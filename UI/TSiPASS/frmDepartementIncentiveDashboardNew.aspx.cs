using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSiPASS_frmDepartementIncentiveDashboardNew : System.Web.UI.Page
{
    //designed by siva as on 29-1-2016 
    //Purpose : Report for Year wise dashboard
    //Tables used : All
    //Stored procedures Used :YearwiseDashboardforAdmin

    General Gen = new General();
    string dist = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            //if (Session["uid"].ToString() == "1213")
            //{
            //    Session["DistrictID"] = "%";
            //}

            //else
            //{


            //}
            if (Session["userlevel"].ToString() != "10")
            {
                trGmDashboard.Visible = false;
            }
            else
            {

                trGmDashboard.Visible = true;
            }


            //if (Session["uid"].ToString() == "1213")
            //{
            //    string dist = "%";
            //}

            //else
            //{
            //    string dist = Session["DistrictID"].ToString();
            //}

            FillDetails();
        }


    }

    void FillDetails()
    {
        //Label1.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label2.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label4.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();


        //Label6.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label8.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();


        //Label11.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label12.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label13.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

        //Label17.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label9.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

        //Label18.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label3.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label21.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label22.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label5.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label7.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
        //Label10.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

        DataSet ds = new DataSet();


        ds = Gen.GetDepartmentIncentiveDashboardNewIncType(Session["DistrictID"].ToString().Trim());//Session["User_Code"].ToString().Trim()Session["DistrictID"].ToString().Trim()
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblAppl.Text = ds.Tables[0].Rows[0]["No of Applications Received"].ToString();
            lblPending.Text = ds.Tables[0].Rows[0]["Inspection - Assigned to Inspecting Officer"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

            Label8.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Scheduled"].ToString();

            lblAssigned.Text = ds.Tables[0].Rows[0]["Inspection - Total Yet to assigned"].ToString();

            Label15.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report Uploaded 48 Hrs"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report Uploaded Beyond"].ToString();

            Label11.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report not Uploaded 48 Hrs"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report  not Uploaded Beyond"].ToString();
            Label17.Text = ds.Tables[0].Rows[0]["GM certificate uploaded"].ToString();
            Label18.Text = ds.Tables[0].Rows[0]["Recommanded to DIPC"].ToString();
            Label19.Text = ds.Tables[0].Rows[0]["Recommanded to COI"].ToString();


            Label5.Text = ds.Tables[0].Rows[0]["Sanctioned Cases"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Sanctioned Incentives"].ToString();


            Label1.Text = ds.Tables[0].Rows[0]["GMRejected"].ToString();

            LblReptiveApplications.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer Repeative"].ToString();


            Label3.Text = ds.Tables[0].Rows[0]["NothavePowerConnection"].ToString();

            //if (session["userlevel"].tostring() == "10")
            //{
            //label6.text = ds.tables[0].rows[0]["assigned by gm1"].tostring();

            //label4.text = ds.tables[0].rows[0]["inspection - inspection yet to scheduled1"].tostring();

            //label10.text = "0";

            //  label13.text = "0";

            //label14.text = "0";

            //label20.text = "0";

            ///label21.text = "0";


            //label10.text = ds.tables[0].rows[0]["inspection - inspection scheduled1"].tostring();

            //label13.text = ds.tables[0].rows[0]["inspection - inspection report uploaded 48 hrs1"].tostring();

            //label14.text = ds.tables[0].rows[0]["inspection - inspection report uploaded beyond1"].tostring();

            //label20.text = ds.tables[0].rows[0]["inspection - inspection report not uploaded 48 hrs1"].tostring();

            //label21.text = ds.tables[0].rows[0]["inspection - inspection report  not uploaded beyond1"].tostring();


            //}


            //  Label3.Text = "1";
            //Label6.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();




            //Label16.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();




            //Label20.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

            //Label20.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label21.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

            //Label23.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label24.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

            //Label26.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label27.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label28.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label29.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label30.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();

            //Label5.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label4.Text = ds.Tables[0].Rows[0]["Inspection - Yet Assigned to Inspecting Officer"].ToString();
            //Label12.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
            //Label18.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
            //Label3.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
            //Label21.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
            //Label22.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
            //Label6.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
            //Label8.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
            //Label1.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
            //Label2.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            //Label5.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
            //Label11.Text = ds.Tables[0].Rows[0]["No of Approvals Awaiting Payment"].ToString();
            //Label7.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            //Label9.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            //Label10.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
            //Label17.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            //Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();
        }



        // DataSet ds = Gen.YearwiseDashboardforAdmin("2016");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    lbl0.Text = ds.Tables[0].Rows[0]["cnt"].ToString();
        //    lbl1.Text = ds.Tables[1].Rows[0]["cnt"].ToString();
        //    lbl2.Text = ds.Tables[2].Rows[0]["cnt"].ToString();
        //    lbl3.Text = ds.Tables[3].Rows[0]["cnt"].ToString();
        //    lbl4.Text = ds.Tables[4].Rows[0]["cnt"].ToString();
        //    lbl5.Text = ds.Tables[5].Rows[0]["cnt"].ToString();
        //    lbl6.Text = ds.Tables[6].Rows[0]["cnt"].ToString();
        //    lbl7.Text = ds.Tables[7].Rows[0]["cnt"].ToString();
        //    lbl8.Text = ds.Tables[8].Rows[0]["cnt"].ToString();
        //    lbl9.Text = ds.Tables[9].Rows[0]["cnt"].ToString();
        //    lbl10.Text = ds.Tables[10].Rows[0]["cnt"].ToString();
        //    lbl11.Text = ds.Tables[11].Rows[0]["cnt"].ToString();
        //    lbl12.Text = ds.Tables[12].Rows[0]["cnt"].ToString();
        //    lbl13.Text = ds.Tables[13].Rows[0]["cnt"].ToString();


        //}
    }


}