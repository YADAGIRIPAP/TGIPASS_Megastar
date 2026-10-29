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

public partial class UI_TSiPASS_frmLabourCFO : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DropDownList ddlWorkPlace;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    List<LabourWorkPlace> lstworkplaceVo = new List<LabourWorkPlace>();
    List<LabourWorkPlace> lstworkplaceVo1 = new List<LabourWorkPlace>();
    List<FamilyMembersAct1> lstfamilyMembersActVo = new List<FamilyMembersAct1>();
    List<FamilyMembersAct1> lstfamilyMembersActVo1 = new List<FamilyMembersAct1>();
    List<EmployeesDetails> lstemployeeDetailsVo = new List<EmployeesDetails>();
    List<ContractorDetails> lstContractorVoAct3 = new List<ContractorDetails>();
    List<ContractorDetails> lstContractorVoAct4 = new List<ContractorDetails>();
    List<FamilyMembersAct1> lstFamilyMembers;
    List<EmployeesDetails> LstLabourEmployeesvo;



    int totalContractEmployees;

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
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                    if (dscheck.Tables.Count > 3 && dscheck.Tables[3].Rows.Count > 0)
                    {
                        //door_no pincode mobilenumber,email
                        txtShopDoorNo.Text = dscheck.Tables[3].Rows[0]["door_no"].ToString();
                        txtShopPincode.Text = dscheck.Tables[3].Rows[0]["pincode"].ToString();
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                    }
                }
                else
                {
                    // Session["Applid"] = "0";
                }

                DataSet dsver = new DataSet();

                if (Session["ApplidA"].ToString() == "" || Session["ApplidA"].ToString() == null)
                {
                    DataSet dscheck1 = new DataSet();
                    dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                    if (dscheck1.Tables[0].Rows.Count > 0)
                    {
                        Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    }
                    else
                    {
                        Session["ApplidA"] = "0";
                    }
                }
                dsver = Gen.GetverifyofqueCFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                    ////string res = Gen.RetriveStatus("1002");
                    if (Request.QueryString.Count > 2 && Request.QueryString["Query"] != null && Request.QueryString["Query"] == "Y")
                    {
                        trsubmitqury.Visible = true;
                        trsubmitactual.Visible = false;
                        txtDateofCommenceAct1.Enabled = false;
                        txtEstDateCompAct2.Enabled = false;
                        txtTotalEmployees.Enabled = false;
                    }
                    else
                    {
                        trsubmitqury.Visible = false;
                        trsubmitactual.Visible = true;
                        DataSet dsver1 = new DataSet();
                        dsver1 = Gen.GetverifyofqueLabourCFO(Session["ApplidA"].ToString());

                        if (dsver1.Tables[0].Rows.Count > 0)
                        {
                            if (res == "3" || Convert.ToInt32(res) >= 3)
                            {
                                if(Session["uid"].ToString().Trim()!= "304943")
                                {
                                    ResetFormControl(this);

                                }
                            }
                        }
                    }
                }
            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
                string labourformvisible = "";
                DataSet dscheck1 = new DataSet();
                dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                Session["dscheck"] = dscheck1;
                if (dscheck1.Tables[0].Rows.Count > 0)
                {
                    Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                    labourformvisible = dscheck1.Tables[0].Rows[0]["labourformvisible"].ToString().Trim();
                    if (dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString() != null && dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString() != "")
                    {
                        ViewState["LabourActId"] = dscheck1.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                        LabourActid = ViewState["LabourActId"].ToString();
                    }
                    if (dscheck1 != null && dscheck1.Tables.Count > 0 && dscheck1.Tables[0].Rows.Count > 0)
                    {
                        txtTotalEmployees.Text = dscheck1.Tables[0].Rows[0]["BuildingWorker"].ToString();
                        if (dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString() != null && dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"].ToString() != "")
                        {
                            txtEstDateCompAct2.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["txtDateofCommenceAct1"]).ToString("dd-MM-yyyy");
                        }

                    }
                    //if (LabourActid == "")
                    // {
                    if (labourformvisible.Trim() == "N")
                    {
                        if (Request.QueryString[1].ToString() == "N")
                            // Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                            Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                        else
                            Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "P");

                    }
                }
                else
                {
                    Session["ApplidA"] = "0";
                }
                if (!IsPostBack)
                {
                    if (LabourActid.Contains("1"))
                    {
                        trattachment.Visible = true;
                        trteluguboard.Visible = true;
                        tridproof.Visible = true;
                        trphoto.Visible = true;
                        trrenetaldeed.Visible = true;
                        //lblHead1.Text = "Labour Details";
                        //lblHead2.Text = "Labour Details";
                        trClassification.Visible = true;
                        trManagerorNot.Visible = true;
                        trMaxnoEmployee.Visible = false;
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
                        trGodown1.Visible = true;
                        trGodown2.Visible = true;

                        gvWorkerDtls.DataSource = BindWorkerPlaceGrid();
                        gvWorkerDtls.DataBind();

                        gvFamilyMembersAct1.DataSource = BindgvFamilyMembersAct1Grid();
                        gvFamilyMembersAct1.DataBind();

                        gvEmployeeNames.DataSource = BindgvEmployeeNamesGrid();
                        gvEmployeeNames.DataBind();
                        lblNatureofBusiness.Text = "8. Nature of business *";
                        trFamilyMembers1.Visible = true;
                        trFamilyMembers2.Visible = true;
                        lblTotalEmps.Text = "11. Total No. of Employees *:";
                        trAgewiseEmployees.Visible = true;
                        trNamesofEmployees1.Visible = true;
                        trNamesofEmployees2.Visible = true;
                        //trEmployerAddress1.Visible = true; check whether it is removed.
                        lblPostalAddress.Text = "3. Address of the Shop/Establishment";
                        lblManagerAddress.Visible = false;
                    }
                    if (LabourActid.Contains("2"))
                    {
                        //lblHead1.Text = "The Building & Other Construction Workers Act";
                        //lblHead2.Text = "The Building & Other Construction Workers Act";
                        lblNatureofBusiness.Text = "4. Nature of work / is to be carried on in the establishment";
                        lblTotalEmps.Text = "6. Maximum number of building workers to be employed on any day *";
                        txtTotalEmployees.Enabled = true;
                        trPermanentAddressofEstab.Visible = true;
                        trCompletionDate.Visible = true;
                        BindDistricts(ddlDistrictPermAct2);
                        lblDateofCommencement.Text = "5. Estimated date of commencement of building or other construction work";
                        lblPostalAddress.Text = "1. Postal address of the Establishment";
                        lblPermanentAddress.Text = "2. Full name and Permanent Address of the establishment, if any";
                        lblManagerAddress.Text = "3. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";
                        lblCompletionDate.Text = "7. Estimated date of completion of building or other construction work";

                    }
                    if (LabourActid.Contains("3"))
                    {
                        //lblHead1.Text = "The Contract Labour Act(Principal Employer)";
                        //lblHead2.Text = "The Contract Labour Act(Principal Employer)";
                        trAct3Registration.Visible = true;
                        trDOB.Visible = true;

                        //trWorksite.Visible = true;
                        //commented by rajinikar
                        // {
                        //trParticularofEst.Visible = true;

                        //trNumberdateEst.Visible = true;
                        //trDetailofPrinEmploy.Visible = true;
                        //trDetailofPrinEmploy1.Visible = true;
                        //trMaxnoEmployee.Visible = true;
                        //trWhetherContract.Visible = true;
                        //trContractAddressDetails.Visible = true;
                        // }
                        //trContractorDetailsAct3.Visible = true;
                        BindRegisteredActs();
                        //gvContractorAct3.DataSource = BindContractorGridAct3();
                        //gvContractorAct3.DataBind();
                        lblCategoryofEstab.Text = "Category of Establishment";  //removed numbering in headings.
                        lblPostalAddress.Text = "1.Postal address of the Establishment";
                        lblNatureofBusiness.Text = "Nature of work carried out in the Establishment";
                        lblContractor.Text = "Particulars of Contractors and migrant workmen";
                    }
                    //ADDED BY RAJJINIKAR
                    if (LabourActid.Contains("5"))
                    {
                        DataSet dsCategory = new DataSet();
                        dsCategory = Gen.GetLabourActCategoryMaster();
                        if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                        {
                            ddlCategoryofEstablishment.DataSource = dsCategory.Tables[0];
                            ddlCategoryofEstablishment.DataTextField = "Category_Desc";
                            ddlCategoryofEstablishment.DataValueField = "Category_Id";
                            ddlCategoryofEstablishment.DataBind();
                        }
                        AddSelect(ddlCategoryofEstablishment);
                        trCategory.Visible = true;
                        trnoanddate.Visible = true;
                        trDeposit.Visible = true;
                        trduration.Visible = true;
                        trselectZone.Visible = true;
                        trContractAddressDetails.Visible = true;
                        trWhetherContract.Visible = true;
                        trMaxnoEmployee.Visible = true;
                        trDetailofPrinEmploy.Visible = true;
                        trDetailofPrinEmploy1.Visible = true;
                        trManagerorNot.Visible = true;
                        trGodown1.Visible = false;
                        trdobnumdatedetails.Visible = true;
                        trDOB.Visible = true;
                        trParticularofEst.Visible = true;

                        trNumberdateEst.Visible = true;

                        trDetailofPrinEmploy.Visible = true;
                        trDetailofPrinEmploy1.Visible = true;
                        tddetails.Visible = true;

                        tragentormanagerdetails.Visible = true;
                        tragentormanageraddress.Visible = true;


                        BindRegisteredActs();

                        lblCategoryofEstab.Text = " 1.Category of Establishment";  //removed numbering in headings.
                        lblPostalAddress.Text = "2.Name and address of the worksite";
                        lblHDeposit.Text = "16.Security Deposit Details";
                        lblNatureofBusiness.Text = "17.Nature of work carried out in the Establishment";


                        //else if(LabourActid=="1,5")
                        //{
                        //    trduration.Visible = true;
                        //    trselectZone.Visible = true;
                        //    trContractAddressDetails.Visible = true;
                        //    trWhetherContract.Visible = true;
                        //    trMaxnoEmployee.Visible = true;
                        //    trDetailofPrinEmploy.Visible = true;
                        //    trDetailofPrinEmploy1.Visible = true;
                        //    trEmployerAddress1.Visible = true;
                        //    trDOB.Visible = true;
                        //    trParticularofEst.Visible = true;

                        //    trNumberdateEst.Visible = true;

                        //    trDetailofPrinEmploy.Visible = true;
                        //    trDetailofPrinEmploy1.Visible = true;
                        //    lblPostalAddress.Text = "Name and address of the worksite";

                        //    BindRegisteredActs();
                        //}
                        //else if(LabourActid=="1,3,5")

                        //{
                        //    trduration.Visible = true;
                        //    trselectZone.Visible = true;
                        //    trContractAddressDetails.Visible = true;
                        //    trWhetherContract.Visible = true;
                        //    trMaxnoEmployee.Visible = true;
                        //    trDetailofPrinEmploy.Visible = true;
                        //    trDetailofPrinEmploy1.Visible = true;
                        //    trEmployerAddress1.Visible = true;
                        //    trDOB.Visible = true;
                        //    trParticularofEst.Visible = true;

                        //    trNumberdateEst.Visible = true;

                        //    trDetailofPrinEmploy.Visible = true;
                        //    trDetailofPrinEmploy1.Visible = true;
                        //    lblPostalAddress.Text = "Name and address of the worksite";

                        //    BindRegisteredActs();

                        //}
                    }
                    if (LabourActid.Contains("4"))
                    {
                        //lblHead1.Text = "Principal Employer Registration under Interstate Migrant Workman Act";
                        //lblHead2.Text = "Principal Employer Registration under Interstate Migrant Workman Act";
                        trDirectorAddress.Visible = true;

                        BindDistricts(ddlDirDistrict);
                        lblCategoryofEstab.Text = "1. Category of Establishment";
                        lblPostalAddress.Text = "2. Postal address of the Establishment";
                        lblManagerAddress.Text = "5. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";
                        lblNatureofBusiness.Text = "6. Nature of work / is to be carried on in the establishment";
                    }
                    if (LabourActid.Contains("3") || LabourActid.Contains("4"))
                    {
                        // 
                        lblTotalEmps.Text = "Total No.of Contract Employees * :";
                        trTotalContractors.Visible = true;
                        lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        //trEmployerAddress1.Visible = false;
                        trContractorDetailsAct4.Visible = true;
                        gvContractorAct4.DataSource = BindContractorGridAct3();
                        gvContractorAct4.DataBind();

                    }
                    if (LabourActid.Contains("1") || LabourActid.Contains("2"))
                    {
                        trDateofCommencement.Visible = true;
                        trTotalEmps.Visible = true;
                    }
                    if (LabourActid.Contains("1") || LabourActid.Contains("3") || LabourActid.Contains("4"))
                    {
                        DataSet dsCategory = new DataSet();
                        dsCategory = Gen.GetLabourActCategoryMaster();
                        if (dsCategory != null && dsCategory.Tables.Count > 0 && dsCategory.Tables[0].Rows.Count > 0)
                        {
                            ddlCategoryofEstablishment.DataSource = dsCategory.Tables[0];
                            ddlCategoryofEstablishment.DataTextField = "Category_Desc";
                            ddlCategoryofEstablishment.DataValueField = "Category_Id";
                            ddlCategoryofEstablishment.DataBind();
                        }
                        AddSelect(ddlCategoryofEstablishment);
                        trEmployerDetails1.Visible = true;
                        trEmployerDetails2.Visible = true;

                        trEmployerAddress2.Visible = true;
                        BindDistricts(ddlDistrictResidentialAct1);
                        trCategory.Visible = true;

                    }
                    if (LabourActid.Contains("2") || LabourActid.Contains("3") || LabourActid.Contains("4"))
                    {
                        //trManagerResidenceAct1.Visible = true;
                        if (LabourActid.Contains("3"))
                        {
                            lblEmployerAddress.Text = "Name and address of the contractor";
                        }
                        //trteluguboard.Visible = false;
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("2"))
                    {
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "7. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "9. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "10. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "12. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "14. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("3"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "12. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        if (LabourActid.Contains("3"))
                        {
                            lblPostalAddress.Text = "Name and address of the worksite"; //added newly
                        }
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "6. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "7. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "8. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "9. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "10. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "11. Name of Employees (Optional):";
                        lblCompletionDate.Text = "12. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("3") && LabourActid.Contains("5"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "12. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        if (LabourActid.Contains("3"))
                        {
                            lblPostalAddress.Text = "3.Name and address of the worksite"; //added newly
                        }
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "6. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "7. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "8. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "9. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "10. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "11. Name of Employees (Optional):";
                        lblCompletionDate.Text = "12. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "6. Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "13. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "7. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "8. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "9. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "10. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "11. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "12. Name of Employees (Optional):";
                        lblCompletionDate.Text = "13. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("2") && LabourActid.Contains("3"))//23
                    {
                        lblCategoryofEstab.Text = "1. Category of Establishment";
                        lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "5. Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "10. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "2. Postal address of the Establishment";
                        lblPermanentAddress.Text = "4. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "6. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "7. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "8. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "9. Estimated date of completion of building or other construction work";
                        lblManagerAddress.Text = "5. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";

                    }
                    if (LabourActid.Contains("2") && LabourActid.Contains("4"))// 24
                    {
                        lblCategoryofEstab.Text = "1. Category of Establishment";
                        lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "5.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "11. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "2. Postal address of the Establishment";
                        lblPermanentAddress.Text = "4. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "7. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "8. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "9. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "10. Estimated date of completion of building or other construction work";
                        lblManagerAddress.Text = "6. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";

                    }
                    if (LabourActid.Contains("3") && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "1. Category of Establishment";
                        lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "4.  Name and address of the Director / Partners (in case of companies/firm)";

                        lblPostalAddress.Text = "2. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "7. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "6. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "9. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "10. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "11. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "12. Name of Employees (Optional):";
                        lblCompletionDate.Text = "7. Estimated date of completion of building or other construction work";
                        lblContractor.Text = "7. Particulars of Contractors and migrant workmen";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("2") && LabourActid.Contains("3"))// && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "14. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "7. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "8. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "9. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "10. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "11. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "12. Name of Employees (Optional):";
                        lblCompletionDate.Text = "13. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("2") && LabourActid.Contains("4"))// && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "15. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "9. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "10. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "12. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "14. Estimated date of completion of building or other construction work";
                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("3") && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "6.  Name and address of the Director / Partners (in case of companies/firm)";

                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "7. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "8. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "9. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "10. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "11. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "12. Name of Employees (Optional):";
                        lblCompletionDate.Text = "13. Estimated date of completion of building or other construction work";
                        lblContractor.Text = "13. Particulars of Contractors and migrant workmen";
                    }
                    if (LabourActid.Contains("2") && LabourActid.Contains("3") && LabourActid.Contains("4"))//234
                    {
                        lblCategoryofEstab.Text = "1. Category of Establishment";
                        lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "5.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "11. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "2. Postal address of the Establishment";
                        lblPermanentAddress.Text = "4. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "7. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "8. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "9. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "10. Estimated date of completion of building or other construction work";
                        lblManagerAddress.Text = "6. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";

                    }
                    if (LabourActid.Contains("1") && LabourActid.Contains("2") && LabourActid.Contains("3") && LabourActid.Contains("4"))
                    {
                        lblCategoryofEstab.Text = "2. Category of Establishment";
                        lblEmployer.Text = "5. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                        lblDirector.Text = "7.  Name and address of the Director / Partners (in case of companies/firm)";
                        lblContractor.Text = "15. Particulars of Contractors and migrant workmen";
                        lblPostalAddress.Text = "3. Postal address of the Establishment";
                        lblPermanentAddress.Text = "6. Full name and Permanent Address of the establishment, if any";
                        lblManagerOrNot.Text = "8. Manager/Agent if any (with residential address):";
                        lblNatureofBusiness.Text = "9. Nature of work / is to be carried on in the establishment";
                        lblDateofCommencement.Text = "10. Estimated date of commencement of building or other construction work";
                        lblFamily.Text = "11. Name of family members of employees family engaged in Shop / Establishment";
                        lblTotalEmps.Text = "12. Maximum number of building workers to be employed on any day *";
                        lblEmployeeNames.Text = "13. Name of Employees (Optional):";
                        lblCompletionDate.Text = "14. Estimated date of completion of building or other construction work";
                    }



                    BindDistricts(ddlShopDistrict);
                    BindDistricts(DropDownList7);
                    BindDistricts(ddlagentormanagerdistrict);
                    //ddlDistPrinEmploy
                    BindDistricts(ddlDistPrinEmploy);

                    BindDistricts(ddlManagerDistrictAct1);
                }
                if (!IsPostBack)
                {
                    FillDetails();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        string LabourActid = "";
        try
        {
            LabourActid = ViewState["LabourActId"].ToString();
            int QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
            ds = Gen.getLabourDetailsCFO(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                if (LabourActid.Contains("1") || LabourActid.Contains("3") || LabourActid.Contains("4"))
                {
                    ddlCategoryofEstablishment.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                    if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
                    {
                        trMemorandum.Visible = true;
                        trincorportaion.Visible = true;
                    }
                }
                if (LabourActid.Contains("2"))
                {
                    txtEstDateCompAct2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"]).ToString("dd-MM-yyyy");
                    txtTotalEmployees.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();

                    txtDoorNoPermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                    txtPinCodePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                    ddlDistrictPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                    ddlDistrictPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlMandalPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                    ddlMandalPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlVillagePermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();

                    txtFullNamePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString();

                }
                if (LabourActid.Contains("3"))
                {
                    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();

                    //if (ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)
                    //{
                    //    ViewState["dtContractorDtls3"] = ds.Tables[4];
                    //    gvContractorAct3.DataSource = ds.Tables[4];
                    //    gvContractorAct3.DataBind();
                    //}
                }
                if (LabourActid.Contains("4"))
                {
                    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();

                }
                if (LabourActid.Contains("3") || LabourActid.Contains("4"))
                {

                    if (ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)
                    {
                        ViewState["dtContractorDtls4"] = ds.Tables[4];
                        gvContractorAct4.DataSource = ds.Tables[4];
                        gvContractorAct4.DataBind();
                    }
                }
                if (LabourActid.Contains("5"))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        trDeposit.Visible = true;
                        if (ds.Tables[0].Rows[0]["chkZone1"].ToString() == "Y")
                        {
                            chkZone1.Checked = true;

                        }
                        else
                        {
                            chkZone1.Checked = false;
                        }
                        if (ds.Tables[0].Rows[0]["chkZone2"].ToString() == "Y")
                        {
                            chkZone2.Checked = true;


                        }
                        else
                        {
                            chkZone2.Checked = false;
                        }
                        if (ds.Tables[0].Rows[0]["chkZone3"].ToString() == "Y")
                        {
                            chkZone3.Checked = true;

                        }
                        else
                        {
                            chkZone3.Checked = false;
                        }
                        txtContAddPincode.Text = ds.Tables[0].Rows[0]["ContAddPincode_contract"].ToString();
                        txtContLocality.Text = ds.Tables[0].Rows[0]["ContLocality_contract"].ToString();
                        txtContOutsideLoc.Text = ds.Tables[0].Rows[0]["ContOutsideLoc_contract"].ToString();
                        txtNameofContractor.Text = ds.Tables[0].Rows[0]["NameofContractor_contLic"].ToString();

                        DropDownList7.SelectedValue = ds.Tables[0].Rows[0]["DropDownList7_contLic"].ToString();
                        DropDownList7_SelectedIndexChanged(this, EventArgs.Empty);
                        DropDownList8.SelectedValue = ds.Tables[0].Rows[0]["DropDownList8_contLic"].ToString();
                        DropDownList8_SelectedIndexChanged(this, EventArgs.Empty);
                        DropDownList9.SelectedValue = ds.Tables[0].Rows[0]["DropDownList9_contLic"].ToString();

                        txtContrEmail.Text = ds.Tables[0].Rows[0]["ContrEmail_contract"].ToString();
                        txtContrMobile.Text = ds.Tables[0].Rows[0]["ContrMobile_contract"].ToString();
                        txtMaxoEmployees.Text = ds.Tables[0].Rows[0]["MaxoEmployees_contract"].ToString();
                        rblcontractConvict.SelectedValue = ds.Tables[0].Rows[0]["contractConvict_contract"].ToString();
                        rblcontractSuspend.SelectedValue = ds.Tables[0].Rows[0]["contractSuspend_contract"].ToString();
                        rblcontractEst.SelectedValue = ds.Tables[0].Rows[0]["rblcontractEst_contract"].ToString();
                        txtStartDate.Text = ds.Tables[0].Rows[0]["StartDate_duration_contract"].ToString();
                        txtEndDate.Text = ds.Tables[0].Rows[0]["EndDate_duration_contract"].ToString();
                        txtDOB.Text = ds.Tables[0].Rows[0]["txtDOB_contract"].ToString();
                        txtage.Text = ds.Tables[0].Rows[0]["AgentorManagerAge"].ToString();
                        txtPartEstablNumber.Text = ds.Tables[0].Rows[0]["PartEstablNumber_contract"].ToString();
                        txtPartEstablDate.Text = ds.Tables[0].Rows[0]["PartEstablDate_contract"].ToString();
                        txtPrinEmployPincode.Text = ds.Tables[0].Rows[0]["PrinEmployPincode_contract"].ToString();
                        txtNamePrinEmploy.Text = ds.Tables[0].Rows[0]["NamePrinEmploy_contract"].ToString();
                        txtDoornoPrinEmploy.Text = ds.Tables[0].Rows[0]["DoornoPrinEmploy_contract"].ToString();

                        ddlDistPrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["DistPrinEmploy_contract"].ToString();
                        ddlDistPrinEmploy_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlMandalPrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["MandalPrinEmploy_contract"].ToString();
                        ddlMandalPrinEmploy_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlVillagePrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["VillagePrinEmploy_contract"].ToString();

                        txtOtherStateAddrPrinEmploy.Text = ds.Tables[0].Rows[0]["PrinEmploytxtOtherStateAddr_contract"].ToString();

                        txtagentormanagername.Text = ds.Tables[0].Rows[0]["AgentorManagerName"].ToString();
                        txtagentormanagerdoorno.Text = ds.Tables[0].Rows[0]["AgentorManagerDoorNo"].ToString();
                        txtagentormanagerlocality.Text = ds.Tables[0].Rows[0]["AgentorManagerLocality"].ToString();
                        txtagentormanageraddress.Text = ds.Tables[0].Rows[0]["AgentorManagerAddress"].ToString();
                        txtagentormanagerpincode.Text = ds.Tables[0].Rows[0]["AgentorManagerPincode"].ToString();

                        ddlagentormanagerdistrict.Text = ds.Tables[0].Rows[0]["AgentorManagerDistrict"].ToString();
                        ddlagentormanagerdistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlagentormanagermandal.Text = ds.Tables[0].Rows[0]["AgentorManagerMandal"].ToString();
                        ddlagentormanagermandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlagentormanagervillage.Text = ds.Tables[0].Rows[0]["AgentorManagerVillage"].ToString();

                        txtAmountPaid.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpaid"].ToString();
                        txtAmountPayable.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpayable"].ToString();
                        txtChallanNo.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanNo"].ToString();
                        txtchallandate.Text = ds.Tables[0].Rows[0]["SecurityDepositChallanDate"].ToString();
                        lblAttachChallan.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanFileName"].ToString();


                        txtNatureofBusinessAct1.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                    }
                    DataSet dsattachment = new DataSet();
                    dsattachment = Gen.ViewAttachmetsDataCFO(hdfFlagID0.Value.ToString());

                    if (dsattachment.Tables[0].Rows.Count > 0)
                    {
                        int c = dsattachment.Tables[0].Rows.Count;
                        string sen, sen1, sen2;
                        int i = 0;

                        while (i < c)
                        {
                            sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                            sen1 = sen2.Replace(@"\", @"/");
                            sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");


                            if (sen.Contains("LabourSecurityDepositChallan"))
                            {
                                //hyperlocationorsiteplan.NavigateUrl = sen;
                                // hyperlocationorsiteplan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                lblAttachChallan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                //HyperLink1.NavigateUrl = sen;
                                //HyperLink1.Text = 
                            }

                            i++;
                        }
                    }
                }
                txtMobileNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                txtEmailManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                txtNameofShopAct1.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                txtShopDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                txtShopLocality.Text = ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                ddlShopDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddlShopVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();

                txtShopPincode.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                TxtnameofUnitAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                txtPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                txtDesigAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                txtAgeAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                txtMobileAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                txtEmailAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                txtDoorNoResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                txtLocalResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                ddlDistrictResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                ddlDistrictResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlMandalResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                ddlMandalResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlVillageResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                if (LabourActid.Contains("1"))
                {
                    Rd_ManagerResidenceAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString();
                    Rd_ManagerResidenceAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                txtManagerNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                txtManagerPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                txtManagerDesignationAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                txtManagerDoorNoAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                txtManagerLocalityAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                ddlManagerDistrictAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                ddlManagerDistrictAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerMandalAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                ddlManagerMandalAct1_SelectedIndexChanged(this, EventArgs.Empty);
                ddlManagerVillageAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();

                txtNatureofBusinessAct1.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                if (LabourActid.Contains("1") || LabourActid.Contains("2"))
                {
                    txtDateofCommenceAct1.Text = ds.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                }
                if (LabourActid.Contains("1"))
                {
                    ddlEstClassification.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();

                    txtAbove18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                    txtBelow18Male.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                    txtAbove18Female.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                    txtBelow18FeMale.Text = ds.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                    txtBelow18FeMale_TextChanged(this, EventArgs.Empty);

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        ViewState["dtWorkerDtls"] = ds.Tables[1];

                        gvWorkerDtls.DataSource = ds.Tables[1];
                        gvWorkerDtls.DataBind();
                    }
                    if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                    {
                        ViewState["dtFamilyMembers"] = ds.Tables[2];

                        gvFamilyMembersAct1.DataSource = ds.Tables[2];
                        gvFamilyMembersAct1.DataBind();
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        ViewState["dtEmplyoees"] = ds.Tables[3];

                        gvEmployeeNames.DataSource = ds.Tables[3];
                        gvEmployeeNames.DataBind();
                    }
                    DataSet dsattachment = new DataSet();
                    dsattachment = Gen.ViewAttachmentCFO(Session["uid"].ToString());

                    if (dsattachment.Tables[0].Rows.Count > 0)
                    {
                        int c = dsattachment.Tables[0].Rows.Count;
                        string sen, sen1, sen2;
                        int i = 0;

                        while (i < c)
                        {
                            sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                            sen1 = sen2.Replace(@"\", @"/");



                            //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                            //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                            if (sen1.Contains("CFOAttachments"))
                            {
                                sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                                if (sen.Contains("TeluguBoard"))
                                {
                                    lblTeluguBoard.NavigateUrl = sen;
                                    lblTeluguBoard.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    LabelTeluguBoard.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                                if (sen.Contains("IDProofEmployer"))
                                {
                                    HyperLinkidproof.NavigateUrl = sen;
                                    HyperLinkidproof.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelidproof.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                                if (sen.Contains("PassportSizePhoto"))
                                {
                                    HyperLinkphoto.NavigateUrl = sen;
                                    HyperLinkphoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelphoto.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                                if (sen.Contains("RentalSaleDeed"))
                                {
                                    HyperLinkrenetaldeed.NavigateUrl = sen;
                                    HyperLinkrenetaldeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelrenetaldeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                                if (sen.Contains("MemorandumofArticle"))
                                {
                                    trMemorandum.Visible = true;
                                    HyperLinkMemorandum.NavigateUrl = sen;
                                    HyperLinkMemorandum.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    LabelMemorandum.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                                if (sen.Contains("Incorporation"))
                                {
                                    trincorportaion.Visible = true;
                                    HyperLinkincorportaion.NavigateUrl = sen;
                                    HyperLinkincorportaion.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    Labelincorportaion.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                    //HyperLink1.NavigateUrl = sen;
                                    //HyperLink1.Text = 
                                }
                            }
                            i++;
                        }
                    }
                }

                try
                {
                    txtDirFullName.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                    txtDirDoorNo.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                    ddlDirDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                    ddlDirDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlDirMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                    ddlDirMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlDirVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                }
                catch (Exception ex)
                {

                }
            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {
        }
    }
    protected void gvWorkerDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindWorkerPlaceGridAdd();

                DropDownList ddlWorkPlace;
                TextBox txtDoorNo;
                TextBox txtLocality;

                String[] arraydata = new String[3];

                int gvrcnt = gvWorkerDtls.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                    arraydata[0] = ddlWorkPlace.SelectedValue;
                    GridViewRow gvr = gvWorkerDtls.Rows[i];
                    txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                    arraydata[1] = txtDoorNo.Text;
                    txtLocality = (TextBox)gvr.FindControl("txtLocality");
                    arraydata[2] = txtLocality.Text;

                    if (txtDoorNo.Text == "" || txtLocality.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Work Place details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvWorkerDtls.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindWorkerPlaceGridAdd();
                    DropDownList ddlWorkPlace;
                    TextBox txtDoorNo;
                    TextBox txtLocality;
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    decimal extent = 0;
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            ddlWorkPlace = (DropDownList)gvWorkerDtls.Rows[i].Cells[1].Controls[1];
                            arraydata[0] = ddlWorkPlace.SelectedValue;
                            GridViewRow gvr = gvWorkerDtls.Rows[i];
                            txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            arraydata[1] = txtDoorNo.Text;
                            txtLocality = (TextBox)gvr.FindControl("txtLocality");
                            arraydata[2] = txtLocality.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtWorkerDtls"] = dt;
                    gvWorkerDtls.DataSource = dt;
                    gvWorkerDtls.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvWorkerDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsWorkPlace = new DataSet();
            dsWorkPlace = Gen.GetWorkPlaceMaster();
            if (dsWorkPlace != null && dsWorkPlace.Tables.Count > 0 && dsWorkPlace.Tables[0].Rows.Count > 0)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ddlWorkPlace = (DropDownList)e.Row.Cells[1].Controls[1];

                    ddlWorkPlace.DataSource = dsWorkPlace.Tables[0];
                    ddlWorkPlace.DataTextField = "Work_Place";
                    ddlWorkPlace.DataValueField = "WorkPlace_Id";
                    ddlWorkPlace.DataBind();

                    AddSelect(ddlWorkPlace);

                    DataTable dt = (DataTable)ViewState["dtWorkerDtls"];

                    if (dt != null)
                    {
                        if (e.Row.RowIndex < dt.Rows.Count)
                        {
                            GridViewRow gvr = e.Row;
                            TextBox txtDoorNo = (TextBox)gvr.FindControl("txtDoorNo");
                            TextBox txtLocality = (TextBox)gvr.FindControl("txtLocality");

                            txtDoorNo.Text = dt.Rows[e.Row.RowIndex]["Door_No"].ToString();
                            txtLocality.Text = dt.Rows[e.Row.RowIndex]["Locality"].ToString();
                            ddlWorkPlace.SelectedValue = dt.Rows[e.Row.RowIndex]["Work_Place"].ToString();

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected DataTable BindWorkerPlaceGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");
        dt.Columns.Add("Door_No");
        dt.Columns.Add("Locality");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
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
    protected DataTable BindWorkerPlaceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvFamilyMembersAct1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvFamilyMembersAct1GridAdd();
                String[] arraydata = new String[4];

                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                    DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                    GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                    TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                    arraydata[0] = txtFamilyMemeberName.Text;
                    arraydata[1] = ddlRelationship.SelectedValue;
                    arraydata[2] = ddlGender.SelectedValue;
                    arraydata[3] = ddlPersonType.SelectedValue;


                    if (txtFamilyMemeberName.Text == "" || ddlRelationship.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Family Member details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFamilyMembersAct1.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvFamilyMembersAct1GridAdd();
                    String[] arraydata = new String[4];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlRelationship = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[2].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                            DropDownList ddlGender = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[3].Controls[1];
                            DropDownList ddlPersonType = (DropDownList)gvFamilyMembersAct1.Rows[i].Cells[4].Controls[1];

                            GridViewRow gvr = gvFamilyMembersAct1.Rows[i];
                            TextBox txtFamilyMemeberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");
                            arraydata[0] = txtFamilyMemeberName.Text;
                            arraydata[1] = ddlRelationship.SelectedValue;
                            arraydata[2] = ddlGender.SelectedValue;
                            arraydata[3] = ddlPersonType.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFamilyMembers"] = dt;
                    gvFamilyMembersAct1.DataSource = dt;
                    gvFamilyMembersAct1.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvFamilyMembersAct1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsRelations = new DataSet();
            DataSet dsGenders = new DataSet();
            DataSet dsPersonTypes = new DataSet();
            dsRelations = Gen.GetLabourActRelationshipMaster();

            dsGenders = Gen.GetGender();
            dsPersonTypes = Gen.GetLabourActPersonMaster();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRelationship = (DropDownList)e.Row.Cells[2].Controls[1];
                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];
                DropDownList ddlPersonType = (DropDownList)e.Row.Cells[4].Controls[1];

                if (dsRelations != null && dsRelations.Tables.Count > 0 && dsRelations.Tables[0].Rows.Count > 0)
                {
                    ddlRelationship.DataSource = dsRelations.Tables[0];
                    ddlRelationship.DataTextField = "Relationship_Type";
                    ddlRelationship.DataValueField = "Relationship_Id";
                    ddlRelationship.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }
                if (dsPersonTypes != null && dsPersonTypes.Tables.Count > 0 && dsPersonTypes.Tables[0].Rows.Count > 0)
                {
                    ddlPersonType.DataSource = dsPersonTypes.Tables[0];
                    ddlPersonType.DataTextField = "PersonType_Type";
                    ddlPersonType.DataValueField = "PersonType_Id";
                    ddlPersonType.DataBind();
                }

                AddSelect(ddlRelationship);
                AddSelect(ddlGender);
                AddSelect(ddlPersonType);

                DataTable dt = (DataTable)ViewState["dtFamilyMembers"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtFamilyMemberName = (TextBox)gvr.FindControl("txtFamilyNameAct1");

                        txtFamilyMemberName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlRelationship.SelectedValue = dt.Rows[e.Row.RowIndex]["RelationShip"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();
                        ddlPersonType.SelectedValue = dt.Rows[e.Row.RowIndex]["Adult_Flag"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }


    }
    protected DataTable BindgvFamilyMembersAct1GridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("RelationShip");
        dt.Columns.Add("Gender");
        dt.Columns.Add("Adult_Flag");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvFamilyMembersAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvEmployeeNamesGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");
        dt.Columns.Add("Name");
        dt.Columns.Add("Gender");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }

    protected DataTable BindgvEmployeeNamesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Occupation");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvEmployeeNames_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsOccupations = new DataSet();
            DataSet dsGenders = new DataSet();
            dsOccupations = Gen.GetLabourActOccupationMaster();

            dsGenders = Gen.GetGender();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlOccupationAct1 = (DropDownList)e.Row.Cells[1].Controls[1];

                DropDownList ddlGender = (DropDownList)e.Row.Cells[3].Controls[1];


                if (dsOccupations != null && dsOccupations.Tables.Count > 0 && dsOccupations.Tables[0].Rows.Count > 0)
                {
                    ddlOccupationAct1.DataSource = dsOccupations.Tables[0];
                    ddlOccupationAct1.DataTextField = "Occupation_Type";
                    ddlOccupationAct1.DataValueField = "Occupation_Id";
                    ddlOccupationAct1.DataBind();
                }
                if (dsGenders != null && dsGenders.Tables.Count > 0 && dsGenders.Tables[0].Rows.Count > 0)
                {
                    ddlGender.DataSource = dsGenders.Tables[0];
                    ddlGender.DataTextField = "Gender_Type";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                }


                AddSelect(ddlOccupationAct1);
                AddSelect(ddlGender);
                DataTable dt = (DataTable)ViewState["dtEmplyoees"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");

                        txtEmployeeName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        ddlOccupationAct1.SelectedValue = dt.Rows[e.Row.RowIndex]["Occupation"].ToString();
                        ddlGender.SelectedValue = dt.Rows[e.Row.RowIndex]["Gender"].ToString();

                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }

    }
    protected void gvEmployeeNames_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvEmployeeNamesGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvEmployeeNames.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                    DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                    GridViewRow gvr = gvEmployeeNames.Rows[i];
                    TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                    arraydata[0] = ddlOccupation.SelectedValue;
                    arraydata[1] = txtEmployeeName.Text;
                    arraydata[2] = ddlGender.SelectedValue;


                    if (txtEmployeeName.Text == "" || ddlOccupation.SelectedValue == "0" || ddlGender.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Employee details";
                        lblmsg.CssClass = "errormsg";
                    }

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvEmployeeNames.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvEmployeeNamesGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
                            DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

                            GridViewRow gvr = gvEmployeeNames.Rows[i];
                            TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
                            arraydata[0] = ddlOccupation.SelectedValue;
                            arraydata[1] = txtEmployeeName.Text;
                            arraydata[2] = ddlGender.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtEmplyoees"] = dt;
                    gvEmployeeNames.DataSource = dt;
                    gvEmployeeNames.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void Rd_ManagerResidenceAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rd_ManagerResidenceAct1.SelectedValue.ToString().Trim() == "Y")
        {
            trManagerResidenceAct1.Visible = true;
        }
        else
        {
            trManagerResidenceAct1.Visible = false;
        }
    }
    protected DataTable BindgvNoofEmployeesAct1Grid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("");
        dt.Columns.Add("");
        dt.Columns.Add("");

        DataRow dr = dt.NewRow();
        dr[0] = "MALE";
        dr[1] = "FEMALE";
        dr[2] = "TOTAL";
        dt.Rows.Add(dr);

        return dt;
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
                ddlDistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--District--");
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
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(DropDownList7, DropDownList8);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDistPrinEmploy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistPrinEmploy, ddlMandalPrinEmploy);
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
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(DropDownList8, DropDownList9);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalPrinEmploy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalPrinEmploy, ddlVillagePrinEmploy);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDistrictResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictResidentialAct1, ddlMandalResidentialAct1);

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalResidentialAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalResidentialAct1, ddlVillageResidentialAct1);
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

    protected void ddlManagerMandalAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlManagerMandalAct1, ddlManagerVillageAct1);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlManagerDistrictAct1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlManagerDistrictAct1, ddlManagerMandalAct1);
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
                }
            }
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
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {

            //labouractvo.
            int valid = 0;
            //labouractvo.
            if (gvWorkerDtls.Visible == true)
            {
                if (gvWorkerDtls.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>Please enter Worker Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                    // return;
                }
            }
            if (gvFamilyMembersAct1.Visible == true)
            {
                if (gvFamilyMembersAct1.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter family members of the Employees Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                    // return;
                }
            }
            if (gvEmployeeNames.Visible == true)
            {
                if (gvEmployeeNames.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Employees Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                    // return;
                }
            }
            if (gvContractorAct4.Visible == true)
            {
                if (gvContractorAct4.Rows.Count < 2)
                {
                    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Contractor and migrant workmen Details..!</font>";
                    lblmsg0.Visible = true;
                    success.Visible = false;
                    Failure.Visible = true;
                    valid = 1;
                    // return;
                }
            }
            if (trteluguboard.Visible)
            {
                if (LabelTeluguBoard.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Telugu Board Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (ddlEstClassification.SelectedValue == "0")
                {
                    lblmsg0.Text = "<font color='red'>Please Select Classification of Establishment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    ddlEstClassification.Enabled = true;
                    return;
                }
                if (ddlCategoryofEstablishment.SelectedValue == "0")
                {
                    lblmsg0.Text = "<font color='red'>Please Select Category of Establishment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    ddlCategoryofEstablishment.Enabled = true;
                    return;
                }
            }
            if (tridproof.Visible)
            {
                if (Labelidproof.Text == "")
                {
                    FileUploadidproof.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Id proof of Employer..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trphoto.Visible)
            {
                if (Labelphoto.Text == "")
                {
                    FileUploadphoto.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Passport Size of Employee..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trrenetaldeed.Visible)
            {
                if (Labelrenetaldeed.Text == "")
                {
                    FileUploadrenetaldeed.Enabled = true;
                    lblmsg0.Text = "<font color='red'>Please Upload Rental Deed/Sale Deed/Ownership Proof..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
            {
                if (trMemorandum.Visible)
                {
                    if (LabelMemorandum.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Memorandum of Articles..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trincorportaion.Visible)
                {
                    if (Labelincorportaion.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Certification of Incorporation..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
            }
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

            //txtTotalEmployees.Text = totalEmp.ToString();
            //txtTotalAbove18.Text = totalAbove18Emp.ToString();
            //txtTotalBelow18.Text = totalBelow18Emp.ToString();

            //commented by rajinikar
            //if (Convert.ToInt32(txtTotalEmployees.Text.Trim()) != Convert.ToInt32(totalEmp))
            //{
            //    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Total of Adults and Young persons should be equal to total number of Employees..!</font>";
            //    lblmsg0.Visible = true;
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    //valid = 1;
            //    return;
            //}
            if (valid == 0)
            {
                //string LabourActid = ViewState["LabourActId"].ToString();
                //if (LabourActid.Contains("3"))
                //{
                valid = SaveLabourDetails_Contract();
                //}
                //else
                //{
                //    valid = SaveLabourDetails();
                //}


                lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    private int SaveLabourDetails()
    {

        LabourActVO labouractvo = new LabourActVO();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        labouractvo.EstClassification = ddlEstClassification.SelectedValue;
        labouractvo.CategoryofEstablishment = ddlCategoryofEstablishment.SelectedValue;
        labouractvo.NameofShopAct1 = txtNameofShopAct1.Text;
        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.ShopDoorNo = txtShopDoorNo.Text;
        labouractvo.ShopLocality = txtShopLocality.Text;
        labouractvo.ShopDistrict = ddlShopDistrict.SelectedValue;
        labouractvo.ShopMandal = ddlShopMandal.SelectedValue;
        labouractvo.ShopVillage = ddlShopVillage.SelectedValue;
        labouractvo.ShopPincode = txtShopPincode.Text;

        labouractvo.NameofUnitAct1 = TxtnameofUnitAct1.Text;
        labouractvo.PGNameAct1 = txtPGNameAct1.Text;
        labouractvo.EmpDesignation = txtDesigAct1.Text;
        labouractvo.AgeAct1 = txtAgeAct1.Text;
        labouractvo.MobileAct1 = txtMobileAct1.Text;
        labouractvo.EmailAct1 = txtEmailAct1.Text;

        labouractvo.DoorNoResidentialAct1 = txtDoorNoResidentialAct1.Text;
        labouractvo.LocalResidentialAct1 = txtLocalResidentialAct1.Text;
        labouractvo.DistrictResidentialAct1 = ddlDistrictResidentialAct1.SelectedValue;
        labouractvo.MandalResidentialAct1 = ddlMandalResidentialAct1.SelectedValue;
        labouractvo.VillageResidentialAct1 = ddlVillageResidentialAct1.SelectedValue;

        labouractvo.ManagerResidenceAct1 = Rd_ManagerResidenceAct1.SelectedValue;
        labouractvo.ManagerNameAct1 = txtManagerNameAct1.Text;
        labouractvo.ManagerPGNameAct1 = txtManagerPGNameAct1.Text;
        labouractvo.ManagerDesignationAct1 = txtManagerDesignationAct1.Text;
        labouractvo.ManagerDoorNo = txtManagerDoorNoAct1.Text;
        labouractvo.ManagerLocalityAct1 = txtManagerLocalityAct1.Text;
        labouractvo.ManagerDistrictAct1 = ddlManagerDistrictAct1.SelectedValue;
        labouractvo.ManagerMandalAct1 = ddlManagerMandalAct1.SelectedValue;
        labouractvo.ManagerVillageAct1 = ddlManagerVillageAct1.SelectedValue;
        labouractvo.ManagerMobileNo = txtMobileNoManagerAct2.Text;
        labouractvo.ManagerEmail = txtEmailManagerAct2.Text;

        labouractvo.NatureofBusinessAct1 = txtNatureofBusinessAct1.Text;
        labouractvo.DateofCommenceAct1 = txtDateofCommenceAct1.Text;

        if (txtTotalEmployees.Text.Trim() != "")
            labouractvo.TotalEmployees = Convert.ToInt32(txtTotalEmployees.Text);
        if (txtAbove18Male.Text.Trim() != "")
            labouractvo.Above18Male = Convert.ToInt32(txtAbove18Male.Text);
        if (txtBelow18Male.Text.Trim() != "")
            labouractvo.Below18Male = Convert.ToInt32(txtBelow18Male.Text);
        if (txtAbove18Female.Text.Trim() != "")
            labouractvo.Above18FeMale = Convert.ToInt32(txtAbove18Female.Text);
        if (txtBelow18FeMale.Text.Trim() != "")
            labouractvo.Below18FeMale = Convert.ToInt32(txtBelow18FeMale.Text);
        if (txtTotalAbove18.Text.Trim() != "")
            labouractvo.TotalAbove18 = Convert.ToInt32(txtTotalAbove18.Text);
        if (txtTotalBelow18.Text.Trim() != "")
            labouractvo.TotalBelow18 = Convert.ToInt32(txtTotalBelow18.Text);


        foreach (GridViewRow gvrow in gvWorkerDtls.Rows)
        {
            LabourWorkPlace workplaceVo = new LabourWorkPlace();
            DropDownList ddlWorkPlace = (DropDownList)gvrow.FindControl("ddlWorkPlace");
            TextBox txtDoorNo = (TextBox)gvrow.FindControl("txtDoorNo");
            TextBox txtLocality = (TextBox)gvrow.FindControl("txtLocality");
            workplaceVo.WorkPlace = ddlWorkPlace.SelectedValue;
            workplaceVo.DoorNo = txtDoorNo.Text.Trim();
            workplaceVo.Locality = txtLocality.Text.Trim();

            lstworkplaceVo.Add(workplaceVo);
        }
        foreach (GridViewRow gvrow in gvFamilyMembersAct1.Rows)
        {
            FamilyMembersAct1 familyMembersActVo = new FamilyMembersAct1();

            DropDownList ddlRelationshipAct1 = (DropDownList)gvrow.FindControl("ddlRelationshipAct1");
            DropDownList ddlFamilyGenderAct1 = (DropDownList)gvrow.FindControl("ddlFamilyGenderAct1");
            DropDownList ddlFamilyAdultAct1 = (DropDownList)gvrow.FindControl("ddlFamilyAdultAct1");
            TextBox txtFamilyNameAct1 = (TextBox)gvrow.FindControl("txtFamilyNameAct1");
            familyMembersActVo.RelationshipAct1 = ddlRelationshipAct1.SelectedValue;
            familyMembersActVo.FamilyNameAct1 = txtFamilyNameAct1.Text;
            familyMembersActVo.GenderAct1 = ddlFamilyGenderAct1.SelectedValue;

            familyMembersActVo.AdultAct1 = ddlFamilyAdultAct1.SelectedValue;

            lstfamilyMembersActVo.Add(familyMembersActVo);
        }
        foreach (GridViewRow gvrow in gvEmployeeNames.Rows)
        {
            EmployeesDetails employeeDetailsVo = new EmployeesDetails();

            DropDownList ddlOccupationAct1 = (DropDownList)gvrow.FindControl("ddlOccupationAct1");
            DropDownList ddlEmployeeGenderAct1 = (DropDownList)gvrow.FindControl("ddlEmployeeGenderAct1");

            TextBox txtEmployeeNameAct1 = (TextBox)gvrow.FindControl("txtEmployeeNameAct1");
            employeeDetailsVo.Occupation = ddlOccupationAct1.SelectedValue;
            employeeDetailsVo.EmployeeNameAct1 = txtEmployeeNameAct1.Text.Trim();
            employeeDetailsVo.EmployeeGenderAct1 = ddlEmployeeGenderAct1.SelectedValue;

            lstemployeeDetailsVo.Add(employeeDetailsVo);
        }
        ///////////////////act2 //////////
        labouractvo.FullNamePerAct2 = txtFullNamePermAct2.Text;
        labouractvo.PerDoorNoAct2 = txtDoorNoPermAct2.Text;
        labouractvo.PerPincode = txtPinCodePermAct2.Text;
        labouractvo.PerDistrict = ddlDistrictPermAct2.SelectedValue;
        labouractvo.PerMandal = ddlMandalPermAct2.SelectedValue;
        labouractvo.PerVillage = ddlVillagePermAct2.SelectedValue;
        labouractvo.CompletionDateAct2 = txtEstDateCompAct2.Text;
        ///////////////////act2 completed //////////
        ///////////////////act3 //////////
        labouractvo.RegActId = ddlSchemAct3.SelectedValue;
        labouractvo.LicenseRegNo = txtRegLicAct3.Text;
        labouractvo.ContractEmployeesAct4 = txtTotalContractors.Text;
        //foreach (GridViewRow gvrow in gvContractorAct3.Rows)
        //{
        //    ContractorDetails ContractorVo = new ContractorDetails();

        //    TextBox txtContractor = (TextBox)gvrow.FindControl("txtContractorNameAct4");
        //    TextBox txtAddress = (TextBox)gvrow.FindControl("txtContractorAddressAct4");
        //    TextBox txtWorkNature = (TextBox)gvrow.FindControl("txtContractorNatureAct4");

        //    TextBox txtManufacturingDepts = (TextBox)gvrow.FindControl("txtManufacturingDepts");

        //    TextBox txtCommenceDate = (TextBox)gvrow.FindControl("txtContractorCommenceAct4");
        //    TextBox txtMaxNoWorkmen = (TextBox)gvrow.FindControl("txtMaxNoofContractLabour");
        //    TextBox txtCompleteDate = (TextBox)gvrow.FindControl("txtContractorCompAct4");

        //    ContractorVo.ContractorName = txtContractor.Text;
        //    ContractorVo.ContractorAddress = txtAddress.Text;
        //    ContractorVo.ManufacturingDepts = txtManufacturingDepts.Text;
        //    ContractorVo.ContractorWorkNature = txtWorkNature.Text;
        //    ContractorVo.ContractorWorkMen = txtMaxNoWorkmen.Text;
        //    ContractorVo.ContractorCommence = txtCommenceDate.Text;
        //    ContractorVo.ContractorComplete = txtCompleteDate.Text;

        //    lstContractorVoAct3.Add(ContractorVo);
        //}
        ///////////////////act3 completed //////////
        ///////////////////act4 //////////


        labouractvo.DirNameAct4 = txtDirFullName.Text;
        labouractvo.DirDoorNoAct4 = txtDirDoorNo.Text;
        labouractvo.DirVillageAct4 = ddlDirVillage.SelectedValue;
        labouractvo.DirMandalAct4 = ddlDirMandal.SelectedValue;
        labouractvo.DirDistrictAct4 = ddlDirDistrict.SelectedValue;
        foreach (GridViewRow gvrow in gvContractorAct4.Rows)
        {
            ContractorDetails ContractorVo = new ContractorDetails();

            TextBox txtContractor = (TextBox)gvrow.FindControl("txtContractorNameAct4");
            TextBox txtAddress = (TextBox)gvrow.FindControl("txtContractorAddressAct4");
            TextBox txtMobileNo = (TextBox)gvrow.FindControl("txtContractorMobileNoAct4");
            TextBox txtWorkNature = (TextBox)gvrow.FindControl("txtContractorNatureAct4");
            TextBox txtNoWorkmen = (TextBox)gvrow.FindControl("txtContractorMaximumNoAct4");
            TextBox txtCommenceDate = (TextBox)gvrow.FindControl("txtContractorCommenceAct4");
            TextBox txtCompleteDate = (TextBox)gvrow.FindControl("txtContractorCompAct4");
            TextBox txtManufacturingDepts = (TextBox)gvrow.FindControl("txtManufacturingDepts");
            ContractorVo.ManufacturingDepts = txtManufacturingDepts.Text;

            ContractorVo.ContractorName = txtContractor.Text;
            ContractorVo.ContractorAddress = txtAddress.Text;
            ContractorVo.ContractorMobileNo = txtMobileNo.Text;
            ContractorVo.ContractorWorkNature = txtWorkNature.Text;
            ContractorVo.ContractorWorkMen = txtNoWorkmen.Text;
            ContractorVo.ContractorCommence = txtCommenceDate.Text;
            ContractorVo.ContractorComplete = txtCompleteDate.Text;

            lstContractorVoAct4.Add(ContractorVo);
        }
        ///////////////////act4 completed //////////
        int valid = Gen.InsertLabourDetailsCFO(labouractvo, lstworkplaceVo, lstemployeeDetailsVo, lstfamilyMembersActVo, lstContractorVoAct3, lstContractorVoAct4);
        return valid;
        //return 0;
    }

    private int SaveLabourDetails_Contract()
    {
        string chkZone12, chkZone22, chkZone32;
        if (chkZone1.Checked == true)
            chkZone12 = "Y";
        else chkZone12 = "N";
        if (chkZone2.Checked == true)
            chkZone22 = "Y";
        else chkZone22 = "N";
        if (chkZone3.Checked == true)
            chkZone32 = "Y";
        else chkZone32 = "N";

        LabourActVO_ContraactLicense oLabourActVO_ContraactLicense = new LabourActVO_ContraactLicense();
        oLabourActVO_ContraactLicense.chkZone1 = chkZone12;
        oLabourActVO_ContraactLicense.chkZone2 = chkZone22;
        oLabourActVO_ContraactLicense.chkZone3 = chkZone32;

        oLabourActVO_ContraactLicense.ContAddPincode_contract = txtContAddPincode.Text;
        oLabourActVO_ContraactLicense.ContLocality_contract = txtContLocality.Text;
        oLabourActVO_ContraactLicense.ContOutsideLoc_contract = txtContOutsideLoc.Text;
        oLabourActVO_ContraactLicense.NameofContractor_contLic = txtNameofContractor.Text;
        oLabourActVO_ContraactLicense.DropDownList7_contLic = DropDownList7.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.DropDownList8_contLic = DropDownList8.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.DropDownList9_contLic = DropDownList9.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.ContrEmail_contract = txtContrEmail.Text.ToString();
        oLabourActVO_ContraactLicense.ContrMobile_contract = txtContrMobile.Text.ToString();

        oLabourActVO_ContraactLicense.MaxoEmployees_contract = txtMaxoEmployees.Text.ToString();

        oLabourActVO_ContraactLicense.contractConvict_contract = rblcontractConvict.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.contractSuspend_contract = rblcontractSuspend.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.rblcontractEst_contract = rblcontractEst.SelectedValue.ToString();

        oLabourActVO_ContraactLicense.StartDate_duration_contract = txtStartDate.Text.ToString();
        oLabourActVO_ContraactLicense.EndDate_duration_contract = txtEndDate.Text.ToString();
        oLabourActVO_ContraactLicense.txtDOB_contract = txtDOB.Text.ToString();
        oLabourActVO_ContraactLicense.PartEstablNumber_contract = txtPartEstablNumber.Text.ToString();
        oLabourActVO_ContraactLicense.PartEstablDate_contract = txtPartEstablDate.Text.ToString();

        oLabourActVO_ContraactLicense.PrinEmployPincode_contract = txtPrinEmployPincode.Text.ToString();
        oLabourActVO_ContraactLicense.DistPrinEmploy_contract = ddlDistPrinEmploy.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.MandalPrinEmploy_contract = ddlMandalPrinEmploy.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.VillagePrinEmploy_contract = ddlVillagePrinEmploy.SelectedValue.ToString();
        oLabourActVO_ContraactLicense.NamePrinEmploy_contract = txtNamePrinEmploy.Text.ToString();
        oLabourActVO_ContraactLicense.DoornoPrinEmploy_contract = txtDoornoPrinEmploy.Text.ToString();
        oLabourActVO_ContraactLicense.PrinEmploytxtOtherStateAddr_contract = txtOtherStateAddrPrinEmploy.Text.ToString();


        oLabourActVO_ContraactLicense.Nameofagentormanager = txtagentormanagername.Text.ToString();
        oLabourActVO_ContraactLicense.DirDoorNoofagentormanager = txtagentormanagerdoorno.Text.ToString();
        oLabourActVO_ContraactLicense.DirLocalityofagentormanager = txtagentormanagerlocality.Text.ToString();
        oLabourActVO_ContraactLicense.DirAddressofagentormanager = txtagentormanageraddress.Text.ToString();
        oLabourActVO_ContraactLicense.DirDistrictofagentormanager = ddlagentormanagerdistrict.SelectedValue;
        oLabourActVO_ContraactLicense.DirMandalofagentormanager = ddlagentormanagermandal.SelectedValue;
        oLabourActVO_ContraactLicense.DirVillageofagentormanager = ddlagentormanagervillage.SelectedValue;
        oLabourActVO_ContraactLicense.DirPincodeofagentormanager = txtagentormanagerpincode.Text.ToString();
        oLabourActVO_ContraactLicense.Age = txtage.Text.ToString();

        oLabourActVO_ContraactLicense.SecurityDepositPaid = txtAmountPaid.Text;
        oLabourActVO_ContraactLicense.SecurityDepositPayable = txtAmountPayable.Text;
        oLabourActVO_ContraactLicense.SecurityDepositChallanNo = txtChallanNo.Text;
        oLabourActVO_ContraactLicense.SecurityDepositChallanDate = txtchallandate.Text;
        //oLabourActVO_ContraactLicense.SecurityDepositChallanFilename = lblAttachChallan.Text;


        LabourActVO labouractvo = new LabourActVO();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["ApplidA"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        labouractvo.EstClassification = ddlEstClassification.SelectedValue;
        labouractvo.CategoryofEstablishment = ddlCategoryofEstablishment.SelectedValue;
        labouractvo.NameofShopAct1 = txtNameofShopAct1.Text;
        labouractvo.CreatedBy = Convert.ToInt32(Session["uid"].ToString().Trim());
        labouractvo.ShopDoorNo = txtShopDoorNo.Text;
        labouractvo.ShopLocality = txtShopLocality.Text;
        labouractvo.ShopDistrict = ddlShopDistrict.SelectedValue;
        labouractvo.ShopMandal = ddlShopMandal.SelectedValue;
        labouractvo.ShopVillage = ddlShopVillage.SelectedValue;
        labouractvo.ShopPincode = txtShopPincode.Text;

        labouractvo.NameofUnitAct1 = TxtnameofUnitAct1.Text;
        labouractvo.PGNameAct1 = txtPGNameAct1.Text;
        labouractvo.EmpDesignation = txtDesigAct1.Text;
        labouractvo.AgeAct1 = txtAgeAct1.Text;
        labouractvo.MobileAct1 = txtMobileAct1.Text;
        labouractvo.EmailAct1 = txtEmailAct1.Text;

        labouractvo.DoorNoResidentialAct1 = txtDoorNoResidentialAct1.Text;
        labouractvo.LocalResidentialAct1 = txtLocalResidentialAct1.Text;
        labouractvo.DistrictResidentialAct1 = ddlDistrictResidentialAct1.SelectedValue;
        labouractvo.MandalResidentialAct1 = ddlMandalResidentialAct1.SelectedValue;
        labouractvo.VillageResidentialAct1 = ddlVillageResidentialAct1.SelectedValue;

        labouractvo.ManagerResidenceAct1 = Rd_ManagerResidenceAct1.SelectedValue;
        labouractvo.ManagerNameAct1 = txtManagerNameAct1.Text;
        labouractvo.ManagerPGNameAct1 = txtManagerPGNameAct1.Text;
        labouractvo.ManagerDesignationAct1 = txtManagerDesignationAct1.Text;
        labouractvo.ManagerDoorNo = txtManagerDoorNoAct1.Text;
        labouractvo.ManagerLocalityAct1 = txtManagerLocalityAct1.Text;
        labouractvo.ManagerDistrictAct1 = ddlManagerDistrictAct1.SelectedValue;
        labouractvo.ManagerMandalAct1 = ddlManagerMandalAct1.SelectedValue;
        labouractvo.ManagerVillageAct1 = ddlManagerVillageAct1.SelectedValue;
        labouractvo.ManagerMobileNo = txtMobileNoManagerAct2.Text;
        labouractvo.ManagerEmail = txtEmailManagerAct2.Text;

        labouractvo.NatureofBusinessAct1 = txtNatureofBusinessAct1.Text;
        labouractvo.DateofCommenceAct1 = txtDateofCommenceAct1.Text;

        if (txtTotalEmployees.Text.Trim() != "")
            labouractvo.TotalEmployees = Convert.ToInt32(txtTotalEmployees.Text);
        if (txtAbove18Male.Text.Trim() != "")
            labouractvo.Above18Male = Convert.ToInt32(txtAbove18Male.Text);
        if (txtBelow18Male.Text.Trim() != "")
            labouractvo.Below18Male = Convert.ToInt32(txtBelow18Male.Text);
        if (txtAbove18Female.Text.Trim() != "")
            labouractvo.Above18FeMale = Convert.ToInt32(txtAbove18Female.Text);
        if (txtBelow18FeMale.Text.Trim() != "")
            labouractvo.Below18FeMale = Convert.ToInt32(txtBelow18FeMale.Text);
        if (txtTotalAbove18.Text.Trim() != "")
            labouractvo.TotalAbove18 = Convert.ToInt32(txtTotalAbove18.Text);
        if (txtTotalBelow18.Text.Trim() != "")
            labouractvo.TotalBelow18 = Convert.ToInt32(txtTotalBelow18.Text);


        foreach (GridViewRow gvrow in gvWorkerDtls.Rows)
        {
            LabourWorkPlace workplaceVo = new LabourWorkPlace();
            DropDownList ddlWorkPlace = (DropDownList)gvrow.FindControl("ddlWorkPlace");
            TextBox txtDoorNo = (TextBox)gvrow.FindControl("txtDoorNo");
            TextBox txtLocality = (TextBox)gvrow.FindControl("txtLocality");
            workplaceVo.WorkPlace = ddlWorkPlace.SelectedValue;
            workplaceVo.DoorNo = txtDoorNo.Text.Trim();
            workplaceVo.Locality = txtLocality.Text.Trim();

            lstworkplaceVo.Add(workplaceVo);
        }
        foreach (GridViewRow gvrow in gvFamilyMembersAct1.Rows)
        {
            FamilyMembersAct1 familyMembersActVo = new FamilyMembersAct1();

            DropDownList ddlRelationshipAct1 = (DropDownList)gvrow.FindControl("ddlRelationshipAct1");
            DropDownList ddlFamilyGenderAct1 = (DropDownList)gvrow.FindControl("ddlFamilyGenderAct1");
            DropDownList ddlFamilyAdultAct1 = (DropDownList)gvrow.FindControl("ddlFamilyAdultAct1");
            TextBox txtFamilyNameAct1 = (TextBox)gvrow.FindControl("txtFamilyNameAct1");
            familyMembersActVo.RelationshipAct1 = ddlRelationshipAct1.SelectedValue;
            familyMembersActVo.FamilyNameAct1 = txtFamilyNameAct1.Text;
            familyMembersActVo.GenderAct1 = ddlFamilyGenderAct1.SelectedValue;

            familyMembersActVo.AdultAct1 = ddlFamilyAdultAct1.SelectedValue;

            lstfamilyMembersActVo.Add(familyMembersActVo);
        }
        foreach (GridViewRow gvrow in gvEmployeeNames.Rows)
        {
            EmployeesDetails employeeDetailsVo = new EmployeesDetails();

            DropDownList ddlOccupationAct1 = (DropDownList)gvrow.FindControl("ddlOccupationAct1");
            DropDownList ddlEmployeeGenderAct1 = (DropDownList)gvrow.FindControl("ddlEmployeeGenderAct1");

            TextBox txtEmployeeNameAct1 = (TextBox)gvrow.FindControl("txtEmployeeNameAct1");
            employeeDetailsVo.Occupation = ddlOccupationAct1.SelectedValue;
            employeeDetailsVo.EmployeeNameAct1 = txtEmployeeNameAct1.Text.Trim();
            employeeDetailsVo.EmployeeGenderAct1 = ddlEmployeeGenderAct1.SelectedValue;

            lstemployeeDetailsVo.Add(employeeDetailsVo);
        }
        ///////////////////act2 //////////
        labouractvo.FullNamePerAct2 = txtFullNamePermAct2.Text;
        labouractvo.PerDoorNoAct2 = txtDoorNoPermAct2.Text;
        labouractvo.PerPincode = txtPinCodePermAct2.Text;
        labouractvo.PerDistrict = ddlDistrictPermAct2.SelectedValue;
        labouractvo.PerMandal = ddlMandalPermAct2.SelectedValue;
        labouractvo.PerVillage = ddlVillagePermAct2.SelectedValue;
        labouractvo.CompletionDateAct2 = txtEstDateCompAct2.Text;
        ///////////////////act2 completed //////////
        ///////////////////act3 //////////
        labouractvo.RegActId = ddlSchemAct3.SelectedValue;
        labouractvo.LicenseRegNo = txtRegLicAct3.Text;
        labouractvo.ContractEmployeesAct4 = txtTotalContractors.Text;

        labouractvo.DirNameAct4 = txtDirFullName.Text;
        labouractvo.DirDoorNoAct4 = txtDirDoorNo.Text;
        labouractvo.DirVillageAct4 = ddlDirVillage.SelectedValue;
        labouractvo.DirMandalAct4 = ddlDirMandal.SelectedValue;
        labouractvo.DirDistrictAct4 = ddlDirDistrict.SelectedValue;
        foreach (GridViewRow gvrow in gvContractorAct4.Rows)
        {
            ContractorDetails ContractorVo = new ContractorDetails();

            TextBox txtContractor = (TextBox)gvrow.FindControl("txtContractorNameAct4");
            TextBox txtAddress = (TextBox)gvrow.FindControl("txtContractorAddressAct4");
            TextBox txtMobileNo = (TextBox)gvrow.FindControl("txtContractorMobileNoAct4");
            TextBox txtWorkNature = (TextBox)gvrow.FindControl("txtContractorNatureAct4");
            TextBox txtNoWorkmen = (TextBox)gvrow.FindControl("txtContractorMaximumNoAct4");
            TextBox txtCommenceDate = (TextBox)gvrow.FindControl("txtContractorCommenceAct4");
            TextBox txtCompleteDate = (TextBox)gvrow.FindControl("txtContractorCompAct4");
            TextBox txtManufacturingDepts = (TextBox)gvrow.FindControl("txtManufacturingDepts");
            ContractorVo.ManufacturingDepts = txtManufacturingDepts.Text;

            ContractorVo.ContractorName = txtContractor.Text;
            ContractorVo.ContractorAddress = txtAddress.Text;
            ContractorVo.ContractorMobileNo = txtMobileNo.Text;
            ContractorVo.ContractorWorkNature = txtWorkNature.Text;
            ContractorVo.ContractorWorkMen = txtNoWorkmen.Text;
            ContractorVo.ContractorCommence = txtCommenceDate.Text;
            ContractorVo.ContractorComplete = txtCompleteDate.Text;

            lstContractorVoAct4.Add(ContractorVo);
        }

        int valid = 0;

        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);




        try
        {
            osqlConnection.Open();
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_Questionnaire_Labour_CFO_ContractLic";
            com.Connection = osqlConnection;


            if (labouractvo.intCFEEnterpid == 0 || labouractvo.intCFEEnterpid == null)
                com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = labouractvo.intCFEEnterpid;


            if (labouractvo.QuestionnaireId == 0 || labouractvo.QuestionnaireId == null)
                com.Parameters.Add("@QuestionnaireId", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            if (labouractvo.Uid_No == null || labouractvo.Uid_No.ToString().Trim() == "" || labouractvo.Uid_No.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = labouractvo.Uid_No.Trim();

            if (labouractvo.Reg_Id == null || labouractvo.Reg_Id.ToString().Trim() == "" || labouractvo.Reg_Id.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = labouractvo.Reg_Id;

            if (labouractvo.LabourActId == null || labouractvo.LabourActId.ToString().Trim() == "" || labouractvo.LabourActId.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Labour_ActId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Labour_ActId", SqlDbType.VarChar).Value = labouractvo.LabourActId.Trim();
            //----------------------------
            if (labouractvo.EstClassification == null || labouractvo.EstClassification.ToString().Trim() == "" || labouractvo.EstClassification.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Estb_Classification", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Estb_Classification", SqlDbType.VarChar).Value = labouractvo.EstClassification.Trim();

            if (labouractvo.CategoryofEstablishment == null || labouractvo.CategoryofEstablishment.ToString().Trim() == "" || labouractvo.CategoryofEstablishment.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Estb_Category", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Estb_Category", SqlDbType.VarChar).Value = labouractvo.CategoryofEstablishment.Trim();
            if (labouractvo.NameofShopAct1 == null || labouractvo.NameofShopAct1.ToString().Trim() == "" || labouractvo.NameofShopAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estb_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estb_Name", SqlDbType.VarChar).Value = labouractvo.NameofShopAct1.Trim();

            if (labouractvo.ShopDoorNo == null || labouractvo.ShopDoorNo.ToString().Trim() == "" || labouractvo.ShopDoorNo.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_DoorNo", SqlDbType.VarChar).Value = labouractvo.ShopDoorNo.Trim();

            if (labouractvo.ShopLocality == null || labouractvo.ShopLocality.ToString().Trim() == "" || labouractvo.ShopLocality.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Locality", SqlDbType.VarChar).Value = labouractvo.ShopLocality.Trim();

            if (labouractvo.ShopDistrict == null || labouractvo.ShopDistrict.ToString().Trim() == "" || labouractvo.ShopDistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_District", SqlDbType.VarChar).Value = labouractvo.ShopDistrict.Trim();

            if (labouractvo.ShopMandal == null || labouractvo.ShopMandal.ToString().Trim() == "" || labouractvo.ShopMandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Mandal", SqlDbType.VarChar).Value = labouractvo.ShopMandal.Trim();

            if (labouractvo.ShopVillage == null || labouractvo.ShopVillage.ToString().Trim() == "" || labouractvo.ShopVillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_Village", SqlDbType.VarChar).Value = labouractvo.ShopVillage.Trim();
            if (labouractvo.ShopPincode == null || labouractvo.ShopPincode.ToString().Trim() == "" || labouractvo.ShopPincode.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Estd_PinCode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Estd_PinCode", SqlDbType.VarChar).Value = labouractvo.ShopPincode.Trim();

            if (labouractvo.NameofUnitAct1 == null || labouractvo.NameofUnitAct1.ToString().Trim() == "" || labouractvo.NameofUnitAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Name", SqlDbType.VarChar).Value = labouractvo.NameofUnitAct1.Trim();

            if (labouractvo.PGNameAct1 == null || labouractvo.PGNameAct1.ToString().Trim() == "" || labouractvo.PGNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Empolyer_FatherName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Empolyer_FatherName", SqlDbType.VarChar).Value = labouractvo.PGNameAct1.Trim();
            if (labouractvo.EmpDesignation == null || labouractvo.EmpDesignation.ToString().Trim() == "" || labouractvo.EmpDesignation.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Designation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Designation", SqlDbType.VarChar).Value = labouractvo.EmpDesignation.Trim();

            if (labouractvo.AgeAct1 == null || labouractvo.AgeAct1.ToString().Trim() == "" || labouractvo.AgeAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Age", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Age", SqlDbType.VarChar).Value = labouractvo.AgeAct1.Trim();

            if (labouractvo.MobileAct1 == null || labouractvo.MobileAct1.ToString().Trim() == "" || labouractvo.MobileAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_MobileNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_MobileNo", SqlDbType.VarChar).Value = labouractvo.MobileAct1.Trim();

            if (labouractvo.EmailAct1 == null || labouractvo.EmailAct1.ToString().Trim() == "" || labouractvo.EmailAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_EmailID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_EmailID", SqlDbType.VarChar).Value = labouractvo.EmailAct1.Trim();
            if (labouractvo.DoorNoResidentialAct1 == null || labouractvo.DoorNoResidentialAct1.ToString().Trim() == "" || labouractvo.DoorNoResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_DoorNo", SqlDbType.VarChar).Value = labouractvo.DoorNoResidentialAct1.Trim();
            if (labouractvo.LocalResidentialAct1 == null || labouractvo.LocalResidentialAct1.ToString().Trim() == "" || labouractvo.LocalResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Locality", SqlDbType.VarChar).Value = labouractvo.LocalResidentialAct1.Trim();

            if (labouractvo.DistrictResidentialAct1 == null || labouractvo.DistrictResidentialAct1.ToString().Trim() == "" || labouractvo.DistrictResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_District", SqlDbType.VarChar).Value = labouractvo.DistrictResidentialAct1.Trim();

            if (labouractvo.MandalResidentialAct1 == null || labouractvo.MandalResidentialAct1.ToString().Trim() == "" || labouractvo.MandalResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Mandal", SqlDbType.VarChar).Value = labouractvo.MandalResidentialAct1.Trim();

            if (labouractvo.VillageResidentialAct1 == null || labouractvo.VillageResidentialAct1.ToString().Trim() == "" || labouractvo.VillageResidentialAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Employer_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Employer_Village", SqlDbType.VarChar).Value = labouractvo.VillageResidentialAct1.Trim();

            if (labouractvo.ManagerResidenceAct1 == null || labouractvo.ManagerResidenceAct1.ToString().Trim() == "" || labouractvo.ManagerResidenceAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Agent_Flag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Agent_Flag", SqlDbType.VarChar).Value = labouractvo.ManagerResidenceAct1.Trim();

            if (labouractvo.ManagerNameAct1 == null || labouractvo.ManagerNameAct1.ToString().Trim() == "" || labouractvo.ManagerNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Name", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Name", SqlDbType.VarChar).Value = labouractvo.ManagerNameAct1.Trim();
            if (labouractvo.ManagerPGNameAct1 == null || labouractvo.ManagerPGNameAct1.ToString().Trim() == "" || labouractvo.ManagerPGNameAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_FatherName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_FatherName", SqlDbType.VarChar).Value = labouractvo.ManagerPGNameAct1.Trim();

            if (labouractvo.ManagerDesignationAct1 == null || labouractvo.ManagerDesignationAct1.ToString().Trim() == "" || labouractvo.ManagerDesignationAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Designation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Designation", SqlDbType.VarChar).Value = labouractvo.ManagerDesignationAct1.Trim();

            if (labouractvo.ManagerDoorNo == null || labouractvo.ManagerDoorNo.ToString().Trim() == "" || labouractvo.ManagerDoorNo.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_DoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_DoorNo", SqlDbType.VarChar).Value = labouractvo.ManagerDoorNo.Trim();

            if (labouractvo.ManagerLocalityAct1 == null || labouractvo.ManagerLocalityAct1.ToString().Trim() == "" || labouractvo.ManagerLocalityAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Locality", SqlDbType.VarChar).Value = labouractvo.ManagerLocalityAct1.Trim();

            if (labouractvo.ManagerDistrictAct1 == null || labouractvo.ManagerDistrictAct1.ToString().Trim() == "" || labouractvo.ManagerDistrictAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_District", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_District", SqlDbType.VarChar).Value = labouractvo.ManagerDistrictAct1.Trim();

            if (labouractvo.ManagerMandalAct1 == null || labouractvo.ManagerMandalAct1.ToString().Trim() == "" || labouractvo.ManagerMandalAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Mandal", SqlDbType.VarChar).Value = labouractvo.ManagerMandalAct1.Trim();
            if (labouractvo.ManagerVillageAct1 == null || labouractvo.ManagerVillageAct1.ToString().Trim() == "" || labouractvo.ManagerVillageAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_Manager_Village", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Manager_Village", SqlDbType.VarChar).Value = labouractvo.ManagerVillageAct1.Trim();
            if (labouractvo.NatureofBusinessAct1 == null || labouractvo.NatureofBusinessAct1.ToString().Trim() == "" || labouractvo.NatureofBusinessAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_Nature_of_Business", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_Nature_of_Business", SqlDbType.VarChar).Value = labouractvo.NatureofBusinessAct1.Trim();

            if (labouractvo.DateofCommenceAct1 == null || labouractvo.DateofCommenceAct1.ToString().Trim() == "" || labouractvo.DateofCommenceAct1.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = labouractvo.DateofCommenceAct1.Trim();

            if (labouractvo.Above18Male == null || labouractvo.Above18Male == 0)
                com.Parameters.Add("@Form1_1_Employees_Above18_Male", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_Above18_Male", SqlDbType.Int).Value = labouractvo.Above18Male;

            if (labouractvo.Above18FeMale == null || labouractvo.Above18FeMale == 0)
                com.Parameters.Add("@Form1_1_Employees_Above18_Female", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_Above18_Female", SqlDbType.Int).Value = labouractvo.Above18FeMale;

            if (labouractvo.Below18Male == null || labouractvo.Below18Male == 0)
                com.Parameters.Add("@Form1_1_Employees_14_18_Male", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_14_18_Male", SqlDbType.Int).Value = labouractvo.Below18Male;

            if (labouractvo.Below18FeMale == null || labouractvo.Below18FeMale == 0)
                com.Parameters.Add("@Form1_1_Employees_14_18_Female", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form1_1_Employees_14_18_Female", SqlDbType.Int).Value = labouractvo.Below18FeMale;

            if (labouractvo.CreatedBy == null || labouractvo.CreatedBy == 0)
                com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.Int).Value = labouractvo.CreatedBy;

            if (labouractvo.TotalAbove18 == 0 || labouractvo.TotalAbove18 == null)
                com.Parameters.Add("@TotalAbove18", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalAbove18", SqlDbType.Int).Value = labouractvo.TotalAbove18;

            if (labouractvo.TotalBelow18 == 0 || labouractvo.TotalBelow18 == null)
                com.Parameters.Add("@TotalBelow18Emps", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalBelow18Emps", SqlDbType.Int).Value = labouractvo.TotalBelow18;

            if (labouractvo.TotalEmployees == 0 || labouractvo.TotalEmployees == null)
                com.Parameters.Add("@TotalEmployees", SqlDbType.Int).Value = DBNull.Value;
            else
                com.Parameters.Add("@TotalEmployees", SqlDbType.Int).Value = labouractvo.TotalEmployees;
            //if (labouractvo.DateofCommenceAct1 != null && labouractvo.DateofCommenceAct1 != "")
            //    com.Parameters.Add("@Form1_1_DateofCommencement", SqlDbType.VarChar).Value = labouractvo.DateofCommenceAct1.Trim();
            com.Parameters.Add("@Created_User", SqlDbType.VarChar).Value = labouractvo.CreatedUser;

            if (labouractvo.FullNamePerAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_FullName", labouractvo.FullNamePerAct2);
            if (labouractvo.PerDoorNoAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_Per_DoorNo", labouractvo.PerDoorNoAct2);
            if (labouractvo.PerVillage != null)
                com.Parameters.AddWithValue("@Form1_2_Per_Village", labouractvo.PerVillage);
            if (labouractvo.PerMandal != null)
                com.Parameters.AddWithValue("@Form1_2_Per_Mandal", labouractvo.PerMandal);
            if (labouractvo.PerDistrict != null)
                com.Parameters.AddWithValue("@Form1_2_Per_District", labouractvo.PerDistrict);
            if (labouractvo.PerPincode != null)
                com.Parameters.AddWithValue("@Form1_2_Per_PinCode", labouractvo.PerPincode);
            if (labouractvo.CompletionDateAct2 != "" && labouractvo.CompletionDateAct2 != null)
                com.Parameters.AddWithValue("@Form1_2_Est_Compltd_Dt", cmf.convertDateIndia(labouractvo.CompletionDateAct2));
            if (labouractvo.ManagerMobileNo != null)
                com.Parameters.AddWithValue("@Form1_Manager_MobileNo", labouractvo.ManagerMobileNo);
            if (labouractvo.ManagerEmail != null)
                com.Parameters.AddWithValue("@Form1_Manager_EMail", labouractvo.ManagerEmail);

            if (labouractvo.RegActId != null)
                com.Parameters.AddWithValue("@Form1_3_Registered_Act", labouractvo.RegActId);
            if (labouractvo.LicenseRegNo != null)
                com.Parameters.AddWithValue("@Form1_3_Reg_Lic", labouractvo.LicenseRegNo);

            if (labouractvo.DirNameAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_FullName", labouractvo.DirNameAct4);
            if (labouractvo.DirDoorNoAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_DoorNo", labouractvo.DirDoorNoAct4);
            if (labouractvo.DirVillageAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_Village", labouractvo.DirVillageAct4);
            if (labouractvo.DirMandalAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_Mandal", labouractvo.DirMandalAct4);
            if (labouractvo.DirDistrictAct4 != null)
                com.Parameters.AddWithValue("@Form1_4_Dir_District", labouractvo.DirDistrictAct4);

            if (oLabourActVO_ContraactLicense.chkZone1 == null || oLabourActVO_ContraactLicense.chkZone1 == "0")
                com.Parameters.Add("@chkZone1", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@chkZone1", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.chkZone1;

            if (oLabourActVO_ContraactLicense.chkZone2 == null || oLabourActVO_ContraactLicense.chkZone2 == "0")
                com.Parameters.Add("@chkZone2", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@chkZone2", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.chkZone2;

            if (oLabourActVO_ContraactLicense.chkZone3 == null || oLabourActVO_ContraactLicense.chkZone3 == "0")
                com.Parameters.Add("@chkZone3", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@chkZone3", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.chkZone3;

            if (oLabourActVO_ContraactLicense.ContAddPincode_contract == null || oLabourActVO_ContraactLicense.ContAddPincode_contract == "0")
                com.Parameters.Add("@ContAddPincode_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ContAddPincode_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.ContAddPincode_contract;


            if (oLabourActVO_ContraactLicense.ContLocality_contract == null || oLabourActVO_ContraactLicense.ContLocality_contract == "0")
                com.Parameters.Add("@ContLocality_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ContLocality_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.ContLocality_contract;

            if (oLabourActVO_ContraactLicense.ContOutsideLoc_contract == null || oLabourActVO_ContraactLicense.ContOutsideLoc_contract == "0")
                com.Parameters.Add("@ContOutsideLoc_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ContOutsideLoc_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.ContOutsideLoc_contract;

            if (oLabourActVO_ContraactLicense.NameofContractor_contLic == null || oLabourActVO_ContraactLicense.NameofContractor_contLic == "0")
                com.Parameters.Add("@NameofContractor_contLic", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@NameofContractor_contLic", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.NameofContractor_contLic;

            if (oLabourActVO_ContraactLicense.DropDownList7_contLic == null || oLabourActVO_ContraactLicense.DropDownList7_contLic == "0")
                com.Parameters.Add("@DropDownList7_contLic", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DropDownList7_contLic", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DropDownList7_contLic;

            if (oLabourActVO_ContraactLicense.DropDownList8_contLic == null || oLabourActVO_ContraactLicense.DropDownList8_contLic == "0")
                com.Parameters.Add("@DropDownList8_contLic", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DropDownList8_contLic", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DropDownList8_contLic;


            if (oLabourActVO_ContraactLicense.DropDownList9_contLic == null || oLabourActVO_ContraactLicense.DropDownList9_contLic == "0")
                com.Parameters.Add("@DropDownList9_contLic", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DropDownList9_contLic", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DropDownList9_contLic;


            if (oLabourActVO_ContraactLicense.ContrEmail_contract == null || oLabourActVO_ContraactLicense.ContrEmail_contract == "0")
                com.Parameters.Add("@ContrEmail_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ContrEmail_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.ContrEmail_contract;


            if (oLabourActVO_ContraactLicense.ContrMobile_contract == null || oLabourActVO_ContraactLicense.ContrMobile_contract == "0")
                com.Parameters.Add("@ContrMobile_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ContrMobile_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.ContrMobile_contract;


            if (oLabourActVO_ContraactLicense.MaxoEmployees_contract == null || oLabourActVO_ContraactLicense.MaxoEmployees_contract == "0")
                com.Parameters.Add("@MaxoEmployees_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MaxoEmployees_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.MaxoEmployees_contract;

            if (oLabourActVO_ContraactLicense.contractConvict_contract == null || oLabourActVO_ContraactLicense.contractConvict_contract == "0")
                com.Parameters.Add("@contractConvict_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@contractConvict_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.contractConvict_contract;


            if (oLabourActVO_ContraactLicense.contractSuspend_contract == null || oLabourActVO_ContraactLicense.contractSuspend_contract == "0")
                com.Parameters.Add("@contractSuspend_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@contractSuspend_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.contractSuspend_contract;


            if (oLabourActVO_ContraactLicense.rblcontractEst_contract == null || oLabourActVO_ContraactLicense.rblcontractEst_contract == "0")
                com.Parameters.Add("@rblcontractEst_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@rblcontractEst_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.rblcontractEst_contract;


            if (oLabourActVO_ContraactLicense.StartDate_duration_contract == null || oLabourActVO_ContraactLicense.StartDate_duration_contract == "0")
                com.Parameters.Add("@StartDate_duration_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@StartDate_duration_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.StartDate_duration_contract;


            if (oLabourActVO_ContraactLicense.EndDate_duration_contract == null || oLabourActVO_ContraactLicense.EndDate_duration_contract == "0")
                com.Parameters.Add("@EndDate_duration_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@EndDate_duration_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.EndDate_duration_contract;



            if (oLabourActVO_ContraactLicense.txtDOB_contract == null || oLabourActVO_ContraactLicense.txtDOB_contract == "0")
                com.Parameters.Add("@txtDOB_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@txtDOB_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.txtDOB_contract;

            if (oLabourActVO_ContraactLicense.PartEstablNumber_contract == null || oLabourActVO_ContraactLicense.PartEstablNumber_contract == "0")
                com.Parameters.Add("@PartEstablNumber_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PartEstablNumber_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.PartEstablNumber_contract;

            if (oLabourActVO_ContraactLicense.PartEstablDate_contract == null || oLabourActVO_ContraactLicense.PartEstablDate_contract == "0")
                com.Parameters.Add("@PartEstablDate_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PartEstablDate_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.PartEstablDate_contract;


            if (oLabourActVO_ContraactLicense.PrinEmployPincode_contract == null || oLabourActVO_ContraactLicense.PrinEmployPincode_contract == "0")
                com.Parameters.Add("@PrinEmployPincode_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PrinEmployPincode_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.PrinEmployPincode_contract;

            if (oLabourActVO_ContraactLicense.DistPrinEmploy_contract == null || oLabourActVO_ContraactLicense.DistPrinEmploy_contract == "0")
                com.Parameters.Add("@DistPrinEmploy_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DistPrinEmploy_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DistPrinEmploy_contract;

            if (oLabourActVO_ContraactLicense.MandalPrinEmploy_contract == null || oLabourActVO_ContraactLicense.MandalPrinEmploy_contract == "0")
                com.Parameters.Add("@MandalPrinEmploy_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MandalPrinEmploy_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.MandalPrinEmploy_contract;

            if (oLabourActVO_ContraactLicense.VillagePrinEmploy_contract == null || oLabourActVO_ContraactLicense.VillagePrinEmploy_contract == "0")
                com.Parameters.Add("@VillagePrinEmploy_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@VillagePrinEmploy_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.VillagePrinEmploy_contract;

            if (oLabourActVO_ContraactLicense.NamePrinEmploy_contract == null || oLabourActVO_ContraactLicense.NamePrinEmploy_contract == "0")
                com.Parameters.Add("@NamePrinEmploy_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@NamePrinEmploy_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.NamePrinEmploy_contract;


            if (oLabourActVO_ContraactLicense.DoornoPrinEmploy_contract == null || oLabourActVO_ContraactLicense.DoornoPrinEmploy_contract == "0")
                com.Parameters.Add("@DoornoPrinEmploy_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DoornoPrinEmploy_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DoornoPrinEmploy_contract;


            if (oLabourActVO_ContraactLicense.PrinEmploytxtOtherStateAddr_contract == null || oLabourActVO_ContraactLicense.PrinEmploytxtOtherStateAddr_contract == "0")
                com.Parameters.Add("@PrinEmploytxtOtherStateAddr_contract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PrinEmploytxtOtherStateAddr_contract", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.PrinEmploytxtOtherStateAddr_contract;

            if (oLabourActVO_ContraactLicense.Nameofagentormanager == null || oLabourActVO_ContraactLicense.Nameofagentormanager == "")
                com.Parameters.Add("@AgentorManagerName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerName", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.Nameofagentormanager;


            if (oLabourActVO_ContraactLicense.DirDoorNoofagentormanager == null || oLabourActVO_ContraactLicense.DirDoorNoofagentormanager == "")
                com.Parameters.Add("@AgentorManagerDoorNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerDoorNo", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirDoorNoofagentormanager;

            if (oLabourActVO_ContraactLicense.DirLocalityofagentormanager == null || oLabourActVO_ContraactLicense.DirLocalityofagentormanager == "")
                com.Parameters.Add("@AgentorManagerLocality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerLocality", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirLocalityofagentormanager;

            if (oLabourActVO_ContraactLicense.DirAddressofagentormanager == null || oLabourActVO_ContraactLicense.DirAddressofagentormanager == "")
                com.Parameters.Add("@AgentorManagerAddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerAddress", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirAddressofagentormanager;





            if (oLabourActVO_ContraactLicense.DirDistrictofagentormanager == null || oLabourActVO_ContraactLicense.DirDistrictofagentormanager == "0")
                com.Parameters.Add("@AgentorManagerDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerDistrict", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirDistrictofagentormanager;

            if (oLabourActVO_ContraactLicense.DirMandalofagentormanager == null || oLabourActVO_ContraactLicense.DirMandalofagentormanager == "0")
                com.Parameters.Add("@AgentorManagerMandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerMandal", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirMandalofagentormanager;

            if (oLabourActVO_ContraactLicense.DirVillageofagentormanager == null || oLabourActVO_ContraactLicense.DirVillageofagentormanager == "0")
                com.Parameters.Add("@AgentorManagerVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerVillage", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirVillageofagentormanager;

            if (oLabourActVO_ContraactLicense.DirPincodeofagentormanager == null || oLabourActVO_ContraactLicense.DirPincodeofagentormanager == "")
                com.Parameters.Add("@AgentorManagerPincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerPincode", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.DirPincodeofagentormanager;

            if (oLabourActVO_ContraactLicense.Age == null || oLabourActVO_ContraactLicense.Age == "")
                com.Parameters.Add("@AgentorManagerAge", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AgentorManagerAge", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.Age;

            if (oLabourActVO_ContraactLicense.SecurityDepositPaid.IsBlankOrNull())

                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_Amountpaid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_Amountpaid", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.SecurityDepositPaid;


            if (oLabourActVO_ContraactLicense.SecurityDepositPayable.IsBlankOrNull())

                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_Amountpayable", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_Amountpayable", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.SecurityDepositPayable;


            if (oLabourActVO_ContraactLicense.SecurityDepositChallanNo.IsBlankOrNull())

                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_ChallanNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_ChallanNo", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.SecurityDepositChallanNo;


            if (oLabourActVO_ContraactLicense.SecurityDepositChallanDate.IsBlankOrNull())

                com.Parameters.Add("@SecurityDepositChallanDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@SecurityDepositChallanDate", SqlDbType.DateTime).Value = oLabourActVO_ContraactLicense.SecurityDepositChallanDate;



            if (oLabourActVO_ContraactLicense.SecurityDepositChallanFilename.IsBlankOrNull())
                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_ChallanFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Form_1_5_Contractor_SecurityDe_ChallanFileName", SqlDbType.VarChar).Value = oLabourActVO_ContraactLicense.SecurityDepositChallanFilename;

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            //FamilyMembersAct1
            //EmployeeDetails
            // object returnvalue = com.ExecuteScalar();
            com.ExecuteNonQuery();
            //if (returnvalue == DBNull.Value || returnvalue == null)
            //    return 0;
            //else
            //    return Convert.ToInt32(returnvalue);

            valid = (Int32)com.Parameters["@Valid"].Value;

            SqlCommand cmdDelWorkPlace = new SqlCommand("[USP_DEL_Godown_Labour_CFO]", osqlConnection);
            cmdDelWorkPlace.CommandType = CommandType.StoredProcedure;

            cmdDelWorkPlace.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelWorkPlace.ExecuteNonQuery();

            foreach (LabourWorkPlace workplacevo in lstworkplaceVo)
            {
                SqlCommand cmdEnj = new SqlCommand("[USP_INS_Godown_Labour_CFO]", osqlConnection);
                cmdEnj.CommandType = CommandType.StoredProcedure;


                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (workplacevo.WorkPlace != null)
                    cmdEnj.Parameters.AddWithValue("@Work_Place", workplacevo.WorkPlace);
                if (workplacevo.DoorNo != null)
                    cmdEnj.Parameters.AddWithValue("@Door_No", workplacevo.DoorNo);

                if (workplacevo.Locality != null && workplacevo.Locality != "")
                    cmdEnj.Parameters.AddWithValue("@Locality", workplacevo.Locality);
                cmdEnj.ExecuteNonQuery();
            }
            SqlCommand cmdDelFamilyMembers = new SqlCommand("[USP_DEL_Family_Member_Labour_CFO]", osqlConnection);
            cmdDelFamilyMembers.CommandType = CommandType.StoredProcedure;

            cmdDelFamilyMembers.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelFamilyMembers.ExecuteNonQuery();

            foreach (FamilyMembersAct1 familyvo in lstfamilyMembersActVo)
            {
                SqlCommand cmdInsFamily = new SqlCommand("[USP_INS_Family_Member_Labour_CFO]", osqlConnection);
                cmdInsFamily.CommandType = CommandType.StoredProcedure;


                //SqlDataAdapter da1 = new SqlDataAdapter(cmdInsFamily);
                cmdInsFamily.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (familyvo.FamilyNameAct1 != null)
                    cmdInsFamily.Parameters.AddWithValue("@Name", familyvo.FamilyNameAct1);
                if (familyvo.RelationshipAct1 != null)
                    cmdInsFamily.Parameters.AddWithValue("@RelationShip", familyvo.RelationshipAct1);

                if (familyvo.GenderAct1 != null && familyvo.GenderAct1 != "")
                    cmdInsFamily.Parameters.AddWithValue("@Gender", familyvo.GenderAct1);
                if (familyvo.AdultAct1 != null && familyvo.AdultAct1 != "")
                    cmdInsFamily.Parameters.AddWithValue("@Adult_Flag", familyvo.AdultAct1);
                cmdInsFamily.ExecuteNonQuery();
            }
            SqlCommand cmdDelEmp = new SqlCommand("[USP_DEL_Employees_Labour_CFO]", osqlConnection);
            cmdDelEmp.CommandType = CommandType.StoredProcedure;

            cmdDelEmp.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelEmp.ExecuteNonQuery();

            foreach (EmployeesDetails empvo in lstemployeeDetailsVo)
            {
                SqlCommand cmdInsEmp = new SqlCommand("[USP_INS_Employees_Labour_CFO]", osqlConnection);
                cmdInsEmp.CommandType = CommandType.StoredProcedure;


                //SqlDataAdapter da1 = new SqlDataAdapter(cmdInsEmp);
                cmdInsEmp.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (empvo.Occupation != null)
                    cmdInsEmp.Parameters.AddWithValue("@Occupation", empvo.Occupation);
                if (empvo.EmployeeNameAct1 != null)
                    cmdInsEmp.Parameters.AddWithValue("@Name", empvo.EmployeeNameAct1);
                if (empvo.EmployeeGenderAct1 != null && empvo.EmployeeGenderAct1 != "")
                    cmdInsEmp.Parameters.AddWithValue("@Gender", empvo.EmployeeGenderAct1);

                cmdInsEmp.ExecuteNonQuery();
            }
            SqlCommand cmdDelContractor = new SqlCommand("[USP_DEL_Contractor_Workmen_Labour_CFO]", osqlConnection);
            cmdDelContractor.CommandType = CommandType.StoredProcedure;

            cmdDelContractor.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
            cmdDelContractor.ExecuteNonQuery();

            foreach (ContractorDetails Contractorvo in lstContractorVoAct3)
            {
                SqlCommand cmdEnj = new SqlCommand("[USP_INS_Contractor_Workmen_Labour_CFO]", osqlConnection);
                cmdEnj.CommandType = CommandType.StoredProcedure;


                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (Contractorvo.ContractorName != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Name", Contractorvo.ContractorName);
                if (Contractorvo.ContractorAddress != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Address", Contractorvo.ContractorAddress);
                if (Contractorvo.ContractorMobileNo != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MobileNo", Contractorvo.ContractorMobileNo);
                if (Contractorvo.ContractorWorkNature != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Work_Nature", Contractorvo.ContractorWorkNature);
                if (Contractorvo.ContractorWorkMen != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MaxWorkers", Contractorvo.ContractorWorkMen);
                if (Contractorvo.ContractorCommence != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Commence_Dt", Contractorvo.ContractorCommence);
                if (Contractorvo.ContractorComplete != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Compltd_Dt", Contractorvo.ContractorComplete);
                if (Contractorvo.ManufacturingDepts != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_ManufacturingDepts", Contractorvo.ManufacturingDepts);
                cmdEnj.ExecuteNonQuery();
            }
            foreach (ContractorDetails Contractorvo in lstContractorVoAct4)
            {
                SqlCommand cmdEnj = new SqlCommand("[USP_INS_Contractor_Workmen_Labour_CFO]", osqlConnection);
                cmdEnj.CommandType = CommandType.StoredProcedure;


                cmdEnj.Parameters.AddWithValue("@QuestionnaireId", SqlDbType.Int).Value = labouractvo.QuestionnaireId;
                if (Contractorvo.ContractorName != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Name", Contractorvo.ContractorName);
                if (Contractorvo.ContractorAddress != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Address", Contractorvo.ContractorAddress);
                if (Contractorvo.ContractorMobileNo != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MobileNo", Contractorvo.ContractorMobileNo);
                if (Contractorvo.ContractorWorkNature != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Work_Nature", Contractorvo.ContractorWorkNature);
                if (Contractorvo.ContractorWorkMen != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_MaxWorkers", Contractorvo.ContractorWorkMen);
                if (Contractorvo.ContractorCommence != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Commence_Dt", Contractorvo.ContractorCommence);
                if (Contractorvo.ContractorComplete != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_Est_Compltd_Dt", Contractorvo.ContractorComplete);
                if (Contractorvo.ManufacturingDepts != null)
                    cmdEnj.Parameters.AddWithValue("@Contractor_ManufacturingDepts", Contractorvo.ManufacturingDepts);
                cmdEnj.ExecuteNonQuery();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            osqlConnection.Close();

        }


        return valid;
    }




    protected void btnNext_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }
        //int valid = 0;
        //labouractvo.
        if (gvWorkerDtls.Visible == true)
        {
            if (gvWorkerDtls.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>Please enter Worker Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
                // return;
            }
        }
        if (gvFamilyMembersAct1.Visible == true)
        {
            if (gvFamilyMembersAct1.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter family members of the Employees Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
                // return;
            }
        }
        if (gvEmployeeNames.Visible == true)
        {
            if (gvEmployeeNames.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Employees Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
                // return;
            }
        }
        if (gvContractorAct4.Visible == true)
        {
            if (gvContractorAct4.Rows.Count < 2)
            {
                lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Please enter Contractor and migrant workmen Details..!</font>";
                lblmsg0.Visible = true;
                success.Visible = false;
                Failure.Visible = true;
                return;
                // return;
            }
        }

        if (trteluguboard.Visible)
        {
            if (LabelTeluguBoard.Text == "")
            {
                FileTeluguBoard.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Telugu Board Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (ddlEstClassification.SelectedValue == "0")
            {
                lblmsg0.Text = "<font color='red'>Please Select Classification of Establishment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                ddlEstClassification.Enabled = true;
                return;
            }
            if (ddlCategoryofEstablishment.SelectedValue == "0")
            {
                lblmsg0.Text = "<font color='red'>Please Select Category of Establishment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                ddlCategoryofEstablishment.Enabled = true;
                return;
            }
        }
        if (tridproof.Visible)
        {
            if (Labelidproof.Text == "")
            {
                FileUploadidproof.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Id proof of Employer..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (trphoto.Visible)
        {
            if (Labelphoto.Text == "")
            {
                FileUploadphoto.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Passport Size of Employee..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (trrenetaldeed.Visible)
        {
            if (Labelrenetaldeed.Text == "")
            {
                FileUploadrenetaldeed.Enabled = true;
                lblmsg0.Text = "<font color='red'>Please Upload Rental Deed/Sale Deed/Ownership Proof..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
        {
            if (trMemorandum.Visible)
            {
                if (LabelMemorandum.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Memorandum of Articles..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trincorportaion.Visible)
            {
                if (Labelincorportaion.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Certification of Incorporation..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
        }
        //if (Convert.ToInt32(txtAbove18Female.Text.Trim()) + Convert.ToInt32(txtAbove18Male.Text.Trim()) + Convert.ToInt32(txtBelow18FeMale.Text.Trim()) + Convert.ToInt32(txtBelow18Male.Text.Trim()) != Convert.ToInt32(txtTotalEmployees.Text.Trim()))
        //{
        //    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Total of Adults and Young persons should be equal to total number of Employees..!</font>";
        //    lblmsg0.Visible = true;
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    //valid = 1;
        //    return;
        //}
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

        //txtTotalEmployees.Text = totalEmp.ToString();
        //txtTotalAbove18.Text = totalAbove18Emp.ToString();
        //txtTotalBelow18.Text = totalBelow18Emp.ToString();

        //commentedbyrajinikar
        //if (Convert.ToInt32(txtTotalEmployees.Text.Trim()) != Convert.ToInt32(totalEmp))
        //{
        //    lblmsg0.Text = "<font color='red'>" + lblmsg0.Text + "," + "</br>Total of Adults and Young persons should be equal to total number of Employees..!</font>";
        //    lblmsg0.Visible = true;
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    //valid = 1;
        //    return;
        //}
        if (btnNext.Text == "Next")
        {
            DataSet ds = new DataSet();
            //Response.Write(hdfFlagID0.Value.ToString());
            //return;
            //ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            int valid = 0;
            valid = SaveLabourDetails_Contract();

            // Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
            // Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
            Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

            //ResetFormControl(this);
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
            //this.Clear();
            success.Visible = true;
            Failure.Visible = false;
            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
            //fillNews(userid);

        }

    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
    }
    protected void ddlDistrictPermAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDistrictPermAct2, ddlMandalPermAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlMandalPermAct2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandalPermAct2, ddlVillagePermAct2);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    public void BindRegisteredActs()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlSchemAct3.Items.Clear();
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            dsd = Gen.getLabourRegisteredActs(hdfFlagID0.Value.ToString(), QuestionnaireId);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlSchemAct3.DataSource = dsd.Tables[0];
                ddlSchemAct3.DataValueField = "Application_Id";
                ddlSchemAct3.DataTextField = "Application_Name";
                ddlSchemAct3.DataBind();
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlSchemAct3.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }



    protected DataTable BindContractorAct3GridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");
        dt.Columns.Add("Contractor_Address");
        dt.Columns.Add("Contractor_Work_Nature");
        dt.Columns.Add("Contractor_ManufacturingDepts");
        dt.Columns.Add("Contractor_Est_Commence_Dt");
        dt.Columns.Add("Contractor_MaxWorkers");
        dt.Columns.Add("Contractor_Est_Compltd_Dt");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";

        dt.Rows.Add(dr);
        return dt;
    }

    protected void gvContractorAct4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindContractorGridAdd();

                TextBox txtContractor;
                TextBox txtAddress;
                TextBox txtMobileNo;
                TextBox txtWorkNature;
                TextBox txtNoWorkmen;
                TextBox txtCommenceDate;
                TextBox txtCompleteDate;
                TextBox txtManufacturingDepts;

                String[] arraydata = new String[8];

                int gvrcnt = gvContractorAct4.Rows.Count;

                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvr = gvContractorAct4.Rows[i];
                    txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                    arraydata[0] = txtContractor.Text;
                    txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                    arraydata[1] = txtAddress.Text;
                    txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                    arraydata[2] = txtMobileNo.Text;
                    txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                    arraydata[3] = txtWorkNature.Text;
                    txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                    arraydata[4] = txtNoWorkmen.Text;
                    txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                    arraydata[5] = txtCommenceDate.Text;
                    txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                    arraydata[6] = txtCompleteDate.Text;
                    txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
                    arraydata[7] = txtManufacturingDepts.Text;

                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtContractorDtls4"] = dt;
                    gvContractorAct4.DataSource = dt;
                    gvContractorAct4.DataBind();
                }
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvContractorAct4.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindContractorGridAdd();
                    String[] arraydata = new String[8];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            TextBox txtContractor;
                            TextBox txtAddress;
                            TextBox txtMobileNo;
                            TextBox txtWorkNature;
                            TextBox txtNoWorkmen;
                            TextBox txtCommenceDate;
                            TextBox txtCompleteDate;
                            TextBox txtManufacturingDepts;

                            GridViewRow gvr = gvContractorAct4.Rows[i];
                            txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                            arraydata[0] = txtContractor.Text;
                            txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                            arraydata[1] = txtAddress.Text;
                            txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                            arraydata[2] = txtMobileNo.Text;
                            txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                            arraydata[3] = txtWorkNature.Text;
                            txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                            arraydata[4] = txtNoWorkmen.Text;
                            txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                            arraydata[5] = txtCommenceDate.Text;
                            txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                            arraydata[6] = txtCompleteDate.Text;
                            txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
                            arraydata[7] = txtManufacturingDepts.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtContractorDtls4"] = dt;
                    gvContractorAct4.DataSource = dt;
                    gvContractorAct4.DataBind();
                }
                else
                {
                    lblmsg.Text = "Cannot remove the details, Please modify";
                    lblmsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvContractorAct4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtContractorDtls4"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvr = e.Row;
                        TextBox txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
                        TextBox txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
                        TextBox txtMobileNo = (TextBox)gvr.FindControl("txtContractorMobileNoAct4");
                        TextBox txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
                        TextBox txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
                        TextBox txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
                        TextBox txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
                        TextBox txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");

                        txtContractor.Text = dt.Rows[e.Row.RowIndex]["Contractor_Name"].ToString();
                        txtAddress.Text = dt.Rows[e.Row.RowIndex]["Contractor_Address"].ToString();
                        txtMobileNo.Text = dt.Rows[e.Row.RowIndex]["Contractor_MobileNo"].ToString();
                        txtWorkNature.Text = dt.Rows[e.Row.RowIndex]["Contractor_Work_Nature"].ToString();
                        txtNoWorkmen.Text = dt.Rows[e.Row.RowIndex]["Contractor_MaxWorkers"].ToString();
                        // txtCommenceDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString();
                        // txtCompleteDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString();
                        if (dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString() != null && dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString() != "")
                        {
                            txtCommenceDate.Text = Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString()).ToString("yyyy-MM-dd");
                        }
                        if (dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString() != null && dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString() != "")
                        {
                            txtCompleteDate.Text = Convert.ToDateTime(dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString()).ToString("yyyy-MM-dd");
                        }
                        txtManufacturingDepts.Text = dt.Rows[e.Row.RowIndex]["Contractor_ManufacturingDepts"].ToString();

                        if (txtNoWorkmen.Text.Trim() != "")
                        {
                            totalContractEmployees = totalContractEmployees + Convert.ToInt32(txtNoWorkmen.Text.Trim());
                        }
                    }
                }
                txtTotalContractors.Text = totalContractEmployees.ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlDirDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlDirDistrict, ddlDirMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected DataTable BindContractorGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");
        dt.Columns.Add("Contractor_Address");
        dt.Columns.Add("Contractor_MobileNo");
        dt.Columns.Add("Contractor_Work_Nature");
        dt.Columns.Add("Contractor_MaxWorkers");
        dt.Columns.Add("Contractor_Est_Commence_Dt");
        dt.Columns.Add("Contractor_Est_Compltd_Dt");
        dt.Columns.Add("Contractor_ManufacturingDepts");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";
        dr[6] = "";
        dr[7] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected void ddlDirMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlDirMandal, ddlDirVillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void ddlSchemAct3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected DataTable BindContractorGridAct3()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Contractor_Name");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    protected void GetTotalWorkMan(object sender, EventArgs e)
    {
        GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;
        TextBox txtContractorMaximumNoAct4 = (TextBox)gvrow.FindControl("txtContractorMaximumNoAct4");
        int gvrcnt = gvContractorAct4.Rows.Count;

        for (int i = 0; i < gvrcnt; i++)
        {
            GridViewRow gvr = gvContractorAct4.Rows[i];
            TextBox txtNoWorkmen;

            txtNoWorkmen = (TextBox)gvr.FindControl("txtContractorMaximumNoAct4");
            if (txtNoWorkmen.Text.Trim() != "")
            {
                totalContractEmployees = totalContractEmployees + Convert.ToInt32(txtNoWorkmen.Text.Trim());
            }
        }
        txtTotalContractors.Text = totalContractEmployees.ToString();
    }

    protected void btnsubmitform_Click(object sender, EventArgs e)
    {
        int valid = 0;
        valid = SaveLabourDetails_Contract();
        string intApprovalid = Request.QueryString["intApprovalid"].ToString();
        Callwebservice(intApprovalid);
        lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        //this.Clear();
        success.Visible = true;
        Failure.Visible = false;
    }
    public void Callwebservice(string deptid)
    {
        LabourQueryResponseCFO.TSLabourServiceImplService labourserviceCfo = new LabourQueryResponseCFO.TSLabourServiceImplService();
        string UIDNO = "";
        DataSet dsdatanew = new DataSet();
        dsdatanew = (DataSet)Session["dscheck"];
        if (dsdatanew != null && dsdatanew.Tables.Count > 1 && dsdatanew.Tables[1].Rows.Count > 0)
        {
            UIDNO = dsdatanew.Tables[1].Rows[0]["UID_No"].ToString();
        }

        if (deptid == "52")// if (deptid == "48")  // shops and establishment
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            dsdept = Gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();

            LabourQueryResponseCFO.shopsEstRegistrations shopactobjnew = new LabourQueryResponseCFO.shopsEstRegistrations();


            //LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
            //LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
            //LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
            //LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

            string actids = "";
            string actid = "";
            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
            string[] split = actids.Split(',');
            if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
            {
                // labouract.buildingRegistrationActSelected = true;
                labouract.shopRegistrationActSelected = true;
                shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                //shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                //shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                //shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                //shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                //shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                //shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                //  shopactobjnew.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                //   shopactobjnew.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                //   shopactobjnew.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                //  shopactobjnew.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                //   shopactobjnew.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                //   shopactobjnew.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                // shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                // shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                // shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                //shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                //shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                //shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                //shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                //shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                //shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                //shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                //shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                //shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                //shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                //shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                //shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //shopactobjnew.transaction_status = "Y";
                //shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                //shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                // shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                // shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                // shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                shopactobjnew.establishment_category = "1";
                shopactobjnew.establishment_classification = "1";

                //  labouract.buildingRegistrationActData = labour;

                LabourQueryResponseCFO.shopActsWorkPlaceMultiData[] shopactobj = null;

                if (dsdept.Tables[1].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdept.Tables[1];
                    shopactobj = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                    for (int k = 0; k < dtraw.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsWorkPlaceMultiData workplacevo = new LabourQueryResponseCFO.shopActsWorkPlaceMultiData();
                        workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                        workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                        workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                        shopactobj[k] = workplacevo;
                    }
                    shopactobjnew.workPlaceDetails = shopactobj;
                }

                LabourQueryResponseCFO.shopActsEmployeesMultiData[] shopactobj1 = null;
                if (dsdept.Tables[2].Rows.Count > 0)
                {
                    DataTable dtraw2 = new DataTable();
                    dtraw2 = dsdept.Tables[2];
                    shopactobj1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                    for (int k = 0; k < dtraw2.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsEmployeesMultiData workplacevo1 = new LabourQueryResponseCFO.shopActsEmployeesMultiData();
                        workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                        workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                        workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                        shopactobj1[k] = workplacevo1;
                    }
                    shopactobjnew.employeesDetails = shopactobj1;
                }


                LabourQueryResponseCFO.shopActsFamilyMultiData[] shopactobj3 = null;

                if (dsdept.Tables[3].Rows.Count > 0)
                {
                    DataTable dtraw3 = new DataTable();
                    dtraw3 = dsdept.Tables[3];
                    shopactobj3 = new LabourQueryResponseCFO.shopActsFamilyMultiData[dtraw3.Rows.Count];

                    for (int k = 0; k < dtraw3.Rows.Count; k++)
                    {
                        LabourQueryResponseCFO.shopActsFamilyMultiData workplacevo3 = new LabourQueryResponseCFO.shopActsFamilyMultiData();
                        workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                        workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                        workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                        workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                        shopactobj3[k] = workplacevo3;
                    }
                    shopactobjnew.familyDetails = shopactobj3;
                }
                DataSet dsdeptattachmentslabour = new DataSet();
                dsdeptattachmentslabour = Gen.getattachmentdetailsonuidCFO(UIDNO, "52", "");
                if (dsdeptattachmentslabour != null && dsdeptattachmentslabour.Tables.Count > 0 && dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                {
                    ///PAN CARD////

                    if (dsdeptattachmentslabour.Tables[0].Rows.Count > 0)
                    {
                        shopactobjnew.employees_proof = dsdeptattachmentslabour.Tables[0].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[1].Rows.Count > 0)
                    {
                        shopactobjnew.address_proof = dsdeptattachmentslabour.Tables[1].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[2].Rows.Count > 0)
                    {
                        shopactobjnew.authorise_letter_proof = dsdeptattachmentslabour.Tables[2].Rows[0]["Filepath"].ToString();
                    }
                    if (dsdeptattachmentslabour.Tables[3].Rows.Count > 0)
                    {
                        shopactobjnew.certificate_incorporation_proof = dsdeptattachmentslabour.Tables[3].Rows[0]["Filepath"].ToString();
                    }
                }
                labouract.shopRegistrationActData = shopactobjnew;
                labourout = labourserviceCfo.actSelected(labouract);

                // labourout = labourserviceCfo.actSelected(labouract);
                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                    // Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    // updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                    //  Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                }
            }
        }
        if (deptid == "50") // contract labour
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            dsdept = Gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
            // LabourQueryResponseCFO.buildingotherconstructions labour = new LabourQueryResponseCFO.buildingotherconstructions();
            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();
            LabourQueryResponseCFO.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFO.contractLabourPrincipalEmployer();
            LabourQueryResponseCFO.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFO.ismwPrincipalEmployer();



            string actids = "";
            string actid = "";
            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
            string[] split = actids.Split(',');
            if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
            {

                labouract.contractLabourPrincipalEmplyerActSelected = true;
                contractvo.actID = "CPF";
                //contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                //contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                //contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                //contractvo.compound_fee = 0;
                contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                // contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
               // contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString() == "--District--")
                {
                    contractvo.manager_agent_district = "";
                }
                else
                {
                    contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                }
                contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                //contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString() == "--Mandal--")
                {
                    contractvo.manager_agent_mandal = "";
                }
                else
                {
                    contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                }
                contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                //contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString() == "--Village--")
                {
                    contractvo.manager_agent_village = "";
                }
                else
                {
                    contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                }
                //  contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                contractvo.other_attachments_1 = "";
                contractvo.other_attachments_2 = "";
                //contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                //contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                //contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                //contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                //contractvo.previous_registered_act = dsdept.Tables[0].Rows[0][""].ToString();
                //contractvo.previous_registration_certificate = dsdept.Tables[0].Rows[0][""].ToString();
                //contractvo.previous_registration_no = dsdept.Tables[0].Rows[0][""].ToString();
                contractvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                contractvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                contractvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                contractvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                contractvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                contractvo.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                contractvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                contractvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                contractvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                //contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                //contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //contractvo.registration_years = 0;
                contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                //contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                //contractvo.total_penality_amount = 0;
                //contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                //contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                //contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                //contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                //contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                //contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                //contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                //contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                //contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                //contractvo.contractorParticulars[] lstitem = null;
                ContractorDetails co = new ContractorDetails();
                //FactoryService.rawMaterial[] lst = null;
                if (dsdept.Tables[1].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdept.Tables[1];
                    contractmulti = new LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                    for (int k = 0; k < dtraw.Rows.Count; k++)
                    {
                        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                        LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData coc = new LabourQueryResponseCFO.contractLabourPrincipalEmployerMultiData();
                        coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                        coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                        coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                        //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                        coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                        coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                        coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                        coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                        contractmulti[k] = coc;
                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                    }
                    contractvo.contractorParticulars = contractmulti;
                    //rawvo.materialDescr
                }

                labouract.contractLabourPrincipalEmplyerActData = contractvo;
                labourout = labourserviceCfo.actSelected(labouract);

                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    //  gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                    updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    // gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                    // updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                }
            }
        }
        if (deptid == "51")
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            dsdept = Gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

            LabourQueryResponseCFO.act labouract = new LabourQueryResponseCFO.act();
            //LabourQueryResponseCFO.buildingotherconstructions labour = new LabourQueryResponseCFO.buildingotherconstructions();
            LabourQueryResponseCFO.actsResponse labourout = new LabourQueryResponseCFO.actsResponse();
            LabourQueryResponseCFO.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFO.contractLabourPrincipalEmployer();
            LabourQueryResponseCFO.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFO.ismwPrincipalEmployer();

            string actids = "";
            string actid = "";
            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
            string[] split = actids.Split(',');

            if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
            {
                labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                migrateemployer.actID = "ISMWPEF";
                //migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                //migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                //migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                //migrateemployer.compound_fee = 0;
                migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                migrateemployer.employees_attachement = "";
                // migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                migrateemployer.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                migrateemployer.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                migrateemployer.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                migrateemployer.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                migrateemployer.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                migrateemployer.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                migrateemployer.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                migrateemployer.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                migrateemployer.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                migrateemployer.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                migrateemployer.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                migrateemployer.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                migrateemployer.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                migrateemployer.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                // migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                migrateemployer.other_attachments_1 = "";
                migrateemployer.other_attachments_2 = "";
                //migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                //migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                //migrateemployer.penality_percentage = 0;
                //migrateemployer.penality_years = 0;
                migrateemployer.previous_registered_act = "";
                migrateemployer.previous_registration_certificate = "";
                migrateemployer.previous_registration_no = "";
                migrateemployer.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                migrateemployer.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                migrateemployer.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                migrateemployer.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                migrateemployer.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                migrateemployer.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                migrateemployer.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                migrateemployer.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                migrateemployer.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                //migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                //migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //migrateemployer.registration_years = 0;
                migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                //migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                //migrateemployer.total_penality_amount = 0;
                //migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                //migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                //migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //migrateemployer.transaction_status = "Y";
                //migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                //migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                //migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                //migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                //migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                //LabourQueryResponseCFO.ismwPrincipalEmployerMultiData[] migrantvo = null;
                //ContractorDetails co = new ContractorDetails();
                ////FactoryService.rawMaterial[] lst = null;
                //if (dsdept.Tables[1].Rows.Count > 0)
                //{
                //    DataTable dtraw = new DataTable();
                //    dtraw = dsdept.Tables[1];
                //    migrantvo = new LabourQueryResponseCFO.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                //    for (int k = 0; k < dtraw.Rows.Count; k++)
                //    {
                //        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                //        LabourQueryResponseCFO.ismwPrincipalEmployerMultiData coc = new LabourQueryResponseCFO.ismwPrincipalEmployerMultiData();
                //        coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                //        coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                //        coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                //        //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                //        coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                //        coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                //        coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                //        coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                //        coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                //        migrantvo[k] = coc;
                //        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                //        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                //    }
                //    migrateemployer.contractorParticulars = migrantvo;
                //    //rawvo.materialDescr
                //}
                labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                labourout = labourserviceCfo.actSelected(labouract);
                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    //  gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                    updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    // gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                    // updatequerystringcfo(Request.QueryString["Queryid"].ToString());
                }
            }
        }
    }

    public void updatequerystringcfo(string Applicantid)
    {
        DataSet ds = new DataSet();
        string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.GetQueryStatusByTransactionIDCFO(Applicantid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();

                int result = 0;

                result = Gen.InsertQueryDetailsCFO(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, "", "", "", "", Created_by, "", "", "", getclientIP());
            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }
    }
    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }
    protected void BtnTeluguBoard_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileTeluguBoard.HasFile)
        {
            if ((FileTeluguBoard.PostedFile != null) && (FileTeluguBoard.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileTeluguBoard.PostedFile.FileName);
                try
                {

                    string[] fileType = FileTeluguBoard.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\TeluguBoard");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileTeluguBoard.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileTeluguBoard.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "TeluguBoard");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblTeluguBoard.Text = FileTeluguBoard.FileName;
                            LabelTeluguBoard.Text = FileTeluguBoard.FileName;
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

    protected void btnPrinformV_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (fuFormvPrinEmp.HasFile)
        {
            if ((fuFormvPrinEmp.PostedFile != null) && (fuFormvPrinEmp.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fuFormvPrinEmp.PostedFile.FileName);
                try
                {

                    string[] fileType = fuFormvPrinEmp.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PrincipalEmployerFormV");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuFormvPrinEmp.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuFormvPrinEmp.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PrincipalEmployerFormV");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hplFormvPrinEmp.Text = FileTeluguBoard.FileName;
                            lblFormvPrinEmp.Text = FileTeluguBoard.FileName;
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

    protected void btnidproof_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadidproof.HasFile)
        {
            if ((FileUploadidproof.PostedFile != null) && (FileUploadidproof.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadidproof.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadidproof.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\IDProofEmployer");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadidproof.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadidproof.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "IDProofEmployer");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkidproof.Text = FileUploadidproof.FileName;
                            Labelidproof.Text = FileUploadidproof.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
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
    protected void btnphoto_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadphoto.HasFile)
        {
            if ((FileUploadphoto.PostedFile != null) && (FileUploadphoto.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadphoto.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadphoto.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PassportSizePhoto");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadphoto.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PassportSizePhoto");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkphoto.Text = FileUploadphoto.FileName;
                            Labelphoto.Text = FileUploadphoto.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
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
    protected void btnrenetaldeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadrenetaldeed.HasFile)
        {
            if ((FileUploadrenetaldeed.PostedFile != null) && (FileUploadrenetaldeed.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadrenetaldeed.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadrenetaldeed.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RentalSaleDeed");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadrenetaldeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadrenetaldeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RentalSaleDeed");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkrenetaldeed.Text = FileUploadrenetaldeed.FileName;
                            Labelrenetaldeed.Text = FileUploadrenetaldeed.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
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
    protected void btnMemorandum_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadMemorandum.HasFile)
        {
            if ((FileUploadMemorandum.PostedFile != null) && (FileUploadMemorandum.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadMemorandum.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadMemorandum.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\MemorandumofArticle");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadMemorandum.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadMemorandum.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "MemorandumofArticle");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkMemorandum.Text = FileUploadMemorandum.FileName;
                            LabelMemorandum.Text = FileUploadMemorandum.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
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
    protected void btnAttachChallan_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        if (fucAttachChallan.HasFile)
        {

            General t1 = new General();
            if ((fucAttachChallan.PostedFile != null) && (fucAttachChallan.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fucAttachChallan.PostedFile.FileName);
                try
                {
                    string[] fileType = fucAttachChallan.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder  
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\LabourSecurityDepositChallan");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fucAttachChallan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fucAttachChallan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RentalSaleDeed");
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            // lnkEmpFrmV.Text = FuEmpFrmV.FileName;
                            lblAttachChallan.Text = fucAttachChallan.FileName;
                            // txtEmpFrmV.Text= FuEmpFrmV.FileName;
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
                        }
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            success.Visible = false;
            Failure.Visible = false;
            string message1 = "alert(Please Upload Security Deposit Attach Challan)";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            return;

        }
    }
    protected void ddlEstClassification_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlEstClassification.SelectedValue == "3" || ddlEstClassification.SelectedValue == "4")
            {
                trMemorandum.Visible = true;
                trincorportaion.Visible = true;
            }
            else
            {
                trMemorandum.Visible = false;
                trincorportaion.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnincorportaion_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadincorportaion.HasFile)
        {
            if ((FileUploadincorportaion.PostedFile != null) && (FileUploadincorportaion.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadincorportaion.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadincorportaion.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\Incorporation");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadincorportaion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadincorportaion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Incorporation");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkincorportaion.Text = FileUploadincorportaion.FileName;
                            Labelincorportaion.Text = FileUploadincorportaion.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF only..!</font>";
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

    #region BusineessLogic for ContraactLicense
    public class LabourActVO_ContraactLicense
    {

        public string chkZone1
        {
            get;
            set;
        }
        public string chkZone2
        {
            get;
            set;
        }
        public string chkZone3
        {
            get;
            set;
        }

        public string StartDate_duration_contract
        {
            get;
            set;
        }

        public string EndDate_duration_contract
        {
            get;
            set;
        }

        public string NameofContractor_contLic
        {
            get;
            set;
        }

        public string DropDownList7_contLic
        {
            get;
            set;
        }

        public string DropDownList8_contLic
        {
            get;
            set;
        }

        public string DropDownList9_contLic
        {
            get;
            set;
        }

        public string ContAddPincode_contract
        {
            get;
            set;
        }

        public string ContrEmail_contract
        {
            get;
            set;
        }


        public string ContrMobile_contract
        {
            get;
            set;
        }

        public string ContLocality_contract
        {
            get;
            set;
        }

        public string ContOutsideLoc_contract
        {
            get;
            set;
        }
        //txtMaxoEmployees

        public string MaxoEmployees_contract
        {
            get;
            set;
        }

        public string contractConvict_contract
        {
            get;
            set;
        }

        public string contractSuspend_contract
        {
            get;
            set;
        }

        public string rblcontractEst_contract
        {
            get;
            set;
        }

        public string txtDOB_contract
        {
            get;
            set;
        }

        public string PartEstablNumber_contract
        {
            get;
            set;
        }
        //

        public string PartEstablDate_contract
        {
            get;
            set;
        }

        public string NamePrinEmploy_contract
        {
            get;
            set;
        }
        public string DoornoPrinEmploy_contract
        {
            get;
            set;
        }
        public string DistPrinEmploy_contract
        {
            get;
            set;
        }
        public string MandalPrinEmploy_contract
        {
            get;
            set;
        }
        public string VillagePrinEmploy_contract
        {
            get;
            set;
        }
        public string PrinEmployPincode_contract
        {
            get;
            set;
        }

        public string PrinEmploytxtOtherStateAddr_contract
        {
            get;
            set;
        }
        public string DirFullName_contract
        {
            get;
            set;
        }
        public string DirDoorNo_contract
        {
            get;
            set;
        }
        public string DirDistrict_contract
        {
            get;
            set;
        }
        public string DirMandal_contract
        {
            get;
            set;
        }
        public string DirVillage_contract
        {
            get;
            set;
        }


        public string Nameofagentormanager
        {
            get;
            set;
        }
        public string DirDoorNoofagentormanager
        {
            get;
            set;
        }
        public string DirLocalityofagentormanager
        {
            get;
            set;
        }
        public string DirAddressofagentormanager
        {
            get;
            set;
        }
        public string DirDistrictofagentormanager
        {
            get;
            set;
        }
        public string DirMandalofagentormanager
        {
            get;
            set;
        }
        public string DirVillageofagentormanager
        {
            get;
            set;
        }
        public string DirPincodeofagentormanager
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }
        public string SecurityDepositPaid { get; set; }
        public string SecurityDepositPayable { get; set; }
        public string SecurityDepositChallanNo { get; set; }

        public string SecurityDepositChallanDate { get; set; }

        public string SecurityDepositChallanFilename { get; set; }

    }


    #endregion











    protected void ddlagentormanagerdistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlagentormanagerdistrict, ddlagentormanagermandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void ddlagentormanagermandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlagentormanagermandal, ddlagentormanagervillage);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        DataSet dsage = new DataSet();
        dsage = GETAGE(txtDOB.Text.Trim());
        if (dsage.Tables[0].Rows.Count > 0)
        {
            txtage.Text = Convert.ToString(dsage.Tables[0].Rows[0]["Column1"]);
        }

    }
    public DataSet GETAGE(string DOB)
    {
        DataSet dsgetagebydob = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@DOB",SqlDbType.DateTime),

        };
        pp[0].Value = DOB;


        dsgetagebydob = Gen.GenericFillDs("GetAge", pp);
        return dsgetagebydob;
    }
}