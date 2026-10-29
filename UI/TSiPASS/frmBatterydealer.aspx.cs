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

public partial class UI_TSiPASS_frmBatterydealer : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Response objRes = new Response();
    Batterydealerproperties bat = new Batterydealerproperties();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }



        if (!IsPostBack)
        {
            getdistricts();
        }

        DataSet dsnew = new DataSet();
        dsnew = GetenterpreneurdetailsBattery(Session["uid"].ToString().Trim());
        if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
        {
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dsnew.Tables[0].Rows[0]["BatdealerID"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            txtindustrialName.Text = dsnew.Tables[0].Rows[0]["Nameofthedealer"].ToString().Trim();
            txtemail.Text = dsnew.Tables[0].Rows[0]["Email"].ToString().Trim();
            txtdoorno.Text = dsnew.Tables[0].Rows[0]["batdoorno"].ToString().Trim();
            txtgstno.Text = dsnew.Tables[0].Rows[0]["GSTNumber"].ToString().Trim();
            txtlat.Text = dsnew.Tables[0].Rows[0]["Latitude"].ToString().Trim();
            txtlong.Text = dsnew.Tables[0].Rows[0]["Longitude"].ToString().Trim();
            txtpincode.Text = dsnew.Tables[0].Rows[0]["batpincode"].ToString().Trim();
            txttelno.Text = dsnew.Tables[0].Rows[0]["Telephoneno"].ToString().Trim();
            txtRegDate.Text = dsnew.Tables[0].Rows[0]["ValidityofBatteryDealerRegistration"].ToString().Trim();


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

            if (ddlvillage.SelectedItem.Text == "--Select--")
            {
                ddlvillage.Enabled = true;
            }
            txtdoorno.Text = dsnew.Tables[0].Rows[0]["batdoorno"].ToString().Trim();


        }

    }

    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetDistrictsbystate(ddlstate.SelectedValue.ToString());

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsnew = new DataSet();
        //ddlProp_intDistrictid.Items.Clear();
        dsnew = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");
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
        ddlvillage.DataSource = dsnew.Tables[0];
        ddlvillage.DataTextField = "Village_Name";
        ddlvillage.DataValueField = "Village_Id";
        ddlvillage.DataBind();
        ddlvillage.Items.Insert(0, "--Select--");


    }
    void clear()
    {

        txtindustrialName.Text = "";
        ddlstate.SelectedIndex = 0; ddldistrict.SelectedIndex = 0; ddlmandal.SelectedIndex = 0; ddlvillage.SelectedIndex = 0; txtdoorno.Text = "";
        txtpincode.Text = ""; txttelno.Text = ""; txtlat.Text = ""; txtlong.Text = ""; txtemail.Text = ""; txtgstno.Text = ""; txtRegDate.Text = "";


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
        Batterydealervo batvo = new Batterydealervo();
        //batvo.Appstatus = "";
        //batvo.BatdealerID =Convert.ToInt32(Session["Applid"].ToString());

        batvo.batdistrict = ddldistrict.SelectedValue;
        batvo.batmandal = ddlmandal.SelectedValue;
        batvo.batvillage = ddlvillage.SelectedValue;
        batvo.BatteryDealername = txtindustrialName.Text;
        batvo.doorno = txtdoorno.Text;
        batvo.Email = txtemail.Text;
        batvo.gstnumber = txtgstno.Text;
        batvo.latitude = txtlat.Text;
        batvo.Longitude = txtlong.Text;
        batvo.pincode = txtpincode.Text;
        batvo.telno = txttelno.Text;
        batvo.Valregdate = Convert.ToDateTime(txtRegDate.Text.ToString());
        batvo.telno = txttelno.Text;
        batvo.Created_by = Session["uid"].ToString().Trim();
        result = InsertBatterydealer(batvo);
        if (result > 0)
        {
            //ResetFormControl(this);
            Response.Redirect("frmBatteryAttachments.aspx?intApplicationId=" + result);
            lblmsg.Text = "<font color='green'>Land Details Added Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
        }

    }

    protected void btnnext_Click(object sender, EventArgs e)
    {

    }

    public int InsertBatterydealerold(Batterydealervo bd)

    {
        //Response objRes = new Response();
        //con.OpenConnection();
        //SqlCommand com = new SqlCommand("SP_Insert_Batterydealer", con.GetConnection);
        //com.CommandType = CommandType.StoredProcedure;
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Insert_Batterydealer";

        try
        {


            if (bd.BatteryDealername.ToString().Trim() == "" || bd.BatteryDealername.ToString().Trim() == null)
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = bd.BatteryDealername.Trim();

            //if (bd.batstate.ToString().Trim() == "0" || bd.batstate.ToString().Trim() == null || bd.batstate.ToString().Trim() == "--Select--")
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = bd.batstate.Trim();

            if (bd.batdistrict.ToString().Trim() == "" || bd.batdistrict.ToString().Trim() == null || bd.batdistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = bd.batdistrict.Trim();

            if (bd.batmandal.ToString().Trim() == "" || bd.batmandal.ToString().Trim() == null || bd.batmandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = bd.batmandal.Trim();

            if (bd.batvillage.ToString().Trim() == "" || bd.batvillage.ToString().Trim() == null || bd.batvillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = bd.batvillage.Trim();

            if (bd.doorno.ToString().Trim() == "" || bd.doorno.ToString().Trim() == null)
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = bd.doorno.Trim();

            if (bd.pincode.ToString().Trim() == "" || bd.pincode.ToString().Trim() == null)
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = bd.pincode.Trim();

            if (bd.latitude.ToString().Trim() == "" || bd.latitude.ToString().Trim() == null)
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = bd.latitude.Trim();

            if (bd.Longitude.ToString().Trim() == "0" || bd.Longitude.ToString().Trim() == null)
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = bd.Longitude.Trim();

            if (bd.Email.ToString().Trim() == "" || bd.Email.ToString().Trim() == null)
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = bd.Email.Trim();

            if (bd.telno.ToString().Trim() == "" || bd.telno.ToString().Trim() == null)
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = bd.telno.Trim();

            if (bd.Valregdate.ToString().Trim() == "" || bd.Valregdate.ToString().Trim() == null)
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value = bd.Valregdate;

            if (bd.gstnumber.ToString().Trim() == "0" || bd.gstnumber.ToString().Trim() == null)
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = bd.gstnumber.Trim();

            if (bd.Created_by.ToString().Trim() == "0" || bd.Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = bd.Created_by.Trim();

            //com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            //com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            //com.ExecuteNonQuery();
            //bd.BatdealerID = (Int32)com.Parameters["@Valid"].Value;


            ////if (bd.BatdealerID > 0)
            ////    objRes.ResponseVal = true;

            ////else
            ////    objRes.ResponseVal = false;
            //con.CloseConnection();

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {
                //return Convert.ToInt32(com.ExecuteScalar());
                //if (returnvalue == DBNull.Value || returnvalue == null)
                //    return 0;
                //else
                //    return Convert.ToInt32(returnvalue);

                object returnvalue = com.ExecuteScalar();
                if (returnvalue == DBNull.Value || returnvalue == null)
                    return 0;
                else
                    return Convert.ToInt32(returnvalue);

            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
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
            throw ex;

        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
        return bd.BatdealerID;

    }

    public int InsertBatterydealer(Batterydealervo bd)
    {
        try
        {

            //con.OpenConnection();
            //SqlDataAdapter myDataAdapter;
            //SqlCommand com = new SqlCommand();
            //com.CommandType = CommandType.StoredProcedure;
            //myDataAdapter = new SqlDataAdapter("[insertEnterPrenuerRenewaldetails]", con.GetConnection);
            //myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Insert_Batterydealer";

            if (bd.BatteryDealername.ToString().Trim() == "" || bd.BatteryDealername.ToString().Trim() == null)
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Nameofdealer", SqlDbType.VarChar).Value = bd.BatteryDealername.Trim();

            //if (bd.batstate.ToString().Trim() == "0" || bd.batstate.ToString().Trim() == null || bd.batstate.ToString().Trim() == "--Select--")
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.Add("@BatState", SqlDbType.VarChar).Value = bd.batstate.Trim();

            if (bd.batdistrict.ToString().Trim() == "" || bd.batdistrict.ToString().Trim() == null || bd.batdistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDistrict", SqlDbType.VarChar).Value = bd.batdistrict.Trim();

            if (bd.batmandal.ToString().Trim() == "" || bd.batmandal.ToString().Trim() == null || bd.batmandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Batmandal", SqlDbType.VarChar).Value = bd.batmandal.Trim();

            if (bd.batvillage.ToString().Trim() == "" || bd.batvillage.ToString().Trim() == null || bd.batvillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatVillage", SqlDbType.VarChar).Value = bd.batvillage.Trim();

            if (bd.doorno.ToString().Trim() == "" || bd.doorno.ToString().Trim() == null)
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatDoorno", SqlDbType.VarChar).Value = bd.doorno.Trim();

            if (bd.pincode.ToString().Trim() == "" || bd.pincode.ToString().Trim() == null)
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = bd.pincode.Trim();

            if (bd.latitude.ToString().Trim() == "" || bd.latitude.ToString().Trim() == null)
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = bd.latitude.Trim();

            if (bd.Longitude.ToString().Trim() == "0" || bd.Longitude.ToString().Trim() == null)
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = bd.Longitude.Trim();

            if (bd.Email.ToString().Trim() == "" || bd.Email.ToString().Trim() == null)
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Email", SqlDbType.VarChar).Value = bd.Email.Trim();

            if (bd.telno.ToString().Trim() == "" || bd.telno.ToString().Trim() == null)
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Telphoneno", SqlDbType.VarChar).Value = bd.telno.Trim();

            if (bd.Valregdate.ToString().Trim() == "" || bd.Valregdate.ToString().Trim() == null)
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@valregdate", SqlDbType.DateTime).Value = bd.Valregdate;

            if (bd.gstnumber.ToString().Trim() == "0" || bd.gstnumber.ToString().Trim() == null)
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@GStnum", SqlDbType.VarChar).Value = bd.gstnumber.Trim();

            if (bd.Created_by.ToString().Trim() == "0" || bd.Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = bd.Created_by.Trim();

            if (bd.BatdealerID.ToString().Trim() == "0" || bd.BatdealerID.ToString().Trim() == null)
                com.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@BatdealerID", SqlDbType.VarChar).Value = bd.BatdealerID;

            con.OpenConnection();
            com.Connection = con.GetConnection;

            try
            {
                //return Convert.ToInt32(com.ExecuteScalar());
                //if (returnvalue == DBNull.Value || returnvalue == null)
                //    return 0;
                //else
                //    return Convert.ToInt32(returnvalue);

                return Convert.ToInt32(com.ExecuteScalar());
                //object returnvalue = com.ExecuteScalar();
                //if (returnvalue == DBNull.Value || returnvalue == null)
                //    return 0;
                //else
                //    return Convert.ToInt32(returnvalue);

            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
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

    protected void btnnext_Click1(object sender, EventArgs e)
    {
        Response.Redirect("frmBatteryAttachments.aspx");
    }

    public DataSet GetenterpreneurdetailsBattery(string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_BATTERY_APPLICATIONID", con.GetConnection);
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
}


