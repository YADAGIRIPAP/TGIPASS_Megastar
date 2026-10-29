using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using DataAccessLayer;

/// <summary>
/// Summary description for Cls_travelagent
/// </summary>
public class Cls_travelagent
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_travelagent()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet GetDepartmentDashboardDetails_tourismagent(string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_GetAdminDashboardDetailstourismagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

    public DataSet GetShowDepartmentFilestourismagent(string Deptid, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_GetShowDepartmentFilestourismagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();

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


    public DataSet GetQueryRaisedOneTimeTourismagent(string intCFEEnterpid, string intDeptid, string intApprovalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_GetQueryRaisedbyOnetimetourismagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();


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

    public int insertDepartmentProcessTourisamagent(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcess_tourismagent";

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
    //TA_UpdatetDeptApprovalnewtourismagent

    public int insertQueryResponsedatatourismagent(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "TA_insertQueriesDetailstourismagent";

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


    public DataSet GetShowEmailidandMobileNumber_Tourismagent(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumber_tourismagent", con.GetConnection);
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

    public int InsertDeptDateTracing_Tourismagent(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
    {
        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand("TA_INS_DASHBOARDDATA_tourismagent", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", Convert.ToString(DepartmentId));
            cmd.Parameters.AddWithValue("@QuessionaireId", Convert.ToString(QuessionaireId));
            cmd.Parameters.AddWithValue("@Uid_No", Convert.ToString(Uid_No));
            cmd.Parameters.AddWithValue("@Apply_Date", Apply_Date);
            cmd.Parameters.AddWithValue("@PreScrutinity_Date", PreScrutinity_Date);
            cmd.Parameters.AddWithValue("@QueryRaised_Date", QueryRaised_Date);
            cmd.Parameters.AddWithValue("@QueryRespond_Date", QueryRespond_Date);
            cmd.Parameters.AddWithValue("@Approval_Date", Approval_Date);
            cmd.Parameters.AddWithValue("@Application_Type", Application_Type);
            cmd.Parameters.AddWithValue("@ApprovalId", ApprovalId);
            cmd.ExecuteNonQuery();
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
        return valid;
    }

    public int UpdateAdditionalpaymentsBeforePre_tourismagent(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBeforePre_tourismagent";
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


    public int UpdateAdditionalpayments_Tourismagent(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "TA_UpdatetDeptApprovalnewtourismagent";

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

    public DataSet GetCompletedbyApproval_Travelagent2A(string status, string FromDate, string Todate, string intDeptid)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("TA_GetApprovalProcessdata_Travelagent2A", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null || status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = status.Trim();
            }


            if (FromDate.Trim() == "" || FromDate.Trim() == null || FromDate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(FromDate);
            }

            if (Todate.Trim() == "" || Todate.Trim() == null || Todate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Todate);
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

    public DataSet GetCompletedbyApproval_Travelagent3A(string status, string FromDate, string Todate, string intDeptid)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("TA_GetApprovalProcessdata_Travelagent3A", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null || status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = status.Trim();
            }


            if (FromDate.Trim() == "" || FromDate.Trim() == null || FromDate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(FromDate);
            }

            if (Todate.Trim() == "" || Todate.Trim() == null || Todate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Todate);
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

    public DataSet GetCompletedbyApproval_Travelagent(string status, string FromDate, string Todate, string intDeptid)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("TA_GetApprovalProcessdataTravelagent", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (status.Trim() == "" || status.Trim() == null || status.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Applid", SqlDbType.VarChar).Value = status.Trim();
            }
            if (FromDate.Trim() == "" || FromDate.Trim() == null || FromDate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(FromDate);
            }
            if (Todate.Trim() == "" || Todate.Trim() == null || Todate.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Todate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Todate);
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

    public int insertDepartmentProcess_TravelAgent(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "TA_insertDepartmentProcess_travelagentadmin";

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

    public int insertApprovalDataTravelagent(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string ipaddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "TA_updateApprovaldatatravelagent";

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

    public DataSet GetShowEmailidandMobileNumber_travelagent(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_GetShowEmailidandMobileNumbertravelagent", con.GetConnection);
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

    public DataSet GetdataofApprovaldataAproval_TravelagentbyID(string enterprenuer, string intDeptid)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("TA_getenterprenuerdatbyidAprovalsNew_Travelagent", con.GetConnection);
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

    public int InsertAttachementApproval_Travelagent(string intQuessionaireCFOid, string intCFOEnterpid, string Uid_No, string Reg_Id,
      string AttachmentTypeName, string AttachmentFilename, string AttachmentFilePath, string Status, string Created_by, string FileDescription, string intDeptid, string intApprovalid)
    {
        try
        {

            con.OpenConnection();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("TA_AttachmentDetDeptApprovaltravelagent", con.GetConnection);
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
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Int32.Parse(Created_by.Trim());
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

    public DataSet GetPaymentDetails_Travelagent(string UID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_FetchEntrpPaymentDetails_Travelagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (UID.Trim() == "" || UID.Trim() == null || UID.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@UID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UID", SqlDbType.VarChar).Value = UID.ToString();

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

    public DataSet GetQueryResponseDetailsByEnterpIDDept_Travelagent(string intCFEEnterpid, string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_RetriveQueriesDetailsAndEntDetByIDDept_travelagentNew", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();


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

    public DataSet GetQueryResponseDetailsByEnterpID_Travelagent(string intCFEEnterpid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            //sp_RetriveQueriesDetailsAndEntDetByIDREN
            da = new SqlDataAdapter("sp_RetriveQueriesDetailsAndEntDetByIDREN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();

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


  
    public DataSet RetriveLinkForDDCFO_travelagent(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_RetriveLinkForDD_travelagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();



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
    public DataSet GetdatabyDeptinRENdocumentRespondDetails(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_RetrivelinkbyDeptidtravelagentbyRespondant", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();
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

    public DataSet GetdatabyDeptin_travelagentdocument(string intEnterprenuerid, string deptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_RetrivelinkbyDeptid_travelagentbyapporval", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();

            if (deptid.Trim() == "" || deptid.Trim() == null || deptid.Trim() == "10" || deptid.Trim() == "1000")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = deptid.ToString();

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

    public DataSet Getdata_TravelAgentApprovaldocument(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("TA_RetriveApprovallinkTravelagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();


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

    public DataSet ViewAttachment_TravelAgent(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        try
        {
            da = new SqlDataAdapter("TA_RetriveAttachmentTravelagent", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();

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

    public int InsertDeptDateTracing_TourismTravelagent(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
    {
        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand("TA_USP_INS_DASHBOARDDATA_TTA", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentId", Convert.ToString(DepartmentId));
            cmd.Parameters.AddWithValue("@QuessionaireId", Convert.ToString(QuessionaireId));
            cmd.Parameters.AddWithValue("@Uid_No", Convert.ToString(Uid_No));
            cmd.Parameters.AddWithValue("@Apply_Date", Apply_Date);
            cmd.Parameters.AddWithValue("@PreScrutinity_Date", PreScrutinity_Date);
            cmd.Parameters.AddWithValue("@QueryRaised_Date", QueryRaised_Date);
            cmd.Parameters.AddWithValue("@QueryRespond_Date", QueryRespond_Date);
            cmd.Parameters.AddWithValue("@Approval_Date", Approval_Date);
            cmd.Parameters.AddWithValue("@Application_Type", Application_Type);
            cmd.Parameters.AddWithValue("@ApprovalId", ApprovalId);
            cmd.ExecuteNonQuery();
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
        return valid;
    }

    public DataSet GetShowDepartmentFilesIndusSearch_TourismTravelagent(string Deptid, string intStageid, string intDistrictid, string NameofUnit, string UIDNUmber, string District_Id, string level)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            if (level == "1")
            {
                level = "Mega,Large,Medium";
            }
            else if (level == "2")
            {
                level = "Small,Micro";
            }
            else if (level == "--Select--")
            {
                level = "Mega,Large,Medium,Small,Micro";
            }
            da = new SqlDataAdapter("TAGetShowDepartmentFilesSearch_TTA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();

            if (level.Trim() == "" || level.Trim() == null)
                da.SelectCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@level", SqlDbType.VarChar).Value = level.ToString();

            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();

            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();

            if (District_Id.Trim() == "" || District_Id.Trim() == null || District_Id.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@District_Id", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@District_Id", SqlDbType.VarChar).Value = District_Id.ToString();

            if (NameofUnit.Trim() == "" || NameofUnit.Trim() == null)
                da.SelectCommand.Parameters.Add("@NameofUnit", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@NameofUnit", SqlDbType.VarChar).Value = "%" + NameofUnit.ToString() + "%";
            if (UIDNUmber.Trim() == "" || UIDNUmber.Trim() == null)
                da.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = "%" + UIDNUmber.ToString() + "%";
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

    public DataSet Get_TravelagentPOPUPDetailsNew(string UIDNO)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("TA_getpopdatabyUIDNO", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (UIDNO.Trim() == "" || UIDNO.Trim() == null || UIDNO.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UIDNO;
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

}