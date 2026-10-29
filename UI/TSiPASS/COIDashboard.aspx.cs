using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_COIDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["uid"]) ==""|| Convert.ToString(Session["username"])!="Commissioner")
        {
            Response.Redirect("~/TSHome.aspx");
        }
    }

    protected void btnCFE_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCommissionerReportDashboard.aspx");
    }

    protected void btnCFO_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCommissionerReportDashboardCFO.aspx");
    }

    protected void btnINC_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveDashBoard.aspx");
    }
    protected void btnTTAP_Click(object sender, EventArgs e)
    {
        string UserId = Session["user_id"].ToString();
        string Password = Session["password"].ToString();
        string Flag = Session["PwdEncryflag"].ToString();
        string CreateBy = Session["uid"].ToString();
        string Role = Session["Role_Code"].ToString();
        string User_level = Session["userlevel"].ToString();
        string Fromname = Session["Type"].ToString();
        string DistrictID = Session["DistrictID"].ToString();
        string User_type = Session["user_type"].ToString();

        Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserId + "&UserCode=" + Password + "&Flg=Y&CreateBy=" +
                                CreateBy + "&Role=" + Role + "&User_level=" + User_level + "&Fromname=" + Fromname + "&DistrictID=" + DistrictID + "&User_type=" + User_type);
    }
    protected void btnsvc_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmSVCDEPTProcessedApplication_Commissioner.aspx");
    }
}