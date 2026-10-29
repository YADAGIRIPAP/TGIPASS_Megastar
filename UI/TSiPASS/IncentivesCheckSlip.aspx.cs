using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;

public partial class UI_TSiPASS_IncentivesAnnexure_IncentivesCheckSlip : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    string attachValue = "0";
    DataSet ds = new DataSet();
    string servManfTest = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        try
        {
            if (Session["uid"] != null)
            {
                string check = Session["rblSector"].ToString();


                //  Session["EntprIncentive"] = "1000";
                if (Session["EntprIncentive"] != null)
                {
                    // ds = (DataSet)Session["incentivedata"];
                    // string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                    string IncentiveId = Session["EntprIncentive"].ToString();
                    //string createdby = Session["uid"].ToString();
                    string createdby = Session["checkCreatedby"].ToString();


                    if (!IsPostBack)
                    {
                        ds = Gen.GETINCENTIVESCHECKLIST(createdby, IncentiveId);
                        FillDetails(ds);
                        BtnPrevious.Visible = true;
                        ddlCOBORROWER.SelectedIndex = 1;
                        ddlCOBORROWER.Enabled = false;
                        if (check != "2")
                        {
                            ddlFacLicense.Enabled = false;
                            ddlFacLicense.SelectedValue = "3";
                            ddlTMCStar.Enabled = false;
                            ddlTMCStar.SelectedValue = "3";
                        }


                    }
                    DataSet dsnew = new DataSet();
                    dsnew = Gen.GETINCENTIVESCAFDATA(createdby, IncentiveId);
                    string applicationStatus = "";
                    string localemp = "";
                    applicationStatus = dsnew.Tables[0].Rows[0]["intStatusid"].ToString();
                    localemp = dsnew.Tables[0].Rows[0]["islocalemp"].ToString();//islocal emp// begin
                    hdncaste.Value = dsnew.Tables[0].Rows[0]["Caste"].ToString();//islocal emp// begin
                    hdnisph.Value = dsnew.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();//islocal emp// begin
                    //sowjanya 05/05/2026
                    hdnMSMEApplied.Value = dsnew.Tables[0].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
                    if (hdnMSMEApplied.Value == "Y")
                    {
                        trMSME1.Visible = true;
                        // trMSME2.Visible = true;
                        trMSME3.Visible = true;
                        trMSME4.Visible = true;
                        trMSME5.Visible = true;
                        lblPCB.Text = "Consent for Operation/Acknowledgement from TGPCB";
                        lblBIS.Text = "Certificate from BIS/ZED Certification";
                    }
                    if (hdnisph.Value != "Y" && (hdncaste.Value == "2" || hdncaste.Value == "1" || hdncaste.Value == "5"))
                    {
                        TRDEETDOCUMENT.Visible = true;
                        TRDEETHEADING.Visible = true;
                        ddldeetregack.SelectedValue = "Y";
                        ddldeetregack.Enabled = false;
                        ddldeetregack_SelectedIndexChanged(sender, e);

                    }
                    else
                    {
                        TRDEETDOCUMENT.Visible = false;
                        TRDEETHEADING.Visible = false;
                    }
                    if (localemp == "Y")
                    {
                        
                        trlocal2.Visible = true;
                        trlocal1.Visible = true;
                        ddladdlocalemp1.Visible = true;
                        ddladdlocalemp2.Visible = true;
                        ddladdlocalemp2.SelectedItem.Text = "YES";
                        ddladdlocalemp1.SelectedItem.Text = "YES";
                        ddladdlocalemp2_SelectedIndexChanged(sender, e);
                        ddladdlocalemp1_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        trlocal2.Visible = false;
                        trlocal1.Visible = false;
                        ddladdlocalemp1.Visible = false;
                        ddladdlocalemp2.Visible = false;

                    }//end
                    if (applicationStatus != "")
                    {
                        if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                        {
                            if (Session["applyagain"] == null)
                            {
                                ResetFormControl(this);
                            }
                            if (dsnew.Tables[0].Rows[0]["Caste"].ToString() == "3" || dsnew.Tables[0].Rows[0]["Caste"].ToString() == "4")
                            {
                                ddlCOBORROWER.SelectedIndex = 1;
                                ddlCOBORROWER.Enabled = false;
                            }
                            //if (ddlCOBORROWER.SelectedIndex.ToString() == "0")
                            //{
                            //    ddlCOBORROWER.SelectedIndex = 1;

                            //}
                        }

                    }

                    //if (HyperLink229.Text == "")
                    //{
                    //    if (HyperLink229.Text == "" || ddlCOBORROWER.SelectedItem.Text.ToString() == "--Select--" || ddlCOBORROWER.SelectedIndex.ToString() == "0")
                    //    //if (ddlCOBORROWER.SelectedIndex.ToString() == "0")
                    //    {
                    //        ddlCOBORROWER.SelectedIndex = 1;
                    //        HyperLink229.Visible = true;
                    //        FileUpload229.Visible = true;
                    //        FileUpload229.Enabled = true;
                    //        Button229.Visible = true;
                    //        Button229.Enabled = true;
                    //    }
                    if (HyperLink229.Text == "" || ddlCOBORROWER.SelectedItem.Text.ToString() == "--Select--" || ddlCOBORROWER.SelectedIndex.ToString() == "0")
                    {
                        ddlCOBORROWER.Enabled = true;
                        FileUpload229.Visible = true;
                        FileUpload229.Enabled = true;

                        Button229.Visible = true;
                        Button229.Enabled = true;
                        //BtnSave.Text
                    }




                    else if (HyperLink229.Text != "" && attachValue == "1")
                    {
                        HyperLink229.Visible = true;
                        FileUpload229.Visible = true;
                        FileUpload229.Enabled = true;
                        Button229.Visible = true;
                        Button229.Enabled = true;
                    }



                    string incentiveid = Session["EntprIncentive"].ToString();
                    string isIncentiveVehicle = Session["Incentive_isVehicle"].ToString();
                    string str1 = Session["Incentive_DateOfCommencement"].ToString();
                    int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                    int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());
                    string GHMC_Flag = Session["Incentive_GHMC"].ToString();
                    int category = Convert.ToInt32(Session["Incentive_Category"]);
                    bool phc = Convert.ToBoolean(0);
                    bool isveh = Convert.ToBoolean(Session["Incentive_isVehicle"]);

                    if (caste != null && caste != 0 && (caste == 3 || caste == 4))
                    {
                        ddlCOBORROWER.SelectedValue = "Y";
                        ddlCOBORROWER.Enabled = false;
                        ddlCOBORROWER_SelectedIndexChanged(sender, e);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string valid = "";


        try
        {
            int i = Convert.ToInt32(ValidateFileUploads());
            if (i == 1)
            {
                lblmsg0.Text = "<font color=Red>Please Upload Mandatory(*) File Uploads</font></br>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Visible = false;
                lblmsg0.Visible = true;
                if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
                {
                    if (Label229.Text == "" || Label229.Text == null || Label229.Text == string.Empty)
                    {
                        lblmsg0.Text = "<font color=Red>Please Upload UNDERTAKING ON CO-BORROWER / CO-APPLICANT / CO-OBLIGANT(T-Pride)</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        BtnNext.Visible = false;
                        lblmsg0.Visible = true;
                    }

                }
            }
            else
            {
                AssignValuesToVosFromControls();
                valid = Gen.InsertCheckSlip(objvoA);

                if (valid == "Y")
                {
                    //lblmsg.Text = "<font color=black>application submitted sucessfully</font>";
                    //success.Visible = true;

                    string message = "alert('Checkslips Uploaded Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnNext.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
                else
                {
                    lblmsg0.Text = "<font color=Red>Submission Failed</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    BtnNext.Visible = false;
                    //BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
            }

        }

        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void AssignValuesToVosFromControls()
    {
        try
        {
            objvoA.CSCreatedBy = Session["uid"].ToString().Trim();
            objvoA.CSIncentiveId = Session["EntprIncentive"].ToString().Trim();
            objvoA.CSbillsofinstitutfinancedEnterpriseindustries = ddlCSbillsofinstitutfinancedEnterpriseindustries.SelectedValue.Trim();
            objvoA.CSbillandpymtproofrespectofselffinancedEnterprisesindustries = ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue.Trim();
            objvoA.CasteCertificatesSCST = ddlCSCasteCertificatesSCST.SelectedValue.Trim();
            objvoA.CSEntrepreneurAadhar = ddlCSEntrepreneurAadhar.SelectedValue.Trim();
            objvoA.CSEntrepreneurPANCard = ddlCSEntrepreneurPANCard.SelectedValue.Trim();
            objvoA.CSCertificateofCA = ddlCSCertificateofCA.SelectedValue.Trim();
            objvoA.CSRegdPartnershipDeedArticles = ddlCSRegdPartnershipDeedArticles.SelectedValue.Trim();
            objvoA.CSApprovalDirectorFactories = ddlCSApprovalDirectorFactories.SelectedValue.Trim();
            objvoA.CSBoilersCertificate = ddlCSBoilersCertificate.SelectedValue.Trim();
            objvoA.CSApprovalDirectorTownCountryPlanningUDA = ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue.Trim();
            objvoA.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat = ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue.Trim();
            objvoA.CSOperationTSPCBAcknowledgementGM = ddlCSOperationTSPCBAcknowledgementGM.SelectedValue.Trim();
            objvoA.CSPowerreleaseCertificatefrmTSTRANSCODISCOM = ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue.Trim();
            objvoA.CSEnvironmentalclearance = ddlCSEnvironmentalclearance.SelectedValue.Trim();
            objvoA.CSOtherstatutoryapprovalsspecif = ddlCSOtherstatutoryapprovalsspecif.SelectedValue.Trim();
            objvoA.CSEMPartIfullsetIEMIL = ddlCSEMPartIfullsetIEMIL.SelectedValue.Trim();
            //objvoA.CSEMPartIIfullsetIEMIL = ddlCSEMPartIIfullsetIEMIL.SelectedValue;
            objvoA.CSUdyogAadhar = ddlCSUdyogAadhar.SelectedValue.Trim();
            objvoA.CSProjectReport = ddlCSProjectReport.SelectedValue.Trim();
            objvoA.CSTermloansanctionletters = ddlCSTermloansanctionletters.SelectedValue.Trim();
            objvoA.CSBoardResolutionauthorizing = ddlCSBoardResolutionauthorizing.SelectedValue.Trim();
            objvoA.CSRegisteredlandSaledeedPremisesLeasedeed = ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue.Trim();
            objvoA.CSCACECertificateregarding2handplantmachinery = ddlCSCACECertificateregarding2handplantmachinery.SelectedValue.Trim();
            objvoA.CSCECertificateSelffabricatedmachinery = ddlCSCECertificateSelffabricatedmachinery.SelectedValue.Trim();
            objvoA.CSBISCertificate = ddlCSBISCertificate.SelectedValue.Trim();
            objvoA.CSDrugLicense = ddlCSDrugLicense.SelectedValue.Trim();
            objvoA.CSExplosiveLicense = ddlCSExplosiveLicense.SelectedValue.Trim();
            objvoA.CSVATCSTSGSTCertificate = ddlCSVATCSTSGSTCertificate.SelectedValue.Trim();
            objvoA.CSFormA = ddlCSFormA.SelectedValue.Trim();
            objvoA.CSFormB = ddlCSFormB.SelectedValue.Trim();
            objvoA.CSProductionParticulars3Years = ddlProductionParticulars3Years.SelectedValue.Trim();
            objvoA.CSRTACertificate = ddlRTACertificate.SelectedValue.Trim();
            objvoA.CSPHCertificate = ddlPHCertificate.SelectedValue.Trim();
            objvoA.CSUndertakingForm = ddlUntertakingForm.SelectedValue.Trim();

            objvoA.ApplicantVehPhoto = ddlApplicantVehiclePhoto.SelectedValue.Trim();
            objvoA.firstsalebill = ddlfirstsalebill.SelectedValue.Trim();
            objvoA.COBORROWER = ddlCOBORROWER.SelectedValue.Trim();
            objvoA.BLAStatementBrw = ddlBLAStatement_Brw.SelectedValue.Trim();
            objvoA.CCCoBorrwers = ddlCCCoBorrwer.SelectedValue.Trim();
            objvoA.FacLicenses = ddlFacLicense.SelectedValue.Trim();
            objvoA.TMCStar = ddlTMCStar.SelectedValue.Trim();
            objvoA.addlocalemp1 = ddladdlocalemp1.SelectedValue.Trim();
            objvoA.addlocalemp2 = ddladdlocalemp2.SelectedValue.Trim();
            objvoA.DEETREGACK = ddldeetregack.SelectedValue.Trim();



        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

        //BtnNext.PostBackUrl = "../../UI/Tsipass/IncetivesNewForm2.aspx";
        BtnNext.PostBackUrl = "~/UI/Tsipass/IncetivesNewForm2.aspx";
        Response.Redirect(BtnNext.PostBackUrl, false);
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            string valid = "";


            int i = Convert.ToInt32(ValidateFileUploads());
            if (i == 1)
            {
                lblmsg0.Text = "<font color=Red>Please Upload Mandatory File Uploads</font>";
                success.Visible = false;
                Failure.Visible = true;
              //  BtnNext.Visible = false;
                lblmsg0.Visible = true;
                if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
                {
                    if (Label229.Text == "" || Label229.Text == null || Label229.Text == string.Empty)
                    {
                        lblmsg0.Text = "<font color=Red>Please Upload UNDERTAKING ON CO-BORROWER / CO-APPLICANT / CO-OBLIGANT(T-Pride)</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                       // BtnNext.Visible = false;
                        lblmsg0.Visible = true;
                    }

                }
            }
            else
            {
                AssignValuesToVosFromControls();
                valid = Gen.InsertCheckSlip(objvoA);

                if (valid == "Y")
                {
                    //lblmsg.Text = "<font color=black>application submitted sucessfully</font>";
                    //success.Visible = true;

                    string message = "alert('Checkslips Uploaded Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnNext.Enabled = true;
                    BtnSave.Enabled = false;
                    //BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                    BtnNext.PostBackUrl = "~/UI/Tsipass/TypeOfIncentivesNew.aspx";
                    Response.Redirect(BtnNext.PostBackUrl, false);
                }
                else
                {
                    lblmsg0.Text = "<font color=Red>Submission Failed</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    BtnNext.Visible = false;
                    //BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
            }


        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
        }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("../../IncentivesCheckSlip.aspx");
    }

    public void FillDetails(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnNext.Enabled = true;
            BtnSave.Enabled = false;
            ddlCSbillsofinstitutfinancedEnterpriseindustries.SelectedValue = ds.Tables[0].Rows[0]["CSbillsofinstitutfinancedEnterpriseindustries"].ToString().Trim();
            ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue = ds.Tables[0].Rows[0]["CSbillandpymtproofrespectofselffinancedEnterprisesindustries"].ToString().Trim();
            ddlCSCasteCertificatesSCST.SelectedValue = ds.Tables[0].Rows[0]["CSCasteCertificatesSCST"].ToString().Trim();
            ddlCSEntrepreneurAadhar.SelectedValue = ds.Tables[0].Rows[0]["CSEntrepreneurAadhar"].ToString().Trim();
            ddlCSEntrepreneurPANCard.SelectedValue = ds.Tables[0].Rows[0]["CSEntrepreneurPANCard"].ToString().Trim();
            ddlCSCertificateofCA.SelectedValue = ds.Tables[0].Rows[0]["CSCertificateofCA"].ToString().Trim();
            ddlCSRegdPartnershipDeedArticles.SelectedValue = ds.Tables[0].Rows[0]["CSRegdPartnershipDeedArticles"].ToString().Trim();
            ddlCSApprovalDirectorFactories.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorFactories"].ToString().Trim();
            ddlCSBoilersCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSBoilersCertificate"].ToString().Trim();
            ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorTownCountryPlanningUDA"].ToString().Trim();
            ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue = ds.Tables[0].Rows[0]["CSRegularbuildingplansapprovalofMunicipalityGramPanchayat"].ToString().Trim();
            ddlCSOperationTSPCBAcknowledgementGM.SelectedValue = ds.Tables[0].Rows[0]["CSOperationTSPCBAcknowledgementGM"].ToString().Trim();
            ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue = ds.Tables[0].Rows[0]["CSPowerreleaseCertificatefrmTSTRANSCODISCOM"].ToString().Trim();
            ddlCSEnvironmentalclearance.SelectedValue = ds.Tables[0].Rows[0]["CSEnvironmentalclearance"].ToString().Trim();
            ddlCSOtherstatutoryapprovalsspecif.SelectedValue = ds.Tables[0].Rows[0]["CSOtherstatutoryapprovalsspecif"].ToString().Trim();
            ddlCSEMPartIfullsetIEMIL.SelectedValue = ds.Tables[0].Rows[0]["CSEMPartIfullsetIEMIL"].ToString().Trim();
            // ddlCSEMPartIIfullsetIEMIL.SelectedValue = ds.Tables[0].Rows[0]["IncentveID"].ToString(); objvoA.CSEMPartIIfullsetIEMIL
            ddlCSUdyogAadhar.SelectedValue = ds.Tables[0].Rows[0]["CSUdyogAadhar"].ToString().Trim();
            ddlCSProjectReport.SelectedValue = ds.Tables[0].Rows[0]["CSProjectReport"].ToString().Trim();
            ddlCSTermloansanctionletters.SelectedValue = ds.Tables[0].Rows[0]["CSTermloansanctionletters"].ToString().Trim();
            ddlCSBoardResolutionauthorizing.SelectedValue = ds.Tables[0].Rows[0]["CSBoardResolutionauthorizing"].ToString().Trim();
            ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue = ds.Tables[0].Rows[0]["CSRegisteredlandSaledeedPremisesLeasedeed"].ToString().Trim();
            ddlCSCACECertificateregarding2handplantmachinery.SelectedValue = ds.Tables[0].Rows[0]["CSCACECertificateregarding2handplantmachinery"].ToString().Trim();
            ddlCSCECertificateSelffabricatedmachinery.SelectedValue = ds.Tables[0].Rows[0]["CSCECertificateSelffabricatedmachinery"].ToString().Trim();

            ddlCSBISCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSBISCertificate"].ToString().Trim();
            ddlCSDrugLicense.SelectedValue = ds.Tables[0].Rows[0]["CSDrugLicense"].ToString().Trim();
            ddlCSExplosiveLicense.SelectedValue = ds.Tables[0].Rows[0]["CSExplosiveLicense"].ToString().Trim();
            ddlCSVATCSTSGSTCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSVATCSTSGSTCertificate"].ToString().Trim();
            ddlCSFormA.SelectedValue = ds.Tables[0].Rows[0]["CSFormA"].ToString().Trim();
            ddlCSFormB.SelectedValue = ds.Tables[0].Rows[0]["CSFormB"].ToString().Trim();

            ddlProductionParticulars3Years.SelectedValue = ds.Tables[0].Rows[0]["CSProductionParticulars3Years"].ToString().Trim();
            ddlRTACertificate.SelectedValue = ds.Tables[0].Rows[0]["CSRTACertificate"].ToString().Trim();
            ddlPHCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSPHCertificate"].ToString().Trim();
            ddlUntertakingForm.SelectedValue = ds.Tables[0].Rows[0]["CSUndertakingForm"].ToString().Trim();

            ddlApplicantVehiclePhoto.SelectedValue = ds.Tables[0].Rows[0]["ApplicantVehPhoto"].ToString().Trim();
            ddlfirstsalebill.SelectedValue = ds.Tables[0].Rows[0]["Fisrsalebill"].ToString().Trim();
            ddlCOBORROWER.SelectedValue = ds.Tables[0].Rows[0]["COBORROWER"].ToString().Trim();
            ddlBLAStatement_Brw.SelectedValue = ds.Tables[0].Rows[0]["BLAStatementBrw"].ToString().Trim();
            ddlCCCoBorrwer.SelectedValue = ds.Tables[0].Rows[0]["CCCoBorrwers"].ToString().Trim();
            ddlFacLicense.SelectedValue = ds.Tables[0].Rows[0]["FacLicenses"].ToString().Trim();
            ddlTMCStar.SelectedValue = ds.Tables[0].Rows[0]["TMCStar"].ToString().Trim();
            ddladdlocalemp1.SelectedValue = ds.Tables[0].Rows[0]["addlocalemp1"].ToString().Trim();
            ddladdlocalemp2.SelectedValue = ds.Tables[0].Rows[0]["addlocalemp2"].ToString().Trim();
            
            if (ddladdlocalemp1.SelectedValue == "Y")
            {
                ddladdlocalemp1_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddladdlocalemp2.SelectedValue == "Y")
            {
                ddladdlocalemp2_SelectedIndexChanged(this, EventArgs.Empty);
            }


            # region  " ddl selected change events"
            if (ddlCSbillsofinstitutfinancedEnterpriseindustries.SelectedValue == "Y")
            {
                ddlCSbillsofinstitutfinancedEnterpriseindustries_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue == "Y")
            {
                //ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSCasteCertificatesSCST.SelectedValue == "Y")
            {
                ddlCSCasteCertificatesSCST_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlCSEntrepreneurAadhar.SelectedValue == "Y")
            {
                ddlCSEntrepreneurAadhar_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSEntrepreneurPANCard.SelectedValue == "Y")
            {
                ddlCSEntrepreneurPANCard_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSCertificateofCA.SelectedValue == "Y")
            {
                ddlCSCertificateofCA_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSRegdPartnershipDeedArticles.SelectedValue == "Y")
            {
                ddlCSRegdPartnershipDeedArticles_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSApprovalDirectorFactories.SelectedValue == "Y")
            {
                ddlCSApprovalDirectorFactories_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSBoilersCertificate.SelectedValue == "Y")
            {
                ddlCSBoilersCertificate_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue == "Y")
            {
                ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue == "Y")
            {
                ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSOperationTSPCBAcknowledgementGM.SelectedValue == "Y")
            {
                ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue == "Y")
            {
                ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlCSEnvironmentalclearance.SelectedValue == "Y")
            {
                ddlCSEnvironmentalclearance_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSOtherstatutoryapprovalsspecif.SelectedValue == "Y")
            {
                ddlCSOtherstatutoryapprovalsspecif_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSEMPartIfullsetIEMIL.SelectedValue == "Y")
            {
                ddlCSEMPartIfullsetIEMIL_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSUdyogAadhar.SelectedValue == "Y")
            {
                ddlCSUdyogAadhar_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSProjectReport.SelectedValue == "Y")
            {
                ddlCSProjectReport_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSTermloansanctionletters.SelectedValue == "Y")
            {
                ddlCSTermloansanctionletters_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSBoardResolutionauthorizing.SelectedValue == "Y")
            {
                ddlCSBoardResolutionauthorizing_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue == "Y")
            {
                ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSCACECertificateregarding2handplantmachinery.SelectedValue == "Y")
            {
                ddlCSCACECertificateregarding2handplantmachinery_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSCECertificateSelffabricatedmachinery.SelectedValue == "Y")
            {
                ddlCSCECertificateSelffabricatedmachinery_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSBISCertificate.SelectedValue == "Y")
            {
                ddlCSBISCertificate_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSDrugLicense.SelectedValue == "Y")
            {
                ddlCSDrugLicense_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCSExplosiveLicense.SelectedValue == "Y")
            {
                ddlCSExplosiveLicense_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlCSVATCSTSGSTCertificate.SelectedValue == "Y")
            {
                ddlCSVATCSTSGSTCertificate_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlCSFormA.SelectedValue == "Y")
            {
                ddlCSFormA_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlCSFormB.SelectedValue == "Y")
            {
                ddlCSFormB_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlProductionParticulars3Years.SelectedValue == "Y")
            {
                ddlProductionParticulars3Years_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlRTACertificate.SelectedValue == "Y")
            {
                ddlRTACertificate_SelectedIndexChanged(this, EventArgs.Empty);
            }

            if (ddlPHCertificate.SelectedValue == "Y")
            {
                ddlPHCertificate_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlUntertakingForm.SelectedValue == "Y")
            {
                ddlUntertakingForm_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlfirstsalebill.SelectedValue == "Y")
            {
                ddlfirstsalebill_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCOBORROWER.SelectedValue == "Y")
            {
                ddlCOBORROWER_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlBLAStatement_Brw.SelectedValue == "Y")
            {
                ddlBLAStatement_Brw_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlCCCoBorrwer.SelectedValue == "Y")
            {
                ddlCCCoBorrwer_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlFacLicense.SelectedValue == "Y")
            {
                ddlFacLicense_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddlTMCStar.SelectedValue == "Y")
            {
                ddlTMCStar_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (ddldeetregack.SelectedValue == "Y")
            {
                ddldeetregack_SelectedIndexChanged(this, EventArgs.Empty);
            }
            # endregion

            BtnSave.Enabled = false;

        }
        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataTable table = ds.Tables[1];
            string sen, sen1, sen2, sennew;

            foreach (DataRow dr in table.Rows)
            {
                string attachmentid = dr["AttachmentId"].ToString();
                sen2 = dr["link"].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                sennew = dr["LINKNEW"].ToString();// LINKNEW
                string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                //if (sen.Contains("60"))
                if (attachmentid == "1001")
                {
                   // lblupload1.NavigateUrl = sen;
                    lblupload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;

                    lblupload1.Text = dr["FileNm"].ToString(); // hyperlink 
                    lblAttachedFileName1.Text = dr["FileNm"].ToString(); // label   
                    lblupload1.Visible = true;
                    lblAttachedFileName1.Visible = false;
                }
                if (attachmentid == "101")
                {
                   // HyperLink101.NavigateUrl = sen;
                    HyperLink101.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;

                    HyperLink101.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label101.Text = dr["FileNm"].ToString(); // label        
                    HyperLink101.Visible = true;
                    Label101.Visible = false;

                }

                if (attachmentid == "102")
                {
                   // HyperLink102.NavigateUrl = sen;
                    HyperLink102.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink102.Text = dr["FileNm"].ToString();// hyperlink 
                    Label102.Text = dr["FileNm"].ToString(); // label       
                    HyperLink102.Visible = true;
                    Label102.Visible = false;

                }
                if (attachmentid == "103")
                {
                  //  HyperLink103.NavigateUrl = sen;
                    HyperLink103.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                   // HyperLink103.NavigateUrl = sen;
                    HyperLink103.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label103.Text = dr["FileNm"].ToString(); // label 

                    HyperLink103.Visible = true;
                    Label103.Visible = false;

                }

                if (attachmentid == "104")
                {
                    HyperLink104.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                   // HyperLink104.NavigateUrl = sen;
                    HyperLink104.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label104.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink104.Visible = true;
                    Label104.Visible = false;
                }
                if (attachmentid == "105")
                {
                    //HyperLink105.NavigateUrl = sen;
                   HyperLink105.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                   // HyperLink105.NavigateUrl = dr["FileNm"].ToString();
                    HyperLink105.Text = dr["FileNm"].ToString(); // hyperlink 
                    HyperLink105.Visible = true;
                    Label105.Text = dr["FileNm"].ToString();  // label  

                    HyperLink105.Visible = true;
                    Label105.Visible = false;
                }

                if (attachmentid == "106")
                {
                   // HyperLink106.NavigateUrl = sen;
                    HyperLink106.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink106.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label106.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink106.Visible = true;
                    Label106.Visible = false;
                }

                if (attachmentid == "201")
                {
                   // HyperLink201.NavigateUrl = sen;
                    HyperLink201.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink201.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label201.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink201.Visible = true;
                    Label201.Visible = false;
                }

                if (attachmentid == "202")
                {
                    //HyperLink202.NavigateUrl = sen;
                    HyperLink202.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink202.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label202.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink202.Visible = true;
                    Label202.Visible = false;
                }
                if (attachmentid == "203")
                {
                   // HyperLink203.NavigateUrl = sen;
                    HyperLink203.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink203.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label203.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink203.Visible = true;
                    Label203.Visible = false;
                }

                if (attachmentid == "204")
                {
                    //HyperLink204.NavigateUrl = sen;
                    HyperLink204.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink204.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label204.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink204.Visible = true;
                    Label204.Visible = false;
                }
                if (attachmentid == "205")
                {
                   // HyperLink205.NavigateUrl = sen;
                    HyperLink205.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink205.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label205.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink205.Visible = true;
                    Label205.Visible = false;
                }
                if (attachmentid == "206")
                {
                   // HyperLink206.NavigateUrl = sen;
                    HyperLink206.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink206.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label206.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink206.Visible = true;
                    Label206.Visible = false;
                }
                if (attachmentid == "207")
                {
                    //HyperLink207.NavigateUrl = sen;
                    HyperLink207.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink207.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label207.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink207.Visible = true;
                    Label207.Visible = false;
                }
                if (attachmentid == "208")
                {
                    //HyperLink208.NavigateUrl = sen;
                    HyperLink208.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink208.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label208.Text = dr["FileNm"].ToString(); // label                  

                    HyperLink208.Visible = true;
                    Label208.Visible = false;
                }
                if (attachmentid == "209")
                {
                   // HyperLink209.NavigateUrl = sen;
                    HyperLink209.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink209.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label209.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink209.Visible = true;
                    Label209.Visible = false;
                }

                if (attachmentid == "210")
                {
                    //HyperLink210.NavigateUrl = sen;
                    HyperLink210.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink210.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label210.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink210.Visible = true;
                    Label210.Visible = false;
                }

                if (attachmentid == "211")
                {
                    //HyperLink211.NavigateUrl = sen;
                    HyperLink211.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink211.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label211.Text = dr["FileNm"].ToString(); // label                  

                    HyperLink211.Visible = true;
                    Label211.Visible = false;
                }


                if (attachmentid == "212")
                {
                    //HyperLink212.NavigateUrl = sen;
                    HyperLink212.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink212.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label212.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink212.Visible = true;
                    Label212.Visible = false;
                }

                if (attachmentid == "213")
                {
                   // HyperLink213.NavigateUrl = sen;
                    HyperLink213.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink213.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label213.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink213.Visible = true;
                    Label213.Visible = false;
                }
                if (attachmentid == "214")
                {
                    //HyperLink214.NavigateUrl = sen;
                    HyperLink214.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink214.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label214.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink214.Visible = true;
                    Label214.Visible = false;
                }
                if (attachmentid == "215")
                {
                   // HyperLink215.NavigateUrl = sen;
                    HyperLink215.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink215.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label215.Text = dr["FileNm"].ToString(); // label                  

                    HyperLink215.Visible = true;
                    Label215.Visible = false;
                }
                if (attachmentid == "216")
                {
                    //HyperLink216.NavigateUrl = sen;
                    HyperLink216.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink216.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label216.Text = dr["FileNm"].ToString();// label                  

                    HyperLink216.Visible = true;
                    Label216.Visible = false;
                }
                if (attachmentid == "217")
                {
                    //HyperLink217.NavigateUrl = sen;
                    HyperLink217.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink217.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label208.Text = dr["FileNm"].ToString(); // label                  

                    HyperLink217.Visible = true;
                    Label217.Visible = false;
                }
                if (attachmentid == "218")
                {
                    //HyperLink218.NavigateUrl = sen;
                    HyperLink218.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink218.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label218.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink218.Visible = true;
                    Label218.Visible = false;
                }
                if (attachmentid == "219")
                {
                    //HyperLink219.NavigateUrl = sen;
                    HyperLink219.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink219.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label219.Text = dr["FileNm"].ToString(); // label                  

                    HyperLink219.Visible = true;
                    Label219.Visible = false;
                }

                if (attachmentid == "220")
                {
                   // HyperLink220.NavigateUrl = sen;
                    HyperLink220.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink220.Text = dr["FileNm"].ToString(); // hyperlink 
                    Label220.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink220.Visible = true;
                    Label220.Visible = false;
                }

                if (attachmentid == "221")
                {
                    //HyperLink221.NavigateUrl = sen;
                    HyperLink221.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink221.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label221.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink221.Visible = true;
                    Label221.Visible = false;
                }

                if (attachmentid == "222")
                {
                   // HyperLink222.NavigateUrl = sen;
                    HyperLink222.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink222.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label222.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink222.Visible = true;
                    Label222.Visible = false;
                }

                if (attachmentid == "223")
                {
                   // HyperLink223.NavigateUrl = sen;
                    HyperLink223.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink223.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label223.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink223.Visible = true;
                    Label223.Visible = false;
                }

                if (attachmentid == "224")
                {
                    //HyperLink224.NavigateUrl = sen;
                    HyperLink224.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink224.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label224.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink224.Visible = true;
                    Label224.Visible = false;
                }

                if (attachmentid == "225")
                {
                    //HyperLink225.NavigateUrl = sen;
                    HyperLink225.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink225.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label225.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink223.Visible = true;
                    Label223.Visible = false;
                }

                if (attachmentid == "226")
                {
                    //HyperLink226.NavigateUrl = sen;
                    HyperLink226.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink226.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label226.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink226.Visible = true;
                    Label226.Visible = false;
                }

                if (attachmentid == "227")
                {
                    //HyperLink227.NavigateUrl = sen;
                    HyperLink227.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink227.Text = dr["FileNm"].ToString();  // hyperlink 
                    Label227.Text = dr["FileNm"].ToString();  // label                  

                    HyperLink227.Visible = true;
                    Label227.Visible = false;
                }
                if (attachmentid == "228")
                {
                    //HyperLink228.NavigateUrl = sen;
                    HyperLink228.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink228.Text = dr["FileNm"].ToString();  // hyperlink
                    Label228.Text = dr["FileNm"].ToString();  // label                 
                    HyperLink228.Visible = true;
                    Label228.Visible = false;
                }
                if (attachmentid == "1094")
                {
                    //HyperLink229.NavigateUrl = sen;
                    HyperLink229.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink229.Text = dr["FileNm"].ToString();  // hyperlink
                    Label229.Text = dr["FileNm"].ToString();  // label                 
                    HyperLink229.Visible = true;
                    Label229.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100019")
                {
                    //HyperLink229.NavigateUrl = sen;
                    HyperLink229.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink229.Text = dr["FileNm"].ToString();  // hyperlink
                    Label229.Text = dr["FileNm"].ToString();  // label                 
                    HyperLink229.Visible = true;
                    Label229.Visible = false;
                }
                if (attachmentid == "100020")
                {
                    //hplBLAStatement_Brw.NavigateUrl = sen;
                    hplBLAStatement_Brw.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplBLAStatement_Brw.Text = dr["FileNm"].ToString();  // hyperlink
                    lblBLAStatement_Brw.Text = dr["FileNm"].ToString();  // label                 
                    hplBLAStatement_Brw.Visible = true;
                    lblBLAStatement_Brw.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100021")
                {
                    hplddlCCCoBorrwer.NavigateUrl = sen;
                    hplddlCCCoBorrwer.NavigateUrl = sen;
                    hplddlCCCoBorrwer.Text = dr["FileNm"].ToString();  // hyperlink
                    lblddlCCCoBorrwer.Text = dr["FileNm"].ToString();  // label                 
                    hplddlCCCoBorrwer.Visible = true;
                    lblddlCCCoBorrwer.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100022")
                {
                   // hplFacLicense.NavigateUrl = sen;
                    hplFacLicense.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplFacLicense.Text = dr["FileNm"].ToString();  // hyperlink
                    lblFacLicense.Text = dr["FileNm"].ToString();  // label                 
                    hplFacLicense.Visible = true;
                    lblFacLicense.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100023")
                {
                    //hplTMCStar.NavigateUrl = sen;
                    hplTMCStar.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplTMCStar.Text = dr["FileNm"].ToString();  // hyperlink
                    lblTMCStar.Text = dr["FileNm"].ToString();  // label                 
                    hplTMCStar.Visible = true;
                    lblTMCStar.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100024")
                {
                   // hplAddlocalemp1.NavigateUrl = sen;
                    hplAddlocalemp1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplAddlocalemp1.Text = dr["FileNm"].ToString();  // hyperlink
                    lbllocalemp1.Text = dr["FileNm"].ToString();  // label                 
                    hplAddlocalemp1.Visible = true;
                    lbllocalemp1.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100025")
                {
                   // hplAddlocalemp2.NavigateUrl = sen;
                    hplAddlocalemp2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplAddlocalemp2.Text = dr["FileNm"].ToString();  // hyperlink
                    lbllocalemp2.Text = dr["FileNm"].ToString();  // label                 
                    hplAddlocalemp2.Visible = true;
                    lbllocalemp2.Visible = false;
                    attachValue = "1";
                }
                if (attachmentid == "100050")
                {
                    // hplAddlocalemp2.NavigateUrl = sen;
                    hypdeetregack.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hypdeetregack.Text = dr["FileNm"].ToString();  // hyperlink
                    lbldeetregack.Text = dr["FileNm"].ToString();  // label                 
                    hypdeetregack.Visible = true;
                    lbldeetregack.Visible = false;
                    attachValue = "1";
                }
                //MSME
                if (attachmentid == "901")
                {
                    hplCAMSME1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplCAMSME1.Text = dr["FileNm"].ToString();  // hyperlink                               
                    hplCAMSME1.Visible = true;
                    lblCAMSME1.Text = dr["FileNm"].ToString();  // label     
                    lblCAMSME1.Visible = false;
                }
                if (attachmentid == "902")
                {
                    hplCivilCert.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplCivilCert.Text = dr["FileNm"].ToString();  // hyperlink                               
                    hplCivilCert.Visible = true;
                    lblCivilCert.Text = dr["FileNm"].ToString();  // label     
                    lblCivilCert.Visible = false;
                }
                if (attachmentid == "903")
                {
                    hplEnterpsriseDecl.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplEnterpsriseDecl.Text = dr["FileNm"].ToString();  // hyperlink                               
                    hplEnterpsriseDecl.Visible = true;
                    lblEnterpsriseDecl.Text = dr["FileNm"].ToString();  // label     
                    lblEnterpsriseDecl.Visible = false;
                }
                if (attachmentid == "904")
                {
                    hplloanstmt.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    hplloanstmt.Text = dr["FileNm"].ToString();  // hyperlink                               
                    hplloanstmt.Visible = true;
                    lblloanstmt.Text = dr["FileNm"].ToString();  // label     
                    lblloanstmt.Visible = false;
                }
            }


        }

        #region 'attachments binding'
        //int c = ds.Tables[1].Rows.Count;
        //string sen, sen1, sen2;
        //int i = 23;

        //while (i < c)
        //{
        //    string attachmentid = ds.Tables[1].Rows[i][0].ToString();
        //    sen2 = ds.Tables[1].Rows[i][3].ToString();
        //    sen1 = sen2.Replace(@"\", @"/");
        //    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

        //    //if (sen.Contains("60"))
        //    if (attachmentid == "1001")
        //    {
        //        lblupload1.NavigateUrl = sen;
        //        lblupload1.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        lblAttachedFileName1.Text = ds.Tables[1].Rows[i][2].ToString();  // label                   

        //    }
        //    if (attachmentid == "101")
        //    {
        //        HyperLink101.NavigateUrl = sen;
        //        HyperLink101.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label101.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "102")
        //    {
        //        HyperLink102.NavigateUrl = sen;
        //        HyperLink102.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label102.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    } if (attachmentid == "103")
        //    {
        //        HyperLink103.NavigateUrl = sen;
        //        HyperLink103.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label103.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "104")
        //    {
        //        HyperLink104.NavigateUrl = sen;
        //        HyperLink104.Text = ds.Tables[1].Rows[i][2].ToString();  // hyperlink 
        //        Label104.Text = ds.Tables[1].Rows[i][2].ToString();  // label                  

        //    }
        //    if (attachmentid == "105")
        //    {
        //        //HyperLink105.NavigateUrl = sen;
        //        HyperLink105.NavigateUrl = ds.Tables[1].Rows[i][3].ToString();
        //        HyperLink105.Text = ds.Tables[1].Rows[i][2].ToString();  // hyperlink 
        //        HyperLink105.Visible = true;
        //        Label105.Text = ds.Tables[1].Rows[i][2].ToString();  // label  

        //        //HyperLink105.NavigateUrl = sen;
        //        //HyperLink105.Text = dr["FileNm"].ToString();
        //        //HyperLink105.Text = dr["FileNm"].ToString();
        //    }

        //    if (attachmentid == "106")
        //    {
        //        HyperLink106.NavigateUrl = sen;
        //        HyperLink106.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label106.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "201")
        //    {
        //        HyperLink201.NavigateUrl = sen;
        //        HyperLink201.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label201.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "202")
        //    {
        //        HyperLink202.NavigateUrl = sen;
        //        HyperLink202.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label202.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "203")
        //    {
        //        HyperLink203.NavigateUrl = sen;
        //        HyperLink203.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label203.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "204")
        //    {
        //        HyperLink204.NavigateUrl = sen;
        //        HyperLink204.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label204.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "205")
        //    {
        //        HyperLink205.NavigateUrl = sen;
        //        HyperLink205.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label205.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "206")
        //    {
        //        HyperLink206.NavigateUrl = sen;
        //        HyperLink206.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label206.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "207")
        //    {
        //        HyperLink207.NavigateUrl = sen;
        //        HyperLink207.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label207.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "208")
        //    {
        //        HyperLink208.NavigateUrl = sen;
        //        HyperLink208.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label208.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "209")
        //    {
        //        HyperLink209.NavigateUrl = sen;
        //        HyperLink209.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label209.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "211")
        //    {
        //        HyperLink211.NavigateUrl = sen;
        //        HyperLink211.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label211.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }


        //    if (attachmentid == "212")
        //    {
        //        HyperLink212.NavigateUrl = sen;
        //        HyperLink212.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label212.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "213")
        //    {
        //        HyperLink213.NavigateUrl = sen;
        //        HyperLink213.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label213.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }


        //    if (attachmentid == "214")
        //    {
        //        HyperLink214.NavigateUrl = sen;
        //        HyperLink214.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label214.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "215")
        //    {
        //        HyperLink215.NavigateUrl = sen;
        //        HyperLink215.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label215.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "216")
        //    {
        //        HyperLink216.NavigateUrl = sen;
        //        HyperLink216.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label216.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "217")
        //    {
        //        HyperLink217.NavigateUrl = sen;
        //        HyperLink208.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label208.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "218")
        //    {
        //        HyperLink218.NavigateUrl = sen;
        //        HyperLink218.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label218.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }
        //    if (attachmentid == "219")
        //    {
        //        HyperLink219.NavigateUrl = sen;
        //        HyperLink219.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label219.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }


        //    if (attachmentid == "220")
        //    {
        //        HyperLink220.NavigateUrl = sen;
        //        HyperLink221.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label221.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "221")
        //    {
        //        HyperLink221.NavigateUrl = sen;
        //        HyperLink221.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label221.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    if (attachmentid == "222")
        //    {
        //        HyperLink222.NavigateUrl = sen;
        //        HyperLink222.Text = ds.Tables[1].Rows[i][3].ToString();  // hyperlink 
        //        Label222.Text = ds.Tables[1].Rows[i][3].ToString();  // label                  

        //    }

        //    i++;
        //}
        #endregion


    }


    // added on 18.06.2017  for file uploads

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


    protected void btnUpload1_Click1(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fuDocuments1.HasFile)
        {
            if ((fuDocuments1.PostedFile != null) && (fuDocuments1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments1.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\1001");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      1001,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName1.Text = fuDocuments1.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        lblupload1.Text = fuDocuments1.FileName;
                        lblupload1.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception ex)//in case of an error
                {
                   // throw ex;
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                    DeleteFile(newPath + "\\" + sFileName);
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


    protected void Button101_Click(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload101.HasFile)
        {
            if ((FileUpload101.PostedFile != null) && (FileUpload101.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload101.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload101.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\101");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload101.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload101.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      101,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label101.Text = FileUpload101.FileName;
                        //Label101.Visible = true;
                        HyperLink101.Text = FileUpload101.FileName;
                        HyperLink101.Visible = true;

                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception ex )//in case of an error
                {
                    LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

                    DeleteFile(newPath + "\\" + sFileName);
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

    protected void Button102_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload102.HasFile)
        {
            if ((FileUpload102.PostedFile != null) && (FileUpload102.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload102.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload102.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\102");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload102.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload102.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      102,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label102.Text = FileUpload102.FileName;
                        // Label102.Visible = true;
                        HyperLink102.Text = FileUpload102.FileName;
                        HyperLink102.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button103_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload103.HasFile)
        {
            if ((FileUpload103.PostedFile != null) && (FileUpload103.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload103.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload103.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\103");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload103.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload103.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      103,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label103.Text = FileUpload103.FileName;
                        // Label103.Visible = true;
                        HyperLink103.Text = FileUpload103.FileName;
                        HyperLink103.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button104_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload104.HasFile)
        {
            if ((FileUpload104.PostedFile != null) && (FileUpload104.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload104.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload104.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\104");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload104.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload104.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      104,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label104.Text = FileUpload104.FileName;
                        HyperLink104.Text = FileUpload104.FileName;
                        // Label104.Visible = true;
                        HyperLink104.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button105_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload105.HasFile)
        {
            if ((FileUpload105.PostedFile != null) && (FileUpload105.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload105.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload105.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\105");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload105.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload105.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      105,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label105.Text = FileUpload105.FileName;
                        //Label105.Visible = true;
                        HyperLink105.Text = FileUpload105.FileName;
                        HyperLink105.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button106_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload106.HasFile)
        {
            if ((FileUpload106.PostedFile != null) && (FileUpload106.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload106.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload106.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\106");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload106.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload106.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      106,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label106.Text = FileUpload106.FileName;
                        // Label106.Visible = true;
                        HyperLink106.Text = FileUpload106.FileName;
                        HyperLink106.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button201_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload201.HasFile)
        {
            if ((FileUpload201.PostedFile != null) && (FileUpload201.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload201.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload201.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\201");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      201,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label201.Text = FileUpload201.FileName;
                        //  Label201.Visible = true;
                        HyperLink201.Text = FileUpload201.FileName;
                        HyperLink201.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button202_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload202.HasFile)
        {
            if ((FileUpload202.PostedFile != null) && (FileUpload202.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload202.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload202.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\202");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      202,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label202.Text = FileUpload202.FileName;
                        // Label202.Visible = true;
                        HyperLink202.Text = FileUpload202.FileName;
                        HyperLink202.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button203_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload203.HasFile)
        {
            if ((FileUpload203.PostedFile != null) && (FileUpload203.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload203.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload203.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\203");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      203,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label203.Text = FileUpload203.FileName;
                        // Label203.Visible = true;
                        HyperLink203.Text = FileUpload203.FileName;
                        HyperLink203.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button204_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload204.HasFile)
        {
            if ((FileUpload204.PostedFile != null) && (FileUpload204.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload204.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload204.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\204");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      204,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label204.Text = FileUpload204.FileName;
                        //Label204.Visible = true;
                        HyperLink204.Text = FileUpload204.FileName;
                        HyperLink204.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button205_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload205.HasFile)
        {
            if ((FileUpload205.PostedFile != null) && (FileUpload205.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload205.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload205.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\205");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      205,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label205.Text = FileUpload205.FileName;
                        // Label205.Visible = true;
                        HyperLink205.Text = FileUpload205.FileName;
                        HyperLink205.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void Button206_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload206.HasFile)
        {
            if ((FileUpload206.PostedFile != null) && (FileUpload206.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload206.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload206.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\206");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      206,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label206.Text = FileUpload206.FileName;
                        //Label206.Visible = true;
                        HyperLink206.Text = FileUpload206.FileName;
                        HyperLink206.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button207_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload207.HasFile)
        {
            if ((FileUpload207.PostedFile != null) && (FileUpload207.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload207.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload207.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\207");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload207.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload207.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      207,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label207.Text = FileUpload207.FileName;
                        //Label207.Visible = true;
                        HyperLink207.Text = FileUpload207.FileName;
                        HyperLink207.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }

    protected void Button208_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload208.HasFile)
        {
            if ((FileUpload208.PostedFile != null) && (FileUpload208.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload208.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload208.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\208");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload208.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload208.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      208,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label208.Text = FileUpload208.FileName;
                        //Label208.Visible = true;
                        HyperLink208.Text = FileUpload208.FileName;
                        HyperLink208.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button209_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload209.HasFile)
        {
            if ((FileUpload209.PostedFile != null) && (FileUpload209.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload209.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload209.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\209");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload209.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload209.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      209,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label209.Text = FileUpload209.FileName;
                        // Label209.Visible = true;
                        HyperLink209.Text = FileUpload209.FileName;
                        HyperLink209.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }

    protected void Button210_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload210.HasFile)
        {
            if ((FileUpload210.PostedFile != null) && (FileUpload210.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload210.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload210.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\210");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload210.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload210.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      210,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label210.Text = FileUpload210.FileName;
                        // Label210.Visible = true;
                        HyperLink210.Text = FileUpload210.FileName;
                        HyperLink210.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button211_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload211.HasFile)
        {
            if ((FileUpload211.PostedFile != null) && (FileUpload211.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload211.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload211.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\211");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload211.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload211.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      211,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label211.Text = FileUpload211.FileName;
                        //Label211.Visible = true;
                        HyperLink211.Text = FileUpload211.FileName;
                        HyperLink211.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button212_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload212.HasFile)
        {
            if ((FileUpload212.PostedFile != null) && (FileUpload212.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload212.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload212.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\212");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload212.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload212.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      212,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label212.Text = FileUpload212.FileName;
                        //Label212.Visible = true;
                        HyperLink212.Text = FileUpload212.FileName;
                        HyperLink212.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button213_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload213.HasFile)
        {
            if ((FileUpload213.PostedFile != null) && (FileUpload213.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload213.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload213.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\213");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload213.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload213.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      213,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label213.Text = FileUpload213.FileName;
                        //Label213.Visible = true;
                        HyperLink213.Text = FileUpload213.FileName;
                        HyperLink213.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button214_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload214.HasFile)
        {
            if ((FileUpload214.PostedFile != null) && (FileUpload214.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload214.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload214.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\214");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload214.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload214.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      214,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label214.Text = FileUpload214.FileName;
                        //Label214.Visible = true;
                        HyperLink214.Text = FileUpload214.FileName;
                        HyperLink214.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button215_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload215.HasFile)
        {
            if ((FileUpload215.PostedFile != null) && (FileUpload215.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload215.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload215.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\215");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload215.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload215.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      215,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label215.Text = FileUpload215.FileName;
                        //Label215.Visible = true;
                        HyperLink215.Text = FileUpload215.FileName;
                        HyperLink215.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }

    protected void Button216_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload216.HasFile)
        {
            if ((FileUpload216.PostedFile != null) && (FileUpload216.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload216.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload216.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\216");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload216.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload216.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      216,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label216.Text = FileUpload216.FileName;
                        // Label216.Visible = true;
                        HyperLink216.Text = FileUpload216.FileName;
                        HyperLink216.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button217_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload217.HasFile)
        {
            if ((FileUpload217.PostedFile != null) && (FileUpload217.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload217.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload217.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\217");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload217.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload217.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      217,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label217.Text = FileUpload217.FileName;
                        // Label217.Visible = true;
                        HyperLink217.Text = FileUpload217.FileName;
                        HyperLink217.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button218_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload218.HasFile)
        {
            if ((FileUpload218.PostedFile != null) && (FileUpload218.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload218.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload218.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\218");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload218.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload218.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      218,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label218.Text = FileUpload218.FileName;
                        // Label218.Visible = true;
                        HyperLink218.Text = FileUpload218.FileName;
                        HyperLink218.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }

    protected void Button219_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload219.HasFile)
        {
            if ((FileUpload219.PostedFile != null) && (FileUpload219.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload219.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload219.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\219");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload219.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload219.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      219,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label219.Text = FileUpload219.FileName;
                        // Label219.Visible = true;
                        HyperLink219.Text = FileUpload219.FileName;
                        HyperLink219.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button220_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload220.HasFile)
        {
            if ((FileUpload220.PostedFile != null) && (FileUpload220.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload220.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload220.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\220");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload220.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload220.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      220,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label220.Text = FileUpload220.FileName;
                        // Label220.Visible = true;
                        HyperLink220.Text = FileUpload220.FileName;
                        HyperLink220.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button221_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload221.HasFile)
        {
            if ((FileUpload221.PostedFile != null) && (FileUpload221.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload221.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload221.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\221");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload221.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload221.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      221,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label221.Text = FileUpload221.FileName;
                        // Label221.Visible = true;
                        HyperLink221.Text = FileUpload221.FileName;
                        HyperLink221.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void Button222_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload222.HasFile)
        {
            if ((FileUpload222.PostedFile != null) && (FileUpload222.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload222.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload222.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\222");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload222.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload222.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      222,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label222.Text = FileUpload222.FileName;
                        // Label222.Visible = true;
                        HyperLink222.Text = FileUpload222.FileName;
                        HyperLink222.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void ddlCSbillsofinstitutfinancedEnterpriseindustries_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Failure.Visible = false;
        if (ddlCSbillsofinstitutfinancedEnterpriseindustries.SelectedItem.Text.ToUpper() == "YES")
        {
            fuDocuments1.Visible = true;
            btnUpload1.Visible = true;
            lblAttachedFileName1.Visible = false;
            lblupload1.Visible = true;
        }
        else
        {
            fuDocuments1.Visible = false;
            btnUpload1.Visible = false;
            lblAttachedFileName1.Visible = false;
            lblupload1.Visible = false;
        }

    }
    public void FUPVisible(Boolean str, FileUpload fuDocuments, Button btnUpload, Label lblAttachedFileName, Label lblupload)
    {
        fuDocuments.Visible = str;
        btnUpload.Visible = str;
        lblAttachedFileName.Visible = str;
        lblupload.Visible = str;
    }
    protected void ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Failure.Visible = false;
        if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload101.Visible = true;
            Button101.Visible = true;
            HyperLink101.Visible = true;
            Label101.Visible = false;
        }
        else
        {

            FileUpload101.Visible = false;
            Button101.Visible = false;
            HyperLink101.Visible = false;
            Label101.Visible = false;
        }
    }
    protected void ddlCSEntrepreneurAadhar_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Failure.Visible = false;
        if (ddlCSEntrepreneurAadhar.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload103.Visible = true;
            Button103.Visible = true;
            HyperLink103.Visible = true;
            Label103.Visible = false;
        }
        else
        {
            FileUpload103.Visible = false;
            Button103.Visible = false;
            HyperLink103.Visible = false;
            Label103.Visible = false;
        }
    }
    protected void ddlCSEntrepreneurPANCard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Failure.Visible = false;
        if (ddlCSEntrepreneurPANCard.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload104.Visible = true;
            Button104.Visible = true;
            HyperLink104.Visible = true;
            Label104.Visible = false;
        }
        else
        {

            FileUpload104.Visible = false;
            Button104.Visible = false;
            HyperLink104.Visible = false;
            Label104.Visible = false;
        }
    }
    protected void ddlCSCertificateofCA_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSCertificateofCA.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload105.Visible = true;
            Button105.Visible = true;
            HyperLink105.Visible = true;
            Label105.Visible = false;
        }
        else
        {
            FileUpload105.Visible = false;
            Button105.Visible = false;
            HyperLink105.Visible = false;
            Label105.Visible = false;
        }
    }
    protected void ddlCSRegdPartnershipDeedArticles_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Failure.Visible = false;
        if (ddlCSRegdPartnershipDeedArticles.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload106.Visible = true;
            Button106.Visible = true;
            HyperLink106.Visible = true;
            Label106.Visible = false;
        }
        else
        {
            FileUpload106.Visible = false;
            Button106.Visible = false;
            HyperLink106.Visible = false;
            Label106.Visible = false;
        }


    }
    protected void ddlCSApprovalDirectorFactories_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload201.Visible = true;
            Button201.Visible = true;
            HyperLink201.Visible = true;
            Label201.Visible = false;
        }
        else
        {
            FileUpload201.Visible = false;
            Button201.Visible = false;
            HyperLink201.Visible = false;
            Label201.Visible = false;
        }

    }
    protected void ddlCSBoilersCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload202.Visible = true;
            Button202.Visible = true;
            HyperLink202.Visible = true;
            Label202.Visible = false;
        }
        else
        {
            FileUpload202.Visible = false;
            Button202.Visible = false;
            HyperLink202.Visible = false;
            Label202.Visible = false;
        }
    }
    protected void ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload203.Visible = true;
            Button203.Visible = true;
            HyperLink203.Visible = true;
            Label203.Visible = false;
        }
        else
        {
            FileUpload203.Visible = false;
            Button203.Visible = false;
            HyperLink203.Visible = false;
            Label203.Visible = false;
        }

    }
    protected void ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload204.Visible = true;
            Button204.Visible = true;
            HyperLink204.Visible = true;
            Label204.Visible = false;
        }
        else
        {
            FileUpload204.Visible = false;
            Button204.Visible = false;
            HyperLink204.Visible = false;
            Label204.Visible = false;
        }

    }
    protected void ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload205.Visible = true;
            Button205.Visible = true;
            HyperLink205.Visible = true;
            Label205.Visible = false;
        }
        else
        {
            FileUpload205.Visible = false;
            Button205.Visible = false;
            HyperLink205.Visible = false;
            Label205.Visible = false;
        }

    }
    protected void ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload206.Visible = true;
            Button206.Visible = true;
            HyperLink206.Visible = true;
            Label206.Visible = false;
        }
        else
        {
            FileUpload206.Visible = false;
            Button206.Visible = false;
            HyperLink206.Visible = false;
            Label206.Visible = false;
        }
    }
    protected void ddlCSEnvironmentalclearance_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSEnvironmentalclearance.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload207.Visible = true;
            Button207.Visible = true;
            HyperLink207.Visible = true;
            Label207.Visible = false;
        }
        else
        {
            FileUpload207.Visible = false;
            Button207.Visible = false;
            HyperLink207.Visible = false;
            Label207.Visible = false;
        }

    }
    protected void ddlCSOtherstatutoryapprovalsspecif_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSOtherstatutoryapprovalsspecif.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload208.Visible = true;
            Button208.Visible = true;
            HyperLink208.Visible = true;
            Label208.Visible = false;
        }
        else
        {
            FileUpload208.Visible = false;
            Button208.Visible = false;
            HyperLink208.Visible = false;
            Label208.Visible = false;
        }

    }
    protected void ddlCSEMPartIfullsetIEMIL_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSEMPartIfullsetIEMIL.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload209.Visible = true;
            Button209.Visible = true;
            HyperLink209.Visible = true;
            Label209.Visible = false;
        }
        else
        {
            FileUpload209.Visible = false;
            Button209.Visible = false;
            HyperLink209.Visible = false;
            Label209.Visible = false;
        }

    }
    protected void ddlCSUdyogAadhar_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSUdyogAadhar.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload210.Visible = true;
            Button210.Visible = true;
            HyperLink210.Visible = true;
            Label210.Visible = false;
        }
        else
        {
            FileUpload210.Visible = false;
            Button210.Visible = false;
            HyperLink210.Visible = false;
            Label210.Visible = false;
        }

    }
    protected void ddlCSProjectReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSProjectReport.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload211.Visible = true;
            Button211.Visible = true;
            HyperLink211.Visible = true;
            Label211.Visible = false;
        }
        else
        {
            //FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
            // FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
            FileUpload211.Visible = false;
            Button211.Visible = false;
            HyperLink211.Visible = false;
            Label211.Visible = false;
        }

    }
    protected void ddlCSTermloansanctionletters_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSTermloansanctionletters.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload212.Visible = true;
            Button212.Visible = true;
            HyperLink212.Visible = true;
            Label212.Visible = false;
        }
        else
        {
            FileUpload212.Visible = false;
            Button212.Visible = false;
            HyperLink212.Visible = false;
            Label212.Visible = false;
        }
    }
    protected void ddlCSBoardResolutionauthorizing_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSBoardResolutionauthorizing.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload213.Visible = true;
            Button213.Visible = true;
            HyperLink213.Visible = true;
            Label213.Visible = false;
        }
        else
        {
            FileUpload213.Visible = false;
            Button213.Visible = false;
            HyperLink213.Visible = false;
            Label213.Visible = false;
        }

    }
    protected void ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload214.Visible = true;
            Button214.Visible = true;
            HyperLink214.Visible = true;
            Label214.Visible = false;
        }
        else
        {
            FileUpload214.Visible = false;
            Button214.Visible = false;
            HyperLink214.Visible = false;
            Label214.Visible = false;
        }

    }
    protected void ddlCSCACECertificateregarding2handplantmachinery_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSCACECertificateregarding2handplantmachinery.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload215.Visible = true;
            Button215.Visible = true;
            HyperLink215.Visible = true;
            Label215.Visible = false;
        }
        else
        {
            FileUpload215.Visible = false;
            Button215.Visible = false;
            HyperLink215.Visible = false;
            Label215.Visible = false;
        }

    }
    protected void ddlCSCECertificateSelffabricatedmachinery_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSCECertificateSelffabricatedmachinery.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload216.Visible = true;
            Button216.Visible = true;
            HyperLink216.Visible = true;
            Label216.Visible = false;
        }
        else
        {
            FileUpload216.Visible = false;
            Button216.Visible = false;
            HyperLink216.Visible = false;
            Label216.Visible = false;
        }


    }
    protected void ddlCSBISCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSBISCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload217.Visible = true;
            Button217.Visible = true;
            HyperLink217.Visible = true;
            Label217.Visible = false;
        }
        else
        {
            //FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
            // FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
            FileUpload217.Visible = false;
            Button217.Visible = false;
            HyperLink217.Visible = false;
            Label217.Visible = false;
        }

    }
    protected void ddlCSDrugLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSDrugLicense.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload218.Visible = true;
            Button218.Visible = true;
            HyperLink218.Visible = true;
            Label218.Visible = false;
        }
        else
        {
            FileUpload218.Visible = false;
            Button218.Visible = false;
            HyperLink218.Visible = false;
            Label218.Visible = false;
            Failure.Visible = false;
        }

    }
    protected void ddlCSExplosiveLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSExplosiveLicense.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload219.Visible = true;
            Button219.Visible = true;
            HyperLink219.Visible = true;
            Label219.Visible = false;
        }
        else
        {
            FileUpload219.Visible = false;
            Button219.Visible = false;
            HyperLink219.Visible = false;
            Label219.Visible = false;
        }

    }
    protected void ddlCSVATCSTSGSTCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSVATCSTSGSTCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload220.Visible = true;
            Button220.Visible = true;
            HyperLink220.Visible = true;
            Label220.Visible = false;
        }
        else
        {
            FileUpload220.Visible = false;
            Button220.Visible = false;
            HyperLink220.Visible = false;
            Label220.Visible = false;
        }

    }
    protected void ddlCSFormA_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSFormA.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload221.Visible = true;
            Button221.Visible = true;
            HyperLink221.Visible = true;
            Label221.Visible = false;
        }
        else
        {
            FileUpload221.Visible = false;
            Button221.Visible = false;
            HyperLink221.Visible = false;
            Label221.Visible = false;
        }


    }
    protected void ddlCSFormB_SelectedIndexChanged(object sender, EventArgs e)
    {
        //  Failure.Visible = false;
        if (ddlCSFormB.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload222.Visible = true;
            Button222.Visible = true;
            HyperLink222.Visible = true;
            Label222.Visible = false;
        }
        else
        {
            FileUpload222.Visible = false;
            Button222.Visible = false;
            HyperLink222.Visible = false;
            Label222.Visible = false;
        }

    }
    protected void ddlCSCasteCertificatesSCST_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlCSCasteCertificatesSCST.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload102.Visible = true;
            Button102.Visible = true;
            HyperLink102.Visible = true;
            Label102.Visible = false;
        }
        else
        {
            FileUpload102.Visible = false;
            Button102.Visible = false;
            HyperLink102.Visible = false;
            Label102.Visible = false;
        }

    }
    protected void ddlProductionParticulars3Years_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlProductionParticulars3Years.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload223.Visible = true;
            Button223.Visible = true;
            HyperLink223.Visible = true;
            Label223.Visible = false;
        }
        else
        {
            FileUpload223.Visible = false;
            Button223.Visible = false;
            HyperLink223.Visible = false;
            Label223.Visible = false;
        }

    }
    //protected void ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged1(object sender, EventArgs e)
    //{

    //     if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedItem.Text.ToUpper() == "YES")
    //    {
    //        FileUpload214.Visible = true;
    //        Button214.Visible = true;
    //        HyperLink214.Visible = true;
    //        Label214.Visible = true;
    //    }
    //     else 
    //     {
    //         FileUpload214.Visible = false;
    //         Button214.Visible = false;
    //         HyperLink214.Visible = false;
    //         Label214.Visible = false;
    //     }

    // }


    public int ValidateFileUploads()
    {
        int i = 0;

        if (ddlCSbillsofinstitutfinancedEnterpriseindustries.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lblAttachedFileName1.Text == "" || lblAttachedFileName1.Text == null || lblAttachedFileName1.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlBLAStatement_Brw.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lblBLAStatement_Brw.Text == "" || lblBLAStatement_Brw.Text == null || lblBLAStatement_Brw.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCCCoBorrwer.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lblddlCCCoBorrwer.Text == "" || lblddlCCCoBorrwer.Text == null || lblddlCCCoBorrwer.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlFacLicense.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lblFacLicense.Text == "" || lblFacLicense.Text == null || lblFacLicense.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlTMCStar.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lblTMCStar.Text == "" || lblTMCStar.Text == null || lblTMCStar.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddldeetregack.SelectedItem.Text.ToUpper() == "YES")
        {
            if (lbldeetregack.Text == "" || lbldeetregack.Text == null || lbldeetregack.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label101.Text == "" || Label101.Text == null || Label101.Text == string.Empty)
            {
                i = 1;
            }


        }
        if (ddlCSCasteCertificatesSCST.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label102.Text == "" || Label102.Text == null || Label102.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSEntrepreneurAadhar.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label103.Text == "" || Label103.Text == null || Label103.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSEntrepreneurPANCard.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label104.Text == "" || Label104.Text == null || Label104.Text == string.Empty)
            {
                i = 1;
            }


        }
        if (ddlCSCertificateofCA.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label105.Text == "" || Label105.Text == null || Label105.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSRegdPartnershipDeedArticles.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label106.Text == "" || Label106.Text == null || Label106.Text == string.Empty)
            {
                i = 1;
            }


        }
        if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label201.Text == "" || Label201.Text == null || Label201.Text == string.Empty)
            {
                i = 1;
            }


        }
        if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label202.Text == "" || Label202.Text == null || Label202.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label203.Text == "" || Label203.Text == null || Label203.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label204.Text == "" || Label204.Text == null || Label204.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label205.Text == "" || Label205.Text == null || Label205.Text == string.Empty)
            {
                i = 1;
            }
        }


        if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label206.Text == "" || Label206.Text == null || Label206.Text == string.Empty)
            {
                i = 1;
            }
        }

        if (ddlCSEnvironmentalclearance.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label207.Text == "" || Label207.Text == null || Label207.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSOtherstatutoryapprovalsspecif.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label208.Text == "" || Label208.Text == null || Label208.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSEMPartIfullsetIEMIL.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label209.Text == "" || Label209.Text == null || Label209.Text == string.Empty)
            {
                i = 1;
            }
        }

        if (ddlCSUdyogAadhar.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label210.Text == "" || Label210.Text == null || Label210.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSProjectReport.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label211.Text == "" || Label211.Text == null || Label211.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSTermloansanctionletters.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label212.Text == "" || Label212.Text == null || Label212.Text == string.Empty)
            {
                i = 1;
            }
        }

        if (ddlCSBoardResolutionauthorizing.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label213.Text == "" || Label213.Text == null || Label213.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label214.Text == "" || Label214.Text == null || Label214.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSCACECertificateregarding2handplantmachinery.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label215.Text == "" || Label215.Text == null || Label215.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSCECertificateSelffabricatedmachinery.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label216.Text == "" || Label216.Text == null || Label216.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSBISCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            if (HyperLink217.Text == "" || HyperLink217.Text == null || HyperLink217.Text == string.Empty)
            {
                i = 1;
            }

            //if (Label217.Text == "" || Label217.Text == null || Label217.Text == string.Empty)
            //{
            //    i = 1;
            //}
        }
        if (ddlCSDrugLicense.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label218.Text == "" || Label218.Text == null || Label218.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSExplosiveLicense.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label219.Text == "" || Label219.Text == null || Label219.Text == string.Empty)
            {
                i = 1;
            }
        }
        if (ddlCSVATCSTSGSTCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label220.Text == "" || Label220.Text == null || Label220.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSFormA.SelectedItem.Text.ToUpper() == "YES")
        {
            if (Label221.Text == "" || Label221.Text == null || Label221.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCSFormB.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label222.Text == "" || Label222.Text == null || Label222.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlProductionParticulars3Years.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label223.Text == "" || Label223.Text == null || Label223.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlRTACertificate.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label224.Text == "" || Label224.Text == null || Label224.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlPHCertificate.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label225.Text == "" || Label225.Text == null || Label225.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlUntertakingForm.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label226.Text == "" || Label226.Text == null || Label226.Text == string.Empty)
            {
                i = 1;
            }

        }

        if (ddlApplicantVehiclePhoto.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label227.Text == "" || Label227.Text == null || Label227.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
        {

            if (Label229.Text == "" || Label229.Text == null || Label229.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlBLAStatement_Brw.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lblBLAStatement_Brw.Text == "" || lblBLAStatement_Brw.Text == null || lblBLAStatement_Brw.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlCCCoBorrwer.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lblddlCCCoBorrwer.Text == "" || lblddlCCCoBorrwer.Text == null || lblddlCCCoBorrwer.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlFacLicense.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lblFacLicense.Text == "" || lblFacLicense.Text == null || lblFacLicense.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddlTMCStar.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lblTMCStar.Text == "" || lblTMCStar.Text == null || lblTMCStar.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddladdlocalemp1.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lbllocalemp1.Text == "" || lbllocalemp1.Text == null || lbllocalemp1.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (ddladdlocalemp2.SelectedItem.Text.ToUpper() == "YES")
        {

            if (lbllocalemp2.Text == "" || lbllocalemp2.Text == null || lbllocalemp2.Text == string.Empty)
            {
                i = 1;
            }

        }
        if (hdnMSMEApplied.Value == "Y")
        {
            if (hplCAMSME1.Text.Trim() == "")
            {
                i = 1;
            }
            if (hplCivilCert.Text.Trim() == "")
            {
                i = 1;
            }
            if (hplEnterpsriseDecl.Text.Trim() == "")
            {
                i = 1;
            }
            if (hplloanstmt.Text.Trim() == "")
            {
                i = 1;
            }
        }
        return i;
    }

    //protected void ddlProductionParticulars3Years_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlCSFormB.SelectedItem.Text.ToUpper() == "YES")
    //    {
    //        ddlProductionParticulars3Years.Visible = true;
    //        Button223.Visible = true;
    //        HyperLink223.Visible = true;
    //        Label223.Visible = false;
    //    }
    //    else
    //    {
    //        FileUpload223.Visible = false;
    //        Button223.Visible = false;
    //        HyperLink222.Visible = false;
    //        Label223.Visible = false;
    //    }
    //}

    protected void Button223_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload223.HasFile)
        {
            if ((FileUpload223.PostedFile != null) && (FileUpload223.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload223.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload223.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\223");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload223.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload223.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      223,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label223.Text = FileUpload223.FileName;
                        // Label222.Visible = true;
                        HyperLink223.Text = FileUpload223.FileName;
                        HyperLink223.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void ddlRTACertificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRTACertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload224.Visible = true;
            Button224.Visible = true;
            HyperLink224.Visible = true;
            Label224.Visible = false;
        }
        else
        {
            FileUpload224.Visible = false;
            Button224.Visible = false;
            HyperLink224.Visible = false;
            Label224.Visible = false;
        }
    }

    protected void Button224_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload224.HasFile)
        {
            if ((FileUpload224.PostedFile != null) && (FileUpload224.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload224.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload224.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\224");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload224.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload224.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      224,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label224.Text = FileUpload224.FileName;
                        // Label222.Visible = true;
                        HyperLink224.Text = FileUpload224.FileName;
                        HyperLink224.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }


    protected void ddlPHCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Failure.Visible = false;
        if (ddlPHCertificate.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload225.Visible = true;
            Button225.Visible = true;
            HyperLink225.Visible = true;
            Label225.Visible = false;
        }
        else
        {
            FileUpload225.Visible = false;
            Button225.Visible = false;
            HyperLink225.Visible = false;
            Label225.Visible = false;
        }
    }
    protected void Button225_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload225.HasFile)
        {
            if ((FileUpload225.PostedFile != null) && (FileUpload225.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload225.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload225.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\225");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload225.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload225.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      225,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label225.Text = FileUpload225.FileName;
                        // Label222.Visible = true;
                        HyperLink225.Text = FileUpload225.FileName;
                        HyperLink225.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void ddlUntertakingForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlUntertakingForm.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload226.Visible = true;
            Button226.Visible = true;
            HyperLink226.Visible = true;
            Label226.Visible = false;
        }
        else
        {
            FileUpload226.Visible = false;
            Button226.Visible = false;
            HyperLink226.Visible = false;
            Label226.Visible = false;
        }
    }
    protected void Button226_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload226.HasFile)
        {
            if ((FileUpload226.PostedFile != null) && (FileUpload226.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload226.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload226.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\226");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload226.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload226.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      226,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label226.Text = FileUpload226.FileName;
                        // Label222.Visible = true;
                        HyperLink226.Text = FileUpload226.FileName;
                        HyperLink226.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }



    protected void ddlApplicantVehiclePhoto_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Failure.Visible = false;
        if (ddlApplicantVehiclePhoto.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload227.Visible = true;
            Button227.Visible = true;
            HyperLink227.Visible = true;
            Label227.Visible = false;
        }
        else
        {
            FileUpload227.Visible = false;
            Button227.Visible = false;
            HyperLink227.Visible = false;
            Label227.Visible = false;
        }
    }
    protected void Button227_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload227.HasFile)
        {
            if ((FileUpload227.PostedFile != null) && (FileUpload227.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload227.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload227.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\227");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload227.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload227.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      227,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label227.Text = FileUpload227.FileName;
                        // Label222.Visible = true;
                        HyperLink227.Text = FileUpload227.FileName;
                        HyperLink227.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void ddlfirstsalebill_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfirstsalebill.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload228.Visible = true;
            Button228.Visible = true;
            HyperLink228.Visible = true;
            Label228.Visible = false;
        }
        else
        {
            FileUpload228.Visible = false;
            Button228.Visible = false;
            HyperLink228.Visible = false;
            Label228.Visible = false;
        }
    }


    protected void Button228_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload228.HasFile)
        {
            if ((FileUpload228.PostedFile != null) && (FileUpload228.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload228.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload228.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\228");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))
                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload228.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);
                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload228.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      228,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label228.Text = FileUpload228.FileName;
                        // Label222.Visible = true;
                        HyperLink228.Text = FileUpload228.FileName;
                        HyperLink228.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim();
        }
    }
    protected void Button229_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (FileUpload229.HasFile)
        {
            if ((FileUpload229.PostedFile != null) && (FileUpload229.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload229.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload229.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100019");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))
                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload229.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);
                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload229.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100019,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label229.Text = FileUpload229.FileName;
                        // Label222.Visible = true;
                        HyperLink229.Text = FileUpload229.FileName;
                        HyperLink229.Visible = true;
                        Button229.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim();
        }
    }


    protected void btnStatementBrw_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fulBLAStatement_Brw.HasFile)
        {
            if ((fulBLAStatement_Brw.PostedFile != null) && (fulBLAStatement_Brw.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fulBLAStatement_Brw.PostedFile.FileName);
                try
                {
                    string[] fileType = fulBLAStatement_Brw.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100020");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fulBLAStatement_Brw.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fulBLAStatement_Brw.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100020,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblBLAStatement_Brw.Text = fulBLAStatement_Brw.FileName;
                        hplBLAStatement_Brw.Text = fulBLAStatement_Brw.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lblBLAStatement_Brw.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void btnCCCoBorrwer_Click(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fulddlCCCoBorrwer.HasFile)
        {
            if ((fulddlCCCoBorrwer.PostedFile != null) && (fulddlCCCoBorrwer.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fulddlCCCoBorrwer.PostedFile.FileName);
                try
                {
                    string[] fileType = fulddlCCCoBorrwer.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100021");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fulddlCCCoBorrwer.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fulddlCCCoBorrwer.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA", 100021,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblddlCCCoBorrwer.Text = fulddlCCCoBorrwer.FileName;
                        hplddlCCCoBorrwer.Text = fulddlCCCoBorrwer.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lblddlCCCoBorrwer.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void btnFacLicense_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        
        
        General t1 = new General();
        if (fulFacLicense.HasFile)
        {
            if ((fulFacLicense.PostedFile != null) && (fulFacLicense.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fulFacLicense.PostedFile.FileName);
                try
                {
                    string[] fileType = fulFacLicense.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100022");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fulFacLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fulFacLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100022,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFacLicense.Text = fulFacLicense.FileName;
                        hplFacLicense.Text = fulFacLicense.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lblFacLicense.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void btnTMCStar_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fulTMCStar.HasFile)
        {
            if ((fulTMCStar.PostedFile != null) && (fulTMCStar.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fulTMCStar.PostedFile.FileName);
                try
                {
                    string[] fileType = fulTMCStar.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100023");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fulTMCStar.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fulTMCStar.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100023,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblTMCStar.Text = fulTMCStar.FileName;
                        hplTMCStar.Text = fulTMCStar.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lblTMCStar.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }




    protected void ddlCOBORROWER_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
        {
            FileUpload229.Visible = true;
            Button229.Visible = true;
            HyperLink229.Visible = true;
            Label229.Visible = false;
        }

        else
        {
            FileUpload229.Visible = false;
            Button229.Visible = false;
            HyperLink229.Visible = false;
            Label229.Visible = false;
        }
    }


    protected void ddlBLAStatement_Brw_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBLAStatement_Brw.SelectedItem.Text.ToUpper() == "YES")
        {
            fulBLAStatement_Brw.Visible = true;
            btnBLAStatement_Brw.Visible = true;
            hplBLAStatement_Brw.Visible = true;
            lblBLAStatement_Brw.Visible = false;
        }

        else
        {
            fulBLAStatement_Brw.Visible = false;
            btnBLAStatement_Brw.Visible = false;
            hplBLAStatement_Brw.Visible = false;
            lblBLAStatement_Brw.Visible = false;
        }
    }
    protected void ddlCCCoBorrwer_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCCCoBorrwer.SelectedItem.Text.ToUpper() == "YES")
        {
            fulddlCCCoBorrwer.Visible = true;
            btnddlCCCoBorrwer.Visible = true;
            hplddlCCCoBorrwer.Visible = true;
            lblddlCCCoBorrwer.Visible = false;
        }

        else
        {
            fulddlCCCoBorrwer.Visible = false;
            btnddlCCCoBorrwer.Visible = false;
            hplddlCCCoBorrwer.Visible = false;
            lblddlCCCoBorrwer.Visible = false;
        }
    }
    protected void ddlFacLicense_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFacLicense.SelectedItem.Text.ToUpper() == "YES")
        {
            fulFacLicense.Visible = true;
            btnFacLicense.Visible = true;
            hplFacLicense.Visible = true;
            lblFacLicense.Visible = false;
        }

        else
        {
            fulFacLicense.Visible = false;
            btnFacLicense.Visible = false;
            hplFacLicense.Visible = false;
            lblFacLicense.Visible = false;
        }
    }
    protected void ddlTMCStar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTMCStar.SelectedItem.Text.ToUpper() == "YES")
        {
            fulTMCStar.Visible = true;
            btnTMCStar.Visible = true;
            hplTMCStar.Visible = true;
            lblTMCStar.Visible = false;
        }

        else
        {
            fulTMCStar.Visible = false;
            btnTMCStar.Visible = false;
            hplTMCStar.Visible = false;
            lblTMCStar.Visible = false;
        }
    }

    public void ResetFormControl(Control parent)
    {
        try
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
                            if (((FileUpload)c).ID != "fupdeetregack")
                                ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    //additional local emp//
    protected void ddladdlocalemp2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladdlocalemp2.SelectedItem.Text.ToUpper() == "YES")
        {
            Addlocalempup2.Visible = true;
            btnlocalemp2.Visible = true;
            hplAddlocalemp2.Visible = true;
            lbllocalemp2.Visible = false;
        }

        else
        {
            Addlocalempup2.Visible = false;
            btnlocalemp2.Visible = false;
            hplAddlocalemp2.Visible = false;
            lbllocalemp2.Visible = false;
        }
    }


    protected void ddladdlocalemp1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladdlocalemp1.SelectedItem.Text.ToUpper() == "YES")
        {
            Addlocalempup1.Visible = true;
            btnlocalemp1.Visible = true;
            hplAddlocalemp1.Visible = true;
            lbllocalemp1.Visible = false;
        }

        else
        {
            Addlocalempup1.Visible = false;
            btnlocalemp1.Visible = false;
            hplAddlocalemp1.Visible = false;
            lbllocalemp1.Visible = false;
        }
    }

    protected void btnlocalemp1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (Addlocalempup1.HasFile)
        {
            if ((Addlocalempup1.PostedFile != null) && (Addlocalempup1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(Addlocalempup1.PostedFile.FileName);
                try
                {
                    string[] fileType = Addlocalempup1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100024");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            Addlocalempup1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                Addlocalempup1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100024,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lbllocalemp1.Text = Addlocalempup1.FileName;
                        hplAddlocalemp1.Text = Addlocalempup1.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lbllocalemp1.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }



    protected void btnlocalemp2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (Addlocalempup2.HasFile)
        {
            if ((Addlocalempup2.PostedFile != null) && (Addlocalempup2.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(Addlocalempup2.PostedFile.FileName);
                try
                {
                    string[] fileType = Addlocalempup2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100025");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            Addlocalempup2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                Addlocalempup2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100025,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lbllocalemp2.Text = Addlocalempup2.FileName;
                        hplAddlocalemp2.Text = Addlocalempup2.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lbllocalemp2.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void ddldeetregack_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldeetregack.SelectedItem.Text.ToUpper() == "YES")
        {
            fupdeetregack.Visible = true;
            btndeetregack.Visible = true;
            hypdeetregack.Visible = true;
            lbldeetregack.Visible = false;
        }
        else
        {
            fupdeetregack.Visible = false;
            btndeetregack.Visible = false;
            hypdeetregack.Visible = false;
            lbldeetregack.Visible = false;
        }
    }

    protected void btndeetregack_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fupdeetregack.HasFile)
        {
            if ((fupdeetregack.PostedFile != null) && (fupdeetregack.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupdeetregack.PostedFile.FileName);
                try
                {
                    string[] fileType = fupdeetregack.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\100050");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupdeetregack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupdeetregack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      100050,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lbldeetregack.Text = fupdeetregack.FileName;
                        hypdeetregack.Text = fupdeetregack.FileName;
                        //  lblAttachedFileName1.Visible = true;
                        //lblupload1.Text = fuDo/*/*c*/*/uments1.FileName;
                        lbldeetregack.Visible = true;
                        success.Visible = true;
                        //Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }
    protected void btnCAMSME1_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fupCAMSME1.HasFile)
            {
                if ((fupCAMSME1.PostedFile != null) && (fupCAMSME1.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupCAMSME1.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupCAMSME1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\901");

                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;

                            if (count == 0)
                                fupCAMSME1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupCAMSME1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                          901,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblCAMSME1.Text = fupCAMSME1.FileName;
                            hplCAMSME1.Text = fupCAMSME1.FileName;
                            success.Visible = true;
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
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        catch (Exception ex) { }
    }
    protected void btnCivilCert_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fupCivilCert.HasFile)
            {
                if ((fupCivilCert.PostedFile != null) && (fupCivilCert.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupCivilCert.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupCivilCert.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\902");

                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;

                            if (count == 0)
                                fupCivilCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupCivilCert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                          902,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hplCivilCert.Text = fupCivilCert.FileName;
                            lblCivilCert.Text = fupCivilCert.FileName;
                            success.Visible = true;
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
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        catch (Exception ex) { }

    }
    protected void btnEnterpsriseDecl_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fupEnterpsriseDecl.HasFile)
            {
                if ((fupEnterpsriseDecl.PostedFile != null) && (fupEnterpsriseDecl.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupEnterpsriseDecl.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupEnterpsriseDecl.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\903");

                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;

                            if (count == 0)
                                fupEnterpsriseDecl.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupEnterpsriseDecl.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                          903,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblEnterpsriseDecl.Text = fupEnterpsriseDecl.FileName;
                            hplEnterpsriseDecl.Text = fupEnterpsriseDecl.FileName;
                            success.Visible = true;
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
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        catch (Exception ex) { }
    }

    protected void btnloanstmt_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fuploanstmt.HasFile)
            {
                if ((fuploanstmt.PostedFile != null) && (fuploanstmt.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fuploanstmt.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fuploanstmt.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\904");

                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;

                            if (count == 0)
                                fuploanstmt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuploanstmt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                          904,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblloanstmt.Text = fuploanstmt.FileName;
                            hplloanstmt.Text = fuploanstmt.FileName;
                            success.Visible = true;
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
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        catch (Exception ex) { }

    }

}




