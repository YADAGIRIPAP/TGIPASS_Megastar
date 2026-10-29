//By Srikanth on 13-05-2013
// For: Abstract for All Zone
// Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS
///Storedprocedure Name : Queries also used.

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


public partial class FrmUsers : System.Web.UI.Page
{
    HtmlTableRow tRow;
    HtmlTableCell tcell1;
    DataSet ds = new DataSet();

    int cnt = 0;    
    string Dept = "";
    DB.DB con1 = new DB.DB();
    General tran1 = new General();
    General csRegComplaint = new General();
    int pendingafter, pendingbefore, closedafter, closedbefore, total, Reject, QueryRaised, QueryRaiseda, Pending, Pendinga, Approved, Approveda;
    int pendingaftera, pendingbeforea, closedaftera, closedbeforea, totala,Rejecta;
    int BankReportTarget1, BankReportCompleted1, BankReportPending1, BankVisitTarget1, BankVisitCompleted1,
                      BankVisitPending1, VehicleInspectionTarget1, VehicleInspectionCompleted1, VehicleInspectionPending1, TSiPASSTarget1, TSiPASSCompleted1, TSiPASSPending1, PMEGPTarget1, PMEGPCompleted1,
                      PMEGPPending1, AdvanceSubsidyTarget1, AdvanceSubsidyCompleted1, AdvanceSubsidyPending1, ClosedUnitTarget1, ClosedUnitCompleted1, ClosedUnitPending1, IndustryCatelogTarget1,
                      IndustryCatelogCompleted1, IndustryCatelogPending1;

    int BankReportTarget12, BankReportCompleted12, BankReportPending12, BankVisitTarget12, BankVisitCompleted12,
                    BankVisitPending12, VehicleInspectionTarget12, VehicleInspectionCompleted12, VehicleInspectionPending12, TSiPASSTarget12, TSiPASSCompleted12, TSiPASSPending12, PMEGPTarget12, PMEGPCompleted12,
                    PMEGPPending12, AdvanceSubsidyTarget12, AdvanceSubsidyCompleted12, AdvanceSubsidyPending12, ClosedUnitTarget12, ClosedUnitCompleted12, ClosedUnitPending12, IndustryCatelogTarget12,
                    IndustryCatelogCompleted12, IndustryCatelogPending12;

    string zone = "%";
    protected void Page_Load(object sender, EventArgs e)
    {
      // this.txtFrom.Attributes.Add("onfocus", "popUpCalendarLeft(this,document.getElementById('ctl00_ContentPlaceHolder1_txtFrom'), 'dd-mmm-yyyy')");
       // this.txtTo.Attributes.Add("onfocus", "popUpCalendarLeft(this,document.getElementById('ctl00_ContentPlaceHolder1_txtTo'), 'dd-mmm-yyyy')");
        
      
        if (Session.Count == 0)
            Response.Redirect("../../Index.aspx");
        else
        {
            if (!Page.IsPostBack)
            {
                // Modified by Srikanth on 13-05-2013


               
                if (!IsPostBack)
                {
                    int year = DateTime.Now.Year - 5;

                    for (int Y = year; Y <= DateTime.Now.Year; Y++)
                    {

                        ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
                    }

                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                    ddlMonth.SelectedIndex = DateTime.Now.Month;
                 

                    //ds = Gen.DistrictWiseReport();


                    // grdDetails.DataSource = ds.Tables[0];
                    //grdDetails.DataBind();
                }
              
                THeader();
                FillGrid();
                tbl1.Width = "1000";
               TTotal("Sr");
                TTotal("Gr");
            }
           
        }
    }
  

