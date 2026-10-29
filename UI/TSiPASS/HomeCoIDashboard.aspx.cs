using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_HomeCoIDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/IpassLogin.aspx");
        }
        if (Session["uid"].ToString() == "57783")
        {
            tdrelease.Visible = true;
        }
        else
        {
            tdrelease.Visible = false;
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        string user = Session["uid"].ToString();
        if (user == "57783")
        {
            //Response.Redirect("frmDashBoardSLC.aspx");
            string url = "frmDashBoardSLC.aspx";
            string script = "window.open('" + url + "', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenSLCDashboard", script, true);
        }
        else if (Session["Role_Code"].ToString() == "COI-CLERK")
        {
            Response.Redirect("frmCoiDashboardclerk.aspx");
        }
        else if (Session["Role_Code"].ToString() == "COI-SUPDT")
        {
            Response.Redirect("frmCoiDashboardSUPDT.aspx");
        }
        else if (Session["Role_Code"].ToString() == "COI-AD")
        {
            if (user == "32952" || user == "32953")
            {
                Response.Redirect("frmCoiDashboardAD.aspx");
            }
            else
            {
                Response.Redirect("frmCoiDashboardadNew.aspx");
            }
        }
        else if (Session["Role_Code"].ToString() == "COI-DD")
        {
            Response.Redirect("frmCoiDashboardDD.aspx");
        }
        else
        {
            Response.Redirect("frmCoiDashboard.aspx");
        }
    }

    protected void BTNPRINT_Click(object sender, EventArgs e)
    {
        Response.Redirect("Appraisalnoteprint.aspx");
    }
    protected void btnbulk_Click(object sender, EventArgs e)
    {
        Response.Redirect("Appraisalnote2_bulk.aspx");
    }
    protected void btnReleasepending_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReleaseProcedingsStep2New.aspx");
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

        //Response.Redirect("http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserId + "&UserCode=" + Password + "&Flg=Y&CreateBy=" +
        //                        CreateBy + "&Role=" + Role + "&User_level=" + User_level + "&Fromname=" + Fromname + "&DistrictID=" + DistrictID + "&User_type=" + User_type);
        string url = "http://120.138.9.236/TTAP/loginReg.aspx?UserId=" + UserId
           + "&UserCode=" + Password
           + "&Flg=Y"
           + "&CreateBy=" + CreateBy
           + "&Role=" + Role
           + "&User_level=" + User_level
           + "&Fromname=" + Fromname
           + "&DistrictID=" + DistrictID
           + "&User_type=" + User_type;

        // open in new tab
        string script = "window.open('" + url + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenTTAP", script, true);
    }
    
}