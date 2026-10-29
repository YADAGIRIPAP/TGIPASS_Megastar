using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_IncentiveStatusInspectionUploadbyCoi : System.Web.UI.Page
{
    General Gen = new General();
    string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("/ipasslogin.aspx");
        }
        status = Request.QueryString[0].ToString().Trim();

        if (!IsPostBack)
        {
            getdistricts();        
            FetchDetails();

        }
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        DrpDist.Items.Clear();
        DrpDist.DataSource = dsnew.Tables[0];
        DrpDist.DataTextField = "District_Name";
        DrpDist.DataValueField = "District_Id";
        DrpDist.DataBind();
        DrpDist.Items.Insert(0, new ListItem("Select District", "0"));


        DropDownList1.Items.Clear();
        DropDownList1.DataSource = dsnew.Tables[0];
        DropDownList1.DataTextField = "District_Name";
        DropDownList1.DataValueField = "District_Id";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("Select District", "0"));



    }
    private void FetchDetails()
    {
        DataSet ds = new DataSet();


        ds = Gen.CoifetchIncentivedetIPONewIncType(Session["uid"].ToString(), status);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (Request.QueryString[0].ToString().Trim() == "54" || Request.QueryString[0].ToString().Trim() == "55" || Request.QueryString[0].ToString().Trim() == "56" ||
                Request.QueryString[0].ToString().Trim() == "83" || Request.QueryString[0].ToString().Trim() == "84")
            {
                trNEW2.Visible = true;
                trNEW1.Visible = false;
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                trNEW2.Visible = false;
                trNEW1.Visible = true;
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
    }


    protected void anchortaglink_Click(object sender, EventArgs e)
    {
        Button ddlDeptnameFnl2 = (Button)sender;

        GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;

        Label enterid = (Label)row.FindControl("lblIncentiveID");
        string status = Request.QueryString[0].ToString().Trim();
        Button Button1 = (Button)row.FindControl("anchortaglink");
        Label Incids = (Label)row.FindControl("lblIncentiveIDS");
        string newurl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&IncIds=" + Incids.Text.Trim();
        Response.Redirect(newurl);
    }
}