using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;


public partial class UI_TSIPASS_frmcoiGeneralDD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string querystrg1 = Request.QueryString["status"].ToString();
            string querystrg2 = Request.QueryString["code"].ToString();
            //"frmcoiGeneralDD.aspx?status=cfeAppeal&code=trc";

            SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
           
            osqlConnection.Open();
            oSqlDataAdapter = new SqlDataAdapter("cfeCfoGrievGenQuqery_drilldown", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            oSqlDataAdapter.SelectCommand.Parameters.Add("@typeID", SqlDbType.VarChar).Value = querystrg1.ToString();

            oSqlDataAdapter.SelectCommand.Parameters.Add("@subTypeID", SqlDbType.VarChar).Value = querystrg2.ToString();
    
            oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            grdDetails.DataSource = oDataSet.Tables[0];
            grdDetails.DataBind();
        }
    }
}