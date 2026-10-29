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

public partial class CCMaster : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //TSTDashboard.Visible = false;
        //IPDashboard.Visible = false;

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
                PDC.Visible = false;

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
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = PDC.Visible = liMinister.Visible =
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;
            }


            if (Session["userlevel"].ToString() == "13")
            {
                //Li3.Visible = true;
                TSTDashboard.Visible = true;
                PDC.Visible = false;
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
                PDC.Visible = true;
                Li2.Visible = true;
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
                Li2.Visible = true;
            }
            else
            {
                //liRawMaterial.Visible = false;
                Li4.Visible = false;
            }

            if (Convert.ToInt32(Session["uid"].ToString()) >= 1149 && Convert.ToInt32(Session["uid"].ToString()) <= 1158)
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
                PDC.Visible = false;
                LEODB.Visible = false;
                liIncentive.Visible = false;
                liRawMaterial.Visible = false;
                Li7.Visible = false;
                rawmetrpt.Visible = false;

            }
            if (Session["user_type"].ToString() == "11")
            {

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
            //        PDC.Visible = false;
            //        //lblwecome.Text = "Implementing Partner";
            //    }
            //    else if (Session["user_type"].ToString() == "PDC")
            //    {
            //        PDC.Visible = true;
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
                PDC.Visible = true;
                LEODB.Visible = true;
            }
            else
            {
                PDC.Visible = false;
                LEODB.Visible = false;
            }


            if (Session["uid"].ToString() == "1726")
            {
                TSTDashboard.Visible = Li3.Visible = Lindus.Visible = Li5.Visible = Li6.Visible = Li2.Visible = Li7Dist.Visible = Li4.Visible = false;
                Masters.Visible = TST.Visible = IP.Visible = Li7.Visible = Li8Grievance.Visible = BDC.Visible = PDC.Visible = false;
                LEODB.Visible = liIncentive.Visible = liRawMaterial.Visible = rawmetrpt.Visible = false;

                liMinister.Visible = true;
            }

            if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "1213")
            {
                paymentdet.Visible = true;

            }

            if (Session["uid"].ToString() == "1134" || Session["uid"].ToString() == "1135" || Session["uid"].ToString() == "1136" || Session["uid"].ToString() == "1137" || Session["uid"].ToString() == "1138"
                || Session["uid"].ToString() == "1139" || Session["uid"].ToString() == "1140" || Session["uid"].ToString() == "1141" || Session["uid"].ToString() == "1142" || Session["uid"].ToString() == "1143")
            {

                DICDashboard.Visible = true;
                Li3.Visible = true;



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
