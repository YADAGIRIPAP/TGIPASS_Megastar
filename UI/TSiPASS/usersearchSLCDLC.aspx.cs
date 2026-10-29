using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSIPASS_usersearchSLCDLC : System.Web.UI.Page
{

    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
        }



    }
    public void getdata()
    {

        SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        osqlConnection.Open();
        SqlDataAdapter da;
        da = new SqlDataAdapter("USP_GETUSERDETAILS", osqlConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet ds = new DataSet();
        da.SelectCommand.Parameters.Add("@distid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString();
        da.Fill(ds);
        osqlConnection.Close();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                e.Row.Cells[3].Text = gen.Decrypt(e.Row.Cells[3].Text.Trim(), "SYSTIME");
            }
        }
        catch (Exception ex)
        {

        }
    }
}
 