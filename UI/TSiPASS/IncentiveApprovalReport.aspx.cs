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
    decimal NoOfClaims, ForwardedCOI, ForwardedDLC, SLCCount, SLCAmount, DLCCount, DLCAmount, TotalCount, TotalAmount, ReleaseCount, ReleaseAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
          
            if (Request.QueryString["fromdt"] != null && Request.QueryString["fromdt"] != "" && Request.QueryString["todt"] != null && Request.QueryString["todt"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdt"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todt"].ToString().Trim();
                //if (Request.QueryString["Category"] != null && Request.QueryString["Category"] != "")
                //{
                //    ddlCategory.SelectedValue = Request.QueryString["Category"].ToString();
                //}

                FillGridDetails();
            }
        }
    }
   
    protected void BtnSave1_Click(object sender, System.EventArgs e)
    {
        int valid = 0;

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        //if (ddlCaste.SelectedItem.Text== "--Select--")
        //{
        //    lblmsg0.Text += "Please Select Caste <br/>";
        //    valid = 1;
        //}
        if (valid == 1)
        {
            Failure.Visible = true;
        }

        if (valid == 0)
        {
            Failure.Visible = false;
            FillGridDetails();
        }
    }
    public void FillGridDetails()
    {
        DataSet ds = new DataSet();

        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        // ds = Gen.GetIncentivesClaimedReport(ddlCategory.SelectedItem.ToString().Trim(), ddldistrict.SelectedValue, FromdateforDB, TodateforDB);
        ds = Gen.GetIncentivesApprovalReport(FromdateforDB, TodateforDB);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
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
            decimal NoOfClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Totalapplied"));
            NoOfClaims = NoOfClaims1 + NoOfClaims;

            decimal ForwardedCOI1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ForwardedbyGM"));
            ForwardedCOI = ForwardedCOI1 + ForwardedCOI;

            decimal ForwardedDLC1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved"));
            ForwardedDLC = ForwardedDLC1 + ForwardedDLC;

            decimal SLCCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending"));
            SLCCount = SLCCount1 + SLCCount;

            decimal SLCAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            SLCAmount = SLCAmount1 + SLCAmount;

            decimal DLCCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingWithin"));
            DLCCount = DLCCount1 + DLCCount;

            decimal DLCAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingBeyond"));
            DLCAmount = DLCAmount1 + DLCAmount;



            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
            h1.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
            h2.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink5");
            h3.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink6");
            h4.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink4");
            h5.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink7");
            h6.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink8");
            h7.NavigateUrl = "IncentiveApprovalReportDrill.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            Label Claims = new Label();
            Claims.Text = NoOfClaims.ToString();
            e.Row.Cells[2].Controls.Add(Claims);

            Label COI = new Label();
            COI.Text = ForwardedCOI.ToString();
            e.Row.Cells[3].Controls.Add(COI);

            Label DLC = new Label();
            DLC.Text = ForwardedDLC.ToString();
            e.Row.Cells[4].Controls.Add(DLC);

            Label SLCC = new Label();
            SLCC.Text = SLCCount.ToString();
            e.Row.Cells[5].Controls.Add(SLCC);

            Label SLCA = new Label();
            SLCA.Text = SLCAmount.ToString();
            e.Row.Cells[6].Controls.Add(SLCA);

            Label DLCC = new Label();
            DLCC.Text = DLCCount.ToString();
            e.Row.Cells[7].Controls.Add(DLCC);

            Label DLCA = new Label();
            DLCA.Text = DLCAmount.ToString();
            e.Row.Cells[8].Controls.Add(DLCA);

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

            //for (int i = 0; i < headerCellCount; i++)
            //{
            //    if (i == 5 || i == 6 || i == 7)
            //    {
            //        cellIndex++;
            //    }
            //    else
            //    {
            //        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
            //        tcHeader.RowSpan = 2;
            //        gvHeaderRowCopy.Cells.Add(tcHeader);
            //    }
            //}


            //TableCell tcMergePackage = new TableCell();
            //tcMergePackage.Text = "Approvals";
            //tcMergePackage.CssClass = "GridviewScrollC1Header";
            //tcMergePackage.ColumnSpan = 3;
            //gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage);


            //TableCell tcMergePackage1 = new TableCell();
            //tcMergePackage1.Text = "Pending to Assign Inspection Date";
            //tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage1.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage1);

            //TableCell tcMergePackage2 = new TableCell();
            //tcMergePackage2.Text = "Pending to Upload Inspection Report";
            //tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage2.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage2);

            //TableCell tcMergePackage20 = new TableCell();
            //tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
            //tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage20.ColumnSpan = 2;
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
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
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

}