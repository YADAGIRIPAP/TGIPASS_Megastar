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

public partial class UI_TSiPASS_FrmCommissionerReportDrillDown : System.Web.UI.Page
{
    decimal NumberTotal, InvestmnetTotal, EmploymentTotal;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //getdistricts();
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");

            }
            BindDistricts();
            BindSector(ddlsector);
            BindFinancialYears(ddlFinYear);
            if (Request.QueryString["ddlFinYear"] != null && Request.QueryString["ddlFinYear"] != "")
            {
                ddlFinYear.SelectedIndex = ddlFinYear.Items.IndexOf(ddlFinYear.Items.FindByValue(Request.QueryString["ddlFinYear"].ToString().Trim()));
            }
            if (Request.QueryString["ddlProp_intDistrictid"] != null && Request.QueryString["ddlProp_intDistrictid"].ToString() != "")
            {
                //ddlProp_intDistrictid.Items.FindByValue(Request.QueryString["ddlProp_intDistrictid"].ToString().Trim()).Selected = true;
                //ddlProp_intDistrictid.SelectedItem.Text = ddlProp_intDistrictid.Items.FindByText(Request.QueryString["ddlProp_intDistrictid"].ToString().Trim()).Text;


                //ddlProp_intDistrictid.SelectedItem.Text = ddlProp_intDistrictid.Items.Cast<System.Web.UI.WebControls.ListItem>().FirstOrDefault(x => x.Text.ToLower().Contains(Request.QueryString["ddlProp_intDistrictid"].ToString().Trim())).Text;


            }
            if (Request.QueryString["ddlsector"] != null && Request.QueryString["ddlsector"].ToString() != "")
            {
                ddlsector.SelectedValue = Request.QueryString["ddlsector"].ToString();
            }
            if (Request.QueryString["ddlEnterPriseType"] != null && Request.QueryString["ddlEnterPriseType"].ToString() != "")
            {
                ddlEnterPriseType.SelectedValue = Request.QueryString["ddlEnterPriseType"].ToString();
            }
            if (Request.QueryString["ddlcolor"] != null && Request.QueryString["ddlcolor"].ToString() != "")
            {
                ddlcolor.SelectedValue = Request.QueryString["ddlcolor"].ToString();
            }
            if (Request.QueryString["ddlinsutrytype"] != null && Request.QueryString["ddlinsutrytype"].ToString() != "")
            {
                ddlSector_Ent.SelectedValue = Request.QueryString["ddlinsutrytype"].ToString();
            }
            if (Request.QueryString["ddlStatus"] != null && Request.QueryString["ddlStatus"].ToString() != "")
            {
                ddlStatus.SelectedValue = Request.QueryString["ddlStatus"].ToString();
            }
            if (Request.QueryString["ddlEligibility"] != null && Request.QueryString["ddlEligibility"].ToString() != "")
            {
                ddlEligibility.SelectedValue = Request.QueryString["ddlEligibility"].ToString();
            }

            if (Request.QueryString["ddlincentiveapplied"] != null && Request.QueryString["ddlincentiveapplied"].ToString() != "")
            {
                ddlincentiveapplied.SelectedValue = Request.QueryString["ddlincentiveapplied"].ToString();
            }

            //dsnew = Gen.FetchTotalDistrictwise_New_NewCommissioner(ddlFinYear.SelectedValue, ddlProp_intDistrictid.SelectedItem.Text, ddlsector.SelectedValue, ddlEnterPriseType.SelectedValue, ddlcolor.SelectedValue);
            fillgrid();
        }
    }
    #endregion

    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddlConnectLoad.DataSource = dsnew.Tables[0];
    //    ddlConnectLoad.DataTextField = "District_Name";
    //    ddlConnectLoad.DataValueField = "District_Name";
    //    ddlConnectLoad.DataBind();
    //    ddlConnectLoad.Items.Insert(0, "--Select--");
    //}
    public void fillgrid()
    {

        string FromdateforDB = "", TodateforDB = "";
        //if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        //{
        //    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        //}

        DataSet dsnew = new DataSet();

        dsnew = FetchTotalDistrictwise_New_NewCommissionerDrillDown(ddlFinYear.SelectedValue, Request.QueryString["ddlProp_intDistrictid"].ToString(), ddlsector.SelectedItem.Text, ddlEnterPriseType.SelectedValue, ddlcolor.SelectedValue, ddlSector_Ent.SelectedValue, ddlStatus.SelectedValue, ddlEligibility.SelectedValue, ddlincentiveapplied.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

            //if (ddlType.SelectedValue == "3")
            //{
            //    Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            //}
            //else
            //{
            //    if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
            //        Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            //    else
            //        Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            //}
            //if (Request.QueryString[2].ToString().Trim() == "%")
            //{
            //    lblHeader.Text = "R6.1: TSiPASS- District Wise Report";
            //}
            //else
            //{
            //    lblHeader.Text = "R6.1: TSiPASS- District Wise Report - " + Request.QueryString[2].ToString().Trim();
            //}
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }


    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Right;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            //decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number"));
            //NumberTotal = NumberTotal1 + NumberTotal;

            decimal InvestmnetTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Investment"));
            InvestmnetTotal = InvestmnetTotal1 + InvestmnetTotal;


            decimal EmploymentTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NUMBER OF EMPLOYEES"));
            EmploymentTotal = EmploymentTotal1 + EmploymentTotal;





        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[4].Text = "Total";
            //  e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[5].Text = InvestmnetTotal.ToString();
            e.Row.Cells[6].Text = EmploymentTotal.ToString();

        }
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;

                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";

                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        fillgrid();
    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    { }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ExportToExcel()
    {
        try
        {

            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeader.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                divPrint1.RenderControl(hw);

                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeader.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    //protected void PrintPdf()
    //{
    //    try
    //    {
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //            {
    //                //To Export all pages
    //                //trLogo.Visible = true;
    //                grdDetails.AllowPaging = false;
    //                this.fillgrid();
    //                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.RenderControl(hw);
    //                StringReader sr = new StringReader(sw.ToString());
    //                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
    //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                pdfDoc.Open();
    //                htmlparser.Parse(sr);
    //                pdfDoc.Close();

    //                Response.ContentType = "application/pdf";
    //                string FileName = lblHeader.Text;
    //                FileName = FileName.Replace(" ", "");
    //                Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                Response.Write(pdfDoc);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}
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
                    grdDetails.AllowPaging = false;
                    // this.fillgrid();
                    //grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    string FileName = lblHeader.Text;
                    FileName = FileName.Replace(" ", "");
                    Response.AddHeader("content-disposition", "attachment;filename=  " + FileName + ".pdf");
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;

        if (valid == 0)
        {
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
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
                ddlProp_intDistrictid.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void BindSector(DropDownList ddlsector)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlFinYear.Items.Clear();
            dsd = Gen.GetTypeofSector();
            //ListItem ITEM=new ListItem
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlsector.DataSource = dsd.Tables[0];
                ddlsector.DataValueField = "SectorName";
                ddlsector.DataTextField = "SectorName";
                ddlsector.DataBind();
                //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
                //{
                //    AddAll(ddlFinYear);
                //}
            }


            ddlsector.Items.Insert(0, "--Select--");

        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public DataSet FetchTotalDistrictwise_New_NewCommissionerDrillDown(string FINYEAR, string DISTRICT, string SECTOR, string CATEGORY, string COLOR, string TYPEOFSECTOR, string Progress, string INCENTIVEEligibility,string incentivesapplied)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FINYEAR",SqlDbType.VarChar),
                new SqlParameter("@DISTRICT",SqlDbType.VarChar),
               new SqlParameter("@SECTOR",SqlDbType.VarChar),
               new SqlParameter("@CATEGORY",SqlDbType.VarChar),
               new SqlParameter("@COLOR",SqlDbType.VarChar),
               new SqlParameter("@TYPEOFSECTOR",SqlDbType.VarChar),
               new SqlParameter("@Progress",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEEligibility",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEAPPLIEDFLAG",SqlDbType.VarChar)

           };
        pp[0].Value = FINYEAR;
        pp[1].Value = DISTRICT;
        pp[2].Value = SECTOR;
        pp[3].Value = CATEGORY;//micro
        pp[4].Value = COLOR;
        pp[5].Value = TYPEOFSECTOR;
        pp[6].Value = Progress;
        pp[7].Value = INCENTIVEEligibility;
        pp[8].Value = incentivesapplied;

        //Dsnew = Gen.GenericFillDs("USP_GET_COMMISSIONER_REPORT_DRILLDOWN", pp);
        Dsnew = Gen.GenericFillDs("USP_GET_COMMISSIONER_REPORT_DRILLDOWN_COINEW", pp);
        
        return Dsnew;
    }

}