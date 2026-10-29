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
public partial class UI_TSiPASS_frmKotakReversalResponseTokenTest : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();
    string sonlinetrnsNo;
    HttpClient HTTP_ClientN = new HttpClient();
    protected void Page_Load(object sender, EventArgs e)
    {

        String decrypted = DecryptData("863H8WF2zwEiVc6WcGROHhB15aHG6XIuFyEaTaUh21BxMEfEOQIg316Ud+n+M1zUg0WX+SHB1eAq34iZO+G6Us4ghUvQ+5jZeKaQZwPPREdYq8ivToVl/cyQYo7KpS2EB6rVIiRCdmFBNQwQrCg8ECDVGaJ+ZbAHQeJgSqTE732Zb7yY1x0ey7CPZqG0zcUgJbx5LMeh5IUXmV6Wh0PzkaSKoj4kgKsY1RyEXeojT726mF4ovlGCcHccSpCtc9FAQPspEY5dIxa4RWBHPG4Xmj6N0S+535nLTZ+ufvSs4CT0GFKukGPLDYrX7BuFoWRLxSFPNHllLcaEEowwsKddEpKZ4DevozOgIe1H/qk17BNDGSyaH/6PEF0pjKgk4xCCVmH0nIgcHhATLXE3F4C4cXBgVz6W4eAT1+l4mpGotkdFM1Go0sqqKQoXUMO+wNc7kb7Heb3ksc0AhC+3XIzWhytYNXsK0KGqGkPryKYnFZRIEmwqEOQ5zdtYWhTR/NJRnP+lFgr/peeXZiMOQrNxP3uR1sqQ5rnkOeBc4DhawFjAT78CRm/Yg5IGvQyK8QfEqvATAXj3sQTsfowD6/mn3K8cOM1a34EfEqJqAlnIVBNZ2rcNgzUtSycj8k5CI/RU", "80df547a8f0a402ead165f7f2798956d");
        GetReversalRequest(decrypted);

    }


    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string kotaktoken = "";
            string grant_type = "client_credentials";
            string client_id = "l7xxfe62b490c5d94bfabd444fd81e0542d1";
            string client_secret = "80df547a8f0a402ead165f7f2798956d";
            string Content_Type = "application/x-www-form-urlencoded";

            string RequestStringtoken =
                "grant_type=" + grant_type + "&client_id=" + client_id + "&client_secret=" + client_secret;

            string GetAuthCode_APIUrl = "https://apigwuat.kotak.com:8443/auth/oauth/v2/token";

            HttpContent inputContent = new StringContent(RequestStringtoken, Encoding.UTF8, Content_Type);
            HttpResponseMessage Response_Obj = HTTP_ClientN.PostAsync(GetAuthCode_APIUrl, inputContent).Result;
            if (Response_Obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject Obj_Json = JObject.Parse(Response_Obj.Content.ReadAsStringAsync().Result) as JObject;
                List<AuthData> Obj_ParseAuthData = parseAuthDataToList(Obj_Json);

                kotaktoken = Obj_ParseAuthData[0].access_token;
            }


            //HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigwuat.kotak.com:8443/cms_generic_service");
            //HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigw.kotak.com:8443/cms_generic_service?apikey=l7xx48840f4c6a6c4ce88824a4fdbda07fa9");

            HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigwuat.kotak.com:8443/v1/cms/rev");
            requestreversal.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
            requestreversal.PreAuthenticate = true;
            requestreversal.Headers.Add("Authorization", "Bearer " + kotaktoken);
            requestreversal.Method = "POST";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string RequestStringReversal = Reversal(txtordernumber.Text.Trim(), "THRSTRAVEL", txtdate.Text.Trim());//("Split20181102123553", "TSIPASS", "2018-11-02");
                                                                                                                   //Logfile(ConfigPath, "CallPayment Request : " + RequestString);

            String data = RequestStringReversal; /*request packet needs to be entered here*/
            String key = "80df547a8f0a402ead165f7f2798956d";//key 
            String encrypted = EncryptData(data, key);
            GetReversalRequest(encrypted);
            //                int outputpcb = UpdateKotakSplitPayment(txtordernumber.Text.Trim(), "", "", Session["uid"].ToString(), "",
            //"", "Y", "", "", "", "");

            byte[] byteArrayReversal = Encoding.UTF8.GetBytes(encrypted);
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
                        String decrypted = DecryptData(ServiceResult, "80df547a8f0a402ead165f7f2798956d");
                       // GetReversalRequest(decrypted);
                        GetReversalResponse(decrypted);
                    }
                    catch (Exception ex)
                    {

                    }
                    string ReversalResponse = ""; string ReversalOutputCode = ""; string ReversalPaymentDate = ""; string ReversalReqid = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(ServiceResult.ToString());
                    var items = xmlDoc.GetElementsByTagName("ns0:UTR");
                    foreach (var item in items)
                    {
                        ReversalResponse = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                        //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    }
                    var items1 = xmlDoc.GetElementsByTagName("ns0:Status_Code");
                    foreach (var item in items1)
                    {
                        ReversalOutputCode = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                        //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    }
                    var items2 = xmlDoc.GetElementsByTagName("ns0:Date_Post");
                    foreach (var item in items2)
                    {
                        ReversalPaymentDate = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                        //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    }
                    var items3 = xmlDoc.GetElementsByTagName("ns0:Req_Id");
                    foreach (var item in items3)
                    {
                        ReversalReqid = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                        //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    }

                    int Reversaloutput = UpdateKotakSplitPayment(ReversalReqid, "", "", Session["uid"].ToString(), "",
 "", "", ReversalOutputCode, ReversalResponse, ReversalPaymentDate, "");
                    success.Visible = true;
                    lblmsg.Text += ServiceResult;
                    lblmsg.Visible = true;
                    //ReturnResult = ServiceResult.ToString();
                    //Logfile(ConfigPath, "CallPayment Response : " + ReturnResult);
                }
            }
        }

        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg.Text += ex.Message;
            lblmsg.Visible = true;
            GetReversalResponse(ex.ToString());
            //Logfile(ConfigPath, "Error In CallPayment : " + ex.ToString());
            //RemitError = true;
        }
    }

    public static string Reversal(string ArgregId, string ArgClientCode, string ArgPaymentDt)
    {
        string RequestReversal = "";
        RequestReversal = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        //RequestReversal += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:pay=\"http://www.kotak.com/schemas/CMS_Generic/Payment_Request.xsd\">";
        RequestReversal += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:rev=\"http://www.kotak.com/schemas/CMS_Generic/Reversal_Request.xsd\">";
        RequestReversal += " <soap:Header/>";
        RequestReversal += " <soap:Body>";
        RequestReversal += "      <rev:Reversal>";
        RequestReversal += "  <rev:Header>";
        RequestReversal += "    <rev:Req_Id>" + ArgregId + "</rev:Req_Id>";
        RequestReversal += "    <rev:Msg_Src>" + ArgregId + "</rev:Msg_Src>";
        RequestReversal += "    <rev:Client_Code>" + ArgClientCode + "</rev:Client_Code>";
        RequestReversal += "    <rev:Date_Post>" + ArgPaymentDt + "</rev:Date_Post>";
        RequestReversal += "  </rev:Header>";
        RequestReversal += "  <rev:Details>";
        //RequestReversal += "     <!--Zero or more repetitions:-->";
        RequestReversal += "     <rev:Msg_Id>" + ArgregId + "</rev:Msg_Id>";
        RequestReversal += "   </rev:Details>";
        RequestReversal += "  </rev:Reversal>";
        RequestReversal += "  </soap:Body>";
        RequestReversal += " </soap:Envelope>";
        return RequestReversal;
    }

    public void GetReversalRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITREVERSALREQUEST", con.GetConnection);
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

    public void GetReversalResponse(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SPLITREVERSALSPONSE", con.GetConnection);
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

    public int UpdateKotakSplitPayment(string SplitOnlineOrderNo, string Total_Amount, string deptid, string Created_by, string PaymentResponse,
      string PaymentOutputCode, string ReversalRequestFlag, string ReversalRepose, string ReversaTransactionno, string Reversalupdatedate,
       string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPDATE_KotakSplit_PaymentDtls";

        if (SplitOnlineOrderNo == "" || SplitOnlineOrderNo == null)
            com.Parameters.Add("@SplitOnlineOrderNo ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SplitOnlineOrderNo", SqlDbType.VarChar).Value = SplitOnlineOrderNo.Trim();

        if (Total_Amount == null)
            com.Parameters.Add("@Total_Amount ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Total_Amount", SqlDbType.VarChar).Value = Total_Amount;

        if (deptid == "" || deptid == null)
            com.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = deptid.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (PaymentResponse == "" || PaymentResponse == null)
            com.Parameters.Add("@PaymentResponse", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentResponse", SqlDbType.VarChar).Value = PaymentResponse.Trim();

        if (PaymentOutputCode == "" || PaymentOutputCode == null)
            com.Parameters.Add("@PaymentOutputCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentOutputCode", SqlDbType.VarChar).Value = PaymentOutputCode.Trim();

        if (ReversalRequestFlag == "" || ReversalRequestFlag == null)
            com.Parameters.Add("@ReversalRequestFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversalRequestFlag", SqlDbType.VarChar).Value = ReversalRequestFlag.Trim();

        if (ReversalRepose == "" || ReversalRepose == null)
            com.Parameters.Add("@ReversalRepose", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversalRepose", SqlDbType.VarChar).Value = ReversalRepose.Trim();

        if (ReversaTransactionno == "" || ReversaTransactionno == null)
            com.Parameters.Add("@ReversaTransactionno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReversaTransactionno", SqlDbType.VarChar).Value = ReversaTransactionno.Trim();

        if (Reversalupdatedate == "" || Reversalupdatedate == null)
            com.Parameters.Add("@Reversalupdatedate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reversalupdatedate", SqlDbType.VarChar).Value = Reversalupdatedate.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VALID", SqlDbType.VarChar).Value = output.Trim();

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

    public static string EncryptData(string textData, string Encryptionkey)
    {
        RijndaelManaged objrij = new RijndaelManaged();
        objrij.Mode = CipherMode.CBC;
        objrij.Padding = PaddingMode.PKCS7;
        byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
        byte[] IV = new byte[16];
        objrij.Key = passBytes;


        byte[] textData1 = Encoding.UTF8.GetBytes(textData);
        byte[] textDataByte = new byte[textData1.Length + 16];
        Array.Copy(IV, 0, textDataByte, 0, 16);
        Array.Copy(textData1, 0, textDataByte, 16, textData1.Length);

        ICryptoTransform objtransform = objrij.CreateEncryptor();
        return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
    }

    public static string DecryptData(string EncryptedText, string Encryptionkey)
    {
        RijndaelManaged objrij = new RijndaelManaged();
        objrij.Mode = CipherMode.CBC;
        objrij.Padding = PaddingMode.PKCS7;
        byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
        byte[] passBytes = Encoding.UTF8.GetBytes(Encryptionkey);
        byte[] IV = new byte[16];
        Array.Copy(encryptedTextByte, 0, IV, 0, IV.Length);
        objrij.Key = passBytes;
        objrij.IV = IV;
        byte[] dec = new byte[encryptedTextByte.Length - 16];
        Array.Copy(encryptedTextByte, 16, dec, 0, dec.Length);


        byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(dec, 0, dec.Length);
        return Encoding.UTF8.GetString(TextByte);
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