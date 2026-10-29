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

public partial class UI_TSiPASS_frmMSMEReportEmployement : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal Nounitsmega, Nounitslarge, Nounitsmedium, Nounits,
        Nounitsmegaemployee, Nounitslargeemployee, Nounitsmediumemployee, Nounitsemployee,
        Nounitsmegaemployeebal, Nounitslargeemployeebal, Nounitsmediumemployeebal, Nounitsemployeebal;
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
            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSTOTAL"));
            Nounits = Nounits1 + Nounits;


            decimal Nounits1megaemployee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEGAEMPLOY"));
            Nounitsmegaemployee = Nounits1megaemployee + Nounitsmegaemployee;
            decimal Nounits1largeemployee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSLARGEEMPLOY"));
            Nounitslargeemployee = Nounits1largeemployee + Nounitslargeemployee;
            decimal Nounits1mediumemployee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEDIUMEMPLOY"));
            Nounitsmediumemployee = Nounits1mediumemployee + Nounitsmediumemployee;
            decimal Nounits1employee = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSTOTALEMPLOY"));
            Nounitsemployee = Nounits1employee + Nounitsemployee;

            decimal Nounits1megaemployeebal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEGAEMPLOYBAL"));
            Nounitsmegaemployeebal = Nounits1megaemployeebal + Nounitsmegaemployeebal;
            decimal Nounits1largeemployeebal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSLARGEEMPLOYBAL"));
            Nounitslargeemployeebal = Nounits1largeemployeebal + Nounitslargeemployeebal;
            decimal Nounits1mediumemployeebal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSMEDIUMEMPLOYBAL"));
            Nounitsmediumemployeebal = Nounits1mediumemployeebal + Nounitsmediumemployeebal;
            decimal Nounits1employeebal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUNITSTOTALEMPLOYBAL"));
            Nounitsemployeebal = Nounits1employeebal + Nounitsemployeebal;



            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEGA");
            h1.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=1";

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyNOOFUNITSLARGE");
            h2.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=2";

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEDIUM");
            h3.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=3";

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyNOOFUNITSTOTAL");
            h4.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=4";


            HyperLink h5 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEGAEMPLOY");
            h5.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=5";

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyNOOFUNITSLARGEEMPLOY");
            h6.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=6";

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEDIUMEMPLOY");
            h7.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=7";

            HyperLink h8 = (HyperLink)e.Row.FindControl("HyNOOFUNITSTOTALEMPLOY");
            h8.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=8";

            HyperLink h9 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEGAEMPLOYBAL");
            h9.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=9";

            HyperLink h10 = (HyperLink)e.Row.FindControl("HyNOOFUNITSLARGEEMPLOYBAL");
            h10.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=10";

            HyperLink h11 = (HyperLink)e.Row.FindControl("HyNOOFUNITSMEDIUMEMPLOYBAL");
            h11.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=11";

            HyperLink h12 = (HyperLink)e.Row.FindControl("HyNOOFUNITSTOTALEMPLOYBAL");
            h12.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=12";


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            //Label nounitstotal = new Label();         


            HyperLink nounitstotalmega = new HyperLink();
            nounitstotalmega.Text = Nounitsmega.ToString();
            e.Row.Cells[2].Text = Nounitsmega.ToString();
            e.Row.Cells[2].Controls.Add(nounitstotalmega);
            nounitstotalmega.ForeColor = System.Drawing.Color.White;
            nounitstotalmega.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=1";

            HyperLink nounitstotallarge = new HyperLink();
            nounitstotallarge.Text = Nounitslarge.ToString();
            e.Row.Cells[3].Text = Nounitslarge.ToString();
            e.Row.Cells[3].Controls.Add(nounitstotallarge);
            nounitstotallarge.ForeColor = System.Drawing.Color.White;
            nounitstotallarge.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=2";

            HyperLink nounitstotalmedium = new HyperLink();
            nounitstotalmedium.Text = Nounitsmedium.ToString();
            e.Row.Cells[4].Text = Nounitsmedium.ToString();
            e.Row.Cells[4].Controls.Add(nounitstotalmedium);
            nounitstotalmedium.ForeColor = System.Drawing.Color.White;
            nounitstotalmedium.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=3";

            HyperLink nounitstotal = new HyperLink();
            nounitstotal.Text = Nounits.ToString();
            e.Row.Cells[5].Text = Nounits.ToString();
            e.Row.Cells[5].Controls.Add(nounitstotal);
            nounitstotal.ForeColor = System.Drawing.Color.White;
            nounitstotal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=4";




            HyperLink nounitstotalmegaemployee = new HyperLink();
            nounitstotalmegaemployee.Text = Nounitsmegaemployee.ToString();
            e.Row.Cells[6].Text = Nounitsmegaemployee.ToString();
            e.Row.Cells[6].Controls.Add(nounitstotalmegaemployee);
            nounitstotalmegaemployee.ForeColor = System.Drawing.Color.White;
            nounitstotalmegaemployee.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=5";

            HyperLink nounitstotallargeemployee = new HyperLink();
            nounitstotallargeemployee.Text = Nounitslargeemployee.ToString();
            e.Row.Cells[7].Text = Nounitslargeemployee.ToString();
            e.Row.Cells[7].Controls.Add(nounitstotallargeemployee);
            nounitstotallargeemployee.ForeColor = System.Drawing.Color.White;
            nounitstotallargeemployee.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=6";

            HyperLink nounitstotalmediumemployee = new HyperLink();
            nounitstotalmediumemployee.Text = Nounitsmediumemployee.ToString();
            e.Row.Cells[8].Text = Nounitsmediumemployee.ToString();
            e.Row.Cells[8].Controls.Add(nounitstotalmediumemployee);
            nounitstotalmediumemployee.ForeColor = System.Drawing.Color.White;
            nounitstotalmediumemployee.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=7";

            HyperLink nounitstotalemployee = new HyperLink();
            nounitstotalemployee.Text = Nounitsemployee.ToString();
            e.Row.Cells[9].Text = Nounitsemployee.ToString();
            e.Row.Cells[9].Controls.Add(nounitstotalemployee);
            nounitstotalemployee.ForeColor = System.Drawing.Color.White;
            nounitstotalemployee.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=8";




            HyperLink nounitstotalmegaemployeebal = new HyperLink();
            nounitstotalmegaemployeebal.Text = Nounitsmegaemployeebal.ToString();
            e.Row.Cells[10].Text = Nounitsmegaemployeebal.ToString();
            e.Row.Cells[10].Controls.Add(nounitstotalmegaemployeebal);
            nounitstotalmegaemployeebal.ForeColor = System.Drawing.Color.White;
            nounitstotalmegaemployeebal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=9";

            HyperLink nounitstotallargeemployeebal = new HyperLink();
            nounitstotallargeemployeebal.Text = Nounitslargeemployeebal.ToString();
            e.Row.Cells[11].Text = Nounitslargeemployeebal.ToString();
            e.Row.Cells[11].Controls.Add(nounitstotallargeemployeebal);
            nounitstotallargeemployeebal.ForeColor = System.Drawing.Color.White;
            nounitstotallargeemployeebal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=10";

            HyperLink nounitstotalmediumemployeebal = new HyperLink();
            nounitstotalmediumemployeebal.Text = Nounitsmediumemployeebal.ToString();
            e.Row.Cells[12].Text = Nounitsmediumemployeebal.ToString();
            e.Row.Cells[12].Controls.Add(nounitstotalmediumemployeebal);
            nounitstotalmediumemployeebal.ForeColor = System.Drawing.Color.White;
            nounitstotalmediumemployeebal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=11";

            HyperLink nounitstotalemployeebal = new HyperLink();
            nounitstotalemployeebal.Text = Nounitsemployeebal.ToString();
            e.Row.Cells[13].Text = Nounitsemployeebal.ToString();
            e.Row.Cells[13].Controls.Add(nounitstotalemployeebal);
            nounitstotalemployeebal.ForeColor = System.Drawing.Color.White;
            nounitstotalemployeebal.NavigateUrl = "frmMSMEReportDRILLDOWNEmployement.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL" + "&type=12";


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


        Dsnew = Gen.GenericFillDs("USP_GET_MSME_EMPLOYEEMENT_REPORT", pp);
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
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13 || i == 14)
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
            tcMergePackage.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Updated";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage1);

            TableCell tcMergePackage2 = new TableCell();
            tcMergePackage2.Text = "Balance";
            tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage2.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage2);
        }
    }
}