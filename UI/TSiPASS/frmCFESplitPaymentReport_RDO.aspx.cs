using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class UI_TSIPASS_frmCFESplitPaymentReport_RDO : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal NumberofApprovalsappliedfor1;
    DB.DB con = new DB.DB();
    string within;
    //string within;
    protected void Page_Load(object sender, EventArgs e)
    {
        string rdo_Flag = Request.QueryString["rdoFlag"].ToString();
        if (!IsPostBack)
        {
            if (rdo_Flag == "Y")
            {
                Label1.Text = "Report as on date " + DateTime.Now.ToString() + "";

                rdoPayments.Visible = true;
                lblHeading.Text = "RDO Payments transfer pending";
                DataSet ds_RDO = new DataSet();
                ds_RDO = getRDOPaymentDet();
                grdRDOPayments.Visible = true;
                grdRDOPayments.DataSource = ds_RDO.Tables[0];
                grdRDOPayments.DataBind();
            }
        }
    }

    protected void grdRDOPayments_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdRDOPayments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {


    }
   

    public DataSet getRDOPaymentDet()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("getRDOPaymentPending", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    protected void grdRDOPayments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //decimal within, beyond, totalexplaination, explainationaccepted, explainationnotaccepted, showcausereplied, pendingataddl, pendingatgm;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal within1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending Units"));
            within = within1 + within;




            HyperLink h9 = (HyperLink)e.Row.FindControl("HyNOOFPendingUnits");
            h9.NavigateUrl = "frmRDOPaymentDrillDown.aspx?district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "deptID")).Trim();

            


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //decimal within, beyond, totalexplaination, explainationaccepted, explainationnotaccepted, showcausereplied, pendingataddl, pendingatgm;
            e.Row.Cells[1].Text = "Total";

            //HyperLink withintotal = new HyperLink();
            //withintotal.Text = within.ToString();
            //e.Row.Cells[2].Text = within.ToString();
            //e.Row.Cells[2].Controls.Add(withintotal);
            ////withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&district=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DISTRICTID")).Trim() + "&StatusFlag=1";
            //withintotal.NavigateUrl = "frmGMDelayResonseDrillDownCOI.aspx?district=ALL" + "&StatusFlag=1";
            //withintotal.ForeColor = System.Drawing.Color.White;
            
        }
    }
}