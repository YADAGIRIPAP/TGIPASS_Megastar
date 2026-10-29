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
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        DataSet ds = new DataSet();
        string eid = Request.QueryString[0].ToString().Trim();
        if (!IsPostBack)
        {
            if (Session["userlevel"].ToString().Trim() == "10" && Session["user_id"].ToString().Trim().ToLower() != "indus")
            {
                ds = Gen.GetQueryResponseDetailsByEnterpIDDeptCFO(eid, Session["User_Code"].ToString().Trim());
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            else
            {


                ds = Gen.GetQueryResponseDetailsByEnterpIDCFO(eid);
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
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
   
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h3 = (HyperLink)e.Row.Cells[16].Controls[0];
            h3.Target = "_blank";

            h3.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFOEnterpid")).Trim();

            //string path = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryAttachmentFilePath")).Trim();
            //path = path.Replace(@"\", @"/");
            //h3.NavigateUrl = path.Replace(path.Substring(0, path.IndexOf(@"/Attachments")), "~") + "/" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryAttachmentFileName")).Trim();
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
