using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data;
using System.IO;
using iTextSharp.text.html;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_Waltform16A : System.Web.UI.Page
{
    string Applicantid = "";
    string downloadfilename = "Form16A";
    Cls_DrillingRigs obj = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0] != null)
                {
                    if (!IsPostBack)
                    {
                        Applicantid = Convert.ToString(Request.QueryString[0]);
                        DataSet ds = obj.Form16_DrillingRigs(Convert.ToInt32(Applicantid));
                        if(ds!=null)
                        {
                            if(ds.Tables[0].Rows.Count>0)
                            {
                                lbl_applicationtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["Applicationtype"]);
                                lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameoftheapplicant"]);
                                lbl_RTODistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["RTODistrictName"]);


                                lbl_Registrationvehiclenumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["regvehicleno"]);
                                lbl_nameofapplicant.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameoftheapplicant"]);
                                //lbl_address.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddDistrictName"]) + "," + Convert.ToString(ds.Tables[0].Rows[0]["AddMandalname"])
                                //    + "," + Convert.ToString(ds.Tables[0].Rows[0]["AddVillagename"]) + "," + Convert.ToString(ds.Tables[0].Rows[0]["Houseno"]) + "," +
                                //     Convert.ToString(ds.Tables[0].Rows[0]["Street"]);
                                lbl_address.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddressApplicant"]);
                                
                                lbl_validitydate.Text = Convert.ToString(DateTime.Now.AddYears(2));
                                lbl_currentdate.Text = Convert.ToString(DateTime.Now);
                             
                            }
                        }
                    }

                }
            }


        }
        catch (Exception ex)
        {
            
        }
    }


    protected void btn_pdf_Click(object sender, EventArgs e)
    {
       ExportToPDF();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //div_panel.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter stringWriter = new StringWriter();
        //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        //employeelistDiv.RenderControl(htmlTextWriter);
        //StringReader stringReader = new StringReader(stringWriter.ToString());
        //Document Doc = new Document(PageSize.A4, 10 f, 10 f, 100 f, 0 f);
        //HTMLWorker htmlparser = new HTMLWorker(Doc);
        //PdfWriter.GetInstance(Doc, Response.OutputStream);
        //Doc.Open();
        //htmlparser.Parse(stringReader);
        //Doc.Close();
        //Response.Write(Doc);
        //Response.End();



    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void lnk_excel_Click(object sender, EventArgs e)
    {
        Excel_Export();
    }
    protected void lnk_pdf_Click(object sender, EventArgs e)
    {
      
    }
    protected void ExportToPDF()
    {
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {

                //To Export all pages
                employeelistDiv.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + downloadfilename + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
    private void Excel_Export()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", downloadfilename + ".xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        employeelistDiv.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }


}