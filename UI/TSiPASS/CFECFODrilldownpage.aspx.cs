using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection.Emit;

public partial class UI_TSiPASS_CFECFEODrilldownpage : System.Web.UI.Page
{
    General Gen = new General();
    string conString = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Ensures direct file download postback without AJAX update panel interception
        ScriptManager sm = ScriptManager.GetCurrent(this.Page);
        if (sm != null)
        {
            sm.RegisterPostBackControl(btnExcelExport);
            sm.RegisterPostBackControl(btnPdfExport);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblHeading.Text = "View Applications";
        if (!IsPostBack)
        {
            BindGridData();
        }
    }

    private DataTable FetchDataForExport()
    {
        string dept = Request.QueryString.Count > 0 ? Request.QueryString[0].ToString().Trim() : "";
        string status = Request.QueryString.Count > 1 ? Request.QueryString[1].ToString().Trim() : "";
        string fromDate = !string.IsNullOrEmpty(txtFromDate.Text) ? txtFromDate.Text.Trim() : (Request.QueryString.Count > 2 ? Request.QueryString[2].ToString().Trim() : "");
        string toDate = !string.IsNullOrEmpty(txtTodate.Text) ? txtTodate.Text.Trim() : (Request.QueryString.Count > 3 ? Request.QueryString[3].ToString().Trim() : "");
        string type = Request.QueryString.Count > 4 ? Request.QueryString[4].ToString().Trim() : "";
        string approval = Request.QueryString.Count > 5 ? Request.QueryString[5].ToString().Trim() : "";

        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlCommand cmd = new SqlCommand("DeptReportDepartmentWise_New1_CFE_FORAGENDA_drilldown", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 3600;

                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
                cmd.Parameters.Add("@approvalid", SqlDbType.VarChar).Value = approval;

                if (!string.IsNullOrEmpty(fromDate) && fromDate.Contains("-"))
                {
                    DateTime dtFrom, dtTo;
                    if (DateTime.TryParseExact(fromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtFrom))
                    {
                        cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = dtFrom;
                    }
                    if (DateTime.TryParseExact(toDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtTo))
                    {
                        cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = dtTo;
                    }
                }

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Columns.Contains("DOA"))
                    {
                        dt.Columns.Remove("DOA");
                    }

                    // Prepend S No column
                    if (!dt.Columns.Contains("S No"))
                    {
                        DataColumn colSerial = new DataColumn("S No", typeof(int));
                        dt.Columns.Add(colSerial);
                        colSerial.SetOrdinal(0);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dt.Rows[i]["S No"] = i + 1;
                        }
                    }

