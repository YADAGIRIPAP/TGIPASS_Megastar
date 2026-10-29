using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_IncentiveWiseListGMDIPC : System.Web.UI.Page
{
    General gen = new General();
    string code = "";
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            DataSet ods = new DataSet();
            SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
            if (Request.QueryString["code"] != null)
                code = Request.QueryString[1].ToString();
            if (code != null && code != "")
            {
                Session["code"] = code;
                osqlConnection.Open();

                try
                {
                    // USP_GET_LIST_INCENTIVEWISE_GM_ABSTRACT
                    // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_GM", con.GetConnection);
                    oSqlDataAdapter = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_GM_ABSTRACT_DIPC", osqlConnection);
                    oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@Dlcno", SqlDbType.VarChar).Value = Request.QueryString[0].ToString();
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString().Trim();
                    oSqlDataAdapter.SelectCommand.Parameters.Add("@code", SqlDbType.VarChar).Value = code;
                    
                    oSqlDataAdapter.Fill(ods);
                    oSqlDataAdapter.SelectCommand.CommandTimeout = 3600;
                    grdDetailsPavallavaddiSC.DataSource = ods.Tables[0];
                    grdDetailsPavallavaddiSC.DataBind();
                    grdAgreementNotUpload.DataSource = ods.Tables[1];
                    grdAgreementNotUpload.DataBind();
                    grdUploadPending.DataSource = ods.Tables[2];
                    grdUploadPending.DataBind();
                    gvOfflineApplications.DataSource = ods.Tables[3];
                    gvOfflineApplications.DataBind();
                    grdAbeyance.DataSource = ods.Tables[4];
                    grdAbeyance.DataBind();
                    osqlConnection.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    osqlConnection.Close();
                }
            }
            else
            {
                string test1, test2, test3;
                test1 = Request.QueryString[0].ToString();
                test2 = Session["DistrictID"].ToString().Trim();
                test3 = code;
                oSqlDataAdapter = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_GM_ABSTRACT_DIPC", osqlConnection);
                oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                oSqlDataAdapter.SelectCommand.Parameters.Add("@Dlcno", SqlDbType.VarChar).Value = Request.QueryString[0].ToString();
                oSqlDataAdapter.SelectCommand.Parameters.Add("@Distid", SqlDbType.VarChar).Value = Session["DistrictID"].ToString().Trim();
                oSqlDataAdapter.SelectCommand.CommandTimeout = 3600;
                oSqlDataAdapter.Fill(ods);
                grdDetailsPavallavaddiSC.DataSource = ods.Tables[0];
                grdDetailsPavallavaddiSC.DataBind();
                grdAgreementNotUpload.DataSource = ods.Tables[1];
                grdAgreementNotUpload.DataBind();
                grdUploadPending.DataSource = ods.Tables[2];
                grdUploadPending.DataBind();
                gvOfflineApplications.DataSource = ods.Tables[3];
                gvOfflineApplications.DataBind();
                grdAbeyance.DataSource = ods.Tables[4];
                grdAbeyance.DataBind();
                osqlConnection.Close();
            }

        }
    }
    // SC CAtegory

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdAgreementNotUpload.Rows[indexing].FindControl("Label4")).Text;
            //string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblCategory1 = ((Label)grdAgreementNotUpload.Rows[indexing].FindControl("lblCategory3")).Text;
            string lblsubinctype = ((Label)grdAgreementNotUpload.Rows[indexing].FindControl("lblSubIncTypeId0")).Text;

            Response.Redirect("ReleaseModuleUnitWiseGMDipc.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + lblsubinctype + "&Agreement=N");
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            //string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblsubinctype = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

            Response.Redirect("ReleaseModuleUnitWiseGMDipc.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + lblsubinctype + "&Agreement=Y");
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


    protected void grdAgreementNotUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label4") as Label);
            Button Button1 = (e.Row.FindControl("Button2") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }



    protected void btnOfflineapplications_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string lblMstIncentiveId = ((Label)gvOfflineApplications.Rows[indexing].FindControl("Label3")).Text;
        //string Sactionnumber = Request.QueryString[0].ToString();
        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
        string lblCategory1 = ((Label)gvOfflineApplications.Rows[indexing].FindControl("lblCategory1")).Text;
        string lblsubinctype = ((Label)gvOfflineApplications.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

        Response.Redirect("ReleaseModuleUnitWiseGMDipc.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncTypeId=" + lblsubinctype + "&Agreement=O");
    }

    protected void gvOfflineApplications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button2 = (e.Row.FindControl("btnOfflineapplications") as Button);

            if (enterid.Text == "")
            {
                Button2.Visible = false;
            }
        }
    }

    protected void agreementaftrNotupload_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string lblMstIncentiveId = ((Label)grdUploadPending.Rows[indexing].FindControl("Label3")).Text;
        //string Sactionnumber = Request.QueryString[0].ToString();
        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
        string lblCategory1 = ((Label)grdUploadPending.Rows[indexing].FindControl("lblCategory1")).Text;
        string lblsubinctype = ((Label)grdUploadPending.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

        Response.Redirect("ReleaseModuleUnitWiseGMDipc.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId +
            "&SubIncTypeId=" + lblsubinctype + "&Agreement=R");
    }

    protected void agreementaftrNotuploadAbeyance_Click(object sender, EventArgs e)
    {
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string lblMstIncentiveId = ((Label)grdAbeyance.Rows[indexing].FindControl("lblIncentiveTypID")).Text;
        //string Sactionnumber = Request.QueryString[0].ToString();
        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
        string lblCategory1 = ((Label)grdAbeyance.Rows[indexing].FindControl("lblCategory1")).Text;
        string lblsubinctype = ((Label)grdAbeyance.Rows[indexing].FindControl("lblSubIncTypeId")).Text;

        Response.Redirect("ReleaseModuleUnitWiseGMDipc.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId +
            "&SubIncTypeId=" + lblsubinctype + "&Agreement=A");
    }
    protected void grdAbeyance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblIncentiveTypID") as Label);
            Button Button2 = (e.Row.FindControl("agreementaftrNotuploadAbeyance") as Button);

            if (enterid.Text == "")
            {
                Button2.Visible = false;
            }
        }
    }


    protected void grdUploadPending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button2 = (e.Row.FindControl("agreementaftrNotupload") as Button);

            if (enterid.Text == "")
            {
                Button2.Visible = false;
            }
        }
    }
}