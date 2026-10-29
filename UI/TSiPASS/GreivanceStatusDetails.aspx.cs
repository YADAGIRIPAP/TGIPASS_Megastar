using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class TSTBDCReg1 : System.Web.UI.Page
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
                grdDetails.Columns[4].Visible = false;
                //grdDetails.Columns[9].Visible = false;
                if (Session["userlevel"].ToString() == "10")
                {
                    grdDetails.Columns[10].Visible = true;
                    //grdDetails.Columns[11].Visible = true;
                }
                else
                {
                    grdDetails.Columns[10].Visible = true;
                    //grdDetails.Columns[11].Visible = false;
                }
                //grdDetails.Columns[10].Visible = false;
            }
            else
            {
                ddlstatus.SelectedIndex = 0;
                ddlstatus.Enabled = true;
                grdDetails.Columns[10].Visible = true;
                if (Session["userlevel"].ToString() == "10")
                {

                    grdDetails.Columns[11].Visible = true;
                }
                else
                {
                    grdDetails.Columns[11].Visible = false;
                }
            }
            getdistricts();
            fetchgrievancedet();
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
        fetchgrievancedet();
    }
    protected void fetchgrievancedet()
    {
        DataSet ds = new DataSet();
        string status = Request.QueryString[0].ToString();
        if (Session["userlevel"].ToString() == "10")
        {
            ds = Gen.fetchgrievancedet(status, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString(), "%", "%", "%");
        }
        else if (Session["userlevel"].ToString() == "13")
        {
            ds = Gen.fetchgrievancedet(status, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), "%", "%", Session["uid"].ToString(), "%");
        }
        else if (Session["userlevel"].ToString() == "1" || Session["userlevel"].ToString() == "2")
        {
            if (Request.QueryString.Count > 0)
            {
                ds = Gen.fetchgrievancedet(status, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Request.QueryString[1].ToString(), "%", "%", "%");
            }
            else
            {
                ds = Gen.fetchgrievancedet(status, ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), "%", "%", "%", "1213");
            }
        }
        string statustext = "";
        if (status == "PendingW")
        {
            statustext = "Pending Wihin 5 days";
        }
        else if (status == "PendingB")
        {
            statustext = "Pending Beyond 5 days";
        }
        else if (status == "PendingT")
        {
            statustext = "Toatal Pending";
        }
        else if (status == "RedressedW")
        {
            statustext = "Redressed Wihin 5 days";
        }
        else if (status == "RedressedB")
        {
            statustext = "Redressed Beyond 5 days";
        }
        else if (status == "RedressedT")
        {
            statustext = "Toatal Redressed";
        }
        else if (status == "Reject")
        {
            statustext = "Toatal Rejected";
        }
        lblMsg.Text = statustext;
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            lblMsg.Text = statustext + " - " + ds.Tables[0].Rows.Count.ToString();
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
        fetchgrievancedet();
    }
  
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status")) == "Pending" && Session["userlevel"].ToString() == "10")//&& Request.QueryString.Count == 0
        //    {
        //        HyperLink h1 = (HyperLink)e.Row.Cells[11].Controls[0];
        //        h1.Text = "Forward";
        //        h1.NavigateUrl = "GreivanceChangeStatus.aspx?intGrievanceid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intGrievanceid")).Trim() + "&forward=Y";
        //        h1.Visible = true;
        //    }
        //}
    }

    protected void btnprocess_Click(object sender, EventArgs e)
    {
        //string intGrievanceid=Request.QueryString[1].ToString();
        int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
        string intGrievanceid = ((Label)grdDetails.Rows[indexing].FindControl("lblintGrievanceid")).Text;
        Response.Redirect("GreivanceChangeStatus.aspx?intGrievanceid=" + intGrievanceid);
    }
}
