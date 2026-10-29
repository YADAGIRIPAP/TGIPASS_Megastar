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
            FillDetails();
        }

        
    }

    void FillDetails()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetEnterpreneourDashboardDetailsRenewals(Session["uid"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            //labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
            //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            //labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
            Label4.Text =  ds.Tables[0].Rows[0]["Total Renewals"].ToString();
          //  Label5.Text = ds.Tables[0].Rows[0]["In Complete (Draft)"].ToString();
            
                Label6.Text = ds.Tables[0].Rows[0]["payment Request"].ToString();
            //}
            
          //  Label9.Text =  ds.Tables[0].Rows[0]["Approvals - Payment Done"].ToString();
                Label12.Text =  ds.Tables[0].Rows[0]["Renewals"].ToString();

                Label15.Text =  ds.Tables[0].Rows[0]["Rejected"].ToString();
            
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
    
   
}
