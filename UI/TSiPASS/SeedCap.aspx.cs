using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UI_TSiPASS_IncentivesAnnexure_SeedCap : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            if (Session["incentivedata"] != null)
            {
                string userid = Session["uid"].ToString();
                string IncentveID = Session["EntprIncentive"].ToString();
                DataSet dscaste = new DataSet();
                dscaste = Gen.GetIncentivesCaste(userid, IncentveID);

                DataSet ds = new DataSet();
                ds = (DataSet)Session["incentivedata"];
                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 10);  // Seed Capital Assistance for 1st generation Entrepreneur for Micro Enterprise
                if (drs.Length > 0)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = Gen.GetIncentives_SEED_CAP_data(Session["EntprIncentive"].ToString());
                    Filldata(dsnew);
                }
                else
                {
                    if (Request.QueryString[0].ToString() == "N")
                    {
                        Response.Redirect("IncentiveFromVIII.aspx?next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("IncentiveFORMVI.aspx?Previous=" + "P");
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
                        lblheadTPRIDE.Text = "<center>" + "ANNEXURE: X" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SEED CAPITAL ASSISTANCE UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                        lblheadTIDEA.Visible = false;

                    }
                    else if (TIDEAflag == "Y")
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: X" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SEED CAPITAL ASSISTANCE UNDER T - IDEA </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
                    }
                }
                
                else
                {
                    lblheadTIDEA.Visible = true;

                    lblheadTIDEA.Text = "<center>" + "ANNEXURE: X" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF SEED CAPITAL ASSISTANCE UNDER " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                    lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                    lblheadTPRIDE.Visible = false;
                }

            }
        }
    }
    void Filldata(DataSet ds)
    {
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Amountclaimed"] != null && ds.Tables[0].Rows[0]["Amountclaimed"] != "")
            {

                txtAmtSubClaimed.Text = ds.Tables[0].Rows[0]["Amountclaimed"].ToString();
                BtnSave.Enabled = false;
                BtnNext.Enabled = true;

            }
        }
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

                if (sen.Contains("67"))
                {
                    //lblUpload1.NavigateUrl = sen;
                    lblUpload1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    lblUpload1.Text = ds.Tables[1].Rows[i][1].ToString();
                    lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                    lblAttachedFileName1.Visible = true;
                    //HyperLink1.NavigateUrl = sen;
                    //HyperLink1.Text = 
                }

                if (sen.Contains("9051"))
                {
                    //lblUpload2.NavigateUrl = sen;
                    lblUpload2.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                    lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                    lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                    lblAttachedFileName2.Visible = true;
                    //HyperLink1.NavigateUrl = sen;
                    //HyperLink1.Text = 
                }

                i++;
            }

        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        lblmsg0.Text = "";
        try
        {
            if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "")
            {
                if (save())
                {
                    //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                    //success.Visible = true;
                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
                    UpdateAnnexureflag(IncentiveId, "10", "Y", "");

                    string message = "alert('Seedcap Reimbursement Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    BtnSave.Enabled = false;
                    BtnNext.Enabled = true;
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
            throw ex;
        }
    }
    public bool save()
    {
        try
        {
            lblmsg.Text = "";
            lblmsg0.Text = "";

            AssignValuestoVosFromcontrols();
            string valid = Gen.InsertSeedCapDtls(objvoA);
            if (valid == "Y")
            {
                //lblmsg.Text = "Submitted Successfully";
                //success.Visible = true;


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
            objvoA.AppldInvestSubsidy = txtAmtSubClaimed.Text.Trim();
            objvoA.IncentveID = Session["EntprIncentive"].ToString();
            objvoA.Created_by = Session["uid"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
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
                            //Session["EntprIncentive"] = "12345";
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\10\\67");
                            //newPath = System.IO.Path.Combine(sFileDir, "12345" + "\\67");

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
                                                          67,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            //lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAttachedFileName1.Text = fuDocuments1.FileName;
                            lblAttachedFileName1.Visible = false;
                            lblUpload1.Text = fuDocuments1.FileName;
                            lblUpload1.Visible = true;

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
            throw ex;
        }
    }

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

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

        Response.Redirect("IncentiveFORMVI.aspx?Previous=" + "P");
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "")
        {
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "10", "Y", "");


            Response.Redirect("IncentiveFromVIII.aspx?next=" + "N");
        }
        else
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please upload Mandatory Document(s).";
            BtnSave.Enabled = true;
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

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
                            //Session["EntprIncentive"] = "12345";
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\10\\9051");
                            //newPath = System.IO.Path.Combine(sFileDir, "12345" + "\\67");

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
                                                          9051,
                                                          sFileName,
                                                          newPath,
                                                          Convert.ToInt32(Session["uid"].ToString()));

                            //lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAttachedFileName2.Text = fuDocuments2.FileName;
                            lblAttachedFileName2.Visible = false;
                            lblUpload2.Text = fuDocuments2.FileName;
                            lblUpload2.Visible = true;
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
            throw ex;
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

}