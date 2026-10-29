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
public partial class UI_TSiPASS_ccavResponseHandlerMOBILETOWER_TSROW : System.Web.UI.Page
{
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    protected void Page_Load(object sender, EventArgs e)
    {
        string workingKey = "9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here
        CCACrypto ccaCrypto = new CCACrypto();
        string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
        NameValueCollection Params = new NameValueCollection();
        string[] segments = encResponse.Split('&');
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

        for (int i = 0; i < Params.Count; i++)
        {
            //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
        }
        //our code we for db insertion
        string msg = encResponse;
        if (msg != null)
        {
            string BilldeskResponse = msg;
            try
            {
                GetTESTVALUES(BilldeskResponse);
            }
            catch (Exception ex)
            {

            }


            paymentresponseVOsobj.MerchantID_0 = "185458";
            paymentresponseVOsobj.CustomerID_1 = Params[0];   // UID Number
            paymentresponseVOsobj.TxnReferenceNo_2 = Params[1];
            paymentresponseVOsobj.BankReferenceNo_3 = Params[2];
            paymentresponseVOsobj.TxnAmount_4 = Params[10];
            paymentresponseVOsobj.BankID_5 = Params[6];
            paymentresponseVOsobj.BIN_6 = "";
            paymentresponseVOsobj.TxnType_7 = Params[5];
            paymentresponseVOsobj.CurrencyName_8 = Params[9];
            paymentresponseVOsobj.ItemCode_9 = "";
            paymentresponseVOsobj.SecurityType_10 = "";
            paymentresponseVOsobj.SecurityID_11 = "";
            paymentresponseVOsobj.SecurityPassword_12 = "";
           
            string[] date = Params[40].Split(' ');
            string[] newdate = date[0].ToString().Split('/');
            paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString() + " " + date[1].ToString();

            paymentresponseVOsobj.AuthStatus_14 = Params[3];
            paymentresponseVOsobj.SettlementType_15 = Params[5];
            paymentresponseVOsobj.AdditionalInfo1_16 = Params[26];   // Questionaireid
            paymentresponseVOsobj.AdditionalInfo2_17 = Params[27];    // TSipassOrderNumber
            paymentresponseVOsobj.AdditionalInfo3_18 = Params[28];   // ApplicationType
            paymentresponseVOsobj.AdditionalInfo4_19 = Params[29];   // Departmentdetails
            paymentresponseVOsobj.AdditionalInfo5_20 = Params[30];   //  AddtionalPayment flag
            paymentresponseVOsobj.AdditionalInfo6_21 = "";
            paymentresponseVOsobj.AdditionalInfo7_22 = "";
            paymentresponseVOsobj.ErrorStatus_23 = Params[4];
            paymentresponseVOsobj.ErrorDescription_24 = Params[4];
            paymentresponseVOsobj.CheckSum_25 = "";
           

            if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
            {
                DataSet dspaydtls = new DataSet();
                if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                {
                    dspaydtls = GetEnterprinerpaymentDtls_MOBILETOWER_TSROW(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                    paymentresponseVOsobj.Createdby = dspaydtls.Tables[1].Rows[0]["CREATEDBY"].ToString();
                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                    {
                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                    }
                }
                else
                {
                    dspaydtls = GetEnterprinerpaymentDtls_MOBILETOWER_TSROW(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

            if (paymentresponseVOsobj.AuthStatus_14 == "Success")
            {
                int valid = InsertUpdatepaymentdtls_MOBILETOWER_TSROW(paymentresponseVOsobj, paymendepartwisetresponseVOsobj);
                try
                {
                    GetTESTVALUES_MOBILETOWER_TSROW(BilldeskResponse);
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

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='IpassPrintReceiptMultiplex.aspx';", true);
                }
            }
            else
            {
                // LogErrorToText1("Payment failed at bank values: " + respActualValues);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank due to " + paymentresponseVOsobj.ErrorDescription_24 + "');" + "window.location='MultiplexDashboardList.aspx';", true);
                // Response.Redirect("HomeDashboard.aspx");
            }
        }
        //kotak code
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

    public void GetTESTVALUES_MOBILETOWER_TSROW(string Responce)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_TEST_WEBSERVISE_MOBILETOWER_TSROW", con.GetConnection);
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

    public int InsertUpdatepaymentdtls_MOBILETOWER_TSROW(paymentresponseVOs paymentresponseVOsobj, List<paymendepartwisetresponseVOs> paymendepartwisetresponseVOsobj)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid = 0;
        int itemidout = 0;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction trans = null;

        connection.Open();
        trans = connection.BeginTransaction(); 
         SqlCommand command = new SqlCommand("USP_UPDATE_Builldesc_PaymentDtls_MOBILETOWER_TSROW", connection);
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
                    command1 = new SqlCommand("USP_UPDATE_DEPTWISE_Builldesc_PaymentDtls_MOBILETOWER_TSROW", connection);
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

    public DataSet GetEnterprinerpaymentDtls_MOBILETOWER_TSROW(string UID, string Orderno, string AdditionalPaymentflg)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Builldesc_PaymentDtls_DESE_MobiletowerTSROW", con.GetConnection);
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
}