using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using CCA.Util;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class UI_TSiPASS_ccavRequestHandlerMultiplex : System.Web.UI.Page
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

            if (ccaRequest != null)
            {
                string BilldeskResponse = ccaRequest;
                try
                {
                    GetTESTVALUES(BilldeskResponse);
                }
                catch (Exception ex)
                {

                }
            }
            //Response.Redirect("https://secure.ccavenue.com/transaction/transaction.do?command=initiateTransaction");
            //strMerchantId = Request.Form["merchant_id"].ToString();
        }
    }



    public void GetTESTVALUES(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_REQUESTDATAWEBSERVISE", con.GetConnection);
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