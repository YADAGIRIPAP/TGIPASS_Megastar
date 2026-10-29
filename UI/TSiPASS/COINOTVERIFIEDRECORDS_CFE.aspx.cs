using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;

public partial class UI_TSiPASS_COINOTVERIFIEDRECORDS_CFE : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = "13-07-2023";
            txtTodate.Text = System.DateTime.Now.ToString("d-MM-yyyy");
            Getlist_Click(sender, e);
        }
    }
    protected void Getlist_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Label2.Text = "";
        ERROR.Visible = false;
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            Label2.Text = "<br/> Please Enter 'From Date'";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            Label2.Text += "<br/> Please Enter 'To Date'";
            valid = 1;
        }
        if (valid == 0)
        {
            SqlParameter[] pp = new SqlParameter[]
                 {
                    new SqlParameter("@FROMDATE", SqlDbType.Date),
                    new SqlParameter("@TODATE", SqlDbType.Date)
                 };

            pp[0].Value = txtFromDate.Text;
            pp[1].Value = txtTodate.Text;
            DataSet ds2 = new DataSet();
            ds2 = gen.GenericFillDs("SP_GET_NOTVERIFIEDRECORDS", pp);
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                grdDetails.Visible = true;
                grdDetails.DataSource = ds2.Tables[0];
                grdDetails.DataBind();
                //trupdate.Visible = true;
            }
        }
        else
        {
            ERROR.Visible = true;
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // HyperLink h1 = (HyperLink)e.Row.Cells[12].Controls[0];
            // HyperLink h2 = (HyperLink)e.Row.Cells[13].Controls[0];
            // HyperLink h3 = (HyperLink)e.Row.Cells[14].Controls[0];

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");
            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";


        }
    }

}