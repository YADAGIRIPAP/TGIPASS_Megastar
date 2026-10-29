using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;
using DataAccessLayer;
using System.Web.UI;


public partial class UI_TSiPASS_IncentiveWiseSLClistGM : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    SqlDataAdapter myDataAdapter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            if (Session["uid"] != null)
            {
                ds = getincentiveslclist(Session["uid"].ToString().Trim());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
                    grdDetailsPavallavaddiSC.DataBind();
                }
                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                // SC CAtegoty
                //grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
                //grdDetailsPavallavaddiSC.DataBind();

                //gvInvestmentSubsidySC.DataSource = ds.Tables[1];
                //gvInvestmentSubsidySC.DataBind();

                //gvGeneralSC.DataSource = ds.Tables[2];
                //gvGeneralSC.DataBind();

                //// ST CAtegoty
                //gvPavallavaddiST.DataSource = ds.Tables[3];
                //gvPavallavaddiST.DataBind();

                //gvInvestmentSubsidyST.DataSource = ds.Tables[4];
                //gvInvestmentSubsidyST.DataBind();

                //gvGeneralST.DataSource = ds.Tables[5];
                //gvGeneralST.DataBind();

                //// General CAtegoty
                //gvPavallavaddiGeneral.DataSource = ds.Tables[6];
                //gvPavallavaddiGeneral.DataBind();

                //gvInvestmentSubsidyGeneral.DataSource = ds.Tables[7];
                //gvInvestmentSubsidyGeneral.DataBind();

                //gvGeneralGeneral.DataSource = ds.Tables[8];
                //gvGeneralGeneral.DataBind();
                // }
            }
        }
    }
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;

            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            Response.Redirect("ReleasePendingViewGM.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId);

            //if (indexing == 0 || indexing == 1 || indexing == 2 || indexing == 3 || indexing == 4)
            //{
            //    string Sactionnumber = Request.QueryString[0].ToString();
            //    // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            //    Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
            //}
            //if (indexing == 5 || indexing == 6 || indexing == 7 || indexing == 8 || indexing == 9)
            //{
            //    string Sactionnumber = Request.QueryString[0].ToString();
            //    // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            //    Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
            //}

            //if (indexing == 10 || indexing == 11 || indexing == 12 || indexing == 13 || indexing == 14)
            //{
            //    string Sactionnumber = Request.QueryString[0].ToString();
            //    // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            //    Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
            //}
        }
        catch (Exception ex)
        {

        }
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvInvestmentSubsidySC.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvGeneralSC.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        //  Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    //// ST Category
    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvPavallavaddiST.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void Button5_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvInvestmentSubsidyST.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvGeneralST.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        //  Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}

    //// General Category

    //protected void Button7_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvPavallavaddiGeneral.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void Button8_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvInvestmentSubsidyGeneral.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    //protected void Button9_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
    //        string lblMstIncentiveId = ((Label)gvGeneralGeneral.Rows[indexing].FindControl("Label3")).Text;
    //        string Sactionnumber = Request.QueryString[0].ToString();
    //        //Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
    //        Response.Redirect("ReleasePendingView.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
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

    public DataSet getincentiveslclist(string distid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_NEW_GM", con.GetConnection);
            da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = distid;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //da.SelectCommand.Parameters.Add("@slcno", SqlDbType.VarChar).Value = slcno;
            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
}