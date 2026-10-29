using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//designing and developed by siva as on 23-11-2015
//Purpose : To validate user details
//Tables used : tbl_Users

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Redirect("tshome.aspx");
            if (Session.Count != 0)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                if (!Page.IsPostBack)
                    Session.Abandon();
            }

            txtUserId.Focus();

            

            if (Request.Browser.Browser.ToString().Trim().ToLower() == "firefox")
            {
                //lblmsg.Text = "Please use Internet Explorer or Google Chrome";
                btnSignIn.Enabled = false;
            }
        }
    }
   
    protected void btnSignIn_Click1(object sender, ImageClickEventArgs e)
    {
       
        String UserID = "", Password = "";

        UserID = txtUserId.Text;
        Password = txtPwd.Text;

        General clsGeneral = new General();
        DataSet ds = clsGeneral.ValidateLogin(UserID, Password);
        DataView dv = ds.Tables[0].DefaultView;

        if (dv.Table.Rows.Count > 0)
        {
            Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
            Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
            Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
            Session["password"] = dv.Table.Rows[0]["password"].ToString();
            Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
            Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();

            Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();

            int i = clsGeneral.chkpwd(Session["user_id"].ToString());
            if (i == 1000)
            {
                //Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                Response.Redirect("UI/TSiPASS/Home.aspx");
            }
            else if (i == 99)
            {
                //Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                Response.Redirect("UI/TSiPASS/Home.aspx");
            }
            else
            {
                Response.Redirect("UI/TSiPASS/Home.aspx");
            }
            

        }
        else
        {
            //lblmsg.Text = "Invalid UserID/Password";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Invalid UserID/Password", true);
            return;
        }

    }


    public void EnterDataToLoginHistory()
    {
        




    }
}
