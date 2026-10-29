using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_TouragentDashboardList_User : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["DashType"] != null && Request.QueryString["DashType"].ToString() != "")
        {
            Session["DashType"] = Request.QueryString["DashType"].ToString();
            getdetails();
        }
        else
        {
            getdetails();
        }
    }

        public void getdetails()
        {
            try
            {
                osqlConnection.Open();
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
                DataSet oDataSet = new DataSet();

                oSqlDataAdapter = new SqlDataAdapter("GET_TOURISMAgent_DASHBOARD_HISTORY_USER", osqlConnection);

                oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (Session["uid"] != null)
                {
                    string text = Session["uid"].ToString();
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Session["uid"].ToString();
                    oSqlDataAdapter.Fill(oDataSet);

                    if (oDataSet.Tables.Count >= 1)
                    {
                        grdDetails.DataSource = oDataSet.Tables[0];
                        grdDetails.DataBind();

                        if (oDataSet.Tables.Count > 1 && oDataSet.Tables[1].Rows.Count > 0)
                        {
                            trApplyAgainbtn.Visible = false;
                        }
                        else
                        {
                            trApplyAgainbtn.Visible = true;
                        }
                    }
                    else if (oDataSet.Tables.Count == 0)
                    {
                        Response.Redirect("frmDraftQuestionnaireRegistrationOfTravelAgent.aspx?status=B", false);
                    }

                }
                else
                {
                    Response.Redirect("HomeDashboard.aspx");
                }

            }
            catch (Exception ex)
            {
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
                Label lblRENINTQNREID = (e.Row.FindControl("lblRENINTQNREID") as Label);
                HyperLink anchortaglinkAcknowledgement = (e.Row.FindControl("anchortaglinkAcknowledgement") as HyperLink);

                lblanchortaglinkPendingQueriesAtLevel.NavigateUrl = "frmDashboardRedirectTourismAgent.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                    "&status=" + "Queries -Yet to Respond" + "&check=" + "A";

                anchortaglink.NavigateUrl = "TourismAgent_UserDashboard.aspx?Qnreid=" + lblRENINTQNREID.Text.Trim();


                HyperLink lblanchortaghplRejectionAtLevel = (e.Row.FindControl("hplRejection") as HyperLink);
                if (lblanchortaghplRejectionAtLevel.Text != "0")

                    lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectTourismAgent.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                        "&status=" + "Pre-Scrutiny - Rejected" + "&check=" + "A";


                if (lblApplApprRejection.Text != "0")
                {
                    lblanchortaghplRejectionAtLevel.NavigateUrl = "frmDashboardRedirectTourismAgent.aspx?id=" + lblRENINTQNREID.Text.Trim() +
                    "&status=" + "Approval - Rejected" + "&check=" + "A";
                    lblanchortaghplRejectionAtLevel.Text = lblApplApprRejection.Text;
                }

                Label lblApprovalStatus = (e.Row.FindControl("lblApprovalStatus") as Label);
                if (lblApprovalStatus.Text == "3")
                {

                    string intqnreid = lblRENINTQNREID.Text.ToString();
                    anchortaglinkStatus.NavigateUrl = "RptApplicationWiseDetailedTrakerTourismAgent_User.aspx?intqnreid=" + intqnreid.ToString();
                    anchortaglinkAcknowledgement.NavigateUrl = "AcknowledgmentEntrPrintTravel.aspx?intqnreid=" + intqnreid.ToString();
                }
                else if (lblApprovalStatus.Text == "2")
                {
                    //Label lblRENINTQNREID = (e.Row.FindControl("lblRENINTQNREID") as Label);
                    //string intqnreid = lblRENINTQNREID.Text.ToString();
                    anchortaglinkStatus.NavigateUrl = "frmDraftQuestionnaireRegistrationOfTravelAgent.aspx?status=B&id=" + lblRENINTQNREID.Text.Trim();
                    anchortaglinkStatus.Text = "Incomplete Application";
                }



            }

        }

        protected void btnApplyAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDraftQuestionnaireRegistrationOfTravelAgent.aspx?status=A");
        }

    
}