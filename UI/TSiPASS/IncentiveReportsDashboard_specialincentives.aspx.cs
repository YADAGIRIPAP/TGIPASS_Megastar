using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IncentiveReportsDashboard_specialincentives : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            if (Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424" || Session["uid"].ToString() == "77141" || Session["uid"].ToString() == "34668")
            {
                gmcoireport.Visible = true;
                gmcoi1.Visible = true;
                gmcoi2.Visible = true;
                gmcoireport9.Visible = true;
                gmcoireport10.Visible = true;
                gmcoi3.Visible = false;
                gmcoi22.Visible = false;
                gmcoi4.Visible = false;
                gmcoi5.Visible = false;
                gmcoi6.Visible = false;
                gmcoi7.Visible = false;
                gmcoi8.Visible = false;
                Li1.Visible = false;
                A2.Visible = false;
                Ulgmdelayreport.Visible = true;
            }
            else if (Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "32951")
            {
                Ul1.Visible = true;
            }
            else
            {
                gmcoireport.Visible = false;
            }
            if (Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424")
            {
                AUTOREJECTED.Visible = false;
            }
        }
    }
}