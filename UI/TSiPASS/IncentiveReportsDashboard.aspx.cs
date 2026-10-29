using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSIPASS_IncentiveReportsDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            if (Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424" || Session["uid"].ToString() == "77141" || Session["uid"].ToString() == "34668")
            {
                ulSLCSVCRep.Visible = false;
                ulReleasesReport.Visible = false;
                gmcoireport.Visible = true;
                gmcoi1.Visible = true;
                gmcoi2.Visible = true;
                gmcoireport9.Visible = true;
                gmcoireport10.Visible = true;
                gmcoi3.Visible = false;
                gmcoi22.Visible = false;
                gmcoi4.Visible = false;
                gmcoi5.Visible = false;
                gmcoi6.Visible = false;
                gmcoi7.Visible = false;
                gmcoi8.Visible = false;
                Li1.Visible = false;
                A2.Visible = false;
                Ulgmdelayreport.Visible = true;
                lblr5.Text = "R2: Incentives Reports New";
            }
            else if (Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "32951"|| Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "359030" || Session["uid"].ToString() == "359104" || Session["uid"].ToString() == "365452")
            {
                Ul1.Visible = true;
            }
            else
            {
                gmcoireport.Visible = false;
            }
            if (Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1424")
            {
                AUTOREJECTED.Visible = false;
            }
            if(Session["uid"].ToString() == "3377"|| Session["uid"].ToString() == "77233"|| Session["uid"].ToString() == "251974" || Session["uid"].ToString() == "34668"
                || Session["uid"].ToString() == "253625"|| Session["uid"].ToString() == "57783"|| Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "359030"
                 || Session["uid"].ToString() == "359104" || Session["uid"].ToString() == "21345" || Session["uid"].ToString() == "365452" || Session["uid"].ToString() == "364490"
                 )
            {
                Li2.Visible = true;
                lblr5.Visible = true;
                uir51.Visible = true;
                uir52.Visible = true;
                uir53.Visible = true;
                uir54.Visible = true;
                uir55.Visible = true;
                uir56.Visible = true;
                Ul2.Visible = true;
                Ul3.Visible = true;
                Ul4.Visible = true;
                Ul5.Visible = true;
            }
            if(Session["uid"].ToString() == "32950")
            {
                Li2.Visible = true;
                lblr5.Visible = true;

                uir53.Visible = true;
                uir54.Visible = true;
                uir55.Visible = true;
            }
            if (Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "365452")
            {

                LIHEADOFFICE.Visible = true;
               // LIPLOTREPORT.Visible = true;
            }
            else
            {
                LIHEADOFFICE.Visible = false;
                LIPLOTREPORT.Visible = false;
            }

            if ( Session["uid"].ToString() == "359030" || Session["uid"].ToString() == "359104" || Session["uid"].ToString() == "1238"|| Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "365452")
            {

                LIHEADOFFICE.Visible = true;
               // LIPLOTREPORT.Visible = true;
            }
            else
            {
                LIHEADOFFICE.Visible = false;
               // LIPLOTREPORT.Visible = false;
            }
        }
    }
}