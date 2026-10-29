using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_CFEListtoVerify : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["uid"]) != "")
            {
                if (!IsPostBack)
                {
                    GetDetails();
                }
            }
            else
            { Response.Redirect("~/Ipasslogin.aspx"); }
        }
        catch (Exception ex)
        { }

    }
    public void GetDetails()
    {
        try
        {
            con.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("USP_GETCFEAPPL_TOVERIFY", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
            con.CloseConnection();
            if (ds.Tables.Count > 0)
            {
                grdCFEDetails.DataSource = ds;
                grdCFEDetails.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void grdCFEDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hplUID = (HyperLink)e.Row.FindControl("hplUID");
                Label lblEnterpid = (Label)e.Row.FindControl("lblintCFEEnterpid");
                Label lblQuessionaireid = (Label)e.Row.FindControl("lblintQuessionaireid");
              
                if (hplUID.Text != "" && lblQuessionaireid.Text != "")
                {
                    hplUID.NavigateUrl = "~/UI/TSIPASS/ApplicationTrakerDetailed.aspx?ID=" + lblQuessionaireid.Text;
                }
            }
        }
        catch (Exception ex)
        { }
    }



    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            Button btnVerify = (Button)sender;

            GridViewRow row = (GridViewRow)btnVerify.NamingContainer;
            Label lblEnterpid = (Label)row.FindControl("lblintCFEEnterpid");
            Label lblQuessionaireid = (Label)row.FindControl("lblintQuessionaireid");
            Label lblintUserid = (Label)row.FindControl("lblintUserid");
            Response.Redirect("~/UI/TSIPASS/CFEDetailsVerification.aspx?Enterpid=" + lblEnterpid.Text + "&Quessionaireid=" + lblQuessionaireid.Text+"&Userid="+ lblintUserid.Text);
        }
        catch (Exception ex) { }
    }
}