using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}
        
        
        
        if (!IsPostBack)
        {
            GetDepartment();
            getdistricts();
        }

      
    }

    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();

        dsd = Gen.GetDepartmentFullName();
        ddlDepartment.DataSource = dsd.Tables[0];
        ddlDepartment.DataValueField = "Dept_Id";
        ddlDepartment.DataTextField = "Dept_name";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--Select--");
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlDistrict.DataSource = dsnew.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = Gen.GetInspectionRptDrilown(txtnameofUnit.Text, txtUID.Text, ddlDistrict.SelectedItem.Text, ddlDepartment.SelectedItem.Text);
        grdDetails.DataSource = ds.Tables[0];
        grdDetails.DataBind();
       
    }
    void clear()
    {

        
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        
    }
    void FillDetails()
    {
        
          
    }    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        
    }
    
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
            
        try
        {

           

        }
        catch (Exception ex)
        {
           // lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    
    }

   
  
    
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[9].Controls[0];

            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            if (DataBinder.Eval(e.Row.DataItem, "Source").ToString() == "iPASS")
            {
                h1.Target = "_blank";
                h1.NavigateUrl = "frmViewInspectionAttachments.aspx?intInspectionid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intInspectionid")).Trim();
                h1.Text = "View";
            }
            else
            {
                h1.Target = "_blank";
                h1.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Web Path1")).Trim();
                h1.Text = "View";
            }
            
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
