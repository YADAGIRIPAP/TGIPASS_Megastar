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

public partial class UI_TSiPASS_frmmsmecfeuitsreports : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal Nounits, msmemapped, msmenotmapped, tsunits, tsmapped, tsnotmapped, TSIPASSMAPPED240621, TSIPASSMAPPED250621, TSIPASSMAPPED260621,TSIPASSMAPPED270621,TSIPASSMAPPED280621,TSIPASSMAPPED290621,TSIPASSMAPPED300621;
   
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

            decimal TSIPASSMAPPED2406211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED240621"));
            TSIPASSMAPPED240621 = TSIPASSMAPPED2406211 + TSIPASSMAPPED240621;

            decimal TSIPASSMAPPED2506211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED250621"));
            TSIPASSMAPPED250621 = TSIPASSMAPPED2506211 + TSIPASSMAPPED250621;

            decimal TSIPASSMAPPED2606211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED260621"));
            TSIPASSMAPPED260621 = TSIPASSMAPPED2606211 + TSIPASSMAPPED260621;

            decimal TSIPASSMAPPED2706211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED270621"));
            TSIPASSMAPPED270621 = TSIPASSMAPPED2706211 + TSIPASSMAPPED270621;

            decimal TSIPASSMAPPED2806211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED280621"));
            TSIPASSMAPPED280621 = TSIPASSMAPPED2806211 + TSIPASSMAPPED280621;

            decimal TSIPASSMAPPED2906211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED290621"));
            TSIPASSMAPPED290621 = TSIPASSMAPPED2906211 + TSIPASSMAPPED290621;

            decimal TSIPASSMAPPED3006211 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TSIPASSMAPPED300621"));
            TSIPASSMAPPED300621 = TSIPASSMAPPED3006211 + TSIPASSMAPPED300621;



            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            h1.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim()+ "&type=MSMENOOFUNITS";

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyMSMEMAPPEDWITHTSIPASS");
            h2.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMEMAPPEDWITHTSIPASS";

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyMSMENOTMAPPEDWITHTSIPASS");
            h3.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=MSMENOTMAPPEDWITHTSIPASS";

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyTSIPASSUNITS");
            h4.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSUNITS";

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyTSIPASSMAPPEDWITHMSME");
            h5.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPEDWITHMSME";

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyTsipassnotmapped");
            h6.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSNOTMAPPEDWITHMSME";
            HyperLink h7 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED240621");
            h7.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED240621";
            HyperLink h8 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED250621");
            h8.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED250621";
            HyperLink h9 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED260621");
            h9.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED260621";
            HyperLink h10 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED270621");
            h10.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED270621";
            HyperLink h11 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED280621");
            h11.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED280621";
            HyperLink h12 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED290621");
            h12.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED290621";
            HyperLink h13 = (HyperLink)e.Row.FindControl("hypTSIPASSMAPPED300621");
            h13.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&type=TSIPASSMAPPED300621";


            //HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink2");
            //h2.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=AD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink3");
            //h3.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=DD&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();

            //HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink10");
            //h4.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?ROLE=GM&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim();


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

            Label lblTSIPASSMAPPED240621 = new Label();
            lblTSIPASSMAPPED240621.Text = TSIPASSMAPPED240621.ToString();
            e.Row.Cells[8].Text = TSIPASSMAPPED240621.ToString();
            e.Row.Cells[8].Controls.Add(lblTSIPASSMAPPED240621);

            Label lblTSIPASSMAPPED250621 = new Label();
            lblTSIPASSMAPPED250621.Text = TSIPASSMAPPED250621.ToString();
            e.Row.Cells[9].Text = TSIPASSMAPPED250621.ToString();
            e.Row.Cells[9].Controls.Add(lblTSIPASSMAPPED250621);

            Label lblTSIPASSMAPPED260621 = new Label();
            lblTSIPASSMAPPED260621.Text = TSIPASSMAPPED260621.ToString();
            e.Row.Cells[10].Text = TSIPASSMAPPED260621.ToString();
            e.Row.Cells[10].Controls.Add(lblTSIPASSMAPPED260621);

            Label lblTSIPASSMAPPED270621 = new Label();
            lblTSIPASSMAPPED270621.Text = TSIPASSMAPPED270621.ToString();
            e.Row.Cells[11].Text = TSIPASSMAPPED270621.ToString();
            e.Row.Cells[11].Controls.Add(lblTSIPASSMAPPED270621);

            Label lblTSIPASSMAPPED280621 = new Label();
            lblTSIPASSMAPPED280621.Text = TSIPASSMAPPED280621.ToString();
            e.Row.Cells[12].Text = TSIPASSMAPPED280621.ToString();
            e.Row.Cells[12].Controls.Add(lblTSIPASSMAPPED280621);

            Label lblTSIPASSMAPPED290621 = new Label();
            lblTSIPASSMAPPED290621.Text = TSIPASSMAPPED290621.ToString();
            e.Row.Cells[13].Text = TSIPASSMAPPED290621.ToString();
            e.Row.Cells[13].Controls.Add(lblTSIPASSMAPPED290621);


            Label lblTSIPASSMAPPED300621 = new Label();
            lblTSIPASSMAPPED300621.Text = TSIPASSMAPPED300621.ToString();
            e.Row.Cells[14].Text = TSIPASSMAPPED300621.ToString();
            e.Row.Cells[14].Controls.Add(lblTSIPASSMAPPED300621);
 



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


        Dsnew = Gen.GenericFillDs("USP_GET_REPORT_MSMETSIPASSMAPPED", pp);
        return Dsnew;
    }
}