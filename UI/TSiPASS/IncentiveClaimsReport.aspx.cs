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
    decimal NoOfClaims, ForwardedCOI, ForwardedDLC, SLCCount, SLCAmount, DLCCount, DLCAmount,TotalCountmanu,TotalCountserv, TotalCount, TotalAmount, ReleaseCount, ReleaseAmount, NoOfUnits;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            GetCasteMaster();
            GetIncentiveTypes();
            ddlCaste.SelectedValue = "All";
            ddlIncentiveType.SelectedValue = "All";
            if (Request.QueryString["fromdt"] != null && Request.QueryString["fromdt"] != "" && Request.QueryString["todt"] != null && Request.QueryString["todt"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdt"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todt"].ToString().Trim();
                //if (Request.QueryString["Category"] != null && Request.QueryString["Category"] != "")
                //{
                //    ddlCategory.SelectedValue = Request.QueryString["Category"].ToString();
                //}
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
            else
            {

                txtFromDate.Text = "01-04-2016";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
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
    }
    protected void GetCasteMaster()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetCasteForReports();
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            ddlCaste.DataSource = dsnew.Tables[0];
            ddlCaste.DataTextField = "Caste_Name";
            ddlCaste.DataValueField = "intCasteId";
            ddlCaste.DataBind();
        }
    }
    protected void GetIncentiveTypes()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetIncentiveTypesForReports();
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            ddlIncentiveType.DataSource = dsnew.Tables[0];
            ddlIncentiveType.DataTextField = "IncentiveName";
            ddlIncentiveType.DataValueField = "IncentiveID";
            ddlIncentiveType.DataBind();
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

      //  Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        // ds = Gen.GetIncentivesClaimedReport(ddlCategory.SelectedItem.ToString().Trim(), ddldistrict.SelectedValue, FromdateforDB, TodateforDB);
        ds = Gen.GetIncentivesClaimedReport(ddlCaste.SelectedValue, ddlEnterPriseType.SelectedValue, ddlIncentiveType.SelectedValue, FromdateforDB, TodateforDB, ddlSector.SelectedValue, ddlManufacture.SelectedValue, ddlProp_intDistrictid.SelectedValue);

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
            decimal Noofunits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Noofunits"));
            NoOfUnits = Noofunits1 + NoOfUnits;

            decimal NoOfClaims1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsFiled"));
            NoOfClaims = NoOfClaims1 + NoOfClaims;

            decimal ForwardedCOI1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ClaimsForwardedtoCOI"));
            ForwardedCOI = ForwardedCOI1 + ForwardedCOI;

            decimal ForwardedDLC1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ClaimsForwardedtoDLC"));
            ForwardedDLC = ForwardedDLC1 + ForwardedDLC;

            decimal SLCCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsApprovedbySLC"));
            SLCCount = SLCCount1 + SLCCount;

            decimal SLCAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountofClaimsApprovedbySLC"));
            SLCAmount = SLCAmount1 + SLCAmount;

            decimal DLCCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofClaimsApprovedbyDLC"));
            DLCCount = DLCCount1 + DLCCount;

            decimal DLCAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountofClaimsApprovedbyDLC"));
            DLCAmount = DLCAmount1 + DLCAmount;

            decimal TotalCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalClaimsApprovedbySLCDLC"));
            TotalCount = TotalCount1 + TotalCount;

            decimal TotalAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountofClaimsApprovedbySLCDLC"));
            TotalAmount = TotalAmount1 + TotalAmount;

            decimal ReleaseCount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NoofReleases"));
            ReleaseCount = ReleaseCount1 + ReleaseCount;

            decimal ReleaseAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountforReleases"));
            ReleaseAmount = ReleaseAmount1 + ReleaseAmount;


            decimal TotalCountmanu1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalClaimsApprovedbySLCDLCmanufacture"));
            TotalCountmanu = TotalCountmanu1 + TotalCountmanu;


            decimal TotalCountserv1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalClaimsApprovedbySLCDLCSERVICE"));
            TotalCountserv = TotalCountserv1 + TotalCountserv;

            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
            h1.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
            h2.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink4");
            h3.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink5");
            h4.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink6");
            h5.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink7");
            h6.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink8");
            h7.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyperLink9");
            h8.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
            h9.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyperLink11");
            h10.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h11 = (HyperLink)e.Row.FindControl("HyperLink12");
            h11.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            //HyperLink h12 = (HyperLink)e.Row.FindControl("hypnoofunits");
            //h12.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h13 = (HyperLink)e.Row.FindControl("HyperLinkMANU");
            h13.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();

            HyperLink h14 = (HyperLink)e.Row.FindControl("HyperLinkSERVICE");
            h14.NavigateUrl = "IncentiveClaimsReportDrill.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim() + "&Category=" + ddlCaste.SelectedValue + "&IncentiveType=" + ddlIncentiveType.SelectedValue + "&EntType=" + ddlEnterPriseType.SelectedValue + "&Sector=" + ddlSector.SelectedValue + "&Subsector=" + ddlManufacture.SelectedValue + "&fromdt=" + txtFromDate.Text.Trim() + "&todt=" + txtTodate.Text.Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            Label units = new Label();
            units.Text = NoOfUnits.ToString();
            e.Row.Cells[2].Text = NoOfUnits.ToString();
            e.Row.Cells[2].Controls.Add(units);


            Label Claims = new Label();
            Claims.Text = NoOfClaims.ToString();
            e.Row.Cells[3].Text = NoOfClaims.ToString();
            e.Row.Cells[3].Controls.Add(Claims);

            Label COI = new Label();
            COI.Text = ForwardedCOI.ToString();
            e.Row.Cells[4].Text = ForwardedCOI.ToString();
            e.Row.Cells[4].Controls.Add(COI);

            Label DLC = new Label();
            DLC.Text = ForwardedDLC.ToString();
            e.Row.Cells[5].Text = ForwardedDLC.ToString();
            e.Row.Cells[5].Controls.Add(DLC);

            Label SLCC = new Label();
            SLCC.Text = SLCCount.ToString();
            e.Row.Cells[6].Text = SLCCount.ToString();
            e.Row.Cells[6].Controls.Add(SLCC);

            Label SLCA = new Label();
            SLCA.Text = SLCAmount.ToString();
            e.Row.Cells[7].Text = SLCAmount.ToString();
            e.Row.Cells[7].Controls.Add(SLCA);

            Label DLCC = new Label();
            DLCC.Text = DLCCount.ToString();
            e.Row.Cells[8].Text = DLCCount.ToString();
            e.Row.Cells[8].Controls.Add(DLCC);

            Label DLCA = new Label();
            DLCA.Text = DLCAmount.ToString();
            e.Row.Cells[9].Text = DLCAmount.ToString();
            e.Row.Cells[9].Controls.Add(DLCA);
            
            Label TotalC = new Label();
            TotalC.Text = TotalCount.ToString();
            e.Row.Cells[10].Text = TotalCount.ToString();
            e.Row.Cells[10].Controls.Add(TotalC);

            Label Totalserv = new Label();
            Totalserv.Text = TotalCountserv.ToString();
            e.Row.Cells[12].Text = TotalCountserv.ToString();
            e.Row.Cells[12].Controls.Add(Totalserv);

            Label Totalmanu = new Label();
            Totalmanu.Text = TotalCountmanu.ToString();
            e.Row.Cells[11].Text = TotalCountmanu.ToString();
            e.Row.Cells[11].Controls.Add(Totalmanu);

            

            Label TotalA = new Label();
            TotalA.Text = TotalAmount.ToString();
            e.Row.Cells[13].Text = TotalAmount.ToString();
            e.Row.Cells[13].Controls.Add(TotalA);

            Label ReleaseC = new Label();
            ReleaseC.Text = ReleaseCount.ToString();
            e.Row.Cells[14].Text = ReleaseCount.ToString();
            e.Row.Cells[14].Controls.Add(ReleaseC);

            Label ReleaseA = new Label();
            ReleaseA.Text = ReleaseAmount.ToString();
            e.Row.Cells[15].Text = ReleaseAmount.ToString();
            e.Row.Cells[15].Controls.Add(ReleaseA);
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
                if (i == 4 || i == 5 || i == 6)
                {
                    cellIndex++;
                }
                else if (i == 7 || i == 8 || i == 9)
                {
                    cellIndex++;
                }
                else if (i == 10 || i == 11 || i == 12 || i == 13)
                {
                    cellIndex++;
                }
                //else if (i == 12 || i == 13||i == 14)
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
            tcMergePackage.Text = "SLC";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);


            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "DLC";
            tcMergePackage1.CssClass = "GridviewScrollC1Header";
            tcMergePackage1.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Total Claims Approved by SLC/DLC";
            tcMergePackage2.CssClass = "GridviewScrollC1Header";
            tcMergePackage2.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage2);

            //TableCell tcMergePackage20 = new TableCell();
            //tcMergePackage20.Text = "Releases";
            //tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
            //tcMergePackage20.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage20);

            //TableCell tcMergePackage4 = new TableCell();
            //tcMergePackage4.Text = "No. of Releases";
            //tcMergePackage4.CssClass = "GridviewScrollC1Header";
            //tcMergePackage4.ColumnSpan = 2;
            //gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage4);

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
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.1Abstract-FinancialYearwise" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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
    protected void PrintPdf1()
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
                    Document pdfDoc = new Document(PageSize.A3, 10f, 20f, 20f, 20f);
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