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
            //if (Session["Applid"] != null || Session["Applid"] != "")
            //{
            //    //  Response.Redirect("frmDepartmentApprovalDetails.aspx");

            //}
            //else
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");

            //}
            Label1.Text = "Report as on: " + System.DateTime.Now.ToString("dd-MM-yyyy");
            DataSet ds = new DataSet();
            ds = Gen.GetR1ReportbyDistrictid("%");
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
                LblProjCost.Text = "Total Capital Investment (Rs. in Crores) :" + ds.Tables[1].Rows[0][0].ToString().Trim();

                grdDetails0.DataSource = ds.Tables[2];
                grdDetails0.DataBind();

                grdDetails3.DataSource = null;
                grdDetails3.DataBind();

                grdDetails1.DataSource = ds.Tables[4];
                grdDetails1.DataBind();

                grdDetails2.DataSource = ds.Tables[5];
                grdDetails2.DataBind();
                
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                grdDetails0.DataSource =null;
                grdDetails0.DataBind();
                grdDetails1.DataSource = null;
                grdDetails1.DataBind();
                grdDetails2.DataSource = null;
                grdDetails2.DataBind();
                grdDetails3.DataSource = null;
                grdDetails3.DataBind();
            }
            

           
        }

      
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {


       
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getcounties()
    {
       
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    void getPayams()
    {
       
    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
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

   
  
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
