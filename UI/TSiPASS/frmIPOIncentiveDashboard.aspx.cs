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
        //    Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            FillDetails();
        }
        
        
    }

    void FillDetails()
    {
        //Label1.Text = "0";
        //Label2.Text = "0";
        //Label4.Text = "0";
     

        //Label6.Text = "0";
        //Label8.Text = "0";


        //Label11.Text = "0";
        //Label12.Text = "0";
        //Label13.Text = "0";
       
        //Label17.Text = "0";
        //Label9.Text = "0";

        //Label18.Text = "0";
        //Label3.Text = "0";
        //Label21.Text = "0";
        //Label22.Text = "0";
        //Label5.Text = "0";
        //Label7.Text = "0";
        //Label10.Text = "0";

        DataSet ds = new DataSet();
        ds = Gen.GetIPOIncentiveDashboard(Session["User_Code"].ToString().Trim());//Session["User_Code"].ToString().Trim()
        if (ds.Tables[0].Rows.Count > 0)
        {
            //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            //labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
            //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            //labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
            lblAppl.Text = ds.Tables[0].Rows[0]["Assigned by GM"].ToString();

          
            Label8.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Scheduled"].ToString();
            lblApproved.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Yet to Scheduled"].ToString();


            Label15.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report Uploaded 48 Hrs"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report Uploaded Beyond"].ToString();

            Label11.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report not Uploaded 48 Hrs"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Report  not Uploaded Beyond"].ToString();
           
            Label18.Text = ds.Tables[0].Rows[0]["Recommanded to GM"].ToString();
        


           
           
           
        }



      
    }
    
   
}
