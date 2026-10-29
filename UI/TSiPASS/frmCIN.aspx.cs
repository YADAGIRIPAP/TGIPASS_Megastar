using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

public partial class UI_TSiPASS_frmCIN : System.Web.UI.Page
{
    string accessToken = "";
    //string url = "http://182.79.115.45:8280/";
    //string url = "http://182.79.115.52:8280/";
    string url = "https://apim.mca.gov.in:8243/";
    protected void Page_Load(object sender, EventArgs e)
    { 

        if (!IsPostBack)
        {
            // Call methods to make API requests
            string cin = "ACE-0608";// "U45202TG2020PTC144407";
            CallUATTokenCIN();
            CallCINService(cin);
            CallDINService(cin);
            CallDINDetailsService("08079145");
        }
    }

    private void CallUATTokenCIN()
    {
        try
        {
            //string clientId = "your_client_id";
           // string clientSecret = "your_client_secret";
            string apiUrl = url+"token";

            using (var client = new HttpClient())
            {
                //string credentials = clientId + ":" + clientSecret;
                //byte[] credentialsBytes = Encoding.ASCII.GetBytes(credentials);
                //string base64Credentials = Convert.ToBase64String(credentialsBytes);
                // string base64Credentials = "ME4wUDBtQm1NdGVGcTNZX1c5cjdZRkxQZWswYTpwQmVWd3hzTjdJWnVfcEdKUzk1MFZoUmxjQVlh";
                string base64Credentials = "N0ZHUFV1cUZBX0NTSGF3V29sZVBmTlB2aXh3YTp5N2tfbXFOMlJtUFdBZ3J1R0Rwc0l0bW4yS0lh";

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64Credentials);

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", "admin"));
                postData.Add(new KeyValuePair<string, string>("password", "admin"));

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
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData("errortoken" + ex.ToString());
        }
    }

    private void CallCINService(string cin)
    {
        try
        {
            //string apiUrl = "http://182.79.115.45:8280/cin/service/integration/1.0.0?CIN=U01100AP2018PTC107442";
            string apiUrl =url+ "cin/service/integration/1.0.0?CIN=" +cin;
            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallCINService " + result);
                // Handle response as needed
                LogErrorFile.LogData("2");
                LogErrorFile.LogData(result);
            }

        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }

    private void CallDINService(string cin)
    {
        try
        {
            string apiUrl =url+ "din/service/integration/1.0.0?CIN=" + cin;

            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallDINService " + result);
                // Handle response as needed
                LogErrorFile.LogData("3");
                LogErrorFile.LogData(result);
            }
        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }

    private void CallDINDetailsService(string cin)
    {
        try
        {
            string apiUrl =url+ "dindetails/service/integration/1.0.0?DIN="+ cin;

            using (var client = new HttpClient())
            {
                // Set Authorization header if needed
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                var response = client.GetAsync(apiUrl).Result;

                var result = response.Content.ReadAsStringAsync().Result;
                GetCINResponse("CallDINDetailsService " + result );
                LogErrorFile.LogData("4");
                LogErrorFile.LogData(result);
                // Handle response as needed
            }
        }
        catch (Exception ex)
        {
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
        }
    }

    public void GetCINRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_CINREQUEST", con.GetConnection);
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

    public void GetCINResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_CINRESPONSE", con.GetConnection);
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