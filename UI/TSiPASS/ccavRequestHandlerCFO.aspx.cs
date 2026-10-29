using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;

public partial class UI_TSIPASS_ccavRequestHandler_aspx : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    string workingKey = "9B383382630D206B91CCF862546AF22A";//"9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";// "http://www.localhost:5518";//"http://ipass.telangana.gov.in";
    public string strMerchantId = "185458";
    public string strEncRequest = "";
    public string strAccessCode = "AVHE79FG49CL98EHLC";//"AVHE79FG49CL98EHLC";// put the access key in the quotes provided here.

    //string workingKey = "9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here 	
    //string ccaRequest = "http://ipass.telangana.gov.in";// http://ipass.telangana.gov.in";
    //public string strMerchantId = "185458";
    //public string strEncRequest = "";
    //public string strAccessCode = "AVHE79FG49CL98EHLC";// put the access key in the quotes provided here.
    protected void Page_Load(object sender, EventArgs e)
    {
        //string s = "03/08/2018 13:03:04";
        //string[] date = s.Split(' ');
        //string[] names = date[0].ToString().Split('/');
        //string ss = names[0].ToString() + "/" + names[1].ToString() + "/" + names[2].ToString();
        if (!IsPostBack)
        {
            foreach (string name in Request.Form)
            {
                if (name != null)
                {
                    if (!name.StartsWith("_"))
                    {
                        ccaRequest = ccaRequest + name + "=" + HttpUtility.UrlEncode(Request.Form[name]) + "&";
                        /* Response.Write(name + "=" + Request.Form[name]);
                          Response.Write("</br>");*/
                    }
                }
            }
            strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);

            //Response.Redirect("https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction");
            //strMerchantId = Request.Form["merchant_id"].ToString();
        }

    }
}