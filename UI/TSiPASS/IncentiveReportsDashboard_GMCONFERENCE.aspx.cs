using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IncentiveReportsDashboard_GMCONFERENCE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "359104" || Session["uid"].ToString() == "359030")
            {
                lir1.Visible = true;
                lir2.Visible = true;
                lir3.Visible = true;
                lir4.Visible = true;
                lir5.Visible = true;
                li6.Visible = true;
                li7.Visible = true;
                li8.Visible = true;
                li9.Visible = true;
            }
            else
            {
                lir1.Visible = false;
                lir2.Visible = false;
                lir3.Visible = false;
                lir4.Visible = false;
                lir5.Visible = false;
                li6.Visible = false;
                li7.Visible = false;
                li8.Visible = false;
                li9.Visible = false;
            }
        }
    }

}