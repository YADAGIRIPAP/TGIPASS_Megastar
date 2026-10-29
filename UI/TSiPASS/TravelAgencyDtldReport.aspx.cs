using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_TravelAgencyDtldReport : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                txtFromDate.Text = Request.QueryString["fdt"].ToString();
                txtTodate.Text = Request.QueryString["tdt"].ToString();
            }
            else
            {
                txtFromDate.Text = "01-01-2020";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
            }
            BindData();
           // btnData_Click(sender, e);
        }
    }
    public void BindData()
    {
        try
        {
            string DistId, Type;
            DataSet ds = new DataSet();
            string DistName = "";
            string Fromdate = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            string Todate = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            //string DistId = Request.QueryString["Dist"].ToString();
            //string Type = Request.QueryString["Type"].ToString();
            if (Session["DistrictID"].ToString().Trim() != "")
            {
                DistId = Request.QueryString["Dist"].ToString();
            }
            else
            {
                DistId = "%";
            }
            if (Request.QueryString["Type"] != null)
            {
                Type = Request.QueryString["Type"].ToString();
            }
            else
            {
                Type = "%";
            }
            ds = Gen.GetTravelAgencyDetails(DistId, Fromdate, Todate, Type);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDetails.DataSource = ds.Tables[0];
                gvDetails.DataBind();
                if (Session["DistrictID"].ToString().Trim() != "")
                {
                    DistName = ds.Tables[1].Rows[0]["District_Name"].ToString();
                    //if (DistId == "All")
                    //{

                    //}
                }
                else
                {
                    DistName = "All Districts";
                }
            }
            else
            {
                gvDetails.DataSource = null;
                gvDetails.DataBind();
            }
            header.InnerHtml = "Data from " + txtFromDate.Text + " to " + txtTodate.Text + " - " + DistName;
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnData_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    protected void BtnExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = "Travel Agency List";
            string Heading = header.InnerHtml.ToString();
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvDetails.RenderControl(hw);

                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='16'><h4>" + Heading + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
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
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {

                    gvDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    gvDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                    gvDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    gvDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;


                    gvDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    string FileName = "Travel Agency List";
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + FileName + "_" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
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

    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hypCFE_CFO = (HyperLink)e.Row.FindControl("hypCFE_CFO");
            HyperLink hypAttachments = (HyperLink)e.Row.FindControl("hypAttachments");
            HyperLink hypPaymentDetails = (HyperLink)e.Row.FindControl("hypPaymentDetails");

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";

            hypCFE_CFO.NavigateUrl = "TourismTravelagentformPrint.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TravelAgentID")).Trim();
            hypAttachments.NavigateUrl = "frmViewAttachmentDetails_Travelagent.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TravelAgentID")).Trim();
            hypPaymentDetails.NavigateUrl = "RptPaymentDetails_Travelagent.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
        }
    }
}