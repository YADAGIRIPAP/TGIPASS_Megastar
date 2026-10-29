using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Cls_MSME
/// </summary>
public class Cls_MSME
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    Globavaribles gbp = new Globavaribles();

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;

    comFunctions cmf = new comFunctions();
    public Cls_MSME()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet getemployeementdatabymsmeno(string MsmeNo)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_getemployeementdatabymsmeno", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = MsmeNo.ToString();


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


    public DataSet MSMEDistrictwiseReport(string FromDate, string ToDate, string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_AllDistrictwisereport", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (FromDate == "" || FromDate == null)
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.VarChar).Value = FromDate.Trim();
            if (ToDate == "" || ToDate == null)
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.VarChar).Value = ToDate.Trim();       
            if (District == "" || District == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = District.Trim();

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


     #region edit msme Cls_MSME
    public DataSet GetMSMEDetailsbyMSMEID(string MsmeNo)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_getMSMEDetailsbyMSMEID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = MsmeNo.ToString();
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
    public DataTable getProductMANFDETAILSbyMSMEID(string MsmeNo)
    {
        con.OpenConnection();
        con.OpenConnection();
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            da = new SqlDataAdapter("MSME_GETproductmanfacturedetails", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = MsmeNo.ToString();
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
    public DataTable getRAWDETAILSbyMSMEID(string MsmeNo)
    {
        con.OpenConnection();
        con.OpenConnection();
        SqlDataAdapter da;
        DataTable ds = new DataTable();
        try
        {
            da = new SqlDataAdapter("MSME_GETRAWDETAILSbymsmeid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = MsmeNo.ToString();
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
    public DataSet ViewAttachmetsDatabyMSMEID(string MsmeNo)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_getAttachmentsByMSMEID", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MsmeNo", SqlDbType.VarChar).Value = MsmeNo.ToString();
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

    public int UpdateMsmeUnitDetails(MSMEUNITDETAILS bc)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "MSME_Update_UNIT_DETAILS";
            com.Transaction = transaction;
            com.Connection = connection;
            com.Parameters.AddWithValue("@remarks", bc.REMARKS);
            com.Parameters.AddWithValue("@UNITS_IE_OR_NOT", bc.UNITS_IE_OR_NOT);
            com.Parameters.AddWithValue("@CATEGOERY_ID", bc.CATEGOERY_ID);
            com.Parameters.AddWithValue("@UAM_ID", bc.UAM_ID);
            com.Parameters.AddWithValue("@DISTRICT_ID", bc.DISTRICT_ID);
            com.Parameters.AddWithValue("@MANDAL_ID", bc.MANDAL_ID);
            com.Parameters.AddWithValue("@UNIT_NAME", bc.UNIT_NAME);
            com.Parameters.AddWithValue("@EMPLOYMENT", bc.EMPLOYMENT);
            com.Parameters.AddWithValue("@NAME_OF_ENTREPRENEUR", bc.NAME_OF_ENTREPRENEUR);
            com.Parameters.AddWithValue("@MOBILE_NO", bc.MOBILE_NO);
            com.Parameters.AddWithValue("@EMAIL_ID", bc.EMAIL_ID);
            com.Parameters.AddWithValue("@LINE_OF_ACTIVITY", bc.LINE_OF_ACTIVITY);
            com.Parameters.AddWithValue("@PRODUCT_SPEC", bc.PRODUCT_SPEC);
            com.Parameters.AddWithValue("@CREATED_BY", bc.CreatedBy);
            //com.Parameters.AddWithValue("@DateofCapture", bc.Date);
            com.Parameters.AddWithValue("@PresentStatus", bc.presentstatus);
            com.Parameters.AddWithValue("@OtherPresentStatus", bc.otherpresentstatus);
            com.Parameters.AddWithValue("@TYPEOFINDUSTRY", bc.TYPEOFINDUSTRY);
            com.Parameters.AddWithValue("@DATEOFCOMMENCEMENT", bc.DATEOFCOMMENCEMENT);
            com.Parameters.AddWithValue("@EXPORT", bc.EXPORT);
            com.Parameters.AddWithValue("@EXPORTCOUNTRY", bc.EXPORTCOUNTRY);
            com.Parameters.AddWithValue("@TYPEOFCONNECTION", bc.TYPEOFCONNECTION);
            com.Parameters.AddWithValue("@PCBCATEGORY", bc.PCBCATEGORY);
            com.Parameters.AddWithValue("@SOCAILSTATUS", bc.SOCAILSTATUS);
            com.Parameters.AddWithValue("@PROMOTERWOMEN", bc.PROMOTERWOMEN);
            com.Parameters.AddWithValue("@PROMOTERDISABLED", bc.PROMOTERDISABLED);
            com.Parameters.AddWithValue("@SECTOR", bc.SECTOR);
            com.Parameters.AddWithValue("@RAWMATERIALPROCURED", bc.RAWMATERIALPROCURED);
            com.Parameters.AddWithValue("@RAWMATERIALDISTRICT", bc.RAWMATERIALDISTRICT);
            com.Parameters.AddWithValue("@RAWMATERIALSTATE", bc.RAWMATERIALSTATE);
            com.Parameters.AddWithValue("@RAWMATERIALCOUNTRY", bc.RAWMATERIALCOUNTRY);
            com.Parameters.AddWithValue("@CompleteAddress", bc.Completeaddress);
            com.Parameters.AddWithValue("@Investment", bc.investment);
            com.Parameters.AddWithValue("@MSME_NO", bc.MSMENO);
            //com.Parameters.AddWithValue("@uploaddetailslistofmachinery", bc.uploaddetailslistofmachinery);
            com.Parameters.AddWithValue("@VillageID", bc.VillageID);
            com.Parameters.AddWithValue("@HouseNo", bc.HouseNo);
            com.Parameters.AddWithValue("@Locality", bc.Locality);
            com.Parameters.AddWithValue("@Street", bc.Street);
            com.Parameters.AddWithValue("@LandMark", bc.LandMark);
            com.Parameters.AddWithValue("@IndustrialParkID", bc.IndustrialParkID);

            if (bc.tsipassuidno == "" || bc.tsipassuidno == null)
                com.Parameters.AddWithValue("@tsipassuidno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@tsipassuidno", SqlDbType.VarChar).Value = bc.tsipassuidno.Trim();

            if (bc.intcfeid == "" || bc.intcfeid == null)
                com.Parameters.AddWithValue("@intcfeid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@intcfeid", SqlDbType.VarChar).Value = bc.intcfeid.Trim();


            if (bc.noofempgivenesipf == "" || bc.noofempgivenesipf == null)
                com.Parameters.AddWithValue("@noofempgivenesipf", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempgivenesipf", SqlDbType.VarChar).Value = bc.noofempgivenesipf.Trim();

            if (bc.noofempnotgivenesipf == "" || bc.noofempnotgivenesipf == null)
                com.Parameters.AddWithValue("@noofempnotgivenesipf", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempnotgivenesipf", SqlDbType.VarChar).Value = bc.noofempnotgivenesipf.Trim();

            if (bc.noofemplocal == "" || bc.noofemplocal == null)
                com.Parameters.AddWithValue("@noofemplocal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofemplocal", SqlDbType.VarChar).Value = bc.noofemplocal.Trim();
            if (bc.noofempnonlocal == "" || bc.noofempnonlocal == null)
                com.Parameters.AddWithValue("@noofempnonlocal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempnonlocal", SqlDbType.VarChar).Value = bc.noofempnonlocal.Trim();

            if (bc.Migrantworkman == "" || bc.Migrantworkman == null)
                com.Parameters.AddWithValue("@Migrantworkman", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@Migrantworkman", SqlDbType.VarChar).Value = bc.Migrantworkman.Trim();

            if (bc.noofempdirect == "" || bc.noofempdirect == null)

                com.Parameters.AddWithValue("@noofempdirect", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempdirect", SqlDbType.VarChar).Value = bc.noofempdirect.Trim();
            if (bc.noofempindirect == "" || bc.noofempindirect == null)
                com.Parameters.AddWithValue("@noofempindirect", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempindirect", SqlDbType.VarChar).Value = bc.noofempindirect.Trim();
            if (bc.noofempoutsourcig == "" || bc.noofempoutsourcig == null)
                com.Parameters.AddWithValue("@noofempoutsourcig", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempoutsourcig", SqlDbType.VarChar).Value = bc.noofempoutsourcig.Trim();

            if (bc.noofempContract == "" || bc.noofempContract == null)
                com.Parameters.AddWithValue("@noofempContract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofempContract", SqlDbType.VarChar).Value = bc.noofempContract.Trim();



            if (bc.skilledcontract == "" || bc.skilledcontract == null)
                com.Parameters.AddWithValue("@skilledcontract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@skilledcontract", SqlDbType.VarChar).Value = bc.skilledcontract.Trim();
            if (bc.skilledoutsourcing == "" || bc.skilledoutsourcing == null)
                com.Parameters.AddWithValue("@skilledoutsourcing", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@skilledoutsourcing", SqlDbType.VarChar).Value = bc.skilledoutsourcing.Trim();
            if (bc.skilledtotal == "" || bc.skilledtotal == null)
                com.Parameters.AddWithValue("@skilledtotal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@skilledtotal", SqlDbType.VarChar).Value = bc.skilledtotal.Trim();



            if (bc.semiskilledcontract == "" || bc.semiskilledcontract == null)
                com.Parameters.AddWithValue("@semiskilledcontract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@semiskilledcontract", SqlDbType.VarChar).Value = bc.semiskilledcontract.Trim();
            if (bc.semiskilledoutsourcing == "" || bc.semiskilledoutsourcing == null)
                com.Parameters.AddWithValue("@semiskilledoutsourcing", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@semiskilledoutsourcing", SqlDbType.VarChar).Value = bc.semiskilledoutsourcing.Trim();
            if (bc.semiskilledtotal == "" || bc.semiskilledtotal == null)
                com.Parameters.AddWithValue("@semiskilledtotal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@semiskilledtotal", SqlDbType.VarChar).Value = bc.semiskilledtotal.Trim();


            if (bc.unskilledcontract == "" || bc.unskilledcontract == null)
                com.Parameters.AddWithValue("@unskilledcontract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@unskilledcontract", SqlDbType.VarChar).Value = bc.unskilledcontract.Trim();
            if (bc.unskilledoutsourcing == "" || bc.unskilledoutsourcing == null)
                com.Parameters.AddWithValue("@unskilledoutsourcing", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@unskilledoutsourcing", SqlDbType.VarChar).Value = bc.unskilledoutsourcing.Trim();
            if (bc.unskilledtotal == "" || bc.unskilledtotal == null)
                com.Parameters.AddWithValue("@unskilledtotal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@unskilledtotal", SqlDbType.VarChar).Value = bc.unskilledtotal.Trim();



            if (bc.managerialcontract == "" || bc.managerialcontract == null)
                com.Parameters.AddWithValue("@managerialcontract", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@managerialcontract", SqlDbType.VarChar).Value = bc.managerialcontract.Trim();
            if (bc.managerialoutsourcing == "" || bc.managerialoutsourcing == null)
                com.Parameters.AddWithValue("@managerialoutsourcing", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@managerialoutsourcing", SqlDbType.VarChar).Value = bc.managerialoutsourcing.Trim();
            if (bc.managerialtotal == "" || bc.managerialtotal == null)
                com.Parameters.AddWithValue("@managerialtotal", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@managerialtotal", SqlDbType.VarChar).Value = bc.managerialtotal.Trim();

            if (bc.noofMenemp == "" || bc.noofMenemp == null)
                com.Parameters.AddWithValue("@noofMenemp", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofMenemp", SqlDbType.VarChar).Value = bc.noofMenemp.Trim();
            if (bc.noofWomenemp == "" || bc.noofWomenemp == null)
                com.Parameters.AddWithValue("@noofWomenemp", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@noofWomenemp", SqlDbType.VarChar).Value = bc.noofWomenemp.Trim();
            if (bc.totalEmployement == "" || bc.totalEmployement == null)
                com.Parameters.AddWithValue("@totalEmployement", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@totalEmployement", SqlDbType.VarChar).Value = bc.totalEmployement.Trim();

            if (bc.latitude == "" || bc.latitude == null)
                com.Parameters.AddWithValue("@latitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@latitude", SqlDbType.VarChar).Value = bc.latitude.Trim();
            if (bc.longitude == "" || bc.longitude == null)
                com.Parameters.AddWithValue("@longitude", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@longitude", SqlDbType.VarChar).Value = bc.longitude.Trim();

            //-----------------------Newly added after Survey----------//
            if (bc.isUnitRegistered == "" || bc.isUnitRegistered == null)
                com.Parameters.AddWithValue("@isUnitRegistered", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@isUnitRegistered", SqlDbType.VarChar).Value = bc.isUnitRegistered.Trim();

            if (bc.CorrAdr_HouseNo == "" || bc.CorrAdr_HouseNo == null)
                com.Parameters.AddWithValue("@CorrAdr_HouseNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_HouseNo", SqlDbType.VarChar).Value = bc.CorrAdr_HouseNo.Trim();

            if (bc.CorrAdr_StreetName == "" || bc.CorrAdr_StreetName == null)
                com.Parameters.AddWithValue("@CorrAdr_StreetName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_StreetName", SqlDbType.VarChar).Value = bc.CorrAdr_StreetName.Trim();

            if (bc.CorrAdr_Locality == "" || bc.CorrAdr_Locality == null)
                com.Parameters.AddWithValue("@CorrAdr_Locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_Locality", SqlDbType.VarChar).Value = bc.CorrAdr_Locality.Trim();

            if (bc.CorrAdr_LandMark == "" || bc.CorrAdr_LandMark == null)
                com.Parameters.AddWithValue("@CorrAdr_LandMark", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_LandMark", SqlDbType.VarChar).Value = bc.CorrAdr_LandMark.Trim();

            if (bc.CorrAdr_DistrictId == "" || bc.CorrAdr_DistrictId == null || bc.CorrAdr_DistrictId == "0")
                com.Parameters.AddWithValue("@CorrAdr_DistrictId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_DistrictId", SqlDbType.VarChar).Value = bc.CorrAdr_DistrictId.Trim();

            if (bc.CorrAdr_MandalId == "" || bc.CorrAdr_MandalId == null)
                com.Parameters.AddWithValue("@CorrAdr_MandalId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_MandalId", SqlDbType.VarChar).Value = bc.CorrAdr_MandalId.Trim();

            if (bc.isUnitRegistered == "" || bc.isUnitRegistered == null)
                com.Parameters.AddWithValue("@CorrAdr_VillageId", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CorrAdr_VillageId", SqlDbType.VarChar).Value = bc.CorrAdr_VillageId.Trim();

            if (bc.MSMEOwnerGeneration == "" || bc.MSMEOwnerGeneration == null)
                com.Parameters.AddWithValue("@MSMEOwnerGeneration", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@MSMEOwnerGeneration", SqlDbType.VarChar).Value = bc.MSMEOwnerGeneration.Trim();

            if (bc.AvailedLoanScheme == "" || bc.AvailedLoanScheme == null)
                com.Parameters.AddWithValue("@AvailedLoanScheme", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@AvailedLoanScheme", SqlDbType.VarChar).Value = bc.AvailedLoanScheme.Trim();

            if (bc.OtherLoanScheme == "" || bc.OtherLoanScheme == null)
                com.Parameters.AddWithValue("@OtherLoanScheme", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@OtherLoanScheme", SqlDbType.VarChar).Value = bc.OtherLoanScheme.Trim();

            if (bc.LoanStatus == "" || bc.LoanStatus == null)
                com.Parameters.AddWithValue("@LoanStatus", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@LoanStatus", SqlDbType.VarChar).Value = bc.LoanStatus.Trim();

            if (bc.LoanBankName == "" || bc.LoanBankName == null)
                com.Parameters.AddWithValue("@LoanBankName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@LoanBankName", SqlDbType.VarChar).Value = bc.LoanBankName.Trim();

            if (bc.LoanNBFCName == "" || bc.LoanNBFCName == null)
                com.Parameters.AddWithValue("@LoanNBFCName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@LoanNBFCName", SqlDbType.VarChar).Value = bc.LoanNBFCName.Trim();

            if (bc.CapitalInvestment == "" || bc.CapitalInvestment == null)
                com.Parameters.AddWithValue("@CapitalInvestment", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@CapitalInvestment", SqlDbType.VarChar).Value = bc.CapitalInvestment.Trim();

            if (bc.Turnover == "" || bc.Turnover == null)
                com.Parameters.AddWithValue("@Turnover", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@Turnover", SqlDbType.VarChar).Value = bc.Turnover.Trim();

            if (bc.ProfitorLoss == "" || bc.ProfitorLoss == null)
                com.Parameters.AddWithValue("@ProfitorLoss", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ProfitorLoss", SqlDbType.VarChar).Value = bc.ProfitorLoss.Trim();

            if (bc.ProfitAmount == "" || bc.ProfitAmount == null)
                com.Parameters.AddWithValue("@ProfitAmount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ProfitAmount", SqlDbType.VarChar).Value = bc.ProfitAmount.Trim();

            if (bc.LossAmount == "" || bc.LossAmount == null)
                com.Parameters.AddWithValue("@LossAmount", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@LossAmount", SqlDbType.VarChar).Value = bc.LossAmount.Trim();

            if (bc.EmpWithinDistrict == "" || bc.EmpWithinDistrict == null)
                com.Parameters.AddWithValue("@EmpWithinDistrict", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@EmpWithinDistrict", SqlDbType.VarChar).Value = bc.EmpWithinDistrict.Trim();

            if (bc.AltMobileNo == "" || bc.AltMobileNo == null)
                com.Parameters.AddWithValue("@AltMobileNo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@AltMobileNo", SqlDbType.VarChar).Value = bc.AltMobileNo.Trim();

            if (bc.IsDuplorNEorNA == "" || bc.IsDuplorNEorNA == null)
                com.Parameters.AddWithValue("@IsDuplorNEorNA", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@IsDuplorNEorNA", SqlDbType.VarChar).Value = bc.IsDuplorNEorNA.Trim();

            //if (bc.IsDuplorNEorNA == "" || bc.IsDuplorNEorNA == null)
            //    com.Parameters.AddWithValue("@IsDuplorNEorNA", SqlDbType.VarChar).Value = DBNull.Value;
            //else
            //    com.Parameters.AddWithValue("@IsDuplorNEorNA", SqlDbType.VarChar).Value = bc.IsDuplorNEorNA.Trim();

            if (bc.DuplMaptoMSMEID == "" || bc.DuplMaptoMSMEID == null)
                com.Parameters.AddWithValue("@DuplMaptoMSMEID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@DuplMaptoMSMEID", SqlDbType.VarChar).Value = bc.DuplMaptoMSMEID.Trim();

            if (bc.DuplMaptoMSMEUnitname == "" || bc.DuplMaptoMSMEUnitname == null)
                com.Parameters.AddWithValue("@DuplMaptoMSMEUnitname", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@DuplMaptoMSMEUnitname", SqlDbType.VarChar).Value = bc.DuplMaptoMSMEUnitname.Trim();

            if (bc.ConfrmDonethrough == "" || bc.ConfrmDonethrough == null || bc.ConfrmDonethrough == "0")
                com.Parameters.AddWithValue("@ConfrmDonethrough", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ConfrmDonethrough", SqlDbType.VarChar).Value = bc.ConfrmDonethrough.Trim();

            if (bc.OtherConfrmation == "" || bc.OtherConfrmation == null)
                com.Parameters.AddWithValue("@OtherConfrmation", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@OtherConfrmation", SqlDbType.VarChar).Value = bc.OtherConfrmation.Trim();

            if (bc.ConfrmDoneby == "" || bc.ConfrmDoneby == null || bc.ConfrmDoneby == "0")
                com.Parameters.AddWithValue("@ConfrmDoneby", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ConfrmDoneby", SqlDbType.VarChar).Value = bc.ConfrmDoneby.Trim();

            if (bc.ClosingMainReason == "" || bc.ClosingMainReason == null || bc.ClosingMainReason == "0")
                com.Parameters.AddWithValue("@ClosingMainReason", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ClosingMainReason", SqlDbType.VarChar).Value = bc.ClosingMainReason.Trim();

            if (bc.ClosingSubReason == "" || bc.ClosingSubReason == null)
                com.Parameters.AddWithValue("@ClosingSubReason", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@ClosingSubReason", SqlDbType.VarChar).Value = bc.ClosingSubReason.Trim();
            //-----------------------Newly added after Survey----------//

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            valid = (Int32)com.Parameters["@Valid"].Value;
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;


    }

    public int UpdateMsme_rawmaterialdetails(MSMELineOfManfGrid1DETAILS obj_msmerawmaterials)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "MSME_insertupdateRawmaterial";
            com.Transaction = transaction;
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MSME_NO", obj_msmerawmaterials.MSMEID);
            com.Parameters.AddWithValue("@RAW_ITEM_NAME", obj_msmerawmaterials.Item);
            com.Parameters.AddWithValue("@RAW_QUANTITY_PER_ANNUM", obj_msmerawmaterials.QuantityPerAnnum);
            com.Parameters.AddWithValue("@RAW_PRODUCCTION_IN", obj_msmerawmaterials.ProductionInUnits);
            com.Parameters.AddWithValue("@RAW_PRODUCTION_OTHERS", obj_msmerawmaterials.OtherRawUnits);
            com.Parameters.AddWithValue("@CREATED_BY", obj_msmerawmaterials.CreatedBy);
            com.Parameters.AddWithValue("@RMDID", obj_msmerawmaterials.RMDID);
            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            valid = (Int32)com.Parameters["@Valid"].Value;
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;


    }

    public int deactiveMsme_rawmaterialdetails(string MSME_NO, string RMDID, string CREATED_BY)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "MSME_deactiveRawmaterialbyrowid";
        if (MSME_NO.Trim() == "" || MSME_NO.Trim() == null)
            com.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = MSME_NO.Trim();
        if (RMDID.Trim() == "" || RMDID.Trim() == null)
            com.Parameters.Add("@RMDID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RMDID", SqlDbType.VarChar).Value = RMDID.Trim();
        if (CREATED_BY.Trim() == "" || CREATED_BY.Trim() == null)
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.Trim();
        con.OpenConnection();
        com.Connection = con.GetConnection;
        try
        {
            // return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteNonQuery());
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

  

    //public bool deactiveMsme_rawmaterialdetails(string MSME_NO,string RMDID,string CREATED_BY)
    //{
    //    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;     
    //    SqlConnection connection = new SqlConnection(str);
    //    SqlTransaction transaction = null;
    //    connection.Open();
    //    transaction = connection.BeginTransaction();
       
    //        SqlCommand com = new SqlCommand();
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.CommandText = "MSME_deactiveRawmaterialbyrowid";
    //        com.Transaction = transaction;
    //        com.Connection = connection;
    //        com.CommandType = CommandType.StoredProcedure;
    //        com.Parameters.AddWithValue("@MSME_NO", MSME_NO);
    //        com.Parameters.AddWithValue("@RMDID", RMDID);
    //        com.Parameters.AddWithValue("@CREATED_BY", CREATED_BY);
    //     try
    //    {
    //        com.ExecuteNonQuery();
    //        connection.Close();
    //        return true;
    //    }       
    //        catch (Exception ex)
    //    {
    //        //transaction.Rollback();
    //        //throw ex;
    //        return false;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //        connection.Dispose();
    //    }
    //}


    public DataSet GetRawmaterialbyrowid(string MsmeNo,string RMDID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_getRawmaterialbyrowid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = MsmeNo.ToString();
            if (RMDID.Trim() == "" || RMDID.Trim() == null)
                da.SelectCommand.Parameters.Add("@RMDID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@RMDID", SqlDbType.VarChar).Value = RMDID.ToString();
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
    public int UpdateMsme_productmanfaturedetails(MSMELineOfManfGrid2DETAILS obj_msmeproductmanfacture)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "MSME_insertupdateManufactureDetailsMSME";
            com.Transaction = transaction;
            com.Connection = connection;
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MSME_NO", obj_msmeproductmanfacture.MSMEID);
            com.Parameters.AddWithValue("@MANF_ITEM_NAME", obj_msmeproductmanfacture.Item);
            com.Parameters.AddWithValue("@MANF_QUANTITY_PER_ANNUM", obj_msmeproductmanfacture.QuantityPerAnnum);
            com.Parameters.AddWithValue("@MANF_PRODUCTIONS_IN", obj_msmeproductmanfacture.ProductionInUnits);
            com.Parameters.AddWithValue("@MANF_PRODUCTION_OTHERS", obj_msmeproductmanfacture.ManufOtherUnits);
            com.Parameters.AddWithValue("@MANF_UNIT_PHOTO", obj_msmeproductmanfacture.Attachment);
            com.Parameters.AddWithValue("@CREATED_BY", obj_msmeproductmanfacture.CreatedBy);
            com.Parameters.AddWithValue("@OthersSpecify", obj_msmeproductmanfacture.OthersSpecify);
            com.Parameters.AddWithValue("@prodmanf_ID", obj_msmeproductmanfacture.prodmanf_ID);
            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            valid = (Int32)com.Parameters["@Valid"].Value;
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;


    }

    public int deactiveMsme_productmanfaturedetails(string MSME_NO, string prodmanf_ID, string CREATED_BY)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "MSME_deactiveproductmanfacturebyrowid";
        if (MSME_NO.Trim() == "" || MSME_NO.Trim() == null)
            com.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = MSME_NO.Trim();
        if (prodmanf_ID.Trim() == "" || prodmanf_ID.Trim() == null)
            com.Parameters.Add("@prodmanf_ID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@prodmanf_ID", SqlDbType.VarChar).Value = prodmanf_ID.Trim();
        if (CREATED_BY.Trim() == "" || CREATED_BY.Trim() == null)
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@CREATED_BY", SqlDbType.VarChar).Value = CREATED_BY.Trim();
        con.OpenConnection();
        com.Connection = con.GetConnection;
        try
        {
            // return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteNonQuery());
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
    //public bool deactiveMsme_productmanfaturedetails(string MSME_NO, string prodmanf_ID, string CREATED_BY)
    //{
    //    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    //    SqlConnection connection = new SqlConnection(str);
    //    SqlTransaction transaction = null;
    //    connection.Open();
    //    transaction = connection.BeginTransaction();

    //    SqlCommand com = new SqlCommand();
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.CommandText = "MSME_deactiveproductmanfacturebyrowid";
    //    com.Transaction = transaction;
    //    com.Connection = connection;
    //    com.CommandType = CommandType.StoredProcedure;
    //    com.Parameters.AddWithValue("@MSME_NO", MSME_NO);
    //    com.Parameters.AddWithValue("@prodmanf_ID", prodmanf_ID);
    //    com.Parameters.AddWithValue("@CREATED_BY", CREATED_BY);
    //    try
    //    {
    //        com.ExecuteNonQuery();
    //        connection.Close();
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        //transaction.Rollback();
    //        //throw ex;
    //        return false;
    //    }
    //    finally
    //    {
    //        connection.Close();
    //        connection.Dispose();
    //    }
    //}


    public DataSet Getproductmanfaturebyprodmanfid(string MsmeNo, string ProdManID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_getproductmanfacturebyrowid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (MsmeNo.Trim() == "" || MsmeNo.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = MsmeNo.ToString();
            if (ProdManID.Trim() == "" || ProdManID.Trim() == null)
                da.SelectCommand.Parameters.Add("@prodmanf_ID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@prodmanf_ID", SqlDbType.VarChar).Value = ProdManID.ToString();
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

    #endregion

    public bool Uploadlistdetailsofmanchinetools(int intUID, string FileType, string FilePath, string FileName, string FileDescription,
 int Created_by, string applid)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "MSME_InsertMSMEuploadDetails";
        com.Transaction = transaction;
        com.Connection = connection;
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@intUID", intUID);
        com.Parameters.AddWithValue("@FileType", FileType);
        com.Parameters.AddWithValue("@FilePath", FilePath);
        com.Parameters.AddWithValue("@FileName", FileName);
        com.Parameters.AddWithValue("@FileDescription", FileDescription);
        com.Parameters.AddWithValue("@Created_by", Created_by);
        com.Parameters.AddWithValue("@applid", applid);
        try
        {
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            //transaction.Rollback();
            //throw ex;
            return false;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
    }


    public bool deactiveMsme_uploadlistofdetails(string MSME_NO, string RMDID, string CREATED_BY)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "MSME_deactiveuploadfilebyrowid";
        com.Transaction = transaction;
        com.Connection = connection;
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@MSME_NO", MSME_NO);
        com.Parameters.AddWithValue("@intMSMEID", RMDID);
        com.Parameters.AddWithValue("@CREATED_BY", CREATED_BY);
        try
        {
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            //transaction.Rollback();
            //throw ex;
            return false;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
    }
    public DataSet GetpopupMSMEApplicationsbydistrictidstatus(string DistrictID, string Status)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("MSME_GetpopupMSMEApplicationsbydistrictidstatus", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DistrictID == "" || DistrictID == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = DistrictID.Trim();
            if (Status == "" || Status == null)
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();
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
    public DataSet GetMSMEOLDNEWDATA(string MSMENO)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETMSME_OLDNEW_DATA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (MSMENO.Trim() == "" || MSMENO.Trim() == null)
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MSMENO", SqlDbType.VarChar).Value = MSMENO.ToString();



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


    public int DeleteMsmeDetailsbyIDandDIC(string msmeno, string deleteflag, string remarks, string createdby, string DeletedID,
        string DeletedReason, string DeletedIP)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "MSME_DELETEMSMEDRILLDOWNbyID";
        cmd.Parameters.Add("@MSME_NO", SqlDbType.VarChar).Value = msmeno;
        cmd.Parameters.Add("@DELETEFLAG", SqlDbType.VarChar).Value = deleteflag;
        cmd.Parameters.Add("@DELETEREMARKS", SqlDbType.VarChar).Value = remarks;
        cmd.Parameters.Add("@MODIFIEDUSER", SqlDbType.VarChar).Value = createdby;
        cmd.Parameters.Add("@DeletedID", SqlDbType.VarChar).Value = DeletedID;
        cmd.Parameters.Add("@DeletedReason", SqlDbType.VarChar).Value = DeletedReason;
        cmd.Parameters.Add("@DeletedIP", SqlDbType.VarChar).Value = DeletedIP;

        con.OpenConnection();
        cmd.Connection = con.GetConnection;

        try
        {
            return cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
            return 0;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();

        }

    }


    public bool insertemployeedata(MSMEemployeedatagridDETAILS objMSMEemployeedatagridDETAILSBO)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "msme_insertemployeedata";
        com.Transaction = transaction;
        com.Connection = connection;
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.AddWithValue("@emptypeid", objMSMEemployeedatagridDETAILSBO.emptypeid);
        com.Parameters.AddWithValue("@emptypename", objMSMEemployeedatagridDETAILSBO.emptypename);
        com.Parameters.AddWithValue("@payamount", objMSMEemployeedatagridDETAILSBO.payamount);
        com.Parameters.AddWithValue("@Pfamount", objMSMEemployeedatagridDETAILSBO.Pfamount);
        com.Parameters.AddWithValue("@esiamount", objMSMEemployeedatagridDETAILSBO.esiamount);
        com.Parameters.AddWithValue("@qualiskillsreq", objMSMEemployeedatagridDETAILSBO.qualiskillsreq);
        com.Parameters.AddWithValue("@noofpost", objMSMEemployeedatagridDETAILSBO.noofpost);
        com.Parameters.AddWithValue("@Women", objMSMEemployeedatagridDETAILSBO.Women);
        com.Parameters.AddWithValue("@men", objMSMEemployeedatagridDETAILSBO.men);
        com.Parameters.AddWithValue("@Local", objMSMEemployeedatagridDETAILSBO.Local);
        com.Parameters.AddWithValue("@Nonlocal", objMSMEemployeedatagridDETAILSBO.Nonlocal);
        com.Parameters.AddWithValue("@CreatedBy", objMSMEemployeedatagridDETAILSBO.CreatedBy);
        com.Parameters.AddWithValue("@CreatedIP", objMSMEemployeedatagridDETAILSBO.CreatedIP);
        com.Parameters.AddWithValue("@MSMENO", objMSMEemployeedatagridDETAILSBO.MSMENO);
        com.Parameters.AddWithValue("@Iscontract", objMSMEemployeedatagridDETAILSBO.Iscontract);
        com.Parameters.AddWithValue("@Isoutsour", objMSMEemployeedatagridDETAILSBO.Isoutsour);
        try
        {
            com.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            //transaction.Rollback();
            //throw ex;
            return false;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
    }

    public bool inactiveemployeedata(string CreatedBy, string CreatedIP, string MSMENO)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "msme_inactiveemployeedata";
        com.Transaction = transaction;
        com.Connection = connection;
        com.CommandType = CommandType.StoredProcedure;

        com.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        com.Parameters.AddWithValue("@CreatedIP", CreatedIP);
        com.Parameters.AddWithValue("@MSMENO", MSMENO);
        try
        {
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            //transaction.Rollback();
            //throw ex;
            return false;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
    }

}
public class MSMEemployeedatagridDETAILS
{
    public string emptypeid { get; set; }
    public string emptypename { get; set; }
    public string payamount { get; set; }
    public string Pfamount { get; set; }
    public string esiamount { get; set; }
    public string qualiskillsreq { get; set; }
    public string noofpost { get; set; }
    public string Women { get; set; }
    public string men { get; set; }
    public string Local { get; set; }
    public string Nonlocal { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedIP { get; set; }
    public string MSMENO { get; set; }
    public bool Iscontract { get; set; }
    public bool Isoutsour { get; set; }

}