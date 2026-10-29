using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class UI_TSiPASS_IPORptStampDutySubsidy : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DataSet ds = new DataSet();

    string IncentiveId = "";
    string MstIncentiveId = "";
    string createdby = "";

    static DataTable dt = new DataTable();

    string casteGenderGmUpdate;
    static DataTable myDtNewPowerdr = new DataTable();
    static DataTable myDtNewEnergydr = new DataTable();

    static DataTable dtPower1;
    static DataTable dtPower2;

    static DataTable dtEnergy1;
    static DataTable dtEnergy2;

    static DataTable dtMyTableCertificate;
    static DataTable dtMyTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        //IncentiveId = "12345";
        //createdby = "5050";
        //MstIncentiveId = "9";
        if (Request.QueryString[0] != null)
        {
            IncentiveId = Request.QueryString[0];
        }
        if (Request.QueryString[0] != null)
        {
            MstIncentiveId = Request.QueryString[1];
        }
        createdby = Session["uid"].ToString();
        if (!IsPostBack)
        {
            try
            {
                Session["Energy"] = null;
                Session["CertificateTb2"] = null;
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
                if (Session["uid"] != null)
                {
                    DataSet dsmst = new DataSet();
                    dsmst = Gen.GETINCENTIVE_MASTERDATA(MstIncentiveId, IncentiveId);
                    if (dsmst != null && dsmst.Tables.Count > 0 && dsmst.Tables[0].Rows.Count > 0)
                    {
                        if (dsmst.Tables[0].Rows[0]["IncentiveName"].ToString() != null)
                        {
                            lblsubsidytype.Text = dsmst.Tables[0].Rows[0]["IncentiveName"].ToString();

                            lblUnitname.Text = dsmst.Tables[1].Rows[0]["UnitName"].ToString();
                            lbldcp.Text = dsmst.Tables[1].Rows[0]["DCPNEW"].ToString();
                        }
                    }

                    if (MstIncentiveId == "14")
                    {
                        TrStampduty1.Visible = true;
                        TrStampduty2.Visible = false;
                        TrStampduty3.Visible = false;
                        TrStampduty4.Visible = false;
                        tdTrStampduty1.InnerText = "2.";
                        tdTrStampduty5.InnerText = "3.";
                        tdTrStampduty6.InnerText = "4.";
                        tdTrStampduty7.InnerText = "5.1";
                        tdTrStampduty8.InnerText = "5.2";
                       
                        txtMortgageDuty.Text = "0";
                        txtLandConversionCharges.Text = "0";
                        txtLandCost.Text = "0";

                    }
                    else if (MstIncentiveId == "15")
                    {
                        TrStampduty1.Visible = false;
                        TrStampduty2.Visible = true;
                        TrStampduty3.Visible = false;
                        TrStampduty4.Visible = false;
                        tdTrStampduty2.InnerText = "2.";
                        tdTrStampduty5.InnerText = "3.";
                        tdTrStampduty6.InnerText = "4.";
                        tdTrStampduty7.InnerText = "5.1";
                        tdTrStampduty8.InnerText = "5.2";

                        txtstampduty.Text = "0";
                        txtLandConversionCharges.Text = "0";
                        txtLandCost.Text = "0";
                    }
                    else if (MstIncentiveId == "16")
                    {
                        TrStampduty1.Visible = false;
                        TrStampduty2.Visible = false;
                        TrStampduty3.Visible = true;
                        TrStampduty4.Visible = false;
                        tdTrStampduty3.InnerText = "2.";
                        tdTrStampduty5.InnerText = "3.";
                        tdTrStampduty6.InnerText = "4.";
                        tdTrStampduty7.InnerText = "5.1";
                        tdTrStampduty8.InnerText = "5.2";

                        txtstampduty.Text = "0";
                        txtMortgageDuty.Text = "0";
                        txtLandCost.Text = "0";
                    }
                    else if (MstIncentiveId == "17")
                    {
                        TrStampduty1.Visible = false;
                        TrStampduty2.Visible = false;
                        TrStampduty3.Visible = false;
                        TrStampduty4.Visible = true;
                        tdTrStampduty4.InnerText = "2.";
                        tdTrStampduty5.InnerText = "3.";
                        tdTrStampduty6.InnerText = "4.";
                        tdTrStampduty7.InnerText = "5.1";
                        tdTrStampduty8.InnerText = "5.2";

                        txtstampduty.Text = "0";
                        txtMortgageDuty.Text = "0";
                        txtLandConversionCharges.Text = "0";
                    }
                    else
                    {
                        TrStampduty1.Visible = true;
                        TrStampduty2.Visible = true;
                        TrStampduty3.Visible = true;
                        TrStampduty4.Visible = true;
                    }

                   

                    trlandexemption.Visible = false;

                    DataSet dsnewre = new DataSet();
                    dsnewre = Gen.GetIncetiveDetailsdeptAttachementsIpo(IncentiveId, MstIncentiveId);
                    if (dsnewre != null && dsnewre.Tables.Count > 0 && dsnewre.Tables[0].Rows.Count > 0)
                    {
                        GridView3att.DataSource = dsnewre.Tables[0];
                        GridView3att.DataBind();
                    }

                    if (!IsPostBack)
                    {
                        BindFinancialYears(ddlFinYearEnergy, "10", IncentiveId);
                    }

                    dtEnergy1 = EnergyDt();
                    if (Session["Energy"] != "" && Session["Energy"] != null)
                    {
                        dtEnergy1 = ((DataTable)Session["Energy"]);
                    }

                    Session["Energy"] = dtEnergy1;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
    }
    protected void GridView3att_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (e.Row.FindControl("lbl") as Label);
            HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
            //CheckBox chkverified = (e.Row.FindControl("chkverified") as CheckBox);
            RadioButtonList rbtverified = (e.Row.FindControl("rbtverified") as RadioButtonList);

            Label lblVerifiednew = (e.Row.FindControl("lblVerified") as Label);

            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
            if (filepathnew != "")
            {
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
            }
            else
            {
                HyperLinkSubsidy.Visible = false;
            }
            //if (lbl.Text == "")
            //{
            //    //e.Row.Cells[1].ColumnSpan = 2;
            //    //e.Row.Cells.RemoveAt(2);
            //    HyperLinkSubsidy.Visible = false;
            //    e.Row.Font.Bold = true;
            //    chkverified.Visible = false;
            //}
            //if (HyperLinkSubsidy.NavigateUrl == "")
            //{
            //    HyperLinkSubsidy.Visible = false;
            //    chkverified.Visible = false;
            //}
            //if (lblVerifiednew.Text == "YES" && chkverified.Visible == true)
            //{

            //    chkverified.Checked = true;
            //    chkverified.Enabled = false;
            //}
            if (lbl.Text == "")
            {
                HyperLinkSubsidy.Visible = false;
                e.Row.Font.Bold = true;
                rbtverified.Visible = false;
            }
            if (HyperLinkSubsidy.NavigateUrl == "")
            {
                HyperLinkSubsidy.Visible = false;
                rbtverified.Visible = false;
            }
            if (lblVerifiednew.Text == "YES" && rbtverified.Visible == true)
            {

                rbtverified.SelectedValue = "Y";
                rbtverified.Enabled = false;
            }
            if (lblVerifiednew.Text == "WRONG" && rbtverified.Visible == true)
            {

                rbtverified.SelectedValue = "N";
                rbtverified.Enabled = false;
            }
        }

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        int rowCount = GridView3att.Rows.Count;
        int rowCountinc = 0;
        lblmsg.Text = "";
        lblmsg0.Text = "";
        int i = 0;
        string valid = "";
        try
        {
            if (ddlexemptionpurchaseofland.SelectedValue == "1")
            {
                if (txtexemptiononland.Text == "" && txtexemptiononland.Text == string.Empty)
                {
                    lblmsg0.Text = "<font color=Red>Please Enter Exemption on purchase of land</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    BtnNext.Enabled = false;
                    i = 1;
                }
            }
            if (txtstampduty.Text == "" && txtstampduty.Text == string.Empty)
            {
                lblmsg0.Text = "<font color=Red>Please Enter Stamp Duty/Transfer Duty</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (txtMortgageDuty.Text == "" && txtMortgageDuty.Text == string.Empty)
            {
                lblmsg0.Text = "<font color=Red>Please Enter Mortgage and Hypothecations Duty</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (txtLandConversionCharges.Text == "" && txtLandConversionCharges.Text == string.Empty)
            {
                lblmsg0.Text = "<font color=Red>Please Enter 25% Land Conversion Charges</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (txtLandCost.Text == "" && txtLandCost.Text == string.Empty)
            {
                lblmsg0.Text = "<font color=Red>Please Enter 25% Land Cost purchase in IE/IDA/IP’s</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (rblDLCSLC.SelectedItem == null)
            {
                lblmsg0.Text = "<font color=Red>Please Select Whether Is Dlc Or Slc</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (txtremarks.Text == "" && txtremarks.Text == string.Empty)
            {
                lblmsg0.Text = "<font color=Red>Please Enter Remarks</font>";
                success.Visible = false;
                Failure.Visible = true;
                BtnNext.Enabled = false;
                i = 1;
            }
            if (i == 0)
            {
                while (rowCountinc < rowCount)  //added newly on 25.02.2020.
                {

                    Label lbltext = (Label)GridView3att.Rows[rowCountinc].FindControl("lbl");
                    string text = lbltext.Text.ToString();
                    //CheckBox chkverified = (CheckBox)GridView3att.Rows[rowCountinc].FindControl("chkverified");
                    RadioButtonList rbtverified = (RadioButtonList)GridView3att.Rows[rowCountinc].FindControl("rbtverified");

                    //if (chkverified.Checked != true && chkverified.Visible == true)
                    if ((rbtverified.SelectedValue == "" || rbtverified.SelectedValue == null || rbtverified.SelectedValue == "") && rbtverified.Visible == true)

                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please verify all the attachments');", true);
                        return;
                    }
                    rowCountinc = rowCountinc + 1;
                }
                if(rdbSector.SelectedIndex==1)
                {
                    valid = Gen.InsertIPORpt_StampDuty(IncentiveId, MstIncentiveId, txtexemptiononland.Text, txtstampduty.Text, txtMortgageDuty.Text, txtLandConversionCharges.Text, txtLandCost.Text, createdby, txtremarks.Text, rblDLCSLC.SelectedValue.ToString(), rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(), "","");
                }
                else if (rdbSector.SelectedIndex == 0)
                {
                    valid = Gen.InsertIPORpt_StampDuty(IncentiveId, MstIncentiveId, txtexemptiononland.Text, txtstampduty.Text, txtMortgageDuty.Text, txtLandConversionCharges.Text, txtLandCost.Text, createdby, txtremarks.Text, rblDLCSLC.SelectedValue.ToString(), rdbCaste.SelectedValue.ToString(), rdbGender.SelectedValue.ToString(), rdbCategory.SelectedValue.ToString(), rdbEnterprise.SelectedValue.ToString(), rdbSector.SelectedValue.ToString(), rdbServiceType.SelectedValue.ToString(), rdbTransportNonTrans.SelectedValue.ToString());
                }
   
                if (valid == "Y")
                {
                    int k = 0;
                    k = SaveEnergy();

                    try
                    {
                        foreach (GridViewRow gvrow in GridView3att.Rows)
                        {
                            string attid = ((Label)gvrow.FindControl("lblatchid")).Text.ToString();
                           // CheckBox chkverified = ((CheckBox)gvrow.FindControl("chkverified"));
                            RadioButtonList rbtverified = ((RadioButtonList)gvrow.FindControl("rbtverified"));

                            //if (chkverified.Visible == true && chkverified.Checked == true && attid != "0" && attid != "")
                            if (rbtverified.Visible == true && (rbtverified.SelectedValue == "Y" || rbtverified.SelectedValue == "N") && attid != "0" && attid != "")

                            {
                                int validss = Gen.UpdateverifyInctveattachment(ViewState["IncentveID"].ToString(), attid, Session["uid"].ToString(), rbtverified.SelectedValue);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                    //success.Visible = true;
                    //Failure.Visible = false;
                    BtnNext.Visible = true;
                    BtnSave1.Visible = false;

                    //string message = "alert('')";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Inspection Report Submitted Sucessfully');", true);
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {
            // Response.Redirect("IPORptStampDutySubsidy.aspx");
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void ddlexemptionpurchaseofland_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlexemptionpurchaseofland.SelectedValue == "1")
            {
                trlandexemption.Visible = true;
            }
            else
            {
                trlandexemption.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        gvCertificate.Visible = true;

        if (Request.QueryString[0] != null)
        {
            IncentiveId = Request.QueryString[0];
        }
        if (Request.QueryString[1] != null)
        {
            MstIncentiveId = Request.QueryString[1];
        }

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            string incentiveid = Request.QueryString[0];

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string fileexte = Path.GetExtension(sFileName);
                string onlyfilename = Path.GetFileNameWithoutExtension(sFileName);
                sFileName = onlyfilename + DateTime.Now.Minute + DateTime.Now.Second + fileexte;
                //return;
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        string serverpath = Server.MapPath("~\\ReportAttachmentforIcentive\\" + incentiveid.ToString() + "\\" + MstIncentiveId);  // incentiveid2
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        // string Path = serverpath;
                        string FileName = sFileName;
                        ViewState["AttachmentName"] = sFileName;
                        ViewState["pathAttachment"] = serverpath;
                        string Attachmentidnew = incentiveid + DateTime.Now.Minute + DateTime.Now.Second;
                        t1.InsertIncentiveAttachmentInspReports(incentiveid, Attachmentidnew, sFileName, serverpath, CrtdUser, MstIncentiveId, "InspReport");
                        string File_Path_Text = System.IO.Path.GetFullPath(FileUpload1.PostedFile.FileName);
                        AddDataToTableCeertificate(sFileName, File_Path_Text, (DataTable)Session["CertificateTb2"]);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        lblmsg.Text = "";

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        success.Visible = true;
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
                    // DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

        gvCertificate.Visible = true;
    }

    private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["FileName"] = Filename;
            Row["filepath"] = filepath;
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("FileName", typeof(string));
        dtMyTable.Columns.Add("filepath", typeof(string));
        return dtMyTable;
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
                lblmsg0.Text = "Please Select 1st or 2nd Half of Financial Year" + "<br/>";
                Failure.Visible = true;
                btnEnergyAdd.Focus();
                ddlFin1stOr2ndHalfyear.Focus();
                valid = 1;
            }

            if (valid == 0)
            {
                createdby = Session["uid"].ToString();
                if (Request.QueryString[0] != null)
                {
                    IncentiveId = Request.QueryString[0];
                }
                if (Request.QueryString[1] != null)
                {
                    MstIncentiveId = Request.QueryString[1];
                }
                AddDataToTableEnergy(ddlFinYearEnergy.SelectedValue, ddlFinYearEnergy.SelectedItem.Text, ddlFin1stOr2ndHalfyear.SelectedValue, IncentiveId, MstIncentiveId, ddlFin1stOr2ndHalfyear.SelectedItem.Text, (DataTable)Session["Energy"]);

                this.gvEnergy.DataSource = ((DataTable)Session["Energy"]).DefaultView;
                this.gvEnergy.DataBind();

                //ddlFinYearEnergy.SelectedValue = "--Select--";
                //ddlFin1stOr2ndHalfyear.SelectedValue = "--Select--";

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

    private void AddDataToTableEnergy(string FinancialYearId, string FinancialYear, string Fin1stOr2ndHalfYear, string incentiveid, string mstincentiveid, string Fin1stOr2ndHalfYearText, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtEnergy2 = new DataTable("Energy2");

            Row["new"] = "0";
            Row["FinancialYearId"] = FinancialYearId;
            Row["FinancialYear"] = FinancialYear;
            Row["Fin1stOr2ndHalfYear"] = Fin1stOr2ndHalfYear;
            Row["incentiveid"] = incentiveid;
            Row["mstincentiveid"] = mstincentiveid;
            Row["Fin1stOr2ndHalfYearText"] = Fin1stOr2ndHalfYearText;

            // Row["Fin1stOr2ndHalfYearText"] = Fin1stOr2ndHalfYear;

            Row["Created_by"] = Session["uid"].ToString().Trim();
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
        dtPower1.Columns.Add("Fin1stOr2ndHalfYear", typeof(string));

        dtPower1.Columns.Add("incentiveid", typeof(string));
        dtPower1.Columns.Add("mstincentiveid", typeof(string));
        dtPower1.Columns.Add("Fin1stOr2ndHalfYearText", typeof(string));
        dtPower1.Columns.Add("Created_by", typeof(string));
        return dtPower1;
    }

    private int SaveEnergy()
    {
        int value = 0;
        try
        {
            PCBClass objPCB = new PCBClass();
            comFunctions cmf = new comFunctions();
            General Gen = new General();

            DataSet ds = new DataSet();
            //ds = (DataSet)Session["incentivedata"];
            //string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            string IncentiveId2 = "";
            if (Request.QueryString[0] != null)
            {
                IncentiveId2 = Request.QueryString[0];
            }
            if (((DataTable)Session["Energy"]).Rows.Count > 0)
            {
                GetNewEnergytoInsertdr();
                value = Gen.bulkInsertEnergyIORpt(myDtNewEnergydr, IncentiveId2);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return value;
    }

    protected void GetNewEnergytoInsertdr()
    {
        myDtNewEnergydr = (DataTable)Session["Energy"];
        DataView dvdr = new DataView(myDtNewEnergydr);
        myDtNewEnergydr = dvdr.ToTable();
    }

    private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
    {
        DataSet dsYears = new DataSet();
        dsYears = Gen.GetFinancialYearIncentives(Count, incentiveid);
        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        {
            ddl.DataSource = dsYears.Tables[0];
            ddl.DataTextField = "FinancialYear";
            ddl.DataValueField = "SlNo";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "--Select--");

    }

    protected void rdbCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCaste.SelectedIndex == 0 || rdbCaste.SelectedIndex == 1 || rdbCaste.SelectedIndex == 2 || rdbCaste.SelectedIndex == 3)
        {
            rdbCaste.Enabled = false;
            rdbGender.Enabled = true;

        }
    }
    protected void rdbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbGender.SelectedIndex == 0 || rdbGender.SelectedIndex == 1)
        {
            rdbGender.Enabled = false;
            rdbCategory.Enabled = true;

        }
    }
    protected void rdbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCategory.SelectedIndex == 0 || rdbCategory.SelectedIndex == 1 || rdbCategory.SelectedIndex == 2 || rdbCategory.SelectedIndex == 3 || rdbCategory.SelectedIndex == 4)
        {
            rdbCategory.Enabled = false;
            rdbEnterprise.Enabled = true;

        }
    }
    protected void rdbEnterprise_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbEnterprise.SelectedIndex == 0 || rdbEnterprise.SelectedIndex == 1)
        {
            rdbEnterprise.Enabled = false;
            rdbSector.Enabled = true;

        }
    }
    protected void rdbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbSector.SelectedIndex == 0 || rdbSector.SelectedIndex == 1)
        {
            rdbSector.Enabled = false;
            if (rdbSector.SelectedIndex != 0)
            {
                casteGenderGmUpdate = "Y";
                ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
            }
            else
            {
                trServiceType.Visible = true;
                rdbServiceType.Enabled = true;
            }

            //trForwardApplicationTo.Visible = true;
            //trForwardGMGrid.Visible = true;
            //trFowardNote.Visible = true;

        }
    }
    protected void rdbTransportNonTrans_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbTransportNonTrans.Enabled = false;
        casteGenderGmUpdate = "Y";
        ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
    }

    protected void rdbServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbServiceType.Enabled = false;
        rdbTransportNonTrans.Enabled = true;
        trTransNonTrans.Visible = true;
        rdbTransportNonTrans.Visible = true;
    }

}