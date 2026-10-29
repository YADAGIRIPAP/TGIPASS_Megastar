using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http.Headers;
using System.Web;

public partial class UI_TSiPASS_MSWSPRECHECK : System.Web.UI.Page
{
    //string url = "http://localhost:8080/realms/TSIPASS_NSWS/protocol/openid-connect/";
    //string url = "http://cmsuathyd.co.in:8080/auth/realms/TSIPASS_NSWS/protocol/openid-connect/";
    //string url = "https://ipass.telangana.gov.in/auth/realms/TSIPASS_NSWS/protocol/openid-connect/";
    string url = "https://ipass.telangana.gov.in/auth/realms/test-nsws/protocol/openid-connect/";
    string accessToken = "";
    DB.DB con = new DB.DB();
    NSWSKeylcoakAttributes objNSWSKeylcoakAttributes = new NSWSKeylcoakAttributes();
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    private void CallUATToken()
    {
        try
        {
            //string clientId = "your_client_id";
            // string clientSecret = "your_client_secret";
            string apiUrl = url + "token";

            using (var client = new HttpClient())
            {
                //var collection = new List<KeyValuePair<string, string>>();
                //collection.Add(new("client_id", "userpri-client"));
                //collection.Add(new("client_secret", "WpyXnvLMdG0amzfPCFxlK1S33DqWQYEw"));
                //collection.Add(new("grant_type", "password"));
                //collection.Add(new("username", "testpolice"));
                //collection.Add(new("password", "TSIPASS123"));
                //var content = new FormUrlEncodedContent(collection); 9shj3Uk4gtRyXJ7OzeSclQsSoXBnCNQL
                //request.Content = content; zDl3Er12C3vLvdU2LA4kBaPxuSIYQJO2

                var postData = new List<KeyValuePair<string, string>>();
                //postData.Add(new KeyValuePair<string, string>("client_id", "userpri-client"));
                postData.Add(new KeyValuePair<string, string>("client_id", "token-session"));
                postData.Add(new KeyValuePair<string, string>("client_secret", "DTrdUwO5fEfg3uXS4wb7x4NnvZf5ZW4Q"));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", txtusername.Text.Trim()));
                postData.Add(new KeyValuePair<string, string>("password", txtpassword.Text.Trim()));

                var content = new FormUrlEncodedContent(postData);
                LogErrorFile.LogData(content.ToString());
                var response = client.PostAsync(apiUrl, content).Result;
                LogErrorFile.LogData(response.ToString());
                var result = response.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                LogErrorFile.LogData(result.ToString());
                accessToken = json.access_token;
                LogErrorFile.LogData("1");
                LogErrorFile.LogData(accessToken);
                // Store or use the access token as needed
            }
        }
        catch (Exception ex)
        {
            // GetCINResponse(ex.ToString());
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }
    }

