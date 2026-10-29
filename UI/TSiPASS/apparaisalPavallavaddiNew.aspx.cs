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

public partial class UI_TSiPASS_apparaisalPavallavaddiNew : System.Web.UI.Page
{
    Cls_pallavaddi obj_pallavaddi = new Cls_pallavaddi();
    DB.DB con = new DB.DB();
    public string incentiveid;
    public string mstincentiveid;
    static DataTable dtMyTableCertificate;
    static DataTable dtMyTable1;
    DataTable myDtNewRecdr = new DataTable();
    pallavadiproperties oIncentiveVosA = new pallavadiproperties();
    //IncentiveVosAppraisal oIncentiveVosA = new IncentiveVosAppraisal();
    List<officerRemarks> lstremarksad = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string incentiveid = "56276";
            // string incentiveid = "85769";
            //string incentiveid = "33709";
            string MstIncentiveId = "1";

            //string incentiveid = "75884";
            //string incentiveid = "87725";
            //string incentiveid = "61043";

            // string incentiveid = "84976"; //DHANALAXMI RICE INDUSTRIES

            // string incentiveid = "14444"; //M/S SADASHIVA OIL INDUSTRIES
            string incentiveid = "112523"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "33216"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "46602"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "58419"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "66036"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "76376"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "89832"; //M/S SADASHIVA OIL INDUSTRIES

            //string incentiveid = "51407"; //SPM POWER AND TELECOM PRIVATE LIMITED
            // string incentiveid = "62033"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "77548"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "77553"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "92266"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "92274"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "136977"; //SPM POWER AND TELECOM PRIVATE LIMITED
            //string incentiveid = "136977"; //SPM POWER AND TELECOM PRIVATE LIMITED

