using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmSVCDashBoardFinal : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            string status = Request.QueryString["stage"].ToString().Trim();
            ds = gen.getProposedSVClistconvened();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlapplicationto.DataSource = ds.Tables[0];
                ddlapplicationto.DataValueField = "ProposedSVCDATEnew";
                ddlapplicationto.DataTextField = "ProposedSVCDATE";
                ddlapplicationto.DataBind();
            }
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
            string[] date4 = txtsvcdate.Text.Trim().Split('/');
            string date2 = date1[2] + "/" + date1[1] + "/" + date1[0];
            string date3 = txtsvcdate.Text.Trim(); //date4[2] + "/" + date4[1] + "/" + date4[0];

            if (txtsvcdate.Text.Trim() == "")
            {
                string message = "alert('Please Enter Convened SVC Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;

            //  Response.Redirect("AssignSVCDate.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + ddlapplicationto.SelectedValue + "&Proposeddate=" + ddlapplicationto.SelectedItem.Text);
            Response.Redirect("AssignSVCDate.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + date2 + "&Proposeddate=" + date3 + "&Stage=" + status);
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
    protected void btnupdatestatus_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string SvcDate = ddlapplicationto.SelectedValue;
        string[] date = SvcDate.Split(' ');
        string[] date1 = date[0].Split('-');
        string status = Request.QueryString["Stage"].ToString().Trim();
        ds = gen.getincentivesSVClistconvened(date1[2] + "/" + date1[1] + "/" + date1[0], status);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            trConvened.Visible = true;
            txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }
}