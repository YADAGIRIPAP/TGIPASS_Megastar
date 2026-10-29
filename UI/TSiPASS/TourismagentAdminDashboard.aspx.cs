using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_TourismagentAdminDashboard : System.Web.UI.Page
{
    Cls_travelagent obj_travelagent = new Cls_travelagent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
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
        ds = obj_travelagent.GetDepartmentDashboardDetails_tourismagent(Session["User_Code"].ToString().Trim());
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
        }
    }
}