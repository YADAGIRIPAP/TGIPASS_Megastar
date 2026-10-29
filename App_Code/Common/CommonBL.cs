using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web;

/// <summary>
/// Summary description for CommonBL
/// </summary>
public class CommonBL
{
    Globavaribles gbp = new Globavaribles();
    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    public string sss { get; set; }    

    public DataSet GetConstitutionunit()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETCONSTITUTIONUNIT", con.GetConnection);
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

    public DataSet GetenterpriseSectors()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GETENTERPRISESECTORS", con.GetConnection);
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
    public DataSet GetApplicationType(int Loc_of_unitid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_APPLICATION_TYPE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Loc_of_unitid", Loc_of_unitid);
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
    public DataSet GetLOcationofUnitNew(string intDistrictid, string intMandalid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("[GET_LOCATIONOFUNITBYDISTRICT_UNITCD]", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null)
                da.SelectCommand.Parameters.AddWithValue("@intDistrictid", null);
            else
                da.SelectCommand.Parameters.AddWithValue("@intDistrictid", intDistrictid);


            if (intMandalid.Trim() == "" || intMandalid.Trim() == null)
                da.SelectCommand.Parameters.AddWithValue("@intMandalid", null);
            else
                da.SelectCommand.Parameters.AddWithValue("@intMandalid", intMandalid);



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

    public DataSet GetHPPowerdetails()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HP_POWER", con.GetConnection);
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
    public DataSet GetMeasureMents()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_MeasureMents", con.GetConnection);
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
    public int UpdateUserPassword(string Name, Byte[] Image, string NameOfMinister, string Designation, string News, string CrtdtUser, string Type)
    {
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("[USP_INSERT_NEW_GALLARY]", con.GetConnection);

        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@Name", Convert.ToString(Name));
            cmd.Parameters.AddWithValue("@NameOfMinister", Convert.ToString(NameOfMinister));
            cmd.Parameters.AddWithValue("@Designation", Convert.ToString(Designation));
            cmd.Parameters.AddWithValue("@News", Convert.ToString(News));
            cmd.Parameters.AddWithValue("@Image", Image);
            cmd.Parameters.AddWithValue("@CrtdtUser", Convert.ToString(CrtdtUser));
            cmd.Parameters.AddWithValue("@Transtype", Convert.ToString(Type));
            cmd.Parameters.Add("@ERROR", SqlDbType.Int, 500);

            cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int strMessage = (Int32)cmd.Parameters["@ERROR"].Value;

            con.CloseConnection();
            return strMessage;
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
    }
    public DataSet GetHomepagecontete()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_HOMEPAGE_CONTENT", con.GetConnection);
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
    public DataSet GetCurrencymaster()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_CURRENCY_MST", con.GetConnection);
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
    public DataSet GetIALAParks(int IALACode, int DistrictCd)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_IALA_INDUSTRIALPARKS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IALACode != null && IALACode != 0)
                da.SelectCommand.Parameters.AddWithValue("@IALA_Cd", IALACode);
            if (DistrictCd != null && DistrictCd != 0)
                da.SelectCommand.Parameters.AddWithValue("@DISTRICTCD", DistrictCd);

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

    public DataSet GetIALAParks_Incentives(int IALACode, int DistrictCd)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_IALA_INDUSTRIALPARKS_INCENTIVES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (IALACode != null && IALACode != 0)
                da.SelectCommand.Parameters.AddWithValue("@IALA_Cd", IALACode);
            if (DistrictCd != null && DistrictCd != 0)
                da.SelectCommand.Parameters.AddWithValue("@DISTRICTCD", DistrictCd);

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

    public DataSet GetIALANAME(int DistrictCd)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_IALANAME", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (DistrictCd != null && DistrictCd != 0)
                da.SelectCommand.Parameters.AddWithValue("@DISTRICTCD", DistrictCd);

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
    public DataSet GetApplicationTypeNew(int Loc_of_unitid, string TourismFlag)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_APPLICATION_TYPE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Loc_of_unitid", Loc_of_unitid);
            da.SelectCommand.Parameters.AddWithValue("@TourismFlag", TourismFlag);
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

    public string ValidateUser(string PageUserID, string SessionUserID)
    {
        string Valid = "0";
        if (PageUserID != "" && SessionUserID != "")
        {
            if (PageUserID != SessionUserID)
            {
                Valid = "1";
            }
        }
        return Valid;
    }

}


public class LabourShopServiceVo
{
    public string QuestionnaireCFOId { get; set; }
    public string intCFEOnterpid { get; set; }
    public string Form1_2_Est_Compltd_Dt { get; set; }
    public string max_employees_aday { get; set; }
    public string date_commencement { get; set; }
    public string total_amount_payable { get; set; }
    public string valid_from_date { get; set; }
    public string valid_to_date { get; set; }
    public string transaction_date { get; set; }
    public string registration_fee { get; set; }
    public string registration_years { get; set; }
    public string penality_years { get; set; }
    public string penality_percentage { get; set; }
    public string compound_fee { get; set; }
    public string total_registration_fee { get; set; }
    public string total_penality_amount { get; set; }
    public string oldRegistrationYears2016 { get; set; }
    public string newRegistrationYears2017 { get; set; }
    public string oldPenalityYears2016 { get; set; }
    public string newPenalityYears2017 { get; set; }
    public string oldPenalityAmount2016 { get; set; }
    public string newPenalityAmount2017 { get; set; }
    public string oldRegistrationAmount2016 { get; set; }
    public string newRegistrationAmount2017 { get; set; }
    public string Created_by { get; set; }
    public string Approvalid { get; set; }
}

public class QuesionerVO
{
    public string ExciseLabel
    {
        get;
        set;
    }
    public string ExciseBrand
    {
        get;
        set;
    }
    public string ExciseImport
    {
        get;
        set;
    }
    public string ExciseExport
    {
        get;
        set;
    }


    public string FDC
    {
        get;
        set;
    }
   
    public string NoofworkersContractor
    {
        get;
        set;
    }
    public string CommencemantdateContractor
    {
        get;
        set;
    }

    public string BoilerManufactuer
    {
        get;
        set;
    }

    public string NoOfFloors
    {
        get;
        set;
    }
    public string annualTurnover
    {
        get;
        set;
    }
    public string annualTurnover_act
    {
        get;
        set;
    }
    public string annualTurnover_Exp
    {
        get;
        set;
    }
    public string annualTurnover_Exp_act
    {
        get;
        set;
    }

    public string Exciseflag
    {
        get;
        set;
    }

    public string Water_reg_from5
    {
        get;
        set;
    }
    public string Water_req_Perday5
    {
        get;
        set;
    }

    public string BPFilenumber
    {
        get;
        set;
    }

    public string ArchitectLicNumber
    {
        get;
        set;
    }
    public string Occupancyflag
    {
        get;
        set;
    }

    public string professiontaxflag
    {
        get;
        set;
    }
    public string Water_reg_from4
    {
        get;
        set;
    }
    public string Water_req_Perday4
    {
        get;
        set;
    }

    public string Borewellflag
    {
        get;
        set;
    }

    public string Remarks
    {
        get;
        set;
    }

    public string CEIG
    {
        get;
        set;
    }

    public string RegulationType
    {
        get;
        set;
    }
    public string VoltageType
    {
        get;
        set;
    }
    public string AggregateCapacity
    {
        get;
        set;
    }

    public string SteamPipeline
    {
        get;
        set;
    }

    public string VicinityWater
    {
        get;
        set;
    }

    public string MarketValue
    {
        get;
        set;
    }
    public string LabelConfirmation
    {
        get;
        set;
    }
    public string LabourActID
    {
        get;
        set;
    }
    public string IALAFlag
    {
        get;
        set;
    }
    public string IALA_Code
    {
        get;
        set;
    }

