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

public partial class UI_TSiPASS_IncentiveWiseSLClistGMADSubPlan : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    SqlDataAdapter myDataAdapter;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            if (Session["uid"] != null && Session["uid"].ToString() == "32951")
            {
                getdistrictsUnit();
              
                
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
            Response.Redirect("ReleasePendingViewGMADSubPlan.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&distid=" + ddlUnitDIst.SelectedValue);

            
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

    public DataSet getincentiveslclist(string userid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_NEW_GM_ADSUBPLAN", con.GetConnection);
            da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = userid;
            if (ddlUnitDIst.SelectedItem.Text.ToUpper() == "ALL")
            {
                da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = "32";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@dist", SqlDbType.VarChar).Value = ddlUnitDIst.SelectedValue;
            }
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
          
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


    protected void getdistrictsUnit()
    {
        DataSet dsnew = new DataSet();     
        dsnew = gen.GetDistrictsbystate("31");
        ddlUnitDIst.DataSource = dsnew.Tables[0];
        ddlUnitDIst.DataTextField = "District_Name";
        ddlUnitDIst.DataValueField = "District_Id";
        ddlUnitDIst.DataBind();
        ddlUnitDIst.Items.Insert(0, "--Select--");
        ddlUnitDIst.Items.Insert(32, "ALL");

  

    }
    protected void btngetdtls_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = getincentiveslclist(Session["uid"].ToString().Trim());

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetailsPavallavaddiSC.DataSource = ds.Tables[0];
            grdDetailsPavallavaddiSC.DataBind();
        }
                
    }
}