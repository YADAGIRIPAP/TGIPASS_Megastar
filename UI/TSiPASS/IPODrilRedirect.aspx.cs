using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IPODrilRedirect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["VMonth"] = Request.QueryString[2].ToString();
        Session["VYear"] = Request.QueryString[1].ToString();
        Session["uidIPO"] = Request.QueryString[0].ToString();
        if (Request.QueryString[3].ToString()=="1000")
        {

            Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1001")
        {

            Response.Redirect("frmBankVistReport213.aspx?id="+Session["uidIPO"].ToString().Trim()+"&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());


            //frmBankVistReport213.aspx?id=<%= Session["uidIPO"]%>&Year=<%=Session["VMonth"]%>&Month=<%=Session["VYear"]%>
        }
        else if (Request.QueryString[3].ToString() == "1002")
        {

           // Response.Redirect("VehicleInspectiondrilDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
            Response.Redirect("VehicleInspectiondrilDownLat.aspx?Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1003")
        {
            if (Request.QueryString[4].ToString() == "Completed")
            {
                Response.Redirect("TSiPASSReport213.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
            }
            else if (Request.QueryString[4].ToString() == "Pending")
            {
                Response.Redirect("TSiPASSReport213Ppenidng.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
            }
          //  Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1004")
        {

//            Response.Redirect("frmPMEGP213.aspx?Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());

            Response.Redirect("frmPMEGP213.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());

        }
        else if (Request.QueryString[3].ToString() == "1005")
        {
            if (Request.QueryString[4].ToString() == "Completed")
            {
                Response.Redirect("frmadvanceSbsidy213.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
            }
            else if (Request.QueryString[4].ToString() == "Pending")
            {
                Response.Redirect("frmadvanceSbsidy213Penidng.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
            }

            //Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1006")
        {

//            Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
            Response.Redirect("frmClosedUnits213.aspx?id=" + Session["uidIPO"].ToString().Trim() + "&Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1007")
        {

            Response.Redirect("IndustrialCataloge1DrillDownLat.aspx?Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1008")
        {

          //  Response.Redirect("IndustrialCataloge1DrillDownLat.aspx?Year=" + Session["VMonth"].ToString().Trim() + "&Month=" + Session["VYear"].ToString().Trim());

 //           Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
        }
        else if (Request.QueryString[3].ToString() == "1009")
        {

            //Response.Redirect("frmProformaeReport1DrillDownLat.aspx?Year=" + Session["VYear"].ToString().Trim() + "&Month=" + Session["VMonth"].ToString().Trim());
        }

    }
}
