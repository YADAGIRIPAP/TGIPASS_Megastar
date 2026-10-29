using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CenteralInspectionVo
/// </summary>
public class CenteralInspectionVo
{
    #region Labour
    public string slno { get; set; }
    public string address { get; set; }
    public string ci1_generated_path { get; set; }
    public string district_id { get; set; }
    public string inspection_alloted_time { get; set; }
    public string inspection_completed { get; set; }
    public string inspection_officer_alloted { get; set; }
    public string inspection_week { get; set; }
    public string name_of_establishment { get; set; }
    public string no_of_workers_employees { get; set; }
    public string registration_no { get; set; }
    public string risk_level { get; set; }
    public string takedar_principalemployer_name { get; set; }
    public string act_name { get; set; }
    public string factory_inspecting_officer { get; set; }
    public string factory_inspecting_officer_mobile { get; set; }
    public string labourinspectiontype { get; set; }
    #endregion

    #region Factory
    public string actionTaken { get; set; }
    public string allottedInspectionOfficer { get; set; }
    public string complianceAction { get; set; }
    public string complianceActionTakenBy { get; set; }
    public string complianceDate { get; set; }
    public string complianceFilepath { get; set; }
    public string complianceGeneratedIP { get; set; }
    public string complianceRemarksByOfficer { get; set; }
    public string complianceSubmitted { get; set; }
    public string complianceVerificationRemarksByOfficer { get; set; }
    public string descriptionOfEconomicActivity { get; set; }
    public string dofAction { get; set; }
    public string dofActionDate { get; set; }
    public string dofRemarks { get; set; }
    public string factoryAddress { get; set; }
    public string factorycircleName { get; set; }
    public string factoryDistrictName { get; set; }
    public string factoryMandalId { get; set; }
    public string factoryMandalName { get; set; }
    public string factoryName { get; set; }
    public string generalRemarks { get; set; }
    public string inspectionReportUploaded { get; set; }
    public string inspectionReportUploadedTime { get; set; }
    public string inspectionScheduledTime { get; set; }
    public string inspectionYear { get; set; }
    public string ownerComplianceRemarks { get; set; }
    public string registrationNumber { get; set; }
    public string riskFactor { get; set; }
    public string showcausePostalReference { get; set; }
    public string workingOrClosedFactory { get; set; }
    public string inspectionMonth { get; set; }
    #endregion

    #region PCB
    public string AssignedForMonthYr { get; set; }
    public string AllocationMonth { get; set; }
    public string AllocationYear { get; set; } 
    public string InspectionAllocatedToEmp { get; set; } 
    public string InspectionAllocatedToName { get; set; } 
    public string IndustryId { get; set; } 
    public string IndustryDetails { get; set; }  

    #endregion

    #region Boiler
    public string BoilerAddress { get; set; }
    public string BoilerAllocationMonth { get; set; }
    public string BoilerAllocationYear { get; set; }
    public string BoilermakerNumber { get; set; }
    public string BoilerOwnerName { get; set; }
    public string BoilerOfficer { get; set; }
    //public string IndustryDetails { get; set; }

    #endregion

    #region Legal
    public string LegalAddress { get; set; }
    public string LegalAllocationMonth { get; set; }
    public string LegalAllocationYear { get; set; }
    public string LegalLicenseNumber { get; set; }
    public string LegalOwnerName { get; set; }
    public string LegalOfficer { get; set; }
    //public string IndustryDetails { get; set; }

    #endregion
    public CenteralInspectionVo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}