using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using CCA.Util;
using System.Collections.Specialized;
using System.Xml;

public partial class UI_TSiPASS_frmKotakNotUpdatedXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            string accessCode = "AVHE79FG49CL98EHLC";//from avenues
            string workingKey = "9B383382630D206B91CCF862546AF22A";// from avenues

            string orderStatusQueryXml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><Order_Status_Query order_no=\""+txtuidno.Text.Trim()+"\" reference_no=\""+txtccavenuerefno.Text.Trim()+"\"></Order_Status_Query>";
            string encXml = "";

            string queryUrl = "https://login.ccavenue.com/apis/servlet/DoWebTrans";

            CCACrypto ccaCrypto = new CCACrypto();
            encXml = ccaCrypto.Encrypt(orderStatusQueryXml, workingKey);

            // make query for the status of the order to ccAvenues change the command param as per your need
            string authQueryUrlParam = "enc_request=" + encXml + "&access_code=" + accessCode + "&command=orderStatusTracker&request_type=XML&response_type=XML&version=1.1";

            // Url Connection
            String message = postPaymentRequestToGateway(queryUrl, authQueryUrlParam);
            //Response.Write(message);
            NameValueCollection param = getResponseMap(message);
            String status = "";
            String encResXML = "";
            if (param != null && param.Count == 2)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    if ("status".Equals(param.Keys[i]))
                    {
                        status = param[i];
                    }
                    if ("enc_response".Equals(param.Keys[i]))
                    {
                        encResXML = param[i];
                        //Response.Write(encResXML);
                    }
                }
                if (!"".Equals(status) && status.Equals("0"))
                {
                    String ResXml = ccaCrypto.Decrypt(encResXML, workingKey);
                    Response.Write(ResXml);
                    string xml = "<NewDataSet>" + ' ' + ResXml + ' ' + "</NewDataSet>";

                    //XmlDataDocument dco = new XmlDataDocument();
                    //dco.DocumentElement
                    //dco.LoadXml(xml);
                    //StringReader str = new StringReader(xml);
                    Response.Write(xml);
                }
                else if (!"".Equals(status) && status.Equals("1"))
                {
                    Console.WriteLine("failure response from ccAvenues: " + encResXML);
                    lblmsg.Text = encResXML;
                    lblmsg.Visible = true;
                    lblmsg0.Text = "Madhurifalse";
                    lblmsg0.Visible = true;
                
                }

            }

        }
        catch (Exception exp)
        {
            Response.Write("Exception " + exp);

        }
    }

    private string postPaymentRequestToGateway(String queryUrl, String urlParam)
    {

        String message = "";
        try
        {
            StreamWriter myWriter = null;// it will open a http connection with provided url
            WebRequest objRequest = WebRequest.Create(queryUrl);//send data using objxmlhttp object
            objRequest.Method = "POST";
            //objRequest.ContentLength = TranRequest.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";//to set content type
            myWriter = new System.IO.StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(urlParam);//send data
            myWriter.Close();//closed the myWriter object

            // Getting Response
            System.Net.HttpWebResponse objResponse = (System.Net.HttpWebResponse)objRequest.GetResponse();//receive the responce from objxmlhttp object 
            using (System.IO.StreamReader sr = new System.IO.StreamReader(objResponse.GetResponseStream()))
            {
                message = sr.ReadToEnd();
                //Response.Write(message);
            }
        }
        catch (Exception exception)
        {
            Console.Write("Exception occured while connection." + exception);
        }
        return message;

    }

    private NameValueCollection getResponseMap(String message)
    {
        NameValueCollection Params = new NameValueCollection();
        if (message != null || !"".Equals(message))
        {
            string[] segments = message.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }
        }
        return Params;
    }
}