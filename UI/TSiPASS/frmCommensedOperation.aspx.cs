using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmCommensedOperation : System.Web.UI.Page
{
    decimal withinmonths, WithMonthly, monthYear, Years, WithYear, AboveYear, Totals,Offline, yetto, initial, advanced, Totalind;
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    DB.DB con = new DB.DB();
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Operation();
            Yera();
        }
        lbllabel.Text = DateTime.Now.ToString("dd-MM-yyyy");
    }
    public void Operation()
    {
       
        try
        {
            //lblhdngmsg.Text = "Applications to be Processed";
            //grdCompleted.Visible = false; //Completed Grid

            DataSet dsn = new DataSet();
            SqlDataAdapter da;
            con.OpenConnection();

            //da = new SqlDataAdapter("SP_SENDALLTOSVC_DEPARTMENTWISE", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_IMPLIMENTAION_COMMENCED", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@ONLINEFLAG", SqlDbType.VarChar).Value = "%";
            da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value=ddlYear.SelectedItem.Value;           
            da.Fill(dsn);
            con.CloseConnection();
            if (dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
            {
                grdOperation.DataSource = dsn.Tables[0];
                grdOperation.DataBind();
            }
            else
            {
                grdOperation.DataSource = null;
                grdOperation.DataBind();
                //lblmsg0.Text = "No Records Found";
                //Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            throw ex;
        }

    }

    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        PrintPdf();
    }

    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdOperation.AllowPaging = false;
                    // this.fillgrid();
                    grdOperation.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdOperation.FooterRow.ForeColor = System.Drawing.Color.Black;
                    //grdOperation.Columns[1].Visible = false;
                    grdOperation.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= COMMENCED OPERATION.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                Government.Visible = true;
                divPrint1.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);
                string label1text = Label2.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void grdOperation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal WithMonthy = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WITHIN3MONTHS"));
            withinmonths = WithMonthy + withinmonths;

            decimal Monthly = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FRM3TO6SIXMONTHS"));
            WithMonthly = Monthly + WithMonthly;

            decimal Yearly = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FRM6MTO1YR"));
            monthYear = Yearly + monthYear;

            decimal Year = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FRM1YRTO2YRS"));
            Years = Year + Years;

            decimal With = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FRM2TO3YRS"));
            WithYear = With + WithYear;

            decimal Above = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ABOVE3YRS"));
            AboveYear = Above + AboveYear;

            decimal WithTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "COMMENCED_OPERATIONS"));
            Totals = WithTotal + Totals;

            decimal withOffline = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "OFFLINE"));
            Offline = withOffline + Offline;

            int YettoStart = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "YETTOSTART"));
            yetto = yetto + YettoStart;
            
            int InitialStage = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "INITIALSTAGE"));
            initial = initial + InitialStage;

            int AdvancedStage = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ADVANCESTAGE"));
            advanced = advanced + AdvancedStage;

            int Totalind1= Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalInd"));
            Totalind = Totalind + Totalind1;

            HyperLink h10 = (HyperLink)e.Row.Cells[2].Controls[0];
            h10.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&Year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=I";
            h10.Target = "_blank";

            HyperLink h11 = (HyperLink)e.Row.Cells[3].Controls[0];
            h11.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&Year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=J";
            h11.Target = "_blank";

            HyperLink h12 = (HyperLink)e.Row.Cells[4].Controls[0];
            h12.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&Year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=K";
            h12.Target = "_blank";

            HyperLink h7 = (HyperLink)e.Row.Cells[5].Controls[0];
            h7.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=G";
            h7.Target = "_blank";


            HyperLink h1 = (HyperLink)e.Row.Cells[6].Controls[0];
            h1.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value  + "&ONLINEFLAG=%" + "&Status=A";
            h1.Target = "_blank";

            HyperLink h2 = (HyperLink)e.Row.Cells[7].Controls[0];
            h2.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=B";
            h2.Target = "_blank";

            HyperLink h3 = (HyperLink)e.Row.Cells[8].Controls[0];
            h3.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=C";
            h3.Target = "_blank";

            HyperLink h4 = (HyperLink)e.Row.Cells[9].Controls[0];
            h4.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=D";
            h4.Target = "_blank";

            HyperLink h5 = (HyperLink)e.Row.Cells[10].Controls[0];
            h5.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=E";
            h5.Target = "_blank";

            HyperLink h6 = (HyperLink)e.Row.Cells[11].Controls[0];
            h6.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=F";
            h6.Target = "_blank";

            HyperLink htotal = (HyperLink)e.Row.Cells[12].Controls[0];
            htotal.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=L";
            htotal.Target = "_blank";



            //HyperLink h9 = (HyperLink)e.Row.Cells[9].Controls[0];
            //h9.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&Year" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=NO" + "&Status=H";
            //h9.Target = "_blank";



        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";

            HyperLink hyetto = new HyperLink();
            hyetto.ForeColor = System.Drawing.Color.White;
            hyetto.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=I";
            hyetto.Target = "_blank";
            hyetto.Text = yetto.ToString();
            e.Row.Cells[2].Text = yetto.ToString();
            e.Row.Cells[2].Controls.Add(hyetto);

            HyperLink Initial = new HyperLink();
            Initial.ForeColor = System.Drawing.Color.White;
            Initial.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=J";
            Initial.Target = "_blank";
            Initial.Text = initial.ToString();
            e.Row.Cells[3].Text = initial.ToString();
            e.Row.Cells[3].Controls.Add(Initial);

            HyperLink hadvanced = new HyperLink();
            hadvanced.ForeColor = System.Drawing.Color.White;
            hadvanced.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=K";
            hadvanced.Target = "_blank";
            hadvanced.Text = advanced.ToString();
            e.Row.Cells[4].Text = advanced.ToString();
            e.Row.Cells[4].Controls.Add(hadvanced);

            HyperLink Yearlys = new HyperLink();
            Yearlys.ForeColor = System.Drawing.Color.White;
            Yearlys.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=G";
            Yearlys.Target = "_blank";
            Yearlys.Text = Totals.ToString();
            e.Row.Cells[5].Text = Totals.ToString();
            e.Row.Cells[5].Controls.Add(Yearlys);

            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=A";
            Total.Text = withinmonths.ToString();
            e.Row.Cells[6].Text = withinmonths.ToString();
            e.Row.Cells[6].Controls.Add(Total);

            HyperLink Beyond = new HyperLink();

            Beyond.ForeColor = System.Drawing.Color.White;
            Beyond.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=B";
            Beyond.Target = "_blank";
            Beyond.Text = WithMonthly.ToString();
            e.Row.Cells[7].Text = WithMonthly.ToString();
            e.Row.Cells[7].Controls.Add(Beyond);

            HyperLink Month = new HyperLink();
            Month.ForeColor = System.Drawing.Color.White;
            Month.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=C";
            Month.Target = "_blank";
            Month.Text = monthYear.ToString();
            e.Row.Cells[8].Text = monthYear.ToString();
            e.Row.Cells[8].Controls.Add(Month);

            HyperLink Yearly = new HyperLink();
            Yearly.ForeColor = System.Drawing.Color.White;
            Yearly.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=D";
            Yearly.Target = "_blank";
            Yearly.Text = Years.ToString();
            e.Row.Cells[9].Text = Years.ToString();
            e.Row.Cells[9].Controls.Add(Yearly);

            HyperLink Operated = new HyperLink();
            Operated.ForeColor = System.Drawing.Color.White;
            Operated.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() + "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=E";
            Operated.Target = "_blank";
            Operated.Text = WithYear.ToString();
            e.Row.Cells[10].Text = WithYear.ToString();
            e.Row.Cells[10].Controls.Add(Operated);

            HyperLink Commende = new HyperLink();
            Commende.ForeColor = System.Drawing.Color.White;
            Commende.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=F";
            Commende.Target = "_blank";
            Commende.Text = AboveYear.ToString();
            e.Row.Cells[11].Text = AboveYear.ToString();
            e.Row.Cells[11].Controls.Add(Commende);

            HyperLink TotIndustries = new HyperLink();
            TotIndustries.ForeColor = System.Drawing.Color.White;
            TotIndustries.NavigateUrl = "CommensedOperationDrilldown.aspx?dist=%" + /*Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISRICT")).Trim() +*/ "&year=" + ddlYear.SelectedItem.Value + "&ONLINEFLAG=%" + "&Status=L";
            TotIndustries.Target = "_blank";
            TotIndustries.Text = Totalind.ToString();
            e.Row.Cells[12].Text = Totalind.ToString();
            e.Row.Cells[12].Controls.Add(TotIndustries);





        }
    }

    protected void grdOperation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdOperation_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // GridView HeaderGrid = (GridView)sender;

            // GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            // HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            // TableCell HeaderCell0 = new TableCell();
            // HeaderCell0.Text = "";
            // HeaderCell0.ColumnSpan = 1;
            // HeaderCell0.RowSpan = 1;
            // HeaderGridRow.Cells.Add(HeaderCell0);

            // TableCell HeaderCell1 = new TableCell();
            // HeaderCell1.Text = "";
            // HeaderCell1.ColumnSpan = 1;
            // HeaderCell1.RowSpan = 1;
            // HeaderGridRow.Cells.Add(HeaderCell1);

            // TableCell HeaderCell3 = new TableCell();
            // HeaderCell3.Text = "Yet to Start Construction";
            // HeaderCell3.ColumnSpan = 1;
            // HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell3);

            // TableCell HeaderCell4 = new TableCell();
            // HeaderCell4.Text = "Initial Stage";
            // HeaderCell4.ColumnSpan = 1;
            // HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell4);

            // TableCell HeaderCell5 = new TableCell();
            // HeaderCell5.Text = "Advanced Stage";
            // HeaderCell5.ColumnSpan = 1;
            // HeaderCell5.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell5);

            // TableCell HeaderCell6 = new TableCell();
            // HeaderCell6.Text = "Commenced";
            // HeaderCell6.ColumnSpan = 1;
            // HeaderCell6.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell6);


            // TableCell HeaderCell2 = new TableCell();
            // HeaderCell2.Text = "Commensed Operations ";
            // HeaderCell2.ColumnSpan = 6;
            // HeaderCell2.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell2);

            // TableCell HeaderCell7 = new TableCell();
            // HeaderCell7.Text = "Total No.of Industries";
            // HeaderCell7.ColumnSpan = 1;
            ////HeaderCell7.RowSpan = 2;
            // HeaderCell7.HorizontalAlign = HorizontalAlign.Center;
            // HeaderGridRow.Cells.Add(HeaderCell7);
            // grdOperation.Controls[0].Controls.AddAt(0, HeaderGridRow);

            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdOperation.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i ==5 || i == 6 || i == 7 || i == 8||i == 9 || i == 10 || i == 11)
                {
                    cellIndex++;
                }                
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Commensed Operations ";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 7;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);


            //TableCell tcMergePackage1 = new TableCell();
            //tcMergePackage1.Text = "Pending to Assign Inspection Date";
            //tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage1.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

            //TableCell tcMergePackage2 = new TableCell();
            //tcMergePackage2.Text = "Pending to Upload Inspection Report";
            //tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage2.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

            //TableCell tcMergePackage20 = new TableCell();
            //tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
            //tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage20.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage20);
        }
    }
    protected void grdOperation_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Yera()
    {
        DataSet dsnew = new DataSet();
        dsnew = SP_GETFINANCIALYEARS();
        ddlYear.DataSource = dsnew.Tables[0];
        ddlYear.DataTextField = "FinancialYear";
        ddlYear.DataValueField = "FYEAR";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, "--Select--");
    }
    public DataSet SP_GETFINANCIALYEARS()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETFINANCIALYEARS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Operation();

    }
}