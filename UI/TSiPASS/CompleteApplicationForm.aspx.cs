using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;

public partial class UI_TSiPASS_CompleteApplicationForm : System.Web.UI.Page
{
    General Gen = new General();

    DataSet ds = new DataSet();
    DataSet dsCAF = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string incentiveID = "";
            if (!IsPostBack)
            {
                string userid = Session["uid"].ToString();
                if (Session["uid"] != null)
                {
                    string uname = Session["username"].ToString();
                    // 

                    if (Session["EntprIncentive"] != null)
                    {

                        incentiveID = Session["EntprIncentive"].ToString();
                    }
                    else
                    {
                        incentiveID = Request.QueryString["EntrpId"].ToString();
                    }
                    //dsCAF = Gen.GetAllIncentives(Session["uid"].ToString().Trim());            
                    dsCAF = Gen.GetAllIncentivesDeptView(incentiveID);
                    string IncentiveId = dsCAF.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                    if (IncentiveId != null)
                    {
                        if (!IsPostBack)
                        {
                            string useridnew = Session["uid"].ToString();
                            string IncentveID = incentiveID;
                            DataSet dscaste = new DataSet();
                            dscaste = Gen.GetIncentivesCaste(useridnew, IncentveID);
                            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                            {
                                string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                                if (dscaste.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>T-PRIDE (TSCP)</center>" + "</br><center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";
                                    //lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                                }
                                else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>T-PRIDE (TSP)</center>" + "</br><center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";
                                }
                                else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>T-IDEA</center>" + "</br><center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";
                                }
                                if (dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "2" || dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "3")
                                {
                                    trexpansion.Visible = true;
                                    trexpansionhead.Visible = true;
                                    tblpower.Visible = true;

                                    tr2.Visible = false;
                                    tr1.Visible = true;
                                }
                                else
                                {
                                    trexpansion.Visible = false;
                                    trexpansionhead.Visible = false;
                                    tblpower.Visible = false;

                                    tr2.Visible = true;
                                    tr1.Visible = false;
                                }
                            }

                            if (Request.QueryString.Count > 0 && Request.QueryString["q"] != null)
                            {
                                int str = Convert.ToInt32(Request.QueryString["q"]);
                                if (str == 3)
                                {
                                    DataSet ds = new DataSet();
                                    ds = Gen.GetIncentiveDeptDetails(IncentiveId);
                                    FillDetails(ds);
                                    BtnNext.Visible = true;
                                    // BtnPrevious.Visible = true;
                                    return;
                                }
                            }
                            else
                            {
                                BtnNext.Visible = false;
                            }

                            DataSet ds1 = new DataSet();
                            ds1 = Gen.GetIncentiveDeptDetails(IncentiveId);
                            FillDetails(ds1);
                            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                            {
                                if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                {
                                    BindForms(dsCAF, IncentiveId);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            DataSet ds2 = new DataSet();
                            ds2 = Gen.GetIncentiveDeptDetailsCreatedBy(userid);
                            string IncentID = FillDetails(ds2);

                            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                            {
                                if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                {
                                    BindForms(dsCAF, IncentID);
                                }
                            }
                        }
                    }

                }

                #region InvestmentSubsidy

                string IncIDfrData = incentiveID;
                DataSet ds5 = new DataSet();
                ds5 = Gen.GetIncentiveDeptDetails(IncIDfrData);
                FillDetailsNewis(ds5);

                DataSet dsInsp = new DataSet();

                //dtMyTableCertificate = createtablecrtificate1();
                //Session["CertificateTb2"] = dtMyTableCertificate;


                // string IncentiveId = incentiveID;
                DataSet dsnew = new DataSet();
                dsnew = Gen.GetIncentivesISdata(incentiveID, "6");
                FilldataISnew(dsnew);

                DataSet dsname = new DataSet();
                dsname = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveID, "6", "");
                if (dsname.Tables.Count > 0 && dsname.Tables[0].Rows.Count > 0)
                {
                    if (dsname.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblName.Text = dsname.Tables[0].Rows[0]["EmpName"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                    }
                }

                #endregion

                #region PV

                DataSet ds2pv = new DataSet();
                ds2pv = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "1");
                binddatanew(ds2pv);

                #endregion

                #region pt
                DataSet ds2pt = new DataSet();
                ds2pt = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "3");
                binddatanewpt(ds2pt);

