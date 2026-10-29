using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Cls_exciseliquoruser
/// </summary>
public class Cls_exciseliquoruser
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_exciseliquoruser()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Insertupdateexciseliquor(Exciseliquorobj obj)
    {
        string valid = "";

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("el_insertupdateexciseliquor", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            if (obj.gazetteserialno.ToString().Trim() == "" || obj.gazetteserialno.ToString().Trim() == null)
                cmd.Parameters.Add("@gazetteserialno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@gazetteserialno", SqlDbType.VarChar).Value = obj.gazetteserialno.Trim();

            if (obj.Location.ToString().Trim() == null || obj.Location.ToString().Trim() == "")
                cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Location", SqlDbType.VarChar).Value = obj.Location.Trim();

            if (obj.ExciseStation.ToString().Trim() == "" || obj.ExciseStation.ToString().Trim() == null)
                cmd.Parameters.Add("@ExciseStation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ExciseStation", SqlDbType.VarChar).Value = obj.ExciseStation.Trim();

            if (obj.exciseDistrictID.ToString().Trim() == "" || obj.exciseDistrictID.ToString().Trim() == null)
                cmd.Parameters.Add("@exciseDistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@exciseDistrictID", SqlDbType.VarChar).Value = obj.exciseDistrictID.Trim();

            if (obj.exciseDistrictName.ToString().Trim() == "" || obj.exciseDistrictName.ToString().Trim() == null)
                cmd.Parameters.Add("@exciseDistrictName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@exciseDistrictName", SqlDbType.VarChar).Value = obj.exciseDistrictName.Trim();

            if (obj.retailtaxslabyearinlakhs.ToString().Trim() == "" || obj.retailtaxslabyearinlakhs.ToString().Trim() == null)
                cmd.Parameters.Add("@retailtaxslabyearinlakhs", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@retailtaxslabyearinlakhs", SqlDbType.VarChar).Value = obj.retailtaxslabyearinlakhs.Trim();

            if (obj.applicantname.ToString().Trim() == "" || obj.applicantname.ToString().Trim() == null)
                cmd.Parameters.Add("@applicantname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@applicantname", SqlDbType.VarChar).Value = obj.applicantname.Trim();

            if (obj.applicationfathername.ToString().Trim() == "" || obj.applicationfathername.ToString().Trim() == null)
                cmd.Parameters.Add("@applicationfathername", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@applicationfathername", SqlDbType.VarChar).Value = obj.applicationfathername.Trim();

            if (obj.applicantdateofbirth.ToString().Trim() == null || obj.applicantdateofbirth.ToString().Trim() == "")
                cmd.Parameters.Add("@applicantdateofbirth", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@applicantdateofbirth", SqlDbType.DateTime).Value = obj.applicantdateofbirth;

            if (obj.applicantage.ToString().Trim() == null || obj.applicantage.ToString().Trim() == "")
                cmd.Parameters.Add("@applicantage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@applicantage", SqlDbType.VarChar).Value = obj.applicantage;

            if (obj.houseno.ToString().Trim() == "" || obj.houseno.ToString().Trim() == null)
                cmd.Parameters.Add("@houseno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@houseno", SqlDbType.VarChar).Value = obj.houseno.Trim();

            if (obj.streetno.ToString().Trim() == "" || obj.streetno.ToString().Trim() == null)
                cmd.Parameters.Add("@streetno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@streetno", SqlDbType.VarChar).Value = obj.streetno.Trim();

            if (obj.ApplDistrictID.ToString().Trim() == "" || obj.ApplDistrictID.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplDistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplDistrictID", SqlDbType.VarChar).Value = obj.ApplDistrictID.Trim();

            if (obj.ApplicantMandal.ToString().Trim() == "" || obj.ApplicantMandal.ToString().Trim() == null)
                cmd.Parameters.Add("@ApplicantMandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ApplicantMandal", SqlDbType.VarChar).Value = obj.ApplicantMandal.Trim();

            if (obj.Applicantvillage.ToString().Trim() == "" || obj.Applicantvillage.ToString().Trim() == null)
                cmd.Parameters.Add("@Applicantvillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Applicantvillage", SqlDbType.VarChar).Value = obj.Applicantvillage;

            if (obj.pincode.ToString().Trim() == "" || obj.pincode.ToString().Trim() == null)
                cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = obj.pincode.Trim();

            if (obj.mobileno1.ToString().Trim() == "" || obj.mobileno1.ToString().Trim() == null)
                cmd.Parameters.Add("@mobileno1", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@mobileno1", SqlDbType.VarChar).Value = obj.mobileno1;

            if (obj.mobileno2.ToString().Trim() == "" || obj.mobileno2.ToString().Trim() == null)
                cmd.Parameters.Add("@mobileno2", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@mobileno2", SqlDbType.VarChar).Value = obj.mobileno2;
            if (obj.EmailID.ToString().Trim() == "" || obj.EmailID.ToString().Trim() == null)
                cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = obj.EmailID.Trim();

            if (obj.nameoffirmregistration.ToString().Trim() == "0" || obj.nameoffirmregistration.ToString().Trim() == null)
                cmd.Parameters.Add("@nameoffirmregistration", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@nameoffirmregistration", SqlDbType.VarChar).Value = obj.nameoffirmregistration.Trim();

            if (obj.registrationno.ToString().Trim() == "" || obj.registrationno.ToString().Trim() == null)
                cmd.Parameters.Add("@registrationno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@registrationno", SqlDbType.VarChar).Value = obj.registrationno;

            if (obj.registrationdate.ToString().Trim() == "" || obj.registrationdate.ToString().Trim() == null)
                cmd.Parameters.Add("@registrationdate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@registrationdate", SqlDbType.DateTime).Value = obj.registrationdate;

            if (obj.gistin.ToString().Trim() == "0" || obj.@gistin.ToString().Trim() == null)
                cmd.Parameters.Add("@gistin", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@gistin", SqlDbType.VarChar).Value = obj.gistin.Trim();
            if (obj.pancard.ToString().Trim() == "" || obj.pancard.ToString().Trim() == null)
                cmd.Parameters.Add("@pancard", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@pancard", SqlDbType.VarChar).Value = obj.pancard;
            if (obj.Aadharno.ToString().Trim() == "" || obj.Aadharno.ToString().Trim() == null)
                cmd.Parameters.Add("@Aadharno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@Aadharno", SqlDbType.VarChar).Value = obj.Aadharno.Trim();

            if (obj.isa4certificate.ToString().Trim() == "0" || obj.isa4certificate.ToString().Trim() == null)
                cmd.Parameters.Add("@isa4certificate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@isa4certificate", SqlDbType.VarChar).Value = obj.isa4certificate.Trim();

            if (obj.CreatedIP.ToString().Trim() == "" || obj.CreatedIP.ToString().Trim() == null)
                cmd.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = obj.CreatedIP.Trim();
            if (obj.CreatedBy.ToString().Trim() == "" || obj.CreatedBy.ToString().Trim() == null)
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = obj.CreatedBy.Trim();
            if (obj.ExciseliquorID.ToString().Trim() == "0" || obj.ExciseliquorID.ToString().Trim() == null)
                cmd.Parameters.Add("@ExciseliquorID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@ExciseliquorID", SqlDbType.VarChar).Value = obj.ExciseliquorID;

            cmd.Parameters.Add("@valid", SqlDbType.Int, 500);
            cmd.Parameters["@valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int res = (Int32)cmd.Parameters["@valid"].Value;
            valid = Convert.ToString(res);
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
    public DataSet getdatabyapplicantid(string CreatedBy)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("el_getdatabyapplicantid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (CreatedBy.Trim() == "" || CreatedBy.Trim() == null)
                da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy.ToString();
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
    public int SaveAttachmentsofExciseliquorID(string intexciseliquorID, string FileType, string FilePath, string FileName, string FileDescription, string Created_by)
    {
        int n = 0;
        try
        {
            con.OpenConnection();
            SqlCommand cmdFiles = new SqlCommand("usp_Insert_ExciseliquorID_attachments", con.GetConnection);
            cmdFiles.CommandType = CommandType.StoredProcedure;
            cmdFiles.Parameters.AddWithValue("@ExciseliquorID", Convert.ToInt32(intexciseliquorID));
            cmdFiles.Parameters.AddWithValue("@FileType", FileType);
            cmdFiles.Parameters.AddWithValue("@FilePath", FilePath);
            cmdFiles.Parameters.AddWithValue("@FileName", FileName);
            cmdFiles.Parameters.AddWithValue("@FileDescription", FileDescription);
            cmdFiles.Parameters.AddWithValue("@Created_by", Created_by);
            n = cmdFiles.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Created_by);
            con.CloseConnection();
            throw ex;

        }
        finally
        {

            con.CloseConnection();

        }
        return n;
    }






    public DataSet GetexciseliquorAppIDbyuserid(int UserID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("el_GetexciseliquorAppIDbyuserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
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

    public DataSet GetShowApprovalandFees_ExciseliquorOther(string ExciseliquorID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_exciseliquor", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ExciseliquorID.Trim() == "" || ExciseliquorID.Trim() == null)
                da.SelectCommand.Parameters.Add("@ExciseliquorID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@ExciseliquorID", SqlDbType.VarChar).Value = ExciseliquorID.ToString();
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


    public DataSet GetexciseliquorPayDetailsAddtionalPayment(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("el_GetexciseliquorPayDetails_AddtionalPayment", con.GetConnection);
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

    public int UpdateUIDexciseliqour(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("elUpdateUIDexciseliqour", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@UID_no", UID_no);
            cmd.Parameters.AddWithValue("@intQuessionaireid", intQuessionaireid);
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

    public int insertDepartmentAprroval_exciseliqour(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_exciseliqour";

        if (intQuessionaireid == "" || intQuessionaireid == null)
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

        if (Approval_Fee == "" || Approval_Fee == null)
            com.Parameters.Add("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Approval_Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(Approval_Fee.Trim());

        if (IsPayment == "" || IsPayment == null)
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsPayment", SqlDbType.VarChar).Value = IsPayment;

        if (Created_by == "" || Created_by == null)
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (IsOffline == "" || IsOffline == null)
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();
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


    public DataSet getexciseliqourdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getexciseliqourdatabyQues", con.GetConnection);
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

    public int InsertPaymentBillDesk_exciseliqour(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INSERT_Builldesc_PaymentDtls_exciseliqour";

        if (UidNo.Trim() == "" || UidNo.Trim() == null)
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@UIDNO", SqlDbType.VarChar).Value = UidNo.Trim();
        }
        if (intCFEEnterpid == "" || intCFEEnterpid == null)
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

        if (OnlineOrderNo == "" || OnlineOrderNo == null)
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();


        if (intDeptid == "" || intDeptid == null)
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

        if (intApprovalid == "" || intApprovalid == null)
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


        if (Online_Amount == "" || Online_Amount == null)
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Online_Amount", SqlDbType.VarChar).Value = Convert.ToDecimal(Online_Amount.Trim());


        if (Created_by.Trim() == "" || Created_by.Trim() == null)
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
        }
        if (AdditionalPayment == "" || AdditionalPayment == null)
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

        com.Parameters.Add("@ApplType", SqlDbType.VarChar).Value = ApplType.Trim();
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

public class Exciseliquorobj
{

    public int ExciseliquorID { get; set; }
public string gazetteserialno { get; set; }
public string Location   { get; set; }
public string ExciseStation  { get; set; }
public string exciseDistrictID   { get; set; }
public string exciseDistrictName { get; set; }
public string retailtaxslabyearinlakhs { get; set; }
public string applicantname { get; set; }
public string applicationfathername { get; set; }
public DateTime applicantdateofbirth  { get; set; }
public int applicantage { get; set; }
public string houseno { get; set; }
public string streetno { get; set; }
public string ApplDistrictID{ get; set; }
public string ApplicantMandal  { get; set; }
public string Applicantvillage   { get; set; }
public string pincode   { get; set; }
public string mobileno1   { get; set; }
public string mobileno2  { get; set; }
public string EmailID   { get; set; }
public string nameoffirmregistration  { get; set; }
public string registrationno  { get; set; }
public DateTime registrationdate { get; set; }
public string gistin  { get; set; }
public string pancard { get; set; }
public string Aadharno  { get; set; }
public string isa4certificate { get; set; }
public DateTime CreatedOn   { get; set; }
public string CreatedBy { get; set; }
public string CreatedIP  { get; set; }
public DateTime ModifiedOn  { get; set; }
public string ModifiedIP  { get; set; }
public string ModifiedBy{ get; set; }
public string StageID { get; set; }
public string ISPayment  { get; set; }
public DateTime PaymentDate  { get; set; }
public string UIDNO  { get; set; }


    
  
}
