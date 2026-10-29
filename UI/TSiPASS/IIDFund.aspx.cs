using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.IO;

public partial class UI_TSiPASS_IncentivesAnnexure_IIDFund : System.Web.UI.Page
{
    comFunctions objCmf = new comFunctions();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (Session["incentivedata"] != null)
            {
                string IncentveID = Session["EntprIncentive"].ToString();
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 7);  //Industrial Infrastructure Development Fund(IIDF)
                if (drs.Length > 0)
                {

                    DataSet dsnew = new DataSet();
                    dsnew = Gen.GetIncentivesIIDFunddata(IncentveID);
                    Filldata(dsnew);
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("AdvanceSubsidyForSCandST.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("IncentiveFormIX.aspx?Previous=" + "P");
                    }
                }
                string userid = Session["uid"].ToString();
                // string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                string lblscheme = dscaste.Tables[0].Rows[0]["Scheme"].ToString();
                if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TIDEA")
                {
                    lblscheme = "TIDEA, 2014";
                }
                //else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "TFAP")
                //{
                //    lblscheme.Text = "TFAP, 2022";
                //}
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2005-10")
                {
                    lblscheme = "IIPP Scheme 2005 - 2010";
                }
                else if (dscaste.Tables[0].Rows[0]["Scheme"].ToString() == "IIPP SCHEME 2010-15")
                {
                    lblscheme = "IIPP Scheme 2010 - 2015";
                }

                string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();


                if (lblscheme == "TIDEA, 2014")
                {
                    //  if (caste == "3" || caste == "4")   //SC, ST
                    if (TSCPflag == "Y" || TSPflag == "Y")
                    {
                        lblheadTPRIDE.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INDUSTRIAL INFRASTRUCTURE DEVELOPMENT FUND (IIDF) UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INDUSTRIAL INFRASTRUCTURE DEVELOPMENT FUND (IIDF) UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XV" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF INDUSTRIAL INFRASTRUCTURE DEVELOPMENT FUND (IIDF) UNDER " + lblscheme + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }

                DataSet dsdisable = Gen.GETINCENTIVESCAFDATA(userid, IncentveID);
                if (dsdisable.Tables.Count > 0)
                {
                    if (dsdisable.Tables[6].Rows.Count > 0)
                    {
                        hdnMSMEApplied.Value = dsdisable.Tables[6].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
                        if (hdnMSMEApplied.Value == "Y")
                        {
                            trMSME1.Visible = true;
                            trMSME2.Visible = true;
                            trMSME3.Visible = true;
                            lblMSMEPolicy.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Visible = false;
                        }
                    }
                }
            }
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            BtnSave.Enabled = false;
            BtnNext.Enabled = true;

            txtUnitLocatedinIndustArea.SelectedValue = ds.Tables[0].Rows[0]["UnitLocatedinIndustArea"].ToString();
            txtJustLocation.Text = ds.Tables[0].Rows[0]["JustLocation"].ToString();
            txtFinanceSource.Text = ds.Tables[0].Rows[0]["FinanceSource"].ToString();
            txtReqdInfraFacilities.Text = ds.Tables[0].Rows[0]["ReqdInfraFacilities"].ToString();
            txtProposedInfraCritical.Text = ds.Tables[0].Rows[0]["ProposedInfraCritical"].ToString();

            txtEstimatesInfra.Text = ds.Tables[0].Rows[0]["EstimatesInfra"].ToString();
            txtCAName.Text = ds.Tables[0].Rows[0]["CAName"].ToString();
            txtProjDuration.Text = ds.Tables[0].Rows[0]["ProjDuration"].ToString();
            txtMaintanCostAnnum.Text = ds.Tables[0].Rows[0]["MaintanCostAnnum"].ToString();
            txtAmtClaimed.Text = ds.Tables[0].Rows[0]["AmtClaimed"].ToString();

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = ds.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    if (sen.Contains("19"))                    //if (sen.Contains("66"))
                    {
                        //lblUpload1.NavigateUrl = sen;
                        lblUpload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("910"))
                    {
                        hplEntrDeclaration.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplEntrDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblEntrDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                    if (sen.Contains("911"))
                    {
                        hplDeptDeclaration.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplDeptDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblDeptDeclaration.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                    if (sen.Contains("912"))
                    {
                        hplInfraEstimates.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        hplInfraEstimates.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblInfraEstimates.Text = ds.Tables[1].Rows[i][1].ToString();
                    }
                    i++;
                }
            }

            txtUnitLocatedinIndustArea.Enabled = false;
            txtJustLocation.Enabled = false;
            txtFinanceSource.Enabled = false;
            txtReqdInfraFacilities.Enabled = false;
            txtProposedInfraCritical.Enabled = false;

