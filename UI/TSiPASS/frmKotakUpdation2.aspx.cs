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
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmKotakUpdation2 : System.Web.UI.Page
{
    paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
    General objgen = new General();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            if (Session["user_id"] != null)
            {
                if (Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim().ToLower() == "cmsnikhil" || Session["user_id"].ToString().Trim().ToLower() == "cmssandeep")
                {
                    if (Request.QueryString["order_id"] != null)
                    {
                        if (Request.QueryString["order_id"].ToString() != "")
                        {
                            txtuidno.Text = "order_id='" + Request.QueryString["order_id"].ToString() + "'&tracking_id='" + Request.QueryString["tracking_id"].ToString() + "'&bank_ref_no='" + Request.QueryString["bank_ref_no"].ToString() + "'&order_status=Success&failure_message=&payment_mode='" + Request.QueryString["payment_mode"].ToString() + "'&card_name='" + Request.QueryString["card_name"].ToString() + "'&status_code=null&status_message=Success&currency=INR&amount='" + Request.QueryString["amount"].ToString() + "'&card_name='" + Request.QueryString["card_name"].ToString() + "'&billing_name=&billing_address=&billing_city=&billing_state=&billing_zip=&billing_country=&billing_tel=&billing_email=&delivery_name=&delivery_address=&delivery_city=&delivery_state=&delivery_zip=&delivery_country=&delivery_tel=&merchant_param1=12349&merchant_param2='" + Request.QueryString["merchant_param2"].ToString() + "'&merchant_param3='" + Request.QueryString["merchant_param3"].ToString() + "'&merchant_param4=NODEPT&merchant_param5='" + Request.QueryString["merchant_param5"].ToString() + "'&vault=N&offer_type=null&offer_code=null&discount_value=0.0&mer_amount='" + Request.QueryString["mer_amount"].ToString() + "'&eci_value=02&retry=N&response_code=0&billing_notes=&trans_date='" + Request.QueryString["trans_date"].ToString() + "'+ 14:58:12&bin_country=INDIA&trans_fee=0.0&service_tax=0.0";
                        }
                    }
                }
            }

            else
            {
                Response.Redirect("~/Index.aspx");
            }


    }
    
    protected void txtUID_TextChanged(object sender, EventArgs e)
    {
        filldetails();
    }
    protected void filldetails()
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter myDataAdapter;
            DataSet oDataSet = new DataSet();

            myDataAdapter = new SqlDataAdapter("sp_getPaymentSubmissionDetails", osqlConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            myDataAdapter.SelectCommand.Parameters.Add("@uidNo", SqlDbType.VarChar).Value = txtUID.Text.Trim();

            myDataAdapter.Fill(oDataSet);

            txtUID.Text = oDataSet.Tables[0].Rows[0]["uidNo"].ToString();
            txtAmount.Text = oDataSet.Tables[0].Rows[0]["Amount"].ToString();
            txtAmounnt2.Text = oDataSet.Tables[0].Rows[0]["Amount"].ToString();
            txtEmail.Text = oDataSet.Tables[0].Rows[0]["Email"].ToString();
            txtMobile.Text = oDataSet.Tables[0].Rows[0]["Mobile"].ToString();
            txtKotak.Text = oDataSet.Tables[0].Rows[0]["KotakID"].ToString();



        }
        catch (Exception ex)
        {
            throw ex;
            //string message = "alert('Payment Submission Failed. Pl try again')";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + message + "');", true);
            //return;
        }

        finally
        {
            osqlConnection.Close();
        }



    }

    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        txtAmounnt2.Text = txtAmount.Text;
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string workingKey = "9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here
        CCACrypto ccaCrypto = new CCACrypto();
        string paymentSubmssion = "";
        string checkings = "";
        if (ddlAddlPaymnt.SelectedItem.Text.ToString().Trim() == "YES")
        {
            checkings = "Y";
        }
        else
        {
            checkings = "";
        }
        paymentSubmssion = "order_id=" + txtUID.Text.ToString().Trim() + "&tracking_id=" + txtTTRid.Text.ToString().Trim() + "&bank_ref_no=" + txtBrNo.Text.ToString().Trim() + "&order_status=Success&failure_message=&payment_mode=" + txtPM.Text.ToString().Trim() + "&card_name=" + txtCrdName.Text.ToString().Trim() + "&status_code=null&status_message=Success&currency=INR&amount=" + txtAmount.Text.ToString().Trim() + "&card_name=&billing_name=&billing_address=&billing_city=&billing_state=&billing_zip=&billing_country=&billing_tel=&billing_email=&delivery_name=&delivery_address=&delivery_city=&delivery_state=&delivery_zip=&delivery_country=&delivery_tel=&merchant_param1=12349&merchant_param2=" + txtKotak.Text.ToString().Trim() + "&merchant_param3=" + ddlTypeofAppl.SelectedItem.Text.ToString().Trim() + "&merchant_param4=NODEPT&merchant_param5=" + checkings + "&vault=N&offer_type=null&offer_code=null&discount_value=0.0&mer_amount=" + txtAmount.Text.ToString().Trim() + "&eci_value=02&retry=N&response_code=0&billing_notes=&trans_date=" + txtDate.Text.ToString().Trim() + "&bin_country=INDIA&trans_fee=0.0&service_tax=0.0";
        NameValueCollection Params = new NameValueCollection();
        string[] segments = paymentSubmssion.Split('&');

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
        string msg = paymentSubmssion;
        if (msg != null)
        {
            //string BilldeskResponse = txtuidno.Text.Trim();
            //try
            //{
            //    GetTESTVALUES(BilldeskResponse);
            //}
            //catch (Exception ex)
            //{

            //}

            paymentresponseVOsobj.AdditionalInfo3_18 = Params[28];
            if (paymentresponseVOsobj.AdditionalInfo3_18 == "CFE")
            {
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
                //string s = Params[40]; ;
                //string[] date = s.Split(' ');
                //string[] newdate = date[0].ToString().Split('/');
                ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                ////string[] date = 
                ////string[] newdate = date[0].ToString().Split('/');
                //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                string[] date = Params[40].Split(' ');
                string[] newdate = date[0].ToString().Split('/');
                paymentresponseVOsobj.TxnDate_13 =
                    newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
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
                paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//

                if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
                {
                    DataSet dspaydtls = new DataSet();
                    if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                    {
                        dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                        {
                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                        }
                    }
                    else
                    {
                        dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

                if (paymentresponseVOsobj.AuthStatus_14 == "Success")// sucess payment done.
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
            //kotak code
        }
        if (paymentresponseVOsobj.AdditionalInfo3_18 == "CFO")
        {
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
            paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                //+ " " + date[1].ToString();
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
            paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//



            if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
            {
                DataSet dspaydtls = new DataSet();
                if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                {
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                    {
                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                    }
                }
                else
                {
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

            if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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

        if (paymentresponseVOsobj.AdditionalInfo3_18 == "REN")
        {
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
            paymentresponseVOsobj.TxnDate_13 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
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
            paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//

            if (paymentresponseVOsobj.AdditionalInfo4_19 == "NODEPT")
            {
                DataSet dspaydtls = new DataSet();
                if (paymentresponseVOsobj.AdditionalInfo5_20 == "Y")
                {
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                    {
                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                    }
                }
                else
                {
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

            if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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
        if (paymentresponseVOsobj.AdditionalInfo3_18 == "PLOT")
        {
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
            //string s = Params[40]; ;
            //string[] date = s.Split(' ');
            //string[] newdate = date[0].ToString().Split('/');
            ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
            ////string[] date = 
            ////string[] newdate = date[0].ToString().Split('/');
            //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
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
            paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


            //Response.Write("paymentresponseVOsobj.MerchantID_0 = " + paymentresponseVOsobj.MerchantID_0.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.CustomerID_1 = " + paymentresponseVOsobj.CustomerID_1.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.TxnReferenceNo_2 = " + paymentresponseVOsobj.TxnReferenceNo_2.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.BankReferenceNo_3 = " + paymentresponseVOsobj.BankReferenceNo_3.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.TxnAmount_4 = " + paymentresponseVOsobj.TxnAmount_4.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.BankID_5 = " + paymentresponseVOsobj.BankID_5.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.BIN_6 = " + paymentresponseVOsobj.BIN_6.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.TxnType_7 = " + paymentresponseVOsobj.TxnType_7.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.CurrencyName_8 = " + paymentresponseVOsobj.CurrencyName_8.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.ItemCode_9 = " + paymentresponseVOsobj.ItemCode_9.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.SecurityType_10 = " + paymentresponseVOsobj.SecurityType_10.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.SecurityID_11 = " + paymentresponseVOsobj.SecurityID_11.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.SecurityPassword_12 = " + paymentresponseVOsobj.SecurityPassword_12.ToString() + "<br>");

            //Response.Write("paymentresponseVOsobj.TxnDate_13 = " + paymentresponseVOsobj.TxnDate_13.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AuthStatus_14 = " + paymentresponseVOsobj.AuthStatus_14.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.SettlementType_15 = " + paymentresponseVOsobj.SettlementType_15.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_16 = " + paymentresponseVOsobj.AdditionalInfo1_16.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_17 = " + paymentresponseVOsobj.AdditionalInfo2_17.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_18 = " + paymentresponseVOsobj.AdditionalInfo3_18.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_19 = " + paymentresponseVOsobj.AdditionalInfo4_19.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_20 = " + paymentresponseVOsobj.AdditionalInfo5_20.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_21 = " + paymentresponseVOsobj.AdditionalInfo6_21.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.AdditionalInfo1_22 = " + paymentresponseVOsobj.AdditionalInfo7_22.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.ErrorStatus_23 = " + paymentresponseVOsobj.ErrorStatus_23.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.ErrorDescription_24 = " + paymentresponseVOsobj.ErrorDescription_24.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.CheckSum_25 = " + paymentresponseVOsobj.CheckSum_25.ToString() + "<br>");
            //Response.Write("paymentresponseVOsobj.Createdby = " + paymentresponseVOsobj.Createdby.ToString() + "<br>");


            //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

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
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                    //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                    if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                    {
                        paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                    }
                }
                else
                {
                    dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

            if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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

    }



    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtuidno.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Online Order Number..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
            string workingKey = "9B383382630D206B91CCF862546AF22A";//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = txtuidno.Text.Trim(); //ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            //string encResponse = "order_id=MIC020001248732CFO&tracking_id=107437484769&bank_ref_no=245886&order_status=Success&failure_message=&payment_mode=Debit Card&card_name=MasterCard Debit Card&status_code=null&status_message=Success&currency=INR&amount=500.0&billing_name=&billing_address=&billing_city=&billing_state=&billing_zip=&billing_country=&billing_tel=&billing_email=&delivery_name=&delivery_address=&delivery_city=&delivery_state=&delivery_zip=&delivery_country=&delivery_tel=&merchant_param1=7813&merchant_param2=Kotak20180921145706&merchant_param3=CFO&merchant_param4=NODEPT&merchant_param5=NA&vault=N&offer_type=null&offer_code=null&discount_value=0.0&mer_amount=500.0&eci_value=02&retry=N&response_code=0&billing_notes=&trans_date=21/09/2018 14:58:12&bin_country=INDIA&trans_fee=0.0&service_tax=0.0";
            //string encResponse = "order_id=LRG01400046150&tracking_id=107421242541&bank_ref_no=179264529&order_status=Success&failure_message=&payment_mode=Net Banking&card_name=IDBI Bank&status_code=null&status_message=null&currency=INR&amount=6.72&billing_name=asd&billing_address=sas&billing_city=hyd&billing_state=telegana&billing_zip=500005&billing_country=India&billing_tel=9618445500&billing_email=sangem.madhuri@gmail.com&delivery_name=asd&delivery_address=sas&delivery_city=hyd&delivery_state=telegana&delivery_zip=500005&delivery_country=India&delivery_tel=9618445500&merchant_param1=5933&merchant_param2=Kotak20180821145855&merchant_param3=CFE&merchant_param4=NODEPT&merchant_param5=NA&vault=N&offer_type=null&offer_code=null&discount_value=0.0&mer_amount=2.0&eci_value=null&retry=N&response_code=0&billing_notes=&trans_date=21/08/2018 15:00:44&bin_country=&trans_fee=4.0&service_tax=0.72";
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
                //string BilldeskResponse = txtuidno.Text.Trim();
                //try
                //{
                //    GetTESTVALUES(BilldeskResponse);
                //}
                //catch (Exception ex)
                //{

                //}

                paymentresponseVOsobj.AdditionalInfo3_18 = Params[28];
                if (paymentresponseVOsobj.AdditionalInfo3_18 == "CFE")
                {
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
                    //string s = Params[40]; ;
                    //string[] date = s.Split(' ');
                    //string[] newdate = date[0].ToString().Split('/');
                    ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                    ////string[] date = 
                    ////string[] newdate = date[0].ToString().Split('/');
                    //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
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
                    paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                    //Response.Write("paymentresponseVOsobj.MerchantID_0 = " + paymentresponseVOsobj.MerchantID_0.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.CustomerID_1 = " + paymentresponseVOsobj.CustomerID_1.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.TxnReferenceNo_2 = " + paymentresponseVOsobj.TxnReferenceNo_2.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.BankReferenceNo_3 = " + paymentresponseVOsobj.BankReferenceNo_3.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.TxnAmount_4 = " + paymentresponseVOsobj.TxnAmount_4.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.BankID_5 = " + paymentresponseVOsobj.BankID_5.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.BIN_6 = " + paymentresponseVOsobj.BIN_6.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.TxnType_7 = " + paymentresponseVOsobj.TxnType_7.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.CurrencyName_8 = " + paymentresponseVOsobj.CurrencyName_8.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.ItemCode_9 = " + paymentresponseVOsobj.ItemCode_9.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.SecurityType_10 = " + paymentresponseVOsobj.SecurityType_10.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.SecurityID_11 = " + paymentresponseVOsobj.SecurityID_11.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.SecurityPassword_12 = " + paymentresponseVOsobj.SecurityPassword_12.ToString() + "<br>");

                    //Response.Write("paymentresponseVOsobj.TxnDate_13 = " + paymentresponseVOsobj.TxnDate_13.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AuthStatus_14 = " + paymentresponseVOsobj.AuthStatus_14.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.SettlementType_15 = " + paymentresponseVOsobj.SettlementType_15.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_16 = " + paymentresponseVOsobj.AdditionalInfo1_16.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_17 = " + paymentresponseVOsobj.AdditionalInfo2_17.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_18 = " + paymentresponseVOsobj.AdditionalInfo3_18.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_19 = " + paymentresponseVOsobj.AdditionalInfo4_19.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_20 = " + paymentresponseVOsobj.AdditionalInfo5_20.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_21 = " + paymentresponseVOsobj.AdditionalInfo6_21.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.AdditionalInfo1_22 = " + paymentresponseVOsobj.AdditionalInfo7_22.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.ErrorStatus_23 = " + paymentresponseVOsobj.ErrorStatus_23.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.ErrorDescription_24 = " + paymentresponseVOsobj.ErrorDescription_24.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.CheckSum_25 = " + paymentresponseVOsobj.CheckSum_25.ToString() + "<br>");
                    //Response.Write("paymentresponseVOsobj.Createdby = " + paymentresponseVOsobj.Createdby.ToString() + "<br>");


                    //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

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
                            dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                            //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                            if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                            {
                                paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                            }
                        }
                        else
                        {
                            dspaydtls = objgen.GetEnterprinerpaymentDtls(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

                    if (paymentresponseVOsobj.AuthStatus_14 == "Success")// sucess payment done.
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
                //kotak code
            }
            if (paymentresponseVOsobj.AdditionalInfo3_18 == "CFO")
            {
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
                //string s = Params[40]; ;
                //string[] date = s.Split(' ');
                //string[] newdate = date[0].ToString().Split('/');
                ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                ////string[] date = 
                ////string[] newdate = date[0].ToString().Split('/');
                //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
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
                paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                //Response.Write("paymentresponseVOsobj.MerchantID_0 = " + paymentresponseVOsobj.MerchantID_0.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CustomerID_1 = " + paymentresponseVOsobj.CustomerID_1.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnReferenceNo_2 = " + paymentresponseVOsobj.TxnReferenceNo_2.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankReferenceNo_3 = " + paymentresponseVOsobj.BankReferenceNo_3.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnAmount_4 = " + paymentresponseVOsobj.TxnAmount_4.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankID_5 = " + paymentresponseVOsobj.BankID_5.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BIN_6 = " + paymentresponseVOsobj.BIN_6.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnType_7 = " + paymentresponseVOsobj.TxnType_7.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CurrencyName_8 = " + paymentresponseVOsobj.CurrencyName_8.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ItemCode_9 = " + paymentresponseVOsobj.ItemCode_9.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityType_10 = " + paymentresponseVOsobj.SecurityType_10.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityID_11 = " + paymentresponseVOsobj.SecurityID_11.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityPassword_12 = " + paymentresponseVOsobj.SecurityPassword_12.ToString() + "<br>");

                //Response.Write("paymentresponseVOsobj.TxnDate_13 = " + paymentresponseVOsobj.TxnDate_13.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AuthStatus_14 = " + paymentresponseVOsobj.AuthStatus_14.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SettlementType_15 = " + paymentresponseVOsobj.SettlementType_15.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_16 = " + paymentresponseVOsobj.AdditionalInfo1_16.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_17 = " + paymentresponseVOsobj.AdditionalInfo2_17.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_18 = " + paymentresponseVOsobj.AdditionalInfo3_18.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_19 = " + paymentresponseVOsobj.AdditionalInfo4_19.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_20 = " + paymentresponseVOsobj.AdditionalInfo5_20.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_21 = " + paymentresponseVOsobj.AdditionalInfo6_21.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_22 = " + paymentresponseVOsobj.AdditionalInfo7_22.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorStatus_23 = " + paymentresponseVOsobj.ErrorStatus_23.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorDescription_24 = " + paymentresponseVOsobj.ErrorDescription_24.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CheckSum_25 = " + paymentresponseVOsobj.CheckSum_25.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.Createdby = " + paymentresponseVOsobj.Createdby.ToString() + "<br>");


                //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

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
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                        {
                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                        }
                    }
                    else
                    {
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsCfo(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

                if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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

            if (paymentresponseVOsobj.AdditionalInfo3_18 == "REN")
            {
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
                //string s = Params[40]; ;
                //string[] date = s.Split(' ');
                //string[] newdate = date[0].ToString().Split('/');
                ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                ////string[] date = 
                ////string[] newdate = date[0].ToString().Split('/');
                //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
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
                paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                //Response.Write("paymentresponseVOsobj.MerchantID_0 = " + paymentresponseVOsobj.MerchantID_0.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CustomerID_1 = " + paymentresponseVOsobj.CustomerID_1.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnReferenceNo_2 = " + paymentresponseVOsobj.TxnReferenceNo_2.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankReferenceNo_3 = " + paymentresponseVOsobj.BankReferenceNo_3.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnAmount_4 = " + paymentresponseVOsobj.TxnAmount_4.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankID_5 = " + paymentresponseVOsobj.BankID_5.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BIN_6 = " + paymentresponseVOsobj.BIN_6.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnType_7 = " + paymentresponseVOsobj.TxnType_7.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CurrencyName_8 = " + paymentresponseVOsobj.CurrencyName_8.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ItemCode_9 = " + paymentresponseVOsobj.ItemCode_9.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityType_10 = " + paymentresponseVOsobj.SecurityType_10.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityID_11 = " + paymentresponseVOsobj.SecurityID_11.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityPassword_12 = " + paymentresponseVOsobj.SecurityPassword_12.ToString() + "<br>");

                //Response.Write("paymentresponseVOsobj.TxnDate_13 = " + paymentresponseVOsobj.TxnDate_13.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AuthStatus_14 = " + paymentresponseVOsobj.AuthStatus_14.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SettlementType_15 = " + paymentresponseVOsobj.SettlementType_15.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_16 = " + paymentresponseVOsobj.AdditionalInfo1_16.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_17 = " + paymentresponseVOsobj.AdditionalInfo2_17.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_18 = " + paymentresponseVOsobj.AdditionalInfo3_18.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_19 = " + paymentresponseVOsobj.AdditionalInfo4_19.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_20 = " + paymentresponseVOsobj.AdditionalInfo5_20.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_21 = " + paymentresponseVOsobj.AdditionalInfo6_21.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_22 = " + paymentresponseVOsobj.AdditionalInfo7_22.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorStatus_23 = " + paymentresponseVOsobj.ErrorStatus_23.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorDescription_24 = " + paymentresponseVOsobj.ErrorDescription_24.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CheckSum_25 = " + paymentresponseVOsobj.CheckSum_25.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.Createdby = " + paymentresponseVOsobj.Createdby.ToString() + "<br>");


                //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

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
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                        {
                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                        }
                    }
                    else
                    {
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsRenewal(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

                if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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
            if (paymentresponseVOsobj.AdditionalInfo3_18 == "PLOT")
            {
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
                //string s = Params[40]; ;
                //string[] date = s.Split(' ');
                //string[] newdate = date[0].ToString().Split('/');
                ////string ss = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
                ////string[] date = 
                ////string[] newdate = date[0].ToString().Split('/');
                //paymentresponseVOsobj.TxnDate_13 = newdate[0].ToString() + "/" + newdate[1].ToString() + "/" + newdate[2].ToString();
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
                paymentresponseVOsobj.Createdby = Session["uid"].ToString();   //"17311";//


                //Response.Write("paymentresponseVOsobj.MerchantID_0 = " + paymentresponseVOsobj.MerchantID_0.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CustomerID_1 = " + paymentresponseVOsobj.CustomerID_1.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnReferenceNo_2 = " + paymentresponseVOsobj.TxnReferenceNo_2.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankReferenceNo_3 = " + paymentresponseVOsobj.BankReferenceNo_3.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnAmount_4 = " + paymentresponseVOsobj.TxnAmount_4.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BankID_5 = " + paymentresponseVOsobj.BankID_5.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.BIN_6 = " + paymentresponseVOsobj.BIN_6.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.TxnType_7 = " + paymentresponseVOsobj.TxnType_7.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CurrencyName_8 = " + paymentresponseVOsobj.CurrencyName_8.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ItemCode_9 = " + paymentresponseVOsobj.ItemCode_9.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityType_10 = " + paymentresponseVOsobj.SecurityType_10.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityID_11 = " + paymentresponseVOsobj.SecurityID_11.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SecurityPassword_12 = " + paymentresponseVOsobj.SecurityPassword_12.ToString() + "<br>");

                //Response.Write("paymentresponseVOsobj.TxnDate_13 = " + paymentresponseVOsobj.TxnDate_13.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AuthStatus_14 = " + paymentresponseVOsobj.AuthStatus_14.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.SettlementType_15 = " + paymentresponseVOsobj.SettlementType_15.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_16 = " + paymentresponseVOsobj.AdditionalInfo1_16.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_17 = " + paymentresponseVOsobj.AdditionalInfo2_17.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_18 = " + paymentresponseVOsobj.AdditionalInfo3_18.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_19 = " + paymentresponseVOsobj.AdditionalInfo4_19.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_20 = " + paymentresponseVOsobj.AdditionalInfo5_20.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_21 = " + paymentresponseVOsobj.AdditionalInfo6_21.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.AdditionalInfo1_22 = " + paymentresponseVOsobj.AdditionalInfo7_22.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorStatus_23 = " + paymentresponseVOsobj.ErrorStatus_23.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.ErrorDescription_24 = " + paymentresponseVOsobj.ErrorDescription_24.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.CheckSum_25 = " + paymentresponseVOsobj.CheckSum_25.ToString() + "<br>");
                //Response.Write("paymentresponseVOsobj.Createdby = " + paymentresponseVOsobj.Createdby.ToString() + "<br>");


                //Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");

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
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, paymentresponseVOsobj.AdditionalInfo5_20);
                        //Departmentdetails (Questionnaire id#Entrepreneur id1#Department id1#TSIPASSUID#amount1#ApprovalId)
                        if (dspaydtls != null && dspaydtls.Tables.Count > 1 && dspaydtls.Tables[1].Rows.Count > 0)
                        {
                            paymentresponseVOsobj.AdditionalInfo4_19 = dspaydtls.Tables[1].Rows[0]["DEPTPAYMENTDTLS"].ToString();
                        }
                    }
                    else
                    {
                        dspaydtls = objgen.GetEnterprinerpaymentDtlsTSIIC(paymentresponseVOsobj.CustomerID_1, paymentresponseVOsobj.AdditionalInfo2_17, "");
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

                if (paymentresponseVOsobj.AuthStatus_14 == "Success")
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


        }
        catch (Exception ex)
        {

        }
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


}
