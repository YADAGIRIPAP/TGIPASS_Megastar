using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_IncetivesNewFormDeptView : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (Request.QueryString["IncentveID"] != null)
            {
                //  hdfFlagID.Value = Request.QueryString["intApplicationId"];
            }
            //string incentiveID = ""; // Request.QueryString["IncentveID"].ToString();
            string userid = Session["uid"].ToString();
            string uname = Session["username"].ToString();
            //string strincentiveid = Convert.ToString(Session["EntprIncentive"]);
            //incentiveID = strincentiveid;
            string incentiveID = "";
            DataSet ds = new DataSet();
            if (Request.QueryString.Count > 0)
            {
                incentiveID = Request.QueryString["EntrpId"].ToString();
                if (!IsPostBack)
                {
                    trNewIndustry.Visible = false;
                    trexpansion.Visible = false;


                    ds = Gen.GetIncentiveDeptDetails(incentiveID);
                    FillDetails(ds);
                }
            }
            else
            {
                ds = Gen.GetIncentiveDeptDetailsCreatedBy(userid);
                FillDetails(ds);
            }

        }
    }
    public void FillDetails(DataSet ds)
    {


        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                ddldistrictunit.Text = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                ddlUnitMandal.Text = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                ddlVillageunit.Text = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                txtunitaddhno.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                txtstreetunit.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();

                ddldistrictoffc.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                ddloffcmandal.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                ddlvilloffc.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                txtstreetoffice.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();

                txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

                ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();

                ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();       //modified on 14.06.2017
                //  ddltypeofOrg.Text = ds.Tables[0].Rows[0]["Cons_of_Unit"].ToString();

                ddlindustryStatus.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();

                if (ddlindustryStatus.Text == "New Industry")
                {
                    trNewIndustry.Visible = true;
                    //gvInstalledCap.Visible = true;
                    gvInstalledCap.DataSource = null;
                    gvInstalledCap.DataBind();
                    gvInstalledCap.DataSource = ds.Tables[1];
                    gvInstalledCap.DataBind();
                }
                else
                {
                    trNewIndustry.Visible = false;
                }
                if (ddlindustryStatus.Text == "trexpansion")
                {
                    trexpansion.Visible = true;
                    EEloa.Text = ds.Tables[0].Rows[0]["ExistingEnterpriseLOA"].ToString();
                    eeInstalledCap.Text = ds.Tables[0].Rows[0]["ExistingInstalledCapacityinEnter"].ToString();
                    eePercentage.Text = ds.Tables[0].Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();
                }
                else
                {
                    trexpansion.Visible = false;
                }


                gvDirectorDetails.DataSource = null;
                gvDirectorDetails.DataBind();
                gvDirectorDetails.DataSource = ds.Tables[2];
                gvDirectorDetails.DataBind();

                EDPloa.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLOA"].ToString();
                edpInstalledCapacity.Text = ds.Tables[0].Rows[0]["ExpanORDiversInstalledCapacityinEnter"].ToString();
                edpPercentage.Text = ds.Tables[0].Rows[0]["ExpanORDiversPercentIncreaseunderExpansionORDiversification"].ToString();

                LandEE.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                LandExpansionDiversification.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                landPercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                BuildingEE.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                BuildingLandExpansionDiversification.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                BuildigPercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                PlantMachineryEE.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                PlantMachLandExpansionDiversification.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                PlantMachpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                lblSocialStatus.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();

                // grid view code binding  // for directors/ proprietors
                gvInstalledCap.DataSource = null;
                gvInstalledCap.DataBind();
                gvInstalledCap.DataSource = ds.Tables[1];
                gvInstalledCap.DataBind();

                ddlPowerStatus.Text = ds.Tables[0].Rows[0]["PowerType"].ToString();

                if (ddlPowerStatus.Text == "New Industry")
                {
                    trpower1.Visible = true;
                    trpower2.Visible = false;
                    txtpowerReleasedate.Text = ds.Tables[0].Rows[0]["PowerReleaseDate"].ToString();
                    txtconnectedload.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                    txtcontractedload.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                    txtServiceConnectionNumber.Text = ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString();
                }
                if (ddlPowerStatus.Text == "Expansion/Diversification")
                {
                    trpower1.Visible = false;
                    trpower2.Visible = true;
                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";

                    txtExistingPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                    txtExistingContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                    txtExistingConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                    txtExistingServiceConnectionNO.Text = ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString();
                    txtExpanDiverPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                    txtExpanDiverContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                    txtExpanDiverConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                    txtExpanDiverServiceConnectionNO.Text = ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString();
                }

                txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                txtStaffFemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                txtSuprMale.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                txtSuperFemale.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();

                txtprjfinance.Text = ds.Tables[0].Rows[0]["ProjectFinance"].ToString();
                txtTermloan.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString();
                txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString();
                txtInstallDate.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "Y")
                {
                    ddlsubsidy.Text = "Yes";
                }
                else if (ds.Tables[0].Rows[0]["AvailedSubsidyEarlier"].ToString() == "N")
                {
                    ddlsubsidy.Text = "No";
                }

                ddlBank.Text = ds.Tables[4].Rows[0]["BankName"].ToString();
                txtAccNumber.Text = ds.Tables[4].Rows[0]["AccNo"].ToString();
                txtBranchName.Text = ds.Tables[4].Rows[0]["BranchName"].ToString();
                txtIfscCode.Text = ds.Tables[4].Rows[0]["IFSCCode"].ToString();
                ddlPower.Text = ds.Tables[4].Rows[0]["WhetherPower"].ToString();




                //txtSubsidyScheme.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedScheme"].ToString();
                //txtSubsidyAmount.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedAmount"].ToString();

                txt2ndMachVal.Text = ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString();
                txtNewMachVal.Text = ds.Tables[0].Rows[0]["NewMachVal"].ToString();
                txtNewand2ndlMachVal.Text = ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString();
                txt2ndMachPercValue.Text = ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString();
                txtPurchasedMachValbyBank.Text = ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString();
                txtTotalMachVal.Text = ds.Tables[0].Rows[0]["TotalMachVal"].ToString();


                // Nature of Assets binding
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
                    PM2.Text = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                else
                    PM2.Text = "0.00";
                if (ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString() != "")
                    PM3.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                else
                    PM3.Text = "0.00";
                if (ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString() != "")
                    PM4.Text = ds.Tables[3].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                else
                    PM4.Text = "0.00";
                if (ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString() != "")
                    PM5.Text = ds.Tables[3].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                else
                    PM5.Text = "0.00";
                if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString() != "")
                    PM6.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                else
                    PM6.Text = "0.00";
                if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString() != "")
                    PM7.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                else
                    PM7.Text = "0.00";

                if (ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString() != "")
                    MCont2.Text = ds.Tables[3].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                else
                    MCont2.Text = "0.00";
                if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString() != "")
                    MCont3.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                else
                    MCont3.Text = "0.00";
                if (ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString() != "")
                    MCont4.Text = ds.Tables[3].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                else
                    MCont4.Text = "0.00";
                if (ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString() != "")
                    MCont5.Text = ds.Tables[3].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                else
                    MCont5.Text = "0.00";
                if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString() != "")
                    MCont6.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                else
                    MCont6.Text = "0.00";
                if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString() != "")
                    MCont7.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                else
                    MCont7.Text = "0.00";


                Erec2.Text = ds.Tables[3].Rows[0]["ErectionApprovedProjectCost"].ToString();
                Erec3.Text = ds.Tables[3].Rows[0]["ErectionLoanSactioned"].ToString();
                Erec4.Text = ds.Tables[3].Rows[0]["ErectionPromotersEquity"].ToString();
                Erec5.Text = ds.Tables[3].Rows[0]["ErectionLoanAmountReleased"].ToString();
                Erec6.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                Erec7.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyCA"].ToString();

                TFS2.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                TFS3.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                TFS4.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                TFS5.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                TFS6.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                TFS7.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();

                WC2.Text = ds.Tables[3].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                WC3.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                WC4.Text = ds.Tables[3].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                WC5.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                WC6.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                WC7.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                //int total2 = Convert.ToInt32(txtLand2.Text) + Convert.ToInt32(txtBuilding2.Text) +
                //    Convert.ToInt32(PM2.Text) + Convert.ToInt32(MCont2.Text);// +
                //Convert.ToInt32(Erec2.Text) + Convert.ToInt32(TFS2.Text); //+
                //Convert.ToInt32(WC2.Text);
                //Tot2.Text = total2.ToString();

                //decimal total3 = Convert.ToDecimal(txtLand3.Text) + Convert.ToDecimal(txtBuilding3.Text) +
                //Convert.ToDecimal(PM3.Text) + Convert.ToDecimal(MCont3.Text) +
                //Convert.ToDecimal(Erec3.Text) + Convert.ToDecimal(TFS3.Text) +
                //Convert.ToDecimal(WC3.Text);
                //Tot3.Text = total3.ToString();

                //decimal total4 = Convert.ToDecimal(txtLand4.Text) + Convert.ToDecimal(txtBuilding4.Text) +
                //    Convert.ToDecimal(PM4.Text) + Convert.ToDecimal(MCont4.Text) +
                //    Convert.ToDecimal(Erec4.Text) + Convert.ToDecimal(TFS4.Text) +
                //    Convert.ToDecimal(WC4.Text);
                //Tot4.Text = total4.ToString();

                //decimal total5 = Convert.ToDecimal(txtLand5.Text) + Convert.ToDecimal(txtBuilding5.Text) +
                //    Convert.ToDecimal(PM5.Text) + Convert.ToDecimal(MCont5.Text) +
                //    Convert.ToDecimal(Erec5.Text) + Convert.ToDecimal(TFS5.Text) +
                //    Convert.ToDecimal(WC5.Text);
                //Tot5.Text = total5.ToString();

                //decimal total6 = Convert.ToDecimal(txtLand6.Text) + Convert.ToDecimal(txtBuilding6.Text) +
                //    Convert.ToDecimal(PM6.Text) + Convert.ToDecimal(MCont6.Text) +
                //    Convert.ToDecimal(Erec6.Text) + Convert.ToDecimal(TFS6.Text) +
                //    Convert.ToDecimal(WC6.Text);
                //Tot6.Text = total6.ToString();

                //decimal total7 = Convert.ToDecimal(txtLand7.Text) + Convert.ToDecimal(txtBuilding7.Text) +
                //    Convert.ToDecimal(PM7.Text) + Convert.ToDecimal(MCont7.Text) +
                //    Convert.ToDecimal(Erec7.Text) + Convert.ToDecimal(TFS7.Text) +
                //    Convert.ToDecimal(WC7.Text);
                //Tot7.Text = total7.ToString();

                //txtInvestSubsidy.Text = ds.Tables[0].Rows[0]["InvestimentSubsidy"].ToString();
                //txtInvestSubsidyWomen.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomen"].ToString();
                //txtInvestSubsidySCST.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForSCORST"].ToString();
                //txtInvestSubsidyScheduledAreas.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomenInScheduledAreas"].ToString();
                //txtTotalInvestApplied.Text = ds.Tables[0].Rows[0]["TotalAppliedIncetives"].ToString();


            }
        }

    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveCAFDetails.aspx");
    }
}