using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_MisreportDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btngrievancemis_Click(object sender, EventArgs e)
    {
        Response.Redirect("GrievanceMisreport.aspx");
    }
    protected void btnregulationmis_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBussinessRegulationMis.aspx");
    }
    protected void btncfemis_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTsipassMis.aspx");
    }
    protected void btnIncentive_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveMis.aspx");
    }
    protected void btncentralinspectionmis_Click(object sender, EventArgs e)
    {
        Response.Redirect("CentralInspectionMisreport.aspx");
    }

    protected void btnsinglewindow_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmSingleWindowDashboard.aspx");
    }
    protected void btngranted_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmGrantedDashboard.aspx");
    }
    protected void btnIncentivedashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveDashboardEODB.aspx");
    }
    protected void btnquery_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmQueryHandleEODBDashboard.aspx");
    }
    protected void btntourism_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTorusimEventDashboardEODB.aspx");
    }
    protected void btnTravelAgency_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTravelAgencyDashboardEODB.aspx");
    }
    protected void btnhotelcfe_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFEHotelDashboardEODB.aspx");
    }
    protected void btnhotelcfo_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFOHotelDashboardEODB.aspx");
    }
    protected void BTNHELPDESK_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmQueryHandleEODBDashboard_HELPDESKQUERY.aspx");
        
    }

    protected void btnallaaprwithfeedetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("CFEAllapprovalsIssuedwithFeedetails.aspx");
    }
    protected void btnDecrim_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmDecriminalisationList.aspx");
    }
    protected void btnfeedback_Click(object sender, EventArgs e)
    {
        Response.Redirect("feedbackreportNew.aspx");
    }
    protected void btnAIML_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAIMLReports.aspx");
    }
    

}