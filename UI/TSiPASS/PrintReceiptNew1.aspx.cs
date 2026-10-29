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

public partial class InterfaceNetBanking_PrintReceipt : System.Web.UI.Page
{
    #region "Global Variables"
    //PaymentDetailsBL objBL = new PaymentDetailsBL();
    //PaymentDetailsBE objBE = new PaymentDetailsBE();
    DataSet ds = new DataSet();
    string constring = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    public string sEmail;
    //SMsHttpPostClient objSms = new SMsHttpPostClient();
    //static String username = "cgg-tipass";
    //static String password = "tip@$$@2016";
    //static String senderid = "TiPASS";

    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";
    #endregion    
    #region "Page_Load"
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        filldetails(); 
    }
    #endregion

 void filldetails()
{
    DataSet ds = new DataSet();
    ds= gen.getAcknowledgeRawmaterial(Request.QueryString[0].ToString());
    lblPaidat.Text = ds.Tables[0].Rows[0]["EMNoUdyogAadhaar"].ToString();
     txtrcptno.Text = ds.Tables[0].Rows[0]["TypeofApplication"].ToString();
     txtname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
     lblMobileNumber.Text = ds.Tables[0].Rows[0]["District"].ToString();
     txttotal.Text = ds.Tables[0].Rows[0]["Mandal"].ToString();
     txtasmtno.Text = ds.Tables[0].Rows[0]["Address"].ToString();
     txtrcptdt.Text = ds.Tables[0].Rows[0]["RawMatAllot"].ToString();
     txtaddress.Text = ds.Tables[0].Rows[0]["Requirement"].ToString();
     txtEmailId.Text = ds.Tables[0].Rows[0]["Usagedetails"].ToString();
   
    //lblCategory.Text = dt.Rows[0]["Category"].ToString();

}
   
    #region "btnprint_Click"
    protected void btnprint_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=RawMaterialReceipt.pdf");
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
        catch
        {

        }
    }
    #endregion
  
    
 
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
}