            //string incentiveid = Request.QueryString["incentiveid"].ToString();
            //string MstIncentiveId = Request.QueryString["MstIncentiveId"].ToString();
            USP_GETDETAILSFORSECTION(incentiveid, MstIncentiveId);
            txtINCNoEntry.Text = incentiveid;
            btnINCSearch_Click(sender, e);
            BindgetFYClaimperiod();
            GetYearName_DB();
        }
    }


    #region binding the data on page load
    public void BindConstitutionUnit()
    {
        try
        {
            DataSet oDataSet = obj_pallavaddi.DB_BindConstitutionUnitpallavadi();
            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                ddlOrddlorgtypes.DataSource = oDataSet.Tables[0];
                ddlOrddlorgtypes.DataValueField = "CunitId";
                ddlOrddlorgtypes.DataTextField = "ConstitutionUnit";
                ddlOrddlorgtypes.DataBind();
                //ddlOrddlorgtypes.Items.Insert(0, "--Select--");
                AddSelect(ddlOrddlorgtypes);
            }
            else
            {
                // ddlOrddlorgtypes.Items.Insert(0, "--Select--");
                AddSelect(ddlOrddlorgtypes);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void getUdyogAadharType1()
    {
        DataSet ds = new DataSet();
        ds = obj_pallavaddi.DB_tUdyogAadharTypepallavadi();

        ddlUdyogAadharType.DataSource = ds.Tables[0];
        ddlUdyogAadharType.DataTextField = "Name";
        ddlUdyogAadharType.DataValueField = "Slno";
        ddlUdyogAadharType.DataBind();
        AddSelect(ddlUdyogAadharType);

    }

    public void USP_GETDETAILSFORSECTION(string IncentiveId, string MasterIncentiveId)
    {
        DataSet ds = obj_pallavaddi.DB_USP_GETDETAILSFORSECTIONpallavadi(IncentiveId, MasterIncentiveId);
        getLOAData(IncentiveId);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["socialStatus"] = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
            lblApplicationno.Text = ds.Tables[0].Rows[0]["incApplnNo"].ToString();
            txtunitnames.Text = ds.Tables[0].Rows[0]["NameOfIndustrial"].ToString();

            txtLocofUnit.Text = ds.Tables[0].Rows[0]["LocationOfIndustrial"].ToString();
            //ddlOrddlorgtypes.SelectedItem.Text = ds.Tables[0].Rows[0]["ConstitutionOfIndustrial"].ToString();
            ddlOrddlorgtypes.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["consunitid"]);
            ddlUdyogAadharType.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["SSIApprovalofIEM"].ToString());
            txtPersonIndustry.Text = ds.Tables[0].Rows[0]["lblAcknoledgementLIORIL"].ToString();
            lblAllwomen.Value = ds.Tables[0].Rows[0]["allwomen"].ToString();

            //--------------------Initaial Steps Taken For Project Implementation---------------------
            txtDateOfapplnFile.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfFilingOfAppln"]).ToString("dd/MM/yyyy");
            txtLoanApplnNo.Text = ds.Tables[0].Rows[0]["BankSanctionLetter_No"].ToString();
            if (ds.Tables[0].Rows[0]["BankSanction_Date"].ToString() != "" && ds.Tables[0].Rows[0]["BankSanction_Date"].ToString() != "NA")
                txtDate_Loan.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["BankSanction_Date"]).ToString("dd/MM/yyyy");
            else
                txtDate_Loan.Text = "NA";
            if (ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString() != "")
                if (ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString() != "")
                    if ((ds.Tables[0].Rows[0]["NewPowerReleaseDate"]).ToString() != "NA")
                        txtPowerConn_date.Text =
                        Convert.ToDateTime(ds.Tables[0].Rows[0]["NewPowerReleaseDate"]).ToString("dd/MM/yyyy");
                    else
                        txtPowerConn_date.Text = "NA";

            txtPowerConn_load.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();

            if (ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"].ToString() != "")
            {
                txtDCP_unit.Text =
               Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
                txt_DateofCommencementofactivity.Text =
                    Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
            }
            else
            {
                txtDCP_unit.Text = "";
                txt_DateofCommencementofactivity.Text = "";
            }


            if (ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"].ToString() != "")
            {
                txtrc_dic.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"]).ToString("dd/MM/yyyy");  //same date as application filed date..         
            }

            else
                txtrc_dic.Text = "";


            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "New")
            {
                Session["IdsustryStatus"] = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();

            }
            else if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Expansion")
            {



                Session["IdsustryStatus"] = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();


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

                txtWC2.Text = "";

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



                //---------------------Computation of Capital Cost-  ----------A.LAND----------------------------------------
                if (ds.Tables[0].Rows[0]["Land_ValueRecommendedByGM"].ToString() != null)
                {
                    txtLandcostCompc.Text = "0";
                    TextBox56.Text = "0";
                }

                else
                {
                    txtLandcostCompc.Text = "0";
                    TextBox56.Text = "0";

                }



                if (ds.Tables[0].Rows[0]["Building_ValueRecommendedByGM"].ToString() != null)
                {
                    txtfacCostCompc.Text = "0";
                    TextBox57.Text = "0";
                }

                else
                {
                    txtfacCostCompc.Text = "0";
                    TextBox57.Text = "0";
                }
                if (ds.Tables[0].Rows[0]["ProjcostPlant"].ToString() != null)
                {
                    TextBox30.Text = "0";
                    TextBox58.Text = "0";
                }
                else
                {
                    TextBox30.Text = "0";
                    TextBox58.Text = "0";
                }

                txtLandAreaCompc.Text = "0";
                txtPurchaCompc.Text = "0";
                txtStmpDutyCompc.Text = "0";
                txtRegnfeeCompc.Text = "0";
                txtTotalCompc.Text = "0";
                txtBuildingAreCompc.Text = "0";
                txtvalDICCompc.Text = "0";
                txtvalCompc1.Text = "0";

                //------------------------------B.FACTORY---------------------------------------------------------------------

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
                Session["GM_Rcon_Amount"] = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();


                TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();

                TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
                if (ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString() != null)
                {
                    txt_GMrecommendedamount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                }
            }


        }
    }

    public void getLOAData(string ds1)
    {
        DataSet ds = new DataSet();
        ds = obj_pallavaddi.DB_getLOADatapallavadi(ds1);
        gvInstalledCap.Visible = true;
        gvInstalledCap.DataSource = ds;
        gvInstalledCap.DataBind();
    }

    protected void btnINCSearch_Click(object sender, EventArgs e)
    {
        if (txtINCNoEntry.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        }
        else
        {
            incentiveid = txtINCNoEntry.Text.ToString();
            Session["incentiveid"] = incentiveid.ToString();
            mstincentiveid = "1";
            dtMyTableCertificate = createtablecrtificate1();
            Session["CertificateTb2"] = dtMyTableCertificate;
            BindConstitutionUnit();
            USP_GETDETAILSFORSECTION(Session["incentiveid"].ToString(), mstincentiveid);
            getUdyogAadharType1();
            calleventforbackup(Session["incentiveid"].ToString());

        }

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

    public void BindgetFYClaimperiod()
    {
        try
        {
            DataSet oDataSet = obj_pallavaddi.DB_getFYClaimperiod(Convert.ToString(Session["incentiveid"]));
            if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
            {
                ddl_ClaimPeriod.DataSource = oDataSet.Tables[0];
                ddl_ClaimPeriod.DataValueField = "FinancialYearID";
                ddl_ClaimPeriod.DataTextField = "FinancialYearName";
                ddl_ClaimPeriod.DataBind();
                ddl_ClaimPeriod.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region on auto post back
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (txtINCNoEntry.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter incentive id');", true);
        }
        Response.Redirect("appraisalNote_is.aspx?incid=" + txtINCNoEntry.Text.ToString() + "&mstid=15");
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
    protected void btnInstalledcap_Click(object sender, EventArgs e)
    {
        AddDataToTableCeertificate(txtLOActivity.Text.ToString(), txtunit.Text.ToString(), ddlquantityin.SelectedItem.Text.ToString(), txtinstalledccap.Text.ToString(), txtvalue.Text.ToString(), "Y");
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
            string firstColumn = Convert.ToString(com.ExecuteScalar());

            transaction.Commit();
            string retvals = firstColumn.ToString();
            if (retvals == "not done")
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Line of activity already exists!');", true);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void btn_cancelproductactivity_Click(object sender, EventArgs e)
    {
        ClearTxt();
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

    public void ClearTxt()
    {
        txtLOActivity.Text = "";
        txtunit.Text = "";
        txtinstalledccap.Text = "";
        txtvalue.Text = "";
    }

    #endregion

    #region on auto post back of Abstarct
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


    #endregion


    #region  

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

    public bool save()
    {
        AssignValuestoVosFromcontrols();
        string returnval = obj_pallavaddi.INSERT_INCENTIVES_DATA_COMMON_appraisal_PAVALLAVADDI(oIncentiveVosA);

        //string returnval = InsertCommonData(oIncentiveVosA);
        if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
        {
            //line of activity
            SaveIncentiveDetailsFromGridViewToTable(Session["incentiveid"].ToString());
            insertgriddatadb(returnval);
            lstremarksad.Clear();
            string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
            officerRemarks fromvo = new officerRemarks();
            fromvo.EnterperIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text.ToString();

            fromvo.MstIncentiveId = "3";
            fromvo.id = "";// ((Label)gvrow.FindControl("Label60")).Text.ToString();
            fromvo.status = "Recomm";
            fromvo.CreatedByid = oIncentiveVosA.createdby;// ((Label)gvrow.FindControl("Label59")).Text.ToString();
            fromvo.Designation = Role_Code.Trim();
            lstremarksad.Add(fromvo);
            officerForwarded frmvo = new officerForwarded();
            string lblMstIncentiveId = "3";
            string lblIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text;
                                                               //IncentiveID = lblIncentiveID;
            frmvo.EnterperIncentiveID = lblIncentiveID;
            frmvo.MstIncentiveId = lblMstIncentiveId;
            frmvo.CreatedByid = Session["uid"].ToString();
            frmvo.ApplicationFrom = Session["uid"].ToString();
            lstincentives.Add(frmvo);
            int valid = 0;
            valid = InsertincentiveOfficerCommentsAD(lstremarksad, lstincentives, getclientIP());
            return true;
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "message", message, true);
            return false;
        }

    }

    public bool insertgriddatadb(string SUBPallvaid)
    {
        bool checkstatus = true;
        pallavadisubproperties objgriduploads = new pallavadisubproperties();

        objgriduploads.INCENTIVEID = Convert.ToString(Session["incentiveid"]);
        objgriduploads.SUBPallvaid = Convert.ToInt16(SUBPallvaid);
        objgriduploads.PERIODOFINSTALMENT_MAINTABLE = Convert.ToString(ddl_periodofinstallment.SelectedValue);
        objgriduploads.NOOFINSTALLMENTS_MAINTABLE = Convert.ToString(txt_noofinstallment.Text);
        objgriduploads.InstallmentAmount = Convert.ToDecimal(txt_Installmentamount.Text);
        objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        objgriduploads.ACTUALINTERESTAMOUNTPAID = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
        objgriduploads.INTERESTREIMBERSEMENTCALCULATED = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
        objgriduploads.ELIGIBLETYPE = Convert.ToString(rbtgrd_isbelated.SelectedValue);
        objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        objgriduploads.GMRECOMMENDEDAMOUNT = Convert.ToDecimal(txt_GMrecommendedamount.Text);
        objgriduploads.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
        objgriduploads.IPADDRESS = Request.ServerVariables["Remote_Addr"];
        objgriduploads.CREATED_BY = Convert.ToString(Session["uid"]);
        objgriduploads.interestegliblereimbursement = Convert.ToDecimal(txt_eglibleamountofreimbursementbyeglibletype.Text);
        objgriduploads.PeriodofinstallmentName = Convert.ToString(ddl_periodofinstallment.SelectedItem.Text);
        objgriduploads.ELIGIBLETYPEName = Convert.ToString(rbtgrd_isbelated.SelectedItem.Text);
        objgriduploads.eligibleperiodinmonths = Convert.ToDecimal(txt_Eligibleperiodinmonths.Text);
        //objgriduploads.installmentstartmonthyear = ddl_installmentstartmonth.SelectedValue + "/" + ddl_installmentstartingyear.SelectedValue;
        objgriduploads.dcpdate = Convert.ToDateTime(txt_DateofCommencementofactivity.Text);

        for (int i = 0; i < grd_Addclaimperiod.Rows.Count; i++)
        {


            HiddenField hfgrd_fyid = grd_Addclaimperiod.Rows[i].FindControl("hfgrd_fyid") as HiddenField;
            Label lbl_grd_fyname = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_fyname") as Label;
            Label lbl_grd_NoofInstallmentCompletedthisclaimperiod = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_NoofInstallmentCompletedthisclaimperiod") as Label;

            Label lbl_grd_Principalamountduebeforehalfyearthisclaimperiod = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_Principalamountduebeforehalfyearthisclaimperiod") as Label;

            HiddenField hfgrd_monthid = grd_Addclaimperiod.Rows[i].FindControl("hfgrd_monthid") as HiddenField;
            Label lbl_grd_monthname = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_monthname") as Label;
            Label lbl_grd_Principalamounntdue = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_Principalamounntdue") as Label;
            Label lbl_grd_NoofInstallment = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_NoofInstallment") as Label;
            Label lbl_grd_Interestamount = grd_Addclaimperiod.Rows[i].FindControl("lbl_grd_Interestamount") as Label;

            objgriduploads.CLAIMPERIOD_Grid = Convert.ToString(hfgrd_fyid.Value);
            objgriduploads.CLAIMPERIODName_Grid = Convert.ToString(lbl_grd_fyname.Text);
            objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid = Convert.ToString(lbl_grd_NoofInstallmentCompletedthisclaimperiod.Text);
            objgriduploads.principalamountduefornexthalfyr_grid = Convert.ToDecimal(lbl_grd_Principalamountduebeforehalfyearthisclaimperiod.Text);
            objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthid.Value);
            objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthname.Text);
            objgriduploads.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_Principalamounntdue.Text);
            objgriduploads.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_NoofInstallment.Text);
            objgriduploads.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_Interestamount.Text);
            obj_pallavaddi.DB_INSERTPVCALIMSDATA(objgriduploads);



        }


        return checkstatus;
    }


    public void AssignValuestoVosFromcontrols()
    {
        //oIncentiveVosA = new IncentiveVosAppraisal();
        oIncentiveVosA.incapplnno = lblApplicationno.Text;
        //  oIncentiveVosA.Remarks = txtremarks.Text;
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
        oIncentiveVosA.TextBox59 = "";


        oIncentiveVosA.createdby = Session["uid"].ToString();
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




        oIncentiveVosA.MstIncentiveId = "1";

        oIncentiveVosA.ELIGIBLESANCTIONEDAMOUNT = Convert.ToString(txt_eglsacamountinterestreimbursement.Text);
        oIncentiveVosA.CLAIMPERIODID = Convert.ToString(ddl_ClaimPeriod.SelectedValue);
        oIncentiveVosA.CLAIMPERIOD = Convert.ToString(ddl_ClaimPeriod.SelectedItem.Text);
        oIncentiveVosA.DATEOFCOMMENCEMENTOFACTIVITY = Convert.ToDateTime(txt_DateofCommencementofactivity.Text);
        oIncentiveVosA.PERIODOFINSTALMENTID = Convert.ToString(ddl_periodofinstallment.SelectedValue);
        oIncentiveVosA.INSTALMENTPERIOD = Convert.ToString(txt_Eligibleperiodinmonths.Text);
        oIncentiveVosA.NOOFINSTALMENTS = Convert.ToString(txt_noofinstallment.Text);
        oIncentiveVosA.INSTALMENTAMOUNT = Convert.ToDecimal(txt_Installmentamount.Text);
        //oIncentiveVosA.INSTALMENTSTARTMONTHYEAR_ID = Convert.ToString(ddl_installmentstartmonth.SelectedValue + "/" + ddl_installmentstartingyear.SelectedValue);
        //oIncentiveVosA.INSTALMENTSTARTMONTHYEAR_VALUE = Convert.ToString(ddl_installmentstartmonth.SelectedItem.Text + "/" + ddl_installmentstartingyear.SelectedItem.Text);
        oIncentiveVosA.RATEOFINTEREST = Convert.ToString(txt_RateofInterest.Text);
        oIncentiveVosA.ELIGIBLERATEOFREUMBERSEMENT = Convert.ToString(txt_Eligiblerateofreimbursement.Text);
        oIncentiveVosA.NOOFINSTALMENTS_COMPLETED = Convert.ToString(txt_Noofinstallmentscompleted.Text);
        oIncentiveVosA.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR = Convert.ToString(txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text);
        oIncentiveVosA.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        oIncentiveVosA.ACTUALINTERESTAMOUNT_PAID = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATED = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);

        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATED_FINAL = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
        oIncentiveVosA.GMRECOMMENDEDAMOUNT = Convert.ToDecimal(txt_GMrecommendedamount.Text);
        oIncentiveVosA.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
        oIncentiveVosA.EglibleTypeID = Convert.ToString(rbtgrd_isbelated.SelectedValue);
        oIncentiveVosA.EglibleTypeName = Convert.ToString(rbtgrd_isbelated.SelectedItem.Text);
        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype = Convert.ToDecimal(txt_eglibleamountofreimbursementbyeglibletype.Text);
        oIncentiveVosA.PERIODOFINSTALMENTName = Convert.ToString(ddl_periodofinstallment.SelectedItem.Text);


    }
    //business logic

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
        if (ddl_ClaimPeriod.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select claim period \\n";
            slno = slno + 1;
        }
        if (txt_eglsacamountinterestreimbursement.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Eligible sanctionned amount towards interest reimbursement (Value in Rs.)\\n";
            slno = slno + 1;
        }
        if (txt_DateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of activity \\n";
            slno = slno + 1;
        }
        if (ddl_periodofinstallment.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Period of installment\\n";
            slno = slno + 1;
        }
        if (txt_noofinstallment.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter No of installment \\n";
            slno = slno + 1;
        }
        if (txt_Installmentamount.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Installment amount \\n";
            slno = slno + 1;
        }
        //if (ddl_installmentstartmonth.SelectedIndex <= 0)
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Month from which installment starts\\n";
        //    slno = slno + 1;
        //}
        if (txt_RateofInterest.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Rate of Interest \\n";
            slno = slno + 1;
        }
        if (txt_Eligiblerateofreimbursement.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible rate of reimbursement\\n";
            slno = slno + 1;
        }
        if (txt_Noofinstallmentscompleted.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter No of installments completed \\n";
            slno = slno + 1;
        }
        if (txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Principal amount become DUE before this HALF YEAR \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
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
        Response.Redirect("frmCoiDashboard.aspx");// + hdfID.Value
    }

    #endregion



    #region eglible amount

    protected void txt_eglsacamountinterestreimbursement_TextChanged(object sender, EventArgs e)
    {

        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{
        //    string errorgmsg1 = ValidateControls_installmentamount();
        //    if (errorgmsg1.Trim().TrimStart() != "")
        //    {
        //        string message = "alert('" + errorgmsg + "')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        return;
        //    }
        //    else
        //    {

        //    }
        //}
    }

    protected void ddl_ClaimPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        // getthedate_eligibleincentives_datatest();
        //string claimperiodddlvalue = ddl_ClaimPeriod.SelectedValue;
        //string[] argclaimperiod = new string[5];
        //argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
        //string FYSlnoofIncentiveID = Convert.ToString(argclaimperiod[0]);
        //string firstsecondhalfyear = Convert.ToString(argclaimperiod[1]);
        //string yeardata = Convert.ToString(argclaimperiod[2]);
        //string[] argyearclaimperiod = new string[5];
        //argyearclaimperiod = yeardata.Split('-');
        //string Startyear = Convert.ToString(argyearclaimperiod[0]);
        //string endyear = Convert.ToString(argyearclaimperiod[1]);

        //GetMonthYearName_DB(Convert.ToInt32(Startyear), Convert.ToInt32(firstsecondhalfyear));

        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
    }

    protected void txt_DateofCommencementofactivity_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
    }

    protected void ddl_periodofinstallment_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
    }

    protected void txt_noofinstallment_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        // getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{
        //    string errorgmsg1 = ValidateControls_installmentamount();
        //    if (errorgmsg1.Trim().TrimStart() != "")
        //    {
        //        string message = "alert('" + errorgmsg + "')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        return;
        //    }
        //    else
        //    {

        //    }
        //}
    }

    protected void txt_Installmentamount_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        // getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
    }

    protected void ddl_installmentstartmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
    }

    protected void ddl_installmentstartingyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
    }

    protected void txt_RateofInterest_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //getthedate_eligibleincentives_datatest();
        //string errorgmsg1 = ValidateControls_rateofinterest();
        //if (errorgmsg1.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg1 + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{
        //    string errorgmsg = ValidateControls_eligibleincentives();
        //    if (errorgmsg.Trim().TrimStart() != "")
        //    {
        //        string message = "alert('" + errorgmsg + "')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        return;
        //    }
        //    else
        //    {

        //    }
        //}
    }

    protected void txt_Eligiblerateofreimbursement_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
        //getthedate_eligibleincentives_datatest();
    }

    protected void txt_Noofinstallmentscompleted_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
        //getthedate_eligibleincentives_datatest();
    }

    protected void txt_PrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        //string errorgmsg = ValidateControls_eligibleincentives();
        //if (errorgmsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errorgmsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{

        //}
        //getthedate_eligibleincentives_datatest();
    }

    protected void txt_installmentstartdateofappl_TextChanged(object sender, EventArgs e)
    {
        string errorgmsg = getthedate_eligibleincentives();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }
    public string getthedate_eligibleincentives()
    {
        int slno = 1;
        string ErrorMsg = "";

        decimal Totalamount = 0; DateTime dcpdate = DateTime.Now; int periodofinstallment = 0; 
        int Totalinstallment = 0; decimal installmentamount = 0; decimal rateofinterest = 0;
        decimal egliblerateofinterest = 0; int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
        int FYSlnoofIncentiveID = 0;
        int firstsecondhalfyearoffirstddlclaim = 0;
        int fyStartyear = 0;
        int fystartmonth = 0;
        int fyendyear = 0;
        int fyendmonth = 0;
        DateTime installmentstartdate = DateTime.Now; 

        // ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of activity \\n";
        //slno = slno + 1;

        if (txt_eglsacamountinterestreimbursement.Text != "")
        {
            Totalamount = Convert.ToDecimal(txt_eglsacamountinterestreimbursement.Text);
        }
        if (txt_DateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
        {

            dcpdate = Convert.ToDateTime(txt_DateofCommencementofactivity.Text);
        }
        if (ddl_periodofinstallment.SelectedIndex > 0)
        {
            periodofinstallment = Convert.ToInt32(ddl_periodofinstallment.SelectedValue);
        }
       
        if (txt_noofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
        {
            Totalinstallment = Convert.ToInt32(txt_noofinstallment.Text);
        }
        if (txt_RateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterest = Convert.ToDecimal(txt_RateofInterest.Text);
        }
        if (ddl_ClaimPeriod.SelectedIndex > 0)
        {
            string claimperiodddlvalue = ddl_ClaimPeriod.SelectedValue;
            string[] argclaimperiod = new string[5];
            argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
            FYSlnoofIncentiveID = Convert.ToInt32(argclaimperiod[0]);
            firstsecondhalfyearoffirstddlclaim = Convert.ToInt16(argclaimperiod[1]);
            string yeardata = Convert.ToString(argclaimperiod[2]);
            string[] argyearclaimperiod = new string[5];
            argyearclaimperiod = yeardata.Split('-');
            fyStartyear = Convert.ToInt32(argyearclaimperiod[0]);
            fyendyear = Convert.ToInt32(argyearclaimperiod[1]);
            if (firstsecondhalfyearoffirstddlclaim > 0)
            {
                if (firstsecondhalfyearoffirstddlclaim == 1)
                {
                    fystartmonth = 4;
                    fyendmonth = 9;
                }
                if (firstsecondhalfyearoffirstddlclaim == 2)
                {
                    fystartmonth = 10;
                    fyendmonth = 3;
                }
                if (firstsecondhalfyearoffirstddlclaim == 3)
                {
                    fystartmonth = 4;
                    fyendmonth = 3;
                }
            }
        }

        if (txt_installmentstartdateofappl.Text.TrimStart().TrimEnd().Trim() != "")
        {

            installmentstartdate = Convert.ToDateTime(txt_installmentstartdateofappl.Text);
        }
        

        if (rateofinterest > 0)
        {
            egliblerateofinterest = rateofinterest - 3;
            if (egliblerateofinterest > 9)
            {
                egliblerateofinterest = 9;
            }
        }

        if (egliblerateofinterest > 0)
        {
            txt_Eligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
            slno = slno + 1;
        }
        if (Totalinstallment > 0 && Totalamount > 0)
        {
            installmentamount = Totalamount / Totalinstallment;
            txt_Installmentamount.Text = Convert.ToString(Math.Round(installmentamount, 2));
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
            slno = slno + 1;
        }

        decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0;
        if (dcpdate.Date < DateTime.Now.Date)
        {
            if (installmentstartdate.Date < DateTime.Now.Date)
            {
                if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0  &&
              Totalinstallment > 0 && installmentamount > 0 && rateofinterest > 0 && fyStartyear > 0 && fystartmonth > 0
                    && fyendyear > 0 && fyendmonth > 0 && installmentstartdate != null)
                {

                    DateTime dt_considerdate = DateTime.Now;
                    if(dcpdate.Date< installmentstartdate.Date)
                    {
                        dt_considerdate = dcpdate;
                    }
                    else
                    {
                        dt_considerdate = installmentstartdate;
                    }

                    if(dt_considerdate < DateTime.Now)
                    {


                        // ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month
                        int totalmonthcal = 0;
                        int totaltwoyearscal = 0;
                        int totalmonthbwtwoyears = 0;
                        if (fyStartyear == dt_considerdate.Year)
                        {
                            totaltwoyearscal = 0;
                            if (fystartmonth > dt_considerdate.Month)
                            {
                                //dcp date start before financial year
                                totalmonthcal = (fystartmonth - dt_considerdate.Month);
                            }
                            else
                            {
                                // totalmonthcal = (dt_considerdate.Month- fystartmonth) + 12;
                                //dcp date didn't start for that finanical year
                                totalmonthcal = 0;
                            }
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (dt_considerdate.Year < fyStartyear)
                        {
                            totaltwoyearscal = ((fyStartyear - dt_considerdate.Year) * 12);
                            totalmonthcal = (fystartmonth - dt_considerdate.Month);
                            //if (fystartmonth > dt_considerdate.Month)
                            //{
                            //    totalmonthcal = (fystartmonth - dt_considerdate.Month);
                            //}
                            //else
                            //{
                            //    totalmonthcal = (dt_considerdate.Month - fystartmonth) + 12;
                            //}
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (dt_considerdate.Year > fyStartyear)
                        {
                            totaltwoyearscal = 0;
                            totalmonthcal = 0;
                            //totaltwoyearscal = ((fyStartyear-dt_considerdate.Year) * 12);
                            //if (fystartmonth > dt_considerdate.Month)
                            //{
                            //    totalmonthcal = (dt_considerdate.Month - fystartmonth) + 12;
                            //}
                            //else
                            //{
                            //    totalmonthcal = (fystartmonth - dt_considerdate.Month);
                            //}
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        int quotientcompleted = 0;
                        if (periodofinstallment == 1)
                        {
                            //Yearly
                            quotientcompleted = totalmonthbwtwoyears / 12;
                        }
                        else if (periodofinstallment == 2)
                        {
                            //halfyear
                            quotientcompleted = totalmonthbwtwoyears / 6;
                        }
                        else if (periodofinstallment == 3)
                        {
                            //quaertly
                            quotientcompleted = totalmonthbwtwoyears / 3;
                        }
                        else if (periodofinstallment == 4)
                        {
                            //Monthly
                            quotientcompleted = totalmonthbwtwoyears;
                        }
                        noofinstallmentcompleted = quotientcompleted;



                        if (noofinstallmentcompleted <= Totalinstallment)
                        {
                            if (noofinstallmentcompleted == 0)
                            {
                                termprincipaldueamount = Totalamount;
                            }
                            else
                            {
                                termprincipaldueamount = Totalamount - (noofinstallmentcompleted * installmentamount);
                            }

                            int TotalInstallmentCompleted = 0;

                            if (termprincipaldueamount > 0)
                            {
                                DataSet oDataSet = obj_pallavaddi.DB_getFYClaimperiod(Convert.ToString(Session["incentiveid"]));
                                if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dt_grid = new DataTable();
                                    dt_grid.Columns.Add("IncentiveFYClaimID", typeof(string));
                                    dt_grid.Columns.Add("FirstsecondhalfyearID", typeof(string));
                                    dt_grid.Columns.Add("FinancialYearID", typeof(string));
                                    dt_grid.Columns.Add("FinancialYearName", typeof(string));
                                    dt_grid.Columns.Add("RateofInterest", typeof(string));
                                    dt_grid.Columns.Add("forPresenthalfyeardueamount", typeof(string));
                                    dt_grid.Columns.Add("TotalInstallmentCompleted", typeof(string));
                                    dt_grid.Columns.Add("InstallmentAmount", typeof(string));

                                    dt_grid.Columns.Add("MonthYear", typeof(string));
                                    dt_grid.Columns.Add("MonthName_Year", typeof(string));
                                    dt_grid.Columns.Add("Principalamountdue", typeof(decimal));
                                    dt_grid.Columns.Add("noofinstallment", typeof(int));
                                    dt_grid.Columns.Add("InterestAmount", typeof(decimal));



                                    for (int i = 0; i < oDataSet.Tables[0].Rows.Count; i++)
                                    {
                                        int installmentstartmonthyear = 0;
                                        decimal forPresenthalfyeardueamount = 0;

                                        String eachclaimperiodID = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearID"]);
                                        String eachclaimperiodName = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearName"]);
                                        string[] argeachclaimperiod = new string[5];
                                        argeachclaimperiod = eachclaimperiodID.Split('/'); //32012/1/2016-2017
                                        string IncentiveFYClaimID = Convert.ToString(argeachclaimperiod[0]);
                                        int firstsecondhalfyearclaimtype = Convert.ToInt16(argeachclaimperiod[1]);
                                        string yeardataeachclaim = Convert.ToString(argeachclaimperiod[2]);
                                        string[] argeachyearclaimperiod = new string[5];
                                        argeachyearclaimperiod = yeardataeachclaim.Split('-');
                                        int fyeachStartyear = Convert.ToInt32(argeachyearclaimperiod[0]);
                                        int fyeachendyear = Convert.ToInt32(argeachyearclaimperiod[1]);
                                        if (i == 0)
                                        {
                                            TotalInstallmentCompleted = noofinstallmentcompleted;
                                        }

                                        int totalmonthforhalfyear = 6;
                                        int monthofstart = 4;//April      
                                        installmentstartmonthyear = 4;
                                        if (firstsecondhalfyearclaimtype == 3)
                                        {
                                            totalmonthforhalfyear = 12;
                                        }
                                        if (firstsecondhalfyearclaimtype == 2)
                                        {
                                            monthofstart = 10;//OCT
                                            if (TotalInstallmentCompleted > 0)
                                            {
                                                installmentstartmonthyear = 10;
                                            }
                                        }
                                        DateTime dateofmonthstart = new DateTime(Convert.ToInt32(fyeachStartyear), monthofstart, 01);
                                        var dat = dateofmonthstart.AddMonths(1).AddDays(-1);

                                        for (int k = 0; k < totalmonthforhalfyear; k++)
                                        {
                                            DataRow drs = dt_grid.NewRow();
                                            dat.AddMonths(k).ToString("d");
                                            string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                                            string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
                                            //string MonthYear = 0+k + "/" + d1.Year;
                                            //string MonthName = 0 + k + "-" + d1.Year;
                                            int gridmonth = dat.AddMonths(k).Month;
                                            int gridyear = dat.AddMonths(k).Year;

                                            decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
                                            if (gridyear >= dt_considerdate.Year)
                                            {
                                                int gridtotaltwoyearscal = 0;
                                                int gridtotalmonthcal = 0;
                                                int gridtotalmonthbwyears = 0;
                                                // int gridtotalmonthbwyears = ((gridyear - dt_considerdate.Year) * 12) + (gridmonth - dt_considerdate.Month);
                                                if (gridyear == dt_considerdate.Year)
                                                {
                                                    gridtotaltwoyearscal = 0;
                                                    if (gridmonth > dt_considerdate.Month)
                                                    {
                                                        //dcp date start before financial year
                                                        gridtotalmonthcal = (gridmonth - dt_considerdate.Month);
                                                    }
                                                    else
                                                    {
                                                        gridtotalmonthcal = 0;
                                                        //dcp date didn't start for that finanical year
                                                        //gridtotalmonthcal = 0;
                                                    }
                                                    gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                }
                                                else if (dt_considerdate.Year < gridyear)
                                                {
                                                    gridtotaltwoyearscal = ((gridyear - dt_considerdate.Year) * 12);
                                                    gridtotalmonthcal = (gridmonth - dt_considerdate.Month);
                                                    gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                }
                                                else if (dt_considerdate.Year > gridyear)
                                                {
                                                    //in that year dcp didn't started
                                                    gridtotaltwoyearscal = 0;
                                                    gridtotalmonthcal = 0;
                                                    gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                }


                                                //int gridtotalmonthbwyears = ((gridyear - dt_considerdate.Year) * 12) + (gridmonth - dt_considerdate.Month);
                                                int gridquotientCompleted = 0;
                                                int gridremainder = 0;
                                                if (Convert.ToInt16(periodofinstallment) == 1)
                                                {
                                                    //Yearly
                                                    gridquotientCompleted = gridtotalmonthbwyears / 12;
                                                    gridremainder = gridtotalmonthbwyears % 12;
                                                    if (gridquotientCompleted + 1 <= Totalinstallment)
                                                    {
                                                        if (gridquotientCompleted <= 0)
                                                        {
                                                            if (gridremainder <= 0)
                                                            {
                                                                if (gridyear == dt_considerdate.Year)
                                                                {
                                                                    if (gridmonth == dt_considerdate.Month)
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount;
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted;
                                                                        Principalamountdue = 0;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted;
                                                                    Principalamountdue = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            noofinstallment = gridquotientCompleted + 1;
                                                            if (gridremainder == 0)
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        //if (gridremainder > 0)
                                                        //{
                                                        //    noofinstallment = gridquotientCompleted + 1;
                                                        //    if (gridremainder == 1)
                                                        //    {
                                                        //        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                        //    }

                                                        //}
                                                        //else
                                                        //{
                                                        //    noofinstallment = gridquotientCompleted + 1;
                                                        //    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                        //}
                                                        //if (totalmonthforhalfyear - 1 == k)
                                                        //{
                                                        //    forPresenthalfyeardueamount = Principalamountdue;
                                                        //    TotalInstallmentCompleted = noofinstallment;
                                                        //}

                                                        if (k == 0)
                                                        {
                                                            forPresenthalfyeardueamount = Principalamountdue;
                                                            if (noofinstallment - 1 <= 0)
                                                            {
                                                                TotalInstallmentCompleted = 0;
                                                            }
                                                            else
                                                            {
                                                                TotalInstallmentCompleted = noofinstallment - 1;
                                                            }
                                                        }

                                                    }
                                                }
                                                else if (Convert.ToInt16(periodofinstallment) == 2)
                                                {
                                                    //Half yearly
                                                    gridquotientCompleted = gridtotalmonthbwyears / 6;
                                                    gridremainder = gridtotalmonthbwyears % 6;

                                                    if (gridquotientCompleted + 1 <= Totalinstallment)
                                                    {
                                                        if (gridquotientCompleted <= 0)
                                                        {
                                                            if (gridremainder <= 0)
                                                            {
                                                                if (gridyear == dt_considerdate.Year)
                                                                {
                                                                    if (gridmonth == dt_considerdate.Month)
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount;
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted;
                                                                        Principalamountdue = 0;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted;
                                                                    Principalamountdue = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            noofinstallment = gridquotientCompleted + 1;
                                                            if (gridremainder == 0)
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }






                                                        //if (gridremainder > 0)
                                                        //{
                                                        //    noofinstallment = gridquotientCompleted + 1;
                                                        //    if (gridremainder == 1)
                                                        //    {
                                                        //        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                        //    }
                                                        //    else
                                                        //    {
                                                        //        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                        //    }

                                                        //}
                                                        //else
                                                        //{
                                                        //    noofinstallment = gridquotientCompleted + 1;
                                                        //    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                        //}

                                                        //if (totalmonthforhalfyear - 1 == k)
                                                        //{
                                                        //    forPresenthalfyeardueamount = Principalamountdue;
                                                        //    TotalInstallmentCompleted = noofinstallment;
                                                        //}

                                                        if (k == 0)
                                                        {
                                                            forPresenthalfyeardueamount = Principalamountdue;
                                                            if (noofinstallment - 1 <= 0)
                                                            {
                                                                TotalInstallmentCompleted = 0;
                                                            }
                                                            else
                                                            {
                                                                TotalInstallmentCompleted = noofinstallment - 1;
                                                            }


                                                        }

                                                    }
                                                }
                                                else if (Convert.ToInt16(periodofinstallment) == 3)
                                                {
                                                    // Quarelty
                                                    gridquotientCompleted = gridtotalmonthbwyears / 3;
                                                    gridremainder = gridtotalmonthbwyears % 3;
                                                    if (gridquotientCompleted + 1 <= Totalinstallment)
                                                    {
                                                        if (gridquotientCompleted <= 0)
                                                        {
                                                            if (gridremainder <= 0)
                                                            {
                                                                if (gridyear == dt_considerdate.Year)
                                                                {
                                                                    if (gridmonth == dt_considerdate.Month)
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount;
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted;
                                                                        Principalamountdue = 0;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted;
                                                                    Principalamountdue = 0;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            noofinstallment = gridquotientCompleted + 1;
                                                            if (gridremainder == 0)
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }



                                                        //if (totalmonthforhalfyear - 1 == k)
                                                        //{
                                                        //    forPresenthalfyeardueamount = Principalamountdue;
                                                        //    TotalInstallmentCompleted = noofinstallment;
                                                        //}
                                                        if (k == 0)
                                                        {
                                                            forPresenthalfyeardueamount = Principalamountdue;
                                                            if (noofinstallment - 1 <= 0)
                                                            {
                                                                TotalInstallmentCompleted = 0;
                                                            }
                                                            else
                                                            {
                                                                TotalInstallmentCompleted = noofinstallment - 1;
                                                            }


                                                        }

                                                    }
                                                }
                                                else if (Convert.ToInt16(periodofinstallment) == 4)
                                                {
                                                    //Monthly
                                                    if (gridquotientCompleted + 1 <= Totalinstallment)
                                                    {
                                                        if (gridyear == dt_considerdate.Year)
                                                        {
                                                            if (gridtotalmonthbwyears == 0)
                                                            {
                                                                if (gridmonth == dt_considerdate.Month)
                                                                {
                                                                    gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                    noofinstallment = (gridquotientCompleted);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    gridquotientCompleted = 0;
                                                                    noofinstallment = (gridquotientCompleted);
                                                                    Principalamountdue = 0;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                noofinstallment = (gridquotientCompleted);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                            noofinstallment = (gridquotientCompleted);
                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                        }

                                                        //noofinstallment = (totalcompletedinstallment + rowstartdata + 1);


                                                        //if (totalmonthforhalfyear - 1 == k)
                                                        //{
                                                        //    forPresenthalfyeardueamount = Principalamountdue;
                                                        //    TotalInstallmentCompleted = noofinstallment;
                                                        //}
                                                        if (k == 0)
                                                        {
                                                            forPresenthalfyeardueamount = Principalamountdue;

                                                            if (noofinstallment - 1 <= 0)
                                                            {
                                                                TotalInstallmentCompleted = 0;
                                                            }
                                                            else
                                                            {
                                                                TotalInstallmentCompleted = noofinstallment - 1;
                                                            }
                                                        }
                                                    }
                                                }

                                                interestamount = (Principalamountdue * rateofinterest) / 1200;

                                            }

                                            if (noofinstallment >= 1)
                                            {
                                                Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                totalinterestforallfy = totalinterestforallfy + interestamount;
                                            }


                                            drs["MonthYear"] = MonthYear;
                                            drs["MonthName_Year"] = MonthName;
                                            drs["Principalamountdue"] = Convert.ToString(Math.Round(Principalamountdue, 2));
                                            drs["noofinstallment"] = noofinstallment;
                                            drs["InterestAmount"] = Convert.ToString(Math.Round(interestamount, 2));
                                            drs["IncentiveFYClaimID"] = IncentiveFYClaimID;
                                            drs["FirstsecondhalfyearID"] = firstsecondhalfyearclaimtype;
                                            drs["FinancialYearID"] = eachclaimperiodID;//yeardataeachclaim;
                                            drs["FinancialYearName"] = eachclaimperiodName;
                                            drs["RateofInterest"] = rateofinterest;
                                            drs["InstallmentAmount"] = Convert.ToString(Math.Round(installmentamount, 2));
                                            drs["forPresenthalfyeardueamount"] = Convert.ToString(Math.Round(forPresenthalfyeardueamount, 2));
                                            drs["TotalInstallmentCompleted"] = TotalInstallmentCompleted;
                                            dt_grid.Rows.Add(drs);
                                        }
                                    }

                                    DataSet dsmain = new DataSet();
                                    dsmain.Tables.Add(dt_grid);
                                    grd_Addclaimperiod.DataSource = dsmain.Tables[0];
                                    grd_Addclaimperiod.DataBind();


                                }
                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero    \\n";
                                slno = slno + 1;
                            }
                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter completed total installment should be less than total installment   \\n";
                            slno = slno + 1;
                        }


                    }
                   
                }
            }
            else
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installment start date should be below  current date \\n";
                slno = slno + 1;
            }
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date should be below  current date \\n";
            slno = slno + 1;
        }

        // = Toteglibleperiodinmonths + 1;
        txt_Eligibleperiodinmonths.Text = Convert.ToString(Toteglibleperiodinmonths);
        txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));


        txt_Noofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
        txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(Math.Round(termprincipaldueamount, 2));





        return ErrorMsg;
    }

    public void GetYearName_DB()
    {
        try
        {
            DataTable dt_grid = new DataTable();
            dt_grid.Columns.Add("YEAR", typeof(string));
            int CurrentYear = DateTime.Now.Year;
            int totalmonth = CurrentYear - 2010;
            int Yearstart = 2010;
            for (int k = 0; k <= totalmonth; k++)
            {
                DataRow drs = dt_grid.NewRow();
                int Year = Yearstart + k;
                drs["YEAR"] = Year;
                dt_grid.Rows.Add(drs);
            }

            DataSet dsmain = new DataSet();
            dsmain.Tables.Add(dt_grid);
            if (dsmain != null && dsmain.Tables.Count > 0 && dsmain.Tables[0].Rows.Count > 0)
            {
                //ddl_installmentstartingyear.DataSource = dsmain.Tables[0];
                //ddl_installmentstartingyear.DataValueField = "YEAR";
                //ddl_installmentstartingyear.DataTextField = "YEAR";
                //ddl_installmentstartingyear.DataBind();
                //ddl_installmentstartingyear.Items.Insert(0, "--Select--");
            }
            // ddl_installmentstartmonth.SelectedIndex = 1;//By Default April or oct
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errorgmsg = ValidateControls();
        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            if (save())
            {
                string message = "alert('Appraisal note submitted successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }

    }

    protected void BtnClearall_Click(object sender, EventArgs e)
    {
        this.Page_Load(null, null);
    }

    protected void btm_previous_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCoiDashboard.aspx");
    }

    protected void txt_Insertamounttobepaidaspercalculations_TextChanged(object sender, EventArgs e)
    {
        interestamountcalacutions();
    }

    protected void txt_Actualinterestamountpaid_TextChanged(object sender, EventArgs e)
    {
        interestamountcalacutions();
    }

    protected void rbtgrd_isbelated_TextChanged(object sender, EventArgs e)
    {
        interestamountcalacutions();
    }

    void interestamountcalacutions()
    {
        decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
        decimal rateofinterest = 0; decimal egliblerateofinterest = 0; decimal interestegliblereimbursement = 0;
        decimal eglibleamountofreimbursementbyeglibletype = 0;
        if (txt_Insertamounttobepaidaspercalculations.Text != "")
        {
            totalgridinterestamount = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        }

        if (txt_Actualinterestamountpaid.Text != "")
        {
            actualinterestamountpaid  = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
        }
        if (txt_RateofInterest.Text != "")
        {
            rateofinterest = Convert.ToDecimal(txt_RateofInterest.Text);
        }
        if (txt_Eligiblerateofreimbursement.Text != "")
        {
            egliblerateofinterest = Convert.ToDecimal(txt_Eligiblerateofreimbursement.Text);
        }

        if (totalgridinterestamount > 0)
        {
            if (totalgridinterestamount > 0)
            {
                if (rateofinterest > 0)
                {
                    if (egliblerateofinterest > 0)
                    {
                        if (Math.Round(totalgridinterestamount) < Math.Round(actualinterestamountpaid))
                        {
                            interestamountcondisered = totalgridinterestamount;
                        }
                        else
                        {
                            interestamountcondisered = Math.Round(actualinterestamountpaid);
                        }
                        interestegliblereimbursement = (interestamountcondisered * egliblerateofinterest) / rateofinterest;


                    }
                    else
                    {
                        //Please Enter Eglible Rate of interest
                    }
                }
                else
                {
                    //Please Enter Rate of interest
                }
            }
            else
            {
                //Please enter Actual interest amount paid
            }
        }
        else
        {
            //then error insert amount can't be zero
        }

        if (interestegliblereimbursement > 0)
        {
            if (rbtgrd_isbelated.SelectedValue == "0")
            {
                //More than an Year
                eglibleamountofreimbursementbyeglibletype = 0;
                txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);

            }
            else if (rbtgrd_isbelated.SelectedValue == "Y")
            {
                //Regular
                eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement;
                txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
            }
            else if (rbtgrd_isbelated.SelectedValue == "N")
            {
                //Belated
                eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement / 2;
                txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
            }
            else
            {
                //Please Select Eglible Type
            }
        }


        txt_Insertreimbursementcalculated.Text = Convert.ToString(Math.Round(interestegliblereimbursement, 2));
        txt_Eligibleamount.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));

    }




    public string getthedate_eligibleincentives_datatest()
    {
        int slno = 1;
        string ErrorMsg = "";

        decimal Totalamount = 0; DateTime dcpdate = DateTime.Now; int periodofinstallment = 0; int emistartmonth = 0;
        int emistartyear = 0; int Totalinstallment = 0; decimal installmentamount = 0; decimal rateofinterest = 0;
        decimal egliblerateofinterest = 0; int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
        int FYSlnoofIncentiveID = 0;
        int firstsecondhalfyearoffirstddlclaim = 0;
        int fyStartyear = 0;
        int fystartmonth = 0;
        int fyendyear = 0;
        int fyendmonth = 0;

        // ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of activity \\n";
        //slno = slno + 1;

        if (txt_eglsacamountinterestreimbursement.Text != "")
        {
            Totalamount = Convert.ToDecimal(txt_eglsacamountinterestreimbursement.Text);
        }
        if (txt_DateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
        {

            dcpdate = Convert.ToDateTime(txt_DateofCommencementofactivity.Text);
        }
        if (ddl_periodofinstallment.SelectedIndex > 0)
        {
            periodofinstallment = Convert.ToInt32(ddl_periodofinstallment.SelectedValue);
        }
        //if (ddl_installmentstartmonth.SelectedIndex > 0)
        //{
        //    emistartmonth = Convert.ToInt32(ddl_installmentstartmonth.SelectedValue);
        //}
        //if (ddl_installmentstartingyear.SelectedIndex > 0)
        //{
        //    emistartyear = Convert.ToInt32(ddl_installmentstartingyear.SelectedValue);
        //}
        if (txt_noofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
        {
            Totalinstallment = Convert.ToInt32(txt_noofinstallment.Text);
        }
        if (txt_RateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterest = Convert.ToDecimal(txt_RateofInterest.Text);
        }
        if (ddl_ClaimPeriod.SelectedIndex > 0)
        {
            string claimperiodddlvalue = ddl_ClaimPeriod.SelectedValue;
            string[] argclaimperiod = new string[5];
            argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
            FYSlnoofIncentiveID = Convert.ToInt32(argclaimperiod[0]);
            firstsecondhalfyearoffirstddlclaim = Convert.ToInt16(argclaimperiod[1]);
            string yeardata = Convert.ToString(argclaimperiod[2]);
            string[] argyearclaimperiod = new string[5];
            argyearclaimperiod = yeardata.Split('-');
            fyStartyear = Convert.ToInt32(argyearclaimperiod[0]);
            fyendyear = Convert.ToInt32(argyearclaimperiod[1]);
            if (firstsecondhalfyearoffirstddlclaim > 0)
            {
                if (firstsecondhalfyearoffirstddlclaim == 1)
                {
                    fystartmonth = 4;
                    fyendmonth = 9;
                }
                if (firstsecondhalfyearoffirstddlclaim == 2)
                {
                    fystartmonth = 10;
                    fyendmonth = 3;
                }
                if (firstsecondhalfyearoffirstddlclaim == 3)
                {
                    fystartmonth = 4;
                    fyendmonth = 3;
                }
            }
        }

        if (rateofinterest > 0)
        {
            egliblerateofinterest = rateofinterest - 3;
            if (egliblerateofinterest > 9)
            {
                egliblerateofinterest = 9;
            }
        }

        if (egliblerateofinterest > 0)
        {
            txt_Eligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
            slno = slno + 1;
        }
        if (Totalinstallment > 0 && Totalamount > 0)
        {
            installmentamount = Totalamount / Totalinstallment;
            txt_Installmentamount.Text = Convert.ToString(installmentamount);
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
            slno = slno + 1;
        }

        decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0;
        if (dcpdate.Date != DateTime.Now.Date)
        {
            if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0 && emistartyear > 0 && emistartmonth > 0 &&
              Totalinstallment > 0 && installmentamount > 0 && rateofinterest > 0 && fyStartyear > 0 && fystartmonth > 0
                    && fyendyear > 0 && fyendmonth > 0)
            {
                if ((dcpdate.Year >= emistartyear) || (dcpdate.Year <= emistartyear))
                {
                    // ((date1.Year - date2.Year) * 12) + date1.Month - date2.Month
                    int totalmonthcal = 0;
                    int totaltwoyearscal = 0;
                    int totalmonthbwtwoyears = 0;
                    if (fyStartyear == dcpdate.Year)
                    {
                        totaltwoyearscal = 0;
                        if (fystartmonth > dcpdate.Month)
                        {
                            //dcp date start before financial year
                            totalmonthcal = (fystartmonth - dcpdate.Month);
                        }
                        else
                        {
                            // totalmonthcal = (dcpdate.Month- fystartmonth) + 12;
                            //dcp date didn't start for that finanical year
                            totalmonthcal = 0;
                        }
                        totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                    }
                    else if (dcpdate.Year < fyStartyear)
                    {
                        totaltwoyearscal = ((fyStartyear - dcpdate.Year) * 12);
                        totalmonthcal = (fystartmonth - dcpdate.Month);
                        //if (fystartmonth > dcpdate.Month)
                        //{
                        //    totalmonthcal = (fystartmonth - dcpdate.Month);
                        //}
                        //else
                        //{
                        //    totalmonthcal = (dcpdate.Month - fystartmonth) + 12;
                        //}
                        totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                    }
                    else if (dcpdate.Year > fyStartyear)
                    {
                        totaltwoyearscal = 0;
                        totalmonthcal = 0;
                        //totaltwoyearscal = ((fyStartyear-dcpdate.Year) * 12);
                        //if (fystartmonth > dcpdate.Month)
                        //{
                        //    totalmonthcal = (dcpdate.Month - fystartmonth) + 12;
                        //}
                        //else
                        //{
                        //    totalmonthcal = (fystartmonth - dcpdate.Month);
                        //}
                        totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                    }
                    int quotientcompleted = 0;
                    if (periodofinstallment == 1)
                    {
                        //Yearly
                        quotientcompleted = totalmonthbwtwoyears / 12;
                    }
                    else if (periodofinstallment == 2)
                    {
                        //halfyear
                        quotientcompleted = totalmonthbwtwoyears / 6;
                    }
                    else if (periodofinstallment == 3)
                    {
                        //quaertly
                        quotientcompleted = totalmonthbwtwoyears / 3;
                    }
                    else if (periodofinstallment == 4)
                    {
                        //Monthly
                        quotientcompleted = totalmonthbwtwoyears;
                    }
                    noofinstallmentcompleted = quotientcompleted;

                    if (emistartyear <= DateTime.Now.Year)
                    {
                        if (emistartyear == DateTime.Now.Year && emistartmonth > DateTime.Now.Month)
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter installment start year,Month, should be less than/Current year, Moth   \\n";
                            slno = slno + 1;
                        }
                        else
                        {
                            if (noofinstallmentcompleted <= Totalinstallment)
                            {
                                if (noofinstallmentcompleted == 0)
                                {
                                    termprincipaldueamount = Totalamount;
                                }
                                else
                                {
                                    termprincipaldueamount = Totalamount - (noofinstallmentcompleted * installmentamount);
                                }

                                int TotalInstallmentCompleted = 0;

                                if (termprincipaldueamount > 0)
                                {
                                    DataSet oDataSet = obj_pallavaddi.DB_getFYClaimperiod(Convert.ToString(Session["incentiveid"]));
                                    if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        DataTable dt_grid = new DataTable();
                                        dt_grid.Columns.Add("IncentiveFYClaimID", typeof(string));
                                        dt_grid.Columns.Add("FirstsecondhalfyearID", typeof(string));
                                        dt_grid.Columns.Add("FinancialYearID", typeof(string));
                                        dt_grid.Columns.Add("FinancialYearName", typeof(string));
                                        dt_grid.Columns.Add("RateofInterest", typeof(string));
                                        dt_grid.Columns.Add("forPresenthalfyeardueamount", typeof(string));
                                        dt_grid.Columns.Add("TotalInstallmentCompleted", typeof(string));
                                        dt_grid.Columns.Add("InstallmentAmount", typeof(string));

                                        dt_grid.Columns.Add("MonthYear1", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year1", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue1", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment1", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount1", typeof(decimal));

                                        dt_grid.Columns.Add("MonthYear2", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year2", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue2", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment2", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount2", typeof(decimal));

                                        dt_grid.Columns.Add("MonthYear3", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year3", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue3", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment3", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount3", typeof(decimal));

                                        dt_grid.Columns.Add("MonthYear4", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year4", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue4", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment4", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount4", typeof(decimal));

                                        dt_grid.Columns.Add("MonthYear5", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year5", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue5", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment5", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount5", typeof(decimal));

                                        dt_grid.Columns.Add("MonthYear6", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year6", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue6", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment6", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount6", typeof(decimal));



                                        for (int i = 0; i < oDataSet.Tables[0].Rows.Count; i++)
                                        {
                                            int installmentstartmonthyear = 0;
                                            decimal forPresenthalfyeardueamount = 0;

                                            String eachclaimperiodID = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearID"]);
                                            String eachclaimperiodName = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearName"]);
                                            string[] argeachclaimperiod = new string[5];
                                            argeachclaimperiod = eachclaimperiodID.Split('/'); //32012/1/2016-2017
                                            string IncentiveFYClaimID = Convert.ToString(argeachclaimperiod[0]);
                                            int firstsecondhalfyearclaimtype = Convert.ToInt16(argeachclaimperiod[1]);
                                            string yeardataeachclaim = Convert.ToString(argeachclaimperiod[2]);
                                            string[] argeachyearclaimperiod = new string[5];
                                            argeachyearclaimperiod = yeardataeachclaim.Split('-');
                                            int fyeachStartyear = Convert.ToInt32(argeachyearclaimperiod[0]);
                                            int fyeachendyear = Convert.ToInt32(argeachyearclaimperiod[1]);
                                            if (i == 0)
                                            {
                                                TotalInstallmentCompleted = noofinstallmentcompleted;
                                            }

                                            int totalmonthforhalfyear = 6;
                                            int monthofstart = 4;//April      
                                            installmentstartmonthyear = 4;
                                            if (firstsecondhalfyearclaimtype == 3)
                                            {
                                                totalmonthforhalfyear = 12;
                                            }
                                            if (firstsecondhalfyearclaimtype == 2)
                                            {
                                                monthofstart = 10;//OCT
                                                if (TotalInstallmentCompleted > 0)
                                                {
                                                    installmentstartmonthyear = 10;
                                                }
                                            }
                                            DateTime dateofmonthstart = new DateTime(Convert.ToInt32(fyeachStartyear), monthofstart, 01);
                                            var dat = dateofmonthstart.AddMonths(1).AddDays(-1);

                                            for (int k = 0; k < totalmonthforhalfyear; k++)
                                            {
                                                DataRow drs = dt_grid.NewRow();
                                                dat.AddMonths(k).ToString("d");
                                                string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                                                string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
                                                //string MonthYear = 0+k + "/" + d1.Year;
                                                //string MonthName = 0 + k + "-" + d1.Year;
                                                int gridmonth = dat.AddMonths(k).Month;
                                                int gridyear = dat.AddMonths(k).Year;

                                                decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
                                                if (gridyear >= dcpdate.Year)
                                                {
                                                    int gridtotaltwoyearscal = 0;
                                                    int gridtotalmonthcal = 0;
                                                    int gridtotalmonthbwyears = 0;
                                                    // int gridtotalmonthbwyears = ((gridyear - dcpdate.Year) * 12) + (gridmonth - dcpdate.Month);
                                                    if (gridyear == dcpdate.Year)
                                                    {
                                                        gridtotaltwoyearscal = 0;
                                                        if (gridmonth > dcpdate.Month)
                                                        {
                                                            //dcp date start before financial year
                                                            gridtotalmonthcal = (gridmonth - dcpdate.Month);
                                                        }
                                                        else
                                                        {
                                                            gridtotalmonthcal = 0;
                                                            //dcp date didn't start for that finanical year
                                                            //gridtotalmonthcal = 0;
                                                        }
                                                        gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                    }
                                                    else if (dcpdate.Year < gridyear)
                                                    {
                                                        gridtotaltwoyearscal = ((gridyear - dcpdate.Year) * 12);
                                                        gridtotalmonthcal = (gridmonth - dcpdate.Month);
                                                        gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                    }
                                                    else if (dcpdate.Year > gridyear)
                                                    {
                                                        //in that year dcp didn't started
                                                        gridtotaltwoyearscal = 0;
                                                        gridtotalmonthcal = 0;
                                                        gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                    }


                                                    //int gridtotalmonthbwyears = ((gridyear - dcpdate.Year) * 12) + (gridmonth - dcpdate.Month);
                                                    int gridquotientCompleted = 0;
                                                    int gridremainder = 0;
                                                    if (Convert.ToInt16(periodofinstallment) == 1)
                                                    {
                                                        //Yearly
                                                        gridquotientCompleted = gridtotalmonthbwyears / 12;
                                                        gridremainder = gridtotalmonthbwyears % 12;
                                                        if (gridquotientCompleted + 1 <= Totalinstallment)
                                                        {
                                                            if (gridremainder > 0)
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                if (gridremainder == 1)
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }

                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                            if (totalmonthforhalfyear - 1 == k)
                                                            {
                                                                forPresenthalfyeardueamount = Principalamountdue;
                                                                TotalInstallmentCompleted = noofinstallment;
                                                            }

                                                        }
                                                    }
                                                    else if (Convert.ToInt16(periodofinstallment) == 2)
                                                    {
                                                        //Half yearly
                                                        gridquotientCompleted = gridtotalmonthbwyears / 6;
                                                        gridremainder = gridtotalmonthbwyears % 6;

                                                        if (gridquotientCompleted + 1 <= Totalinstallment)
                                                        {
                                                            if (gridremainder > 0)
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                if (gridremainder == 1)
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }

                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                            if (totalmonthforhalfyear - 1 == k)
                                                            {
                                                                forPresenthalfyeardueamount = Principalamountdue;
                                                                TotalInstallmentCompleted = noofinstallment;
                                                            }

                                                        }
                                                    }
                                                    else if (Convert.ToInt16(periodofinstallment) == 3)
                                                    {
                                                        // Quarelty
                                                        gridquotientCompleted = gridtotalmonthbwyears / 3;
                                                        gridremainder = gridtotalmonthbwyears % 3;
                                                        if (gridquotientCompleted + 1 <= Totalinstallment)
                                                        {
                                                            if (gridquotientCompleted <= 0)
                                                            {
                                                                if (gridremainder <= 0)
                                                                {
                                                                    if (gridyear == dcpdate.Year)
                                                                    {
                                                                        if (gridmonth == dcpdate.Month)
                                                                        {
                                                                            noofinstallment = gridquotientCompleted + 1;
                                                                            Principalamountdue = Totalamount;
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted;
                                                                            Principalamountdue = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted;
                                                                        Principalamountdue = 0;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = gridquotientCompleted + 1;
                                                                if (gridremainder == 0)
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }



                                                            if (totalmonthforhalfyear - 1 == k)
                                                            {
                                                                forPresenthalfyeardueamount = Principalamountdue;
                                                                TotalInstallmentCompleted = noofinstallment;
                                                            }

                                                        }
                                                    }
                                                    else if (Convert.ToInt16(periodofinstallment) == 4)
                                                    {
                                                        //Monthly
                                                        if (gridquotientCompleted + 1 <= Totalinstallment)
                                                        {
                                                            if (gridyear == dcpdate.Year)
                                                            {
                                                                if (gridtotalmonthbwyears == 0)
                                                                {
                                                                    if (gridmonth == dcpdate.Month)
                                                                    {
                                                                        gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                        noofinstallment = (gridquotientCompleted);
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                    else
                                                                    {
                                                                        gridquotientCompleted = 0;
                                                                        noofinstallment = (gridquotientCompleted);
                                                                        Principalamountdue = 0;
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                    noofinstallment = (gridquotientCompleted);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                noofinstallment = (gridquotientCompleted);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }

                                                            //noofinstallment = (totalcompletedinstallment + rowstartdata + 1);


                                                            if (totalmonthforhalfyear - 1 == k)
                                                            {
                                                                forPresenthalfyeardueamount = Principalamountdue;
                                                                TotalInstallmentCompleted = noofinstallment;
                                                            }
                                                        }
                                                    }

                                                    interestamount = (Principalamountdue * rateofinterest) / 1200;

                                                }

                                                if (noofinstallment >= 1)
                                                {
                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                    totalinterestforallfy = totalinterestforallfy + interestamount;
                                                }


                                                if (k == 0)
                                                {
                                                    drs["MonthYear1"] = MonthYear;
                                                    drs["MonthName_Year1"] = MonthName;
                                                    drs["Principalamountdue1"] = Principalamountdue;
                                                    drs["noofinstallment1"] = noofinstallment;
                                                    drs["InterestAmount1"] = interestamount;
                                                }
                                                if (k == 1)
                                                {
                                                    drs["MonthYear2"] = MonthYear;
                                                    drs["MonthName_Year2"] = MonthName;
                                                    drs["Principalamountdue2"] = Principalamountdue;
                                                    drs["noofinstallment2"] = noofinstallment;
                                                    drs["InterestAmount2"] = interestamount;
                                                }
                                                if (k == 2)
                                                {
                                                    drs["MonthYear3"] = MonthYear;
                                                    drs["MonthName_Year3"] = MonthName;
                                                    drs["Principalamountdue3"] = Principalamountdue;
                                                    drs["noofinstallment3"] = noofinstallment;
                                                    drs["InterestAmount3"] = interestamount;
                                                }
                                                if (k == 3)
                                                {
                                                    drs["MonthYear4"] = MonthYear;
                                                    drs["MonthName_Year4"] = MonthName;
                                                    drs["Principalamountdue4"] = Principalamountdue;
                                                    drs["noofinstallment4"] = noofinstallment;
                                                    drs["InterestAmount4"] = interestamount;
                                                }
                                                if (k == 4)
                                                {
                                                    drs["MonthYear5"] = MonthYear;
                                                    drs["MonthName_Year5"] = MonthName;
                                                    drs["Principalamountdue5"] = Principalamountdue;
                                                    drs["noofinstallment5"] = noofinstallment;
                                                    drs["InterestAmount5"] = interestamount;
                                                }
                                                if (k == 5)
                                                {
                                                    drs["MonthYear6"] = MonthYear;
                                                    drs["MonthName_Year6"] = MonthName;
                                                    drs["Principalamountdue6"] = Principalamountdue;
                                                    drs["noofinstallment6"] = noofinstallment;
                                                    drs["InterestAmount6"] = interestamount;
                                                }




                                                drs["IncentiveFYClaimID"] = IncentiveFYClaimID;
                                                drs["FirstsecondhalfyearID"] = firstsecondhalfyearclaimtype;
                                                drs["FinancialYearID"] = yeardataeachclaim;
                                                drs["FinancialYearName"] = eachclaimperiodName;
                                                drs["RateofInterest"] = rateofinterest;
                                                drs["InstallmentAmount"] = installmentamount;
                                                drs["forPresenthalfyeardueamount"] = forPresenthalfyeardueamount;
                                                drs["TotalInstallmentCompleted"] = TotalInstallmentCompleted;
                                                dt_grid.Rows.Add(drs);
                                            }
                                        }

                                        DataSet dsmain = new DataSet();
                                        dsmain.Tables.Add(dt_grid);
                                        grd_claimperiodfy.DataSource = dsmain.Tables[0];
                                        grd_claimperiodfy.DataBind();


                                    }
                                }
                                else
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero    \\n";
                                    slno = slno + 1;
                                }
                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter completed total installment should be less than total installment   \\n";
                                slno = slno + 1;
                            }
                        }
                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter installment start year, should be less than/equal to Current year   \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter EMI Start Month & year Above/equal to DCP Date  \\n";
                    slno = slno + 1;
                }
            }

        }

        // = Toteglibleperiodinmonths + 1;
        txt_Eligibleperiodinmonths.Text = Convert.ToString(Toteglibleperiodinmonths);
        txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(totalinterestforallfy);

        txt_Noofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
        txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(termprincipaldueamount);





        return ErrorMsg;
    }


    protected void grd_claimperiodfy_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

   
}