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





            string k = System.DateTime.Now.Year.ToString();
           // ddlMonth.SelectedIndex =System.DateTime.Now.Month-1;
           // ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
            if ((System.DateTime.Now.Month) == 1)
            {
                ddlMonth.SelectedValue = "12";
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.SelectedValue = ddlYear.Items.FindByValue((System.DateTime.Now.Year - 1).ToString()).Value;
            }
            else
            {
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                ddlYear.Enabled = false;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
                ddlMonth.Enabled = false;

            }
            ddlMonth.Enabled = false;
            ddlYear.Enabled = false;


            if
(Session["User_Code"].ToString().Trim() == "74" ||
Session["User_Code"].ToString() == "112" ||
Session["User_Code"].ToString() == "113" ||
Session["User_Code"].ToString() == "114" ||
Session["User_Code"].ToString() == "115" ||
Session["User_Code"].ToString() == "116" ||
Session["User_Code"].ToString() == "117" ||
Session["User_Code"].ToString() == "118" ||
Session["User_Code"].ToString() == "119" ||
Session["User_Code"].ToString() == "120" ||
Session["User_Code"].ToString() == "122" ||
Session["User_Code"].ToString() == "123" ||
Session["User_Code"].ToString() == "125" ||
Session["User_Code"].ToString() == "126" ||
Session["User_Code"].ToString() == "131" ||
Session["User_Code"].ToString() == "132" ||
Session["User_Code"].ToString() == "134" ||
Session["User_Code"].ToString() == "136" ||
Session["User_Code"].ToString() == "137" ||
Session["User_Code"].ToString() == "140" ||
Session["User_Code"].ToString() == "141" ||
Session["User_Code"].ToString() == "147" ||
Session["User_Code"].ToString() == "148" ||
Session["User_Code"].ToString() == "149" ||

Session["User_Code"].ToString() == "113" ||
Session["User_Code"].ToString() == "121" ||
Session["User_Code"].ToString() == "124" ||
Session["User_Code"].ToString() == "127" ||
Session["User_Code"].ToString() == "128" ||
Session["User_Code"].ToString() == "129" ||
Session["User_Code"].ToString() == "130" ||
Session["User_Code"].ToString() == "133" ||
Session["User_Code"].ToString() == "135" ||
Session["User_Code"].ToString() == "138" ||
Session["User_Code"].ToString() == "139"

)
            {
                unitAD.Visible = true;
                unitDet.Visible = true;

                UnitTarget.Visible = true;
                UnitPending.Visible = true;
                UnitCompleted.Visible = true;
                Label31.Visible = true;
            }


            else
            {

                UnitTarget.Visible = false;
                UnitPending.Visible = false;
                UnitCompleted.Visible = false;
                Label31.Visible = false;
            }


            
        //    FillDetails();







            if (Session["DistrictID"].ToString() != "" )
            {
                GMTsipass.Visible = true;
                GMPer.Visible = true;
                IPOPer.Visible = false;
                IPOTsipass.Visible = false;

            }
            else if ((Convert.ToInt32(Session["User_Code"].ToString()) >= 74 && Convert.ToInt32(Session["User_Code"].ToString()) <= 141) || Session["User_Code"].ToString() == "143" || Session["User_Code"].ToString() == "144" || Session["User_Code"].ToString() == "145" || Session["User_Code"].ToString() == "146" || Session["User_Code"].ToString() == "147" || Session["User_Code"].ToString() == "148" || Session["User_Code"].ToString() == "149" || Session["User_Code"].ToString() == "150")
            {
                GMTsipass.Visible = false;
                GMPer.Visible = false;
                IPOPer.Visible = true;
                IPOTsipass.Visible = true;


            }





        }

        
    }

    void FillDetails()
    {
        Session["VMonth"] = ddlMonth.SelectedIndex.ToString().Trim();
        Session["VYear"] = ddlYear.SelectedValue.ToString().Trim();
        DataSet ds = new DataSet();
        ds = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(),ddlMonth.SelectedIndex.ToString(),ddlYear.SelectedValue.ToLower().Trim(),"1000");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label4.Text = ds.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label6.Text = ds.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label7.Text = ds.Tables[2].Rows[0]["Pending"].ToString().Trim();

        }
        DataSet ds1 = new DataSet();
        ds1 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1001");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Label5.Text = ds1.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label8.Text = ds1.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label9.Text = ds1.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }

        DataSet ds2 = new DataSet();
        ds2 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1002");
        if (ds2.Tables[0].Rows.Count > 0)
        {
            Label13.Text = ds2.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label14.Text = ds2.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label15.Text = ds2.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }
        // Different

        DataSet ds3 = new DataSet();
        ds3 = Gen.GetIPOPMAppIPODashboardTSiPASS(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1003");
        if (ds3.Tables[0].Rows.Count > 0)
        {
            Label19.Text = ds3.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label20.Text = ds3.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label21.Text = ds3.Tables[2].Rows[0]["Pending"].ToString().Trim();
            Label27.Text = ds3.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }

        DataSet ds4 = new DataSet();
        ds4 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1004");
        if (ds4.Tables[0].Rows.Count > 0)
        {
            Label1.Text = ds4.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label2.Text = ds4.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label3.Text = ds4.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }
        // Different
        DataSet ds5 = new DataSet();
        ds5 = Gen.GetIPOPMAppIPODashboardSubSidy(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1005");
        if (ds5.Tables[0].Rows.Count > 0)
        {
            Label10.Text = ds5.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label11.Text = ds5.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label12.Text = ds5.Tables[2].Rows[0]["Pending"].ToString().Trim();
            Label26.Text = ds5.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }

        DataSet ds6 = new DataSet();
        ds6 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1006");
        if (ds6.Tables[0].Rows.Count > 0)
        {
            Label16.Text = ds6.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label17.Text = ds6.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label18.Text = ds6.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }

        DataSet ds7 = new DataSet();
        ds7 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1007");
        if (ds7.Tables[0].Rows.Count > 0)
        {
            Label22.Text = ds7.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label23.Text = ds7.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label24.Text = ds7.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }


        DataSet ds8 = new DataSet();
        ds8 = Gen.GetIPOPMAppIPODashboard(Session["uid"].ToString(), ddlMonth.SelectedIndex.ToString(), ddlYear.SelectedValue.ToLower().Trim(), "1008");
        if (ds8.Tables[0].Rows.Count > 0)
        {
            Label28.Text = ds8.Tables[0].Rows[0]["Target"].ToString().Trim();
            Label29.Text = ds8.Tables[1].Rows[0]["Completed"].ToString().Trim();
            Label30.Text = ds8.Tables[2].Rows[0]["Pending"].ToString().Trim();
        }
        else
        {

            Label28.Text = "0";
            Label29.Text = "0";
            Label30.Text = "0";
        }
           
       
      
        
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIPOMonthlyReportUpdate.aspx");
    }
}
