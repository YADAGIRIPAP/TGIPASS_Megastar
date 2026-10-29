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

public partial class UI_TSiPASS_comReportDrill_drilldownTotal_aspx : System.Web.UI.Page
{
    string codes, dists;
    string FromdateforDB = "", TodateforDB = "", fromdate = "", todate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            codes = Request.QueryString["Code"].ToString();


            if (codes == "CFE PENDENCY BEYOND" || codes == "CFO PENDENCY BEYOND" || codes == "RAW MATERIALS PENDENCY" || codes == "RENEWALS PENDENCY" || codes == "NOT ASSIGNED BY GM" || codes == "INCENTIVE GM RECOMMEND PENDENCY" || codes == "INSPECTION DATE NOT ASSIGNED" || codes == "INSPECTION REPORT NOT UPLOADED" || codes == "QUERY NOT REPORTED BEYOND 30 DAYS" || codes == "REPORT NOT SUBMITTED" || codes == "REPORT SUBMITTED" || codes == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || codes == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || codes == "MSME CATALOGUE DETAILS UPLOADED" || codes == "INITIAL STAGE" || codes == "Yet to Start Construction" || codes == "ADVANCED STAGE")
            {
                dists = Request.QueryString["Dist"].ToString();
            }
            else
            {
                dists = "";
            }




            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {


                fromdate = Request.QueryString["fromdate"].ToString().Trim();
                todate = Request.QueryString["todate"].ToString().Trim();

                //FromdateforDB = Convert.ToString(DateTime.ParseExact(fromdate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                //TodateforDB = Convert.ToString(DateTime.ParseExact(todate, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

                FromdateforDB = fromdate;
                TodateforDB = todate;


                getdetails();
                lblheadingtext.Text = codes;
                lbldists.Text = dists;
                //   Label1.Text = "Report as on date " + DateTime.Now;


            }

        }

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    private void getdetails()
    {
        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("USP_GET_COI_DASHBOARD_ALL_DRILLDOWNTOTAL", osqlConnection);
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        oSqlDataAdapter.SelectCommand.Parameters.Add("@CODE", SqlDbType.VarChar).Value = codes.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@DIST", SqlDbType.VarChar).Value = dists.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB.ToString();
        oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB.ToString();
        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        ExportGridToExcel();
    }
    private void ExportGridToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "Vithal" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        grdDetails.GridLines = GridLines.Both;
        grdDetails.HeaderStyle.Font.Bold = true;
        grdDetails.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnbdf_Click(object sender, EventArgs e)
    {
    }
}