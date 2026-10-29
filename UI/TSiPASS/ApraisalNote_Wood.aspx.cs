using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class UI_TSiPASS_ApraisalNote_Wood : System.Web.UI.Page
{
    General Gen = new General();
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTable1;
    static DataTable dtMyTable;
    string casteGenderGmUpdate = "";
    DataTable myDtNewRecdr = new DataTable();
    public string incentiveid;
    public string mstincentiveid;
    IncentiveVosAppraisalStamp oIncentiveVosA = new IncentiveVosAppraisalStamp();
    DB.DB con = new DB.DB();
    List<officerRemarks> lstremarksad = new List<officerRemarks>();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    List<officerRemarks> lstremarksamount = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    string FINALCAPITALINVESTMENT = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                // txtgmRecommend.Text = "123";
                // txtINCNoEntry.Text = "112528";
                // btnINCSearch_Click(sender, e);
                if (Request.QueryString[0].ToString() != "")
                {
                    txtINCNoEntry.Text = Request.QueryString[0].ToString();
                    // txtINCNoEntry.Text = "44803";
                    // oIncentiveVosA.MstIncentiveId = "16";
                    btnINCSearch_Click(sender, e);
                    getCasteDetails();
                }
            }

        }
    }
    public void getCasteDetails()
    {
        string incentiveID = "";
        if (Request.QueryString[0] != null)
        {
            incentiveID = Request.QueryString[0].ToString().ToString();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("[FETCHINC_DETAILS_ID]", con.GetConnection);
            da = new SqlDataAdapter("[USP_GET_DATA_INSPECTIONREPORT_APPRAISAL]", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (incentiveID.ToString() != "" || incentiveID.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@IncentveID", SqlDbType.VarChar).Value = incentiveID;
                da.SelectCommand.Parameters.Add("@MSTINCENTVEID", SqlDbType.VarChar).Value = "6";
            }

            da.Fill(ds);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                rdbCaste.SelectedValue = ds.Tables[0].Rows[0]["caste_IR"].ToString();
                rdbCaste.Enabled = true;

                rdbGender.SelectedValue = ds.Tables[0].Rows[0]["gender_IR"].ToString();
                rdbGender.Enabled = true;

                rdbCategory.SelectedValue = ds.Tables[0].Rows[0]["category_IR"].ToString();
                rdbCategory.Enabled = true;

                rdbEnterprise.SelectedValue = ds.Tables[0].Rows[0]["enterprise_IR"].ToString();
                rdbEnterprise.Enabled = true;

                rdbSector.SelectedValue = ds.Tables[0].Rows[0]["sector_IR"].ToString();
                rdbSector.Enabled = true;

                rdbServiceType.SelectedValue = ds.Tables[0].Rows[0]["serviceType_IR"].ToString();
                rdbServiceType.Enabled = true;


                rdbSector_SelectedIndexChanged(this.rdbSector, new EventArgs());


                if (rdbSector.SelectedIndex == 0)
                {
                    rdbSector.Enabled = true;
                    rdbTransportNonTrans.Enabled = true;
                    trTransNonTrans.Visible = true;
                    rdbTransportNonTrans.Visible = true;
                    rdbTransportNonTrans.SelectedValue = ds.Tables[0].Rows[0]["transportNonTrans_IR"].ToString();
                    rdbTransportNonTrans.Enabled = true;

                    rdbTransportNonTrans.Enabled = true;
                    trTransNonTrans.Visible = true;
                    rdbTransportNonTrans.Enabled = true;

                    rdbTransportNonTrans_SelectedIndexChanged(this.rdbTransportNonTrans, new EventArgs());

                }




            }





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
    void getUdyogAadharType1()
    {
        DataSet ds = new DataSet();
        ds = getUdyogAadharType();

        ddlUdyogAadharType.DataSource = ds.Tables[0];
        ddlUdyogAadharType.DataTextField = "Name";
        ddlUdyogAadharType.DataValueField = "Slno";
        ddlUdyogAadharType.DataBind();
        AddSelect(ddlUdyogAadharType);
        // ddlUdyogAadharType.Items.Insert(0, "-- Select Udyog Aadhar/EM/IEM/IL/EOU No --");
    }
    void calleventforbackup(string incentiveid)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();

        SqlDataAdapter da;
        DataSet ds = new DataSet();

        da = new SqlDataAdapter("calleventforbackup", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = Session["incentiveid"].ToString();
        da.Fill(ds);


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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public DataSet getUdyogAadharType()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_UDYOG_AADHAAR_TYPE", con);
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
            con.Close();
        }
    }
    public void USP_GETDETAILSFORSECTION()
    {
        string IncentiveId = txtINCNoEntry.Text.ToString();

        string MasterIncentiveId = "19";
        SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        osqlConnection.Open();
        SqlDataAdapter da;
      //  da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_appeal_TESTFORWOOD", osqlConnection);
        da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_appeal_WOOD", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
        da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
        da.Fill(ds);

        getLOAData(IncentiveId);

        if (ds.Tables[0].Rows.Count > 0)
        {

            //ds.Tables[0].Rows[0]["lblTideaTpride"].ToString();
            if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
            {
                tprideTr.Visible = true;
                tideaTr.Visible = false;
            }
            else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
            {
                tprideTr.Visible = false;
                tideaTr.Visible = true;
            }
            if (ds.Tables[0].Rows[0]["MSME_Applied"].ToString() == "Y")
            {
                tprideTr.Visible = false;
                tideaTr.Visible = false;
                TRMSME.Visible = true;
            }

            lblApplicationno.Text = ds.Tables[0].Rows[0]["incApplnNo"].ToString();
            txtunitnames.Text = ds.Tables[0].Rows[0]["NameOfIndustrial"].ToString();

            txtLocofUnit.Text = ds.Tables[0].Rows[0]["LocationOfIndustrial"].ToString();
            ddlOrddlorgtypes.SelectedItem.Text = ds.Tables[0].Rows[0]["ConstitutionOfIndustrial"].ToString();
            ddlUdyogAadharType.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["SSIApprovalofIEM"].ToString());
            txtPersonIndustry.Text = ds.Tables[0].Rows[0]["lblAcknoledgementLIORIL"].ToString();
            lblAllwomen.Value = ds.Tables[0].Rows[0]["allwomen"].ToString();
            //if (lblAllwomen.Value.ToString() == "Y")
            //{
            //    txtTSSFCnorms423.Enabled = true;
            //}
            //else
            //{
            //    txtTSSFCnorms423.Enabled = false;

            //}
            //lblLOA.Text = ds.Tables[0].Rows[0]["LOA"].ToString();
            //lblCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
            //lblUnitNumbers.Text = ds.Tables[0].Rows[0]["UnitNumbers"].ToString();
            //lblValue.Text = ds.Tables[0].Rows[0]["Value"].ToString();

            //--------------------Initaial Steps Taken For Project Implementation---------------------
            txtDateOfapplnFile.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfFilingOfAppln"]).ToString("dd/MM/yyyy");
            txtLoanApplnNo.Text = ds.Tables[0].Rows[0]["BankSanctionLetter_No"].ToString();
            if (ds.Tables[0].Rows[0]["BankSanction_Date"].ToString() != "" && ds.Tables[0].Rows[0]["BankSanction_Date"].ToString() != "NA")
                txtDate_Loan.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BankSanction_Date"]).ToString("dd/MM/yyyy");
            else
                txtDate_Loan.Text = "NA";

            //txtDate_Loan.Text = ds.Tables[0].Rows[0]["BankSanction_Date"].ToString();

            if (ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString() != "")
                if (ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString() != "")
                    if ((ds.Tables[0].Rows[0]["NewPowerReleaseDate"]).ToString() != "NA")
                        txtPowerConn_date.Text =
                        Convert.ToDateTime(ds.Tables[0].Rows[0]["NewPowerReleaseDate"]).ToString("dd/MM/yyyy");
                    else
                        txtPowerConn_date.Text = "NA";

            txtPowerConn_load.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
            //lblPowerConnection_Date_contracted.Text = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
            //lblPowerConnection_HP_contracted.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();

            if (ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"].ToString() != "")
            {
                txtDCP_unit.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");

            }
            else
                txtDCP_unit.Text = "";

            if (ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"].ToString() != "")
                txtrc_dic.Text = //same date as application filed date..
                Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"]).ToString("dd/MM/yyyy");
            else
                txtrc_dic.Text = "";

            if ((ds.Tables[0].Rows[0]["Date_Communcn_ShortFalls_DIC"]).ToString() != "")
                txtquery_dic.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Communcn_ShortFalls_DIC"]).ToString("dd/MM/yyyy");
            else
                txtquery_dic.Text = "";
            if ((ds.Tables[0].Rows[0]["DateOfReceipt_DIC"]).ToString() != "")
                txtcompdate_dic.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfReceipt_DIC"]).ToString("dd/MM/yyyy");
            else
                txtcompdate_dic.Text = "";
            if (ds.Tables[0].Rows[0]["ClaimAppln_Date_COI"].ToString() != "")
                txtcompdate_coi.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimAppln_Date_COI"]).ToString("dd/MM/yyyy");

            else
                txtcompdate_coi.Text = "";


            if ((ds.Tables[0].Rows[0]["Date_Communcn_ShortFalls_COI"]).ToString() != "")
                txtquery_coi.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Communcn_ShortFalls_COI"]).ToString("dd/MM/yyyy");
            else
                txtquery_coi.Text = "NA";

            if ((ds.Tables[0].Rows[0]["DateOfReceipt_COI"]).ToString() != "")
                txtcompdate_coi1.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfReceipt_COI"]).ToString("dd/MM/yyyy");
            else
                txtcompdate_coi1.Text = "NA";
            //-------------------Approved Project Cost As Per Guidelines--------------------------------------------------------------------
            txtLand2.Text = ds.Tables[0].Rows[0]["ApprovedLnd"].ToString();
            txtLand3.Text = "";
            txtLand4.Text = "";
            txtLand5.Text = "";
            txtLand6.Text = "";
            txtLand7.Text = "";

            txtBuilding2.Text = ds.Tables[0].Rows[0]["lblApprBuilding"].ToString();
            txtBuilding3.Text = "";
            txtBuilding4.Text = "";
            txtBuilding5.Text = "";
            txtBuilding6.Text = "";
            txtBuilding7.Text = "";

            txtPM2.Text = ds.Tables[0].Rows[0]["ApprovPlantMachinery"].ToString();
            txtPM3.Text = "";
            txtPM4.Text = "";
            txtPM5.Text = "";
            txtPM6.Text = "";
            txtPM7.Text = "";

            txtMCont2.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_ProjectCost"].ToString();
            txtMCont3.Text = "";
            txtMCont4.Text = "";
            txtMCont5.Text = "";
            txtMCont6.Text = "";
            txtMCont7.Text = "";

            txtErec2.Text = "";
            txtErec3.Text = "";
            txtErec4.Text = "";
            txtErec5.Text = "";
            txtErec6.Text = "";
            txtErec7.Text = "";

            txtTFS2.Text = "";
            txtTFS3.Text = "";
            txtTFS4.Text = "";
            txtTFS5.Text = "";
            txtTFS6.Text = "";
            txtTFS7.Text = "";

            txtWC2.Text = "";
            txtWC3.Text = "";
            txtWC4.Text = "";
            txtWC5.Text = "";
            txtWC6.Text = "";
            txtWC7.Text = "";
            //lblApprovOthers.Text = ds.Tables[0].Rows[0]["ApprovOthers"].ToString();
            txtWC2.Text = "";
            //lblOthers1Approve.Text = ds.Tables[0].Rows[0]["Others1Approve"].ToString();

            //--------------------------Details of Investment on fixed Capital assets as on:---------------------------------------------------------------------
            txtLand2.Text = ds.Tables[0].Rows[0]["Land_ProjectCost"].ToString();
            txtLand3.Text = ds.Tables[0].Rows[0]["Land_LoanSanctioned"].ToString();
            txtLand4.Text = ds.Tables[0].Rows[0]["Land_LoanDisbursed"].ToString();
            txtLand5.Text = ds.Tables[0].Rows[0]["Land_Assets"].ToString();
            txtLand6.Text = ds.Tables[0].Rows[0]["Land_ActualExpend_CA"].ToString();
            txtLand7.Text = ds.Tables[0].Rows[0]["Land_ValueRecommendedByGM"].ToString();//insp cost cmptd

            txtBuilding2.Text = ds.Tables[0].Rows[0]["Building_ProjectCost"].ToString();
            txtBuilding3.Text = ds.Tables[0].Rows[0]["Building_LoanSanctioned"].ToString();
            txtBuilding4.Text = ds.Tables[0].Rows[0]["Building_LoanDisbursed"].ToString();
            txtBuilding5.Text = ds.Tables[0].Rows[0]["Building_Assets"].ToString();
            txtBuilding6.Text = ds.Tables[0].Rows[0]["Building_ActualExpend_CA"].ToString();
            txtBuilding7.Text = ds.Tables[0].Rows[0]["Building_ValueRecommendedByGM"].ToString();//insp cost cmptd

            txtPM2.Text = ds.Tables[0].Rows[0]["PlantMachry_ProjectCost"].ToString();
            txtPM3.Text = ds.Tables[0].Rows[0]["PlantMachry_LoanSanctioned"].ToString();
            txtPM4.Text = ds.Tables[0].Rows[0]["PlantMachry_LoanDisbursed"].ToString();
            txtPM5.Text = ds.Tables[0].Rows[0]["PlantMachry_Assets"].ToString();
            txtPM6.Text = ds.Tables[0].Rows[0]["PlantMachry_ActualExpend_CA"].ToString();
            txtPM7.Text = ds.Tables[0].Rows[0]["PlantMachry_ValueRecommendedByGM"].ToString();//insp cost cmptd

            txtMCont2.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_ProjectCost"].ToString();
            txtMCont3.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_Land_LoanSanctioned"].ToString();
            txtMCont4.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_Land_LoanDisbursed"].ToString();
            txtMCont5.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_Assets"].ToString();
            txtMCont6.Text = ds.Tables[0].Rows[0]["FeasibilityStudyCharges_ActualExpend_CA"].ToString();
            txtMCont7.Text = ds.Tables[0].Rows[0]["lblFeasibilityStudyRecommendedByGM"].ToString();//insp cost cmptd

            txtErec2.Text = "0";
            txtErec3.Text = "0";
            txtErec4.Text = "0";
            txtErec5.Text = "0";
            txtErec6.Text = "0";
            txtErec7.Text = "0";

            txtTFS2.Text = "0";
            txtTFS3.Text = "0";
            txtTFS4.Text = "0";
            txtTFS5.Text = "0";
            txtTFS6.Text = "0";
            txtTFS7.Text = "0";

            txtWC2.Text = ds.Tables[0].Rows[0]["Total_ProjectCost"].ToString();
            txtWC3.Text = ds.Tables[0].Rows[0]["Total_LoanSanctioned"].ToString();
            txtWC4.Text = ds.Tables[0].Rows[0]["Total_LoanDisbursed"].ToString();
            txtWC5.Text = ds.Tables[0].Rows[0]["Total_Assets"].ToString();
            txtWC6.Text = ds.Tables[0].Rows[0]["Total_ActualExpend_CA"].ToString();
            txtWC7.Text = "0";
            if (txtLand7.Text == "" || txtLand7.Text == null)
            {
                txtLand7.Text = "0";
            }
            if (txtBuilding7.Text == "" || txtBuilding7.Text == null)
            {
                txtBuilding7.Text = "0";
            }
            if (txtPM7.Text == "" || txtPM7.Text == null)
            {
                txtPM7.Text = "0";
            }
            if (txtMCont7.Text == "" || txtMCont7.Text == null)
            {
                txtMCont7.Text = "0";
            }
            if (txtErec7.Text == "" || txtErec7.Text == null)
            {
                txtErec7.Text = "0";
            }
            if (txtTFS7.Text == "" || txtTFS7.Text == null)
            {
                txtTFS7.Text = "0";
            }


            txtgmRecommend.Text = ds.Tables[0].Rows[0]["Total_ValueRecommendedByGM"].ToString();
            //txtgmRecommend.Text = "123";

            //---------------------Computation of Capital Cost-  ----------A.LAND----------------------------------------
            if (ds.Tables[0].Rows[0]["Land_ValueRecommendedByGM"].ToString() != null)
            {
                txtLandcostCompc.Text = ds.Tables[0].Rows[0]["Land_ValueRecommendedByGM"].ToString();
                TextBox56.Text = ds.Tables[0].Rows[0]["Land_ValueRecommendedByGM"].ToString();
            }

            else
            {
                txtLandcostCompc.Text = "0";
                TextBox56.Text = "0";

            }



            if (ds.Tables[0].Rows[0]["Building_ValueRecommendedByGM"].ToString() != null)
            {
                txtfacCostCompc.Text = ds.Tables[0].Rows[0]["Building_ValueRecommendedByGM"].ToString();
                TextBox57.Text = ds.Tables[0].Rows[0]["Building_ValueRecommendedByGM"].ToString();
            }

            else
            {
                txtfacCostCompc.Text = "0";
                TextBox57.Text = "0";
            }
            if (ds.Tables[0].Rows[0]["ProjcostPlant"].ToString() != null)
            {
                TextBox30.Text = ds.Tables[0].Rows[0]["ProjcostPlant"].ToString();
                TextBox58.Text = ds.Tables[0].Rows[0]["ProjcostPlant"].ToString();
            }

            else
            {
                TextBox30.Text = "0";
                TextBox58.Text = "0";
            }




            txtLandAreaCompc.Text = ds.Tables[0].Rows[0]["LandMeasuring"].ToString();
            txtPurchaCompc.Text = ds.Tables[0].Rows[0]["LandPurchaseValue"].ToString();
            txtStmpDutyCompc.Text = ds.Tables[0].Rows[0]["LandStampDuty"].ToString();
            txtRegnfeeCompc.Text = ds.Tables[0].Rows[0]["LandRegistrationFee"].ToString();
            txtTotalCompc.Text = ds.Tables[0].Rows[0]["TotalLand"].ToString();
            txtBuildingAreCompc.Text = ds.Tables[0].Rows[0]["LandBuildingPlinthArea"].ToString();
            txtvalDICCompc.Text = ds.Tables[0].Rows[0]["LandValue_RecommdedBy_GM"].ToString();
            txtvalCompc1.Text = ds.Tables[0].Rows[0]["LandValue_Computed"].ToString();

            //------------------------------B.FACTORY---------------------------------------------------------------------
            //txtfacCostCompc.Text = ds.Tables[0].Rows[0]["[Building_ValueRecommendedByGM]"].ToString();

            txtfacBldgCompc.Text = ds.Tables[0].Rows[0]["FactoryPlinthArea"].ToString();

            txtsfcCompc.Text = ds.Tables[0].Rows[0]["FactryTSSFCrates"].ToString();

            txtCompvalCompc.Text = ds.Tables[0].Rows[0]["FactoryComputedValue"].ToString();


            //----------------------------------C.PLANT & MACHINERY-------------------------------------------

            TextBox42.Text = ds.Tables[0].Rows[0]["ProjcostPlant"].ToString();
            TextBox32.Text = ds.Tables[0].Rows[0]["TechFeasibilityPlantprjcost"].ToString();
            TextBox31.Text = ds.Tables[0].Rows[0]["PlantSubTotal"].ToString(); //cost comptd

            TextBox34.Text = ds.Tables[0].Rows[0]["PlantMCstatements"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["PlantMCstatements"].ToString();
            TextBox12.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
            TextBox61.Text = ds.Tables[0].Rows[0]["Ownsharecapital"].ToString();
            TextBox19.Text = (Convert.ToDecimal(TextBox60.Text) + Convert.ToDecimal(TextBox5.Text) + Convert.ToDecimal(TextBox7.Text) + Convert.ToDecimal(TextBox9.Text) + Convert.ToDecimal(TextBox11.Text) + Convert.ToDecimal(TextBox13.Text) + Convert.ToDecimal(TextBox15.Text) + Convert.ToDecimal(TextBox17.Text) + Convert.ToDecimal(TextBox18.Text)).ToString();

            TextBox20.Text = (Convert.ToDecimal(TextBox61.Text) + Convert.ToDecimal(TextBox6.Text) + Convert.ToDecimal(TextBox8.Text) + Convert.ToDecimal(TextBox10.Text) + Convert.ToDecimal(TextBox12.Text) + Convert.ToDecimal(TextBox16.Text)).ToString();


            TextBox36.Text = ds.Tables[0].Rows[0]["PlantCACerti"].ToString();
            TextBox38.Text = ds.Tables[0].Rows[0]["PlantCapitalisCerti"].ToString();
            TextBox42.Text = ds.Tables[0].Rows[0]["ComputdValuePlant"].ToString();
            TextBox33.Text = ds.Tables[0].Rows[0]["ApprovedLnd"].ToString();
            TextBox37.Text = ds.Tables[0].Rows[0]["lblApprBuilding"].ToString();
            TextBox41.Text = ds.Tables[0].Rows[0]["ApprovPlantMachinery"].ToString();
            TextBox44.Text = "0";



            //if (TextBox44.Text != "0")
            //{
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
            //}
            //if (TextBox45.Text != "0")
            //{
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
            //}
            if (ds.Tables[2].Rows.Count > 0)
            {
                TXTWOODQUANTITY.Text = ds.Tables[2].Rows[0]["Quantity_WOOD"].ToString();
                TXTWOODQUANTITY_TextChanged(this, EventArgs.Empty);
                TXTELIGIBLEAMOUNT.Text = ds.Tables[2].Rows[0]["Amountclaimed"].ToString();

            }


        }
    }
    public void getLOAData(string ds1)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        da = new SqlDataAdapter("USP_GET_LOA_DATA", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = ds1.ToString();
        da.Fill(ds);
        gvInstalledCap.Visible = true;
        gvInstalledCap.DataSource = ds;
        gvInstalledCap.DataBind();
    }
    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");


        dtMyTable1.Columns.Add("Column1", typeof(string));
        dtMyTable1.Columns.Add("Column2", typeof(string));
        dtMyTable1.Columns.Add("Column3", typeof(string));
        dtMyTable1.Columns.Add("Column4", typeof(string));
        dtMyTable1.Columns.Add("Column5", typeof(string));
        dtMyTable1.Columns.Add("Column6", typeof(string));
        dtMyTable1.Columns.Add("Created_by", typeof(string));


        return dtMyTable1;
    }
    public int SaveIncentiveDetailsFromGridViewToTable(string incentiveId)
    {
        int Value = 0;
        int statuspr = 0;

        if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
        {
            GetNewRectoInsertdr();
            statuspr = bulkInsertNewEnterPrise(myDtNewRecdr, incentiveId);
        }

        // LOA Expan 

        return statuspr;
    }
    public int bulkInsertNewEnterPrise(DataTable dt, string incentiveId)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        con.Open();
        int i = 0;
        try
        {
            foreach (DataRow row in dt.Rows)
            {
                row["Column5"] = incentiveId;
            }

            SqlBulkCopy bulkCopy = new SqlBulkCopy(con);
            SqlBulkCopyColumnMapping mapping1 = new SqlBulkCopyColumnMapping("Column1", "LineofActivity");
            SqlBulkCopyColumnMapping mapping2 = new SqlBulkCopyColumnMapping("Column2", "NameofUnit");
            SqlBulkCopyColumnMapping mapping3 = new SqlBulkCopyColumnMapping("Column3", "InstalledCapacity");
            SqlBulkCopyColumnMapping mapping4 = new SqlBulkCopyColumnMapping("Column4", "Value");
            SqlBulkCopyColumnMapping mapping5 = new SqlBulkCopyColumnMapping("Created_by", Session["uid"].ToString());
            SqlBulkCopyColumnMapping mapping6 = new SqlBulkCopyColumnMapping("Column5", "incentiveid");

            bulkCopy.ColumnMappings.Add(mapping1);
            bulkCopy.ColumnMappings.Add(mapping2);
            bulkCopy.ColumnMappings.Add(mapping3);
            bulkCopy.ColumnMappings.Add(mapping4);
            bulkCopy.ColumnMappings.Add(mapping5);
            bulkCopy.ColumnMappings.Add(mapping6);

            bulkCopy.DestinationTableName = ("Incentives_Line_of_Activity_appraisalnote");
            bulkCopy.WriteToServer(dt);
            i = 1;
        }
        catch (Exception ex)
        {
            throw ex;
            i = 0;
        }
        finally
        {
            con.Close();
        }
        return i;
    }
    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        myDtNewRecdr = dvdr.ToTable();

    }
    private void AddDataToTableCeertificate(string Manf_ItemName, string strunit, string Manf_Item_Qty, string Manf_units, string Manf_Item_Price, string updDelete)
    {
        try
        {
            if (ddlquantityin.SelectedValue.ToString() == "Others")
            {

            }

            DataRow Row;
            DataTable myTable;
            myTable = createtablecrtificate1();
            Row = myTable.NewRow();
            Row["Column1"] = Manf_ItemName; Row["Column2"] = strunit; Row["Column3"] = Manf_Item_Price;
            Row["Column4"] = Manf_Item_Qty; Row["Column5"] = Manf_units;
            Row["Column6"] = Session["incentiveid"].ToString();
            Row["Created_by"] = Session["uid"].ToString().Trim();
            myTable.Rows.Add(Row); gvInstalledCap.DataSource = myTable; gvInstalledCap.DataBind();
            Session["CertificateTb2"] = ""; Session["CertificateTb2"] = myTable;
            //myTable.Rows.Add();
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlTransaction transaction = null; connection.Open();
            transaction = connection.BeginTransaction();
            string testss = Session["incentiveid"].ToString();

            string testss1 = Session["uid"].ToString();

            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[Incentives_Line_of_Activity_appraisalnote_ltst]";

            com.Transaction = transaction;
            com.Connection = connection;

            com.Parameters.AddWithValue("@lineofact", Manf_ItemName.ToString());
            com.Parameters.AddWithValue("@lineofact_unit", strunit.ToString());
            com.Parameters.AddWithValue("@lineofact_qty", Manf_Item_Qty.ToString());
            com.Parameters.AddWithValue("@lineofact_instCap", Manf_units.ToString());
            com.Parameters.AddWithValue("@lineofact_value", Manf_Item_Price.ToString());
            com.Parameters.AddWithValue("@incentiveid", testss.ToString());
            com.Parameters.AddWithValue("@createdby", testss1.ToString());
            com.Parameters.AddWithValue("@updDel", updDelete.ToString());
            //com.Parameters.Add("@retval", SqlDbType.Int);
            //com.Parameters["@retval"].Direction = ParameterDirection.Output;

            //com.ExecuteNonQuery();

            //com.ExecuteNonQuery();
            //int iCount = 

            //object retval =  com.ExecuteScalar();

            string firstColumn = Convert.ToString(com.ExecuteScalar());

            transaction.Commit();
            string retvals = firstColumn.ToString();
            //com.ExecuteNonQuery();
            //string retval = com.Parameters["@rretVAl"].Value.ToString();

            if (retvals == "not done")
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity already exists!');", true);


            //if (retval == "deleted")
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity deleted');", true);


            #region "commented code"
            //string test = ViewState["checking"].ToString();
            //if (ViewState["checking"]==null || ViewState["checking"].ToString() != "Y")
            //{
            //    if (gvInstalledCap.Rows.Count >= 1)
            //    {
            //        foreach (GridViewRow grow in gvInstalledCap.Rows)
            //        {
            //            ViewState["checking"] = "Y";

            //            string Manf_ItemName1= grow.Cells[0].Text.ToString();
            //            string strunit1 = grow.Cells[1].Text.ToString();
            //            string Manf_Item_Price1 = grow.Cells[2].Text.ToString();
            //            string Manf_Item_Qty1 = grow.Cells[3].Text.ToString();//for others units..
            //            string Manf_units1 = grow.Cells[4].Text.ToString();
            //            string Manf_units2 = grow.Cells[5].Text.ToString();
            //            string Manf_units3 = grow.Cells[6].Text.ToString();
            //            string Manf_units4 = grow.Cells[6].Text.ToString();
            //            string Manf_units5 = grow.Cells[7].Text.ToString();
            //            string Manf_units6 = grow.Cells[8].Text.ToString();


            //            string incentiveid1= Session["incentiveid"].ToString();
            //            string Created_by1= Session["uid"].ToString().Trim();

            //            //for (int i = 0; i < grow.Cells.Count; i++)
            //            //{
            //            //    myTable.Rows[grow.RowIndex][i] = grow.Cells[i].Text;
            //            //}
            //        }
            //    }
            //}

            #endregion

        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    public void ClearTxt()
    {
        txtLOActivity.Text = "";
        txtunit.Text = "";
        txtinstalledccap.Text = "";
        txtvalue.Text = "";

        // txtnamedparter.Text = "";
        // txtshare.Text = "";
        // txtpercentage.Text = "";
    }
    protected void btnInstalledcap_Click(object sender, EventArgs e)
    {

        AddDataToTableCeertificate(txtLOActivity.Text.ToString(), txtunit.Text.ToString(), ddlquantityin.SelectedItem.Text.ToString(), txtinstalledccap.Text.ToString(), txtvalue.Text.ToString(), "Y");

    }
    protected void gvInstalledCap_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvInstalledCap_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string delValue = gvInstalledCap.Rows[e.RowIndex].Cells[1].Text.ToString();
            AddDataToTableCeertificate(delValue, "", "", "", "", "N");
        }
        catch (Exception ex)
        {

        }

    }
    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantityin.SelectedValue.ToString() == "Others")
        {
            txtunit.Visible = true;
            ddlquantityin.Visible = true;
        }
        else
        {
            txtunit.Visible = false;
            ddlquantityin.Visible = true;
        }

    }
    public int deleteGroupSavingData1(string id)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "deletemanufacturedata_appraisal";

        cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


        con.Open();
        cmd.Connection = con;

        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            return 0;
        }
        finally
        {
            cmd.Dispose();
            con.Close();

        }
    }
    protected void txtLand7_TextChanged(object sender, EventArgs e)
    {

    }
    public void BindConstitutionUnit()
    {
        try
        {
            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("USP_GETCONSTITUTIONUNIT", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            //USP_GETCONSTITUTIONUNIT

            //ddlOrddlorgtypes.DataSource = oDataSet;
            //dsdorg.Tables.Add(dtorg);
            //dsdorg.Tables.Remove(dtorg);
            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                ddlOrddlorgtypes.DataSource = oDataSet.Tables[0];
                ddlOrddlorgtypes.DataValueField = "CunitId";
                ddlOrddlorgtypes.DataTextField = "ConstitutionUnit";
                ddlOrddlorgtypes.DataBind();
                ddlOrddlorgtypes.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlOrddlorgtypes.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void txtBuilding7_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtPM7_TextChanged(object sender, EventArgs e)
    {


    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void gvInstalledCap_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvInstalledCap_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void txtTSSFCnorms422_TextChanged(object sender, EventArgs e)
    {
        //if (txtTSSFCnorms422.Text != "0")
        //{
        //    txt423guideline.Enabled = true;
        //}
        //else
        //{
        //    txt423guideline.Enabled = false;
        //}
    }
    //protected void TextBox59_TextChanged(object sender, EventArgs e)
    //{
    //    if (TextBox57.Text != "" && TextBox58.Text != "" && TextBox45.Text != "")
    //    {

    //        if (rdeligibility.SelectedValue == "Regular")
    //        {
    //            //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
    //            //txtTSSFCnorms423.Text = "0";
    //        }
    //        if (rdeligibility.SelectedValue == "Belated")
    //        {
    //            //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
    //            //txtTSSFCnorms423.Text = "0";
    //        }
    //        if (rdeligibility.SelectedValue == "OneYear")
    //        {
    //            //    txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
    //            //    txtTSSFCnorms423.Text = "0";
    //        }

    //        txtvalue424.Text = "";// (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();



    //    }
    //    else
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter all the details in Abstract - Computed as eligible investment');", true);
    //        //TextBox59.Text = "";
    //    }
    //}
    protected void TextBox33_TextChanged(object sender, EventArgs e)
    {
        if (TextBox37.Text == "")
        {
            TextBox37.Text = "0";
        }
        if (TextBox41.Text == "")
        {
            TextBox41.Text = "0";
        }
        if (TextBox44.Text == "")
        {
            TextBox44.Text = "0";
        }

        TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
    }
    protected void TextBox37_TextChanged(object sender, EventArgs e)
    {
        if (TextBox33.Text == "")
        {
            TextBox33.Text = "0";
        }
        if (TextBox41.Text == "")
        {
            TextBox41.Text = "0";
        }
        if (TextBox44.Text == "")
        {
            TextBox44.Text = "0";
        }
        TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
    }
    protected void TextBox41_TextChanged(object sender, EventArgs e)
    {
        if (TextBox33.Text == "")
        {
            TextBox33.Text = "0";
        }
        if (TextBox37.Text == "")
        {
            TextBox37.Text = "0";
        }
        if (TextBox44.Text == "")
        {
            TextBox44.Text = "0";
        }
        TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
    }
    protected void TextBox44_TextChanged(object sender, EventArgs e)
    {
        if (TextBox33.Text == "")
        {
            TextBox33.Text = "0";
        }
        if (TextBox37.Text == "")
        {
            TextBox37.Text = "0";
        }
        if (TextBox41.Text == "")
        {
            TextBox41.Text = "0";
        }
        TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
    }
    protected void TextBox56_TextChanged(object sender, EventArgs e)
    {
        if (TextBox57.Text == "")
        {
            TextBox57.Text = "0";
        }
        if (TextBox58.Text == "")
        {
            TextBox58.Text = "0";
        }
        if (TextBox45.Text == "")
        {
            TextBox45.Text = "0";
        }
        TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
    }
    protected void TextBox57_TextChanged(object sender, EventArgs e)
    {
        if (TextBox56.Text == "")
        {
            TextBox56.Text = "0";
        }
        if (TextBox58.Text == "")
        {
            TextBox58.Text = "0";
        }
        if (TextBox45.Text == "")
        {
            TextBox45.Text = "0";
        }
        TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
    }
    protected void TextBox58_TextChanged(object sender, EventArgs e)
    {
        if (TextBox56.Text == "")
        {
            TextBox56.Text = "0";
        }
        if (TextBox57.Text == "")
        {
            TextBox57.Text = "0";
        }
        if (TextBox45.Text == "")
        {
            TextBox45.Text = "0";
        }
        TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
    }
    protected void TextBox45_TextChanged(object sender, EventArgs e)
    {
        if (TextBox56.Text == "")
        {
            TextBox56.Text = "0";
        }
        if (TextBox57.Text == "")
        {
            TextBox57.Text = "0";
        }
        if (TextBox58.Text == "")
        {
            TextBox58.Text = "0";
        }
        TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Page_Load(null, null);
    }
    public bool save()
    {
        //        GetNewRectoInsertd//r();
        AssignValuestoVosFromcontrols();
        string returnval = InsertCommonData(oIncentiveVosA);
        if (returnval == "1")
        {
            lstremarksad.Clear();
            //string IncentiveID = "";
            //DataTable oDataSet;
            //oDataSet = new DataTable();
            //oDataSet = (DataTable)gvQueries_ADLevel.DataSource;
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();

            //foreach (GridViewRow gvrow in GridView16.Rows)
            //{

            officerRemarks fromvo = new officerRemarks();
            //int rowIndex = gvrow.RowIndex;
            fromvo.EnterperIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text.ToString();

            fromvo.MstIncentiveId = "19";// Request.QueryString["MstIncentiveId"].ToString();
            fromvo.id = "";// ((Label)gvrow.FindControl("Label60")).Text.ToString();
            fromvo.status = "Recomm";
            fromvo.Remarks = txtremarks.Text;// HttpUtility.HtmlDecode(GridView16.Rows[rowIndex].Cells[3].Text);
            fromvo.CreatedByid = oIncentiveVosA.created_by;// ((Label)gvrow.FindControl("Label59")).Text.ToString();
            fromvo.Designation = Role_Code.Trim();

            fromvo.Recomamount = oIncentiveVosA.FINALSUBSIDYAMOUNT;

            lstremarksad.Add(fromvo);

            //Button4.Visible = true;
            // }

            //foreach (GridViewRow gvrow in GridView16.Rows)
            //{
            officerForwarded frmvo = new officerForwarded();
            string lblMstIncentiveId = "19";// Request.QueryString["MstIncentiveId"].ToString();
            string lblIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text;
            //IncentiveID = lblIncentiveID;
            frmvo.EnterperIncentiveID = lblIncentiveID;
            frmvo.MstIncentiveId = lblMstIncentiveId;
            frmvo.CreatedByid = Session["uid"].ToString();
            frmvo.ApplicationFrom = Session["uid"].ToString();
            //if (tradditional.Visible == true)
            //{
            //    string[] datett = txtslcnodate.Text.Trim().Split('/');
            //    frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
            //    frmvo.SLCNO = txtslcno.Text.Trim();
            //}

            lstincentives.Add(frmvo);
            //}
            int valid = 0;
            valid = InsertincentiveOfficerCommentsAD(lstremarksad, lstincentives, getclientIP());
            //if (valid == 1)
            //{
            return true;
            //}
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "message", message, true);
            return false;
        }

    }
    public string InsertCommonData(IncentiveVosAppraisalStamp oIncentiveVosA)
    {
        string valid = "";
        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        //SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_appraisal_WOOD]";

            com.Transaction = transaction;
            com.Connection = connection;

            if (oIncentiveVosA.lblApplicationno != null)
                com.Parameters.AddWithValue("@incapplnno", oIncentiveVosA.lblApplicationno);

            if (oIncentiveVosA.txtunitnames != null)
                com.Parameters.AddWithValue("@txtunitnames", oIncentiveVosA.txtunitnames);

            if (oIncentiveVosA.txtLocofUnit != null)
                com.Parameters.AddWithValue("@txtLocofUnit", oIncentiveVosA.txtLocofUnit);

            if (oIncentiveVosA.ddlOrddlorgtypes != null)
                com.Parameters.AddWithValue("@ddlOrddlorgtypes", oIncentiveVosA.ddlOrddlorgtypes);

            if (oIncentiveVosA.ddlUdyogAadharType != null)
                com.Parameters.AddWithValue("@ddlUdyogAadharType", oIncentiveVosA.ddlUdyogAadharType);

            if (oIncentiveVosA.txtPersonIndustry != null)
                com.Parameters.AddWithValue("@txtPersonIndustry", oIncentiveVosA.txtPersonIndustry);

            if (oIncentiveVosA.txtDateOfapplnFile != null)
                com.Parameters.AddWithValue("@txtDateOfapplnFile", oIncentiveVosA.txtDateOfapplnFile);

            if (oIncentiveVosA.txtLoanApplnNo != null)
                com.Parameters.AddWithValue("@txtLoanApplnNo", oIncentiveVosA.txtLoanApplnNo);

            if (oIncentiveVosA.txtDate_Loan != null)
                com.Parameters.AddWithValue("@txtDate_Loan", oIncentiveVosA.txtDate_Loan);

            if (oIncentiveVosA.txtNameofFinIns != null)
                com.Parameters.AddWithValue("@txtNameofFinIns", oIncentiveVosA.txtNameofFinIns);

            if (oIncentiveVosA.txtPowerConn_date != null)
                com.Parameters.AddWithValue("@txtPowerConn_date", oIncentiveVosA.txtPowerConn_date);

            if (oIncentiveVosA.txtPowerConn_load != null)
                com.Parameters.AddWithValue("@txtPowerConn_load", oIncentiveVosA.txtPowerConn_load);

            if (oIncentiveVosA.txtDCP_unit != null)
                com.Parameters.AddWithValue("@txtDCP_unit", oIncentiveVosA.txtDCP_unit);

            if (oIncentiveVosA.txtrc_dic != null)
                com.Parameters.AddWithValue("@txtrc_dic", oIncentiveVosA.txtrc_dic);

            if (oIncentiveVosA.txtcompdate_dic != null)
                com.Parameters.AddWithValue("@txtcompdate_dic", oIncentiveVosA.txtcompdate_dic);

            if (oIncentiveVosA.txtquery_dic != null)
                com.Parameters.AddWithValue("@txtquery_dic", oIncentiveVosA.txtquery_dic);

            if (oIncentiveVosA.txtcompdate_coi != null)
                com.Parameters.AddWithValue("@txtcompdate_coi", oIncentiveVosA.txtcompdate_coi);

            if (oIncentiveVosA.txtcompdate_coi1 != null)
                com.Parameters.AddWithValue("@txtcompdate_coi1", oIncentiveVosA.txtcompdate_coi1);

            if (oIncentiveVosA.txtLand2 != null)
                com.Parameters.AddWithValue("@txtLand2", oIncentiveVosA.txtLand2);

            if (oIncentiveVosA.txtLand3 != null)
                com.Parameters.AddWithValue("@txtLand3", oIncentiveVosA.txtLand3);

            if (oIncentiveVosA.txtLand4 != null)
                com.Parameters.AddWithValue("@txtLand4", oIncentiveVosA.txtLand4);

            if (oIncentiveVosA.txtLand5 != null)
                com.Parameters.AddWithValue("@txtLand5", oIncentiveVosA.txtLand5);

            if (oIncentiveVosA.txtLand6 != null)
                com.Parameters.AddWithValue("@txtLand6", oIncentiveVosA.txtLand6);

            if (oIncentiveVosA.txtLand7 != null)
                com.Parameters.AddWithValue("@txtLand7", oIncentiveVosA.txtLand7);

            if (oIncentiveVosA.txtBuilding2 != null)
                com.Parameters.AddWithValue("@txtBuilding2", oIncentiveVosA.txtBuilding2);

            if (oIncentiveVosA.txtBuilding3 != null)
                com.Parameters.AddWithValue("@txtBuilding3", oIncentiveVosA.txtBuilding3);

            if (oIncentiveVosA.txtBuilding4 != null)
                com.Parameters.AddWithValue("@txtBuilding4", oIncentiveVosA.txtBuilding4);

            if (oIncentiveVosA.txtBuilding5 != null)
                com.Parameters.AddWithValue("@txtBuilding5", oIncentiveVosA.txtBuilding5);

            if (oIncentiveVosA.txtBuilding6 != null)
                com.Parameters.AddWithValue("@txtBuilding6", oIncentiveVosA.txtBuilding6);

            if (oIncentiveVosA.txtBuilding7 != null)
                com.Parameters.AddWithValue("@txtBuilding7", oIncentiveVosA.txtBuilding7);

            if (oIncentiveVosA.txtPM2 != null)
                com.Parameters.AddWithValue("@txtPM2", oIncentiveVosA.txtPM2);

            if (oIncentiveVosA.txtPM3 != null)
                com.Parameters.AddWithValue("@txtPM3", oIncentiveVosA.txtPM3);

            if (oIncentiveVosA.txtPM4 != null)
                com.Parameters.AddWithValue("@txtPM4", oIncentiveVosA.txtPM4);

            if (oIncentiveVosA.txtPM5 != null)
                com.Parameters.AddWithValue("@txtPM5", oIncentiveVosA.txtPM5);

            if (oIncentiveVosA.txtPM6 != null)
                com.Parameters.AddWithValue("@txtPM6", oIncentiveVosA.txtPM6);

            if (oIncentiveVosA.txtPM7 != null)
                com.Parameters.AddWithValue("@txtPM7", oIncentiveVosA.txtPM7);

            if (oIncentiveVosA.txtMCont2 != null)
                com.Parameters.AddWithValue("@txtMCont2", oIncentiveVosA.txtMCont2);

            if (oIncentiveVosA.txtMCont3 != null)
                com.Parameters.AddWithValue("@txtMCont3", oIncentiveVosA.txtMCont3);

            if (oIncentiveVosA.txtMCont4 != null)
                com.Parameters.AddWithValue("@txtMCont4", oIncentiveVosA.txtMCont4);

            if (oIncentiveVosA.txtMCont5 != null)
                com.Parameters.AddWithValue("@txtMCont5", oIncentiveVosA.txtMCont5);

            if (oIncentiveVosA.txtMCont6 != null)
                com.Parameters.AddWithValue("@txtMCont6", oIncentiveVosA.txtMCont6);

            if (oIncentiveVosA.txtMCont7 != null)
                com.Parameters.AddWithValue("@txtMCont7", oIncentiveVosA.txtMCont7);

            if (oIncentiveVosA.txtErec2 != null)
                com.Parameters.AddWithValue("@txtErec2", oIncentiveVosA.txtErec2);

            if (oIncentiveVosA.txtErec3 != null)
                com.Parameters.AddWithValue("@txtErec3", oIncentiveVosA.txtErec3);

            if (oIncentiveVosA.txtErec4 != null)
                com.Parameters.AddWithValue("@txtErec4", oIncentiveVosA.txtErec4);

            if (oIncentiveVosA.txtErec5 != null)
                com.Parameters.AddWithValue("@txtErec5", oIncentiveVosA.txtErec5);

            if (oIncentiveVosA.txtErec6 != null)
                com.Parameters.AddWithValue("@txtErec6", oIncentiveVosA.txtErec6);

            if (oIncentiveVosA.txtErec7 != null)
                com.Parameters.AddWithValue("@txtErec7", oIncentiveVosA.txtErec7);

            if (oIncentiveVosA.txtTFS2 != null)
                com.Parameters.AddWithValue("@txtTFS2", oIncentiveVosA.txtTFS2);

            if (oIncentiveVosA.txtTFS3 != null)
                com.Parameters.AddWithValue("@txtTFS3", oIncentiveVosA.txtTFS3);

            if (oIncentiveVosA.txtTFS4 != null)
                com.Parameters.AddWithValue("@txtTFS4", oIncentiveVosA.txtTFS4);

            if (oIncentiveVosA.txtTFS5 != null)
                com.Parameters.AddWithValue("@txtTFS5", oIncentiveVosA.txtTFS5);

            if (oIncentiveVosA.txtTFS6 != null)
                com.Parameters.AddWithValue("@txtTFS6", oIncentiveVosA.txtTFS6);

            if (oIncentiveVosA.txtTFS7 != null)
                com.Parameters.AddWithValue("@txtTFS7", oIncentiveVosA.txtTFS7);

            if (oIncentiveVosA.txtWC2 != null)
                com.Parameters.AddWithValue("@txtWC2", oIncentiveVosA.txtWC2);

            if (oIncentiveVosA.txtWC3 != null)
                com.Parameters.AddWithValue("@txtWC3", oIncentiveVosA.txtWC3);

            if (oIncentiveVosA.txtWC4 != null)
                com.Parameters.AddWithValue("@txtWC4", oIncentiveVosA.txtWC4);

            if (oIncentiveVosA.txtWC5 != null)
                com.Parameters.AddWithValue("@txtWC5", oIncentiveVosA.txtWC5);

            if (oIncentiveVosA.txtWC6 != null)
                com.Parameters.AddWithValue("@txtWC6", oIncentiveVosA.txtWC6);

            if (oIncentiveVosA.txtWC7 != null)
                com.Parameters.AddWithValue("@txtWC7", oIncentiveVosA.txtWC7);

            if (oIncentiveVosA.txtLandcostCompc != null)
                com.Parameters.AddWithValue("@txtLandcostCompc", oIncentiveVosA.txtLandcostCompc);

            if (oIncentiveVosA.txtLandAreaCompc != null)
                com.Parameters.AddWithValue("@txtLandAreaCompc", oIncentiveVosA.txtLandAreaCompc);

            if (oIncentiveVosA.txtPurchaCompc != null)
                com.Parameters.AddWithValue("@txtPurchaCompc", oIncentiveVosA.txtPurchaCompc);

            if (oIncentiveVosA.txtStmpDutyCompc != null)
                com.Parameters.AddWithValue("@txtStmpDutyCompc", oIncentiveVosA.txtStmpDutyCompc);

            if (oIncentiveVosA.txtRegnfeeCompc != null)
                com.Parameters.AddWithValue("@txtRegnfeeCompc", oIncentiveVosA.txtRegnfeeCompc);

            if (oIncentiveVosA.txtTotalCompc != null)
                com.Parameters.AddWithValue("@txtTotalCompc", oIncentiveVosA.txtTotalCompc);

            if (oIncentiveVosA.txtBuildingAreCompc != null)
                com.Parameters.AddWithValue("@txtBuildingAreCompc", oIncentiveVosA.txtBuildingAreCompc);

            if (oIncentiveVosA.txtvalDICCompc != null)
                com.Parameters.AddWithValue("@txtvalDICCompc", oIncentiveVosA.txtvalDICCompc);

            if (oIncentiveVosA.txtvalCompc1 != null)
                com.Parameters.AddWithValue("@txtvalCompc1", oIncentiveVosA.txtvalCompc1);

            if (oIncentiveVosA.txtresonsCompc != null)
                com.Parameters.AddWithValue("@txtresonsCompc", oIncentiveVosA.txtresonsCompc);

            if (oIncentiveVosA.txtfacCostCompc != null)
                com.Parameters.AddWithValue("@txtfacCostCompc", oIncentiveVosA.txtfacCostCompc);

            // Bank details 
            if (oIncentiveVosA.txtfacBldgCompc != null)
                com.Parameters.AddWithValue("@txtfacBldgCompc", oIncentiveVosA.txtfacBldgCompc);

            if (oIncentiveVosA.txtcivilEngCompc != null)
                com.Parameters.AddWithValue("@txtcivilEngCompc", oIncentiveVosA.txtcivilEngCompc);

            if (oIncentiveVosA.txtsfcCompc != null)
                com.Parameters.AddWithValue("@txtsfcCompc", oIncentiveVosA.txtsfcCompc);

            if (oIncentiveVosA.TextBox60 != null)
                com.Parameters.AddWithValue("@TextBox60", oIncentiveVosA.TextBox60);

            if (oIncentiveVosA.TextBox5 != null)
                com.Parameters.AddWithValue("@TextBox5", oIncentiveVosA.TextBox5);

            if (oIncentiveVosA.TextBox9 != null)
                com.Parameters.AddWithValue("@TextBox9", oIncentiveVosA.TextBox9);

            if (oIncentiveVosA.TextBox11 != null)
                com.Parameters.AddWithValue("@TextBox11", oIncentiveVosA.TextBox11);

            if (oIncentiveVosA.TextBox13 != null)
                com.Parameters.AddWithValue("@TextBox13", oIncentiveVosA.TextBox13);

            if (oIncentiveVosA.TextBox15 != null)
                com.Parameters.AddWithValue("@TextBox15", oIncentiveVosA.TextBox15);

            if (oIncentiveVosA.TextBox17 != null)
                com.Parameters.AddWithValue("@TextBox17", oIncentiveVosA.TextBox17);

            if (oIncentiveVosA.TextBox18 != null)
                com.Parameters.AddWithValue("@TextBox18", oIncentiveVosA.TextBox18);

            if (oIncentiveVosA.TextBox19 != null)
                com.Parameters.AddWithValue("@TextBox19", oIncentiveVosA.TextBox19);

            if (oIncentiveVosA.TextBox61 != null)
                com.Parameters.AddWithValue("@TextBox61", oIncentiveVosA.TextBox61);
            if (oIncentiveVosA.TextBox6 != null)
                com.Parameters.AddWithValue("@TextBox6", oIncentiveVosA.TextBox6);
            if (oIncentiveVosA.TextBox8 != null)
                com.Parameters.AddWithValue("@TextBox8", oIncentiveVosA.TextBox8);
            if (oIncentiveVosA.TextBox10 != null)
                com.Parameters.AddWithValue("@TextBox10", oIncentiveVosA.TextBox10);
            if (oIncentiveVosA.TextBox12 != null)
                com.Parameters.AddWithValue("@TextBox12", oIncentiveVosA.TextBox12);
            if (oIncentiveVosA.TextBox14 != null)
                com.Parameters.AddWithValue("@TextBox14", oIncentiveVosA.TextBox14);
            if (oIncentiveVosA.TextBox16 != null)
                com.Parameters.AddWithValue("@TextBox16", oIncentiveVosA.TextBox16);
            if (oIncentiveVosA.TextBox20 != null)
                com.Parameters.AddWithValue("@TextBox20", oIncentiveVosA.TextBox20);


            if (oIncentiveVosA.TextBox7 != null)
                com.Parameters.AddWithValue("@TextBox7", oIncentiveVosA.TextBox7);

            if (oIncentiveVosA.txtCAExpCompc != null)
                com.Parameters.AddWithValue("@txtCAExpCompc", oIncentiveVosA.txtCAExpCompc);

            if (oIncentiveVosA.txtCompvalCompc != null)
                com.Parameters.AddWithValue("@txtCompvalCompc", oIncentiveVosA.txtCompvalCompc);

            if (oIncentiveVosA.txtrsnCompc != null)
                com.Parameters.AddWithValue("@txtrsnCompc", oIncentiveVosA.txtrsnCompc);


            if (oIncentiveVosA.TextBox30 != null)
                com.Parameters.AddWithValue("@TextBox30", oIncentiveVosA.TextBox30);


            if (oIncentiveVosA.TextBox32 != null)
                com.Parameters.AddWithValue("@TextBox32", oIncentiveVosA.TextBox32);


            if (oIncentiveVosA.TextBox31 != null)
                com.Parameters.AddWithValue("@TextBox31", oIncentiveVosA.TextBox31);


            if (oIncentiveVosA.TextBox34 != null)
                com.Parameters.AddWithValue("@TextBox34", oIncentiveVosA.TextBox34);


            if (oIncentiveVosA.TextBox36 != null)
                com.Parameters.AddWithValue("@TextBox36", oIncentiveVosA.TextBox36);


            if (oIncentiveVosA.TextBox38 != null)
                com.Parameters.AddWithValue("@TextBox38", oIncentiveVosA.TextBox38);

            //// Vat No
            if (oIncentiveVosA.TextBox40 != null)
                com.Parameters.AddWithValue("@TextBox40", oIncentiveVosA.TextBox40);


            if (oIncentiveVosA.TextBox42 != null)
                com.Parameters.AddWithValue("@TextBox42", oIncentiveVosA.TextBox42);

            if (oIncentiveVosA.TextBox47 != null)
                com.Parameters.AddWithValue("@TextBox47", oIncentiveVosA.TextBox47);

            if (oIncentiveVosA.TextBox33 != null)
                com.Parameters.AddWithValue("@TextBox33", oIncentiveVosA.TextBox33);

            if (oIncentiveVosA.TextBox37 != null)
                com.Parameters.AddWithValue("@TextBox37", oIncentiveVosA.TextBox37);

            if (oIncentiveVosA.TextBox41 != null)
                com.Parameters.AddWithValue("@TextBox41", oIncentiveVosA.TextBox41);

            if (oIncentiveVosA.TextBox44 != null)
                com.Parameters.AddWithValue("@TextBox44", oIncentiveVosA.TextBox44);

            if (oIncentiveVosA.TextBox1 != null)
                com.Parameters.AddWithValue("@TextBox1", oIncentiveVosA.TextBox1);

            if (oIncentiveVosA.TextBox56 != null)
                com.Parameters.AddWithValue("@TextBox56", oIncentiveVosA.TextBox56);

            if (oIncentiveVosA.TextBox57 != null)
                com.Parameters.AddWithValue("@TextBox57", oIncentiveVosA.TextBox57);

            if (oIncentiveVosA.TextBox58 != null)
                com.Parameters.AddWithValue("@TextBox58", oIncentiveVosA.TextBox58);

            if (oIncentiveVosA.TextBox45 != null)
                com.Parameters.AddWithValue("@TextBox45", oIncentiveVosA.TextBox45);

            if (oIncentiveVosA.TextBox2 != null)
                com.Parameters.AddWithValue("@TextBox2", oIncentiveVosA.TextBox2);

            if (oIncentiveVosA.TextBox35 != null)
                com.Parameters.AddWithValue("@TextBox35", oIncentiveVosA.TextBox35);

            if (oIncentiveVosA.TextBox39 != null)
                com.Parameters.AddWithValue("@TextBox39", oIncentiveVosA.TextBox39);

            if (oIncentiveVosA.TextBox43 != null)
                com.Parameters.AddWithValue("@TextBox43", oIncentiveVosA.TextBox43);

            if (oIncentiveVosA.TextBox46 != null)
                com.Parameters.AddWithValue("@TextBox46", oIncentiveVosA.TextBox46);

            if (oIncentiveVosA.TextBox48 != null)
                com.Parameters.AddWithValue("@TextBox48", oIncentiveVosA.TextBox48);

            if (oIncentiveVosA.txtContProdMgm != null)
                if (oIncentiveVosA.txtContProdMgm != null)
                    com.Parameters.AddWithValue("@txtContProdMgm", oIncentiveVosA.txtContProdMgm);

            if (oIncentiveVosA.txt25BldgCvl != null)
                com.Parameters.AddWithValue("@txt25BldgCvl", oIncentiveVosA.txt25BldgCvl);

            if (oIncentiveVosA.txt822guideline422 != null)
                com.Parameters.AddWithValue("@txt822guideline422", oIncentiveVosA.txt822guideline422);

            if (oIncentiveVosA.txtTSSFCnorms422 != null)
                com.Parameters.AddWithValue("@txtTSSFCnorms422", oIncentiveVosA.txtTSSFCnorms422);

            if (oIncentiveVosA.txtPlintharea424 != null)
                com.Parameters.AddWithValue("@txtPlintharea424", oIncentiveVosA.txtPlintharea424);

            if (oIncentiveVosA.txtPlintharea422 != null)
                com.Parameters.AddWithValue("@txtPlintharea422", oIncentiveVosA.txtPlintharea422);

            if (oIncentiveVosA.txtquery_coi != null)
                com.Parameters.AddWithValue("@txtquery_coi", oIncentiveVosA.txtquery_coi);

            if (oIncentiveVosA.txtvalue422 != null)
                com.Parameters.AddWithValue("@txtvalue422", oIncentiveVosA.txtvalue422);

            if (oIncentiveVosA.TextBox59 != null)
                com.Parameters.AddWithValue("@TextBox59", oIncentiveVosA.TextBox59);

            if (oIncentiveVosA.txt423guideline != null)
                com.Parameters.AddWithValue("@txt423guideline", oIncentiveVosA.txt423guideline);

            if (oIncentiveVosA.txtTSSFCnorms423 != null)
                com.Parameters.AddWithValue("@txtTSSFCnorms423", oIncentiveVosA.txtTSSFCnorms423);

            if (oIncentiveVosA.txtvalue424 != null)
                com.Parameters.AddWithValue("@txtvalue424", oIncentiveVosA.txtvalue424);

            if (oIncentiveVosA.created_by != null)
                com.Parameters.AddWithValue("@createdby", oIncentiveVosA.created_by);
            string test = Session["incentiveid"].ToString();

            if (oIncentiveVosA.incentiveid != null || oIncentiveVosA.incentiveid == null)
                com.Parameters.AddWithValue("@incentiveid", Session["incentiveid"].ToString());


            //if (oIncentiveVosA.lmv != null || oIncentiveVosA.lmv == null)
            //    com.Parameters.AddWithValue("@RDLMV", oIncentiveVosA.lmv);

            //if (oIncentiveVosA.womenmen != null || oIncentiveVosA.womenmen == null)
            //    com.Parameters.AddWithValue("@RDWOMENMEN", oIncentiveVosA.womenmen);

            if (oIncentiveVosA.eligibletype != null || oIncentiveVosA.eligibletype == null)
                com.Parameters.AddWithValue("@RDELIGIBLE", oIncentiveVosA.eligibletype);
            if (oIncentiveVosA.Remarks != null || oIncentiveVosA.Remarks == null)
                com.Parameters.AddWithValue("@Remarks", oIncentiveVosA.Remarks);

            if (oIncentiveVosA.MstIncentiveId != null || oIncentiveVosA.MstIncentiveId == null)
                com.Parameters.AddWithValue("@MstIncentiveId", oIncentiveVosA.MstIncentiveId);
            // -----------=====---------------

            if (oIncentiveVosA.WOODQUANTITY != null)
                com.Parameters.AddWithValue("@WOODQUANTITY", oIncentiveVosA.WOODQUANTITY);
            if (oIncentiveVosA.ELIGIBLEAMOUNT != null)
                com.Parameters.AddWithValue("@ELIGIBLEAMOUNT", oIncentiveVosA.ELIGIBLEAMOUNT);
            if (oIncentiveVosA.GMVALUE != null)
                com.Parameters.AddWithValue("@GMVALUE", oIncentiveVosA.GMVALUE);
            if (oIncentiveVosA.FINALSUBSIDYAMOUNT != null)
                com.Parameters.AddWithValue("@FINALSUBSIDYAMOUNT", oIncentiveVosA.FINALSUBSIDYAMOUNT);

            if (oIncentiveVosA.caste_IR != null)
                com.Parameters.AddWithValue("@caste_IR", oIncentiveVosA.caste_IR);
            if (oIncentiveVosA.gender_IR != null)
                com.Parameters.AddWithValue("@gender_IR", oIncentiveVosA.gender_IR);
            if (oIncentiveVosA.category_IR != null)
                com.Parameters.AddWithValue("@category_IR", oIncentiveVosA.category_IR);
            if (oIncentiveVosA.enterprisetype_IR != null)
                com.Parameters.AddWithValue("@enterprise_IR", oIncentiveVosA.enterprisetype_IR);
            if (oIncentiveVosA.sector_IR != null)
                com.Parameters.AddWithValue("@sector_IR", oIncentiveVosA.sector_IR);
            if (oIncentiveVosA.servicetype_IR != null)
                com.Parameters.AddWithValue("@serviceType_IR", oIncentiveVosA.servicetype_IR);
            if (oIncentiveVosA.transNonTrans_IR != null)
                com.Parameters.AddWithValue("@transportNonTrans_IR", oIncentiveVosA.transNonTrans_IR);


            com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();

            valid = com.Parameters["@Valid"].Value.ToString();
            if (valid == "1")
            {
                SaveIncentiveDetailsFromGridViewToTable(Session["incentiveid"].ToString());
            }

            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ValidateControls();
        if (save())
        {
            string message = "alert('Appraisal note submitted successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //..btn
            Button3.Enabled = false;
            Button1.Visible = false;
            Response.Redirect("HomeCoiDashboard.aspx");
        }
    }
    public void AssignValuestoVosFromcontrols()
    {
        //oIncentiveVosA = new IncentiveVosAppraisal();
        oIncentiveVosA.lblApplicationno = lblApplicationno.Text;
        oIncentiveVosA.txtunitnames = txtunitnames.Text;
        oIncentiveVosA.txtLocofUnit = txtLocofUnit.Text;
        oIncentiveVosA.ddlOrddlorgtypes = ddlOrddlorgtypes.SelectedIndex.ToString();
        oIncentiveVosA.ddlUdyogAadharType = ddlUdyogAadharType.SelectedIndex.ToString();
        oIncentiveVosA.txtPersonIndustry = txtPersonIndustry.Text;
        oIncentiveVosA.txtDateOfapplnFile = txtDateOfapplnFile.Text;
        oIncentiveVosA.txtLoanApplnNo = txtLoanApplnNo.Text;
        oIncentiveVosA.txtDate_Loan = txtDate_Loan.Text;
        oIncentiveVosA.txtNameofFinIns = txtNameofFinIns.Text;
        oIncentiveVosA.txtPowerConn_date = txtPowerConn_date.Text;
        oIncentiveVosA.txtPowerConn_load = txtPowerConn_load.Text;
        oIncentiveVosA.txtDCP_unit = txtDCP_unit.Text;
        oIncentiveVosA.txtrc_dic = txtrc_dic.Text;
        oIncentiveVosA.txtcompdate_dic = txtcompdate_dic.Text;
        oIncentiveVosA.txtquery_dic = txtquery_dic.Text;
        oIncentiveVosA.txtcompdate_coi = txtcompdate_coi.Text;
        oIncentiveVosA.txtcompdate_coi1 = txtcompdate_coi1.Text;
        oIncentiveVosA.txtLand2 = txtLand2.Text;
        oIncentiveVosA.txtLand3 = txtLand3.Text;
        oIncentiveVosA.txtLand4 = txtLand4.Text;
        oIncentiveVosA.txtLand5 = txtLand5.Text;
        oIncentiveVosA.txtLand6 = txtLand6.Text;
        oIncentiveVosA.txtLand7 = txtLand7.Text;
        oIncentiveVosA.txtBuilding2 = txtBuilding2.Text;
        oIncentiveVosA.txtBuilding3 = txtBuilding3.Text;
        oIncentiveVosA.txtBuilding4 = txtBuilding4.Text;
        oIncentiveVosA.txtBuilding5 = txtBuilding5.Text;
        oIncentiveVosA.txtBuilding6 = txtBuilding6.Text;
        oIncentiveVosA.txtBuilding7 = txtBuilding7.Text;
        oIncentiveVosA.txtPM2 = txtPM2.Text;
        oIncentiveVosA.txtPM3 = txtPM3.Text;
        oIncentiveVosA.txtPM4 = txtPM4.Text;
        oIncentiveVosA.txtPM5 = txtPM5.Text;
        oIncentiveVosA.txtPM6 = txtPM6.Text;
        oIncentiveVosA.txtPM7 = txtPM7.Text;
        oIncentiveVosA.txtMCont2 = txtMCont2.Text;
        oIncentiveVosA.txtMCont3 = txtMCont3.Text;
        oIncentiveVosA.txtMCont4 = txtMCont4.Text;
        oIncentiveVosA.txtMCont5 = txtMCont5.Text;
        oIncentiveVosA.txtMCont6 = txtMCont6.Text;
        oIncentiveVosA.txtMCont7 = txtMCont7.Text;
        oIncentiveVosA.txtErec2 = txtErec2.Text;
        oIncentiveVosA.txtErec3 = txtErec3.Text;
        oIncentiveVosA.txtErec4 = txtErec4.Text;
        oIncentiveVosA.txtErec5 = txtErec5.Text;
        oIncentiveVosA.txtErec6 = txtErec6.Text;
        oIncentiveVosA.txtErec7 = txtErec7.Text;
        oIncentiveVosA.txtTFS2 = txtTFS2.Text;
        oIncentiveVosA.txtTFS3 = txtTFS3.Text;
        oIncentiveVosA.txtTFS4 = txtTFS4.Text;
        oIncentiveVosA.txtTFS5 = txtTFS5.Text;
        oIncentiveVosA.txtTFS6 = txtTFS6.Text;
        oIncentiveVosA.txtTFS7 = txtTFS7.Text;
        oIncentiveVosA.txtWC2 = txtWC2.Text;
        oIncentiveVosA.txtWC3 = txtWC3.Text;
        oIncentiveVosA.txtWC4 = txtWC4.Text;
        oIncentiveVosA.txtWC5 = txtWC5.Text;
        oIncentiveVosA.txtWC6 = txtWC6.Text;
        oIncentiveVosA.txtWC7 = txtWC7.Text;
        oIncentiveVosA.txtLandcostCompc = txtLandcostCompc.Text;
        oIncentiveVosA.txtLandAreaCompc = txtLandAreaCompc.Text;
        oIncentiveVosA.txtPurchaCompc = txtPurchaCompc.Text;
        oIncentiveVosA.txtStmpDutyCompc = txtStmpDutyCompc.Text;
        oIncentiveVosA.txtRegnfeeCompc = txtRegnfeeCompc.Text;
        oIncentiveVosA.txtTotalCompc = txtTotalCompc.Text;
        oIncentiveVosA.txtBuildingAreCompc = txtBuildingAreCompc.Text;
        oIncentiveVosA.txtvalDICCompc = txtvalDICCompc.Text;
        oIncentiveVosA.txtvalCompc1 = txtvalCompc1.Text;
        oIncentiveVosA.txtresonsCompc = txtresonsCompc.Text;
        oIncentiveVosA.txtfacCostCompc = txtfacCostCompc.Text;
        oIncentiveVosA.txtfacBldgCompc = txtfacBldgCompc.Text;
        oIncentiveVosA.txtcivilEngCompc = txtcivilEngCompc.Text;
        oIncentiveVosA.txtsfcCompc = txtsfcCompc.Text;
        oIncentiveVosA.txtCAExpCompc = txtCAExpCompc.Text;
        oIncentiveVosA.txtCompvalCompc = txtCompvalCompc.Text;
        oIncentiveVosA.txtrsnCompc = txtrsnCompc.Text;
        oIncentiveVosA.TextBox30 = TextBox30.Text;
        oIncentiveVosA.TextBox32 = TextBox32.Text;
        oIncentiveVosA.TextBox31 = TextBox31.Text;
        oIncentiveVosA.TextBox34 = TextBox34.Text;
        oIncentiveVosA.TextBox36 = TextBox36.Text;
        oIncentiveVosA.TextBox38 = TextBox38.Text;
        oIncentiveVosA.TextBox40 = TextBox40.Text;
        oIncentiveVosA.TextBox42 = TextBox42.Text;
        oIncentiveVosA.TextBox47 = TextBox47.Text;
        oIncentiveVosA.TextBox33 = TextBox33.Text;
        oIncentiveVosA.TextBox37 = TextBox37.Text;
        oIncentiveVosA.TextBox41 = TextBox41.Text;
        oIncentiveVosA.TextBox44 = TextBox44.Text;
        oIncentiveVosA.TextBox1 = TextBox1.Text;
        oIncentiveVosA.TextBox56 = TextBox56.Text;
        oIncentiveVosA.TextBox57 = TextBox57.Text;
        oIncentiveVosA.TextBox58 = TextBox58.Text;
        oIncentiveVosA.TextBox45 = TextBox45.Text;
        oIncentiveVosA.TextBox2 = TextBox2.Text;
        oIncentiveVosA.TextBox35 = TextBox35.Text;
        oIncentiveVosA.TextBox39 = TextBox39.Text;
        oIncentiveVosA.TextBox43 = TextBox43.Text;
        oIncentiveVosA.TextBox46 = TextBox46.Text;
        oIncentiveVosA.TextBox48 = TextBox48.Text;
        oIncentiveVosA.txtContProdMgm = txtContProdMgm.Text;
        oIncentiveVosA.txt25BldgCvl = txt25BldgCvl.Text;
        oIncentiveVosA.txt822guideline422 = txt822guideline422.Text;
        oIncentiveVosA.txtTSSFCnorms422 = txtTSSFCnorms422.Text;
        oIncentiveVosA.txtPlintharea424 = txtPlintharea424.Text;
        oIncentiveVosA.txtPlintharea422 = txtPlintharea422.Text;
        oIncentiveVosA.txtquery_coi = txtquery_coi.Text;
        oIncentiveVosA.txtvalue422 = txtvalue422.Text;
        //oIncentiveVosA.TextBox59 = TextBox59.Text;
        //oIncentiveVosA.txt423guideline = txt423guideline.Text;
        //oIncentiveVosA.txtTSSFCnorms423 = txtTSSFCnorms423.Text;
        oIncentiveVosA.txtvalue424 = txtvalue424.Text;

        oIncentiveVosA.created_by = Session["uid"].ToString();
        oIncentiveVosA.incentiveid = Session["incentiveid"].ToString();
        oIncentiveVosA.TextBox60 = TextBox60.Text;
        oIncentiveVosA.TextBox5 = TextBox5.Text;
        oIncentiveVosA.TextBox7 = TextBox7.Text;
        oIncentiveVosA.TextBox9 = TextBox9.Text;
        oIncentiveVosA.TextBox11 = TextBox11.Text;
        oIncentiveVosA.TextBox13 = TextBox13.Text;
        oIncentiveVosA.TextBox15 = TextBox15.Text;
        oIncentiveVosA.TextBox17 = TextBox17.Text;
        oIncentiveVosA.TextBox18 = TextBox18.Text;
        oIncentiveVosA.TextBox19 = TextBox19.Text;

        oIncentiveVosA.TextBox61 = TextBox61.Text;
        oIncentiveVosA.TextBox6 = TextBox6.Text;
        oIncentiveVosA.TextBox8 = TextBox8.Text;
        oIncentiveVosA.TextBox10 = TextBox10.Text;
        oIncentiveVosA.TextBox12 = TextBox12.Text;
        oIncentiveVosA.TextBox14 = TextBox14.Text;
        oIncentiveVosA.TextBox16 = TextBox16.Text;
        oIncentiveVosA.TextBox20 = TextBox20.Text;

        //oIncentiveVosA.lmv = rdlmv.SelectedValue;
        //oIncentiveVosA.womenmen = rdmenwomen.SelectedValue;

        oIncentiveVosA.Remarks = txtremarks.Text;
        oIncentiveVosA.MstIncentiveId = "19";// Request.QueryString["MstIncentiveId"].ToString();
        oIncentiveVosA.WOODQUANTITY = Convert.ToDecimal(TXTWOODQUANTITY.Text);
        oIncentiveVosA.ELIGIBLEAMOUNT = Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text);
        oIncentiveVosA.GMVALUE = Convert.ToDecimal(txtgmRecommend.Text);
        oIncentiveVosA.FINALSUBSIDYAMOUNT = Convert.ToDecimal(TXTFINALSUBSIDYAMOUNT.Text);

        oIncentiveVosA.caste_IR = rdbCaste.SelectedValue.ToString();

        oIncentiveVosA.gender_IR = rdbGender.SelectedValue.ToString();

        oIncentiveVosA.category_IR = rdbCategory.SelectedValue.ToString();

        oIncentiveVosA.enterprisetype_IR = rdbEnterprise.SelectedValue.ToString();

        oIncentiveVosA.sector_IR = rdbSector.SelectedValue.ToString();

        oIncentiveVosA.servicetype_IR = rdbServiceType.SelectedValue.ToString();

        oIncentiveVosA.transNonTrans_IR = rdbTransportNonTrans.SelectedValue.ToString();


    }
    //business logic
    public class IncentiveVosAppraisalStamp
    {
        public string lblApplicationno { get; set; } //	int	4
        public string txtunitnames { get; set; } //	varchar	20
        public string txtLocofUnit { get; set; } //	int	4
        public string ddlOrddlorgtypes { get; set; } //	int	4
        public string ddlUdyogAadharType { get; set; } //	decimal	9
        public string txtPersonIndustry { get; set; } //	decimal	9
        public string txtDateOfapplnFile { get; set; } //	decimal	9
        public string txtLoanApplnNo { get; set; } //	decimal	9
        public string txtDate_Loan { get; set; } //	decimal	9
        public string txtNameofFinIns { get; set; } //	decimal	9
        public string txtDCP_unit { get; set; } //	decimal	9
        public string txtrc_dic { get; set; } //	decimal	9
        public string txtPowerConn_date { get; set; } //	decimal	9
        public string txtPowerConn_load { get; set; } //	decimal	9
        public string txtquery_dic { get; set; } //	decimal	9
        public string txtcompdate_dic { get; set; } //	decimal	9
        public string txtcompdate_coi { get; set; } //	decimal	9
        public string txtquery_coi { get; set; } //	decimal	9
        public string txtcompdate_coi1 { get; set; } //	decimal	9
        public string txtLand2 { get; set; } //	decimal	9
        public string txtLand3 { get; set; } //	decimal	9
        public string txtLand4 { get; set; } //	decimal	9
        public string txtLand5 { get; set; } //	decimal	9
        public string txtLand6 { get; set; } //	decimal	9
        public string txtLand7 { get; set; } //	decimal	9
        public string txtBuilding2 { get; set; } //	decimal	9
        public string txtBuilding3 { get; set; } //	decimal	9
        public string txtBuilding4 { get; set; } //	decimal	9
        public string txtBuilding5 { get; set; } //	decimal	9
        public string txtBuilding6 { get; set; } //	decimal	9
        public string txtBuilding7 { get; set; } //	decimal	9
        public string txtPM2 { get; set; } //	decimal	9
        public string txtPM3 { get; set; } //	decimal	9
        public string txtPM4 { get; set; } //	decimal	9
        public string txtPM5 { get; set; } //	decimal	9
        public string txtPM6 { get; set; } //	decimal	9
        public string txtPM7 { get; set; } //	decimal	9
        public string txtMCont2 { get; set; } //	decimal	9
        public string txtMCont3 { get; set; } //	decimal	9
        public string txtMCont4 { get; set; } //	decimal	9
        public string txtMCont5 { get; set; } //	decimal	9
        public string txtMCont6 { get; set; } //	decimal	9
        public string txtMCont7 { get; set; } //	decimal	9
        public string txtErec2 { get; set; } //	decimal	9
        public string txtErec3 { get; set; } //	decimal	9
        public string txtErec4 { get; set; } //	decimal	9
        public string txtErec5 { get; set; } //	int	4
        public string txtErec6 { get; set; } //	datetime	8
        public string txtErec7 { get; set; } //	int	4
        public string txtTFS2 { get; set; } //	datetime	8
        public string txtTFS3 { get; set; }
        public string txtTFS4 { get; set; }
        public string txtTFS5 { get; set; }
        public string txtTFS6 { get; set; }
        public string txtTFS7 { get; set; }
        public string txtWC2 { get; set; }
        public string txtWC3 { get; set; }
        public string txtWC4 { get; set; }
        public string txtWC5 { get; set; }
        public string txtWC6 { get; set; }
        public string txtWC7 { get; set; }
        public string txtLandcostCompc { get; set; }
        public string txtLandAreaCompc { get; set; }
        public string txtPurchaCompc { get; set; }
        public string txtStmpDutyCompc { get; set; }
        public string txtRegnfeeCompc { get; set; }
        public string txtTotalCompc { get; set; }
        public string txtBuildingAreCompc { get; set; }
        public string txtvalDICCompc { get; set; }
        public string txtvalCompc1 { get; set; }
        public string txtresonsCompc { get; set; }
        public string txtfacCostCompc { get; set; }
        public string txtfacBldgCompc { get; set; }
        public string txtcivilEngCompc { get; set; }
        public string txtsfcCompc { get; set; }
        public string txtCAExpCompc { get; set; }
        public string txtCompvalCompc { get; set; }
        public string txtrsnCompc { get; set; }
        public string TextBox33 { get; set; }
        public string TextBox30 { get; set; }
        public string TextBox32 { get; set; }
        public string TextBox31 { get; set; }
        public string TextBox34 { get; set; }
        public string TextBox36 { get; set; }
        public string TextBox38 { get; set; }
        public string TextBox40 { get; set; }
        public string TextBox42 { get; set; }
        public string TextBox47 { get; set; }
        public string TextBox37 { get; set; }
        public string TextBox41 { get; set; }
        public string TextBox44 { get; set; }
        public string TextBox1 { get; set; }
        public string TextBox56 { get; set; }
        public string TextBox57 { get; set; }
        public string TextBox58 { get; set; }
        public string TextBox45 { get; set; }
        public string TextBox2 { get; set; }
        public string TextBox35 { get; set; }
        public string TextBox39 { get; set; }
        public string TextBox43 { get; set; }
        public string TextBox46 { get; set; }
        public string TextBox48 { get; set; }
        public string txtContProdMgm { get; set; }
        public string txt25BldgCvl { get; set; }
        public string txt822guideline422 { get; set; }
        public string txtTSSFCnorms422 { get; set; }
        public string txtPlintharea424 { get; set; }
        public string txtPlintharea422 { get; set; }
        public string txtvalue422 { get; set; }
        public string TextBox59 { get; set; }
        public string txt423guideline { get; set; }
        public string txtTSSFCnorms423 { get; set; }
        public string txtvalue424 { get; set; }
        public string created_dt { get; set; }
        public string created_by { get; set; }
        public string incentiveid { get; set; }
        public string TextBox60 { get; set; }
        public string TextBox5 { get; set; }
        public string TextBox7 { get; set; }
        public string TextBox9 { get; set; }
        public string TextBox11 { get; set; }
        public string TextBox13 { get; set; }
        public string TextBox15 { get; set; }
        public string TextBox17 { get; set; }
        public string TextBox18 { get; set; }
        public string TextBox19 { get; set; }
        public string TextBox61 { get; set; }
        public string TextBox6 { get; set; }
        public string TextBox8 { get; set; }
        public string TextBox10 { get; set; }
        public string TextBox12 { get; set; }
        public string TextBox14 { get; set; }
        public string TextBox16 { get; set; }
        public string TextBox20 { get; set; }
        public string lmv { get; set; }
        public string womenmen { get; set; }
        public string eligibletype { get; set; }
        public string Remarks { get; set; }
        public string MstIncentiveId { get; set; }
        public Decimal? WOODQUANTITY { get; set; }
        public Decimal? ELIGIBLEAMOUNT { get; set; }
        public Decimal? GMVALUE { get; set; }
        public Decimal? FINALSUBSIDYAMOUNT { get; set; }

        public string caste_IR { get; set; }
        public string gender_IR { get; set; }
        public string category_IR { get; set; }
        public string enterprisetype_IR { get; set; }
        public string sector_IR { get; set; }
        public string servicetype_IR { get; set; }

        public string transNonTrans_IR { get; set; }


    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtunitnames.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Unit name \\n";
            slno = slno + 1;
        }
        if (txtLocofUnit.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Location of the unit \\n";
            slno = slno + 1;
        }
        if (ddlOrddlorgtypes.SelectedIndex == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select costitution of the unit \\n";
            slno = slno + 1;
        }
        if (txtPersonIndustry.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter PMT/SSI/IEM acknowledgement\\n";
            slno = slno + 1;
        }
        if (gvInstalledCap.Rows.Count == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter line of activity\\n";
            slno = slno + 1;
        }
        if (txtDateOfapplnFile.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter date of filing of application\\n";
            slno = slno + 1;
        }
        if (txtLoanApplnNo.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter In case term loan obtained from the Financial Institution/Bank Term loan \\n";
            slno = slno + 1;
        }
        if (txtDate_Loan.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter In case term loan obtained from the Financial Institution/Bank Term loan - Date  \\n";
            slno = slno + 1;
        }
        if (txtPowerConn_date.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Power connection with connected load - date\\n";
            slno = slno + 1;
        }
        if (txtPowerConn_load.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Power connection with connected load\\n";
            slno = slno + 1;
        }

        if (txtNameofFinIns.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Financing Institution\\n";
            slno = slno + 1;
        }
        if (txtDCP_unit.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of Commencement of Commercial production \\n";
            slno = slno + 1;
        }
        if (txtrc_dic.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of receipt of claim application(in DIC)\\n";
            slno = slno + 1;
        }

        // Address
        if (txtquery_dic.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of communication of shortfalls to the party(in DIC)\\n";
            slno = slno + 1;
        }
        if (txtcompdate_dic.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of receipt of complete information from the party(in DIC)\\n";
            slno = slno + 1;
        }


        if (txtcompdate_coi.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of receipt of claim application(in COI)\\n";
            slno = slno + 1;
        }

        if (txtcompdate_coi1.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of receipt of complete information from the party (in COI)\\n";
            slno = slno + 1;
        }
        if (txtquery_coi.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Date of communication of shortfalls to the party(in COI)\\n";
            slno = slno + 1;
        }
        if (txtLand2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtLand3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtLand4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtLand5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtLand6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtLand7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
            slno = slno + 1;
        }
        if (txtBuilding2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtBuilding3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtBuilding4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtBuilding5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtBuilding6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtBuilding7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
            slno = slno + 1;
        }
        if (txtPM2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtPM3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtPM4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtPM5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtPM6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtPM7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
            slno = slno + 1;
        }
        if (txtMCont2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }
        if (txtMCont3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }
        if (txtMCont4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }
        if (txtMCont5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }
        if (txtMCont6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }
        if (txtMCont7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
            slno = slno + 1;
        }

        if (txtErec2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtErec3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtErec4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtErec5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtErec6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtErec7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
            slno = slno + 1;
        }
        if (txtTFS2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtWC2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtTFS5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtTFS7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
            slno = slno + 1;
        }
        if (txtWC2.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC3.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC4.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtWC7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
            slno = slno + 1;
        }
        if (txtLandcostCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtPurchaCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtStmpDutyCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtRegnfeeCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtTotalCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtBuildingAreCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtvalDICCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtvalCompc1.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtresonsCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
            slno = slno + 1;
        }
        if (txtfacCostCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtfacBldgCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtcivilEngCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtsfcCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtCAExpCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtCompvalCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (txtrsnCompc.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
            slno = slno + 1;
        }
        if (TextBox30.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox32.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox31.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox34.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox36.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox38.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox40.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox42.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox47.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
            slno = slno + 1;
        }
        if (TextBox33.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Landas per approved costs \\n";
            slno = slno + 1;
        }
        if (TextBox37.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Buildingas per approved costs \\n";
            slno = slno + 1;
        }
        if (TextBox41.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Plant and Machineryas per approved costs \\n";
            slno = slno + 1;
        }
        if (TextBox44.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Know-how feasibility studyas per approved costs \\n";
            slno = slno + 1;
        }
        if (TextBox56.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
            slno = slno + 1;
        }
        if (TextBox57.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
            slno = slno + 1;
        }
        if (TextBox58.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
            slno = slno + 1;
        }
        if (TextBox45.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
            slno = slno + 1;
        }
        if (TextBox35.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
            slno = slno + 1;
        }
        if (TextBox39.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
            slno = slno + 1;
        }
        if (TextBox43.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
            slno = slno + 1;
        }
        if (TextBox46.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
            slno = slno + 1;
        }
        if (TextBox48.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
            slno = slno + 1;
        }
        if (txt25BldgCvl.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (txt822guideline422.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (txtTSSFCnorms422.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (txtPlintharea424.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all valuecalleventforbackups of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (txtPlintharea422.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (txtvalue422.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
            slno = slno + 1;
        }
        if (TextBox60.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }

        if (TextBox5.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox7.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox9.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox11.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox13.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox15.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox17.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox18.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox19.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox61.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox6.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox11.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox13.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox15.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox17.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox18.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }
        if (TextBox19.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
            slno = slno + 1;
        }




        return ErrorMsg;
    }
    protected void TextBox61_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnINCSearch_Click(object sender, EventArgs e)
    {
        if (txtINCNoEntry.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        }
        else
        {
            //if()
            incentiveid = txtINCNoEntry.Text.ToString();
            Session["incentiveid"] = incentiveid.ToString();
            mstincentiveid = "19";

            //mstincentiveid = Request.QueryString["mstid"].ToString()/*;*/
            dtMyTableCertificate = createtablecrtificate1();
            Session["CertificateTb2"] = dtMyTableCertificate;
            BindConstitutionUnit();
            USP_GETDETAILSFORSECTION();
            getUdyogAadharType1();
            calleventforbackup(Session["incentiveid"].ToString());
            btnINCSearch.Enabled = false;

        }

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        printTD.Visible = true;

        if (txtINCNoEntry.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        }




        //if(txtPrintINCID.Text=="")
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        //}
        else
        {
            //    string incID = txtPrintINCID.Text;

            //    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            //    SqlTransaction transaction = null; connection.Open();
            //    transaction = connection.BeginTransaction();
            //    string testss = Session["incentiveid"].ToString();

            //    string testss1 = Session["uid"].ToString();

            //    SqlCommand com = new SqlCommand();
            //    com.CommandType = CommandType.StoredProcedure;
            //    com.CommandText = "[checkiincAppraisal]";

            //    com.Transaction = transaction;
            //    com.Connection = connection;

            //    com.Parameters.AddWithValue("@lineofact", Manf_ItemName.ToString());
            //    com.Parameters.AddWithValue("@lineofact_unit", strunit.ToString());
            //    com.Parameters.AddWithValue("@lineofact_qty", Manf_Item_Qty.ToString());
            //    com.Parameters.AddWithValue("@lineofact_instCap", Manf_units.ToString());
            //    com.Parameters.AddWithValue("@lineofact_value", Manf_Item_Price.ToString());
            //    com.Parameters.AddWithValue("@incentiveid", testss.ToString());
            //    com.Parameters.AddWithValue("@createdby", testss1.ToString());
            //    com.Parameters.AddWithValue("@updDel", updDelete.ToString());
            //    //com.Parameters.Add("@retval", SqlDbType.Int);
            //    //com.Parameters["@retval"].Direction = ParameterDirection.Output;

            //    //com.ExecuteNonQuery();

            //    //com.ExecuteNonQuery();
            //    //int iCount = 

            //    //object retval =  com.ExecuteScalar();

            //    string firstColumn = Convert.ToString(com.ExecuteScalar());

            //    transaction.Commit();
            //    string retvals = firstColumn.ToString();
            //    //com.ExecuteNonQuery();
            //    //string retval = com.Parameters["@rretVAl"].Value.ToString();

            //    if (retvals == "not done")
            //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity already exists!');", true);


            //    //if (retval == "deleted")
            //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity deleted');", true);
            Response.Redirect("appraisalNote_is.aspx?incid=" + txtINCNoEntry.Text.ToString() + "&mstid=5");
        }


    }
    protected void txtTSSFCnorms423_TextChanged(object sender, EventArgs e)
    {
        //txtvalue424.Text = (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();
    }

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PCBClass objPCB = new PCBClass();
        comFunctions cmf = new comFunctions();
        General Gen = new General();

        string newPath = "";

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = txtINCNoEntry.Text;// Session["EntprIncentive"].ToString();
            string masterincentiveid = "19";
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + "\\ADWORKSHEET" + "\\" + incentiveid.ToString() + "\\" + masterincentiveid.ToString());
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "100018", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachmentInspReports(incentiveid, "100024", sFileName, serverpath, CrtdUser, masterincentiveid.ToString(), "WorkSheet");

                        lblFileName.NavigateUrl = serverpath + sFileName;
                        lblFileName.Text = sFileName;
                        lblFileName.Visible = true;
                        success.Visible = true;
                        lblmsg.Text = "File uploaded successfully.";
                        Failure.Visible = false;
                        //troptpbutton.Visible = true;
                    }
                    else
                    {
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
    public int InsertincentiveOfficerCommentsAD(List<officerRemarks> Ramarks, List<officerForwarded> lstincentives, string IPAddress)
    {
        int valid = 0;

        foreach (officerRemarks Ramarksvo in Ramarks)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("[USP_INSERT_OfficerRemarks_AD_TEST]", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@EnterperIncentiveID", Convert.ToString(Ramarksvo.EnterperIncentiveID));
                cmd.Parameters.AddWithValue("@MstIncentiveId", Convert.ToString(Ramarksvo.MstIncentiveId));
                cmd.Parameters.AddWithValue("@Remarks", Convert.ToString(Ramarksvo.Remarks));
                cmd.Parameters.AddWithValue("@status", Convert.ToString(Ramarksvo.status));
                cmd.Parameters.AddWithValue("@CreatedByid", Convert.ToString(Ramarksvo.CreatedByid));
                cmd.Parameters.AddWithValue("@id", Convert.ToString(Ramarksvo.id));
                cmd.Parameters.AddWithValue("@Designation", Convert.ToString(Ramarksvo.Designation));
                cmd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
                cmd.Parameters.AddWithValue("@AD_RECON_AMOUNT", Convert.ToString(Ramarksvo.Recomamount));
                cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                valid = (Int32)cmd.Parameters["@Valid"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        return valid;
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
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCoiDashboardclerk.aspx");// + hdfID.Value
    }
    protected void rdbCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCaste.SelectedIndex == 0 || rdbCaste.SelectedIndex == 1 || rdbCaste.SelectedIndex == 2 || rdbCaste.SelectedIndex == 3)
        {
            rdbCaste.Enabled = false;
            rdbGender.Enabled = true;

        }
    }
    protected void rdbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbGender.SelectedIndex == 0 || rdbGender.SelectedIndex == 1)
        {
            rdbGender.Enabled = false;
            rdbCategory.Enabled = true;

        }
    }
    protected void rdbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCategory.SelectedIndex == 0 || rdbCategory.SelectedIndex == 1 || rdbCategory.SelectedIndex == 2 || rdbCategory.SelectedIndex == 3 || rdbCategory.SelectedIndex == 4)
        {
            rdbCategory.Enabled = false;
            rdbEnterprise.Enabled = true;

        }
    }
    protected void rdbEnterprise_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbEnterprise.SelectedIndex == 0 || rdbEnterprise.SelectedIndex == 1)
        {
            rdbEnterprise.Enabled = false;
            rdbSector.Enabled = true;

        }
    }
    protected void rdbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbSector.SelectedIndex == 0 || rdbSector.SelectedIndex == 1)
        {
            rdbSector.Enabled = false;
            if (rdbSector.SelectedIndex != 0)
            {
                casteGenderGmUpdate = "Y";
                ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;

                trsubmit.Visible = true;
            }
            else
            {
                trsubmit.Visible = false;
                trServiceType.Visible = true;
                rdbTransportNonTrans.Enabled = true;
            }

            //trForwardApplicationTo.Visible = true;
            //trForwardGMGrid.Visible = true;
            //trFowardNote.Visible = true;

        }
    }
    protected void rdbTransportNonTrans_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbTransportNonTrans.Enabled = false;
        casteGenderGmUpdate = "Y";
        ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
        trsubmit.Visible = true;
        trTransNonTrans.Visible = true;
    }

    protected void rdbServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbServiceType.Enabled = false;
        rdbTransportNonTrans.Enabled = true;
        trTransNonTrans.Visible = true;
        rdbTransportNonTrans.Enabled = true;
    }  
    protected void TXTWOODQUANTITY_TextChanged(object sender, EventArgs e)
    {
        TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTWOODQUANTITY.Text) * 1000).ToString();
        if (Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) <= Convert.ToDecimal(txtgmRecommend.Text))
        {
            TXTFINALSUBSIDYAMOUNT.Text = TXTELIGIBLEAMOUNT.Text;
        }
        if (Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) > Convert.ToDecimal(txtgmRecommend.Text))
        {
            TXTFINALSUBSIDYAMOUNT.Text = txtgmRecommend.Text;
        }
    }
}