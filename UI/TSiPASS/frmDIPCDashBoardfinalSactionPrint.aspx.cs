using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmDIPCDashBoardfinalSactionPrint : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string status = Request.QueryString["stage"].ToString().Trim();
            ds = gen.getProposedDIPClistconvened(Session["DistrictID"].ToString().Trim(), status);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlapplicationto.DataSource = ds.Tables[0];
                ddlapplicationto.DataValueField = "ProposedSLCDATENEW";
                ddlapplicationto.DataTextField = "ProposedSLCDATE";
                ddlapplicationto.DataBind();
            }

            //DataSet ds = new DataSet();
            //ds = gen.getincentivesSLClist();

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            //    grdDetailsPavallavaddiSC.DataBind();
            //}
        }
    }
    protected void btnupdatestatus_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string ProposedDate = "";
        string SLcDate = ddlapplicationto.SelectedValue;
        string[] SLcDatearr = SLcDate.Split(' ');
        SLcDate = SLcDatearr[0].ToString();
        //if (SLcDate.Contains('-'))
        //{
        //    string[] datett = SLcDate.Trim().Split('-');
        //    ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
        //}
        //else if (SLcDate.Contains('/'))
        //{
        //    string[] datett = SLcDate.Trim().Split('/');
        //    ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
        //}
        string status = Request.QueryString["stage"].ToString().Trim();
        ds = gen.getincentivesDIPClistUpdated(SLcDate, Session["DistrictID"].ToString().Trim(), status);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // trConvened.Visible = true;
            // txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;

           // Response.Redirect("SactionViewDIPCP.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Proposeddate=" + ddlapplicationto.SelectedValue + "&date=" + ddlapplicationto.SelectedItem.Text);
            Response.Redirect("ReleasePendingViewDIPCAgendaPrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + ddlapplicationto.SelectedItem.Text);
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblince") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);
            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }
}