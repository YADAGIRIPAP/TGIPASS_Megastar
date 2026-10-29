using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;
public partial class UI_TSiPASS_frmNSWSDashboard : System.Web.UI.Page
{
    Cls_NSWSDashboard Cls_NSWSDashboardobj = new Cls_NSWSDashboard();
    DB.DB con = new DB.DB();
    NSWSParams nsparams = new NSWSParams();
    Approval Approvalvo = new Approval();
    UpdateLicenseStatus UpdateLicenseStatusvo = new UpdateLicenseStatus();
    PushDocument PushDocumentvo = new PushDocument();
    string ApprovalCertificate;
    protected void Page_Load(object sender, EventArgs e)
    {
        DB.DB con = new DB.DB();
        string token = "";
        nsparams.Emailid = "testuserllp@yopmail.fr";
        nsparams.Password = "Pass@123";
        var JsonDetails = JsonConvert.SerializeObject(nsparams);
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        string apiUrl = "https://ppe-api.nsws.gov.in/gateway/auth/authenticate";
            //"https://uat-nsws.investindia.gov.in/auth/realms/madhyam/protocol/openid-connect/token";
        using (var client = new HttpClient())
        {

            // Request headers
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // Request body data
            var parameters = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "client_id", "sws_state" },
                { "username", "TelanPpe" },  // Replace with actual username
                { "password", "TelanPpe@2024" },        // Replace with actual password
                { "client_secret", "643790eb-2b2a-4187-8c43-54a663b840eb" }  // Replace with actual secret
            };

