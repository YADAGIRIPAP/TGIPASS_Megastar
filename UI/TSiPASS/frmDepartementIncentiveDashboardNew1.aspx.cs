using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection.Emit;

public partial class UI_TSiPASS_frmDepartementIncentiveDashboardNew1 : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    //designed by siva as on 29-1-2016 
    //Purpose : Report for Year wise dashboard
    //Tables used : All
    //Stored procedures Used :YearwiseDashboardforAdmin

    General Gen = new General();
    string dist = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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

                    //  trGmDashboard.Visible = true;   // commented on 10.06.2017
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

                if (Session["DummyLogin"] != null)
                {
                    //if (Session["DummyLogin"].ToString() == "")
                    //{
                    //    trsection1.Visible = true;
                    //    trGmDashboard.Visible = false;
                    //    Table1.Visible = false;
                    //    Table2.Visible = false;
                    //    trsection2.Visible = false;
                    //    trsection3.Visible = false;
                    //    trsection4.Visible = false;
                    //    trsection5.Visible = false;
                    //    trsection6.Visible = false;
                    //    trsection7.Visible = false;
                    //    trsection8.Visible = false;
                    //    trsection9.Visible = false;
                    //    trsection10.Visible = false;
                    //    trsection11.Visible = false;
                    //    trsection12.Visible = false;
                    //    trsection13.Visible = false;
                    //}
                }
            }
        }
        catch (Exception ex)//in case of an error
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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


       // ds = Gen.GetDepartmentIncentiveDashboardNewIncType(Session["DistrictID"].ToString().Trim());//Session["User_Code"].ToString().Trim()Session["DistrictID"].ToString().Trim()
        ds = GetDepartmentIncentiveDashboardNewIncType(Session["DistrictID"].ToString().Trim());//Session["User_Code"].ToString().Trim()Session["DistrictID"].ToString().Trim()

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblslcrecved.Text = ds.Tables[0].Rows[0]["NoofapplicationsrecvdSLC"].ToString();
            lblDIPCAgenda.Text = ds.Tables[0].Rows[0]["SCRwithinSLCag"].ToString();
            lblDIPCAgenda2.Text = ds.Tables[0].Rows[0]["SCRBeyondSLCag"].ToString();
            lblDIPCUploadProc.Text = ds.Tables[0].Rows[0]["SCRwithinSLC"].ToString();
            lblDIPCUploadProc2.Text = ds.Tables[0].Rows[0]["SCRBeyondSLC"].ToString();
            Label28.Text = ds.Tables[0].Rows[0]["slctotal"].ToString();
            lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["SCRwithinCOMSLC"].ToString();
            lblDIPCReleasePendings2.Text = ds.Tables[0].Rows[0]["SCRBeyondCOMSLC"].ToString();
            slcrejected.Text = ds.Tables[0].Rows[0]["SCRRejectedCOMSLC"].ToString();

            //lblDIPCAgenda.Text = ds.Tables[0].Rows[0]["DIPCAGENDA"].ToString();
            //lblDIPCReleasePendings.Text = ds.Tables[0].Rows[0]["DIPCAPPROVEDLIST"].ToString();
            //lblDIPCUploadProc.Text = ds.Tables[0].Rows[0]["DIPCUPLOADPROCEEDINGS"].ToString();
            //Label28.Text = ds.Tables[0].Rows[0]["DIPCUPLOADPROCEEDINGS"].ToString();


            lblAppl.Text = ds.Tables[0].Rows[0]["No of Applications Received"].ToString();


            lblPendingWithin.Text = ds.Tables[0].Rows[0]["Pending Within 7 Days"].ToString();
            lblPendingBeyond.Text = ds.Tables[0].Rows[0]["Pending Beyond 7 Days"].ToString();
            lblPendingBeyondTomorrow.Text = ds.Tables[0].Rows[0]["BeyondApplicationforTomorrow"].ToString();
            lbltotalinspectionsbeyond.Text = ds.Tables[0].Rows[0]["TotalBeyondInspections"].ToString();

            lblinspectionnotdoneManufacturing.Text = ds.Tables[0].Rows[0]["ManufacturingBeyond"].ToString();
            lblinspectionnotdoneTransport.Text = ds.Tables[0].Rows[0]["ServiceTransportBeyond"].ToString();
            lblinspectionnotdoneOther.Text = ds.Tables[0].Rows[0]["ServiceOtherBeyond"].ToString();

            lblQueryRespondedwithin.Text = ds.Tables[0].Rows[0]["query Pending Within 7 Days"].ToString();
            lblQueryRespondedbeyond.Text = ds.Tables[0].Rows[0]["query Pending Beyond 7 Days"].ToString();

            lblcomWithin.Text = ds.Tables[0].Rows[0]["Completed Within 7 Days"].ToString();
            lblcombeyond.Text = ds.Tables[0].Rows[0]["Completed Beyond 7 Days"].ToString();
            // Label7.Text = ds.Tables[0].Rows[0]["Query Raised"].ToString();
            Label26.Text = ds.Tables[0].Rows[0]["Query Responed"].ToString();
            Label27.Text = ds.Tables[0].Rows[0]["Yet Query Responed"].ToString();
            lblAutorejected.Text = ds.Tables[0].Rows[0]["Auto Rejected"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Insp Assigned Within 7 Days"].ToString();  //within
            lblApprovedByndSvn.Text = ds.Tables[0].Rows[0]["Insp Assigned Beyond 7 Days"].ToString();  //beyond

            lblAssigned.Text = ds.Tables[0].Rows[0]["Total Insp Assigned"].ToString();

            lblScheduledW.Text = ds.Tables[0].Rows[0]["Inspections Scheduled Within"].ToString();
            lblScheduledB.Text = ds.Tables[0].Rows[0]["Inspections Scheduled Beyond"].ToString();
            lblScheduledTotal.Text = ds.Tables[0].Rows[0]["Inspections Scheduled"].ToString();
            //----------------added on 25-02-2025 sowjanya------------------------------
            lblOfficertochange.Text = ds.Tables[0].Rows[0]["TotalInspAssigned_OfficerNotChanged"].ToString();
            lblOfficerchanged.Text = ds.Tables[0].Rows[0]["TotalInspAssigned_OfficerChanged"].ToString();
            //Insp Not Upload Total
            lblTotRptNotUpld.Text = ds.Tables[0].Rows[0]["Insp Not Upload Total"].ToString();
            lblTotRptNotUpldNeedtoRollback.Text = ds.Tables[0].Rows[0]["InspNotUpload_torollback"].ToString();
            // Label8.Text = ds.Tables[0].Rows[0]["Total Insp Scheduled"].ToString();

            Label15.Text = ds.Tables[0].Rows[0]["Insp Upload Witin"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Insp Upload Beyond"].ToString();

            Label11.Text = ds.Tables[0].Rows[0]["Insp Not Upload Witin"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Insp Not Upload Beyond"].ToString();

            Label6.Text = ds.Tables[0].Rows[0]["Total Insp Assigned GM"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["Total Insp Yet Assigned GM"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Total Insp Scheduled GM"].ToString();

            Label13.Text = ds.Tables[0].Rows[0]["Insp Upload Witin GM"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["Insp Upload Beyond GM"].ToString();

            Label20.Text = ds.Tables[0].Rows[0]["Insp Not Upload Witin GM"].ToString();
            Label21.Text = ds.Tables[0].Rows[0]["Insp Not Upload Beyond GM"].ToString();

            Label18.Text = ds.Tables[0].Rows[0]["Recommended to DIPC Within"].ToString();
            Label9.Text = ds.Tables[0].Rows[0]["Recommended to DIPC Beyond"].ToString();

            Label19.Text = ds.Tables[0].Rows[0]["Recommended to COI Within"].ToString();
            Label22.Text = ds.Tables[0].Rows[0]["Recommended to COI Beyond"].ToString();

            Label2.Text = ds.Tables[0].Rows[0]["Total Sanctioned"].ToString();

            Label1.Text = ds.Tables[0].Rows[0]["GM Rejected"].ToString();

            Label5.Text = ds.Tables[0].Rows[0]["Sanctioned Within 60 Days"].ToString();

            Label23.Text = ds.Tables[0].Rows[0]["Sanctioned Beyond 60 Days"].ToString();

            Label24.Text = ds.Tables[0].Rows[0]["Released Within 180 Days"].ToString();
            Label25.Text = ds.Tables[0].Rows[0]["Released Beyond 180 Days"].ToString();

            lblQueriesfromcoi.Text = ds.Tables[0].Rows[0]["COIQueryRsd"].ToString();
            lblqueriesrespondedcoi.Text = ds.Tables[0].Rows[0]["COIQueryResponded"].ToString();
            Label31.Text = ds.Tables[0].Rows[0]["COIQueryRsdApplicant"].ToString();
            Label42.Text = ds.Tables[0].Rows[0]["COIQueryRsdApplicantAGAINGMQueryRsdApplicant"].ToString();
            lblqueriestotalcoi.Text = ds.Tables[0].Rows[0]["COITotalQueryRsd"].ToString();

            if (ds.Tables[0].Rows[0]["GMQueryResponse"].ToString() != null && ds.Tables[0].Rows[0]["GMQueryResponse"].ToString() != "")
            {
                lblGMQueryRespond.Text = ds.Tables[0].Rows[0]["GMQueryResponse"].ToString();
            }
            if (ds.Tables[0].Rows[0]["SSCInspectionAppReport"].ToString() != null && ds.Tables[0].Rows[0]["SSCInspectionAppReport"].ToString() != "")
            {
                lblssccompleted.Text = ds.Tables[0].Rows[0]["SSCInspectionAppReport"].ToString();
            }
            lblpendingtoberefferdW.Text = ds.Tables[0].Rows[0]["within Pending to be Reffered"].ToString();
            lblpendingtoberefferdB.Text = ds.Tables[0].Rows[0]["beyond Pending to be Reffered"].ToString();

            lblAfrerInspectionawaiting.Text = ds.Tables[0].Rows[0]["Pending Query Raised after inspection"].ToString();
            lblAfrerInspectionwithin.Text = ds.Tables[0].Rows[0]["Pending Query Raised after inspection within"].ToString();
            lblAfrerInspectionbeyond.Text = ds.Tables[0].Rows[0]["Pending Query Raised after inspection Beyond"].ToString();
            lblAfrerInspection.Text = ds.Tables[0].Rows[0]["Total Pending Query Raised after inspection Beyond"].ToString();

            lblworkingstatus.Text = ds.Tables[0].Rows[0]["Working Status"].ToString();

            lblworkingstatusDLC.Text = ds.Tables[0].Rows[0]["Working Status DLC"].ToString();

            Label7.Text = ds.Tables[0].Rows[0]["IPOQueryRsd"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["ApplicantIPOQueryRsd"].ToString();
            Label29.Text = ds.Tables[0].Rows[0]["ApplicantIPOQueryRsdRespnce"].ToString();
            Label30.Text = ds.Tables[0].Rows[0]["JD Rejected SLC Cases"].ToString();

            Label32.Text = ds.Tables[0].Rows[0]["UCUpdatedListSLC"].ToString();
            Label44.Text = ds.Tables[0].Rows[0]["UCABHEYANCEDUNITSListSLC"].ToString();
            Label46.Text = ds.Tables[0].Rows[0]["UCABHEYANCEDUNITSListDLC"].ToString();
            Label34.Text = ds.Tables[0].Rows[0]["UCUpdatedListDLC"].ToString();


            Label35.Text = ds.Tables[0].Rows[0]["RejectedByjd"].ToString();
            Label36.Text = ds.Tables[0].Rows[0]["rejectedbyaddl"].ToString();
            Label37.Text = ds.Tables[0].Rows[0]["Rejectedsvc"].ToString();
            Label38.Text = ds.Tables[0].Rows[0]["RejectedSLC"].ToString();

            Label39.Text = ds.Tables[0].Rows[0]["Holdbyjd"].ToString();
            Label40.Text = ds.Tables[0].Rows[0]["Holdbyaddl"].ToString();

            lblrejectedafterinsp.Text = ds.Tables[0].Rows[0]["GM Rejected AFTER INSP"].ToString();

            Label41.Text = ds.Tables[0].Rows[0]["HoldbyDIC"].ToString();
            lblAgreementSLC.Text = ds.Tables[0].Rows[0]["lblAgreementSLC"].ToString();
            lblAgreementSLC0.Text = ds.Tables[0].Rows[0]["lblAgreementDLC"].ToString();



            /////code added by madhuri on 18/03/2021/////////////
            LBLReplied.Text = ds.Tables[0].Rows[0]["lblrepliedshowcause"].ToString();
            LBLNotReplied.Text = ds.Tables[0].Rows[0]["lblpendingshowcause"].ToString();
            LBLTOTALSHOWCAUSE.Text =Convert.ToString( Convert.ToInt32( ds.Tables[0].Rows[0]["lblrepliedshowcause"].ToString())
                + Convert.ToInt32(ds.Tables[0].Rows[0]["lblpendingshowcause"].ToString()));
            Label3.Text = "0";


            ///end of added code/////
            //
            //lblAssigned.Text = ds.Tables[0].Rows[0]["Inspection - Total Yet to assigned"].ToString();

            //Label15.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report Uploaded 48 Hrs"].ToString();


            //Label11.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report not Uploaded 48 Hrs"].ToString();
            //Label12.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report  not Uploaded Beyond"].ToString();
            //Label17.Text = ds.Tables[0].Rows[0]["GM certificate uploaded"].ToString();
            //Label18.Text = ds.Tables[0].Rows[0]["Recommanded to DIPC"].ToString();
            //Label18.Text = ds.Tables[0].Rows[0]["Recommanded to DIPC"].ToString();
            //Label19.Text = ds.Tables[0].Rows[0]["Recommanded to COI"].ToString();


            //Label5.Text = ds.Tables[0].Rows[0]["Sanctioned Cases"].ToString();
            //Label2.Text = ds.Tables[0].Rows[0]["Sanctioned Incentives"].ToString();


            //Label1.Text = ds.Tables[0].Rows[0]["GMRejected"].ToString();

            LblReptiveApplications.Text = "0";


            //

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
            Label17.Text = "0";
            //Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();
        }
        try
        {
            Officers(Session["DistrictID"].ToString().Trim());
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";

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

    public DataSet GetDepartmentIncentiveDashboardNewIncType(string intDistrictid)   //nikhil - incentive
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("sp_GetDepartmentIncentiveDashboard", con.GetConnection);

            da = new SqlDataAdapter("sp_GetDepartmentIncentiveDashboardNewIncTypeNew", con.GetConnection);

            // da = new SqlDataAdapter("sp_GetDepartmentIncentiveDashboardNewIncTypenew", con.GetConnection);

            //sp_GetDepartmentIncentiveDashboardNewIncType
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intDistrictid.Trim() == "" || intDistrictid.Trim() == null || intDistrictid.Trim() == "--Select--" || intDistrictid.Trim() == "0")
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.ToString();

            da.SelectCommand.CommandTimeout = 3600;
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

    public void Officers(string DistID)
    {
        try
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDepartmentINcentiveNew(DistID);//distid    DistID

            if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
            {
                gvqueryresponse.DataSource = dsnew.Tables[1];
                gvqueryresponse.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
}