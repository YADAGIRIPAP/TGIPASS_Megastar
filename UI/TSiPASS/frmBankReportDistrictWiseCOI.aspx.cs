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

public partial class UI_TSiPASS_frmBankReportDistrictWiseCOI : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal Nounits, IncipientSick, Sick, WillfulDefaulters, TEVStudyDone, Restructuringundertaken, SARFAESI, AccountClosed, Nounitsreg, NounitsUpdated;
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
           // Label1.Text = "Report from " + txtFromDate.Text + " to " + txtTodate.Text;
            Label1.Text = "Report from " + txtFromDate.Text + " to " + DateTime.Now;

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
        dsnew = GetBankerApplications(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
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
            decimal Nounitsreg1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFBANKS"));
            Nounitsreg = Nounitsreg1 + Nounitsreg;

            decimal Nounits1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "No Units"));
            Nounits = Nounits1 + Nounits;

            decimal nounitstotalupdated1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NOOFUPDATED"));
            NounitsUpdated = nounitstotalupdated1 + NounitsUpdated;

            decimal IncipientSick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Incipient Sick"));
            IncipientSick = IncipientSick1 + IncipientSick;

            decimal Sick1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Sick"));
            Sick = Sick1 + Sick;

            decimal WillfulDefaulters1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Willful Defaulters"));
            WillfulDefaulters = WillfulDefaulters1 + WillfulDefaulters;

            decimal TEVStudyDone1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TEV Study Done"));
            TEVStudyDone = TEVStudyDone1 + TEVStudyDone;

            decimal Restructuringundertaken1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Restructuring under taken"));
            Restructuringundertaken = Restructuringundertaken1 + Restructuringundertaken;

            decimal SARFAESI1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SARFAESI"));
            SARFAESI = SARFAESI1 + SARFAESI;

            decimal AccountClosed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Account Closed"));
            AccountClosed = AccountClosed1 + AccountClosed;


            HyperLink h1reg = (HyperLink)e.Row.FindControl("HyNoofbanksregistered");
            h1reg.NavigateUrl = "frmBankRegistrationDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim(); // ddlProp_intDistrictid.SelectedValue;


            HyperLink hupdated = (HyperLink)e.Row.FindControl("HyNoofUpdatedData");
            hupdated.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=%&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h1 = (HyperLink)e.Row.FindControl("HyNoofClaimsFiled");
            h1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink2");
            h2.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink3");
            h3.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink10");
            h4.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink5");
            h5.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink6");
            h6.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink11");
            h7.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";

            HyperLink nounitstotalreg = new HyperLink();
            nounitstotalreg.Text = Nounitsreg.ToString();
            e.Row.Cells[2].Text = Nounitsreg.ToString();
            e.Row.Cells[2].Controls.Add(nounitstotalreg);
            nounitstotalreg.ForeColor = System.Drawing.Color.White;
            nounitstotalreg.NavigateUrl = "frmBankRegistrationDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=ALL"; // ddlProp_intDistrictid.SelectedValue;

            Label nounitstotal = new Label();
            nounitstotal.Text = Nounits.ToString();
            e.Row.Cells[3].Text = Nounits.ToString();
            e.Row.Cells[3].Controls.Add(nounitstotal);


            HyperLink nounitstotalupdated = new HyperLink();
            nounitstotalupdated.Text = NounitsUpdated.ToString();
            e.Row.Cells[4].Text = NounitsUpdated.ToString();
            e.Row.Cells[4].Controls.Add(nounitstotalupdated);
            nounitstotalupdated.ForeColor = System.Drawing.Color.White;
            nounitstotalupdated.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=%&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink IncipientSicktotal = new HyperLink();
            IncipientSicktotal.Text = IncipientSick.ToString();
            e.Row.Cells[5].Text = IncipientSick.ToString();
            e.Row.Cells[5].Controls.Add(IncipientSicktotal);
            IncipientSicktotal.ForeColor = System.Drawing.Color.White;
            IncipientSicktotal.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;
            //Label Claims = new Label();
            //Claims.Text = NoOfClaims.ToString();
            //e.Row.Cells[2].Text = NoOfClaims.ToString();
            //e.Row.Cells[2].Controls.Add(Claims);


            HyperLink Sick1 = new HyperLink();
            Sick1.Text = Sick.ToString();
            e.Row.Cells[6].Text = Sick.ToString();
            e.Row.Cells[6].Controls.Add(Sick1);
            Sick1.ForeColor = System.Drawing.Color.White;
            Sick1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink WillfulDefaulters1 = new HyperLink();
            WillfulDefaulters1.Text = WillfulDefaulters.ToString();
            e.Row.Cells[7].Text = WillfulDefaulters.ToString();
            e.Row.Cells[7].Controls.Add(WillfulDefaulters1);
            WillfulDefaulters1.ForeColor = System.Drawing.Color.White;
            WillfulDefaulters1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink TEVStudyDone1 = new HyperLink();
            TEVStudyDone1.Text = TEVStudyDone.ToString();
            e.Row.Cells[8].Text = TEVStudyDone.ToString();
            e.Row.Cells[8].Controls.Add(TEVStudyDone1);
            TEVStudyDone1.ForeColor = System.Drawing.Color.White;
            TEVStudyDone1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;


            HyperLink Restructuringundertaken1 = new HyperLink();
            Restructuringundertaken1.Text = Restructuringundertaken.ToString();
            e.Row.Cells[9].Text = Restructuringundertaken.ToString();
            e.Row.Cells[9].Controls.Add(Restructuringundertaken1);
            Restructuringundertaken1.ForeColor = System.Drawing.Color.White;
            Restructuringundertaken1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;


            HyperLink SARFAESI1 = new HyperLink();
            SARFAESI1.Text = SARFAESI.ToString();
            e.Row.Cells[10].Text = SARFAESI.ToString();
            e.Row.Cells[10].Controls.Add(SARFAESI1);
            SARFAESI1.ForeColor = System.Drawing.Color.White;
            SARFAESI1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink AccountClosed1 = new HyperLink();
            AccountClosed1.Text = AccountClosed.ToString();
            e.Row.Cells[11].Text = AccountClosed.ToString();
            e.Row.Cells[11].Controls.Add(AccountClosed1);
            AccountClosed1.ForeColor = System.Drawing.Color.White;
            AccountClosed1.NavigateUrl = "frmBankReportDistrictWiseCOIDrillDown.aspx?type=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Bank Name")).Trim() + "&bankname=" + ddlProp_intDistrictid.SelectedValue;


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

    public DataSet GetBankerApplications(string fromdate, string todate, string districtid)
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


        Dsnew = Gen.GenericFillDs("USP_GET_BANKERREPORT_DISTRICT_COI", pp);
        return Dsnew;
    }
}