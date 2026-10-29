using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_frmDashboardRedirect_UserDrillingRigs : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        hyp_back.NavigateUrl = "UserDrillingRigBorewellDashboard.aspx?Qnreid=" + Request.QueryString[0].ToString().Trim();
        string intquestionnaireid = "";
        string status = Request.QueryString[1].ToString().Trim();
        intquestionnaireid = Request.QueryString[0].ToString().Trim();
        Label1.Text= Request.QueryString[1].ToString().Trim();
        if (!IsPostBack)
        {
            DataSet ds = getEnterprenuerDrilligRigsdashboarddrilldown(status, Request.QueryString[0].ToString().Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();

            }
            if(status== "Queries -Yet to Respond")
            {
                grdDetails.Columns[3].Visible = true;
            }
            else
            {
                grdDetails.Columns[3].Visible = false;
            }
        }
    }



    public DataSet getEnterprenuerDrilligRigsdashboarddrilldown(string status, string intQuessionaireid)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
        con.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("Rigs_getEnterprenuer_DrilligRigsdashboarddrilldown", con);
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

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            HyperLink anchortaglink_queryrespond = (HyperLink)e.Row.FindControl("anchortaglink_queryrespond");
            HyperLink anchortaglink_applicationform = (HyperLink)e.Row.FindControl("anchortaglink_applicationform");
            HyperLink anchortaglink_payment = (HyperLink)e.Row.FindControl("anchortaglink_payment");
            HyperLink anchortaglink_attachment = (HyperLink)e.Row.FindControl("anchortaglink_attachment");

            HyperLink hyp_viewqueryresponse = (HyperLink)e.Row.FindControl("hyp_viewqueryresponse");
            hyp_viewqueryresponse.Visible = false;

            HyperLink anchortaglink_approvalrejectedattachment = (HyperLink)e.Row.FindControl("anchortaglink_approvalrejectedattachment");
            anchortaglink_approvalrejectedattachment.Visible = false;
            anchortaglink_applicationform.Target = "_blank";
            anchortaglink_applicationform.NavigateUrl = "DrillingRigsBorewellPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_payment.Target = "_blank";
            anchortaglink_payment.NavigateUrl = "UserDrillingrigsborewellsPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            anchortaglink_attachment.Target = "_blank";
            anchortaglink_attachment.NavigateUrl = "UserDrillingRigsAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            if(!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid"))))
            {
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
                if(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid"))=="5" || 
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid")) == "6" || 
                    Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid")) == "7")
                {
                    anchortaglink_queryrespond.Visible = true;
                    anchortaglink_queryrespond.Target = "_blank";
                    anchortaglink_queryrespond.NavigateUrl = "frmResponceQueries_UserDrillingRigs.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                }
                else
                {
                    anchortaglink_queryrespond.Visible = false;
                }
            }

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
                {
                    hyp_viewqueryresponse.Visible = true;
                    hyp_viewqueryresponse.NavigateUrl = "frmqueryresponseview_DrillingsRigsUser.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim()+ "&intDeptid="+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();
                }
            }
               
           
        }
    }
}