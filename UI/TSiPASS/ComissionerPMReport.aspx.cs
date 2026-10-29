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
    decimal district11, district12, district13, state11, state12, state13;
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (Session["user"] != null && Session["user"] != "")
            //{ }
            //else
            //{
            //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
            //}
            DataSet ds = new DataSet();
            if (Session["userlevel"].ToString() == "1")
            {
                lblHeading.Text = "COMMISSIONER'S DASH BOARD";
                lblHeading2.Text = "COMMISSIONER'S DASH BOARD";
            }
            else
            {
                lblHeading.Text = "GM'S DASH BOARD";
                lblHeading2.Text = "GM'S DASH BOARD";
            }
            if (!IsPostBack)
            {
                int year = DateTime.Now.Year - 5;

                for (int Y = year; Y <= DateTime.Now.Year; Y++)
                {

                    ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
                }

                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                ddlMonth.SelectedIndex = DateTime.Now.Month;
                getIPOS();

                fillGrid();


                //ds = Gen.DistrictWiseReport();


                // grdDetails.DataSource = ds.Tables[0];
                //grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    void fillGrid()
    {
        try
        {

            DataSet ds = new DataSet();

            ds = Gen.GetIPOwiseDashboard(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), ddlIPOname.SelectedValue.ToString(), ddlStatus.SelectedValue.ToString(), Session["uid"].ToString());
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
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void getIPOS()
    {
        try
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.GetIPOS(Session["uid"].ToString());

            ddlIPOname.DataSource = dsnew.Tables[0];
            ddlIPOname.DataTextField = "Dept_Name";
            ddlIPOname.DataValueField = "intUserid";
            ddlIPOname.DataBind();
            ddlIPOname.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
        Response.Redirect("GMWISEReport.aspx");

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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[29].Text = "8 of 8";
                int cnt = 0;
                if (e.Row.Cells[6].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[9].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[12].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[15].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[18].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[21].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[24].Text == "0")
                {
                    cnt = cnt + 1;
                }
                if (e.Row.Cells[28].Text == "0")
                {
                    cnt = cnt + 1;
                }

                e.Row.Cells[29].Text = cnt.ToString() + " of 8";
            }
            //    decimal district1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level"));
            //    district11 = district1 + district11;

            //    decimal state1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level"));
            //    state11 = state1 + state11;


            //    decimal district2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level1"));
            //    district12 = district2 + district12;


            //    decimal state2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level1"));
            //    state12 = state2 + state12;

            //    decimal district3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level2"));
            //    district13 = district3 + district13;

            //    decimal state3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level2"));
            //    state13 = state3 + state13;

            //    HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            //    h1.Target = "_blank";
            //    h1.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=1&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //    HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            //    h2.Target = "_blank";
            //    h2.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=2&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //    HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            //    h3.Target = "_blank";
            //    h3.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=3&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //    HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //    h4.Target = "_blank";
            //    h4.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=4&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //    HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            //    h5.Target = "_blank";
            //    h5.NavigateUrl = "CommissionerDashboardDrilldown.aspx?Stage=5&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //    HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            //    h6.Target = "_blank";
            //    h6.NavigateUrl = "CommissionerApproval.aspx?Stage=6&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

            //}

            //if (e.Row.RowType == DataControlRowType.Footer)
            //{

            //    e.Row.Cells[1].Text = "Total";
            //    e.Row.Cells[2].Text = district11.ToString();
            //    e.Row.Cells[3].Text = state11.ToString();
            //    e.Row.Cells[4].Text = district12.ToString();
            //    e.Row.Cells[5].Text = state12.ToString();
            //    e.Row.Cells[6].Text = district13.ToString();
            //    e.Row.Cells[7].Text = state13.ToString();
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 5;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Bank Wise Report";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Bank Visit Report";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Vehicle Inspection";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "TSiPASS";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "PMEGP & Mudra";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Closed Units";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);


                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Advance Subsidy";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 3;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Industrial Catalogue";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}
