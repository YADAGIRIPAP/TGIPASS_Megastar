using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmADMGapplDashboard : System.Web.UI.Page
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
        ds = GetADMGmandalwise(Session["MROMandalID"].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblTotAppl.Text = ds.Tables[0].Rows[0]["Total No of Applications"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Approval Issued"].ToString();
            LblPendng.Text = ds.Tables[0].Rows[0]["No of Applications Pending"].ToString();
            lblRejctd.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            //Label12.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
            //Label18.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
            //Label3.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
            //Label21.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
            //Label22.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
            //Label6.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
            //Label8.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
            //Label1.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
            //Label2.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            //Label5.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
            //Label11.Text = ds.Tables[0].Rows[0]["No of Approvals Awaiting Payment"].ToString();
            //Label7.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            //Label9.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            //Label10.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
            //Label17.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            //Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();
            //lblrejectedatprescrutiny.Text = ds.Tables[0].Rows[0]["No of Applications Rejected PSC"].ToString();
        }

    }

    public DataSet GetADMGmandalwise(String MROMandalID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("sp_GetDepartmentDashboardDetailsCFO", con.GetConnection);
            da = new SqlDataAdapter("[sp_GetMandalwise_ADMG]", con.GetConnection);
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