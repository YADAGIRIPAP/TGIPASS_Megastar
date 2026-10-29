using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class DistOtherServicesLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkbtnLogin_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtuname.Text) || String.IsNullOrEmpty(txtpsw.Text))
        {
            lblmsg0.Text = "Please provide User Name and Password";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
            Failure.Visible = true;
        }
        else
        {
            success.Visible = false;
            Failure.Visible = false;
            String UserID = "", Password = "", Dept = "";

            UserID = txtuname.Text;
            Password = txtpsw.Text;
            Dept = "%";

            General clsGeneral = new General();
            string encpassword = clsGeneral.Encrypt(Password, "SYSTIME");
            DataSet ds = clsGeneral.ValidateLoginReforms(UserID, Password, encpassword);//,Dept
            DataView dv = ds.Tables[0].DefaultView;
            DataSet dsnew = new DataSet();

            // dsnew = clsGeneral.UpdateCFOUID();

            if (dv.Table.Rows.Count > 0)
            {
                Session["uid"] = dv.Table.Rows[0]["UserReformId"].ToString();
                Session["username"]= dv.Table.Rows[0]["UserId"].ToString();
                Session["PwdEncryflag"] = dv.Table.Rows[0]["PwdEncryflag"].ToString();

                if (Session["PwdEncryflag"] == null || Session["PwdEncryflag"].ToString() == "")
                {
                    Response.Redirect("UI/TSiPASS/frmDistRefChangePassword.aspx");
                }
                else
                {
                    Response.Redirect("UI/TSiPASS/ApplicationTrackerOtherService.aspx");
                }
            
            }
            else
            {
                lblmsg0.Text = "Invalid UserName or Password";
                Failure.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
            }
        }
    }
}