using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_Misreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btncfemis_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTsipassMis.aspx");
    }
   
    protected void btnglanceReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("GlanceReport.aspx");
    }
    protected void btnfinancial_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinancialYear.aspx"); 
    }
    protected void btnsector_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmSectorWise.aspx"); 
    }
}