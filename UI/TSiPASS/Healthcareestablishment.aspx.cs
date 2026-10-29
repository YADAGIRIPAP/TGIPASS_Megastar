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
using System.Xml.Linq;
using System.Threading;
using Org.BouncyCastle.Asn1.Ocsp;

public partial class UI_TSiPASS_Healthcareestablishment : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    BMWClass ObjBMW = new BMWClass();
    General Gen = new General();
    int ID;
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    string HdfQueid = "";
    public string Health_care_establishmentname { get; set; }
    public string HCE_locationPostal_Address { get; set; }
    public string Pincode { get; set; }
    public string Revenue_district { get; set; }
    public string Mandal { get; set; }
    public string Village { get; set; }
    public string Created_by { get; set; }
    public string HCEID { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {

            Response.Redirect("~/Index.aspx");
        }



        if (!IsPostBack)
        {
            if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
            {

                HdfQueid = Request.QueryString["intqnreid"].ToString();
                hdnQueid.Value = Request.QueryString["intqnreid"].ToString();
            }
            else
            {
                HdfQueid = "0";
                hdnQueid.Value = "0";
            }
            getdistricts();
            string uid = Session["uid"].ToString();
            string qid = Request.QueryString["intqnreid"];

            if (Session["uid"].ToString().Trim() == "" || Session["uid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareReg.aspx");
            }
            if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
            {

                DataSet dschk = new DataSet();

                dschk = ObjBMW.GetBWMdatabyReq(Request.QueryString["intqnreid"].ToString());
                if (dschk.Tables[0].Rows.Count > 0)
                {
                    hdnhcid.Value = dschk.Tables[0].Rows[0]["HCEID"].ToString().Trim();
                    HdfQueid = dschk.Tables[0].Rows[0]["HCEID"].ToString().Trim();
                    txtHCEname.Text = dschk.Tables[0].Rows[0]["Health_care_establishmentname"].ToString().Trim();
                    txtHCEname.Enabled = true;
                    txtHCElocation.Text = dschk.Tables[0].Rows[0]["HCE_locationPostal_Address"].ToString().Trim();

                    txtHCElocation.Enabled = true;
                    txtPincode.Text = dschk.Tables[0].Rows[0]["Pincode"].ToString().Trim();
                    txtPincode.Enabled = true;


                    if (dschk.Tables[0].Rows[0]["Revenue_district"].ToString() != "")
                    {
                        ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(dschk.Tables[0].Rows[0]["Revenue_district"].ToString().Trim()).Value;
                        ddldistrict.Enabled = true;
                    }
                    ddldistrict_SelectedIndexChanged(sender, e);

                    if (dschk.Tables[0].Rows[0]["Mandal"].ToString() != "")
                    {
                        ddlmandal.SelectedValue = ddlmandal.Items.FindByValue(dschk.Tables[0].Rows[0]["Mandal"].ToString().Trim()).Value;
                        ddlmandal.Enabled = true;
                    }
                    ddlmandal_SelectedIndexChanged(sender, e);
                    if (dschk.Tables[0].Rows[0]["Village"].ToString() != "")
                    {
                        ddlVillage.SelectedValue = ddlVillage.Items.FindByValue(dschk.Tables[0].Rows[0]["Village"].ToString().Trim()).Value;
                        ddlVillage.Enabled = true;
                    }
                    if (dschk.Tables[0].Rows[0]["Applicationtype"].ToString() != "")
                    {
                        ddlapptype.SelectedValue = ddlapptype.Items.FindByValue(dschk.Tables[0].Rows[0]["Applicationtype"].ToString().Trim()).Value;
                        ddlapptype.Enabled = true;
                    }
                }
            }


        }

        DataSet dsnew = new DataSet();
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            if (ddldistrict.SelectedItem.Text == "--Select--")
            {
                ddldistrict.Enabled = true;
            }
            else
            {
                ddldistrict.Enabled = true;
            }
            if (ddlmandal.SelectedItem.Text == "--Select--")
            {
                ddlmandal.Enabled = true;
            }
            else
            {
                ddlmandal.Enabled = true;
            }

            if (ddlVillage.SelectedItem.Text == "--Select--")
            {
                ddlVillage.Enabled = true;
            }
            else
            {
                ddlVillage.Enabled = true;
            }



        }
    }


    //DataSet dsd = new DataSet();
    //ddlProp_intDistrictid.Items.Clear();
    //        dsd = Gen.GetDistrictsWithoutHYD();
    //        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
    //        {
    //            ddlProp_intDistrictid.DataSource = dsd.Tables[0];
    //            ddlProp_intDistrictid.DataValueField = "District_Id";
    //            ddlProp_intDistrictid.DataTextField = "District_Name";
    //            ddlProp_intDistrictid.DataBind();
    //            ddlProp_intDistrictid.Items.Insert(0, "--District--");
    //        }
    //        else

    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetDistrictsbystate(ddlstate.SelectedValue.ToString());

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsnew = new DataSet();
        //ddlProp_intDistrictid.Items.Clear();
        dsnew = Gen.GetDistrictsWithoutHYD();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldistrict.SelectedValue.ToString());
        ddlmandal.DataSource = dsnew.Tables[0];
        ddlmandal.DataTextField = "Manda_lName";
        ddlmandal.DataValueField = "Mandal_Id";
        ddlmandal.DataBind();
        ddlmandal.Items.Insert(0, "--Select--");


    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlmandal.SelectedValue.ToString());
        ddlVillage.DataSource = dsnew.Tables[0];
        ddlVillage.DataTextField = "Village_Name";
        ddlVillage.DataValueField = "Village_Id";
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, "--Select--");


    }
    void clear()
    {

        txtHCEname.Text = "";
        ddldistrict.SelectedIndex = 0; ddlmandal.SelectedIndex = 0; ddlVillage.SelectedIndex = 0; txtHCElocation.Text = "";
        txtPincode.Text = "";


    }



    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {

        getMandals();

    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedItem.Text.ToString() != "--Select--" || ddlmandal.SelectedValue == "0")
        {
            getVillages();

        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, "--Select--");

        }

    }

    public DataSet GenUser(string procedurename)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter(procedurename, con.GetConnection);
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

    public DataSet GenUser(string procedurename, SqlParameter[] sp)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter(procedurename, con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddRange(sp);

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

    public int GenUserExecuteNonQuery(string procedurename, SqlParameter[] sp)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = procedurename;
        com.Parameters.AddRange(sp);
        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return Convert.ToInt32(com.ExecuteNonQuery());
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

    protected void Btnsave_Click(object sender, EventArgs e)
    {
        int s = 0;
        //if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
        //{

        //    HdfQueid = Request.QueryString["intqnreid"].ToString();
        //}
        //else
        //{
        //    HdfQueid = "0";
        //}
        HdfQueid = hdnQueid.Value;
        s = ObjBMW.HealthcareestablishmentData(txtHCEname.Text, txtHCElocation.Text, txtPincode.Text, ddldistrict.SelectedValue,
        Session["uid"].ToString().Trim(), ddlmandal.SelectedValue, ddlVillage.SelectedValue, ddlapptype.SelectedValue, HdfQueid);  //"1002");
        Session["Applid"] = s.ToString();

        //int s = HealthcareestablishmentData();
        //Session["Applid"] = s.ToString();

        hdnQueid.Value = HdfQueid = s.ToString();

        lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
        success.Visible = true;
        Failure.Visible = false;
        //OBJHCE.Created_by = Session["uid"].ToString();
        //int result = HealthCareEstablishment(OBJHCE);
        //if (result > 0)
        //{
        //    string message = "alert('Data Inserted Successfully')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    success.Visible = true;
        //    lblmsg.Text = "Data Inserted Successfully";

        //}
        //else
        //{
        //    string message = "alert('Application Not Processed please try Again!!')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);


        //}


    }



    protected void Btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int s = 0;
            //if (Request.QueryString["intqnreid"] != null && Request.QueryString["intqnreid"] != "")
            //{

            //    HdfQueid = Request.QueryString["intqnreid"].ToString();
            //}
            //else
            //{
            //    HdfQueid = "0";
            //}

            HdfQueid = hdnQueid.Value;

            s = ObjBMW.HealthcareestablishmentData(txtHCEname.Text, txtHCElocation.Text, txtPincode.Text, ddldistrict.SelectedValue,
            Session["uid"].ToString().Trim(), ddlmandal.SelectedValue, ddlVillage.SelectedValue, ddlapptype.SelectedValue, HdfQueid);  //"1002");
            Session["Applid"] = s.ToString();

            //int s = HealthcareestablishmentData();
            //Session["Applid"] = s.ToString();
            lblmsg.Text = "<font color='GREEN'> Details Added Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
            Response.Redirect("frmpcbBWM.aspx?intApplicationId=" + Session["Applid"].ToString());

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

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();
    }


    public int HealthcareestablishmentData()
    {
        //string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

        //SqlConnection connection = new SqlConnection(str);
        //SqlTransaction transaction = null;
        //connection.Open();
        //transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "USP_INS_BMWVALUES";
            //SqlCommand com = new SqlCommand();
            //com.CommandType = CommandType.StoredProcedure;
            //com.CommandText = "USP_INS_BMWVALUES";
            //com.Transaction = transaction;
            //com.Connection = connection;
            //com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@Health_care_establishmentname", SqlDbType.VarChar).Value = txtHCEname.Text.Trim();
            com.Parameters.Add("@HCE_locationPostal_Address", SqlDbType.VarChar).Value = txtHCElocation.Text.Trim();
            com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = txtPincode.Text.Trim();
            com.Parameters.Add("@Revenue_district", SqlDbType.VarChar).Value = ddldistrict.SelectedValue.Trim();
            com.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = ddlmandal.SelectedValue.Trim();
            com.Parameters.Add("@Village", SqlDbType.VarChar).Value = ddlVillage.SelectedValue.Trim();
            com.Parameters.Add("@Applicationtype", SqlDbType.VarChar).Value = ddlapptype.SelectedValue.Trim();
            if (hdnhcid.Value == "" || hdnhcid.Value == null)
                com.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = hdnhcid.Value.Trim();

            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Session["uid"].ToString();

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
        catch (Exception ex)
        {
            // transaction.Rollback();
            throw ex;
        }
        finally
        {
            //connection.Close();
            //connection.Dispose();
        }
        // return ID;

    }
}




