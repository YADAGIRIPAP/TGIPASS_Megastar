using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

[WebService(Namespace = "http://tempuri.org/")]

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public partial class UI_TSiPASS_CentralInspection : System.Web.UI.Page
{
    WebClient wc = new WebClient();
    CenteralInspectionVo centeralvo = new CenteralInspectionVo();
    General gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            BoilerService.TSBoilerServiceImplService boilerservice = new BoilerService.TSBoilerServiceImplService();
            BoilerService.boilersInspectionDetailsSendResponse boilerinspectionoutput = new BoilerService.boilersInspectionDetailsSendResponse();
            BoilerService.boilersInspectionDetailsResponse boilerinspectionResponseout = new BoilerService.boilersInspectionDetailsResponse();

            boilerinspectionoutput = boilerservice.scheduleBoilersDepartmentInspection();
            BoilerService.boilersInspectionDetailsResponse boilerinspectionvo = new BoilerService.boilersInspectionDetailsResponse();

            int boilercount = boilerinspectionoutput.boilersInspectionDetailsResponse.Length;
            for (int b = 0; b < boilercount; b++)
            {
                boilerinspectionvo = boilerinspectionoutput.boilersInspectionDetailsResponse[b];
                centeralvo.BoilerAddress = boilerinspectionvo.boilerAddress;
                centeralvo.BoilerAllocationMonth = boilerinspectionvo.inspectionMonth;
                centeralvo.BoilerAllocationYear = boilerinspectionvo.inspectionYear;
                centeralvo.BoilermakerNumber = boilerinspectionvo.boilermakerNumber;
                centeralvo.BoilerOfficer = boilerinspectionvo.allottedInspectionOfficer;
                centeralvo.BoilerOwnerName = boilerinspectionvo.ownerName;
                //centeralvo.BoilerinspectionScheduledTime = boilerinspectionvo.inspectionScheduledTime;
                //string[] rd1 = null;
                //string ConvertedDt1 = "";
                //if (centeralvo.BoilerinspectionScheduledTime != "")
                //{
                //    rd1 = centeralvo.BoilerinspectionScheduledTime.Split('/');
                //    ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

                //    centeralvo.LegalinspectionScheduledTime = ConvertedDt1;
                //}
                int outputpcb = gen.InsertBOILERCenteralInspection(centeralvo);
            }
        }
        catch (Exception ex)
        {
        }


        try
        {
            FactoryJointInspection.TSFactoryServiceImplService factoryjoint = new FactoryJointInspection.TSFactoryServiceImplService();
            FactoryJointInspection.factoriesInspectionDetailsSendResponse factoryjointout = new FactoryJointInspection.factoriesInspectionDetailsSendResponse();

            factoryjointout = factoryjoint.scheduleFactoriesJointInspection();
            FactoryJointInspection.factoriesInspectionDetailsResponse factoryjointvo = new FactoryJointInspection.factoriesInspectionDetailsResponse();

            int factorycount = factoryjointout.factoriesInspectionDetailsResponse.Length;
            for (int i = 0; i < factorycount; i++)
            {
                factoryjointvo = factoryjointout.factoriesInspectionDetailsResponse[i];
                centeralvo.actionTaken = factoryjointvo.actionTaken;
                centeralvo.allottedInspectionOfficer = factoryjointvo.allottedInspectionOfficer;
                centeralvo.complianceAction = factoryjointvo.complianceAction;
                centeralvo.complianceActionTakenBy = factoryjointvo.complianceActionTakenBy;
                if (factoryjointvo.complianceDate != "null")
                {
                    centeralvo.complianceDate = factoryjointvo.complianceDate;
                }
                centeralvo.complianceFilepath = factoryjointvo.complianceFilepath;
                centeralvo.complianceGeneratedIP = factoryjointvo.complianceGeneratedIP;
                centeralvo.complianceRemarksByOfficer = factoryjointvo.complianceRemarksByOfficer;
                centeralvo.complianceSubmitted = factoryjointvo.complianceSubmitted;
                centeralvo.complianceVerificationRemarksByOfficer = factoryjointvo.complianceVerificationRemarksByOfficer;
                centeralvo.descriptionOfEconomicActivity = factoryjointvo.descriptionOfEconomicActivity;
                centeralvo.dofAction = factoryjointvo.dofAction;
                if (factoryjointvo.dofActionDate != "null")
                {
                    centeralvo.dofActionDate = factoryjointvo.dofActionDate;
                }
                centeralvo.dofRemarks = factoryjointvo.dofRemarks;
                centeralvo.factoryAddress = factoryjointvo.factoryAddress;
                centeralvo.factorycircleName = factoryjointvo.factorycircleName;
                centeralvo.factoryDistrictName = factoryjointvo.factoryDistrictName;
                centeralvo.factoryMandalId = factoryjointvo.factoryMandalId;
                centeralvo.factoryMandalName = factoryjointvo.factoryMandalName;
                centeralvo.factoryName = factoryjointvo.factoryName;
                centeralvo.generalRemarks = factoryjointvo.generalRemarks;
                centeralvo.inspectionMonth = factoryjointvo.inspectionMonth;
                centeralvo.inspectionReportUploaded = factoryjointvo.inspectionReportUploaded;
                if (factoryjointvo.inspectionReportUploadedTime != "null")
                {
                    centeralvo.inspectionReportUploadedTime = factoryjointvo.inspectionReportUploadedTime;
                }
                centeralvo.inspectionScheduledTime = factoryjointvo.inspectionScheduledTime;
                //centeralvo.inspectionScheduledTime = factoryvo.inspectionScheduledTime;
                centeralvo.inspectionScheduledTime = factoryjointvo.inspectionScheduledTime;
                comFunctions com = new comFunctions();
                //centeralvo.inspectionScheduledTime = com.convertDateIndia(factoryjointvo.inspectionScheduledTime).ToString();
                string[] rd1 = null;
                string ConvertedDt1 = "";

                if (factoryjointvo.inspectionScheduledTime != "")
                {
                    rd1 = factoryjointvo.inspectionScheduledTime.Split('/');
                    ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

                    centeralvo.inspectionScheduledTime = ConvertedDt1;
                }
                else
                {
                    centeralvo.inspectionScheduledTime = "01/01/1900";
                }
                centeralvo.inspectionYear = factoryjointvo.inspectionYear;
                centeralvo.ownerComplianceRemarks = factoryjointvo.ownerComplianceRemarks;
                centeralvo.registrationNumber = factoryjointvo.registrationNumber;
                centeralvo.riskFactor = factoryjointvo.riskFactor;
                centeralvo.showcausePostalReference = factoryjointvo.showcausePostalReference;
                centeralvo.workingOrClosedFactory = factoryjointvo.workingOrClosedFactory;
                centeralvo.labourinspectiontype = "Joint";
                int outputfac = gen.InsertFactoryCenteralInspection(centeralvo);
            }
        }
        catch (Exception ex)
        {
        }




        LabourJointInspection.TSLabourServiceImplService labourjoint = new LabourJointInspection.TSLabourServiceImplService();
        LabourJointInspection.actsResponse labourjointout = new LabourJointInspection.actsResponse();
        try
        {
            labourjointout = labourjoint.jiInspectionsLogicBegin();
            LabourJointInspection.labourInspectionDetails labourjointvo = new LabourJointInspection.labourInspectionDetails();
            int jointcount = labourjointout.labourInspectionDetails.Length;

            for (int i = 0; i < jointcount; i++)
            {
                labourjointvo = labourjointout.labourInspectionDetails[i];

                centeralvo.act_name = labourjointvo.act_name;
                centeralvo.factory_inspecting_officer = labourjointvo.factory_inspecting_officer;
                centeralvo.factory_inspecting_officer_mobile = labourjointvo.factory_inspecting_officer_mobile;
                centeralvo.address = labourjointvo.address;
                //centeralvo.ci1_generated_path = labourjointvo.ci1_generated_path;
                centeralvo.district_id = labourjointvo.district_id;
                //centeralvo.inspection_alloted_time = labourjointvo.inspection_alloted_time;
                string[] rd = null;
                string ConvertedDt = "";
                comFunctions com = new comFunctions();
                if (labourjointvo.inspection_alloted_time != "")
                {
                    rd = labourjointvo.inspection_alloted_time.Split('/');
                    ConvertedDt = rd[1].ToString() + "/" + rd[0].ToString() + "/" + rd[2].ToString();

                    centeralvo.inspection_alloted_time = ConvertedDt;
                }
                else
                {
                    centeralvo.inspection_alloted_time = "01/01/1900";
                }

                centeralvo.inspection_completed = labourjointvo.inspection_completed;
                centeralvo.inspection_officer_alloted = labourjointvo.inspection_officer_alloted;
                //centeralvo.inspection_week = labourjointvo.inspection_week;
                centeralvo.name_of_establishment = labourjointvo.name_of_establishment;
                centeralvo.no_of_workers_employees = labourjointvo.no_of_workers_employees;
                centeralvo.registration_no = labourjointvo.registration_no;
                centeralvo.risk_level = labourjointvo.risk_level;
                centeralvo.slno = labourjointvo.slno;
                //centeralvo.takedar_principalemployer_name = labourjointvo.takedar_principalemployer_name;
                centeralvo.labourinspectiontype = "Joint";
                int outputlab = gen.InsertLabourCenteralInspection(centeralvo);
            }

        }
        catch (Exception ex)
        {
        }

        try
        {
            FactoryInspection.TSFactoryServiceImplService factory = new FactoryInspection.TSFactoryServiceImplService();
            FactoryInspection.factoriesInspectionDetailsSendResponse factoryout = new FactoryInspection.factoriesInspectionDetailsSendResponse();

            factoryout = factory.scheduleFactoriesDepartmentInspection();
            FactoryInspection.factoriesInspectionDetailsResponse factoryvo = new FactoryInspection.factoriesInspectionDetailsResponse();

            int factorycount = factoryout.factoriesInspectionDetailsResponse.Length;
            for (int i = 0; i < factorycount; i++)
            {
                factoryvo = factoryout.factoriesInspectionDetailsResponse[i];
                centeralvo.actionTaken = factoryvo.actionTaken;
                centeralvo.allottedInspectionOfficer = factoryvo.allottedInspectionOfficer;
                centeralvo.complianceAction = factoryvo.complianceAction;
                centeralvo.complianceActionTakenBy = factoryvo.complianceActionTakenBy;
                if (factoryvo.complianceDate != "null")
                {
                    centeralvo.complianceDate = factoryvo.complianceDate;
                }
                centeralvo.complianceFilepath = factoryvo.complianceFilepath;
                centeralvo.complianceGeneratedIP = factoryvo.complianceGeneratedIP;
                centeralvo.complianceRemarksByOfficer = factoryvo.complianceRemarksByOfficer;
                centeralvo.complianceSubmitted = factoryvo.complianceSubmitted;
                centeralvo.complianceVerificationRemarksByOfficer = factoryvo.complianceVerificationRemarksByOfficer;
                centeralvo.descriptionOfEconomicActivity = factoryvo.descriptionOfEconomicActivity;
                centeralvo.dofAction = factoryvo.dofAction;
                if (factoryvo.dofActionDate != "null")
                {
                    centeralvo.dofActionDate = factoryvo.dofActionDate;
                }
                centeralvo.dofRemarks = factoryvo.dofRemarks;
                centeralvo.factoryAddress = factoryvo.factoryAddress;
                centeralvo.factorycircleName = factoryvo.factorycircleName;
                centeralvo.factoryDistrictName = factoryvo.factoryDistrictName;
                centeralvo.factoryMandalId = factoryvo.factoryMandalId;
                centeralvo.factoryMandalName = factoryvo.factoryMandalName;
                centeralvo.factoryName = factoryvo.factoryName;
                centeralvo.generalRemarks = factoryvo.generalRemarks;
                centeralvo.inspectionMonth = factoryvo.inspectionMonth;
                centeralvo.inspectionReportUploaded = factoryvo.inspectionReportUploaded;
                if (factoryvo.inspectionReportUploadedTime != "null")
                {
                    centeralvo.inspectionReportUploadedTime = factoryvo.inspectionReportUploadedTime;
                }
                centeralvo.inspectionScheduledTime = factoryvo.inspectionScheduledTime;
                comFunctions com = new comFunctions();
                //centeralvo.inspectionScheduledTime = com.convertDateIndia(factoryvo.inspectionScheduledTime).ToString();
                string[] rd1 = null;
                string ConvertedDt1 = "";

                if (factoryvo.inspectionScheduledTime != "")
                {
                    rd1 = factoryvo.inspectionScheduledTime.Split('/');
                    ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

                    centeralvo.inspectionScheduledTime = ConvertedDt1;
                }
                else
                {
                    centeralvo.inspectionScheduledTime = "01/01/1900";
                }

                centeralvo.inspectionYear = factoryvo.inspectionYear;
                centeralvo.ownerComplianceRemarks = factoryvo.ownerComplianceRemarks;
                centeralvo.registrationNumber = factoryvo.registrationNumber;
                centeralvo.riskFactor = factoryvo.riskFactor;
                centeralvo.showcausePostalReference = factoryvo.showcausePostalReference;
                centeralvo.workingOrClosedFactory = factoryvo.workingOrClosedFactory;
                centeralvo.labourinspectiontype = "Factory";
                int outputfac = gen.InsertFactoryCenteralInspection(centeralvo);
            }
        }
        catch (Exception ex)
        {
        }

        LabourInspectionService.TSLabourServiceImplService labour = new LabourInspectionService.TSLabourServiceImplService();
        LabourInspectionService.actsResponse labourout = new LabourInspectionService.actsResponse();

        labourout = labour.inspectionsLogicBegin();
        LabourInspectionService.labourInspectionDetails labourvo = new LabourInspectionService.labourInspectionDetails();
        int count = labourout.labourInspectionDetails.Length;
        try
        {
            for (int i = 0; i < count; i++)
            {
                labourvo = labourout.labourInspectionDetails[i];
                centeralvo.act_name = labourvo.act_name;
                centeralvo.address = labourvo.address;
                centeralvo.ci1_generated_path = "";// labourvo.ci1_generated_path;
                centeralvo.district_id = labourvo.district_id;
                centeralvo.inspection_alloted_time = labourvo.inspection_alloted_time;
                string[] rd = null;
                string ConvertedDt = "";
                comFunctions com = new comFunctions();
                if (labourvo.inspection_alloted_time != "")
                {
                    rd = labourvo.inspection_alloted_time.Split('/');
                    ConvertedDt = rd[1].ToString() + "/" + rd[0].ToString() + "/" + rd[2].ToString();

                    centeralvo.inspection_alloted_time = ConvertedDt;
                }
                else
                {
                    centeralvo.inspection_alloted_time = "01/01/1900";
                }

                centeralvo.inspection_completed = labourvo.inspection_completed;
                centeralvo.inspection_officer_alloted = labourvo.inspection_officer_alloted;
                centeralvo.inspection_week = labourvo.inspection_week;
                centeralvo.name_of_establishment = labourvo.name_of_establishment;
                centeralvo.no_of_workers_employees = labourvo.no_of_workers_employees;
                centeralvo.registration_no = labourvo.registration_no;
                centeralvo.risk_level = labourvo.risk_level;
                centeralvo.slno = labourvo.slno;
                centeralvo.takedar_principalemployer_name = labourvo.takedar_principalemployer_name;
                centeralvo.labourinspectiontype = "Labour";
                int outputlab = gen.InsertLabourCenteralInspection(centeralvo);
            }

        }
        catch (Exception ex)
        {
        }

        //try
        //{
        //    PCBInspectionService.ScheduledInspections pcbinspection = new PCBInspectionService.ScheduledInspections();


        //    //XmlElement pcboutput = "";
        //    XmlElement pcboutput = pcbinspection.GetEmpwiseIndustryInsp();

        //    string xml = "<NewDataSet>" + ' ' + pcboutput.InnerXml + ' ' + "</NewDataSet>";

        //    //XmlDataDocument dco = new XmlDataDocument();
        //    //dco.DocumentElement
        //    //dco.LoadXml(xml);
        //    StringReader str = new StringReader(xml);
        //    //dco.LoadXml(xml);
        //    //DataSet dsout = dco.DataSet;
        //    DataSet dsout = new DataSet();
        //    dsout.ReadXml(str);

        //    if (dsout != null && dsout.Tables.Count > 0 && dsout.Tables[0].Rows.Count > 0)
        //    {
        //        int pcbcount = dsout.Tables[0].Rows.Count;
        //        for (int i = 0; i < pcbcount; i++)
        //        {
        //            centeralvo.AssignedForMonthYr = dsout.Tables[0].Rows[i]["AssignedForMonthYr"].ToString();
        //            centeralvo.AllocationMonth = dsout.Tables[0].Rows[i]["AllocationMonth"].ToString();
        //            centeralvo.AllocationYear = dsout.Tables[0].Rows[i]["AllocationYear"].ToString();
        //            centeralvo.InspectionAllocatedToEmp = dsout.Tables[0].Rows[i]["InspectionAllocatedToEmp"].ToString();
        //            centeralvo.InspectionAllocatedToName = dsout.Tables[0].Rows[i]["InspectionAllocatedToEmp"].ToString();
        //            centeralvo.IndustryId = dsout.Tables[0].Rows[i]["IndustryId"].ToString();
        //            centeralvo.IndustryDetails = dsout.Tables[0].Rows[i]["IndustryDetails"].ToString();
        //            centeralvo.PCBinspectionScheduledTime = dsout.Tables[0].Rows[i]["ScheduledInspectionDate"].ToString();
        //            centeralvo.PCBOfficerDesignation = dsout.Tables[0].Rows[i]["DesignationinInspectionNotice"].ToString();
        //            string[] rd1 = null;
        //            string ConvertedDt1 = "";
        //            if (centeralvo.PCBinspectionScheduledTime != "")
        //            {
        //                rd1 = centeralvo.PCBinspectionScheduledTime.Split('/');
        //                ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

        //                centeralvo.PCBinspectionScheduledTime = ConvertedDt1;
        //            }
        //            int outputpcb = gen.InsertPCBCenteralInspection(centeralvo);
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //}


    }
}