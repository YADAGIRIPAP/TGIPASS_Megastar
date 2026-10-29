using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testRest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var st = "data";
        String commonkey = "alAQ2hHZXsvr";
        String data = "0122|COITS|Bill20180124162958|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "";
        String hash = String.Empty;
        hash = GetHMACSHA256(data, commonkey);
        hash = hash.ToUpper();
        String msg = data + "|" + hash;
        Response.Write(msg);
        Response.Write("<br/><br/>");

        string WEBSERVICE_URL = "https://www.billdesk.com/pgidsk/PGIQueryController?msg="+msg+"";
        try
        {
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/x-www-form-urlencoded";

                using (System.IO.Stream s = webRequest.GetRequestStream())
                {
                  //using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(s);
                  //sw.Write(jsonData);
                }

                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        Response.Write(jsonResponse);
                        Response.Write("<br/><br/>");
                        String[] Array = jsonResponse.Split('|');
                        foreach (var re in Array)
                        {
                            Response.Write(re);
                            Response.Write("<br/>");
                        }

                        System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }

    }

    public string GetHMACSHA256(string text, string key)
    {
        UTF8Encoding encoder = new UTF8Encoding();

        byte[] hashValue;
        byte[] keybyt = encoder.GetBytes(key);
        byte[] message = encoder.GetBytes(text);

        HMACSHA256 hashString = new HMACSHA256(keybyt);
        string hex = "";

        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;
    }
}