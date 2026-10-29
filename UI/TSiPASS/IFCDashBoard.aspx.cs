using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IFCDashBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
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

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryDashBoard.aspx");

    }
}