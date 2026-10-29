using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class UI_TSiPASS_frmViewAppl_DrillingRigsDepartmentuser : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();

    string rstages = "0";

    Cls_DrillingRigs obj_dashboard = new Cls_DrillingRigs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();
        }
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            GetDetails();
        }
    }

    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            DataSet dsn = new DataSet();
            dsn = obj_dashboard.GetShowDepartmentFiles_DrillingRigsDept(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
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
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            #region      
            grdDetails.Columns[9].Visible = false;
            if (rstages == "11" || rstages == "12")
            {
                grdDetails.Columns[9].Visible = true;
            
            }

            #endregion
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            #region
            HyperLink hyp_Applicationform = (HyperLink)e.Row.FindControl("hyp_Applicationform");
            HyperLink hyp_paymentdetails = (HyperLink)e.Row.FindControl("hyp_paymentdetails");
            HyperLink hyp_attachments = (HyperLink)e.Row.FindControl("hyp_attachments");
            HyperLink hyp_approveapplication = (HyperLink)e.Row.FindControl("hyp_approveapplication");

            //Label lbl_userqueryresponse = (Label)e.Row.FindControl("lbl_userqueryresponse");
            HyperLink hyp_userqueryrespose = (HyperLink)e.Row.FindControl("hyp_userqueryrespose");



            string QueryresponseDate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryresponseDate")).Trim();
            string QueryRaisedDate = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRaisedDate")).Trim();
            hyp_userqueryrespose.Visible = false;
            hyp_userqueryrespose.NavigateUrl = "frmqueryresponsetodepartment_DrillingsRigsDept.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            if (!string.IsNullOrEmpty(QueryRaisedDate))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.Text = "Query Raised";
                hyp_userqueryrespose.ForeColor = System.Drawing.Color.Red;  
            }

            if (!string.IsNullOrEmpty(QueryresponseDate))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.Text = "Query Responded";
                hyp_userqueryrespose.ForeColor = System.Drawing.Color.Green;
            }


            hyp_Applicationform.Target = "_blank";
            hyp_Applicationform.NavigateUrl = "DrillingRigsBorewellPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_paymentdetails.Target = "_blank";
            hyp_paymentdetails.NavigateUrl = "UserDrillingrigsborewellsPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_attachments.Target = "_blank";
            hyp_attachments.NavigateUrl = "UserDrillingRigsAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNo")).Trim();
            LinkButton lnk_uid_no = (LinkButton)e.Row.FindControl("lnk_uid_no");
            lnk_uid_no.OnClientClick = "javascript:return Popup('" + intUid + "')";

            Label lbl_rejetedstatusofapplication = (Label)e.Row.FindControl("lbl_rejetedstatusofapplication");
            lbl_rejetedstatusofapplication.Visible = false;

            string StageId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")).Trim();
            string ReasonForRejection = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ReasonForRejection")).Trim();

                if (!string.IsNullOrEmpty(ReasonForRejection))
                {
                    lbl_rejetedstatusofapplication.Visible = true;
                    lbl_rejetedstatusofapplication.Text = "Reason for  Rejection:  " + ReasonForRejection;
                }

            hyp_approveapplication.Visible = false;
            if (StageId == "4" || StageId == "8" || StageId == "9")
            {
                //7   Application Recommened to MRO by Ground Water Department
                if (rstages == "11" || rstages == "12")
                {
                    hyp_approveapplication.Visible = true;
                    //hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_DrillingRigs.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                    hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_DrillingRigs.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                    hyp_approveapplication.Text = "Query raise/Approve/Reject";

                    if (StageId == "8" || StageId == "9")
                    {
                        hyp_approveapplication.Text = "Approve/Reject";
                    }                    
                }

            }

            #endregion
        }
    }
   
}