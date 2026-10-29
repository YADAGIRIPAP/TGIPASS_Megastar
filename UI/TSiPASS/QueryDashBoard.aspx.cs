using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_QueryDashBoard : System.Web.UI.Page
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
            ds = Gen.FeedBackQueries_Dashboard(Session["User_Code"].ToString(), "%", "Q");
            if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
            {
                ds = Gen.FeedBackQueries_Dashboard("%", Session["uid"].ToString(), "Q");
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            //grdDetails.Columns[0].Visible = false;
        }
        else if (Session["userlevel"].ToString() == "13")
        {
            ds = Gen.FeedBackQueries_Dashboard("%", Session["uid"].ToString(), "Q");
            //grdDetails.Columns[0].Visible = false;
        }
        //else
        //{
        //    ds = Gen.GrievDeptwiseDashboard();
        //    grdDetails.Columns[0].Visible = true;
        //}
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}
        else
        {
            ds = Gen.FeedBackQueries_Dashboard("%", Session["uid"].ToString(), "Q");
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
                HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
                h1.NavigateUrl = "QueryStatusDetails.aspx?Status=All";
                HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
                h2.NavigateUrl = "QueryStatusDetails.aspx?Status=Pending";
                HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
                h3.NavigateUrl = "QueryStatusDetails.aspx?Status=Attended";
                //HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
                //h4.NavigateUrl = "QueryStatusDetails.aspx?Status=Reject";

            }
            else if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
            {
                HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
                h1.NavigateUrl = "QueryStatusDetails.aspx?Status=All";
                HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
                h2.NavigateUrl = "QueryStatusDetails.aspx?Status=Pending";
                HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
                h3.NavigateUrl = "QueryStatusDetails.aspx?Status=Attended";
            }

            decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
            Total1 = Total + Total1;


            decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pending"));
            pending1 = pending + pending1;

            decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Attended"));
            Redress1 = Redress + Redress1;

            decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
            Reject1 = Reject + Reject1;



        }
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    //4,5,8,11
        //    //e.Row.Cells[1].Text = "Total:";

        //    e.Row.Cells[1].Text = Total1.ToString();
        //    e.Row.Cells[2].Text = pending1.ToString();
        //    e.Row.Cells[3].Text = Redress1.ToString();
        //    e.Row.Cells[4].Text = Reject1.ToString();
        //}

    }
}