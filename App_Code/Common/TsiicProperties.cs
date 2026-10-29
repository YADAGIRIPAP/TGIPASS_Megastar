using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TsiicProperties
/// </summary>
public class TsiicProperties
{
    public string PlotNoID { get; set; }
    public Int64 ApplicationId { get; set; }
    public string DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string IndustrialParkId { get; set; }
    public string IndustrialParkName { get; set; }
    public string PlotNo { get; set; }
    public decimal Areain_Sq_Mtrs { get; set; }
    public decimal Price_inRs { get; set; }
    public decimal EMD_inRs { get; set; }
    public string Created_by { get; set; }
    public decimal ProcessFee { get; set; }
    public decimal CGST { get; set; }
    public string plotdescripton { get; set; }
    public decimal PerSqrmtrPrice_inRs { get; set; }   
   
}

public class Additionalpromotor
{
    public Int64 ApplicationId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Int64 ContactNo { get; set; }
    public string Qualification { get; set; }
    public string Experience { get; set; }
    public decimal Networth { get; set; }
    public Int64 createdby { get; set; }

}


public class proposedproduct
{
    public Int64 ApplicationId { get; set; }
    public string product { get; set; }
    public string productcode { get; set; }
    public string unitmwasurenent { get; set; }
    public string installedcapacity { get; set; }
    public Int64 createdby { get; set; }
}





public class materialmanufacturing
{
    public int ApplicationId { get; set; }
    public string Describeitem { get; set; }
    public string Itemcode { get; set; }
    public string dailyconsumption { get; set; }
    public string unitmeasurement { get; set; }
    public int createdby { get; set; }


}


//public class TsiicPropertiesMain
//{
//    public int ApplicationId { get; set; }
//    public string DistrictId { get; set; }
//    public string IndustrialParkId { get; set; }
//    public decimal PlotTotalamount { get; set; }
//    public decimal ProcessFee { get; set; }
//    public decimal CGST { get; set; }
//    public decimal SGST { get; set; }
//    public decimal Amounttobepaid { get; set; }
//    public string Created_by { get; set; }
//}


[Serializable]
public class TsiicPropertiesMain
{
    public string IndustrialParkNAME { get; set; }
    public string PlotID { get; set; }
    public Int64 ApplicationId { get; set; }
    public string DistrictId { get; set; }
    public string IndustrialParkId { get; set; }
    public decimal PlotTotalArea { get; set; }
    public decimal PlotTotalamount { get; set; }
    public decimal TotalEmd { get; set; }
    public decimal ProcessFee { get; set; }
    public decimal CGST { get; set; }
    public decimal SGST { get; set; }
    public decimal Amounttobepaid { get; set; }
    public string Created_by { get; set; }
    public string Caste { get; set; }
}
public class TsiicAttachment
{
    public string Processflowchart { get; set; }
    public string UdyogAadharAcknowledgent  { get; set; }
    public string Partnershipdeed { get; set; }
    public string PlantandMachinery { get; set; }
    
    public string communityandcastecertificate { get; set; }

    public string CertificatecopyAddress { get; set; }
    public string Pancardaddress { get; set; }
    public string photographapplicant { get; set; }
    public string Financialclosure { get; set; }
    public string Onlinepaymentreceiptapplicant { get; set; }
    public string GstRegistration { get; set; }
    public string Anyotherrelevantdocuments { get; set; }
}

public class TsiicMainApplicantDtls
{

    public string BankName { get; set; }
    public string BranchName { get; set; }
    public string Ifsccode { get; set; }
    public string AccountNo { get; set; }
    public string TypeofAccount { get; set; }
    public string AccountHolderName { get; set; }


    public string PageSaveNumber { get; set; }
    public Int64 ApplicationId { get; set; }
    public string NameOftheFirm_Applicant { get; set; }
    public string Door_No_RegOffice { get; set; }
    public string Street_1_RegOffice { get; set; }
    public string Street_2_RegOffice { get; set; }
    public Int64 State_RegOffice { get; set; }
    public Int64 Distid_RegOffice { get; set; }
    public Int64 Mandal_RegOffice { get; set; }
    public Int64 Village_RegOffice { get; set; }
    public string OtherState_RegOffice_flag { get; set; }
    public string DistName_RegOffice { get; set; }
    public string MandalName_RegOffice { get; set; }
    public string VillageName_RegOffice { get; set; }
    public Int64 Pincode_RegOffice { get; set; }
    public Int64 TelephonoNo1_RegOffice { get; set; }
    public Int64 TelephonoNo2_RegOffice { get; set; }
    public string FaxNo1_RegOffice { get; set; }
    public string FaxNo2_RegOffice { get; set; }
    public string Category_RegOffice { get; set; }
    public string TypeofOrganization_RegOffice { get; set; }
    public string GovtDeptName_RegOffice { get; set; }
    public string DiffCommunicationAddr_Flag { get; set; }


