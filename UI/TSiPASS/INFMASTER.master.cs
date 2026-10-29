using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_INFMASTER : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            lblwecome.Text = Session["username"].ToString();
        }
    }
    protected void lbtnIndusries_Click(object sender, EventArgs e)
    {
        string UserID = Session["user_id"].ToString();
        string Password = Session["password"].ToString();
        string Flag = Session["PwdEncryflag"].ToString();


        Response.Redirect("http://www.industries.telangana.gov.in/newLogin.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (Session["userlevel"].ToString().Trim() == "13")
        {
            //Response.Redirect("Dashboard.aspx");
            Response.Redirect("HomeDashboard.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "25")
        {
            Response.Redirect("Home.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "12")
        {
            Response.Redirect("frmApprovelDocument.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "10")
        {

            if (Session["uid"].ToString().Trim() == "1030")
            {

                Response.Redirect("HomeIndusDashboard.aspx");
            }
            else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
            {
                Response.Redirect("IFCDashBoard.aspx");
            }
            else
            {
                //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                //{
                //    Response.Redirect("frmIPOIncentiveDashboard.aspx");
                //}
                if (Session["userlevel"].ToString().Trim() == "10")
                {

                    if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                    {
                        Response.Redirect("frmIPOIncentiveDashboardNew.aspx");
                    }
                    else
                    {
                        //Response.Redirect("frmDepartementDashboardNew.aspx");
                        Response.Redirect("HomeDeptDashboard.aspx");
                    }
                }

                //Response.Redirect("frmDepartementDashboardNew.aspx");
                //  Response.Redirect("HomeDeptDashboard.aspx");

            }

            //Response.Redirect("frmDepartementDashboardNew.aspx");
            //Response.Redirect("HomeDeptDashboard.aspx");

        }
        else
        {
            if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "3378")
            {
                Response.Redirect("HomeCommDashboard.aspx");
            }
            else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT")
            {
                Response.Redirect("HomeCoiDashboard.aspx");
            }
            else if (Session["uid"].ToString().Trim() == "1622")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "35")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
            {
                Response.Redirect("HomeCommDashboardNew.aspx");
            }
            else
            {
                Response.Redirect("ReportsDashboardNew.aspx");
            }
        }

    }
}
