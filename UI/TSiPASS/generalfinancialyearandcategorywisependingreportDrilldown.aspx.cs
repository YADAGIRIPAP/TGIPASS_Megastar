using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_generalfinancialyearandcategorywisependingreportDrilldown : System.Web.UI.Page
{
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblReportDate.Text = "Report as on date : " + DateTime.Now.ToString("dd-MM-yyyy");
            SetHeading();
            FillClaimDetailsGrid();
        }
    }

    private void SetHeading()
    {
        string financialYear = Convert.ToString(Request.QueryString["financialyear"]).Trim();
        string category = Convert.ToString(Request.QueryString["category"]).Trim().ToUpperInvariant();

        lblHeading.Text = "Financial Year Wise Release Pending - GENERAL - "
            + financialYear + " - " + category;
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        FillClaimDetailsGrid();
        ExportToExcel();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    private void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        string fileName = "FYCategoryClaimDetails_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string headerTable = "<table width='100%'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></tr>"
                + "<tr><td align='center' colspan='10'><h5>" + lblReportDate.Text + "</h5></td></tr></table>";

            gvClaimDetails.RenderControl(hw);
            Response.Write(headerTable);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    private void FillClaimDetailsGrid()
    {
        string financialYear = Convert.ToString(Request.QueryString["financialyear"]).Trim();
        string category = Convert.ToString(Request.QueryString["category"]).Trim().ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(financialYear) || string.IsNullOrWhiteSpace(category))
        {
            gvClaimDetails.DataSource = null;
            gvClaimDetails.DataBind();
            lblNoRecords.Visible = true;
            return;
        }

        if (category != "MICRO" && category != "SMALL" && category != "MEDIUM" && category != "LARGE" && category != "MEGA")
        {
            gvClaimDetails.DataSource = null;
            gvClaimDetails.DataBind();
            lblNoRecords.Visible = true;
            return;
        }

        DataSet ds = GetClaimDetails(financialYear, category);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvClaimDetails.DataSource = ds.Tables[0];
            gvClaimDetails.DataBind();
            lblNoRecords.Visible = false;
        }
        else
        {
            gvClaimDetails.DataSource = null;
            gvClaimDetails.DataBind();
            lblNoRecords.Visible = true;
        }
    }

    private DataSet GetClaimDetails(string financialYear, string category)
    {
        DataSet ds = new DataSet();

        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("SP_GETGENERALRELEASEPENDING_FYEAR_CATEGORYWISE_DRILLDOWN", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@FINANCIALYEAR", SqlDbType.VarChar, 100).Value = financialYear;
            da.SelectCommand.Parameters.Add("@CATEGORYID", SqlDbType.VarChar, 100).Value = category;
            da.Fill(ds);
        }
        finally
        {
            con.CloseConnection();
        }

        return ds;
    }
}
