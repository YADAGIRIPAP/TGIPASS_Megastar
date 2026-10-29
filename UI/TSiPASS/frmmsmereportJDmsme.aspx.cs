using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmmsmereportJDmsme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmmsmeupdatedreport.aspx");
    }
    protected void btnemployment_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmMSMEReportEmployement.aspx");
    }

    protected void btnmapped_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmmsmecfeuitscuurentmonthreports.aspx");
    }
    protected void btnmsme_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmMSMEReport.aspx");
    }
}