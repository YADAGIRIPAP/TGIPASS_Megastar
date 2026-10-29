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
public partial class UI_TSiPASS_frmapplicationForLicenceRenewal : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();


    contractLicenceActRenewalCheckVo labourvo = new contractLicenceActRenewalCheckVo();
    LabourCFOService.TSLabourServiceImplService labour = new LabourCFOService.TSLabourServiceImplService();
    LabourCFOService.contractLicenceRenewalDetails contLicRenDetails = new LabourCFOService.contractLicenceRenewalDetails();
    LabourCFOService.actsResponse labourresponse = new LabourCFOService.actsResponse();
    LabourCFOService.act act = new LabourCFOService.act();
    LabourCFOService.contractLicenceContractorRenewals contractlabourwebswervice = new LabourCFOService.contractLicenceContractorRenewals();

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
                dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "132");//Session["Applid"].ToString()
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        Response.Redirect("frmCinematographLicenseRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        //Response.Redirect("frmCinematographLicenseRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim());
                    }
                    else
                    {
                        Response.Redirect("frmISMWCLRenewalForm.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }

            if (!IsPostBack)
            {
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
                getdatacontractlicense();
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
                // ddlDistrict.Items.Insert(0, "--District--");
                ddlDistrict.Items.Insert(0, new ListItem("--District--", "0"));
            }
            else
            {
                // ddlDistrict.Items.Insert(0, "--District--");
                ddlDistrict.Items.Insert(0, new ListItem("--District--", "0"));
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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
        string jh = ddlDistrict.SelectedValue;
        dsm = Gen.GetMandalsLabour(ddlDistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Mandal_Name";
            ddlMandal.DataBind();
            // ddlMandal.Items.Insert(0, "--Mandal--");
            ddlMandal.Items.Insert(0, new ListItem("--Mandal--", "0"));
        }
        else
        {
            ddlMandal.Items.Clear();
            //  ddlMandal.Items.Insert(0, "--Mandal--");
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
                // ddlVillages.Items.Insert(0, "--Village--");
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
        trvisibleregno.Visible = false;
        try
        {
            labourresponse = labour.contractLicenceActRenewalCheck(txtfactregno.Text.Trim());

            if (labourresponse.status == "SUCCESS")
            {
                trvisibleregno.Visible = true;
                int count = labourresponse.contractLicenceRenewalDetails.Length;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        contLicRenDetails = labourresponse.contractLicenceRenewalDetails[i];
                        labourvo.act = Convert.ToString(contLicRenDetails.actID);
                        //  labourvo.name_pe = Convert.ToString(contLicRenDetails.name_pe;
                        labourvo.max_contract_labour = Convert.ToString(contLicRenDetails.max_employees_aday);
                        labourvo.application_code = Convert.ToString(contLicRenDetails.previous_registration_no);
                        labourvo.contractor_name = Convert.ToString(contLicRenDetails.establishment_name);
                        labourvo.licence_num = Convert.ToString(contLicRenDetails.previous_registration_no);
                        labourvo.expiry_date = Convert.ToString(contLicRenDetails.previous_certificate_valid_to);

                        //labourvo.expiry_date = DateTime.Now;
                        labourvo.worksiteDoorNo = Convert.ToString(contLicRenDetails.establishment_postal_door);
                        labourvo.worksiteLocality = Convert.ToString(contLicRenDetails.establishment_postal_locality);
                        labourvo.worksiteDistrict = Convert.ToString(contLicRenDetails.establishment_postal_district);
                        labourvo.worksiteMandal = Convert.ToString(contLicRenDetails.establishment_postal_mandal);
                        labourvo.worksiteVillage = Convert.ToString(contLicRenDetails.establishment_postal_village);
                        labourvo.worksitePinNo = Convert.ToString(contLicRenDetails.establishment_postal_pincode);
                        labourvo.nature_of_work = Convert.ToString(contLicRenDetails.nature_work);

                        labourvo.user_serial_no = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.uID)) && Convert.ToString(contLicRenDetails.uID) != "null" && Convert.ToString(contLicRenDetails.uID)!="")

                        if (contLicRenDetails.uID != null && contLicRenDetails.uID != "0")
                        {
                            labourvo.user_serial_no = Convert.ToString(contLicRenDetails.uID);
                        }

                        labourvo.payment_mode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.payment_mode)) && Convert.ToString(contLicRenDetails.payment_mode) != "null")
                        {
                            labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);
                        }

                        //
                        //if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.payment_mode)) && Convert.ToString(contLicRenDetails.payment_mode) != "null")
                        //  {
                        //    labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);
                        //}
                        labourvo.amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.totalAmount)) && Convert.ToString(contLicRenDetails.totalAmount) != "null")
                        {
                            labourvo.amount = Convert.ToString(contLicRenDetails.totalAmount);
                        }
                        //  labourvo.bank_code = "";
                        //  if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_code) && Convert.ToString(contLicRenDetails.bank_code != "null")
                        //  {
                        //      labourvo.bank_code = Convert.ToString(contLicRenDetails.bank_code;
                        //  }

                        labourvo.actID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.actID)) && Convert.ToString(contLicRenDetails.actID) == "null")
                        {
                            labourvo.actID = Convert.ToString(contLicRenDetails.actID);
                        }

                        // labourvo.actID = Convert.ToString(contLicRenDetails.actID;
                        labourvo.bank_code = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_code)) && Convert.ToString(contLicRenDetails.bank_code) != "null")
                            labourvo.bank_code = Convert.ToString(contLicRenDetails.bank_code);

                        labourvo.bank_ref_number = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_ref_number)) && Convert.ToString(contLicRenDetails.bank_ref_number) != "null")
                            labourvo.bank_ref_number = Convert.ToString(contLicRenDetails.bank_ref_number);

                        labourvo.bankName = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bankName)) && Convert.ToString(contLicRenDetails.bankName) != "null")
                            labourvo.bankName = Convert.ToString(contLicRenDetails.bankName);

                        labourvo.cin = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.cin)) && Convert.ToString(contLicRenDetails.cin) != "null")
                            labourvo.cin = Convert.ToString(contLicRenDetails.cin);

                        labourvo.compound_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.compound_fee)) && Convert.ToString(contLicRenDetails.compound_fee) != "null")
                            labourvo.compound_fee = Convert.ToString(contLicRenDetails.compound_fee);

                        labourvo.contractor_email = "kondam_manjusha@cms.co.in";

                        labourvo.contractor_mobile = "7337435977";

                        labourvo.entrepreneur_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.entrepreneur_id)) && Convert.ToString(contLicRenDetails.entrepreneur_id) != "null")
                            labourvo.entrepreneur_id = Convert.ToString(contLicRenDetails.entrepreneur_id);

                        labourvo.establishment_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_name)) && Convert.ToString(contLicRenDetails.establishment_name) != "null")
                            labourvo.establishment_name = Convert.ToString(contLicRenDetails.establishment_name);

                        labourvo.establishment_otherstate_address = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_otherstate_address)) && Convert.ToString(contLicRenDetails.establishment_otherstate_address) != "null")
                            labourvo.establishment_otherstate_address = Convert.ToString(contLicRenDetails.establishment_otherstate_address);

                        labourvo.establishment_postal_district = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_district)) && Convert.ToString(contLicRenDetails.establishment_postal_district) != "null")
                            labourvo.establishment_postal_district = Convert.ToString(contLicRenDetails.establishment_postal_district);

                        labourvo.establishment_postal_door = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_door)) && Convert.ToString(contLicRenDetails.establishment_postal_door) != "null")
                            labourvo.establishment_postal_door = Convert.ToString(contLicRenDetails.establishment_postal_door);

                        labourvo.establishment_postal_locality = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_locality)) && Convert.ToString(contLicRenDetails.establishment_postal_locality) != "null")
                            labourvo.establishment_postal_locality = Convert.ToString(contLicRenDetails.establishment_postal_locality);

                        labourvo.establishment_postal_mandal = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_mandal)) && Convert.ToString(contLicRenDetails.establishment_postal_mandal) != "null")
                            labourvo.establishment_postal_mandal = Convert.ToString(contLicRenDetails.establishment_postal_mandal);

                        labourvo.establishment_postal_pincode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_pincode)) && Convert.ToString(contLicRenDetails.establishment_postal_pincode) != "null")
                            labourvo.establishment_postal_pincode = Convert.ToString(contLicRenDetails.establishment_postal_pincode);

                        labourvo.establishment_postal_village = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_village)) && Convert.ToString(contLicRenDetails.establishment_postal_village) != "null")
                            labourvo.establishment_postal_village = Convert.ToString(contLicRenDetails.establishment_postal_village);

                        labourvo.max_employees_aday = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.max_employees_aday)) && Convert.ToString(contLicRenDetails.max_employees_aday) != "null")
                            labourvo.max_employees_aday = Convert.ToString(contLicRenDetails.max_employees_aday);

                        labourvo.nature_work = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.nature_work)) && Convert.ToString(contLicRenDetails.nature_work) != "null")
                            labourvo.nature_work = Convert.ToString(contLicRenDetails.nature_work);
                        // labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);

                        labourvo.paymentFlag = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.paymentFlag)) && Convert.ToString(contLicRenDetails.paymentFlag) != "null")
                            labourvo.paymentFlag = Convert.ToString(contLicRenDetails.paymentFlag);

                        labourvo.penality_percentage = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.penality_percentage)) && Convert.ToString(contLicRenDetails.penality_percentage) != "null")
                            labourvo.penality_percentage = Convert.ToString(contLicRenDetails.penality_percentage);

                        labourvo.penality_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.penality_years)) && Convert.ToString(contLicRenDetails.penality_years) != "null")
                            labourvo.penality_years = Convert.ToString(contLicRenDetails.penality_years);

                        labourvo.previous_registration_no = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registration_no)) && Convert.ToString(contLicRenDetails.previous_registration_no) != "null")
                            labourvo.previous_registration_no = Convert.ToString(contLicRenDetails.previous_registration_no);

                        labourvo.principal_employer_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.name_pe)) && Convert.ToString(contLicRenDetails.name_pe) != "null")
                            labourvo.principal_employer_name = Convert.ToString(contLicRenDetails.name_pe);

                        labourvo.projectSubmitDate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.projectSubmitDate)) && Convert.ToString(contLicRenDetails.projectSubmitDate) != "null")
                            labourvo.projectSubmitDate = Convert.ToString(contLicRenDetails.projectSubmitDate);

                        labourvo.questionnaire_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.questionnaire_id)) && Convert.ToString(contLicRenDetails.questionnaire_id) != "null")
                            labourvo.questionnaire_id = Convert.ToString(contLicRenDetails.questionnaire_id);

                        labourvo.registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.registration_fee)) && Convert.ToString(contLicRenDetails.registration_fee) != "null")
                            labourvo.registration_fee = Convert.ToString(contLicRenDetails.registration_fee);

                        labourvo.registration_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.registration_years)) && Convert.ToString(contLicRenDetails.registration_years) != "null")
                            labourvo.registration_years = Convert.ToString(contLicRenDetails.registration_years);

                        labourvo.renewalCaseType = "R";

                        labourvo.stageID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.stageID)) && Convert.ToString(contLicRenDetails.stageID) != "null")
                            labourvo.stageID = Convert.ToString(contLicRenDetails.stageID);

                        labourvo.total_amount_payable = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_amount_payable)) && Convert.ToString(contLicRenDetails.total_amount_payable) != "null")
                            labourvo.total_amount_payable = Convert.ToString(contLicRenDetails.total_amount_payable);

                        labourvo.total_penality_amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_penality_amount)) && Convert.ToString(contLicRenDetails.total_penality_amount) != "null")
                            labourvo.total_penality_amount = Convert.ToString(contLicRenDetails.total_penality_amount);

                        labourvo.total_registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_registration_fee)) && Convert.ToString(contLicRenDetails.total_registration_fee) != "null")
                            labourvo.total_registration_fee = Convert.ToString(contLicRenDetails.total_registration_fee);

                        labourvo.totalAmount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.totalAmount)) && Convert.ToString(contLicRenDetails.totalAmount) != "null")
                            labourvo.totalAmount = Convert.ToString(contLicRenDetails.totalAmount);

                        labourvo.transaction_for = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_for)) && Convert.ToString(contLicRenDetails.transaction_for) != "null")
                            labourvo.transaction_for = Convert.ToString(contLicRenDetails.transaction_for);

                        labourvo.transaction_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_id)) && Convert.ToString(contLicRenDetails.transaction_id) != "null")
                            labourvo.transaction_id = Convert.ToString(contLicRenDetails.transaction_id);

                        labourvo.transaction_status = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_status)) && Convert.ToString(contLicRenDetails.transaction_status) != "null")
                            labourvo.transaction_status = Convert.ToString(contLicRenDetails.transaction_status);

                        labourvo.transactionDate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transactionDate)) && Convert.ToString(contLicRenDetails.transactionDate) != "null")
                            labourvo.transactionDate = Convert.ToString(contLicRenDetails.transactionDate);

                        labourvo.transactionNumber = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transactionNumber)) && Convert.ToString(contLicRenDetails.transactionNumber) != "null")
                            labourvo.transactionNumber = Convert.ToString(contLicRenDetails.transactionNumber);

                        labourvo.type_of_application = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.type_of_application)) && Convert.ToString(contLicRenDetails.type_of_application) != "null")
                            labourvo.type_of_application = Convert.ToString(contLicRenDetails.type_of_application);

                        labourvo.uID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.uID)) && Convert.ToString(contLicRenDetails.uID) != "null")
                            labourvo.uID = Convert.ToString(contLicRenDetails.uID);

                        labourvo.unpaid_balance_welfare = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.unpaid_balance_welfare)) && Convert.ToString(contLicRenDetails.unpaid_balance_welfare) != "null")
                            labourvo.unpaid_balance_welfare = Convert.ToString(contLicRenDetails.unpaid_balance_welfare);

                        labourvo.valid_from_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.valid_from_date)) && Convert.ToString(contLicRenDetails.valid_from_date) != "null")
                            labourvo.valid_from_date = Convert.ToString(contLicRenDetails.valid_from_date);

                        labourvo.valid_to_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.valid_to_date)) && Convert.ToString(contLicRenDetails.valid_to_date) != "null")
                            labourvo.valid_to_date = Convert.ToString(contLicRenDetails.valid_to_date);


                        labourvo.date_commencement = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.date_commencement)) && Convert.ToString(contLicRenDetails.date_commencement) != "null")
                            labourvo.date_commencement = Convert.ToString(contLicRenDetails.date_commencement);

                        labourvo.date_ending = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.date_ending)) && Convert.ToString(contLicRenDetails.date_ending) != "null")
                            labourvo.date_ending = Convert.ToString(contLicRenDetails.date_ending);

                        labourvo.name_pe = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.name_pe)) && Convert.ToString(contLicRenDetails.name_pe) != "null")
                            labourvo.name_pe = Convert.ToString(contLicRenDetails.name_pe);

                        labourvo.previous_certificate_valid_from = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_certificate_valid_from)) && Convert.ToString(contLicRenDetails.previous_certificate_valid_from) != "null")
                            labourvo.previous_certificate_valid_from = Convert.ToString(contLicRenDetails.previous_certificate_valid_from);

                        labourvo.previous_certificate_valid_to = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_certificate_valid_to)) && Convert.ToString(contLicRenDetails.previous_certificate_valid_to) != "null")
                            labourvo.previous_certificate_valid_to = Convert.ToString(contLicRenDetails.previous_certificate_valid_to);

                        labourvo.previous_registered_act = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registered_act)) && Convert.ToString(contLicRenDetails.previous_registered_act) != "null")
                            labourvo.previous_registered_act = Convert.ToString(contLicRenDetails.previous_registered_act);

                        labourvo.previous_registration_certificate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registration_certificate)) && Convert.ToString(contLicRenDetails.previous_registration_certificate) != "null")
                            labourvo.previous_registration_certificate = Convert.ToString(contLicRenDetails.previous_registration_certificate);

                        labourvo.principal_employees = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.principal_employees)) && Convert.ToString(contLicRenDetails.principal_employees) != "null")
                            labourvo.principal_employees = Convert.ToString(contLicRenDetails.principal_employees);

                        labourvo.stageID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.stageID)) && Convert.ToString(contLicRenDetails.stageID) != "null")
                            labourvo.stageID = Convert.ToString(contLicRenDetails.stageID);

                        labourvo.worksite_district = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_district)) && Convert.ToString(contLicRenDetails.worksite_district) != "null")
                            labourvo.worksite_district = Convert.ToString(contLicRenDetails.worksite_district);

                        labourvo.worksite_door = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_door)) && Convert.ToString(contLicRenDetails.worksite_door) != "null")
                            labourvo.worksite_door = Convert.ToString(contLicRenDetails.worksite_door);

                        labourvo.worksite_locality = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_locality)) && Convert.ToString(contLicRenDetails.worksite_locality) != "null")
                            labourvo.worksite_locality = Convert.ToString(contLicRenDetails.worksite_locality);

                        labourvo.worksite_mandal = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_mandal)) && Convert.ToString(contLicRenDetails.worksite_mandal) != "null")
                            labourvo.worksite_mandal = Convert.ToString(contLicRenDetails.worksite_mandal);

                        labourvo.worksite_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_name)) && Convert.ToString(contLicRenDetails.worksite_name) != "null")
                            labourvo.worksite_name = Convert.ToString(contLicRenDetails.worksite_name);

                        labourvo.worksite_pincode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_pincode)) && Convert.ToString(contLicRenDetails.worksite_pincode) != "null")
                            labourvo.worksite_pincode = Convert.ToString(contLicRenDetails.worksite_pincode);

                        labourvo.worksite_village = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_village)) && Convert.ToString(contLicRenDetails.worksite_village) != "null")
                            labourvo.worksite_village = Convert.ToString(contLicRenDetails.worksite_village);


                        labourvo.intQuessionaireid = Convert.ToString(Session["Applid"]);

                        labourvo.CreatedBy = Session["uid"].ToString().Trim();


                        labourvo.CreatedIP = Request.ServerVariables["Remote_Addr"];

                        labourvo.CLCAFPID = "0";




                        trvisibleregno.Visible = true;
                        txtexistingregvaliditydate.Text = Convert.ToString(contLicRenDetails.previous_certificate_valid_to);
                        txtfactname.Text = contLicRenDetails.nature_work;
                        txtfactaddress.Text = contLicRenDetails.establishment_name;
                        txtfactlicno.Text = contLicRenDetails.name_pe;
                        txtcircle.Text = contLicRenDetails.worksite_door;
                        txtfacthorsepower.Text = contLicRenDetails.worksite_locality;
                        ddlShopDistrict.SelectedValue = contLicRenDetails.worksite_district;
                        ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopMandal.SelectedValue = contLicRenDetails.worksite_mandal;
                        ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopVillage.SelectedValue = contLicRenDetails.worksite_village;
                        txtcircle.Text = contLicRenDetails.establishment_postal_door;
                        txtfacthorsepower.Text = contLicRenDetails.establishment_postal_locality;
                        ddlShopDistrict.SelectedValue = contLicRenDetails.establishment_postal_district;
                        ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopMandal.SelectedValue = contLicRenDetails.establishment_postal_mandal;
                        ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlShopVillage.SelectedValue = contLicRenDetails.establishment_postal_village;
                        txtpincode.Text = contLicRenDetails.establishment_postal_pincode;
                        txtempno.Text = contLicRenDetails.max_employees_aday;

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

                txtfactregno.Text = "";
                txtexistingregvaliditydate.Text = "";
                txtfactname.Text = contLicRenDetails.nature_work;
                txtfactaddress.Text = "";
                txtfactlicno.Text = "";
                txtcircle.Text = contLicRenDetails.worksite_door;
                txtfacthorsepower.Text = contLicRenDetails.worksite_locality;
                ddlShopDistrict.SelectedIndex = 0;
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedIndex = 0;
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedIndex = 0;
                txtpincode.Text = contLicRenDetails.worksite_pincode;
                txtempno.Text = contLicRenDetails.max_employees_aday;
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
        Response.Redirect("frmCinematographLicenseRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim());
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmapplicationForLicenceRenewal.aspx");
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {

    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            labourresponse = labour.contractLicenceActRenewalCheck(txtfactregno.Text.Trim());

            if (labourresponse.status == "SUCCESS")
            {
                trvisibleregno.Visible = true;
                int count = labourresponse.contractLicenceRenewalDetails.Length;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        contLicRenDetails = labourresponse.contractLicenceRenewalDetails[i];
                        labourvo.act = Convert.ToString(contLicRenDetails.actID);
                        //  labourvo.name_pe = Convert.ToString(contLicRenDetails.name_pe;
                        labourvo.max_contract_labour = Convert.ToString(contLicRenDetails.max_employees_aday);
                        labourvo.application_code = Convert.ToString(contLicRenDetails.previous_registration_no);
                        labourvo.contractor_name = Convert.ToString(contLicRenDetails.establishment_name);
                        labourvo.licence_num = Convert.ToString(contLicRenDetails.previous_registration_no);
                        labourvo.expiry_date = Convert.ToString(contLicRenDetails.previous_certificate_valid_to);

                        //labourvo.expiry_date = DateTime.Now;
                        labourvo.worksiteDoorNo = Convert.ToString(contLicRenDetails.establishment_postal_door);
                        labourvo.worksiteLocality = Convert.ToString(contLicRenDetails.establishment_postal_locality);
                        labourvo.worksiteDistrict = Convert.ToString(contLicRenDetails.establishment_postal_district);
                        labourvo.worksiteMandal = Convert.ToString(contLicRenDetails.establishment_postal_mandal);
                        labourvo.worksiteVillage = Convert.ToString(contLicRenDetails.establishment_postal_village);
                        labourvo.worksitePinNo = Convert.ToString(contLicRenDetails.establishment_postal_pincode);
                        labourvo.nature_of_work = Convert.ToString(contLicRenDetails.nature_work);

                        labourvo.user_serial_no = "";
                        //if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.uID)) && Convert.ToString(contLicRenDetails.uID) != "null" && Convert.ToString(contLicRenDetails.uID)!="")

                        if (contLicRenDetails.uID != null && contLicRenDetails.uID != "0")
                        {
                            labourvo.user_serial_no = Convert.ToString(contLicRenDetails.uID);
                        }

                        labourvo.payment_mode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.payment_mode)) && Convert.ToString(contLicRenDetails.payment_mode) != "null")
                        {
                            labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);
                        }

                        //
                        //if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.payment_mode)) && Convert.ToString(contLicRenDetails.payment_mode) != "null")
                        //  {
                        //    labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);
                        //}
                        labourvo.amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.totalAmount)) && Convert.ToString(contLicRenDetails.totalAmount) != "null")
                        {
                            labourvo.amount = Convert.ToString(contLicRenDetails.totalAmount);
                        }
                        //  labourvo.bank_code = "";
                        //  if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_code) && Convert.ToString(contLicRenDetails.bank_code != "null")
                        //  {
                        //      labourvo.bank_code = Convert.ToString(contLicRenDetails.bank_code;
                        //  }

                        labourvo.actID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.actID)) && Convert.ToString(contLicRenDetails.actID) != "null")
                        {
                            labourvo.actID = Convert.ToString(contLicRenDetails.actID);
                        }

                        // labourvo.actID = Convert.ToString(contLicRenDetails.actID;
                        labourvo.bank_code = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_code)) && Convert.ToString(contLicRenDetails.bank_code) != "null")
                            labourvo.bank_code = Convert.ToString(contLicRenDetails.bank_code);

                        labourvo.bank_ref_number = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bank_ref_number)) && Convert.ToString(contLicRenDetails.bank_ref_number) != "null")
                            labourvo.bank_ref_number = Convert.ToString(contLicRenDetails.bank_ref_number);

                        labourvo.bankName = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.bankName)) && Convert.ToString(contLicRenDetails.bankName) != "null")
                            labourvo.bankName = Convert.ToString(contLicRenDetails.bankName);

                        labourvo.cin = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.cin)) && Convert.ToString(contLicRenDetails.cin) != "null")
                            labourvo.cin = Convert.ToString(contLicRenDetails.cin);

                        labourvo.compound_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.compound_fee)) && Convert.ToString(contLicRenDetails.compound_fee) != "null")
                            labourvo.compound_fee = Convert.ToString(contLicRenDetails.compound_fee);

                        labourvo.contractor_email = ""; // "kondam_manjusha@cms.co.in";

                        labourvo.contractor_mobile = ""; //"7337435977";

                        labourvo.entrepreneur_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.entrepreneur_id)) && Convert.ToString(contLicRenDetails.entrepreneur_id) != "null")
                            labourvo.entrepreneur_id = Convert.ToString(contLicRenDetails.entrepreneur_id);

                        labourvo.establishment_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_name)) && Convert.ToString(contLicRenDetails.establishment_name) != "null")
                            labourvo.establishment_name = Convert.ToString(contLicRenDetails.establishment_name);

                        labourvo.establishment_otherstate_address = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_otherstate_address)) && Convert.ToString(contLicRenDetails.establishment_otherstate_address) != "null")
                            labourvo.establishment_otherstate_address = Convert.ToString(contLicRenDetails.establishment_otherstate_address);

                        labourvo.establishment_postal_district = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_district)) && Convert.ToString(contLicRenDetails.establishment_postal_district) != "null")
                            labourvo.establishment_postal_district = Convert.ToString(contLicRenDetails.establishment_postal_district);

                        labourvo.establishment_postal_door = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_door)) && Convert.ToString(contLicRenDetails.establishment_postal_door) != "null")
                            labourvo.establishment_postal_door = Convert.ToString(contLicRenDetails.establishment_postal_door);

                        labourvo.establishment_postal_locality = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_locality)) && Convert.ToString(contLicRenDetails.establishment_postal_locality) != "null")
                            labourvo.establishment_postal_locality = Convert.ToString(contLicRenDetails.establishment_postal_locality);

                        labourvo.establishment_postal_mandal = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_mandal)) && Convert.ToString(contLicRenDetails.establishment_postal_mandal) != "null")
                            labourvo.establishment_postal_mandal = Convert.ToString(contLicRenDetails.establishment_postal_mandal);

                        labourvo.establishment_postal_pincode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_pincode)) && Convert.ToString(contLicRenDetails.establishment_postal_pincode) != "null")
                            labourvo.establishment_postal_pincode = Convert.ToString(contLicRenDetails.establishment_postal_pincode);

                        labourvo.establishment_postal_village = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.establishment_postal_village)) && Convert.ToString(contLicRenDetails.establishment_postal_village) != "null")
                            labourvo.establishment_postal_village = Convert.ToString(contLicRenDetails.establishment_postal_village);

                        labourvo.max_employees_aday = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.max_employees_aday)) && Convert.ToString(contLicRenDetails.max_employees_aday) != "null")
                            labourvo.max_employees_aday = Convert.ToString(contLicRenDetails.max_employees_aday);

                        labourvo.nature_work = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.nature_work)) && Convert.ToString(contLicRenDetails.nature_work) != "null")
                            labourvo.nature_work = Convert.ToString(contLicRenDetails.nature_work);
                        // labourvo.payment_mode = Convert.ToString(contLicRenDetails.payment_mode);

                        labourvo.paymentFlag = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.paymentFlag)) && Convert.ToString(contLicRenDetails.paymentFlag) != "null")
                            labourvo.paymentFlag = Convert.ToString(contLicRenDetails.paymentFlag);

                        labourvo.penality_percentage = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.penality_percentage)) && Convert.ToString(contLicRenDetails.penality_percentage) != "null")
                            labourvo.penality_percentage = Convert.ToString(contLicRenDetails.penality_percentage);

                        labourvo.penality_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.penality_years)) && Convert.ToString(contLicRenDetails.penality_years) != "null")
                            labourvo.penality_years = Convert.ToString(contLicRenDetails.penality_years);

                        labourvo.previous_registration_no = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registration_no)) && Convert.ToString(contLicRenDetails.previous_registration_no) != "null")
                            labourvo.previous_registration_no = Convert.ToString(contLicRenDetails.previous_registration_no);

                        labourvo.principal_employer_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.name_pe)) && Convert.ToString(contLicRenDetails.name_pe) != "null")
                            labourvo.principal_employer_name = Convert.ToString(contLicRenDetails.name_pe);

                        labourvo.projectSubmitDate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.projectSubmitDate)) && Convert.ToString(contLicRenDetails.projectSubmitDate) != "null")
                            labourvo.projectSubmitDate = Convert.ToString(contLicRenDetails.projectSubmitDate);

                        labourvo.questionnaire_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.questionnaire_id)) && Convert.ToString(contLicRenDetails.questionnaire_id) != "null")
                            labourvo.questionnaire_id = Convert.ToString(contLicRenDetails.questionnaire_id);

                        labourvo.registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.registration_fee)) && Convert.ToString(contLicRenDetails.registration_fee) != "null")
                            labourvo.registration_fee = Convert.ToString(contLicRenDetails.registration_fee);

                        labourvo.registration_years = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.registration_years)) && Convert.ToString(contLicRenDetails.registration_years) != "null")
                            labourvo.registration_years = Convert.ToString(contLicRenDetails.registration_years);

                        labourvo.renewalCaseType = "R";

                        labourvo.stageID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.stageID)) && Convert.ToString(contLicRenDetails.stageID) != "null")
                            labourvo.stageID = Convert.ToString(contLicRenDetails.stageID);

                        labourvo.total_amount_payable = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_amount_payable)) && Convert.ToString(contLicRenDetails.total_amount_payable) != "null")
                            labourvo.total_amount_payable = Convert.ToString(contLicRenDetails.total_amount_payable);

                        labourvo.total_penality_amount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_penality_amount)) && Convert.ToString(contLicRenDetails.total_penality_amount) != "null")
                            labourvo.total_penality_amount = Convert.ToString(contLicRenDetails.total_penality_amount);

                        labourvo.total_registration_fee = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.total_registration_fee)) && Convert.ToString(contLicRenDetails.total_registration_fee) != "null")
                            labourvo.total_registration_fee = Convert.ToString(contLicRenDetails.total_registration_fee);

                        labourvo.totalAmount = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.totalAmount)) && Convert.ToString(contLicRenDetails.totalAmount) != "null")
                            labourvo.totalAmount = Convert.ToString(contLicRenDetails.totalAmount);

                        labourvo.transaction_for = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_for)) && Convert.ToString(contLicRenDetails.transaction_for) != "null")
                            labourvo.transaction_for = Convert.ToString(contLicRenDetails.transaction_for);

                        labourvo.transaction_id = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_id)) && Convert.ToString(contLicRenDetails.transaction_id) != "null")
                            labourvo.transaction_id = Convert.ToString(contLicRenDetails.transaction_id);

                        labourvo.transaction_status = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transaction_status)) && Convert.ToString(contLicRenDetails.transaction_status) != "null")
                            labourvo.transaction_status = Convert.ToString(contLicRenDetails.transaction_status);

                        labourvo.transactionDate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transactionDate)) && Convert.ToString(contLicRenDetails.transactionDate) != "null")
                            labourvo.transactionDate = Convert.ToString(contLicRenDetails.transactionDate);

                        labourvo.transactionNumber = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.transactionNumber)) && Convert.ToString(contLicRenDetails.transactionNumber) != "null")
                            labourvo.transactionNumber = Convert.ToString(contLicRenDetails.transactionNumber);

                        labourvo.type_of_application = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.type_of_application)) && Convert.ToString(contLicRenDetails.type_of_application) != "null")
                            labourvo.type_of_application = Convert.ToString(contLicRenDetails.type_of_application);

                        labourvo.uID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.uID)) && Convert.ToString(contLicRenDetails.uID) != "null")
                            labourvo.uID = Convert.ToString(contLicRenDetails.uID);

                        labourvo.unpaid_balance_welfare = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.unpaid_balance_welfare)) && Convert.ToString(contLicRenDetails.unpaid_balance_welfare) != "null")
                            labourvo.unpaid_balance_welfare = Convert.ToString(contLicRenDetails.unpaid_balance_welfare);

                        labourvo.valid_from_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.valid_from_date)) && Convert.ToString(contLicRenDetails.valid_from_date) != "null")
                            labourvo.valid_from_date = Convert.ToString(contLicRenDetails.valid_from_date);

                        labourvo.valid_to_date = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.valid_to_date)) && Convert.ToString(contLicRenDetails.valid_to_date) != "null")
                            labourvo.valid_to_date = Convert.ToString(contLicRenDetails.valid_to_date);


                        labourvo.date_commencement = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.date_commencement)) && Convert.ToString(contLicRenDetails.date_commencement) != "null")
                            labourvo.date_commencement = Convert.ToString(contLicRenDetails.date_commencement);

                        labourvo.date_ending = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.date_ending)) && Convert.ToString(contLicRenDetails.date_ending) != "null")
                            labourvo.date_ending = Convert.ToString(contLicRenDetails.date_ending);

                        labourvo.name_pe = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.name_pe)) && Convert.ToString(contLicRenDetails.name_pe) != "null")
                            labourvo.name_pe = Convert.ToString(contLicRenDetails.name_pe);

                        labourvo.previous_certificate_valid_from = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_certificate_valid_from)) && Convert.ToString(contLicRenDetails.previous_certificate_valid_from) != "null")
                            labourvo.previous_certificate_valid_from = Convert.ToString(contLicRenDetails.previous_certificate_valid_from);

                        labourvo.previous_certificate_valid_to = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_certificate_valid_to)) && Convert.ToString(contLicRenDetails.previous_certificate_valid_to) != "null")
                            labourvo.previous_certificate_valid_to = Convert.ToString(contLicRenDetails.previous_certificate_valid_to);

                        labourvo.previous_registered_act = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registered_act)) && Convert.ToString(contLicRenDetails.previous_registered_act) != "null")
                            labourvo.previous_registered_act = Convert.ToString(contLicRenDetails.previous_registered_act);

                        labourvo.previous_registration_certificate = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.previous_registration_certificate)) && Convert.ToString(contLicRenDetails.previous_registration_certificate) != "null")
                            labourvo.previous_registration_certificate = Convert.ToString(contLicRenDetails.previous_registration_certificate);

                        labourvo.principal_employees = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.principal_employees)) && Convert.ToString(contLicRenDetails.principal_employees) != "null")
                            labourvo.principal_employees = Convert.ToString(contLicRenDetails.principal_employees);

                        labourvo.stageID = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.stageID)) && Convert.ToString(contLicRenDetails.stageID) != "null")
                            labourvo.stageID = Convert.ToString(contLicRenDetails.stageID);

                        labourvo.worksite_district = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_district)) && Convert.ToString(contLicRenDetails.worksite_district) != "null")
                            labourvo.worksite_district = Convert.ToString(contLicRenDetails.worksite_district);

                        labourvo.worksite_door = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_door)) && Convert.ToString(contLicRenDetails.worksite_door) != "null")
                            labourvo.worksite_door = Convert.ToString(contLicRenDetails.worksite_door);

                        labourvo.worksite_locality = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_locality)) && Convert.ToString(contLicRenDetails.worksite_locality) != "null")
                            labourvo.worksite_locality = Convert.ToString(contLicRenDetails.worksite_locality);

                        labourvo.worksite_mandal = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_mandal)) && Convert.ToString(contLicRenDetails.worksite_mandal) != "null")
                            labourvo.worksite_mandal = Convert.ToString(contLicRenDetails.worksite_mandal);

                        labourvo.worksite_name = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_name)) && Convert.ToString(contLicRenDetails.worksite_name) != "null")
                            labourvo.worksite_name = Convert.ToString(contLicRenDetails.worksite_name);

                        labourvo.worksite_pincode = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_pincode)) && Convert.ToString(contLicRenDetails.worksite_pincode) != "null")
                            labourvo.worksite_pincode = Convert.ToString(contLicRenDetails.worksite_pincode);

                        labourvo.worksite_village = "";
                        if (!string.IsNullOrEmpty(Convert.ToString(contLicRenDetails.worksite_village)) && Convert.ToString(contLicRenDetails.worksite_village) != "null")
                            labourvo.worksite_village = Convert.ToString(contLicRenDetails.worksite_village);


                        labourvo.intQuessionaireid = Convert.ToString(Session["Applid"]);

                        labourvo.CreatedBy = Session["uid"].ToString().Trim();


                        labourvo.CreatedIP = Request.ServerVariables["Remote_Addr"];

                        labourvo.CLCAFPID = "0";

                        obj_insertretrival.Insert_Contractlabourrenwal(labourvo);
                    }


                }
                catch (Exception ex)
                {

                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    void getdatacontractlicense()
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

        DataSet dt_getdata = obj_insertretrival.getdetailsrenewalcontractlabourinxmlformat(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));

        try
        {
            if (dt_getdata.Tables.Count > 0)
            {
                if (dt_getdata.Tables[0].Rows.Count > 0)
                {
                    trvisibleregno.Visible = true;
                    txtfactregno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["previous_registration_no"]);
                    txtexistingregvaliditydate.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["previous_certificate_valid_to"]);
                    txtfactname.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["nature_work"]);
                    txtfactaddress.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_name"]);
                    txtfactlicno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["principal_employer_name"]);
                    ddlShopDistrict.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_district"]);
                    ddlShopMandal.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_mandal"]);
                    ddlShopVillage.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_village"]);
                    txtcircle.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_door"]);
                    txtfacthorsepower.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_locality"]);
                    ddlShopDistrict.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_district"]);
                    ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopMandal.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_mandal"]);
                    ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlShopVillage.SelectedValue = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_village"]);
                    txtpincode.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["establishment_postal_pincode"]);
                    txtempno.Text = Convert.ToString(dt_getdata.Tables[0].Rows[0]["max_employees_aday"]);
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
}