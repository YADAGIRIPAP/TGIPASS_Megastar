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

public partial class UI_TSiPASS_FeedbackSMSAlertForm : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DataSet dsOldFBdata = new DataSet();
                dsOldFBdata = Gen.GetOldFBdatatoSend("", "A");

                SendSmsEmail(Session["uid"].ToString(), dsOldFBdata);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SendSmsEmail(string userid, DataSet dsOldFBdata)
    {

        string UidNo = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", Link = "";


        if (dsOldFBdata != null && dsOldFBdata.Tables.Count > 0 && dsOldFBdata.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsOldFBdata.Tables[0].Rows.Count; i++)
            {
                //UnitEmail = "krishna.cheripally@gmail.com";
                //UnitMobileNo = "9493060305";
                if (dsOldFBdata.Tables[0].Rows[i]["Email"].ToString() != null && dsOldFBdata.Tables[0].Rows[i]["Email"].ToString() != string.Empty)
                {
                    UnitEmail = dsOldFBdata.Tables[0].Rows[i]["Email"].ToString();
                }
                if (dsOldFBdata.Tables[0].Rows[i]["MobileNumber"].ToString() != null && dsOldFBdata.Tables[0].Rows[i]["MobileNumber"].ToString() != string.Empty)
                {
                    UnitMobileNo = dsOldFBdata.Tables[0].Rows[i]["MobileNumber"].ToString();
                }
                if (dsOldFBdata.Tables[0].Rows[i]["link"].ToString() != null && dsOldFBdata.Tables[0].Rows[i]["link"].ToString() != string.Empty)
                {
                    Link = dsOldFBdata.Tables[0].Rows[i]["link"].ToString();
                }
                if (dsOldFBdata.Tables[0].Rows[i]["UID_NO"].ToString() != null && dsOldFBdata.Tables[0].Rows[i]["UID_NO"].ToString() != string.Empty)
                {
                    UidNo = dsOldFBdata.Tables[0].Rows[i]["UID_NO"].ToString();
                }
                try
                {
                    //SendSingleSMSnew(UnitMobileNo, "Sir/Madam," + '\n' + "Thanks for availing services under TS-iPASS. Please click on the link " + Link + " and give your valuable feedback for improving the system further. " + '\n' + "Thank You," + '\n' + " TS-iPASS CELL," + '\n' + "Commissionerate of Industries," + '\n' + "Hyderabad.Ph: 040-23441636.", UidNo,"");
                    // SendSingleSMSnew(UnitMobileNo, "Sir/Madam," + '\n' + "Thanks for obtaining approvals for renewal through TS-iPASS. Please click on the link " + Link + " and give your valuable feedback for improving the system further. " + '\n' + "Thank You," + '\n' + " TS-iPASS CELL," + '\n' + "Commissionerate of Industries," + '\n' + "Hyderabad.Ph: 040-23441636", UidNo);
                    // SendSingleSMSnew(UnitMobileNo, "Sir/Madam," + '\n' + "Thanks for obtaining CFO approvals under TS-iPASS. Please click on the link " + Link + " and give your valuable feedback for improving the system further. " + '\n' + "Thank You," + '\n' + " TS-iPASS CELL," + '\n' + "Commissionerate of Industries," + '\n' + "Hyderabad.Ph: 040-23441636, Cell: 9908077333", UidNo);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    cmf.SendFeedbackmail(UnitEmail, "Sir/Madam,<br />" + "Thanks for obtaining CFE approvals under TS-iPASS. Hope you had a good experience with the system.Kindly spare some time to give feedback for improving the system further. Please click on the below link to give your valuable feedback. Thank You." + " <br /><br /> Portal address:  " + Link + "<br /> <br />TS-iPASS CELL," + "<br /> Commissionerate of Industries," + "<br /> Chirag-ali-lane, abids, Hyderabad " + "<br /> Ph: 040-23441636.");
                    //cmf.SendFeedbackmail(UnitEmail, "Sir/Madam,<br />" + "Thanks for obtaining approvals for renewal through TS-iPASS. Hope you had a good experience with the system.Kindly spare some time to give feedback for improving the system further. Please click on the below link to give your valuable feedback. Thank You." + " <br /><br /> Portal address:  " + Link + "<br /> <br />TS-iPASS CELL," + "<br /> Commissionerate of Industries," + "<br /> Chirag-ali-lane, abids, Hyderabad " + "<br /> Ph: 040-23441636");
                    //cmf.SendFeedbackmail(UnitEmail, "Sir/Madam,<br />" + "Thanks for obtaining CFO approvals under TS-iPASS. Hope you had a good experience with the system.Kindly spare some time to give feedback for improving the system further. Please click on the below link to give your valuable feedback. Thank You." + " <br /><br /> Portal address:  " + Link + "<br /> <br />TS-iPASS CELL," + "<br /> Commissionerate of Industries," + "<br /> Chirag-ali-lane, abids, Hyderabad " + "<br /> Ph: 040-23441636, Cell: 9908077333 ");
                    //cmf.SendFeedbackmail(UnitEmail, "Sir/Madam,<br />" + "Thanks for applying incentives through TS-iPASS. Hope you had a good experience with the system.Kindly spare some time to give feedback for improving the system further. Please click on the below link to give your valuable feedback. Thank You." + " <br /><br /> Portal address:  " + Link + "<br /> <br />TS-iPASS CELL," + "<br /> Commissionerate of Industries," + "<br /> Chirag-ali-lane, abids, Hyderabad " + "<br /> Ph: 040-23441636, Cell: 9908077333 ");
                }
                catch (Exception ex)
                {

                }
            }
        }
    }

    //public string SendSingleSMSnew(String mobileNo, String message, string UidNo)
    //{
    //    //String username = "cgg-tipass";
    //    //String password = "tip@$$@2016";
    //    //String senderid = "TiPASS";

    //    String username = "TSIPASS";
    //    String password = "kcsb@786";
    //    String senderid = "TSIPAS";

    //    HttpWebRequest request;


    //    string responseFromServer = "";
    //    try
    //    {
    //        request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
    //        request.ProtocolVersion = HttpVersion.Version10;
    //        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
    //        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //        request.Method = "POST";
    //        String smsservicetype = "singlemsg"; //For single message.
    //        String query = "username=" + HttpUtility.UrlEncode(username) +
    //            "&password=" + HttpUtility.UrlEncode(password) +
    //            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
    //            "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
    //            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //            "&senderid=" + HttpUtility.UrlEncode(senderid);

    //        byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //        request.ContentType = "application/x-www-form-urlencoded";
    //        request.ContentLength = byteArray.Length;
    //        Stream dataStream = request.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();
    //        WebResponse response = request.GetResponse();
    //        String Status = ((HttpWebResponse)response).StatusDescription;
    //        dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        responseFromServer = reader.ReadToEnd();
    //        reader.Close();
    //        response.Close();
    //        dataStream.Close();
    //        //  request.KeepAlive = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);

    //    }
    //    responseFromServer = responseFromServer.Replace("\r\n", string.Empty);

    //    if (responseFromServer.Contains("402"))
    //    {
    //        DataSet result = new DataSet();
    //        result = Gen.GetOldFBdatatoSend(UidNo, "U");
    //    }
    //    return responseFromServer.Trim();
    //    // return "402,1,0";
    //}

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
}