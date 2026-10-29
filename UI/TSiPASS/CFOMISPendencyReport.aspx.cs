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
public partial class UI_TSiPASS_IncentiveClaimsReport : System.Web.UI.Page
{
    General Gen = new General();
    decimal GMAssignW, GMAssignB, GMAssign90, InspAssignW, InspAssingB, InspAssign90, InspUploadW, InspUploadB, InspUpload90, GMtoCOIW, GMtoCOIB, GMtoCOI90, Query, Total, Total90;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                FillGridDetails();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void FillGridDetails()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = Gen.GetCFOMISPendingReport();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {


    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal GMAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedWithin"));
                GMAssignW = GMAssignW1 + GMAssignW;

                decimal GMAssignB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ApprovedBeyond"));
                GMAssignB = GMAssignB1 + GMAssignB;

                decimal GMAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedWithin"));
                GMAssign90 = GMAssign901 + GMAssign90;

                decimal InspAssignW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "RejectedBeyond"));
                InspAssignW = InspAssignW1 + InspAssignW;

                decimal InspAssingB1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingWithin"));
                InspAssingB = InspAssingB1 + InspAssingB;

                decimal InspAssign901 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PendingBeyond"));
                InspAssign90 = InspAssign901 + InspAssign90;

                decimal InspUploadW1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending90"));
                InspUploadW = InspUploadW1 + InspUploadW;


                HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink2");
                h1.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=A&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h2 = (HyperLink)e.Row.FindControl("HyperLink3");
                h2.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=B&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h9 = (HyperLink)e.Row.FindControl("HyperLink10");
                h9.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=C&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink5");
                h3.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=D&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h4 = (HyperLink)e.Row.FindControl("HyperLink6");
                h4.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=E&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h10 = (HyperLink)e.Row.FindControl("HyperLink11");
                h10.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=F&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink4");
                h5.NavigateUrl = "CFOMISPendencyReportDrill.aspx?status=G&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink7");
                //h6.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=H&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h11 = (HyperLink)e.Row.FindControl("HyperLink12");
                //h11.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=I&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h7 = (HyperLink)e.Row.FindControl("HyperLink8");
                //h7.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=J&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h8 = (HyperLink)e.Row.FindControl("HyperLink9");
                //h8.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=K&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h12 = (HyperLink)e.Row.FindControl("HyperLink13");
                //h12.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=L&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h13 = (HyperLink)e.Row.FindControl("HyperLink14");
                //h13.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=M&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h14 = (HyperLink)e.Row.FindControl("HyperLink15");
                //h14.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=N&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

                //HyperLink h15 = (HyperLink)e.Row.FindControl("HyperLink16");
                //h15.NavigateUrl = "IncentiveMISPendencyReportDrill.aspx?status=O&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";

                Label GMAssignW1 = new Label();
                GMAssignW1.Text = GMAssignW.ToString();
                e.Row.Cells[3].Controls.Add(GMAssignW1);

                Label GMAssignB1 = new Label();
                GMAssignB1.Text = GMAssignB.ToString();
                e.Row.Cells[4].Controls.Add(GMAssignB1);

                Label GMAssign901 = new Label();
                GMAssign901.Text = GMAssign90.ToString();
                e.Row.Cells[5].Controls.Add(GMAssign901);

                Label InspAssignW1 = new Label();
                InspAssignW1.Text = InspAssignW.ToString();
                e.Row.Cells[6].Controls.Add(InspAssignW1);

                Label InspAssingB1 = new Label();
                InspAssingB1.Text = InspAssingB.ToString();
                e.Row.Cells[7].Controls.Add(InspAssingB1);

                Label InspAssign901 = new Label();
                InspAssign901.Text = InspAssign90.ToString();
                e.Row.Cells[8].Controls.Add(InspAssign901);

                Label InspUploadW1 = new Label();
                InspUploadW1.Text = InspUploadW.ToString();
                e.Row.Cells[9].Controls.Add(InspUploadW1);

                //Label InspUploadB1 = new Label();
                //InspUploadB1.Text = InspUploadB.ToString();
                //e.Row.Cells[10].Controls.Add(InspUploadB1);

                //Label InspUpload901 = new Label();
                //InspUpload901.Text = InspUpload90.ToString();
                //e.Row.Cells[11].Controls.Add(InspUpload901);

                //Label GMtoCOIW1 = new Label();
                //GMtoCOIW1.Text = GMtoCOIW.ToString();
                //e.Row.Cells[12].Controls.Add(GMtoCOIW1);

                //Label GMtoCOIB1 = new Label();
                //GMtoCOIB1.Text = GMtoCOIB.ToString();
                //e.Row.Cells[13].Controls.Add(GMtoCOIB1);

                //Label GMtoCOI901 = new Label();
                //GMtoCOI901.Text = GMtoCOI90.ToString();
                //e.Row.Cells[14].Controls.Add(GMtoCOI901);

                //Label Query1 = new Label();
                //Query1.Text = Query.ToString();
                //e.Row.Cells[15].Controls.Add(Query1);

                //Label Total1 = new Label();
                //Total1.Text = Total.ToString();
                //e.Row.Cells[16].Controls.Add(Total1);

                //Label Total901 = new Label();
                //Total901.Text = Total90.ToString();
                //e.Row.Cells[17].Controls.Add(Total901);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvHeaderRow = e.Row;
                GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

                int headerCellCount = gvHeaderRow.Cells.Count;
                int cellIndex = 0;

                for (int i = 0; i < headerCellCount; i++)
                {
                    if (i == 3 || i == 4)
                    {
                        cellIndex++;
                    }
                    else if (i == 5 || i == 6)
                    {
                        cellIndex++;
                    }
                    else if (i == 7 || i == 8 || i == 9)
                    {
                        cellIndex++;
                    }
                    else
                    {
                        TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                        tcHeader.RowSpan = 2;
                        gvHeaderRowCopy.Cells.Add(tcHeader);
                    }
                }


                TableCell tcMergePackage = new TableCell();
                tcMergePackage.Text = "Approved";
                tcMergePackage.CssClass = "GridviewScrollC1Header";
                tcMergePackage.ColumnSpan = 2;
                gvHeaderRowCopy.Cells.AddAt(3, tcMergePackage);


                TableCell tcMergePackage1 = new TableCell();
                tcMergePackage1.Text = "Rejected";
                tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage1.ColumnSpan = 2;
                gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage1);

                TableCell tcMergePackage2 = new TableCell();
                tcMergePackage2.Text = "Pending";
                tcMergePackage2.CssClass = "GridviewScrollC1Headerwrap";
                tcMergePackage2.ColumnSpan = 3;
                gvHeaderRowCopy.Cells.AddAt(5, tcMergePackage2);

                //TableCell tcMergePackage20 = new TableCell();
                //tcMergePackage20.Text = "Pending to Forward to COI/DIPC";
                //tcMergePackage20.CssClass = "GridviewScrollC1Headerwrap";
                //tcMergePackage20.ColumnSpan = 3;
                //gvHeaderRowCopy.Cells.AddAt(6, tcMergePackage20);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
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
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
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
                //string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
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
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        try
        {
            PrintPdf();
        }
        catch (Exception ex)
        {
            lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

}