            txtEstimatesInfra.Enabled = false;
            txtCAName.Enabled = false;
            txtProjDuration.Enabled = false;
            txtMaintanCostAnnum.Enabled = false;
            txtAmtClaimed.Enabled = false;

        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Failure.Visible = success.Visible = false;
            bool isValid;
            if (hdnMSMEApplied.Value == "Y")
            {
                if (hplEntrDeclaration.Text == "" || hplDeptDeclaration.Text == "" || hplInfraEstimates.Text == "")
                {
                  
                    Failure.Visible = true;
                    lblmsg0.Text = "Please upload Mandatory Document(s).";
                    return;
                }
            }
            if (lblAttachedFileName1.Text != "")
            {
                isValid = false;
                //Failure.Visible = true;
                //lblmsg0.Text = "Please upload Mandatory Document(s).";
                //trEnclosures = System.Drawing.Color.Pink;
                if (save())
                {
                    //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                    //success.Visible = true;
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                    UpdateAnnexureflag(IncentiveId, "7", "Y", "");
                    string message = "alert('Industrial Infrastructure Development Fund Reimbursement Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BtnSave.Enabled = false;
                    BtnNext.Enabled = true;
                    //  BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
            }
        }
        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg0.Text = ex.Message;
        }
    }
    public bool save()
    {
        try
        {
            AssignValuestoVosFromcontrols();

            string valid = Gen.InsertIncentIIDF(objvoA);

            if (valid == "Y")
            {
                lblmsg.Text = "Submitted Successfully";
                success.Visible = true;

            }

        }
        catch (Exception ex)
        {

            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        return true;
    }
    public void AssignValuestoVosFromcontrols()
    {
        try
        {
            objvoA.UnitLocatedinIndustArea = txtUnitLocatedinIndustArea.SelectedItem.Text;
            objvoA.JustLocation = txtJustLocation.Text;
            objvoA.FinanceSource = txtFinanceSource.Text;
            objvoA.ReqdInfraFacilities = txtReqdInfraFacilities.Text;
            objvoA.ProposedInfraCritical = txtProposedInfraCritical.Text;
            objvoA.EstimatesInfra = txtEstimatesInfra.Text;
            objvoA.CAName = txtCAName.Text;
            objvoA.ProjDuration = txtProjDuration.Text;
            //objvoA.MeasuresProposed = txtMeasuresProposed.Text;
            objvoA.MaintanCostAnnum = txtMaintanCostAnnum.Text;
            objvoA.AmtClaimed = txtAmtClaimed.Text;


            objvoA.IncentveID = Session["EntprIncentive"].ToString();
            objvoA.Created_by = Session["uid"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        try
        {

            Response.Redirect("IncentiveFormIX.aspx?Previous=" + "P");

        }
        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg0.Text = ex.Message;
        }
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblAttachedFileName1.Text != "")
            {
                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                UpdateAnnexureflag(IncentiveId, "7", "Y", "");

                Response.Redirect("AdvanceSubsidyForSCandST.aspx?next=" + "N");
            }
            else
            {
              
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
            }
        }
        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg0.Text = ex.Message;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            success.Visible = true;
            lblmsg0.Text = ex.Message;
        }
    }
    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fuDocuments1.HasFile)
        {
            if ((fuDocuments1.PostedFile != null) && (fuDocuments1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fuDocuments1.PostedFile.FileName);
                try
                {
                    string[] fileType = fuDocuments1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\66");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\7\\19");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fuDocuments1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                            //66,
                                                      19,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName1.Text = fuDocuments1.FileName;
                        lblAttachedFileName1.Visible = true;
                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    public void DeleteFile(string strFileName)
    {
        //Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
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

    //MSME added on 04/05/2026-sowjanya
    protected void btnEntrDeclaration_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fupEntrDeclaration.HasFile)
        {
            if ((fupEntrDeclaration.PostedFile != null) && (fupEntrDeclaration.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupEntrDeclaration.PostedFile.FileName);
                try
                {
                    string[] fileType = fupEntrDeclaration.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\66");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\7\\910");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupEntrDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupEntrDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      //66,
                                                      910,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblEntrDeclaration.Text = fupEntrDeclaration.FileName;
                        lblEntrDeclaration.Visible = true;
                        hplEntrDeclaration.Text = sFileName;
                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void btnDeptDeclaration_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fupDeptDeclaration.HasFile)
        {
            if ((fupDeptDeclaration.PostedFile != null) && (fupDeptDeclaration.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupDeptDeclaration.PostedFile.FileName);
                try
                {
                    string[] fileType = fupDeptDeclaration.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\66");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\7\\911");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupDeptDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupDeptDeclaration.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      //66,
                                                      911,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblDeptDeclaration.Text = fupDeptDeclaration.FileName;
                        lblDeptDeclaration.Visible = true;
                        hplDeptDeclaration.Text = sFileName;
                        //success.Visible = true;
                        //Failure.Visible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }

    }

    protected void btnInfraEstimates_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
        string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
        General t1 = new General();
        if (fupInfraEstimates.HasFile)
        {
            if ((fupInfraEstimates.PostedFile != null) && (fupInfraEstimates.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupInfraEstimates.PostedFile.FileName);
                try
                {
                    string[] fileType = fupInfraEstimates.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\66");
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\7\\912");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fupInfraEstimates.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupInfraEstimates.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                      //66,
                                                      912,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblInfraEstimates.Text = fupInfraEstimates.FileName;
                        lblInfraEstimates.Visible = true;
                        hplInfraEstimates.Text = sFileName;
                        //success.Visible = true;
                        //Failure.Vlblisible = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }
}