    private void Callsession()
    {
        //string apiUrl = "http://103.154.75.191:8080/realms/TSIPASS_NSWS/browser-session/init?publicClient=newTest"; // Replace this with your API endpoint URL
        //string apiUrl = "https://ipass.telangana.gov.in/auth/realms/TSIPASS_NSWS/browser-session/init?publicClient=newTest"; // Replace this with your API endpoint URL
        string apiUrl = "https://ipass.telangana.gov.in/auth/realms/test-nsws/browser-session/init?publicClient=open-session";
        string bearerToken = accessToken; // Replace this with your bearer token

        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "GET"; // Set HTTP method (GET, POST, etc.)

            // Set bearer token in the Authorization header
            request.Headers["Authorization"] = "Bearer " + bearerToken;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    var cookies = response.Headers.GetValues("Set-Cookie");
                    //// Process each cookie if needed
                    //foreach (var cookie in cookies)
                    //{
                    //    setcookies(cookie);
                    //}
                    string[] setCookieValues = response.Headers.GetValues("Set-Cookie");

                    // Loop through each value in the setCookieValues array
                    foreach (string setCookieValue in setCookieValues)
                    {
                        // Parse the Set-Cookie value to extract cookie name and value
                        string[] parts = setCookieValue.Split(';');
                        string cookieKeyValue = parts[0];
                        string[] keyValue = cookieKeyValue.Split('=');
                        string cookieName = keyValue[0];
                        string cookieValue = keyValue[1];

                        // Check if the cookie already exists
                        if (Request.Cookies[cookieName] != null)
                        {
                            // If the cookie exists, update its value
                            HttpCookie existingCookie = Request.Cookies[cookieName];
                            existingCookie.Value = cookieValue;

                            // Optionally, update other properties such as expiration date
                            existingCookie.Expires = DateTime.Now.AddDays(1);

                            // Add the updated cookie back to the response
                            Response.Cookies.Add(existingCookie);
                        }
                        else
                        {
                            // If the cookie doesn't exist, create a new one
                            HttpCookie newCookie = new HttpCookie(cookieName);
                            newCookie.Value = cookieValue;

                            // Optionally, set other properties such as expiration date
                            newCookie.Expires = DateTime.Now.AddDays(1);

                            // Add the new cookie to the response
                            Response.Cookies.Add(newCookie);
                        }
                    }
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseFromServer);
                    LogErrorFile.LogData("responseFromServer");

