using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class UI_TSiPASS_frmMandalFacilitatorsdrilldown : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null || Session["uid"].ToString() == "")
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {

            if (!IsPostBack)
            {
                Binddata(Request.QueryString[0], Request.QueryString[1]);
            }

        }
    }
    protected void Binddata(string Districtid,string Mandal)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_MANDALLEVEL_WOMENCELLFECILITATORDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Districtid == null || Districtid == "" || Districtid == "-Select" || Districtid == "0")
            {
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Districtid;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Districtid;
            }
            if (Mandal == null || Mandal == "" || Mandal == "-Select" || Mandal == "0")
            {
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = Mandal;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@MANDAL", SqlDbType.VarChar).Value = Mandal;
            }
            da.Fill(ds);
            con.CloseConnection();
            
            grddistfacilitatordetails.DataSource = ds.Tables[0];
            grddistfacilitatordetails.DataBind();


        }
        catch (Exception Ex)
        { throw Ex; }
    }
}