#region Imports
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
using System.Resources;
//using CFST_BLOnline;
using System.Drawing;
using System.Data.SqlClient;
using System.IO;


#endregion

public partial class UI_TSiPASS_frmCalenderReportCOI : System.Web.UI.Page
{
    #region Member Variables
    //CommonBS commonBS = new CommonBS();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    General Gen = new General();
    int monthNum;
    int yearNum;
    int todaysMonth;
    int todaysYear;
    int lastDate;
    int numbDays;
    int firstDay;
    DateTime firstDate;
    static DateTime today;
    string[] wordMonth;
    int thisDate;
    int todaysDay;
    int todaysDate;
    int cnt;
    //DateTime IssueDt;

    string ClassId = string.Empty;
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        //tblSlots.Visible = false;
        //btnSubmit.Enabled = false;

        if (!Page.IsPostBack)
        {

            BindDistricts();

            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid.Enabled = false;
            }
            else
            {
                if (Session["DistrictIDSel"] != null && Session["DistrictIDSel"].ToString().Trim() != "")
                {
                    ddlProp_intDistrictid.SelectedValue = Session["DistrictIDSel"].ToString().Trim();

                }
                else
                {
                    // ddlProp_intDistrictid.SelectedIndex = 0;
                }
            }
        }
        int year = DateTime.Now.Year - 7, count = 1;
        DropDownList1.Items.Insert(0, new ListItem("---select---"));

        for (int i = year; i < year + 7; i++)
        {
            DropDownList1.Items.Insert(count, new ListItem("April " + i.ToString() + " - " + "March " + (i + 1).ToString()));
            count++;
        }

        SetValues();
        CreateHeading();
        CreateCalendar();

        //}


        //btnSubmit.Attributes.Add("onclick", "document.getElementById('btnSubmit.ClientID').disabled=true;");
    }


    protected void lbtnHome_Click(object sender, EventArgs e)
    {
        Session["LLRData"] = null;
        Response.Redirect("Home.aspx");
    }
    protected void lbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("OnlineLearnerLicence.aspx");
    }


    #endregion

    #region Methods
    //protected void PopulateApplicantData()
    //{
    //    onlineLLAppVO = (OnlineLearnerLicenceAppVO)Session["LLRData"];
    //    txtFirstName.Text = onlineLLAppVO.FirstName;
    //    txtLastName.Text = onlineLLAppVO.LastName;
    //    txtDOB.Text = onlineLLAppVO.DateOfBirth;
    //    txtFatherHusbandname.Text = onlineLLAppVO.FatherHusbandName;
    //    lblTestCntr.Text = onlineLLAppVO.OfficeDesc;
    //    lblJurisOffice.Text = onlineLLAppVO.OfficeDesc;
    //}

    protected void PopulateOffices(int Dist_Cd)
    {
        //ddlTestCenter.Items.Clear();
        //onlineLicenseAppBS = new OnlineLicenseAppBS();
        //DataSet dsOfffice = new DataSet();
        //dsOfffice = onlineLicenseAppBS.GetOfficeByDist(Dist_Cd);
        //if (dsOfffice.Tables.Count > 0)
        //{
        //    if (dsOfffice.Tables[0].Rows.Count > 0)
        //    {
        //        ddlTestCenter.DataSource = dsOfffice;
        //        ddlTestCenter.DataValueField = "OFFICE_CD";
        //        ddlTestCenter.DataTextField = "VC_OFM_Office_Description";
        //        ddlTestCenter.DataBind();
        //    }
        //}
        //AddSelect(ref ddlTestCenter);
    }



    protected void SetValues()
    {
        tbCalendar.BorderWidth = 1;
        tbCalendar.BorderColor = Color.Black;
        thisDate = 1;							                // Tracks current date being written in calendar
        wordMonth = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        //wordMonth = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };

        if (Request.QueryString.Count > 0)
        {
            today = new DateTime(Convert.ToInt32(Request.QueryString["year"].ToString()), Convert.ToInt32(Request.QueryString["month"].ToString()), 1);
        }
        else
        {
            if (DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) == DateTime.Today.Day)
            {
                today = DateTime.Today.AddDays(1);
            }
            else
            {
                today = DateTime.Today.Date;
            }
        }
        //today = DateTime.Today.Date;		                // Date object to store the current date
        todaysDay = int.Parse(today.DayOfWeek.ToString("d"));			                // Stores the current day number 1-7
        todaysDate = today.Date.Day;			                // Stores the current numeric date within the month
        todaysMonth = today.Month;				                // Stores the current month 1-12
        todaysYear = today.Year;				                // Stores the current year
        monthNum = todaysMonth;					                // Tracks the current month being displayed
        yearNum = todaysYear;					                // Tracks the current year being displayed
        firstDate = new DateTime(yearNum, monthNum, 1);	// Object Storing the first day of the current month
        firstDay = int.Parse(firstDate.DayOfWeek.ToString("d"));			                // Tracks the day number 1-7 of the first day of the current month
        lastDate = DateTime.DaysInMonth(yearNum, monthNum);
        numbDays = 0;
        numbDays = lastDate;

    }

    public void CreateHeading()
    {
        TableRow trButtons = new TableRow();
        trButtons.HorizontalAlign = HorizontalAlign.Center;
        trButtons.VerticalAlign = VerticalAlign.Middle;

        TableCell tcPreYear = new TableCell();
        TableCell tcPreMon = new TableCell();
        TableCell tcCurrentMonth = new TableCell();
        TableCell tcNextMon = new TableCell();
        TableCell tcNextYear = new TableCell();

        //if (monthNum != DateTime.Today.Month)
        //{
        LinkButton lbtnPreviousMonth = new LinkButton();
        lbtnPreviousMonth.Text = "PreviousMonth";
        lbtnPreviousMonth.Font.Bold = true;
        lbtnPreviousMonth.Click += new EventHandler(lbtnPreviousMonth_Click);
        tcPreMon.Controls.Add(lbtnPreviousMonth);
        trButtons.Cells.Add(tcPreMon);
        //}
        tcCurrentMonth.Font.Name = "calibri";
        tcCurrentMonth.Font.Size = 10;
        tcCurrentMonth.Font.Bold = true;
        tcCurrentMonth.Text = "&nbsp;&nbsp;" + wordMonth[monthNum - 1] + "&nbsp;&nbsp;" + yearNum + "&nbsp;&nbsp;";
        trButtons.Cells.Add(tcCurrentMonth);

        //if (monthNum != 12)
        //{
        LinkButton lbtnNextMonth = new LinkButton();
        lbtnNextMonth.Text = "NextMonth";
        lbtnNextMonth.Font.Bold = true;
        lbtnNextMonth.Click += new EventHandler(lbtnNextMonth_Click);
        tcNextMon.Controls.Add(lbtnNextMonth);
        trButtons.Cells.Add(tcNextMon);
        //}

        tblHeading.Rows.Add(trButtons);
    }

    public void CreateCalendar()
    {
        try
        {


            DataSet ds = new DataSet();

            //Getting holiday list
            ds = Gen.GetHolidayList();

            cnt = ds.Tables[0].Rows.Count;
            string[] CalSave = new string[cnt];
            if (cnt > 0)
            {
                int flow = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    CalSave[flow] = dr[0].ToString();
                    flow++;
                }
            }

            int daycounter = 0;

            tbCalendar.BackColor = Color.FromName("#FEFCFA");

            TableRow trDays = new TableRow();
            TableCell tcS = new TableCell();
            TableCell tcM = new TableCell();
            TableCell tcT = new TableCell();
            TableCell tcW = new TableCell();
            TableCell tcTh = new TableCell();
            TableCell tcF = new TableCell();
            TableCell tcSa = new TableCell();


            tcS.Text = "Sun";
            tcM.Text = "Mon";
            tcT.Text = "Tue";
            tcW.Text = "Wed";
            tcTh.Text = "Thu";
            tcF.Text = "Fri";
            tcSa.Text = "Sat";

            tcS.HorizontalAlign = HorizontalAlign.Center;
            tcM.HorizontalAlign = HorizontalAlign.Center;
            tcT.HorizontalAlign = HorizontalAlign.Center;
            tcW.HorizontalAlign = HorizontalAlign.Center;
            tcTh.HorizontalAlign = HorizontalAlign.Center;
            tcF.HorizontalAlign = HorizontalAlign.Center;
            tcSa.HorizontalAlign = HorizontalAlign.Center;

            tcS.Font.Size = 15;
            //tcS.Font.Bold = true;
            tcS.ForeColor = Color.Red;
            tcS.BackColor = Color.FromName("#D5CEC6");
            tcS.Font.Name = "calibri";
            tcM.Font.Size = 15;
            //tcM.Font.Bold = true;
            tcM.BackColor = Color.FromName("#D5CEC6");
            tcM.Font.Name = "calibri";
            tcT.Font.Size = 15;
            //tcT.Font.Bold = true;
            tcT.BackColor = Color.FromName("#D5CEC6");
            tcT.Font.Name = "calibri";
            tcW.Font.Size = 15;
            //tcW.Font.Bold = true;
            tcW.BackColor = Color.FromName("#D5CEC6");
            tcW.Font.Name = "calibri";
            tcTh.Font.Size = 15;
            //tcTh.Font.Bold = true;
            tcTh.BackColor = Color.FromName("#D5CEC6");
            tcTh.Font.Name = "calibri";
            tcF.Font.Size = 15;
            //tcF.Font.Bold = true;
            tcF.BackColor = Color.FromName("#D5CEC6");
            tcF.Font.Name = "calibri";
            tcSa.Font.Size = 15;
            //tcSa.Font.Bold = true;
            tcSa.BackColor = Color.FromName("#D5CEC6");
            tcSa.Font.Name = "calibri";

            tcS.Width = 500;
            tcS.Height = 50;
            tcM.Width = 500;
            tcM.Height = 50;
            tcT.Width = 500;
            tcT.Height = 50;
            tcW.Width = 500;
            tcW.Height = 50;
            tcTh.Width = 500;
            tcTh.Height = 50;
            tcF.Width = 500;
            tcF.Height = 50;
            tcSa.Width = 500;
            tcSa.Height = 50;


            trDays.Cells.Add(tcS);
            trDays.Cells.Add(tcM);
            trDays.Cells.Add(tcT);
            trDays.Cells.Add(tcW);
            trDays.Cells.Add(tcTh);
            trDays.Cells.Add(tcF);
            trDays.Cells.Add(tcSa);

            tbCalendar.Rows.Add(trDays);

            thisDate = 0;
            Color DateColor = new Color();

            for (int i = 1; i <= 6; i++)
            {
                TableRow tr1 = new TableRow();
                tr1.BorderColor = Color.FromName("#B7AB9E");
                tr1.BorderWidth = 1;
                for (int x = 1; x <= 7; x++)
                {
                    daycounter = (thisDate - firstDay) + 1;
                    thisDate++;
                    if ((daycounter > numbDays) || (daycounter < 1))
                    {
                        TableCell tc = new TableCell();
                        tc.Text = "<br>";
                        tc.BackColor = Color.FromName("#F7FBFF");
                        tc.BorderWidth = 1;
                        tc.BorderColor = Color.FromName("#B7AB9E");
                        tc.VerticalAlign = VerticalAlign.Top;
                        //tc.HorizontalAlign = HorizontalAlign.Center;
                        tc.Font.Name = "calibri";
                        tc.Font.Size = 9;
                        tc.Height = 50;
                        tc.Width = 50;
                        tr1.Cells.Add(tc);
                    }
                    else
                    {
                        //string query = "";
                        DateTime NowDate = new DateTime(yearNum, monthNum, daycounter);

                        int Check = 0;
                        string strHoliday = string.Empty;
                        bool DateEnable = true;

                        for (int n = 0; n < cnt; n++)
                        {
                            if (CalSave[n] == NowDate.ToString())
                            {
                                Check = 1;
                                DateColor = Color.Brown;
                                strHoliday = "Public Holiday";
                                DateEnable = false;
                                break;
                            }
                        }

                        //if (NowDate > DateTime.Now.Date)
                        //{
                        if (i == 2 && x == 7)
                        {
                            Check = 1;
                            strHoliday = "Second Saturday";
                            DateEnable = false;
                            DateColor = Color.Red;
                        }
                        if (x == 1)
                        {
                            Check = 1;
                            DateEnable = false;
                            strHoliday = "Sunday";
                            DateColor = Color.Brown;
                        }
                        //if (Check == 1)
                        //{
                        //    DataSet dsHE = new DataSet();
                        //    dsHE = commonBS.GetHolidayExemption(NowDate.ToString(), ddlTestCenter.SelectedValue, "LL", "ONLINE");
                        //    if (dsHE != null && dsHE.Tables.Count > 0 && dsHE.Tables[0].Rows.Count > 0)
                        //    {
                        //        Check = 0;
                        //    }
                        //}
                        if (Check == 0)
                        {
                            string DateSlot = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                            DataSet dsStatus = GetDayWiseStatus(ddlProp_intDistrictid.SelectedValue.ToString(), DateSlot);

                            if (CheckDateSlot(NowDate.Month.ToString() + "/" + NowDate.Day.ToString() + "/" + NowDate.Year.ToString()))
                            {
                                TableCell tcb = new TableCell();
                                tcb.BorderColor = Color.FromName("#B7AB9E");
                                tcb.BorderWidth = 1;
                                tcb.BackColor = Color.FromName("#F7FBFF");
                                LinkButton lbl = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                lbl.ID = DateSlot;
                                lbl.Font.Name = "calibri";
                                lbl.Text = daycounter.ToString() + "<br>";
                                lbl.Font.Size = 10;
                                lbl.Width = 120;
                                lbl.Font.Bold = true;
                                lbl.ForeColor = Color.Black;
                                lbl.Click += new EventHandler(lbl_Click);
                                tcb.BorderWidth = 1;
                                tcb.VerticalAlign = VerticalAlign.Top;
                                lbl.Attributes.Add("style", "text-align:right !important;");

                                //tcb.HorizontalAlign = HorizontalAlign.Right;
                                tcb.BorderColor = Color.FromName("#B7AB9E");
                                tcb.Controls.Add(lbl);
                                tcb.Width = 50;
                                tcb.Height = 80;
                                if (NowDate == DateTime.Now.Date)
                                {
                                    tcb.BackColor = Color.FromName("#FFFF99");
                                }
                                tr1.Cells.Add(tcb);
                                

                                if (NowDate <= DateTime.Now.Date)
                                {
                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //cfe
                                    Label cfe = new Label();
                                    LinkButton lblcfe = new LinkButton();
                                    LinkButton lblcfe1 = new LinkButton();
                                    LinkButton lblcfered = new LinkButton();
                                    LinkButton lblcfeblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    cfe.Font.Name = "calibri";
                                    cfe.Text = "CFE";
                                    cfe.Font.Size = 10;
                                    cfe.Width = 95;
                                    cfe.Font.Bold = true;
                                    cfe.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    cfe.Attributes.Add("style", "text-align:left !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(cfe);

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P";
                                    lblcfe.Font.Name = "calibri";
                                    lblcfe.Text = ":";
                                    lblcfe.Font.Size = 10;
                                    lblcfe.Width = 10;
                                    lblcfe.Font.Bold = true;
                                    lblcfe.ForeColor = Color.Black;
                                    //  lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblcfe.Attributes.Add("style", "text-align:center !important;");

                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblcfe);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblcfered.Text = dsStatus.Tables[0].Rows[0]["CFEPENDING"].ToString().Trim();
                                    lblcfeblack.Text = "/" + dsStatus.Tables[0].Rows[0]["CFETOTAL"].ToString().Trim();
                                    lblcfered.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P";
                                    lblcfeblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T";
                                    lblcfe1.Font.Name = "calibri";
                                    //lblcfe1.Text = dsStatus.Tables[0].Rows[0]["CFEPENDING"].ToString().Trim() + "/" + dsStatus.Tables[0].Rows[0]["CFETOTAL"].ToString().Trim() + "<br>";
                                    lblcfe1.Text = lblcfered.Text + lblcfeblack.Text + "<br>";//  "/"
                                    lblcfe1.Font.Size = 10;
                                    lblcfered.Font.Size = 10;
                                    lblcfeblack.Font.Size = 10;
                                    lblcfe1.Width = 40;
                                    lblcfered.Attributes.Add("style", "width:auto");
                                    lblcfeblack.Attributes.Add("style", "width:auto");
                                    lblcfe1.Font.Bold = true;
                                    lblcfered.Font.Bold = true;
                                    lblcfeblack.Font.Bold = true;
                                    lblcfered.ForeColor = Color.Red;
                                    lblcfeblack.ForeColor = Color.Black;
                                    //lblcfe1.ForeColor = Color.Black;
                                    lblcfered.Click += new EventHandler(lbl_Clickcfe);
                                    lblcfeblack.Click += new EventHandler(lbl_Clickcfe1);
                                    //lblcfe1.Click += new EventHandler(lbl_Clickcfe1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblcfe1.Attributes.Add("style", "text-align:right !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblcfered);
                                    tcb.Controls.Add(lblcfeblack);
                                    // tcb.Controls.Add(lblcfe1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);

                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //cfo
                                    Label cfo = new Label();
                                    LinkButton lblcfo = new LinkButton();
                                    LinkButton lblcfo1 = new LinkButton();
                                    LinkButton lblcfored = new LinkButton();
                                    LinkButton lblcfoblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    cfo.Font.Name = "calibri";
                                    cfo.Text = "CFO";
                                    cfo.Font.Size = 10;
                                    cfo.Width = 95;
                                    cfo.Font.Bold = true;
                                    cfo.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    cfo.Attributes.Add("style", "text-align:left !important;");

                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(cfo);


                                    // lblcfo.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "CFO";
                                    lblcfo.Font.Name = "calibri";
                                    lblcfo.Text = ":";
                                    lblcfo.Font.Size = 10;
                                    lblcfo.Width = 10;
                                    lblcfo.Font.Bold = true;
                                    lblcfo.ForeColor = Color.Black;
                                    // lblcfo.Click += new EventHandler(lbl_Clickcfo);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblcfo.Attributes.Add("style", "text-align:center !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblcfo);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblcfored.Text = dsStatus.Tables[0].Rows[0]["CFOPENDING"].ToString().Trim();
                                    lblcfoblack.Text = "/" + dsStatus.Tables[0].Rows[0]["CFOTOTAL"].ToString().Trim();
                                    lblcfored.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "CFO";
                                    lblcfoblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "CFO";
                                    lblcfo1.Font.Name = "calibri";
                                    lblcfo1.Text = lblcfored.Text + lblcfoblack.Text + "<br>";
                                    lblcfo1.Font.Size = 10;
                                    lblcfored.Font.Size = 10;
                                    lblcfoblack.Font.Size = 10;
                                    lblcfored.Attributes.Add("style", "width:auto");
                                    lblcfoblack.Attributes.Add("style", "width:auto");
                                    lblcfo1.Width = 40;
                                    lblcfo1.Font.Bold = true;
                                    lblcfored.Font.Bold = true;
                                    lblcfoblack.Font.Bold = true;
                                    lblcfored.ForeColor = Color.Red;
                                    lblcfoblack.ForeColor = Color.Black;
                                    //lblcfo1.ForeColor = Color.Black;
                                    lblcfored.Click += new EventHandler(lbl_Clickcfo);
                                    lblcfoblack.Click += new EventHandler(lbl_Clickcfo1);
                                    //lblcfo1.Click += new EventHandler(lbl_Clickcfo1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblcfo1.Attributes.Add("style", "text-align:right !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblcfored);
                                    tcb.Controls.Add(lblcfoblack);
                                    // tcb.Controls.Add(lblcfo1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);


                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //ren
                                    Label ren = new Label();
                                    LinkButton lblren = new LinkButton();
                                    LinkButton lblren1 = new LinkButton();
                                    LinkButton lblrenred = new LinkButton();
                                    LinkButton lblrenblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    ren.Font.Name = "calibri";
                                    ren.Text = "REN";
                                    ren.Font.Size = 10;
                                    ren.Width = 95;
                                    ren.Font.Bold = true;
                                    ren.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    ren.Attributes.Add("style", "text-align:left !important;");

                                    //  tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(ren);

                                    //  lblren.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "REN";
                                    lblren.Font.Name = "calibri";
                                    lblren.Text = ":";
                                    lblren.Font.Size = 10;
                                    lblren.Width = 10;
                                    lblren.Font.Bold = true;
                                    lblren.ForeColor = Color.Black;
                                    // lblren.Click += new EventHandler(lbl_Clickren);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblren.Attributes.Add("style", "text-align:center !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblren);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblrenred.Text = dsStatus.Tables[0].Rows[0]["RENEWALPENDING"].ToString().Trim();
                                    lblrenblack.Text = "/" + dsStatus.Tables[0].Rows[0]["RENEWALTOAL"].ToString().Trim();
                                    lblrenred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "REN";
                                    lblrenblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "REN";
                                    lblren1.Font.Name = "calibri";
                                    lblren1.Text = lblrenred.Text + lblrenblack.Text + "<br>";
                                    lblren1.Font.Size = 10;
                                    lblren1.Width = 40;
                                    lblrenred.Font.Size = 10;
                                    lblrenblack.Font.Size = 10;
                                    lblrenred.Attributes.Add("style", "width:auto");
                                    lblrenblack.Attributes.Add("style", "width:auto");
                                    lblren1.Font.Bold = true;
                                    lblrenblack.Font.Bold = true;
                                    lblrenred.Font.Bold = true;
                                    lblrenred.ForeColor = Color.Red;
                                    lblrenblack.ForeColor = Color.Black;
                                    //lblren1.ForeColor = Color.Black;
                                    lblrenred.Click += new EventHandler(lbl_Clickren);
                                    lblrenblack.Click += new EventHandler(lbl_Clickren1);
                                    //lblren1.Click += new EventHandler(lbl_Clickren1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblren1.Attributes.Add("style", "text-align:right !important;");

                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblrenred);
                                    tcb.Controls.Add(lblrenblack);
                                    //tcb.Controls.Add(lblren1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);

                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //Incentives Manufacturer
                                    Label incentivemanu = new Label();
                                    LinkButton lblincentivemanu = new LinkButton();
                                    LinkButton lblincentivemanu1 = new LinkButton();
                                    LinkButton lblincenred = new LinkButton();
                                    LinkButton lblincenblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    incentivemanu.Font.Name = "calibri";
                                    incentivemanu.Text = "Incentives (Mfg)";
                                    incentivemanu.Font.Size = 10;
                                    incentivemanu.Width = 95;
                                    incentivemanu.Font.Bold = true;
                                    incentivemanu.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    incentivemanu.Attributes.Add("style", "text-align:left !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(incentivemanu);

                                    // lblincentivemanu.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INC";
                                    lblincentivemanu.Font.Name = "calibri";
                                    lblincentivemanu.Text = ":";
                                    lblincentivemanu.Font.Size = 10;
                                    lblincentivemanu.Width = 10;
                                    lblincentivemanu.Font.Bold = true;
                                    lblincentivemanu.ForeColor = Color.Black;
                                    // lblincentivemanu.Click += new EventHandler(lbl_Clickincentivemanu);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblincentivemanu.Attributes.Add("style", "text-align:center !important;");

                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincentivemanu);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblincenred.Text = dsStatus.Tables[0].Rows[0]["INCENTIVESMANUFACTUREPENDING"].ToString().Trim();
                                    lblincenblack.Text = "/" + dsStatus.Tables[0].Rows[0]["INCENTIVESMANUFACTURETOTAL"].ToString().Trim();
                                    lblincenred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INC";

                                    lblincenblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INC";
                                    lblincentivemanu1.Font.Name = "calibri";
                                    lblincentivemanu1.Text = lblincenred.Text + lblincenblack.Text + "<br>";
                                    lblincentivemanu1.Font.Size = 10;
                                    lblincentivemanu1.Width = 40;
                                    lblincenred.Font.Size = 10;
                                    lblincenblack.Font.Size = 10;
                                    lblincenred.Attributes.Add("style", "width:auto");
                                    lblincenblack.Attributes.Add("style", "width:auto");
                                    lblincenred.Font.Bold = true;
                                    lblincenblack.Font.Bold = true;
                                    lblincenred.ForeColor = Color.Red;
                                    lblincenblack.ForeColor = Color.Black;
                                    lblincentivemanu1.Font.Bold = true;
                                    //lblincentivemanu1.ForeColor = Color.Black;
                                    lblincenred.Click += new EventHandler(lbl_Clickincentivemanu);
                                    lblincenblack.Click += new EventHandler(lbl_Clickincentivemanu1);
                                    //lblincentivemanu1.Click += new EventHandler(lbl_Clickincentivemanu1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    lblincentivemanu1.Attributes.Add("style", "text-align:right !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincenred);
                                    tcb.Controls.Add(lblincenblack);
                                    // tcb.Controls.Add(lblincentivemanu1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);

                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //Incentives Service
                                    Label incentiveservice = new Label();
                                    LinkButton lblincentiveservice = new LinkButton();
                                    LinkButton lblincentiveservice1 = new LinkButton();
                                    LinkButton lblincensred = new LinkButton();
                                    LinkButton lblincensblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    incentiveservice.Font.Name = "calibri";
                                    incentiveservice.Text = "Incentives (Serv)";
                                    incentiveservice.Font.Size = 10;
                                    incentiveservice.Width = 95;
                                    incentiveservice.Font.Bold = true;
                                    incentiveservice.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    incentiveservice.Attributes.Add("style", "text-align:left !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(incentiveservice);

                                    //lblincentiveservice.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INCS";
                                    lblincentiveservice.Font.Name = "calibri";
                                    lblincentiveservice.Text = ":";
                                    lblincentiveservice.Font.Size = 10;
                                    lblincentiveservice.Width = 10;
                                    lblincentiveservice.Font.Bold = true;
                                    lblincentiveservice.ForeColor = Color.Black;
                                    //  lblincentiveservice.Click += new EventHandler(lbl_Clickincentiveservice);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    lblincentiveservice.Attributes.Add("style", "text-align:center !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincentiveservice);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblincensred.Text = dsStatus.Tables[0].Rows[0]["INCENTIVESERVICEPENDING"].ToString().Trim();
                                    lblincensblack.Text = "/" + dsStatus.Tables[0].Rows[0]["INCENTIVESERVICETOTAL"].ToString().Trim();
                                    lblincensred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INCS";
                                    lblincensblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INCS";
                                    lblincentiveservice1.Font.Name = "calibri";
                                    lblincentiveservice1.Text = lblincensred.Text + lblincensblack.Text + "<br>";
                                    lblincentiveservice1.Font.Size = 10;
                                    lblincentiveservice1.Width = 40;
                                    lblincentiveservice1.Font.Bold = true;
                                    lblincensred.Font.Size = 10;
                                    lblincensblack.Font.Size = 10;
                                    lblincensred.Attributes.Add("style", "width:auto");
                                    lblincensblack.Attributes.Add("style", "width:auto");
                                    lblincensred.Font.Bold = true;
                                    lblincensblack.Font.Bold = true;
                                    lblincensred.ForeColor = Color.Red;
                                    lblincensblack.ForeColor = Color.Black;
                                    lblincentiveservice1.ForeColor = Color.Black;
                                    lblincensred.Click += new EventHandler(lbl_Clickincentiveservice);
                                    lblincensblack.Click += new EventHandler(lbl_Clickincentiveservice1);
                                    // lblincentiveservice1.Click += new EventHandler(lbl_Clickincentiveservice1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    lblincentiveservice1.Attributes.Add("style", "text-align:right !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincensred);
                                    tcb.Controls.Add(lblincensblack);
                                    //tcb.Controls.Add(lblincentiveservice1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);

                                    tcb.Controls.Add(new LiteralControl("<br />"));

                                    //Incentives Manufacturer
                                    Label incentivemanuq = new Label();
                                    LinkButton lblincentivemanuq = new LinkButton();
                                    LinkButton lblincentivemanu1q = new LinkButton();
                                    LinkButton lblincenredq = new LinkButton();
                                    LinkButton lblincenblackq = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    incentivemanuq.Font.Name = "calibri";
                                    incentivemanuq.Text = "Incentives (Qry)";
                                    incentivemanuq.Font.Size = 10;
                                    incentivemanuq.Width = 95;
                                    incentivemanuq.Font.Bold = true;
                                    incentivemanuq.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    incentivemanuq.Attributes.Add("style", "text-align:left !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(incentivemanuq);

                                    // lblincentivemanu.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INC";
                                    lblincentivemanuq.Font.Name = "calibri";
                                    lblincentivemanuq.Text = ":";
                                    lblincentivemanuq.Font.Size = 10;
                                    lblincentivemanuq.Width = 10;
                                    lblincentivemanuq.Font.Bold = true;
                                    lblincentivemanuq.ForeColor = Color.Black;
                                    // lblincentivemanu.Click += new EventHandler(lbl_Clickincentivemanu);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblincentivemanuq.Attributes.Add("style", "text-align:center !important;");

                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincentivemanuq);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblincenredq.Text = dsStatus.Tables[0].Rows[0]["INCENTIVEQUERYPENDING"].ToString().Trim();
                                    lblincenblackq.Text = "/" + dsStatus.Tables[0].Rows[0]["INCENTIVEQUERY"].ToString().Trim();
                                    lblincenredq.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INCQ";

                                    lblincenblackq.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INCQ";
                                    lblincentivemanu1q.Font.Name = "calibri";
                                    lblincentivemanu1q.Text = lblincenred.Text + lblincenblack.Text + "<br>";
                                    lblincentivemanu1q.Font.Size = 10;
                                    lblincentivemanu1q.Width = 40;
                                    lblincenredq.Font.Size = 10;
                                    lblincenblackq.Font.Size = 10;
                                    lblincenredq.Attributes.Add("style", "width:auto");
                                    lblincenblackq.Attributes.Add("style", "width:auto");
                                    lblincenredq.Font.Bold = true;
                                    lblincenblackq.Font.Bold = true;
                                    lblincenredq.ForeColor = Color.Red;
                                    lblincenblackq.ForeColor = Color.Black;
                                    lblincentivemanu1q.Font.Bold = true;
                                    //lblincentivemanu1.ForeColor = Color.Black;
                                    lblincenredq.Click += new EventHandler(lbl_Clickincentivemanuq);
                                    lblincenblackq.Click += new EventHandler(lbl_Clickincentivemanu1q);
                                    //lblincentivemanu1.Click += new EventHandler(lbl_Clickincentivemanu1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    lblincentivemanu1q.Attributes.Add("style", "text-align:right !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblincenredq);
                                    tcb.Controls.Add(lblincenblackq);
                                    // tcb.Controls.Add(lblincentivemanu1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);

                                    tcb.Controls.Add(new LiteralControl("<br />"));
                                    //rawmaterial
                                    Label rawmaterial = new Label();
                                    LinkButton lblrawmaterial = new LinkButton();
                                    LinkButton lblrawmaterial1 = new LinkButton();
                                    LinkButton lblrawred = new LinkButton();
                                    LinkButton lblrawblack = new LinkButton();
                                    //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                    //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                    rawmaterial.Font.Name = "calibri";
                                    rawmaterial.Text = "Rawmaterial";
                                    rawmaterial.Font.Size = 10;
                                    rawmaterial.Width = 95;
                                    rawmaterial.Font.Bold = true;
                                    rawmaterial.ForeColor = Color.Black;
                                    //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    // tcb.HorizontalAlign = HorizontalAlign.Center;
                                    rawmaterial.Attributes.Add("style", "text-align:left !important;");

                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(rawmaterial);

                                    //lblrawmaterial.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "RAW";
                                    lblrawmaterial.Font.Name = "calibri";
                                    lblrawmaterial.Text = ":";
                                    lblrawmaterial.Font.Size = 10;
                                    lblrawmaterial.Width = 10;
                                    lblrawmaterial.Font.Bold = true;
                                    lblrawmaterial.ForeColor = Color.Black;
                                    // lblrawmaterial.Click += new EventHandler(lbl_Clickrawmaterial1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    lblrawmaterial.Attributes.Add("style", "text-align:center !important;");
                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblrawmaterial);
                                    //tcb.Width = 50;
                                    //tcb.Height = 50;
                                    //tr1.Cells.Add(tcb);
                                    lblrawred.Text = dsStatus.Tables[0].Rows[0]["RAWMATERIALPENDNING"].ToString().Trim();
                                    lblrawblack.Text = "/" + dsStatus.Tables[0].Rows[0]["RAWMATERIALTOTAL"].ToString().Trim();
                                    lblrawred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "RAW";
                                    lblrawblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "RAW";
                                    lblrawmaterial1.Font.Name = "calibri";
                                    lblrawmaterial1.Text = lblrawred.Text + lblrawblack.Text + "<br>";
                                    lblrawmaterial1.Font.Size = 10;
                                    lblrawmaterial1.Width = 40;
                                    lblrawred.Font.Size = 10;
                                    lblrawblack.Font.Size = 10;
                                    lblrawred.Attributes.Add("style", "width:auto");
                                    lblrawblack.Attributes.Add("style", "width:auto");
                                    lblrawred.Font.Bold = true;
                                    lblrawblack.Font.Bold = true;
                                    lblrawred.ForeColor = Color.Red;
                                    lblrawblack.ForeColor = Color.Black;
                                    lblrawmaterial1.Font.Bold = true;
                                    //lblrawmaterial1.ForeColor = Color.Black;
                                    lblrawred.Click += new EventHandler(lbl_Clickrawmaterial1);
                                    lblrawblack.Click += new EventHandler(lbl_Clickrawmaterial1);
                                    //lblrawmaterial1.Click += new EventHandler(lbl_Clickrawmaterial1);
                                    tcb.BorderWidth = 1;
                                    tcb.VerticalAlign = VerticalAlign.Top;
                                    //tcb.HorizontalAlign = HorizontalAlign.Center;
                                    // lblrawmaterial1.Attributes.Add("style", "text-align:right !important;");
                                    lblrawmaterial1.Attributes.Add("style", "text-align:right !important;");
                                    tcb.BorderColor = Color.FromName("#B7AB9E");
                                    tcb.Controls.Add(lblrawred);
                                    tcb.Controls.Add(lblrawblack);
                                    //tcb.Controls.Add(lblrawmaterial1);
                                    tcb.Width = 50;
                                    tcb.Height = 50;
                                    tr1.Cells.Add(tcb);
                                }

                            }
                            else
                            {
                                TableCell tcd = new TableCell();
                                Label lbls = new Label();
                                lbls.Font.Name = "calibri";
                                lbls.Font.Size = 10;
                                //lbls.ForeColor = Color.Red;
                                lbls.ForeColor = Color.Red;
                                lbls.Font.Bold = true;
                                lbls.Text = daycounter.ToString() + "<br>";
                                lbls.ToolTip = "No slots available";

                                tcd.BackColor = Color.FromName("#F7FBFF");
                                tcd.BorderWidth = 1;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                // tcd.HorizontalAlign = HorizontalAlign.Right;
                                tcd.VerticalAlign = VerticalAlign.Top;

                                tcd.Controls.Add(lbls);

                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                //cfe
                                //LinkButton lblcfe = new LinkButton();

                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblcfe.ID = DateSlot;
                                //lblcfe.Font.Name = "calibri";
                                //lblcfe.Text = "CFE" + "" + ":" + dsStatus.Tables[0].Rows[0]["CFE"].ToString().Trim() + "<br>";
                                //lblcfe.Font.Size = 10;
                                //lblcfe.Width = 120;
                                //lblcfe.Font.Bold = true;
                                //lblcfe.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //// tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblcfe);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);

                                ////cfo
                                //LinkButton lblcfo = new LinkButton();
                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblcfo.ID = DateSlot;
                                //lblcfo.Font.Name = "calibri";
                                //lblcfo.Text = "CFO" + "" + ":" + dsStatus.Tables[0].Rows[0]["CFO"].ToString().Trim() + "<br>";
                                //lblcfo.Font.Size = 10;
                                //lblcfo.Font.Bold = true;
                                //lblcfo.ForeColor = Color.Black;
                                //lblcfo.Click += new EventHandler(lbl_Clickcfo);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblcfo);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);

                                ////renewal
                                //LinkButton lblren = new LinkButton();
                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblren.ID = DateSlot;
                                //lblren.Font.Name = "calibri";
                                //lblren.Text = "Renewals" + "" + ":" + dsStatus.Tables[0].Rows[0]["RENEWAL"].ToString().Trim() + "<br>";
                                //lblren.Font.Size = 10;
                                //lblren.Font.Bold = true;
                                //lblren.ForeColor = Color.Black;
                                //lblren.Click += new EventHandler(lbl_Clickren);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblren);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);

                                ////incentivemanufa
                                //LinkButton lblincentivemanu = new LinkButton();
                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblincentivemanu.ID = DateSlot;
                                //lblincentivemanu.Font.Name = "calibri";
                                //lblincentivemanu.Text = "IncentiveManufacture" + "" + ":" + dsStatus.Tables[0].Rows[0]["INCENTIVEMANUFACRURE"].ToString().Trim() + "<br>";
                                //lblincentivemanu.Font.Size = 10;
                                //lblincentivemanu.Font.Bold = true;
                                //lblincentivemanu.ForeColor = Color.Black;
                                //lblincentivemanu.Click += new EventHandler(lbl_Clickincentivemanu);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblincentivemanu);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);

                                ////incentiveservice
                                //LinkButton lblincentiveservice = new LinkButton();
                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblincentiveservice.ID = DateSlot;
                                //lblincentiveservice.Font.Name = "calibri";
                                //lblincentiveservice.Text = "IncentiveService" + "" + ":" + dsStatus.Tables[0].Rows[0]["INCENTIVESERVICE"].ToString().Trim() + "<br>";
                                //lblincentiveservice.Font.Size = 10;
                                //lblincentiveservice.Font.Bold = true;
                                //lblincentiveservice.ForeColor = Color.Black;
                                //lblincentiveservice.Click += new EventHandler(lbl_Clickincentiveservice);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblincentiveservice);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);

                                ////rawmaterials
                                //LinkButton lblraw = new LinkButton();
                                ////lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                                ////lblraw.ID = DateSlot;
                                //lblraw.Font.Name = "calibri";
                                //lblraw.Text = "Rawmaterials" + "" + ":" + dsStatus.Tables[0].Rows[0]["RAWMATERIAL"].ToString().Trim() + "<br>";
                                //lblraw.Font.Size = 10;
                                //lblraw.Font.Bold = true;
                                //lblraw.ForeColor = Color.Black;
                                //lblraw.Click += new EventHandler(lbl_Clickrawmaterial);
                                //tcd.BorderWidth = 1;
                                //tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                //tcd.BorderColor = Color.FromName("#B7AB9E");
                                //tcd.Controls.Add(lblraw);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                            }
                        }
                        else
                        {
                            string DateSlot = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();
                            DataSet dsStatus1 = GetDayWiseStatus(ddlProp_intDistrictid.SelectedValue.ToString(), DateSlot);

                            TableCell tcd = new TableCell();
                            Label lbls = new Label();
                            lbls.Font.Name = "calibri";
                            lbls.Font.Size = 10;
                            lbls.Width = 120;
                            lbls.Attributes.Add("style", "text-align:right !important;");
                            //lbls.ForeColor = Color.Red;
                            lbls.ForeColor = DateColor;
                            lbls.Font.Bold = true;
                            lbls.Text = daycounter.ToString() + "<br>";
                            lbls.ToolTip = strHoliday;
                            lbls.Enabled = DateEnable;

                            tcd.BackColor = Color.FromName("#F7FBFF");
                            tcd.BorderWidth = 1;
                            tcd.BorderColor = Color.FromName("#B7AB9E");
                            //tcd.HorizontalAlign = HorizontalAlign.Right;
                            //tcd.VerticalAlign = VerticalAlign.Top;

                            tcd.Controls.Add(lbls);

                            tcd.Width = 50;
                            tcd.Height = 50;
                            if (NowDate == DateTime.Now.Date)
                            {
                                tcd.BackColor = Color.FromName("#FFFF99");
                            }
                            tr1.Cells.Add(tcd);

                            if (NowDate <= DateTime.Now.Date)
                            {
                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //cfe
                                //cfe
                                Label cfe = new Label();
                                LinkButton lblcfe = new LinkButton();
                                LinkButton lblcfe1 = new LinkButton();
                                LinkButton lblcfered = new LinkButton();
                                LinkButton lblcfeblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                cfe.Font.Name = "calibri";
                                cfe.Text = "CFE";
                                cfe.Font.Size = 10;
                                cfe.Width = 95;
                                cfe.Font.Bold = true;
                                cfe.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                cfe.Attributes.Add("style", "text-align:left !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(cfe);

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P";
                                lblcfe.Font.Name = "calibri";
                                lblcfe.Text = ":";
                                lblcfe.Font.Size = 10;
                                lblcfe.Width = 10;
                                lblcfe.Font.Bold = true;
                                lblcfe.ForeColor = Color.Black;
                                // lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblcfe.Attributes.Add("style", "text-align:center !important;");

                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblcfe);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblcfered.Text = dsStatus1.Tables[0].Rows[0]["CFEPENDING"].ToString().Trim();
                                lblcfeblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["CFETOTAL"].ToString().Trim();
                                lblcfered.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P";
                                lblcfeblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T";
                                lblcfe1.Font.Name = "calibri";
                                //lblcfe1.Text = dsStatus.Tables[0].Rows[0]["CFEPENDING"].ToString().Trim() + "/" + dsStatus.Tables[0].Rows[0]["CFETOTAL"].ToString().Trim() + "<br>";
                                lblcfe1.Text = lblcfered.Text + lblcfeblack.Text + "<br>";//  "/"
                                lblcfe1.Font.Size = 10;
                                lblcfered.Font.Size = 10;
                                lblcfeblack.Font.Size = 10;
                                lblcfe1.Width = 40;
                                lblcfered.Attributes.Add("style", "width:auto");
                                lblcfeblack.Attributes.Add("style", "width:auto");
                                lblcfe1.Font.Bold = true;
                                lblcfered.Font.Bold = true;
                                lblcfeblack.Font.Bold = true;
                                lblcfered.ForeColor = Color.Red;
                                lblcfeblack.ForeColor = Color.Black;
                                //lblcfe1.ForeColor = Color.Black;
                                lblcfered.Click += new EventHandler(lbl_Clickcfe);
                                lblcfeblack.Click += new EventHandler(lbl_Clickcfe1);
                                //lblcfe1.Click += new EventHandler(lbl_Clickcfe1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblcfe1.Attributes.Add("style", "text-align:right !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblcfered);
                                tcd.Controls.Add(lblcfeblack);
                                // tcd.Controls.Add(lblcfe1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //cfo
                                Label cfo = new Label();
                                LinkButton lblcfo = new LinkButton();
                                LinkButton lblcfo1 = new LinkButton();
                                LinkButton lblcfored = new LinkButton();
                                LinkButton lblcfoblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                cfo.Font.Name = "calibri";
                                cfo.Text = "CFO";
                                cfo.Font.Size = 10;
                                cfo.Width = 95;
                                cfo.Font.Bold = true;
                                cfo.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                cfo.Attributes.Add("style", "text-align:left !important;");

                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(cfo);


                                // lblcfo.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "CFO";
                                lblcfo.Font.Name = "calibri";
                                lblcfo.Text = ":";
                                lblcfo.Font.Size = 10;
                                lblcfo.Width = 10;
                                lblcfo.Font.Bold = true;
                                lblcfo.ForeColor = Color.Black;
                                //lblcfo.Click += new EventHandler(lbl_Clickcfo);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblcfo.Attributes.Add("style", "text-align:center !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblcfo);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblcfored.Text = dsStatus1.Tables[0].Rows[0]["CFOPENDING"].ToString().Trim();
                                lblcfoblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["CFOTOTAL"].ToString().Trim();
                                lblcfored.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "CFO";
                                lblcfoblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "CFO";
                                lblcfo1.Font.Name = "calibri";
                                lblcfo1.Text = lblcfored.Text + lblcfoblack.Text + "<br>";
                                lblcfo1.Font.Size = 10;
                                lblcfored.Font.Size = 10;
                                lblcfoblack.Font.Size = 10;
                                lblcfored.Attributes.Add("style", "width:auto");
                                lblcfoblack.Attributes.Add("style", "width:auto");
                                lblcfo1.Width = 40;
                                lblcfo1.Font.Bold = true;
                                lblcfored.Font.Bold = true;
                                lblcfoblack.Font.Bold = true;
                                lblcfored.ForeColor = Color.Red;
                                lblcfoblack.ForeColor = Color.Black;
                                //lblcfo1.ForeColor = Color.Black;
                                lblcfored.Click += new EventHandler(lbl_Clickcfo);
                                lblcfoblack.Click += new EventHandler(lbl_Clickcfo1);
                                //lblcfo1.Click += new EventHandler(lbl_Clickcfo1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblcfo1.Attributes.Add("style", "text-align:right !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblcfored);
                                tcd.Controls.Add(lblcfoblack);
                                // tcd.Controls.Add(lblcfo1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);


                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //ren
                                Label ren = new Label();
                                LinkButton lblren = new LinkButton();
                                LinkButton lblren1 = new LinkButton();
                                LinkButton lblrenred = new LinkButton();
                                LinkButton lblrenblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                ren.Font.Name = "calibri";
                                ren.Text = "REN";
                                ren.Font.Size = 10;
                                ren.Width = 95;
                                ren.Font.Bold = true;
                                ren.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                ren.Attributes.Add("style", "text-align:left !important;");

                                //  tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(ren);

                                //lblren.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "REN";
                                lblren.Font.Name = "calibri";
                                lblren.Text = ":";
                                lblren.Font.Size = 10;
                                lblren.Width = 10;
                                lblren.Font.Bold = true;
                                lblren.ForeColor = Color.Black;
                                // lblren.Click += new EventHandler(lbl_Clickren);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblren.Attributes.Add("style", "text-align:center !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblren);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblrenred.Text = dsStatus1.Tables[0].Rows[0]["RENEWALPENDING"].ToString().Trim();
                                lblrenblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["RENEWALTOAL"].ToString().Trim();
                                lblrenred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "REN";
                                lblrenblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "REN";
                                lblren1.Font.Name = "calibri";
                                lblren1.Text = lblrenred.Text + lblrenblack.Text + "<br>";
                                lblren1.Font.Size = 10;
                                lblren1.Width = 40;
                                lblrenred.Font.Size = 10;
                                lblrenblack.Font.Size = 10;
                                lblrenred.Attributes.Add("style", "width:auto");
                                lblrenblack.Attributes.Add("style", "width:auto");
                                lblren1.Font.Bold = true;
                                lblrenblack.Font.Bold = true;
                                lblrenred.Font.Bold = true;
                                lblrenred.ForeColor = Color.Red;
                                lblrenblack.ForeColor = Color.Black;
                                //lblren1.ForeColor = Color.Black;
                                lblrenred.Click += new EventHandler(lbl_Clickren);
                                lblrenblack.Click += new EventHandler(lbl_Clickren1);
                                //lblren1.Click += new EventHandler(lbl_Clickren1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblren1.Attributes.Add("style", "text-align:right !important;");

                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblrenred);
                                tcd.Controls.Add(lblrenblack);
                                //tcd.Controls.Add(lblren1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //Incentives Manufacturer
                                Label incentivemanu = new Label();
                                LinkButton lblincentivemanu = new LinkButton();
                                LinkButton lblincentivemanu1 = new LinkButton();
                                LinkButton lblincenred = new LinkButton();
                                LinkButton lblincenblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                incentivemanu.Font.Name = "calibri";
                                incentivemanu.Text = "Incentives (Mfg)";
                                incentivemanu.Font.Size = 10;
                                incentivemanu.Width = 95;
                                incentivemanu.Font.Bold = true;
                                incentivemanu.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                incentivemanu.Attributes.Add("style", "text-align:left !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(incentivemanu);

                                //lblincentivemanu.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INC";
                                lblincentivemanu.Font.Name = "calibri";
                                lblincentivemanu.Text = ":";
                                lblincentivemanu.Font.Size = 10;
                                lblincentivemanu.Width = 10;
                                lblincentivemanu.Font.Bold = true;
                                lblincentivemanu.ForeColor = Color.Black;
                                // lblincentivemanu.Click += new EventHandler(lbl_Clickincentivemanu);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblincentivemanu.Attributes.Add("style", "text-align:center !important;");

                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincentivemanu);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblincenred.Text = dsStatus1.Tables[0].Rows[0]["INCENTIVESMANUFACTUREPENDING"].ToString().Trim();
                                lblincenblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["INCENTIVESMANUFACTURETOTAL"].ToString().Trim();
                                lblincenred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INC";
                                lblincenblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INC";
                                lblincentivemanu1.Font.Name = "calibri";
                                lblincentivemanu1.Text = lblincenred.Text + lblincenblack.Text + "<br>";
                                lblincentivemanu1.Font.Size = 10;
                                lblincentivemanu1.Width = 40;
                                lblincenred.Font.Size = 10;
                                lblincenblack.Font.Size = 10;
                                lblincenred.Attributes.Add("style", "width:auto");
                                lblincenblack.Attributes.Add("style", "width:auto");
                                lblincenred.Font.Bold = true;
                                lblincenblack.Font.Bold = true;
                                lblincenred.ForeColor = Color.Red;
                                lblincenblack.ForeColor = Color.Black;
                                lblincentivemanu1.Font.Bold = true;
                                //lblincentivemanu1.ForeColor = Color.Black;
                                lblincenred.Click += new EventHandler(lbl_Clickincentivemanu);
                                lblincenblack.Click += new EventHandler(lbl_Clickincentivemanu1);
                                //lblincentivemanu1.Click += new EventHandler(lbl_Clickincentivemanu1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                lblincentivemanu1.Attributes.Add("style", "text-align:right !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincenred);
                                tcd.Controls.Add(lblincenblack);
                                // tcd.Controls.Add(lblincentivemanu1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //Incentives Service
                                Label incentiveservice = new Label();
                                LinkButton lblincentiveservice = new LinkButton();
                                LinkButton lblincentiveservice1 = new LinkButton();
                                LinkButton lblincensred = new LinkButton();
                                LinkButton lblincensblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                incentiveservice.Font.Name = "calibri";
                                incentiveservice.Text = "Incentives (Serv)";
                                incentiveservice.Font.Size = 10;
                                incentiveservice.Width = 95;
                                incentiveservice.Font.Bold = true;
                                incentiveservice.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                incentiveservice.Attributes.Add("style", "text-align:left !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(incentiveservice);

                                //lblincentiveservice.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INCS";
                                lblincentiveservice.Font.Name = "calibri";
                                lblincentiveservice.Text = ":";
                                lblincentiveservice.Font.Size = 10;
                                lblincentiveservice.Width = 10;
                                lblincentiveservice.Font.Bold = true;
                                lblincentiveservice.ForeColor = Color.Black;
                                // lblincentiveservice.Click += new EventHandler(lbl_Clickincentiveservice);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                lblincentiveservice.Attributes.Add("style", "text-align:center !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincentiveservice);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblincensred.Text = dsStatus1.Tables[0].Rows[0]["INCENTIVESERVICEPENDING"].ToString().Trim();
                                lblincensblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["INCENTIVESERVICETOTAL"].ToString().Trim();
                                lblincensred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INCS";
                                lblincensblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INCS";
                                lblincentiveservice1.Font.Name = "calibri";
                                lblincentiveservice1.Text = lblincensred.Text + lblincensblack.Text + "<br>";
                                lblincentiveservice1.Font.Size = 10;
                                lblincentiveservice1.Width = 40;
                                lblincentiveservice1.Font.Bold = true;
                                lblincensred.Font.Size = 10;
                                lblincensblack.Font.Size = 10;
                                lblincensred.Attributes.Add("style", "width:auto");
                                lblincensblack.Attributes.Add("style", "width:auto");
                                lblincensred.Font.Bold = true;
                                lblincensblack.Font.Bold = true;
                                lblincensred.ForeColor = Color.Red;
                                lblincensblack.ForeColor = Color.Black;
                                lblincentiveservice1.ForeColor = Color.Black;
                                lblincensred.Click += new EventHandler(lbl_Clickincentiveservice);
                                lblincensblack.Click += new EventHandler(lbl_Clickincentiveservice1);
                                // lblincentiveservice1.Click += new EventHandler(lbl_Clickincentiveservice1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                lblincentiveservice1.Attributes.Add("style", "text-align:right !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincensred);
                                tcd.Controls.Add(lblincensblack);
                                //tcd.Controls.Add(lblincentiveservice1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                tcd.Controls.Add(new LiteralControl("<br />"));

                                //Incentives Manufacturer
                                Label incentivemanuq = new Label();
                                LinkButton lblincentivemanuq = new LinkButton();
                                LinkButton lblincentivemanu1q = new LinkButton();
                                LinkButton lblincenredq = new LinkButton();
                                LinkButton lblincenblackq = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                incentivemanuq.Font.Name = "calibri";
                                incentivemanuq.Text = "Incentives (Qry)";
                                incentivemanuq.Font.Size = 10;
                                incentivemanuq.Width = 95;
                                incentivemanuq.Font.Bold = true;
                                incentivemanuq.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcb.HorizontalAlign = HorizontalAlign.Center;
                                incentivemanuq.Attributes.Add("style", "text-align:left !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(incentivemanuq);

                                // lblincentivemanu.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "INC";
                                lblincentivemanuq.Font.Name = "calibri";
                                lblincentivemanuq.Text = ":";
                                lblincentivemanuq.Font.Size = 10;
                                lblincentivemanuq.Width = 10;
                                lblincentivemanuq.Font.Bold = true;
                                lblincentivemanuq.ForeColor = Color.Black;
                                // lblincentivemanu.Click += new EventHandler(lbl_Clickincentivemanu);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblincentivemanuq.Attributes.Add("style", "text-align:center !important;");

                                // tcb.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincentivemanuq);
                                //tcb.Width = 50;
                                //tcb.Height = 50;
                                //tr1.Cells.Add(tcb);
                                lblincenredq.Text = dsStatus1.Tables[0].Rows[0]["INCENTIVEQUERYPENDING"].ToString().Trim();
                                lblincenblackq.Text = "/" + dsStatus1.Tables[0].Rows[0]["INCENTIVEQUERY"].ToString().Trim();
                                lblincenredq.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "INCQ";

                                lblincenblackq.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "INCQ";
                                lblincentivemanu1q.Font.Name = "calibri";
                                lblincentivemanu1q.Text = lblincenred.Text + lblincenblack.Text + "<br>";
                                lblincentivemanu1q.Font.Size = 10;
                                lblincentivemanu1q.Width = 40;
                                lblincenredq.Font.Size = 10;
                                lblincenblackq.Font.Size = 10;
                                lblincenredq.Attributes.Add("style", "width:auto");
                                lblincenblackq.Attributes.Add("style", "width:auto");
                                lblincenredq.Font.Bold = true;
                                lblincenblackq.Font.Bold = true;
                                lblincenredq.ForeColor = Color.Red;
                                lblincenblackq.ForeColor = Color.Black;
                                lblincentivemanu1q.Font.Bold = true;
                                //lblincentivemanu1.ForeColor = Color.Black;
                                lblincenredq.Click += new EventHandler(lbl_Clickincentivemanuq);
                                lblincenblackq.Click += new EventHandler(lbl_Clickincentivemanu1q);
                                //lblincentivemanu1.Click += new EventHandler(lbl_Clickincentivemanu1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcb.HorizontalAlign = HorizontalAlign.Center;
                                lblincentivemanu1q.Attributes.Add("style", "text-align:right !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblincenredq);
                                tcd.Controls.Add(lblincenblackq);
                                // tcb.Controls.Add(lblincentivemanu1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);

                                tcd.Controls.Add(new LiteralControl("<br />"));
                                //rawmaterial
                                Label rawmaterial = new Label();
                                LinkButton lblrawmaterial = new LinkButton();
                                LinkButton lblrawmaterial1 = new LinkButton();
                                LinkButton lblrawred = new LinkButton();
                                LinkButton lblrawblack = new LinkButton();
                                //lbl.ID = NowDate.Day.ToString() + "-" + NowDate.Month.ToString() + "-" + NowDate.Year.ToString();

                                //lblcfe.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString();
                                rawmaterial.Font.Name = "calibri";
                                rawmaterial.Text = "Rawmaterial";
                                rawmaterial.Font.Size = 10;
                                rawmaterial.Width = 95;
                                rawmaterial.Font.Bold = true;
                                rawmaterial.ForeColor = Color.Black;
                                //lblcfe.Click += new EventHandler(lbl_Clickcfe);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                // tcd.HorizontalAlign = HorizontalAlign.Center;
                                rawmaterial.Attributes.Add("style", "text-align:left !important;");

                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(rawmaterial);

                                // lblrawmaterial.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + " P" + "RAW";
                                lblrawmaterial.Font.Name = "calibri";
                                lblrawmaterial.Text = ":";
                                lblrawmaterial.Font.Size = 10;
                                lblrawmaterial.Width = 10;
                                lblrawmaterial.Font.Bold = true;
                                lblrawmaterial.ForeColor = Color.Black;
                                //lblrawmaterial.Click += new EventHandler(lbl_Clickrawmaterial1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                lblrawmaterial.Attributes.Add("style", "text-align:center !important;");
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblrawmaterial);
                                //tcd.Width = 50;
                                //tcd.Height = 50;
                                //tr1.Cells.Add(tcd);
                                lblrawred.Text = dsStatus1.Tables[0].Rows[0]["RAWMATERIALPENDNING"].ToString().Trim();
                                lblrawblack.Text = "/" + dsStatus1.Tables[0].Rows[0]["RAWMATERIALTOTAL"].ToString().Trim();
                                lblrawred.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#P" + "RAW";
                                lblrawblack.ID = NowDate.Day.ToString() + "/" + NowDate.Month.ToString() + "/" + NowDate.Year.ToString() + "#T" + "RAW";
                                lblrawmaterial1.Font.Name = "calibri";
                                lblrawmaterial1.Text = lblrawred.Text + lblrawblack.Text + "<br>";
                                lblrawmaterial1.Font.Size = 10;
                                lblrawmaterial1.Width = 40;
                                lblrawred.Font.Size = 10;
                                lblrawblack.Font.Size = 10;
                                lblrawred.Attributes.Add("style", "width:auto");
                                lblrawblack.Attributes.Add("style", "width:auto");
                                lblrawred.Font.Bold = true;
                                lblrawblack.Font.Bold = true;
                                lblrawred.ForeColor = Color.Red;
                                lblrawblack.ForeColor = Color.Black;
                                lblrawmaterial1.Font.Bold = true;
                                //lblrawmaterial1.ForeColor = Color.Black;
                                lblrawred.Click += new EventHandler(lbl_Clickrawmaterial1);
                                lblrawblack.Click += new EventHandler(lbl_Clickrawmaterial1);
                                //lblrawmaterial1.Click += new EventHandler(lbl_Clickrawmaterial1);
                                tcd.BorderWidth = 1;
                                tcd.VerticalAlign = VerticalAlign.Top;
                                //tcd.HorizontalAlign = HorizontalAlign.Center;
                                // lblrawmaterial1.Attributes.Add("style", "text-align:right !important;");
                                lblrawmaterial1.Attributes.Add("style", "text-align:right !important;");
                                tcd.BorderColor = Color.FromName("#B7AB9E");
                                tcd.Controls.Add(lblrawred);
                                tcd.Controls.Add(lblrawblack);
                                //tcd.Controls.Add(lblrawmaterial1);
                                tcd.Width = 50;
                                tcd.Height = 50;
                                tr1.Cells.Add(tcd);
                            }
                        }
                        //}
                        //else
                        //{
                        //    TableCell tcd = new TableCell();
                        //    Label lbls = new Label();
                        //    lbls.Font.Name = "calibri";
                        //    lbls.Font.Size = 20;
                        //    lbls.ForeColor = Color.Red;
                        //    lbls.Font.Bold = true;
                        //    lbls.Text = daycounter.ToString() + "<br>";
                        //    lbls.Enabled = false;

                        //    tcd.BackColor = Color.FromName("#F7FBFF");
                        //    tcd.BorderWidth = 1;
                        //    tcd.BorderColor = Color.FromName("#B7AB9E");
                        //    tcd.HorizontalAlign = HorizontalAlign.Center;
                        //    tcd.VerticalAlign = VerticalAlign.Top;

                        //    tcd.Controls.Add(lbls);

                        //    tcd.Width = 50;
                        //    tcd.Height = 50;
                        //    tr1.Cells.Add(tcd);
                        //}

                    }
                }
                tbCalendar.Rows.Add(tr1);



            }


        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "errormsg";
        }
    }

    void lbl_Clickcfe(object sender, EventArgs e)
    {
        //LinkButton lbtn = (LinkButton)sender;
        ////lbtn.BackColor = Color.Red;
        //string[] date = lbtn.ID.Split('/');
        ////string[] newdate = date[0].ToString().Split('/');

        ////string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[0])).Date;

        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywisecfedrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " P");
    }

    void lbl_Clickcfe1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;

        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywisecfedrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T");

    }

    void lbl_Clickcfo1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;

        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywisecfodrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T");

    }

    void lbl_Clickcfo(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;

        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywisecfodrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " P");
    }
    void lbl_Clickren(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;

        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiserendrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " P");
    }
    void lbl_Clickren1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        //lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '/' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0]), Convert.ToInt32(lbid[2])).Date;

        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiserendrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T");
    }
    void lbl_Clickincentivemanu(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " P" + "&TYPE=" + "2");
    }
    void lbl_Clickincentivemanu1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T" + "&TYPE=" + "2");
    }
    void lbl_Clickincentiveservice(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " P" + "&TYPE=" + "1");
    }
    void lbl_Clickincentiveservice1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T" + "&TYPE=" + "1");

    }

    void lbl_Clickincentivemanuq(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " QP" + "&TYPE=" + "2");
    }
    void lbl_Clickincentivemanu1q(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiseIncentivedrillmanufacture.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " QT" + "&TYPE=" + "2");
    }

    void lbl_Clickrawmaterial(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiserawmaterialdrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T");
    }
    void lbl_Clickrawmaterial1(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string[] date = lbtn.ID.Split('#');
        string[] newdate = date[0].Split(new char[] { '/' });
        if (newdate[0].Length == 1)
        {
            newdate[0] = 0 + newdate[0];
        }
        if (newdate[1].Length == 1)
        {
            newdate[1] = 0 + newdate[1];
        }
        string SlotDate = newdate[0].ToString() + "-" + newdate[1].ToString() + "-" + newdate[2].ToString().ToString();


        Response.Redirect("frmdaywiserawmaterialdrill.aspx?intApplicationId=" + ddlProp_intDistrictid.SelectedValue + "&next=" + SlotDate + " T");
    }
    void lbl_Click(object sender, EventArgs e)
    {
        ////onlineLicenseAppBS = new OnlineLicenseAppBS();
        //CFST_BL.OnlineApplication.OnlineLicenseAppBS onlineLicenseAppBS = new CFST_BL.OnlineApplication.OnlineLicenseAppBS();
        //bool RbtnEnabled = true;
        //DataSet dsTimeSlot = new DataSet();
        ////dsTimeSlot = commonBS.GetLLRTimeSlots(ddlTestCenter.SelectedValue.ToString());
        //dsTimeSlot = commonBS.GetLicenseTimeSlots();
        //if (dsTimeSlot.Tables[0].Rows.Count > 0)
        //{
        //    rbtnTimeSlots.DataSource = dsTimeSlot;
        //    rbtnTimeSlots.DataTextField = "TimePeriod";
        //    rbtnTimeSlots.DataValueField = "TimeId";
        //    rbtnTimeSlots.DataBind();
        //}
        //tblSlots.Visible = true;

        //LinkButton lbtn = (LinkButton)sender;
        ////lbtn.BackColor = Color.Red;
        //string[] lbid = lbtn.ID.Split(new char[] { '-' });
        //DateTime SlotDate = new DateTime(Convert.ToInt32(lbid[2]), Convert.ToInt32(lbid[1]), Convert.ToInt32(lbid[0])).Date;

        //lblDate.Text = SlotDate.ToString("dd-MM-yyyy");

        //if (Session["LLRData"] != null)
        //{
        //    onlineLLAppVO = (OnlineLearnerLicenceAppVO)Session["LLRData"];
        //    int EnableCnt = 0;
        //    foreach (ListItem liTimeSlot in rbtnTimeSlots.Items)
        //    {
        //        int AvailableSlots = 0;
        //        RbtnEnabled = true;
        //        int NoofSlots = onlineLicenseAppBS.GetNoofSlotsForOnlineDLTrans(ddlTestCenter.SelectedValue.Trim());
        //        int FilledSlot = onlineLicenseAppBS.GetFilledSlotsOnlineAvailability(ddlTestCenter.SelectedValue.Trim(), Convert.ToInt32(liTimeSlot.Value), SlotDate.Month.ToString() + "/" + SlotDate.Day.ToString() + "/" + SlotDate.Year.ToString(), "");
        //        AvailableSlots = NoofSlots - FilledSlot;

        //        //int NoofSlots = onlineLicenseAppBS.GetNoofSlotsForLL(onlineLLAppVO.Office);
        //        // int FilledSlot = onlineLicenseAppBS.GetFilledSlots(onlineLLAppVO.Office, Convert.ToInt32(liTimeSlot.Value), SlotDate.Month.ToString() + "/" + SlotDate.Day.ToString() + "/" + SlotDate.Year.ToString());
        //        AvailableSlots = NoofSlots - FilledSlot;

        //        if (AvailableSlots > 0)
        //        {
        //            RbtnEnabled = true;
        //        }
        //        else
        //        {
        //            RbtnEnabled = false;
        //        }

        //        liTimeSlot.Enabled = RbtnEnabled;
        //        if (AvailableSlots < 0)
        //        {
        //            AvailableSlots = 0;
        //        }
        //        liTimeSlot.Text = liTimeSlot.Text + "<br><span style='color:Green; font-size:13'>" + " [ Available Slots : " + AvailableSlots.ToString() + " ] </span> ";

        //        if (RbtnEnabled && EnableCnt == 0)
        //        {
        //            liTimeSlot.Selected = true;
        //            EnableCnt++;
        //        }
        //    }
        //    btnSubmit.Enabled = true;
        //    Session["LLRData"] = onlineLLAppVO;
        //}
    }

    protected bool CheckDateSlot(string SlotDate)
    {
        //onlineLicenseAppBS = new OnlineLicenseAppBS();
        //CFST_BL.OnlineApplication.OnlineLicenseAppBS onlineLicenseAppBS = new CFST_BL.OnlineApplication.OnlineLicenseAppBS();
        bool RbtnEnabled = true;
        //DataSet dsTimeSlot = new DataSet();
        //dsTimeSlot = commonBS.GetLLRTimeSlots(ddlTestCenter.SelectedValue.ToString());

        //if (Session["LLRData"] != null)
        //{
        //    onlineLLAppVO = (OnlineLearnerLicenceAppVO)Session["LLRData"];
        //    foreach (DataRow drTimeSlot in dsTimeSlot.Tables[0].Rows)
        //    {
        //        int AvailableSlots = 0;
        //        RbtnEnabled = true;

        //        int NoofSlots = onlineLicenseAppBS.GetNoofSlotsForOnlineDLTrans(ddlTestCenter.SelectedValue.Trim());
        //        int FilledSlot = onlineLicenseAppBS.GetFilledSlotsOnlineLIC(ddlTestCenter.SelectedValue.Trim(), Convert.ToInt32(drTimeSlot["TimeId"].ToString()), SlotDate, "");
        //        AvailableSlots = NoofSlots - FilledSlot;

        //        if (AvailableSlots > 0)
        //        {
        //            RbtnEnabled = true;
        //        }
        //        else
        //        {
        //            RbtnEnabled = false;
        //        }

        //        //liTimeSlot.Enabled = RbtnEnabled;
        //        //liTimeSlot.Text = liTimeSlot.Text + "<br><span style='color:Green; font-size:13'>" + " [ Available Slots : " + AvailableSlots.ToString() + " ] </span> ";

        //        //if (RbtnEnabled && EnableCnt == 0)
        //        //{
        //        //    liTimeSlot.Selected = true;
        //        //    EnableCnt++;
        //        //}
        //        if (RbtnEnabled)
        //        {
        //            break;
        //        }
        //    }
        //}
        return RbtnEnabled;
    }

    void lbtnNextMonth_Click(object sender, EventArgs e)
    {
        ChangeDt("nextmo");
    }

    void lbtnPreviousMonth_Click(object sender, EventArgs e)
    {
        ChangeDt("prevmo");
    }

    protected void ChangeDt(string str)
    {
        if (str == "prevmo") monthNum--;
        else if (str == "nextmo") monthNum++;
        else if (str == "return")
        {
            monthNum = todaysMonth;
            yearNum = todaysYear;
        }

        if (monthNum == 0)
        {
            monthNum = 12;
            yearNum--;
        }
        else if (monthNum == 13)
        {
            monthNum = 1;
            yearNum++;
        }

        lastDate = DateTime.DaysInMonth(yearNum, monthNum);
        numbDays = lastDate;

        firstDate = new DateTime(yearNum, monthNum, 1);

        firstDay = int.Parse(firstDate.DayOfWeek.ToString("d"));

        Response.Redirect("frmCalenderReportCOI.aspx?month=" + monthNum + "&year=" + yearNum);
    }

    private void AddSelect(ref DropDownList drp)
    {
        ListItem lstSelect = new ListItem();
        lstSelect.Value = "0";
        lstSelect.Text = "Select";
        drp.Items.Insert(0, lstSelect);
    }
    #endregion
    protected void ddlTestCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //onlineLLAppVO = (OnlineLearnerLicenceAppVO)Session["LLRData"];
        //onlineLLAppVO.Office = ddlTestCenter.SelectedValue;
        //onlineLLAppVO.OfficeDesc = ddlTestCenter.SelectedItem.Text;
        //Session["LLRData"] = onlineLLAppVO;
        //Response.Redirect("OnlineSelectSlot.aspx");
    }

    public DataSet GetDayWiseStatus(string DISTRICTID, string AppnId)
    {
        SqlDataAdapter da;
        osqlConnection.Open();
        DataSet ds = new DataSet();
        string[] date = AppnId.Split('-');
        //string[] newdate = date[0].ToString().Split('/');
        AppnId = date[1].ToString() + "/" + date[0].ToString() + "/" + date[2].ToString();
        try
        {
            da = new SqlDataAdapter("USP_GET_DAYWISEAPPLICATION", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null || DISTRICTID.Trim() == "--Select--")
            //if (DISTRICTID == null || DISTRICTID == "--District--")
            //{
            //    if (DISTRICTID.Trim() == "" || DISTRICTID == "--District--")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
            }
            //}

            else //if (DISTRICTID.Trim() != null && DISTRICTID.Trim() != "")
            {
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DISTRICTID.ToString();
            }

            if (AppnId.Trim() == "" || AppnId.Trim() == null)
                da.SelectCommand.Parameters.Add("@APPLICATIONDATE", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@APPLICATIONDATE", SqlDbType.VarChar).Value = AppnId.ToString();



            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {

        Session["DistrictIDSel"] = ddlProp_intDistrictid.SelectedValue.ToString();
        Response.Redirect("frmCalenderReportCOI.aspx");
        //string dis = ddlProp_intDistrictid.SelectedValue.ToString();

        //int year = DateTime.Now.Year - 7, count = 1;
        //DropDownList1.Items.Insert(0, new ListItem("---select---"));

        //for (int i = year; i < year + 7; i++)
        //{
        //    DropDownList1.Items.Insert(count, new ListItem("April " + i.ToString() + " - " + "March " + (i + 1).ToString()));
        //    count++;
        //}

        //SetValues();
        //CreateHeading();
        //CreateCalendar();
    }
    protected void ddlProp_Financial_SelectedIndexChanged(object sender, EventArgs e)
    {

        string dif = DropDownList1.SelectedValue.ToString();
        calendarPanel.Visible = false;
        //BindGrid();

    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings[""].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, ContactName, City, Country FROM Customers"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBoxUserID.Text = GridView1.SelectedRow.Cells[1].Text;
        //TextBoxUserName.Text = GridView1.SelectedRow.Cells[2].Text;
        SetValues();
        CreateHeading();
        CreateCalendar();
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
                ddlProp_intDistrictid.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlProp_intDistrictid.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void CtrlBtnSubmt_Click(object sender, EventArgs e)
    {
        SetValues();
        CreateHeading();
        CreateCalendar();
    }
}