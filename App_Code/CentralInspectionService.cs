using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;

/// <summary>
/// Summary description for CentralInspectionService
/// </summary>
/// 
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CentralInspectionService : System.Web.Services.WebService
{

    DB.DB con = new DB.DB();
    DataSet ds;
    DataTable dt;
    SqlDataAdapter myDataAdapter;
    comFunctions cmf = new comFunctions();
    General genogj = new General();

    public CentralInspectionService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string LabourInspectionActschecked(string registration_no, string acts_checked, string ci3_form_req, string inspection_completed, string inspection_checklist_upload_time)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateactschecked(registration_no, acts_checked, ci3_form_req, inspection_completed, inspection_checklist_upload_time);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourInspectionCIGeneratedPath(string registration_no, string ci_2_generated_path, string ci_3_generated_path)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateCIGeneratepath(registration_no, ci_2_generated_path, ci_3_generated_path);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourInspectionnotinspectingreasons(string registration_no, string not_inspecting_reasons)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updatenotinspectingreasons(registration_no, not_inspecting_reasons);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourInspectioncompliancereport(string registration_no, string compliancereport)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updatecompliance(registration_no, compliancereport);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourJointInspectionActschecked(string registration_no, string acts_checked, string ci3_form_req, string inspection_completed, string inspection_checklist_upload_time)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateactschecked(registration_no, acts_checked, ci3_form_req, inspection_completed, inspection_checklist_upload_time);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourJointInspectionCIGeneratedPath(string registration_no, string ci_2_generated_path, string ci_3_generated_path)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateCIGeneratepath(registration_no, ci_2_generated_path, ci_3_generated_path);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourJointInspectionnotinspectingreasons(string registration_no, string not_inspecting_reasons)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updatenotinspectingreasons(registration_no, not_inspecting_reasons);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string LabourJointInspectioncompliancereport(string registration_no, string compliancereport)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updatecompliance(registration_no, compliancereport);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdatePCBInspectionReport(string LineofActivity,
string DateofInspection, string IndustryEmailId, string IndustryMobileNo, string RemarksMajorObservations, string InspectionReport, string AllocationMonth,
string AllocationYear, string InspectionAllocatedToEmp, string IndustryId, string referenceno)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updatePCBIrReport(LineofActivity,
 DateofInspection, IndustryEmailId, IndustryMobileNo, RemarksMajorObservations, InspectionReport, AllocationMonth,
 AllocationYear, InspectionAllocatedToEmp, IndustryId, referenceno);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string UpdateFactoryInspectionReportLevel1(string type_of_orders, string show_cause_file_no, string action_taken, string general_remarks_by_officer,
    string ir_path, string io_path, string scn_path, string ir_uploaded, string ir_uploaded_time, string working_or_closed_factory, string inspection_type, string registrationNumber, string inspectionMonth,
    string inspectionYear)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            int valid = 0;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            if (registrationNumber == "" && registrationNumber == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter registrationNumber";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (inspectionYear == "" && inspectionYear == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Type Of inspectionYear";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (inspectionMonth == "" && inspectionMonth == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Type Of inspectionMonth";
                dt.Rows.Add(dr);
                valid = 1;
            }

            //if (type_of_orders == "" && type_of_orders == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Type Of Orders";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (show_cause_file_no == "" && show_cause_file_no == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Show Cause File Number";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (action_taken == "" && action_taken == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Action Taken";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (general_remarks_by_officer == "" && general_remarks_by_officer == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter General Remarks By Officer";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (ir_path == "" && ir_path == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter IR path";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (io_path == "" && io_path == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter IO Path";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (scn_path == "" && scn_path == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter SCN Path";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (ir_uploaded == "" && ir_uploaded == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter IR Uploaded";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (ir_uploaded_time == "" && ir_uploaded_time == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter IR Uploaded Time";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (working_or_closed_factory == "" && working_or_closed_factory == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Working Or Closed Factory";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}
            //if (inspection_type == "" && inspection_type == string.Empty)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = "2";
            //    dr[1] = "Please Enter Inspection Type";
            //    dt.Rows.Add(dr);
            //    valid = 1;
            //}

            if (valid == 0)
            {
                result = UpdateFactoryIRReport(type_of_orders, show_cause_file_no, action_taken, general_remarks_by_officer,
                         ir_path, io_path, scn_path, ir_uploaded, ir_uploaded_time, working_or_closed_factory, inspection_type, registrationNumber, inspectionMonth,
                         inspectionYear);

                if (result > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
            }

            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();
            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdateFactoryInspectionReportLevel2(string ir_path, string io_path, string scn_path, string showcause_postal_reference, string inspection_type, string registrationNumber, string inspectionMonth, string inspectionYear)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (ir_path == "" && ir_path == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter IR path";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (io_path == "" && io_path == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter IO Path";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (scn_path == "" && scn_path == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter SCN Path";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (showcause_postal_reference == "" && showcause_postal_reference == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Show Cause Postal Reference";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (valid == 0)
            {
                result = UpdateFactoryIRReportlevel2(ir_path, io_path, scn_path, showcause_postal_reference, inspection_type, registrationNumber, inspectionMonth,
                         inspectionYear);

                if (result > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
            }

            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdateFactoryInspectionReportLevel3(string compliance_submitted, string compliance_filepath, string compliance_date, string owner_compliance_remarks, string inspection_type, string registrationNumber, string inspectionMonth, string inspectionYear)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (compliance_submitted == "" && compliance_submitted == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Submitted";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (compliance_filepath == "" && compliance_filepath == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Filepath";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (compliance_date == "" && compliance_date == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Date";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (owner_compliance_remarks == "" && owner_compliance_remarks == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Owner Compliance Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (valid == 0)
            {
                result = UpdateFactoryIRReportlevel3(compliance_submitted, compliance_filepath, compliance_date, owner_compliance_remarks, inspection_type, registrationNumber, inspectionMonth,
                     inspectionYear);

                if (result > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
            }

            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdateFactoryInspectionReportLevel4(string showcause_postal_reference, string compliance_action, string compliance_action_takenby, string compliance_remarks_by_officer, string comp_verig_remarks_by_officer, string inspection_type, string registrationNumber, string inspectionMonth, string inspectionYear)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (showcause_postal_reference == "" && showcause_postal_reference == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter ShowCause Postal Reference";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (compliance_action == "" && compliance_action == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Action";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (compliance_action_takenby == "" && compliance_action_takenby == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Action TakenBy";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (compliance_remarks_by_officer == "" && compliance_remarks_by_officer == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Compliance Remarks By Officer";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (comp_verig_remarks_by_officer == "" && comp_verig_remarks_by_officer == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter Comp Verig Remarks By Officer";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (valid == 0)
            {
                result = UpdateFactoryIRReportlevel4(showcause_postal_reference, compliance_action, compliance_action_takenby, compliance_remarks_by_officer, comp_verig_remarks_by_officer, inspection_type, registrationNumber, inspectionMonth,
                         inspectionYear);

                if (result > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
            }

            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdateFactoryInspectionReportLevel5(string dof_remarks, string dof_action, string dof_action_date, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");
            int valid = 0;

            if (dof_remarks == "" && dof_remarks == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter DOF Remarks";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (dof_action == "" && dof_action == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter DOF Action";
                dt.Rows.Add(dr);
                valid = 1;
            }
            if (dof_action_date == "" && dof_action_date == string.Empty)
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Please Enter DOF Action Date";
                dt.Rows.Add(dr);
                valid = 1;
            }

            if (valid == 0)
            {
                result = UpdateFactoryIRReportlevel5(dof_remarks, dof_action, dof_action_date, inspection_type, registrationNumber, inspectionMonth,
                         inspectionYear);

                if (result > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = "1";
                    dr[1] = "Successfully Updated";
                    dt.Rows.Add(dr);
                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = "2";
                    dr[1] = "Updation Failed";
                    dt.Rows.Add(dr);
                }
            }

            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int updateactschecked(string registration_no, string acts_checked, string ci3_form_req, string inspection_completed, string inspection_checklist_upload_time)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_ACTS_CHECKED]";

        if (acts_checked == "" || acts_checked == null)
            com.Parameters.Add("@acts_checked", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@acts_checked", SqlDbType.VarChar).Value = acts_checked.Trim();

        if (ci3_form_req == "" || ci3_form_req == null)
            com.Parameters.Add("@ci3_form_req", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ci3_form_req", SqlDbType.VarChar).Value = ci3_form_req.Trim();

        if (inspection_completed == "" || inspection_completed == null)
            com.Parameters.Add("@inspection_completed", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_completed", SqlDbType.VarChar).Value = inspection_completed.Trim();

        if (inspection_checklist_upload_time == "" || inspection_checklist_upload_time == null)
            com.Parameters.Add("@inspection_checklist_upload_time", SqlDbType.VarChar).Value = DBNull.Value;
        else
        {
            string[] dateinsp = inspection_checklist_upload_time.Split('/');
            com.Parameters.Add("@inspection_checklist_upload_time", SqlDbType.VarChar).Value = dateinsp[1].ToString() + "/" + dateinsp[0].ToString() + "/" + dateinsp[2].ToString();
        }

        if (registration_no == "" || registration_no == null)
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = registration_no;



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int updateCIGeneratepath(string registration_no, string ci_2_generated_path, string ci_3_generated_path)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_CI_GENERATION]";

        if (ci_2_generated_path == "" || ci_2_generated_path == null)
            com.Parameters.Add("@ci_2_generated_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ci_2_generated_path", SqlDbType.VarChar).Value = ci_2_generated_path.Trim();

        if (ci_3_generated_path == "" || ci_3_generated_path == null)
            com.Parameters.Add("@ci_3_generated_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ci_3_generated_path", SqlDbType.VarChar).Value = ci_3_generated_path.Trim();

        if (registration_no == "" || registration_no == null)
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = registration_no;



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int updatenotinspectingreasons(string registration_no, string not_inspecting_reasons)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_NOTINSPECTINGREASON]";

        if (not_inspecting_reasons == "" || not_inspecting_reasons == null)
            com.Parameters.Add("@not_inspecting_reasons", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@not_inspecting_reasons", SqlDbType.VarChar).Value = not_inspecting_reasons.Trim();

        if (registration_no == "" || registration_no == null)
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = registration_no;



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int updatecompliance(string registration_no, string compliance_report)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_COMPLIANCEREPORT";

        if (compliance_report == "" || compliance_report == null)
            com.Parameters.Add("@compliance_report", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_report", SqlDbType.VarChar).Value = compliance_report.Trim();

        if (registration_no == "" || registration_no == null)
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registration_no", SqlDbType.VarChar).Value = registration_no;



        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int updatePCBIrReport(string LineofActivity,
string DateofInspection, string IndustryEmailId, string IndustryMobileNo, string RemarksMajorObservations, string InspectionReport, string AllocationMonth,
string AllocationYear, string InspectionAllocatedToEmp, string IndustryId, string referenceno)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_PCB_INSPECTIONREPORT]";

        if (AllocationMonth == "" || AllocationMonth == null)
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = AllocationMonth.Trim();

        if (AllocationYear == "" || AllocationYear == null)
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = AllocationYear.Trim();

        if (InspectionAllocatedToEmp == "" || InspectionAllocatedToEmp == null)
            com.Parameters.Add("@InspectionAllocatedToEmp", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@InspectionAllocatedToEmp", SqlDbType.VarChar).Value = InspectionAllocatedToEmp.Trim();

        if (IndustryId == "" || IndustryId == null)
            com.Parameters.Add("@IndustryId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IndustryId", SqlDbType.VarChar).Value = IndustryId.Trim();

        if (LineofActivity == "" || LineofActivity == null)
            com.Parameters.Add("@LineofActivity", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@LineofActivity", SqlDbType.VarChar).Value = LineofActivity.Trim();

        if (DateofInspection != "" && DateofInspection != null)
        {
            string[] dateinsp = DateofInspection.Split('/');
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = dateinsp[1].ToString() + "/" + dateinsp[0].ToString() + "/" + dateinsp[2].ToString();
        }

        else
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = DBNull.Value;

        if (referenceno == "" || referenceno == null)
             com.Parameters.Add("@referenceno", SqlDbType.VarChar).Value = DBNull.Value;
        else
             com.Parameters.Add("@referenceno", SqlDbType.VarChar).Value = referenceno.Trim();
        
        //if (DateofInspection != null && DateofInspection != "")
        //{

        //}

        //com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = cmf.convertDateIndia(DateofInspection.Trim());

        if (IndustryEmailId == "" || IndustryEmailId == null)
            com.Parameters.Add("@IndustryEmailId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IndustryEmailId", SqlDbType.VarChar).Value = IndustryEmailId.Trim();

        if (IndustryMobileNo == "" || IndustryMobileNo == null)
            com.Parameters.Add("@IndustryMobileNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IndustryMobileNo", SqlDbType.VarChar).Value = IndustryMobileNo.Trim();


        if (RemarksMajorObservations == "" || RemarksMajorObservations == null)
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = RemarksMajorObservations.Trim();

        if (InspectionReport == "" || InspectionReport == null)
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = InspectionReport.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int UpdateFactoryIRReport(string type_of_orders, string show_cause_file_no, string action_taken, string general_remarks_by_officer,
string ir_path, string io_path, string scn_path, string ir_uploaded, string ir_uploaded_time, string working_or_closed_factory, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_FACTORYCENTRALINSP_LEVEL1]";

        if (type_of_orders == "" || type_of_orders == null)
            com.Parameters.Add("@type_of_orders", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@type_of_orders", SqlDbType.VarChar).Value = type_of_orders.Trim();

        if (show_cause_file_no == "" || show_cause_file_no == null)
            com.Parameters.Add("@show_cause_file_no", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@show_cause_file_no", SqlDbType.VarChar).Value = show_cause_file_no.Trim();

        if (action_taken == "" || action_taken == null)
            com.Parameters.Add("@action_taken", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@action_taken", SqlDbType.VarChar).Value = action_taken.Trim();

        if (general_remarks_by_officer == "" || general_remarks_by_officer == null)
            com.Parameters.Add("@general_remarks_by_officer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@general_remarks_by_officer", SqlDbType.VarChar).Value = general_remarks_by_officer.Trim();

        if (ir_path == "" || ir_path == null)
            com.Parameters.Add("@ir_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ir_path", SqlDbType.VarChar).Value = ir_path.Trim();

        if (io_path == "" || io_path == null)
            com.Parameters.Add("@io_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@io_path", SqlDbType.VarChar).Value = io_path.Trim();

        if (scn_path == "" || scn_path == null)
            com.Parameters.Add("@scn_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@scn_path", SqlDbType.VarChar).Value = scn_path.Trim();


        if (ir_uploaded == "" || ir_uploaded == null)
            com.Parameters.Add("@ir_uploaded", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ir_uploaded", SqlDbType.VarChar).Value = ir_uploaded.Trim();


        if (ir_uploaded_time != "" && ir_uploaded_time != null)
        {
            string[] dateinsp = ir_uploaded_time.Split('/');
            com.Parameters.Add("@ir_uploaded_time", SqlDbType.VarChar).Value = dateinsp[1].ToString() + "/" + dateinsp[0].ToString() + "/" + dateinsp[2].ToString();
        }
        else
            com.Parameters.Add("@ir_uploaded_time", SqlDbType.VarChar).Value = DBNull.Value;
            //com.Parameters.Add("@ir_uploaded_time", SqlDbType.VarChar).Value = cmf.convertDateIndia(ir_uploaded_time.Trim());

        if (working_or_closed_factory == "" || working_or_closed_factory == null)
            com.Parameters.Add("@working_or_closed_factory", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@working_or_closed_factory", SqlDbType.VarChar).Value = working_or_closed_factory.Trim();

        if (inspection_type == "" || inspection_type == null)
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = inspection_type.Trim();

        if (registrationNumber == "" || registrationNumber == null)
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = registrationNumber.Trim();

        if (inspectionMonth == "" || inspectionMonth == null)
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = inspectionMonth.Trim();

        if (inspectionYear == "" || inspectionYear == null)
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = inspectionYear.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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


    public int UpdateFactoryIRReportlevel2(string ir_path, string io_path, string scn_path, string showcause_postal_reference, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_FACTORYCENTRALINSP_LEVEL2]";

        if (ir_path == "" || ir_path == null)
            com.Parameters.Add("@ir_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@ir_path", SqlDbType.VarChar).Value = ir_path.Trim();

        if (io_path == "" || io_path == null)
            com.Parameters.Add("@io_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@io_path", SqlDbType.VarChar).Value = io_path.Trim();

        if (scn_path == "" || scn_path == null)
            com.Parameters.Add("@scn_path", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@scn_path", SqlDbType.VarChar).Value = scn_path.Trim();

        if (showcause_postal_reference == "" || showcause_postal_reference == null)
            com.Parameters.Add("@showcause_postal_reference", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@showcause_postal_reference", SqlDbType.VarChar).Value = showcause_postal_reference.Trim();

        if (inspection_type == "" || inspection_type == null)
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = inspection_type.Trim();

        if (registrationNumber == "" || registrationNumber == null)
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = registrationNumber.Trim();

        if (inspectionMonth == "" || inspectionMonth == null)
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = inspectionMonth.Trim();

        if (inspectionYear == "" || inspectionYear == null)
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = inspectionYear.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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



    public int UpdateFactoryIRReportlevel3(string compliance_submitted, string compliance_filepath, string compliance_date, string owner_compliance_remarks, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_FACTORYCENTRALINSP_LEVEL3]";

        if (compliance_submitted == "" || compliance_submitted == null)
            com.Parameters.Add("@compliance_submitted", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_submitted", SqlDbType.VarChar).Value = compliance_submitted.Trim();

        if (compliance_filepath == "" || compliance_filepath == null)
            com.Parameters.Add("@compliance_filepath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_filepath", SqlDbType.VarChar).Value = compliance_filepath.Trim();

        if (compliance_date == "" || compliance_date == null)
            com.Parameters.Add("@compliance_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_date", SqlDbType.VarChar).Value = cmf.convertDateIndia(compliance_date.Trim());

        if (owner_compliance_remarks == "" || owner_compliance_remarks == null)
            com.Parameters.Add("@owner_compliance_remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@owner_compliance_remarks", SqlDbType.VarChar).Value = owner_compliance_remarks.Trim();

        if (inspection_type == "" || inspection_type == null)
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = inspection_type.Trim();

        if (registrationNumber == "" || registrationNumber == null)
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = registrationNumber.Trim();

        if (inspectionMonth == "" || inspectionMonth == null)
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = inspectionMonth.Trim();

        if (inspectionYear == "" || inspectionYear == null)
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = inspectionYear.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int UpdateFactoryIRReportlevel4(string showcause_postal_reference, string compliance_action, string compliance_action_takenby, string compliance_remarks_by_officer, string comp_verig_remarks_by_officer, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_FACTORYCENTRALINSP_LEVEL4]";

        if (showcause_postal_reference == "" || showcause_postal_reference == null)
            com.Parameters.Add("@showcause_postal_reference ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@showcause_postal_reference ", SqlDbType.VarChar).Value = showcause_postal_reference.Trim();

        if (compliance_action == "" || compliance_action == null)
            com.Parameters.Add("@compliance_action", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_action", SqlDbType.VarChar).Value = compliance_action.Trim();

        if (compliance_action_takenby == "" || compliance_action_takenby == null)
            com.Parameters.Add("@compliance_action_takenby", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_action_takenby", SqlDbType.VarChar).Value = compliance_action_takenby.Trim();

        if (compliance_remarks_by_officer == "" || compliance_remarks_by_officer == null)
            com.Parameters.Add("@compliance_remarks_by_officer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@compliance_remarks_by_officer", SqlDbType.VarChar).Value = compliance_remarks_by_officer.Trim();

        if (comp_verig_remarks_by_officer == "" || comp_verig_remarks_by_officer == null)
            com.Parameters.Add("@comp_verig_remarks_by_officer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@comp_verig_remarks_by_officer", SqlDbType.VarChar).Value = comp_verig_remarks_by_officer.Trim();

        if (inspection_type == "" || inspection_type == null)
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = inspection_type.Trim();

        if (registrationNumber == "" || registrationNumber == null)
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = registrationNumber.Trim();

        if (inspectionMonth == "" || inspectionMonth == null)
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = inspectionMonth.Trim();

        if (inspectionYear == "" || inspectionYear == null)
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = inspectionYear.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int UpdateFactoryIRReportlevel5(string dof_remarks, string dof_action, string dof_action_date, string inspection_type, string registrationNumber, string inspectionMonth,
string inspectionYear)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_FACTORYCENTRALINSP_LEVEL5]";

        if (dof_remarks == "" || dof_remarks == null)
            com.Parameters.Add("@dof_remarks ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dof_remarks ", SqlDbType.VarChar).Value = dof_remarks.Trim();

        if (dof_action == "" || dof_action == null)
            com.Parameters.Add("@dof_action ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dof_action ", SqlDbType.VarChar).Value = dof_action.Trim();

        if (dof_action_date == "" || dof_action_date == null)
            com.Parameters.Add("@dof_action_date", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@dof_action_date", SqlDbType.VarChar).Value = cmf.convertDateIndia(dof_action_date.Trim());


        if (inspection_type == "" || inspection_type == null)
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspection_type", SqlDbType.VarChar).Value = inspection_type.Trim();

        if (registrationNumber == "" || registrationNumber == null)
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@registrationNumber", SqlDbType.VarChar).Value = registrationNumber.Trim();

        if (inspectionMonth == "" || inspectionMonth == null)
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionMonth", SqlDbType.VarChar).Value = inspectionMonth.Trim();

        if (inspectionYear == "" || inspectionYear == null)
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@inspectionYear", SqlDbType.VarChar).Value = inspectionYear.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    [WebMethod]
    public string UpdateBoilerInspectionReport(string DateofInspection, string Remarksobserved, string InspectionReport, string Month,
string Year, string uplodedby, string boilermakerno, string reportuploaddate)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateBOILERIrReport(DateofInspection, Remarksobserved, InspectionReport, Month, Year, uplodedby, boilermakerno, reportuploaddate);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string UpdateLegalInspectionReport(string DateofInspection, string Remarksobserved, string InspectionReport, string Month,
string Year, string uplodedby, string Licenseno, string reportuploaddate)
    {
        try
        {
            int result = 0;
            string lblmsg = "";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ErrorCode");
            dt.Columns.Add("ErrorDescription");

            int valid = 0;
            result = updateLEGALIrReport(DateofInspection, Remarksobserved, InspectionReport, Month, Year, uplodedby, Licenseno, reportuploaddate);


            if (result > 0)
            {
                dr = dt.NewRow();
                dr[0] = "1";
                dr[1] = "Successfully Updated";
                dt.Rows.Add(dr);
            }
            else
            {
                dr = dt.NewRow();
                dr[0] = "2";
                dr[1] = "Updation Failed";
                dt.Rows.Add(dr);
            }
            ds = new DataSet();
            ds.Tables.Add(dt);
            lblmsg = ds.GetXml();

            return lblmsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int updateBOILERIrReport(string DateofInspection, string RemarksMajorObservations, string InspectionReport, string AllocationMonth,
string AllocationYear, string uplodedby, string boilermakerno, string reportuploaddate)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_BOILER_INSPECTIONREPORT]";

        if (AllocationMonth == "" || AllocationMonth == null)
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = AllocationMonth.Trim();

        if (AllocationYear == "" || AllocationYear == null)
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = AllocationYear.Trim();

        if (boilermakerno == "" || boilermakerno == null)
            com.Parameters.Add("@boilermakerno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@boilermakerno", SqlDbType.VarChar).Value = boilermakerno.Trim();

        if (RemarksMajorObservations == "" || RemarksMajorObservations == null)
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = RemarksMajorObservations.Trim();

        if (uplodedby == "" || uplodedby == null)
            com.Parameters.Add("@uplodedby", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@uplodedby", SqlDbType.VarChar).Value = uplodedby.Trim();

        if (DateofInspection != "" && DateofInspection != null)
        {
            string[] dateinsp = DateofInspection.Split('/');
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = dateinsp[1].ToString() + "/" + dateinsp[0].ToString() + "/" + dateinsp[2].ToString();
        }

        else
        {
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = DBNull.Value;
        }
        if (reportuploaddate != "" && reportuploaddate != null)
        {
            string[] datereport = DateofInspection.Split('/');
            com.Parameters.Add("@reportuploaddate", SqlDbType.VarChar).Value = datereport[1].ToString() + "/" + datereport[0].ToString() + "/" + datereport[2].ToString();
        }

        else
        {
            com.Parameters.Add("@reportuploaddate", SqlDbType.VarChar).Value = DBNull.Value;
        }


        if (InspectionReport == "" || InspectionReport == null)
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = InspectionReport.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

    public int updateLEGALIrReport(string DateofInspection, string RemarksMajorObservations, string InspectionReport, string AllocationMonth,
string AllocationYear, string uplodedby, string boilermakerno, string reportuploaddate)
    {

        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[USP_UPD_LEGAL_INSPECTIONREPORT]";

        if (AllocationMonth == "" || AllocationMonth == null)
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationMonth", SqlDbType.VarChar).Value = AllocationMonth.Trim();

        if (AllocationYear == "" || AllocationYear == null)
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AllocationYear", SqlDbType.VarChar).Value = AllocationYear.Trim();

        if (boilermakerno == "" || boilermakerno == null)
            com.Parameters.Add("@boilermakerno", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@boilermakerno", SqlDbType.VarChar).Value = boilermakerno.Trim();

        if (RemarksMajorObservations == "" || RemarksMajorObservations == null)
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@RemarksMajorObservations", SqlDbType.VarChar).Value = RemarksMajorObservations.Trim();

        if (uplodedby == "" || uplodedby == null)
            com.Parameters.Add("@uplodedby", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@uplodedby", SqlDbType.VarChar).Value = uplodedby.Trim();

        if (DateofInspection != "" && DateofInspection != null)
        {
            string[] dateinsp = DateofInspection.Split('/');
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = dateinsp[1].ToString() + "/" + dateinsp[0].ToString() + "/" + dateinsp[2].ToString();
        }

        else
        {
            com.Parameters.Add("@DateofInspection", SqlDbType.VarChar).Value = DBNull.Value;
        }
        if (reportuploaddate != "" && reportuploaddate != null)
        {
            string[] datereport = DateofInspection.Split('/');
            com.Parameters.Add("@reportuploaddate", SqlDbType.VarChar).Value = datereport[1].ToString() + "/" + datereport[0].ToString() + "/" + datereport[2].ToString();
        }

        else
        {
            com.Parameters.Add("@reportuploaddate", SqlDbType.VarChar).Value = DBNull.Value;
        }


        if (InspectionReport == "" || InspectionReport == null)
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@InspectionReport", SqlDbType.VarChar).Value = InspectionReport.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
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

}
