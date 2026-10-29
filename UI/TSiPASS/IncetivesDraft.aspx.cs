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
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;


public partial class IncetivesDraft : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DataSet dsCAF = new DataSet();
    string username;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["uid"].ToString();
            if (Session["uid"] != null)
            {
                string uname = Session["username"].ToString();
                // 
                username = Session["username"].ToString();
                string incentiveID = "";
                if (Session["EntprIncentive"] != null)
                {

                    incentiveID = Session["EntprIncentive"].ToString();
                }
                else if (Request.QueryString["EntrpId"] != null && Request.QueryString["EntrpId"].ToString() != "")
                {
                    incentiveID = Request.QueryString["EntrpId"].ToString();
                }
                else if (Request.QueryString["ENTERPERINCENTIVEID"] != null && Request.QueryString["ENTERPERINCENTIVEID"].ToString() != "")
                {
                    incentiveID = Request.QueryString["ENTERPERINCENTIVEID"].ToString();
                }
                //dsCAF = Gen.GetAllIncentives(Session["uid"].ToString().Trim());            
                dsCAF = Gen.GetAllIncentivesDeptView(incentiveID);
                if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                {
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
                                else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() != "Y")
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>T-IDEA</center>" + "</br><center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT INCENTIVE SCHEME 2014) </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";
                                }
                                else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() == "Y")
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>TFAP</center>" + "</br><center>(TELANGANA STATE FOOD PROCESSING) </center>" + "<center>(G.O.Ms.No.18 Industries & Commerce (FP&MSME) Department, Dated: 07/08/2021)</center>";
                                }
                                 if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP" && dscaste.Tables[0].Rows[0]["IDFOODPROCESSING"].ToString() == "Y")
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>TFAP</center>" + "</br><center>(TELANGANA STATE FOOD PROCESSING) </center>" + "<center>(G.O.Ms.No.18 Industries & Commerce (FP&MSME) Department, Dated: 07/08/2021)</center>";
                                }
                                if (dscaste.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y" )
                                {
                                    lblheadTPRIDE.Visible = true;

                                    lblheadTPRIDE.Text = "<center>MSME-2024</center>" + "</br><center>(TELANGANA STATE MICRO, SMALL & MEDIUM ENTERPRISES POLICY,2024) </center>" + "<center>(G.O.Ms.No. 16, Industries & Commerce (FP&MSME) Department, Dated: 18/09/2024)</center>";
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


                            ds = Gen.GetIncentiveDeptDetails(IncentiveId);
                            FillDetails(ds);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                            ds = Gen.GetIncentiveDeptDetailsCreatedBy(userid);
                            string IncentID = FillDetails(ds);

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (dsCAF != null && dsCAF.Tables.Count > 0 && dsCAF.Tables[0].Rows.Count > 0)
                                {
                                    BindForms(dsCAF, IncentID);
                                }
                            }
                        }
                    }
                }
                else
                {
                    BtnNext.Visible = false;
                    BtnPrevious.Visible = false;
                    Button1.Visible = false;
                    Button2.Visible = false;
                }

            }
        }
        catch(Exception ex) { LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString()); }

    }

    public string FillDetails(DataSet ds)
    {
        string IncentID = "";
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
                if (ddlindustryStatus.Text == "Expansion")
                {
                    TRINDUSEXPANTYPE.Visible = true;
                    lblindusexpantype.Text = ds.Tables[0].Rows[0]["IndustryExpanType"].ToString();
                }
                txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();

                rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
                rblCaste.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();

                lblcfeno.Text = ds.Tables[0].Rows[0]["CFEUidno"].ToString();
                lblcfo.Text = ds.Tables[0].Rows[0]["CFOUidno"].ToString();
                if (ds.Tables[0].Rows[0]["Nameofloa"].ToString() != "" || ds.Tables[0].Rows[0]["Nameofloa"].ToString() != null)
                {
                    serloa.Visible = true;
                    ddlserviceloa.Text = ds.Tables[0].Rows[0]["Nameofloa"].ToString();

                }
                else
                {
                    serloa.Visible = false;
                }

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


                //Local if ticked//
                
                txttotalmaleskled.Text = ds.Tables[0].Rows[0]["skilledemploymaletotal"].ToString();
                txttotalfemaleskled.Text = ds.Tables[0].Rows[0]["skilledemployfemaletotal"].ToString();
                txtlocalmaleskled.Text = ds.Tables[0].Rows[0]["skilledemploymaletotal_local"].ToString();
                txtlocalfemaleskled.Text = ds.Tables[0].Rows[0]["skilledemployfemaletotal_local"].ToString();
                txttotalmalesmskld.Text = ds.Tables[0].Rows[0]["semiskilledemploymaletotal"].ToString();
                txttotalfemalesmskld.Text = ds.Tables[0].Rows[0]["semiskilledemployfemaletotal"].ToString();
                txtlocalmalesmskld.Text = ds.Tables[0].Rows[0]["semiskilledemploymaletotal_local"].ToString();
                txtlocalfemalesmskld.Text = ds.Tables[0].Rows[0]["semiskilledemployfemaletotal_local"].ToString();

                txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                txtStaffFemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                txtSuprMale.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                txtSuperFemale.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString();
                txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString();
                txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString();

                //txtprjfinance.Text = ds.Tables[0].Rows[0]["ProjectFinance"].ToString();
                txtTermloan.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString();
                txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString();
                txtdatesanctioned.Text = ds.Tables[0].Rows[0]["TermloanSandate"].ToString();

                // Name of Assets binding
                if (ds.Tables.Count > 0 && ds.Tables[3].Rows.Count > 0)
                {
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
                }
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

        return IncentID;
    }

    public void BindForms(DataSet ds, string incentiveID)
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
                        divSCAndST.Visible = true;
                    }
                    else if (MasterIncentiveId == "14") // Newly Added By shankar
                    {
                        DataSet ds9 = new DataSet();
                        ds9 = Gen.GetIncentivesStampDutydata1(incentiveID);
                        FilldataStampDuty1(ds9);
                        divStampDuty1.Visible = true;
                    }
                    else if (MasterIncentiveId == "15") // Newly Added By shankar
                    {
                        DataSet ds9 = new DataSet();
                        ds9 = Gen.GetIncentivesStampDutydata2(incentiveID);
                        FilldataStampDuty2(ds9);
                        divStampDuty2.Visible = true;
                    }
                    else if (MasterIncentiveId == "16") // Newly Added By shankar
                    {
                        DataSet ds9 = new DataSet();
                        ds9 = Gen.GetIncentivesStampDutydata3(incentiveID);
                        FilldataStampDuty3(ds9);
                        divStampDuty3.Visible = true;
                    }
                    else if (MasterIncentiveId == "17") // Newly Added By shankar
                    {
                        DataSet ds9 = new DataSet();
                        ds9 = Gen.GetIncentivesStampDutydata4(incentiveID);
                        FilldataStampDuty4(ds9);
                        divStampDuty4.Visible = true;
                    }
                    else if (MasterIncentiveId == "18")  // COAL
                    {
                        DataSet ds1 = new DataSet();
                        ds1 = GetCOALWOODIncentives(Convert.ToInt32(incentiveID), "18");
                        FillDataCoal(ds1);
                        DIVCOAL.Visible = true;
                    }
                    else if (MasterIncentiveId == "19")  // WOOD
                    {
                        DataSet ds1 = new DataSet();
                        ds1 = GetCOALWOODIncentives(Convert.ToInt32(incentiveID), "19");
                        FillDataWood(ds1);
                        DIVWOOD.Visible = true;
                    }
                    else if (MasterIncentiveId == "20")  // Transport Subsidy
                    {
                        DataSet ds1 = new DataSet();
                        ds1 = GetTransportSubsidy(Convert.ToInt32(incentiveID), "20");
                        FillDataTransportSubsidy(ds1);
                        DIVTRANSPORTDUTY.Visible = true;
                    }
                    else if (MasterIncentiveId == "21")//APMC
                    {
                        DataSet DS21 = new DataSet();
                        DS21 = GetIncentivesAPMC(incentiveID);
                        FilldataAPMC(DS21);
                        divapmc.Visible = true;
                    }
                    else if (MasterIncentiveId == "22")//CAPITAL SUBSIDY
                    {
                        DataSet DS21 = new DataSet();
                        DS21 = GetIncentivesCAPITALSUBSIDY(incentiveID);
                        FilldataCAPITALSUBSIDY(DS21);
                        DIVCAPITALSUBSIDY.Visible = true;
                    }
                }
            }

        }
    }
    public DataSet GetIncentivesAPMC(string IncentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INCENTIVES_APMC]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    private void FilldataAPMC(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblfeepaidyear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            lblamountpaid.Text = ds.Tables[0].Rows[0]["APMCFEEPAID"].ToString();



        }
        else
        {

        }
    }
    public DataSet GetIncentivesCAPITALSUBSIDY(string IncentiveID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_INCENTIVES_CAPITALSUBSIDY]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    private void FilldataCAPITALSUBSIDY(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblfinancialyear_CS.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            lblfIirstorsecondhalfyear_CS.Text = ds.Tables[0].Rows[0]["FIRSTORSECONDHALFYEAR"].ToString();
            lblinvestment_cs.Text = ds.Tables[0].Rows[0]["INVESTMENT_FINYEAR"].ToString();



        }
        else
        {

        }
    }
    public DataSet GetCOALWOODIncentives(int incentiveid, string MASTERINCENTIVEID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_COALANDWOODINCENTIVES_PRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
            da.SelectCommand.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.Int).Value = MASTERINCENTIVEID;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public DataSet GetTransportSubsidy(int incentiveid, string MASTERINCENTIVEID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TRASNPORTSUBSIDYINCENTIVES_PRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
            da.SelectCommand.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.Int).Value = MASTERINCENTIVEID;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    private void FillDataCoal(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtFinancialYear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
            txt1st2ndHalfYear.Text = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
            txtCoalQuan.Text = ds.Tables[0].Rows[0]["Quantity_Coal"].ToString();
            txtUnitOfMeasure.Text = ds.Tables[0].Rows[0]["UnitMeasurement_coal"].ToString();
            txtamntPaid.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
            txtAmntClaimed.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
            if (txt1st2ndHalfYear.Text == "(First Half Year)")
            {
                TRFIRSTHALFYEAR_COAL.Visible = true;
                txt1stHlfyramntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountPaid"].ToString();
                txt1stHlfyramntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountclaimed"].ToString();
                TRSECONDHALFYEAR_COAL.Visible = false;
            }
            if (txt1st2ndHalfYear.Text == "(Second Half Year)")
            {
                TRFIRSTHALFYEAR_COAL.Visible = false;
                TRSECONDHALFYEAR_COAL.Visible = true;
                txt2ndHlfyramntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountPaid"].ToString();
                txt2ndHlfyramntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountclaimed"].ToString();

            }
            txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity_IPG"].ToString();
            txtUnitOfMeasurem.Text = ds.Tables[0].Rows[0]["Unitmeasurement_IPG"].ToString();
            txtPaperQuan.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
            txtPaperUnitOfMeasurem.Text = ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();
        }
    }

    private void FillDataWood(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtFinancialYearWood.Text = ds.Tables[0].Rows[0]["Financialyear"].ToString();
            txt1st2ndHlfYearWood.Text = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
            txt1st2ndQuarter.Text = ds.Tables[0].Rows[0]["FirstorsecondQuarter"].ToString();
            if (txt1st2ndHlfYearWood.Text == "(First Half Year)" && txt1st2ndQuarter.Text == "(First Quarter)")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = true;
                txt1sthlfyr1stquaamntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountPaid"].ToString();
                txt1sthlfyr1stquaamntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountclaimed"].ToString();
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "(First Half Year)" && txt1st2ndQuarter.Text == "(Second quarter)")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = true;
                txt1sthlfyr2ndquaamntpaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountPaid"].ToString();
                txt1sthlfyr2ndquaamntclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountclaimed"].ToString();
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "(Second Half Year)" && txt1st2ndQuarter.Text == "(First Quarter))")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = true;
                txt2ndhlfyr1stquaamntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountPaid"].ToString();
                txt2ndhlfyr1stquaamntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountclaimed"].ToString();
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = false;
            }
            if (txt1st2ndHlfYearWood.Text == "(Second Half Year)" && txt1st2ndQuarter.Text == "(Second quarter)")
            {
                TRFIRSTHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRFIRSTHALFYEARSECONDQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARFIRSTQUARTER_WOOD.Visible = false;
                TRSECONDHALFYEARSECONDQUARTER_WOOD.Visible = true;
                txt2ndhlfyr2ndquaamntpaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountPaid"].ToString();
                txt2ndhlfyr2ndquaamntclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountclaimed"].ToString();
            }
            txtYesNo.Text = ds.Tables[0].Rows[0]["ISPREVIOUSLYWOODSANCTIONED"].ToString();
            if (txtYesNo.Text == "Y")
            {
                TDSANCTIONEDCLAIMSA.Visible = true;
                TDSANCTIONEDCLAIMSB.Visible = true;
                txtSanctionedYear.Text = ds.Tables[0].Rows[0]["NOOFQUARTERSPREVIOUSLYSANCTIONED"].ToString();
                if (txtSanctionedYear.Text == "1")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = false;
                    TRTHIRDQUARTER.Visible = false;
                }
                if (txtSanctionedYear.Text == "2")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = true;
                    txt2ndQuaQuan.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                    TRTHIRDQUARTER.Visible = false;
                }
                if (txtSanctionedYear.Text == "3")
                {
                    TRFIRSTQUARTER.Visible = true;
                    txt1stQuaQuan.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                    TRSECONDQUARTER.Visible = true;
                    txt2ndQuaQuan.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                    TRTHIRDQUARTER.Visible = true;
                    txt3rdQuaQuan.Text = ds.Tables[0].Rows[0]["THIRDQUARTERQTY"].ToString();
                }
            }

            else
            {
                TDSANCTIONEDCLAIMSA.Visible = false;
                TDSANCTIONEDCLAIMSB.Visible = false;
            }

            txtAdmtQuan.Text = ds.Tables[0].Rows[0]["Quantity_WOOD"].ToString();
            txtUnitOfMeasWood.Text = ds.Tables[0].Rows[0]["UnitMeasurement_WOOD"].ToString();

            txtAmntPaidWd.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
            txtAmntClaimedWd.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
            txtQuantityP.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
            txtUnitOfMeasurement.Text = ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();

        }
    }
    private void FillDataTransportSubsidy(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["THIRDPARTYAGENCY"].ToString() == "Y")
                {
                    lblthirdparty.Text = "Third Party Agency";
                    tdnameofthirdpartyagencty.Visible = true;
                    tdnameofthirdpartyagencty1.Visible = true;
                    lblnameofthirdpartagancy.Visible = true;

                    lblnameofthirdpartagancy.Text = ds.Tables[0].Rows[0]["Nameofthirdpartagency"].ToString();

                }
                if (ds.Tables[0].Rows[0]["TRAIN"].ToString() == "Y")
                {
                    lbltrain.Text = "Train";

                }
                if (ds.Tables[0].Rows[0]["OWNTRANSPORTATION"].ToString() == "Y")
                {
                    lblowntransport.Text = "Own Transport";

                }

                if (ds.Tables[0].Rows[0]["WAYBILL"].ToString() == "Y")
                {
                    lblwaybill.Text = "Way Bill";

                }
                if (ds.Tables[0].Rows[0]["FUELBILL"].ToString() == "Y")
                {
                    lblfuelbill.Text = "Fuel Bill";

                }
                if (ds.Tables[0].Rows[0]["FREIGHTCHARGES"].ToString() == "Y")
                {
                    lblfreightcharges.Text = "Freight Charges";

                }

                lbltotalamountofexpenditure.Text = ds.Tables[0].Rows[0]["Totalamountofexpenditure"].ToString();
                lblamountofsubsidyclaimed.Text = ds.Tables[0].Rows[0]["Amountofsubsidyclaimed"].ToString();
                lbltotalamountalreadysanctioned.Text = ds.Tables[0].Rows[0]["Alreadysanctionedamount"].ToString();
                lblfinancialyear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();
                lblfirstorsecondhalf.Text = ds.Tables[0].Rows[0]["firstorsecondhalf"].ToString();


            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {

                gvcomponentdetails.DataSource = ds.Tables[1];
                gvcomponentdetails.DataBind();

            }
        }


    }

    // bind forms methods
    private void FilldataIS(DataSet ds)
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

    private void FilldataStampDuty(DataSet ds)
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

    private void FillDetailsPower(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtClaimedAmount.Text = ds.Tables[0].Rows[0]["AmountClaimed"].ToString();
            if (username == "SumitPrxair")
            {
                if (ds.Tables[0].Rows[0]["Electricitydutyunits"].ToString() != null && ds.Tables[0].Rows[0]["Electricitydutyunits"].ToString() != "")
                {
                    trelectricitydutyunits.Visible = true;
                    lblelectricitydutyunits.Text = ds.Tables[0].Rows[0]["Electricitydutyunits"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Electricitydutyamount"].ToString() != null && ds.Tables[0].Rows[0]["Electricitydutyamount"].ToString() != "")
                {
                    trelectricitydutyamount.Visible = true;
                    lblelectricitydutyamount.Text = ds.Tables[0].Rows[0]["Electricitydutyamount"].ToString();
                }
            }
            else
            {
                trelectricitydutyunits.Visible = false;
                trelectricitydutyamount.Visible = false;
            }
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

    private void FillDetailsPavalaVaddi(DataSet ds)
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

    private void FillDetailsSalesTax(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0)
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

    private void FillDetailsQualityCertification(DataSet ds)
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

    private void FillDetailsCleanerProduction(DataSet ds)
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

    private void FillDetailsSkillUpgradation(DataSet ds)
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

    private void FilldataIIDFund(DataSet ds)
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

    private void FilldataSCSCT(DataSet ds)
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
        catch (Exception e)
        {

        }
    }


    private void FilldataStampDuty1(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed1.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild1.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild1.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal1.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB1.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans1.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

            txtSubRegOffc1.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo1.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtStampTranfrDutyAP1.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAP"].ToString();

            //txtMortgageHypothDutyAP1.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            //txtLandConvrChrgAP1.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();

            // txtLandCostIeIdaIpAP1.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
            txtStampTranfrDutyAC1.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAC"].ToString();
            //txtMortgageHypothDutyAC1.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
            //txtLandConvrChrgAC1.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
            //txtLandCostIeIdaIpAC1.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();
        }
    }
    private void FilldataStampDuty2(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed2.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild2.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild2.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal2.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB2.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans2.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();
            txtSubRegOffc2.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo2.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate2.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtMortgageHypothDutyAP2.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            txtMortgageHypothDutyAC2.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
        }

    }
    private void FilldataStampDuty3(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed3.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild3.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild3.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal3.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB3.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans3.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

            txtSubRegOffc3.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo3.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate3.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtLandConvrChrgAP3.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();
            txtLandConvrChrgAC3.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
        }
    }
    private void FilldataStampDuty4(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtAreaRegdSaledeed4.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild4.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild4.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal4.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB4.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            txtNatureofTrans4.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();
            txtSubRegOffc4.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo4.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate4.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtLandCostIeIdaIpAP4.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
            txtLandCostIeIdaIpAC4.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();
        }

    }
}
