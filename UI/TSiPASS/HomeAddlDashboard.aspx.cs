using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_HomeAddlDashboard : System.Web.UI.Page
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

    protected void btnincentivenew_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmAddlashboard.aspx");
    }
}