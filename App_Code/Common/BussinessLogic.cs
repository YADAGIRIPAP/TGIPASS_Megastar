using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace BusinessLogic
{
    public class DML
    {

        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        public DataSet InsPCBApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsPCBApprovals", Uid_No, IntApprovalID, weblink, fileName); }

        public DataSet InsPCBPreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsPCBPreScuitinyCompleted", Uid_No, AdditionalPayement); }

        public string InsUpdDelVATReg(string flag, long ID, string RegistrationType, string Act, string CSTRegistration, string ApplicationDate, string Division, string Circle, string PAN, string Name, string DoorNumber, string Street, string Locality, string CityTownVillage, string District, string PIN, string email, DateTime CreatedOn, DateTime ModifiedOn, string Stat, string RNRNo)
        {
            return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDelVATReg", flag, ID, RegistrationType, Act, CSTRegistration, ApplicationDate, Division, Circle, PAN, Name, DoorNumber, Street, Locality, CityTownVillage, District, PIN, email, CreatedOn, ModifiedOn, Stat, RNRNo));
        }

        public DataSet InsUpdDelTSNPDCL_FeasibilityReport(string TSNPDCL_NAMEOFSUBSTN, string TSNPDCL_FEEDER, DateTime TSNPDCL_TF_ISSUEDATE, string TSNPDCL_DESIGN_ISSUEOFFICER, string TSNPDCL_ADE_OPERATION, string TSNPDCL_DE_OPERATION, string TSNPDCL_SE_OPERATION, string TSNPDCL_MOBILE_NO, string TSNPCL_Feasible_NonFeasible, string ReasonForNonFeasible, string UID, string Feasibility_document, string Feasibility_Load) { return SqlHelper.ExecuteDataset(con, "InsUpdDelTSNPDCL_FeasibilityReport", TSNPDCL_NAMEOFSUBSTN, TSNPDCL_FEEDER, TSNPDCL_TF_ISSUEDATE, TSNPDCL_DESIGN_ISSUEOFFICER, TSNPDCL_ADE_OPERATION, TSNPDCL_DE_OPERATION, TSNPDCL_SE_OPERATION, TSNPDCL_MOBILE_NO, TSNPCL_Feasible_NonFeasible, ReasonForNonFeasible, UID, Feasibility_document, Feasibility_Load); }

        public string updMeeSevatbl_Incentive(int IncentiveID, string MeeSevaTransactionNo) { return Convert.ToString(SqlHelper.ExecuteScalar(con, "updMeeSevatbl_Incentive", IncentiveID, MeeSevaTransactionNo)); }

        public string UpdWhetherPower(string Id, string WhetherPower, string RequesttoDept)
        { return Convert.ToString(SqlHelper.ExecuteScalar(con, "UpdWhetherPower", Id, WhetherPower, RequesttoDept)); }

        public DataTable InsUpdDeltblIncentiveMapping(string flag, int MaapingID, int CasteID, int SectorID, bool DIfferentlyAbled, bool Women, bool Minority, bool NewOrOld, bool isNewvh, int Incentive, int Created_by) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltblIncentiveMapping", flag, MaapingID, CasteID, SectorID, DIfferentlyAbled, Women, Minority, NewOrOld, isNewvh, Incentive, Created_by).Tables[0]; }

        public DataTable InsUpdDeltd_Incentive_Uploads(int EntrpID, int IncentiveID, int AttachmentId, string FileNm, string FilePath, int Createdby) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads", EntrpID, IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0]; }

        //public string InsincentiveDtl(int EntprId, int IsNeworExistingEntrepenuer, int Createdby, DataTable IncentiveTransType) { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EntprId, IsNeworExistingEntrepenuer, Createdby, IncentiveTransType)); }

        public string InsincentiveDtl(int EnterperIncentiveID, int IsNeworExistingEntrepenuer, bool isVehicleIncentive, int Createdby, DataTable IncentiveTransType) { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType)); }

        //public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority, string Addressofunit, int mdid, int vlid, int sector, string NatureofBussiness, bool IsGHMCandOtherMuncp)
        //{ return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority, Addressofunit, mdid, vlid, sector, NatureofBussiness, IsGHMCandOtherMuncp)); }

        public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority, string Addressofunit, int mdid, int vlid, int sector, string NatureofBussiness, bool IsGHMCandOtherMuncp, bool isVehicleIncentive, DateTime DCP, string VehicleNumber, bool IsMeeSevaApplication, string MeeSevaUserID, bool IsMeesevaPayDone)
        { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority, Addressofunit, mdid, vlid, sector, NatureofBussiness, IsGHMCandOtherMuncp, isVehicleIncentive, DCP, VehicleNumber, IsMeeSevaApplication, MeeSevaUserID, IsMeesevaPayDone)); }


        public DataSet InsTSSPDCLPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsTSSPDCLPreScuitinyCompleted", Uid, AdditionalPayement); }

        public DataSet InsTSNPDCLPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsTSNPDCLPreScuitinyCompleted", Uid, AdditionalPayement); }

        public string InsUpdDeltbl_Incentive(string EMiUdyogAadhar, string UnitName, string ApplciantName, string Gender, int Caste, string EmailID, string MobileNo, int natureOfAct, int Category, decimal Landvalue, decimal BuildingValue, decimal PlantMachineryValue, decimal EquipmentValue, decimal Total, string landstatus, string BuildingStatus, int District, int TypeofOrg, int TotalEmployment, string BankName, string AccNo, string BranchName, string IFSCCode, int Createdby, bool IsDifferentlyAbled, bool IsWomen, bool IsMinority)
        { return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_Incentive", EMiUdyogAadhar, UnitName, ApplciantName, Gender, Caste, EmailID, MobileNo, natureOfAct, Category, Landvalue, BuildingValue, PlantMachineryValue, EquipmentValue, Total, landstatus, BuildingStatus, District, TypeofOrg, TotalEmployment, BankName, AccNo, BranchName, IFSCCode, Createdby, IsDifferentlyAbled, IsWomen, IsMinority)); }

        public DataSet InsFireApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsFireApprovals", Uid_No, IntApprovalID, weblink, fileName); }


        public DataSet InsFireRejection(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsFireRejection", Uid_No, IntApprovalID, weblink, fileName); }

        //added by chinna 
        public DataTable InsUpdCOI_Incentive_Attachments(int AttachmentType, int IncentiveID, int MasterIncentiveID, int SlcNumber, string FileNm, string FilePath, int Createdby)
        {
            return SqlHelper.ExecuteDataset(con, "usp_InsUpdCOI_Uploads_Incentive", AttachmentType, MasterIncentiveID, IncentiveID, SlcNumber, FileNm, FilePath, Createdby).Tables[0];
        }

        public DataSet InsFactoriesApprovals(string Uid_No, int IntApprovalID, string weblink, string fileName) { return SqlHelper.ExecuteDataset(con, "InsFactoriesApprovals", Uid_No, IntApprovalID, weblink, fileName); }

        public DataSet InsTSNPDCLQueryRaise(string Uid_No, string Remarks, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsTSNPDCLQueryRaise", Uid_No, Remarks, Date, AdditionalPayement); }

        public DataSet InsUpdDelRawmaterial(string flag, int ID, string EMNoUdyogAadhaar, string TypeofApplication, string UnitName, string District, string Mandal, string Address, string RawmaterialforAllotment, string Requirement, string Usagedetails, string ExistingAllotmentOrder, string ValidCFO, string BoilerDetails, string Proofofproductiontillpreviousmonth, string VAT, string RG1Register, string ProcessDescriptionFlowChart, string Createdby, DateTime CreatedDate, string modifiedby, DateTime Modified_dt, string uom) { return SqlHelper.ExecuteDataset(con, "InsUpdDelRawmaterial", flag, ID, EMNoUdyogAadhaar, TypeofApplication, UnitName, District, Mandal, Address, RawmaterialforAllotment, Requirement, Usagedetails, ExistingAllotmentOrder, ValidCFO, BoilerDetails, Proofofproductiontillpreviousmonth, VAT, RG1Register, ProcessDescriptionFlowChart, Createdby, CreatedDate, modifiedby, Modified_dt, uom); }

        public DataSet InsForestQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsForestQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

        public DataSet InsFireQueryRaise(string Uid_No, string Remarks, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsFireQueryRaise", Uid_No, Remarks, Date, AdditionalPayement); }

        public DataSet InsHMDAQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsHMDAQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

        public DataSet InsFactoriesQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsFactoriesQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayement); }

        public DataSet InsPCBQueryRaise(string Uid_No, string QueryDesc, DateTime Date, double AdditionalPayment) { return SqlHelper.ExecuteDataset(con, "InsPCBQueryRaise", Uid_No, QueryDesc, Date, AdditionalPayment); }

        public DataSet InsFirePreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsFirePreScuitinyCompleted", Uid_No, AdditionalPayement); }

        public DataSet InsForestPreScuitinyCompleted(string Uid_No, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsForestPreScuitinyCompleted", Uid_No, AdditionalPayement); }

        public DataSet InsFactoriesPreScuitinyCompleted(string Uid, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsFactoriesPreScuitinyCompleted", Uid, AdditionalPayement); }

        //public DataSet InsFireQueryRaise (string  Uid_No, string  Remarks, DateTime  Date, double  AdditionalPayement)  {  return SqlHelper.ExecuteDataset(con,"InsFireQueryRaise", Uid_No, Remarks, Date, AdditionalPayement);  }

        public DataSet InsQueryRaise(string Uid_No, int IntDeptID, string QueryDesc, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsQueryRaise", Uid_No, IntDeptID, QueryDesc, AdditionalPayement); }

        public DataSet InsPreScuitinyCompleted(string Uid_No, int IntDeptID, double AdditionalPayement) { return SqlHelper.ExecuteDataset(con, "InsPreScuitinyCompleted", Uid_No, IntDeptID, AdditionalPayement); }

        public int InsUpdDeltbl_InspectionDet(string flag, int intInspectionid, string UnitName, string Location_District, string Location_Mandal, string Location_Village, string Inspection_Authority_Desg, DateTime Date_Inspection, DateTime Date_Uploading_Inspection, string Unique_Number, string File_Link, string Department)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(con, "InsUpdDeltbl_InspectionDet", flag, intInspectionid, UnitName, Location_District, Location_Mandal, Location_Village, Inspection_Authority_Desg, Date_Inspection, Date_Uploading_Inspection, Unique_Number, File_Link, Department));
        }

        public DataSet InsUpdDeltbl_CAFFeeDetails(string uid, string Dept, double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL, int CreatedBy) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltbl_CAFFeeDetails", uid, Dept, TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, CreatedBy); }

        public DataSet InsUpdDelTSSPDCL(string TSSPDCL_NAMEOFSUBSTN, string TSSPDCL_EXIS_PTR_CAPACITY, string TSSPDCL_MD_REACHED, string TSSPDCL_PROLOAD_PTR, string TSSPDCL_TOT_PTR, string TSSPDCL_FROMFEEDER, string TSSPDCL_PRESLOAD_FEEDER, string TSSPDCL_NOWPROP_FEEDER, string TSSPDCL_TOT_FEEDER, string TSSPDCL_DEDI_FEEDER, string TSSPDCL_FROM_TSTRANSCO, DateTime TSSPDCL_TF_ISSUEDATE, string TSSPDCL_DESIGN_ISSUEOFFICER, string TSSPDCL_ADE_OPERATION, string TSSPDCL_DE_OPERATION, string TSSPDCL_SE_OPERATION, string TSSPDCL_HT_NO, string TSSPDCL_MOBILE_NO, string UID) { return SqlHelper.ExecuteDataset(con, "InsUpdDelTSSPDCL", TSSPDCL_NAMEOFSUBSTN, TSSPDCL_EXIS_PTR_CAPACITY, TSSPDCL_MD_REACHED, TSSPDCL_PROLOAD_PTR, TSSPDCL_TOT_PTR, TSSPDCL_FROMFEEDER, TSSPDCL_PRESLOAD_FEEDER, TSSPDCL_NOWPROP_FEEDER, TSSPDCL_TOT_FEEDER, TSSPDCL_DEDI_FEEDER, TSSPDCL_FROM_TSTRANSCO, TSSPDCL_TF_ISSUEDATE, TSSPDCL_DESIGN_ISSUEOFFICER, TSSPDCL_ADE_OPERATION, TSSPDCL_DE_OPERATION, TSSPDCL_SE_OPERATION, TSSPDCL_HT_NO, TSSPDCL_MOBILE_NO, UID); }

        public DataSet FetchConstitutionUnit()
        {
            return SqlHelper.ExecuteDataset(con, "USP_GETCONSTITUTIONUNIT");
        }
       
        public DataTable FetchIncentiveViewNew(int CreatedBy, int IncentveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveViewNew", CreatedBy, IncentveID).Tables[0];
        }
        public DataTable FetchIncentiveDtlsbyIncentiveIDNew(string IncentiveId)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveIDNew", IncentiveId).Tables[0];
        }
        public DataTable InsUpdDeltd_Incentive_UploadsIncentives(int IncentiveID, string mastid, int AttachmentId, string FileNm, string FilePath, int Createdby)
        {
            return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads_Incentives", IncentiveID,mastid, AttachmentId, FileNm, FilePath, Createdby).Tables[0];
        }

        public string InsincentiveDtlNew2(int EnterperIncentiveID, int IsNeworExistingEntrepenuer, bool isVehicleIncentive, int Createdby, DataTable IncentiveTransType, string checkSpinning, string FreshSub)
        {
            //return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType));
            return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtlNewIncType", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType, checkSpinning,FreshSub));
        }
        // Incentives New- Endss

        // Incentives Enterprenuer side methods added on 17.06.2017 

        // TypeofIncentivesNew.aspx method
        public string InsincentiveDtlNew(int EnterperIncentiveID, int IsNeworExistingEntrepenuer, bool isVehicleIncentive, int Createdby, DataTable IncentiveTransType)
        {
            //return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtl", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType));
            return Convert.ToString(SqlHelper.ExecuteScalar(con, "InsincentiveDtlNewIncType", EnterperIncentiveID, IsNeworExistingEntrepenuer, isVehicleIncentive, Createdby, IncentiveTransType));
        }

        // SingleUploadsNew.aspx method
        public DataTable InsUpdDeltd_Incentive_UploadsNew(int EntrpID, int IncentiveID, int AttachmentId, string FileNm, string FilePath, int Createdby) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltd_Incentive_Uploads_New", EntrpID, IncentiveID, AttachmentId, FileNm, FilePath, Createdby).Tables[0]; }


    }

    public class Fetch
    {


        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        public DataSet FetchConstitutionUnit()
        {
            return SqlHelper.ExecuteDataset(con, "USP_GETCONSTITUTIONUNIT");
        }
        public DataSet FetchCommissionerates()
        {
            return SqlHelper.ExecuteDataset(con, "USP_GETCOMMISSIONERATES");
        }
        public DataTable FetchIncentiveViewNew(int CreatedBy, int IncentveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncentiveViewNew", CreatedBy, IncentveID).Tables[0];
        }
        public DataTable FetchIncentiveDtlsbyIncentiveIDNew(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveIDNew", IncentiveId).Tables[0]; }


        public DataSet GetTSNPDCLQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetTSNPDCLQueryResponse", Uid_No); }

        public DataSet GetTSSPDCLQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetTSSPDCLQueryResponse", Uid_No); }

        public DataTable IsTSSPDCLTSNPDCL(int intCfeEntrpID) { return SqlHelper.ExecuteDataset(con, "IsTSSPDCLTSNPDCL", intCfeEntrpID).Tables[0]; }

        public DataTable FetchIncentiveMandatoryDocuments(int EntrpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMandatoryDocuments", EntrpID).Tables[0]; }

        public DataSet GETEntrepreneurDetails(string userID) { return SqlHelper.ExecuteDataset(con, "GETEntrepreneurDetails", userID); }

        public DataSet GetPCBQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetPCBQueryResponse", Uid_No); }

        public DataSet GetFirependingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetFirependingApprovalDetails"); }

        public DataSet GetPCBPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetPCBPendingApprovalDetails"); }

        public DataSet GetTSNPDCLPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetTSNPDCLPendingApprovalDetails"); }

        public DataSet GetTSSPDCLPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetTSSPDCLPendingApprovalDetails"); }

        public DataSet GetFactoriesPendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetFactoriesPendingApprovalDetails"); }

        public DataSet GetForestpendingApprovalDetails() { return SqlHelper.ExecuteDataset(con, "GetForestpendingApprovalDetails"); }

        public DataSet GetFactoriesPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetFactoriesPaymentDetails", Uid_No); }

        public DataSet GetTSNPDCLPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetTSNPDCLPaymentDetails", Uid_No); }

        public DataSet GetPCBPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetPCBPaymentDetails", Uid_No); }

        public DataSet GetTSSPDCLPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetTSSPDCLPaymentDetails", Uid_No); }

        public DataSet GetFirePaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetFirePaymentDetails", Uid_No); }

        public DataSet GetFirePaymentDetailsbyDate(string Dates) { return SqlHelper.ExecuteDataset(con, "GetFirePaymentDetailsbyDate", Dates); }

        public DataSet GetForestPaymentDetails(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetForestPaymentDetails", Uid_No); }

        public DataSet GETEntrepreneurwebsrvdtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETEntrepreneurwebsrvdtls", Uid_No); }

        public DataSet GETLandWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETLandWebservicedtls", Uid_No); }

        public DataSet GETPowerWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETPowerWebservicedtls", Uid_No); }

        public DataSet tsipass_get_attachments_TSPDCL_uid(string uid) { return SqlHelper.ExecuteDataset(con, "tsipass_get_attachments_TSPDCL_uid", uid); }

        public DataSet GetUIDDetails()
        {
            DataSet ds = new DataSet("Details");
            return ds = SqlHelper.ExecuteDataset(con, "GetUIDDetails");
        }

        public DataSet GETLineofmanuRawwebsrvdtls(string Uid_NO) { return SqlHelper.ExecuteDataset(con, "GETLineofmanuRawwebsrvdtls", Uid_NO); }

        public DataSet GETWaterWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETWaterWebservicedtls", Uid_No); }

        public DataSet GETFIREWebservicedtls(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GETFIREWebservicedtls", Uid_No); }

        public DataSet GetUIDTSSPDCLDetails() { return SqlHelper.ExecuteDataset(con, "GetUIDTSSPDCLDetails"); }

        public DataSet GetUIDTSNPDCLDetails() { return SqlHelper.ExecuteDataset(con, "GetUIDTSNPDCLDetails"); }

        public DataSet GetTSSPDCLDetails(string UID) { return SqlHelper.ExecuteDataset(con, "GetTSSPDCLDetails", UID); }

        public DataSet GETForestWebservicedtls(string Uid) { return SqlHelper.ExecuteDataset(con, "GETForestWebservicedtls", Uid); }

        public DataSet GetUIDDetailsBydept(string Dept) { return SqlHelper.ExecuteDataset(con, "GetUIDDetailsBydept", Dept); }

        public DataSet GetOfflineApprovalDetBydept(string Dept) { return SqlHelper.ExecuteDataset(con, "GetOfflineApprovalDetBydept", Dept); }

        public DataSet GetFireQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetFireQueryResponse", Uid_No); }
        // public DataSet GetFireQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetFireQueryResponse", Uid_No); }

        public DataSet GetForestQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetForestQueryResponse", Uid_No); }

        public DataSet GETPCBWebservicedtls(string UID) { return SqlHelper.ExecuteDataset(con, "GETPCBWebservicedtls", UID); }

        public DataSet GetFactoriesQueryResponse(string Uid_No) { return SqlHelper.ExecuteDataset(con, "GetFactoriesQueryResponse", Uid_No); }

        public DataSet GetAllAttachments(string Uid) { return SqlHelper.ExecuteDataset(con, "GetAllAttachments", Uid); }

        public DataSet FetchEnterprenuerDetails(string Uid) { return SqlHelper.ExecuteDataset(con, "FetchEnterprenuerDetails", Uid); }

        public DataTable FetchBankMst() { return SqlHelper.ExecuteDataset(con, "FetchBankMst").Tables[0]; }

        public DataTable FetchDistrictMst() { return SqlHelper.ExecuteDataset(con, "FetchDistrictMst").Tables[0]; }

        public DataTable FetchLineofActivity() { return SqlHelper.ExecuteDataset(con, "FetchLineofActivity").Tables[0]; }

        public DataTable FetchCategory() { return SqlHelper.ExecuteDataset(con, "FetchCategory").Tables[0]; }

        public DataTable FetchIncentiveMasterDtl(int EntrpID, int IncentiveType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMasterDtl", EntrpID, IncentiveType).Tables[0]; }

        //public DataSet FetchIncentiveUploads(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploads", EntprId, IncType); }

        public DataTable FetchIncentiveUploads(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploads", EntprId, IncType).Tables[0]; }

        public DataTable FetchIncentiveDtls(string createdby) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtls", createdby).Tables[0]; }

        public DataTable FetchMandals(int disid) { return SqlHelper.ExecuteDataset(con, "FetchMandals", disid).Tables[0]; }

        public DataTable FetchVillages(int VillageId) { return SqlHelper.ExecuteDataset(con, "FetchVillages", VillageId).Tables[0]; }

        public DataTable FetchIncentiveTypes() { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypes").Tables[0]; }

        public DataTable FetchIncentivesyCasterSector(int intCasteID, int IntSector, int IntIncentiveID, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentivesyCasterSector", intCasteID, IntSector, IntIncentiveID, EnterpID).Tables[0]; }

        public DataTable FetchIncentivesbyID(int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesbyID", IncentiveID).Tables[0]; }

        public DataTable FetchIncentiveMst() { return SqlHelper.ExecuteDataset(con, "FetchIncentiveMst").Tables[0]; }

        public DataTable FetchtblIncentiveMapping(int Casteid, int SectorID, bool DiffAbled, bool Women, bool Minority, bool NeworOld, int IncentiveId, bool VehicleIncentive) { return SqlHelper.ExecuteDataset(con, "FetchtblIncentiveMapping", Casteid, SectorID, DiffAbled, Women, Minority, NeworOld, IncentiveId, VehicleIncentive).Tables[0]; }

        public DataTable FetchtblIncentiveMapping_Min(int Casteid, int SectorID, bool DiffAbled, int IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchtblIncentiveMapping_Min", Casteid, SectorID, DiffAbled, IncentiveId).Tables[0]; }

        public DataTable FetchviewIncentive(int EntrpId) { return SqlHelper.ExecuteDataset(con, "FetchviewIncentive", EntrpId).Tables[0]; }

        public DataTable FetchIncentives(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive, int IncentiveType, int EnterpID)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentives", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive, IncentiveType, EnterpID).Tables[0]; }

        public DataTable FetchIncentivesNewINCType(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive, int IncentiveType, int EnterpID, string isSpinningSelected)
        { return SqlHelper.ExecuteDataset(con, "FetchIncentivesNewINCType", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive, IncentiveType, EnterpID, isSpinningSelected).Tables[0]; }
        
        public DataTable FetchIncentiveView(int CreatedBy) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveView", CreatedBy).Tables[0]; }

        public DataTable FetchIncentiveTypesView(int EntrpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypesView", EntrpID).Tables[0]; }

        public DataTable FetchIncetiveUploadsView(int EntrpID, int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsView", EntrpID, IncentiveID).Tables[0]; }

        public DataTable FetchEligibleIncentives(int CasteID, int SectorID, bool IsBelongstoGHMCandOtherMunicipalCorpState, int IsNewIncentive, int CategoryID, bool physicallyhandicapped, bool VehicleIncentive) { return SqlHelper.ExecuteDataset(con, "FetchEligibleIncentives", CasteID, SectorID, IsBelongstoGHMCandOtherMunicipalCorpState, IsNewIncentive, CategoryID, physicallyhandicapped, VehicleIncentive).Tables[0]; }

        public DataTable FetchIncentiveDtls_MeeSeva(string createdby) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtls_MeeSeva", createdby).Tables[0]; }

        public DataTable Fetch_MeeSevaBeforPayment(int IncentiveId) { return SqlHelper.ExecuteDataset(con, "Fetch_MeeSevaBeforPayment", IncentiveId).Tables[0]; }

        public DataTable FetchIncentiveDtlsbyIncentiveID(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveID", IncentiveId).Tables[0]; }

        public DataSet FetchIncentivesApplied(string IncentiveID, string EnterpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesApplied", IncentiveID, EnterpID); }

        // added on 26.11.2017
        public DataSet FetchIncentivesAppliedNewly(string IncentiveID, string EnterpID) { return SqlHelper.ExecuteDataset(con, "FetchIncentivesAppliedNewly", IncentiveID, EnterpID); }

        //public DataSet InsUpdDeltbl_CAFFeeDetails(string uid, string Dept, double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL, int CreatedBy, string Additionalpaymentraiseddate, string DemandNoticeFilepath) { return SqlHelper.ExecuteDataset(con, "InsUpdDeltbl_CAFFeeDetails_New", uid, Dept, TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, CreatedBy, Additionalpaymentraiseddate, DemandNoticeFilepath); }

        public DataSet InsUpdDeltbl_CAFFeeDetails(string uid, string Dept, double TSSPDCL_DEVL_CHRGS, double TSSPDCL_SEC_DEP, double TSSPDCL_SUP_CHRGS, double TSSPDCL_COST_MATERIAL,
            int CreatedBy, string Additionalpaymentraiseddate, string DemandNoticeFilepath,
           string RegistrationNo, string AccountNumber, string IFSCCode, string BankName, string StatusCode, string StatusDescription,
string PaymentDureDate, string TypeofWork, string DTRSdAmount, string Total_Fee)
        {
            return SqlHelper.ExecuteDataset(con, "InsUpdDeltbl_CAFFeeDetails_New", uid, Dept, TSSPDCL_DEVL_CHRGS, TSSPDCL_SEC_DEP, TSSPDCL_SUP_CHRGS, TSSPDCL_COST_MATERIAL, CreatedBy, Additionalpaymentraiseddate, DemandNoticeFilepath,
            RegistrationNo, AccountNumber, IFSCCode, BankName, StatusCode, StatusDescription, PaymentDureDate, TypeofWork, DTRSdAmount, Total_Fee);
        }

        public DataTable FetchIncetiveUploadsViewNewINCType(int EntrpID, int IncentiveID)
        {
            return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsViewNewINCType", EntrpID, IncentiveID).Tables[0]; // FetchIncetiveUploadsView_NewIncType
        }

        // added on 17.06.2017
        public DataTable FetchIncentiveUploadsNewINCType(int EntprId, int IncType) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveUploadsNewINCType", EntprId, IncType).Tables[0]; }

        public DataTable FetchIncentiveTypesView_NewIncType(int EntrpID,string incID) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveTypesView_NewIncType", EntrpID,"0").Tables[0]; }

        public DataTable FetchIncentiveDtlsbyIncentiveID_NewIncType(string IncentiveId) { return SqlHelper.ExecuteDataset(con, "FetchIncentiveDtlsbyIncentiveID_NewIncType", IncentiveId).Tables[0]; }

        public DataTable FetchIncetiveUploadsViewNewIncType(int EntrpID, int IncentiveID) { return SqlHelper.ExecuteDataset(con, "FetchIncetiveUploadsView_NewIncType", EntrpID, IncentiveID).Tables[0]; }

        public DataSet GETEntrepreneurDetailsRenewals(string userID) { return SqlHelper.ExecuteDataset(con, "GETEntrepreneurDetailsRenewals", userID); }
    }

}
