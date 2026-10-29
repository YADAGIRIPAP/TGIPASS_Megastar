using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;


public partial class UI_TSiPASS_RP_MSMETSIPASSMAPPEDUNITSMonthlyReports : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    decimal Nounits, msmemapped, msmenotmapped, tsunits, tsmapped, tsnotmapped,
      TSIPASSMAPPED1, TSIPASSMAPPED2, TSIPASSMAPPED3, TSIPASSMAPPED4, TSIPASSMAPPED5, TSIPASSMAPPED6, TSIPASSMAPPED7,
      TSIPASSMAPPED8, TSIPASSMAPPED9, TSIPASSMAPPED10, TSIPASSMAPPED11, TSIPASSMAPPED12, TSIPASSMAPPED13, TSIPASSMAPPED14,
      TSIPASSMAPPED15, TSIPASSMAPPED16, TSIPASSMAPPED17, TSIPASSMAPPED18, TSIPASSMAPPED19, TSIPASSMAPPED20, TSIPASSMAPPED21,
      TSIPASSMAPPED22, TSIPASSMAPPED23, TSIPASSMAPPED24, TSIPASSMAPPED25, TSIPASSMAPPED26, TSIPASSMAPPED27, TSIPASSMAPPED28,
      TSIPASSMAPPED29, TSIPASSMAPPED30, TSIPASSMAPPED31, TSIPASSMAPPEDMonthlyTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            Label1.Text = "Report as on date " + DateTime.Now;
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }
            BindMonth();
           // fillgrid();
        }
    }


    public DataSet GetYears_DB()
    {
        DataTable dt_grid = new DataTable();
        dt_grid.Columns.Add("MonthYear", typeof(string));
        dt_grid.Columns.Add("MonthName_Year", typeof(string));

        int year = DateTime.Now.Year - 2020;
        for (int m=0;m<= year;m++)
        {
            var firstDayOfMonth = new DateTime(2020+m, 1, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var dat = new DateTime(firstDayOfMonth.Year, firstDayOfMonth.Month, lastDayOfMonth.Day);

            for (int k = 0; k < 12; k++)
            {
                DataRow drs = dt_grid.NewRow();

                dat.AddMonths(k).ToString("d");
                string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;

                //string MonthYear = 0+k + "/" + d1.Year;
                //string MonthName = 0 + k + "-" + d1.Year;
                drs["MonthYear"] = MonthYear;
                drs["MonthName_Year"] = MonthName;
                dt_grid.Rows.Add(drs);
            }

        }



        //var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        //var dat = new DateTime(DateTime.Now.Year, DateTime.Now.Month, lastDayOfMonth.Day);

       

        DataSet dsmain = new DataSet();
        dsmain.Tables.Add(dt_grid);
        return dsmain;
    }
    public void BindMonth()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddl_Month.Items.Clear();
            dsd = GetYears_DB();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddl_Month.DataSource = dsd.Tables[0];
                ddl_Month.DataValueField = "MonthYear";
                ddl_Month.DataTextField = "MonthName_Year";
                ddl_Month.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--Select--", "%");
                ddl_Month.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--Select--", "%");
                ddl_Month.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        if (ddl_Month.SelectedValue == "" || ddl_Month.SelectedValue == null)
        {
            lblmsg0.Text = "Please Enter Month <br/>";
            valid = 1;
        }      
        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public void fillgrid()
    {
        string use = Convert.ToString(ddl_Month.SelectedValue);
        string[] arg = new string[2];
        arg = use.Split('/');
        string Month = Convert.ToString(arg[0]);
        string Year = Convert.ToString(arg[1]);

        DataSet dsnew = new DataSet();
        dsnew = GetMSMEApplications(ddlProp_intDistrictid.SelectedValue, Month, Year);
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

        //int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        int days = DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
        if (days == 28)
        {
            grdDetails.Columns[36].Visible = false;   
            grdDetails.Columns[37].Visible = false;
            grdDetails.Columns[38].Visible = false;
        }
        else if (days == 29)
        {
            grdDetails.Columns[36].Visible = true;
            grdDetails.Columns[37].Visible = false;
            grdDetails.Columns[38].Visible = false;
        }
        else if (days == 30)
        {
            grdDetails.Columns[36].Visible = true;
            grdDetails.Columns[37].Visible = true;
            grdDetails.Columns[38].Visible = false;
        }
        else
        {
            grdDetails.Columns[36].Visible = true;
            grdDetails.Columns[37].Visible = true;
            grdDetails.Columns[38].Visible = true;
        }
    }
  
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink HyNoofClaimsFiled = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            HyNoofClaimsFiled.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMENOOFUNITS";

            HyperLink HyMSMEMAPPEDWITHTSIPASS = (HyperLink)e.Row.FindControl("HyMSMEMAPPEDWITHTSIPASS");
            HyMSMEMAPPEDWITHTSIPASS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMEMAPPEDWITHTSIPASS";

            HyperLink HyMSMENOTMAPPEDWITHTSIPASS = (HyperLink)e.Row.FindControl("HyMSMENOTMAPPEDWITHTSIPASS");
            HyMSMENOTMAPPEDWITHTSIPASS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMENOTMAPPEDWITHTSIPASS";

            HyperLink HyTSIPASSUNITS = (HyperLink)e.Row.FindControl("HyTSIPASSUNITS");
            HyTSIPASSUNITS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSUNITS";

            HyperLink HyTSIPASSMAPPEDWITHMSME = (HyperLink)e.Row.FindControl("HyTSIPASSMAPPEDWITHMSME");
            HyTSIPASSMAPPEDWITHMSME.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDWITHMSME";

            HyperLink HyTsipassnotmapped = (HyperLink)e.Row.FindControl("HyTsipassnotmapped");
            HyTsipassnotmapped.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSNOTMAPPEDWITHMSME";


            HyperLink hypTSIPASSMAPPED1 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED1");
            hypTSIPASSMAPPED1.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED1";
            HyperLink hypTSIPASSMAPPED2 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED2");
            hypTSIPASSMAPPED2.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED2";
            HyperLink hypTSIPASSMAPPED3 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED3");
            hypTSIPASSMAPPED3.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED3";
            HyperLink hypTSIPASSMAPPED4 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED4");
            hypTSIPASSMAPPED4.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED4";
            HyperLink hypTSIPASSMAPPED5 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED5");
            hypTSIPASSMAPPED5.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED5";

            HyperLink hypTSIPASSMAPPED6 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED6");
            hypTSIPASSMAPPED6.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED6";
            HyperLink hypTSIPASSMAPPED7 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED7");
            hypTSIPASSMAPPED7.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED7";
            HyperLink hypTSIPASSMAPPED8 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED8");
            hypTSIPASSMAPPED8.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED8";
            HyperLink hypTSIPASSMAPPED9 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED9");
            hypTSIPASSMAPPED9.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED9";
            HyperLink hypTSIPASSMAPPED10 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED10");
            hypTSIPASSMAPPED10.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED10";

            HyperLink hypTSIPASSMAPPED11 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED11");
            hypTSIPASSMAPPED11.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED11";
            HyperLink hypTSIPASSMAPPED12 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED12");
            hypTSIPASSMAPPED12.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED12";
            HyperLink hypTSIPASSMAPPED13 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED13");
            hypTSIPASSMAPPED13.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED13";
            HyperLink hypTSIPASSMAPPED14 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED14");
            hypTSIPASSMAPPED14.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED14";
            HyperLink hypTSIPASSMAPPED15 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED15");
            hypTSIPASSMAPPED15.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED15";

            HyperLink hypTSIPASSMAPPED16 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED16");
            hypTSIPASSMAPPED16.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED16";
            HyperLink hypTSIPASSMAPPED17 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED17");
            hypTSIPASSMAPPED17.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED17";
            HyperLink hypTSIPASSMAPPED18 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED18");
            hypTSIPASSMAPPED18.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED18";
            HyperLink hypTSIPASSMAPPED19 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED19");
            hypTSIPASSMAPPED19.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED19";
            HyperLink hypTSIPASSMAPPED20 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED20");
            hypTSIPASSMAPPED20.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED20";

            HyperLink hypTSIPASSMAPPED21 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED21");
            hypTSIPASSMAPPED21.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED21";
            HyperLink hypTSIPASSMAPPED22 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED22");
            hypTSIPASSMAPPED22.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED22";
            HyperLink hypTSIPASSMAPPED23 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED23");
            hypTSIPASSMAPPED23.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED23";
            HyperLink hypTSIPASSMAPPED24 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED24");
            hypTSIPASSMAPPED24.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED24";
            HyperLink hypTSIPASSMAPPED25 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED25");
            hypTSIPASSMAPPED25.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED25";

            HyperLink hypTSIPASSMAPPED26 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED26");
            hypTSIPASSMAPPED26.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED26";
            HyperLink hypTSIPASSMAPPED27 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED27");
            hypTSIPASSMAPPED27.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED27";
            HyperLink hypTSIPASSMAPPED28 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED28");
            hypTSIPASSMAPPED28.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED28";

            HyperLink hypTSIPASSMAPPED29 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED29");
            hypTSIPASSMAPPED29.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED29";
            HyperLink hypTSIPASSMAPPED30 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED30");
            hypTSIPASSMAPPED30.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED30";
            HyperLink hypTSIPASSMAPPED31 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED31");
            hypTSIPASSMAPPED31.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED31";

            HyperLink hypTSIPASSMAPPEDMonthlyTotal = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDMonthlyTotal");
            hypTSIPASSMAPPEDMonthlyTotal.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_Month.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDMonthlyTotal";


            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITS"));
            Nounits = Nounits1 + Nounits;

            decimal msmemapped1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MSMEMAPPEDWITHTSIPASS"));
            msmemapped = msmemapped1 + msmemapped;

            decimal msmenotmapped1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MSMENOTMAPPEDWITHTSIPASS"));
            msmenotmapped = msmenotmapped1 + msmenotmapped;

            decimal tsunits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSUNITS"));
            tsunits = tsunits1 + tsunits;

            decimal tsmapped1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDWITHMSME"));
            tsmapped = tsmapped1 + tsmapped;

            decimal tsnotmapped1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSNOTMAPPEDWITHMSME"));
            tsnotmapped = tsnotmapped1 + tsnotmapped;

            decimal TSIPASSMAPPEDrow1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED1"));
            TSIPASSMAPPED1 = TSIPASSMAPPEDrow1 + TSIPASSMAPPED1;

            decimal TSIPASSMAPPEDrow2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED2"));
            TSIPASSMAPPED2 = TSIPASSMAPPEDrow2 + TSIPASSMAPPED2;

            decimal TSIPASSMAPPEDrow3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED3"));
            TSIPASSMAPPED3 = TSIPASSMAPPEDrow3 + TSIPASSMAPPED3;

            decimal TSIPASSMAPPEDrow4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED4"));
            TSIPASSMAPPED4 = TSIPASSMAPPEDrow4 + TSIPASSMAPPED4;

            decimal TSIPASSMAPPEDrow5 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED5"));
            TSIPASSMAPPED5 = TSIPASSMAPPEDrow5 + TSIPASSMAPPED5;

            decimal TSIPASSMAPPEDrow6 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED6"));
            TSIPASSMAPPED6 = TSIPASSMAPPEDrow6 + TSIPASSMAPPED6;

            decimal TSIPASSMAPPEDrow7 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED7"));
            TSIPASSMAPPED7 = TSIPASSMAPPEDrow7 + TSIPASSMAPPED7;

            decimal TSIPASSMAPPEDrow8 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED8"));
            TSIPASSMAPPED8 = TSIPASSMAPPEDrow8 + TSIPASSMAPPED8;

            decimal TSIPASSMAPPEDrow9 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED9"));
            TSIPASSMAPPED9 = TSIPASSMAPPEDrow9 + TSIPASSMAPPED9;

            decimal TSIPASSMAPPEDrow10 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED10"));
            TSIPASSMAPPED10 = TSIPASSMAPPEDrow10 + TSIPASSMAPPED10;

            decimal TSIPASSMAPPEDrow11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED11"));
            TSIPASSMAPPED11 = TSIPASSMAPPEDrow11 + TSIPASSMAPPED11;

            decimal TSIPASSMAPPEDrow12 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED12"));
            TSIPASSMAPPED12 = TSIPASSMAPPEDrow12 + TSIPASSMAPPED12;

            decimal TSIPASSMAPPEDrow13 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED13"));
            TSIPASSMAPPED13 = TSIPASSMAPPEDrow13 + TSIPASSMAPPED13;

            decimal TSIPASSMAPPEDrow14 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED14"));
            TSIPASSMAPPED14 = TSIPASSMAPPEDrow14 + TSIPASSMAPPED14;

            decimal TSIPASSMAPPEDrow15 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED15"));
            TSIPASSMAPPED15 = TSIPASSMAPPEDrow15 + TSIPASSMAPPED15;

            decimal TSIPASSMAPPEDrow16 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED16"));
            TSIPASSMAPPED16 = TSIPASSMAPPEDrow16 + TSIPASSMAPPED16;

            decimal TSIPASSMAPPEDrow17 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED17"));
            TSIPASSMAPPED17 = TSIPASSMAPPEDrow17 + TSIPASSMAPPED17;

            decimal TSIPASSMAPPEDrow18 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED18"));
            TSIPASSMAPPED18 = TSIPASSMAPPEDrow18 + TSIPASSMAPPED18;

            decimal TSIPASSMAPPEDrow19 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED19"));
            TSIPASSMAPPED19 = TSIPASSMAPPEDrow19 + TSIPASSMAPPED19;

            decimal TSIPASSMAPPEDrow20 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED20"));
            TSIPASSMAPPED20 = TSIPASSMAPPEDrow20 + TSIPASSMAPPED20;

            decimal TSIPASSMAPPEDrow21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED21"));
            TSIPASSMAPPED21 = TSIPASSMAPPEDrow21 + TSIPASSMAPPED21;

            decimal TSIPASSMAPPEDrow22 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED22"));
            TSIPASSMAPPED22 = TSIPASSMAPPEDrow22 + TSIPASSMAPPED22;

            decimal TSIPASSMAPPEDrow23 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED23"));
            TSIPASSMAPPED23 = TSIPASSMAPPEDrow23 + TSIPASSMAPPED23;

            decimal TSIPASSMAPPEDrow24 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED24"));
            TSIPASSMAPPED24 = TSIPASSMAPPEDrow24 + TSIPASSMAPPED24;

            decimal TSIPASSMAPPEDrow25 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED25"));
            TSIPASSMAPPED25 = TSIPASSMAPPEDrow25 + TSIPASSMAPPED25;

            decimal TSIPASSMAPPEDrow26 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED26"));
            TSIPASSMAPPED26 = TSIPASSMAPPEDrow26 + TSIPASSMAPPED26;

            decimal TSIPASSMAPPEDrow27 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED27"));
            TSIPASSMAPPED27 = TSIPASSMAPPEDrow27 + TSIPASSMAPPED27;

            decimal TSIPASSMAPPEDrow28 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED28"));
            TSIPASSMAPPED28 = TSIPASSMAPPEDrow28 + TSIPASSMAPPED28;

            decimal TSIPASSMAPPEDrow29 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED29"));
            TSIPASSMAPPED29 = TSIPASSMAPPEDrow29 + TSIPASSMAPPED29;

            decimal TSIPASSMAPPEDrow30 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED30"));
            TSIPASSMAPPED30 = TSIPASSMAPPEDrow30 + TSIPASSMAPPED30;

            decimal TSIPASSMAPPEDrow31 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED31"));
            TSIPASSMAPPED31 = TSIPASSMAPPEDrow31 + TSIPASSMAPPED31;

            decimal TSIPASSMAPPEDrowMonthlyTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED31"));
            TSIPASSMAPPEDMonthlyTotal = TSIPASSMAPPEDrowMonthlyTotal + TSIPASSMAPPEDMonthlyTotal;


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            Label nounitstotal = new Label();
            nounitstotal.Text = Nounits.ToString();
            e.Row.Cells[2].Text = Nounits.ToString();
            e.Row.Cells[2].Controls.Add(nounitstotal);


            Label lbmsmemapped = new Label();
            lbmsmemapped.Text = msmemapped.ToString();
            e.Row.Cells[3].Text = msmemapped.ToString();
            e.Row.Cells[3].Controls.Add(lbmsmemapped);

            Label lbmsmenotmapped = new Label();
            lbmsmenotmapped.Text = msmenotmapped.ToString();
            e.Row.Cells[4].Text = msmenotmapped.ToString();
            e.Row.Cells[4].Controls.Add(lbmsmenotmapped);

            Label lbtsunits = new Label();
            lbtsunits.Text = tsunits.ToString();
            e.Row.Cells[5].Text = tsunits.ToString();
            e.Row.Cells[5].Controls.Add(lbtsunits);


            Label lbtsmapped = new Label();
            lbtsmapped.Text = tsmapped.ToString();
            e.Row.Cells[6].Text = tsmapped.ToString();
            e.Row.Cells[6].Controls.Add(lbtsmapped);

            Label lbtsnotmapped = new Label();
            lbtsnotmapped.Text = tsnotmapped.ToString();
            e.Row.Cells[7].Text = tsnotmapped.ToString();
            e.Row.Cells[7].Controls.Add(lbtsnotmapped);

            Label lblTSIPASSMAPPED1 = new Label();
            lblTSIPASSMAPPED1.Text = TSIPASSMAPPED1.ToString();
            e.Row.Cells[8].Text = TSIPASSMAPPED1.ToString();
            e.Row.Cells[8].Controls.Add(lblTSIPASSMAPPED1);

            Label lblTSIPASSMAPPED2 = new Label();
            lblTSIPASSMAPPED2.Text = TSIPASSMAPPED2.ToString();
            e.Row.Cells[9].Text = TSIPASSMAPPED2.ToString();
            e.Row.Cells[9].Controls.Add(lblTSIPASSMAPPED2);

            Label lblTSIPASSMAPPED3 = new Label();
            lblTSIPASSMAPPED3.Text = TSIPASSMAPPED3.ToString();
            e.Row.Cells[10].Text = TSIPASSMAPPED3.ToString();
            e.Row.Cells[10].Controls.Add(lblTSIPASSMAPPED3);

            Label lblTSIPASSMAPPED4 = new Label();
            lblTSIPASSMAPPED4.Text = TSIPASSMAPPED4.ToString();
            e.Row.Cells[11].Text = TSIPASSMAPPED4.ToString();
            e.Row.Cells[11].Controls.Add(lblTSIPASSMAPPED4);

            Label lblTSIPASSMAPPED5 = new Label();
            lblTSIPASSMAPPED5.Text = TSIPASSMAPPED5.ToString();
            e.Row.Cells[12].Text = TSIPASSMAPPED5.ToString();
            e.Row.Cells[12].Controls.Add(lblTSIPASSMAPPED5);

            Label lblTSIPASSMAPPED6 = new Label();
            lblTSIPASSMAPPED6.Text = TSIPASSMAPPED6.ToString();
            e.Row.Cells[13].Text = TSIPASSMAPPED6.ToString();
            e.Row.Cells[13].Controls.Add(lblTSIPASSMAPPED6);

            Label lblTSIPASSMAPPED7 = new Label();
            lblTSIPASSMAPPED7.Text = TSIPASSMAPPED7.ToString();
            e.Row.Cells[14].Text = TSIPASSMAPPED7.ToString();
            e.Row.Cells[14].Controls.Add(lblTSIPASSMAPPED7);

            Label lblTSIPASSMAPPED8 = new Label();
            lblTSIPASSMAPPED8.Text = TSIPASSMAPPED8.ToString();
            e.Row.Cells[15].Text = TSIPASSMAPPED8.ToString();
            e.Row.Cells[15].Controls.Add(lblTSIPASSMAPPED8);

            Label lblTSIPASSMAPPED9 = new Label();
            lblTSIPASSMAPPED9.Text = TSIPASSMAPPED9.ToString();
            e.Row.Cells[16].Text = TSIPASSMAPPED9.ToString();
            e.Row.Cells[16].Controls.Add(lblTSIPASSMAPPED9);

            Label lblTSIPASSMAPPED10 = new Label();
            lblTSIPASSMAPPED10.Text = TSIPASSMAPPED10.ToString();
            e.Row.Cells[17].Text = TSIPASSMAPPED10.ToString();
            e.Row.Cells[17].Controls.Add(lblTSIPASSMAPPED10);

            Label lblTSIPASSMAPPED11 = new Label();
            lblTSIPASSMAPPED11.Text = TSIPASSMAPPED11.ToString();
            e.Row.Cells[18].Text = TSIPASSMAPPED11.ToString();
            e.Row.Cells[18].Controls.Add(lblTSIPASSMAPPED11);

            Label lblTSIPASSMAPPED12 = new Label();
            lblTSIPASSMAPPED12.Text = TSIPASSMAPPED12.ToString();
            e.Row.Cells[19].Text = TSIPASSMAPPED12.ToString();
            e.Row.Cells[19].Controls.Add(lblTSIPASSMAPPED12);

            Label lblTSIPASSMAPPED13 = new Label();
            lblTSIPASSMAPPED13.Text = TSIPASSMAPPED13.ToString();
            e.Row.Cells[20].Text = TSIPASSMAPPED13.ToString();
            e.Row.Cells[20].Controls.Add(lblTSIPASSMAPPED13);

            Label lblTSIPASSMAPPED14 = new Label();
            lblTSIPASSMAPPED14.Text = TSIPASSMAPPED14.ToString();
            e.Row.Cells[21].Text = TSIPASSMAPPED14.ToString();
            e.Row.Cells[21].Controls.Add(lblTSIPASSMAPPED14);

            Label lblTSIPASSMAPPED15 = new Label();
            lblTSIPASSMAPPED15.Text = TSIPASSMAPPED15.ToString();
            e.Row.Cells[22].Text = TSIPASSMAPPED15.ToString();
            e.Row.Cells[22].Controls.Add(lblTSIPASSMAPPED15);

            Label lblTSIPASSMAPPED16 = new Label();
            lblTSIPASSMAPPED16.Text = TSIPASSMAPPED16.ToString();
            e.Row.Cells[23].Text = TSIPASSMAPPED16.ToString();
            e.Row.Cells[23].Controls.Add(lblTSIPASSMAPPED16);

            Label lblTSIPASSMAPPED17 = new Label();
            lblTSIPASSMAPPED17.Text = TSIPASSMAPPED17.ToString();
            e.Row.Cells[24].Text = TSIPASSMAPPED17.ToString();
            e.Row.Cells[24].Controls.Add(lblTSIPASSMAPPED17);

            Label lblTSIPASSMAPPED18 = new Label();
            lblTSIPASSMAPPED18.Text = TSIPASSMAPPED18.ToString();
            e.Row.Cells[25].Text = TSIPASSMAPPED18.ToString();
            e.Row.Cells[25].Controls.Add(lblTSIPASSMAPPED18);

            Label lblTSIPASSMAPPED19 = new Label();
            lblTSIPASSMAPPED19.Text = TSIPASSMAPPED19.ToString();
            e.Row.Cells[26].Text = TSIPASSMAPPED9.ToString();
            e.Row.Cells[26].Controls.Add(lblTSIPASSMAPPED19);

            Label lblTSIPASSMAPPED20 = new Label();
            lblTSIPASSMAPPED20.Text = TSIPASSMAPPED20.ToString();
            e.Row.Cells[27].Text = TSIPASSMAPPED20.ToString();
            e.Row.Cells[27].Controls.Add(lblTSIPASSMAPPED20);

            Label lblTSIPASSMAPPED21 = new Label();
            lblTSIPASSMAPPED21.Text = TSIPASSMAPPED21.ToString();
            e.Row.Cells[28].Text = TSIPASSMAPPED21.ToString();
            e.Row.Cells[28].Controls.Add(lblTSIPASSMAPPED21);

            Label lblTSIPASSMAPPED22 = new Label();
            lblTSIPASSMAPPED22.Text = TSIPASSMAPPED22.ToString();
            e.Row.Cells[29].Text = TSIPASSMAPPED22.ToString();
            e.Row.Cells[29].Controls.Add(lblTSIPASSMAPPED22);

            Label lblTSIPASSMAPPED23 = new Label();
            lblTSIPASSMAPPED23.Text = TSIPASSMAPPED23.ToString();
            e.Row.Cells[30].Text = TSIPASSMAPPED23.ToString();
            e.Row.Cells[30].Controls.Add(lblTSIPASSMAPPED23);

            Label lblTSIPASSMAPPED24 = new Label();
            lblTSIPASSMAPPED24.Text = TSIPASSMAPPED24.ToString();
            e.Row.Cells[31].Text = TSIPASSMAPPED24.ToString();
            e.Row.Cells[31].Controls.Add(lblTSIPASSMAPPED24);

            Label lblTSIPASSMAPPED25 = new Label();
            lblTSIPASSMAPPED25.Text = TSIPASSMAPPED25.ToString();
            e.Row.Cells[32].Text = TSIPASSMAPPED25.ToString();
            e.Row.Cells[32].Controls.Add(lblTSIPASSMAPPED25);

            Label lblTSIPASSMAPPED26 = new Label();
            lblTSIPASSMAPPED26.Text = TSIPASSMAPPED26.ToString();
            e.Row.Cells[33].Text = TSIPASSMAPPED26.ToString();
            e.Row.Cells[33].Controls.Add(lblTSIPASSMAPPED26);

            Label lblTSIPASSMAPPED27 = new Label();
            lblTSIPASSMAPPED27.Text = TSIPASSMAPPED27.ToString();
            e.Row.Cells[34].Text = TSIPASSMAPPED27.ToString();
            e.Row.Cells[34].Controls.Add(lblTSIPASSMAPPED27);

            Label lblTSIPASSMAPPED28 = new Label();
            lblTSIPASSMAPPED28.Text = TSIPASSMAPPED28.ToString();
            e.Row.Cells[35].Text = TSIPASSMAPPED28.ToString();
            e.Row.Cells[35].Controls.Add(lblTSIPASSMAPPED28);

            //Label lblTSIPASSMAPPED29 = new Label();
            //lblTSIPASSMAPPED29.Text = TSIPASSMAPPED29.ToString();
            //e.Row.Cells[36].Text = TSIPASSMAPPED29.ToString();
            //e.Row.Cells[36].Controls.Add(lblTSIPASSMAPPED29);

            //Label lblTSIPASSMAPPED30 = new Label();
            //lblTSIPASSMAPPED30.Text = TSIPASSMAPPED30.ToString();
            //e.Row.Cells[37].Text = TSIPASSMAPPED30.ToString();
            //e.Row.Cells[37].Controls.Add(lblTSIPASSMAPPED30);


            //Label lblTSIPASSMAPPED31 = new Label();
            //lblTSIPASSMAPPED31.Text = TSIPASSMAPPED31.ToString();
            //e.Row.Cells[38].Text = TSIPASSMAPPED31.ToString();
            //e.Row.Cells[38].Controls.Add(lblTSIPASSMAPPED31);

            //Label lblTSIPASSMAPPEDMonthlyTotal = new Label();
            //lblTSIPASSMAPPEDMonthlyTotal.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
            //e.Row.Cells[39].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
            //e.Row.Cells[39].Controls.Add(lblTSIPASSMAPPEDMonthlyTotal);



            Label lblTSIPASSMAPPED29 = new Label();
            Label lblTSIPASSMAPPED30 = new Label();
            Label lblTSIPASSMAPPED31 = new Label();
            Label lblTSIPASSMAPPEDMonthlyTotal = new Label();


            

            string usedays = Convert.ToString(ddl_Month.SelectedValue);
            string[] arg1 = new string[2];
            arg1 = usedays.Split('/');
            string Month = Convert.ToString(arg1[0]);
            string Year = Convert.ToString(arg1[1]);

            int days = DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month));
            if (days == 28)
            {
                //lblTSIPASSMAPPED29.Text = TSIPASSMAPPED29.ToString();
                //e.Row.Cells[36].Text = TSIPASSMAPPED29.ToString();
                //e.Row.Cells[36].Controls.Add(lblTSIPASSMAPPED29);

                //lblTSIPASSMAPPED30.Text = TSIPASSMAPPED30.ToString();
                //e.Row.Cells[37].Text = TSIPASSMAPPED30.ToString();
                //e.Row.Cells[37].Controls.Add(lblTSIPASSMAPPED30);

                //lblTSIPASSMAPPED31.Text = TSIPASSMAPPED31.ToString();
                //e.Row.Cells[38].Text = TSIPASSMAPPED31.ToString();
                //e.Row.Cells[38].Controls.Add(lblTSIPASSMAPPED31);


                lblTSIPASSMAPPEDMonthlyTotal.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                e.Row.Cells[36].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                e.Row.Cells[36].Controls.Add(lblTSIPASSMAPPEDMonthlyTotal);

            }
            else
            {

                lblTSIPASSMAPPED29.Text = TSIPASSMAPPED29.ToString();
                e.Row.Cells[36].Text = TSIPASSMAPPED29.ToString();
                e.Row.Cells[36].Controls.Add(lblTSIPASSMAPPED29);

                if (days == 29)
                {

                    //lblTSIPASSMAPPED30.Text = TSIPASSMAPPED30.ToString();
                    //e.Row.Cells[37].Text = TSIPASSMAPPED30.ToString();
                    //e.Row.Cells[37].Controls.Add(lblTSIPASSMAPPED30);

                    //lblTSIPASSMAPPED31.Text = TSIPASSMAPPED31.ToString();
                    //e.Row.Cells[38].Text = TSIPASSMAPPED31.ToString();
                    //e.Row.Cells[38].Controls.Add(lblTSIPASSMAPPED31);

                    lblTSIPASSMAPPEDMonthlyTotal.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                    e.Row.Cells[37].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                    e.Row.Cells[37].Controls.Add(lblTSIPASSMAPPEDMonthlyTotal);


                }
                else
                {
                    lblTSIPASSMAPPED30.Text = TSIPASSMAPPED30.ToString();
                    e.Row.Cells[37].Text = TSIPASSMAPPED30.ToString();
                    e.Row.Cells[37].Controls.Add(lblTSIPASSMAPPED30);

                    if (days == 30)
                    {

                        lblTSIPASSMAPPEDMonthlyTotal.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                        e.Row.Cells[38].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                        e.Row.Cells[38].Controls.Add(lblTSIPASSMAPPEDMonthlyTotal);
                    }
                    else
                    {
                        lblTSIPASSMAPPED31.Text = TSIPASSMAPPED31.ToString();
                        e.Row.Cells[38].Text = TSIPASSMAPPED31.ToString();
                        e.Row.Cells[38].Controls.Add(lblTSIPASSMAPPED31);


                        lblTSIPASSMAPPEDMonthlyTotal.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                        e.Row.Cells[39].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
                        e.Row.Cells[39].Controls.Add(lblTSIPASSMAPPEDMonthlyTotal);

                    }
                }
            }

        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7)
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 8;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
                else
                {
                    cellIndex++;


                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Cummulative No of MSME Units Mapped in" + Convert.ToString(ddl_Month.SelectedItem.Text);
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 32;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage);
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();


                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= Banker Report.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

  

    public DataSet GetMSMEApplications(string districtid,string MonthID,string Year)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                new SqlParameter("@MonthID",SqlDbType.VarChar),
                new SqlParameter("@Year",SqlDbType.VarChar)
           };
       
        pp[0].Value = districtid;
        pp[1].Value = MonthID;
        pp[2].Value = Year;
        Dsnew = Gen.GenericFillDs("MSME_GETREPORTMSMETSIPASSMAPPEDdatesbymonthyear", pp);
        return Dsnew;
    }

  





}