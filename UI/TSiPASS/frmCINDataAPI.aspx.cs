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

public partial class UI_TSiPASS_frmCINDataAPI : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string WEBSERVICE_URL = "http://182.79.115.45:8280/cin/service/integration/1.0.0?CIN=U01100AP2018PTC107442";
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                try
                {
                    GetCINRequest(WEBSERVICE_URL);
                }
                catch (Exception ex)
                {

                }
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        try
                        {
                            GetCINResponse(jsonResponse);
                        }
                        catch (Exception ex)
                        {

                        }
                        System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                        if (jsonResponse.Contains("Your Transaction  successful"))
                        {

                        }
                        else
                        {
                            try
                            {
                                GetCINResponse(jsonResponse);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            try
            {
                GetCINResponse(ex.Message);
            }
            catch (Exception)
            {

            }
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    public static string Payment(string Cinno)
    {
        string RequestMsg = "";

        RequestMsg = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
        RequestMsg += "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:mca=\"http://www.mca.gov.in\">";
        RequestMsg += " <soap:Header/>";
        RequestMsg += " <soap:Body>";
        RequestMsg += "     <mca:getCINInfo>";
        RequestMsg += "             <arg0>" + Cinno + "</arg0>";
        RequestMsg += "                  </mca:getCINInfo>";
        RequestMsg += " </soap:Body>";
        RequestMsg += "</soap:Envelope>";

        return RequestMsg;
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

    void CINOldPRocedure()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mca21v3services.mca.gov.in/MCAGstIntegration/GstService/WEB-INF/wsdl/GstService.wsdl");//https://apigwuat.kotak.com:8443/v1/cms/pay
                                                                                                                                                                      //request.PreAuthenticate = true;
                                                                                                                                                                      //request.Headers.Add("Authorization", "Bearer " + kotaktoken);
                                                                                                                                                                      //request.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
                                                                                                                                                                      //request.Method = "POST";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            request.Method = "POST";
            string RequestString = Payment("U72900PN2021PTC206834");
            String data = RequestString;
            try
            {
                GetCINRequest(data);
            }
            catch (Exception ex)
            {

            }

            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            request.ContentType = "application/soap+xml;charset=UTF-8;";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var ServiceResult = rd.ReadToEnd();
                    try
                    {
                        GetCINResponse(ServiceResult);
                    }
                    catch (Exception ex)
                    {

                    }
                    string PaymentResponse = ""; string PaymentOutputCode = "";
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(ServiceResult.ToString());
                    //var items = xmlDoc.GetElementsByTagName("ns0:StatusRem");
                    //foreach (var item in items)
                    //{
                    //    PaymentResponse = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                    //    //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    //}
                    //var items1 = xmlDoc.GetElementsByTagName("ns0:StatusCd");
                    //foreach (var item in items1)
                    //{
                    //    PaymentOutputCode = ((System.Xml.XmlElement)(item)).InnerText.ToString();
                    //    //Console.WriteLine(((System.Xml.XmlElement)(item)).InnerText.ToString());
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            GetCINResponse(ex.Message);
        }
    }
}