                    LogErrorFile.LogData(responseFromServer);
                }
            }
        }
        catch (WebException ex)
        {
            // Handle web exceptions
            if (ex.Response != null)
            {
                using (WebResponse errorResponse = ex.Response)
                {
                    using (Stream dataStream = errorResponse.GetResponseStream())
                    {

                        StreamReader reader = new StreamReader(dataStream);
                        string errorFromServer = reader.ReadToEnd();
                        LogErrorFile.LogData("Success" + errorFromServer);
                    }
                }
            }
            else
            {
                LogErrorFile.LogData("errortoken" + ex.ToString());
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (txtusername.Text != "" && txtpassword.Text != "")
        {
            CallUATToken();
            string token = accessToken;
            Callsession();
            objNSWSKeylcoakAttributes = GetNSWSKeycloakData(txtusername.Text.Trim());
            var data = new
            {
                email = objNSWSKeylcoakAttributes.email.Trim(),
                entityType = objNSWSKeylcoakAttributes.entityType,
                pan = objNSWSKeylcoakAttributes.pan,
                cin = objNSWSKeylcoakAttributes.cin,
                companyName = objNSWSKeylcoakAttributes.companyName,
                 llpin = objNSWSKeylcoakAttributes.llpin
            };

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

            //U67190TN2014PTC055555 var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://dev-nsws.investindia.gov.in/auth/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-dev");
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://dev-nsws.investindia.gov.in/auth/realms/madhyam/userOrg/redirect/user/telanganaTest?clientId=portal-dev");
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://www.ppe.nsws.gov.in/auth/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-ppe");
            //("http://dev-nsws.investindia.gov.in/realms/madhyam/userOrg/redirect/user/telangana?clientId=portal-dev");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "{\"email\":\"mudavathmallesh966@gmail.com\"," +
            //                  "\"entityType\":\"3\"," +
            //                  "\"pan\":\"AHBPV4068M\"," +
            //                   "\"cin\":\"\"," +
            //                   "\"companyName\":\"M/s R.S.R  SHEDS\"}";

            //    streamWriter.Write(json);
            //}
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(data);
                streamWriter.Write(json);
                LogErrorFile.LogData("jsonRequest" + json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            LogErrorFile.LogData("jsonResponse" + httpResponse);
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                LogErrorFile.LogData("jsonresult" + result);
                string url = httpResponse.ResponseUri.ToString();
                Response.Redirect(url);
                
            }
        }
    }


    private void Callsessionold()
    {
        var clientHandler = new HttpClientHandler();
        var client = new HttpClient(clientHandler);
        client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", accessToken);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/realms/DemoTest/browser-session/init?publicClient=newTest/");//https://apigwuat.kotak.com:8443/v1/cms/pay
        request.PreAuthenticate = true;
        request.Headers.Add("Authorization", "Bearer " + accessToken);
        request.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
        request.Method = "POST";
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

        //byte[] byteArray = Encoding.UTF8.GetBytes(accessToken);
        //request.ContentType = "application/soap+xml;charset=UTF-8;action=\"/BusinessServices/StarterProcesses/CMS_Generic_Service.serviceagent/Payment\"";
        //request.ContentLength = byteArray.Length;
        //Stream dataStream = request.GetRequestStream();
        //dataStream.Write(byteArray, 0, byteArray.Length);
        //dataStream.Close();
        using (WebResponse Serviceres = request.GetResponse())
        {
            using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
            {
                var ServiceResult = rd.ReadToEnd();
                try
                {
                    LogErrorFile.LogData(ServiceResult);
                }
                catch (Exception ex)
                {

                }

            }
        }
    }

    public NSWSKeylcoakAttributes GetNSWSKeycloakData(string username)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[Sp_NSWSparameters]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (username.ToString() != "" || username.ToString() != null)
            {
                // da.SelectCommand.Parameters.Add("intUserID", SqlDbType.VarChar).Value = userid;
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = username;
            }

            da.Fill(ds);
            // return ds;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                objNSWSKeylcoakAttributes.cin = ds.Tables[0].Rows[0]["cin"].ToString();
                //RootObject data = new RootObject();

                // Fill in sample data
                //data.cinDto = new CinDto
                //{
                //    cin = ds.Tables[1].Rows[0]["CIN"].ToString(),
                //    companyName = ds.Tables[1].Rows[0]["companyName"].ToString(),
                //    companyStatus = ds.Tables[1].Rows[0]["companyStatus"].ToString(),
                //    email = ds.Tables[1].Rows[0]["emailAddress"].ToString(),
                //    financialAuditStatus = ds.Tables[1].Rows[0][""].ToString(),
                //    financialDetails = new List<FinancialDetail>
                //    {
                //        new FinancialDetail
                //        {
                //            profitLoss = ds.Tables[1].Rows[0][""].ToString(),
                //            turnOver = ds.Tables[1].Rows[0][""].ToString(),
                //            year = ds.Tables[1].Rows[0][""].ToString(),
                //        }
                //    },
                //    incorpdate = ds.Tables[1].Rows[0][""].ToString(),
                //    registeredAddress = ds.Tables[1].Rows[0][""].ToString(),
                //    rocCode = ds.Tables[1].Rows[0][""].ToString(),
                //};

                //data.directorDetailDtos = new List<DirectorDetailDto>
                //{
                //    new DirectorDetailDto
                //    {
                //        directorDetails = new DirectorDetails
                //        {
                //            contactNumber = ds.Tables[1].Rows[0][""].ToString(),
                //            din = ds.Tables[1].Rows[0][""].ToString(),
                //            name = ds.Tables[1].Rows[0][""].ToString(),
                //        },
                //        dinDetail = new DinDetail
                //        {
                //            dinName =ds.Tables[1].Rows[0][""].ToString(),
                //            dinStatus = ds.Tables[1].Rows[0][""].ToString(),
                //            dob =ds.Tables[1].Rows[0][""].ToString(),
                //            fatherName =ds.Tables[1].Rows[0][""].ToString()
                //        }
                //    }
                //};

                //// Convert object to JSON
                //string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);


                //            data.cinDto = new CinDto
                //            {
                //                cin = "L72200KA1999PLC025564",
                //                companyName = "MINDTREE LIMITED",
                //                companyStatus = "Active",
                //                email = "Subhodh.Shetty@mindtree.com",
                //                financialAuditStatus = "YES",
                //                financialDetails = new List<FinancialDetail>
                //    {
                //        new FinancialDetail
                //        {
                //            profitLoss = "11103000000.00",
                //            turnOver = "79678000000.00",
                //            year = "2021"
                //        }
                //    },
                //                incorpdate = "05/08/1999",
                //                registeredAddress = "Global Village,RVCE Post, Mysore Road BANGALORE KA 560059 IN",
                //                rocCode = "RoC-Bangalore"
                //            };

                //            data.directorDetailDtos = new List<DirectorDetailDto>
                //{
                //    new DirectorDetailDto
                //    {
                //        directorDetails = new DirectorDetails
                //        {
                //            contactNumber = "",
                //            din = "0000190097",
                //            name = "APURVA PUROHIT"
                //        },
                //        dinDetail = new DinDetail
                //        {
                //            dinName = "APURVA PUROHIT",
                //            dinStatus = "Approved",
                //            dob = "03-10-1966",
                //            fatherName = "YOGI KANWAR"
                //        }
                //    }
                //};
                //            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                //            objNSWSKeylcoakAttributes.cinData = json;
                objNSWSKeylcoakAttributes.cinData = "";
                objNSWSKeylcoakAttributes.companyName = ds.Tables[0].Rows[0]["companyName"].ToString();
                objNSWSKeylcoakAttributes.email = ds.Tables[0].Rows[0]["email"].ToString();
                objNSWSKeylcoakAttributes.entityType = ds.Tables[0].Rows[0]["entityType"].ToString();
                objNSWSKeylcoakAttributes.fullName = ds.Tables[0].Rows[0]["fullname"].ToString();
                objNSWSKeylcoakAttributes.llpin = ds.Tables[0].Rows[0]["llpin"].ToString();
                objNSWSKeylcoakAttributes.mobileNumber = ds.Tables[0].Rows[0]["mobileNumber"].ToString();
                objNSWSKeylcoakAttributes.pan = ds.Tables[0].Rows[0]["Pan"].ToString();
                objNSWSKeylcoakAttributes.postalAddress1 = ds.Tables[0].Rows[0]["postalAddress1"].ToString();
                objNSWSKeylcoakAttributes.postalAddress2 = ds.Tables[0].Rows[0]["postalAddress2"].ToString();
                objNSWSKeylcoakAttributes.postalCity = ds.Tables[0].Rows[0]["postalCity"].ToString();
                objNSWSKeylcoakAttributes.postalCountry = ds.Tables[0].Rows[0]["postalCountry"].ToString();
                objNSWSKeylcoakAttributes.postalPincode = ds.Tables[0].Rows[0]["postalPincode"].ToString();
                objNSWSKeylcoakAttributes.postalState = ds.Tables[0].Rows[0]["postalState"].ToString();
                objNSWSKeylcoakAttributes.regAddress1 = ds.Tables[0].Rows[0]["regAddress1"].ToString();
                objNSWSKeylcoakAttributes.regAddress2 = ds.Tables[0].Rows[0]["regAddress2"].ToString();
                objNSWSKeylcoakAttributes.regCity = ds.Tables[0].Rows[0]["regCity"].ToString();
                objNSWSKeylcoakAttributes.regCountry = ds.Tables[0].Rows[0]["regCountry"].ToString();
                objNSWSKeylcoakAttributes.regPincode = ds.Tables[0].Rows[0]["regPincode"].ToString();
                objNSWSKeylcoakAttributes.regState = ds.Tables[0].Rows[0]["regState"].ToString();


            }
            return objNSWSKeylcoakAttributes;
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
public class NSWSKeylcoakAttributes
{
    public string fullName { get; set; }
    public string email { get; set; }
    public string mobileNumber { get; set; }
    public string entityType { get; set; }
    public string pan { get; set; }
    public string regAddress1 { get; set; }
    public string regAddress2 { get; set; }
    public string regCountry { get; set; }
    public string regState { get; set; }
    public string regCity { get; set; }
    public string regPincode { get; set; }
    public string postalAddress1 { get; set; }
    public string postalAddress2 { get; set; }
    public string postalCountry { get; set; }
    public string postalState { get; set; }
    public string postalCity { get; set; }
    public string postalPincode { get; set; }
    public string cin { get; set; }
    public string llpin { get; set; }
    public string cinData { get; set; }
    public string companyName { get; set; }
}