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


public partial class UI_TSiPASS_frmmsmeupdatedreport : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal Nounitsmega, Nounitslarge, Nounitsmedium, NounitsSmall, NounitMicro, Nounitstotal,
       noofupdated, noofeidited, noofrawmaterial, noofproducts, noofduplicate, noofnotexists,
       noclosed, noofothers, noofdirect, noofindirect, nooftotalemp,
       noofmen, noofwomen, nooflocal, noofnonlocal, noofmigrant, noofpf, noofesi, noofcompanyrolls, noofoutsourcing,
       noofskilled, noofsemiskilled, noofunskilled, noofmanagerial, noofies, noinvestment;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-03-2020";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            Label1.Text = "Report as on date " + DateTime.Now;
            if (Session["userlevel"].ToString().Trim() != "13")
            {
                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                    ddlProp_intDistrictid.Enabled = false;
                }
                else
                {
                    ddlProp_intDistrictid.SelectedIndex = 0;
                }

                fillgrid();
            }

            if (Session["userlevel"].ToString().Trim() == "13")
            {
                Response.Redirect("~/Index.aspx");
            }
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

    public void fillgrid()
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        dsnew = GetMSMEApplications(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();
            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Nounits1mega = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEGA"));
            Nounitsmega = Nounits1mega + Nounitsmega;
            decimal Nounits1large = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSLARGE"));
            Nounitslarge = Nounits1large + Nounitslarge;
            decimal Nounits1medium = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEDIUM"));
            Nounitsmedium = Nounits1medium + Nounitsmedium;
            decimal Nounits1small = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSSMALL"));
            NounitsSmall = Nounits1small + NounitsSmall;
            decimal Nounits1micro = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMICRO"));
            NounitMicro = Nounits1micro + NounitMicro;
            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSTOTAL"));
            Nounitstotal = Nounits1 + Nounitstotal;



            decimal noofupdated1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSUPDATED"));
            noofupdated = noofupdated1 + noofupdated;

            decimal noofeidited1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSEDITED"));
            noofeidited = noofeidited1 + noofeidited;
            decimal noofrawmaterial1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMATERIAL"));
            noofrawmaterial = noofrawmaterial1 + noofrawmaterial;
            decimal noofproducts1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSPRODUCT"));
            noofproducts = noofproducts1 + noofproducts;
            decimal noofduplicate1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSDUPLICATE"));
            noofduplicate = noofduplicate1 + noofduplicate;
            decimal noofnotexists1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSNOTEXIST"));
            noofnotexists = noofnotexists1 + noofnotexists;
            decimal noclosed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSCLOSED"));
            noclosed = noclosed1 + noclosed;
            decimal noofothers1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSOTHER"));
            noofothers = noofothers1 + noofothers;
            decimal noofdirect1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTDIRECT"));
            noofdirect = noofdirect1 + noofdirect;
            decimal noofindrect1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTINDIRECT"));
            noofindirect = noofindrect1 + noofindirect;
            decimal nooftotalemp1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTTOTAL"));
            nooftotalemp = nooftotalemp1 + nooftotalemp;
            decimal noofmen1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTMEN"));
            noofmen = noofmen1 + noofmen;
            decimal noofwomen1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTWOMEN"));
            noofwomen = noofwomen1 + noofwomen;
            decimal nooflocal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTLOCAL"));
            nooflocal = nooflocal1 + nooflocal;
            decimal noofnonlocal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTNONLOCAL"));
            noofnonlocal = noofnonlocal1 + noofnonlocal;
            decimal noofmigrant1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTMIGRANT"));
            noofmigrant = noofmigrant1 + noofmigrant;
            decimal noofpf1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTPF"));
            noofpf = noofpf1 + noofpf;
            decimal noofesi1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTESI"));
            noofesi = noofesi1 + noofesi;
            decimal noofcompanyrolls1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTCOMPANYROLLS"));
            noofcompanyrolls = noofcompanyrolls1 + noofcompanyrolls;
            decimal noofoutsourcing1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTOUTSOURCING"));
            noofoutsourcing = noofoutsourcing1 + noofoutsourcing;
            decimal noofskilled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTSKILLED"));
            noofskilled = noofskilled1 + noofskilled;
            decimal noofsemiskilled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTSEMISKILLED"));
            noofsemiskilled = noofsemiskilled1 + noofsemiskilled;
            decimal noofunskilled1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTUNSKILLED"));
            noofunskilled = noofunskilled1 + noofunskilled;
            decimal noofmanagerial1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EMPLOYMENTMANAGERIAL"));
            noofmanagerial = noofmanagerial1 + noofmanagerial;
            decimal NOOFUNITSIE1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSIE"));
            noofies = NOOFUNITSIE1 + noofies;
            decimal noofinvest1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "INVESTMENT"));
            noinvestment = noofinvest1 + noinvestment;





            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEGA");
            h1.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=1";

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyNOOFUNITSLARGE");
            h2.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=2";

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEDIUM");
            h3.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=3";

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyNOOFUNITSSMALL");
            h4.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=4";


            HyperLink h5 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMICRO");
            h5.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=5";

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyNOOFUNITSTOTAL");
            h6.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=6";

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyNOOFUNITSUPDATED");
            h7.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=7";

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyNOOFUNITSEDITED");
            h8.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=8";

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMATERIAL");
            h9.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=9";

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyNOOFUNITSPRODUCT");
            h10.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=10";

            HyperLink h11 = (HyperLink)e.Row.FindControl("HyNOOFUNITSDUPLICATE");
            h11.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=11";

            HyperLink h12 = (HyperLink)e.Row.FindControl("HyNOOFUNITSNOTEXIST");
            h12.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";


            HyperLink h13 = (HyperLink)e.Row.FindControl("HyNOOFUNITSCLOSED");
            h13.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h14 = (HyperLink)e.Row.FindControl("HyNOOFUNITSOTHER");
            h14.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h15 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTDIRECT");
            h15.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h16 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTINDIRECT");
            h16.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h17 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTTOTAL");
            h17.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h18 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTMEN");
            h18.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h19 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTWOMEN");
            h19.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h20 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTLOCAL");
            h20.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h21 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTNONLOCAL");
            h21.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h22 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTMIGRANT");
            h22.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h23 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTPF");
            h23.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h24 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTESI");
            h24.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h25 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTCOMPANYROLLS");
            h25.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h26 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTOUTSOURCING");
            h26.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h27 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTSKILLED");
            h27.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h28 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTSEMISKILLED");
            h28.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h29 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTUNSKILLED");
            h29.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h30 = (HyperLink)e.Row.FindControl("HyEMPLOYMENTMANAGERIAL");
            h30.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h31 = (HyperLink)e.Row.FindControl("HyNOOFUNITSIE");
            h31.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";

            HyperLink h32 = (HyperLink)e.Row.FindControl("HyINVESTMENT");
            h32.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";



        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            //Label nounitstotal = new Label();         


            HyperLink hyNounitsmega = new HyperLink();
            hyNounitsmega.Text = Nounitsmega.ToString();
            e.Row.Cells[2].Text = Nounitsmega.ToString();
            e.Row.Cells[2].Controls.Add(hyNounitsmega);
            hyNounitsmega.ForeColor = System.Drawing.Color.White;
            hyNounitsmega.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=1";

            HyperLink hyNounitslarge = new HyperLink();
            hyNounitslarge.Text = Nounitslarge.ToString();
            e.Row.Cells[3].Text = Nounitslarge.ToString();
            e.Row.Cells[3].Controls.Add(hyNounitslarge);
            hyNounitslarge.ForeColor = System.Drawing.Color.White;
            hyNounitslarge.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=2";

            HyperLink hyNounitsmedium = new HyperLink();
            hyNounitsmedium.Text = Nounitsmedium.ToString();
            e.Row.Cells[4].Text = Nounitsmedium.ToString();
            e.Row.Cells[4].Controls.Add(hyNounitsmedium);
            hyNounitsmedium.ForeColor = System.Drawing.Color.White;
            hyNounitsmedium.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=3";

            HyperLink hyNounitsSmall = new HyperLink();
            hyNounitsSmall.Text = NounitsSmall.ToString();
            e.Row.Cells[5].Text = NounitsSmall.ToString();
            e.Row.Cells[5].Controls.Add(hyNounitsSmall);
            hyNounitsSmall.ForeColor = System.Drawing.Color.White;
            hyNounitsSmall.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=4";

            HyperLink hyNounitMicro = new HyperLink();
            hyNounitMicro.Text = NounitMicro.ToString();
            e.Row.Cells[6].Text = NounitMicro.ToString();
            e.Row.Cells[6].Controls.Add(hyNounitMicro);
            hyNounitMicro.ForeColor = System.Drawing.Color.White;
            hyNounitMicro.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=5";

            HyperLink hyNounitstotal = new HyperLink();
            hyNounitstotal.Text = Nounitstotal.ToString();
            e.Row.Cells[7].Text = Nounitstotal.ToString();
            e.Row.Cells[7].Controls.Add(hyNounitstotal);
            hyNounitstotal.ForeColor = System.Drawing.Color.White;
            hyNounitstotal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=6";

            HyperLink hynoofupdated = new HyperLink();
            hynoofupdated.Text = noofupdated.ToString();
            e.Row.Cells[8].Text = noofupdated.ToString();
            e.Row.Cells[8].Controls.Add(hynoofupdated);
            hynoofupdated.ForeColor = System.Drawing.Color.White;
            hynoofupdated.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=7";


            HyperLink hynoofeidited = new HyperLink();
            hynoofeidited.Text = noofeidited.ToString();
            e.Row.Cells[9].Text = noofeidited.ToString();
            e.Row.Cells[9].Controls.Add(hynoofeidited);
            hynoofeidited.ForeColor = System.Drawing.Color.White;
            hynoofeidited.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=8";

            HyperLink hynoofrawmaterial = new HyperLink();
            hynoofrawmaterial.Text = noofrawmaterial.ToString();
            e.Row.Cells[10].Text = noofrawmaterial.ToString();
            e.Row.Cells[10].Controls.Add(hynoofrawmaterial);
            hynoofrawmaterial.ForeColor = System.Drawing.Color.White;
            hynoofrawmaterial.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=9";

            HyperLink hynoofproducts = new HyperLink();
            hynoofproducts.Text = noofproducts.ToString();
            e.Row.Cells[11].Text = noofproducts.ToString();
            e.Row.Cells[11].Controls.Add(hynoofproducts);
            hynoofproducts.ForeColor = System.Drawing.Color.White;
            hynoofproducts.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=10";

            HyperLink hynoofduplicate = new HyperLink();
            hynoofduplicate.Text = noofduplicate.ToString();
            e.Row.Cells[12].Text = noofduplicate.ToString();
            e.Row.Cells[12].Controls.Add(hynoofduplicate);
            hynoofduplicate.ForeColor = System.Drawing.Color.White;
            hynoofduplicate.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=11";

            HyperLink hynoofnotexists = new HyperLink();
            hynoofnotexists.Text = noofnotexists.ToString();
            e.Row.Cells[13].Text = noofnotexists.ToString();
            e.Row.Cells[13].Controls.Add(hynoofnotexists);
            hynoofnotexists.ForeColor = System.Drawing.Color.White;
            hynoofnotexists.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=12";

            HyperLink hynoclosed = new HyperLink();
            hynoclosed.Text = noclosed.ToString();
            e.Row.Cells[14].Text = noclosed.ToString();
            e.Row.Cells[14].Controls.Add(hynoclosed);
            hynoclosed.ForeColor = System.Drawing.Color.White;
            hynoclosed.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=13";

            HyperLink hynoofothers = new HyperLink();
            hynoofothers.Text = noofothers.ToString();
            e.Row.Cells[15].Text = noofothers.ToString();
            e.Row.Cells[15].Controls.Add(hynoofothers);
            hynoofothers.ForeColor = System.Drawing.Color.White;
            hynoofothers.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=14";

            HyperLink hynoofidrect = new HyperLink();
            hynoofidrect.Text = noofdirect.ToString();
            e.Row.Cells[16].Text = noofdirect.ToString();
            e.Row.Cells[16].Controls.Add(hynoofidrect);
            hynoofidrect.ForeColor = System.Drawing.Color.White;
            hynoofidrect.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=15";

            HyperLink hynoofindirect = new HyperLink();
            hynoofindirect.Text = noofindirect.ToString();
            e.Row.Cells[17].Text = noofindirect.ToString();
            e.Row.Cells[17].Controls.Add(hynoofindirect);
            hynoofindirect.ForeColor = System.Drawing.Color.White;
            hynoofindirect.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=16";

            HyperLink hynooftotalemp = new HyperLink();
            hynooftotalemp.Text = nooftotalemp.ToString();
            e.Row.Cells[18].Text = nooftotalemp.ToString();
            e.Row.Cells[18].Controls.Add(hynooftotalemp);
            hynooftotalemp.ForeColor = System.Drawing.Color.White;
            hynooftotalemp.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=17";

            HyperLink hynoofmen = new HyperLink();
            hynoofmen.Text = noofmen.ToString();
            e.Row.Cells[19].Text = noofmen.ToString();
            e.Row.Cells[19].Controls.Add(hynoofmen);
            hynoofmen.ForeColor = System.Drawing.Color.White;
            hynoofmen.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=18";

            HyperLink hynoofwomen = new HyperLink();
            hynoofwomen.Text = noofwomen.ToString();
            e.Row.Cells[20].Text = noofwomen.ToString();
            e.Row.Cells[20].Controls.Add(hynoofwomen);
            hynoofwomen.ForeColor = System.Drawing.Color.White;
            hynoofwomen.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=19";

            HyperLink hynooflocal = new HyperLink();
            hynooflocal.Text = nooflocal.ToString();
            e.Row.Cells[21].Text = nooflocal.ToString();
            e.Row.Cells[21].Controls.Add(hynooflocal);
            hynooflocal.ForeColor = System.Drawing.Color.White;
            hynooflocal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=20";

            HyperLink hynoofnonlocal = new HyperLink();
            hynoofnonlocal.Text = noofnonlocal.ToString();
            e.Row.Cells[22].Text = noofnonlocal.ToString();
            e.Row.Cells[22].Controls.Add(hynoofnonlocal);
            hynoofnonlocal.ForeColor = System.Drawing.Color.White;
            hynoofnonlocal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=21";

            HyperLink hynoofmigrant = new HyperLink();
            hynoofmigrant.Text = noofmigrant.ToString();
            e.Row.Cells[23].Text = noofmigrant.ToString();
            e.Row.Cells[23].Controls.Add(hynoofmigrant);
            hynoofmigrant.ForeColor = System.Drawing.Color.White;
            hynoofmigrant.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=22";

            HyperLink hynoofpf = new HyperLink();
            hynoofpf.Text = noofpf.ToString();
            e.Row.Cells[24].Text = noofpf.ToString();
            e.Row.Cells[24].Controls.Add(hynoofpf);
            hynoofpf.ForeColor = System.Drawing.Color.White;
            hynoofpf.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=23";

            HyperLink hynoofesi = new HyperLink();
            hynoofesi.Text = noofesi.ToString();
            e.Row.Cells[25].Text = noofesi.ToString();
            e.Row.Cells[25].Controls.Add(hynoofesi);
            hynoofesi.ForeColor = System.Drawing.Color.White;
            hynoofesi.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=24";

            HyperLink hynoofcompanyrolls = new HyperLink();
            hynoofcompanyrolls.Text = noofcompanyrolls.ToString();
            e.Row.Cells[26].Text = noofcompanyrolls.ToString();
            e.Row.Cells[26].Controls.Add(hynoofcompanyrolls);
            hynoofcompanyrolls.ForeColor = System.Drawing.Color.White;
            hynoofcompanyrolls.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=25";

            HyperLink hynoofoutsourcing = new HyperLink();
            hynoofoutsourcing.Text = noofoutsourcing.ToString();
            e.Row.Cells[27].Text = noofoutsourcing.ToString();
            e.Row.Cells[27].Controls.Add(hynoofoutsourcing);
            hynoofoutsourcing.ForeColor = System.Drawing.Color.White;
            hynoofoutsourcing.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=26";

            HyperLink hynoofskilled = new HyperLink();
            hynoofskilled.Text = noofskilled.ToString();
            e.Row.Cells[28].Text = noofskilled.ToString();
            e.Row.Cells[28].Controls.Add(hynoofskilled);
            hynoofskilled.ForeColor = System.Drawing.Color.White;
            hynoofskilled.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=27";


            HyperLink hynoofsemiskilled = new HyperLink();
            hynoofsemiskilled.Text = noofsemiskilled.ToString();
            e.Row.Cells[29].Text = noofsemiskilled.ToString();
            e.Row.Cells[29].Controls.Add(hynoofsemiskilled);
            hynoofsemiskilled.ForeColor = System.Drawing.Color.White;
            hynoofsemiskilled.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=27";

            HyperLink hynoofunskilled = new HyperLink();
            hynoofunskilled.Text = noofunskilled.ToString();
            e.Row.Cells[30].Text = noofunskilled.ToString();
            e.Row.Cells[30].Controls.Add(hynoofunskilled);
            hynoofunskilled.ForeColor = System.Drawing.Color.White;
            hynoofunskilled.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=28";

            HyperLink hynoofmanagerial = new HyperLink();
            hynoofmanagerial.Text = noofmanagerial.ToString();
            e.Row.Cells[31].Text = noofmanagerial.ToString();
            e.Row.Cells[31].Controls.Add(hynoofmanagerial);
            hynoofmanagerial.ForeColor = System.Drawing.Color.White;
            hynoofmanagerial.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=29";

            HyperLink hynoofies = new HyperLink();
            hynoofies.Text = noofies.ToString();
            e.Row.Cells[32].Text = noofies.ToString();
            e.Row.Cells[32].Controls.Add(hynoofies);
            hynoofies.ForeColor = System.Drawing.Color.White;
            hynoofies.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=30";

            //  HyperLink  = new HyperLink();
            //.Text = .ToString();
            //e.Row.Cells[32].Text = .ToString();
            //e.Row.Cells[32].Controls.Add();
            //.ForeColor = System.Drawing.Color.White;
            //.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=";

            HyperLink hynoinvestment = new HyperLink();
            hynoinvestment.Text = noinvestment.ToString();
            e.Row.Cells[33].Text = noinvestment.ToString();
            e.Row.Cells[33].Controls.Add(hynoinvestment);
            hynoinvestment.ForeColor = System.Drawing.Color.White;
            hynoinvestment.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=31";


        }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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
                    //To Export all pages
                    //trLogo.Visible = true;

                    //this.FillGridDetails();

                    //grdDetails.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

                    // grdExport.Columns[1].Visible = false;
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

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        //string status = Request.QueryString[0].ToString().Trim();
        //DataSet ds = new DataSet();
        //string input, financial, fromdate, todate;
        //input = rbtnlstInputType.SelectedValue.ToString().Trim();
        //financial = ddlFinancialYear.SelectedValue.ToString().Trim();
        //fromdate = txtFromDate.Text;
        //todate = txtTodate.Text;
        //ds = Gen.getR1DrildownbyidfinNew(status, ddlCategory.SelectedItem.Text, ddldistrict.SelectedValue, input, financial, fromdate, todate);

        //if (ds != null && ds.Tables[0].Rows.Count > 0)
        //{
        //    Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
        //    ds.Tables[0].Columns.Remove("DOA");
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    Label1.Text = "No Records Found ";
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    public DataSet GetMSMEApplications(string fromdate, string todate, string districtid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;


        Dsnew = Gen.GenericFillDs("USP_GET_MSME_REPORT_EMPLOYMENT", pp);
        return Dsnew;
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
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 15
                    || i == 16 || i == 17 || i == 18 || i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24 || i == 25 || i == 26 || i == 27
                    || i == 28 || i == 29 || i == 30 || i == 31)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "No. of Industries";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 6;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "No. Of Units Updated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "No. of units deleted";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);

            TableCell tcMergePackage3 = new TableCell();
            tcMergePackage3.Text = "Employment";
            tcMergePackage3.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage3.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage3);

            TableCell tcMergePackage4 = new TableCell();
            tcMergePackage4.Text = "Gender wise";
            tcMergePackage4.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage4.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage4);

            TableCell tcMergePackage5 = new TableCell();
            tcMergePackage5.Text = "Local Employment";
            tcMergePackage5.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage5.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(7, tcMergePackage5);

            TableCell tcMergePackage6 = new TableCell();
            tcMergePackage6.Text = "Statutory benefits";
            tcMergePackage6.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage6.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(8, tcMergePackage6);

            TableCell tcMergePackage7 = new TableCell();
            tcMergePackage7.Text = "Mode of hiring";
            tcMergePackage7.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage7.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(9, tcMergePackage7);

            TableCell tcMergePackage8 = new TableCell();
            tcMergePackage8.Text = "Skill Wise Employment";
            tcMergePackage8.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage8.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(10, tcMergePackage8);

        }
    }
}