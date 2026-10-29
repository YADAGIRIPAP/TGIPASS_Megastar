using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WebserviceVO
/// </summary>
public class WebserviceVO
{
    # region CommonFields Declaration
    public string UID_No { get; set; }
    public int intQuessionaireid { get; set; }
    public int intEnterpreneurid { get; set; }
    public string NameofIndustrialUnder { get; set; }
    public string NameofthePromoter { get; set; }
    public string Plot_Number { get; set; }
    public string STREET { get; set; }
    public string Land_intDistrictid { get; set; }
    public string Land_intMandalid { get; set; }
    public string Land_intVillageid { get; set; }
    public string Land_Pincode { get; set; }
    public string Land_Email { get; set; }
    public string Land_TelephoneNumber { get; set; }
    public string MobileNumber { get; set; }
    public string Door_No { get; set; }
    public string StreetName { get; set; }
    public string intVillageid { get; set; }
    public string intMandalid { get; set; }
    public string intDistrictid { get; set; }
    public string Pincode { get; set; }
    public string TelephoneNumber { get; set; }
    public string Email { get; set; }
    public string intTypeofOrganization { get; set; }
    public string TypeofFactory { get; set; }
    public string ProposalFor { get; set; }
    public string Caste { get; set; }
    public string WomenEnterprenuer { get; set; }
    public string Minority { get; set; }
    public string Reg_No { get; set; }
    public string Reg_Date { get; set; }
    public string Reg_id { get; set; }
    public string intStatusid { get; set; }
    public string Land_Value { get; set; }
    public string plant_value { get; set; }
    public string Building_value { get; set; }
    public string Total_value { get; set; }
    public string DistrictName { get; set; }
    public string Mandalname { get; set; }
    public string VillageName { get; set; }
    public string intUnitID { get; set; }
    public string diffabled { get; set; }
    public string Survey_No { get; set; }
    public string Name_Gramapachayat { get; set; }
    public string ProposedLocationofFactory { get; set; }
    public string UID_NOGenerateDate { get; set; }
    public string Approval_Fee { get; set; }
    public string IsPayment { get; set; }
    public string Paid_At { get; set; }
    public string Receipt_No { get; set; }
    public string Receipt_Date { get; set; }
    public string Father { get; set; }
    #endregion

    #region Power Declaration
    public string Cont_Demand_Max { get; set; }
    public string Connect_Load_A { get; set; }
    public string Connect_Load_B { get; set; }
    public string Power_PerMonth { get; set; }
    public string Trail_Production { get; set; }
    public string Portable_Date { get; set; }
    public string Service_No { get; set; }
    public string Req_Voltage { get; set; }
    public string Anyother_Service { get; set; }
    public string Power_PerDay { get; set; }
    public string DirectMale { get; set; }
    public string DirectFemale { get; set; }
    public string InDirectMale { get; set; }
    public string InDirectFemale { get; set; }
    public string intCategoryofReg { get; set; }
    #endregion

    #region Fire
    public int NoofBlocks { get; set; }
    public string BuildingName { get; set; }
    #endregion

    public string AreaName { get; set; }
    public decimal saleDeedPlotAreaInSqMts { get; set; }
    public decimal saleDeedPlotAreaInSqYards { get; set; }
    public decimal totalPlinthArea { get; set; }
    public decimal Amount { get; set; }
    public string Paymentflag { get; set; }
    public string Bankname { get; set; }
    public string Transactionno { get; set; }
    public string TransactionDate { get; set; }


    #region NALA
    public string UserId { get; set; }
    public string Password { get; set; }
    public string LogindID { get; set; }
    public string ServiceID { get; set; }
    public string AddressFlag { get; set; }
    public string UIDNumber { get; set; }
    public string ApplicantName { get; set; }
    public string Relation { get; set; }
    public string FatherName { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }
    public string PermanentDoorNo { get; set; }
    public string PermanentLocality { get; set; }
    public string PermanentDistrict { get; set; }
    public string PermanentMandal { get; set; }
    public string PermanentVillage { get; set; }
    public string PermanentPincode { get; set; }
    public string PostalDoorNo { get; set; }
    public string PostalLocality { get; set; }
    public string StateId { get; set; }
    public string PostalDistrict { get; set; }
    public string PostalMandal { get; set; }
    public string PostalVillage { get; set; }
    public string PostalPincode { get; set; }
    public string MobileNo { get; set; }
    public string PhoneNo { get; set; }
    public string EmailID { get; set; }
    public string Remarks { get; set; }
    public string RationCardNo { get; set; }
    public string AadhaarNo { get; set; }
    public string DeliveryType { get; set; }
    public string Doc_District { get; set; }
    public string Doc_Mandal { get; set; }
    public string Doc_Village { get; set; }
    public string Purpose { get; set; }
    public string ServiceCharge { get; set; }
    public string UserCharge { get; set; }
    public string PostalCharge { get; set; }
    public string TotalAmount { get; set; }
    public string GridDetails { get; set; }
    public string QuestionaireId { get; set; }
    public string EntrepreneurId { get; set; }
    public string docapplicationform { get; set; }
    public string landrelated { get; set; }
    public string certificateform { get; set; }
    public string idproof { get; set; }
    #endregion
    public WebserviceVO()
    {

        //
        // TODO: Add constructor logic here
        //
    }
}