using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;

public partial class UI_TSiPASS_IncentivesAnnexure_AdvanceSubsidyForSCandST : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["uid"] != null)
            {
                if (Session["incentivedata"] != null)
                {
                    string IncentveID = Session["EntprIncentive"].ToString();
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 12);  //Advance Subsidy before DCP for SC/ST Enterprises
                    if (drs.Length > 0)
                    {
                        if (!IsPostBack)
                        {

                            DataSet dsnew = new DataSet();
                            dsnew = Gen.GetIncentivesAdvSubsidySCST(IncentveID);
                            Filldata(dsnew);
                        }
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                            Response.Redirect("frmIncentiveform_COAL.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("IIDFund.aspx?Previous=" + "P");
                        }
                    }


                    string userid = Session["uid"].ToString();
                    // string IncentveID = Session["EntprIncentive"].ToString();
                    DataSet dscaste = new DataSet();
                    dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();

                    if (dscaste.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y")   //if (caste == "3" || caste == "4")   //SC, ST
                    {
                        lblheadTPRIDE.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XVI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<b><u><center>CLAIMING ADVANCE SUBSIDY UNDER T-PRIDE (TSCP) " + "</center> </u></b>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (dscaste.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")   //if (caste == "3" || caste == "4")   //SC, ST
                    {
                        lblheadTPRIDE.Visible = true;
                        lblheadTIDEA.Visible = false;
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: XVI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<b><u><center>CLAIMING ADVANCE SUBSIDY UNDER T-PRIDE (TSP) " + "</center> </u></b>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: XVI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<b><u><center>CLAIMING ADVANCE SUBSIDY  UNDER T-IDEA " + "</center> </u></b>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT)  INCENTIVE SCHEME 2014s</center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                    //else if (dscaste.Tables[0].Rows[0]["scheme"].ToString() == "TFAP")
                    //{
                    //    lblheadTIDEA.Visible = true;

                    //    lblheadTIDEA.Text = "<center>" + "ANNEXURE: XVI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<b><u><center>CLAIMING ADVANCE SUBSIDY  UNDER TFAP,2022 " + "</center> </u></b>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT)  INCENTIVE SCHEME 2014s</center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    //    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    //    lblheadTPRIDE.Visible = false;
                    //}
                    hdnMSMEApplied.Value = dscaste.Tables[0].Rows[0]["MSME_Applied"].ToString();//Applied under MSME policy
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
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    void Filldata(DataSet ds)
    {
        try
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtTotalEquity.Text = ds.Tables[0].Rows[0]["TotalEquity"].ToString();
                txtOwnCapital.Text = ds.Tables[0].Rows[0]["OwnCapital"].ToString();
                txtBorrowed.Text = ds.Tables[0].Rows[0]["Borrowed"].ToString();
                txtAdvSubClaimed.Text = ds.Tables[0].Rows[0]["AdvSubClaimed"].ToString();
                //for msme
                txtDISCOMApplDate.Text = ds.Tables[0].Rows[0]["DISCOMApplDate1"].ToString();
                txtExpectedDCP.Text = ds.Tables[0].Rows[0]["ExpecctedDCP1"].ToString();
                txtContractedLoad.Text = ds.Tables[0].Rows[0]["ContractedLoad"].ToString();
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
                        if (sen.Contains("53"))                    //if (sen.Contains("80"))
                        {
                            //lblupload1.NavigateUrl = sen;
                            lblupload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                            lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("54"))                    //if (sen.Contains("81"))
                        {
                            //lblupload2.NavigateUrl = sen;
                            lblupload2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblupload2.Text = ds.Tables[1].Rows[i][1].ToString();
                            lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("55"))                    //if (sen.Contains("82"))
                        {
                            //lblupload3.NavigateUrl = sen;
                            lblupload3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblupload3.Text = ds.Tables[1].Rows[i][1].ToString();
                            lblAttachedFileName3.Text = ds.Tables[1].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("4"))                    //if (sen.Contains("83"))
                        {
                            //lblupload4.NavigateUrl = sen;
                            lblupload4.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblupload4.Text = ds.Tables[1].Rows[i][1].ToString();
                            lblAttachedFileName4.Text = ds.Tables[1].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        if (sen.Contains("913"))                    //if (sen.Contains("83"))
                        {
                            //lblupload4.NavigateUrl = sen;
                            hplCommDoc.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hplCommDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                            lblCommDoc.Text = ds.Tables[1].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                        i++;
                    }
                }

                txtTotalEquity.Enabled = false;
                txtOwnCapital.Enabled = false;
                txtBorrowed.Enabled = false;
                txtAdvSubClaimed.Enabled = false;

                BtnSave.Enabled = false;
                BtnNext.Enabled = true;
            }
            else
            {
                txtTotalEquity.Enabled = true;
                txtOwnCapital.Enabled = true;
                txtBorrowed.Enabled = true;
                txtAdvSubClaimed.Enabled = true;

                BtnSave.Enabled = true;
                BtnNext.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "" && lblAttachedFileName3.Text != "" && lblAttachedFileName4.Text != "")
            {
                if (hdnMSMEApplied.Value == "Y")
                {
                    string errormsg = "";
                    if (txtExpectedDCP.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Expected Date of Commencement of Production \\n"; }
                    if (txtDISCOMApplDate.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Date of Application with DISCOM \\n"; }
                    if (txtDISCOMApplDate.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Contracted Load(KW/HP) \\n"; }
                    if (lblCommDoc.Text.Trim() == "")
                    { errormsg = errormsg + "Please upload Registration Copy with Commercial taxes Department \\n"; }
                    if (errormsg != "")
                    {
                        string msg = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                        return;

                    }
                }
                if (save())
                {
                    //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                    //success.Visible = true;
                    string message = "alert('Advanced Subsidy Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnNext.Visible = true;

                    BtnSave.Enabled = false;
                    BtnNext.Enabled = true;

                    // BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
                BtnSave.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public bool save()
    {
        try
        {
            AssignValuestoVosFromcontrols();

            string valid = Gen.InsertIncentAdvSub(objvoA);

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
            objvoA.TotalEquity = txtTotalEquity.Text;
            objvoA.OwnCapital = txtOwnCapital.Text;
            objvoA.Borrowed = txtBorrowed.Text;
            objvoA.AdvSubClaimed = txtAdvSubClaimed.Text;
            objvoA.FinanceSource = ddlinstallment.SelectedValue;

            string[] Ld2 = null;
            string ConvertedDt5 = "";
            if (txtExpectedDCP.Text != "")
            {
                Ld2 = txtExpectedDCP.Text.Split('/');
                ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                objvoA.ExpecctedDCP = ConvertedDt5;
            }
            else
            {
                objvoA.ExpecctedDCP = null;
            }


        //    objvoA.ExpecctedDCP = txtExpectedDCP.Text;

            string[] Ld3 = null;
            string ConvertedDt6 = "";

            if (txtDISCOMApplDate.Text != "")
            {
                Ld3 = txtDISCOMApplDate.Text.Split('/');
                ConvertedDt6 = Ld3[2].ToString() + "/" + Ld3[1].ToString() + "/" + Ld3[0].ToString();

                objvoA.DISCOMApplDate = ConvertedDt6;
            }
            else
            {
                objvoA.DISCOMApplDate = null;
            }


         //   objvoA.DISCOMApplDate = txtDISCOMApplDate.Text;

            objvoA.ContractedLoad = txtContractedLoad.Text;
            objvoA.IncentveID = Session["EntprIncentive"].ToString();
            objvoA.Created_by = Session["uid"].ToString();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("IIDFund.aspx?Previous=P");
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "" && lblAttachedFileName3.Text != "" && lblAttachedFileName4.Text != "")
            {
                if (hdnMSMEApplied.Value == "Y")
                {
                    string errormsg = "";
                    if (txtExpectedDCP.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Expected Date of Commencement of Production \\n"; }
                    if (txtDISCOMApplDate.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Date of Application with DISCOM \\n"; }
                    if (txtDISCOMApplDate.Text.Trim() == "")
                    { errormsg = errormsg + "Please enter Contracted Load(KW/HP) \\n"; }
                    if (lblCommDoc.Text.Trim() == "")
                    { errormsg = errormsg + "Please upload Registration Copy with Commercial taxes Department \\n"; }
                    if (errormsg != "")
                    {
                        string msg = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", msg, true);
                        return;
                    }
                }
                if (save())
                {
                    //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                    //success.Visible = true;
                    string message = "alert('Advanced Subsidy Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnNext.Visible = true;

                    BtnSave.Enabled = false;
                    BtnNext.Enabled = true;

                    // BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                }
                Response.Redirect("FinalPage.aspx");
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please upload Mandatory Document(s).";
                BtnSave.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdvanceSubsidyForSCandST.aspx");
    }

    public void DeleteFile(string strFileName)
    {
        try
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnUpload1_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
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
                            //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\80");
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\12\\53");

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
                                //80,
                                                          53,
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnUpload2_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fuDocuments2.HasFile)
            {
                if ((fuDocuments2.PostedFile != null) && (fuDocuments2.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fuDocuments2.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fuDocuments2.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\81");
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\12\\54");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuDocuments2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuDocuments2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                // 81,
                                                         54,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAttachedFileName2.Text = fuDocuments2.FileName;
                            lblAttachedFileName2.Visible = true;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnUpload3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fuDocuments3.HasFile)
            {
                if ((fuDocuments3.PostedFile != null) && (fuDocuments3.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fuDocuments3.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fuDocuments3.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\82");
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\12\\55");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuDocuments3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuDocuments3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                //  82,
                                                        55,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAttachedFileName3.Text = fuDocuments3.FileName;
                            lblAttachedFileName3.Visible = true;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnUpload4_Click(object sender, EventArgs e)
    {
        try
        {

            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fuDocuments4.HasFile)
            {
                if ((fuDocuments4.PostedFile != null) && (fuDocuments4.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fuDocuments4.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fuDocuments4.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\83");
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\12\\4");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuDocuments4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuDocuments4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                // 83,
                                                         4,
                                                         sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAttachedFileName4.Text = fuDocuments4.FileName;
                            lblAttachedFileName4.Visible = true;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnCommDoc_Click(object sender, EventArgs e)
    {
        try
        {

            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];
            General t1 = new General();
            if (fupCommDoc.HasFile)
            {
                if ((fupCommDoc.PostedFile != null) && (fupCommDoc.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupCommDoc.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupCommDoc.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            //newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\83");
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\12\\913");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupCommDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupCommDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()), "NA",
                                                         913,
                                                         sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblCommDoc.Text = fupCommDoc.FileName;
                            lblCommDoc.Visible = true;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}