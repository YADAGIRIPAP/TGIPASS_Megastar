using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class UI_TSiPASS_frmDistrictReportEnterpriseTypeDrillDown : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        
        if (!IsPostBack)
        {
            string fromdate = "", Todate = "";
            
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
               // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + DateTime.Now;
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
            }
            else
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
                        FillDetails();
            HyperLink1.NavigateUrl = "frmDistrictReportEnterpriseType.aspx?status=A&lbl=Application Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

        }
    }
    private void ClearFields()
    {
        Label1.Text = "";
        txtFromDate.Text = "";
        txtTodate.Text = "";
        
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
       
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
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
        }
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }

    void FillDetails()
    {

        DataSet ds = new DataSet();
        string input, financial, fromdate, todate;
        string status = Request.QueryString[1].ToString().Trim();
        string type = Request.QueryString[0].ToString().Trim();
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }


        string district = Request.QueryString["district"].ToString().Trim();
        string polcategory = Request.QueryString["polcategory"].ToString().Trim();

        ds = GetDistrictWisePollutionApplicationsDrill(FromdateforDB, TodateforDB, district, polcategory);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           
            string fromdt = "", Todt = "";

            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
           
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    



    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

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
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

           

        }
    }



    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        
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
            FillDetails();
        }
        else
        {
            Failure.Visible = true;
        }
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

                string status = Request.QueryString[0].ToString().Trim();
                string type = Request.QueryString[1].ToString().Trim();
                DataSet ds = new DataSet();
                string input, financial, fromdate, todate;
                string FromdateforDB = "", TodateforDB = "";
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }


                string district = Request.QueryString["district"].ToString().Trim();
                string polcategory = Request.QueryString["polcategory"].ToString().Trim();

                ds = GetDistrictWisePollutionApplicationsDrill(FromdateforDB, TodateforDB, district, polcategory);
                
                grdExport.DataSource = ds.Tables[0];
                grdExport.DataBind();

                grdExport.RenderControl(hw);

                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
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

    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PrintPdf();
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
                    Response.AddHeader("content-disposition", "attachment;filename= IndustryCatelog.pdf");
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

    public DataSet GetDistrictWisePollutionApplicationsDrill(string fromdate, string todate, string district, string sector)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FromDate",SqlDbType.VarChar),
                new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DISTRICTID",SqlDbType.VarChar),
              // new SqlParameter("@FinancialYearCd",SqlDbType.VarChar),
               new SqlParameter("@ENTERPRISETYPE",SqlDbType.VarChar)

           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = district;
        //pp[3].Value = financialyear;
        pp[3].Value = sector;

        Dsnew = Gen.GenericFillDs("USP_GET_DISTRICTREPORT_ENTERPRISETYPE_DRILLDOWN", pp);
        return Dsnew;
    }

}