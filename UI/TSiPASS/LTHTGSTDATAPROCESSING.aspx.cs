using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class UI_TSiPASS_LTHTGSTDATAPROCESSING : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    string Applicanttype;
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString.Count>3)
                {
                    HDNDISTRICTID.Value = Request.QueryString["DISTRICTID"].ToString();
                    HDNUNITNAME.Value = Request.QueryString["UNITNAME"].ToString();
                    HDNMSMENO.Value = Request.QueryString["MSMENO"].ToString();
                    HDNIDENTITYID.Value = Request.QueryString["IDENTITYID"].ToString();
                }
                else
                {
                    HDNDISTRICTID.Value = Request.QueryString["DISTRICTID"].ToString();
                    HDNUNITNAME.Value = Request.QueryString["UNITNAME"].ToString();
                    HDNIDENTITYID.Value = Request.QueryString["LBLID"].ToString();
                }

            }
            else

            {
            }


        }
    }

    protected void RBTISMSMEUNIT_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RBTISMSMEUNIT.SelectedValue == "1")
        {
            TRMSMEUNITNAME.Visible = true;
            BINDMSMEUNITNAMES();
        }
        else
        {
            Response.Redirect("frmmsme_LTHTGST.aspx?district=" + HDNDISTRICTID.Value.ToString() + "&UNITNAME=" + HDNUNITNAME.Value+"&identityid="+HDNIDENTITYID.Value);
        }
    }
    public void BINDMSMEUNITNAMES()
    {
        DataSet UNITNAME = new DataSet();
        UNITNAME = GETMSMEUNITNAMES(HDNDISTRICTID.Value, HDNUNITNAME.Value);
        if (UNITNAME.Tables[0].Rows.Count > 0)
        {
            DDLMSMEUNITNAME.DataSource = UNITNAME.Tables[0];
            DDLMSMEUNITNAME.DataTextField = "UNIT_NAME";
            DDLMSMEUNITNAME.DataValueField = "MSME_NO";
            DDLMSMEUNITNAME.DataBind();
            AddSelect(DDLMSMEUNITNAME);
        }
        else
        {
            DDLMSMEUNITNAME.Items.Clear();
            AddSelect(DDLMSMEUNITNAME);
            RBTISMSMEUNIT.SelectedValue = "0";
            RBTISMSMEUNIT_SelectedIndexChanged(this, EventArgs.Empty);
        }
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public DataSet GETMSMEUNITNAMES(string DISTRICTID,  string MSMEUNITNAME)
    {

        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                new SqlParameter("@MSMEUNITNAME",SqlDbType.VarChar)
       };
        pp[0].Value = DISTRICTID;
        pp[1].Value = MSMEUNITNAME;
        Dsnew = Gen.GenericFillDs("SP_GETMSMEUNITNAMES_LTHTGSTDATA", pp);
        return Dsnew;
    }
    protected void DDLMSMEUNITNAME_SelectedIndexChanged(object sender, EventArgs e)
    {
        TRDISTANDMANDAL.Visible = true;
        TRMSMEANDLOA.Visible = true;
        TRUPDATE.Visible = true;
        trunitname.Visible = true;
        TRUPDATE.Visible = true;
        DataSet dsmmsme = new DataSet();
        dsmmsme = GETMSMEUNITDATA(HDNDISTRICTID.Value,HDNUNITNAME.Value,DDLMSMEUNITNAME.SelectedValue);
        if (dsmmsme != null && dsmmsme.Tables.Count > 0 && dsmmsme.Tables[0].Rows.Count > 0)
        {
            
            LBLUNITNAME.Text= dsmmsme.Tables[0].Rows[0]["UNIT_NAME"].ToString().Trim();
            LBLMSMENO.Text = dsmmsme.Tables[0].Rows[0]["MSME_NO"].ToString().Trim();

            LBLDISTRICT.Text = dsmmsme.Tables[0].Rows[0]["District_Name"].ToString().Trim();

            LBLMANDAL.Text = dsmmsme.Tables[0].Rows[0]["Manda_lName"].ToString().Trim();

            LBLLOANAME.Text = dsmmsme.Tables[0].Rows[0]["LineofActivity_Name"].ToString().Trim();

        }
        else
        {

          
        }
    }
    public DataSet GETMSMEUNITDATA(string District,string Unitname,string MSMEID)
    {

        DataSet Dsnew = new DataSet();
        try
        {
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@DISTRICT",SqlDbType.VarChar),

               new SqlParameter("@UNITNAME",SqlDbType.VarChar),
               new SqlParameter("@MSMEID",SqlDbType.VarChar)

           };

            //pp[0].Value = (Unitname == "") ? "%" : Unitname;
            pp[0].Value = District;
    
            pp[1].Value = (Unitname == "") ? "%" : "%" + Unitname.ToString() + "%";
            pp[2].Value = MSMEID;


            Dsnew = Gen.GenericFillDs("[USP_GETMSMEUNITDATA_BYMSMEID]", pp);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        return Dsnew;
    }


    protected void BTNUPDATE_Click(object sender, EventArgs e)
    {
        try
        {
            int i = 0;

            i = UPDATELTHTTABLEDATA_MSMENO(HDNDISTRICTID.Value,HDNUNITNAME.Value,HDNIDENTITYID.Value,LBLMSMENO.Text);

            if (i > 0)
            {
                //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", "RECORD UPDATED SUCCESSFULLY", true);
                Response.Redirect("lthtnpdclgstdata.aspx");
                return;
               
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public int UPDATELTHTTABLEDATA_MSMENO(string ddldistrict, string UNITNAME, string IDENTITYID,string MSMENO)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UPDATEMSMENO";
        {
            if (ddldistrict == "" || ddldistrict == null || ddldistrict == "--Select--")
                com.Parameters.Add("@ddldistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ddldistrict", SqlDbType.VarChar).Value = ddldistrict.Trim();

            if (UNITNAME == "" || UNITNAME == null || UNITNAME == "--Select--")
                com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@UNITNAME", SqlDbType.VarChar).Value = UNITNAME.Trim();
            if (IDENTITYID == "" || IDENTITYID == null || IDENTITYID == "--Select--")
                com.Parameters.Add("@IDENTITYID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@IDENTITYID", SqlDbType.VarChar).Value = IDENTITYID.Trim();

            if (MSMENO == "" || MSMENO == null || MSMENO == "--Select--")
                com.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = MSMENO.Trim();
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

    }

}