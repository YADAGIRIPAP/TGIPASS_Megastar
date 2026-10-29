using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_IncentiveFromVIII : System.Web.UI.Page
{
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    General Gen = new General();
    static DataTable dtMyTable;
    DB.DB con = new DB.DB();

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;
    List<formVIIIVo> lstformvo = new List<formVIIIVo>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string IncentveID = "";
            if (Session["incentivedata"] != null)
            {

                IncentveID = Session["EntprIncentive"].ToString();
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 4);  // Specific Cleaner Production measures
                if (drs.Length > 0)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = Gen.GetIncentivesfrom8data(IncentveID);
                    Filldata(dsnew);

                }
                else
                {
                    tblmain.Visible = true;
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("IncentiveFormIX.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("SeedCap.aspx?Previous=" + "P");
                    }
                }

                string userid = Session["uid"].ToString();
                // string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                {
                    lblscheme.Text = "TIDEA, 2014";
                }
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                {
                    lblscheme.Text = "TFAP";
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
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF EQUIPMENT PURCHASED FOR CLEANER PRODUCTION MEASURES UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF EQUIPMENT PURCHASED FOR CLEANER PRODUCTION MEASURES UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                
                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XIII" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF EQUIPMENT PURCHASED FOR CLEANER PRODUCTION MEASURES " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }
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
                    }
                }
            }

            txtCostoftheequipment.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtVAtCSTinRs.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtExciseDuty.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtFreight.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtOthercharges.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");



            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnDelete.Enabled = true;
            BtnSave1.Enabled = false;

            gvCertificate.DataSource = ds.Tables[0];
            gvCertificate.DataBind();
            tblmain.Visible = false;
            txtsubsidyclaimed.Text = ds.Tables[0].Rows[0]["subsidyclaimed"].ToString();
        }
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataTable table = ds.Tables[1];
            string sen, sen1, sen2, sennew;

            foreach (DataRow dr in table.Rows)
            {
                string AttcahmentId = dr["AttachmentId"].ToString();
                sen2 = dr["link"].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                sennew = dr["LINKNEW"].ToString(); // LINKNEW
                string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                if (AttcahmentId == "9022")
                {
                    //Label453.NavigateUrl = sen;
                    Label453.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    Label453.Text = dr["FileNm"].ToString();
                    Label454.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "9023")
                {
                   // HyperLink1.NavigateUrl = sen;
                    HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink1.Text = dr["FileNm"].ToString();
                    Label8.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "9024")
                {
                   // HyperLink3.NavigateUrl = sen;
                    HyperLink3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    HyperLink3.Text = dr["FileNm"].ToString();
                    Label14.Text = dr["FileNm"].ToString();
                }
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (gvCertificate.Rows.Count == 0)
        {
            lblmsg0.Text = "<font color=red> Please Enter >Reimbursement of Interest Subsidy Details and Click add new Button </font>";

            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label453.Text == "" || HyperLink1.Text == "" || HyperLink3.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            return;
        }
        lstformvo.Clear();
        foreach (GridViewRow gvrow in gvCertificate.Rows)
        {
            formVIIIVo fromvo = new formVIIIVo();
            int rowIndex = gvrow.RowIndex;

            fromvo.IncentiveID = Session["EntprIncentive"].ToString();
            fromvo.Nameoftheequipment = gvCertificate.Rows[rowIndex].Cells[1].Text;
            fromvo.Nameaddressofsupplier = gvCertificate.Rows[rowIndex].Cells[2].Text;
            fromvo.BillNo = gvCertificate.Rows[rowIndex].Cells[3].Text;
            fromvo.BillDate = gvCertificate.Rows[rowIndex].Cells[4].Text;
            fromvo.Costoftheequipment = gvCertificate.Rows[rowIndex].Cells[5].Text;
            fromvo.VATCST = gvCertificate.Rows[rowIndex].Cells[6].Text;
            fromvo.ExciseDuty = gvCertificate.Rows[rowIndex].Cells[7].Text;
            fromvo.FreightCharge = gvCertificate.Rows[rowIndex].Cells[8].Text;
            fromvo.Othercharges = gvCertificate.Rows[rowIndex].Cells[9].Text;
            fromvo.TotalinRs = gvCertificate.Rows[rowIndex].Cells[10].Text;

            fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
            fromvo.Created_By = Session["uid"].ToString();
            fromvo.subsidyclaimed = txtsubsidyclaimed.Text.Trim();
            lstformvo.Add(fromvo);
        }

        int VALID = Gen.InsertFormVIIIvalues(lstformvo);
        DataSet ds = new DataSet();
        ds = (DataSet)Session["incentivedata"];
        string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();

        UpdateAnnexureflag(IncentiveId, "4", "Y", "");
        if (VALID == 1)
        {
            //success.Visible = true;
            //lblmsg.Text = "Data Saved Sucessfully";
            string message = "alert('Cleaner production Measures Reimbursement Application Submitted Successfully')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            BtnDelete.Enabled = true;
            BtnSave1.Enabled = false;

        }
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("SeedCap.aspx?Previous=" + "P");

    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (Label453.Text == "" || HyperLink1.Text == "" || HyperLink3.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
        }
        else
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "4", "Y", "");

            Response.Redirect("IncentiveFormIX.aspx?next=" + "N");
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            decimal Totalrs = 0;
            if (txtCostoftheequipment.Text.Trim() != "")
            {
                Totalrs = Totalrs + Convert.ToDecimal(txtCostoftheequipment.Text.Trim());
            }
            if (txtVAtCSTinRs.Text.Trim() != "")
            {
                Totalrs = Totalrs + Convert.ToDecimal(txtVAtCSTinRs.Text.Trim());
            }
            if (txtExciseDuty.Text.Trim() != "")
            {
                Totalrs = Totalrs + Convert.ToDecimal(txtExciseDuty.Text.Trim());
            }
            if (txtFreight.Text.Trim() != "")
            {
                Totalrs = Totalrs + Convert.ToDecimal(txtFreight.Text.Trim());
            }
            if (txtOthercharges.Text.Trim() != "")
            {
                Totalrs = Totalrs + Convert.ToDecimal(txtOthercharges.Text.Trim());
            }

            AddDataToTableCeertificate(txtEquipmentName.Text.Trim(), txtSupplierAddress.Text.Trim(), txtbillno.Text.Trim(), txtBillDate.Text.Trim(), txtCostoftheequipment.Text.Trim(), txtVAtCSTinRs.Text.Trim(), txtExciseDuty.Text.Trim(), txtFreight.Text.Trim(), txtOthercharges.Text.Trim(), Totalrs.ToString(), (DataTable)Session["CertificateTb2"]);
            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
            lblmsg.Text = "";
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;
    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {
        }


    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }

    private void AddDataToTableCeertificate(string Nameoftheequipment, string Nameaddressofsupplier, string BillNo, string BillDate, string Costoftheequipment, string VATCST, string ExciseDuty, string FreightCharge, string Othercharges, string TotalinRs, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["Nameoftheequipment"] = Nameoftheequipment;
            Row["Nameaddressofsupplier"] = Nameaddressofsupplier;
            Row["BillNo"] = BillNo;
            Row["BillDate"] = BillDate;

            Row["Costoftheequipment"] = Costoftheequipment;
            Row["VATCST"] = VATCST;
            Row["ExciseDuty"] = ExciseDuty;
            Row["FreightCharge"] = FreightCharge;
            Row["Othercharges"] = Othercharges;
            Row["TotalinRs"] = TotalinRs;
            Row["id"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Nameoftheequipment", typeof(string));
        dtMyTable.Columns.Add("Nameaddressofsupplier", typeof(string));
        dtMyTable.Columns.Add("BillNo", typeof(string));
        dtMyTable.Columns.Add("BillDate", typeof(string));
        dtMyTable.Columns.Add("Costoftheequipment", typeof(string));
        dtMyTable.Columns.Add("VATCST", typeof(string));
        dtMyTable.Columns.Add("ExciseDuty", typeof(string));
        dtMyTable.Columns.Add("FreightCharge", typeof(string));
        dtMyTable.Columns.Add("Othercharges", typeof(string));
        dtMyTable.Columns.Add("TotalinRs", typeof(string));
        dtMyTable.Columns.Add("id", typeof(string));

        return dtMyTable;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload10.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9022");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\4\\9022");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\4\\9022";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9022", sFileName, serverpath, CrtdUser);
                        Label453.Text = FileUpload10.FileName;
                        Label454.Text = sFileName;
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
    public void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload11.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9023");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\4\\9023");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\4\\9023";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload11.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9023", sFileName, serverpath, CrtdUser);
                        HyperLink1.Text = FileUpload11.FileName;
                        Label8.Text = sFileName;
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

    protected void Button11_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload13.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9024");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\4\\9024");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\4\\9024";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload13.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9024", sFileName, serverpath, CrtdUser);
                        HyperLink3.Text = FileUpload13.FileName;
                        Label14.Text = sFileName;
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
}