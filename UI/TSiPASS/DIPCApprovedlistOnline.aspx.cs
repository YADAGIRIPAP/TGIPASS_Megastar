using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSIPASS_DIPCApprovedlistOnline : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getallapproveddipcno();
            ddlApplicationMode.SelectedValue = "1";
            ddlApplicationMode.Enabled = false;

            if (Request.QueryString["Stg"].ToString() == "5")
            {
                DropDownList1.SelectedValue = "1";
            }
            else if (Request.QueryString["Stg"].ToString() == "6")
            {
                DropDownList1.SelectedValue = "2";
            }
            else if (Request.QueryString["Stg"].ToString() == "8")
            {
                DropDownList1.SelectedValue = "0";
            }
            else if (Request.QueryString["Stg"].ToString() == "7")
            {
                DropDownList1.SelectedValue = "0";
                ddlworkingstatus.SelectedValue = "3";
            }
            else if (Request.QueryString["Stg"].ToString() == "9")
            {
                DropDownList1.SelectedValue = "0";
                ddlworkingstatus.SelectedValue = "0";
            }

            Button2_Click(sender, e);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            //string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            //string status = Request.QueryString["Stg"].ToString().Trim();
            //string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            //string offlineflag = "";
            //if (Request.QueryString.Count > 1 && Request.QueryString[1].ToString() != "")
            //{
            //    offlineflag = Request.QueryString[1].ToString();
            //    Response.Redirect("ReleasePendingViewDIPC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Status=" + status + "&offlineflag=Y");
            //}
            //else
            //{
            //    offlineflag = null;
            //    Response.Redirect("ReleasePendingViewDIPC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Status=" + status);
            //}

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;

            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblSubIncType = "0";//((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;

            string AllApplicationstatus = "";

            if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
            {
                AllApplicationstatus = "ALL";
            }

            Response.Redirect("ReleasePendingViewDIPCOnline.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
            "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue + "&TIMELINES=" + DropDownList1.SelectedValue +
            "&DIPCNumber=" + ddlDIPCno.SelectedValue + "&ALLAPPSTATUS=" + AllApplicationstatus);

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
    public void getallapproveddipcno()
    {
        DataSet ds = new DataSet();
        string Distid = "";
        if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
        {
            Distid = Session["DistrictID"].ToString().Trim();
        }

        SqlParameter[] pp = new SqlParameter[] {
             
             new SqlParameter("@DISTCODE", SqlDbType.VarChar)
            };
        pp[0].Value = Distid;
        ds = gen.GenericFillDs("USP_GET_LIST_INCENTIVE_DIPCSanctionNO", pp);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDIPCno.DataSource = ds.Tables[0];
            ddlDIPCno.DataValueField = "DIPCNumer";
            ddlDIPCno.DataTextField = "DIPCNumerdate";
            ddlDIPCno.DataBind();
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "--ALL--";
            ddlDIPCno.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Value = "0";
            li.Text = "--ALL--";
            ddlDIPCno.Items.Insert(0, li);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string Distid = "";
        if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
        {
            Distid = Session["DistrictID"].ToString().Trim();
        }
        string AllApplicationstatus = "";

        if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
        {
            AllApplicationstatus = "ALL";
            DropDownList1.SelectedValue = "0";
            ddlworkingstatus.SelectedValue = "0";
            ddlDIPCno.SelectedValue = "0";
        }

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@APPMODE",SqlDbType.VarChar),
             new SqlParameter("@APPSTATUS", SqlDbType.VarChar),
             new SqlParameter("@slcno", SqlDbType.VarChar),
             new SqlParameter("@DISTCODE", SqlDbType.VarChar),
             new SqlParameter("@DIPCNumer", SqlDbType.VarChar),
             new SqlParameter("@AllApplication", SqlDbType.VarChar),
            };

        pp[0].Value = ddlApplicationMode.SelectedValue;
        pp[1].Value = ddlworkingstatus.SelectedValue;
        pp[2].Value = DropDownList1.SelectedValue;
        pp[3].Value = Distid;
        pp[4].Value = ddlDIPCno.SelectedValue;
        pp[5].Value = AllApplicationstatus;
        ds = gen.GenericFillDs("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_DIPC_DIPC_APPROVEDLIST", pp);

        //ds = gen.getincentiveDIPClist(Session["DistrictID"].ToString().Trim());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();

        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        ddlApplicationMode.SelectedValue = "0";
        ddlworkingstatus.SelectedValue = "0";
        grdDetailsPavallavaddiSC.DataSource = null;
        grdDetailsPavallavaddiSC.DataBind();
    }
}