using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Security.Cryptography;
using System.Text;
public partial class UI_TSiPASS_frmBillDeskNotUpdated : System.Web.UI.Page
{
    #region Declaration
    //General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();

    DataSet dslist;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
            }
            else
            {
                DateTime fromdate = DateTime.Today;
                txtFromDate.Text = fromdate.ToString("dd-MM-yyyy");
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
            }

            //fillgrid();
            callbilldeskpage();
        }
    }

    public void fillgrid()
    {

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        ds = Gen.GetBillDeskNotUpdateReport(FromdateforDB, TodateforDB,"");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

            griddetails.DataSource = ds.Tables[0];
            griddetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            griddetails.DataSource = null;
            griddetails.DataBind();
        }
    }

    public void callbilldeskpage()
    {
        try
        {
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = Gen.GetBillDeskNotUpdateReport(FromdateforDB, TodateforDB,"");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string onlineorderno = dt.Rows[i]["OnlineOrderNo"].ToString();
                    string Appltype = dt.Rows[i]["ApplType"].ToString();
                    var st = "data";
                    String commonkey = "alAQ2hHZXsvr";
                    String data = "0122|COITS|" + onlineorderno + "|" + DateTime.Now.ToString("yyyyMMddHHmmss") + "";
                    String hash = String.Empty;
                    hash = GetHMACSHA256(data, commonkey);
                    hash = hash.ToUpper();
                    String msg = data + "|" + hash;
                    //Response.Write(msg);

                    //Response.Write("<br/><br/>");

                    string WEBSERVICE_URL = "https://www.billdesk.com/pgidsk/PGIQueryController?msg=" + msg + "";
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
                                    //Response.Write(jsonResponse);
                                    //Response.Write("<br/><br/>");
                                    //String[] Array = jsonResponse.Split('|');
                                    //foreach (var re in Array)
                                    //{
                                    //    Response.Write(re);
                                    //    Response.Write("<br/>");
                                    //}
                                    //System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));

                                    //MerchantID|CustomerID|TxnReferenceNo|BankReferenceNo|TxnAmount|BankID|BIN|TxnTy
                                    //pe|CurrencyName|ItemCode|SecurityType|SecurityID|SecurityPassword|TxnDate|AuthStatu
                                    //s|SettlementType|AdditionalInfo1|AdditionalInfo2|AdditionalInfo3|AdditionalInfo4|Additional
                                    //Info5|AdditionalInfo6|AdditionalInfo7|ErrorStatus|ErrorDescription|CheckSum

                                    //RequestType | MerchantID | CustomerID | TxnReferenceNo | BankReferenceNo | TxnAmount | Bank
                                    //ID | BankMerchantID | TxnType | CurrencyName | ItemCode | SecurityType | SecurityID | SecurityPa
                                    //ssword | TxnDate | AuthStatus | SettlementType | AdditionalInfo1 | AdditionalInfo2 | AdditionalInfo
                                    //3 | AdditionalInfo4 | AdditionalInfo5 | AdditionalInfo6 | AdditionalInfo7 | ErrorStatus | ErrorDescripti
                                    //on | Filler1 | RefundStatus | TotalRefundAmount | LastRefundDate | LastRefundRefNo | QueryStatus
                                    //| CheckSum


                                    string BilldeskResponse = Request.Form["jsonResponse"];
                                    // string BilldeskResponse = msg;
                                    string[] values = BilldeskResponse.Split('|');

                                    paymentresponseVOsobj.MerchantID_0 = values[1];
                                    paymentresponseVOsobj.CustomerID_1 = values[18];   // UID Number
                                    paymentresponseVOsobj.TxnReferenceNo_2 = values[3];
                                    paymentresponseVOsobj.BankReferenceNo_3 = values[4];
                                    paymentresponseVOsobj.TxnAmount_4 = values[5];
                                    paymentresponseVOsobj.BankID_5 = values[6];
                                    paymentresponseVOsobj.BIN_6 = values[7];
                                    paymentresponseVOsobj.TxnType_7 = values[8];
                                    paymentresponseVOsobj.CurrencyName_8 = values[9];
                                    paymentresponseVOsobj.ItemCode_9 = values[10];
                                    paymentresponseVOsobj.SecurityType_10 = values[11];
                                    paymentresponseVOsobj.SecurityID_11 = values[12];
                                    paymentresponseVOsobj.SecurityPassword_12 = values[13];
                                    string[] date = values[14].Split(' ');
                                    string[] newdate = date[0].ToString().Split('-');
                                    paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();
                                    paymentresponseVOsobj.AuthStatus_14 = values[15];
                                    paymentresponseVOsobj.SettlementType_15 = values[16];
                                    paymentresponseVOsobj.AdditionalInfo1_16 = values[17];   // Questionaireid
                                    paymentresponseVOsobj.AdditionalInfo2_17 = values[2];    // TSipassOrderNumber
                                    paymentresponseVOsobj.AdditionalInfo3_18 = values[19];   // ApplicationType
                                    paymentresponseVOsobj.AdditionalInfo4_19 = values[20];   // Departmentdetails
                                    paymentresponseVOsobj.AdditionalInfo5_20 = values[21];   //  AddtionalPayment flag
                                    paymentresponseVOsobj.AdditionalInfo6_21 = values[22];
                                    paymentresponseVOsobj.AdditionalInfo7_22 = values[23];
                                    paymentresponseVOsobj.ErrorStatus_23 = values[24];
                                    paymentresponseVOsobj.ErrorDescription_24 = values[25];
                                    paymentresponseVOsobj.CheckSum_25 = values[32];
                                    //paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                                    //“0300”   Success                                           Successful Transaction
                                    //“0399”   Invalid Authentication at Bank                    Cancel Transaction
                                    //“NA”     Invalid Input in the Request Message              Cancel Transaction
                                    //“0002”   BillDesk is waiting for Response from Bank        Cancel Transaction
                                    //“0001”   Error at BillDesk                                 Cancel Transaction

                                    if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                                    {
                                        DataSet dspaydtls = new DataSet();
                                        if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                                        {
                                            if (Appltype == "CFE")
                                            {
                                                dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                            }
                                            if (Appltype == "CFO")
                                            {
                                                dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                                            }

                                            //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                                            if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                                            {
                                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            if (Appltype == "CFE")
                                            {
                                                dspaydtls = Gen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                            }
                                            if (Appltype == "CFO")
                                            {
                                                dspaydtls = Gen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
                                            }
                                            //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
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
                                    for (int k = 0; k < deptvalues.Length; k++)
                                    {
                                        string[] deptwisevalues = deptvalues[k].Split('#');
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

                                    if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                                    {
                                        if (Appltype == "CFE")
                                        {
                                            int valid = InsertUpdatepaymentdtls(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                            if (valid == 1)
                                            {
                                                //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                                Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                                Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                                Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceipt.aspx';", true);
                                            }
                                        }
                                        if(Appltype=="CFO")
                                        {
                                            int valid = InsertUpdatepaymentdtlscfo(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                                            if (valid == 1)
                                            {
                                                //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

                                                Session["Amount"] = paymentresponseVOsobj.TxnAmount_4;
                                                Session["RefNo"] = paymentresponseVOsobj.BankID_5;
                                                Session["TranRefNo"] = paymentresponseVOsobj.TxnReferenceNo_2;

                                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptCFO.aspx';", true);
                                            }
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
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }


                }
            }
        }
        catch (Exception ex)
        {

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
}