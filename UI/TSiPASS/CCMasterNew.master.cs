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

public partial class CCMasterNew : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TSTDashboard.Visible = false;
        //IPDashboard.Visible = false;

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
            if (Session["userlevel"].ToString() == "10")
            {

                //   Li2.Visible = true;

            }

            else
            {

                //   Li2.Visible = false;
            }



            if (Session["userlevel"].ToString() == "10")
            {
                Li3.Visible = true;
                Masters.Visible = false;
                TST.Visible = false;
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;

            }
            else
            {
                Li3.Visible = false;
                Masters.Visible = true;
                TST.Visible = true;
                BDC.Visible = true;

            }
            if (Session["userlevel"].ToString() == "25")
            {
                liInspection.Visible = true;
                TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible =
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = liMinister.Visible =
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;
                LiCFOReports.Visible = false;
            }

            if (Session["userlevel"].ToString() == "12")
            {

                liInspection.Visible = TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible = Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = liMinister.Visible = LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;

                LiCFOReports.Visible = false;
            }


            if (Session["userlevel"].ToString() == "13")
            {
                //Li3.Visible = true;
                TSTDashboard.Visible = true;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                liRawMaterial.Visible = true;
                liIncentive.Visible = true;
                Li8Grievance.Visible = false;
                Li8Grievance.Visible = true;

            }

            else
            {
                TSTDashboard.Visible = false;
                //Li3.Visible = false;

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
                LiCFEReports.Visible = true;
                LiCFOReports.Visible = true;
                Li2.Visible = false;
                Lidist.Visible = true;
                Listate.Visible = true;
                Incentive.Visible = true;
            }
            else
            {
                Li5.Visible = false;

                Li6.Visible = false;
            }

            if (Session["uid"].ToString() == "1213")
            {
                liRawMaterial.Visible = true;
                Li4.Visible = true;
                Li2.Visible = false;
                LiincentiveReport.Visible = true;

                LiBankLoan.Visible = true;
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
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;

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
                LiCFEReports.Visible = true;
                LiCFOReports.Visible = true;
                LEODB.Visible = true;
                liapplTrack.Visible = true;
                LiAdminNew.Visible = true;
            }
            else
            {
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                LEODB.Visible = false;
            }

            if (Session["uid"].ToString() == "1003")
            {
                liapplTrack.Visible = true;
            }

            if (Session["uid"].ToString() == "1726")
            {
                TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible = false;
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = LiCFEReports.Visible = false;
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;

                LiCFOReports.Visible = false;
                liMinister.Visible = true;
            }

            if (Session["uid"].ToString() == "1238")
            {
                paymentdet.Visible = liApproval.Visible = liPayment.Visible = lidicpcb.Visible = true;

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
                LiCFEReports.Visible = true;
                LiCFOReports.Visible = true;
                Li2.Visible = true;
            }

            if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 31 && Convert.ToInt32(Session["User_Code"].ToString()) <= 40))
            {
                MSMEReport.Visible = true;
                VATManExport.Visible = true;
            }
            if (Session["userlevel"].ToString() == "13")
            {
                MSMEReport.Visible = true;
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
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                MSMEReport.Visible = true;
                LiBankLoan.Visible = true;




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
                BDC.Visible = false;
                LiCFEReports.Visible = false;
                LiCFOReports.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;
                MSMEReport.Visible = false;
                LiBankLoan.Visible = false;
                VATExportslat.Visible = true;



            }

            if (Session["DistrictID"].ToString() == "")
            {

            }
            else
            {
                LiCFEReports.Visible = true;
                LiCFOReports.Visible = true;
                LiincentiveReport.Visible = true;
            }


            if (Session["uid"].ToString() == "1213")
            {
                MSMEReport.Visible = true;
                //  Bankloans.Visible = true;
            }
            if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141))
            {
                Li8ipopmdash.Visible = true;
            }

            if (Session["userlevel"].ToString() == "10" && (Convert.ToInt32(Session["User_Code"].ToString()) >= 31 && Convert.ToInt32(Session["User_Code"].ToString()) <= 40))
            {
                LiGMDashBoard.Visible = true;
            }
            if (Session["userlevel"].ToString() == "1")
            {
                LiCommissionerReport.Visible = true;
                liGenCer.Visible = true;
                liAppeal.Visible = true;
            }

            //switch (Session["uid"].ToString())
            //{
            //    case "1134":
            //    case "1135":
            //    case "1136":
            //    case "1137":
            //    case "1138":
            //    case "1139":
            //    case "1140":
            //    case "1141":
            //    case "1142":
            //    case "1143":
            //    case "1301":
            //    case "1213":
            //        liRawMaterial.Visible = true;
            //        break;
            //    default:
            //        liRawMaterial.Visible = false;
            //        break;

            //}
        }

    }
}
