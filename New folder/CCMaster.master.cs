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
using System.Text;
//using System.Data.SqlClient;


public partial class CCMaster : System.Web.UI.MasterPage
{
    CommonBL objcommon = new CommonBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //TSTDashboard.Visible = false;
        //IPDashboard.Visible = false;
        if (!IsPostBack)
        {
            //string fullUrl = Request.Url.ToString();
            //if (fullUrl != "")
            //{
            //    General clsGeneral = new General();
            //    SqlParameter[] p = new SqlParameter[]
            //           {
            //        new SqlParameter("@userid", SqlDbType.VarChar),
            //        new SqlParameter("@username", SqlDbType.VarChar),
            //        new SqlParameter("@IPAddress", SqlDbType.VarChar),
            //         new SqlParameter("@Pagename", SqlDbType.VarChar),
            //        new SqlParameter("@result", SqlDbType.Int)
            //           };
            //    p[0].Value = Convert.ToString(Session["uid"]);
            //    p[1].Value = Convert.ToString(Session["username"]);
            //    p[2].Value = getclientIP();
            //    p[3].Value = fullUrl;
            //    p[4].Value = 0;
            //    p[4].Direction = ParameterDirection.Output;
            //    int i = clsGeneral.GenericExecuteNonQuery("InsPagesaccessedbyusers", p);
            //}
            DataSet ds = new DataSet();
            ds = objcommon.GetHomepagecontete();
            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                lbllastupdat.Text = ds.Tables[4].Rows[0]["LastDate"].ToString();
            }
        }
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }

        if (Session.Count > 0)
        {
            lblwecome.Text = Session["username"].ToString();
            //    if (Session["user_type"].ToString() == "Adm")
            //    {
            //        TST.Visible = false;
            //        Masters.Visible = true;
            //        IP.Visible = false;
            LEODB.Visible = false;
            liRawMaterial.Visible = false;
            Li2.Visible = false;
            liIncentive.Visible = false;
            Li7Dist.Visible = false;
            Li8Grievance.Visible = false;
            LiBankLoan.Visible = false;
            LiincentiveReport.Visible = false;
            Li14.Visible = false;
            Li15.Visible = false;
            if (Session["userlevel"].ToString() == "10")
            {
                //   Li2.Visible = true;s
            }
            else
            {
                //   Li2.Visible = false;
            }
            if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377")
            {
                LIGMCONFERENCE.Visible = true;
            }
            else
            {
                LIGMCONFERENCE.Visible = false;
            }

            if (Session["uid"].ToString() == "1238")
            {
                LIALLAPPROVALISSUED.Visible = true;
                liduplicate.Visible = true;
                liverifiednotverifieddelatedrecords.Visible = true;
            }
            else
            {
                LIALLAPPROVALISSUED.Visible = false;
                liduplicate.Visible = false;
                liverifiednotverifieddelatedrecords.Visible = false;
            }

            if (Session["uid"].ToString() == "1035")
            {
                ligroundwaterdetails.Visible = true;
            }
            else
            {
                ligroundwaterdetails.Visible = false;
            }
            if (Session["userlevel"].ToString() == "10" && Session["DistrictID"].ToString().Trim() != "")
            {
                Li8.Visible = true;//cluster
                Li10.Visible = true;//cluster
                Lidist.Visible = true;
                Licfeduplicate.Visible = true;
                Licfoduplicate.Visible = false;
                Li12.Visible = true;
                LiCFOReports.Visible = true;
            }
            else
            {
                Li8.Visible = false; //cluster
                if (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "COMM")
                {
                    Li10.Visible = true;//cluster    
                    Li12.Visible = true;
                }
            }
            if (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM")
            {
                Listate.Visible = true; // Update State Level 

            }

            if (Session["userlevel"].ToString() == "10")
            {
                Li3.Visible = true;
                Masters.Visible = false;
                TST.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = true;
                Li17.Visible = true;
                Li12.Visible = true;
                liapplTrack.Visible = true;
                LiLoan.Visible = false;
            }
            else
            {

                Li3.Visible = false;
                Masters.Visible = true;
                TST.Visible = true;
                BDC.Visible = true;
                LiLoan.Visible = true;

            }
            if (Session["userlevel"].ToString() == "25")
            {
                liInspection.Visible = true;
                TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible =
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = liMinister.Visible =
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;
                LiCFOReports.Visible = LiLoan.Visible = libatterydealer.Visible = false;
            }



            if (Session["userlevel"].ToString() == "12")
            {
                liInspection.Visible = TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible = Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = liMinister.Visible = LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = libatterydealer.Visible = false;

                LiCFOReports.Visible = LiLoan.Visible = false;
            }


            if (Session["userlevel"].ToString() == "13")
            {
                //Li3.Visible = true;
                Li_usergroundwaterapplications.Visible = true;
                TSTDashboard.Visible = true;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                liRawMaterial.Visible = true;
                liIncentive.Visible = true;
                Li8Grievance.Visible = false;
                Li8Grievance.Visible = true;
                Li12.Visible = false;
                // Li14.Visible = true;
                Li15.Visible = true;
                LiToursim.Visible = true;
                LiTravel.Visible = true;
                LiFlimShooting.Visible = true;
                Limultiplexscreening.Visible = true;
                LiMobileTower.Visible = true;
                LiAdvertisement.Visible = true;
                licomplaincedashboard.Visible = true;
                // liIncentiveNew.Visible = true;
                LiPattadar.Visible = true;//pattadarland tab
            }
            else
            {
                LiFlimShooting.Visible = false;
                Limultiplexscreening.Visible = false;
                LiMobileTower.Visible = false;
                Li14.Visible = false;
                TSTDashboard.Visible = false;
                LiToursim.Visible = false;
                LiTravel.Visible = false;
                LiAdvertisement.Visible = false;
                licomplaincedashboard.Visible = false;

                // liIncentiveNew.Visible = false;
                //                liIncentiveNew.Visible = false;
            }

            if (Session["uid"].ToString() == "9942")
            {
                liMasterData.Visible = true;
            }
            else
            {

                liMasterData.Visible = false;
            }

            if (Session["uid"].ToString() == "1222")
            {

                liREJECT.Visible = true;
            }
            else
            {

                liREJECT.Visible = false;
            }

            if (Session["uid"].ToString() == "1030")
            {

                Lindus.Visible = true;
                Li3.Visible = false;
            }
            else
            {

                Lindus.Visible = false;
            }

            if (Session["uid"].ToString() == "1238")
            {
                Li5.Visible = true;
                Li6.Visible = true;
                //  Li2.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                LiCFEReports.Visible = false;
                Li12.Visible = true;
                LiCFOReports.Visible = true;
                Li2.Visible = false;
                Lidist.Visible = true;
                Licfeduplicate.Visible = true;
                Licfoduplicate.Visible = false;
                Listate.Visible = true;
                Incentive.Visible = true;
                Li11.Visible = true;
                Liifc.Visible = false;
                LiLoan.Visible = false;
                //liIncentiveNew.Visible = true;
            }
            else
            {
                Li5.Visible = false;
                // Li11.Visible = false;
                Li6.Visible = false;
            }



            if (Session["uid"].ToString() == "1213")
            {
                liRawMaterial.Visible = true;
                Li4.Visible = true;
                Li2.Visible = false;
                LiincentiveReport.Visible = true;
                Li11.Visible = true;
                LiBankLoan.Visible = true;
                Li18.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                Li1.Visible = false;
                LiLoan.Visible = false;
                LiBankReport.Visible = true;
            }
            else
            {
                //liRawMaterial.Visible = false;
                Li4.Visible = false;
            }
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                Li7Dist.Visible = true;
            }
            if (Session["uid"].ToString() == "1622")
            {
                TSTDashboard.Visible = false;
                Li3.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Li2.Visible = false;
                Li7Dist.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                Li12.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                LiLoan.Visible = false;
            }
            if (Session["user_type"].ToString() == "11" || Session["uid"].ToString() == "1213")
            {
                liRawMaterial.Visible = false;
                rawmetrpt.Visible = true;
            }
            else
            {
                rawmetrpt.Visible = false;
            }
            //        //lblwecome.Text = "Admin";
            //    }
            //    else if (Session["user_type"].ToString() == "TST")
            //    {
            //        Masters.Visible = false;
            //        TST.Visible = true;
            //        IP.Visible = false;
            //        TSTDashboard.Visible = true;
            //        //lblwecome.Text = "Technical Support Team";
            //    }
            //    else if (Session["user_type"].ToString() == "IP")
            //    {
            //        Masters.Visible = false;
            //        TST.Visible = false;
            //        IP.Visible = true;
            //        IPDashboard.Visible = true;
            //        //lblwecome.Text = "Implementing Partner";


            //    }
            //    else if (Session["user_type"].ToString() == "BDC")
            //    {
            //        BDC.Visible = true;
            //        TST.Visible = false;
            //        //Master.Visible = false;
            //        IP.Visible = false;
            //        LiCFEReports.Visible = false;
            //        //lblwecome.Text = "Implementing Partner";
            //    }
            //    else if (Session["user_type"].ToString() == "LiCFEReports")
            //    {
            //        LiCFEReports.Visible = true;
            //        TST.Visible = false;
            //        //Master.Visible = false;
            //        IP.Visible = false;
            //        BDC.Visible = false;
            //       //lblwecome.Text = "Implementing Partner";
            //    }
            //}
            //else
            //{
            //    Response.Redirect("../../frmuserlogin.aspx");
            //}

            if (Session["userlevel"].ToString() == "1")
            {
                LiCFEReports.Visible = false;
                Li12.Visible = true;
                LiCFOReports.Visible = true;
                Li17.Visible = true;
                LEODB.Visible = true;
                liapplTrack.Visible = true;
                //LiAdminNew.Visible = true;
            }

            if (Session["userlevel"].ToString() == "2")
            {
                LiCFEReports.Visible = false;
                Li12.Visible = true;
                LiCFOReports.Visible = true;
                LEODB.Visible = true;
                liapplTrack.Visible = true;
                Li17.Visible = true;
                // LiAdminNew.Visible = true;
            }
            else
            {
                LiCFEReports.Visible = false;
                // LiCFOReports.Visible = false;
                LEODB.Visible = false;
                LiAdminNew.Visible = false;
            }

            if (Session["uid"].ToString() == "1003")
            {
                liapplTrack.Visible = true;
            }

            if (Session["uid"].ToString() == "1726")
            {
                TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible = false;
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = false;
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = LiLoan.Visible = libatterydealer.Visible = false;

                LiCFOReports.Visible = false;
                liMinister.Visible = true;
            }

            if (Session["uid"].ToString() == "1238")
            {
                paymentdet.Visible = liApproval.Visible = liPayment.Visible = lidicpcb.Visible = true;
                Li11.Visible = true;

            }

            if (Session["uid"].ToString() == "1134" || Session["uid"].ToString() == "1135" || Session["uid"].ToString() == "1136" || Session["uid"].ToString() == "1137" || Session["uid"].ToString() == "1138"
                || Session["uid"].ToString() == "1139" || Session["uid"].ToString() == "1140" || Session["uid"].ToString() == "1141" || Session["uid"].ToString() == "1142" || Session["uid"].ToString() == "1143"
              || Session["uid"].ToString() == "8613"
|| Session["uid"].ToString() == "8614"
|| Session["uid"].ToString() == "8615"
|| Session["uid"].ToString() == "8616"
|| Session["uid"].ToString() == "8617"
|| Session["uid"].ToString() == "8618"
|| Session["uid"].ToString() == "8619"
|| Session["uid"].ToString() == "8620"
|| Session["uid"].ToString() == "8621"
|| Session["uid"].ToString() == "8622"
|| Session["uid"].ToString() == "8623"
|| Session["uid"].ToString() == "8624"
|| Session["uid"].ToString() == "8625"
|| Session["uid"].ToString() == "8626"
|| Session["uid"].ToString() == "8627"
|| Session["uid"].ToString() == "8628"
|| Session["uid"].ToString() == "8629"
|| Session["uid"].ToString() == "8630"
|| Session["uid"].ToString() == "8631"
|| Session["uid"].ToString() == "8632"
|| Session["uid"].ToString() == "8633"

     )
            {

                DICDashboard.Visible = true;
                Li3.Visible = true;



            }
            if (Session["user_id"].ToString().Trim().ToLower() == "fruxhelpdesk")
            {
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                Li2.Visible = false;
            }

            if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 31 && Convert.ToInt32(Session["User_Code"].ToString()) <= 40))
            {
                MSMEReport.Visible = true;
                VATManExport.Visible = true;
            }
            if (Session["userlevel"].ToString() == "13")
            {
                MSMEReport.Visible = false;
            }

            if (Session["userlevel"].ToString() == "20")
            {
                TSTDashboard.Visible = false;
                Li3.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Li2.Visible = false;
                Li7Dist.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                MSMEReport.Visible = true;
                LiBankLoan.Visible = true;
                LiLoan.Visible = false;
            }


            if (Session["userlevel"].ToString() == "24")
            {
                TSTDashboard.Visible = false;
                Li3.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Li2.Visible = false;
                Li7Dist.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                MSMEReport.Visible = false;
                LiBankLoan.Visible = false;
                VATExportslat.Visible = true;



            }


            else
            {
                LiCFEReports.Visible = false;
                //LiCFOReports.Visible = false;
                LiincentiveReport.Visible = false;

            }


            if (Session["uid"].ToString() == "1213")
            {
                MSMEReport.Visible = true;
                //  Bankloans.Visible = true;
            }
            //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141))
            //{
            //    Li8ipopmdash.Visible = true;
            //}

            if (Session["DummyLogin"] != null && Session["Role_Code"] != null)
            {
                if (Session["Role_Code"].ToString() == "GM" && Session["DummyLogin"].ToString() != "Y")
                    LiGMDashBoard.Visible = true;


                if (Session["DummyLogin"].ToString() != "Y" && (Session["Role_Code"].ToString() == "IPO"))
                {
                    Li8ipopmdash.Visible = true;
                }

                if (Session["DummyLogin"].ToString() != "Y" && (Session["Role_Code"].ToString() == "AD"))
                {
                    Li19addash.Visible = true;
                }

                if (Session["DummyLogin"].ToString() != "Y" && (Session["Role_Code"].ToString() == "DD"))
                {
                    li20dddash.Visible = true;
                }

            }

            //    if (Session["userlevel"].ToString() == "10" && (Convert.ToInt32(Session["User_Code"].ToString()) >= 31 && Convert.ToInt32(Session["User_Code"].ToString()) <= 40))
            //{
            //    LiGMDashBoard.Visible = true;
            //}
            if (Session["userlevel"].ToString() == "1" || Session["userlevel"].ToString() == "2")
            {
                LiCommissionerReport.Visible = true;
                liGenCer.Visible = true;
                liAppeal.Visible = true;
                // liAmmendment.Visible = true;
                Li12.Visible = true;
            }
            //if (Session["uid"].ToString() == "20505" || Session["uid"].ToString() == "20604" || Session["uid"].ToString() == "20933" || Session["uid"].ToString() == "21022" || Session["uid"].ToString() == "21115" || Session["uid"].ToString() == "21160" || Session["uid"].ToString() == "21163"
            //    || Session["uid"].ToString() == "21164" || Session["uid"].ToString() == "21165" || Session["uid"].ToString() == "21348" || Session["uid"].ToString() == "21485")
            //{
            //    liIncentiveNew.Visible = true;
            //}
            //else
            //{
            //    liIncentiveNew.Visible = false;
            //}
            if (Session["userlevel"].ToString() == "35")
            {
                liAmmendment.Visible = true;
                Li7Dist.Visible = false;
                TSTDashboard.Visible = false;
                Li3.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Li2.Visible = false;
                Li7Dist.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                MSMEReport.Visible = false;
                LiBankLoan.Visible = false;
                VATExportslat.Visible = false;
                VATManExport.Visible = false;
                LiincentiveReport.Visible = false;
                Li1.Visible = false;
            }
            if (Session["uid"].ToString() == "1222")
            {

                LiCFEReports.Visible = false;
            }

            if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
            {
                Liifc.Visible = true;
                Li3.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                liAmmendment.Visible = false;
                Li1.Visible = false;
            }
            else
            {
                Liifc.Visible = false;
            }

            if (Session["user_id"].ToString().Trim().ToUpper() == "FACT" || Session["user_id"].ToString().Trim().ToUpper() == "PCB" || Session["user_id"].ToString().Trim().ToUpper() == "LABOUR" || Session["uid"].ToString() == "1238")
            {
                Li11.Visible = true;
            }
            else
            {
                Li11.Visible = false;
            }

            if (Session["uid"].ToString() == "22787" || Session["uid"].ToString() == "22855" || Session["uid"].ToString() == "22856" || Session["uid"].ToString() == "22857" || Session["uid"].ToString() == "22858" || Session["uid"].ToString() == "22859" || Session["uid"].ToString() == "22860" || Session["uid"].ToString() == "22862" || Session["uid"].ToString() == "22863" || Session["uid"].ToString() == "22864")
            {
                Lislc.Visible = true;
            }
            else
            {
                Lislc.Visible = false;
            }

            if (Session["userlevel"].ToString() == "10")
            {
                // Li12.Visible = false;
                if (Session["DistrictID"].ToString() == "")
                {
                    Li12.Visible = true;
                }
            }
            else
            {
                LiCFEReports.Visible = false;
            }

            if (Session["uid"].ToString() == "21345")
            {
                Li14new1.Visible = true;
                Li14new.Visible = false;
            }
            if (Session["uid"].ToString() == "21346")
            {
                Li14new1.Visible = false;
                Li14new.Visible = true;
            }
            if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "34670")
            {
                LiCFOReports.Visible = true;
                LiAdminNew.Visible = true;
            }
            if (Session["uid"].ToString() == "1222")
            {
                LiCFOReports.Visible = true;
            }
            if (Session["Visibleflag"].ToString().Trim().TrimStart() == "Y")
            {
                Li14.Visible = true;
            }
            else
            {
                Li14.Visible = false;
            }

            // New Changes Done By shankar
            if (Session["uid"].ToString() == "1222")   // Chassing Cell Login
            {
                Li14.Visible = false;
                Li15.Visible = false;
                Li14new.Visible = false;
                Li14new1.Visible = false;
                Liifc.Visible = false;
                TSTDashboard.Visible = false;
                Li3.Visible = false;
                Lindus.Visible = false;
                DICDashboard.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Lidist.Visible = false;
                Licfeduplicate.Visible = false;
                Licfoduplicate.Visible = false;
                Listate.Visible = false;
                Incentive.Visible = false;
                Lislc.Visible = false;
                Li2.Visible = false;


                Li7Dist.Visible = false;
                Li8.Visible = false;
                Li10.Visible = false;
                Li11.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                Li7.Visible = false;

                Li8ipopmdash.Visible = false;
                LiGMDashBoard.Visible = false;
                LiCommissionerReport.Visible = false;
                liInspection.Visible = false;
                liApproval.Visible = false;
                lidicpcb.Visible = false;
                liPayment.Visible = false;
                Li8Grievance.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;


                LEODB.Visible = false;
                liMasterData.Visible = false;
                liREJECT.Visible = false;
                liAmmendment.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                rawmetrpt.Visible = false;
                liMinister.Visible = false;
                MSMEReport.Visible = false;
                VATManExport.Visible = false;
                VATExportslat.Visible = false;
                LiBankLoan.Visible = false;
                LiincentiveReport.Visible = false;
                Li8ipopmdashOLD.Visible = false;
                Li1.Visible = false;
                LiAdminNew2.Visible = false;
                LiAdminNew1.Visible = false;
                // True Cases
                Li12.Visible = true;
                LiCFOReports.Visible = true;
                liapplTrack.Visible = true;
                Li17.Visible = true;
                liGenCer.Visible = true;
                liAppeal.Visible = true;
                li16.Visible = true;
                LiAdminNew.Visible = true;
                Li18.Visible = false;
                LiPlotdashboard.Visible = true;

            }

            if (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "DEPT")
            {
                Li12.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
            }
            if (Session["userlevel"].ToString() == "2" || Session["uid"].ToString() == "1238")
            {
                lihelpdesc.Visible = true;
            }
            if (Session["userlevel"].ToString() == "2" || Session["uid"].ToString() == "1238")// || Session["uid"].ToString() == "3377" removed on 09/12/2019
            {
                lihelpdescSoltion.Visible = true;
            }
            if (Session["uid"].ToString() == "1238")
            {
                lblappealprovision.Visible = true;
            }
            if (Session["userlevel"].ToString() == "2")
            {
                lidailyreport.Visible = true;
            }
            if (Session["DummyLogin"].ToString() == "Y")   // Chassing Cell Login
            {
                Li14.Visible = false;
                Li15.Visible = false;
                Li14new.Visible = false;
                Li14new1.Visible = false;
                Liifc.Visible = false;
                TSTDashboard.Visible = false;

                Lindus.Visible = false;
                DICDashboard.Visible = false;
                Li5.Visible = false;
                Li6.Visible = false;
                Lidist.Visible = false;
                Licfeduplicate.Visible = false;
                Licfoduplicate.Visible = false;
                Listate.Visible = false;
                Incentive.Visible = false;
                Lislc.Visible = false;
                Li2.Visible = false;


                Li7Dist.Visible = false;
                Li8.Visible = false;
                Li10.Visible = false;
                Li11.Visible = false;
                Li4.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                Li7.Visible = false;

                Li8ipopmdash.Visible = false;
                LiGMDashBoard.Visible = false;
                LiCommissionerReport.Visible = false;
                liInspection.Visible = false;
                liApproval.Visible = false;
                lidicpcb.Visible = false;
                liPayment.Visible = false;
                Li8Grievance.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;


                LEODB.Visible = false;
                liMasterData.Visible = false;
                liREJECT.Visible = false;
                liAmmendment.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                rawmetrpt.Visible = false;
                liMinister.Visible = false;
                MSMEReport.Visible = false;
                VATManExport.Visible = false;
                VATExportslat.Visible = false;
                LiBankLoan.Visible = false;
                LiincentiveReport.Visible = false;
                Li8ipopmdashOLD.Visible = false;
                Li1.Visible = false;
                LiAdminNew2.Visible = false;
                LiAdminNew1.Visible = false;
                Li12.Visible = false;
                LiCFOReports.Visible = false;
                liapplTrack.Visible = false;
                Li17.Visible = false;
                liGenCer.Visible = false;
                liAppeal.Visible = false;
                li16.Visible = false;
                LiAdminNew.Visible = false;

                Li3.Visible = true;
                Li1.Visible = false;
            }
            if (Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424" || Session["uid"].ToString() == "77141" || Session["uid"].ToString() == "34668" || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM"))
            {
                LiCoiCalender.Visible = true;
                calendarid.Visible = true;

            }

            else
            {
                LiCoiCalender.Visible = false;
                calendarid.Visible = false;

            }

            if (Session["uid"].ToString() == "33065" || Session["uid"].ToString() == "33067")
            {
                liAppraisalNote.Visible = true;
            }
            if (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM")
            {
                Licfoduplicate.Visible = true;
            }
            else
            {
                Licfoduplicate.Visible = false;
            }
            if ((Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "DD") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "IPO") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "AD") || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim() == "JDMSME")
            {
                limsmecatelogue.Visible = true;
            }
            else
            {
                limsmecatelogue.Visible = false;
            }

            if ((Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GM") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "DD") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "IPO") || (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "AD") || Session["uid"].ToString() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim() == "JDMSME" || Session["user_id"].ToString().Trim() == "AD-Naveen")
            {
                limsmereport.Visible = true;

            }
            else
            {
                limsmereport.Visible = false;
            }
            if (Session["userlevel"].ToString().Trim() == "13")
            {
                LiBankReport.Visible = false;
            }

            if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
            {
                licommreport.Visible = true;
                Li19coi.Visible = true;
                limsmecatelogue.Visible = false;
                limsmereport.Visible = false;
                Li10.Visible = false;
                Li12.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                liRawMaterial.Visible = false;
                MSMEReport.Visible = false;
                LiBankLoan.Visible = false;
                LiBankReport.Visible = false;
                LiCoiCalender.Visible = false;
                Li18.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                BDC.Visible = false;
                Li4.Visible = true;
                Li11.Visible = false;
                lbtncfereport.Visible = true;
                lbtncforeport.Visible = true;
                lidistrictreports.Visible = true;
                A3.Visible = true;
                rawmetrpt.Visible = false;
                //LiBankLoan
            }
            else
            {
                licommreport.Visible = false;
                lbtncfereport.Visible = false;
                lbtncforeport.Visible = false;
                lidistrictreports.Visible = false;
                A3.Visible = false;
                Li19coi.Visible = false;
            }

            if (Session["userlevel"].ToString() == "10")
            {
                liapplTrack.Visible = false;
                Li18.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                LiBankReport.Visible = false;
            }
            if (Session["user_id"] != null && Session["Role_Code"] != null && (Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim() == "JDMSME" || Session["user_id"].ToString().Trim() == "AD-Naveen"))
            {
                limsmereportEdited.Visible = true;
                litsipassmap.Visible = true;
            }
            else
            {
                limsmereportEdited.Visible = false;
                litsipassmap.Visible = false;
            }
            if (Session["Role_Code"] != null)
            {
                if (Session["Role_Code"].ToString().Trim() == "GM" || Session["Role_Code"].ToString().Trim() == "AD" || Session["Role_Code"].ToString().Trim() == "DD" || Session["Role_Code"].ToString().Trim() == "IPO")
                {
                    limsmereportEdited.Visible = true;
                    litsipassmap.Visible = true;
                }

            }

            if (Session["uid"].ToString().Trim() == "95120")
            {
                Li17.Visible = false;
            }
            if (Session["uid"].ToString().Trim() == "3377")
            {
                limsmereportnew.Visible = true;
            }
            else
            {
                limsmereportnew.Visible = false;
            }
            if (Session["userlevel"].ToString().Trim() == "13")
            { licentralapproval.Visible = true; }

            //    if (Session["uid"].ToString() == "48167" || Session["uid"].ToString() == "326806" || Session["uid"].ToString() == "4222" || Session["uid"].ToString() == "329388")
            //{
            //    licentralapproval.Visible = true;
            //}
            //else
            //{
            //    licentralapproval.Visible = true;
            //}

        }
        if (Session["user_id"].ToString().Contains("MRO-"))
        {
            LiCFOReports.Visible = false;
            Li12.Visible = false;
            Li17.Visible = false;

        }
        if (Session["user_id"].ToString().Trim() == "JDMSME" || Session["user_id"].ToString().Trim() == "Addl_director" || Session["user_id"].ToString().Trim() == "JD-Incentives"
            || Session["user_id"].ToString().Trim() == "cmsmadhuri")
        {
            limsmealljd.Visible = true;
        }
        else
        {
            limsmealljd.Visible = false;
        }

        if (Session["Role_Code"] != null && Session["Role_Code"].ToString() == "GWCOMM")
        {
            if (Session["user_id"].ToString().Trim().ToLower() == "gw_commissioner" || Session["user_id"].ToString().Trim().ToLower() == "gw_director")
            {
                Li_gwreports.Visible = true;
                Masters.Visible = false;
                Li18.Visible = false;
                Masters.Visible = false;
                TST.Visible = false;
                BDC.Visible = false;
                // li_newotherservices.Visible = false;
                LiLoan.Visible = false;
                liapplTrack.Visible = false;
                liGenCer.Visible = false;
                LiLoan.Visible = false;

                Li_usergroundwaterapplications.Visible = false;
                TSTDashboard.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                Li17.Visible = false;
                liRawMaterial.Visible = false;
                liIncentive.Visible = false;
                Li8Grievance.Visible = false;
                Li8Grievance.Visible = false;
                Li12.Visible = false;
                Li15.Visible = false;
                IP.Visible = false;
                libatterydealer.Visible = false;
                liAppeal.Visible = false;
                LiGMDashBoard.Visible = false;
                LiCommissionerReport.Visible = false;
                //Li19.Visible = false;
                LiBankReport.Visible = false;
                //li1_tourism.Visible = false;
                Li1.Visible = false;
            }
        }
        if (Session["uid"].ToString() == "1238")
        {
            LIALLAPPROVALISSUED.Visible = true;
            liduplicate.Visible = true;
            liverifiednotverifieddelatedrecords.Visible = true;
            Li5.Visible = false;
            Li6.Visible = false;
            Licfeduplicate.Visible = false;
            Licfoduplicate.Visible = false;
            limsmecatelogue.Visible = false;
            limsmereport.Visible = false;
            litsipassmap.Visible = false;
            limsmereportEdited.Visible = false;
            Li18.Visible = false;
            LiBMW.Visible = false;
            Li19.Visible = false;
            libatterydealer.Visible = false;
            LiGMDashBoard.Visible = false;
            LiCommissionerReport.Visible = false;
            LiCoiCalender.Visible = false;
            liApproval.Visible = false;
            lidicpcb.Visible = false;
            BDC.Visible = false;
            LiBankReport.Visible = false;
        }
        if (Session["uid"].ToString() == "1213")
        {
            litsipassmap.Visible = false;
            limsmereportEdited.Visible = false;
            liapplTrack.Visible = false;
            LiBMW.Visible = false;
            Li19.Visible = false;
        }
        if (Session["userlevel"].ToString() == "10")
        {
            licentralapproval.Visible = false;
            LiBMW.Visible = false;
            Li19.Visible = false;
            LiCFEReports.Visible = false;
            LiCFOReports.Visible = false;
            Li17.Visible = false;
            liutrnumber.Visible = true;
            if (Session["userlevel"].ToString() == "10" && Session["uid"].ToString().Trim() == "95120")
            {
                Litourismreport.Visible = true;
            }
            else
            {
                Litourismreport.Visible = false;
            }
            if (Session["Role_Code"].ToString().Trim() == "GM" || Session["Role_Code"].ToString().Trim() == "AD" || Session["Role_Code"].ToString().Trim() == "IPO"
                || Session["Role_Code"].ToString().Trim() == "DD")
            {
                Li17.Visible = true;
                LiCFOReports.Visible = true;

            }
        }

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (Session["userlevel"].ToString().Trim() == "13")
        {
            //Response.Redirect("Dashboard.aspx");
            Response.Redirect("HomeDashboard.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "25")
        {
            Response.Redirect("Home.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "12")
        {
            Response.Redirect("frmApprovelDocument.aspx");
        }
        else if (Convert.ToString(Session["uid"]) == "324563" || Convert.ToString(Session["uid"]) == "324565" ||
                   Convert.ToString(Session["uid"]) == "324566" || Convert.ToString(Session["uid"]) == "324567" ||
                   Convert.ToString(Session["uid"]) == "324568" || Convert.ToString(Session["uid"]) == "324569" ||
                   Convert.ToString(Session["uid"]) == "324570")
        {
            Response.Redirect("DashboardINC.aspx");
        }
        else if (Convert.ToString(Session["uid"]) == "3377")
        {
            Response.Redirect("HomeJDDashboard.aspx");
        }
        else if (Session["userlevel"].ToString().Trim() == "10")
        {

            if (Session["uid"].ToString().Trim() == "1030")
            {

                Response.Redirect("HomeIndusDashboard.aspx");
            }
            else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
            {
                Response.Redirect("IFCDashBoard.aspx");
            }
            else
            {
                //if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
                //{
                //    Response.Redirect("frmIPOIncentiveDashboard.aspx");
                //}
                if (Session["userlevel"].ToString().Trim() == "10")
                {
                    if (Session["Role_Code"].ToString() == "AD" || Session["Role_Code"].ToString() == "IPO" || Session["Role_Code"].ToString() == "DD")//|| ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150" || (Convert.ToInt32((Session["User_Code"].ToString())) >= 195 && (Convert.ToInt32((Session["User_Code"].ToString())) <= 265)))))
                    {
                        Response.Redirect("frmIPOIncentiveDashboardNew.aspx");
                    }
                    else
                    {
                        //Response.Redirect("frmDepartementDashboardNew.aspx");
                        Response.Redirect("HomeDeptDashboard.aspx");
                    }
                }

                //Response.Redirect("frmDepartementDashboardNew.aspx");
                //  Response.Redirect("HomeDeptDashboard.aspx");

            }

            //Response.Redirect("frmDepartementDashboardNew.aspx");
            //Response.Redirect("HomeDeptDashboard.aspx");

        }
        else
        {
            if (Session["user_id"].ToString().Trim().ToLower() == "cmshelpdesk" || Session["user_id"].ToString().Trim().ToLower() == "cmsmadhuri" || Session["user_id"].ToString().Trim().ToLower() == "kcsbabu" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "3378")
            {
                Response.Redirect("HomeCommDashboard.aspx");
            }
            else if (Session["Role_Code"].ToString() == "COI-AD" || Session["Role_Code"].ToString() == "COI-DD" || Session["Role_Code"].ToString() == "COI-SUPDT" || Session["Role_Code"].ToString() == "COI-CLERK")
            {
                Response.Redirect("HomeCoiDashboard.aspx");
            }
            else if (Session["uid"].ToString().Trim() == "1622")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Session["userlevel"].ToString().Trim() == "35")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Session["uid"].ToString().Trim() == "77141" || Session["user_id"].ToString().Trim().ToLower() == "commissioner" || Session["user_id"].ToString().Trim().ToLower() == "Commissioner" || Session["user_id"].ToString().Trim().ToLower() == "CommissionerTest")
            {
                //Response.Redirect("HomeCommDashboardNew.aspx");
                Response.Redirect("COIDashboard.aspx");
            }
            else if (Session["uid"].ToString().Trim() == "324136")
            {
                Response.Redirect("frmincentiveReportAudit.aspx");
            }
            else
            {
                Response.Redirect("ReportsDashboardNew.aspx");
            }
        }

    }


    protected void lbtnIndusries_Click(object sender, EventArgs e)
    {
        string UserID = Session["user_id"].ToString();
        string Password = Session["password"].ToString();
        string Flag = Session["PwdEncryflag"].ToString();


        Response.Redirect("http://industries.telangana.gov.in/newLogin.aspx?UserId=" + UserID + "&UserCode=" + Password + "&Flg=" + Flag);
    }

    General Gen = new General(); //changed nikhil - kcsb
    protected void lbl_ecaf_Click(object sender, EventArgs e)
    {
        Session["ECAF"] = "Y";
        DataSet dscheck = new DataSet();
        dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
        Response.Redirect("frmFireDetails.aspx?intApplicationId=" + dscheck.Tables[4].Rows[0]["intCFEEnterpid"].ToString().Trim() + "&next=" + "N");
        //
    }
    //public static string getclientIP()
    //{
    //    string result = string.Empty;
    //    string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
    //    if (!string.IsNullOrEmpty(ip))
    //    {
    //        string[] ipRange = ip.Split(',');
    //        int le = ipRange.Length - 1;
    //        result = ipRange[0];
    //    }
    //    else
    //    {
    //        result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    //    }

    //    return result;
    //}

}
