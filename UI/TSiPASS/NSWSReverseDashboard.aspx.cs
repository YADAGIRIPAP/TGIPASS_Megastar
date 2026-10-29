using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
public partial class UI_TSiPASS_NSWSReverseDashboard : System.Web.UI.Page
{
    Cls_NSWSDashboard Cls_NSWSDashboardobj = new Cls_NSWSDashboard();
    string accessToken = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Generatetoken();
        GetPanDetails();
    }
    public void Generatetoken()
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            string apiUrl = "https://api.nsws.gov.in/gateway/auth/authenticate";
            //'https://sso-uat-nsws.investindia.gov.in/auth/realms/madhyam/protocol/openid-connect/token' 
            using (var client = new HttpClient())
            {

                // Request headers
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                // Request body data
                var parameters = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", "sws_state" },
                { "username", "TelanNsws" },  // Replace with actual username
                { "password", "TelanNsws@2024" },        // Replace with actual password
                { "client_secret", "643790eb-2b2a-4187-8c43-54a663b840eb" }  // Replace with actual secret
            };

                var content = new FormUrlEncodedContent(parameters);
                // Serialize the content to a readable string
                var serializedContent = content.ReadAsStringAsync().Result;

                // Log the serialized content
                LogErrorFile.LogData(serializedContent);
                //LogErrorFile.LogData(content.ToString());
                var response = client.PostAsync(apiUrl, content).Result;
                LogErrorFile.LogData("Before Token :" + response);
                var result = response.Content.ReadAsStringAsync().Result;
                TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
                //dynamic json = JsonConvert.DeserializeObject(result);
                LogErrorFile.LogData(result.ToString());
                accessToken = tokenResponse.AccessToken;
                LogErrorFile.LogData(accessToken);
                // Store or use the access token as needed
            }
        }
        catch (Exception ex)
        {
        }
    }
    DB.DB con = new DB.DB();
    public void GetPanDetails()
    {
        try
        {
            string WEBSERVICE_URL = "https://www.nsws.gov.in/gateway/user/org/getPanDetailsFromNsws?state_id=29";
            LogErrorFile.LogData("CALLING PAN DETAILS");
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                //     webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/json";
                webRequest.Headers["Authorization"] = "Bearer " + accessToken;
                LogErrorFile.LogData(webRequest.ToString());
                try
                {
                    // Get response
                    using (WebResponse response = webRequest.GetResponse())
                    {
                        // Read response
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            string responseJson = reader.ReadToEnd();
                            LogErrorFile.LogData("getPanDetailsFromNsws Response: " + responseJson);
                            Console.WriteLine("getPanDetailsFromNsws Response: " + responseJson);
                            if (responseJson != null)
                            {
                                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseJson);
                                List<CompanyInfo> companies = apiResponse.Data;
                                //List<CompanyInfo> companies = JsonConvert.DeserializeObject<List<CompanyInfo>>(responseJson);
                                LogErrorFile.LogData("getPanDetailsFromNsws Response LIST ADDED: " + responseJson);
                                CompanyInfo objcompany = new CompanyInfo();
                                if (companies != null)
                                {
                                    foreach (var company in companies)
                                    {
                                        objcompany.PanNumber = company.PanNumber;
                                        objcompany.NameAsPerPan = company.NameAsPerPan;
                                        objcompany.GstIn = company.GstIn;
                                        objcompany.CinNumber = company.CinNumber;
                                        objcompany.SwsId = company.SwsId;
                                        // int valid = Cls_NSWSDashboardobj.InsertNSWSDashboardResponseOutput(objcompany);
                                        LogErrorFile.LogData(
           "Before Insert => PAN : " + objcompany.PanNumber +
           ", Name : " + objcompany.NameAsPerPan +
           ", GST : " + objcompany.GstIn +
           ", CIN : " + objcompany.CinNumber +
           ", SWSID : " + objcompany.SwsId);

                                        try
                                        {
                                            int valid = Cls_NSWSDashboardobj.InsertNSWSDashboardResponseOutput(objcompany);

                                            LogErrorFile.LogData(
                                                "Insert Result => " + valid +
                                                ", SWSID : " + objcompany.SwsId);
                                        }
                                        catch (Exception ex)
                                        {
                                            LogErrorFile.LogData(
                                                "Insert Error for SWSID : " + objcompany.SwsId +
                                                " Error : " + ex.ToString());
                                        }
                                    }
                                    //DataSet ds = new DataSet();
                                    //ds = Cls_NSWSDashboardobj.GetNSWSDashboardUsers();
                                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    //{
                                    //    var consumedSwsIds = new List<string>();

                                    //    foreach (DataRow row in ds.Tables[0].Rows)
                                    //    {
                                    //        string swsId = row["ConsumedSwsIds"].ToString();
                                    //        if (!string.IsNullOrEmpty(swsId))
                                    //        {
                                    //            consumedSwsIds.Add(swsId);
                                    //        }
                                    //    }

                                    //    var result = new
                                    //    {
                                    //        consumedSwsIds = consumedSwsIds,
                                    //        state_id = "29"
                                    //    };

                                    //    var JsonDetail = JsonConvert.SerializeObject(result, Formatting.Indented);

                                    //    try
                                    //    { 
                                    //        string WEBSERVICE_URLACk = "https://www.nsws.gov.in/gateway/user/org/ackPanDetailsFromNsws";
                                    //        var webRequestAck = System.Net.WebRequest.Create(WEBSERVICE_URLACk);

                                    //        if (webRequestAck != null)
                                    //        {
                                    //            webRequestAck.Method = "POST"; // Change to POST
                                    //            webRequestAck.Timeout = 20000;
                                    //            webRequestAck.ContentType = "application/json";
                                    //            webRequestAck.Headers["Authorization"] = "Bearer " + accessToken;

                                    //            // Convert JSON string to byte array
                                    //            byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetail);

                                    //            // Set content length
                                    //            webRequestAck.ContentLength = byteArray.Length;

                                    //            // Write JSON data to request body
                                    //            using (Stream dataStream = webRequestAck.GetRequestStream())
                                    //            {
                                    //                dataStream.Write(byteArray, 0, byteArray.Length);
                                    //            }

                                    //            LogErrorFile.LogData(webRequestAck.ToString());

                                    //            try
                                    //            {
                                    //                // Get response
                                    //                using (WebResponse responseAck = webRequestAck.GetResponse())
                                    //                {
                                    //                    // Read response
                                    //                    using (Stream responseStreamAck = responseAck.GetResponseStream())
                                    //                    {
                                    //                        StreamReader readerAck = new StreamReader(responseStreamAck, Encoding.UTF8);
                                    //                        string responseJsonAck = readerAck.ReadToEnd();
                                    //                        LogErrorFile.LogData("ackPanDetailsFromNsws Response : " + responseJsonAck);
                                    //                        Console.WriteLine("ackPanDetailsFromNsws Response : " + responseJsonAck);

                                    //                        if (responseJsonAck.Contains("success"))
                                    //                        {
                                    //                            Console.WriteLine("Acknowledgement Successful");
                                    //                        }
                                    //                    }
                                    //                }
                                    //            }
                                    //            catch (WebException ex)
                                    //            {
                                    //                LogErrorFile.LogData("Error response Acknowledgement : " + ex.Message);

                                    //                // Handle exception and log error response
                                    //                if (ex.Response != null)
                                    //                {
                                    //                    using (WebResponse errorResponse = ex.Response)
                                    //                    {
                                    //                        using (Stream errorStream = errorResponse.GetResponseStream())
                                    //                        {
                                    //                            StreamReader reader1 = new StreamReader(errorStream, Encoding.UTF8);
                                    //                            string errorText = reader1.ReadToEnd();
                                    //                            LogErrorFile.LogData("Error response Acknowledgement: " + errorText);
                                    //                            Console.WriteLine("Error response Acknowledgement: " + errorText);
                                    //                        }
                                    //                    }
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //    catch (WebException ex)
                                    //    {
                                    //        LogErrorFile.LogData("ackPanDetailsFromNsws Error response: " + ex.Message);
                                    //        // Handle exception
                                    //        if (ex.Response != null)
                                    //        {
                                    //            using (WebResponse errorResponse = ex.Response)
                                    //            {
                                    //                using (Stream errorStream = errorResponse.GetResponseStream())
                                    //                {
                                    //                    StreamReader reader1 = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                    //                    string errorText = reader1.ReadToEnd();
                                    //                    LogErrorFile.LogData("ackPanDetailsFromNsws Error response Acknowledgement: " + errorText);
                                    //                    Console.WriteLine("ackPanDetailsFromNsws Error response Acknowledgement: " + errorText);
                                    //                }
                                    //            }
                                    //        }
                                    //    }
                                    //}
                                    //try
                                    //{
                                    //    DataSet ds = Cls_NSWSDashboardobj.GetNSWSDashboardUsers();

                                    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    //    {
                                    //        List<string> consumedSwsIds = new List<string>();

                                    //        foreach (DataRow row in ds.Tables[0].Rows)
                                    //        {
                                    //            string swsId = Convert.ToString(row["ConsumedSwsIds"]);

                                    //            if (!string.IsNullOrWhiteSpace(swsId))
                                    //            {
                                    //                consumedSwsIds.Add(swsId.Trim());
                                    //            }
                                    //        }

                                    //        if (consumedSwsIds.Count > 0)
                                    //        {
                                    //            var requestObj = new
                                    //            {
                                    //                consumedSwsIds = consumedSwsIds,
                                    //                state_id = "29"
                                    //            };

                                    //            string JsonDetail =
                                    //                JsonConvert.SerializeObject(requestObj, Formatting.Indented);

                                    //            LogErrorFile.LogData("==================================");
                                    //            LogErrorFile.LogData("ACK REQUEST START");
                                    //            LogErrorFile.LogData("Total SWS IDs : " + consumedSwsIds.Count);
                                    //            LogErrorFile.LogData("Request JSON : ");
                                    //            LogErrorFile.LogData(JsonDetail);
                                    //            LogErrorFile.LogData("==================================");

                                    //            string WEBSERVICE_URLACk =
                                    //                "https://www.nsws.gov.in/gateway/user/org/ackPanDetailsFromNsws";

                                    //            HttpWebRequest webRequestAck =
                                    //                (HttpWebRequest)WebRequest.Create(WEBSERVICE_URLACk);

                                    //            webRequestAck.Method = "POST";
                                    //            webRequestAck.ContentType = "application/json";
                                    //            webRequestAck.Accept = "application/json";
                                    //            webRequestAck.Timeout = 60000;
                                    //            webRequestAck.ReadWriteTimeout = 60000;
                                    //            Generatetoken();
                                    //            webRequestAck.Headers["Authorization"] = "Bearer " + accessToken.Trim();
                                    //            //webRequest.Headers["Authorization"] = "Bearer " + accessToken;
                                    //            //webRequestAck.Headers.Add(
                                    //            //    "Authorization",
                                    //            //    "Bearer " + accessToken);
                                    //            LogErrorFile.LogData("===== ACK API CALL START =====");
                                    //            LogErrorFile.LogData("ACK URL: " + WEBSERVICE_URLACk);
                                    //            LogErrorFile.LogData("TOKEN EXISTS: " + (!string.IsNullOrEmpty(accessToken)));
                                    //            //LogErrorFile.LogData("TOKEN LENGTH: " + (accessToken?.Length ?? 0));
                                    //            LogErrorFile.LogData("ACK TOKEN LENGTH: " + (accessToken != null ? accessToken.Length.ToString() : "NULL"));
                                    //            byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetail);

                                    //            webRequestAck.ContentLength = byteArray.Length;

                                    //            using (Stream dataStream = webRequestAck.GetRequestStream())
                                    //            {
                                    //                dataStream.Write(byteArray, 0, byteArray.Length);
                                    //            }

                                    //            try
                                    //            {
                                    //                using (HttpWebResponse responseAck =
                                    //                    (HttpWebResponse)webRequestAck.GetResponse())
                                    //                {
                                    //                    string responseJsonAck = "";

                                    //                    using (Stream responseStreamAck =
                                    //                        responseAck.GetResponseStream())
                                    //                    {
                                    //                        using (StreamReader readerAck =
                                    //                            new StreamReader(responseStreamAck, Encoding.UTF8))
                                    //                        {
                                    //                            responseJsonAck = readerAck.ReadToEnd();
                                    //                        }
                                    //                    }

                                    //                    LogErrorFile.LogData("ACK RESPONSE STATUS : "
                                    //                                         + (int)responseAck.StatusCode);

                                    //                    LogErrorFile.LogData("ACK RESPONSE : "
                                    //                                         + responseJsonAck);

                                    //                    Console.WriteLine(responseJsonAck);
                                    //                }
                                    //            }
                                    //            catch (WebException ex)
                                    //            {
                                    //                LogErrorFile.LogData("ACK API ERROR : " + ex.Message);

                                    //                if (ex.Response != null)
                                    //                {
                                    //                    HttpWebResponse errorResponse =
                                    //                        (HttpWebResponse)ex.Response;

                                    //                    LogErrorFile.LogData("HTTP STATUS CODE : "
                                    //                                         + (int)errorResponse.StatusCode);

                                    //                    LogErrorFile.LogData("HTTP STATUS : "
                                    //                                         + errorResponse.StatusDescription);

                                    //                    using (Stream errorStream =
                                    //                        errorResponse.GetResponseStream())
                                    //                    {
                                    //                        using (StreamReader readerAck =
                                    //                            new StreamReader(errorStream, Encoding.UTF8))
                                    //                        {
                                    //                            string errorText = readerAck.ReadToEnd();

                                    //                            LogErrorFile.LogData(
                                    //                                "ACK ERROR RESPONSE BODY :");

                                    //                            LogErrorFile.LogData(errorText);

                                    //                            Console.WriteLine(errorText);
                                    //                        }
                                    //                    }
                                    //                }
                                    //                else
                                    //                {
                                    //                    LogErrorFile.LogData(
                                    //                        "No response received from server.");
                                    //                }
                                    //            }
                                    //        }
                                    //        else
                                    //        {
                                    //            LogErrorFile.LogData(
                                    //                "No SWS IDs found for acknowledgement.");
                                    //        }
                                    //    }
                                    //}
                                    //catch (Exception ex)
                                    //{
                                    //    LogErrorFile.LogData(
                                    //        "GENERAL ACK ERROR : " + ex.ToString());
                                    //}
                                    try
                                    {
                                        DataSet ds = Cls_NSWSDashboardobj.GetNSWSDashboardUsers();

                                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                        {
                                            List<string> consumedSwsIds = new List<string>();

                                            foreach (DataRow row in ds.Tables[0].Rows)
                                            {
                                                string swsIds = Convert.ToString(row["ConsumedSwsIds"]);

                                                if (!string.IsNullOrWhiteSpace(swsIds))
                                                {
                                                    // Handles both single ID and comma-separated IDs
                                                    consumedSwsIds.AddRange(
                                                        swsIds.Split(',')
                                                              .Select(x => x.Trim())
                                                              .Where(x => !string.IsNullOrWhiteSpace(x))
                                                    );
                                                }
                                            }

                                            // Remove duplicates if any
                                            consumedSwsIds = consumedSwsIds.Distinct().ToList();

                                            if (consumedSwsIds.Count > 0)
                                            {
                                                var requestObj = new
                                                {
                                                    consumedSwsIds = consumedSwsIds,
                                                    state_id = 29
                                                };

                                                string JsonDetail = JsonConvert.SerializeObject(requestObj, Formatting.Indented);

                                                LogErrorFile.LogData("==================================");
                                                LogErrorFile.LogData("ACK REQUEST START");
                                                LogErrorFile.LogData("Total SWS IDs : " + consumedSwsIds.Count);
                                                LogErrorFile.LogData("Request JSON : ");
                                                LogErrorFile.LogData(JsonDetail);
                                                LogErrorFile.LogData("==================================");

                                                string WEBSERVICE_URLACk = "https://www.nsws.gov.in/gateway/user/org/ackPanDetailsFromNsws";

                                                HttpWebRequest webRequestAck = (HttpWebRequest)WebRequest.Create(WEBSERVICE_URLACk);

                                                webRequestAck.Method = "POST";
                                                webRequestAck.ContentType = "application/json";
                                                webRequestAck.Accept = "application/json";
                                                webRequestAck.Timeout = 60000;
                                                webRequestAck.ReadWriteTimeout = 60000;

                                                // Generate Access Token
                                                Generatetoken();

                                                webRequestAck.Headers["Authorization"] = "Bearer " + accessToken.Trim();

                                                // CURL LOG
                                                string curlCommand = string.Format(
                                    @"curl --location '{0}' \
--header 'Content-Type: application/json' \
--header 'Accept: application/json' \
--header 'Authorization: Bearer {1}' \
--data-raw '{2}'",
                                                    WEBSERVICE_URLACk,
                                                    accessToken.Trim(),
                                                    JsonDetail.Replace("'", "\\'")
                                                );

                                                LogErrorFile.LogData("==================================");
                                                LogErrorFile.LogData("ACK API CURL");
                                                LogErrorFile.LogData(curlCommand);
                                                LogErrorFile.LogData("==================================");

                                                byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetail);

                                                webRequestAck.ContentLength = byteArray.Length;

                                                using (Stream dataStream = webRequestAck.GetRequestStream())
                                                {
                                                    dataStream.Write(byteArray, 0, byteArray.Length);
                                                }

                                                try
                                                {
                                                    using (HttpWebResponse responseAck =
    (HttpWebResponse)webRequestAck.GetResponse())
                                                    {
                                                        string responseJsonAck = "";

                                                        using (Stream responseStreamAck = responseAck.GetResponseStream())
                                                        {
                                                            using (StreamReader readerAck = new StreamReader(responseStreamAck, Encoding.UTF8))
                                                            {
                                                                responseJsonAck = readerAck.ReadToEnd();
                                                            }
                                                        }

                                                        LogErrorFile.LogData("ACK RESPONSE STATUS : " + (int)responseAck.StatusCode);
                                                        LogErrorFile.LogData("ACK RESPONSE : ");
                                                        LogErrorFile.LogData(responseJsonAck);

                                                        Console.WriteLine(responseJsonAck);

                                                        // Deserialize Response
                                                        AckResponse ackResponse = JsonConvert.DeserializeObject<AckResponse>(responseJsonAck);
                                                         
                                                        if (ackResponse != null && ackResponse.data != null)
                                                        {
                                                            // Update Valid Records
                                                            if (ackResponse.data.ValidList != null)
                                                            {
                                                                foreach (string item in ackResponse.data.ValidList)
                                                                {
                                                                    string[] ids = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                                                    foreach (string id in ids)
                                                                    {
                                                                        string swsId = id.Trim();

                                                                        int result = UpdateAckNSWSDashboard(
                                                                            swsId,
                                                                            "",
                                                                            ((int)responseAck.StatusCode).ToString(),
                                                                            ackResponse.message,
                                                                            "FirstTime");

                                                                        LogErrorFile.LogData(
                                                                            "VALID -> SWSID: " + swsId +
                                                                            ", Result: " + result +
                                                                            ", StatusCode: " + ((int)responseAck.StatusCode) +
                                                                            ", Message: " + ackResponse.message);
                                                                    }
                                                                }
                                                            }

                                                            // Update Duplicate Records
                                                            if (ackResponse.data.DuplicateList != null)
                                                            {
                                                                foreach (string item in ackResponse.data.DuplicateList)
                                                                {
                                                                    string[] ids = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                                                                    foreach (string id in ids)
                                                                    {
                                                                        string swsId = id.Trim();

                                                                        int result = UpdateAckNSWSDashboard(
                                                                            swsId,
                                                                            "",
                                                                            ((int)responseAck.StatusCode).ToString(),
                                                                            ackResponse.message,
                                                                            "Duplicate");

                                                                        LogErrorFile.LogData(
                                                                            "DUPLICATE -> SWSID: " + swsId +
                                                                            ", Result: " + result +
                                                                            ", StatusCode: " + ((int)responseAck.StatusCode) +
                                                                            ", Message: " + ackResponse.message);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    //using (HttpWebResponse responseAck = (HttpWebResponse)webRequestAck.GetResponse())
                                                    //{
                                                    //    string responseJsonAck = "";

                                                    //    using (Stream responseStreamAck = responseAck.GetResponseStream())
                                                    //    using (StreamReader readerAck = new StreamReader(responseStreamAck, Encoding.UTF8))
                                                    //    {
                                                    //        responseJsonAck = readerAck.ReadToEnd();
                                                    //    }

                                                    //    LogErrorFile.LogData("ACK RESPONSE STATUS : " + (int)responseAck.StatusCode);
                                                    //    LogErrorFile.LogData("ACK RESPONSE : ");
                                                    //    LogErrorFile.LogData(responseJsonAck);
                                                    //}
                                                }
                                                catch (WebException ex)
                                                {
                                                    LogErrorFile.LogData("ACK API ERROR : " + ex.Message);

                                                    if (ex.Response != null)
                                                    {
                                                        HttpWebResponse errorResponse = (HttpWebResponse)ex.Response;

                                                        LogErrorFile.LogData("HTTP STATUS CODE : " + (int)errorResponse.StatusCode);
                                                        LogErrorFile.LogData("HTTP STATUS : " + errorResponse.StatusDescription);

                                                        using (Stream errorStream = errorResponse.GetResponseStream())
                                                        using (StreamReader readerackresponse = new StreamReader(errorStream))
                                                        {
                                                            string errorText = readerackresponse.ReadToEnd();
                                                            LogErrorFile.LogData("ACK ERROR RESPONSE:");
                                                            LogErrorFile.LogData(errorText);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LogErrorFile.LogData("No response received from server.");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                LogErrorFile.LogData("No SWS IDs found for acknowledgement.");
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        LogErrorFile.LogData("GENERAL ACK ERROR : " + ex.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    LogErrorFile.LogData("getPanDetailsFromNsws Error response: " + ex.Message);
                    // Handle exception
                    if (ex.Response != null)
                    {
                        using (WebResponse errorResponse = ex.Response)
                        {
                            using (Stream errorStream = errorResponse.GetResponseStream())
                            {
                                StreamReader reader = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                string errorText = reader.ReadToEnd();
                                LogErrorFile.LogData("getPanDetailsFromNsws Error response: " + errorText);
                                Console.WriteLine("getPanDetailsFromNsws Error response: " + errorText);
                            }
                        }
                    }
                }



            }
        }
        catch (Exception ex)
        {
        }
    }

    public int UpdateAckNSWSDashboard(string SWSID, string PANNO,
    string AckStatusCode, string AckMsg, string AckResponse)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_NSWSDASHBOARD_ACKNOWLEDGEMENT";

        com.Parameters.Add("@SWSID", SqlDbType.VarChar).Value =
            string.IsNullOrWhiteSpace(SWSID) ? (object)DBNull.Value : SWSID.Trim();

        com.Parameters.Add("@PANNO", SqlDbType.VarChar).Value =
            string.IsNullOrWhiteSpace(PANNO) ? (object)DBNull.Value : PANNO.Trim();

        com.Parameters.Add("@AckStatusCode", SqlDbType.VarChar).Value =
            string.IsNullOrWhiteSpace(AckStatusCode) ? (object)DBNull.Value : AckStatusCode.Trim();

        com.Parameters.Add("@AckResponse", SqlDbType.VarChar).Value =
            string.IsNullOrWhiteSpace(AckResponse) ? (object)DBNull.Value : AckResponse.Trim();

        com.Parameters.Add("@AckMsg", SqlDbType.VarChar).Value =
            string.IsNullOrWhiteSpace(AckMsg) ? (object)DBNull.Value : AckMsg.Trim();

        // OUTPUT Parameter
        SqlParameter outParam = new SqlParameter("@Valid", SqlDbType.Int);
        outParam.Direction = ParameterDirection.Output;
        com.Parameters.Add(outParam);

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            com.ExecuteNonQuery();
            return Convert.ToInt32(outParam.Value);
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
}
public class AckResponse
{
    public bool status { get; set; }
    public string message { get; set; }
    public AckData data { get; set; }
}

public class AckData
{
    public int ValidCount { get; set; }
    public List<string> ValidList { get; set; }
    public List<string> DuplicateList { get; set; }
    public int DuplicateCount { get; set; }
}