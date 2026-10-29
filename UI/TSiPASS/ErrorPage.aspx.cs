using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        try
        {
            //DataSet dsdata = new DataSet();
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    SqlCommand cmdsrc = new SqlCommand("INS_ErrorLog", con);
            //    cmdsrc.Parameters.AddWithValue("@Message", Convert.ToString(Request.QueryString[0]));
            //    cmdsrc.Parameters.AddWithValue("@StackTrace", Convert.ToString(Request.QueryString[0]));
            //    cmdsrc.Parameters.AddWithValue("@Source", Convert.ToString(Request.QueryString[0]));
            //    cmdsrc.Parameters.AddWithValue("@TargetSite", Convert.ToString(Request.QueryString[0]));
            //    cmdsrc.Parameters.AddWithValue("@CreatedBy", Convert.ToString(Session["uid"]));
            //    cmdsrc.Parameters.AddWithValue("@path", Convert.ToString(Request.QueryString[0]));
            //    cmdsrc.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    cmdsrc.ExecuteNonQuery();
            //    con.Close();
            //}
        }
        catch (Exception ee)
        {

        }

    }
}