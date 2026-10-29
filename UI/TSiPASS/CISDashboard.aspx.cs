using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_CISDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btninspection_Click(object sender, EventArgs e)
    {
        Response.Redirect("InspectionreportStatus.aspx");
    }
    protected void btncentralinspectionmis_Click(object sender, EventArgs e)
    {
        Response.Redirect("CentralInspectionMisreport.aspx");
    }
}