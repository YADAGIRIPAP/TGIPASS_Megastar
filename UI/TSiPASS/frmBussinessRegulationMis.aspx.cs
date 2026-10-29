using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmBussinessRegulationMis : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    decimal Total1, pending1, Redress1, Reject1;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        LBLDATETIME.Text = System.DateTime.Now.ToString();
        try
        {
            ds = Gen.Bussinessregulationmis();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal Total = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "total"));
                Total1 = Total + Total1;


                decimal pending = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Draft"));
                pending1 = pending + pending1;

                decimal Redress = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fianl"));
                Redress1 = Redress + Redress1;

                //decimal Reject = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "reject"));
                //Reject1 = Reject + Reject1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //4,5,8,11
                e.Row.Cells[1].Text = "Total:";

                e.Row.Cells[2].Text = Total1.ToString();
                e.Row.Cells[3].Text = pending1.ToString();
                e.Row.Cells[4].Text = Redress1.ToString();
                //e.Row.Cells[5].Text = Reject1.ToString();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
}