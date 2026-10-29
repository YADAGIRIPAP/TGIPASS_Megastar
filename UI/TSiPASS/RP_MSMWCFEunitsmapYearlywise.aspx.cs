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


public partial class UI_TSiPASS_RP_MSMWCFEunitsmapYearlywise : System.Web.UI.Page
{

    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    decimal Nounits, msmemapped, msmenotmapped, tsunits, tsmapped, tsnotmapped,
      TSIPASSMAPPEDJanuary, TSIPASSMAPPEDFebruary, TSIPASSMAPPEDMarch, TSIPASSMAPPEDApril, TSIPASSMAPPEDMay, TSIPASSMAPPEDJune, TSIPASSMAPPEDJuly,
      TSIPASSMAPPEDAugust, TSIPASSMAPPEDSeptember, TSIPASSMAPPEDOctober, TSIPASSMAPPEDNovember, TSIPASSMAPPEDDecember, TSIPASSMAPPEDMonthlyTotal;
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
            ddl_year.SelectedValue =Convert.ToString(DateTime.Now.Year);
            fillgrid();
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
        if (ddl_year.SelectedValue == "" || ddl_year.SelectedValue == null)
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

        DataSet dsnew = new DataSet();
        dsnew = GetMSMEApplications(ddlProp_intDistrictid.SelectedValue, ddl_year.SelectedValue);
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
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink HyNoofClaimsFiled = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            HyNoofClaimsFiled.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMENOOFUNITS";

            HyperLink HyMSMEMAPPEDWITHTSIPASS = (HyperLink)e.Row.FindControl("HyMSMEMAPPEDWITHTSIPASS");
            HyMSMEMAPPEDWITHTSIPASS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMEMAPPEDWITHTSIPASS";

            HyperLink HyMSMENOTMAPPEDWITHTSIPASS = (HyperLink)e.Row.FindControl("HyMSMENOTMAPPEDWITHTSIPASS");
            HyMSMENOTMAPPEDWITHTSIPASS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMENOTMAPPEDWITHTSIPASS";

            HyperLink HyTSIPASSUNITS = (HyperLink)e.Row.FindControl("HyTSIPASSUNITS");
            HyTSIPASSUNITS.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSUNITS";

            HyperLink HyTSIPASSMAPPEDWITHMSME = (HyperLink)e.Row.FindControl("HyTSIPASSMAPPEDWITHMSME");
            HyTSIPASSMAPPEDWITHMSME.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDWITHMSME";

            HyperLink HyTsipassnotmapped = (HyperLink)e.Row.FindControl("HyTsipassnotmapped");
            HyTsipassnotmapped.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSNOTMAPPEDWITHMSME";

            HyperLink hypTSIPASSMAPPEDJanuary = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDJanuary");
            hypTSIPASSMAPPEDJanuary.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDJanuary";
            HyperLink hypTSIPASSMAPPEDFebruary = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDFebruary");
            hypTSIPASSMAPPEDFebruary.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDFebruary";
            HyperLink hypTSIPASSMAPPEDMarch = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDMarch");
            hypTSIPASSMAPPEDMarch.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDMarch";
            HyperLink hypTSIPASSMAPPEDApril = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDApril");
            hypTSIPASSMAPPEDApril.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDApril";
            HyperLink hypTSIPASSMAPPEDMay = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDMay");
            hypTSIPASSMAPPEDMay.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDMay";

            HyperLink hypTSIPASSMAPPEDJune = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDJune");
            hypTSIPASSMAPPEDJune.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDJune";
            HyperLink hypTSIPASSMAPPEDJuly = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDJuly");
            hypTSIPASSMAPPEDJuly.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDJuly";
            HyperLink hypTSIPASSMAPPEDAugust = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDAugust");
            hypTSIPASSMAPPEDAugust.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDAugust";
            HyperLink hypTSIPASSMAPPEDSeptember = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDSeptember");
            hypTSIPASSMAPPEDSeptember.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDSeptember";
            HyperLink hypTSIPASSMAPPEDOctober = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDOctober");
            hypTSIPASSMAPPEDOctober.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDOctober";

