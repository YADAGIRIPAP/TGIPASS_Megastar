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
    decimal district11, district12, district13, district14, state11, state12, state13, state14;
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
        DataSet ds = new DataSet();
        
        if (!IsPostBack)
        {
            ds = Gen.DistrictWiseReportCFO1();
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
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
          decimal district1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level"));
            district11 = district1 + district11;

            decimal state1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level"));
            state11 = state1 + state11;


            decimal district2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level1"));
            district12 = district2 + district12;


            decimal state2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level1"));
            state12 = state2 + state12;

            decimal district3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level2"));
            district13 = district3 + district13;

            decimal state3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level2"));
            state13 = state3 + state13;

            decimal district4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level Rejected"));
            district14 = district4 + district14;

            decimal state4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level Rejected"));
            state14 = state4 + state14;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            h1.Target = "_blank";
            h1.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=1&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            h2.Target = "_blank";
            h2.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=2&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            h3.Target = "_blank";
            h3.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=3&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            h4.Target = "_blank";
            h4.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=4&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            h5.Target = "_blank";
            h5.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=5&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            h6.Target = "_blank";
            //h6.NavigateUrl = "CommissionerDashboardDrilldownCFO.aspx?Stage=6&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            h6.NavigateUrl = "CommissionerApprovalCFO.aspx?Stage=6&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            h7.Target = "_blank";
            h7.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=7&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
            h8.Target = "_blank";
            h8.NavigateUrl = "CommissionerDashboardDrilldownCFO1.aspx?Stage=8&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = district11.ToString();
            e.Row.Cells[3].Text = state11.ToString();
            e.Row.Cells[4].Text = district12.ToString();
            e.Row.Cells[5].Text = state12.ToString();
            e.Row.Cells[6].Text = district13.ToString();
            e.Row.Cells[7].Text = state13.ToString();
            e.Row.Cells[8].Text = district14.ToString();
            e.Row.Cells[9].Text = state14.ToString();
        }
   
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableCell HeaderCell = new TableCell();
            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Prescrutiny Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Payment / Approval Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Approved Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Rejected Stage";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }
}
