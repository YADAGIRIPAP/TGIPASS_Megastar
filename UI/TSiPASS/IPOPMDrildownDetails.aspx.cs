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



        
        if (!IsPostBack)
        {
            
        }
        if (Request.QueryString.Count > 0)
        {
           

            if (!IsPostBack)
            {
               
            }
        }
        else
        {
           
            
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
   
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        fetchIncentivedet();
    }
    protected void fetchIncentivedet()
    {
        DataSet ds = new DataSet();

        ds = Gen.fetchIPOPMDashboardDril(Session["uid"].ToString(), Session["VMonth"].ToString().Trim(), Session["VYear"].ToString().Trim(), Request.QueryString[0].ToString().Trim());
        if (ds.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            if (Request.QueryString[0].ToString().Trim() == "1000")
            {
                grdDetails.Columns[1].Visible = true;
            }
            else
            {
                grdDetails.Columns[1].Visible = false;
            }
            
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
       
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
            if (Request.QueryString[0].ToString().Trim() == "1000")
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter");
                h2.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FileDownload"));
            }
           
        }
    }
   

    
}
