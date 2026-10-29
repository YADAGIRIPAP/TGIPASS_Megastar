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
using System.Drawing;

public partial class UI_TSiPASS_frmcentralinspectionreport : System.Web.UI.Page
{
    #region OTP Chars  //variables for OTP -> Nikhil.

    char[] charArr = "0123456789".ToCharArray();
    string strOTPMobile = string.Empty;
    string strOTPMail = string.Empty;
    string finalOTPMail = "";
    string finalOTPMobile = "";
    Random oRandom = new Random();
    int noOfChar = 6;
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    #endregion
    int inspectionid ;
    string mobileno = "";
    string emailid = "";
    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)

    {
        txtOTPVerify.Enabled = false;
        GridView1.HeaderStyle.BackColor = Color.Yellow;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Text;

        try
        {
            if (txtemail.Text.ToString() != "" && txtcontact.Text.ToString() != "")
            {
                Text = Gen.checkMobileFORINSPECTION(txtcontact.Text.ToString(), txtemail.Text.ToString());
               
                if(Text!="0")
                {
                    txtOTPVerify.Enabled = true;

                    //OTPMobile();
                    OTPMobile(txtemail.Text.ToString());
                    //An OTP has been sent to your mobile no. Please enter it to verify.
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your mobile no. Please enter it to verify.');", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('An OTP has been sent to your Mobile. Please enter it to verify.');", true);
                }
              else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Pls Enter Correct Password(Mobile no) and UserId(Mail Id)');", true);
                    txtemail.Text = "";
                    txtcontact.Text = "";
                }

            }


            //OTPMobile(txtemail.Text.ToString());
            //An OTP has been sent to your mobile no. Please enter it to verify.



        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error!!. Pl try again.');", true);

        }

    }
    public void OTPMobile(string email)
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
            string msgMobile = "Dear " + "user" + "\r\n" + "" + "Your OTP is : '" + finalOTPMobile + "'" + "\r\n" + "Please confirm to register";
            msgMobile = msgMobile + "\r\n" + "\r\n" + "Regards ," + "\r\n" + "Commissionerate of Industries," + "\n" + "TS-iPASS Cell.";

            string bodyMobile = msgMobile;
            //SendSingleSMSnew(txtcontact.Text, bodyMobile);
            OTPAfterSubmissionApplcnForInspectionOffcr(bodyMobile);
            // Button1.Text = "Click Here To Register";
            HDFmsgOTP.Value = strOTPMobile;   //stored otp message value here.
            //Button1.Visible = false;
            //imgid.Visible = true;
            //BtnSave_Click(null, null);
          //  OTPGenerationMail(email, strOTPMobile);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    private void OTPAfterSubmissionApplcnForInspectionOffcr(string bodyMobile)
    {
        String Email = "", /*UserID = ""*/ MobileNo = "";
        Email = txtemail.Text;
        MobileNo = txtcontact.Text;

        //string msg1 = " your Login Credentials." + "\r\n" + " User Id : " + Email + "\r\n" + "Password : " + MobileNo + "\r\n";
        //string msgs = "Dear Officer " + " " + "\r\n" + " Inspection Details Submitted Successfully." + "\r\n";
        //msgs = msgs + msg1 + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

        string body = bodyMobile;
        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = Email; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("kcsbabu@gmail.com");
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

        mail.Subject = "OTP -";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
        mail.Body = ""+ bodyMobile + " " + "<br><br>" ;

        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
        client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");

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
          //  SendSingleSMSnew(MobileNo, body);


        lblmsg.Text = "OTP sent to Registerd E-Mail And Registerd Mobile No ";
        Failure.Visible = false;
        success.Visible = true;
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
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
    


    protected void txtOTPVerify_TextChanged1(object sender, EventArgs e)
    {
        try
        {
           if (txtOTPVerify.Text == HDFmsgOTP.Value.ToString())
            //if(123==123)
            {
                // BtnSave_Click(sender, e);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP Verification Successful. Please proceed for registration.');", true);
                // BtnSave2.Enabled = true;
                Button1.Enabled = false;
                // BtnSave1.Enabled = true;
                // BtnSave1.Visible = false;
                Button1.Visible = false;

                txtOTPVerify.Enabled = false;
               // imgid.Visible = true;
                //txtname2.Focus();
                GridView1.Visible = true;
                FILLGRID();
                lblmsg.Text = "";
                success.Visible = false;
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



    

    public void FILLGRID()
    {
  
        ds =Gen. insepctionreport(txtemail.Text, txtcontact.Text);
       
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        
    }

    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink1");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "File_Link"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
        HyperLink A = (HyperLink)e.Row.FindControl("hprlink2");

        string hyperLnkA = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "File_Link2"));

        if (hyperLnkA != "")
        {
            A.Text = "View";
            A.Visible = true;


        }
        HyperLink B = (HyperLink)e.Row.FindControl("hprlink3");

        string hyperLnkB = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "File_Link3"));

        if (hyperLnkB != "")
        {
            B.Text = "View";
            B.Visible = true;


        }
        HyperLink C = (HyperLink)e.Row.FindControl("hprlink4");

        string hyperLnkC = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "File_Link4"));

        if (hyperLnkC != "")
        {
            C.Text = "View";
            C.Visible = true;


        }
    }
}