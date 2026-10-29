using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_SWGDeptDashboard : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["uid"]) == "")
            {
                Response.Redirect("~/Ipasslogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();

            //ds = Gen.GetDepartmentDashboardDetails(Session["User_Code"].ToString().Trim());
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
           };
            pp[0].Value = Session["User_Code"].ToString().Trim();
            ds = Gen.GenericFillDs("sp_GetSewerageDepartmentDashboard", pp);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Label4.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
                Label12.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
                Label18.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
                Label21.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
                Label22.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
                Label6.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
                Label8.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
                Label5.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
                Label11.Text = ds.Tables[0].Rows[0]["No of Approvals Awaiting Payment"].ToString();
                Label7.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
                Label9.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
                Label10.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
                Label17.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
                Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();

                lblrejectedatprescrutiny.Text = ds.Tables[0].Rows[0]["No of Applications Rejected PSC"].ToString();

                lblprelastday.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days Tomorrow"].ToString();
                lblapprlastday.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits Tomorrow"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public DataSet GetDepartentApplications(string Deptid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
           };
        pp[0].Value = Deptid;
        Dsnew = Gen.GenericFillDs("[USP_CFE_DASHBOARD_DEPARTMENT]", pp);
        return Dsnew;
    }
}