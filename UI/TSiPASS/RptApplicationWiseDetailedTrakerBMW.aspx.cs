using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class UI_TSiPASS_RptApplicationWiseDetailedTrakerBMW : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;
    string intqnreid;
    BMWClass objbmw = new BMWClass();
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");

        //}
        if (!IsPostBack)
        {

            //getdistricts();
            ///  fillgrid();
            ///  
            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}


            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}
        }
        //ds = Gen.sp_GetDistriciWiseReport(ddldistrict.SelectedValue, ddlCategory.SelectedValue);
        intqnreid = Request.QueryString[0].ToString();
        ds = objbmw.ApplicationWiseDetailedTrakerBMW(intqnreid.ToString());
        Session["Applid"] = intqnreid.ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            labUidNumber.Text = ds.Tables[0].Rows[0]["UID Number"].ToString();
            //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            labNameandAddress.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
            labLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
            labTotalInvestment.Text = ds.Tables[0].Rows[0]["Total Investment"].ToString();
            //labLineofActivity.Text= ds.Tables[0].Rows[0]["LineofActivityType"].ToString();

            //labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["Category of Industry"].ToString();
            labDOA.Text = ds.Tables[0].Rows[0]["Date of Application"].ToString();
            labNameandAddress0.Text = ds.Tables[0].Rows[0]["PropAddress"].ToString();
        }
        grdDetails.DataSource = ds.Tables[1];
        grdDetails.DataBind();
    }
    #endregion


    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    fillgrid();
    //}
    //void fillgrid()
    //{

    //    string User = "";
    //    if (Session["user_type"].ToString() == "TST")
    //    {
    //        User = Session["uid"].ToString();
    //    }
    //    else
    //    {
    //        User = "%";
    //    }

    //    DataSet ds = Gen.getCASearch(ddlState.SelectedValue, ddlCounties.SelectedValue,txtca.Text,User);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblMsg.Text = ds.Tables[0].Rows.Count.ToString() + " Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //    else
    //    {
    //        lblMsg.Text = "No Records found.";
    //        grdDetails.DataSource = ds.Tables[0];
    //        grdDetails.DataBind();
    //    }
    //}


    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        //dsnew = Gen.GetDistricts1();
        //ddldistrict.DataSource = dsnew.Tables[0];
        //ddldistrict.DataTextField = "District_Name";
        //ddldistrict.DataValueField = "District_Id";
        //ddldistrict.DataBind();
        //ddldistrict.Items.Insert(0, "--Select--");

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //ddldistrict.SelectedIndex = 0;
        //  txtRegDate.Text = "";
        //  ddlCategory.SelectedIndex = 0;

    }


    protected void BtnSave1_Click(object sender, EventArgs e)
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NumberofApprovalsappliedfor"));
        //    NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

        //    decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Completed"));
        //    Completed1 = Completed + Completed1;


        //    decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
        //    QueryRaised1 = QueryRaised + QueryRaised1;


        //    decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

        //    decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pendinglessthan3days"));
        //    Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


        //    decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Numberofpaymentreceivedfor"));
        //    Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;


        //}

        //if (e.Row.RowType == DataControlRowType.Footer)
        //{

        //    e.Row.Cells[1].Text = "Total";
        //    e.Row.Cells[2].Text = NumberofApprovalsappliedfor1.ToString();
        //    e.Row.Cells[3].Text = Completed1.ToString();
        //    e.Row.Cells[4].Text = QueryRaised1.ToString();
        //    e.Row.Cells[5].Text = Pendinglessthan3days1.ToString();
        //    e.Row.Cells[6].Text = Pendingmorthan3days1.ToString();
        //    e.Row.Cells[7].Text = Numberofpaymentreceivedfor1.ToString();
        //}
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


            TableCell HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();

            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Font.Bold = true;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();



            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderGridRow.Cells.Add(HeaderCell);




            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Applicant Status on Approvals";
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Pre-Scrutiny Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Payment Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "Approval Status ";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            //HeaderCell.Text = "Additions";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 1;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.Text = "";
            HeaderCell.Visible = true;
            HeaderGridRow.Cells.Add(HeaderCell);


            grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }
}