                    return dt;
                }
            }
        }
    }

    private void BindGridData()
    {
        try
        {
            string status = Request.QueryString.Count > 1 ? Request.QueryString[1].ToString().Trim() : "";
            txtFromDate.Text = Request.QueryString.Count > 2 ? Request.QueryString[2].ToString().Trim() : "";
            txtTodate.Text = Request.QueryString.Count > 3 ? Request.QueryString[3].ToString().Trim() : "";
            string type = Request.QueryString.Count > 4 ? Request.QueryString[4].ToString().Trim() : "";
            lbllable.Text = type;

            DataTable dt = FetchDataForExport();

            if (dt != null && dt.Rows.Count > 0)
            {
                Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();

                if (type == "CFO")
                {
                    grdExport.DataSource = dt;
                    grdExport.DataBind();
                    divExport.Visible = true;
                    Tr1.Visible = false;
                }
                else
                {
                    grdDetails.DataSource = dt;
                    grdDetails.DataBind();
                    divExport.Visible = false;
                    Tr1.Visible = true;
                }
            }
            else
            {
                Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdExport.DataSource = null;
                grdExport.DataBind();
            }

            HyperLink1.NavigateUrl = "frmcfecfoReviewPendency.aspx?status=" + status + "&lbl=Total Applications Received&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "LoadError", "alert('Load Error: " + ex.Message.Replace("'", "") + "');", true);
        }
    }

    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = FetchDataForExport();
            if (dt == null || dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No records available to export.');", true);
                return;
            }

            // Exclude questionnaire ID columns from export
            DataTable dtExport = dt.Copy();
            if (dtExport.Columns.Contains("intQuessionaireid"))
            {
                dtExport.Columns.Remove("intQuessionaireid");
            }
            if (dtExport.Columns.Contains("intQuessionaireCFOid"))
            {
                dtExport.Columns.Remove("intQuessionaireCFOid");
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>");
            sb.Append("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>");
            sb.Append("<style>");
            sb.Append("body { font-family: Calibri, 'Segoe UI', Arial, sans-serif; font-size: 11pt; }");
            sb.Append("table { border-collapse: collapse; }");
            sb.Append(".table-th { background-color: #2E689C; color: #FFFFFF; font-weight: bold; font-size: 10.5pt; text-align: center; vertical-align: middle; height: 32px; border: 1px solid #1A446C; }");
            sb.Append(".data-row-even { background-color: #FFFFFF; }");
            sb.Append(".data-row-odd { background-color: #F8FAFC; }");
            sb.Append(".cell-base { border: 1px solid #D2D6DC; padding: 6px; vertical-align: middle; mso-number-format:\\@; font-size: 10pt; }");
            sb.Append(".center-align { text-align: center; }");
            sb.Append("</style>");
            sb.Append("<!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>Applications Report</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]-->");
            sb.Append("</head><body>");

            sb.Append("<table border='1' cellspacing='0' cellpadding='0'>");

            // 1. Column Headers (Blue with White text matching PDF)
            sb.Append("<tr>");
            foreach (DataColumn col in dtExport.Columns)
            {
                sb.Append("<th class='table-th'>").Append(HttpUtility.HtmlEncode(col.ColumnName)).Append("</th>");
            }
            sb.Append("</tr>");

            // 2. Data Rows with Alternating Row Colors
            for (int rowIndex = 0; rowIndex < dtExport.Rows.Count; rowIndex++)
            {
                DataRow row = dtExport.Rows[rowIndex];
                string rowStyle = (rowIndex % 2 == 0) ? "data-row-even" : "data-row-odd";

                sb.Append("<tr class='").Append(rowStyle).Append("'>");

                for (int colIndex = 0; colIndex < dtExport.Columns.Count; colIndex++)
                {
                    string val = row[colIndex] != null ? row[colIndex].ToString().Trim() : "";
                    string alignClass = (colIndex == 0) ? " center-align" : "";

                    sb.Append("<td class='cell-base").Append(alignClass).Append("'>");
                    sb.Append(HttpUtility.HtmlEncode(val));
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }

            sb.Append("</table></body></html>");

            Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();
            Response.Buffer = true;

            string fileName = "Applications_Report_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".xls";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        catch (System.Threading.ThreadAbortException)
        {
            // Expected consequence of Response.End()
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "ExcelError", "alert('Excel Export Error: " + ex.Message.Replace("'", "") + "');", true);
        }
    }
    protected void btnPdfExport_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = FetchDataForExport();
            if (dt == null || dt.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No records available to export.');", true);
                return;
            }

            // Exclude questionnaire ID columns from PDF export
            DataTable dtExport = dt.Copy();
            if (dtExport.Columns.Contains("intQuessionaireid"))
            {
                dtExport.Columns.Remove("intQuessionaireid");
            }
            if (dtExport.Columns.Contains("intQuessionaireCFOid"))
            {
                dtExport.Columns.Remove("intQuessionaireCFOid");
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Report_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Document pdfDoc = new Document(PageSize.A3.Rotate(), 15f, 15f, 15f, 15f);

            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter.GetInstance(pdfDoc, ms);
                pdfDoc.Open();

                Font titleFont = FontFactory.GetFont("Arial", 14, Font.BOLD, iTextSharp.text.Color.BLACK);
                Paragraph title = new Paragraph("TGiPASS - View Applications Report", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 15f;
                pdfDoc.Add(title);

                PdfPTable pdfTable = new PdfPTable(dtExport.Columns.Count);
                pdfTable.WidthPercentage = 100;

                Font headerFont = FontFactory.GetFont("Arial", 9, Font.BOLD, iTextSharp.text.Color.WHITE);
                Font cellFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, iTextSharp.text.Color.BLACK);
                iTextSharp.text.Color headerBg = new iTextSharp.text.Color(46, 104, 156);

                foreach (DataColumn column in dtExport.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, headerFont));
                    cell.BackgroundColor = headerBg;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    cell.Padding = 5f;
                    pdfTable.AddCell(cell);
                }

                foreach (DataRow row in dtExport.Rows)
                {
                    for (int i = 0; i < dtExport.Columns.Count; i++)
                    {
                        string cellValue = row[i] != null ? row[i].ToString().Trim() : "";
                        PdfPCell cell = new PdfPCell(new Phrase(cellValue, cellFont));
                        cell.Padding = 4f;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;

                        if (i == 0)
                        {
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        }

                        pdfTable.AddCell(cell);
                    }
                }

                pdfDoc.Add(pdfTable);
                pdfDoc.Close();

                byte[] bytes = ms.ToArray();
                Response.BinaryWrite(bytes);
                Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        catch (System.Threading.ThreadAbortException)
        {
            // Handled
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "PdfError", "alert('PDF Export Error: " + ex.Message.Replace("'", "") + "');", true);
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                    gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else
            {
                gr.CssClass = cssName;
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;
                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d))
                            gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch { }
                }
            }
        }
        catch { }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
    }

    protected void grdDetails_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
            if (e.Row.Cells.Count > 2)
            {
                e.Row.Cells[2].Visible = false; // Hide intQuessionaireid Header
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            DataRowView rowView = (DataRowView)e.Row.DataItem;
            if (rowView != null && rowView.DataView.Table.Columns.Contains("intQuessionaireid"))
            {
                string intUid = Convert.ToString(rowView["intQuessionaireid"]).Trim();
                LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
                if (btn != null)
                {
                    btn.Text = "View";
                    btn.OnClientClick = "javascript:return Popup('" + intUid + "');";
                }
            }

            if (e.Row.Cells.Count > 2)
            {
                e.Row.Cells[2].Visible = false; // Hide intQuessionaireid Data Cell
            }
        }
    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 2)
        {
            e.Row.Cells[2].Visible = false;
        }
    }

    protected void grdExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
            if (e.Row.Cells.Count > 2)
            {
                e.Row.Cells[2].Visible = false; // Hide intQuessionaireCFOid Header
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            DataRowView rowView = (DataRowView)e.Row.DataItem;
            if (rowView != null && rowView.DataView.Table.Columns.Contains("intQuessionaireCFOid"))
            {
                string intUid = Convert.ToString(rowView["intQuessionaireCFOid"]).Trim();
                LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton2");
                if (btn != null)
                {
                    btn.Text = "View";
                    btn.OnClientClick = "javascript:return PopupCFO('" + intUid + "');";
                }
            }

            if (e.Row.Cells.Count > 2)
            {
                e.Row.Cells[2].Visible = false; // Hide intQuessionaireCFOid Data Cell
            }
        }
    }

    protected void grdExport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > 2)
        {
            e.Row.Cells[2].Visible = false;
        }
    }
}