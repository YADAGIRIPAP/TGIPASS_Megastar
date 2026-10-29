using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_GrievanceMisreport : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    decimal Total1, pending1, Redress1, Reject1;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        LBLDATETIME.Text = System.DateTime.Now.ToString();
        if (ddlRegisterAs.SelectedValue == "G")
        {
            ddlRegisterAs_SelectedIndexChanged(sender, e);
        }
    }
    protected void ddlRegisterAs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRegisterAs.SelectedValue == "G")
        {
            trgrievancereport.Visible = true;
            trquerydetailsreport.Visible = false;
            trfeedbackreport.Visible = false;
            ds = Gen.GrievDeptwiseDashboard();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        if (ddlRegisterAs.SelectedValue == "F")
        {
            trgrievancereport.Visible = false;
            trquerydetailsreport.Visible = false;
            trfeedbackreport.Visible = true;
            ds = Gen.FeedbackQuery_DeptwiseDashboard("F");
            grdfeedback.DataSource = ds.Tables[0];
            grdfeedback.DataBind();
        }
        if (ddlRegisterAs.SelectedValue == "Q")
        {
            trquerydetailsreport.Visible = true;
            trgrievancereport.Visible = false;
            trfeedbackreport.Visible = false;
            ds = Gen.GeneralQueryMis("%", "", "Q");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblquerytotal.Text = "Total CFE Applications Received :";
                lblquerytotal.Text = ds.Tables[0].Rows[0]["Total"].ToString().Trim();
                grdquerydetails.DataSource = ds.Tables[1];
                grdquerydetails.DataBind();
            }
        }
    }
    
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
            Total1 = Total + Total1;


            decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pending"));
            pending1 = pending + pending1;

            decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "redress"));
            Redress1 = Redress + Redress1;

            decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
            Reject1 = Reject + Reject1;
            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.NavigateUrl = "GrievanceMisReportDrilldown.aspx?Status=All&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.NavigateUrl = "GrievanceMisReportDrilldown.aspx?Status=Pending&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.NavigateUrl = "GrievanceMisReportDrilldown.aspx?Status=Redressed&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            h4.NavigateUrl = "GrievanceMisReportDrilldown.aspx?Status=Reject&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //4,5,8,11
            e.Row.Cells[1].Text = "Total:";

            e.Row.Cells[2].Text = Total1.ToString();
            e.Row.Cells[3].Text = pending1.ToString();
            e.Row.Cells[4].Text = Redress1.ToString();
            e.Row.Cells[5].Text = Reject1.ToString();
        }
    }
    protected void grdfeedback_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
            Total1 = Total + Total1;


            decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pending"));
            pending1 = pending + pending1;

            decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "redress"));
            Redress1 = Redress + Redress1;

            decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
            Reject1 = Reject + Reject1;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //4,5,8,11
            e.Row.Cells[1].Text = "Total:";

            e.Row.Cells[2].Text = Total1.ToString();
            e.Row.Cells[3].Text = pending1.ToString();
            e.Row.Cells[4].Text = Redress1.ToString();
            e.Row.Cells[5].Text = Reject1.ToString();
        }
    }
    //protected void grdquerydetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
    //        Total1 = Total + Total1;


    //        decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pending"));
    //        pending1 = pending + pending1;

    //        decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Attended"));
    //        Redress1 = Redress + Redress1;

    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        //4,5,8,11
    //        e.Row.Cells[1].Text = "Total:";

    //        e.Row.Cells[2].Text = pending1.ToString();
    //        e.Row.Cells[3].Text = Redress1.ToString();
    //        //e.Row.Cells[4].Text = Redress1.ToString();
    //       // e.Row.Cells[5].Text = Reject1.ToString();
    //    }
    //}
}