    public string intQuessionaireid
    {
        get;
        set;
    }
    public string Const_of_unit
    {
        get;
        set;
    }
    public string Sector_Ent
    {
        get;
        set;
    }
    public string Tot_Extent
    {
        get;
        set;
    }
    public string TxtTot_ExtentNew
    {
        get;
        set;
    }
    public string TxtTot_Gunthas
    {
        get;
        set;
    }
    public string Prop_intDistrictid
    {
        get;
        set;
    }
    public string Prop_intMandalid
    {
        get;
        set;
    }
    public string Prop_intVillageid
    {
        get;
        set;
    }
    public string Prop_Emp
    {
        get;
        set;
    }
    public string Val_Land
    {
        get;
        set;
    }
    public string Val_Build
    {
        get;
        set;
    }
    public string Val_Plant
    {
        get;
        set;
    }
    public string Tot_PrjCost
    {
        get;
        set;
    }
    public string Ent_is
    {
        get;
        set;
    }
    public string intLineofActivity
    {
        get;
        set;
    }
    public string Pol_Indus
    {
        get;
        set;
    }
    public string Pol_Category
    {
        get;
        set;
    }
    public string Power_Req
    {
        get;
        set;
    }
    public string Loc_of_unit
    {
        get;
        set;
    }
    public string Water_req_Perday
    {
        get;
        set;
    }
    public string Water_req_Perday1
    {
        get;
        set;
    }
    public string Water_req_Perday2
    {
        get;
        set;
    }
    public string Water_req_Perday3
    {
        get;
        set;
    }
    public string Water_reg_from1
    {
        get;
        set;
    }
    public string Water_reg_from2
    {
        get;
        set;
    }
    public string Water_reg_from3
    {
        get;
        set;
    }
    public string Do_Store_Kerosine
    {
        get;
        set;
    }
    public string Gen_Reqired
    {
        get;
        set;
    }
    public string Hight_Build
    {
        get;
        set;
    }
    public string
                      Built_up_Area
    {
        get;
        set;
    }
    public string Fall_in_Municipal
    {
        get;
        set;
    }
    public string Prop_Site
    {
        get;
        set;
    }
    public string Appl_Status
    {
        get;
        set;
    }
    public string Appl_no
    {
        get;
        set;
    }
    public string Created_by
    {
        get;
        set;
    }
    public string NoofTrees
    {
        get;
        set;
    }
    public string Non_Exempted
    {
        get;
        set;
    }
    public string Appl_Type
    {
        get;
        set;
    }
    public string nameofunit
    {
        get;
        set;
    }
    public string TypeofMesurement
    {
        get;
        set;
    }
    public string CurrencyType
    {
        get;
        set;
    }
    public string Val_Land_Actul
    {
        get;
        set;
    }
    public string Val_Build_Actul
    {
        get;
        set;
    }
    public string Val_Plant_Actul
    {
        get;
        set;
    }
    // Expansion
    public string Val_LandExpansion
    {
        get;
        set;
    }
    public string Val_BuildExpansion
    {
        get;
        set;
    }
    public string Val_PlantExpansion
    {
        get;
        set;
    }
    public string Tot_PrjCostExpansion
    {
        get;
        set;
    }
    public string Val_Land_ActulExpansion
    {
        get;
        set;
    }
    public string Val_Build_ActulExpansion
    {
        get;
        set;
    }
    public string Val_Plant_ActulExpansion
    {
        get;
        set;
    }
    public string ProposalFor
    {
        get;
        set;
    }
    public string TotalNoofWorkes
    {
        get;
        set;
    }
    public string TotalNoofWorkesforContractLbr
    {
        get;
        set;
    }
    public string TotalNoofWorkesformigrantact
    {
        get;
        set;
    }
    public string txtDateofCommenceAct1
    {
        get;
        set;
    }
    public string PCBCFO
    {
        get;
        set;
    }
    public string FactoryCFO
    {
        get;
        set;
    }
    public string FireCFO
    {
        get;
        set;
    }
    public string DurgCFO
    {
        get;
        set;
    }
    public string BoilerCFO
    {
        get;
        set;
    }
    public string HTMeter
    {
        get;
        set;
    }
    public string TsiicPlotno
    {
        get;
        set;
    }

    public string TotalNoofWorkesformigrantact20d
    {
        get;
        set;
    }
    public string TotalNoofWorkesContractLabourAct_Lisense
    {
        get;
        set;
    }
    public string petrolDieselFlag
    {
        get;
        set;
    }
    public string TourismFlag
    {
        get;
        set;
    }
    public string OwnedLease
    {
        get;
        set;
    }
    public string NoofRooms
    {
        get;
        set;
    }
    public string Outlets
    {
        get;
        set;
    }
    public string Banquets
    {
        get;
        set;
    }
    public string PoliceNOCFlag
    {
        get;
        set;
    }
    public string ParkingConditionFlag
    {
        get;
        set;
    }
    public string Excavation_Flag
    {
        get;
        set;
    }
    public string StorageConstruction_Flag
    {
        get;
        set;
    }
    public string ParkingCondition
    {
        get;
        set;
    }
    public string StorageConstruction
    {
        get;
        set;
    }
    public string HotelType
    {
        get;
        set;
    }

    public string Classification_Rating
    {
        get;
        set;
    }
    public string Bar_License
    {
        get;
        set;
    }
    public string Trade_License
    {
        get;
        set;
    }
    public string HealthSDG_License
    {
        get;
        set;
    }
    public string FSSAI_Certificate
    {
        get;
        set;
    }
    public string HotelClassification
    {
        get;
        set;
    }

    public string CinematographicLicense
    {
        get;
        set;
    }
    public string LicensePeriod
    {
        get;
        set;
    }
    public string Noofscreens
    {
        get;
        set;
    }
    public string TotalFee
    {
        get;
        set;
    }
    public string HotelCFOFlag
    {
        get;
        set;
    }
    public string HotelCFEFlag
    {
        get;
        set;
    }
    
}

public class UserRegistrationVo
{

    public string Firstname
    {
        get;
        set;
    }
    public string Lastname
    {
        get;
        set;
    }
    public string Email
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }
    public string PANcardno
    {
        get;
        set;
    }
    public string MobileNo
    {
        get;
        set;
    }
    public string username
    {
        get;
        set;
    }
    public string AadharNo
    {
        get;
        set;
    }
    public string Password
    {
        get;
        set;
    }
    public string OTPMail
    {
        get;
        set;
    }
    public string OTPMsg
    {
        get;
        set;
    }

    public string Pwdflag
    {
        get;
        set;
    }
}

public class paymentresponseVOs
{
    public string SUBMID
    {
        get;
        set;
    }

    public string MerchantID_0
    {
        get;
        set;
    }
    public string CustomerID_1
    {
        get;
        set;
    }
    public string TxnReferenceNo_2
    {
        get;
        set;
    }
    public string BankReferenceNo_3
    {
        get;
        set;
    }
    public string TxnAmount_4
    {
        get;
        set;
    }
    public string BankID_5
    {
        get;
        set;
    }
    public string BIN_6
    {
        get;
        set;
    }
    public string TxnType_7
    {
        get;
        set;
    }
    public string CurrencyName_8
    {
        get;
        set;
    }
    public string ItemCode_9
    {
        get;
        set;
    }
    public string SecurityType_10
    {
        get;
        set;
    }
    public string SecurityID_11
    {
        get;
        set;
    }
    public string SecurityPassword_12
    {
        get;
        set;
    }
    public string TxnDate_13
    {
        get;
        set;
    }
    public string AuthStatus_14
    {
        get;
        set;
    }
    public string SettlementType_15
    {
        get;
        set;
    }
    public string AdditionalInfo1_16
    {
        get;
        set;
    }
    public string AdditionalInfo2_17
    {
        get;
        set;
    }
    public string AdditionalInfo3_18
    {
        get;
        set;
    }
    public string AdditionalInfo4_19
    {
        get;
        set;
    }
    public string AdditionalInfo5_20
    {
        get;
        set;
    }
    public string AdditionalInfo6_21
    {
        get;
        set;
    }
    public string AdditionalInfo7_22
    {
        get;
        set;
    }
    public string ErrorStatus_23
    {
        get;
        set;
    }
    public string ErrorDescription_24
    {
        get;
        set;
    }
    public string CheckSum_25
    {
        get;
        set;
    }
    public string Createdby
    {
        get;
        set;
    }
}

