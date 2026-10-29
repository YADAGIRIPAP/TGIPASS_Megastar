using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_GMreports : System.Web.UI.Page
{
   
    public static DataSet GDs { get; set; }
    General Common = new General();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {



                txtfromdate.Text = "01-05-2018";
                txttodate.Text = System.DateTime.Now.ToString();
                Label1.Text = "Report as on date " + DateTime.Now;
                string date = txttodate.Text;
                string dist = DropDownList1.SelectedValue;
                string[] dt = date.Split(' ');
                txttodate.Text = dt[0].ToString();

                dashboard(txtfromdate.Text, txttodate.Text, dist);


                bindDistricts();


            }
        }
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }


    public void bindDistricts()
    {

        DropDownList1.Items.Clear();

        var data = Common.GenericFillDataTable("USP_GET_RM_DISTRICTSwisereports", null);

        if (data.Rows.Count > 0)
        {

            DropDownList1.DataSource = data;
            DropDownList1.DataTextField = "District_Name";
            DropDownList1.DataValueField = "District_Id";
            DropDownList1.DataBind();



        }

        DropDownList1.Items.Insert(0, new ListItem { Text = "---All---", Value = "0" });


    }

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
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            dashboard(txtfromdate.Text, txttodate.Text, DropDownList1.SelectedValue);
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }


    }


    public void dashboard(string fromdate, string todate, string dist)
    {
        try
        {

            SqlParameter[] p = new SqlParameter[] {
                new SqlParameter("@fromdate",SqlDbType.DateTime),
                 new SqlParameter("@todate",SqlDbType.DateTime),
                new SqlParameter("@DIST",SqlDbType.VarChar),


                };

            p[0].Value = formdate(fromdate.ToString());

            p[1].Value = formdate(todate.ToString());
            p[2].Value = dist.ToString();

            GDs = Common.GenericFillDs("sp_GMreports", p);




            if (GDs.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = GDs.Tables[0];
                grdDetails.DataBind();


            }
            if (GDs.Tables[1].Rows.Count > 0)
            {

                gvLevel2.DataSource = GDs.Tables[1];
                gvLevel2.DataBind();

            }
            if (GDs.Tables[2].Rows.Count > 0)
            {


                GridView2.DataSource = GDs.Tables[2];
                GridView2.DataBind();




            }

            if (GDs.Tables[3].Rows.Count > 0)
            {

                GridView1.DataSource = GDs.Tables[3];
                GridView1.DataBind();

            }
            if (GDs.Tables[4].Rows.Count > 0)
            {

                GridView3.DataSource = GDs.Tables[4];
                GridView3.DataBind();

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






            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            h1.NavigateUrl = "Gmwisereports.aspx?status=1&fromdate=" + formdate(txtfromdate.Text) + "&todate=" + formdate(txttodate.Text) + "&District=" + DropDownList1.SelectedValue;



            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];



            h5.NavigateUrl = "Gmwisereports.aspx?status=2&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];

            h5a.NavigateUrl = "Gmwisereports.aspx?status=3&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];

            h5b.NavigateUrl = "Gmwisereports.aspx?status=4&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];

            h6.NavigateUrl = "Gmwisereports.aspx?status=5&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "Gmwisereports.aspx?status=6&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "Gmwisereports.aspx?status=7&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];

            h6c.NavigateUrl = "Gmwisereports.aspx?status=8&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6kl = (HyperLink)e.Row.Cells[8].Controls[0];
            h6kl.NavigateUrl = "Gmwisereports.aspx?status=9&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;








        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }

    protected void gvLevel2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            h1.NavigateUrl = "Gmwisereports.aspx?status=10&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;



            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];



            h5.NavigateUrl = "Gmwisereports.aspx?status=11&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District= " + DropDownList1.SelectedValue;
            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];

            h5a.NavigateUrl = "Gmwisereports.aspx?status=12&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];

            h5b.NavigateUrl = "Gmwisereports.aspx?status=13&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h13 = (HyperLink)e.Row.Cells[4].Controls[0];

            h13.NavigateUrl = "Gmwisereports.aspx?status=53&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District= " + DropDownList1.SelectedValue;
            HyperLink h12 = (HyperLink)e.Row.Cells[5].Controls[0];

            h12.NavigateUrl = "Gmwisereports.aspx?status=54&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h14 = (HyperLink)e.Row.Cells[6].Controls[0];

            h14.NavigateUrl = "Gmwisereports.aspx?status=55&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];

            //h6.NavigateUrl = "Gmwisereports.aspx?status=20&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6a = (HyperLink)e.Row.Cells[8].Controls[0];
            //h6a.NavigateUrl = "Gmwisereports.aspx?status=21&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            //HyperLink h6b = (HyperLink)e.Row.Cells[9].Controls[0];
            //h6b.NavigateUrl = "Gmwisereports.aspx?status=22&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[10].Controls[0];
            h6c.NavigateUrl = "Gmwisereports.aspx?status=17&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6kl = (HyperLink)e.Row.Cells[11].Controls[0];
            h6kl.NavigateUrl = "Gmwisereports.aspx?status=18&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h6k2 = (HyperLink)e.Row.Cells[12].Controls[0];
            h6k2.NavigateUrl = "Gmwisereports.aspx?status=19&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h6k21 = (HyperLink)e.Row.Cells[13].Controls[0];
            h6k21.NavigateUrl = "Gmwisereports.aspx?status=23&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;






        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            h1.NavigateUrl = "Gmwisereports.aspx?status=24&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;



            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];



            h5.NavigateUrl = "Gmwisereports.aspx?status=25&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];

            h5a.NavigateUrl = "Gmwisereports.aspx?status=26&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];

            h5b.NavigateUrl = "Gmwisereports.aspx?status=27&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];

            h6.NavigateUrl = "Gmwisereports.aspx?status=28&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "Gmwisereports.aspx?status=29&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "Gmwisereports.aspx?status=30&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            h6c.NavigateUrl = "Gmwisereports.aspx?status=31&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6kl = (HyperLink)e.Row.Cells[8].Controls[0];
            h6kl.NavigateUrl = "Gmwisereports.aspx?status=32&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h6k2 = (HyperLink)e.Row.Cells[9].Controls[0];


            h6kl.NavigateUrl = "Gmwisereports.aspx?status=33&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;



        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            h1.NavigateUrl = "Gmwisereports.aspx?status=34&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;



            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];



            h5.NavigateUrl = "Gmwisereports.aspx?status=35&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];

            h5a.NavigateUrl = "Gmwisereports.aspx?status=36&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];

            h5b.NavigateUrl = "Gmwisereports.aspx?status=37&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];

            h6.NavigateUrl = "Gmwisereports.aspx?status=38&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "Gmwisereports.aspx?status=39&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "Gmwisereports.aspx?status=40&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            h6c.NavigateUrl = "Gmwisereports.aspx?status=41&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6kl = (HyperLink)e.Row.Cells[8].Controls[0];

            h6kl.NavigateUrl = "Gmwisereports.aspx?status=42&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;


        }

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];

            h1.NavigateUrl = "Gmwisereports.aspx?status=43&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;



            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];



            h5.NavigateUrl = "Gmwisereports.aspx?status=44&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];

            h5a.NavigateUrl = "Gmwisereports.aspx?status=45&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];

            h5b.NavigateUrl = "Gmwisereports.aspx?status=46&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];

            h6.NavigateUrl = "Gmwisereports.aspx?status=47&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "Gmwisereports.aspx?status=48&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "Gmwisereports.aspx?status=49&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            h6c.NavigateUrl = "Gmwisereports.aspx?status=50&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

            HyperLink h6f = (HyperLink)e.Row.Cells[8].Controls[0];

            h6f.NavigateUrl = "Gmwisereports.aspx?status=51&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;
            HyperLink h6k2 = (HyperLink)e.Row.Cells[9].Controls[0];

            h6k2.NavigateUrl = "Gmwisereports.aspx?status=52&fromdate=" + txtfromdate.Text + "&todate=" + txttodate.Text + "&District=" + DropDownList1.SelectedValue;

        }

    }

}