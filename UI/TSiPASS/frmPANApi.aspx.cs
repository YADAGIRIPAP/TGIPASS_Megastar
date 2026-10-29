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
using Newtonsoft.Json;

public partial class UI_TSiPASS_frmPANApi : System.Web.UI.Page
{
    PANVO panvo = new PANVO();
    protected void Page_Load(object sender, EventArgs e)
    {
        //RootObject rootObject = new RootObject();

        //// Initialize the inputData list
        //rootObject.inputData = new List<PANVO>();

        //// Add InputData objects to the inputData list
        //rootObject.inputData.Add(new PANVO
        //{
        panvo.pan = "AADCS0823M";
        panvo.name = "SURYALATA SPINNING MILLS LIMITED";
        panvo.fathername = "";
        panvo.dob = "23/05/1983";

        //panvo.pan = "AIFPP5729A";
        //panvo.name = "ABC CORPORATION PVT. LTD.";
        //panvo.fathername = "";
        //panvo.dob = "15/08/1993";
        // });
        string JsonFrimDetails = JsonConvert.SerializeObject(panvo);
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        // string WEBSERVICE_URL = "https://121.240.36.237/TIN/PanInquiryAPIBackEnd";
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://59.163.46.2/TIN/PanInquiryBackEnd");//
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://121.240.36.237/TIN/PanInquiryAPIBackEnd");//("https://121.240.36.237/TIN/PanInquiryAPIBackEnd");//
        try
        {
            // var webRequest = System.Net.WebRequest.Create(request);
            if (request != null)
            {
                request.Method = "POST";
                request.Timeout = 20000;
                request.ContentType = "application/json";
                request.Headers["User_ID"] = "V0024301";
                request.Headers["Records_count"] = "1";
                //DateTime dateTime = DateTime.Now;
                //// Format the date and time as required
                //string formattedDateTime = dateTime.ToString("YYYY-MM-DDThh:mm:ss");//("yy -MM-dd-HH.mm.ss.ffffff");
                // Get the current date and time
                DateTime currentDateTime = DateTime.Now;
                // Format the date and time as required
                string formattedDateTime = currentDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
                string sonlinetrnsNo = "Split" + DateTime.Now.ToString("yyyyMMddHHmm").ToString();
                request.Headers["Request_time"] = formattedDateTime;
                request.Headers["Transaction_ID"] = "V0024301:"+sonlinetrnsNo;
                request.Headers["Version"] = "4";
                // string inputdata = "inputData:[" + JsonFrimDetails + "]," + "signature:" + "";
                string inputdata = "inputData:[" + JsonFrimDetails + "]";
                // Convert JSON string to byte array
                // byte[] byteArray = Encoding.UTF8.GetBytes(JsonFrimDetails);
                byte[] byteArray = Encoding.UTF8.GetBytes(inputdata);
                GetPANRequest(inputdata);
                // Set content length
                request.ContentLength = byteArray.Length;
               
                // Write JSON data to request body
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                try
                {
                    GetPANRequest(formattedDateTime + " req- " + JsonFrimDetails);
                }
                catch (Exception ex)
                {

                }
                try
                {
                    // Get response
                    using (WebResponse response = request.GetResponse())
                    {
                        // Read response
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            string responseJson = reader.ReadToEnd();//{"connectionid":"241834332402090001","status":"success"}
                            try
                            {
                                GetPANResponse("Madhuri" + responseJson);
                            }
                            catch (Exception ex)
                            {

                            }
                            Console.WriteLine("status: " + responseJson);
                            if (responseJson.Contains("success"))
                            {

                            }
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
                                GetPANResponse(errorText);
                                Console.WriteLine("Error response: " + errorText);
                            }
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {
            GetPANResponse(ex.Message);
            System.Diagnostics.Debug.WriteLine(ex.ToString());
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
public class PANVO
{
    //  string Name { get; set; }
    public string pan { get; set; }
    public string name { get; set; }
    public string fathername { get; set; }
    public string dob { get; set; }
    //public string signature { get; set; }
}
public class RootObject
{
    public List<PANVO> inputData { get; set; }
}