    public string Door_No_CommAddr { get; set; }
    public string Street_1_CommAddr { get; set; }
    public string Street_2_CommAddr { get; set; }
    public Int64 State_CommAddr { get; set; }
    public Int64 Distid_CommAddr { get; set; }
    public Int64 Mandal_CommAddr { get; set; }
    public Int64 Village_CommAddr { get; set; }
    public string OtherState_CommAddr_flag { get; set; }
    public string DistName_CommAddr { get; set; }
    public string MandalName_CommAddr { get; set; }
    public string VillageName_CommAddr { get; set; }
    public Int64 Pincode_CommAddr { get; set; }
    public string TelephonoNo1_CommAddr { get; set; }
    public string TelephonoNo2_CommAddr { get; set; }
    public string FaxNo1_CommAddr { get; set; }
    public string FaxNo2_CommAddr { get; set; }


    public Int64 YearofEstablishment_Firmregistration { get; set; }
    public Int64 YearofCommencement_Firmregistration { get; set; }
    public string RegistrationNo_Firmregistration { get; set; }
    public string RegisteringAuthority_Firmregistration { get; set; }




    public string PlotNo_Prv_flot { get; set; }
    public string ShedName_Prv_flot { get; set; }
    public string House_Prv_flot { get; set; }
    public string OtherDetails_Prv_flot { get; set; }
    public string Shop_Prv_flot { get; set; }
    public string StatusAllotted_Lease_Name_Prv_flot { get; set; }

    public string Surname_Cont_info { get; set; }
    public string FirstName_Cont_info { get; set; }


  

    public string Door_No_Cont_info { get; set; }
    public string Street_1_Cont_info { get; set; }
    public string Street_2_Cont_info { get; set; }
    public Int64 State_Cont_info { get; set; }
    public Int64 Distid_Cont_info { get; set; }
    public Int64 Mandal_Cont_info { get; set; }
    public Int64 Village_Cont_info { get; set; }
    public string OtherState_Cont_info_flag { get; set; }
    public string DistName_Cont_info { get; set; }
    public string MandalName_Cont_info { get; set; }
    public string VillageName_Cont_info { get; set; }
    public Int64 Pincode_Cont_info { get; set; }
    public long  MobileNo_Cont_info { get; set; }
    public int TelephonoNo1_Cont_info { get; set; }
    public int TelephonoNo2_Cont_info { get; set; }
    public string FaxNo1_Cont_info { get; set; }
    public string FaxNo2_Cont_info { get; set; }
    public string Email_Cont_info { get; set; }

    public string ProposedProject_Financial { get; set; }
    public decimal Assets_Financial_Inlakhs { get; set; }
    public decimal Liabilities_Financial_Inlakhs { get; set; }
    public decimal OtherAssets_Financial_Inlakhs { get; set; }
    public string Immovable_Assets_Land_Building_Financial { get; set; }
    public string Anyother_Financial_Info { get; set; }
    public string PanNumber_Financial_Info { get; set; }

    public string TypeofVenture_General_Info { get; set; }
    public string ProjectStatus_General_Info { get; set; }
    public string ProjectCategory1_General_Info { get; set; }
    public string ProjectCategory2_General_Info { get; set; }
    public string ProjectCategory3_General_Info { get; set; }
    public string ProjectName_Description_General_Info { get; set; }
    public string DtCommencement_Commercial_Operations_General_Info { get; set; }
    public string Expected_Dt_Commencement_Construction_General_Info { get; set; }
    public string Expected_Dt_Trial_Operations_General_Info { get; set; }

    public string DtCommencement_Commercial_Operations_General_Infophase2{ get; set; }
    public string Expected_Dt_Commencement_Construction_General_Infophase2 { get; set; }
    public string Expected_Dt_Trial_Operations_General_Infophase2 { get; set; }
    public string DtCommencement_Commercial_Operations_General_Infophase3 { get; set; }
    public string Expected_Dt_Commencement_Construction_General_Infophase3 { get; set; }
    public string Expected_Dt_Trial_Operations_General_Infophase3 { get; set; }

