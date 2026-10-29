using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Activities;

public partial class UI_TSIPASS_ExciseDashboardList : System.Web.UI.Page
{

    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        getdetails();
    }

    public void getdetails()
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();
            oSqlDataAdapter = new SqlDataAdapter("USP_GET_DASHBOARD_HISTORY_EXCISE", osqlConnection);
            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();
                oSqlDataAdapter.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Session["uid"].ToString();
                oSqlDataAdapter.Fill(oDataSet);
                if (oDataSet.Tables.Count >= 1)
                {
                    if (oDataSet.Tables[0].Rows.Count == 0)
                    {

                        Response.Redirect("frmRenewalService.aspx?status=B", false);
                    }
                    else
                    {
                        grdDetails.DataSource = oDataSet.Tables[0];
                        grdDetails.DataBind();
                    }

                }

                else if (oDataSet.Tables.Count == 0)
                {

                    Response.Redirect("frmRenewalService.aspx?status=B", false);
                }


            }
            else
            {
                Response.Redirect("HomeDashboard.aspx");
            }

        }
        catch (Exception ex)
        {
            throw ex;
            Response.Redirect("HomeDashboard.aspx");
        }
        finally
        {
            osqlConnection.Close();
        }
    }





    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label enterid = (e.Row.FindControl("lblRENENTERPID") as Label);
            Label lblApplApprRejection = (e.Row.FindControl("lblApplApprRejection") as Label);
            HyperLink lblanchortaglinkPendingQueriesAtLevel = (e.Row.FindControl("hplQueries") as HyperLink);
            HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);
            HyperLink anchortaglink = (e.Row.FindControl("anchortaglink") as HyperLink);
            Label lblCFOINTQNREID = (e.Row.FindControl("lblCFOINTQNREID") as Label);

            lblanchortaglinkPendingQueriesAtLevel.NavigateUrl = "HomeDashboard_Excise.aspx";

            anchortaglink.NavigateUrl = "HomeDashboard_Excise.aspx?Qnreid=" + lblCFOINTQNREID.Text.Trim();

            anchortaglinkStatus.NavigateUrl = "ApplicationTrakerDetailedCFO.aspx?Qnreid=" + lblCFOINTQNREID.Text.Trim();


            HyperLink lblanchortaghplRejectionAtLevel = (e.Row.FindControl("hplRejection") as HyperLink);
            if (lblanchortaghplRejectionAtLevel.Text != "0")

                lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectRenewal.aspx?id=" + lblCFOINTQNREID.Text.Trim() +
                    "&status=" + "Pre-Scrutiny - Rejected" + "&check=" + "A";
            if (lblApplApprRejection.Text != "0")
            {
                lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectRenewal.aspx?id=" + lblCFOINTQNREID.Text.Trim() +
                "&status=" + "Approval - Rejected" + "&check=" + "A";
                lblanchortaghplRejectionAtLevel.Text = lblApplApprRejection.Text;
            }





        }
    }
}