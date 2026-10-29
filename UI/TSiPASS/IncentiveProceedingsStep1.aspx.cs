using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_IncentiveProceedingsStep1 : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rblSector_SelectedIndexChanged(sender, e);
            //DataSet ds = new DataSet();
            //ds = gen.getincentiveslclistStep1(Request.QueryString[0].ToString());

            ////if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            ////{
            //// SC CAtegoty
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
            //// }
        }
    }
    protected void rblSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = gen.getincentiveslclistStep1(Request.QueryString[0].ToString(), rblSector.SelectedValue);

        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        // SC CAtegoty
        grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
        grdDetailsPavallavaddiSC.DataBind();
    }
    // SC CAtegory
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;

            //   string Sactionnumber = Request.QueryString[0].ToString();
            // Response.Redirect("Finalsactionamount.aspx?Sactionnumber=" + Sactionnumber + "&MstIncentiveId=" + lblMstIncentiveId);
            string lblsactionedAmount = ((TextBox)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;

            string txtGoNo = ((TextBox)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("txtGoNo")).Text;
            string txtGodate = ((TextBox)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("txtGodate")).Text;
            string txtLocno = ((TextBox)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("txtLocno")).Text;
            string txtLocdate = ((TextBox)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("txtLocdate")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblSubIncType = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;


            if (txtGoNo != "" && txtGodate != "" && txtLocno != "" && txtLocdate != "" && lblsactionedAmount != "")
            {


                Session["txtGoNo"] = txtGoNo;
                Session["txtGodate"] = txtGodate;
                Session["txtLocno"] = txtLocno;
                Session["txtLocdate"] = txtLocdate;

                //Response.Redirect("ReleaseProcedingsStep2.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);

                Response.Redirect("ReleaseProcedingsStep2Test.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount + "&SubIncId=" + lblSubIncType + "&GoNo=" + txtGoNo + "&GoDate=" + txtGodate + "&LocNo=" + txtLocno + "&LocDate=" + txtLocdate + "&Sector=" + rblSector.SelectedValue);

                //if (indexing == 0 || indexing == 1 || indexing == 2 || indexing == 3 || indexing == 4)
                //{
                //    Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);

                //}
                //if (indexing == 5 || indexing == 6 || indexing == 7 || indexing == 8 || indexing == 9)
                //{
                //    Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
                //}
                //if (indexing == 10 || indexing == 11 || indexing == 12 || indexing == 13 || indexing == 14)
                //{
                //    Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
                //}
            }
            else
            {

                string message = "alert('Please Enter Details to Process')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }


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

            TextBox txtGoNo = (e.Row.FindControl("txtGoNo") as TextBox);
            TextBox txtGodate = (e.Row.FindControl("txtGodate") as TextBox);
            TextBox txtLocno = (e.Row.FindControl("txtLocno") as TextBox);
            TextBox txtLocdate = (e.Row.FindControl("txtLocdate") as TextBox);
            TextBox txtsanctionedamountnew = (e.Row.FindControl("txtsanctionedamountnew") as TextBox);


            if (enterid.Text == "")
            {
                Button1.Visible = false;
                txtGoNo.Visible = false;
                txtGodate.Visible = false;
                txtLocno.Visible = false;
                txtLocdate.Visible = false;
                txtsanctionedamountnew.Visible = false;
            }
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
    //        string lblsactionedAmount = ((TextBox)gvInvestmentSubsidySC.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvGeneralSC.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvPavallavaddiST.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvInvestmentSubsidyST.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvGeneralST.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvPavallavaddiGeneral.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvInvestmentSubsidyGeneral.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
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
    //        string lblsactionedAmount = ((TextBox)gvGeneralGeneral.Rows[indexing].FindControl("txtsanctionedamountnew")).Text;
    //        Response.Redirect("ReleaseProcedingsStep2.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId + "&sactionedAmount=" + lblsactionedAmount);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
}