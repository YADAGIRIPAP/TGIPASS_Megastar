using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UI_TSiPASS_QueryStatusDetails : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {

            if (Request.QueryString.Count > 0)
            {
                string status = Request.QueryString[0].ToString();
                ddlstatus.SelectedValue = status;
                ddlstatus.Enabled = false;
                //grdDetails.Columns[8].Visible = false;
                grdDetails.Columns[3].Visible = false;
                if (Session["userlevel"].ToString() == "10")
                {
                    if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                    {
                        grdDetails.Columns[8].Visible = true;
                        grdDetails.Columns[9].Visible = false;
                    }
                    else
                    {
                        grdDetails.Columns[8].Visible = true;
                        grdDetails.Columns[9].Visible = true;
                    }
                }
                else
                {
                    grdDetails.Columns[8].Visible = true;
                    grdDetails.Columns[9].Visible = false;
                }
                //grdDetails.Columns[9].Visible = false;
            }
            else
            {
                ddlstatus.SelectedIndex = 0;
                ddlstatus.Enabled = true;
                grdDetails.Columns[7].Visible = true;
                if (Session["userlevel"].ToString() == "10")
                {
                    if (Session["user_id"].ToString().Trim().ToUpper() == "IFC")
                    {
                        grdDetails.Columns[9].Visible = false;
                    }
                    else
                    {
                        grdDetails.Columns[9].Visible = true;
                    }
                }
                else
                {
                    grdDetails.Columns[9].Visible = false;
                }
            }
            getdistricts();
            fetch_FeedbackQuerydet();
        }

    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetch_FeedbackQuerydet();
    }
    protected void fetch_FeedbackQuerydet()
    {
        DataSet ds = new DataSet();

        if (Session["userlevel"].ToString() == "10")
        {
            ds = Gen.fetch_FeedbackQuerydet(ddlstatus.SelectedValue, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString(), "%", "%", "%", "Q");
        }
        else if (Session["userlevel"].ToString() == "13")
        {
            ds = Gen.fetch_FeedbackQuerydet(ddlstatus.SelectedValue, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), "%", "%", Session["uid"].ToString(), "%", "Q");
        }
        else if (Session["userlevel"].ToString() == "1" || Session["userlevel"].ToString() == "2")
        {
            if (Request.QueryString.Count > 0)
            {
                ds = Gen.fetch_FeedbackQuerydet(ddlstatus.SelectedValue, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), "", "%", "%", "%", "Q");
            }
            else
            {
                ds = Gen.fetch_FeedbackQuerydet(ddlstatus.SelectedValue, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), "%", "%", "%", "1213", "Q");
            }
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblMsg.Text = "No Records found.";
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetch_FeedbackQuerydet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status")) == "Pending" && Session["userlevel"].ToString() == "10")//&& Request.QueryString.Count == 0
            {
                if (Session["user_id"].ToString().Trim().ToUpper() != "IFC")
                {
                    HyperLink h1 = (HyperLink)e.Row.Cells[11].Controls[0];
                    h1.Text = "Forward";
                    h1.NavigateUrl = "QueryChangeStatus.aspx?intGrievanceid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intGrievanceid")).Trim() + "&forward=Y";
                    h1.Visible = true;
                }
            }
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status")) == "Pending" && Session["userlevel"].ToString() == "1")//&& Request.QueryString.Count == 0
            {
                if (Session["user_id"].ToString().Trim().ToUpper() != "IFC")
                {
                    e.Row.Cells[11].Visible = false;
                }
            }
        }
    }



    protected void btnprocess_Click(object sender, EventArgs e)
    {
        Button btn1 = (Button)sender;
        GridViewRow row = (GridViewRow)btn1.NamingContainer;

        string sno11 = row.Cells[11].Text.ToString();

        //row.Cells[11].Visible = true;
        //string sno12 = row.Cells[12].Text.ToString();




        //string test = row.ID.ToString();

        //string intGrievanceid=Request.QueryString[1].ToString();
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string intGrievanceid = grdDetails.Rows[indexing].Cells[1].Text.ToString();
        Response.Redirect("QueryChangeStatus.aspx?intGrievanceid=" + sno11);
    }
}
