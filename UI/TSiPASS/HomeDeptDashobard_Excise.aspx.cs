using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSIPASS_HomeDeptDashobard_Excise : System.Web.UI.Page
{
    string createdBy = "";
    string userName = "";
    string password = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            createdBy = Session["uid"].ToString();
            userName = Session["username"].ToString();
            password = Session["password_decrypt"].ToString();
        }



    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" &&
        (Session["uid"].ToString() != "96099"))
            Response.Redirect("http://183.82.106.234/HPFS/tscentral/index.php/site/logineodb?username=dm_rhizome&password=Admin@123&uid=17083&approvalid=141");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" &&
         (Session["uid"].ToString() != "96099"))
            Response.Redirect("http://183.82.106.234/HPFS/tscentral/index.php/site/logineodb?username=dm_rhizome&password=Admin@123&uid=17083&approvalid=142");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" &&
            (Session["uid"].ToString() != "96099"))


            Response.Redirect("http://183.82.106.234/HPFS/tscentral/index.php/site/logineodb?username=dm_rhizome&password=Admin@123&uid=17083&approvalid=143");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["uid"].ToString() != "17083" && Session["uid"].ToString() != "4518" && Session["uid"].ToString() != "96097" &&
        (Session["uid"].ToString() == "96099"))
            Response.Redirect("http://183.82.106.234/HPFS/tscentral/index.php/site/logineodb?username=ARTISAN&password=Admin@4321&uid=17083&approvalid=143");

    }
}