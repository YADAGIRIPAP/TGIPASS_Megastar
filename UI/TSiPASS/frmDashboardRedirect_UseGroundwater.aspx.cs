using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmDashboardRedirect_UseGroundwater : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        hyp_back.NavigateUrl = "UserGroundwaterDashboard.aspx?Qnreid=" + Request.QueryString[0].ToString().Trim();
        string intquestionnaireid = "";
        if(Request.QueryString.Count>0)
        {
            intquestionnaireid = Request.QueryString[0].ToString().Trim();
            if (Request.QueryString.Count==2)
            {
                string status = Request.QueryString[1].ToString().Trim();
                lbl_headtitle.Text = status;
                if (!IsPostBack)
                {
                    DataSet ds = getEnterprenuergroundwaterdashboarddrilldown(status, intquestionnaireid);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds.Tables[0];
                        grdDetails.DataBind();
                    }
                    if (status == "Queries-Yet to Respond")
                    {
                        grdDetails.Columns[3].Visible = true;
                    }
                    else
                    {
                        grdDetails.Columns[3].Visible = false;
                    }
                }
            }              
        }
    }



    public DataSet getEnterprenuergroundwaterdashboarddrilldown(string status, string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {            
               da = new SqlDataAdapter("GW_getEnterprenuer_groundwaterdashboarddrilldown", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (status.Trim() == "" || status.Trim() == null)
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = status.ToString();

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.ToString();
            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            //throw ex;
            return null;
        }
        finally
        {
            con.Close();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
//        ID,ApplicationType_IndusorAgri,ApplicantName,DistrictID,MandalId,VillageId,Street,HouseNo,LocationOfWell,TypeofWell,TypeOfDrwngWater,
//SpecifactioncnOFPump,DistanceFromExistWell,StageId,paymentFlag,ApplicationType_IndusorAgriName,UID_No,App_Status,PaymentDate,
//DWGOApproved,DWGOApproveddate,DWGOApprovedby,FormRejectNumber,FormApproveNumber,FormAppNumber,DistrictName,MandalName,VillageName,
//ApplicantMobileNO,ApplicantEmailID,TypeofWellName,TypeOfDrwngWaterName,DWGORejected,DWGORejecteddate,DWGORejectedby,DWGOQueryRaised,
//DWGOQueryRaiseddate,DWGOQueryRaisedby,ISDWGOQueryResponded,MROApproveddate,MRORejecteddate,District_Name,Manda_lName,Village_Name,
//intCFEEnterpid,Address,Status,Query_RaiseDate,QueryRespondDate,MRORejectedReason,DGWORejetedReason
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink anchortaglink_applicationform = (HyperLink)e.Row.FindControl("anchortaglink_applicationform");
            HyperLink anchortaglink_payment = (HyperLink)e.Row.FindControl("anchortaglink_payment");
            HyperLink anchortaglink_attachment = (HyperLink)e.Row.FindControl("anchortaglink_attachment");
            
            anchortaglink_applicationform.Target = "_blank";
            anchortaglink_applicationform.NavigateUrl = "GroundWaterPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_payment.Target = "_blank";
            anchortaglink_payment.NavigateUrl = "UserGroundwaterPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_attachment.Target = "_blank";
            anchortaglink_attachment.NavigateUrl = "UserGroundwaterAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            Label lbl_grdrejectedremarks = (Label)e.Row.FindControl("lbl_grdrejectedremarks");
            Label lbl_queryraisedetails = (Label)e.Row.FindControl("lbl_queryraisedetails");
            Label lbl_queryresponsedetails = (Label)e.Row.FindControl("lbl_queryresponsedetails");
            lbl_grdrejectedremarks.Visible = false;
            lbl_queryraisedetails.Visible = false;
            lbl_queryresponsedetails.Visible = false;

            string Rejectedreason = "";
            if(!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason"))))
            {
                Rejectedreason ="MRO Rejected Reason:"+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason"))))
            {
                Rejectedreason += Rejectedreason+"Ground water Rejected Reason:"+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSCORejetedReason"))))
            {
                Rejectedreason = Rejectedreason + "TRANSCO Rejected Reason:" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSCORejetedReason"));
            }
            if(!string.IsNullOrEmpty(Rejectedreason))
            {
                lbl_grdrejectedremarks.Visible = true;
                lbl_grdrejectedremarks.Text = Rejectedreason;
            }
            string Queryraiseddate = "";
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                Queryraiseddate = "MRO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"))))
            {
                Queryraiseddate += Queryraiseddate + "DGWO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaiseddate"))))
            {
                Queryraiseddate = Queryraiseddate + "TRANSCO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaiseddate"));
            }
            if (!string.IsNullOrEmpty(Queryraiseddate))
            {
                lbl_queryraisedetails.Visible = true;
                lbl_queryraisedetails.Text = Queryraiseddate;
            }

            string Queryresponsedate = "";

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
            {
                Queryresponsedate = "MRO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
            {
                Queryresponsedate += Queryresponsedate+ "DGWO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"));
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRespondeddate"))))
            {
                Queryresponsedate = Queryresponsedate + "TRANSCO-" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRespondeddate"));
            }
          
            if (!string.IsNullOrEmpty(Queryresponsedate))
            {
                lbl_queryresponsedetails.Visible = true;
                lbl_queryresponsedetails.Text = Queryresponsedate;
            }

           



            HyperLink hyp_viewqueryresponse = (HyperLink)e.Row.FindControl("hyp_viewqueryresponse");
            hyp_viewqueryresponse.Visible = false;

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_GroundwaterUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaiseddate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_GroundwaterUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaiseddate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRespondeddate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_GroundwaterUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
            }




            HyperLink anchortaglink_approvalrejectedattachment = (HyperLink)e.Row.FindControl("anchortaglink_approvalrejectedattachment");
            anchortaglink_approvalrejectedattachment.Visible = false;

            HyperLink anchortaglink_queryrespond = (HyperLink)e.Row.FindControl("anchortaglink_queryrespond");

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId"))))
            {
                if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")) == "5" ||Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")) == "6" ||
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")) == "7")
                {
                    anchortaglink_queryrespond.Visible = true;
                    anchortaglink_queryrespond.Target = "_blank";
                    anchortaglink_queryrespond.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&ISTRANSCOqueryraised=N";
                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")) == "12" &&
              !string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaised")))
              && string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ISDWGOQueryResponded"))))
                {
                    anchortaglink_queryrespond.Visible = true;
                    anchortaglink_queryrespond.Target = "_blank";
                    anchortaglink_queryrespond.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim()+"&ISTRANSCOqueryraised=N";


                }
                else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StageId")) == "12" &&
                   !string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaised")))
                   && string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryResponded"))))
                {
                    anchortaglink_queryrespond.Visible = true;
                    anchortaglink_queryrespond.Target = "_blank";
                    anchortaglink_queryrespond.NavigateUrl = "frmResponceQueries_UserGroundwater.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim()+"&ISTRANSCOqueryraised=Y";


                }
                else
                {
                    anchortaglink_queryrespond.Visible = false;
                }

                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalDocument"))))
                {
                    anchortaglink_approvalrejectedattachment.ForeColor = System.Drawing.Color.Green;
                    anchortaglink_approvalrejectedattachment.Text = "Approval Document";
                    anchortaglink_approvalrejectedattachment.Visible = true;
                    anchortaglink_approvalrejectedattachment.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalDocument"));
                }
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedDocument"))))
                {
                    anchortaglink_approvalrejectedattachment.ForeColor = System.Drawing.Color.Red;
                    anchortaglink_approvalrejectedattachment.Text = "Rejected Document";
                    anchortaglink_approvalrejectedattachment.Visible = true;
                    anchortaglink_approvalrejectedattachment.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedDocument"));
                }

               
            }

           


        }
    }




}