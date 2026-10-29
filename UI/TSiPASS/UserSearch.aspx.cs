using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_UserSearch : System.Web.UI.Page
{
    General gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        //if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "34670" || Session["uid"].ToString() == "1213" || Session["uid"].ToString() == "1003" || Session["uid"].ToString() == "17377" || Session["uid"].ToString() == "3377" || Session["uid"].ToString() == "1222" || Session["userlevel"].ToString().Trim() == "2")
        //{

        //}
        //else
        //{
        //    Response.Redirect("~/Index.aspx");
        //}
        //if(Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "1238"  || Session["uid"].ToString() == "34670" || Session["uid"].ToString() == "194556"|| Session["uid"].ToString() == "200451"
        //|| Session["uid"].ToString() == "232576"|| Session["uid"].ToString() == "253625"|| Session["uid"].ToString() == "306659" || Session["uid"].ToString() == "309647"
        if (Session["uid"].ToString() == "77233" || Session["uid"].ToString() == "34668" || Session["uid"].ToString() == "251974"
            || Session["uid"].ToString() == "253625" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "359104"|| Session["uid"].ToString() == "380604"
            || Session["uid"].ToString() == "380734" || Session["uid"].ToString() == "380735"|| Session["uid"].ToString() == "364490" || Session["uid"].ToString() == "3377")
        {
            if (Session["uid"].ToString() == "34667")
            {
                ListItem li = new ListItem("Incentive ID", "4");
                ddlFinancialYear.Items.Insert(ddlFinancialYear.Items.Count, li);
            }
            if (Session["uid"].ToString() == "364490")
            {
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("1"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("2"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("3"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("5"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("6"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("8"));
                ddlFinancialYear.Items.Remove(ddlFinancialYear.Items.FindByValue("9"));
            }
        }
        else
        {

            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {



        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            TRMULTIPLELOGINDETAILSBYINTUSERIDS.Visible = false;
            grdDetails.Visible = false;

            DataSet ds = new DataSet();
            ds = gen.GetUserSearch(txtUserName.Text.Trim().TrimStart().TrimEnd() + "*" + ddlFinancialYear.SelectedValue + "*" + Session["uid"].ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                grdDetails.Visible = true;
                Failure.Visible = false;
                TRMULTIPLELOGINDETAILSBYINTUSERIDS.Visible = false;
                GRDMULTIPLELOGINDETAILS.Visible = false;


            }
            else if (ds.Tables[1].Rows.Count > 0)
            {
               
                    TRMULTIPLELOGINDETAILSBYINTUSERIDS.Visible = true;
                    GRDMULTIPLELOGINDETAILS.DataSource = ds.Tables[1];
                    GRDMULTIPLELOGINDETAILS.DataBind();
                    GRDMULTIPLELOGINDETAILS.Visible = true;
                grdDetails.Visible = false;
                Failure.Visible = false;


            }
            else
            {
                Failure.Visible = true;
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails.Visible = false;
                GRDMULTIPLELOGINDETAILS.Visible = false;
                TRMULTIPLELOGINDETAILSBYINTUSERIDS.Visible = false;
                GRDMULTIPLELOGINDETAILS.DataSource = null;
                GRDMULTIPLELOGINDETAILS.DataBind();


            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserSearch.aspx");
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                e.Row.Cells[3].Text = gen.Decrypt(e.Row.Cells[3].Text.Trim(), "SYSTIME").Trim();
            }
        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.Message;
            // Failure.Visible = true;
            // success.Visible = false;
        }
    }
    protected void GRDMULTIPLELOGINDETAILS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType.Equals(DataControlRowType.DataRow))
            {
                e.Row.Cells[3].Text = gen.Decrypt(e.Row.Cells[3].Text.Trim(), "SYSTIME");
            }
        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.Message;
            // Failure.Visible = true;
            // success.Visible = false;
        }

    }
}