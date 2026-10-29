using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;

public partial class frmBridgeAccLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //DataSet ds = new DataSet();
                //ds = objcommon.GetHomepagecontete();
                //if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count >     0)
                //{
                //    lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
                //}

                if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                {
                    string UserId = Request.QueryString["UserId"].ToString();
                    string UserCode = Request.QueryString["UserCode"].ToString();
                    string Flg = Request.QueryString["Flg"].ToString();
                    if (Flg.Trim().TrimStart() == "Y")
                    {
                        General clsGeneral = new General();
                        string Decrypt = clsGeneral.Decrypt(UserCode.Replace(" ", "+"), "SYSTIME");
                        txtpsw.TextMode = TextBoxMode.SingleLine;
                        txtuname.Text = UserId;
                        txtpsw.Text = Decrypt;
                        lnkbtnLogin_Click(sender, e);
                    }
                    else
                    {
                        txtpsw.TextMode = TextBoxMode.SingleLine;
                        txtuname.Text = UserId;
                        txtpsw.Text = UserCode;
                        lnkbtnLogin_Click(sender, e);
                    }
                }
            }
            txtuname.Focus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
                DataSet ds = clsGeneral.ValidateLoginNew(UserID, Password, encpassword);//,Dept
                DataView dv = ds.Tables[0].DefaultView;
                DataSet dsnew = new DataSet();

                // dsnew = clsGeneral.UpdateCFOUID();

                if (dv.Table.Rows.Count > 0)
                {
                    Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
                    Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
                    Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
                    Session["password"] = dv.Table.Rows[0]["password"].ToString();
                    Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
                    Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();
                    Session["Type"] = dv.Table.Rows[0]["Fromname"].ToString();
                    Session["MobileNumber"] = dv.Table.Rows[0]["MobileNumber"].ToString();
                    Session["Email"] = dv.Table.Rows[0]["EmailE"].ToString();
                    Session["usernameAppl"] = dv.Table.Rows[0]["username"].ToString();//nikhil
                    Session["Role_Code"] = dv.Table.Rows[0]["Role_Code"].ToString();//added by lavanya
                    Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
                    Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
                    Session["intDeptid"] = dv.Table.Rows[0]["intDeptid"].ToString();
                    Session["Visibleflag"] = dv.Table.Rows[0]["Visibleflag"].ToString();
                    Session["DummyLogin"] = dv.Table.Rows[0]["DummyLogin"].ToString();
                    Session["DefaultPwd"] = dv.Table.Rows[0]["DefaultPwd"].ToString();
                    Session["PwdEncryflag"] = dv.Table.Rows[0]["PwdEncryflag"].ToString();
                    Session["ECAF"] = "N";

                    string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                    //if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                    //{
                    //    Response.Redirect("UI/TSiPASS/IpassFeedBackForm.aspx");
                    //}
                    if (Session["userlevel"].ToString().Trim() != "14" || Session["Type"].ToString().Trim() != "Banker")
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("UI/TSiPASS/frmSbordinateDebtscheme.aspx");
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