using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSIPASS_frmCheckDetailsprintGenerated : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string DIPCFlag = "", UCSTATUS = "";
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
                DIPCFlag = "Y";
            }
            else
            {
                DIPCFlag = null;
            }
            if (Request.QueryString["Status"] != null && Request.QueryString["Status"].ToString() != "")
            {
                UCSTATUS = Request.QueryString["Status"].ToString();
            }
            if (UCSTATUS == "NUC")
            {
                tdworkstatus.Visible = false;
                ddlworkingstatus.Visible = false;
            }

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@DIPC",SqlDbType.VarChar)
            };
            pp[0].Value = DIPCFlag;
            DataSet ds2 = new DataSet();
            ds2 = gen.GenericFillDs("USP_GET_RELEASE_PROCEEDING_NOS_LIST_NEW", pp);
            //ds2 = gen.GetReleaseProceedingNosList();
            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
            {
                ddlReleaseProceedingNo.DataSource = ds2.Tables[0];
                ddlReleaseProceedingNo.DataValueField = "ReleaseProceedingNo";
                ddlReleaseProceedingNo.DataTextField = "ReleaseProceedingNo";
                ddlReleaseProceedingNo.DataBind();

                AddSelect(ddlReleaseProceedingNo);
            }
            ddlReleaseProceedingNo_SelectedIndexChanged(sender, e);
            txtsvcdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            Button2_Click(sender, e);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/frmCheckDetailsprintGenerated.aspx");
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--All--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
        }
    }
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            //string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;

            string lblsubInctypeid = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblInctypeId")).Text;

            string DIPCFlag = "";
            if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            {
                DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            }

            Response.Redirect("CheckListPrintGenerated.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text.Trim() + "&SubIncTypeId=" + lblsubInctypeid + "&RlsProceedNo=" + ddlReleaseProceedingNo.Text + "&DIPC=" + DIPCFlag
                + "&WORKINGSTATUS=" + ddlworkingstatus.SelectedValue + "&FromDate=" + ViewState["FromDate"].ToString() + "&ToDate=" + ViewState["ToDate"].ToString());

        }
        catch (Exception ex)
        {

        }
    }

    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lblmsg0.Text = "";
        if (ddlReleaseProceedingNo.Text.Trim() == "--Select--")
        {
            lblmsg0.Text = "Please Select Release Proceeding Number";
            lblmsg0.Visible = true;
            Failure.Visible = true;
            return;
        }
        else
        {
            lblmsg0.Text = "";
        }

        if (txtFromDate.Text.Trim() == null && txtFromDate.Text.Trim() == "")
        {
            lblmsg0.Text = "Please Select From Date";
        }
        if (txtFromDate.Text.Trim() == null && txtFromDate.Text.Trim() == "")
        {
            lblmsg0.Text += "Please Select To Date";
        }
        if (lblmsg0.Text.Trim() != null && lblmsg0.Text.Trim() != "")
        {
            lblmsg0.Visible = true;
            Failure.Visible = true;
            return;

        }
        else
        {
            lblmsg0.Visible = false;
            Failure.Visible = false;
        }

        string DIPCFlag = "";
        if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
        {
            DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            DIPCFlag = "Y";
        }
        else DIPCFlag = null;
        string ProposedDate = "";

        string FromDate = "";
        String ToDate = "";

        ViewState["FromDate"] = "";
        ViewState["ToDate"] = "";
        if (txtFromDate.Text.Trim().Contains('/'))
        {
            string[] datett = txtFromDate.Text.Trim().Split('/');
            FromDate = datett[2] + "/" + datett[1] + "/" + datett[0];

        }
        else if (txtFromDate.Text.Trim().Contains('-'))
        {
            string[] datett1 = txtFromDate.Text.Trim().Split('-');
            FromDate = datett1[2] + "/" + datett1[1] + "/" + datett1[0];
        }
        ViewState["FromDate"] = FromDate;

        if (txtToDate.Text.Trim().Contains('/'))
        {
            string[] datett2 = txtToDate.Text.Trim().Split('/');
            ToDate = datett2[2] + "/" + datett2[1] + "/" + datett2[0];
        }
        else if (txtToDate.Text.Trim().Contains('-'))
        {
            string[] datett3 = txtToDate.Text.Trim().Split('-');
            ToDate = datett3[2] + "/" + datett3[1] + "/" + datett3[0];
        }
        ViewState["ToDate"] = ToDate;

        ProposedDate = ddlReleaseProceedingNo.SelectedItem.Text.Trim();
        DataSet ds = new DataSet();
        ds = gen.getincentiveslclistWorkigngListcheckGenerated(ProposedDate, DIPCFlag, FromDate, ToDate, ddlworkingstatus.SelectedValue);


        grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
        grdDetailsPavallavaddiSC.DataBind();

    }
    protected void ddlReleaseProceedingNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReleaseProceedingNo.SelectedItem.Text.ToUpper() != "--SELECT--")
        {
            trdates.Visible = true;
            txtFromDate.Text = "01-08-2017";//System.DateTime.Now.ToString("dd/MM/yyyy");
            txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblmsg0.Visible = false;
            Failure.Visible = false;
        }
        else
        {
            trdates.Visible = false;
        }
    }
}