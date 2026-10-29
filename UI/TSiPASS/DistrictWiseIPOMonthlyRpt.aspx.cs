using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class UI_TSiPASS_DistrictWiseIPOMonthlyRpt : System.Web.UI.Page
{
    decimal NumberTotal, ApprovedTotal, RejectedTotal,PendingTotal;
    protected void Page_Load(object sender, EventArgs e)
    {
 

        string FromdateforDB = "", TodateforDB = "";

        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-') && txtTodate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-') && txtTodate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }

        SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
        DataSet oDataSet = new DataSet();
        //string gmID = Session["uid"].ToString();
        osqlConnection.Open();
        oSqlDataAdapter = new SqlDataAdapter("USP_GET_IPO_MOTHREPORT", osqlConnection);
        oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

        if (FromdateforDB.Trim() == "" || FromdateforDB.Trim() == null)
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = FromdateforDB;
        }

        if (TodateforDB.Trim() == "" || TodateforDB.Trim() == null)
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            oSqlDataAdapter.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = TodateforDB;
        }

        oSqlDataAdapter.SelectCommand.Parameters.Add("@reportCode", SqlDbType.VarChar).Value = "T";

        oDataSet = new DataSet();
        oSqlDataAdapter.Fill(oDataSet);
        grdDetails.DataSource = oDataSet.Tables[0];
        grdDetails.DataBind();





    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal NumberTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL"));
            NumberTotal = NumberTotal1 + NumberTotal;

            decimal ApprovedTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "APPROVED"));
            ApprovedTotal = ApprovedTotal1 + ApprovedTotal;


            decimal RejectedTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            RejectedTotal = RejectedTotal1 + RejectedTotal;

            decimal PendingTotal1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PENDINGFORAPPROVAL"));
            PendingTotal = PendingTotal1 + PendingTotal;

            //HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

            //h1.NavigateUrl = "ipoMonthlyReportData.aspx?District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Sectorandmajor")).Trim()+"";

            
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            HyperLink Total = new HyperLink();
            Total.ForeColor = System.Drawing.Color.White;
           // Total.NavigateUrl = "frmSectorDistrictDrillDown.aspx?status=" + ddlType.SelectedValue.ToString() + "&lbl=Total Applications Received&dist=%" + "&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;
            Total.Text = NumberTotal.ToString();
            //e.Row.Cells[2].Controls.RemoveAt(0);
            e.Row.Cells[2].Text = NumberTotal.ToString();
            e.Row.Cells[2].Controls.Add(Total);
            e.Row.Cells[3].Text = ApprovedTotal.ToString();
            e.Row.Cells[4].Text = RejectedTotal.ToString();
            e.Row.Cells[5].Text = PendingTotal.ToString();
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdDetails.PageIndex = e.NewPageIndex;
        //fillgrid();
    }
}
