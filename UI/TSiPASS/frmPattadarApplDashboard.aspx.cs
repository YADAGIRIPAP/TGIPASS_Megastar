using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmPattadarApplDashboard : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session.Count <= 0)
        {
            //    Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            FillDetails();
        }
    }
    void FillDetails()
    {
        DataSet ds = new DataSet();
        ds = GetPattalandAppl(Session["MROMandalID"].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblTotAppl.Text = ds.Tables[0].Rows[0]["Total No of Applications"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Approval Issued"].ToString();
            LblPendng.Text = ds.Tables[0].Rows[0]["No of Applications Pending"].ToString();
            lblRejctd.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
           
        }

    }

    public DataSet GetPattalandAppl(String MROMandalID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("sp_GetDepartmentDashboardDetailsCFO", con.GetConnection);
            da = new SqlDataAdapter("[Sp_GetPattalandApplications]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (MROMandalID.Trim() == "" || MROMandalID.Trim() == null)
                da.SelectCommand.Parameters.Add("@MROMandalID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MROMandalID", SqlDbType.VarChar).Value = MROMandalID.ToString();

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