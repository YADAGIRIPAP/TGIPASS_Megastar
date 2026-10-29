using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmDIPCDashBoardfinalSaction : System.Web.UI.Page
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

            if (status == "4")
            {
                btnupdatestatus.Text = "Get Data";
                tdnamehead.InnerText = "Abeyanced DIPC Date: ";
            }
            else
            {
                btnupdatestatus.Text = "Get Updated Proposed DIPC Agenda";
                tdnamehead.InnerText = "Proposed DIPC Date: ";
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
        string SLcDate = ddlapplicationto.SelectedValue;

        string[] datett = new string[3];

        if (SLcDate.Contains("-"))
        {
            datett = SLcDate.Trim().Split('-');
        }
        if (SLcDate.Contains("/"))
        {
            datett = SLcDate.Trim().Split('/');
        }
       
        //string ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];   // modified on 23.09.2017
        string ProposedDate = datett[2] + "/" + datett[0] + "/" + datett[1];
        string status = Request.QueryString["stage"].ToString().Trim();
        ds = gen.getincentivesDIPClistUpdated(ProposedDate, Session["DistrictID"].ToString().Trim(), status);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // trConvened.Visible = true;
            // txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
            btnprint.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string status = Request.QueryString["stage"].ToString().Trim();
            Response.Redirect("SactionViewDIPC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Proposeddate=" + ddlapplicationto.SelectedValue + "&date=" + ddlapplicationto.SelectedItem.Text + "&Status=" + status);
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