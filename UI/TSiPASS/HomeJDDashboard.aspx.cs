using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_HomeJDDashboard : System.Web.UI.Page
{

General Gen = new General();

protected void Page_Load(object sender, EventArgs e)
{
    if (Session.Count <= 0)
    {
         Response.Redirect("~/Index.aspx");
    }
    if (!IsPostBack)
    {

     if (Convert.ToString(Session["uid"]) == "364490")
            {
                TRCFECFO.Visible = false;
                trnewinc.Visible = false;
            }
            

        }
        // jdbutton.Enabled = false;


    }

protected void BtnSave1_Click(object sender, EventArgs e)
{
        if (Convert.ToString(Session["uid"]) == "3377")
        {
            Response.Redirect("ReportsDashboardNew.aspx");

        }
        else
        {
            Response.Redirect("CFEDashboardJD.aspx");

        }

    }

protected void BtnDelete_Click(object sender, EventArgs e)
{
        if (Convert.ToString(Session["uid"]) == "3377")
        {
            Response.Redirect("ReportsDashboardCFO.aspx");

        }
        else
        {
            Response.Redirect("CFOJDDASHBOARD.aspx");
        }

}

protected void btnincentivenew_Click(object sender, EventArgs e)
{
    Response.Redirect("frmJDashboard.aspx");
}

    protected void Renewals_Click(object sender, EventArgs e)
    {
        Response.Redirect("RenewalsJD.aspx");
    }


    protected void Incentivesreport_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveReportsDashboard.aspx");
    }

    protected void btnttap_Click(object sender, EventArgs e)
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
}