public class paymendepartwisetresponseVOs
{
    public string Questionnaireid
    {
        get;
        set;
    }
    public string intApprovalid
    {
        get;
        set;
    }
    public string intEnterprenerid
    {
        get;
        set;
    }
    public string Departmentid
    {
        get;
        set;
    }
    public string Createdby
    {
        get;
        set;
    }
    public string MerchantID_0
    {
        get;
        set;
    }
    public string DeptAmount
    {
        get;
        set;
    }
    public string CustomerID_1
    {
        get;
        set;
    }
    public string TxnReferenceNo_2
    {
        get;
        set;
    }
    public string BankReferenceNo_3
    {
        get;
        set;
    }
    public string TxnAmount_4
    {
        get;
        set;
    }
    public string BankID_5
    {
        get;
        set;
    }
    public string BIN_6
    {
        get;
        set;
    }
    public string TxnType_7
    {
        get;
        set;
    }
    public string CurrencyName_8
    {
        get;
        set;
    }
    public string ItemCode_9
    {
        get;
        set;
    }
    public string SecurityType_10
    {
        get;
        set;
    }
    public string SecurityID_11
    {
        get;
        set;
    }
    public string SecurityPassword_12
    {
        get;
        set;
    }
    public string TxnDate_13
    {
        get;
        set;
    }
    public string AuthStatus_14
    {
        get;
        set;
    }
    public string SettlementType_15
    {
        get;
        set;
    }
    public string AdditionalInfo1_16
    {
        get;
        set;
    }
    public string AdditionalInfo2_17
    {
        get;
        set;
    }
    public string AdditionalInfo3_18
    {
        get;
        set;
    }
    public string AdditionalInfo4_19
    {
        get;
        set;
    }
    public string AdditionalInfo5_20
    {
        get;
        set;
    }
    public string AdditionalInfo6_21
    {
        get;
        set;
    }
    public string AdditionalInfo7_22
    {
        get;
        set;
    }
    public string ErrorStatus_23
    {
        get;
        set;
    }
    public string ErrorDescription_24
    {
        get;
        set;
    }
    public string CheckSum_25
    {
        get;
        set;
    }
    public string AdditionalPaymentFlag
    {
        get;
        set;
    }

    public string HDRemarks
    {
        get;
        set;
    }
    public string HDid
    {
        get;
        set;
    }
    public string Ipaddress
    {
        get;
        set;
    }
    public string TransactionType
    {
        get;
        set;
    }
    public string DocPath
    {
        get;
        set;
    }
    public string TypeofOfflineUpdate
    {
        get;
        set;
    }
}
public class LabourActVO
{
    public string RegActId
    {
        get;
        set;
    }
    public string LicenseRegNo
    {
        get;
        set;
    }

    public string EstClassification
    {
        get;
        set;
    }
    public string CategoryofEstablishment
    {
        get;
        set;
    }
    public string NameofShopAct1
    {
        get;
        set;
    }
    public string ShopDoorNo
    {
        get;
        set;
    }
    public string ShopLocality
    {
        get;
        set;
    }
    public string ShopDistrict
    {
        get;
        set;
    }

    public string ManagerPINCode
    {
        get;
        set;
    }

    public string ManagerAddress
    {
        get;
        set;
    }

    public string ShopMandal
    {
        get;
        set;
    }
    public string ShopVillage
    {
        get;
        set;
    }
    public string ShopPincode
    {
        get;
        set;
    }

    public DataTable LabourWorkPlaceTable
    {
        get;
        set;
    }
    public string NameofUnitAct1
    {
        get;
        set;
    }
    public string PGNameAct1
    {
        get;
        set;
    }
    public string EmpDesignation
    {
        get;
        set;
    }
    public string AgeAct1
    {
        get;
        set;
    }
    public string MobileAct1
    {
        get;
        set;
    }
    public string EmailAct1
    {
        get;
        set;
    }
    public string DoorNoResidentialAct1
    {
        get;
        set;
    }
    public string LocalResidentialAct1
    {
        get;
        set;
    }
    public string DistrictResidentialAct1
    {
        get;
        set;
    }
    public string MandalResidentialAct1
    {
        get;
        set;
    }
    public string VillageResidentialAct1
    {
        get;
        set;
    }
    public string ManagerResidenceAct1
    {
        get;
        set;
    }
    public string ManagerNameAct1
    {
        get;
        set;
    }
    public string ManagerPGNameAct1
    {
        get;
        set;
    }
    public string ManagerDesignationAct1
    {
        get;
        set;
    }
    public string ManagerDoorNo
    {
        get;
        set;
    }
    public string ManagerLocalityAct1
    {
        get;
        set;
    }
    public string ManagerDistrictAct1
    {
        get;
        set;
    }
    public string ManagerMandalAct1
    {
        get;
        set;
    }
    public string ManagerVillageAct1
    {
        get;
        set;
    }
    public string ManagerMobileNo
    {
        get;
        set;
    }
    public string ManagerEmail
    {
        get;
        set;
    }
    public string NatureofBusinessAct1
    {
        get;
        set;
    }
    public string DateofCommenceAct1
    {
        get;
        set;
    }
    public DataTable FamilyMembersAct1
    {
        get;
        set;
    }
    public int TotalEmployees
    {
        get;
        set;
    }
    public int Above18Male
    {
        get;
        set;
    }
    public int Below18Male
    {
        get;
        set;
    }
    public int Above18FeMale
    {
        get;
        set;
    }
    public int Below18FeMale
    {
        get;
        set;
    }
    public int intCFEEnterpid
    {
        get;
        set;
    }
    public int TotalBelow18
    {
        get;
        set;
    }
    public int TotalAbove18
    {
        get;
        set;
    }
    public DataTable EmployeesDetails
    {
        get;
        set;
    }

