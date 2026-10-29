using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Data.SqlClient;


public partial class UI_TSiPASS_IncentiveMISPendencyReportCOI : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();

    decimal GMAssignW, GMAssignB, GMAssign90, InspAssignW, InspAssingB, InspAssign90, InspUploadW, InspUploadB, InspUpload90, GMtoCOIW, GMtoCOIB, GMtoCOI90,
        Query, Total, Total90, Noofappsfiled, Deemed, NoofUnits;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
            

        }
        if (Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424" || Session["uid"].ToString() == "77141" || Session["uid"].ToString() == "34668" || Session["uid"].ToString() == "21345"  )
        {
            if (!IsPostBack)
            {
                FillGridDetails();
                Label1.Text = "Report as on date " + DateTime.Now;
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
        
    }

    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        ds = GetIncentivesMISPendingReport();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal GMAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMInspPendingWithin"));
            GMAssignW = GMAssignW1 + GMAssignW;

            decimal GMAssignB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMInspPendingBeyond"));
            GMAssignB = GMAssignB1 + GMAssignB;

            decimal GMAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMInspPending90"));
            GMAssign90 = GMAssign901 + GMAssign90;

            decimal InspAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspAssignDateWithin"));
            InspAssignW = InspAssignW1 + InspAssignW;

            decimal InspAssingB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspAssignDateBeyond"));
            InspAssingB = InspAssingB1 + InspAssingB;

            decimal InspAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspAssignDate90"));
            InspAssign90 = InspAssign901 + InspAssign90;

            decimal InspUploadW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspUploadWithin"));
            InspUploadW = InspUploadW1 + InspUploadW;

            decimal InspUploadB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspUploadBeyond"));
            InspUploadB = InspUploadB1 + InspUploadB;

            decimal InspUpload901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspUpload90"));
            InspUpload90 = InspUpload901 + InspUpload90;

            decimal GMtoCOIW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMtoCOIWithin"));
            GMtoCOIW = GMtoCOIW1 + GMtoCOIW;

            decimal GMtoCOIB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMtoCOIBeyond"));
            GMtoCOIB = GMtoCOIB1 + GMtoCOIB;

            decimal GMtoCOI901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GMtoCOI90"));
            GMtoCOI90 = GMtoCOI901 + GMtoCOI90;

            decimal Query1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryPending"));
            Query = Query1 + Query;

            decimal Deemed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deemed"));
            Deemed = Deemed1 + Deemed;

            decimal Total1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalPending"));
            Total = Total1 + Total;

            decimal Total901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total90"));
            Total90 = Total901 + Total90;

            decimal Noofappsfiled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsFiled"));
            Noofappsfiled = Noofappsfiled1 + Noofappsfiled;

            decimal NoofUnits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofUnits"));
            NoofUnits = NoofUnits1 + NoofUnits;

            

            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
            h1.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
            h2.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
            h9.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink5");
            h3.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink6");
            h4.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyperLink11");
            h10.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink4");
            h5.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink7");
            h6.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h11 = (HyperLink)e.Row.FindControl("HyperLink12");
            h11.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink8");
            h7.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyperLink9");
            h8.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h12 = (HyperLink)e.Row.FindControl("HyperLink13");
            h12.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h13 = (HyperLink)e.Row.FindControl("HyperLink14");
            h13.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h14 = (HyperLink)e.Row.FindControl("HyperLink15");
            h14.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h15 = (HyperLink)e.Row.FindControl("HyperLink16");
            h15.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=O&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h16 = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            h16.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=P&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h17 = (HyperLink)e.Row.FindControl("HyperLink17");
            h17.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=Q&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h18 = (HyperLink)e.Row.FindControl("HyNoofunits");
            h18.NavigateUrl = "IncentiveMISPendencyReportDrillCOI.aspx?status=R&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            Label GMrecedNOUNITS = new Label();
            GMrecedNOUNITS.Text = NoofUnits.ToString();
            e.Row.Cells[3].Controls.Add(GMrecedNOUNITS);

            Label GMrecedtotal = new Label();
            GMrecedtotal.Text = Noofappsfiled.ToString();
            e.Row.Cells[4].Controls.Add(GMrecedtotal);

            Label GMAssignW1 = new Label();
            GMAssignW1.Text = GMAssignW.ToString();
            e.Row.Cells[5].Controls.Add(GMAssignW1);

            Label GMAssignB1 = new Label();
            GMAssignB1.Text = GMAssignB.ToString();
            e.Row.Cells[6].Controls.Add(GMAssignB1);

            Label GMAssign901 = new Label();
            GMAssign901.Text = GMAssign90.ToString();
            e.Row.Cells[7].Controls.Add(GMAssign901);

            Label InspAssignW1 = new Label();
            InspAssignW1.Text = InspAssignW.ToString();
            e.Row.Cells[8].Controls.Add(InspAssignW1);

            Label InspAssingB1 = new Label();
            InspAssingB1.Text = InspAssingB.ToString();
            e.Row.Cells[9].Controls.Add(InspAssingB1);

            Label InspAssign901 = new Label();
            InspAssign901.Text = InspAssign90.ToString();
            e.Row.Cells[10].Controls.Add(InspAssign901);

            Label InspUploadW1 = new Label();
            InspUploadW1.Text = InspUploadW.ToString();
            e.Row.Cells[11].Controls.Add(InspUploadW1);

            Label InspUploadB1 = new Label();
            InspUploadB1.Text = InspUploadB.ToString();
            e.Row.Cells[12].Controls.Add(InspUploadB1);

            Label InspUpload901 = new Label();
            InspUpload901.Text = InspUpload90.ToString();
            e.Row.Cells[13].Controls.Add(InspUpload901);

            Label GMtoCOIW1 = new Label();
            GMtoCOIW1.Text = GMtoCOIW.ToString();
            e.Row.Cells[14].Controls.Add(GMtoCOIW1);

            Label GMtoCOIB1 = new Label();
            GMtoCOIB1.Text = GMtoCOIB.ToString();
            e.Row.Cells[15].Controls.Add(GMtoCOIB1);

            Label GMtoCOI901 = new Label();
            GMtoCOI901.Text = GMtoCOI90.ToString();
            e.Row.Cells[16].Controls.Add(GMtoCOI901);

            Label Query1 = new Label();
            Query1.Text = Query.ToString();
            e.Row.Cells[17].Controls.Add(Query1);

            Label Deemed1 = new Label();
            Deemed1.Text = Deemed.ToString();
            e.Row.Cells[18].Controls.Add(Deemed1);

            Label Total1 = new Label();
            Total1.Text = Total.ToString();
            e.Row.Cells[19].Controls.Add(Total1);

            Label Total901 = new Label();
            Total901.Text = Total90.ToString();
            e.Row.Cells[20].Controls.Add(Total901);
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15)
                {
                    cellIndex++;
                }
                //else if (i == 5 || i == 6)
                //{
                //    cellIndex++;
                //}
                //else if (i == 7 || i == 8)
                //{
                //    cellIndex++;
                //}
                //else if (i == 9 || i == 10 || i == 11 || i == 12)
                //{
                //    cellIndex++;
                //}
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Assign Inspection";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Inspection Date";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Inspection Report Upload";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage2);

            TableCell tcMergePackage20 = new TableCell();
            tcMergePackage20.Text = "Not Yet Forwarded (SLC/DIPC)";
            tcMergePackage20.CssClass = "GridviewScrollC1Header";
            tcMergePackage20.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage20);
        }


    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

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
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
                //string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
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

                    //this.FillGridDetails();

                    //grdDetails.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

                    // grdExport.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A1, 0f, 0f, 0f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R2-1-STATUS-OF-PRESCRUTINY-DEPARTMENT-WISE.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

    public DataSet GetIncentivesMISPendingReport()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INCENTIVEMISPENDINGREPORTCOI", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 3600;



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
}