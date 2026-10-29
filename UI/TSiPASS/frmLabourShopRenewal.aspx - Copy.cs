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

public partial class UI_TSiPASS_frmLabourShopRenewal : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DropDownList ddlWorkPlace;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    List<LabourWorkPlace> lstworkplaceVo = new List<LabourWorkPlace>();
    List<FamilyMembersAct1> lstfamilyMembersActVo = new List<FamilyMembersAct1>();
    List<EmployeesDetails> lstemployeeDetailsVo = new List<EmployeesDetails>();
    LabourRenewalService.shopRenewalDetails labourrenvo = new LabourRenewalService.shopRenewalDetails();
    //LabourRenewalService.shopsEstRenewals labourren = new LabourRenewalService.shopsEstRenewals();
    LabourRenewalService.TSLabourServiceImplService labour = new LabourRenewalService.TSLabourServiceImplService();
    LabourRenewalService.actsResponse labourresponse = new LabourRenewalService.actsResponse();
    LabourRenewalService.act act = new LabourRenewalService.act();
    RenewalVo labourvo = new RenewalVo();
    LabourRenewalService.shopsEstRenewals shopvo = new LabourRenewalService.shopsEstRenewals();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../index.aspx");
        }
        if (Session["uid"] != null)
        {
            lblmsg0.Text = "";
            Failure.Visible = false;
            if (!IsPostBack)
            {
                DataSet dsCategory = new DataSet();
                DataSet dsClassification = new DataSet();
                dsClassification = Gen.GetLabourActClassification();
                if (dsClassification != null && dsClassification.Tables.Count > 0 && dsClassification.Tables[0].Rows.Count > 0)
                {
                    ddlEstClassification.DataSource = dsClassification.Tables[0];
                    ddlEstClassification.DataTextField = "Classification_Desc";
                    ddlEstClassification.DataValueField = "Classification_Id";
                    ddlEstClassification.DataBind();
                }
                AddSelect(ddlEstClassification);
                dsCategory = Gen.GetLabourActCategoryMaster();
                if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                {
                    ddlCategoryofEstablishment.DataSource = dsCategory.Tables[0];
                    ddlCategoryofEstablishment.DataTextField = "Category_Desc";
                    ddlCategoryofEstablishment.DataValueField = "Category_Id";
                    ddlCategoryofEstablishment.DataBind();
                }
                AddSelect(ddlCategoryofEstablishment);
                BindDistricts(ddlDistrictEstbAct2);
                BindDistricts(ddlDistrictResidentialAct1);

            }
            if (!IsPostBack)
            {
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

                //DataSet ds = new DataSet();
                //ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    FillDetails();
                //}
            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityRENAPPROVALID(Session["Applid"].ToString(), "56");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        //Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }
                    else
                    {
                        Response.Redirect("frmpcbrenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }

            if (!IsPostBack)
            {

                DataSet ds = new DataSet();
                ds = Gen.getdetailsrenewalshopsestablishment(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtcertificateno.Text = ds.Tables[0].Rows[0]["previous_registration_no"].ToString();
                    txtcertificateno_TextChanged(sender, e);
                    FillDetails();

                }
            }
        }
    }

    public void BindDistricts(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrictEstbAct2.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrictEstbAct2.DataSource = dsd.Tables[0];
                ddlDistrictEstbAct2.DataValueField = "District_Id";
                ddlDistrictEstbAct2.DataTextField = "District_Name";
                ddlDistrictEstbAct2.DataBind();
                ddlDistrictEstbAct2.Items.Insert(0, "--District--");
            }
            else
            {
                ddlDistrictEstbAct2.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void txtcertificateno_TextChanged(object sender, EventArgs e)
    {
        try
        {

            //tbldetails.Visible = true;
            LabourRenewalService.shopRenewalDetails labourrenvo = new LabourRenewalService.shopRenewalDetails();
            labourresponse = labour.shopsActRenewalCheck(txtcertificateno.Text.Trim());

            if (labourresponse.status == "SUCCESS")
            {
                trvisibleregno.Visible = true;
                trclassification.Visible = false;
                trresidentialddress.Visible = false;
                trresidentiDistrict.Visible = false;
                trresidentialVillage.Visible = false;
                trresidentialPincode.Visible = false;
                trnatureofbussiness.Visible = false;
                trdateofcommencement.Visible = false;
                tremploycount.Visible = false;
                tragree.Visible = true;
                int count = labourresponse.shopRenewalDetails.Length;
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        //tbldetails.Visible = true;
                        labourrenvo = labourresponse.shopRenewalDetails[i];
                        ViewState["Labourren"] = labourrenvo;
                        labourvo.actID = labourrenvo.actID;
                        labourvo.compound_fee = labourrenvo.compound_fee;
                        labourvo.employer_permanent_door = labourrenvo.employer_permanent_door;
                        labourvo.employer_permanent_locality = labourrenvo.employer_permanent_locality;
                        labourvo.employer_permanent_pincode = labourrenvo.employer_permanent_pincode;
                        labourvo.newPenalityAmount2017 = labourrenvo.newPenalityAmount2017;
                        labourvo.newPenalityYears2017 = labourrenvo.newPenalityYears2017;
                        labourvo.newRegistrationAmount2017 = labourrenvo.newRegistrationAmount2017;
                        labourvo.newRegistrationYears2017 = labourrenvo.newRegistrationYears2017;
                        labourvo.oldPenalityAmount2016 = labourrenvo.oldPenalityAmount2016;
                        labourvo.oldPenalityYears2016 = labourrenvo.oldPenalityYears2016;
                        labourvo.oldRegistrationAmount2016 = labourrenvo.oldRegistrationAmount2016;
                        labourvo.oldRegistrationYears2016 = labourrenvo.oldRegistrationYears2016;
                        labourvo.penality_percentage = labourrenvo.penality_percentage;
                        labourvo.penality_years = labourrenvo.penality_years;
                        labourvo.registration_fee = labourrenvo.registration_fee;
                        labourvo.registration_years = labourrenvo.registration_years;
                        labourvo.renewalExpired = labourrenvo.renewalExpired;
                        labourvo.total_amount_payable = labourrenvo.total_amount_payable;
                        labourvo.total_penality_amount = labourrenvo.total_penality_amount;
                        labourvo.total_registration_fee = labourrenvo.total_registration_fee;
                        labourvo.totalAmount = labourrenvo.totalAmount;
                        labourvo.unpaid_balance_welfare = labourrenvo.unpaid_balance_welfare;
                        labourvo.valid_from_date = labourrenvo.valid_from_date;
                        labourvo.valid_to_date = labourrenvo.valid_to_date;
                        labourvo.employer_email = labourrenvo.employer_email;
                        ViewState["Labourren"] = labourvo;
                        txtempAge.Text = labourrenvo.employer_age;
                        txtEmpSo.Text = labourrenvo.employer_agent_so_do_wo;
                        txtEmpMobileNo.Text = labourrenvo.employer_mobile;
                        txtFullNameemp.Text = labourrenvo.employer_name;
                        txtnameofestablishment.Text = labourrenvo.establishment_name;
                        ddlDistrictEstbAct2.SelectedValue = labourrenvo.establishment_postal_district;
                        ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlMandalEstbAct2.SelectedValue = labourrenvo.establishment_postal_mandal;
                        ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                        txtEstdDoorNoEstbAct2.Text = labourrenvo.establishment_postal_door;
                        txtEstdlocality.Text = labourrenvo.establishment_postal_locality;
                        txtPincodeEstdAct2.Text = labourrenvo.establishment_postal_pincode;
                        txtManagerAge.Text = labourrenvo.manager_agent_age;
                        txtFullNameManager.Text = labourrenvo.manager_agent_name;
                        txtManagerSo.Text = labourrenvo.manager_agent_so_do_wo;
                        txtTotalEmployees.Text = labourrenvo.max_employees_aday;
                        txtrenewalvalidfromdate.Text = labourrenvo.previous_certificate_valid_from;
                        txtrenewalvalidtodate.Text = labourrenvo.previous_certificate_valid_to;
                        txtregnno.Text = labourrenvo.previous_registration_no;
                        //ddlVillageEstbAct2.SelectedValue = labourrenvo.establishment_postal_village;

                        //txtcertificateno.Text = "";



                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

                //lblmsg.Text = "Please enter Correct Registration Number";
                //lblmsg.CssClass = "errormsg";
                trvisibleregno.Visible = false;
                lblmsg0.Text = "<font color='red'>Please enter Correct Registration Number!</font>";
                success.Visible = false;
                Failure.Visible = true;
                txtempAge.Text = "";
                txtEmpSo.Text = "";
                txtEmpMobileNo.Text = "";
                txtFullNameemp.Text = "";
                txtnameofestablishment.Text = "";
                ddlDistrictEstbAct2.SelectedIndex = 0;
                ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalEstbAct2.SelectedIndex = 0;
                ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageEstbAct2.SelectedValue = "";
                txtEstdDoorNoEstbAct2.Text = "";
                txtEstdlocality.Text = "";
                txtPincodeEstdAct2.Text = "";
                txtManagerAge.Text = "";
                txtFullNameManager.Text = "";
                txtManagerSo.Text = "";
                txtTotalEmployees.Text = "";
                txtrenewalvalidfromdate.Text = "";
                txtrenewalvalidtodate.Text = "";
                txtregnno.Text = "";
                //trclassification.Visible = true;
                //trresidentialddress.Visible = true;
                //trresidentiDistrict.Visible = true;
                //trresidentialVillage.Visible = true;
                //trresidentialPincode.Visible = true;
                //trnatureofbussiness.Visible = true;
                //trdateofcommencement.Visible = true;
                //tremploycount.Visible = true;
                //tragree.Visible = false;
            }



        }
        catch (Exception ex)
        {
            //trvisibleregno.Visible = false;
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void rdagreelist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdagreelist.SelectedValue == "N")
        {
            tdpreviousren.Visible = false;
            tdpreviousYear.Visible = true;
            trpreviousrendate.Visible = true;
            lbluploadrencer.Text = "1.2.3 Upload Previous Renewal Certificate";
        }
        else
        {
            tdpreviousren.Visible = false;
            tdpreviousYear.Visible = false;
            trpreviousrendate.Visible = false;
            lbluploadrencer.Text = "1.2.1 Upload Previous Renewal Certificate";
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void ddlDistrictEstbAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictEstbAct2, ddlMandalEstbAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void ddlMandalEstbAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalEstbAct2, ddlVillageEstbAct2);
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
            ddlMandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }

    }

    public void BindVillages(DropDownList ddlMandal, DropDownList ddlVillages)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillages.Items.Clear();
            ddlVillages.Items.Insert(0, "--Village--");
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
                ddlVillages.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillages.Items.Clear();
                ddlVillages.Items.Insert(0, "--Village--");
            }
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        RenewalVo renvo = new RenewalVo();
        try
        {
            if (LabelPreviouscertificate.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Previous Renewal Certificate..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (ViewState["Labourren"] != null)
            {
                renvo = (RenewalVo)(ViewState["Labourren"]);

                if (rdagreelist.SelectedValue == "N")
                {
                    if (txtpreviousrendate.Text == "")
                    {
                        lblmsg.Text = "Please Enter Previous Renewal Date";
                        lblmsg.CssClass = "errormsg";
                        return;
                    }
                    if (ddlprerenyear.SelectedValue == "--Select--")
                    {
                        lblmsg.Text = "Please Select Previous Renewal Year";
                        lblmsg.CssClass = "errormsg";
                        return;
                    }
                }

                if (rdagreelist.SelectedValue == "Y")
                {
                    labourvo.renewalCaseType = "A";
                }
                else
                {
                    labourvo.renewalCaseType = "D";
                }
                labourvo.stageid = 3;
                if (Session["uid"].ToString().Trim() != "")
                {
                    labourvo.Intenterprenurid = Convert.ToInt32(Session["uid"].ToString().Trim());
                    labourvo.Created_by = Session["uid"].ToString().Trim();
                }
                if (Session["Applid"].ToString().Trim() != "")
                {
                    labourvo.questionnaire_id = Convert.ToInt32(Session["Applid"].ToString().Trim());
                }
                labourvo.actID = renvo.actID;
                labourvo.compound_fee = renvo.compound_fee;
                labourvo.employer_age = txtempAge.Text;
                labourvo.employer_agent_so_do_wo = txtEmpSo.Text;
                labourvo.employer_email = renvo.employer_email;
                labourvo.employer_mobile = txtEmpMobileNo.Text.Trim();
                labourvo.employer_name = txtFullNameemp.Text.Trim();
                labourvo.employer_permanent_door = renvo.employer_permanent_door;
                labourvo.employer_permanent_locality = txtemplocality.Text.Trim();
                labourvo.employer_permanent_pincode = renvo.employer_permanent_pincode;
                labourvo.establishment_name = txtnameofestablishment.Text.Trim();
                labourvo.establishment_postal_district = ddlDistrictEstbAct2.SelectedValue;
                //ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_mandal = ddlMandalEstbAct2.SelectedValue;
                //ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_village = ddlVillageEstbAct2.SelectedValue;
                labourvo.establishment_postal_door = txtEstdDoorNoEstbAct2.Text;
                labourvo.establishment_postal_locality = txtEstdlocality.Text;
                labourvo.establishment_postal_pincode = txtPincodeEstdAct2.Text;
                labourvo.manager_agent_age = txtManagerAge.Text;
                labourvo.manager_agent_name = txtFullNameManager.Text;
                labourvo.manager_agent_so_do_wo = txtManagerSo.Text;
                labourvo.max_employees_aday = txtTotalEmployees.Text;
                labourvo.newPenalityAmount2017 = renvo.newPenalityAmount2017;
                labourvo.newPenalityYears2017 = renvo.newPenalityYears2017;
                labourvo.newRegistrationAmount2017 = renvo.newRegistrationAmount2017;
                labourvo.newRegistrationYears2017 = renvo.newRegistrationYears2017;
                labourvo.oldPenalityAmount2016 = renvo.oldPenalityAmount2016;
                labourvo.oldPenalityYears2016 = renvo.oldPenalityYears2016;
                labourvo.oldRegistrationAmount2016 = renvo.oldRegistrationAmount2016;
                labourvo.oldRegistrationYears2016 = renvo.oldRegistrationYears2016;
                labourvo.penality_percentage = renvo.penality_percentage;
                labourvo.penality_years = renvo.penality_years;
                labourvo.previous_certificate_valid_from = txtrenewalvalidfromdate.Text;
                labourvo.previous_certificate_valid_to = txtrenewalvalidtodate.Text;
                labourvo.previous_registration_no = txtregnno.Text;
                labourvo.registration_fee = renvo.registration_fee;
                labourvo.registration_years = renvo.registration_years;
                labourvo.renewalExpired = true;
                labourvo.total_amount_payable = renvo.total_amount_payable;
                labourvo.total_penality_amount = renvo.total_penality_amount;
                labourvo.total_registration_fee = renvo.total_registration_fee;
                labourvo.totalAmount = renvo.totalAmount;
                labourvo.unpaid_balance_welfare = renvo.unpaid_balance_welfare;
                labourvo.CategoryofEstablishments = ddlCategoryofEstablishment.SelectedValue;
                if (renvo.valid_from_date != "null" && renvo.valid_to_date != "")
                {
                    labourvo.valid_from_date = renvo.valid_from_date;
                }
                if (renvo.valid_to_date != "null" && renvo.valid_to_date != "")
                {
                    labourvo.valid_to_date = renvo.valid_to_date;
                }
            }

            else
            {
                if (rdagreelist.SelectedValue == "Y")
                {
                    labourvo.renewalCaseType = "A";
                }
                else
                {
                    labourvo.renewalCaseType = "D";
                }
                labourvo.stageid = 3;
                if (Session["uid"].ToString().Trim() != "")
                {
                    labourvo.Intenterprenurid = Convert.ToInt32(Session["uid"].ToString().Trim());
                    labourvo.Created_by = Session["uid"].ToString().Trim();
                }
                DataSet dsLabour2 = new DataSet();
                string date = "";
                if (txtDateofCommenceAct1.Text != "")
                {
                    string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('/');
                    if (newdate.ToString() != "" && newdate != null)
                    {
                        date = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString();
                    }
                }
                dsLabour2 = Gen.GetShowApprovalandFeesLabouractRenewal("48", "1", txtTotalEmployees.Text.Trim().TrimStart(), date);

                labourvo.actID = "SER";
                labourvo.AdultFemale = Convert.ToInt32(txtAbove18Female.Text.Trim());
                labourvo.AdultMale = Convert.ToInt32(txtAbove18Male.Text.Trim());
                labourvo.CategoryofEstablishments = ddlCategoryofEstablishment.SelectedValue;
                labourvo.ClassificationofEstablishment = ddlEstClassification.SelectedValue;
                labourvo.compound_fee = 0;
                labourvo.Dateofcommencement = date;
                labourvo.employer_age = txtempAge.Text;
                labourvo.employer_agent_so_do_wo = txtEmpSo.Text.Trim();
                labourvo.employer_district = ddlDistrictEstbAct2.SelectedValue;
                labourvo.employer_email = "";
                labourvo.employer_mandal = ddlMandalEstbAct2.SelectedValue;
                labourvo.employer_mobile = txtEmpMobileNo.Text.Trim();
                labourvo.employer_name = txtFullNameemp.Text.Trim();
                labourvo.employer_permanent_door = "";
                labourvo.employer_permanent_locality = txtemplocality.Text.Trim();
                labourvo.employer_permanent_pincode = "";
                labourvo.establishment_name = txtnameofestablishment.Text.Trim();
                labourvo.establishment_postal_district = ddlDistrictEstbAct2.SelectedValue;
                //ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_mandal = ddlMandalEstbAct2.SelectedValue;
                //ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_village = ddlVillageEstbAct2.SelectedValue;
                labourvo.establishment_postal_door = txtEstdDoorNoEstbAct2.Text;
                labourvo.establishment_postal_locality = txtEstdlocality.Text;
                labourvo.establishment_postal_pincode = txtPincodeEstdAct2.Text;
                labourvo.manager_agent_age = txtManagerAge.Text;
                labourvo.manager_agent_name = txtFullNameManager.Text;
                labourvo.manager_agent_so_do_wo = txtManagerSo.Text;
                labourvo.max_employees_aday = txtTotalEmployees.Text;
                labourvo.newPenalityAmount2017 = 0;
                labourvo.newPenalityYears2017 = 0;
                labourvo.newRegistrationAmount2017 = 0;
                labourvo.newRegistrationYears2017 = 0;
                labourvo.oldPenalityAmount2016 = 0;
                labourvo.oldPenalityYears2016 = 0;
                labourvo.oldRegistrationAmount2016 = 0;
                labourvo.oldRegistrationYears2016 = 0;
                labourvo.penality_percentage = 0;
                labourvo.penality_years = 0;
                labourvo.previous_certificate_valid_from = txtrenewalvalidfromdate.Text;
                labourvo.previous_certificate_valid_to = txtrenewalvalidtodate.Text;
                labourvo.previous_registration_no = txtregnno.Text;
                labourvo.registration_fee = 0;
                labourvo.registration_years = 0;
                labourvo.renewalExpired = true;
                if (dsLabour2 != null && dsLabour2.Tables.Count > 0 && dsLabour2.Tables[0].Rows.Count > 0)
                {
                    labourvo.total_amount_payable = Convert.ToInt32(Convert.ToDecimal(dsLabour2.Tables[0].Rows[0]["Fees"].ToString()));
                }
                labourvo.total_penality_amount = 0;
                labourvo.total_registration_fee = 0;
                labourvo.Natureofbusiness = txtNatureofBusinessAct1.Text.Trim();
                //labourvo.totalAmount = renvo.totalAmount;
                //labourvo.unpaid_balance_welfare = renvo.unpaid_balance_welfare;
                //if (renvo.valid_from_date != "nul" && renvo.valid_from_date != "")
                //{
                //    labourvo.valid_from_date = renvo.valid_from_date;
                //}
                //if (renvo.valid_to_date != "nul" && renvo.valid_to_date != "")
                //{
                //    labourvo.valid_to_date = renvo.valid_to_date;
                //}

                //labourvo.you
            }
            Gen.InsertLabourRenewal(labourvo);

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {
            // Response.Redirect("frmLabourShopRenewal.aspx");
            txtcertificateno.Text = "";
            txtcertificateno_TextChanged(sender, e);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        RenewalVo renvo = new RenewalVo();
        try
        {
            //Response.Redirect("frmLabourRenewalApproval.aspx?intApplicationId=" + Session["uid"].ToString().Trim());
            if (txtcertificateno.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Certificate Number..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (LabelPreviouscertificate.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Previous Renewal Certificate..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (ViewState["Labourren"] != null)
            {
                renvo = (RenewalVo)(ViewState["Labourren"]);

                if (rdagreelist.SelectedValue == "N")
                {
                    if (txtpreviousrendate.Text == "")
                    {
                        lblmsg.Text = "Please Enter Previous Renewal Date";
                        lblmsg.CssClass = "errormsg";
                        return;
                    }
                    if (ddlprerenyear.SelectedValue == "--Select--")
                    {
                        lblmsg.Text = "Please Select Previous Renewal Year";
                        lblmsg.CssClass = "errormsg";
                        return;
                    }
                }

                if (rdagreelist.SelectedValue == "Y")
                {
                    labourvo.renewalCaseType = "A";
                }
                else
                {
                    labourvo.renewalCaseType = "D";
                }
                labourvo.stageid = 3;
                if (Session["uid"].ToString().Trim() != "")
                {
                    labourvo.Intenterprenurid = Convert.ToInt32(Session["uid"].ToString().Trim());
                    labourvo.Created_by = Session["uid"].ToString().Trim();
                }
                if (Session["Applid"].ToString().Trim() != "")
                {
                    labourvo.questionnaire_id = Convert.ToInt32(Session["Applid"].ToString().Trim());
                }
                labourvo.actID = renvo.actID;
                labourvo.compound_fee = renvo.compound_fee;
                labourvo.employer_age = txtempAge.Text;
                labourvo.employer_agent_so_do_wo = txtEmpSo.Text;
                labourvo.employer_email = renvo.employer_email;
                labourvo.employer_mobile = txtEmpMobileNo.Text.Trim();
                labourvo.employer_name = txtFullNameemp.Text.Trim();
                labourvo.employer_permanent_door = renvo.employer_permanent_door;
                labourvo.employer_permanent_locality = renvo.employer_permanent_locality;
                labourvo.employer_permanent_pincode = renvo.employer_permanent_pincode;
                labourvo.establishment_name = txtnameofestablishment.Text.Trim();
                labourvo.establishment_postal_district = ddlDistrictEstbAct2.SelectedValue;
                //ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_mandal = ddlMandalEstbAct2.SelectedValue;
                //ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_village = ddlVillageEstbAct2.SelectedValue;
                labourvo.establishment_postal_door = txtEstdDoorNoEstbAct2.Text;
                labourvo.establishment_postal_locality = txtEstdlocality.Text;
                labourvo.establishment_postal_pincode = txtPincodeEstdAct2.Text;
                labourvo.manager_agent_age = txtManagerAge.Text;
                labourvo.manager_agent_name = txtFullNameManager.Text;
                labourvo.manager_agent_so_do_wo = txtManagerSo.Text;
                labourvo.max_employees_aday = txtTotalEmployees.Text;
                labourvo.newPenalityAmount2017 = renvo.newPenalityAmount2017;
                labourvo.newPenalityYears2017 = renvo.newPenalityYears2017;
                labourvo.newRegistrationAmount2017 = renvo.newRegistrationAmount2017;
                labourvo.newRegistrationYears2017 = renvo.newRegistrationYears2017;
                labourvo.oldPenalityAmount2016 = renvo.oldPenalityAmount2016;
                labourvo.oldPenalityYears2016 = renvo.oldPenalityYears2016;
                labourvo.oldRegistrationAmount2016 = renvo.oldRegistrationAmount2016;
                labourvo.oldRegistrationYears2016 = renvo.oldRegistrationYears2016;
                labourvo.penality_percentage = renvo.penality_percentage;
                labourvo.penality_years = renvo.penality_years;
                labourvo.previous_certificate_valid_from = txtrenewalvalidfromdate.Text;
                labourvo.previous_certificate_valid_to = txtrenewalvalidtodate.Text;
                labourvo.previous_registration_no = txtregnno.Text;
                labourvo.registration_fee = renvo.registration_fee;
                labourvo.registration_years = renvo.registration_years;
                labourvo.renewalExpired = true;
                labourvo.total_amount_payable = renvo.total_amount_payable;
                labourvo.total_penality_amount = renvo.total_penality_amount;
                labourvo.total_registration_fee = renvo.total_registration_fee;
                labourvo.totalAmount = renvo.totalAmount;
                labourvo.unpaid_balance_welfare = renvo.unpaid_balance_welfare;
                labourvo.CategoryofEstablishments = ddlCategoryofEstablishment.SelectedValue;
                if (renvo.valid_from_date != "null" && renvo.valid_to_date != "")
                {
                    labourvo.valid_from_date = renvo.valid_from_date;
                }
                if (renvo.valid_to_date != "null" && renvo.valid_to_date != "")
                {
                    labourvo.valid_to_date = renvo.valid_to_date;
                }
            }
            else
            {
                if (rdagreelist.SelectedValue == "Y")
                {
                    labourvo.renewalCaseType = "A";
                }
                else
                {
                    labourvo.renewalCaseType = "D";
                }
                labourvo.stageid = 3;
                if (Session["uid"].ToString().Trim() != "")
                {
                    labourvo.Intenterprenurid = Convert.ToInt32(Session["uid"].ToString().Trim());
                    labourvo.Created_by = Session["uid"].ToString().Trim();
                }
                DataSet dsLabour2 = new DataSet();
                string date = "";
                string[] newdate = txtDateofCommenceAct1.Text.ToString().Split('/');
                if (newdate.ToString() != "" && newdate != null)
                {
                    date = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString();
                }
                dsLabour2 = Gen.GetShowApprovalandFeesLabouractRenewal("48", "1", txtTotalEmployees.Text.Trim().TrimStart(), date);

                labourvo.actID = "SER";
                labourvo.AdultFemale = Convert.ToInt32(txtAbove18Female.Text.Trim());
                labourvo.AdultMale = Convert.ToInt32(txtAbove18Male.Text.Trim());
                labourvo.CategoryofEstablishments = ddlCategoryofEstablishment.SelectedValue;
                labourvo.ClassificationofEstablishment = ddlEstClassification.SelectedValue;
                labourvo.compound_fee = 0;
                labourvo.Dateofcommencement = date;
                labourvo.employer_age = txtempAge.Text;
                labourvo.employer_agent_so_do_wo = txtEmpSo.Text.Trim();
                labourvo.employer_district = ddlDistrictEstbAct2.SelectedValue;
                labourvo.employer_email = "";
                labourvo.employer_mandal = ddlMandalEstbAct2.SelectedValue;
                labourvo.employer_mobile = txtEmpMobileNo.Text.Trim();
                labourvo.employer_name = txtFullNameemp.Text.Trim();
                labourvo.employer_permanent_door = "";
                labourvo.employer_permanent_locality = txtemplocality.Text.Trim();
                labourvo.employer_permanent_pincode = "";
                labourvo.establishment_name = txtnameofestablishment.Text.Trim();
                labourvo.establishment_postal_district = ddlDistrictEstbAct2.SelectedValue;
                //ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_mandal = ddlMandalEstbAct2.SelectedValue;
                //ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
                labourvo.establishment_postal_village = ddlVillageEstbAct2.SelectedValue;
                labourvo.establishment_postal_door = txtEstdDoorNoEstbAct2.Text;
                labourvo.establishment_postal_locality = txtEstdlocality.Text;
                labourvo.establishment_postal_pincode = txtPincodeEstdAct2.Text;
                labourvo.manager_agent_age = txtManagerAge.Text;
                labourvo.manager_agent_name = txtFullNameManager.Text;
                labourvo.manager_agent_so_do_wo = txtManagerSo.Text;
                labourvo.max_employees_aday = txtTotalEmployees.Text;
                labourvo.newPenalityAmount2017 = 0;
                labourvo.newPenalityYears2017 = 0;
                labourvo.newRegistrationAmount2017 = 0;
                labourvo.newRegistrationYears2017 = 0;
                labourvo.oldPenalityAmount2016 = 0;
                labourvo.oldPenalityYears2016 = 0;
                labourvo.oldRegistrationAmount2016 = 0;
                labourvo.oldRegistrationYears2016 = 0;
                labourvo.penality_percentage = 0;
                labourvo.penality_years = 0;
                labourvo.previous_certificate_valid_from = txtrenewalvalidfromdate.Text;
                labourvo.previous_certificate_valid_to = txtrenewalvalidtodate.Text;
                labourvo.previous_registration_no = txtregnno.Text;
                labourvo.registration_fee = 0;
                labourvo.registration_years = 0;
                labourvo.renewalExpired = true;
                if (dsLabour2 != null && dsLabour2.Tables.Count > 0 && dsLabour2.Tables[0].Rows.Count > 0)
                {
                    labourvo.total_amount_payable = Convert.ToInt32(Convert.ToDecimal(dsLabour2.Tables[0].Rows[0]["Fees"].ToString()));
                }
                labourvo.total_penality_amount = 0;
                labourvo.total_registration_fee = 0;
                labourvo.Natureofbusiness = txtNatureofBusinessAct1.Text.Trim();
                //labourvo.totalAmount = renvo.totalAmount;
                //labourvo.unpaid_balance_welfare = renvo.unpaid_balance_welfare;
                //if (renvo.valid_from_date != "nul" && renvo.valid_from_date != "")
                //{
                //    labourvo.valid_from_date = renvo.valid_from_date;
                //}
                //if (renvo.valid_to_date != "nul" && renvo.valid_to_date != "")
                //{
                //    labourvo.valid_to_date = renvo.valid_to_date;
                //}

                //labourvo.you
            }

            Gen.InsertLabourRenewal(labourvo);
            //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Session["Applid"].ToString().Trim());
            Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void BtnPreviouscertificate_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\RENAttachments");

            General t1 = new General();
            if (FilePreviouscertificate.HasFile)
            {
                if ((FilePreviouscertificate.PostedFile != null) && (FilePreviouscertificate.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FilePreviouscertificate.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FilePreviouscertificate.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\LabourPreviousCertificate");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FilePreviouscertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FilePreviouscertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            //result = t1.InsertRenewalAttachement("1", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", txtregnno.Text.Trim(), "LabourPreviousCertificate");
                            result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LabourRenewalPreivousCertificate");
                            // result = t1.InsertImagedataRenewal(Session["Applid"].ToString(), Session["uid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DD Upload", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                HyperlinkPreviouscertificate.Text = FilePreviouscertificate.FileName;
                                LabelPreviouscertificate.Text = FilePreviouscertificate.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtAbove18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18Male.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtAbove18Female_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtBelow18FeMale_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtBelow18FeMale.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtBelow18Male_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
            if (txtAbove18Male.Text.Trim() != "")
                Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
            if (txtAbove18Female.Text.Trim() != "")
                Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
            if (txtBelow18Male.Text.Trim() != "")
                Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
            if (txtBelow18FeMale.Text.Trim() != "")
                Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

            totalAbove18Emp = Above18Male + Above18Female;
            totalBelow18Emp = Below18Male + Below18Female;
            totalEmp = totalAbove18Emp + totalBelow18Emp;

            txtTotalEmployees.Text = totalEmp.ToString();
            txtTotalAbove18.Text = totalAbove18Emp.ToString();
            txtTotalBelow18.Text = totalBelow18Emp.ToString();
            txtAbove18Female.Focus();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
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
        dsdept = Gen.getdetailsrenewalshopsestablishment(Session["uid"].ToString().Trim(), Convert.ToInt32(Session["Applid"]));
        txtempAge.Text = dsdept.Tables[0].Rows[0]["employer_age"].ToString();
        txtEmpSo.Text = dsdept.Tables[0].Rows[0]["employer_agent_so_do_wo"].ToString();
        txtEmpMobileNo.Text = dsdept.Tables[0].Rows[0]["employer_mobile"].ToString();
        txtFullNameemp.Text = dsdept.Tables[0].Rows[0]["employer_name"].ToString();
        txtnameofestablishment.Text = dsdept.Tables[0].Rows[0]["establishment_name"].ToString();
        ddlDistrictEstbAct2.SelectedValue = dsdept.Tables[0].Rows[0]["establishment_postal_district"].ToString();
        ddlDistrictEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
        ddlMandalEstbAct2.SelectedValue = dsdept.Tables[0].Rows[0]["establishment_postal_mandal"].ToString();
        ddlMandalEstbAct2_SelectedIndexChanged(this, EventArgs.Empty);
        ddlVillageEstbAct2.SelectedValue = dsdept.Tables[0].Rows[0]["establishment_postal_village"].ToString();
        txtEstdDoorNoEstbAct2.Text = dsdept.Tables[0].Rows[0]["establishment_postal_door"].ToString();
        txtEstdlocality.Text = dsdept.Tables[0].Rows[0]["establishment_postal_locality"].ToString();
        txtPincodeEstdAct2.Text = dsdept.Tables[0].Rows[0]["establishment_postal_pincode"].ToString();
        txtManagerAge.Text = dsdept.Tables[0].Rows[0]["manager_agent_age"].ToString();
        txtFullNameManager.Text = dsdept.Tables[0].Rows[0]["manager_agent_name"].ToString();
        txtManagerSo.Text = dsdept.Tables[0].Rows[0]["manager_agent_so_do_wo"].ToString();
        txtTotalEmployees.Text = dsdept.Tables[0].Rows[0]["max_employees_aday"].ToString();
        txtrenewalvalidfromdate.Text = dsdept.Tables[0].Rows[0]["previous_certificate_valid_from"].ToString();
        txtrenewalvalidtodate.Text = dsdept.Tables[0].Rows[0]["previous_certificate_valid_to"].ToString();
        txtregnno.Text = dsdept.Tables[0].Rows[0]["previous_registration_no"].ToString();
        txtcertificateno.Text = dsdept.Tables[0].Rows[0]["previous_registration_no"].ToString();
        if (dsdept.Tables[0].Rows[0]["CategoryofEstablishments"].ToString() != null)
        {
            ddlCategoryofEstablishment.SelectedValue = dsdept.Tables[0].Rows[0]["CategoryofEstablishments"].ToString();
        }
        txtemplocality.Text = dsdept.Tables[0].Rows[0]["employer_permanent_locality"].ToString();
        trvisibleregno.Visible = true;
        tragree.Visible = true;
        //txtcertificateno_TextChanged(this, EventArgs.Empty);
    }
}