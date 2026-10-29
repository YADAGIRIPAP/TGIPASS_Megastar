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

public partial class UI_TSIPASS_frmIncentiveProceedingabstractDrilldown : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string status = Request.QueryString[0].ToString().Trim();
            string Dist = Request.QueryString[1].ToString().Trim();
            string caste = Request.QueryString[2].ToString().Trim();
            string txtFromDate = "", txtTodate = "";
            
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                 txtFromDate = Request.QueryString["fromdate"].ToString().Trim();
                 txtTodate = Request.QueryString["todate"].ToString().Trim();
                 //Label1.Text = "Report from " + txtFromDate.Trim() + " To " + txtTodate.Trim();
                 Label1.Text = "Report from " + txtFromDate.Trim() + " To " + DateTime.Now;
            }
            else
                Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            string FromdateforDB = "", TodateforDB = "";
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

            ds = GetAbstractdrill(Dist, FromdateforDB, TodateforDB, status, caste);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

            if (status == "A")
            {
                lblHeading.Text = "No of Units for which release proceedings are issued (DLC)";
            }
            else if (status == "B")
            {
                lblHeading.Text = "No of Units for which release proceedings are issued (SLC)";
            }
            else if (status == "C")
            {
                lblHeading.Text = "Total No. of Units for which release proceedings are issued (DLC & SLC)";
            }
            if (status == "D")
            {
                lblHeading.Text = "UC Updated - Working Units(DLC) ";
            }
            else if (status == "E")
            {
                lblHeading.Text = "UC Updated - Working Units(SLC)";
            }
            else if (status == "F")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Working Units(DLC & SLC)";
            }
            if (status == "G")
            {
                lblHeading.Text = "UC Updated - Closed Units(DLC) ";
            }
            else if (status == "H")
            {
                lblHeading.Text = "UC Updated - Closed Units(SLC)";
            }
            else if (status == "I")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Closed Units(DLC & SLC)";
            }
            else if (status == "M")
            {
                lblHeading.Text = "UC Updated - Abeyanced Units(DLC) ";
            }
            else if (status == "N")
            {
                lblHeading.Text = "UC Updated - Abeyanced Units(SLC)";
            }
            else if (status == "O")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Abeyanced Units(DLC & SLC)";
            }
            if (status == "j")
            {
                lblHeading.Text = "UC Not Updated Units(DLC) ";
            }
            else if (status == "K")
            {
                lblHeading.Text = "UC Not Updated Units(SLC)";
            }
            else if (status == "L")
            {
                lblHeading.Text = "Total No. of Units for which UC Not Updated Units(DLC & SLC)";
            }
            else if (status == "P")
            {
                lblHeading.Text = "UC Updated - Closed Units but worked for stipulated period (DLC) ";
            }
            else if (status == "Q")
            {
                lblHeading.Text = "UC Updated - Closed Units but worked for stipulated period (SLC)";
            }
            else if (status == "R")
            {
                lblHeading.Text = "Total No. of Units for which UC Updated - Closed Units but worked for stipulated period (DLC & SLC)";
            }
            // HyperLink1.NavigateUrl = "frmR1ReportKMRNew.aspx?status=" + "" + "&lbl=Total Applications Received&fromdate=" + txtFromDate + "&todate=" + txtTodate;
        }
    }

    public DataSet GetAbstractdrill(string Distid, string fromdate, string Todate, string Status, string Caste)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DISTRICTCD",SqlDbType.VarChar),
               new SqlParameter("@Fromdate",SqlDbType.VarChar),
               new SqlParameter("@Todate",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Cast",SqlDbType.VarChar)
           };
        pp[0].Value = Distid;
        pp[1].Value = fromdate;
        pp[2].Value = Todate;
        pp[3].Value = Status;
        pp[4].Value = Caste;
        Dsnew = Gen.GenericFillDs("USP_GET_ABSTRACT_INCENTIVEPROCEEDINGS_DRILL", pp);
        return Dsnew;
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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        PrintPdf1();
    }

    protected void PrintPdf1()
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
                    Response.AddHeader("content-disposition", "attachment;filename= IncentivesClaim.pdf");
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
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
       // ExportToExcel();

    }
}