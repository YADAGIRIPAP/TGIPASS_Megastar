using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class UI_TSiPASS_FilmShootingUserDashboardList : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["DashType"] != null && Request.QueryString["DashType"].ToString() != "")
        {
            Session["DashType"] = Request.QueryString["DashType"].ToString();
            getdetails();
        }
        getdetails();
    }

    public void getdetails()
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();

            oSqlDataAdapter = new SqlDataAdapter("USP_GET_FilmShooting_DASHBOARD_HISTORY", osqlConnection);

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
                    Response.Redirect("frmFilmShootingApplication.aspx?status=B", false);
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
            HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);
            HyperLink anchortaglink = (e.Row.FindControl("anchortaglink") as HyperLink);
            HyperLink anchortaglinkprint = (e.Row.FindControl("anchortaglinkprint") as HyperLink);
            HyperLink anchortaglinkpayment = (e.Row.FindControl("anchortaglinkpayment") as HyperLink);

            string intApplicationID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RENENTERPID"));
            string Approval_Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_Status"));

            anchortaglink.NavigateUrl = "frmUserFilmShootingDashboard.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkprint.NavigateUrl = "FilmShootingPrint.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkpayment.NavigateUrl = "UserFlimshootingtpaymentDetails.aspx?Qnreid=" + intApplicationID.Trim();
            if (Approval_Status == "3")
            {
                anchortaglinkStatus.NavigateUrl = "RptApplicationWiseDetailedTrakerFilmShooting.aspx?intqnreid=" + intApplicationID.ToString();
            }
            else if (Approval_Status == "2")
            {
                anchortaglinkStatus.NavigateUrl = "frmFilmShootingApplication.aspx?status=B&id=" + intApplicationID.Trim();
                anchortaglinkStatus.Text = "Incomplete Application";
            }



        }

    }

    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmFilmShootingApplication.aspx?status=A");
    }



}