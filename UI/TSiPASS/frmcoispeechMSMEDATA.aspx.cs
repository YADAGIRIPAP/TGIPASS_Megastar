using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

public partial class UI_TSiPASS_frmcoispeechMSMEDATA : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();

    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        TXTMSMEUNITSREGYEAR_UNTILL.Text = DateTime.Now.ToShortDateString();

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

      
        //IIPC
        if (txtDBIITYEAR.Text.Trim() == ""|| txtDBIITYEAR.Text.Trim() == null|| txtDBIITYEAR.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter The year for which DPIIT has communicated set of reforms \\n";
            slno = slno + 1;
        }
        if (TXTNOOFREFORMS.Text.Trim() == "" || TXTNOOFREFORMS.Text.Trim() == null || TXTNOOFREFORMS.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter No of Reforms DPIIT communicated \\n";
            slno = slno + 1;
        }
        if (TXTTOPACHIEVERYEAR.Text.Trim() == "" || TXTTOPACHIEVERYEAR.Text.Trim() == null || TXTTOPACHIEVERYEAR.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Year for which Telangana stood among the top achievers for the year \\n";
            slno = slno + 1;
        }
        //MSME
        if (TXTNOOFSICKUNITS.Text.Trim() == "" || TXTNOOFSICKUNITS.Text.Trim() == null || TXTNOOFSICKUNITS.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter No of Sick Units assisted by TIHCL. \\n";
            slno = slno + 1;
        }
        if (TXTNOOFMSMEUNITS.Text.Trim() == "" || TXTNOOFMSMEUNITS.Text.Trim() == null || TXTNOOFMSMEUNITS.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter No of Units registered under UDYAM \\n";
            slno = slno + 1;
        }
        if (txtnoofapplicationsfiled.Text.Trim() == "" || txtnoofapplicationsfiled.Text.Trim() == null || txtnoofapplicationsfiled.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter No of cases filed under TSMSEFC \\n";
            slno = slno + 1;
        }
        if (TXTNOOFCASES.Text.Trim() == "" || TXTNOOFCASES.Text.Trim() == null || TXTNOOFCASES.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Total cases disposed \\n";
            slno = slno + 1;
        }
        if (TXTAMOUNTDISPOSED.Text.Trim() == "" || TXTAMOUNTDISPOSED.Text.Trim() == null || TXTAMOUNTDISPOSED.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Amount involved in disposed cases \\n";
            slno = slno + 1;
        }
        if (txttechorextcentersinvestment.Text.Trim() == "" || txttechorextcentersinvestment.Text.Trim() == null || txttechorextcentersinvestment.Text.Trim() == "0")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Technology/Extension Centers Investment \\n";
            slno = slno + 1;
        }
        //Commented on 08/01/2024

        //if (TXTAMOUNTFOUNDEDBYTGGOVT.Text.Trim() == "" || TXTAMOUNTFOUNDEDBYTGGOVT.Text.Trim() == null || TXTAMOUNTFOUNDEDBYTGGOVT.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter The amount funded by Telangana Govt(In Cr) \\n";
        //    slno = slno + 1;
        //}   
        //if (TXTAMOUNTSETTINGUPFORNBFC.Text.Trim() == "" || TXTAMOUNTSETTINGUPFORNBFC.Text.Trim() == null || TXTAMOUNTSETTINGUPFORNBFC.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Amount to setting up Telangana Industrial Health Clinic as Non-Banking Finance Company(NBFC)(In Cr.) \\n";
        //    slno = slno + 1;
        //}     
        //if (TXTBUDGETALLOCATEDTIDEA.Text.Trim() == "" || TXTBUDGETALLOCATEDTIDEA.Text.Trim() == null || TXTBUDGETALLOCATEDTIDEA.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Allocated under T IDEA \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETRELEASEDTIDEA.Text.Trim() == "" || TXTBUDGETRELEASEDTIDEA.Text.Trim() == null || TXTBUDGETRELEASEDTIDEA.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Released under T IDEA \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETPENDINGTIDEA.Text.Trim() == "" || TXTBUDGETPENDINGTIDEA.Text.Trim() == null || TXTBUDGETPENDINGTIDEA.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Pending under T IDEA \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETUNILIZEDTIDEA.Text.Trim() == "" || TXTBUDGETUNILIZEDTIDEA.Text.Trim() == null || TXTBUDGETUNILIZEDTIDEA.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget utilized under T IDEA \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETALLOCATEDTPRIDE.Text.Trim() == "" || TXTBUDGETALLOCATEDTPRIDE.Text.Trim() == null || TXTBUDGETALLOCATEDTPRIDE.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Allocated under T PRIDE \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETRELEASEDTPRIDE.Text.Trim() == "" || TXTBUDGETRELEASEDTPRIDE.Text.Trim() == null || TXTBUDGETRELEASEDTPRIDE.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Released under T PRIDE \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETPENDINGTPRIDE.Text.Trim() == "" || TXTBUDGETPENDINGTPRIDE.Text.Trim() == null || TXTBUDGETPENDINGTPRIDE.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget Pending under T PRIDE \\n";
        //    slno = slno + 1;
        //}
        //if (TXTBUDGETUNILIZEDTPRIDE.Text.Trim() == "" || TXTBUDGETUNILIZEDTPRIDE.Text.Trim() == null || TXTBUDGETUNILIZEDTPRIDE.Text.Trim() == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Budget utilized under T PRIDE \\n";
        //    slno = slno + 1;
        //}

        return ErrorMsg;
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg1 = ValidateControls();
        if (errormsg1.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg1 + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        int i = 0;
            i = InsertClosedUnits(txtDBIITYEAR.Text,TXTNOOFREFORMS.Text,TXTTOPACHIEVERYEAR.Text, TXTAMOUNTSETTINGUPFORNBFC.Text,
                TXTAMOUNTFOUNDEDBYTGGOVT.Text, TXTNOOFSICKUNITS.Text, TXTNOOFMSMEUNITS.Text, TXTMSMEUNITSREGYEAR_UNTILL.Text,
                TXTNOOFCASES.Text, Session["uid"].ToString(), txtnoofapplicationsfiled.Text, TXTAMOUNTDISPOSED.Text, txttechorextcentersinvestment.Text,
                TXTBUDGETALLOCATEDTIDEA.Text,TXTBUDGETRELEASEDTIDEA.Text,TXTBUDGETPENDINGTIDEA.Text,TXTBUDGETUNILIZEDTIDEA.Text,
                TXTBUDGETALLOCATEDTPRIDE.Text, TXTBUDGETRELEASEDTPRIDE.Text, TXTBUDGETPENDINGTPRIDE.Text, TXTBUDGETUNILIZEDTPRIDE.Text);

            if (i > 0)
            {

                //clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Saved Successfully..!');", true);
                return;
            }
            else
            {

               // clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Failed to Save Data..!');", true);
                return;
            }


    }
    public int InsertClosedUnits(string txtDBIITYEAR, string TXTNOOFREFORMS, string TXTTOPACHIEVERYEAR, string TXTAMOUNTSETTINGUPFORNBFC,
       string TXTAMOUNTFOUNDEDBYTGGOVT, string TXTNOOFSICKUNITS, string TXTNOOFMSMEUNITS, string TXTMSMEUNITSREGYEAR_UNTILL,
       string TXTNOOFCASES,string created_by,string txtnoofapplicationsfiled, string TXTAMOUNTDISPOSED, string txttechorextcentersinvestment,
       string TXTBUDGETALLOCATEDTIDEA, string TXTBUDGETRELEASEDTIDEA, string TXTBUDGETPENDINGTIDEA, string TXTBUDGETUNILIZEDTIDEA,
       string TXTBUDGETALLOCATEDTPRIDE, string TXTBUDGETRELEASEDTPRIDE, string TXTBUDGETPENDINGTPRIDE, string TXTBUDGETUNILIZEDTPRIDE)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "InsertCOISPEECH";

        if (TXTMSMEUNITSREGYEAR_UNTILL == "" || TXTMSMEUNITSREGYEAR_UNTILL == null || TXTMSMEUNITSREGYEAR_UNTILL == "--Select--")
            com.Parameters.Add("@TXTMSMEUNITSREGYEAR_UNTILL", SqlDbType.DateTime).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTMSMEUNITSREGYEAR_UNTILL", SqlDbType.DateTime).Value = TXTMSMEUNITSREGYEAR_UNTILL.Trim();
        //IIPC
        if (txtDBIITYEAR == "" || txtDBIITYEAR == null || txtDBIITYEAR == "--Select--")
            com.Parameters.Add("@txtDBIITYEAR", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@txtDBIITYEAR", SqlDbType.VarChar).Value = txtDBIITYEAR.Trim();

        if (TXTNOOFREFORMS == "" || TXTNOOFREFORMS == null || TXTNOOFREFORMS == "--Select--")
            com.Parameters.Add("@TXTNOOFREFORMS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTNOOFREFORMS", SqlDbType.VarChar).Value = TXTNOOFREFORMS.Trim();

        if (TXTTOPACHIEVERYEAR == "" || TXTTOPACHIEVERYEAR == null || TXTTOPACHIEVERYEAR == "--Select--")
            com.Parameters.Add("@TXTTOPACHIEVERYEAR", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTTOPACHIEVERYEAR", SqlDbType.VarChar).Value = TXTTOPACHIEVERYEAR.Trim();


        if (TXTAMOUNTSETTINGUPFORNBFC == "" || TXTAMOUNTSETTINGUPFORNBFC == null || TXTAMOUNTSETTINGUPFORNBFC == "--Select--")
            com.Parameters.Add("@TXTAMOUNTSETTINGUPFORNBFC", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTAMOUNTSETTINGUPFORNBFC", SqlDbType.VarChar).Value = TXTAMOUNTSETTINGUPFORNBFC.Trim();

        if (TXTAMOUNTFOUNDEDBYTGGOVT == "" || TXTAMOUNTFOUNDEDBYTGGOVT == null || TXTAMOUNTFOUNDEDBYTGGOVT == "--Select--")
            com.Parameters.Add("@TXTAMOUNTFOUNDEDBYTGGOVT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTAMOUNTFOUNDEDBYTGGOVT", SqlDbType.VarChar).Value = TXTAMOUNTFOUNDEDBYTGGOVT.Trim();
        
        if (TXTNOOFSICKUNITS == "" || TXTNOOFSICKUNITS == null || TXTNOOFSICKUNITS == "--Select--")
            com.Parameters.Add("@TXTNOOFSICKUNITS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTNOOFSICKUNITS", SqlDbType.VarChar).Value = TXTNOOFSICKUNITS.Trim();

        if (TXTNOOFMSMEUNITS == "" || TXTNOOFMSMEUNITS == null)
            com.Parameters.Add("@TXTNOOFMSMEUNITS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTNOOFMSMEUNITS", SqlDbType.VarChar).Value = TXTNOOFMSMEUNITS.Trim();

       

        if (TXTNOOFCASES == "" || TXTNOOFCASES == null || TXTNOOFCASES == "--Select--")
            com.Parameters.Add("@TXTNOOFCASES", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTNOOFCASES", SqlDbType.VarChar).Value = TXTNOOFCASES.Trim();

        if (created_by == "" || created_by == null || created_by == "--Select--")
            com.Parameters.Add("@created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@created_by", SqlDbType.VarChar).Value = created_by.Trim();
        
        if (txtnoofapplicationsfiled == "" || txtnoofapplicationsfiled == null || txtnoofapplicationsfiled == "--Select--")
            com.Parameters.Add("@txtnoofapplicationsfiled", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@txtnoofapplicationsfiled", SqlDbType.VarChar).Value = txtnoofapplicationsfiled.Trim();
       
        if (TXTAMOUNTDISPOSED == "" || TXTAMOUNTDISPOSED == null || TXTAMOUNTDISPOSED == "--Select--")
            com.Parameters.Add("@TXTAMOUNTDISPOSED", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTAMOUNTDISPOSED", SqlDbType.VarChar).Value = TXTAMOUNTDISPOSED.Trim();
        
        if (txttechorextcentersinvestment == "" || txttechorextcentersinvestment == null || txttechorextcentersinvestment == "--Select--")
            com.Parameters.Add("@txttechorextcentersinvestment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@txttechorextcentersinvestment", SqlDbType.VarChar).Value = txttechorextcentersinvestment.Trim();


        if (TXTBUDGETALLOCATEDTIDEA == "" || TXTBUDGETALLOCATEDTIDEA == null || TXTBUDGETALLOCATEDTIDEA == "--Select--")
            com.Parameters.Add("@TXTBUDGETALLOCATEDTIDEA", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETALLOCATEDTIDEA", SqlDbType.VarChar).Value = TXTBUDGETALLOCATEDTIDEA.Trim();

        if (TXTBUDGETRELEASEDTIDEA == "" || TXTBUDGETRELEASEDTIDEA == null || TXTBUDGETRELEASEDTIDEA == "--Select--")
            com.Parameters.Add("@TXTBUDGETRELEASEDTIDEA", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETRELEASEDTIDEA", SqlDbType.VarChar).Value = TXTBUDGETRELEASEDTIDEA.Trim();

        if (TXTBUDGETPENDINGTIDEA == "" || TXTBUDGETPENDINGTIDEA == null || TXTBUDGETPENDINGTIDEA == "--Select--")
            com.Parameters.Add("@TXTBUDGETPENDINGTIDEA", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETPENDINGTIDEA", SqlDbType.VarChar).Value = TXTBUDGETPENDINGTIDEA.Trim();

        if (TXTBUDGETUNILIZEDTIDEA == "" || TXTBUDGETUNILIZEDTIDEA == null || TXTBUDGETUNILIZEDTIDEA == "--Select--")
            com.Parameters.Add("@TXTBUDGETUNILIZEDTIDEA", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETUNILIZEDTIDEA", SqlDbType.VarChar).Value = TXTBUDGETUNILIZEDTIDEA.Trim();

        if (TXTBUDGETALLOCATEDTPRIDE == "" || TXTBUDGETALLOCATEDTPRIDE == null || TXTBUDGETALLOCATEDTPRIDE == "--Select--")
            com.Parameters.Add("@TXTBUDGETALLOCATEDTPRIDE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETALLOCATEDTPRIDE", SqlDbType.VarChar).Value = TXTBUDGETALLOCATEDTPRIDE.Trim();

        if (TXTBUDGETRELEASEDTPRIDE == "" || TXTBUDGETRELEASEDTPRIDE == null || TXTBUDGETRELEASEDTPRIDE == "--Select--")
            com.Parameters.Add("@TXTBUDGETRELEASEDTPRIDE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETRELEASEDTPRIDE", SqlDbType.VarChar).Value = TXTBUDGETRELEASEDTPRIDE.Trim();

        if (TXTBUDGETPENDINGTPRIDE == "" || TXTBUDGETPENDINGTPRIDE == null || TXTBUDGETPENDINGTPRIDE == "--Select--")
            com.Parameters.Add("@TXTBUDGETPENDINGTPRIDE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETPENDINGTPRIDE", SqlDbType.VarChar).Value = TXTBUDGETPENDINGTPRIDE.Trim();

        if (TXTBUDGETUNILIZEDTPRIDE == "" || TXTBUDGETUNILIZEDTPRIDE == null || TXTBUDGETUNILIZEDTPRIDE == "--Select--")
            com.Parameters.Add("@TXTBUDGETUNILIZEDTPRIDE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TXTBUDGETUNILIZEDTPRIDE", SqlDbType.VarChar).Value = TXTBUDGETUNILIZEDTPRIDE.Trim();

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

    void clear()
    {


    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();

    }

    void Page_PreInit(Object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    this.MasterPageFile = "~/UI/TSiPASS/EmptyMaster.master";
        //}

    }

}