    public int QuestionnaireId
    {
        get;
        set;
    }
    public string Uid_No
    {
        get;
        set;
    }
    public int Reg_Id
    {
        get;
        set;
    }
    public string LabourActId
    {
        get;
        set;
    }
    public string CreatedUser
    {
        get;
        set;
    }
    public int CreatedBy
    {
        get;
        set;
    }
    public string EstdLocation
    {
        get;
        set;
    }
    public string EstdDoorNo
    {
        get;
        set;
    }
    public string EstdDistrict
    {
        get;
        set;
    }
    public string EstdMandal
    {
        get;
        set;
    }
    public string EstdVillage
    {
        get;
        set;
    }
    public string FullNamePrincipalAct4
    {
        get;
        set;
    }
    public string FatherNamePrincipalAct4
    {
        get;
        set;
    }
    public string MobileNoPrincipalAct4
    {
        get;
        set;
    }
    public string EmailIdPrincipalAct4
    {
        get;
        set;
    }
    public string DoorNoPrincipalAct4
    {
        get;
        set;
    }
    public string VillagePrincipalAct4
    {
        get;
        set;
    }
    public string MandalPrincipalAct4
    {
        get;
        set;
    }
    public string DistrictPrincipalAct4
    {
        get;
        set;
    }
    public string DirNameAct4
    {
        get;
        set;
    }
    public string DirDoorNoAct4
    {
        get;
        set;
    }
    public string DirVillageAct4
    {
        get;
        set;
    }
    public string DirMandalAct4
    {
        get;
        set;
    }
    public string DirDistrictAct4
    {
        get;
        set;
    }
    public string ManagerFullNameAct4
    {
        get;
        set;
    }
    public string ManagerDoorNoAct4
    {
        get;
        set;
    }
    public string ManagerDistrictAct4
    {
        get;
        set;
    }
    public string ManagerMandalAct4
    {
        get;
        set;
    }
    public string ManagerVillageAct4
    {
        get;
        set;
    }
    public string NatureofBusinessAct4
    {
        get;
        set;
    }
    public string ContractEmployeesAct4
    {
        get;
        set;
    }
    public DataTable ContractorDetails
    {
        get;
        set;
    }
    public string FullNamePerAct2
    {
        get;
        set;
    }
    public string PerDoorNoAct2
    {
        get;
        set;
    }
    public string PerVillage
    {
        get;
        set;
    }
    public string PerMandal
    {
        get;
        set;
    }
    public string PerDistrict
    {
        get;
        set;
    }
    public string PerPincode
    {
        get;
        set;
    }
    public string CompletionDateAct2
    {
        get;
        set;
    }





    //added by chinna


    public string Firmname { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string FName { get; set; }
    public string DoorNo { get; set; }
    public string Locality { get; set; }
    public string District { get; set; }
    public string Mandal { get; set; }
    public string Village { get; set; }
    public string pincode { get; set; }
    public string OtherStateAddress { get; set; }
    public string Dob { get; set; }
    public string Age { get; set; }
    public string TypeOfBusiness { get; set; }
    public string EstablishmentNumber { get; set; }
    public string EstablishmentDate { get; set; }
    public string EstablishmentRegCertificateFilename { get; set; }
    public string ConvictedFlag { get; set; }
    public string AnyOrderFlag { get; set; }
    public string AnyEstablishFlag { get; set; }
    public string PEFormVFileName { get; set; }
    public string ConvictedDetails { get; set; }
    public string AnyOrderDate { get; set; }
    public string AnyEstablishDetails { get; set; }
    public string SecurityDepositPaid { get; set; }
    public string SecurityDepositPayable { get; set; }
    public string SecurityDepositChallanNo { get; set; }
    public string SecurityDepositChallanDate { get; set; }

    public string SecurityDepositChallanFilename { get; set; }
    public int? MaxNoEmployed { get; set; }

    public string Principleempnumber { get; set; }
    public string PrincipleempDate { get; set; }
    public string PrincipleempZone { get; set; }

    public string PrincipleempCommenceDate { get; set; }
    public string PrincipleempCommenceEnddate { get; set; }

    public string NoofworkersunderallContractorsofthePrincipalEmployer { get; set; }
}

public class LabourAct2VO2
{
    public int QuestionnaireId
    {
        get;
        set;
    }
    public int intCFEEnterpid
    {
        get;
        set;
    }
    public string Uid_No
    {
        get;
        set;
    }
    public int Reg_Id
    {
        get;
        set;
    }
    public string LabourActId
    {
        get;
        set;
    }
    public string CreatedUser
    {
        get;
        set;
    }
    public int CreatedBy
    {
        get;
        set;
    }
    public string NameAct2
    {
        get;
        set;
    }
    public string LocationAct2
    {
        get;
        set;
    }
    public string ShopDoorNo
    {
        get;
        set;
    }
    public string ShopLocality
    {
        get;
        set;
    }
    public string ShopDistrict
    {
        get;
        set;
    }
    public string ShopMandal
    {
        get;
        set;
    }
    public string ShopVillage
    {
        get;
        set;
    }
    public string ShopPincode
    {
        get;
        set;
    }
    public string FullNamePerAct2
    {
        get;
        set;
    }
    public string PerDoorNoAct2
    {
        get;
        set;
    }
    public string PerVillage
    {
        get;
        set;
    }
    public string PerMandal
    {
        get;
        set;
    }
    public string PerDistrict
    {
        get;
        set;
    }
    public string PerPincode
    {
        get;
        set;
    }
    public string ManagerFullName
    {
        get;
        set;
    }
    public string ManagerDoorNo
    {
        get;
        set;
    }
    public string ManagerStreet
    {
        get;
        set;
    }
    public string ManagerDistrict
    {
        get;
        set;
    }
    public string ManagerMandal
    {
        get;
        set;
    }
    public string ManagerVillage
    {
        get;
        set;
    }

    public string ManagerMobile
    {
        get;
        set;
    }
    public string ManagerEmail
    {
        get;
        set;
    }
    public string NatureofWork
    {
        get;
        set;
    }
    public string MaxWorkersAct2
    {
        get;
        set;
    }
    public string CommensementDateAct2
    {
        get;
        set;
    }
    public string CompletionDateAct2
    {
        get;
        set;
    }
    public string RegActId
    {
        get;
        set;
    }
    public string LicenseRegNo
    {
        get;
        set;
    }

}


public class LabourActVO_ContraactLicense
{

    public string chkZone1
    {
        get;
        set;
    }
    public string chkZone2
    {
        get;
        set;
    }
    public string chkZone3
    {
        get;
        set;
    }

    public string StartDate_duration_contract
    {
        get;
        set;
    }

    public string EndDate_duration_contract
    {
        get;
        set;
    }

    public string NameofContractor_contLic
    {
        get;
        set;
    }

    public string DropDownList7_contLic
    {
        get;
        set;
    }

    public string DropDownList8_contLic
    {
        get;
        set;
    }

    public string DropDownList9_contLic
    {
        get;
        set;
    }

    public string ContAddPincode_contract
    {
        get;
        set;
    }

    public string ContrEmail_contract
    {
        get;
        set;
    }


    public string ContrMobile_contract
    {
        get;
        set;
    }

    public string ContLocality_contract
    {
        get;
        set;
    }

    public string ContOutsideLoc_contract
    {
        get;
        set;
    }
    //txtMaxoEmployees

    public string MaxoEmployees_contract
    {
        get;
        set;
    }

    public string contractConvict_contract
    {
        get;
        set;
    }

    public string contractSuspend_contract
    {
        get;
        set;
    }

    public string rblcontractEst_contract
    {
        get;
        set;
    }

    public string txtDOB_contract
    {
        get;
        set;
    }

    public string PartEstablNumber_contract
    {
        get;
        set;
    }
    //

    public string PartEstablDate_contract
    {
        get;
        set;
    }

    public string NamePrinEmploy_contract
    {
        get;
        set;
    }
    public string DoornoPrinEmploy_contract
    {
        get;
        set;
    }
    public string DistPrinEmploy_contract
    {
        get;
        set;
    }
    public string MandalPrinEmploy_contract
    {
        get;
        set;
    }
    public string VillagePrinEmploy_contract
    {
        get;
        set;
    }
    public string PrinEmployPincode_contract
    {
        get;
        set;
    }

    public string PrinEmploytxtOtherStateAddr_contract
    {
        get;
        set;
    }
    public string DirFullName_contract
    {
        get;
        set;
    }
    public string DirDoorNo_contract
    {
        get;
        set;
    }
    public string DirDistrict_contract
    {
        get;
        set;
    }
    public string DirMandal_contract
    {
        get;
        set;
    }
    public string DirVillage_contract
    {
        get;
        set;
    }


