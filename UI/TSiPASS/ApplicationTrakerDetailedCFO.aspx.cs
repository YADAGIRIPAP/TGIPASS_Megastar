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

//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch


public partial class TSTBDCReg1 : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
    #region Declaration
    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;


    DataSet dslist;


    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }
        try
        {
            if (!IsPostBack)
            {
                //getdistricts();
                ///  fillgrid();
                ///  
                DataSet dscheck = new DataSet();
                //dscheck = Gen.GetApplicationTrackerDetailedCFOnew(Request.QueryString[0].ToString().Trim());
                //if (dscheck.Tables[0].Rows.Count > 0)
                //{
                //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                //}
                //else
                //{
                //    Session["Applid"] = "0";
                //}

                //ds = Gen.sp_GetDistriciWiseReport(ddldistrict.SelectedValue, ddlCategory.SelectedValue);
                if (Request.QueryString.Count > 0)
                {
                    ds = Gen.GetApplicationTrackerDetailed2newCFO(Request.QueryString[0].ToString().Trim());
                }
                else
                {
                    dscheck = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                    if (dscheck.Tables[0].Rows.Count > 0)
                    {
                        Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                        ds = Gen.GetApplicationTrackerDetailed2newCFO(Session["Applid"].ToString());
                    }
                    else
                    {
                        Session["Applid"] = "0";
                    }
                }
                //ds = Gen.GetApplicationTrackerDetailed2newCFO(Session["Applid"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUID.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    // labUidNumber.Attributes["href"] = "ViewCFEPrint.aspx?intApplid=" + Session["intCFEEnterpid"].ToString();
                    //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    labUidNumber.Attributes["href"] = "CFOPrint.aspx?intApplid=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    //labUidNumber.Attributes["href"] = "CFOPrint.aspx?intApplid=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    HyperLinkSubsidy.NavigateUrl = "frmViewAttachmentDetailsCFO.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["INTCFEENTERPID"].ToString();
                    labNameandAddress.Text = ds.Tables[0].Rows[0]["Name of the Industry"].ToString();
                    labLineofActivity.Text = ds.Tables[0].Rows[0]["Line of Activity"].ToString();
                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                    lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();

                    labDOA.Text = ds.Tables[0].Rows[0]["Date of Application of  industry"].ToString();
                    labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["CategoryOfIndustry"].ToString();
                    labTotalInvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString() + " Crore "; //+ ds.Tables[0].Rows[0]["CurrencyType"].ToString();
                    // labNameandAddress0.Text=ds.Tables[0].Rows[0]["PropAddress"].ToString();
                    lblpolution.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                    lblEmploymenttot.Text = ds.Tables[0].Rows[0]["Employment"].ToString();
                }
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
    }
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    //if (Session.Count <= 0)
    //    //{
    //    //    Response.Redirect("../../frmUserLogin.aspx");
    //    //}
    //    if (!IsPostBack)
    //    {
    //        //getdistricts();
    //      ///  fillgrid();
    //      ///  
    //        DataSet dscheck = new DataSet();
    //        dscheck = Gen.GetApplicationTrackerDetailedCFOnew(Request.QueryString[0].ToString().Trim());
    //        if (dscheck.Tables[0].Rows.Count > 0)
    //        {
    //            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
    //        }
    //        else
    //        {
    //            Session["Applid"] = "0";
    //        }
    //    }
    //    //ds = Gen.sp_GetDistriciWiseReport(ddldistrict.SelectedValue, ddlCategory.SelectedValue);
    //    ds = Gen.GetApplicationTrackerDetailed2newCFO(Session["Applid"].ToString());
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblUID.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
    //       // labUidNumber.Attributes["href"] = "ViewCFEPrint.aspx?intApplid=" + Session["intCFEEnterpid"].ToString();
    //        //labNameandAddress.Text = ds.Tables[0].Rows[0]["Name"].ToString();
    //        labNameandAddress.Text = ds.Tables[0].Rows[0]["Name of the Industry"].ToString();
    //        labLineofActivity.Text = ds.Tables[0].Rows[0]["Line of Activity"].ToString();
    //        lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
    //        lblDistrict.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();

    //        labDOA.Text = ds.Tables[0].Rows[0]["Date of Application of  industry"].ToString();
    //        labCategoryofIndustry.Text = ds.Tables[0].Rows[0]["CategoryOfIndustry"].ToString();
    //        labTotalInvestment.Text = ds.Tables[0].Rows[0]["Investment"].ToString() + " Crore "; //+ ds.Tables[0].Rows[0]["CurrencyType"].ToString();
    //        // labNameandAddress0.Text=ds.Tables[0].Rows[0]["PropAddress"].ToString();
    //        lblpolution.Text = ds.Tables[0].Rows[0]["Category"].ToString();
    //        lblEmploymenttot.Text = ds.Tables[0].Rows[0]["Employment"].ToString();
    //    }
    //    grdDetails.DataSource = ds.Tables[0];
    //    grdDetails.DataBind();
    //}
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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string Statusid = DataBinder.Eval(e.Row.DataItem, "intStageid").ToString();
                if (Statusid != "")
                {
                    int Statusidnew = Convert.ToInt32(Statusid);
                    if (Statusidnew == 13 || Statusidnew == 14 || Statusidnew == 15 || Statusidnew == 16)
                    {
                        e.Row.FindControl("lblverified").Visible = false;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("lblverified").Visible = true;
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                    }

                    if (((HyperLink)e.Row.FindControl("hyperboilerRegistration")).NavigateUrl == "")
                    {
                        e.Row.FindControl("hyperboilerRegistration").Visible = false;
                    }
                    else
                    {
                        e.Row.FindControl("hyperboilerRegistration").Visible = true;
                    }
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
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
        try
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
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
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
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Prescrutiny Status";
                HeaderGridRow.Cells.Add(HeaderCell);

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
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                HeaderCell.Font.Bold = true;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Text = "Approval Stage";
                HeaderCell.Visible = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Font.Bold = true;
                HeaderCell.Text = "";
                HeaderGridRow.Cells.Add(HeaderCell);
                grdDetails.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            //lblmsg.Text = ex.Message;

        }
    }
}

