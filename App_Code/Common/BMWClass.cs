using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;
using DataAccessLayer;
/// <summary>
/// Summary description for BMWClass
/// </summary>
public class BMWClass
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public BMWClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetBWMDashboardDetails(string intEntid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetBWMDashboardDetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (intEntid.Trim() == "" || intEntid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = intEntid.ToString();

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



    public DataSet GetShowBWMQuestionaries(string Created_by, string INTAPPLICATIONID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getBWMdashboarddrilldown", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();

            if (INTAPPLICATIONID.Trim() == "" || INTAPPLICATIONID.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTAPPLICATIONID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTAPPLICATIONID", SqlDbType.VarChar).Value = INTAPPLICATIONID.ToString();

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


    public DataSet getBWMdashboarddrilldown(string intEntid, string status, string intQuessionaireid, string createddt)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getBWMdashboarddrilldown", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();

            if (intEntid.Trim() == "" || intEntid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = intEntid.ToString();

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            if (createddt.Trim() == "" || createddt.Trim() == null)
                da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = createddt.ToString();
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

    public DataSet GetUidnumberBMW(string intQuessionaireid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getUIDNumberdataBMW", con.GetConnection);
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
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet GetEnterPreniourPayDetailsPaidDetBMW(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsPaidDetBMW", con.GetConnection);
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
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet GetEnterPreniourPayDetailsAddtionalPaymentBMW(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetEnterPreniourPayDetails_AddtionalPaymentBMW]", con.GetConnection);
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
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet GetShowBWMQuestionaries2(string Created_by, string INTAPPLICATIONID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowBWMQuestionaries", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.ToString();

            if (INTAPPLICATIONID.Trim() == "" || INTAPPLICATIONID.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTAPPLICATIONID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTAPPLICATIONID", SqlDbType.VarChar).Value = INTAPPLICATIONID.ToString();

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

    public DataSet GetdataRedirectionurltopcbBWM(string questionniareid, string enterprenurid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DATAFROMPCB_BMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (questionniareid.Trim() == "" || questionniareid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTQUESTIONNAIREID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTQUESTIONNAIREID", SqlDbType.VarChar).Value = questionniareid.ToString();

            if (enterprenurid.Trim() == "" || enterprenurid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTENTERID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTENTERID", SqlDbType.VarChar).Value = enterprenurid.ToString();

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

    public DataSet getdataofidentityBWM(string intQuessioneryid, string deptid)
    {


        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {

            da = new SqlDataAdapter("GetDeptOrderBWM", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessioneryid.Trim() == "" || intQuessioneryid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessioneryid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessioneryid", SqlDbType.VarChar).Value = intQuessioneryid.ToString();



            if (deptid.Trim() == "" || deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@deptid", SqlDbType.VarChar).Value = deptid.ToString();
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

    public DataSet GetBWMdatabyReq(string intHCEID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet dst = new DataSet();
        try
        {
            da = new SqlDataAdapter("getBWMdatabyHCEID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intHCEID.Trim() == "" || intHCEID.Trim() == null)
                da.SelectCommand.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = intHCEID.ToString();



            da.Fill(dst);
            return dst;


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

    public DataSet GetEnterPreniourPayDetailsBMW(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsBMW", con.GetConnection);
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
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    public DataSet GetEnterPreneurdatabyQueBMW(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuerdatabyQuesBMW", con.GetConnection);
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
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    public int InsertUIDGenerationBMW(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string Payment_Mode, string Payment_DDNo, string Payment_DDDate, string Payment_Amount, string BankName, string BankBranchName, string Payment_FileName, string Payment_FilePath, string Created_by, string Created_dt, string Modified_by, string Modified_dt, string UIDNumber)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[sp_InsertUIDGenerationBMW]";

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());

        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


        if (Payment_DDNo == "" || Payment_DDNo == null)
            com.Parameters.Add("@Payment_DDNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Payment_DDNo", SqlDbType.VarChar).Value = Payment_DDNo.Trim();

        if (UIDNumber.ToString().Trim() == "" || UIDNumber.ToString().Trim() == null)
            com.Parameters.Add("@UIDNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UIDNumber", SqlDbType.VarChar).Value = UIDNumber.Trim();

        if (Payment_DDDate.Trim() == "" || Payment_DDDate.Trim() == null || Payment_DDDate.Trim() == "--Select--")
        {
            com.Parameters.Add("@Payment_DDDate", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Payment_DDDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Payment_DDDate.Trim());
        }

        if (Payment_Amount == "" || Payment_Amount == null)
            com.Parameters.Add("@Payment_Amount", SqlDbType.Decimal).Value = DBNull.Value;
        else
            com.Parameters.Add("@Payment_Amount", SqlDbType.Decimal).Value = Payment_Amount.Trim();

        if (Payment_Mode == "" || Payment_Mode == null)
            com.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Payment_Mode", SqlDbType.VarChar).Value = Payment_Mode.Trim();

        if (BankName == "" || BankName == null)
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankName", SqlDbType.VarChar).Value = BankName.Trim();

        if (BankBranchName == "" || BankBranchName == null)
            com.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = BankBranchName.Trim();

        if (Payment_FileName == "" || Payment_FileName == null)
            com.Parameters.Add("@Payment_FileName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Payment_FileName", SqlDbType.VarChar).Value = Payment_FileName.Trim();

        if (Payment_FilePath == "" || Payment_FilePath == null)
            com.Parameters.Add("@Payment_FilePath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Payment_FilePath", SqlDbType.VarChar).Value = Payment_FilePath.Trim();

        if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
        }

        if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
        {
            com.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
        }


        if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
        {
            com.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
        }

        if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
        {
            com.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
        }

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

    public int UpdateAdditionalpaymentsUIDBMW(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBMW";


        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

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

    public DataSet GetQuestionaryAprovalsApplyDataBMW(string intQuessionaireid, string intDeptid, string intApprovalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetQuestionaryAprovalsApplyDataBMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.ToString();



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

    public DataSet GetDepartmentonuidBMW(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DEPARTMENTS_UID_BMW", con.GetConnection);
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

    public DataSet getdepartmentdetailsonuidBMW(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDETAILS_DEPARTMENT_SERVICE_BMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
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

    public DataSet getAdditionalPaymentDetailsBMW(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ADDITIONALPAYMENTDETAILS_BMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (uidno.Trim() != "" || uidno.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = null;
            }
            if (deptid.Trim() != "" || deptid.Trim() != null)
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = deptid.ToString();
            }
            else
            {
                da.SelectCommand.Parameters.Add("@DEPARTMENTID", SqlDbType.VarChar).Value = null;
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

    public DataSet GetEnterprinerpaymentDtlsBMW(string UID, string Orderno, string AdditionalPaymentflg)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_Builldesc_PaymentDtls_DESE_BMW]", con.GetConnection);
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

    public int HealthcareestablishmentData(string Health_care_establishmentname, string HCE_locationPostal_Address, string Pincode, string Revenue_district, string Created_by, string Mandal, string Village, string Applicationtype,string HCEID)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INS_BMWVALUES";

        if (Health_care_establishmentname == "" || Health_care_establishmentname == null)
            com.Parameters.Add("@Health_care_establishmentname", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Health_care_establishmentname", SqlDbType.VarChar).Value = Health_care_establishmentname.Trim();

        if (HCE_locationPostal_Address == "" || HCE_locationPostal_Address == null)
            com.Parameters.Add("@HCE_locationPostal_Address", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@HCE_locationPostal_Address", SqlDbType.VarChar).Value = HCE_locationPostal_Address.Trim();

        if (Pincode == "" || Pincode == null)
            com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = Pincode.Trim();
 

        if (Revenue_district == "" || Revenue_district == null)
            com.Parameters.Add("@Revenue_district", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Revenue_district", SqlDbType.VarChar).Value = Revenue_district;

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (Mandal == "" || Mandal == null)
            com.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = Mandal.Trim();


        if (Village == "" || Village == null)
            com.Parameters.Add("@Village", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Village", SqlDbType.VarChar).Value = Village.Trim();

        if (Applicationtype == "" || Applicationtype == null)
            com.Parameters.Add("@Applicationtype", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Applicationtype", SqlDbType.VarChar).Value = Applicationtype.Trim();

        if (HCEID == "" || HCEID == null)
            com.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@HCEID", SqlDbType.VarChar).Value = HCEID.Trim();


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

    public DataSet GetQueryStatusByTransactionIDBMW(string User_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetQueryStatusByTransactionIDBMW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = User_id.ToString();

            if (User_id.Trim() == "" || User_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = "%";



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

    public DataSet ApplicationWiseDetailedTrakerREN(string Quesionary_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveR4ReportRENNew", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (Quesionary_id.Trim() == "" || Quesionary_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = Quesionary_id.ToString();

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

    public DataSet ApplicationWiseDetailedTrakerBMW(string Quesionary_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveR4ReportBMWNew", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            if (Quesionary_id.Trim() == "" || Quesionary_id.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = Quesionary_id.ToString();

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

    public int insertDepartmentProcessBWM(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcessBWM";
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

    public DataSet GetPaymentDetailsBWM(string UID)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("FetchEntrpPaymentDetailsBWM", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (UID.Trim() == "" || UID.Trim() == null || UID.Trim() == "--Select--")

                da.SelectCommand.Parameters.Add("@UID", SqlDbType.VarChar).Value = "%";
            else

                da.SelectCommand.Parameters.Add("@UID", SqlDbType.VarChar).Value = UID.ToString();
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {                        //throw ex;
            return null;
        }
        finally
        {
            con.CloseConnection();
        }

    }

    public int UpdateDepartwebserviceflagBMW(string uidno, string deptid, string flag, string output, string statusflag)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_DEPTCOMMONFEILDS_BMW";

        if (uidno == "" || uidno == null)
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = uidno.Trim();

        if (deptid == "" || deptid == null)
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DEPTID", SqlDbType.VarChar).Value = deptid.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (statusflag == "" || statusflag == null)
            com.Parameters.Add("@STATUSFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@STATUSFLAG", SqlDbType.VarChar).Value = statusflag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

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