    public string Nameofagentormanager
    {
        get;
        set;
    }
    public string DirDoorNoofagentormanager
    {
        get;
        set;
    }
    public string DirLocalityofagentormanager
    {
        get;
        set;
    }
    public string DirAddressofagentormanager
    {
        get;
        set;
    }
    public string DirDistrictofagentormanager
    {
        get;
        set;
    }
    public string DirMandalofagentormanager
    {
        get;
        set;
    }
    public string DirVillageofagentormanager
    {
        get;
        set;
    }
    public string DirPincodeofagentormanager
    {
        get;
        set;
    }

    public string Age
    {
        get;
        set;
    }


}


public class LabourWorkPlace
{
    public string WorkPlace
    {
        get;
        set;
    }
    public string DoorNo
    {
        get;
        set;
    }
    public string Locality
    {
        get;
        set;
    }
}
public class FamilyMembersAct1
{
    public string FamilyNameAct1
    {
        get;
        set;
    }
    public string RelationshipAct1
    {
        get;
        set;
    }
    public string GenderAct1
    {
        get;
        set;
    }
    public string AdultAct1
    {
        get;
        set;
    }
}
public class EmployeesDetails
{
    public string Occupation
    {
        get;
        set;
    }
    public string EmployeeNameAct1
    {
        get;
        set;
    }
    public string EmployeeGenderAct1
    {
        get;
        set;
    }

}
public class ContractorDetails
{
    public string ContractorName
    {
        get;
        set;
    }
    public string ContractorAddress
    {
        get;
        set;
    }
    public string ContractorMobileNo
    {
        get;
        set;
    }
    public string ContractorWorkNature
    {
        get;
        set;
    }
    public string ContractorWorkMen
    {
        get;
        set;
    }
    public string ContractorCommence
    {
        get;
        set;
    }
    public string ContractorComplete
    {
        get;
        set;
    }
    public string ManufacturingDepts
    {
        get;
        set;
    }
}


public class LegalClass
{
    public int QuestionnaireId
    {
        get;
        set;
    }
    public string Uid_No
    {
        get;
        set;
    }
    public int Reg_Id
    {
        get;
        set;
    }
    public string LabourActId
    {
        get;
        set;
    }
    public string CreatedUser
    {
        get;
        set;
    }
    public int CreatedBy
    {
        get;
        set;
    }
    public int intCFEEnterpid
    {
        get;
        set;
    }


    public string Registration_cd
    {
        get;
        set;
    }
    public string Firm_DoorNo
    {
        get;
        set;
    }
    public string Firm_DistrictCd
    {
        get;
        set;
    }
    public string Firm_MandalCd
    {
        get;
        set;
    }
    public string Firm_VillageCd
    {
        get;
        set;
    }
    public string Firm_Pincode
    {
        get;
        set;
    }

    public string Firm_Landline
    {
        get;
        set;
    }
    public string Firm_EmailId
    {
        get;
        set;
    }
    public string DateofCommencement
    {
        get;
        set;
    }
    public string Premises_Name
    {
        get;
        set;
    }
    public string Premises_DoorNo
    {
        get;
        set;
    }
    public string Premises_DistrictCd
    {
        get;
        set;
    }
    public string Premises_LandLineNo
    {
        get;
        set;
    }
    public string Premises_Pincode
    {
        get;
        set;
    }
    public string Premises_VillageCd
    {
        get;
        set;
    }
    public string Premises_MandalCd
    {
        get;
        set;
    }
    public string Premises_ShortAddress
    {
        get;
        set;
    }
    public string Premises_TradeLicense
    {
        get;
        set;
    }
    public string Tin_Number
    {
        get;
        set;
    }
    public string Label_details
    {
        get;
        set;
    }
    public string Created_by
    {
        get;
        set;
    }

}

public class LegalDirectors
{
    public string Director_Name
    {
        get;
        set;
    }
    public string Director_DoorNo
    {
        get;
        set;
    }
    public string Director_Districtcd
    {
        get;
        set;
    }
    public string Director_MandalCd
    {
        get;
        set;
    }
    public string Director_VillageCd
    {
        get;
        set;
    }
    public string Director_Pincode
    {
        get;
        set;
    }
    public string Director_AadharNo
    {
        get;
        set;
    }


}
public class LegalBrand
{
    public string BrandName
    {
        get;
        set;
    }
}
public class LegalCommodity
{
    public string Commodity_Name
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
}
public class AmmendmentVo
{
    public string Dept_ID
    {
        get;
        set;
    }

    public string Dept_Name
    {
        get;
        set;
    }

    public string Ammendment
    {
        get;
        set;
    }
    public string Ammendment_Date
    {
        get;
        set;
    }
    public string Ammendment_Path
    {
        get;
        set;
    }
    public string UserName
    {
        get;
        set;
    }
    public string District
    {
        get;
        set;
    }
    public string MobileNo
    {
        get;
        set;
    }
    public string MailId
    {
        get;
        set;
    }
    public string Ammendment_Id
    {
        get;
        set;
    }
    public string Comments
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string Amm_FileName
    {
        get;
        set;
    }
    public string Amm_Type
    {
        get;
        set;
    }
}
public class ClusterVo
{
    public int Cluster_Id
    {
        get;
        set;
    }
    public string District_Cd
    {
        get;
        set;
    }
    public string Mandal_Cd
    {
        get;
        set;
    }
    public string Village_Cd
    {
        get;
        set;
    }
    public string LineofActivity
    {
        get;
        set;
    }
    public string Infra_Power
    {
        get;
        set;
    }
    public string Infra_SubStation
    {
        get;
        set;
    }
    public string Infra_Sub_Capacity
    {
        get;
        set;
    }
    public string Infra_Common_Facility
    {
        get;
        set;
    }
    public string Infra_Training_Facility
    {
        get;
        set;
    }
    public string Raw_Material_Source
    {
        get;
        set;
    }
    public string Major_Markets
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string InsertMode
    {
        get;
        set;
    }
}
public class ClusterUnitVo
{

    public string Unit_Type
    {
        get;
        set;
    }
    public string No_Units
    {
        get;
        set;
    }
    public string Investment
    {
        get;
        set;
    }
    public string Employment
    {
        get;
        set;
    }
    public string TurnOver
    {
        get;
        set;
    }
}
public class ClusterExportVo
{
    public string Nameof_Unit
    {
        get;
        set;
    }
    public string Product_Exported
    {
        get;
        set;
    }
    public string Country_Exported
    {
        get;
        set;
    }
    public string QuantumofExports
    {
        get;
        set;
    }
    public string ValueofExports
    {
        get;
        set;
    }
    public string QuantityIn
    {
        get;
        set;
    }
}
public class ClusterIndustryVo
{
    public string NameofIndustry
    {
        get;
        set;
    }
    public string LineofActivity
    {
        get;
        set;
    }
    public string Investment
    {
        get;
        set;
    }
    public string Employment
    {
        get;
        set;
    }
    public string UnitType
    {
        get;
        set;
    }
    public string NoofUnits
    {
        get;
        set;
    }
    public string Turnover
    {
        get;
        set;
    }
    public string Unit_Typevalue
    {
        get;
        set;
    }
}

public class ClusterCommonFacilitiesVO
{
    public string TypeCd
    {
        get;
        set;
    }
    public string Details
    {
        get;
        set;
    }
}


public class LandetailsVo
{
    public string PresentUseofLand
    {
        get;
        set;
    }
    public string LocationSpecify
    {
        get;
        set;
    }
    public string GreenBeltArea
    {
        get;
        set;
    }
    public string BuildTownship
    {
        get;
        set;
    }
    public string TownshipAreaAllocation
    {
        get;
        set;
    }
    public string TownshipDistance
    {
        get;
        set;
    }
    public string TownshipPopulation
    {
        get;
        set;
    }
    public string TownShipWaterConsumption
    {
        get;
        set;
    }
    public string TownShipDisposal
    {
        get;
        set;
    }
    public string TownShipSewerSys
    {
        get;
        set;
    }
    public string TownShipSewageSys
    {
        get;
        set;
    }
    public string TotalEmps_Premises
    {
        get;
        set;
    }
    public string IsprohibittedArea
    {
        get;
        set;
    }
}
public class PCBDetailsVo
{
    public string FaxNo
    {
        get;
        set;
    }
    public string ForeignCollab
    {
        get;
        set;
    }
    public string UseofLand
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }
    public string GreenBeltArea
    {
        get;
        set;
    }
    public string TownShipProposal
    {
        get;
        set;
    }
    public string TownArea_Alloc
    {
        get;
        set;
    }
    public string DistanceFromSite
    {
        get;
        set;
    }
    public string Emp_Population
    {
        get;
        set;
    }
    public string WaterSupply
    {
        get;
        set;
    }
    public string DisposalPoint
    {
        get;
        set;
    }
    public string SewerSys
    {
        get;
        set;
    }
    public string Sewage_TreatMent
    {
        get;
        set;
    }
    public string TotalEmp_Premises
    {
        get;
        set;
    }
    public string Prohibitted_Area
    {
        get;
        set;
    }
    public string Source_Energy
    {
        get;
        set;
    }
    public string Inplant_Generationtype
    {
        get;
        set;
    }

