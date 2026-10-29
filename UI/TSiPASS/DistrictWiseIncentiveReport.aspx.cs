using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TSTBDCReg1 : System.Web.UI.Page
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
        //if (Session["userlevel"].ToString() == "10")
        //{
        //    ds = Gen.GrievDashboard(Session["User_Code"].ToString(), "%");
        //    grdDetails.Columns[0].Visible = false;
        //}
        //else if (Session["userlevel"].ToString() == "13")
        //{
        //    ds = Gen.GrievDashboard("%", Session["uid"].ToString());
        //    grdDetails.Columns[0].Visible = false;
        //}
        //else
        //{
        if (Session["DistrictID"].ToString().Trim() != "")
        {
            ds = Gen.DistrictWiseIncentivereportdetails(Session["DistrictID"].ToString().Trim());
        }
        else
        {
            ds = Gen.DistrictWiseIncentivereportdetails("%");
        }
            grdDetails.Columns[0].Visible = true;
        //}
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
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1HeaderWrap");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            //if (Session["userlevel"].ToString() != "10" && Session["userlevel"].ToString() != "13")
            //{
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                h1.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=1" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                h2.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=3" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                h3.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=2" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h15 = (HyperLink)e.Row.Cells[5].Controls[0];
                h15.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=17" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();




                HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
                h4.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=4" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h5 = (HyperLink)e.Row.Cells[7].Controls[0];
                h5.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=5" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h6 = (HyperLink)e.Row.Cells[8].Controls[0];
                h6.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=6" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h7 = (HyperLink)e.Row.Cells[9].Controls[0];
                h7.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=7" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h8 = (HyperLink)e.Row.Cells[10].Controls[0];
                h8.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=8" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h9 = (HyperLink)e.Row.Cells[11].Controls[0];
                h9.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=9" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h10 = (HyperLink)e.Row.Cells[12].Controls[0];
                h10.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=10" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h11 = (HyperLink)e.Row.Cells[13].Controls[0];
                h11.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=11" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h12= (HyperLink)e.Row.Cells[14].Controls[0];
                h12.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=16" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

                HyperLink h13= (HyperLink)e.Row.Cells[15].Controls[0];
                h13.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=16" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();
    HyperLink h14= (HyperLink)e.Row.Cells[16].Controls[0];
    h14.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=16" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

    HyperLink h99 = (HyperLink)e.Row.Cells[17].Controls[0];
    h99.NavigateUrl = "DistrictWiseIncentiveStatusDetails.aspx?Stg=99" + "&d1=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "District_Id")).Trim();

           // }

            //decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
            //Total1 = Total + Total1;


            //decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "pending"));
            //pending1 = pending + pending1;

            //decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "redress"));
            //Redress1 = Redress + Redress1;

            //decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
            //Reject1 = Reject + Reject1;


            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
           DataSet  ds1 = new DataSet();
           if (Session["DistrictID"].ToString().Trim() != "")
           {
               ds1 = Gen.DistrictWiseIncentivereportdetails(Session["DistrictID"].ToString().Trim());
           }
           else
           {
               ds1 = Gen.DistrictWiseIncentivereportdetails("%");
           }
            //4,5,8,11
            e.Row.Cells[1].Text = "Total:";

            e.Row.Cells[2].Text = ds1.Tables[1].Rows[0][1].ToString();
            e.Row.Cells[3].Text = ds1.Tables[1].Rows[0][2].ToString();
            e.Row.Cells[4].Text = ds1.Tables[1].Rows[0][3].ToString();
            e.Row.Cells[5].Text = ds1.Tables[1].Rows[0][4].ToString();
            e.Row.Cells[6].Text = ds1.Tables[1].Rows[0][5].ToString();
            e.Row.Cells[7].Text = ds1.Tables[1].Rows[0][6].ToString();
            e.Row.Cells[8].Text = ds1.Tables[1].Rows[0][7].ToString();
            e.Row.Cells[9].Text = ds1.Tables[1].Rows[0][8].ToString();
            e.Row.Cells[10].Text = ds1.Tables[1].Rows[0][9].ToString();
            e.Row.Cells[11].Text = ds1.Tables[1].Rows[0][10].ToString();
            e.Row.Cells[12].Text = ds1.Tables[1].Rows[0][11].ToString();
            e.Row.Cells[13].Text = ds1.Tables[1].Rows[0][12].ToString();
            e.Row.Cells[14].Text = ds1.Tables[1].Rows[0][13].ToString();
            e.Row.Cells[15].Text = ds1.Tables[1].Rows[0][14].ToString();
            e.Row.Cells[16].Text = ds1.Tables[1].Rows[0][16].ToString();

            e.Row.Cells[17].Text = ds1.Tables[1].Rows[0][17].ToString();

           
           
        }

    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1HeaderWrap";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;

                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
