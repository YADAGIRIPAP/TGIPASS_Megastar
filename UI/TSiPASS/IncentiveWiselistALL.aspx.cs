using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
public partial class UI_TSiPASS_IncentiveWiselistALL : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    General gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Button2_Click(sender, e);
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
            string lblSubIncType = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;

            Response.Redirect("ReleasePendingViewALL.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
           "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string Distid = "";
        if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
        {
            Distid = Session["DistrictID"].ToString().Trim();
        }
        ds = getincentiveslclist(Distid, ddlApplicationMode.SelectedValue, ddlworkingstatus.SelectedValue);
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

    public DataSet getincentiveslclist(string slcno, string APPMODE, string APPSTATUS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_NEW_ALL", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@APPMODE", SqlDbType.VarChar).Value = APPMODE;
            da.SelectCommand.Parameters.Add("@APPSTATUS", SqlDbType.VarChar).Value = APPSTATUS;
            da.SelectCommand.Parameters.Add("@slcno", SqlDbType.VarChar).Value = slcno;
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