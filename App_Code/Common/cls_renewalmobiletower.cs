using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for cls_renewalmobiletower
/// </summary>
public class cls_renewalmobiletower
{
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
    public cls_renewalmobiletower()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Insertupdatemobiletowerrenewal(prdmobiletowerrenewalobj obj)
    {
        string valid = "";

        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("ren_insertupdatecelltower", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {

            if (obj.PrdDistrictID.ToString().Trim() == "" || obj.PrdDistrictID.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdDistrictID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdDistrictID", SqlDbType.VarChar).Value = obj.PrdDistrictID.Trim();

            if (obj.PrdDistrictName.ToString().Trim() == null || obj.PrdDistrictName.ToString().Trim() == "")
                cmd.Parameters.Add("@PrdDistrictName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdDistrictName", SqlDbType.VarChar).Value = obj.PrdDistrictName.Trim();

            if (obj.PrdMandalID.ToString().Trim() == "" || obj.PrdMandalID.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdMandalID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdMandalID", SqlDbType.VarChar).Value = obj.PrdMandalID.Trim();

            if (obj.PrdMandalName.ToString().Trim() == "" || obj.PrdMandalName.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdMandalName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdMandalName", SqlDbType.VarChar).Value = obj.PrdMandalName.Trim();

            if (obj.PrdVillageID.ToString().Trim() == "" || obj.PrdVillageID.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdVillageID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdVillageID", SqlDbType.VarChar).Value = obj.PrdVillageID.Trim();

            if (obj.PrdVillageName.ToString().Trim() == "" || obj.PrdVillageName.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdVillageName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdVillageName", SqlDbType.VarChar).Value = obj.PrdVillageName.Trim();

            if (obj.PrdTradeLicenseYear.ToString().Trim() == "" || obj.PrdTradeLicenseYear.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdTradeLicenseYear", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdTradeLicenseYear", SqlDbType.VarChar).Value = obj.PrdTradeLicenseYear.Trim();

            if (obj.PrdTradeLicenseNumber.ToString().Trim() == "" || obj.PrdTradeLicenseNumber.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdTradeLicenseNumber", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdTradeLicenseNumber", SqlDbType.VarChar).Value = obj.PrdTradeLicenseNumber.Trim();

            if (obj.PrdTradeID.ToString().Trim() == null || obj.PrdTradeID.ToString().Trim() == "")
                cmd.Parameters.Add("@PrdTradeID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdTradeID", SqlDbType.VarChar).Value = obj.PrdTradeID.Trim();

            if (obj.PrdTradeName.ToString().Trim() == null || obj.PrdTradeName.ToString().Trim() == "")
                cmd.Parameters.Add("@PrdTradeName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdTradeName", SqlDbType.VarChar).Value = obj.PrdTradeName.Trim();
 
            if (obj.PrdSubTradeID.ToString().Trim() == "" || obj.PrdSubTradeID.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdSubTradeID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdSubTradeID", SqlDbType.VarChar).Value = obj.PrdSubTradeID.Trim();

            if (obj.PrdSubTradeName.ToString().Trim() == "" || obj.PrdSubTradeName.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdSubTradeName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdSubTradeName", SqlDbType.VarChar).Value = obj.PrdSubTradeName.Trim();

            if (obj.PrdCellTowerID.ToString().Trim() == "" || obj.PrdCellTowerID.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdCellTowerID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdCellTowerID", SqlDbType.VarChar).Value = obj.PrdCellTowerID.Trim();

            if (obj.PrdCellTowerFor.ToString().Trim() == "" || obj.PrdCellTowerFor.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdCellTowerFor", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdCellTowerFor", SqlDbType.VarChar).Value = obj.PrdCellTowerFor.Trim();

            if (obj.PrdAnuualLicenseFee.ToString().Trim() == "" || obj.PrdAnuualLicenseFee.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdAnuualLicenseFee", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdAnuualLicenseFee", SqlDbType.VarChar).Value = obj.PrdAnuualLicenseFee;

            if (obj.PrdNameoffirm_shops.ToString().Trim() == "" || obj.PrdNameoffirm_shops.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdNameoffirm_shops", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdNameoffirm_shops", SqlDbType.VarChar).Value = obj.PrdNameoffirm_shops.Trim();

            if (obj.prdDoorNo_locality.ToString().Trim() == "" || obj.prdDoorNo_locality.ToString().Trim() == null)
                cmd.Parameters.Add("@prdDoorNo_locality", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@prdDoorNo_locality", SqlDbType.VarChar).Value = obj.prdDoorNo_locality;

            if (obj.PrdRenewalperiodFrom.ToString().Trim() == "" || obj.PrdRenewalperiodFrom.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdRenewalperiodFrom", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdRenewalperiodFrom", SqlDbType.DateTime).Value = obj.PrdRenewalperiodFrom;
            if (obj.PrdRenewalPeriodTo.ToString().Trim() == "" || obj.PrdRenewalPeriodTo.ToString().Trim() == null)
                cmd.Parameters.Add("@PrdRenewalPeriodTo", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@PrdRenewalPeriodTo", SqlDbType.VarChar).Value = obj.PrdRenewalPeriodTo.Trim();

            if (obj.RenewalID.ToString().Trim() == "0" || obj.RenewalID.ToString().Trim() == null)
                cmd.Parameters.Add("@RenewalID", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@RenewalID", SqlDbType.VarChar).Value = obj.RenewalID.Trim();

            if (obj.CreatedIP.ToString().Trim() == "" || obj.CreatedIP.ToString().Trim() == null)
                cmd.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CreatedIP", SqlDbType.VarChar).Value = obj.CreatedIP.Trim();
            if (obj.CreatedBy.ToString().Trim() == "" || obj.CreatedBy.ToString().Trim() == null)
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = obj.CreatedBy.Trim();
            cmd.Parameters.Add("@RenwalCelltowerid", SqlDbType.Int, 500);
            cmd.Parameters["@RenwalCelltowerid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int res = (Int32)cmd.Parameters["@RenwalCelltowerid"].Value;
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
    public DataSet Getcelltowerrenwaliduserid(string RenewalID, string CreatedBy)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("ren_getcelltowerrenwaliduserid", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (RenewalID.Trim() == "" || RenewalID.Trim() == null)
                da.SelectCommand.Parameters.Add("@RenewalID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@RenewalID", SqlDbType.VarChar).Value = RenewalID.ToString();
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
}
public class prdmobiletowerrenewalobj
    {
        public string tradelicenseno { get; set; }
        public string PrdDistrictID { get; set; }
        public string PrdDistrictName { get; set; }
        public string PrdMandalID { get; set; }
        public string PrdMandalName { get; set; }
        public string PrdVillageID { get; set; }
        public string PrdVillageName { get; set; }
        public string PrdTradeLicenseYear { get; set; }
        public string PrdTradeLicenseNumber { get; set; }
        public string PrdTradeID { get; set; }
        public string PrdTradeName { get; set; }
        public string PrdSubTradeID { get; set; }
        public string PrdSubTradeName { get; set; }
        public string PrdCellTowerID { get; set; }
        public string PrdCellTowerFor { get; set; }
        public decimal PrdAnuualLicenseFee { get; set; }
        public string PrdNameoffirm_shops { get; set; }
        public string prdDoorNo_locality { get; set; }
        public string PrdRenewalperiodFrom  { get; set; }
        public string PrdRenewalPeriodTo { get; set; }
        public string RenewalID  { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedBy { get; set; }
        public string RenwalCelltowerid { get; set; }
    }
