using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using iTextSharp.text;

public partial class IpassLogin : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General clsGeneral = new General();
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillCapctha();
                if (Session["uid"] != null || Convert.ToString(Session["uid"]) != "")
                {
                    UpdateLogout();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "runJS", "checkSessionInJS();", true);
                if (Request.QueryString.Count == 0)
                { Killsession(); }
                if (Session.Count > 0 && Request.QueryString.Count == 0)
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please logout from all Tabs and then Login";
                    lblmsg0.Visible = true;
                    txtuname.Enabled = false;
                    txtpsw.Enabled = false;
                }
                /*
                if (Request.QueryString.Count > 0 && Request.QueryString.Count != 2) // Convert.ToString(Request.QueryString["IsTtap"]) != "")
                {
                    if (Request.QueryString["UserId"].ToString() != "" && Request.QueryString["Website"].ToString() != "")
                    {
                        if (Request.QueryString["Website"].ToString() == "Industries" || Request.QueryString["Website"].ToString() == "TTAP")
                        {
                            txtuname.Text = Request.QueryString["UserId"].ToString().Trim();
                            txtpsw.Text = Request.QueryString["UserCode"].ToString().Trim();
                            string PwdEncryflag = Request.QueryString["PwdEncryflag"].ToString().Trim();
                            TTAPLogin(txtuname.Text, txtpsw.Text, PwdEncryflag);
                        }
                    }
                }
                */

                //DataSet ds = new DataSet();
                //ds = objcommon.GetHomepagecontete();
                //if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count >     0)
                //{
                //    lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
                //}
                if (Request.QueryString.Count > 0 && Request.QueryString.Count != 2)
                {
                    Session["RedirectfromNSWSURL"] = "Y";

                    //HdnSession.Value = System.Web.HttpContext.Current.Session.SessionID;

                }


                //if (Request.QueryString.Count > 0 && Request.QueryString.Count == 2)
                //{
                //    if (Request.QueryString["IntUserId"].ToString() != "" && Request.QueryString["IsTtap"].ToString() != "")
                //    {
                //        txtuname.Text = Request.QueryString["UserName"].ToString().Trim();
                //        txtpsw.Text = Request.QueryString["Password"].ToString().Trim();
                //        TTAPLogin(txtuname.Text, txtpsw.Text);
                //    }
                //}
                if (Request.QueryString.Count > 0 && Request.QueryString.Count == 2)
                {
                    Session["RedirectfromNSWSURL"] = "Y";
                    // prevPagensws = Request.UrlReferrer.ToString();
                    string UserName = Request.QueryString["UserName"].ToString();
                    string Password = Request.QueryString["Password"].ToString();
                    string nswspassword = "";
                    //LogErrorFile.LogData("NSWS USER REDIRECTION URL " + Request.UrlReferrer.ToString());
                    LogErrorFile.LogData(Convert.ToString(UserName + "password: " + Password));
                    General clsGeneral = new General();
                    string DecryptUserName = clsGeneral.Decrypt(UserName, "SYSTIME");
                    DataSet dspass = new DataSet();
                    dspass = DB_Getredirectuserurlbytsipassid(DecryptUserName, null, null);
                    if (dspass != null && dspass.Tables.Count > 0 && dspass.Tables[0].Rows.Count > 0)
                    {
                        nswspassword = Convert.ToString(dspass.Tables[0].Rows[0]["Password"]);
                        LogErrorFile.LogData(Convert.ToString(DecryptUserName + " DBpassword: " + nswspassword));
                    }
                    Password = nswspassword;
                    LogErrorFile.LogData(Convert.ToString(UserName + "newpassword" + Password));
                    string DecryptPassword = clsGeneral.Decrypt(Password, "SYSTIME");
                    LogErrorFile.LogData(Convert.ToString(UserName + "DecryptPassword is-" + DecryptPassword));
                    txtpsw.TextMode = TextBoxMode.SingleLine;
                    txtuname.Text = DecryptUserName;
                    txtpsw.Text = DecryptPassword;
                    //lnkbtnLogin_Click(sender, e);
                    //TTAPLogin(txtuname.Text, Password, "Y");
                    TTAPLogin(txtuname.Text, Password);
                }
                else
                {
                    Session["RedirectfromNSWSURL"] = "N";
                    //LogErrorFile.LogData(Convert.ToString("FROM TTAP LOGIN" ));
                    if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["PwdEncryflag"] != null)
                    {
                        string UserId = Request.QueryString["UserId"].ToString();
                        string UserCode = Request.QueryString["UserCode"].ToString();
                        string Flg = Request.QueryString["PwdEncryflag"].ToString();
                        if (Flg.Trim().TrimStart() == "Y")
                        {
                            General clsGeneral = new General();
                            string Decrypt = clsGeneral.Decrypt(UserCode.Replace(" ", "+"), "SYSTIME");
                            txtpsw.TextMode = TextBoxMode.SingleLine;
                            txtuname.Text = UserId;
                            txtpsw.Text = Decrypt;
                            //lnkbtnLogin_Click(sender, e);
                            TTAPLogin(txtuname.Text, UserCode, "Y");
                        }
                        else
                        {
                            txtpsw.TextMode = TextBoxMode.SingleLine;
                            txtuname.Text = UserId;
                            txtpsw.Text = UserCode;
                            // lnkbtnLogin_Click(sender, e);
                            TTAPLogin(txtuname.Text, txtpsw.Text, "N");
                        }

                    }
                }
            }
            txtuname.Focus();
        }
        catch (Exception ex)
        {
            //   throw ex;

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "");
        }
    }
    public void UpdateLogout()
    {
        try
        {
            int valid = 0;


            con.OpenConnection();
            SqlCommand da = new SqlCommand("[Sp_UpdateLogoutDetails]", con.GetConnection);
            da.CommandType = CommandType.StoredProcedure;
            try
            {
                string SessionID = Session.SessionID;
                da.Parameters.Add("@userid", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
                da.Parameters.Add("@username", SqlDbType.VarChar).Value = Convert.ToString(Session["username"]);
                da.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = SessionID;

                da.Parameters.Add("@result", SqlDbType.Int, 500);
                da.Parameters["@result"].Direction = ParameterDirection.Output;
                da.ExecuteNonQuery();
                valid = (Int32)da.Parameters["@result"].Value;
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        catch (Exception ex) { }
    }

    public void UPDATEIPADDRESS(string CREATED_BY, string IPADDRESS)
    {
        int valid = 0;


        con.OpenConnection();
        SqlCommand da = new SqlCommand("[SP_INSERT_IPADDRESS]", con.GetConnection);
        da.CommandType = CommandType.StoredProcedure;
        try
        {
            string SessionID = Session.SessionID;
            da.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY;
            da.Parameters.Add("@IPADDRESS", SqlDbType.VarChar).Value = IPADDRESS;
            da.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = Convert.ToString(Session["user_id"]);
            da.Parameters.Add("@SessionID", SqlDbType.VarChar).Value = SessionID;

            da.Parameters.Add("@Valid", SqlDbType.Int, 500);
            da.Parameters["@Valid"].Direction = ParameterDirection.Output;
            da.ExecuteNonQuery();
            valid = (Int32)da.Parameters["@Valid"].Value;
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }

    public DataSet ValidateLoginNewchecking(string UserID, string Password, string Encpassword)//,string Dept
    {
        DataSet ds = new DataSet();
        con.OpenConnection();
        SqlDataAdapter da;
        try
        {

            da = new SqlDataAdapter("[sp_ValidUser_Checking]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (UserID.ToString() == "")
            {
                da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = UserID.ToString();
            }
            if (Password.ToString() == "")
            {
                da.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = Password.ToString();
            }
            if (Encpassword.ToString() == "")
            {
                da.SelectCommand.Parameters.Add("@Encpassword", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@Encpassword", SqlDbType.VarChar).Value = Encpassword.ToString();
            }

            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }
    /*
    protected void lnkbtnLogin_Click(object sender, EventArgs e)
    {
        //if (Session.Count < 0)
        //{
        if (Request.RequestType.ToUpper() != "POST")
        {
            Killsession();
        }

        if (String.IsNullOrEmpty(txtuname.Text) || String.IsNullOrEmpty(txtpsw.Text))
        {
            lblmsg0.Text = "provide User Name and Password";
            Failure.Visible = true;
            FillCapctha(); Killsession();
            txtCaptcha.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
            return;

        }
        else if (ViewState["captchaLogin"].ToString() != txtCaptcha.Text.Trim().TrimStart())
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
            FillCapctha(); Killsession();
            lblmsg0.Text = "Invalid Captcha Code !!.";
            success.Visible = false;
            Failure.Visible = true;
            txtCaptcha.Text = "";
            return;
        }

        else
        {
            if (Session.Count > 0)
            {
                //int a = GETQUERYRAISEDATTACHMENTSNAMES(Session["uid"].ToString(), getclientIP());
                //Session["user_id"] = "";
                //Session["password"].ToString().TrimEnd() = "";
                //Session["username"].ToString().TrimEnd() = "";
                if (Request.QueryString.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["user_id"])))
                    {

                        if (Session["user_id"].ToString().TrimEnd() != txtuname.Text.TrimStart().TrimEnd())
                        {
                            Failure.Visible = true;
                            lblmsg0.Text = "Please logout from all Tabs and then Login";
                            lblmsg0.Visible = true;
                            txtuname.Enabled = false;
                            txtpsw.Enabled = false;
                            return;
                        }
                    }
                }
            }

            success.Visible = false;
            Failure.Visible = false;
            String UserID = "", Password = "", Dept = "";

            UserID = txtuname.Text.TrimStart().TrimEnd();
            Password = txtpsw.Text.TrimStart().TrimEnd();
            ////-----Toget Failed Attempts Count--------/////
            DataSet dsfailed = new DataSet();
            DB.DB con = new DB.DB();
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_GetfailedloginAttempts", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
            da.SelectCommand.Parameters.Add("@SiteName", SqlDbType.VarChar).Value = "TSIPASS";
            da.Fill(dsfailed);
            con.CloseConnection();
            int Failedattempts = dsfailed.Tables[0].Rows.Count;
            if (Failedattempts <= 4)
            {
                Dept = "%";

                General clsGeneral = new General();
                string encpassword = clsGeneral.Encrypt(Password, "SYSTIME");
                DataSet ds = clsGeneral.ValidateLoginNew(UserID, Password, encpassword);//,Dept
                DataView dv = ds.Tables[0].DefaultView;
                DataSet dsnew = new DataSet();

                // dsnew = clsGeneral.UpdateCFOUID();

                if (dv.Table.Rows.Count > 0)
                {
                    if (Failedattempts > 0)
                    {
                        SqlParameter[] p = new SqlParameter[]
                       {
                            new SqlParameter("@userid", SqlDbType.VarChar),
                       };
                        p[0].Value = txtuname.Text;
                        clsGeneral.GenericExecuteNonQuery("Sp_UpdateFailedAttemptsCount", p);
                    }
                    Session["password_decrypt"] = txtpsw.Text.TrimStart().TrimEnd();
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

                    Session["MROMandalID"] = dv.Table.Rows[0]["MROMandalID"].ToString();//to view ADMG Appli
                    UPDATEIPADDRESS(Session["uid"].ToString(), getclientIP());
                    if (Convert.ToString(Session["user_id"]) == "cmshelpdesk")
                    {
                        Response.Redirect("UI/TSiPASS/CFEListtoverify.aspx");
                    }
                    string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                    //if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                    //{
                    //    Response.Redirect("UI/TSiPASS/IpassFeedBackForm.aspx");
                    //}
                    if (Session["userlevel"].ToString().Trim() == "14" || Session["Type"].ToString().Trim() == "Banker")
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                    {
                        if (Defaultpasswordflag.Trim() == "Y")
                        {
                            Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                        }
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["uid"].ToString() == "324136")
                    {
                        Response.Redirect("UI/TSiPASS/frmIncentiveReportAudit.aspx");
                    }
                    else if (Defaultpasswordflag.Trim() == "Y")
                    {
                        if (Session["userlevel"].ToString().Trim() == "13")
                        {

                            if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                            {
                                // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                                //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                                Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                            }
                            else
                            {

                                Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                            }
                        }
                        else
                        {

                            Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                        }

                    }
                    if (Session["userlevel"].ToString().Trim() == "13")
                    {
                        if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                        {
                            // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                            //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                            Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                        }
                        //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                        if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" || Session["uid"].ToString() == "96099")
                        {
                            Response.Redirect("UI/TSiPASS/HomeDeptDashobard_Excise.aspx");
                        }
                        else
                        {
                            Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                        }
                    }


                    else if (Session["userlevel"].ToString().Trim() == "25")
                    {
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "12")
                    {
                        Response.Redirect("UI/TSiPASS/frmApprovelDocument.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "10")
                    {

                        if (Session["uid"].ToString().Trim() == "1030")
                        {

                            Response.Redirect("UI/TSiPASS/HomeIndusDashboard.aspx");
                        }
                        else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                        {
                            Response.Redirect("UI/TSiPASS/IFCDashBoard.aspx");
                        }
                        else if (Convert.ToString(Session["uid"]) == "324563" || Convert.ToString(Session["uid"]) == "324565" ||
                                        Convert.ToString(Session["uid"]) == "324566" || Convert.ToString(Session["uid"]) == "324567" ||
                                        Convert.ToString(Session["uid"]) == "324568" || Convert.ToString(Session["uid"]) == "324569" ||
                                        Convert.ToString(Session["uid"]) == "324570")
                        {
                            Response.Redirect("UI/TSiPASS/DashboardINC.aspx");
                        }
                        else
                        {
                            //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                            //{
                            //    Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboard.aspx");
                            //}
                            if (Session["userlevel"].ToString().Trim() == "10")
                            {
                                if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                                {
                                    Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboardNew.aspx");
                                }
                                else if (Session["User_code"].ToString() == "408" || Session["User_code"].ToString() == "410")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeDeptDashboardOther.aspx");
                                }

                                else
                                {
                                    //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                    Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                                }
                            }

                            //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                            //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                        }

                        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                        //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                    }
                    else
                    {
                        if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3378" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri")
                        {
                            Response.Redirect("UI/TSiPASS/HomeCommDashboard.aspx");
                        }
                        else if (Session["uid"].ToString() == "3377")
                        {
                            Response.Redirect("UI/TSiPASS/HomeJDDashboard.aspx");
                        }
                        else if (Session["uid"].ToString() == "21345")
                        {
                            Response.Redirect("UI/TSiPASS/HomeAddlDashboard.aspx");
                        }
                        else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["Role_Code"].ToString() == "COI-CLERK")
                        {
                            Response.Redirect("UI/TSiPASS/HomeCoiDashboard.aspx");
                        }
                        else if (Session["uid"].ToString().Trim() == "1622")
                        {
                            Response.Redirect("UI/TSiPASS/Home.aspx");
                        }
                        else if (Session["userlevel"].ToString().Trim() == "35")
                        {
                            Response.Redirect("UI/TSiPASS/Home.aspx");
                        }
                        else if (Session["userlevel"].ToString().Trim() == "11")
                        {
                            Response.Redirect("UI/TSiPASS/frmBankLoanSanctionList.aspx");
                        }
                        else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
                        {
                            Response.Redirect("UI/TSiPASS/COIDashboard.aspx");
                        }
                        else
                        {
                            if (Session["Role_Code"].ToString() == "GWCOMM")
                            {
                                if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
                                {
                                    //  Response.Redirect("UI/TSiPASS/RPT_GWStatereport.aspx");
                                    Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                                }
                            }
                            //else
                            //{
                            //    Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                            //}
                            else if (Session["Role_Code"].ToString() == "MSMEDirector")
                            {
                                Response.Redirect("UI/TSiPASS/MSMEDistrictPDLSReport.aspx");
                            }
                            else
                            {
                                Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                            }
                            //Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                        }

                    }

                }
                else
                {
                    DataSet dsuser = new DataSet();

                    con.OpenConnection();
                    SqlDataAdapter dauser = new SqlDataAdapter("sp_checkusername", con.GetConnection);
                    dauser.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dauser.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
                    dauser.Fill(dsuser);
                    con.CloseConnection();
                    if (dsuser.Tables[0].Rows.Count > 0)
                    {
                        int balattempts = 4 - Failedattempts;

                        InsertFailedloginAttempts(); Killsession();
                        lblmsg0.Text = "Invalid UserName or Password \r\n" + balattempts + " Attempts remaining for today";
                        Failure.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    }
                    else
                    {
                        lblmsg0.Text = "Username does not exists";
                        Killsession();
                        Failure.Visible = true;
                    }
                }
            }
            else
            {
                InsertFailedloginAttempts(); Killsession();
                lblmsg0.Text = "Your Account has been locked for today because of 5 failed attempts. Contact Adminstrator ";
                Failure.Visible = true;
            }
        }
        //}
        //else
        //{
        //    Failure.Visible = true;
        //    lblmsg0.Text = "Please logout from all Tabs and then Login";
        //    lblmsg0.Visible = true;
        //    txtuname.Enabled = false;
        //    txtpsw.Enabled = false;
        //}
    }
    */
    protected void lnkbtnLogin_Click(object sender, EventArgs e)
    {
        //SessionIDManager.CreateSessionID;
        if (Request.RequestType.ToUpper() != "POST")
        {
            Killsession();
        }

        if (String.IsNullOrEmpty(txtuname.Text) || String.IsNullOrEmpty(txtpsw.Text))
        {
            lblmsg0.Text = "provide User Name and Password";
            Failure.Visible = true;
            FillCapctha(); Killsession();
            txtCaptcha.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
            return;

        }
        else if (ViewState["captchaLogin"].ToString() != txtCaptcha.Text.Trim().TrimStart() && Request.QueryString.Count == 0)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid Captcha Code !!.');", true);
            FillCapctha(); Killsession();
            lblmsg0.Text = "Invalid Captcha Code !!.";
            success.Visible = false;
            Failure.Visible = true;
            txtCaptcha.Text = "";
            return;
        }

        else
        {
            //lnkbtnLogin.Enabled = false;

            if (Session.Count > 0)
            {
                //int a = GETQUERYRAISEDATTACHMENTSNAMES(Session["uid"].ToString(), getclientIP());
                //Session["user_id"] = "";
                //Session["password"].ToString().TrimEnd() = "";
                //Session["username"].ToString().TrimEnd() = "";
                if (Request.QueryString.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["user_id"])))
                    {

                        if (Session["user_id"].ToString().TrimEnd() != txtuname.Text.TrimStart().TrimEnd())
                        {
                            Failure.Visible = true;
                            lblmsg0.Text = "Please logout from all Tabs and then Login";
                            lblmsg0.Visible = true;
                            txtuname.Enabled = false;
                            txtpsw.Enabled = false;
                            return;
                        }
                    }
                }
            }

            success.Visible = false;
            Failure.Visible = false;
            String UserID = "", Password = "", Dept = "";

            UserID = txtuname.Text.TrimStart().TrimEnd();
            Password = txtpsw.Text.TrimStart().TrimEnd();
            ////-----Toget Failed Attempts Count--------/////
            DataSet dsfailed = new DataSet();
            DB.DB con = new DB.DB();
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_GetfailedloginAttempts", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
            da.SelectCommand.Parameters.Add("@SiteName", SqlDbType.VarChar).Value = "TSIPASS";
            da.Fill(dsfailed);
            con.CloseConnection();
            int Failedattempts = dsfailed.Tables[0].Rows.Count;
            if (Failedattempts <= 4)
            {
                Dept = "%";

                General clsGeneral = new General();
                DataSet dsvalid = new DataSet();
                dsvalid = ValidateLoginNewchecking(UserID, "", "");//,Dept
                string dycriptpassword = "";
                if (dsvalid.Tables[0].Rows.Count > 0)
                {
                    string Encflag = dsvalid.Tables[0].Rows[0]["PwdEncryflag"].ToString();
                    if (Encflag.Trim() == "Y")
                    {
                        string Dbpass = dsvalid.Tables[0].Rows[0]["password"].ToString();
                        dycriptpassword = clsGeneral.Decrypt(Dbpass, "SYSTIME");
                    }
                    else
                    {
                        dycriptpassword = dsvalid.Tables[0].Rows[0]["password"].ToString();
                    }


                    string actPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(dycriptpassword.ToLower() + HdnSession.Value, "MD5");

                    //LogErrorFile.LogData(Convert.ToString(" actPwd value is " + actPwd));
                    //LogErrorFile.LogData(Convert.ToString(" Password value is " + Password));
                    if ((actPwd.ToUpper() == Password.ToUpper()) && (string.Equals(UserID, dsvalid.Tables[0].Rows[0]["User_id"].ToString(), StringComparison.OrdinalIgnoreCase)))
                    {

                        string encpassword = clsGeneral.Encrypt(dycriptpassword, "SYSTIME");
                        //DataSet ds = clsGeneral.ValidateLoginNew(UserID, Password, encpassword);//,Dept
                        DataSet ds = clsGeneral.ValidateLoginNew(UserID, dycriptpassword, encpassword);//,Dept
                        DataView dv = ds.Tables[0].DefaultView;
                        DataSet dsnew = new DataSet();

                        // dsnew = clsGeneral.UpdateCFOUID();

                        if (dv.Table.Rows.Count > 0)
                        {
                            string temp = Session.SessionID;
                            if (Failedattempts > 0)
                            {
                                SqlParameter[] p = new SqlParameter[]
                               {
                            new SqlParameter("@userid", SqlDbType.VarChar),
                               };
                                p[0].Value = txtuname.Text;
                                clsGeneral.GenericExecuteNonQuery("Sp_UpdateFailedAttemptsCount", p);
                            }
                            Session["password_decrypt"] = txtpsw.Text.TrimStart().TrimEnd();
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

                            Session["MROMandalID"] = dv.Table.Rows[0]["MROMandalID"].ToString();//to view ADMG Appli
                            UPDATEIPADDRESS(Session["uid"].ToString(), getclientIP());
                            if (Convert.ToString(Session["user_id"]) == "cmshelpdesk")
                            {
                                Response.Redirect("UI/TSiPASS/CFEListtoverify.aspx");
                            }
                            string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                            //if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                            //{
                            //    Response.Redirect("UI/TSiPASS/IpassFeedBackForm.aspx");
                            //}
                            if (Session["userlevel"].ToString().Trim() == "14" || Session["Type"].ToString().Trim() == "Banker")
                            {
                                Response.Redirect("~/Index.aspx");
                            }
                            if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                            {
                                if (Defaultpasswordflag.Trim() == "Y")
                                {
                                    Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                                }
                                Response.Redirect("UI/TSiPASS/Home.aspx");
                            }
                            else if (Session["uid"].ToString() == "324136")
                            {
                                Response.Redirect("UI/TSiPASS/HomeAuditDashboard.aspx");
                            }
                            else if (Defaultpasswordflag.Trim() == "Y")
                            {
                                if (Session["userlevel"].ToString().Trim() == "13")
                                {

                                    if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                                    {
                                        // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                                        //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                                        Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                                    }
                                    else
                                    {

                                        Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                                    }
                                }
                                else
                                {

                                    Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                                }

                            }
                            if (Session["userlevel"].ToString().Trim() == "13")
                            {
                                if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                                {
                                    // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                                    //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                                    Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                                }
                                //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                                if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" || Session["uid"].ToString() == "96099")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeDeptDashobard_Excise.aspx");
                                }
                                else
                                {
                                    Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                                }
                            }


                            else if (Session["userlevel"].ToString().Trim() == "25")
                            {
                                Response.Redirect("UI/TSiPASS/Home.aspx");
                            }
                            else if (Session["userlevel"].ToString().Trim() == "12")
                            {
                                Response.Redirect("UI/TSiPASS/frmApprovelDocument.aspx");
                            }
                            else if (Session["userlevel"].ToString().Trim() == "10")
                            {

                                if (Session["uid"].ToString().Trim() == "1030")
                                {

                                    Response.Redirect("UI/TSiPASS/HomeIndusDashboard.aspx");
                                }
                                else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                                {
                                    Response.Redirect("UI/TSiPASS/IFCDashBoard.aspx");
                                }
                                else if (Convert.ToString(Session["uid"]) == "324563" || Convert.ToString(Session["uid"]) == "324565" ||
                                                Convert.ToString(Session["uid"]) == "324566" || Convert.ToString(Session["uid"]) == "324567" ||
                                                Convert.ToString(Session["uid"]) == "324568" || Convert.ToString(Session["uid"]) == "324569" ||
                                                Convert.ToString(Session["uid"]) == "324570")
                                {
                                    Response.Redirect("UI/TSiPASS/DashboardINC.aspx");
                                }
                                else
                                {
                                    //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                                    //{
                                    //    Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboard.aspx");
                                    //}
                                    if (Session["userlevel"].ToString().Trim() == "10")
                                    {
                                        if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                                        {
                                            Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                                        }
                                        else if (Session["User_code"].ToString() == "408" || Session["User_code"].ToString() == "410")
                                        {
                                            Response.Redirect("UI/TSiPASS/HomeDeptDashboardOther.aspx");
                                        }

                                        else
                                        {
                                            //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                            Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                                        }
                                    }

                                    //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                    //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                                }

                                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                            }
                            else
                            {
                                if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3378" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeCommDashboard.aspx");
                                }
                                else if (Session["uid"].ToString() == "3377" || Convert.ToString(Session["uid"]) == "364490")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeJDDashboard.aspx");
                                }
                                else if (Session["uid"].ToString() == "21345")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeAddlDashboard.aspx");
                                }
                                else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["Role_Code"].ToString() == "COI-CLERK")
                                {
                                    Response.Redirect("UI/TSiPASS/HomeCoiDashboard.aspx");
                                }
                                else if (Session["uid"].ToString().Trim() == "1622")
                                {
                                    Response.Redirect("UI/TSiPASS/Home.aspx");
                                }
                                else if (Session["userlevel"].ToString().Trim() == "35")
                                {
                                    Response.Redirect("UI/TSiPASS/Home.aspx");
                                }
                                else if (Session["userlevel"].ToString().Trim() == "11")
                                {
                                    Response.Redirect("UI/TSiPASS/frmBankLoanSanctionList.aspx");
                                }
                                else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
                                {
                                    Response.Redirect("UI/TSiPASS/COIDashboard.aspx");
                                }
                                else if (Session["uid"].ToString().Trim() == "365452" || Session["user_id"].ToString().Trim().ToLower() == "Splcs-inds")
                                {
                                    Response.Redirect("UI/TSiPASS/SPLCSDASHBOARD.aspx");
                                }
                                else
                                {
                                    if (Session["Role_Code"].ToString() == "GWCOMM")
                                    {
                                        if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
                                        {
                                            //  Response.Redirect("UI/TSiPASS/RPT_GWStatereport.aspx");
                                            Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                                        }
                                    }
                                    //else
                                    //{
                                    //    Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                                    //}
                                    else if (Session["Role_Code"].ToString() == "MSMEDirector")
                                    {
                                        Response.Redirect("UI/TSiPASS/MSMEDistrictPDLSReport.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                                    }
                                    //Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                                }

                            }

                        }
                    }

                    //else if (string.Equals(userid,dsvalid.Tables[0].Rows[0]["user_id"].ToString(),StringComparison.OrdinalIgnoreCase)  && Request.QueryString.Count > 0)
                    //{
                    //    lblMsg0.Text = "valid UserName or Password.";
                    //}
                    else
                    {
                        DataSet dsuser = new DataSet();

                        con.OpenConnection();
                        SqlDataAdapter dauser = new SqlDataAdapter("sp_checkusername", con.GetConnection);
                        dauser.SelectCommand.CommandType = CommandType.StoredProcedure;
                        dauser.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
                        dauser.Fill(dsuser);
                        con.CloseConnection();
                        if (dsuser.Tables[0].Rows.Count > 0)
                        {
                            int balattempts = 4 - Failedattempts;

                            InsertFailedloginAttempts(); Killsession();
                            lblmsg0.Text = "Invalid UserName or Password \r\n" + balattempts + " Attempts remaining for today";
                            Failure.Visible = true;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                        }
                        else
                        {
                            lblmsg0.Text = "Username does not exists";
                            Killsession();
                            Failure.Visible = true;
                        }
                    }
                }


            }
            else
            {
                InsertFailedloginAttempts(); Killsession();
                lblmsg0.Text = "Your Account has been locked for today because of 5 failed attempts. Contact Adminstrator ";
                Failure.Visible = true;
            }
        }
        //}
        //else
        //{
        //    Failure.Visible = true;
        //    lblmsg0.Text = "Please logout from all Tabs and then Login";
        //    lblmsg0.Visible = true;
        //    txtuname.Enabled = false;
        //    txtpsw.Enabled = false;
        //}
        //HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {

        txtCaptcha.Text = "";
        FillCapctha();
        txtCaptcha.Focus();
    }
    void FillCapctha()
    {
        try
        {
            ViewState["captchaLogin"] = "";

            Random random = new Random();
            string combination = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();

            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            ViewState["captchaLogin"] = captcha.ToString();
            imgCaptcha.ImageUrl = "UI/TSiPASS/CaptchaHandler.ashx?query=" + captcha.ToString();
        }
        catch
        {
            throw;
        }
    }
    public void Killsession()
    {
        //if (HttpContext.Current.Cache[ApplicationSession.FRMPortalUser.UserName] != null)
        //{
        //    HttpContext.Current.Cache.Remove(ApplicationSession.FRMPortalUser.UserName);
        //}
        if (Request.Cookies["ASP.NET_SessionId"] != null)
        {

            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;

            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

        }
        if (Request.Cookies["ASP.NET_SessionIdTemp"] != null)
        {
            Response.Cookies["ASP.NET_SessionIdTemp"].Value = string.Empty;

            Response.Cookies["ASP.NET_SessionIdTemp"].Expires = DateTime.Now.AddMonths(-20);
        }

        if (Request.Cookies["AuthToken"] != null)
        {

            Response.Cookies["AuthToken"].Value = string.Empty;

            Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

        }
        if (Request.Cookies["__AntiXsrfToken"] != null)
        {

            Response.Cookies["__AntiXsrfToken"].Value = string.Empty;

            Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);

        }
        Session.Abandon();
        Session.Clear();

        var manager = new System.Web.SessionState.SessionIDManager();
        string newSessionId = manager.CreateSessionID(HttpContext.Current);
        bool isRedirected = false;
        bool isAdded = false;
        manager.SaveSessionID(HttpContext.Current, newSessionId, out isRedirected, out isAdded);

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now);
        Response.Cache.SetNoStore();
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
        //Response.Redirect(ConfigurationManager.AppSettings["VirtualPath"] + "//Default.aspx?ID=Y");
        //Response.Redirect("~/login.aspx");
    }
    protected void AbandonSession()
    {
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        if (Request.Cookies["ASP.NET_SessionId"] != null)
        {
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
        }
        if (Request.Cookies["__AntiXsrfToken"] != null)
        {
            Response.Cookies["__AntiXsrfToken"].Value = string.Empty;
            Response.Cookies["__AntiXsrfToken"].Expires = DateTime.Now.AddMonths(-20);
        }

    }

    public void InsertFailedloginAttempts()
    {
        SqlParameter[] p = new SqlParameter[]
                       {
                    new SqlParameter("@username", SqlDbType.VarChar),
                    new SqlParameter("@Hashedpswd", SqlDbType.VarChar),
                    new SqlParameter("@IPAddress", SqlDbType.VarChar),
                     new SqlParameter("@SiteName", SqlDbType.VarChar),
                    new SqlParameter("@result", SqlDbType.Int)
                       };
        p[0].Value = txtuname.Text;
        p[1].Value = txtpsw.Text;
        p[2].Value = getclientIP();
        p[3].Value = "TSIPASS";
        p[4].Value = 0;
        p[4].Direction = ParameterDirection.Output;
        int i = clsGeneral.GenericExecuteNonQuery("Sp_InsertLoginFailedDetails", p);
    }

    public void TTAPLogin(string UserID, string Password)
    {
        try
        {
            LogErrorFile.LogData(Convert.ToString(UserID + " DB CALLING PSWD as: " + Password));
            General clsGeneral = new General();
            //string Password = clsGeneral.Decrypt(EncrptedPassword, "SYSTIME");
            //DataSet ds = clsGeneral.ValidateLoginNew(UserID, Password, EncrptedPassword);//,Dept
            //DataView dv = ds.Tables[0].DefaultView;
            //DataSet dsnew = new DataSet();

            string encpassword = Password;
            string decryptpswd = clsGeneral.Decrypt(Password, "SYSTIME");

            DataSet ds = clsGeneral.ValidateLoginNew(UserID, decryptpswd, encpassword);//,Dept
            DataView dv = ds.Tables[0].DefaultView;
            DataSet dsnew = new DataSet();
            LogErrorFile.LogData(Convert.ToString(UserID + " DecryptPassword as: " + decryptpswd));
            // dsnew = clsGeneral.UpdateCFOUID();

            if (dv.Table.Rows.Count > 0)
            {
                // LogErrorFile.LogData(Convert.ToString(UserID + " DB ROWS FETCHED as: " + decryptpswd));
                Session["password_decrypt"] = txtpsw.Text.TrimStart().TrimEnd();
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

                Session["MROMandalID"] = dv.Table.Rows[0]["MROMandalID"].ToString();//to view ADMG Appli
                UPDATEIPADDRESS(Session["uid"].ToString(), getclientIP());
                string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                //if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                //{
                //    Response.Redirect("UI/TSiPASS/IpassFeedBackForm.aspx");
                //}
                if (Session["userlevel"].ToString().Trim() == "14" || Session["Type"].ToString().Trim() == "Banker")
                {
                    Response.Redirect("~/Index.aspx");
                }
                if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                {
                    if (Defaultpasswordflag.Trim() == "Y")
                    {
                        Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                    }
                    Response.Redirect("UI/TSiPASS/Home.aspx");
                }
                else if (Defaultpasswordflag.Trim() == "Y")
                {
                    if (Session["userlevel"].ToString().Trim() == "13")
                    {

                        if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                        {
                            // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                            //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                            Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                        }
                        else
                        {

                            Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                        }
                    }
                    else
                    {

                        Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                    }

                }
                if (Session["userlevel"].ToString().Trim() == "13")
                {
                    if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                    {
                        // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                        //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                        Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                    }
                    //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                    if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" || Session["uid"].ToString() == "96099")
                    {
                        Response.Redirect("UI/TSiPASS/HomeDeptDashobard_Excise.aspx");
                    }
                    else
                    {
                        Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                    }
                }


                else if (Session["userlevel"].ToString().Trim() == "25")
                {
                    Response.Redirect("UI/TSiPASS/Home.aspx");
                }
                else if (Session["userlevel"].ToString().Trim() == "12")
                {
                    Response.Redirect("UI/TSiPASS/frmApprovelDocument.aspx");
                }
                else if (Session["userlevel"].ToString().Trim() == "10")
                {

                    if (Session["uid"].ToString().Trim() == "1030")
                    {

                        Response.Redirect("UI/TSiPASS/HomeIndusDashboard.aspx");
                    }
                    else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                    {
                        Response.Redirect("UI/TSiPASS/IFCDashBoard.aspx");
                    }
                    else
                    {
                        //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                        //{
                        //    Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboard.aspx");
                        //}
                        if (Session["userlevel"].ToString().Trim() == "10")
                        {
                            if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                            {
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                            }
                            else if (Session["User_code"].ToString() == "408" || Session["User_code"].ToString() == "410")
                            {
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboardOther.aspx");
                            }

                            else
                            {
                                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                            }
                        }

                        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                        //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                    }

                    //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                    //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                }
                else
                {
                    if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3378" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCommDashboard.aspx");
                    }
                    else if (Session["uid"].ToString() == "3377" || Convert.ToString(Session["uid"]) == "364490")
                    {
                        Response.Redirect("UI/TSiPASS/HomeJDDashboard.aspx");
                    }
                    else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["Role_Code"].ToString() == "COI-CLERK")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCoiDashboard.aspx");
                    }
                    else if (Session["uid"].ToString().Trim() == "1622")
                    {
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "35")
                    {
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "11")
                    {
                        Response.Redirect("UI/TSiPASS/frmBankLoanSanctionList.aspx");
                    }
                    else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCommDashboardNew.aspx");
                    }
                    else
                    {
                        if (Session["Role_Code"].ToString() == "GWCOMM")
                        {
                            if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
                            {
                                //  Response.Redirect("UI/TSiPASS/RPT_GWStatereport.aspx");
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                            }
                        }
                        //else
                        //{
                        //    Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                        //}
                        else if (Session["Role_Code"].ToString() == "MSMEDirector")
                        {
                            Response.Redirect("UI/TSiPASS/MSMEDistrictPDLSReport.aspx");
                        }
                        else
                        {
                            Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                        }
                        //Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                    }

                }

            }
            else
            {
                DataSet dsuser = new DataSet();

                con.OpenConnection();
                SqlDataAdapter dauser = new SqlDataAdapter("sp_checkusername", con.GetConnection);
                dauser.SelectCommand.CommandType = CommandType.StoredProcedure;
                dauser.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
                dauser.Fill(dsuser);
                con.CloseConnection();

            }
        }
        catch (Exception e)
        {

        }
    }
    public void TTAPLogin(string UserID, string Password, string PwdEncryflag)
    {
        try
        {
            General clsGeneral = new General();
            LogErrorFile.LogData(Convert.ToString(UserID + " DB CALLING PSWD as: " + Password));
            //string Password = clsGeneral.Decrypt(EncrptedPassword, "SYSTIME");
            //DataSet ds = clsGeneral.ValidateLoginNew(UserID, Password, EncrptedPassword);//,Dept
            //DataView dv = ds.Tables[0].DefaultView;
            //DataSet dsnew = new DataSet();

            string encpassword = "", decryptpswd = "";
            if (PwdEncryflag == "Y")
            {
                LogErrorFile.LogData(Convert.ToString(UserID + " pwd encr: " + PwdEncryflag));
                encpassword = Password;
                decryptpswd = clsGeneral.Decrypt(Password, "SYSTIME");
            }
            else
            {
                LogErrorFile.LogData(Convert.ToString(UserID + " pwd encr: " + PwdEncryflag));
                decryptpswd = Password;
                encpassword = clsGeneral.Encrypt(Password, "SYSTIME");
            }
            LogErrorFile.LogData(Convert.ToString(UserID + " DecryptPassword as: " + decryptpswd + " encryptPassword as: " + encpassword));
            DataSet ds = clsGeneral.ValidateLoginNew(UserID, decryptpswd, encpassword);//,Dept
            DataView dv = ds.Tables[0].DefaultView;
            DataSet dsnew = new DataSet();

            // dsnew = clsGeneral.UpdateCFOUID();

            if (dv.Table.Rows.Count > 0)
            {
                LogErrorFile.LogData(Convert.ToString(UserID + " DB ROWS FETCHED as: " + decryptpswd));
                Session["password_decrypt"] = txtpsw.Text.TrimStart().TrimEnd();
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

                Session["MROMandalID"] = dv.Table.Rows[0]["MROMandalID"].ToString();//to view ADMG Appli
                LogErrorFile.LogData(Convert.ToString(" SESSION ID as: " + Session["uid"].ToString()));
                UPDATEIPADDRESS(Session["uid"].ToString(), getclientIP());

                string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                //if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                //{
                //    Response.Redirect("UI/TSiPASS/IpassFeedBackForm.aspx");
                //}
                if (Session["userlevel"].ToString().Trim() == "14" || Session["Type"].ToString().Trim() == "Banker")
                {
                    Response.Redirect("~/Index.aspx");
                }
                if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                {
                    if (Defaultpasswordflag.Trim() == "Y")
                    {
                        Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                    }
                    Response.Redirect("UI/TSiPASS/Home.aspx");
                }
                else if (Defaultpasswordflag.Trim() == "Y")
                {
                    if (Session["userlevel"].ToString().Trim() == "13")
                    {

                        if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                        {
                            // Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                            //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                            Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                        }
                        else
                        {

                            Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                        }
                    }
                    else
                    {

                        Response.Redirect("UI/TSiPASS/frmChangePassword.aspx");
                    }

                }
                if (Session["userlevel"].ToString().Trim() == "13")
                {
                    if (Convert.ToString(Session["RedirectfromNSWSURL"]) == "Y")
                    {

                        //Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                        //  Response.Redirect("UI/TSiPASS/Category.aspx?Mode=CFE");
                        Response.Redirect("UI/TSiPASS/frmQuesstionniareReg.aspx?HOTEL=N");
                    }
                    //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                    if (Session["uid"].ToString() == "17083" || Session["uid"].ToString() == "4518" || Session["uid"].ToString() == "96097" || Session["uid"].ToString() == "96099")
                    {
                        Response.Redirect("UI/TSiPASS/HomeDeptDashobard_Excise.aspx");
                    }
                    else
                    {
                        LogErrorFile.LogData(Convert.ToString(" PAGENAME  as: " + Session["uid"].ToString()));
                        Response.Redirect("UI/TSiPASS/HomeDashboard.aspx");
                    }
                }
                else if (Session["userlevel"].ToString().Trim() == "25")
                {
                    Response.Redirect("UI/TSiPASS/Home.aspx");
                }
                else if (Session["userlevel"].ToString().Trim() == "12")
                {
                    Response.Redirect("UI/TSiPASS/frmApprovelDocument.aspx");
                }
                else if (Session["userlevel"].ToString().Trim() == "10")
                {

                    if (Session["uid"].ToString().Trim() == "1030")
                    {

                        Response.Redirect("UI/TSiPASS/HomeIndusDashboard.aspx");
                    }
                    else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                    {
                        Response.Redirect("UI/TSiPASS/IFCDashBoard.aspx");
                    }
                    else
                    {
                        //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                        //{
                        //    Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboard.aspx");
                        //}
                        if (Session["userlevel"].ToString().Trim() == "10")
                        {
                            if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                            {
                                Response.Redirect("UI/TSiPASS/frmIPOIncentiveDashboardNew.aspx");
                            }
                            else if (Session["User_code"].ToString() == "408" || Session["User_code"].ToString() == "410")
                            {
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboardOther.aspx");
                            }

                            else
                            {
                                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                            }
                        }

                        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                        //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                    }

                    //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                    //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                }
                else
                {
                    if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3378" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCommDashboard.aspx");
                    }
                    else if (Session["uid"].ToString() == "3377" || Convert.ToString(Session["uid"]) == "364490")
                    {
                        Response.Redirect("UI/TSiPASS/HomeJDDashboard.aspx");
                    }
                    else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["Role_Code"].ToString() == "COI-CLERK")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCoiDashboard.aspx");
                    }
                    else if (Session["uid"].ToString().Trim() == "1622")
                    {
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "35")
                    {
                        Response.Redirect("UI/TSiPASS/Home.aspx");
                    }
                    else if (Session["userlevel"].ToString().Trim() == "11")
                    {
                        Response.Redirect("UI/TSiPASS/frmBankLoanSanctionList.aspx");
                    }
                    else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
                    {
                        Response.Redirect("UI/TSiPASS/HomeCommDashboardNew.aspx");
                    }
                    else
                    {
                        if (Session["Role_Code"].ToString() == "GWCOMM")
                        {
                            if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
                            {
                                //  Response.Redirect("UI/TSiPASS/RPT_GWStatereport.aspx");
                                Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");
                            }
                        }
                        //else
                        //{
                        //    Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                        //}
                        else if (Session["Role_Code"].ToString() == "MSMEDirector")
                        {
                            Response.Redirect("UI/TSiPASS/MSMEDistrictPDLSReport.aspx");
                        }
                        else
                        {
                            Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                        }
                        //Response.Redirect("UI/TSiPASS/ReportsDashboardNew.aspx");
                    }

                }

            }
            else
            {
                DataSet dsuser = new DataSet();

                con.OpenConnection();
                SqlDataAdapter dauser = new SqlDataAdapter("sp_checkusername", con.GetConnection);
                dauser.SelectCommand.CommandType = CommandType.StoredProcedure;
                dauser.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = txtuname.Text.TrimStart().TrimEnd();
                dauser.Fill(dsuser);
                con.CloseConnection();

            }
        }
        catch (Exception e)
        {

        }
    }
    public DataSet DB_Getredirectuserurlbytsipassid(string username, string investorSwsId, string TSIPASSID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("NSWS_getdirectiondetailsNSWSbyswsidusernamtsipassid_PASSWORD", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            da.SelectCommand.Parameters.Add("@investorSwsId", SqlDbType.VarChar).Value = investorSwsId;
            da.SelectCommand.Parameters.Add("@TSIPASSID", SqlDbType.VarChar).Value = TSIPASSID;


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }


    }
}