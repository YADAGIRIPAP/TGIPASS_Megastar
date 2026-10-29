using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IncentiveWiseSLClistCOI : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["uid"]) != "")
        {
            //clerks -161017,161018,161019, 161020,127573, 127574
            //select* from tbl_users where intUserid in (33065, 33067, 33068, 33069)--SUPDT
            //select* from tbl_users where intUserid in (32952, 32953, 21415, 21416)
            // select* from tbl_users where intUserid in (32950, 242924)


            if (Convert.ToString(Session["uid"]) == "161017" || Convert.ToString(Session["uid"]) == "161018" ||
                Convert.ToString(Session["uid"]) == "161019" || Convert.ToString(Session["uid"]) == "1610120" ||
                Convert.ToString(Session["uid"]) == "127573" || Convert.ToString(Session["uid"]) == "127574" ||
                Convert.ToString(Session["uid"]) == "33065" || Convert.ToString(Session["uid"]) == "33067" ||
                Convert.ToString(Session["uid"]) == "33068" || Convert.ToString(Session["uid"]) == "33069" ||
                Convert.ToString(Session["uid"]) == "32952" || Convert.ToString(Session["uid"]) == "32953" ||
                Convert.ToString(Session["uid"]) == "21415" || Convert.ToString(Session["uid"]) == "21416" ||
                Convert.ToString(Session["uid"]) == "32950" || Convert.ToString(Session["uid"]) == "242924")
            {
                if (!IsPostBack)
                {
                    btnGetList_Click(sender, e);
                }
            }
            else
            {
                Response.Redirect("~/TSHome.aspx");
            }
        }
        else
        {
            Response.Redirect("~/TSHome.aspx");
        }
    }

    protected void btnGetList_Click(object sender, EventArgs e)
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
    protected void grdDetailsPavallavaddiSC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblince") as Label);
            Button Button1 = (e.Row.FindControl("btnView") as Button);
            if (enterid.Text == "")
            {
                Button1.Visible = false;
            }
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlApplicationMode.SelectedValue = "0";
        ddlworkingstatus.SelectedValue = "0";
        grdDetailsPavallavaddiSC.DataSource = null;
        grdDetailsPavallavaddiSC.DataBind();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            string lblMstIncentiveId = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("Label3")).Text;

            string lblCategory1 = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblCategory1")).Text;
            string lblSubIncType = ((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;
            if(lblCategory1!= "General")
            Response.Redirect("ReleasePendingView.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
           "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue);
            
            else
                Response.Redirect("ReleasePendingView.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
              "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue + "&LEVEL=COI");

        }
        catch (Exception ex)
        {

        }
    }
    public DataSet getincentiveslclist(string DISTCODE, string APPMODE, string APPSTATUS)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE", con.GetConnection);
            // da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT", con.GetConnection);
            da = new SqlDataAdapter("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_COIOFFICERS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@APPMODE", SqlDbType.VarChar).Value = APPMODE;
            da.SelectCommand.Parameters.Add("@APPSTATUS", SqlDbType.VarChar).Value = APPSTATUS;
            da.SelectCommand.Parameters.Add("@DISTCODE", SqlDbType.VarChar).Value = DISTCODE;
            da.SelectCommand.Parameters.Add("@USERID", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);

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