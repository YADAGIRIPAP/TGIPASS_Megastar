using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for Legalverify
/// </summary>
public class Legalverify
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();

    public DataSet GetVillagebymandallegal(string intstateid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getVillagebymandalLegal", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intstateid.Trim() == "" || intstateid.Trim() == null || intstateid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = intstateid.ToString();

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

    public DataSet GetQuestionaryAprovalsApplyDataLegal(string intQuessionaireid, string intDeptid, string intApprovalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetQuestionaryAprovalsApplyDataLegal", con.GetConnection);
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

    public DataSet GetDistricts()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getDistrictsLegal", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetVillagebymandal(string intstateid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getVillagebymandal", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intstateid.Trim() == "" || intstateid.Trim() == null || intstateid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intstateid", SqlDbType.VarChar).Value = intstateid.ToString();
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

    public DataSet getMandalsbydistrictLegal(string intstateid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getMandalsbydistrictLegal", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intstateid.Trim() == "" || intstateid.Trim() == null || intstateid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intdistId", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intdistId", SqlDbType.VarChar).Value = intstateid.ToString();
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
    public DataSet GetEnterPreniourPayDetailsLegalverification(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsLegalverification", con.GetConnection);
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

    public DataSet GetEntreprenuerPayDetailsPaidDetLegalverify(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEntreprenuerPayDetailsPaidDetLegalverify", con.GetConnection);
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


    public DataSet GetEnterpreneourDashboardDetails_Legal(string intEntid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_GetEnterpreneourDashboardDetails_Legal", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intEntid.Trim() == "" || intEntid.Trim() == null)
                da.SelectCommand.Parameters.Add("@LGVid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@LGVid", SqlDbType.VarChar).Value = intEntid.ToString();
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


    public int UpdateAdditionalpaymentsUIDLegal(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewLegal";


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

    public DataSet getEnterprenuerdatabyQuesLegalV(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuerdatabyQuesLegalV", con.GetConnection);
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
    public DataSet getEnterprenuerLegalverificationdashboarddrilldown(string intEntid, string status, string intQuessionaireid, string createddt)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[getEnterprenuerLegalverificationdashboarddrilldown]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();

            //if (intEntid.Trim() == "" || intEntid.Trim() == null)
            //    da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = "%";
            //else
            //    da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = intEntid.ToString();

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();

            //if (createddt.Trim() == "" || createddt.Trim() == null)
            //    da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = "%";
            //else
            //    da.SelectCommand.Parameters.Add("@createddt", SqlDbType.VarChar).Value = createddt.ToString();
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
    public DataSet GetShowLegalverification(string Created_by, string INTAPPLICATIONID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetShowLegalMetrology]", con.GetConnection);
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

    public DataSet GetUidnumberLegal(string intQuessionaireid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getUIDNumberdataLegal", con.GetConnection);
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

    public DataSet GetEnterPreniourPayDetailsPaidDetLEGAL(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsPaidDetLEGAL", con.GetConnection);
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

    public DataSet GetEnterPreniourPayDetailsAddtionalPaymentlEGAL(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GetEnterPreniourPayDetails_AddtionalPaymentLEGAL]", con.GetConnection);
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

    public DataSet GetEnterPreniourPayDetailsLEGAL(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsLEGAL", con.GetConnection);
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
    public DataSet GetEnterPreneurdatabyQueLEGAL(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getEnterprenuerdatabyQuesLEGAL", con.GetConnection);
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

    public int InsertUIDGenerationLEGAL(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid, string Payment_Mode, string Payment_DDNo, string Payment_DDDate, string Payment_Amount, string BankName, string BankBranchName, string Payment_FileName, string Payment_FilePath, string Created_by, string Created_dt, string Modified_by, string Modified_dt, string UIDNumber)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[sp_InsertUIDGenerationLEGAL]";

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

    public DataSet GetEnterprinerpaymentDtlsLEGAL(string UID, string Orderno, string AdditionalPaymentflg)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[USP_GET_Builldesc_PaymentDtls_DESE_LEGAL]", con.GetConnection);
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

    public DataSet GetDepartmentonuidLEGAL(string uidno)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_DEPARTMENTS_UID_LEGAL", con.GetConnection);
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

    public DataSet getdepartmentdetailsonuidLEGAL(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETDETAILS_DEPARTMENT_SERVICE_LEGAL", con.GetConnection);
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

    public DataSet getAdditionalPaymentDetailsLEGAL(string uidno, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ADDITIONALPAYMENTDETAILS_LEGAL", con.GetConnection);
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

    public int UpdateDepartwebserviceflagLEGAL(string uidno, string deptid, string flag, string output, string statusflag)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_DEPTCOMMONFEILDS_LEGAL";

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

    public DataSet GetenterpreneurdetailsLegalmetrology(string createdby)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_Legalverify_APPLICATIONID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (createdby.Trim() == "" || createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@CREATEDBY", SqlDbType.VarChar).Value = createdby.ToString();

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

    public DataSet ApplicationWiseDetailedTrakerLEGAL(string Quesionary_id)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("sp_RetriveR4ReportLEGALNew", con.GetConnection);
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
}




public class LegalMetrologyverify
{
    public string Nameoftheunit { get; set; }

    public string lgvstate { get; set; }
    public string lgvdistrict { get; set; }
    public string lgvmandal { get; set; }
    public string lgvvillage { get; set; }
    public string Created_by { get; set; }
    public string registrationtype { get; set; }
    public string Appstatus { get; set; }
    public int LgvID { get; set; }



}
