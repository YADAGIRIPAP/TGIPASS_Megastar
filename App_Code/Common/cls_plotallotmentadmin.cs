using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for cls_plotallotmentadmin
/// </summary>
public class cls_plotallotmentadmin
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public cls_plotallotmentadmin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetplotallotmentDepartmentDashboardDetails(string intDeptid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {          
                da = new SqlDataAdapter("PA_GetDepartmentDashboardplotallotmentDetails", con.GetConnection);
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
    public DataSet GetDistrictsofplot()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetDistrictsHYD", con.GetConnection);
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
    public DataSet GetShowDepartmentFilesSearch_plotallotment(string Deptid, string intStageid, string intDistrictid, string NameofUnit, string UIDNUmber)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        { 
            da = new SqlDataAdapter("GetShowDepartmentFilesSearch_plotallotment", con.GetConnection);
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
    public DataSet GetShowDepartmentFiles_plotallotment(string Deptid, string intStageid, string intDistrictid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowDepartmentFiles_plotallotment", con.GetConnection);
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
    public DataSet GetQueryRaised(string intCFEEnterpid, string intDeptid, string intApprovalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetQueryRaised", con.GetConnection);
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
    public int insertDepartmentProcess_plotallotment(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Created_by)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertDepartmentProcess_plotallotment";
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
    public int UpdateStatusofapplicant_plotallotment(string intCFEEnterpid,string Reason,string Status,string Created_by,string stageid,string dept,string Approval, string ipaddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "PA_UpdatetDeptApprovalnew_PlotAllotment";
        if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

        if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();
        if (Reason.Trim() == "" || Reason.Trim() == null)
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@QueryDescription", SqlDbType.VarChar).Value = Reason.Trim();
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
    public int insertQueryResponsedata(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid)
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertQueriesDetails";

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
    public int InsertDeptDateTracing_plotallotment(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
    {
        int valid = 0;
        con.OpenConnection();
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand("USP_INS_DASHBOARDDATA_plotallotment", con.GetConnection);
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
    public DataSet GetShowEmailidandMobileNumber_plotallotment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowEmailidandMobileNumber_plotallotment", con.GetConnection);
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

    public int UpdateAdditionalpaymentsBeforePre_plotallotment(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string Reason, string IPAddress)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "UpdatetDeptApprovalnewBeforePre_plotallotment";
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


    public DataSet GetdataofApprovaldataAprovalbyID_plotallotment(string enterprenuer, string intDeptid)
    {
        DataSet ds = new DataSet();
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("PA_getenterprenuerdatbyidAprovalsNew_plotallotment", con.GetConnection);
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


    public int InsertImagedataApproval_plotallotment(string intQuessionaireid,string FileType, string FilePath, string FileName, string FileDescription,
    string Created_by,string intDeptid, string intApprovalid)
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("PA_InsertImageApproval_plotallotment", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
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
            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
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


    public int insertApprovalData_plotallotment(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "PA_updateApprovaldata_plotallotment";
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

    public DataSet GetPaymentDetails_plotallotment(string UID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("PA_FetchEntrpPaymentDetails_PloatAllotment", con.GetConnection);
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

    public DataSet GetQueryResponseDetail_plotallotment(string intCFEEnterpid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("PA_RetriveQueriesDetails_DeptPlotallotment", con.GetConnection);
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


    public DataSet GePlotallotmentEnterprenuerDetailsNew_popup(string intSBenid)
    {
        DataSet ds = new DataSet();
        try
        {
            
            con.OpenConnection();
            SqlDataAdapter myDataAdapter;
            myDataAdapter = new SqlDataAdapter("PA_GetPlotAllotmentEnterprenuerDetailsNew", con.GetConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intSBenid.Trim() == "" || intSBenid.Trim() == null || intSBenid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@UIDNUmber", SqlDbType.VarChar).Value = intSBenid;
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