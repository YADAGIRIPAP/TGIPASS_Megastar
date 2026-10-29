using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmdistrictreportindustrystatusCFO : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal COMMENCEDOPERATIONS, YETTOSTARTCONSTRUCTION, ADVANCEDSTAGE, INITIALSTAGE, TOTUNITS, TotalEmployeement, TotalInvestment;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-03-2020";
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
            BindFinancialYears(ddlFinancialYear);
            fillgrid();
        }
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

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
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
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetDistrictWisePollutionCategory(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue, ddlFinancialYear.SelectedValue);

        if (dsnew.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = dsnew.Tables[0];
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


            decimal COMMENCEDOPERATIONS1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "COMMENCEDOPERATIONS"));
            COMMENCEDOPERATIONS = COMMENCEDOPERATIONS1 + COMMENCEDOPERATIONS;

            decimal YETTOSTARTCONSTRUCTION1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "YETTOSTARTCONSTRUCTION"));
            YETTOSTARTCONSTRUCTION = YETTOSTARTCONSTRUCTION1 + YETTOSTARTCONSTRUCTION;

            decimal ADVANCEDSTAGE1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ADVANCEDSTAGE"));
            ADVANCEDSTAGE = ADVANCEDSTAGE1 + ADVANCEDSTAGE;

            decimal INITIALSTAGE1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "INITIALSTAGE"));
            INITIALSTAGE = INITIALSTAGE1 + INITIALSTAGE;


            decimal TOTUNITS1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTALUNITS"));
            TOTUNITS = TOTUNITS1 + TOTUNITS;

            decimal TotalEmployeement1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalEmployeement"));
            TotalEmployeement = TotalEmployeement1 + TotalEmployeement;

            decimal TotalInvestment1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InvestmentCr"));
            TotalInvestment = TotalInvestment1 + TotalInvestment;


            string district = DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME").ToString();


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "COMMENCED OPERATIONS" + "&district=" + district;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "YET TO START CONSTRUCTION" + " &district=" + district;
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "ADVANCED STAGE" + "&district=" + district;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "INITIAL STAGE" + "&district=" + district;
            }

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTUNITS" + "&district=" + district;
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTUNITS" + "&district=" + district;
            }

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmDistrictReportIndustryStatusDrillDownCFO.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&polcategory=" + "TOTUNITS" + "&district=" + district;
            }





        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = COMMENCEDOPERATIONS.ToString();
            e.Row.Cells[3].Text = YETTOSTARTCONSTRUCTION.ToString();
            e.Row.Cells[4].Text = ADVANCEDSTAGE.ToString();
            e.Row.Cells[5].Text = INITIALSTAGE.ToString();
            e.Row.Cells[6].Text = TOTUNITS.ToString();
            e.Row.Cells[7].Text = TotalEmployeement.ToString();
            e.Row.Cells[8].Text = TotalInvestment.ToString();



        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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

                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= IndustryStatusReport.pdf");
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

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

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

        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetDistrictWisePollutionCategory(string fromdate, string todate, string districtid, string financialcd)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
               new SqlParameter("@FinancialYearCd",SqlDbType.VarChar),

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;
        pp[3].Value = financialcd;

        //Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_INDUSTRYSTATUS", pp);
        Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_INDUSTRYSTATUS_CFO", pp);
        return Dsnew;
    }

    public void BindFinancialYears(DropDownList ddlFinYear)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = Gen.GetFinancialYearsForReports();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlFinYear.DataSource = dsd.Tables[0];
                ddlFinYear.DataValueField = "SlNo";
                ddlFinYear.DataTextField = "FinancialYear";
                ddlFinYear.DataBind();

            }


            ddlFinYear.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {


        }
    }
}