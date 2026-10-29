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
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
            }
            string status = Request.QueryString[0].ToString().Trim();
            string distid = Session["DistrictID"].ToString().Trim();
            if (Request.QueryString.Count > 0)
            {


                ddlDistrict.SelectedValue = distid;
                ddlDistrict.Enabled = false;
                //grdDetails.Columns[7].Visible = false;
                //grdDetails.Columns[8].Visible = false;
            }
            else
            {

                ddlDistrict.SelectedValue = distid;
                ddlDistrict.Enabled = false;
            }

            if (!IsPostBack)
            {
                getdistricts();
                fetchIncentivedet();

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void GetDepartment()
    {

    }
    protected void getdistricts()
    {
        try
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.GetDistrictsbystate("%");
            ddlDistrict.DataSource = dsnew.Tables[0];
            ddlDistrict.DataTextField = "District_Name";
            ddlDistrict.DataValueField = "District_Id";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            fetchIncentivedet();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void fetchIncentivedet()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = Gen.fetchIncentivedet(ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString());//,Request.QueryString[0].ToString().Trim()
            if (ds.Tables[0].Rows.Count > 0)
            {

                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString[0].ToString().Trim() == "3" || Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11" || Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
                    {
                        grdDetails.Columns[14].Visible = true;
                    }
                    else
                    {
                        grdDetails.Columns[14].Visible = false;
                    }
                }
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {
            ddlstatus.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            TxtIndname.Text = "";
            fetchIncentivedet();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlDeptname = (e.Row.FindControl("ddlDeptname") as DropDownList);
                DataSet dsnew = new DataSet();
                if (Request.QueryString[0].ToString().Trim() == "3")
                {
                    dsnew = Gen.GetDepartmentINcentive(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistID")).Trim());
                    ddlDeptname.DataSource = dsnew.Tables[0];
                    ddlDeptname.DataTextField = "Dept_Name";
                    ddlDeptname.DataValueField = "Dept_Id";
                    ddlDeptname.DataBind();
                    ddlDeptname.Items.Insert(0, "--Select--");
                }
                else if (Request.QueryString[0].ToString().Trim() == "10" || Request.QueryString[0].ToString().Trim() == "11" || Request.QueryString[0].ToString().Trim() == "5" || Request.QueryString[0].ToString().Trim() == "6")
                {
                    ddlDeptname.Items.Insert(0, new ListItem("Commissioner of COI", "999"));
                    ddlDeptname.Items.Insert(0, new ListItem("Rejected", "0"));
                    ddlDeptname.Items.Insert(0, new ListItem("DIPC-" + e.Row.Cells[7].Text, "1"));

                }

                //GetDepartment();
                //string IncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
                //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

                //btn.Text = "View";


                //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
                HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
                HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
                //  DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlDeptname");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
    {
        try
        {
            Button BtnSaveg = (Button)sender;
            GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

            HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
            DropDownList ddlDeptname = (DropDownList)row.FindControl("ddlDeptname");

            if (ddlDeptname.SelectedIndex == 0)
            {
                lblresult.Text = "Please Select Status";
            }
            else
            {
                //  lblresult.Text = "Status Updated";


                int returnValue = Gen.UpdateInspectorName(HdfintApplicationid.Value, ddlDeptname.SelectedValue.ToString().Trim(), Session["uid"].ToString(), row.Cells[1].Text, Session["User_Code"].ToString(), "3");

                if (returnValue != 999)
                {

                    lblresult.Text = "Status Updated";
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

                    // fillgrid();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

                    lblresult.Text = "Status Not Updated";

                }


            }
            // int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());


            fetchIncentivedet();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            // Failure.Visible = true;
        }
    }


}
