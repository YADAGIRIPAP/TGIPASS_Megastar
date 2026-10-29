using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Reflection.Emit;

public partial class UI_TSiPASS_IncentiveFormIX : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["incentivedata"] != null)
            {

                string IncentveID = Session["EntprIncentive"].ToString();

                DataSet ds = new DataSet();

                ds = Gen.GetIncentivesfrom9data(IncentveID);
                Filldata(ds);

                
                DataSet dsnew = new DataSet();
                dsnew = (DataSet)Session["incentivedata"];
                DataRow[] drs = dsnew.Tables[0].Select("IncentiveID = " + 8);  //Reimbursement of cost involved in skill upgradation and training
                if (drs.Length > 0)
                {

                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("IIDFund.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("IncentiveFromVIII.aspx?Previous=" + "P");
                    }
                }


                string userid = Session["uid"].ToString();
                 //string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

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
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XIV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF COST INVOLVED IN SKILL UPGRADATION AND TRAINING UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XIV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVOLVED IN SKILL UPGRADATION AND TRAINING UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XIV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INVOLVED IN SKILL UPGRADATION AND TRAINING UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

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
                        trMSME1.Visible = true;
                        trMSME2.Visible = true;
                        lblMSMEPolicy.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Visible = false;
                    }
                }
            }

            txtDurationoftraining.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtNumberskilledemployees.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtExpenditureincurredfortrainingprogramme.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtAmountclaimedinRs.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

      
           
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnSave1.Enabled = false;
            BtnDelete.Enabled = true;

            txtagencyName.Text = ds.Tables[0].Rows[0]["Nameofthetraininginstitute"].ToString();
            txtNameoftheskilldevelopmentprogramme.Text = ds.Tables[0].Rows[0]["Nameoftheskilldevelopmentprogramme"].ToString();
            txtNumberskilledemployees.Text = ds.Tables[0].Rows[0]["Numberskilledemployees"].ToString();
            txtExpenditureincurredfortrainingprogramme.Text = ds.Tables[0].Rows[0]["Expenditureincurredtrainingprogramme"].ToString();
            txtAmountclaimedinRs.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
            txtDurationoftraining.Text = ds.Tables[0].Rows[0]["Durationoftraining"].ToString();
            ddlTrainingDurationMode.SelectedValue = ds.Tables[0].Rows[0]["DurationModeoftraining"].ToString();
        }
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
        {
            DataTable table = ds.Tables[1];
            string sen, sen1, sen2;

            foreach (DataRow dr in table.Rows)
            {
                string AttcahmentId = dr["AttachmentId"].ToString();
                sen2 = dr["link"].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                if (AttcahmentId == "9018")
                {
                    Label453.NavigateUrl = sen;
                    Label453.Text = dr["FileNm"].ToString();
                    Label454.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "9019")
                {
                    HyperLink1.NavigateUrl = sen;
                    HyperLink1.Text = dr["FileNm"].ToString();
                    Label8.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "9020")
                {
                    HyperLink3.NavigateUrl = sen;
                    HyperLink3.Text = dr["FileNm"].ToString();
                    Label14.Text = dr["FileNm"].ToString();
                }

                if (AttcahmentId == "9050")
                {
                    HyperLink4.NavigateUrl = sen;
                    HyperLink4.Text = dr["FileNm"].ToString();
                    Label4.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "908")
                {
                    hplProforma.NavigateUrl = sen;
                    lblProforma.Text = dr["FileNm"].ToString();
                }
                if (AttcahmentId == "909")
                {
                    hplEmpProof.NavigateUrl = sen;
                    hplEmpProof.Text = dr["FileNm"].ToString();
                }
            }
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (hdnMSMEApplied.Value == "Y" && (hplEmpProof.Text.Trim() == "" || hplProforma.Text.Trim() == ""))
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload both Proforma and Local Employee proof study certificate or Residence certificate (as per MSME policy )";
            return;
        }
        if (Label453.Text.Trim() == "" || HyperLink1.Text.Trim() == "" || HyperLink3.Text.Trim() == "" || HyperLink4.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            return;
        }
        else
        {
            formIXVo formvoobj = new formIXVo();
            // formvoobj.Enterpid = "1111";
            // formvoobj.Quessionaireid = "1222";
            if (Request.QueryString[0] != null)
            {
                formvoobj.Incentiveid = Session["EntprIncentive"].ToString();

                formvoobj.Nameofthetraininginstitute = txtagencyName.Text.Trim().TrimStart();
                formvoobj.Nameoftheskilldevelopmentprogramme = txtNameoftheskilldevelopmentprogramme.Text.Trim().TrimStart();
                formvoobj.Numberskilledemployees = txtNumberskilledemployees.Text.Trim().TrimStart();
                formvoobj.Expenditureincurredtrainingprogramme = txtExpenditureincurredfortrainingprogramme.Text.Trim().TrimStart();
                formvoobj.Amountclaimed = txtAmountclaimedinRs.Text.Trim().TrimStart();
                formvoobj.Durationoftraining = txtDurationoftraining.Text.Trim();
                formvoobj.DurationModeoftraining = ddlTrainingDurationMode.SelectedValue;


                formvoobj.Created_By = Session["uid"].ToString().Trim();

                int VALID = Gen.InsertFormIXvalues(formvoobj);
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "8", "Y", "");
                if (VALID == 1)
                {
                    //success.Visible = true;
                    //lblmsg.Text = "Data Saved Sucessfully";

                    string message = "alert('Skill Upgradation Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnSave1.Enabled = false;
                    BtnDelete.Enabled = true;

                }
            }
        }
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncentiveFromVIII.aspx?Previous=" + "P");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (hdnMSMEApplied.Value == "Y" && (hplEmpProof.Text.Trim() == "" || hplProforma.Text.Trim() == ""))
        {

            Failure.Visible = true;
            lblmsg0.Text = "Please upload both Proforma and Local Employee proof study certificate or Residence certificate" +
                "(as per MSME policy )";
            return;

        }
        if (Label453.Text.Trim() == "" || HyperLink1.Text.Trim() == "" || HyperLink3.Text.Trim() == "" || HyperLink4.Text.Trim() == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            return;
        }
        else
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "8", "Y", "");

            Response.Redirect("IIDFund.aspx?next=" + "N");
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9018");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9018");  // incentiveid2
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\9018";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9018", sFileName, serverpath, CrtdUser);
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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9019");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9019");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\9019";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload11.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9019", sFileName, serverpath, CrtdUser);
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
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9020");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9020");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\9020";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload13.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9020", sFileName, serverpath, CrtdUser);
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
    protected void Button12_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (FileUpload14.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((FileUpload14.PostedFile != null) && (FileUpload14.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload14.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload14.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9050");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9050");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\9050";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload14.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "9050", sFileName, serverpath, CrtdUser);
                        HyperLink4.Text = FileUpload14.FileName;
                        Label4.Text = sFileName;
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
    //added for msme on 04/05/2026
    protected void btnProforma_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (fupProforma.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupProforma.PostedFile != null) && (fupProforma.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupProforma.PostedFile.FileName);
                try
                {
                    string[] fileType = fupProforma.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9020");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9020");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\908";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupProforma.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "908", sFileName, serverpath, CrtdUser);
                        hplProforma.Text = fupProforma.FileName;
                        lblProforma.Text = sFileName;
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

    protected void btnEmpProof_Click(object sender, EventArgs e)
    {
        string newPath = "";

        General t1 = new General();
        if (fupEmpProof.HasFile)
        {
            string incentiveid = Session["EntprIncentive"].ToString();

            if ((fupEmpProof.PostedFile != null) && (fupEmpProof.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupEmpProof.PostedFile.FileName);
                try
                {
                    string[] fileType = fupEmpProof.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\9020");  // incentiveid2
                        //string serverpath = Server.MapPath("~\\IncentivesAttachmentsNew\\" + incentiveid.ToString() + "\\8\\9020");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\8\\909";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        fupEmpProof.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();

                        string Path = serverpath;
                        string FileName = sFileName;


                        t1.InsertIncentiveAttachment(incentiveid, "NA", "909", sFileName, serverpath, CrtdUser);
                        hplEmpProof.Text = fupEmpProof.FileName;
                        hplEmpProof.Text = sFileName;
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
}