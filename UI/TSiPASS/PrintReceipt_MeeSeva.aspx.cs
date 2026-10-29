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
using BusinessLogic;


public partial class InterfaceNetBanking_PrintReceipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["EntprIncentive"] != null)
            {
                Fetch obj = new Fetch();
                DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID(Session["EntprIncentive"].ToString());
                lblEmNo.Text = dt.Rows[0]["EMiUdyogAadhar"].ToString();
                lblUnitName.Text = dt.Rows[0]["UnitName"].ToString();
                lblApplicantname.Text = dt.Rows[0]["ApplciantName"].ToString();
                lblGender.Text = dt.Rows[0]["Gender"].ToString();
                lblCaste.Text = dt.Rows[0]["Caste"].ToString();
                lblDateofissue.Text=dt.Rows[0]["DateOfApplication"].ToString();
                lblMobileNumber.Text = dt.Rows[0]["MobileNo"].ToString();
                lblEmailId.Text = dt.Rows[0]["EmailID"].ToString();
                lblCategory.Text = dt.Rows[0]["Category"].ToString();
                lblLandValue.Text = dt.Rows[0]["Landvalue"].ToString();
                lblPlantValue.Text = dt.Rows[0]["PlantMachineryValue"].ToString();
                lblBuldingValue.Text = dt.Rows[0]["BuildingValue"].ToString();
                lblEuipmentvalue.Text = dt.Rows[0]["EquipmentValue"].ToString();
                lblSector.Text = dt.Rows[0]["sector"].ToString();
                lblMeeSevaTransacNo.Text = dt.Rows[0]["MeeSevaTransactionNo"].ToString();
                lblTsiPassTransacNo.Text = dt.Rows[0]["IncentiveId"].ToString();
            }
        }
        catch (Exception ex) { Errors.ErrorLog(ex); }
    }
    
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
    #region "btnprint_Click"
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=MeeSevasPaymentReceipt.pdf");
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
            Errors.ErrorLog(ex);
        }
    }
    #endregion
    #region "VerifyRenderingInServerForm"
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    #endregion
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
}
