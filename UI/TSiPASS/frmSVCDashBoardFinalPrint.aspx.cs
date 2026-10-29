using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class UI_TSiPASS_frmSVCDashBoardFinalPrint : System.Web.UI.Page
{

    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string status = Request.QueryString["stage"].ToString().Trim();
            if (status == "2")
            {
                tddatetext.InnerText = "Proposed SVC Date:";
                DataSet ds = new DataSet();
                ds = gen.getProposedSVClistconvened();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlapplicationto.DataSource = ds.Tables[0];
                    ddlapplicationto.DataValueField = "ProposedSVCDATEnew";
                    ddlapplicationto.DataTextField = "ProposedSVCDATE";
                    ddlapplicationto.DataBind();
                }
            }
            else
            {
                tddatetext.InnerText = "SVC Date:";
                DataSet ds = new DataSet();
                ds = GetCompletedSVC(status);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlapplicationto.DataSource = ds.Tables[0];
                    ddlapplicationto.DataValueField = "ProposedSVCDATEnew";
                    ddlapplicationto.DataTextField = "ProposedSVCDATE";
                    ddlapplicationto.DataBind();

                    ListItem li = new ListItem();
                    li.Text = "ALL";
                    li.Value = "0";
                    ddlapplicationto.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = "ALL";
                    li.Value = "0";
                    ddlapplicationto.Items.Insert(0, li);
                }


                //trConvened1.Visible = false;
                trConvened.Visible = false;
                btnupdatestatus_Click(sender, e);

            }

            if (status == "1")
            {
                trConvened1.Visible = false;
            }
            else
            {
                trConvened1.Visible = true;
            }
        }
    }

    public DataSet GetCompletedSVC(string stage)
    {
        DataSet ds = new DataSet();
        SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@status",SqlDbType.VarChar),
                
            };

        pp[0].Value = stage;

        ds = gen.GenericFillDs("USP_GET_LIST_INCENTIVEWISE_SVCDATE", pp);

        return ds;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string status = Request.QueryString["stage"].ToString().Trim();
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string SLcDate = "";
            string[] date = null;
            string[] date1 = null;
            string date2 = "";
            string date3 = "";

            //if (status == "2")
            //{
            SLcDate = ddlapplicationto.SelectedValue;
            //date = SLcDate.Split(' ');
            //date1 = date[0].Split('-');
            //date2 = date1[2] + "/" + date1[1] + "/" + date1[0];
            //date3 = date1[2] + "-" + date1[1] + "-" + date1[0];

            //if (txtsvcdate.Text.Trim() == "")
            //{
            //    string message = "alert('Please Enter Convened SVC Date')";
            //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //    return;
            //}


            //  Response.Redirect("AssignSVCDate.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + ddlapplicationto.SelectedValue + "&Proposeddate=" + ddlapplicationto.SelectedItem.Text);
            Response.Redirect("AssignSVCDatePrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + SLcDate + "&Proposeddate=" + SLcDate + "&Stage=" + status);
            //}
            //else
            //{
            //    Response.Redirect("AssignSVCDatePrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&date=" + date2 + "&Proposeddate=" + date3 + "&Stage=" + status);
            //}
        }
        catch (Exception ex)
        {

        }
    }
    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblince") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);
            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }
    protected void btnupdatestatus_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        string status = Request.QueryString["Stage"].ToString().Trim();

        if (status == "2")
        {
            string SvcDate = ddlapplicationto.SelectedValue;
            string[] date = SvcDate.Split(' ');
            string[] date1 = date[0].Split('-');
            ds = gen.getincentivesSVClistconvened(date1[2] + "/" + date1[1] + "/" + date1[0], status);
        }
        else if (ddlapplicationto.SelectedValue == "0")
        {
            ds = gen.getincentivesSVClistconvened(null, status);
        }
        else
        {
            string SvcDate = ddlapplicationto.SelectedValue;
            string[] date = SvcDate.Split(' ');
            string[] date1 = date[0].Split('-');
            ds = gen.getincentivesSVClistconvened(date1[2] + "/" + date1[1] + "/" + date1[0], status);
        }

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (status == "2")
            {
                trConvened.Visible = true;
            }
            else if (ddlapplicationto.SelectedValue != "0")
            {
                //trConvened.Visible = true;
            }
            txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }

}