using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_IncentiveWiseListGMCOI : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = gen.getincentiveslclistGMCOI(Request.QueryString[0].ToString(), Session["DistrictID"].ToString().Trim());

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            // SC CAtegoty
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();

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
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);


            if (indexing == 0 || indexing == 1 || indexing == 2 || indexing == 3 || indexing == 4)
            {
                Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
            }
            if (indexing == 5 || indexing == 6 || indexing == 7 || indexing == 8 || indexing == 9)
            {
                Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
            }
            if (indexing == 10 || indexing == 11 || indexing == 12 || indexing == 13 || indexing == 14)
            {
                Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
            }
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
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
    //        Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
}