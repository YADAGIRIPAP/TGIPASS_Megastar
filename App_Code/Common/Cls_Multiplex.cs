using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Cls_Multiplex
/// </summary>
public class Cls_Multiplex
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public Cls_Multiplex()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GetCinemaLicensedetails(int cinemaid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetCinematographicDetailsPrint", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Cinemalicenseid", SqlDbType.Int).Value = cinemaid;
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

    public DataSet RetriveCinematographicDetails(int CREATEDBY, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetCinematoographicLicenseDetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = CREATEDBY;
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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
    public Response InsertCinematographicLicenseDetails(string ExpYear, string Fileno_9B,
    string Rererancedate, string LongevityCertificateDate, string ElectricalCertificateDate, string NocDate, string LicensePeriod,
    string TheatreType, string Noofscreens, string Noofshows, out int cinemalicenseid, string Created_by, string ApplicantName,
    string ApplicantDistrict, string ApplicantMandal, string ApplicantVillage, string ApplicantPlotNo,
    string ApplicantPINCODE, string PlaceorBildinLicense, string OwnerName, string OwnerDistrict,
    string OwnerMandal, string OwnerVillage, string OwnerPlotNo, string OwnerPINCODE,
    string Commissionerate, string Zone, string Division, string Policestation, string TrafficZone,
    string TrafficDivision, string TrafficPolicestation, string ApprovalFee)
    {
        Response objRes = new Response();
        con.OpenConnection();
        SqlCommand com = new SqlCommand("SP_INSERT_CINEMATOGRAPHICLICENSE_DETAILS", con.GetConnection);
        com.CommandType = CommandType.StoredProcedure;

        try
        {


            if (ExpYear.ToString().Trim() == "0" || ExpYear.ToString().Trim() == null || ExpYear.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ExpYear", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ExpYear", SqlDbType.VarChar).Value = ExpYear.Trim();

            if (Fileno_9B.ToString().Trim() == "" || Fileno_9B.ToString().Trim() == null)
                com.Parameters.Add("@Fileno_9B", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Fileno_9B", SqlDbType.VarChar).Value = Fileno_9B.Trim();

            if (Rererancedate.ToString().Trim() == "" || Rererancedate.ToString().Trim() == null)
                com.Parameters.Add("@Rererancedate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@Rererancedate", SqlDbType.DateTime).Value = Rererancedate.Trim();

            if (LongevityCertificateDate.ToString().Trim() == "" || LongevityCertificateDate.ToString().Trim() == null)
                com.Parameters.Add("@LongevityCertificateDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@LongevityCertificateDate", SqlDbType.DateTime).Value = LongevityCertificateDate.Trim();

            if (ElectricalCertificateDate.ToString().Trim() == "" || ElectricalCertificateDate.ToString().Trim() == null)
                com.Parameters.Add("@ElectricalCertificateDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@ElectricalCertificateDate", SqlDbType.DateTime).Value = ElectricalCertificateDate.Trim();

            if (NocDate.ToString().Trim() == "" || NocDate.ToString().Trim() == null)
                com.Parameters.Add("@NocDate", SqlDbType.DateTime).Value = DBNull.Value;
            else
                com.Parameters.Add("@NocDate", SqlDbType.DateTime).Value = NocDate.Trim();

            if (LicensePeriod.ToString().Trim() == "0" || LicensePeriod.ToString().Trim() == null || LicensePeriod.ToString().Trim() == "--Select--")
                com.Parameters.Add("@LicensePeriod", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@LicensePeriod", SqlDbType.VarChar).Value = LicensePeriod.Trim();

            if (TheatreType.ToString().Trim() == "" || TheatreType.ToString().Trim() == null)
                com.Parameters.Add("@TheatreType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TheatreType", SqlDbType.VarChar).Value = TheatreType.Trim();

            if (Noofscreens.ToString().Trim() == "" || Noofscreens.ToString().Trim() == null)
                com.Parameters.Add("@Noofscreens", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Noofscreens", SqlDbType.VarChar).Value = Noofscreens.Trim();

            if (Noofshows.ToString().Trim() == "" || Noofshows.ToString().Trim() == null)
                com.Parameters.Add("@Noofshows", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Noofshows", SqlDbType.VarChar).Value = Noofshows.Trim();

            if (Commissionerate.ToString().Trim() == "0" || Commissionerate.ToString().Trim() == null || Commissionerate.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Commissionerate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Commissionerate", SqlDbType.VarChar).Value = Commissionerate.Trim();

            if (Zone.ToString().Trim() == "0" || Zone.ToString().Trim() == null || Zone.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Zone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Zone", SqlDbType.VarChar).Value = Zone.Trim();

            if (Division.ToString().Trim() == "0" || Division.ToString().Trim() == null || Division.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Division", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Division", SqlDbType.VarChar).Value = Division.Trim();

            if (Policestation.ToString().Trim() == "0" || Policestation.ToString().Trim() == null || Policestation.ToString().Trim() == "--Select--")
                com.Parameters.Add("@Policestation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Policestation", SqlDbType.VarChar).Value = Policestation.Trim();

            if (TrafficZone.ToString().Trim() == "0" || TrafficZone.ToString().Trim() == null || TrafficZone.ToString().Trim() == "--Select--")
                com.Parameters.Add("@TrafficZone", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TrafficZone", SqlDbType.VarChar).Value = TrafficZone.Trim();

            if (TrafficDivision.ToString().Trim() == "0" || TrafficDivision.ToString().Trim() == null || TrafficDivision.ToString().Trim() == "--Select--")
                com.Parameters.Add("@TrafficDivision", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TrafficDivision", SqlDbType.VarChar).Value = TrafficDivision.Trim();

            if (TrafficPolicestation.ToString().Trim() == "0" || TrafficPolicestation.ToString().Trim() == null || TrafficPolicestation.ToString().Trim() == "--Select--")
                com.Parameters.Add("@TrafficPolicestation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@TrafficPolicestation", SqlDbType.VarChar).Value = TrafficPolicestation.Trim();

            if (ApplicantName.ToString().Trim() == "" || ApplicantName.ToString().Trim() == null)
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantName", SqlDbType.VarChar).Value = ApplicantName.Trim();

            if (ApplicantDistrict.ToString().Trim() == "0" || ApplicantDistrict.ToString().Trim() == null || ApplicantDistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ApplicantDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantDistrict", SqlDbType.VarChar).Value = ApplicantDistrict.Trim();

            if (ApplicantMandal.ToString().Trim() == "0" || ApplicantMandal.ToString().Trim() == null || ApplicantMandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ApplicantMandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantMandal", SqlDbType.VarChar).Value = ApplicantMandal.Trim();

            if (ApplicantVillage.ToString().Trim() == "0" || ApplicantVillage.ToString().Trim() == null || ApplicantVillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@ApplicantVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantVillage", SqlDbType.VarChar).Value = ApplicantVillage.Trim();

            if (ApplicantPlotNo.ToString().Trim() == "" || ApplicantPlotNo.ToString().Trim() == null)
                com.Parameters.Add("@ApplicantPlotNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantPlotNo", SqlDbType.VarChar).Value = ApplicantPlotNo.Trim();

            if (ApplicantPINCODE.ToString().Trim() == "" || ApplicantPINCODE.ToString().Trim() == null)
                com.Parameters.Add("@ApplicantPINCODE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@ApplicantPINCODE", SqlDbType.VarChar).Value = ApplicantPINCODE.Trim();

            if (PlaceorBildinLicense.ToString().Trim() == "" || PlaceorBildinLicense.ToString().Trim() == null)
                com.Parameters.Add("@PlaceorBildinLicense", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@PlaceorBildinLicense", SqlDbType.VarChar).Value = PlaceorBildinLicense.Trim();

            if (OwnerName.ToString().Trim() == "" || OwnerName.ToString().Trim() == null)
                com.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = OwnerName.Trim();

            if (OwnerDistrict.ToString().Trim() == "0" || OwnerDistrict.ToString().Trim() == null || OwnerDistrict.ToString().Trim() == "--Select--")
                com.Parameters.Add("@OwnerDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerDistrict", SqlDbType.VarChar).Value = OwnerDistrict.Trim();

            if (OwnerMandal.ToString().Trim() == "0" || OwnerMandal.ToString().Trim() == null || OwnerMandal.ToString().Trim() == "--Select--")
                com.Parameters.Add("@OwnerMandal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerMandal", SqlDbType.VarChar).Value = OwnerMandal.Trim();

            if (OwnerVillage.ToString().Trim() == "0" || OwnerVillage.ToString().Trim() == null || OwnerVillage.ToString().Trim() == "--Select--")
                com.Parameters.Add("@OwnerVillage", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerVillage", SqlDbType.VarChar).Value = OwnerVillage.Trim();

            if (OwnerPlotNo.ToString().Trim() == "" || OwnerPlotNo.ToString().Trim() == null)
                com.Parameters.Add("@OwnerPlotNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerPlotNo", SqlDbType.VarChar).Value = OwnerPlotNo.Trim();

            if (OwnerPINCODE.ToString().Trim() == "" || OwnerPINCODE.ToString().Trim() == null)
                com.Parameters.Add("@OwnerPINCODE", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@OwnerPINCODE", SqlDbType.VarChar).Value = OwnerPINCODE.Trim();



            if (Created_by.ToString().Trim() == "" || Created_by.ToString().Trim() == null)
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();
             if (Created_by.ToString().Trim() == "" || Created_by.ToString().Trim() == null)

                 com.Parameters.Add("@ApprovalFee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                 com.Parameters.Add("@ApprovalFee", SqlDbType.VarChar).Value = ApprovalFee.Trim();

            
            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            cinemalicenseid = (Int32)com.Parameters["@Valid"].Value;


            if (cinemalicenseid > 0)
                objRes.ResponseVal = true;

            else
                objRes.ResponseVal = false;
            con.CloseConnection();
        }


        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
        return objRes;
    }


    public DataSet GetMultiplexAppIDbyuserid(int UserID, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetMultiplexAppIDbyuserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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

    public DataSet GetShowApprovalandFees_Multiplex(string AdvertisementID, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetShowApprovalandFees_Multiplex", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (AdvertisementID.Trim() == "" || AdvertisementID.Trim() == null)
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@AdvertisementID", SqlDbType.VarChar).Value = AdvertisementID.ToString();
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();
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

    public DataSet GetMultiplexPayDetailsAddtionalPayment(string intQuessionaireid, string applicationid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SOA_GetMultiplexPayDetails_AddtionalPayment", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
            if (applicationid.Trim() == "" || applicationid.Trim() == null)
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@applicationid", SqlDbType.VarChar).Value = applicationid.ToString();

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

    public int UpdateUIDMultiplex(string UID_no, string intQuessionaireid)
    {
        int valid = 0;

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("UpdateUID_multiplex", con.GetConnection);
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

    public int insertDepartmentAprroval_Multiplex(string intQuessionaireid, string intDeptid, string intApprovalid, string Approval_Fee, string IsPayment, string Created_by, string IsOffline)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insDepartmentApprovals_Multiplex";

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

    public DataSet getMultiplexdatabyQues(string intQuessionaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getmultiplexdatabyQues", con.GetConnection);
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

    public int InsertPaymentBillDesk_Multiplex(string UidNo, string intCFEEnterpid, string OnlineOrderNo, string intDeptid, string Online_Amount, string Created_by, string intApprovalid, string ApplType, string AdditionalPayment)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_INSERT_Builldesc_PaymentDtls";

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