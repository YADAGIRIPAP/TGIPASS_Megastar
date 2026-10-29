using AjaxControlToolkit.HTMLEditor.ToolbarButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_DashboardINC : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect("~/TSHome.aspx");

        }
        else
        {
            string uid = Convert.ToString(Session["uid"]);
            string[] allowedUids = { "324563", "324565", "324566", "324567", "324568", "324569", "324570" };

            if (allowedUids.Contains(uid))
            {
                // Cast to HtmlTableCell instead of TableCell
                HtmlTableCell leftMenuTd = Master.FindControl("MstLftMenu") as HtmlTableCell;
                if (leftMenuTd != null)
                {
                    leftMenuTd.Style.Add("display", "none");
                }

                btnIncentive.Visible = true;
            }
            else
            {
                Response.Redirect("~/TSHome.aspx");
            }
        }
    }

    protected void btnIncentive_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveApplicationsList.aspx?status=INC");
    }

    protected void btncmpltd_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveApplicationsList.aspx?status=Completed");

    }
    private Control FindControlRecursive(Control root, string id)
    {
        if (root.ID == id)
        {
            return root;
        }

        foreach (Control control in root.Controls)
        {
            Control foundControl = FindControlRecursive(control, id);
            if (foundControl != null)
            {
                return foundControl;
            }
        }

        return null;
    }
}