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
using System.Globalization;

public partial class UI_TSiPASS_ReleasePendingViewSLCAgenda : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string Cast = Request.QueryString[0].ToString();
            string Investmentid = Request.QueryString[1].ToString();
            h1heading.InnerHtml = Cast + " Category";
            txtsvcdate.Text = Request.QueryString[2].ToString();
            string statusnew = Request.QueryString["stage"].ToString().Trim();
            DataSet ds = new DataSet();
            ds = gen.getReleaseProceedingsSLCAgenda(Cast, Investmentid, statusnew);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    
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
                    Response.AddHeader("content-disposition", "attachment;filename= SLCAgenda.pdf");
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        foreach (GridViewRow gvrow in grdDetails.Rows)
        {
            int rowIndex = gvrow.RowIndex;
            string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
            string[] datett = txtsvcdate.Text.Trim().Split('/');
            //frmvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
            string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
            string MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
            valid = gen.UpdateincentiveProposedSLCdate(EnterperIncentiveID, MstIncentiveId, ProposedDate, Session["uid"].ToString());
        }
        if (valid == 1)
        {
            string message = "alert('Proposed SLC Proceedings Updated Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            Button6.Visible = true;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}