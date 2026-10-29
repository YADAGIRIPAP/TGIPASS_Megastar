using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public partial class UI_TSiPASS_frmISMWCLRenewalForm : System.Web.UI.Page
{
    General Gen = new General();
    ismwContractorAnnualFeePaymentCheckvo labourvo = new ismwContractorAnnualFeePaymentCheckvo();
    LabourCFOService.TSLabourServiceImplService labour = new LabourCFOService.TSLabourServiceImplService();
    LabourCFOService.actISMWContractorAnnualFeePaymentResponse ismwresponse = new LabourCFOService.actISMWContractorAnnualFeePaymentResponse();

    LabourCFOService.actsResponse labourresponse = new LabourCFOService.actsResponse();
    LabourCFOService.act act = new LabourCFOService.act();
    LabourCFOService.ismwContractorAnnualFeePaymentDetails ismwlabourwebswervice = new LabourCFOService.ismwContractorAnnualFeePaymentDetails();

    // LabourServiceTest.ismwPrincipalEmployer labourmwvo = new LabourServiceTest.ismwPrincipalEmployer();



    Cls_RenewalLabourDept obj_insertretrival = new Cls_RenewalLabourDept();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string LabourActid = "";
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "133");//Session["Applid"].ToString()
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    
                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        //Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        Response.Redirect("frmapplicationForLicenceRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }
                    else
                    {
                        Response.Redirect("manfofboilerRENEWAL.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }
            if (!IsPostBack)
            {
                getdatacontracismwtlicense();
                BindDistricts(ddlShopDistrict);
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }
                
                if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
                {

                    ResetFormControl(this);

                }
            }
            

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD_Labour();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                //ddlDistrict.Items.Insert(0, "--District--");
                ddlDistrict.Items.Insert(0, new ListItem("--District--", "0"));
            }
            else
            {
                //ddlDistrict.Items.Insert(0, "--District--");
                ddlDistrict.Items.Insert(0, new ListItem("--District--", "0"));
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    void getdatacontracismwtlicense()
    {
        trvisibleregno.Visible = false;
        txtfactregno.Text = "";
        txtfactregno.Enabled = true;
        txtexistingregvaliditydate.Enabled = false;
        txtfactname.Enabled = false;
        txtfactaddress.Enabled = false;
        txtfactlicno.Enabled = false;
        txtcircle.Enabled = false;
        txtfacthorsepower.Enabled = false;
        ddlShopDistrict.Enabled = false;
        ddlShopMandal.Enabled = false;
        ddlShopVillage.Enabled = false;
        txtpincode.Enabled = false;
        txtempno.Enabled = false;

        DataSet dt_getdata = obj_insertretrival.getdetailsismwforxmlformat(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));

        try
        {
            if (dt_getdata.Tables.Count > 0)
            {
                if (dt_getdata.Tables[0].Rows.Count > 0)
                {
                    trvisibleregno.Visible = true;
                    txtfactregno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["existingLicenceNo"]);
                    txtexistingregvaliditydate.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["existing_registration_validity_date"]);
                    txtfactname.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["nature_of_activity"]);
                    txtfactaddress.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["contractorName"]);
                    txtfactlicno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["principalEmployerName"]);
                    ddlShopDistrict.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteDistrcitId"]);
                    ddlShopMandal.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteMandalId"]);
                    ddlShopVillage.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteVillageId"]);
                    txtcircle.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteDoorNo"]);
                    txtfacthorsepower.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteLocality"]);
                    ddlShopDistrict.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteDistrcitId"]);
                    ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopMandal.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteMandalId"]);
                    ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopVillage.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteVillageId"]);
                    txtpincode.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSitePincode"]);
                    txtempno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["total_employees"]);

                }
                else
                {
                    trvisibleregno.Visible = false;
                    lblmsg0.Text = "<font color='red'>Please enter Correct Registration Number!</font>";
                    success.Visible = false;
                    Failure.Visible = true;

                    txtfactregno.Text = "";
                    txtexistingregvaliditydate.Text = "";
                    txtfactname.Text = "";
                    txtfactaddress.Text = "";
                    txtfactlicno.Text = "";
                    txtcircle.Text = "";
                    txtfacthorsepower.Text = "";
                    ddlShopDistrict.SelectedIndex = 0;
                    ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopMandal.SelectedIndex = 0;
                    ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopVillage.SelectedIndex = 0;
                    txtpincode.Text = "";
                    txtempno.Text = "";

                }
            }
            else
            {
                trvisibleregno.Visible = false;
                lblmsg0.Text = "<font color='red'>Please enter Correct Registration Number!</font>";
                success.Visible = false;
                Failure.Visible = true;

                txtfactregno.Text = "";
                txtexistingregvaliditydate.Text = "";
                txtfactname.Text = "";
                txtfactaddress.Text = "";
                txtfactlicno.Text = "";
                txtcircle.Text = "";
                txtfacthorsepower.Text = "";
                ddlShopDistrict.SelectedIndex = 0;
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedIndex = 0;
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedIndex = 0;
                txtpincode.Text = "";
                txtempno.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }

    }

    protected void ddlShopDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlShopDistrict, ddlShopMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindMandals(DropDownList ddlDistrict, DropDownList ddlMandal)
    {

        ddlMandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandalsLabour(ddlDistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Mandal_Name";
            ddlMandal.DataBind();
            //ddlMandal.Items.Insert(0, "--Mandal--");
            ddlMandal.Items.Insert(0, new ListItem("--Mandal--", "0"));
        }
        else
        {
            ddlMandal.Items.Clear();
            //ddlMandal.Items.Insert(0, "--Mandal--");
            ddlMandal.Items.Insert(0, new ListItem("--Mandal--", "0"));
        }

    }
    protected void ddlShopMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlShopMandal, ddlShopVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    public void BindVillages(DropDownList ddlMandal, DropDownList ddlVillages)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillages.Items.Clear();
            //ddlVillages.Items.Insert(0, "--Village--");
            ddlVillages.Items.Insert(0, new ListItem("--Village--", "0"));
        }
        else
        {
            ddlVillages.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillagesLabour(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillages.DataSource = dsv.Tables[0];
                ddlVillages.DataValueField = "Village_Id";
                ddlVillages.DataTextField = "Village_Name";
                ddlVillages.DataBind();
                //ddlVillages.Items.Insert(0, "--Village--");
                ddlVillages.Items.Insert(0, new ListItem("--Village--", "0"));
            }
            else
            {
                ddlVillages.Items.Clear();
                // ddlVillages.Items.Insert(0, "--Village--");
                ddlVillages.Items.Insert(0, new ListItem("--Village--", "0"));
            }
        }

    }

    protected void txtfactregno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //ismwresponse = labour.ismwContractorAnnualFeePaymentCheck(txtfactregno.Text.Trim());
            ismwresponse = labour.ismwContractorAnnualFeePaymentCheck(txtfactregno.Text.Trim());
            trvisibleregno.Visible = false;
            if (ismwresponse.status == "SUCCESS")
            {
                //int count = ismwresponse.ismwContractorAnnualFeeDetails.Length;
                int count = ismwresponse.ismwContractorAnnualFeeDetails.Length;
                //ismwContractorAnnualFeeDetails.Length;
                try
                {
                    trvisibleregno.Visible = true;
                    for (int i = 0; i < count; i++)
                    {
                        ismwlabourwebswervice = ismwresponse.ismwContractorAnnualFeeDetails[i];
                        labourvo.ISMWID = "";
                        labourvo.actID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.actID)) && Convert.ToString(ismwlabourwebswervice.actID) != "null")
                            labourvo.act = ismwlabourwebswervice.actID;
                        labourvo.actID = ismwlabourwebswervice.actID;


                        labourvo.amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_amount_payable)) && Convert.ToString(ismwlabourwebswervice.total_amount_payable) != "null")
                            labourvo.amount = Convert.ToString(ismwlabourwebswervice.total_amount_payable);
                        labourvo.application_code = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.existingLicenceNo)) && Convert.ToString(ismwlabourwebswervice.existingLicenceNo) != "null")
                            labourvo.application_code = ismwlabourwebswervice.existingLicenceNo;
                        labourvo.bank_code = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.bank_code)) && Convert.ToString(ismwlabourwebswervice.bank_code) != "null")
                            labourvo.bank_code = ismwlabourwebswervice.bank_code;
                        labourvo.bank_ref_number = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.bank_ref_number)) && Convert.ToString(ismwlabourwebswervice.bank_ref_number) != "null")
                        //labourvo.bank_ref_number = ismwlabourwebswervice.bank_ref_number;
                        labourvo.bankName = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.bankName)) && Convert.ToString(ismwlabourwebswervice.bankName) != "null")
                        //labourvo.bankName = ismwlabourwebswervice.bankName;
                        labourvo.cin = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.cin)) && Convert.ToString(ismwlabourwebswervice.cin) != "null")
                        //labourvo.cin = ismwlabourwebswervice.cin;
                        labourvo.compound_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.compound_fee)) && Convert.ToString(ismwlabourwebswervice.compound_fee) != "null")
                            labourvo.compound_fee = Convert.ToString(ismwlabourwebswervice.compound_fee);
                        labourvo.contractor_mobile = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.contractor_mobile)) && Convert.ToString(ismwlabourwebswervice.contractor_mobile) != "null")
                        //labourvo.contractor_mobile = ismwlabourwebswervice.contractor_mobile;
                        labourvo.contractor_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.contractorName)) && Convert.ToString(ismwlabourwebswervice.contractorName) != "null")
                            labourvo.contractor_name = ismwlabourwebswervice.contractorName;
                        labourvo.contractorName = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.contractorName)) && Convert.ToString(ismwlabourwebswervice.contractorName) != "null")
                            labourvo.contractorName = ismwlabourwebswervice.contractorName;
                        labourvo.district_establishment = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteDistrcitId)) && Convert.ToString(ismwlabourwebswervice.workSiteDistrcitId) != "null")
                            labourvo.district_establishment = ismwlabourwebswervice.workSiteDistrcitId;
                        labourvo.door_no_establishment = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteDoorNo)) && Convert.ToString(ismwlabourwebswervice.workSiteDoorNo) != "null")
                            labourvo.door_no_establishment = ismwlabourwebswervice.workSiteDoorNo;

                        labourvo.entrepreneur_id = Session["uid"].ToString().Trim();
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.entrepreneur_id)) && Convert.ToString(ismwlabourwebswervice.entrepreneur_id) != "null")
                        //labourvo.entrepreneur_id = ismwlabourwebswervice.entrepreneur_id;

                        labourvo.existing_licence_no = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.existingLicenceNo)) && Convert.ToString(ismwlabourwebswervice.existingLicenceNo) != "null")
                            labourvo.existing_licence_no = ismwlabourwebswervice.existingLicenceNo;
                        labourvo.existing_registration_validity_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.existing_registration_validity_date)) && Convert.ToString(ismwlabourwebswervice.existing_registration_validity_date) != "null")
                            labourvo.existing_registration_validity_date = ismwlabourwebswervice.existing_registration_validity_date;
                        labourvo.existingLicenceNo = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.existingLicenceNo)) && Convert.ToString(ismwlabourwebswervice.existingLicenceNo) != "null")
                            labourvo.existingLicenceNo = ismwlabourwebswervice.existingLicenceNo;
                        labourvo.licence_expiry_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.existing_registration_validity_date)) && Convert.ToString(ismwlabourwebswervice.existing_registration_validity_date) != "null")
                            labourvo.licence_expiry_date = ismwlabourwebswervice.existing_registration_validity_date;
                        labourvo.locality_establishment = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteLocality)) && Convert.ToString(ismwlabourwebswervice.workSiteLocality) != "null")
                            labourvo.locality_establishment = ismwlabourwebswervice.workSiteLocality;
                        labourvo.mandal_establishment = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteMandalId)) && Convert.ToString(ismwlabourwebswervice.workSiteMandalId) != "null")
                            labourvo.mandal_establishment = ismwlabourwebswervice.workSiteMandalId;
                        labourvo.max_contract_labour = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_employees)) && Convert.ToString(ismwlabourwebswervice.total_employees) != "null")
                            labourvo.max_contract_labour = ismwlabourwebswervice.total_employees;
                        labourvo.name_pe = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.principalEmployerName)) && Convert.ToString(ismwlabourwebswervice.principalEmployerName) != "null")
                            labourvo.name_pe = ismwlabourwebswervice.principalEmployerName;
                        labourvo.nature_of_activity = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.nature_of_activity)) && Convert.ToString(ismwlabourwebswervice.nature_of_activity) != "null")
                            labourvo.nature_of_activity = ismwlabourwebswervice.nature_of_activity;
                        labourvo.nature_of_work = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.nature_of_activity)) && Convert.ToString(ismwlabourwebswervice.nature_of_activity) != "null")
                            labourvo.nature_of_work = ismwlabourwebswervice.nature_of_activity;
                        labourvo.nature_work = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.nature_of_activity)) && Convert.ToString(ismwlabourwebswervice.nature_of_activity) != "null")
                            labourvo.nature_work = ismwlabourwebswervice.nature_of_activity;
                        labourvo.payment_mode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.payment_mode)) && Convert.ToString(ismwlabourwebswervice.payment_mode) != "null")
                            labourvo.payment_mode = ismwlabourwebswervice.payment_mode;

                        labourvo.paymentFlag = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.paymentFlag)) && Convert.ToString(ismwlabourwebswervice.paymentFlag) != "null")
                        //labourvo.paymentFlag = ismwlabourwebswervice.paymentFlag;

                        labourvo.penality_percentage = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.penality_percentage)) && Convert.ToString(ismwlabourwebswervice.penality_percentage) != "null")
                            labourvo.penality_percentage = Convert.ToString(ismwlabourwebswervice.penality_percentage);
                        labourvo.penality_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.penality_years)) && Convert.ToString(ismwlabourwebswervice.penality_years) != "null")
                            labourvo.penality_years = Convert.ToString(ismwlabourwebswervice.penality_years);



                        labourvo.principalEmployerName = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.principalEmployerName)) && Convert.ToString(ismwlabourwebswervice.principalEmployerName) != "null")
                            labourvo.principalEmployerName = ismwlabourwebswervice.principalEmployerName;

                        labourvo.projectSubmitDate = "";
                        //               if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.projectSubmitDate)) && Convert.ToString(ismwlabourwebswervice.projectSubmitDate) != "null")
                        //labourvo.projectSubmitDate = ismwlabourwebswervice.projectSubmitDate;

                        labourvo.questionnaire_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["Applid"])) && Convert.ToString(Session["Applid"]) != "null")
                            labourvo.questionnaire_id = Convert.ToString(Session["Applid"]);
                        labourvo.registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.registration_fee)) && Convert.ToString(ismwlabourwebswervice.registration_fee) != "null")
                            labourvo.registration_fee = Convert.ToString(ismwlabourwebswervice.registration_fee);
                        labourvo.registration_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.registration_years)) && Convert.ToString(ismwlabourwebswervice.registration_years) != "null")
                            labourvo.registration_years = Convert.ToString(ismwlabourwebswervice.registration_years);

                        labourvo.stageID = "";
                        //                if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.stageID)) && Convert.ToString(ismwlabourwebswervice.stageID) != "null")
                        //labourvo.stageID = ismwlabourwebswervice.stageID;

                        labourvo.total_amount_payable = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_amount_payable)) && Convert.ToString(ismwlabourwebswervice.total_amount_payable) != "null")
                            labourvo.total_amount_payable = Convert.ToString(ismwlabourwebswervice.total_amount_payable);
                        labourvo.total_employees = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_employees)) && Convert.ToString(ismwlabourwebswervice.total_employees) != "null")
                            labourvo.total_employees = ismwlabourwebswervice.total_employees;
                        labourvo.total_penality_amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_penality_amount)) && Convert.ToString(ismwlabourwebswervice.total_penality_amount) != "null")
                            labourvo.total_penality_amount = Convert.ToString(ismwlabourwebswervice.total_penality_amount);

                        labourvo.total_registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.total_registration_fee)) && Convert.ToString(ismwlabourwebswervice.total_registration_fee) != "null")
                            labourvo.total_registration_fee = Convert.ToString(ismwlabourwebswervice.total_registration_fee);

                        labourvo.totalAmount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.totalAmount)) && Convert.ToString(ismwlabourwebswervice.totalAmount) != "null")
                            labourvo.totalAmount = ismwlabourwebswervice.totalAmount;

                        labourvo.transaction_for = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.transaction_for)) && Convert.ToString(ismwlabourwebswervice.transaction_for) != "null")
                        //    labourvo.transaction_for = ismwlabourwebswervice.transaction_for;

                        labourvo.transaction_id = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.transaction_id)) && Convert.ToString(ismwlabourwebswervice.transaction_id) != "null")
                        //    labourvo.transaction_id = ismwlabourwebswervice.transaction_id;

                        labourvo.transaction_status = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.transaction_status)) && Convert.ToString(ismwlabourwebswervice.transaction_status) != "null")
                        //    labourvo.transaction_status = ismwlabourwebswervice.transaction_status;

                        labourvo.transactionDate = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.transactionDate)) && Convert.ToString(ismwlabourwebswervice.transactionDate) != "null")
                        //    labourvo.transactionDate = ismwlabourwebswervice.transactionDate;

                        labourvo.transactionNumber = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.transactionNumber)) && Convert.ToString(ismwlabourwebswervice.transactionNumber) != "null")
                        //    labourvo.transactionNumber = ismwlabourwebswervice.transactionNumber;

                        labourvo.tsipassApplicationID = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.tsipassApplicationID)) && Convert.ToString(ismwlabourwebswervice.tsipassApplicationID) != "null")
                        //    labourvo.tsipassApplicationID = ismwlabourwebswervice.tsipassApplicationID;

                        labourvo.type_of_application = "Renwal";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.type_of_application)) && Convert.ToString(ismwlabourwebswervice.type_of_application) != "null")
                        //labourvo.type_of_application = ismwlabourwebswervice.type_of_application;

                        labourvo.uID = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.uID)) && Convert.ToString(ismwlabourwebswervice.uID) != "null")
                        //    labourvo.uID = ismwlabourwebswervice.uID;

                        labourvo.user_serial_no = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.user_serial_no)) && Convert.ToString(ismwlabourwebswervice.user_serial_no) != "null")
                            labourvo.user_serial_no = ismwlabourwebswervice.user_serial_no;

                        labourvo.valid_from_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.valid_from_date)) && Convert.ToString(ismwlabourwebswervice.valid_from_date) != "null")
                            labourvo.valid_from_date = ismwlabourwebswervice.valid_from_date;

                        labourvo.valid_to_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.valid_to_date)) && Convert.ToString(ismwlabourwebswervice.valid_to_date) != "null")
                            labourvo.valid_to_date = ismwlabourwebswervice.valid_to_date;

                        labourvo.village_establishment = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteVillageId)) && Convert.ToString(ismwlabourwebswervice.workSiteVillageId) != "null")
                            labourvo.village_establishment = ismwlabourwebswervice.workSiteVillageId;

                        labourvo.workSiteDistrcitId = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteDistrcitId)) && Convert.ToString(ismwlabourwebswervice.workSiteDistrcitId) != "null")
                            labourvo.workSiteDistrcitId = ismwlabourwebswervice.workSiteDistrcitId;

                        labourvo.workSiteDoorNo = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteDoorNo)) && Convert.ToString(ismwlabourwebswervice.workSiteDoorNo) != "null")
                            labourvo.workSiteDoorNo = ismwlabourwebswervice.workSiteDoorNo;

                        labourvo.workSiteLocality = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteLocality)) && Convert.ToString(ismwlabourwebswervice.workSiteLocality) != "null")
                            labourvo.workSiteLocality = ismwlabourwebswervice.workSiteLocality;

                        labourvo.workSiteMandalId = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteMandalId)) && Convert.ToString(ismwlabourwebswervice.workSiteMandalId) != "null")
                            labourvo.workSiteMandalId = ismwlabourwebswervice.workSiteMandalId;

                        labourvo.pincode_establishment = "";
                        labourvo.workSitePincode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSitePincode)) && Convert.ToString(ismwlabourwebswervice.workSitePincode) != "null")
                            labourvo.workSitePincode = ismwlabourwebswervice.workSitePincode;
                        labourvo.pincode_establishment = ismwlabourwebswervice.workSitePincode;


                        labourvo.workSiteVillageId = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(ismwlabourwebswervice.workSiteVillageId)) && Convert.ToString(ismwlabourwebswervice.workSiteVillageId) != "null")
                            labourvo.workSiteVillageId = ismwlabourwebswervice.workSiteVillageId;
                        labourvo.CreatedBy = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(Session["uid"])) && Convert.ToString(Session["uid"]) != "null")
                            labourvo.CreatedBy = Session["uid"].ToString().Trim();
                        labourvo.CreatedIP = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(Request.ServerVariables["Remote_Addr"])) && Convert.ToString(Request.ServerVariables["Remote_Addr"]) != "null")
                            labourvo.CreatedIP = Request.ServerVariables["Remote_Addr"];

                        obj_insertretrival.insertupdateiSMWrenewalannualfee(labourvo);

                        trvisibleregno.Visible = true;
                        txtexistingregvaliditydate.Text = ismwlabourwebswervice.existing_registration_validity_date;
                        txtfactname.Text = ismwlabourwebswervice.nature_of_activity;
                        txtfactaddress.Text = ismwlabourwebswervice.contractorName;
                        txtfactlicno.Text = ismwlabourwebswervice.principalEmployerName;
                        //principal_employer_name;
                        txtcircle.Text = ismwlabourwebswervice.workSiteDoorNo;
                        txtfacthorsepower.Text = ismwlabourwebswervice.workSiteLocality;
                        ddlShopDistrict.SelectedValue = ismwlabourwebswervice.workSiteDistrcitId;
                        ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopMandal.SelectedValue = ismwlabourwebswervice.workSiteMandalId;
                        ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopVillage.SelectedValue = ismwlabourwebswervice.workSiteVillageId;
                        txtpincode.Text = ismwlabourwebswervice.workSitePincode;
                        txtempno.Text = ismwlabourwebswervice.total_employees;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                trvisibleregno.Visible = false;
                lblmsg0.Text = "<font color='red'>Please enter Correct Registration Number!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtexistingregvaliditydate.Text = "";
                txtfactname.Text = "";
                txtfactaddress.Text = "";
                txtfactlicno.Text = "";
                txtcircle.Text = "";
                txtfacthorsepower.Text = "";
                ddlShopDistrict.SelectedIndex = 0;
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedIndex = 0;
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedIndex = 0;
                txtpincode.Text = "";
                txtempno.Text = "";
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCinematographLicenseRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim() + "&next=" + "N");
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmISMWCLRenewalForm.aspx");
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {


            DataSet dt_getdata = obj_insertretrival.getdetailsrenewalcontractlabourinxmlformat(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));
            string jh = Convert.ToString(dt_getdata.Tables[0].Rows[0]["actID"]);

            if (dt_getdata.Tables.Count > 0)
            {
                if (dt_getdata.Tables[0].Rows.Count > 0)
                {


                    //act.ismwContractorAnnualFeePaymentActSelected = true;

                    //labourmwvo.actID = Convert.ToString(dt_getdata.Tables[0].Rows[0]["actID"]);
                    //labourmwvo.bankName = Convert.ToString(dt_getdata.Tables[0].Rows[0]["bankName"]);
                    //labourmwvo.bank_code = Convert.ToString(dt_getdata.Tables[0].Rows[0]["bank_code"]);
                    //labourmwvo.bank_ref_number = Convert.ToString(dt_getdata.Tables[0].Rows[0]["bank_ref_number"]);
                    //labourmwvo.cin = Convert.ToString(dt_getdata.Tables[0].Rows[0]["cin"]);
                    //labourmwvo.compound_fee = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["compound_fee"]);
                    //labourmwvo.contractorName = Convert.ToString(dt_getdata.Tables[0].Rows[0]["contractorName"]);
                    //labourmwvo.contractor_mobile = Convert.ToString(dt_getdata.Tables[0].Rows[0]["contractor_mobile"]);
                    //labourmwvo.entrepreneur_id = Convert.ToString(dt_getdata.Tables[0].Rows[0]["entrepreneur_id"]);
                    //labourmwvo.existingLicenceNo = Convert.ToString(dt_getdata.Tables[0].Rows[0]["existingLicenceNo"]);
                    //labourmwvo.existing_registration_validity_date = Convert.ToString(dt_getdata.Tables[0].Rows[0]["existing_registration_validity_date"]);
                    //labourmwvo.nature_of_activity = Convert.ToString(dt_getdata.Tables[0].Rows[0]["nature_of_activity"]);
                    //labourmwvo.nature_work = Convert.ToString(dt_getdata.Tables[0].Rows[0]["nature_work"]);
                    //labourmwvo.paymentFlag = Convert.ToString(dt_getdata.Tables[0].Rows[0]["paymentFlag"]);
                    //labourmwvo.payment_mode = Convert.ToString(dt_getdata.Tables[0].Rows[0]["payment_mode"]);
                    //labourmwvo.penality_percentage = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["penality_percentage"]);
                    //labourmwvo.penality_years = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["penality_years"]);
                    //labourmwvo.principalEmployerName = Convert.ToString(dt_getdata.Tables[0].Rows[0]["principalEmployerName"]);
                    //labourmwvo.projectSubmitDate = Convert.ToString(dt_getdata.Tables[0].Rows[0]["projectSubmitDate"]);
                    //labourmwvo.questionnaire_id = Convert.ToString(dt_getdata.Tables[0].Rows[0]["questionnaire_id"]);
                    //labourmwvo.registration_fee = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["registration_fee"]);
                    //labourmwvo.registration_years = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["registration_years"]);
                    //labourmwvo.stageID = Convert.ToString(dt_getdata.Tables[0].Rows[0]["stageID"]);
                    //labourmwvo.totalAmount = Convert.ToString(dt_getdata.Tables[0].Rows[0]["totalAmount"]);
                    //labourmwvo.total_amount_payable = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["total_amount_payable"]);
                    //labourmwvo.total_employees = Convert.ToString(dt_getdata.Tables[0].Rows[0]["total_employees"]);
                    //labourmwvo.total_penality_amount = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["total_penality_amount"]);
                    //labourmwvo.total_registration_fee = Convert.ToInt32(dt_getdata.Tables[0].Rows[0]["total_registration_fee"]);
                    //labourmwvo.transactionDate = Convert.ToString(dt_getdata.Tables[0].Rows[0]["transactionDate"]);
                    //labourmwvo.transactionNumber = Convert.ToString(dt_getdata.Tables[0].Rows[0]["transactionNumber"]);
                    //labourmwvo.transaction_for = Convert.ToString(dt_getdata.Tables[0].Rows[0]["transaction_for"]);
                    //labourmwvo.transaction_id = Convert.ToString(dt_getdata.Tables[0].Rows[0]["transaction_id"]);
                    //labourmwvo.transaction_status = Convert.ToString(dt_getdata.Tables[0].Rows[0]["transaction_status "]);
                    //labourmwvo.tsipassApplicationID = Convert.ToString(dt_getdata.Tables[0].Rows[0]["tsipassApplicationID "]);
                    //labourmwvo.type_of_application = Convert.ToString(dt_getdata.Tables[0].Rows[0]["type_of_application "]);
                    //labourmwvo.user_serial_no = Convert.ToString(dt_getdata.Tables[0].Rows[0]["user_serial_no"]);
                    //labourmwvo.valid_from_date = Convert.ToString(dt_getdata.Tables[0].Rows[0]["valid_from_date"]);
                    //labourmwvo.valid_to_date = Convert.ToString(dt_getdata.Tables[0].Rows[0]["valid_to_date"]);
                    //labourmwvo.workSiteDistrcitId = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteDistrcitId"]);
                    //labourmwvo.workSiteDoorNo = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteDoorNo "]);
                    //labourmwvo.workSiteLocality = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteLocality"]);
                    //labourmwvo.workSiteMandalId = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteMandalId"]);
                    //labourmwvo.workSitePincode = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSitePincode "]);
                    //labourmwvo.workSiteVillageId = Convert.ToString(dt_getdata.Tables[0].Rows[0]["workSiteVillageId "]);
                    //labourmwvo.uID = Convert.ToString(dt_getdata.Tables[0].Rows[0]["uID"]);

                    //act.ismwcontractorAFPData = ismwlabourwebswervice;
                    //act.ismwContractorAnnualFeePaymentActSelected = true;
                    //labourresponse = labour.actSelected(act);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

}