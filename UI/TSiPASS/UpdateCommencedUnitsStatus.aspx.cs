using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class UI_TSiPASS_UpdateCommencedUnitsStatus : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["user_id"]) != "" && Convert.ToString(Session["Role_Code"]) == "GM")
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    lblUIDNo.Text = Convert.ToString(Request.QueryString["UID"]);
                    lblUnitName.Text = Convert.ToString(Request.QueryString["UnitName"]);

                }
                else { Response.Redirect("CommencedUnitsStatus.aspx"); }
            }
        }
        else { Response.Redirect("~/Tshome.aspx"); }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string Result;
        string errormsg = "";
        errormsg = Validations();
        if (errormsg == "")
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("USP_UpdateCommencedUnitStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UID", lblUIDNo.Text);
            cmd.Parameters.AddWithValue("@UnitName", lblUnitName.Text);
            cmd.Parameters.AddWithValue("@IsRunning", rblRunning.SelectedValue);
            cmd.Parameters.AddWithValue("@IsRMavailable", rblRawMaterial.SelectedValue);
            cmd.Parameters.AddWithValue("@FinancialStatus", rblFinStatus.SelectedValue);
            cmd.Parameters.AddWithValue("@MarketingType", rblMarketing.SelectedValue);
            cmd.Parameters.AddWithValue("@UnitPersonName", txtPersonName.Text);
            cmd.Parameters.AddWithValue("@UnitPersonDesgn", txtPersonDesgn.Text);
            cmd.Parameters.AddWithValue("@UnitPersonMobile", txtPersonMobile.Text);
            if(txtanyIssue.Text!="")
            cmd.Parameters.AddWithValue("@FacinganyIssue", txtanyIssue.Text);
            cmd.Parameters.AddWithValue("@GMRemarks", txtGMremarks.Text);

            cmd.Parameters.AddWithValue("@Updatedby", Convert.ToString(Session["uid"]));
            cmd.Parameters.AddWithValue("@UpdatedIP", getclientIP());

            cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
            cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            Result = cmd.Parameters["@Result"].Value.ToString();

            if (Result == "1")
            {
                lblmsg.Text = "Status updated Succesfully";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                success.Visible = true;
                btnUpdate.Enabled = false;
            }

        }
        else
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
            return;
        }

    }
    public string Validations()
    {
        string errormsg = ""; int slno = 1;
        if (rblRunning.SelectedIndex == -1)
        {
            errormsg = errormsg + slno + ". Please Select  whether the unit is running properly or not? \\n";
            slno = slno + 1;
        }
        if (rblRawMaterial.SelectedIndex == -1)
        {
            errormsg = errormsg + slno + ". Please Select  whether the Raw-Material is available or not? \\n";
            slno = slno + 1;
        }
        if (rblFinStatus.SelectedIndex == -1)
        {
            errormsg = errormsg + slno + ". Please Select Financial status \\n";
            slno = slno + 1;
        }
        if (rblMarketing.SelectedIndex == -1)
        {
            errormsg = errormsg + slno + ". Please Select Marketing type \\n";
            slno = slno + 1;
        }

        if (string.IsNullOrEmpty(txtPersonName.Text) || txtPersonName.Text == "" || txtPersonName.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Unit Person Name\\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtPersonDesgn.Text) || txtPersonDesgn.Text == "" || txtPersonDesgn.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Unit Person Designation\\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtPersonMobile.Text) || txtPersonMobile.Text == "" || txtPersonMobile.Text == null || txtPersonMobile.Text.Length != 10 || txtPersonMobile.Text.All(c => c == '0'))
        {
            errormsg = errormsg + slno + ". Please Enter Unit Person Mobile Number\\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtGMremarks.Text) || txtGMremarks.Text == "" || txtGMremarks.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Remarks\\n";
            slno = slno + 1;
        }
        return errormsg;
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
}