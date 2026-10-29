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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSiPASS_frmKotakPaymentFailedService : System.Web.UI.Page
{
    CCavenuvo ccavo = new CCavenuvo();
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    General objgen = new General();
    BMWClass objBMW = new BMWClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string accessCode = "AVHE79FG49CL98EHLC";//from avenues
            string workingKey = "9B383382630D206B91CCF862546AF22A";// from avenues

            ccavo.reference_no = ""; ccavo.order_no = "";
            ccavo.order_bill_tel = ""; ccavo.order_country = ""; ccavo.order_email = ""; ccavo.order_fraud_status = ""; ccavo.order_max_amount = "";
            ccavo.order_min_amount = "";
            ccavo.order_name = ""; ccavo.order_payment_type = ""; ccavo.order_type = ""; ccavo.order_currency = ""; ccavo.page_number = "";

            ccavo.from_date = "04-05-2024";
            ccavo.to_date = "05-05-2024";
            ccavo.order_status = "Shipped";
            //ccavo.order_no = "PLOT2024031259530";
           // ccavo.reference_no = "113275269231";
            var JsonFrimDetails = JsonConvert.SerializeObject(ccavo);
            string orderStatusQueryJson = JsonFrimDetails;
                //"{ \"reference_no\":\"103001198924\", \"order_no\":\"77141516\" }"; //Ex. { "reference_no":"CCAvenue_Reference_No" , "order_no":"123456"} 
            string encJson = "";

            string queryUrl = "https://login.ccavenue.com/apis/servlet/DoWebTrans";

            CCACrypto ccaCrypto = new CCACrypto();
            encJson = ccaCrypto.Encrypt(orderStatusQueryJson, workingKey);

            // make query for the status of the order to ccAvenues change the command param as per your need
            string authQueryUrlParam = "enc_request=" + encJson + "&access_code=" + accessCode + "&command=orderStatusTracker&request_type=JSON&response_type=JSON";

            // Url Connection
            String message = postPaymentRequestToGateway(queryUrl, authQueryUrlParam);
            //Response.Write(message);
            LogErrorFile.LogData(Convert.ToString(message.ToString()));
            NameValueCollection param = getResponseMap(message);
            String status = "";
            String encResJson = "";
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
                        encResJson = param[i];
                        LogErrorFile.LogData(Convert.ToString(encResJson.ToString()));
                        //Response.Write(encResXML);
                    }
                }
                if (!"".Equals(status) && status.Equals("0"))
                {
                    String ResJson = ccaCrypto.Decrypt(encResJson, workingKey);
                    //Response.Write(ResJson);
                    LogErrorFile.LogData(Convert.ToString("success" + ResJson.ToString()));
                    OrderStatusList orderStatusListnn = DigiGeneral.DigiGeneral.JsonDeserialize<OrderStatusList>(ResJson);
                    LogErrorFile.LogData(Convert.ToString("success1" + orderStatusListnn.order_Status_List.Count));
                    foreach (var order in orderStatusListnn.order_Status_List)
                    {
                        LogErrorFile.LogData("Success5");

                        DataSet dsdept = new DataSet();
                        dsdept = Checkpaymentstatus(order.order_no, order.reference_no, order.merchant_param3);
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {

                        }
                        else
                        {
                            if (order.merchant_param3 == "CFE")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")// sucess payment done.
                                {
                                    int valid = InsertUpdatepaymentdtls(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceipt.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "CFO")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();




                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtlscfo(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptCFO.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "REN")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtlsRen(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptRen.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "PLOT")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                            else
                                            {
                                                UpdateOldtransactiondetails(paymentresponseVOsobj.AdditionalInfo2_17);
                                                dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                                if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                                {
                                                    if (dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != null && dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString() != "")
                                                    {
                                                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtlsTSIIC(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptPlot.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "TE")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsTourism(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsTourism(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtlsTOURISM(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    try
                                    {
                                        //GetTESTVALUESTourismEvent(BilldeskResponse);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptTourismEvent.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "TTA")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsTravelAgent(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsTravelAgent(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtlsTravelAgent(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    //try
                                    //{
                                    //    GetTESTVALUESTRAVELAGENT(BilldeskResponse);
                                    //}
                                    //catch (Exception ex)
                                    //{

                                    //}
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptTravelAgent.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "GW")
                            {

                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();
                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsgroundwater(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = GetEnterprinerpaymentDtlsgroundwater(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);

                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtls_Groundwater(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    //try
                                    //{
                                    //    GetTESTVALUESgroundwater(BilldeskResponse);
                                    //}
                                    //catch (Exception ex)
                                    //{

                                    //}
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptGroundwater.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }

                            if (order.merchant_param3 == "BMW")
                            {
                                paymentresponseVOsobj.MerchantID_0 = "185458";
                                paymentresponseVOsobj.CustomerID_1 = order.order_no;   // UID Number
                                paymentresponseVOsobj.TxnReferenceNo_2 = order.reference_no;
                                paymentresponseVOsobj.BankReferenceNo_3 = order.order_bank_ref_no;
                                paymentresponseVOsobj.TxnAmount_4 = order.order_gross_amt;
                                paymentresponseVOsobj.BankID_5 = order.order_card_name;
                                paymentresponseVOsobj.BIN_6 = "";
                                paymentresponseVOsobj.TxnType_7 = order.payment_mode;
                                paymentresponseVOsobj.CurrencyName_8 = order.order_currncy;
                                paymentresponseVOsobj.ItemCode_9 = "";
                                paymentresponseVOsobj.SecurityType_10 = "";
                                paymentresponseVOsobj.SecurityID_11 = "";
                                paymentresponseVOsobj.SecurityPassword_12 = "";
                                string[] date = order.order_status_date_time.Split(' ');
                                string[] newdate = date[0].ToString().Split('-');
                                paymentresponseVOsobj.TxnDate_13 = newdate[1].ToString() + "/" + newdate[2].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

                                paymentresponseVOsobj.AuthStatus_14 = order.order_status;
                                paymentresponseVOsobj.SettlementType_15 = order.payment_mode;
                                paymentresponseVOsobj.AdditionalInfo1_16 = order.merchant_param1;   // Questionaireid
                                paymentresponseVOsobj.AdditionalInfo2_17 = order.merchant_param2;    // TSipassOrderNumber
                                paymentresponseVOsobj.AdditionalInfo3_18 = order.merchant_param3;   // ApplicationType
                                paymentresponseVOsobj.AdditionalInfo4_19 = order.merchant_param4;   // Departmentdetails
                                paymentresponseVOsobj.AdditionalInfo5_20 = order.merchant_param5;   //  AddtionalPayment flag
                                paymentresponseVOsobj.AdditionalInfo6_21 = "";
                                paymentresponseVOsobj.AdditionalInfo7_22 = "";
                                paymentresponseVOsobj.ErrorStatus_23 = order.order_fraud_status;
                                paymentresponseVOsobj.ErrorDescription_24 = order.order_fraud_status;
                                paymentresponseVOsobj.CheckSum_25 = "";
                                paymentresponseVOsobj.SUBMID = "";
                                paymentresponseVOsobj.Createdby = Session["uid"].ToString();

                                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                {
                                    DataSet dspaydtls = new DataSet();
                                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                    {
                                        dspaydtls = objBMW.GetEnterprinerpaymentDtlsBMW(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dspaydtls = objBMW.GetEnterprinerpaymentDtlsBMW(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                        paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                        {
                                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                        }
                                    }
                                }
                                if (paymentresponseVOsobj.AdditionalInfo5_20 == "NA")
                                {
                                    paymentresponseVOsobj.AdditionalInfo5_20 = "";
                                }
                                List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj = new List<paymendepartwisetresponseVOs>();
                                string[] deptvalues = paymentresponseVOsobj.AdditionalInfo4_19.Split('&');
                                for (int i = 0; i < deptvalues.Length; i++)
                                {
                                    string[] deptwisevalues = deptvalues[i].Split('#');
                                    paymendepartwisetresponseVOs payment = new paymendepartwisetresponseVOs();
                                    payment.Questionnaireid = deptwisevalues[0].ToString();
                                    payment.intEnterprenerid = deptwisevalues[1].ToString();
                                    payment.Departmentid = deptwisevalues[2].ToString();
                                    payment.CustomerID_1 = deptwisevalues[3].ToString();
                                    payment.DeptAmount = deptwisevalues[4].ToString();
                                    payment.intApprovalid = deptwisevalues[5].ToString();
                                    payment.TxnDate_13 = paymentresponseVOsobj.TxnDate_13;
                                    payment.TxnReferenceNo_2 = paymentresponseVOsobj.TxnReferenceNo_2;
                                    payment.BankReferenceNo_3 = paymentresponseVOsobj.BankReferenceNo_3;
                                    payment.TxnAmount_4 = paymentresponseVOsobj.TxnAmount_4;
                                    payment.BankID_5 = paymentresponseVOsobj.BankID_5;
                                    payment.Createdby = paymentresponseVOsobj.Createdby;
                                    payment.AdditionalPaymentFlag = paymentresponseVOsobj.AdditionalInfo5_20;
                                    paymendepartwisetresponseVOsobj.Add(payment);
                                    //Response.Write("payment.Questionnaireid = " + payment.Questionnaireid.ToString() + "<br>");
                                    //Response.Write("payment.intEnterprenerid = " + payment.intEnterprenerid.ToString() + "<br>");
                                    //Response.Write("payment.Departmentid = " + payment.Departmentid.ToString() + "<br>");
                                    //Response.Write("payment.CustomerID_1 = " + payment.CustomerID_1.ToString() + "<br>");
                                    //Response.Write("payment.DeptAmount = " + payment.DeptAmount.ToString() + "<br>");
                                    //Response.Write("payment.intApprovalid = " + payment.intApprovalid.ToString() + "<br>");
                                    //Response.Write("payment.TxnDate_13 = " + payment.TxnDate_13.ToString() + "<br>");
                                    //Response.Write("payment.TxnReferenceNo_2 = " + payment.TxnReferenceNo_2.ToString() + "<br>");
                                    //Response.Write("payment.BankReferenceNo_3 = " + payment.BankReferenceNo_3.ToString() + "<br>");
                                    //Response.Write("payment.TxnAmount_4 = " + payment.TxnAmount_4.ToString() + "<br>");
                                    //Response.Write("payment.BankID_5 = " + payment.BankID_5.ToString() + "<br>");
                                    //Response.Write("payment.Createdby = " + payment.Createdby.ToString() + "<br>");
                                    //Response.Write("payment.AdditionalPaymentFlag = " + payment.AdditionalPaymentFlag.ToString() + "<br>");
                                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                                }

                                if (paymentresponseVOsobj.AuthStatus_14 == "Shipped")
                                {
                                    int valid = InsertUpdatepaymentdtls_BWM(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                    if (valid == 1)
                                    {
                                        //LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                        Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                        Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                        Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptBMW.aspx';", true);
                                    }
                                }
                                else
                                {
                                    // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='HomeDashboard.aspx';", true);
                                    // Response.Redirect("HomeDashboard.aspx");
                                }
                            }
                        }
                    }
                }
                else if (!"".Equals(status) && status.Equals("1"))
                {
                   // Console.WriteLine("failure response from ccAvenues: " + encResJson);
                    LogErrorFile.LogData(Convert.ToString("failure response from ccAvenues: " + encResJson));
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

    public DataSet GetEnterprinerpaymentDtlsgroundwater(string UID, string Orderno, string AdditionalPaymentflg)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Builldesc_PaymentDtls_DESE_groundwater", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UID.Trim();
            da.SelectCommand.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = Orderno.Trim();
            da.SelectCommand.Parameters.Add("@AdditionalPaymentflg", SqlDbType.VarChar).Value = AdditionalPaymentflg.Trim();
            da.Fill(ds);
            return ds;
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

    public int InsertUpdatepaymentdtls_Groundwater(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("USP_UPDATE_Builldesc_PaymentDtls_groundwater", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_Groundwater", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public int InsertUpdatepaymentdtls(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public int InsertUpdatepaymentdtlscfo(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_CFO]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_CFO]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public int InsertUpdatepaymentdtlsRen(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_Renewal]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_Renewal]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public int InsertUpdatepaymentdtlsTSIIC(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_TSIIC]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            //if (valid == 1)
            //{
            //    foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
            //    {
            //        command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_CFO]", connection);
            //        command1.CommandType = CommandType.StoredProcedure;
            //        command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
            //        command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
            //        command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
            //        command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
            //        command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
            //        command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
            //        command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
            //        command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
            //        command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
            //        command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
            //        command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
            //        command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
            //        command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
            //        command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
            //        command1.Transaction = trans;
            //        command1.ExecuteNonQuery();
            //        valid = (Int32)command1.Parameters["@VALID"].Value;
            //    }
            //}
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public void UpdateOldtransactiondetails(string TSipassOrderNumber)
    {
        string OldTSipassOrderNumber = "";
        string NewTSipassOrderNumber = "";
        string UidNo = "";
        string PaymentStatus = "";
        DataSet ds = new DataSet();
        ds = Getchildandparentdata(TSipassOrderNumber);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            int totalrowscount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < totalrowscount; i++)
            {
                OldTSipassOrderNumber = "";
                NewTSipassOrderNumber = "";
                UidNo = "";
                PaymentStatus = "";

                OldTSipassOrderNumber = ds.Tables[0].Rows[i]["OldOnlineOrderNo"].ToString();
                NewTSipassOrderNumber = ds.Tables[0].Rows[i]["OnlineOrderNo"].ToString();
                UidNo = ds.Tables[0].Rows[i]["UIDNO"].ToString();
                UpdateNewpaymentidwitholdpaymentid(OldTSipassOrderNumber, NewTSipassOrderNumber, UidNo);
                //PaymentStatus = Cehckstatuspayment(OldTSipassOrderNumber);
                //if (PaymentStatus == "0300")
                //{
                //    UpdateNewpaymentidwitholdpaymentid(OldTSipassOrderNumber, NewTSipassOrderNumber, UidNo);
                //    callbilldeskpage(OldTSipassOrderNumber);
                //    return;
                //}
            }
        }
    }

    public DataSet Getchildandparentdata(string TSipassOrderNumber)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@OnlineOrderNo",SqlDbType.VarChar),
           };
        pp[0].Value = TSipassOrderNumber;
        Dsnew = objgen.GenericFillDs("USP_GET_OLDTRANSACTIONS_UPDATE_NEW", pp);
        return Dsnew;
    }

    public int UpdateNewpaymentidwitholdpaymentid(string oldTSipassOrderNumber, string NewTSipassOrderNumber, string UidNO)
    {
        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@oldTSipassOrderNumber",SqlDbType.VarChar),
               new SqlParameter("@NewTSipassOrderNumber",SqlDbType.VarChar),
               new SqlParameter("@UidNO",SqlDbType.VarChar),
               new SqlParameter("@Outresponse",SqlDbType.VarChar)
           };
        pp[0].Value = oldTSipassOrderNumber;
        pp[1].Value = NewTSipassOrderNumber;
        pp[2].Value = UidNO;
        pp[3].Value = "0";
        pp[3].Direction = ParameterDirection.Output;

        int valid = 0;
        valid = objgen.GenericExecuteNonQuery("USP_UPD_OldOnlineOrderNo_BILLDESC", pp);
        return valid;
    }

    public int InsertUpdatepaymentdtlsTOURISM(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_TOURISM]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_TOURISMEVENT]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public DataSet GetEnterprinerpaymentDtlsTourism(string UID, string Orderno, string AdditionalPaymentflg)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_Builldesc_PaymentDtls_DESE_TOURISM]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UID.Trim();
            da.SelectCommand.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = Orderno.Trim();
            da.SelectCommand.Parameters.Add("@AdditionalPaymentflg", SqlDbType.VarChar).Value = AdditionalPaymentflg.Trim();
            da.Fill(ds);
            return ds;
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

    public void GetTESTVALUESTourismEvent(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE_TOURISMEVENT", con.GetConnection);
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

    public void GetTESTVALUES(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE", con.GetConnection);
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

    public void GetTESTVALUESTRAVELAGENT(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE_TRAVELAGENT", con.GetConnection);
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

    public int InsertUpdatepaymentdtlsTravelAgent(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_TravelAgent]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_TravelAgent]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }

    public DataSet GetEnterprinerpaymentDtlsTravelAgent(string UID, string Orderno, string AdditionalPaymentflg)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_Builldesc_PaymentDtls_DESE_TravelAgent]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UID.Trim();
            da.SelectCommand.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = Orderno.Trim();
            da.SelectCommand.Parameters.Add("@AdditionalPaymentflg", SqlDbType.VarChar).Value = AdditionalPaymentflg.Trim();
            da.Fill(ds);
            return ds;
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

    public int InsertUpdatepaymentdtls_BWM(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction();
        SqlCommand command = new SqlCommand("[USP_UPDATE_Builldesc_PaymentDtls_BMW]", connection);
        command.CommandType = CommandType.StoredProcedure;
        SqlCommand command1 = null;

        try
        {
            command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
            command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
            command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
            command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
            command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
            command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
            command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
            command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
            command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
            command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
            command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
            command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
            command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
            command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
            command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
            command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
            command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
            command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
            command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
            command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
            command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
            command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
            command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
            command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
            command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
            command.Parameters.Add("@VALID", SqlDbType.Int, 500);
            command.Parameters["@VALID"].Direction = ParameterDirection.Output;

            command.Transaction = trans;
            command.ExecuteNonQuery();
            valid = (Int32)command.Parameters["@VALID"].Value;

            if (valid == 1)
            {
                foreach (paymendepartwisetresponseVOs ffvo in paymendepartwisetresponseVOsobj)
                {
                    command1 = new SqlCommand("[USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_BMW]", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@intQuessionaireid", ffvo.Questionnaireid);
                    command1.Parameters.AddWithValue("@intApprovalid", ffvo.intApprovalid);
                    command1.Parameters.AddWithValue("@intDeptid", ffvo.Departmentid);
                    command1.Parameters.AddWithValue("@TSIPASSUID", ffvo.CustomerID_1);
                    command1.Parameters.AddWithValue("@TxnDate_13", ffvo.TxnDate_13);
                    command1.Parameters.AddWithValue("@TxnReferenceNo_2", ffvo.TxnReferenceNo_2);
                    command1.Parameters.AddWithValue("@BankReferenceNo_3", ffvo.BankReferenceNo_3);
                    command1.Parameters.AddWithValue("@Deptamont", ffvo.DeptAmount);
                    command1.Parameters.AddWithValue("@TxnAmount_4", ffvo.TxnAmount_4);
                    command1.Parameters.AddWithValue("@BankID_5", ffvo.BankID_5);
                    command1.Parameters.AddWithValue("@AdditionalPaymentflg", ffvo.AdditionalPaymentFlag);
                    command1.Parameters.AddWithValue("@Created_by", ffvo.Createdby);
                    command1.Parameters.Add("@VALID", SqlDbType.Int, 500);
                    command1.Parameters["@VALID"].Direction = ParameterDirection.Output;
                    command1.Transaction = trans;
                    command1.ExecuteNonQuery();
                    valid = (Int32)command1.Parameters["@VALID"].Value;
                }
            }
            trans.Commit();
            connection.Close();

        }

        catch (Exception ex)
        {
            trans.Rollback();

            throw ex;
        }
        finally
        {
            command.Dispose();
            connection.Close();
            connection.Dispose();
            //command1.Dispose();
        }
        return valid;
    }
    public void GetPANRequest(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_FailedPaymentsREQUEST", con.GetConnection);
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
            da = new SqlDataAdapter("USP_INS_FailedPaymentRESPONSE", con.GetConnection);
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
    public DataSet Checkpaymentstatus(string uidno, string transactionno, string appltype)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_CHECK_PAYMENT_STATUS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno;
            da.SelectCommand.Parameters.Add("@TRANSACTIONNO", SqlDbType.VarChar).Value = transactionno;
            da.SelectCommand.Parameters.Add("@APPLTYPE", SqlDbType.VarChar).Value = appltype;
            da.Fill(ds);
            return ds;
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
public class CCavenuvo
{
    public string reference_no { get; set; }
    public string order_no { get; set; }
    public string order_bill_tel { get; set; }
    public string order_country { get; set; }
    public string order_email { get; set; }
    public string order_fraud_status { get; set; }
    public string order_max_amount { get; set; }
    public string order_min_amount { get; set; }
    public string order_name { get; set; }
    public string order_payment_type { get; set; }
    public string order_type { get; set; }
    public string order_currency { get; set; }
    public string page_number { get; set; }
    public string from_date { get; set; }
    public string to_date { get; set; }
    public string order_status { get; set; }

}
public class Order
{
    public string reference_no { get; set; }
    public string order_no { get; set; }
    public string order_currncy { get; set; }
    public string order_amt { get; set; }
    public string order_date_time { get; set; }
    public string order_bill_name { get; set; }
    public string order_bill_address { get; set; }
    public string order_bill_zip { get; set; }
    public string order_bill_tel { get; set; }
    public string order_bill_email { get; set; }
    public string order_bill_country { get; set; }
    public string order_ship_name { get; set; }
    public string order_ship_address { get; set; }
    public string order_ship_country { get; set; }
    public string order_ship_tel { get; set; }
    public string order_bill_city { get; set; }
    public string order_bill_state { get; set; }
    public string order_ship_city { get; set; }
    public string order_ship_state { get; set; }
    public string order_ship_zip { get; set; }
    public string order_ship_email { get; set; }
    public string order_notes { get; set; }
    public string order_ip { get; set; }
    public string order_status { get; set; }
    public string order_fraud_status { get; set; }
    public string order_status_date_time { get; set; }
    public string order_capt_amt { get; set; }
    public string order_card_name { get; set; }
    public string order_delivery_details { get; set; }
    public string order_fee_perc_value { get; set; }
    public string order_fee_perc { get; set; }
    public string order_fee_flat { get; set; }
    public string order_gross_amt { get; set; }
    public string order_discount { get; set; }
    public string order_tax { get; set; }
    public string order_bank_ref_no { get; set; }
    public string order_gtw_id { get; set; }
    public string order_bank_response { get; set; }
    public string order_option_type { get; set; }
    public string order_TDS { get; set; }
    public string order_device_type { get; set; }
    public string order_type { get; set; }
    public string ship_date_time { get; set; }
    public string payment_mode { get; set; }
    public string card_type { get; set; }
    public string sub_acc_id { get; set; }
    public string order_bin_country { get; set; }
    public string order_stlmt_date { get; set; }
    public string card_enrolled { get; set; }
    public string merchant_param1 { get; set; }
    public string merchant_param2 { get; set; }
    public string merchant_param3 { get; set; }
    public string merchant_param4 { get; set; }
    public string merchant_param5 { get; set; }
    public string order_bank_arn_no { get; set; }
    public string order_split_payout { get; set; }
    public string emi_issuing_bank { get; set; }
    public string tenure_duration { get; set; }
    public string emi_discount_type { get; set; }
    public string emi_discount_value { get; set; }
}
public class OrderStatusList
{
    public List<Order> order_Status_List { get; set; }
    public string page_count { get; set; }
    public string total_records { get; set; }
    public string failure_trans_count { get; set; }
    public string successful_trans_count { get; set; }
    public string awaited_trans_count { get; set; }
    public string dropped_trans_count { get; set; }
    public string fraud_trans_count { get; set; }
    public string error_desc { get; set; }
    public string error_code { get; set; }
}