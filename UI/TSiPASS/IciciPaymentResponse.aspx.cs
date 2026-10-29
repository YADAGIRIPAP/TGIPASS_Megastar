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
using DotNetIntegrationKit;
using System.Configuration;
using System.Data.SqlClient;
public partial class IciciPaymentResponse : System.Web.UI.Page
{
    #region Variable Declaration
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    string strHEX, strPGActualReponseWithChecksum, strPGActualReponseEncrypted, strPGActualReponseDecrypted, strPGresponseChecksum, strPGTxnStatusCode;
    string[] strPGChecksum, strPGTxnString;
    bool isDecryptable = false;

    string strPG_TxnStatus = string.Empty,
    strPG_ClintTxnRefNo = string.Empty,
            strPG_TPSLTxnBankCode = string.Empty,
            strPG_TPSLTxnID = string.Empty,
            strPG_TxnAmount = string.Empty,
            strPG_TxnDateTime = string.Empty,
            strPG_TxnDate = string.Empty,
            strPG_TxnTime = string.Empty;
    string strPGResponse;
    string[] strSplitDecryptedResponse;
    string[] strArrPG_TxnDateTime;
    #endregion   

    protected void Page_Load(object sender, EventArgs e)
    {
        strPGResponse =Request["msg"].ToString();
      // strPGResponse = "123";
        Response.Write(strPGResponse);
        if (strPGResponse != "" || strPGResponse != null)
        {
           // LBL_DisplayResult.Text = "Response :: " + strPGResponse;
            //Creating Object of Class DotNetIntegration_1_1.RequestURL
            RequestURL objRequestURL = new RequestURL();
            //Decrypting the PG response
            string strDecryptedVal = objRequestURL.VerifyPGResponse(strPGResponse, ConfigurationSettings.AppSettings["FilePath"]);
               // "txn_status=0300|txn_msg=success|txn_err_msg=|clnt_txn_ref=ICICI20160105130433|tpsl_bank_cd=10|tpsl_txn_id=7421002|txn_amt=4.00|tpsl_txn_time=26-03-2014 19:15:13|tpsl_rfnd_id=NA|bal_amt=NA|rqst_token=e082e594-74d4-4cca-baad-039a8fc593f2";//objRequestURL.VerifyPGResponse(strPGResponse, ConfigurationSettings.AppSettings["FilePath"]);
          // We need to write Decrypted file in Log file
           // strDecryptedVal = "txn_status=0300|txn_msg=success|txn_err_msg=NA|clnt_txn_ref=ICICI20160421182905|tpsl_bank_cd=470|tpsl_txn_id=218966408|txn_amt=1.00|clnt_rqst_meta={email:fss.srikanth@gmail.com}{mob:9246761959}{custid:SML0041801025}{custname:Srikanth M}|tpsl_txn_time=21-04-2016 18:30:54|tpsl_rfnd_id=NA|bal_amt=NA|rqst_token=5708e99f-a50f-45ee-a3d7-9fa7f630672c";
           // Response.Write(strDecryptedVal);
            lblResponseDecrypted.Text = strDecryptedVal;

           
            LogErrorToText1(strDecryptedVal);
            if(strDecryptedVal.StartsWith("ERROR"))
            {
                lblValidate.Text = strDecryptedVal;
            }
            else
            {
                strSplitDecryptedResponse = strDecryptedVal.Split('|');
                GetPGRespnseData(strSplitDecryptedResponse);

                if(strPG_TxnStatus == "0300")
                {
                    
                     lblValidate.Text = "Transaction Success  " + strPG_TxnStatus;
                     string[] values;
                     if(strPG_TxnAmount.Contains("."))
                     {
                         values =strPG_TxnAmount.Split('.');
                         lblAmount.Text=values[0];
                     }
                     else
                     {
                      lblAmount.Text=strPG_TxnAmount;
                     }

                  

                         SqlConnection conn = new SqlConnection(constring);
                         if (conn.State == ConnectionState.Closed)
                         {
                             conn.Open();
                         }
                         SqlCommand cmd1 = new SqlCommand("InsertICICIPaymentDt", conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@OrderNo", lblTransRefNumber.Text);
                        cmd1.Parameters.AddWithValue("@Receipt_No", lblTxnRefId.Text);
                        cmd1.Parameters.AddWithValue("@Receipt_Date", strPG_TxnDate);
                        cmd1.Parameters.AddWithValue("@Paid_At", "IC");
                        cmd1.Parameters.AddWithValue("@Pay_Mode", "");                      
                        cmd1.Parameters.AddWithValue("@Paid_Amt", lblAmount.Text != "" ? Convert.ToDecimal(lblAmount.Text): Convert.ToDecimal("0") );
                        cmd1.Parameters.AddWithValue("@Status", lblTrnaStatus.Text);
                        cmd1.Parameters.AddWithValue("@Remarks", lblTranMesage.Text);
                        cmd1.Parameters.AddWithValue("@Bank_id", lblBankCode.Text);
                        cmd1.Parameters.AddWithValue("@Bank_RefNo", lbltpslTrnsId.Text);
                        cmd1.Parameters.AddWithValue("@Transaction_Date", strPG_TxnDate);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet ds = new DataSet();
                        da1.Fill(ds);
                        conn.Close();                        

                        if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if(ds.Tables[0].Rows[0][0].ToString() == "A")
                            {
                                Session["Amount"] = lblAmount.Text;
                                Session["RefNo"] = "IC";                                    
                                Session["TranRefNo"] = lblTransRefNumber.Text;
                                LogErrorToText1("Transaction Completed Sucessfully , Your reference No: "+ lblTransRefNumber.Text);
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='PrintReceipt.aspx';", true);
                            }
                            else
                            {
                                SqlConnection conn1 = new SqlConnection(constring);
                                conn1.Open();
                                SqlCommand cmd2 = new SqlCommand("InsertERRORDetails", conn1);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.AddWithValue("@OrderNo", lblTransRefNumber.Text);
                                cmd2.Parameters.AddWithValue("@Receipt_No", lblTxnRefId.Text);
                                cmd2.Parameters.AddWithValue("@Recepit_Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                                cmd2.Parameters.AddWithValue("@Paid_At", "IC");
                                cmd2.Parameters.AddWithValue("@Pay_Mode", "");
                                cmd2.Parameters.AddWithValue("@TSipass_UID", "icici");
                                cmd2.Parameters.AddWithValue("@Paid_Amt", lblAmount.Text != "" ? Convert.ToDecimal(lblAmount.Text) : Convert.ToDecimal("0"));
                                cmd2.Parameters.AddWithValue("@Status", lblTrnaStatus.Text);
                                cmd2.Parameters.AddWithValue("@Remarks", lblTranMesage.Text);
                                cmd2.Parameters.AddWithValue("@Bank_id", lblBankCode.Text);
                                cmd2.Parameters.AddWithValue("@Bank_RefNo", lbltpslTrnsId.Text);
                                cmd2.Parameters.AddWithValue("@Transaction_Date", strPG_TxnDate);
                                int iEfCount = cmd2.ExecuteNonQuery();
                                //SqlDataAdapter da = new SqlDataAdapter(cmd1);
                                //DataSet ds2 = new DataSet();
                                //da.Fill(ds2);
                                conn1.Close();
                                LogErrorToText1("Transaction Failed at Our Database, Your reference No: " + lblTransRefNumber.Text);
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('your payment reference number: " + lblTransRefNumber.Text + " ');", true);

                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed,try Again');", true);
                            }
                        }
                        else
                        {
                            SqlConnection conn1 = new SqlConnection(constring);
                            conn1.Open();
                            SqlCommand cmd2 = new SqlCommand("InsertERRORDetails", conn1);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@OrderNo", lblTransRefNumber.Text);
                            cmd2.Parameters.AddWithValue("@Receipt_No", lblTxnRefId.Text);
                            cmd2.Parameters.AddWithValue("@Recepit_Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                            cmd2.Parameters.AddWithValue("@Paid_At", "IC");
                            cmd2.Parameters.AddWithValue("@Pay_Mode", "");
                            cmd2.Parameters.AddWithValue("@TSipass_UID", "icici");
                            cmd2.Parameters.AddWithValue("@Paid_Amt", lblAmount.Text != "" ? Convert.ToDecimal(lblAmount.Text) : Convert.ToDecimal("0"));
                            cmd2.Parameters.AddWithValue("@Status", lblTrnaStatus.Text);
                            cmd2.Parameters.AddWithValue("@Remarks", lblTranMesage.Text);
                            cmd2.Parameters.AddWithValue("@Bank_id", lblBankCode.Text);
                            cmd2.Parameters.AddWithValue("@Bank_RefNo", lbltpslTrnsId.Text);
                            cmd2.Parameters.AddWithValue("@Transaction_Date", strPG_TxnDate);
                            int iEfCount= cmd2.ExecuteNonQuery();
                            //SqlDataAdapter da = new SqlDataAdapter(cmd1);
                            //DataSet ds2 = new DataSet();
                            //da.Fill(ds2);
                            conn1.Close();
                            LogErrorToText1("Transaction Dataset in null , Your reference No: " + lblTransRefNumber.Text);
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('your payment reference number: " + lblTransRefNumber.Text + " ');", true);

                        }                       
                        

                }
                else
                {
                    LogErrorToText1("Payment Failed at Bank values" + strDecryptedVal);
                    lblValidate.Text = "Transaction Fail :: <br/>" + "Response :: <br/>"+ strDecryptedVal;
                }
            }
        } 

    }
    public void GetPGRespnseData(string[] parameters)
    {
        string[] strGetMerchantParamForCompare;
        for (int i = 0; i < parameters.Length; i++)
        {
            strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
            if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
            {
                strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                lblTransTime.Text = strPG_TxnStatus;
            }
            else if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_REF")
            {
                strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                lblTransRefNumber.Text = strPG_ClintTxnRefNo;
            }
            else if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_BANK_CD")
            {
                strPG_TPSLTxnBankCode = Convert.ToString(strGetMerchantParamForCompare[1]);
                lblBankCode.Text = strPG_TPSLTxnBankCode;
            }
            else if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_ID")
            {
                strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                lbltpslTrnsId.Text = strPG_TPSLTxnID;
            }
            else if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMT")
            {
                strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                lblAmount.Text = strPG_TxnAmount;
            }
            else if(Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_TIME")
            {
                strPG_TxnDateTime = Convert.ToString(strGetMerchantParamForCompare[1]);
                strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
                lblTransTime.Text = strPG_TxnDate + " " + strPG_TxnTime;
            }
        }
    }
    public static void LogErrorToText1(string ex)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("********************" + " Error Log - " + DateTime.Now + "*********************");
        sb.Append(Environment.NewLine);
        sb.Append("Error Message : " + ex);
        sb.Append(Environment.NewLine);
        //sb.Append(ex);
        sb.Append("********************" + " END Error Log *********************");
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
        sb.Append("********************" + " Error Log - " + DateTime.Now + "*********************");
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
        sb.Append("********************" + " END Error Log *********************");
        string filePath = HttpContext.Current.Server.MapPath("Online_Error_Log.txt");
        if (System.IO.File.Exists(filePath))
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
        }
    }
}
