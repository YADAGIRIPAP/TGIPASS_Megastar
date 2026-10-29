using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmIPOIncentiveDashboardNew : System.Web.UI.Page
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

        Session["IncUserIDUrl"] = "";
        DataSet ds = new DataSet();//GetIPOIncentiveDashboardNew
        //    ds = Gen.GetIPOIncentiveDashboardNew(Session["User_Code"].ToString().Trim());//Session["User_Code"].ToString().Trim()
        if (Request.QueryString.Count > 0 && Request.QueryString["UserID"] != null)
        {
            Session["IncUserIDUrl"] = Request.QueryString["UserID"].ToString().Trim();
            ds = Gen.GetIPOIncentiveDashboardNew(Request.QueryString["UserID"].ToString().Trim());
        }
        else
        {
            ds = Gen.GetIPOIncentiveDashboardNew(Session["uid"].ToString().Trim());
        }
      
        if (ds.Tables[0].Rows.Count > 0)
        {
           
            lblAppl.Text = ds.Tables[0].Rows[0]["Assigned by GM"].ToString();


            Label8.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Scheduled within 7 days"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Scheduled beyond 7 days"].ToString();

            lblApproved.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Yet to Scheduled within 3 days"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Yet to Scheduled beyond 3 days"].ToString();

            Label15.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Upload within 48"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Upload Beyond 48"].ToString();

            Label11.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Not Upload Within 48"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Inspection - Inspection Not Upload Beyond 48"].ToString();

            Label18.Text = ds.Tables[0].Rows[0]["GM Recommended"].ToString();
            //if (Session["DistrictID"].ToString() == "24")
            //{
                trRollbackGM.Visible = true;
                lblRollbackedfromGM.Text = ds.Tables[0].Rows[0]["RollbackedfromGM"].ToString();
            //}

           lblAfrerInspectionawaiting.Text = ds.Tables[0].Rows[0]["QueryRaisedIO"].ToString();
           lblAfrerInspection.Text = ds.Tables[0].Rows[0]["QueryRaisedIO_Responce"].ToString();
            
          //  Label3.Text = ds.Tables[0].Rows[0]["Query Raised"].ToString();


        }
    }
    
   

}