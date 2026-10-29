using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Cls_OSGroundWater
/// </summary>
public class Cls_OSGroundWater
{
    comFunctions cmf = new comFunctions();
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    //public Cls_OSGroundWater()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    #region Reports
    public DataSet DB_getgroundwaterrpdistrictwise(string DistrictID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_rpdistrictwise", con);
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

    public DataSet DB_getgroundwaterrpdistrictmandalwise(string DistrictID, string MandalID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_rpdistrictmandalwise", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
                // da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.ToString();
            if (MandalID.Trim() == "" || MandalID.Trim() == null)
                // da.SelectCommand.Parameters.Add("@MandalID", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@MandalID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MandalID", SqlDbType.VarChar).Value = MandalID.ToString();
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

    #region Master

    public DataTable DB_GWgetdistricts()
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

    public DataTable DB_GWgetmadals(string Districtid)
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

    public DataTable DB_GWGetVillages(string Mandalid)
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

    public DataSet DB_Modeofwaterdrawingmaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_Modeofwaterdrawingmaster", con);
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

    public DataSet DB_Typeofwellmaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_Typeofwellmaster", con);
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

    public DataSet DB_ApplicationTypemaster()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_ApplicationTypemaster", con);
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

    public DataTable DB_GWdocumetmaster(string ApplicationTypeID,string userid, string GroundwaterID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_documetmaster", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ApplicationTypeID == "" || ApplicationTypeID == null)
            {
                da.SelectCommand.Parameters.Add("@ApplicationTypeID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ApplicationTypeID", SqlDbType.VarChar).Value = ApplicationTypeID;
            }
            if (userid == "" || userid == null)
            {
                da.SelectCommand.Parameters.Add("@intuserid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@intuserid", SqlDbType.VarChar).Value = userid;
            }

            if (GroundwaterID == "" || GroundwaterID == null)
            {
                da.SelectCommand.Parameters.Add("@Groundwater_ID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                da.SelectCommand.Parameters.Add("@Groundwater_ID", SqlDbType.VarChar).Value = GroundwaterID;
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

    #region Insert applicant details
    public string insertWaltaApplicationDetails(WaltaApplDetailsproperties OBJWaltaApplDetails)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("SP_INSERTWALTAApplicnDetails", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
            if (OBJWaltaApplDetails.ApplicationType_IndusorAgriName == "" || OBJWaltaApplDetails.ApplicationType_IndusorAgriName == null)
                com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();


            if (OBJWaltaApplDetails.ApplicationType_IndusorAgri == "" || OBJWaltaApplDetails.ApplicationType_IndusorAgri == null)
                com.Parameters.Add("@ApplicationType_IndusorAgri", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicationType_IndusorAgri", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgri.Trim();

            if (OBJWaltaApplDetails.ApplicantName == "" || OBJWaltaApplDetails.ApplicantName == null || OBJWaltaApplDetails.ApplicantName == "--Select--")
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicantName.Trim();

            if (OBJWaltaApplDetails.DistrictID == "" || OBJWaltaApplDetails.DistrictID == null || OBJWaltaApplDetails.DistrictID == "--Select--")
                com.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DistrictID.Trim();
            if (OBJWaltaApplDetails.MandalId == "" || OBJWaltaApplDetails.MandalId == null || OBJWaltaApplDetails.MandalId == "--Select--")
                com.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MandalId.Trim();

            if (OBJWaltaApplDetails.VillageId == "" || OBJWaltaApplDetails.VillageId == null || OBJWaltaApplDetails.VillageId == "--Select--")
                com.Parameters.Add("@VillageId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@VillageId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.VillageId.Trim();

            if (OBJWaltaApplDetails.Street == "" || OBJWaltaApplDetails.Street == null || OBJWaltaApplDetails.Street == "--Select--")
                com.Parameters.Add("@Street", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Street", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Street.Trim();

            if (OBJWaltaApplDetails.HouseNo == "" || OBJWaltaApplDetails.HouseNo == null || OBJWaltaApplDetails.HouseNo == "--Select--")
                com.Parameters.Add("@HouseNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@HouseNo", SqlDbType.VarChar).Value = OBJWaltaApplDetails.HouseNo.Trim();

            if (OBJWaltaApplDetails.LocationOfWell == "" || OBJWaltaApplDetails.LocationOfWell == null || OBJWaltaApplDetails.LocationOfWell == "--Select--")
                com.Parameters.Add("@LocationOfWell", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LocationOfWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.LocationOfWell.Trim();

            if (OBJWaltaApplDetails.TypeofWell == "" || OBJWaltaApplDetails.TypeofWell == null || OBJWaltaApplDetails.TypeofWell == "--Select--")
                com.Parameters.Add("@TypeofWell", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TypeofWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeofWell.Trim();

            if (OBJWaltaApplDetails.TypeOfDrwngWater == "" || OBJWaltaApplDetails.TypeOfDrwngWater == null || OBJWaltaApplDetails.TypeOfDrwngWater == "--Select--")
                com.Parameters.Add("@TypeOfDrwngWater", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TypeOfDrwngWater", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeOfDrwngWater.Trim();

            if (OBJWaltaApplDetails.SpecifactioncnOFPump == "" || OBJWaltaApplDetails.SpecifactioncnOFPump == null || OBJWaltaApplDetails.SpecifactioncnOFPump == "--Select--")
                com.Parameters.Add("@SpecifactioncnOFPump", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@SpecifactioncnOFPump", SqlDbType.VarChar).Value = OBJWaltaApplDetails.SpecifactioncnOFPump.Trim();

            if (OBJWaltaApplDetails.DistanceFromExistWell == "" || OBJWaltaApplDetails.DistanceFromExistWell == null || OBJWaltaApplDetails.DistanceFromExistWell == "--Select--")
                com.Parameters.Add("@DistanceFromExistWell", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DistanceFromExistWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DistanceFromExistWell.Trim();


            if (OBJWaltaApplDetails.ChkAcceptence == "" || OBJWaltaApplDetails.ChkAcceptence == null || OBJWaltaApplDetails.ChkAcceptence == "--Select--")
                com.Parameters.Add("@AccepFlag", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@AccepFlag", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ChkAcceptence.Trim();

            if (OBJWaltaApplDetails.Createdby == "" || OBJWaltaApplDetails.Createdby == null || OBJWaltaApplDetails.Createdby == "--Select--")
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Createdby.Trim();

            if (OBJWaltaApplDetails.CreatedIP == "" || OBJWaltaApplDetails.CreatedIP == null)
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = OBJWaltaApplDetails.CreatedIP.Trim();

            if (OBJWaltaApplDetails.DistrictName == "" || OBJWaltaApplDetails.DistrictName == null || OBJWaltaApplDetails.DistrictName == "--Select--")
                com.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DistrictName.Trim();

            if (OBJWaltaApplDetails.MandalName == "" || OBJWaltaApplDetails.MandalName == null || OBJWaltaApplDetails.MandalName == "--Select--")
                com.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MandalName.Trim();
            if (OBJWaltaApplDetails.VillageName == "" || OBJWaltaApplDetails.VillageName == null || OBJWaltaApplDetails.VillageName == "--Select--")
                com.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.VillageName.Trim();
            if (OBJWaltaApplDetails.ApplicantMobileNO == "" || OBJWaltaApplDetails.ApplicantMobileNO == null)
                com.Parameters.Add("@ApplicantMobileNO", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantMobileNO", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicantMobileNO.Trim();

            if (OBJWaltaApplDetails.ApplicantEmailID == "" || OBJWaltaApplDetails.ApplicantEmailID == null)
                com.Parameters.Add("@ApplicantEmailID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantEmailID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicantEmailID.Trim();

            if (OBJWaltaApplDetails.TypeofWellName == "" || OBJWaltaApplDetails.TypeofWellName == null || OBJWaltaApplDetails.TypeofWellName == "--Select--")
                com.Parameters.Add("@TypeofWellName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TypeofWellName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeofWellName.Trim();
            if (OBJWaltaApplDetails.TypeOfDrwngWaterName == "" || OBJWaltaApplDetails.TypeOfDrwngWaterName == null || OBJWaltaApplDetails.TypeOfDrwngWaterName == "--Select--")
                com.Parameters.Add("@TypeOfDrwngWaterName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TypeOfDrwngWaterName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeOfDrwngWaterName.Trim();
            if (OBJWaltaApplDetails.GroundwaterID == "" || OBJWaltaApplDetails.GroundwaterID == null)
                com.Parameters.Add("@GroundwaterID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@GroundwaterID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.GroundwaterID.Trim();


            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            //com.ExecuteScalar();
            valid = (Int32)com.Parameters["@Valid"].Value;


            resp = Convert.ToString(valid);
            //con.CloseConnection();
            //con.OpenConnection();
            //com.Connection = con.GetConnection;

            transaction.Commit();
            connection.Close();
            //return com.ExecuteNonQuery();
            //return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;

        }
        finally
        {
            com.Dispose();
            //con.CloseConnection();
            connection.Close();
        }
        return resp;
    }
    public bool DB_InsertGroundwaterWaltapplattachments(WaltaApplfileuploadspro objfileuploads)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("usp_Insert_Groundwater_attachments", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (objfileuploads.ApplicationID == "" || objfileuploads.ApplicationID == null)
            {
                cmdpacd.Parameters.AddWithValue("@Groundwater_ID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Groundwater_ID", SqlDbType.VarChar).Value = Convert.ToInt32(objfileuploads.ApplicationID);
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

    #endregion


    #region Payment Details

    public DataSet GetUidnumber_groundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_getUIDNumberdatagroundwater", con);
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
    public DataSet GetEnterPreniourPayDetailsPaidDetgroundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GetEnterPreniourPayDetailsPaidDet_groundwater", con);
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
    public DataSet GetEnterPreniourPayDetailsGroundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GetEnterPreniourPayDetails_groundwater", con);
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
    public DataSet GetEnterPreneurdatabyQue_Groundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_getEnterprenuerdatabyQuesgroundwater", con);
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
            SqlCommand cmdpacd = new SqlCommand("GW_InsertUIDGenerationGroundwater", connection);
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

            retValue = Convert.ToString(cmdpacd.ExecuteScalar());
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
    public int insertDepartmentAprroval_Groundwater(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("insDepartmentApprovals_groundwater", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            if (intQuessionaireid == "" || intQuessionaireid == null)
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();

            if (intDeptid == "" || intDeptid == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();

            if (intApprovalid == "" || intApprovalid == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.VarChar).Value = intApprovalid.Trim();

            if (Approval_Fee == "" || Approval_Fee == null)
                cmdpacd.Parameters.AddWithValue("@Approval_Fee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Approval_Fee", SqlDbType.Decimal).Value = Convert.ToDecimal(Approval_Fee.Trim());

            if (IsPayment == "" || IsPayment == null)
                cmdpacd.Parameters.AddWithValue("@IsPayment", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@IsPayment", SqlDbType.VarChar).Value = IsPayment;

            if (Created_by == "" || Created_by == null)
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

            if (IsOffline == "" || IsOffline == null)
                cmdpacd.Parameters.AddWithValue("@IsOffline", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@IsOffline", SqlDbType.VarChar).Value = IsOffline.Trim();
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
    public int InsertPaymentBillDesk_groundwater(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("USP_INSERT_Builldesc_PaymentDtls_groundwater", connection);
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
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());

            if (OnlineOrderNo == "" || OnlineOrderNo == null)
                cmdpacd.Parameters.AddWithValue("@OnlineOrderNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@OnlineOrderNo", SqlDbType.VarChar).Value = OnlineOrderNo.Trim();


            if (intDeptid == "" || intDeptid == null)
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intDeptid", SqlDbType.Int).Value = Int32.Parse(intDeptid.Trim());

            if (intApprovalid == "" || intApprovalid == null)
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@intApprovalid", SqlDbType.Int).Value = Int32.Parse(intApprovalid.Trim());


            if (Online_Amount == "" || Online_Amount == null)
                cmdpacd.Parameters.AddWithValue("@Online_Amount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@Online_Amount", SqlDbType.VarChar).Value = Online_Amount.Trim();


            if (Created_by.Trim() == "" || Created_by.Trim() == null)
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }
            if (AdditionalPayment == "" || AdditionalPayment == null)
                cmdpacd.Parameters.AddWithValue("@AdditionalPayment", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@AdditionalPayment", SqlDbType.VarChar).Value = AdditionalPayment.Trim();

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
    public DataSet GetGroundwaterpaymentDtls(string UID, string Orderno, string AdditionalPaymentflg)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("USP_GET_Builldesc_PaymentDtls_Groundwater_DESE", con);
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

    #region User Dashboard List
    public DataSet GETGroundwaterdahboardlist(int UserID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GETGroundwaterdahboardlist", con);
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
            con.Close();
        }
    }
    #endregion

    #region Print
    public DataSet GetGroundwaterDetailsbyGroundwaterIDforprint(int GroundwaterID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GroundwaterDetailsbyGwIDforprint", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@GroundwaterID", SqlDbType.Int).Value = GroundwaterID;
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
    public DataSet GetdatadocumentbyQuestioneerieid_Groundwater(string intEnterprenuerid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetdatadocumentbyQueid_groundwater", con);
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

    #region  view Payment
    public DataSet BindUserPaymentReceipt(string TranRefNo)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GET_ACKNOWLEDGEMENT_Groundwaterpayment", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intEntid", SqlDbType.VarChar).Value = TranRefNo;
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

    #region user query response
    public int InsertQueryDetails_groundwater(string intQuessionaireid, string intCFEEnterpid, string intDeptid,
       string intApprovalid, string QueryAttachmentFileName,
       string QueryAttachmentFilePath, string QueryRespondRemarks, string Created_by, string IPAddress)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("gw_InsertQueryDetailsresponse", connection);
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
                retValue= 1;
            }
            else
            {
                retValue= 0;
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

    public DataSet GetQueryStatusByTransactionID_Groundwater(string intQueryTrnsid, string User_id, string ISTRANSCOqueryraised)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetQueryStatusByTransactionIDgroundwater", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQueryTrnsid.Trim() == "" || intQueryTrnsid.Trim() == null || intQueryTrnsid.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intQueryTrnsid", SqlDbType.VarChar).Value = intQueryTrnsid.ToString();
            if (User_id.Trim() == "" || User_id.Trim() == null || User_id.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = User_id.ToString();

            if (ISTRANSCOqueryraised.Trim() == "" || ISTRANSCOqueryraised.Trim() == null)
                da.SelectCommand.Parameters.Add("@ISTRANSCOqueryraised", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@ISTRANSCOqueryraised", SqlDbType.VarChar).Value = ISTRANSCOqueryraised.ToString();
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

    #region MRO ADMIN  Dashboardlist
    public DataSet GetDepartmentDashboardDetails_GroundwaterMRO(string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetDepartmentDashboardDetailsbyMROUSER", con);
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
            con.Close();
        }
    }
    public DataSet GetDepartmentApplications_GroundwaterMRO(string Deptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_MRO", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
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
    public DataSet GetMonthwiseStatusrptDrill_GroundwaterMRO(string dept, string Status)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_DRILL_MRO", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = dept;
            da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = Status;
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

    #region MRO ADMIN  Dashboardlistofapplications
    public DataSet GetShowDepartmentFiles_grounwaterMRO(string Deptid, string intStageid, string intDistrictid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetShowDepartmentFiles_MROGroundwater", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();
            da.SelectCommand.CommandTimeout = 3600;

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

    #region Query Response View by User,MRO,GW Department
    public DataSet GetquerresponsedetailsfordeptbyID_Groundwater(string intCFEEnterpid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_RetriveQueriesDetailsByIDDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();
            //if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            //    da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = " %";
            //else
            //    da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();

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

    #region MRO ADMIN  Pre-Scrunity Stage & Query Raise
    public int insertDepartmentProcess_grounwaterMRO(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid,string Created_by)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("gw_insertDepartmentProcess_MROgroundwater", connection);
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
    public int UpdateprescrunitystageofMRO(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string Reason)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("GW_UpdatetDeptApprovalnew_MROgroundwater", connection);
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
            if (Reason.Trim() == "" || Reason.Trim() == null)
                cmdpacd.Parameters.AddWithValue("@rejected_reason", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmdpacd.Parameters.AddWithValue("@rejected_reason", SqlDbType.VarChar).Value = Reason.Trim();
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
    public int  InsertDeptDateTracing_mrogroundwater(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("USP_INS_DASHBOARDDATA_groundwaterMRO", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;
            cmdpacd.Parameters.AddWithValue("@DepartmentId", Convert.ToString(DepartmentId));
            cmdpacd.Parameters.AddWithValue("@QuessionaireId", Convert.ToString(QuessionaireId));
            cmdpacd.Parameters.AddWithValue("@Uid_No", Convert.ToString(Uid_No));
            cmdpacd.Parameters.AddWithValue("@Apply_Date", Apply_Date);
            cmdpacd.Parameters.AddWithValue("@PreScrutinity_Date", PreScrutinity_Date);
            cmdpacd.Parameters.AddWithValue("@QueryRaised_Date", QueryRaised_Date);
            cmdpacd.Parameters.AddWithValue("@QueryRespond_Date", QueryRespond_Date);
            cmdpacd.Parameters.AddWithValue("@Approval_Date", Approval_Date);
            cmdpacd.Parameters.AddWithValue("@Application_Type", Application_Type);
            cmdpacd.Parameters.AddWithValue("@ApprovalId", ApprovalId);
            //    cmd.ExecuteNonQuery();
            //retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
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
    public DataSet GetShowEmailidandMobileNumber_MROGroundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetShowEmailidandMobileNumber_MROGroundwater", con);
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
    public int insertQueryResponsedata_MROGroundwater(string intEnterpreniourApprovalid, string intCFEEnterpid, string QueryDescription, string QueryStatus, string Created_by, string intDeptid, string intApprovalid, string intQuessionaireid)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("insertQueriesDetails_MROqueryraise", connection);
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

            retValue= Convert.ToInt32(cmdpacd.ExecuteScalar());
           // retValue = Convert.ToInt32(cmdpacd.ExecuteNonQuery());
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

     
    #region MRO ADMIN  approval reject
    //Approval
    public DataSet GetStatusforCertificate_MROGroundwater(string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetStatusforCertificate_MROGroundwater", con);
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
    public int insertApprovalData_groundwater(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("GW_updateApprovaldata_MROGroundwater", connection);
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

    public int UpdCommissionerApprovalNew_MROGroundwater(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by, string intQid)

{
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("GW_UpdCommissionerApprovalNew_MROGroundwater", connection);
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

        if (Trans_Date == "" || Trans_Date == null)
            cmdpacd.Parameters.AddWithValue("@Trans_Date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            cmdpacd.Parameters.AddWithValue("@Trans_Date", SqlDbType.VarChar).Value = cmf.convertDateIndia(Trans_Date);

        if (Created_by == "" || Created_by == null)
            cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            cmdpacd.Parameters.AddWithValue("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (intQid == "" || intQid == null)
            cmdpacd.Parameters.AddWithValue("@intQid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            cmdpacd.Parameters.AddWithValue("@intQid", SqlDbType.VarChar).Value = intQid.Trim();
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

    public DataSet DB_getformapprovalrejectdata(int Applicantionid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_fromapprovalreject3466abyapplicantid", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Applicantionid", SqlDbType.VarChar).Value = Applicantionid;
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
    public DataSet GETGroundwaterincompletedetailsbyuserid(int UserID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GETGroundwaterincompletedetailsbyuserid", con);
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
            con.Close();
        }
    }
    public DataSet GetMROofficers(string District, string MandalId)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("master_getmroofficerbydistmandids", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (District.Trim() == "" || District.Trim() == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = District.ToString();

            if (MandalId.Trim() == "" || MandalId.Trim() == null)
                da.SelectCommand.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = MandalId.ToString();
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

    #region Ground water Admin

    public DataSet GetDepartmentDashboardDetails_GroundwaterDept(string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open(); 
             da = new SqlDataAdapter("GW_GetDepartmentDashboardDetailsbyGroundwaterUSER", con);
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
            con.Close();
        }
    }

    public DataSet GetDepartentApplications_GroundwaterDept(string Deptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_GrounwaterDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
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

    public DataSet GetShowDepartmentFiles_grounwaterDept(string Deptid, string intStageid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetShowDepartmentFiles_GroundwaterDept", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();
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

    #region Ground water Admin approval pages
    public DataSet GetdataofApprovaldataAprovalbyID_groundwater(string enterprenuer, string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_getenterprenuerdatbyidAprovalsNew_MROGrounwater", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (enterprenuer.Trim() == "" || enterprenuer.Trim() == null || enterprenuer.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@enterprenuer", SqlDbType.VarChar).Value = enterprenuer.Trim();
            }
            if (intDeptid.Trim() == "" || intDeptid.Trim() == null || intDeptid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.Trim();
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

    #region department file upload
    public int InsertImagedataApproval_groundwater(string intQuessionaireid, string FileType, string FilePath, string FileName, string FileDescription,
string Created_by, string Created_dt, string Modified_by, string Modified_dt, string intDeptid, string intApprovalid)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("GW_InsertImageApproval_MROGroundwater", connection);
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
            cmdpacd.ExecuteScalar();
            retValue = 1;
            // retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
            //if (n > 0)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}

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

    #region DWGO approval reject
    public int insertApprovalData_DWGOgroundwater(string Enterprenuer, string RefNo, string Status, string Modified_by, string intApprovalid, string intDeptid, string Remarks, string IPAddress)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("GW_updateApprovaldata_DWGOGroundwater", connection);
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
    public int InsertDeptDateTracing_DWGOgroundwater(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)

    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        int retValue = 0;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("USP_INS_DASHBOARDDATA_groundwaterDWGO", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            if (ApprovalId.Trim() == "" || ApprovalId.Trim() == null)
            {
                cmdpacd.Parameters.AddWithValue("@ApprovalId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ApprovalId", ApprovalId);
            }
            if (Application_Type == "" || Application_Type == null)
            {
                cmdpacd.Parameters.AddWithValue("@Application_Type", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Application_Type", Application_Type);
            }
            if (Approval_Date == "" || Approval_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Approval_Date", Approval_Date);
            }
            if (QueryRespond_Date == "" || QueryRespond_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@QueryRespond_Date", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QueryRespond_Date", QueryRespond_Date);
            }
            if (QueryRaised_Date == "" || QueryRaised_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@QueryRaised_Date", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QueryRaised_Date", QueryRaised_Date);
            }
            if (PreScrutinity_Date == "" || PreScrutinity_Date == null)
            {
                cmdpacd.Parameters.AddWithValue("@PreScrutinity_Date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PreScrutinity_Date", PreScrutinity_Date);
            }
            if (Apply_Date.Trim() == "" || Apply_Date.Trim() == null)
            {
                cmdpacd.Parameters.AddWithValue("@Apply_Date", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Apply_Date", Apply_Date);
            }
            if (Uid_No == "" || Uid_No == null)
            {
                cmdpacd.Parameters.AddWithValue("@Uid_No", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Uid_No", Convert.ToString(Uid_No));
            }
            if (QuessionaireId == "" || QuessionaireId == null)
            {
                cmdpacd.Parameters.AddWithValue("@QuessionaireId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@QuessionaireId", Convert.ToString(QuessionaireId));
            }
            if (DepartmentId == "" || DepartmentId == null)
            {
                cmdpacd.Parameters.AddWithValue("@DepartmentId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@DepartmentId", Convert.ToString(DepartmentId));
            }
            //retValue = Convert.ToInt32(cmdpacd.ExecuteScalar());
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


    #region report state

    public DataSet Getstatereport_groundwater(string FromDate, string Todate, string DistrictID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_statereport", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //if (FromDate.Trim() == "" || FromDate.Trim() == null)
            //    //da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value; 
            //    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = "%";
            //else
            da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate;

            //if (Todate.Trim() == "" || Todate.Trim() == null)
            //    da.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = "%";
            //else
            da.SelectCommand.Parameters.Add("@Todate", SqlDbType.VarChar).Value = Todate;

            //if (DistrictID.Trim() == "" || DistrictID.Trim() == null)
            //    da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            //else
            da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID;
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

    public DataSet DB_statereportlistofwellrigsdetails(string Typedataofappl, string Status, string Category, string Districtid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rpt_statereportlistofwellrigsdetails", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Typedataofappl.Trim() == "" || Typedataofappl.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Type", SqlDbType.VarChar).Value = Typedataofappl.ToString();
            if (Status.Trim() == "" || Status.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.ToString();
            if (Category.Trim() == "" || Category.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = Category.ToString();
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

    public DataSet DB_RptWellApplicationlistdistrictwiseReport(string Typedataofappl, string Districtid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rpt_WellApplicationlistdistrictwiseReport", con);
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

    public DataSet DB_RptWellApplicationlistmandalwiseReport(string Typedataofappl, string Districtid, string MandalID)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("rpt_WellApplicationlistmandalwiseReport", con);
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

            if (MandalID.Trim() == "" || MandalID.Trim() == null)
                // da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.VarChar).Value = DBNull.Value;
                da.SelectCommand.Parameters.Add("@MandalID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MandalID", SqlDbType.VarChar).Value = MandalID.ToString();

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

  
   

    #region 28-oct-2020

    //public string insertWaltaApplicationDetails(WaltaApplDetailsproperties OBJWaltaApplDetails)
    //{
    //    int valid = 0;
    //    string resp = "";
    //    SqlConnection connection = new SqlConnection(strConnectionString);
    //    SqlTransaction transaction = null;
    //    connection.Open();
    //    transaction = connection.BeginTransaction();
    //    SqlCommand com = new SqlCommand("SP_INSERTWALTAApplicnDetails", connection);
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.Transaction = transaction;


    //    //int valid = 0;
    //    //string resp = "";
    //    //con.OpenConnection();
    //    //SqlCommand com = new SqlCommand();
    //    //com.CommandType = CommandType.StoredProcedure;
    //    //com.CommandText = "SP_INSERTWALTAApplicnDetails";
    //    //SqlCommand com = new SqlCommand("SP_INSERTWALTAApplicnDetails", con.GetConnection);
    //    //com.CommandType = CommandType.StoredProcedure;
    //    try
    //    {
    //        if (OBJWaltaApplDetails.ApplicationType_IndusorAgriName == "" || OBJWaltaApplDetails.ApplicationType_IndusorAgriName == null)
    //            com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();


    //        if (OBJWaltaApplDetails.ApplicationType_IndusorAgri == "" || OBJWaltaApplDetails.ApplicationType_IndusorAgri == null)
    //            com.Parameters.Add("@ApplicationType_IndusorAgri", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@ApplicationType_IndusorAgri", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgri.Trim();

    //        if (OBJWaltaApplDetails.ApplicantName == "" || OBJWaltaApplDetails.ApplicantName == null || OBJWaltaApplDetails.ApplicantName == "--Select--")
    //            com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicantName.Trim();

    //        if (OBJWaltaApplDetails.DistrictID == "" || OBJWaltaApplDetails.DistrictID == null || OBJWaltaApplDetails.DistrictID == "--Select--")
    //            com.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DistrictID.Trim();
    //        if (OBJWaltaApplDetails.MandalId == "" || OBJWaltaApplDetails.MandalId == null || OBJWaltaApplDetails.MandalId == "--Select--")
    //            com.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@MandalId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MandalId.Trim();

    //        if (OBJWaltaApplDetails.VillageId == "" || OBJWaltaApplDetails.VillageId == null || OBJWaltaApplDetails.VillageId == "--Select--")
    //            com.Parameters.Add("@VillageId", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@VillageId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.VillageId.Trim();

    //        if (OBJWaltaApplDetails.Street == "" || OBJWaltaApplDetails.Street == null || OBJWaltaApplDetails.Street == "--Select--")
    //            com.Parameters.Add("@Street", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@Street", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Street.Trim();

    //        if (OBJWaltaApplDetails.HouseNo == "" || OBJWaltaApplDetails.HouseNo == null || OBJWaltaApplDetails.HouseNo == "--Select--")
    //            com.Parameters.Add("@HouseNo", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@HouseNo", SqlDbType.VarChar).Value = OBJWaltaApplDetails.HouseNo.Trim();

    //        if (OBJWaltaApplDetails.LocationOfWell == "" || OBJWaltaApplDetails.LocationOfWell == null || OBJWaltaApplDetails.LocationOfWell == "--Select--")
    //            com.Parameters.Add("@LocationOfWell", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@LocationOfWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.LocationOfWell.Trim();

    //        if (OBJWaltaApplDetails.TypeofWell == "" || OBJWaltaApplDetails.TypeofWell == null || OBJWaltaApplDetails.TypeofWell == "--Select--")
    //            com.Parameters.Add("@TypeofWell", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@TypeofWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeofWell.Trim();

    //        if (OBJWaltaApplDetails.TypeOfDrwngWater == "" || OBJWaltaApplDetails.TypeOfDrwngWater == null || OBJWaltaApplDetails.TypeOfDrwngWater == "--Select--")
    //            com.Parameters.Add("@TypeOfDrwngWater", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@TypeOfDrwngWater", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TypeOfDrwngWater.Trim();

    //        if (OBJWaltaApplDetails.SpecifactioncnOFPump == "" || OBJWaltaApplDetails.SpecifactioncnOFPump == null || OBJWaltaApplDetails.SpecifactioncnOFPump == "--Select--")
    //            com.Parameters.Add("@SpecifactioncnOFPump", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@SpecifactioncnOFPump", SqlDbType.VarChar).Value = OBJWaltaApplDetails.SpecifactioncnOFPump.Trim();

    //        if (OBJWaltaApplDetails.DistanceFromExistWell == "" || OBJWaltaApplDetails.DistanceFromExistWell == null || OBJWaltaApplDetails.DistanceFromExistWell == "--Select--")
    //            com.Parameters.Add("@DistanceFromExistWell", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@DistanceFromExistWell", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DistanceFromExistWell.Trim();


    //        if (OBJWaltaApplDetails.ChkAcceptence == "" || OBJWaltaApplDetails.ChkAcceptence == null || OBJWaltaApplDetails.ChkAcceptence == "--Select--")
    //            com.Parameters.Add("@AccepFlag", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@AccepFlag", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ChkAcceptence.Trim();

    //        if (OBJWaltaApplDetails.Createdby == "" || OBJWaltaApplDetails.Createdby == null || OBJWaltaApplDetails.Createdby == "--Select--")
    //            com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Createdby.Trim();


    //        if (OBJWaltaApplDetails.MROOfficeID == "" || OBJWaltaApplDetails.MROOfficeID == null || OBJWaltaApplDetails.MROOfficeID == "--Select--")
    //            com.Parameters.Add("@MROOfficeID", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@MROOfficeID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MROOfficeID.Trim();

    //        if (OBJWaltaApplDetails.LandPassbookPath == "" || OBJWaltaApplDetails.LandPassbookPath == null || OBJWaltaApplDetails.LandPassbookPath == "--Select--")
    //            com.Parameters.Add("@LandPassbookPath", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@LandPassbookPath", SqlDbType.VarChar).Value = OBJWaltaApplDetails.LandPassbookPath.Trim();

    //        if (OBJWaltaApplDetails.Registrationcertificatepath == "" || OBJWaltaApplDetails.Registrationcertificatepath == null || OBJWaltaApplDetails.Registrationcertificatepath == "--Select--")
    //            com.Parameters.Add("@Registrationcertificatepath", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@Registrationcertificatepath", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Registrationcertificatepath.Trim();


    //        if (OBJWaltaApplDetails.IdentityProofPath == "" || OBJWaltaApplDetails.IdentityProofPath == null || OBJWaltaApplDetails.IdentityProofPath == "--Select--")
    //            com.Parameters.Add("@IdentityProofPath", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            com.Parameters.Add("@IdentityProofPath", SqlDbType.VarChar).Value = OBJWaltaApplDetails.IdentityProofPath.Trim();


    //        com.Parameters.Add("@Valid", SqlDbType.Int, 500);
    //        com.Parameters["@Valid"].Direction = ParameterDirection.Output;
    //        com.ExecuteNonQuery();
    //        //com.ExecuteScalar();
    //        valid = (Int32)com.Parameters["@Valid"].Value;

    //        if (OBJWaltaApplDetails.FileUploadPaths != null)
    //        {
    //            if (OBJWaltaApplDetails.FileUploadPaths.Rows.Count > 0)
    //            {

    //                try
    //                {
    //                    for (int i = 0; i < OBJWaltaApplDetails.FileUploadPaths.Rows.Count; i++)
    //                    {
    //                        SqlCommand cmdFiles = new SqlCommand("usp_Insert_Groundwater_attachments", connection);
    //                        cmdFiles.CommandType = CommandType.StoredProcedure;

    //                        cmdFiles.Parameters.AddWithValue("@Groundwater_ID", Convert.ToInt32(valid));
    //                        cmdFiles.Parameters.AddWithValue("@FileType", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["FileType"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FilePath", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["FilePath"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FileName", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["UploadFileName"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FileDescription", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["DocumentName"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@Created_by", Convert.ToInt32(OBJWaltaApplDetails.Createdby));
    //                        cmdFiles.ExecuteNonQuery();

    //                        //resp = "Success";
    //                        resp = Convert.ToString(valid);
    //                    }
    //                }
    //                catch (Exception ex)
    //                {

    //                }
    //            }
    //        }
    //        resp = Convert.ToString(valid);
    //        //con.CloseConnection();
    //        //con.OpenConnection();
    //        //com.Connection = con.GetConnection;

    //        transaction.Commit();
    //        connection.Close();
    //        //return com.ExecuteNonQuery();
    //        //return Convert.ToInt32(com.ExecuteScalar());
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;

    //    }
    //    finally
    //    {
    //        com.Dispose();
    //        //con.CloseConnection();
    //        connection.Close();
    //    }
    //    return resp;
    //}



    //#region MRO ADMIN
    //public DataSet GetDepartmentDashboardDetails_GroundwaterMRO(string intDeptid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {          
    //            da = new SqlDataAdapter("GW_GetDepartmentDashboardDetailsbyMROUSER", con.GetConnection);
    //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            if (intDeptid.Trim() == "" || intDeptid.Trim() == null)
    //                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
    //            else
    //                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = intDeptid.ToString();
    //            da.Fill(ds);
    //            return ds;         
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}
    //public DataSet GetDepartentApplications_GroundwaterMRO(string Deptid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_MRO", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (Deptid.Trim() == "" || Deptid.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}
    //public DataSet GetMonthwiseStatusrptDrill_GroundwaterMRO(string dept, string Status)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {

    //        da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_DRILL_MRO", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = dept;
    //        da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = Status;
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }
    //}

    //#endregion


    //#region  //view attachment
    //public DataSet GetdatadocumentbyQuestioneerieid_Groundwater(string intEnterprenuerid)
    //{
    //    con.OpenConnection();
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        da = new SqlDataAdapter("GW_GetdatadocumentbyQueid_groundwater", con.GetConnection);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();
    //        da.Fill(ds);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.CloseConnection();
    //    }

    //}

    //#endregion




    //          if (OBJWaltaApplDetails.FileUploadPaths != null)
    //        {
    //            if (OBJWaltaApplDetails.FileUploadPaths.Rows.Count > 0)
    //            {

    //                try
    //                {
    //                    for (int i = 0; i<OBJWaltaApplDetails.FileUploadPaths.Rows.Count; i++)
    //                    {
    //                        SqlCommand cmdFiles = new SqlCommand("usp_Insert_Groundwater_attachments", connection);
    //cmdFiles.CommandType = CommandType.StoredProcedure;

    //                        cmdFiles.Parameters.AddWithValue("@Groundwater_ID", Convert.ToInt32(valid));
    //                        cmdFiles.Parameters.AddWithValue("@FileType", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["FileType"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FilePath", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["FilePath"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FileName", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["UploadFileName"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@FileDescription", Convert.ToString(OBJWaltaApplDetails.FileUploadPaths.Rows[i]["DocumentName"].ToString()));
    //                        cmdFiles.Parameters.AddWithValue("@Created_by", Convert.ToInt32(OBJWaltaApplDetails.Createdby));
    //                        cmdFiles.ExecuteNonQuery();

    //                        //resp = "Success";
    //                        resp = Convert.ToString(valid);
    //                    }
    //                }
    //                catch (Exception ex)
    //                {

    //                }
    //            }
    //        }
    #endregion




    #region TRANSCO GROUND WATER
    //public DataSet GetDepartentApplications_GroundwaterDept_TRANSCO(string Deptid)
    //{
    //    SqlConnection con = new SqlConnection(strConnectionString);
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        con.Open();
    //        da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_GrounwaterDept", con);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (Deptid.Trim() == "" || Deptid.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
    //        else
    //            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
    //        da.Fill(ds);
    //        return ds;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //    }
    //}

    #endregion

    #region TRANSCO GROUND WATER
    public DataSet GetDepartentApplications_GroundwaterDept_TRANSCO(string Deptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {

            con.Open();
            da = new SqlDataAdapter("GW_DASHBOARD_DEPARTMENT_GrounwaterDept_Transco", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = Deptid.ToString();
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

    public DataSet GetDepartmentDashboardDetails_GroundwaterDept_TRANSCO(string intDeptid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetDepartmentDashboardDetailsbyGroundwaterUSER_Transco", con);
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
            con.Close();
        }
    }

    public DataSet GetShowDepartmentFiles_grounwaterDept_Transco(string Deptid, string intStageid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("GW_GetShowDepartmentFiles_GroundwaterDeptTransco", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Deptid.Trim() == "" || Deptid.Trim() == null)
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@Deptid", SqlDbType.VarChar).Value = Deptid.ToString();
            if (intStageid.Trim() == "" || intStageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intStageid", SqlDbType.VarChar).Value = intStageid.ToString();
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

public class WaltaApplDetailsproperties
{
    public string GroundwaterID { get; set; }
    public string ApplicationType_IndusorAgriName { get; set; }
    public string ApplicationType_IndusorAgri { get; set; }
    public string ApplicantName { get; set; }
    public string DistrictID { get; set; }
    public string MandalId { get; set; }
    public string VillageId { get; set; }
    public string Street { get; set; }
    public string HouseNo { get; set; }
    public string LocationOfWell { get; set; }
    public string TypeofWell { get; set; }
    public string TypeOfDrwngWater { get; set; }

    public string SpecifactioncnOFPump { get; set; }
    public string DistanceFromExistWell { get; set; }
    public string Createdby { get; set; }
    public string ChkAcceptence { get; set; }

    public string DistrictName { get; set; }
    public string MandalName { get; set; }
    public string VillageName { get; set; }
    public string ApplicantMobileNO { get; set; }
    public string ApplicantEmailID { get; set; }
    public string TypeofWellName { get; set; }
    public string TypeOfDrwngWaterName { get; set; }
    public string CreatedIP { get; set; }
    //public string LandPassbookPath { get; set; }
    //public string Registrationcertificatepath { get; set; }
    //public string IdentityProofPath { get; set; }
    //public string MROOfficeID { get; set; }

  
}


public class WaltaApplfileuploadspro
{
    public string ApplicationID { get; set; }
    public string FileType { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string FileDescription { get; set; }
    public string Created_by { get; set; }
}