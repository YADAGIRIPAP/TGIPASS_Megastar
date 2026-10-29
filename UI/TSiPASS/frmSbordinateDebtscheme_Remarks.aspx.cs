using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSIPASS_frmSbordinateDebtscheme_Remarks : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    string sno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        if(txtRemarks.Text!="")
        {
            sno = Request.QueryString["status"].ToString();
            osqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SBORDINATEDEPTSCHEMEDETAILS_Updateremarks", osqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sno", sno);
            cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.ToString());
            cmd.ExecuteNonQuery();
            osqlConnection.Close();
            string message = "alert('Updated successfully!')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            Response.Redirect("frmSbordinateDebtscheme_report.aspx");
        }
        else
        {
            string message = "alert('Remarks cannot be blank')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        }
       
    }
}