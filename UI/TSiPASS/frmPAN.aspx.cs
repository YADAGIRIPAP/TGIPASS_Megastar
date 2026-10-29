using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography.Pkcs;
using System.Web.Script.Serialization;

public partial class UI_TSiPASS_frmPAN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string url = Convert.ToString(ConfigurationManager.AppSettings["PANURL"]);
            //string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPassword"]);
            //string certificate = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatename"]);
            //string userid = Convert.ToString(ConfigurationManager.AppSettings["PANUserid"]);

            string url = Convert.ToString(ConfigurationManager.AppSettings["PANURLLIVE"]);
            string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPasswordLIVE"]);
            string certificate = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatenameLIVE"]);
            string userid = Convert.ToString(ConfigurationManager.AppSettings["PANUseridLIVE"]);

            string pan = "AHBPV4068M";
            string name = "SRIVANI VANGURU";
            string fathername = "";
            string dob = "04/06/1984";
            string record_count = "1";
            try
            {

                GetPANRequest("url: " + url + " passowrd: " + password + " certificatepath: " + certificate + " userid: " + userid);
            }
            catch (Exception ex)
            {

            }
            PanInquiryRequestData inputdatum = new PanInquiryRequestData();
            List<PanInquiryRequestData> input = new List<PanInquiryRequestData>();

            var Mypanbody = (dynamic)null;
            inputdatum.pan = pan;
            inputdatum.name = name;
            inputdatum.fathername = fathername;
            inputdatum.dob = dob;
            input.Add(inputdatum);
            Mypanbody = JsonConvert.SerializeObject(input);
            try
            {

                GetPANRequest(Mypanbody);
            }
            catch (Exception ex)
            {

            }
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

            X509Certificate2 m = new X509Certificate2(certificate, password);
            byte[] bytes = encoding.GetBytes(Mypanbody);
            byte[] sig = Sign(bytes, m);
            String sigi = Convert.ToBase64String(sig);
            hdnPanSignature.Value = sigi;



            //HttpWebRequest myrequest = (HttpWebRequest)WebRequest.Create(url);

            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            formattedDateTime = formattedDateTime.Replace(@"/", "-");
            string Transactional_id = formattedDateTime.Replace("-", "");
            //myrequest.Headers.Add("User_ID", userid);
            //myrequest.Headers.Add("Records_count", record_count);
            //myrequest.Headers.Add("Request_time", formattedDateTime);
            //myrequest.Headers.Add("Transaction_ID", userid + ":" + Transactional_id);
            //myrequest.Headers.Add("Version", "4");
            //myrequest.ContentType = "application / json";
            //myrequest.Method = "POST";

            PanRx ip = new PanRx();
            ip.inputData = input;
            ip.signature = sigi;

            string json = new JavaScriptSerializer().Serialize(ip);
            try
            {

                GetPANRequest(json);
            }
            catch (Exception ex)
            {

            }
            using (WebClient wc = new WebClient())
            {
                // ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(true);
                ServicePointManager.ServerCertificateValidationCallback += ValidateServerCertificate;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | (SecurityProtocolType)(0xc00) | SecurityProtocolType.Ssl3;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers.Add("User_ID", userid);
                wc.Headers.Add("Records_count", record_count);
                wc.Headers.Add("Request_time", formattedDateTime);
                wc.Headers.Add("Transaction_ID", userid + ":" + Transactional_id);
                wc.Headers.Add("Version", "4");

                var output = wc.UploadString(url, json);
                GetPANResponse(output);
            }
        }
        catch (Exception ex)
        {
            GetPANResponse(ex.Message);
        }
    }
    static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Implement your certificate validation logic here
        // For example, you might check the certificate issuer, validity period, etc.
        // Return true if the certificate is considered valid, false otherwise

        // For simplicity, always return true (accept all certificates)
        return true;
    }
    public static byte[] Sign(byte[] data, X509Certificate2 certificate)
    {
        if (data == null)
            throw new ArgumentException("data");
        if (certificate == null)
            throw new ArgumentException("certificate");

        ContentInfo content = new ContentInfo(data);
        SignedCms signedcms = new SignedCms(content, false);
        CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
        signedcms.ComputeSignature(signer);
        return signedcms.Encode();
    }

    public void GetPANRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_PANREQUEST", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
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
    public void GetPANResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_PANRESPONSE", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
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
public class PanInquiryRequestData
{
    public string pan { get; set; }
    public string name { get; set; }
    public string fathername { get; set; }
    public string dob { get; set; }
}

public class PanRx
{
    public List<PanInquiryRequestData> inputData { get; set; }
    public string signature { get; set; }
}
//public class RootObject
//{
//    public List<PANVO> inputData { get; set; }
//}