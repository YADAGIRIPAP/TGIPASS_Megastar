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
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = Gen.GetPaymentDetails(Request.QueryString[0].ToString().Trim());

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }

      
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    
    
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
      
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

            h1.Target = "_blank";
            h1.NavigateUrl = "frmViewAttachmentDetailsDD.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID")).Trim();

        }

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
}
