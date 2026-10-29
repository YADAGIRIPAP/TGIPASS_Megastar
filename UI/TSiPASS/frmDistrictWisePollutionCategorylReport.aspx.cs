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

public partial class UI_TSiPASS_frmDistrictWisePollutionCategorylReport : System.Web.UI.Page
{
    General Gen = new General();
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";

    decimal RED, GREEN, ORANGE, WHITE, TOTALUNITS, TotalEmployeement, TotalInvestment;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            BindDistricts();
            txtFromDate.Text = "01-01-2015";
            DateTime today = DateTime.Today;
            Label1.Text = "Report as on date " + DateTime.Now;
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
            BindFinancialYears(ddlFinancialYear);
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
        dsnew = GetDistrictWisePollutionCategory(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue, ddlFinancialYear.SelectedValue, ddlEnterPriseType.SelectedValue);
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
            decimal RED1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RED"));
            RED = RED1 + RED;

            decimal GREEN1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GREEN"));
            GREEN = GREEN1 + GREEN;

            decimal ORANGE1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ORANGE"));
            ORANGE = ORANGE1 + ORANGE;

            decimal WHITE1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "WHITE"));
            WHITE = WHITE1 + WHITE;

            decimal TOTALUNITS1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTALUNITS"));
            TOTALUNITS = TOTALUNITS1 + TOTALUNITS;

            decimal TotalEmployeement1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalEmployeement"));
            TotalEmployeement = TotalEmployeement1 + TotalEmployeement;

            decimal TotalInvestment1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InvestmentCr"));
            TotalInvestment = TotalInvestment1 + TotalInvestment;
            
            string district = DataBinder.Eval(e.Row.DataItem, "DISTRICTNAME").ToString();

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "R" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "O" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "G" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "W" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            string district;

            if (ddlProp_intDistrictid.SelectedItem.Text == "" || ddlProp_intDistrictid.SelectedItem.Text == null || ddlProp_intDistrictid.SelectedItem.Text == "--Select--" || ddlProp_intDistrictid.SelectedValue == "%" || ddlProp_intDistrictid.SelectedItem.Text == "--ALL--")
            {
                district = "%";
            }
            else
            {
                district = ddlProp_intDistrictid.SelectedItem.Text;
            }
            e.Row.Cells[1].Text = "Total";



            HyperLink REDNEW = new HyperLink();
            REDNEW.ForeColor = System.Drawing.Color.White;
            REDNEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "R" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            REDNEW.Text = RED.ToString();
            e.Row.Cells[2].Text = RED.ToString();
            e.Row.Cells[2].Controls.Add(REDNEW);

            HyperLink GREENNEW = new HyperLink();
            GREENNEW.ForeColor = System.Drawing.Color.White;
            GREENNEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "G" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            GREENNEW.Text = GREEN.ToString();
            e.Row.Cells[3].Text = GREEN.ToString();
            e.Row.Cells[3].Controls.Add(GREENNEW);


            HyperLink ORANGENEW = new HyperLink();
            ORANGENEW.ForeColor = System.Drawing.Color.White;
            ORANGENEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "O" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            ORANGENEW.Text = ORANGE.ToString();

            e.Row.Cells[4].Text = ORANGE.ToString();
            e.Row.Cells[4].Controls.Add(ORANGENEW);


            HyperLink WHITENEW = new HyperLink();
            WHITENEW.ForeColor = System.Drawing.Color.White;
            WHITENEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "W" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            WHITENEW.Text = WHITE.ToString();

            e.Row.Cells[5].Text = WHITE.ToString();
            e.Row.Cells[5].Controls.Add(WHITENEW);


            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
            Total.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            Total.Text = TOTALUNITS.ToString();
            e.Row.Cells[6].Text = TOTALUNITS.ToString();
            e.Row.Cells[6].Controls.Add(Total);

            HyperLink TOTALEMPNEW = new HyperLink();
            TOTALEMPNEW.ForeColor = System.Drawing.Color.White;
            TOTALEMPNEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            TOTALEMPNEW.Text = TotalEmployeement.ToString();
            e.Row.Cells[7].Text = TotalEmployeement.ToString();
            e.Row.Cells[7].Controls.Add(TOTALEMPNEW);


            HyperLink TOTALINVNEW = new HyperLink();
            TOTALINVNEW.ForeColor = System.Drawing.Color.White;
            TOTALINVNEW.NavigateUrl = "frmDistrictWisePollutionCategorylReportDrillDown.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&ddlpolcategory=" + "T" + "&district=" + district + "&Enttype=" + ddlEnterPriseType.SelectedValue;
            TOTALINVNEW.Text = TotalInvestment.ToString();
            e.Row.Cells[8].Text = TotalInvestment.ToString();
            e.Row.Cells[8].Controls.Add(TOTALINVNEW);



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
                    Response.AddHeader("content-disposition", "attachment;filename= DistrWisePollutnCatReport.pdf");
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

    public DataSet GetDistrictWisePollutionCategory(string fromdate, string todate, string districtid, string financialcd, string EntType)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
               new SqlParameter("@FinancialYearCd",SqlDbType.VarChar),
                              new SqlParameter("@EntType",SqlDbType.VarChar)


           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = districtid;
        pp[3].Value = financialcd;
        pp[4].Value = EntType;


        Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_POLLUTIONCATEGORY", pp);
        return Dsnew;
    }

    public void BindFinancialYears(DropDownList ddlFinYear)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = Gen.GetFinancialYearsForReports();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlFinYear.DataSource = dsd.Tables[0];
                ddlFinYear.DataValueField = "SlNo";
                ddlFinYear.DataTextField = "FinancialYear";
                ddlFinYear.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlFinYear.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
}