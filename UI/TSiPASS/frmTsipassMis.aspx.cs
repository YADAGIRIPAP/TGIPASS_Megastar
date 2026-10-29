using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmTsipassMis : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    decimal Total1, pending1, Redress1, Reject1;
    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
    //    string FromdateforDB = "", TodateforDB = "";
    //    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        if (!IsPostBack)
        {
            LBLDATETIME.Text = System.DateTime.Now.ToString();
            if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
            {
                // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                FillGrid();
            }
            else
            {
                txtFromDate.Text = "01-04-2016";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                FillGrid();
            }
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
        }

       
    }
    protected void grddetailscfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
        //    Total1 = Total + Total1;


        //    decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Within Time Lines"));
        //    pending1 = pending + pending1;

        //    decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Beyond Time Lines"));
        //    Redress1 = Redress + Redress1;

        //    //decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
        //    //Reject1 = Reject + Reject1;
        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    //4,5,8,11
        //    e.Row.Cells[1].Text = "Total:";

        //    e.Row.Cells[2].Text = Total1.ToString();
        //    e.Row.Cells[3].Text = pending1.ToString();
        //    e.Row.Cells[4].Text = Redress1.ToString();
        //    //e.Row.Cells[5].Text = Reject1.ToString();
        //}
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Failure.Visible = false;
        lblmsg0.Text = "";
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date ";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date";
            valid = 1;
        }
        if (valid == 0)
        {
            string fromdt = "", Todt = "";

            //fromdt = Convert.ToDateTime(txtFromDate.Text.Trim()).ToString("dd-MMM-yyyy");
            //Todt = Convert.ToDateTime(txtTodate.Text.Trim()).ToString("dd-MMM-yyyy");
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " to " + txtTodate.Text.Trim();

            FillGrid();
        }
        else
        {
            ClearFields();
            Failure.Visible = true;
        }
    }
    private void FillGrid()
    {
        DataSet ds = new DataSet();
        grdDetails.DataSource = null;
        grdDetails.DataBind();

        string FromdateforDB = "", TodateforDB = "";
        FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        ds = Gen.Tsipassapplicationsmis(FromdateforDB, TodateforDB);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            lblcfetotal.Text = "Total CFE Applications Received :";
            lblcfetotal.Text = ds.Tables[0].Rows[0]["Total"].ToString().Trim();

            grdDetails.DataSource = ds.Tables[1];
            grdDetails.DataBind();


            lblcfototal.Text = "Total CFE Applications Received :";
            lblcfototal.Text = ds.Tables[2].Rows[0]["Total"].ToString().Trim();

            grddetailscfo.DataSource = ds.Tables[3];
            grddetailscfo.DataBind();


        }
    }
    void ClearFields()
    {
        //txtFromDate.Text = "";
        //txtFromDate.Text = "";
        grdDetails.DataSource = null;
        grdDetails.DataBind();
       
        Label1.Text = "";
    }
}