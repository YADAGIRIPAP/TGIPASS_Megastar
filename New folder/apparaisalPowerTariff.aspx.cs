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


public partial class UI_TSIPASS_apparaisalPowerTariff : System.Web.UI.Page
{

    static DataTable dtMyTableCertificate;
    static DataTable dtMyTable1;
    static DataTable dtMyTable;
    DataTable myDtNewRecdr = new DataTable();
    string casteGenderGmUpdate = "";
    public string incentiveid;
    public string mstincentiveid;
    IncentiveVosAppraisal oIncentiveVosA = new IncentiveVosAppraisal();
    DB.DB con = new DB.DB();
    List<officerRemarks> lstremarksad = new List<officerRemarks>();
    List<officerRemarks> lstremarks = new List<officerRemarks>();
    List<officerRemarks> lstremarksamount = new List<officerRemarks>();
    List<officerForwarded> lstincentives = new List<officerForwarded>();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect("~/IpassLogin.aspx");
        }
        if (!IsPostBack)
        {
            

            string incentiveid = Request.QueryString["incentiveid"].ToString();
            string MstIncentiveId = Request.QueryString["MstIncentiveId"].ToString();
            claimsgrd();
            tr1.Visible = false;
            USP_GETDETAILSFORSECTION(incentiveid, MstIncentiveId);
            txtINCNoEntry.Text = incentiveid;

            btnINCSearch_Click(sender, e);
            getCasteDetails();

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
    protected void txt_grdyear_TextChanged(object sender, EventArgs e)

    {
        TextBox txt_grdyear = (TextBox)grd_calimsdetails.FindControl("txt_grdyear");
        for (int i = 0; i < grd_calimsdetails.Rows.Count; i++)
        {
            TextBox txt_grdmonthyear1 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear1");
            txt_grdmonthyear1.Text = txt_grdyear.Text;

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
    protected void rdeligibility_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    public void USP_GETDETAILSFORSECTION(string IncentiveId, string MasterIncentiveId)
    {
        //string IncentiveId = txtINCNoEntry.Text.ToString();

        //string MasterIncentiveId = "3";
        SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        osqlConnection.Open();
        SqlDataAdapter da;
        da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_appeal_PowerTariff", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        ds = new DataSet();
        da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
        da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
        da.Fill(ds);

        getLOAData(IncentiveId);

        if (ds.Tables[0].Rows.Count > 0)
        {

            Session["socialStatus"] = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
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


            lblApplicationno.Text = ds.Tables[0].Rows[0]["incApplnNo"].ToString();
            txtunitnames.Text = ds.Tables[0].Rows[0]["NameOfIndustrial"].ToString();

            txtLocofUnit.Text = ds.Tables[0].Rows[0]["LocationOfIndustrial"].ToString();
            ddlOrddlorgtypes.SelectedItem.Text = ds.Tables[0].Rows[0]["ConstitutionOfIndustrial"].ToString();
            ddlUdyogAadharType.SelectedIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["SSIApprovalofIEM"].ToString());
            txtPersonIndustry.Text = ds.Tables[0].Rows[0]["lblAcknoledgementLIORIL"].ToString();
            lblAllwomen.Value = ds.Tables[0].Rows[0]["allwomen"].ToString();

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
                txtDCP_unit.Text =
                Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
            else
                txtDCP_unit.Text = "";

            if (ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"].ToString() != "")
            {
                txtrc_dic.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimAppln_Date_DIC"]).ToString("dd/MM/yyyy");  //same date as application filed date..
                for (int intCnt = 0; intCnt < grd_calimsdetails.Rows.Count; intCnt++)
                {
                    if (grd_calimsdetails.Rows[intCnt].RowType == DataControlRowType.DataRow)
                    {
                        TextBox txt_grddateoffillingindic = (TextBox)grd_calimsdetails.Rows[0].FindControl("txt_grddateoffillingindic");
                        txt_grddateoffillingindic.Text = txtrc_dic.Text;



                    }
                }
                //TextBox txt_grdmonthyear1 = grd_calimsdetails.Rows[0].FindControl("txt_grdmonthyear1") as TextBox;


            }

            else
                txtrc_dic.Text = "";
            lblSchemeName.Text = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
            if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                    lblSchemeName.Text = "T-PRIDE(PHC)";  //ADDED..

                else if (ds.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                {
                    lblSchemeName.Text = "TIDEA, 2014";

                    if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                    {


                        lblSchemeName.Text = "T-PRIDE";
                        //lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                    }
                    else if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                    {


                        lblSchemeName.Text = "T-PRIDE";
                    }
                    else if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {


                        lblSchemeName.Text = "T-IDEA";
                    }

                }
                else if (ds.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP 2005-10")
                {
                    lblSchemeName.Text = "IIPP Scheme 2005 - 2010";
                }
                else if (ds.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP 2010-15")
                {
                    lblSchemeName.Text = "IIPP Scheme 2010 - 2015";   // IIPP 2010-15
                }


            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "New")
            {
                Session["IdsustryStatus"] = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                trnoofoclaims.Visible = false;
                trschemename.Visible = false;
                totalunitstr.Visible = false;
                trfinancialyear.Visible = false;
                Tr2.Visible = false;
                tbl_monthyeardataExpansion.Visible = false;
                tblNewUnit.Visible = true;
         
                if (lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
                {
                    if (Session["socialStatus"].ToString() == "General")
                    {
                        TextBox21.Text = "0.75";
                        TextBox22.Text = "0.75";
                        TextBox26.Text = "0.75";
                        TextBox27.Text = "0.75";
                        TextBox95.Text = "0.75";
                        TextBox96.Text = "0.75";

                        if(TextBox23.Text!="" && TextBox21.Text!="")
                        {
                            TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();

                        }
                        if (TextBox50.Text != "" && TextBox22.Text != "")
                        {
                            TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }
                        if (TextBox63.Text != "" && TextBox26.Text != "")
                        {
                            TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }
                        if (TextBox71.Text != "" && TextBox27.Text != "")
                        {
                            TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }
                        if (TextBox79.Text != "" && TextBox95.Text != "")
                        {
                            TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }
                        if (TextBox87.Text != "" && TextBox95.Text != "")
                        {
                            TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                        //TextBox21.Enabled = false;
                        //TextBox22.Enabled = false;
                        //TextBox26.Enabled = false;
                        //TextBox27.Enabled = false;
                        //TextBox95.Enabled = false;
                        //TextBox96.Enabled = false;
                        //TextBox92.Enabled = false;
                        //TextBox107.Enabled = false;
                        //TextBox114.Enabled = false;
                        //TextBox121.Enabled = false;
                        //TextBox128.Enabled = false;
                        //TextBox135.Enabled = false;


                    }
                    else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                    {
                 


                        TextBox21.Text = "1";
                        TextBox22.Text = "1";
                        TextBox26.Text = "1";
                        TextBox27.Text = "1";
                        TextBox95.Text = "1";
                        TextBox96.Text = "1";

                        if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                        {
                            TextBox92.Text = "1";
                            TextBox107.Text = "1";
                            TextBox114.Text = "1";
                            TextBox121.Text = "1";
                            TextBox128.Text = "1";
                            TextBox135.Text = "1";
                        }



                        //TextBox21.Enabled = false;
                        //TextBox22.Enabled = false;
                        //TextBox26.Enabled = false;
                        //TextBox27.Enabled = false;
                        //TextBox95.Enabled = false;
                        //TextBox96.Enabled = false;
                        //TextBox92.Enabled = false;
                        //TextBox107.Enabled = false;
                        //TextBox114.Enabled = false;
                        //TextBox121.Enabled = false;
                        //TextBox128.Enabled = false;
                        //TextBox135.Enabled = false;


                    }


                }

                else if (lblSchemeName.Text == "IIPP Scheme 2010 - 2015")
                {
                    if (Session["socialStatus"].ToString() == "General")
                    {
                   

                        TextBox21.Text = "0.75";
                        TextBox22.Text = "0.75";
                        TextBox26.Text = "0.75";
                        TextBox27.Text = "0.75";
                        TextBox95.Text = "0.75";
                        TextBox96.Text = "0.75";

                        if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                        {
                            TextBox92.Text = "0.75";
                            TextBox107.Text = "0.75";
                            TextBox114.Text = "0.75";
                            TextBox121.Text = "0.75";
                            TextBox128.Text = "0.75";
                            TextBox135.Text = "0.75";
                        }

                        //TextBox21.Enabled = false;
                        //TextBox22.Enabled = false;
                        //TextBox26.Enabled = false;
                        //TextBox27.Enabled = false;
                        //TextBox95.Enabled = false;
                        //TextBox96.Enabled = false;

                        //TextBox92.Enabled = false;
                        //TextBox107.Enabled = false;
                        //TextBox114.Enabled = false;
                        //TextBox121.Enabled = false;
                        //TextBox128.Enabled = false;
                        //TextBox135.Enabled = false;

                    }
                    else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                    {
              


                        TextBox21.Text = "1";
                        TextBox22.Text = "1";
                        TextBox26.Text = "1";
                        TextBox27.Text = "1";
                        TextBox95.Text = "1";
                        TextBox96.Text = "1";
                        if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                        {
                            TextBox92.Text = "1";
                            TextBox107.Text = "1";
                            TextBox114.Text = "1";
                            TextBox121.Text = "1";
                            TextBox128.Text = "1";
                            TextBox135.Text = "1";
                        }


                        //TextBox21.Enabled = false;
                        //TextBox22.Enabled = false;
                        //TextBox26.Enabled = false;
                        //TextBox27.Enabled = false;
                        //TextBox95.Enabled = false;
                        //TextBox96.Enabled = false;

                            //TextBox92.Enabled = false;
                            //TextBox107.Enabled = false;
                            //TextBox114.Enabled = false;
                            //TextBox121.Enabled = false;
                            //TextBox128.Enabled = false;
                            //TextBox135.Enabled = false;
                    }

                }
                else if (lblSchemeName.Text == "T-IDEA")
                {
 

                    TextBox21.Text = "1";
                    TextBox22.Text = "1";
                    TextBox26.Text = "1";
                    TextBox27.Text = "1";
                    TextBox95.Text = "1";
                    TextBox96.Text = "1";

                    if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1";
                        TextBox107.Text = "1";
                        TextBox114.Text = "1";
                        TextBox121.Text = "1";
                        TextBox128.Text = "1";
                        TextBox135.Text = "1";
                    }

                    //TextBox21.Enabled = false;
                    //TextBox22.Enabled = false;
                    //TextBox26.Enabled = false;
                    //TextBox27.Enabled = false;
                    //TextBox95.Enabled = false;
                    //TextBox96.Enabled = false;

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;

                }
                else if (lblSchemeName.Text == "T-PRIDE")
                {
 

                    TextBox21.Text = "1.5";
                    TextBox22.Text = "1.5";
                    TextBox26.Text = "1.5";
                    TextBox27.Text = "1.5";
                    TextBox95.Text = "1.5";
                    TextBox96.Text = "1.5";


                    //TextBox21.Enabled = false;
                    //TextBox22.Enabled = false;
                    //TextBox26.Enabled = false;
                    //TextBox27.Enabled = false;
                    //TextBox95.Enabled = false;
                    //TextBox96.Enabled = false;
                    if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1.5";
                        TextBox107.Text = "1.5";
                        TextBox114.Text = "1.5";
                        TextBox121.Text = "1.5";
                        TextBox128.Text = "1.5";
                        TextBox135.Text = "1.5";
                    }

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;

                }
                else if (lblSchemeName.Text == "T-PRIDE(PHC)" && lblSchemeName.Text != "IIPP Scheme 2010 - 2015" && lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
                {
 

                    TextBox21.Text = "1.5";
                    TextBox22.Text = "1.5";
                    TextBox26.Text = "1.5";
                    TextBox27.Text = "1.5";
                    TextBox95.Text = "1.5";
                    TextBox96.Text = "1.5";


                    //TextBox21.Enabled = false;
                    //TextBox22.Enabled = false;
                    //TextBox26.Enabled = false;
                    //TextBox27.Enabled = false;
                    //TextBox95.Enabled = false;
                    //TextBox96.Enabled = false;

                    if (rdbFinYearBothList.SelectedIndex == 0 && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1.5";
                        TextBox107.Text = "1.5";
                        TextBox114.Text = "1.5";
                        TextBox121.Text = "1.5";
                        TextBox128.Text = "1.5";
                        TextBox135.Text = "1.5";
                    }

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;


                }


                txt_grdmonthyear1New.Text = ds.Tables[2].Rows[0]["monthNames"].ToString();
                txt_grdmonthyear1NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                //TextBox txt_grdmonthyear2 = grd_calimsdetails.Rows[1].FindControl("txt_grdmonthyear2") as TextBox;
                txt_grdmonthyear2New.Text = ds.Tables[2].Rows[1]["monthNames"].ToString();
                txt_grdmonthyear2NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
             
                  
                //TextBox txt_grdmonthyear3 = grd_calimsdetails.Rows[2].FindControl("txt_grdmonthyear3") as TextBox;
                txt_grdmonthyear3New.Text = ds.Tables[2].Rows[2]["monthNames"].ToString();
                txt_grdmonthyear3NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                //TextBox txt_grdmonthyear4 = grd_calimsdetails.Rows[3].FindControl("txt_grdmonthyear4") as TextBox;
                txt_grdmonthyear4New.Text = ds.Tables[2].Rows[3]["monthNames"].ToString();
                txt_grdmonthyear4NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                //TextBox txt_grdmonthyear5 = grd_calimsdetails.Rows[4].FindControl("txt_grdmonthyear5") as TextBox;
                txt_grdmonthyear5New.Text = ds.Tables[2].Rows[4]["monthNames"].ToString();
                txt_grdmonthyear5NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                //TextBox txt_grdmonthyear6 = grd_calimsdetails.Rows[5].FindControl("txt_grdmonthyear6") as TextBox;
                txt_grdmonthyear6New.Text = ds.Tables[2].Rows[5]["monthNames"].ToString();
                txt_grdmonthyear6NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
            }
            else if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Expansion")
            {

                ddlFinancialYear.DataSource = ds.Tables[4];
                ddlFinancialYear.DataTextField = "FinancialYear";
                ddlFinancialYear.DataValueField = "SlNo";
                ddlFinancialYear.DataBind();


                ddlFinancialYear1.DataSource = ds.Tables[4];
                ddlFinancialYear1.DataTextField = "FinancialYear";
                ddlFinancialYear1.DataValueField = "SlNo";
                ddlFinancialYear1.DataBind();


                ddlFinancialYear2.DataSource = ds.Tables[4];
                ddlFinancialYear2.DataTextField = "FinancialYear";
                ddlFinancialYear2.DataValueField = "SlNo";
                ddlFinancialYear2.DataBind();


                Session["IdsustryStatus"] = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                tbl_monthyeardataExpansion.Visible = true;
                tblNewUnit.Visible = false;

                txt_grdmonthyear1.Text = ds.Tables[2].Rows[0]["monthNames"].ToString();

                txt_grdyear1unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();
                txt_grdyear2unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();
                txt_grdyear3unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();
                txt_grdyear4unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();
                txt_grdyear5unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();
                txt_grdyear6unitsconsumed.Text = ds.Tables[3].Rows[0]["FinancialYear"].ToString();

                //TextBox txt_grdmonthyear2 = grd_calimsdetails.Rows[1].FindControl("txt_grdmonthyear2") as TextBox;
                txt_grdmonthyear2.Text = ds.Tables[2].Rows[1]["monthNames"].ToString();

                //TextBox txt_grdmonthyear3 = grd_calimsdetails.Rows[2].FindControl("txt_grdmonthyear3") as TextBox;
                txt_grdmonthyear3.Text = ds.Tables[2].Rows[2]["monthNames"].ToString();
                //TextBox txt_grdmonthyear4 = grd_calimsdetails.Rows[3].FindControl("txt_grdmonthyear4") as TextBox;
                txt_grdmonthyear4.Text = ds.Tables[2].Rows[3]["monthNames"].ToString();
                //TextBox txt_grdmonthyear5 = grd_calimsdetails.Rows[4].FindControl("txt_grdmonthyear5") as TextBox;
                txt_grdmonthyear5.Text = ds.Tables[2].Rows[4]["monthNames"].ToString();
                //TextBox txt_grdmonthyear6 = grd_calimsdetails.Rows[5].FindControl("txt_grdmonthyear6") as TextBox;
                txt_grdmonthyear6.Text = ds.Tables[2].Rows[5]["monthNames"].ToString();
            }
            //TextBox txt_grd_halfyear = (TextBox)grd_calimsdetails.Rows[0].FindControl("txt_grd_halfyear");
            txt_grd_halfyear.Text = ds.Tables[0].Rows[0]["secondHFFirstHF"].ToString();
            //TextBox txt_grdyear = (TextBox)grd_calimsdetails.Rows[0].FindControl("txt_grdyear");

            txt_grdyear.Text = ds.Tables[0].Rows[0]["FinancialYear"].ToString();


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

            //lblVehicles_ProjectCost.Text = "";
            //lblVehicles_LoanSanctioned.Text = "";
            //lblVehicles_LoanDisbursed.Text = "";
            //lblVehicles_Assets.Text = "";
            //lblVehicles_ActualExpend_CA.Text = "";
            //lblVehicles_ValueRecommendedByGM.Text = "";

            //lblOthersEligible_ProjectCost.Text = "";
            //lblOthersEligible_LoanSanctioned.Text = "";
            //lblOthersEligible_LoanDisbursed.Text = "";
            //lblOthersEligible_Assets.Text = "";
            //lblOthersEligible_ActualExpend_CA.Text = "";
            //lblOthersEligible_ValueRecommendedByGM.Text = "";

            //lblTotal_ProjectCost.Text = ds.Tables[0].Rows[0]["Total_ProjectCost"].ToString();
            //lblTotal_LoanSanctioned.Text = ds.TatxtfacCostCompcbles[0].Rows[0]["Total_LoanSanctioned"].ToString();
            //lblTotal_LoanDisbursed.Text = ds.Tables[0].Rows[0]["Total_LoanDisbursed"].ToString();
            //lblTotal_Assets.Text = ds.Tables[0].Rows[0]["Total_Assets"].ToString();
            //lblTotal_ActualExpend_CA.Text = ds.Tables[0].Rows[0][Land_VatxtLoanApplnNolueRecommendedByGM"Total_ActualExpend_CA"].ToString();
            //lblTotal_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["Total_ValueRecommendedByGM"].ToString();

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
            Session["GM_Rcon_Amount"] = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();

            //txtLoanSanctioned.Text = txtWC3.Text;



            //txtMortgageDutyPaid.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            //txtTermloanAvailed.Text = txtWC4.Text;
            //decimal a = Convert.ToDecimal(txtTermloanAvailed.Text);
            //decimal b = Convert.ToDecimal(txtMortgageDutyPaid.Text);
            //decimal c = Convert.ToDecimal(txtLoanSanctioned.Text);
            //txtProportionateMortgage.Text = (((a) * (b)) / c).ToString();
            //txtMortgageRecomended.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();

            //if (TextBox44.Text != "0")
            //{
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
            //}
            //if (TextBox45.Text != "0")
            //{
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
            //}
            //decimal d = Convert.ToDecimal(txtProportionateMortgage.Text);
            //decimal e = Convert.ToDecimal(txtMortgageRecomended.Text);

            //if (d == e)
            //    txtEligibleMortgage.Text = d.ToString();
            //else if (d < e)
            //    txtEligibleMortgage.Text = d.ToString();
            //else if (d < e)
            //    txtEligibleMortgage.Text = e.ToString();
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

            fromvo.MstIncentiveId = "3";
            fromvo.id = "";// ((Label)gvrow.FindControl("Label60")).Text.ToString();
            fromvo.status = "Recomm";
            fromvo.Remarks = txtremarks.Text;// HttpUtility.HtmlDecode(GridView16.Rows[rowIndex].Cells[3].Text);
            fromvo.CreatedByid = oIncentiveVosA.created_by;// ((Label)gvrow.FindControl("Label59")).Text.ToString();
            fromvo.Designation = Role_Code.Trim();

            if (Session["IdsustryStatus"].ToString() == "Expansion" && rdbFinYearBothList.SelectedIndex == 1)
            {
                if (rbtgrd_isbelated.SelectedValue == "Y")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_expn);
                    fromvo.Recomamount = Amount;
                }
                if (rbtgrd_isbelated.SelectedValue == "N")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.ifbelatedthentotalamount_expn);
                    fromvo.Recomamount = Amount;
                }
                if (rbtgrd_isbelated.SelectedValue == "R")
                {
                    //Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_expn);
                    fromvo.Recomamount = 0;
                }

            }
            if (Session["IdsustryStatus"].ToString() == "Expansion" && rdbFinYearBothList.SelectedIndex == 0)
            {
                if (RadioButtonList3.SelectedValue == "Y")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamountBoth_expn);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList3.SelectedValue == "N")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.ifbelatedthentotalamountBoth_expn);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList3.SelectedValue == "R")
                {
                    //Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_expn);
                    fromvo.Recomamount = 0;
                }
            }
            if (Session["IdsustryStatus"].ToString() == "New" && rdbFinYearBothList.SelectedIndex == 1)
            {
                if (RadioButtonList1.SelectedValue == "Y")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_new);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList1.SelectedValue == "N")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.ifbelatedthentotalamount_new);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList1.SelectedValue == "R")
                {
                    //Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_expn);
                    fromvo.Recomamount = 0;
                }

            }
            if (Session["IdsustryStatus"].ToString() == "New" && rdbFinYearBothList.SelectedIndex == 0)
            {
                if (RadioButtonList2.SelectedValue == "Y")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamountBoth_new);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList2.SelectedValue == "N")
                {
                    Decimal Amount = Convert.ToDecimal(oIncentiveVosA.ifbelatedthentotalamountBoth_new);
                    fromvo.Recomamount = Amount;
                }
                if (RadioButtonList2.SelectedValue == "R")
                {
                    //Decimal Amount = Convert.ToDecimal(oIncentiveVosA.totaleligibleamount_expn);
                    fromvo.Recomamount = 0;
                }
            }
            fromvo.Recomamount = Convert.ToDecimal(oIncentiveVosA.finalsubsidyamount_systemcalculated);
            lstremarksad.Add(fromvo);

            //Button4.Visible = true;
            // }

            //foreach (GridViewRow gvrow in GridView16.Rows)
            //{
            officerForwarded frmvo = new officerForwarded();
            string lblMstIncentiveId = "3";
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

    public string InsertCommonData(IncentiveVosAppraisal oIncentiveVosA)
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
            com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON_appraisal_PowerTariff]";

            com.Transaction = transaction;
            com.Connection = connection;
            if (oIncentiveVosA.finalsubsidyamount_systemcalculated != null)
                com.Parameters.AddWithValue("@finalsubsidyamount_systemcalculated", oIncentiveVosA.finalsubsidyamount_systemcalculated);


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


            if (oIncentiveVosA.txtquery_coi != null)
                com.Parameters.AddWithValue("@txtquery_coi", oIncentiveVosA.txtquery_coi);

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

            if (oIncentiveVosA.txtvalue422 != null)
                com.Parameters.AddWithValue("@txtvalue422", oIncentiveVosA.txtvalue422);

            if (oIncentiveVosA.TextBox59 != null)
                com.Parameters.AddWithValue("@TextBox59", oIncentiveVosA.TextBox59);

            if (oIncentiveVosA.txt423guideline != null)
                com.Parameters.AddWithValue("@txt423guideline", "");

            if (oIncentiveVosA.txtTSSFCnorms423 != null)
                com.Parameters.AddWithValue("@txtTSSFCnorms423", oIncentiveVosA.txtTSSFCnorms423);

            if (oIncentiveVosA.txtvalue424 != null)
                com.Parameters.AddWithValue("@txtvalue424", oIncentiveVosA.txtvalue424);

            if (oIncentiveVosA.created_by != null)
                com.Parameters.AddWithValue("@createdby", oIncentiveVosA.created_by);
            string test = Session["incentiveid"].ToString();

            if (oIncentiveVosA.incentiveid != null)
                com.Parameters.AddWithValue("@incentiveid", oIncentiveVosA.incentiveid);

            if (oIncentiveVosA.TextBox60 != null)
                com.Parameters.AddWithValue("@TextBox60", oIncentiveVosA.TextBox60);

            /////

            if (oIncentiveVosA.TextBox5 != null)
                com.Parameters.AddWithValue("@TextBox5", oIncentiveVosA.TextBox5);

            if (oIncentiveVosA.TextBox7 != null)
                com.Parameters.AddWithValue("@TextBox7", oIncentiveVosA.TextBox7);

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
            if (oIncentiveVosA.Remarks != null)
                com.Parameters.AddWithValue("@Remarks", oIncentiveVosA.Remarks);
            if (Session["IdsustryStatus"].ToString() == "Expansion")
            {

                if (rdbFinYearBothList.SelectedIndex == 1 || rdbFinYearBothList.SelectedIndex == 0)
                {

                    if (oIncentiveVosA.finyearMonth1_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth1_expn", oIncentiveVosA.finyearMonth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth2_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth2_expn", oIncentiveVosA.finyearMonth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth3_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth3_expn", oIncentiveVosA.finyearMonth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth4_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth4_expn", oIncentiveVosA.finyearMonth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth5_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth5_expn", oIncentiveVosA.finyearMonth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth6_expn != null)
                        com.Parameters.AddWithValue("@finyearMonth6_expn", oIncentiveVosA.finyearMonth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear1_expn != null)
                        com.Parameters.AddWithValue("@finyear1_expn", oIncentiveVosA.finyear1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear2_expn != null)
                        com.Parameters.AddWithValue("@finyear2_expn", oIncentiveVosA.finyear2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear3_expn != null)
                        com.Parameters.AddWithValue("@finyear3_expn", oIncentiveVosA.finyear3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear4_expn != null)
                        com.Parameters.AddWithValue("@finyear4_expn", oIncentiveVosA.finyear4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear5_expn != null)
                        com.Parameters.AddWithValue("@finyear5_expn", oIncentiveVosA.finyear5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear6_expn != null)
                        com.Parameters.AddWithValue("@finyear6_expn", oIncentiveVosA.finyear6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth1_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth1_expn", oIncentiveVosA.unitsconsumedMonth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth2_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth2_expn", oIncentiveVosA.unitsconsumedMonth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth3_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth3_expn", oIncentiveVosA.unitsconsumedMonth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth4_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth4_expn", oIncentiveVosA.unitsconsumedMonth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth5_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth5_expn", oIncentiveVosA.unitsconsumedMonth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth6_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth6_expn", oIncentiveVosA.unitsconsumedMonth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth1_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth1_expn", oIncentiveVosA.rateperunitsMonth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth2_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth2_expn", oIncentiveVosA.rateperunitsMonth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth3_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth3_expn", oIncentiveVosA.rateperunitsMonth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth4_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth4_expn", oIncentiveVosA.rateperunitsMonth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth5_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth5_expn", oIncentiveVosA.rateperunitsMonth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth6_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth6_expn", oIncentiveVosA.rateperunitsMonth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth1_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth1_expn", oIncentiveVosA.amountPaidMonth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth2_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth2_expn", oIncentiveVosA.amountPaidMonth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth3_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth3_expn", oIncentiveVosA.amountPaidMonth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth4_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth4_expn", oIncentiveVosA.amountPaidMonth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth5_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth5_expn", oIncentiveVosA.amountPaidMonth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth6_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonth6_expn", oIncentiveVosA.amountPaidMonth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth1_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth1_expn", oIncentiveVosA.basefixedpermonth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth2_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth2_expn", oIncentiveVosA.basefixedpermonth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth3_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth3_expn", oIncentiveVosA.basefixedpermonth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth4_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth4_expn", oIncentiveVosA.basefixedpermonth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth5_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth5_expn", oIncentiveVosA.basefixedpermonth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth6_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonth6_expn", oIncentiveVosA.basefixedpermonth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover1_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover1_expn", oIncentiveVosA.eligibleunitsover1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover2_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover2_expn", oIncentiveVosA.eligibleunitsover2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover3_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover3_expn", oIncentiveVosA.eligibleunitsover3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover4_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover4_expn", oIncentiveVosA.eligibleunitsover4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover5_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover5_expn", oIncentiveVosA.eligibleunitsover5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsover6_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsover6_expn", oIncentiveVosA.eligibleunitsover6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits1_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits1_expn", oIncentiveVosA.eligiblerateforreimbursementperunits1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits2_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits2_expn", oIncentiveVosA.eligiblerateforreimbursementperunits2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits3_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits3_expn", oIncentiveVosA.eligiblerateforreimbursementperunits3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits4_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits4_expn", oIncentiveVosA.eligiblerateforreimbursementperunits4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits5_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits5_expn", oIncentiveVosA.eligiblerateforreimbursementperunits5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunits6_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunits6_expn", oIncentiveVosA.eligiblerateforreimbursementperunits6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totaleligibleamount_expn != null)
                        com.Parameters.AddWithValue("@totaleligibleamount_expn", oIncentiveVosA.totaleligibleamount_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.isbelated_expn != null)
                        com.Parameters.AddWithValue("@isbelated_expn", oIncentiveVosA.isbelated_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ifbelatedthentotalamount_expn != null)
                        com.Parameters.AddWithValue("@ifbelatedthentotalamount_expn", oIncentiveVosA.ifbelatedthentotalamount_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ELIGIBLETYPE_expn != null)
                        com.Parameters.AddWithValue("@ELIGIBLETYPE_expn", oIncentiveVosA.ELIGIBLETYPE_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunits1_expn != null)   //from here
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits1_expn", oIncentiveVosA.eligibleamountforreimbursementperunits1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligibleamountforreimbursementperunits2_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits2_expn", oIncentiveVosA.eligibleamountforreimbursementperunits2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligibleamountforreimbursementperunits3_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits3_expn", oIncentiveVosA.eligibleamountforreimbursementperunits3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunits4_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits4_expn", oIncentiveVosA.eligibleamountforreimbursementperunits4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunits5_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits5_expn", oIncentiveVosA.eligibleamountforreimbursementperunits5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunits6_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunits6_expn", oIncentiveVosA.eligibleamountforreimbursementperunits6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear1_expn1 != null)
                        com.Parameters.AddWithValue("@finyear1_expn1", oIncentiveVosA.finyear1_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear2_expn1 != null)
                        com.Parameters.AddWithValue("@finyear2_expn1", oIncentiveVosA.finyear2_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear3_expn1 != null)
                        com.Parameters.AddWithValue("@finyear3_expn1", oIncentiveVosA.finyear3_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.noofunits_finyear1_expn1 != null)
                        com.Parameters.AddWithValue("@noofunits_finyear1_expn1", oIncentiveVosA.noofunits_finyear1_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.noofunits_finyear2_expn1 != null)
                        com.Parameters.AddWithValue("@noofunits_finyear2_expn1", oIncentiveVosA.noofunits_finyear2_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.noofunits_finyear3_expn1 != null)
                        com.Parameters.AddWithValue("@noofunits_finyear3_expn1", oIncentiveVosA.noofunits_finyear3_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunit_finyear2_expn1 != null)
                        com.Parameters.AddWithValue("@rateperunit_finyear1_expn1", oIncentiveVosA.rateperunit_finyear1_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunit_finyear2_expn1 != null)
                        com.Parameters.AddWithValue("@rateperunit_finyear2_expn1", oIncentiveVosA.rateperunit_finyear2_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunit_finyear3_expn1 != null)
                        com.Parameters.AddWithValue("@rateperunit_finyear3_expn1", oIncentiveVosA.rateperunit_finyear3_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totalpaid_finyear1_expn1 != null)
                        com.Parameters.AddWithValue("@totalpaid_finyear1_expn1", oIncentiveVosA.totalpaid_finyear1_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totalpaid_finyear2_expn1 != null)
                        com.Parameters.AddWithValue("@totalpaid_finyear2_expn1", oIncentiveVosA.totalpaid_finyear2_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totalpaid_finyear3_expn1 != null)
                        com.Parameters.AddWithValue("@totalpaid_finyear3_expn1", oIncentiveVosA.totalpaid_finyear3_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totalunitconsumed_finyear3_expn1 != null)
                        com.Parameters.AddWithValue("@totalunitconsumed_finyear3_expn1", oIncentiveVosA.totalunitconsumed_finyear3_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totalunitconsumed_averageunits_expn1 != null)
                        com.Parameters.AddWithValue("@totalunitconsumed_averageunits_expn1", oIncentiveVosA.totalunitconsumed_averageunits_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basepowerconsumptionfixed_expn1 != null)
                        com.Parameters.AddWithValue("@basepowerconsumptionfixed_expn1", oIncentiveVosA.basepowerconsumptionfixed_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basepowerconsumptionpermonth_expn1 != null)
                        com.Parameters.AddWithValue("@basepowerconsumptionpermonth_expn1", oIncentiveVosA.basepowerconsumptionpermonth_expn1);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                }

                if (rdbFinYearBothList.SelectedIndex == 0)
                {

                    if (oIncentiveVosA.finyearMonthBoth1_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth1_expn", oIncentiveVosA.finyearMonthBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonthBoth2_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth2_expn", oIncentiveVosA.finyearMonthBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonthBoth3_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth3_expn", oIncentiveVosA.finyearMonthBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonthBoth4_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth4_expn", oIncentiveVosA.finyearMonthBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonthBoth5_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth5_expn", oIncentiveVosA.finyearMonthBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonthBoth6_expn != null)
                        com.Parameters.AddWithValue("@finyearMonthBoth6_expn", oIncentiveVosA.finyearMonthBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth1_expn != null)
                        com.Parameters.AddWithValue("@finyearBoth1_expn", oIncentiveVosA.finyearBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth2_expn != null)
                        com.Parameters.AddWithValue("@finyearBoth2_expn", oIncentiveVosA.finyearBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth3_expn != null)
                        com.Parameters.AddWithValue("@finyearBoth3_expn", oIncentiveVosA.finyearBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth4_expn != null)
                        com.Parameters.AddWithValue("@finyearBoth4_expn", oIncentiveVosA.finyearBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth5_expn != null)
                        com.Parameters.AddWithValue("@finyear5_expn", oIncentiveVosA.finyearBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearBoth6_expn != null)
                        com.Parameters.AddWithValue("@finyearBoth6_expn", oIncentiveVosA.finyearBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth1_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth1_expn", oIncentiveVosA.unitsconsumedMonthBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth2_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth2_expn", oIncentiveVosA.unitsconsumedMonthBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth3_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth3_expn", oIncentiveVosA.unitsconsumedMonthBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth4_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth4_expn", oIncentiveVosA.unitsconsumedMonthBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth5_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth5_expn", oIncentiveVosA.unitsconsumedMonthBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonthBoth6_expn != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonthBoth6_expn", oIncentiveVosA.unitsconsumedMonthBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth1_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth1_expn", oIncentiveVosA.rateperunitsMonthBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth2_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth2_expn", oIncentiveVosA.rateperunitsMonthBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth3_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth3_expn", oIncentiveVosA.rateperunitsMonthBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth4_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth4_expn", oIncentiveVosA.rateperunitsMonthBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth5_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth5_expn", oIncentiveVosA.rateperunitsMonthBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonthBoth6_expn != null)
                        com.Parameters.AddWithValue("@rateperunitsMonthBoth6_expn", oIncentiveVosA.rateperunitsMonthBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth1_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth1_expn", oIncentiveVosA.amountPaidMonthBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth2_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth2_expn", oIncentiveVosA.amountPaidMonthBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth3_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth3_expn", oIncentiveVosA.amountPaidMonthBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth4_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth4_expn", oIncentiveVosA.amountPaidMonthBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth5_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth5_expn", oIncentiveVosA.amountPaidMonthBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonthBoth6_expn != null)
                        com.Parameters.AddWithValue("@amountPaidMonthBoth6_expn", oIncentiveVosA.amountPaidMonthBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonthBoth1_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth1_expn", oIncentiveVosA.basefixedpermonthBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonthBoth2_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth2_expn", oIncentiveVosA.basefixedpermonthBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonthBoth3_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth3_expn", oIncentiveVosA.basefixedpermonthBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonthBoth4_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth4_expn", oIncentiveVosA.basefixedpermonthBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonthBoth5_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth5_expn", oIncentiveVosA.basefixedpermonthBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.basefixedpermonth6_expn != null)
                        com.Parameters.AddWithValue("@basefixedpermonthBoth6_expn", oIncentiveVosA.basefixedpermonthBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth1_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth1_expn", oIncentiveVosA.eligibleunitsoverBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth2_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth2_expn", oIncentiveVosA.eligibleunitsoverBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth3_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth3_expn", oIncentiveVosA.eligibleunitsoverBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth4_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth4_expn", oIncentiveVosA.eligibleunitsoverBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth5_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth5_expn", oIncentiveVosA.eligibleunitsoverBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleunitsoverBoth6_expn != null)
                        com.Parameters.AddWithValue("@eligibleunitsoverBoth6_expn", oIncentiveVosA.eligibleunitsoverBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth1_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth1_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth2_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth2_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth3_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth3_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth4_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth4_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth5_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth5_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligiblerateforreimbursementperunitsBoth6_expn != null)
                        com.Parameters.AddWithValue("@eligiblerateforreimbursementperunitsBoth6_expn", oIncentiveVosA.eligiblerateforreimbursementperunitsBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.totaleligibleamountBoth_expn != null)
                        com.Parameters.AddWithValue("@totaleligibleamountBoth_expn", oIncentiveVosA.totaleligibleamountBoth_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.isbelatedBoth_expn != null)
                        com.Parameters.AddWithValue("@isbelatedBoth_expn", oIncentiveVosA.isbelatedBoth_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ifbelatedthentotalamountBoth_expn != null)
                        com.Parameters.AddWithValue("@ifbelatedthentotalamountBoth_expn", oIncentiveVosA.ifbelatedthentotalamountBoth_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ELIGIBLETYPEBoth_expn != null)
                        com.Parameters.AddWithValue("@ELIGIBLETYPEBoth_expn", oIncentiveVosA.ELIGIBLETYPEBoth_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth1_expn != null)   //from here
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth1_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth1_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth2_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth2_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth2_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth3_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth3_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth3_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth4_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth4_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth4_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth5_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth5_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth5_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.eligibleamountforreimbursementperunitsBoth6_expn != null)
                        com.Parameters.AddWithValue("@eligibleamountforreimbursementperunitsBoth6_expn", oIncentiveVosA.eligibleamountforreimbursementperunitsBoth6_expn);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                  
                }
            }
            if (Session["IdsustryStatus"].ToString() == "New")
            {
                if (rdbFinYearBothList.SelectedIndex == 1 || rdbFinYearBothList.SelectedIndex == 0)
                {
                    if (oIncentiveVosA.finyearMonth1_new != null)
                        com.Parameters.AddWithValue("@finyearMonth1_new", oIncentiveVosA.finyearMonth1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth2_new != null)
                        com.Parameters.AddWithValue("@finyearMonth2_new", oIncentiveVosA.finyearMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth3_new != null)
                        com.Parameters.AddWithValue("@finyearMonth3_new", oIncentiveVosA.finyearMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth4_new != null)
                        com.Parameters.AddWithValue("@finyearMonth4_new", oIncentiveVosA.finyearMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth5_new != null)
                        com.Parameters.AddWithValue("@finyearMonth5_new", oIncentiveVosA.finyearMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyearMonth6_new != null)
                        com.Parameters.AddWithValue("@finyearMonth6_new", oIncentiveVosA.finyearMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.finyear1_new != null)
                        com.Parameters.AddWithValue("@finyear1_new", oIncentiveVosA.finyear1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear2_new != null)
                        com.Parameters.AddWithValue("@finyear2_new", oIncentiveVosA.finyear2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear3_new != null)
                        com.Parameters.AddWithValue("@finyear3_new", oIncentiveVosA.finyear3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear4_new != null)
                        com.Parameters.AddWithValue("@finyear4_new", oIncentiveVosA.finyear4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear5_new != null)
                        com.Parameters.AddWithValue("@finyear5_new", oIncentiveVosA.finyear5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.finyear6_new != null)
                        com.Parameters.AddWithValue("@finyear6_new", oIncentiveVosA.finyear6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.unitsconsumedMonth1_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth1_new", oIncentiveVosA.unitsconsumedMonth1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth2_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth2_new", oIncentiveVosA.unitsconsumedMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth3_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth3_new", oIncentiveVosA.unitsconsumedMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth4_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth4_new", oIncentiveVosA.unitsconsumedMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth5_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth5_new", oIncentiveVosA.unitsconsumedMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.unitsconsumedMonth6_new != null)
                        com.Parameters.AddWithValue("@unitsconsumedMonth6_new", oIncentiveVosA.unitsconsumedMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                    if (oIncentiveVosA.rateperunitsMonth1_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth1_new", oIncentiveVosA.rateperunitsMonth1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth2_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth2_new", oIncentiveVosA.rateperunitsMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth3_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth3_new", oIncentiveVosA.rateperunitsMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth4_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth4_new", oIncentiveVosA.rateperunitsMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth5_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth5_new", oIncentiveVosA.rateperunitsMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.rateperunitsMonth6_new != null)
                        com.Parameters.AddWithValue("@rateperunitsMonth6_new", oIncentiveVosA.rateperunitsMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.amountPaidMonth1_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth1_new", oIncentiveVosA.amountPaidMonth1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth2_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth2_new", oIncentiveVosA.amountPaidMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth3_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth3_new", oIncentiveVosA.amountPaidMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth4_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth4_new", oIncentiveVosA.amountPaidMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth5_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth5_new", oIncentiveVosA.amountPaidMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.amountPaidMonth6_new != null)
                        com.Parameters.AddWithValue("@amountPaidMonth6_new", oIncentiveVosA.amountPaidMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    // from here   
                    //    
                    if (oIncentiveVosA.eligiblerateunitMonth1_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth1_new", oIncentiveVosA.eligiblerateunitMonth1_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateunitMonth2_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth2_new", oIncentiveVosA.eligiblerateunitMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateunitMonth3_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth3_new", oIncentiveVosA.eligiblerateunitMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateunitMonth4_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth4_new", oIncentiveVosA.eligiblerateunitMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateunitMonth5_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth5_new", oIncentiveVosA.eligiblerateunitMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                    if (oIncentiveVosA.eligiblerateunitMonth6_new != null)
                        com.Parameters.AddWithValue("@eligiblerateunitMonth6_new", oIncentiveVosA.eligiblerateunitMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    //     

                    if (oIncentiveVosA.eligiblerateamountMonth1_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth1_new", oIncentiveVosA.eligiblerateamountMonth1_new);

                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                    if (oIncentiveVosA.eligiblerateamountMonth2_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth2_new", oIncentiveVosA.eligiblerateamountMonth2_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateamountMonth3_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth3_new", oIncentiveVosA.eligiblerateamountMonth3_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateamountMonth4_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth4_new", oIncentiveVosA.eligiblerateamountMonth4_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateamountMonth5_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth5_new", oIncentiveVosA.eligiblerateamountMonth5_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                    if (oIncentiveVosA.eligiblerateamountMonth6_new != null)
                        com.Parameters.AddWithValue("@eligiblerateamountMonth6_new", oIncentiveVosA.eligiblerateamountMonth6_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                    // till here

                    if (oIncentiveVosA.totaleligibleamount_new != null)
                        com.Parameters.AddWithValue("@totaleligibleamount_new", oIncentiveVosA.totaleligibleamount_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.isbelated_new != null)
                        com.Parameters.AddWithValue("@isbelated_new", oIncentiveVosA.isbelated_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ifbelatedthentotalamount_new != null)
                        com.Parameters.AddWithValue("@ifbelatedthentotalamount_new", oIncentiveVosA.ifbelatedthentotalamount_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (oIncentiveVosA.ELIGIBLETYPE_new != null)
                        com.Parameters.AddWithValue("@ELIGIBLETYPE_new", oIncentiveVosA.ELIGIBLETYPE_new);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    if (rdbFinYearBothList.SelectedIndex == 0)
                    {
                        if (oIncentiveVosA.finyearMonth1Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth1Both_new", oIncentiveVosA.finyearMonth1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyearMonth2Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth2Both_new", oIncentiveVosA.finyearMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyearMonth3Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth3Both_new", oIncentiveVosA.finyearMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyearMonth4Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth4Both_new", oIncentiveVosA.finyearMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyearMonth5Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth5Both_new", oIncentiveVosA.finyearMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyearMonth6Both_new != null)
                            com.Parameters.AddWithValue("@finyearMonth6Both_new", oIncentiveVosA.finyearMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.finyear1Both_new != null)
                            com.Parameters.AddWithValue("@finyear1Both_new", oIncentiveVosA.finyear1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyear2Both_new != null)
                            com.Parameters.AddWithValue("@finyear2Both_new", oIncentiveVosA.finyear2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyear3Both_new != null)
                            com.Parameters.AddWithValue("@finyear3Both_new", oIncentiveVosA.finyear3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyear4Both_new != null)
                            com.Parameters.AddWithValue("@finyear4Both_new", oIncentiveVosA.finyear4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyear5Both_new != null)
                            com.Parameters.AddWithValue("@finyear5Both_new", oIncentiveVosA.finyear5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.finyear6Both_new != null)
                            com.Parameters.AddWithValue("@finyear6Both_new", oIncentiveVosA.finyear6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.unitsconsumedMonth1Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth1Both_new", oIncentiveVosA.unitsconsumedMonth1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.unitsconsumedMonth2Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth2Both_new", oIncentiveVosA.unitsconsumedMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.unitsconsumedMonth3Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth3Both_new", oIncentiveVosA.unitsconsumedMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.unitsconsumedMonth4Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth4Both_new", oIncentiveVosA.unitsconsumedMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.unitsconsumedMonth5Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth5Both_new", oIncentiveVosA.unitsconsumedMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.unitsconsumedMonth6Both_new != null)
                            com.Parameters.AddWithValue("@unitsconsumedMonth6Both_new", oIncentiveVosA.unitsconsumedMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                        if (oIncentiveVosA.rateperunitsMonth1Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth1Both_new", oIncentiveVosA.rateperunitsMonth1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.rateperunitsMonth2Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth2Both_new", oIncentiveVosA.rateperunitsMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.rateperunitsMonth3Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth3Both_new", oIncentiveVosA.rateperunitsMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.rateperunitsMonth4Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth4Both_new", oIncentiveVosA.rateperunitsMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.rateperunitsMonth5Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth5Both_new", oIncentiveVosA.rateperunitsMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.rateperunitsMonth6Both_new != null)
                            com.Parameters.AddWithValue("@rateperunitsMonth6Both_new", oIncentiveVosA.rateperunitsMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.amountPaidMonth1Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth1Both_new", oIncentiveVosA.amountPaidMonth1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.amountPaidMonth2Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth2Both_new", oIncentiveVosA.amountPaidMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.amountPaidMonth3Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth3Both_new", oIncentiveVosA.amountPaidMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.amountPaidMonth4Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth4Both_new", oIncentiveVosA.amountPaidMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.amountPaidMonth5Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth5Both_new", oIncentiveVosA.amountPaidMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.amountPaidMonth6Both_new != null)
                            com.Parameters.AddWithValue("@amountPaidMonth6Both_new", oIncentiveVosA.amountPaidMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        // from here   
                        //    
                        if (oIncentiveVosA.eligiblerateunitMonth1Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth1Both_new", oIncentiveVosA.eligiblerateunitMonth1Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateunitMonth2Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth2Both_new", oIncentiveVosA.eligiblerateunitMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateunitMonth3Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth3Both_new", oIncentiveVosA.eligiblerateunitMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateunitMonth4Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth4Both_new", oIncentiveVosA.eligiblerateunitMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateunitMonth5Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth5Both_new", oIncentiveVosA.eligiblerateunitMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                        if (oIncentiveVosA.eligiblerateunitMonth6Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateunitMonth6Both_new", oIncentiveVosA.eligiblerateunitMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        //     

                        if (oIncentiveVosA.eligiblerateamountMonth1Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth1Both_new", oIncentiveVosA.eligiblerateamountMonth1Both_new);

                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                        if (oIncentiveVosA.eligiblerateamountMonth2Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth2Both_new", oIncentiveVosA.eligiblerateamountMonth2Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateamountMonth3Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth3Both_new", oIncentiveVosA.eligiblerateamountMonth3Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateamountMonth4Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth4Both_new", oIncentiveVosA.eligiblerateamountMonth4Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateamountMonth5Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth5Both_new", oIncentiveVosA.eligiblerateamountMonth5Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);

                        if (oIncentiveVosA.eligiblerateamountMonth6Both_new != null)
                            com.Parameters.AddWithValue("@eligiblerateamountMonth6Both_new", oIncentiveVosA.eligiblerateamountMonth6Both_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);


                        // till here

                        if (oIncentiveVosA.totaleligibleamountBoth_new != null)
                            com.Parameters.AddWithValue("@totaleligibleamountBoth_new", oIncentiveVosA.totaleligibleamountBoth_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.isbelatedBoth_new != null)
                            com.Parameters.AddWithValue("@isbelatedBoth_new", oIncentiveVosA.isbelatedBoth_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.ifbelatedthentotalamountBoth_new != null)
                            com.Parameters.AddWithValue("@ifbelatedthentotalamountBoth_new", oIncentiveVosA.ifbelatedthentotalamountBoth_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                        if (oIncentiveVosA.ELIGIBLETYPEBoth_new != null)
                            com.Parameters.AddWithValue("@ELIGIBLETYPEBoth_new", oIncentiveVosA.ELIGIBLETYPEBoth_new);
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
                    }
                }



            }
            



            if (oIncentiveVosA.MstIncentiveId != null || oIncentiveVosA.MstIncentiveId == null)
                com.Parameters.AddWithValue("@MstIncentiveId", oIncentiveVosA.MstIncentiveId);
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

        if (rdbFinYearBothList.SelectedIndex == -1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Financial Year Both/Not');", true);
            return;
        }
        else
        {
            if (save())
            {
                string message = "alert('Appraisal note submitted successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //..btn
                Button3.Enabled = false;
                Button1.Visible = false;
            }
        }
       
    }

    public void AssignValuestoVosFromcontrols()
    {
        oIncentiveVosA.finalsubsidyamount_systemcalculated = lbltotalsubsidyamount.Text;
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
        oIncentiveVosA.TextBox59 = "";


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
        oIncentiveVosA.Remarks= txtremarks.Text;

        //oIncentiveVosA.eligibletype = rdeligibility.SelectedValue;
        oIncentiveVosA.Remarks = txtremarks.Text;
        oIncentiveVosA.MstIncentiveId = "3";


        if (Session["IdsustryStatus"].ToString() == "Expansion")
        {
            oIncentiveVosA.finyearMonth1_expn = txt_grdmonthyear1.Text;
            oIncentiveVosA.finyearMonth2_expn = txt_grdmonthyear2.Text;
            oIncentiveVosA.finyearMonth3_expn = txt_grdmonthyear3.Text;
            oIncentiveVosA.finyearMonth4_expn = txt_grdmonthyear4.Text;
            oIncentiveVosA.finyearMonth5_expn = txt_grdmonthyear5.Text;
            oIncentiveVosA.finyearMonth6_expn = txt_grdmonthyear6.Text;   //....

            oIncentiveVosA.finyear1_expn = txt_grdyear1unitsconsumed.Text;
            oIncentiveVosA.finyear2_expn = txt_grdyear2unitsconsumed.Text;
            oIncentiveVosA.finyear3_expn = txt_grdyear3unitsconsumed.Text;
            oIncentiveVosA.finyear4_expn = txt_grdyear4unitsconsumed.Text;
            oIncentiveVosA.finyear5_expn = txt_grdyear5unitsconsumed.Text;
            oIncentiveVosA.finyear6_expn = txt_grdyear6unitsconsumed.Text;  //....

            oIncentiveVosA.unitsconsumedMonth1_expn = txt_grdyear1rateperunit.Text;
            oIncentiveVosA.unitsconsumedMonth2_expn = txt_grdyear2rateperunit.Text;
            oIncentiveVosA.unitsconsumedMonth3_expn = txt_grdyear3rateperunit.Text;
            oIncentiveVosA.unitsconsumedMonth4_expn = txt_grdyear4rateperunit.Text;
            oIncentiveVosA.unitsconsumedMonth5_expn = txt_grdyear5rateperunit.Text;
            oIncentiveVosA.unitsconsumedMonth6_expn = txt_grdyear6rateperunit.Text; //....


            oIncentiveVosA.rateperunitsMonth1_expn = txt_grdyear1amountpaid.Text;
            oIncentiveVosA.rateperunitsMonth2_expn = txt_grdyear2amountpaid.Text;
            oIncentiveVosA.rateperunitsMonth3_expn = txt_grdyear3amountpaid.Text;
            oIncentiveVosA.rateperunitsMonth4_expn = txt_grdyear4amountpaid.Text;
            oIncentiveVosA.rateperunitsMonth5_expn = txt_grdyear5amountpaid.Text;
            oIncentiveVosA.rateperunitsMonth6_expn = txt_grdyear6amountpaid.Text;  //....

            oIncentiveVosA.amountPaidMonth1_expn = txt_grdyear1basefixedunitspermonth.Text;
            oIncentiveVosA.amountPaidMonth2_expn = txt_grdyear2basefixedunitspermonth.Text;
            oIncentiveVosA.amountPaidMonth3_expn = txt_grdyear3basefixedunitspermonth.Text;
            oIncentiveVosA.amountPaidMonth4_expn = txt_grdyear4basefixedunitspermonth.Text;
            oIncentiveVosA.amountPaidMonth5_expn = txt_grdyear5basefixedunitspermonth.Text;
            oIncentiveVosA.amountPaidMonth6_expn = txt_grdyear6basefixedunitspermonth.Text;    //....


            oIncentiveVosA.basefixedpermonth1_expn = txt_grdyear1eligibleunits.Text;
            oIncentiveVosA.basefixedpermonth2_expn = txt_grdyear2eligibleunits.Text;
            oIncentiveVosA.basefixedpermonth3_expn = txt_grdyear3eligibleunits.Text;
            oIncentiveVosA.basefixedpermonth4_expn = txt_grdyear4eligibleunits.Text;
            oIncentiveVosA.basefixedpermonth5_expn = txt_grdyear5eligibleunits.Text;
            oIncentiveVosA.basefixedpermonth6_expn = txt_grdyear6eligibleunits.Text;     //....


            oIncentiveVosA.eligibleunitsover1_expn = txt_grdyear1eligiblerateofreimbursement.Text;
            oIncentiveVosA.eligibleunitsover2_expn = txt_grdyear2eligiblerateofreimbursement.Text;
            oIncentiveVosA.eligibleunitsover3_expn = txt_grdyear3eligiblerateofreimbursement.Text;
            oIncentiveVosA.eligibleunitsover4_expn = txt_grdyear4eligiblerateofreimbursement.Text;
            oIncentiveVosA.eligibleunitsover5_expn = txt_grdyear5eligiblerateofreimbursement.Text;
            oIncentiveVosA.eligibleunitsover6_expn = txt_grdyear6eligiblerateofreimbursement.Text;  //....

            oIncentiveVosA.eligiblerateforreimbursementperunits1_expn = txt_grdyear1eligibleamountforreimbursement.Text;
            oIncentiveVosA.eligiblerateforreimbursementperunits2_expn = txt_grdyear2eligibleamountforreimbursement.Text;
            oIncentiveVosA.eligiblerateforreimbursementperunits3_expn = txt_grdyear3eligibleamountforreimbursement.Text;
            oIncentiveVosA.eligiblerateforreimbursementperunits4_expn = txt_grdyear4eligibleamountforreimbursement.Text;
            oIncentiveVosA.eligiblerateforreimbursementperunits5_expn = txt_grdyear5eligibleamountforreimbursement.Text;
            oIncentiveVosA.eligiblerateforreimbursementperunits6_expn = txt_grdyear6eligibleamountforreimbursement.Text;  //....

            oIncentiveVosA.eligibleamountforreimbursementperunits1_expn = TextBox75.Text;  //added 
            oIncentiveVosA.eligibleamountforreimbursementperunits2_expn = TextBox76.Text;
            oIncentiveVosA.eligibleamountforreimbursementperunits3_expn = TextBox77.Text;
            oIncentiveVosA.eligibleamountforreimbursementperunits4_expn = TextBox78.Text;
            oIncentiveVosA.eligibleamountforreimbursementperunits5_expn = TextBox82.Text;
            oIncentiveVosA.eligibleamountforreimbursementperunits6_expn = TextBox83.Text;     //....

            oIncentiveVosA.finyear1_expn1 = ddlFinancialYear.SelectedItem.ToString();
            oIncentiveVosA.finyear2_expn1 = ddlFinancialYear1.SelectedItem.ToString();
            oIncentiveVosA.finyear3_expn1 = ddlFinancialYear2.SelectedItem.ToString();

            oIncentiveVosA.noofunits_finyear1_expn1 = txt_grddateoffillingindic0.Text;
            oIncentiveVosA.noofunits_finyear2_expn1 = txt_grddateoffillingindic1.Text;
            oIncentiveVosA.noofunits_finyear3_expn1 = TextBox59.Text;

            oIncentiveVosA.rateperunit_finyear1_expn1 = TextBox62.Text;
            oIncentiveVosA.rateperunit_finyear2_expn1 = TextBox66.Text;
            oIncentiveVosA.rateperunit_finyear3_expn1 = TextBox67.Text;

            oIncentiveVosA.totalpaid_finyear1_expn1 = TextBox68.Text;
            oIncentiveVosA.totalpaid_finyear2_expn1 = TextBox69.Text;
            oIncentiveVosA.totalpaid_finyear3_expn1 = TextBox70.Text;


            oIncentiveVosA.totalunitconsumed_finyear3_expn1 = TextBox74.Text;
            oIncentiveVosA.totalunitconsumed_averageunits_expn1 = TextBox97.Text;
            oIncentiveVosA.basepowerconsumptionfixed_expn1 = TextBox98.Text;
            oIncentiveVosA.basepowerconsumptionpermonth_expn1 = TextBox7775.Text;



            oIncentiveVosA.totaleligibleamount_expn = lbl_grdtoteligibleamount.Text;
            oIncentiveVosA.isbelated_expn = rbtgrd_isbelated.SelectedValue.ToString();
            oIncentiveVosA.ifbelatedthentotalamount_expn = txt_belatedamount.Text;


            oIncentiveVosA.ELIGIBLETYPE_expn = rdeligibility.SelectedValue.ToString();

            if (rdbFinYearBothList.SelectedIndex == 0)
            {
                oIncentiveVosA.finyearMonthBoth1_expn = TextBox84.Text;
                oIncentiveVosA.finyearMonthBoth2_expn = TextBox102.Text;
                oIncentiveVosA.finyearMonthBoth3_expn = TextBox109.Text;
                oIncentiveVosA.finyearMonthBoth4_expn = TextBox116.Text;
                oIncentiveVosA.finyearMonthBoth5_expn = TextBox123.Text;
                oIncentiveVosA.finyearMonthBoth6_expn = TextBox130.Text;

                oIncentiveVosA.finyearBoth1_expn = TextBox85.Text;
                oIncentiveVosA.finyearBoth2_expn = TextBox103.Text;
                oIncentiveVosA.finyearBoth3_expn = TextBox110.Text;
                oIncentiveVosA.finyearBoth4_expn = TextBox117.Text;
                oIncentiveVosA.finyearBoth5_expn = TextBox124.Text;
                oIncentiveVosA.finyearBoth6_expn = TextBox131.Text;

                oIncentiveVosA.unitsconsumedMonthBoth1_expn = TextBox86.Text;
                oIncentiveVosA.unitsconsumedMonthBoth2_expn = TextBox104.Text;
                oIncentiveVosA.unitsconsumedMonthBoth3_expn = TextBox111.Text;
                oIncentiveVosA.unitsconsumedMonthBoth4_expn = TextBox118.Text;
                oIncentiveVosA.unitsconsumedMonthBoth5_expn = TextBox125.Text;
                oIncentiveVosA.unitsconsumedMonthBoth6_expn = TextBox132.Text;

                oIncentiveVosA.rateperunitsMonthBoth1_expn = TextBox140.Text;
                oIncentiveVosA.rateperunitsMonthBoth2_expn = TextBox149.Text;
                oIncentiveVosA.rateperunitsMonthBoth3_expn = TextBox158.Text;
                oIncentiveVosA.rateperunitsMonthBoth4_expn = TextBox167.Text;
                oIncentiveVosA.rateperunitsMonthBoth5_expn = TextBox176.Text;
                oIncentiveVosA.rateperunitsMonthBoth6_expn = TextBox185.Text;

                oIncentiveVosA.amountPaidMonthBoth1_expn = TextBox141.Text;
                oIncentiveVosA.amountPaidMonthBoth2_expn = TextBox150.Text;
                oIncentiveVosA.amountPaidMonthBoth3_expn = TextBox159.Text;
                oIncentiveVosA.amountPaidMonthBoth4_expn = TextBox168.Text;
                oIncentiveVosA.amountPaidMonthBoth5_expn = TextBox177.Text;
                oIncentiveVosA.amountPaidMonthBoth6_expn = TextBox186.Text;

                oIncentiveVosA.basefixedpermonthBoth1_expn = TextBox142.Text;
                oIncentiveVosA.basefixedpermonthBoth2_expn = TextBox151.Text;
                oIncentiveVosA.basefixedpermonthBoth3_expn = TextBox160.Text;
                oIncentiveVosA.basefixedpermonthBoth4_expn = TextBox169.Text;
                oIncentiveVosA.basefixedpermonthBoth5_expn = TextBox178.Text;
                oIncentiveVosA.basefixedpermonthBoth6_expn = TextBox187.Text;

                oIncentiveVosA.eligibleunitsoverBoth1_expn = TextBox143.Text;
                oIncentiveVosA.eligibleunitsoverBoth2_expn = TextBox152.Text;
                oIncentiveVosA.eligibleunitsoverBoth3_expn = TextBox161.Text;
                oIncentiveVosA.eligibleunitsoverBoth4_expn = TextBox170.Text;
                oIncentiveVosA.eligibleunitsoverBoth5_expn = TextBox179.Text;
                oIncentiveVosA.eligibleunitsoverBoth6_expn = TextBox188.Text;

                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth1_expn = TextBox144.Text;
                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth2_expn = TextBox153.Text;
                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth3_expn = TextBox162.Text;
                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth4_expn = TextBox171.Text;
                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth5_expn = TextBox180.Text;
                oIncentiveVosA.eligiblerateforreimbursementperunitsBoth6_expn = TextBox189.Text;

                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth1_expn = TextBox145.Text;  //added 
                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth2_expn = TextBox154.Text;
                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth3_expn = TextBox163.Text;
                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth4_expn = TextBox172.Text;
                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth5_expn = TextBox181.Text;
                oIncentiveVosA.eligibleamountforreimbursementperunitsBoth6_expn = TextBox190.Text;

                oIncentiveVosA.totaleligibleamountBoth_expn = TextBox191.Text;
                oIncentiveVosA.isbelatedBoth_expn = RadioButtonList3.SelectedValue.ToString();
                oIncentiveVosA.ifbelatedthentotalamountBoth_expn = TextBox192.Text;

            }
        }

        if (Session["IdsustryStatus"].ToString() == "New")
        {
            oIncentiveVosA.finyearMonth1_new = txt_grdmonthyear1New.Text;
            oIncentiveVosA.finyearMonth2_new = txt_grdmonthyear2New.Text;
            oIncentiveVosA.finyearMonth3_new = txt_grdmonthyear3New.Text;
            oIncentiveVosA.finyearMonth4_new = txt_grdmonthyear4New.Text;
            oIncentiveVosA.finyearMonth5_new = txt_grdmonthyear5New.Text;
            oIncentiveVosA.finyearMonth6_new = txt_grdmonthyear6New.Text;  //---


            oIncentiveVosA.finyear1_new = txt_grdmonthyear1NewFinyear.Text;
            oIncentiveVosA.finyear2_new = txt_grdmonthyear2NewFinyear.Text;
            oIncentiveVosA.finyear3_new = txt_grdmonthyear3NewFinyear.Text;
            oIncentiveVosA.finyear4_new = txt_grdmonthyear4NewFinyear.Text;
            oIncentiveVosA.finyear5_new = txt_grdmonthyear5NewFinyear.Text;
            oIncentiveVosA.finyear6_new = txt_grdmonthyear6NewFinyear.Text;  //---

            oIncentiveVosA.unitsconsumedMonth1_new = TextBox23.Text;
            oIncentiveVosA.unitsconsumedMonth2_new = TextBox50.Text;
            oIncentiveVosA.unitsconsumedMonth3_new = TextBox63.Text;
            oIncentiveVosA.unitsconsumedMonth4_new = TextBox71.Text;
            oIncentiveVosA.unitsconsumedMonth5_new = TextBox79.Text;
            oIncentiveVosA.unitsconsumedMonth6_new = TextBox87.Text;   //---

            oIncentiveVosA.rateperunitsMonth1_new = TextBox24.Text;
            oIncentiveVosA.rateperunitsMonth2_new = TextBox51.Text;
            oIncentiveVosA.rateperunitsMonth3_new = TextBox64.Text;
            oIncentiveVosA.rateperunitsMonth4_new = TextBox72.Text;
            oIncentiveVosA.rateperunitsMonth5_new = TextBox80.Text;
            oIncentiveVosA.rateperunitsMonth6_new = TextBox88.Text;  //---
            oIncentiveVosA.amountPaidMonth1_new = TextBox25.Text;
            oIncentiveVosA.amountPaidMonth2_new = TextBox52.Text;
            oIncentiveVosA.amountPaidMonth3_new = TextBox65.Text;
            oIncentiveVosA.amountPaidMonth4_new = TextBox73.Text;
            oIncentiveVosA.amountPaidMonth5_new = TextBox81.Text;
            oIncentiveVosA.amountPaidMonth6_new = TextBox89.Text; //---

            oIncentiveVosA.eligiblerateunitMonth1_new = TextBox21.Text;
            oIncentiveVosA.eligiblerateunitMonth2_new = TextBox22.Text;
            oIncentiveVosA.eligiblerateunitMonth3_new = TextBox26.Text;
            oIncentiveVosA.eligiblerateunitMonth4_new = TextBox27.Text;
            oIncentiveVosA.eligiblerateunitMonth5_new = TextBox95.Text;
            oIncentiveVosA.eligiblerateunitMonth6_new = TextBox96.Text;  //---

            oIncentiveVosA.eligiblerateamountMonth1_new = TextBox28.Text;
            oIncentiveVosA.eligiblerateamountMonth2_new = TextBox29.Text;
            oIncentiveVosA.eligiblerateamountMonth3_new = TextBox49.Text;
            oIncentiveVosA.eligiblerateamountMonth4_new = TextBox53.Text;
            oIncentiveVosA.eligiblerateamountMonth5_new = TextBox54.Text;
            oIncentiveVosA.eligiblerateamountMonth6_new = TextBox55.Text;


            oIncentiveVosA.totaleligibleamount_new = TextBox93.Text;
            oIncentiveVosA.isbelated_new = RadioButtonList1.SelectedValue.ToString();
            oIncentiveVosA.ifbelatedthentotalamount_new = TextBox94.Text;
            oIncentiveVosA.ELIGIBLETYPE_new = rdeligibility.SelectedValue.ToString();

            if(rdbFinYearBothList.SelectedIndex==0)
            {
                oIncentiveVosA.finyearMonth1Both_new = TextBox84.Text;
                oIncentiveVosA.finyearMonth2Both_new = TextBox102.Text;
                oIncentiveVosA.finyearMonth3Both_new = TextBox109.Text;
                oIncentiveVosA.finyearMonth4Both_new = TextBox116.Text;
                oIncentiveVosA.finyearMonth5Both_new = TextBox123.Text;
                oIncentiveVosA.finyearMonth6Both_new = TextBox130.Text;

                oIncentiveVosA.finyear1Both_new = TextBox85.Text;
                oIncentiveVosA.finyear2Both_new = TextBox103.Text;
                oIncentiveVosA.finyear3Both_new = TextBox110.Text;
                oIncentiveVosA.finyear4Both_new = TextBox117.Text;
                oIncentiveVosA.finyear5Both_new = TextBox124.Text;
                oIncentiveVosA.finyear6Both_new = TextBox131.Text;

                oIncentiveVosA.unitsconsumedMonth1Both_new = TextBox86.Text;
                oIncentiveVosA.unitsconsumedMonth2Both_new = TextBox104.Text;
                oIncentiveVosA.unitsconsumedMonth3Both_new = TextBox111.Text;
                oIncentiveVosA.unitsconsumedMonth4Both_new = TextBox118.Text;
                oIncentiveVosA.unitsconsumedMonth5Both_new = TextBox125.Text;
                oIncentiveVosA.unitsconsumedMonth6Both_new = TextBox132.Text;

                oIncentiveVosA.rateperunitsMonth1Both_new = TextBox90.Text;
                oIncentiveVosA.rateperunitsMonth2Both_new = TextBox105.Text;
                oIncentiveVosA.rateperunitsMonth3Both_new = TextBox112.Text;
                oIncentiveVosA.rateperunitsMonth4Both_new = TextBox119.Text;
                oIncentiveVosA.rateperunitsMonth5Both_new = TextBox126.Text;
                oIncentiveVosA.rateperunitsMonth6Both_new = TextBox133.Text;

                oIncentiveVosA.amountPaidMonth1Both_new = TextBox91.Text;
                oIncentiveVosA.amountPaidMonth2Both_new = TextBox106.Text;
                oIncentiveVosA.amountPaidMonth3Both_new = TextBox113.Text;
                oIncentiveVosA.amountPaidMonth4Both_new = TextBox120.Text;
                oIncentiveVosA.amountPaidMonth5Both_new = TextBox127.Text;
                oIncentiveVosA.amountPaidMonth6Both_new = TextBox134.Text;


                oIncentiveVosA.eligiblerateunitMonth1Both_new= TextBox92.Text;
                oIncentiveVosA.eligiblerateunitMonth2Both_new = TextBox107.Text;
                oIncentiveVosA.eligiblerateunitMonth3Both_new = TextBox114.Text;
                oIncentiveVosA.eligiblerateunitMonth4Both_new = TextBox121.Text;
                oIncentiveVosA.eligiblerateunitMonth5Both_new = TextBox128.Text;
                oIncentiveVosA.eligiblerateunitMonth6Both_new = TextBox135.Text;

                oIncentiveVosA.eligiblerateamountMonth1Both_new = TextBox99.Text;
                oIncentiveVosA.eligiblerateamountMonth2Both_new = TextBox108.Text;
                oIncentiveVosA.eligiblerateamountMonth3Both_new = TextBox115.Text;
                oIncentiveVosA.eligiblerateamountMonth4Both_new = TextBox122.Text;
                oIncentiveVosA.eligiblerateamountMonth5Both_new = TextBox129.Text;
                oIncentiveVosA.eligiblerateamountMonth6Both_new = TextBox136.Text;


                oIncentiveVosA.totaleligibleamountBoth_new = TextBox100.Text;
                oIncentiveVosA.isbelatedBoth_new = RadioButtonList2.SelectedValue.ToString();
                oIncentiveVosA.ifbelatedthentotalamountBoth_new = TextBox101.Text;
                oIncentiveVosA.ELIGIBLETYPEBoth_new = rdeligibility.SelectedValue.ToString();
            }
        }

        oIncentiveVosA.caste_IR = rdbCaste.SelectedValue.ToString();

        oIncentiveVosA.gender_IR = rdbGender.SelectedValue.ToString();

        oIncentiveVosA.category_IR = rdbCategory.SelectedValue.ToString();

        oIncentiveVosA.enterprisetype_IR = rdbEnterprise.SelectedValue.ToString();

        oIncentiveVosA.sector_IR = rdbSector.SelectedValue.ToString();

        oIncentiveVosA.servicetype_IR = rdbServiceType.SelectedValue.ToString();

        oIncentiveVosA.transNonTrans_IR = rdbTransportNonTrans.SelectedValue.ToString();

        //oIncentiveVosA.belatedClaim { get; set; }

        //oIncentiveVosA.isbelated_expn = rbtgrd_isbelated.SelectedValue.ToString();
        //oIncentiveVosA.ifbelatedthentotalamount_expn = txt_belatedamount.Text;
        //oIncentiveVosA.ELIGIBLETYPE_expn = rdeligibility.SelectedValue.ToString();



        //oIncentiveVosA.txtmor = txtLoanSanctioned.Text;


    }
    //business logic
    public class IncentiveVosAppraisal
    {
        public string finalsubsidyamount_systemcalculated { get; set; }
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

        public string finyearMonth1_expn { get; set; }
        public string finyearMonth2_expn { get; set; }
        public string finyearMonth3_expn { get; set; }
        public string finyearMonth4_expn { get; set; }
        public string finyearMonth5_expn { get; set; }
        public string finyearMonth6_expn { get; set; }

        public string finyearMonthBoth1_expn { get; set; }
        public string finyearMonthBoth2_expn { get; set; }
        public string finyearMonthBoth3_expn { get; set; }
        public string finyearMonthBoth4_expn { get; set; }
        public string finyearMonthBoth5_expn { get; set; }
        public string finyearMonthBoth6_expn { get; set; }


        public string finyear1_expn { get; set; }
        public string finyear2_expn { get; set; }
        public string finyear3_expn { get; set; }
        public string finyear4_expn { get; set; }
        public string finyear5_expn { get; set; }
        public string finyear6_expn { get; set; }

        public string finyearBoth1_expn { get; set; }
        public string finyearBoth2_expn { get; set; }
        public string finyearBoth3_expn { get; set; }
        public string finyearBoth4_expn { get; set; }
        public string finyearBoth5_expn { get; set; }
        public string finyearBoth6_expn { get; set; }
        public string unitsconsumedMonth1_expn { get; set; }
        public string unitsconsumedMonth2_expn { get; set; }
        public string unitsconsumedMonth3_expn { get; set; }
        public string unitsconsumedMonth4_expn { get; set; }
        public string unitsconsumedMonth5_expn { get; set; }
        public string unitsconsumedMonth6_expn { get; set; }

        public string unitsconsumedMonthBoth1_expn { get; set; }
        public string unitsconsumedMonthBoth2_expn { get; set; }
        public string unitsconsumedMonthBoth3_expn { get; set; }
        public string unitsconsumedMonthBoth4_expn { get; set; }
        public string unitsconsumedMonthBoth5_expn { get; set; }
        public string unitsconsumedMonthBoth6_expn { get; set; }

        public string rateperunitsMonth1_expn { get; set; }
        public string rateperunitsMonth2_expn { get; set; }
        public string rateperunitsMonth3_expn { get; set; }
        public string rateperunitsMonth4_expn { get; set; }
        public string rateperunitsMonth5_expn { get; set; }
        public string rateperunitsMonth6_expn { get; set; }

        public string rateperunitsMonthBoth1_expn { get; set; }
        public string rateperunitsMonthBoth2_expn { get; set; }
        public string rateperunitsMonthBoth3_expn { get; set; }
        public string rateperunitsMonthBoth4_expn { get; set; }
        public string rateperunitsMonthBoth5_expn { get; set; }
        public string rateperunitsMonthBoth6_expn { get; set; }
        public string amountPaidMonth1_expn { get; set; }
        public string amountPaidMonth2_expn { get; set; }
        public string amountPaidMonth3_expn { get; set; }
        public string amountPaidMonth4_expn { get; set; }
        public string amountPaidMonth5_expn { get; set; }
        public string amountPaidMonth6_expn { get; set; }

        public string amountPaidMonthBoth1_expn { get; set; }
        public string amountPaidMonthBoth2_expn { get; set; }
        public string amountPaidMonthBoth3_expn { get; set; }
        public string amountPaidMonthBoth4_expn { get; set; }
        public string amountPaidMonthBoth5_expn { get; set; }
        public string amountPaidMonthBoth6_expn { get; set; }

        public string basefixedpermonth1_expn { get; set; }
        public string basefixedpermonth2_expn { get; set; }
        public string basefixedpermonth3_expn { get; set; }
        public string basefixedpermonth4_expn { get; set; }
        public string basefixedpermonth5_expn { get; set; }
        public string basefixedpermonth6_expn { get; set; }

        public string basefixedpermonthBoth1_expn { get; set; }
        public string basefixedpermonthBoth2_expn { get; set; }
        public string basefixedpermonthBoth3_expn { get; set; }
        public string basefixedpermonthBoth4_expn { get; set; }
        public string basefixedpermonthBoth5_expn { get; set; }
        public string basefixedpermonthBoth6_expn { get; set; }

        public string eligibleunitsover1_expn { get; set; }
        public string eligibleunitsover2_expn { get; set; }
        public string eligibleunitsover3_expn { get; set; }
        public string eligibleunitsover4_expn { get; set; }
        public string eligibleunitsover5_expn { get; set; }
        public string eligibleunitsover6_expn { get; set; }


        public string eligibleunitsoverBoth1_expn { get; set; }
        public string eligibleunitsoverBoth2_expn { get; set; }
        public string eligibleunitsoverBoth3_expn { get; set; }
        public string eligibleunitsoverBoth4_expn { get; set; }
        public string eligibleunitsoverBoth5_expn { get; set; }
        public string eligibleunitsoverBoth6_expn { get; set; }

        public string eligiblerateforreimbursementperunits1_expn { get; set; }
        public string eligiblerateforreimbursementperunits2_expn { get; set; }
        public string eligiblerateforreimbursementperunits3_expn { get; set; }
        public string eligiblerateforreimbursementperunits4_expn { get; set; }
        public string eligiblerateforreimbursementperunits5_expn { get; set; }
        public string eligiblerateforreimbursementperunits6_expn { get; set; }


        public string eligiblerateforreimbursementperunitsBoth1_expn { get; set; }
        public string eligiblerateforreimbursementperunitsBoth2_expn { get; set; }
        public string eligiblerateforreimbursementperunitsBoth3_expn { get; set; }
        public string eligiblerateforreimbursementperunitsBoth4_expn { get; set; }
        public string eligiblerateforreimbursementperunitsBoth5_expn { get; set; }
        public string eligiblerateforreimbursementperunitsBoth6_expn { get; set; }

        public string eligibleamountforreimbursementperunits1_expn { get; set; }   //froom heere - add in proc
        public string eligibleamountforreimbursementperunits2_expn { get; set; }
        public string eligibleamountforreimbursementperunits3_expn { get; set; }
        public string eligibleamountforreimbursementperunits4_expn { get; set; }
        public string eligibleamountforreimbursementperunits5_expn { get; set; }
        public string eligibleamountforreimbursementperunits6_expn { get; set; }


        public string eligibleamountforreimbursementperunitsBoth1_expn { get; set; }   //froom heere - add in proc
        public string eligibleamountforreimbursementperunitsBoth2_expn { get; set; }
        public string eligibleamountforreimbursementperunitsBoth3_expn { get; set; }
        public string eligibleamountforreimbursementperunitsBoth4_expn { get; set; }
        public string eligibleamountforreimbursementperunitsBoth5_expn { get; set; }
        public string eligibleamountforreimbursementperunitsBoth6_expn { get; set; }

        public string finyear1_expn1 { get; set; } 
        public string finyear2_expn1 { get; set; }
        public string finyear3_expn1 { get; set; }
        
        public string noofunits_finyear1_expn1 { get; set; }  
        public string noofunits_finyear2_expn1 { get; set; }
        public string noofunits_finyear3_expn1 { get; set; }

        public string rateperunit_finyear1_expn1 { get; set; }
        public string rateperunit_finyear2_expn1 { get; set; }
        public string rateperunit_finyear3_expn1 { get; set; }

        public string totalpaid_finyear1_expn1 { get; set; }
        public string totalpaid_finyear2_expn1 { get; set; }
        public string totalpaid_finyear3_expn1 { get; set; }

        public string totalunitconsumed_finyear3_expn1 { get; set; }

        public string totalunitconsumed_averageunits_expn1 { get; set; }
        public string basepowerconsumptionfixed_expn1 { get; set; }
        public string basepowerconsumptionpermonth_expn1 { get; set; }  //end ehere

        public string totaleligibleamount_expn { get; set; }
        public string isbelated_expn { get; set; }
        public string ifbelatedthentotalamount_expn { get; set; }

        public string totaleligibleamountBoth_expn { get; set; }
        public string isbelatedBoth_expn { get; set; }
        public string ifbelatedthentotalamountBoth_expn { get; set; }

        public string ELIGIBLETYPE_expn { get; set; }
        public string ELIGIBLETYPEBoth_expn { get; set; }
        public string finyearMonth1_new { get; set; }
        public string finyearMonth2_new { get; set; }
        public string finyearMonth3_new { get; set; }
        public string finyearMonth4_new { get; set; }
        public string finyearMonth5_new { get; set; }
        public string finyearMonth6_new { get; set; }

        public string finyearMonth1Both_new { get; set; }
        public string finyearMonth2Both_new { get; set; }
        public string finyearMonth3Both_new { get; set; }
        public string finyearMonth4Both_new { get; set; }
        public string finyearMonth5Both_new { get; set; }
        public string finyearMonth6Both_new { get; set; }
        public string finyear1_new { get; set; }
        public string finyear2_new { get; set; }
        public string finyear3_new { get; set; }
        public string finyear4_new { get; set; }
        public string finyear5_new { get; set; }
        public string finyear6_new { get; set; }

        public string finyear1Both_new { get; set; }
        public string finyear2Both_new { get; set; }
        public string finyear3Both_new { get; set; }
        public string finyear4Both_new { get; set; }
        public string finyear5Both_new { get; set; }
        public string finyear6Both_new { get; set; }
        public string unitsconsumedMonth1_new { get; set; }
        public string unitsconsumedMonth2_new { get; set; }
        public string unitsconsumedMonth3_new { get; set; }
        public string unitsconsumedMonth4_new { get; set; }
        public string unitsconsumedMonth5_new { get; set; }
        public string unitsconsumedMonth6_new { get; set; }

        public string unitsconsumedMonth1Both_new { get; set; }
        public string unitsconsumedMonth2Both_new { get; set; }
        public string unitsconsumedMonth3Both_new { get; set; }
        public string unitsconsumedMonth4Both_new { get; set; }
        public string unitsconsumedMonth5Both_new { get; set; }
        public string unitsconsumedMonth6Both_new { get; set; }
        public string rateperunitsMonth1_new { get; set; }
        public string rateperunitsMonth2_new { get; set; }
        public string rateperunitsMonth3_new { get; set; }
        public string rateperunitsMonth4_new { get; set; }
        public string rateperunitsMonth5_new { get; set; }
        public string rateperunitsMonth6_new { get; set; }

        public string rateperunitsMonth1Both_new { get; set; }
        public string rateperunitsMonth2Both_new { get; set; }
        public string rateperunitsMonth3Both_new { get; set; }
        public string rateperunitsMonth4Both_new { get; set; }
        public string rateperunitsMonth5Both_new { get; set; }
        public string rateperunitsMonth6Both_new { get; set; }
        public string amountPaidMonth1_new { get; set; }
        public string amountPaidMonth2_new { get; set; }
        public string amountPaidMonth3_new { get; set; }
        public string amountPaidMonth4_new { get; set; }
        public string amountPaidMonth5_new { get; set; }
        public string amountPaidMonth6_new { get; set; }

        public string amountPaidMonth1Both_new { get; set; }
        public string amountPaidMonth2Both_new { get; set; }
        public string amountPaidMonth3Both_new { get; set; }
        public string amountPaidMonth4Both_new { get; set; }
        public string amountPaidMonth5Both_new { get; set; }
        public string amountPaidMonth6Both_new { get; set; }



        //
        public string eligiblerateunitMonth1_new { get; set; }
        public string eligiblerateunitMonth2_new { get; set; }
        public string eligiblerateunitMonth3_new { get; set; }
        public string eligiblerateunitMonth4_new { get; set; }
        public string eligiblerateunitMonth5_new { get; set; }
        public string eligiblerateunitMonth6_new { get; set; }

        public string eligiblerateunitMonth1Both_new { get; set; }
        public string eligiblerateunitMonth2Both_new { get; set; }
        public string eligiblerateunitMonth3Both_new { get; set; }
        public string eligiblerateunitMonth4Both_new { get; set; }
        public string eligiblerateunitMonth5Both_new { get; set; }
        public string eligiblerateunitMonth6Both_new { get; set; }
        public string eligiblerateamountMonth1_new { get; set; }
        public string eligiblerateamountMonth2_new { get; set; }
        public string eligiblerateamountMonth3_new { get; set; }
        public string eligiblerateamountMonth4_new { get; set; }
        public string eligiblerateamountMonth5_new { get; set; }
        public string eligiblerateamountMonth6_new { get; set; }

        public string eligiblerateamountMonth1Both_new { get; set; }
        public string eligiblerateamountMonth2Both_new { get; set; }
        public string eligiblerateamountMonth3Both_new { get; set; }
        public string eligiblerateamountMonth4Both_new { get; set; }
        public string eligiblerateamountMonth5Both_new { get; set; }
        public string eligiblerateamountMonth6Both_new { get; set; }
        //
        public string totaleligibleamount_new { get; set; }
        public string isbelated_new { get; set; }
        public string ifbelatedthentotalamount_new { get; set; }
        public string ELIGIBLETYPE_new { get; set; }

        public string belatedClaim { get; set; }

        public string totaleligibleamountBoth_new { get; set; }
        public string isbelatedBoth_new { get; set; }
        public string ifbelatedthentotalamountBoth_new { get; set; }
        public string ELIGIBLETYPEBoth_new { get; set; }

        public string belatedClaimBoth { get; set; }

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

        if (rdbFinYearBothList.SelectedIndex==-1)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year Both/Not \\n";
            slno = slno + 1;
        }
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
        if (ddlOrddlorgtypes.SelectedIndex == -1)
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



        if (rdeligibility.SelectedValue.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select type of Eligiblity \\n";
            slno = slno + 1;
        }
        if (rdbFinYearBothList.SelectedValue == "" || rdbFinYearBothList.SelectedValue == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year Both/Not \\n";
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
            mstincentiveid = "3";

            //mstincentiveid = Request.QueryString["mstid"].ToString()/*;*/
            dtMyTableCertificate = createtablecrtificate1();
            Session["CertificateTb2"] = dtMyTableCertificate;
            BindConstitutionUnit();
            USP_GETDETAILSFORSECTION(Session["incentiveid"].ToString(), mstincentiveid);
            getUdyogAadharType1();
            calleventforbackup(Session["incentiveid"].ToString());
            //btnINCSearch.Enabled = false;
            //grd_calimsdetails_RowDataBound(null, null);

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
            Response.Redirect("appraisalNote_is.aspx?incid=" + txtINCNoEntry.Text.ToString() + "&mstid=15");
        }


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
            string masterincentiveid = "3";
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];

                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                        string serverpath = System.IO.Path.Combine(sFileDir + incentiveid.ToString() + "\\" + "ADWORKSHEET_POWER" + "\\" +  masterincentiveid.ToString());
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "100018", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachmentInspReports(incentiveid, "1111112", sFileName, serverpath, CrtdUser, masterincentiveid.ToString(), "WorkSheet");

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
        Response.Redirect("frmCoiDashboard.aspx");// + hdfID.Value
    }





    #region fixed capitaltxt_fixedcapital_TextChanged
    //protected void txt_fixedcapital_TextChanged(object sender, EventArgs e)
    //{
    //    string errormsg = displayfixedcapital();
    //    if (errormsg.Trim().TrimStart() != "")
    //    {
    //        string message = "alert('" + errormsg + "')";
    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    //        return;
    //    }
    //}

    #endregion


    #region Date of New Con.Released previous three years

    //protected void ddlAppliedFor_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string errormsg = bindpreviousyears();
    //    if (errormsg.Trim().TrimStart() != "")
    //    {
    //        string message = "alert('" + errormsg + "')";
    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    //        return;
    //    }
    //}

    //protected void txt_dateofnewcon_TextChanged(object sender, EventArgs e)
    //{
    //    string errormsg = bindpreviousyears();
    //    if (errormsg.Trim().TrimStart() != "")
    //    {
    //        string message = "alert('" + errormsg + "')";
    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    //        return;
    //    }
    //}
    //public string bindpreviousyears()
    //{
    //    lbl_mainheaddetailsoffinyear.Visible = false;
    //    tbl_financalyear.Visible = false;

    //    string ErrorMsg = "";
    //    int slno = 1;
    //    if (!string.IsNullOrEmpty(txt_dateofnewcon.Text))
    //    {
    //        if (valid_isdatetime(Convert.ToString(txt_dateofnewcon.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Correct Date of New Con.Released\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            if (!string.IsNullOrEmpty(ddlAppliedFor.SelectedValue))
    //            {
    //                if (ddlAppliedFor.SelectedValue == "2")
    //                {
    //                    int year = Convert.ToDateTime(txt_dateofnewcon.Text).Year;
    //                    txt_finacialyear1.Text = (year - 4) + "-" + (year - 3);
    //                    txt_finacialyear2.Text = (year - 3) + "-" + (year - 2);
    //                    txt_finacialyear3.Text = (year - 2) + "-" + (year - 1);
    //                    txt_yearpriorem.Text = "3";
    //                    lbl_mainheaddetailsoffinyear.Visible = true;
    //                    tbl_financalyear.Visible = true;
    //                }
    //            }
    //        }
    //    }

    //    //txt_dateofnewcon.Text = "";
    //    //    txt_finacialyear1.Text = "";
    //    //txt_finacialyear2.Text = "";
    //    //txt_finacialyear3.Text = "";
    //    return ErrorMsg;
    //}

    protected void txt_previousfinunitsutilised_TextChanged(object sender, EventArgs e)
    {
        //string errormsg = calprefinaulitizedunits();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
    }

    //public string calprefinaulitizedunits()
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;

    //    int fin1unitsutilised = 0; int fin2unitsutilised = 0; int fin3unitsutilised = 0;
    //    int totunitsconsumedpriorto3years = 0; decimal averageunitsem = 0;

    //    //check text box is null or not,if null display 0
    //    //check text box is integer or not

    //    if (!string.IsNullOrEmpty(txt_fin1unitsutilised.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_fin1unitsutilised.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-1 No of Units Utilised\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            fin1unitsutilised = Convert.ToInt32(txt_fin1unitsutilised.Text);
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(txt_fin2unitsutilised.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_fin2unitsutilised.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-2 No of Units Utilised\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            fin2unitsutilised = Convert.ToInt32(txt_fin2unitsutilised.Text);
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(txt_fin3unitsutilised.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_fin3unitsutilised.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-3 No of Units Utilised\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            fin3unitsutilised = Convert.ToInt32(txt_fin3unitsutilised.Text);
    //        }
    //    }

    //    totunitsconsumedpriorto3years = fin1unitsutilised + fin2unitsutilised + fin3unitsutilised;
    //    txt_totunitsconsumedpriorto3years.Text = Convert.ToString(totunitsconsumedpriorto3years);
    //    if (fin1unitsutilised <= 0 && fin2unitsutilised <= 0 && fin3unitsutilised <= 0)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-1,2,3 No of Units Utilised should be less than or equal to zero\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //        averageunitsem = (totunitsconsumedpriorto3years / 3);
    //    }
    //    txt_averageunitsem.Text = Convert.ToString(averageunitsem);

    //    return ErrorMsg;
    //}

    //protected void txt_basepowerconsumptionfixedperyear_TextChanged(object sender, EventArgs e)
    //{
    //    string errormsg = calbasepowerconfixed();
    //    if (errormsg.Trim().TrimStart() != "")
    //    {
    //        string message = "alert('" + errormsg + "')";
    //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    //        return;
    //    }
    //}

    //public string calbasepowerconfixed()
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;
    //    int basepowerconsumptionfixedperyear = 0; int basepowerconsumptionfixedpermonth = 0;
    //    //check text box is null or not,if null display 0
    //    //check text box is integer or not
    //    if (!string.IsNullOrEmpty(txt_basepowerconsumptionfixedperyear.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_basepowerconsumptionfixedperyear.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Base Power Consumption fixed per year\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            basepowerconsumptionfixedperyear = Convert.ToInt32(txt_basepowerconsumptionfixedperyear.Text);
    //        }
    //    }
    //    if (basepowerconsumptionfixedperyear <= 0)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Base Power Consumption fixed per year should be not less than or equal to zero\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //        basepowerconsumptionfixedpermonth = (basepowerconsumptionfixedperyear / 12);
    //    }
    //    txt_basepowerconsumptionfixedpermonth.Text = Convert.ToString(basepowerconsumptionfixedpermonth);

    //    return ErrorMsg;
    //}

    #endregion

    #region no of claims databinding

    protected void ddl_scheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string errormsg = claimsgrd();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
    }

    protected void txt_basepowerconsumptionfixedpermonth_TextChanged(object sender, EventArgs e)
    {
        //string errormsg = claimsgrd();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
    }
    protected void txt_noofclaims_TextChanged(object sender, EventArgs e)
    {
        //string errormsg = claimsgrd();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
    }
    //public string claimsgrd()
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;
    //    int noofclaims = 0; double powerTrafiffperUnit = 0; double eligiblrrateforreimbursement;
    //    int basepowerconsumptionfixedpermonth = 0;
    //    //check text box is null or not,if null display 0
    //    //check text box is integer or not

    //    if (!string.IsNullOrEmpty(txt_noofclaims.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_noofclaims.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric No of Claims\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            noofclaims = Convert.ToInt32(txt_noofclaims.Text);
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(txt_basepowerconsumptionfixedpermonth.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_basepowerconsumptionfixedpermonth.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Base Power Consumption fixed per Month\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            basepowerconsumptionfixedpermonth = Convert.ToInt32(txt_basepowerconsumptionfixedpermonth.Text);
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(ddl_scheme.SelectedValue))
    //    {
    //        if (ddl_scheme.SelectedIndex <= 0)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter select Scheme\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            powerTrafiffperUnit = Convert.ToDouble(ddl_scheme.SelectedValue);
    //        }
    //    }

    //    // powerTrafiffperUnit = 3.25;
    //    eligiblrrateforreimbursement = 1;
    //    txt_powerTrafiffperUnit.Text = Convert.ToString(powerTrafiffperUnit);
    //    txt_eligiblrrateforreimbursement.Text = Convert.ToString(eligiblrrateforreimbursement);
    //    if (noofclaims > 0)
    //    {
    //        //grd_calimsdetails
    //        DataTable dtmain = new DataTable();
    //        dtmain.Columns.Add("number");
    //        dtmain.Columns.Add("rateperunit");
    //        dtmain.Columns.Add("basefixedunitspermonth");
    //        dtmain.Columns.Add("reimbursementrateperunit");


    //        for (int i = 0; i < noofclaims; i++)
    //        {
    //            DataRow drs = dtmain.NewRow();
    //            drs["number"] = i + 1;
    //            drs["basefixedunitspermonth"] = basepowerconsumptionfixedpermonth;
    //            drs["rateperunit"] = powerTrafiffperUnit;
    //            drs["reimbursementrateperunit"] = eligiblrrateforreimbursement;
    //            dtmain.Rows.Add(drs);
    //        }
    //        DataSet dsmain = new DataSet();
    //        dsmain.Tables.Add(dtmain);

    //        grd_calimsdetails.DataSource = dsmain;
    //        grd_calimsdetails.DataBind();



    //    }
    //    else
    //    {
    //        grd_calimsdetails.DataSource = null;
    //        grd_calimsdetails.DataBind();
    //    }

    //    return ErrorMsg;
    //}

    #endregion

    public string claimsgrd()
    {
        string ErrorMsg = "";
        int slno = 1;
        int noofclaims = 0; double powerTrafiffperUnit = 0; double eligiblrrateforreimbursement;
        int basepowerconsumptionfixedpermonth = 0;

        if (!string.IsNullOrEmpty(txt_noofclaims.Text))
        {
            if (valid_isnumeric(Convert.ToString(txt_noofclaims.Text)) == false)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric No of Claims\\n";
                slno = slno + 1;
            }
            else
            {
                noofclaims = Convert.ToInt32(txt_noofclaims.Text);
            }
        }

        eligiblrrateforreimbursement = 1;
        txt_powerTrafiffperUnit.Text = Convert.ToString(powerTrafiffperUnit);
        txt_eligiblrrateforreimbursement.Text = Convert.ToString(eligiblrrateforreimbursement);

        DataTable dtmain = new DataTable();
        dtmain.Columns.Add("number");
        dtmain.Columns.Add("rateperunit");
        dtmain.Columns.Add("basefixedunitspermonth");
        dtmain.Columns.Add("reimbursementrateperunit");


        for (int i = 0; i < 5; i++)
        {
            DataRow drs = dtmain.NewRow();
            drs["number"] = i + 1;
            drs["basefixedunitspermonth"] = basepowerconsumptionfixedpermonth;
            drs["rateperunit"] = powerTrafiffperUnit;
            drs["reimbursementrateperunit"] = eligiblrrateforreimbursement;
            dtmain.Rows.Add(drs);
        }
        DataSet dsmain = new DataSet();
        dsmain.Tables.Add(dtmain);

        grd_calimsdetails.DataSource = dsmain;
        grd_calimsdetails.DataBind();



        //if (noofclaims > 0)
        //{
        //    //grd_calimsdetails



        //}
        //else
        //{
        //    grd_calimsdetails.DataSource = null;
        //    grd_calimsdetails.DataBind();
        //}

        return ErrorMsg;
    }

    #region eachgrid
    protected void txt_grddateoffillingindic_TextChanged(object sender, EventArgs e)
    {
        //TextBox txt_grddateoffillingindic = (TextBox)sender;
        //GridViewRow grd_calimsdetails = (GridViewRow)txt_grddateoffillingindic.Parent.Parent;

        //TextBox txt_grddateoffillingindic = (TextBox)sender;
        //GridViewRow grd_calimsdetails = (GridViewRow)txt_grddateoffillingindic.NamingContainer;

        TextBox txt_grddateoffillingindic_org = (TextBox)grd_calimsdetails.FindControl("txt_grddateoffillingindic");
        DropDownList ddl_grdedingyear_org = (DropDownList)grd_calimsdetails.FindControl("ddl_grdedingyear");
        TextBox txt_grd_halfyear = (TextBox)grd_calimsdetails.FindControl("txt_grd_halfyear");
        TextBox txt_grdyear = (TextBox)grd_calimsdetails.FindControl("txt_grdyear");
        TextBox txt_grdmonthyear1 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear1");
        TextBox txt_grdmonthyear2 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear2");
        TextBox txt_grdmonthyear3 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear3");
        TextBox txt_grdmonthyear4 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear4");
        TextBox txt_grdmonthyear5 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear5");
        TextBox txt_grdmonthyear6 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear6");

        //TextBox txt_grdyear1rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1rateperunit");
        //TextBox txt_grdyear2rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2rateperunit");
        //TextBox txt_grdyear3rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3rateperunit");
        //TextBox txt_grdyear4rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4rateperunit");
        //TextBox txt_grdyear5rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5rateperunit");
        //TextBox txt_grdyear6rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6rateperunit");

        //TextBox txt_grdyear1basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1basefixedunitspermonth");
        //TextBox txt_grdyear2basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2basefixedunitspermonth");
        //TextBox txt_grdyear3basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3basefixedunitspermonth");
        //TextBox txt_grdyear4basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4basefixedunitspermonth");
        //TextBox txt_grdyear5basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5basefixedunitspermonth");
        //TextBox txt_grdyear6basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6basefixedunitspermonth");

        //TextBox txt_grdyear1eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1eligiblerateofreimbursement");
        //TextBox txt_grdyear2eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2eligiblerateofreimbursement");
        //TextBox txt_grdyear3eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3eligiblerateofreimbursement");
        //TextBox txt_grdyear4eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4eligiblerateofreimbursement");
        //TextBox txt_grdyear5eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5eligiblerateofreimbursement");
        //TextBox txt_grdyear6eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6eligiblerateofreimbursement");


        string errormsg = binddatamonthstofrddetailseergycosumed(txt_grddateoffillingindic_org, ddl_grdedingyear_org, txt_grdmonthyear1,
           txt_grdmonthyear2, txt_grdmonthyear3, txt_grdmonthyear4, txt_grdmonthyear5, txt_grdmonthyear6, txt_grd_halfyear, txt_grdyear);

        //string errormsg = binddatamonthstofrddetailseergycosumed(txt_grddateoffillingindic_org, ddl_grdedingyear_org, txt_grdmonthyear1,
        //    txt_grdmonthyear2, txt_grdmonthyear3, txt_grdmonthyear4, txt_grdmonthyear5, txt_grdmonthyear6, txt_grd_halfyear, txt_grdyear,
        //      txt_grdyear1rateperunit, txt_grdyear2rateperunit, txt_grdyear3rateperunit, txt_grdyear4rateperunit, txt_grdyear5rateperunit,
        //  txt_grdyear6rateperunit, txt_grdyear1basefixedunitspermonth, txt_grdyear2basefixedunitspermonth, txt_grdyear3basefixedunitspermonth,
        //  txt_grdyear4basefixedunitspermonth, txt_grdyear5basefixedunitspermonth, txt_grdyear6basefixedunitspermonth,
        //  txt_grdyear1eligiblerateofreimbursement, txt_grdyear2eligiblerateofreimbursement, txt_grdyear3eligiblerateofreimbursement,
        //  txt_grdyear4eligiblerateofreimbursement, txt_grdyear5eligiblerateofreimbursement, txt_grdyear6eligiblerateofreimbursement);
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    protected void ddl_grdedingyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList ddl_grdedingyear = (DropDownList)sender;
        //GridViewRow gvRow = (GridViewRow)ddl_grdedingyear.Parent.Parent;

        DropDownList ddl_grdedingyear = (DropDownList)sender;
        GridViewRow gvRow = (GridViewRow)ddl_grdedingyear.NamingContainer;

        TextBox txt_grddateoffillingindic_org = (TextBox)gvRow.FindControl("txt_grddateoffillingindic");
        DropDownList ddl_grdedingyear_org = (DropDownList)gvRow.FindControl("ddl_grdedingyear");
        TextBox txt_grd_halfyear = (TextBox)gvRow.FindControl("txt_grd_halfyear");
        TextBox txt_grdyear = (TextBox)gvRow.FindControl("txt_grdyear");


        TextBox txt_grdmonthyear1 = (TextBox)gvRow.FindControl("txt_grdmonthyear1");
        TextBox txt_grdmonthyear2 = (TextBox)gvRow.FindControl("txt_grdmonthyear2");
        TextBox txt_grdmonthyear3 = (TextBox)gvRow.FindControl("txt_grdmonthyear3");
        TextBox txt_grdmonthyear4 = (TextBox)gvRow.FindControl("txt_grdmonthyear4");
        TextBox txt_grdmonthyear5 = (TextBox)gvRow.FindControl("txt_grdmonthyear5");
        TextBox txt_grdmonthyear6 = (TextBox)gvRow.FindControl("txt_grdmonthyear6");

        //TextBox txt_grdyear1rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1rateperunit");
        //TextBox txt_grdyear2rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2rateperunit");
        //TextBox txt_grdyear3rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3rateperunit");
        //TextBox txt_grdyear4rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4rateperunit");
        //TextBox txt_grdyear5rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5rateperunit");
        //TextBox txt_grdyear6rateperunit = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6rateperunit");

        //TextBox txt_grdyear1basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1basefixedunitspermonth");
        //TextBox txt_grdyear2basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2basefixedunitspermonth");
        //TextBox txt_grdyear3basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3basefixedunitspermonth");
        //TextBox txt_grdyear4basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4basefixedunitspermonth");
        //TextBox txt_grdyear5basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5basefixedunitspermonth");
        //TextBox txt_grdyear6basefixedunitspermonth = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6basefixedunitspermonth");

        //TextBox txt_grdyear1eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear1eligiblerateofreimbursement");
        //TextBox txt_grdyear2eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear2eligiblerateofreimbursement");
        //TextBox txt_grdyear3eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear3eligiblerateofreimbursement");
        //TextBox txt_grdyear4eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear4eligiblerateofreimbursement");
        //TextBox txt_grdyear5eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear5eligiblerateofreimbursement");
        //TextBox txt_grdyear6eligiblerateofreimbursement = (TextBox)grd_calimsdetails.FindControl("txt_grdyear6eligiblerateofreimbursement");

        string errormsg = binddatamonthstofrddetailseergycosumed(txt_grddateoffillingindic_org, ddl_grdedingyear_org, txt_grdmonthyear1,
        txt_grdmonthyear2, txt_grdmonthyear3, txt_grdmonthyear4, txt_grdmonthyear5, txt_grdmonthyear6, txt_grd_halfyear, txt_grdyear);

        //string errormsg = binddatamonthstofrddetailseergycosumed(txt_grddateoffillingindic_org, ddl_grdedingyear_org, txt_grdmonthyear1,
        //  txt_grdmonthyear2, txt_grdmonthyear3, txt_grdmonthyear4, txt_grdmonthyear5, txt_grdmonthyear6, txt_grd_halfyear, txt_grdyear,
        //  txt_grdyear1rateperunit,txt_grdyear2rateperunit,txt_grdyear3rateperunit,txt_grdyear4rateperunit,txt_grdyear5rateperunit,
        //  txt_grdyear6rateperunit,txt_grdyear1basefixedunitspermonth,txt_grdyear2basefixedunitspermonth,txt_grdyear3basefixedunitspermonth,
        //  txt_grdyear4basefixedunitspermonth,txt_grdyear5basefixedunitspermonth,txt_grdyear6basefixedunitspermonth,
        //  txt_grdyear1eligiblerateofreimbursement,txt_grdyear2eligiblerateofreimbursement,txt_grdyear3eligiblerateofreimbursement,
        //  txt_grdyear4eligiblerateofreimbursement,txt_grdyear5eligiblerateofreimbursement,txt_grdyear6eligiblerateofreimbursement);
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
    }

    public string binddatamonthstofrddetailseergycosumed(TextBox txt_grddateoffillingindic_org1, DropDownList ddl_grdedingyear_org1,
       TextBox txt_grdmonthyear1_org1, TextBox txt_grdmonthyear2_org1, TextBox txt_grdmonthyear3_org1, TextBox txt_grdmonthyear4_org1,
       TextBox txt_grdmonthyear5_org1, TextBox txt_grdmonthyear6_org1, TextBox txt_grd_halfyear_org1, TextBox txt_grdyear_org1)
    {
        string ErrorMsg = "";
        int slno = 1;
        DateTime grddateoffillingindic; string grdedingyear = ""; string grdmonthyear1 = "";
        string grdmonthyear2 = ""; string grdmonthyear3 = ""; string grdmonthyear4 = "";
        string grdmonthyear5 = ""; string grdmonthyear6 = "";


        //if (!string.IsNullOrEmpty(txt_grddateoffillingindic_org1.Text))
        //{
        //if (valid_isdatetime(Convert.ToString(txt_grddateoffillingindic_org1.Text)) == false)
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Date of filling in DIC\\n";
        //    slno = slno + 1;
        //}
        //else
        //{
        //    //// Convert a null string.  
        //    //string dateString = null;
        //    //CultureInfo provider = CultureInfo.InvariantCulture;
        //    //// It throws Argument null exception  
        //    //DateTime dateTime10 = DateTime.ParseExact(dateString, "mm/dd/yyyy", provider);

        //    string use = Convert.ToString(txt_grddateoffillingindic_org1.Text);
        //    string[] arg = new string[3];
        //    arg = use.Split('/');
        //    grddateoffillingindic = Convert.ToDateTime(arg[1] + "/" + arg[0] + "/" + arg[2]);

        //    //CultureInfo provider = CultureInfo.InvariantCulture;
        //    //grddateoffillingindic = DateTime.ParseExact(txt_grddateoffillingindic_org1.Text, "MM/dd/yyyy", provider); 
        //    DateTime sixmonthsbackdate = DateTime.Now.AddMonths(-7);
        //    if (grddateoffillingindic > sixmonthsbackdate.Date)
        //    {
        //        ErrorMsg = ErrorMsg + slno + ". Please Enter  Date of filling in DIC should should be less than six month from current month\\n";
        //        slno = slno + 1;
        //    }
        //    else
        //    {
        //        if (!string.IsNullOrEmpty(ddl_grdedingyear_org1.SelectedValue)
        //            && ddl_grdedingyear_org1.SelectedValue != "0" && ddl_grdedingyear_org1.SelectedValue != " ")
        //        {
        //            //DateTime date = new DateTime(year, month, day);
        //            // to get the Abbreviated month name
        //            //  string month_name = date.ToString("MMM");
        //            //// to get the full month name 
        //            //string month_name = date.ToString("MMMM");
        //            DateTime firstdate = DateTime.Now;
        //            if (ddl_grdedingyear_org1.SelectedValue == "1")
        //            {

        //                grdmonthyear1 = getFullName(1, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear2 = getFullName(2, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear3 = getFullName(3, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear4 = getFullName(4, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear5 = getFullName(5, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear6 = getFullName(6, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                // grdhalfyeardate = Convert.ToDateTime((grddateoffillingindic.Year - 1), 6, 1).AddMonths(1).AddDays(-1));
        //                //DateTime d = new DateTime(yr, mn, dt);
        //                //DateTime firstdate = new DateTime((grddateoffillingindic.Year - 1), 6, 1);
        //                firstdate = new DateTime((grddateoffillingindic.Year - 1), 6, 1);
        //                //grdhalfyeardate =firstdate.AddMonths(1).AddDays(-1);
        //                //grdhalfyeardate = DateTime.DaysInMonth(1980, 08);
        //            }
        //            else if (ddl_grdedingyear_org1.SelectedValue == "2")
        //            {
        //                grdmonthyear1 = getFullName(7, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear2 = getFullName(8, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear3 = getFullName(9, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear4 = getFullName(10, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear5 = getFullName(11, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                grdmonthyear6 = getFullName(12, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
        //                //grdhalfyeardate = Convert.ToDateTime((grddateoffillingindic.Year - 1), 2, 1).AddMonths(1).AddDays(-1));
        //                //DateTime firstdate = new DateTime((grddateoffillingindic.Year - 1),12, 1);
        //                //grdhalfyeardate = firstdate.AddMonths(1).AddDays(-1);
        //            }

        //            DateTime grdhalfyeardate = firstdate.AddMonths(1).AddDays(-1);
        //            txt_grd_halfyear_org1.Text = Convert.ToString(grdhalfyeardate);
        //            //
        //            grdedingyear = Convert.ToString(grddateoffillingindic.Year - 1);
        //            txt_grdyear_org1.Text = grdedingyear;

        //            txt_grdmonthyear1_org1.Text = grdmonthyear1;
        //            txt_grdmonthyear2_org1.Text = grdmonthyear2;
        //            txt_grdmonthyear3_org1.Text = grdmonthyear3;
        //            txt_grdmonthyear4_org1.Text = grdmonthyear4;
        //            txt_grdmonthyear5_org1.Text = grdmonthyear5;
        //            txt_grdmonthyear6_org1.Text = grdmonthyear6;


        //        }
        //        else
        //        {
        //            ErrorMsg = ErrorMsg + slno + ". Please Enter select 1st or 2 nd half of the year Ending date of\\n";
        //            slno = slno + 1;
        //        }
        //        // }
        //    }
        //}
        //}
        //else
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Date of filling in DIC\\n";
        //    slno = slno + 1;
        //}

        return ErrorMsg;
    }


    //public string binddatamonthstofrddetailseergycosumed(TextBox txt_grddateoffillingindic_org1, DropDownList ddl_grdedingyear_org1,
    //    TextBox txt_grdmonthyear1_org1, TextBox txt_grdmonthyear2_org1, TextBox txt_grdmonthyear3_org1, TextBox txt_grdmonthyear4_org1, 
    //    TextBox txt_grdmonthyear5_org1, TextBox txt_grdmonthyear6_org1, TextBox txt_grd_halfyear_org1, TextBox txt_grdyear_org1,
    //    TextBox txt_grdyear1rateperunit_org1,TextBox txt_grdyear2rateperunit_org1,TextBox txt_grdyear3rateperunit_org1,
    //    TextBox txt_grdyear4rateperunit_org1,TextBox txt_grdyear5rateperunit_org1,TextBox txt_grdyear6rateperunit_org1,
    //TextBox txt_grdyear1basefixedunitspermonth_org1,TextBox txt_grdyear2basefixedunitspermonth_org1,TextBox txt_grdyear3basefixedunitspermonth_org1,
    //TextBox txt_grdyear4basefixedunitspermonth_org1,TextBox txt_grdyear5basefixedunitspermonth_org1,TextBox txt_grdyear6basefixedunitspermonth_org1,
    //TextBox txt_grdyear1eligiblerateofreimbursement_org1,TextBox txt_grdyear2eligiblerateofreimbursement_org1,
    //TextBox txt_grdyear3eligiblerateofreimbursement_org1,TextBox txt_grdyear4eligiblerateofreimbursement_org1,
    //TextBox txt_grdyear5eligiblerateofreimbursement_org1,TextBox txt_grdyear6eligiblerateofreimbursement_org1)
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;
    //    DateTime grddateoffillingindic; string grdedingyear = ""; string grdmonthyear1 = "";
    //    string grdmonthyear2 = ""; string grdmonthyear3 = ""; string grdmonthyear4 = "";
    //    string grdmonthyear5 = ""; string grdmonthyear6 = "";
    //    double powerTrafiffperUnit = 0; double eligiblrrateforreimbursement=0;
    //    int basepowerconsumptionfixedpermonth = 0;

    //    //check text box is null or not,if null display 0
    //    //check text box is integer or not
    //    //Date of filling in DIC shouldbe after 6month
    //    if (!string.IsNullOrEmpty(txt_basepowerconsumptionfixedpermonth.Text))
    //    {
    //        if (valid_isnumeric(Convert.ToString(txt_basepowerconsumptionfixedpermonth.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Base Power Consumption fixed per Month\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            basepowerconsumptionfixedpermonth = Convert.ToInt32(txt_basepowerconsumptionfixedpermonth.Text);
    //        }
    //    }
    //    if (!string.IsNullOrEmpty(ddl_scheme.SelectedValue))
    //    {
    //        if (ddl_scheme.SelectedIndex <= 0)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter select Scheme\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            powerTrafiffperUnit = Convert.ToDouble(ddl_scheme.SelectedValue);
    //        }
    //    }

    //    // powerTrafiffperUnit = 3.25;
    //    eligiblrrateforreimbursement = 1;
    //    if (!string.IsNullOrEmpty(txt_grddateoffillingindic_org1.Text))
    //    {
    //        if (valid_isdatetime(Convert.ToString(txt_grddateoffillingindic_org1.Text)) == false)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of filling in DIC\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            //// Convert a null string.  
    //            //string dateString = null;
    //            //CultureInfo provider = CultureInfo.InvariantCulture;
    //            //// It throws Argument null exception  
    //            //DateTime dateTime10 = DateTime.ParseExact(dateString, "mm/dd/yyyy", provider);

    //            string use = Convert.ToString(txt_grddateoffillingindic_org1.Text);
    //            string[] arg = new string[3];
    //            arg = use.Split('/');
    //            grddateoffillingindic = Convert.ToDateTime(arg[1] + "/" + arg[0] + "/" + arg[2]);

    //            //CultureInfo provider = CultureInfo.InvariantCulture;
    //            //grddateoffillingindic = DateTime.ParseExact(txt_grddateoffillingindic_org1.Text, "MM/dd/yyyy", provider); 
    //            DateTime sixmonthsbackdate = DateTime.Now.AddMonths(-7);
    //            if (grddateoffillingindic > sixmonthsbackdate.Date)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter  Date of filling in DIC should should be less than six month from current month\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                if (!string.IsNullOrEmpty(ddl_grdedingyear_org1.SelectedValue)
    //                    && ddl_grdedingyear_org1.SelectedValue != "0" && ddl_grdedingyear_org1.SelectedValue != " ")
    //                {
    //                    //DateTime date = new DateTime(year, month, day);
    //                    // to get the Abbreviated month name
    //                    //  string month_name = date.ToString("MMM");
    //                    //// to get the full month name 
    //                    //string month_name = date.ToString("MMMM");
    //                    DateTime firstdate=DateTime.Now;
    //                    if (ddl_grdedingyear_org1.SelectedValue == "1")
    //                    {

    //                        grdmonthyear1 = getFullName(1, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear2 = getFullName(2, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear3 = getFullName(3, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear4 = getFullName(4, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear5 = getFullName(5, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear6 = getFullName(6, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        // grdhalfyeardate = Convert.ToDateTime((grddateoffillingindic.Year - 1), 6, 1).AddMonths(1).AddDays(-1));
    //                        //DateTime d = new DateTime(yr, mn, dt);
    //                        //DateTime firstdate = new DateTime((grddateoffillingindic.Year - 1), 6, 1);
    //                        firstdate = new DateTime((grddateoffillingindic.Year - 1), 6, 1);
    //                        //grdhalfyeardate =firstdate.AddMonths(1).AddDays(-1);
    //                        //grdhalfyeardate = DateTime.DaysInMonth(1980, 08);
    //                    }
    //                    else if (ddl_grdedingyear_org1.SelectedValue == "2")
    //                    {
    //                        grdmonthyear1 = getFullName(7, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear2 = getFullName(8, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear3 = getFullName(9, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear4 = getFullName(10, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear5 = getFullName(11, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        grdmonthyear6 = getFullName(12, (grddateoffillingindic.Year - 1)) + "-" + (grddateoffillingindic.Year - 1);
    //                        //grdhalfyeardate = Convert.ToDateTime((grddateoffillingindic.Year - 1), 2, 1).AddMonths(1).AddDays(-1));
    //                        //DateTime firstdate = new DateTime((grddateoffillingindic.Year - 1),12, 1);
    //                        //grdhalfyeardate = firstdate.AddMonths(1).AddDays(-1);
    //                    }

    //                    DateTime grdhalfyeardate = firstdate.AddMonths(1).AddDays(-1);
    //                    txt_grd_halfyear_org1.Text = Convert.ToString(grdhalfyeardate);

    //                    grdedingyear = Convert.ToString(grddateoffillingindic.Year - 1);
    //                    txt_grdyear_org1.Text = grdedingyear;

    //                    txt_grdmonthyear1_org1.Text = grdmonthyear1;
    //                    txt_grdmonthyear2_org1.Text = grdmonthyear2;
    //                    txt_grdmonthyear3_org1.Text = grdmonthyear3;
    //                    txt_grdmonthyear4_org1.Text = grdmonthyear4;
    //                    txt_grdmonthyear5_org1.Text = grdmonthyear5;
    //                    txt_grdmonthyear6_org1.Text = grdmonthyear6;


    //                }
    //                else
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter select 1st or 2 nd half of the year Ending date of\\n";
    //                    slno = slno + 1;
    //                }
    //                // }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Date of filling in DIC\\n";
    //        slno = slno + 1;
    //    }


    //    if(powerTrafiffperUnit<=0)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter select Scheme\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //        txt_grdyear1rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //        txt_grdyear2rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //        txt_grdyear3rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //        txt_grdyear4rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //        txt_grdyear5rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //        txt_grdyear6rateperunit_org1.Text = Convert.ToString(powerTrafiffperUnit);
    //    }
    //    if(eligiblrrateforreimbursement<=0)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter select eligible rate for reimbursement\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //         txt_grdyear1eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //        txt_grdyear2eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //        txt_grdyear3eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //        txt_grdyear4eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //        txt_grdyear5eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //        txt_grdyear6eligiblerateofreimbursement_org1.Text = Convert.ToString(eligiblrrateforreimbursement);
    //    }

    //    if (basepowerconsumptionfixedpermonth <= 0)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Base Power Consumption fixed per Month\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //         txt_grdyear1basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth);
    //        txt_grdyear2basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth);
    //        txt_grdyear3basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth);
    //        txt_grdyear4basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth); ;
    //        txt_grdyear5basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth) ;
    //        txt_grdyear6basefixedunitspermonth_org1.Text = Convert.ToString(basepowerconsumptionfixedpermonth);
    //    }

    //    return ErrorMsg;
    //}

    #endregion

    #region eachgridrowcalculation

    protected void txt_grdyear1unitsconsumed_TextChanged(object sender, EventArgs e)
    {
        //string errormsg = gridvaluestotal();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}

    }
    //public string gridvaluestotal()
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;

    //    double grdfootertotunitsconsumed = 0; double grdyfootertotrateperunit = 0; double grdfootertotamountpaid = 0;
    //    double grdfootertotbasefixedunitspermonth = 0; double grdfootertoteligibleunits = 0;
    //    double grdfootertoteligiblerateofreimbursement = 0; double grdyfootereligibleamountforreimbursement = 0;
    //    double grdyfooterbelatedeligibleamountforreimbursement = 0;


    //    for (int i = 0; i < grd_calimsdetails.Rows.Count; i++)
    //    {


    //        double grdyear1unitsconsumed = 0; double grdyear1eligibleunits = 0; double grdyear1amountpaid = 0;
    //        double grdyear1eligiblerateofreimbursement = 0; double grdyear1eligibleamountforreimbursement = 0;
    //        double grdyear1basefixedunitspermonth = 0;
    //        double grdyear2unitsconsumed = 0; double grdyear2eligibleunits = 0; double grdyear2amountpaid = 0;
    //        double grdyear2eligiblerateofreimbursement = 0; double grdyear2eligibleamountforreimbursement = 0;
    //        double grdyear2basefixedunitspermonth = 0;
    //        double grdyear3unitsconsumed = 0; double grdyear3eligibleunits = 0; double grdyear3amountpaid = 0;
    //        double grdyear3eligiblerateofreimbursement = 0; double grdyear3eligibleamountforreimbursement = 0;
    //        double grdyear3basefixedunitspermonth = 0;
    //        double grdyear4unitsconsumed = 0; double grdyear4eligibleunits = 0; double grdyear4amountpaid = 0;
    //        double grdyear4eligiblerateofreimbursement = 0; double grdyear4eligibleamountforreimbursement = 0;
    //        double grdyear4basefixedunitspermonth = 0;
    //        double grdyear5unitsconsumed = 0; double grdyear5eligibleunits = 0; double grdyear5amountpaid = 0;
    //        double grdyear5eligiblerateofreimbursement = 0; double grdyear5eligibleamountforreimbursement = 0;
    //        double grdyear5basefixedunitspermonth = 0;
    //        double grdyear6unitsconsumed = 0; double grdyear6eligibleunits = 0; double grdyear6amountpaid = 0;
    //        double grdyear6eligiblerateofreimbursement = 0; double grdyear6eligibleamountforreimbursement = 0;
    //        double grdyear6basefixedunitspermonth = 0;
    //        double grdtoteligibleamount = 0; double grdtoteligibleamountbelated = 0;


    //        TextBox txt_grddateoffillingindic = grd_calimsdetails.Rows[i].FindControl("txt_grddateoffillingindic") as TextBox;
    //        DropDownList ddl_grdedingyear = grd_calimsdetails.Rows[i].FindControl("ddl_grdedingyear") as DropDownList;
    //        TextBox txt_grd_halfyear = grd_calimsdetails.Rows[i].FindControl("txt_grd_halfyear") as TextBox;
    //        TextBox txt_grdyear = grd_calimsdetails.Rows[i].FindControl("txt_grdyear") as TextBox;
    //        TextBox txt_grdmonthyear1 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear1") as TextBox;
    //        TextBox txt_grdyear1unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1unitsconsumed") as TextBox;
    //        TextBox txt_grdyear1rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1rateperunit") as TextBox;
    //        TextBox txt_grdyear1amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1amountpaid") as TextBox;
    //        TextBox txt_grdyear1basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear1eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleunits") as TextBox;
    //        TextBox txt_grdyear1eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear1eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleamountforreimbursement") as TextBox;


    //        TextBox txt_grdmonthyear2 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear2") as TextBox;
    //        TextBox txt_grdyear2unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2unitsconsumed") as TextBox;
    //        TextBox txt_grdyear2rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2rateperunit") as TextBox;
    //        TextBox txt_grdyear2amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2amountpaid") as TextBox;
    //        TextBox txt_grdyear2basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear2eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleunits") as TextBox;
    //        TextBox txt_grdyear2eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear2eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleamountforreimbursement") as TextBox;

    //        TextBox txt_grdmonthyear3 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear3") as TextBox;
    //        TextBox txt_grdyear3unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3unitsconsumed") as TextBox;
    //        TextBox txt_grdyear3rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3rateperunit") as TextBox;
    //        TextBox txt_grdyear3amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3amountpaid") as TextBox;
    //        TextBox txt_grdyear3basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear3eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleunits") as TextBox;
    //        TextBox txt_grdyear3eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear3eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleamountforreimbursement") as TextBox;


    //        TextBox txt_grdmonthyear4 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear4") as TextBox;
    //        TextBox txt_grdyear4unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4unitsconsumed") as TextBox;
    //        TextBox txt_grdyear4rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4rateperunit") as TextBox;
    //        TextBox txt_grdyear4amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4amountpaid") as TextBox;
    //        TextBox txt_grdyear4basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear4eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleunits") as TextBox;
    //        TextBox txt_grdyear4eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear4eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleamountforreimbursement") as TextBox;

    //        TextBox txt_grdmonthyear5 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear5") as TextBox;
    //        TextBox txt_grdyear5unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5unitsconsumed") as TextBox;
    //        TextBox txt_grdyear5rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5rateperunit") as TextBox;
    //        TextBox txt_grdyear5amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5amountpaid") as TextBox;
    //        TextBox txt_grdyear5basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear5eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleunits") as TextBox;
    //        TextBox txt_grdyear5eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear5eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleamountforreimbursement") as TextBox;

    //        TextBox txt_grdmonthyear6 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear6") as TextBox;
    //        TextBox txt_grdyear6unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6unitsconsumed") as TextBox;
    //        TextBox txt_grdyear6rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6rateperunit") as TextBox;
    //        TextBox txt_grdyear6amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6amountpaid") as TextBox;
    //        TextBox txt_grdyear6basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6basefixedunitspermonth") as TextBox;
    //        TextBox txt_grdyear6eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleunits") as TextBox;
    //        TextBox txt_grdyear6eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligiblerateofreimbursement") as TextBox;
    //        TextBox txt_grdyear6eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleamountforreimbursement") as TextBox;
    //        TextBox lbl_grdtoteligibleamount = grd_calimsdetails.Rows[i].FindControl("lbl_grdtoteligibleamount") as TextBox;
    //        RadioButtonList rbtgrd_isbelated = grd_calimsdetails.Rows[i].FindControl("rbtgrd_isbelated") as RadioButtonList;
    //        TextBox txt_belatedamount = grd_calimsdetails.Rows[i].FindControl("txt_belatedamount") as TextBox;

    //        ////check text box is null or not,if null display 0
    //        ////check text box is integer or not
    //        if (!string.IsNullOrEmpty(txt_grdyear1unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Units Consumedin Nos. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1unitsconsumed = Convert.ToDouble(txt_grdyear1unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Eligible Units i.e over & above Base \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1eligibleunits = Convert.ToDouble(txt_grdyear1eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter  Numeric Month1 Eligible Rate for Reimbursement per units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear1eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Eligible amount for Reiembursement in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear1eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1amountpaid = Convert.ToInt32(txt_grdyear1amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Base fixed per month in units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear1basefixedunitspermonth = Convert.ToDouble(txt_grdyear1basefixedunitspermonth.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear1rateperunit.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1rateperunit.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Rate per Units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyfootertotrateperunit = Convert.ToDouble(txt_grdyear1rateperunit.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear1eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear1eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month1 Eligible Rate for Reimbursement per units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdfootertoteligiblerateofreimbursement = Convert.ToDouble(txt_grdyear1eligiblerateofreimbursement.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear2unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Units Consumedin Nos.\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2unitsconsumed = Convert.ToDouble(txt_grdyear2unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear2eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Eligible Units i.e over & above Base\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2eligibleunits = Convert.ToDouble(txt_grdyear2eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear2eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Eligible Rate for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear2eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear2eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Eligible Amount for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear2eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear2amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2amountpaid = Convert.ToDouble(txt_grdyear2amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear2basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear2basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month2 Base fixed per month in units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear2basefixedunitspermonth = Convert.ToDouble(txt_grdyear2basefixedunitspermonth.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear3unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Units Consumedin Nos.\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3unitsconsumed = Convert.ToDouble(txt_grdyear3unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear3eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Eligible Units i.e over & above Base\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3eligibleunits = Convert.ToDouble(txt_grdyear3eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear3eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Eligible Rate for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear3eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear3eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Eligible Amount for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear3eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear3amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3amountpaid = Convert.ToDouble(txt_grdyear3amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear3basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear3basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month3 Base fixed per month in units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear3basefixedunitspermonth = Convert.ToDouble(txt_grdyear3basefixedunitspermonth.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear4unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month4 Units Consumedin Nos.\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4unitsconsumed = Convert.ToDouble(txt_grdyear4unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear4eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month4 Eligible Units i.e over & above Base\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4eligibleunits = Convert.ToDouble(txt_grdyear4eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear4eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month4 Eligible Rate for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear4eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear4eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month4 Eligible Amount for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear4eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear4amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter  Numeric Month4 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4amountpaid = Convert.ToDouble(txt_grdyear4amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear4basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear4basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter  Numeric Month4 Base fixed per month in units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear4basefixedunitspermonth = Convert.ToDouble(txt_grdyear4basefixedunitspermonth.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear5unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Units Consumedin Nos.\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5unitsconsumed = Convert.ToDouble(txt_grdyear5unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear5eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Eligible Units i.e over & above Base\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5eligibleunits = Convert.ToDouble(txt_grdyear5eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear5eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Eligible Rate for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear5eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear5eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Eligible Amount for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear5eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear5amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5amountpaid = Convert.ToDouble(txt_grdyear5amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear5basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear5basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month5 Base fixed per month in units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear5basefixedunitspermonth = Convert.ToDouble(txt_grdyear5basefixedunitspermonth.Text);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(txt_grdyear6unitsconsumed.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6unitsconsumed.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month6 Units Consumedin Nos.\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6unitsconsumed = Convert.ToDouble(txt_grdyear6unitsconsumed.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear6eligibleunits.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6eligibleunits.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month6 Eligible Units i.e over & above Base\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6eligibleunits = Convert.ToDouble(txt_grdyear6eligibleunits.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear6eligibleamountforreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6eligibleamountforreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month6 Eligible Amount for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6eligibleamountforreimbursement = Convert.ToDouble(txt_grdyear6eligibleamountforreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear6eligiblerateofreimbursement.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6eligiblerateofreimbursement.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month6 Eligible Rate for Reimbursement per units\\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6eligiblerateofreimbursement = Convert.ToDouble(txt_grdyear6eligiblerateofreimbursement.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear6amountpaid.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6amountpaid.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter  Numeric Month6 Amount Paid as per Bill in Rs. \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6amountpaid = Convert.ToDouble(txt_grdyear6amountpaid.Text);
    //            }
    //        }
    //        if (!string.IsNullOrEmpty(txt_grdyear6basefixedunitspermonth.Text))
    //        {
    //            if (valid_isdouble(Convert.ToString(txt_grdyear6basefixedunitspermonth.Text)) == false)
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Numeric Month6 Base fixed per month in units \\n";
    //                slno = slno + 1;
    //            }
    //            else
    //            {
    //                grdyear6basefixedunitspermonth = Convert.ToDouble(txt_grdyear6basefixedunitspermonth.Text);
    //            }
    //        }


    //        grdyear1eligibleunits = grdyear1unitsconsumed;
    //        grdyear2eligibleunits = grdyear2unitsconsumed;
    //        grdyear3eligibleunits = grdyear3unitsconsumed;
    //        grdyear4eligibleunits = grdyear4unitsconsumed;
    //        grdyear5eligibleunits = grdyear5unitsconsumed;
    //        grdyear6eligibleunits = grdyear6unitsconsumed;

    //        txt_grdyear1eligibleunits.Text = Convert.ToString(grdyear1eligibleunits);
    //        txt_grdyear2eligibleunits.Text = Convert.ToString(grdyear2eligibleunits);
    //        txt_grdyear3eligibleunits.Text = Convert.ToString(grdyear3eligibleunits);
    //        txt_grdyear4eligibleunits.Text = Convert.ToString(grdyear4eligibleunits);
    //        txt_grdyear5eligibleunits.Text = Convert.ToString(grdyear5eligibleunits);
    //        txt_grdyear6eligibleunits.Text = Convert.ToString(grdyear6eligibleunits);


    //        grdyear1eligibleamountforreimbursement = grdyear1unitsconsumed * grdyear1eligiblerateofreimbursement;
    //        grdyear2eligibleamountforreimbursement = grdyear2unitsconsumed * grdyear2eligiblerateofreimbursement;
    //        grdyear3eligibleamountforreimbursement = grdyear3unitsconsumed * grdyear3eligiblerateofreimbursement;
    //        grdyear4eligibleamountforreimbursement = grdyear4unitsconsumed * grdyear4eligiblerateofreimbursement;
    //        grdyear5eligibleamountforreimbursement = grdyear5unitsconsumed * grdyear5eligiblerateofreimbursement;
    //        grdyear6eligibleamountforreimbursement = grdyear6unitsconsumed * grdyear6eligiblerateofreimbursement;

    //        txt_grdyear1eligibleamountforreimbursement.Text = Convert.ToString(grdyear1eligibleamountforreimbursement);
    //        txt_grdyear2eligibleamountforreimbursement.Text = Convert.ToString(grdyear2eligibleamountforreimbursement);
    //        txt_grdyear3eligibleamountforreimbursement.Text = Convert.ToString(grdyear3eligibleamountforreimbursement);
    //        txt_grdyear4eligibleamountforreimbursement.Text = Convert.ToString(grdyear4eligibleamountforreimbursement);
    //        txt_grdyear5eligibleamountforreimbursement.Text = Convert.ToString(grdyear5eligibleamountforreimbursement);
    //        txt_grdyear6eligibleamountforreimbursement.Text = Convert.ToString(grdyear6eligibleamountforreimbursement);

    //        grdtoteligibleamount = grdyear1eligibleamountforreimbursement + grdyear2eligibleamountforreimbursement + grdyear3eligibleamountforreimbursement + grdyear4eligibleamountforreimbursement + grdyear5eligibleamountforreimbursement + grdyear6eligibleamountforreimbursement;
    //        lbl_grdtoteligibleamount.Text = Convert.ToString(grdtoteligibleamount);
    //        if (rbtgrd_isbelated.SelectedValue == "Y")
    //        {
    //            if (grdtoteligibleamount > 0)
    //            {
    //                grdtoteligibleamountbelated = grdtoteligibleamount / 2;
    //            }
    //        }

    //        txt_belatedamount.Text = Convert.ToString(grdtoteligibleamountbelated);

    //        grdfootertotunitsconsumed = grdfootertotunitsconsumed + (grdyear1unitsconsumed + grdyear2unitsconsumed + grdyear3unitsconsumed + grdyear4unitsconsumed + grdyear5unitsconsumed + grdyear6unitsconsumed);
    //        grdfootertotamountpaid = grdfootertotamountpaid + (grdyear1amountpaid + grdyear2amountpaid + grdyear3amountpaid + grdyear4amountpaid + grdyear5amountpaid + grdyear6amountpaid);
    //        grdfootertotbasefixedunitspermonth = grdfootertotbasefixedunitspermonth + (grdyear1basefixedunitspermonth + grdyear2basefixedunitspermonth + grdyear3basefixedunitspermonth + grdyear4basefixedunitspermonth + grdyear5basefixedunitspermonth + grdyear6basefixedunitspermonth);
    //        grdfootertoteligibleunits = grdfootertoteligibleunits + (grdyear1eligibleunits + grdyear2eligibleunits + grdyear3eligibleunits + grdyear4eligibleunits + grdyear5eligibleunits + grdyear6eligibleunits);
    //        grdyfootereligibleamountforreimbursement = grdyfootereligibleamountforreimbursement + grdtoteligibleamount;
    //        grdyfooterbelatedeligibleamountforreimbursement = grdyfooterbelatedeligibleamountforreimbursement + grdtoteligibleamountbelated;

    //    }


    //    txt_grdfootertotunitsconsumed.Text = Convert.ToString(grdfootertotunitsconsumed);
    //    txt_grdyfootertotrateperunit.Text = Convert.ToString(grdyfootertotrateperunit);
    //    txt_grdfootertotamountpaid.Text = Convert.ToString(grdfootertotamountpaid);
    //    txt_grdfootertotbasefixedunitspermonth.Text = Convert.ToString(grdfootertotbasefixedunitspermonth);
    //    txt_grdfootertoteligibleunits.Text = Convert.ToString(grdfootertoteligibleunits);
    //    txt_grdfootertoteligiblerateofreimbursement.Text = Convert.ToString(grdfootertoteligiblerateofreimbursement);
    //    txt_grdyfootereligibleamountforreimbursement.Text = Convert.ToString(grdyfootereligibleamountforreimbursement);
    //    txt_grdyfooterbelatedeligibleamountforreimbursement.Text = Convert.ToString(grdyfooterbelatedeligibleamountforreimbursement);
    //    return ErrorMsg;
    //}


    #endregion


    #region validations
    public static bool valid_isnumeric(string Numericvalue)
    {
        bool Isnumeric = true;
        int Value;
        if (!int.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isnumeric = false;
        }
        else
        {
            //if (Value <= 0)
            //{
            //    Isnumeric = false;
            //}
        }
        return Isnumeric;
    }
    public static bool valid_isdecimal(string Numericvalue)
    {
        bool Isdecimal = true;
        decimal Value;
        if (!decimal.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isdecimal = false;
        }
        else
        {
            if (Value <= 0)
            {
                Isdecimal = false;
            }
        }
        return Isdecimal;
    }
    //public static bool valid_isdatetime(string datetimevalue)
    //{
    //    bool Isdatetime = false;
    //    DateTime Value;
    //    DateTimeStyles styles = DateTimeStyles.None;
    //    //DateTime startDate;
    //    foreach (CultureInfo cInfo in CultureInfo.GetCultures(CultureTypes.AllCultures))
    //    {
    //        if (DateTime.TryParse(datetimevalue, cInfo, styles, out Value))
    //        {
    //            Isdatetime = true;
    //        }
    //    }

    //    //if (!DateTime.TryParse(Convert.ToString(datetimevalue), out Value))
    //    //{
    //    //    Isdatetime = false;
    //    //}
    //    //else
    //    //{
    //    //    //if (Value <= 0)
    //    //    //{
    //    //    //    Isdatetime = false;
    //    //    //}
    //    //}
    //    //if (DateTime.TryParseExact(datetimevalue, "dd'.'MM'.'yyyy",
    //    //                   CultureInfo.InvariantCulture,
    //    //                   DateTimeStyles.None,
    //    //                   out Value))
    //    //{
    //    //    // Success
    //    //}
    //    //else
    //    //{
    //    //    // Parse failed
    //    //}

    //    return Isdatetime;
    //}
    public static bool valid_isdouble(string Numericvalue)
    {
        bool Isdouble = true;
        double Value;
        if (!double.TryParse(Convert.ToString(Numericvalue), out Value))
        {
            Isdouble = false;
        }
        else
        {
            if (Value <= 0)
            {
                Isdouble = false;
            }
        }
        return Isdouble;
    }


    //DateTime nextMonth = DateTime.Now.AddDays(1).AddMonths(1).AddDays(-1);
    //public static DateTime NextMonth(this DateTime date)
    //{
    //    if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
    //        return date.AddMonths(1);
    //    else
    //        return date.AddDays(1).AddMonths(1).AddDays(-1);
    //}
    // function to get the full month name
    public static string getFullName(int month, int year)
    {
        DateTime date = new DateTime(year, month, 1);
        return date.ToString("MMMM");
    }


    #endregion



    #region

    //public string validationsubmit()
    //{
    //    string ErrorMsg = "";
    //    int slno = 1;



    //    if (string.IsNullOrEmpty(txt_filenodateingmoffice.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter File No. in GM office\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_dateingm.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Date in GM office\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_fileheadoffice.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter File No.in Head office\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_Eligible.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_invstsubfileno.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter INVST_SUB File No\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_nameofunit.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Unit\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_addressoftheunit.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Address of the Unit\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_Constitutionoftheindustry.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Constitution of the industry\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_SocialStatus.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Social Status\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_nameofthepropmd.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the PROP/PARTNR/MD\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(ddl_scheme.SelectedItem.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Scheme\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(ddl_scheme.SelectedValue))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Scheme\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_ssiregniemilno.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter SSI Regn./IEM/IL No\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_date.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Date\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_lineofactivity.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Line of Activity\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_units.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter UNITS\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_capacity.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter CAPACITY\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(ddlAppliedFor.SelectedItem.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter New/Expansion/Diversification\\n";
    //        slno = slno + 1;
    //    }

    //    if (string.IsNullOrEmpty(ddlAppliedFor.SelectedValue))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter New/Expansion/Diversification\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //        if (ddlAppliedFor.SelectedValue == "2")
    //        {
    //            if (string.IsNullOrEmpty(txt_finacialyear1.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-I\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin1unitsutilised.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-I No of Units Utilised\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin1rateperunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-I Rate Per Unit\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin1totalpaidbytheunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-I Total Paid by the unit in Rs.\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_finacialyear2.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-II \\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin2unitsutilised.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-II No of Units Utilised\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin2rateperunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-II Rate Per Unit\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin2totalpaidbytheunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-II Total Paid by the unit in Rs.\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_finacialyear3.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-III \\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin3unitsutilised.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-III No of Units Utilised\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin3rateperunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-III Rate Per Unit\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_fin3totalpaidbytheunit.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Finacial Year-III Total Paid by the unit in Rs.\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_yearpriorem.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Year Prior EM\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_totunitsconsumedpriorto3years.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Units Consumed prior to 3 Years\\n";
    //                slno = slno + 1;
    //            }
    //            if (string.IsNullOrEmpty(txt_averageunitsem.Text))
    //            {
    //                ErrorMsg = ErrorMsg + slno + ". Please Enter Average Units EM\\n";
    //                slno = slno + 1;
    //            }

    //        }
    //    }

    //    if (string.IsNullOrEmpty(txt_DateofCommensementofProdn.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Commensement of Prodn\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_NameofFinancingInstitution.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Financing Institution\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(lbl_fixedland.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter LAND\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_landapprovedprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter LAND Approved Project Cost for Investment\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_landexistingprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter LAND Investment of the Existing Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_landnewexpansionprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter LAND Investment of the New / Expasion / Diversification Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(lbl_fixedbuilding.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Building\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_buildingapprovedprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Building Approved Project Cost for Investment\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_buildingexistingprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Building Investment of the Existing Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_buildingnewexpansionprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Building Investment of the New / Expasion / Diversification Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(lbl_plantmc.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & M/C\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_plantmcapprovedprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & M/C Approved Project Cost for Investment\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_plantmcexistingprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & M/C Investment of the Existing Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_plantmcnewexpansionprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & M/C Investment of the New / Expasion / Diversification Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_totalapprovedprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Approved Project Cost for Investment\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_totalexistingprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Investment of the Existing Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_totalmcnewexpansionprojectcost.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Investment of the New / Expasion / Diversification Project\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_installcapapriorofed.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Installed Capacity Prior of E/D\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_installcapundered.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Installed Capacity Under E/D\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_increinveundered.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter % Increased Investment UnderE/D\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_increcapacityindered.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter % Increased Capacity Under E/D\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_existingpowerinhp.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Power in H.P\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_newpowerconnection.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter New Power Connection(In KVA)\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_dateofnewcon.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Date of New Con.Released\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_serviceconnectionno.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Service Connectio No\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_installcapacityem.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Install Capacity EM\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_75perproduction.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter 75 %  of the Production\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_75peruitsproduction.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Units as per 75 % Production\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_basepowerconsumptionfixedperyear.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Base Power Consumption fixed per year\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_basepowerconsumptionfixedpermonth.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Base Power Consumption fixed per Month\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_noofclaims.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter No of Claims\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_powerTrafiffperUnit.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Power Trafiff Per Unit\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_eligiblrrateforreimbursement.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Rate for reimbursement per units\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grandtotalamountsayrs.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Say Rs\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grandtotalrecombygmdic.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Recommended by GM,DIC(in RS)\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grandtotaleligibleamountrs.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Amount Rs\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_totremarks.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks\\n";
    //        slno = slno + 1;
    //    }

    //    if (string.IsNullOrEmpty(txt_grdfootertotunitsconsumed.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Units Consumed in Nos. \\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdyfootertotrateperunit.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Rate per Units \\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdfootertotamountpaid.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Amount Paid as per Bill in Rs. \\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdfootertotbasefixedunitspermonth.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Base fixed per month in units\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdfootertoteligibleunits.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Eligible Units i.e over & above Base\\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdfootertoteligiblerateofreimbursement.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Eligible Rate for Reimbursement per units \\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdyfootereligibleamountforreimbursement.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Eligible amount for Reiembursement in Rs. \\n";
    //        slno = slno + 1;
    //    }
    //    if (string.IsNullOrEmpty(txt_grdyfooterbelatedeligibleamountforreimbursement.Text))
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter total Belated Eligible amount for Reiembursement in Rs. \\n";
    //        slno = slno + 1;
    //    }

    //    if (grd_calimsdetails == null)
    //    {
    //        ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //        slno = slno + 1;
    //    }
    //    else
    //    {
    //        if (grd_calimsdetails.Rows.Count <= 0)
    //        {
    //            ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //            slno = slno + 1;
    //        }
    //        else
    //        {
    //            for (int i = 0; i < grd_calimsdetails.Rows.Count; i++)
    //            {
    //                TextBox txt_grddateoffillingindic = grd_calimsdetails.Rows[i].FindControl("txt_grddateoffillingindic") as TextBox;
    //                DropDownList ddl_grdedingyear = grd_calimsdetails.Rows[i].FindControl("ddl_grdedingyear") as DropDownList;
    //                TextBox txt_grd_halfyear = grd_calimsdetails.Rows[i].FindControl("txt_grd_halfyear") as TextBox;
    //                TextBox txt_grdyear = grd_calimsdetails.Rows[i].FindControl("txt_grdyear") as TextBox;
    //                TextBox txt_grdmonthyear1 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear1") as TextBox;
    //                TextBox txt_grdyear1unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1unitsconsumed") as TextBox;
    //                TextBox txt_grdyear1rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1rateperunit") as TextBox;
    //                TextBox txt_grdyear1amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1amountpaid") as TextBox;
    //                TextBox txt_grdyear1basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear1eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleunits") as TextBox;
    //                TextBox txt_grdyear1eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear1eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleamountforreimbursement") as TextBox;


    //                TextBox txt_grdmonthyear2 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear2") as TextBox;
    //                TextBox txt_grdyear2unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2unitsconsumed") as TextBox;
    //                TextBox txt_grdyear2rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2rateperunit") as TextBox;
    //                TextBox txt_grdyear2amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2amountpaid") as TextBox;
    //                TextBox txt_grdyear2basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear2eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleunits") as TextBox;
    //                TextBox txt_grdyear2eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear2eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleamountforreimbursement") as TextBox;

    //                TextBox txt_grdmonthyear3 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear3") as TextBox;
    //                TextBox txt_grdyear3unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3unitsconsumed") as TextBox;
    //                TextBox txt_grdyear3rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3rateperunit") as TextBox;
    //                TextBox txt_grdyear3amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3amountpaid") as TextBox;
    //                TextBox txt_grdyear3basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear3eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleunits") as TextBox;
    //                TextBox txt_grdyear3eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear3eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleamountforreimbursement") as TextBox;


    //                TextBox txt_grdmonthyear4 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear4") as TextBox;
    //                TextBox txt_grdyear4unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4unitsconsumed") as TextBox;
    //                TextBox txt_grdyear4rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4rateperunit") as TextBox;
    //                TextBox txt_grdyear4amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4amountpaid") as TextBox;
    //                TextBox txt_grdyear4basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear4eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleunits") as TextBox;
    //                TextBox txt_grdyear4eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear4eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleamountforreimbursement") as TextBox;

    //                TextBox txt_grdmonthyear5 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear5") as TextBox;
    //                TextBox txt_grdyear5unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5unitsconsumed") as TextBox;
    //                TextBox txt_grdyear5rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5rateperunit") as TextBox;
    //                TextBox txt_grdyear5amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5amountpaid") as TextBox;
    //                TextBox txt_grdyear5basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear5eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleunits") as TextBox;
    //                TextBox txt_grdyear5eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear5eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleamountforreimbursement") as TextBox;

    //                TextBox txt_grdmonthyear6 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear6") as TextBox;
    //                TextBox txt_grdyear6unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6unitsconsumed") as TextBox;
    //                TextBox txt_grdyear6rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6rateperunit") as TextBox;
    //                TextBox txt_grdyear6amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6amountpaid") as TextBox;
    //                TextBox txt_grdyear6basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6basefixedunitspermonth") as TextBox;
    //                TextBox txt_grdyear6eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleunits") as TextBox;
    //                TextBox txt_grdyear6eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligiblerateofreimbursement") as TextBox;
    //                TextBox txt_grdyear6eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleamountforreimbursement") as TextBox;
    //                TextBox lbl_grdtoteligibleamount = grd_calimsdetails.Rows[i].FindControl("lbl_grdtoteligibleamount") as TextBox;
    //                RadioButtonList rbtgrd_isbelated = grd_calimsdetails.Rows[i].FindControl("rbtgrd_isbelated") as RadioButtonList;
    //                TextBox txt_belatedamount = grd_calimsdetails.Rows[i].FindControl("txt_belatedamount") as TextBox;


    //                string ClaimNo = Convert.ToString(i + 1);

    //                if (string.IsNullOrEmpty(txt_grddateoffillingindic.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Date of filling in DIC Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(ddl_grdedingyear.SelectedValue))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Ending date of Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grd_halfyear.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Half Year Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Year Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(lbl_grdtoteligibleamount.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(rbtgrd_isbelated.SelectedValue))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                else
    //                {
    //                    if (rbtgrd_isbelated.SelectedValue == "Y")
    //                    {
    //                        if (string.IsNullOrEmpty(txt_belatedamount.Text))
    //                        {
    //                            ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                            slno = slno + 1;
    //                        }
    //                    }
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear1.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month-year Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Units Consumed in Nos.Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Base fixed per month in units  Claims details" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Eligible Units i.e over & above Base Claims details" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Eligible Rate for Reimbursement per units  Claims details" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear1eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month1 Eligible amount for Reiembursement in Rs.  Claims details" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear2.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month-year Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Units Consumed in Nos. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Base fixed per month in units  Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Eligible Units i.e over & above Base Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month2 Eligible Rate for Reimbursement per units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear2eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter  Month2 Eligible amount for Reiembursement in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear3.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Units Consumed in Nos. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Base fixed per month in units  Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Eligible Units i.e over & above Base Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month3 Eligible Rate for Reimbursement per units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear3eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter  Month3 Eligible amount for Reiembursement in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear4.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Units Consumed in Nos. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Base fixed per month in units  Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Eligible Units i.e over & above Base Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month4 Eligible Rate for Reimbursement per units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear4eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter  Month4 Eligible amount for Reiembursement in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear5.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Units Consumed in Nos. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Base fixed per month in units  Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Eligible Units i.e over & above Base Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month5 Eligible Rate for Reimbursement per units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear5eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter  Month5 Eligible amount for Reiembursement in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdmonthyear6.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Claims details\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6unitsconsumed.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Units Consumed in Nos. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6rateperunit.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Rate per Units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6amountpaid.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Amount Paid as per Bill in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6basefixedunitspermonth.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Base fixed per month in units  Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6eligibleunits.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Eligible Units i.e over & above Base Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6eligiblerateofreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter Month6 Eligible Rate for Reimbursement per units Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //                if (string.IsNullOrEmpty(txt_grdyear6eligibleamountforreimbursement.Text))
    //                {
    //                    ErrorMsg = ErrorMsg + slno + ". Please Enter  Month6 Eligible amount for Reiembursement in Rs. Claims details-" + ClaimNo + "\\n";
    //                    slno = slno + 1;
    //                }
    //            }
    //        }
    //    }
    //    return ErrorMsg;
    //}
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        //string errormsg_grd = gridvaluestotal();
        //if (errormsg_grd.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg_grd + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{
        //    string errormsg = validationsubmit();
        //    if (errormsg.Trim().TrimStart() != "")
        //    {
        //        string message = "alert('" + errormsg + "')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        return;
        //    }
        //    else
        //    {


        //        incpowertariffproperties obj_pro = new incpowertariffproperties();
        //        if (!string.IsNullOrEmpty(hf_incpowrtariffid.Value))
        //        {
        //            obj_pro.incpowrtariffid = Convert.ToInt32(txt_filenodateingmoffice.Text);
        //        }
        //        //obj_pro.constitID = Convert.ToString(txt_filenodateingmoffice.Text);
        //        //obj_pro.IncentiveID = Convert.ToString(txt_filenodateingmoffice.Text);
        //        //obj_pro.socialstatusid = Convert.ToInt32(txt_filenodateingmoffice.Text);
        //        //obj_pro.lineofactivityid = Convert.ToString(txt_filenodateingmoffice.Text);

        //        obj_pro.fileno = Convert.ToString(txt_filenodateingmoffice.Text);
        //        obj_pro.dateingmoffice = Convert.ToDateTime(txt_dateingm.Text);
        //        obj_pro.filenoheadoffice = Convert.ToString(txt_fileheadoffice.Text);
        //        obj_pro.eligibleno = Convert.ToString(txt_Eligible.Text);
        //        obj_pro.invst_subfileno = Convert.ToString(txt_invstsubfileno.Text);
        //        obj_pro.nameoftheunit = Convert.ToString(txt_nameofunit.Text);
        //        obj_pro.addressoftheunit = Convert.ToString(txt_addressoftheunit.Text);
        //        obj_pro.constitutiooftheindustry = Convert.ToString(txt_Constitutionoftheindustry.Text);
        //        obj_pro.socialstatus = Convert.ToString(txt_SocialStatus.Text);
        //        obj_pro.nemeproppartnrmpmd = Convert.ToString(txt_nameofthepropmd.Text);
        //        obj_pro.schemename = Convert.ToString(ddl_scheme.SelectedItem.Text);
        //        obj_pro.schemeID = Convert.ToString(ddl_scheme.SelectedValue);
        //        obj_pro.SSIregiemlno = Convert.ToString(txt_ssiregniemilno.Text);
        //        obj_pro.dateapp = Convert.ToDateTime(txt_date.Text);
        //        obj_pro.lineofactivity = Convert.ToString(txt_lineofactivity.Text);

        //        obj_pro.units = Convert.ToString(txt_units.Text);
        //        obj_pro.capcity = Convert.ToInt32(txt_capacity.Text);
        //        obj_pro.unittype = Convert.ToString(ddlAppliedFor.SelectedItem.Text);
        //        obj_pro.unittypeid = Convert.ToString(ddlAppliedFor.SelectedValue);
        //        if (ddlAppliedFor.SelectedValue == "2")
        //        {
        //            obj_pro.prefinacialyr1 = Convert.ToString(txt_finacialyear1.Text);
        //            obj_pro.prefinacialyt1unitsutilised = Convert.ToInt32(txt_fin1unitsutilised.Text);
        //            obj_pro.prefinacialyr1rateofunit = Convert.ToDecimal(txt_fin1rateperunit.Text);
        //            obj_pro.prefinacialyr1totpaid = Convert.ToDecimal(txt_fin1totalpaidbytheunit.Text);
        //            obj_pro.prefinacialyr2 = Convert.ToString(txt_finacialyear2.Text);
        //            obj_pro.prefinacialyr2unitsutilised = Convert.ToInt32(txt_fin2unitsutilised.Text);
        //            obj_pro.prefinacialyr2rateofunit = Convert.ToDecimal(txt_fin2rateperunit.Text);
        //            obj_pro.prefinacialyr2totpaid = Convert.ToDecimal(txt_fin2totalpaidbytheunit.Text);
        //            obj_pro.prefinacialyr3 = Convert.ToString(txt_finacialyear3.Text);
        //            obj_pro.prefinacialyr3unitsutilised = Convert.ToInt32(txt_fin3unitsutilised.Text);
        //            obj_pro.prefinacialyr3rateofunit = Convert.ToDecimal(txt_fin3rateperunit.Text);
        //            obj_pro.prefinacialyr3totpaid = Convert.ToDecimal(txt_fin3totalpaidbytheunit.Text);
        //            obj_pro.yearofprior = Convert.ToInt32(txt_yearpriorem.Text);
        //            obj_pro.totunitsconprior3yrs = Convert.ToDecimal(txt_totunitsconsumedpriorto3years.Text);
        //            obj_pro.averageunitsem = Convert.ToDecimal(txt_averageunitsem.Text);
        //        }
        //        obj_pro.dateofcommesemetofprodn = Convert.ToDateTime(txt_DateofCommensementofProdn.Text);
        //        obj_pro.nameoffinancinginstituition = Convert.ToString(txt_NameofFinancingInstitution.Text);
        //        obj_pro.fixedassetsLandname = Convert.ToString(lbl_fixedland.Text);
        //        obj_pro.landapprovedprocst = Convert.ToInt32(txt_landapprovedprojectcost.Text);
        //        obj_pro.landexistprocst = Convert.ToInt32(txt_landexistingprojectcost.Text);
        //        obj_pro.landinvstprocst = Convert.ToInt32(txt_landnewexpansionprojectcost.Text);
        //        obj_pro.fixedassestsbuildingname = Convert.ToString(lbl_fixedbuilding.Text);
        //        obj_pro.buildingapprovedprocst = Convert.ToInt32(txt_buildingapprovedprojectcost.Text);
        //        obj_pro.buildingexistprocst = Convert.ToInt32(txt_buildingexistingprojectcost.Text);
        //        obj_pro.buildinginvstprocst = Convert.ToInt32(txt_buildingnewexpansionprojectcost.Text);
        //        obj_pro.fixedassestsplantmcname = Convert.ToString(lbl_plantmc.Text);
        //        obj_pro.plantmcapprovedprocst = Convert.ToInt32(txt_plantmcapprovedprojectcost.Text);
        //        obj_pro.plantmcexistprocst = Convert.ToInt32(txt_plantmcexistingprojectcost.Text);
        //        obj_pro.plantmcinvstprocst = Convert.ToInt32(txt_plantmcnewexpansionprojectcost.Text);
        //        obj_pro.fixedassesttotapprovedprocst = Convert.ToInt32(txt_totalapprovedprojectcost.Text);
        //        obj_pro.fixedassestexistprocst = Convert.ToInt32(txt_totalexistingprojectcost.Text);
        //        obj_pro.fixedassestinvstprocst = Convert.ToInt32(txt_totalmcnewexpansionprojectcost.Text);
        //        obj_pro.installcappriorofed = Convert.ToInt32(txt_installcapapriorofed.Text);
        //        obj_pro.installcapundered = Convert.ToInt32(txt_installcapundered.Text);
        //        obj_pro.perincinvstundered = Convert.ToDecimal(txt_increinveundered.Text);
        //        obj_pro.perinccapundered = Convert.ToDecimal(txt_increcapacityindered.Text);
        //        obj_pro.existingpowerinhp = Convert.ToDecimal(txt_existingpowerinhp.Text);
        //        obj_pro.newpowerconkva = Convert.ToDecimal(txt_newpowerconnection.Text);
        //        obj_pro.dateofnewconrelased = Convert.ToDateTime(txt_dateofnewcon.Text);
        //        obj_pro.serviceconnno = Convert.ToString(txt_serviceconnectionno.Text);
        //        obj_pro.installcapcityem = Convert.ToInt32(txt_installcapacityem.Text);
        //        obj_pro.rate75perofprod = Convert.ToDecimal(txt_75perproduction.Text);
        //        obj_pro.unitsper75perprodn = Convert.ToDecimal(txt_75peruitsproduction.Text);
        //        obj_pro.basepowconsfixperyr = Convert.ToDecimal(txt_basepowerconsumptionfixedperyear.Text);
        //        obj_pro.basepowconfixpermonnth = Convert.ToDecimal(txt_basepowerconsumptionfixedpermonth.Text);
        //        obj_pro.noofclaims = Convert.ToInt32(txt_noofclaims.Text);
        //        obj_pro.powertraiffperunits = Convert.ToDecimal(txt_powerTrafiffperUnit.Text);
        //        obj_pro.eglibleremperunits = Convert.ToDecimal(txt_eligiblrrateforreimbursement.Text);
        //        obj_pro.sayinrs = Convert.ToDecimal(txt_grandtotalamountsayrs.Text);
        //        obj_pro.recombygmdic = Convert.ToDecimal(txt_grandtotalrecombygmdic.Text);
        //        obj_pro.eligiblevalue = Convert.ToString(txt_grandtotaleligibleamountrs.Text);
        //        obj_pro.remarks = Convert.ToString(txt_totremarks.Text);

        //        obj_pro.belatedgrandtotofclaims = Convert.ToDecimal(txt_grdyfooterbelatedeligibleamountforreimbursement.Text);
        //        obj_pro.grandtotalofclaims = Convert.ToDecimal(txt_grdyfootereligibleamountforreimbursement.Text);
        //        obj_pro.grdtotUnitsConsumedinNos = Convert.ToDecimal(txt_grdfootertotunitsconsumed.Text);
        //        obj_pro.grdtotAmountPaidasperbill = Convert.ToDecimal(txt_grdfootertotamountpaid.Text);
        //        obj_pro.grdtotBasefixedpermonthinunits = Convert.ToDecimal(txt_grdfootertotbasefixedunitspermonth.Text);
        //        obj_pro.grdtotEligibleUnitsoverabove = Convert.ToDecimal(txt_grdfootertoteligibleunits.Text);

        //        obj_pro.createdby = Convert.ToString(Session["uid"]);
        //        obj_pro.createdip = Request.ServerVariables["Remote_Addr"];

        //        //string incpowrtariffid = obj_data.InsertCompanyforApplication(obj_pro);
        //        //if (!string.IsNullOrEmpty(incpowrtariffid))
        //        //{
        //        //    for (int i = 0; i < grd_calimsdetails.Rows.Count; i++)
        //        //    {
        //        //        TextBox txt_grddateoffillingindic = grd_calimsdetails.Rows[i].FindControl("txt_grddateoffillingindic") as TextBox;
        //        //        DropDownList ddl_grdedingyear = grd_calimsdetails.Rows[i].FindControl("ddl_grdedingyear") as DropDownList;
        //        //        TextBox txt_grd_halfyear = grd_calimsdetails.Rows[i].FindControl("txt_grd_halfyear") as TextBox;
        //        //        TextBox txt_grdyear = grd_calimsdetails.Rows[i].FindControl("txt_grdyear") as TextBox;
        //        //        TextBox txt_grdmonthyear1 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear1") as TextBox;
        //        //        TextBox txt_grdyear1unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear1rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1rateperunit") as TextBox;
        //        //        TextBox txt_grdyear1amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1amountpaid") as TextBox;
        //        //        TextBox txt_grdyear1basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear1eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear1eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear1eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear1eligibleamountforreimbursement") as TextBox;


        //        //        TextBox txt_grdmonthyear2 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear2") as TextBox;
        //        //        TextBox txt_grdyear2unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear2rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2rateperunit") as TextBox;
        //        //        TextBox txt_grdyear2amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2amountpaid") as TextBox;
        //        //        TextBox txt_grdyear2basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear2eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear2eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear2eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear2eligibleamountforreimbursement") as TextBox;

        //        //        TextBox txt_grdmonthyear3 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear3") as TextBox;
        //        //        TextBox txt_grdyear3unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear3rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3rateperunit") as TextBox;
        //        //        TextBox txt_grdyear3amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3amountpaid") as TextBox;
        //        //        TextBox txt_grdyear3basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear3eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear3eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear3eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear3eligibleamountforreimbursement") as TextBox;


        //        //        TextBox txt_grdmonthyear4 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear4") as TextBox;
        //        //        TextBox txt_grdyear4unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear4rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4rateperunit") as TextBox;
        //        //        TextBox txt_grdyear4amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4amountpaid") as TextBox;
        //        //        TextBox txt_grdyear4basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear4eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear4eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear4eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear4eligibleamountforreimbursement") as TextBox;

        //        //        TextBox txt_grdmonthyear5 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear5") as TextBox;
        //        //        TextBox txt_grdyear5unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear5rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5rateperunit") as TextBox;
        //        //        TextBox txt_grdyear5amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5amountpaid") as TextBox;
        //        //        TextBox txt_grdyear5basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear5eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear5eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear5eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear5eligibleamountforreimbursement") as TextBox;

        //        //        TextBox txt_grdmonthyear6 = grd_calimsdetails.Rows[i].FindControl("txt_grdmonthyear6") as TextBox;
        //        //        TextBox txt_grdyear6unitsconsumed = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6unitsconsumed") as TextBox;
        //        //        TextBox txt_grdyear6rateperunit = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6rateperunit") as TextBox;
        //        //        TextBox txt_grdyear6amountpaid = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6amountpaid") as TextBox;
        //        //        TextBox txt_grdyear6basefixedunitspermonth = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6basefixedunitspermonth") as TextBox;
        //        //        TextBox txt_grdyear6eligibleunits = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleunits") as TextBox;
        //        //        TextBox txt_grdyear6eligiblerateofreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligiblerateofreimbursement") as TextBox;
        //        //        TextBox txt_grdyear6eligibleamountforreimbursement = grd_calimsdetails.Rows[i].FindControl("txt_grdyear6eligibleamountforreimbursement") as TextBox;
        //        //        TextBox lbl_grdtoteligibleamount = grd_calimsdetails.Rows[i].FindControl("lbl_grdtoteligibleamount") as TextBox;
        //        //        RadioButtonList rbtgrd_isbelated = grd_calimsdetails.Rows[i].FindControl("rbtgrd_isbelated") as RadioButtonList;
        //        //        TextBox txt_belatedamount = grd_calimsdetails.Rows[i].FindControl("txt_belatedamount") as TextBox;

        //        //        incpowertariffclaimdetailsproperties objclaimdetails = new incpowertariffclaimdetailsproperties();
        //        //        objclaimdetails.ClaimNo = Convert.ToInt32(i + 1);
        //        //        objclaimdetails.DateoffillinginDIC = Convert.ToDateTime(txt_grddateoffillingindic.Text);
        //        //        objclaimdetails.Endingdateofid = Convert.ToString(ddl_grdedingyear.SelectedValue);
        //        //        objclaimdetails.Endingdateof = Convert.ToString(ddl_grdedingyear.SelectedItem.Text);
        //        //        objclaimdetails.HalfYeardate = Convert.ToString(txt_grd_halfyear.Text);
        //        //        objclaimdetails.Year = Convert.ToString(txt_grdyear.Text);
        //        //        objclaimdetails.incpowrtariffid = Convert.ToInt32(incpowrtariffid);
        //        //        objclaimdetails.TotalEliglibleamount = Convert.ToString(lbl_grdtoteligibleamount.Text);
        //        //        objclaimdetails.IsBelated = false;
        //        //        if (rbtgrd_isbelated.SelectedValue == "Y")
        //        //        {
        //        //            objclaimdetails.IsBelated = true;
        //        //        }
        //        //        objclaimdetails.belatedtotEligibleamountReiembursement = Convert.ToDecimal(txt_belatedamount.Text);
        //        //        objclaimdetails.Monthyear1 = Convert.ToString(txt_grdmonthyear1.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear1 = Convert.ToDecimal(txt_grdyear1unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear1 = Convert.ToDecimal(txt_grdyear1rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear1 = Convert.ToDecimal(txt_grdyear1amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear1 = Convert.ToDecimal(txt_grdyear1basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear1 = Convert.ToDecimal(txt_grdyear1eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear1 = Convert.ToDecimal(txt_grdyear1eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear1 = Convert.ToDecimal(txt_grdyear1eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Monthyear2 = Convert.ToString(txt_grdmonthyear2.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear2 = Convert.ToDecimal(txt_grdyear2unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear2 = Convert.ToDecimal(txt_grdyear2rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear2 = Convert.ToDecimal(txt_grdyear2amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear2 = Convert.ToDecimal(txt_grdyear2basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear2 = Convert.ToDecimal(txt_grdyear2eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear2 = Convert.ToDecimal(txt_grdyear2eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear2 = Convert.ToDecimal(txt_grdyear2eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Monthyear3 = Convert.ToString(txt_grdmonthyear3.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear3 = Convert.ToDecimal(txt_grdyear3unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear3 = Convert.ToDecimal(txt_grdyear3rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear3 = Convert.ToDecimal(txt_grdyear3amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear3 = Convert.ToDecimal(txt_grdyear3basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear3 = Convert.ToDecimal(txt_grdyear3eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear3 = Convert.ToDecimal(txt_grdyear3eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear3 = Convert.ToDecimal(txt_grdyear3eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Monthyear4 = Convert.ToString(txt_grdmonthyear4.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear4 = Convert.ToDecimal(txt_grdyear4unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear4 = Convert.ToDecimal(txt_grdyear4rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear4 = Convert.ToDecimal(txt_grdyear4amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear4 = Convert.ToDecimal(txt_grdyear4basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear4 = Convert.ToDecimal(txt_grdyear4eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear4 = Convert.ToDecimal(txt_grdyear4eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear4 = Convert.ToDecimal(txt_grdyear4eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Monthyear5 = Convert.ToString(txt_grdmonthyear5.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear5 = Convert.ToDecimal(txt_grdyear5unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear5 = Convert.ToDecimal(txt_grdyear5rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear5 = Convert.ToDecimal(txt_grdyear5amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear5 = Convert.ToDecimal(txt_grdyear5basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear5 = Convert.ToDecimal(txt_grdyear5eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear5 = Convert.ToDecimal(txt_grdyear5eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear5 = Convert.ToDecimal(txt_grdyear5eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Monthyear6 = Convert.ToString(txt_grdmonthyear6.Text);
        //        //        objclaimdetails.UnitsConsumedinNosMonthyear6 = Convert.ToDecimal(txt_grdyear6unitsconsumed.Text);
        //        //        objclaimdetails.RateperUnitsMonthyear6 = Convert.ToDecimal(txt_grdyear6rateperunit.Text);
        //        //        objclaimdetails.AmountPaidasperBillMonthyear6 = Convert.ToDecimal(txt_grdyear6amountpaid.Text);
        //        //        objclaimdetails.BasefixedpermonthinunitsMonthyear6 = Convert.ToDecimal(txt_grdyear6basefixedunitspermonth.Text);
        //        //        objclaimdetails.EligibleUnitsBaseMonthyear6 = Convert.ToDecimal(txt_grdyear6eligibleunits.Text);
        //        //        objclaimdetails.EligibleRateReimbursementperunitsMonthyear6 = Convert.ToDecimal(txt_grdyear6eligiblerateofreimbursement.Text);
        //        //        objclaimdetails.EligibleamountReiembursementMonthyear6 = Convert.ToDecimal(txt_grdyear6eligibleamountforreimbursement.Text);
        //        //        objclaimdetails.Createdby = Convert.ToString(Session["uid"]);
        //        //        objclaimdetails.createdip = Request.ServerVariables["Remote_Addr"];
        //        //        //obj_data.DB_insertappofincpowertariffclaimdetails(objclaimdetails);


        //        //    }
        //        //}

        //        //if (!string.IsNullOrEmpty(incpowrtariffid))
        //        //{
        //        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Successfully')", true);
        //        //}
        //        //else
        //        //{
        //        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Failed')", true);
        //        //}
        //    }
        //}
    }

    #endregion


    #region grid row databound
    protected void grd_calimsdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string IncentiveId = txtINCNoEntry.Text.ToString();
        GridView grd_calimsdetails = (GridView)sender;
        // GridViewRow gvRow = (GridViewRow)grd_calimsdetails.NamingContainer;

        if (IncentiveId != "")
        {
            string MasterIncentiveId = "3";
            SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            osqlConnection.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_appeal_PowerTariff", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
            da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
            da.Fill(ds);

            //int testCount = grd_calimsdetails.Rows.Count;



            //for (int intCnt = 0; intCnt < ds.Tables[0].Rows.Count; intCnt++)
            //{
            //    //if (grd_calimsdetails.Rows[intCnt].RowType == DataControlRowType.DataRow)
            //    //{
            //        TextBox txt_grddateoffillingindic = (TextBox)grd_calimsdetails.Rows[0].FindControl("txt_grddateoffillingindic");
            //        txt_grddateoffillingindic.Text = txtrc_dic.Text;

            //    //}
            //}
            //for (int i = 0; i < grd_calimsdetails.Rows.Count; i++)
            //{

            //}

        }




        //TextBox txt_grdmonthyear1 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear1");

        //txt_grdmonthyear1.Text = "";

        //TextBox txt_grdmonthyear1 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear1");

        //TextBox tx-+t_grdmonthyear2 = (TextBox)grd_calimsdetails.Rows[0].FindControl("txt_grdmonthyear2");
        //    //if (txt_grdmonthyear2 != null)
        //        txt_grdmonthyear2.Text = ds.Tables[2].Rows[1]["monthNames"].ToString();

        //    TextBox txt_grdmonthyear3 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear3");
        //    //if (txt_grdmonthyear3 != null)
        //        txt_grdmonthyear3.Text = ds.Tables[2].Rows[2]["monthNames"].ToString();

        //    TextBox txt_grdmonthyear4 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear4");
        //    if (txt_grdmonthyear4 != null)
        //        txt_grdmonthyear4.Text = ds.Tables[2].Rows[3]["monthNames"].ToString();

        //    TextBox txt_grdmonthyear5 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear5");
        //    if (txt_grdmonthyear5 != null)
        //        txt_grdmonthyear5.Text = ds.Tables[2].Rows[4]["monthNames"].ToString();

        //    TextBox txt_grdmonthyear6 = (TextBox)grd_calimsdetails.FindControl("txt_grdmonthyear6");
        //    if (txt_grdmonthyear6 != null)
        //        txt_grdmonthyear6.Text = ds.Tables[2].Rows[5]["monthNames"].ToString();


        //TextBox txt_grdmonthyear1 = (TextBox)e.Row.FindControl("txt_grdmonthyear1");
        //txt_grdmonthyear1.Text = ds.Tables[0].Rows[0]["ProjcostPlant"].ToString();

        //for (int i = 0; i < 5; i++)
        //{
        //    TextBox txt_grdmonthyear1 = (TextBox)e.Row.FindControl("txt_grdmonthyear1");
        //    txt_grdmonthyear1.Text = ds.Tables[2].Rows[i]["monthNames"].ToString();
        //}

        #region "commentCode"
        //.FindControl("txt_grddateoffillingindic"));

        //txt_grddateoffillingindic.Text = txtrc_dic.Text.ToString();

        //    GridViewRow grd_calimsdetails = (GridViewRow)grd_calimsdetails.NamingContainer;

        //    txt_grddateoffillingindic_org = (TextBox)txt_grddateoffillingindic_org.FindControl("txt_grddateoffillingindic");


        //    txt_grddateoffillingindic.Text = txtrc_dic.Text;
        //        if (!string.IsNullOrEmpty(hf_incpowrtariffid.Value))
        //        {

        //            Label lbl_Enrolled = (Label)e.Row.FindControl("lbl_Enrolled");
        //            Label lbl_Dropout = (Label)e.Row.FindControl("lbl_Dropout");
        //            Label lbl_placed = (Label)e.Row.FindControl("lbl_placed");
        //            Label lbl_MaxMembers = (Label)e.Row.FindControl("lbl_MaxMembers");

        //            TextBox txt_grddateoffillingindic = (TextBox)e.Row.FindControl("txt_grddateoffillingindic");
        //            DropDownList ddl_grdedingyear = (DropDownList)e.Row.FindControl("ddl_grdedingyear");
        //            TextBox txt_grd_halfyear = (TextBox)e.Row.FindControl("txt_grd_halfyear");
        //            TextBox txt_grdyear = (TextBox)e.Row.FindControl("txt_grdyear");
        //            TextBox txt_grdmonthyear1 = (TextBox)e.Row.FindControl("txt_grdmonthyear1");
        //            TextBox txt_grdyear1unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear1unitsconsumed");
        //            TextBox txt_grdyear1rateperunit = (TextBox)e.Row.FindControl("txt_grdyear1rateperunit");
        //            TextBox txt_grdyear1amountpaid = (TextBox)e.Row.FindControl("txt_grdyear1amountpaid");
        //            TextBox txt_grdyear1basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear1basefixedunitspermonth");
        //            TextBox txt_grdyear1eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear1eligibleunits");
        //            TextBox txt_grdyear1eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear1eligiblerateofreimbursement");
        //            TextBox txt_grdyear1eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear1eligibleamountforreimbursement");

        //            TextBox txt_grdmonthyear2 = (TextBox)e.Row.FindControl("txt_grdmonthyear2");
        //            TextBox txt_grdyear2unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear2unitsconsumed");
        //            TextBox txt_grdyear2rateperunit = (TextBox)e.Row.FindControl("txt_grdyear2rateperunit");
        //            TextBox txt_grdyear2amountpaid = (TextBox)e.Row.FindControl("txt_grdyear2amountpaid");
        //            TextBox txt_grdyear2basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear2basefixedunitspermonth");
        //            TextBox txt_grdyear2eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear2eligibleunits");
        //            TextBox txt_grdyear2eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear2eligiblerateofreimbursement");
        //            TextBox txt_grdyear2eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear2eligibleamountforreimbursement");

        //            TextBox txt_grdmonthyear3 = (TextBox)e.Row.FindControl("txt_grdmonthyear3");
        //            TextBox txt_grdyear3unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear3unitsconsumed");
        //            TextBox txt_grdyear3rateperunit = (TextBox)e.Row.FindControl("txt_grdyear3rateperunit");
        //            TextBox txt_grdyear3amountpaid = (TextBox)e.Row.FindControl("txt_grdyear3amountpaid");
        //            TextBox txt_grdyear3basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear3basefixedunitspermonth");
        //            TextBox txt_grdyear3eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear3eligibleunits");
        //            TextBox txt_grdyear3eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear3eligiblerateofreimbursement");
        //            TextBox txt_grdyear3eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear3eligibleamountforreimbursement");

        //            TextBox txt_grdmonthyear4 = (TextBox)e.Row.FindControl("txt_grdmonthyear4");
        //            TextBox txt_grdyear4unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear4unitsconsumed");
        //            TextBox txt_grdyear4rateperunit = (TextBox)e.Row.FindControl("txt_grdyear4rateperunit");
        //            TextBox txt_grdyear4amountpaid = (TextBox)e.Row.FindControl("txt_grdyear4amountpaid");
        //            TextBox txt_grdyear4basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear4basefixedunitspermonth");
        //            TextBox txt_grdyear4eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear4eligibleunits");
        //            TextBox txt_grdyear4eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear4eligiblerateofreimbursement");
        //            TextBox txt_grdyear4eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear4eligibleamountforreimbursement");

        //            TextBox txt_grdmonthyear5 = (TextBox)e.Row.FindControl("txt_grdmonthyear5");
        //            TextBox txt_grdyear5unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear5unitsconsumed");
        //            TextBox txt_grdyear5rateperunit = (TextBox)e.Row.FindControl("txt_grdyear5rateperunit");
        //            TextBox txt_grdyear5amountpaid = (TextBox)e.Row.FindControl("txt_grdyear5amountpaid");
        //            TextBox txt_grdyear5basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear5basefixedunitspermonth");
        //            TextBox txt_grdyear5eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear5eligibleunits");
        //            TextBox txt_grdyear5eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear5eligiblerateofreimbursement");
        //            TextBox txt_grdyear5eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear5eligibleamountforreimbursement");

        //            TextBox txt_grdmonthyear6 = (TextBox)e.Row.FindControl("txt_grdmonthyear6");
        //            TextBox txt_grdyear6unitsconsumed = (TextBox)e.Row.FindControl("txt_grdyear6unitsconsumed");
        //            TextBox txt_grdyear6rateperunit = (TextBox)e.Row.FindControl("txt_grdyear6rateperunit");
        //            TextBox txt_grdyear6amountpaid = (TextBox)e.Row.FindControl("txt_grdyear6amountpaid");
        //            TextBox txt_grdyear6basefixedunitspermonth = (TextBox)e.Row.FindControl("txt_grdyear6basefixedunitspermonth");
        //            TextBox txt_grdyear6eligibleunits = (TextBox)e.Row.FindControl("txt_grdyear6eligibleunits");
        //            TextBox txt_grdyear6eligiblerateofreimbursement = (TextBox)e.Row.FindControl("txt_grdyear6eligiblerateofreimbursement");
        //            TextBox txt_grdyear6eligibleamountforreimbursement = (TextBox)e.Row.FindControl("txt_grdyear6eligibleamountforreimbursement");
        //            TextBox lbl_grdtoteligibleamount = (TextBox)e.Row.FindControl("lbl_grdtoteligibleamount");
        //            RadioButtonList rbtgrd_isbelated = (RadioButtonList)e.Row.FindControl("rbtgrd_isbelated");
        //            TextBox txt_belatedamount = (TextBox)e.Row.FindControl("txt_belatedamount");

        //            //incpowertariffclaimid,ClaimNo,,,Endingdateof,,,incpowrtariffid,Createdby,Createdon,createdip,modifiedby,modifiedon,modifiedip,isactive

        //            txt_grddateoffillingindic.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DateoffillinginDIC"));
        //            ddl_grdedingyear.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Endingdateofid"));
        //            //ddl_grdedingyear.SelectedItem.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BatchCode"));
        //            txt_grd_halfyear.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HalfYeardate"));
        //            txt_grdyear.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Year"));
        //            lbl_grdtoteligibleamount.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalEliglibleamount"));
        //            rbtgrd_isbelated.SelectedValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsBelated"));
        //            txt_belatedamount.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "belatedtotEligibleamountReiembursement"));

        //            txt_grdmonthyear1.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear1"));
        //            txt_grdyear1unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear1"));
        //            txt_grdyear1rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear1amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear1"));
        //            txt_grdyear1basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear1eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear1"));
        //            txt_grdyear1eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear1eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear1"));

        //            txt_grdmonthyear2.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear2"));
        //            txt_grdyear2unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear2"));
        //            txt_grdyear2rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear2amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear2"));
        //            txt_grdyear2basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear2eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear2"));
        //            txt_grdyear2eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear2eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear2"));


        //            txt_grdmonthyear3.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear3"));
        //            txt_grdyear3unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear3"));
        //            txt_grdyear3rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear3amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear3"));
        //            txt_grdyear3basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear3eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear3"));
        //            txt_grdyear3eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear3eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear3"));


        //            txt_grdmonthyear4.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear4"));
        //            txt_grdyear4unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear4"));
        //            txt_grdyear4rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear4amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear4"));
        //            txt_grdyear4basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear4eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear4"));
        //            txt_grdyear4eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear4eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear4"));


        //            txt_grdmonthyear5.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear5"));
        //            txt_grdyear5unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear5"));
        //            txt_grdyear5rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear5amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear5"));
        //            txt_grdyear5basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear5eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear5"));
        //            txt_grdyear5eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear5eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear5"));

        //            txt_grdmonthyear6.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Monthyear6"));
        //            txt_grdyear6unitsconsumed.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitsConsumedinNosMonthyear6"));
        //            txt_grdyear6rateperunit.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "rateperunit"));
        //            txt_grdyear6amountpaid.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AmountPaidasperBillMonthyear6"));
        //            txt_grdyear6basefixedunitspermonth.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "basefixedunitspermonth"));
        //            txt_grdyear6eligibleunits.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleUnitsBaseMonthyear6"));
        //            txt_grdyear6eligiblerateofreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "reimbursementrateperunit"));
        //            txt_grdyear6eligibleamountforreimbursement.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EligibleamountReiembursementMonthyear6"));
        //        }
        #endregion
    }


    protected void txt_grdyear1rateperunit_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txt_grdyear1amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear1rateperunit.Text != "" && txt_grdyear1amountpaid.Text != "")
        {
            txt_grdyear1basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear1rateperunit.Text) * Convert.ToDecimal(txt_grdyear1amountpaid.Text)).ToString();
        }
    }

    protected void txt_grdyear2amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear2rateperunit.Text != "" && txt_grdyear2amountpaid.Text != "")
        {
            //txt_grdyear2basefixedunitspermonth
            txt_grdyear2basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear2rateperunit.Text) * Convert.ToDecimal(txt_grdyear2amountpaid.Text)).ToString();
        }
    }

    protected void txt_grdyear3amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear3rateperunit.Text != "" && txt_grdyear3amountpaid.Text != "")
        {
            txt_grdyear3basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear3rateperunit.Text) * Convert.ToDecimal(txt_grdyear3amountpaid.Text)).ToString();
        }
    }

    protected void txt_grdyear4amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear4rateperunit.Text != "" && txt_grdyear4amountpaid.Text != "")
        {
            txt_grdyear4basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear4rateperunit.Text) * Convert.ToDecimal(txt_grdyear4amountpaid.Text)).ToString();
        }
    }

    protected void txt_grdyear5amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear5rateperunit.Text != "" && txt_grdyear5amountpaid.Text != "")
        {
            txt_grdyear5basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear5rateperunit.Text) * Convert.ToDecimal(txt_grdyear5amountpaid.Text)).ToString();
        }

    }

    protected void txt_grdyear6amountpaid_TextChanged(object sender, EventArgs e)
    {
        if (txt_grdyear6rateperunit.Text != "" && txt_grdyear6amountpaid.Text != "")
        {
            txt_grdyear6basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear6rateperunit.Text) * Convert.ToDecimal(txt_grdyear6amountpaid.Text)).ToString();
        }

    }

    protected void txt_grdyear2rateperunit_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txt_grdyear3rateperunit_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txt_grdyear4rateperunit_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txt_grdyear5rateperunit_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox24_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else
        {
            if (TextBox23.Text != "" && TextBox24.Text != "")
            {
                TextBox25.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox24.Text)).ToString();

                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();

                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();


                }

                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }




            }
        }
      
    }
    protected void TextBox51_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else
        {
            if (TextBox50.Text != "" && TextBox51.Text != "")
            {
                TextBox52.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox51.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }

                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }


            }
        }
      

    }

    protected void TextBox64_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else
        {
            if (TextBox63.Text != "" && TextBox64.Text != "")
            {
                TextBox65.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox64.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }
                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }



            }
        }
    }

    protected void TextBox72_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else {
            if (TextBox71.Text != "" && TextBox72.Text != "")
            {
                TextBox73.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox72.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }

                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }

            }
        }
    }

    protected void TextBox80_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else {
            if (TextBox79.Text != "" && TextBox80.Text != "")
            {
                TextBox81.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox80.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }

                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }

            }
        }
    }


    protected void TextBox88_TextChanged(object sender, EventArgs e)
    {
        if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox23.Text = "";
            TextBox50.Text = "";
            TextBox63.Text = "";
            TextBox71.Text = "";
            TextBox79.Text = "";
            TextBox87.Text = "";

            TextBox24.Text = "";
            TextBox51.Text = "";
            TextBox64.Text = "";
            TextBox72.Text = "";
            TextBox80.Text = "";
            TextBox88.Text = "";
        }
        else {
            if (TextBox87.Text != "" && TextBox88.Text != "")
            {
                TextBox89.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox88.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }

                if (TextBox23.Text != "" && TextBox21.Text != "")
                {
                    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }


                }
                if (TextBox50.Text != "" && TextBox22.Text != "")
                {
                    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox63.Text != "" && TextBox26.Text != "")
                {
                    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox71.Text != "" && TextBox27.Text != "")
                {
                    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox79.Text != "" && TextBox95.Text != "")
                {
                    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }
                if (TextBox87.Text != "" && TextBox95.Text != "")
                {
                    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                    if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                    }

                }

            }
        }

    }

    protected void TextBox23_TextChanged(object sender, EventArgs e)
    {
        if (TextBox23.Text != "" && TextBox24.Text != "")
        {
            TextBox25.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox24.Text)).ToString();

            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();

                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();
 

            }



        }
    }

    protected void TextBox50_TextChanged(object sender, EventArgs e)
    {
        if (TextBox50.Text != "" && TextBox51.Text != "")
        {
            TextBox52.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox51.Text)).ToString();
            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

            }
 


        }
    }

    protected void TextBox63_TextChanged(object sender, EventArgs e)
    {
        if (TextBox63.Text != "" && TextBox64.Text != "")
        {
            TextBox65.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox64.Text)).ToString();
            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

            }

          
        }
    }

    protected void TextBox71_TextChanged(object sender, EventArgs e)
    {
        if (TextBox71.Text != "" && TextBox72.Text != "")
        {
            TextBox73.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox72.Text)).ToString();
            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

            }
            //if (TextBox23.Text != "" && TextBox21.Text != "")
            //{
            //    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();

            //}
            //if (TextBox50.Text != "" && TextBox22.Text != "")
            //{
            //    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
            //}
            //if (TextBox63.Text != "" && TextBox26.Text != "")
            //{
            //    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
            //}
            //if (TextBox71.Text != "" && TextBox27.Text != "")
            //{
            //    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
            //}
            //if (TextBox79.Text != "" && TextBox95.Text != "")
            //{
            //    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
            //}
            //if (TextBox87.Text != "" && TextBox95.Text != "")
            //{
            //    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
            //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
            //}



        }
    }

    protected void TextBox79_TextChanged(object sender, EventArgs e)
    {
        if (TextBox79.Text != "" && TextBox80.Text != "")
        {
            TextBox81.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox80.Text)).ToString();
            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

            }
           

        }
    }

    protected void TextBox87_TextChanged(object sender, EventArgs e)
    {
        if (TextBox87.Text != "" && TextBox88.Text != "")
        {
            TextBox89.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox88.Text)).ToString();
            if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
            {
                lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

            }


        }
    }






    protected void txt_grdyear6rateperunit_TextChanged(object sender, EventArgs e)
    {

    }



    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (lblGmAmount0.Text != "" && TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
        {
            if (RadioButtonList1.SelectedValue.ToString() == "N")
            {

                decimal a = Convert.ToDecimal(lblGmAmount0.Text);
                decimal b = Convert.ToDecimal(lblGmAmount.Text);
                decimal c = a / 2;  //coi - calculated
                if (c < b)
                {
                    TextBox93.Text = c.ToString();
                }
                if (b < c)
                {
                    TextBox93.Text = b.ToString();
                }
                if (b == c)
                {
                    TextBox93.Text = b.ToString();
                }
                TextBox94.Text = TextBox93.Text;
            }
            if (RadioButtonList1.SelectedValue.ToString() == "Y")
            {
                decimal a = Convert.ToDecimal(lblGmAmount0.Text);
                decimal b = Convert.ToDecimal(lblGmAmount.Text);

                if (a < b)
                {
                    TextBox93.Text = a.ToString();
                }

                if (b < a)
                {
                    TextBox93.Text = b.ToString();
                }
                if (b == a)
                {
                    TextBox93.Text = b.ToString();
                }

                TextBox94.Text = TextBox93.Text;
            }
            if (RadioButtonList1.SelectedValue.ToString() == "R")
            {
                TextBox93.Text = "0";
                TextBox94.Text = TextBox93.Text;

            }
            if (txt_belatedamount.Text == "" || txt_belatedamount.Text == null)
            {
                txt_belatedamount.Text = "0";
            }
            if (TextBox192.Text == "" || TextBox192.Text == null)
            {
                TextBox192.Text = "0";
            }
            if (TextBox94.Text==""|| TextBox94.Text==null)
            {
                TextBox94.Text = "0";
            }
            if (TextBox101.Text == "" || TextBox101.Text == null)
            {
                TextBox101.Text = "0";
            }
            lbltotalsubsidyamount.Text = (Convert.ToDecimal(txt_belatedamount.Text) +
                Convert.ToDecimal(TextBox192.Text) + Convert.ToDecimal(TextBox94.Text) + Convert.ToDecimal(TextBox101.Text)).ToString();
        }

        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
    }

    protected void TextBox62_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox66_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox67_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox62_TextChanged1(object sender, EventArgs e)
    {
        if (txt_grddateoffillingindic0.Text != "" && TextBox62.Text != "")
        {
            TextBox68.Text = (Convert.ToDecimal(txt_grddateoffillingindic0.Text) * Convert.ToDecimal(TextBox62.Text)).ToString();
        }

        if (TextBox74.Text == "")
        {
            TextBox74.Text = "0";
        }
        else if (TextBox74.Text != "")
        {
            if (ddlFinancialYear.SelectedValue != ddlFinancialYear1.SelectedValue && ddlFinancialYear.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear1.SelectedValue)
            {
                TextBox74.Text = (Convert.ToDecimal(txt_grddateoffillingindic0.Text) + Convert.ToDecimal(txt_grddateoffillingindic1.Text) + +Convert.ToDecimal(TextBox59.Text)).ToString();
                TextBox97.Text = (Convert.ToDecimal(TextBox74.Text) / 3).ToString();
                decimal test = Math.Round(Convert.ToDecimal(TextBox97.Text));
                TextBox97.Text = test.ToString();
                TextBox98.Text = TextBox97.Text;
                TextBox98.Enabled = false;
                TextBox7775.Text = (Math.Round(test / 12)).ToString();
                txt_grdyear1eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear2eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear3eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear4eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear5eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear6eligibleunits.Text = (TextBox7775.Text).ToString();
                TextBox7775_TextChanged(sender, e);


                if (lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
                {
                    if (Session["socialStatus"].ToString() == "General")
                    {
                        txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                        //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



                    }
                    else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                    {


                        txt_grdyear1eligibleamountforreimbursement.Text = "1";
                        txt_grdyear2eligibleamountforreimbursement.Text = "1";
                        txt_grdyear3eligibleamountforreimbursement.Text = "1";
                        txt_grdyear4eligibleamountforreimbursement.Text = "1";
                        txt_grdyear5eligibleamountforreimbursement.Text = "1";
                        txt_grdyear6eligibleamountforreimbursement.Text = "1";



                        //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


                    }


                }

                else if (lblSchemeName.Text == "IIPP Scheme 2010 - 2015")
                {
                    if (Session["socialStatus"].ToString() == "General")
                    {


                        txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                        txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                        //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


                    }
                    else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                    {




                        txt_grdyear1eligibleamountforreimbursement.Text = "1";
                        txt_grdyear2eligibleamountforreimbursement.Text = "1";
                        txt_grdyear3eligibleamountforreimbursement.Text = "1";
                        txt_grdyear4eligibleamountforreimbursement.Text = "1";
                        txt_grdyear5eligibleamountforreimbursement.Text = "1";
                        txt_grdyear6eligibleamountforreimbursement.Text = "1";



                        //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                        //txt_grdyear6eligibleamountforreimbursement.Enabled = false;
                    }

                }
                else if (lblSchemeName.Text == "T-IDEA")
                {

                    txt_grdyear1eligibleamountforreimbursement.Text = "1";
                    txt_grdyear2eligibleamountforreimbursement.Text = "1";
                    txt_grdyear3eligibleamountforreimbursement.Text = "1";
                    txt_grdyear4eligibleamountforreimbursement.Text = "1";
                    txt_grdyear5eligibleamountforreimbursement.Text = "1";
                    txt_grdyear6eligibleamountforreimbursement.Text = "1";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



                }
                else if (lblSchemeName.Text == "T-PRIDE")
                {


                    txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;

                }
                else if (lblSchemeName.Text == "T-PRIDE(PHC)" && lblSchemeName.Text != "IIPP Scheme 2010 - 2015" && lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
                {


                    txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
                    txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


                }

            }

            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Financial year selected cannot be equal to other financial years selected!');", true);



        }


    }

    protected void TextBox66_TextChanged1(object sender, EventArgs e)
    {
        if (txt_grddateoffillingindic1.Text != "" && TextBox66.Text != "")
        {
            TextBox69.Text = (Convert.ToDecimal(txt_grddateoffillingindic1.Text) * Convert.ToDecimal(TextBox66.Text)).ToString();
        }
        if (TextBox74.Text == "")
        {
            TextBox74.Text = "0";
        }
        else if (TextBox74.Text != "")
        {
            if (ddlFinancialYear.SelectedValue != ddlFinancialYear1.SelectedValue && ddlFinancialYear.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear1.SelectedValue)
            {
                if(txt_grddateoffillingindic0.Text!="" && txt_grddateoffillingindic1.Text!="" && TextBox59.Text!="")
                {
                    TextBox74.Text = (Convert.ToDecimal(txt_grddateoffillingindic0.Text) + Convert.ToDecimal(txt_grddateoffillingindic1.Text) + +Convert.ToDecimal(TextBox59.Text)).ToString();
                    TextBox97.Text = (Convert.ToDecimal(TextBox74.Text) / 3).ToString();
                    decimal test = Math.Round(Convert.ToDecimal(TextBox97.Text));
                    TextBox97.Text = test.ToString();
                    TextBox98.Text = TextBox97.Text;
                    TextBox98.Enabled = false;
                    TextBox7775.Text = (Math.Round(test / 12)).ToString();
                    txt_grdyear1eligibleunits.Text = (TextBox7775.Text).ToString();
                    txt_grdyear2eligibleunits.Text = (TextBox7775.Text).ToString();
                    txt_grdyear3eligibleunits.Text = (TextBox7775.Text).ToString();
                    txt_grdyear4eligibleunits.Text = (TextBox7775.Text).ToString();
                    txt_grdyear5eligibleunits.Text = (TextBox7775.Text).ToString();
                    txt_grdyear6eligibleunits.Text = (TextBox7775.Text).ToString();
                }
                
            }

            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Financial year selected cannot be equal to other financial years selected!');", true);
            TextBox7775_TextChanged(sender, e);

        }
    }

    protected void TextBox67_TextChanged1(object sender, EventArgs e)
    {
        if (TextBox59.Text != "" && TextBox67.Text != "")
        {
            TextBox70.Text = (Convert.ToDecimal(TextBox59.Text) * Convert.ToDecimal(TextBox67.Text)).ToString();
        }
        if (TextBox74.Text == "")
        {
            TextBox74.Text = "0";
        }
        else if (TextBox74.Text != "")
        {
            if (ddlFinancialYear.SelectedValue != ddlFinancialYear1.SelectedValue && ddlFinancialYear.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear2.SelectedValue && ddlFinancialYear1.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear.SelectedValue && ddlFinancialYear2.SelectedValue != ddlFinancialYear1.SelectedValue)
            {
                TextBox74.Text = (Convert.ToDecimal(txt_grddateoffillingindic0.Text) + Convert.ToDecimal(txt_grddateoffillingindic1.Text) + +Convert.ToDecimal(TextBox59.Text)).ToString();
                TextBox97.Text = (Convert.ToDecimal(TextBox74.Text) / 3).ToString();
                decimal test = Math.Round(Convert.ToDecimal(TextBox97.Text));
                TextBox97.Text = test.ToString();
                TextBox98.Text = TextBox97.Text;
                TextBox98.Enabled = false;
                TextBox7775.Text = (Math.Round(test / 12)).ToString();
                txt_grdyear1eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear2eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear3eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear4eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear5eligibleunits.Text = (TextBox7775.Text).ToString();
                txt_grdyear6eligibleunits.Text = (TextBox7775.Text).ToString();

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Financial year selected cannot be equal to other financial years selected!');", true);
        }
        TextBox7775_TextChanged(sender, e);


    }





    protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFinancialYear1.Items.Remove(ddlFinancialYear.SelectedItem);
        ddlFinancialYear2.Items.Remove(ddlFinancialYear.SelectedItem);
        ddlFinancialYear.Enabled = false;
    }

    protected void ddlFinancialYear1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFinancialYear.Items.Remove(ddlFinancialYear1.SelectedItem);
        ddlFinancialYear2.Items.Remove(ddlFinancialYear1.SelectedItem);
        ddlFinancialYear1.Enabled = false;



    }

    protected void ddlFinancialYear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFinancialYear.Items.Remove(ddlFinancialYear2.SelectedItem);
        ddlFinancialYear1.Items.Remove(ddlFinancialYear2.SelectedItem);
        ddlFinancialYear2.Enabled = false;


    }

    protected void txt_grdyear1rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //(TextBox7775.Text).ToString();

        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear1rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
            txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear1rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

   


        //}
        //else if (Convert.ToDecimal(txt_grdyear1rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear1rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear1rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear1rateperunit.Text)).ToString();

        //}
        if(txt_grdyear1eligiblerateofreimbursement.Text!="" && txt_grdyear1eligibleamountforreimbursement.Text!="")
        {
            TextBox75.Text = ((Convert.ToDecimal(txt_grdyear1eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear1eligibleamountforreimbursement.Text))).ToString();
        }
 

    }

    protected void txt_grdyear2rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear2rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
            txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear2rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear2rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear2rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear2rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear2rateperunit.Text)).ToString();

        //}

        if(txt_grdyear2eligiblerateofreimbursement.Text!="" && txt_grdyear2eligibleamountforreimbursement.Text!="")
        {
            TextBox76.Text = ((Convert.ToDecimal(txt_grdyear2eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear2eligibleamountforreimbursement.Text))).ToString();
        }
 

    }

    protected void txt_grdyear3rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear3rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
            txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear3rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear3rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear3rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear3rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear3rateperunit.Text)).ToString();

        //}

        if(txt_grdyear3eligiblerateofreimbursement.Text!="" && txt_grdyear3eligibleamountforreimbursement.Text!="")
        {
            TextBox77.Text = ((Convert.ToDecimal(txt_grdyear3eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear3eligibleamountforreimbursement.Text))).ToString();
        }

    }

    protected void txt_grdyear4rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear4rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
            txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear4rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear4rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear4rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear4rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear4rateperunit.Text)).ToString();

        //}
        if(txt_grdyear4eligiblerateofreimbursement.Text!="" && txt_grdyear4eligibleamountforreimbursement.Text!="")
        {
            TextBox78.Text = ((Convert.ToDecimal(txt_grdyear4eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear4eligibleamountforreimbursement.Text))).ToString();
        }

    }

    protected void txt_grdyear5rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear5rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
            txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear5rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear5rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear5rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear5rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear5rateperunit.Text)).ToString();

        //}
        if(txt_grdyear5eligiblerateofreimbursement.Text !="" && txt_grdyear5eligibleamountforreimbursement.Text!="")
        {
            TextBox82.Text = ((Convert.ToDecimal(txt_grdyear5eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear5eligibleamountforreimbursement.Text))).ToString();
        }
 
    }

    protected void txt_grdyear6rateperunit_TextChanged1(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear6rateperunit.Text))//txt_grdyear1eligibleunits.Text 
        //{
        txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear6rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear6rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear6rateperunit.Text)).ToString();

        //}
        //else if (Convert.ToDecimal(txt_grdyear6rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
        //{
        //    txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear6rateperunit.Text)).ToString();

        //}
        if (txt_grdyear6eligiblerateofreimbursement.Text != "" && txt_grdyear6eligibleamountforreimbursement.Text != "")
        {
            TextBox83.Text = ((Convert.ToDecimal(txt_grdyear6eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear6eligibleamountforreimbursement.Text))).ToString();
        }


        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
          
    }

    protected void txt_grdyear1eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox75.Text = (Convert.ToDecimal(txt_grdyear1eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear1eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }

    protected void txt_grdyear2eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox76.Text = (Convert.ToDecimal(txt_grdyear2eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear2eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }

    protected void txt_grdyear3eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox77.Text = (Convert.ToDecimal(txt_grdyear3eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear3eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }

    protected void txt_grdyear4eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox78.Text = (Convert.ToDecimal(txt_grdyear4eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear4eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }



    protected void txt_grdyear5eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox82.Text = (Convert.ToDecimal(txt_grdyear5eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear5eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }

    protected void txt_grdyear6eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
    {
        TextBox83.Text = (Convert.ToDecimal(txt_grdyear6eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear6eligibleamountforreimbursement.Text)).ToString();
        if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
        {
            lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
        }
    }

    protected void rbtgrd_isbelated_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(lbl_grdtoteligibleamount.Text!="")
        {
            if (rbtgrd_isbelated.SelectedValue.ToString() == "N")
                txt_belatedamount.Text = (Convert.ToDecimal(lbl_grdtoteligibleamount.Text) / 2).ToString();
            if (rbtgrd_isbelated.SelectedValue.ToString() == "R")
                txt_belatedamount.Text = "0";
            if (rbtgrd_isbelated.SelectedValue.ToString() == "Y")
            {
                txt_belatedamount.Text = lbl_grdtoteligibleamount.Text;
            }
            if (txt_belatedamount.Text == "" || txt_belatedamount.Text == null)
            {
                txt_belatedamount.Text = "0";
            }
            if (TextBox192.Text == "" || TextBox192.Text == null)
            {
                TextBox192.Text = "0";
            }
            if (TextBox94.Text == "" || TextBox94.Text == null)
            {
                TextBox94.Text = "0";
            }
            if (TextBox101.Text == "" || TextBox101.Text == null)
            {
                TextBox101.Text = "0";
            }
            lbltotalsubsidyamount.Text = (Convert.ToDecimal(txt_belatedamount.Text) +
                Convert.ToDecimal(TextBox192.Text) + Convert.ToDecimal(TextBox94.Text) + Convert.ToDecimal(TextBox101.Text)).ToString();


        }
    }

    protected void rdbFinYearBothList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string IncentiveId = txtINCNoEntry.Text.ToString();

        string MasterIncentiveId = "3";
        SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        osqlConnection.Open();
        SqlDataAdapter da;
        da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_appeal_PowerTariff", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        ds = new DataSet();
        da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
        da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
        da.Fill(ds);
        osqlConnection.Close();
        if (rdbFinYearBothList.SelectedIndex == 0)
        {
            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Expansion")
            {
                tbl_monthyeardataExpansion.Visible = true;
                tbl_monthyeardataExpansionBoth.Visible = true;
                tblNewUnit.Visible = false;
                tblNewunitBoth.Visible = false;
                txt_grdmonthyear1.Text = "April";
                txt_grdmonthyear2.Text = "May";
                txt_grdmonthyear3.Text = "June";
                txt_grdmonthyear4.Text = "July";
                txt_grdmonthyear5.Text = "August";
                txt_grdmonthyear6.Text = "September";

                TextBox137.Text = "October";
                TextBox146.Text = "November";
                TextBox155.Text = "December";
                TextBox164.Text = "January";
                TextBox173.Text = "February";
                TextBox182.Text = "March";

                txt_grdmonthyear1.Text = ds.Tables[2].Rows[0][0].ToString();
                txt_grdmonthyear2.Text = ds.Tables[2].Rows[1][0].ToString();
                txt_grdmonthyear3.Text = ds.Tables[2].Rows[2][0].ToString();
                txt_grdmonthyear4.Text = ds.Tables[2].Rows[3][0].ToString();
                txt_grdmonthyear5.Text = ds.Tables[2].Rows[4][0].ToString();
                txt_grdmonthyear6.Text = ds.Tables[2].Rows[5][0].ToString();

                TextBox137.Text = ds.Tables[2].Rows[6][0].ToString();
                TextBox146.Text = ds.Tables[2].Rows[7][0].ToString();
                TextBox155.Text = ds.Tables[2].Rows[8][0].ToString();
                TextBox164.Text = ds.Tables[2].Rows[9][0].ToString();
                TextBox173.Text = ds.Tables[2].Rows[10][0].ToString();
                TextBox182.Text = ds.Tables[2].Rows[11][0].ToString();

                txt_grdyear1unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdyear2unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdyear3unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdyear4unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdyear5unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdyear6unitsconsumed.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();

                TextBox138.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox147.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox156.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox165.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox174.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox183.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();

            }
            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "New")
            {
                tbl_monthyeardataExpansion.Visible = false;
                tbl_monthyeardataExpansionBoth.Visible = false;
                tblNewUnit.Visible = true;
                tblNewunitBoth.Visible = true;

                txt_grdmonthyear1New.Text = ds.Tables[2].Rows[0][0].ToString();
                txt_grdmonthyear2New.Text = ds.Tables[2].Rows[1][0].ToString();
                txt_grdmonthyear3New.Text = ds.Tables[2].Rows[2][0].ToString();
                txt_grdmonthyear4New.Text = ds.Tables[2].Rows[3][0].ToString();
                txt_grdmonthyear5New.Text = ds.Tables[2].Rows[4][0].ToString();
                txt_grdmonthyear6New.Text = ds.Tables[2].Rows[5][0].ToString();

                TextBox84.Text = ds.Tables[2].Rows[6][0].ToString();
                TextBox102.Text = ds.Tables[2].Rows[7][0].ToString();
                TextBox109.Text = ds.Tables[2].Rows[8][0].ToString();
                TextBox116.Text = ds.Tables[2].Rows[9][0].ToString();
                TextBox123.Text = ds.Tables[2].Rows[10][0].ToString();
                TextBox130.Text = ds.Tables[2].Rows[11][0].ToString();

                txt_grdmonthyear1NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdmonthyear2NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdmonthyear3NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdmonthyear4NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdmonthyear5NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();
                txt_grdmonthyear6NewFinyear.Text = ds.Tables[0].Rows[0]["FinancialYear1"].ToString();

                TextBox85.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox103.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox110.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox117.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox124.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();
                TextBox131.Text = ds.Tables[0].Rows[0]["FinancialYear2"].ToString();

                if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                {



                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1";
                        TextBox107.Text = "1";
                        TextBox114.Text = "1";
                        TextBox121.Text = "1";
                        TextBox128.Text = "1";
                        TextBox135.Text = "1";
                    }

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;
                }

                if (lblSchemeName.Text == "IIPP Scheme 2010 - 2015")
                {
                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "0.75";
                        TextBox107.Text = "0.75";
                        TextBox114.Text = "0.75";
                        TextBox121.Text = "0.75";
                        TextBox128.Text = "0.75";
                        TextBox135.Text = "0.75";
                    }

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;



                }

                if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                {

                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1";
                        TextBox107.Text = "1";
                        TextBox114.Text = "1";
                        TextBox121.Text = "1";
                        TextBox128.Text = "1";
                        TextBox135.Text = "1";
                    }


                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;

                }

                else if (lblSchemeName.Text == "T-IDEA")
                {

                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1";
                        TextBox107.Text = "1";
                        TextBox114.Text = "1";
                        TextBox121.Text = "1";
                        TextBox128.Text = "1";
                        TextBox135.Text = "1";
                    }
                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;


                }

                if (lblSchemeName.Text == "T-PRIDE")
                {

                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1.5";
                        TextBox107.Text = "1.5";
                        TextBox114.Text = "1.5";
                        TextBox121.Text = "1.5";
                        TextBox128.Text = "1.5";
                        TextBox135.Text = "1.5";
                    }

                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;
                }
                if (lblSchemeName.Text == "T-PRIDE(PHC)" && lblSchemeName.Text != "IIPP Scheme 2010 - 2015" && lblSchemeName.Text == "IIPP Scheme 2005 - 2010")

                {

                    if (rdbFinYearBothList.SelectedIndex == 0 && Session["IdsustryStatus"].ToString() != "Expansion")
                    {
                        TextBox92.Text = "1.5";
                        TextBox107.Text = "1.5";
                        TextBox114.Text = "1.5";
                        TextBox121.Text = "1.5";
                        TextBox128.Text = "1.5";
                        TextBox135.Text = "1.5";
                    }
                    //TextBox92.Enabled = false;
                    //TextBox107.Enabled = false;
                    //TextBox114.Enabled = false;
                    //TextBox121.Enabled = false;
                    //TextBox128.Enabled = false;
                    //TextBox135.Enabled = false;


                }
            }



   
        }
        if (rdbFinYearBothList.SelectedIndex == 1)
        {
            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Expansion")
            {
                tbl_monthyeardataExpansion.Visible = true;
                tbl_monthyeardataExpansionBoth.Visible = false;
                tblNewUnit.Visible = false;
                tblNewunitBoth.Visible = false;
            }
            if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "New")
            {
                tbl_monthyeardataExpansion.Visible = false;
                tbl_monthyeardataExpansionBoth.Visible = false;
                tblNewUnit.Visible = true;
                tblNewunitBoth.Visible = false;

            }
        }

            
    }

    protected void TextBox7775_TextChanged(object sender, EventArgs e)
    {
        string test = Session["socialStatus"].ToString();
        txt_grdyear1eligibleunits.Text = TextBox7775.Text;
        txt_grdyear2eligibleunits.Text = TextBox7775.Text;
        txt_grdyear3eligibleunits.Text = TextBox7775.Text;
        txt_grdyear4eligibleunits.Text = TextBox7775.Text;
        txt_grdyear5eligibleunits.Text = TextBox7775.Text;
        txt_grdyear6eligibleunits.Text = TextBox7775.Text;

        if (lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
        {
            if (Session["socialStatus"].ToString() == "General" || Session["socialStatus"].ToString() == "OBC")
            {
                txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



            }
            else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
            {


                txt_grdyear1eligibleamountforreimbursement.Text = "1";
                txt_grdyear2eligibleamountforreimbursement.Text = "1";
                txt_grdyear3eligibleamountforreimbursement.Text = "1";
                txt_grdyear4eligibleamountforreimbursement.Text = "1";
                txt_grdyear5eligibleamountforreimbursement.Text = "1";
                txt_grdyear6eligibleamountforreimbursement.Text = "1";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


            }


        }

        else if (lblSchemeName.Text == "IIPP Scheme 2010 - 2015")
        {
            if (Session["socialStatus"].ToString() == "General" || Session["socialStatus"].ToString() == "OBC")
            {


                txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


            }
            else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
            {




                txt_grdyear1eligibleamountforreimbursement.Text = "1";
                txt_grdyear2eligibleamountforreimbursement.Text = "1";
                txt_grdyear3eligibleamountforreimbursement.Text = "1";
                txt_grdyear4eligibleamountforreimbursement.Text = "1";
                txt_grdyear5eligibleamountforreimbursement.Text = "1";
                txt_grdyear6eligibleamountforreimbursement.Text = "1";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;
            }

        }
        else if (lblSchemeName.Text == "T-IDEA")
        {

            txt_grdyear1eligibleamountforreimbursement.Text = "1";
            txt_grdyear2eligibleamountforreimbursement.Text = "1";
            txt_grdyear3eligibleamountforreimbursement.Text = "1";
            txt_grdyear4eligibleamountforreimbursement.Text = "1";
            txt_grdyear5eligibleamountforreimbursement.Text = "1";
            txt_grdyear6eligibleamountforreimbursement.Text = "1";



            //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



        }
        else if (lblSchemeName.Text == "T-PRIDE")
        {


            txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



            //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear6eligibleamountforreimbursement.Enabled = false;

        }
        else if (lblSchemeName.Text == "T-PRIDE(PHC)" && lblSchemeName.Text != "IIPP Scheme 2010 - 2015" && lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
        {


            txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
            txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



            //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
            //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


        }


    }

    protected void TextBox90_TextChanged(object sender, EventArgs e)
    {
        if(TextBox92.Text=="" || TextBox107.Text == ""|| TextBox114.Text == ""|| TextBox121.Text == ""|| TextBox128.Text == ""|| TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }
        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();
                TextBox99.Text = (Convert.ToDecimal(TextBox86.Text) * Convert.ToDecimal(TextBox92.Text)).ToString();

                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
        }
    
    




    }

    

    protected void TextBox105_TextChanged(object sender, EventArgs e)
    {
        if (TextBox92.Text == "" || TextBox107.Text == "" || TextBox114.Text == "" || TextBox121.Text == "" || TextBox128.Text == "" || TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }

        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();

                if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
                {
                    Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox106.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text)).ToString();

                    //Label2.Text = Session["GM_Rcon_Amount"].ToString();


                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                TextBox108.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox107.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }


            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                TextBox115.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox114.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }

        }

    }

    protected void TextBox112_TextChanged(object sender, EventArgs e)
    {
        if (TextBox92.Text == "" || TextBox107.Text == "" || TextBox114.Text == "" || TextBox121.Text == "" || TextBox128.Text == "" || TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }

        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();

                if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")

                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();


                    //Label2.Text = Session["GM_Rcon_Amount"].ToString();


                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }


            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                TextBox115.Text = (Convert.ToDecimal(TextBox114.Text) * Convert.ToDecimal(TextBox111.Text)).ToString();

                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }

        }
      

    }

    protected void TextBox119_TextChanged(object sender, EventArgs e)
    {
        if (TextBox92.Text == "" || TextBox107.Text == "" || TextBox114.Text == "" || TextBox121.Text == "" || TextBox128.Text == "" || TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }
        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();

                if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                    //Label2.Text = Session["GM_Rcon_Amount"].ToString();


                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();
                }


            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();
                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                TextBox122.Text = (Convert.ToDecimal(TextBox121.Text) * Convert.ToDecimal(TextBox118.Text)).ToString();

                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();
                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();
                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();
                }

            }
        }
     

    }

    protected void TextBox126_TextChanged(object sender, EventArgs e)
    {
        if (TextBox92.Text == "" || TextBox107.Text == "" || TextBox114.Text == "" || TextBox121.Text == "" || TextBox128.Text == "" || TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }
        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();

                if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                    //Label2.Text = Session["GM_Rcon_Amount"].ToString();


                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                //TextBox99.Text
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }


            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                TextBox129.Text = (Convert.ToDecimal(TextBox128.Text) * Convert.ToDecimal(TextBox125.Text)).ToString();

                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
        }
  

    }

    protected void TextBox133_TextChanged(object sender, EventArgs e)
    {
        if (TextBox92.Text == "" || TextBox107.Text == "" || TextBox114.Text == "" || TextBox121.Text == "" || TextBox128.Text == "" || TextBox135.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
            TextBox86.Text = "";
            TextBox104.Text = "";
            TextBox111.Text = "";
            TextBox118.Text = "";
            TextBox125.Text = "";
            TextBox132.Text = "";

            TextBox90.Text = "";
            TextBox105.Text = "";
            TextBox112.Text = "";
            TextBox119.Text = "";
            TextBox126.Text = "";
            TextBox133.Text = "";
        }
        else
        {
            if (TextBox90.Text != "" && TextBox86.Text != "")
            {
                TextBox91.Text = (Convert.ToDecimal(TextBox90.Text) * Convert.ToDecimal(TextBox86.Text)).ToString();

                if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();


                    //Label2.Text = Session["GM_Rcon_Amount"].ToString();


                }
            }

            if (TextBox104.Text != "" && TextBox105.Text != "")
            {
                TextBox106.Text = (Convert.ToDecimal(TextBox104.Text) * Convert.ToDecimal(TextBox105.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }


            }
            if (TextBox111.Text != "" && TextBox112.Text != "")
            {
                TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox118.Text != "" && TextBox119.Text != "")
            {
                TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox125.Text != "" && TextBox126.Text != "")
            {
                TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
            if (TextBox132.Text != "" && TextBox133.Text != "")
            {
                TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();
                TextBox136.Text = (Convert.ToDecimal(TextBox135.Text) * Convert.ToDecimal(TextBox132.Text)).ToString();
                if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                {
                    if (TextBox99.Text != "" && TextBox108.Text != "" && TextBox115.Text != "" && TextBox122.Text != "" && TextBox129.Text != "" && TextBox136.Text != "")
                        Label2.Text = (Convert.ToDecimal(TextBox99.Text) + Convert.ToDecimal(TextBox108.Text) + Convert.ToDecimal(TextBox115.Text) + Convert.ToDecimal(TextBox122.Text) + Convert.ToDecimal(TextBox129.Text) + Convert.ToDecimal(TextBox136.Text)).ToString();

                }

            }
        }
    

    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblGmAmount0.Text != "" && TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
        {
            if (RadioButtonList2.SelectedValue.ToString() == "N")
            {

                decimal a = Convert.ToDecimal(Label2.Text);
                decimal b = Convert.ToDecimal(lblGmAmount.Text);
                decimal c = a / 2;  //coi - calculated
                if (c < b)
                {
                    TextBox100.Text = c.ToString();
                }
                if (b < c)
                {
                    TextBox100.Text = b.ToString();
                }
                if (b == c)
                {
                    TextBox100.Text = b.ToString();
                }
                TextBox101.Text = TextBox100.Text;
            }
            if (RadioButtonList2.SelectedValue.ToString() == "Y")
            {
                decimal a = Convert.ToDecimal(Label2.Text);
                decimal b = Convert.ToDecimal(lblGmAmount.Text);

                if (a < b)
                {
                    TextBox100.Text = a.ToString();
                }

                if (b < a)
                {
                    TextBox100.Text = b.ToString();
                }
                if (b == a)
                {
                    TextBox100.Text = b.ToString();
                }

                TextBox101.Text = TextBox100.Text;
            }
            if (RadioButtonList2.SelectedValue.ToString() == "R")
            {
                TextBox100.Text = "0";
                TextBox101.Text = TextBox100.Text;

            }
            if (txt_belatedamount.Text == "" || txt_belatedamount.Text == null)
            {
                txt_belatedamount.Text = "0";
            }
            if (TextBox192.Text == "" || TextBox192.Text == null)
            {
                TextBox192.Text = "0";
            }
            if (TextBox94.Text == "" || TextBox94.Text == null)
            {
                TextBox94.Text = "0";
            }
            if (TextBox101.Text == "" || TextBox101.Text == null)
            {
                TextBox101.Text = "0";
            }

            if ((Convert.ToDecimal(txt_belatedamount.Text) +
                Convert.ToDecimal(TextBox192.Text) + Convert.ToDecimal(TextBox94.Text) + Convert.ToDecimal(TextBox101.Text)) > Convert.ToDecimal(lblGmAmount.Text))
            {
                lbltotalsubsidyamount.Text = lblGmAmount.Text;
            }

            else
            {

                lbltotalsubsidyamount.Text = (Convert.ToDecimal(txt_belatedamount.Text) +
                    Convert.ToDecimal(TextBox192.Text) + Convert.ToDecimal(TextBox94.Text) + Convert.ToDecimal(TextBox101.Text)).ToString();
            }

        }

        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all values!');", true);
    }

    protected void TextBox86_TextChanged(object sender, EventArgs e)
    {
        if (TextBox90.Text != "" && TextBox86.Text != "")
        {
            TextBox91.Text = (Convert.ToDecimal(TextBox86.Text) * Convert.ToDecimal(TextBox90.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                //Label2.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
    }

    protected void TextBox104_TextChanged(object sender, EventArgs e)
    {
        if (TextBox105.Text != "" && TextBox104.Text != "")
        {
            TextBox106.Text = (Convert.ToDecimal(TextBox105.Text) * Convert.ToDecimal(TextBox104.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                //Label2.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
    }

    protected void TextBox111_TextChanged(object sender, EventArgs e)
    {
        if (TextBox112.Text != "" && TextBox111.Text != "")
        {
            TextBox113.Text = (Convert.ToDecimal(TextBox111.Text) * Convert.ToDecimal(TextBox112.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                //Label2.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
    }

    protected void TextBox118_TextChanged(object sender, EventArgs e)
    {
        if (TextBox118.Text != "" && TextBox119.Text != "")
        {
            TextBox120.Text = (Convert.ToDecimal(TextBox118.Text) * Convert.ToDecimal(TextBox119.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                //Label2.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
    }

    protected void TextBox125_TextChanged(object sender, EventArgs e)
    {
        if (TextBox125.Text != "" && TextBox126.Text != "")
        {
            TextBox127.Text = (Convert.ToDecimal(TextBox125.Text) * Convert.ToDecimal(TextBox126.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                //Label2.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
    }

    protected void TextBox132_TextChanged(object sender, EventArgs e)
    {
        if (TextBox132.Text != "" && TextBox133.Text != "")
        {
            TextBox134.Text = (Convert.ToDecimal(TextBox132.Text) * Convert.ToDecimal(TextBox133.Text)).ToString();

            if (TextBox91.Text != "" && TextBox106.Text != "" && TextBox113.Text != "" && TextBox120.Text != "" && TextBox127.Text != "" && TextBox134.Text != "")
            {
                Label2.Text = (Convert.ToDecimal(TextBox91.Text) + Convert.ToDecimal(TextBox113.Text) + Convert.ToDecimal(TextBox120.Text) + Convert.ToDecimal(TextBox127.Text) + Convert.ToDecimal(TextBox134.Text) + Convert.ToDecimal(TextBox106.Text)).ToString();

                Label3.Text = Session["GM_Rcon_Amount"].ToString();


            }



        }
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
                trServiceType.Visible = true;
                rdbTransportNonTrans.Enabled = true;
                trsubmit.Visible = false;

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


    }

    protected void rdbServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbServiceType.Enabled = false;
        rdbTransportNonTrans.Enabled = true;
        trTransNonTrans.Visible = true;
        rdbTransportNonTrans.Enabled = true;
    }
}

        #endregion


    




