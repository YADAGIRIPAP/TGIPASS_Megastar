using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmAIMLReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPDFExtraction_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://13.202.25.127:5001/login");
    }

    protected void btnDiscrepancy_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://103.154.75.191/TSIPASSREPORTS/INDEX");
    }

    protected void btnquery_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://zealous-water-03451e300.2.azurestaticapps.net/");
    }
}