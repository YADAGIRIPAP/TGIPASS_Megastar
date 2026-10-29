using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_IncentivesAnnexures_AnnexAdvancedSubsidySCST : System.Web.UI.Page
{
    General Gen = new General();

    DataSet ds = new DataSet();
    DataSet dsCAF = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string userid = Session["uid"].ToString();
        if (Session["uid"] != null)
        {
            string uname = Session["username"].ToString();

            //string incentiveID = Request.QueryString["IncentveID"].ToString();
            //dsCAF = Gen.GetAllIncentives(Session["uid"].ToString().Trim());
            dsCAF = (DataSet)Session["incentivedata"];
            string IncentiveId = dsCAF.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            if (IncentiveId != null)
            {
                if (!IsPostBack)
                {
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

                // txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                //ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();

                ddlindustryStatus.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();

                // rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();
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

                //trexpansion.Visible = true;
                //txteeploa.Text = ds.Tables[0].Rows[0]["ExistingEnterpriseLOA"].ToString();
                //txteepinscap.Text = ds.Tables[0].Rows[0]["ExistingInstalledCapacityinEnter"].ToString();
                //ddleepinscap.Text = ds.Tables[0].Rows[0]["eepinscapUnit"].ToString();
                //txteeppercentage.Text = ds.Tables[0].Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();

                //txtedploa.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLOA"].ToString();
                //txtedpinscap.Text = ds.Tables[0].Rows[0]["ExpanORDiversInstalledCapacityinEnter"].ToString();
                //ddledpinscap.Text = ds.Tables[0].Rows[0]["edpinscapUnit"].ToString();
                //txtedppercentage.Text = ds.Tables[0].Rows[0]["ExpanORDiversPercentIncreaseunderExpansionORDiversification"].ToString();

                //txtlandexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                //txtlandexpandiver.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                //txtlandpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                //txtbuildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                //txtbuildingexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                //txtbuildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                //txtplantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                //txtplantexpandiver.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                //txtplantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                // grid view code binding  // for directors/ proprietors
                GridViewdirectors.DataSource = null;
                GridViewdirectors.DataBind();
                GridViewdirectors.DataSource = ds.Tables[2];
                GridViewdirectors.DataBind();

                //ddlPowerStatus.Text = ds.Tables[0].Rows[0]["PowerType"].ToString();

                //if (ddlPowerStatus.Text == "New Industry")
                //{
                //trpower1.Visible = true;
                //trpower2.Visible = false;

                txtNewPowerReleaseDate.Text = ds.Tables[0].Rows[0]["PowerReleaseDate"].ToString();
                txtNewContractedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                //  txtNewConnectedLoad.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                //txtServiceConnectionNumberNew.Text = ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString();

                // }
                //if (ddlPowerStatus.Text == "Expansion/Diversification")
                //{
                //    //trpower1.Visible = false;
                //    //trpower2.Visible = true;
                //    lblexistingpower.Text = "Existing Enterprise production details";
                //    lblexpandiverpower.Text = "Expansion / Diversification details";

                //    txtExistPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                //    txtExistContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                //    txtExistConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                //    txtServiceConnectionNumberExist.Text = ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString();
                //    txtExpanPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                //    txtExpanContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                //    txtExpanConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                //    txtServiceConnectionNumberExpan.Text = ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString();
                //}

                //txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                //txtStaffFemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                //txtSuprMale.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                //txtSuperFemale.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                //txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                //txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                //txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                //txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();

                //txtprjfinance.Text = ds.Tables[0].Rows[0]["ProjectFinance"].ToString();
                txtTermloan.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();
                txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString();
                txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString();
                txtdatesanctioned.Text = ds.Tables[0].Rows[0]["TermLoanApplDate"].ToString();

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
                //if (ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString() != "")
                //    txtLand6.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                //else
                //    txtLand6.Text = "0.00";
                //if (ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString() != "")
                //    txtLand7.Text = ds.Tables[3].Rows[0]["LandAssetsValuebyCA"].ToString();
                //else
                //    txtLand7.Text = "0.00";


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
                //if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString() != "")
                //    txtBuilding6.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                //else
                //    txtBuilding6.Text = "0.00";
                //if (ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString() != "")
                //    txtBuilding7.Text = ds.Tables[3].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                //else
                //    txtBuilding7.Text = "0.00";


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
                //if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString() != "")
                //    txtPM6.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                //else
                //    txtPM6.Text = "0.00";
                //if (ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString() != "")
                //    txtPM7.Text = ds.Tables[3].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                //else
                //    txtPM7.Text = "0.00";

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

                //if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString() != "")
                //    txtMCont6.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                //else
                //    txtMCont6.Text = "0.00";
                //if (ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString() != "")
                //    txtMCont7.Text = ds.Tables[3].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                //else
                //    txtMCont7.Text = "0.00";

                txtErec2.Text = ds.Tables[3].Rows[0]["ErectionApprovedProjectCost"].ToString();
                txtErec3.Text = ds.Tables[3].Rows[0]["ErectionLoanSactioned"].ToString();
                txtErec4.Text = ds.Tables[3].Rows[0]["ErectionPromotersEquity"].ToString();
                txtErec5.Text = ds.Tables[3].Rows[0]["ErectionLoanAmountReleased"].ToString();
                //txtErec6.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                //txtErec7.Text = ds.Tables[3].Rows[0]["ErectionAssetsValuebyCA"].ToString();

                txtTFS2.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                txtTFS3.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                txtTFS4.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                txtTFS5.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                //txtTFS6.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                //txtTFS7.Text = ds.Tables[3].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();

                txtWC2.Text = ds.Tables[3].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                txtWC3.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                txtWC4.Text = ds.Tables[3].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                txtWC5.Text = ds.Tables[3].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                //txtWC6.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                //txtWC7.Text = ds.Tables[3].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                //txtsecondhndmachine.Text = ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString();
                //txtnewmachine.Text = ds.Tables[0].Rows[0]["NewMachVal"].ToString();
                //txtTotalvalue12.Text = ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString();
                //txtpercentage12.Text = ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString();
                //txtmachinepucr.Text = ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString();
                //txttotal25.Text = ds.Tables[0].Rows[0]["TotalMachVal"].ToString();


                //txtAvldSubsidyScheme.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedScheme"].ToString();
                //txtAvldSubsidyAmt.Text = ds.Tables[0].Rows[0]["TotalSubsidyAlreadyAvailedAmount"].ToString();
                //txtSchemeEligible.Text = "";
                //txtAppldInvestSubsidy.Text = ds.Tables[0].Rows[0]["InvestimentSubsidy"].ToString();
                //txtAppldAddlAmtWomen.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomen"].ToString();
                //txtAppldAddlAmtSCST.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForSCORST"].ToString();
                // txtAppldAddlAmtScheduldAreas.Text = ds.Tables[0].Rows[0]["AdditionalInvSubsidyForWomenInScheduledAreas"].ToString();
                //  txtAppldTotInvestSubsidy.Text = ds.Tables[0].Rows[0]["TotalAppliedIncetives"].ToString();

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

                txtVatDate.Text = ds.Tables[0].Rows[0]["CSTRegDate"].ToString();
                txtEMPartNo.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();

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

                    if (MasterIncentiveId == "12")  //AdvSubsidySCST
                    {
                        DataSet ds12 = new DataSet();
                        ds12 = Gen.GetIncentivesAdvSubsidySCST(incentiveID);
                        FilldataSCSCT(ds12);
                    }

                }
            }

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


}