                DataSet dsnamept = new DataSet();
                dsnamept = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveID, "6", "");
                if (dsnamept.Tables.Count > 0 && dsnamept.Tables[0].Rows.Count > 0)
                {
                    if (dsnamept.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblName.Text = dsnamept.Tables[0].Rows[0]["EmpName"].ToString() + "</br>" + dsnamept.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsnamept.Tables[0].Rows[0]["Dist"].ToString();
                    }
                }
                #endregion

                #region sales tax
                DataSet ds2st = new DataSet();
                ds2st = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "5");
                binddatanewst(ds2st);

                DataSet dsnamest = new DataSet();
                dsnamest = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveID, "5", "");
                if (dsnamest.Tables.Count > 0 && dsnamest.Tables[0].Rows.Count > 0)
                {
                    if (dsnamest.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblNamest.Text = dsnamest.Tables[0].Rows[0]["EmpName"].ToString() + "</br>" + dsnamest.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsnamest.Tables[0].Rows[0]["Dist"].ToString();
                    }
                }
                #endregion

                #region Stampduty
                DataSet ds2sd = new DataSet();
                ds2sd = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "9");
                binddatanewsd(ds2sd);
                #endregion

                #region Seed Cap
                DataSet ds2sc = new DataSet();
                ds2sc = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "10");
                binddatanewsc(ds2sc);
                #endregion

                #region QC
                DataSet ds2QC = new DataSet();
                ds2QC = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "11");
                binddatanewQC(ds2QC);
                #endregion

                #region CP
                DataSet ds2cp = new DataSet();
                ds2cp = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "4");
                binddatanewCP(ds2cp);
                #endregion

                #region SU
                DataSet ds2SU = new DataSet();
                ds2SU = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "8");
                binddatanewSU(ds2SU);
                #endregion

                #region IIDF
                DataSet dsIIDF = new DataSet();
                dsIIDF = Gen.GetIncentiveDeptDetails(incentiveID);
                FillDetailsIIDF(dsIIDF);

                DataSet ds2IIDF = new DataSet();
                ds2IIDF = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "7"); // -- IIDF
                binddatanewIIDF(ds2IIDF);

                DataSet dsnameiidf = new DataSet();
                dsnameiidf = Gen.GetIPORecommendationOfficerDetailsDIC(incentiveID, "7", "");  // -- IIDF
                if (dsnameiidf.Tables.Count > 0 && dsnameiidf.Tables[0].Rows.Count > 0)
                {
                    if (dsnameiidf.Tables[0].Rows[0]["EmpName"].ToString() != null)
                    {
                        lblDICName.Text = dsnameiidf.Tables[0].Rows[0]["EmpName"].ToString(); // + "</br>" + dsname.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + dsname.Tables[0].Rows[0]["Dist"].ToString();
                        lblGMname.Text = dsnameiidf.Tables[0].Rows[0]["EmpName"].ToString();
                    }
                }
                #endregion

                #region AdvancedSS
                DataSet ds2AdvancedSS = new DataSet();
                ds2AdvancedSS = Gen.GetBasicUnitDetails_Proforma_letters(incentiveID, "12");
                binddatanewASS(ds2AdvancedSS);
                #endregion
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }


    public string FillDetails(DataSet ds)
    {
        string IncentID = "";
        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    divCommonAppli.Visible = true;
                    IncentID = ds.Tables[0].Rows[0]["IncentveID"].ToString();

                    txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                    txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                    ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();

                    ddlindustryStatus.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();

                    txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();

                    rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                    rblCaste.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();

                    ddldistrictunit.Text = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                    ddlUnitMandal.Text = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                    ddlVillageunit.Text = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                    txtunitaddhno.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                    txtstreetunit.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                    txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                    txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();

                    ddldistrictoffc.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                    ddloffcmandal.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                    ddlvilloffc.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                    txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                    txtstreetoffice.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                    txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                    txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

                    gvLOA.DataSource = null;
                    gvLOA.DataBind();
                    gvLOA.DataSource = ds.Tables[1];
                    gvLOA.DataBind();
                    if (ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "1")
                    {
                        tr2.Visible = true;
                        tr1.Visible = false;
                        txtlandexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                        txtbuildingexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                        txtplantexistingNew.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "2" || ds.Tables[0].Rows[0]["IdsustryStatus1"].ToString() == "3")
                    {
                        tr1.Visible = true;
                        tr2.Visible = false;

                        txteeploa.Text = ds.Tables[0].Rows[0]["ExistingEnterpriseLOA"].ToString();
                        txteepinscap.Text = ds.Tables[0].Rows[0]["ExistingInstalledCapacityinEnter"].ToString();
                        ddleepinscap.Text = ds.Tables[0].Rows[0]["eepinscapUnit"].ToString();
                        txteeppercentage.Text = ds.Tables[0].Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();
                        txtedploa.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLOA"].ToString();
                        txtedpinscap.Text = ds.Tables[0].Rows[0]["ExpanORDiversInstalledCapacityinEnter"].ToString();
                        ddledpinscap.Text = ds.Tables[0].Rows[0]["edpinscapUnit"].ToString();
                        txtedppercentage.Text = ds.Tables[0].Rows[0]["ExpanORDiversPercentIncreaseunderExpansionORDiversification"].ToString();

                        txtlandexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                        txtlandexpandiver.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                        txtlandpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                        txtbuildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                        txtbuildingexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                        txtbuildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                        txtplantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                        txtplantexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                        txtplantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();
                    }
                    // grid view code binding  // for directors/ proprietors
                    GridViewdirectors.DataSource = null;
                    GridViewdirectors.DataBind();
                    GridViewdirectors.DataSource = ds.Tables[2];
                    GridViewdirectors.DataBind();

                    ddlPowerStatus.Text = ds.Tables[0].Rows[0]["PowerType"].ToString();

                    if (ddlPowerStatus.Text == "New Industry")
                    {
                        //trpower1.Visible = true;
                        //trpower2.Visible = false;
                        txtNewPowerReleaseDate.Text = ds.Tables[0].Rows[0]["PowerReleaseDate"].ToString();
                        txtNewContractedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                        txtNewConnectedLoad.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                        txtServiceConnectionNumberNew.Text = ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString();
                    }
                    if (ddlPowerStatus.Text == "Expansion/Diversification")
                    {
                        //trpower1.Visible = false;
                        //trpower2.Visible = true;
                        lblexistingpower.Text = "Existing Enterprise production details";
                        lblexpandiverpower.Text = "Expansion / Diversification details";

                        txtExistPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                        txtExistContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                        txtExistConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                        txtServiceConnectionNumberExist.Text = ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString();
                        txtExpanPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                        txtExpanContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                        txtExpanConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                        txtServiceConnectionNumberExpan.Text = ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString();
                    }

                    txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                    txtStaffFemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                    txtSuprMale.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                    txtSuperFemale.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                    txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();

                    //txtprjfinance.Text = ds.Tables[0].Rows[0]["ProjectFinance"].ToString();
                    txtTermloan.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                    txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString();
                    txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString();
                    txtdatesanctioned.Text = ds.Tables[0].Rows[0]["TermloanSandate"].ToString();

                    // Name of Assets binding
                    if (ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString() != "")
                        txtLand2.Text = ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString();
                    else
                        txtLand2.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["LandLoanSactioned"].ToString() != "")
                        txtLand3.Text = ds.Tables[3].Rows[0]["LandLoanSactioned"].ToString();
                    else
                        txtLand3.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["LandPromotersEquity"].ToString() != "")
                        txtLand4.Text = ds.Tables[3].Rows[0]["LandPromotersEquity"].ToString();
                    else
                        txtLand4.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["LandLoanAmountReleased"].ToString() != "")
                        txtLand5.Text = ds.Tables[3].Rows[0]["LandLoanAmountReleased"].ToString();
                    else
                        txtLand5.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString() != "")
                        txtLand6.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                    else
                        txtLand6.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString() != "")
                        txtLand7.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString();
                    else
                        txtLand7.Text = "0.00";


                    if (ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString() != "")
                        txtBuilding2.Text = ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString();
                    else
                        txtBuilding2.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["BuildingLoanSactioned"].ToString() != "")
                        txtBuilding3.Text = ds.Tables[3].Rows[0]["BuildingLoanSactioned"].ToString();
                    else
                        txtBuilding3.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["BuildingPromotersEquity"].ToString() != "")
                        txtBuilding4.Text = ds.Tables[3].Rows[0]["BuildingPromotersEquity"].ToString();
                    else
                        txtBuilding4.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["BuildingLoanAmountReleased"].ToString() != "")
                        txtBuilding5.Text = ds.Tables[3].Rows[0]["BuildingLoanAmountReleased"].ToString();
                    else
                        txtBuilding5.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString() != "")
                        txtBuilding6.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                    else
                        txtBuilding6.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString() != "")
                        txtBuilding7.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                    else
                        txtBuilding7.Text = "0.00";


                    if (ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString() != "")
                        txtPM2.Text = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                    else
                        txtPM2.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString() != "")
                        txtPM3.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                    else
                        txtPM3.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString() != "")
                        txtPM4.Text = ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                    else
                        txtPM4.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString() != "")
                        txtPM5.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                    else
                        txtPM5.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString() != "")
                        txtPM6.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                    else
                        txtPM6.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString() != "")
                        txtPM7.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                    else
                        txtPM7.Text = "0.00";

                    if (ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString() != "")
                        txtMCont2.Text = ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                    else
                        txtMCont2.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString() != "")
                        txtMCont3.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                    else
                        txtMCont3.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString() != "")
                        txtMCont4.Text = ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                    else
                        txtMCont4.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString() != "")
                        txtMCont5.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                    else
                        txtMCont5.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString() != "")
                        txtMCont6.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                    else
                        txtMCont6.Text = "0.00";
                    if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString() != "")
                        txtMCont7.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                    else
                        txtMCont7.Text = "0.00";


                    txtErec2.Text = ds.Tables[3].Rows[0]["ErectionApprovedProjectCost"].ToString();
                    txtErec3.Text = ds.Tables[3].Rows[0]["ErectionLoanSactioned"].ToString();
                    txtErec4.Text = ds.Tables[3].Rows[0]["ErectionPromotersEquity"].ToString();
                    txtErec5.Text = ds.Tables[3].Rows[0]["ErectionLoanAmountReleased"].ToString();
                    txtErec6.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                    txtErec7.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyCA"].ToString();

                    txtTFS2.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                    txtTFS3.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                    txtTFS4.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                    txtTFS5.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                    txtTFS6.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                    txtTFS7.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();

                    txtWC2.Text = ds.Tables[3].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                    txtWC3.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                    txtWC4.Text = ds.Tables[3].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                    txtWC5.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                    txtWC6.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                    txtWC7.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                    txtsecondhndmachine.Text = ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString();
                    txtnewmachine.Text = ds.Tables[0].Rows[0]["NewMachVal"].ToString();
                    txtTotalvalue12.Text = ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString();
                    txtpercentage12.Text = ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString();
                    txtmachinepucr.Text = ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString();
                    txttotal25.Text = ds.Tables[0].Rows[0]["TotalMachVal"].ToString();


                    txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedScheme"].ToString();
                    txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedAmount"].ToString();
                    txtSchemeEligible.Text = "";
                    txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["InvestimentSubsidy"].ToString();
                    txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomen"].ToString();
                    //txtAppldAddlAmtSCST.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForSCORST"].ToString();
                    //  txtAppldAddlAmtScheduldAreas.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomenInScheduledAreas"].ToString();
                    txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["TotalAppliedIncetives"].ToString();


                    if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "Y")
                    {
                        // ddlsubsidy.Text = "Yes";
                    }
                    else if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "N")
                    {
                        // ddlsubsidy.Text = "No";
                    }

                    //ddlBank.Text = ds.Tables[4].Rows[0]["BankName"].ToString();
                    //txtAccNumber.Text = ds.Tables[4].Rows[0]["AccNo"].ToString();
                    //txtBranchName.Text = ds.Tables[4].Rows[0]["BranchName"].ToString();
                    //txtIfscCode.Text = ds.Tables[4].Rows[0]["IFSCCode"].ToString();
                    //ddlPower.Text = ds.Tables[4].Rows[0]["WhetherPower"].ToString();

                    txtvatno.Text = ds.Tables[0].Rows[0]["VATNo"].ToString();
                    txtcstno.Text = ds.Tables[0].Rows[0]["CSTNo"].ToString();
                    txtCSTRegDate.Text = ds.Tables[0].Rows[0]["CSTRegDate"].ToString();
                    txtCSTRegAuthority.Text = ds.Tables[0].Rows[0]["CSTRegAuthority"].ToString();
                    txtCSTRegAuthAddress.Text = ds.Tables[0].Rows[0]["CSTRegAuthAddress"].ToString();
                    lblEMPartNo.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();

                    return IncentID;
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
        return IncentID;
    }

    public void BindForms(DataSet ds, string incentiveID)
    {

        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string MasterIncentiveId = ds.Tables[0].Rows[i]["IncentiveID"].ToString();

                        if (MasterIncentiveId == "6")  //IS
                        {
                            DataSet ds6 = new DataSet();
                            ds6 = Gen.GetIncentivesISdata(incentiveID, "6");
                            FilldataIS(ds6);
                            divInvestmenSubsidy.Visible = true;
                        }

                        else if (MasterIncentiveId == "9") //STAMP DUTY
                        {
                            DataSet ds9 = new DataSet();
                            ds9 = Gen.GetIncentivesStampDutydata(incentiveID);
                            FilldataStampDuty(ds9);
                            divStampDuty.Visible = true;
                        }
                        else if (MasterIncentiveId == "3")  // pOWER
                        {
                            DataSet ds3 = new DataSet();
                            ds3 = Gen.GetFormIIIIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsPower(ds3);
                            divPowerCost.Visible = true;
                        }
                        else if (MasterIncentiveId == "1")  // PV
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = Gen.GetFormIVIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsPavalaVaddi(ds1);
                            divPavalaVaddi.Visible = true;
                        }
                        else if (MasterIncentiveId == "5")  // SALES TAX
                        {
                            DataSet ds5 = new DataSet();
                            ds5 = Gen.GetFormVIncentives(Convert.ToInt32(incentiveID));
                            FillDetailsSalesTax(ds5);
                            divSalesTax.Visible = true;
                        }
                        else if (MasterIncentiveId == "11")  // qc
                        {
                            DataSet ds11 = new DataSet();
                            ds11 = Gen.GetIncentivesfrom4data(incentiveID);
                            FillDetailsQualityCertification(ds11);
                            divQualityCertification.Visible = true;
                        }
                        else if (MasterIncentiveId == "10")  // seed cap
                        {
                            DataSet ds10 = new DataSet();
                            ds10 = Gen.GetIncentives_SEED_CAP_data(incentiveID);
                            //  FillDetailsQualityCertification(ds10);
                            //divQualityCertification.Visible = true;

                        }
                        else if (MasterIncentiveId == "4")
                        {
                            DataSet ds4 = new DataSet();
                            ds4 = Gen.GetIncentivesfrom8data(incentiveID);
                            FillDetailsCleanerProduction(ds4);
                            divCleanerProduction.Visible = true;
                        }
                        else if (MasterIncentiveId == "8")
                        {
                            DataSet ds8 = new DataSet();
                            ds8 = Gen.GetIncentivesfrom9data(incentiveID);
                            FillDetailsSkillUpgradation(ds8);
                            divSkillupgradation.Visible = true;
                        }
                        else if (MasterIncentiveId == "7")
                        {
                            DataSet ds7 = new DataSet();
                            ds7 = Gen.GetIncentivesIIDFunddata(incentiveID);
                            FilldataIIDFund(ds7);
                        }
                        else if (MasterIncentiveId == "12")
                        {
                            DataSet ds12 = new DataSet();
                            ds12 = Gen.GetIncentivesAdvSubsidySCST(incentiveID);
                            FilldataSCSCT(ds12);
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    // bind forms methods
    private void FilldataIS(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AppldAddlAmtWomen"].ToString();
                txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldInvestSubsidy"].ToString();
                txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["AppldTotInvestSubsidy"].ToString();
                txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["AvldSubsidyAmt"].ToString();
                txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["AvldSubsidyScheme"].ToString();
                txtSchemeEligible.Text = ds.Tables[0].Rows[0]["SchemeEligible"].ToString();

                #region fileuploadbinding IS
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("62"))
                //        {
                //            lblUpload1.NavigateUrl = sen;
                //            lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("63"))
                //        {
                //            lblUpload2.NavigateUrl = sen;
                //            lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FilldataStampDuty(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtAreaRegdSaledeed.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
                txtPlnthAreaBuild.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
                txtFivePlnthAreaBuild.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
                txtAreaReqdAppraisal.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
                txtAreaReqdTSPCB.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
                txtNatureofTrans.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

                txtSubRegOffc.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
                txtRegdDeedNo.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
                txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
                txtStampTranfrDutyAP.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAP"].ToString();
                txtMortgageHypothDutyAP.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
                txtLandConvrChrgAP.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();

                txtLandCostIeIdaIpAP.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
                txtStampTranfrDutyAC.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAC"].ToString();
                txtMortgageHypothDutyAC.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
                txtLandConvrChrgAC.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
                txtLandCostIeIdaIpAC.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();

                #region fileuploadbinding StampDuty
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("60"))
                //        {
                //            lblupload1.NavigateUrl = sen;
                //            lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("61"))
                //        {
                //            lblUpload2.NavigateUrl = sen;
                //            lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FillDetailsPower(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtClaimedAmount.Text = ds.Tables[0].Rows[0]["AmountClaimed"].ToString();
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtPowerIncentives"] = ds.Tables[1];
                    gvPowerIncentives.DataSource = ds.Tables[1];
                    gvPowerIncentives.DataBind();
                }
                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ViewState["dtEnergy"] = ds.Tables[2];
                    gvEnergy.DataSource = ds.Tables[2];
                    gvEnergy.DataBind();
                }

                #region FileUploading Power
                //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[3];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();
                //        sen2 = dr["link"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "49")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "50")
                //        {
                //            HyperLink1.NavigateUrl = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label4.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "51")
                //        {
                //            HyperLink2.NavigateUrl = sen;
                //            HyperLink2.Text = dr["FileNm"].ToString();
                //            Label5.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "52")
                //        {
                //            HyperLink3.NavigateUrl = sen;
                //            HyperLink3.Text = dr["FileNm"].ToString();
                //            Label6.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "53")
                //        {
                //            HyperLink4.NavigateUrl = sen;
                //            HyperLink4.Text = dr["FileNm"].ToString();
                //            Label7.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "54")
                //        {
                //            HyperLink5.NavigateUrl = sen;
                //            HyperLink5.Text = dr["FileNm"].ToString();
                //            Label7.Text = dr["FileNm"].ToString();
                //        }
                //    }

                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FillDetailsPavalaVaddi(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["dtDCP"] = ds.Tables[0];
                    gvInterestDCP.DataSource = ds.Tables[0];
                    gvInterestDCP.DataBind();
                }

                #region  FileUploading Pavala Vaddi
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[1];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();

                //        sen2 = dr["FilePath"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "58")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "59")
                //        {
                //            HyperLink1.Text = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label2.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "64")
                //        {
                //            HyperLink2.Text = sen;
                //            HyperLink2.Text = dr["link"].ToString();
                //            Label2.Text = dr["FileNm"].ToString();
                //        }
                //    }
                //}
                #endregion
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }

    }

    private void FillDetailsSalesTax(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["dtProductiondtls"] = ds.Tables[0];
                    gvProductiondtls.DataSource = ds.Tables[0];
                    gvProductiondtls.DataBind();
                }
                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ViewState["dtSalesTax"] = ds.Tables[1];
                    gvSalesTax.DataSource = ds.Tables[1];
                    gvSalesTax.DataBind();
                }

                #region  File Uploading Sales Tax
                //if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                //{
                //    DataTable table = ds.Tables[2];
                //    string sen, sen1, sen2;

                //    foreach (DataRow dr in table.Rows)
                //    {
                //        string AttcahmentId = dr["AttachmentId"].ToString();

                //        sen2 = dr["FilePath"].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (AttcahmentId == "55")
                //        {
                //            lblFileName.NavigateUrl = sen;
                //            lblFileName.Text = dr["FileNm"].ToString();
                //            Label444.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "57")
                //        {
                //            HyperLink1.NavigateUrl = sen;
                //            HyperLink1.Text = dr["FileNm"].ToString();
                //            Label4.Text = dr["FileNm"].ToString();
                //        }
                //        if (AttcahmentId == "58")
                //        {
                //            HyperLink2.NavigateUrl = sen;
                //            HyperLink2.Text = dr["FileNm"].ToString();
                //            Label5.Text = dr["FileNm"].ToString();
                //        }
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FillDetailsQualityCertification(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofagency"].ToString();
                txtCertificatNumber.Text = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
                txtDateofIssue.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofIssue"].ToString()).ToString("dd/MM/yyyy");
                txtPeriodofValidity.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["periodofvalidity"].ToString()).ToString("dd/MM/yyyy");
                txtAmountspentinacquiringthecertification.Text = ds.Tables[0].Rows[0]["Amountspentinacquiringthecertification"].ToString();
                txtFromCentralGovernment.Text = ds.Tables[0].Rows[0]["FromCentralGovernment"].ToString();
                txtFromStateGovernment.Text = ds.Tables[0].Rows[0]["FromStateGovernment"].ToString();
                txtFinancingInstitution.Text = ds.Tables[0].Rows[0]["Fromfinancinginstitution"].ToString();

                ddlstate.Text = ds.Tables[0].Rows[0]["intStateid"].ToString();

                if (ds.Tables[0].Rows[0]["intStateid"].ToString() == "31")
                {
                    ddlDistrict.Text = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
                    ddlmandal.Text = ds.Tables[0].Rows[0]["intMandalid"].ToString();
                    ddlvillage.Text = ds.Tables[0].Rows[0]["intVillageid"].ToString();
                }
                else
                {
                    ddlDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                    ddlmandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                    ddlvillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();
                }

                txtdoorno.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                txtpincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            }

            #region File Uploading Quality Certification
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9014")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9015")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9016")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FillDetailsCleanerProduction(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvCertificate.DataSource = ds.Tables[0];
                gvCertificate.DataBind();
                txtsubsidyclaimed.Text = ds.Tables[0].Rows[0]["subsidyclaimed"].ToString();
            }

            #region  File Uploading Cleaner Production
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9022")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9023")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9024")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FillDetailsSkillUpgradation(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofthetraininginstitute"].ToString();
                txtNameoftheskilldevelopmentprogramme.Text = ds.Tables[0].Rows[0]["Nameoftheskilldevelopmentprogramme"].ToString();
                txtNumberskilledemployees.Text = ds.Tables[0].Rows[0]["Numberskilledemployees"].ToString();
                txtExpenditureincurredfortrainingprogramme.Text = ds.Tables[0].Rows[0]["Expenditureincurredtrainingprogramme"].ToString();
                txtAmountclaimedinRs.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
                txtDurationoftraining.Text = ds.Tables[0].Rows[0]["Durationoftraining"].ToString();
            }

            #region File Uploading Skill Upgradation
            //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            //{
            //    DataTable table = ds.Tables[1];
            //    string sen, sen1, sen2;

            //    foreach (DataRow dr in table.Rows)
            //    {
            //        string AttcahmentId = dr["AttachmentId"].ToString();
            //        sen2 = dr["link"].ToString();
            //        sen1 = sen2.Replace(@"\", @"/");
            //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

            //        if (AttcahmentId == "9018")
            //        {
            //            Label453.NavigateUrl = sen;
            //            Label453.Text = dr["FileNm"].ToString();
            //            Label454.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9019")
            //        {
            //            HyperLink1.NavigateUrl = sen;
            //            HyperLink1.Text = dr["FileNm"].ToString();
            //            Label8.Text = dr["FileNm"].ToString();
            //        }
            //        if (AttcahmentId == "9020")
            //        {
            //            HyperLink3.NavigateUrl = sen;
            //            HyperLink3.Text = dr["FileNm"].ToString();
            //            Label14.Text = dr["FileNm"].ToString();
            //        }
            //    }
            //}
            #endregion
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FilldataIIDFund(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtUnitLocatedinIndustArea.Text = ds.Tables[0].Rows[0]["UnitLocatedinIndustArea"].ToString();
                txtJustLocation.Text = ds.Tables[0].Rows[0]["JustLocation"].ToString();
                txtFinanceSource.Text = ds.Tables[0].Rows[0]["FinanceSource"].ToString();
                txtReqdInfraFacilities.Text = ds.Tables[0].Rows[0]["ReqdInfraFacilities"].ToString();
                txtProposedInfraCritical.Text = ds.Tables[0].Rows[0]["ProposedInfraCritical"].ToString();

                txtEstimatesInfra.Text = ds.Tables[0].Rows[0]["EstimatesInfra"].ToString();
                txtCAName.Text = ds.Tables[0].Rows[0]["CAName"].ToString();
                txtProjDuration.Text = ds.Tables[0].Rows[0]["ProjDuration"].ToString();
                txtMaintanCostAnnum.Text = ds.Tables[0].Rows[0]["MaintanCostAnnum"].ToString();
                txtAmtClaimed.Text = ds.Tables[0].Rows[0]["AmtClaimed"].ToString();

                #region File Uploading IIDF
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("66"))
                //        {
                //            lblUpload1.NavigateUrl = sen;
                //            lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }

    private void FilldataSCSCT(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtTotalEquity.Text = ds.Tables[0].Rows[0]["TotalEquity"].ToString();
                txtOwnCapital.Text = ds.Tables[0].Rows[0]["OwnCapital"].ToString();
                txtBorrowed.Text = ds.Tables[0].Rows[0]["Borrowed"].ToString();
                txtAdvSubClaimed.Text = ds.Tables[0].Rows[0]["AdvSubClaimed"].ToString();

                #region File Uploading Advanced Subsidy for SC/ST
                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2;
                //    int i = 0;

                //    while (i < c)
                //    {
                //        sen2 = ds.Tables[1].Rows[i][0].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                //        if (sen.Contains("80"))
                //        {
                //            lblupload1.NavigateUrl = sen;
                //            lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("81"))
                //        {
                //            lblupload2.NavigateUrl = sen;
                //            lblupload2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("82"))
                //        {
                //            lblupload3.NavigateUrl = sen;
                //            lblupload3.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName3.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        if (sen.Contains("83"))
                //        {
                //            lblupload4.NavigateUrl = sen;
                //            lblupload4.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblAttachedFileName4.Text = ds.Tables[1].Rows[i][1].ToString();
                //            //HyperLink1.NavigateUrl = sen;
                //            //HyperLink1.Text = 
                //        }
                //        i++;
                //    }
                //}
                #endregion

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    protected void BtnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveCAFDetails.aspx");
    }
    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

    }
    protected void gvCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    // grdExport.Columns[1].Visible = false;
                    recipet.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= SLCAgenda.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }


    #region Investsubsidy
    void FilldataISnew(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                lblLandCost.Text = ds.Tables[2].Rows[0]["totCstCmptdLand"].ToString();
                lblBuildingCost.Text = ds.Tables[2].Rows[0]["TotCstCmptdBldg"].ToString();
                lblPlantMachCost.Text = ds.Tables[2].Rows[0]["TotCstCmptdPlntMach"].ToString();
                // lblTotal.Text = ds.Tables[2].Rows[0]["TotCstCmptdTotal"].ToString();    

            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                lblAMount.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                string[] no;
                int Number;
                if (lblAMount.Text.Contains("."))
                {
                    no = lblAMount.Text.Split('.');
                    Number = Convert.ToInt32(no[0]);
                }
                else
                {
                    Number = Convert.ToInt32(lblAMount.Text);
                }
                lblApplcationDate.Text = NumberToText(Number) + " Rupees Only.";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public string FillDetailsNewis(DataSet ds)
    {
        string IncentID = "";
        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {


                    lblLetterNo.Text = "DIC/" + txtudyogAadharNo.Text;


                    lblLetterDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");


                    if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                    {
                        lblRefApplicationNo.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["CREATED_DT"].ToString() != null && ds.Tables[0].Rows[0]["CREATED_DT"].ToString() != "")
                    {
                        lblRefApplnDate.Text = ds.Tables[0].Rows[0]["CREATED_DT"].ToString();
                        lblClaimApplicationDate.Text = ds.Tables[0].Rows[0]["CREATED_DT"].ToString();
                    }



                    if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                    {
                        lblEnterpreneurDetails.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                        lblEnterpreneurDetails2.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    }

                    return IncentID;
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }

        return IncentID;
    }
    public string NumberToText(int number)
    {
        if (number == 0) return "Zero";
        int[] num = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "Twenty ", "Thirty ", "Fourty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };
        num[0] = number % 1000; // units
        num[1] = number / 1000;
        num[2] = number / 100000;
        num[1] = num[1] - 100 * num[2]; // thousands
        num[3] = number / 10000000; // crores
        num[2] = num[2] - 100 * num[3]; // lakhs
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }
        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;
            u = num[i] % 10; // ones
            t = num[i] / 10;
            h = num[i] / 100; // hundreds
            t = t - 10 * h; // tens
            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                //if (h > 0 || i == 0) sb.Append("and ");
                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }


        // TextBox2.Text = "Rupees " + sb.ToString().TrimEnd() + " Only";
        return sb.ToString().TrimEnd();
    }
    #endregion

    #region pv
    public void binddatanew(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lbldist1.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNo1.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDate1.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblIIPPScheme.Text = "T-IDEA";
                        lblIIPPScheme2.Text = "T-IDEA";
                        lblIIPPScheme3.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblIIPPScheme.Text = "T-PRIDE(TSCP)";
                        lblIIPPScheme2.Text = "T-PRIDE(TSCP)";
                        lblIIPPScheme3.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblIIPPScheme.Text = "T-PRIDE(TSP)";
                        lblIIPPScheme2.Text = "T-PRIDE(TSP)";
                        lblIIPPScheme3.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2pv.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNo1.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDate1.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDateofCommencement.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMPartNo"].ToString() != null && ds.Tables[0].Rows[0]["EMPartNo"].ToString() != "") // need to Clarify
                {
                    lblEMPartNOpv.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();
                    lblEMPPartDate.Text = "";
                }


            }
            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }
            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                {
                    lblFinancialYear1.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear5.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                }

                if (ds.Tables[2].Rows[0]["RateofIntrest"].ToString() != null && ds.Tables[2].Rows[0]["RateofIntrest"].ToString() != "")
                {
                    lblBankInterestPercent.Text = ds.Tables[2].Rows[0]["RateofIntrest"].ToString();
                }
                if (ds.Tables[2].Rows[0]["IntrestPaid"].ToString() != null && ds.Tables[2].Rows[0]["IntrestPaid"].ToString() != "")
                {
                    lblamountpaid1.Text = ds.Tables[2].Rows[0]["IntrestPaid"].ToString();
                    lblamountpaid2.Text = ds.Tables[2].Rows[0]["IntrestPaid"].ToString();

                    double paidamt = Convert.ToDouble(lblamountpaid2.Text.ToString());
                    double rateofinterest = Convert.ToDouble(lblBankInterestPercent.Text.ToString());

                }



                // need to clarify
                lbl1stOR2nd.Text = "2nd";
                lbl1stOR2nd2.Text = "2nd";
                lbl1stOR2nd3.Text = "2nd";
                lbl1stOR2nd4.Text = "2nd";
                lbl1stOR2nd5.Text = "2nd";

            }
            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {

                if (ds.Tables[4].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[4].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid3.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblSTAmountPaid3.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region Pt
    public void binddatanewpt(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lbldist1pt.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNopt.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDatept.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblIIPPYearScheme1.Text = "T-IDEA";
                        lblIIPPYearScheme2.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblIIPPYearScheme1.Text = "T-PRIDE(TSCP)";
                        lblIIPPYearScheme2.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblIIPPYearScheme1.Text = "T-PRIDE(TSP)";
                        lblIIPPYearScheme2.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1pt.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails1pt.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null || ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNopt.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDatept.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null || ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDateofCommencementpt.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();

                    //DateTime PWBaseDate = DateTime.Parse("10/10/2017");      // need to Clarify
                    //if (DateTime.Parse(lblDateofCommencement.Text) > PWBaseDate)
                    //{
                    //    lblRateEligiblePerUnit.Text = "1.00";
                    //}
                    //else
                    //{
                    //    lblRateEligiblePerUnit.Text = "0.75";
                    //}

                }
                if (ds.Tables[0].Rows[0]["EMPartNo"].ToString() != null || ds.Tables[0].Rows[0]["EMPartNo"].ToString() != "") // need to Clarify
                {
                    lblEMPartNOpt.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();
                    lblEMPPartDatept.Text = "";
                }


            }
            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null || ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtpt.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null || ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                {
                    lblFinancialYear1pt.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear2pt.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear3pt.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                }

                gvpwtariff.DataSource = null;
                gvpwtariff.DataBind();

                gvpwtariff.DataSource = ds.Tables[2];
                gvpwtariff.DataBind();

                //double totalunitsconsumed = Convert.ToDouble(ds.Tables[2].Rows[0]["FinalTotal"].ToString());
                //double PerUnitRate = Convert.ToDouble(lblRateEligiblePerUnit.Text);

                //lblEligibleAmount.Text = Convert.ToString(totalunitsconsumed * PerUnitRate);

                //lblPWAmount2.Text = lblEligibleAmount.Text;
                //int AmountPaid = Convert.ToInt32(lblPWAmount2.Text.ToString());
                //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);

                // need to clarify
                lbl1stOR2nd2pt.Text = "2nd";
                lbl1stOR2nd2pt.Text = "2nd";
                lbl1stOR2nd3pt.Text = "2nd";
                // select * from  tbl_FormIII_Power_Incentives order by incentiveid desc   -- -- for previous 3 financial year dtls ( for expansion/diversification)
                // select * from tbl_FormIII_Energy_Incentives order by incentiveid desc   -- for applying financial year dtls
            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblPWAmount2.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString(); ;

                    int AmountPaid = Convert.ToInt32(lblPWAmount2.Text.ToString());
                    lblSanctionedAmtDescpt.Text = Gen.NumberToWord(AmountPaid);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region ST
    public void binddatanewst(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdist"].ToString() != null && ds.Tables[0].Rows[0]["unitdist"].ToString() != string.Empty)
                {
                    lblDistrict.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNost.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDatest.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1st.Text = "T-IDEA";
                        lblTIdeaTPride2.Text = "T-IDEA";
                        lblTIdeaTPride3.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1st.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1st.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1st.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2st.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNost.Text = "DIC/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDatest.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPst.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharno.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardate.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    lblTinnost.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtst.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                {
                    lblFinancialYear2st.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear3st.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                    lblFinancialYear4st.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                }

                if (ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != null && ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != "")
                {
                    lblSTAmountPaid3st.Text = ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString();
                    lblSTAmountPaid1.Text = ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString();
                    //lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString();

                    //int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
                }


                // need to clarify
                lbl1st2nd1.Text = "2nd";
                lbl1st2nd2.Text = "2nd";
                lbl1st2nd3.Text = "2nd";

            }
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblGMRecommendedAmount.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblSTAmountPaid3st.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                    int AmountPaid = Convert.ToInt32(lblGMRecommendedAmount.Text.ToString());
                    lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region SD
    public void binddatanewsd(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictsd.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNosd.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDatesd.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride2sd.Text = "T-IDEA";
                        lblTIdeaTPride3sd.Text = "T-IDEA";
                        lblTIdeaTPride3sd.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride2sd.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2sd.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3sd.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride2sd.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2sd.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3sd.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1sd.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2sd.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null || ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNosd.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDatesd.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null || ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPsd.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnosd.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardatesd.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null || ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null || ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtsd.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                //{
                //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                //}
                lblFinancialYear2sd.Text = "2016-17";
                lblFinancialYear3sd.Text = "2016-17";
                lblFinancialYear4sd.Text = "2016-17";
                if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null || ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
                {
                    //if (ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != null && ds.Tables[2].Rows[0]["FinalTotalAmountPaid"].ToString() != "")
                    //{
                    //    lblSTAmountPaid.Text = ds.Tables[0].Rows[0]["FinalTotalAmountPaid"].ToString();
                    //    lblSTAmountPaid3.Text = ds.Tables[0].Rows[0]["FinalTotalAmountPaid"].ToString();

                    //    int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid.Text.ToString()));
                    //    lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
                    //}
                    if (ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString() != "")
                    {
                        lblStampTransferDutyPaid.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();
                        trStamptransferDuty.Visible = true;

                        lblSTAmountPaid3sd.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();

                        lblSTAmountPaid3sd.Text = ds.Tables[2].Rows[0]["StampTranfrDutyAP"].ToString();               // for testing only
                        //int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid.Text.ToString()));
                        //lblSanctionedAmtDescsd.Text = Gen.NumberToWord(AmountPaid);
                    }
                    if (ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != null && ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString() != "")
                    {
                        lblMortgageDutyPaid.Text = ds.Tables[2].Rows[0]["MortgageHypothDutyAP"].ToString();
                        trMortgageDutyPaid.Visible = true;
                    }
                    if (ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString() != null && ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString() != "")
                    {
                        lblLandConversionCharges.Text = ds.Tables[2].Rows[0]["LandConvrChrgAP"].ToString();
                        trLandConversionCharges.Visible = true;
                    }
                    if (ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString() != null && ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString() != "")
                    {
                        lblLandConversionCharges.Text = ds.Tables[2].Rows[0]["LandCostIeIdaIpAP"].ToString();
                        trLandConversionCharges.Visible = false;
                    }
                }
                // need to clarify
                lbl1st2nd1.Text = "2nd";
                lbl1st2nd2.Text = "2nd";
                lbl1st2nd3.Text = "2nd";

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region Seed Cap
    public void binddatanewsc(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictSC.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoSC.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDateSC.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SC.Text = "T-IDEA";
                        lblTIdeaTPride2SC.Text = "T-IDEA";
                        lblTIdeaTPride3SC.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SC.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2SC.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3SC.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SC.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2SC.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3SC.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1SC.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2SC.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoSC.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDateSC.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPSC.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnoSC.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardateSC.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtSC.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null && ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                //{
                //lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //}
                lblFinancialYear2SC.Text = "2016-17";
                lblFinancialYear3SC.Text = "2016-17";
                lblFinancialYear4SC.Text = "2016-17";

                if (ds.Tables[2].Rows[0]["Amountclaimed"].ToString() != null && ds.Tables[2].Rows[0]["Amountclaimed"].ToString() != "")
                {
                    lblSTAmountPaid1SC.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();
                    lblSTAmountPaid1SC.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();
                    //lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();

                    //int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                    //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
                }


                // need to clarify
                lbl1st2nd1SC.Text = "2nd";
                lbl1st2nd2SC.Text = "2nd";
                lbl1st2nd3SC.Text = "2nd";

            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid3SC.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString(); ;

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDescSC.Text = Gen.NumberToWord(AmountPaid);

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region QC
    public void binddatanewQC(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictqc.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoQC.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDateQC.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1QC.Text = "T-IDEA";
                        lblTIdeaTPride2QC.Text = "T-IDEA";
                        lblTIdeaTPride3QC.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1QC.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2QC.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3QC.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1QC.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2QC.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3QC.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1QC.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2QC.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoQC.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDateQC.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPQC.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnoQC.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardateQC.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtQC.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null || ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                //{
                //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                //}
                lblFinancialYear2QC.Text = "2016-17";
                lblFinancialYear3QC.Text = "2016-17";
                lblFinancialYear4QC.Text = "2016-17";


                if (ds.Tables[2].Rows[0]["Amountspentinacquiringthecertification"].ToString() != null && ds.Tables[2].Rows[0]["Amountspentinacquiringthecertification"].ToString() != "")
                {
                    lblSTAmountPaid1QC.Text = ds.Tables[2].Rows[0]["Amountspentinacquiringthecertification"].ToString();
                    lblSTAmountPaid1QC.Text = ds.Tables[2].Rows[0]["Amountspentinacquiringthecertification"].ToString();

                }


                // need to clarify
                lbl1st2nd1QC.Text = "2nd";
                lbl1st2nd2QC.Text = "2nd";
                lbl1st2nd3QC.Text = "2nd";

            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid3QC.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblSTAmountPaid3QC.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDescQC.Text = Gen.NumberToWord(AmountPaid);

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region CP
    public void binddatanewCP(DataSet ds)
    {
        try
        {

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictPCP.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoPCP.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDatePCP.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" && ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1CP.Text = "T-IDEA";
                        lblTIdeaTPride2PCP.Text = "T-IDEA";
                        lblTIdeaTPride3PCP.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1CP.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2PCP.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3PCP.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" && ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1CP.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2PCP.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3PCP.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1PCP.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2PCP.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoPCP.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDatePCP.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPPCP.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                //if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                //{
                //    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                //if (udyognotype == "1")
                //{
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                {
                    lbludyogaadharnoPCP.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                {
                    lblUdyogAadhaardatePCP.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                }
                // }
                // }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtPCP.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null || ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")  // need to Check
                //{ 
                //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                //}
                lblFinancialYear2PCP.Text = "2016-17";
                lblFinancialYear3PCP.Text = "2016-17";
                lblFinancialYear4PCP.Text = "2016-17";
                if (ds.Tables[2].Rows[0]["subsidyclaimed"].ToString() != null || ds.Tables[2].Rows[0]["subsidyclaimed"].ToString() != "")
                {
                    lblSTAmountPaid1PCP.Text = ds.Tables[2].Rows[0]["subsidyclaimed"].ToString();
                    lblSTAmountPaid1PCP.Text = ds.Tables[2].Rows[0]["subsidyclaimed"].ToString();
                    //lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["subsidyclaimed"].ToString();
                    //int AmountPaid = Convert.ToInt32(lblSTAmountPaid.Text.ToString());
                    //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);

                }


                // need to clarify
                lbl1st2nd1PCP.Text = "2nd";
                lbl1st2nd2PCP.Text = "2nd";
                lbl1st2nd2PCP.Text = "2nd";

            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid3PCP.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblSTAmountPaid3PCP.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDescPCP.Text = Gen.NumberToWord(AmountPaid);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region SU
    public void binddatanewSU(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictSU.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoSU.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDateSU.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SU.Text = "T-IDEA";
                        lblTIdeaTPride2SU.Text = "T-IDEA";
                        lblTIdeaTPride3SU.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SU.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2SU.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3SU.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1SU.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2SU.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3SU.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1SU.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2SU.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null || ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoSU.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDateSU.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null || ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPSU.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnoSU.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardateSU.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null || ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null || ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtSU.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null || ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                //{
                //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                //}
                lblFinancialYear2SU.Text = "2016-17";
                lblFinancialYear3SU.Text = "2016-17";
                lblFinancialYear4SU.Text = "2016-17";
                if (ds.Tables[2].Rows[0]["AmountClaimed"].ToString() != null || ds.Tables[2].Rows[0]["AmountClaimed"].ToString() != "")
                {
                    lblSTAmountPaidSU.Text = ds.Tables[2].Rows[0]["AmountClaimed"].ToString();
                    lblSTAmountPaid1SU.Text = ds.Tables[2].Rows[0]["AmountClaimed"].ToString();
                    //lblSTAmountPaid3.Text = ds.Tables[2].Rows[0]["AmountClaimed"].ToString();

                    //int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                    //lblSanctionedAmtDesc.Text = Gen.NumberToWord(AmountPaid);
                }


                // need to clarify
                lbl1st2nd1SU.Text = "2nd";
                lbl1st2nd2SU.Text = "2nd";
                lbl1st2nd3su.Text = "2nd";

            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {

                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid3SU.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString(); ;

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDescSU.Text = Gen.NumberToWord(AmountPaid);

                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region IIDF
    public void binddatanewIIDF(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null && ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lbldist1iidf.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                    lbldist2.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                    lbldist3.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoiidf.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null && ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDateiidf.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Scheme"].ToString() != null && ds.Tables[0].Rows[0]["Scheme"].ToString() != "") // 
                {
                    lblTIdeaTPride1.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                    lblTIdeaTPride2.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                    //lblTIdeaTPride3.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null && ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1iidf.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2iidf.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null && ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoiidf.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null && ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDate.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null && ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPiidf.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null && ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnoiidf.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null && ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardateiidf.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null && ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }
            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null && ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtiidf.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }
            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                if (ds.Tables[2].Rows[0]["AmtClaimed"].ToString() != null || ds.Tables[2].Rows[0]["AmtClaimed"].ToString() != "")
                {
                    //lblSTAmountPaid.Text = ds.Tables[2].Rows[0]["AmtClaimed"].ToString();
                    lblSTAmountPaid1iidf.Text = ds.Tables[2].Rows[0]["AmtClaimed"].ToString();
                    lblSTAmountPaid3iidf.Text = ds.Tables[2].Rows[0]["AmtClaimed"].ToString();
                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid1.Text.ToString());
                    lblSanctionedAmtDesciidf.Text = Gen.NumberToWord(AmountPaid);
                }
            }

            //  Tables[3] 
            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                if (ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != null && ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString() != "")
                {
                    lblSTAmountPaid1iidf.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblSTAmountPaid3iidf.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();
                    //lblSTAmountPaid.Text = ds.Tables[3].Rows[0]["GM_Rcon_Amount"].ToString();

                    int AmountPaid = Convert.ToInt32(lblSTAmountPaid3.Text.ToString());
                    lblSanctionedAmtDesciidf.Text = Gen.NumberToWord(AmountPaid);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void FillDetailsIIDF(DataSet ds)
    {
        try
        {
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    if (ds.Tables[1].Rows[0]["LineofActivity"].ToString() != "" && ds.Tables[1].Rows[0]["LineofActivity"].ToString() != null)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            lblloa.Text = ds.Tables[1].Rows[i]["LineofActivity"].ToString() + ", ";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion

    #region Advanced SS
    public void binddatanewASS(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["unitdistrict"].ToString() != null || ds.Tables[0].Rows[0]["unitdistrict"].ToString() != string.Empty)
                {
                    lblDistrictASS.Text = ds.Tables[0].Rows[0]["unitdistrict"].ToString();
                }
                if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != string.Empty)
                {
                    lblLetterNoASS.Text = "COI/" + ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                }
                if (ds.Tables[0].Rows[0]["todaydate"].ToString() != null || ds.Tables[0].Rows[0]["todaydate"].ToString() != "") // need to Clarify
                {
                    lblLetterDateASS.Text = ds.Tables[0].Rows[0]["todaydate"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != "" || ds.Tables[0].Rows[0]["TIDEAflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1ASS.Text = "T-IDEA";
                        lblTIdeaTPride2ass.Text = "T-IDEA";
                        lblTIdeaTPride3ASS.Text = "T-IDEA";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSCPflag"].ToString() != null)
                {

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1ASS.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride2ass.Text = "T-PRIDE(TSCP)";
                        lblTIdeaTPride3ASS.Text = "T-PRIDE(TSCP)";
                    }
                }
                if (ds.Tables[0].Rows[0]["TSPflag"].ToString() != "" || ds.Tables[0].Rows[0]["TSPflag"].ToString() != null)
                {
                    if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {
                        lblTIdeaTPride1ASS.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride2ass.Text = "T-PRIDE(TSP)";
                        lblTIdeaTPride3ASS.Text = "T-PRIDE(TSP)";
                    }
                }

                if (ds.Tables[0].Rows[0]["UnitDtls"].ToString() != null || ds.Tables[0].Rows[0]["UnitDtls"].ToString() != "")
                {
                    lblEnterpreneurDetails1ASS.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    lblEnterpreneurDetails2ass.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != null || ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                {
                    lblRefApplicationNoASS.Text = "COI/" + ds.Tables[0].Rows[0]["IncentveID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != null || ds.Tables[0].Rows[0]["ApplicationDate"].ToString() != "")
                {
                    lblRefApplnDateASS.Text = ds.Tables[0].Rows[0]["ApplicationDate"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DCPNew"].ToString() != null || ds.Tables[0].Rows[0]["DCPNew"].ToString() != "")
                {
                    lblDCPASS.Text = ds.Tables[0].Rows[0]["DCPNew"].ToString();
                }


                if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "") // need to Clarify
                {
                    string udyognotype = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    //if (udyognotype == "1")
                    //{
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != null || ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "") // need to Clarify
                    {
                        lbludyogaadharnoASS.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "") // need to Clarify
                    {
                        lblUdyogAadhaardateASS.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    // }
                }
                if (ds.Tables[0].Rows[0]["TinNO"].ToString() != null || ds.Tables[0].Rows[0]["TinNO"].ToString() != "") // need to Clarify
                {
                    //  lblTinno.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                }

            }

            //  Tables[1] 
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["InpectedDate"].ToString() != null || ds.Tables[1].Rows[0]["InpectedDate"].ToString() != "")
                {
                    lblinspecteddtASS.Text = ds.Tables[1].Rows[0]["InpectedDate"].ToString();
                }

            }

            //  Tables[2] 
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                //if (ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != null || ds.Tables[2].Rows[0]["FinancialYearNew"].ToString() != "")
                //{
                //    lblFinancialYear2.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear3.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();
                //    lblFinancialYear4.Text = ds.Tables[2].Rows[0]["FinancialYearNew"].ToString();

                //}
                lblFinancialYear2ASS.Text = "2016-17";
                lblFinancialYear3ASS.Text = "2016-17";
                lblFinancialYear4ASS.Text = "2016-17";
                if (ds.Tables[2].Rows[0]["AdvSubClaimed"].ToString() != null || ds.Tables[2].Rows[0]["AdvSubClaimed"].ToString() != "")
                {
                    lblSTAmountPaid1ASS.Text = ds.Tables[2].Rows[0]["AdvSubClaimed"].ToString();
                    lblSTAmountPaid1ASS.Text = ds.Tables[2].Rows[0]["AdvSubClaimed"].ToString();
                    lblSTAmountPaid3ASS.Text = ds.Tables[2].Rows[0]["AdvSubClaimed"].ToString();


                    int AmountPaid = Convert.ToInt32(Convert.ToDouble(lblSTAmountPaid3.Text.ToString()));
                    lblSanctionedAmtDescASS.Text = Gen.NumberToWord(AmountPaid);
                }


                // need to clarify
                lbl1st2nd1ASS.Text = "2nd";
                lbl1st2nd2ASS.Text = "2nd";
                lbl1st2nd3.Text = "2nd";

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblms.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    #endregion
}