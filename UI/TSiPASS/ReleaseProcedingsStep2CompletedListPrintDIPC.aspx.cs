using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class UI_TSiPASS_ReleaseProcedingsStep2CompletedListPrintDIPC : System.Web.UI.Page
{
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userid = Session["uid"].ToString();
            DataSet ds = new DataSet();
            //  ds = gen.GetAmountAllotedGONumbersList(userid);  // modified on 07.12.2017
            ds = gen.GetReleaseProceedingNosListDIPC();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlapplicationto.DataSource = ds.Tables[0];
                //ddlapplicationto.DataValueField = "GO_NO";
                //ddlapplicationto.DataTextField = "GO_NO";

                ddlapplicationto.DataValueField = "ReleaseProceedingNo";
                ddlapplicationto.DataTextField = "ReleaseProceedingNo";
                ddlapplicationto.DataBind();

                ddlapplicationto.Items.Insert(0, "--Select--");
            }
        }

    }

    protected void btnAmtAllotedList_Click(object sender, EventArgs e)
    {
        if (ddlapplicationto.Text == "--Select--")
        {
            lblmsg1.Text = "";
            lblmsg1.Visible = true;

            lblmsg1.Text = "Please Select G.O. Number";
        }
        else
        {
            lblmsg1.Visible = false;

            DataSet ds = new DataSet();
            ds = gen.GetAmountAllotedListOnGONumberDIPC(ddlapplicationto.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
                grdDetailsPavallavaddiSC.DataBind();
            }
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;
            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblSubIncTypeId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncTypeId")).Text;


            Response.Redirect("ReleaseProcedingsStep2CompletedListPrintDrillDIPC.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&GONO=" + ddlapplicationto.Text + "&SubIncType=" + lblSubIncTypeId);

        }
        catch (Exception ex)
        {

        }
    }
}

