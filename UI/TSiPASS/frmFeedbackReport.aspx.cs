using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
using System.Drawing;

public partial class UI_TSiPASS_frmFeedbackReport : System.Web.UI.Page
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
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["status"] != null && Request.QueryString["status"] != "" && Request.QueryString["ApprovalId"] != null && Request.QueryString["ApprovalId"] != "")
            {
                Label1.Text = "";

                grdDetails.DataSource = null;
                grdDetails.DataBind();

                FillGrid();
            }

            // Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
        }
    }

    private void FillGrid()
    {
        DataSet ds = new DataSet();
        string status = "";
        string approvalid = "";
        status = Request.QueryString["status"].ToString();
        approvalid = Request.QueryString["ApprovalId"].ToString();

        ds = Gen.GetFeedBackRptRetrospectivedDrill(status, approvalid, null);
        lblHeading.Text = "FeedBack Report";

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();

        }
    }

    protected void ExportToExcel()
    {
        try
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=R1.2" + DateTime.Now.ToString("MM-dd-yyyy") + ".xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    div_Print.RenderControl(hw);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}
            GridView[] gvList = null;
            gvList = new GridView[] { grdDetails };
            ExportAv("FeedBackReport.xls", gvList);


        }
        catch (Exception e)
        {

        }
    }
    public void ExportAv(string fileName, GridView[] gvs)
    {

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //Label1.Text = "";

        foreach (GridView gv in gvs)
        {
            gv.AllowPaging = false;

            //   Create a form to contain the grid
            System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

            table.GridLines = gv.GridLines;
            //   add the header row to the table
            if (!(gv.Caption == null))
            {

                TableCell cell = new TableCell();
                cell.Text = gv.Caption;
                cell.ColumnSpan = 6;
                TableRow tr = new TableRow();
                tr.Controls.Add(cell);
                table.Rows.Add(tr);
            }
            // table.Rows.Add(
            if (gv.ID == "grdDetails0")
            {

                TableCell cell = new TableCell();
                cell.Text = "PRESCRUTINY STAGE : STATUS";
                cell.ColumnSpan = 6;
                cell.Height = 20;
                // cell. = 20;

                cell.VerticalAlign = VerticalAlign.Middle;
                TableRow tr = new TableRow();
                tr.Controls.Add(cell);
                table.Rows.Add(tr);

            }
            else if (gv.ID == "grdDetails1")
            {

                TableCell cell = new TableCell();
                cell.Text = "APPROVAL STAGE : STATUS";
                cell.ColumnSpan = 6;
                cell.Height = 20;
                // cell. = 20;

                cell.VerticalAlign = VerticalAlign.Middle;
                TableRow tr = new TableRow();
                tr.Controls.Add(cell);
                table.Rows.Add(tr);

            }
            if (!(gv.HeaderRow == null))
            {
                table.Rows.Add(gv.HeaderRow);
            }
            //   add each of the data rows to the table
            foreach (GridViewRow row in gv.Rows)
            {
                table.Rows.Add(row);
            }
            //   add the footer row to the table
            if (!(gv.FooterRow == null))
            {
                table.Rows.Add(gv.FooterRow);
            }
            if (gv.ID == "grdDetails")
            {

                TableCell cell = new TableCell();
                cell.Text = "Total";
                cell.ColumnSpan = 6;
                cell.Height = 20;
                // cell.
                // cell. = 20;

                cell.VerticalAlign = VerticalAlign.Middle;
                TableRow tr = new TableRow();
                tr.Controls.Add(cell);
                table.Rows.Add(tr);

            }
            //   render the table into the htmlwriter
            table.RenderControl(htw);
        }
        //   render the htmlwriter into the response

        string label1text = Label1.Text;
        string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
        HttpContext.Current.Response.Write(headerTable);
        HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=FeedbackReport.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        PrintPDF.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Failure.Visible = false;
        lblmsg0.Text = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date ";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date";
            valid = 1;
        }
        if (valid == 0)
        {
            string fromdt = "", Todt = "";

            //fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " to " + txtTodate.Text.Trim();

            FillGrid();
        }
        else
        {
            //ClearFields();
            Failure.Visible = true;
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcel();

        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.ToString();
        }
        finally
        {
        }
    }
    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // grdDetails.Columns[3].Visible = false;

    }
    protected void lnkUdyogAadhaarNo_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnkbtn.NamingContainer;
        LinkButton lnkuidno = (LinkButton)row.FindControl("lnkUdyogAadhaarNo");
        string uidno = lnkuidno.Text;

        DataSet ds = new DataSet();
        ds = Gen.GetFeedBackRptRetrospectivedDrill("UID", null, uidno);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdUdyogAadhaarAprovalsList.DataSource = ds.Tables[0];
            grdUdyogAadhaarAprovalsList.DataBind();
            //window.open("viewApprovalDetails.aspx?UIDNO=" + uidno, 'ViewChange', 'height=440,width=650,left=150,top=150,screenX=0,screenY=100');
            Popup(true);
        }

    }
    //To show message after performing operations
  public  void Popup(bool isDisplay)
    {
        StringBuilder builder = new StringBuilder();
        if (isDisplay)
        {
            builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
        }
        else
        {
            builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[3].Visible = false;
    }

    protected void grdDetails_RowCommand(object sender, GridViewRowEventArgs e)
    {
       
    }
    //public void btnClose_Click()
    //{
    //    Popup(false);
    //}

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Popup(false);
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/FeedbackRptNew.aspx");
    }
}