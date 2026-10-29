using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
//using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;

public partial class UI_TSiPASS_RPT_GWStatereport : System.Web.UI.Page
{
    Cls_OSGroundWater obj_insert = new Cls_OSGroundWater();
 
   

    int statewellappl, staterigsappl;int districtwellappl,districtrigsappl;
    int wellappltype;int rigsappltype;
    int allwellappl, allwellappltype1, allwellappltype2, allwellappltype3, allwellappltype4;
    int allrigappl, allrignew, allrigrenewal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                BindFinancialYears();
                BindDistricts();
                Bindgrids();
                //txtFromDate.Text = "01-01-2021";
                //DateTime today = DateTime.Today;
                //txtTodate.Text = today.ToString("dd-MM-yyyy");
                //FromdateforDB = txtFromDate.Text;
                //TodateforDB = txtTodate.Text;
                //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));       
                //Label3.Text = "Report as on date " + DateTime.Now;
                //FromDateFinancialYear();
        }
    }


    #region

    public void BindFinancialYears()
    {
        General Gen = new General();
        try
        {
            DataSet dsd = new DataSet();
            ddlFinancialYear.Items.Clear();
            dsd = Gen.GetFinancialYearsForReports();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlFinancialYear.DataSource = dsd.Tables[0];
                ddlFinancialYear.DataValueField = "SlNo";
                ddlFinancialYear.DataTextField = "FinancialYear";
                ddlFinancialYear.DataBind();
                AddSelect(ddlFinancialYear);
            }
            else
            {
                AddSelect(ddlFinancialYear);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void BindDistricts()
    {
        try
        {
            ddl_district.Items.Clear();
            DataTable dsd = obj_insert.DB_GWgetdistricts();
            if (dsd != null && dsd.Rows.Count > 0)
            {
                ddl_district.DataSource = dsd;
                ddl_district.DataValueField = "District_Id";
                ddl_district.DataTextField = "District_Name";
                ddl_district.DataBind();
                AddSelect(ddl_district);
            }
            else
            {

                AddSelect(ddl_district);
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void rbtnlstInputType_SelectedIndexChanged(object sender, EventArgs e)
    {      
        //trFinYears.Visible = false;
        //txtFromDate.Enabled = true;
        //txtTodate.Enabled = true;
        //if (rbtnlstInputType.SelectedValue == "F")
        //{
        //    trFinYears.Visible = true;
        //    txtFromDate.Text = "";
        //    txtTodate.Text = "";
        //    txtFromDate.Enabled = false;
        //    txtTodate.Enabled = false;
        //    BindFinancialYears();
        //}       
    }
    protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindgrids();
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_district.SelectedIndex > 0)
        {
            Bindgrids();
        }
        else
        {
            lblmsg0.Text += "Please Enter District <br/>";
        }
            
    }
    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        Bindgrids();
    }
    protected void txtTodate_TextChanged(object sender, EventArgs e)
    {
        Bindgrids();
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        Bindgrids();
    }
    public void Bindgrids()
    {
        int valid = 0;
        lblmsg0.Text = "";
        Failure.Visible = false;
        txtFromDate.Enabled = true;
        txtTodate.Enabled = true;
        string FromdateforDB=null, TodateforDB= null, DistrictID= null;
        try
        {
            if(ddl_district.SelectedIndex>0)
            {
                DistrictID = Convert.ToString(ddl_district.SelectedValue);
            }
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
                
                   
                }
            
       
                if (ddlFinancialYear.SelectedItem.ToString() == "--Select--" || ddlFinancialYear.SelectedIndex<=0)
                {
                    if ((txtFromDate.Text == "" || txtFromDate.Text == null) && (txtTodate.Text == "" || txtTodate.Text == null))
                    {

                    }
                    else
                    {

                        if ((txtFromDate.Text!= "" || txtFromDate.Text!= null) && (txtTodate.Text!= "" || txtTodate.Text!= null))
                        {
                            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        }
                        else
                        {
                            if ((txtFromDate.Text == "" || txtFromDate.Text == null) && (txtTodate.Text != "" || txtTodate.Text != null))
                            {
                                lblmsg0.Text = "Please Enter From Date <br/>";
                                valid = 1;
                            }
                            else
                            {
                                if ((txtFromDate.Text != "" || txtFromDate.Text != null) && (txtTodate.Text == "" || txtTodate.Text == null))
                                {
                                    lblmsg0.Text += "Please Enter To Date <br/>";
                                    valid = 1;
                                }
                                else
                                {
                                    lblmsg0.Text = "Please Select Financial Year";
                                    valid = 1;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (valid == 0)
                    {
                        String Dates1 = Convert.ToString(ddlFinancialYear.SelectedValue);
                        string[] tokens1 = Dates1.Split('-');
                        string from = tokens1[0];
                        string todate = tokens1[1];
                        //FromdateforDB  = Convert.ToDateTime(Convert.ToString(tokens1[0])).ToString("MM/dd/yyyy");
                        FromdateforDB = Convert.ToString(DateTime.ParseExact(Convert.ToString(tokens1[0]), "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        DateTime startDate = Convert.ToDateTime(Convert.ToString(tokens1[1]));
                        DateTime endDate = startDate.AddMonths(1).AddDays(-1);
                        //TodateforDB  = Convert.ToString(endDate);
                        TodateforDB = Convert.ToString(DateTime.ParseExact(Convert.ToString(endDate), "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        txtFromDate.Text = FromdateforDB;
                        txtTodate.Text = TodateforDB;
                        txtFromDate.Enabled = false;
                        txtTodate.Enabled = false;
                    }
                }

            
            if (valid == 0)
            {
                Label3.Text = "Report as on date " + FromdateforDB+'-'+ TodateforDB;
                DataSet dsd = obj_insert.Getstatereport_groundwater(FromdateforDB, TodateforDB, DistrictID);
                if (dsd != null && dsd.Tables.Count > 0)
                {
                    grdDetails_state.DataSource = dsd.Tables[0];
                    grdDetails_state.DataBind();
                    grdDetails_district.DataSource = dsd.Tables[1];
                    grdDetails_district.DataBind();
                    grd_groundwaterappltype.DataSource = dsd.Tables[2];
                    grd_groundwaterappltype.DataBind();
                    grd_drillingappltype.DataSource = dsd.Tables[3];
                    grd_drillingappltype.DataBind();
                    grd_alldata.DataSource = dsd.Tables[4];
                    grd_alldata.DataBind();

                }
            }
            else
            {
                Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {

        }
    }

    #endregion

    protected void grdDetails_state_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails_state.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 2 || i == 3)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Applications";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

        }
    }
    protected void grdDetails_district_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails_district.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 2 || i == 3)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Applications";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 2;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);
        }
    }
    protected void grd_groundwaterappltype_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridViewRow gvHeaderRow = e.Row;
        //    GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    this.grd_groundwaterappltype.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

        //    int headerCellCount = gvHeaderRow.Cells.Count;
        //    int cellIndex = 0;

        //    for (int i = 0; i < headerCellCount; i++)
        //    {
        //        if (i == 2)
        //        {
        //            cellIndex++;
        //        }
        //        else
        //        {
        //            TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
        //            tcHeader.RowSpan = 2;
        //            gvHeaderRowCopy.Cells.Add(tcHeader);
        //        }
        //    }

        //    TableCell tcMergePackage = new TableCell();
        //    tcMergePackage.Text = "Well Applications";
        //    tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
        //    tcMergePackage.ColumnSpan = 2;
        //    gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);
        //}
    }
    protected void grd_drillingappltype_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridViewRow gvHeaderRow = e.Row;
        //    GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //    this.grd_drillingappltype.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

        //    int headerCellCount = gvHeaderRow.Cells.Count;
        //    int cellIndex = 0;

        //    for (int i = 0; i < headerCellCount; i++)
        //    {
        //        if (i == 2 )
        //        {
        //            cellIndex++;
        //        }
        //        else
        //        {
        //            TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
        //            tcHeader.RowSpan = 2;
        //            gvHeaderRowCopy.Cells.Add(tcHeader);
        //        }
        //    }

        //    TableCell tcMergePackage = new TableCell();
        //    tcMergePackage.Text = "Drilling Rigs Applications";
        //    tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
        //    tcMergePackage.ColumnSpan = 2;
        //    gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

        //}
    }
    protected void grd_alldata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grd_alldata.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8)
                {
                    cellIndex++;
                }
                else
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
            }

            TableCell tcMergePackage1 = new TableCell();
            tcMergePackage1.Text = "Drilling Rigs Applications";
            tcMergePackage1.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage1.ColumnSpan = 3;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage1);

            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Well Applications";
            tcMergePackage.CssClass = "GridviewScrollC1Headerwrap";
            tcMergePackage.ColumnSpan = 4;
            gvHeaderRowCopy.Cells.AddAt(2, tcMergePackage);

          

        }
    }
  
    
    protected void grdDetails_state_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int statewellappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroundwaterAppl"));
            statewellappl = statewellappl1 + statewellappl;
            int staterigsappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DrillingAppl"));
            staterigsappl = staterigsappl1 + staterigsappl;


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=state&Status=WellApplications"+ "&Category=1" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts"; ;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=state&Status=DrillingRigApplications" + "&Category=2" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts"; ;
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[2].Text = statewellappl.ToString();

            HyperLink Totalstatewellappl = new HyperLink();
            Totalstatewellappl.ForeColor = System.Drawing.Color.White;
            Totalstatewellappl.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=state&Status=WellApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts"; ;
            Totalstatewellappl.Text = statewellappl.ToString();
            e.Row.Cells[2].Controls.Add(Totalstatewellappl);

            //e.Row.Cells[3].Text = staterigsappl.ToString();

            HyperLink Totalstaterigsappl = new HyperLink();
            Totalstaterigsappl.ForeColor = System.Drawing.Color.White;
            Totalstaterigsappl.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=state&Status=DrillingRigApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts"; ;
            Totalstaterigsappl.Text = staterigsappl.ToString();
            e.Row.Cells[3].Controls.Add(Totalstaterigsappl);
        }
    }

    protected void grdDetails_district_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID"));
            string DistrictName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName"));

            int districtwellappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroundwaterAppl"));
            districtwellappl = districtwellappl1 + districtwellappl;
            int districtrigsappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DrillingAppl"));
            districtrigsappl = districtrigsappl1 + districtrigsappl;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=District&Status=WellApplications" + "&Category=1" + "&Districtid=" + DistrictID+ "&DistrictName=" + DistrictName;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=District&Status=DrillingRigApplications" + "&Category=2" + "&Districtid=" + DistrictID + "&DistrictName=" + DistrictName;
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[2].Text = districtwellappl.ToString();
            //e.Row.Cells[3].Text = districtrigsappl.ToString();

            HyperLink Totalstatewellappl = new HyperLink();
            Totalstatewellappl.ForeColor = System.Drawing.Color.White;
            Totalstatewellappl.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=District&Status=WellApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalstatewellappl.Text = districtwellappl.ToString();
            e.Row.Cells[2].Controls.Add(Totalstatewellappl);

            HyperLink Totalstaterigsappl = new HyperLink();
            Totalstaterigsappl.ForeColor = System.Drawing.Color.White;
            Totalstaterigsappl.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=District&Status=DrillingRigApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalstaterigsappl.Text = districtrigsappl.ToString();
            e.Row.Cells[3].Controls.Add(Totalstaterigsappl);
        }
    }
  

    protected void grd_groundwaterappltype_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ApplicationTypeID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationTypeID"));
            string ApplicationType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationType"));

            int wellappltype1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroundwaterAppl"));
            wellappltype = wellappltype1 + wellappltype;

            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=WellApplications&Status="+ ApplicationType + "&Category="+ ApplicationTypeID + "&Districtid=ALL" + "&DistrictName=ALL";
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[2].Text = wellappltype.ToString();

            HyperLink Totalstatewellappl = new HyperLink();
            Totalstatewellappl.ForeColor = System.Drawing.Color.White;
            Totalstatewellappl.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=WellApplications&Status=ALL WellApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalstatewellappl.Text = wellappltype.ToString();
            e.Row.Cells[2].Controls.Add(Totalstatewellappl);

        }
    }

    protected void grd_drillingappltype_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ApplicationTypeID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationTypeID"));
            string ApplicationType = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationType"));
            int rigsappltype1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DrillingAppl"));
            rigsappltype = rigsappltype1 + rigsappltype;

            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=DrillingRigApplications&Status="+ ApplicationType + "&Category="+ ApplicationTypeID + "&Districtid=ALL"+ "&DistrictName=ALL";
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[2].Text = rigsappltype.ToString();

            HyperLink Totalstaterigsappl = new HyperLink();
            Totalstaterigsappl.ForeColor = System.Drawing.Color.White;
            Totalstaterigsappl.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=District&Status=ALL DrillingRigApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalstaterigsappl.Text = rigsappltype.ToString();
            e.Row.Cells[2].Controls.Add(Totalstaterigsappl);
        }
    }

    protected void grd_alldata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID"));
            string DIstrictName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DIstrictName"));


            int allwellappl1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GroundwaterAppl"));
            allwellappl = allwellappl1 + allwellappl;

            //int rw_allwellappltype1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Agriculture_IrrigationWater"));
            //allwellappltype1 = rw_allwellappltype1 + allwellappltype1;

            int rw_allwellappltype2 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Agriculture_IrrigationWater"));
            allwellappltype2 = rw_allwellappltype2 + allwellappltype2;

            int rw_allwellappltype3 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Drinking_DomesticWater"));
            allwellappltype3 = rw_allwellappltype3 + allwellappltype3;

            int rw_allwellappltype4 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Institution_Infrastructure_OthersWater"));
            allwellappltype4 = rw_allwellappltype4 + allwellappltype4;

            int rw_allrigappl = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DrillingAppl"));
            allrigappl = rw_allrigappl + allrigappl;

            int rw_allrignew = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Newrigs"));
            allrignew = allrignew + rw_allrignew;

            int rw_allrigrenewal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Renewalrigs"));
            allrigrenewal = rw_allrigrenewal + allrigrenewal;


            HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
            if (h1.Text != "0")
            {
                h1.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=ALL" + "&Districtid="+DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
            if (h2.Text != "0")
            {
                h2.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Agriculture/Irrigation" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
            if (h3.Text != "0")
            {
                h3.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Drinking/Domestic Water" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (h4.Text != "0")
            {
                h4.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Institution/Infrastructure/Others" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
            if (h5.Text != "0")
            {
                h5.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=ALL" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
            if (h6.Text != "0")
            {
                h6.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=New" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }
            HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
            if (h7.Text != "0")
            {
                h7.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=Renewal" + "&Districtid=" + DistrictID + "&DistrictName=" + DIstrictName;
            }




        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[2].Text = allwellappl.ToString();
            ////e.Row.Cells[3].Text = allwellappltype1.ToString();
            //e.Row.Cells[3].Text = allwellappltype2.ToString();
            //e.Row.Cells[4].Text = allwellappltype3.ToString();
            //e.Row.Cells[5].Text = allwellappltype4.ToString();
            //e.Row.Cells[6].Text = allrigappl.ToString();
            //e.Row.Cells[7].Text = allrignew.ToString();
            //e.Row.Cells[8].Text = allrigrenewal.ToString();


            HyperLink Totalallwellappl = new HyperLink();
            Totalallwellappl.ForeColor = System.Drawing.Color.White;
            Totalallwellappl.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallwellappl.Text = allwellappl.ToString();
            e.Row.Cells[2].Controls.Add(Totalallwellappl);

            HyperLink Totalallwellappltype2 = new HyperLink();
            Totalallwellappltype2.ForeColor = System.Drawing.Color.White;
            Totalallwellappltype2.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Agriculture/Irrigation" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallwellappltype2.Text = allwellappltype2.ToString();
            e.Row.Cells[3].Controls.Add(Totalallwellappltype2);

            HyperLink Totalallwellappltype3 = new HyperLink();
            Totalallwellappltype3.ForeColor = System.Drawing.Color.White;
            Totalallwellappltype3.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Drinking/Domestic Water" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallwellappltype3.Text = allwellappltype3.ToString();
            e.Row.Cells[4].Controls.Add(Totalallwellappltype3);

            HyperLink Totalallwellappltype4 = new HyperLink();
            Totalallwellappltype4.ForeColor = System.Drawing.Color.White;
            Totalallwellappltype4.NavigateUrl = "frmlistofwellapplicationdetails.aspx?Type=TotalDistrictApplications&Status=WellApplications" + "&Category=Institution/Infrastructure/Others" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallwellappltype4.Text = allwellappltype4.ToString();
            e.Row.Cells[5].Controls.Add(Totalallwellappltype4);


            HyperLink Totalallrigappl = new HyperLink();
            Totalallrigappl.ForeColor = System.Drawing.Color.White;
            Totalallrigappl.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=ALL" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallrigappl.Text = allrigappl.ToString();
            e.Row.Cells[6].Controls.Add(Totalallrigappl);


            HyperLink Totalallrignew = new HyperLink();
            Totalallrignew.ForeColor = System.Drawing.Color.White;
            Totalallrignew.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=New" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallrignew.Text = allrignew.ToString();
            e.Row.Cells[7].Controls.Add(Totalallrignew);


            HyperLink Totalallrigrenewal = new HyperLink();
            Totalallrigrenewal.ForeColor = System.Drawing.Color.White;
            Totalallrigrenewal.NavigateUrl = "frmlistofDrillingrigdetails.aspx?Type=TotalDistrictApplications&Status=DrillingRigApplications" + "&Category=Renewal" + "&Districtid=ALL" + "&DistrictName=" + "ALLDistricts";
            Totalallrigrenewal.Text = allrigrenewal.ToString();
            e.Row.Cells[8].Controls.Add(Totalallrigrenewal);
        }
    }

    protected void BtnSave2_Click(object sender, EventArgs e)
    {
       // ExportToExcel();

    }

    #region

    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{
    //    ExportToExcel();

    //}
    //public void FromDateFinancialYear()
    //{
    //    //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //    //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //    int valid = 0;
    //    lblmsg0.Text = "";
    //    Failure.Visible = false;
    //    if (rbtnlstInputType.SelectedValue == "N")
    //    {
    //        if (txtFromDate.Text == "" || txtFromDate.Text == null)
    //        {
    //            lblmsg0.Text = "Please Enter From Date <br/>";
    //            valid = 1;
    //        }
    //        if (txtTodate.Text == "" || txtTodate.Text == null)
    //        {
    //            lblmsg0.Text += "Please Enter To Date <br/>";
    //            valid = 1;
    //        }
    //        if (valid == 0)
    //        {
    //            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //        }
    //    }
    //    else
    //    {
    //        if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
    //        {
    //            lblmsg0.Text = "Please Select Financial Year";
    //            valid = 1;
    //        }
    //        else
    //        {
    //            String Dates1 = Convert.ToString(ddlFinancialYear.SelectedValue);
    //            string[] tokens1 = Dates1.Split('-');
    //            string from = tokens1[0];
    //            string todate = tokens1[1];
    //            //FromdateforDB  = Convert.ToDateTime(Convert.ToString(tokens1[0])).ToString("MM/dd/yyyy");
    //            FromdateforDB = Convert.ToString(DateTime.ParseExact(Convert.ToString(tokens1[0]), "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //            DateTime startDate = Convert.ToDateTime(Convert.ToString(tokens1[1]));
    //            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
    //            //TodateforDB  = Convert.ToString(endDate);
    //            TodateforDB = Convert.ToString(DateTime.ParseExact(Convert.ToString(endDate), "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

    //        }

    //    }
    //    if (valid == 0)
    //    {
    //        getdetails(FromdateforDB, TodateforDB, rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), "G");

    //    }
    //    else
    //    {
    //        Failure.Visible = true;
    //    }
    //}
    //protected void btnNewPdf_Click(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
    //    Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK);

    //    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //    {
    //        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

    //        Phrase phrase = null;
    //        PdfPCell cell = null;
    //        PdfPTable table = null;
    //        PdfPTable tablenew = null;
    //        Color color = null;

    //        document.Open();
    //        writer.PageEvent = new Footer();
    //        //Header Table
    //        PdfContentByte contentBytenew = writer.DirectContent;
    //        table = new PdfPTable(3);
    //        table.TotalWidth = document.PageSize.Width - 60f;
    //        table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
    //        table.LockedWidth = true;


    //        cell = ImageCell("~/images/ipasslogopsr.png", 20f, PdfPCell.ALIGN_LEFT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        table.AddCell(cell);


    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("Telangana State Industrial Project Approval &	Self- Certification System (TS-iPASS)\n\n", FontFactory.GetFont("trebuchet ms", 14, Font.BOLD, Color.BLACK)));
    //        phrase.Add(new Chunk("government of telangana".ToUpper(), FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));

    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        // cell.PaddingBottom = 30f;
    //        table.AddCell(cell);

    //        cell = ImageCell("~/images/logoTG.gif", 20f, PdfPCell.ALIGN_RIGHT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_TOP;
    //        table.AddCell(cell);

    //        //------------------------------------------------------------------------------------------------------------------------------------------------------
    //        string strDuration = "";
    //        string monthName = "", monthName1 = "";
    //        string FromdateforDB1 = "", TodateforDB1 = "";
    //        int monthday1 = 0, monthday2 = 0;

    //        strDuration = DisplayWithSuffix(monthday1) + " " + monthName + " " + FromdateforDB1 + " to " + DisplayWithSuffix(monthday2) + " " + monthName1 + " " + TodateforDB1;

    //        string tcMergePackage = "";

    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("COI Dashboard \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //        phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
    //        cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
    //        cell.Colspan = 3;
    //        cell.PaddingTop = 20f;
    //        cell.PaddingBottom = 0f;
    //        table.AddCell(cell);

    //        phrase = new Phrase();
    //        phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
    //        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //        cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //        cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
    //        cell.Colspan = 3;
    //        cell.PaddingTop = 10f;
    //        cell.PaddingBottom = 0f;
    //        table.AddCell(cell);

    //        document.Add(table);

    //        color = new Color(6, 170, 26);
    //        DrawLineMiddleline(writer, 2f, document.Top - 60f, document.PageSize.Width - 2f, document.Top - 60f, color);

    //        int CountColumns = 0;

    //        foreach (DataControlFieldCell cellnew in grdDetails.Rows[0].Cells)
    //        {
    //            if (cellnew.Visible == true)
    //            {
    //                CountColumns += 1;
    //            }
    //        }

    //        tablenew = new PdfPTable(CountColumns);
    //        float[] terms = new float[CountColumns];
    //        for (int runs = 0; runs < CountColumns; runs++)
    //        {
    //            if (runs == 0)
    //            {
    //                terms[runs] = 5f;
    //            }
    //            else if (runs == 1)
    //            {
    //                terms[runs] = 20f;
    //            }
    //            else if (runs == 2)
    //            {
    //                terms[runs] = 5f;
    //            }

    //        }
    //        tablenew.SetWidths(terms);
    //        tablenew.TotalWidth = document.PageSize.Width - 60f;

    //        tablenew.LockedWidth = true;
    //        tablenew.SpacingBefore = 5f;
    //        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;

    //        for (int i = 0; i < CountColumns; i++)
    //        {
    //            string cellText = "";

    //            cellText = Server.HtmlDecode(grdDetails.Columns[i].HeaderText);

    //            phrase = new Phrase();
    //            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //            cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
    //            cell.PaddingBottom = 5;
    //            cell.MinimumHeight = 30f;
    //            tablenew.AddCell(cell);
    //        }

    //        for (int i = 0; i < grdDetails.Rows.Count; i++)
    //        {
    //            if (grdDetails.Rows[i].RowType == DataControlRowType.DataRow)
    //            {
    //                for (int j = 0; j < CountColumns; j++)
    //                {
    //                    string cellText = "";
    //                    HyperLink h4 = null;
    //                    Label l4 = null;
    //                    phrase = new Phrase();

    //                    if (j == 0)
    //                    {
    //                        cellText = Server.HtmlDecode(grdDetails.Rows[i].Cells[j].Text);
    //                    }
    //                    else if (j == 1)
    //                    {
    //                        h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
    //                        cellText = h4.Text;
    //                    }
    //                    else
    //                    {
    //                        if (grdDetails.Rows[i].Cells[j].Controls[0].Visible == true)
    //                        {
    //                            h4 = (HyperLink)grdDetails.Rows[i].Cells[j].Controls[0];
    //                            cellText = h4.Text;
    //                        }
    //                        else
    //                            continue;
    //                    }
    //                    cellText = Server.HtmlDecode(cellText);
    //                    if (j == 0 && (cellText == "A" || cellText == "B" || cellText == "C" || cellText == "D" || cellText == "E" || cellText == "F" || cellText == "G"))

    //                    {

    //                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
    //                    }
    //                    else if (cellText == "PENDENCY BEYOND TIMELIMITS" || cellText == "APPEAL PENDENCY" || cellText == "IMPLEMENTATION STATUS MORE THAN 6 MONTHS OF APPROVAL"
    //                        || cellText == "INCENTIVES" || cellText == "RECIEVED CFO NOT APPLIED FOR INCENTIVES" || cellText == "MONTHLY PERFORMANCE REPORT" || cellText == "MSME CATALOGUE DETAILS UPLOADED")
    //                    {
    //                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
    //                    }
    //                    else
    //                    {
    //                        string cellTextnew1 = Server.HtmlDecode(grdDetails.Rows[i].Cells[1].Text);

    //                        if ((cellTextnew1 == "CFE - Total" || cellTextnew1 == "CFO - Total" || cellTextnew1 == "CFE + CFO TOTAL" || cellTextnew1 == "GRAND TOTAL"))
    //                        {
    //                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.BOLD, Color.BLACK)));
    //                        }
    //                        else
    //                        {
    //                            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.BLACK)));
    //                        }
    //                    }
    //                    if (j == 0)
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_RIGHT;
    //                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //                    }
    //                    else if (j == 1)
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_RIGHT;
    //                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //                        if (cellText == "PENDENCY BEYOND TIMELIMITS" || cellText == "APPEAL PENDENCY" || cellText == "IMPLEMENTATION STATUS MORE THAN 6 MONTHS OF APPROVAL"
    //                        || cellText == "INCENTIVES" || cellText == "RECIEVED CFO NOT APPLIED FOR INCENTIVES" || cellText == "MONTHLY PERFORMANCE REPORT" || cellText == "MSME CATALOGUE DETAILS UPLOADED")
    //                        {
    //                            cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
    //                            cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
    //                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                        }
    //                    }
    //                    else
    //                    {
    //                        cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //                        cell.VerticalAlignment = PdfCell.ALIGN_RIGHT;
    //                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //                    }

    //                    if (grdDetails.Rows[i].RowState == DataControlRowState.Alternate)
    //                    {
    //                        cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#FAFAFA"));
    //                        cell.BorderWidthRight = 0.5f;
    //                        cell.BorderWidthLeft = 0.5f;
    //                        cell.BorderWidthTop = 0.5f;
    //                        cell.BorderWidthBottom = 0.5f;

    //                        cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
    //                        cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                    }
    //                    else
    //                    {
    //                        cell.BorderWidthRight = 0.5f;
    //                        cell.BorderWidthLeft = 0.5f;
    //                        cell.BorderWidthTop = 0.5f;
    //                        cell.BorderWidthBottom = 0.5f;

    //                        cell.BorderColorBottom = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));  //#E5E5E5
    //                        cell.BorderColorTop = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorLeft = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                        cell.BorderColorRight = new Color(System.Drawing.ColorTranslator.FromHtml("#E5E5E5"));
    //                    }

    //                    //cell.BackgroundColor = Color.GRAY;

    //                    cell.PaddingBottom = 5;
    //                    cell.MinimumHeight = 30f;
    //                    tablenew.AddCell(cell);
    //                }
    //            }
    //            var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
    //            var initialPosition = writer.GetVerticalPosition(false);
    //            var tablehiht = tablenew.TotalHeight;

    //            if (remainingPageSpace >= tablehiht && remainingPageSpace - 60 <= tablehiht)
    //            {
    //                contentBytenew.SetColorStroke(color);
    //                contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
    //                contentBytenew.Stroke();

    //                ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

    //                document.Add(tablenew);
    //                document.NewPage();
    //                tablenew.DeleteBodyRows();
    //                phrase = new Phrase();
    //                phrase.Add(new Chunk("COI Dashboard \n\n", FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //                phrase.Add(new Chunk(tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
    //                cell.VerticalAlignment = PdfCell.ALIGN_CENTER;
    //                cell.HorizontalAlignment = PdfCell.ALIGN_CENTER;
    //                cell.Colspan = 3;
    //                cell.PaddingTop = 20f;
    //                cell.PaddingBottom = 0f;
    //                tablenew.AddCell(cell);

    //                phrase = new Phrase();
    //                phrase.Add(new Chunk("Report Generated On :" + DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, Color.BLACK)));
    //                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
    //                cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                cell.HorizontalAlignment = PdfCell.ALIGN_RIGHT;
    //                cell.Colspan = 3;
    //                cell.PaddingTop = 10f;
    //                cell.PaddingBottom = 10f;
    //                tablenew.AddCell(cell);

    //                for (int k = 0; k < CountColumns; k++)
    //                {
    //                    string cellText = "";

    //                    cellText = Server.HtmlDecode(grdDetails.Columns[k].HeaderText);

    //                    phrase = new Phrase();
    //                    phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //                    cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //                    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
    //                    cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
    //                    cell.PaddingBottom = 5;
    //                    cell.MinimumHeight = 30f;
    //                    tablenew.AddCell(cell);
    //                }
    //                //document.Add(table);
    //            }
    //        }
    //        for (int i = 0; i < CountColumns; i++)
    //        {
    //            string cellText = "";

    //            cellText = Server.HtmlDecode(grdDetails.FooterRow.Cells[i].Text);
    //            //cellText = Server.HtmlDecode(grdDetails.Columns[i].FooterText);

    //            phrase = new Phrase();
    //            phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, Color.WHITE)));
    //            cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
    //            cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
    //            cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml("#009688"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
    //            cell.PaddingBottom = 5;
    //            cell.MinimumHeight = 30f;
    //            tablenew.AddCell(cell);
    //        }
    //        document.Add(tablenew);

    //        contentBytenew.SetColorStroke(color);
    //        contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
    //        contentBytenew.Stroke();
    //        ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, Color.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);




    //        document.Close();
    //        byte[] bytes = memoryStream.ToArray();
    //        memoryStream.Close();
    //        Response.Clear();
    //        Response.ContentType = "application/pdf";
    //        Response.AddHeader("Content-Disposition", "attachment; filename=COIDASHBOARD" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
    //        Response.ContentType = "application/pdf";

    //        //Response.Buffer = true;
    //        //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
    //        //Response.Charset = "";
    //        //Response.ContentType = "application/vnd.ms-excel";

    //        Response.Buffer = true;
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.BinaryWrite(bytes);
    //        Response.End();
    //        Response.Close();


    //    }

    //}
    //public partial class Footer : PdfPageEventHelper
    //{
    //    //new Color(127, 127, 127)
    //    public override void OnEndPage(PdfWriter writer, Document doc)
    //    {
    //        Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Industry Chasing Cell.  Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, Color.BLACK));
    //        footer.Alignment = Element.ALIGN_LEFT;
    //        PdfPTable footerTbl = new PdfPTable(1);
    //        footerTbl.TotalWidth = 500f;
    //        footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
    //        PdfPCell cell = new PdfPCell(footer);
    //        cell.Border = 0;
    //        cell.PaddingLeft = 10;
    //        footerTbl.AddCell(cell);
    //        footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
    //    }
    //}
    //private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    //{
    //    PdfContentByte contentByte = writer.DirectContent;
    //    contentByte.SetColorStroke(color);
    //    contentByte.MoveTo(x1, y1);
    //    contentByte.LineTo(x2, y2);
    //    contentByte.SetLineWidth(1f);
    //    contentByte.Stroke();
    //}
    //private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
    //{
    //    PdfContentByte contentByte = writer.DirectContent;
    //    contentByte.SetColorStroke(color);
    //    contentByte.MoveTo(x1, y1);
    //    contentByte.LineTo(x2, y2);
    //    contentByte.SetLineWidth(2f);
    //    contentByte.Stroke();
    //}
    //private static PdfPCell PhraseCell(Phrase phrase, int align)
    //{
    //    PdfPCell cell = new PdfPCell(phrase);
    //    cell.BorderColor = Color.WHITE;
    //    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
    //    cell.HorizontalAlignment = align;
    //    cell.PaddingBottom = 2f;
    //    cell.PaddingTop = 0f;
    //    return cell;
    //}
    //private static PdfPCell PhraseCellnew(Phrase phrase, int align)
    //{
    //    PdfPCell cell = new PdfPCell(phrase);
    //    cell.BorderColor = Color.WHITE;
    //    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //    cell.HorizontalAlignment = align;
    //    //cell.PaddingBottom = 5f;
    //    //cell.PaddingTop = 5f; 
    //    cell.BorderWidthRight = 0.5f;
    //    cell.BorderWidthLeft = 0.5f;
    //    cell.BorderWidthTop = 0.5f;
    //    cell.BorderWidthBottom = 0.5f;
    //    cell.BorderColorBottom = Color.BLACK;
    //    cell.BorderColorTop = Color.BLACK;
    //    cell.BorderColorLeft = Color.BLACK;
    //    cell.BorderColorRight = Color.BLACK;
    //    cell.MinimumHeight = 30f;

    //    return cell;
    //}
    //private static PdfPCell ImageCell(string path, float scale, int align)
    //{
    //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
    //    image.ScalePercent(scale);
    //    PdfPCell cell = new PdfPCell(image);
    //    cell.BorderColor = Color.WHITE;
    //    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
    //    cell.HorizontalAlignment = align;
    //    cell.PaddingBottom = 0f;
    //    cell.PaddingTop = 0f;
    //    return cell;
    //}
    //public string DisplayWithSuffix(int num)
    //{
    //    if (num.ToString().EndsWith("11")) return num.ToString() + "th";
    //    if (num.ToString().EndsWith("12")) return num.ToString() + "th";
    //    if (num.ToString().EndsWith("13")) return num.ToString() + "th";
    //    if (num.ToString().EndsWith("1")) return num.ToString() + "st";
    //    if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
    //    if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
    //    return num.ToString() + "th";
    //}
    //protected void ExportToExcel()
    //{
    //    ExportGridToExcel();

    //}
    //private void ExportGridToExcel()
    //{
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.ClearContent();
    //    Response.ClearHeaders();
    //    Response.Charset = "";
    //    string FileName = "COI Dash Board" + DateTime.Now + ".xls";
    //    StringWriter strwritter = new StringWriter();
    //    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.ContentType = "application/vnd.ms-excel";
    //    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
    //    grdDetails.GridLines = GridLines.Both;
    //    grdDetails.HeaderStyle.Font.Bold = true;
    //    grdDetails.RenderControl(htmltextwrtter);
    //    Response.Write(strwritter.ToString());
    //    Response.End();

    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    //protected void BtnSave1_Click(object sender, EventArgs e)
    //{
    //    int valid = 0;
    //    lblmsg0.Text = "";
    //    Failure.Visible = false;
    //    //string FromdateforDB = "", TodateforDB = "";

    //    if (rbtnlstInputType.SelectedValue == "N")
    //    {
    //        if (txtFromDate.Text == "" || txtFromDate.Text == null)
    //        {
    //            lblmsg0.Text = "Please Enter From Date <br/>";
    //            valid = 1;
    //        }
    //        if (txtTodate.Text == "" || txtTodate.Text == null)
    //        {
    //            lblmsg0.Text += "Please Enter To Date <br/>";
    //            valid = 1;
    //        }
    //        if (valid == 0)
    //        {
    //            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //        }
    //    }
    //    else
    //    {
    //        if (ddlFinancialYear.SelectedItem.ToString() == "--Select--")
    //        {
    //            lblmsg0.Text = "Please Select Financial Year";
    //            valid = 1;
    //        }

    //        FromdateforDB = ViewState["FromdateforDB"].ToString();
    //        TodateforDB = ViewState["TodateforDB"].ToString();
    //    }
    //    if (valid == 0)
    //    {
    //        getdetails(FromdateforDB, TodateforDB, rbtnlstInputType.SelectedValue.ToString().Trim(), ddlFinancialYear.SelectedValue.ToString().Trim(), "G");
    //        //FillGridDetails(FromdateforDB, TodateforDB, ddlProp_intDistrictid.SelectedValue);
    //    }
    //    else
    //    {
    //        Failure.Visible = true;
    //    }
    //}

    #endregion

    #region
    //private void getdetails(string FromdateforDB1, string TodateforDB1, string input, string financial, string Flag)
    //{
    //    DataSet ds = new DataSet();


    //    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    //    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    //    DataSet oDataSet = new DataSet();
    //    osqlConnection.Open();
    //    oSqlDataAdapter = new SqlDataAdapter("USP_GET_COI_DASHBOARD_ALL_NewDrill", osqlConnection);
    //    oSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    oSqlDataAdapter.SelectCommand.Parameters.Add("@FROMDATE", SqlDbType.VarChar).Value = FromdateforDB1.ToString();
    //    oSqlDataAdapter.SelectCommand.Parameters.Add("@TODATE", SqlDbType.VarChar).Value = TodateforDB1.ToString();
    //    oSqlDataAdapter.SelectCommand.Parameters.Add("@InputFlg", SqlDbType.VarChar).Value = input.ToString();
    //    oSqlDataAdapter.SelectCommand.Parameters.Add("@FinancialYearCd", SqlDbType.VarChar).Value = financial.ToString();
    //    oSqlDataAdapter.SelectCommand.Parameters.Add("@Flag", SqlDbType.VarChar).Value = Flag.ToString();
    //    oDataSet = new DataSet();
    //    oSqlDataAdapter.Fill(oDataSet);
    //    grdDetails1.DataSource = oDataSet.Tables[0];
    //    grdDetails1.DataBind();
    //    //GridView1.DataSource = oDataSet.Tables[2];
    //    //GridView1.DataBind();
    //    GridView2.DataSource = oDataSet.Tables[2];
    //    GridView2.DataBind();
    //    grdDetails.DataSource = oDataSet.Tables[3];
    //    grdDetails.DataBind();
    //}  
    //protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string testing1 = e.Row.Cells[2].Text.ToString();

    //    string testing = e.Row.Cells[1].Text.ToString();
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + testing + "');", true);
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

    //        string testing2 = h1.Text.ToString();
    //        if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "REPORT SUBMITTED" || testing2 == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || testing2 == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "RECIEVED CFO ELIGIBLE FOR INCENTIVES" || testing2 == "RECIEVED CFO NOT ELIGIBLE FOR INCENTIVES")
    //        {
    //            //h1.ForeColor = "red";

    //            h1.Font.Bold = false;
    //            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "GENERAL QUERY PENDENCY" || testing2 == "COMMENCED OPERATIONS" || testing2 == "RECIEVED CFO ELIGIBLE FOR INCENTIVES" || testing2 == "RECIEVED CFO NOT ELIGIBLE FOR INCENTIVES")
    //            {
    //                h2.Style.Add("color", "#ff4615");
    //            }
    //            h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        else if (testing2 == "GRIEVANCES" || testing2 == "GRIEVANCES" || testing2 == "QUERY" || testing2 == "-CFE" || testing2 == "-CFO")
    //        {
    //            h1.Font.Bold = false;
    //            HyperLink h12 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "-CFE" || testing2 == "-CFO" || testing2 == "QUERY")
    //            {
    //                h12.Style.Add("color", "#ff4615");
    //            }
    //            h12.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        else if (testing2 == "PENDENCY BEYOND TIMELIMITS" || testing2 == "APPEAL PENDENCY" || testing2 == "IMPLEMENTATION STATUS MORE THAN 6 MONTHS OF APPROVAL"
    //                        || testing2 == "INCENTIVES" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES" || testing2 == "MONTHLY PERFORMANCE REPORT" || testing2 == "MSME CATALOGUE DETAILS UPLOADED")
    //        {
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
    //        }
    //        //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    }


    //    #region "comm"
    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{

    //    //    if (testing == "CFE PENDENCY BEYOND" || testing == "CFO PENDENCY BEYOND" || testing == "RAW MATERIALS PENDENCY" || testing == "RENEWALS PENDENCY" || testing == "INCENTIVE GM ASSIGN PENDENCY" || testing == "INCENTIVE GM RECOMMEND PENDENCY")
    //    //    {
    //    //        HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //    //        h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    //    }
    //    //    else
    //    //    {

    //    //        HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
    //    //        h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    //    }

    //    //}
    //    #endregion
    //}
    //protected void grdDetails_PreRender(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow grdrow in grdDetails.Rows)
    //    {
    //        //HyperLink statusLabel = (HyperLink)grdrow.Cells[0].FindControl("statusLabel");
    //        HyperLink statusLabel = (HyperLink)grdrow.Cells[1].Controls[0];
    //        if (statusLabel.Text == "PENDENCY BEYOND TIMELIMITS" || statusLabel.Text == "APPEAL PENDENCY" || statusLabel.Text == "INCENTIVE" || statusLabel.Text == "MONTHLY PERFORMANCE REPORT" || statusLabel.Text == "MSME CATALOGUE DETAILS UPLOADED" || statusLabel.Text == "STATUS OF IMPLEMENTATION BEYOND 6 MONTHS ABOVE" || statusLabel.Text == "RECIEVED CFO NOT APPLIED FOR INCENTIVES")//|| statusLabel.Text == "PENDENCY "
    //        {
    //            grdrow.Font.Bold = true;
    //            grdrow.Font.Underline = false;
    //            grdrow.HorizontalAlign = HorizontalAlign.Center;
    //        }
    //        else
    //        {
    //            grdrow.Font.Bold = false;
    //            grdrow.Font.Underline = false;
    //        }
    //    }
    //}  
    //protected void grdDetails1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string testing1 = e.Row.Cells[2].Text.ToString();

    //    string testing = e.Row.Cells[1].Text.ToString();
    //    //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //    //TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

    //        string testing2 = h1.Text.ToString();
    //        if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "REPORT SUBMITTED" || testing2 == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || testing2 == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "COMMENCED OPERATIONS")
    //        {
    //            //h1.ForeColor = "red";

    //            h1.Font.Bold = false;
    //            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "QUERY" || testing2 == "COMMENCED OPERATIONS")
    //            {
    //                h2.Style.Add("color", "#ff4615");
    //                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //            }
    //            h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        else if (testing2 == "GRIEVANCES" || testing2 == "GRIEVANCES" || testing2 == "QUERY" || testing2 == "-CFE" || testing2 == "-CFO" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES")
    //        {
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

    //            h1.Font.Bold = false;
    //            HyperLink h12 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "-CFE" || testing2 == "-CFO" || testing2 == "QUERY")
    //            {
    //                h12.Style.Add("color", "#ff4615");
    //            }
    //            h12.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //        if (testing2 == "PENDENCY BEYOND TIMELIMITS" || testing2 == "APPEAL PENDENCY" || testing2 == "IMPLEMENTATION STATUS MORE THAN 6 MONTHS OF APPROVAL"
    //                       || testing2 == "INCENTIVES" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES" || testing2 == "MONTHLY PERFORMANCE REPORT" || testing2 == "MSME CATALOGUE DETAILS UPLOADED")
    //        {
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
    //        }

    //    }


    //    #region "comm"

    //    #endregion

    //}
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string testing1 = e.Row.Cells[2].Text.ToString();

    //    string testing = e.Row.Cells[1].Text.ToString();
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + testing + "');", true);
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

    //        string testing2 = h1.Text.ToString();
    //        if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "REPORT SUBMITTED" || testing2 == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || testing2 == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "COMMENCED OPERATIONS")
    //        {
    //            //h1.ForeColor = "red";

    //            h1.Font.Bold = false;
    //            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "QUERY" || testing2 == "COMMENCED OPERATIONS")
    //            {
    //                h2.Style.Add("color", "#ff4615");
    //            }
    //            h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        else if (testing2 == "GRIEVANCES" || testing2 == "GRIEVANCES" || testing2 == "QUERY" || testing2 == "-CFE" || testing2 == "-CFO" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES")
    //        {
    //            h1.Font.Bold = false;
    //            HyperLink h12 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "-CFE" || testing2 == "-CFO" || testing2 == "QUERY")
    //            {
    //                h12.Style.Add("color", "#ff4615");
    //            }
    //            h12.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    }



    //}
    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string testing1 = e.Row.Cells[2].Text.ToString();

    //    string testing = e.Row.Cells[1].Text.ToString();
    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + testing + "');", true);
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];

    //        string testing2 = h1.Text.ToString();
    //        if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "REPORT SUBMITTED" || testing2 == "REPORT NOT SUBMITTED BUT SALARY PROCESSED" || testing2 == "REPORT SUBMITTED BUT SALARY NOT YET PROCESSED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "RECIEVED CFO ELIGIBLE FOR INCENTIVES" || testing2 == "RECIEVED CFO NOT ELIGIBLE FOR INCENTIVES")
    //        {
    //            //h1.ForeColor = "red";
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //            h1.Font.Bold = false;
    //            HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "CFE" || testing2 == "CFO" || testing2 == "RAW MATERIALS" || testing2 == "RENEWALS" || testing2 == "NOT YET ASSIGNED BY GM" || testing2 == "INCENTIVE GM RECOMMEND PENDENCY" || testing2 == "INSPECTION DATE NOT YET ASSIGNED" || testing2 == "INSPECTION REPORT NOT UPLOADED" || testing2 == "QUERY NOT RESPONDED BEYOND 30 DAYS BY APPLICANT" || testing2 == "REPORT NOT SUBMITTED" || testing2 == "INITIAL STAGE" || testing2 == "Yet to Start Construction" || testing2 == "ADVANCED STAGE" || testing2 == "QUERY" || testing2 == "COMMENCED OPERATIONS" || testing2 == "RECIEVED CFO ELIGIBLE FOR INCENTIVES" || testing2 == "RECIEVED CFO NOT ELIGIBLE FOR INCENTIVES")
    //            {
    //                h2.Style.Add("color", "#ff4615");
    //            }
    //            h2.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        else if (testing2 == "GRIEVANCES" || testing2 == "GRIEVANCES" || testing2 == "QUERY" || testing2 == "-CFE" || testing2 == "-CFE" || testing2 == "RECIEVED CFO NOT APPLIED FOR INCENTIVES")
    //        {
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //            h1.Font.Bold = false;
    //            HyperLink h12 = (HyperLink)e.Row.Cells[2].Controls[0];
    //            if (testing2 == "-CFE" || testing2 == " -CFO" || testing2 == "QUERY")
    //            {
    //                h12.Style.Add("color", "#ff4615");
    //            }
    //            h12.NavigateUrl = "comRepDrill_dist.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim() + "&fromdate=" + FromdateforDB + "&todate=" + TodateforDB;
    //        }
    //        if (testing2 == "INCENTIVES" || testing2.Contains("RECIEVED CFO NOT APPLIED FOR INCENTIVES") || testing2.Contains("MONTHLY PERFORMANCE REPORT") || testing2.Contains("MSME CATALOGUE DETAILS"))
    //        {
    //            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
    //        }
    //        //h1.NavigateUrl = "comReportDrill_drilldown.aspx?CODE=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Type")).Trim();
    //    }




    //}

    #endregion













}