using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_TPRIDEfinancialyearandcategorywisependingreport : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    private static readonly string[] ClaimsFields =
    {
        "SCMicroClaims", "SCSmallClaims",
        "STMicroClaims", "STSmallClaims",
        "PHCMicroClaims", "PHCSmallClaims"
    };

    private static readonly string[] AmountFields =
    {
        "SCMicroAmount", "SCSmallAmount",
        "STMicroAmount", "STSmallAmount",
        "PHCMicroAmount", "PHCSmallAmount"
    };

    private static readonly string[] ClaimLinkIds =
    {
        "lnkSCMicroClaims", "lnkSCSmallClaims",
        "lnkSTMicroClaims", "lnkSTSmallClaims",
        "lnkPHCMicroClaims", "lnkPHCSmallClaims"
    };

    private readonly int[] claimsTotals = new int[6];
    private readonly decimal[] amountTotals = new decimal[6];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblReportDate.Text = "Report as on date : " + DateTime.Now.ToString("dd-MM-yyyy");
            FillPendingReportGrid();
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        lblReportDate.Text = "Report as on date : " + DateTime.Now.ToString("dd-MM-yyyy");
        FillPendingReportGrid();
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    private void ExportToExcel()
    {
        FillPendingReportGrid();

        Response.Clear();
        Response.Buffer = true;
        string fileName = "TPRIDE_FinancialYearWiseReleasePending_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string headerTable = "<table width='100%'><tr><td align='center' colspan='14'><h4>T-PRIDE Financial Year Wise Release Pending</h4></td></tr>"
                + "<tr><td align='center' colspan='14'><h5>" + lblReportDate.Text + "</h5></td></tr></table>";

            gvPendingReport.RenderControl(hw);
            Response.Write(headerTable);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void FillPendingReportGrid()
    {
        DataSet ds = GetFinancialYearCategoryPendingReport();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ResetTotals();
            gvPendingReport.DataSource = ds.Tables[0];
            gvPendingReport.DataBind();
        }
        else
        {
            gvPendingReport.DataSource = null;
            gvPendingReport.DataBind();
        }
    }

    public DataSet GetFinancialYearCategoryPendingReport()
    {
        DataSet ds = new DataSet();

        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_TPRIDE_RELEASEPENDING_FYEAR_CATEGORYWISE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
        }
        finally
        {
            con.CloseConnection();
        }

        return ds;
    }

    private void ResetTotals()
    {
        for (int i = 0; i < 6; i++)
        {
            claimsTotals[i] = 0;
            amountTotals[i] = 0;
        }
    }

    protected void gvPendingReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
            return;

        GridView gv = (GridView)sender;
        e.Row.CssClass = "sub-header";

        GridViewRow sizeHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        AddEmptyHeaderCell(sizeHeader, "slno-column");
        AddEmptyHeaderCell(sizeHeader, "year-column");
        for (int i = 0; i < 6; i++)
        {
            AddSizeHeader(sizeHeader, i % 2 == 0 ? "MICRO" : "SMALL");
        }
        AddTotalSizeHeader(sizeHeader);

        GridViewRow schemeHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        AddEmptyHeaderCell(schemeHeader, "slno-column");
        AddEmptyHeaderCell(schemeHeader, "year-column");
        AddSchemeHeader(schemeHeader, "SC");
        AddSchemeHeader(schemeHeader, "ST");
        AddSchemeHeader(schemeHeader, "PHC");
        AddTotalSchemeHeader(schemeHeader, "TOTAL");

        gv.Controls[0].Controls.AddAt(0, sizeHeader);
        gv.Controls[0].Controls.AddAt(0, schemeHeader);
    }

    private void AddEmptyHeaderCell(GridViewRow row, string cssClass)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "&nbsp;";
        cell.CssClass = "category-empty " + cssClass;
        row.Cells.Add(cell);
    }

    private void AddSchemeHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 4;
        cell.CssClass = "scheme-header";
        row.Cells.Add(cell);
    }

    private void AddTotalSchemeHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 2;
        cell.CssClass = "scheme-header";
        row.Cells.Add(cell);
    }

    private void AddSizeHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 2;
        cell.CssClass = "main-header";
        row.Cells.Add(cell);
    }

    private void AddTotalSizeHeader(GridViewRow row)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "&nbsp;";
        cell.ColumnSpan = 2;
        cell.CssClass = "main-header";
        row.Cells.Add(cell);
    }
    protected void gvPendingReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /* if (e.Row.RowType == DataControlRowType.DataRow)
         {
             for (int i = 0; i < 6; i++)
             {
                 claimsTotals[i] += ToInt(DataBinder.Eval(e.Row.DataItem, ClaimsFields[i]));
                 amountTotals[i] += ToDecimal(DataBinder.Eval(e.Row.DataItem, AmountFields[i]));
                 DisableClaimsLinkIfZero(e.Row.FindControl(ClaimLinkIds[i]));
             }
         }
         else if (e.Row.RowType == DataControlRowType.Footer)
         {
             e.Row.CssClass = "total-row";
             e.Row.Cells[0].Text = "";
             e.Row.Cells[1].Text = "TOTAL";

             for (int i = 0; i < 6; i++)
             {
                 int cellIndex = 2 + (i * 2);
                 e.Row.Cells[cellIndex].Text = claimsTotals[i].ToString();
                 e.Row.Cells[cellIndex + 1].Text = amountTotals[i].ToString("0.##");
             }
         }*/


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowTotalClaims = 0;
            decimal rowTotalAmount = 0;

            for (int i = 0; i < 6; i++)
            {
                int claims = ToInt(DataBinder.Eval(e.Row.DataItem, ClaimsFields[i]));
                decimal amount = ToDecimal(DataBinder.Eval(e.Row.DataItem, AmountFields[i]));

                claimsTotals[i] += claims;
                amountTotals[i] += amount;

                rowTotalClaims += claims;
                rowTotalAmount += amount;

                DisableClaimsLinkIfZero(e.Row.FindControl(ClaimLinkIds[i]));
            }

            SetLabelText(e.Row, "lblTotalClaims", rowTotalClaims.ToString());
            SetLabelText(e.Row, "lblTotalAmount", rowTotalAmount.ToString("0.##"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "total-row";
            e.Row.Cells[0].Text = "";
            e.Row.Cells[1].Text = "TOTAL";

            int grandTotalClaims = 0;
            decimal grandTotalAmount = 0;

            for (int i = 0; i < 6; i++)
            {
                int cellIndex = 2 + (i * 2);
                e.Row.Cells[cellIndex].Text = claimsTotals[i].ToString();
                e.Row.Cells[cellIndex + 1].Text = amountTotals[i].ToString("0.##");

                grandTotalClaims += claimsTotals[i];
                grandTotalAmount += amountTotals[i];
            }

            int totalClaimsCellIndex = 2 + (6 * 2);
            e.Row.Cells[totalClaimsCellIndex].Text = grandTotalClaims.ToString();
            e.Row.Cells[totalClaimsCellIndex + 1].Text = grandTotalAmount.ToString("0.##");
        }
    }

    private void SetLabelText(GridViewRow row, string controlId, string text)
    {
        System.Web.UI.WebControls.Label label =
            row.FindControl(controlId) as System.Web.UI.WebControls.Label;

        if (label != null)
            label.Text = text;
    }

    private void DisableClaimsLinkIfZero(Control control)
    {
        LinkButton link = control as LinkButton;
        if (link == null)
            return;

        if (ToInt(link.Text) <= 0)
        {
            link.Enabled = false;
            link.Style["color"] = "#000000";
            link.Style["text-decoration"] = "none";
            link.Style["cursor"] = "default";
        }
    }

    protected void gvPendingReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "ViewClaims")
            return;

        string argument = Convert.ToString(e.CommandArgument);
        if (string.IsNullOrWhiteSpace(argument))
            return;

        string[] values = argument.Split('|');
        if (values.Length != 4)
            return;

        string fyearId = values[0].Trim();
        string financialYear = values[1].Trim();
        string scheme = values[2].Trim().ToUpperInvariant();
        string category = values[3].Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(fyearId) || string.IsNullOrWhiteSpace(financialYear))
            return;

        if (scheme != "SC" && scheme != "ST" && scheme != "PHC")
            return;

        if (category != "MICRO" && category != "SMALL")
            return;

        //Response.Redirect(
        //    "TPRIDEfinancialyearandcategorywisependingreportDrilldown.aspx"
        //    + "?fyearid=" + Server.UrlEncode(fyearId)
        //    + "&financialyear=" + Server.UrlEncode(financialYear)
        //    + "&scheme=" + Server.UrlEncode(scheme)
        //    + "&category=" + Server.UrlEncode(category),
        //    false);
        string targetUrl = "TPRIDEfinancialyearandcategorywisependingreportDrilldown.aspx"
    + "?fyearid=" + Server.UrlEncode(fyearId)
    + "&financialyear=" + Server.UrlEncode(financialYear)
    + "&scheme=" + Server.UrlEncode(scheme)
    + "&category=" + Server.UrlEncode(category);

        // Escapes the URL for JavaScript and registers the startup script to open a new tab
        string script = "window.open('" + ResolveUrl(targetUrl) + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenOpenNewTab", script, true);

        Context.ApplicationInstance.CompleteRequest();
    }

    private int ToInt(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        int result;
        int.TryParse(Convert.ToString(value), out result);
        return result;
    }

    private decimal ToDecimal(object value)
    {
        if (value == null || value == DBNull.Value)
            return 0;

        decimal result;
        decimal.TryParse(Convert.ToString(value), out result);
        return result;
    }
}
