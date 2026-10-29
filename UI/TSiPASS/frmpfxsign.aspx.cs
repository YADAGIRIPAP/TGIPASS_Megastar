using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.IO;
public partial class UI_TSiPASS_frmpfxsign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetPANRequest("1");
            var inputDataList = new List<InputData>
        {
            new InputData { Pan = "AABCS4225M", Name = "SERUM INSTITUTE OF INDIA PRIVATE LIMITED", FatherName = "", Dob = "22/05/1984" }
            //,            new InputData { Pan = "AAATN1963H", Name = "NATIONAL HIGHWAY AUTHORITY OF INDIA", FatherName = "", Dob = "16/12/1988" } 
        };
            var JsonFrimDetails = JsonConvert.SerializeObject(inputDataList);
            GetPANRequest("2");
            string oath = Convert.ToString(ConfigurationManager.AppSettings["PANCertificatename"]);
            string password = Convert.ToString(ConfigurationManager.AppSettings["PANFXPassword"]);

            // Load the certificate from the .pfx file with the correct password
            X509Certificate2 certificate = new X509Certificate2(oath, password);
            GetPANRequest("3");
            // Create content to be signed

            byte[] data = Encoding.UTF8.GetBytes(JsonFrimDetails) ;
            ContentInfo contentInfo = new ContentInfo(data);

            // Create a signer
            CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);

            // Create a SignedCms object
            SignedCms signedCms = new SignedCms(contentInfo, detached: true);
            GetPANRequest("4");
            // Compute the signature
            signedCms.ComputeSignature(signer);
            GetPANRequest("5");
            // Encode the SignedCms object
            byte[] signedData = signedCms.Encode();
            string signature = Convert.ToBase64String(signedData);

            GetPANRequest(signature);
            var root = new RootObject
            {
                InputData = inputDataList,
                Signature =signature
            };
            // Serialize root object to JSON
            string json = JsonConvert.SerializeObject(root, Formatting.Indented);
            // Verify the signature (optional)
            //signedCms.CheckSignature(true);
            string url = Convert.ToString(ConfigurationManager.AppSettings["PANURL"]);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            string WEBSERVICE_URL = url;
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                LogErrorFile.LogData(Convert.ToString(webRequest));
                if (webRequest != null)
                {
                    // Add headers
                    //DateTime currentDateTime = DateTime.Now;
                    // Format the date and time as required
                    string formattedDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");// currentDateTime.ToString("YYYY-MM-DDThh:mm:ss"); //YYYY - MM - DDThh:mm: ss
                    LogErrorFile.LogData("formattedDateTime" + formattedDateTime);
                    string Transactional_id = formattedDateTime.Replace("-", "");
                    webRequest.Headers.Add("User_ID", "V0024301");
                    webRequest.Headers.Add("Records_count", "2");
                    webRequest.Headers.Add("Request_time", formattedDateTime);
                    webRequest.Headers.Add("Transaction_ID", "V0024301 " + ":" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString());// + Transactional_id);
                    webRequest.Headers.Add("Version", "4");
                    webRequest.Method = "POST";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    LogErrorFile.LogData(webRequest.Headers.ToString());
                    // Convert JSON string to byte array
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    LogErrorFile.LogData(Convert.ToString(json));
                    // Set content length
                    webRequest.ContentLength = byteArray.Length;

                    // Write JSON data to request body
                    using (Stream dataStream = webRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                    
                    try
                    {
                        // Get response
                        using (WebResponse response = webRequest.GetResponse())
                        {
                            // Read response
                            using (Stream responseStream = response.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                string responseJson = reader.ReadToEnd();//{"connectionid":"241834332402090001","status":"success"}
                                Console.WriteLine("status: " + responseJson);
                                //if (responseJson.Contains("success"))
                                //{
                                    LogErrorFile.LogData(Convert.ToString(responseJson));
                                //}
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        // Handle exception
                        if (ex.Response != null)
                        {
                            using (WebResponse errorResponse = ex.Response)
                            {
                                using (Stream errorStream = errorResponse.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                    string errorText = reader.ReadToEnd();
                                    Console.WriteLine("Error response: " + errorText);
                                    LogErrorFile.LogData(Convert.ToString(errorText));
                                }
                            }
                        }
                    }
                     
                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogData(Convert.ToString(ex.Message));
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            } 
        }
        catch (CryptographicException ex)
        {
            GetPANRequest(ex.Message);
            LogErrorFile.LogData(Convert.ToString(ex.Message));
        }
        catch (Exception ex)
        {
            GetPANRequest(ex.Message);
            LogErrorFile.LogData(Convert.ToString(ex.Message));
        }
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

}
public class InputData
{
    public string Pan { get; set; }
    public string Name { get; set; }
    public string FatherName { get; set; }
    public string Dob { get; set; }
}

public class RootObject
{
    public List<InputData> InputData { get; set; }
    public string Signature { get; set; }
}