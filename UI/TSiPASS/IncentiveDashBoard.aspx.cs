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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
//created by suresh as on 1-17-2016 for county adm lookup 
//tables td_CountyAdmDet,getCASearch



public partial class UI_TSiPASS_RptYEARWISEPROGRESSNew : System.Web.UI.Page
{
    decimal NumberofApprovalsappliedfor1, Completed1, Pendinglessthan3days1, Numberofpaymentreceivedfor24, Numberofpaymentreceivedfor12, Numberofpaymentreceivedfor22, Pendingmorthan3days1, QueryRaised1, Numberofpaymentreceivedfor1;
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

        if (!IsPostBack)
        {
            BindDistricts();

            //BindFinancialYears(ddlFinancialYear);

            //FillGridDetails();
            ///  fillgrid();
            ///  

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                ddlProp_intDistrictid.SelectedIndex = 0;
            }

            string FromdateforDB = "", TodateforDB = "";

            if (Request.QueryString["input"] != null && Request.QueryString["input"] != "")
            {
                //rbtnlstInputType.SelectedValue = Request.QueryString["input"].ToString();
                //rbtnlstInputType_SelectedIndexChanged(sender, e);

                //if (Request.QueryString["FinYear"] != null && Request.QueryString["FinYear"] != "" && Request.QueryString["FinYear"] != "--Select--")
                //{
                //    ddlFinancialYear.SelectedValue = Request.QueryString["FinYear"].ToString();
                //}
                if (Request.QueryString["fromdate"] != null && Request.QueryString["fromdate"] != "" && Request.QueryString["todate"] != null && Request.QueryString["todate"] != "")
                {
                    // Label1.Text = "Report from " + Request.QueryString["fromdate"].ToString().Trim() + " To " + Request.QueryString["todate"].ToString().Trim();
                    txtFromDate.Text = Request.QueryString["fromdate"].ToString().Trim();
                    txtTodate.Text = Request.QueryString["todate"].ToString().Trim();
                }

                //if (Request.QueryString["cate"] != null && Request.QueryString["cate"].ToString() != "")
                //{
                //    //ddlCategory.SelectedValue = Request.QueryString["cate"].ToString().Trim();
                //    ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByText(Request.QueryString["cate"].ToString().Trim()));
                //}
                //if (Request.QueryString["dist"] != null && Request.QueryString["dist"].ToString() != "")
                //    ddldistrict.SelectedValue = Request.QueryString["dist"].ToString().Trim();
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }

                FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
            }
            else
            {
                txtFromDate.Text = "01-04-2016";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
                {
                    FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                    TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                }
                FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
            }
        }
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


    //protected void getdistricts()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetDistricts();
    //    ddldistrict.DataSource = dsnew.Tables[0];
    //    ddldistrict.DataTextField = "District_Name";
    //    ddldistrict.DataValueField = "District_Id";
    //    ddldistrict.DataBind();
    //    ddldistrict.Items.Insert(0, "--Select--");
    //    if (Session["DistrictID"].ToString().Trim() != "")
    //    {
    //        ddldistrict.SelectedValue = Session["DistrictID"].ToString().Trim();
    //        ddldistrict.Enabled = false;
    //    }
    //    else
    //    {
    //        ddldistrict.Enabled = true;
    //    }
    //}
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //  ddldistrict.SelectedIndex = 0;
        //  txtRegDate.Text = "";
        //  ddlCategory.SelectedIndex = 0;

    }
    public void FillGridDetails(string fromdate, string todate, string Districtid)
    {
        ds = Gen.GetIncentiveDashBoard(fromdate, todate, Districtid);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[0];
                grdDetails.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvLevel2.DataSource = ds.Tables[1];
                gvLevel2.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                gvLevel3.DataSource = ds.Tables[2];
                gvLevel3.DataBind();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                gvLevel4.DataSource = ds.Tables[3];
                gvLevel4.DataBind();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[4];
                GridView1.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridView2.DataSource = ds.Tables[5];
                GridView2.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridView3.DataSource = ds.Tables[5];
                GridView3.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridView4.DataSource = ds.Tables[5];
                GridView4.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridView5.DataSource = ds.Tables[5];
                GridView5.DataBind();
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                GridView6.DataSource = ds.Tables[6];
                GridView6.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                GridView7.DataSource = ds.Tables[5];
                GridView7.DataBind();
            }
            // Label1.Text = "Report from 1st April 2016 to " + System.DateTime.Now.ToString("dd-MMM-yyyy");
            string fromdt = "", Todt = "";
            //if (rbtnlstInputType.SelectedValue == "N")
            //{
            //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;

            //}
            //else
            //{
            //    Label1.Text = "Report of Financial Year : " + ddlFinancialYear.SelectedItem.Text;

            //}
        }

        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        string FromdateforDB = "", TodateforDB = "";

        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
        }
        else
        {
            Failure.Visible = true;
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //decimal NumberofApprovalsappliedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Application received"));
            //NumberofApprovalsappliedfor1 = NumberofApprovalsappliedfor + NumberofApprovalsappliedfor1;

            //decimal Completed = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total Investments"));
            //Completed1 = Completed + Completed1;


            //decimal QueryRaised = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total deptl Approvals Required"));
            //QueryRaised1 = QueryRaised + QueryRaised1;


            //decimal Pendinglessthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals already taken by applicant"));
            //Pendinglessthan3days1 = Pendinglessthan3days + Pendinglessthan3days1;

            //decimal Pendingmorthan3days = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Applied by applicant"));
            //Pendingmorthan3days1 = Pendingmorthan3days + Pendingmorthan3days1;


            //decimal Numberofpaymentreceivedfor = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Net Approvals required"));
            //Numberofpaymentreceivedfor1 = Numberofpaymentreceivedfor + Numberofpaymentreceivedfor1;

            //decimal Numberofpaymentreceivedfor11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Pending"));
            //Numberofpaymentreceivedfor12 = Numberofpaymentreceivedfor11 + Numberofpaymentreceivedfor12;

            //decimal Numberofpaymentreceivedfor21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Deptl Approvals Issued"));
            //Numberofpaymentreceivedfor22 = Numberofpaymentreceivedfor21 + Numberofpaymentreceivedfor22;

            //decimal Numberofpaymentreceivedfor23 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TS-iPASS Approvals"));
            //Numberofpaymentreceivedfor24 = Numberofpaymentreceivedfor23 + Numberofpaymentreceivedfor24;





            HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            //HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h2.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h2.NavigateUrl = "frmYearstatusNew.aspx?status=B&lbl=Approvals Required&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            //HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h3.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h3.NavigateUrl = "frmYearstatusNew.aspx?status=C&lbl=Approvals Already Taken By Applicant&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            //HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h4.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h4.NavigateUrl = "frmYearstatusNew.aspx?status=D&lbl=Net Approvals Required&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            HyperLink h5 = (HyperLink)e.Row.Cells[2].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[3].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[4].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[6].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[8].Controls[0];
            h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[9].Controls[0];
            h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6kl = (HyperLink)e.Row.Cells[10].Controls[0];
            h6kl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6ml = (HyperLink)e.Row.Cells[7].Controls[0];
            h6ml.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6Nl = (HyperLink)e.Row.Cells[11].Controls[0];
            h6Nl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            //HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            //HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            //HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            // HyperLink h5c = (HyperLink)e.Row.Cells[10].Controls[0];
            //HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            //h5c.Target = "_blank";
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5c.NavigateUrl = "frmYearstatusNew.aspx?status=I&lbl=TS-IPASS Approvals&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();


        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {

        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        ExportToExcel();
       

    }

    protected void ExportToExcel()
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            string FileName = lblHeading.Text;
            FileName = FileName.Replace(" ", "");
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdDetails.RenderControl(hw);
                gvLevel2.RenderControl(hw);
                gvLevel3.RenderControl(hw);
                gvLevel4.RenderControl(hw);
                GridView1.RenderControl(hw);
                GridView2.RenderControl(hw);
                GridView3.RenderControl(hw);
                GridView4.RenderControl(hw);
                GridView5.RenderControl(hw);
                GridView6.RenderControl(hw);
                GridView7.RenderControl(hw);
                string label1text = Label1.Text;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    //this.FillGridDetails(rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), FromdateforDB, TodateforDB);
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.Visible = false;
                    grdDetails.RenderControl(hw);
                    gvLevel2.AllowPaging = false;
                    gvLevel2.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    gvLevel2.FooterRow.Visible = false;
                    gvLevel2.RenderControl(hw);

                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= R1.1Abstract-FinancialYearwise" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }
    //protected void PrintPdf()
    //{
    //    try
    //    {
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //            {
    //                //To Export all pages
    //                //trLogo.Visible = true;

    //                //this.FillGridDetails();

    //                //grdDetails.RenderControl(hw);
    //                //StringReader sr = new StringReader(sw.ToString());
    //                //Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
    //                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                //pdfDoc.Open();
    //                //htmlparser.Parse(sr);
    //                //pdfDoc.Close();
    //                grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

    //                grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
    //                grdDetails.FooterStyle.ForeColor = System.Drawing.Color.Black;

    //                // grdExport.Columns[1].Visible = false;
    //                grdDetails.RenderControl(hw);
    //                StringReader sr = new StringReader(sw.ToString());
    //                Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
    //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
    //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //                pdfDoc.Open();
    //                htmlparser.Parse(sr);
    //                pdfDoc.Close();


    //                Response.ContentType = "application/pdf";
    //                Response.AddHeader("content-disposition", "attachment;filename= DistrictFinancialRept.pdf");
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //                Response.Write(pdfDoc);
    //                Response.Flush();
    //                Response.End();
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}


    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
    //public void BindFinancialYears(DropDownList ddlFinYear)
    //{
    //    try
    //    {
    //        DataSet dsd = new DataSet();
    //        ddlFinYear.Items.Clear();
    //        dsd = Gen.GetFinancialYearsForReports();
    //        //ListItem ITEM=new ListItem
    //        if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
    //        {
    //            ddlFinYear.DataSource = dsd.Tables[0];
    //            ddlFinYear.DataValueField = "SlNo";
    //            ddlFinYear.DataTextField = "FinancialYear";
    //            ddlFinYear.DataBind();
    //            //if (Session["Role_Code"] != null && Session["Role_Code"].ToString() != "" && Session["Role_Code"].ToString() == "COMM")
    //            //{
    //            //    AddAll(ddlFinYear);
    //            //}
    //        }


    //        ddlFinYear.Items.Insert(0, "--Select--");

    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = ex.Message;
    //        //lblmsg0.CssClass = "errormsg";
    //    }
    //}
    protected void btnGet_Click(object sender, EventArgs e)
    {
        int valid = 0;
        lblmsg0.Text = "";
        string FromdateforDB = "", TodateforDB = "";
        Failure.Visible = false;
        //if (rbtnlstInputType.SelectedValue == "N")
        //{
        if (txtFromDate.Text == "" || txtFromDate.Text == null)
        {
            lblmsg0.Text = "Please Enter From Date <br/>";
            valid = 1;
        }
        if (txtTodate.Text == "" || txtTodate.Text == null)
        {
            lblmsg0.Text += "Please Enter To Date <br/>";
            valid = 1;
        }
        if (valid == 0)
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }
        //}
        //else
        //{
        //    if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
        //    {
        //        lblmsg0.Text = "Please Select Financial Year";
        //        valid = 1;
        //    }
        //}
        if (valid == 0)
        {
            string fromdt = "", Todt = "";
            //if (rbtnlstInputType.SelectedValue == "N")
            //{
            //Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + DateTime.Now;
            //}
            //else
            //{
            //    Label1.Text = "Report of Financial Year : " + ddlFinancialYear.SelectedItem.Text;
            //    //Label387.Text = "Number of Industries given Approvals";
            //}
            FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
        }
        else
        {
            Failure.Visible = true;
        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
            else
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem("--All--", "%");
                ddlProp_intDistrictid.Items.Insert(0, li);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    //protected void rbtnlstInputType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    grdDetails.DataSource = null;
    //    grdDetails.DataBind();
    //    if (rbtnlstInputType.SelectedValue == "N")
    //    {
    //        trBetweenDates.Visible = true;
    //        trFinYears.Visible = false;
    //        ClearFields();
    //    }
    //    else
    //    {
    //        trBetweenDates.Visible = false;
    //        trFinYears.Visible = true;
    //        ClearFields();
    //    }
    //}

    private void ClearFields()
    {
        Label1.Text = "";
        // Label8.Text = "";
        txtFromDate.Text = "";
        txtTodate.Text = "";
        //System.Web.UI.WebControls.ListItem item = ddlFinancialYear.Items.FindByText("--Select--");
        //if (item != null)
        //{
        //    ddlFinancialYear.SelectedValue = "--Select--";
        //}
    }
    protected void gvLevel2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;


            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6K = (HyperLink)e.Row.Cells[8].Controls[0];
            h6K.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6L = (HyperLink)e.Row.Cells[9].Controls[0];
            h6L.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7L = (HyperLink)e.Row.Cells[10].Controls[0];
            h7L.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=2&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }
    protected void gvLevel3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=3&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }
    protected void gvLevel4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=4&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7 = (HyperLink)e.Row.Cells[6].Controls[0];
            h7.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h8 = (HyperLink)e.Row.Cells[7].Controls[0];
            h8.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h9 = (HyperLink)e.Row.Cells[8].Controls[0];
            h9.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h10 = (HyperLink)e.Row.Cells[9].Controls[0];
            h10.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=5&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7 = (HyperLink)e.Row.Cells[6].Controls[0];
            h7.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=6&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7 = (HyperLink)e.Row.Cells[6].Controls[0];
            h7.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h8 = (HyperLink)e.Row.Cells[7].Controls[0];
            h8.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=7&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h7 = (HyperLink)e.Row.Cells[6].Controls[0];
            h7.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h8 = (HyperLink)e.Row.Cells[7].Controls[0];
            h8.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=8&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=9&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=9&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=9&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h1D = (HyperLink)e.Row.Cells[3].Controls[0];
            h1D.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5D = (HyperLink)e.Row.Cells[4].Controls[0];
            h5D.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5aD = (HyperLink)e.Row.Cells[5].Controls[0];
            h5aD.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=10&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }

    protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink h1 = (HyperLink)e.Row.Cells[0].Controls[0];
            h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=11&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=11&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;

            HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=11&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text + "&District=" + ddlProp_intDistrictid.SelectedValue;
        }
    }
}
