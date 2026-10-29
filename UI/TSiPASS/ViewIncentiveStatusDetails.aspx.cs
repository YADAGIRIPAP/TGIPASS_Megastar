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
           // Response.Redirect("../../frmUserLogin.aspx");
        }
        string status = Request.QueryString[0].ToString().Trim();
        string distid = Session["DistrictID"].ToString().Trim();
        if (Request.QueryString.Count > 0)
        {
            
            ddlstatus.SelectedValue = status;
            ddlstatus.Enabled = false;
            ddlDistrict.SelectedValue = distid;
            ddlDistrict.Enabled = false;
            //grdDetails.Columns[7].Visible = false;
            //grdDetails.Columns[8].Visible = false;
        }
        else
        {
            ddlstatus.SelectedIndex = 0;
            ddlstatus.Enabled = true;
            ddlDistrict.SelectedValue = distid;
            ddlDistrict.Enabled = false;
        }

        if (!IsPostBack)
        {
            getdistricts();
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
        DataSet ds= new DataSet();

        ds = Gen.fetchIncentivedet( ddlDistrict.SelectedValue, TxtIndname.Text.Trim(), Session["User_Code"].ToString());
             grdDetails.DataSource = ds.Tables[0]; 
            grdDetails.DataBind();
        
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

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlDeptname = (e.Row.FindControl("ddlDeptname") as DropDownList);
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDepartment();
            ddlDeptname.DataSource = dsnew.Tables[0];
            ddlDeptname.DataTextField = "Dept_Name";
            ddlDeptname.DataValueField = "Dept_Id";
            ddlDeptname.DataBind();
            ddlDeptname.Items.Insert(0, "--Select--");
            //GetDepartment();
            //string IncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID")).Trim();
            //LinkButton btn = (LinkButton)e.Row.FindControl("LinkButton1");

            //btn.Text = "View";


            //btn.OnClientClick = "javascript:return Popup('" + intUid + "')";
            HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[11].FindControl("HdfintApplicationid");
            HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId")).Trim();
            //DropDownList ddlStatus = (DropDownList)e.Row.Cells[12].FindControl("ddlDeptname");
        }
    }
    protected void BtnSaveg_Click(object sender, EventArgs e)
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


            int returnValue = Gen.UpdateInspectorName(HdfintApplicationid.Value, ddlDeptname.SelectedValue.ToString().Trim(), Session["uid"].ToString(), "", "", ""); //fix by CMS by passing string EMiUdyogAadhar, string SentFrom, string Status

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




    }

    
}
