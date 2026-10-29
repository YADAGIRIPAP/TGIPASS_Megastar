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


public partial class UI_TSiPASS_HelpDeskStatusReport : System.Web.UI.Page
{
    #region Declaration
    //General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        if (!IsPostBack)
        {
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
            }
            else
            {
                DateTime fromdate = DateTime.Today;
                txtFromDate.Text = fromdate.ToString("dd-MM-yyyy");
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
            }

            fillgrid();
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //fillgrid();
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
            fillgrid();
        }
        else
        {
            Failure.Visible = true;
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    public void fillgrid()
    {

        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        ds = Gen.GetHelpDeskStatusReport(FromdateforDB, TodateforDB, "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

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


    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsdetails = new DataSet();
        string deptname = "";
        if (e.CommandName.ToString() == "DESCRIPTION")
        {
            deptname = e.CommandArgument.ToString();
            //status = null;
            string FromdateforDB = "", TodateforDB = "";
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            dsdetails = Gen.GetHelpDeskStatusReport(FromdateforDB, TodateforDB, deptname);
            if (dsdetails != null && dsdetails.Tables.Count > 0 && dsdetails.Tables[0].Rows.Count > 0)
            {
                //trdate.Visible = true;
                Trgriddetails.Visible = true;
                griddetails.DataSource = dsdetails.Tables[0];
                griddetails.DataBind();
                div_Print.Visible = false;
            }
            else
            {
                Trgriddetails.Visible = false;
                div_Print.Visible = true;
            }
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
                div_Print.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
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
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportToExcel();
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

                    grdDetails.AllowPaging = false;

                    //this.fillgrid();

                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
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
                    Response.AddHeader("content-disposition", "attachment;filename= R4.2PendencyReport.pdf");
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
}