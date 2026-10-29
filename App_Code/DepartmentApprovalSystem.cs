using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using AjaxControlToolkit;
/// <summary>
/// Summary description for DepartmentApprovalSystem
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DepartmentApprovalSystem : System.Web.Services.WebService
{
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    General genogj = new General();
    public DepartmentApprovalSystem()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetTSIPASSdataonUIDnumber(string uidno, string Createdby)
    {
        string lblmsg = "";
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("USP_GET_TSIPASSDATA_TTAP", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() == "" || uidno.Trim() == null || uidno.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = uidno;
            }
            if (Createdby.Trim() == "" || Createdby.Trim() == null || Createdby.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
            }
            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    public string GetTSIPASSTrackeronUIDnumber(string uidno, string Approvalid)
    {
        string lblmsg = "";
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("USP_GET_CFETRACKER_DTLS_TTAP", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() == "" || uidno.Trim() == null || uidno.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNOTTAP", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNOTTAP", SqlDbType.VarChar).Value = uidno;
            }
            if (Approvalid.Trim() == "" || Approvalid.Trim() == null || Approvalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalidDRILL", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalidDRILL", SqlDbType.VarChar).Value = Approvalid;
            }
            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    public string InsertPCBNICPortalData(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (ApplicationSubmitted != "" || ApplicationSubmitted != null)
            {
                if (ApplicationSubmitted == "Y")
                {
                    if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Application Submission Date";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Downloadlink == "" || Downloadlink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (NICApplicationno == "" || NICApplicationno == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (AppealFlag != "Y")
                    {
                        if (TotalAmount == "" || TotalAmount == null)
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Total Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (PaymentStatus != "" || PaymentStatus != null)
                    {
                        if (PaymentStatus == "Y")
                        {
                            if (TransactionNo == "" || TransactionNo == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "5";
                                dr[1] = "Please Enter Transaction Number";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (TotalAmount == "" || TotalAmount == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "6";
                                dr[1] = "Please Enter Total Amount";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (PaymentDate == "" || PaymentDate == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "7";
                                dr[1] = "Please Enter PaymentDate";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (BankName == "" || BankName == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "8";
                                dr[1] = "Please Enter BankName";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr[0] = "13";
                        dr[1] = "Please Enter Payment Status Y/N'";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "12";
                    dr[1] = "Please Application Submitted 'Y'";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                result = insertpcbnicdata(intCFEEnterpid, intQuessionaireid, ApplicationSubmitted, ApplicationSubmissionDate, PaymentStatus, TransactionNo, PaymentDate, BankName, TotalAmount, Downloadlink, NICApplicationno, AppealFlag);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string DepartmentApprovalProcess(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (intApprovalid == "73" || intApprovalid == "74" || intApprovalid == "75")
            {
                DataSet dsuidno = new DataSet();
                dsuidno = GetDepartmentFileno(UID);
                string intQuessionaireidcfo = ""; string intCFoEnterpid = ""; string UIDno = "";
                if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireidcfo = dsuidno.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                    intCFoEnterpid = dsuidno.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                    UIDno = dsuidno.Tables[0].Rows[0]["UID_No"].ToString();
                }
                string outputmsg = DepartmentApprovalProcessCFO(intQuessionaireidcfo, intCFoEnterpid, UIDno, intDeptid, intApprovalid, intStageid, Querytype, Query_Raised_Text, AdditionalAmount,
                      additionaldocs, Trans_Date, Created_by, Sysip);
                return outputmsg;
            }

            if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
            {
                DataSet dsuidno = new DataSet();
                dsuidno = GetDepartmentonuid(UID);
                if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                    intCFEEnterpid = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                }
            }

            if (intDeptid == "1")
            {
                DataSet dsuidno1 = new DataSet();
                dsuidno1 = GetDepartmentonuid(intQuessionaireid);
                if (dsuidno1 != null && dsuidno1.Tables.Count > 0 && dsuidno1.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireid = dsuidno1.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                    intCFEEnterpid = dsuidno1.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                }
            }

            result = insertDepartmentProcess(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            string errorvalue = "";
            errorvalue = Getchildandparentdata(intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, intStageid, Querytype);
            if (errorvalue != "")
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = errorvalue;
                dt.Rows.Add(dr);
                valid = 1;
                DataSet dserror = new DataSet();
                dserror.Tables.Add(dt);
                lblmsg = dserror.GetXml();
                return lblmsg;
            }

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    // 1 –additional docs,2-additional payment,3-others

                    if (Querytype == "1" || Querytype == "3")
                    {
                        int j = UpdateAdditionalpayments(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip, "");
                        int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                        DataSet dsMail = new DataSet();
                    }
                    else if (Querytype == "2")
                    {
                        if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
                        {
                            int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip, additionaldocs);
                            try
                            {
                                int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip, "");
                            try
                            {
                                int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        // int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    }

                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpayments(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip, "");
                try
                {
                    int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }
            else if (intStageid == "16")
            {
                if (Query_Raised_Text != "")
                {

                    if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
                    {
                        int j = UpdateAdditionalpaymentsBeforePre(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip, additionaldocs);
                        try
                        {
                            int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        int j = UpdateAdditionalpaymentsBeforePre(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip, "");
                        try
                        {
                            int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertDepartmentProcess(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertDepartmentProcess_WebSrvc]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
    public int UpdateAdditionalpayments(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string dcletter)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdatetDeptApprovalnew_Websrvc]";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();


        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (dcletter.Trim() == "" || dcletter.Trim() == null)
            com.Parameters.Add("@DCLetter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DCLetter", SqlDbType.VarChar).Value = dcletter.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedata(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertQueriesDetails_Websrvc]";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetShowEmailidandMobileNumber(string intQuessionaireid, string approvalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetShowEmailidandMobileNumber_websrv]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            da.SelectCommand.Parameters.Add("@approvalid", SqlDbType.VarChar).Value = approvalid.ToString();

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
    public int UpdateAdditionalpaymentsBeforePre(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress, string RejectedLetter)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdatetDeptApprovalnewBeforePre_Websrvc]";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();

        if (RejectedLetter.Trim() == "" || RejectedLetter.Trim() == null)
            com.Parameters.Add("@RejectedLetter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RejectedLetter", SqlDbType.VarChar).Value = RejectedLetter.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUpload(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        if (intApprovalid == "73" || intApprovalid == "74" || intApprovalid == "75")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentFileno(intQuessionaireid);
            string intQuessionaireidcfo = ""; string intCFoEnterpid = ""; string UIDno = "";
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireidcfo = dsuidno.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                intCFoEnterpid = dsuidno.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                UIDno = dsuidno.Tables[0].Rows[0]["UID_No"].ToString();
            }
            string output = DepartmentApprovalProcessAndCertificateUploadCFO(intQuessionaireidcfo, intCFoEnterpid, intApprovalid, intDeptid, intStageid, FileName, FilePath, Remarks, FileRefNo, Modified_by);
            return output;
        }

        if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuid(intQuessionaireid);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }
        if (intDeptid == "1")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuid(intQuessionaireid);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }

        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertImagedataApproval(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "ApprovalDocument", "", Modified_by, intDeptid, intApprovalid);

                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificate(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    //result = UpdCommissionerApprovalNew(EnterprenuerId, intDeptid, intApprovalid, "15", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else if (intStageid == "15")
        {
            if (intApprovalid == "25" || intApprovalid == "4")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                //FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertImagedataApproval(intQuessionaireid, EnterprenuerId, ".pdf", FilePath, "ReleaseCertificate", "ReleaseDocument", "", Modified_by, intDeptid, intApprovalid);
            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernew(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int insertApprovalData(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[updateApprovaldata_Web_Srv]";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetStatusforCertificate(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetStatusforCertificate_Websrv]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public int UpdCommissionerApprovalNew(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Created_by, string intQid)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdCommissionerApprovalNew_websrv]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (intQid == "" || intQid == null)
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = intQid.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetShowEmailidandMobileNumbernew(string intQuessionaireid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberNew1", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

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

    public DataSet GetdataofApprovaldataAprovalbyID(string enterprenuer, string intDeptid)
    {

        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("getenterprenuerdatbyidAprovalsNew", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }
            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
        return ds;
    }

    public int InsertImagedataApproval(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[sp_InsertImageApproval_WebSrv]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadContractLabour(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertImagedataApprovalContractLabour(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "ApprovalDocument", "", Modified_by, intDeptid, intApprovalid);

                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificate(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    //result = UpdCommissionerApprovalNew(EnterprenuerId, intDeptid, intApprovalid, "15", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernew(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        //SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadPrincipalEmployer(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertImagedataApprovalPrincipalEmployer(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "ApprovalDocument", "", Modified_by, intDeptid, intApprovalid);

                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificate(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                   // result = UpdCommissionerApprovalNew(EnterprenuerId, intDeptid, intApprovalid, "15", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernew(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }


    public int InsertImagedataApprovalContractLabour(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[sp_InsertImageApproval_WebSrv_CONTRACTLABOUR]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    public int InsertImagedataApprovalPrincipalEmployer(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[sp_InsertImageApproval_WebSrv_PrincipalEmployer]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();

            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }


    // CFO
    [WebMethod]
    public string DepartmentApprovalProcessCFO(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (intDeptid == "1")
            {
                DataSet dsuidno1 = new DataSet();
                dsuidno1 = GetDepartmentonuidCFO(intQuessionaireid);
                if (dsuidno1 != null && dsuidno1.Tables.Count > 0 && dsuidno1.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireid = dsuidno1.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                    intCFEEnterpid = dsuidno1.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                }
            }

            result = insertDepartmentProcessCFO(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {

                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "3";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    if (Querytype != "2")
                    {
                        int j = UpdateAdditionalpaymentsCFO(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                        int i = insertQueryResponsedataCFO(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        int j = UpdateAdditionalpaymentsCFO(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFO", intApprovalid);
                            int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                    //int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpaymentsCFO(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                try
                {
                    int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }
            else if (intStageid == "16")
            {
                if (Query_Raised_Text != "")
                {
                    int j = UpdateAdditionalpaymentsBeforePreCFO(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip);
                    try
                    {
                        int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "5";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }
            else if (intStageid == "18")
            {
                int j = UpdateAdditionalpaymentsCFO(intCFEEnterpid, "", additionaldocs, Created_by, intStageid, intDeptid, intApprovalid, Sysip);
            }
            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "7";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "8";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadCFO(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival

        if (intDeptid == "1")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuidCFO(intQuessionaireid);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }

        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalCFObyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));

                Fileresult = InsertCFOAttachementApproval(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ApprovalDocument", intDeptid, intApprovalid);

                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);

                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificateCFO(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    result = UpdCommissionerApprovalCFONew(EnterprenuerId, intDeptid, intApprovalid, "15", "", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewCFO(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASSCFO(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int insertDepartmentProcessCFO(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcessCFO_Websrv";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsCFO(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewCFO_Websrv";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedataCFO(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertQueriesDetailsCFO_websrv";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsBeforePreCFO(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBeforePreCFO_Websrv";

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public DataSet GetdataofApprovaldataAprovalCFObyID(string enterprenuer, string intDeptid)
    {

        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[getenterprenuerdatbyidAprovalsCFONew_websrv]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }


            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {

            con.CloseConnection();

        }
        return ds;
    }

    public int InsertCFOAttachementApproval(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_CFOAttachmentDetDeptApproval_Websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }

    public int insertApprovalDataCFO(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "updateApprovaldataCFO_Web_Srv";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetStatusforCertificateCFO(string intQuessionaireCFOid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetStatusforCertificateCFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.ToString();


            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public int UpdCommissionerApprovalCFONew(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by, string intQid)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdCommissionerApprovalCFONew_Websrv";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (intQid == "" || intQid == null)
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQid", SqlDbType.VarChar).Value = intQid.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public DataSet GetShowEmailidandMobileNumbernewCFO(string intQuessionaireid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberNew1CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();



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

    public DataSet GetShowEmailidandMobileNumbernewREN(string intQuessionaireid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberNew1REN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();



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

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadContractLabourCFO(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalCFObyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertCFOAttachementApprovalContractLabour(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ApprovalDocument", intDeptid, intApprovalid);

                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificateCFO(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    result = UpdCommissionerApprovalCFONew(EnterprenuerId, intDeptid, intApprovalid, "15", "", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewCFO(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASSCFO(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }

                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadPrincipalEmployerCFO(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalCFObyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertCFOAttachementApprovalPrincipalemployer(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ApprovalDocument", intDeptid, intApprovalid);

                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificateCFO(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    result = UpdCommissionerApprovalCFONew(EnterprenuerId, intDeptid, intApprovalid, "15", "", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewCFO(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }

                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int InsertCFOAttachementApprovalContractLabour(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_CFOAttachmentDetDeptApproval_Websrv_ContractLabourCFO", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }

    public int InsertCFOAttachementApprovalPrincipalemployer(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_CFOAttachmentDetDeptApproval_Websrv_PrincipalemployerCfo", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }
    [WebMethod]
    public string DepartmentErectorCertificateUploadCFO(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalCFObyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "12")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));

                Fileresult = InsertCFOAttachementErectionPermission(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ErectionPermission", intDeptid, intApprovalid);

                i = insertErectionPermissionCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                //int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE");
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Erection Permission Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "2";
            dr[1] = "Please Enter Stage Id as 12";
            dt.Rows.Add(dr);

        }
        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewCFO(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + "Approved" + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + "Approved" + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                //}

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }


    public int InsertCFOAttachementErectionPermission(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_CFOAttachmentDetDeptErectionPermission_Websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }

    public int insertErectionPermissionCFO(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "updateApprovaldataCFO_ErectionPermission";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string HMDAAdditionalPaymentDetails(string ChallanId, string Amount, string UidNo, string IntDeptid, string IntApprovalId)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = inshmdaadditionalpaymentdetails(ChallanId, Amount, UidNo, IntDeptid, IntApprovalId);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int inshmdaadditionalpaymentdetails(string ChallanId, string Amount, string UidNo, string IntDeptid, string IntApprovalId)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_HMDAADDITIONALAMOUNT_DTLS]";

        if (ChallanId == "" || ChallanId == null)
            com.Parameters.Add("@ChallanId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ChallanId", SqlDbType.VarChar).Value = ChallanId.Trim();

        if (Amount == "" || Amount == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();

        if (UidNo == "" || UidNo == null)
            com.Parameters.Add("@UidNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UidNo", SqlDbType.VarChar).Value = UidNo;

        if (IntDeptid == "" || IntDeptid == null)
            com.Parameters.Add("@IntDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IntDeptid", SqlDbType.VarChar).Value = IntDeptid;

        if (IntApprovalId == "" || IntApprovalId == null)
            com.Parameters.Add("@IntApprovalId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IntApprovalId", SqlDbType.VarChar).Value = IntApprovalId;

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetDepartmentonuid(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_UIDNO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
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

    public int insertpcbnicdata(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_PCBNICDATA]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = ApplicationSubmitted.Trim();

        if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ApplicationSubmissionDate.Trim());

        if (PaymentStatus == "" || PaymentStatus == null)
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = PaymentStatus;

        if (TransactionNo == "" || TransactionNo == null)
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = TransactionNo.Trim();

        if (PaymentDate == "" || PaymentDate == null)
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(PaymentDate.Trim());

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (TotalAmount == "" || TotalAmount == null)
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = TotalAmount.Trim();

        if (Downloadlink == "" || Downloadlink == null)
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = Downloadlink.Trim();

        if (NICApplicationno == "" || NICApplicationno == null)
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = NICApplicationno.Trim();

        if (AppealFlag == "" || AppealFlag == null)
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = AppealFlag.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadContractLabourLicense(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival
        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                Fileresult = InsertImagedataApprovalContractLabourLicense(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "ApprovalDocument", "", Modified_by, intDeptid, intApprovalid);

                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                DataSet dscer = new DataSet();
                dscer = GetStatusforCertificate(intQuessionaireid);

                if (dscer.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    //result = UpdCommissionerApprovalNew(EnterprenuerId, intDeptid, intApprovalid, "15", Modified_by, intQuessionaireid);
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalData(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernew(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int InsertImagedataApprovalContractLabourLicense(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertImageApproval_WebSrv_ContractLabourLicense", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();

            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string InsertPCBNICPortalDataCFO(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (ApplicationSubmitted != "" || ApplicationSubmitted != null)
            {
                if (ApplicationSubmitted == "Y")
                {
                    if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Application Submission Date";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Downloadlink == "" || Downloadlink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (NICApplicationno == "" || NICApplicationno == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (AppealFlag != "Y")
                    {
                        if (TotalAmount == "" || TotalAmount == null)
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Total Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (PaymentStatus != "" || PaymentStatus != null)
                    {
                        if (PaymentStatus == "Y")
                        {
                            if (TransactionNo == "" || TransactionNo == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "5";
                                dr[1] = "Please Enter Transaction Number";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (TotalAmount == "" || TotalAmount == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "6";
                                dr[1] = "Please Enter Total Amount";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (PaymentDate == "" || PaymentDate == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "7";
                                dr[1] = "Please Enter PaymentDate";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (BankName == "" || BankName == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "8";
                                dr[1] = "Please Enter BankName";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr[0] = "13";
                        dr[1] = "Please Enter Payment Status Y/N'";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "12";
                    dr[1] = "Please Application Submitted 'Y'";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                result = insertpcbnicdataCFO(intCFEEnterpid, intQuessionaireid, ApplicationSubmitted, ApplicationSubmissionDate, PaymentStatus, TransactionNo, PaymentDate, BankName, TotalAmount, Downloadlink, NICApplicationno, AppealFlag);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertpcbnicdataCFO(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_PCBNICDATA_CFO]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = ApplicationSubmitted.Trim();

        if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ApplicationSubmissionDate.Trim());

        if (PaymentStatus == "" || PaymentStatus == null)
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = PaymentStatus;

        if (TransactionNo == "" || TransactionNo == null)
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = TransactionNo.Trim();

        if (PaymentDate == "" || PaymentDate == null)
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(PaymentDate.Trim());

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (TotalAmount == "" || TotalAmount == null)
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = TotalAmount.Trim();

        if (Downloadlink == "" || Downloadlink == null)
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = Downloadlink.Trim();

        if (NICApplicationno == "" || NICApplicationno == null)
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = NICApplicationno.Trim();

        if (AppealFlag == "" || AppealFlag == null)
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = AppealFlag.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetDepartmentonuidCFO(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_UIDNO_CFO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
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

    [WebMethod]
    public string DigitalSiteplanUpload(string Siteplandocument)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        if (Siteplandocument.Trim() != "")
        {
            int Fileresult = 0;


            StringReader str = new StringReader(Siteplandocument);
            //dco.LoadXml(xml);
            //DataSet dsout = dco.DataSet;
            DataSet dsout = new DataSet();
            dsout.ReadXml(str);
            DataTable myDtNewRecdr = new DataTable();
            string intQuessionaireid, EnterprenuerId, intApprovalid, intDeptid, FileName, FilePath;//, Remarks, FileRefNo, Modified_by,intStageid
            if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
            {
                int rawmaterialcount = dsout.Tables[0].Rows.Count;
                for (int m = 0; m < rawmaterialcount; m++)
                {

                    intQuessionaireid = dsout.Tables[0].Rows[m]["intQuessionaireid"].ToString();
                    EnterprenuerId = dsout.Tables[0].Rows[m]["EnterprenuerId"].ToString();
                    intApprovalid = dsout.Tables[0].Rows[m]["intApprovalid"].ToString();
                    intDeptid = dsout.Tables[0].Rows[m]["intDeptid"].ToString();
                    FileName = dsout.Tables[0].Rows[m]["FileName"].ToString();
                    FilePath = dsout.Tables[0].Rows[m]["FilePath"].ToString();
                    string FileType = "";
                    string[] fileType = FileName.Split('.');
                    int k = fileType.Length;
                    FileType = fileType[k - 1];
                    FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));

                    Fileresult = InsertImageDigitalSiteplan(intQuessionaireid, EnterprenuerId, FileType, FilePath, "DigitalSitePlan", FileName, "A", "1029", intDeptid, intApprovalid);
                }

            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "Please Upload Erection Permission Document";
            dt.Rows.Add(dr);

        }

        if (i != 999)
        {

            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "Status Updated Successfully";
            dt.Rows.Add(dr);

        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int InsertImageDigitalSiteplan(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[sp_InsertImageApproval_WebSrv_DigitalSitePlanUpload]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    [WebMethod]
    public string GetRegistrationNumberAndCerificate(string intQuessionairecfOid, string intCFOEnterpid, string intDeptid, string intApprovalid, string CertoficatePath, string RegistrationNumber)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireid",SqlDbType.VarChar),
               new SqlParameter("@intCFEEnterpid",SqlDbType.VarChar),
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
               new SqlParameter("@intApprovalid",SqlDbType.VarChar),
               new SqlParameter("@CertoficatePath",SqlDbType.VarChar),
               new SqlParameter("@RegistrationNumber",SqlDbType.VarChar),
               new SqlParameter("@RESPONSERROR",SqlDbType.VarChar)
           };

        pp[0].Value = intQuessionairecfOid;
        pp[1].Value = intCFOEnterpid;
        pp[2].Value = intDeptid;
        pp[3].Value = intApprovalid;
        pp[4].Value = CertoficatePath;
        pp[5].Value = RegistrationNumber;
        pp[6].Value = "0";
        pp[6].Size = 500;
        pp[6].Direction = ParameterDirection.Output;
        genogj.GenericFillDs("USP_UPDATE_BOILERSREGITRATIONNO", pp);
        string value = pp[6].Value.ToString();
        return value;
    }

    public string Getchildandparentdata(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Querytype)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@intQuessionaireid",SqlDbType.VarChar),
               new SqlParameter("@intCFEEnterpid",SqlDbType.VarChar),
               new SqlParameter("@intDeptid",SqlDbType.VarChar),
               new SqlParameter("@intApprovalid",SqlDbType.VarChar),
               new SqlParameter("@intStageid",SqlDbType.VarChar),
               new SqlParameter("@RESPONSERROR",SqlDbType.VarChar),
               new SqlParameter("@Querytype",SqlDbType.VarChar)
           };

        pp[0].Value = intQuessionaireid;
        pp[1].Value = intCFEEnterpid;
        pp[2].Value = intDeptid;
        pp[3].Value = intApprovalid;
        pp[4].Value = intStageid;
        pp[5].Value = "";
        pp[5].Size = 1000;
        pp[5].Direction = ParameterDirection.Output;
        pp[6].Value = Querytype;
        genogj.GenericFillDs("USP_CHECK_APPLICATIONSSTAGE", pp);
        string value = pp[5].Value.ToString();
        return value;
    }

    [WebMethod]
    public string DPMSPlanUpload(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival

        if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuid(intQuessionaireid);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }
        //if (intDeptid == "1")
        //{
        //    DataSet dsuidno = new DataSet();
        //    dsuidno = GetDepartmentonuid(intQuessionaireid);
        //    if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
        //    {
        //        intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
        //        EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
        //    }
        //}

        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end

        if (FileName.Trim() != "")
        {
            int Fileresult = 0;

            string FileType = "";
            string[] fileType = FileName.Split('.');
            int k = fileType.Length;
            FileType = fileType[k - 1];
            FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
            Fileresult = Insertdpmsplans(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "DPMSPlanDocument", "", Modified_by, intDeptid, intApprovalid);
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "Please Upload Plan Document";
            dt.Rows.Add(dr);

        }


        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernew(intQuessionaireid, intDeptid);

            dr = dt.NewRow();
            dr[0] = "3";
            dr[1] = "Status Updated Successfully";
            dt.Rows.Add(dr);

        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int Insertdpmsplans(string intQuessionaireid, string intCFEid, string FileType, string FilePath, string FileName, string FileDescription, string bu, string Created_by, string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("[sp_InsertImageApproval_WebSrv_Proceeding]", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEid.Trim() == "" || intCFEid.Trim() == null || intCFEid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.Int).Value = Int32.Parse(intCFEid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }

            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }

            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }

            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (bu.Trim() == "" || bu.Trim() == null || bu.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@bu", SqlDbType.VarChar).Value = bu.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }


            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    [WebMethod]

    public string InsertClarificationResponse(string intQuessionaireid, string intDeptid, string intApprovalid, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondDate,
   string QueryRespondRemarks, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            string intEnterpreniourApprovalid, intCFEEnterpid, QueryRaiseDate, QueryDescription, QueryStatus, Created_by, Created_dt, Modified_by, Modified_dt;
            int valid = 0;
            DataSet ds = new DataSet();



            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Please Provide Caf number";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (QueryRespondRemarks == "" || QueryRespondRemarks == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter Clarification Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag == "" || categoryFlag == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter category change fllag Y/N";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag != "" || categoryFlag != null)
            {
                if (categoryFlag == "Y")
                {
                    if (lineofacitivtyid == "" || lineofacitivtyid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Enter Line of Activity";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (categoryid == "" || categoryid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Provide Category Id";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                }
                //if (categoryFlag != "Y" && categoryFlag != "N")
                //{
                //    dr = dt.NewRow();
                //    dr[0] = "4";
                //    dr[1] = "Please Provide Correct Category FLAG";
                //    dt.Rows.Add(dr);
                //    valid = 1;
                //}
            }

            ds = genogj.GetQueryStatusByTransactionIDPCBCFE(intQuessionaireid);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                // hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";
                Modified_by = "";
                Modified_dt = "";




                if (valid == 0)
                {
                    result = InsertQueryDetails(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid,
     intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, QueryAttachmentFileName, QueryAttachmentFilePath,
     QueryRespondDate, QueryRespondRemarks, Created_by, Created_dt, Modified_by, Modified_dt, IPAddress, categoryFlag, lineofacitivtyid, categoryid);
                }

            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Developed By Rajesh Patnaik
    public int InsertQueryDetails(string intEnterpreniourApprovalid,
string intQuessionaireid,
string intCFEEnterpid,
string intDeptid,
string intApprovalid,
string QueryRaiseDate,
string QueryDescription,
string QueryStatus,
string QueryAttachmentFileName,
string QueryAttachmentFilePath,
string QueryRespondDate,
string QueryRespondRemarks,
string Created_by,
string Created_dt,
string Modified_by, string Modified_dt, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertQueryDetails_Webservice", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }


            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            //if (QueryRaiseDate.Trim() == "" || QueryRaiseDate.Trim() == null || QueryRaiseDate.Trim() == "--Select--")
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = QueryRaiseDate.Trim();
            //}


            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();


            //-------------------------------------------------
            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (categoryFlag.ToString().Trim() == "" || categoryFlag.ToString().Trim() == null || categoryFlag.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = categoryFlag.Trim();

            if (lineofacitivtyid.Trim() == "" || lineofacitivtyid.Trim() == null || lineofacitivtyid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = Int32.Parse(lineofacitivtyid.Trim());
            }
            if (categoryid.Trim() == "" || categoryid.Trim() == null || categoryid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = Int32.Parse(categoryid.Trim());
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    #endregion

    [WebMethod]

    public string InsertClarificationResponseCFO(string intQuessionaireid, string intDeptid, string intApprovalid, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondDate,
   string QueryRespondRemarks, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            string intEnterpreniourApprovalid, intCFEEnterpid, QueryRaiseDate, QueryDescription, QueryStatus, Created_by, Created_dt, Modified_by, Modified_dt;
            int valid = 0;
            DataSet ds = new DataSet();



            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Please Provide Caf number";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (QueryRespondRemarks == "" || QueryRespondRemarks == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter Clarification Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag == "" || categoryFlag == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter category change fllag Y/N";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag != "" || categoryFlag != null)
            {
                if (categoryFlag == "Y")
                {
                    if (lineofacitivtyid == "" || lineofacitivtyid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Enter Line of Activity";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (categoryid == "" || categoryid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Provide Category Id";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                }
                //if (categoryFlag != "Y" && categoryFlag != "N")
                //{
                //    dr = dt.NewRow();
                //    dr[0] = "4";
                //    dr[1] = "Please Provide Correct Category FLAG";
                //    dt.Rows.Add(dr);
                //    valid = 1;
                //}
            }

            ds = genogj.GetQueryStatusByTransactionIDPCBCFO(intQuessionaireid);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                // hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";
                Modified_by = "";
                Modified_dt = "";




                if (valid == 0)
                {
                    result = InsertQueryDetailsCFO(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid,
     intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, QueryAttachmentFileName, QueryAttachmentFilePath,
     QueryRespondDate, QueryRespondRemarks, Created_by, Created_dt, Modified_by, Modified_dt, IPAddress, categoryFlag, lineofacitivtyid, categoryid);
                }

            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Developed By Rajesh Patnaik
    public int InsertQueryDetailsCFO(string intEnterpreniourApprovalid,
string intQuessionaireid,
string intCFEEnterpid,
string intDeptid,
string intApprovalid,
string QueryRaiseDate,
string QueryDescription,
string QueryStatus,
string QueryAttachmentFileName,
string QueryAttachmentFilePath,
string QueryRespondDate,
string QueryRespondRemarks,
string Created_by,
string Created_dt,
string Modified_by, string Modified_dt, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertQueryDetails_Webservice_CFO", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }


            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            //if (QueryRaiseDate.Trim() == "" || QueryRaiseDate.Trim() == null || QueryRaiseDate.Trim() == "--Select--")
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = QueryRaiseDate.Trim();
            //}


            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();


            //-------------------------------------------------
            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (categoryFlag.ToString().Trim() == "" || categoryFlag.ToString().Trim() == null || categoryFlag.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = categoryFlag.Trim();

            if (lineofacitivtyid.Trim() == "" || lineofacitivtyid.Trim() == null || lineofacitivtyid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = Int32.Parse(lineofacitivtyid.Trim());
            }
            if (categoryid.Trim() == "" || categoryid.Trim() == null || categoryid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = Int32.Parse(categoryid.Trim());
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    #endregion

    [WebMethod]
    public string InsertPCBNICPortalDataREN(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (ApplicationSubmitted != "" || ApplicationSubmitted != null)
            {
                if (ApplicationSubmitted == "Y")
                {
                    if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Application Submission Date";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Downloadlink == "" || Downloadlink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (NICApplicationno == "" || NICApplicationno == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (AppealFlag != "Y")
                    {
                        if (TotalAmount == "" || TotalAmount == null)
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Total Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (PaymentStatus != "" || PaymentStatus != null)
                    {
                        if (PaymentStatus == "Y")
                        {
                            if (TransactionNo == "" || TransactionNo == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "5";
                                dr[1] = "Please Enter Transaction Number";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (TotalAmount == "" || TotalAmount == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "6";
                                dr[1] = "Please Enter Total Amount";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (PaymentDate == "" || PaymentDate == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "7";
                                dr[1] = "Please Enter PaymentDate";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (BankName == "" || BankName == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "8";
                                dr[1] = "Please Enter BankName";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr[0] = "13";
                        dr[1] = "Please Enter Payment Status Y/N'";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "12";
                    dr[1] = "Please Application Submitted 'Y'";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                result = insertpcbnicdataREN(intCFEEnterpid, intQuessionaireid, ApplicationSubmitted, ApplicationSubmissionDate, PaymentStatus, TransactionNo, PaymentDate, BankName, TotalAmount, Downloadlink, NICApplicationno, AppealFlag);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertpcbnicdataREN(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_PCBNICDATA_REN]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = ApplicationSubmitted.Trim();

        if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ApplicationSubmissionDate.Trim());

        if (PaymentStatus == "" || PaymentStatus == null)
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = PaymentStatus;

        if (TransactionNo == "" || TransactionNo == null)
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = TransactionNo.Trim();

        if (PaymentDate == "" || PaymentDate == null)
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(PaymentDate.Trim());

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (TotalAmount == "" || TotalAmount == null)
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = TotalAmount.Trim();

        if (Downloadlink == "" || Downloadlink == null)
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = Downloadlink.Trim();

        if (NICApplicationno == "" || NICApplicationno == null)
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = NICApplicationno.Trim();

        if (AppealFlag == "" || AppealFlag == null)
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = AppealFlag.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessREN(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (intDeptid == "1")
            {
                DataSet dsuidno1 = new DataSet();
                dsuidno1 = GetDepartmentonuidREN(intQuessionaireid, intCFEEnterpid);
                if (dsuidno1 != null && dsuidno1.Tables.Count > 0 && dsuidno1.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireid = dsuidno1.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                    intCFEEnterpid = dsuidno1.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                }
            }

            result = insertDepartmentProcessREN(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {

                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "3";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    if (Querytype != "2")
                    {
                        int j = UpdateAdditionalpaymentsREN(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                        int i = insertQueryResponsedataREN(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            int k = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        int j = UpdateAdditionalpaymentsREN(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip);
                        try
                        {
                            int k = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                            //int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                    //int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpaymentsREN(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                try
                {
                    //int k = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                    int k = genogj.InsertDeptDateTracingREN(intDeptid, intCFEEnterpid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "REN", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }
            else if (intStageid == "16")
            {
                if (Query_Raised_Text != "")
                {
                    int j = UpdateAdditionalpaymentsBeforePreREN(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip);
                    try
                    {
                        int k = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "5";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "7";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "8";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadREN(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival

        if (intDeptid == "1")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuidREN(intQuessionaireid, EnterprenuerId);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }

        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalRENbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));

                Fileresult = InsertRenAttachementApproval(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ApprovalDocument", intDeptid, intApprovalid);

                i = insertApprovalDataRen(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                    int M = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "REN", intApprovalid);

                }
                catch (Exception ex)
                {

                }
                //DataSet dscer = new DataSet();
                //dscer = GetStatusforCertificateCFO(intQuessionaireid);

                //if (dscer.Tables[0].Rows.Count > 0)
                //{
                //    int result = 0;
                //    result = UpdCommissionerApprovalCFONew(EnterprenuerId, intDeptid, intApprovalid, "15", "", Modified_by, intQuessionaireid);
                //}
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataRen(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                //i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    int M = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewREN(EnterprenuerId, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }

                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int insertDepartmentProcessREN(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcessREN_Websrv";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsREN(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewREN_Websrv";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedataREN(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertQueriesDetailsREN_Websrv";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsBeforePreREN(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBeforePreREN_Websrv";

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }

    }

    public DataSet GetDepartmentonuidREN(string uidno, string renid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_UIDNO_REN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (renid.Trim() != "" || renid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@renid", SqlDbType.VarChar).Value = renid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@renid", SqlDbType.VarChar).Value = null;
            }
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

    public int insertApprovalDataRen(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "updateApprovaldataREN_Web_Srv";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int InsertRenAttachementApproval(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_RENAttachmentDetDeptApproval_Websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }

    [WebMethod]

    public string InsertClarificationResponseRen(string intQuessionaireid, string intcfeid, string intDeptid, string intApprovalid, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondDate,
   string QueryRespondRemarks, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            string intEnterpreniourApprovalid, intCFEEnterpid, QueryRaiseDate, QueryDescription, QueryStatus, Created_by, Created_dt, Modified_by, Modified_dt;
            int valid = 0;
            DataSet ds = new DataSet();


            if (intcfeid == "" || intcfeid == null)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Please Provide Entrprenur Id";
                dt.Rows.Add(dr);
                valid = 1;
            }


            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Please Provide Caf number";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (QueryRespondRemarks == "" || QueryRespondRemarks == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter Clarification Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag == "" || categoryFlag == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter category change fllag Y/N";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag != "" || categoryFlag != null)
            {
                if (categoryFlag == "Y")
                {
                    if (lineofacitivtyid == "" || lineofacitivtyid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Enter Line of Activity";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (categoryid == "" || categoryid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Provide Category Id";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                }
                //if (categoryFlag != "Y" && categoryFlag != "N")
                //{
                //    dr = dt.NewRow();
                //    dr[0] = "4";
                //    dr[1] = "Please Provide Correct Category FLAG";
                //    dt.Rows.Add(dr);
                //    valid = 1;
                //}
            }

            ds = genogj.GetQueryStatusByTransactionIDPCBREN(intQuessionaireid, intcfeid);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                // hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";
                Modified_by = "";
                Modified_dt = "";




                if (valid == 0)
                {
                    result = InsertQueryDetailsREN(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid,
     intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, QueryAttachmentFileName, QueryAttachmentFilePath,
     QueryRespondDate, QueryRespondRemarks, Created_by, Created_dt, Modified_by, Modified_dt, IPAddress, categoryFlag, lineofacitivtyid, categoryid);
                }

            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Developed By Rajesh Patnaik
    public int InsertQueryDetailsREN(string intEnterpreniourApprovalid,
string intQuessionaireid,
string intCFEEnterpid,
string intDeptid,
string intApprovalid,
string QueryRaiseDate,
string QueryDescription,
string QueryStatus,
string QueryAttachmentFileName,
string QueryAttachmentFilePath,
string QueryRespondDate,
string QueryRespondRemarks,
string Created_by,
string Created_dt,
string Modified_by, string Modified_dt, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertQueryDetails_Webservice_REN", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }


            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            //if (QueryRaiseDate.Trim() == "" || QueryRaiseDate.Trim() == null || QueryRaiseDate.Trim() == "--Select--")
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = QueryRaiseDate.Trim();
            //}


            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();


            //-------------------------------------------------
            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (categoryFlag.ToString().Trim() == "" || categoryFlag.ToString().Trim() == null || categoryFlag.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = categoryFlag.Trim();

            if (lineofacitivtyid.Trim() == "" || lineofacitivtyid.Trim() == null || lineofacitivtyid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = Int32.Parse(lineofacitivtyid.Trim());
            }
            if (categoryid.Trim() == "" || categoryid.Trim() == null || categoryid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = Int32.Parse(categoryid.Trim());
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    #endregion

    public DataSet GetdataofApprovaldataAprovalRENbyID(string enterprenuer, string intDeptid)
    {

        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("getenterprenuerdatbyidAprovalsRENNew_websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }


            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {

            con.CloseConnection();

        }
        return ds;
    }

    [WebMethod]
    public string BoilerInspectionReportStatus(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Documentpath, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (intCFEEnterpid == "" || intCFEEnterpid == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Share IntCFEID";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share intQuessionaireid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intStageid == "" || intStageid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share Stagedid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (Documentpath == "" || Documentpath == null)
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Please Share Documentpath";
                dt.Rows.Add(dr);
                valid = 1;
            }




            result = insertDepartmentProcessREN(intCFEEnterpid, intDeptid, intApprovalid, intStageid, null, null);

            if (valid == 0)
            {
                result = UpdateBoilerInspectionStatus(intCFEEnterpid, intQuessionaireid, intStageid, intDeptid, intApprovalid, Sysip, Documentpath);
            }





            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateBoilerInspectionStatus(string intCFEEnterpid, string intquestionnaireid, string stageid, string dept, string Approval, string ipaddress, string Documentpath)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptBoilerInspection_Websrv";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intquestionnaireid.Trim() == "" || intquestionnaireid.Trim() == null)
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = intquestionnaireid.Trim();


        if (Documentpath.Trim() == "" || Documentpath.Trim() == null)
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = Documentpath.Trim();


        //if (Created_by.Trim() == "" || Created_by.Trim() == null)
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    [WebMethod]
    public string DepartmentPlotAllotmentProcess(string intapplicationid, string UID, string intStageid, string Querytype, string Query_Raised_Text, string additionaldocs, string Trans_Date, string Created_by, string Sysip, string filename, string filepath, string filerefno)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            result = insertDepartmentProcessPLOT(intapplicationid, intStageid, Trans_Date, Created_by);

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }

                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    if (intStageid == "5")
                    {
                        if (Querytype != "2")
                        {
                            int j = UpdateAdditionalpaymentsPLOT(intapplicationid, "", "Completed", Created_by, intStageid, "3", "12", Sysip, "");

                            int i = insertQueryResponsedataPLOT(result.ToString(), Query_Raised_Text, "Y", Created_by, "3", "12", intapplicationid, additionaldocs, Querytype, "");
                            try
                            {
                                //int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFO", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }

                }


            }
            else if (intStageid == "16" || intStageid == "19")
            {
                if (Query_Raised_Text != "")
                {
                    int j = UpdateAdditionalpaymentsPLOT(intapplicationid, "", "Completed", Created_by, intStageid, "3", "12", Sysip, Query_Raised_Text);
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "5";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }
            else if (intStageid == "13")
            {

                int j = UpdateAdditionalpaymentsPLOT(intapplicationid, "", "Completed", Created_by, intStageid, "3", "13", Sysip, Query_Raised_Text);
                if (filename.Trim() != "")
                {
                    int Fileresult = 0;

                    string FileType = "";
                    string[] fileType = filename.Split('.');
                    int k = fileType.Length;
                    FileType = fileType[k - 1];
                    filepath = filepath.Substring(0, filepath.LastIndexOf('/'));

                    result = InsertplotAttachement(Convert.ToInt32(intapplicationid), filename, filepath, 0, 16);

                }
            }
            else if (intStageid == "15")
            {
                if (filename.Trim() != "")
                {
                    int Fileresult = 0;

                    string FileType = "";
                    string[] fileType = filename.Split('.');
                    int k = fileType.Length;
                    FileType = fileType[k - 1];
                    filepath = filepath.Substring(0, filepath.LastIndexOf('/'));

                    result = InsertplotAttachement(Convert.ToInt32(intapplicationid), filename, filepath, 0, 17);

                }
            }
            //else
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Reason For Rejection";
            //    dt.Rows.Add(dr);
            //}
            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertDepartmentProcessPLOT(string intCFEEnterpid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertDepartmentProcess_WebSrvc_PLOT]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int insertQueryResponsedataPLOT(string intEnterpreniourApprovalid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertQueriesDetailsPLOT_Websrvc]";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        //if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
        //    com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int UpdateAdditionalpaymentsPLOT(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string rejectionreason)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnew_Websrv_PLOT";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (rejectionreason.Trim() == "" || rejectionreason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = rejectionreason.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    [WebMethod]
    public string DepartmentApprovalProcessCFOLabour(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;


            result = insertDepartmentProcessCFO(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {

                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "3";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    if (Querytype != "2")
                    {
                        int j = UpdateAdditionalpaymentsCFOLabour(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                        int i = insertQueryResponsedataCFOLabour(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                    //int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpaymentsCFOLabour(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                try
                {
                    // int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }


            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "7";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "8";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateAdditionalpaymentsCFOLabour(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewCFO_Websrv_Labour";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedataCFOLabour(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertQueriesDetailsCFO_websrv_Labour";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public DataSet GetDepartmentFileno(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_FILENO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
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

    [WebMethod]
    public string GetCFEEnterprenuerDetailsNew(string uidno, string Createdby)
    {
        string lblmsg = "";
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("GetCFEEnterprenuerDetailsNew_Service", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() == "" || uidno.Trim() == null || uidno.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@uidno", SqlDbType.VarChar).Value = uidno;
            }
            if (Createdby.Trim() == "" || Createdby.Trim() == null || Createdby.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Createdby;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    [WebMethod]
    public string GetdataCFEApprovaldocument(string uidno, string Createdby)
    {
        string lblmsg = "";
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("sp_RetriveApprovallink_SERVICE", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() == "" || uidno.Trim() == null || uidno.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = uidno;
            }
            if (Createdby.Trim() == "" || Createdby.Trim() == null || Createdby.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = Createdby;
            }

            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
            lblmsg = ds.GetXml();

            //return lblmsg;
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();

        }
        return lblmsg;
    }

    public String SendSingleSMSnew(String mobileNo, String message, string uidno, string intquestionaid, string intdeptid, string intapprovalid, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";

        Stream dataStream = null;
        StreamReader reader = null;
        WebResponse response = null;
        try
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = true;
            request.ServicePoint.ConnectionLimit = 10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            String encryptedPassword = encryptedPasswod(password);
            String newSecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg";

            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                           "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                           "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                           "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                           "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                           "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                           "&key=" + HttpUtility.UrlEncode(newSecureKey.Trim()) +
                           "&templateid=" + HttpUtility.UrlEncode(templID.Trim());

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentLength = byteArray.Length;

            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            response = request.GetResponse();
            String status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            if (responseFromServer.Contains("402"))
            {
                try
                {
                    GetTESTVALUES(message, uidno, mobileNo, intquestionaid, intdeptid, intapprovalid);
                }
                catch (Exception ex)
                {

                }
            }

            return responseFromServer;
        }
        catch (WebException webEx)
        {
            return "Error: " + webEx.Message;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
        finally
        {
            if (reader != null) reader.Close();
            if (dataStream != null) dataStream.Close();
            if (response != null) response.Close();
        }
    }
    public String SendSingleSMSnew(String mobileNo, String message, string uidno, string intquestionaid, string intdeptid, string intapprovalid)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        if (responseFromServer.Contains("402"))
        {
            try
            {
                GetTESTVALUES(message, uidno, mobileNo, intquestionaid, intdeptid, intapprovalid);
            }
            catch (Exception ex)
            {

            }
        }
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    public String SendSingleSMSnewold(String mobileNo, String message, string uidno, string intquestionaid, string intdeptid, string intapprovalid, string templID)
    {
        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";
        String secureKey = "e8750728-53e8-4f29-9bc9-9f06975accb0";
        //Latest Generated Secure Key

        Stream dataStream;
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
        request.ProtocolVersion = HttpVersion.Version10;
        request.KeepAlive = false;
        request.ServicePoint.ConnectionLimit = 1;
        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
        request.Method = "POST";
        //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        //System.Net.ServicePointManager.CertificatePolicy= new 
        String encryptedPassword = encryptedPasswod(password);
        String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
        String smsservicetype = "singlemsg"; //For single message.
        String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            "&content=" + HttpUtility.UrlEncode(message.Trim()) +
            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
            "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
            "&templateid=" + HttpUtility.UrlEncode(templID.Trim());
        byte[] byteArray = Encoding.ASCII.GetBytes(query);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        String Status = ((HttpWebResponse)response).StatusDescription;
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        String responseFromServer = reader.ReadToEnd();
        if (responseFromServer.Contains("402"))
        {
            try
            {
                GetTESTVALUES(message, uidno, mobileNo, intquestionaid, intdeptid, intapprovalid);
            }
            catch (Exception ex)
            {

            }
        }
        reader.Close();
        dataStream.Close();
        response.Close();
        return responseFromServer;
    }

    protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
        byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
        byte[] sec_key = sha1.ComputeHash(genkey);
        StringBuilder sb1 = new StringBuilder();
        for (int i = 0; i < sec_key.Length; i++)
        {
            sb1.Append(sec_key[i].ToString("x2"));
        }
        return sb1.ToString();
    }
    protected String encryptedPasswod(String password)
    {
        byte[] encPwd = Encoding.UTF8.GetBytes(password);
        //static byte[] pwd = new byte[encPwd.Length];
        HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
        byte[] pp = sha1.ComputeHash(encPwd);
        // static string result = System.Text.Encoding.UTF8.GetString(pp);
        StringBuilder sb = new StringBuilder();
        foreach (byte b in pp)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }


    public void GetTESTVALUES(string Responce, string UIDNO, string MOBILENO, string INTQUESSIONAREID, string INTDEPTID, string INTAPPROVALID)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SMSSENDDATA", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@UIDno", SqlDbType.VarChar).Value = UIDNO.ToString();
            da.SelectCommand.Parameters.Add("@Mobileno", SqlDbType.VarChar).Value = MOBILENO.ToString();
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = INTQUESSIONAREID.ToString();
            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = INTDEPTID.ToString();
            da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = INTAPPROVALID.ToString();

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

    [WebMethod]
    public string BoilerInspectionStatusCFE(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Documentpath, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (intCFEEnterpid == "" || intCFEEnterpid == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Share IntCFEID";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share intQuessionaireid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intStageid == "" || intStageid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share Stagedid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (Documentpath == "" || Documentpath == null)
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Please Share Documentpath";
                dt.Rows.Add(dr);
                valid = 1;
            }




            result = insertDepartmentProcess(intCFEEnterpid, intDeptid, intApprovalid, intStageid, null, null);

            if (valid == 0)
            {
                result = UpdateBoilerInspectionStatuscfe(intCFEEnterpid, intQuessionaireid, intStageid, intDeptid, intApprovalid, Sysip, Documentpath);
            }





            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string BoilerInspectionStatusREN(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Documentpath, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (intCFEEnterpid == "" || intCFEEnterpid == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Share IntCFEID";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share intQuessionaireid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (intStageid == "" || intStageid == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Share Stagedid";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (Documentpath == "" || Documentpath == null)
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Please Share Documentpath";
                dt.Rows.Add(dr);
                valid = 1;
            }




            result = insertDepartmentProcessREN(intCFEEnterpid, intDeptid, intApprovalid, intStageid, null, null);

            if (valid == 0)
            {
                result = UpdateBoilerInspectionStatusren(intCFEEnterpid, intQuessionaireid, intStageid, intDeptid, intApprovalid, Sysip, Documentpath);
            }





            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateBoilerInspectionStatuscfe(string intCFEEnterpid, string intquestionnaireid, string stageid, string dept, string Approval, string ipaddress, string Documentpath)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptBoilerInspection_Websrv_CFE";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intquestionnaireid.Trim() == "" || intquestionnaireid.Trim() == null)
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = intquestionnaireid.Trim();


        if (Documentpath.Trim() == "" || Documentpath.Trim() == null)
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = Documentpath.Trim();


        //if (Created_by.Trim() == "" || Created_by.Trim() == null)
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateBoilerInspectionStatusren(string intCFEEnterpid, string intquestionnaireid, string stageid, string dept, string Approval, string ipaddress, string Documentpath)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptBoilerInspection_Websrv_REN";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intquestionnaireid.Trim() == "" || intquestionnaireid.Trim() == null)
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = intquestionnaireid.Trim();


        if (Documentpath.Trim() == "" || Documentpath.Trim() == null)
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Documentpath", SqlDbType.VarChar).Value = Documentpath.Trim();


        //if (Created_by.Trim() == "" || Created_by.Trim() == null)
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int InsertplotAttachement(Int64 appid, string AttachmentFilename, string AttachmentFilePath, Int64 Created_by, int attachmentid)
    {
        try
        {

            //string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
            DB.DB con = new DB.DB();
            con.OpenConnection();
            //SqlDataAdapter da;

            //SqlConnection con = new SqlConnection(str);
            //con.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("USP_INS_TsiicATTACHMENTS", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (appid == 0 || appid == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@appid", SqlDbType.BigInt).Value = appid;
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (attachmentid == 0 || attachmentid == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@attachmentid", SqlDbType.VarChar).Value = Convert.ToInt32(attachmentid);
            }


            if (Created_by == 0 || Created_by == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToInt64(Created_by);
            }

            myDataAdapter.SelectCommand.Parameters.Add("@Result", SqlDbType.VarChar, 500);
            myDataAdapter.SelectCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {



        }
    }

    [WebMethod]
    public string InsertEXCISEPortalDataCFO(string approvalid, string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string EXCISEApplicationno, string AppealFlag)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (ApplicationSubmitted != "" || ApplicationSubmitted != null)
            {
                if (ApplicationSubmitted == "Y")
                {
                    if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Application Submission Date";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Downloadlink == "" || Downloadlink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (EXCISEApplicationno == "" || EXCISEApplicationno == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (AppealFlag != "Y")
                    {
                        if (TotalAmount == "" || TotalAmount == null)
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Total Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (PaymentStatus != "" || PaymentStatus != null)
                    {
                        if (PaymentStatus == "Y")
                        {
                            if (TransactionNo == "" || TransactionNo == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "5";
                                dr[1] = "Please Enter Transaction Number";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (TotalAmount == "" || TotalAmount == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "6";
                                dr[1] = "Please Enter Total Amount";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (PaymentDate == "" || PaymentDate == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "7";
                                dr[1] = "Please Enter PaymentDate";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (BankName == "" || BankName == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "8";
                                dr[1] = "Please Enter BankName";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr[0] = "13";
                        dr[1] = "Please Enter Payment Status Y/N'";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "12";
                    dr[1] = "Please Application Submitted 'Y'";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                result = insertexcisedataCFO(intCFEEnterpid, intQuessionaireid, ApplicationSubmitted, ApplicationSubmissionDate, PaymentStatus, TransactionNo, PaymentDate, BankName, TotalAmount, Downloadlink, EXCISEApplicationno, AppealFlag, approvalid);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertexcisedataCFO(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag, string approvalid)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_EXCISEDATA_CFO]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = ApplicationSubmitted.Trim();

        if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ApplicationSubmissionDate.Trim());

        if (PaymentStatus == "" || PaymentStatus == null)
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = PaymentStatus;

        if (TransactionNo == "" || TransactionNo == null)
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = TransactionNo.Trim();

        if (PaymentDate == "" || PaymentDate == null)
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(PaymentDate.Trim());

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (TotalAmount == "" || TotalAmount == null)
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = TotalAmount.Trim();

        if (Downloadlink == "" || Downloadlink == null)
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = Downloadlink.Trim();

        if (NICApplicationno == "" || NICApplicationno == null)
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = NICApplicationno.Trim();

        if (AppealFlag == "" || AppealFlag == null)
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = AppealFlag.Trim();

        if (approvalid == "" || approvalid == null)
            com.Parameters.Add("@APPROVALID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@APPROVALID", SqlDbType.VarChar).Value = approvalid.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessTourismEvent(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;



            result = insertDepartmentProcessTourismEvent(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            string errorvalue = "";
            //errorvalue = GetchildandparentdataTourismEvent(intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, intStageid, Querytype);
            //if (errorvalue != "")
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "10";
            //    dr[1] = errorvalue;
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //    DataSet dserror = new DataSet();
            //    dserror.Tables.Add(dt);
            //    lblmsg = dserror.GetXml();
            //    return lblmsg;
            //}

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    // 1 –additional docs,2-additional payment,3-others

                    if (Querytype == "1" || Querytype == "3")
                    {
                        int j = UpdateAdditionalpaymentsTourismEvent(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip, "");
                        int i = insertQueryResponsedataTourismEvent(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                        DataSet dsMail = new DataSet();
                    }
                    else if (Querytype == "2")
                    {
                        if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
                        {
                            int j = UpdateAdditionalpaymentsTourismEvent(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip, additionaldocs);
                            try
                            {
                                //int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            int j = UpdateAdditionalpaymentsTourismEvent(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip, "");
                            try
                            {
                                // int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        // int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    }

                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpaymentsTourismEvent(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip, "");
                try
                {
                    // int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }
            else if (intStageid == "16")
            {
                if (Query_Raised_Text != "")
                {

                    if (intDeptid == "11" || intDeptid == "13" || intDeptid == "3")
                    {
                        int j = UpdateAdditionalpaymentsBeforePreTourismEvent(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip, additionaldocs);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        int j = UpdateAdditionalpaymentsBeforePreTourismEvent(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip, "");
                        try
                        {
                            // int k = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFE", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertDepartmentProcessTourismEvent(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertDepartmentProcess_WebSrvc_TourismEvent]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int UpdateAdditionalpaymentsTourismEvent(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string dcletter)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdatetDeptApprovalnew_Websrvc_TourismEvent]";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();


        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (dcletter.Trim() == "" || dcletter.Trim() == null)
            com.Parameters.Add("@DCLetter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DCLetter", SqlDbType.VarChar).Value = dcletter.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedataTourismEvent(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[insertQueriesDetails_Websrvc_TourismEvent]";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int UpdateAdditionalpaymentsBeforePreTourismEvent(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress, string RejectedLetter)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[UpdatetDeptApprovalnewBeforePre_Websrvc_TourismEvent]";


        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();

        if (RejectedLetter.Trim() == "" || RejectedLetter.Trim() == null)
            com.Parameters.Add("@RejectedLetter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RejectedLetter", SqlDbType.VarChar).Value = RejectedLetter.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }


    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadTourismEvent(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");


        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalbyIDtourismevent(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));
                //Fileresult = InsertImagedataApproval(intQuessionaireid, EnterprenuerId, FileType, FilePath, FileName, "ApprovalDocument", "", Modified_by, intDeptid, intApprovalid);

                Fileresult = SaveAttachmentsTourismEvent(intQuessionaireid, FileType, FilePath, FileName, "ApprovalDocument", Modified_by, intApprovalid, intDeptid);

                i = insertApprovalDataTourismEvent(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                i = insertApprovalDataTourismEvent(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }

            }
        }

        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataTourismEvent(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracing(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumbernewTourismEvent(intQuessionaireid, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }
                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int insertApprovalDataTourismEvent(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[updateApprovaldata_Web_Srv_TourismEvent]";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }


    public int SaveAttachmentsTourismEvent(string intTourismId, string FileType, string FilePath, string FileName, string FileDescription, string Created_by, string intApprovalid, string intDeptid)
    {
        int n = 0;
        try
        {

            con.OpenConnection();

            SqlCommand cmdFiles = new SqlCommand("usp_Insert_TourismEvent_attachments_APPROVAL", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;

            cmdFiles.Parameters.AddWithValue("@TourismEvent_ID", Convert.ToInt32(intTourismId));
            cmdFiles.Parameters.AddWithValue("@FileType", FileType);
            cmdFiles.Parameters.AddWithValue("@FilePath", FilePath);
            cmdFiles.Parameters.AddWithValue("@FileName", FileName);
            cmdFiles.Parameters.AddWithValue("@FileDescription", FileDescription);
            cmdFiles.Parameters.AddWithValue("@Created_by", Created_by);
            cmdFiles.Parameters.AddWithValue("@intDeptid", intDeptid);
            cmdFiles.Parameters.AddWithValue("@intApprovalid", intApprovalid);
            n = cmdFiles.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
        return n;
    }

    public DataSet GetShowEmailidandMobileNumbernewTourismEvent(string intQuessionaireid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberNew1_TourismEvent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

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

    public DataSet GetdataofApprovaldataAprovalbyIDtourismevent(string enterprenuer, string intDeptid)
    {

        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("getenterprenuerdatbyidAprovalsNew_tourismevent", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }
            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
        return ds;
    }

    [WebMethod]
    public string DepartmentPlotAllotmentProcessSubdivision(string intapplicationid, string UID, string intStageid, string plotno, string pltoarea, string remarks, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            result = insertDepartmentProcessPLOT(intapplicationid, intStageid, "", Created_by);

            if (intStageid.ToString() == "13")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                // 1 –additional docs,2-additional payment,3-others

                if (plotno == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Please Mention correct type of Query";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
                if (valid == 0)
                {
                    if (intStageid == "13")
                    {
                        int j = UpdateAdditionalpaymentsPLOTsubdivision(intapplicationid, plotno, pltoarea, "Completed", Created_by, intStageid, "3", "13", Sysip, remarks);
                        //int j = UpdateAdditionalpaymentsPLOT(intapplicationid, "", "Completed", Created_by, intStageid, "3", "13", Sysip, remarks);
                    }
                    else if (intStageid == "16")
                    {
                        if (remarks != "")
                        {
                            //int j = UpdateAdditionalpaymentsPLOT(intapplicationid, "", "Completed", Created_by, intStageid, "3", "16", Sysip, remarks);
                            int j = UpdateAdditionalpaymentsPLOTsubdivision(intapplicationid, plotno, pltoarea, "Rejected", Created_by, intStageid, "3", "16", Sysip, remarks);
                        }
                    }
                }
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    //if (remarks == "")
                    //{
                    //    dr = dt.NewRow();
                    //    dr[0] = "2";
                    //    dr[1] = "Please Enter Reason For Rejection";
                    //    dt.Rows.Add(dr);
                    //}
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateAdditionalpaymentsPLOTsubdivision(string intCFEEnterpid, string subplotno, string subplotarea, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string rejectionreason)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnew_Websrv_PLOT_Subdivision";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (subplotno.Trim() == "" || subplotno.Trim() == null)
            com.Parameters.Add("@SUBDIVISIONPLOTNO", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@SUBDIVISIONPLOTNO", SqlDbType.VarChar).Value = subplotno.Trim();

        if (subplotarea.Trim() == "" || subplotarea.Trim() == null)
            com.Parameters.Add("@SUBDIVISIONPLOTAREA", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@SUBDIVISIONPLOTAREA", SqlDbType.VarChar).Value = subplotarea.Trim();




        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (rejectionreason.Trim() == "" || rejectionreason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = rejectionreason.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public DataSet GetRenewalQuestionnaireid(string nicapplno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_CAFNO_PCBREN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (nicapplno.Trim() != "" || nicapplno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@NICAPPLICATIONO", SqlDbType.VarChar).Value = nicapplno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@NICAPPLICATIONO", SqlDbType.VarChar).Value = null;
            }
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

    [WebMethod]
    public string GetRenewalQuestionnaireidpcb(string nicapplno)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            DataSet dsuidno = new DataSet();
            dsuidno = GetRenewalQuestionnaireid(nicapplno);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                lblmsg = dsuidno.GetXml();
            }

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string InsertPCBNICPortalDataBMW(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (ApplicationSubmitted != "" || ApplicationSubmitted != null)
            {
                if (ApplicationSubmitted == "Y")
                {
                    if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "2";
                        dr[1] = "Please Enter Application Submission Date";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Downloadlink == "" || Downloadlink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (NICApplicationno == "" || NICApplicationno == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (AppealFlag != "Y")
                    {
                        if (TotalAmount == "" || TotalAmount == null)
                        {
                            dr = dt.NewRow();
                            dr[0] = "6";
                            dr[1] = "Please Enter Total Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (PaymentStatus != "" || PaymentStatus != null)
                    {
                        if (PaymentStatus == "Y")
                        {
                            if (TransactionNo == "" || TransactionNo == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "5";
                                dr[1] = "Please Enter Transaction Number";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (TotalAmount == "" || TotalAmount == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "6";
                                dr[1] = "Please Enter Total Amount";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (PaymentDate == "" || PaymentDate == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "7";
                                dr[1] = "Please Enter PaymentDate";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                            if (BankName == "" || BankName == null)
                            {
                                dr = dt.NewRow();
                                dr[0] = "8";
                                dr[1] = "Please Enter BankName";
                                dt.Rows.Add(dr);
                                valid = 1;
                            }
                        }
                    }
                    else
                    {
                        dr = dt.NewRow();
                        dr[0] = "13";
                        dr[1] = "Please Enter Payment Status Y/N'";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "12";
                    dr[1] = "Please Application Submitted 'Y'";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (valid == 0)
            {
                result = insertpcbnicdataBMW(intCFEEnterpid, intQuessionaireid, ApplicationSubmitted, ApplicationSubmissionDate, PaymentStatus, TransactionNo, PaymentDate, BankName, TotalAmount, Downloadlink, NICApplicationno, AppealFlag);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int insertpcbnicdataBMW(string intCFEEnterpid, string intQuessionaireid, string ApplicationSubmitted, string ApplicationSubmissionDate, string PaymentStatus, string TransactionNo, string PaymentDate, string BankName, string TotalAmount, string Downloadlink, string NICApplicationno, string AppealFlag)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_INS_PCBNICDATA_BMW]";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (ApplicationSubmitted == "" || ApplicationSubmitted == null)
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmitted", SqlDbType.VarChar).Value = ApplicationSubmitted.Trim();

        if (ApplicationSubmissionDate == "" || ApplicationSubmissionDate == null)
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApplicationSubmissionDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ApplicationSubmissionDate.Trim());

        if (PaymentStatus == "" || PaymentStatus == null)
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentStatus", SqlDbType.VarChar).Value = PaymentStatus;

        if (TransactionNo == "" || TransactionNo == null)
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = TransactionNo.Trim();

        if (PaymentDate == "" || PaymentDate == null)
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(PaymentDate.Trim());

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (TotalAmount == "" || TotalAmount == null)
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TotalAmount", SqlDbType.VarChar).Value = TotalAmount.Trim();

        if (Downloadlink == "" || Downloadlink == null)
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Downloadlink", SqlDbType.VarChar).Value = Downloadlink.Trim();

        if (NICApplicationno == "" || NICApplicationno == null)
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NICApplicationno", SqlDbType.VarChar).Value = NICApplicationno.Trim();

        if (AppealFlag == "" || AppealFlag == null)
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AppealFlag", SqlDbType.VarChar).Value = AppealFlag.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessBMW(string intQuessionaireid, string intCFEEnterpid, string UID, string intDeptid, string intApprovalid, string intStageid, string Querytype, string Query_Raised_Text, string AdditionalAmount, string additionaldocs, string Trans_Date, string Created_by, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (intDeptid == "1")
            {
                DataSet dsuidno1 = new DataSet();
                dsuidno1 = GetDepartmentonuidBMW(intQuessionaireid, intCFEEnterpid);
                if (dsuidno1 != null && dsuidno1.Tables.Count > 0 && dsuidno1.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireid = dsuidno1.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                    intCFEEnterpid = dsuidno1.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                }
            }

            result = insertDepartmentProcessBMW(intCFEEnterpid, intDeptid, intApprovalid, intStageid, Trans_Date, Created_by);

            if (intStageid.ToString() == "5")//|| ddlStatus.SelectedValue.ToString()=="9"
            {

                // 1 –additional docs,2-additional payment,3-others
                if (Querytype != "")
                {
                    if (Querytype != "1" && Querytype != "2" && Querytype != "3")
                    {
                        dr = dt.NewRow();
                        dr[0] = "1";
                        dr[1] = "Please Mention correct type of Query";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (Querytype == "3")
                    {
                        if (Query_Raised_Text == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "2";
                            dr[1] = "Please Enter Query Description";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "2")
                    {
                        if (AdditionalAmount == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "3";
                            dr[1] = "Please Enter Amount";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                    if (Querytype == "1")
                    {
                        if (additionaldocs == "")
                        {
                            dr = dt.NewRow();
                            dr[0] = "4";
                            dr[1] = "Please Enter Additional Documents Required";
                            dt.Rows.Add(dr);
                            valid = 1;
                        }
                    }
                }
                if (valid == 0)
                {
                    if (Querytype != "2")
                    {
                        int j = UpdateAdditionalpaymentsBMW(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                        int i = insertQueryResponsedataBMW(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracingBMW(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        int j = UpdateAdditionalpaymentsBMW(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, "11", intDeptid, intApprovalid, Sysip);
                        try
                        {
                            //int k = genogj.InsertDeptDateTracingBMW(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                            //int k = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //int j = UpdateAdditionalpayments(intCFEEnterpid, AdditionalAmount, "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                    //int i = insertQueryResponsedata(result.ToString(), intCFEEnterpid, Query_Raised_Text, "Y", Created_by, intDeptid, intApprovalid, intQuessionaireid, additionaldocs, Querytype, AdditionalAmount);
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    //}
                }
            }
            else if (intStageid == "12")
            {
                int j = UpdateAdditionalpaymentsBMW(intCFEEnterpid, "", "Completed", Created_by, intStageid, intDeptid, intApprovalid, Sysip);
                try
                {
                    //int k = genogj.InsertDeptDateTracingREN(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                    //int k = genogj.InsertDeptDateTracingBMW(intDeptid, intCFEEnterpid, UID, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "REN", intApprovalid);
                }
                catch (Exception ex)
                {

                }
                DataSet dsMail = new DataSet();
                // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                //if (dsMail.Tables[0].Rows.Count > 0)
                //{
                //  //  cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //  //  cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has completed pre-scrutiny of your application. Thank You.");

                //}
            }
            else if (intStageid == "16")
            {
                if (Query_Raised_Text != "")
                {
                    int j = UpdateAdditionalpaymentsBeforePreBMW(intCFEEnterpid, "", "Rejected", Created_by, intStageid, intDeptid, intApprovalid, Query_Raised_Text, Sysip);
                    try
                    {
                        //int k = genogj.InsertDeptDateTracingBMW(intDeptid, intQuessionaireid, UID, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "REN", intApprovalid);
                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    // dsMail = GetShowEmailidandMobileNumber(intQuessionaireid, intApprovalid);
                    //if (dsMail.Tables[0].Rows.Count > 0)
                    //{
                    //   // cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                    //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    //{
                    //   // cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + dsMail.Tables[0].Rows[0]["dept_name"].ToString().Trim() + "  has Rejected your application. Thank You.");
                    //}
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "5";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
                if (intStageid == "16")
                {
                    if (Query_Raised_Text == "")
                    {
                        dr = dt.NewRow();
                        dr[0] = "7";
                        dr[1] = "Please Enter Reason For Rejection";
                        dt.Rows.Add(dr);
                    }
                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "8";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string DepartmentApprovalProcessAndCertificateUploadBMW(string intQuessionaireid, string EnterprenuerId, string intApprovalid, string intDeptid, string intStageid, string FileName, string FilePath, string Remarks, string FileRefNo, string Modified_by)
    {
        int i = 0;
        string lblmsg = "";
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("ErrorCode");
        dt.Columns.Add("ErrorDescription");

        // Data Retrival

        if (intDeptid == "1")
        {
            DataSet dsuidno = new DataSet();
            dsuidno = GetDepartmentonuidBMW(intQuessionaireid, EnterprenuerId);
            if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
            {
                intQuessionaireid = dsuidno.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                EnterprenuerId = dsuidno.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
            }
        }

        DataSet dsdatauser = new DataSet();
        dsdatauser = GetdataofApprovaldataAprovalBMWbyID(EnterprenuerId, intDeptid);

        string Label447 = "", Label448 = "", Label449 = "", Label450 = "";
        if (dsdatauser.Tables[0].Rows.Count > 0)
        {
            Label447 = dsdatauser.Tables[0].Rows[0]["UID_No"].ToString().Trim();
            Label448 = dsdatauser.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
            Label449 = dsdatauser.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
            Label450 = dsdatauser.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
        }
        // end
        if (intStageid == "13")
        {
            if (FileName.Trim() != "")
            {
                int Fileresult = 0;

                string FileType = "";
                string[] fileType = FileName.Split('.');
                int k = fileType.Length;
                FileType = fileType[k - 1];
                FilePath = FilePath.Substring(0, FilePath.LastIndexOf('/'));

                Fileresult = InsertBMWAttachementApproval(intQuessionaireid, EnterprenuerId, Label447, "1", FileType, FileName, FilePath, "A", Modified_by, "ApprovalDocument", intDeptid, intApprovalid);

                i = insertApprovalDataBMW(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                    //int M = genogj.InsertDeptDateTracingBMW(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "REN", intApprovalid);

                }
                catch (Exception ex)
                {

                }
                //DataSet dscer = new DataSet();
                //dscer = GetStatusforCertificateCFO(intQuessionaireid);

                //if (dscer.Tables[0].Rows.Count > 0)
                //{
                //    int result = 0;
                //    result = UpdCommissionerApprovalCFONew(EnterprenuerId, intDeptid, intApprovalid, "15", "", Modified_by, intQuessionaireid);
                //}
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Upload Approval Document";
                dt.Rows.Add(dr);

            }
        }
        else
        {
            if (Remarks != "")
            {
                i = insertApprovalDataBMW(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                //i = insertApprovalDataCFO(EnterprenuerId, FileRefNo, intStageid, Modified_by, intApprovalid, intDeptid, Remarks, "");
                try
                {
                    //int M = genogj.InsertDeptDateTracingBMW(intDeptid, intQuessionaireid, Label447, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFO", intApprovalid);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Reason For Rejection..";
                dt.Rows.Add(dr);
            }
        }

        if (i != 999)
        {
            DataSet dsMail1 = new DataSet();
            dsMail1 = GetShowEmailidandMobileNumberBMW(EnterprenuerId, intDeptid);
            if (intStageid == "13")
            {
                if (dsMail1.Tables[0].Rows.Count > 0)
                {
                    //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an" + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
                    try
                    {
                        //cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thak You.");
                    //cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an " + ddlStatus.SelectedItem.Text.ToString() + " to your application.Please login to TS-iPASS to download your approval. Thank You.");
                    try
                    {
                        SendSingleSMSnew(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail1.Tables[0].Rows[0]["Names"].ToString().Trim() + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.", Label447, intQuessionaireid, intDeptid, intApprovalid, "1007452343961897611");
                    }
                    catch (Exception ex)
                    {

                    }

                }

                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
                //Response.Redirect("frmDepartementDashboardNew.aspx");
            }
            else
            {
                //if (dsMail1.Tables[0].Rows.Count > 0)
                //{
                //    cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                //}
                //if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448 + " - (" + Label447 + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + "Rejected" + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //}
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Status Updated Successfully";
                dt.Rows.Add(dr);
            }
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = "4";
            dr[1] = "failed";
            dt.Rows.Add(dr);
        }

        ds = new DataSet();
        ds.Tables.Add(dt);
        lblmsg = ds.GetXml();

        return lblmsg;
    }

    public int insertDepartmentProcessBMW(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcessBMW_Websrv";

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intStageid == "" || intStageid == null)
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();

        if (Trans_Date == "" || Trans_Date == null)
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsBMW(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBMW_Websrv";

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int insertQueryResponsedataBMW(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid, string additionaldocs, string Querytype, string AdditionalAmount)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertQueriesDetailsBMW_Websrv";

        if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();


        if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
        if (additionaldocs.Trim() == "" || additionaldocs.Trim() == null)
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@additionaldocsDescription", SqlDbType.VarChar).Value = additionaldocs.Trim();

        if (Querytype.Trim() == "" || Querytype.Trim() == null)
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Querytype", SqlDbType.VarChar).Value = Querytype.Trim();

        if (AdditionalAmount.Trim() == "" || AdditionalAmount.Trim() == null)
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalAmount", SqlDbType.VarChar).Value = AdditionalAmount.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    public int UpdateAdditionalpaymentsBeforePreBMW(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBeforePreBMW_Websrv";

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (Amount.Trim() == "" || Amount.Trim() == null)
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Amount.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stageid", SqlDbType.VarChar).Value = stageid.Trim();


        if (dept.Trim() == "" || dept.Trim() == null)
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept.Trim();


        if (Approval.Trim() == "" || Approval.Trim() == null)
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval", SqlDbType.VarChar).Value = Approval.Trim();

        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }

    }

    public DataSet GetDepartmentonuidBMW(string uidno, string renid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ENTERID_UIDNO_BMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (renid.Trim() != "" || renid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@renid", SqlDbType.VarChar).Value = renid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@renid", SqlDbType.VarChar).Value = null;
            }
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

    public int insertApprovalDataBMW(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "updateApprovaldataBMW_Web_Srv";

        if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();

        if (RefNo.Trim() == "" || RefNo.Trim() == null)
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();


        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();


        if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public int InsertBMWAttachementApproval(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id, string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_BMWAttachmentDetDeptApproval_Websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = intDeptid.Trim();
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = intApprovalid.Trim();
            }


            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireCFOid.Trim());
            }

            if (intCFOEnterpid.Trim() == "" || intCFOEnterpid.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFOEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.VarChar).Value = Reg_Id.Trim();
            }

            if (AttachmentTypeName.Trim() == "" || AttachmentTypeName.Trim() == null || AttachmentTypeName.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentTypeName", SqlDbType.VarChar).Value = AttachmentTypeName.Trim();
            }

            if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilename", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
            }

            if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@AttachmentFilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }

            if (Status.Trim() == "" || Status.Trim() == null || Status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
            }


            if (FileDescription.Trim() == "" || FileDescription.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
    }

    [WebMethod]

    public string InsertClarificationResponseBMW(string intQuessionaireid, string intcfeid, string intDeptid, string intApprovalid, string QueryAttachmentFileName, string QueryAttachmentFilePath, string QueryRespondDate,
   string QueryRespondRemarks, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            string intEnterpreniourApprovalid, intCFEEnterpid, QueryRaiseDate, QueryDescription, QueryStatus, Created_by, Created_dt, Modified_by, Modified_dt;
            int valid = 0;
            DataSet ds = new DataSet();


            if (intcfeid == "" || intcfeid == null)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Please Provide Entrprenur Id";
                dt.Rows.Add(dr);
                valid = 1;
            }


            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                dr = dt.NewRow();
                dr[0] = "6";
                dr[1] = "Please Provide Caf number";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (QueryRespondRemarks == "" || QueryRespondRemarks == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter Clarification Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag == "" || categoryFlag == null)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter category change fllag Y/N";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (categoryFlag != "" || categoryFlag != null)
            {
                if (categoryFlag == "Y")
                {
                    if (lineofacitivtyid == "" || lineofacitivtyid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Enter Line of Activity";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (categoryid == "" || categoryid == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Provide Category Id";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                }
                //if (categoryFlag != "Y" && categoryFlag != "N")
                //{
                //    dr = dt.NewRow();
                //    dr[0] = "4";
                //    dr[1] = "Please Provide Correct Category FLAG";
                //    dt.Rows.Add(dr);
                //    valid = 1;
                //}
            }

            ds = genogj.GetQueryStatusByTransactionIDPCBBMW(intQuessionaireid, intcfeid);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                // hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";
                Modified_by = "";
                Modified_dt = "";




                if (valid == 0)
                {
                    result = InsertQueryDetailsBMW(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid,
     intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, QueryAttachmentFileName, QueryAttachmentFilePath,
     QueryRespondDate, QueryRespondRemarks, Created_by, Created_dt, Modified_by, Modified_dt, IPAddress, categoryFlag, lineofacitivtyid, categoryid);
                }

            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Developed By Rajesh Patnaik
    public int InsertQueryDetailsBMW(string intEnterpreniourApprovalid,
string intQuessionaireid,
string intCFEEnterpid,
string intDeptid,
string intApprovalid,
string QueryRaiseDate,
string QueryDescription,
string QueryStatus,
string QueryAttachmentFileName,
string QueryAttachmentFilePath,
string QueryRespondDate,
string QueryRespondRemarks,
string Created_by,
string Created_dt,
string Modified_by, string Modified_dt, string IPAddress, string categoryFlag, string lineofacitivtyid, string categoryid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_InsertQueryDetails_Webservice_BMW", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (IPAddress.Trim() == "" || IPAddress.Trim() == null || IPAddress.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            }


            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null || intEnterpreniourApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intEnterpreniourApprovalid", SqlDbType.Int).Value = Int32.Parse(intEnterpreniourApprovalid.Trim());
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }

            //if (QueryRaiseDate.Trim() == "" || QueryRaiseDate.Trim() == null || QueryRaiseDate.Trim() == "--Select--")
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    myDataAdapter.SelectCommand.Parameters.Add("@QueryRaiseDate", SqlDbType.DateTime).Value = QueryRaiseDate.Trim();
            //}


            if (QueryDescription.ToString().Trim() == "" || QueryDescription.ToString().Trim() == null || QueryDescription.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();

            if (QueryStatus.ToString().Trim() == "" || QueryStatus.ToString().Trim() == null || QueryStatus.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();

            if (QueryAttachmentFileName.ToString().Trim() == "" || QueryAttachmentFileName.ToString().Trim() == null || QueryAttachmentFileName.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.ToString().Trim() == "" || QueryAttachmentFilePath.ToString().Trim() == null || QueryAttachmentFilePath.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.ToString().Trim() == "" || QueryRespondRemarks.ToString().Trim() == null || QueryRespondRemarks.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();


            //-------------------------------------------------
            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (categoryFlag.ToString().Trim() == "" || categoryFlag.ToString().Trim() == null || categoryFlag.ToString().Trim() == "--Select--")
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                myDataAdapter.SelectCommand.Parameters.Add("@categoryFlag", SqlDbType.VarChar).Value = categoryFlag.Trim();

            if (lineofacitivtyid.Trim() == "" || lineofacitivtyid.Trim() == null || lineofacitivtyid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@lineofacitivtyid", SqlDbType.Int).Value = Int32.Parse(lineofacitivtyid.Trim());
            }
            if (categoryid.Trim() == "" || categoryid.Trim() == null || categoryid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@categoryid", SqlDbType.Int).Value = Int32.Parse(categoryid.Trim());
            }
            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    #endregion

    public DataSet GetdataofApprovaldataAprovalBMWbyID(string enterprenuer, string intDeptid)
    {

        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("getenterprenuerdatbyidAprovalsBMWNew_websrv", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }


            ds = new System.Data.DataSet();
            myDataAdapter.Fill(ds);
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
        }
        finally
        {

            con.CloseConnection();

        }
        return ds;
    }

    public DataSet GetShowEmailidandMobileNumberBMW(string intQuessionaireid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumberNewBMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

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

    [WebMethod]
    public string UpdateRedirectionstatusLegalVerfication(string LGVID, string LegalApplID, string LegalDownloadLink, string Legalmetrologystatus)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (Legalmetrologystatus == "" || Legalmetrologystatus == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Mention Application Submitted Yes/No";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (Legalmetrologystatus != "" || Legalmetrologystatus != null)
            {
                if (Legalmetrologystatus == "Y")
                {
                    if (LegalDownloadLink == "" || LegalDownloadLink == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "3";
                        dr[1] = "Please Provide Download Link";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                    if (LegalApplID == "" || LegalApplID == null)
                    {
                        dr = dt.NewRow();
                        dr[0] = "4";
                        dr[1] = "Please Application Number";
                        dt.Rows.Add(dr);
                        valid = 1;
                    }
                }
            }
            if (valid == 0)
            {
                result = insertlegalverificationdata(LGVID, LegalApplID, LegalDownloadLink, Legalmetrologystatus);
            }



            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "10";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "11";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;



        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }

    }

    public int insertlegalverificationdata(string LGVID, string LegalApplID, string LegalDownloadLink, string Legalmetrologystatus)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_Insert_UpdatefromLegalMetrology";

        if (LGVID.ToString().Trim() == "" || LGVID.ToString().Trim() == null)
            com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LGVID.Trim();

        if (LegalApplID.ToString().Trim() == "" || LegalApplID.ToString().Trim() == null)
            com.Parameters.Add("@LegalApplID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LegalApplID", SqlDbType.VarChar).Value = LegalApplID.Trim();

        if (LegalDownloadLink.ToString().Trim() == "" || LegalDownloadLink.ToString().Trim() == null)
            com.Parameters.Add("@LegalDownloadLink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LegalDownloadLink", SqlDbType.VarChar).Value = LegalDownloadLink.Trim();

        if (Legalmetrologystatus.ToString().Trim() == "" || Legalmetrologystatus.ToString().Trim() == null)
            com.Parameters.Add("@Legalmetrologystatus", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Legalmetrologystatus", SqlDbType.VarChar).Value = Legalmetrologystatus.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {

            return Convert.ToInt32(com.ExecuteScalar());

        }
        catch (Exception ex)
        {
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    [WebMethod]
    public string UpdatelegalStatus(string LgvID, string AdditionalPayment, string rejectedremarks, string approvalRejectionflag, string stageid, string ApprovalLink)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;

            if (stageid.ToString() == "11")//|| ddlStatus.SelectedValue.ToString()=="9"
            {
                // 1 –additional docs,2-additional payment,3-others
                if (AdditionalPayment == "" && AdditionalPayment == "0")
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Please Enter Additional Amount";
                    dt.Rows.Add(dr);
                    valid = 1;
                }
            }
            if (stageid == "16")
            {
                if (rejectedremarks == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Please Enter Reason For Rejection";
                    dt.Rows.Add(dr);
                }
            }
            if (stageid == "13")
            {
                if (ApprovalLink == "")
                {
                    dr = dt.NewRow();
                    dr[0] = "13";
                    dr[1] = "Please Share the Approval Link";
                    dt.Rows.Add(dr);
                }
            }
            if (valid == 0)
            {
                int j = UpdateLegalStatusall(LgvID, AdditionalPayment, rejectedremarks, approvalRejectionflag, stageid, ApprovalLink);
                if (j > 0 && valid == 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "3";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "4";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
                ds = new DataSet();
                ds.Tables.Add(dt);
                lblmsg = ds.GetXml();
            }



            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public int UpdateLegalStatusall(string LgvID, string AdditionalPayment, string rejectedremarks, string approvalRejectionflag, string stageid, string ApprovalLink)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "SP_flow_UpdatefromLegalMetrology";


        if (LgvID.Trim() == "" || LgvID.Trim() == null)
            com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LgvID", SqlDbType.VarChar).Value = LgvID.Trim();


        if (rejectedremarks.Trim() == "" || rejectedremarks.Trim() == null)
            com.Parameters.Add("@rejectedremarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@rejectedremarks", SqlDbType.VarChar).Value = rejectedremarks.Trim();

        if (AdditionalPayment.Trim() == "" || AdditionalPayment.Trim() == null)
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();


        if (ApprovalLink.Trim() == "" || ApprovalLink.Trim() == null)
            com.Parameters.Add("@ApprovalLink", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ApprovalLink", SqlDbType.VarChar).Value = ApprovalLink.Trim();


        if (approvalRejectionflag.Trim() == "" || approvalRejectionflag.Trim() == null)
            com.Parameters.Add("@approvalRejectionflag", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@approvalRejectionflag", SqlDbType.VarChar).Value = approvalRejectionflag.Trim();

        if (stageid.Trim() == "" || stageid.Trim() == null)
            com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@instageid", SqlDbType.VarChar).Value = stageid.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    [WebMethod]
    public string Discomstage(string UIDNO, string Dept, string APPROVALID,
string StatusCode, string StatusDescription, string FILEPATH, string Sysip)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            string intQuessionaireidcfo = ""; string intCFoEnterpid = ""; string UIDNOCFO = "";
            if (UIDNO == "" || UIDNO == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter UID Number";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (APPROVALID == "39" || APPROVALID == "40")
            {
                DataSet dsuidno = new DataSet();
                dsuidno = GetDepartmentFileno(UIDNO);

                if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireidcfo = dsuidno.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                    intCFoEnterpid = dsuidno.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                    UIDNOCFO = dsuidno.Tables[0].Rows[0]["UID_No"].ToString();
                }

            }


            if (valid == 0)
            {
                result = UpdateDiscomStage(UIDNO, UIDNOCFO,
  intQuessionaireidcfo, intCFoEnterpid, Dept, APPROVALID,
  StatusCode, StatusDescription, FILEPATH, Sysip);
            }





            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int UpdateDiscomStage(string UIDNO, string UIDNOCFO,
string intQuessionaireidcfo, string intCFoEnterpid, string Dept, string APPROVALID,
string StatusCode, string StatusDescription, string FILEPATH, string Sysip)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INS_DISCOMSTAGES";

        if (Sysip.Trim() == "" || Sysip.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = Sysip.Trim();

        if (UIDNO.Trim() == "" || UIDNO.Trim() == null)
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UIDNO.Trim();

        if (UIDNOCFO.Trim() == "" || UIDNOCFO.Trim() == null)
            com.Parameters.Add("@UIDNOCFO", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@UIDNOCFO", SqlDbType.VarChar).Value = UIDNOCFO.Trim();


        if (intQuessionaireidcfo.Trim() == "" || intQuessionaireidcfo.Trim() == null)
            com.Parameters.Add("@intQuessionaireidcfo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireidcfo", SqlDbType.VarChar).Value = intQuessionaireidcfo.Trim();


        if (intCFoEnterpid.Trim() == "" || intCFoEnterpid.Trim() == null)
            com.Parameters.Add("@intCFoEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFoEnterpid", SqlDbType.VarChar).Value = intCFoEnterpid.Trim();


        if (Dept.Trim() == "" || Dept.Trim() == null)
            com.Parameters.Add("@Dept", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Dept", SqlDbType.VarChar).Value = Dept.Trim();


        if (APPROVALID.Trim() == "" || APPROVALID.Trim() == null)
            com.Parameters.Add("@APPROVALID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@APPROVALID", SqlDbType.VarChar).Value = APPROVALID.Trim();

        if (StatusCode.Trim() == "" || StatusCode.Trim() == null)
            com.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@StatusCode", SqlDbType.VarChar).Value = StatusCode.Trim();

        if (StatusDescription.Trim() == "" || StatusDescription.Trim() == null)
            com.Parameters.Add("@StatusDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@StatusDescription", SqlDbType.VarChar).Value = StatusDescription.Trim();

        if (FILEPATH.Trim() == "" || FILEPATH.Trim() == null)
            com.Parameters.Add("@FILEPATH", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEPATH", SqlDbType.VarChar).Value = FILEPATH.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }

    [WebMethod]
    public string SPDCLReleaseDetails(string Officer, string location,
string CustomerName, string Address1, string Address2, string Address3, string District,
string UIDNO, string ReleasedDate, string Applicantname, string Registrationnumber, string RegisteredDate,
string Load, string Units, string Category, string VOLTAGE, string servicenumber, string QUESTIONNAIREID, string CFEID)
    {
        try
        {
            string APPROVALID = "";
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            string intQuessionaireidcfo = ""; string intCFoEnterpid = ""; string UIDNOCFO = "";
            if (UIDNO == "" || UIDNO == null)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Please Enter UID Number";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (APPROVALID == "40")
            {
                DataSet dsuidno = new DataSet();
                dsuidno = GetDepartmentFileno(UIDNO);

                if (dsuidno != null && dsuidno.Tables.Count > 0 && dsuidno.Tables[0].Rows.Count > 0)
                {
                    intQuessionaireidcfo = dsuidno.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                    intCFoEnterpid = dsuidno.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                    UIDNOCFO = dsuidno.Tables[0].Rows[0]["UID_No"].ToString();
                }

            }


            if (valid == 0)
            {
                string[] newdate = ReleasedDate.ToString().Split('/');
                string ReleasedDate1 = newdate[2].ToString() + "/" + newdate[1].ToString() + "/" + newdate[0].ToString();
                string[] newdate1 = RegisteredDate.ToString().Split('/');
                string RegisteredDate1 = newdate1[2].ToString() + "/" + newdate1[1].ToString() + "/" + newdate1[0].ToString();
                result = InsertSPDCLReleaseDetails(Officer,
 location, CustomerName, Address1, Address2, Address3, District, UIDNO,
 ReleasedDate1, Applicantname, Registrationnumber, RegisteredDate1, Load,
 Units, Category, VOLTAGE, servicenumber, QUESTIONNAIREID, CFEID);
            }

            if (result > 0 && valid == 0)
            {
                dr = dt.NewRow();
                dr[0] = "3";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "4";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int InsertSPDCLReleaseDetails(string Officer,
string location, string CustomerName, string Address1, string Address2, string Address3,
string District, string UIDNO, string ReleasedDate, string Applicantname, string Registrationnumber,
string RegisteredDate, string Load, string Units, string Category, string VOLTAGE,
string servicenumber, string QUESTIONNAIREID, string CFEID)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INS_SPDCL_RELEASEDETAILS";

        if (Officer.Trim() == "" || Officer.Trim() == null)
            com.Parameters.Add("@Officer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Officer", SqlDbType.VarChar).Value = Officer.Trim();



        if (location.Trim() == "" || location.Trim() == null)
            com.Parameters.Add("@location", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@location", SqlDbType.VarChar).Value = location.Trim();


        if (CustomerName.Trim() == "" || CustomerName.Trim() == null)
            com.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = CustomerName.Trim();


        if (Address1.Trim() == "" || Address1.Trim() == null)
            com.Parameters.Add("@Address1", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Address1", SqlDbType.VarChar).Value = Address1.Trim();


        if (Address2.Trim() == "" || Address2.Trim() == null)
            com.Parameters.Add("@Address2", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Address2", SqlDbType.VarChar).Value = Address2.Trim();


        if (Address3.Trim() == "" || Address3.Trim() == null)
            com.Parameters.Add("@Address3", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Address3", SqlDbType.VarChar).Value = Address3.Trim();

        if (District.Trim() == "" || District.Trim() == null)
            com.Parameters.Add("@District", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@District", SqlDbType.VarChar).Value = District.Trim();
        if (UIDNO.Trim() == "" || UIDNO.Trim() == null)
            com.Parameters.Add("@UID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UID", SqlDbType.VarChar).Value = UIDNO.Trim();

        if (ReleasedDate.Trim() == "" || ReleasedDate.Trim() == null)
            com.Parameters.Add("@ReleasedDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ReleasedDate", SqlDbType.VarChar).Value = cmf.convertDateIndia(ReleasedDate);


        if (Applicantname.Trim() == "" || Applicantname.Trim() == null)
            com.Parameters.Add("@Applicantname", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Applicantname", SqlDbType.VarChar).Value = Applicantname.Trim();

        if (Registrationnumber.Trim() == "" || Registrationnumber.Trim() == null)
            com.Parameters.Add("@Registrationnumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Registrationnumber", SqlDbType.VarChar).Value = Registrationnumber.Trim();

        if (RegisteredDate.Trim() == "" || RegisteredDate.Trim() == null)
            com.Parameters.Add("@RegisteredDate", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RegisteredDate", SqlDbType.VarChar).Value =
                 cmf.convertDateIndia(RegisteredDate);

        if (Load.Trim() == "" || Load.Trim() == null)
            com.Parameters.Add("@Load", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Load", SqlDbType.VarChar).Value = Load.Trim();

        if (Units.Trim() == "" || Units.Trim() == null)
            com.Parameters.Add("@Units", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Units", SqlDbType.VarChar).Value = Units.Trim();

        if (Category.Trim() == "" || Category.Trim() == null)
            com.Parameters.Add("@Category", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category.Trim();

        if (VOLTAGE.Trim() == "" || VOLTAGE.Trim() == null)
            com.Parameters.Add("@VOLTAGE", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VOLTAGE", SqlDbType.VarChar).Value = VOLTAGE.Trim();

        if (servicenumber.Trim() == "" || servicenumber.Trim() == null)
            com.Parameters.Add("@servicenumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@servicenumber", SqlDbType.VarChar).Value = servicenumber.Trim();

        if (QUESTIONNAIREID.Trim() == "" || QUESTIONNAIREID.Trim() == null)
            com.Parameters.Add("@QUESTIONNAIREID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QUESTIONNAIREID", SqlDbType.VarChar).Value = QUESTIONNAIREID.Trim();

        if (CFEID.Trim() == "" || CFEID.Trim() == null)
            com.Parameters.Add("@CFEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CFEID", SqlDbType.VarChar).Value = CFEID.Trim();


        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }


    }
}