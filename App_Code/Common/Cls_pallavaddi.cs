using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Cls_pallavaddi
/// </summary>
public class Cls_pallavaddi
{
    comFunctions cmf = new comFunctions();
    string strConnectionString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    //public Cls_pallavaddi()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public DataSet DB_BindConstitutionUnitpallavadi()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("USP_GETCONSTITUTIONUNIT", con);
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

    public DataSet DB_tUdyogAadharTypepallavadi()
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("USP_GET_UDYOG_AADHAAR_TYPE", con);
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

    public DataSet DB_USP_GETDETAILSFORSECTIONpallavadi(string IncentiveId, string MasterIncentiveId)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("PV_USP_GETDETAILSFORSECTION_appeal_pallavaadi", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
            if (MasterIncentiveId.Trim() == "" || MasterIncentiveId.Trim() == null)
                da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId.ToString();
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


    public DataSet DB_getLOADatapallavadi(string incid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("USP_GET_LOA_DATA", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (incid.Trim() == "" || incid.Trim() == null)
                da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = incid.ToString();
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

    public DataSet DB_getFYClaimperiod(string incid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("PV_getFYClaimperiod", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (incid.Trim() == "" || incid.Trim() == null)
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = incid.ToString();
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

    //public DataSet DB_calleventforbackuppallavadi(string incid)
    //{
    //    SqlConnection con = new SqlConnection(strConnectionString);
    //    SqlDataAdapter da;
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        con.Open();
    //        da = new SqlDataAdapter("calleventforbackup", con);
    //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        if (incid.Trim() == "" || incid.Trim() == null)
    //            da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = DBNull.Value;
    //        else
    //            da.SelectCommand.Parameters.Add("@incid", SqlDbType.VarChar).Value = incid.ToString();
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


    #region insertproc

    public string INSERT_INCENTIVES_DATA_COMMON_appraisal_PAVALLAVADDI(pallavadiproperties OBJWaltaApplDetails)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("USP_INSERT_INCENTIVES_DATA_COMMON_appraisal_PAVALLAVADDI", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();

            if (OBJWaltaApplDetails.incapplnno == "" || OBJWaltaApplDetails.incapplnno == null)
            {
                com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = OBJWaltaApplDetails.incapplnno.Trim();
            }
            if (OBJWaltaApplDetails.txtunitnames == "" || OBJWaltaApplDetails.txtunitnames == null)
            {
                com.Parameters.Add("@txtunitnames", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtunitnames", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtunitnames.Trim();
            }
            if (OBJWaltaApplDetails.txtLocofUnit == "" || OBJWaltaApplDetails.txtLocofUnit == null)
            {
                com.Parameters.Add("@txtLocofUnit", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLocofUnit", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLocofUnit.Trim();
            }
            if (OBJWaltaApplDetails.ddlOrddlorgtypes == "" || OBJWaltaApplDetails.ddlOrddlorgtypes == null)
            {
                com.Parameters.Add("@ddlOrddlorgtypes", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ddlOrddlorgtypes", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ddlOrddlorgtypes.Trim();
            }
            if (OBJWaltaApplDetails.ddlUdyogAadharType == "" || OBJWaltaApplDetails.ddlUdyogAadharType == null)
            {
                com.Parameters.Add("@ddlUdyogAadharType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ddlUdyogAadharType", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ddlUdyogAadharType.Trim();
            }
            if (OBJWaltaApplDetails.txtPersonIndustry == "" || OBJWaltaApplDetails.txtPersonIndustry == null)
            {
                com.Parameters.Add("@txtPersonIndustry", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPersonIndustry", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPersonIndustry.Trim();
            }
            if (OBJWaltaApplDetails.txtDateOfapplnFile == "" || OBJWaltaApplDetails.txtDateOfapplnFile == null)
            {
                com.Parameters.Add("@txtDateOfapplnFile", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDateOfapplnFile", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDateOfapplnFile.Trim();
            }
            if (OBJWaltaApplDetails.txtLoanApplnNo == "" || OBJWaltaApplDetails.txtLoanApplnNo == null)
            {
                com.Parameters.Add("@txtLoanApplnNo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLoanApplnNo", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLoanApplnNo.Trim();
            }
            if (OBJWaltaApplDetails.txtDate_Loan == "" || OBJWaltaApplDetails.txtDate_Loan == null)
            {
                com.Parameters.Add("@txtDate_Loan", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDate_Loan", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDate_Loan.Trim();
            }
            if (OBJWaltaApplDetails.txtNameofFinIns == "" || OBJWaltaApplDetails.txtNameofFinIns == null)
            {
                com.Parameters.Add("@txtNameofFinIns", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtNameofFinIns", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtNameofFinIns.Trim();
            }
            if (OBJWaltaApplDetails.txtPowerConn_date == "" || OBJWaltaApplDetails.txtPowerConn_date == null)
            {
                com.Parameters.Add("@txtPowerConn_date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPowerConn_date", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPowerConn_date.Trim();
            }
            if (OBJWaltaApplDetails.txtPowerConn_load == "" || OBJWaltaApplDetails.txtPowerConn_load == null)
            {
                com.Parameters.Add("@txtPowerConn_load", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPowerConn_load", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPowerConn_load.Trim();
            }
            if (OBJWaltaApplDetails.txtDCP_unit == "" || OBJWaltaApplDetails.txtDCP_unit == null)
            {
                com.Parameters.Add("@txtDCP_unit", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDCP_unit", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDCP_unit.Trim();
            }
            if (OBJWaltaApplDetails.txtrc_dic == "" || OBJWaltaApplDetails.txtrc_dic == null)
            {
                com.Parameters.Add("@txtrc_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtrc_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtrc_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_dic == "" || OBJWaltaApplDetails.txtcompdate_dic == null)
            {
                com.Parameters.Add("@txtcompdate_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtquery_dic == "" || OBJWaltaApplDetails.txtquery_dic == null)
            {
                com.Parameters.Add("@txtquery_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtquery_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtquery_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_coi == "" || OBJWaltaApplDetails.txtcompdate_coi == null)
            {
                com.Parameters.Add("@txtcompdate_coi", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_coi", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_coi.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_coi1 == "" || OBJWaltaApplDetails.txtcompdate_coi1 == null)
            {
                com.Parameters.Add("@txtcompdate_coi1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_coi1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_coi1.Trim();
            }
            if (OBJWaltaApplDetails.txtquery_coi == "" || OBJWaltaApplDetails.txtquery_coi == null)
            {
                com.Parameters.Add("@txtquery_coi", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtquery_coi", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtquery_coi.Trim();
            }
            if (OBJWaltaApplDetails.txtLand2 == "" || OBJWaltaApplDetails.txtLand2 == null)
            {
                com.Parameters.Add("@txtLand2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand2.Trim();
            }
            if (OBJWaltaApplDetails.txtLand3 == "" || OBJWaltaApplDetails.txtLand3 == null)
            {
                com.Parameters.Add("@txtLand3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand3.Trim();
            }
            if (OBJWaltaApplDetails.txtLand4 == "" || OBJWaltaApplDetails.txtLand4 == null)
            {
                com.Parameters.Add("@txtLand4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand4.Trim();
            }
            if (OBJWaltaApplDetails.txtLand5 == "" || OBJWaltaApplDetails.txtLand5 == null)
            {
                com.Parameters.Add("@txtLand5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand5.Trim();
            }
            if (OBJWaltaApplDetails.txtLand6 == "" || OBJWaltaApplDetails.txtLand6 == null)
            {
                com.Parameters.Add("@txtLand6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand6.Trim();
            }
            if (OBJWaltaApplDetails.txtLand7 == "" || OBJWaltaApplDetails.txtLand7 == null)
            {
                com.Parameters.Add("@txtLand7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand7.Trim();
            }

            if (OBJWaltaApplDetails.txtBuilding2 == "" || OBJWaltaApplDetails.txtBuilding2 == null)
            {
                com.Parameters.Add("@txtBuilding2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding2.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding3 == "" || OBJWaltaApplDetails.txtBuilding3 == null)
            {
                com.Parameters.Add("@txtBuilding3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding3.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding4 == "" || OBJWaltaApplDetails.txtBuilding4 == null)
            {
                com.Parameters.Add("@txtBuilding4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding4.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding5 == "" || OBJWaltaApplDetails.txtBuilding5 == null)
            {
                com.Parameters.Add("@txtBuilding5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding5.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding6 == "" || OBJWaltaApplDetails.txtBuilding6 == null)
            {
                com.Parameters.Add("@txtBuilding6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding6.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding7 == "" || OBJWaltaApplDetails.txtBuilding7 == null)
            {
                com.Parameters.Add("@txtBuilding7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding7.Trim();
            }
            if (OBJWaltaApplDetails.txtPM2 == "" || OBJWaltaApplDetails.txtPM2 == null)
            {
                com.Parameters.Add("@txtPM2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM2.Trim();
            }
            if (OBJWaltaApplDetails.txtPM3 == "" || OBJWaltaApplDetails.txtPM3 == null)
            {
                com.Parameters.Add("@txtPM3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM3.Trim();
            }
            if (OBJWaltaApplDetails.txtPM4 == "" || OBJWaltaApplDetails.txtPM4 == null)
            {
                com.Parameters.Add("@txtPM4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM4.Trim();
            }
            if (OBJWaltaApplDetails.txtPM5 == "" || OBJWaltaApplDetails.txtPM5 == null)
            {
                com.Parameters.Add("@txtPM5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM5.Trim();
            }
            if (OBJWaltaApplDetails.txtPM6 == "" || OBJWaltaApplDetails.txtPM6 == null)
            {
                com.Parameters.Add("@txtPM6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM6.Trim();
            }
            if (OBJWaltaApplDetails.txtPM7 == "" || OBJWaltaApplDetails.txtPM7 == null)
            {
                com.Parameters.Add("@txtPM7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM7.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont2 == "" || OBJWaltaApplDetails.txtMCont2 == null)
            {
                com.Parameters.Add("@txtMCont2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont2.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont3 == "" || OBJWaltaApplDetails.txtMCont3 == null)
            {
                com.Parameters.Add("@txtMCont3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont3.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont4 == "" || OBJWaltaApplDetails.txtMCont4 == null)
            {
                com.Parameters.Add("@txtMCont4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont4.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont5 == "" || OBJWaltaApplDetails.txtMCont5 == null)
            {
                com.Parameters.Add("@txtMCont5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont5.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont6 == "" || OBJWaltaApplDetails.txtMCont6 == null)
            {
                com.Parameters.Add("@txtMCont6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont6.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont7 == "" || OBJWaltaApplDetails.txtMCont7 == null)
            {
                com.Parameters.Add("@txtMCont7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont7.Trim();
            }
            if (OBJWaltaApplDetails.txtErec2 == "" || OBJWaltaApplDetails.txtErec2 == null)
            {
                com.Parameters.Add("@txtErec2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec2.Trim();
            }
            if (OBJWaltaApplDetails.txtErec3 == "" || OBJWaltaApplDetails.txtErec3 == null)
            {
                com.Parameters.Add("@txtErec3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec3.Trim();
            }
            if (OBJWaltaApplDetails.txtErec4 == "" || OBJWaltaApplDetails.txtErec4 == null)
            {
                com.Parameters.Add("@txtErec4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec4.Trim();
            }
            if (OBJWaltaApplDetails.txtErec5 == "" || OBJWaltaApplDetails.txtErec5 == null)
            {
                com.Parameters.Add("@txtErec5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec5.Trim();
            }
            if (OBJWaltaApplDetails.txtErec6 == "" || OBJWaltaApplDetails.txtErec6 == null)
            {
                com.Parameters.Add("@txtErec6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec6.Trim();
            }
            if (OBJWaltaApplDetails.txtErec7 == "" || OBJWaltaApplDetails.txtErec7 == null)
            {
                com.Parameters.Add("@txtErec7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec7.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS2 == "" || OBJWaltaApplDetails.txtTFS2 == null)
            {
                com.Parameters.Add("@txtTFS2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS2.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS3 == "" || OBJWaltaApplDetails.txtTFS3 == null)
            {
                com.Parameters.Add("@txtTFS3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS3.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS4 == "" || OBJWaltaApplDetails.txtTFS4 == null)
            {
                com.Parameters.Add("@txtTFS4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS4.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS5 == "" || OBJWaltaApplDetails.txtTFS5 == null)
            {
                com.Parameters.Add("@txtTFS5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS5.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS6 == "" || OBJWaltaApplDetails.txtTFS6 == null)
            {
                com.Parameters.Add("@txtTFS6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS6.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS7 == "" || OBJWaltaApplDetails.txtTFS7 == null)
            {
                com.Parameters.Add("@txtTFS7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS7.Trim();
            }
            if (OBJWaltaApplDetails.txtWC2 == "" || OBJWaltaApplDetails.txtWC2 == null)
            {
                com.Parameters.Add("@txtWC2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC2.Trim();
            }
            if (OBJWaltaApplDetails.txtWC3 == "" || OBJWaltaApplDetails.txtWC3 == null)
            {
                com.Parameters.Add("@txtWC3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC3.Trim();
            }
            if (OBJWaltaApplDetails.txtWC4 == "" || OBJWaltaApplDetails.txtWC4 == null)
            {
                com.Parameters.Add("@txtWC4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC4.Trim();
            }
            if (OBJWaltaApplDetails.txtWC5 == "" || OBJWaltaApplDetails.txtWC5 == null)
            {
                com.Parameters.Add("@txtWC5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC5.Trim();
            }
            if (OBJWaltaApplDetails.txtWC6 == "" || OBJWaltaApplDetails.txtWC6 == null)
            {
                com.Parameters.Add("@txtWC6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC6.Trim();
            }
            if (OBJWaltaApplDetails.txtWC7 == "" || OBJWaltaApplDetails.txtWC7 == null)
            {
                com.Parameters.Add("@txtWC7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC7.Trim();
            }
            if (OBJWaltaApplDetails.txtLandcostCompc == "" || OBJWaltaApplDetails.txtLandcostCompc == null)
            {
                com.Parameters.Add("@txtLandcostCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLandcostCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLandcostCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtLandAreaCompc == "" || OBJWaltaApplDetails.txtLandAreaCompc == null)
            {
                com.Parameters.Add("@txtLandAreaCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLandAreaCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLandAreaCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtPurchaCompc == "" || OBJWaltaApplDetails.txtPurchaCompc == null)
            {
                com.Parameters.Add("@txtPurchaCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPurchaCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPurchaCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtStmpDutyCompc == "" || OBJWaltaApplDetails.txtStmpDutyCompc == null)
            {
                com.Parameters.Add("@txtStmpDutyCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtStmpDutyCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtStmpDutyCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtRegnfeeCompc == "" || OBJWaltaApplDetails.txtRegnfeeCompc == null)
            {
                com.Parameters.Add("@txtRegnfeeCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtRegnfeeCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtRegnfeeCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtTotalCompc == "" || OBJWaltaApplDetails.txtTotalCompc == null)
            {
                com.Parameters.Add("@txtTotalCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTotalCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTotalCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtBuildingAreCompc == "" || OBJWaltaApplDetails.txtBuildingAreCompc == null)
            {
                com.Parameters.Add("@txtBuildingAreCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuildingAreCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuildingAreCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtvalDICCompc == "" || OBJWaltaApplDetails.txtvalDICCompc == null)
            {
                com.Parameters.Add("@txtvalDICCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalDICCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalDICCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtvalCompc1 == "" || OBJWaltaApplDetails.txtvalCompc1 == null)
            {
                com.Parameters.Add("@txtvalCompc1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalCompc1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalCompc1.Trim();
            }
            if (OBJWaltaApplDetails.txtresonsCompc == "" || OBJWaltaApplDetails.txtresonsCompc == null)
            {
                com.Parameters.Add("@txtresonsCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtresonsCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtresonsCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtfacCostCompc == "" || OBJWaltaApplDetails.txtfacCostCompc == null)
            {
                com.Parameters.Add("@txtfacCostCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtfacCostCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtfacCostCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtfacBldgCompc == "" || OBJWaltaApplDetails.txtfacBldgCompc == null)
            {
                com.Parameters.Add("@txtfacBldgCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtfacBldgCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtfacBldgCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtcivilEngCompc == "" || OBJWaltaApplDetails.txtcivilEngCompc == null)
            {
                com.Parameters.Add("@txtcivilEngCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcivilEngCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcivilEngCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtsfcCompc == "" || OBJWaltaApplDetails.txtsfcCompc == null)
            {
                com.Parameters.Add("@txtsfcCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtsfcCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtsfcCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtCAExpCompc == "" || OBJWaltaApplDetails.txtCAExpCompc == null)
            {
                com.Parameters.Add("@txtCAExpCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtCAExpCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtCAExpCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtCompvalCompc == "" || OBJWaltaApplDetails.txtCompvalCompc == null)
            {
                com.Parameters.Add("@txtCompvalCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtCompvalCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtCompvalCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtrsnCompc == "" || OBJWaltaApplDetails.txtrsnCompc == null)
            {
                com.Parameters.Add("@txtrsnCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtrsnCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtrsnCompc.Trim();
            }

            if (OBJWaltaApplDetails.TextBox30 == "" || OBJWaltaApplDetails.TextBox30 == null)
            {
                com.Parameters.Add("@TextBox30", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox30", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox30.Trim();
            }
            if (OBJWaltaApplDetails.TextBox32 == "" || OBJWaltaApplDetails.TextBox32 == null)
            {
                com.Parameters.Add("@TextBox32", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox32", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox32.Trim();
            }
            if (OBJWaltaApplDetails.TextBox31 == "" || OBJWaltaApplDetails.TextBox31 == null)
            {
                com.Parameters.Add("@TextBox31", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox31", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox31.Trim();
            }
            if (OBJWaltaApplDetails.TextBox34 == "" || OBJWaltaApplDetails.TextBox34 == null)
            {
                com.Parameters.Add("@TextBox34", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox34", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox34.Trim();
            }
            if (OBJWaltaApplDetails.TextBox36 == "" || OBJWaltaApplDetails.TextBox36 == null)
            {
                com.Parameters.Add("@TextBox36", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox36", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox36.Trim();
            }
            if (OBJWaltaApplDetails.TextBox38 == "" || OBJWaltaApplDetails.TextBox38 == null)
            {
                com.Parameters.Add("@TextBox38", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox38", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox38.Trim();
            }
            if (OBJWaltaApplDetails.TextBox40 == "" || OBJWaltaApplDetails.TextBox40 == null)
            {
                com.Parameters.Add("@TextBox40", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox40", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox40.Trim();
            }
            if (OBJWaltaApplDetails.TextBox42 == "" || OBJWaltaApplDetails.TextBox42 == null)
            {
                com.Parameters.Add("@TextBox42", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox42", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox42.Trim();
            }
            if (OBJWaltaApplDetails.TextBox47 == "" || OBJWaltaApplDetails.TextBox47 == null)
            {
                com.Parameters.Add("@TextBox47", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox47", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox47.Trim();
            }
            if (OBJWaltaApplDetails.TextBox33 == "" || OBJWaltaApplDetails.TextBox33 == null)
            {
                com.Parameters.Add("@TextBox33", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox33", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox33.Trim();
            }
            if (OBJWaltaApplDetails.TextBox37 == "" || OBJWaltaApplDetails.TextBox37 == null)
            {
                com.Parameters.Add("@TextBox37", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox37", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox37.Trim();
            }
            if (OBJWaltaApplDetails.TextBox41 == "" || OBJWaltaApplDetails.TextBox41 == null)
            {
                com.Parameters.Add("@TextBox41", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox41", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox41.Trim();
            }
            if (OBJWaltaApplDetails.TextBox44 == "" || OBJWaltaApplDetails.TextBox44 == null)
            {
                com.Parameters.Add("@TextBox44", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox44", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox44.Trim();
            }

            if (OBJWaltaApplDetails.TextBox1 == "" || OBJWaltaApplDetails.TextBox1 == null)
            {
                com.Parameters.Add("@TextBox1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox1.Trim();
            }
            if (OBJWaltaApplDetails.TextBox56 == "" || OBJWaltaApplDetails.TextBox56 == null)
            {
                com.Parameters.Add("@TextBox56", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox56", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox56.Trim();
            }
            if (OBJWaltaApplDetails.TextBox57 == "" || OBJWaltaApplDetails.TextBox57 == null)
            {
                com.Parameters.Add("@TextBox57", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox57", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox57.Trim();
            }
            if (OBJWaltaApplDetails.TextBox58 == "" || OBJWaltaApplDetails.TextBox58 == null)
            {
                com.Parameters.Add("@TextBox58", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox58", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox58.Trim();
            }
            if (OBJWaltaApplDetails.TextBox45 == "" || OBJWaltaApplDetails.TextBox45 == null)
            {
                com.Parameters.Add("@TextBox45", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox45", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox45.Trim();
            }
            if (OBJWaltaApplDetails.TextBox2 == "" || OBJWaltaApplDetails.TextBox2 == null)
            {
                com.Parameters.Add("@TextBox2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox2.Trim();
            }
            if (OBJWaltaApplDetails.TextBox35 == "" || OBJWaltaApplDetails.TextBox35 == null)
            {
                com.Parameters.Add("@TextBox35", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox35", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox35.Trim();
            }
            if (OBJWaltaApplDetails.TextBox39 == "" || OBJWaltaApplDetails.TextBox39 == null)
            {
                com.Parameters.Add("@TextBox39", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox39", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox39.Trim();
            }
            if (OBJWaltaApplDetails.TextBox43 == "" || OBJWaltaApplDetails.TextBox43 == null)
            {
                com.Parameters.Add("@TextBox43", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox43", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox43.Trim();
            }
            if (OBJWaltaApplDetails.TextBox46 == "" || OBJWaltaApplDetails.TextBox46 == null)
            {
                com.Parameters.Add("@TextBox46", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox46", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox46.Trim();
            }
            if (OBJWaltaApplDetails.TextBox48 == "" || OBJWaltaApplDetails.TextBox48 == null)
            {
                com.Parameters.Add("@TextBox48", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox48", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox48.Trim();
            }
            if (OBJWaltaApplDetails.txtContProdMgm == "" || OBJWaltaApplDetails.txtContProdMgm == null)
            {
                com.Parameters.Add("@txtContProdMgm", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtContProdMgm", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtContProdMgm.Trim();
            }
            if (OBJWaltaApplDetails.txt25BldgCvl == "" || OBJWaltaApplDetails.txt25BldgCvl == null)
            {
                com.Parameters.Add("@txt25BldgCvl", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt25BldgCvl", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt25BldgCvl.Trim();
            }
            if (OBJWaltaApplDetails.txt822guideline422 == "" || OBJWaltaApplDetails.txt822guideline422 == null)
            {
                com.Parameters.Add("@txt822guideline422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt822guideline422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt822guideline422.Trim();
            }
            if (OBJWaltaApplDetails.txtTSSFCnorms422 == "" || OBJWaltaApplDetails.txtTSSFCnorms422 == null)
            {
                com.Parameters.Add("@txtTSSFCnorms422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTSSFCnorms422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTSSFCnorms422.Trim();
            }
            if (OBJWaltaApplDetails.txtPlintharea424 == "" || OBJWaltaApplDetails.txtPlintharea424 == null)
            {
                com.Parameters.Add("@txtPlintharea424", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPlintharea424", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPlintharea424.Trim();
            }
            if (OBJWaltaApplDetails.txtPlintharea422 == "" || OBJWaltaApplDetails.txtPlintharea422 == null)
            {
                com.Parameters.Add("@txtPlintharea422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPlintharea422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPlintharea422.Trim();
            }
            if (OBJWaltaApplDetails.txtvalue422 == "" || OBJWaltaApplDetails.txtvalue422 == null)
            {
                com.Parameters.Add("@txtvalue422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalue422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalue422.Trim();
            }
            if (OBJWaltaApplDetails.TextBox59 == "" || OBJWaltaApplDetails.TextBox59 == null)
            {
                com.Parameters.Add("@TextBox59", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox59", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox59.Trim();
            }
            if (OBJWaltaApplDetails.txt423guideline == "" || OBJWaltaApplDetails.txt423guideline == null)
            {
                com.Parameters.Add("@txt423guideline", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt423guideline", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt423guideline.Trim();
            }
            if (OBJWaltaApplDetails.txtTSSFCnorms423 == "" || OBJWaltaApplDetails.txtTSSFCnorms423 == null)
            {
                com.Parameters.Add("@txtTSSFCnorms423", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTSSFCnorms423", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTSSFCnorms423.Trim();
            }
            if (OBJWaltaApplDetails.txtvalue424 == "" || OBJWaltaApplDetails.txtvalue424 == null)
            {
                com.Parameters.Add("@txtvalue424", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalue424", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalue424.Trim();
            }
            if (OBJWaltaApplDetails.createdby == "" || OBJWaltaApplDetails.createdby == null)
            {
                com.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@createdby", SqlDbType.VarChar).Value = OBJWaltaApplDetails.createdby.Trim();
            }
            if (OBJWaltaApplDetails.incentiveid == "" || OBJWaltaApplDetails.incentiveid == null)
            {
                com.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = OBJWaltaApplDetails.incentiveid.Trim();
            }
            if (OBJWaltaApplDetails.TextBox60 == "" || OBJWaltaApplDetails.TextBox60 == null)
            {
                com.Parameters.Add("@TextBox60", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox60", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox60.Trim();
            }
            if (OBJWaltaApplDetails.TextBox5 == "" || OBJWaltaApplDetails.TextBox5 == null)
            {
                com.Parameters.Add("@TextBox5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox5.Trim();
            }
            if (OBJWaltaApplDetails.TextBox7 == "" || OBJWaltaApplDetails.TextBox7 == null)
            {
                com.Parameters.Add("@TextBox7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox7.Trim();
            }
            if (OBJWaltaApplDetails.TextBox9 == "" || OBJWaltaApplDetails.TextBox9 == null)
            {
                com.Parameters.Add("@TextBox9", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox9", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox9.Trim();
            }
            if (OBJWaltaApplDetails.TextBox11 == "" || OBJWaltaApplDetails.TextBox11 == null)
            {
                com.Parameters.Add("@TextBox11", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox11", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox11.Trim();
            }
            if (OBJWaltaApplDetails.TextBox13 == "" || OBJWaltaApplDetails.TextBox13 == null)
            {
                com.Parameters.Add("@TextBox13", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox13", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox13.Trim();
            }
            if (OBJWaltaApplDetails.TextBox15 == "" || OBJWaltaApplDetails.TextBox15 == null)
            {
                com.Parameters.Add("@TextBox15", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox15", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox15.Trim();
            }
            if (OBJWaltaApplDetails.TextBox17 == "" || OBJWaltaApplDetails.TextBox17 == null)
            {
                com.Parameters.Add("@TextBox17", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox17", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox17.Trim();
            }
            if (OBJWaltaApplDetails.TextBox18 == "" || OBJWaltaApplDetails.TextBox18 == null)
            {
                com.Parameters.Add("@TextBox18", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox18", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox18.Trim();
            }
            if (OBJWaltaApplDetails.TextBox19 == "" || OBJWaltaApplDetails.TextBox19 == null)
            {
                com.Parameters.Add("@TextBox19", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox19", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox19.Trim();
            }
            if (OBJWaltaApplDetails.TextBox61 == "" || OBJWaltaApplDetails.TextBox61 == null)
            {
                com.Parameters.Add("@TextBox61", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox61", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox61.Trim();
            }
            if (OBJWaltaApplDetails.TextBox6 == "" || OBJWaltaApplDetails.TextBox6 == null)
            {
                com.Parameters.Add("@TextBox6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox6.Trim();
            }
            if (OBJWaltaApplDetails.TextBox8 == "" || OBJWaltaApplDetails.TextBox8 == null)
            {
                com.Parameters.Add("@TextBox8", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox8", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox8.Trim();
            }
            if (OBJWaltaApplDetails.TextBox10 == "" || OBJWaltaApplDetails.TextBox10 == null)
            {
                com.Parameters.Add("@TextBox10", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox10", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox10.Trim();
            }
            if (OBJWaltaApplDetails.TextBox12 == "" || OBJWaltaApplDetails.TextBox12 == null)
            {
                com.Parameters.Add("@TextBox12", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox12", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox12.Trim();
            }
            if (OBJWaltaApplDetails.TextBox14 == "" || OBJWaltaApplDetails.TextBox14 == null)
            {
                com.Parameters.Add("@TextBox14", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox14", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox14.Trim();
            }
            if (OBJWaltaApplDetails.TextBox16 == "" || OBJWaltaApplDetails.TextBox16 == null)
            {
                com.Parameters.Add("@TextBox16", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox16", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox16.Trim();
            }
            if (OBJWaltaApplDetails.TextBox20 == "" || OBJWaltaApplDetails.TextBox20 == null)
            {
                com.Parameters.Add("@TextBox20", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox20", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox20.Trim();
            }


            if (OBJWaltaApplDetails.RDELIGIBLE == "" || OBJWaltaApplDetails.RDELIGIBLE == null)
            {
                com.Parameters.Add("@RDELIGIBLE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@RDELIGIBLE", SqlDbType.VarChar).Value = OBJWaltaApplDetails.RDELIGIBLE.Trim();
            }
            if (OBJWaltaApplDetails.Remarks == "" || OBJWaltaApplDetails.Remarks == null)
            {
                com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Remarks.Trim();
            }
            if (OBJWaltaApplDetails.MstIncentiveId == "" || OBJWaltaApplDetails.MstIncentiveId == null)
            {
                com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MstIncentiveId.Trim();
            }
            if (OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT == "" || OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT == null)
            {
                com.Parameters.Add("@ELIGIBLESANCTIONEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ELIGIBLESANCTIONEDAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT.Trim();
            }
            if (OBJWaltaApplDetails.CLAIMPERIODID == "" || OBJWaltaApplDetails.CLAIMPERIODID == null)
            {
                com.Parameters.Add("@CLAIMPERIODID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CLAIMPERIODID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.CLAIMPERIODID.Trim();
            }
            if (OBJWaltaApplDetails.CLAIMPERIOD == "" || OBJWaltaApplDetails.CLAIMPERIOD == null)
            {
                com.Parameters.Add("@CLAIMPERIOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CLAIMPERIOD", SqlDbType.VarChar).Value = OBJWaltaApplDetails.CLAIMPERIOD.Trim();
            }
            if (OBJWaltaApplDetails.DATEOFCOMMENCEMENTOFACTIVITY == null)
            {
                com.Parameters.Add("@DATEOFCOMMENCEMENTOFACTIVITY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@DATEOFCOMMENCEMENTOFACTIVITY", SqlDbType.DateTime).Value = OBJWaltaApplDetails.DATEOFCOMMENCEMENTOFACTIVITY;
            }
            if (OBJWaltaApplDetails.PERIODOFINSTALMENTID == "" || OBJWaltaApplDetails.PERIODOFINSTALMENTID == null)
            {
                com.Parameters.Add("@PERIODOFINSTALMENTID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PERIODOFINSTALMENTID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PERIODOFINSTALMENTID.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTPERIOD == "" || OBJWaltaApplDetails.INSTALMENTPERIOD == null)
            {
                com.Parameters.Add("@INSTALMENTPERIOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTPERIOD", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTPERIOD.Trim();
            }
            if (OBJWaltaApplDetails.NOOFINSTALMENTS == "" || OBJWaltaApplDetails.NOOFINSTALMENTS == null)
            {
                com.Parameters.Add("@NOOFINSTALMENTS", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NOOFINSTALMENTS", SqlDbType.VarChar).Value = OBJWaltaApplDetails.NOOFINSTALMENTS.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTAMOUNT == null)
            {
                com.Parameters.Add("@INSTALMENTAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTAMOUNT;
            }
            if (OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID == "" || OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID == null)
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_ID", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_ID", SqlDbType.DateTime).Value = OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE == "" || OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE == null)
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_VALUE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_VALUE", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE.Trim();
            }
            if (OBJWaltaApplDetails.RATEOFINTEREST == "" || OBJWaltaApplDetails.RATEOFINTEREST == null)
            {
                com.Parameters.Add("@RATEOFINTEREST", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@RATEOFINTEREST", SqlDbType.VarChar).Value = OBJWaltaApplDetails.RATEOFINTEREST.Trim();
            }
            if (OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT == "" || OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT == null)
            {
                com.Parameters.Add("@ELIGIBLERATEOFREUMBERSEMENT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ELIGIBLERATEOFREUMBERSEMENT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT.Trim();
            }
            if (OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED == "" || OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED == null)
            {
                com.Parameters.Add("@NOOFINSTALMENTS_COMPLETED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NOOFINSTALMENTS_COMPLETED", SqlDbType.VarChar).Value = OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED.Trim();
            }
            if (OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR == "" || OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR == null)
            {
                com.Parameters.Add("@PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR.Trim();
            }
            if (OBJWaltaApplDetails.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS == null)
            {
                com.Parameters.Add("@INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS;
            }
            if (OBJWaltaApplDetails.ACTUALINTERESTAMOUNT_PAID == null)
            {
                com.Parameters.Add("@ACTUALINTERESTAMOUNT_PAID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ACTUALINTERESTAMOUNT_PAID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ACTUALINTERESTAMOUNT_PAID;
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED", SqlDbType.VarChar).Value = DBNull.Value;

            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED;
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED_FINAL == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED_FINAL;
            }
            if (OBJWaltaApplDetails.GMRECOMMENDEDAMOUNT == null)
            {
                com.Parameters.Add("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.GMRECOMMENDEDAMOUNT;
            }
            if (OBJWaltaApplDetails.FINALELIGIBLEAMOUNT == null)
            {
                com.Parameters.Add("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.FINALELIGIBLEAMOUNT;
            }
            if (OBJWaltaApplDetails.EglibleTypeID == null)
            {
                com.Parameters.Add("@EglibleTypeID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@EglibleTypeID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.EglibleTypeID;
            }
            if (OBJWaltaApplDetails.EglibleTypeName == null)
            {
                com.Parameters.Add("@EglibleTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@EglibleTypeName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.EglibleTypeName;
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATEDaftereglibletype", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATEDaftereglibletype", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype;
            }
            if (OBJWaltaApplDetails.PERIODOFINSTALMENTName == null)
            {
                com.Parameters.Add("@PERIODOFINSTALMENTName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PERIODOFINSTALMENTName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PERIODOFINSTALMENTName;
            }

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


    public bool DB_INSERTPVCALIMSDATA(pallavadisubproperties objgriduploads)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("SP_INSERTPVCALIMSDATA", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            if (objgriduploads.INCENTIVEID == "" || objgriduploads.INCENTIVEID == null)
            {
                cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INCENTIVEID);
            }
            if (objgriduploads.CLAIMPERIOD_Grid == "" || objgriduploads.CLAIMPERIOD_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIOD_Grid);
            }
            if (objgriduploads.PERIODOFINSTALMENT_MAINTABLE == "" || objgriduploads.PERIODOFINSTALMENT_MAINTABLE == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFINSTALMENT_MAINTABLE);
            }
            if (objgriduploads.NOOFINSTALLMENTS_MAINTABLE == "" || objgriduploads.NOOFINSTALLMENTS_MAINTABLE == null)
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENTS_MAINTABLE);
            }
            if (objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == "" || objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid);
            }
            if (objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID);
            }
            if (objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID);
            }
            if (objgriduploads.PRINCIPALAMOUNTDUE_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PRINCIPALAMOUNTDUE_GRID);
            }
            if (objgriduploads.NOOFINSTALLMENT_GRID == "" || objgriduploads.NOOFINSTALLMENT_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENT_GRID);
            }
            if (objgriduploads.INTERESTAMOUNT_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNT_GRID);
            }
            if (objgriduploads.InstallmentAmount == null)
            {
                cmdpacd.Parameters.AddWithValue("@InstallmentAmount", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@InstallmentAmount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.InstallmentAmount);
            }
            if (objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID);
            }
            if (objgriduploads.ACTUALINTERESTAMOUNTPAID == null)
            {
                cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ACTUALINTERESTAMOUNTPAID);
            }
            if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED == null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED);
            }
            if (objgriduploads.ELIGIBLETYPE == "" || objgriduploads.ELIGIBLETYPE == null)
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPE);
            }
            if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL == null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL);
            }
            if (objgriduploads.GMRECOMMENDEDAMOUNT == null)
            {
                cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.GMRECOMMENDEDAMOUNT);
            }
            if (objgriduploads.FINALELIGIBLEAMOUNT == null)
            {
                cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.FINALELIGIBLEAMOUNT);
            }
            if (objgriduploads.IPADDRESS == "" || objgriduploads.IPADDRESS == null)
            {
                cmdpacd.Parameters.AddWithValue("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@IPADDRESS", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IPADDRESS);
            }
            if (objgriduploads.CREATED_BY == "" || objgriduploads.CREATED_BY == null)
            {
                cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CREATED_BY);
            }
            if (objgriduploads.interestegliblereimbursement == null)
            {
                cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.interestegliblereimbursement);
            }
            if (objgriduploads.SUBPallvaid == null)
            {
                cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.SUBPallvaid);
            }
            if (objgriduploads.CLAIMPERIODName_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIODName_Grid);
            }
            if (objgriduploads.PeriodofinstallmentName == null)
            {
                cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PeriodofinstallmentName);
            }

            if (objgriduploads.principalamountduefornexthalfyr_grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.principalamountduefornexthalfyr_grid);
            }
            if (objgriduploads.ELIGIBLETYPEName == null)
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPEName);
            }

            if (objgriduploads.eligibleperiodinmonths == null)
            {
                cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligibleperiodinmonths);
            }
            if (objgriduploads.installmentstartmonthyear == null)
            {
                cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.installmentstartmonthyear);
            }
            if (objgriduploads.dcpdate == null)
            {
                cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = Convert.ToString(objgriduploads.dcpdate);
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

    public DataSet DB_apprasialnote2pallavaddi(string IncentiveId, string CLAIMPERIOD_Grid)
    {
        SqlConnection con = new SqlConnection(strConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            da = new SqlDataAdapter("pv_apprasialnote2pallavaddi", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
            if (CLAIMPERIOD_Grid.Trim() == "" || CLAIMPERIOD_Grid.Trim() == null)
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = CLAIMPERIOD_Grid.ToString();


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


    public string INSERT_INCENTIVES_DATA_COMMON_appraisal_PAVALLAVADDILoan(pallavadiproperties OBJWaltaApplDetails)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("PV_insertappraisalpallavaddiCommontdetails", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();

            //if (OBJWaltaApplDetails.incapplnno == "" || OBJWaltaApplDetails.incapplnno == null)
            //{
            //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = DBNull.Value;
            //}else{
            //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = OBJWaltaApplDetails.incapplnno.Trim();
            //}


            if (OBJWaltaApplDetails.lblApplicationno == "" || OBJWaltaApplDetails.lblApplicationno == null)
            {
                com.Parameters.Add("@lblApplicationno", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@lblApplicationno", SqlDbType.VarChar).Value = OBJWaltaApplDetails.lblApplicationno.Trim();
            }
            if (OBJWaltaApplDetails.txtunitnames == "" || OBJWaltaApplDetails.txtunitnames == null)
            {
                com.Parameters.Add("@txtunitnames", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtunitnames", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtunitnames.Trim();
            }
            if (OBJWaltaApplDetails.txtLocofUnit == "" || OBJWaltaApplDetails.txtLocofUnit == null)
            {
                com.Parameters.Add("@txtLocofUnit", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLocofUnit", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLocofUnit.Trim();
            }
            if (OBJWaltaApplDetails.ddlOrddlorgtypes == "" || OBJWaltaApplDetails.ddlOrddlorgtypes == null)
            {
                com.Parameters.Add("@ddlOrddlorgtypes", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ddlOrddlorgtypes", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ddlOrddlorgtypes.Trim();
            }
            if (OBJWaltaApplDetails.ddlUdyogAadharType == "" || OBJWaltaApplDetails.ddlUdyogAadharType == null)
            {
                com.Parameters.Add("@ddlUdyogAadharType", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ddlUdyogAadharType", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ddlUdyogAadharType.Trim();
            }
            if (OBJWaltaApplDetails.txtPersonIndustry == "" || OBJWaltaApplDetails.txtPersonIndustry == null)
            {
                com.Parameters.Add("@txtPersonIndustry", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPersonIndustry", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPersonIndustry.Trim();
            }
            if (OBJWaltaApplDetails.txtDateOfapplnFile == "" || OBJWaltaApplDetails.txtDateOfapplnFile == null)
            {
                com.Parameters.Add("@txtDateOfapplnFile", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDateOfapplnFile", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDateOfapplnFile.Trim();
            }
            if (OBJWaltaApplDetails.txtLoanApplnNo == "" || OBJWaltaApplDetails.txtLoanApplnNo == null)
            {
                com.Parameters.Add("@txtLoanApplnNo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLoanApplnNo", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLoanApplnNo.Trim();
            }

            if (OBJWaltaApplDetails.txtDate_Loan == "" || OBJWaltaApplDetails.txtDate_Loan == null)
            {
                com.Parameters.Add("@txtDate_Loan", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDate_Loan", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDate_Loan.Trim();
            }
            if (OBJWaltaApplDetails.txtNameofFinIns == "" || OBJWaltaApplDetails.txtNameofFinIns == null)
            {
                com.Parameters.Add("@txtNameofFinIns", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtNameofFinIns", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtNameofFinIns.Trim();
            }
            if (OBJWaltaApplDetails.txtPowerConn_date == "" || OBJWaltaApplDetails.txtPowerConn_date == null)
            {
                com.Parameters.Add("@txtPowerConn_date", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPowerConn_date", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPowerConn_date.Trim();
            }
            if (OBJWaltaApplDetails.txtPowerConn_load == "" || OBJWaltaApplDetails.txtPowerConn_load == null)
            {
                com.Parameters.Add("@txtPowerConn_load", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPowerConn_load", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPowerConn_load.Trim();
            }
            if (OBJWaltaApplDetails.txtDCP_unit == "" || OBJWaltaApplDetails.txtDCP_unit == null)
            {
                com.Parameters.Add("@txtDCP_unit", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtDCP_unit", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtDCP_unit.Trim();
            }
            if (OBJWaltaApplDetails.txtrc_dic == "" || OBJWaltaApplDetails.txtrc_dic == null)
            {
                com.Parameters.Add("@txtrc_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtrc_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtrc_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_dic == "" || OBJWaltaApplDetails.txtcompdate_dic == null)
            {
                com.Parameters.Add("@txtcompdate_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtquery_dic == "" || OBJWaltaApplDetails.txtquery_dic == null)
            {
                com.Parameters.Add("@txtquery_dic", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtquery_dic", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtquery_dic.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_coi == "" || OBJWaltaApplDetails.txtcompdate_coi == null)
            {
                com.Parameters.Add("@txtcompdate_coi", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_coi", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_coi.Trim();
            }
            if (OBJWaltaApplDetails.txtcompdate_coi1 == "" || OBJWaltaApplDetails.txtcompdate_coi1 == null)
            {
                com.Parameters.Add("@txtcompdate_coi1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcompdate_coi1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcompdate_coi1.Trim();
            }
            if (OBJWaltaApplDetails.txtquery_coi == "" || OBJWaltaApplDetails.txtquery_coi == null)
            {
                com.Parameters.Add("@txtquery_coi", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtquery_coi", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtquery_coi.Trim();
            }
            if (OBJWaltaApplDetails.txtLand2 == "" || OBJWaltaApplDetails.txtLand2 == null)
            {
                com.Parameters.Add("@txtLand2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand2.Trim();
            }
            if (OBJWaltaApplDetails.txtLand3 == "" || OBJWaltaApplDetails.txtLand3 == null)
            {
                com.Parameters.Add("@txtLand3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand3.Trim();
            }
            if (OBJWaltaApplDetails.txtLand4 == "" || OBJWaltaApplDetails.txtLand4 == null)
            {
                com.Parameters.Add("@txtLand4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand4.Trim();
            }
            if (OBJWaltaApplDetails.txtLand5 == "" || OBJWaltaApplDetails.txtLand5 == null)
            {
                com.Parameters.Add("@txtLand5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand5.Trim();
            }
            if (OBJWaltaApplDetails.txtLand6 == "" || OBJWaltaApplDetails.txtLand6 == null)
            {
                com.Parameters.Add("@txtLand6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand6.Trim();
            }
            if (OBJWaltaApplDetails.txtLand7 == "" || OBJWaltaApplDetails.txtLand7 == null)
            {
                com.Parameters.Add("@txtLand7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLand7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLand7.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding2 == "" || OBJWaltaApplDetails.txtBuilding2 == null)
            {
                com.Parameters.Add("@txtBuilding2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding2.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding3 == "" || OBJWaltaApplDetails.txtBuilding3 == null)
            {
                com.Parameters.Add("@txtBuilding3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding3.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding4 == "" || OBJWaltaApplDetails.txtBuilding4 == null)
            {
                com.Parameters.Add("@txtBuilding4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding4.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding5 == "" || OBJWaltaApplDetails.txtBuilding5 == null)
            {
                com.Parameters.Add("@txtBuilding5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding5.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding6 == "" || OBJWaltaApplDetails.txtBuilding6 == null)
            {
                com.Parameters.Add("@txtBuilding6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding6.Trim();
            }
            if (OBJWaltaApplDetails.txtBuilding7 == "" || OBJWaltaApplDetails.txtBuilding7 == null)
            {
                com.Parameters.Add("@txtBuilding7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuilding7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuilding7.Trim();
            }
            if (OBJWaltaApplDetails.txtPM2 == "" || OBJWaltaApplDetails.txtPM2 == null)
            {
                com.Parameters.Add("@txtPM2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM2.Trim();
            }
            if (OBJWaltaApplDetails.txtPM3 == "" || OBJWaltaApplDetails.txtPM3 == null)
            {
                com.Parameters.Add("@txtPM3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM3.Trim();
            }
            if (OBJWaltaApplDetails.txtPM4 == "" || OBJWaltaApplDetails.txtPM4 == null)
            {
                com.Parameters.Add("@txtPM4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM4.Trim();
            }
            if (OBJWaltaApplDetails.txtPM5 == "" || OBJWaltaApplDetails.txtPM5 == null)
            {
                com.Parameters.Add("@txtPM5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM5.Trim();
            }
            if (OBJWaltaApplDetails.txtPM6 == "" || OBJWaltaApplDetails.txtPM6 == null)
            {
                com.Parameters.Add("@txtPM6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM6.Trim();
            }
            if (OBJWaltaApplDetails.txtPM7 == "" || OBJWaltaApplDetails.txtPM7 == null)
            {
                com.Parameters.Add("@txtPM7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPM7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPM7.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont2 == "" || OBJWaltaApplDetails.txtMCont2 == null)
            {
                com.Parameters.Add("@txtMCont2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont2.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont3 == "" || OBJWaltaApplDetails.txtMCont3 == null)
            {
                com.Parameters.Add("@txtMCont3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont3.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont4 == "" || OBJWaltaApplDetails.txtMCont4 == null)
            {
                com.Parameters.Add("@txtMCont4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont4.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont5 == "" || OBJWaltaApplDetails.txtMCont5 == null)
            {
                com.Parameters.Add("@txtMCont5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont5.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont6 == "" || OBJWaltaApplDetails.txtMCont6 == null)
            {
                com.Parameters.Add("@txtMCont6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont6.Trim();
            }
            if (OBJWaltaApplDetails.txtMCont7 == "" || OBJWaltaApplDetails.txtMCont7 == null)
            {
                com.Parameters.Add("@txtMCont7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtMCont7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtMCont7.Trim();
            }
            if (OBJWaltaApplDetails.txtErec2 == "" || OBJWaltaApplDetails.txtErec2 == null)
            {
                com.Parameters.Add("@txtErec2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec2.Trim();
            }
            if (OBJWaltaApplDetails.txtErec3 == "" || OBJWaltaApplDetails.txtErec3 == null)
            {
                com.Parameters.Add("@txtErec3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec3.Trim();
            }
            if (OBJWaltaApplDetails.txtErec4 == "" || OBJWaltaApplDetails.txtErec4 == null)
            {
                com.Parameters.Add("@txtErec4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec4.Trim();
            }
            if (OBJWaltaApplDetails.txtErec5 == "" || OBJWaltaApplDetails.txtErec5 == null)
            {
                com.Parameters.Add("@txtErec5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec5.Trim();
            }
            if (OBJWaltaApplDetails.txtErec6 == "" || OBJWaltaApplDetails.txtErec6 == null)
            {
                com.Parameters.Add("@txtErec6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec6.Trim();
            }
            if (OBJWaltaApplDetails.txtErec7 == "" || OBJWaltaApplDetails.txtErec7 == null)
            {
                com.Parameters.Add("@txtErec7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtErec7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtErec7.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS2 == "" || OBJWaltaApplDetails.txtTFS2 == null)
            {
                com.Parameters.Add("@txtTFS2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS2.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS3 == "" || OBJWaltaApplDetails.txtTFS3 == null)
            {
                com.Parameters.Add("@txtTFS3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS3.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS4 == "" || OBJWaltaApplDetails.txtTFS4 == null)
            {
                com.Parameters.Add("@txtTFS4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS4.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS5 == "" || OBJWaltaApplDetails.txtTFS5 == null)
            {
                com.Parameters.Add("@txtTFS5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS5.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS6 == "" || OBJWaltaApplDetails.txtTFS6 == null)
            {
                com.Parameters.Add("@txtTFS6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS6.Trim();
            }
            if (OBJWaltaApplDetails.txtTFS7 == "" || OBJWaltaApplDetails.txtTFS7 == null)
            {
                com.Parameters.Add("@txtTFS7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTFS7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTFS7.Trim();
            }
            if (OBJWaltaApplDetails.txtWC2 == "" || OBJWaltaApplDetails.txtWC2 == null)
            {
                com.Parameters.Add("@txtWC2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC2.Trim();
            }
            if (OBJWaltaApplDetails.txtWC3 == "" || OBJWaltaApplDetails.txtWC3 == null)
            {
                com.Parameters.Add("@txtWC3", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC3", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC3.Trim();
            }
            if (OBJWaltaApplDetails.txtWC4 == "" || OBJWaltaApplDetails.txtWC4 == null)
            {
                com.Parameters.Add("@txtWC4", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC4", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC4.Trim();
            }
            if (OBJWaltaApplDetails.txtWC5 == "" || OBJWaltaApplDetails.txtWC5 == null)
            {
                com.Parameters.Add("@txtWC5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC5.Trim();
            }
            if (OBJWaltaApplDetails.txtWC6 == "" || OBJWaltaApplDetails.txtWC6 == null)
            {
                com.Parameters.Add("@txtWC6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC6.Trim();
            }
            if (OBJWaltaApplDetails.txtWC7 == "" || OBJWaltaApplDetails.txtWC7 == null)
            {
                com.Parameters.Add("@txtWC7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtWC7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtWC7.Trim();
            }
            if (OBJWaltaApplDetails.txtLandcostCompc == "" || OBJWaltaApplDetails.txtLandcostCompc == null)
            {
                com.Parameters.Add("@txtLandcostCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLandcostCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLandcostCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtLandAreaCompc == "" || OBJWaltaApplDetails.txtLandAreaCompc == null)
            {
                com.Parameters.Add("@txtLandAreaCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtLandAreaCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtLandAreaCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtPurchaCompc == "" || OBJWaltaApplDetails.txtPurchaCompc == null)
            {
                com.Parameters.Add("@txtPurchaCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPurchaCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPurchaCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtStmpDutyCompc == "" || OBJWaltaApplDetails.txtStmpDutyCompc == null)
            {
                com.Parameters.Add("@txtStmpDutyCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtStmpDutyCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtStmpDutyCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtRegnfeeCompc == "" || OBJWaltaApplDetails.txtRegnfeeCompc == null)
            {
                com.Parameters.Add("@txtRegnfeeCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtRegnfeeCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtRegnfeeCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtTotalCompc == "" || OBJWaltaApplDetails.txtTotalCompc == null)
            {
                com.Parameters.Add("@txtTotalCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTotalCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTotalCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtBuildingAreCompc == "" || OBJWaltaApplDetails.txtBuildingAreCompc == null)
            {
                com.Parameters.Add("@txtBuildingAreCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtBuildingAreCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtBuildingAreCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtvalDICCompc == "" || OBJWaltaApplDetails.txtvalDICCompc == null)
            {
                com.Parameters.Add("@txtvalDICCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalDICCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalDICCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtvalCompc1 == "" || OBJWaltaApplDetails.txtvalCompc1 == null)
            {
                com.Parameters.Add("@txtvalCompc1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalCompc1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalCompc1.Trim();
            }
            if (OBJWaltaApplDetails.txtresonsCompc == "" || OBJWaltaApplDetails.txtresonsCompc == null)
            {
                com.Parameters.Add("@txtresonsCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtresonsCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtresonsCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtfacCostCompc == "" || OBJWaltaApplDetails.txtfacCostCompc == null)
            {
                com.Parameters.Add("@txtfacCostCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtfacCostCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtfacCostCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtfacBldgCompc == "" || OBJWaltaApplDetails.txtfacBldgCompc == null)
            {
                com.Parameters.Add("@txtfacBldgCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtfacBldgCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtfacBldgCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtcivilEngCompc == "" || OBJWaltaApplDetails.txtcivilEngCompc == null)
            {
                com.Parameters.Add("@txtcivilEngCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtcivilEngCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtcivilEngCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtsfcCompc == "" || OBJWaltaApplDetails.txtsfcCompc == null)
            {
                com.Parameters.Add("@txtsfcCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtsfcCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtsfcCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtCAExpCompc == "" || OBJWaltaApplDetails.txtCAExpCompc == null)
            {
                com.Parameters.Add("@txtCAExpCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtCAExpCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtCAExpCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtCompvalCompc == "" || OBJWaltaApplDetails.txtCompvalCompc == null)
            {
                com.Parameters.Add("@txtCompvalCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtCompvalCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtCompvalCompc.Trim();
            }
            if (OBJWaltaApplDetails.txtrsnCompc == "" || OBJWaltaApplDetails.txtrsnCompc == null)
            {
                com.Parameters.Add("@txtrsnCompc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtrsnCompc", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtrsnCompc.Trim();
            }
            if (OBJWaltaApplDetails.TextBox30 == "" || OBJWaltaApplDetails.TextBox30 == null)
            {
                com.Parameters.Add("@TextBox30", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox30", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox30.Trim();
            }

            if (OBJWaltaApplDetails.TextBox32 == "" || OBJWaltaApplDetails.TextBox32 == null)
            {
                com.Parameters.Add("@TextBox32", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox32", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox32.Trim();
            }
            if (OBJWaltaApplDetails.TextBox31 == "" || OBJWaltaApplDetails.TextBox31 == null)
            {
                com.Parameters.Add("@TextBox31", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox31", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox31.Trim();
            }
            if (OBJWaltaApplDetails.TextBox34 == "" || OBJWaltaApplDetails.TextBox34 == null)
            {
                com.Parameters.Add("@TextBox34", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox34", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox34.Trim();
            }
            if (OBJWaltaApplDetails.TextBox36 == "" || OBJWaltaApplDetails.TextBox36 == null)
            {
                com.Parameters.Add("@TextBox36", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox36", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox36.Trim();
            }
            if (OBJWaltaApplDetails.TextBox38 == "" || OBJWaltaApplDetails.TextBox38 == null)
            {
                com.Parameters.Add("@TextBox38", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox38", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox38.Trim();
            }
            if (OBJWaltaApplDetails.TextBox40 == "" || OBJWaltaApplDetails.TextBox40 == null)
            {
                com.Parameters.Add("@TextBox40", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox40", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox40.Trim();
            }
            if (OBJWaltaApplDetails.TextBox42 == "" || OBJWaltaApplDetails.TextBox42 == null)
            {
                com.Parameters.Add("@TextBox42", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox42", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox42.Trim();
            }
            if (OBJWaltaApplDetails.TextBox47 == "" || OBJWaltaApplDetails.TextBox47 == null)
            {
                com.Parameters.Add("@TextBox47", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox47", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox47.Trim();
            }
            if (OBJWaltaApplDetails.TextBox33 == "" || OBJWaltaApplDetails.TextBox33 == null)
            {
                com.Parameters.Add("@TextBox33", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox33", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox33.Trim();
            }
            if (OBJWaltaApplDetails.TextBox37 == "" || OBJWaltaApplDetails.TextBox37 == null)
            {
                com.Parameters.Add("@TextBox37", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox37", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox37.Trim();
            }
            if (OBJWaltaApplDetails.TextBox41 == "" || OBJWaltaApplDetails.TextBox41 == null)
            {
                com.Parameters.Add("@TextBox41", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox41", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox41.Trim();
            }
            if (OBJWaltaApplDetails.TextBox44 == "" || OBJWaltaApplDetails.TextBox44 == null)
            {
                com.Parameters.Add("@TextBox44", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox44", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox44.Trim();
            }
            if (OBJWaltaApplDetails.TextBox1 == "" || OBJWaltaApplDetails.TextBox1 == null)
            {
                com.Parameters.Add("@TextBox1", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox1", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox1.Trim();
            }
            if (OBJWaltaApplDetails.TextBox56 == "" || OBJWaltaApplDetails.TextBox56 == null)
            {
                com.Parameters.Add("@TextBox56", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox56", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox56.Trim();
            }
            if (OBJWaltaApplDetails.TextBox57 == "" || OBJWaltaApplDetails.TextBox57 == null)
            {
                com.Parameters.Add("@TextBox57", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox57", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox57.Trim();
            }
            if (OBJWaltaApplDetails.TextBox58 == "" || OBJWaltaApplDetails.TextBox58 == null)
            {
                com.Parameters.Add("@TextBox58", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox58", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox58.Trim();
            }
            if (OBJWaltaApplDetails.TextBox45 == "" || OBJWaltaApplDetails.TextBox45 == null)
            {
                com.Parameters.Add("@TextBox45", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox45", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox45.Trim();
            }
            if (OBJWaltaApplDetails.TextBox2 == "" || OBJWaltaApplDetails.TextBox2 == null)
            {
                com.Parameters.Add("@TextBox2", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox2", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox2.Trim();
            }
            if (OBJWaltaApplDetails.TextBox35 == "" || OBJWaltaApplDetails.TextBox35 == null)
            {
                com.Parameters.Add("@TextBox35", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox35", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox35.Trim();
            }
            if (OBJWaltaApplDetails.TextBox39 == "" || OBJWaltaApplDetails.TextBox39 == null)
            {
                com.Parameters.Add("@TextBox39", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox39", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox39.Trim();
            }
            if (OBJWaltaApplDetails.TextBox43 == "" || OBJWaltaApplDetails.TextBox43 == null)
            {
                com.Parameters.Add("@TextBox43", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox43", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox43.Trim();
            }
            if (OBJWaltaApplDetails.TextBox46 == "" || OBJWaltaApplDetails.TextBox46 == null)
            {
                com.Parameters.Add("@TextBox46", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox46", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox46.Trim();
            }
            if (OBJWaltaApplDetails.TextBox48 == "" || OBJWaltaApplDetails.TextBox48 == null)
            {
                com.Parameters.Add("@TextBox48", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox48", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox48.Trim();
            }
            if (OBJWaltaApplDetails.txtContProdMgm == "" || OBJWaltaApplDetails.txtContProdMgm == null)
            {
                com.Parameters.Add("@txtContProdMgm", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtContProdMgm", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtContProdMgm.Trim();
            }
            if (OBJWaltaApplDetails.txt25BldgCvl == "" || OBJWaltaApplDetails.txt25BldgCvl == null)
            {
                com.Parameters.Add("@txt25BldgCvl", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt25BldgCvl", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt25BldgCvl.Trim();
            }
            if (OBJWaltaApplDetails.txt822guideline422 == "" || OBJWaltaApplDetails.txt822guideline422 == null)
            {
                com.Parameters.Add("@txt822guideline422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt822guideline422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt822guideline422.Trim();
            }
            if (OBJWaltaApplDetails.txtTSSFCnorms422 == "" || OBJWaltaApplDetails.txtTSSFCnorms422 == null)
            {
                com.Parameters.Add("@txtTSSFCnorms422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTSSFCnorms422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTSSFCnorms422.Trim();
            }
            if (OBJWaltaApplDetails.txtPlintharea424 == "" || OBJWaltaApplDetails.txtPlintharea424 == null)
            {
                com.Parameters.Add("@txtPlintharea424", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPlintharea424", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPlintharea424.Trim();
            }
            if (OBJWaltaApplDetails.txtPlintharea422 == "" || OBJWaltaApplDetails.txtPlintharea422 == null)
            {
                com.Parameters.Add("@txtPlintharea422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtPlintharea422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtPlintharea422.Trim();
            }
            if (OBJWaltaApplDetails.txtvalue422 == "" || OBJWaltaApplDetails.txtvalue422 == null)
            {
                com.Parameters.Add("@txtvalue422", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalue422", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalue422.Trim();
            }
            if (OBJWaltaApplDetails.TextBox59 == "" || OBJWaltaApplDetails.TextBox59 == null)
            {
                com.Parameters.Add("@TextBox59", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox59", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox59.Trim();
            }
            if (OBJWaltaApplDetails.txt423guideline == "" || OBJWaltaApplDetails.txt423guideline == null)
            {
                com.Parameters.Add("@txt423guideline", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txt423guideline", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txt423guideline.Trim();
            }
            if (OBJWaltaApplDetails.txtTSSFCnorms423 == "" || OBJWaltaApplDetails.txtTSSFCnorms423 == null)
            {
                com.Parameters.Add("@txtTSSFCnorms423", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtTSSFCnorms423", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtTSSFCnorms423.Trim();
            }
            if (OBJWaltaApplDetails.txtvalue424 == "" || OBJWaltaApplDetails.txtvalue424 == null)
            {
                com.Parameters.Add("@txtvalue424", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@txtvalue424", SqlDbType.VarChar).Value = OBJWaltaApplDetails.txtvalue424.Trim();
            }
            if (OBJWaltaApplDetails.created_by == "" || OBJWaltaApplDetails.created_by == null)
            {
                com.Parameters.Add("@created_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@created_by", SqlDbType.VarChar).Value = OBJWaltaApplDetails.created_by.Trim();
            }
            if (OBJWaltaApplDetails.incentiveid == "" || OBJWaltaApplDetails.incentiveid == null)
            {
                com.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = OBJWaltaApplDetails.incentiveid.Trim();
            }
            if (OBJWaltaApplDetails.TextBox60 == "" || OBJWaltaApplDetails.TextBox60 == null)
            {
                com.Parameters.Add("@TextBox60", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox60", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox60.Trim();
            }
            if (OBJWaltaApplDetails.TextBox5 == "" || OBJWaltaApplDetails.TextBox5 == null)
            {
                com.Parameters.Add("@TextBox5", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox5", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox5.Trim();
            }
            if (OBJWaltaApplDetails.TextBox7 == "" || OBJWaltaApplDetails.TextBox7 == null)
            {
                com.Parameters.Add("@TextBox7", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox7", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox7.Trim();
            }
            if (OBJWaltaApplDetails.TextBox9 == "" || OBJWaltaApplDetails.TextBox9 == null)
            {
                com.Parameters.Add("@TextBox9", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox9", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox9.Trim();
            }
            if (OBJWaltaApplDetails.TextBox11 == "" || OBJWaltaApplDetails.TextBox11 == null)
            {
                com.Parameters.Add("@TextBox11", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox11", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox11.Trim();
            }
            if (OBJWaltaApplDetails.TextBox13 == "" || OBJWaltaApplDetails.TextBox13 == null)
            {
                com.Parameters.Add("@TextBox13", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox13", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox13.Trim();
            }
            if (OBJWaltaApplDetails.TextBox15 == "" || OBJWaltaApplDetails.TextBox15 == null)
            {
                com.Parameters.Add("@TextBox15", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox15", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox15.Trim();
            }
            if (OBJWaltaApplDetails.TextBox17 == "" || OBJWaltaApplDetails.TextBox17 == null)
            {
                com.Parameters.Add("@TextBox17", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox17", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox17.Trim();
            }
            if (OBJWaltaApplDetails.TextBox18 == "" || OBJWaltaApplDetails.TextBox18 == null)
            {
                com.Parameters.Add("@TextBox18", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox18", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox18.Trim();
            }
            if (OBJWaltaApplDetails.TextBox19 == "" || OBJWaltaApplDetails.TextBox19 == null)
            {
                com.Parameters.Add("@TextBox19", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox19", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox19.Trim();
            }
            if (OBJWaltaApplDetails.TextBox61 == "" || OBJWaltaApplDetails.TextBox61 == null)
            {
                com.Parameters.Add("@TextBox61", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox61", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox61.Trim();
            }
            if (OBJWaltaApplDetails.TextBox6 == "" || OBJWaltaApplDetails.TextBox6 == null)
            {
                com.Parameters.Add("@TextBox6", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox6", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox6.Trim();
            }
            if (OBJWaltaApplDetails.TextBox8 == "" || OBJWaltaApplDetails.TextBox8 == null)
            {
                com.Parameters.Add("@TextBox8", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox8", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox8.Trim();
            }
            if (OBJWaltaApplDetails.TextBox10 == "" || OBJWaltaApplDetails.TextBox10 == null)
            {
                com.Parameters.Add("@TextBox10", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox10", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox10.Trim();
            }
            if (OBJWaltaApplDetails.TextBox12 == "" || OBJWaltaApplDetails.TextBox12 == null)
            {
                com.Parameters.Add("@TextBox12", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox12", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox12.Trim();
            }
            if (OBJWaltaApplDetails.TextBox14 == "" || OBJWaltaApplDetails.TextBox14 == null)
            {
                com.Parameters.Add("@TextBox14", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox14", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox14.Trim();
            }
            if (OBJWaltaApplDetails.TextBox16 == "" || OBJWaltaApplDetails.TextBox16 == null)
            {
                com.Parameters.Add("@TextBox16", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox16", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox16.Trim();
            }
            if (OBJWaltaApplDetails.TextBox20 == "" || OBJWaltaApplDetails.TextBox20 == null)
            {
                com.Parameters.Add("@TextBox20", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@TextBox20", SqlDbType.VarChar).Value = OBJWaltaApplDetails.TextBox20.Trim();
            }
            if (OBJWaltaApplDetails.MstIncentiveId == "" || OBJWaltaApplDetails.MstIncentiveId == null)
            {
                com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = OBJWaltaApplDetails.MstIncentiveId.Trim();
            }
            if (OBJWaltaApplDetails.Remarks == "" || OBJWaltaApplDetails.Remarks == null)
            {
                com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Remarks.Trim();
            }
            if (OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT == "" || OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT == null)
            {
                com.Parameters.Add("@ELIGIBLESANCTIONEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ELIGIBLESANCTIONEDAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ELIGIBLESANCTIONEDAMOUNT.Trim();
            }
            if (OBJWaltaApplDetails.CLAIMPERIODID == "" || OBJWaltaApplDetails.CLAIMPERIODID == null)
            {
                com.Parameters.Add("@CLAIMPERIODID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CLAIMPERIODID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.CLAIMPERIODID.Trim();
            }
            if (OBJWaltaApplDetails.CLAIMPERIOD == "" || OBJWaltaApplDetails.CLAIMPERIOD == null)
            {
                com.Parameters.Add("@CLAIMPERIOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CLAIMPERIOD", SqlDbType.VarChar).Value = OBJWaltaApplDetails.CLAIMPERIOD.Trim();
            }
            if (OBJWaltaApplDetails.DATEOFCOMMENCEMENTOFACTIVITY == null)
            {
                com.Parameters.Add("@DATEOFCOMMENCEMENTOFACTIVITY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@DATEOFCOMMENCEMENTOFACTIVITY", SqlDbType.VarChar).Value = OBJWaltaApplDetails.DATEOFCOMMENCEMENTOFACTIVITY;
            }
            if (OBJWaltaApplDetails.PERIODOFINSTALMENTID == "" || OBJWaltaApplDetails.PERIODOFINSTALMENTID == null)
            {
                com.Parameters.Add("@PERIODOFINSTALMENTID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PERIODOFINSTALMENTID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PERIODOFINSTALMENTID.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTPERIOD == "" || OBJWaltaApplDetails.INSTALMENTPERIOD == null)
            {
                com.Parameters.Add("@INSTALMENTPERIOD", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTPERIOD", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTPERIOD.Trim();
            }
            if (OBJWaltaApplDetails.NOOFINSTALMENTS == "" || OBJWaltaApplDetails.NOOFINSTALMENTS == null)
            {
                com.Parameters.Add("@NOOFINSTALMENTS", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NOOFINSTALMENTS", SqlDbType.VarChar).Value = OBJWaltaApplDetails.NOOFINSTALMENTS.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTAMOUNT == null)
            {
                com.Parameters.Add("@INSTALMENTAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTAMOUNT;
            }
            if (OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID == "" || OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID == null)
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_ID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_ID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_ID.Trim();
            }
            if (OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE == "" || OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE == null)
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_VALUE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INSTALMENTSTARTMONTHYEAR_VALUE", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INSTALMENTSTARTMONTHYEAR_VALUE.Trim();
            }
            if (OBJWaltaApplDetails.RATEOFINTEREST == "" || OBJWaltaApplDetails.RATEOFINTEREST == null)
            {
                com.Parameters.Add("@RATEOFINTEREST", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@RATEOFINTEREST", SqlDbType.VarChar).Value = OBJWaltaApplDetails.RATEOFINTEREST.Trim();
            }
            if (OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT == "" || OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT == null)
            {
                com.Parameters.Add("@ELIGIBLERATEOFREUMBERSEMENT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ELIGIBLERATEOFREUMBERSEMENT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ELIGIBLERATEOFREUMBERSEMENT.Trim();
            }
            if (OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED == "" || OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED == null)
            {
                com.Parameters.Add("@NOOFINSTALMENTS_COMPLETED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NOOFINSTALMENTS_COMPLETED", SqlDbType.VarChar).Value = OBJWaltaApplDetails.NOOFINSTALMENTS_COMPLETED.Trim();
            }
            if (OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR == "" || OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR == null)
            {
                com.Parameters.Add("@PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR.Trim();
            }
            if (OBJWaltaApplDetails.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS == null)
            {
                com.Parameters.Add("@INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS;
            }
            if (OBJWaltaApplDetails.ACTUALINTERESTAMOUNT_PAID == null)
            {
                com.Parameters.Add("@ACTUALINTERESTAMOUNT_PAID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ACTUALINTERESTAMOUNT_PAID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ACTUALINTERESTAMOUNT_PAID;
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED;
            }
            if (OBJWaltaApplDetails.ELIGIBLETYPE == "" || OBJWaltaApplDetails.ELIGIBLETYPE == null)
            {
                com.Parameters.Add("@ELIGIBLETYPE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ELIGIBLETYPE", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ELIGIBLETYPE.Trim();
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED_FINAL == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATED_FINAL;
            }
            if (OBJWaltaApplDetails.GMRECOMMENDEDAMOUNT == null)
            {
                com.Parameters.Add("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.GMRECOMMENDEDAMOUNT;
            }
            if (OBJWaltaApplDetails.FINALELIGIBLEAMOUNT == null)
            {
                com.Parameters.Add("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = OBJWaltaApplDetails.FINALELIGIBLEAMOUNT;
            }
            if (OBJWaltaApplDetails.modified_by == "" || OBJWaltaApplDetails.modified_by == null)
            {
                com.Parameters.Add("@modified_by", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@modified_by", SqlDbType.VarChar).Value = OBJWaltaApplDetails.modified_by.Trim();
            }
            if (OBJWaltaApplDetails.EglibleTypeID == "" || OBJWaltaApplDetails.EglibleTypeID == null)
            {
                com.Parameters.Add("@EglibleTypeID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@EglibleTypeID", SqlDbType.VarChar).Value = OBJWaltaApplDetails.EglibleTypeID.Trim();
            }
            if (OBJWaltaApplDetails.EglibleTypeName == "" || OBJWaltaApplDetails.EglibleTypeName == null)
            {
                com.Parameters.Add("@EglibleTypeName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@EglibleTypeName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.EglibleTypeName.Trim();
            }
            if (OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype == null)
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATEDaftereglibletype", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@INTERESTREIMBURSEMENTCALCULATEDaftereglibletype", SqlDbType.VarChar).Value = OBJWaltaApplDetails.INTERESTREIMBURSEMENTCALCULATEDaftereglibletype;
            }
            if (OBJWaltaApplDetails.PERIODOFINSTALMENTName == "" || OBJWaltaApplDetails.PERIODOFINSTALMENTName == null)
            {
                com.Parameters.Add("@PERIODOFINSTALMENTName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PERIODOFINSTALMENTName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.PERIODOFINSTALMENTName.Trim();
            }
            if (OBJWaltaApplDetails.Noofclaimperiods == null)
            {
                com.Parameters.Add("@Noofclaimperiods", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Noofclaimperiods", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Noofclaimperiods;
            }
            if (OBJWaltaApplDetails.createdIP == "" || OBJWaltaApplDetails.createdIP == null)
            {
                com.Parameters.Add("@createdIP", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@createdIP", SqlDbType.VarChar).Value = OBJWaltaApplDetails.createdIP.Trim();
            }
            if (OBJWaltaApplDetails.ModifiedIP == "" || OBJWaltaApplDetails.ModifiedIP == null)
            {
                com.Parameters.Add("@ModifiedIP", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ModifiedIP", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ModifiedIP.Trim();
            }
            if (OBJWaltaApplDetails.Conreburismentamount == null)
            {
                com.Parameters.Add("@Conreburismentamount", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Conreburismentamount", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Conreburismentamount;
            }

            
            if (OBJWaltaApplDetails.Scheme == "" || OBJWaltaApplDetails.Scheme == null)
            {
                com.Parameters.Add("@Scheme", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Scheme", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Scheme.Trim();
            }
            if (OBJWaltaApplDetails.Yrsfrmdcpdate == null)
            {
                com.Parameters.Add("@Yrsfrmdcpdate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Yrsfrmdcpdate", SqlDbType.VarChar).Value = OBJWaltaApplDetails.Yrsfrmdcpdate;
            }
            if (OBJWaltaApplDetails.caste_IR != null)
                com.Parameters.AddWithValue("@caste_IR", OBJWaltaApplDetails.caste_IR);
            if (OBJWaltaApplDetails.gender_IR != null)
                com.Parameters.AddWithValue("@gender_IR", OBJWaltaApplDetails.gender_IR);
            if (OBJWaltaApplDetails.category_IR != null)
                com.Parameters.AddWithValue("@category_IR", OBJWaltaApplDetails.category_IR);
            if (OBJWaltaApplDetails.enterprisetype_IR != null)
                com.Parameters.AddWithValue("@enterprise_IR", OBJWaltaApplDetails.enterprisetype_IR);
            if (OBJWaltaApplDetails.sector_IR != null)
                com.Parameters.AddWithValue("@sector_IR", OBJWaltaApplDetails.sector_IR);
            if (OBJWaltaApplDetails.servicetype_IR != null)
                com.Parameters.AddWithValue("@serviceType_IR", OBJWaltaApplDetails.servicetype_IR);
            if (OBJWaltaApplDetails.transNonTrans_IR != null)
                com.Parameters.AddWithValue("@transportNonTrans_IR", OBJWaltaApplDetails.transNonTrans_IR);

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


    public string INSERT_PAVALLAVADDICLAIMLOANCOUNT(Pallavaddiclaimloanproperties OBJPallavaddiclaimloanproperties)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("PV_insertpallavaddiclaimloancount", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();
            if (OBJPallavaddiclaimloanproperties.Incentiveid == null)
            {
                com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.Incentiveid;
            }
            if (OBJPallavaddiclaimloanproperties.APCDPVID == null)
            {
                com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@APCDPVID", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.APCDPVID;
            }
            if (OBJPallavaddiclaimloanproperties.ClaimPeriodID == "" || OBJPallavaddiclaimloanproperties.ClaimPeriodID == null)
            {
                com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ClaimPeriodID", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.ClaimPeriodID.Trim();
            }
            if (OBJPallavaddiclaimloanproperties.ClaimPeriodName == "" || OBJPallavaddiclaimloanproperties.ClaimPeriodName == null)
            {
                com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ClaimPeriodName", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.ClaimPeriodName.Trim();
            }
            if (OBJPallavaddiclaimloanproperties.@LoanCount == null)
            {
                com.Parameters.Add("@LoanCount", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@LoanCount", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.LoanCount;
            }
            if (OBJPallavaddiclaimloanproperties.Createdby == "" || OBJPallavaddiclaimloanproperties.Createdby == null)
            {
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.Createdby.Trim();
            }
            if (OBJPallavaddiclaimloanproperties.CreatedIP == "" || OBJPallavaddiclaimloanproperties.CreatedIP == null)
            {
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.CreatedIP.Trim();
            }
            if (OBJPallavaddiclaimloanproperties.FinancialYear == "" || OBJPallavaddiclaimloanproperties.FinancialYear == null)
            {
                com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value = OBJPallavaddiclaimloanproperties.FinancialYear.Trim();
            }


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

    public string INSERT_PAVALLAVADDICLAIMPERIODLOANDETAILS(pallavaddiclaimLoandetailsproperties OBJPVclaimLoandetailsproperties)
    {
        int valid = 0;
        string resp = "";
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand com = new SqlCommand("PV_insertpallavaddiClaimloanFyDetails", connection);
        com.CommandType = CommandType.StoredProcedure;
        com.Transaction = transaction;
        try
        {
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = DBNull.Value;
            //com.Parameters.Add("@ApplicationType_IndusorAgriName", SqlDbType.VarChar).Value = OBJWaltaApplDetails.ApplicationType_IndusorAgriName.Trim();

            //if (OBJPVclaimLoandetailsproperties.incapplnno == "" || OBJPVclaimLoandetailsproperties.incapplnno == null)
            //{
            //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = DBNull.Value;
            //}
            //else
            //{
            //    com.Parameters.Add("@incapplnno", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.incapplnno.Trim();
            //}

            if (OBJPVclaimLoandetailsproperties.Incentiveid== null)
            {
                com.Parameters.Add("@Incentiveid",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@Incentiveid", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Incentiveid; 
            }

            if (OBJPVclaimLoandetailsproperties.APCDPVID== null)
            { 
                com.Parameters.Add("@APCDPVID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@APCDPVID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.APCDPVID; 
            }

            if (OBJPVclaimLoandetailsproperties.ClaimPeriodID== "" || OBJPVclaimLoandetailsproperties.ClaimPeriodID== null)
            { 
                com.Parameters.Add("@ClaimPeriodID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@ClaimPeriodID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.ClaimPeriodName== "" || OBJPVclaimLoandetailsproperties.ClaimPeriodName== null)
            { 
                com.Parameters.Add("@ClaimPeriodName",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@ClaimPeriodName",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodName.Trim();
            }
            if (OBJPVclaimLoandetailsproperties.LoanNumber== null)
            { 
                com.Parameters.Add("@LoanNumber",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            {
                com.Parameters.Add("@LoanNumber", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.LoanNumber;
            }
            if (OBJPVclaimLoandetailsproperties.ClaimPeriodFYID== "" || OBJPVclaimLoandetailsproperties.ClaimPeriodFYID== null)
            { 
                com.Parameters.Add("@ClaimPeriodFYID",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            { 
                com.Parameters.Add("@ClaimPeriodFYID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodFYID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID== "" || OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID== null)
            { 
                com.Parameters.Add("@ClaimPeriodFYSubID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@ClaimPeriodFYSubID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ClaimPeriodFYSubID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.IS1st2dhalfyear== "" || OBJPVclaimLoandetailsproperties.IS1st2dhalfyear== null)
            { 
                com.Parameters.Add("@IS1st2dhalfyear",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@IS1st2dhalfyear",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IS1st2dhalfyear.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.dcpdate== null)
            {
                com.Parameters.Add("@dcpdate", SqlDbType.DateTime).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@dcpdate", SqlDbType.DateTime).Value = OBJPVclaimLoandetailsproperties.dcpdate; 
            }
            if (OBJPVclaimLoandetailsproperties.loaninstallmentstartdate== null)
            {
                com.Parameters.Add("@loaninstallmentstartdate", SqlDbType.DateTime).Value = DBNull.Value; 
            }
            else 
            {
                com.Parameters.Add("@loaninstallmentstartdate", SqlDbType.DateTime).Value = OBJPVclaimLoandetailsproperties.loaninstallmentstartdate;
            }
            if (OBJPVclaimLoandetailsproperties.tottermloanavil== null)
            { 
                com.Parameters.Add("@tottermloanavil",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@tottermloanavil",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.tottermloanavil;
            }
            if (OBJPVclaimLoandetailsproperties.Periodofinstallmentid== "" || OBJPVclaimLoandetailsproperties.Periodofinstallmentid== null)
            { 
                com.Parameters.Add("@Periodofinstallmentid",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@Periodofinstallmentid",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Periodofinstallmentid.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.Periodofinstallmentname== "" || OBJPVclaimLoandetailsproperties.Periodofinstallmentname== null)
            { 
                com.Parameters.Add("@Periodofinstallmentname",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@Periodofinstallmentname",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Periodofinstallmentname.Trim();
            }
            if (OBJPVclaimLoandetailsproperties.Noofinstallmentforloan== null)
            { 
                com.Parameters.Add("@Noofinstallmentforloan",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@Noofinstallmentforloan", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Noofinstallmentforloan; 
            }
            if (OBJPVclaimLoandetailsproperties.Installmentamountforloan== null)
            { 
                com.Parameters.Add("@Installmentamountforloan",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@Installmentamountforloan",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Installmentamountforloan; 
            }



            if (OBJPVclaimLoandetailsproperties.Rateofinterestforloan == null)
            {
                com.Parameters.Add("@Rateofinterestforloan", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Rateofinterestforloan", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Rateofinterestforloan;
            }
            if (OBJPVclaimLoandetailsproperties.Eligibleratereimbursementforlaon== null)
            { 
                com.Parameters.Add("@Eligibleratereimbursementforlaon",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@Eligibleratereimbursementforlaon",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Eligibleratereimbursementforlaon;
            }
            if (OBJPVclaimLoandetailsproperties.NoofinstallmentcompletedfortheloanFY== null)
            { 
                com.Parameters.Add("@NoofinstallmentcompletedfortheloanFY",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            { 
                com.Parameters.Add("@NoofinstallmentcompletedfortheloanFY", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofinstallmentcompletedfortheloanFY;
            }
            if (OBJPVclaimLoandetailsproperties.principalamountdueforhalfyrFY== null)
            {
                com.Parameters.Add("@principalamountdueforhalfyrFY",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@principalamountdueforhalfyrFY",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.principalamountdueforhalfyrFY;
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth1ID",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            { 
                com.Parameters.Add("@PeriodofClaimMonth1ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth1Name",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@PeriodofClaimMonth1Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth1Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth1== null)
            { 
                com.Parameters.Add("@PrincipalamountdueMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@PrincipalamountdueMonth1",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth1;
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth1== null)
            {
                com.Parameters.Add("@NoofInstallmentMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@NoofInstallmentMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth1; 
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth1== null)
            { 
                com.Parameters.Add("@rateofinterestMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth1", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth1; 
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth1== null)
            { 
                com.Parameters.Add("@interestamountMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@interestamountMonth1",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth1; 
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth1== null)
            {
                com.Parameters.Add("@unitholdercontMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@unitholdercontMonth1",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth1;
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth1== null)
            {
                com.Parameters.Add("@eligiblerateofintersetMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth1",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth1;
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth1== null)
            {
                com.Parameters.Add("@eligibleinterestamountMonth1",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligibleinterestamountMonth1",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth1; 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth2ID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PeriodofClaimMonth2ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth2Name",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PeriodofClaimMonth2Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth2Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth2== null)
            { com.Parameters.Add("@PrincipalamountdueMonth2",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PrincipalamountdueMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth2; 
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth2== null)
            { 
                com.Parameters.Add("@NoofInstallmentMonth2",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@NoofInstallmentMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth2;
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth2== null)
            { 
                com.Parameters.Add("@rateofinterestMonth2",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth2; 
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth2== null)
            { 
                com.Parameters.Add("@interestamountMonth2",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@interestamountMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth2;
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth2== null)
            {
                com.Parameters.Add("@unitholdercontMonth2",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@unitholdercontMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth2;
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth2== null)
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth2",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth2; 
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth2== null)
            {
                com.Parameters.Add("@eligibleinterestamountMonth2",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@eligibleinterestamountMonth2",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth2;
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth3ID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@PeriodofClaimMonth3ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name== null)
            {
                com.Parameters.Add("@PeriodofClaimMonth3Name",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            {
                com.Parameters.Add("@PeriodofClaimMonth3Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth3Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth3== null)
            { 
                com.Parameters.Add("@PrincipalamountdueMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PrincipalamountdueMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth3== null)
            {
                com.Parameters.Add("@NoofInstallmentMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@NoofInstallmentMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth3== null)
            { 
                com.Parameters.Add("@rateofinterestMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth3== null)
            {
                com.Parameters.Add("@interestamountMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@interestamountMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth3== null)
            {
                com.Parameters.Add("@unitholdercontMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@unitholdercontMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth3== null)
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth3;
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth3== null)
            { 
                com.Parameters.Add("@eligibleinterestamountMonth3",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@eligibleinterestamountMonth3",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth3; 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth4ID",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@PeriodofClaimMonth4ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth4Name",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@PeriodofClaimMonth4Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth4Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth4== null)
            { 
                com.Parameters.Add("@PrincipalamountdueMonth4",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PrincipalamountdueMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth4; 
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth4== null)
            { 
                com.Parameters.Add("@NoofInstallmentMonth4",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@NoofInstallmentMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth4; 
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth4== null)
            { 
                com.Parameters.Add("@rateofinterestMonth4",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth4;
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth4== null)
            { 
                com.Parameters.Add("@interestamountMonth4",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@interestamountMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth4;
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth4== null)
            {
                com.Parameters.Add("@unitholdercontMonth4",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            {
                com.Parameters.Add("@unitholdercontMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth4; 
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth4== null)
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth4",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth4; 
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth4== null)
            { 
                com.Parameters.Add("@eligibleinterestamountMonth4",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligibleinterestamountMonth4",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth4;
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth5ID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PeriodofClaimMonth5ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth5Name",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PeriodofClaimMonth5Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth5Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth5== null)
            { 
                com.Parameters.Add("@PrincipalamountdueMonth5",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@PrincipalamountdueMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth5;
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth5== null)
            { 
                com.Parameters.Add("@NoofInstallmentMonth5",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NoofInstallmentMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth5== null)
            { 
                com.Parameters.Add("@rateofinterestMonth5",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth5== null)
            { 
                com.Parameters.Add("@interestamountMonth5",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@interestamountMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth5== null)
            { 
                com.Parameters.Add("@unitholdercontMonth5",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@unitholdercontMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth5== null)
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth5",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth5== null)
            {
                com.Parameters.Add("@eligibleinterestamountMonth5",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@eligibleinterestamountMonth5",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth5; 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID== null)
            {
                com.Parameters.Add("@PeriodofClaimMonth6ID",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@PeriodofClaimMonth6ID",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6ID.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name== "" || OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name== null)
            { 
                com.Parameters.Add("@PeriodofClaimMonth6Name",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@PeriodofClaimMonth6Name",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PeriodofClaimMonth6Name.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth6== null)
            { 
                com.Parameters.Add("@PrincipalamountdueMonth6",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@PrincipalamountdueMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.PrincipalamountdueMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.NoofInstallmentMonth6== null)
            { 
                com.Parameters.Add("@NoofInstallmentMonth6",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@NoofInstallmentMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofInstallmentMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.rateofinterestMonth6== null)
            { 
                com.Parameters.Add("@rateofinterestMonth6",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@rateofinterestMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.rateofinterestMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.interestamountMonth6== null)
            {
                com.Parameters.Add("@interestamountMonth6",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@interestamountMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.interestamountMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.unitholdercontMonth6== null)
            { 
                com.Parameters.Add("@unitholdercontMonth6",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@unitholdercontMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.unitholdercontMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth6== null)
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth6",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligiblerateofintersetMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligiblerateofintersetMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth6== null)
            { 
                com.Parameters.Add("@eligibleinterestamountMonth6",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@eligibleinterestamountMonth6",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleinterestamountMonth6; 
            }
            if (OBJPVclaimLoandetailsproperties.totmonthseligibleinterestamount== null)
            { 
                com.Parameters.Add("@totmonthseligibleinterestamount",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@totmonthseligibleinterestamount",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totmonthseligibleinterestamount; 
            }
            if (OBJPVclaimLoandetailsproperties.totmonthsinterestamountMonth== null)
            { 
                com.Parameters.Add("@totmonthsinterestamountMonth",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@totmonthsinterestamountMonth",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totmonthsinterestamountMonth; 
            }
            if (OBJPVclaimLoandetailsproperties.eligibleperiodinmonths== null)
            { 
                com.Parameters.Add("@eligibleperiodinmonths",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@eligibleperiodinmonths",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.eligibleperiodinmonths; 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_interestamountpaidaspercal== null)
            { 
                com.Parameters.Add("@CPL_interestamountpaidaspercal",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CPL_interestamountpaidaspercal",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestamountpaidaspercal; 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_actualinterestamountpaid== null)
            { 
                com.Parameters.Add("@CPL_actualinterestamountpaid",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CPL_actualinterestamountpaid",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_actualinterestamountpaid; 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_Conamountforcalintreimberest== null)
            { 
                com.Parameters.Add("@CPL_Conamountforcalintreimberest",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            { 
                com.Parameters.Add("@CPL_Conamountforcalintreimberest",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_Conamountforcalintreimberest; 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal== null)
            { 
                com.Parameters.Add("@CPL_interestreimbersementcal",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CPL_interestreimbersementcal",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal; 
            }

            if (OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE== "" || OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE== null)
            { 
                com.Parameters.Add("@CPL_ELIGIBLETYPE",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@CPL_ELIGIBLETYPE",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPE.Trim();
            }
            if (OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName== "" || OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName== null)
            { 
                com.Parameters.Add("@CPL_ELIGIBLETYPEName",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            {
                com.Parameters.Add("@CPL_ELIGIBLETYPEName",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_ELIGIBLETYPEName.Trim();
            }
            if (OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype== "" || OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype== null)
            { 
                com.Parameters.Add("@CPL_interestreimbersementcal_finaleligibletype",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CPL_interestreimbersementcal_finaleligibletype",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_interestreimbersementcal_finaleligibletype.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_gmrecommendedamount== null)
            { 
                com.Parameters.Add("@CPL_gmrecommendedamount",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CPL_gmrecommendedamount",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_gmrecommendedamount; 
            }
            if (OBJPVclaimLoandetailsproperties.CPL_FINALELIGIBLEAMOUNT== null)
            { 
                com.Parameters.Add("@CPL_FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@CPL_FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CPL_FINALELIGIBLEAMOUNT; 
            }
            if (OBJPVclaimLoandetailsproperties.totince_interestamountpaidaspercal== null)
            {
                com.Parameters.Add("@totince_interestamountpaidaspercal",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@totince_interestamountpaidaspercal",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestamountpaidaspercal; 
            }
            if (OBJPVclaimLoandetailsproperties.totince_actualinterestamountpaid== null)
            {
                com.Parameters.Add("@totince_actualinterestamountpaid",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@totince_actualinterestamountpaid",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_actualinterestamountpaid; 
            }
            if (OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal== null)
            { 
                com.Parameters.Add("@totince_interestreimbersementcal",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else 
            { 
                com.Parameters.Add("@totince_interestreimbersementcal",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal; 
            }
            if (OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype== "" || OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype== null)
            { 
                com.Parameters.Add("@totince_interestreimbersementcal_finaleligibletype",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@totince_interestreimbersementcal_finaleligibletype",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_interestreimbersementcal_finaleligibletype.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.totince_gmrecommendedamount== null)
            {
                com.Parameters.Add("@totince_gmrecommendedamount",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                com.Parameters.Add("@totince_gmrecommendedamount",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_gmrecommendedamount;
            }
            if (OBJPVclaimLoandetailsproperties.totince_FINALELIGIBLEAMOUNT== null)
            { 
                com.Parameters.Add("@totince_FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else 
            { 
                com.Parameters.Add("@totince_FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_FINALELIGIBLEAMOUNT;
            }
            if (OBJPVclaimLoandetailsproperties.Createdby== "" || OBJPVclaimLoandetailsproperties.Createdby== null)
            {
                com.Parameters.Add("@Createdby",SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            { 
                com.Parameters.Add("@Createdby",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Createdby.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.CreatedIP== "" || OBJPVclaimLoandetailsproperties.CreatedIP== null)
            { 
                com.Parameters.Add("@CreatedIP",SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            { 
                com.Parameters.Add("@CreatedIP",SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.CreatedIP.Trim(); 
            }
            if (OBJPVclaimLoandetailsproperties.totince_Conamountforcalintreimberest == null) 
            { 
                com.Parameters.Add("@totince_Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value; 
            } 
            else
            { 
                com.Parameters.Add("@totince_Conamountforcalintreimberest", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.totince_Conamountforcalintreimberest; 
            }

            if (OBJPVclaimLoandetailsproperties.IsMortage == null)
            {
                com.Parameters.Add("@IsMortage", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@IsMortage", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IsMortage;
            }

            if (OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompleted == null)
            {
                com.Parameters.Add("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompleted;
            }

            if (OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompletedMonths == null)
            {
                com.Parameters.Add("@ActualNoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@ActualNoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.ActualNoofinstallmentsCompletedMonths;
            }
            if (OBJPVclaimLoandetailsproperties.Actualprincipalamtfornextyrs == null)
            {
                com.Parameters.Add("@Actualprincipalamtfornextyrs", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Actualprincipalamtfornextyrs", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Actualprincipalamtfornextyrs;
            }
            if (OBJPVclaimLoandetailsproperties.NoofinstallmentsCompletedMonths == null)
            {
                com.Parameters.Add("@NoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@NoofinstallmentsCompletedMonths", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.NoofinstallmentsCompletedMonths;
            }
            if (OBJPVclaimLoandetailsproperties.IsprevMoratorium == null)
            {
                com.Parameters.Add("@IsprevMoratorium", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@IsprevMoratorium", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.IsprevMoratorium;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowone == null)
            {
                com.Parameters.Add("@Moratoriumrowone", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowone", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowone;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowtwo == null)
            {
                com.Parameters.Add("@Moratoriumrowtwo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowtwo", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowtwo;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowthree == null)
            {
                com.Parameters.Add("@Moratoriumrowthree", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowthree", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowthree;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowfour == null)
            {
                com.Parameters.Add("@Moratoriumrowfour", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowfour", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowfour;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowfive == null)
            {
                com.Parameters.Add("@Moratoriumrowfive", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowfive", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowfive;
            }
            if (OBJPVclaimLoandetailsproperties.Moratoriumrowsix == null)
            {
                com.Parameters.Add("@Moratoriumrowsix", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                com.Parameters.Add("@Moratoriumrowsix", SqlDbType.VarChar).Value = OBJPVclaimLoandetailsproperties.Moratoriumrowsix;
            }
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

    public bool DB_INSERTPVCALIMSDATALOAN(pallavadisubproperties objgriduploads)
    {
        SqlConnection connection = new SqlConnection(strConnectionString);
        SqlTransaction transaction = null;
        bool retValue = false;
        try
        {
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdpacd = new SqlCommand("PV_insertpallavaddiclaimsbyloansid", connection);
            cmdpacd.CommandType = CommandType.StoredProcedure;
            cmdpacd.Transaction = transaction;

            //if (objgriduploads.INCENTIVEID == "" || objgriduploads.INCENTIVEID == null)
            //{
            //    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INCENTIVEID);
            //}


            if (objgriduploads.INCENTIVEID== "" || objgriduploads.INCENTIVEID== null)
            { 
                cmdpacd.Parameters.AddWithValue("@INCENTIVEID", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INCENTIVEID",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INCENTIVEID);
            }
            if (objgriduploads.CLAIMPERIOD_Grid == "" || objgriduploads.CLAIMPERIOD_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIOD_Grid);
            }
            if (objgriduploads.PERIODOFINSTALMENT_MAINTABLE == "" || objgriduploads.PERIODOFINSTALMENT_MAINTABLE == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFINSTALMENT_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFINSTALMENT_MAINTABLE);
            }
            if (objgriduploads.NOOFINSTALLMENTS_MAINTABLE == "" || objgriduploads.NOOFINSTALLMENTS_MAINTABLE == null)
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENTS_MAINTABLE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENTS_MAINTABLE);
            }
            if (objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == "" || objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALMENTSCOMPLETED_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALMENTSCOMPLETED_Grid);
            }
            if (objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_ID_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_ID_GRID);
            }
            if (objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == "" || objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID == null)
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PERIODOFCLAIM_MONTHWISE_VALUE_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PERIODOFCLAIM_MONTHWISE_VALUE_GRID);
            }
            if (objgriduploads.PRINCIPALAMOUNTDUE_GRID== null)
            {
                cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PRINCIPALAMOUNTDUE_GRID",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PRINCIPALAMOUNTDUE_GRID);
            }
            if (objgriduploads.NOOFINSTALLMENT_GRID== "" || objgriduploads.NOOFINSTALLMENT_GRID== null)
            { 
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@NOOFINSTALLMENT_GRID",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.NOOFINSTALLMENT_GRID);
            }
            if (objgriduploads.INTERESTAMOUNT_GRID== null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNT_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNT_GRID); 
            }
            if (objgriduploads.InstallmentAmount== null)
            {
                cmdpacd.Parameters.AddWithValue("@InstallmentAmount", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@InstallmentAmount",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.InstallmentAmount); 
            }
            if (objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID== null)
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID); 
            }
            if (objgriduploads.ACTUALINTERESTAMOUNTPAID == null)
            {
                cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ACTUALINTERESTAMOUNTPAID", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ACTUALINTERESTAMOUNTPAID);
            }
            if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED== null)
            { 
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED); 
            }
            if (objgriduploads.ELIGIBLETYPE== "" || objgriduploads.ELIGIBLETYPE== null)
            { 
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPE", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPE); 
            }
            if (objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL== null)
            { 
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@INTERESTREIMBERSEMENTCALCULATED_FINAL",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.INTERESTREIMBERSEMENTCALCULATED_FINAL);
            }
            if (objgriduploads.GMRECOMMENDEDAMOUNT== null)
            { 
                cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@GMRECOMMENDEDAMOUNT", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.GMRECOMMENDEDAMOUNT); 
            }
            if (objgriduploads.FINALELIGIBLEAMOUNT== null)
            { 
                cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.FINALELIGIBLEAMOUNT); 
            }
            if (objgriduploads.IPADDRESS== "" || objgriduploads.IPADDRESS== null)
            { 
                cmdpacd.Parameters.AddWithValue("@IPADDRESS", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@IPADDRESS",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IPADDRESS); 
            }
            if (objgriduploads.CREATED_BY == "" || objgriduploads.CREATED_BY == null)
            {
                cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CREATED_BY", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CREATED_BY);
            }
            if (objgriduploads.interestegliblereimbursement== null)
            { 
                cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@interestegliblereimbursement",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.interestegliblereimbursement); 
            }
            if (objgriduploads.SUBPallvaid== null)
            { 
                cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@SUBPallvaid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.SUBPallvaid); 
            }
            if (objgriduploads.CLAIMPERIODName_Grid == "" || objgriduploads.CLAIMPERIODName_Grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CLAIMPERIODName_Grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CLAIMPERIODName_Grid);
            }
            if (objgriduploads.PeriodofinstallmentName== "" || objgriduploads.PeriodofinstallmentName== null)
            { cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PeriodofinstallmentName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PeriodofinstallmentName); 
            }
            if (objgriduploads.principalamountduefornexthalfyr_grid == null)
            {
                cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@principalamountduefornexthalfyr_grid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.principalamountduefornexthalfyr_grid);
            }
            if (objgriduploads.ELIGIBLETYPEName== "" || objgriduploads.ELIGIBLETYPEName== null)
            { 
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ELIGIBLETYPEName", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ELIGIBLETYPEName); 
            }
            if (objgriduploads.eligibleperiodinmonths== null)
            { 
                cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@eligibleperiodinmonths",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligibleperiodinmonths); 
            }
            if (objgriduploads.dcpdate== null)
            {
                cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@dcpdate", SqlDbType.DateTime).Value = objgriduploads.dcpdate; 
            }
            if (objgriduploads.installmentstartmonthyear== "" || objgriduploads.installmentstartmonthyear== null)
            { 
                cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@installmentstartmonthyear",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.installmentstartmonthyear); 
            }
            if (objgriduploads.LoanNumber== null){ cmdpacd.Parameters.AddWithValue("@LoanNumber", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@LoanNumber", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.LoanNumber); 
            }
            if (objgriduploads.unitholdercont== null)
            { 
                cmdpacd.Parameters.AddWithValue("@unitholdercont", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@unitholdercont",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.unitholdercont); 
            }
            if (objgriduploads.eligiblerateofinterset== null)
            { 
                cmdpacd.Parameters.AddWithValue("@eligiblerateofinterset", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@eligiblerateofinterset",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligiblerateofinterset); 
            }
            if (objgriduploads.eligibleinterestamount== null)
            { 
                cmdpacd.Parameters.AddWithValue("@eligibleinterestamount", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@eligibleinterestamount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.eligibleinterestamount); 
            }
            if (objgriduploads.CPL_interestamountpaidaspercal== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_interestamountpaidaspercal", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_interestamountpaidaspercal",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestamountpaidaspercal); 
            }
            if (objgriduploads.CPL_actualinterestamountpaid== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_actualinterestamountpaid", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_actualinterestamountpaid); 
            }
            if (objgriduploads.CPL_Conamountforcalintreimberest== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_Conamountforcalintreimberest",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_Conamountforcalintreimberest); 
            }
            if (objgriduploads.CPL_interestreimbersementcal== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestreimbersementcal); 
            }
            if (objgriduploads.CPL_interestreimbersementcal_finaleligibletype== "" || objgriduploads.CPL_interestreimbersementcal_finaleligibletype== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal_finaleligibletype", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_interestreimbersementcal_finaleligibletype",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_interestreimbersementcal_finaleligibletype); 
            }
            if (objgriduploads.CPL_gmrecommendedamount== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_gmrecommendedamount", SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_gmrecommendedamount);
            }
            if (objgriduploads.CPL_FINALELIGIBLEAMOUNT== null)
            { 
                cmdpacd.Parameters.AddWithValue("@CPL_FINALELIGIBLEAMOUNT", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@CPL_FINALELIGIBLEAMOUNT",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.CPL_FINALELIGIBLEAMOUNT); 
            }
            if (objgriduploads.Conamountforcalintreimberest== null)
            { 
                cmdpacd.Parameters.AddWithValue("@Conamountforcalintreimberest", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Conamountforcalintreimberest",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Conamountforcalintreimberest); 
            }
            if (objgriduploads.PVCPLHFID== null)
            { 
                cmdpacd.Parameters.AddWithValue("@PVCPLHFID", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@PVCPLHFID",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.PVCPLHFID); 
            }
            if (objgriduploads.IsMortage== "" || objgriduploads.IsMortage== null)
            { 
                cmdpacd.Parameters.AddWithValue("@IsMortage", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@IsMortage",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.IsMortage); 
            }
            if (objgriduploads.ActualNoofinstallmentsCompleted== null)
            { 
                cmdpacd.Parameters.AddWithValue("@ActualNoofinstallmentsCompleted", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@ActualNoofinstallmentsCompleted",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.ActualNoofinstallmentsCompleted); 
            }
            if (objgriduploads.tottermloanavil== null)
            { 
                cmdpacd.Parameters.AddWithValue("@tottermloanavil", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@tottermloanavil",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.tottermloanavil); 
            }
            if (objgriduploads.totmonthseligibleinterestamount== null)
            { 
                cmdpacd.Parameters.AddWithValue("@totmonthseligibleinterestamount", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@totmonthseligibleinterestamount",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.totmonthseligibleinterestamount); 
            }
            if (objgriduploads.totmonthsinterestamountMonth== null)
            { 
                cmdpacd.Parameters.AddWithValue("@totmonthsinterestamountMonth", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@totmonthsinterestamountMonth",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.totmonthsinterestamountMonth); 
            }
            if (objgriduploads.Rateofinterestforloan== null)
            { 
                cmdpacd.Parameters.AddWithValue("@Rateofinterestforloan", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Rateofinterestforloan",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Rateofinterestforloan); 
            }
            if (objgriduploads.Eligibleratereimbursementforlaon== null)
            { 
                cmdpacd.Parameters.AddWithValue("@Eligibleratereimbursementforlaon", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@Eligibleratereimbursementforlaon",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.Eligibleratereimbursementforlaon); 
            }
            if (objgriduploads.MonthRateofinterest== null)
            { 
                cmdpacd.Parameters.AddWithValue("@MonthRateofinterest", SqlDbType.VarChar).Value = DBNull.Value; 
            }
            else
            {
                cmdpacd.Parameters.AddWithValue("@MonthRateofinterest",SqlDbType.VarChar).Value = Convert.ToString(objgriduploads.MonthRateofinterest); 
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

}





public class pallavadiproperties
{
public string incapplnno { get; set; }
    public string txtunitnames { get; set; }
    public string txtLocofUnit { get; set; }
    public string ddlOrddlorgtypes { get; set; }
    public string ddlUdyogAadharType { get; set; }
    public string txtPersonIndustry { get; set; }
    public string txtDateOfapplnFile { get; set; }
    public string txtLoanApplnNo { get; set; }
    public string txtDate_Loan { get; set; }
    public string txtNameofFinIns { get; set; }
    public string txtPowerConn_date { get; set; }
    public string txtPowerConn_load { get; set; }
    public string txtDCP_unit { get; set; }
    public string txtrc_dic { get; set; }
    public string txtcompdate_dic { get; set; }
    public string txtquery_dic { get; set; }
    public string txtcompdate_coi { get; set; }
    public string txtcompdate_coi1 { get; set; }
    public string txtquery_coi { get; set; }
    public string txtLand2 { get; set; }
    public string txtLand3 { get; set; }
    public string txtLand4 { get; set; }
    public string txtLand5 { get; set; }
    public string txtLand6 { get; set; }
    public string txtLand7 { get; set; }
    public string txtBuilding2 { get; set; }
    public string txtBuilding3 { get; set; }
    public string txtBuilding4 { get; set; }
    public string txtBuilding5 { get; set; }
    public string txtBuilding6 { get; set; }
    public string txtBuilding7 { get; set; }
    public string txtPM2 { get; set; }
    public string txtPM3 { get; set; }
    public string txtPM4 { get; set; }
    public string txtPM5 { get; set; }
    public string txtPM6 { get; set; }
    public string txtPM7 { get; set; }
    public string txtMCont2 { get; set; }
    public string txtMCont3 { get; set; }
    public string txtMCont4 { get; set; }
    public string txtMCont5 { get; set; }
    public string txtMCont6 { get; set; }
    public string txtMCont7 { get; set; }
    public string txtErec2 { get; set; }
    public string txtErec3 { get; set; }
    public string txtErec4 { get; set; }
    public string txtErec5 { get; set; }
    public string txtErec6 { get; set; }
    public string txtErec7 { get; set; }
    public string txtTFS2 { get; set; }
    public string txtTFS3 { get; set; }
    public string txtTFS4 { get; set; }
    public string txtTFS5 { get; set; }
    public string txtTFS6 { get; set; }
    public string txtTFS7 { get; set; }
    public string txtWC2 { get; set; }
    public string txtWC3 { get; set; }
    public string txtWC4 { get; set; }
    public string txtWC5 { get; set; }
    public string txtWC6 { get; set; }
    public string txtWC7 { get; set; }
    public string txtLandcostCompc { get; set; }
    public string txtLandAreaCompc { get; set; }
    public string txtPurchaCompc { get; set; }
    public string txtStmpDutyCompc { get; set; }
    public string txtRegnfeeCompc { get; set; }
    public string txtTotalCompc { get; set; }
    public string txtBuildingAreCompc { get; set; }
    public string txtvalDICCompc { get; set; }
    public string txtvalCompc1 { get; set; }
    public string txtresonsCompc { get; set; }
    public string txtfacCostCompc { get; set; }
    public string txtfacBldgCompc { get; set; }
    public string txtcivilEngCompc { get; set; }
    public string txtsfcCompc { get; set; }
    public string txtCAExpCompc { get; set; }
    public string txtCompvalCompc { get; set; }
    public string txtrsnCompc { get; set; }
    public string TextBox30 { get; set; }
    public string TextBox32 { get; set; }
    public string TextBox31 { get; set; }
    public string TextBox34 { get; set; }
    public string TextBox36 { get; set; }
    public string TextBox38 { get; set; }
    public string TextBox40 { get; set; }
    public string TextBox42 { get; set; }
    public string TextBox47 { get; set; }
    public string TextBox33 { get; set; }
    public string TextBox37 { get; set; }
    public string TextBox41 { get; set; }
    public string TextBox44 { get; set; }
    public string TextBox1 { get; set; }
    public string TextBox56 { get; set; }
    public string TextBox57 { get; set; }
    public string TextBox58 { get; set; }
    public string TextBox45 { get; set; }
    public string TextBox2 { get; set; }
    public string TextBox35 { get; set; }
    public string TextBox39 { get; set; }
    public string TextBox43 { get; set; }
    public string TextBox46 { get; set; }
    public string TextBox48 { get; set; }
    public string txtContProdMgm { get; set; }
    public string txt25BldgCvl { get; set; }
    public string txt822guideline422 { get; set; }
    public string txtTSSFCnorms422 { get; set; }
    public string txtPlintharea424 { get; set; }
    public string txtPlintharea422 { get; set; }
    public string txtvalue422 { get; set; }
    public string TextBox59 { get; set; }
    public string txt423guideline { get; set; }
    public string txtTSSFCnorms423 { get; set; }
    public string txtvalue424 { get; set; }
    
    public string incentiveid { get; set; }
    public string TextBox60 { get; set; }
    public string TextBox5 { get; set; }
    public string TextBox7 { get; set; }
    public string TextBox9 { get; set; }
    public string TextBox11 { get; set; }
    public string TextBox13 { get; set; }
    public string TextBox15 { get; set; }
    public string TextBox17 { get; set; }
    public string TextBox18 { get; set; }
    public string TextBox19 { get; set; }
    public string TextBox61 { get; set; }
    public string TextBox6 { get; set; }
    public string TextBox8 { get; set; }
    public string TextBox10 { get; set; }
    public string TextBox12 { get; set; }
    public string TextBox14 { get; set; }
    public string TextBox16 { get; set; }
    public string TextBox20 { get; set; }
    public string RDELIGIBLE { get; set; }
    public string Remarks { get; set; }
    public string MstIncentiveId { get; set; }
    public string ELIGIBLESANCTIONEDAMOUNT { get; set; }
    public string CLAIMPERIODID { get; set; }
    public string CLAIMPERIOD { get; set; }
    public DateTime? DATEOFCOMMENCEMENTOFACTIVITY { get; set; }
    public string PERIODOFINSTALMENTID { get; set; }
    public string INSTALMENTPERIOD { get; set; }
    public string NOOFINSTALMENTS { get; set; }
    public decimal? INSTALMENTAMOUNT { get; set; }
    public string INSTALMENTSTARTMONTHYEAR_ID { get; set; }
    public string INSTALMENTSTARTMONTHYEAR_VALUE { get; set; }
    public string RATEOFINTEREST { get; set; }
    public string ELIGIBLERATEOFREUMBERSEMENT { get; set; }
    public string NOOFINSTALMENTS_COMPLETED { get; set; }
    public string PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR { get; set; }
    public decimal? INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS { get; set; }
    public decimal? ACTUALINTERESTAMOUNT_PAID { get; set; }
    public decimal? INTERESTREIMBURSEMENTCALCULATED { get; set; }
    public decimal? INTERESTREIMBURSEMENTCALCULATED_FINAL { get; set; }
    public decimal? GMRECOMMENDEDAMOUNT { get; set; }
    public decimal? FINALELIGIBLEAMOUNT { get; set; }
    public int? Valid { get; set; }
    public string EglibleTypeID { get; set; }
    public string EglibleTypeName { get; set; }
    public decimal? INTERESTREIMBURSEMENTCALCULATEDaftereglibletype { get; set; }
    public string PERIODOFINSTALMENTName { get; set; }
    public int? Noofclaimperiods { get; set; }
    public int? IDENTITYCOCUMN { get; set; }
   public string lblApplicationno  { get; set; }
    public DateTime? created_dt  	{ get; set; }
    public string createdby { get; set; }
    public string created_by { get; set; }
    public string ELIGIBLETYPE   { get; set; }
    public string modified_by 	{ get; set; }
    public DateTime? modified_dt 	{ get; set; }
    public string createdIP  { get; set; }

public string ModifiedIP { get; set; }

    public decimal? Conreburismentamount { get; set; }


    public string Scheme { get; set; }

    public decimal? Yrsfrmdcpdate { get; set; }

    public string caste_IR { get; set; }
    public string gender_IR { get; set; }
    public string category_IR { get; set; }
    public string enterprisetype_IR { get; set; }
    public string sector_IR { get; set; }
    public string servicetype_IR { get; set; }

    public string transNonTrans_IR { get; set; }

}

public class pallavadisubproperties
{
    public int? PVID  { get; set; }
    public string INCENTIVEID { get; set; }
    public string CLAIMPERIOD_Grid { get; set; }
    public string PERIODOFINSTALMENT_MAINTABLE { get; set; }
    public string NOOFINSTALLMENTS_MAINTABLE { get; set; }
    public string NOOFINSTALMENTSCOMPLETED_Grid { get; set; }
    public string PERIODOFCLAIM_MONTHWISE_ID_GRID { get; set; }
    public string PERIODOFCLAIM_MONTHWISE_VALUE_GRID { get; set; }
    public decimal? PRINCIPALAMOUNTDUE_GRID { get; set; }
    public string NOOFINSTALLMENT_GRID { get; set; }
    public decimal? INTERESTAMOUNT_GRID { get; set; } 
    public decimal? InstallmentAmount { get; set; }
    public decimal? INTERESTAMOUNTPAIDASPERCALCULATIONS_GRID { get; set; } 
    public decimal? ACTUALINTERESTAMOUNTPAID { get; set; } 
    public decimal? INTERESTREIMBERSEMENTCALCULATED { get; set; }
    public string ELIGIBLETYPE { get; set; }
    public decimal? INTERESTREIMBERSEMENTCALCULATED_FINAL { get; set; } 
    public decimal? GMRECOMMENDEDAMOUNT { get; set; } 
    public decimal? FINALELIGIBLEAMOUNT { get; set; }
    public string IPADDRESS { get; set; }
    public string CREATED_BY { get; set; }   
    public DateTime? CREATED_DT { get; set; }
    public string MODIFIED_BY { get; set; }
    public DateTime? MODIFIED_DT { get; set; }
    public decimal? interestegliblereimbursement { get; set; }
    public int? SUBPallvaid { get; set; }   
    public string CLAIMPERIODName_Grid { get; set; }
    public string PeriodofinstallmentName  { get; set; }
    public decimal? principalamountduefornexthalfyr_grid  { get; set; }
    public string ELIGIBLETYPEName { get; set; }
    public decimal? eligibleperiodinmonths  { get; set; }
    public string installmentstartmonthyear { get; set; }
    public DateTime? dcpdate { get; set; }
    public int? LoanNumber { get; set; }
    public decimal? unitholdercont { get; set; }
    public decimal? eligiblerateofinterset { get; set; }
    public decimal? eligibleinterestamount { get; set; }
    public decimal? CPL_interestamountpaidaspercal { get; set; }
    public decimal? CPL_actualinterestamountpaid { get; set; }
    public decimal? CPL_Conamountforcalintreimberest { get; set; }
    public decimal? CPL_interestreimbersementcal  { get; set; }
    public string CPL_interestreimbersementcal_finaleligibletype { get; set; }
    public decimal? CPL_gmrecommendedamount  { get; set; }
    public decimal? CPL_FINALELIGIBLEAMOUNT  { get; set; }
    public decimal? Conamountforcalintreimberest { get; set; }
    public int PVCPLHFID { get; set; }
    public string IsMortage { get; set; }
    public int? ActualNoofinstallmentsCompleted  { get; set; }

    public decimal? tottermloanavil { get; set; }
    public decimal? totmonthseligibleinterestamount { get; set; }
    public decimal? totmonthsinterestamountMonth { get; set; }
    public decimal? Rateofinterestforloan { get; set; }
    public decimal? Eligibleratereimbursementforlaon { get; set; }
    public decimal? MonthRateofinterest { get; set; }
}


public class pallavaddiclaimLoandetailsproperties
{
    public Int32? PVCPLHFID { get; set; }
    public Int32? Incentiveid { get; set; }
    public Int32? APCDPVID { get; set; }
    public string ClaimPeriodID { get; set; } 
    public string ClaimPeriodName { get; set; } 
    public Int32? LoanNumber { get; set; }
    public string ClaimPeriodFYID { get; set; }
    public string ClaimPeriodFYSubID { get; set; }	 
    public string IS1st2dhalfyear { get; set; } 
    public DateTime? dcpdate { get; set; }    
    public DateTime? loaninstallmentstartdate { get; set; }   
    public decimal? tottermloanavil { get; set; }
    public string Periodofinstallmentid { get; set; }	 
    public string Periodofinstallmentname { get; set; } 
    public Int32? Noofinstallmentforloan  { get; set; } 
    public decimal? Installmentamountforloan  { get; set; }
    public decimal? Rateofinterestforloan { get; set; }
    public decimal? Eligibleratereimbursementforlaon  { get; set; }
    public Int32? NoofinstallmentcompletedfortheloanFY  { get; set; }
    public decimal? principalamountdueforhalfyrFY  { get; set; }
    public string PeriodofClaimMonth1ID { get; set; }    
    public string PeriodofClaimMonth1Name { get; set; }    
    public decimal? PrincipalamountdueMonth1  { get; set; }
    public Int32? NoofInstallmentMonth1 { get; set; }
    public decimal? rateofinterestMonth1 { get; set; }   
    public decimal? interestamountMonth1 { get; set; } 
    public decimal? unitholdercontMonth1 { get; set; } 
    public decimal? eligiblerateofintersetMonth1  { get; set; }
    public decimal? eligibleinterestamountMonth1  { get; set; }
    public string PeriodofClaimMonth2ID { get; set; }  
    public string PeriodofClaimMonth2Name { get; set; }	 
    public decimal? PrincipalamountdueMonth2  { get; set; }
    public Int32? NoofInstallmentMonth2 { get; set; }
    public decimal? rateofinterestMonth2  { get; set; }
    public decimal? interestamountMonth2  { get; set; }
    public decimal? unitholdercontMonth2  { get; set; }
    public decimal? eligiblerateofintersetMonth2  { get; set; }
    public decimal? eligibleinterestamountMonth2  { get; set; }
    public string PeriodofClaimMonth3ID { get; set; }
    public string PeriodofClaimMonth3Name  { get; set; }
    public decimal? PrincipalamountdueMonth3  { get; set; }
    public Int32? NoofInstallmentMonth3 { get; set; }
    public decimal? rateofinterestMonth3  { get; set; }
    public decimal? interestamountMonth3  { get; set; }
    public decimal? unitholdercontMonth3  { get; set; }
    public decimal? eligiblerateofintersetMonth3 { get; set; }
    public decimal? eligibleinterestamountMonth3  { get; set; }
    public string PeriodofClaimMonth4ID { get; set; }  
    public string PeriodofClaimMonth4Name  { get; set; }   
    public decimal? PrincipalamountdueMonth4  { get; set; }
    public Int32? NoofInstallmentMonth4 { get; set; } 
    public decimal? rateofinterestMonth4  { get; set; }
    public decimal? interestamountMonth4  { get; set; }
    public decimal? unitholdercontMonth4  { get; set; }
    public decimal? eligiblerateofintersetMonth4  { get; set; }
    public decimal? eligibleinterestamountMonth4  { get; set; }
    public string PeriodofClaimMonth5ID  { get; set; }    
    public string PeriodofClaimMonth5Name { get; set; }	 
    public decimal? PrincipalamountdueMonth5  { get; set; }
    public Int32? NoofInstallmentMonth5   { get; set; }  
    public decimal? rateofinterestMonth5 { get; set; }  
    public decimal? interestamountMonth5  { get; set; }
    public decimal? unitholdercontMonth5  { get; set; }
    public decimal? eligiblerateofintersetMonth5 { get; set; } 
    public decimal? eligibleinterestamountMonth5 { get; set; } 
    public string PeriodofClaimMonth6ID  { get; set; }	 
    public string PeriodofClaimMonth6Name   { get; set; }  
    public decimal? PrincipalamountdueMonth6  { get; set; }
    public Int32? NoofInstallmentMonth6 { get; set; }
    public decimal? rateofinterestMonth6  { get; set; }
    public decimal? interestamountMonth6  { get; set; }
    public decimal? unitholdercontMonth6  { get; set; }
    public decimal? eligiblerateofintersetMonth6    { get; set; }   
    public decimal? eligibleinterestamountMonth6 { get; set; } 
    public decimal? totmonthseligibleinterestamount { get; set; }  
    public decimal? totmonthsinterestamountMonth { get; set; } 
    public decimal? eligibleperiodinmonths    { get; set; }
    public decimal? CPL_interestamountpaidaspercal { get; set; } 
    public decimal? CPL_actualinterestamountpaid  { get; set; }
    public decimal? CPL_Conamountforcalintreimberest  { get; set; }
    public decimal? CPL_interestreimbersementcal  { get; set; }
    public string CPL_ELIGIBLETYPE  { get; set; }    
    public string CPL_ELIGIBLETYPEName { get; set; } 
    public string CPL_interestreimbersementcal_finaleligibletype  { get; set; }   
    public decimal? CPL_gmrecommendedamount  { get; set; }
    public decimal? CPL_FINALELIGIBLEAMOUNT  { get; set; }
    public decimal? totince_interestamountpaidaspercal  { get; set; }
    public decimal? totince_actualinterestamountpaid  { get; set; }
    public decimal? totince_interestreimbersementcal  { get; set; }
    public string totince_interestreimbersementcal_finaleligibletype { get; set; } 
    public decimal? totince_gmrecommendedamount  { get; set; }
    public decimal? totince_FINALELIGIBLEAMOUNT  { get; set; }

    public string Createdby { get; set; }
    public string CreatedIP { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string Modifiedby { get; set; }
    public string ModifiedIP { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public decimal totince_Conamountforcalintreimberest { get; set; }

    public string IsMortage { get; set; }
    public int ActualNoofinstallmentsCompleted  { get; set; }

    public int ActualNoofinstallmentsCompletedMonths { get; set; }
    public decimal Actualprincipalamtfornextyrs { get; set; }
    public int NoofinstallmentsCompletedMonths { get; set; }
    public string IsprevMoratorium { get; set; }
    public bool Moratoriumrowone { get; set; }
    public bool Moratoriumrowtwo { get; set; }
    public bool Moratoriumrowthree { get; set; }
    public bool Moratoriumrowfour { get; set; }
    public bool Moratoriumrowfive { get; set; }
    public bool Moratoriumrowsix { get; set; }
}

public class Pallavaddiclaimloanproperties
{
    public Int32 PVFYLID { get; set; }
    public Int32 Incentiveid { get; set; }
    public Int32 APCDPVID { get; set; }
    public string ClaimPeriodID { get; set; }
    public string ClaimPeriodName { get; set; }
    public Int32 LoanCount { get; set; }
    public Int32 Isactive { get; set; }
    public string Createdby { get; set; }
    public string CreatedIP { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Modifiedby { get; set; }
    public string ModifiedIP { get; set; }
    public DateTime ModifiedOn { get; set; }

    public string FinancialYear { get; set; }
}