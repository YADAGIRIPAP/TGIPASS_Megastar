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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch

public partial class UI_TSiPASS_FrmDistDrilldownold2NewWithoutDuplicate : System.Web.UI.Page
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
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            }
            if (Request.QueryString["status"] != null && Request.QueryString["status"].ToString() != "" && Request.QueryString["status"].ToString() != "--Select--")
            {
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByValue(Request.QueryString["status"].ToString().Trim()));
            }
            if (Request.QueryString["Enttype"] != null && Request.QueryString["Enttype"].ToString() != "" && Request.QueryString["Enttype"].ToString() != "0")
            {
                ddlEnterPriseType.SelectedValue = Request.QueryString["Enttype"].ToString();
            }
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
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        DataSet dsnew = new DataSet();
        if (FromdateforDB != "")
            dsnew = Gen.FetchDistrictwiseDrildownNewWithoutDuplicate(ddlType.SelectedValue, Request.QueryString[2].ToString().Trim(), FromdateforDB, TodateforDB, ddlEnterPriseType.SelectedValue);
        else
        {
            dsnew = Gen.FetchDistrictwiseDrildownNewWithoutDuplicate(ddlType.SelectedValue, Request.QueryString[2].ToString().Trim(), FromdateforDB, TodateforDB, ddlEnterPriseType.SelectedValue);
        }

        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();

            grdDetails.DataSource = dsnew.Tables[0];
            grdDetails.DataBind();

            if (ddlType.SelectedValue == "3")
            {
                Label1.Text = "Report from 01-April-2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            }
            else
            {
                if (txtFromDate.Text.Trim() != "" && txtTodate.Text.Trim() != "")
                    Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
                else
                    Label1.Text = "Report from 01-Jan-2015 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            }
            if (Request.QueryString[2].ToString().Trim() == "%")
            {
                lblHeader.Text = "R6.1: TSiPASS- District Wise Report";
            }
            else
            {
                lblHeader.Text = "R6.1: TSiPASS- District Wise Report - " + Request.QueryString[2].ToString().Trim();
            }
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
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue != "--Select--")
        {
            tdFromDate.Visible = false;
            tdToDate.Visible = false;
            txtFromDate.Text = "";
            txtTodate.Text = "";
        }
        else
        {
            tdFromDate.Visible = true;
            tdToDate.Visible = true;
            txtFromDate.Text = "";
            txtTodate.Text = "";
        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        if (ddlType.SelectedValue == "--Select--")//!= "3" && ddlType.SelectedValue == "1")
        {
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
        }
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
}