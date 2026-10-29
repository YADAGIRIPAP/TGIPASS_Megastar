using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using InfoSoftGlobal;

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;
    decimal NoofapplicationsApplied1, prescrutinywithin1, prescrutinybeyond1, queryrisedwith1, queryrisedbeyond1, pendingless1, pendingmore1, approvedwithin1, approvedbeyond1;
    decimal underprocesswithin1, underprocessbeyond1, rejectedwith1, rejectedbeyond1, noofpayment1;


    //Added by Rushi 
   // DataTable dt = new DataTable("Chart");
    string GraphWidth = "900";
    string GraphHeight = "500";
    string[] color = new string[12]; 
    //end
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
           // Response.Redirect("~/Index.aspx");
        }
        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {

            //FillDetails();
            //Failure.Visible = false;
            //success.Visible = false;
            //BtnSave1.Text = "Update";
            ////lblresult.Text = "";
            ////Btnsave.Enabled = true;
            //hdfFlagID.Value = "";
        }

        if (!IsPostBack)

        {
            //    ddlMonth.SelectedIndex = System.DateTime.Now.Month;
            //    ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
            //    ddlMonth.Enabled = false;
            //    ddlYear.Enabled = false;

            DataSet ds = new DataSet();
            ds = Gen.getApproval();
            ddlcategory.DataSource = ds.Tables[0];
            ddlcategory.DataValueField = "ApprovalId";
            ddlcategory.DataTextField = "ApprovalName";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, "--Select--");
            //    DataSet dsm = new DataSet();
            //    dsm = Gen.GetDistricts();
            //if (dsm.Tables[0].Rows.Count > 0)
            //{
            //    ddlcategory.DataSource = dsm.Tables[0];
            //    ddlcategory.DataValueField = "District_Id";
            //    ddlcategory.DataTextField = "District_Name";
            //    ddlcategory.DataBind();
            //    ddlcategory.Items.Insert(0, "--District--");
            //}
            //else
            //{
            //    ddldistrict.Items.Clear();
            //    ddldistrict.Items.Insert(0, "--District--");
            //}

            fillgrid();
            
        }
    }

    
  


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        
        
    }
    
    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //clear();

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
    


    

    protected void GetNewRectoInsertdr1()
    {
        //myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        //DataView dvdr1 = new DataView(myDtNewRecdr1);
        ////dvdr1.RowFilter = "new = 0";
        //myDtNewRecdr1 = dvdr1.ToTable();

    }

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //}
    }

    
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        
        //ddldistrict.SelectedIndex = 0;
        ddlcategory.SelectedIndex = 0;
        gvCertificate0.DataSource = null;
        gvCertificate0.DataBind();
        success.Visible = false;
        Failure.Visible = false;
    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void TxtNameofUnit_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        
        fillgrid();
        // txtUidno0.Text = "";
        //ddldistrict.SelectedIndex = 0;
        //ddlcategory.SelectedIndex = 0;
    }
    void fillgrid()
    {


        DataSet ds = new DataSet();

        ds = Gen.searchAaprovalname(ddlcategory.SelectedValue.ToString());
        string value = "%";
        if (ddlcategory.SelectedValue.ToString() != "--Select--")
        {
            value = ddlcategory.SelectedValue.ToString();
        }
       // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "fusionchart.callFunction('" + value + "')", true);


       // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "fusionchart.LoadTempdata()", true);
        
        if (ds.Tables[0].Rows.Count > 0)
        {

            string categories = "<categories>";
            string applications = "<dataset seriesName='No of Applications Submitted' color='#8BBA00'>";
            string appovalssubmitted = "<dataset seriesName='No of Applications Approved' color='#FF8E46'>";
            string prescuitiny = "<dataset seriesName='No of Applications Prescuitiny Completed' color='#FF5733'>"; string approved = "<dataset seriesName='No of Applications Approved' color='#FEB8A9'>"; string queryraised = "<dataset seriesName='No of Query Raised' color='#CD8E81'>"; string rejected = "<dataset seriesName='No of Applications Rejected' color='#F92F04'>";
            int i = 0;
            string xmlData = @"<graph caption='Search Approvals'  formatNumberScale='1' rotateValues='1' placeValuesInside='1' decimalPrecision='0' >";

            foreach (DataTable table in ds.Tables)
            {

                foreach (DataRow DR in table.Rows)
                {
                    //Append <category name='...' /> to strCategories
                    categories += "<category name='" + DR["MonthNames"].ToString() + "' />";

                    //Add <set value='...' /> to both the datasets
                    applications += "<set value='" + DR["Number of Applications submitted"].ToString() + "'  />";
                    appovalssubmitted += "<set value='" + DR["Number of approvals submitted"].ToString() + "' />";
                    prescuitiny += "<set value='" + DR["Pre-ScrutinyCompleted"].ToString() + "' />";
                    queryraised += "<set value='" + DR["Number of approvals - query raised"].ToString() + "' />";
                    approved += "<set value='" + DR["Number of approvals approved"].ToString() + "' />";
                    rejected += "<set value='" + DR["Number of approvals rejected"].ToString() + "' />";
                    i++;
                }
            }
            
            categories += "</categories>";
            applications += "</dataset>";
            appovalssubmitted += "</dataset>";
            prescuitiny += "</dataset>";
            queryraised += "</dataset>";
            approved += "</dataset>";
            rejected += "</dataset>";
            xmlData += categories + applications + appovalssubmitted + prescuitiny + queryraised + approved + rejected + "</graph>";

            //Create the chart - MS Column 3D Chart with data contained in xmlData
            //  return FusionCharts.RenderChart("../../FusionCharts/MSColumn3D.swf", "", xmlData, "productSales", "600", "300", false, false);

            FCLiteral1.Text = FusionCharts.RenderChartHTML(
                "../../Resource/FusionCharts/FCF_MSColumn3D.swf", // Path to chart's SWF
                "",                              // Leave blank when using Data String method
                xmlData,                          // xmlStr contains the chart data
                "productSales",                      // Unique chart ID
                GraphWidth, GraphHeight,                   // Width & Height of chart
                false
                );

            gvCertificate0.DataSource = ds.Tables[0];
            gvCertificate0.DataBind();
            //lblmsg.Text = "";
            ////success.Visible = true;
            //Failure.Visible = false;



            

        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg0.Text = "No Records found.";
            gvCertificate0.DataSource = null;
            gvCertificate0.DataBind();
        }
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
            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 2;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Number of Submitted";
            
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 1;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "";
            
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            HeaderCell = new TableCell();
            HeaderCell.ColumnSpan = 3;
            HeaderCell.RowSpan = 0;
            HeaderCell.Font.Bold = true;
            HeaderCell.Text = "Number of approvals ";
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //HeaderCell = new TableCell();
            //HeaderCell.ColumnSpan = 2;
            //HeaderCell.RowSpan = 0;
            //HeaderCell.Font.Bold = true;
            //HeaderCell.Text = "Approved ";
            //HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //HeaderCell = new TableCell();
            //HeaderCell.ColumnSpan = 2;
            //HeaderCell.RowSpan = 0;
            //HeaderCell.Font.Bold = true;
            //HeaderCell.Text = "Under Process";
            //HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //HeaderCell = new TableCell();
            //HeaderCell.ColumnSpan = 2;
            //HeaderCell.RowSpan = 0;
            //HeaderCell.Font.Bold = true;
            //HeaderCell.Text = "Rejected";
            //HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //HeaderCell = new TableCell();
            //HeaderCell.ColumnSpan = 1;
            //HeaderCell.RowSpan = 0;
            //HeaderCell.Font.Bold = true;
            //HeaderCell.Text = "";
            
            //HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //gvCertificate0.Controls[0].Controls.AddAt(0, HeaderGridRow);
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal ApplicationsReceived = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of Applications submitted"));
            NoofapplicationsApplied1 = ApplicationsReceived + NoofapplicationsApplied1;

            decimal prescrutinywithin = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of approvals submitted"));
            prescrutinywithin1 = prescrutinywithin + prescrutinywithin1;

            decimal prescrutinybeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pre-ScrutinyCompleted"));
            prescrutinybeyond1 = prescrutinybeyond + prescrutinybeyond1;

            decimal queryrisedwith = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of approvals - query raised"));
            queryrisedwith1 = queryrisedwith + queryrisedwith1;

            decimal queryrisedbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of approvals approved"));
            queryrisedbeyond1 = queryrisedbeyond + queryrisedbeyond1;

            decimal pendingless = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of approvals rejected"));
            pendingless1 = pendingless + pendingless1;

            //decimal pendingmore = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"));
            //pendingmore1 = pendingmore + pendingmore1;


            //decimal approvedwithin = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved with in days"));
            //approvedwithin1 = approvedwithin + approvedwithin1;

            //decimal approvedbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Approved Beyond days"));
            //approvedbeyond1 = approvedbeyond + approvedbeyond1;

            //decimal underprocesswithin = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Under Process Within Days"));
            //underprocesswithin1 = underprocesswithin + underprocesswithin1;

            //decimal underprocessbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Under Process Beyond Days"));
            //underprocessbeyond1 = underprocessbeyond + underprocessbeyond1;

            //decimal rejectedwith = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected With in Days"));
            //rejectedwith1 = rejectedwith + rejectedwith1;

            //decimal rejectedbeyond = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Rejected Beyond Days"));
            //rejectedbeyond1 = rejectedbeyond + rejectedbeyond1;

            //decimal noofpayment = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Number of payment received for"));
            //noofpayment1 = noofpayment + noofpayment1;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[2].Text = NoofapplicationsApplied1.ToString();
            e.Row.Cells[3].Text = prescrutinywithin1.ToString();
            e.Row.Cells[4].Text = prescrutinybeyond1.ToString();
            e.Row.Cells[5].Text = queryrisedwith1.ToString();
            e.Row.Cells[6].Text = queryrisedbeyond1.ToString();

            e.Row.Cells[7].Text = pendingless1.ToString();
            //e.Row.Cells[8].Text = pendingmore1.ToString();
            //e.Row.Cells[9].Text = approvedwithin1.ToString();
            //e.Row.Cells[10].Text = approvedbeyond1.ToString();
            //e.Row.Cells[11].Text = underprocesswithin1.ToString();
            //e.Row.Cells[12].Text = underprocessbeyond1.ToString();
            //e.Row.Cells[13].Text = rejectedwith1.ToString();
            //e.Row.Cells[14].Text = rejectedbeyond1.ToString();
            //e.Row.Cells[15].Text = noofpayment1.ToString();
        }
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else if (gr.RowType == DataControlRowType.Footer)
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;

                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnCenter";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //Adde by Rushi
    
    //end
}

