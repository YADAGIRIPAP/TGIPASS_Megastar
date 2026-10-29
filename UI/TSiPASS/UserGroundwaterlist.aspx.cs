using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_UserGroundwaterlist : System.Web.UI.Page
{
  
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        getdetails();
    }

    public void getdetails()
    {
        try
        {    
            if (Session["uid"] != null)
            {
                string UserID = Session["uid"].ToString();
                DataSet ds = obj_dashboard.GETGroundwaterdahboardlist(Convert.ToInt32(UserID));
              
                if (ds.Tables.Count >= 1)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                   
                }
                else if (ds.Tables.Count == 0)
                {
                    Response.Redirect("waltaform2.aspx?status=B", false);
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
        
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink anchortaglinkStatus = (e.Row.FindControl("anchortaglinkStatus") as HyperLink);
            HyperLink anchortaglink = (e.Row.FindControl("anchortaglink") as HyperLink);
            HyperLink anchortaglinkprint = (e.Row.FindControl("anchortaglinkprint") as HyperLink);
            HyperLink anchortaglinkpayment = (e.Row.FindControl("anchortaglinkpayment") as HyperLink);
            HyperLink anchortaglinkattachment = (e.Row.FindControl("anchortaglinkattachment") as HyperLink);
            HyperLink anchortaglinkApplicationstatus = (e.Row.FindControl("anchortaglinkApplicationstatus") as HyperLink);
            HyperLink anchortaglinkApplicationqueryraisedbytranscostatus = (e.Row.FindControl("anchortaglinkApplicationqueryraisedbytranscostatus") as HyperLink);

            anchortaglinkApplicationqueryraisedbytranscostatus.Visible = false;

            string intApplicationID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
            string Approval_Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_Status"));

            string DWGOQueryRaised = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaised"));
            string ISDWGOQueryResponded = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ISDWGOQueryResponded"));

            string GWTRASCOQueryRaised = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaised"));
            string GWTRASCOQueryResponded = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryResponded"));


            anchortaglinkApplicationstatus.Enabled = false;
            anchortaglinkApplicationstatus.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationStatus"));

            anchortaglink.NavigateUrl = "UserGroundwaterDashboard.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkprint.NavigateUrl = "GroundWaterPrint.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkpayment.NavigateUrl = "UserGroundwaterPaymentDetails.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkattachment.NavigateUrl = "UserGroundwaterAttachments.aspx?intApplicationId=" + intApplicationID.Trim();
            if (Convert.ToInt32(Approval_Status) >= 3)
            {
                anchortaglinkStatus.NavigateUrl = "RptApplicationWiseDetailedTrakerGroundwater.aspx?intApplicationId=" + intApplicationID.ToString();
                anchortaglinkStatus.Text = "Track";
                anchortaglinkStatus.Enabled = true;
            }
            else if (Approval_Status == "2" || Approval_Status == "3")
            {
                anchortaglinkStatus.NavigateUrl = "waltaform2.aspx?status=B&id=" + intApplicationID.Trim();
                anchortaglinkStatus.Text = "Incomplete Application";
            }
            if (Approval_Status == "5" || Approval_Status == "6" || Approval_Status == "7")
            {
                anchortaglinkApplicationstatus.Enabled = true;
                anchortaglinkApplicationstatus.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(intApplicationID).Trim()+"&ISTRANSCOqueryraised=N";
            }
            if (Approval_Status == "12")
            {
                if(!string.IsNullOrEmpty(DWGOQueryRaised))
                {
                    if(DWGOQueryRaised=="Y")
                    {
                        if (string.IsNullOrEmpty(ISDWGOQueryResponded) || ISDWGOQueryResponded == "N")
                        {
                            anchortaglinkApplicationstatus.Enabled = true;
                            anchortaglinkApplicationstatus.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(intApplicationID).Trim()+"&ISTRANSCOqueryraised=N";
                        }
                    }
                  
                }
                if (GWTRASCOQueryRaised == "Y")
                {
                    if (string.IsNullOrEmpty(GWTRASCOQueryResponded) || GWTRASCOQueryResponded == "N")
                    {
                        anchortaglinkApplicationqueryraisedbytranscostatus.Text = "Query Raised by District TRASCO Department";
                        anchortaglinkApplicationqueryraisedbytranscostatus.Visible = true;
                        anchortaglinkApplicationqueryraisedbytranscostatus.Enabled = true;
                        anchortaglinkApplicationqueryraisedbytranscostatus.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(intApplicationID).Trim() + "&ISTRANSCOqueryraised=Y";
                    }
                }


            }

        }

    }

    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("waltaform2.aspx?status=A");
    }
}