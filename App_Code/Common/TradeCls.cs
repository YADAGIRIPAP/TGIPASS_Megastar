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
/// Summary description for TradeCls
/// </summary>
public class TradeCls
{
    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
    private SqlConnection connSqlHelper = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    DB.DB con = new DB.DB();
    comFunctions cmf = new comFunctions();
	public TradeCls()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet Getdata_TradeRenewalDetails(string intQuessionaireCFOid,string createdby,string applicationflag)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TRADERENEWALDETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            if (intQuessionaireCFOid.Trim() == "" || intQuessionaireCFOid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.ToString();

            if (createdby.Trim() == "" || createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = createdby.ToString();

            if (applicationflag.Trim() == "" || applicationflag.Trim() == null)
                da.SelectCommand.Parameters.Add("@APPLFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@APPLFLAG", SqlDbType.VarChar).Value = applicationflag.ToString();


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

    public void InsertTradeRenewal(TradeRenewalProperties TradeRenVo)
    {

        try
        {
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            SqlCommand cmdEnj = new SqlCommand("USP_INS_TRADERENEWAL", connection);
            cmdEnj.CommandType = CommandType.StoredProcedure;
            cmdEnj.Transaction = transaction;
            cmdEnj.Connection = connection;

            if (TradeRenVo.AddressofOwner != "" && TradeRenVo.AddressofOwner != null)
            {
                cmdEnj.Parameters.AddWithValue("@AddressofOwner", SqlDbType.Int).Value = TradeRenVo.AddressofOwner;
            }

            if (TradeRenVo.ArrearGarbageCharges != "" && TradeRenVo.ArrearGarbageCharges != null)
            {
                cmdEnj.Parameters.AddWithValue("@ArrearGarbageCharges", SqlDbType.Int).Value = TradeRenVo.ArrearGarbageCharges;
            }
            if (TradeRenVo.ArrearsAmountLicence != "" && TradeRenVo.ArrearsAmountLicence != null)
            {
                cmdEnj.Parameters.AddWithValue("@ArrearsAmountLicence", SqlDbType.VarChar).Value = TradeRenVo.ArrearsAmountLicence;
            }
            if (TradeRenVo.ArrearsAmountLicenseinterest != "" && TradeRenVo.ArrearsAmountLicenseinterest != null)
            {
                cmdEnj.Parameters.AddWithValue("@ArrearsAmountLicenseinterest", SqlDbType.VarChar).Value = TradeRenVo.ArrearsAmountLicenseinterest;
            }
            if (TradeRenVo.CategoryID != "" && TradeRenVo.CategoryID != null)
            {
                cmdEnj.Parameters.AddWithValue("@CategoryID", SqlDbType.VarChar).Value = TradeRenVo.CategoryID;
            }
            if (TradeRenVo.CategoryName != "" && TradeRenVo.CategoryName != null)
            {
                cmdEnj.Parameters.AddWithValue("@CategoryName", SqlDbType.VarChar).Value = TradeRenVo.CategoryName;
            }
            if (TradeRenVo.Created_by != "" && TradeRenVo.Created_by != null)
            {
                cmdEnj.Parameters.AddWithValue("@Created_by", SqlDbType.Int).Value = TradeRenVo.Created_by;
            }
            if (TradeRenVo.CurrentGarbageCharges != "" && TradeRenVo.CurrentGarbageCharges != null)
            {
                cmdEnj.Parameters.AddWithValue("@CurrentGarbageCharges", SqlDbType.Int).Value = TradeRenVo.CurrentGarbageCharges;
            }
            if (TradeRenVo.CurrentLicenceFee != "" && TradeRenVo.CurrentLicenceFee != null)
            {
                cmdEnj.Parameters.AddWithValue("@CurrentLicenceFee", SqlDbType.VarChar).Value = TradeRenVo.CurrentLicenceFee;
            }
            if (TradeRenVo.CurrentLicenceFeeInterest != "" && TradeRenVo.CurrentLicenceFeeInterest != null)
            {
                cmdEnj.Parameters.AddWithValue("@CurrentLicenceFeeInterest", SqlDbType.VarChar).Value = TradeRenVo.CurrentLicenceFeeInterest;
            }
            if (TradeRenVo.intCFOEnterpid != "" && TradeRenVo.intCFOEnterpid != null)
            {
                cmdEnj.Parameters.AddWithValue("@intCFOEnterpid", SqlDbType.VarChar).Value = TradeRenVo.intCFOEnterpid;
            }
            if (TradeRenVo.intDeptid != "" && TradeRenVo.intDeptid != null)
            {
                cmdEnj.Parameters.AddWithValue("@intDeptid", SqlDbType.VarChar).Value = TradeRenVo.intDeptid;
            }
            if (TradeRenVo.intQuessionaireCFOid != "" && TradeRenVo.intQuessionaireCFOid != null)
            {
                cmdEnj.Parameters.AddWithValue("@intQuessionaireCFOid", SqlDbType.VarChar).Value = TradeRenVo.intQuessionaireCFOid;
            }
            if (TradeRenVo.intStageid != "" && TradeRenVo.intStageid != null)
            {
                cmdEnj.Parameters.AddWithValue("@intStageid", SqlDbType.VarChar).Value = TradeRenVo.intStageid;
            }
            if (TradeRenVo.licenceValidFrom != "" && TradeRenVo.licenceValidFrom != null)
            {
                cmdEnj.Parameters.AddWithValue("@licenceValidFrom", SqlDbType.VarChar).Value = cmf.convertDateIndia(TradeRenVo.licenceValidFrom);
            }
            if (TradeRenVo.licenceValidUpto != "" && TradeRenVo.licenceValidUpto != null)
            {
                cmdEnj.Parameters.AddWithValue("@licenceValidUpto", SqlDbType.VarChar).Value = cmf.convertDateIndia(TradeRenVo.licenceValidUpto);
            }
            if (TradeRenVo.Modified_by != "" && TradeRenVo.Modified_by != null)
            {
                cmdEnj.Parameters.AddWithValue("@Modified_by", SqlDbType.VarChar).Value = TradeRenVo.Modified_by;
            }
            if (TradeRenVo.NameofOwner != "" && TradeRenVo.NameofOwner != null)
            {
                cmdEnj.Parameters.AddWithValue("@NameofOwner", SqlDbType.VarChar).Value = TradeRenVo.NameofOwner;
            }
            if (TradeRenVo.PlinthArea != "" && TradeRenVo.PlinthArea != null)
            {
                cmdEnj.Parameters.AddWithValue("@PlinthArea", SqlDbType.VarChar).Value = TradeRenVo.PlinthArea;
            }
            if (TradeRenVo.Reg_Id != "" && TradeRenVo.Reg_Id != null)
            {
                cmdEnj.Parameters.AddWithValue("@Reg_Id", SqlDbType.VarChar).Value = TradeRenVo.Reg_Id;
            }
            if (TradeRenVo.RoadTypeId != "" && TradeRenVo.RoadTypeId != null)
            {
                cmdEnj.Parameters.AddWithValue("@RoadTypeId", SqlDbType.VarChar).Value = TradeRenVo.RoadTypeId;
            }
            if (TradeRenVo.RoadTypeName != "" && TradeRenVo.RoadTypeName != null)
            {
                cmdEnj.Parameters.AddWithValue("@RoadTypeName", SqlDbType.VarChar).Value = TradeRenVo.RoadTypeName;
            }
            if (TradeRenVo.SubCategory != "" && TradeRenVo.SubCategory != null)
            {
                cmdEnj.Parameters.AddWithValue("@SubCategory", SqlDbType.VarChar).Value = TradeRenVo.SubCategory;
            }

            if (TradeRenVo.SubCategoryID != "" && TradeRenVo.SubCategoryID != null)
            {
                cmdEnj.Parameters.AddWithValue("@SubCategoryID", SqlDbType.VarChar).Value = TradeRenVo.SubCategoryID;
            }

            if (TradeRenVo.TitleOfTrade != "" && TradeRenVo.TitleOfTrade != null)
            {
                cmdEnj.Parameters.AddWithValue("@TitleOfTrade", SqlDbType.VarChar).Value = TradeRenVo.TitleOfTrade;
            }


            if (TradeRenVo.TotalAmount != "" && TradeRenVo.TotalAmount != null)
            {
                cmdEnj.Parameters.AddWithValue("@TotalAmount", SqlDbType.Int).Value = TradeRenVo.TotalAmount;
            }

            if (TradeRenVo.TradeAddress != "" && TradeRenVo.TradeAddress != null)
            {
                cmdEnj.Parameters.AddWithValue("@TradeAddress", SqlDbType.Int).Value = TradeRenVo.TradeAddress;
            }

            if (TradeRenVo.TradeTinno != "" && TradeRenVo.TradeTinno != null)
            {
                cmdEnj.Parameters.AddWithValue("@TradeTinno", SqlDbType.Int).Value = TradeRenVo.TradeTinno;
            }
            if (TradeRenVo.Uid_No != "" && TradeRenVo.Uid_No != null)
            {
                cmdEnj.Parameters.AddWithValue("@Uid_No", SqlDbType.Int).Value = TradeRenVo.Uid_No;
            }

            cmdEnj.ExecuteNonQuery();
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            // cmdEnj.Dispose();
            con.CloseConnection();
        }
    }
    
}
public class TradeRenewalProperties
{
    // GHMC RENEWAL PROPERTIES

    public string intQuessionaireCFOid { get; set; }
    public string intCFOEnterpid { get; set; }
    public string Uid_No { get; set; }
    public string Reg_Id { get; set; }
    public string TradeTinno { get; set; }
    public string TitleOfTrade { get; set; }
    public string TradeAddress { get; set; }
    public string CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string SubCategoryID { get; set; }
    public string SubCategory { get; set; }
    public string PlinthArea { get; set; }
    public string RoadTypeId { get; set; }
    public string RoadTypeName { get; set; }
    public string NameofOwner { get; set; }
    public string AddressofOwner { get; set; }
    public string ArrearsAmountLicence { get; set; }
    public string ArrearsAmountLicenseinterest { get; set; }
    public string CurrentLicenceFee { get; set; }
    public string CurrentLicenceFeeInterest { get; set; }
    public string ArrearGarbageCharges { get; set; }
    public string CurrentGarbageCharges { get; set; }
    public string TotalAmount { get; set; }
    public string intStageid { get; set; }
    public string licenceValidFrom { get; set; }
    public string licenceValidUpto { get; set; }
    public string Created_by { get; set; }
    public string Created_dt { get; set; }
    public string Modified_by { get; set; }
    public string Modified_dt { get; set; }
    public string intDeptid { get; set; }
    public string intApprovalid { get; set; }

}