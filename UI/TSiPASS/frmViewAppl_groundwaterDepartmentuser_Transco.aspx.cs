using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmViewAppl_groundwaterDepartmentuser_Transco : System.Web.UI.Page
{

    string rstages = "0";
    comFunctions cmf = new comFunctions();
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/tshome.aspx");
        }
        if (Request.QueryString.Count > 0)
        {
            rstages = Convert.ToString(Request.QueryString[0]).Trim();
            lbl_title.Text = Convert.ToString(Request.QueryString[1]);
            if (!IsPostBack)
            {
                GetDetails();
            }
        }
    }

    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            DataSet dsn = new DataSet();
            dsn = obj_dashboard.GetShowDepartmentFiles_grounwaterDept_Transco(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            grdDetails.Columns[9].Visible = false;
            if (rstages == "2" || rstages == "3")
            {
                //Stg=2&Pre-Scrutiny-Pending Within 3 Days
                //Stg=3&Pre-Scrutiny-Pending Beyond 3 Days
                grdDetails.Columns[9].Visible = true;
            }
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            #region
            LinkButton lnk_uid_no = (LinkButton)e.Row.FindControl("lnk_uid_no");
            Label lbl_rejetedstatusofapplication = (Label)e.Row.FindControl("lbl_rejetedstatusofapplication");
            HyperLink hyp_Applicationform = (HyperLink)e.Row.FindControl("hyp_Applicationform");
            HyperLink hyp_attachments = (HyperLink)e.Row.FindControl("hyp_attachments");
            HyperLink hyp_paymentdetails = (HyperLink)e.Row.FindControl("hyp_paymentdetails");

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            //lnk_uid_no.OnClientClick = "javascript:return Popup('" + intUid + "')";

            hyp_Applicationform.Target = "_blank";
            hyp_Applicationform.NavigateUrl = "GroundWaterPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_attachments.Target = "_blank";
            hyp_attachments.NavigateUrl = "UserGroundwaterAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_paymentdetails.Target = "_blank";
            hyp_paymentdetails.NavigateUrl = "UserGroundwaterPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            lbl_rejetedstatusofapplication.Visible = false;
            string ReasonForRejection = "";
            string MRORejectedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason")).Trim();
            string DGWORejetedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason")).Trim();
            string TRANSCORejectedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSCORejectedReason")).Trim();

            if (!string.IsNullOrEmpty(MRORejectedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = "Reason for MRO Rejection:  " + MRORejectedReason + "," + "\n";
            }
            if (!string.IsNullOrEmpty(DGWORejetedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = ReasonForRejection + "Reason for Ground Water Department Rejection:  " + DGWORejetedReason + "\n";
            }
            if (!string.IsNullOrEmpty(TRANSCORejectedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = ReasonForRejection + "Reason for Ground Water Department Rejection:  " + TRANSCORejectedReason + "\n";
            }

            lbl_rejetedstatusofapplication.Text = ReasonForRejection;

            HyperLink hyp_approveapplication = (HyperLink)e.Row.FindControl("hyp_approveapplication");
            hyp_approveapplication.Visible = false;
            string StageId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid")).Trim();
            string DWGORejected = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGORejected")).Trim();
            string DWGOApprovedby = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOApprovedby")).Trim();

            if (StageId == "4")
            {
                //4   Application Submitted and Payment Made
                if (rstages == "2" || rstages == "3")
                {
                    //Stg=2&Pre-Scrutiny-Pending Within 3 Days
                    //Stg=3&Pre-Scrutiny-Pending Beyond 3 Days
                    hyp_approveapplication.Visible = true;
                    hyp_approveapplication.Text = "Query Raise/Approve/Reject";
                    hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_TRANSCOgroundwater.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }
            if (StageId == "9")
            {
                //Query Responded action should take by department
                if (rstages == "2" || rstages == "3")
                {
                    //Stg=2&Pre-Scrutiny-Pending Within 3 Days
                    //Stg=3&Pre-Scrutiny-Pending Beyond 3 Days
                    hyp_approveapplication.Visible = true;
                    hyp_approveapplication.Text = "Approve/Reject";
                    hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_TRANSCOgroundwater.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }

            HyperLink hyp_userqueryrespose = (HyperLink)e.Row.FindControl("hyp_userqueryrespose");
            hyp_userqueryrespose.Visible = false;
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaisedby"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaiseddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRespondeddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            #endregion
        }
    }

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
    }






}