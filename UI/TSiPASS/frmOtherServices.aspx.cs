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
            lst3.HRef ="https://labour.telangana.gov.in/regForm1.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim();
            lst1.HRef = "https://labour.telangana.gov.in/contractlabourregistration.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim();
            lst2.HRef = "https://labour.telangana.gov.in/applicationForLicence.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim();
            //" http://tsfactories.cgg.gov.in/annualfee.do?iPASS=T&iPASSUSER=XYZ&iPASSUSERMOBILE=9999999999"
        }

        
    }

    protected void Shops_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://labour.telangana.gov.in/regForm1.do?iPASS=T&iPASSUSER=" + Session["uid"].ToString().Trim());
    }
   
}
