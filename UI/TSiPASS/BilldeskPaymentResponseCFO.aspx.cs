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
using com.toml.dp.util;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class UI_TSiPASS_BilldeskPaymentResponseCFO : System.Web.UI.Page
{
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    General objgen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                // string msg = "COITS|Bill20170429110241|ICIT5328013130|498871-002887|2.00|CIT|516640|03|INR|DIRECT|NA|NA|00000000.00|29-04-2017 11:04:39|0300|NA|4714|MEG01800494415|CFO|NODEPT|txtadditional5| txtadditional6| txtadditional7|NA|Success|58BB0DF9AC4FA97402AF8341DBFFB539594629D3C7C34BEFCEECFD8B082AD697";
                if (Request.Form["msg"] != null)
                {
                    //if (msg != null)
                    //{
                    //MerchantID|CustomerID|TxnReferenceNo|BankReferenceNo|TxnAmount|BankID|BIN|TxnTy
                    //pe|CurrencyName|ItemCode|SecurityType|SecurityID|SecurityPassword|TxnDate|AuthStatu
                    //s|SettlementType|AdditionalInfo1|AdditionalInfo2|AdditionalInfo3|AdditionalInfo4|Additional
                    //Info5|AdditionalInfo6|AdditionalInfo7|ErrorStatus|ErrorDescription|CheckSum

                    string BilldeskResponse = Request.Form["msg"];

                    try
                    {
                        GetTESTVALUES(BilldeskResponse);
                    }
                    catch (Exception ex)
                    {

                    }
                    // string BilldeskResponse = msg;
                    string[] values = BilldeskResponse.Split('|');

                    paymentresponseVOsobj.MerchantID_0 = values[0];
                    paymentresponseVOsobj.CustomerID_1 = values[17];   // UID Number
                    paymentresponseVOsobj.TxnReferenceNo_2 = values[2];
                    paymentresponseVOsobj.BankReferenceNo_3 = values[3];
                    paymentresponseVOsobj.TxnAmount_4 = values[4];
                    paymentresponseVOsobj.BankID_5 = values[5];
                    paymentresponseVOsobj.BIN_6 = values[6];
                    paymentresponseVOsobj.TxnType_7 = values[7];
                    paymentresponseVOsobj.CurrencyName_8 = values[8];
                    paymentresponseVOsobj.ItemCode_9 = values[9];
                    paymentresponseVOsobj.SecurityType_10 = values[10];
                    paymentresponseVOsobj.SecurityID_11 = values[11];
                    paymentresponseVOsobj.SecurityPassword_12 = values[12];
                    string[] date = values[13].Split(' ');
                    string[] newdate = date[0].ToString().Split('-');
                    paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();
                    paymentresponseVOsobj.AuthStatus_14 = values[14];
                    paymentresponseVOsobj.SettlementType_15 = values[15];
                    paymentresponseVOsobj.AdditionalInfo1_16 = values[16];   // Questionaireid
                    paymentresponseVOsobj.AdditionalInfo2_17 = values[1];    // TSipassOrderNumber
                    paymentresponseVOsobj.AdditionalInfo3_18 = values[18];   // ApplicationType
                    paymentresponseVOsobj.AdditionalInfo4_19 = values[19];   // Departmentdetails
                    paymentresponseVOsobj.AdditionalInfo5_20 = values[20];   //  AddtionalPayment flag
                    paymentresponseVOsobj.AdditionalInfo6_21 = values[21];
                    paymentresponseVOsobj.AdditionalInfo7_22 = values[22];
                    paymentresponseVOsobj.ErrorStatus_23 = values[23];
                    paymentresponseVOsobj.ErrorDescription_24 = values[24];
                    paymentresponseVOsobj.CheckSum_25 = values[25];
                    paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                    //“0300”   Success                                           Successful Transaction
                    //“0399”   Invalid Authentication at Bank                    Cancel Transaction
                    //“NA”     Invalid Input in the Request Message              Cancel Transaction
                    //“0002”   BillDesk is waiting for Response from Bank        Cancel Transaction
                    //“0001”   Error at BillDesk                                 Cancel Transaction

                    if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                    {
                        if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                        {
                            DataSet dspaydtls = new DataSet();
                            dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                            //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                            if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                            {
                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                            }
                        }
                        else
                        {
                            DataSet dspaydtls = new DataSet();
                            dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17,"");
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

                    if (paymentresponseVOsobj.AuthStatus_14 == "0300")
                    {
                        int valid = InsertUpdatepaymentdtlscfo(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                        if (valid == 1)
                        {
                            //  LogErrorToText1("Payment done successfully,Reference number: " + paymentresponseVOsobj.TxnReferenceNo_2);

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
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            // LogErrorToText(ex);
        }
    }
    public static void LogErrorToText1(string ex)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("********************" + " Bill Desk ONLINE Error Log - " + DateTime.Now + "*********************");
        sb.Append(Environment.NewLine);
        sb.Append("Error Message : " + ex);
        sb.Append(Environment.NewLine);
        //sb.Append(ex);
        sb.Append("********************" + " Bill Desk ONLINE END Error Log *********************");
        string filePath = HttpContext.Current.Server.MapPath("Online_Error_Log.txt");
        if (System.IO.File.Exists(filePath))
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
        }
    }
    public static void LogErrorToText(Exception ex)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("********************" + " Bill Desk ONLINE Error Log - " + DateTime.Now + "*********************");
        sb.Append(Environment.NewLine);
        sb.Append(Environment.NewLine);
        sb.Append("Exception Type : " + ex.GetType().Name);
        sb.Append(Environment.NewLine);
        sb.Append("Error Message : " + ex.Message);
        sb.Append(Environment.NewLine);
        sb.Append("Error Source : " + ex.Source);
        sb.Append(Environment.NewLine);
        if (ex.StackTrace != null)
        {
            sb.Append("Error Trace : " + ex.StackTrace);
        }
        Exception innerEx = ex.InnerException;

        while (innerEx != null)
        {
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Exception Type : " + innerEx.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append("Error Message : " + innerEx.Message);
            sb.Append(Environment.NewLine);
            sb.Append("Error Source : " + innerEx.Source);
            sb.Append(Environment.NewLine);
            if (ex.StackTrace != null)
            {
                sb.Append("Error Trace : " + innerEx.StackTrace);
            }
            innerEx = innerEx.InnerException;
        }
        sb.Append("********************" + " BillDesk ONLINE END Error Log *********************");
        string filePath = HttpContext.Current.Server.MapPath("Online_Error_Log.txt");
        if (System.IO.File.Exists(filePath))
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
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