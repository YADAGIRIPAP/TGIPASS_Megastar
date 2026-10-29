using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_FeedBackDashBoard : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    decimal Total1, pending1, Redress1, Reject1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        DataSet ds = new DataSet();
        if (Session["userlevel"].ToString() == "10")
        {
            ds = Gen.FeedBackQueries_Dashboard(Session["User_Code"].ToString(), "%","F");
            grdDetails.Columns[0].Visible = false;
        }
        else if (Session["userlevel"].ToString() == "13")
        {
            ds = Gen.FeedBackQueries_Dashboard("%", Session["uid"].ToString(),"F");
            grdDetails.Columns[0].Visible = false;
        }
        else
        {
            ds = Gen.FeedbackQuery_DeptwiseDashboard("F");
            grdDetails.Columns[0].Visible = true;
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Session["userlevel"].ToString() != "10" && Session["userlevel"].ToString() != "13")
            {
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                h1.NavigateUrl = "FeedBackStatusDetails.aspx?Status=All&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
                //HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                //h2.NavigateUrl = "GreivanceStatusDetails.aspx?Status=Pending&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
                //HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                //h3.NavigateUrl = "GreivanceStatusDetails.aspx?Status=Redressed&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
                //HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                //h4.NavigateUrl = "GreivanceStatusDetails.aspx?Status=Reject&intDeptid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();

            }

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
            //e.Row.Cells[3].Text = pending1.ToString();
            //e.Row.Cells[4].Text = Redress1.ToString();
            //e.Row.Cells[5].Text = Reject1.ToString();
        }

    }
}