using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmSLCDashBoardfinalSaction : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string status = Request.QueryString["stage"].ToString().Trim();
            ds = gen.getProposedSLClistconvened();

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
        string SLcDate = ddlapplicationto.SelectedValue;
        string[] date = SLcDate.Split(' ');
        string[] date1 = date[0].Split('-');
        string status = Request.QueryString["stage"].ToString().Trim();
        ds = gen.getincentivesSLClistUpdated(date1[2] + "/" + date1[1] + "/" + date1[0], status);
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
            // added by chaitanya
            string status = Request.QueryString["stage"].ToString().Trim();

            string SLcDate = ddlapplicationto.SelectedValue;
            string[] date = SLcDate.Split(' ');
            string[] date1 = date[0].Split('-');
            string date2 = date1[0] + "/" + date1[1] + "/" + date1[2];
            string date3 = date1[2] + "-" + date1[1] + "-" + date1[0];

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;

            // commented by chaitanya
          //  Response.Redirect("SactionViewSLC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Proposeddate=" + ddlapplicationto.SelectedValue + "&date=" + ddlapplicationto.SelectedItem.Text);

            Response.Redirect("SactionViewSLC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Proposeddate=" + date3 + "&date=" + date2 + "&Stage=" + status);
       
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