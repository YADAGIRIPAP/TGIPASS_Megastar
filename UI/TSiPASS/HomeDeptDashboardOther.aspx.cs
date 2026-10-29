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

public partial class UI_TSiPASS_HomeDeptDashboardOther : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../IpassLogin.aspx");
        }

        if (!IsPostBack)
        {
            

        }


    }



    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //if (Session["uid"].ToString() == "1134" || Session["uid"].ToString() == "1135" || Session["uid"].ToString() == "1136" || Session["uid"].ToString() == "1137" || Session["uid"].ToString() == "1138"
        //        || Session["uid"].ToString() == "1139" || Session["uid"].ToString() == "1140" || Session["uid"].ToString() == "1141" || Session["uid"].ToString() == "1142" || Session["uid"].ToString() == "1143")
        //{

        //    Response.Redirect("CollectorDistrictWiseReportDIC.aspx");

        //}
        //else
        //{
        if (Session["User_code"].ToString() == "408" || Session["User_code"].ToString() == "410")
        {
            Response.Redirect("frmDepartementDashboardNewOther.aspx");

        }
        else
        {
            Response.Redirect("frmDepartementDashboardNew.aspx");
        }
        //}

    }

   
}