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
public partial class UI_TSiPASS_IncentiveClaimsReport : System.Web.UI.Page
{
    General Gen = new General();
    decimal GMAssignW, GMAssignB, GMAssign90, InspAssignW, InspAssingB, InspAssign90, InspUploadW, InspUploadB, InspUpload90, GMtoCOIW, GMtoCOIB, GMtoCOI90, Query, Total, Total90;

    decimal GMAssignWdlc, GMAssignBdlc, GMAssign90dlc, InspAssignWdlc, InspAssingBdlc, InspAssign90dlc, InspUploadWdlc, InspUploadBdlc, InspUpload90dlc, GMtoCOIWdlc, GMtoCOIBdlc, GMtoCOI90dlc, Querydlc, Totaldlc, Total90dlc, Noofclaimesfiled;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            FillGridDetails();
        }
    }

    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        ds = Gen.GetIncentivesMISSanctionPendingReport(ddlProp_intDistrictid.SelectedValue);

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


            decimal Noofclaimesfiled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsFiled"));
            Noofclaimesfiled = Noofclaimesfiled1 + Noofclaimesfiled;

            decimal GMAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedWithinslc"));
            GMAssignW = GMAssignW1 + GMAssignW;

            decimal GMAssignB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedBeyondslc"));
            GMAssignB = GMAssignB1 + GMAssignB;

            decimal GMAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedWithinslc"));
            GMAssign90 = GMAssign901 + GMAssign90;

            decimal InspAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedBeyondslc"));
            InspAssignW = InspAssignW1 + InspAssignW;

            decimal InspAssingB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingWithinslc"));
            InspAssingB = InspAssingB1 + InspAssingB;

            decimal InspAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingBeyondslc"));
            InspAssign90 = InspAssign901 + InspAssign90;

            decimal InspUploadW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending90slc"));
            InspUploadW = InspUploadW1 + InspUploadW;

            // dlc

            decimal GMAssignW1dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedWithindlc"));
            GMAssignWdlc = GMAssignW1dlc + GMAssignWdlc;

            decimal GMAssignB1dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedBeyonddlc"));
            GMAssignBdlc = GMAssignB1dlc + GMAssignBdlc;

            decimal GMAssign901dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedWithindlc"));
            GMAssign90 = GMAssign901 + GMAssign90;

            decimal InspAssignW1dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedBeyonddlc"));
            InspAssignWdlc = InspAssignW1dlc + InspAssignWdlc;

            decimal InspAssingB1dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingWithindlc"));
            InspAssingBdlc = InspAssingB1dlc + InspAssingBdlc;

            decimal InspAssign901dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingBeyonddlc"));
            InspAssign90dlc = InspAssign901dlc + InspAssign90dlc;

            decimal InspUploadW1dlc = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending90dlc"));
            InspUploadWdlc = InspUploadW1dlc + InspUploadWdlc;





            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
            h1.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
            h2.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
            h9.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink5");
            h3.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink6");
            h4.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyperLink11");
            h10.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink4");
            h5.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            // DLC

            HyperLink h1dlc = (HyperLink)e.Row.FindControl("HyperLink2dlc");
            h1dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h2dlc = (HyperLink)e.Row.FindControl("HyperLink3dlc");
            h2dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h9dlc = (HyperLink)e.Row.FindControl("HyperLink10dlc");
            h9dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h3dlc = (HyperLink)e.Row.FindControl("HyperLink5dlc");
            h3dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h4dlc = (HyperLink)e.Row.FindControl("HyperLink6dlc");
            h4dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h10dlc = (HyperLink)e.Row.FindControl("HyperLink11dlc");
            h10dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h5dlc = (HyperLink)e.Row.FindControl("HyperLink4dlc");
            h5dlc.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink hNoofapps = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            hNoofapps.NavigateUrl = "IncentiveSanctionMISPendencyReportDrill.aspx?status=P&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";



            Label Noofclaimesfiledlbl = new Label();
            Noofclaimesfiledlbl.Text = Noofclaimesfiled.ToString();
            e.Row.Cells[3].Controls.Add(Noofclaimesfiledlbl);

            Label GMAssignW1 = new Label();
            GMAssignW1.Text = GMAssignW.ToString();
            e.Row.Cells[4].Controls.Add(GMAssignW1);

            Label GMAssignB1 = new Label();
            GMAssignB1.Text = GMAssignB.ToString();
            e.Row.Cells[5].Controls.Add(GMAssignB1);

            Label GMAssign901 = new Label();
            GMAssign901.Text = GMAssign90.ToString();
            e.Row.Cells[8].Controls.Add(GMAssign901);

            Label InspAssignW1 = new Label();
            InspAssignW1.Text = InspAssignW.ToString();
            e.Row.Cells[9].Controls.Add(InspAssignW1);

            Label InspAssingB1 = new Label();
            InspAssingB1.Text = InspAssingB.ToString();
            e.Row.Cells[12].Controls.Add(InspAssingB1);

            Label InspAssign901 = new Label();
            InspAssign901.Text = InspAssign90.ToString();
            e.Row.Cells[13].Controls.Add(InspAssign901);

            Label InspUploadW1 = new Label();
            InspUploadW1.Text = InspUploadW.ToString();
            e.Row.Cells[14].Controls.Add(InspUploadW1);

            // DLC

            Label GMAssignW1DLC = new Label();
            GMAssignW1DLC.Text = GMAssignWdlc.ToString();
            e.Row.Cells[6].Controls.Add(GMAssignW1DLC);

            Label GMAssignB1DLC = new Label();
            GMAssignB1DLC.Text = GMAssignBdlc.ToString();
            e.Row.Cells[7].Controls.Add(GMAssignB1DLC);

            Label GMAssign901DLC = new Label();
            GMAssign901DLC.Text = GMAssign90dlc.ToString();
            e.Row.Cells[10].Controls.Add(GMAssign901DLC);

            Label InspAssignW1DLC = new Label();
            InspAssignW1DLC.Text = InspAssignWdlc.ToString();
            e.Row.Cells[11].Controls.Add(InspAssignW1DLC);

            Label InspAssingB1DLC = new Label();
            InspAssingB1DLC.Text = InspAssingBdlc.ToString();
            e.Row.Cells[15].Controls.Add(InspAssingB1DLC);

            Label InspAssign901DLC = new Label();
            InspAssign901DLC.Text = InspAssign90dlc.ToString();
            e.Row.Cells[16].Controls.Add(InspAssign901DLC);

            Label InspUploadW1DLC = new Label();
            InspUploadW1DLC.Text = InspUploadWdlc.ToString();
            e.Row.Cells[17].Controls.Add(InspUploadW1DLC);

            //Label InspUploadB1 = new Label();
            //InspUploadB1.Text = InspUploadB.ToString();
            //e.Row.Cells[10].Controls.Add(InspUploadB1);

            //Label InspUpload901 = new Label();
            //InspUpload901.Text = InspUpload90.ToString();
            //e.Row.Cells[11].Controls.Add(InspUpload901);

            //Label GMtoCOIW1 = new Label();
            //GMtoCOIW1.Text = GMtoCOIW.ToString();
            //e.Row.Cells[12].Controls.Add(GMtoCOIW1);

            //Label GMtoCOIB1 = new Label();
            //GMtoCOIB1.Text = GMtoCOIB.ToString();
            //e.Row.Cells[13].Controls.Add(GMtoCOIB1);

            //Label GMtoCOI901 = new Label();
            //GMtoCOI901.Text = GMtoCOI90.ToString();
            //e.Row.Cells[14].Controls.Add(GMtoCOI901);

            //Label Query1 = new Label();
            //Query1.Text = Query.ToString();
            //e.Row.Cells[15].Controls.Add(Query1);

            //Label Total1 = new Label();
            //Total1.Text = Total.ToString();
            //e.Row.Cells[16].Controls.Add(Total1);

            //Label Total901 = new Label();
            //Total901.Text = Total90.ToString();
            //e.Row.Cells[17].Controls.Add(Total901);
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
                if ( i == 4)
                {
                    cellIndex++;
                }
                else if (i == 5 || i == 6)
                {
                    cellIndex++;
                }
                else if (i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15 || i == 16 || i == 17)
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
            tcMergePackage.Text = "SLC";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "DLC";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage1.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "SLC";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage2.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);


            TableCell tcMergePackage3 = new TableCell();
            tcMergePackage3.Text = "DLC";
            tcMergePackage3.CssClass = "GridviewScrollC1Header";
            tcMergePackage3.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage3.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "SLC";
            tcMergePackage4.CssClass = "GridviewScrollC1Header";
            tcMergePackage4.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage4.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell();
            tcMergePackage5.Text = "DLC";
            tcMergePackage5.CssClass = "GridviewScrollC1Header";
            tcMergePackage5.HorizontalAlign = HorizontalAlign.Center;
            tcMergePackage5.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage5);



            //TableCell tcMergePackage20 = new TableCell();
            //tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
            //tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage20.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage20);
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
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
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

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

}