            var content = new FormUrlEncodedContent(parameters);
            LogErrorFile.LogData("Before Token :" + content.ToString());
            var response = client.PostAsync(apiUrl, content).Result;
            LogErrorFile.LogData("Before Token1 :" + response.ToString());
            var result = response.Content.ReadAsStringAsync().Result;
            TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
            //dynamic json = JsonConvert.DeserializeObject(result);
            LogErrorFile.LogData(result.ToString());
            token = tokenResponse.AccessToken;
            LogErrorFile.LogData("Token Response " + token);
            // Store or use the access token as needed
        }
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
        //request.Method = "POST"; // Set HTTP method (GET, POST, etc.)

        // Set bearer token in the Authorization header
        //request.Headers["Authorization"] = "Bearer" + token;

        string WEBSERVICE_URL = "https://www.ppe.nsws.gov.in/gateway/user/org/getPanDetailsFromNsws?state_id=29";

        try
        {
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                //     webRequest.Headers.Add("token", "bd16b347e586f05339f830b3a85d8aefa8da92c1");
                //webRequest.Headers =  "bd16b347e586f05339f830b3a85d8aefa8da92c1";
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/json";
                webRequest.Headers["Authorization"] = "Bearer " + token;
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
                            LogErrorFile.LogData(responseJson);
                            Console.WriteLine("getPanDetailsFromNsws Response: " + responseJson);
                            if (responseJson != null)
                            {
                                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseJson);
                                List<CompanyInfo> companies = apiResponse.Data;
                                //List<CompanyInfo> companies = JsonConvert.DeserializeObject<List<CompanyInfo>>(responseJson);
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
                                        int valid = InsertNSWSDashboardResponseOutput(objcompany);
                                    }
                                    DataSet ds = new DataSet();
                                    ds = GetNSWSDashboardUsers();
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        var consumedSwsIds = new List<string>();

                                        foreach (DataRow row in ds.Tables[0].Rows)
                                        {
                                            string swsId = row["ConsumedSwsIds"].ToString();
                                            if (!string.IsNullOrEmpty(swsId))
                                            {
                                                consumedSwsIds.Add(swsId);
                                            }
                                        }

                                        var result = new
                                        {
                                            consumedSwsIds = consumedSwsIds,
                                            state_id = "29"
                                        };

                                        var JsonDetail = JsonConvert.SerializeObject(result, Formatting.Indented);

                                        try
                                        {
                                            string WEBSERVICE_URLACk = "https://www.ppe.nsws.gov.in/gateway/user/org/ackPanDetailsFromNsws";
                                            var webRequestAck = System.Net.WebRequest.Create(WEBSERVICE_URLACk);

                                            if (webRequestAck != null)
                                            {
                                                webRequestAck.Method = "POST"; // Change to POST
                                                webRequestAck.Timeout = 20000;
                                                webRequestAck.ContentType = "application/json";
                                                webRequestAck.Headers["Authorization"] = "Bearer " + token;

                                                // Convert JSON string to byte array
                                                byte[] byteArray = Encoding.UTF8.GetBytes(JsonDetail);

                                                // Set content length
                                                webRequestAck.ContentLength = byteArray.Length;

                                                // Write JSON data to request body
                                                using (Stream dataStream = webRequestAck.GetRequestStream())
                                                {
                                                    dataStream.Write(byteArray, 0, byteArray.Length);
                                                }

                                                LogErrorFile.LogData(webRequestAck.ToString());

                                                try
                                                {
                                                    // Get response
                                                    using (WebResponse responseAck = webRequestAck.GetResponse())
                                                    {
                                                        // Read response
                                                        using (Stream responseStreamAck = responseAck.GetResponseStream())
                                                        {
                                                            StreamReader readerAck = new StreamReader(responseStreamAck, Encoding.UTF8);
                                                            string responseJsonAck = readerAck.ReadToEnd();
                                                            LogErrorFile.LogData("ackPanDetailsFromNsws Response : " +  responseJsonAck);
                                                            Console.WriteLine("ackPanDetailsFromNsws Response : " + responseJsonAck);

                                                            if (responseJsonAck.Contains("success"))
                                                            {
                                                                Console.WriteLine("Acknowledgement Successful");
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (WebException ex)
                                                {
                                                    LogErrorFile.LogData("Error response Acknowledgement : " + ex.Message);

                                                    // Handle exception and log error response
                                                    if (ex.Response != null)
                                                    {
                                                        using (WebResponse errorResponse = ex.Response)
                                                        {
                                                            using (Stream errorStream = errorResponse.GetResponseStream())
                                                            {
                                                                StreamReader reader1 = new StreamReader(errorStream, Encoding.UTF8);
                                                                string errorText = reader1.ReadToEnd();
                                                                LogErrorFile.LogData("Error response Acknowledgement: " + errorText);
                                                                Console.WriteLine("Error response Acknowledgement: " + errorText);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (WebException ex)
                                        {
                                            LogErrorFile.LogData("ackPanDetailsFromNsws Error response: " + ex.Message);
                                            // Handle exception
                                            if (ex.Response != null)
                                            {
                                                using (WebResponse errorResponse = ex.Response)
                                                {
                                                    using (Stream errorStream = errorResponse.GetResponseStream())
                                                    {
                                                        StreamReader reader1 = new StreamReader(errorStream, Encoding.GetEncoding("utf-8"));
                                                        string errorText = reader1.ReadToEnd();
                                                        LogErrorFile.LogData(" ackPanDetailsFromNsws Error response Acknowledgement: " + errorText);
                                                        Console.WriteLine("ackPanDetailsFromNsws Error response Acknowledgement: " + errorText);
                                                    }
                                                }
                                            }
                                        }
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
                                LogErrorFile.LogData("getPanDetailsFromNsws Error response: " +  errorText);
                                Console.WriteLine("getPanDetailsFromNsws Error response: " + errorText);
                            }
                        }
                    }
                }



            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }


        string WebUrl = "https://www.ppe.nsws.gov.in/gateway-sec/form-builder-sec/user-approval/saveStateUnifiedApprovals";

        try
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(WebUrl);
            webRequest.Method = "POST";
            webRequest.Timeout = 20000;
            webRequest.ContentType = "application/json";
            // Uncomment the line below if you need to add an Authorization header
            //webRequest.Headers.Add("Authorization", "Bearer your_access_token");
            webRequest.Headers["Authorization"] = "Bearer " + token;
            // Create the payload object
            var approvals = new List<Approval>
{
    //new Approval
    //{
    //    appliedOn = "1710848695",
    //    approvalName = "Building Plan Approval from IALA/TSIIC",
    //    approvalStatus = "I",
    //    licenseId = "S009_D010_A0001",
    //    stateId = "29",
    //    swsId = "SW7150889414",
    //    approvalDate = "1733333930"
    //}
   //,
   new Approval
    {
        appliedOn = "1733746836",
        approvalName = "NOC from Forest Department",
        approvalStatus = "I",
        licenseId = "S009_D006_A0001",
        stateId = "29",
        swsId = "SW0121024748",
        approvalDate = "1733746836"
    }
};

            // Serialize the object to JSON
            //var jsonPayload = JsonConvert.SerializeObject(new List<Approval> { approval });
            var Json = JsonConvert.SerializeObject(approvals);
            LogErrorFile.LogData("Input : " + Json); // Log the response
            // Write the JSON payload to the request stream
            using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
            {
                streamWriter.Write(Json);
                streamWriter.Flush();
                LogErrorFile.LogData("saveStateUnifiedApprovals Input :  " + Json); // Log the response
            }

            // Get the response
            using (var response = (HttpWebResponse)webRequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = reader.ReadToEnd();
                    LogErrorFile.LogData("saveStateUnifiedApprovals Response :  " + responseText); // Log the response
                    Console.WriteLine(responseText);   // Print the response
                }
            }
        }
        catch (WebException ex)
        {
            // Handle HTTP errors
            if (ex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)ex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var errorText = reader.ReadToEnd();
                        LogErrorFile.LogData("saveStateUnifiedApprovals Response Error1  :" + errorText); // Log the error response
                        Console.WriteLine(errorText);   // Print the error response
                    }
                }
            }
            else
            {
                LogErrorFile.LogData("saveStateUnifiedApprovals Response Error2  :" +  ex.Message); // Log the exception message
                Console.WriteLine(ex.Message);   // Print the exception message
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            LogErrorFile.LogData("saveStateUnifiedApprovals Response Error3  :" +  ex.Message); // Log the exception message
            Console.WriteLine("saveStateUnifiedApprovals Response Error4  :" +  ex.Message);   // Print the exception message
        }

        string WebUrlpushDocument = "https://ppe-api.nsws.gov.in/nsws_document/pushDocument";

        var boundary = "----BoundaryString";
        var pushrequest = (HttpWebRequest)WebRequest.Create(WebUrlpushDocument);
        pushrequest.Method = "POST";
        pushrequest.ContentType = "multipart/form-data; boundary=" + boundary;
        pushrequest.Headers.Add("api-key", "Min1@PD02");
        pushrequest.Headers.Add("access-id", "MIN_TEST_0");
        pushrequest.Headers.Add("access-secret", "MintesT@1234");

        // Request payload
        string jsonPayload = "{\"documentId\":\"MDOC000099\",\"documentName\":\"License Certificate\",\"approvalId\":\"SW0121024748-S009_D006_A0001-1733746836\",\"swsId\":\"SW0121024748\",\"investorReqId\":\"339130\",\"mnstryDprtmntId\":\"S009_D006_A0001\"}";
        string filePath = "G:/TS-iPASSFinal/OfflineApprovals/147882/HMDA/Approved Letter.pdf";
        //"https://dpms.tsiic.telangana.gov.in:443/UploadedFiles/Proposal/3073/2024/NOV/ADCR_1322_2024/New/SignedFiles/BPO1_IIC_1246_2024.pdf"; // Replace with actual file path
        string fileName = Path.GetFileName(filePath);

        using (var stream = pushrequest.GetRequestStream())
        {
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            byte[] newLineBytes = Encoding.ASCII.GetBytes("\r\n");

            // File Part
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string fileHeader = "Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream\r\n\r\n";
            byte[] fileHeaderBytes = Encoding.UTF8.GetBytes(fileHeader);
            stream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
            byte[] fileData = File.ReadAllBytes(filePath);
            stream.Write(fileData, 0, fileData.Length);

            // JSON Part
            stream.Write(newLineBytes, 0, newLineBytes.Length);
            stream.Write(boundaryBytes, 0, boundaryBytes.Length);
            string jsonHeader = "Content-Disposition: form-data; name=\"requestJson\"\r\nContent-Type: application/json\r\n\r\n";
            byte[] jsonHeaderBytes = Encoding.UTF8.GetBytes(jsonHeader);
            stream.Write(jsonHeaderBytes, 0, jsonHeaderBytes.Length);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonPayload);
            stream.Write(jsonBytes, 0, jsonBytes.Length);

            // Closing Boundary
            byte[] closingBoundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            stream.Write(closingBoundaryBytes, 0, closingBoundaryBytes.Length);
        }

        try
        {
            using (var response = (HttpWebResponse)pushrequest.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseText = reader.ReadToEnd();
                    // ApprovalCertificate = responseText;
                    LogErrorFile.LogData("pushDocument Response: " + responseText);
                    Console.WriteLine("pushDocument Response: " + responseText);
                    JObject jsonObject = JObject.Parse(responseText);

                    // Extract "response" object
                    JToken responseToken = jsonObject["response"];
                    if (responseToken != null && responseToken["contentId"] != null)
                    {
                        ApprovalCertificate = responseToken["contentId"].ToString();
                    }
                    //var jsonObject = JObject.Parse(responseText);
                    //string contentId = jsonObject["response"]?["contentId"]?.ToString();
                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)ex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string errorText = reader.ReadToEnd();
                        Console.WriteLine("Error: " + errorText);
                        LogErrorFile.LogData("pushDocument Error: " + errorText);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: " + ex.Message);
                LogErrorFile.LogData("pushDocument Error: " + ex.Message);
            }
        }

        string WebUrlUpdateLicenseStatus = "https://www.ppe.nsws.gov.in/gateway-sec/form-builder-sec/user-approval/updateStateUnifiedApprovalsByLicenseReqId";

        try
        {
            var webRequestUpdate = (HttpWebRequest)WebRequest.Create(WebUrlUpdateLicenseStatus);
            webRequestUpdate.Method = "POST";
            webRequestUpdate.Timeout = 20000;
            webRequestUpdate.ContentType = "application/json";
            // Uncomment the line below if you need to add an Authorization header
            //webRequestUpdate.Headers.Add("Authorization", "Bearer your_access_token");
            webRequestUpdate.Headers["Authorization"] = "Bearer " + token;
            // Create the payload object
            var UpdateLicenseStatusobj = new List<UpdateLicenseStatus>
{
    //new Approval
    //{
    //    appliedOn = "1710848695",
    //    approvalName = "Building Plan Approval from IALA/TSIIC",
    //    approvalStatus = "I",
    //    licenseId = "S009_D010_A0001",
    //    stateId = "29",
    //    swsId = "SW7150889414",
    //    approvalDate = "1733333930"
    //}
   //,
   new UpdateLicenseStatus
    {
        approvalCertificate = ApprovalCertificate,// "SW7150889414-MDOC000099-#DFLT#-$ORGID$-2",
        approvalStatus  = "A",
        approvalSubStatus  = "The request is approved by first level authority, Payment pending",
        licenseReqId = "SW0121024748-S009_D006_A0001-1733746836"

    }
};

            // Serialize the object to JSON
            //var jsonPayload = JsonConvert.SerializeObject(new List<Approval> { approval });
            var json = JsonConvert.SerializeObject(UpdateLicenseStatusobj);
            LogErrorFile.LogData("updateStateUnifiedApprovalsByLicenseReqId Input : " + json); // Log the response
            // Write the JSON payload to the request stream
            using (var streamWriter = new StreamWriter(webRequestUpdate.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            // Get the response
            using (var response = (HttpWebResponse)webRequestUpdate.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var responseText = reader.ReadToEnd();
                    LogErrorFile.LogData("updateStateUnifiedApprovalsByLicenseReqId Response : " + responseText); // Log the response
                    Console.WriteLine(responseText);   // Print the response
                }
            }
        }
        catch (WebException ex)
        {
            // Handle HTTP errors
            if (ex.Response != null)
            {
                using (var errorResponse = (HttpWebResponse)ex.Response)
                {
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        var errorText = reader.ReadToEnd();
                        LogErrorFile.LogData(errorText); // Log the error response
                        Console.WriteLine(errorText);   // Print the error response
                    }
                }
            }
            else
            {
                LogErrorFile.LogData(ex.Message); // Log the exception message
                Console.WriteLine(ex.Message);   // Print the exception message
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            LogErrorFile.LogData(ex.Message); // Log the exception message
            Console.WriteLine(ex.Message);   // Print the exception message
        }

    }

    public int InsertNSWSDashboardResponseOutput(CompanyInfo CompanyVO)
    {
        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand("USP_INSERT_NSWSDASHBOARD", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PanNumber", Convert.ToString(CompanyVO.PanNumber));
            cmd.Parameters.AddWithValue("@NameAsPerPan", Convert.ToString(CompanyVO.NameAsPerPan));
            cmd.Parameters.AddWithValue("@GstIn", Convert.ToString(CompanyVO.GstIn));
            cmd.Parameters.AddWithValue("@CinNumber", CompanyVO.CinNumber);
            cmd.Parameters.AddWithValue("@SwsId", CompanyVO.SwsId);
            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            valid = (Int32)cmd.Parameters["@Valid"].Value;

            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
        return valid;
    }
    public int UpdateAckNSWSDashboard(string SWSID, string PANNO, string AckStatusCode, string AckMsg, string AckResponse, string Valid)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_NSWSDASHBOARD_ACKNOWLEDGEMENT";

        if (SWSID == "" || SWSID == null)
            com.Parameters.Add("@SWSID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SWSID", SqlDbType.VarChar).Value = SWSID.Trim();

        if (PANNO == "" || PANNO == null)
            com.Parameters.Add("@PANNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PANNO", SqlDbType.VarChar).Value = PANNO.Trim();

        if (AckStatusCode == "" || AckStatusCode == null)
            com.Parameters.Add("@AckStatusCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckStatusCode", SqlDbType.VarChar).Value = AckStatusCode.Trim();

        if (AckResponse == "" || AckResponse == null)
            com.Parameters.Add("@AckResponse", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckResponse", SqlDbType.VarChar).Value = AckResponse.Trim();

        if (AckMsg == "" || AckMsg == null)
            com.Parameters.Add("@AckMsg", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AckMsg", SqlDbType.VarChar).Value = AckMsg.Trim();

        if (Valid == "" || Valid == null)
            com.Parameters.Add("@Valid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Valid", SqlDbType.VarChar).Value = Valid.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetNSWSDashboardUsers()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_NSWSDASHBOARDUSERS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

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

