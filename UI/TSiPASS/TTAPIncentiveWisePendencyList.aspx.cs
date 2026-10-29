using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

public partial class UI_TSiPASS_TTAPIncentiveWisePendencyList : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General gen = new General();
    int Slnorow = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
            GetSnos();
        }
    }
    public void BindGrid() 
    {
        DataSet ds = new DataSet();
        ds = getincentiveslclist();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    public DataSet getincentiveslclist()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TTAP_RELEASE_PENDENCY_REPORT", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Category = DataBinder.Eval(e.Row.DataItem, "Category").ToString();
            string IncentiveName = DataBinder.Eval(e.Row.DataItem, "IncentiveName").ToString();
            if (Category == "1" || Category == "2")
            {
                e.Row.Cells.Clear();
                TableCell mergedCell = new TableCell();
                mergedCell.ColumnSpan = 6;
                mergedCell.Text = IncentiveName;
                mergedCell.HorizontalAlign = HorizontalAlign.Center;
                mergedCell.Font.Bold = true;
                if (Category == "1")
                {
                    mergedCell.CssClass = "merged-row-style";
                }
                e.Row.Cells.Add(mergedCell);
            }
            if (Category == "3")
            {
                /*e.Row.CssClass = "merged-row-style1";*/
                e.Row.Cells[0].Text = IncentiveName;
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.ForeColor = System.Drawing.Color.Red;
                e.Row.Font.Bold = true;
                e.Row.Cells.RemoveAt(1);
            }
            if (Category == "4")
            {
                /*e.Row.CssClass = "merged-row-style2";*/
                e.Row.Cells[0].Text = IncentiveName;
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.ForeColor = System.Drawing.Color.DarkGreen;
                e.Row.Font.Bold = true;
                e.Row.Cells.RemoveAt(1);
            }
            if (Category == "5")
            {
                /*e.Row.CssClass = "merged-row-style1";*/
                e.Row.Cells[0].Text = IncentiveName;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
                e.Row.ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Font.Bold = true;
                e.Row.Cells.RemoveAt(1);
            }
        }
    }
    public void GetSnos()
    {
        int slno = 0;
        foreach (GridViewRow row in grdDetails.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lblInc = row.FindControl("lblNoOfIncentives") as Label;
                Label lblCategory = row.FindControl("lblHeaderCategory") as Label;
                if (lblInc != null)
                {
                    string Inc = lblInc.Text.Trim();
                    string Category = lblCategory.Text.Trim();
                    if (Inc != "" && Category == "")
                    {
                        slno = slno + 1;
                        row.Cells[0].Text = Convert.ToString(slno);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}