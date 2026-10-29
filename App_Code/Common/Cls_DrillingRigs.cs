using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;


/// <summary>
/// Summary description for Cls_DrillingRigs
/// </summary>
public class Cls_DrillingRigs
{
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    //public Cls_DrillingRigs()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    #region Application insert,update
    public DataTable DB_getdistricts()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rigs_GetDistricts", con);
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
            con.Close();
        }
    }

    public DataTable DB_getmadals(string Districtid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetMandals", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = Districtid;
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public DataTable DB_GetVillages(string Mandalid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetVillages", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intMandalid", SqlDbType.VarChar).Value = Mandalid;
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public string DB_InsertDrillingRigs(RegistrationDrillingRigspro objdata)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_insertDrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (objdata.Applicationtype == "" || objdata.Applicationtype == null)
                cmdpacd.Parameters.AddWithValue("@Applicationtype", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Applicationtype", SqlDbType.VarChar).Value = objdata.Applicationtype.Trim();

            if (objdata.Applicationtypeid ==0)
                cmdpacd.Parameters.AddWithValue("@Applicationtypeid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Applicationtypeid", SqlDbType.VarChar).Value = objdata.Applicationtypeid;

            if (objdata.Nameoftheapplicant == "" || objdata.Nameoftheapplicant == null)
                cmdpacd.Parameters.AddWithValue("@Nameoftheapplicant", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Nameoftheapplicant", SqlDbType.VarChar).Value = objdata.Nameoftheapplicant.Trim();

            if (objdata.AddDistrictId == 0)
                cmdpacd.Parameters.AddWithValue("@AddDistrictId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddDistrictId", SqlDbType.VarChar).Value = objdata.AddDistrictId;

            if (objdata.AddDistrictName == "" || objdata.AddDistrictName == null)
                cmdpacd.Parameters.AddWithValue("@AddDistrictName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddDistrictName", SqlDbType.VarChar).Value = objdata.AddDistrictName.Trim();

            if (objdata.AddMandalid == 0)
                cmdpacd.Parameters.AddWithValue("@AddMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddMandalid", SqlDbType.VarChar).Value = objdata.AddMandalid;

            if (objdata.AddMandalname == "" || objdata.AddMandalname == null)
                cmdpacd.Parameters.AddWithValue("@AddMandalname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddMandalname", SqlDbType.VarChar).Value = objdata.AddMandalname.Trim();
            if (objdata.AddVillageid == 0)
                cmdpacd.Parameters.AddWithValue("@AddVillageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddVillageid", SqlDbType.VarChar).Value = objdata.AddVillageid;
            if (objdata.AddVillagename == "" || objdata.AddVillagename == null)
                cmdpacd.Parameters.AddWithValue("@AddVillagename", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AddVillagename", SqlDbType.VarChar).Value = objdata.AddVillagename.Trim();
            if (objdata.Street == "" || objdata.Street == null)
                cmdpacd.Parameters.AddWithValue("@Street", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Street", SqlDbType.VarChar).Value = objdata.Street.Trim();
            if (objdata.Houseno == "" || objdata.Houseno == null)
                cmdpacd.Parameters.AddWithValue("@Houseno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Houseno", SqlDbType.VarChar).Value = objdata.Houseno.Trim();

            if (objdata.regvehicleno == "" || objdata.regvehicleno == null)
                cmdpacd.Parameters.AddWithValue("@regvehicleno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@regvehicleno", SqlDbType.VarChar).Value = objdata.regvehicleno.Trim();
            if (objdata.rtoplaceofregvehicle == "" || objdata.rtoplaceofregvehicle == null)
                cmdpacd.Parameters.AddWithValue("@rtoplaceofregvehicle", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@rtoplaceofregvehicle", SqlDbType.VarChar).Value = objdata.rtoplaceofregvehicle.Trim();
            if (objdata.RTODistrictID == 0)
                cmdpacd.Parameters.AddWithValue("@RTODistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@RTODistrictID", SqlDbType.VarChar).Value = objdata.RTODistrictID;

            if (objdata.RTODistrictName == "" || objdata.RTODistrictName == null)
                cmdpacd.Parameters.AddWithValue("@RTODistrictName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@RTODistrictName", SqlDbType.VarChar).Value = objdata.RTODistrictName.Trim();

            if (objdata.Descofdrillrigs == "" || objdata.Descofdrillrigs == null)
                cmdpacd.Parameters.AddWithValue("@Descofdrillrigs", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Descofdrillrigs", SqlDbType.VarChar).Value = objdata.Descofdrillrigs.Trim();
            if (objdata.maxdiameterdepth == 0)
                cmdpacd.Parameters.AddWithValue("@maxdiameterdepth", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@maxdiameterdepth", SqlDbType.VarChar).Value = objdata.maxdiameterdepth;

            if (objdata.Areaofoperation == "" || objdata.Areaofoperation == null)
                cmdpacd.Parameters.AddWithValue("@Areaofoperation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Areaofoperation", SqlDbType.VarChar).Value = objdata.Areaofoperation.Trim();

            if (objdata.CreatedBy == "" || objdata.CreatedBy == null)
                cmdpacd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@CreatedBy", SqlDbType.VarChar).Value = objdata.CreatedBy.Trim();
            if (objdata.CreatedIP == "" || objdata.CreatedIP == null)
                cmdpacd.Parameters.AddWithValue("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@CreatedIP", SqlDbType.VarChar).Value = objdata.CreatedIP.Trim();

            if (objdata.ApplicantMobileno == "" || objdata.ApplicantMobileno == null)
                cmdpacd.Parameters.AddWithValue("@ApplicantMobileno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@ApplicantMobileno", SqlDbType.VarChar).Value = objdata.ApplicantMobileno.Trim();
            if (objdata.ApplicantEmailID == "" || objdata.ApplicantEmailID == null)
                cmdpacd.Parameters.AddWithValue("@ApplicantEmailID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@ApplicantEmailID", SqlDbType.VarChar).Value = objdata.ApplicantEmailID.Trim();


            cmdpacd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmdpacd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmdpacd.ExecuteNonQuery();
            valid = (Int32)cmdpacd.Parameters["@Valid"].Value;

           

            resp = Convert.ToString(valid);
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return resp;
    }

    public bool DB_InsertGroundwaterDrillingRigsattachments(RegistrationDrillingRigsfileuploadspro objfileuploads)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("usp_Insert_GroundwaterDrillingRigs_attachments", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (objfileuploads.ApplicationID == "" || objfileuploads.ApplicationID == null)
            {
                cmdpacd.Parameters.AddWithValue("@RegRigID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@RegRigID", SqlDbType.VarChar).Value = Convert.ToInt32(objfileuploads.ApplicationID);
            }
            if (objfileuploads.FileType == "" || objfileuploads.FileType == null)
            {
                cmdpacd.Parameters.AddWithValue("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileType", SqlDbType.VarChar).Value = Convert.ToString(objfileuploads.FileType);
            }
            if (objfileuploads.FilePath == "" || objfileuploads.FilePath == null)
            {
                cmdpacd.Parameters.AddWithValue("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FilePath", SqlDbType.VarChar).Value = Convert.ToString(objfileuploads.FilePath);
            }
            if (objfileuploads.FileName == "" || objfileuploads.FileName == null)
            {
                cmdpacd.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = Convert.ToString(objfileuploads.FileName);
            }
            if (objfileuploads.FileDescription == "" || objfileuploads.FileDescription == null)
            {
                cmdpacd.Parameters.AddWithValue("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileDescription", SqlDbType.VarChar).Value = Convert.ToString(objfileuploads.FileDescription);
            }
            if (objfileuploads.Created_by == "" || objfileuploads.Created_by == null)
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Convert.ToInt32(objfileuploads.Created_by);
            }



            cmdpacd.ExecuteNonQuery();
            retValue = true;
            //retValue = cmdpacd.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public DataSet DB_GETDrillingRigscompletedetailsbyuserid(int UserID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GETDrillingRigscompletedetailsbyuserid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
    public DataTable DB_documetmaster(string ApplicationTypeID,string ConditionID, string userid,string RegRigID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rigs_documetmaster", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ApplicationTypeID == "" || ApplicationTypeID == null)
            {
                da.SelectCommand.Parameters.Add("@ApplicationTypeID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApplicationTypeID", SqlDbType.VarChar).Value = ApplicationTypeID;
            }

            if (ConditionID == "" || ConditionID == null)
            {
                da.SelectCommand.Parameters.Add("@ConditionID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ConditionID", SqlDbType.VarChar).Value = ConditionID;
            }
            if (userid == "" || userid == null)
            {
                da.SelectCommand.Parameters.Add("@intuserid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@intuserid", SqlDbType.VarChar).Value = userid;
            }
           
            if (RegRigID == "" || RegRigID == null)
            {
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = RegRigID;
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
            con.Close();
        }
    }

    #endregion

    #region Payment

    public DataSet GetUidnumber_drillingrigs(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_getUIDNumberdatadrillingrigs", con);
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
            con.Close();
        }
    }
    public DataSet GetEnterPreniourPayDetailsPaidDetdrillingrigs(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            
            con.Open(); 
             da = new SqlDataAdapter("GetEnterPreniourPayDetailsPaidDet_drillingrigs", con);
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
            con.Close();
        }
    }
    public DataSet GetEnterPreniourPayDetailsDrillingRigs(string intQuessionaireid)
{
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open(); 
             da = new SqlDataAdapter("GetEnterPreniourPayDetails_DrillingRigs", con);
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
            con.Close();
        }
    }
    public DataSet GetEnterPreneurdatabyQue_DrillingRigs(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_getEnterprenuerdatabyQuesDrillingRigs", con);
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
            con.Close();
        }
    }


    public string InsertUIDGenerationGroundwater(string intQuessionaireid, string intCFEEnterpid, string intDeptid, string intApprovalid,
 string Payment_Mode, string Payment_Amount, string Created_by, string Created_dt, string Modified_by, string Modified_dt,
  string UIDNumber)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        string retValue = "";
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("rigs_InsertUIDGenerationDrillingrigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intQuessionaireid == "" || intQuessionaireid == null)
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());

            if (intCFEEnterpid == "" || intCFEEnterpid == null)
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

            if (intDeptid == "" || intDeptid == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

            if (intApprovalid == "" || intApprovalid == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());

            if (UIDNumber.ToString().Trim() == "" || UIDNumber.ToString().Trim() == null)
                cmdpacd.Parameters.AddWithValue("@UIDNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@UIDNumber", SqlDbType.VarChar).Value = UIDNumber.Trim();

            if (Payment_Amount == "" || Payment_Amount == null)
                cmdpacd.Parameters.AddWithValue("@Payment_Amount", SqlDbType.Decimal).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Payment_Amount", SqlDbType.Decimal).Value = Payment_Amount.Trim();

            if (Payment_Mode == "" || Payment_Mode == null)
                cmdpacd.Parameters.AddWithValue("@Payment_Mode", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Payment_Mode", SqlDbType.VarChar).Value = Payment_Mode.Trim();

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            //if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            //{
            //    cmdpacd.Parameters.AddWithValue("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmdpacd.Parameters.AddWithValue("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            //}

            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            //if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
            //{
            //    cmdpacd.Parameters.AddWithValue("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmdpacd.Parameters.AddWithValue("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
            //}
            retValue= Convert.ToString(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public int insertDepartmentAprroval_DrillingRigs(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
        {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("insDepartmentApprovals_DrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intQuessionaireid == "" || intQuessionaireid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();
            }
            if (intDeptid == "" || intDeptid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            }
              
            if (intApprovalid == "" || intApprovalid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
            }
            if (Approval_Fee == "" || Approval_Fee == null)
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(Approval_Fee.Trim());
            }
            if (IsPayment == "" || IsPayment == null)
            {
                cmdpacd.Parameters.AddWithValue("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@IsPayment", SqlDbType.VarChar).Value = IsPayment;
            }
            if (Created_by == "" || Created_by == null)
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            }
            if (IsOffline == "" || IsOffline == null)
            {
                cmdpacd.Parameters.AddWithValue("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();
            }
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public int InsertPaymentBillDesk_DrillingRigs(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("USP_INSERT_Builldesc_PaymentDtls_DrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
           
            if (UidNo.Trim() == "" || UidNo.Trim() == null)
            {
                cmdpacd.Parameters.AddWithValue("@UIDNO", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@UIDNO", SqlDbType.VarChar).Value = UidNo.Trim();
            }
            if (intCFEEnterpid == "" || intCFEEnterpid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }
            if (OnlineOrderNo == "" || OnlineOrderNo == null)
            {
                cmdpacd.Parameters.AddWithValue("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();
            }
            if (intDeptid == "" || intDeptid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }
            if (intApprovalid == "" || intApprovalid == null)
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }
            if (Online_Amount == "" || Online_Amount == null)
            {
                cmdpacd.Parameters.AddWithValue("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Online_Amount", SqlDbType.VarChar).Value = Online_Amount.Trim();
            }
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }
            if (AdditionalPayment == "" || AdditionalPayment == null)
            {
                cmdpacd.Parameters.AddWithValue("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();
            }
            cmdpacd.Parameters.AddWithValue("@ApplType", SqlDbType.VarChar).Value = ApplType.Trim();
             
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public DataSet GetDrillingRigspaymentDtls(string UID, string Orderno, string AdditionalPaymentflg)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("USP_GET_Builldesc_PaymentDtls_DrillingRigs_DESE", con);
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
            con.Close();
        }
    }

    #endregion


    #region User Dashboard
    public DataSet GETDrillingrigsdahboardlist(int UserID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GETDrillingrigsdahboardlist", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (UserID==0)
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
   #endregion

    #region  view attachment
    public DataSet GetdatadocumentbyQuestioneerieid_Drilligrigs(string intEnterprenuerid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetdatadocumentbyQueid_Drilligrigs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    #endregion

    #region  view Payment Details

    public DataSet BindUserPaymentReceipt_Drillingrigs(string TranRefNo)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GET_ACKNOWLEDGEMENT_Drillingrigspayment", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (TranRefNo.Trim() == "" || TranRefNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = TranRefNo.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    #endregion

    #region Print

    public DataSet GetDetailsbyDrillingRigsIDforprint(int RegRigID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_DrillingRigsDetailsbyRegRigIDforprint", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (RegRigID == 0)
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = RegRigID.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    

    #endregion



    #region DrillingRigs DWGO Dashboard

    public DataSet GetDepartmentDashboardDetails_DrillingRigsDept(string intDeptid, string intDistrictID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetDepartmentDashboardDetailsbyDrillingRigsUSER", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();
            if (intDistrictID.Trim() == "" || intDistrictID.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = intDistrictID.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public DataSet GetDepartentApplications_DrillingRigsDept(string Deptid, string intDistrictID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_DASHBOARD_DEPARTMENT_DrillingRigsDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intDistrictID.Trim() == "" || intDistrictID.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = intDistrictID.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }


    public DataSet GetMonthwiseStatusrptDrill_DrillingRigs(string dept, string Status)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_DASHBOARD_DEPARTMENT_DRILL_DrillingRigs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (dept.Trim() == "" || dept.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = dept.ToString();
            if (Status.Trim() == "" || Status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = Status.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }



    public DataSet GetShowDepartmentFiles_DrillingRigsDept(string Deptid, string intStageid, string intDistrictid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetShowDepartmentFiles_DrillingRigsDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();
            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = " %";
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
            con.Close();
        }
    }



    #endregion


    #region DWGO Approval and reject
    public DataSet GetdataofApprovaldataAprovalbyID_DrillingRigs(string enterprenuer, string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_getenterprenuerdatbyidAprovalsNew_DrillingRigs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.ToString();
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
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
            con.Close();
        }
    }
    public DataSet GetShowEmailidandMobileNumber_DrillingRigs(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetShowEmailidandMobileNumber_DrillingRigs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = " %";
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
            con.Close();
        }
    }

    public int insertApprovalData_DrillingRigs(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_updateApprovaldata_DrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (Enterprenuer.Trim() == "" || Enterprenuer.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Enterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Enterprenuer", SqlDbType.VarChar).Value = Enterprenuer.Trim();
            if (RefNo.Trim() == "" || RefNo.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@RefNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@RefNo", SqlDbType.VarChar).Value = RefNo.Trim();
            if (Status.Trim() == "" || Status.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = Status.Trim();
            if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.VarChar).Value = Modified_by.Trim();

            if (Remarks.Trim() == "" || Remarks.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

            if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

    public int InsertDeptDateTracing_DrillingsRigs(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date,
        string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("USP_INS_DASHBOARDDATA_DrillingsRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            if (DepartmentId == "" || DepartmentId == null)
            {
                cmdpacd.Parameters.AddWithValue("@DepartmentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@DepartmentId", SqlDbType.VarChar).Value = DepartmentId.Trim();
            }
            if (QuessionaireId == "" || QuessionaireId == null)
            {
                cmdpacd.Parameters.AddWithValue("@QuessionaireId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QuessionaireId", SqlDbType.VarChar).Value = QuessionaireId.Trim();
            }
            if (Uid_No == "" || Uid_No == null)
            {
                cmdpacd.Parameters.AddWithValue("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Uid_No", SqlDbType.VarChar).Value = Uid_No.Trim();
            }
            if (Apply_Date == "" || Apply_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@Apply_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Apply_Date", SqlDbType.VarChar).Value = Apply_Date.Trim();
            }
            if (PreScrutinity_Date == "" || PreScrutinity_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@PreScrutinity_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PreScrutinity_Date", SqlDbType.VarChar).Value = PreScrutinity_Date.Trim();
            }
            if (QueryRaised_Date == "" || QueryRaised_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@QueryRaised_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QueryRaised_Date", SqlDbType.VarChar).Value = QueryRaised_Date.Trim();
            }
            if (QueryRespond_Date == "" || QueryRespond_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@QueryRespond_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QueryRespond_Date", SqlDbType.VarChar).Value = QueryRespond_Date.Trim();
            }

            if (Approval_Date == "" || Approval_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Date", SqlDbType.VarChar).Value = Approval_Date.Trim();
            }

            if (Application_Type == "" || Application_Type == null)
            {
                cmdpacd.Parameters.AddWithValue("@Application_Type", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Application_Type", SqlDbType.VarChar).Value = Application_Type.Trim();
            }

            if (ApprovalId == "" || ApprovalId == null)
            {
                cmdpacd.Parameters.AddWithValue("@ApprovalId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ApprovalId", SqlDbType.VarChar).Value = ApprovalId.Trim();
            }
            // cmd.ExecuteNonQuery();

            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }
    public int InsertImagedataApproval_DrillingRigs(string intQuessionaireid, string FileType, string FilePath, string FileName, string FileDescription,
string Created_by, string Created_dt, string Modified_by, string Modified_dt, string intDeptid, string intApprovalid)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_InsertImageApproval_DrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());
            }
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null || intApprovalid.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());
            }
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }

            if (FileType.Trim() == "" || FileType.Trim() == null || FileType.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@FileType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileType", SqlDbType.VarChar).Value = FileType.Trim();
            }
            if (FilePath.Trim() == "" || FilePath.Trim() == null || FilePath.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FilePath", SqlDbType.VarChar).Value = FilePath.Trim();
            }
            if (FileName.Trim() == "" || FileName.Trim() == null || FileName.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileName", SqlDbType.VarChar).Value = FileName.Trim();
            }
            if (FileDescription.Trim() == "" || FileDescription.Trim() == null || FileDescription.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@FileDescription", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FileDescription", SqlDbType.VarChar).Value = FileDescription.Trim();
            }

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }
            //if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            //{
            //    cmdpacd.Parameters.AddWithValue("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmdpacd.Parameters.AddWithValue("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            //}
            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }
            //if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
            //{
            //    cmdpacd.Parameters.AddWithValue("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmdpacd.Parameters.AddWithValue("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
            //}
            // int n = myDataAdapter.SelectCommand.ExecuteNonQuery();

            retValue = Convert.ToInt32(cmdpacd.ExecuteNonQuery());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }



    #endregion

    #region FORM16
    public DataSet Form16_DrillingRigs(int RegRigID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_Form16_DrillingRigs", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (RegRigID == 0)
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@RegRigID", SqlDbType.VarChar).Value = RegRigID.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    #endregion

    #region Queryresponse

    public DataSet GetquerresponsedetailsfordeptbyID_DrillingRigs(string intCFEEnterpid, string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_RetriveQueriesDetailsByIDDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
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
            con.Close();
        }
    }

    public DataSet GetQueryStatusByTransactionID_Rigs(string intQueryTrnsid, string User_id)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_GetQueryStatusByTransactionID", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQueryTrnsid.Trim() == "" || intQueryTrnsid.Trim() == null || intQueryTrnsid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = intQueryTrnsid.ToString();
            if (User_id.Trim() == "" || User_id.Trim() == null || User_id.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = User_id.ToString();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }


    public int InsertQueryDetails_Rigs(string intQuessionaireid, string intCFEEnterpid, string intDeptid,
        string intApprovalid,string QueryAttachmentFileName,
        string QueryAttachmentFilePath, string QueryRespondRemarks, string Created_by,string IPAddress)
{
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_InsertQueryDetails", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            if (QueryAttachmentFileName.Trim() == "" || QueryAttachmentFileName.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@QueryAttachmentFileName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@QueryAttachmentFileName", SqlDbType.VarChar).Value = QueryAttachmentFileName.Trim();

            if (QueryAttachmentFilePath.Trim() == "" || QueryAttachmentFilePath.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@QueryAttachmentFilePath", SqlDbType.VarChar).Value = QueryAttachmentFilePath.Trim();

            if (QueryRespondRemarks.Trim() == "" || QueryRespondRemarks.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@QueryRespondRemarks", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@QueryRespondRemarks", SqlDbType.VarChar).Value = QueryRespondRemarks.Trim();
            if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@ipaddress", SqlDbType.VarChar).Value = IPAddress.Trim();
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
       
        transaction.Commit();
            connection.Close();
            if (retValue > 0)
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
            connection.Close();
        }
        return retValue;
    }

    #endregion

    #region Queryraised

    public int insertDepartmentProcess_rigs(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Created_by)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_insertDepartmentProcess", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intCFEEnterpid == "" || intCFEEnterpid == null)
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();

            if (intDeptid == "" || intDeptid == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

            if (intApprovalid == "" || intApprovalid == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

            if (intStageid == "" || intStageid == null)
                cmdpacd.Parameters.AddWithValue("@intStageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intStageid", SqlDbType.VarChar).Value = intStageid.Trim();
            if (Created_by == "" || Created_by == null)
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();


            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }


    public int insertQueryRaiseddata(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_insertQueriesDetailsdept", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intEnterpreniourApprovalid.Trim() == "" || intEnterpreniourApprovalid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intEnterpreniourApprovalid", SqlDbType.VarChar).Value = intEnterpreniourApprovalid.Trim();
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();
            if (QueryDescription.Trim() == "" || QueryDescription.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@QueryDescription", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@QueryDescription", SqlDbType.VarChar).Value = QueryDescription.Trim();
            if (QueryStatus.Trim() == "" || QueryStatus.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@QueryStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@QueryStatus", SqlDbType.VarChar).Value = QueryStatus.Trim();
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
            if (intApprovalid.Trim() == "" || intApprovalid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }


    public int UpdateAdditionalpaymentsrigs(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("Rigs_UpdatetDeptApprovalnewDrillingRigs", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.Trim();
            if (ipaddress.Trim() == "" || ipaddress.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@ipaddress", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@ipaddress", SqlDbType.VarChar).Value = ipaddress.Trim();
            if (Amount.Trim() == "" || Amount.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Amount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Amount", SqlDbType.VarChar).Value = Amount.Trim();
            if (Status.Trim() == "" || Status.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = Status.Trim();
            if (Created_by.Trim() == "" || Created_by.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

            if (stageid.Trim() == "" || stageid.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@stageid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@stageid", SqlDbType.VarChar).Value = stageid.Trim();
            if (dept.Trim() == "" || dept.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@dept", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@dept", SqlDbType.VarChar).Value = dept.Trim();
            if (Approval.Trim() == "" || Approval.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@Approval", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Approval", SqlDbType.VarChar).Value = Approval.Trim();
            retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return retValue;
    }

  

    #endregion

    #region Reports
    public DataSet DB_getrpdistrictwise(string DistrictID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("Rigs_rpdistrictwise", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.ToString();

            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public DataSet DB_RptDrillingApplicationlist(string Typedataofappl, string Districtid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rpt_DrillingApplicationlistdistrict", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Typedataofappl.Trim() == "" || Typedataofappl.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Typedataofappl.ToString();

            if (Districtid.Trim() == "" || Districtid.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = Districtid.ToString();
            da.Fill(ds);
            return ds;

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }


    #endregion
}


public class RegistrationDrillingRigspro
{
    public int RegRigID { get; set; }
    public string Applicationtype { get; set; }
    public int Applicationtypeid { get; set; }
    public string Nameoftheapplicant { get; set; }
    public int AddDistrictId { get; set; }
    public string AddDistrictName { get; set; }
    public int AddMandalid { get; set; }
    public string AddMandalname { get; set; }
    public int AddVillageid { get; set; }
    public string AddVillagename { get; set; }
    public string Street { get; set; }
    public string Houseno { get; set; }
    public string regvehicleno { get; set; }
    public string rtoplaceofregvehicle { get; set; }
    public int RTODistrictID { get; set; }
    public string RTODistrictName { get; set; }
    public string Descofdrillrigs { get; set; }
    public decimal maxdiameterdepth { get; set; }
    public string Areaofoperation { get; set; }
    public bool Isactive { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedIP { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
    public string ModifiedIP { get; set; }
    public int AppStatus { get; set; }
    public int Stageid { get; set; }
    public DateTime PaymentDate { get; set; }
    public string UIDNO { get; set; }
    public int DWGODeptid { get; set; }
    public int DWGOApprovalid { get; set; }
    public decimal FeeAmount { get; set; }
    public char PaymentDone { get; set; }

    public string ApplicantMobileno { get; set; }
    public string ApplicantEmailID { get; set; }
}

public class RegistrationDrillingRigsfileuploadspro
{
    public string ApplicationID { get; set; }
    public string FileType { get; set; }
    public string FilePath { get; set; }    
    public string FileName { get; set; }    
    public string FileDescription { get; set; }    
    public string Created_by  { get; set; }
}