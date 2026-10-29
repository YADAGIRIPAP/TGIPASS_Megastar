using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_WeakerSectionPlotDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            if (Session["Role_Code"].ToString() == "GM" || Session["Role_Code"].ToString() == "IPO"
       || Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "DD"
           || Session["Role_Code"].ToString() == "JD")
            {
                if (!IsPostBack)
                {
                    Binddata(Request.QueryString[0], Request.QueryString[1], Request.QueryString[2], Request.QueryString[3]);
                }
            }
            else { Response.Redirect("~/TSHome.aspx"); }
        }
    }
    protected void Binddata(string Districtid, string type, string fromdate, string todate)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_Weakersectionplotdetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.Date).Value = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.Date).Value = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            //if (Session["Role_Code"].ToString() == "JD")
            //{
            //    da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            //}
            //else
            //{
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = Districtid;
            //}
            da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;
            da.Fill(ds);
            con.CloseConnection();
            lblForGrid.Visible = true;

            if (type.TrimStart().TrimEnd() == "IE")
            {
                lblForGrid.Text = "IE Details";
                grdsupport.DataSource = ds.Tables[0];
                grdsupport.DataBind();

            }
            if (type == "AllotableSC")
            {
                lblForGrid.Text = "Allotable SC Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();

                grdallotable.Columns[7].Visible = false;//ST
                grdallotable.Columns[8].Visible = false;//BC
                grdallotable.Columns[9].Visible = false;//Min
                grdallotable.Columns[10].Visible = false;//Women
                grdallotable.Columns[11].Visible = false;//General

            }
            if (type == "AllotableST")
            {
                lblForGrid.Text = "Allotable ST Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();

                grdallotable.Columns[6].Visible = false;//SC

                grdallotable.Columns[8].Visible = false;//BC
                grdallotable.Columns[9].Visible = false;//Min
                grdallotable.Columns[10].Visible = false;//Women
                grdallotable.Columns[11].Visible = false;//General

            }
            if (type == "AllotableBC")
            {
                lblForGrid.Text = "Allotable BC Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();

                grdallotable.Columns[6].Visible = false;//SC
                grdallotable.Columns[7].Visible = false;//ST
                                                        
                grdallotable.Columns[9].Visible = false;//Min
                grdallotable.Columns[10].Visible = false;//Women
                grdallotable.Columns[11].Visible = false;//General

            }
            if (type == "AllotableMinority")
            {
                lblForGrid.Text = "Allotable Minority Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();
                grdallotable.Columns[6].Visible = false;//SC
                grdallotable.Columns[7].Visible = false;//ST
                grdallotable.Columns[8].Visible = false;//BC
                
                grdallotable.Columns[10].Visible = false;//Women
                grdallotable.Columns[11].Visible = false;//General

            }            
            if (type == "AllotableWomen")
            {
                lblForGrid.Text = "Allotable Women Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();

                grdallotable.Columns[6].Visible = false;//SC
                grdallotable.Columns[7].Visible = false;//ST
                grdallotable.Columns[8].Visible = false;//BC
                grdallotable.Columns[9].Visible = false;//Min
                
                grdallotable.Columns[11].Visible = false;//General

            }
            if (type == "AllotableGeneral")
            {
                lblForGrid.Text = "Allotable General Plot Details";
                grdallotable.DataSource = ds.Tables[0];
                grdallotable.DataBind();
                grdallotable.Columns[6].Visible = false;//SC
                grdallotable.Columns[7].Visible = false;//ST
                grdallotable.Columns[8].Visible = false;//BC
                grdallotable.Columns[9].Visible = false;//Min
                grdallotable.Columns[10].Visible = false;//Women
            }
        }
        catch (Exception Ex)
        { throw Ex; }
    }


    protected void grdsupport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.EmptyDataRow, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "IE and Officer Details";

            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderGridRow.BackColor = ColorTranslator.FromHtml("#009688");
            //HeaderGridRow.ForeColor = ColorTranslator.FromHtml("#FFFFFF");
            //HeaderGridRow.BorderStyle = BorderStyle.Solid;
            //HeaderGridRow.BorderColor = ColorTranslator.FromHtml("#FFFFFF");
            HeaderGridRow.HorizontalAlign = HorizontalAlign.Center;

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Mandated";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Alloted";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Vacant";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = "Total No.of Plots Allotable";
            HeaderCell.ColumnSpan = 6;
            HeaderGridRow.Cells.Add(HeaderCell);



            grdsupport.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }

    protected void grdsupport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");

            DataSet dss = new DataSet();
            Label campId = (Label)e.Row.FindControl("lblcampid");
            GridView grdplots = (GridView)e.Row.FindControl("grdPlots");

            //con.OpenConnection();
            //SqlDataAdapter da = new SqlDataAdapter("SP_GetPlotDetails", con.GetConnection);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.Add("@PmegpId", SqlDbType.VarChar).Value = PmegpId.Text;
            //da.Fill(dss);
            //con.CloseConnection();

            //grdplots.DataSource = dss.Tables[0];
            //grdplots.DataBind();

            //HyperLink hprint = (HyperLink)e.Row.Cells[1].Controls[0];
            //hprint.NavigateUrl = "CampsConductedPrint.aspx?Campid=" + campId.Text;
        }

    }
    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        lblHeading.Visible = true;
        //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
        using (StringWriter sw = new StringWriter())
        {

            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                grdsupport.AllowPaging = false;

                // this.fillgrid();

                grdsupport.HeaderRow.ForeColor = System.Drawing.Color.Black;
                grdsupport.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                grdsupport.FooterRow.ForeColor = System.Drawing.Color.Black;
                // grdExport.Columns[1].Visible = false;
                grdsupport.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=R6.1:TSiPASS-TotalReportold2NewReport" + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }


    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {
        try
        {
            lblHeading.Visible = true;
            //  GrdwmenEntpnrdtls.Columns[6].Visible = false;
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
                grdsupport.Style["width"] = "680px";
                Button1.Visible = false;
                Button2.Visible = false;
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdsupport.RenderControl(hw);
                string label1text = lblForGrid.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='5'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='5'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            //Button1.Visible = true;
            //Button2.Visible = true;
        }
        catch (Exception e)
        {

        }
        // Handle exceptions appropriately, e.g., log or display an error message
    }
}