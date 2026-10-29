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
            Response.Redirect("~/Index.aspx");
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
        ds = Gen.GetDepartmentDashboardDetailsHMDAPart1(Session["User_Code"].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            //labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            //labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            //labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
            //labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            //labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["No of Application Received"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
            Label18.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
            Label21.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
            Label22.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
            Label35.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Beyond 7 Days"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
            Label1.Text = ds.Tables[0].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["Approval Under Process-Total"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["No of Approvals Awaiting Payment"].ToString();
            Label7.Text = ds.Tables[0].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            Label9.Text = ds.Tables[0].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["Approval Issued-Total"].ToString();
            Label17.Text = ds.Tables[0].Rows[0]["No of Applications Rejected"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["No of Applications appeal against Rejection"].ToString();
            lblrejectedatprescrutiny.Text = ds.Tables[0].Rows[0]["No of Applications Rejected PSC"].ToString();
            Label37.Text = ds.Tables[0].Rows[0]["No of Application Received maud"].ToString();

            Label38maud.Text = ds.Tables[0].Rows[0]["No of Application Received maud WITHIN"].ToString();
            Label39maud.Text = ds.Tables[0].Rows[0]["No of Application Received maud BEYOND"].ToString();
            //   Label2.Text = "0";

            Label14.Text = ds.Tables[1].Rows[0]["No of Application Received"].ToString();
            Label15.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Completed-Within 3 Days"].ToString();
            Label16.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Completed-Beyond 3 Days"].ToString();
            Label19.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Completed-Total"].ToString();
            Label20.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Pending-Within 3 Days"].ToString();
            Label23.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Pending-Beyond 3 Days"].ToString();
            Label36.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Pending-Beyond 7 Days"].ToString();
            Label24.Text = ds.Tables[1].Rows[0]["Pre-Scrutiny-Pending-Total"].ToString();
            Label25.Text = ds.Tables[1].Rows[0]["No of Applications Awaiting for Query Response"].ToString();
            Label27.Text = ds.Tables[1].Rows[0]["Approval Under Process-Within Time Limits"].ToString();
            Label28.Text = ds.Tables[1].Rows[0]["Approval Under Process-Beyond Time Limits"].ToString();
            Label38.Text = ds.Tables[1].Rows[0]["No of Applications Rejected PSC"].ToString();
            // Label27.Text = "0";

            Label29.Text = ds.Tables[1].Rows[0]["Approval Under Process-Total"].ToString();
            Label26.Text = ds.Tables[1].Rows[0]["No of Approvals Awaiting Payment"].ToString();
            Label30.Text = ds.Tables[1].Rows[0]["Approval Issued-Within Time Limits"].ToString();
            Label31.Text = ds.Tables[1].Rows[0]["Approval Issued-Beyond Time Limits"].ToString();
            Label32.Text = ds.Tables[1].Rows[0]["Approval Issued-Total"].ToString();
            Label33.Text = ds.Tables[1].Rows[0]["No of Applications Rejected"].ToString();
            Label34.Text = ds.Tables[1].Rows[0]["No of Applications appeal against Rejection"].ToString();
            //  Label28.Text = "0";
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
