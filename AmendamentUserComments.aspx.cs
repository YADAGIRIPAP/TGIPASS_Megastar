using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AmendamentUserComments : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BindDistricts(ddlDistrict);
                trComments.Visible = true;
                DataSet dsdepts = new DataSet();
                //  dsdepts = Gen.GetDepartmentSofAmmendments();
                dsdepts = Gen.GetAmmendamentFullName();
                if (dsdepts != null && dsdepts.Tables.Count > 0 && dsdepts.Tables[0].Rows.Count > 0)
                {
                    //ddlDepartments.DataSource = dsdepts.Tables[0];
                    //ddlDepartments.DataTextField = "Dept_Name";
                    //ddlDepartments.DataValueField = "Dept_Id";
                    //ddlDepartments.DataBind();
                    //AddSelect(ddlDepartments);

                    ddlDepartments.DataSource = dsdepts.Tables[0];
                    ddlDepartments.DataValueField = "Id";
                    ddlDepartments.DataTextField = "Dept_name";
                    ddlDepartments.DataBind();
                    ddlDepartments.Items.Insert(0, "--Select--");
                    AddSelect(ddlDepartments);
                }




                string Deptid = "";
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString[0].ToString().Contains("http://120.138.9.236") || Request.QueryString[0].ToString().Contains("https://ipass.telangana.gov.in"))
                    {
                        IframePanel.Attributes["src"] = Request.QueryString[0];
                    }
                    else
                    {
                        IframePanel.Attributes["src"] = "#";
                    }
                    ddlDepartments.SelectedValue = Request.QueryString[1];
                    ddlDepartments_SelectedIndexChanged(sender, e);
                    ddlAmendment.SelectedValue = Request.QueryString[2];
                    ddlDepartments.Enabled = false;
                    ddlAmendment.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblerrMsg.Text = ex.Message;
                lblerrMsg.CssClass = "errormsg";
            }
        }
    }

    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    public void BindDistricts(DropDownList ddlDistrict)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dsd.Tables[0];
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--District--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--District--");
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void ddlDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlAmendment.Items.Clear();
            int DEPTID = Convert.ToInt32(ddlDepartments.SelectedValue);
            DataSet ds1 = Gen.GetAmmendments(DEPTID);
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                ddlAmendment.DataSource = ds1.Tables[0];
                ddlAmendment.DataTextField = "Ammendment";
                ddlAmendment.DataValueField = "Ammendment_Id";
                ddlAmendment.DataBind();
            }
            AddSelect(ddlAmendment);

        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AmmendmentVo ammendment = new AmmendmentVo();
        ammendment.UserName = txtUserName.Text;
        ammendment.District = ddlDistrict.SelectedValue;
        ammendment.MobileNo = txtMobileNo.Text;
        ammendment.MailId = txtEmailId.Text;
        ammendment.Dept_ID = ddlDepartments.SelectedValue;
        ammendment.Ammendment_Id = ddlAmendment.SelectedValue;
        ammendment.Comments = txtComments.Text;
        ammendment.Created_By = "";
        int VALID = 0;
        VALID = Gen.InsertAmmendmentsComments(ammendment);
        if (VALID == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Comments Saved Successfully');" + "window.location='UseCommentsOnAmmendments.aspx';", true);
            lblresult.Text = "Comments Saved Successfully";
            lblresult.Visible = true;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("UseCommentsOnAmmendments.aspx");
    }

    protected void btnviewcomments_Click(object sender, EventArgs e)
    {
        Response.Redirect("AmmendmentViewPublicComments.aspx?filename=" + ddlAmendment.SelectedValue);
    }
}