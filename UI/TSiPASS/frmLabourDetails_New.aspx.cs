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

public partial class UI_TSiPASS_frmLabourDetails_New : System.Web.UI.Page
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
    List<ContractorDetails> lstContractorVoAct3 = new List<ContractorDetails>();
    List<ContractorDetails> lstContractorVoAct4 = new List<ContractorDetails>();
    string LabourActid = "";
    int totalContractEmployees;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string TourismFlag = "";
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                trsubmitqury.Visible = false;
                trsubmitactual.Visible = true;

                BindDistricts(ddlDistrictPermAct2);
                BindDistricts(ddlShopDistrict);
                BindDistricts(ddlManagerDistrictAct1);
                BindDistricts(ddlContractorDistrict);
                BindDistricts(ddlagentormanagerdistrict);
                BindDistricts(ddlDistPrinEmploy);
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    Session["dscheck"] = dscheck;
                    TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                    if (dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != null && dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != "")
                    {
                        ViewState["LabourActId"] = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                        LabourActid = ViewState["LabourActId"].ToString();
                    }
                    if (LabourActid == "")
                    {
                        if (Request.QueryString[1].ToString() == "N")
                        {
                            //Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
                            Response.Redirect("frmPowerCeig.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        }
                        else
                            Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "P");
                    }
                    if (dscheck.Tables.Count > 3 && dscheck.Tables[3].Rows.Count > 0)
                    {
                        //door_no pincode mobilenumber,email
                        txtShopDoorNo.Text = dscheck.Tables[3].Rows[0]["door_no"].ToString();
                        txtShopPincode.Text = dscheck.Tables[3].Rows[0]["pincode"].ToString();
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                    }
                    if (dscheck.Tables.Count > 4 && dscheck.Tables[4].Rows.Count > 0)
                    {
                        //door_no pincode mobilenumber,email
                        if (dscheck.Tables[4].Rows[0]["Name_Gramapachayat"].ToString() != "")
                        {
                            txtShopLocality.Text = dscheck.Tables[4].Rows[0]["Name_Gramapachayat"].ToString();
                            txtShopLocality.Enabled = false;
                        }
                        if (dscheck.Tables[4].Rows[0]["SurveyNo"].ToString() != "")
                        {
                            txtShopDoorNo.Text = dscheck.Tables[4].Rows[0]["SurveyNo"].ToString();
                            txtShopDoorNo.Enabled = false;
                        }
                        if (dscheck.Tables[4].Rows[0]["SurveyNo"].ToString() != "")
                        {
                            txtDoorNoPermAct2.Text = dscheck.Tables[4].Rows[0]["SurveyNo"].ToString();
                            txtDoorNoPermAct2.Enabled = false;
                        }
                        if (dscheck.Tables[4].Rows[0]["Land_Pincode"].ToString() != "")
                        {
                            txtShopPincode.Text = dscheck.Tables[4].Rows[0]["Land_Pincode"].ToString();
                            txtShopPincode.Enabled = false;
                        }
                        if (dscheck.Tables[4].Rows[0]["Land_Pincode"].ToString() != "")
                        {
                            txtPinCodePermAct2.Text = dscheck.Tables[4].Rows[0]["Land_Pincode"].ToString();
                            txtPinCodePermAct2.Enabled = false;
                        }

                        if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() != "" && dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() != "0")
                        {
                            if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() == "33")
                            {
                                //string dist= dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString();
                                ddlShopDistrict.SelectedValue = "7";
                                ddlShopDistrict_SelectedIndexChanged(sender, e);
                                ddlShopDistrict.Enabled = false;
                                // ddlShopDistrict.Enabled = false;
                            }
                            else if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() == "32")
                            {
                                ddlShopDistrict.SelectedValue = "30";
                                ddlShopDistrict_SelectedIndexChanged(sender, e);
                                ddlShopDistrict.Enabled = false;
                            }
                            else
                            {
                                ddlShopDistrict.SelectedValue = ddlShopDistrict.Items.FindByValue(dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString().Trim()).Value;
                                ddlShopDistrict_SelectedIndexChanged(sender, e);
                                ddlShopDistrict.Enabled = false;
                                // ddlShopDistrict.Enabled = false;
                            }
                        }
                        if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() != "" && dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() != "0")
                        {
                            if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() == "33")
                            {
                                //string dist= dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString();
                                ddlShopDistrict.SelectedValue = "7";
                                ddlShopDistrict_SelectedIndexChanged(sender, e);
                                ddlShopDistrict.Enabled = false;
                                // ddlShopDistrict.Enabled = false;
                            }
                            else if (dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString() == "32")
                            {
                                ddlShopDistrict.SelectedValue = "30";
                                ddlShopDistrict_SelectedIndexChanged(sender, e);
                                ddlShopDistrict.Enabled = false;
                            }
                            else
                            {
                                ddlDistrictPermAct2.SelectedValue = ddlDistrictPermAct2.Items.FindByValue(dscheck.Tables[4].Rows[0]["Land_intDistrictid"].ToString().Trim()).Value;
                                ddlDistrictPermAct2_SelectedIndexChanged(sender, e);
                                ddlDistrictPermAct2.Enabled = false;
                                // ddlShopDistrict.Enabled = false;
                            }
                        }
                        if (dscheck.Tables[4].Rows[0]["nameofunit"].ToString() != "")
                        {
                            txtFullNamePermAct2.Text =  dscheck.Tables[4].Rows[0]["nameofunit"].ToString();
                            txtFullNamePermAct2.Enabled = false;
                        }
                        if (dscheck.Tables[4].Rows[0]["LineofActivity_Name"].ToString() != "")
                        {
                            txtNatureofBusinessAct1.Text = dscheck.Tables[4].Rows[0]["LineofActivity_Name"].ToString();
                           // txtNatureofBusinessAct1.Enabled = false;
                        }
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                        //txtShopDoorNo.Text = dscheck.Tables[3].Rows[0][""].ToString();
                    }
                }
                else
                {
                    Session["Applid"] = "0";
                }

                DataSet dsver = new DataSet();
                dsver = Gen.GetverifyofqueLabour(Session["Applid"].ToString());
                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
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

                        if (res == "3" || Convert.ToInt32(res) >= 3)
                        {
                            ResetFormControl(this);
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                
                if (LabourActid.Contains("2"))
                {
                    lblPostalAddress.Text = "1.Postal Address of the Establishment";
                    lblPermanentAddress.Text = "2. Full name and Permanent Address of the Establishment, if any";
                    lblManagerAddress.Text = "3. Full Name and Address of the Manager or Person Responsible for the Supervision and Control of the Establishment";
                    lblNatureofBusiness.Text = "4. Nature of work / is to be carried on in the establishment";
                    lblDateofCommencement.Text = "5. Estimated date of commencement of building or other construction work";
                    lblTotalEmps.Text = "6. Maximum number of building workers to be employed on any day ";
                    lblCompletionDate.Text = "7. Estimated date of completion of building or other construction work";

                    trPostalAddress.Visible = true;
                    trPermanentAddressofEstab.Visible = true;
                    trManagerResidenceAct1.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    trDateofCommencement.Visible = true;
                    trTotalEmps.Visible = true;
                    trCompletionDate.Visible = true;

                    txtTotalEmployees.Enabled = true;
                    BindDistricts(ddlDistrictPermAct2);

                }

                if (LabourActid.Contains("3"))
                {
                    trCategory.Visible = true;
                    trPostalAddress.Visible = true;
                    trEmployerDetails1Main.Visible = true;
                    trEmployerDetails1.Visible = true;
                    trEmployerDetails2.Visible = true;
                    trEmployerAddress1main.Visible = true;
                    trEmployerAddress1.Visible = false;
                    trEmployerAddress2.Visible = true;
                    trManagerResidenceAct1.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    trContractorDetailsAct4.Visible = true;
                    trTotalContractors.Visible = true;


                    // BindRegisteredActs();
                    lblCategoryofEstab.Text = "1. Category of Establishment";
                    lblPostalAddress.Text = "2. Postal address of the Establishment";
                    lblEmployer.Text = "Full name and address of the Principal Employer(furnish father's name in the case of individuals)";
                    lblManagerAddress.Text = "4. Full name and address of the Manager or person responsible for the Supervison and control of the Establishment";
                    lblNatureofBusiness.Text = "5. Nature of work carried out in the Establishment";
                    lblContractor.Text = "6. Particulars of Contractors and Contract Labours/Migrant workmen";
                }

                if (LabourActid.Contains("4"))
                {
                    trCategory.Visible = true;
                    trPostalAddress.Visible = true;
                    trEmployerDetails1Main.Visible = true;
                    trEmployerDetails1.Visible = true;
                    trEmployerDetails2.Visible = true;
                    trEmployerAddress1main.Visible = true;
                    trEmployerAddress1.Visible = false;
                    trEmployerAddress2.Visible = true;
                    trManagerResidenceAct1.Visible = true;
                    trEmployerDetails1.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    trContractorDetailsAct4.Visible = true;
                    trTotalContractors.Visible = true;
                    trDirectorAddress.Visible = true;
                    BindDistricts(ddlDirDistrict);

                    lblCategoryofEstab.Text = "1. Category of Establishment";
                    lblPostalAddress.Text = "2. Postal address of the Establishment";
                    lblEmployer.Text = "3. Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                    lblDirector.Text = "4.  Name and address of the Director / Partners (in case of companies/firm)";
                    lblManagerAddress.Text = "5. Full name and address of the Manager or person responsible for the Supervison and control of the Establishment";

                    lblNatureofBusiness.Text = "6. Nature of work carried on in the Establishment";
                    lblContractor.Text = "7. Particulars of Contractors and Contract Labours/Migrant workmen";
                }

                if (LabourActid.Contains("5"))
                {

                    DataSet ds1 = new DataSet();
                    ds1 = Gen.GetLabourActCategoryMaster();
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlTypeOfBussiness.DataSource = ds1.Tables[0];
                        ddlTypeOfBussiness.DataTextField = "Category_Desc";
                        ddlTypeOfBussiness.DataValueField = "Business_id";
                        ddlTypeOfBussiness.DataBind();
                    }
                    trContratorDetls.Visible = true;
                    trContractorDob.Visible = true;
                    trPostalAddress.Visible = true;
                    trEmployerDetails1Main.Visible = true;
                    trEmployerDetails1.Visible = true;
                    trEmployerDetails2.Visible = true;
                    trEmployerAddress1main.Visible = true;
                    trEmployerAddress1.Visible = false;
                    trEmployerAddress2.Visible = true;
                    trManagerResidenceAct1.Visible = true;
                    trTypeOfEstablishment.Visible = true;
                    trCertRegEstablish.Visible = true;
                    TRNAMEANDDATE.Visible = true;
                    TRNUMANDDATE.Visible = true;
                    TRPEREGCERT.Visible = true;

                    // trAgentOrMangerWorkSite.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    trDateofCommencement.Visible = true;
                    trTotalEmps.Visible = true;
                    trCompletionDate.Visible = true;
                    trMaxMigrantEstabDate.Visible = true;
                    trOptions.Visible = true;
                    trPrinEmpFrmV.Visible = true;
                    trDeposit.Visible = true;

                    lblHContrator.Text = "1. Name and address of the contractor(including his father's/ husband's name in case of individuals)";
                    lblHCDob.Text = "2. Date of birth (in case of individuals)";
                    lblPostalAddress.Text = "3. Postal address of the Establishment";
                    lblEmployer.Text = "4. Details of the Principal Employer";
                    lblManagerAddress.Text = "5. Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";
                    //----------------------------------
                    AddSelect(ddlTypeOfBussiness);

                }
                if (LabourActid.Contains("6"))
                {
                    DataSet ds1 = new DataSet();
                    ds1 = Gen.GetLabourActCategoryMaster();
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlTypeOfBussiness.DataSource = ds1.Tables[0];
                        ddlTypeOfBussiness.DataTextField = "Category_Desc";
                        ddlTypeOfBussiness.DataValueField = "Business_id";
                        ddlTypeOfBussiness.DataBind();
                    }
                    txtTotalEmployees.Enabled = true;
                    trContratorDetls.Visible = true;
                    trContractorDob.Visible = true;
                    trprincipalCert.Visible = true;
                    trCategory.Visible = true;
                    trEmployerDetails1Main.Visible = true;
                    trEmployerDetails1.Visible = true;
                    trEmployerDetails2.Visible = true;
                    trEmployerAddress1main.Visible = true;
                    trEmployerAddress1.Visible = false;
                    trEmployerAddress2.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    trManagerResidenceAct1.Visible = true;
                    trTotalEmps.Visible = true;
                    trOptions.Visible = true;
                    trPrinEmpFrmV.Visible = true;
                    trDeposit.Visible = true;
                    trcontractzone.Visible = true;
                    trcommencementdatecontractlabor.Visible = true;
                }
               
                if (LabourActid.Contains("7"))
                {
                    DataSet ds1 = new DataSet();
                    ds1 = Gen.GetLabourActCategoryMaster();
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        ddlTypeOfBussiness.DataSource = ds1.Tables[0];
                        ddlTypeOfBussiness.DataTextField = "Category_Desc";
                        ddlTypeOfBussiness.DataValueField = "Business_id";
                        ddlTypeOfBussiness.DataBind();
                    }

                    //tr1.Visible = true;
                    trAgentOrMangerWorkSite.Visible = true;
                    
                    trDetailofPrinEmploy.Visible = true;
                    trDetailofPrinEmploy1.Visible = true;
                   
                    trGodown1.Visible = false;

                    trContractorDob.Visible = true;
                    trContratorDetls.Visible = true;
                    trprincipalCert.Visible = true;
                    trnoanddate1.Visible = true;
                    trnoanddate2.Visible = true;
                    truploadandworksers.Visible = false;
                    trCertRegEstablish.Visible = true;
                    TRNAMEANDDATE.Visible = false;
                    TRNUMANDDATE.Visible = false;
                    TRPEREGCERT.Visible = true;
                    trprincpleemployee.Visible = true;
                    trzone.Visible = true;
                    trzonechecklist.Visible = true;
                    trcommencementdatecontractlabor.Visible = true;
                    trAgentOrMangerWorkSite.Visible = true;
                    trTypeOfEstablishment.Visible = true;
                    trMaxMigrantEstabDate.Visible = true;
                    trOptions.Visible = true;
                    trPrinEmpFrmV.Visible = true;
                    trDeposit.Visible = true;
                    trcontractzone.Visible = true;
                    trPostalAddress.Visible = true;
                    trNatureofBusinessAct1.Visible = true;
                    lblNatureofBusiness.Text = "Nature of work in which contract labour is employed or is to be employed in the establishment";







                    lblCategoryofEstab.Text = "Category of Establishment";  //removed numbering in headings.
                    lblPostalAddress.Text = "Name and address of the worksite";
                   // lblNatureofBusiness.Text = "Nature of work carried out in the Establishment";
                    lblContractor.Text = "Particulars of Contractors and migrant workmen";

                    
                }
                // Aasigning numbers
                int Slno = 0;
                if (trCategory.Visible == true)
                {
                    lblCategoryofEstab.Text = (Slno + 1).ToString() + ". Category of Establishment";
                    Slno = (Slno + 1);
                }
                if (trContratorDetls.Visible == true)
                {
                    lblHContrator.Text = (Slno + 1).ToString() + ". Name and address of the contractor(including his father's/ husband's name in case of individuals)";
                    Slno = (Slno + 1);
                }
                if (trContractorDob.Visible == true)
                {
                    lblHCDob.Text = (Slno + 1).ToString() + ". Date of birth (in case of individuals)";
                    Slno = (Slno + 1);
                }
                if (trprincipalCert.Visible == true)
                {
                    lblprincipalCert.Text = (Slno + 1).ToString() + ". Number and date of certificate of registration of the establishment under the act(of Principal Employer)";
                    Slno = (Slno + 1);
                }
                if (trPostalAddress.Visible == true)
                {
                    if(LabourActid.Contains("7"))
                    {
                        lblPostalAddress.Text = (Slno + 1).ToString() + ". Name and address of the worksite";
                        Slno = (Slno + 1);
                    }
                    else
                    {
                        lblPostalAddress.Text = (Slno + 1).ToString() + ". Postal address of the Establishment";
                        Slno = (Slno + 1);
                    }
                    
                }
                if (trEmployerDetails1Main.Visible == true)
                {
                    lblEmployer.Text = (Slno + 1).ToString() + ". Full name and address of the Principal Employer(furnish father's name in the case of individuals) with Phone No.:";
                    Slno = (Slno + 1);
                }
                if (trPermanentAddressofEstab.Visible == true)
                {
                    lblPermanentAddress.Text = (Slno + 1).ToString() + ". Full name and Permanent Address of the establishment, if any";
                    Slno = (Slno + 1);
                }
                if (trDirectorAddress.Visible == true)
                {
                    lblDirector.Text = (Slno + 1).ToString() + ".  Name and address of the Director / Partners (in case of companies/firm)";
                    Slno = (Slno + 1);
                }
                if (trManagerResidenceAct1.Visible == true)
                {
                    lblManagerAddress.Text = (Slno + 1).ToString() + ". Full name and Address of the Manager or person responsible for the Supervision and control of the Establishment";
                    Slno = (Slno + 1);
                }
                if (trcontractzone.Visible == true)
                {
                    lblcontractzone.Text = (Slno + 1).ToString() + ". Please Select Zone";
                    Slno = (Slno + 1);
                }
                if (trcommencementdatecontractlabor.Visible == true)
                {
                    lblcommencementdatecontractlabor.Text = (Slno + 1).ToString() + ". Duration of the proposed contract work(give particulars of proposed date of commencing and ending)";
                    Slno = (Slno + 1);
                }

                if (trAgentOrMangerWorkSite.Visible == true)
                {
                    lblAgentOrMangerWorkSite.Text = (Slno + 1).ToString() + ". Name and address of the agent or manager of the contractor at the work-site";
                    Slno = (Slno + 1);
                }
                if (trTypeOfEstablishment.Visible == true)
                {
                    lblTypeOfEstablishment.Text = (Slno + 1).ToString() + ". Type of business, trade, industry, manufacture or occupation, which is carried on in the establishment";
                    Slno = (Slno + 1);
                }
                if (trCertRegEstablish.Visible == true)
                {
                    lblCertRegEstablish.Text = (Slno + 1).ToString() + ". Number and date of certificate of registration of the establishment under the act";
                    Slno = (Slno + 1);
                }
                if (trNatureofBusinessAct1.Visible == true)
                {
                    if (LabourActid.Contains("5"))
                    {
                        lblNatureofBusiness.Text = (Slno + 1).ToString() + ". Nature of work in which migrant workmen are be employed in the establishment *";
                        Slno = (Slno + 1);
                    }
                    if (LabourActid.Contains("7"))
                    {
                        lblNatureofBusiness.Text = (Slno + 1).ToString() + ". Nature of work in which contract labour is employed or is to be employed in the establishment *";
                        Slno = (Slno + 1);
                    }
                    else
                    {
                        lblNatureofBusiness.Text = (Slno + 1).ToString() + ". Nature of work / is to be carried on in the establishment";
                        Slno = (Slno + 1);
                    }
                }
                if (trDateofCommencement.Visible == true)
                {
                    lblDateofCommencement.Text = (Slno + 1).ToString() + ". Estimated date of commencement of building or other construction work";
                    Slno = (Slno + 1);
                }
                if (trTotalEmps.Visible == true)
                {
                    lblTotalEmps.Text = (Slno + 1).ToString() + ". Maximum number of Contract Employees / building workers to be employed on any day ";
                    Slno = (Slno + 1);
                }
                if (trCompletionDate.Visible == true)
                {
                    lblCompletionDate.Text = (Slno + 1).ToString() + ". Estimated date of completion of building or other construction work";
                    Slno = (Slno + 1);
                }
                if (trMaxMigrantEstabDate.Visible == true)
                {
                    lblMaxMigrantNo.Text = (Slno + 1).ToString() + ". Maximum Number of migrant workmen proposed to be employed in the establishment on any date";
                    Slno = (Slno + 1);
                }
                if (trOptions.Visible == true)
                {
                    lblOption1.Text = (Slno + 1).ToString() + ". Whether the contractor was convicted of any offence within the preceding five years. If so give details";
                    Slno = (Slno + 1);
                    lblOption2.Text = (Slno + 1).ToString() + ". Whether there was any order against the contractor revoking or suspending license or forefeiting security deposits in respect of an earlier contract . If so the date of such order.";
                    Slno = (Slno + 1);
                    lblOption3.Text = (Slno + 1).ToString() + ". Whether the contractor has worked in any other establishment within the past five years, If so, give details of the Principal Emplyer,Establishments and nature of work";
                    Slno = (Slno + 1);
                }
                if (trPrinEmpFrmV.Visible == true)
                {
                    lblPrinEmpFrmV.Text = (Slno + 1).ToString() + ". Whether a certificate by the Principal Employer in Form V is enclosed";
                    Slno = (Slno + 1);
                }
                if (trDeposit.Visible == true)
                {
                    lblHDeposit.Text = (Slno + 1).ToString() + ". Security Deposit Details";
                    Slno = (Slno + 1);
                }
                if (trContractorDetailsAct4.Visible == true)
                {
                    lblContractor.Text = (Slno + 1).ToString() + ". Particulars of Contractors and migrant workmen";
                    Slno = (Slno + 1);
                }


                // End Aasigning numbers
                if (LabourActid.Contains("3") || LabourActid.Contains("4"))
                {
                    gvContractorAct4.DataSource = BindContractorGridAct3();
                    gvContractorAct4.DataBind();

                }



                if (LabourActid.Contains("1") || LabourActid.Contains("3") || LabourActid.Contains("4") || LabourActid.Contains("6"))
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

                    BindDistricts(ddlDistrictResidentialAct1);

                }
                BindDistricts(ddlDistrictResidentialAct1);
            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();
                    if (TourismFlag == "Y")
                    {
                        ddlTypeOfBussiness.SelectedValue = "9";
                    }
                }
            }

            if (txtmanageragenpincode.Text.Trim().TrimStart() == "")
            {
                txtmanageragenpincode.ReadOnly = false;
            }
            if (txtmanageragenpincode.Text.Trim().TrimStart() == "")
            {
                txtmanageragenAddress.ReadOnly = false;
            }
            if (ddlCategoryofEstablishment.SelectedIndex == 0)
            { 
            ddlCategoryofEstablishment.Enabled = true;
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
            int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
            ds = Gen.getLabourDetails(hdfFlagID0.Value.ToString(), QuestionnaireId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                if (LabourActid.Contains("1") || LabourActid.Contains("3") || LabourActid.Contains("4") || LabourActid.Contains("6"))
                {
                    ddlCategoryofEstablishment.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                    if (ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString() != "")
                    {
                        txtEstDateCompAct2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"]).ToString("dd-MM-yyyy");
                    }
                }
                if (LabourActid.Contains("2"))
                {
                    if (ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString() != "")
                    {
                        txtEstDateCompAct2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"]).ToString("dd-MM-yyyy");
                    }


                    //changing
                    if (ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString() == null)
                    {
                        txtTotalEmployees.Enabled = true;
                        txtTotalEmployees.ReadOnly = false;
                    }
                    else
                    {
                        txtTotalEmployees.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString() == null)
                    {
                        txtDoorNoPermAct2.Enabled = true;
                        txtDoorNoPermAct2.ReadOnly = false;
                    }
                    else
                    {
                        txtDoorNoPermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString() == null)
                    {
                        txtPinCodePermAct2.Enabled = true;
                        txtPinCodePermAct2.ReadOnly = false;
                    }
                    else
                    {
                        txtPinCodePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString() == null)
                    {
                        ddlDistrictPermAct2.Enabled = true;

                    }
                    else
                    {
                        ddlDistrictPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                        ddlDistrictPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString() == null)
                    {
                        ddlMandalPermAct2.Enabled = true;

                    }
                    else
                    {
                        ddlMandalPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                        ddlMandalPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString() == null)
                    {
                        ddlVillagePermAct2.Enabled = true;

                    }
                    else
                    {
                        ddlVillagePermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                        
                    }

                    if (ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString() == null)
                    {
                        txtFullNamePermAct2.Enabled = true;
                        txtFullNamePermAct2.ReadOnly = false;
                    }
                    else
                    {
                        txtFullNamePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString();

                    }
                 //   txtTotalEmployees.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();

                  //  txtDoorNoPermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();

                  //  txtPinCodePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                    //ddlDistrictPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                    //ddlDistrictPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddlMandalPermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                    //ddlMandalPermAct2_SelectedIndexChanged(this, EventArgs.Empty);
                   // ddlVillagePermAct2.SelectedValue = ds.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();

                   // txtFullNamePermAct2.Text = ds.Tables[0].Rows[0]["Form1_2_FullName"].ToString();
                    //upto here changed

                }
                //if (LabourActid.Contains("3"))
                //{
                //    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                //    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                //    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                //    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();

                //    //if (ds.Tables.Count > 1 && ds.Tables[4].Rows.Count > 0)
                //    //{
                //    //    ViewState["dtContractorDtls3"] = ds.Tables[4];
                //    //    gvContractorAct3.DataSource = ds.Tables[4];
                //    //    gvContractorAct3.DataBind();
                //    //}
                //}
                //if (LabourActid.Contains("4"))
                //{
                //    ddlSchemAct3.SelectedValue = ds.Tables[0].Rows[0]["Form1_3_Registered_Act"].ToString();
                //    ddlSchemAct3_SelectedIndexChanged(this, EventArgs.Empty);
                //    txtRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();
                //    txtReRegLicAct3.Text = ds.Tables[0].Rows[0]["Form1_3_Reg_Lic"].ToString();

                //}
                if(LabourActid.Contains("7"))
                {
                    if (ds.Tables[0].Rows[0]["AgentorManagerAddress"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerAddress"].ToString() == null)
                    {
                        txtagentormanageraddress.Enabled = true;
                        txtagentormanageraddress.ReadOnly = false;
                    }
                    else
                    {
                        txtagentormanageraddress.Text = ds.Tables[0].Rows[0]["AgentorManagerAddress"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerName"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerName"].ToString() == null)
                    {
                        txtagentormanagername.Enabled = true;
                        txtagentormanagername.ReadOnly = false;
                    }
                    else
                    {
                        txtagentormanagername.Text = ds.Tables[0].Rows[0]["AgentorManagerName"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerDoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerDoorNo"].ToString() == null)
                    {
                        txtagentormanagerdoorno.Enabled = true;
                        txtagentormanagerdoorno.ReadOnly = false;
                    }
                    else
                    {
                        txtagentormanagerdoorno.Text = ds.Tables[0].Rows[0]["AgentorManagerDoorNo"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerLocality"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerLocality"].ToString() == null)
                    {
                        txtagentormanagerlocality.Enabled = true;
                        txtagentormanagerlocality.ReadOnly = false;
                    }
                    else
                    {
                        txtagentormanagerlocality.Text = ds.Tables[0].Rows[0]["AgentorManagerLocality"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerDistrict"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerDistrict"].ToString() == null)
                    {
                        ddlagentormanagerdistrict.Enabled = true;

                    }
                    else
                    {
                        ddlagentormanagerdistrict.SelectedValue = ds.Tables[0].Rows[0]["AgentorManagerDistrict"].ToString();
                        ddlagentormanagerdistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerMandal"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerMandal"].ToString() == null)
                    {
                        ddlagentormanagermandal.Enabled = true;

                    }
                    else
                    {
                        ddlagentormanagermandal.SelectedValue = ds.Tables[0].Rows[0]["AgentorManagerMandal"].ToString();
                        ddlagentormanagermandal_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerVillage"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerVillage"].ToString() == null)
                    {
                        ddlagentormanagervillage.Enabled = true;

                    }
                    else
                    {
                        ddlagentormanagervillage.SelectedValue = ds.Tables[0].Rows[0]["AgentorManagerVillage"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["AgentorManagerPincode"].ToString() == "" || ds.Tables[0].Rows[0]["AgentorManagerPincode"].ToString() == null)
                    {
                        txtagentormanagerpincode.Enabled = true;
                        txtagentormanagerpincode.ReadOnly = false;
                    }
                    else
                    {
                        txtagentormanagerpincode.Text = ds.Tables[0].Rows[0]["AgentorManagerPincode"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["NamePrinEmploy_contract"].ToString() == "" || ds.Tables[0].Rows[0]["NamePrinEmploy_contract"].ToString() == null)
                    {
                        txtNamePrinEmploy.Enabled = true;
                        txtNamePrinEmploy.ReadOnly = false;
                    }
                    else
                    {
                        txtNamePrinEmploy.Text = ds.Tables[0].Rows[0]["NamePrinEmploy_contract"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["DoornoPrinEmploy_contract"].ToString() == "" || ds.Tables[0].Rows[0]["DoornoPrinEmploy_contract"].ToString() == null)
                    {
                        txtDoornoPrinEmploy.Enabled = true;
                        txtDoornoPrinEmploy.ReadOnly = false;
                    }
                    else
                    {
                        txtDoornoPrinEmploy.Text = ds.Tables[0].Rows[0]["DoornoPrinEmploy_contract"].ToString();

                    }
                    
                    if (ds.Tables[0].Rows[0]["DistPrinEmploy_contract"].ToString() == "" || ds.Tables[0].Rows[0]["DistPrinEmploy_contract"].ToString() == null)
                    {
                        ddlDistPrinEmploy.Enabled = true;

                    }
                    else
                    {
                        ddlDistPrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["DistPrinEmploy_contract"].ToString();
                        ddlDistPrinEmploy_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["MandalPrinEmploy_contract"].ToString() == "" || ds.Tables[0].Rows[0]["MandalPrinEmploy_contract"].ToString() == null)
                    {
                        ddlMandalPrinEmploy.Enabled = true;

                    }
                    else
                    {
                        ddlMandalPrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["MandalPrinEmploy_contract"].ToString();
                        ddlMandalPrinEmploy_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["VillagePrinEmploy_contract"].ToString() == "" || ds.Tables[0].Rows[0]["VillagePrinEmploy_contract"].ToString() == null)
                    {
                        ddlVillagePrinEmploy.Enabled = true;

                    }
                    else
                    {
                        ddlVillagePrinEmploy.SelectedValue = ds.Tables[0].Rows[0]["VillagePrinEmploy_contract"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["PrinEmployPincode_contract"].ToString() == "" || ds.Tables[0].Rows[0]["PrinEmployPincode_contract"].ToString() == null)
                    {
                        txtPrinEmployPincode.Enabled = true;
                        txtPrinEmployPincode.ReadOnly = false;
                    }
                    else
                    {
                        txtPrinEmployPincode.Text = ds.Tables[0].Rows[0]["PrinEmployPincode_contract"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["PrinEmploytxtOtherStateAddr_contract"].ToString() == "" || ds.Tables[0].Rows[0]["PrinEmploytxtOtherStateAddr_contract"].ToString() == null)
                    {
                        txtOtherStateAddrPrinEmploy.Enabled = true;
                        txtOtherStateAddrPrinEmploy.ReadOnly = false;
                    }
                    else
                    {
                        txtOtherStateAddrPrinEmploy.Text = ds.Tables[0].Rows[0]["PrinEmploytxtOtherStateAddr_contract"].ToString();

                    }
 
                    if (ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString() == null)
                    {
                        txtContractorName.Enabled = true;
                        txtContractorName.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorName.Text = ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString() == null)
                    {
                        txtContractorMobile.Enabled = true;
                        txtContractorMobile.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorMobile.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString() == null)
                    {
                        txtContractorEmail.Enabled = true;
                        txtContractorEmail.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorEmail.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString() == null)
                    {
                        txtContractorFname.Enabled = true;
                        txtContractorFname.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorFname.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString() == null)
                    {
                        txtContractorDoorNo.Enabled = true;
                        txtContractorDoorNo.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorDoorNo.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString() == null)
                    {
                        txtContractorLocality.Enabled = true;
                        txtContractorLocality.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorLocality.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString() == null)
                    {
                        ddlContractorDistrict.Enabled = true;

                    }
                    else
                    {
                        ddlContractorDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString();
                        ddlContractorDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString() == null)
                    {
                        ddlContractorMandal.Enabled = true;

                    }
                    else
                    {
                        ddlContractorMandal.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString();
                        ddlContractorMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString() == null)
                    {
                        ddlContractorVillage.Enabled = true;

                    }
                    else
                    {
                        ddlContractorVillage.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString() == null)
                    {
                        txtContractorPincode.Enabled = true;
                        txtContractorPincode.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorPincode.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString() == null)
                    {
                        txtContractorOtherStateAddress.Enabled = true;
                        txtContractorOtherStateAddress.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorOtherStateAddress.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString();

                    }
                    string chkzonesstr = ds.Tables[0].Rows[0]["PrincipleempZone"].ToString();
                    if (!string.IsNullOrEmpty(chkzonesstr))
                    {
                        string[] zonesstr = chkzonesstr.Split(',');
                        foreach (string name in zonesstr)
                        {
                            int index = chkzones.Items.IndexOf(chkzones.Items.FindByValue(name));
                            if (index >= 0)
                            {
                                chkzones.Items[index].Selected = true;
                            }
                        }
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_Dob"].ToString() == null || ds.Tables[0].Rows[0]["Form_1_5_Dob"].ToString() == "")
                    {
                        txtContractorDob.Text = "";
                    }
                    else
                    {
                        txtContractorDob.Text = Convert.ToString(ds.Tables[0].Rows[0]["Form_1_5_Dob"]);
                    }
                    txtMaxMigrantNo.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_MaxNoEmployed"].ToString();
                    txtAmountPaid.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpaid"].ToString();
                    txtAmountPayable.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpayable"].ToString();
                    txtChallanNo.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanNo"].ToString();
                    txtchallandate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["SecurityDepositChallanDate"]).ToString("dd-MM-yyyy");// ds.Tables[0].Rows[0]["SecurityDepositChallanDate"].ToString();
                    lblAttachChallan.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanFileName"].ToString();
                    txtContractorAge.Text = ds.Tables[0].Rows[0]["Form_1_5_Age"].ToString();
                    txtprincipalNumber.Text = ds.Tables[0].Rows[0]["Principleempnumber"].ToString();
                    if (ds.Tables[0].Rows[0]["PrincipleempDate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempDate"].ToString() == "")
                    {
                        txtdateprincipalemployer.Text = "";
                    }
                    else
                    {
                        txtdateprincipalemployer.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempDate"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["PrincipleempCommenceDate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempCommenceDate"].ToString() == "")
                    {
                    }
                    else
                    {
                        txtcontractcommence.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempCommenceDate"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"].ToString() == "")
                    {
                    }
                    else
                    {
                        txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"]).ToString("dd-MM-yyyy");
                    }

                    DataSet dsattachment = new DataSet();
                    dsattachment = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

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

                            if (sen.Contains("PrincipalEmployerFormV"))
                            {
                                //hyperlocationorsiteplan.NavigateUrl = sen;
                               // hyperlocationorsiteplan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                lblEmpFrmV.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                                //HyperLink1.NavigateUrl = sen;
                                //HyperLink1.Text = 
                            }
                            
                            i++;
                        }
                    }



                }
                if (LabourActid.Contains("5") || LabourActid.Contains("6"))
                {
                    if (ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString() == null)
                    {
                        txtContractorName.Enabled = true;
                        txtContractorName.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorName.Text = ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString() == null)
                    {
                        txtContractorMobile.Enabled = true;
                        txtContractorMobile.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorMobile.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString() == null)
                    {
                        txtContractorEmail.Enabled = true;
                        txtContractorEmail.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorEmail.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString() == null)
                    {
                        txtContractorFname.Enabled = true;
                        txtContractorFname.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorFname.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString() == null)
                    {
                        txtContractorDoorNo.Enabled = true;
                        txtContractorDoorNo.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorDoorNo.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString() == null)
                    {
                        txtContractorLocality.Enabled = true;
                        txtContractorLocality.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorLocality.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString() == null)
                    {
                        ddlContractorDistrict.Enabled = true;

                    }
                    else
                    {
                        ddlContractorDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString();
                        ddlContractorDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString() == null)
                    {
                        ddlContractorMandal.Enabled = true;

                    }
                    else
                    {
                        ddlContractorMandal.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString();
                        ddlContractorMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString() == null)
                    {
                        ddlContractorVillage.Enabled = true;

                    }
                    else
                    {
                        ddlContractorVillage.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString();
                        
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString() == null)
                    {
                        txtContractorPincode.Enabled = true;
                        txtContractorPincode.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorPincode.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString() == "" || ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString() == null)
                    {
                        txtContractorOtherStateAddress.Enabled = true;
                        txtContractorOtherStateAddress.ReadOnly = false;
                    }
                    else
                    {
                        txtContractorOtherStateAddress.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString();

                    }




                 //   txtContractorName.Text = ds.Tables[0].Rows[0]["Form1_5_contr_Firm"].ToString();
                  //  txtContractorMobile.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Mobile"].ToString();
                 //   txtContractorEmail.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Email"].ToString();
                  //  txtContractorFname.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Fname"].ToString();
                  //  txtContractorDoorNo.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Doorno"].ToString();
                  //  txtContractorLocality.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Locality"].ToString();
                    //ddlContractorDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_District"].ToString();
                    //ddlContractorDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddlContractorMandal.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Mandal"].ToString();
                    //ddlContractorMandal_SelectedIndexChanged(this, EventArgs.Empty);
                  //  ddlContractorVillage.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_contr_Village"].ToString();
                  //  txtContractorPincode.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Pincode"].ToString();
                  //  txtContractorOtherStateAddress.Text = ds.Tables[0].Rows[0]["Form_1_5_contr_Othr_St_Address"].ToString();
                    //upto here
                    if (ds.Tables[0].Rows[0]["Form_1_5_Dob"].ToString() == null || ds.Tables[0].Rows[0]["Form_1_5_Dob"].ToString() == "")
                    {
                        txtContractorDob.Text = "";
                    }
                    else
                    {
                        txtContractorDob.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form_1_5_Dob"]).ToString("dd-MM-yyyy");
                    }

                    txtContractorAge.Text = ds.Tables[0].Rows[0]["Form_1_5_Age"].ToString();
                    ddlTypeOfBussiness.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_Type_of_Bussiness"].ToString();
                    txtEstRegNumber.Text = ds.Tables[0].Rows[0]["Form_1_5_Establishment_Number"].ToString();

                    if (ds.Tables[0].Rows[0]["Form_1_5_Establishment_Date"].ToString() == null || ds.Tables[0].Rows[0]["Form_1_5_Establishment_Date"].ToString() == "")
                    {
                        txtRegEstdate.Text = "";
                    }
                    else
                    {
                        txtRegEstdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form_1_5_Establishment_Date"]).ToString("dd-MM-yyyy");
                    }
                    txtMaxMigrantNo.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_MaxNoEmployed"].ToString();
                    // lnkPERCert.Text = ds.Tables[0].Rows[0]["Form_1_5_Establishment_Reg_certi"].ToString();
                    rdlOptList1.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_Contractor_convicted_flag"].ToString();
                    rdlOptList2.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder_flag"].ToString();
                    rdlOptList3.SelectedValue = ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyestablish_flag"].ToString();
                    //lnkEmpFrmV.Text = ds.Tables[0].Rows[0]["Form_1_5_PE_Form_V_Name"].ToString();


                    if (ds.Tables[0].Rows[0]["Form_1_5_Contractor_convicted_flag"].ToString() == "Y")
                    {
                        rdlOptList1_SelectedIndexChanged(this, EventArgs.Empty);
                        txtOpt1.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_convicted"].ToString();

                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder_flag"].ToString() == "Y")
                    {
                        rdlOptList2_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder"].ToString() != "")
                        {
                            txtOpt2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyorder"]).ToString("dd-MM-yyyy");
                        }
                    }
                    if (ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyestablish_flag"].ToString() == "Y")
                    {
                        rdlOptList3_SelectedIndexChanged(this, EventArgs.Empty);
                        txtOpt3.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_anyestablish"].ToString();
                    }

                    

                    lblEmpFrmV.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_PEFVFileName"].ToString();
                    lblPERCert.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_PERCFileName"].ToString();

                    txtAmountPaid.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpaid"].ToString();
                    txtAmountPayable.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_Amountpayable"].ToString();
                    txtChallanNo.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanNo"].ToString();
                    lblAttachChallan.Text = ds.Tables[0].Rows[0]["Form_1_5_Contractor_SecurityDe_ChallanFileName"].ToString();


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

                if (ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString() == null)
                {
                    txtMobileNoManagerAct2.Enabled = true;
                    txtMobileNoManagerAct2.ReadOnly = false;
                }
                else
                {
                    txtMobileNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString() == null)
                {
                    txtEmailManagerAct2.Enabled = true;
                    txtEmailManagerAct2.ReadOnly = false;
                }
                else
                {
                    txtEmailManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();

                }


                if (ds.Tables[0].Rows[0]["Form1_Manager_PINCode"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Manager_PINCode"].ToString() == null)
                {
                    txtmanageragenpincode.Enabled = true;
                    txtmanageragenpincode.ReadOnly = false;
                }
                else
                {
                    txtmanageragenpincode.Text = ds.Tables[0].Rows[0]["Form1_Manager_PINCode"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Manager_Address"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Manager_Address"].ToString() == null)
                {
                    txtmanageragenAddress.Enabled = true;
                    txtmanageragenAddress.ReadOnly = false;
                }
                else
                {
                    txtmanageragenAddress.Text = ds.Tables[0].Rows[0]["Form1_Manager_Address"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString() == null)
                {
                    txtNameofShopAct1.Enabled = true;
                    txtNameofShopAct1.ReadOnly = false;
                }
                else
                {
                    txtNameofShopAct1.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString() == null)
                {
                    txtShopDoorNo.Enabled = true;
                    txtShopDoorNo.ReadOnly = false;
                }
                else
                {
                    txtShopDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString() == null)
                {
                    txtShopLocality.Enabled = true;
                    txtShopLocality.ReadOnly = false;
                }
                else
                {
                    txtShopLocality.Text = ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString() == null)
                {
                    ddlShopDistrict.Enabled = true;

                }
                else
                {
                    ddlShopDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                    ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString() == null)
                {
                    ddlShopMandal.Enabled = true;

                }
                else
                {
                    ddlShopMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                    ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString() == null)
                {
                    ddlShopVillage.Enabled = true;

                }
                else
                {
                    ddlShopVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                   
                }


                //txtMobileNoManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
               // txtEmailManagerAct2.Text = ds.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
               // txtNameofShopAct1.Text = ds.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
               // txtShopDoorNo.Text = ds.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
              //  txtShopLocality.Text = ds.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
               // ddlShopDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
             //   ddlShopDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                //ddlShopMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                //ddlShopMandal_SelectedIndexChanged(this, EventArgs.Empty);
               // ddlShopVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();

                if (ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString() == null)
                {
                    txtShopPincode.Enabled = true;
                    txtShopPincode.ReadOnly = false;
                }
                else
                {
                    txtShopPincode.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString() == null)
                {
                    TxtnameofUnitAct1.Enabled = true;
                    TxtnameofUnitAct1.ReadOnly = false;
                }
                else {
                    TxtnameofUnitAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString() == null)
                {
                    txtPGNameAct1.Enabled = true;
                    txtPGNameAct1.ReadOnly = false;
                }
                else
                {
                    txtPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString() == null)
                {
                    txtDesigAct1.Enabled = true;
                    txtDesigAct1.ReadOnly = false;
                }
                else
                {
                    txtDesigAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString() == null)
                {
                    txtAgeAct1.Enabled = true;
                    txtAgeAct1.ReadOnly = false;
                }
                else
                {
                    txtAgeAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString() == null)
                {
                    txtMobileAct1.Enabled = true;
                    txtMobileAct1.ReadOnly = false;
                }
                else
                {
                    txtMobileAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString() == null)
                {
                    txtEmailAct1.Enabled = true;
                    txtEmailAct1.ReadOnly = false;
                }
                else
                {
                    txtEmailAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString() == null)
                {
                    txtDoorNoResidentialAct1.Enabled = true;
                    txtDoorNoResidentialAct1.ReadOnly = false;
                }
                else
                {
                    txtDoorNoResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString() == null)
                {
                    txtLocalResidentialAct1.Enabled = true;
                    txtLocalResidentialAct1.ReadOnly = false;
                }
                else
                {
                    txtLocalResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString() == null)
                {
                    ddlDistrictResidentialAct1.Enabled = true;
                    
                }
                else
                {
                    ddlDistrictResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                    ddlDistrictResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString() == null)
                {
                    ddlMandalResidentialAct1.Enabled = true;

                }
                else
                {
                    ddlMandalResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                    ddlMandalResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString() == null)
                {
                    ddlVillageResidentialAct1.Enabled = true;

                }
                else
                {
                    ddlVillageResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                    
                }

                //------------------changed----------------
                //txtShopPincode.Text = ds.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                //TxtnameofUnitAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                //txtPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                //txtDesigAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                //txtAgeAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                //txtMobileAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                //txtEmailAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                //txtDoorNoResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                //txtLocalResidentialAct1.Text = ds.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
               // ddlDistrictResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                //ddlDistrictResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
               // ddlMandalResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
               // ddlMandalResidentialAct1_SelectedIndexChanged(this, EventArgs.Empty);
                //ddlVillageResidentialAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();

                //---------------changed-----------------------------------
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString() == null)
                {
                    txtManagerNameAct1.Enabled = true;
                    txtManagerNameAct1.ReadOnly = false;
                }
                else
                {
                    txtManagerNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString() == null)
                {
                    txtManagerPGNameAct1.Enabled = true;
                    txtManagerPGNameAct1.ReadOnly = false;
                }
                else
                {
                    txtManagerPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString() == null)
                {
                    txtManagerDesignationAct1.Enabled = true;
                    txtManagerDesignationAct1.ReadOnly = false;
                }
                else
                {
                    txtManagerDesignationAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString() == null)
                {
                    txtManagerDoorNoAct1.Enabled = true;
                    txtManagerDoorNoAct1.ReadOnly = false;
                }
                else
                {
                    txtManagerDoorNoAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();

                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString() == null)
                {
                    txtManagerLocalityAct1.Enabled = true;
                    txtManagerLocalityAct1.ReadOnly = false;
                }
                else
                {
                    txtManagerLocalityAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();

                }

                if (ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString() == null)
                {
                    ddlManagerDistrictAct1.Enabled = true;

                }
                else
                {
                    ddlManagerDistrictAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                    ddlManagerDistrictAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString() == null)
                {
                    ddlManagerMandalAct1.Enabled = true;

                }
                else
                {
                    ddlManagerMandalAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                    ddlManagerMandalAct1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString() == null)
                {
                    ddlManagerVillageAct1.Enabled = true;

                }
                else
                {
                    ddlManagerVillageAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                   
                }

                //-------changed---------------
                //txtManagerNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
               // txtManagerPGNameAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
               // txtManagerDesignationAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
               // txtManagerDoorNoAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
               // txtManagerLocalityAct1.Text = ds.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
               // ddlManagerDistrictAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
              //  ddlManagerDistrictAct1_SelectedIndexChanged(this, EventArgs.Empty);
               // ddlManagerMandalAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
              //  ddlManagerMandalAct1_SelectedIndexChanged(this, EventArgs.Empty);
               // ddlManagerVillageAct1.SelectedValue = ds.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                //-------changed---------------
                //
                //
                if (LabourActid.Contains("6"))
                {
                    txtTotalEmployees.Text = ds.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                    txtTotalEmployees_TextChanged(this, EventArgs.Empty);
                    txtprincipalNumber.Text = ds.Tables[0].Rows[0]["Principleempnumber"].ToString();
                    if (ds.Tables[0].Rows[0]["PrincipleempDate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempDate"].ToString() == "")
                    {
                        txtdateprincipalemployer.Text = "";
                    }
                    else
                    {
                        txtdateprincipalemployer.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempDate"]).ToString("dd-MM-yyyy");
                    }
                    string chkzonesstr = ds.Tables[0].Rows[0]["PrincipleempZone"].ToString();
                    if (!string.IsNullOrEmpty(chkzonesstr))
                    {
                        string[] zonesstr = chkzonesstr.Split(',');
                        foreach (string name in zonesstr)
                        {
                            int index = chkzones.Items.IndexOf(chkzones.Items.FindByValue(name));
                            if (index >= 0)
                            {
                                chkzones.Items[index].Selected = true;
                            }
                        }
                    }
                    if (ds.Tables[0].Rows[0]["PrincipleempCommenceDate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempCommenceDate"].ToString() == "")
                    {
                    }
                    else
                    {
                        txtcontractcommence.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempCommenceDate"]).ToString("dd-MM-yyyy");
                    }
                    if (ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"].ToString() == null || ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"].ToString() == "")
                    {
                    }
                    else
                    {
                        txtEndDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PrincipleempCommenceEnddate"]).ToString("dd-MM-yyyy");
                    }

                    txtprvprincipal.Text = ds.Tables[0].Rows[0]["NoofworkersunderPrePrincipalEmployer"].ToString();
                }

                txtNatureofBusinessAct1.Text = ds.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                if (LabourActid.Contains("1") || LabourActid.Contains("2") || LabourActid.Contains("5"))
                {
                    if (ds.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString() != "")
                    {
                        txtDateofCommenceAct1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Form1_1_DateofCommencement"]).ToString("dd-MM-yyyy");
                    }
                }
                
                try
                {
                    //txtDirFullName.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                    //txtDirDoorNo.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                    //ddlDirDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                    //ddlDirDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddlDirMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                    //ddlDirMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    //ddlDirVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString(); //commented
                    if (ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString() == null)
                    {
                        txtDirFullName.Enabled = true;
                        txtDirFullName.ReadOnly = false;
                    }
                    else
                    {
                        txtDirFullName.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();

                    }

                    if (ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString() == null)
                    {
                        txtDirDoorNo.Enabled = true;
                        txtDirDoorNo.ReadOnly = false;
                    }
                    else
                    {
                        txtDirDoorNo.Text = ds.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();

                    }

                    if (ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString() == null)
                    {
                        ddlDirDistrict.Enabled = true;

                    }
                    else
                    {
                        ddlDirDistrict.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                        ddlDirDistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString() == null)
                    {
                        ddlDirMandal.Enabled = true;

                    }
                    else
                    {
                        ddlDirMandal.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                        ddlDirMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString() == "" || ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString() == null)
                    {
                        ddlDirVillage.Enabled = true;

                    }
                    else
                    {
                        ddlDirVillage.SelectedValue = ds.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        catch (Exception ex)
        {
            lblmsg0.Text = ex.ToString();
            Failure.Visible = true;
        }
        finally
        {
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
    protected DataTable BindWorkerPlaceGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Work_Place");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
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
    //protected void gvEmployeeNames_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        lblmsg.Text = "";
    //        int valid = 0;
    //        if (e.CommandName == "Add")
    //        {
    //            dt = BindgvEmployeeNamesGridAdd();
    //            String[] arraydata = new String[3];

    //            int gvrcnt = gvEmployeeNames.Rows.Count;
    //            decimal extent = 0;
    //            for (int i = 0; i < gvrcnt; i++)
    //            {
    //                DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
    //                DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

    //                GridViewRow gvr = gvEmployeeNames.Rows[i];
    //                TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
    //                arraydata[0] = ddlOccupation.SelectedValue;
    //                arraydata[1] = txtEmployeeName.Text;
    //                arraydata[2] = ddlGender.SelectedValue;


    //                if (txtEmployeeName.Text == "" || ddlOccupation.SelectedValue == "0" || ddlGender.SelectedValue == "0")// || txtEnjExtent.Value == "")
    //                {
    //                    valid = 1;
    //                    lblmsg.Text = "Please enter Employee details";
    //                    lblmsg.CssClass = "errormsg";
    //                }

    //                dt.Rows[i].ItemArray = arraydata;
    //                DataRow dRow;
    //                dRow = null;
    //                dRow = dt.NewRow();
    //                dt.Rows.Add(dRow);
    //            }


    //            if (valid == 0)
    //            {
    //                ViewState["dtEmplyoees"] = dt;
    //                gvEmployeeNames.DataSource = dt;
    //                gvEmployeeNames.DataBind();
    //            }
    //            //SetFocus(gvEnjoyer);
    //        }
    //        else if (e.CommandName == "Remove")
    //        {
    //            int gvrcnt = gvEmployeeNames.Rows.Count;
    //            if (gvrcnt > 1)
    //            {
    //                dt = BindgvEmployeeNamesGridAdd();
    //                String[] arraydata = new String[3];

    //                int j = Convert.ToInt32(e.CommandArgument);
    //                int i;
    //                for (i = 0; i < gvrcnt; i++)
    //                {

    //                    if (i != j)
    //                    {
    //                        DropDownList ddlOccupation = (DropDownList)gvEmployeeNames.Rows[i].Cells[1].Controls[1]; //(DropDownList)e.Row.Cells[2].Controls[1];
    //                        DropDownList ddlGender = (DropDownList)gvEmployeeNames.Rows[i].Cells[3].Controls[1];

    //                        GridViewRow gvr = gvEmployeeNames.Rows[i];
    //                        TextBox txtEmployeeName = (TextBox)gvr.FindControl("txtEmployeeNameAct1");
    //                        arraydata[0] = ddlOccupation.SelectedValue;
    //                        arraydata[1] = txtEmployeeName.Text;
    //                        arraydata[2] = ddlGender.SelectedValue;

    //                        DataRow dRow;
    //                        dRow = null;
    //                        dRow = dt.NewRow();
    //                        dt.Rows.Add(dRow);

    //                        dt.Rows[i].ItemArray = arraydata;
    //                    }
    //                }
    //                dt.Rows.RemoveAt(j);
    //                ViewState["dtEmplyoees"] = dt;
    //                gvEmployeeNames.DataSource = dt;
    //                gvEmployeeNames.DataBind();
    //            }
    //            else
    //            {
    //                lblmsg.Text = "Cannot remove the details, Please modify";
    //                lblmsg.CssClass = "errormsg";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}
   
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

                        //((TextBox)c).ReadOnly = true;
                        //break;
                        TextBox txt = (TextBox)c;

                        string[] exemptTextBoxes = { "txtNatureofBusinessAct1" };

                        if (!exemptTextBoxes.Contains(txt.ID))
                        {
                            if (!string.IsNullOrWhiteSpace(txt.Text))
                            {
                                txt.Enabled = false;
                            }
                        }
                        else
                        {
                            txt.Enabled = true;
                        }
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

    //protected void txtAbove18Male_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
    //        if (txtAbove18Male.Text.Trim() != "")
    //            Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
    //        if (txtAbove18Female.Text.Trim() != "")
    //            Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
    //        if (txtBelow18Male.Text.Trim() != "")
    //            Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
    //        if (txtBelow18FeMale.Text.Trim() != "")
    //            Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

    //        totalAbove18Emp = Above18Male + Above18Female;
    //        totalBelow18Emp = Below18Male + Below18Female;
    //        totalEmp = totalAbove18Emp + totalBelow18Emp;

    //        txtTotalEmployees.Text = totalEmp.ToString();
    //        txtTotalAbove18.Text = totalAbove18Emp.ToString();
    //        txtTotalBelow18.Text = totalBelow18Emp.ToString();
    //        txtBelow18Male.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}
    //protected void txtAbove18Female_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
    //        if (txtAbove18Male.Text.Trim() != "")
    //            Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
    //        if (txtAbove18Female.Text.Trim() != "")
    //            Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
    //        if (txtBelow18Male.Text.Trim() != "")
    //            Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
    //        if (txtBelow18FeMale.Text.Trim() != "")
    //            Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

    //        totalAbove18Emp = Above18Male + Above18Female;
    //        totalBelow18Emp = Below18Male + Below18Female;
    //        totalEmp = totalAbove18Emp + totalBelow18Emp;

    //        txtTotalEmployees.Text = totalEmp.ToString();
    //        txtTotalAbove18.Text = totalAbove18Emp.ToString();
    //        txtTotalBelow18.Text = totalBelow18Emp.ToString();
    //        txtBelow18FeMale.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}

    //protected void txtBelow18FeMale_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
    //        if (txtAbove18Male.Text.Trim() != "")
    //            Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
    //        if (txtAbove18Female.Text.Trim() != "")
    //            Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
    //        if (txtBelow18Male.Text.Trim() != "")
    //            Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
    //        if (txtBelow18FeMale.Text.Trim() != "")
    //            Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

    //        totalAbove18Emp = Above18Male + Above18Female;
    //        totalBelow18Emp = Below18Male + Below18Female;
    //        totalEmp = totalAbove18Emp + totalBelow18Emp;

    //        txtTotalEmployees.Text = totalEmp.ToString();
    //        txtTotalAbove18.Text = totalAbove18Emp.ToString();
    //        txtTotalBelow18.Text = totalBelow18Emp.ToString();
    //        txtBelow18FeMale.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}
    //protected void txtBelow18Male_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int totalEmp = 0, Above18Male = 0, Above18Female = 0, Below18Male = 0, Below18Female = 0, totalAbove18Emp = 0, totalBelow18Emp = 0;
    //        if (txtAbove18Male.Text.Trim() != "")
    //            Above18Male = Convert.ToInt32(txtAbove18Male.Text.Trim());
    //        if (txtAbove18Female.Text.Trim() != "")
    //            Above18Female = Convert.ToInt32(txtAbove18Female.Text.Trim());
    //        if (txtBelow18Male.Text.Trim() != "")
    //            Below18Male = Convert.ToInt32(txtBelow18Male.Text.Trim());
    //        if (txtBelow18FeMale.Text.Trim() != "")
    //            Below18Female = Convert.ToInt32(txtBelow18FeMale.Text.Trim());

    //        totalAbove18Emp = Above18Male + Above18Female;
    //        totalBelow18Emp = Below18Male + Below18Female;
    //        totalEmp = totalAbove18Emp + totalBelow18Emp;

    //        txtTotalEmployees.Text = totalEmp.ToString();
    //        txtTotalAbove18.Text = totalAbove18Emp.ToString();
    //        txtTotalBelow18.Text = totalBelow18Emp.ToString();
    //        txtAbove18Female.Focus();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            LabourActid = ViewState["LabourActId"].ToString();
            if (LabourActid.Contains("5"))
            {
                string message = "";
                if (lblPERCert.Text == "" && lblEmpFrmV.Text == "" && lblAttachChallan.Text == "")
                {
                    message = "Please Upload Principal Employer Regitration Certificate \\nPlease Upload Principal Employer in Form V \\Please Upload Security Deposit Attach Challan";
                }
                else if (lblPERCert.Text == "")
                {
                    message = "Please Upload Principal Employer Regitration Certificate";
                }
                else if (lblEmpFrmV.Text == "")
                {
                    message = "Please Upload Principal Employer in Form V";
                }
                else if (lblAttachChallan.Text == "")
                {
                    message = "Please Upload Security Deposit Attach Challan";
                }
                //else if (Label6.Text == "")  //not neccessary as this tr is commented for LabourActid=5
                //{
                //    message = "Please Upload Principal Employers Registration Certificate";
                //}
                if (message != "")
                {
                    success.Visible = false;
                    Failure.Visible = false;
                    string message1 = "alert('" + message + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    return;
                }
            }
            int valid = 0;
            valid = SaveLabourDetails();
            lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
            success.Visible = true;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";

        }
    }
    private int SaveLabourDetails()
    {
        
        LabourActVO_ContraactLicense oLabourActVO_ContraactLicense = new LabourActVO_ContraactLicense();
        


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



        LabourActVO labouractvo = new LabourActVO();
        labouractvo.QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
        labouractvo.intCFEEnterpid = Convert.ToInt32(Request.QueryString[0].ToString());

        //labouractvo.EstClassification = ddlEstClassification.SelectedValue;
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

        //labouractvo.ManagerResidenceAct1 = Rd_ManagerResidenceAct1.SelectedValue;
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
        labouractvo.ManagerPINCode = txtmanageragenpincode.Text;
        labouractvo.ManagerAddress = txtmanageragenAddress.Text;

        labouractvo.NatureofBusinessAct1 = txtNatureofBusinessAct1.Text;
        labouractvo.DateofCommenceAct1 = DateTimeConversion(txtDateofCommenceAct1.Text);

        if (txtTotalEmployees.Text.Trim() != "")
            labouractvo.TotalEmployees = Convert.ToInt32(txtTotalEmployees.Text);
        //if (txtAbove18Male.Text.Trim() != "")
        //    labouractvo.Above18Male = Convert.ToInt32(txtAbove18Male.Text);
        //if (txtBelow18Male.Text.Trim() != "")
        //    labouractvo.Below18Male = Convert.ToInt32(txtBelow18Male.Text);
        //if (txtAbove18Female.Text.Trim() != "")
        //    labouractvo.Above18FeMale = Convert.ToInt32(txtAbove18Female.Text);
        //if (txtBelow18FeMale.Text.Trim() != "")
        //    labouractvo.Below18FeMale = Convert.ToInt32(txtBelow18FeMale.Text);
        //if (txtTotalAbove18.Text.Trim() != "")
        //    labouractvo.TotalAbove18 = Convert.ToInt32(txtTotalAbove18.Text);
        //if (txtTotalBelow18.Text.Trim() != "")
        //    labouractvo.TotalBelow18 = Convert.ToInt32(txtTotalBelow18.Text);


        //foreach (GridViewRow gvrow in gvWorkerDtls.Rows)
        //{
        //    LabourWorkPlace workplaceVo = new LabourWorkPlace();
        //    DropDownList ddlWorkPlace = (DropDownList)gvrow.FindControl("ddlWorkPlace");
        //    TextBox txtDoorNo = (TextBox)gvrow.FindControl("txtDoorNo");
        //    TextBox txtLocality = (TextBox)gvrow.FindControl("txtLocality");
        //    workplaceVo.WorkPlace = ddlWorkPlace.SelectedValue;
        //    workplaceVo.DoorNo = txtDoorNo.Text.Trim();
        //    workplaceVo.Locality = txtLocality.Text.Trim();

        //    lstworkplaceVo.Add(workplaceVo);
        //}
        //foreach (GridViewRow gvrow in gvFamilyMembersAct1.Rows)
        //{
        //    FamilyMembersAct1 familyMembersActVo = new FamilyMembersAct1();

        //    DropDownList ddlRelationshipAct1 = (DropDownList)gvrow.FindControl("ddlRelationshipAct1");
        //    DropDownList ddlFamilyGenderAct1 = (DropDownList)gvrow.FindControl("ddlFamilyGenderAct1");
        //    DropDownList ddlFamilyAdultAct1 = (DropDownList)gvrow.FindControl("ddlFamilyAdultAct1");
        //    TextBox txtFamilyNameAct1 = (TextBox)gvrow.FindControl("txtFamilyNameAct1");
        //    familyMembersActVo.RelationshipAct1 = ddlRelationshipAct1.SelectedValue;
        //    familyMembersActVo.FamilyNameAct1 = txtFamilyNameAct1.Text;
        //    familyMembersActVo.GenderAct1 = ddlFamilyGenderAct1.SelectedValue;

        //    familyMembersActVo.AdultAct1 = ddlFamilyAdultAct1.SelectedValue;

        //    lstfamilyMembersActVo.Add(familyMembersActVo);
        //}
        //foreach (GridViewRow gvrow in gvEmployeeNames.Rows)
        //{
        //    EmployeesDetails employeeDetailsVo = new EmployeesDetails();

        //    DropDownList ddlOccupationAct1 = (DropDownList)gvrow.FindControl("ddlOccupationAct1");
        //    DropDownList ddlEmployeeGenderAct1 = (DropDownList)gvrow.FindControl("ddlEmployeeGenderAct1");

        //    TextBox txtEmployeeNameAct1 = (TextBox)gvrow.FindControl("txtEmployeeNameAct1");
        //    employeeDetailsVo.Occupation = ddlOccupationAct1.SelectedValue;
        //    employeeDetailsVo.EmployeeNameAct1 = txtEmployeeNameAct1.Text.Trim();
        //    employeeDetailsVo.EmployeeGenderAct1 = ddlEmployeeGenderAct1.SelectedValue;

        //    lstemployeeDetailsVo.Add(employeeDetailsVo);
        //}
        ///////////////////act2 //////////
        labouractvo.FullNamePerAct2 = txtFullNamePermAct2.Text;
        labouractvo.PerDoorNoAct2 = txtDoorNoPermAct2.Text;
        labouractvo.PerPincode = txtPinCodePermAct2.Text;
        labouractvo.PerDistrict = ddlDistrictPermAct2.SelectedValue;
        labouractvo.PerMandal = ddlMandalPermAct2.SelectedValue;
        labouractvo.PerVillage = ddlVillagePermAct2.SelectedValue;
        labouractvo.CompletionDateAct2 = DateTimeConversion(txtEstDateCompAct2.Text);
        ///////////////////act2 completed //////////
        ///////////////////act3 //////////
        //labouractvo.RegActId = ddlSchemAct3.SelectedValue;
        //labouractvo.LicenseRegNo = txtRegLicAct3.Text;
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





        labouractvo.Firmname = txtContractorName.Text;
        labouractvo.Mobile = txtContractorMobile.Text;
        labouractvo.Email = txtContractorEmail.Text;
        labouractvo.FName = txtContractorFname.Text;
        labouractvo.DoorNo = txtContractorDoorNo.Text;
        labouractvo.Locality = txtContractorLocality.Text;
        labouractvo.District = ddlContractorDistrict.SelectedValue;
        labouractvo.Mandal = ddlContractorMandal.SelectedValue;
        labouractvo.Village = ddlContractorVillage.SelectedValue;
        labouractvo.pincode = txtContractorPincode.Text;
        labouractvo.OtherStateAddress = txtContractorOtherStateAddress.Text;
        labouractvo.Dob = (txtContractorDob.Text);
        labouractvo.Age = txtContractorAge.Text;
        labouractvo.TypeOfBusiness = ddlTypeOfBussiness.SelectedValue;
        labouractvo.EstablishmentNumber = txtEstRegNumber.Text;
        labouractvo.EstablishmentDate = DateTimeConversion(txtRegEstdate.Text);
        labouractvo.ConvictedFlag = rdlOptList1.SelectedValue;
        labouractvo.AnyOrderFlag = rdlOptList2.SelectedValue;
        labouractvo.AnyEstablishFlag = rdlOptList3.SelectedValue;
        labouractvo.EstablishmentRegCertificateFilename = lblPERCert.Text;
        labouractvo.PEFormVFileName = lblEmpFrmV.Text;
        labouractvo.ConvictedDetails = txtOpt1.Text;
        labouractvo.AnyOrderDate = DateTimeConversion(txtOpt2.Text);
        labouractvo.AnyEstablishDetails = txtOpt3.Text;

        labouractvo.SecurityDepositPaid = txtAmountPaid.Text;
        labouractvo.SecurityDepositPayable = txtAmountPayable.Text;
        labouractvo.SecurityDepositChallanNo = txtChallanNo.Text;
        labouractvo.SecurityDepositChallanDate = txtchallandate.Text;
        labouractvo.SecurityDepositChallanFilename = lblAttachChallan.Text;
        labouractvo.MaxNoEmployed = txtMaxMigrantNo.Text.ToString() == "" ? 0 : Convert.ToInt32(txtMaxMigrantNo.Text);

        labouractvo.Principleempnumber = txtprincipalNumber.Text;
        labouractvo.PrincipleempDate = DateTimeConversion(txtdateprincipalemployer.Text);

        foreach (ListItem li in chkzones.Items)
        {
            if (li.Selected)
            {
                if (labouractvo.PrincipleempZone == "")
                {
                    labouractvo.PrincipleempZone = li.Value;
                }
                else
                {
                    labouractvo.PrincipleempZone = labouractvo.PrincipleempZone + "," + li.Value;
                }

            }
        }

        labouractvo.PrincipleempCommenceDate = DateTimeConversion(txtcontractcommence.Text);
        labouractvo.PrincipleempCommenceEnddate = DateTimeConversion(txtEndDate.Text);

        labouractvo.NoofworkersunderallContractorsofthePrincipalEmployer = txtprvprincipal.Text;






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
        int valid = Gen.InsertLabourDetails(labouractvo, oLabourActVO_ContraactLicense, lstworkplaceVo, lstemployeeDetailsVo, lstfamilyMembersActVo, lstContractorVoAct3, lstContractorVoAct4);
        return valid;
        //return 0;
    }

    public string DateTimeConversion(string date)
    {
        string dd = "";
        if (date != "")
        {
            if (date.Contains("-"))
            {
                string[] dt = date.Split('-');
                dd = dt[1].ToString() + "/" + dt[0].ToString() + "/" + dt[2].ToString();
            }
            else if (date.Contains("/"))
            {
                string[] dt1 = date.Split('/');
                dd = dt1[1].ToString() + "/" + dt1[0].ToString() + "/" + dt1[2].ToString();
            }
        }
        return dd;
    }

    //public string DateTimeConversion(string date)
    //{
    //    string dd = "";
    //    if (date != "")
    //    {
    //        string[] dt = date.Split('-');
    //        dd = dt[1].ToString() + "/" + dt[0].ToString() + "/" + dt[2].ToString();
    //    }
    //    return dd;
    //}
    public string DateTimeConversion1(string date)
    {
        string dd = "";
        if (date != "")
        {
            string[] dt = date.Split('/');
            dd = dt[1].ToString() + "/" + dt[0].ToString() + "/" + dt[2].ToString();
        }
        return dd;
    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }

        if (btnNext.Text == "Next")
        {
            LabourActid = ViewState["LabourActId"].ToString();
            if (LabourActid.Contains("5"))
            {
                string message = "";
                if (lblPERCert.Text == "" && lblEmpFrmV.Text == "" && lblAttachChallan.Text == "")
                {
                    message = "Please Upload Principal Employer Regitration Certificate \\nPlease Upload Principal Employer in Form V \\Please Upload Security Deposit Attach Challan";
                }
                else if (lblPERCert.Text == "")
                {
                    message = "Please Upload Principal Employer Regitration Certificate";
                }
                else if (lblEmpFrmV.Text == "")
                {
                    message = "Please Upload Principal Employer in Form V";
                }
                else if (lblAttachChallan.Text == "")
                {
                    message = "Please Upload Security Deposit Attach Challan";
                }
                else if (lblPERCert.Text == "")
                {
                    message = "Please Upload Principal Employers Registration Certificate";
                }
                if (message != "")
                {
                    success.Visible = false;
                    Failure.Visible = false;
                    string message1 = "alert('" + message + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    return;
                }
            }



            DataSet ds = new DataSet();
            //Response.Write(hdfFlagID0.Value.ToString());
            //return;
            //ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            int valid = 0;
            valid = SaveLabourDetails();

            Response.Redirect("frmPowerCeig.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 
            // Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N"); //lavanya new 

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
        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        // Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "P");

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
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

    //public void BindRegisteredActs()
    //{
    //    try
    //    {
    //        DataSet dsd = new DataSet();
    //        ddlSchemAct3.Items.Clear();
    //        int QuestionnaireId = Convert.ToInt32(Session["Applid"].ToString());
    //        dsd = Gen.getLabourRegisteredActs(hdfFlagID0.Value.ToString(), QuestionnaireId);
    //        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
    //        {
    //            ddlSchemAct3.DataSource = dsd.Tables[0];
    //            ddlSchemAct3.DataValueField = "Application_Id";
    //            ddlSchemAct3.DataTextField = "Application_Name";
    //            ddlSchemAct3.DataBind();
    //            ddlSchemAct3.Items.Insert(0, "--Select--");
    //        }
    //        else
    //        {
    //            ddlSchemAct3.Items.Insert(0, "--Select--");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblerror.Text = ex.Message;
    //        //lblerror.CssClass = "errormsg";
    //    }
    //}

    //protected void gvContractorAct3_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        lblmsg.Text = "";
    //        int valid = 0;
    //        if (e.CommandName == "Add")
    //        {
    //            dt = BindContractorAct3GridAdd();

    //            TextBox txtContractor;
    //            TextBox txtAddress;
    //            // TextBox txtMobileNo;
    //            TextBox txtWorkNature;
    //            TextBox txtMaxNoWorkmen;
    //            TextBox txtCommenceDate;
    //            TextBox txtCompleteDate;
    //            TextBox txtManufacturingDepts;
    //            String[] arraydata = new String[7];

    //            int gvrcnt = gvContractorAct3.Rows.Count;

    //            for (int i = 0; i < gvrcnt; i++)
    //            {

    //                GridViewRow gvr = gvContractorAct3.Rows[i];
    //                txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
    //                arraydata[0] = txtContractor.Text;
    //                txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
    //                arraydata[1] = txtAddress.Text;

    //                txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
    //                arraydata[2] = txtWorkNature.Text;
    //                txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
    //                arraydata[3] = txtManufacturingDepts.Text;
    //                txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
    //                arraydata[4] = txtCommenceDate.Text;
    //                txtMaxNoWorkmen = (TextBox)gvr.FindControl("txtMaxNoofContractLabour");
    //                arraydata[5] = txtMaxNoWorkmen.Text;
    //                txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
    //                arraydata[6] = txtCompleteDate.Text;

    //                dt.Rows[i].ItemArray = arraydata;
    //                DataRow dRow;
    //                dRow = null;
    //                dRow = dt.NewRow();
    //                dt.Rows.Add(dRow);
    //            }

    //            if (valid == 0)
    //            {
    //                ViewState["dtContractorDtls3"] = dt;
    //                gvContractorAct3.DataSource = dt;
    //                gvContractorAct3.DataBind();
    //            }
    //        }
    //        else if (e.CommandName == "Remove")
    //        {
    //            int gvrcnt = gvContractorAct3.Rows.Count;
    //            if (gvrcnt > 1)
    //            {
    //                dt = BindContractorAct3GridAdd();
    //                String[] arraydata = new String[7];

    //                int j = Convert.ToInt32(e.CommandArgument);
    //                int i;
    //                for (i = 0; i < gvrcnt; i++)
    //                {

    //                    if (i != j)
    //                    {
    //                        TextBox txtContractor;
    //                        TextBox txtAddress;
    //                        TextBox txtWorkNature;
    //                        TextBox txtMaxNoWorkmen;
    //                        TextBox txtCommenceDate;
    //                        TextBox txtCompleteDate;
    //                        TextBox txtManufacturingDepts;

    //                        GridViewRow gvr = gvContractorAct3.Rows[i];
    //                        txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
    //                        arraydata[0] = txtContractor.Text;
    //                        txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");
    //                        arraydata[1] = txtAddress.Text;
    //                        txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");
    //                        arraydata[2] = txtWorkNature.Text;
    //                        txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
    //                        arraydata[3] = txtManufacturingDepts.Text;
    //                        txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
    //                        arraydata[4] = txtCommenceDate.Text;
    //                        txtMaxNoWorkmen = (TextBox)gvr.FindControl("txtMaxNoofContractLabour");
    //                        arraydata[5] = txtMaxNoWorkmen.Text;
    //                        txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");
    //                        arraydata[6] = txtCompleteDate.Text;

    //                        if (j == 0)
    //                            dt.Rows[i - 1].ItemArray = arraydata;
    //                        else
    //                            dt.Rows[i].ItemArray = arraydata;


    //                        DataRow dRow;
    //                        dRow = null;
    //                        dRow = dt.NewRow();
    //                        dt.Rows.Add(dRow);
    //                    }
    //                }
    //                dt.Rows.RemoveAt(i - 1);
    //                ViewState["dtContractorDtls3"] = dt;
    //                gvContractorAct3.DataSource = dt;
    //                gvContractorAct3.DataBind();
    //            }
    //            else
    //            {
    //                lblmsg.Text = "Cannot remove the details, Please modify";
    //                lblmsg.CssClass = "errormsg";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}

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

    //protected void gvContractorAct3_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            DataTable dt = (DataTable)ViewState["dtContractorDtls3"];

    //            if (dt != null)
    //            {
    //                if (e.Row.RowIndex < dt.Rows.Count)
    //                {
    //                    GridViewRow gvr = e.Row;
    //                    TextBox txtContractor = (TextBox)gvr.FindControl("txtContractorNameAct4");
    //                    TextBox txtAddress = (TextBox)gvr.FindControl("txtContractorAddressAct4");

    //                    TextBox txtManufacturingDepts = (TextBox)gvr.FindControl("txtManufacturingDepts");
    //                    TextBox txtWorkNature = (TextBox)gvr.FindControl("txtContractorNatureAct4");

    //                    TextBox txtNoWorkmen = (TextBox)gvr.FindControl("txtMaxNoofContractLabour");
    //                    TextBox txtCommenceDate = (TextBox)gvr.FindControl("txtContractorCommenceAct4");
    //                    TextBox txtCompleteDate = (TextBox)gvr.FindControl("txtContractorCompAct4");

    //                    txtContractor.Text = dt.Rows[e.Row.RowIndex]["Contractor_Name"].ToString();
    //                    txtAddress.Text = dt.Rows[e.Row.RowIndex]["Contractor_Address"].ToString();
    //                    txtManufacturingDepts.Text = dt.Rows[e.Row.RowIndex]["Contractor_ManufacturingDepts"].ToString();
    //                    txtWorkNature.Text = dt.Rows[e.Row.RowIndex]["Contractor_Work_Nature"].ToString();
    //                    txtNoWorkmen.Text = dt.Rows[e.Row.RowIndex]["Contractor_MaxWorkers"].ToString();
    //                    txtCommenceDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Commence_Dt"].ToString();
    //                    txtCompleteDate.Text = dt.Rows[e.Row.RowIndex]["Contractor_Est_Compltd_Dt"].ToString();

    //                    if (txtNoWorkmen.Text.Trim() != "")
    //                    {
    //                        totalContractEmployees = totalContractEmployees + Convert.ToInt32(txtNoWorkmen.Text.Trim());
    //                    }
    //                }
    //            }
    //            txtTotalContractors.Text = totalContractEmployees.ToString();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //        lblmsg.CssClass = "errormsg";
    //    }
    //}

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
                    dt = BindContractorGridAdd();
                    ViewState["dtContractorDtls4"] = dt;
                    gvContractorAct4.DataSource = dt;
                    gvContractorAct4.DataBind();
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
        // valid = SaveLabourDetails();
        string intApprovalid = Request.QueryString["intApprovalid"].ToString();
        Callwebservice(intApprovalid);
        lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
        //this.Clear();
        success.Visible = true;
        Failure.Visible = false;
    }

    public void Callwebservice(string deptid)
    {
        LabourQueryResponseCFE.TSLabourServiceImplService labourservice = new LabourQueryResponseCFE.TSLabourServiceImplService();
        string UIDNO = "";
        DataSet dsdatanew = new DataSet();
        dsdatanew = (DataSet)Session["dscheck"];
        if (dsdatanew != null && dsdatanew.Tables.Count > 2 && dsdatanew.Tables[2].Rows.Count > 0)
        {
            UIDNO = dsdatanew.Tables[2].Rows[0]["UID_No"].ToString();
        }
        if (deptid == "47")
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();


            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            LabourQueryResponseCFE.act labouract = new LabourQueryResponseCFE.act();
            LabourQueryResponseCFE.actsResponse labourout = new LabourQueryResponseCFE.actsResponse();
            LabourQueryResponseCFE.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFE.contractLabourPrincipalEmployer();
            LabourQueryResponseCFE.buildingotherconstructions labour = new LabourQueryResponseCFE.buildingotherconstructions();
            LabourQueryResponseCFE.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFE.ismwPrincipalEmployer();

            string actids = "";
            string actid = "";
            actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
            string[] split = actids.Split(',');
            if (actids.Contains("2"))//The Buildings & Other Construction Workers Act
            {
                labouract.buildingRegistrationActSelected = true;
                labour.actID = dsdept.Tables[0].Rows[0]["actID"].ToString();
                //labour.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                //labour.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //labour.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                //labour.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                //labour.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                //labour.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                //labour.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                //labour.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                labour.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                labour.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                labour.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                labour.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                labour.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                labour.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                labour.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                labour.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                labour.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                labour.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                labour.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                labour.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                labour.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                labour.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                labour.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                labour.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                labour.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                labour.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                labour.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                labour.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                labour.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                labour.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                labour.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                //labour.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                labour.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                labour.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                labour.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                //labour.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                //labour.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                //labour.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                //labour.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                labour.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                //labour.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                //labour.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                //labour.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                labour.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                //labour.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                //labour.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                //labour.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                //labour.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                //labour.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                //labour.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                //labour.transaction_status = "Y";
                //labour.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                //labour.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                labour.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                // labour.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                // labour.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                // labour.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                labouract.buildingRegistrationActData = labour;

                labourout = labourservice.actSelected(labouract);
                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    // Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                    //  Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                }
            }
        }
        if (deptid == "48")
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            LabourQueryResponseCFE.act labouract = new LabourQueryResponseCFE.act();
            LabourQueryResponseCFE.actsResponse labourout = new LabourQueryResponseCFE.actsResponse();
            LabourQueryResponseCFE.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFE.contractLabourPrincipalEmployer();
            LabourQueryResponseCFE.buildingotherconstructions labour = new LabourQueryResponseCFE.buildingotherconstructions();
            LabourQueryResponseCFE.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFE.ismwPrincipalEmployer();



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
                //contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                // contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
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
                //contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
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

                LabourQueryResponseCFE.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                //contractvo.contractorParticulars[] lstitem = null;
                ContractorDetails co = new ContractorDetails();
                //FactoryService.rawMaterial[] lst = null;
                if (dsdept.Tables[1].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdept.Tables[1];
                    contractmulti = new LabourQueryResponseCFE.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                    for (int k = 0; k < dtraw.Rows.Count; k++)
                    {
                        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                        LabourQueryResponseCFE.contractLabourPrincipalEmployerMultiData coc = new LabourQueryResponseCFE.contractLabourPrincipalEmployerMultiData();
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
                labourout = labourservice.actSelected(labouract);
                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    // Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    //  Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                }
            }
        }
        if (deptid == "49")
        {
            DataSet dsdept = new DataSet();
            DataSet dsdeptattachments = new DataSet();
            DataSet dsuidno = new DataSet();
            Session["Applid"].ToString();
            dsdept = Gen.getdepartmentdetailsonuid(UIDNO, deptid);
            LabourQueryResponseCFE.act labouract = new LabourQueryResponseCFE.act();
            LabourQueryResponseCFE.actsResponse labourout = new LabourQueryResponseCFE.actsResponse();
            LabourQueryResponseCFE.contractLabourPrincipalEmployer contractvo = new LabourQueryResponseCFE.contractLabourPrincipalEmployer();
            LabourQueryResponseCFE.buildingotherconstructions labour = new LabourQueryResponseCFE.buildingotherconstructions();
            LabourQueryResponseCFE.ismwPrincipalEmployer migrateemployer = new LabourQueryResponseCFE.ismwPrincipalEmployer();

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
                // migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
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
                //migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
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

                //LabourQueryResponseCFE.ismwPrincipalEmployerMultiData[] migrantvo = null;
                //ContractorDetails co = new ContractorDetails();
                ////FactoryService.rawMaterial[] lst = null;
                //if (dsdept.Tables[1].Rows.Count > 0)
                //{
                //    DataTable dtraw = new DataTable();
                //    dtraw = dsdept.Tables[1];
                //    migrantvo = new LabourQueryResponseCFE.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                //    for (int k = 0; k < dtraw.Rows.Count; k++)
                //    {
                //        //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                //        LabourQueryResponseCFE.ismwPrincipalEmployerMultiData coc = new LabourQueryResponseCFE.ismwPrincipalEmployerMultiData();
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

                //    }
                //    migrateemployer.contractorParticulars = migrantvo;
                //}

                labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                labourout = labourservice.actSelected(labouract);
                if (labourout.status == "SUCCESS")
                {
                    string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    //  Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labouroutmsg, "Y");
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                }
                else
                {
                    string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                    //  Gen.UpdateDepartwebserviceflag(UIDNO, deptid, "C", labourouterrormsg, "N");
                    updatequerystring(Request.QueryString["Queryid"].ToString());
                }
            }
        }
    }

    public void updatequerystring(string Applicantid)
    {
        try
        {
            string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
            DataSet ds = new DataSet();
            ds = Gen.GetQueryStatusByTransactionID(Applicantid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                int result = 0;
                string queryresopnedesc = "";
                result = Gen.InsertQueryDetails(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, "", "", "", queryresopnedesc, Created_by, "", "", "", getclientIP());

                int j = Gen.UpdateAdditionalpayments(intCFEEnterpid, "", "Completed", Session["uid"].ToString(), "12", intDeptid, intApprovalid, getclientIP());
                try
                {
                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
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

    protected void ddlContractorDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindMandals(ddlContractorDistrict, ddlContractorMandal);
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    protected void ddlContractorMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlContractorMandal, ddlContractorVillage);
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


    protected void rdlOptList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlOptList1.SelectedValue == "Y")
        {
            trtxtOp1.Visible = true;
        }
        else
        {
            trtxtOp1.Visible = false;
            txtOpt1.Text = "";
        }
    }

    protected void rdlOptList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlOptList2.SelectedValue == "Y")
        {
            trtxtOp2.Visible = true;
        }
        else
        {
            trtxtOp2.Visible = false;
            txtOpt2.Text = "";
        }
    }

    protected void rdlOptList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdlOptList3.SelectedValue == "Y")
        {
            trtxtOp3.Visible = true;
        }
        else
        {
            trtxtOp3.Visible = false;
            txtOpt3.Text = "";
        }
    }
   
    protected void btnPERCert_Click(object sender, EventArgs e)
    {




        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        if (fupPERCert.HasFile)
        {
            General t1 = new General();
            if ((fupPERCert.PostedFile != null) && (fupPERCert.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fupPERCert.PostedFile.FileName);
                try
                {
                    string[] fileType = fupPERCert.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder   PERegitrationCertificate
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PERegitrationCertificate");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupPERCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupPERCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PERegitrationCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            // lnkPERCert.Text = fupPERCert.FileName;
                            lblPERCert.Text = fupPERCert.FileName;
                            //   txtPERCert.Text = fupPERCert.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            success.Visible = false;
            Failure.Visible = false;
            string message1 = "alert(Please Upload Principal Employer Regitration Certificate)";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            return;
        }


    }

    protected void BtnFuEmpFrmV_Click(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        if (FuEmpFrmV.HasFile)
        {

            General t1 = new General();
            if ((FuEmpFrmV.PostedFile != null) && (FuEmpFrmV.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FuEmpFrmV.PostedFile.FileName);
                try
                {
                    string[] fileType = FuEmpFrmV.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder  
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PrincipalEmployerFormV");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FuEmpFrmV.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FuEmpFrmV.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CellarFloorPlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            // lnkEmpFrmV.Text = FuEmpFrmV.FileName;
                            lblEmpFrmV.Text = FuEmpFrmV.FileName;
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
            string message1 = "alert(Please Upload Principal Employer Form V)";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            return;

        }

    }

    protected void btnAttachChallan_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

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
                                FuEmpFrmV.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CellarFloorPlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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

    protected void txtTotalEmployees_TextChanged(object sender, EventArgs e)
    {
        string labourid = ViewState["LabourActId"].ToString();
        if (labourid.Contains("6"))
        {
            if (txtTotalEmployees.Text.Trim() != "")
            {
                decimal paybleamount = Convert.ToDecimal(txtTotalEmployees.Text.Trim());
                txtAmountPayable.Text = (paybleamount * 500).ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        if (fluPrincipalEmployersRegistrationCertificate.HasFile)
        {
            General t1 = new General();
            if ((fluPrincipalEmployersRegistrationCertificate.PostedFile != null) && (fluPrincipalEmployersRegistrationCertificate.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fluPrincipalEmployersRegistrationCertificate.PostedFile.FileName);
                try
                {
                    string[] fileType = fluPrincipalEmployersRegistrationCertificate.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder   PERegitrationCertificate
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PrincipalRegitrationCertificate");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fluPrincipalEmployersRegistrationCertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fluPrincipalEmployersRegistrationCertificate.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PrincipalRegitrationCertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            // lnkPERCert.Text = fluPrincipalEmployersRegistrationCertificate.FileName;
                            Label6.Text = fluPrincipalEmployersRegistrationCertificate.FileName;
                            //   txtPERCert.Text = fluPrincipalEmployersRegistrationCertificate.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            success.Visible = false;
            Failure.Visible = false;
            string message1 = "alert(Please Upload Principal Employer Regitration Certificate)";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
            return;
        }



    }
    protected void txtPGNameAct1_TextChanged(object sender, EventArgs e)
    {

    }

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
    protected void txtContractorDob_TextChanged(object sender, EventArgs e)
    {
        DataSet dsage = new DataSet();
        dsage = GETAGE(txtContractorDob.Text.Trim());
        if (dsage.Tables[0].Rows.Count > 0)
        {
            txtContractorAge.Text = Convert.ToString(dsage.Tables[0].Rows[0]["Column1"]);
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