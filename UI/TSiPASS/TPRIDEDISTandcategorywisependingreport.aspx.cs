using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_TPRIDEDISTandcategorywisependingreport : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    private static readonly string[] UnitsFields =
    {
        "SCMicroUnits", "SCSmallUnits",
        "STMicroUnits", "STSmallUnits",
        "PHCMicroUnits", "PHCSmallUnits"
    };

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

    private readonly int[] unitsTotals = new int[6];
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
        string fileName = "TPRIDEIncentivesReleasePending_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string headerTable = "<table width='100%'><tr><td align='center' colspan='20'><h4>T-PRIDE Incentives Release Pending</h4></td></tr>"
                + "<tr><td align='center' colspan='20'><h5>" + lblReportDate.Text + "</h5></td></tr></table>";

            gvPendingReport.RenderControl(hw);
            Response.Write(headerTable);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void FillPendingReportGrid()
    {
        DataSet ds = GetDistrictCategoryPendingReport();

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];

            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                string districtName = Convert.ToString(dt.Rows[i]["District_Name"]).Trim();
                if (districtName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
                {
                    dt.Rows.RemoveAt(i);
                }
            }

            ResetTotals();
            gvPendingReport.DataSource = dt;
            gvPendingReport.DataBind();
        }
        else
        {
            gvPendingReport.DataSource = null;
            gvPendingReport.DataBind();
        }
    }

    public DataSet GetDistrictCategoryPendingReport()
    {
        DataSet ds = new DataSet();

        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GET_TPRIDE_RELEASEPENDINGDISTRICTANDCATEGORYWISE", con.GetConnection);
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
            unitsTotals[i] = 0;
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

        if (e.Row.Cells.Count > 1)
            e.Row.Cells[1].Visible = false;

        GridViewRow schemeHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        AddEmptyHeaderCell(schemeHeader, "slno-column");
        AddEmptyHeaderCell(schemeHeader, "district-column");
        AddSchemeHeader(schemeHeader, "SCP");
        AddSchemeHeader(schemeHeader, "TSP");
        AddSchemeHeader(schemeHeader, "PHC");
        AddTotalSchemeHeader(schemeHeader, "TOTAL");//NEW

        GridViewRow sizeHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        AddEmptyHeaderCell(sizeHeader, "slno-column");
        AddEmptyHeaderCell(sizeHeader, "district-column");
        for (int i = 0; i < 6; i++)
        {
            AddSizeHeader(sizeHeader, i % 2 == 0 ? "MICRO" : "SMALL");
        }
        AddTotalSizeHeader(sizeHeader); //NEW

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
        cell.ColumnSpan = 6;
        cell.CssClass = "scheme-header";
        row.Cells.Add(cell);
    }
    private void AddTotalSchemeHeader(GridViewRow row, string headerText) //NEW
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 3;
        cell.CssClass = "scheme-header";
        row.Cells.Add(cell);
    }

    private void AddSizeHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = headerText;
        cell.ColumnSpan = 3;
        cell.CssClass = "main-header";
        row.Cells.Add(cell);
    }
    private void AddTotalSizeHeader(GridViewRow row)//NEW
    {
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "&nbsp;";
        cell.ColumnSpan = 3;
        cell.CssClass = "main-header";
        row.Cells.Add(cell);
    }
    protected void gvPendingReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /* if (e.Row.RowType == DataControlRowType.DataRow)
         {
             for (int i = 0; i < 6; i++)
             {
                 unitsTotals[i] += ToInt(DataBinder.Eval(e.Row.DataItem, UnitsFields[i]));
                 claimsTotals[i] += ToInt(DataBinder.Eval(e.Row.DataItem, ClaimsFields[i]));
                 amountTotals[i] += ToDecimal(DataBinder.Eval(e.Row.DataItem, AmountFields[i]));
                 DisableClaimsLinkIfZero(e.Row.FindControl(ClaimLinkIds[i]));
             }
         }
         else if (e.Row.RowType == DataControlRowType.Footer)
         {
             e.Row.CssClass = "total-row";
             e.Row.Cells[0].Text = "";
             e.Row.Cells[1].Text = "";
             e.Row.Cells[2].Text = "TOTAL";

             for (int i = 0; i < 6; i++)
             {
                 int cellIndex = 3 + (i * 3);
                 e.Row.Cells[cellIndex].Text = unitsTotals[i].ToString();
                 e.Row.Cells[cellIndex + 1].Text = claimsTotals[i].ToString();
                 e.Row.Cells[cellIndex + 2].Text = amountTotals[i].ToString("0.##");
             }
         }*/

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int rowTotalUnits = 0;
            int rowTotalClaims = 0;
            decimal rowTotalAmount = 0;

            for (int i = 0; i < 6; i++)
            {
                int units = ToInt(DataBinder.Eval(e.Row.DataItem, UnitsFields[i]));
                int claims = ToInt(DataBinder.Eval(e.Row.DataItem, ClaimsFields[i]));
                decimal amount = ToDecimal(DataBinder.Eval(e.Row.DataItem, AmountFields[i]));

                unitsTotals[i] += units;
                claimsTotals[i] += claims;
                amountTotals[i] += amount;

                rowTotalUnits += units;
                rowTotalClaims += claims;
                rowTotalAmount += amount;

                DisableClaimsLinkIfZero(e.Row.FindControl(ClaimLinkIds[i]));
            }

            System.Web.UI.WebControls.Label lblTotalUnits =
                e.Row.FindControl("lblTotalUnits") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label lblTotalClaims =
                e.Row.FindControl("lblTotalClaims") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label lblTotalAmount =
                e.Row.FindControl("lblTotalAmount") as System.Web.UI.WebControls.Label;

            if (lblTotalUnits != null)
                lblTotalUnits.Text = rowTotalUnits.ToString();

            if (lblTotalClaims != null)
                lblTotalClaims.Text = rowTotalClaims.ToString();

            if (lblTotalAmount != null)
                lblTotalAmount.Text = rowTotalAmount.ToString("0.##");
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "total-row";
            e.Row.Cells[0].Text = "";
            e.Row.Cells[1].Text = "";
            e.Row.Cells[2].Text = "TOTAL";

            int grandTotalUnits = 0;
            int grandTotalClaims = 0;
            decimal grandTotalAmount = 0;

            for (int i = 0; i < 6; i++)
            {
                int cellIndex = 3 + (i * 3);

                e.Row.Cells[cellIndex].Text = unitsTotals[i].ToString();
                e.Row.Cells[cellIndex + 1].Text = claimsTotals[i].ToString();
                e.Row.Cells[cellIndex + 2].Text = amountTotals[i].ToString("0.##");

                grandTotalUnits += unitsTotals[i];
                grandTotalClaims += claimsTotals[i];
                grandTotalAmount += amountTotals[i];
            }

            int totalUnitsCellIndex = 3 + (6 * 3);

            e.Row.Cells[totalUnitsCellIndex].Text = grandTotalUnits.ToString();
            e.Row.Cells[totalUnitsCellIndex + 1].Text = grandTotalClaims.ToString();
            e.Row.Cells[totalUnitsCellIndex + 2].Text = grandTotalAmount.ToString("0.##");
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
        if (values.Length != 4)
            return;

        string districtId = values[0].Trim();
        string districtName = values[1].Trim();
        string scheme = values[2].Trim().ToUpperInvariant();
        string category = values[3].Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(districtId) || string.IsNullOrWhiteSpace(districtName))
            return;

        if (scheme != "SC" && scheme != "ST" && scheme != "PHC")
            return;

        if (category != "MICRO" && category != "SMALL")
            return;

        //Response.Redirect("TPRIDEDISTandcategorywisependingreportDrilldown.aspx"
        //    + "?districtid=" + Server.UrlEncode(districtId)
        //    + "&districtname=" + Server.UrlEncode(districtName)
        //    + "&scheme=" + Server.UrlEncode(scheme)
        //    + "&category=" + Server.UrlEncode(category), false);
        string targetUrl = "TPRIDEDISTandcategorywisependingreportDrilldown.aspx"
    + "?districtid=" + Server.UrlEncode(districtId)
    + "&districtname=" + Server.UrlEncode(districtName)
    + "&scheme=" + Server.UrlEncode(scheme)
    + "&category=" + Server.UrlEncode(category);

        // Registers the JavaScript block to execute on the client side, opening a new tab
        string script = "window.open('" + ResolveUrl(targetUrl) + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenTprideDistrictReport", script, true);

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