    public string DischargeWasteWater
    {
        get;
        set;
    }
    public string ModeofFinalDischarge
    {
        get;
        set;
    }
    public string PretreatmentNecessary
    {
        get;
        set;
    }
    public string NoisePollution
    {
        get;
        set;
    }
    public string OdourPRoblem
    {
        get;
        set;
    }

    public string ThermalPollution
    {
        get;
        set;
    }
    public string PolMonitoring_Cost
    {
        get;
        set;
    }
    public string PolControl_Cost
    {
        get;
        set;
    }
    public string Recurring_Cost
    {
        get;
        set;
    }
}

public class LandFeatures
{
    public string Feature
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string Distance
    {
        get;
        set;
    }
}
public class WaterSourcePCB
{
    public string Source_Type
    {
        get;
        set;
    }
    public string SourceName
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
}
public class PointofFinalDischargePCB
{
    public string FSource
    {
        get;
        set;
    }
    public string PointofDischarge
    {
        get;
        set;
    }

}
public class WaterConsumptionPCB
{
    public string Purpose
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
}
public class ToxicSubstancePCB
{
    public string Source
    {
        get;
        set;
    }
    public string Substance
    {
        get;
        set;
    }
    public string Name
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
}
public class PhysicalCharactersticsPCB
{
    public string PCSource
    {
        get;
        set;
    }
    public string Temprature
    {
        get;
        set;
    }
    public string PH
    {
        get;
        set;
    }
    public string Colour
    {
        get;
        set;
    }
    public string Turbidity
    {
        get;
        set;
    }
    public string Odour
    {
        get;
        set;
    }
    public string TotalSolids
    {
        get;
        set;
    }
    public string SuspendedSolids
    {
        get;
        set;
    }
    public string VolatileSolids
    {
        get;
        set;
    }
}
public class OtherCharactersticsPCB
{
    public string OSource
    {
        get;
        set;
    }
    public string Item
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
    public string Units
    {
        get;
        set;
    }
}
public class WasteWaterDischargePCB
{
    public string Source
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
}
public class ChemicalDetailsPCB
{
    public string Source
    {
        get;
        set;
    }
    public string Acidity
    {
        get;
        set;
    }
    public string Alkalinity
    {
        get;
        set;
    }
    public string Hardness
    {
        get;
        set;
    }
    public string BOD
    {
        get;
        set;
    }
    public string COD
    {
        get;
        set;
    }
    public string Oil_Greases
    {
        get;
        set;
    }
    public string Nitrogen_Phosphate
    {
        get;
        set;
    }
    public string Sulphates
    {
        get;
        set;
    }
    public string Total_Phosphates
    {
        get;
        set;
    }
    public string Total_Chloride
    {
        get;
        set;
    }
    public string Sodium
    {
        get;
        set;
    }
    public string Potassium
    {
        get;
        set;
    }
    public string Calcium
    {
        get;
        set;
    }
    public string Magnesium
    {
        get;
        set;
    }
}
public class ByProduct
{
    public string Name
    {
        get;
        set;
    }
    public string Capacity
    {
        get;
        set;
    }
    public string Units
    {
        get;
        set;
    }
}

public class StackDetailsPCB
{
    public string StackAttached
    {
        get;
        set;
    }
    public string StackHeight
    {
        get;
        set;
    }
    public string Temprature
    {
        get;
        set;
    }
    public string ExpectedQuantity
    {
        get;
        set;
    }
    public string AirPollution
    {
        get;
        set;
    }
    public string Diameter
    {
        get;
        set;
    }
    public string FlowRate
    {
        get;
        set;
    }
    public string StackHeightGround
    {
        get;
        set;
    }
    public string StackTop
    {
        get;
        set;
    }
    public string EmissionStandards
    {
        get;
        set;
    }

    public string StackCount
    {
        get;
        set;
    }

}

public class StackDetailsFugitivePCB
{
    public string StackAttached
    {
        get;
        set;
    }
    public string StackHeight
    {
        get;
        set;
    }
    public string Temprature
    {
        get;
        set;
    }
    public string ExpectedQuantity
    {
        get;
        set;
    }
    public string AirPollution
    {
        get;
        set;
    }
    public string Diameter
    {
        get;
        set;
    }
    public string FlowRate
    {
        get;
        set;
    }
    public string StackHeightGround
    {
        get;
        set;
    }
    public string StackTop
    {
        get;
        set;
    }
    public string EmissionStandards
    {
        get;
        set;
    }

    public string StackCount
    {
        get;
        set;
    }

}
public class StackDustPCB
{
    public string StackName
    {
        get;
        set;
    }
    public string NatureofDust
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }

}
public class StackDustFugitivePCB
{
    public string StackName
    {
        get;
        set;
    }
    public string NatureofDust
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }

}
public class StackGasesPCB
{
    public string StackName
    {
        get;
        set;
    }
    public string Gases
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }

}
public class StackGasesFugitivePCB
{
    public string StackName
    {
        get;
        set;
    }
    public string Gases
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }

}
public class FuelPCB
{

    public string NameFuel
    {
        get;
        set;
    }
    public string DailyConsumption
    {
        get;
        set;
    }
    public string Purpose
    {
        get;
        set;
    }
    public string Unit
    {
        get;
        set;
    }
}

//public class DirectorDetails_Drug
//{
//    public string Name
//    {
//        get;
//        set;
//    }
//    public string Designation
//    {
//        get;
//        set;
//    }
//    public string Address
//    {
//        get;
//        set;
//    }
//    public string IdProofNo
//    {
//        get;
//        set;
//    }
//    public string EffectiveDate
//    {
//        get;
//        set;
//    }
//    public string CertificateDate
//    {
//        get;
//        set;
//    }
//    public string ProductCategory
//    {
//        get;
//        set;
//    }
//    public string transformerfilepath
//    {
//        get;
//        set;
//    }
//    public string SalesManufacturer
//    {
//        get;
//        set;
//    }
//}

