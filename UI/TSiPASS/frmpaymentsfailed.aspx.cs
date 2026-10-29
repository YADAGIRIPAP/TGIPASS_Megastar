using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

public partial class UI_TSiPASS_frmpaymentsfailed : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    CCavenuvo ccavo = new CCavenuvo();
    string workingKey = "9B383382630D206B91CCF862546AF22A";//"9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";// "http://www.localhost:5518";//"http://ipass.telangana.gov.in";
    public string strMerchantId = "185458";
    public string strEncRequest = "";
    public string strdecRequest = "";
    public string strAccessCode = "AVHE79FG49CL98EHLC";//"AVHE79FG49CL98EHLC";// put the access key in the quotes provided here.
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    General objgen = new General();
    BMWClass objBMW = new BMWClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        var j = "status=0&enc_response=f38cd3ad0b45180ed5fb44013fbb59e2dd78ed888088b65844ccf5b27dbb524a55a9087d0cdc8257a158fb0e82a1f1efd03bfa3dd592bb3b5cd212dfd1c061e91d6a4d4d7385b8095d12734e46f04f2d995ab06ddb0a044ec0a3b7c4e1f0b86a20f704d8c77bfacc18cc5569f767ad9bea3ab965d28f7aba501b0e8f09f3eff6bbafdaa5ffdea37891064d819683f15475ffc78941ea02d4796ae60a1d8e3dceb233f0e5395e63f45e49292989a65b61c2d819759a92d8ad2de6319dce458caf0d3dddbe52cd78832da777ce3c6db0e422f6fef497ef01b118c536cecc9c249e7096efafbae1052bc9adf7fbe1343957375e8b61947588ecf1eada6c085a4307fc5fa89b5fea58736dec80e641e889ea1ac297511fbcc4c5da48d37a717f7b3b335f8ed6bb1f8b85f2507efc767569692f2b2ff63261907569a3b66474182d73141c769b7900da7cc7eaeb1b8381c235838d48ea1b6ea24b2a9b702cfadf7e31ec1b1729ef022e68ae010e4be9af8c79e41a1bdc023eb0f359b1fd7b24b52988135af481591c1c3ee7dfc21fab7d1d199cb56444a08808ac7bd17db6a39c5c49521ff51fea31b6117901b605ed51fa158b671a41694e00ccfffc749a54085c71cf53fe1c7cee92cd4c15e100ab5b4262998a3eef9626666949680562fe3ca2105bdd4987a8147ee1617f22e7db7036d024341a83acc1ffe91a482d48aa3a0aee34aaca11212723c359efdbf5956ce5fb48ea448cfa3ec7f8e6c37e40d57b03228727703281df1b0c6002397be64e52927f8a80353f823d6972db0f9ae80162179f0af2d41193de2db2b46921380eaef15bb2bdea57d1426ba8a6cb01b68a6395f25debf3f3fa1bad98db7c49711c4e51dd21234088a111c7996f0c6724a7f823cc64a1f2abbda543259cceb5dba8bb719fe71d08db658829a2ecf9b6f89d07974414e77b58214c57dfb7fbb283dd61c42eca040487339bef1ae23438d92727d3ea8d7459e78d4601935e12cb95390ca6ff1b3eac97e6bef1c18c36b01d81f2919f01af7f4a7c821e62f72dbc0fc247f3f5a15e3b0264a7dc12640035cddd3fc2852eecf41900124767a98569a677dc36a859599af45c367480c6c8dbed5c3a2ccd0a5b8864ef97c690284695278159f2c2d46b3c0698786df71503d67b681cf54fded64d4be5df3d9b4f44667da2248c0457ad99f5b0741f5640027d110aacde8fc5ca96c03c23e0808586fcecf60d5c730437fda28947e42ca338cb3b73aa128ac58094ec0ddd83abda2f037cf17a6fad9e39c4e0581db4562b262ab562055c02b6d1fa424ea1e5139e296c1769c0f06159534327333a517722809339b0bea87e95f4777a09a8aee1e46129471646ede22755d8cb40ce711472673793ed95d8895c2bec59473e74d788c669aa79b0c7da44d331a1426ed2ee8dfccaf4bc909b6fb7ef19af43fd5f5ba827f7a4bcaa25920d9485cbc0719170d6c09b0fccad2b16ec407f0a70d2e34bc330c8d582704e0be1dcc4f3c548b9ed8d8bb4dcbf08bb865922733b9bbc9d9d20834fc99858260187507ba941eb3aaeb1bee2919d1aa3473e0ebb3e6a53e087e81b1c19360d1079fc6da9cec90f844b9f49adff1a515b9bbcdb840a0da0dcdc73b18016966aa2a2ef2a75a3533fdcfc934f5db99fc57d81e2aa1e93636370a256b2802f2b94d3093817252e4623c777bbd9135ac2e854c2f6115c67fc3e74792627ea4d1c7e8ac5e57756dbbcf46540954aa2c9adbd996f886d0266626c3b7d5514dade983ae7e43c0ed286afa4a1de607eabdb85728cec0a8a41408f7517867a31300f95d7749782a18efffe24d7a705e7fa33b16fdcf85e54211e59089b976d66b8447575d9b76e5c9566dbd4531d714c6b904bd9986d47fc46d3d0a5b611a7d77775469edbe69096920f800dbcdd1a0fca59ca1c76bece40ff5a6118cf44b07257a075007e9333e6a2829f8e8fbc7cc9aec4eb73da8a30c1445cb790ee497e300b0a172aa01bc747ffa3bc6e3196eaeed17a4b4270b1083066e532a0304a0f2ab97e981f8f5149a4082e1b1d9b17e0ecba2a14ef7ddf0b4ceaaa8aa549e279883b982ffbf3f7b2f94dae91ee178e829c84db91d6548dd1dabd0735610a689d2e48a83becad5ce3bc9d485a7ce1b99ac49d234e6d7aee85a65de2a496386420143f8009524d827859870b50c38c692319ce12b9b018dd34005fc151ed014df1270325309c1f4ffedada1b69bf6a155caea2b19c046f2b1f9fcfd9b89e2fc39b66226c278817fe8fd28c35a39c195cceb4a898aa539ca7444c821a9a04207ddd92ac935f655c8d8a5370917f14baa3943b9a5674e36a819a5e1c19d023d6e8f19e0ffffffe0c64f33b25023a45aa6c90a15d07c70cc0bdeedad51c9e33f56bef46d9ee6d06b174f4c0b04b41b1f94ec6906967ef0419ebe594c7704698aa579c1a82e0d322aade332630e4fdafddded0dc6fa0183c48";
            //"status=0&enc_response=2059ed7b9770f9503aec1d7b4fac838568509b43c7c8d86b1f316c2d377686a44e7487fba5b465253a61ecd01cf37ecac530ea58a0c49505daa0fdd7d4aa72024a8514cbe2a46d47d826dddb36d13405e4a4598d7512a649fde212c7df416abc0a96df68eb052228e54cf37d6edd13f9753b8309b1e48e211a524e4c18a39135cced2e5e1492d7c58942f2fe617252c66b46d6f134df63acfafbeb26abbffac1d13dbd6f9a1e182332c7143f45097f6b959c6777d14d29592cb5cd06fc3223f9833ef194a140ac46080d0ee4ea08adfae746545ecc56bae761a62afe972286a7fcb700c318c39d64653ef3e37e6fd3ace6f65ae19c2c723c66fec832efdb624a";

        string[] pairs = j.Split('&');
        foreach (string pair in pairs)
        {
            string[] keyValue = pair.Split('=');
            if (keyValue.Length == 2)
            {
                string key = keyValue[0];
                string value = keyValue[1];
                if (key == "enc_response")
                {
                    string json = ccaCrypto.Decrypt(value, workingKey);
                    LogErrorFile.LogData("working");
                    OrderStatusList orderStatusListnn = DigiGeneral.DigiGeneral.JsonDeserialize<OrderStatusList>(json);
                    foreach (var order in orderStatusListnn.order_Status_List)
                    {
                        LogErrorFile.LogData("notowkring");
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
            }
        }
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