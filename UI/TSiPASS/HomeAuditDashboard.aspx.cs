using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_HomeAuditDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {



        }
    }

    protected void TTAP_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveReportAudit_TTAP.aspx");

    }

    protected void btnincentivenew_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveReportAudit.aspx");
    }
}