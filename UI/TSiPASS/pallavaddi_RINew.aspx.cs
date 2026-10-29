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

public partial class UI_TSiPASS_pallavaddi_RINew : System.Web.UI.Page
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
            //string incentiveid = "85769";

            // string incentiveid = "85339"; //BHARATH MINERALS

            string incentiveid = "84960"; //BHARATH MINERALS
            //string incentiveid = "51407"; //SPM POWER AND TELECOM PRIVATE LIMITED

            // string incentiveid = "75195";//KATRAVATH KAVITHA
            //string incentiveid = "88203";//KATRAVATH KAVITHA

            // string incentiveid = "33709";
            string MstIncentiveId = "1";//144722

            //string incentiveid = "75884";
            //string incentiveid = "87725";
            //string incentiveid = "61043";

            // string incentiveid = "84976"; //DHANALAXMI RICE INDUSTRIES

            // string incentiveid = "14444"; //M/S SADASHIVA OIL INDUSTRIES
            //string incentiveid = "112523"; //M/S SADASHIVA OIL INDUSTRIES
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

            //string incentiveid = "138878";
            //string incentiveid = "101360";
            //string incentiveid = Request.QueryString["incentiveid"].ToString();
            //string MstIncentiveId = Request.QueryString["MstIncentiveId"].ToString();
            USP_GETDETAILSFORSECTION(incentiveid, MstIncentiveId);
            txtINCNoEntry.Text = incentiveid;
            btnINCSearch_Click(sender, e);
            BindgetFYClaimperiod();
            // GetYearName_DB();
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
            lbl_schemetide.Text = Convert.ToString(ds.Tables[0].Rows[0]["Scheme"]);
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
               // DateofCommencementofactivity = Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]);
                //txt_DateofCommencementofactivity.Text =
                //    Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
            }
            else
            {
                txtDCP_unit.Text = "";
                // txt_DateofCommencementofactivity.Text = "";
            }


            if (ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"].ToString() != "")
            {
                txtrc_dic.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"]).ToString("dd/MM/yyyy");  //same date as application filed date..         
            }

            else
                txtrc_dic.Text = "";

            if (ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString() != null)
            {
                //txt_GMrecommendedamount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                txt_GMrecommendedamount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
            }
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
                if (ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString() != null)
                {
                    //  txt_GMrecommendedamount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                    txt_GMrecommendedamount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                }


                TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();

                TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
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
                grd_claimperiodofloanadd.DataSource = oDataSet.Tables[0];
                grd_claimperiodofloanadd.DataBind();
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


        bool status = true;
        try
        {
            TextBox txt_Eligibleamount = new TextBox();

            AssignValuestoVosFromcontrols();
            string returnval = obj_pallavaddi.INSERT_INCENTIVES_DATA_COMMON_appraisal_PAVALLAVADDILoan(oIncentiveVosA);

            //string returnval = InsertCommonData(oIncentiveVosA);
            if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
            {
                //line of activity
                SaveIncentiveDetailsFromGridViewToTable(Session["incentiveid"].ToString());
                InsertGridclaimloanNumber(returnval);
                insertallgrideachclaimperioddb(returnval);
                lstremarksad.Clear();
                string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                officerRemarks fromvo = new officerRemarks();
                fromvo.EnterperIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text.ToString();
                if(txt_Eligibleamount.Text !="")
                {
                    fromvo.Recomamount = Convert.ToDecimal(txt_Eligibleamount.Text);///
                }
                else
                {
                    fromvo.Recomamount = Convert.ToDecimal(oIncentiveVosA.FINALELIGIBLEAMOUNT);
                }

                    fromvo.MstIncentiveId = "1";
                fromvo.id = "";// ((Label)gvrow.FindControl("Label60")).Text.ToString();
                fromvo.status = "Recomm";
                fromvo.CreatedByid = oIncentiveVosA.createdby;// ((Label)gvrow.FindControl("Label59")).Text.ToString();
                fromvo.Designation = Role_Code.Trim();
                lstremarksad.Add(fromvo);
                officerForwarded frmvo = new officerForwarded();
                string lblMstIncentiveId = "1";
                string lblIncentiveID = oIncentiveVosA.incentiveid;// ((Label)gvrow.FindControl("Label58")).Text;
                                                                   //IncentiveID = lblIncentiveID;
                frmvo.EnterperIncentiveID = lblIncentiveID;
                frmvo.MstIncentiveId = lblMstIncentiveId;
                frmvo.CreatedByid = Session["uid"].ToString();
                frmvo.ApplicationFrom = Session["uid"].ToString();
                lstincentives.Add(frmvo);
                int valid = 0;
                valid = InsertincentiveOfficerCommentsAD(lstremarksad, lstincentives, getclientIP());
                // return true;
                status = true;
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "message", message, true);
                //return false;
                status = false;
            }
        }
        catch (Exception ex)
        {

        }
        return status;
    }


    public bool InsertGridclaimloanNumber(string SUBPallvaid)
    {
        bool checkstatus = true;
        Pallavaddiclaimloanproperties objgridclaimloanNumber = new Pallavaddiclaimloanproperties();

        objgridclaimloanNumber.Incentiveid = Convert.ToInt32(Session["incentiveid"]);
        objgridclaimloanNumber.APCDPVID = Convert.ToInt32(SUBPallvaid); 
        objgridclaimloanNumber.Createdby = Convert.ToString(Session["uid"]);
        objgridclaimloanNumber.CreatedIP= Request.ServerVariables["Remote_Addr"];
        objgridclaimloanNumber.Modifiedby = Convert.ToString(Session["uid"]);
        objgridclaimloanNumber.ModifiedIP= Request.ServerVariables["Remote_Addr"];

        for (int i = 0; i < grd_claimperiodofloanadd.Rows.Count; i++)
        {
            HiddenField hf_claimperiodofloanaddIncentiveId = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddIncentiveId") as HiddenField;
            HiddenField hf_claimperiodofloanaddFinancialYear = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddFinancialYear") as HiddenField;
            HiddenField hf_claimperiodofloanadd_ID = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanadd_ID") as HiddenField;
            Label lbl_claimperiodofloanaddname = grd_claimperiodofloanadd.Rows[i].FindControl("lbl_claimperiodofloanaddname") as Label;
            TextBox txt_claimperiodofloanaddNumber = grd_claimperiodofloanadd.Rows[i].FindControl("txt_claimperiodofloanaddNumber") as TextBox;

            objgridclaimloanNumber.ClaimPeriodID = Convert.ToString(hf_claimperiodofloanadd_ID.Value);
            objgridclaimloanNumber.ClaimPeriodName = Convert.ToString(lbl_claimperiodofloanaddname.Text);
            objgridclaimloanNumber.LoanCount = Convert.ToInt32(txt_claimperiodofloanaddNumber.Text);
            objgridclaimloanNumber.FinancialYear = Convert.ToString(hf_claimperiodofloanaddFinancialYear.Value);

            obj_pallavaddi.INSERT_PAVALLAVADDICLAIMLOANCOUNT(objgridclaimloanNumber);



        }


        return checkstatus;
    }


    public bool insertallgrideachclaimperioddb(string SUBPallvaid)
    {
        bool checkstatus = true;
        pallavaddiclaimLoandetailsproperties objgriduploads = new pallavaddiclaimLoandetailsproperties();


        objgriduploads.Incentiveid = Convert.ToInt32(Session["incentiveid"]);
        objgriduploads.APCDPVID = Convert.ToInt32(SUBPallvaid);
        objgriduploads.Createdby = Convert.ToString(Session["uid"]);
        objgriduploads.CreatedIP = Request.ServerVariables["Remote_Addr"];
        objgriduploads.Modifiedby = Convert.ToString(Session["uid"]);
        objgriduploads.ModifiedIP = Request.ServerVariables["Remote_Addr"];
        objgriduploads.totince_interestamountpaidaspercal = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        objgriduploads.totince_actualinterestamountpaid = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
        objgriduploads.totince_interestreimbersementcal = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
        objgriduploads.totince_interestreimbersementcal_finaleligibletype = Convert.ToString(txt_eglibleamountofreimbursementbyeglibletype.Text);
        objgriduploads.totince_gmrecommendedamount = Convert.ToDecimal(txt_GMrecommendedamount.Text);
        objgriduploads.totince_FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
        objgriduploads.totince_Conamountforcalintreimberest = Convert.ToDecimal(txt_ConsideredAmountofInterest.Text);

        for (int i = 0; i < grd_eglibilepallavaddi.Rows.Count; i++)
        {
            HiddenField hf_grdeglibilepallavaddiIncentiveId = grd_eglibilepallavaddi.Rows[i].FindControl("hf_grdeglibilepallavaddiIncentiveId") as HiddenField;
            HiddenField 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 = grd_eglibilepallavaddi.Rows[i].FindControl("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") as HiddenField;
            HiddenField hf_grdeglibilepallavaddiFY_ID = grd_eglibilepallavaddi.Rows[i].FindControl("hf_grdeglibilepallavaddiFY_ID") as HiddenField;

            Label lbl_grdeglibilepallavaddiFYname = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grdeglibilepallavaddiFYname") as Label;
            Label lbl_claimeglibleincentivesloanwiseLoanID = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_claimeglibleincentivesloanwiseLoanID") as Label;

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement") as TextBox;
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = grd_eglibilepallavaddi.Rows[i].FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment") as DropDownList;

            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwisenoofinstallment") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted") as TextBox;
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR") as TextBox;


            HiddenField hfgrd_monthoneid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monthoneid") as HiddenField;
            Label lbl_grd_monthonename = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthonename") as Label;
            Label lbl_grd_monthnonePrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthnonePrincipalamounntdue") as Label;
            Label lbl_grd_monthoneNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneNoofInstallment") as Label;
            TextBox lbl_grd_monthoneRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneRateofinterest") as TextBox;
            Label lbl_grd_monthoneInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneInterestamount") as Label;
            Label lbl_grd_monthoneUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneUnitHolderContribution") as Label;
            Label lbl_grd_monthoneEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneEligibleRateofinterest") as Label;
            Label lbl_grd_monthoneEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthoneEligibleInterestAmount") as Label;

            HiddenField hfgrd_monthtwoid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monthtwoid") as HiddenField;
            Label lbl_grd_monthtwoname = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoname") as Label;
            Label lbl_grd_monthtwoPrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoPrincipalamounntdue") as Label;
            Label lbl_grd_monthtwoNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoNoofInstallment") as Label;
            TextBox lbl_grd_monthtwoRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoRateofinterest") as TextBox;
            Label lbl_grd_monthtwoInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoInterestamount") as Label;
            Label lbl_grd_monthtwoUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoUnitHolderContribution") as Label;
            Label lbl_grd_monthtwoEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoEligibleRateofinterest") as Label;
            Label lbl_grd_monthtwoEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthtwoEligibleInterestAmount") as Label;

            HiddenField hfgrd_monththreeid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monththreeid") as HiddenField;
            Label lbl_grd_monththreename = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreename") as Label;
            Label lbl_grd_monththreePrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreePrincipalamounntdue") as Label;
            Label lbl_grd_monththreeNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeNoofInstallment") as Label;
            TextBox lbl_grd_monththreeRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeRateofinterest") as TextBox;
            Label lbl_grd_monththreeInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeInterestamount") as Label;
            Label lbl_grd_monththreeUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeUnitHolderContribution") as Label;
            Label lbl_grd_monththreeEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeEligibleRateofinterest") as Label;
            Label lbl_grd_monththreeEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monththreeEligibleInterestAmount") as Label;

            HiddenField hfgrd_monthfourid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monthfourid") as HiddenField;
            Label lbl_grd_monthfourname = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourname") as Label;
            Label lbl_grd_monthfourPrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourPrincipalamounntdue") as Label;
            Label lbl_grd_monthfourNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourNoofInstallment") as Label;
            TextBox lbl_grd_monthfourRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourRateofinterest") as TextBox;
            Label lbl_grd_monthfourInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourInterestamount") as Label;
            Label lbl_grd_monthfourUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourUnitHolderContribution") as Label;
            Label lbl_grd_monthfourEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourEligibleRateofinterest") as Label;
            Label lbl_grd_monthfourEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfourEligibleInterestAmount") as Label;

            HiddenField hfgrd_monthfiveid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monthfiveid") as HiddenField;
            Label lbl_grd_monthfivename = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfivename") as Label;
            Label lbl_grd_monthfivePrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfivePrincipalamounntdue") as Label;
            Label lbl_grd_monthfiveNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveNoofInstallment") as Label;
            TextBox lbl_grd_monthfiveRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveRateofinterest") as TextBox;
            Label lbl_grd_monthfiveInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveInterestamount") as Label;
            Label lbl_grd_monthfiveUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveUnitHolderContribution") as Label;
            Label lbl_grd_monthfiveEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveEligibleRateofinterest") as Label;
            Label lbl_grd_monthfiveEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthfiveEligibleInterestAmount") as Label;

            HiddenField hfgrd_monthsixid = grd_eglibilepallavaddi.Rows[i].FindControl("hfgrd_monthsixid") as HiddenField;
            Label lbl_grd_monthsixname = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixname") as Label;
            Label lbl_grd_monthsixPrincipalamounntdue = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixPrincipalamounntdue") as Label;
            Label lbl_grd_monthsixNoofInstallment = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixNoofInstallment") as Label;
            TextBox lbl_grd_monthsixRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixRateofinterest") as TextBox;
            Label lbl_grd_monthsixInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixInterestamount") as Label;
            Label lbl_grd_monthsixUnitHolderContribution = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixUnitHolderContribution") as Label;
            Label lbl_grd_monthsixEligibleRateofinterest = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixEligibleRateofinterest") as Label;
            Label lbl_grd_monthsixEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_monthsixEligibleInterestAmount") as Label;

            Label lbl_grd_totmonthsInterestamount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_totmonthsInterestamount") as Label;
            Label lbl_grd_totmonthsEligibleInterestAmount = grd_eglibilepallavaddi.Rows[i].FindControl("lbl_grd_totmonthsEligibleInterestAmount") as Label;

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths") as TextBox;
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations") as TextBox;
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseRateofInterest") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest") as TextBox;
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated") as TextBox;

            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = grd_eglibilepallavaddi.Rows[i].FindControl("rbtgrdeglibilepallavaddi_isbelated") as RadioButtonList;

            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype") as TextBox;
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiGMrecommendedamount") as TextBox;
            TextBox txt_grdeglibilepallavaddiEligibleamount = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiEligibleamount") as TextBox;


            objgriduploads.ClaimPeriodID = Convert.ToString(hf_grdeglibilepallavaddiFY_ID.Value);
            objgriduploads.ClaimPeriodName = Convert.ToString(lbl_grdeglibilepallavaddiFYname.Text);
            objgriduploads.LoanNumber = Convert.ToInt32(lbl_claimeglibleincentivesloanwiseLoanID.Text);

            string claimperiodddlvalue = hf_grdeglibilepallavaddiFY_ID.Value;
            string[] argclaimperiod = new string[5];
            argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017

            objgriduploads.ClaimPeriodFYID = Convert.ToString(argclaimperiod[0]);
            objgriduploads.ClaimPeriodFYSubID = Convert.ToString(argclaimperiod[2]);
            objgriduploads.IS1st2dhalfyear = Convert.ToString(argclaimperiod[1]);
            objgriduploads.dcpdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text);
            objgriduploads.loaninstallmentstartdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text);
            objgriduploads.tottermloanavil = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text);
            objgriduploads.Periodofinstallmentid = Convert.ToString(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedValue);
            objgriduploads.Periodofinstallmentname = Convert.ToString(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedItem.Text);
            objgriduploads.Noofinstallmentforloan = Convert.ToInt32(txt_claimeglibleincentivesloanwisenoofinstallment.Text);
            objgriduploads.Installmentamountforloan = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseInstallmentamount.Text);

            objgriduploads.NoofinstallmentcompletedfortheloanFY = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);
            objgriduploads.principalamountdueforhalfyrFY = Convert.ToDecimal(txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Text);

            objgriduploads.IsMortage = Convert.ToString("N");
            objgriduploads.ActualNoofinstallmentsCompleted = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);


            objgriduploads.PeriodofClaimMonth1ID = Convert.ToString(hfgrd_monthoneid.Value);
            objgriduploads.PeriodofClaimMonth1Name = Convert.ToString(lbl_grd_monthonename.Text);
            objgriduploads.PrincipalamountdueMonth1 = Convert.ToDecimal(lbl_grd_monthnonePrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth1 = Convert.ToInt32(lbl_grd_monthoneNoofInstallment.Text);
            objgriduploads.rateofinterestMonth1 = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
            objgriduploads.interestamountMonth1 = Convert.ToDecimal(lbl_grd_monthoneInterestamount.Text);
            objgriduploads.unitholdercontMonth1 = Convert.ToDecimal(lbl_grd_monthoneUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth1 = Convert.ToDecimal(lbl_grd_monthoneEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth1 = Convert.ToDecimal(lbl_grd_monthoneEligibleInterestAmount.Text);

            objgriduploads.PeriodofClaimMonth2ID = Convert.ToString(hfgrd_monthtwoid.Value);
            objgriduploads.PeriodofClaimMonth2Name = Convert.ToString(lbl_grd_monthtwoname.Text);
            objgriduploads.PrincipalamountdueMonth2 = Convert.ToDecimal(lbl_grd_monthtwoPrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth2 = Convert.ToInt32(lbl_grd_monthtwoNoofInstallment.Text);
            objgriduploads.rateofinterestMonth2 = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
            objgriduploads.interestamountMonth2 = Convert.ToDecimal(lbl_grd_monthtwoInterestamount.Text);
            objgriduploads.unitholdercontMonth2 = Convert.ToDecimal(lbl_grd_monthtwoUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth2 = Convert.ToDecimal(lbl_grd_monthtwoEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth2 = Convert.ToDecimal(lbl_grd_monthtwoEligibleInterestAmount.Text);

            objgriduploads.PeriodofClaimMonth3ID = Convert.ToString(hfgrd_monththreeid.Value);
            objgriduploads.PeriodofClaimMonth3Name = Convert.ToString(lbl_grd_monththreename.Text);
            objgriduploads.PrincipalamountdueMonth3 = Convert.ToDecimal(lbl_grd_monththreePrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth3 = Convert.ToInt32(lbl_grd_monththreeNoofInstallment.Text);
            objgriduploads.rateofinterestMonth3 = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
            objgriduploads.interestamountMonth3 = Convert.ToDecimal(lbl_grd_monththreeInterestamount.Text);
            objgriduploads.unitholdercontMonth3 = Convert.ToDecimal(lbl_grd_monththreeUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth3 = Convert.ToDecimal(lbl_grd_monththreeEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth3 = Convert.ToDecimal(lbl_grd_monththreeEligibleInterestAmount.Text);

            objgriduploads.PeriodofClaimMonth4ID = Convert.ToString(hfgrd_monthfourid.Value);
            objgriduploads.PeriodofClaimMonth4Name = Convert.ToString(lbl_grd_monthfourname.Text);
            objgriduploads.PrincipalamountdueMonth4 = Convert.ToDecimal(lbl_grd_monthfourPrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth4 = Convert.ToInt32(lbl_grd_monthfourNoofInstallment.Text);
            objgriduploads.rateofinterestMonth4 = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
            objgriduploads.interestamountMonth4 = Convert.ToDecimal(lbl_grd_monthfourInterestamount.Text);
            objgriduploads.unitholdercontMonth4 = Convert.ToDecimal(lbl_grd_monthfourUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth4 = Convert.ToDecimal(lbl_grd_monthfourEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth4 = Convert.ToDecimal(lbl_grd_monthfourEligibleInterestAmount.Text);

            objgriduploads.PeriodofClaimMonth5ID = Convert.ToString(hfgrd_monthfiveid.Value);
            objgriduploads.PeriodofClaimMonth5Name = Convert.ToString(lbl_grd_monthfivename.Text);
            objgriduploads.PrincipalamountdueMonth5 = Convert.ToDecimal(lbl_grd_monthfivePrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth5 = Convert.ToInt32(lbl_grd_monthfiveNoofInstallment.Text);
            objgriduploads.rateofinterestMonth5 = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
            objgriduploads.interestamountMonth5 = Convert.ToDecimal(lbl_grd_monthfiveInterestamount.Text);
            objgriduploads.unitholdercontMonth5 = Convert.ToDecimal(lbl_grd_monthfiveUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth5 = Convert.ToDecimal(lbl_grd_monthfiveEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth5 = Convert.ToDecimal(lbl_grd_monthfiveEligibleInterestAmount.Text);

            objgriduploads.PeriodofClaimMonth6ID = Convert.ToString(hfgrd_monthsixid.Value);
            objgriduploads.PeriodofClaimMonth6Name = Convert.ToString(lbl_grd_monthsixname.Text);
            objgriduploads.PrincipalamountdueMonth6 = Convert.ToDecimal(lbl_grd_monthsixPrincipalamounntdue.Text);
            objgriduploads.NoofInstallmentMonth6 = Convert.ToInt32(lbl_grd_monthsixNoofInstallment.Text);
            objgriduploads.rateofinterestMonth6 = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
            objgriduploads.interestamountMonth6 = Convert.ToDecimal(lbl_grd_monthsixInterestamount.Text);
            objgriduploads.unitholdercontMonth6 = Convert.ToDecimal(lbl_grd_monthsixUnitHolderContribution.Text);
            objgriduploads.eligiblerateofintersetMonth6 = Convert.ToDecimal(lbl_grd_monthsixEligibleRateofinterest.Text);
            objgriduploads.eligibleinterestamountMonth6 = Convert.ToDecimal(lbl_grd_monthsixEligibleInterestAmount.Text);

            objgriduploads.totmonthseligibleinterestamount = Convert.ToDecimal(lbl_grd_totmonthsInterestamount.Text);
            objgriduploads.totmonthsinterestamountMonth = Convert.ToDecimal(lbl_grd_totmonthsEligibleInterestAmount.Text);
            objgriduploads.eligibleperiodinmonths = Convert.ToDecimal(txt_grdeglibilepallavaddiEligibleperiodinmonths.Text);
            objgriduploads.CPL_interestamountpaidaspercal = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
            objgriduploads.CPL_actualinterestamountpaid = Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
            objgriduploads.Rateofinterestforloan = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseRateofInterest.Text);
            objgriduploads.Eligibleratereimbursementforlaon = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text);
            objgriduploads.CPL_Conamountforcalintreimberest = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text);
            objgriduploads.CPL_interestreimbersementcal = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text);
            objgriduploads.CPL_ELIGIBLETYPE = Convert.ToString(rbtgrdeglibilepallavaddi_isbelated.SelectedValue);
            objgriduploads.CPL_ELIGIBLETYPEName = Convert.ToString(rbtgrdeglibilepallavaddi_isbelated.SelectedItem.Text);
            objgriduploads.CPL_interestreimbersementcal_finaleligibletype = Convert.ToString(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text);
            objgriduploads.CPL_gmrecommendedamount = Convert.ToDecimal(txt_grdeglibilepallavaddiGMrecommendedamount.Text);
            objgriduploads.CPL_FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_grdeglibilepallavaddiEligibleamount.Text);

            string ClaimperiodeachUNID = obj_pallavaddi.INSERT_PAVALLAVADDICLAIMPERIODLOANDETAILS(objgriduploads);
            if (!string.IsNullOrEmpty(ClaimperiodeachUNID) && ClaimperiodeachUNID != "")
            {
                pallavadisubproperties objgrideachrowmonthwise = new pallavadisubproperties();

                objgrideachrowmonthwise.INCENTIVEID = Convert.ToString(Session["incentiveid"]);
                objgrideachrowmonthwise.IPADDRESS = Request.ServerVariables["Remote_Addr"];
                objgrideachrowmonthwise.CREATED_BY = Convert.ToString(Session["uid"]);
                objgrideachrowmonthwise.MODIFIED_BY = Convert.ToString(Session["uid"]);
                objgrideachrowmonthwise.SUBPallvaid = Convert.ToInt32(SUBPallvaid);
                objgrideachrowmonthwise.PVCPLHFID = Convert.ToInt32(ClaimperiodeachUNID);

                objgrideachrowmonthwise.CLAIMPERIOD_Grid = Convert.ToString(hf_grdeglibilepallavaddiFY_ID.Value);
                objgrideachrowmonthwise.CLAIMPERIODName_Grid = Convert.ToString(lbl_grdeglibilepallavaddiFYname.Text);
                objgrideachrowmonthwise.PERIODOFINSTALMENT_MAINTABLE = Convert.ToString(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedValue);
                objgrideachrowmonthwise.NOOFINSTALLMENTS_MAINTABLE = Convert.ToString(txt_claimeglibleincentivesloanwisenoofinstallment.Text);
                objgrideachrowmonthwise.NOOFINSTALMENTSCOMPLETED_Grid = Convert.ToString(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);
                objgrideachrowmonthwise.PeriodofinstallmentName = Convert.ToString(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedItem.Text);
                objgrideachrowmonthwise.InstallmentAmount = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseInstallmentamount.Text);
                objgrideachrowmonthwise.installmentstartmonthyear = Convert.ToString(txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text);
                objgrideachrowmonthwise.dcpdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text);
                objgrideachrowmonthwise.LoanNumber = Convert.ToInt32(lbl_claimeglibleincentivesloanwiseLoanID.Text);
                objgrideachrowmonthwise.IsMortage = Convert.ToString("N");
                objgrideachrowmonthwise.ActualNoofinstallmentsCompleted = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);

                //objgrideachrowmonthwise.principalamountduefornexthalfyr_grid = Convert.ToString();
                objgrideachrowmonthwise.CPL_interestamountpaidaspercal = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
                objgrideachrowmonthwise.CPL_actualinterestamountpaid = Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
                objgrideachrowmonthwise.CPL_Conamountforcalintreimberest = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text);
                objgrideachrowmonthwise.CPL_interestreimbersementcal = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text);
                objgrideachrowmonthwise.CPL_interestreimbersementcal_finaleligibletype = Convert.ToString(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text);
                objgrideachrowmonthwise.CPL_gmrecommendedamount = Convert.ToDecimal(txt_grdeglibilepallavaddiGMrecommendedamount.Text);
                objgrideachrowmonthwise.CPL_FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_grdeglibilepallavaddiEligibleamount.Text);

                objgrideachrowmonthwise.eligibleperiodinmonths = Convert.ToDecimal(txt_grdeglibilepallavaddiEligibleperiodinmonths.Text);
                objgrideachrowmonthwise.ELIGIBLETYPE = Convert.ToString(rbtgrdeglibilepallavaddi_isbelated.SelectedValue);
                objgrideachrowmonthwise.ELIGIBLETYPEName = Convert.ToString(rbtgrdeglibilepallavaddi_isbelated.SelectedItem.Text);
                objgrideachrowmonthwise.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
                objgrideachrowmonthwise.ACTUALINTERESTAMOUNTPAID = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
                objgrideachrowmonthwise.INTERESTREIMBERSEMENTCALCULATED = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
                objgrideachrowmonthwise.INTERESTREIMBERSEMENTCALCULATED_FINAL = Convert.ToDecimal(txt_eglibleamountofreimbursementbyeglibletype.Text);
                objgrideachrowmonthwise.GMRECOMMENDEDAMOUNT = Convert.ToDecimal(txt_GMrecommendedamount.Text);
                objgrideachrowmonthwise.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
                // objgrideachrowmonthwise.interestegliblereimbursement = Convert.ToString();
                objgrideachrowmonthwise.Conamountforcalintreimberest = Convert.ToDecimal(txt_ConsideredAmountofInterest.Text);



                objgrideachrowmonthwise.tottermloanavil = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text);
                objgrideachrowmonthwise.totmonthseligibleinterestamount = Convert.ToDecimal(lbl_grd_totmonthsInterestamount.Text);
                objgrideachrowmonthwise.totmonthsinterestamountMonth = Convert.ToDecimal(lbl_grd_totmonthsEligibleInterestAmount.Text);
                objgrideachrowmonthwise.Rateofinterestforloan = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseRateofInterest.Text);
                objgrideachrowmonthwise.Eligibleratereimbursementforlaon = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text);

                for (int j = 0; j < 6; j++)
                {
                    if (j == 0)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthoneid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthonename.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monthnonePrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monthoneNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monthoneInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monthoneUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monthoneEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monthoneEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);
                    }
                    if (j == 1)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthtwoid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthtwoname.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monthtwoPrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monthtwoNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monthtwoInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monthtwoUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monthtwoEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monthtwoEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);
                    }
                    if (j == 2)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monththreeid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monththreename.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monththreePrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monththreeNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monththreeInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monththreeUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monththreeEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monththreeEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);

                    }
                    if (j == 3)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthfourid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthfourname.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monthfourPrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monthfourNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monthfourInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monthfourUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monthfourEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monthfourEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);
                    }
                    if (j == 4)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthfiveid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthfivename.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monthfivePrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monthfiveNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monthfiveInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monthfiveUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monthfiveEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monthfiveEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);
                    }
                    if (j == 5)
                    {
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_ID_GRID = Convert.ToString(hfgrd_monthsixid.Value);
                        objgrideachrowmonthwise.PERIODOFCLAIM_MONTHWISE_VALUE_GRID = Convert.ToString(lbl_grd_monthsixname.Text);
                        objgrideachrowmonthwise.PRINCIPALAMOUNTDUE_GRID = Convert.ToDecimal(lbl_grd_monthsixPrincipalamounntdue.Text);
                        objgrideachrowmonthwise.NOOFINSTALLMENT_GRID = Convert.ToString(lbl_grd_monthsixNoofInstallment.Text);
                        objgrideachrowmonthwise.INTERESTAMOUNT_GRID = Convert.ToDecimal(lbl_grd_monthsixInterestamount.Text);
                        objgrideachrowmonthwise.unitholdercont = Convert.ToDecimal(lbl_grd_monthsixUnitHolderContribution.Text);
                        objgrideachrowmonthwise.eligiblerateofinterset = Convert.ToDecimal(lbl_grd_monthsixEligibleRateofinterest.Text);
                        objgrideachrowmonthwise.eligibleinterestamount = Convert.ToDecimal(lbl_grd_monthsixEligibleInterestAmount.Text);

                        objgrideachrowmonthwise.MonthRateofinterest = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
                        obj_pallavaddi.DB_INSERTPVCALIMSDATALOAN(objgrideachrowmonthwise);
                    }


                }

            }
        }






                return checkstatus;
    }


   

    public void AssignValuestoVosFromcontrols()
    {
        //oIncentiveVosA = new IncentiveVosAppraisal();

        oIncentiveVosA.lblApplicationno = lblApplicationno.Text;
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
        oIncentiveVosA.created_by = Session["uid"].ToString();
        oIncentiveVosA.modified_by = Session["uid"].ToString();
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
        oIncentiveVosA.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
        oIncentiveVosA.ACTUALINTERESTAMOUNT_PAID = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
        oIncentiveVosA.Conreburismentamount = Convert.ToDecimal(txt_ConsideredAmountofInterest.Text);
        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATED = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATED_FINAL = Convert.ToDecimal(txt_Insertreimbursementcalculated.Text);
        oIncentiveVosA.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype = Convert.ToDecimal(txt_eglibleamountofreimbursementbyeglibletype.Text);
        oIncentiveVosA.GMRECOMMENDEDAMOUNT = Convert.ToDecimal(txt_GMrecommendedamount.Text);
        oIncentiveVosA.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
        oIncentiveVosA.Remarks = txt_TotalRemarks.Text;
        oIncentiveVosA.Noofclaimperiods = grd_claimperiodofloanadd.Rows.Count;
        oIncentiveVosA.createdIP = Request.ServerVariables["Remote_Addr"];
        oIncentiveVosA.ModifiedIP = Request.ServerVariables["Remote_Addr"];

        oIncentiveVosA.Scheme = lbl_schemetide.Text;
        int dcpyearsofdate = 5;
        if (Convert.ToString(lbl_schemetide.Text) == "TPRIDE" || Convert.ToString(lbl_schemetide.Text) == "T-PRIDE" ||
            Convert.ToString(lbl_schemetide.Text).ToLower() == "tpride" || Convert.ToString(lbl_schemetide.Text).ToLower() == "t-pride")
        {
            dcpyearsofdate = 6;
        }
        oIncentiveVosA.Yrsfrmdcpdate= Convert.ToDecimal(dcpyearsofdate);



        //oIncentiveVosA.txt423guideline= "111";
        //oIncentiveVosA.txtTSSFCnorms423= "112";
        //oIncentiveVosA.txtvalue424= "113";
        // oIncentiveVosA.RDELIGIBLE= "134";
        // 

        //oIncentiveVosA.ELIGIBLESANCTIONEDAMOUNT= "137";
        //oIncentiveVosA.CLAIMPERIODID= "138";
        //oIncentiveVosA.CLAIMPERIOD= "139";
        //  oIncentiveVosA.DATEOFCOMMENCEMENTOFACTIVITY = DateTime.Now;
        //oIncentiveVosA.PERIODOFINSTALMENTID= "141";
        //oIncentiveVosA.INSTALMENTPERIOD= "142";
        //oIncentiveVosA.NOOFINSTALMENTS= "143";
        //oIncentiveVosA.INSTALMENTAMOUNT= 144;
        //oIncentiveVosA.INSTALMENTSTARTMONTHYEAR_ID= "145";
        //oIncentiveVosA.INSTALMENTSTARTMONTHYEAR_VALUE= "146";
        //   oIncentiveVosA.NOOFINSTALMENTS_COMPLETED= "149";
        // oIncentiveVosA.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR= "150";
        //
        //oIncentiveVosA.Valid = 157;
        //oIncentiveVosA.EglibleTypeID = "158";
        //oIncentiveVosA.EglibleTypeName = "159";
        // oIncentiveVosA.PERIODOFINSTALMENTName= "161";
        // oIncentiveVosA.IDENTITYCOCUMN= 163;
        //oIncentiveVosA.ELIGIBLETYPE= "168";
        //oIncentiveVosA.RATEOFINTEREST = "168";
        //oIncentiveVosA.ELIGIBLERATEOFREUMBERSEMENT ="168";






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



        //if (txtDateOfapplnFile.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter date of filing of application\\n";
        //    slno = slno + 1;
        //}
        //if (txtLoanApplnNo.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter In case term loan obtained from the Financial Institution/Bank Term loan \\n";
        //    slno = slno + 1;
        //}
        //if (txtDate_Loan.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter In case term loan obtained from the Financial Institution/Bank Term loan - Date  \\n";
        //    slno = slno + 1;
        //}
        #region
        //if (txtPowerConn_date.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Power connection with connected load - date\\n";
        //    slno = slno + 1;
        //}
        //if (txtPowerConn_load.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Power connection with connected load\\n";
        //    slno = slno + 1;
        //}

        //if (txtNameofFinIns.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Financing Institution\\n";
        //    slno = slno + 1;
        //}
        #endregion
        //if (txtDCP_unit.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of Commencement of Commercial production \\n";
        //    slno = slno + 1;
        //}
        //if (txtrc_dic.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of receipt of claim application(in DIC)\\n";
        //    slno = slno + 1;
        //}

        #region

        // Address
        //if (txtquery_dic.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of communication of shortfalls to the party(in DIC)\\n";
        //    slno = slno + 1;
        //}
        //if (txtcompdate_dic.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of receipt of complete information from the party(in DIC)\\n";
        //    slno = slno + 1;
        //}


        //if (txtcompdate_coi.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of receipt of claim application(in COI)\\n";
        //    slno = slno + 1;
        //}

        //if (txtcompdate_coi1.Text.ToString() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of receipt of complete information from the party (in COI)\\n";
        //    slno = slno + 1;
        //}
        //if (txtquery_coi.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Date of communication of shortfalls to the party(in COI)\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtLand7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of land purchased\\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtBuilding7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of building constructed \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtPM7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Plant & M/C \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}
        //if (txtMCont7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Tech.Knows -how feasibility \\n";
        //    slno = slno + 1;
        //}

        //if (txtErec2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtErec3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtErec4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtErec5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtErec6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtErec7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Vechicles\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtTFS7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Other eligible\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC2.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC3.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC4.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtWC7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Total\\n";
        //    slno = slno + 1;
        //}
        //if (txtLandcostCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtPurchaCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtStmpDutyCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtRegnfeeCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtTotalCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtBuildingAreCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtvalDICCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtvalCompc1.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtresonsCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - LAND\\n";
        //    slno = slno + 1;
        //}
        //if (txtfacCostCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtfacBldgCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtcivilEngCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtsfcCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtCAExpCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtCompvalCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (txtrsnCompc.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - FACTORY BUILDINGS\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox30.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox32.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox31.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox34.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox36.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox38.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox40.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox42.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox47.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computation of Capital Cost - PLANT AND MACHINERY\\n";
        //    slno = slno + 1;
        //}
        //if (TextBox33.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Landas per approved costs \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox37.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Buildingas per approved costs \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox41.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Plant and Machineryas per approved costs \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox44.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Know-how feasibility studyas per approved costs \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox56.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox57.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox58.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox45.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox35.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox39.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox43.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox46.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox48.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Remarks \\n";
        //    slno = slno + 1;
        //}
        //if (txt25BldgCvl.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (txt822guideline422.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (txtTSSFCnorms422.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (txtPlintharea424.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all valuecalleventforbackups of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (txtPlintharea422.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (txtvalue422.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of EXPANSION/DIVERSIFICATION CASES \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox60.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}

        //if (TextBox5.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox7.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox9.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox11.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox13.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox15.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox17.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox18.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox19.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox61.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox6.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox11.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox13.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox15.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox17.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox18.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        //if (TextBox19.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Approved Project Cost As Per Guidelines (Rs. in Lakhs)  \\n";
        //    slno = slno + 1;
        //}
        #endregion

        if (grd_claimperiodofloanadd.Rows.Count == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Claim Period Loan for each Claim\\n";
            slno = slno + 1;
        }
        if (grd_eglibilepallavaddi.Rows.Count == 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The Claim Period Details\\n";
            slno = slno + 1;
        }
        if (txt_Insertamounttobepaidaspercalculations.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Insert amount to be paid as per calculations \\n";
            slno = slno + 1;
        }
        if (txt_Actualinterestamountpaid.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Actual interest amount paid\\n";
            slno = slno + 1;
        }
        if (txt_ConsideredAmountofInterest.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Considered Amount of Interest \\n";
            slno = slno + 1;
        }
        if (txt_Insertreimbursementcalculated.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Interst reimbursement calculated \\n";
            slno = slno + 1;
        }
        if (txt_eglibleamountofreimbursementbyeglibletype.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Interst reimbursement(After selecting the eglible Type) \\n";
            slno = slno + 1;
        }
        if (txt_GMrecommendedamount.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". GM recommended amount\\n";
            slno = slno + 1;
        }
        if (txt_Eligibleamount.Text.ToString() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Eligible amount\\n";
            slno = slno + 1;
        }
      
        if(grd_claimperiodofloanadd.Rows.Count>0)
        {
            for (int i = 0; i < grd_claimperiodofloanadd.Rows.Count; i++)
            {
                HiddenField hf_claimperiodofloanaddIncentiveId = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddIncentiveId") as HiddenField;
                HiddenField hf_claimperiodofloanaddFinancialYear = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddFinancialYear") as HiddenField;
                HiddenField hf_claimperiodofloanadd_ID = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanadd_ID") as HiddenField;
                Label lbl_claimperiodofloanaddname = grd_claimperiodofloanadd.Rows[i].FindControl("lbl_claimperiodofloanaddname") as Label;
                TextBox txt_claimperiodofloanaddNumber = grd_claimperiodofloanadd.Rows[i].FindControl("txt_claimperiodofloanaddNumber") as TextBox;

                if (lbl_claimperiodofloanaddname.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-"+ (i+1) + ". Enter the Claim  Period"+ "\\n";
                    slno = slno + 1;
                }
                if (txt_claimperiodofloanaddNumber.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (i + 1) + ". Enter the Claim  Period No of Loan Applied" + "\\n";
                    slno = slno + 1;
                }
                else 
                {
                    if (Convert.ToInt32(txt_claimperiodofloanaddNumber.Text)<=0)
                    {
                        ErrorMsg = ErrorMsg + slno + "Claim-" + (i + 1) + ". Enter the Claim  Period No of Loan Applied greatet than zero" + "\\n";
                        slno = slno + 1;
                    }
                }
            }
        }


        if(grd_eglibilepallavaddi.Rows.Count>0)
        {
            for (int j = 0; j < grd_eglibilepallavaddi.Rows.Count; j++)
            {
                HiddenField hf_grdeglibilepallavaddiIncentiveId = grd_eglibilepallavaddi.Rows[j].FindControl("hf_grdeglibilepallavaddiIncentiveId") as HiddenField;
                HiddenField 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 = grd_eglibilepallavaddi.Rows[j].FindControl("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") as HiddenField;
                HiddenField hf_grdeglibilepallavaddiFY_ID = grd_eglibilepallavaddi.Rows[j].FindControl("hf_grdeglibilepallavaddiFY_ID") as HiddenField;

                Label lbl_grdeglibilepallavaddiFYname = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grdeglibilepallavaddiFYname") as Label;
                Label lbl_claimeglibleincentivesloanwiseLoanID = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_claimeglibleincentivesloanwiseLoanID") as Label;

                TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement") as TextBox;
                DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = grd_eglibilepallavaddi.Rows[j].FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment") as DropDownList;
                TextBox txt_claimeglibleincentivesloanwisenoofinstallment = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwisenoofinstallment") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseRateofInterest = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseRateofInterest") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted") as TextBox;
                TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR") as TextBox;

                HiddenField hfgrd_monthoneid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monthoneid") as HiddenField;
                Label lbl_grd_monthonename = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthonename") as Label;
                Label lbl_grd_monthnonePrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthnonePrincipalamounntdue") as Label;
                Label lbl_grd_monthoneNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneNoofInstallment") as Label;
                TextBox lbl_grd_monthoneRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneRateofinterest") as TextBox;
                Label lbl_grd_monthoneInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneInterestamount") as Label;
                Label lbl_grd_monthoneUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneUnitHolderContribution") as Label;
                Label lbl_grd_monthoneEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneEligibleRateofinterest") as Label;
                Label lbl_grd_monthoneEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthoneEligibleInterestAmount") as Label;

                HiddenField hfgrd_monthtwoid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monthtwoid") as HiddenField;
                Label lbl_grd_monthtwoname = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoname") as Label;
                Label lbl_grd_monthtwoPrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoPrincipalamounntdue") as Label;
                Label lbl_grd_monthtwoNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoNoofInstallment") as Label;
                TextBox lbl_grd_monthtwoRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoRateofinterest") as TextBox;
                Label lbl_grd_monthtwoInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoInterestamount") as Label;
                Label lbl_grd_monthtwoUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoUnitHolderContribution") as Label;
                Label lbl_grd_monthtwoEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoEligibleRateofinterest") as Label;
                Label lbl_grd_monthtwoEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthtwoEligibleInterestAmount") as Label;

                HiddenField hfgrd_monththreeid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monththreeid") as HiddenField;
                Label lbl_grd_monththreename = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreename") as Label;
                Label lbl_grd_monththreePrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreePrincipalamounntdue") as Label;
                Label lbl_grd_monththreeNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeNoofInstallment") as Label;
                TextBox lbl_grd_monththreeRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeRateofinterest") as TextBox;
                Label lbl_grd_monththreeInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeInterestamount") as Label;
                Label lbl_grd_monththreeUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeUnitHolderContribution") as Label;
                Label lbl_grd_monththreeEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeEligibleRateofinterest") as Label;
                Label lbl_grd_monththreeEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monththreeEligibleInterestAmount") as Label;

                HiddenField hfgrd_monthfourid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monthfourid") as HiddenField;
                Label lbl_grd_monthfourname = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourname") as Label;
                Label lbl_grd_monthfourPrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourPrincipalamounntdue") as Label;
                Label lbl_grd_monthfourNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourNoofInstallment") as Label;
                TextBox lbl_grd_monthfourRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourRateofinterest") as TextBox;
                Label lbl_grd_monthfourInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourInterestamount") as Label;
                Label lbl_grd_monthfourUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourUnitHolderContribution") as Label;
                Label lbl_grd_monthfourEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourEligibleRateofinterest") as Label;
                Label lbl_grd_monthfourEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfourEligibleInterestAmount") as Label;

                HiddenField hfgrd_monthfiveid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monthfiveid") as HiddenField;
                Label lbl_grd_monthfivename = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfivename") as Label;
                Label lbl_grd_monthfivePrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfivePrincipalamounntdue") as Label;
                Label lbl_grd_monthfiveNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveNoofInstallment") as Label;
                TextBox lbl_grd_monthfiveRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveRateofinterest") as TextBox;
                Label lbl_grd_monthfiveInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveInterestamount") as Label;
                Label lbl_grd_monthfiveUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveUnitHolderContribution") as Label;
                Label lbl_grd_monthfiveEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveEligibleRateofinterest") as Label;
                Label lbl_grd_monthfiveEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthfiveEligibleInterestAmount") as Label;

                HiddenField hfgrd_monthsixid = grd_eglibilepallavaddi.Rows[j].FindControl("hfgrd_monthsixid") as HiddenField;
                Label lbl_grd_monthsixname = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixname") as Label;
                Label lbl_grd_monthsixPrincipalamounntdue = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixPrincipalamounntdue") as Label;
                Label lbl_grd_monthsixNoofInstallment = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixNoofInstallment") as Label;
                TextBox lbl_grd_monthsixRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixRateofinterest") as TextBox;
                Label lbl_grd_monthsixInterestamount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixInterestamount") as Label;
                Label lbl_grd_monthsixUnitHolderContribution = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixUnitHolderContribution") as Label;
                Label lbl_grd_monthsixEligibleRateofinterest = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixEligibleRateofinterest") as Label;
                Label lbl_grd_monthsixEligibleInterestAmount = grd_eglibilepallavaddi.Rows[j].FindControl("lbl_grd_monthsixEligibleInterestAmount") as Label;

                TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths") as TextBox;
                TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations") as TextBox;
                TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid") as TextBox;
                TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated") as TextBox;
                RadioButtonList rbtgrdeglibilepallavaddi_isbelated = grd_eglibilepallavaddi.Rows[j].FindControl("rbtgrdeglibilepallavaddi_isbelated") as RadioButtonList;
                TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype") as TextBox;
                TextBox txt_grdeglibilepallavaddiGMrecommendedamount = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiGMrecommendedamount") as TextBox;
                TextBox txt_grdeglibilepallavaddiEligibleamount = grd_eglibilepallavaddi.Rows[j].FindControl("txt_grdeglibilepallavaddiEligibleamount") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = grd_eglibilepallavaddi.Rows[j].FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest") as TextBox;



                if (hf_grdeglibilepallavaddiIncentiveId.Value.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (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.Value.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (hf_grdeglibilepallavaddiFY_ID.Value.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
                if (lbl_grdeglibilepallavaddiFYname.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (lbl_claimeglibleincentivesloanwiseLoanID.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
                if (txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedIndex<0)
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
                if (txt_claimeglibleincentivesloanwisenoofinstallment.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
                if (txt_claimeglibleincentivesloanwiseInstallmentamount.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (txt_claimeglibleincentivesloanwiseRateofInterest.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
                if (txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
                if (txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
           
            if (hfgrd_monthoneid.Value.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
            if (lbl_grd_monthonename.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
            if (lbl_grd_monthnonePrincipalamounntdue.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthoneNoofInstallment.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthoneRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthoneInterestamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthoneUnitHolderContribution.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthoneEligibleRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthoneEligibleInterestAmount.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
         
            if (hfgrd_monthtwoid.Value.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthtwoname.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthtwoPrincipalamounntdue.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthtwoNoofInstallment.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthtwoRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
            if (lbl_grd_monthtwoInterestamount.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthtwoUnitHolderContribution.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monthtwoEligibleRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
            if (lbl_grd_monthtwoEligibleInterestAmount.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
     
            if (hfgrd_monththreeid.Value.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
            if (lbl_grd_monththreename.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
            if (lbl_grd_monththreePrincipalamounntdue.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monththreeNoofInstallment.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
            if (lbl_grd_monththreeRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                } 
            if (lbl_grd_monththreeInterestamount.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
            if (lbl_grd_monththreeUnitHolderContribution.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
            if (lbl_grd_monththreeEligibleRateofinterest.Text.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monththreeEligibleInterestAmount.Text.ToString() == "")
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
          
            if (hfgrd_monthfourid.Value.ToString() == "") 
                { 
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                } 
            if (lbl_grd_monthfourname.Text.ToString() == "") 
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j+1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1; 
                }
                if (lbl_grd_monthfourPrincipalamounntdue.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourNoofInstallment.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourInterestamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourUnitHolderContribution.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourEligibleRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfourEligibleInterestAmount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }

                if (hfgrd_monthfiveid.Value.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfivename.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfivePrincipalamounntdue.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveNoofInstallment.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveInterestamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveUnitHolderContribution.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveEligibleRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthfiveEligibleInterestAmount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }

                if (hfgrd_monthsixid.Value.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixname.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixPrincipalamounntdue.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixNoofInstallment.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixInterestamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixUnitHolderContribution.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixEligibleRateofinterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (lbl_grd_monthsixEligibleInterestAmount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiEligibleperiodinmonths.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiActualinterestamountpaid.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (rbtgrdeglibilepallavaddi_isbelated.SelectedIndex < 0)
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiGMrecommendedamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_grdeglibilepallavaddiEligibleamount.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Claim  Period" + "\\n"; slno = slno + 1;
                }
                if (txt_TotalRemarks.Text.ToString() == "")
                {
                    ErrorMsg = ErrorMsg + slno + "Claim-" + (j + 1) + ". Enter the Remarks" + "\\n"; slno = slno + 1;
                }

                



        }
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



 

    #region 

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {


            string errorgmsg = ValidateControls();
            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
                Response.Redirect("frmCoiDashboardclerk.aspx");
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
        catch (Exception ex)
        {
            throw ex;
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

    #endregion

   

    #region
    protected void btn_savegrdclaimperiodofloanadd_Click(object sender, EventArgs e)
    {
        DateTime? DateofCommencementofactivity = null;
        if(txtDCP_unit.Text!=null)
        {
            DateofCommencementofactivity =Convert.ToDateTime(txtDCP_unit.Text);
        }
        try
        {
            // DataSet ds_loantype = new DataSet();
            DataTable dt_grid = new DataTable();
            dt_grid.Columns.Add("IncentiveId", typeof(string));
            dt_grid.Columns.Add("FinancialYear", typeof(string));
            dt_grid.Columns.Add("FinancialYearID", typeof(string));
            dt_grid.Columns.Add("FinancialYearName", typeof(string));
            dt_grid.Columns.Add("LoanNumber", typeof(int));

            //dt_grid.Columns.Add("DCPDATE", typeof(DateTime?));
            //dt_grid.Columns.Add("InstallmentStartdate", typeof(DateTime?));
            dt_grid.Columns.Add("DCPDATE", typeof(string));
            dt_grid.Columns.Add("InstallmentStartdate", typeof(string));
            dt_grid.Columns.Add("TotalTermLoanAmt", typeof(decimal));

            dt_grid.Columns.Add("PeriodofinstallmentID", typeof(string));
            dt_grid.Columns.Add("PeriodofinstallmentName", typeof(string));
            dt_grid.Columns.Add("Noofinstallment", typeof(int));

            dt_grid.Columns.Add("RateofInterest", typeof(string));
            dt_grid.Columns.Add("EglibleRateofInterestreimbursement", typeof(string));
            dt_grid.Columns.Add("InstallmentAmount", typeof(string));
            dt_grid.Columns.Add("NoofInstallmentCompleted", typeof(string));
            dt_grid.Columns.Add("PrincipalAmountthishalfyear", typeof(string));
            dt_grid.Columns.Add("GM_Rcon_Amount", typeof(string));

            string GM_Rcon_Amount = "0";
            if(Convert.ToString(Session["GM_Rcon_Amount"])!="")
            {
                GM_Rcon_Amount = Convert.ToString(Session["GM_Rcon_Amount"]);
            }
            if (Convert.ToString(txt_GMrecommendedamount.Text) != "")
            {
                GM_Rcon_Amount = Convert.ToString(txt_GMrecommendedamount.Text);
            }


            for (int i = 0; i < grd_claimperiodofloanadd.Rows.Count; i++)
            {
                HiddenField hf_claimperiodofloanaddIncentiveId = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddIncentiveId") as HiddenField;
                HiddenField hf_claimperiodofloanaddFinancialYear = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanaddFinancialYear") as HiddenField;
                HiddenField hf_claimperiodofloanadd_ID = grd_claimperiodofloanadd.Rows[i].FindControl("hf_claimperiodofloanadd_ID") as HiddenField;
                Label lbl_claimperiodofloanaddname = grd_claimperiodofloanadd.Rows[i].FindControl("lbl_claimperiodofloanaddname") as Label;
                TextBox txt_claimperiodofloanaddNumber = grd_claimperiodofloanadd.Rows[i].FindControl("txt_claimperiodofloanaddNumber") as TextBox;


                if (!string.IsNullOrEmpty(txt_claimperiodofloanaddNumber.Text))
                {
                    if (Convert.ToInt32(txt_claimperiodofloanaddNumber.Text) > 0)
                    {

                        for (int loanid = 0; loanid < Convert.ToInt32(txt_claimperiodofloanaddNumber.Text); loanid++)
                        {
                            DataRow drs = dt_grid.NewRow();
                            int test = loanid + 1;
                            drs["LoanNumber"] = loanid + 1;
                            drs["IncentiveId"] = Convert.ToString(hf_claimperiodofloanaddIncentiveId.Value);
                            drs["FinancialYear"] = Convert.ToString(hf_claimperiodofloanaddFinancialYear.Value);
                            drs["FinancialYearID"] = Convert.ToString(hf_claimperiodofloanadd_ID.Value);
                            drs["FinancialYearName"] = Convert.ToString(lbl_claimperiodofloanaddname.Text);
                            drs["DCPDATE"] = DateofCommencementofactivity;
                            drs["GM_Rcon_Amount"] = GM_Rcon_Amount;
                            dt_grid.Rows.Add(drs);
                        }

                        // txt_DateofCommencementofactivity.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
                    }
                }


            }

            DataSet ds_loantype = new DataSet();
            ds_loantype.Tables.Add(dt_grid);
            if (dt_grid.Rows.Count > 0)
            {
                //grd_claimeglibleincentivesloanwise.DataSource = dt_grid;
                //grd_claimeglibleincentivesloanwise.DataBind();
                //grd_claimeglibleincentivesloanwise.Visible = true;
                grd_eglibilepallavaddi.DataSource = dt_grid;
                grd_eglibilepallavaddi.DataBind();
                grd_eglibilepallavaddi.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void txt_claimeglibleincentivesloanwiseDateofCommencementofactivity_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseinstallmentstartdate_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void ddl_claimeglibleincentivesloanwiseperiodofinstallment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList lnk_view = (DropDownList)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwisenoofinstallment_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseInstallmentamount_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseRateofInterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;
        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddiEligibleperiodinmonths_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow gvgrd_eglibilepallavaddiRow = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddiActualinterestamountpaid_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddiInsertreimbursementcalculated_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount,txt_grdeglibilepallavaddiEligibleamount,txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void rbtgrdeglibilepallavaddi_isbelated_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList lnk_view = (RadioButtonList)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount,txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

    }

    protected void txt_grdeglibilepallavaddiGMrecommendedamount_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }


    protected void lbl_grd_monthoneRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount,txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void lbl_grd_monthtwoRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void lbl_grd_monththreeRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void lbl_grd_monthfourRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void lbl_grd_monthfiveRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void lbl_grd_monthsixRateofinterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount,txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
, lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void txt_claimeglibleincentivesloanwiseConsideredAmountforInterest_TextChanged(object sender, EventArgs e)
    {
        TextBox lnk_view = (TextBox)sender;
        GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

        //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
        //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

        HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
        HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
        HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

        Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
        Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
        TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
        DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
        TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
        TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
        TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

        HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
        Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
        Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
        Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
        TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
        Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
        Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
        Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
        Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

        HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
        Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
        Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
        Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
        TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
        Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
        Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
        Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
        Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

        HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
        Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
        Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
        Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
        TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
        Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
        Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
        Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
        Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

        HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
        Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
        Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
        Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
        TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
        Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
        Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
        Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
        Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

        HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
        Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
        Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
        Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
        TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
        Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
        Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
        Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
        Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

        HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
        Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
        Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
        Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
        TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
        Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
        Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
        Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
        Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
        TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
        TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
        TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
        TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
        Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
        Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");


        string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
lbl_grd_monthsixEligibleInterestAmount,
txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount,txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
lbl_grd_totmonthsInterestamount,lbl_grd_totmonthsEligibleInterestAmount);


        if (errorgmsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errorgmsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    public string getdynamicallyeachrowdata_eligibleincentives(
    HiddenField hf_grdeglibilepallavaddiIncentiveId, HiddenField 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, HiddenField hf_grdeglibilepallavaddiFY_ID,
    Label lbl_grdeglibilepallavaddiFYname, Label lbl_claimeglibleincentivesloanwiseLoanID,
    TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity, TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate,
    TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement, DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment,
    TextBox txt_claimeglibleincentivesloanwisenoofinstallment, TextBox txt_claimeglibleincentivesloanwiseInstallmentamount,
    TextBox txt_claimeglibleincentivesloanwiseRateofInterest, TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement,
    TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted, TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    HiddenField hfgrd_monthoneid, Label lbl_grd_monthonename, Label lbl_grd_monthnonePrincipalamounntdue, Label lbl_grd_monthoneNoofInstallment,
    TextBox lbl_grd_monthoneRateofinterest, Label lbl_grd_monthoneInterestamount, Label lbl_grd_monthoneUnitHolderContribution,
    Label lbl_grd_monthoneEligibleRateofinterest, Label lbl_grd_monthoneEligibleInterestAmount,
    HiddenField hfgrd_monthtwoid, Label lbl_grd_monthtwoname, Label lbl_grd_monthtwoPrincipalamounntdue, Label lbl_grd_monthtwoNoofInstallment,
    TextBox lbl_grd_monthtwoRateofinterest, Label lbl_grd_monthtwoInterestamount, Label lbl_grd_monthtwoUnitHolderContribution,
    Label lbl_grd_monthtwoEligibleRateofinterest, Label lbl_grd_monthtwoEligibleInterestAmount,
    HiddenField hfgrd_monththreeid, Label lbl_grd_monththreename, Label lbl_grd_monththreePrincipalamounntdue, Label lbl_grd_monththreeNoofInstallment,
    TextBox lbl_grd_monththreeRateofinterest, Label lbl_grd_monththreeInterestamount, Label lbl_grd_monththreeUnitHolderContribution,
    Label lbl_grd_monththreeEligibleRateofinterest, Label lbl_grd_monththreeEligibleInterestAmount,
    HiddenField hfgrd_monthfourid, Label lbl_grd_monthfourname, Label lbl_grd_monthfourPrincipalamounntdue, Label lbl_grd_monthfourNoofInstallment,
    TextBox lbl_grd_monthfourRateofinterest, Label lbl_grd_monthfourInterestamount, Label lbl_grd_monthfourUnitHolderContribution,
    Label lbl_grd_monthfourEligibleRateofinterest, Label lbl_grd_monthfourEligibleInterestAmount,
    HiddenField hfgrd_monthfiveid, Label lbl_grd_monthfivename, Label lbl_grd_monthfivePrincipalamounntdue, Label lbl_grd_monthfiveNoofInstallment,
    TextBox lbl_grd_monthfiveRateofinterest, Label lbl_grd_monthfiveInterestamount, Label lbl_grd_monthfiveUnitHolderContribution,
    Label lbl_grd_monthfiveEligibleRateofinterest, Label lbl_grd_monthfiveEligibleInterestAmount,
    HiddenField hfgrd_monthsixid, Label lbl_grd_monthsixname, Label lbl_grd_monthsixPrincipalamounntdue, Label lbl_grd_monthsixNoofInstallment,
    TextBox lbl_grd_monthsixRateofinterest, Label lbl_grd_monthsixInterestamount, Label lbl_grd_monthsixUnitHolderContribution,
    Label lbl_grd_monthsixEligibleRateofinterest, Label lbl_grd_monthsixEligibleInterestAmount,
    TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths, TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    TextBox txt_grdeglibilepallavaddiActualinterestamountpaid, TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    RadioButtonList rbtgrdeglibilepallavaddi_isbelated, TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    TextBox txt_grdeglibilepallavaddiGMrecommendedamount, TextBox txt_grdeglibilepallavaddiEligibleamount,TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
     ,Label lbl_grd_totmonthsInterestamount, Label lbl_grd_totmonthsEligibleInterestAmount)
    {
        int slno = 1;
        string ErrorMsg = "";

        decimal Totalamount = 0; DateTime dcpdate = DateTime.Now; int periodofinstallment = 0;
        int Totalinstallment = 0; decimal installmentamount = 0;  int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
        int FYSlnoofIncentiveID = 0;
        int firstsecondhalfyearoffirstddlclaim = 0;
        int fyStartyear = 0;
        int fystartmonth = 0;
        int fyendyear = 0;
        int fyendmonth = 0;
        decimal rateofinterestMonthone = 0, rateofinterestMonthtwo = 0, rateofinterestMonththree = 0,
            rateofinterestMonthfour = 0, rateofinterestMonthfive = 0, rateofinterestMonthsix = 0;


        DateTime installmentstartdate = DateTime.Now;
        // ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of activity \\n";
        //slno = slno + 1;

        if (txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text != "")
        {
            Totalamount = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text);
        }
        if (txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
        {

            dcpdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text);
        }
        if (ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedIndex > 0)
        {
            periodofinstallment = Convert.ToInt32(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedValue);
        }

        if (txt_claimeglibleincentivesloanwisenoofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
        {
            Totalinstallment = Convert.ToInt32(txt_claimeglibleincentivesloanwisenoofinstallment.Text);
        }
      
        if (txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text.TrimStart().TrimEnd().Trim() != "")
        {

            installmentstartdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text);
        }


        if (!string.IsNullOrEmpty(hf_grdeglibilepallavaddiFY_ID.Value) || hf_grdeglibilepallavaddiFY_ID.Value != "")
        {
            string claimperiodddlvalue = hf_grdeglibilepallavaddiFY_ID.Value;
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

        
        if (Totalinstallment > 0 && Totalamount > 0)
        {
            installmentamount = Totalamount / Totalinstallment;
            txt_claimeglibleincentivesloanwiseInstallmentamount.Text = Convert.ToString(Math.Round(installmentamount, 2));
        }
        else
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
            slno = slno + 1;
        }



        if (lbl_grd_monthoneRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonthone = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
        }
        if (lbl_grd_monthtwoRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonthtwo = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
        }
        if (lbl_grd_monththreeRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonththree = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
        }
        if (lbl_grd_monthfourRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonthfour = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
        }
        if (lbl_grd_monthfiveRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonthfive = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
        }
        if (lbl_grd_monthsixRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterestMonthsix = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
        }

        decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0; decimal totaleglibleinterestforallfy = 0;
        if (dcpdate.Date != DateTime.Now.Date)
        {
            if (installmentstartdate.Date != DateTime.Now.Date)
            {
                if (dcpdate.Date < DateTime.Now.Date && installmentstartdate.Date < DateTime.Now.Date)
                {
                    if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0 &&
                      Totalinstallment > 0 && installmentamount > 0  && fyStartyear > 0 && fystartmonth > 0
                            && fyendyear > 0 && fyendmonth > 0 && installmentstartdate != null)
                    {
                        #region totalcompleted installmets
                        int totalmonthcal = 0;
                        int totaltwoyearscal = 0;
                        int totalmonthbwtwoyears = 0;
                        if (fyStartyear == installmentstartdate.Year)
                        {
                            totaltwoyearscal = 0;
                            if (fystartmonth > installmentstartdate.Month)
                            {
                                //dcp date start before financial year
                                totalmonthcal = (fystartmonth - installmentstartdate.Month);
                            }
                            else
                            {
                                totalmonthcal = 0;
                            }
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (installmentstartdate.Year < fyStartyear)
                        {
                            totaltwoyearscal = ((fyStartyear - installmentstartdate.Year) * 12);
                            totalmonthcal = (fystartmonth - installmentstartdate.Month);

                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (installmentstartdate.Year > fyStartyear)
                        {
                            totaltwoyearscal = 0;
                            totalmonthcal = 0;
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

                        int dcpyearsofdate = 5;
                        if(Convert.ToString(lbl_schemetide.Text)== "TPRIDE" || Convert.ToString(lbl_schemetide.Text) == "T-PRIDE" ||
                            Convert.ToString(lbl_schemetide.Text).ToLower() == "tpride" || Convert.ToString(lbl_schemetide.Text).ToLower() == "t-pride")
                        {
                            dcpyearsofdate = 6;
                        }
                           
                        DateTime fiveyearsdate = dcpdate.AddYears(dcpyearsofdate);
                        //DateTime fiveyearsdate = dcpdate.AddYears(5);
                        #endregion

                        #region principalamountdue amount for this half year
                        int pramounttotalmonthcal = 0;
                        int pramounttotaltwoyearscal = 0;
                        int pramounttotalmonthbwtwoyears = 0;
                        if (fyStartyear == dcpdate.Year)
                        {
                            if (dcpdate.Month < fystartmonth)
                            {
                                //dcp date started before financial year
                                pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                            }
                            else
                            {
                                //dcp date started after financial year/in same month
                                pramounttotalmonthcal = 0;
                            }
                            pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                        }
                        else
                        {
                            if (dcpdate.Year < fyStartyear)
                            {
                                //dcp date started before finanical year
                                pramounttotaltwoyearscal = ((fyStartyear - dcpdate.Year) * 12);
                                pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                                pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                            }
                            else
                            {
                                if (dcpdate.Year > fyStartyear)
                                {
                                    ////dcp date started after finanical year
                                    pramounttotaltwoyearscal = 0;
                                    pramounttotalmonthcal = 0;
                                    pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;

                                }
                            }

                        }
                        int pramountquotientcompleted = 0;
                        int pramountremaindercompleted = 0;
                        if (periodofinstallment == 1)
                        {
                            //Yearly
                            pramountquotientcompleted = totalmonthbwtwoyears / 12;
                            pramountremaindercompleted = totalmonthbwtwoyears % 12;

                        }
                        else if (periodofinstallment == 2)
                        {
                            //halfyear
                            pramountquotientcompleted = totalmonthbwtwoyears / 6;
                            pramountremaindercompleted = totalmonthbwtwoyears % 6;
                        }
                        else if (periodofinstallment == 3)
                        {
                            //quaertly
                            pramountquotientcompleted = totalmonthbwtwoyears / 3;
                            pramountremaindercompleted = totalmonthbwtwoyears % 3;
                        }
                        else if (periodofinstallment == 4)
                        {
                            //Monthly
                            pramountquotientcompleted = totalmonthbwtwoyears;
                        }
                        if (pramountquotientcompleted == 0)
                        {
                            termprincipaldueamount = Totalamount;
                        }
                        else
                        {
                            if (pramountremaindercompleted == 0)
                            {
                                termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                            }
                            else
                            {
                                termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                            }
                        }
                        #endregion
                        #region grid finanical years

                        if (noofinstallmentcompleted <= Totalinstallment)
                        {
                            int TotalInstallmentCompleted = 0;

                            if (termprincipaldueamount > 0)
                            {
                                DataTable dt_grid = new DataTable();
                                dt_grid.Columns.Add("RateofInterest", typeof(string));
                                dt_grid.Columns.Add("MonthYear", typeof(string));
                                dt_grid.Columns.Add("MonthName_Year", typeof(string));
                                dt_grid.Columns.Add("Principalamountdue", typeof(decimal));
                                dt_grid.Columns.Add("noofinstallment", typeof(int));
                                dt_grid.Columns.Add("InterestAmount", typeof(decimal));
                                dt_grid.Columns.Add("UnitHolderContribution", typeof(decimal));
                                dt_grid.Columns.Add("EligibleRateofInterest", typeof(decimal));
                                dt_grid.Columns.Add("EligibleInterestAmount", typeof(decimal));
                                int installmentstartmonthyear = 0;
                                decimal forPresenthalfyeardueamount = 0;
                                String eachclaimperiodID = Convert.ToString(hf_grdeglibilepallavaddiFY_ID.Value);
                                String eachclaimperiodName = Convert.ToString(lbl_grdeglibilepallavaddiFYname.Text);
                                string[] argeachclaimperiod = new string[5];
                                argeachclaimperiod = eachclaimperiodID.Split('/'); //32012/1/2016-2017
                                string IncentiveFYClaimID = Convert.ToString(argeachclaimperiod[0]);
                                int firstsecondhalfyearclaimtype = Convert.ToInt16(argeachclaimperiod[1]);
                                string yeardataeachclaim = Convert.ToString(argeachclaimperiod[2]);
                                string[] argeachyearclaimperiod = new string[5];
                                argeachyearclaimperiod = yeardataeachclaim.Split('-');
                                int fyeachStartyear = Convert.ToInt32(argeachyearclaimperiod[0]);
                                int fyeachendyear = Convert.ToInt32(argeachyearclaimperiod[1]);

                                TotalInstallmentCompleted = noofinstallmentcompleted;


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

                                    //condition 1- from Dcp date to claim period start date up to 5 years only claim inserest amount is given  
                                    DataRow drs = dt_grid.NewRow();
                                    dat.AddMonths(k).ToString("d");
                                    string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                                    string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
                                    //string MonthYear = 0+k + "/" + d1.Year;
                                    //string MonthName = 0 + k + "-" + d1.Year;
                                    int gridmonth = dat.AddMonths(k).Month;
                                    int gridyear = dat.AddMonths(k).Year;

                                    decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
                                    decimal UnitHolderContribution = 0; decimal EligibleRateofInterestofgrd = 0; decimal EligibleInterestAmount = 0;
                                    decimal rateofinterestofdt = 0;

                                    if (k==0)
                                    {
                                        rateofinterestofdt = rateofinterestMonthone;
                                    }
                                    if (k == 1)
                                    {
                                        rateofinterestofdt = rateofinterestMonthtwo;
                                    }
                                    if (k == 2)
                                    {
                                        rateofinterestofdt = rateofinterestMonththree;
                                    }
                                    if (k ==3)
                                    {
                                        rateofinterestofdt = rateofinterestMonthfour;
                                    }
                                    if (k == 4)
                                    {
                                        rateofinterestofdt = rateofinterestMonthfive;
                                    }
                                    if (k == 5)
                                    {
                                        rateofinterestofdt = rateofinterestMonthsix;
                                    }
                                    if (gridyear >= installmentstartdate.Year)
                                    {
                                        int gridtotaltwoyearscal = 0;
                                        int gridtotalmonthcal = 0;
                                        int gridtotalmonthbwyears = 0;
                                        // int gridtotalmonthbwyears = ((gridyear - installmentstartdate.Year) * 12) + (gridmonth - installmentstartdate.Month);
                                        if (gridyear == installmentstartdate.Year)
                                        {
                                            gridtotaltwoyearscal = 0;
                                            if (gridmonth > installmentstartdate.Month)
                                            {
                                                //installmentstartdate start before financial year
                                                gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                            }
                                            else
                                            {
                                                gridtotalmonthcal = 0;
                                                //installmentstartdate didn't start for that finanical year
                                                //gridtotalmonthcal = 0;
                                            }
                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                        }
                                        else if (installmentstartdate.Year < gridyear)
                                        {
                                            gridtotaltwoyearscal = ((gridyear - installmentstartdate.Year) * 12);
                                            gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                        }
                                        else if (installmentstartdate.Year > gridyear)
                                        {
                                            //in that year installmentstartdate didn't started
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
                                                if (gridquotientCompleted <= 0)
                                                {
                                                    if (gridremainder <= 0)
                                                    {
                                                        if (gridyear == installmentstartdate.Year)
                                                        {
                                                            if (gridmonth == installmentstartdate.Month)
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
                                                        if (gridyear == installmentstartdate.Year)
                                                        {
                                                            if (gridmonth == installmentstartdate.Month)
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
                                                        if (gridyear == installmentstartdate.Year)
                                                        {
                                                            if (gridmonth == installmentstartdate.Month)
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
                                                if (gridyear == installmentstartdate.Year)
                                                {
                                                    if (gridtotalmonthbwyears == 0)
                                                    {
                                                        if (gridmonth == installmentstartdate.Month)
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



                                        #region interest amount check dcp date,5 years from current date

                                        //DateTime fiveyearsdate = dcpdate.AddYears(5);
                                        if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                        {
                                            //installment date is less than 5 year date
                                            //then interest amount to be calculated  
                                            if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                            {
                                                //Above 5 years the interest amount is zero,
                                                //if same year & Same month then calcfor that many days;
                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                            }
                                            else
                                            {
                                                if (dat.AddMonths(k).Date > dcpdate.Date)
                                                {
                                                    if (dat.AddMonths(k).Year > dcpdate.Year)
                                                    {
                                                        //installment started and dcp date started;
                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                    }
                                                    else
                                                    {
                                                        if (dat.AddMonths(k).Year == dcpdate.Year)
                                                        {
                                                            //if same year & Same month then calcfor that many days;
                                                            if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                            {
                                                                if (noofinstallment > 0)
                                                                {
                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                                else
                                                                {
                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                                   
                                                            }
                                                            else
                                                            {
                                                                if (dat.AddMonths(k).Month > dcpdate.Month)
                                                                {
                                                                    if(noofinstallment>0)
                                                                    {
                                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        //installment not started,interest is given on term loan amount
                                                                        interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                                else
                                                {
                                                    //installment date started,before the dcp date,then
                                                    //if same year & Same month then calcfor that many days;
                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                    {
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                    }
                                                }



                                            }
                                        }
                                        else
                                        {
                                            //Above 5 years the interest amount is zero,
                                            //if same year & Same month then calcfor that many days;
                                            if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                            {
                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                            }
                                        }

                                        #endregion


                                       

                                        //   interestamount = (Principalamountdue * rateofinterestofdt) / 1200;

                                    }
                                    else
                                    {
                                        //Finincal year started,installment date not started check with dcp date

                                      


                                        #region interest amount check dcp date,5 years from current date

                                       
                                        if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                        {
                                            //installment date is less than 5 year date
                                            //then interest amount to be calculated  
                                                if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                            {
                                                //Above 5 years the interest amount is zero,
                                                //if same year & Same month then calcfor that many days;
                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                            }
                                            else
                                            {
                                                if (dat.AddMonths(k).Date > dcpdate.Date)
                                                {
                                                    if(dat.AddMonths(k).Year> dcpdate.Year)
                                                    {
                                                        //installment started and dcp date started;
                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                    }
                                                    else
                                                    {
                                                        if(dat.AddMonths(k).Year== dcpdate.Year)
                                                        {
                                                            //if same year & Same month then calcfor that many days;
                                                            if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                            {
                                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                            }
                                                            else
                                                            {
                                                                if(dat.AddMonths(k).Month> dcpdate.Month)
                                                                {
                                                                    //installment not started,interest is given on term loan amount
                                                                    // interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    if (noofinstallment > 0)
                                                                    {
                                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        //installment not started,interest is given on term loan amount
                                                                        interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        
                                                    }
                                                }
                                                else
                                                {
                                                    //installment date started,before the dcp date,then
                                                    //if same year & Same month then calcfor that many days;
                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                    {
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                    }
                                                }


                                                   
                                            }
                                        }
                                        else
                                        {
                                            //Above 5 years the interest amount is zero,
                                            //if same year & Same month then calcfor that many days;
                                            if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                            {
                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                            }
                                        }

                                        #endregion


                                    }


                                    if (interestamount > 0)
                                    {

                                        EligibleRateofInterestofgrd = rateofinterestofdt-3;
                                        if(EligibleRateofInterestofgrd>=9)
                                        {
                                            EligibleRateofInterestofgrd = 9;
                                        }
                                        if(EligibleRateofInterestofgrd<0)
                                        {
                                            EligibleRateofInterestofgrd = 0;
                                        }
                                        UnitHolderContribution = rateofinterestofdt - EligibleRateofInterestofgrd;
                                        EligibleInterestAmount = (interestamount * EligibleRateofInterestofgrd) / rateofinterestofdt;


                                        if (gridyear == dcpdate.Year && gridmonth == dcpdate.Month)
                                        {
                                            int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                            double daysforcal = 1 - (Convert.ToDouble(dcpdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                            Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                        }
                                        else
                                        {
                                            DateTime startDateofeachmonthgrd = new DateTime(gridyear, gridmonth, 1);
                                            if (dcpdate.Date < startDateofeachmonthgrd.Date)
                                            {
                                                if(fiveyearsdate.Year== gridyear && gridmonth == fiveyearsdate.Month)
                                                {
                                                    int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                                    double daysforcal = 1 - (Convert.ToDouble(fiveyearsdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                }
                                                else
                                                {
                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                }
                                                
                                            }
                                            else
                                            {

                                            }

                                           
                                        }
                                    }

                                    totalinterestforallfy = totalinterestforallfy + interestamount;
                                    totaleglibleinterestforallfy = totaleglibleinterestforallfy + EligibleInterestAmount;



                                    drs["MonthYear"] = MonthYear;
                                    drs["MonthName_Year"] = MonthName;
                                    drs["Principalamountdue"] = Convert.ToString(Math.Round(Principalamountdue, 2));
                                    drs["noofinstallment"] = noofinstallment;
                                    drs["InterestAmount"] = Convert.ToString(Math.Round(interestamount, 2));
                                    drs["RateofInterest"] = rateofinterestofdt;
                                    drs["EligibleRateofInterest"] = EligibleRateofInterestofgrd;
                                    drs["UnitHolderContribution"] = UnitHolderContribution;
                                    drs["EligibleInterestAmount"] = Convert.ToString(Math.Round(EligibleInterestAmount));


                                    dt_grid.Rows.Add(drs);
                                }


                                DataSet dsmain = new DataSet();
                                dsmain.Tables.Add(dt_grid);
                               
                                if (dt_grid.Rows.Count > 0)
                                {
                                    for (int t = 0; t < dt_grid.Rows.Count; t++)
                                    {
                                        if (t == 0)
                                        {
                                            hfgrd_monthoneid.Value = Convert.ToString(dt_grid.Rows[0]["MonthYear"]);
                                            lbl_grd_monthonename.Text = Convert.ToString(dt_grid.Rows[0]["MonthName_Year"]);
                                            lbl_grd_monthnonePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[0]["Principalamountdue"]);
                                            lbl_grd_monthoneNoofInstallment.Text = Convert.ToString(dt_grid.Rows[0]["noofinstallment"]);
                                            lbl_grd_monthoneRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["RateofInterest"]);
                                            lbl_grd_monthoneInterestamount.Text = Convert.ToString(dt_grid.Rows[0]["InterestAmount"]);
                                            lbl_grd_monthoneUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[0]["UnitHolderContribution"]);
                                            lbl_grd_monthoneEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["EligibleRateofInterest"]);
                                            lbl_grd_monthoneEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[0]["EligibleInterestAmount"]);
                                        }
                                        if (t == 1)
                                        {
                                            hfgrd_monthtwoid.Value = Convert.ToString(dt_grid.Rows[1]["MonthYear"]);
                                            lbl_grd_monthtwoname.Text = Convert.ToString(dt_grid.Rows[1]["MonthName_Year"]);
                                            lbl_grd_monthtwoPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[1]["Principalamountdue"]);
                                            lbl_grd_monthtwoNoofInstallment.Text = Convert.ToString(dt_grid.Rows[1]["noofinstallment"]);
                                            lbl_grd_monthtwoRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["RateofInterest"]);
                                            lbl_grd_monthtwoInterestamount.Text = Convert.ToString(dt_grid.Rows[1]["InterestAmount"]);
                                            lbl_grd_monthtwoUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[1]["UnitHolderContribution"]);
                                            lbl_grd_monthtwoEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["EligibleRateofInterest"]);
                                            lbl_grd_monthtwoEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[1]["EligibleInterestAmount"]);
                                        }
                                        if (t == 2)
                                        {
                                            hfgrd_monththreeid.Value = Convert.ToString(dt_grid.Rows[2]["MonthYear"]);
                                            lbl_grd_monththreename.Text = Convert.ToString(dt_grid.Rows[2]["MonthName_Year"]);
                                            lbl_grd_monththreePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[2]["Principalamountdue"]);
                                            lbl_grd_monththreeNoofInstallment.Text = Convert.ToString(dt_grid.Rows[2]["noofinstallment"]);
                                            lbl_grd_monththreeRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["RateofInterest"]);
                                            lbl_grd_monththreeInterestamount.Text = Convert.ToString(dt_grid.Rows[2]["InterestAmount"]);
                                            lbl_grd_monththreeUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[2]["UnitHolderContribution"]);
                                            lbl_grd_monththreeEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["EligibleRateofInterest"]);
                                            lbl_grd_monththreeEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[2]["EligibleInterestAmount"]);
                                        }
                                        if (t == 3)
                                        {
                                            hfgrd_monthfourid.Value = Convert.ToString(dt_grid.Rows[3]["MonthYear"]);
                                            lbl_grd_monthfourname.Text = Convert.ToString(dt_grid.Rows[3]["MonthName_Year"]);
                                            lbl_grd_monthfourPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[3]["Principalamountdue"]);
                                            lbl_grd_monthfourNoofInstallment.Text = Convert.ToString(dt_grid.Rows[3]["noofinstallment"]);
                                            lbl_grd_monthfourRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["RateofInterest"]);
                                            lbl_grd_monthfourInterestamount.Text = Convert.ToString(dt_grid.Rows[3]["InterestAmount"]);
                                            lbl_grd_monthfourUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[3]["UnitHolderContribution"]);
                                            lbl_grd_monthfourEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["EligibleRateofInterest"]);
                                            lbl_grd_monthfourEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[3]["EligibleInterestAmount"]);
                                        }
                                        if (t == 4)
                                        {
                                            hfgrd_monthfiveid.Value = Convert.ToString(dt_grid.Rows[4]["MonthYear"]);
                                            lbl_grd_monthfivename.Text = Convert.ToString(dt_grid.Rows[4]["MonthName_Year"]);
                                            lbl_grd_monthfivePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[4]["Principalamountdue"]);
                                            lbl_grd_monthfiveNoofInstallment.Text = Convert.ToString(dt_grid.Rows[4]["noofinstallment"]);
                                            lbl_grd_monthfiveRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["RateofInterest"]);
                                            lbl_grd_monthfiveInterestamount.Text = Convert.ToString(dt_grid.Rows[4]["InterestAmount"]);
                                            lbl_grd_monthfiveUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[4]["UnitHolderContribution"]);
                                            lbl_grd_monthfiveEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["EligibleRateofInterest"]);
                                            lbl_grd_monthfiveEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[4]["EligibleInterestAmount"]);
                                        }
                                        if (t == 5)
                                        {
                                            hfgrd_monthsixid.Value = Convert.ToString(dt_grid.Rows[5]["MonthYear"]);
                                            lbl_grd_monthsixname.Text = Convert.ToString(dt_grid.Rows[5]["MonthName_Year"]);
                                            lbl_grd_monthsixPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[5]["Principalamountdue"]);
                                            lbl_grd_monthsixNoofInstallment.Text = Convert.ToString(dt_grid.Rows[5]["noofinstallment"]);
                                            lbl_grd_monthsixRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["RateofInterest"]);
                                            lbl_grd_monthsixInterestamount.Text = Convert.ToString(dt_grid.Rows[5]["InterestAmount"]);
                                            lbl_grd_monthsixUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[5]["UnitHolderContribution"]);
                                            lbl_grd_monthsixEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["EligibleRateofInterest"]);
                                            lbl_grd_monthsixEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[5]["EligibleInterestAmount"]);
                                        }
                                    }
                                }



                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero \\n";
                                slno = slno + 1;
                            }
                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter completed total installment should be less than total installment   \\n";
                            slno = slno + 1;
                        }

                        #endregion

                    }
                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start date Should be less than current date \\n";
                    slno = slno + 1;
                }
            }
        }


        txt_grdeglibilepallavaddiEligibleperiodinmonths.Text = Convert.ToString(Math.Round(Toteglibleperiodinmonths, 2));
        txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));

        txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
        txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(Math.Round(termprincipaldueamount, 2));

        lbl_grd_totmonthsInterestamount.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));
        lbl_grd_totmonthsEligibleInterestAmount.Text = Convert.ToString(Math.Round(totaleglibleinterestforallfy, 2));

        decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
        decimal rateofinterest = 0; decimal egliblerateofinterest = 0; decimal interestegliblereimbursement = 0;
        decimal eglibleamountofreimbursementbyeglibletype = 0;decimal GMrecommendedamount = 0;decimal finalegibleamountdisscussed = 0;

        if (txt_grdeglibilepallavaddiGMrecommendedamount.Text != "")
        {
            GMrecommendedamount = Convert.ToDecimal(txt_grdeglibilepallavaddiGMrecommendedamount.Text);
        }

        if (txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text != "")
        {
            totalgridinterestamount = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
        }

        if (txt_grdeglibilepallavaddiActualinterestamountpaid.Text != "")
        {
            actualinterestamountpaid = Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
        }
        if (txt_claimeglibleincentivesloanwiseRateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
        {
            rateofinterest = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseRateofInterest.Text);
        }
      
        if (totalgridinterestamount > 0)
        {
            if (totalgridinterestamount > 0)
            {
                if (rateofinterest != 0)
                {
                    if (rateofinterest >3)
                    {
                        egliblerateofinterest = rateofinterest - 3;
                        if (egliblerateofinterest > 9)
                        {
                            egliblerateofinterest = 9;
                        }
                        if (egliblerateofinterest > 0)
                        {
                            if (totalgridinterestamount < actualinterestamountpaid)
                            {
                                interestamountcondisered = totalgridinterestamount;
                            }
                            else
                            {
                                interestamountcondisered = actualinterestamountpaid;
                            }
                            interestegliblereimbursement = (interestamountcondisered * egliblerateofinterest) / rateofinterest;
                        }
                        else
                        {
                            //Please Enter Eglible Rate of interest
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Eglible rate of remibursement less than zero \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    //Please Enter Rate of interest
                        ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest \\n";
                        slno = slno + 1;
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
            if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "0")
            {
                //More than an Year
                eglibleamountofreimbursementbyeglibletype = 0;
                txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);

            }
            else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "Y")
            {
                //Regular
                eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement;
                txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
            }
            else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "N")
            {
                //Belated
                eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement / 2;
                txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
            }
            else
            {
                //Please Select Eglible Type
            }
        }

        if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
        {
            finalegibleamountdisscussed = GMrecommendedamount;
        }

        else
        {
            finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
        }

        txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
        txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text = Convert.ToString(Math.Round(interestegliblereimbursement, 2));
        txt_grdeglibilepallavaddiEligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
        txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text = Convert.ToString(Math.Round(interestamountcondisered, 2));
        interestamountcalacutionsofgrdeligible();
        return ErrorMsg;
    }
 
    
    protected void txt_GMrecommendedamount_TextChanged(object sender, EventArgs e)
    {
        interestamountcalacutionsofgrdeligible();
    }

    void interestamountcalacutionsofgrdeligible()
    {
        decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
        decimal interestegliblereimbursement = 0; decimal eglibleamountofreimbursementbyeglibletype = 0;
        decimal GMrecommendedamount = 0; decimal finalegibleamountdisscussed = 0;

        for (int i = 0; i < grd_eglibilepallavaddi.Rows.Count; i++)
        {
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations") as TextBox;
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid") as TextBox;
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated") as TextBox;
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype") as TextBox;
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest") as TextBox;
            
            if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text))
            {
                totalgridinterestamount = totalgridinterestamount + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
            }

            if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiActualinterestamountpaid.Text))
            {
                actualinterestamountpaid = actualinterestamountpaid + Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
            }

            if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text))
            {
                interestegliblereimbursement = interestegliblereimbursement + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text);
            }

            if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text))
            {
                eglibleamountofreimbursementbyeglibletype = eglibleamountofreimbursementbyeglibletype + Convert.ToDecimal(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text);
            }

            if (!string.IsNullOrEmpty(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text))
            {
                interestamountcondisered = interestamountcondisered + Convert.ToDecimal(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text);
            }
            
        }

        txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(totalgridinterestamount);
        txt_Actualinterestamountpaid.Text = Convert.ToString(actualinterestamountpaid);
        txt_Insertreimbursementcalculated.Text = Convert.ToString(interestegliblereimbursement);
        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);
        txt_ConsideredAmountofInterest.Text = Convert.ToString(interestamountcondisered);
        if (txt_GMrecommendedamount.Text != "")
        {
            GMrecommendedamount = Convert.ToDecimal(txt_GMrecommendedamount.Text);
        }
        if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
        {
            finalegibleamountdisscussed = GMrecommendedamount;
        }
        else
        {
            finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
        }
        txt_Eligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
    }

    #endregion







}

#region 

//public void testin()
//{
//    DateTime dcpdate = DateTime.Now;
//    DateTime dat = DateTime.Now;
//    decimal interestamount = 0;


//    #region interest amount check dcp date,5 years from current date

//    DateTime fiveyearsdate = dcpdate.AddYears(5);
//    if (dat <= fiveyearsdate.Date)
//    {

//        //installment date is less than 5 year date
//        //then interest amount to be calculated  
//        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
//        {
//            //Above 5 years the interest amount is zero,
//            //if same year & Same month then calcfor that many days;
//            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
//            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//        }
//        else
//        {

//            if (dat.AddMonths(k).Date < dcpdate.Date)
//            {
//                //installment date started,before the dcp date,then
//                //if same year & Same month then calcfor that many days;
//                if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                {
//                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//                }
//            }
//            else
//            {
//                //installment date started, the dcp date started,then
//                //if same year & Same month then calcfor that many days;
//                if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                {
//                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//                }
//                else
//                {
//                    if (dat.AddMonths(k).Date > dcpdate.Date)
//                    {
//                        //installment not started,interest is given on term loan amount
//                        interestamount = (Totalamount * rateofinterestofdt) / 1200;
//                    }
//                    else
//                    {
//                        //installment started and dcp date started;
//                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
//                    }
//                }
//            }
//        }
//    }
//    else
//    {
//        //clear
//        //Above 5 years the interest amount is zero,
//        //if same year & Same month then calcfor that many days;
//        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
//        {
//            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
//            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//        }
//    }

//    #endregion

//}

//interest amount check dcp date,5 years from current date

//DateTime fiveyearsdate = dcpdate.AddYears(5);
//                                        if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
//                                        {

//                                            //installment date is less than 5 year date
//                                            //then interest amount to be calculated  
//                                            if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
//                                            {
//                                                //Above 5 years the interest amount is zero,
//                                                //if same year & Same month then calcfor that many days;
//                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                            }
//                                            else
//                                            {

//                                                if (dat.AddMonths(k).Date<dcpdate.Date)
//                                                {
//                                                    //installment date started,before the dcp date,then
//                                                    //if same year & Same month then calcfor that many days;
//                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                                                    {
//                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    //installment date started, the dcp date started,then
//                                                    //if same year & Same month then calcfor that many days;
//                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                                                    {
//                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                                    }
//                                                    else
//                                                    {
//                                                        if (dat.AddMonths(k).Date> dcpdate.Date)
//                                                        {
//                                                            //installment not started,interest is given on term loan amount
//                                                            interestamount = (Totalamount* rateofinterestofdt) / 1200;
//                                                        }
//                                                        else
//                                                        {
//                                                            //installment started and dcp date started;
//                                                            interestamount = (Principalamountdue* rateofinterestofdt) / 1200;
//                                                        }
//                                                    }
//                                                }
//                                            }
//                                        }
//                                        else
//                                        {
//                                            //Above 5 years the interest amount is zero,
//                                            //if same year & Same month then calcfor that many days;
//                                            if((dat.AddMonths(k).Year==fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
//                                            {
//                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                            }
//                                        }

#endregion

#region
// if (dat.AddMonths(k).Date<dcpdate.Date)
//                                                {
//                                                    //installment date started,before the dcp date,then
//                                                    //if same year & Same month then calcfor that many days;
//                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                                                    {
//                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    //installment date started, the dcp date started,then
//                                                    //if same year & Same month then calcfor that many days;
//                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
//                                                    {
//                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
//int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//interestamount = (pramountpaidfordays* rateofinterestofdt) / 1200;
//                                                    }
//                                                    else
//                                                    {
//                                                        if (dat.AddMonths(k).Date > dcpdate.Date)
//                                                        {
//                                                            //installment started and dcp date started;
//                                                            interestamount = (Principalamountdue* rateofinterestofdt) / 1200;

//                                                        }
//                                                        else
//                                                        {
//                                                            //installment not started,interest is given on term loan amount
//                                                            interestamount = (Totalamount* rateofinterestofdt) / 1200;
//                                                        }
//                                                    }
//                                                }
//TextBox txt_Eligibleamount = new TextBox();
//TextBox txt_noofinstallment = new TextBox();
//TextBox txt_Installmentamount = new TextBox();
//TextBox txt_Insertamounttobepaidaspercalculations = new TextBox();
//TextBox txt_Actualinterestamountpaid = new TextBox();
//TextBox txt_Insertreimbursementcalculated = new TextBox();
//TextBox txt_GMrecommendedamount = new TextBox();
//TextBox txt_eglibleamountofreimbursementbyeglibletype = new TextBox();
//TextBox txt_Eligibleperiodinmonths = new TextBox();
//TextBox txt_DateofCommencementofactivity = new TextBox();
//TextBox txt_installmentstartdate = new TextBox();
//TextBox txt_eglsacamountinterestreimbursement = new TextBox();
//TextBox txt_RateofInterest = new TextBox();
//TextBox txt_Eligiblerateofreimbursement = new TextBox();
//TextBox txt_Noofinstallmentscompleted = new TextBox();
//TextBox txt_PrincipalamountbecomeDUEbeforethisHALFYEAR = new TextBox();

//GridView grd_Addclaimperiod = new GridView();
//DropDownList ddl_periodofinstallment = new DropDownList();
//RadioButtonList rbtgrd_isbelated = new RadioButtonList();
//DropDownList ddl_ClaimPeriod = new DropDownList();
//GridView grd_claimeglibleincentivesloanwise = new GridView();
//TextBox txt_Eligibleamount = new TextBox();
//TextBox txt_Eligibleamount = new TextBox();
//TextBox txt_Eligibleamount = new TextBox();

//protected void txt_Insertamounttobepaidaspercalculations_TextChanged(object sender, EventArgs e)
//{
//    interestamountcalacutions();
//}

//protected void txt_Actualinterestamountpaid_TextChanged(object sender, EventArgs e)
//{
//    interestamountcalacutions();
//}

//protected void rbtgrd_isbelated_TextChanged(object sender, EventArgs e)
//{
//    interestamountcalacutions();
//}

//void interestamountcalacutions()
//{
//    //decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
//    //decimal rateofinterest = 0; decimal egliblerateofinterest = 0; decimal interestegliblereimbursement = 0;
//    //decimal eglibleamountofreimbursementbyeglibletype = 0;
//    //decimal GMrecommendedamount = 0;
//    //decimal finalegibleamountdisscussed = 0;

//    //if (txt_GMrecommendedamount.Text != "")
//    //{
//    //    GMrecommendedamount = Convert.ToDecimal(txt_GMrecommendedamount.Text);
//    //}

//    //if (txt_Insertamounttobepaidaspercalculations.Text != "")
//    //{
//    //    totalgridinterestamount = Convert.ToDecimal(txt_Insertamounttobepaidaspercalculations.Text);
//    //}

//    //if (txt_Actualinterestamountpaid.Text != "")
//    //{
//    //    actualinterestamountpaid = Convert.ToDecimal(txt_Actualinterestamountpaid.Text);
//    //}
//    //if (txt_RateofInterest.Text != "")
//    //{
//    //    rateofinterest = Convert.ToDecimal(txt_RateofInterest.Text);
//    //}
//    //if (txt_Eligiblerateofreimbursement.Text != "")
//    //{
//    //    egliblerateofinterest = Convert.ToDecimal(txt_Eligiblerateofreimbursement.Text);
//    //}

//    //if (totalgridinterestamount > 0)
//    //{
//    //    if (totalgridinterestamount > 0)
//    //    {
//    //        if (rateofinterest > 0)
//    //        {
//    //            if (egliblerateofinterest > 0)
//    //            {
//    //                if (totalgridinterestamount < actualinterestamountpaid)
//    //                {
//    //                    interestamountcondisered = totalgridinterestamount;
//    //                }
//    //                else
//    //                {
//    //                    interestamountcondisered = actualinterestamountpaid;
//    //                }
//    //                interestegliblereimbursement = (interestamountcondisered * egliblerateofinterest) / rateofinterest;


//    //            }
//    //            else
//    //            {
//    //                //Please Enter Eglible Rate of interest
//    //            }
//    //        }
//    //        else
//    //        {
//    //            //Please Enter Rate of interest
//    //        }
//    //    }
//    //    else
//    //    {
//    //        //Please enter Actual interest amount paid
//    //    }
//    //}
//    //else
//    //{
//    //    //then error insert amount can't be zero
//    //}

//    //if (interestegliblereimbursement > 0)
//    //{
//    //    if (rbtgrd_isbelated.SelectedValue == "0")
//    //    {
//    //        //More than an Year
//    //        eglibleamountofreimbursementbyeglibletype = 0;
//    //        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);

//    //    }
//    //    else if (rbtgrd_isbelated.SelectedValue == "Y")
//    //    {
//    //        //Regular
//    //        eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement;
//    //        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
//    //    }
//    //    else if (rbtgrd_isbelated.SelectedValue == "N")
//    //    {
//    //        //Belated
//    //        eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement / 2;
//    //        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
//    //    }
//    //    else
//    //    {
//    //        //Please Select Eglible Type
//    //    }
//    //}

//    //if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
//    //{
//    //    finalegibleamountdisscussed = GMrecommendedamount;
//    //}
//    //else
//    //{
//    //    finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
//    //}

//    //txt_Insertreimbursementcalculated.Text = Convert.ToString(Math.Round(interestegliblereimbursement, 2));
//    //txt_Eligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
//}

#endregion

//grd_Addclaimperiod.DataSource = dsmain.Tables[0];
//grd_Addclaimperiod.DataBind();

//if (noofinstallment >= 1)
//{
//    Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
//}
//if (noofinstallment >= 1)
//{
//    if(noofinstallment == 1)
//    {
//        int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
//        decimal daysforcal = dcpdate.Day/ daysinamonthofgrid;
//        Toteglibleperiodinmonths = Toteglibleperiodinmonths + daysforcal;
//    }
//    else
//    {
//        Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
//        totalinterestforallfy = totalinterestforallfy + interestamount;
//    }
//}
//else
//{
//    totalinterestforallfy = totalinterestforallfy + interestamount;
//}

// = Toteglibleperiodinmonths + 1;
//if (grd_Addclaimperiod != null)
//{
//    if (grd_Addclaimperiod.Rows.Count > 0)
//    {
//        interestamountcalacutions();
//    }
//}

#region eglible amount

//protected void txt_eglsacamountinterestreimbursement_TextChanged(object sender, EventArgs e)
//{

//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{
//    //    string errorgmsg1 = ValidateControls_installmentamount();
//    //    if (errorgmsg1.Trim().TrimStart() != "")
//    //    {
//    //        string message = "alert('" + errorgmsg + "')";
//    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //        return;
//    //    }
//    //    else
//    //    {

//    //    }
//    //}
//}

//protected void ddl_ClaimPeriod_SelectedIndexChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    // getthedate_eligibleincentives_datatest();
//    //string claimperiodddlvalue = ddl_ClaimPeriod.SelectedValue;
//    //string[] argclaimperiod = new string[5];
//    //argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
//    //string FYSlnoofIncentiveID = Convert.ToString(argclaimperiod[0]);
//    //string firstsecondhalfyear = Convert.ToString(argclaimperiod[1]);
//    //string yeardata = Convert.ToString(argclaimperiod[2]);
//    //string[] argyearclaimperiod = new string[5];
//    //argyearclaimperiod = yeardata.Split('-');
//    //string Startyear = Convert.ToString(argyearclaimperiod[0]);
//    //string endyear = Convert.ToString(argyearclaimperiod[1]);

//    //GetMonthYearName_DB(Convert.ToInt32(Startyear), Convert.ToInt32(firstsecondhalfyear));

//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//}

//protected void txt_DateofCommencementofactivity_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//}

//protected void ddl_periodofinstallment_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//}

//protected void txt_noofinstallment_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    // getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{
//    //    string errorgmsg1 = ValidateControls_installmentamount();
//    //    if (errorgmsg1.Trim().TrimStart() != "")
//    //    {
//    //        string message = "alert('" + errorgmsg + "')";
//    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //        return;
//    //    }
//    //    else
//    //    {

//    //    }
//    //}
//}

//protected void txt_Installmentamount_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    // getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//}

//protected void ddl_installmentstartmonth_SelectedIndexChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//}

//protected void ddl_installmentstartingyear_SelectedIndexChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//}

//protected void txt_RateofInterest_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //getthedate_eligibleincentives_datatest();
//    //string errorgmsg1 = ValidateControls_rateofinterest();
//    //if (errorgmsg1.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg1 + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{
//    //    string errorgmsg = ValidateControls_eligibleincentives();
//    //    if (errorgmsg.Trim().TrimStart() != "")
//    //    {
//    //        string message = "alert('" + errorgmsg + "')";
//    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //        return;
//    //    }
//    //    else
//    //    {

//    //    }
//    //}
//}

//protected void txt_Eligiblerateofreimbursement_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//    //getthedate_eligibleincentives_datatest();
//}

//protected void txt_Noofinstallmentscompleted_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//    //getthedate_eligibleincentives_datatest();
//}

//protected void txt_PrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//    //string errorgmsg = ValidateControls_eligibleincentives();
//    //if (errorgmsg.Trim().TrimStart() != "")
//    //{
//    //    string message = "alert('" + errorgmsg + "')";
//    //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//    //    return;
//    //}
//    //else
//    //{

//    //}
//    //getthedate_eligibleincentives_datatest();
//}

//protected void txt_installmentstartdate_TextChanged(object sender, EventArgs e)
//{
//    string errorgmsg = getthedate_eligibleincentives();
//    if (errorgmsg.Trim().TrimStart() != "")
//    {
//        string message = "alert('" + errorgmsg + "')";
//        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
//        return;
//    }
//}





#endregion

#region

//public string getthedate_eligibleincentives()
//{
//    int slno = 1;
//    string ErrorMsg = "";

//decimal Totalamount = 0; DateTime dcpdate = DateTime.Now; int periodofinstallment = 0;
//int Totalinstallment = 0; decimal installmentamount = 0; decimal rateofinterest = 0;
//decimal egliblerateofinterest = 0; int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
//int FYSlnoofIncentiveID = 0;
//int firstsecondhalfyearoffirstddlclaim = 0;
//int fyStartyear = 0;
//int fystartmonth = 0;
//int fyendyear = 0;
//int fyendmonth = 0;
//DateTime installmentstartdate = DateTime.Now;
//// ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commencement of activity \\n";
////slno = slno + 1;

//if (txt_eglsacamountinterestreimbursement.Text != "")
//{
//    Totalamount = Convert.ToDecimal(txt_eglsacamountinterestreimbursement.Text);
//}
//if (txt_DateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
//{

//    dcpdate = Convert.ToDateTime(txt_DateofCommencementofactivity.Text);
//}
//if (ddl_periodofinstallment.SelectedIndex > 0)
//{
//    periodofinstallment = Convert.ToInt32(ddl_periodofinstallment.SelectedValue);
//}

//if (txt_noofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
//{
//    Totalinstallment = Convert.ToInt32(txt_noofinstallment.Text);
//}
//if (txt_RateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
//{
//    rateofinterest = Convert.ToDecimal(txt_RateofInterest.Text);
//}
//if (txt_installmentstartdate.Text.TrimStart().TrimEnd().Trim() != "")
//{

//    installmentstartdate = Convert.ToDateTime(txt_installmentstartdate.Text);
//}


//if (ddl_ClaimPeriod.SelectedIndex > 0)
//{
//    string claimperiodddlvalue = ddl_ClaimPeriod.SelectedValue;
//    string[] argclaimperiod = new string[5];
//    argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
//    FYSlnoofIncentiveID = Convert.ToInt32(argclaimperiod[0]);
//    firstsecondhalfyearoffirstddlclaim = Convert.ToInt16(argclaimperiod[1]);
//    string yeardata = Convert.ToString(argclaimperiod[2]);
//    string[] argyearclaimperiod = new string[5];
//    argyearclaimperiod = yeardata.Split('-');
//    fyStartyear = Convert.ToInt32(argyearclaimperiod[0]);
//    fyendyear = Convert.ToInt32(argyearclaimperiod[1]);
//    if (firstsecondhalfyearoffirstddlclaim > 0)
//    {
//        if (firstsecondhalfyearoffirstddlclaim == 1)
//        {
//            fystartmonth = 4;
//            fyendmonth = 9;
//        }
//        if (firstsecondhalfyearoffirstddlclaim == 2)
//        {
//            fystartmonth = 10;
//            fyendmonth = 3;
//        }
//        if (firstsecondhalfyearoffirstddlclaim == 3)
//        {
//            fystartmonth = 4;
//            fyendmonth = 3;
//        }
//    }
//}

//if (rateofinterest > 0)
//{
//    egliblerateofinterest = rateofinterest - 3;
//    if (egliblerateofinterest > 9)
//    {
//        egliblerateofinterest = 9;
//    }
//}

//if (egliblerateofinterest > 0)
//{
//    txt_Eligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
//}
//else
//{
//    ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
//    slno = slno + 1;
//}
//if (Totalinstallment > 0 && Totalamount > 0)
//{
//    installmentamount = Totalamount / Totalinstallment;
//    txt_Installmentamount.Text = Convert.ToString(Math.Round(installmentamount, 2));
//}
//else
//{
//    ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
//    slno = slno + 1;
//}

//decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0;
//if (dcpdate.Date != DateTime.Now.Date)
//{
//    if (installmentstartdate.Date != DateTime.Now.Date)
//    {
//        if (dcpdate.Date < DateTime.Now.Date && installmentstartdate.Date < DateTime.Now.Date)
//        {


//            if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0 &&
//              Totalinstallment > 0 && installmentamount > 0 && rateofinterest > 0 && fyStartyear > 0 && fystartmonth > 0
//                    && fyendyear > 0 && fyendmonth > 0 && installmentstartdate != null)
//            {
//                #region totalcompleted installmets
//                int totalmonthcal = 0;
//                int totaltwoyearscal = 0;
//                int totalmonthbwtwoyears = 0;
//                if (fyStartyear == installmentstartdate.Year)
//                {
//                    totaltwoyearscal = 0;
//                    if (fystartmonth > installmentstartdate.Month)
//                    {
//                        //dcp date start before financial year
//                        totalmonthcal = (fystartmonth - installmentstartdate.Month);
//                    }
//                    else
//                    {
//                        totalmonthcal = 0;
//                    }
//                    totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
//                }
//                else if (installmentstartdate.Year < fyStartyear)
//                {
//                    totaltwoyearscal = ((fyStartyear - installmentstartdate.Year) * 12);
//                    totalmonthcal = (fystartmonth - installmentstartdate.Month);

//                    totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
//                }
//                else if (installmentstartdate.Year > fyStartyear)
//                {
//                    totaltwoyearscal = 0;
//                    totalmonthcal = 0;
//                    totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
//                }

//                int quotientcompleted = 0;
//                if (periodofinstallment == 1)
//                {
//                    //Yearly
//                    quotientcompleted = totalmonthbwtwoyears / 12;
//                }
//                else if (periodofinstallment == 2)
//                {
//                    //halfyear
//                    quotientcompleted = totalmonthbwtwoyears / 6;
//                }
//                else if (periodofinstallment == 3)
//                {
//                    //quaertly
//                    quotientcompleted = totalmonthbwtwoyears / 3;
//                }
//                else if (periodofinstallment == 4)
//                {
//                    //Monthly
//                    quotientcompleted = totalmonthbwtwoyears;
//                }
//                noofinstallmentcompleted = quotientcompleted;
//                #endregion

//                #region principalamountdue amount for this half year
//                int pramounttotalmonthcal = 0;
//                int pramounttotaltwoyearscal = 0;
//                int pramounttotalmonthbwtwoyears = 0;
//                if (fyStartyear == dcpdate.Year)
//                {
//                    if (dcpdate.Month < fystartmonth)
//                    {
//                        //dcp date started before financial year
//                        pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
//                    }
//                    else
//                    {
//                        //dcp date started after financial year/in same month
//                        pramounttotalmonthcal = 0;
//                    }
//                    pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
//                }
//                else
//                {
//                    if (dcpdate.Year < fyStartyear)
//                    {
//                        //dcp date started before finanical year
//                        pramounttotaltwoyearscal = ((fyStartyear - dcpdate.Year) * 12);
//                        pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
//                        pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
//                    }
//                    else
//                    {
//                        if (dcpdate.Year > fyStartyear)
//                        {
//                            ////dcp date started after finanical year
//                            pramounttotaltwoyearscal = 0;
//                            pramounttotalmonthcal = 0;
//                            pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;

//                        }
//                    }

//                }
//                int pramountquotientcompleted = 0;
//                int pramountremaindercompleted = 0;
//                if (periodofinstallment == 1)
//                {
//                    //Yearly
//                    pramountquotientcompleted = totalmonthbwtwoyears / 12;
//                    pramountremaindercompleted = totalmonthbwtwoyears % 12;

//                }
//                else if (periodofinstallment == 2)
//                {
//                    //halfyear
//                    pramountquotientcompleted = totalmonthbwtwoyears / 6;
//                    pramountremaindercompleted = totalmonthbwtwoyears % 6;
//                }
//                else if (periodofinstallment == 3)
//                {
//                    //quaertly
//                    pramountquotientcompleted = totalmonthbwtwoyears / 3;
//                    pramountremaindercompleted = totalmonthbwtwoyears % 3;
//                }
//                else if (periodofinstallment == 4)
//                {
//                    //Monthly
//                    pramountquotientcompleted = totalmonthbwtwoyears;
//                }
//                if (pramountquotientcompleted == 0)
//                {
//                    termprincipaldueamount = Totalamount;
//                }
//                else
//                {
//                    if (pramountremaindercompleted == 0)
//                    {
//                        termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
//                    }
//                    else
//                    {
//                        termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
//                    }
//                }
//                #endregion
//                #region grid finanical years

//                if (noofinstallmentcompleted <= Totalinstallment)
//                {
//                    int TotalInstallmentCompleted = 0;

//                    if (termprincipaldueamount > 0)
//                    {
//                        DataSet oDataSet = obj_pallavaddi.DB_getFYClaimperiod(Convert.ToString(Session["incentiveid"]));
//                        if (oDataSet != null && oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
//                        {
//                            DataTable dt_grid = new DataTable();
//                            dt_grid.Columns.Add("IncentiveFYClaimID", typeof(string));
//                            dt_grid.Columns.Add("FirstsecondhalfyearID", typeof(string));
//                            dt_grid.Columns.Add("FinancialYearID", typeof(string));
//                            dt_grid.Columns.Add("FinancialYearName", typeof(string));
//                            dt_grid.Columns.Add("RateofInterest", typeof(string));
//                            dt_grid.Columns.Add("forPresenthalfyeardueamount", typeof(string));
//                            dt_grid.Columns.Add("TotalInstallmentCompleted", typeof(string));
//                            dt_grid.Columns.Add("InstallmentAmount", typeof(string));

//                            dt_grid.Columns.Add("MonthYear", typeof(string));
//                            dt_grid.Columns.Add("MonthName_Year", typeof(string));
//                            dt_grid.Columns.Add("Principalamountdue", typeof(decimal));
//                            dt_grid.Columns.Add("noofinstallment", typeof(int));
//                            dt_grid.Columns.Add("InterestAmount", typeof(decimal));



//                            for (int i = 0; i < oDataSet.Tables[0].Rows.Count; i++)
//                            {
//                                int installmentstartmonthyear = 0;
//                                decimal forPresenthalfyeardueamount = 0;

//                                String eachclaimperiodID = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearID"]);
//                                String eachclaimperiodName = Convert.ToString(oDataSet.Tables[0].Rows[i]["FinancialYearName"]);
//                                string[] argeachclaimperiod = new string[5];
//                                argeachclaimperiod = eachclaimperiodID.Split('/'); //32012/1/2016-2017
//                                string IncentiveFYClaimID = Convert.ToString(argeachclaimperiod[0]);
//                                int firstsecondhalfyearclaimtype = Convert.ToInt16(argeachclaimperiod[1]);
//                                string yeardataeachclaim = Convert.ToString(argeachclaimperiod[2]);
//                                string[] argeachyearclaimperiod = new string[5];
//                                argeachyearclaimperiod = yeardataeachclaim.Split('-');
//                                int fyeachStartyear = Convert.ToInt32(argeachyearclaimperiod[0]);
//                                int fyeachendyear = Convert.ToInt32(argeachyearclaimperiod[1]);
//                                if (i == 0)
//                                {
//                                    TotalInstallmentCompleted = noofinstallmentcompleted;
//                                }

//                                int totalmonthforhalfyear = 6;
//                                int monthofstart = 4;//April      
//                                installmentstartmonthyear = 4;
//                                if (firstsecondhalfyearclaimtype == 3)
//                                {
//                                    totalmonthforhalfyear = 12;
//                                }
//                                if (firstsecondhalfyearclaimtype == 2)
//                                {
//                                    monthofstart = 10;//OCT
//                                    if (TotalInstallmentCompleted > 0)
//                                    {
//                                        installmentstartmonthyear = 10;
//                                    }
//                                }
//                                DateTime dateofmonthstart = new DateTime(Convert.ToInt32(fyeachStartyear), monthofstart, 01);
//                                var dat = dateofmonthstart.AddMonths(1).AddDays(-1);

//                                for (int k = 0; k < totalmonthforhalfyear; k++)
//                                {
//                                    DataRow drs = dt_grid.NewRow();
//                                    dat.AddMonths(k).ToString("d");
//                                    string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
//                                    string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
//                                    //string MonthYear = 0+k + "/" + d1.Year;
//                                    //string MonthName = 0 + k + "-" + d1.Year;
//                                    int gridmonth = dat.AddMonths(k).Month;
//                                    int gridyear = dat.AddMonths(k).Year;

//                                    decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
//                                    if (gridyear >= installmentstartdate.Year)
//                                    {
//                                        int gridtotaltwoyearscal = 0;
//                                        int gridtotalmonthcal = 0;
//                                        int gridtotalmonthbwyears = 0;
//                                        // int gridtotalmonthbwyears = ((gridyear - installmentstartdate.Year) * 12) + (gridmonth - installmentstartdate.Month);
//                                        if (gridyear == installmentstartdate.Year)
//                                        {
//                                            gridtotaltwoyearscal = 0;
//                                            if (gridmonth > installmentstartdate.Month)
//                                            {
//                                                //installmentstartdate start before financial year
//                                                gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
//                                            }
//                                            else
//                                            {
//                                                gridtotalmonthcal = 0;
//                                                //installmentstartdate didn't start for that finanical year
//                                                //gridtotalmonthcal = 0;
//                                            }
//                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
//                                        }
//                                        else if (installmentstartdate.Year < gridyear)
//                                        {
//                                            gridtotaltwoyearscal = ((gridyear - installmentstartdate.Year) * 12);
//                                            gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
//                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
//                                        }
//                                        else if (installmentstartdate.Year > gridyear)
//                                        {
//                                            //in that year installmentstartdate didn't started
//                                            gridtotaltwoyearscal = 0;
//                                            gridtotalmonthcal = 0;
//                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
//                                        }


//                                        //int gridtotalmonthbwyears = ((gridyear - dcpdate.Year) * 12) + (gridmonth - dcpdate.Month);
//                                        int gridquotientCompleted = 0;
//                                        int gridremainder = 0;
//                                        if (Convert.ToInt16(periodofinstallment) == 1)
//                                        {
//                                            //Yearly
//                                            gridquotientCompleted = gridtotalmonthbwyears / 12;
//                                            gridremainder = gridtotalmonthbwyears % 12;
//                                            if (gridquotientCompleted + 1 <= Totalinstallment)
//                                            {
//                                                if (gridquotientCompleted <= 0)
//                                                {
//                                                    if (gridremainder <= 0)
//                                                    {
//                                                        if (gridyear == installmentstartdate.Year)
//                                                        {
//                                                            if (gridmonth == installmentstartdate.Month)
//                                                            {
//                                                                noofinstallment = gridquotientCompleted + 1;
//                                                                Principalamountdue = Totalamount;
//                                                            }
//                                                            else
//                                                            {
//                                                                noofinstallment = gridquotientCompleted;
//                                                                Principalamountdue = 0;
//                                                            }
//                                                        }
//                                                        else
//                                                        {
//                                                            noofinstallment = gridquotientCompleted;
//                                                            Principalamountdue = 0;
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        noofinstallment = gridquotientCompleted + 1;
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    noofinstallment = gridquotientCompleted + 1;
//                                                    if (gridremainder == 0)
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                    }
//                                                    else
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                if (k == 0)
//                                                {
//                                                    forPresenthalfyeardueamount = Principalamountdue;
//                                                    if (noofinstallment - 1 <= 0)
//                                                    {
//                                                        TotalInstallmentCompleted = 0;
//                                                    }
//                                                    else
//                                                    {
//                                                        TotalInstallmentCompleted = noofinstallment - 1;
//                                                    }
//                                                }
//                                            }
//                                        }
//                                        else if (Convert.ToInt16(periodofinstallment) == 2)
//                                        {
//                                            //Half yearly
//                                            gridquotientCompleted = gridtotalmonthbwyears / 6;
//                                            gridremainder = gridtotalmonthbwyears % 6;

//                                            if (gridquotientCompleted + 1 <= Totalinstallment)
//                                            {
//                                                if (gridquotientCompleted <= 0)
//                                                {
//                                                    if (gridremainder <= 0)
//                                                    {
//                                                        if (gridyear == installmentstartdate.Year)
//                                                        {
//                                                            if (gridmonth == installmentstartdate.Month)
//                                                            {
//                                                                noofinstallment = gridquotientCompleted + 1;
//                                                                Principalamountdue = Totalamount;
//                                                            }
//                                                            else
//                                                            {
//                                                                noofinstallment = gridquotientCompleted;
//                                                                Principalamountdue = 0;
//                                                            }
//                                                        }
//                                                        else
//                                                        {
//                                                            noofinstallment = gridquotientCompleted;
//                                                            Principalamountdue = 0;
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        noofinstallment = gridquotientCompleted + 1;
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    noofinstallment = gridquotientCompleted + 1;
//                                                    if (gridremainder == 0)
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                    }
//                                                    else
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                if (k == 0)
//                                                {
//                                                    forPresenthalfyeardueamount = Principalamountdue;
//                                                    if (noofinstallment - 1 <= 0)
//                                                    {
//                                                        TotalInstallmentCompleted = 0;
//                                                    }
//                                                    else
//                                                    {
//                                                        TotalInstallmentCompleted = noofinstallment - 1;
//                                                    }
//                                                }
//                                            }
//                                        }
//                                        else if (Convert.ToInt16(periodofinstallment) == 3)
//                                        {
//                                            // Quarelty
//                                            gridquotientCompleted = gridtotalmonthbwyears / 3;
//                                            gridremainder = gridtotalmonthbwyears % 3;
//                                            if (gridquotientCompleted + 1 <= Totalinstallment)
//                                            {
//                                                if (gridquotientCompleted <= 0)
//                                                {
//                                                    if (gridremainder <= 0)
//                                                    {
//                                                        if (gridyear == installmentstartdate.Year)
//                                                        {
//                                                            if (gridmonth == installmentstartdate.Month)
//                                                            {
//                                                                noofinstallment = gridquotientCompleted + 1;
//                                                                Principalamountdue = Totalamount;
//                                                            }
//                                                            else
//                                                            {
//                                                                noofinstallment = gridquotientCompleted;
//                                                                Principalamountdue = 0;
//                                                            }
//                                                        }
//                                                        else
//                                                        {
//                                                            noofinstallment = gridquotientCompleted;
//                                                            Principalamountdue = 0;
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        noofinstallment = gridquotientCompleted + 1;
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    noofinstallment = gridquotientCompleted + 1;
//                                                    if (gridremainder == 0)
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                    }
//                                                    else
//                                                    {
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
//                                                    }
//                                                }
//                                                if (k == 0)
//                                                {
//                                                    forPresenthalfyeardueamount = Principalamountdue;
//                                                    if (noofinstallment - 1 <= 0)
//                                                    {
//                                                        TotalInstallmentCompleted = 0;
//                                                    }
//                                                    else
//                                                    {
//                                                        TotalInstallmentCompleted = noofinstallment - 1;
//                                                    }


//                                                }

//                                            }
//                                        }
//                                        else if (Convert.ToInt16(periodofinstallment) == 4)
//                                        {
//                                            //Monthly
//                                            if (gridquotientCompleted + 1 <= Totalinstallment)
//                                            {
//                                                if (gridyear == installmentstartdate.Year)
//                                                {
//                                                    if (gridtotalmonthbwyears == 0)
//                                                    {
//                                                        if (gridmonth == installmentstartdate.Month)
//                                                        {
//                                                            gridquotientCompleted = gridtotalmonthbwyears + 1;
//                                                            noofinstallment = (gridquotientCompleted);
//                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                        }
//                                                        else
//                                                        {
//                                                            gridquotientCompleted = 0;
//                                                            noofinstallment = (gridquotientCompleted);
//                                                            Principalamountdue = 0;
//                                                        }

//                                                    }
//                                                    else
//                                                    {
//                                                        gridquotientCompleted = gridtotalmonthbwyears + 1;
//                                                        noofinstallment = (gridquotientCompleted);
//                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    gridquotientCompleted = gridtotalmonthbwyears + 1;
//                                                    noofinstallment = (gridquotientCompleted);
//                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
//                                                }
//                                                if (k == 0)
//                                                {
//                                                    forPresenthalfyeardueamount = Principalamountdue;

//                                                    if (noofinstallment - 1 <= 0)
//                                                    {
//                                                        TotalInstallmentCompleted = 0;
//                                                    }
//                                                    else
//                                                    {
//                                                        TotalInstallmentCompleted = noofinstallment - 1;
//                                                    }
//                                                }
//                                            }
//                                        }




//                                        #region interest amount
//                                        //Finincal year started,installment date started, check with dcp date
//                                        if (gridyear == installmentstartdate.Year)
//                                        {
//                                            if (gridyear >= dcpdate.Year)
//                                            {
//                                                //finanical year started after dcp date
//                                                if (gridyear == dcpdate.Year)
//                                                {
//                                                    if (dcpdate.Month < gridmonth)
//                                                    {
//                                                        //dcp date started before financial year
//                                                        if (gridmonth == dcpdate.Month)
//                                                        {
//                                                            int daysinamonth = DateTime.DaysInMonth(gridyear, gridmonth);
//                                                            int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//                                                            interestamount = (pramountpaidfordays * rateofinterest) / 1200;
//                                                        }
//                                                        else
//                                                        {
//                                                            //interestamount = (Totalamount * rateofinterest) / 1200; COMMNETED ON 19/01/2022
//                                                            interestamount = (Principalamountdue * rateofinterest) / 1200;
//                                                        }
//                                                    }
//                                                    else
//                                                    {
//                                                        interestamount = 0;
//                                                    }
//                                                }
//                                                else
//                                                {
//                                                    //finanical year started  is greater than dcp date
//                                                    if (Principalamountdue <= 0 && noofinstallment <= 0)
//                                                    {
//                                                        interestamount = (Totalamount * rateofinterest) / 1200;
//                                                    }
//                                                    else
//                                                    {
//                                                        interestamount = (Principalamountdue * rateofinterest) / 1200;
//                                                    }


//                                                }
//                                            }
//                                            else
//                                            {
//                                                //interest amount  is zero as dcp date didn't started
//                                                interestamount = 0;
//                                            }
//                                        }
//                                        else
//                                        {

//                                            //installment started before the finincal year
//                                            interestamount = (Principalamountdue * rateofinterest) / 1200;
//                                        }


//                                        #endregion



//                                        //   interestamount = (Principalamountdue * rateofinterest) / 1200;

//                                    }
//                                    else
//                                    {
//                                        //Finincal year started,installment date not started check with dcp date
//                                        if (gridyear >= dcpdate.Year)
//                                        {
//                                            //finanical year started after dcp date
//                                            if (gridyear == dcpdate.Year)
//                                            {
//                                                if (dcpdate.Month <= gridmonth)
//                                                {
//                                                    //dcp date started before financial year
//                                                    if (dcpdate.Month == gridmonth)
//                                                    {
//                                                        int daysinamonthdcp = DateTime.DaysInMonth(gridyear, gridmonth);
//                                                        int daystopaiddcp = (daysinamonthdcp - dcpdate.Day) + 1;
//                                                        decimal pramountpaidfordays = (Totalamount / daysinamonthdcp) * daystopaiddcp;
//                                                        interestamount = (pramountpaidfordays * rateofinterest) / 1200;
//                                                    }
//                                                    else
//                                                    {
//                                                        interestamount = (Totalamount * rateofinterest) / 1200;
//                                                    }
//                                                }
//                                            }
//                                            else
//                                            {
//                                                //finanical year started  is greater than dcp date
//                                                interestamount = (Totalamount * rateofinterest) / 1200;
//                                            }
//                                        }
//                                    }


//                                    if (interestamount > 0)
//                                    {
//                                        if (gridyear == dcpdate.Year && gridmonth == dcpdate.Month)
//                                        {
//                                            int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
//                                            double daysforcal = 1 - (Convert.ToDouble(dcpdate.Day) / Convert.ToDouble(daysinamonthofgrid));
//                                            Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
//                                        }
//                                        else
//                                        {
//                                            DateTime startDateofeachmonthgrd = new DateTime(gridyear, gridmonth, 1);
//                                            if (dcpdate.Date < startDateofeachmonthgrd.Date)
//                                            {
//                                                Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
//                                            }
//                                            else
//                                            {

//                                            }

//                                            //if (noofinstallment >= 1)
//                                            //{
//                                            //    Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
//                                            //}
//                                        }
//                                    }

//                                    totalinterestforallfy = totalinterestforallfy + interestamount;



//                                    //if (noofinstallment >= 1)
//                                    //{
//                                    //    if(noofinstallment == 1)
//                                    //    {
//                                    //        int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
//                                    //        decimal daysforcal = dcpdate.Day/ daysinamonthofgrid;
//                                    //        Toteglibleperiodinmonths = Toteglibleperiodinmonths + daysforcal;
//                                    //    }
//                                    //    else
//                                    //    {
//                                    //        Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
//                                    //        totalinterestforallfy = totalinterestforallfy + interestamount;
//                                    //    }
//                                    //}
//                                    //else
//                                    //{
//                                    //    totalinterestforallfy = totalinterestforallfy + interestamount;
//                                    //}


//                                    drs["MonthYear"] = MonthYear;
//                                    drs["MonthName_Year"] = MonthName;
//                                    drs["Principalamountdue"] = Convert.ToString(Math.Round(Principalamountdue, 2));
//                                    drs["noofinstallment"] = noofinstallment;
//                                    drs["InterestAmount"] = Convert.ToString(Math.Round(interestamount, 2));
//                                    drs["IncentiveFYClaimID"] = IncentiveFYClaimID;
//                                    drs["FirstsecondhalfyearID"] = firstsecondhalfyearclaimtype;
//                                    drs["FinancialYearID"] = eachclaimperiodID;//yeardataeachclaim;
//                                    drs["FinancialYearName"] = eachclaimperiodName;
//                                    drs["RateofInterest"] = rateofinterest;
//                                    drs["InstallmentAmount"] = Convert.ToString(Math.Round(installmentamount, 2));
//                                    drs["forPresenthalfyeardueamount"] = Convert.ToString(Math.Round(forPresenthalfyeardueamount, 2));
//                                    drs["TotalInstallmentCompleted"] = TotalInstallmentCompleted;
//                                    dt_grid.Rows.Add(drs);
//                                }
//                            }

//                            DataSet dsmain = new DataSet();
//                            dsmain.Tables.Add(dt_grid);
//                            grd_Addclaimperiod.DataSource = dsmain.Tables[0];
//                            grd_Addclaimperiod.DataBind();


//                        }
//                    }
//                    else
//                    {
//                        ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero \\n";
//                        slno = slno + 1;
//                    }
//                }
//                else
//                {
//                    ErrorMsg = ErrorMsg + slno + ". Please Enter completed total installment should be less than total installment   \\n";
//                    slno = slno + 1;
//                }

//                #endregion

//            }
//        }
//        else
//        {
//            ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start date Should be less than current date \\n";
//            slno = slno + 1;
//        }
//    }
//}

//// = Toteglibleperiodinmonths + 1;
//txt_Eligibleperiodinmonths.Text = Convert.ToString(Math.Round(Toteglibleperiodinmonths, 2));
//txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));


//txt_Noofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
//txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(Math.Round(termprincipaldueamount, 2));

//if (grd_Addclaimperiod != null)
//{
//    if (grd_Addclaimperiod.Rows.Count > 0)
//    {
//        interestamountcalacutions();
//    }
//}


//    return ErrorMsg;
//}
//if (gridyear >= dcpdate.Year)
//{
//    //finanical year started after dcp date
//    if (gridyear == dcpdate.Year)
//    {
//        if (dcpdate.Month <= gridmonth)
//        {
//            //dcp date started before financial year
//            if (dcpdate.Month == gridmonth)
//            {
//                int daysinamonthdcp = DateTime.DaysInMonth(gridyear, gridmonth);
//                int daystopaiddcp = (daysinamonthdcp - dcpdate.Day) + 1;
//                decimal pramountpaidfordays = (Totalamount / daysinamonthdcp) * daystopaiddcp;
//                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//            }
//            else
//            {
//                interestamount = (Totalamount * rateofinterestofdt) / 1200;
//            }
//        }
//    }
//    else
//    {
//        //finanical year started  is greater than dcp date
//        interestamount = (Totalamount * rateofinterestofdt) / 1200;
//    }
//}
#endregion


#region interest amount
//Finincal year started,installment date started, check with dcp date
//if (gridyear == installmentstartdate.Year)
//{
//    if (gridyear >= dcpdate.Year)
//    {
//        //finanical year started after dcp date
//        if (gridyear == dcpdate.Year)
//        {
//            if (dcpdate.Month < gridmonth)
//            {
//                //dcp date started before financial year
//                if (gridmonth == dcpdate.Month)
//                {
//                    int daysinamonth = DateTime.DaysInMonth(gridyear, gridmonth);
//                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
//                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
//                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
//                }
//                else
//                {
//                    //interestamount = (Totalamount * rateofinterestofdt) / 1200; COMMNETED ON 19/01/2022
//                    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
//                }
//            }
//            else
//            {
//                interestamount = 0;
//            }
//        }
//        else
//        {
//            //finanical year started  is greater than dcp date
//            if (Principalamountdue <= 0 && noofinstallment <= 0)
//            {
//                interestamount = (Totalamount * rateofinterestofdt) / 1200;
//            }
//            else
//            {
//                interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
//            }


//        }
//    }
//    else
//    {
//        //interest amount  is zero as dcp date didn't started
//        interestamount = 0;
//    }
//}
//else
//{

//    //installment started before the finincal year
//    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
//}


#endregion

#region



//bool checkfrmdcpdates = false;//if more than 5 years true
//double Noofdaysbw5yrsmonthsame = 0;
//if (dat.AddMonths(k).Date > dcpdate.Date)
//{
//    //installment started before the finincal year
//    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;

//    checkfrmdcpdates = false;//installmentdate greater than Dcp date,here between them is zero
//}
//else
//{
//    //checkfrmdcpdates = false;
//    if (dat.AddMonths(k).Date < dcpdate.Date)
//    {
//        if (fiveyearsdate.Date > dat.AddMonths(k).Date)
//        {
//            checkfrmdcpdates = false;
//        }
//        else
//        {
//            if (fiveyearsdate.Year == dat.AddMonths(k).Year)
//            {
//                if (fiveyearsdate.Month == dat.AddMonths(k).Month)
//                {
//                    checkfrmdcpdates = true;
//                    Noofdaysbw5yrsmonthsame = (dat.AddMonths(k).Date - fiveyearsdate.Date).TotalDays;
//                }
//                else
//                {
//                    checkfrmdcpdates = true;
//                }
//            }
//            else
//            {
//                checkfrmdcpdates = true;
//            }
//        }
//    }
//    else
//    {
//        //installment started before the finincal year
//        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
//    }



//}
#endregion