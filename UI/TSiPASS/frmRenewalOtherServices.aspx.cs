using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Dashboard : System.Web.UI.Page
{
    //designed by siva as on 29-1-2016 
    //Purpose : Report for Year wise dashboard
    //Tables used : All
    //Stored procedures Used :YearwiseDashboardforAdmin
    
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
                
        if (Session.Count <= 0)
        {
           Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            //FillDetails();
            lst3.HRef = "http://tsfactories.cgg.gov.in/annualfee.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim() + "&iPASSUSERMOBILE=" + Session["MobileNumber"].ToString().Trim();
            lst1.HRef = "http://tsboilers.cgg.gov.in/renewalofboilercertificateIpass.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim() ;
            lst4.HRef = "https://labour.telangana.gov.in/renewalForm3.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim();

            lst5.HRef = "http://tspcbmanifest.cgg.gov.in/autorenewals" ;
        }

        
    }

    protected void Shops_Click(object sender, EventArgs e)
    {
        //Response.Redirect("https://labour.telangana.gov.in/regForm1.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim());
    }
   
}
