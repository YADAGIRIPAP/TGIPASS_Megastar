using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_frmBridgeLoanRegForm : System.Web.UI.Page
{
    #region OTP Chars  //variables for OTP -> Nikhil.
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    char[] charArr = "0123456789".ToCharArray();
    string strOTPMobile = string.Empty;
    string strOTPMail = string.Empty;
    string finalOTPMail = "";
    string finalOTPMobile = "";
    Random oRandom = new Random();
    int noOfChar = 6;

    #endregion
    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";
    comFunctions cmf = new comFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ViewState["captcha"] = "";
                //FillCapctha();

                txtUserName.Attributes.Add("onKeyPress", "javascript:return AlphanumericOnlyJs(event);");
                txtMobileNo.Attributes.Add("onKeyPress", "javascript:return inputOnlyNumbers(event);");
                BtnSave1.Enabled = false;
                BindBrdgeBankDetails();
                BindDistricts();
            }
        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string UserName = txtifscCode.Text.Trim();
        try
        {
            success.Visible = false;
            lblmsg.Text = "";

            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckBankersUserid(UserName);
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtUserName.Text = "";
                lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = false;
                Failure.Visible = true;

                return;
            }
            if (OtherBranch.Visible = true)
            {
                if (txtotherbranch.Text == "")
                {
                    lblmsg0.Text = "<font color=red> Please Enter Branch Name </font>";

                    success.Visible = false;
                    Failure.Visible = true;
                }

            }
            BankersRegistrationVo userregistrationvoobj = new BankersRegistrationVo();
            try
            {
                // OTPGenerationMail();
            }
            catch (Exception ex)
            {

            }

            string password = "";
            //password = Gen.Encrypt("TSIPASS123", "SYSTIME");
            password = Gen.Encrypt(txtcomparepwd.Text, "SYSTIME");
            userregistrationvoobj.BankName = ddlbankName.SelectedValue.ToString();
            if (ddldistrict.SelectedValue == "34")
            {
                userregistrationvoobj.District = ddlOtherDistrict.SelectedValue.ToString();
            }
            else
            {
                userregistrationvoobj.District = ddldistrict.SelectedValue.ToString();
            }

            userregistrationvoobj.BranchName = ddlbranchname.SelectedValue.ToString();
            userregistrationvoobj.IFSCCode = txtifscCode.Text.ToString();

            userregistrationvoobj.MobileNo = txtMobileNo.Text.Trim();
            userregistrationvoobj.username = UserName;
            userregistrationvoobj.Password = password;
            userregistrationvoobj.OTPMail = txtemail.Text.Trim();
            userregistrationvoobj.OTPMsg = "";
            userregistrationvoobj.Pwdflag = "Y";

            userregistrationvoobj.BranchNametext = txtotherbranch.Text;
            int i = Gen.Bankersregistration(userregistrationvoobj);

            if (i != 999)
            {
                string message = "alert('Your Registration is Complete & IFSC Code is Your UserId')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                lblmsg.Text = "<font color=green> Your Registration is Complete & IFSC Code is Your UserId </font>";

                success.Visible = true;
                Failure.Visible = false;

                string msgs = "Dear " + txtUserName.Text + " " + "\r\n" + "you are successfully registered." + "\r\n" + "User Id : " + txtUserName.Text + "\r\n" + " Password : " + txtcomparepwd.Text + "\r\n";
                msgs = msgs + "\r\n" + "\r\n" + "Thanks and Regards ," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

                string body = msgs;
                try
                {
                    SendMailAnother(txtemail.Text);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    //cmf.SendSingleSMS(txtcontact.Text, body);
                }
                catch (Exception ex)
                {

                }
                //clear();

                //Response.Redirect("FrmHDResultNew.aspx?Msg=Please click on the Verification link which has been sent to your mail id to complete the registration process.");
                General clsGeneral = new General();
                //string encpassword = clsGeneral.Encrypt("TSIPASS123", "SYSTIME");
                string encpassword = clsGeneral.Encrypt(txtcomparepwd.Text, "SYSTIME");
                DataSet ds = clsGeneral.ValidateLoginNew(userregistrationvoobj.username, txtcomparepwd.Text, encpassword);//,Dept
                DataView dv = ds.Tables[0].DefaultView;
                DataSet dsnew = new DataSet();

                //dsnew = clsGeneral.UpdateCFOUID();

                //if (dv.Table.Rows.Count > 0)
                //{
                //    Session["uid"] = dv.Table.Rows[0]["intUserid"].ToString();
                //    Session["username"] = dv.Table.Rows[0]["User_name"].ToString();
                //    Session["user_id"] = dv.Table.Rows[0]["User_id"].ToString();
                //    Session["password"] = dv.Table.Rows[0]["password"].ToString();
                //    Session["userlevel"] = dv.Table.Rows[0]["User_level"].ToString();
                //    Session["user_type"] = dv.Table.Rows[0]["User_type"].ToString();
                //    Session["Type"] = dv.Table.Rows[0]["Fromname"].ToString();
                //    Session["MobileNumber"] = dv.Table.Rows[0]["MobileNumber"].ToString();
                //    Session["Email"] = dv.Table.Rows[0]["EmailE"].ToString();

                //    Session["DistrictID"] = dv.Table.Rows[0]["DistrictID"].ToString();
                //    Session["User_Code"] = dv.Table.Rows[0]["User_code"].ToString();
                //    Session["Visibleflag"] = dv.Table.Rows[0]["Visibleflag"].ToString();

                //    string Defaultpasswordflag = dv.Table.Rows[0]["DefaultPwd"].ToString();
                //    if (Session["userlevel"].ToString().Trim() == "20" || Session["userlevel"].ToString().Trim() == "24")
                //    {
                //        if (Defaultpasswordflag.Trim() == "Y")
                //        {
                //            Response.Redirect("frmChangePassword.aspx");
                //        }
                //        Response.Redirect("UI/TSiPASS/Home.aspx");
                //    }
                //    else
                //        if (Defaultpasswordflag.Trim() == "Y")
                //    {
                //        Response.Redirect("frmChangePassword.aspx");
                //    }
                //    if (Session["userlevel"].ToString().Trim() == "13")
                //    {
                //        //Response.Redirect("UI/TSiPASS/Dashboard.aspx");
                //        Response.Redirect("UI/TSiPASS/frmBridgeLoanDetails.aspx");
                //    }
                //    else if (Session["userlevel"].ToString().Trim() == "25")
                //    {
                //        Response.Redirect("Home.aspx");
                //    }
                //    else if (Session["userlevel"].ToString().Trim() == "12")
                //    {
                //        Response.Redirect("frmApprovelDocument.aspx");
                //    }
                //    else if (Session["userlevel"].ToString().Trim() == "10")
                //    {

                //        if (Session["uid"].ToString().Trim() == "1030")
                //        {

                //            Response.Redirect("HomeIndusDashboard.aspx");
                //        }
                //        else
                //        {
                //            if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                //            {
                //                Response.Redirect("frmIPOIncentiveDashboard.aspx");
                //            }
                //            else
                //            {
                //                //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                //                Response.Redirect("HomeDeptDashboard.aspx");
                //            }


                //            //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                //            //  Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                //        }

                //        //Response.Redirect("UI/TSiPASS/frmDepartementDashboardNew.aspx");
                //        //Response.Redirect("UI/TSiPASS/HomeDeptDashboard.aspx");

                //    }
                //    else
                //    {
                //        if (Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "3378")
                //        {
                //            Response.Redirect("HomeCommDashboard.aspx");
                //        }
                //        else if (Session["uid"].ToString().Trim() == "1622")
                //        {

                //            Response.Redirect("Home.aspx");

                //        }
                //        else
                //        {
                //            Response.Redirect("ReportsDashboard.aspx");
                //        }
                //    }
                //}

                lblmsg.Text = "Your Registration is Complete & IFSC Code is Your UserId..!";
                success.Visible = true;
                Failure.Visible = false;
                BtnClear.Visible = true;
                BtnSave1.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }


        //    if (i == 1)
        //    {
        //        string message = "alert('Your Registration is Complete & IFSC Code is Your UserId')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        lblmsg.Text = "<font color=green> Your Registration is Complete & IFSC Code is Your UserId </font>";

        //        success.Visible = true;
        //        Failure.Visible = false;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //lblmsg0.Text = "Internal error has occured. Please try after some time";
        //    lblmsg0.Text = ex.Message;
        //    Failure.Visible = true;
        //}



    }

    public void SendMailAnother(string anothermail)
    {

        try
        {
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Enterprenuer -Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Dear " + ddlbankName.SelectedItem.Text.ToString() + " " + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> Banker': " + ddlbankName.SelectedItem.Text.ToString() + " " + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtifscCode.Text + "<br> <br> Password :" + txtcomparepwd.Text + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
            client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");

            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                //Session.Remove("File");
                //Session.Remove("FileName");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            } // end try
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }


    public void UserNameCheck()
    {
        try
        {
            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckBankersUserid(txtUserName.Text.Trim());

            if (dsUser.Tables[0].Rows.Count > 0)
            {
                string UserName = dsUser.Tables[0].Rows[0]["username"].ToString();
                lblmsg0.Text = "<font color=red> Bank Branch With IFSC Code: " + UserName + " Code Already Registered </font>";

                success.Visible = false;
                Failure.Visible = true;

            }
            else
            {
                //lblmsg.Text = "<font color=green> User Id Available </font>";





            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        string UserName = txtifscCode.Text.Trim();
        try
        {
            success.Visible = false;
            lblmsg.Text = "";

            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckBankersUserid(UserName);
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtUserName.Text = "";
                lblmsg0.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = false;
                Failure.Visible = true;

                return;
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void OTPMobile()
    {
        try
        {
            for (int cnt = 0; cnt < noOfChar; cnt++)
            {
                int OTPNo = oRandom.Next(1, charArr.Length);
                if (!strOTPMobile.Contains(charArr.GetValue(OTPNo).ToString()))
                {
                    strOTPMobile += charArr.GetValue(OTPNo);
                }
                else
                {
                    cnt--;
                }
            }
            finalOTPMobile = strOTPMobile;
            //////mobile message purpose
            string msgMobile = "Dear " + txtUserName.Text + " " + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please confirm to register";
            msgMobile = msgMobile + "\r\n" + "\r\n" + "Regards ," + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS Cell.";

            string bodyMobile = msgMobile;
            //SendSingleSMSnew(txtMobileNo.Text, bodyMobile);
            // Button1.Text = "Click Here To Register";
            HDFmsgOTP.Value = strOTPMobile;   //stored otp message value here.
            //Button1.Visible = false;
            //imgid.Visible = true;
            //BtnSave_Click(null, null);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected String encryptedPasswod(String password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        // static string result = System.Text.Encoding.UTF8.GetString(pp);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
    public String SendSingleSMSnew(String mobileNo, String message)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtOTPVerify.Enabled = true;
        txtOTPVerify.Text = "";
        try
        {
            if (txtemail.Text.ToString() != "" && txtMobileNo.Text.ToString() != "")
            {
                string Text = Gen.CheckBankersDetailsExist(txtMobileNo.Text.ToString(), txtemail.Text.ToString());
                if (Text == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email id or Mobile No already exists!!. Pl re- enter a new Email id and Mobile no');", true);
                    txtemail.Text = "";
                    txtMobileNo.Text = "";
                }

                else if (Text == "2")
                {
                    OTPMobile();
                    //An OTP has been sent to your mobile no. Please enter it to verify.
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);

                }

            }
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error!!. Pl try again.');", true);

        }
    }

    protected void txtOTPVerify_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtOTPVerify.Text == HDFmsgOTP.Value.ToString())
            {
                // BtnSave_Click(sender, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed for registration.');", true);
                // BtnSave1.Enabled = true;
                // BtnSave1.Visible = false;
                // Button1.Enabled = false;
                txtOTPVerify.Enabled = false;
                imgid.Visible = true;
                txtUserName.Focus();

                BtnSave1.Visible = true;
                BtnSave1.Enabled = true;
                trpassword.Visible = true;
                trrepassword.Visible = true;

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter valid OTP received on your mobile no !!.');", true);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void txtifscCode_TextChanged(object sender, EventArgs e)
    {

    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public void AddSelectOther(DropDownList ddl)
    {
        try
        {

            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ListItem li1 = new ListItem();
            li1.Text = "Others";
            li1.Value = "34";
            ddl.Items.Insert(0, li1);
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public void AddOnlyOther(DropDownList ddl)
    {
        try
        {

            ListItem li1 = new ListItem();
            li1.Text = "Others";
            li1.Value = "34";
            ddl.Items.Insert(0, li1);

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    public void BindBrdgeBankDetails()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlbankName.Items.Clear();
            dsd = Gen.GetBridgeBankDetails();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlbankName.DataSource = dsd.Tables[0];
                ddlbankName.DataValueField = "BANKID";
                ddlbankName.DataTextField = "BANKNAME";
                ddlbankName.DataBind();
                //ddlbankName.Items.Insert(0, "--SELECT--");
                AddSelect(ddlbankName);
            }
            else
            {
                //ddlUnitDIst.Items.Insert(0, "--SELECT--");
                AddSelect(ddlbankName);
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void ddlbankName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlbankName.SelectedIndex == 0)
        //{
        //    //ddlbankName.Items.Clear();
        //    // ddlUnitMandal.Items.Insert(0, "--Mandal--");
        //    AddSelect(ddldistrict);
        //}
        //else
        //{
        //    ddldistrict.Items.Clear();
        //    DataSet dsm = new DataSet();


        //    dsm = Gen.GetBankIdByDistricts(ddlbankName.SelectedValue);
        //    if (dsm.Tables[0].Rows.Count > 0)
        //    {
        //        ddldistrict.DataSource = dsm.Tables[0];
        //        ddldistrict.DataValueField = "DistrictId";
        //        ddldistrict.DataTextField = "DistrictName";
        //        ddldistrict.DataBind();
        //        // ddlUnitMandal.Items.Insert(0, "--Mandal--");
        //        AddSelectOther(ddldistrict);
        //    }
        //    else
        //    {
        //        ddldistrict.Items.Clear();
        //        //ddlUnitMandal.Items.Insert(0, "--Mandal--");
        //        AddSelect(ddldistrict);
        //    }
        //    if (OtherBranch.Visible == true)
        //    {
        //        OtherBranch.Visible = false;
        //    }
        //}

        if (ddldistrict.SelectedIndex == 0)
        {
            txtifscCode.Text = "";
            ddlbranchname.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlbranchname);
        }
        //else if (ddldistrict.SelectedItem.ToString() == "Others")
        //{
        //    trotherDist.Visible = true;
        //    DataSet dsOther = new DataSet();
        //    dsOther = Gen.GetOtherDistricts(ddlbankName.SelectedValue);
        //    if (dsOther.Tables[0].Rows.Count > 0)
        //    {
        //        ddlOtherDistrict.DataSource = dsOther.Tables[0];
        //        ddlOtherDistrict.DataValueField = "District_Id";
        //        ddlOtherDistrict.DataTextField = "District_Name";
        //        ddlOtherDistrict.DataBind();
        //        AddSelect(ddlOtherDistrict);
        //        //ddlOtherDistrict.Items.Insert(01, "Other");
        //        //AddSelect(ddlbranchname);
        //        //ddlbranchname.Items.Insert(01, "Other");
        //    }
        //    else
        //    {
        //        ddlOtherDistrict.Items.Clear();
        //        // ddlVillageunit.Items.Insert(0, "--Village--");
        //        AddSelect(ddlOtherDistrict);
        //    }
        //}
        //else
        //{
        ddlbranchname.Items.Clear();
        DataSet dsv = new DataSet();
        dsv = Gen.GetBranchesByBankDistrictId(ddldistrict.SelectedValue, ddlbankName.SelectedValue);
        if (dsv.Tables[0].Rows.Count > 0)
        {
            ddlbranchname.DataSource = dsv.Tables[0];
            ddlbranchname.DataValueField = "BranchId";
            ddlbranchname.DataTextField = "BranchName";
            ddlbranchname.DataBind();
            AddSelect(ddlbranchname);
            ddlbranchname.Items.Insert(01, "Other");
        }
        else
        {
            ddlbranchname.Items.Clear();
            AddSelect(ddlbranchname);
            ddlbranchname.Items.Insert(01, "Other");
            // ddlVillageunit.Items.Insert(0, "--Village--");
            //AddSelect(ddlbranchname);
        }
        if (OtherBranch.Visible == true)
        {
            OtherBranch.Visible = false;
        }
        // }
    }

    protected void ddlbranchname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlbranchname.SelectedItem.Text == "Other")
        {
            OtherBranch.Visible = true;
            txtifscCode.Text = "";
        }
        else
        {
            //txtifscCode.Text = ddlbranchname.SelectedValue.ToString();
            //txtifscCode.Enabled = false;
            //OtherBranch.Visible = false;
            txtifscCode.Text = ddlbranchname.SelectedValue.ToString();

            DataSet dsIFSCcode = new DataSet();
            dsIFSCcode = GetIfscCodeByBrachId(ddlbranchname.SelectedValue);
            if (dsIFSCcode != null && dsIFSCcode.Tables.Count > 0 && dsIFSCcode.Tables[0].Rows.Count > 0)
            {
                txtifscCode.Text = dsIFSCcode.Tables[0].Rows[0]["IFSCCODE"].ToString();

            }
            OtherBranch.Visible = false;
        }


    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedIndex == 0)
        {
            txtifscCode.Text = "";
            ddlbranchname.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlbranchname);
        }
        //else if (ddldistrict.SelectedItem.ToString() == "Others")
        //{
        //    trotherDist.Visible = true;
        //    DataSet dsOther = new DataSet();
        //    dsOther = Gen.GetOtherDistricts(ddlbankName.SelectedValue);
        //    if (dsOther.Tables[0].Rows.Count > 0)
        //    {
        //        ddlOtherDistrict.DataSource = dsOther.Tables[0];
        //        ddlOtherDistrict.DataValueField = "District_Id";
        //        ddlOtherDistrict.DataTextField = "District_Name";
        //        ddlOtherDistrict.DataBind();
        //        AddSelect(ddlOtherDistrict);
        //        //ddlOtherDistrict.Items.Insert(01, "Other");
        //        //AddSelect(ddlbranchname);
        //        //ddlbranchname.Items.Insert(01, "Other");
        //    }
        //    else
        //    {
        //        ddlOtherDistrict.Items.Clear();
        //        // ddlVillageunit.Items.Insert(0, "--Village--");
        //        AddSelect(ddlOtherDistrict);
        //    }
        //}
        //else
        //{
        ddlbranchname.Items.Clear();
        DataSet dsv = new DataSet();
        dsv = Gen.GetBranchesByBankDistrictId(ddldistrict.SelectedValue, ddlbankName.SelectedValue);
        if (dsv.Tables[0].Rows.Count > 0)
        {
            ddlbranchname.DataSource = dsv.Tables[0];
            ddlbranchname.DataValueField = "BranchId";
            ddlbranchname.DataTextField = "BranchName";
            ddlbranchname.DataBind();
            AddSelect(ddlbranchname);
            //ddlbranchname.Items.Insert(01, "Other");
        }
        else
        {
            ddlbranchname.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            //AddSelect(ddlbranchname);
        }
        if (OtherBranch.Visible == true)
        {
            OtherBranch.Visible = false;
        }
        // }
    }



    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBridgeLoanRegForm.aspx");
    }

    public DataSet GetIfscCodeByBrachId(string BranchId)
    {
        SqlDataAdapter da;
        osqlConnection.Open();
        //SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetIfscCodeByBranchId", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (BranchId.Trim() == "" || BranchId.Trim() == null)
                da.SelectCommand.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@BranchId", SqlDbType.VarChar).Value = BranchId.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    public void AddSelectWithClear(DropDownList ddl)
    {
        try
        {
            ddl.Items.Clear();
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ListItem li1 = new ListItem();
            li1.Text = "Others";
            li1.Value = "34";
            ddl.Items.Insert(0, li1);
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void ddlOtherDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddSelectWithClear(ddlbranchname);
        //ddlbranchname.Items.Clear();
        //AddOnlyOther(ddlbranchname);
        //AddSelectOther(ddlbranchname);
    }
}