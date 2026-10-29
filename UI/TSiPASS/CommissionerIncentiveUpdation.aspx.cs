using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;

public partial class TSTBDCReg1 : System.Web.UI.Page
{
    
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        string status = Request.QueryString[0].ToString().Trim();
        string distid = Session["DistrictID"].ToString().Trim();



        //if (!IsPostBack)
        //{
        //    getdistricts();
        //    fetchIncentivedet();

        //}
        if (!IsPostBack)
        {
            getdistricts();
        }
        if (Request.QueryString.Count > 0)
        {
           

            if (!IsPostBack)
            {
                ddlDistrict.SelectedValue = distid;
                ddlDistrict.Enabled = false;
                if (Session["DistrictID"].ToString().Trim() == null || Session["DistrictID"].ToString().Trim() == "")
                {
                    ddlDistrict.Enabled = true;
                }
                //grdDetails.Columns[7].Visible = false;
                //grdDetails.Columns[8].Visible = false;
            }
        }
        else
        {
           
            ddlDistrict.SelectedValue = distid;
            ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {
            //getdistricts();
            fetchIncentivedet();

        }


    }
    protected void GetDepartment()
    {
        
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
        fetchIncentivedet();
    }
    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIncentivedetnewCommissioner(ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11")
                {
                    if (Session["uid"].ToString() == "1213" || (Convert.ToInt32(Session["User_Code"].ToString()) >= 46 && Convert.ToInt32(Session["User_Code"].ToString()) <= 55))
                    {
                        grdDetails.Columns[15].Visible = true;
                    }
                    else
                    {
                        grdDetails.Columns[15].Visible = false;
                    }
                }
                else
                {
                    grdDetails.Columns[15].Visible = true;
                }
            }
        }
        else
        {
            lblMsg.Text = "";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ddlstatus.SelectedIndex = 0;
        ddlDistrict.SelectedIndex = 0;
        TxtIndname.Text = "";
        fetchIncentivedet();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetails.PageIndex = e.NewPageIndex;
        fetchIncentivedet();
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          

            //GetDepartment();
            //string IncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[12].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
          //  DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlDeptname");
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        Button BtnSaveg = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

        HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
        DropDownList DdlStatus = (DropDownList)row.FindControl("DdlStatus");
        TextBox TxtRemarks = (TextBox)row.FindControl("TxtRemarks");
        TextBox TxtSLCNumber = (TextBox)row.FindControl("TxtSLCNumber");
        TextBox txtSLCDate = (TextBox)row.FindControl("txtSLCDate");
        TextBox txttotal = (TextBox)row.FindControl("txttotal");
       
            //lblresult.Text = "Status Updated";


            int returnValue = Gen.UpdateCommissionerLogin(HdfintApplicationid.Value, DdlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString(),TxtSLCNumber.Text,txtSLCDate.Text,txttotal.Text,TxtRemarks.Text);

            if (returnValue != 999)
            {

                lblresult.Text = "Status Updated";
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);
                if(DdlStatus.SelectedIndex==0)
                Response.Redirect("Sanctionnew.aspx?id=" + HdfintApplicationid.Value + "&IncentiveName=" + row.Cells[4].Text + "&SLCNo=" + TxtSLCNumber.Text + "&SLCDate=" + txtSLCDate.Text + "&SLCAmount=" + txttotal.Text);
                // fillgrid();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                lblresult.Text = "Status Not Updated";

            }


        
       // int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());


        fetchIncentivedet();

    }


    protected void DdlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList DdlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)DdlStatus.NamingContainer;
        DropDownList DdlStatus1 = (DropDownList)row.FindControl("DdlStatus");

        TextBox TxtRemarks = (TextBox)row.FindControl("TxtRemarks");


        Label Label1 = (Label)row.FindControl("Label1");
        Label Label2 = (Label)row.FindControl("Label2");
        Label Label3 = (Label)row.FindControl("Label3");
        TextBox TxtSLCNumber = (TextBox)row.FindControl("TxtSLCNumber");
        TextBox txtSLCDate = (TextBox)row.FindControl("txtSLCDate");
        TextBox txttotal = (TextBox)row.FindControl("txttotal");

        if (DdlStatus.SelectedIndex == 0)
        {


            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            TxtSLCNumber.Visible = true;
            txtSLCDate.Visible = true;
            txttotal.Visible = true;
            TxtRemarks.Visible = false;
        }
        else
        {

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            TxtSLCNumber.Visible = false;
            txtSLCDate.Visible = false;
            txttotal.Visible = false;
           
            TxtRemarks.Visible = true;
        }
    }
}