    public void FillGrid()
    {
        DataSet vehicleDS = new DataSet();
        vehicleDS = tran1.GetIPOPeriodicalAbstract(ddlYear.SelectedValue,ddlMonth.SelectedValue);
        GridView1.DataSource = vehicleDS;
        GridView1.DataBind();
    }
       
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TChildHead( Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Name")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportTarget")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportCompleted")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportPending")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitTarget")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitCompleted")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitPending")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionTarget")), Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionCompleted")),

                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionPending")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSTarget")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSCompleted")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSPending")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPTarget")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPCompleted")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPPending")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyTarget")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyCompleted")),


                 Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyPending")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitTarget")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitCompleted")),

                 Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitPending")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogTarget")),
                Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogCompleted")),
                 Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogPending")) );



            int BankReportTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportTarget")));
            BankReportTarget1 = BankReportTarget3 + BankReportTarget1;
            BankReportTarget12 = BankReportTarget3 + BankReportTarget12;



            int BankReportPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportPending")));
            BankReportPending1 = BankReportPending3 + BankReportPending1;
            BankReportPending12 = BankReportPending3 + BankReportPending12;


            int BankReportCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankReportCompleted")));
            BankReportCompleted1 = BankReportCompleted3 + BankReportCompleted1;
            BankReportCompleted12 = BankReportCompleted3 + BankReportCompleted12;



            int BankVisitTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitTarget")));
            BankVisitTarget1 = BankVisitTarget3 + BankVisitTarget1;
            BankVisitTarget12 = BankVisitTarget3 + BankVisitTarget12;



            int BankVisitCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitCompleted")));
            BankVisitCompleted1 = BankVisitCompleted3 + BankVisitCompleted1;
            BankVisitCompleted12 = BankVisitCompleted3 + BankVisitCompleted12;


            int BankVisitPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BankVisitPending")));
            BankVisitPending1 = BankVisitPending3 + BankVisitPending1;
            BankVisitPending12 = BankVisitPending3 + BankVisitPending12;




            int VehicleInspectionTarget = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionTarget")));
            VehicleInspectionTarget1 = VehicleInspectionTarget + VehicleInspectionTarget1;
            VehicleInspectionTarget12 = VehicleInspectionTarget + VehicleInspectionTarget12;



            int VehicleInspectionPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionPending")));
            VehicleInspectionPending1 = VehicleInspectionPending3 + VehicleInspectionPending1;
            VehicleInspectionPending12 = VehicleInspectionPending3 + VehicleInspectionPending12;


            int VehicleInspectionCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "VehicleInspectionCompleted")));
            VehicleInspectionCompleted1 = VehicleInspectionCompleted3 + VehicleInspectionCompleted1;
            VehicleInspectionCompleted12 = VehicleInspectionCompleted3 + VehicleInspectionCompleted12;


            int TSiPASSTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSTarget")));
            TSiPASSTarget1 = TSiPASSTarget3 + TSiPASSTarget1;
            TSiPASSTarget12 = TSiPASSTarget3 + TSiPASSTarget12;



            int TSiPASSPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSPending")));
            TSiPASSPending1 = TSiPASSPending3 + TSiPASSPending1;
            TSiPASSPending12 = TSiPASSPending3 + TSiPASSPending12;


            int TSiPASSCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TSiPASSCompleted")));
            TSiPASSCompleted1 = TSiPASSCompleted3 + TSiPASSCompleted1;
            TSiPASSCompleted12 = TSiPASSCompleted3 + TSiPASSCompleted12;


            int PMEGPTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPTarget")));
            PMEGPTarget1 = PMEGPTarget3 + PMEGPTarget1;
            PMEGPTarget12 = PMEGPTarget3 + PMEGPTarget12;



            int PMEGPPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPPending")));
            PMEGPPending1 = PMEGPPending3 + PMEGPPending1;
            PMEGPPending12 = PMEGPPending3 + PMEGPPending12;


            int PMEGPCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PMEGPCompleted")));
            PMEGPCompleted1 = PMEGPCompleted3 + PMEGPCompleted1;
            PMEGPCompleted12 = PMEGPCompleted3 + PMEGPCompleted12;


            int AdvanceSubsidyTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyTarget")));
            AdvanceSubsidyTarget1 = AdvanceSubsidyTarget3 + AdvanceSubsidyTarget1;
            AdvanceSubsidyTarget12 = AdvanceSubsidyTarget3 + AdvanceSubsidyTarget12;



            int AdvanceSubsidyPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyPending")));
            AdvanceSubsidyPending1 = AdvanceSubsidyPending3 + AdvanceSubsidyPending1;
            AdvanceSubsidyPending12 = AdvanceSubsidyPending3 + AdvanceSubsidyPending12;


            int AdvanceSubsidyCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "AdvanceSubsidyCompleted")));
            AdvanceSubsidyCompleted1 = AdvanceSubsidyCompleted3 + AdvanceSubsidyCompleted1;
            AdvanceSubsidyCompleted12 = AdvanceSubsidyCompleted3 + AdvanceSubsidyCompleted12;

            int ClosedUnitTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitTarget")));
            ClosedUnitTarget1 = ClosedUnitTarget3 + ClosedUnitTarget1;
            ClosedUnitTarget12 = ClosedUnitTarget3 + ClosedUnitTarget12;



            int ClosedUnitPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitPending")));
            ClosedUnitPending1 = ClosedUnitPending3 + ClosedUnitPending1;
            ClosedUnitPending12 = ClosedUnitPending3 + ClosedUnitPending12;


            int ClosedUnitCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ClosedUnitCompleted")));
            ClosedUnitCompleted1 = ClosedUnitCompleted3 + ClosedUnitCompleted1;
            ClosedUnitCompleted12 = ClosedUnitCompleted3 + ClosedUnitCompleted12;

            int IndustryCatelogTarget3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogTarget")));
            IndustryCatelogTarget1 = IndustryCatelogTarget3 + IndustryCatelogTarget1;
            IndustryCatelogTarget12 = IndustryCatelogTarget3 + IndustryCatelogTarget12;



            int IndustryCatelogPending3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogPending")));
            IndustryCatelogPending1 = IndustryCatelogPending3 + IndustryCatelogPending1;
            IndustryCatelogPending12 = IndustryCatelogPending3 + IndustryCatelogPending12;


            int IndustryCatelogCompleted3 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IndustryCatelogCompleted")));
            IndustryCatelogCompleted1 = IndustryCatelogCompleted3 + IndustryCatelogCompleted1;
            IndustryCatelogCompleted12 = IndustryCatelogCompleted3 + IndustryCatelogCompleted12;

            ////////int total1 = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsApplied")));
            ////////total = total1 + total;
            ////////totala = total1 + totala;

            ////////int pendingafter1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending More than 3 Days"));
            ////////pendingafter = pendingafter1 + pendingafter;
            ////////pendingaftera = pendingafter1 + pendingaftera;

            ////////int pendingbefore1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Pending Less than 3 Days"));
            ////////pendingbefore = pendingbefore1 + pendingbefore;
            ////////pendingbeforea = pendingbefore1 + pendingbeforea;

            ////////int closedafter1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedBeyondDays"));
            ////////closedafter = closedafter1 + closedafter;
            ////////closedaftera = closedafter1 + closedaftera;

            ////////int closedbefore1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedWithinDays"));
            ////////closedbefore = closedbefore1 + closedbefore;
            ////////closedbeforea = closedbefore1 + closedbeforea;

            ////////int Reject1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Rejected"));
            ////////Reject = Reject1 + Reject;
            ////////Rejecta = Reject1 + Rejecta;

            ////////int QueryRaised1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryRaised"));
            ////////QueryRaised = QueryRaised1 + QueryRaised;
            ////////QueryRaiseda = QueryRaised1 + QueryRaiseda;


            ////////int Pending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Completed"));
            ////////Pending = Pending1 + Pending;
            ////////Pendinga = Pending1 + Pendinga;

            ////////int Approved1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Approved"));
            ////////Approved = Approved1 + Approved;
            ////////Approveda = Approved1 + Approveda;
           
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //e.Row.Cells[1].Text = "Total: ";
            //e.Row.Cells[2].Text = total.ToString().Trim();
            //e.Row.Cells[3].Text = closedbefore.ToString().Trim();
            //e.Row.Cells[4].Text = closedafter.ToString().Trim();
            //e.Row.Cells[5].Text = pendingbefore.ToString().Trim();
            //e.Row.Cells[6].Text = pendingafter.ToString().Trim();
            //e.Row.Cells[7].Text = Pending.ToString().Trim();
            //e.Row.Cells[8].Text = QueryRaised.ToString().Trim();
            //e.Row.Cells[9].Text = Reject.ToString().Trim();

            //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
            //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;

            e.Row.Font.Bold = true;
           
        }
    }

    
    #region Create Dynamic Table

    public void THeader()
    {

        #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>S.No.</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;
        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "5px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Name of IPO</b></font>";
        tcell1.Align = "Left";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;
        tcell1.Width = "300px";
        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "3px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Status</b></font>";
        tcell1.Align = "Left";
        tcell1.ColSpan = 1;
        tcell1.RowSpan = 2;


        
        tRow.Cells.Add(tcell1);
        tRow.Style.Add("Padding", "3px");
        tRow.Style.Add("Align", "center");
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Bank Visits</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Bank Loan</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Vehicle Inspection</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
      
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>TSiPASS</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>PMEGP & Mudra</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);

     

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Advance Subsidy</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Closed Units</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Industrial Catalogue</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 3;
        tRow.Cells.Add(tcell1);

        tRow.BgColor = "#337AB7";
        tRow.BorderColor = "#337AB7";
        tbl1.Rows.Add(tRow);

        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);



        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Target</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Pending</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<font color=white><b>Completed</b></font>";
        tcell1.Align = "Center";
        tcell1.ColSpan = 1;
        tRow.Cells.Add(tcell1);


        tRow.BgColor = "#337AB7";
        tRow.BorderColor = "#337AB7";
        
        tbl1.Rows.Add(tRow);
        
        #endregion

    }

    public void TChildHead(string DistrictName,string Dept_Name,string intUserid,string  BankReportTarget,string  BankReportCompleted,string  BankReportPending,string  BankVisitTarget,string  BankVisitCompleted,string  
                      BankVisitPending,string  VehicleInspectionTarget,string  VehicleInspectionCompleted,string  VehicleInspectionPending,string  TSiPASSTarget,string  TSiPASSCompleted,string  TSiPASSPending,string  PMEGPTarget,string  PMEGPCompleted,string  
                      PMEGPPending,string  AdvanceSubsidyTarget,string  AdvanceSubsidyCompleted,string  AdvanceSubsidyPending,string  ClosedUnitTarget,string  ClosedUnitCompleted,string  ClosedUnitPending,string  IndustryCatelogTarget,string  
                      IndustryCatelogCompleted,string  IndustryCatelogPending)
    {
        cnt = cnt + 1;
        if (Dept.Trim() != DistrictName.Trim())
        {
           

            if (cnt > 1)
                TTotal("Sr");

            BankReportTarget1 = 0; BankReportCompleted1 = 0; BankReportPending1 = 0; BankVisitTarget1 = 0; BankVisitCompleted1 = 0;
            BankVisitPending1 = 0; VehicleInspectionTarget1 = 0; VehicleInspectionCompleted1 = 0; VehicleInspectionPending1 = 0; TSiPASSTarget1 = 0; TSiPASSCompleted1 = 0; TSiPASSPending1 = 0; PMEGPTarget1 = 0; PMEGPCompleted1 = 0;
            PMEGPPending1 = 0; AdvanceSubsidyTarget1 = 0; AdvanceSubsidyCompleted1 = 0; AdvanceSubsidyPending1 = 0; ClosedUnitTarget1 = 0; ClosedUnitCompleted1 = 0; ClosedUnitPending1 = 0; IndustryCatelogTarget1 = 0;
            IndustryCatelogCompleted1 = 0; IndustryCatelogPending1 = 0;
            
            Dept = DistrictName.Trim();
            tRow = new HtmlTableRow();
            tcell1 = new HtmlTableCell();
            tcell1.InnerHtml = "<b>" + DistrictName.ToUpper().Trim() + "</b>";
            tcell1.Align = "Center";
            tcell1.ColSpan = 27;
            tRow.Cells.Add(tcell1);
            tRow.BgColor = "#E6EDF7";
            tbl1.Rows.Add(tRow);





           


        }

        



        int cnta = 0;
        if (BankReportPending == "0" && BankReportTarget!="0")
        {
            cnta = cnta + 1;
        }
        if (BankVisitPending == "0" && BankVisitTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (VehicleInspectionPending == "0" && VehicleInspectionTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (TSiPASSPending == "0" && TSiPASSTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (PMEGPPending == "0" && PMEGPTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (AdvanceSubsidyPending == "0" && AdvanceSubsidyTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (ClosedUnitPending == "0" && ClosedUnitTarget != "0")
        {
            cnta = cnta + 1;
        }
        if (IndustryCatelogPending == "0" && IndustryCatelogTarget != "0")
        {
            cnta = cnta + 1;
        }

        string st = cnta.ToString() + " of 8";
        // tRow = new HtmlTableRow();
        #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        tcell1.InnerText = cnt.ToString().Trim();
        tcell1.Align = "Center";
        tcell1.Width = "50";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPOPMSDashboardDrildown.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "'> " + Dept_Name.Trim().ToUpper() + "</a>";
           // Dept_Name.Trim().ToUpper();
        tcell1.Align = "Left";
        tcell1.Width = "300px";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = st.Trim();
        tcell1.Align = "Right";
        //CommissionerIPODashboardDrildown.aspx

        tRow.Cells.Add(tcell1);        
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = BankReportTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = BankReportPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1000'> " + BankReportCompleted.Trim().ToUpper() + "</a>";
        //tcell1.InnerHtml = BankReportCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = BankVisitTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = BankVisitPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1001'> " + BankVisitCompleted.Trim().ToUpper() + "</a>";
        //tcell1.InnerHtml = BankVisitCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);



        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = VehicleInspectionTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = VehicleInspectionPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1002'> " + VehicleInspectionCompleted.Trim().ToUpper() + "</a>";

        //tcell1.InnerHtml = VehicleInspectionCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = TSiPASSTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1003&status=Pending'> " + TSiPASSPending.Trim().ToUpper() + "</a>";

       // tcell1.InnerHtml = TSiPASSPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1003&status=Completed'> " + TSiPASSCompleted.Trim().ToUpper() + "</a>";

        //tcell1.InnerHtml = TSiPASSCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = PMEGPTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = PMEGPPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();

        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1004'> " + PMEGPCompleted.Trim().ToUpper() + "</a>";

        //tcell1.InnerHtml = PMEGPCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = AdvanceSubsidyTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1005&status=Pending'> " + AdvanceSubsidyPending.Trim().ToUpper() + "</a>";
        //tcell1.InnerHtml = AdvanceSubsidyPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1005&status=Completed'> " + AdvanceSubsidyCompleted.Trim().ToUpper() + "</a>";
       // tcell1.InnerHtml = AdvanceSubsidyCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = ClosedUnitTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = ClosedUnitPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1006'> " + ClosedUnitCompleted.Trim().ToUpper() + "</a>";

        //tcell1.InnerHtml = ClosedUnitCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = IndustryCatelogTarget.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = IndustryCatelogPending.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);
        tcell1 = new HtmlTableCell();
        tcell1.InnerHtml = "<a target='_blank' href='IPODrilRedirect.aspx?Id=" + intUserid.Trim() + "&Year=" + ddlYear.SelectedValue.ToString() + "&Month=" + ddlMonth.SelectedIndex.ToString() + "&form=1007'> " + IndustryCatelogCompleted.Trim().ToUpper() + "</a>";

        //tcell1.InnerHtml = IndustryCatelogCompleted.Trim();
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tbl1.Rows.Add(tRow);
        

        #endregion
       
    }

    public void TTotal(string totStatus)
    {
        //tRow = new HtmlTableRow();
        

         #region First Copy
        tRow = new HtmlTableRow();
        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b> Grand Total </b></font>";
        else
            tcell1.InnerHtml = "<b> Sub Total </b>";
        tcell1.ColSpan = 3;
        tcell1.Align = "Center";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankReportTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankReportTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankReportPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankReportPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankReportCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankReportCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankVisitTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankVisitTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankVisitPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankVisitPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + BankVisitCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + BankVisitCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + VehicleInspectionTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + VehicleInspectionTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + VehicleInspectionPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + VehicleInspectionPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + VehicleInspectionCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + VehicleInspectionCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + TSiPASSTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + TSiPASSTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + TSiPASSPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + TSiPASSPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + TSiPASSCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + TSiPASSCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + PMEGPTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + PMEGPTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + PMEGPPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + PMEGPPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + PMEGPCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + PMEGPCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + AdvanceSubsidyTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + AdvanceSubsidyTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + AdvanceSubsidyPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + AdvanceSubsidyPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + AdvanceSubsidyCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + AdvanceSubsidyCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + ClosedUnitTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + ClosedUnitTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + ClosedUnitPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + ClosedUnitPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + ClosedUnitCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + ClosedUnitCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + IndustryCatelogTarget12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + IndustryCatelogTarget1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + IndustryCatelogPending12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + IndustryCatelogPending1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);

        tcell1 = new HtmlTableCell();
        if (totStatus.Trim() == "Gr")
            tcell1.InnerHtml = "<font color=white><b>" + IndustryCatelogCompleted12.ToString().Trim() + "</b></font>";
        else
            tcell1.InnerHtml = "<b>" + IndustryCatelogCompleted1.ToString().Trim() + "</b>";
        tcell1.Align = "Right";
        tRow.Cells.Add(tcell1);


        if (totStatus.Trim() == "Gr")
            tRow.BgColor = "#337AB7";
        else
            tRow.BgColor = "#337AB7";
        tbl1.Rows.Add(tRow);
        #endregion


        if (total <= 0)
        {
            //tbl1.Visible = false;
          //  LblStatus.Text = " No Records Found ";
        }
    }    

    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Modified by Srikanth on 13-05-2013
        // Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS
        //if (Session["Dept_Code"].ToString().Trim() == "20")
        //{
        //    if (ddlZone.SelectedIndex == 0)
        //    {
        //        zone = "%";
        //    }
        //    else
        //    {
        //        zone = ddlZone.SelectedValue;
        //    }
        //}
        //else
        //{
        //    ddlZone.SelectedValue = ddlZone.Items.FindByValue(Session["Zone"].ToString().Trim()).Value;
        //    ddlZone.Enabled = false;
        //    zone = ddlZone.SelectedValue.ToString().Trim();
        //}
        // Modified by Srikanth on 13-05-2013
        // Tables Used: COMPLAINT_MASTER,COMPLAINT_TRANS,DEPT,SERVICE,LOCALITY,SERVICE_USERS,USERS
      
        THeader();
        FillGrid();
        tbl1.Width = "750";
     //  TTotal("Sr");
        TTotal("Gr");
    }



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        THeader();
        FillGrid();
        tbl1.Width = "750";
        
       // TTotal("Sr");
        TTotal("Gr");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        Response.Redirect("IPOPeriodcialAbstract.aspx");
    }
}
