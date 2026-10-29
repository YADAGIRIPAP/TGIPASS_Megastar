using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IIPC_COIDASHBOARD : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../IpassLogin.aspx");
        }
    }
    
    protected void btspeech_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmcoi_speech.aspx");

    }

    protected void btnmsmedata_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmcoispeechmsmedata.aspx");

    }
}