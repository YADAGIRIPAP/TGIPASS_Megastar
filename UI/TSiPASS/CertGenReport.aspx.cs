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
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Home2.aspx");
            }
            DataSet ds = new DataSet();
            if (Session["userlevel"].ToString() == "1")
            {
                lblHeading.Text = "District Wise Certificates Generated";
                lblHeading2.Text = "District Wise Certificates Generated";
            }
            else
            {
                lblHeading.Text = "District Wise Certificates Generated";
                lblHeading2.Text = "District Wise Certificates Generated";
            }
            if (!IsPostBack)
            {
                ds = Gen.DistrictWiseCerGenReport();
                grdDetails.DataSource = ds.Tables[0];
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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                decimal district3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "District Level2"));
                district13 = district3 + district13;

                decimal state3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "State Level2"));
                state13 = state3 + state13;





                HyperLink h5 = (HyperLink)e.Row.Cells[2].Controls[0];
                h5.Target = "_blank";
                h5.NavigateUrl = "CertGenDrillDownReport.aspx?Stage=5&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();

                HyperLink h6 = (HyperLink)e.Row.Cells[3].Controls[0];
                h6.Target = "_blank";
                h6.NavigateUrl = "CertGenDrillDownReport.aspx?Stage=6&District=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictId")).Trim();


            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                HyperLink dtotal = new HyperLink();
                dtotal.ForeColor = System.Drawing.Color.White;
                dtotal.Target = "_blank";
                dtotal.NavigateUrl = "CertGenDrillDownReport.aspx?Stage=5&District=%";
                dtotal.Text = district13.ToString();
                e.Row.Cells[2].Controls.Add(dtotal);

                HyperLink stotal = new HyperLink();
                stotal.ForeColor = System.Drawing.Color.White;
                stotal.Target = "_blank";
                stotal.NavigateUrl = "CertGenDrillDownReport.aspx?Stage=6&District=%";
                stotal.Text = state13.ToString();
                e.Row.Cells[3].Controls.Add(stotal);
            }
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
                HeaderCell.ColumnSpan = 2;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 2;
                HeaderCell.RowSpan = 0;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "Certificates Generated";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
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
