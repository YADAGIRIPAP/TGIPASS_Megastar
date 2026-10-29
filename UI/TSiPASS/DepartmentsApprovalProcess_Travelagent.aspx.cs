using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_DepartmentsApprovalProcess_Travelagent : System.Web.UI.Page
{
    Cls_travelagent Gen = new Cls_travelagent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {

            fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    void fillGrid()
    {

        DataSet dsn = new DataSet();
        if (Request.QueryString[0].ToString().Trim() == "1")
        {
            dsn = Gen.GetCompletedbyApproval_Travelagent2A("12", txtFromDate.Text, txtToDate.Text, Session["User_Code"].ToString().Trim());
        }
        else if (Request.QueryString[0].ToString().Trim() == "2")
        {
            dsn = Gen.GetCompletedbyApproval_Travelagent3A("12", txtFromDate.Text, txtToDate.Text, Session["User_Code"].ToString().Trim());
        }
        else
        {
            dsn = Gen.GetCompletedbyApproval_Travelagent("12", txtFromDate.Text, txtToDate.Text, Session["User_Code"].ToString().Trim());
        }

        if (dsn != null && dsn.Tables.Count > 0 && dsn.Tables[0].Rows.Count > 0)
        {

            grdDetails.DataSource = dsn.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillGrid();
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text.Trim() == "Y")
            {
                e.Row.Cells[5].Text = "Please process this application in Concerned Department portal";
                e.Row.Cells[5].Font.Bold = true;
            }
            else
            {
                e.Row.Cells[5].Text = "Please process this application in TS-iPASS portal";
            }
            HyperLink h1 = (HyperLink)e.Row.Cells[4].Controls[0];
            string fromdate, Todate;
            if (txtFromDate.Text == "" || txtToDate.Text == "")
            {

                fromdate = "%";
                Todate = "%";
                h1.Text = "Approve";
                h1.NavigateUrl = "ApproveDetailsbyquery_Travelagent.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();
            }
            else
            {
                h1.Text = "Approve";
                fromdate = txtFromDate.Text;
                Todate = txtToDate.Text;
                h1.NavigateUrl = "ApproveDetailsbyquery_Travelagent.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;
            }
        }
      
    }

    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        HyperLink h1 = (HyperLink)row.FindControl("h1");
        HyperLink h2 = (HyperLink)row.FindControl("h2");
        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");
        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");
        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        int result = 0;
        result = Gen.insertDepartmentProcess_TravelAgent(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());
        if (ddlStatus.SelectedValue.ToString() == "8")
        {
            int i = 1;
            if (i > 0)
            {
                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Registered";
                return;
            }
        }

        if (result > 0)
        {
            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Registered";
        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";
        }
    }












}