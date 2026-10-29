using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_JDreports : System.Web.UI.Page
{
    public static DataSet GDs { get; set; }
    General Common = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                Label1.Text = "Report as on date " + DateTime.Now;
                dashboard();






            }
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }




    }


    //public void bindDistricts()
    //{

    //    DropDownList1.Items.Clear();

    //    var data = Common.GenericFillDataTable("USP_GET_RM_DISTRICTSwisereports", null);

    //    if (data.Rows.Count > 0)
    //    {

    //        DropDownList1.DataSource = data;
    //        DropDownList1.DataTextField = "District_Name";
    //        DropDownList1.DataValueField = "District_Id";
    //        DropDownList1.DataBind();



    //    }

    //    DropDownList1.Items.Insert(0, new ListItem { Text = "---All---", Value = "0" });


    //}
    public string formdate(string date)
    {
        string dd = "";
        if (date != "")
        {
            string[] dt = date.Split('-');
            dd = dt[2].ToString() + "-" + dt[1].ToString() + "-" + dt[0].ToString();
        }
        return dd;
    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        dashboard(txtfromdate.Text, txttodate.Text, DropDownList1.SelectedValue);
    //    }
    //    catch (Exception ex)
    //    {
    //        LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
    //    }


    //}


    public void dashboard()
    {



        try
        {





            DataTable dt = Common.GenericFillDataTables("USP_GET_JDrawmaterials");




            if (dt.Rows.Count > 0)
            {

                grdDetails.DataSource = dt;
                grdDetails.DataBind();


            }



        }
        catch (Exception ex)
        {

            //throw ee;
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

        }

    }


    public static string DateTimeConversion(string date)
    {
        string dd = "";
        if (date != "")
        {
            string[] dt = date.Split('-');
            dd = dt[1].ToString() + "/" + dt[0].ToString() + "/" + dt[2].ToString();
        }
        return dd;
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {







            HyperLink h1 = (HyperLink)e.Row.FindControl("HyperLink1");

            h1.NavigateUrl = "Jdwisereports.aspx?status=1&&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();



            HyperLink h5 = (HyperLink)e.Row.FindControl("HyperLink2");



            h5.NavigateUrl = "Jdwisereports.aspx?status=2&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();
            HyperLink h5a = (HyperLink)e.Row.FindControl("HyperLink3");

            h5a.NavigateUrl = "Jdwisereports.aspx?status=3&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h5b = (HyperLink)e.Row.FindControl("HyperLink4");

            h5b.NavigateUrl = "Jdwisereports.aspx?status=4&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6 = (HyperLink)e.Row.FindControl("HyperLink5");

            h6.NavigateUrl = "Jdwisereports.aspx?status=5&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6a = (HyperLink)e.Row.FindControl("HyperLink6");
            h6a.NavigateUrl = "Jdwisereports.aspx?status=6&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6b = (HyperLink)e.Row.FindControl("HyperLink7");
            h6b.NavigateUrl = "Jdwisereports.aspx?status=7&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6c = (HyperLink)e.Row.FindControl("HyperLink8");

            h6c.NavigateUrl = "Jdwisereports.aspx?status=8&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6kl = (HyperLink)e.Row.FindControl("HyperLink9");

            h6kl.NavigateUrl = "Jdwisereports.aspx?status=9&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();

            HyperLink h6k2 = (HyperLink)e.Row.FindControl("HyperLink10");

            h6k2.NavigateUrl = "Jdwisereports.aspx?status=10&intDistid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistCd")).Trim();


            //HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            //h1.NavigateUrl = "Jdwisereports.aspx?status=1&fromdate=" + formdate(txtfromdate.Text) + "&todate=" + formdate(txttodate.Text) + "&District=" + DropDownList1.SelectedValue;



            //HyperLink hq = (HyperLink)e.Row.Cells[1].Controls[0];



            //hq.NavigateUrl = "Jdwisereports.aspx?status=2&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            //HyperLink hqa = (HyperLink)e.Row.Cells[2].Controls[0];

            //hqa.NavigateUrl = "Jdwisereports.aspx?status=3&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink hqb = (HyperLink)e.Row.Cells[3].Controls[0];

            //hqb.NavigateUrl = "Jdwisereports.aspx?status=4&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink hq6 = (HyperLink)e.Row.Cells[4].Controls[0];

            //hq6.NavigateUrl = "Jdwisereports.aspx?status=5&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6q = (HyperLink)e.Row.Cells[5].Controls[0];
            //h6q.NavigateUrl = "Jdwisereports.aspx?status=6&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink hqe = (HyperLink)e.Row.Cells[6].Controls[0];
            //hqe.NavigateUrl = "Jdwisereports.aspx?status=7&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6f = (HyperLink)e.Row.Cells[7].Controls[0];

            //h6f.NavigateUrl = "Jdwisereports.aspx?status=8&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6l = (HyperLink)e.Row.Cells[8].Controls[0];
            //h6l.NavigateUrl = "Jdwisereports.aspx?status=9&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6p = (HyperLink)e.Row.Cells[9].Controls[0];
            //h6p.NavigateUrl = "Jdwisereports.aspx?status=10&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;









        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }

}