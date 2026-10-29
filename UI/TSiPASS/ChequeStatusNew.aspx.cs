using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UI_TSiPASS_ChequeStatusNew : System.Web.UI.Page
{
    General gen = new General();
    DataSet Gds = null;
    string DIPCFlag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
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
            string lblsubInctypeid = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblInctypeId")).Text;
            string DIPCFlag = "";
            //if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
            //{
            //    DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
            //}

            Response.Redirect("CheckStatusUpdatedDetailsNew.aspx?checkNo=" + txtcheckno.Text.Trim());

            //Response.Redirect("CheckListPrint.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text);
            // Response.Redirect("UpdateCheckChearenceDate.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&Date=" + txtsvcdate.Text + "&RlsProceedNo=" + ddlapplicationto.SelectedValue + "&checkNo=" + ddlCheckList.SelectedValue + "&SubIncTypeId=" + lblsubInctypeid);

            //if (indexing == 0 || indexing == 1 || indexing == 2 || indexing == 3 || indexing == 4)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=General&MstIncentiveId=" + lblMstIncentiveId);
            //}
            //if (indexing == 5 || indexing == 6 || indexing == 7 || indexing == 8 || indexing == 9)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=SC&MstIncentiveId=" + lblMstIncentiveId);
            //}
            //if (indexing == 10 || indexing == 11 || indexing == 12 || indexing == 13 || indexing == 14)
            //{
            //    Response.Redirect("ReleaseModuleUnitWiseGM.aspx?Sactionnumber=" + Sactionnumber + "&Cast=ST&MstIncentiveId=" + lblMstIncentiveId);
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
            Label enterid = (e.Row.FindControl("Label3") as Label);
            Button Button1 = (e.Row.FindControl("Button1") as Button);

            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }

    
  

    protected void txtcheckno_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        //string releaseProcedingno = ddlapplicationto.SelectedValue;
        string checkno = txtcheckno.Text.Trim();
        string DIPCFlag = "";
        //if (Request.QueryString["DIPCFlag"] != null && Request.QueryString["DIPCFlag"].ToString() != "")
        //{
        //    DIPCFlag = Request.QueryString["DIPCFlag"].ToString();
        //}

        SqlParameter[] pp = new SqlParameter[] {
              // new SqlParameter("@releaseProceno",SqlDbType.VarChar),
                 new SqlParameter("@checkno",SqlDbType.VarChar)
                //  new SqlParameter("@DIPCFlag",SqlDbType.VarChar)
            };
        //pp[0].Value = releaseProcedingno;
        pp[0].Value = checkno;
        // pp[2].Value = DIPCFlag;



        ds = gen.GenericFillDs("USP_GET_LIST_INCENTIVEWISE_CHECKCLEARENCE_ABSTRACT_CHECKNO", pp);



        //ds = gen.getincentivesClearenceDtls(releaseProcedingno,checkno); 

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // trConvened.Visible = true;
            // txtsvcdate.Text = ddlapplicationto.SelectedItem.Text;
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
    }
}