using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_CentralInspectionPrint : System.Web.UI.Page
{
    General gen = new General();
    string regno = "";
    string deptname = "";
    string year = "";
    string month = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            regno = Request.QueryString[0].ToString();
            deptname = Request.QueryString[1].ToString();
            year = Request.QueryString[2].ToString();
            month = Request.QueryString[3].ToString();

            DataSet ds = new DataSet();
            ds = gen.GetCentralInspectionDetails(deptname, regno, year, month);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblofficename.Text = ds.Tables[0].Rows[0]["inspection_officer_alloted"].ToString();
                lblregno.Text = ds.Tables[0].Rows[0]["registration_no"].ToString();
                lbldate.Text = ds.Tables[0].Rows[0]["InspectionCondutedDate"].ToString();
                lblNameaddress.Text = ds.Tables[0].Rows[0]["name_of_establishment"].ToString();
                lbllicno.Text = ds.Tables[0].Rows[0]["registration_no"].ToString();
                lblemp.Text = ds.Tables[0].Rows[0]["takedar_principalemployer_name"].ToString();
                lbldeptname.Text = ds.Tables[0].Rows[0]["deptname"].ToString();
                lbloffice.Text = ds.Tables[0].Rows[0]["inspection_officer_alloted"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["deptname"].ToString();
                lblinspdt.Text = ds.Tables[0].Rows[0]["inspection_alloted_time"].ToString();
                HyperLink2.NavigateUrl = ds.Tables[0].Rows[0]["link"].ToString();
                HyperLink2.Text = ds.Tables[0].Rows[0]["link"].ToString();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("CentralInspectionSystemReport.aspx");
    }
    #region "btnprint_Click"
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=PaymentReceipt.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriterw = new HtmlTextWriter(stringWriter);
            Receipt.RenderControl(htmlTextWriterw);
            StringReader stringReader = new StringReader(stringWriter.ToString());
            Document pdfDoc = new Document(PageSize.A4, 30f, 25f, 15f, 0.2f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            //iTextSharp.text.Image gifghmc1 = iTextSharp.text.Image.GetInstance(Server.MapPath("images/tsSmalllogo.png"));
            //gifghmc1.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
            //gifghmc1.ScaleToFit(80, 80);
            //gifghmc1.Alignment = iTextSharp.text.Image.UNDERLYING;
            //gifghmc1.SetAbsolutePosition(260, 600);
            //pdfDoc.Add(gifghmc1);
            htmlparser.Parse(stringReader);
            pdfDoc.Close();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    #endregion
}