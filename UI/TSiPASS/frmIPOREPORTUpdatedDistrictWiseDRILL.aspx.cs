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
using System.Text;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmIPOREPORTUpdatedDistrictWiseDRILL : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal IncipientSick, Sick, WillfulDefaulters, TEVStudyDone, Restructuringundertaken, SARFAESI, AccountClosed, IndustrialCatalogue;
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
            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new System.Web.UI.WebControls.ListItem(Y.ToString(), Y.ToString()));
            }
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
        string role = Request.QueryString["User"].ToString().Trim();
        string district = Request.QueryString["dist"].ToString().Trim();
        string month = Request.QueryString["month"].ToString().Trim();
        string year = Request.QueryString["year"].ToString().Trim();
        ddlmonth.SelectedValue = month;
        ddlYear.SelectedValue = year;
        ddlProp_intDistrictid.SelectedValue = district;
        ddlProp_intDistrictid.Enabled = false;
        lblHeading.Text = lblHeading.Text + '-' + ddlProp_intDistrictid.SelectedItem.Text + " Report";
        dsnew = GetIPOApplications(role, district, month, year);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
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
            decimal IncipientSick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Stressedassetbank"));
            IncipientSick = IncipientSick1 + IncipientSick;

            decimal Sick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BANKVISITREPORT"));
            Sick = Sick1 + Sick;

            decimal WillfulDefaulters1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VEHICLEINSPECTION"));
            WillfulDefaulters = WillfulDefaulters1 + WillfulDefaulters;

            decimal TEVStudyDone1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASS"));
            TEVStudyDone = TEVStudyDone1 + TEVStudyDone;

            decimal Restructuringundertaken1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PMEGPMUDRAREGISTRATION"));
            Restructuringundertaken = Restructuringundertaken1 + Restructuringundertaken;

            decimal SARFAESI1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidy"));
            SARFAESI = SARFAESI1 + SARFAESI;

            decimal AccountClosed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ClosedUnits"));
            AccountClosed = AccountClosed1 + AccountClosed;

            decimal IndustrialCatalogue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IndustrialCatalogue"));
            IndustrialCatalogue = IndustrialCatalogue1 + IndustrialCatalogue;


            HyperLink h1 = (HyperLink)e.Row.FindControl("hypStressedassetbank");
            h1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=Stressedassetbank";

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperBANKVISITREPORT");
            h2.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=BANKVISITREPORT";

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperVEHICLEINSPECTION");
            h3.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=VEHICLEINSPECTION";

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLinkTSIPASS");
            h4.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=TSIPASS";

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLinkPMEGPMUDRAREGISTRATION");
            h5.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=PMEGPMUDRAREGISTRATION";

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLinkAdvanceSubsidy");
            h6.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=AdvanceSubsidy";

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLinkClosedUnits");
            h7.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=ClosedUnits";

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyperLinkIndustrialCatalogue");
            h8.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DESIGNATION")).Trim() + "&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "USERID")).Trim() + "&dist=" + ddlProp_intDistrictid.SelectedValue + "&reporttype=IndustrialCatalogue";
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            //Label  = new Label();
            //IncipientSicktotal.Text = .ToString();
            //e.Row.Cells[7].Text = IncipientSick.ToString();
            //e.Row.Cells[7].Controls.Add(IncipientSicktotal);

            HyperLink IncipientSicktotal = new HyperLink();
            IncipientSicktotal.Text = IncipientSick.ToString();
            e.Row.Cells[7].Text = IncipientSick.ToString();
            e.Row.Cells[7].Controls.Add(IncipientSicktotal);
            IncipientSicktotal.ForeColor = System.Drawing.Color.White;
            IncipientSicktotal.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=Stressedassetbank";


            HyperLink Sick1 = new HyperLink();
            Sick1.Text = Sick.ToString();
            e.Row.Cells[8].Text = Sick.ToString();
            e.Row.Cells[8].Controls.Add(Sick1);
            Sick1.ForeColor = System.Drawing.Color.White;
            Sick1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=BANKVISITREPORT";

            HyperLink WillfulDefaulters1 = new HyperLink();
            WillfulDefaulters1.Text = WillfulDefaulters.ToString();
            e.Row.Cells[9].Text = WillfulDefaulters.ToString();
            e.Row.Cells[9].Controls.Add(WillfulDefaulters1);
            WillfulDefaulters1.ForeColor = System.Drawing.Color.White;
            WillfulDefaulters1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=VEHICLEINSPECTION";

            HyperLink TEVStudyDone1 = new HyperLink();
            TEVStudyDone1.Text = TEVStudyDone.ToString();
            e.Row.Cells[10].Text = TEVStudyDone.ToString();
            e.Row.Cells[10].Controls.Add(TEVStudyDone1);
            TEVStudyDone1.ForeColor = System.Drawing.Color.White;
            TEVStudyDone1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=TSIPASS";

            HyperLink Restructuringundertaken1 = new HyperLink();
            Restructuringundertaken1.Text = Restructuringundertaken.ToString();
            e.Row.Cells[11].Text = Restructuringundertaken.ToString();
            e.Row.Cells[11].Controls.Add(Restructuringundertaken1);
            Restructuringundertaken1.ForeColor = System.Drawing.Color.White;
            Restructuringundertaken1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=PMEGPMUDRAREGISTRATION";

            HyperLink SARFAESI1 = new HyperLink();
            SARFAESI1.Text = SARFAESI.ToString();
            e.Row.Cells[12].Text = SARFAESI.ToString();
            e.Row.Cells[12].Controls.Add(SARFAESI1);
            SARFAESI1.ForeColor = System.Drawing.Color.White;
            SARFAESI1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=AdvanceSubsidy";

            HyperLink AccountClosed1 = new HyperLink();
            AccountClosed1.Text = AccountClosed.ToString();
            e.Row.Cells[13].Text = AccountClosed.ToString();
            e.Row.Cells[13].Controls.Add(AccountClosed1);
            AccountClosed1.ForeColor = System.Drawing.Color.White;
            AccountClosed1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=ClosedUnits";

            HyperLink IndustrialCatalogue1 = new HyperLink();
            IndustrialCatalogue1.Text = IndustrialCatalogue.ToString();
            e.Row.Cells[14].Text = IndustrialCatalogue.ToString();
            e.Row.Cells[14].Controls.Add(IndustrialCatalogue1);
            IndustrialCatalogue1.ForeColor = System.Drawing.Color.White;
            IndustrialCatalogue1.NavigateUrl = "frmIPOREPORTUpdatedDistrictWiseDRILLDOWN.aspx?User=%&year=" + ddlYear.SelectedValue + "&month=" + ddlmonth.SelectedValue + "&userid=%" + "&dist=%" + "&reporttype=IndustrialCatalogue";

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
                    Response.AddHeader("content-disposition", "attachment;filename= Banker Report.pdf");
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
        //string status = Request.QueryString[0].ToString().Trim();
        //DataSet ds = new DataSet();
        //string input, financial, fromdate, todate;
        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, fromdate, todate);

        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        //    ds.Tables[0].Columns.Remove("DOA");
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    Label1.Text = "No Records Found ";
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
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
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetIPOApplications(string role, string districtid, string month, string year)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@ROLECODE",SqlDbType.VarChar),             
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                  new SqlParameter("@MONTH",SqlDbType.VarChar),
                     new SqlParameter("@YEAR",SqlDbType.VarChar),
               
           };
        pp[0].Value = role;
        pp[1].Value = districtid;
        pp[2].Value = month;
        pp[3].Value = year;


        Dsnew = Gen.GenericFillDs("USP_GET_IPOWISE_REPORT", pp);
        return Dsnew;
    }
}