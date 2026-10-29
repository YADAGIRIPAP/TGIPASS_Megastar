using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using KotakSplitPayment;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

public partial class UI_TSiPASS_frmCINAPINew : System.Web.UI.Page
{
    HttpClient HTTP_ClientN = new HttpClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string kotaktoken = "";
            string grant_type = "password";
            string username = "admin";
            string password = "admin";
            string Content_Type = "application/x-www-form-urlencoded";

            string RequestStringtoken =
                "grant_type=" + grant_type + "&username=" + username + "&password=" + password;

            string GetAuthCode_APIUrl = "http://182.79.115.45:8280/token";
            LogErrorFile.LogData(Convert.ToString(GetAuthCode_APIUrl));

            HttpContent inputContent = new StringContent(RequestStringtoken, Encoding.UTF8, Content_Type);
            LogErrorFile.LogData("1");

            HttpResponseMessage Response_Obj = HTTP_ClientN.PostAsync(GetAuthCode_APIUrl, inputContent).Result;
            LogErrorFile.LogData("2");

            if (Response_Obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject Obj_Json = JObject.Parse(Response_Obj.Content.ReadAsStringAsync().Result) as JObject;
                List<AuthData> Obj_ParseAuthData = parseAuthDataToList(Obj_Json);

                kotaktoken = Obj_ParseAuthData[0].access_token;
            }
            LogErrorFile.LogData("3");
            LogErrorFile.LogData(kotaktoken);
            HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("http://182.79.115.45:8280/cin/service/integration/1.0.0?");
            requestreversal.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
            requestreversal.PreAuthenticate = true;
            requestreversal.Headers.Add("Authorization", "Bearer " + kotaktoken);
            requestreversal.Method = "POST";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string RequestStringReversal = "CIN=U01100AP2018PTC107442";//("Split20181102123553", "TSIPASS", "2018-11-02");
            //                                                                                  //Logfile(ConfigPath, "CallPayment Request : " + RequestString);

            String data = RequestStringReversal; /*request packet needs to be entered here*/
           

            byte[] byteArrayReversal = Encoding.UTF8.GetBytes(data);
            LogErrorFile.LogData(data);
            requestreversal.ContentType = "application/soap+xml;charset=UTF-8;action=\"/BusinessServices/StarterProcesses/CMS_Generic_Service.serviceagent/Reversal\"";
            requestreversal.ContentLength = byteArrayReversal.Length;
            Stream dataStreamReversal = requestreversal.GetRequestStream();
            dataStreamReversal.Write(byteArrayReversal, 0, byteArrayReversal.Length);
            dataStreamReversal.Close();
            using (WebResponse Serviceres = requestreversal.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var ServiceResult = rd.ReadToEnd();
                    try
                    {
                        //String decrypted = DecryptData(ServiceResult, "e9d2a40e09d8448b925e5c479a0db1d3");
                        // GetReversalRequest(decrypted);
                        LogErrorFile.LogData(ServiceResult);
                        GetCINResponse(ServiceResult);
                    }
                    catch (Exception ex)
                    {

                    }
                    
                }
            }
        }

        catch (Exception ex)
        { 
            GetCINResponse(ex.ToString());
            LogErrorFile.LogData(ex.ToString());
            //Logfile(ConfigPath, "Error In CallPayment : " + ex.ToString());
            //RemitError = true;
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
    public List<AuthData> parseAuthDataToList(JObject obj_Json)
    {
        List<AuthData> AuthList = new List<AuthData>();
        try
        {
            JObject JO = obj_Json;
            if (JO == null)
            {
                return null;
            }

            AuthData TempDetails = new AuthData();
            foreach (JProperty prop in (JToken)JO)
            {
                string tempValue = prop.Value.ToString(); // This is not allowed 
                switch (prop.Name)
                {
                    case "access_token":
                        TempDetails.access_token = tempValue;
                        break;
                    case "token_type":
                        TempDetails.token_type = tempValue;
                        break;
                    case "expires_in":
                        TempDetails.expires_in = tempValue;
                        break;
                    case "scope":
                        TempDetails.scope = tempValue;
                        break;
                }
            }
            AuthList.Add(TempDetails);
        }
        catch (Exception ex)
        {
            //throw ex;
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "0");
            string msg = ex.Message;
            // Get stack trace for the exception with source file information
            //var st = new StackTrace(ex, true);
            // Get the top stack frame
            //var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            //var line = frame.GetFileLineNumber();

        }
        return AuthList;
    }
    public class AuthData
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
    }
}

 
