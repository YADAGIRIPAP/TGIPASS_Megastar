using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography;
using System.Data;

public partial class UI_TSiPASS_BilldeskPaymentPageCFO : System.Web.UI.Page
{
    General objgen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["UID_no"] != null && Session["onlinetransId"].ToString() != null)
                {
                    DataSet dspaydtls = new DataSet();

                    Session["BuildDeskNewUrl"] = "https://pgi.billdesk.com/pgidsk/PGIMerchantPayment";


                    string Billerid = "COITS"; // "COITS";
                    string CustomerID = Session["UID_no"].ToString();
                    // string Totalamount = "2";//Session["Amount"].ToString();//"1.00"; //
                    string Totalamount = Session["Amount"].ToString();//"1.00"; //
                    string TSipassOrderNumber = Session["onlinetransId"].ToString();
                    string ApplicationType = "CFO";
                    string additionalPayment = "";
                    if (Session["AdditionalPayment"] != null)
                    {
                        additionalPayment = Session["AdditionalPayment"].ToString().Trim();
                    }
                    if (additionalPayment == "")
                    {
                        additionalPayment = "NA";
                    }
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(CustomerID, TSipassOrderNumber, additionalPayment);
                    string Departmentdetails = "";
                    string Questionaireid = "";
                    string MobileNo = "";
                    string Email = "";
                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1)
                    if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                    {
                        Departmentdetails = dspaydtls.Tables[0].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                        Questionaireid = dspaydtls.Tables[0].Rows[0]["Questionnaireid"].ToString();
                        MobileNo = dspaydtls.Tables[0].Rows[0]["MobileNumber"].ToString();
                        Email = dspaydtls.Tables[0].Rows[0]["Email"].ToString();
                    }
                    //  string ReturnURL = "http://localhost:10389/TSIPASS/UI/TSiPASS/BilldeskPaymentResponseCFO.aspx";
                    // string ReturnURL = "http://120.138.9.236/TSIPASSTEST/UI/TSiPASS/BilldeskPaymentResponseCFO.aspx";
                    string ReturnURL = "https://ipass.telangana.gov.in/UI/TSiPASS/BilldeskPaymentResponseCFO.aspx";
                    string msg = "";


                    //String data = "MERCHANT|1000000000|NA|12.00|NA|NA|NA|INR|DIRECT|R|NA|NA|NA|F|111111111|NA|NA|NA|NA|NA|NA|NA";
                    //String data = Billerid + "|" + CustomerID + "|" + Totalamount + "|" + Questionaireid + "|" + TSipassOrderNumber + "|" + Departmentdetails + "|" + ReturnURL;

                    //MerchantID|CustomerID|NA|TxnAmount|NA|NA|NA|CurrencyType|NA|TypeField1|SecurityID|NA|NA|TypeField2|txtadditional1|txtadditional2|txtadditional3
                    //|txtadditional4|txtadditional5| txtadditional6| txtadditional7|RU

                    String data = Billerid + "|" + TSipassOrderNumber + "|NA|" + Totalamount + "|NA|NA|NA|INR|NA|R|coits|NA|NA|F|" + Questionaireid + "|" + CustomerID + "|" + ApplicationType + "|" + Departmentdetails + "|" + additionalPayment + "|" + MobileNo + "|" + Email + "|" + ReturnURL;

                    String commonkey = "alAQ2hHZXsvr";

                    String hash = String.Empty;
                    hash = GetHMACSHA256(data, commonkey);
                    hash = hash.ToUpper();

                    msg = data + "|" + hash;

                    // Console.Out.WriteLine("HMAC {0}", hash);
                    // Console.ReadKey();


                    Session["msg"] = msg;
                }
                else
                {
                    Response.Redirect("../../Index.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblMsg.Text = ex.Message;
            //Failure.Visible = true;
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