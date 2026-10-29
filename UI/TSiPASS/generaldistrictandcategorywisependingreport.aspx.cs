using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_generaldistrictandcategorywisependingreport : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    private static readonly string[] ClaimLinkIds =
   {
        "lnkMicroClaims", "lnkSmallClaims", "lnkMediumClaims", "lnkLargeClaims", "lnkMegaClaims"
    };
    private int microUnitsTotal = 0;
    private int microClaimsTotal = 0;
    private decimal microAmountTotal = 0;

    private int smallUnitsTotal = 0;
    private int smallClaimsTotal = 0;
    private decimal smallAmountTotal = 0;

    private int mediumUnitsTotal = 0;
    private int mediumClaimsTotal = 0;
    private decimal mediumAmountTotal = 0;

    private int largeUnitsTotal = 0;
    private int largeClaimsTotal = 0;
    private decimal largeAmountTotal = 0;

    private int megaUnitsTotal = 0;
    private int megaClaimsTotal = 0;
    private decimal megaAmountTotal = 0;
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
        string fileName = "TIDEATTAPIncentivesReleasePending_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string headerTable = "<table width='100%'><tr><td align='center' colspan='17'><h4>T-IDEA/TTAP Incentives Release Pending</h4></td></tr>"
                + "<tr><td align='center' colspan='17'><h5>" + lblReportDate.Text + "</h5></td></tr></table>";

            gvPendingReport.RenderControl(hw);
            Response.Write(headerTable);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    public void FillPendingReportGrid()
    {
        try
        {
            DataSet ds = GetDistrictCategoryPendingReport();


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow totalRow = ExtractAndRemoveTotalRow(dt);
                LoadTotals(dt, totalRow);

                gvPendingReport.DataSource = dt;
                gvPendingReport.DataBind();
            }
            else
            {
                ResetTotals();
                gvPendingReport.DataSource = null;
                gvPendingReport.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    public DataSet GetDistrictCategoryPendingReport()
    {
        DataSet ds = new DataSet();

        try
        {
            con.OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter("SP_GETGENERALRELEASEPENDINGDISTRICTANDCATEGORYWISE", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(ds);
        }
        catch
        {
            throw;
        }
        finally
        {
            con.CloseConnection();
        }


        return ds;
    }

    private DataRow ExtractAndRemoveTotalRow(DataTable dt)
    {
        DataRow totalRow = null;

        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            string districtName = Convert.ToString(dt.Rows[i]["District_Name"]).Trim();

            if (districtName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
            {
                totalRow = dt.Rows[i];
                dt.Rows.RemoveAt(i);
            }
        }

        return totalRow;
    }

    private void LoadTotals(DataTable dt, DataRow totalRow)
    {
        ResetTotals();

        if (totalRow != null)
        {
            microUnitsTotal = ToInt(totalRow["MicroUnits"]);
            microClaimsTotal = ToInt(totalRow["MicroClaims"]);
            microAmountTotal = ToDecimal(totalRow["MicroAmount"]);

            smallUnitsTotal = ToInt(totalRow["SmallUnits"]);
            smallClaimsTotal = ToInt(totalRow["SmallClaims"]);
            smallAmountTotal = ToDecimal(totalRow["SmallAmount"]);

            mediumUnitsTotal = ToInt(totalRow["MediumUnits"]);
            mediumClaimsTotal = ToInt(totalRow["MediumClaims"]);
            mediumAmountTotal = ToDecimal(totalRow["MediumAmount"]);

            largeUnitsTotal = ToInt(totalRow["LargeUnits"]);
            largeClaimsTotal = ToInt(totalRow["LargeClaims"]);
            largeAmountTotal = ToDecimal(totalRow["LargeAmount"]);

            megaUnitsTotal = ToInt(totalRow["MegaUnits"]);
            megaClaimsTotal = ToInt(totalRow["MegaClaims"]);
            megaAmountTotal = ToDecimal(totalRow["MegaAmount"]);
            return;
        }

        foreach (DataRow row in dt.Rows)
        {
            microUnitsTotal += ToInt(row["MicroUnits"]);
            microClaimsTotal += ToInt(row["MicroClaims"]);
            microAmountTotal += ToDecimal(row["MicroAmount"]);

            smallUnitsTotal += ToInt(row["SmallUnits"]);
            smallClaimsTotal += ToInt(row["SmallClaims"]);
            smallAmountTotal += ToDecimal(row["SmallAmount"]);

            mediumUnitsTotal += ToInt(row["MediumUnits"]);
            mediumClaimsTotal += ToInt(row["MediumClaims"]);
            mediumAmountTotal += ToDecimal(row["MediumAmount"]);

            largeUnitsTotal += ToInt(row["LargeUnits"]);
            largeClaimsTotal += ToInt(row["LargeClaims"]);
            largeAmountTotal += ToDecimal(row["LargeAmount"]);

            megaUnitsTotal += ToInt(row["MegaUnits"]);
            megaClaimsTotal += ToInt(row["MegaClaims"]);
            megaAmountTotal += ToDecimal(row["MegaAmount"]);
        }
    }

    private void SetFooterTotals(GridViewRow footerRow)
    {
        int col = 0;
        footerRow.Cells[col++].Text = string.Empty; // Slno
        footerRow.Cells[col++].Text = string.Empty; // Hidden DISTRICT column
        footerRow.Cells[col++].Text = "TOTAL";      // District Name

        footerRow.Cells[col++].Text = microUnitsTotal.ToString();
        footerRow.Cells[col++].Text = microClaimsTotal.ToString();
        footerRow.Cells[col++].Text = microAmountTotal.ToString("0.##");

        footerRow.Cells[col++].Text = smallUnitsTotal.ToString();
        footerRow.Cells[col++].Text = smallClaimsTotal.ToString();
        footerRow.Cells[col++].Text = smallAmountTotal.ToString("0.##");

        footerRow.Cells[col++].Text = mediumUnitsTotal.ToString();
        footerRow.Cells[col++].Text = mediumClaimsTotal.ToString();
        footerRow.Cells[col++].Text = mediumAmountTotal.ToString("0.##");

        footerRow.Cells[col++].Text = largeUnitsTotal.ToString();
        footerRow.Cells[col++].Text = largeClaimsTotal.ToString();
        footerRow.Cells[col++].Text = largeAmountTotal.ToString("0.##");

        footerRow.Cells[col++].Text = megaUnitsTotal.ToString();
        footerRow.Cells[col++].Text = megaClaimsTotal.ToString();
        footerRow.Cells[col++].Text = megaAmountTotal.ToString("0.##");

        int grandTotalUnits = microUnitsTotal + smallUnitsTotal + mediumUnitsTotal + largeUnitsTotal + megaUnitsTotal;
        int grandTotalClaims = microClaimsTotal + smallClaimsTotal + mediumClaimsTotal + largeClaimsTotal + megaClaimsTotal;
        decimal grandTotalAmount = microAmountTotal + smallAmountTotal + mediumAmountTotal + largeAmountTotal + megaAmountTotal;

        footerRow.Cells[col++].Text = grandTotalUnits.ToString();
        footerRow.Cells[col++].Text = grandTotalClaims.ToString();
        footerRow.Cells[col++].Text = grandTotalAmount.ToString("0.##");
    }

    private void ResetTotals()
    {
        microUnitsTotal = 0;
        microClaimsTotal = 0;
        microAmountTotal = 0;

        smallUnitsTotal = 0;
        smallClaimsTotal = 0;
        smallAmountTotal = 0;

        mediumUnitsTotal = 0;
        mediumClaimsTotal = 0;
        mediumAmountTotal = 0;

        largeUnitsTotal = 0;
        largeClaimsTotal = 0;
        largeAmountTotal = 0;

        megaUnitsTotal = 0;
        megaClaimsTotal = 0;
        megaAmountTotal = 0;
    }


    protected void gvPendingReport_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
            return;
        GridView gv = (GridView)sender;

        e.Row.CssClass = "sub-header";


        GridViewRow categoryHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);


        TableHeaderCell emptySlno = new TableHeaderCell();

        emptySlno.Text = "&nbsp;";

        emptySlno.CssClass = "category-empty slno-column";

        categoryHeader.Cells.Add(emptySlno);

        TableHeaderCell emptyDistrict = new TableHeaderCell();

        emptyDistrict.Text = "&nbsp;";

        emptyDistrict.CssClass = "category-empty district-column";

        categoryHeader.Cells.Add(emptyDistrict);


        // CATEGORY HEADERS

        AddGroupHeader(categoryHeader, "MICRO");

        AddGroupHeader(categoryHeader, "SMALL");

        AddGroupHeader(categoryHeader, "MEDIUM");

        AddGroupHeader(categoryHeader, "LARGE");

        AddGroupHeader(categoryHeader, "MEGA");

        AddGroupHeader(categoryHeader, "TOTAL");


        gv.Controls[0].Controls.AddAt(0, categoryHeader);
    }


    private void AddGroupHeader(GridViewRow row, string headerText)
    {
        TableHeaderCell cell = new TableHeaderCell();


        cell.Text = headerText;


        cell.ColumnSpan = 3;


        cell.CssClass = "main-header";


        row.Cells.Add(cell);
    }

    protected void gvPendingReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        /* if (e.Row.RowType == DataControlRowType.DataRow)
         {
             DisableClaimsLinkIfZero(e.Row.FindControl("lnkMicroClaims"));
             DisableClaimsLinkIfZero(e.Row.FindControl("lnkSmallClaims"));
             DisableClaimsLinkIfZero(e.Row.FindControl("lnkMediumClaims"));
             DisableClaimsLinkIfZero(e.Row.FindControl("lnkLargeClaims"));
             DisableClaimsLinkIfZero(e.Row.FindControl("lnkMegaClaims"));
         }
         else if (e.Row.RowType == DataControlRowType.Footer)
         {
             e.Row.CssClass = "total-row";
             SetFooterTotals(e.Row);
         }*/

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < ClaimLinkIds.Length; i++)
            {
                DisableClaimsLinkIfZero(e.Row.FindControl(ClaimLinkIds[i]));
            }

            int rowTotalUnits =
                ToInt(DataBinder.Eval(e.Row.DataItem, "MicroUnits"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "SmallUnits"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "MediumUnits"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "LargeUnits"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "MegaUnits"));

            int rowTotalClaims =
                ToInt(DataBinder.Eval(e.Row.DataItem, "MicroClaims"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "SmallClaims"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "MediumClaims"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "LargeClaims"))
                + ToInt(DataBinder.Eval(e.Row.DataItem, "MegaClaims"));

            decimal rowTotalAmount =
                ToDecimal(DataBinder.Eval(e.Row.DataItem, "MicroAmount"))
                + ToDecimal(DataBinder.Eval(e.Row.DataItem, "SmallAmount"))
                + ToDecimal(DataBinder.Eval(e.Row.DataItem, "MediumAmount"))
                + ToDecimal(DataBinder.Eval(e.Row.DataItem, "LargeAmount"))
                + ToDecimal(DataBinder.Eval(e.Row.DataItem, "MegaAmount"));

            SetLabelText(e.Row, "lblTotalUnits", rowTotalUnits.ToString());
            SetLabelText(e.Row, "lblTotalClaims", rowTotalClaims.ToString());
            SetLabelText(e.Row, "lblTotalAmount", rowTotalAmount.ToString("0.##"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "total-row";
            SetFooterTotals(e.Row);
        }
    }
    private void SetLabelText(GridViewRow row, string controlId, string text)
    {
        System.Web.UI.WebControls.Label lbl =
            row.FindControl(controlId) as System.Web.UI.WebControls.Label;

        if (lbl != null)
        {
            lbl.Text = text;
        }
    }


    private void DisableClaimsLinkIfZero(Control control)
    {
        LinkButton link = control as LinkButton;


        if (link == null)
            return;


        int claims = ToInt(link.Text);


        if (claims <= 0)
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
        {
            return;
        }


        string[] values = argument.Split('|');


        if (values.Length != 3)
            return;


        string districtId = values[0].Trim();
        string districtName = values[1].Trim();

        if (string.IsNullOrWhiteSpace(districtId) || string.IsNullOrWhiteSpace(districtName))
        {
            return;
        }


        string category = values[2].Trim().ToUpperInvariant();


        if (category != "MICRO" && category != "SMALL" && category != "MEDIUM" && category != "LARGE" && category != "MEGA")
        {
            return;
        }


        //Response.Redirect("generaldistrictandcategorywisependingreportDrilldown.aspx" + "?district=" + Server.UrlEncode(districtId) + "&districtname=" + Server.UrlEncode(districtName) + "&category=" + Server.UrlEncode(category), false);
        string targetUrl = "generaldistrictandcategorywisependingreportDrilldown.aspx"
    + "?district=" + Server.UrlEncode(districtId)
    + "&districtname=" + Server.UrlEncode(districtName)
    + "&category=" + Server.UrlEncode(category);

        // Dynamically creates the JavaScript to open the URL in a new tab (_blank)
        string script = "window.open('" + ResolveUrl(targetUrl) + "', '_blank');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenDistrictReport", script, true);

        Context.ApplicationInstance
            .CompleteRequest();
    }


    private int ToInt(object value)
    {
        if (value == null ||
            value == DBNull.Value)
        {
            return 0;
        }


        int result;


        int.TryParse(
            Convert.ToString(value),
            out result);


        return result;
    }




    private decimal ToDecimal(object value)
    {
        if (value == null || value == DBNull.Value)
        {
            return 0;
        }


        decimal result;


        decimal.TryParse(Convert.ToString(value), out result);


        return result;
    }
}