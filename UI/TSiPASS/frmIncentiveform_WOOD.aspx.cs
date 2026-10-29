using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class UI_TSiPASS_frmIncentiveform_WOOD : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    PCBClass objPCB = new PCBClass();
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    DataTable myDtNewPowerdr = new DataTable();
    DataTable myDtNewEnergydr = new DataTable();

    static DataTable dtPower1;
    static DataTable dtPower2;

    static DataTable dtEnergy1;
    static DataTable dtEnergy2;

    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["uid"].ToString() != "48696" && Session["uid"].ToString() != "90212" && Session["uid"].ToString() != "72763" && Session["uid"].ToString() != "37708")
        //{
        //    Response.Redirect("frmincentiveformtransportduty.aspx?next=" + "N");
        //}

        success.Visible = false;
        Failure.Visible = false;


        if (!IsPostBack)
        {
            lblwood.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF WOOD </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014, Read with G.O.Ms.No.18, dated.21/03/2018)</center>";

            if (Session["incentivedata"] != null)
            {


                string userid = Session["uid"].ToString();
                string IncentveID = Session["EntprIncentive"].ToString();
                //DataSet dscaste = new DataSet();
                //dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                //string IndustryStatus = dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                //if (IndustryStatus == "2" || IndustryStatus == "3")
                //{
                //    trSalesTaxExpansion.Visible = true;
                //}
                //else
                //{
                //    trSalesTaxExpansion.Visible = false;
                //}

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 19);  // Sales TAX(VAT/GST/SGST) Reimbursement
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("frmincentiveformtransportduty.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmIncentiveform_COAL.aspx?Previous=" + "P");
                    }
                }
  
                BindFinancialYears1(ddlFinYearWOOD, "3", IncentveID);
                DataSet dsdisable = new DataSet();
                dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);

                if (dsdisable.Tables.Count > 0 && dsdisable.Tables[6].Rows.Count > 0)
                {
                    string applicationStatus = "";
                    applicationStatus = dsdisable.Tables[6].Rows[0]["intStatusid"].ToString();
                    if (applicationStatus != "")
                    {
                        if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                        {
                            ResetFormControl(this);
                        }

                    }
                }


            }
        }
        if (!IsPostBack)
        {
            FillDetails();

        }
    }
    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
        //int IncentiveId = Convert.ToInt32("11");
        ds = GetWOODIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0) //&& ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDNWOODID.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                ddlFinYearWOOD.SelectedValue = ds.Tables[0].Rows[0]["FinancialYearNew"].ToString();
                ddlFin1stOr2ndHalfyear.SelectedValue = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
                ddlFirstorSecondQUarter.SelectedValue = ds.Tables[0].Rows[0]["FirstorsecondQuarter"].ToString();
                if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
                {
                    if (ddlFirstorSecondQUarter.SelectedValue == "1")
                    {
                        trFin1stHalf1stquarter.Visible = true;
                        txt1stHalf1stquarterAmountPaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountPaid"].ToString();
                        txt1stHalf1stquarterAmountClaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear1stquarterAmountclaimed"].ToString();
                        trfirsthalfyearsecondquarter.Visible = false;
                        trFin2ndHalf1stquarter.Visible = false;
                        trFin2ndHalf2ndquarter.Visible = false;

                    }
                    if (ddlFirstorSecondQUarter.SelectedValue == "2")
                    {
                        trFin1stHalf1stquarter.Visible = false;
                        trfirsthalfyearsecondquarter.Visible = true;
                        txt1stHalf2ndquarterAmountPaid.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountPaid"].ToString();
                        txt1stHalf2ndquarterAmountClaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyear2ndquarterAmountclaimed"].ToString();
                        trFin2ndHalf1stquarter.Visible = false;
                        trFin2ndHalf2ndquarter.Visible = false;

                    }
                }
                if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
                {
                    if (ddlFirstorSecondQUarter.SelectedValue == "")
                    {
                        trFin1stHalf1stquarter.Visible = false;
                        trfirsthalfyearsecondquarter.Visible = false;
                        trFin2ndHalf1stquarter.Visible = true;
                        txt2ndHalf1stquarterAmountPaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountPaid"].ToString();
                        txt2ndHalf1stquarterAmountClaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear1stquarterAmountclaimed"].ToString();
                        trFin2ndHalf2ndquarter.Visible = false;

                    }
                    if (ddlFirstorSecondQUarter.SelectedValue == "2")
                    {
                        trFin1stHalf1stquarter.Visible = false;
                        trfirsthalfyearsecondquarter.Visible = false;
                        trFin2ndHalf1stquarter.Visible = false;
                        trFin2ndHalf2ndquarter.Visible = true;
                        txt2ndHalf2ndquarterAmountPaid.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountPaid"].ToString();
                        txt2ndHalf2ndquarterAmountClaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyear2ndquarterAmountclaimed"].ToString();

                    }
                }
                TXTADMTQUANTITY.Text = ds.Tables[0].Rows[0]["Quantity_WOOD"].ToString();
                txtunitofmeasurement.Text = ds.Tables[0].Rows[0]["UnitMeasurement_WOOD"].ToString();
                TXTAMOUNTPAID.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
                TXTCLAIMAMOUNT.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
                txtpaperquantity.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
                txtunitmeasurement_paper.Text = ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();
                rbtwoodsanctioned.SelectedValue = ds.Tables[0].Rows[0]["ISPREVIOUSLYWOODSANCTIONED"].ToString();
                if (rbtwoodsanctioned.SelectedValue == "Y")
                {
                    tdquartera.Visible = true;
                    tdquarterb.Visible = true;
                    tdquarterc.Visible = true;
                    tdquarterd.Visible = true;
                    ddlnoofquarterssanctioned.SelectedValue = ds.Tables[0].Rows[0]["NOOFQUARTERSPREVIOUSLYSANCTIONED"].ToString();
                    if (ddlnoofquarterssanctioned.SelectedValue == "1")
                    {
                        trfirstquarterQuantity.Visible = true;
                        TXTFIRSTQTRQTY.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                        trSecondquarterQuantity.Visible = false;
                        trThirdquarterQuantity.Visible = false;
                    }
                    if (ddlnoofquarterssanctioned.SelectedValue == "2")
                    {
                        trfirstquarterQuantity.Visible = true;
                        TXTFIRSTQTRQTY.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                        trSecondquarterQuantity.Visible = true;
                        TXTSECONDQTRQTY.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                        trThirdquarterQuantity.Visible = false;
                    }
                    if (ddlnoofquarterssanctioned.SelectedValue == "3")
                    {
                        trfirstquarterQuantity.Visible = true;
                        TXTFIRSTQTRQTY.Text = ds.Tables[0].Rows[0]["FIRSTQUARTERQTY"].ToString();
                        trSecondquarterQuantity.Visible = true;
                        TXTSECONDQTRQTY.Text = ds.Tables[0].Rows[0]["SECONDQUARTERQTY"].ToString();
                        trThirdquarterQuantity.Visible = true;
                        TXTTHIRDQTRQTY.Text = ds.Tables[0].Rows[0]["THIRDQUARTERQTY"].ToString();
                    }

                }
                else
                {
                    tdquartera.Visible = false;
                    tdquarterb.Visible = false;
                    tdquarterc.Visible = false;
                    tdquarterd.Visible = false;
                }


            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();

                    sen2 = dr["FilePath"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (AttcahmentId == "191")
                    {
                        HYPTSFDC.NavigateUrl = sen;
                        HYPTSFDC.Text = dr["FileNm"].ToString();
                        LBLTSFDC.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "192")
                    {
                        HYPCACERTIFICATE.NavigateUrl = sen;
                        HYPCACERTIFICATE.Text = dr["FileNm"].ToString();
                        LBLCACERTIFICATE.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "193")
                    {
                        hypproofofpaymentreceipts.NavigateUrl = sen;
                        hypproofofpaymentreceipts.Text = dr["FileNm"].ToString();
                        lblproofofpaymentreceipts.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "194")
                    {
                        HYPCACERTIFICATEPAPER.NavigateUrl = sen;
                        HYPCACERTIFICATEPAPER.Text = dr["FileNm"].ToString();
                        LBLCACERTIFICATEPAPER.Text = dr["FileNm"].ToString();
                    }
                    if (AttcahmentId == "195")
                    {
                        HYPFUPCACERTIFICATEADMT.NavigateUrl = sen;
                        HYPFUPCACERTIFICATEADMT.Text = dr["FileNm"].ToString();
                        LBLFUPCACERTIFICATEADMT.Text = dr["FileNm"].ToString();
                    }
                    if (AttcahmentId == "196")
                    {
                        HypCFOCOPY.NavigateUrl = sen;
                        HypCFOCOPY.Text = dr["FileNm"].ToString();
                        LBLCFOCOPY.Text = dr["FileNm"].ToString();
                    }
                }

            }
        }

    }
    public DataSet GetWOODIncentives(int incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_WOODInentives", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = incentiveid;
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
    private void BindFinancialYears(DropDownList ddlFinYear, string Count, string IncentveID)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, IncentveID);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlFinYear.DataSource = dsYears.Tables[0];
            ddlFinYear.DataTextField = "FinancialYear";
            ddlFinYear.DataValueField = "SlNo";
            ddlFinYear.DataBind();
        }
        ddlFinYear.Items.Insert(0, "--Select--");

    }
    private void BindFinancialYears1(DropDownList ddlFinYear, string Count, string IncentveID)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives("WOOD", IncentveID);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlFinYear.DataSource = dsYears.Tables[0];
            ddlFinYear.DataTextField = "FinancialYear";
            ddlFinYear.DataValueField = "SlNo";
            ddlFinYear.DataBind();
        }
        ddlFinYear.Items.Insert(0, "--Select--");

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveform_COAL.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;
        
        //if (HyperLink2.Text == "" || HyperLink2.Text == null)
        //{
        //    lblmsg0.Text = "Please Uppload the documents";
        //    Failure.Visible = true;
        //    Button2.Focus();
        //    start = 1;
        //}
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "5", "Y", "");
            Response.Redirect("FinalPage.aspx?next=" + "N");
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int start = 0;
        int valid = 0;
        int out2 = 0;
        try
        {


            //ds = (DataSet)Session["incentivedata"];
            //string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            // UpdateAnnexureflag(IncentiveId, "5", "Y", ""); reference
            DataSet ds1 = new DataSet();
            ds1 = InsertWoodAnnexureDetails(Session["EntprIncentive"].ToString(), "19", ddlFinYearWOOD.SelectedValue, ddlFin1stOr2ndHalfyear.SelectedValue, ddlFirstorSecondQUarter.SelectedValue,
                TXTADMTQUANTITY.Text, txtunitofmeasurement.Text, TXTAMOUNTPAID.Text, TXTCLAIMAMOUNT.Text, txt1stHalf1stquarterAmountPaid.Text, txt1stHalf1stquarterAmountClaimed.Text,
                txt1stHalf2ndquarterAmountPaid.Text, txt1stHalf2ndquarterAmountClaimed.Text,
                txt2ndHalf1stquarterAmountPaid.Text, txt2ndHalf1stquarterAmountClaimed.Text,
                txt2ndHalf2ndquarterAmountPaid.Text, txt2ndHalf2ndquarterAmountClaimed.Text, 
                txtpaperquantity.Text,txtunitmeasurement_paper.Text, Session["uid"].ToString(), HDNWOODID.Value, rbtwoodsanctioned.SelectedValue, ddlnoofquarterssanctioned.SelectedValue,
                TXTFIRSTQTRQTY.Text, TXTSECONDQTRQTY.Text, TXTTHIRDQTRQTY.Text);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                string a;
                a = ds1.Tables[0].Rows[0]["value"].ToString();
                if (a == "1")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Saved Successfully')", true);
                    BtnSave1.Enabled = false;
                    BtnDelete.Enabled = true;
                    return;
                }
                if (a == "2")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    BtnSave1.Enabled = false;
                    BtnDelete.Enabled = true;
                    return;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Filed To Insert')", true);
                //BtnSave.Enabled = false;
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet InsertWoodAnnexureDetails(string Incentiveid, string MasterIncentiveid,
string Financialyear, string FirstorSecondHalf, string FirstorsecondQuarter, string Quantity_WOOD,
string UnitMeasurement_WOOD,string AmountPaid, string Amountclaimed, 
string FirstHalfyear1stquarterAmountPaid,string FirstHalfyear1stquarterAmountclaimed,
string FirstHalfyear2ndquarterAmountPaid, string FirstHalfyear2ndquarterAmountclaimed,
string SecondHalfyear1stquarterAmountPaid, string SecondHalfyear1stquarterAmountclaimed,
string SecondHalfyear2ndquarterAmountPaid, string SecondHalfyear2ndquarterAmountclaimed,
string Quantity_paper, string UnitMeasurement_paper,string createdby,string WOODID,
string ISPREVIOUSLYWOODSANCTIONED, string NOOFQUARTERSPREVIOUSLYSANCTIONED, 
string FIRSTQUARTERQTY, string SECONDQUARTERQTY, string THIRDQUARTERQTY)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_INSERTWOODDETAILS", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = Incentiveid.ToString();
            da.SelectCommand.Parameters.Add("@MasterIncentiveid", SqlDbType.VarChar).Value = MasterIncentiveid.ToString();
            if (Financialyear.Trim() == "" || Financialyear.Trim() == null || Financialyear.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Financialyear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Financialyear", SqlDbType.VarChar).Value = Financialyear.ToString();
            if (FirstorSecondHalf.Trim() == "" || FirstorSecondHalf.Trim() == null || FirstorSecondHalf.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstorSecondHalf", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstorSecondHalf", SqlDbType.VarChar).Value = FirstorSecondHalf.ToString();
            if (FirstorsecondQuarter.Trim() == "" || FirstorsecondQuarter.Trim() == null || FirstorsecondQuarter.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstorsecondQuarter", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstorsecondQuarter", SqlDbType.VarChar).Value = FirstorsecondQuarter.ToString();

            if (Quantity_WOOD.Trim() == "" || Quantity_WOOD.Trim() == null || Quantity_WOOD.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Quantity_WOOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Quantity_WOOD", SqlDbType.VarChar).Value = Quantity_WOOD.ToString();
            if (UnitMeasurement_WOOD.Trim() == "" || UnitMeasurement_WOOD.Trim() == null || UnitMeasurement_WOOD.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@UnitMeasurement_WOOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@UnitMeasurement_WOOD", SqlDbType.VarChar).Value = UnitMeasurement_WOOD.ToString();


            if (AmountPaid.Trim() == "" || AmountPaid.Trim() == null)
            {
                da.SelectCommand.Parameters.Add("@AmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@AmountPaid", SqlDbType.VarChar).Value = AmountPaid.ToString();
            if (Amountclaimed.Trim() == "" || Amountclaimed.Trim() == null || Amountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Amountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Amountclaimed", SqlDbType.VarChar).Value = Amountclaimed.ToString();
            if (FirstHalfyear1stquarterAmountPaid.Trim() == "" || FirstHalfyear1stquarterAmountPaid.Trim() == null || FirstHalfyear1stquarterAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyear1stquarterAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyear1stquarterAmountPaid", SqlDbType.VarChar).Value = FirstHalfyear1stquarterAmountPaid.ToString();

            if (FirstHalfyear1stquarterAmountclaimed.Trim() == "" || FirstHalfyear1stquarterAmountclaimed.Trim() == null || FirstHalfyear1stquarterAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyear1stquarterAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyear1stquarterAmountclaimed", SqlDbType.VarChar).Value = FirstHalfyear1stquarterAmountclaimed.ToString();

            if (FirstHalfyear2ndquarterAmountPaid.Trim() == "" || FirstHalfyear2ndquarterAmountPaid.Trim() == null || FirstHalfyear2ndquarterAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyear2ndquarterAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyear2ndquarterAmountPaid", SqlDbType.VarChar).Value = FirstHalfyear2ndquarterAmountPaid.ToString();

            if (FirstHalfyear2ndquarterAmountclaimed.Trim() == "" || FirstHalfyear2ndquarterAmountclaimed.Trim() == null || FirstHalfyear2ndquarterAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyear2ndquarterAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyear2ndquarterAmountclaimed", SqlDbType.VarChar).Value = FirstHalfyear2ndquarterAmountclaimed.ToString();



            if (SecondHalfyear1stquarterAmountPaid.Trim() == "" || SecondHalfyear1stquarterAmountPaid.Trim() == null || SecondHalfyear1stquarterAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyear1stquarterAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyear1stquarterAmountPaid", SqlDbType.VarChar).Value = SecondHalfyear1stquarterAmountPaid.ToString();

            if (SecondHalfyear1stquarterAmountclaimed.Trim() == "" || SecondHalfyear1stquarterAmountclaimed.Trim() == null || SecondHalfyear1stquarterAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyear1stquarterAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyear1stquarterAmountclaimed", SqlDbType.VarChar).Value = SecondHalfyear1stquarterAmountclaimed.ToString();

            if (SecondHalfyear2ndquarterAmountPaid.Trim() == "" || SecondHalfyear2ndquarterAmountPaid.Trim() == null || SecondHalfyear2ndquarterAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyear2ndquarterAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyear2ndquarterAmountPaid", SqlDbType.VarChar).Value = SecondHalfyear2ndquarterAmountPaid.ToString();

            if (SecondHalfyear2ndquarterAmountclaimed.Trim() == "" || SecondHalfyear2ndquarterAmountclaimed.Trim() == null || SecondHalfyear2ndquarterAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyear2ndquarterAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyear2ndquarterAmountclaimed", SqlDbType.VarChar).Value = SecondHalfyear2ndquarterAmountclaimed.ToString();

            if (Quantity_paper.Trim() == "" || Quantity_paper.Trim() == null || Quantity_paper.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Quantity_paper", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Quantity_paper", SqlDbType.VarChar).Value = Quantity_paper.ToString();

            if (UnitMeasurement_paper.Trim() == "" || UnitMeasurement_paper.Trim() == null || UnitMeasurement_paper.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@UnitMeasurement_paper", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@UnitMeasurement_paper", SqlDbType.VarChar).Value = UnitMeasurement_paper.ToString();



            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();
            if (WOODID.Trim() == "" || WOODID.Trim() == null || WOODID.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@WOODID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@WOODID", SqlDbType.VarChar).Value = WOODID.ToString();
            

            if (ISPREVIOUSLYWOODSANCTIONED.Trim() == "" || ISPREVIOUSLYWOODSANCTIONED.Trim() == null || ISPREVIOUSLYWOODSANCTIONED.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ISPREVIOUSLYWOODSANCTIONED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ISPREVIOUSLYWOODSANCTIONED", SqlDbType.VarChar).Value = ISPREVIOUSLYWOODSANCTIONED.ToString();
            if (NOOFQUARTERSPREVIOUSLYSANCTIONED.Trim() == "" || NOOFQUARTERSPREVIOUSLYSANCTIONED.Trim() == null || NOOFQUARTERSPREVIOUSLYSANCTIONED.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@NOOFQUARTERSPREVIOUSLYSANCTIONED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@NOOFQUARTERSPREVIOUSLYSANCTIONED", SqlDbType.VarChar).Value = NOOFQUARTERSPREVIOUSLYSANCTIONED.ToString();
          
            if (FIRSTQUARTERQTY.Trim() == "" || FIRSTQUARTERQTY.Trim() == null || FIRSTQUARTERQTY.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FIRSTQUARTERQTY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FIRSTQUARTERQTY", SqlDbType.VarChar).Value = FIRSTQUARTERQTY.ToString();
            if (SECONDQUARTERQTY.Trim() == "" || SECONDQUARTERQTY.Trim() == null || SECONDQUARTERQTY.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SECONDQUARTERQTY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SECONDQUARTERQTY", SqlDbType.VarChar).Value = SECONDQUARTERQTY.ToString();
            if (THIRDQUARTERQTY.Trim() == "" || THIRDQUARTERQTY.Trim() == null || THIRDQUARTERQTY.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@THIRDQUARTERQTY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@THIRDQUARTERQTY", SqlDbType.VarChar).Value = THIRDQUARTERQTY.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (osqlConnection.State != ConnectionState.Closed)
                osqlConnection.Close();
        }
    }
    //protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlquantityin.SelectedValue.ToString() == "Others")
    //    {
    //        txtUnitsConsumed.Visible = true;
    //        ddlquantityin.Visible = true;
    //    }
    //    else
    //    {
    //        txtUnitsConsumed.Visible = false;
    //        ddlquantityin.Visible = true;
    //    }

    //}
    protected void btnPowerClear_Click(object sender, EventArgs e)
    {
        //ddlFinYearPower.SelectedValue = "--Select--";
        //txtUnitsConsumed.Text = "";
        //txtUnitsConsumed.Visible = false;
        //ddlquantityin.SelectedValue = "--Select--";
        //ddlquantityin.Visible = true;
        //txtAmountPaid.Text = "";
        //txtvalue.Text = "";

    }
    protected void btnEnergyClear_Click(object sender, EventArgs e)
    {
        ddlFinYearWOOD.SelectedValue = "--Select--";
        //txt1stHalfAmountPaid.Text = "";
        //txt1stHalfUnitConsumed.Text = "";
        //txt2ndHalfAmountPaid.Text = "";
        //txt2ndHalfUnitConsumed.Text = "";
    }
    //protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
    //    {
    //        trFin1stHalfYear.Visible = true;
    //        trFin2ndHalfYear.Visible = false;
    //    }
    //    else if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
    //    {
    //        trFin1stHalfYear.Visible = false;
    //        trFin2ndHalfYear.Visible = true;
    //    }
    //    else
    //    {
    //        trFin1stHalfYear.Visible = true;
    //        trFin2ndHalfYear.Visible = true;
    //    }

    //}
    public int UpdateAnnexureflag(string EnterperIncentiveID, string MstIncentiveId, string flag, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_ANNEXUREFLA_INCENTIVE";

        if (EnterperIncentiveID == "" || EnterperIncentiveID == null)
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID.Trim();

        if (MstIncentiveId == "" || MstIncentiveId == null)
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
    public void ResetFormControl(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).ReadOnly = true;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).Enabled = false;
                            }
                            break;
                        case "System.Web.UI.WebControls.FileUpload":
                            ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnproofofpaymentreceipts_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (fupproofofpaymentreceipts.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupproofofpaymentreceipts.PostedFile != null) && (fupproofofpaymentreceipts.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(fupproofofpaymentreceipts.PostedFile.FileName);
                try
                {

                    string[] fileType = fupproofofpaymentreceipts.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\193");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\193";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupproofofpaymentreceipts.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "193", sFileName, serverpath, CrtdUser);

                        hypproofofpaymentreceipts.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void BTNTSFDC_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPTSFDC.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPTSFDC.PostedFile != null) && (FUPTSFDC.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPTSFDC.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPTSFDC.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\191");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\191";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPTSFDC.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "191", sFileName, serverpath, CrtdUser);

                        HYPTSFDC.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void BTNCACERTIFICATE_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPCACERTIFICATE.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPCACERTIFICATE.PostedFile != null) && (FUPCACERTIFICATE.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPCACERTIFICATE.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPCACERTIFICATE.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\192");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\192";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCACERTIFICATE.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "192", sFileName, serverpath, CrtdUser);

                        HYPCACERTIFICATE.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void TXTADMTQUANTITY_TextChanged(object sender, EventArgs e)
    {
        if(ddlFin1stOr2ndHalfyear.SelectedValue=="2"&& ddlFirstorSecondQUarter.SelectedValue=="2")
        {
            Decimal previouslysanctionedquantity;
            previouslysanctionedquantity = (Convert.ToDecimal(TXTFIRSTQTRQTY.Text) + Convert.ToDecimal(TXTSECONDQTRQTY.Text) + Convert.ToDecimal(TXTTHIRDQTRQTY.Text));
            if (Convert.ToDecimal(TXTADMTQUANTITY.Text) <= (150000 - previouslysanctionedquantity))
            {

                TXTCLAIMAMOUNT.Text = (Convert.ToDecimal(TXTADMTQUANTITY.Text) * 1000).ToString();
            }
            else
            {
                TXTADMTQUANTITY.Text = "0";
                TXTCLAIMAMOUNT.Text = (Convert.ToDecimal(TXTADMTQUANTITY.Text) * 1000).ToString();
            }
        }
        else
        {
            if(Convert.ToDecimal(TXTADMTQUANTITY.Text)>150000)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter ADMT quantity Amount lessthan 150000 and Remember Total Quantity Availale for One year is 150000 ADMT only');", true);
                return;
            }
            else
            {
                TXTCLAIMAMOUNT.Text = (Convert.ToDecimal(TXTADMTQUANTITY.Text) * 1000).ToString();
            }
        }
        
        
    }
    protected void BTNCACERTIFICATEPAPER_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPCACARTIFICATEPAPER.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPCACARTIFICATEPAPER.PostedFile != null) && (FUPCACARTIFICATEPAPER.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPCACARTIFICATEPAPER.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPCACARTIFICATEPAPER.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\194");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\194";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCACARTIFICATEPAPER.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "194", sFileName, serverpath, CrtdUser);

                        HYPCACERTIFICATEPAPER.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void BTNFUPCACERTIFICATEADMT_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPCACERTIFICATEADMT.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPCACERTIFICATEADMT.PostedFile != null) && (FUPCACERTIFICATEADMT.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPCACERTIFICATEADMT.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPCACERTIFICATEADMT.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\195");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\195";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCACERTIFICATEADMT.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "195", sFileName, serverpath, CrtdUser);

                        HYPFUPCACERTIFICATEADMT.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void BTNCFOCOPY_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPCFOCOPY.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPCFOCOPY.PostedFile != null) && (FUPCFOCOPY.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPCFOCOPY.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPCFOCOPY.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\19\\196");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\19\\196";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCFOCOPY.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "196", sFileName, serverpath, CrtdUser);

                        HypCFOCOPY.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
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
    protected void ddlFirstorSecondQUarter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
        {
            if (ddlFirstorSecondQUarter.SelectedValue == "1")
            {
                trFin1stHalf1stquarter.Visible = true;
                trfirsthalfyearsecondquarter.Visible = false;
                trFin2ndHalf1stquarter.Visible = false;
                trFin2ndHalf2ndquarter.Visible = false;
            }
            if (ddlFirstorSecondQUarter.SelectedValue == "2")
            {
                trFin1stHalf1stquarter.Visible = false;
                trfirsthalfyearsecondquarter.Visible = true;
                trFin2ndHalf1stquarter.Visible = false;
                trFin2ndHalf2ndquarter.Visible = false;
            }

        }
        if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
        {
            if (ddlFirstorSecondQUarter.SelectedValue == "1")
            {
                trFin1stHalf1stquarter.Visible = false;
                trfirsthalfyearsecondquarter.Visible = false;
                trFin2ndHalf1stquarter.Visible = true;
                trFin2ndHalf2ndquarter.Visible = false;
            }
            if (ddlFirstorSecondQUarter.SelectedValue == "2")
            {
                trFin1stHalf1stquarter.Visible = false;
                trfirsthalfyearsecondquarter.Visible = false;
                trFin2ndHalf1stquarter.Visible = false;
                trFin2ndHalf2ndquarter.Visible = true;
            }
        }
    }

    protected void rbtwoodsanctioned_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(rbtwoodsanctioned.SelectedValue=="Y")
        {
            tdquartera.Visible = true;
            tdquarterb.Visible = true;
            tdquarterc.Visible = true;
            tdquarterd.Visible = true;
        }
        else
        {
            tdquartera.Visible = false;
            tdquarterb.Visible = false;
            tdquarterc.Visible = false;
            tdquarterd.Visible = false;
        }
    }

    protected void ddlnoofquarterssanctioned_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlnoofquarterssanctioned.SelectedValue=="1")
        {
            trfirstquarterQuantity.Visible = true;
            trSecondquarterQuantity.Visible = false;
            trThirdquarterQuantity.Visible = false;

        }
        if (ddlnoofquarterssanctioned.SelectedValue == "2")
        {
            trfirstquarterQuantity.Visible = true;
            trSecondquarterQuantity.Visible = true;
            trThirdquarterQuantity.Visible = false;

        }
        if (ddlnoofquarterssanctioned.SelectedValue == "3")
        {
            trfirstquarterQuantity.Visible = true;
            trSecondquarterQuantity.Visible = true;
            trThirdquarterQuantity.Visible = true;
        }
        
    }
}