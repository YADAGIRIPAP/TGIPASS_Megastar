using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_UserDrillingRigsborewelllist : System.Web.UI.Page
{
    Cls_DrillingRigs obj_dashboard = new Cls_DrillingRigs();

 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (!IsPostBack)
            {
                getdetails();
            }
        }
                
    }


    public void getdetails()
    {
        try
        {
            if (Session["uid"] != null)
            {
                string UserID = Session["uid"].ToString();
                DataSet ds = obj_dashboard.GETDrillingrigsdahboardlist(Convert.ToInt32(UserID));

                if (ds.Tables.Count >= 1)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                    {
                        trApplyAgainbtn.Visible = false;
                    }
                    else
                    {
                        trApplyAgainbtn.Visible = true;
                    }
                }
                else if (ds.Tables.Count == 0)
                {
                    Response.Redirect("Registrationfordrillingrigshandboring.aspx?status=B", false);
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
            

            string intApplicationID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid"));
            string Approval_Status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_Status"));

            anchortaglinkApplicationstatus.Enabled = false;
            anchortaglinkApplicationstatus.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationStatus"));


            anchortaglink.NavigateUrl = "UserDrillingRigBorewellDashboard.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkprint.NavigateUrl = "DrillingRigsBorewellPrint.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkpayment.NavigateUrl = "UserDrillingrigsborewellsPaymentDetails.aspx?Qnreid=" + intApplicationID.Trim();
            anchortaglinkattachment.NavigateUrl = "UserDrillingRigsAttachments.aspx?intApplicationId=" + intApplicationID.Trim();
            if (Convert.ToInt32(Approval_Status) > 3)
            {
                anchortaglinkStatus.NavigateUrl = "RptApplicationWiseDetailedTrakerDrillingRigs.aspx?intqnreid=" + intApplicationID.ToString();
                anchortaglinkStatus.Text = "Track";
                anchortaglinkStatus.Enabled = true;
            }
            else if (Approval_Status == "2" || Approval_Status == "3")
            {
                anchortaglinkStatus.NavigateUrl = "Registrationfordrillingrigshandboring.aspx?status=B&id=" + intApplicationID.Trim();
                anchortaglinkStatus.Text = "Incomplete Application";
            }
            if(Approval_Status == "5" || Approval_Status == "6" || Approval_Status == "7")
            {
                anchortaglinkApplicationstatus.Enabled = true;
                anchortaglinkApplicationstatus.NavigateUrl = "frmResponceQueries_UserDrillingRigs.aspx?intApplicationId=" + Convert.ToString(intApplicationID).Trim();
            }
        }

    }

    protected void btnApplyAgain_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registrationfordrillingrigshandboring.aspx?status=A");
    }
}