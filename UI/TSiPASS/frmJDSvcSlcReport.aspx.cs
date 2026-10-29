using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;

using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Activities.Statements;

public partial class UI_TSIPASS_frmJDSvcSlcReport : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindDipcDates(ddlDIPCSLC.SelectedItem.Text.ToString());
            Label1.Text = "Report as on date " + DateTime.Now;

        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bindGRidData(ddlDIPCSlcDate.SelectedItem.Text,ddlDIPCSLC.SelectedItem.Text);
    }
    protected void bindGRidData(string ddlDIPCSLCvals,string date)
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();

 
            da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_DIPCAGENDAPrint_JDReport", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@date", SqlDbType.VarChar).Value = ddlDIPCSLCvals;
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "A";
            da.SelectCommand.Parameters.Add("@slcDIPC", SqlDbType.VarChar).Value = date;
            da.SelectCommand.CommandTimeout = 4800;

            da.Fill(ds);
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }
    protected void bindDipcDates(string ddlDIPCSLC_val)
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
 
            da = new SqlDataAdapter("USP_GET_UNIT_INCENTIVEWISE_DIPCAGENDAPrint_JDReport", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@slcDIPC", SqlDbType.VarChar).Value = ddlDIPCSLC_val;
            da.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = "B";

            da.Fill(ds);
            ddlDIPCSlcDate.DataSource = ds.Tables[0];
            ddlDIPCSlcDate.DataTextField = "ProposedDIPCDATE";
            ddlDIPCSlcDate.DataBind();



        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    protected void ddlDIPCSLC_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDipcDates(ddlDIPCSLC.SelectedItem.Text.ToString());
    }
}