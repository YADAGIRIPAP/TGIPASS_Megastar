using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_generalfinancialyearandcategorywisependingreport : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    private static readonly string[] ClaimsFields =
    {
        "MicroClaims", "SmallClaims", "MediumClaims", "LargeClaims", "MegaClaims"
    };

    private static readonly string[] AmountFields =
    {
        "MicroAmount", "SmallAmount", "MediumAmount", "LargeAmount", "MegaAmount"
    };

    private static readonly string[] ClaimLinkIds =
    {
        "lnkMicroClaims", "lnkSmallClaims", "lnkMediumClaims", "lnkLargeClaims", "lnkMegaClaims"
    };

    private readonly int[] claimsTotals = new int[5];
    private readonly decimal[] amountTotals = new decimal[5];

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
        string fileName = "FinancialYearWiseReleasePending_GENERAL_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string headerTable = "<table width='100%'><tr><td align='center' colspan='12'><h4>Financial Year Wise Release Pending - GENERAL</h4></td></tr>"
                + "<tr><td align='center' colspan='12'><h5>" + lblReportDate.Text + "</h5></td></tr></table>";

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
            SqlDataAdapter da = new SqlDataAdapter("SP_GETGENERALRELEASEPENDING_FYEAR_CATEGORYWISE", con.GetConnection);
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
        for (int i = 0; i < 5; i++)
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

        GridViewRow categoryHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        AddEmptyHeaderCell(categoryHeader, "slno-column");
        AddEmptyHeaderCell(categoryHeader, "year-column");
        AddCategoryHeader(categoryHeader, "MICRO");
        AddCategoryHeader(categoryHeader, "SMALL");
        AddCategoryHeader(categoryHeader, "MEDIUM");
        AddCategoryHeader(categoryHeader, "LARGE");
        AddCategoryHeader(categoryHeader, "MEGA");
        AddCategoryHeader(categoryHeader, "TOTAL");

        GridViewRow generalHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell generalCell = new TableHeaderCell();
        generalCell.Text = "GENERAL";
        //  generalCell.ColumnSpan = 12;
        generalCell.ColumnSpan = 14;
        generalCell.CssClass = "general-header";
        generalHeader.Cells.Add(generalCell);

        gv.Controls[0].Controls.AddAt(0, categoryHeader);
        gv.Controls[0].Controls.AddAt(0, generalHeader);
    }

    private void AddEmptyHeaderCell(GridViewRow row, string cssClass)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "&nbsp;";
        cell.CssClass = "category-empty " + cssClass;
        row.Cells.Add(cell);
    }

    private void AddCategoryHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 2;
        cell.CssClass = "main-header";
        row.Cells.Add(cell);
    }

    protected void gvPendingReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /* if (e.Row.RowType == DataControlRowType.DataRow)
         {
             for (int i = 0; i < 5; i++)
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

             for (int i = 0; i < 5; i++)
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

            for (int i = 0; i < 5; i++)
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

            for (int i = 0; i < 5; i++)
            {
                int cellIndex = 2 + (i * 2);
                e.Row.Cells[cellIndex].Text = claimsTotals[i].ToString();
                e.Row.Cells[cellIndex + 1].Text = amountTotals[i].ToString("0.##");

                grandTotalClaims += claimsTotals[i];
                grandTotalAmount += amountTotals[i];
            }

            int totalClaimsCellIndex = 2 + (5 * 2);
            e.Row.Cells[totalClaimsCellIndex].Text = grandTotalClaims.ToString();
            e.Row.Cells[totalClaimsCellIndex + 1].Text = grandTotalAmount.ToString("0.##");
        }
    }
    private void SetLabelText(GridViewRow row, string controlId, string text)
    {
        System.Web.UI.WebControls.Label label =
            row.FindControl(controlId) as System.Web.UI.WebControls.Label;

        if (label != null)
        {
            label.Text = text;
        }
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
        if (values.Length != 3)
            return;

        string fyearId = values[0].Trim();
        string financialYear = values[1].Trim();
        string category = values[2].Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(fyearId) || string.IsNullOrWhiteSpace(financialYear))
            return;

        if (category != "MICRO" && category != "SMALL" && category != "MEDIUM"
            && category != "LARGE" && category != "MEGA")
            return;

        //Response.Redirect(
        //    "generalfinancialyearandcategorywisependingreportDrilldown.aspx"
        //    + "?financialyear=" + Server.UrlEncode(financialYear)
        //    + "&category=" + Server.UrlEncode(category),
        //    false);
        string targetUrl = "generalfinancialyearandcategorywisependingreportDrilldown.aspx"
    + "?financialyear=" + Server.UrlEncode(financialYear)
    + "&category=" + Server.UrlEncode(category);

        // Registers the script to trigger a new browser tab via client-side JavaScript
        string script = "window.open('" + ResolveUrl(targetUrl) + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenGeneralFinancialYearReport", script, true);
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
