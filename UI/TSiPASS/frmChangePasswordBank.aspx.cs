using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class UI_TSiPASS_frmChangePasswordBank : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                FillCapctha();
            }
            lbluserid.Text = Session["username"].ToString();
            chkpwd();
            // txtPwd.Text = "TSIPASS123";
        }

    }

    void chkpwd()
    {
        int i = Gen.chkpwd(Session["user_id"].ToString());
        if (i == 1000)
        {
            //  warning.Visible = true;
            // lbluserid0.Text = "Please remember to change your password the first time you access..";
        }
        else if (i == 99)
        {
            //  lbluserid0.Text = "Please change your password periodically.";
            //  warning.Visible = true;

        }
        else
        {
            //  warning.Visible = false;

        }

    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        String UserID = "", Password = "", Newpassword = "";
        int retval = 0;
        if (ViewState["captcha"].ToString() != txtCaptcha.Text.Trim().TrimStart())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
            FillCapctha();
            lblmsg.Text = "Invalid Captcha Code !!.";
            success.Visible = false;
            Failure.Visible = true;
            txtCaptcha.Text = "";
            return;
        }

        if (BtnSave1.Text == "Submit")
        {
            if (txtPwd.Text.Trim() == TxtNpwd.Text.Trim())
            {
                lblmsg.Text = "Old Password and New Password should not be same";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            UserID = Session["user_id"].ToString();
            //Password = txtPwd.Text;
            Password = Gen.Encrypt(txtPwd.Text.Trim(), "SYSTIME");

            //General clsGeneral = new General();
            DataSet dv = Gen.ValidateLoginReset(UserID, Password.ToString(), txtPwd.Text.Trim());
            //DataView dv = ds.Tables[0].DefaultView;

            if (dv != null && dv.Tables.Count > 0 && dv.Tables[0].Rows.Count > 0)
            {
                Newpassword = Gen.Encrypt(TxtNpwd.Text.Trim(), "SYSTIME");

                retval = Gen.ChangePassword(UserID, Newpassword, Session["uid"].ToString());
                if (retval == -1)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password Successfully Changed.Please login again with new passwod');", true);
                    lblmsg.Text = "Password Successfully Changed";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                    hidetable.Visible = false;
                    trsubmittion.Visible = false;
                    trchangepewmessage.Visible = true;
                    hidetablepassword.Visible = false;
                }
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
            }
        }
    }

    void FillCapctha()
    {
        try
        {
            ViewState["captcha"] = "";

            Random random = new Random();
            string combination = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();

            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            ViewState["captcha"] = captcha.ToString();
            imgCaptcha.ImageUrl = "CaptchaHandler.ashx?query=" + captcha.ToString();
        }
        catch
        {
            throw;
        }
    }
    void clear()
    {
        BtnSave1.Text = "Submit";
        TxtNpwd.Text = "";
        txtPwd.Text = "";
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmChangePassword.aspx");
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtCaptcha.Text = "";
        FillCapctha();
    }
}