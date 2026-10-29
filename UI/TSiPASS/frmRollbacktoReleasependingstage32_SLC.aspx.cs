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
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Xml;

public partial class UI_TSiPASS_frmRollbacktoReleasependingstage32_SLC : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General Gen = new General();



    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = Gen.GenericFillDs("GetIncentives");
            ddlincentivename.DataSource = ds.Tables[0];
            ddlincentivename.DataTextField = "IncentiveName";//
            ddlincentivename.DataValueField = "IncentiveID";
            ddlincentivename.DataBind();
            ddlincentivename.Items.Insert(0, new ListItem("--Select--", "0"));
            BindDistricts(ddlDist);
        }

    }

    private void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsForOldSanctionedIncentives();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "DistrictName";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;


        if (txtUnitName.Text.Trim() == "")
        {
            lblmsg0.Text += "Please enter Unit Name" + "<br/>";
            valid = 1;
        }
        if (ddlDist.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select District" + "<br/>";
            valid = 1;
        }
        if (ddlcaste.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select Caste" + "<br/>";
            valid = 1;
        }
        if (ddlincentivename.SelectedItem.Text == "--Select--")
        {
            lblmsg0.Text += "Please Select Incentive Type" + "<br/>";
            valid = 1;
        }
        //if (TXTSANXTIONEDAMOUNT.Text == "")
        //{
        //    lblmsg0.Text += "Please enter Sanctioned Amount" + "<br/>";
        //    valid = 1;
        //}


        if (valid == 0)
        {
            DataSet dsd = new DataSet();
            dsd = GET_SLC_WORKINGSTTAUSUPDATEDDATA_STAGEID36(ddlcaste.SelectedValue, ddlDist.SelectedValue, ddlincentivename.SelectedValue, txtUnitName.Text.Trim(), TXTSANXTIONEDAMOUNT.Text.Trim());
            if (dsd != null && dsd.Tables.Count > 0)
            {
                grdDetails.DataSource = dsd.Tables[0];
                grdDetails.DataBind();
                grdDetails.Visible = true;
            }
            else
            {

                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails.Visible = false;

            }

        }
        else
        {

            grdDetails.DataSource = null;
            grdDetails.DataBind();
            grdDetails.Visible = false;


        }
    }
    public DataSet GET_SLC_WORKINGSTTAUSUPDATEDDATA_STAGEID36(string caste, string Dist, string incentivename, string UnitName, string sanctionedamount)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_CHEQUENUMBER_NOTUPDATEDLIST_SLC_TO_ROLLBACK_RELEASEPENDINGSTAGE", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = caste;
            da.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Dist;
            da.SelectCommand.Parameters.Add("@Incentivetype", SqlDbType.VarChar).Value = incentivename;
            da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
            da.SelectCommand.Parameters.Add("@SANCTIONEDAMOUNT", SqlDbType.VarChar).Value = sanctionedamount;

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

    protected void btnrollback_Click(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        string enterpincid = row.Cells[8].Text;
        string subincid = row.Cells[7].Text;
        int j = 0;
        j = RollbackSLCCASESSTAGEID36(enterpincid, subincid, getclientIP(),Convert.ToString(Session["uid"]));
        if (j == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Rollbacked Successfully..!');", true);
            // ddlDist.ClearSelection();
            //// ddlcaste.ClearSelection();
            // //ddlincentivename.ClearSelection();
            // txtUnitName.Text = "";
            // TXTSANXTIONEDAMOUNT.Text = "";
            // grdDetails.Visible = false;
            btnGet_Click(sender, e);
            return;


        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Failed to rollback..!');", true);
            return;
        }

    }
    public int RollbackSLCCASESSTAGEID36(string enterpincid, string subincid,string IPADDRESS,string CREATEDBY)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "";
        com.CommandText = "SP_ROLLBACKSLCCASES_TO_RELEASEPENDINGSTAGE";


        if (enterpincid.Trim() == "" || enterpincid.Trim() == null)
            com.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.VarChar).Value = enterpincid.Trim();



        if (subincid.Trim() == "" || subincid.Trim() == null)
            com.Parameters.Add("@SUBINCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SUBINCENTIVEID", SqlDbType.VarChar).Value = subincid.Trim();

        if (IPADDRESS.Trim() == "" || IPADDRESS.Trim() == null)
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = IPADDRESS.Trim();

        if (CREATEDBY.Trim() == "" || CREATEDBY.Trim() == null)
            com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = CREATEDBY.Trim();





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