using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class UI_TSiPASS_UserGroundwaterPaymentDetails : System.Web.UI.Page
{
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString.Count>0)
        {
            if (Request.QueryString[0].ToString() != "")
            {
                DataSet dsnew = obj_dashboard.BindUserPaymentReceipt(Request.QueryString[0].ToString());

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lbluidno.Text = dsnew.Tables[0].Rows[0]["UID_No"].ToString();
                    lblunitname.Text = dsnew.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                    lbladdress.Text = dsnew.Tables[0].Rows[0]["Village_Name"].ToString();
                    lblvillage.Text = dsnew.Tables[0].Rows[0]["Manda_lName"].ToString();
                    lblmandal.Text = dsnew.Tables[0].Rows[0]["District_Name"].ToString();
                    lblnum2wrds.Text = dsnew.Tables[0].Rows[0]["date"].ToString();
                    if (dsnew != null && dsnew.Tables.Count > 2 && dsnew.Tables[2].Rows.Count > 0)
                    {
                        gvdata.DataSource = dsnew.Tables[2];
                        gvdata.DataBind();
                        foreach (GridViewRow row in gvdata.Rows)
                        {
                            //foreach (TableCell cell in row.Cells)
                            //{
                            row.Cells[2].Attributes.CssStyle["text-align"] = "Right";
                            row.Cells[2].Attributes.CssStyle["Width"] = "100px";
                            //}
                        }
                    }
                    else
                    {
                        Response.Redirect("UserGroundwaterlist.aspx");
                    }
                }
                else
                {
                    Response.Redirect("UserGroundwaterlist.aspx");
                }
            }              
        }
        else
        {
            Response.Redirect("UserGroundwaterlist.aspx");
        }
       
    }

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
        catch
        {

        }
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect(" ~/UI/TSiPASS/UserGroundwaterlist.aspx");
        
    }

  
}