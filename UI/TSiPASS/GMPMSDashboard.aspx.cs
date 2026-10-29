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
          // Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            FillDetails();
        }

        
    }

    void FillDetails()
    {

        Label1.Text = "0";
        Label2.Text = "0";
        Label3.Text = "0";
        Label4.Text = "0";
        Label5.Text = "0";
        Label6.Text = "0";
        Label7.Text = "0";
        Label8.Text = "0";
        Label9.Text = "0";
        Label10.Text = "0";
        Label11.Text = "0";
        Label12.Text = "0";
        Label13.Text = "0";
        Label14.Text = "0";
        Label15.Text = "0";
        Label16.Text = "0";
        Label17.Text = "0";
        Label18.Text = "0";
        Label19.Text = "0";
        Label20.Text = "0";
        Label21.Text = "0";
        Label22.Text = "0";
        Label23.Text = "0";
        Label24.Text = "0";
      
        
    }

      


       
  
    
   
}
