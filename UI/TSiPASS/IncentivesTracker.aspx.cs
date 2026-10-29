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


public partial class UI_TSiPASS_IncentivesTracker : System.Web.UI.Page
{
    General Gen = new General();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dspay = new DataSet();
            string Enterid = "";
            if (Request.QueryString.Count > 0)
            {
                Enterid = Request.QueryString["Enterid"].ToString();
            }

            dspay = Gen.GetEnterincetracker(Enterid);
            if (dspay != null && dspay.Tables.Count > 1 && dspay.Tables[1].Rows.Count > 0)
            {
                grdDetails.DataSource = dspay.Tables[1];
                grdDetails.DataBind();
            }
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);
            Label lblintstageid = (e.Row.FindControl("lblintstageid") as Label);
            HyperLink anchortagGMCertificate = (e.Row.FindControl("anchortagGMCertificate") as HyperLink);
            HyperLink anchortagFbkForm = (e.Row.FindControl("anchortagFbkForm") as HyperLink);

            if (lblintstageid.Text == "32")
            {
                anchortagGMCertificate.Text = "Intimation Letter";
                anchortagGMCertificate.Enabled = true;
                anchortagGMCertificate.Visible = true;
                anchortagFbkForm.Visible = true;
                anchortagGMCertificate.NavigateUrl = "ReleasePendingViewUser.aspx?Enterid=" + enterid.Text + "&MstIncentiveId=" + MstIncentiveId.Text;
                (e.Row.FindControl("anchortagFbkForm") as HyperLink).NavigateUrl = "IncentivesFeedBackForm.aspx?UserId=" + Session["uid"].ToString();
            }
            else
            {
                anchortagGMCertificate.Visible = false;
                anchortagFbkForm.Visible = false;
                anchortagGMCertificate.Enabled = false;
                anchortagGMCertificate.Text = "";
            }
        }
    }
}