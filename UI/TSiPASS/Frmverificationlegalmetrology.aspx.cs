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

public partial class Frmverificationlegalmetrology : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Response objRes = new Response();
    LegalMetrologyverify Lgv = new LegalMetrologyverify();
    Legalverify Lvfd = new Legalverify();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        //getdistricts();


        if (!IsPostBack)
        {
            getdistricts();
            if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
            {

                DataSet dsnew = new DataSet();
                dsnew = GetenterpreneurdetailsLegalmetrology(Request.QueryString["intqnreid"].ToString());
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        Session["Applid"] = dsnew.Tables[0].Rows[0]["LgvID"].ToString().Trim();
                    }
                    else
                    {
                        Session["Applid"] = "0";
                    }

                    txtindustrialName.Text = dsnew.Tables[0].Rows[0]["Nameoftheunit"].ToString().Trim();

                    if (dsnew.Tables[0].Rows[0]["District_Name"].ToString() != "")
                    {
                        ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(dsnew.Tables[0].Rows[0]["District_Name"].ToString().Trim()).Value;
                        ddldistrict.Enabled = true;
                    }
                    ddldistrict_SelectedIndexChanged(sender, e);

                    if (dsnew.Tables[0].Rows[0]["mandal_name"].ToString() != "")
                    {
                        ddlmandal.SelectedValue = ddlmandal.Items.FindByValue(dsnew.Tables[0].Rows[0]["mandal_name"].ToString().Trim()).Value;
                        ddlmandal.Enabled = true;
                    }
                    ddlmandal_SelectedIndexChanged(sender, e);
                    if (dsnew.Tables[0].Rows[0]["village_name"].ToString() != "")
                    {
                        ddlvillage.SelectedValue = ddlvillage.Items.FindByValue(dsnew.Tables[0].Rows[0]["village_name"].ToString().Trim()).Value;
                        ddlvillage.Enabled = true;
                    }
                    if (dsnew.Tables[0].Rows[0]["RegistrationType"].ToString() != "")
                    {
                        ddlregtype.SelectedValue = ddlregtype.Items.FindByValue(dsnew.Tables[0].Rows[0]["RegistrationType"].ToString().Trim()).Value;
                        ddlregtype.Enabled = true;
                    }

                }
            }
        }
       

    }
    /* Update method for getting data from Legal Metrology for tracking -- */
    public int updatingdataLegalmetrology(string LGVID, string LegalApplID, string LegalDownloadLink, string Legalmetrologystatus)
    {
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Insert_UpdatefromLegalMetrology";

            if (LGVID.ToString().Trim() == "" || LGVID.ToString().Trim() == null)
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LGVID.Trim();

            if (LegalApplID.ToString().Trim() == "" || LegalApplID.ToString().Trim() == null)
                com.Parameters.Add("@LegalApplID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LegalApplID", SqlDbType.VarChar).Value = LegalApplID.Trim();

            if (LegalDownloadLink.ToString().Trim() == "" || LegalDownloadLink.ToString().Trim() == null)
                com.Parameters.Add("@LegalDownloadLink", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LegalDownloadLink", SqlDbType.VarChar).Value = LegalDownloadLink.Trim();

            if (Legalmetrologystatus.ToString().Trim() == "" || Legalmetrologystatus.ToString().Trim() == null)
                com.Parameters.Add("@Legalmetrologystatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Legalmetrologystatus", SqlDbType.VarChar).Value = Legalmetrologystatus.Trim();

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {

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
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    /*update Additional payment flow of departments*/
    public int AdditionalPaymentLegalMetrology(string LGVID, string AdditionalPayment, int instageid, string Additionalpaymentdate)
    {
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_flow_UpdatefromLegalMetrology";

            if (LGVID.ToString().Trim() == "" || LGVID.ToString().Trim() == null)
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LGVID.Trim();

            if (AdditionalPayment.ToString().Trim() == "" || AdditionalPayment.ToString().Trim() == null)
                com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

            if (instageid.ToString().Trim() == "" || instageid.ToString().Trim() == null)
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = instageid;

            if (Additionalpaymentdate.ToString().Trim() == "" || Additionalpaymentdate.ToString().Trim() == null)
                com.Parameters.Add("@Additionalpaymentdate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Additionalpaymentdate", SqlDbType.VarChar).Value = Additionalpaymentdate.Trim();

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {

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
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    /* Approval Legal Metrology*/
    public int ApprovalLegalMetrology(string LGVID, string ApprovalLink, int instageid, string Approvaldate)
    {
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_flow_UpdatefromLegalMetrology";

            if (LGVID.ToString().Trim() == "" || LGVID.ToString().Trim() == null)
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LGVID.Trim();

            if (ApprovalLink.ToString().Trim() == "" || ApprovalLink.ToString().Trim() == null)
                com.Parameters.Add("@ApprovalLink", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApprovalLink", SqlDbType.VarChar).Value = ApprovalLink.Trim();

            if (instageid.ToString().Trim() == "" || instageid.ToString().Trim() == null)
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = instageid;

            if (Approvaldate.ToString().Trim() == "" || Approvaldate.ToString().Trim() == null)
                com.Parameters.Add("@Approval_Date", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Approval_Date", SqlDbType.VarChar).Value = Approvaldate.Trim();

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {

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
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    /* Rejection Legal Metrology*/
    public int RejectionLegalMetrology(string LGVID, string PrescruitnyRejectionremarks, string Prescrutinyrejecteddate, string ApprovalRejectionremarks, string ApprovalRejectionDate, int instageid)
    {
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_flow_UpdatefromLegalMetrology";

            if (LGVID.ToString().Trim() == "" || LGVID.ToString().Trim() == null)
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LGVID.Trim();

            if (PrescruitnyRejectionremarks.ToString().Trim() == "" || PrescruitnyRejectionremarks.ToString().Trim() == null)
                com.Parameters.Add("@Prescrutinyrejectedremarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Prescrutinyrejectedremarks", SqlDbType.VarChar).Value = PrescruitnyRejectionremarks.Trim();

            if (Prescrutinyrejecteddate.ToString().Trim() == "" || Prescrutinyrejecteddate.ToString().Trim() == null)
                com.Parameters.Add("@Prescrutinyrejecteddate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Prescrutinyrejecteddate", SqlDbType.VarChar).Value = Prescrutinyrejecteddate.Trim();

            if (ApprovalRejectionremarks.ToString().Trim() == "" || ApprovalRejectionremarks.ToString().Trim() == null)
                com.Parameters.Add("@ApprovalRejectionremarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApprovalRejectionremarks", SqlDbType.VarChar).Value = ApprovalRejectionremarks.Trim();

            if (ApprovalRejectionDate.ToString().Trim() == "" || ApprovalRejectionDate.ToString().Trim() == null)
                com.Parameters.Add("@approvalRejectiondate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@approvalRejectiondate", SqlDbType.VarChar).Value = ApprovalRejectionDate.Trim();

            if (instageid.ToString().Trim() == "" || instageid.ToString().Trim() == null)
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = instageid;


            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {

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
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }


    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Lvfd.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }


    protected void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Lvfd.getMandalsbydistrictLegal(ddldistrict.SelectedValue.ToString());
        ddlmandal.DataSource = dsnew.Tables[0];
        ddlmandal.DataTextField = "mandal_name";
        ddlmandal.DataValueField = "mandal_code";
        ddlmandal.DataBind();
        ddlmandal.Items.Insert(0, "--Select--");
    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Lvfd.GetVillagebymandal(ddlmandal.SelectedValue.ToString());
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "village_name";
        ddlvillage.DataValueField = "village_id";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, "--Select--");


    }
    void clear()
    {

        txtindustrialName.Text = "";
        ddlstate.SelectedIndex = 0; ddldistrict.SelectedIndex = 0; ddlmandal.SelectedIndex = 0; ddlvillage.SelectedIndex = 0; ddlregtype.SelectedIndex = 0;


    }



    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }


    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, "--Select--");

        }

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmEntrepreneurDetails.aspx");
        clear();
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int result = 0;
        LegalMetrologyverify Lgv = new LegalMetrologyverify();

        Lgv.Nameoftheunit = txtindustrialName.Text;
        //Lgv.lgvstate = ddlstate.SelectedValue;
        Lgv.lgvdistrict = ddldistrict.SelectedValue;
        Lgv.lgvmandal = ddlmandal.SelectedValue;
        Lgv.lgvvillage = ddlvillage.SelectedValue;
        Lgv.registrationtype = ddlregtype.SelectedValue;
        Lgv.Created_by = Session["uid"].ToString().Trim();

        if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
        {

            Lgv.LgvID = Convert.ToInt32(Request.QueryString["intqnreid"].ToString());
        }
        else
        {
            Lgv.LgvID = 0;
        }

        result = InsertLegalverify(Lgv);
        lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
        success.Visible = true;
        Failure.Visible = false;
        //string myParameters= "https://qa8.cgg.gov.in/TSLM/TSIpassRegistration.do?mode=saveTSiPassApplication&tsIpassUniqueId= " +result+ 
        //    "&registrationType="+Lgv.registrationtype+ "&districtId="+Lgv.lgvdistrict+ "&mandalId="+Lgv.lgvmandal+ "&villageId="+Lgv.lgvvillage;
        ////Response.Redirect("https://qa8.cgg.gov.in/TSLM/TSIpassRegistration.do?mode=saveTSiPassApplication&tsIpassUniqueId=result&registrationType=Lgv.registrationtype&districtId=Lgv.lgvdistrict&mandalId=Lgv.lgvmandal&villageId=Lgv.lgvvillage");
        //Response.Redirect("https://qa8.cgg.gov.in/TSLM/TSIpassRegistration.do?mode=saveTSiPassApplication&tsIpassUniqueId= " + result +
        //    "&registrationType=" + Lgv.registrationtype + "&districtId=" + Lgv.lgvdistrict + "&mandalId=" + Lgv.lgvmandal + "&villageId=" + Lgv.lgvvillage);

    }

   

    public int InsertLegalverify(LegalMetrologyverify Lgv)
    {
        try
        {


            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Insert_LegalMetrologyverify";

            if (Lgv.Nameoftheunit.ToString().Trim() == "" || Lgv.Nameoftheunit.ToString().Trim() == null)
                com.Parameters.Add("@Nameoftheunit", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Nameoftheunit", SqlDbType.VarChar).Value = Lgv.Nameoftheunit.Trim();

            //if (Lgv.lgvstate.ToString().Trim() == "" || Lgv.lgvstate.ToString().Trim() == null || Lgv.lgvstate.ToString().Trim() == "--Select--")
            //    com.Parameters.Add("@LgvState", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@LgvState", SqlDbType.VarChar).Value = Lgv.lgvstate.Trim();

            if (Lgv.lgvdistrict.ToString().Trim() == "" || Lgv.lgvdistrict.ToString().Trim() == null || Lgv.lgvdistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@LgvDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvDistrict", SqlDbType.VarChar).Value = Lgv.lgvdistrict.Trim();

            if (Lgv.lgvmandal.ToString().Trim() == "" || Lgv.lgvmandal.ToString().Trim() == null || Lgv.lgvmandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Lgvmandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Lgvmandal", SqlDbType.VarChar).Value = Lgv.lgvmandal.Trim();

            if (Lgv.lgvvillage.ToString().Trim() == "" || Lgv.lgvvillage.ToString().Trim() == null || Lgv.lgvvillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@LgvVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvVillage", SqlDbType.VarChar).Value = Lgv.lgvvillage.Trim();

            if (Lgv.registrationtype.ToString().Trim() == "" || Lgv.registrationtype.ToString().Trim() == null || Lgv.registrationtype.ToString().Trim() == "--Select--")
                com.Parameters.Add("@RegistrationType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@RegistrationType", SqlDbType.VarChar).Value = Lgv.registrationtype.Trim();

            if (Lgv.Created_by.ToString().Trim() == "0" || Lgv.Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Lgv.Created_by.Trim();

            if (Lgv.LgvID.ToString().Trim() == "0" || Lgv.LgvID.ToString().Trim() == null)
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = Lgv.LgvID;

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {

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
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }
     
    public DataSet GetenterpreneurdetailsLegalmetrology(string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Legalverify_APPLICATIONID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (createdby.Trim() == "" || createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

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

    protected void Btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int result = 0;
            LegalMetrologyverify Lgv = new LegalMetrologyverify();

            Lgv.Nameoftheunit = txtindustrialName.Text;
            //Lgv.lgvstate = ddlstate.SelectedValue;
            Lgv.lgvdistrict = ddldistrict.SelectedValue;
            Lgv.lgvmandal = ddlmandal.SelectedValue;
            Lgv.lgvvillage = ddlvillage.SelectedValue;
            Lgv.registrationtype = ddlregtype.SelectedValue;
            Lgv.Created_by = Session["uid"].ToString().Trim();
            if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
            {

                Lgv.LgvID = Convert.ToInt32(Request.QueryString["intqnreid"].ToString());
            }
            else
            {
                Lgv.LgvID =  0 ;
            }

            result = InsertLegalverify(Lgv);
            Session["Applid"]  = result;
            lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
            Response.Redirect("frmLegalRedirection.aspx?intApplicationId=" + Session["Applid"].ToString());

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {

        }
        return;

    }
}


