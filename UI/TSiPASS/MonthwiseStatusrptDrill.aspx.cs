using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_MonthwiseStatusrptDrill : System.Web.UI.Page
{

    General Gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblHeading.Text = "Month wise Applications";
        string year = Request.QueryString["year"].ToString();
        string month = Request.QueryString["month"].ToString();
        string status = Request.QueryString["status"].ToString();
        string msg = "";

        if (status.ToUpper() == "A" || status.ToUpper() == "B") { msg = "Month wise Applications Received"; }
        if (status.ToUpper() == "C" || status.ToUpper() == "D") { msg = "Month wise Applications Approvals are Given"; }
        if (status.ToUpper() == "E") { msg = "Month wise Applications Pending"; }
        if (status.ToUpper() == "F") { msg = "Month wise Applications Rejected"; }
        if (status.ToUpper() == "G" || status.ToUpper() == "H"|| status.ToUpper() == "I" || status.ToUpper() == "J") { msg = "Month wise Applications Status"; }
        lblHeading.Text = msg;


        if (!IsPostBack)
        {
            
            ddlFinancialYear.SelectedValue = year;
            ddlMonth.SelectedValue = month;
            FillGridDetails(year,month,status);
        }
        lblMsg.Text = "";

    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        string year = ddlFinancialYear.SelectedValue;
        string month = ddlMonth.SelectedValue;
        string status = Request.QueryString["status"].ToString();
        if (year != "0" && month != "0")
        {
            FillGridDetails(year, month, status);
            lblMsg.Text = "";
        }
        else
        {
            lblMsg.Text = "";
            if (year == "0")
            {
                lblMsg.Text = "Please Select Year <br/>";
            }
            if (month == "0")
            {
                lblMsg.Text += "Please Select Month <br/>";
            }
        }
    }


    public void FillGridDetails(string year,string month,string status)
    {
        try
        {
            DataSet ds = new DataSet();

            Label1.Text = "Report from year " + year+ " and month " +ddlMonth.SelectedItem.Text;

            ds = GetMonthwiseStatusrptDrill(year, month, status);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
               // Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch(Exception ex)
        {
            
        }
        


    }

    public DataSet GetMonthwiseStatusrptDrill(string year, string month, string status)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try 
        {
            da = new SqlDataAdapter("USP_MONTHWISE_RPT_R15_CFE_DRILL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            da.SelectCommand.Parameters.Add("@YEAR", SqlDbType.Int).Value = Convert.ToInt32(year);
            da.SelectCommand.Parameters.Add("@MONTH", SqlDbType.Int).Value = Convert.ToInt32(month);
            da.SelectCommand.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = status;

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{

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
                    Response.AddHeader("content-disposition", "attachment;filename= R2-1-STATUS-OF-PRESCRUTINY-DEPARTMENT-WISE.pdf");
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


}