using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for SBHChallan
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SBHChallan : System.Web.Services.WebService {
    comFunctions cmf = new comFunctions();
    public SBHChallan () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    string connectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();

    [WebMethod]
    public DataSet GetChallanDetails(string Credentials)
    {
        try
        {
            if (Credentials.ToUpper() == "SBH@2016#")
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetALLChallanDetails";
                // cmd.Parameters.AddWithValue("@ChallanReference", sChallanRefNo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                LogErrorToText1("Wrong Credentials");
                return null;
            }
        }
        catch (Exception ex)
        {
            LogErrorToText(ex);
            return null;// +ex.Message;
        }
        //return "Hello World";
    }
    [WebMethod]
    public DataTable GetReferenceNumber(string sChallanRefNo)
    {
        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetChallanReFDetails";
            cmd.Parameters.AddWithValue("@ChallanReference", sChallanRefNo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            LogErrorToText(ex);
            return null;// +ex.Message;
        }
    }
    [WebMethod]
    public string UpdatePaymentDetails(string refno, string coldate, string colbranch, string bankrefno, string modeofpay, string chqno, string chqdt, string micrno)
    {
        try
        {
            if (modeofpay != "C" && modeofpay != "T" && chqno.Length == 6 && chqdt != null && chqdt != "" && micrno != null && micrno != "" && micrno.Length == 9)
            {
                //string sColldate = coldate;
                //DateTime dtColDate;
                //DateTime temp;
                //if (sColldate !="")
                //{
                //    dtColDate = Convert.ToDateTime(Convert.ToDateTime(coldate).ToString("yyyy-MM-dd"));
                //}
                //else
                //{
                //    dtColDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                //}

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_SBH_Payment_Dts";
                cmd.Parameters.AddWithValue("@ChallanRefNo", refno);
                cmd.Parameters.AddWithValue("@Recepit_Date",cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@Paid_At", "Chaln");
                cmd.Parameters.AddWithValue("@Pay_Mode", modeofpay);
                cmd.Parameters.AddWithValue("@Status", colbranch);
                cmd.Parameters.AddWithValue("@Remarks", colbranch);
                cmd.Parameters.AddWithValue("@Bank_id", "SBH");
                cmd.Parameters.AddWithValue("@Bank_RefNo", bankrefno);
                cmd.Parameters.AddWithValue("@Transaction_Date", cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@ChequeNumber", chqno);
                cmd.Parameters.AddWithValue("@ChequeDate", chqdt);
                cmd.Parameters.AddWithValue("@MICR_Number", micrno);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "A")
                    {
                        LogErrorToText1("Transaction Successfully,Challan No: " + refno);
                        return "s|Transaction Successfully";
                    }
                    else
                    {
                        LogErrorToText1(ds.Tables[0].Rows[0][0].ToString() + ",Challan No: " + refno);
                        return "f|Transaction Failed due Invalid Data";
                    }
                }
                else
                {
                    LogErrorToText1("Invalid Data From Client" + ",Challan No: " + refno);
                    return "f|Invalid data from client";
                }

            }
            else if (modeofpay == "C" || modeofpay == "T")
            {
                //string sColldate = coldate;
                //DateTime dtColDate;
                //DateTime temp;
                //if (sColldate != "")
                //{
                //    dtColDate =Convert.ToDateTime( Convert.ToDateTime(coldate).ToString("yyyy-MM-dd"));
                //}
                //else
                //{
                //    dtColDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                //}
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_SBH_Payment_Dts";

                cmd.Parameters.AddWithValue("@ChallanRefNo", refno);
                cmd.Parameters.AddWithValue("@Recepit_Date", cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@Paid_At", "Chaln");
                cmd.Parameters.AddWithValue("@Pay_Mode", modeofpay);
                cmd.Parameters.AddWithValue("@Status", colbranch);
                cmd.Parameters.AddWithValue("@Remarks", colbranch);
                cmd.Parameters.AddWithValue("@Bank_id", "SBH");
                cmd.Parameters.AddWithValue("@Bank_RefNo", bankrefno);
                cmd.Parameters.AddWithValue("@Transaction_Date", cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@ChequeNumber", 0);
                cmd.Parameters.AddWithValue("@ChequeDate", "");
                cmd.Parameters.AddWithValue("@MICR_Number", "");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "A")
                    {
                        LogErrorToText1("Transaction SuccessfullyChallan No: " + refno);
                        return "s|Transaction Successfully";
                    }
                    else
                    {
                        LogErrorToText1(ds.Tables[0].Rows[0][0].ToString() + ",Challan No: " + refno);
                        return "f|Transaction Failed due Invalid Data";
                    }
                }
                else
                {
                    LogErrorToText1("Invalid Data From Client" + ",Challan No: " + refno);
                    return "f|Invalid data from client";
                }



            }
            else if (modeofpay == "Q")
            {
                //string sColldate = coldate;
                //DateTime dtColDate;
                //DateTime temp;
                //if (sColldate != "")
                //{
                //    dtColDate =Convert.ToDateTime( Convert.ToDateTime(coldate).ToString("yyyy-MM-dd"));
                //}
                //else
                //{
                //    dtColDate = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd"));
                //}
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert_SBH_Payment_Dts";

                cmd.Parameters.AddWithValue("@ChallanRefNo", refno);
                cmd.Parameters.AddWithValue("@Recepit_Date", cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@Paid_At", "Chaln");
                cmd.Parameters.AddWithValue("@Pay_Mode", modeofpay);
                cmd.Parameters.AddWithValue("@Status", colbranch);
                cmd.Parameters.AddWithValue("@Remarks", colbranch);
                cmd.Parameters.AddWithValue("@Bank_id", "SBH");
                cmd.Parameters.AddWithValue("@Bank_RefNo", bankrefno);
                cmd.Parameters.AddWithValue("@Transaction_Date", cmf.convertDateIndia(coldate));
                cmd.Parameters.AddWithValue("@ChequeNumber", chqno);
                cmd.Parameters.AddWithValue("@ChequeDate", chqdt);
                cmd.Parameters.AddWithValue("@MICR_Number", "");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "A")
                    {
                        LogErrorToText1("Transaction SuccessfullyChallan No: " + refno);
                        return "s|Transaction Successfully";
                    }
                    else
                    {
                        LogErrorToText1(ds.Tables[0].Rows[0][0].ToString() + ",Challan No: " + refno);
                        return "f|Transaction Failed due Invalid Data";
                    }
                }
                else
                {
                    LogErrorToText1("Invalid Data From Client" + ",Challan No: " + refno);
                    return "f|Invalid data from client";
                }



            }
            else
            {
                LogErrorToText1("Invalid data from client,Cheque or DD Or MicrNumber wrong entry " + "Cheque date " + chqdt + "Cheque No " + chqno + "Micr no " + micrno);
                return "f|Invalid data from client";
            }

        }
        catch (Exception ex)
        {
            LogErrorToText(ex);
            return "f|failed due to error in server";
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
        string filePath = HttpContext.Current.Server.MapPath("SBHErrorLog.txt");
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
        string filePath = HttpContext.Current.Server.MapPath("ErrorLog.txt");
        if (System.IO.File.Exists(filePath))
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
            writer.WriteLine(sb.ToString());
            writer.Flush();
            writer.Close();
        }
    }
    
}