public class DirectorDetails_Drug
{
    public string Name
    {
        get;
        set;
    }
    public string MobileNo
    {
        get;
        set;
    }
    public string Gender
    {
        get;
        set;
    }
    public string Designation
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }
    public string IdProofNo
    {
        get;
        set;
    }
    public string EffectiveDate
    {
        get;
        set;
    }
    public string CertificateDate
    {
        get;
        set;
    }
    public string ProductCategory
    {
        get;
        set;
    }
    public string transformerfilepath
    {
        get;
        set;
    }
    public string SalesManufacturer
    {
        get;
        set;
    }
}


public class PRODUCTS_Drug
{
    public string Name
    {
        get;
        set;
    }
    public string Composition
    {
        get;
        set;
    }
    public string ExportDomestic
    {
        get;
        set;
    }
    public string BrandName
    {
        get;
        set;
    }
    public string ProductCategory
    {
        get;
        set;
    }

}
public class TechStaff_Drug
{
    public string Name
    {
        get;
        set;
    }
    public string Designation
    {
        get;
        set;
    }
    public string Qualification
    {
        get;
        set;
    }
    public string Experience
    {
        get;
        set;
    }
    public string Section
    {
        get;
        set;
    }
    public string IDProof
    {
        get;
        set;
    }
    public string ApprovalSought
    {
        get;
        set;
    }
}
public class HazardousWastePCB
{
    public string Activity
    {
        get;
        set;
    }
    public string Schedule
    {
        get;
        set;
    }
    public string Process
    {
        get;
        set;
    }
    public string HazardousName
    {
        get;
        set;
    }
    public string HazardousDesc
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
    public string Unit
    {
        get;
        set;
    }
    public string Storage
    {
        get;
        set;
    }
    public string Recycle
    {
        get;
        set;
    }
    public string Disposal
    {
        get;
        set;
    }
    public string Existing
    {
        get;
        set;
    }
    public string Proposed
    {
        get;
        set;
    }
    public string Total
    {
        get;
        set;
    }
}
public class NonHazardousWastePCB
{
    public string Description
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
    public string Unit
    {
        get;
        set;
    }
    public string Disposal
    {
        get;
        set;
    }
    public string Existing
    {
        get;
        set;
    }
    public string Proposed
    {
        get;
        set;
    }
    public string Total
    {
        get;
        set;
    }
}

public class formVIVo
{
    public string Enterpid
    {
        get;
        set;
    }
    public string IncentiveID
    {
        get;
        set;
    }
    public string Quessionaireid
    {
        get;
        set;
    }
    public string agencyName
    {
        get;
        set;
    }
    public string CertificateNumber
    {
        get;
        set;
    }
    public string DateofIssue
    {
        get;
        set;
    }
    public string periodofvalidity
    {
        get;
        set;
    }

    public string Amountspentinacquiringthecertification
    {
        get;
        set;
    }
    public string FromCentralGovernment
    {
        get;
        set;
    }
    public string FromStateGovernment
    {
        get;
        set;
    }
    public string Fromfinancinginstitution
    {
        get;
        set;
    }
    public string State
    {
        get;
        set;
    }
    public string Dist
    {
        get;
        set;
    }
    public string Mandal
    {
        get;
        set;
    }
    public string Village
    {
        get;
        set;
    }
    public string DoorNo
    {
        get;
        set;
    }
    public string Pincode
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string Manf_Items
    {
        get;
        set;
    }
}

public class formIXVo
{
    public string Enterpid
    {
        get;
        set;
    }
    public string Quessionaireid
    {
        get;
        set;
    }
    public string Incentiveid
    {
        get;
        set;
    }
    public string Nameofthetraininginstitute
    {
        get;
        set;
    }
    public string Durationoftraining
    {
        get;
        set;
    }
    public string DurationModeoftraining
    {
        get;
        set;
    }
    public string Nameoftheskilldevelopmentprogramme
    {
        get;
        set;
    }
    public string Numberskilledemployees
    {
        get;
        set;
    }
    public string Expenditureincurredtrainingprogramme
    {
        get;
        set;
    }
    public string Amountclaimed
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }

}

public class formVIIIVo
{

    public string Enterpid
    {
        get;
        set;
    }
    public string Quessionaireid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string Nameoftheequipment
    {
        get;
        set;
    }
    public string IncentiveID
    {
        get;
        set;
    }
    public string Nameaddressofsupplier
    {
        get;
        set;
    }
    public string id
    {
        get;
        set;
    }
    public string TotalinRs
    {
        get;
        set;
    }
    public string Othercharges
    {
        get;
        set;
    }
    public string FreightCharge
    {
        get;
        set;
    }
    public string ExciseDuty
    {
        get;
        set;
    }
    public string VATCST
    {
        get;
        set;
    }
    public string Costoftheequipment
    {
        get;
        set;
    }
    public string BillDate
    {
        get;
        set;
    }
    public string BillNo
    {
        get;
        set;
    }
    public string subsidyclaimed
    {
        get;
        set;
    }
}

public class FormIIIPower
{

    public string FinancialYear
    {
        get;
        set;
    }
    public string UnitsConsumed
    {
        get;
        set;
    }
    public string Amount
    {
        get;
        set;
    }
}
public class FormIIIEnergy
{

    public string FinancialYear
    {
        get;
        set;
    }
    public string F_UnitsConsumed
    {
        get;
        set;
    }
    public string F_Amount
    {
        get;
        set;
    }
    public string S_UnitsConsumed
    {
        get;
        set;
    }
    public string S_Amount
    {
        get;
        set;
    }
}
public class FormIV
{

    public string FinancialYear
    {
        get;
        set;
    }
    public string IntrestPaid
    {
        get;
        set;
    }
    public string RateofIntrest
    {
        get;
        set;
    }
    public string IntrestPenaltyPaid
    {
        get;
        set;
    }
    public string Eligible
    {
        get;
        set;
    }
    public string AmountClaimed
    {
        get;
        set;
    }
}
public class FormVProduction
{

    public string FinancialYear
    {
        get;
        set;
    }
    public string Unit
    {
        get;
        set;
    }
    public string Quantity
    {
        get;
        set;
    }
    public string Value
    {
        get;
        set;
    }
}
public class FormVSales
{

    public string FinancialYear
    {
        get;
        set;
    }
    public string F_AmountPaid
    {
        get;
        set;
    }
    public string F_AmountClaimed
    {
        get;
        set;
    }
    public string S_AmountPaid
    {
        get;
        set;
    }
    public string S_AmountClaimed
    {
        get;
        set;
    }
}

public class officerRemarks
{
    public Decimal? Recomamount
    {
        get;
        set;
    }
    public string Incentive
    {
        get;
        set;
    }
    public string land_JD
    {
        get;
        set;
    }
    public string building_JD
    {
        get;
        set;
    }
    public string pnm_JD
    {
        get;
        set;
    }
    public string Remarks
    {
        get;
        set;
    }
    public string status
    {
        get;
        set;
    }
    public string CreatedBy
    {
        get;
        set;
    }
    public string CreatedDate
    {
        get;
        set;
    }
    public string MstIncentiveId
    {
        get;
        set;
    }
    public string EnterperIncentiveID
    {
        get;
        set;
    }
    public string CreatedByid
    {
        get;
        set;
    }
    public string Designation
    {
        get;
        set;
    }
    public string Responce
    {
        get;
        set;
    }
    public string id
    {
        get;
        set;
    }
    public string SLCNO
    {
        get;
        set;
    }
    public string Slcdate
    {
        get;
        set;
    }
    public string SSCdate
    {
        get;
        set;
    }
}
public class GmfinalProceedings
{
    public string MstIncentiveId
    {
        get;
        set;
    }
    public string LoanAggrementAccountNo
    {
        get;
        set;
    }
    public string EnterperIncentiveID
    {
        get;
        set;
    }
    public string SLCNumer
    {
        get;
        set;
    }
    public string nbfcName
    {
        get;
        set;
    }

