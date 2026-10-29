using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_MSMEClosedUnitsList : System.Web.UI.Page
{
    DB.DB con = new DB.DB();
    string District = null;
    int AppcClosedUnits, GMUpdtdClosedUnits, Competetion, Covid, DisputeamongPartners,
FinanceProblems, LabourProblems, ManagementProblems, NoDemand, LegalDispute, NotEstablished, OtherActivity, OutDated,
PersonalReasons, PhoneNotWorking, Relocation, TemporarilyClosed, SeasonallyClosed, SoldOut, TechnicalProblem, Other;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["uid"]) != "")
        {
            
            if (!IsPostBack)
            {
                lbl_datesdisplay.Text = "Report as on date " + DateTime.Now;
                txtFromDate.Text = "01-01-2023";
                DateTime today = DateTime.Today;
                txtTodate.Text = today.ToString("dd-MM-yyyy");
                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    District = Convert.ToString(Session["DistrictID"]);
                }
                FillGrid(District);
            }
        }
    }
    private void FillGrid(string District)
    {
        DataSet ds = new DataSet();
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        ds = MSMEClosedUnitsReport(District);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    public DataSet MSMEClosedUnitsReport(string District)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETMSMECLOSEDUNITS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (District == "" || District == null)
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DistrictID", SqlDbType.VarChar).Value = District.Trim();

            da.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int AppcClosedUnits1, GMUpdtdClosedUnits1, Competetion1, Covid1, DisputeamongPartners1,
            FinanceProblems1, LabourProblems1, ManagementProblems1, NoDemand1, LegalDispute1, NotEstablished1, OtherActivity1,
            OutDated1, PersonalReasons1, PhoneNotWorking1, Relocation1, TemporarilyClosed1, SeasonallyClosed1, SoldOut1,
            TechnicalProblem1, Other1;

            AppcClosedUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AppcClosedUnits"));
            GMUpdtdClosedUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GMUpdtdClosedUnits"));
            Competetion1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Competetion"));
            Covid1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Covid"));
            DisputeamongPartners1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DisputeamongPartners"));
            FinanceProblems1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinanceProblems"));
            LabourProblems1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LabourProblems"));

            ManagementProblems1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ManagementProblems"));
            NoDemand1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoDemand"));
            LegalDispute1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LegalDispute"));
            NotEstablished1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NotEstablished"));
            OtherActivity1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OtherActivity"));
            OutDated1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OutDated"));
            PersonalReasons1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PersonalReasons"));

            PhoneNotWorking1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PhoneNotWorking"));
            Relocation1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Relocation"));
            TemporarilyClosed1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TemporarilyClosed"));
            SeasonallyClosed1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SeasonallyClosed"));
            SoldOut1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SoldOut"));
            TechnicalProblem1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TechnicalProblem"));
            Other1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Other"));

            string DistrictID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictID"));
            string District = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DistrictName"));
            string Status = "";

            AppcClosedUnits = AppcClosedUnits + AppcClosedUnits1; GMUpdtdClosedUnits = GMUpdtdClosedUnits + GMUpdtdClosedUnits1;
            Competetion = Competetion + Competetion1; Covid = Covid + Covid1; 
            DisputeamongPartners = DisputeamongPartners + DisputeamongPartners1;
            FinanceProblems = FinanceProblems + FinanceProblems1; LabourProblems = LabourProblems + LabourProblems1; 
            ManagementProblems = ManagementProblems + ManagementProblems1;
            NoDemand = NoDemand + NoDemand1; LegalDispute = LegalDispute + LegalDispute1; 
            NotEstablished = NotEstablished + NotEstablished1;
            OtherActivity = OtherActivity + OtherActivity1; OutDated = OutDated + OutDated1; 
            PersonalReasons = PersonalReasons + PersonalReasons1;
            PhoneNotWorking = PhoneNotWorking + PhoneNotWorking1; Relocation = Relocation + Relocation1; 
            TemporarilyClosed = TemporarilyClosed + TemporarilyClosed1;
            SeasonallyClosed = SeasonallyClosed + SeasonallyClosed1; SoldOut = SoldOut + SoldOut1;
            TechnicalProblem = TechnicalProblem + TechnicalProblem1;
            Other = Other + Other1;


            //HyperLink hyp_noofunits = (HyperLink)e.Row.FindControl("hyp_noofunits");
            //
            HyperLink hplAppcClosedUnits = (HyperLink)e.Row.FindControl("hplAppcClosedUnits");
            HyperLink hplGMUpdtdClosedUnits = (HyperLink)e.Row.FindControl("hplGMUpdtdClosedUnits");
            HyperLink hplCompetetion = (HyperLink)e.Row.FindControl("hplCompetetion");
            HyperLink hplCovid = (HyperLink)e.Row.FindControl("hplCovid");
            HyperLink hplDisputeamongPartners = (HyperLink)e.Row.FindControl("hplDisputeamongPartners");
            HyperLink hplFinanceProblems = (HyperLink)e.Row.FindControl("hplFinanceProblems");
            HyperLink hplLabourProblems = (HyperLink)e.Row.FindControl("hplLabourProblems");

            HyperLink hplManagementProblems = (HyperLink)e.Row.FindControl("hplManagementProblems");
            HyperLink hplNoDemand = (HyperLink)e.Row.FindControl("hplNoDemand");
            HyperLink hplLegalDispute = (HyperLink)e.Row.FindControl("hplLegalDispute");
            HyperLink hplNotEstablished = (HyperLink)e.Row.FindControl("hplNotEstablished");
            HyperLink hplOtherActivity = (HyperLink)e.Row.FindControl("hplOtherActivity");
            HyperLink hplOutDated = (HyperLink)e.Row.FindControl("hplOutDated");
            HyperLink hplPersonalReasons = (HyperLink)e.Row.FindControl("hplPersonalReasons");

            HyperLink hplPhoneNotWorking = (HyperLink)e.Row.FindControl("hplPhoneNotWorking");
            HyperLink hplRelocation = (HyperLink)e.Row.FindControl("hplRelocation");
            HyperLink hplTemporarilyClosed = (HyperLink)e.Row.FindControl("hplTemporarilyClosed");
            HyperLink hplSeasonallyClosed = (HyperLink)e.Row.FindControl("hplSeasonallyClosed");
            HyperLink hplSoldOut = (HyperLink)e.Row.FindControl("hplSoldOut");
            HyperLink hplTechnicalProblem = (HyperLink)e.Row.FindControl("hplTechnicalProblem");
            HyperLink hplOther = (HyperLink)e.Row.FindControl("hplOther");
        //https://ipass.telangana.gov.in/UI/TSiPASS/frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=01-03-2020&todate=02-07-2024&district=4&type=MSMENOOFUNITS

            if (hplAppcClosedUnits.Text != "0")
                hplAppcClosedUnits.NavigateUrl = "frmMSMEReportDRILLDOWN.aspx?district=" + DistrictID + "&ROLE=" + Convert.ToString(Session["Role_Code"]) + "&fromdate=01-03-2020&todate=" + DateTime.Now.ToString("dd-MM-yyyy") + "&type=MSMECLOSEDUNITS";


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
            Label lblAppcClosedUnits = (Label)e.Row.FindControl("lblAppcClosedUnits");
            Label lblGMUpdtdClosedUnits = (Label)e.Row.FindControl("lblGMclosedunits");
            Label lblCompetetion = (Label)e.Row.FindControl("lblCompetetion");
            Label lblCovid = (Label)e.Row.FindControl("lblCovid");
            Label lblDisputeamongPartners = (Label)e.Row.FindControl("lblDisputeamongPartners");
            Label lblFinanceProblems = (Label)e.Row.FindControl("lblFinanceProblems");
            Label lblLabourProblems = (Label)e.Row.FindControl("lblLabourProblems");

            Label lblManagementProblems = (Label)e.Row.FindControl("lblManagementProblems");
            Label lblNoDemand = (Label)e.Row.FindControl("lblNoDemand");
            Label lblLegalDispute = (Label)e.Row.FindControl("lblLegalDispute");
            Label lblNotEstablished = (Label)e.Row.FindControl("lblNotEstablished");
            Label lblOtherActivity = (Label)e.Row.FindControl("lblOtherActivity");
            Label lblOutDated = (Label)e.Row.FindControl("lblOutDated");
            Label lblPersonalReasons = (Label)e.Row.FindControl("lblPersonalReasons");

            Label lblPhoneNotWorking = (Label)e.Row.FindControl("lblPhoneNotWorking");
            Label lblRelocation = (Label)e.Row.FindControl("lblRelocation");
            Label lblTemporarilyClosed = (Label)e.Row.FindControl("lblTemporarilyClosed");
            Label lblSeasonallyClosed = (Label)e.Row.FindControl("lblSeasonallyClosed");
            Label lblSoldOut = (Label)e.Row.FindControl("lblSoldOut");
            Label lblTechnicalProblem = (Label)e.Row.FindControl("lblTechnicalProblem");
            Label lblOther = (Label)e.Row.FindControl("lblOther");


            lblAppcClosedUnits.Text = Convert.ToString(AppcClosedUnits);
            lblGMUpdtdClosedUnits.Text = Convert.ToString(GMUpdtdClosedUnits);
            lblCompetetion.Text = Convert.ToString(Competetion);
            lblCovid.Text = Convert.ToString(Covid);
            lblDisputeamongPartners.Text = Convert.ToString(DisputeamongPartners);
            lblFinanceProblems.Text = Convert.ToString(FinanceProblems);
            lblLabourProblems.Text = Convert.ToString(LabourProblems);

            lblManagementProblems.Text = Convert.ToString(ManagementProblems);
            lblNoDemand.Text = Convert.ToString(NoDemand);
            lblLegalDispute.Text = Convert.ToString(LegalDispute);
            lblNotEstablished.Text = Convert.ToString(NotEstablished);
            lblOtherActivity.Text = Convert.ToString(OtherActivity);
            lblOutDated.Text = Convert.ToString(OutDated);
            lblPersonalReasons.Text = Convert.ToString(PersonalReasons);


            lblPhoneNotWorking.Text = Convert.ToString(PhoneNotWorking);
            lblRelocation.Text = Convert.ToString(Relocation);
            lblTemporarilyClosed.Text = Convert.ToString(TemporarilyClosed);
            lblSeasonallyClosed.Text = Convert.ToString(SeasonallyClosed);
            lblSoldOut.Text = Convert.ToString(SoldOut);
            lblTechnicalProblem.Text = Convert.ToString(TechnicalProblem);
            lblOther.Text = Convert.ToString(Other);
        }

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        Failure.Visible = false;
        lblmsg0.Text = "";
        try
        {
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                District = Convert.ToString(Session["DistrictID"]);

            }
            if (txtFromDate.Text == "" && txtFromDate.Text == null && txtTodate.Text == "" && txtTodate.Text == null)
            {
                FillGrid(District);
            }
            else
            {
                if (txtFromDate.Text == "" || txtFromDate.Text == null)
                {
                    if (txtTodate.Text != "" || txtTodate.Text != null)
                    {
                        Failure.Visible = true;
                        lblmsg0.Text = "Please Enter From Date ";
                    }
                    else
                    {
                        FillGrid(District);
                    }
                }
                else
                {
                    if (txtTodate.Text == "" || txtTodate.Text == null)
                    {
                        Failure.Visible = true;
                        lblmsg0.Text += "Please Enter To Date";
                    }
                    else
                    {
                        //FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                       // TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
                        lbl_datesdisplay.Text = "Report from " + txtFromDate.Text.Trim() + " to " + txtTodate.Text.Trim();
                        FillGrid(District);
                    }
                }

            }

        }
        catch (Exception ex)
        {
            Failure.Visible = true;
            lblmsg0.Text += ex;

        }
    }
    protected void lnk_pdf_Click(object sender, EventArgs e)
    {
        ExportToPDF();
    }
    protected void ExportToPDF()
    {
        this.FillGrid( District);

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=MSMEDistrictWiseReport_MSMESURVEY.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grdDetails.AllowPaging = false;
        grdDetails.HeaderRow.Visible = true;
        grdDetails.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    private void Excel_Export()
    {
        string fn = "MSMEDistrictWiseReport_MSMESURVEY";
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fn + ".xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grdDetails.AllowPaging = false;
        this.FillGrid(District);
        //Change the Header Row back to white color
        grdDetails.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < grdDetails.HeaderRow.Cells.Count; i++)
        {
            grdDetails.HeaderRow.Cells[i].Style.Add("background-color", "#df5015");
        }
        grdDetails.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void lnk_excel_Click(object sender, EventArgs e)
    {
        Excel_Export();
    }

    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow gvHeaderRow = e.Row;
            GridViewRow gvHeaderRowCopy = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            this.grdDetails.Controls[0].Controls.AddAt(0, gvHeaderRowCopy);

            int headerCellCount = gvHeaderRow.Cells.Count;
            int cellIndex = 0;

            for (int i = 0; i < headerCellCount; i++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3)
                {
                    TableCell tcHeader = gvHeaderRow.Cells[cellIndex];
                    tcHeader.RowSpan = 2;
                    gvHeaderRowCopy.Cells.Add(tcHeader);
                }
                else
                {
                    cellIndex++;


                }
            }


            TableCell tcMergePackage = new TableCell();
            tcMergePackage.Text = "Reason For Closing";
            tcMergePackage.CssClass = "GridviewScrollC1Header";
            tcMergePackage.ColumnSpan = 22;
            gvHeaderRowCopy.Cells.AddAt(4, tcMergePackage);
        }
    }
}