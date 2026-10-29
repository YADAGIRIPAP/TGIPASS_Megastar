using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;
using DataAccessLayer;
using System.Web.UI;

public partial class UI_TSIPASS_appraisalNote_is : System.Web.UI.Page
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        string IncentiveId = Request.QueryString["incid"].ToString();
        string MasterIncentiveId = Request.QueryString["mstid"].ToString();

        SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        osqlConnection.Open();
        SqlDataAdapter da;
        da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_Appraisal_IS", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
        da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
        da.Fill(ds);

        getLOAData(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            HyperLink1.NavigateUrl = "appraisalNote2.aspx?incid=" + IncentiveId + "&mstid=" + MasterIncentiveId + "";
            if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
            {
                tprideTr.Visible = true;
                tideaTr.Visible = false;
            }
            else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
            {
                tprideTr.Visible = true;
                tideaTr.Visible = false;
                //tprideTr.Visible = false;
                //tideaTr.Visible = true;
            }
            lblApplication_no.Text = ds.Tables[0].Rows[0]["lblApplicationno"].ToString();
            lblUnitname.Text = ds.Tables[0].Rows[0]["txtunitnames"].ToString();

            lblLocaddress.Text = ds.Tables[0].Rows[0]["txtLocofUnit"].ToString();
            lblConstitutionOfIndustrial.Text = ds.Tables[0].Rows[0]["ddlOrddlorgtypes"].ToString();
            lblSSIApprovalofIEM.Text = ds.Tables[0].Rows[0]["ddlUdyogAadharType"].ToString();
            lblAcknoledgementLIORIL.Text = ds.Tables[0].Rows[0]["txtPersonIndustry"].ToString();

            //lblLOA.Text = ds.Tables[0].Rows[0]["LOA"].ToString();
            //lblCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
            //lblUnitNumbers.Text = ds.Tables[0].Rows[0]["UnitNumbers"].ToString();
            //lblValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();

            //--------------------Initaial Steps Taken For Project Implementation---------------------
            lblDateOfFilingOfAppln.Text = ds.Tables[0].Rows[0]["txtDateOfapplnFile"].ToString();
            lblBankSanctionLetter_No.Text = ds.Tables[0].Rows[0]["txtLoanApplnNo"].ToString();
            lblLoansanctionDate.Text = ds.Tables[0].Rows[0]["txtDate_Loan"].ToString();
            lblNameOfFinacingInstin.Text = ds.Tables[0].Rows[0]["txtNameofFinIns"].ToString();

            lblPowerConnection_Date_connected.Text = ds.Tables[0].Rows[0]["txtPowerConn_date"].ToString();
            lblPowerConnection_HP_connected.Text = ds.Tables[0].Rows[0]["txtPowerConn_load"].ToString();
            //lblPowerConnection_Date_contracted.Text = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
            //lblPowerConnection_HP_contracted.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();

            lblCommencmentOfCommrclProdcn_Date.Text = ds.Tables[0].Rows[0]["txtDCP_unit"].ToString();
            lblClaimAppln_Date_DIC.Text = ds.Tables[0].Rows[0]["txtDateOfapplnFile"].ToString(); //CHANGED ON 21.01.20201 ds.Tables[0].Rows[0]["txtcompdate_dic"].ToString();//same date as application filed date..
            lblDate_Communcn_ShortFalls_DIC.Text = ds.Tables[0].Rows[0]["txtquery_dic"].ToString();
            lblDateOfReceipt_DIC.Text = ds.Tables[0].Rows[0]["txtrc_dic"].ToString();

            lblClaimAppln_Date_COI.Text = ds.Tables[0].Rows[0]["txtcompdate_coi"].ToString();
            lblDate_Communcn_ShortFalls_COI.Text = ds.Tables[0].Rows[0]["txtquery_coi"].ToString();
            lblDateOfReceipt_COI.Text = ds.Tables[0].Rows[0]["txtcompdate_coi1"].ToString();

            //-------------------Approved Project Cost As Per Guidelines--------------------------------------------------------------------
            lblLand_ProjectCost.Text = ds.Tables[0].Rows[0]["txtLand2"].ToString();
            lblBuilding_ProjectCost.Text = ds.Tables[0].Rows[0]["txtBuilding2"].ToString();
            lblPlantMachry_ProjectCost.Text = ds.Tables[0].Rows[0]["txtPM2"].ToString();
            lblFeasibilityStudyCharges_ProjectCost.Text = ds.Tables[0].Rows[0]["txtMCont2"].ToString();
            lblVehicles_ProjectCost.Text = ds.Tables[0].Rows[0]["txtErec2"].ToString();
            lblOthersEligible_ProjectCost.Text = ds.Tables[0].Rows[0]["txtTFS2"].ToString();
            lblTotal_ProjectCost.Text = ds.Tables[0].Rows[0]["txtWC2"].ToString();

            lblLand_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtLand3"].ToString();
            lblBuilding_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtBuilding3"].ToString();
            lblPlantMachry_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtPM3"].ToString();
            lblFeasibilityStudyCharges_Land_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtMCont3"].ToString();
            lblVehicles_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtErec3"].ToString();
            lblOthersEligible_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtTFS3"].ToString();
            lblTotal_LoanSanctioned.Text = ds.Tables[0].Rows[0]["txtWC3"].ToString();

            lblLand_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtLand4"].ToString();
            lblBuilding_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtBuilding4"].ToString();
            lblPlantMachry_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtPM4"].ToString();
            lblFeasibilityStudyCharges_Land_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtMCont4"].ToString();
            lblVehicles_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtErec4"].ToString();
            lblOthersEligible_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtTFS4"].ToString();
            lblTotal_LoanDisbursed.Text = ds.Tables[0].Rows[0]["txtWC4"].ToString();

            lblLand_Assets.Text = ds.Tables[0].Rows[0]["txtLand5"].ToString();
            lblBuilding_Assets.Text = ds.Tables[0].Rows[0]["txtBuilding5"].ToString();
            lblPlantMachry_Assets.Text = ds.Tables[0].Rows[0]["txtPM5"].ToString();
            lblFeasibilityStudyCharges_Assets.Text = ds.Tables[0].Rows[0]["txtMCont5"].ToString();
            lblVehicles_Assets.Text = ds.Tables[0].Rows[0]["txtErec5"].ToString();
            lblOthersEligible_Assets.Text = ds.Tables[0].Rows[0]["txtTFS5"].ToString();
            lblTotal_Assets.Text = ds.Tables[0].Rows[0]["txtWC5"].ToString();

            lblLand_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtLand6"].ToString();
            lblBuilding_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtBuilding6"].ToString();
            lblPlantMachry_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtPM6"].ToString();
            lblFeasibilityStudyCharges_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtMCont6"].ToString();
            lblVehicles_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtErec6"].ToString();
            lblOthersEligible_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtTFS6"].ToString();
            lblTotal_ActualExpend_CA.Text = ds.Tables[0].Rows[0]["txtWC6"].ToString();

            lblLand_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtLand7"].ToString();
            lblBuilding_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtBuilding7"].ToString();
            lblPlantMachry_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtPM7"].ToString();
            lblFeasibilityStudyCharges_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtMCont7"].ToString();
            lblVehicles_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtErec7"].ToString();
            lblOthersEligible_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtTFS7"].ToString();
            lblTotal_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtWC7"].ToString();

            lblApprovedLnd.Text = ds.Tables[0].Rows[0]["TextBox60"].ToString();
            lblApprBuilding.Text = ds.Tables[0].Rows[0]["TextBox5"].ToString();
            lblApprovPlantMachinery.Text = ds.Tables[0].Rows[0]["TextBox7"].ToString();
            lblPreoperativeexpenditure.Text = ds.Tables[0].Rows[0]["TextBox9"].ToString();
            lblApprovedTechFeasibility.Text = ds.Tables[0].Rows[0]["TextBox11"].ToString();
            lblApprvVehicles.Text = ds.Tables[0].Rows[0]["TextBox13"].ToString();
            lblApprovOthers.Text = ds.Tables[0].Rows[0]["TextBox15"].ToString();
            //lblOthers1Approve.Text = ds.Tables[0].Rows[0]["TextBox17"].ToString();
            lblApprovWorkingCapital.Text = ds.Tables[0].Rows[0]["TextBox18"].ToString();

            //lblOthers1Approve.Text = ds.Tables[0].Rows[0]["Others1Approve"].ToString();
            lblOthers1Approve.Text = "-";
            ////lblApprovWorkingCapital.Text = ds.Tables[0].Rows[0]["TextBox18"].ToString();
            lblApprovlTotal.Text = ds.Tables[0].Rows[0]["TextBox19"].ToString();
            //-------------------Means of finance(Rs in lakhs)------------------------------------------------------------------------------
            lblshareCapita_MF.Text = "-";
            lblStateSubsidy.Text = "-";
            lblFunds_MF.Text = "-";
            lblloan_capital.Text = "-";
            lblTermLoan_MF.Text = "-";
            lblworkingCapital_MF.Text = "-";
            lblUnsecuredloans.Text = "-";
            lblTotal_MF.Text = "-";


            //---------------------Computation of Capital Cost-  ----------A.LAND----------------------------------------
            lblApprovedLandPrjCost.Text = ds.Tables[0].Rows[0]["txtLandcostCompc"].ToString();
            lblLandMeasuring.Text = ds.Tables[0].Rows[0]["txtLandAreaCompc"].ToString();
            lblLandPurchaseValue.Text = ds.Tables[0].Rows[0]["txtPurchaCompc"].ToString();
            lblLandStampDuty.Text = ds.Tables[0].Rows[0]["txtStmpDutyCompc"].ToString();
            lblLandRegistrationFee.Text = ds.Tables[0].Rows[0]["txtRegnfeeCompc"].ToString();
            lblTotalLand.Text = ds.Tables[0].Rows[0]["txtTotalCompc"].ToString();
            lblLandBuildingPlinthArea.Text = ds.Tables[0].Rows[0]["txtBuildingAreCompc"].ToString();
            lblLandValue_RecommdedBy_GM.Text = ds.Tables[0].Rows[0]["txtvalDICCompc"].ToString();
            lblLandValue_Computed.Text = ds.Tables[0].Rows[0]["txtvalCompc1"].ToString();
            lblLandReasons_GM_Recommendation.Text = ds.Tables[0].Rows[0]["txtresonsCompc"].ToString();
            //------------------------------B.FACTORY---------------------------------------------------------------------
            lblFactryProjCost.Text = ds.Tables[0].Rows[0]["txtfacCostCompc"].ToString();
            lblFactoryPlinthArea.Text = ds.Tables[0].Rows[0]["txtfacBldgCompc"].ToString();
            lblFactryCivilEngineerCert.Text = ds.Tables[0].Rows[0]["txtcivilEngCompc"].ToString(); ;
            lblFactryTSSFCrates.Text = ds.Tables[0].Rows[0]["txtsfcCompc"].ToString();
            lblFactoryExpendutreCert.Text = ds.Tables[0].Rows[0]["txtCAExpCompc"].ToString();
            lblFactoryComputedValue.Text = ds.Tables[0].Rows[0]["txtCompvalCompc"].ToString();
            lblReasonFactoryGMrecom.Text = ds.Tables[0].Rows[0]["txtrsnCompc"].ToString();

            //----------------------------------C.PLANT & MACHINERY-------------------------------------------
            lblProjcostPlant.Text = ds.Tables[0].Rows[0]["TextBox30"].ToString();
            lblTechFeasibilityPlantprjcost.Text = ds.Tables[0].Rows[0]["TextBox32"].ToString();
            lblPlantSubTotal.Text = ds.Tables[0].Rows[0]["TextBox31"].ToString(); //cost comptd

            lblPlantMCstatements.Text = ds.Tables[0].Rows[0]["TextBox36"].ToString();
            lblPlantCACerti.Text = ds.Tables[0].Rows[0]["TextBox38"].ToString();
            lblPlantCapitalisCerti.Text = ds.Tables[0].Rows[0]["TextBox40"].ToString();
            lblComputdValuePlant.Text = ds.Tables[0].Rows[0]["TextBox42"].ToString();
            lblGmrecommnPlant.Text = ds.Tables[0].Rows[0]["TextBox47"].ToString();
            // lblRecomGmPlant.Text = ds.Tables[0].Rows[0]["TextBox34"].ToString();

            //------------------------------D.ABSTRACT--------------------------------------------------------

            lblLandCost_Abstract.Text = ds.Tables[0].Rows[0]["TextBox33"].ToString();
            lblBuldingCost_Abstract.Text = ds.Tables[0].Rows[0]["TextBox37"].ToString();
            lblPlantCost_Abstract.Text = ds.Tables[0].Rows[0]["TextBox41"].ToString();
            lblFeasibilityCharges_Abstract.Text = ds.Tables[0].Rows[0]["TextBox44"].ToString();
            lblTotApproveInvest_Abstract.Text = ds.Tables[0].Rows[0]["TextBox1"].ToString();

            lblComputedLandValue_Abstract.Text = ds.Tables[0].Rows[0]["TextBox56"].ToString();
            lblComputedBuildingValue_Abstract.Text = ds.Tables[0].Rows[0]["TextBox57"].ToString();
            lblComputedtPlantlValue_Abstract.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
            lblFeasibilityComputedCharges_Abstract.Text = ds.Tables[0].Rows[0]["TextBox45"].ToString();
            lblComputedTotalValue_Abstract.Text = ds.Tables[0].Rows[0]["TextBox2"].ToString();

            //-------------------------REMARKS-------------------------------------------------------------------------------
            lblSecondHandMchValue.Text = ds.Tables[0].Rows[0]["TextBox35"].ToString();
            lblSocialStatus.Text = ds.Tables[0].Rows[0]["TextBox39"].ToString();
            lblBelatedClaim.Text = ds.Tables[0].Rows[0]["TextBox43"].ToString();
            lblAvailedSubsidy.Text = ds.Tables[0].Rows[0]["TextBox46"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["TextBox48"].ToString();
            lblDateofProdctn.Text = ds.Tables[0].Rows[0]["txtContProdMgm"].ToString();
            //------------------------EXPANSION/DIVERSIFICATION CASES----------------------------------------------------------

            lblInvestPriorED.Text = ds.Tables[0].Rows[0]["txt25BldgCvl"].ToString();
            lblInvestUnderED.Text = ds.Tables[0].Rows[0]["txt822guideline422"].ToString();
            lblIncreaseInvestnED.Text = ds.Tables[0].Rows[0]["txtTSSFCnorms422"].ToString();
            lblProdCapcityED.Text = ds.Tables[0].Rows[0]["txtPlintharea424"].ToString();
            lblAddinCapacityED.Text = ds.Tables[0].Rows[0]["txtPlintharea422"].ToString();
            lblIncresCapcityUndrED.Text = ds.Tables[0].Rows[0]["txtvalue422"].ToString();
            //-----------------------ELIGIBLE INCENTIVES-------------------------------------------------------------------------
            lblPercent.Text = ds.Tables[0].Rows[0]["TextBox59"].ToString();
            lblStateInvesSubsidy.Text = ds.Tables[0].Rows[0]["txt423guideline"].ToString();
            lblAddlSubWomen.Text = ds.Tables[0].Rows[0]["txtTSSFCnorms423"].ToString();
            lblEligi_TotalSubsidy.Text = ds.Tables[0].Rows[0]["txtvalue424"].ToString();
            if (MasterIncentiveId == "6")
            {
                Div3.Visible = true;
                trAsperDecisionIS.Visible = true;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                lblSancIncentiveName.Text = "Sanction of Investment Subsidy";

                lblapplicationtype_IS.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lbllmvornonlmv.Text = ds.Tables[0].Rows[0]["LMV"].ToString();
                lblmenorwomen.Text = ds.Tables[0].Rows[0]["WOMENMEN"].ToString();
                if (lblapplicationtype_IS.Text == "Regular" && lblmenorwomen.Text == "Women")
                {
                    lblpercentage_is.Text = "10%";
                }
                else
                {
                    lblpercentage_is.Text = "0%";
                }
                if (lblapplicationtype_IS.Text == "Belated" && lblmenorwomen.Text == "Women")
                {
                    lblpercentage_is.Text = "5%";
                }
                else
                {
                    lblpercentage_is.Text = "0%";
                }
                if (lblapplicationtype_IS.Text == "OneYear" && lblmenorwomen.Text == "Women")
                {
                    lblpercentage_is.Text = "0%";
                }
                else
                {
                    lblpercentage_is.Text = "0%";
                }
                LBLREMARKS.Text = ds.Tables[0].Rows[0]["WOMENMEN"].ToString();
            }

            if (MasterIncentiveId == "16")  //land conversion 
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = true;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;

                lblLConLandMeasure.Text = ds.Tables[0].Rows[0]["landmeasuring"].ToString();
                LblLconPurchaseValue.Text = ds.Tables[0].Rows[0]["purchasevalue"].ToString();
                lblLconBuildingPlnth.Text = ds.Tables[0].Rows[0]["buildingplntharea"].ToString();
                lblfietimesplintharea.Text = ds.Tables[0].Rows[0]["buildingplnthareaFveTimes"].ToString();

                lblLconProportionate.Text = ds.Tables[0].Rows[0]["proportionatevalue"].ToString();
                lblLconLandValueComputed.Text = ds.Tables[0].Rows[0]["landvaluecomputed"].ToString();
                lblLconTwntyFveComputed.Text = ds.Tables[0].Rows[0]["twntyfveComputed"].ToString();
                lblLConEligibleLandConversion.Text = ds.Tables[0].Rows[0]["Finaleligibleamount"].ToString();
                lblLconValueGMRecom.Text = ds.Tables[0].Rows[0]["valuerecndgm"].ToString();


                lblLconClaimType.Text = ds.Tables[0].Rows[0]["applicantType"].ToString();
                LBLREMARKS_LANDCONVERSION.Text = ds.Tables[0].Rows[0]["mortgageRemarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Land Conversion";


            }
            if (MasterIncentiveId == "15")  //mortgage 
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = true;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;

                lblMortFinancialIns.Text = ds.Tables[0].Rows[0]["FinInstitution"].ToString();
                lblMortTermLoan.Text = ds.Tables[0].Rows[0]["TermLoanSancctioned"].ToString();
                lblMortMortgageDutyPaid.Text = ds.Tables[0].Rows[0]["MortgagePaid"].ToString();
                lblMortTermloanAvailed.Text = ds.Tables[0].Rows[0]["TermLoanAvailed"].ToString();
                lblMortProportionateMortgage.Text = ds.Tables[0].Rows[0]["PropMortgageDuty"].ToString();
                lblMortMortgageDuty.Text = ds.Tables[0].Rows[0]["Mortgage_gM"].ToString();
                lblMortElgibleReimbursement.Text = ds.Tables[0].Rows[0]["ElegibleReimbursemant"].ToString();
                lblMortTypeofClaim.Text = ds.Tables[0].Rows[0]["applicantType"].ToString();
                lblremarks_mortegage.Text = ds.Tables[0].Rows[0]["mortgageRemarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Mortgage";


            }
            if (MasterIncentiveId == "17")   //land cost  
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = true;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;

                //lblLCEligibleLandCost.Text= ds.Tables[0].Rows[0]["ELIGIBLELANDCOST"].ToString();
                lblLcLandPurchase.Text = ds.Tables[0].Rows[0]["LANDPURCHASE"].ToString();
                lblLCLandvalue.Text = ds.Tables[0].Rows[0]["LANDVALUE"].ToString();
                lblLCPlnthArea.Text = ds.Tables[0].Rows[0]["BuildingPlinth"].ToString();
                lblLCfiveTimes.Text = ds.Tables[0].Rows[0]["TotalBuildingPlinth_CALCULATED"].ToString();
                lblLCProportionate.Text = ds.Tables[0].Rows[0]["Proportionatearea"].ToString();
                lblLCValueRecmGM.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblLCEligibleLandCost.Text = ds.Tables[0].Rows[0]["FINALELIGIBLELANDCOST"].ToString();
                lbltypeofclainlandcost.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                //lblLCfiveTimes
                //lblLcLandPurchase
                lblremarks_landcost.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Land Cost";


            }
            if (MasterIncentiveId == "14")   //stampduty  
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = true;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;

                lblSDBuildingplnthfvTimes.Text = ds.Tables[0].Rows[0]["StampBuildingPlinth"].ToString();
                lblSDBuildingPlinth.Text = ds.Tables[0].Rows[0]["BuildingPlinth"].ToString();
                lblSDLandmeasuring.Text = ds.Tables[0].Rows[0]["LandSqmt"].ToString();
                lblSDStampduty.Text = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                lblSDProportionateVAlue.Text = ds.Tables[0].Rows[0]["Proportionatearea"].ToString();
                lblSDValueRecomndGM.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblSDValueComputed.Text = ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"].ToString();
                LBLTYPEOFCLAIM_STAMPDUTY.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                //lblSDBuildingPlinth.Text = ds.Tables[0].Rows[0]["StampSubTotal"].ToString();
                //lblSDValueComputed.Text = ds.Tables[0].Rows[0]["StampBuildingPlinth"].ToString();
                lblSancIncentiveName.Text = "Sanction of Reimbursement of stamp Duty/Transfer Duty";
                lblremarks_stampduty.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();


            }
            if (MasterIncentiveId == "5")   //salestax  
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = true;
                DIVQUALITYCERTIFICATION.Visible = false;

                LBLSCHEMETYPE.Text = ds.Tables[0].Rows[0]["SCHEMETYPE"].ToString();
                lblapplicationtype.Text = ds.Tables[0].Rows[0]["APPLICATIONTYPE"].ToString();
                lblproduction.Text = ds.Tables[0].Rows[0]["PRODUCTION"].ToString();
                lbltaxpaid.Text = ds.Tables[0].Rows[0]["TAXPAIDSGST"].ToString();
                lblbaseproduction.Text = ds.Tables[0].Rows[0]["BASEPRODUCTION"].ToString();
                lblelgprodqty.Text = ds.Tables[0].Rows[0]["ELIGIBLEPRODUCTIONQUANTITY"].ToString();
                lblproportionatesgst.Text = ds.Tables[0].Rows[0]["PROPORTINATESGST"].ToString();
                lblgmrecommendedvalue.Text = ds.Tables[0].Rows[0]["GMVALUE"].ToString();
                lblcategory.Text = ds.Tables[0].Rows[0]["CATEGORYNAME"].ToString();
                if (lblcategory.Text == "Mega")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MEGA"].ToString();
                }
                if (lblcategory.Text == "Large")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["LARGE"].ToString();
                }
                if (lblcategory.Text == "Medium")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MEDIUM"].ToString();
                }
                if (lblcategory.Text == "Small")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["SMALL"].ToString();
                }
                if (lblcategory.Text == "Micro")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MICRO"].ToString();
                }
                if (LBLSCHEMETYPE.Text == "")
                {
                    trcapitaleligibleinvestment.Visible = true;
                    trsalestaxsanctionedonthisclaim.Visible = true;
                    lblcapitalelginvestment.Text = ds.Tables[0].Rows[0]["TOTALCAPITALELIGIBLEINVESTMENT"].ToString();
                    lblsalestaxsanctioned.Text = ds.Tables[0].Rows[0]["TOTALSALESTAXSANCTIONEDONTHISCLAIM"].ToString();
                }
                else
                {
                    trcapitaleligibleinvestment.Visible = false;
                    trsalestaxsanctionedonthisclaim.Visible = false;
                }
                lbleligibleamount.Text = ds.Tables[0].Rows[0]["FINALSUBSIDYAMOUNT"].ToString();
                lbltypeofclaim.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblremarks_salestax.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Sales Tax";


            }
            if (MasterIncentiveId == "11")   //Quality Certification  
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = true;

                lblqualitycertificationcgargespaid.Text = ds.Tables[0].Rows[0]["QUALITYCERTIFICATIONCHARESPAID"].ToString();
                lblfiftypercentage.Text = ds.Tables[0].Rows[0]["FIFTYPEROFCHARGESPAID"].ToString();
                lblgmrecomamount.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lbllesselegibleamount.Text = ds.Tables[0].Rows[0]["ELEGIBLEWHICHEVERLESS"].ToString();
                lbltypeofclaim_quality.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblremarks_qualitycertification.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();



                lblSancIncentiveName.Text = "Sanction of Reimbursement of Quality Certification";


            }
            if (MasterIncentiveId == "1")   //Pallavaddi
            {
                Div3.Visible = false;
                trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                div_pallavaddi.Visible = true;
                USP_GETDETAILSFORSECTION(Convert.ToString(Request.QueryString["incid"]));
                lblSancIncentiveName.Text = "Sanction of Pavala Vaddi";
            }
        }
    }


    public void USP_GETDETAILSFORSECTION(string IncentiveId)
    {
        DataSet ds = DB_apprasialnote2pallavaddi(IncentiveId, "");
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MstIncentiveId = "1";

                    //txt_eglsacamountinterestreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLESANCTIONEDAMOUNT"]);
                    //ddl_ClaimPeriod.Text = Convert.ToString(ds.Tables[0].Rows[0]["CLAIMPERIOD"]);
                    //txt_DateofCommencementofactivity.Text = Convert.ToString(ds.Tables[0].Rows[0]["DATEOFCOMMENCEMENTOFACTIVITY"]);
                    //txt_Eligibleperiodinmonths.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTPERIOD"]);
                    //txt_noofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS"]);
                    //txt_Installmentamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTAMOUNT"]);
                    //txt_installmentstartdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTSTARTMONTHYEAR_ID"]);
                    //txt_RateofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["RATEOFINTEREST"]);
                    //txt_Eligiblerateofreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLERATEOFREUMBERSEMENT"]);
                    //txt_Noofinstallmentscompleted.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS_COMPLETED"]);
                    //txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(ds.Tables[0].Rows[0]["PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR"]);
                    //txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                    //txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                    //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                    //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                    //txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                    //txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);
                    //rbtgrd_isbelated.Text = Convert.ToString(ds.Tables[0].Rows[0]["EglibleTypeName"]);
                    //txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                    //ddl_periodofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PERIODOFINSTALMENTName"]);

                    txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                    txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                    txt_ConsideredAmountofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                    txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                    txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                    txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                    txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);

                    txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                    lbl_pavallavaddiremarksbyclerk.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remarks"]);
                }

                if (ds.Tables.Count >= 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //grd_financalyeargrid.DataSource = ds.Tables[1];
                        //grd_financalyeargrid.DataBind();
                    }

                }

                grd_claimperiodofloanadd.Visible = false;
                if (ds.Tables.Count >= 3)
                {
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        grd_claimperiodofloanadd.DataSource = ds.Tables[3];
                        grd_claimperiodofloanadd.DataBind();
                        grd_claimperiodofloanadd.Visible = true;
                    }

                }
                grd_eglibilepallavaddi.Visible = false;
                if (ds.Tables.Count >= 4)
                {
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        grd_eglibilepallavaddi.Visible = true;
                        grd_eglibilepallavaddi.DataSource = ds.Tables[4];
                        grd_eglibilepallavaddi.DataBind();
                    }

                }



            }
        }
    }
    protected void grd_financalyeargrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CLAIMPERIOD_Grid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CLAIMPERIOD_Grid"));
            // string CLAIMPERIOD_Grid = grd_financalyeargrid.DataKeys[e.Row.RowIndex].Value.ToString();
            GridView grd_Addclaimperiod = e.Row.FindControl("grd_Addclaimperiod") as GridView;
            DataSet ds_data = DB_apprasialnote2pallavaddi(Convert.ToString(Request.QueryString["incid"]), CLAIMPERIOD_Grid);
            if (ds_data != null)
            {
                if (ds_data.Tables.Count > 0)
                {
                    if (ds_data.Tables.Count >= 2)
                    {
                        if (ds_data.Tables[2].Rows.Count > 0)
                        {
                            grd_Addclaimperiod.DataSource = ds_data.Tables[2];
                            grd_Addclaimperiod.DataBind();
                        }

                    }
                }
            }
        }
    }

    public void getLOAData(DataSet ds1)
    {
        if (ds1.Tables.Count > 0)
        {
            if (ds1.Tables.Count >= 2)
            {
                gvInstalledCap.DataSource = ds1.Tables[1];
                gvInstalledCap.DataBind();
            }
        }
    }

    public DataSet DB_apprasialnote2pallavaddi(string IncentiveId, string CLAIMPERIOD_Grid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("pv_apprasialnote2pallavaddi", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
            if (CLAIMPERIOD_Grid.Trim() == "" || CLAIMPERIOD_Grid.Trim() == null)
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = CLAIMPERIOD_Grid.ToString();


            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
}