            HyperLink hypTSIPASSMAPPEDNovember = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDNovember");
            hypTSIPASSMAPPEDNovember.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDNovember";
            HyperLink hypTSIPASSMAPPEDDecember = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDDecember");
            hypTSIPASSMAPPEDDecember.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDDecember";
           
            HyperLink hypTSIPASSMAPPEDMonthlyTotal = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPEDMonthlyTotal");
            hypTSIPASSMAPPEDMonthlyTotal.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + ddl_year.SelectedValue + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDMonthlyTotal";


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

            decimal TSIPASSMAPPEDrow1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDJanuary"));
            TSIPASSMAPPEDJanuary = TSIPASSMAPPEDrow1 + TSIPASSMAPPEDJanuary;

            decimal TSIPASSMAPPEDrow2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDFebruary"));
            TSIPASSMAPPEDFebruary = TSIPASSMAPPEDrow2 + TSIPASSMAPPEDFebruary;

            decimal TSIPASSMAPPEDrow3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDMarch"));
            TSIPASSMAPPEDMarch = TSIPASSMAPPEDrow3 + TSIPASSMAPPEDMarch;

            decimal TSIPASSMAPPEDrow4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDApril"));
            TSIPASSMAPPEDApril = TSIPASSMAPPEDrow4 + TSIPASSMAPPEDApril;

            decimal TSIPASSMAPPEDrow5 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDMay"));
            TSIPASSMAPPEDMay = TSIPASSMAPPEDrow5 + TSIPASSMAPPEDMay;

            decimal TSIPASSMAPPEDrow6 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDJune"));
            TSIPASSMAPPEDJune = TSIPASSMAPPEDrow6 + TSIPASSMAPPEDJune;

            decimal TSIPASSMAPPEDrow7 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDJuly"));
            TSIPASSMAPPEDJuly = TSIPASSMAPPEDrow7 + TSIPASSMAPPEDJuly;

            decimal TSIPASSMAPPEDrow8 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDAugust"));
            TSIPASSMAPPEDAugust = TSIPASSMAPPEDrow8 + TSIPASSMAPPEDAugust;

            decimal TSIPASSMAPPEDrow9 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDSeptember"));
            TSIPASSMAPPEDSeptember = TSIPASSMAPPEDrow9 + TSIPASSMAPPEDSeptember;

            decimal TSIPASSMAPPEDrow10 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDOctober"));
            TSIPASSMAPPEDOctober = TSIPASSMAPPEDrow10 + TSIPASSMAPPEDOctober;

            decimal TSIPASSMAPPEDrow11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDNovember"));
            TSIPASSMAPPEDNovember = TSIPASSMAPPEDrow11 + TSIPASSMAPPEDNovember;

            decimal TSIPASSMAPPEDrow12 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDDecember"));
            TSIPASSMAPPEDDecember = TSIPASSMAPPEDrow12 + TSIPASSMAPPEDDecember;

            decimal TSIPASSMAPPEDrowMonthlyTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPEDMonthlyTotal"));
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
            lblTSIPASSMAPPED1.Text = TSIPASSMAPPEDJanuary.ToString();
            e.Row.Cells[8].Text = TSIPASSMAPPEDJanuary.ToString();
            e.Row.Cells[8].Controls.Add(lblTSIPASSMAPPED1);

            Label lblTSIPASSMAPPED2 = new Label();
            lblTSIPASSMAPPED2.Text = TSIPASSMAPPEDFebruary.ToString();
            e.Row.Cells[9].Text = TSIPASSMAPPEDFebruary.ToString();
            e.Row.Cells[9].Controls.Add(lblTSIPASSMAPPED2);

            Label lblTSIPASSMAPPED3 = new Label();
            lblTSIPASSMAPPED3.Text = TSIPASSMAPPEDMarch.ToString();
            e.Row.Cells[10].Text = TSIPASSMAPPEDMarch.ToString();
            e.Row.Cells[10].Controls.Add(lblTSIPASSMAPPED3);

