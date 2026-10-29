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


public partial class UseCommentsOnAmmendments : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds1 = Gen.GetAmmendments(0);/*this obj is referring to some class in which GetRecord method is present which return the record from database. You can write your //own class and method.*/
            string s1;
            s1 = "<table><tr><td>";

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                string filepath, filepath2, filepath3;
                filepath = ds1.Tables[0].Rows[i]["link"].ToString();
                filepath2 = filepath.Replace(@"\", @"/");
                filepath3 = filepath2.Replace(@"D:/TS-iPASSFinal/", "https://ipass.telangana.gov.in/");
                // filepath3 = filepath2.Replace(@"C:/Users/admin/Desktop/TSIPASS01042017/TSIPASS/", "");
                filepath3 = "viewpdf.aspx?filepathnew=" + filepath;  // filepath3.Replace(@" ", @"%20");
                string Urloffile = "AmendamentUserComments.aspx?filename=" + filepath3 + "&deptid=" + ds1.Tables[0].Rows[i]["Dept_Id"].ToString() + "&Amdid=" + ds1.Tables[0].Rows[i]["Ammendment_Id"].ToString();

                s1 += "<a href=" + Urloffile + " target=" + "_blank style=font-family: fantasy; font-size:larger; font-weight:bold; font-style: normal; color: #8B0000>"
                   + ds1.Tables[0].Rows[i]["Slno"].ToString() + "&nbsp" + ds1.Tables[0].Rows[i]["SCROLLTEXT"].ToString() + "</a>";
                s1 += "<br/>";

            }
            s1 += "</td></tr></table>";
            lt1.Text = s1.ToString();
            if (ds1 != null && ds1.Tables.Count > 1 && ds1.Tables[1].Rows.Count > 0)
            {
                string s2;
                s2 = "<table><tr><td>";

                for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
                {
                    string filepath, filepath2, filepath3;
                    filepath = ds1.Tables[1].Rows[i]["link"].ToString();
                    filepath2 = filepath.Replace(@"\", @"/");
                    filepath3 = filepath2.Replace(@"D:/TS-iPASSFinal/", "https://ipass.telangana.gov.in/");
                    // filepath3 = filepath2.Replace(@"C:/Users/admin/Desktop/TSIPASS01042017/TSIPASS/", "");

                    filepath3 = filepath3.Replace(@" ", @"%20");
                    string Urloffile = "AmendamentUserCommentsFinal.aspx?filename=" + filepath3 + "&deptid=" + ds1.Tables[1].Rows[i]["Dept_Id"].ToString() + "&Amdid=" + ds1.Tables[1].Rows[i]["Old_AmmendmentId"].ToString();

                    s2 += "<a href=" + Urloffile + " target=" + "_blank style=font-family: fantasy; font-size:larger; font-weight:bold; font-style: normal; color: #8B0000>"
                      + ds1.Tables[1].Rows[i]["Slno"].ToString() + "&nbsp" + ds1.Tables[1].Rows[i]["SCROLLTEXT"].ToString() + "</a>";
                    s2 += "<br/>";
                }
                s2 += "</td></tr></table>";
                lt2.Text = s2.ToString();
            }
        }
    }
    protected void btnComments_Click(object sender, EventArgs e)
    {
        try
        {
            BindDistricts(ddlDistrict);
            trComments.Visible = true;
            DataSet dsdepts = new DataSet();
            dsdepts = Gen.GetDepartmentSofAmmendments();
            if (dsdepts != null && dsdepts.Tables.Count > 0 && dsdepts.Tables[0].Rows.Count > 0)
            {
                ddlDepartments.DataSource = dsdepts.Tables[0];
                ddlDepartments.DataTextField = "Dept_Name";
                ddlDepartments.DataValueField = "Dept_Id";
                ddlDepartments.DataBind();
                AddSelect(ddlDepartments);
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
        //
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
            lblresult.Text = "Comments Saved Successfully";
            lblresult.Visible = true;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("UseCommentsOnAmmendments.aspx");
    }
}