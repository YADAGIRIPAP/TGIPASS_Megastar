using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Globalization;

using System.Text;

public partial class UI_TSIPASS_frmSbordinateDebtscheme_report : System.Web.UI.Page
{
    string stauts;
    string id;
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)

    {

        if(!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    stauts= Request.QueryString[0].ToString().Trim();
                }
            }
                    string RbtSMANPA = "";
            string created_by=Session["uid"].ToString();
            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter("SBORDINATEDEPTSCHEMEDETAILS_Report", osqlConnection); 
                //SBORDINATEDEPTSCHEMEDETAILS_Report
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (RbtSMANPA.Trim() == "" || RbtSMANPA.Trim() == null)
                oSqlDataAdapter.SelectCommand.Parameters.Add("@RbtSMANPA", SqlDbType.VarChar).Value = "%";
            else
                oSqlDataAdapter.SelectCommand.Parameters.Add("@RbtSMANPA", SqlDbType.VarChar).Value = RbtSMANPA.ToString();
            if (created_by.Trim() == "" || created_by.Trim() == null)
                oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = "%";
            else
                oSqlDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = created_by.ToString();
            if (stauts.Trim() == "" || stauts.Trim() == null)
                oSqlDataAdapter.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "%";
            else
                oSqlDataAdapter.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = stauts.ToString();

            DataSet oDataSet = new DataSet();
            oSqlDataAdapter.Fill(oDataSet);
            grdDetails.DataSource = oDataSet.Tables[0];
            grdDetails.DataBind();
            osqlConnection.Close();
            
        }

        
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //string sno_3 =  Row.Cells[1].Text.ToString();
             
            string sno_2 = e.Row.Cells[2].Text.ToString();
            string sno_1 = e.Row.Cells[3].Text.ToString();
            string sno_4 = e.Row.Cells[4].Text.ToString();
            string remarks = DataBinder.Eval(e.Row.DataItem, "remarks").ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h1 = (HyperLink)e.Row.FindControl("hypedit");
                h1.NavigateUrl = "frmSbordinateDebtScheme.aspx?ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"));
                h1.Text = "Click Here";
            }



        }
    }
}