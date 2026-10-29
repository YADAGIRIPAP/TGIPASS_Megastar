using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Configuration;

public partial class UI_TSiPASS_KotakPageLegalVerification : System.Web.UI.Page
{

    Legalverify Objverify = new Legalverify();
    CCACrypto ccaCrypto = new CCACrypto();
    string workingKey = "9B383382630D206B91CCF862546AF22A";//"9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";// "http://www.localhost:5518";//"http://ipass.telangana.gov.in";
    public string strMerchantId = "185458";
    public string strEncRequest = "";
    public string strAccessCode = "AVHE79FG49CL98EHLC";//"AVHE79FG49CL98EHLC";// put the access key in the quotes provided here.


    General objgen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["UID_no"] != null && Session["onlinetransId"].ToString() != null)
            {
                DataSet dspaydtls = new DataSet();
                string Billerid = "COITS"; // "COITS";
                string CustomerID = Session["UID_no"].ToString();
                string Totalamount = Session["Amount"].ToString();//"1.00"; //
                string TSipassOrderNumber = Session["onlinetransId"].ToString();
                string ApplicationType = "LEGAL";
                string additionalPayment = "";
                if (Session["AdditionalPayment"] != null)
                {
                    additionalPayment = Session["AdditionalPayment"].ToString().Trim();
                }
                if (additionalPayment == "")
                {
                    additionalPayment = "NA";
                }
                dspaydtls = Objverify.GetEnterprinerpaymentDtlsLEGAL(CustomerID, TSipassOrderNumber, additionalPayment);
                string Departmentdetails = "";
                string Questionaireid = "";
                string MobileNo = "";
                string Email = "";
                if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                {
                    Departmentdetails = dspaydtls.Tables[0].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                    Questionaireid = dspaydtls.Tables[0].Rows[0]["Questionnaireid"].ToString();
                    MobileNo = dspaydtls.Tables[0].Rows[0]["MobileNumber"].ToString();
                    Email = dspaydtls.Tables[0].Rows[0]["Email"].ToString();
                    //billing_name.Value = dspaydtls.Tables[0].Rows[0]["INDUSTRYNAME"].ToString();
                    //billing_address.Value = dspaydtls.Tables[0].Rows[0]["ADDRESS"].ToString();
                    //billing_city.Value = dspaydtls.Tables[0].Rows[0]["CITY"].ToString();
                    //billing_state.Value = "telangana";
                    //billing_zip.Value = dspaydtls.Tables[0].Rows[0]["PINCODE"].ToString();
                    //billing_country.Value = "India";
                    billing_tel.Value = dspaydtls.Tables[0].Rows[0]["MobileNumber"].ToString();
                    billing_email.Value = dspaydtls.Tables[0].Rows[0]["Email"].ToString();
                }
                //billing_name.Value = dspaydtls.Tables[0].Rows[0]["INDUSTRYNAME"].ToString();
                //billing_address.Value = dspaydtls.Tables[0].Rows[0]["ADDRESS"].ToString();
                //billing_city.Value = dspaydtls.Tables[0].Rows[0]["CITY"].ToString();
                //billing_state.Value = "telangana";
                //billing_zip.Value = dspaydtls.Tables[0].Rows[0]["PINCODE"].ToString();
                //billing_country.Value = "India";
                //billing_tel.Value = dspaydtls.Tables[0].Rows[0]["MobileNumber"].ToString();
                //billing_email.Value = dspaydtls.Tables[0].Rows[0]["Email"].ToString();

                amount.Value = Totalamount;
                //tid.Value = TSipassOrderNumber;
                merchant_id.Value = strMerchantId;
                order_id.Value = CustomerID;
                merchant_param1.Value = Questionaireid;
                merchant_param2.Value = TSipassOrderNumber;
                merchant_param3.Value = ApplicationType;
                merchant_param4.Value = Departmentdetails;
                merchant_param5.Value = additionalPayment;
                //string ReturnURL = "http://120.138.9.236/tsipasstest/TSHOME.ASPX";// "https://ipass.telangana.gov.in/UI/TSiPASS/BilldeskPaymentResponse.aspx";

                string msg = "";
                //String data = Billerid + "|" + TSipassOrderNumber + "|NA|" + Totalamount + "|NA|NA|NA|INR|NA|R|coits|NA|NA|F|" + Questionaireid + "|" + CustomerID + "|" + ApplicationType + "|" + Departmentdetails + "|" + additionalPayment + "|" + MobileNo + "|" + Email + "|" + ReturnURL;

                msg = "";
                Session["msg"] = msg;

                //mycode
                //strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);

            }
            else
            {
                Response.Redirect("../../Index.aspx");
            }
        }
    }
}