    public decimal Land_Project_Cost_Lakhs { get; set; }
    public decimal Buildings_Project_Cost_Lakhs { get; set; }
    public decimal Imported_Project_Cost_Lakhs { get; set; }
    public decimal Indigenous_Project_Cost_Lakhs { get; set; }
    public decimal AuxiliaryEquipment_Project_Cost_Lakhs { get; set; }
    public decimal Misc_FixedAssets_Project_Cost_Lakhs { get; set; }
    public decimal Contingencies_Project_Cost_Lakhs { get; set; }
    public decimal PreliminaryExp_Project_Cost_Lakhs { get; set; }
    public decimal WorkCapitalMargin_Project_Cost_Lakhs { get; set; }
    public decimal Total_Project_Cost_Lakhs { get; set; }

 

    public decimal Land_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Buildings_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Imported_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Indigenous_Project_Cost_Lakhsphase2 { get; set; }
    public decimal AuxiliaryEquipment_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Misc_FixedAssets_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Contingencies_Project_Cost_Lakhsphase2 { get; set; }
    public decimal PreliminaryExp_Project_Cost_Lakhsphase2 { get; set; }
    public decimal WorkCapitalMargin_Project_Cost_Lakhsphase2 { get; set; }
    public decimal Total_Project_Cost_Lakhsphase2 { get; set; }

    public decimal Land_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Buildings_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Imported_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Indigenous_Project_Cost_Lakhsphase3 { get; set; }
    public decimal AuxiliaryEquipment_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Misc_FixedAssets_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Contingencies_Project_Cost_Lakhsphase3 { get; set; }
    public decimal PreliminaryExp_Project_Cost_Lakhsphase3 { get; set; }
    public decimal WorkCapitalMargin_Project_Cost_Lakhsphase3 { get; set; }
    public decimal Total_Project_Cost_Lakhsphase3 { get; set; }





    public Int64 Unskilled_Emp { get; set; }
    public Int64 Skilled_Emp { get; set; }
    public Int64 Supervisory_Emp { get; set; }
    public Int64 Managerial_Emp { get; set; }
    public Int64 Total_Emp { get; set; }
    public Int64 Workers_factory_emp { get; set; }

    public Int64 Unskilled_Empphase2 { get; set; }
    public Int64 Skilled_Empphase2 { get; set; }
    public Int64 Supervisory_Empphase2 { get; set; }
    public Int64 Managerial_Empphase2 { get; set; }
    public Int64 Total_Empphase2 { get; set; }


    public Int64 Unskilled_Empphas3 { get; set; }
    public Int64 Skilled_Empphase3 { get; set; }
    public Int64 Supervisory_Empphase3 { get; set; }
    public Int64 Managerial_Empphase3 { get; set; }
    public Int64 Total_Empphase3 { get; set; }


    public Int64 malephase1 { get; set; }
    public Int64 malephase2 { get; set; }
    public Int64 malephase3 { get; set; }
    public Int64 femalephase1 { get; set; }
    public Int64 femalephase2 { get; set; }
    public Int64 femalephase3 { get; set; }


    public decimal Domestic { get; set; }
    public decimal Foreigns { get; set; }
    public decimal TotalEquity { get; set; }
    public string EquityName { get; set; }
    public decimal Amount { get; set; }
    public decimal TotalEquitdebit { get; set; }
    public string Foreigninvestment { get; set; }
    public string Foreigninvestmentdate { get; set; }
    public string IEM { get; set; }
    public string IEMdate { get; set; }
    public string LOI { get; set; }
    public string LOIdate { get; set; }
    public string EOUNo { get; set; }
    public string EOUdate { get; set; }


    public string  Industrialshed { get; set; }
    public decimal PlantFactoryBuildings_LandRequired { get; set; }
    public decimal AdministrationBuildings_LandRequired { get; set; }
    public decimal StorageWarehousing_LandRequired { get; set; }
    public decimal RoadsWaterstorage_LandRequired { get; set; }
    public decimal OpenAreasGreenBelt_LandRequired { get; set; }
    public decimal Total_LandRequired { get; set; }

    
    public decimal PlantFactoryBuildings_LandRequiredphase2 { get; set; }
    public decimal AdministrationBuildings_LandRequiredphase2 { get; set; }
    public decimal StorageWarehousing_LandRequiredphase2 { get; set; }
    public decimal RoadsWaterstorage_LandRequiredphase2 { get; set; }
    public decimal OpenAreasGreenBelt_LandRequiredphase2 { get; set; }
    public decimal Total_LandRequiredphase2 { get; set; }

