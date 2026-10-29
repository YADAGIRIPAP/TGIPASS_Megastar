using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HmdaOcVos
/// </summary>
public class HmdaOcVos
{
    public string AppsLevel { get; set; }
    public string User_Id { get; set; }
    public string OnlineOffline { get; set; }
    public string HMDAFileNo { get; set; }
    public string WorkCommencedDate { get; set; }
    public string WorkCompletionDate { get; set; }
    public string DueDateforCompletionofBuilding { get; set; }
    public string OccupancyAppliedFor { get; set; }
    public string UnitDIst { get; set; }
    public string UnitMandal { get; set; }
    public string Villageunit { get; set; }
    public string OfficeZone { get; set; }
    public string PlotNo { get; set; }
    public string SurveyNo { get; set; }
    public string ProceedingIssuedOnDate { get; set; }
    public string ProceedingIssuedBy { get; set; }
    public string Front { get; set; }
    public string Rear { get; set; }
    public string Side1 { get; set; }
    public string Side2 { get; set; }
    public string SiteArea { get; set; }
    public string RoadAffectedArea { get; set; }
    public string NetArea { get; set; }
    public string TotLot { get; set; }
    public string buildingHeight { get; set; }
    public string NoofRWHPs { get; set; }
    public string nooftrees { get; set; }
    public string BuildingProposedBuilding { get; set; }
    public string BuildingUse { get; set; }
    public string BuildingSubUse { get; set; }
    public string NoofFloors { get; set; }
    public string TechnicalName { get; set; }
    public string TechnicalEmailId { get; set; }
    public string TechnicalMobileNo { get; set; }
    public string OwnerName { get; set; }
    public string txtOwnerEmailId { get; set; }
    public string MobileNo { get; set; }
    public string intQuessionaireCFOid { get; set; }
    public string ApprovalID { get; set; }
    public string DeptID { get; set; }
    public string HmdaOcID { get; set; }

    //public HmdaOcVos()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
}

public class SanctionBuildingDetails
{
    public string intQuessionaireCFOid { get; set; }
    public string intCFOEnterid { get; set; }
  
    public string Buildingid
    {
        get;
        set;
    }
    public string BuildingName
    {
        get;
        set;
    }
    public string PlotNo
    {
        get;
        set;
    }
    public string CreatedBy
    {
        get;
        set;
    }
}