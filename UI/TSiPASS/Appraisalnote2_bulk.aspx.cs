using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BusinessLogic;

public partial class UI_TSiPASS_Appraisalnote2_bulk : System.Web.UI.Page
{
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    General gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["uid"]) != "161017" && Convert.ToString(Session["uid"]) != "161018" && Convert.ToString(Session["uid"]) != "161019" && Convert.ToString(Session["uid"]) != "161020" &&
              Convert.ToString(Session["uid"]) != "127573" && Convert.ToString(Session["uid"]) != "127574")
            {
                Response.Redirect("HomeCoiDashboard.aspx");
            }
            // If called directly via single record query string (backward compatibility)
            if (Request.QueryString["incid"] != null && Request.QueryString["mstid"] != null)
            {
                DataTable dtDirect = new DataTable();
                dtDirect.Columns.Add("IncentiveId", typeof(string));
                dtDirect.Columns.Add("MasterIncentiveId", typeof(string));
                dtDirect.Rows.Add(Request.QueryString["incid"].ToString(), Request.QueryString["mstid"].ToString());

                pnlSelection.Visible = false;
                pnlPrintView.Visible = true;
                lblPrintCount.Text = "Appraisal Note";
                rptAppraisals.DataSource = dtDirect;
                rptAppraisals.DataBind();
            }
            else
            {
                pnlSelection.Visible = true;
                pnlPrintView.Visible = false;
            }
            if (Convert.ToString(Session["username"]).Contains("GENERAL"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("3"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("4"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("9"));
                ddlcategory.SelectedValue = "1";
                ddlcategory.Enabled = false;

            }
            else if (Convert.ToString(Session["username"]).Contains("SCP"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("1"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("4"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("9"));
                ddlcategory.SelectedValue = "3";
                ddlcategory.Enabled = false;

            }
            else if (Convert.ToString(Session["username"]).Contains("TSP"))
            {
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("1"));
                ddlcategory.Items.Remove(ddlcategory.Items.FindByValue("3"));
            }
            DataSet ds = new DataSet();
            ds = getProposedSVClistconvened();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlapplicationto.DataSource = ds.Tables[0];
                ddlapplicationto.DataValueField = "ProposedSVCDATEnew";
                ddlapplicationto.DataTextField = "ProposedSVCDATE";
                ddlapplicationto.DataBind();
            }
        }
    }

    // ==========================================
    // 1. GET DATA BUTTON (LOADS APPLICANT LIST)
    // ==========================================
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        fetchIncentivedetIPONewIncTypeAddlDirector();
    }
    public void fetchIncentivedetIPONewIncTypeAddlDirector()
    {
        DataSet dsnew = new DataSet();
       
        dsnew = GetAppraisalprint( ddlcategory.SelectedValue, ddlincentivetype.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            gvApplications.DataSource = dsnew.Tables[0];
            gvApplications.DataBind();
            gvApplications.Visible = true;
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            gvApplications.DataSource = null;
            gvApplications.DataBind();
            gvApplications.Visible = false;
        }
    }

    public DataSet GetAppraisalprint( string CASTEID, string MSTINCTYPEID)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@MstIncentiveId",SqlDbType.VarChar),
                new SqlParameter("@CASTEID",SqlDbType.VarChar),
                 new SqlParameter("@SLCDate",SqlDbType.VarChar)
              // new SqlParameter("@DISTRICTID",SqlDbType.VarChar)
               
           };
        pp[0].Value = MSTINCTYPEID;
        pp[1].Value = CASTEID;
        pp[2].Value = Convert.ToString(DateTime.ParseExact(ddlapplicationto.SelectedItem.Text, "dd/MM/yyyy", null).ToString("MM-dd-yyyy"));

        Dsnew = gen.GenericFillDs("USP_GET_APPRAISAL_BLUK_NEW_15092026", pp);
        return Dsnew;
    }
    // ==========================================
    // 2. PRINT BUTTON (COLLECTS CHECKBOX SELECTIONS)
    // ==========================================
    protected void btnPrintAppraisals_Click(object sender, EventArgs e)
    {
        DataTable dtSelected = new DataTable();
        dtSelected.Columns.Add("IncentiveId", typeof(string));
        dtSelected.Columns.Add("MasterIncentiveId", typeof(string));

        foreach (GridViewRow row in gvApplications.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk != null && chk.Checked)
                {
                    HiddenField hfInc = (HiddenField)row.FindControl("hfGridIncId");
                    HiddenField hfMst = (HiddenField)row.FindControl("hfGridMstId");

                    string incId = (hfInc != null && !string.IsNullOrEmpty(hfInc.Value))
                        ? hfInc.Value
                        : gvApplications.DataKeys[row.RowIndex]["IncentiveId"].ToString();

                    string mstId = (hfMst != null && !string.IsNullOrEmpty(hfMst.Value))
                        ? hfMst.Value
                        : gvApplications.DataKeys[row.RowIndex]["MasterIncentiveId"].ToString();

                    if (!string.IsNullOrEmpty(incId))
                    {
                        dtSelected.Rows.Add(incId, mstId);
                    }
                }
            }
        }

        if (dtSelected.Rows.Count > 0)
        {
            pnlSelection.Visible = false;
            pnlPrintView.Visible = true;
            lblPrintCount.Text = "Total Appraisal Notes Generated: " + dtSelected.Rows.Count;

            rptAppraisals.DataSource = dtSelected;
            rptAppraisals.DataBind();
        }
        else
        {
            lblGridMessage.Text = "Please select at least one record using the checkbox.";
        }
    }

    protected void btnBackToSelection_Click(object sender, EventArgs e)
    {
        pnlSelection.Visible = true;
        pnlPrintView.Visible = false;
        rptAppraisals.DataSource = null;
        rptAppraisals.DataBind();
    }

    // ==========================================
    // 3. REPEATER ITEM DATA BOUND (EACH RECORD)
    // ==========================================
    protected void rptAppraisals_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        HiddenField hfIncentiveId = (HiddenField)e.Item.FindControl("hfIncentiveId");
        HiddenField hfMasterIncentiveId = (HiddenField)e.Item.FindControl("hfMasterIncentiveId");

        string incentiveId = hfIncentiveId.Value;
        string masterIncentiveId = hfMasterIncentiveId.Value;

        // 1. Proforma Basic Details
        DataSet ds2 = gen.GetBasicUnitDetails_Proforma_lettersPSR(incentiveId, masterIncentiveId);
        if (masterIncentiveId == "1" || masterIncentiveId == "3" || masterIncentiveId == "5")
        {
            HtmlTableRow trClaimPeriod = (HtmlTableRow)e.Item.FindControl("TRCLAIMPERIOD");
            Label lblClaimPeriod = (Label)e.Item.FindControl("lblclaimperiod");
            if (trClaimPeriod != null && lblClaimPeriod != null && ds2 != null && ds2.Tables.Count > 1 && ds2.Tables[1].Rows.Count > 0)
            {
                trClaimPeriod.Visible = true;
                lblClaimPeriod.Text = ds2.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();
            }
        }

        // 2. Section Details Stored Procedure
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("USP_GETDETAILSFORSECTION_Appraisal_IS_New1", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = incentiveId;
                cmd.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = masterIncentiveId;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }
            }
        }

        // 3. Line of Activity Grid
        GridView gvInstalledCap = (GridView)e.Item.FindControl("gvInstalledCap");
        if (gvInstalledCap != null && ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            gvInstalledCap.DataSource = ds.Tables[1];
            gvInstalledCap.DataBind();
        }

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        DataRow dr = ds.Tables[0].Rows[0];

        // 4. Header & Attachment Handlers
        HtmlTableRow clerkattachment = (HtmlTableRow)e.Item.FindControl("clerkattachment");
        HyperLink hylinkattachment = (HyperLink)e.Item.FindControl("hylinkattachment");
        string downloadLink = dr["Downloadlink"] != DBNull.Value ? dr["Downloadlink"].ToString() : "";
        if (!string.IsNullOrEmpty(downloadLink))
        {
            if (clerkattachment != null) clerkattachment.Visible = true;
            if (hylinkattachment != null)
            {
                hylinkattachment.Visible = true;
                hylinkattachment.NavigateUrl = "CS.aspx?filepathnew=" + gen.Encrypt(downloadLink, "SYSTIME");
            }
        }

        HtmlTableRow trScheme = (HtmlTableRow)e.Item.FindControl("TRSCHEME");
        Label lblScheme = (Label)e.Item.FindControl("LBLSCHEME");
        if ((masterIncentiveId == "3" || masterIncentiveId == "5") && trScheme != null && lblScheme != null)
        {
            trScheme.Visible = true;
            lblScheme.Text = dr["Scheme"].ToString();
        }

        HtmlTableRow tprideTr = (HtmlTableRow)e.Item.FindControl("tprideTr");
        HtmlTableRow tideaTr = (HtmlTableRow)e.Item.FindControl("tideaTr");
        HtmlTableRow trMsme = (HtmlTableRow)e.Item.FindControl("TRMSME");
        Label lblCaste = (Label)e.Item.FindControl("LBLCASTE");
        Label lblCaste2 = (Label)e.Item.FindControl("LBLCASTE2");

        string tideaTpride = dr["lblTideaTpride"].ToString();
        if (tideaTpride == "Y")
        {
            if (tprideTr != null) tprideTr.Visible = false;
            if (tideaTr != null) tideaTr.Visible = true;
            if (trMsme != null) trMsme.Visible = false;
        }
        else if (tideaTpride == "N")
        {
            if (tprideTr != null) tprideTr.Visible = true;
            if (tideaTr != null) tideaTr.Visible = false;
            if (trMsme != null) trMsme.Visible = false;

            string caste = dr["CASTE"].ToString();
            if (caste == "SC")
            {
                if (lblCaste != null) { lblCaste.Text = "SCSDF (SCP)"; lblCaste.Visible = true; }
                if (lblCaste2 != null) { lblCaste2.Text = "- SCSDF (SCP)"; lblCaste2.Visible = true; }
            }
            else if (caste == "ST")
            {
                if (lblCaste != null) { lblCaste.Text = "STSDF (TSP)"; lblCaste.Visible = true; }
                if (lblCaste2 != null) { lblCaste2.Text = "- STSDF (TSP)"; lblCaste2.Visible = true; }
            }
        }

        if (dr["MSME_Applied"].ToString() == "Y")
        {
            if (tprideTr != null) tprideTr.Visible = false;
            if (tideaTr != null) tideaTr.Visible = false;
            if (trMsme != null) trMsme.Visible = true;
        }

        // 5. Basic Enterprise Fields
        SetLabel(e.Item, "lblDetailsConfirmed", string.IsNullOrEmpty(dr["DetailsGm"].ToString()) ? "NA" : dr["DetailsGm"].ToString());
        SetLabel(e.Item, "lblApplication_no", dr["lblApplicationno"].ToString());
        SetLabel(e.Item, "lblUnitname", dr["txtunitnames"].ToString());
        SetLabel(e.Item, "lblLocaddress", dr["txtLocofUnit"].ToString());
        SetLabel(e.Item, "lblConstitutionOfIndustrial", dr["ddlOrddlorgtypes"].ToString());
        SetLabel(e.Item, "lblSocialStatus", dr["CASTE"].ToString());
        SetLabel(e.Item, "lblPromoterName", dr["ApplciantName"].ToString());
        SetLabel(e.Item, "lblEntrprName", dr["ApplciantName"].ToString());
        SetLabel(e.Item, "lblSSIRegn", dr["txtPersonIndustry"].ToString());
        SetLabel(e.Item, "lblNewExpnDiver", dr["IdsustryStatus"].ToString());
        SetLabel(e.Item, "lblCommencmentOfCommrclProdcn_Date", dr["txtDCP_unit"].ToString());
        SetLabel(e.Item, "lblApplicationDateDIC", dr["txtDateOfapplnFile"].ToString());
        SetLabel(e.Item, "lblFinInstn", dr["txtNameofFinIns"].ToString());

        // 6. Fixed Capital Calculations
        decimal valLand2 = ToDecimalSafe(dr["txtLand2"]);
        decimal valBuilding2 = ToDecimalSafe(dr["txtBuilding2"]);
        decimal valPM2 = ToDecimalSafe(dr["txtPM2"]);
        SetLabel(e.Item, "lblTotal_ProjectCost", (valLand2 + valBuilding2 + valPM2).ToString());

        decimal valLand7 = ToDecimalSafe(dr["txtLand7"]);
        decimal valBuilding7 = ToDecimalSafe(dr["txtBuilding7"]);
        decimal valPM7 = ToDecimalSafe(dr["txtPM7"]);
        SetLabel(e.Item, "lblTotal_ValueRecommendedByGM", (valLand7 + valBuilding7 + valPM7).ToString());

        decimal valTb56 = ToDecimalSafe(dr["TextBox56"]);
        decimal valTb57 = ToDecimalSafe(dr["TextBox57"]);
        decimal valTb58 = ToDecimalSafe(dr["TextBox58"]);
        SetLabel(e.Item, "lblTotalComputed", (valTb56 + valTb57 + valTb58).ToString());

        SetLabel(e.Item, "lblLand_ProjectCost", dr["txtLand2"].ToString());
        SetLabel(e.Item, "lblLand_ValueRecommendedByGM", dr["txtLand7"].ToString());
        SetLabel(e.Item, "lblLandComputed", dr["TextBox56"].ToString());
        SetLabel(e.Item, "lblLand_GMRec", dr["txtresonsCompc"].ToString());

        SetLabel(e.Item, "lblBuilding_ProjectCost", dr["txtBuilding2"].ToString());
        SetLabel(e.Item, "lblBuilding_ValueRecommendedByGM", dr["txtBuilding7"].ToString());
        SetLabel(e.Item, "lblBuildingComputed", dr["TextBox57"].ToString());
        SetLabel(e.Item, "lblBuilding_GMRec", dr["txtrsnCompc"].ToString());

        SetLabel(e.Item, "lblPlantMachry_ProjectCost", dr["txtPM2"].ToString());
        SetLabel(e.Item, "lblPlantMachry_ValueRecommendedByGM", dr["txtPM7"].ToString());
        SetLabel(e.Item, "lblPlantMachryComputed", dr["TextBox58"].ToString());
        SetLabel(e.Item, "lblPlantMachry_GMRec", dr["TextBox47"].ToString());

        SetLabel(e.Item, "lblVehicles_ProjectCost", dr["txtErec2"].ToString());
        SetLabel(e.Item, "lblVehicles_ValueRecommendedByGM", "-");
        SetLabel(e.Item, "lblVehiclesComputed", "-");
        SetLabel(e.Item, "lblVehicles_GMRec", "-");

        SetLabel(e.Item, "lblOthersEligible_ProjectCost", dr["txtTFS2"].ToString());
        SetLabel(e.Item, "lblOthersEligible_ValueRecommendedByGM", "-");
        SetLabel(e.Item, "lblOthersEligibleComputed", "-");
        SetLabel(e.Item, "lblOthersEligible_GMRec", "-");

        SetLabel(e.Item, "lblFeasibilityStudyCharges_ProjectCost", dr["TextBox44"].ToString());
        SetLabel(e.Item, "lblFeasibilityStudyCharges_ValueRecommendedByGM", dr["TextBox45"].ToString());
        SetLabel(e.Item, "lblFeasibilityStudyChargesComputed", "-");
        SetLabel(e.Item, "lblFeasibilityStudyCharges_GMRec", "-");

        SetLabel(e.Item, "lblPercent", dr["TextBox59"].ToString());
        SetLabel(e.Item, "lblStateInvesSubsidy", dr["txt423guideline"].ToString());
        SetLabel(e.Item, "lblAddlSubWomen", dr["txtTSSFCnorms423"].ToString());
        SetLabel(e.Item, "lblEligi_TotalSubsidy", dr["txtvalue424"].ToString());

        // 7. Toggle Scheme Panels
        HideAllSchemePanels(e.Item);

        // ================= MASTER INCENTIVE CONDITIONS =================
        if (masterIncentiveId == "1") // Pavala Vaddi
        {
            SetControlVisibility(e.Item, "div_pallavaddi", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Pavala Vaddi");
            BindPavalaVaddi(e.Item, incentiveId);
        }
        else if (masterIncentiveId == "6") // Investment Subsidy
        {
            SetControlVisibility(e.Item, "Div3", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Investment Subsidy");
            string appTypeIS = dr["ELIGIBLETYPE"].ToString();
            string womenMen = dr["WOMENMEN"].ToString();

            SetLabel(e.Item, "lblapplicationtype_IS", appTypeIS);
            SetLabel(e.Item, "lbllmvornonlmv", dr["LMV"].ToString());
            SetLabel(e.Item, "lblmenorwomen", womenMen);

            Label lblWomen = (Label)e.Item.FindControl("lblwomen");
            if (womenMen == "Women")
            {
                if (lblWomen != null) { lblWomen.Visible = true; lblWomen.Text = "| Women Entrepreneur : (100% Share)"; }
                SetLabel(e.Item, "lblpercentage_is", appTypeIS == "Regular" ? "10%" : (appTypeIS == "Belated" ? "5%" : "0%"));
            }
            else
            {
                if (lblWomen != null) lblWomen.Visible = false;
                SetLabel(e.Item, "lblpercentage_is", "0%");
            }

            SetLabel(e.Item, "lblFinalSchemeName", dr["Scheme"].ToString());
            SetLabel(e.Item, "LblDICName", dr["distName"].ToString());
            SetLabel(e.Item, "LBLREMARKS", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "5") // Sales Tax
        {
            SetControlVisibility(e.Item, "DIVSALESTAX", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Sales Tax");
            SetLabel(e.Item, "LBLSCHEMETYPE", dr["SCHEMETYPE"].ToString());
            SetLabel(e.Item, "lblapplicationtype", dr["APPLICATIONTYPE"].ToString());
            SetLabel(e.Item, "lblproduction", dr["PRODUCTION"].ToString());
            SetLabel(e.Item, "lbltaxpaid", dr["TAXPAIDSGST"].ToString());
            SetLabel(e.Item, "lblbaseproduction", dr["BASEPRODUCTION"].ToString());
            SetLabel(e.Item, "lblelgprodqty", dr["ELIGIBLEPRODUCTIONQUANTITY"].ToString());
            SetLabel(e.Item, "lblproportionatesgst", dr["PROPORTINATESGST"].ToString());
            SetLabel(e.Item, "lblgmrecommendedvalue", dr["GMVALUE"].ToString());
            string category = dr["CATEGORYNAME"].ToString();
            SetLabel(e.Item, "lblcategory", category);
            if (dr.Table.Columns.Contains(category.ToUpper()))
                SetLabel(e.Item, "lblpercentage", dr[category.ToUpper()].ToString());

            bool isTidea = dr["SCHEMETYPE"].ToString() == "T-IDEA";
            SetControlVisibility(e.Item, "trcapitaleligibleinvestment", isTidea);
            SetControlVisibility(e.Item, "trsalestaxsanctionedonthisclaim", isTidea);
            if (isTidea)
            {
                SetLabel(e.Item, "lblcapitalelginvestment", dr["TOTALCAPITALELIGIBLEINVESTMENT"].ToString());
                SetLabel(e.Item, "lblsalestaxsanctioned", dr["TOTALSALESTAXSANCTIONEDONTHISCLAIM"].ToString());
            }

            SetLabel(e.Item, "lbleligibleamount", dr["FINALSUBSIDYAMOUNT"].ToString());
            SetLabel(e.Item, "lbltypeofclaim", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_salestax", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "16") // Land Conversion
        {
            SetControlVisibility(e.Item, "divLandconversion", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Land Conversion");
            SetLabel(e.Item, "lblLConLandMeasure", dr["landmeasuring"].ToString());
            SetLabel(e.Item, "LblLconPurchaseValue", dr["purchasevalue"].ToString());
            SetLabel(e.Item, "lblLconBuildingPlnth", dr["buildingplntharea"].ToString());
            SetLabel(e.Item, "lblfietimesplintharea", dr["buildingplnthareaFveTimes"].ToString());
            SetLabel(e.Item, "lblLconProportionate", dr["proportionatevalue"].ToString());
            SetLabel(e.Item, "lblLconLandValueComputed", dr["landvaluecomputed"].ToString());
            SetLabel(e.Item, "lblLconTwntyFveComputed", dr["twntyfveComputed"].ToString());
            SetLabel(e.Item, "lblLConEligibleLandConversion", dr["Finaleligibleamount"].ToString());
            SetLabel(e.Item, "lblLconValueGMRecom", dr["valuerecndgm"].ToString());
            SetLabel(e.Item, "lblLconClaimType", dr["applicantType"].ToString());
            SetLabel(e.Item, "LBLREMARKS_LANDCONVERSION", dr["mortgageRemarks"].ToString());
        }
        else if (masterIncentiveId == "15") // Mortgage
        {
            SetControlVisibility(e.Item, "divmortgage", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Mortgage");
            SetLabel(e.Item, "lblMortFinancialIns", dr["FinInstitution"].ToString());
            SetLabel(e.Item, "lblMortTermLoan", dr["TermLoanSancctioned"].ToString());
            SetLabel(e.Item, "lblMortMortgageDutyPaid", dr["MortgagePaid"].ToString());
            SetLabel(e.Item, "lblMortTermloanAvailed", dr["TermLoanAvailed"].ToString());
            SetLabel(e.Item, "lblMortProportionateMortgage", dr["PropMortgageDuty"].ToString());
            SetLabel(e.Item, "lblMortMortgageDuty", dr["Mortgage_gM"].ToString());
            SetLabel(e.Item, "lblMortElgibleReimbursement", dr["FINAL_Mortgage_Reimbursement"].ToString());
            SetLabel(e.Item, "lblMortTypeofClaim", dr["applicantType"].ToString());
            SetLabel(e.Item, "lblremarks_mortegage", dr["mortgageRemarks"].ToString());
        }
        else if (masterIncentiveId == "14") // Stamp Duty
        {
            SetControlVisibility(e.Item, "divStampduty", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Stamp Duty/Transfer Duty");
            SetLabel(e.Item, "lblSDBuildingplnthfvTimes", dr["StampBuildingPlinth"].ToString());
            SetLabel(e.Item, "lblSDBuildingPlinth", dr["BuildingPlinth"].ToString());
            SetLabel(e.Item, "lblSDLandmeasuring", dr["LandSqmt"].ToString());
            SetLabel(e.Item, "lblSDStampduty", dr["StampDuty"].ToString());
            SetLabel(e.Item, "lblSDProportionateVAlue", dr["Proportionatearea"].ToString());
            SetLabel(e.Item, "lblSDValueRecomndGM", dr["GMValue"].ToString());
            SetLabel(e.Item, "lblSDValueComputed", dr["FINALELIGIBLEAMOUNT"].ToString());
            SetLabel(e.Item, "LBLTYPEOFCLAIM_STAMPDUTY", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_stampduty", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "17") // Land Cost
        {
            SetControlVisibility(e.Item, "divlandcost", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Land Cost");
            SetLabel(e.Item, "lblLcLandPurchase", dr["LANDPURCHASE"].ToString());
            SetLabel(e.Item, "lblLCLandvalue", dr["LANDVALUE"].ToString());
            SetLabel(e.Item, "lblLCPlnthArea", dr["BuildingPlinth"].ToString());
            SetLabel(e.Item, "lblLCfiveTimes", dr["TotalBuildingPlinth_CALCULATED"].ToString());
            SetLabel(e.Item, "lblLCProportionate", dr["Proportionatearea"].ToString());
            SetLabel(e.Item, "lblLCValueRecmGM", dr["GMValue"].ToString());
            SetLabel(e.Item, "lblLCEligibleLandCost", dr["FINALELIGIBLELANDCOST"].ToString());
            SetLabel(e.Item, "lbltypeofclainlandcost", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_landcost", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "11") // Quality Certification
        {
            SetControlVisibility(e.Item, "DIVQUALITYCERTIFICATION", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Quality Certification");
            SetLabel(e.Item, "lblqualitycertificationcgargespaid", dr["QUALITYCERTIFICATIONCHARESPAID"].ToString());
            SetLabel(e.Item, "lblfiftypercentage", dr["FIFTYPEROFCHARGESPAID"].ToString());
            SetLabel(e.Item, "lblgmrecomamount", dr["GMValue"].ToString());
            SetLabel(e.Item, "lbllesselegibleamount", dr["ELEGIBLEWHICHEVERLESS"].ToString());
            SetLabel(e.Item, "lbltypeofclaim_quality", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_qualitycertification", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "4") // Cleaner Production
        {
            SetControlVisibility(e.Item, "divspecificcleaner", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Specific Cleaner Production measures");
            SetLabel(e.Item, "lblExpenditure", dr["ExpenditureIncurred"].ToString());
            SetLabel(e.Item, "lblExpenditure25", dr["ExpenditureIncurred_25prcnt"].ToString());
            SetLabel(e.Item, "lblgmspecific", dr["GMValue"].ToString());
            SetLabel(e.Item, "lvlfinalpecific", dr["FINALELIGIBLESPECIFICCLEANER"].ToString());
        }
        else if (masterIncentiveId == "8") // Skill Upgradation
        {
            SetControlVisibility(e.Item, "DIVSKILLUPGRADE", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of cost involved in skill upgradation and training");
            SetLabel(e.Item, "lblskillupchargespaid", dr["SKILLUPGRADECHARESPAID"].ToString());
            SetLabel(e.Item, "lbl50perskillupchargespaid", dr["FIFTYPEROFCHARGESPAID"].ToString());
            SetLabel(e.Item, "lblgmrecomamount_skillupgrade", dr["GMValue"].ToString());
            SetLabel(e.Item, "lblelegamountless_skillupgrade", dr["ELEGIBLEWHICHEVERLESS"].ToString());
            SetLabel(e.Item, "lbltypeofclaim_skillupgrade", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_skillupgrade", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "7") // IIDF
        {
            SetControlVisibility(e.Item, "DIVIIDF", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Industrial Infrastructure Development Fund(IIDF)");
            SetLabel(e.Item, "lbliidfchargespaid", dr["IIDFCHARESPAID"].ToString());
            SetLabel(e.Item, "lbl50perofiidf", dr["FIFTYPEROFCHARGESPAID"].ToString());
            SetLabel(e.Item, "lbl15perofcompcost", dr["FIFTEENPEROFCHARGESPAID"].ToString());
            SetLabel(e.Item, "lblgmrecomamount_iidf", dr["GMValue"].ToString());
            SetLabel(e.Item, "lblelegamountless_iidf", dr["ELEGIBLEWHICHEVERLESS"].ToString());
            SetLabel(e.Item, "lbltypeofclaim_iidf", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblremarks_iidf", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "18") // Coal
        {
            SetControlVisibility(e.Item, "divcoal", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Coal");
            SetLabel(e.Item, "lblcoalquantity", dr["COALQUANTITY"].ToString());
            SetLabel(e.Item, "lbleligibleamount_coal", dr["ELIGIBLEAMOUNT"].ToString());
            SetLabel(e.Item, "lblgmrecommendedvalue_coal", dr["GMVALUE"].ToString());
            SetLabel(e.Item, "lblfinalsubsidyamount_coal", dr["FINALSUBSIDYAMOUNT"].ToString());
            SetLabel(e.Item, "lblremark_coal", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "19") // Wood
        {
            SetControlVisibility(e.Item, "DIVWOOD", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Reimbursement of Wood");
            SetLabel(e.Item, "LBLQUANTITY_WOOD", dr["WOODQUANTITY"].ToString());
            SetLabel(e.Item, "LBLELIGIBLEAMOUNT_WOOD", dr["ELIGIBLEAMOUNT"].ToString());
            SetLabel(e.Item, "LBLGMRECOMMENDEDVALUE_WOOD", dr["GMVALUE"].ToString());
            SetLabel(e.Item, "LBLFINALSUBSIDYAMOUNT_WOOD", dr["FINALSUBSIDYAMOUNT"].ToString());
            SetLabel(e.Item, "LBLREMARKS_WOOD", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "20") // Transport Duty
        {
            SetControlVisibility(e.Item, "DIVTRANSPORTDUTY", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Reimbursement of Transport Duty");
            SetLabel(e.Item, "lblmonth1", dr["month1"].ToString());
            SetLabel(e.Item, "lblfinyear1", dr["month1_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed1", dr["month1amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount1", dr["month1eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lblmonth2", dr["month2"].ToString());
            SetLabel(e.Item, "lblfinyear2", dr["month2_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed2", dr["month2amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount2", dr["month2eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lblmonth3", dr["month3"].ToString());
            SetLabel(e.Item, "lblfinyear3", dr["month3_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed3", dr["month3amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount3", dr["month3eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lblmonth4", dr["month4"].ToString());
            SetLabel(e.Item, "lblfinyear4", dr["month4_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed4", dr["month4amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount4", dr["month4eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lblmonth5", dr["month5"].ToString());
            SetLabel(e.Item, "lblfinyear5", dr["month5_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed5", dr["month5amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount5", dr["month5eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lblmonth6", dr["month6"].ToString());
            SetLabel(e.Item, "lblfinyear6", dr["month6_year"].ToString());
            SetLabel(e.Item, "lblunitsconsumed6", dr["month6amountpaid"].ToString());
            SetLabel(e.Item, "lblelegamount6", dr["month6eligiblesubsidy"].ToString());

            SetLabel(e.Item, "lbltotalmaount", dr["ELIGIBLEAMOUNT"].ToString());
            SetLabel(e.Item, "lbltype", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lblGMreconamount", dr["GMVALUE"].ToString());
            SetLabel(e.Item, "lblfinanelgamount", dr["FINALSUBSIDYAMOUNT"].ToString());
            SetLabel(e.Item, "lblremarks_TRDUTY", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "22") // Capital Subsidy
        {
            SetControlVisibility(e.Item, "DIVCAPITALSUBSIDY", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Reimbursement of CAPITAL SUBSIDY");
            SetLabel(e.Item, "lblinvestment_CS", dr["INVESTMENT"].ToString());
            SetLabel(e.Item, "lblelegibletype_CS", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "lbltenperinvestment_CS", dr["TENPEROFINVESTMENT"].ToString());
            SetLabel(e.Item, "lblfinalsubsidyamount_CS", dr["FINALELIGIBLECAPITALSUBSIDY"].ToString());
            SetLabel(e.Item, "LBLREMARKS_CS", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "21") // APMC
        {
            SetControlVisibility(e.Item, "DIVAPMC", true);
            SetLabel(e.Item, "lblSancIncentiveName", "Reimbursement of APMC");
            SetLabel(e.Item, "LBLAPMCFEEPAIDYEAR", dr["APMCYEAR"].ToString());
            SetLabel(e.Item, "LBLAPMCFEEPAID", dr["APMCAmountPaid"].ToString());
            SetLabel(e.Item, "LBLFIRSTORSECONDHALFYEAR_APMC", dr["FIRSTORSECONDHALFYEAR"].ToString());
            SetLabel(e.Item, "LBLELIGIBLETYPE_APMC", dr["ELIGIBLETYPE"].ToString());
            SetLabel(e.Item, "LBLELIGIBLEAMOUNT_APMC", dr["EligibleAmount"].ToString());
            SetLabel(e.Item, "LBLGMRECOMMENDEDAMOUNT_APMC", dr["GMValue"].ToString());
            SetLabel(e.Item, "LBLFINALSUBSIDYAMOUNT_APMC", dr["FINALELIGIBLEAMOUNT"].ToString());
            SetLabel(e.Item, "LBLREMARKS_APMC", dr["Remarks"].ToString());
        }
        else if (masterIncentiveId == "3") // Power Cost
        {
            SetLabel(e.Item, "lblSancIncentiveName", "Sanction of Reimbursement of Power Cost");
            SetControlVisibility(e.Item, "Div1", true);
            SetLabel(e.Item, "lblamount", dr["finalsubsidyamount_systemcalculated"].ToString());

            string industryStatus = dr["IdsustryStatus"].ToString();
            string bothOrNot = dr["bothOrnot"].ToString();

            if (industryStatus == "New")
            {
                SetControlVisibility(e.Item, "tblNewUnit", true);
                SetControlVisibility(e.Item, "tbl_monthyeardataExpansion", false);

                SetLabel(e.Item, "txt_grdmonthyear1New", dr["finyear1_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear2New", dr["finyear2_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear3New", dr["finyear3_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear4New", dr["finyear4_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear5New", dr["finyear5_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear6New", dr["finyear6_new"].ToString());

                SetLabel(e.Item, "txt_grdmonthyear1NewFinyear", dr["finyearMonth1_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear2NewFinyear", dr["finyearMonth2_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear3NewFinyear", dr["finyearMonth3_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear4NewFinyear", dr["finyearMonth4_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear5NewFinyear", dr["finyearMonth5_new"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear6NewFinyear", dr["finyearMonth6_new"].ToString());

                SetLabel(e.Item, "TextBox23", dr["unitsconsumedMonth1_new"].ToString());
                SetLabel(e.Item, "TextBox50", dr["unitsconsumedMonth2_new"].ToString());
                SetLabel(e.Item, "TextBox63", dr["unitsconsumedMonth3_new"].ToString());
                SetLabel(e.Item, "TextBox71", dr["unitsconsumedMonth4_new"].ToString());
                SetLabel(e.Item, "TextBox79", dr["unitsconsumedMonth5_new"].ToString());
                SetLabel(e.Item, "TextBox87", dr["unitsconsumedMonth6_new"].ToString());

                SetLabel(e.Item, "TextBox24", dr["rateperunitsMonth1_new"].ToString());
                SetLabel(e.Item, "TextBox51", dr["rateperunitsMonth2_new"].ToString());
                SetLabel(e.Item, "TextBox64", dr["rateperunitsMonth3_new"].ToString());
                SetLabel(e.Item, "TextBox72", dr["rateperunitsMonth4_new"].ToString());
                SetLabel(e.Item, "TextBox80", dr["rateperunitsMonth5_new"].ToString());
                SetLabel(e.Item, "TextBox88", dr["rateperunitsMonth6_new"].ToString());

                SetLabel(e.Item, "TextBox25", dr["amountPaidMonth1_new"].ToString());
                SetLabel(e.Item, "TextBox52", dr["amountPaidMonth2_new"].ToString());
                SetLabel(e.Item, "TextBox65", dr["amountPaidMonth3_new"].ToString());
                SetLabel(e.Item, "TextBox73", dr["amountPaidMonth4_new"].ToString());
                SetLabel(e.Item, "TextBox81", dr["amountPaidMonth5_new"].ToString());
                SetLabel(e.Item, "TextBox89", dr["amountPaidMonth6_new"].ToString());

                SetLabel(e.Item, "TextBox21", dr["eligiblerateunitMonth1_new"].ToString());
                SetLabel(e.Item, "TextBox22", dr["eligiblerateunitMonth2_new"].ToString());
                SetLabel(e.Item, "TextBox26", dr["eligiblerateunitMonth3_new"].ToString());
                SetLabel(e.Item, "TextBox27", dr["eligiblerateunitMonth4_new"].ToString());
                SetLabel(e.Item, "TextBox95", dr["eligiblerateunitMonth5_new"].ToString());
                SetLabel(e.Item, "TextBox96", dr["eligiblerateunitMonth6_new"].ToString());

                SetLabel(e.Item, "TextBox28", dr["eligiblerateamountMonth1_new"].ToString());
                SetLabel(e.Item, "TextBox29", dr["eligiblerateamountMonth2_new"].ToString());
                SetLabel(e.Item, "TextBox49", dr["eligiblerateamountMonth3_new"].ToString());
                SetLabel(e.Item, "TextBox53", dr["eligiblerateamountMonth4_new"].ToString());
                SetLabel(e.Item, "TextBox54", dr["eligiblerateamountMonth5_new"].ToString());
                SetLabel(e.Item, "TextBox55", dr["eligiblerateamountMonth6_new"].ToString());

                SetLabel(e.Item, "lblGmAmount0", dr["totaleligibleamount_new"].ToString());
                SetLabel(e.Item, "lblTotalEligibleAm0", dr["isbelated_new"].ToString());
                SetLabel(e.Item, "lblTotalEligibleAm", dr["totaleligible_fin"].ToString());
                SetLabel(e.Item, "lblGmAmount", dr["GM_Rcon_Amount"].ToString());
                SetLabel(e.Item, "lblremarks_powernew", dr["Remarks"].ToString());

                if (bothOrNot == "Y")
                {
                    SetControlVisibility(e.Item, "tblNewUnitBoth", true);
                    SetLabel(e.Item, "txt_grdmonthyear1NewBoth", dr["finyear1Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear2NewBoth", dr["finyear2Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear3NewBoth", dr["finyear3Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear4NewBoth", dr["finyear4Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear5NewBoth", dr["finyear5Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear6NewBoth", dr["finyear6Both_new"].ToString());

                    SetLabel(e.Item, "txt_grdmonthyear1NewFinyearBoth", dr["finyearMonth1Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear2NewFinyearBoth", dr["finyearMonth2Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear3NewFinyearBoth", dr["finyearMonth3Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear4NewFinyearBoth", dr["finyearMonth4Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear5NewFinyearBoth", dr["finyearMonth5Both_new"].ToString());
                    SetLabel(e.Item, "txt_grdmonthyear6NewFinyearBoth", dr["finyearMonth6Both_new"].ToString());

                    SetLabel(e.Item, "TextBox23Both", dr["unitsconsumedMonth1Both_new"].ToString());
                    SetLabel(e.Item, "TextBox50Both", dr["unitsconsumedMonth2Both_new"].ToString());
                    SetLabel(e.Item, "TextBox63Both", dr["unitsconsumedMonth3Both_new"].ToString());
                    SetLabel(e.Item, "TextBox71Both", dr["unitsconsumedMonth4Both_new"].ToString());
                    SetLabel(e.Item, "TextBox79Both", dr["unitsconsumedMonth5Both_new"].ToString());
                    SetLabel(e.Item, "TextBox87Both", dr["unitsconsumedMonth6Both_new"].ToString());

                    SetLabel(e.Item, "TextBox24Both", dr["rateperunitsMonth1Both_new"].ToString());
                    SetLabel(e.Item, "TextBox51Both", dr["rateperunitsMonth2Both_new"].ToString());
                    SetLabel(e.Item, "TextBox64Both", dr["rateperunitsMonth3Both_new"].ToString());
                    SetLabel(e.Item, "TextBox72Both", dr["rateperunitsMonth4Both_new"].ToString());
                    SetLabel(e.Item, "TextBox80Both", dr["rateperunitsMonth5Both_new"].ToString());
                    SetLabel(e.Item, "TextBox88Both", dr["rateperunitsMonth6Both_new"].ToString());

                    SetLabel(e.Item, "TextBox25Both", dr["amountPaidMonth1Both_new"].ToString());
                    SetLabel(e.Item, "TextBox52Both", dr["amountPaidMonth2Both_new"].ToString());
                    SetLabel(e.Item, "TextBox65Both", dr["amountPaidMonth3Both_new"].ToString());
                    SetLabel(e.Item, "TextBox73Both", dr["amountPaidMonth4Both_new"].ToString());
                    SetLabel(e.Item, "TextBox81Both", dr["amountPaidMonth5Both_new"].ToString());
                    SetLabel(e.Item, "TextBox89Both", dr["amountPaidMonth6Both_new"].ToString());

                    SetLabel(e.Item, "TextBox21Both", dr["eligiblerateunitMonth1Both_new"].ToString());
                    SetLabel(e.Item, "TextBox22Both", dr["eligiblerateunitMonth2Both_new"].ToString());
                    SetLabel(e.Item, "TextBox26Both", dr["eligiblerateunitMonth3Both_new"].ToString());
                    SetLabel(e.Item, "TextBox27Both", dr["eligiblerateunitMonth4Both_new"].ToString());
                    SetLabel(e.Item, "TextBox95Both", dr["eligiblerateunitMonth5Both_new"].ToString());
                    SetLabel(e.Item, "TextBox96Both", dr["eligiblerateunitMonth6Both_new"].ToString());

                    SetLabel(e.Item, "TextBox28Both", dr["eligiblerateamountMonth1Both_new"].ToString());
                    SetLabel(e.Item, "TextBox29Both", dr["eligiblerateamountMonth2Both_new"].ToString());
                    SetLabel(e.Item, "TextBox49Both", dr["eligiblerateamountMonth3Both_new"].ToString());
                    SetLabel(e.Item, "TextBox53Both", dr["eligiblerateamountMonth4Both_new"].ToString());
                    SetLabel(e.Item, "TextBox54Both", dr["eligiblerateamountMonth5Both_new"].ToString());
                    SetLabel(e.Item, "TextBox55Both", dr["eligiblerateamountMonth6Both_new"].ToString());

                    SetLabel(e.Item, "lblGmAmount0Both", dr["totaleligibleamountBoth_new"].ToString());
                    SetLabel(e.Item, "lblTotalEligibleAm0Both", dr["isbelatedBoth_new"].ToString() == "Y" ? "Regular" : "Belated");
                    SetLabel(e.Item, "lblTotalEligibleAmBoth", dr["totaleligibleamountBoth_new"].ToString());
                    SetLabel(e.Item, "lblGmAmountBoth", dr["GM_Rcon_Amount"].ToString());
                    SetLabel(e.Item, "lblremarks_powernewBoth", dr["Remarks"].ToString());
                }
            }
            else if (industryStatus == "Expansion" || industryStatus == "Diversification")
            {
                SetControlVisibility(e.Item, "tbl_monthyeardataExpansion", true);
                SetControlVisibility(e.Item, "tblNewUnit", false);

                SetLabel(e.Item, "txt_grdmonthyear1", dr["finyear1_expn"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear2", dr["finyear2_expn"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear3", dr["finyear3_expn"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear4", dr["finyear4_expn"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear5", dr["finyear5_expn"].ToString());
                SetLabel(e.Item, "txt_grdmonthyear6", dr["finyear6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1unitsconsumed", dr["finyearMonth1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2unitsconsumed", dr["finyearMonth2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3unitsconsumed", dr["finyearMonth3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4unitsconsumed", dr["finyearMonth4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5unitsconsumed", dr["finyearMonth5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6unitsconsumed", dr["finyearMonth6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1rateperunit", dr["unitsconsumedMonth1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2rateperunit", dr["unitsconsumedMonth2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3rateperunit", dr["unitsconsumedMonth3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4rateperunit", dr["unitsconsumedMonth4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5rateperunit", dr["unitsconsumedMonth5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6rateperunit", dr["unitsconsumedMonth6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1amountpaid", dr["rateperunitsMonth1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2amountpaid", dr["rateperunitsMonth2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3amountpaid", dr["rateperunitsMonth3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4amountpaid", dr["rateperunitsMonth4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5amountpaid", dr["rateperunitsMonth5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6amountpaid", dr["rateperunitsMonth6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1basefixedunitspermonth", dr["amountPaidMonth1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2basefixedunitspermonth", dr["amountPaidMonth2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3basefixedunitspermonth", dr["amountPaidMonth3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4basefixedunitspermonth", dr["amountPaidMonth4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5basefixedunitspermonth", dr["amountPaidMonth5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6basefixedunitspermonth", dr["amountPaidMonth6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1eligibleunits", dr["basefixedpermonth1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2eligibleunits", dr["basefixedpermonth2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3eligibleunits", dr["basefixedpermonth3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4eligibleunits", dr["basefixedpermonth4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5eligibleunits", dr["basefixedpermonth5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6eligibleunits", dr["basefixedpermonth6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1eligiblerateofreimbursement", dr["eligibleunitsover1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2eligiblerateofreimbursement", dr["eligibleunitsover2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3eligiblerateofreimbursement", dr["eligibleunitsover3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4eligiblerateofreimbursement", dr["eligibleunitsover4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5eligiblerateofreimbursement", dr["eligibleunitsover5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6eligiblerateofreimbursement", dr["eligibleunitsover6_expn"].ToString());

                SetLabel(e.Item, "txt_grdyear1eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits1_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear2eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits2_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear3eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits3_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear4eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits4_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear5eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits5_expn"].ToString());
                SetLabel(e.Item, "txt_grdyear6eligibleamountforreimbursement", dr["eligiblerateforreimbursementperunits6_expn"].ToString());

                SetLabel(e.Item, "TextBox75", dr["eligibleamountforreimbursementperunits1_expn"].ToString());
                SetLabel(e.Item, "TextBox76", dr["eligibleamountforreimbursementperunits2_expn"].ToString());
                SetLabel(e.Item, "TextBox77", dr["eligibleamountforreimbursementperunits3_expn"].ToString());
                SetLabel(e.Item, "TextBox78", dr["eligibleamountforreimbursementperunits4_expn"].ToString());
                SetLabel(e.Item, "TextBox82", dr["eligibleamountforreimbursementperunits5_expn"].ToString());
                SetLabel(e.Item, "TextBox83", dr["eligibleamountforreimbursementperunits6_expn"].ToString());

                SetLabel(e.Item, "Label1", dr["totaleligibleamount_expn"].ToString());
                SetLabel(e.Item, "Label2", dr["isbelated_expn"].ToString());
                SetLabel(e.Item, "Label3", dr["totaleligibleamount_expn_belated"].ToString());
                SetLabel(e.Item, "Label4", dr["GM_Rcon_Amount"].ToString());
                SetLabel(e.Item, "lblremarks_monthyearexp", dr["Remarks"].ToString());

                if (bothOrNot == "Y")
                {
                    SetControlVisibility(e.Item, "tbl_monthyeardataExpansionBoth", true);
                    SetLabel(e.Item, "Label117", dr["finyearMonthBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label126", dr["finyearMonthBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label135", dr["finyearMonthBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label144", dr["finyearMonthBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label153", dr["finyearMonthBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label162", dr["finyearMonthBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label118", dr["finyearBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label127", dr["finyearBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label136", dr["finyearBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label145", dr["finyearBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label154", dr["finyearBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label163", dr["finyearBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label119", dr["unitsconsumedMonthBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label128", dr["unitsconsumedMonthBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label137", dr["unitsconsumedMonthBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label146", dr["unitsconsumedMonthBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label155", dr["unitsconsumedMonthBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label164", dr["unitsconsumedMonthBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label120", dr["rateperunitsMonthBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label129", dr["rateperunitsMonthBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label138", dr["rateperunitsMonthBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label147", dr["rateperunitsMonthBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label156", dr["rateperunitsMonthBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label165", dr["rateperunitsMonthBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label121", dr["amountPaidMonthBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label130", dr["amountPaidMonthBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label139", dr["amountPaidMonthBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label148", dr["amountPaidMonthBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label157", dr["amountPaidMonthBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label166", dr["amountPaidMonthBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label122", dr["basefixedpermonthBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label131", dr["basefixedpermonthBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label140", dr["basefixedpermonthBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label149", dr["basefixedpermonthBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label158", dr["basefixedpermonthBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label167", dr["basefixedpermonthBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label123", dr["eligibleunitsoverBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label132", dr["eligibleunitsoverBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label141", dr["eligibleunitsoverBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label150", dr["eligibleunitsoverBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label159", dr["eligibleunitsoverBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label168", dr["eligibleunitsoverBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label124", dr["eligiblerateforreimbursementperunitsBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label133", dr["eligiblerateforreimbursementperunitsBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label142", dr["eligiblerateforreimbursementperunitsBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label151", dr["eligiblerateforreimbursementperunitsBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label160", dr["eligiblerateforreimbursementperunitsBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label169", dr["eligiblerateforreimbursementperunitsBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label125", dr["eligibleamountforreimbursementperunitsBoth1_expn"].ToString());
                    SetLabel(e.Item, "Label134", dr["eligibleamountforreimbursementperunitsBoth2_expn"].ToString());
                    SetLabel(e.Item, "Label143", dr["eligibleamountforreimbursementperunitsBoth3_expn"].ToString());
                    SetLabel(e.Item, "Label152", dr["eligibleamountforreimbursementperunitsBoth4_expn"].ToString());
                    SetLabel(e.Item, "Label161", dr["eligibleamountforreimbursementperunitsBoth5_expn"].ToString());
                    SetLabel(e.Item, "Label170", dr["eligibleamountforreimbursementperunitsBoth6_expn"].ToString());

                    SetLabel(e.Item, "Label171", dr["totaleligibleamountBoth_expn"].ToString());
                    SetLabel(e.Item, "Label172", dr["isbelatedBoth_expn"].ToString() == "Y" ? "Regular" : "Belated");
                    SetLabel(e.Item, "Label173", dr["ifbelatedthentotalamountBoth_expn"].ToString());
                    SetLabel(e.Item, "Label174", dr["GM_Rcon_Amount"].ToString());
                    SetLabel(e.Item, "Label175", dr["Remarks"].ToString());
                }
            }
        }
    }

    // ==========================================
    // 4. PAVALA VADDI BINDING (FULL GRIDS)
    // ==========================================
    private void BindPavalaVaddi(RepeaterItem item, string incentiveId)
    {
        DataSet dsPv = DB_apprasialnote2pallavaddi(incentiveId, "");
        if (dsPv == null || dsPv.Tables.Count == 0 || dsPv.Tables[0].Rows.Count == 0) return;

        DataRow drPv = dsPv.Tables[0].Rows[0];
        SetLabel(item, "txt_Insertamounttobepaidaspercalculations", drPv["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"].ToString());
        SetLabel(item, "txt_Actualinterestamountpaid", drPv["ACTUALINTERESTAMOUNT_PAID"].ToString());
        SetLabel(item, "txt_ConsideredAmountofInterest", drPv["Conreburismentamount"].ToString());
        SetLabel(item, "txt_Insertreimbursementcalculated", drPv["INTERESTREIMBURSEMENTCALCULATED_FINAL"].ToString());
        SetLabel(item, "txt_GMrecommendedamount", drPv["GMRECOMMENDEDAMOUNT"].ToString());
        SetLabel(item, "txt_Eligibleamount", drPv["FINALELIGIBLEAMOUNT"].ToString());
        SetLabel(item, "txt_eglibleamountofreimbursementbyeglibletype", drPv["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"].ToString());
        SetLabel(item, "lbl_pavallavaddiremarksbyclerk", drPv["Remarks"].ToString());

        // Bind Table 3: Summary of loans applied
        GridView grdLoan = (GridView)item.FindControl("grd_claimperiodofloanadd");
        if (grdLoan != null)
        {
            grdLoan.Visible = false;
            if (dsPv.Tables.Count >= 4 && dsPv.Tables[3].Rows.Count > 0)
            {
                grdLoan.DataSource = dsPv.Tables[3];
                grdLoan.DataBind();
                grdLoan.Visible = true;
            }
        }

        // Bind Table 4: Detailed Loan & 6-Month calculation breakdown
        GridView grdEligiblePV = (GridView)item.FindControl("grd_eglibilepallavaddi");
        if (grdEligiblePV != null)
        {
            grdEligiblePV.Visible = false;
            if (dsPv.Tables.Count >= 5 && dsPv.Tables[4].Rows.Count > 0)
            {
                grdEligiblePV.DataSource = dsPv.Tables[4];
                grdEligiblePV.DataBind();
                grdEligiblePV.Visible = true;
            }
        }
    }

    public DataSet DB_apprasialnote2pallavaddi(string incentiveId, string claimPeriodGrid)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand("pv_apprasialnote2pallavaddi", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(incentiveId) ? (object)DBNull.Value : incentiveId;
                cmd.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = string.IsNullOrWhiteSpace(claimPeriodGrid) ? (object)DBNull.Value : claimPeriodGrid;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }

    private void HideAllSchemePanels(RepeaterItem item)
    {
        string[] panelIds = {
            "Div3", "divLandconversion", "divmortgage", "divlandcost",
            "divStampduty", "DIVQUALITYCERTIFICATION", "DIVSALESTAX",
            "div_pallavaddi", "divcoal", "DIVWOOD", "DIVCAPITALSUBSIDY",
            "DIVAPMC", "DIVTRANSPORTDUTY", "divspecificcleaner",
            "DIVSKILLUPGRADE", "DIVIIDF", "tblNewUnit", "tblNewUnitBoth",
            "tbl_monthyeardataExpansion", "tbl_monthyeardataExpansionBoth", "Div1"
        };
        foreach (string id in panelIds)
        {
            SetControlVisibility(item, id, false);
        }
    }

    private void SetControlVisibility(RepeaterItem item, string controlId, bool visible)
    {
        Control c = item.FindControl(controlId);
        if (c != null) c.Visible = visible;
    }

    private void SetLabel(RepeaterItem item, string labelId, string text)
    {
        Label lbl = item.FindControl(labelId) as Label;
        if (lbl != null) lbl.Text = text;
    }

    private decimal ToDecimalSafe(object val)
    {
        if (val == null || val == DBNull.Value) return 0m;
        decimal res;
        return decimal.TryParse(val.ToString(), out res) ? res : 0m;
    }
    public DataSet getProposedSVClistconvened()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_SVCABSTRACT_convened_Dates_BULKPRINT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

}