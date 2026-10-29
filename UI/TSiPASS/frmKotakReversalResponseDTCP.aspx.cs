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

public partial class UI_TSiPASS_frmKotakReversalResponseDTCP : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();
    string sonlinetrnsNo;

    protected void Page_Load(object sender, EventArgs e)
    {



    }


    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {

            //HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigwuat.kotak.com:8443/cms_generic_service");
            HttpWebRequest requestreversal = (HttpWebRequest)WebRequest.Create("https://apigw.kotak.com:8443/cms_generic_service?apikey=l7xx48840f4c6a6c4ce88824a4fdbda07fa9");
            requestreversal.UserAgent = "Apache-HttpClient/4.1.1 (java 1.5)";
            requestreversal.Method = "POST";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string RequestStringReversal = Reversal(txtordernumber.Text.Trim(), "TSIPASS", txtdate.Text.Trim());//("Split20181102123553", "TSIPASS", "2018-11-02");
            //Logfile(ConfigPath, "CallPayment Request : " + RequestString);
            try
            {
                GetReversalRequest(RequestStringReversal);
                int outputpcb = UpdateKotakSplitPayment(txtordernumber.Text.Trim(), "", "", Session["uid"].ToString(), "",
"", "Y", "", "", "", "");
            }
            catch (Exception ex)
            {

            }
            byte[] byteArrayReversal = Encoding.UTF8.GetBytes(RequestStringReversal);
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
                        GetReversalResponse(ServiceResult);
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
        com.CommandText = "USP_UPDATE_KotakSplit_PaymentDtls_DTCP";

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
}