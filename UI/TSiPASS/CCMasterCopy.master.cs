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
using System.Text;

public partial class CCMaster : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //TSTDashboard.Visible = false;
        //IPDashboard.Visible = false;

        if (Session.Count > 0)
        {
           

            if (Session["userlevel"].ToString() == "10")
            {

             //   Li2.Visible = true;

            }

            else
            {

             //   Li2.Visible = false;
            }





        }


    }
}
