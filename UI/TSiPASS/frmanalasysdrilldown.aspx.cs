using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmanalasysdrilldown : System.Web.UI.Page
{
    General Gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string year = Request.QueryString["Fromdate"].ToString();
                string month = Request.QueryString["Todate"].ToString();
                string id = Request.QueryString["Dept"].ToString();
                string status = Request.QueryString["status"].ToString();
                string deptName = Request.QueryString["deptname"].ToString();
                string DrillDownType = Request.QueryString["DrillDownType"].ToString();
                string SearchType = Request.QueryString["SearchType"].ToString();
                FillGridDetails(year, month, id, status, deptName, DrillDownType, SearchType);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    public void FillGridDetails(string year, string month, string id, string status, string deptName, string DrillDownType, string SearchType)
    {
        try
        {
            DataSet ds = new DataSet();

            Label1.Text = "Report from " + year + " to " + month;
            if (status == "A")
            {
                lblMsg.Text = deptName + " Department - Applications Applied";
            }
            else if (status == "B")
            {
                lblMsg.Text = deptName + " Department - Applications Disposed Online";
            }
            else if (status == "C")
            {
                lblMsg.Text = deptName + " Department - No of Applications Rejected in Pre-Scrutiny";
            }
            else if (status == "D")
            {
                lblMsg.Text = deptName + " Department - No of Applications In-Progress";
            }
            else if (status == "E")
            {
                lblMsg.Text = deptName + " Department - Applications Disposed off Within due Date";
            }
            else if (status == "F")
            {
                lblMsg.Text = deptName + " Department - Applications Disposed off Beyond due Date";
            }
            else if (status == "G")
            {
                lblMsg.Text = deptName + "Department - Applications Disposed on the Same Day";
            }

            if (DrillDownType.Contains("CFE"))
            {
                lblMsg.Text = lblMsg.Text + " (CFE)";
            }
            else if (DrillDownType.Contains("CFO"))
            {
                lblMsg.Text = lblMsg.Text + " (CFO)";
            }

            ds = GetMonthwiseStatusrptDrill(year, month, id, status, deptName, DrillDownType, SearchType);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                // Label1.Text = "No Records Found ";
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
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
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                TableCell HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);
                HeaderCell = new TableCell();



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "";
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Prescrutiny Status";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                //HeaderCell.Text = "Additions";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Approval Stage";
                HeaderCell.Visible = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public DataSet GetMonthwiseStatusrptDrill(string fromdate, string todate, string dept, string Status, string deptName, string DrillDownType, string SearchType)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_ANALASYS_DRILL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.VarChar).Value = fromdate;
            da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = todate;
            da.SelectCommand.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
            da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
            da.SelectCommand.Parameters.Add("@deptName", SqlDbType.VarChar).Value = deptName;
            da.SelectCommand.Parameters.Add("@DrillDownType", SqlDbType.VarChar).Value = DrillDownType;
            da.SelectCommand.Parameters.Add("@SearchType", SqlDbType.VarChar).Value = SearchType;
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}