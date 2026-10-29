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
public partial class forgotpwd : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnPassword_Click(object sender, EventArgs e)
    {
        String Email = "", UserID = "", MobileNo = "";
        Email = txtEmail.Text;
        MobileNo = txtMobile.Text;
        UserID = txtuserid.Text;

        General clsGeneral = new General();
        DataSet ds = clsGeneral.ValidateEmail(Email, MobileNo, UserID);//,Dept
        if (ds.Tables[0].Rows.Count > 0)
        {
            string userpasword = ds.Tables[0].Rows[0]["Password"].ToString();
            if (ds.Tables[0].Rows[0]["PwdEncryflag"].ToString().Trim() == "Y")
            {
                userpasword = clsGeneral.Decrypt(userpasword, "SYSTIME");
            }
            //string msgs = "Dear " + ds.Tables[0].Rows[0]["Firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString() + "\r\n" + " you are Login Credentials." + "\r\n" + " User Id : " + ds.Tables[0].Rows[0]["User_id"].ToString() + "\r\n" + "Password : " + userpasword + "\r\n";
            //msgs = msgs + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";//Commented on 24/06/2022 for sending SMS

            string msgs = "TS-iPASS:Dear " + ds.Tables[0].Rows[0]["Firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString() + "\r\n" + " you are Login Credentials." + "\r\n" + " User Id : " + ds.Tables[0].Rows[0]["User_id"].ToString() + "\r\n" + "Password : " + userpasword + "\r\n";
            msgs = msgs + "Thanks and Regards," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";

            SendSingleSMSnew(ds.Tables[0].Rows[0]["MobileNo"].ToString(), msgs, "1007869682688597663");

            string body = msgs;
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = ds.Tables[0].Rows[0]["Email"].ToString(); //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("kcsbabu@gmail.com");
            //mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Enterprenuer -Forgot Password Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;  //ds.Tables[0].Rows[0]["Password"].ToString()
            mail.Body = "Dear " + ds.Tables[0].Rows[0]["Firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString() + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> " + ds.Tables[0].Rows[0]["Firstname"].ToString() + " " + ds.Tables[0].Rows[0]["Lastname"].ToString() + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + ds.Tables[0].Rows[0]["User_id"].ToString() + "<br> <br> Password : " + userpasword + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

           // client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
           // client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
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
            //cmf.SendSingleSMS(ds.Tables[0].Rows[0]["MobileNo"].ToString(), body);
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtuserid.Text = "";
            lblmsg.Text = "Login Credentials sent to Registerd E-Mail and Mobile";
            Failure.Visible = false;
            success.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
        }
        else
        {
            lblmsg0.Text = "Please Enter Registerd E-Mail and Mobile and User Name";
            Failure.Visible = true;
            success.Visible = false;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
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

    /// <summary>

    /// Method to Generate hash code 

    /// </summary>

    /// <param name="secure_key">your last generated Secure_key

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
    public String SendSingleSMSnew(String mobileNo, String message, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";

        Stream dataStream = null;
        StreamReader reader = null;
        WebResponse response = null;

        try
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = true;
            request.ServicePoint.ConnectionLimit = 10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            String encryptedPassword = encryptedPasswod(password);
            String newSecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg";

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                           "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                           "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                           "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                           "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                           "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                           "&key=" + HttpUtility.UrlEncode(newSecureKey.Trim()) +
                           "&templateid=" + HttpUtility.UrlEncode(templID.Trim());

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            response = request.GetResponse();
            String status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }
        catch (WebException webEx)
        {
            return "Error: " + webEx.Message;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
        finally
        {
            if (reader != null) reader.Close();
            if (dataStream != null) dataStream.Close();
            if (response != null) response.Close();
        }
    }
    //public String SendSingleSMSnew(String mobileNo, String message, string templID)
    //{
    //    String username = "TSIPASS";
    //    String password = "kcsb@786";
    //    String senderid = "TSIPAS";
    //    String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
    //    //Latest Generated Secure Key

    //    Stream dataStream;
    //    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
    //    request.ProtocolVersion = HttpVersion.Version10;
    //    request.KeepAlive = false;
    //    request.ServicePoint.ConnectionLimit = 1;
    //    //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
    //    ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //    request.Method = "POST";
    //    //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
    //    //System.Net.ServicePointManager.CertificatePolicy= new 
    //    String encryptedPassword = encryptedPasswod(password);
    //    String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
    //    String smsservicetype = "singlemsg"; //For single message.
    //    String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
    //        "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
    //        "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
    //        "&content=" + HttpUtility.UrlEncode(message.Trim()) +
    //        "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //        "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
    //        "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
    //        "&templateid=" + HttpUtility.UrlEncode(templID.Trim());


    //    byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //    request.ContentType = "application/x-www-form-urlencoded";
    //    request.ContentLength = byteArray.Length;
    //    dataStream = request.GetRequestStream();
    //    dataStream.Write(byteArray, 0, byteArray.Length);
    //    dataStream.Close();
    //    WebResponse response = request.GetResponse();
    //    String Status = ((HttpWebResponse)response).StatusDescription;
    //    dataStream = response.GetResponseStream();
    //    StreamReader reader = new StreamReader(dataStream);
    //    String responseFromServer = reader.ReadToEnd();
    //    reader.Close();
    //    dataStream.Close();
    //    response.Close();
    //    return responseFromServer;
    //}
}