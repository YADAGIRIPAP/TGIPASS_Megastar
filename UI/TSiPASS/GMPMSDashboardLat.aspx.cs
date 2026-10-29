using System;
using System.Data;

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
            ddlMonth.SelectedIndex = System.DateTime.Now.Month;
            ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
            ddlMonth.Enabled = false;
            ddlYear.Enabled = false;
            FillDetails();
        }

        
    }

    void FillDetails()
    {
        Session["VMonth"] = ddlMonth.SelectedIndex.ToString().Trim();
        Session["VYear"] = ddlYear.SelectedValue.ToString().Trim();



        Label4.Text = "0";
        Label6.Text = "0";
        Label7.Text = "0";
        Label26.Text = "0";
       // Label27.Text = "0"; commented by cms
        Label5.Text = "0";
        Label28.Text = "0";

        Label1.Text = "0";
        Label3.Text = "0";
        Label8.Text = "0";

        Label2.Text = "0";

        // Label13.Text = "0"; commented by cms
        Label14.Text = "0";
        Label15.Text = "0";
        //DataSet ds = new DataSet();
        //ds = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(),ddlMonth.SelectedIndex.ToString(),ddlYear.SelectedValue.ToLower().Trim(),"1000");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    Label4.Text = ds.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label6.Text = ds.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label7.Text = ds.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}
        //DataSet ds1 = new DataSet();
        //ds1 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1001");
        //if (ds1.Tables[0].Rows.Count > 0)
        //{
        //    Label5.Text = ds1.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label8.Text = ds1.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label9.Text = ds1.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds2 = new DataSet();
        //ds2 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1002");
        //if (ds2.Tables[0].Rows.Count > 0)
        //{
        //    Label13.Text = ds2.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label14.Text = ds2.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label15.Text = ds2.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds3 = new DataSet();
        //ds3 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1003");
        //if (ds3.Tables[0].Rows.Count > 0)
        //{
        //    Label19.Text = ds3.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label20.Text = ds3.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label21.Text = ds3.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds4 = new DataSet();
        //ds4 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1004");
        //if (ds4.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = ds4.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label2.Text = ds4.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label3.Text = ds4.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds5 = new DataSet();
        //ds5 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1005");
        //if (ds5.Tables[0].Rows.Count > 0)
        //{
        //    Label10.Text = ds5.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label11.Text = ds5.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label12.Text = ds5.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds6 = new DataSet();
        //ds6 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1006");
        //if (ds6.Tables[0].Rows.Count > 0)
        //{
        //    Label16.Text = ds6.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label17.Text = ds6.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label18.Text = ds6.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}

        //DataSet ds7 = new DataSet();
        //ds7 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1007");
        //if (ds7.Tables[0].Rows.Count > 0)
        //{
        //    Label22.Text = ds7.Tables[0].Rows[0]["Target"].ToString().Trim();
        //    Label23.Text = ds7.Tables[1].Rows[0]["Completed"].ToString().Trim();
        //    Label24.Text = ds7.Tables[2].Rows[0]["Pending"].ToString().Trim();
        //}
           
       
      
        
    }








    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        ddlMonth.SelectedIndex = ddlMonth.SelectedIndex - 1;
        FillDetails();

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlMonth.SelectedIndex = System.DateTime.Now.Month;
        FillDetails();
    }
}
