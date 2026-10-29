using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmrollbacktoupdatechequedetails_slc : System.Web.UI.Page
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
        }

    }


    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;

        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (ddlcaste.SelectedValue == "" || ddlcaste.SelectedValue == "--Select--" || ddlcaste.SelectedValue == "0" || ddlcaste.SelectedValue == null)
        {
            lblmsg0.Text += "Please Select Caste <br/>";
            valid = 1;
        }
        if (ddlincentivename.SelectedValue == "" || ddlincentivename.SelectedValue == "--Select--" || ddlincentivename.SelectedValue == "0" || ddlincentivename.SelectedValue == null)
        {
            lblmsg0.Text += "Please Select Incentive Type <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            DataSet dsd = new DataSet();
            dsd = GET_UTRNUMBERNOTUPDATEDLIST_SLC(FromdateforDB, TodateforDB, ddlcaste.SelectedValue, ddlincentivename.SelectedValue);
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
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

       
    }
    public DataSet GET_UTRNUMBERNOTUPDATEDLIST_SLC(string fromdate, string todate, string caste, string incentivetype)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GET_UTRNUMBERNOTUPDATEDLIST_SLC", con.GetConnection);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = fromdate;
            da.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = todate;
            da.SelectCommand.Parameters.Add("@Cast", SqlDbType.VarChar).Value = caste;
            da.SelectCommand.Parameters.Add("@Incentivetype", SqlDbType.VarChar).Value = incentivetype;


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
        j = ROLLBACKSLCCASES_TOSECTIONTOUPDATECHEQUEDETAILSAGAIN(enterpincid, subincid, getclientIP());
        if (j == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Rollbacked Successfully..!');", true);

            btnGet_Click(sender, e);
            return;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Failed to rollback..!');", true);
            return;
        }

    }
    public int ROLLBACKSLCCASES_TOSECTIONTOUPDATECHEQUEDETAILSAGAIN(string enterpincid, string subincid,string ipadress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_ROLLBACKSLCCASES_TOSECTIONTOUPDATECHEQUEDETAILSAGAIN";

        if (enterpincid.Trim() == "" || enterpincid.Trim() == null)
            com.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MASTERINCENTIVEID", SqlDbType.VarChar).Value = enterpincid.Trim();

        if (subincid.Trim() == "" || subincid.Trim() == null)
            com.Parameters.Add("@SUBINCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SUBINCENTIVEID", SqlDbType.VarChar).Value = subincid.Trim();

        if (ipadress.Trim() == "" || ipadress.Trim() == null)
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = ipadress.Trim();

        if (Convert.ToString(Session["uid"]) == "" || Convert.ToString(Session["uid"]) == null)
            com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);

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