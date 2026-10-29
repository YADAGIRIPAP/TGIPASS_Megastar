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
public partial class PaymentResponse : System.Web.UI.Page
{
   
    DataSet ds = new DataSet();

    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Request.Form["encData"] != null)
                {
                    string EncodedKey = "drnsAzyQ03VDnbXO2kk11Q=="; //"wImKoNvsqbSswM/bO0FT4A==";
                    int keysize = 128;
                    string sResponse = Request.Form["encData"];
                    //"22YoS1orL0fQYWkq8Jtwm9CvEWceaNnqKde2LPlYCiTr0lz4tMTyhjVo/IQD3GOHl5+CLz/hBGtvUyeHV9MMLY/ueEWNwMv8sCpqrhTMJJvjhXdF2I2vaSPo92b1T2uTcRga1Ai9Q9giPZ0y0WH8jAUMWqkDJPgk6VnXfFb51dKgMlQ6NkGD39ZQ+XL49P7dYNExfWy7nxJkrbcvpmJ5Ii/Wwd9FqTsPu5CA7+TOelY="; //Request.Form["encData"];
                    Response.Write(sResponse + "\n");

                    string respActualValues = AES128Bit.Decrypt(sResponse, EncodedKey, keysize);

                    LogErrorToText1(respActualValues);
                    Response.Write(respActualValues);

                    string[] values = respActualValues.Split('|');
                    if(values[2].ToUpper().Trim() == "SUCCESS")
                    {
                        txtMerchntOrderNo.Text = values[0];
                        txtePayRefId.Text = values[1];
                        txtStatus.Text = values[2];
                        txtAmount.Text = values[3];
                        txtCurrency.Text = values[4];
                        txtPayMode.Text = values[5];
                        txtOthDetails.Text = values[6];
                        txtReason.Text = values[7];
                        txtBankCode.Text = values[8];
                        txtBankRefNumber.Text = values[9];
                        txtTransDate.Text = values[10];
                        txtCountry.Text = values[11];

                        string[] Date = txtTransDate.Text.Split(' ');
                        string[] fDate = Date[0].Split('-');
                        string ActValue = fDate[2] + "/" + fDate[1] + "/" + fDate[0];// +" " + Date[1];

                        SqlConnection conn = new SqlConnection(constring);
                        if(conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        SqlCommand cmd1 = new SqlCommand("InsertSBIPaymentDetails", conn);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@OrderNo", txtMerchntOrderNo.Text);
                        cmd1.Parameters.AddWithValue("@Receipt_No", txtePayRefId.Text);
                        cmd1.Parameters.AddWithValue("@Receipt_Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                        cmd1.Parameters.AddWithValue("@Paid_At", "SBI");
                        cmd1.Parameters.AddWithValue("@Pay_Mode", txtPayMode.Text);
                        cmd1.Parameters.AddWithValue("@TSipass_UID", txtOthDetails.Text);
                        cmd1.Parameters.AddWithValue("@Paid_Amt", txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : Convert.ToDecimal("0"));
                        cmd1.Parameters.AddWithValue("@Status", txtStatus.Text);
                        cmd1.Parameters.AddWithValue("@Remarks", txtReason.Text);
                        cmd1.Parameters.AddWithValue("@Bank_id", txtBankCode.Text);
                        cmd1.Parameters.AddWithValue("@Bank_RefNo", txtBankRefNumber.Text);
                        cmd1.Parameters.AddWithValue("@Transaction_Date", ActValue);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet ds = new DataSet();
                        da1.Fill(ds);
                        conn.Close();                        

                        if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            if(ds.Tables[0].Rows[0][0].ToString() == "A")
                            {
                                LogErrorToText1("Payment done successfully,Reference number: " + txtMerchntOrderNo.Text);
                                
                                Session["Amount"] = values[3];
                                Session["RefNo"] = "SBI";
                                Session["TranRefNo"] = txtMerchntOrderNo.Text;

                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='PrintReceipt.aspx';", true);
                            }
                            else
                            {
                                LogErrorToText1("Payment failed at our db,Reference number: " + txtMerchntOrderNo.Text);
                               
                                SqlConnection conn1 = new SqlConnection(constring);
                                if (conn1.State == ConnectionState.Closed)
                                {
                                    conn1.Open();
                                }
                                SqlCommand cmd2 = new SqlCommand("InsertERRORDetails", conn1);
                                cmd2.CommandType = CommandType.StoredProcedure;
                                cmd2.Parameters.AddWithValue("@OrderNo", txtMerchntOrderNo.Text);
                                cmd2.Parameters.AddWithValue("@Receipt_No", txtePayRefId.Text);
                                cmd2.Parameters.AddWithValue("@Receipt_Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                                cmd2.Parameters.AddWithValue("@Paid_At", "SBI");
                                cmd2.Parameters.AddWithValue("@Pay_Mode", txtPayMode.Text);
                                cmd2.Parameters.AddWithValue("@TSipass_UID", txtOthDetails.Text);
                                cmd2.Parameters.AddWithValue("@Paid_Amt", txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : Convert.ToDecimal("0"));
                                cmd2.Parameters.AddWithValue("@Status", txtStatus.Text);
                                cmd2.Parameters.AddWithValue("@Remarks", txtReason.Text);
                                cmd2.Parameters.AddWithValue("@Bank_id", txtBankCode.Text);
                                cmd2.Parameters.AddWithValue("@Bank_RefNo", txtBankRefNumber.Text);
                                cmd2.Parameters.AddWithValue("@Transaction_Date", ActValue);
                                int iEfCount = cmd2.ExecuteNonQuery();                               
                                conn1.Close();
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment ReferenceNumber is:"+txtMerchntOrderNo.Text+"');", true);
                            }
                        }
                        else
                        {
                            LogErrorToText1("Payment failed, dataset null,Reference number: " + txtMerchntOrderNo.Text);

                            SqlConnection conn1 = new SqlConnection(constring);
                            if(conn1.State == ConnectionState.Closed)
                            {
                                conn1.Open();
                            }
                            SqlCommand cmd2 = new SqlCommand("InsertERRORDetails", conn1);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@OrderNo", txtMerchntOrderNo.Text);
                            cmd2.Parameters.AddWithValue("@Receipt_No", txtePayRefId.Text);
                            cmd2.Parameters.AddWithValue("@Receipt_Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
                            cmd2.Parameters.AddWithValue("@Paid_At", "SBI");
                            cmd2.Parameters.AddWithValue("@Pay_Mode", txtPayMode.Text);
                            cmd2.Parameters.AddWithValue("@TSipass_UID", txtOthDetails.Text);
                            cmd2.Parameters.AddWithValue("@Paid_Amt", txtAmount.Text != "" ? Convert.ToDecimal(txtAmount.Text) : Convert.ToDecimal("0"));
                            cmd2.Parameters.AddWithValue("@Status", txtStatus.Text);
                            cmd2.Parameters.AddWithValue("@Remarks", txtReason.Text);
                            cmd2.Parameters.AddWithValue("@Bank_id", txtBankCode.Text);
                            cmd2.Parameters.AddWithValue("@Bank_RefNo", txtBankRefNumber.Text);
                            cmd2.Parameters.AddWithValue("@Transaction_Date", ActValue);
                            int iEfCount= cmd2.ExecuteNonQuery();                           
                            conn1.Close();
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment ReferenceNumber is:" + txtMerchntOrderNo.Text + "');", true);
                        }
                    }
                    else
                    {
                        LogErrorToText1("Payment failed at bank values: " + respActualValues);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank');", true);
                    }
                }
                else
                {
                    LogErrorToText1("Response from bank is null");
                    Response.Write("SBI PAYMENT");
                }
            }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
                LogErrorToText(ex);
            }

    }
    public static void LogErrorToText1(string ex)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("********************" + " SBI ONLINE Error Log - " + DateTime.Now + "*********************");
        sb.Append(Environment.NewLine);
        sb.Append("Error Message : " + ex);
        sb.Append(Environment.NewLine);
        //sb.Append(ex);
        sb.Append("********************" + " SBI ONLINE END Error Log *********************");
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
        sb.Append("********************" + " SBI ONLINE Error Log - " + DateTime.Now + "*********************");
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
        sb.Append("********************" + " SBI ONLINE END Error Log *********************");
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