    public decimal PlantFactoryBuildings_LandRequiredphase3 { get; set; }
    public decimal AdministrationBuildings_LandRequiredphase3 { get; set; }
    public decimal StorageWarehousing_LandRequiredphase3 { get; set; }
    public decimal RoadsWaterstorage_LandRequiredphase3 { get; set; }
    public decimal OpenAreasGreenBelt_LandRequiredphase3 { get; set; }
    public decimal Total_LandRequiredphase3 { get; set; }

    public decimal TSTRANSCO_Energy_KVA { get; set; }
    public decimal ContractedMaxDem_KVA { get; set; }
    public decimal Req_PowerSupply_KV { get; set; }
    public decimal VoltageRating_HT { get; set; }
    public decimal Connectedload_KW { get; set; }
    public decimal Loadfactor { get; set; }

    public decimal TSTRANSCO_Energy_KVAphase2 { get; set; }
    public decimal ContractedMaxDem_KVphase2 { get; set; }
    public decimal Req_PowerSupply_KVphase2 { get; set; }
    public decimal VoltageRating_HTphase2 { get; set; }
    public decimal Connectedload_KWphase2 { get; set; }
    public decimal Loadfactorphase2 { get; set; }

    public decimal TSTRANSCO_Energy_KVAphase3 { get; set; }
    public decimal ContractedMaxDem_KVAphase3 { get; set; }
    public decimal Req_PowerSupply_KVphase3 { get; set; }
    public decimal VoltageRating_HTphase3 { get; set; }
    public decimal Connectedload_KWphase3 { get; set; }
    public decimal Loadfactorphase3 { get; set; }

    public string Dt_Construction_PowerSupply { get; set; }
    public string Dt_Commercial_PowerSupply { get; set; }

    public string Dt_Construction_PowerSupplyphase2 { get; set; }
    public string Dt_Commercial_PowerSupplyphase2 { get; set; }

    public string Dt_Construction_PowerSupplyphase3 { get; set; }
    public string Dt_Commercial_PowerSupplyphase3 { get; set; }

    public decimal Domestic_Temp_WaterReq { get; set; }
    public decimal Industrial_Temp_WaterReq { get; set; }
    public decimal Domestic_Perm_WaterReq { get; set; }
    public decimal Industrial_Perm_WaterReq { get; set; }

    public decimal Domestic_Temp_WaterReqphase2 { get; set; }
    public decimal Industrial_Temp_WaterReqphase2 { get; set; }
    public decimal Domestic_Perm_WaterReqphase2 { get; set; }
    public decimal Industrial_Perm_WaterReqphase2 { get; set; }


    public decimal Domestic_Temp_WaterReqphase3  { get; set; }
    public decimal Industrial_Temp_WaterReqphase3 { get; set; }
    public decimal Domestic_Perm_WaterReqphase3   { get; set; }
    public decimal Industrial_Perm_WaterReqphase3 { get; set; }
    public string Created_by { get; set; }


    public string Effluentsphase1 { get; set; }
    public string Effluentsphase2 { get; set; }
    public string Effluentsphase3 { get; set; }
    public string SolidWastephase1 { get; set; }
    public string SolidWastephase2 { get; set; }
    public string SolidWastephase3 { get; set; }

    public string Descriptioneffulents { get; set; }
    public string Tstranscosupply { get; set; }
    public string Owngeneration { get; set; }
    public string Dgset { get; set; }

    public string Highpressurevessels { get; set; }
    public string noofvessels { get; set; }

    public string GSTNumber { get; set; }
    //public string technicalcollabration { get; set; }
    //public string providedetails { get; set; }
    //public string processtechnology { get; set; }
    //public string processtechnologysteam { get; set; }
    //public string filename { get; set; }
    //public string filepath { get; set; }
   

}

public class plantmachinery
{
    public Int64 ApplicationId { get; set; }
    public string Descriptionplantmachinery { get; set; }
    public string capacitykw { get; set; }

    public Int64 createdby { get; set; }

    public string Quantity { get; set; }
    public decimal Cost { get; set; }
}

