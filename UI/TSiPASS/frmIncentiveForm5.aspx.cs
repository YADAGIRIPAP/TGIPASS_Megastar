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
using System.IO;
using System.Collections.Generic;
using System.Linq;

public partial class UI_TSiPASS_frmIncentiveForm5 : System.Web.UI.Page
{

    DataTable dt = new DataTable();
    DB.DB con = new DB.DB();

    PCBClass objPCB = new PCBClass();
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    DataTable myDtNewPowerdr = new DataTable();
    DataTable myDtNewEnergydr = new DataTable();

    static DataTable dtPower1;
    static DataTable dtPower2;

    static DataTable dtEnergy1;
    static DataTable dtEnergy2;

    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;


        if (!IsPostBack)
        {
            if (Session["incentivedata"] != null)
            {
                hdnincid.Value = Session["EntprIncentive"].ToString();
               

                string userid = Session["uid"].ToString();
                string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

               
                

                    string IndustryStatus = dscaste.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                if (IndustryStatus == "2" || IndustryStatus == "3")
                {
                    trSalesTaxExpansion.Visible = true;
                }
                else
                {
                    trSalesTaxExpansion.Visible = false;
                }

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 5);  // Sales TAX(VAT/GST/SGST) Reimbursement
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("IncentiveFORMVI.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmIncentiveForm4.aspx?Previous=" + "P");
                    }
                }
                if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                {
                    lblscheme.Text = "TIDEA, 2014";
                }
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                {
                    lblscheme.Text = "TFAP, 2022";
                }
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                {
                    lblscheme.Text = "IIPP Scheme 2005 - 2010";
                }
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                {
                    lblscheme.Text = "IIPP Scheme 2010 - 2015";
                }

                string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();


                if (lblscheme.Text == "TIDEA, 2014")
                {
                    //  if (caste == "3" || caste == "4")   //SC, ST
                    if (TSCPflag == "Y" || TSPflag == "Y")
                    {
                        lblheadTPRIDE.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SALES TAX UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SALES TAX UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }

                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SALES TAX UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }

                BindFinancialYears1(ddlFinYearPower, "3", IncentveID);
                //BindFinancialYears(ddlFinYearEnergy, "3", IncentveID);  COMMENTED ON 28.03.22 7 YEARS FOR SALESTAX
                //BindFinancialYears1
                BindFinancialYears1(ddlFinYearEnergy, "3", IncentveID);
                DataSet dsdisable = new DataSet();
               

                    dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);
                if (dsdisable.Tables.Count > 0 && dsdisable.Tables[6].Rows.Count > 0)
                {
                    string applicationStatus = "";
                    applicationStatus = dsdisable.Tables[6].Rows[0]["intStatusid"].ToString();
                    if (applicationStatus != "")
                    {
                        if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                        {
                            ResetFormControl(this);
                        }

                    }
                    hdnMSMEApplied.Value = dsdisable.Tables[6].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
                    if (hdnMSMEApplied.Value == "Y")
                    {
                        lblMSMEPolicy.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Visible = false;
                        trMSME1.Visible = true;
                        trMSME2.Visible = true;
                        BindFinancialYears1(ddlFinYear_availed, "3", IncentveID);
                    }
                }
            }



            dtPower1 = PowerDt();
            Session["Power"] = dtPower1;

            dtEnergy1 = EnergyDt();
            Session["Energy"] = dtEnergy1;

            //gvProductiondtls.DataSource = BindProductionGrid();
            //gvProductiondtls.DataBind();

            //gvSalesTax.DataSource = BindSalesTaxGrid();
            //gvSalesTax.DataBind();
        }
        if (!IsPostBack)
        {
            FillDetails();

        }
    }

    private void FillDetails()
    {
        DataSet ds = new DataSet();
        int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
        //int IncentiveId = Convert.ToInt32("11");
        ds = Gen.GetFormVIncentives(IncentiveId);
        if (ds != null && ds.Tables.Count > 0) //&& ds.Tables[0].Rows.Count > 0)
        {

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                ViewState["dtProductiondtls"] = ds.Tables[0];
                //gvProductiondtls.DataSource = ds.Tables[0];
                //gvProductiondtls.DataBind();

                gvpowerview.DataSource = ds.Tables[0];
                gvpowerview.DataBind();

                trpower1.Visible = false;
                trpower2.Visible = false;
                gvpower.Visible = false;

                trpowerview.Visible = true;
                gvpowerview.Visible = true;
            }
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                BtnSave1.Enabled = false;
                BtnDelete.Enabled = true;

                ViewState["dtSalesTax"] = ds.Tables[1];
                //gvSalesTax.DataSource = ds.Tables[1];
                //gvSalesTax.DataBind();

                gvenergyview.DataSource = ds.Tables[1];
                gvenergyview.DataBind();

                trEnergy1.Visible = false;
                trEnergy2.Visible = false;
                gvEnergy.Visible = false;

                trenergyview.Visible = true;
                gvenergyview.Visible = true;
            }
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                DataTable table = ds.Tables[2];
                string sen, sen1, sen2, sennew;

                foreach (DataRow dr in table.Rows)
                {
                    string AttcahmentId = dr["AttachmentId"].ToString();

                    sen2 = dr["FilePath"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    // sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = dr["LINKNEW"].ToString(); // LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    if (AttcahmentId == "55")
                    {
                        // lblFileName.NavigateUrl = sen;
                        lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName.Text = dr["FileNm"].ToString();
                        Label444.Text = dr["FileNm"].ToString();
                    }
                    //if (AttcahmentId == "56")
                    if (AttcahmentId == "3002")
                    {
                        // HyperLink1.NavigateUrl = sen;
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = dr["FileNm"].ToString();
                        Label4.Text = dr["FileNm"].ToString();
                    }
                    //if (AttcahmentId == "57")
                    if (AttcahmentId == "44")
                    {
                        //HyperLink2.NavigateUrl = sen;
                        HyperLink2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink2.Text = dr["FileNm"].ToString();
                        Label5.Text = dr["FileNm"].ToString();
                        HyperLink2.Visible = true;
                    }
                    if (AttcahmentId == "906")
                    {
                        hplGST3B.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplGST3B.Text = dr["FileNm"].ToString();
                        lblGST3B.Text = dr["FileNm"].ToString();
                        hplGST3B.Visible = true;
                    }
                }
                //  BtnSave1.Enabled = false;
            }
            if (hdnMSMEApplied.Value == "Y")
            {
                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblAvailed.Visible = true;
                    gvAvailed.DataSource = ds.Tables[3];
                    gvAvailed.DataBind();
                    gvAvailed.Columns[6].Visible = false;
                    trMSME6.Visible = true;
                    trMSME2.Visible = false;
                }
            }
        }
        else
        {
            trpower1.Visible = true;
            trpower2.Visible = true;
            gvpower.Visible = true;

            trpowerview.Visible = false;
            gvpowerview.Visible = false;

            trEnergy1.Visible = true;
            trEnergy2.Visible = true;
            gvEnergy.Visible = true;

            trenergyview.Visible = false;
            gvenergyview.Visible = false;
        }
    }
    private DataTable BindSalesTaxGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FinancialYear");
        dt.Columns.Add("F_AmountPaid");
        dt.Columns.Add("F_AmountClaimed");
        dt.Columns.Add("S_AmountPaid");
        dt.Columns.Add("S_AmountClaimed");
        //   dt.Columns.Add("Fin1stOr2ndHalfYear");

        for (int i = 0; i < 5; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";
            dr[3] = "";
            dr[4] = "";
            //dr[5] = "";
            dt.Rows.Add(dr);
        }

        return dt;
    }
    private DataTable BindProductionGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FinancialYear");
        dt.Columns.Add("Unit");
        dt.Columns.Add("Quantity");
        for (int i = 0; i < 3; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";

            dt.Rows.Add(dr);
        }

        return dt;
    }
    private void BindFinancialYears(DropDownList ddlFinYear, string Count, string IncentveID)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, IncentveID);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlFinYear.DataSource = dsYears.Tables[0];
            ddlFinYear.DataTextField = "FinancialYear";
            ddlFinYear.DataValueField = "SlNo";
            ddlFinYear.DataBind();
        }
        ddlFinYear.Items.Insert(0, "--Select--");

    }
    private void BindFinancialYears1(DropDownList ddlFinYear, string Count, string IncentveID)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives("SALESTAX", IncentveID);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddlFinYear.DataSource = dsYears.Tables[0];
            ddlFinYear.DataTextField = "FinancialYear";
            ddlFinYear.DataValueField = "SlNo";
            ddlFinYear.DataBind();
        }
        ddlFinYear.Items.Insert(0, "--Select--");

    }
    protected void gvSalesTax_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmIncentiveForm4.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        int start = 0;
        if (HyperLink1.Text == "" || HyperLink1.Text == null)
        {
            lblmsg0.Text = "Please Uppload the documents";
            Failure.Visible = true;
            Button1.Focus();
            start = 1;
        }
        if (HyperLink2.Text == "" || HyperLink2.Text == null)
        {
            lblmsg0.Text = "Please Uppload the documents";
            Failure.Visible = true;
            Button2.Focus();
            start = 1;
        }
        if (start == 0)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "5", "Y", "");
            Response.Redirect("IncentiveFORMVI.aspx?next=" + "N");
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //List<FormVProduction> lstProduction = new List<FormVProduction>();
    //int IncentiveId = Convert.ToInt32(Session["EntprIncentive"].ToString());
    //foreach (GridViewRow gvr in gvProductiondtls.Rows)
    //{
    //    FormVProduction productionVo = new FormVProduction();

    //    DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //    TextBox txtUnitofMeasurment = (TextBox)gvr.FindControl("txtUnitofMeasurment");
    //    TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
    //    TextBox txtValue = (TextBox)gvr.FindControl("txtValue");

    //    productionVo.FinancialYear = ddlFinYear.SelectedValue;
    //    productionVo.Unit = txtUnitofMeasurment.Text;
    //    productionVo.Quantity = txtQuantity.Text;
    //    productionVo.Value = txtValue.Text;

    //    lstProduction.Add(productionVo);
    //}
    //List<FormVSales> lstSalesTax = new List<FormVSales>();

    //foreach (GridViewRow gvr in gvSalesTax.Rows)
    //{
    //    FormVSales salesVo = new FormVSales();
    //    DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
    //    TextBox txt1Amountpaid = (TextBox)gvr.FindControl("txt1Amountpaid");
    //    TextBox txt1AmountClaimed = (TextBox)gvr.FindControl("txt1AmountClaimed");
    //    TextBox txt2Amountpaid = (TextBox)gvr.FindControl("txt2Amountpaid");
    //    TextBox txt2AmountClaimed = (TextBox)gvr.FindControl("txt2AmountClaimed");

    //    salesVo.FinancialYear = ddlFinYear.SelectedValue;
    //    salesVo.F_AmountPaid = txt1Amountpaid.Text;
    //    salesVo.F_AmountClaimed = txt1AmountClaimed.Text;
    //    salesVo.S_AmountPaid = txt2Amountpaid.Text;
    //    salesVo.S_AmountClaimed = txt2AmountClaimed.Text;
    //    if (ddlFinYear.SelectedValue != "--Select--" && txt1Amountpaid.Text != "")
    //        lstSalesTax.Add(salesVo);
    //}
    //string Created_By = Session["uid"].ToString();
    ////string amountClaimed = txtClaimedAmount.Text.Trim();
    //int valid = 1;
    //valid = Gen.InsertFormVIncentives(Created_By, IncentiveId, lstProduction, lstSalesTax);
    //if (valid == 0)
    //{
    //    lblmsg.Text = "Added Successfully..!";
    //    success.Visible = true;
    //    Failure.Visible = false;
    //}
    //}
    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }
    private void getmymultiheader(GridViewRowEventArgs e, SortedList createcells2)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row;
            IDictionaryEnumerator enumCels = createcells2.GetEnumerator();
            row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);
            while (enumCels.MoveNext())
            {
                string[] cont = enumCels.Value.ToString().Split(Convert.ToChar(","));
                TableCell Cell;
                Cell = new TableCell();
                Cell.RowSpan = Convert.ToInt16(cont[2].ToString());
                Cell.ColumnSpan = Convert.ToInt16(cont[1].ToString());
                Cell.Controls.Add(new LiteralControl(cont[0].ToString()));
                Cell.HorizontalAlign = HorizontalAlign.Center;
                Cell.ForeColor = System.Drawing.Color.White;
                row.Cells.Add(Cell);
            }
            e.Row.Parent.Controls.AddAt(0, row);
        }
    }
    protected void gvProductiondtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtProductiondtls"];
                DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
                BindFinancialYears(ddlFinYear, "3", Session["EntprIncentive"].ToString());

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txtUnitofMeasurment = (TextBox)gvr.FindControl("txtUnitofMeasurment");
                        TextBox txtQuantity = (TextBox)gvr.FindControl("txtQuantity");
                        TextBox txtValue = (TextBox)gvr.FindControl("txtValue");

                        txtUnitofMeasurment.Text = dt.Rows[e.Row.RowIndex]["Unit"].ToString();
                        txtQuantity.Text = dt.Rows[e.Row.RowIndex]["Quantity"].ToString();
                        txtValue.Text = dt.Rows[e.Row.RowIndex]["Value"].ToString();
                        ddlFinYear.SelectedValue = dt.Rows[e.Row.RowIndex]["FinancialYear"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvSalesTax_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            success.Visible = false;
            Failure.Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = e.Row;

                DataTable dt = (DataTable)ViewState["dtSalesTax"];
                DropDownList ddlFinYear = (DropDownList)gvr.FindControl("ddlFinYear");
                BindFinancialYears(ddlFinYear, "5", Session["EntprIncentive"].ToString());

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        TextBox txt1Amountpaid = (TextBox)gvr.FindControl("txt1Amountpaid");
                        TextBox txt1AmountClaimed = (TextBox)gvr.FindControl("txt1AmountClaimed");
                        TextBox txt2Amountpaid = (TextBox)gvr.FindControl("txt2Amountpaid");
                        TextBox txt2AmountClaimed = (TextBox)gvr.FindControl("txt2AmountClaimed");

                        txt1Amountpaid.Text = dt.Rows[e.Row.RowIndex]["F_AmountPaid"].ToString();
                        txt1AmountClaimed.Text = dt.Rows[e.Row.RowIndex]["F_AmountClaimed"].ToString();
                        txt2Amountpaid.Text = dt.Rows[e.Row.RowIndex]["S_AmountPaid"].ToString();
                        txt2AmountClaimed.Text = dt.Rows[e.Row.RowIndex]["S_AmountClaimed"].ToString();

                        ddlFinYear.SelectedValue = dt.Rows[e.Row.RowIndex]["FinancialYear"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (FileUpload2.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\56");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\3002");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\5\\3002");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\5\\3002";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload2.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "56", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "3002", sFileName, serverpath, CrtdUser);

                        HyperLink1.Text = sFileName;

                        Failure.Visible = false;
                        BtnSave1.Focus();
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";

        General t1 = new General();
        if (FileUpload3.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\57");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\44");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\5\\44");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\5\\44";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload3.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        //t1.InsertIncentiveAttachment(incentiveid, "57", sFileName, serverpath, CrtdUser);
                        t1.InsertIncentiveAttachment(incentiveid, "NA", "44", sFileName, serverpath, CrtdUser);

                        HyperLink2.Text = sFileName;

                        HyperLink2.Visible = true;
                        Failure.Visible = false;
                        FileUpload2.Focus();
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\55");
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\5\\55");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\5\\55";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;

                        t1.InsertIncentiveAttachment(incentiveid, "NA", "55", sFileName, serverpath, CrtdUser);

                        lblFileName.Text = sFileName;

                        Failure.Visible = false;
                        FileUpload3.Focus();
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }
    }

    ///////////////////////////////////////////////////////////////////////////////

    private void AddDataToTablePower(string FinancialYearId, string FinancialYear, string UnitsConsumed, string AmountPaid, string Value, string IncentiveId, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtPower2 = new DataTable("Power1");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["UnitsConsumed"] = UnitsConsumed;
            Row["AmountPaid"] = AmountPaid;
            Row["Value"] = Value;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            Row["IncentiveId"] = IncentiveId;

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected DataTable PowerDt()
    {
        dtPower1 = new DataTable("Power2");

        dtPower1.Columns.Add("new", typeof(string));
        dtPower1.Columns.Add("FinancialYearId", typeof(string));
        dtPower1.Columns.Add("FinancialYear", typeof(string));
        dtPower1.Columns.Add("UnitsConsumed", typeof(string));
        dtPower1.Columns.Add("AmountPaid", typeof(string));
        dtPower1.Columns.Add("Value", typeof(string));
        dtPower1.Columns.Add("Created_by", typeof(string));
        dtPower1.Columns.Add("IncentiveId", typeof(string));

        dtPower1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtPower1;
    }

    private void AddDataToTableEnergy(string FinancialYearId, string FinancialYear, string frstUnitsConsumed, string frstAmountPaid, string secondUnitsConsumed, string secondAmountPaid, string IncentiveId, string Fin1stOr2ndHalfYear, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtEnergy2 = new DataTable("Energy2");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["1stUnitsConsumed"] = frstUnitsConsumed;
            Row["1stAmountPaid"] = frstAmountPaid;
            Row["2ndUnitsConsumed"] = secondUnitsConsumed;
            Row["2ndAmountPaid"] = secondAmountPaid;
            Row["Created_by"] = Session["uid"].ToString().Trim();
            Row["IncentiveId"] = IncentiveId;
            Row["Fin1stOr2ndHalfYear"] = Fin1stOr2ndHalfYear;

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected DataTable EnergyDt()
    {
        dtPower1 = new DataTable("Energy");

        dtPower1.Columns.Add("new", typeof(string));
        dtPower1.Columns.Add("FinancialYearId", typeof(string));
        dtPower1.Columns.Add("FinancialYear", typeof(string));
        dtPower1.Columns.Add("1stUnitsConsumed", typeof(string));
        dtPower1.Columns.Add("1stAmountPaid", typeof(string));
        dtPower1.Columns.Add("2ndUnitsConsumed", typeof(string));
        dtPower1.Columns.Add("2ndAmountPaid", typeof(string));
        dtPower1.Columns.Add("Created_by", typeof(string));
        dtPower1.Columns.Add("IncentiveId", typeof(string));
        dtPower1.Columns.Add("Fin1stOr2ndHalfYear", typeof(string));



        dtPower1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtPower1;
    }
    protected void btnPowerAdd_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            if (ddlFinYearPower.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                Failure.Visible = true;
                ddlFinYearPower.Focus();
                valid = 1;
            }
            if (txtvalue.Text == "" || txtvalue.Text == null)
            {
                lblmsg0.Text = "Please Enter Value (in Rs.)" + "<br/>";
                Failure.Visible = true;
                txtvalue.Focus();
                valid = 1;
            }
            if (txtAmountPaid.Text == "" || txtAmountPaid.Text == null)
            {
                lblmsg0.Text = "Amount Paid (in Rs) Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtAmountPaid.Focus();
                valid = 1;
            }
            string strunit = "";

            if (ddlquantityin.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Unit Of Measurments" + "<br/>";
                Failure.Visible = true;
                ddlquantityin.Focus();
                valid = 1;
            }
            else
            {
                strunit = ddlquantityin.SelectedItem.Text;
            }
            if (ddlquantityin.SelectedItem.Text == "Others")
            {
                if (txtUnitsConsumed.Text == "" || txtUnitsConsumed.Text == null)
                {
                    lblmsg0.Text = "Unit Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtUnitsConsumed.Focus();
                    valid = 1;
                }
                else
                {
                    strunit = txtUnitsConsumed.Text;
                }
            }
            //sowjanya
            //DataSet dss = new DataSet();
            //if (Convert.ToString(Session["uid"]) != "48696")
            //{
            //    dss = getappliedlistProduction();
            //    if (dss.Tables[0].Rows.Count > 0)
            //    {
            //        lblmsg0.Text = "You have already applied for financial year " + ddlFinYearPower.SelectedItem.Text + ".";
            //        Failure.Visible = true;
            //        valid = 1;
            //        return;
            //    }
            //}
            //sowjanya
            if (valid == 0)
            {
                AddDataToTablePower(ddlFinYearPower.SelectedValue, ddlFinYearPower.SelectedItem.Text, strunit, txtAmountPaid.Text, txtvalue.Text, "", (DataTable)Session["Power"]);

                this.gvpower.DataSource = ((DataTable)Session["Power"]).DefaultView;
                this.gvpower.DataBind();
                ddlFinYearPower.SelectedValue = "--Select--";
                txtUnitsConsumed.Text = "";
                txtAmountPaid.Text = "";
                txtvalue.Text = "";

                gvpower.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    public DataSet getappliedlistProduction()
    {
        DataSet ds = new DataSet();

        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("USP_GET_FINANCIALYEARS_ProductionApplied", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinYearPower.SelectedValue;
        da.SelectCommand.Parameters.Add("@fstorsecndhalf", SqlDbType.VarChar).Value = "0";

        da.Fill(ds);
        con.CloseConnection();

        return ds;
    }
    public DataSet getappliedlistSalesTax()
    {
        DataSet ds = new DataSet();

        con.OpenConnection();
        SqlDataAdapter da = new SqlDataAdapter("USP_GET_FINANCIALYEARS_SalesTaxApplied", con.GetConnection);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.Add("@created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
        da.SelectCommand.Parameters.Add("@finyear", SqlDbType.VarChar).Value = ddlFinYearEnergy.SelectedValue;
        da.SelectCommand.Parameters.Add("@fstorsecndhalf", SqlDbType.VarChar).Value = ddlFin1stOr2ndHalfyear.SelectedValue;

        da.Fill(ds);
        con.CloseConnection();

        return ds;
    }
    protected void gvpower_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvpower_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["Power"] != null)
            {
                dt = (DataTable)Session["Power"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["Power"]).Rows.RemoveAt(e.RowIndex);

                    this.gvpower.DataSource = ((DataTable)Session["Power"]).DefaultView;
                    this.gvpower.DataBind();
                }
                else
                {
                    this.gvpower.DataSource = null;
                    this.gvpower.DataBind();
                }
            }
            else
            {
                this.gvpower.DataSource = null;
                this.gvpower.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnEnergyAdd_Click(object sender, EventArgs e)
    {
        int valid = 0;

        try
        {
            if (ddlFinYearEnergy.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFinYearEnergy.Focus();
                valid = 1;
            }
            if (ddlFin1stOr2ndHalfyear.SelectedItem.Text == "--Select--")
            {
                lblmsg0.Text = "Please Select 1st or 2nd Half Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFin1stOr2ndHalfyear.Focus();
                valid = 1;
            }
            if (trFin1stHalfYear.Visible == true)
            {
                if (ddlFin1stOr2ndHalfyear.SelectedItem.Text == "--Select--")
                {
                    lblmsg0.Text = "Please Select 1st or 2nd Half of Financial Year" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    ddlFin1stOr2ndHalfyear.Focus();
                    valid = 1;
                }
                if (txt1stHalfAmountPaid.Text == "" || txt1stHalfAmountPaid.Text == null)
                {
                    lblmsg0.Text = "1st Half Year Amount Paid (in Rs) Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt1stHalfAmountPaid.Focus();
                    valid = 1;
                }
            }
            if (trFin2ndHalfYear.Visible == true)
            {
                //if (txt1stHalfUnitConsumed.Text == "" || txt1stHalfUnitConsumed.Text == null)
                //{
                //    lblmsg0.Text = "1st Half Year Units Consumed Cannot be blank" + "<br/>";
                //    Failure.Visible = true;
                //    btnEnergyAdd.Focus();
                //    txt1stHalfUnitConsumed.Focus();
                //    valid = 1;
                //}
                if (txt2ndHalfAmountPaid.Text == "" || txt2ndHalfAmountPaid.Text == null)
                {
                    lblmsg0.Text = "2nd Half Year Amount Paid (in Rs) Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt2ndHalfAmountPaid.Focus();
                    valid = 1;
                }
                if (txt2ndHalfUnitConsumed.Text == "" || txt2ndHalfUnitConsumed.Text == null)
                {
                    lblmsg0.Text = "2nd Half Year Units Consumed Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    btnEnergyAdd.Focus();
                    txt2ndHalfUnitConsumed.Focus();
                    valid = 1;
                }
            }
            //sowjanya
            DataSet dss = new DataSet();
            if (Convert.ToString(Session["uid"]) != "48696" && Convert.ToString(Session["uid"]) != "332781" && Convert.ToString(Session["uid"]) != "60480")
            {
                dss = getappliedlistSalesTax();
                if (dss.Tables[0].Rows.Count > 0)
                {
                    lblmsg0.Text = "You have already applied for financial year" + ddlFinYearEnergy.SelectedItem.Text + "for the " + ddlFin1stOr2ndHalfyear.SelectedItem.Text + " Half.";
                    Failure.Visible = true;
                    valid = 1;
                    return;
                }
            }
            //sowjanya
            if (valid == 0)
            {
                if (trFin1stHalfYear.Visible == true && trFin2ndHalfYear.Visible == false)
                {
                    txt2ndHalfUnitConsumed.Text = "0";
                    txt2ndHalfAmountPaid.Text = "0";
                }
                else if (trFin2ndHalfYear.Visible == true && trFin1stHalfYear.Visible == false)
                {
                    txt1stHalfUnitConsumed.Text = "0";
                    txt1stHalfAmountPaid.Text = "0";
                }
                AddDataToTableEnergy(ddlFinYearEnergy.SelectedValue, ddlFinYearEnergy.SelectedItem.Text, txt1stHalfUnitConsumed.Text, txt1stHalfAmountPaid.Text, txt2ndHalfUnitConsumed.Text, txt2ndHalfAmountPaid.Text, "", ddlFin1stOr2ndHalfyear.SelectedValue, (DataTable)Session["Energy"]);

                this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                this.gvEnergy.DataBind();

                ddlFinYearEnergy.SelectedValue = "--Select--";
                txt1stHalfAmountPaid.Text = "";
                txt1stHalfUnitConsumed.Text = "";
                txt2ndHalfAmountPaid.Text = "";
                txt2ndHalfUnitConsumed.Text = "";

                gvEnergy.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;
            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    protected void gvEnergy_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvEnergy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (Session["Energy"] != null)
            {
                dt = (DataTable)Session["Energy"];
                if (dt.Rows.Count > 0)
                {
                    ((DataTable)Session["Energy"]).Rows.RemoveAt(e.RowIndex);

                    this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                    this.gvEnergy.DataBind();
                }
                else
                {
                    this.gvEnergy.DataSource = null;
                    this.gvEnergy.DataBind();
                }
            }
            else
            {
                this.gvEnergy.DataSource = null;
                this.gvEnergy.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int start = 0;
        int valid = 0;
        int out2 = 0;
        try
        {
            //if (gvpower.Visible == false)
            //{
            //    //string message = "alert('Checkslips Uploaded Successfully')";
            //    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Previous 3 years Sales tax Details and click on Add button');", true);
            //    return;
            //}
            //if (gvEnergy.rows == false)
            if (gvEnergy.Rows.Count <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Sales tax Details and click on Add button');", true);
                return;
            }
            if (HyperLink1.Text == "" || HyperLink1.Text == null)
            {
                lblmsg0.Text = "Please Uppload the documents";
                Failure.Visible = true;
                Button1.Focus();
                start = 1;
            }
            if (HyperLink2.Text == "" || HyperLink2.Text == null)
            {
                lblmsg0.Text = "Please Uppload the documents";
                Failure.Visible = true;
                Button2.Focus();
                start = 1;
            }
            if (hdnMSMEApplied.Value == "Y")
            {
                if (gvAvailed.Rows.Count == 0)
                {
                    lblmsg0.Text = "Please Add amount availed from the date of commencement of production";
                    Failure.Visible = true;
                    Button2.Focus();
                    start = 1;
                }

                if (trMSME1.Visible == true && hplGST3B.Text.Trim() == "")
                {
                    lblmsg0.Text = "Please upload Form GSTR-3B returns for the claim period";
                    Failure.Visible = true;
                    Button2.Focus();
                    start = 1;
                }
            }
            if (start == 0)
            {
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();

                valid = SavePower();
                //if (valid == 1)
                //{
                out2 = SaveEnergy();
                // }

                UpdateAnnexureflag(IncentiveId, "5", "Y", "");

                if (out2 == 1)
                {
                    //lblmsg.Text = "Submitted Successfully";
                    //success.Visible = true;

                    string message = "alert('Sales Tax Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BtnSave1.Enabled = false;
                    BtnDelete.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GetNewPowertoInsertdr()
    {
        myDtNewPowerdr = (DataTable)Session["Power"];
        DataView dvdr = new DataView(myDtNewPowerdr);
        myDtNewPowerdr = dvdr.ToTable();
    }
    protected void GetNewEnergytoInsertdr()
    {
        myDtNewEnergydr = (DataTable)Session["Energy"];
        DataView dvdr = new DataView(myDtNewEnergydr);
        myDtNewEnergydr = dvdr.ToTable();
    }
    private int SavePower()
    {
        int value = 0;

        try
        {
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();

            if (((DataTable)Session["Power"]).Rows.Count > 0)
            {
                GetNewPowertoInsertdr();
                value = Gen.bulkInsertPowerForm5(myDtNewPowerdr, IncentiveId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }
    private int SaveEnergy()
    {
        int value = 0;
        try
        {
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();

            if (((DataTable)Session["Energy"]).Rows.Count > 0)
            {
                GetNewEnergytoInsertdr();
                value = Gen.bulkInsertEnergyForm5(myDtNewEnergydr, IncentiveId);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }

    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantityin.SelectedValue.ToString() == "Others")
        {
            txtUnitsConsumed.Visible = true;
            ddlquantityin.Visible = true;
        }
        else
        {
            txtUnitsConsumed.Visible = false;
            ddlquantityin.Visible = true;
        }

    }
    protected void btnPowerClear_Click(object sender, EventArgs e)
    {
        ddlFinYearPower.SelectedValue = "--Select--";
        txtUnitsConsumed.Text = "";
        txtUnitsConsumed.Visible = false;
        ddlquantityin.SelectedValue = "--Select--";
        ddlquantityin.Visible = true;
        txtAmountPaid.Text = "";
        txtvalue.Text = "";

    }
    protected void btnEnergyClear_Click(object sender, EventArgs e)
    {
        ddlFinYearEnergy.SelectedValue = "--Select--";
        txt1stHalfAmountPaid.Text = "";
        txt1stHalfUnitConsumed.Text = "";
        txt2ndHalfAmountPaid.Text = "";
        txt2ndHalfUnitConsumed.Text = "";
    }
    protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = false;
        }
        else if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
        {
            trFin1stHalfYear.Visible = false;
            trFin2ndHalfYear.Visible = true;
        }
        else
        {
            trFin1stHalfYear.Visible = true;
            trFin2ndHalfYear.Visible = true;
        }

    }

    public int UpdateAnnexureflag(string EnterperIncentiveID, string MstIncentiveId, string flag, string output)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "USP_UPD_ANNEXUREFLA_INCENTIVE";

        if (EnterperIncentiveID == "" || EnterperIncentiveID == null)
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@EnterperIncentiveID", SqlDbType.VarChar).Value = EnterperIncentiveID.Trim();

        if (MstIncentiveId == "" || MstIncentiveId == null)
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId.Trim();

        if (flag == "" || flag == null)
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@FILEDFLAG", SqlDbType.VarChar).Value = flag.Trim();

        if (output == "" || output == null)
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@OUTPUT", SqlDbType.VarChar).Value = output.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }

    public void ResetFormControl(Control parent)
    {
        try
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    ResetFormControl(c);
                }
                else
                {
                    switch (c.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).ReadOnly = true;
                            break;

                        case "System.Web.UI.WebControls.DropDownList":

                            if (((DropDownList)c).Items.Count > 0)
                            {
                                ((DropDownList)c).Enabled = false;
                            }
                            break;
                        case "System.Web.UI.WebControls.FileUpload":
                            ((FileUpload)c).Enabled = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButtonList":
                            ((RadioButtonList)c).Enabled = false;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    //sowjanya on 05/05/2026
    protected void btnGST3B_Click(object sender, EventArgs e)
    {
        success.Visible = false;
        Failure.Visible = false;

        string newPath = "";
        General t1 = new General();
        if (fupGST3B.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupGST3B.PostedFile != null) && (fupGST3B.PostedFile.ContentLength > 0))
            {

                string sFileName = System.IO.Path.GetFileName(fupGST3B.PostedFile.FileName);
                try
                {

                    string[] fileType = fupGST3B.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\5\\906";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupGST3B.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "906", sFileName, serverpath, CrtdUser);

                        hplGST3B.Text = sFileName;

                        Failure.Visible = false;

                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

    }

    protected void btnAddAvailed_Click(object sender, EventArgs e)
    {
        int valid = 0;
        try
        {
            string Errormsg = "";
            if (ddlFinYear_availed.SelectedItem.Text == "--Select--")
            {
                Errormsg = "Please Select Financial Year" + "<br/>";
                valid = 1;
            }
            if (ddlHalfYear_availed.SelectedItem.Text == "--Select--")
            {
                Errormsg = Errormsg + "\\n Please Select 1st or 2nd Half of Financial Year" + "<br/>";
                valid = 1;
            }
            if (trMSME3FirstHalf.Visible == true && (txtFistHalf_availed.Text.Trim() == "" || txtFistHalf_availed.Text == null))
            {
                Errormsg = Errormsg + "\\n 1st Half Year Amount Availed (in Rs) Cannot be blank" + "<br/>";
                valid = 1;
            }
            if (trMSME4SecondHalf.Visible == true && (txtSecondHalf_availed.Text.Trim() == "" || txtSecondHalf_availed.Text == null))
            {
                lblmsg0.Text = "2nd Half Year Amount Paid (in Rs) Cannot be blank" + "<br/>";
                valid = 1;
            }


            if (valid == 0)
            {
                if (trMSME3FirstHalf.Visible == true && trMSME4SecondHalf.Visible == false)
                {
                    txtSecondHalf_availed.Text = "0";
                }
                else if (trMSME4SecondHalf.Visible == true && trMSME3FirstHalf.Visible == false)
                {
                    txtFistHalf_availed.Text = "0";
                }
                AddDataToTableAvailed(ddlFinYear_availed.SelectedValue, ddlFinYear_availed.SelectedItem.Text, ddlHalfYear_availed.Text,
                    ddlHalfYear_availed.SelectedItem.Text, txtFistHalf_availed.Text, txtSecondHalf_availed.Text, (DataTable)Session["Availed"]);

                this.gvAvailed.DataSource = ((DataTable)ViewState["Availed"]).DefaultView;
                this.gvAvailed.DataBind();

                ddlFinYear_availed.ClearSelection();
                ddlHalfYear_availed.ClearSelection();
                txtFistHalf_availed.Text = "";
                txtSecondHalf_availed.Text = "";
                trMSME3FirstHalf.Visible= false;
                trMSME4SecondHalf.Visible = false;
                gvAvailed.Visible = true;
                lblmsg0.Text = "";
                Failure.Visible = false;
            }
            else
            {
                string message = "alert('Please enter all values')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            }
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }

    protected void btnClearAvailed_Click(object sender, EventArgs e)
    {

    }



    protected void ddlHalfYear_availed_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHalfYear_availed.SelectedValue == "1")
        {
            trMSME3FirstHalf.Visible = true;
            trMSME4SecondHalf.Visible = false; txtSecondHalf_availed.Text = "";
        }
        else if (ddlHalfYear_availed.SelectedValue == "2")
        {
            trMSME3FirstHalf.Visible = false; txtFistHalf_availed.Text = "";
            trMSME4SecondHalf.Visible = true;
        }
        else
        {
            trMSME3FirstHalf.Visible = false;
            trMSME4SecondHalf.Visible = false;
        }

    }
    private void AddDataToTableAvailed(string FinancialYearId, string FinancialYear, string HalfYearID, string HalfYear,
        string FirstHalfAvailed, string SecondHalfAvailed, DataTable myTable)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FinancialYearId", typeof(string));
            dt.Columns.Add("FinancialYear", typeof(string));
            dt.Columns.Add("HalfYearId", typeof(string));
            dt.Columns.Add("HalfYear", typeof(string));
            dt.Columns.Add("FirstHalfAvailed", typeof(string));
            dt.Columns.Add("SecondHalfAvailed", typeof(string));
            if (ViewState["Availed"] != null)
            {
                dt = (DataTable)ViewState["Availed"];
            }
            DataRow dr = dt.NewRow();
            dr["FinancialYearId"] = FinancialYearId;
            dr["FinancialYear"] = FinancialYear;
            dr["HalfYearId"] = HalfYearID;
            dr["HalfYear"] = HalfYear;
            dr["FirstHalfAvailed"] = FirstHalfAvailed;
            dr["SecondHalfAvailed"] = SecondHalfAvailed;
            dt.Rows.Add(dr);
            gvAvailed.Visible = true;
            gvAvailed.DataSource = dt;
            gvAvailed.DataBind();
            ViewState["Availed"] = dt;
        }
        catch (Exception ee)
        {
            throw ee;
        }
    }
    public void SaveAvailed()
    {

        if (gvAvailed.Rows.Count > 0)
        {
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            con.OpenConnection();

            foreach (GridViewRow row in gvAvailed.Rows)
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_FormV_SalesTax_Availed";
                com.Connection = con.GetConnection;

                Label lblFinYearID = (Label)row.FindControl("lblFinYearID");
                Label lblHalfYearID = (Label)row.FindControl("lblHalfYearID");

                string financialYear = row.Cells[2].Text;
                string halfYear = row.Cells[3].Text;
                string firstHalf = row.Cells[4].Text;
                string secondHalf = row.Cells[5].Text;


                com.Parameters.Add("@IncentiveId", SqlDbType.Int).Value = Convert.ToInt32(IncentiveId);

                com.Parameters.Add("@FinancialYearId", SqlDbType.Int).Value =
                    lblFinYearID != null ? Convert.ToInt32(lblFinYearID.Text) : 0;

                com.Parameters.Add("@FinancialYear", SqlDbType.VarChar).Value =
                    string.IsNullOrEmpty(financialYear) ? (object)DBNull.Value : financialYear;

                com.Parameters.Add("@HalfYearId", SqlDbType.Int).Value =
                    lblHalfYearID != null ? Convert.ToInt32(lblHalfYearID.Text) : 0;

                com.Parameters.Add("@HalfYear", SqlDbType.VarChar).Value =
                    string.IsNullOrEmpty(halfYear) ? (object)DBNull.Value : halfYear;

                com.Parameters.Add("@FirstHalfAvailed", SqlDbType.Decimal).Value =
                    string.IsNullOrEmpty(firstHalf) ? 0 : Convert.ToDecimal(firstHalf);

                com.Parameters.Add("@SecondHalfAvailed", SqlDbType.Decimal).Value =
                    string.IsNullOrEmpty(secondHalf) ? 0 : Convert.ToDecimal(secondHalf);

                com.Parameters.Add("@Created_By", SqlDbType.Int).Value = Session["uid"].ToString();

                // 🔹 OUTPUT parameter
                SqlParameter outputParam = new SqlParameter("@RESULT", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                com.Parameters.Add(outputParam);

                try
                {
                    com.ExecuteNonQuery();

                    int result = Convert.ToInt32(outputParam.Value);
                    // you can check result == 1 success
                }
                catch (Exception ex)
                {
                    throw; // ❗ don't use throw ex;
                }
                finally
                {
                    com.Dispose();
                }
            }

            con.CloseConnection();
        }
    }

    protected void gvAvailed_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            if (gvAvailed.Rows.Count > 0)
            {
                ((DataTable)ViewState["Availed"]).Rows.RemoveAt(e.RowIndex);
                this.gvAvailed.DataSource = ((DataTable)ViewState["Availed"]).DefaultView;
                this.gvAvailed.DataBind();
                gvAvailed.Visible = true;
                gvAvailed.Focus();

            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}