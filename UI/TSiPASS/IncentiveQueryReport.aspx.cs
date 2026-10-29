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
using System.Text;

using System.Drawing;
using System.Data.SqlClient;


using System.Collections.Generic;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.Data.SqlClient;

public partial class UI_TSIPASS_IncentiveQueryReport : System.Web.UI.Page
{
    int Yet_to_Start1, Yet_to_Start2, Yet_to_Start3, Yet_to_Start4, Yet_to_Start5, Yet_to_Start6, Yet_to_Start7, Yet_to_Start8;


    General gen = new General();
    General Gen = new General();
    int Sno = 0;

    DataSet ds;
    DataTable dt;
    int valid = 0;
    string FromdateforDB = "", TodateforDB = "";
    DataSet dslist;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            ViewState["Incentive"] = "ALL";
            getdistricts();
            txtFromDate.Text = "01-04-2016";
            DateTime today = DateTime.Today;
            txtTodate.Text = today.ToString("dd-MM-yyyy");
            if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
            {
                FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            }
            if (Session["uid"].ToString() == "3377")
            {
                fillgrid(null, "COUNT", null);
            }
            else
            {
                fillgrid(Session["DistrictID"].ToString(), "COUNT", null);
            }


        }
    }
    private void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        //ddlProp_intDistrictid.DataSource = dsnew.Tables[0];
        //ddlProp_intDistrictid.DataTextField = "District_Name";
        //ddlProp_intDistrictid.DataValueField = "District_Id";
        //ddlProp_intDistrictid.DataBind();
        //ddlProp_intDistrictid.Items.Insert(0, "--ALL--");

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        fillgrid(null, null, null);
    }

    protected void BtnSave1_Click(object sender, EventArgs e)
    {

        lblmsg0.Text = "";
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
            //fillgrid();
        }
        else
        {
            Failure.Visible = true;
        }
    }
    public void fillgrid(string District, string Type, string Incentive)
    {
        DataSet dsnew = new DataSet();
        string ReleaseProceedingNo = "";
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
        dsnew = GetIncentiveQueryDetails(null, null, District, Type, Incentive);
        //dsnew = GetAppealApplications(FromdateforDB, TodateforDB); //ddlProp_intDistrictid.SelectedValue);
        // lblMsg.Text = "";
        if (dsnew.Tables[0].Rows.Count > 0)
        {
            // lblMsg.Text = "Total Records :" +dsnew.Tables[0].Rows.Count.ToString();
            if (Incentive == null)
            {
                grdDetails.DataSource = dsnew.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdData.DataSource = dsnew.Tables[0];
                grdData.DataBind();
            }


            //bindgrdDetailsfooter(dsnew.Tables[0]);
        }
        else
        {
            //lblMsg.Text = "";
            // Label1.Text = "No Recards Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }


    public void bindgrdDetailsfooter(DataTable dtt)
    {
        decimal TOTALAPP = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Application")));
        decimal TOTREJECTED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Rejected")));
        decimal SCRUTINYPENDINGWITHIN = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Completed Within")));
        decimal SCRUTINYPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Scrutiny Completed Beyond")));
        decimal SCRUTINYPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total Scrutiny Completed")));
        decimal SCRUTINYPENWITHIN = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Pending Within")));
        decimal SCRUTINYBEYOND = dtt.AsEnumerable().Sum(rows => Convert.ToInt32(rows.Field<object>("Scrutiny Pending Beyond")));
        decimal TOTALSCRUTINYCOMPLETED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Scrutiny Total Pending")));

        decimal INSPECTIONPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Within")));
        decimal INSPECTIONPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Beyond")));
        decimal INSPECTIONPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Completed Total")));
        decimal INSPECTIONWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Within")));
        decimal INSPECTIONBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Beyond")));
        decimal INSPECTIONTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Inspection Pending Total")));

        decimal REFEREDPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Within")));
        decimal REFEREDPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Beyond")));
        decimal REFEREDPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered COI Total")));
        decimal REFEREDCOIWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Within")));
        decimal REFEREDCOIBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Beyond")));
        decimal REFERREDCOITOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Refered Pending COI Total")));

        decimal DLCPENDINGWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Approved Within")));
        decimal DLCPENDINGBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Approved Beyond")));
        decimal DLCPENDINGTOTAL = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total DLC Approved")));
        decimal TOTALDLCWITHIN = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Pending Within")));
        decimal TOTALDLCBEYOND = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("DLC Pending Beyond")));
        decimal TOTALDLCAPPROVED = dtt.AsEnumerable().Sum(row => Convert.ToInt32(row.Field<object>("Total DLC Pending")));
        //decimal NO_of_UnitsPER = decimal.Round((Working_Units_SLC / (NO_UNITS_SLC == 0 ? 1 : NO_UNITS_SLC)) * 100, 2, MidpointRounding.AwayFromZero);
        //decimal NO_of_Units_amountPER = decimal.Round((UC_Not_Updated_AMOUNT_SLC / (AMOUNT_RELEASED_SLC == 0 ? 1 : AMOUNT_RELEASED_SLC)) * 100, 2, MidpointRounding.AwayFromZero);

        grdDetails.FooterRow.HorizontalAlign = HorizontalAlign.Right;
        grdDetails.FooterRow.Font.Bold = true;
        grdDetails.FooterRow.Cells[1].Text = "Total";
        grdDetails.FooterRow.Cells[2].Text = TOTALAPP.ToString();
        grdDetails.FooterRow.Cells[3].Text = TOTREJECTED.ToString();
        grdDetails.FooterRow.Cells[4].Text = SCRUTINYPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[5].Text = SCRUTINYPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[6].Text = SCRUTINYPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[7].Text = SCRUTINYPENWITHIN.ToString();
        grdDetails.FooterRow.Cells[8].Text = SCRUTINYBEYOND.ToString();
        grdDetails.FooterRow.Cells[9].Text = TOTALSCRUTINYCOMPLETED.ToString();

        grdDetails.FooterRow.Cells[10].Text = INSPECTIONPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[11].Text = INSPECTIONPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[12].Text = INSPECTIONPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[13].Text = INSPECTIONWITHIN.ToString();
        grdDetails.FooterRow.Cells[14].Text = INSPECTIONBEYOND.ToString();
        grdDetails.FooterRow.Cells[15].Text = INSPECTIONTOTAL.ToString();

        grdDetails.FooterRow.Cells[16].Text = REFEREDPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[17].Text = REFEREDPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[18].Text = REFEREDPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[19].Text = REFEREDCOIWITHIN.ToString();
        grdDetails.FooterRow.Cells[20].Text = REFEREDCOIBEYOND.ToString();
        grdDetails.FooterRow.Cells[21].Text = REFERREDCOITOTAL.ToString();

        grdDetails.FooterRow.Cells[22].Text = DLCPENDINGWITHIN.ToString();
        grdDetails.FooterRow.Cells[23].Text = DLCPENDINGBEYOND.ToString();
        grdDetails.FooterRow.Cells[24].Text = DLCPENDINGTOTAL.ToString();
        grdDetails.FooterRow.Cells[25].Text = TOTALDLCWITHIN.ToString();
        grdDetails.FooterRow.Cells[26].Text = TOTALDLCBEYOND.ToString();
        grdDetails.FooterRow.Cells[27].Text = TOTALDLCAPPROVED.ToString();
    }


    public DataSet GetIncentiveQueryDetails(string fromdate, string todate, string District, string type, string incentiveid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FROMDATE",SqlDbType.VarChar),
                new SqlParameter("@TODATE",SqlDbType.VarChar),
                new SqlParameter("@District",SqlDbType.VarChar),
                new SqlParameter("@Type",SqlDbType.VarChar),
                new SqlParameter("@IncentiveID",SqlDbType.VarChar),
               //new SqlParameter("@District",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        pp[2].Value = District;
        pp[3].Value = type;
        pp[4].Value = incentiveid;


        Dsnew = gen.GenericFillDs("USP_GET_Incentives_QueryHistroy", pp);
        return Dsnew;
    }
    public DataSet GetAppealApplications(string fromdate, string todate)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@FROMDATE",SqlDbType.VarChar),
                new SqlParameter("@TODATE",SqlDbType.VarChar),
               //new SqlParameter("@District",SqlDbType.VarChar)
               
           };
        pp[0].Value = fromdate;
        pp[1].Value = todate;


        Dsnew = gen.GenericFillDs("USP_GET_Incentives_ReportCompleted", pp);
        return Dsnew;
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
            if (ViewState["Incentive"].ToString() == "ALL")
            {
                fillgrid(Session["DistrictID"].ToString(), "COUNTS", null);
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grdDetails.RenderControl(hw);
                    //string label1text = Label1.Text;
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                    HttpContext.Current.Response.Write(headerTable);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            else
            {
                fillgrid(Session["DistrictID"].ToString(), "COUNTS", ViewState["Incentive"].ToString());
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grdData.RenderControl(hw);
                    //string label1text = Label1.Text;
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='6'></td></td></tr></table>";
                    HttpContext.Current.Response.Write(headerTable);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }





            //this.fillgrid();
        }
        catch (Exception e)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        //PrintPdf();
    }

    public string DisplayWithSuffix(int num)
    {
        if (num.ToString().EndsWith("11")) return num.ToString() + "th";
        if (num.ToString().EndsWith("12")) return num.ToString() + "th";
        if (num.ToString().EndsWith("13")) return num.ToString() + "th";
        if (num.ToString().EndsWith("1")) return num.ToString() + "st";
        if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
        if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
        return num.ToString() + "th";
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



            //Label lblDistId = (e.Row.FindControl("lblDistId") as Label);

            //HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h1.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=1&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h2.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h2.NavigateUrl = "frmYearstatusNew.aspx?status=B&lbl=Approvals Required&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            ////HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h3.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h3.NavigateUrl = "frmYearstatusNew.aspx?status=C&lbl=Approvals Already Taken By Applicant&dist=" + ddldistrict.SelectedValue + "&cate=" + ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            ////HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            //////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            //////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h4.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h4.NavigateUrl = "frmYearstatusNew.aspx?status=D&lbl=Net Approvals Required&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();

            //HyperLink h5 = (HyperLink)e.Row.Cells[1].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=2&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h5a = (HyperLink)e.Row.Cells[2].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=3&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; // +"&District=" + lblDistId;

            //HyperLink h5b = (HyperLink)e.Row.Cells[3].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h5b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=4&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h6 = (HyperLink)e.Row.Cells[4].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            //h6.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=5&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text; //+"&District=" + lblDistId;

            //HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            //h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6b = (HyperLink)e.Row.Cells[7].Controls[0];
            //h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6c = (HyperLink)e.Row.Cells[8].Controls[0];
            //h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6kl = (HyperLink)e.Row.Cells[9].Controls[0];
            //h6kl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=9&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6ml = (HyperLink)e.Row.Cells[6].Controls[0];
            //h6ml.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=10&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            //HyperLink h6Nl = (HyperLink)e.Row.Cells[10].Controls[0];
            //h6Nl.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=11&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;// +"&District=" + lblDistId;

            ////HyperLink h6a = (HyperLink)e.Row.Cells[5].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6a.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=6&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h6b = (HyperLink)e.Row.Cells[6].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6b.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=7&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            ////HyperLink h6c = (HyperLink)e.Row.Cells[7].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h6c.NavigateUrl = "IncentiveDashBoardDrill.aspx?type=1&status=8&fromdate=" + txtFromDate.Text + "&todate=" + txtTodate.Text;

            //// HyperLink h5c = (HyperLink)e.Row.Cells[10].Controls[0];
            ////HiddenField HdfintApplicationid = (HiddenField)e.Row.Cells[0].FindControl("HdfintApplicationid");
            ////HdfintApplicationid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intHousingID")).Trim();
            ////h5c.Target = "_blank";
            //////h1.NavigateUrl = "BatchwisetrngMFrpt.aspx?trngids=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intTrngID")).Trim() + "&trngnames=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "trngName")).Trim() + "&intprjid=1025" + "&totsum=0";
            ////h5c.NavigateUrl = "frmYearstatusNew.aspx?status=I&lbl=TS-IPASS Approvals&dist=" + ddldistrict.SelectedValue+"&cate="+ddlCategory.SelectedItem.Text;// +Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intmandalId")).Trim();


        }
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }


    protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string divid = e.CommandArgument.ToString();
        if (e.CommandName == "INS1")
        {
            fillgrid(divid, "COUNTS", "1");
            ViewState["Incentive"] = "1";
        }
        else if (e.CommandName == "INS2")
        {
            fillgrid(divid, "COUNTS", "2");
            ViewState["Incentive"] = "2";
        }
        else if (e.CommandName == "INS3")
        {
            fillgrid(divid, "COUNTS", "3");
            ViewState["Incentive"] = "3";
        }
        else if (e.CommandName == "INS4")
        {
            fillgrid(divid, "COUNTS", "4");
            ViewState["Incentive"] = "4";
        }
        else if (e.CommandName == "INS5")
        {
            fillgrid(divid, "COUNTS", "5");
            ViewState["Incentive"] = "5";
        }
        else if (e.CommandName == "INS6")
        {
            fillgrid(divid, "COUNTS", "6");
            ViewState["Incentive"] = "6";
        }
        else if (e.CommandName == "INS7")
        {
            fillgrid(divid, "COUNTS", "7");
            ViewState["Incentive"] = "7";
        }
        else if (e.CommandName == "INS8")
        {
            fillgrid(divid, "COUNTS", "8");
            ViewState["Incentive"] = "8";
        }
        else if (e.CommandName == "INS9")
        {
            fillgrid(divid, "COUNTS", "9");
            ViewState["Incentive"] = "9";
        }
        else if (e.CommandName == "INS10")
        {
            fillgrid(divid, "COUNTS", "10");
            ViewState["Incentive"] = "10";
        }
        else if (e.CommandName == "INS11")
        {
            fillgrid(divid, "COUNTS", "11");
            ViewState["Incentive"] = "12";
        }
        else if (e.CommandName == "INS12")
        {
            fillgrid(divid, "COUNTS", "12");
            ViewState["Incentive"] = "12";
        }
        div_Print11.Visible = false;
        div_Print.Visible = true;

    }
}