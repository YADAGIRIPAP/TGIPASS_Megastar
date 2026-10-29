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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class UI_TSiPASS_HEADOFFICEPENDENCYDRILLDOWN : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    DB.DB con = new DB.DB();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        lblHeading.Text = "View Applications";
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string userid = Request.QueryString[0].ToString().Trim();
            string status = Request.QueryString[1].ToString().Trim();

          
                ds = GETHEADOFFICEOFFICERWISEPENDENCYDRILLDOWN(userid, status);

            if (ds.Tables[0].Rows.Count > 0)
            {
               
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();


            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            HyperLink1.NavigateUrl = "HEADOFFICEOFFICERWISEPENDENCY.aspx";

        }


    }


    public DataSet GETHEADOFFICEOFFICERWISEPENDENCYDRILLDOWN(string userid,string status)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_INCENTIVE_PENDENCY_HEADOFFICE_NEW_TEST10022025_DRILLDOWN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (userid.Trim() == "" || userid.Trim() == null)
                da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = userid.ToString();

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = status.ToString();
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
       // ExportToExcel();
    }
}