    public string WorkingStatus
    {
        get;
        set;
    }
    public string CreatedByid
    {
        get;
        set;
    }
    public string Newbankname
    {
        get;
        set;
    }
    public string NewBranchname
    {
        get;
        set;
    }
    public string NewIFSCcode
    {
        get;
        set;
    }
    public string NewAccountType
    {
        get;
        set;
    }
    public string Remarks
    {
        get;
        set;
    }
    public string AccountNumber
    {
        get;
        set;
    }
    public string AccNoConfirmationFlg
    {
        get;
        set;
    }
    public string SubIncTypeId
    {
        get;
        set;
    }


}
public class officerForwarded
{
    public string MstIncentiveId
    {
        get;
        set;
    }
    public string EnterperIncentiveID
    {
        get;
        set;
    }
    public string CreatedByid
    {
        get;
        set;
    }
    public string ApplicationFrom
    {
        get;
        set;
    }
    public string SLCNO
    {
        get;
        set;
    }
    public string Slcdate
    {
        get;
        set;
    }
    public string SVCdate
    {
        get;
        set;
    }
    public string SendTo
    {
        get;
        set;
    }
}
public class ReleasingProceedings
{
    public string SplCase
    {
        get;
        set;
    }

    public string MstIncentiveId
    {
        get;
        set;
    }
    public string EnterperIncentiveID
    {
        get;
        set;
    }
    public string CreatedByid
    {
        get;
        set;
    }
    public string AllotedAmount
    {
        get;
        set;
    }

    public string SLCNo
    {
        get;
        set;
    }
    public string Gono
    {
        get;
        set;
    }
    public string Godate
    {
        get;
        set;
    }
    public string Locdate
    {
        get;
        set;
    }
    public string Locno
    {
        get;
        set;
    }

    public string ReleaseProcedingNo
    {
        get;
        set;
    }

    public string ReleaseProcedingDate
    {
        get;
        set;
    }

    public string Caste
    {
        get;
        set;
    }

    public string SubIncTypeId
    {
        get;
        set;
    }

    public string GoReleaseAmt
    {
        get;
        set;
    }

    public string RemaningAmt
    {
        get;
        set;
    }

    public string ReleasingSlcSpeacCaseAmount
    {
        get;
        set;
    }
    public string ReleasingSlcSpeacCaseDate
    {
        get;
        set;
    }
    public string Remarks
    {
        get;
        set;
    }
    public string GOSpeaclCaseNo
    {
        get;
        set;
    }
    public string PendingAmount
    {
        get;
        set;
    }
    public string SanctionSpecialCaseAmount
    {
        get;
        set;
    }
    public string slno
    {
        get;
        set;
    }


}

public class Stairecases
{
    public string Staireid
    {
        get;
        set;
    }
    public string StaireName
    {
        get;
        set;
    }
    public string Width
    {
        get;
        set;
    }
    public string NoofStairecases
    {
        get;
        set;
    }
    public string id
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }

}
//added by rajinikar
public class minerals
{
    public string mineralid
    {
        get;
        set;
    }
    public string mineral
    {
        get;
        set;
    }
    public string quantity
    {
        get;
        set;
    }
    public string unitid
    {
        get;
        set;
    }
    public string units
    {
        get;
        set;
    }
    public string id
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }

}

public class Deptcomments
{
    public string DeptComments
    {
        get;
        set;
    }
    public string id
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
}

public class LoadParticulars
{
    public string id
    {
        get;
        set;
    }
    public string EquipmentName
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string SerialNo
    {
        get;
        set;
    }
    public string CapacityinKV
    {
        get;
        set;
    }
    public string CapacityinHP
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string LoadUpload
    {
        get;
        set;
    }
    public string capacityloadpath
    {
        get;
        set;
    }
}

public class CircuitBreakerLoad
{
    public string id
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string CBSerialNo
    {
        get;
        set;
    }
    public string CapacityA
    {
        get;
        set;
    }
    public string ISCKA
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string TestCertificateUpload
    {
        get;
        set;
    }
    public string testcertificatefilepath
    {
        get;
        set;
    }
}

public class TransformerTest
{
    public string id
    {
        get;
        set;
    }
    public string Transformer
    {
        get;
        set;
    }
    public string TypeofTransformer
    {
        get;
        set;
    }
    public string Capacity
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string SerialNo
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string VoltageHVLV
    {
        get;
        set;
    }
    public string TransformerTestUpload
    {
        get;
        set;
    }
    public string OilTestUpload
    {
        get;
        set;
    }
    public string transformeruploadfilepath
    {
        get;
        set;
    }
    public string EquipmentName
    {
        get;
        set;
    }
}

public class ABSwitchIsolator
{
    public string id
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }
    public string WithorWithoutEarthSwitch
    {
        get;
        set;
    }
    public string VoltageV
    {
        get;
        set;
    }
    public string CapacityA
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string SerialNo
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string VoltageHVLV
    {
        get;
        set;
    }
    public string TestUpload
    {
        get;
        set;
    }
    public string testuploadpath
    {
        get;
        set;
    }
}

public class LightningArrestor
{
    public string id
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }
    public string VoltageV
    {
        get;
        set;
    }
    public string CapacityA
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string SerialNo
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string VoltageHVLV
    {
        get;
        set;
    }
    public string TestUpload
    {
        get;
        set;
    }
    public string Testuploadfilepath
    {
        get;
        set;
    }
}

public class GeneratorsTestFuel
{
    public string id
    {
        get;
        set;
    }
    public string Location
    {
        get;
        set;
    }

    public string CapacityA
    {
        get;
        set;
    }
    public string Make
    {
        get;
        set;
    }
    public string SerialNo
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string FuelType
    {
        get;
        set;
    }
    public string FuelSource
    {
        get;
        set;
    }
    public string SoxNoxEmission
    {
        get;
        set;
    }
    public string Mercury
    {
        get;
        set;
    }
    public string HeatRateDetails
    {
        get;
        set;
    }
    public string FuelTestUpload
    {
        get;
        set;
    }
    public string FuelTestUploadfilepath
    {
        get;
        set;
    }
}

public class PreCommissioning
{
    public string id
    {
        get;
        set;
    }
    public string Equipment
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string CommissioningUpload
    {
        get;
        set;
    }
    public string CommissioningUploadfilepath
    {
        get;
        set;
    }
}

public class Transmissionlines
{
    public string id
    {
        get;
        set;
    }
    public string Description
    {
        get;
        set;
    }
    public string Enterprenurid
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
    public string TransmissionUpload
    {
        get;
        set;
    }

    public string TransmissionUploadfilepath
    {
        get;
        set;
    }
}

public class BankersRegistrationVo
{

    public string BankName
    {
        get;
        set;
    }
    public string District
    {
        get;
        set;
    }
    public string BranchName
    {
        get;
        set;
    }

    public string BranchNametext
    {
        get;
        set;
    }

    public string IFSCCode
    {
        get;
        set;
    }

    public string username
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }


    public string OTPMail
    {
        get;
        set;
    }
    public string OTPMsg
    {
        get;
        set;
    }

    public string MobileNo
    {
        get;
        set;
    }

    public string Pwdflag
    {
        get;
        set;
    }
}

public class Screendetails
{
    public string CFOEnterprenurid
    {
        get;
        set;
    }
    public string QuessionniareCFOid
    {
        get;
        set;
    }
    public string ScreenNO
    {
        get;
        set;
    }
    public string SeatCapacity
    {
        get;
        set;
    }
    public string ScreenFee
    {
        get;
        set;
    }
    public string Id
    {
        get;
        set;
    }
    public string TotalFee
    {
        get;
        set;
    }
    public string Created_By
    {
        get;
        set;
    }
}