            Label lblTSIPASSMAPPED4 = new Label();
            lblTSIPASSMAPPED4.Text = TSIPASSMAPPEDApril.ToString();
            e.Row.Cells[11].Text = TSIPASSMAPPEDApril.ToString();
            e.Row.Cells[11].Controls.Add(lblTSIPASSMAPPED4);

            Label lblTSIPASSMAPPED5 = new Label();
            lblTSIPASSMAPPED5.Text = TSIPASSMAPPEDMay.ToString();
            e.Row.Cells[12].Text = TSIPASSMAPPEDMay.ToString();
            e.Row.Cells[12].Controls.Add(lblTSIPASSMAPPED5);

            Label lblTSIPASSMAPPED6 = new Label();
            lblTSIPASSMAPPED6.Text = TSIPASSMAPPEDJune.ToString();
            e.Row.Cells[13].Text = TSIPASSMAPPEDJune.ToString();
            e.Row.Cells[13].Controls.Add(lblTSIPASSMAPPED6);

            Label lblTSIPASSMAPPED7 = new Label();
            lblTSIPASSMAPPED7.Text = TSIPASSMAPPEDJuly.ToString();
            e.Row.Cells[14].Text = TSIPASSMAPPEDJuly.ToString();
            e.Row.Cells[14].Controls.Add(lblTSIPASSMAPPED7);

            Label lblTSIPASSMAPPED8 = new Label();
            lblTSIPASSMAPPED8.Text = TSIPASSMAPPEDAugust.ToString();
            e.Row.Cells[15].Text = TSIPASSMAPPEDAugust.ToString();
            e.Row.Cells[15].Controls.Add(lblTSIPASSMAPPED8);

            Label lblTSIPASSMAPPED9 = new Label();
            lblTSIPASSMAPPED9.Text = TSIPASSMAPPEDSeptember.ToString();
            e.Row.Cells[16].Text = TSIPASSMAPPEDSeptember.ToString();
            e.Row.Cells[16].Controls.Add(lblTSIPASSMAPPED9);

            Label lblTSIPASSMAPPED10 = new Label();
            lblTSIPASSMAPPED10.Text = TSIPASSMAPPEDOctober.ToString();
            e.Row.Cells[17].Text = TSIPASSMAPPEDOctober.ToString();
            e.Row.Cells[17].Controls.Add(lblTSIPASSMAPPED10);

            Label lblTSIPASSMAPPED11 = new Label();
            lblTSIPASSMAPPED11.Text = TSIPASSMAPPEDNovember.ToString();
            e.Row.Cells[18].Text = TSIPASSMAPPEDNovember.ToString();
            e.Row.Cells[18].Controls.Add(lblTSIPASSMAPPED11);

            Label lblTSIPASSMAPPED12 = new Label();
            lblTSIPASSMAPPED12.Text = TSIPASSMAPPEDDecember.ToString();
            e.Row.Cells[19].Text = TSIPASSMAPPEDDecember.ToString();
            e.Row.Cells[19].Controls.Add(lblTSIPASSMAPPED12);

            Label lblTSIPASSMAPPED13 = new Label();
            lblTSIPASSMAPPED13.Text = TSIPASSMAPPEDMonthlyTotal.ToString();
            e.Row.Cells[20].Text = TSIPASSMAPPEDMonthlyTotal.ToString();
            e.Row.Cells[20].Controls.Add(lblTSIPASSMAPPED13);

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
            tcMergePackage.Text = "Cummulative No of MSME Units Mapped in" + ddl_year.SelectedItem.Text;
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

    public DataSet GetMSMEApplications(string districtid,string Year)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
                new SqlParameter("@Year",SqlDbType.VarChar)

           };

        pp[0].Value = districtid;
        pp[1].Value = Year;
        Dsnew = Gen.GenericFillDs("MSME_GETREPORTMSMETSIPASSMAPPEDyearwise", pp);
        return Dsnew;
    }




}