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

public partial class Default3 : System.Web.UI.Page
{

    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {

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


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["userlevel"].ToString() == "13" || Session["userlevel"].ToString() == "10")
        {
            Response.Redirect("DashboardNewGriv.aspx");
        }
        else
        {
            Response.Redirect("GreivanceDashboard.aspx");
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmDepartementDashboardNewIndus.aspx");

    }
    protected void btnnewprocess_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmDepartementDashboardNewIndusNew.aspx");

    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmDepartementDashboardNewCFOIndus.aspx");
    }

    protected void btnFeedBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("DeptFeedBackStatusDetails.aspx");


    }
}
