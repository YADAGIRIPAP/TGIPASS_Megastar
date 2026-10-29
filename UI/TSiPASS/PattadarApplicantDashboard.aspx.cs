using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class UI_TSiPASS_PattadarApplicantDashboard : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["DashType"] != null && Request.QueryString["DashType"].ToString() != "")
        //{
        //    Session["DashType"] = Request.QueryString["DashType"].ToString();
        //    getdetails();
        //}
        getdetails();
    }




    public void getdetails()
    {
        try
        {
            osqlConnection.Open();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            DataSet oDataSet = new DataSet();

            oSqlDataAdapter = new SqlDataAdapter("GetPattadarApplicantDashboardData", osqlConnection);

            oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (Session["uid"] != null)
            {
                string text = Session["uid"].ToString();
                oSqlDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Session["uid"].ToString();
                oSqlDataAdapter.Fill(oDataSet);

                if (oDataSet.Tables.Count >= 1)
                {
                    grdDetails.DataSource = oDataSet.Tables[0];
                    grdDetails.DataBind();

                    if (oDataSet.Tables.Count > 1 && oDataSet.Tables[1].Rows.Count > 0)
                    {
                        //grdDetails.FindControl("anchortaglinkprint") = "Rejected";
                        trApplyAgainbtn.Visible = false;
                    }
                    else
                    {
                        trApplyAgainbtn.Visible = true;
                    }
                }
                else if (oDataSet.Tables.Count == 0)
                {
                   
                    Response.Redirect("frmpattalandsapplicationform.aspx?status=B", false);
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
            //HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);
            //HyperLink anchortaglink = (e.Row.FindControl("anchortaglink") as HyperLink);
            HyperLink anchortaglinkprint = (e.Row.FindControl("anchortaglinkprint") as HyperLink);
            HyperLink Attachments = (e.Row.FindControl("Attachments") as HyperLink);

            //string intApplicationID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
            string ID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
            string stageid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageID"));
            //string Approval_Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_Status"));

            anchortaglinkprint.NavigateUrl = "PrintPattalandappl.aspx??PattalandApplid=" + ID.Trim();
            Attachments.NavigateUrl= "frmViewPattalandattachments.aspx?PattalandApplid="+Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PATTADARID")).Trim()
            + "&StageID=" + stageid + "&ID=" + ID;
            //attachmnt.NavigateUrl = "frmViewPattalandattachments.aspx?PattalandApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PATTADARID")).Trim()
            //+ "&StageID=" + Request.QueryString[0].ToString().Trim() + "&ID=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
            //HdfApprovalid.Value = (e.Row.FindControl("anchortaglinkprint").ToString());
        }

    }

    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmpattalandsapplicationform.aspx?status=A");
    }
}