using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmSVCDEPTProcessedApplication_Commissioner : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            //    Response.Redirect("../../frmUserLogin.aspx");
        }
        if (!IsPostBack)
        {
            FillDetails();
        }
    }
    void FillDetails()
    {
        DataSet ds = new DataSet();    
            ds = GetIPOIncentiveDashboardNew();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblpending_commissioner.Text = ds.Tables[0].Rows[0]["SVC Approved-Pending at Commissioner"].ToString();
            lblprocessed_commissioner.Text = ds.Tables[0].Rows[0]["Approved by Commissioner"].ToString();
            lblreturnedby_comissioner.Text = ds.Tables[0].Rows[0]["Returned by Commissioner"].ToString();
        }
    }
    public DataSet GetIPOIncentiveDashboardNew()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_COMMISSIONER_DASHBOARD_SVC", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 600;
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
}