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


public partial class UI_TSiPASS_frmIncentiveform_COAL : System.Web.UI.Page
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
        //    Response.Redirect("frmIncentiveform_wood.aspx?next=" + "N");
        //}

        success.Visible = false;
        Failure.Visible = false;
        //Session["EntprIncentive"] = "1234512345";

        if (!IsPostBack)
        {
            lblcoal.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF COAL </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014, Read with G.O.Ms.No.18, dated.21/03/2018)</center>";
            if (Session["incentivedata"] != null)
            {

           string userid = Session["uid"].ToString();
           // string userid = "48696";
               string IncentveID = Session["EntprIncentive"].ToString();
           // string IncentveID = "147255";
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
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 18);  // Coal(VAT/GST/SGST) Reimbursement
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("frmIncentiveform_WOOD.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("AdvanceSubsidyForSCandST.aspx?Previous=" + "P");
                    }
                }
                

                BindFinancialYears1(ddlFinYearCoal, "3", IncentveID);
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
        ds = GetCOALIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0) //&& ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDNCOALID.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                ddlFinYearCoal.SelectedValue = ds.Tables[0].Rows[0]["FinancialYearNew"].ToString();
                ddlFin1stOr2ndHalfyear.SelectedValue = ds.Tables[0].Rows[0]["FirstorSecondHalf"].ToString();
                if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
                {
                    trFin1stHalfYear.Visible = true;
                    trFin2ndHalfYear.Visible = false;
                    txt1stHalfAmountPaid.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountPaid"].ToString();
                    txt1stHalfamountclaimed.Text = ds.Tables[0].Rows[0]["FirstHalfyearAmountclaimed"].ToString();
                }
                if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
                {
                    trFin1stHalfYear.Visible = false;
                    trFin2ndHalfYear.Visible = true;
                    txt2ndHalfAmountPaid.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountPaid"].ToString();
                    txt2ndHalfamountclaimed.Text = ds.Tables[0].Rows[0]["SecondHalfyearAmountclaimed"].ToString();
                }
                TXTCOALQUANTITY.Text = ds.Tables[0].Rows[0]["Quantity_Coal"].ToString();
                TXTUNITMSMT.Text = ds.Tables[0].Rows[0]["UnitMeasurement_coal"].ToString();
                TXTAMOUNTPAID.Text = ds.Tables[0].Rows[0]["AmountPaid"].ToString();
                TXTCLAIMAMOUNT.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();


                txtIPGQuantity.Text = ds.Tables[0].Rows[0]["Quantity_IPG"].ToString();
                //txtIPGunitofmeasurement.Text= ds.Tables[0].Rows[0]["Unitmeasurement_IPG"].ToString();
                txtpaperquantity.Text = ds.Tables[0].Rows[0]["Quantity_paper"].ToString();
                //txtunitmeasurement_paper.Text= ds.Tables[0].Rows[0]["UnitMeasurement_paper"].ToString();

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

                    if (AttcahmentId == "181")
                    {
                        HYPSCCLINVOICE.NavigateUrl = sen;
                        HYPSCCLINVOICE.Text = dr["FileNm"].ToString();
                        LBLSCCLINVOICE.Text = dr["FileNm"].ToString();
                    }
                    
                    if (AttcahmentId == "182")
                    {
                        hypwaybilldocuments.NavigateUrl = sen;
                        hypwaybilldocuments.Text = dr["FileNm"].ToString();
                        lblwaybilldocuments.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "183")
                    {
                        hypproofofpaymentreceipts.NavigateUrl = sen;
                        hypproofofpaymentreceipts.Text = dr["FileNm"].ToString();
                        lblproofofpaymentreceipts.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "184")
                    {
                        HypCACERTIFICATE.NavigateUrl = sen;
                        HypCACERTIFICATE.Text = dr["FileNm"].ToString();
                        LBLCACERTIFICATE.Text = dr["FileNm"].ToString();
                    }

                    if (AttcahmentId == "185")
                    {
                        HypCFOCOPY.NavigateUrl = sen;
                        HypCFOCOPY.Text = dr["FileNm"].ToString();
                        LBLCFOCOPY.Text = dr["FileNm"].ToString();
                    }

                }
               
            }
        }
        
    }
    public DataSet GetCOALIncentives(int incentiveid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_COALInentives", con.GetConnection);
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
        dsYears = Gen.GetFinancialYearIncentives("COAL", IncentveID);
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
        Response.Redirect("AdvanceSubsidyForSCandST.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;
        
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            //UpdateAnnexureflag(IncentiveId, "18", "Y", "");
            Response.Redirect("frmIncentiveform_WOOD.aspx?next=" + "N");
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

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
        //int start = 0;
        //int valid = 0;
        //int out2 = 0;
        try
        {
           
            
            //ds = (DataSet)Session["incentivedata"];
            //string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            // UpdateAnnexureflag(IncentiveId, "18", "Y", ""); reference
            DataSet ds1 = new DataSet();
            ds1 = InsertCoalAnnexureDetails(Session["EntprIncentive"].ToString(), "18", ddlFinYearCoal.SelectedValue, ddlFin1stOr2ndHalfyear.SelectedValue,
                TXTCOALQUANTITY.Text, TXTUNITMSMT.Text, TXTAMOUNTPAID.Text, TXTCLAIMAMOUNT.Text, txt1stHalfAmountPaid.Text, txt1stHalfamountclaimed.Text,
                txt2ndHalfAmountPaid.Text, txt2ndHalfamountclaimed.Text,  txtIPGQuantity.Text, txtIPGunitofmeasurement.Text, txtpaperquantity.Text,
                txtunitmeasurement_paper.Text,Session["uid"].ToString(), HDNCOALID.Value);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                string a;
                a = ds1.Tables[0].Rows[0]["value"].ToString();
                if (a=="1")
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
    public DataSet InsertCoalAnnexureDetails(string Incentiveid,string MasterIncentiveid,
string Financialyear,string FirstorSecondHalf,string Quantity_Coal,string UnitMeasurement_coal,
string AmountPaid,string Amountclaimed,string FirstHalfyearAmountPaid,
string FirstHalfyearAmountclaimed,string SecondHalfyearAmountPaid,
string SecondHalfyearAmountclaimed,string Quantity_IPG,string Unitmeasurement_IPG,
string Quantity_paper,string UnitMeasurement_paper,string createdby, string Coalid )
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_INSERT_COALDETAILS", osqlConnection);
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
            if (Quantity_Coal.Trim() == "" || Quantity_Coal.Trim() == null || Quantity_Coal.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Quantity_Coal", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Quantity_Coal", SqlDbType.VarChar).Value = Quantity_Coal.ToString();
            if (UnitMeasurement_coal.Trim() == "" || UnitMeasurement_coal.Trim() == null || UnitMeasurement_coal.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@UnitMeasurement_coal", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@UnitMeasurement_coal", SqlDbType.VarChar).Value = UnitMeasurement_coal.ToString();
            

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
            if (FirstHalfyearAmountPaid.Trim() == "" || FirstHalfyearAmountPaid.Trim() == null || FirstHalfyearAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyearAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyearAmountPaid", SqlDbType.VarChar).Value = FirstHalfyearAmountPaid.ToString();

            if (FirstHalfyearAmountclaimed.Trim() == "" || FirstHalfyearAmountclaimed.Trim() == null || FirstHalfyearAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@FirstHalfyearAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@FirstHalfyearAmountclaimed", SqlDbType.VarChar).Value = FirstHalfyearAmountclaimed.ToString();



            if (SecondHalfyearAmountPaid.Trim() == "" || SecondHalfyearAmountPaid.Trim() == null || SecondHalfyearAmountPaid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyearAmountPaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyearAmountPaid", SqlDbType.VarChar).Value = SecondHalfyearAmountPaid.ToString();

            if (SecondHalfyearAmountclaimed.Trim() == "" || SecondHalfyearAmountclaimed.Trim() == null || SecondHalfyearAmountclaimed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SecondHalfyearAmountclaimed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SecondHalfyearAmountclaimed", SqlDbType.VarChar).Value = SecondHalfyearAmountclaimed.ToString();


            if (Quantity_IPG.Trim() == "" || Quantity_IPG.Trim() == null || Quantity_IPG.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Quantity_IPG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Quantity_IPG", SqlDbType.VarChar).Value = Quantity_IPG.ToString();

            if (Unitmeasurement_IPG.Trim() == "" || Unitmeasurement_IPG.Trim() == null )
            {
                da.SelectCommand.Parameters.Add("@Unitmeasurement_IPG", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Unitmeasurement_IPG", SqlDbType.VarChar).Value = Unitmeasurement_IPG.ToString();

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


            if (Coalid.Trim() == "" || Coalid.Trim() == null || Coalid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Coalid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Coalid", SqlDbType.VarChar).Value = Coalid.ToString();


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
        ddlFinYearCoal.SelectedValue = "--Select--";
        txt1stHalfAmountPaid.Text = "";
        txt1stHalfamountclaimed.Text = "";
        txt2ndHalfAmountPaid.Text = "";
        txt1stHalfamountclaimed.Text = "";
    }
    protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = false;
        }
        else if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
        {
            trFin1stHalfYear.Visible = false;
            trFin2ndHalfYear.Visible = true;
        }
        else
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = true;
        }

    }
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

    protected void TXTCOALQUANTITY_TextChanged(object sender, EventArgs e)
    {
        TXTCLAIMAMOUNT.Text = (Convert.ToDecimal(TXTCOALQUANTITY.Text) * 1000).ToString();
    }

    protected void BTNSCCLINVOICE_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FUPSCCLINVOICE.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FUPSCCLINVOICE.PostedFile != null) && (FUPSCCLINVOICE.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FUPSCCLINVOICE.PostedFile.FileName);
                try
                {

                    string[] fileType = FUPSCCLINVOICE.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\18\\181");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\18\\181";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPSCCLINVOICE.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "181", sFileName, serverpath, CrtdUser);

                        HYPSCCLINVOICE.Text = sFileName;

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

    protected void BTNSCLORCACERTIFICATE_Click(object sender, EventArgs e)
    {

    }

    protected void btnwaybilldocuments_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (fupwaybilldocuments.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupwaybilldocuments.PostedFile != null) && (fupwaybilldocuments.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(fupwaybilldocuments.PostedFile.FileName);
                try
                {

                    string[] fileType = fupwaybilldocuments.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\18\\182");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\18\\182";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupwaybilldocuments.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "182", sFileName, serverpath, CrtdUser);

                        hypwaybilldocuments.Text = sFileName;

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\18\\183");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\18\\183";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupproofofpaymentreceipts.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "183", sFileName, serverpath, CrtdUser);

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\18\\184");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\18\\184";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCACERTIFICATE.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "184", sFileName, serverpath, CrtdUser);

                        HypCACERTIFICATE.Text = sFileName;

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\18\\185");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\18\\185";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FUPCFOCOPY.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "185", sFileName, serverpath, CrtdUser);

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
}