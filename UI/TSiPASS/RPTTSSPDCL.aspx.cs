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
        
        DataSet ds = new DataSet();


        ds = Gen.GetTSSPDCL(Request.QueryString[0].ToString().Trim());
        //ds = Gen.GetTSSPDCL("1076");
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        if (!IsPostBack)
        {
           
        }

      
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        
    }
    
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
      
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
