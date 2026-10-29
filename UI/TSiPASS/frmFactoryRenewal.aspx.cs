using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;

[WebService(Namespace = "http://tempuri.org/")]

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public partial class UI_TSiPASS_frmFactoryRenewal : System.Web.UI.Page
{
    FactoryRenewalService.factoriesAutoDetails factoryrenvo = new FactoryRenewalService.factoriesAutoDetails();
    FactoryRenewalService.factoryAnnualLicenseFee factoryfee = new FactoryRenewalService.factoryAnnualLicenseFee();
    FactoryRenewalService.TSFactoryServiceImplService factoryren = new FactoryRenewalService.TSFactoryServiceImplService();
    FactoryRenewalService.factoriesAutoDetailsResponse factoryresponsevo = new FactoryRenewalService.factoriesAutoDetailsResponse();
    FactoryRenewalService.approvedCertificateDetailsResponse factoryinsertresponse = new FactoryRenewalService.approvedCertificateDetailsResponse();

    //FactoryRenewalServiceTest.factoriesAutoDetails factorytestrenvo = new FactoryRenewalServiceTest.factoriesAutoDetails();


    //RenewalsVo renvo = new RenewalsVo();
    RenewalVo renvo = new RenewalVo();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    int n1;

    static DataTable dtMyTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
                {

                    ResetFormControl(this);

                }
            }

            //DataSet ds = new DataSet();
            //ds = Gen.ViewAttachmentREN(Session["uid"].ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    FillDetails();
            //}
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityREN(Request.QueryString[0].ToString(), "9");//Session["Applid"].ToString()
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (txtfactregno.Text.Trim() == "")
        {
            txtfactregno.Enabled = true;
            txtfactregno.ReadOnly = false;
        }
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            ds = Gen.getdetailsrenewalfactorydetails(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtfactregno.Text = ds.Tables[0].Rows[0]["factoryLicenseNumber"].ToString();
                ddlcalender.SelectedItem.Text = ds.Tables[0].Rows[0]["selectedCalendarYear"].ToString().Trim();
                ddlLicenseYear.SelectedItem.Text = ds.Tables[0].Rows[0]["selectedNumberOfLicenseYears"].ToString().Trim();
                btngetdata_Click(sender, e);
                FillDetails();

            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtfactregno.Text.Trim() == "")
            {
                lblmsg0.Text = "Please enter Registration number";
                lblmsg0.ForeColor = System.Drawing.Color.Red;
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (ViewState["Factoryren"].ToString() != null)
            {
                factoryrenvo = (FactoryRenewalService.factoriesAutoDetails)(ViewState["Factoryren"]);
                //renvo.annualLicenceFee = factoryrenvo.annualLicenceFee;
                renvo.arrearsAmount = factoryrenvo.arrearsAmount;
                renvo.factoryAddress = txtfactaddress.Text.Trim();
                renvo.factoryCircleID = factoryrenvo.factoryCircleID;
                renvo.factoryCircleName = txtcircle.Text.Trim();
                renvo.factoryHP = txtfacthorsepower.Text.Trim();
                renvo.factoryLicenseNumber = txtfactlicno.Text.Trim();
                renvo.factoryName = txtfactname.Text.Trim();
                renvo.factoryNumberOfEmployees = txtempno.Text.Trim();
                renvo.factoryRegistrationNumber = txtfactregno.Text.Trim();
                renvo.interestOnAnnualLicenceFee = factoryrenvo.interestOnAnnualLicenseFee;
                renvo.interestOnArrearsAmount = txtlicfeeinterest.Text;
                renvo.arrearsAmount = txtlicfeearrears.Text;
                renvo.licenceValidFrom = factoryrenvo.licenseValidFrom;
                renvo.licenceValidUpto = factoryrenvo.licenseValidUpto;
                renvo.selectedCalendarYear = factoryrenvo.selectedCalendarYear;
                renvo.selectedNumberOfLicenseYears = factoryrenvo.selectedNumberOfLicenseYears;
                //renvo.status = factoryrenvo.status;
                renvo.totalFee = factoryrenvo.totalFee;
                renvo.questionnaire_id = Convert.ToInt32(Request.QueryString[0].ToString());
                renvo.entrepreneur_id = Session["uid"].ToString().Trim();
                renvo.Created_by = Session["uid"].ToString().Trim();
                Gen.InsertFactoryRenewal(renvo);
                lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        if (txtfactregno.Text.Trim() == "")
        {
            lblmsg0.Text = "Please enter Registration number";
            lblmsg0.ForeColor = System.Drawing.Color.Red;
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (txtfactregno.Text.Trim() == "")
        {
            lblmsg0.Text = "Please enter Registration number";
            lblmsg0.ForeColor = System.Drawing.Color.Red;
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (ViewState["Factoryren"].ToString() != null)
        {
            factoryrenvo = (FactoryRenewalService.factoriesAutoDetails)(ViewState["Factoryren"]);
            renvo.annualLicenceFee = factoryrenvo.annualLicenseFee;
            renvo.arrearsAmount = factoryrenvo.arrearsAmount;
            renvo.factoryAddress = txtfactaddress.Text.Trim();
            renvo.factoryCircleID = factoryrenvo.factoryCircleID;
            renvo.factoryCircleName = txtcircle.Text.Trim();
            renvo.factoryHP = txtfacthorsepower.Text.Trim();
            renvo.factoryLicenseNumber = txtfactlicno.Text.Trim();
            renvo.factoryName = txtfactname.Text.Trim();
            renvo.factoryNumberOfEmployees = txtempno.Text.Trim();
            renvo.factoryRegistrationNumber = txtfactregno.Text.Trim();
            renvo.interestOnAnnualLicenceFee = factoryrenvo.interestOnAnnualLicenseFee;
            renvo.interestOnArrearsAmount = txtlicfeeinterest.Text;
            renvo.arrearsAmount = txtlicfeearrears.Text;
            renvo.licenceValidFrom = factoryrenvo.licenseValidFrom;
            renvo.licenceValidUpto = factoryrenvo.licenseValidUpto;
            renvo.selectedCalendarYear = factoryrenvo.selectedCalendarYear;
            renvo.selectedNumberOfLicenseYears = factoryrenvo.selectedNumberOfLicenseYears;
            //renvo.status = factoryrenvo.status;
            renvo.totalFee = factoryrenvo.totalFee;
            renvo.questionnaire_id = Convert.ToInt32(Request.QueryString[0].ToString());
            renvo.entrepreneur_id = Session["uid"].ToString().Trim();
            renvo.Created_by = Session["uid"].ToString().Trim();
            Gen.InsertFactoryRenewal(renvo);
            lblmsg.Text = "<font color='green'>Submitted SuccessFully....!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }
        Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmFactoryRenewal.aspx");
    }
    protected void rdlicyears_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdlicyears.Checked == true)
            {
                trlicyears.Visible = true;
                trcalyr.Visible = true;
                if (rdlicarrears.Checked == true)
                {
                    rdlicarrears.Checked = false;
                    rdlicarrears.Enabled = false;
                }
            }
            else
            {
                rdlicarrears.Checked = true;
                rdlicarrears.Enabled = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btngetdata_Click(object sender, EventArgs e)
    {
        string strcalender = "";
        string strLicenseYear = "";
        try
        {
            //if (rdlicarrears.Checked == false && rdlicyears.Checked == false)
            //{
            //    Failure.Visible = true;
            //    lblmsg0.Text = "Please Select License Fees to be paid";
            //    lblmsg0.Visible = true;
            //    return;
            //}
            if (ddlcalender.SelectedValue == "--Select--")
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please Select Calender Year";
                lblmsg0.Visible = true;
                return;
            }
            if (ddlLicenseYear.SelectedValue == "--Select--")
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please Select License Years ";
                lblmsg0.Visible = true;
                return;
            }

            strcalender = ddlcalender.SelectedItem.Text.Trim();
            strLicenseYear = ddlLicenseYear.SelectedValue;


            factoryresponsevo = factoryren.isValidFactoryRegistrationNumber(txtfactregno.Text.Trim(), strcalender, strLicenseYear);//("48122", "2017", "4");

            //factorytestrenvo.
            //factoryren.isLicenseFeeAlreadyPaid(
            if (factoryresponsevo.status == "SUCCESS")
            {
                trvisibleregno.Visible = true;
                factoryrenvo = factoryresponsevo.factoriesAutoDetails[0];
                ViewState["Factoryren"] = factoryrenvo;
                txtfactname.Text = factoryrenvo.factoryName;
                txtfactaddress.Text = factoryrenvo.factoryAddress;
                txtfactlicno.Text = factoryrenvo.factoryLicenseNumber;
                txtcircle.Text = factoryrenvo.factoryCircleID;
                txtfacthorsepower.Text = factoryrenvo.factoryHP;
                txtempno.Text = factoryrenvo.factoryNumberOfEmployees;
                txtlicfeearrears.Text = factoryrenvo.arrearsAmount;
                txtlicfeeinterest.Text = factoryrenvo.interestOnArrearsAmount;
                txttotalfee.Text = factoryrenvo.totalFee;

                renvo.annualLicenceFee = factoryrenvo.annualLicenseFee;
                renvo.arrearsAmount = factoryrenvo.arrearsAmount;
                renvo.factoryAddress = factoryrenvo.factoryAddress;
                renvo.factoryCircleID = factoryrenvo.factoryCircleID;
                renvo.factoryCircleName = factoryrenvo.factoryCircleName;
                renvo.factoryHP = factoryrenvo.factoryHP;
                renvo.factoryLicenseNumber = factoryrenvo.factoryLicenseNumber;
                renvo.factoryName = factoryrenvo.factoryName;
                renvo.factoryNumberOfEmployees = factoryrenvo.factoryNumberOfEmployees;
                renvo.factoryRegistrationNumber = factoryrenvo.factoryRegistrationNumber;
                renvo.interestOnAnnualLicenceFee = factoryrenvo.interestOnAnnualLicenseFee;
                renvo.interestOnArrearsAmount = factoryrenvo.interestOnArrearsAmount;
                renvo.licenceValidFrom = factoryrenvo.licenseValidFrom;
                renvo.licenceValidUpto = factoryrenvo.licenseValidUpto;
                renvo.selectedCalendarYear = factoryrenvo.selectedCalendarYear;
                renvo.selectedNumberOfLicenseYears = factoryrenvo.selectedNumberOfLicenseYears;
                //renvo.status = factoryrenvo.status;
                renvo.totalFee = factoryrenvo.totalFee;

            }
            else
            {
                trvisibleregno.Visible = false;
            }


            //factoryrenvo.factoryAddress = "";
            //factoryrenvo.factoryCircleID = "";
            //factoryrenvo.factoryCircleName = "";
            //factoryrenvo.factoryHP = "";
            //factoryrenvo.factoryLicenseNumber = "";
            //factoryrenvo.factoryName = "";
            //factoryrenvo.factoryNumberOfEmployees = "";
            //factoryrenvo.factoryRegistrationNumber = "";
            //factoryrenvo.annualLicenceDifferenceFee2016 = "";
            //factoryrenvo.annualLicenceDifferenceFee2017 = "";
            //factoryrenvo.annualLicenceFee = "";
            //factoryrenvo.annualLicenceOldFee2016 = "";
            //factoryrenvo.annualLicenceOldFee2017 = "";
            //factoryrenvo.interestOnAnnualLicenceDifferenceFee2016 = "";
            //factoryrenvo.interestOnAnnualLicenceDifferenceFee2017 = "";
            //factoryrenvo.interestOnAnnualLicenceFee = "";
            //factoryrenvo.interestOnAnnualLicenceOldFee2016 = "";
            //factoryrenvo.interestOnAnnualLicenceOldFee2017 = "";
            //factoryrenvo.licenceValidFrom = "";
            //factoryrenvo.licenceValidUpto = "";
            //factoryrenvo.selectedCalendarYear = "";
            //factoryrenvo.selectedNumberOfLicenseYears = "";
            //factoryrenvo.status = "";
            //factoryrenvo.totalFee = "";

            //factoryrenvo.



        }
        catch (Exception ex)
        {
        }
    }

    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }

    void FillDetails()
    {
        DataSet dsdept = new DataSet();
        dsdept = Gen.getdetailsrenewalfactorydetails(Session["uid"].ToString().Trim(), Convert.ToInt32(Request.QueryString[0].ToString()));
        txtfactname.Text = dsdept.Tables[0].Rows[0]["factoryName"].ToString();
        txtfactaddress.Text = dsdept.Tables[0].Rows[0]["factoryAddress"].ToString();
        txtfactlicno.Text = dsdept.Tables[0].Rows[0]["factoryLicenseNumber"].ToString();
        txtcircle.Text = dsdept.Tables[0].Rows[0]["factoryCircleName"].ToString();
        txtfacthorsepower.Text = dsdept.Tables[0].Rows[0]["factoryHP"].ToString();
        txtempno.Text = dsdept.Tables[0].Rows[0]["factoryNumberOfEmployees"].ToString();
        txtlicfeearrears.Text = dsdept.Tables[0].Rows[0]["interestOnAnnualLicenceFee"].ToString();
        txtlicfeeinterest.Text = dsdept.Tables[0].Rows[0]["interestOnArrearsAmount"].ToString();
        txttotalfee.Text = dsdept.Tables[0].Rows[0]["totalFee"].ToString();
        ddlcalender.SelectedItem.Text = dsdept.Tables[0].Rows[0]["selectedCalendarYear"].ToString().Trim();
        ddlLicenseYear.SelectedItem.Text = dsdept.Tables[0].Rows[0]["selectedNumberOfLicenseYears"].ToString().Trim();
        trvisibleregno.Visible = true;

        factoryrenvo.factoryName = txtfactname.Text;
        factoryrenvo.factoryAddress = txtfactaddress.Text;
        factoryrenvo.factoryLicenseNumber = txtfactlicno.Text;
        factoryrenvo.factoryCircleID = txtcircle.Text;
        factoryrenvo.factoryHP = txtfacthorsepower.Text;
        factoryrenvo.factoryNumberOfEmployees = txtempno.Text;
        factoryrenvo.arrearsAmount = txtlicfeearrears.Text;
        factoryrenvo.interestOnArrearsAmount = txtlicfeeinterest.Text;
        factoryrenvo.totalFee = txttotalfee.Text;
        ViewState["Factoryren"] = factoryrenvo;
    }
}