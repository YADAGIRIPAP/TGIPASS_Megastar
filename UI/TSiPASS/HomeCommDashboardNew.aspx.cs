using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Web.Configuration;
using System.Threading;
using System.ComponentModel;
using System.Text;

public partial class UI_TSiPASS_HomeCommDashboardNew : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (Session["userlevel"].ToString().Trim() == "13" || Session["userlevel"].ToString().Trim() == "10" || Session["userlevel"].ToString().Trim() == "12" || Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24" || Session["userlevel"].ToString().Trim() == "25" || Session["userlevel"].ToString().Trim() == "40")
        {
            //Response.Redirect("Dashboard.aspx");  //added newly on 16.1.19. Nikhil..
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {

            //DataSet ds = new DataSet();
            //ds = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    BtnDelete.Visible = true;
            //}
            //else
            //{

            //    BtnDelete.Visible = false;
            //}


        }


    }

    protected void btncoidashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("comReportDrillnew.aspx");

    }

}