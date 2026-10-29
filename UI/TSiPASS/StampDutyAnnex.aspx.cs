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

public partial class UI_TSiPASS_IncentivesAnnexure_StampDutyAnnex : System.Web.UI.Page
{
    IncentiveVosIncetForms objvoA = new IncentiveVosIncetForms();
    General Gen = new General();
    BusinessLogic.DML objDml = new BusinessLogic.DML();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["uid"] != null)
            {
                if (Session["incentivedata"] != null)
                {
                    string IncentveID = Session["EntprIncentive"].ToString();
                    string userid = Session["uid"].ToString();

                    DataSet ds = new DataSet();
                    ds = (DataSet)Session["incentivedata"];
                    DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 9);  // Reimbursement of stamp Duty/Transfer Duty/Mortgage/Land Conversion/Land Cost
                    if (drs.Length > 0)
                    {
                        DataSet dsnew = new DataSet();
                        dsnew = Gen.GetIncentivesStampDutydata(IncentveID);
                        Filldata(dsnew);
                    }
                    else
                    {
                        if (Request.QueryString[0].ToString() == "N")
                        {
                           // Response.Redirect("frmIncentiveForm3.aspx?next=" + "N");
                            Response.Redirect("StampDutyTransferdutyAnnex1.aspx?next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("InvestmentSubsidy.aspx?Previous=" + "P");
                        }
                    }

                    DataSet dscaste = new DataSet();
                    dscaste = Gen.GetIncentivesCaste(userid, IncentveID);
                    string caste = dscaste.Tables[0].Rows[0]["caste"].ToString();
                    string TSCPflag = dscaste.Tables[0].Rows[0]["TSCPflag"].ToString();
                    string TSPflag = dscaste.Tables[0].Rows[0]["TSPflag"].ToString();
                    string TIDEAflag = dscaste.Tables[0].Rows[0]["TIDEAflag"].ToString();

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

                    if (lblscheme.Text == "TIDEA, 2014")
                    {
                        //  if (caste == "3" || caste == "4")   //SC, ST
                        if (TSCPflag == "Y" || TSPflag == "Y")
                        {
                            lblheadTPRIDE.Visible = true;
                            lblheadTIDEA.Visible = false;
                            lblheadTPRIDE.Text = "<center>" + "ANNEXURE: VI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF STAMP DUTY/ TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER T-PRIDE </center></u></b></span>" + "<center>(TELANGANA STATE PROGRAM FOR RAPID INCUBATION OF DALIT ENTREPRENEURS INCENTIVE SCHEME)</center>" + "<center>(G.O.Ms.No.29 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTPRIDE.ForeColor = System.Drawing.Color.White;
                            lblheadTIDEA.Visible = false;

                        }
                        else if (TIDEAflag == "Y")
                        {
                            lblheadTIDEA.Visible = true;

                            lblheadTIDEA.Text = "<center>" + "ANNEXURE: VI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF STAMP DUTY/ TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER T-IDEA  </center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                            lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                            lblheadTPRIDE.Visible = false;
                        }
                    }
                  
                    else
                    {
                        lblheadTIDEA.Visible = true;

                        lblheadTIDEA.Text = "<center>" + "ANNEXURE: VI" + "</center>" + "<center>APPLICATION CUM VERIFICATION FOR</center>" + "<span style='font-size: 14pt;'><b><u><center>REIMBURSEMENT OF STAMP DUTY/ TRANSFER DUTY / MORTGAGE DUTY / LAND CONVESERSION CHARGES /REIMBURSEMENT OF LAND COST PURCHASED IN IE/IDA/IP’s UNDER  " + lblscheme.Text + "</center></u></b></span>" + "<center>(TELANGANA STATE INDUSTRIAL DEVELOPMENT AND ENTREPRENEUR ADVANCEMENT) INCENTIVE SCHEME 2014 </center>" + "<center>(G.O.Ms.No.28 Industries and Commerce (IP & INF) Department. dated.29/11/2014)</center>";

                        lblheadTIDEA.ForeColor = System.Drawing.Color.White;
                        lblheadTPRIDE.Visible = false;
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
            txtAreaRegdSaledeed.Text = ds.Tables[0].Rows[0]["AreaRegdSaledeed"].ToString();
            txtPlnthAreaBuild.Text = ds.Tables[0].Rows[0]["PlnthAreaBuild"].ToString();
            txtFivePlnthAreaBuild.Text = ds.Tables[0].Rows[0]["FivePlnthAreaBuild"].ToString();
            txtAreaReqdAppraisal.Text = ds.Tables[0].Rows[0]["AreaReqdAppraisal"].ToString();
            txtAreaReqdTSPCB.Text = ds.Tables[0].Rows[0]["AreaReqdTSPCB"].ToString();
            // txtNatureofTrans.Text = ds.Tables[0].Rows[0]["NatureofTrans"].ToString();

            try
            {
                txtNatureofTrans.SelectedValue = txtNatureofTrans.Items.FindByText(ds.Tables[0].Rows[0]["NatureofTrans"].ToString().Trim()).Value;
                txtNatureofTrans.Enabled = false;
            }
            catch
            {
                txtNatureofTrans.Enabled = true;
            }
            txtSubRegOffc.Text = ds.Tables[0].Rows[0]["SubRegOffc"].ToString();
            txtRegdDeedNo.Text = ds.Tables[0].Rows[0]["RegdDeedNo"].ToString();
            txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["RegnDate"].ToString()).ToString("dd/MM/yyyy");
            txtStampTranfrDutyAP.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAP"].ToString();
            txtMortgageHypothDutyAP.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAP"].ToString();
            txtLandConvrChrgAP.Text = ds.Tables[0].Rows[0]["LandConvrChrgAP"].ToString();

            txtLandCostIeIdaIpAP.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAP"].ToString();
            txtStampTranfrDutyAC.Text = ds.Tables[0].Rows[0]["StampTranfrDutyAC"].ToString();
            txtMortgageHypothDutyAC.Text = ds.Tables[0].Rows[0]["MortgageHypothDutyAC"].ToString();
            txtLandConvrChrgAC.Text = ds.Tables[0].Rows[0]["LandConvrChrgAC"].ToString();
            txtLandCostIeIdaIpAC.Text = ds.Tables[0].Rows[0]["LandCostIeIdaIpAC"].ToString();

            ///////////
            txtAreaRegdSaledeed.Enabled = false;
            txtPlnthAreaBuild.Enabled = false;
            txtFivePlnthAreaBuild.Enabled = false;
            txtAreaReqdAppraisal.Enabled = false;
            txtAreaReqdTSPCB.Enabled = false;


            txtSubRegOffc.Enabled = false;
            txtRegdDeedNo.Enabled = false;
            txtRegDate.Enabled = false;
            txtStampTranfrDutyAP.Enabled = false;
            txtMortgageHypothDutyAP.Enabled = false;
            txtLandConvrChrgAP.Enabled = false;

            txtLandCostIeIdaIpAP.Enabled = false;
            txtStampTranfrDutyAC.Enabled = false;
            txtMortgageHypothDutyAC.Enabled = false;
            txtLandConvrChrgAC.Enabled = false;
            txtLandConvrChrgAC.Enabled = false;
            txtLandCostIeIdaIpAC.Enabled = false;
            BtnSave.Enabled = false;

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    //if (sen.Contains("60"))
                    if (sen.Contains("27"))
                    {
                        lblupload1.NavigateUrl = sen;
                        lblupload1.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName1.Text = ds.Tables[1].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    //if (sen.Contains("61"))
                    if (sen.Contains("28"))
                    {
                        lblUpload2.NavigateUrl = sen;
                        lblUpload2.Text = ds.Tables[1].Rows[i][1].ToString();
                        lblAttachedFileName2.Text = ds.Tables[1].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;
                }
            }
        }
        else
        {
            txtAreaRegdSaledeed.Enabled = true;
            txtPlnthAreaBuild.Enabled = true;
            txtFivePlnthAreaBuild.Enabled = true;
            txtAreaReqdAppraisal.Enabled = true;
            txtAreaReqdTSPCB.Enabled = true;
            txtNatureofTrans.Enabled = true;

            txtSubRegOffc.Enabled = true;
            txtRegdDeedNo.Enabled = true;
            txtRegDate.Enabled = true;
            txtStampTranfrDutyAP.Enabled = true;
            txtMortgageHypothDutyAP.Enabled = true;
            txtLandConvrChrgAP.Enabled = true;

            txtLandCostIeIdaIpAP.Enabled = true;
            txtStampTranfrDutyAC.Enabled = true;
            txtMortgageHypothDutyAC.Enabled = true;
            txtLandConvrChrgAC.Enabled = true;
            txtLandConvrChrgAC.Enabled = true;
            txtLandCostIeIdaIpAC.Enabled = true;
            BtnSave.Enabled = true;
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
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

                UpdateAnnexureflag(IncentiveId, "9", "Y", "");
                string message = "alert('Stamp Duty Applied Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                lblupload1.Visible = false;
                lblUpload2.Visible = false;
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
    public bool save()
    {
        try
        {
            AssignValuestoVosFromcontrols();

            string valid = Gen.InsertIncentStampDuty(objvoA);

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
            objvoA.AreaRegdSaledeed = txtAreaRegdSaledeed.Text;
            objvoA.AreaReqdAppraisal = txtAreaReqdAppraisal.Text;
            objvoA.AreaReqdTSPCB = txtAreaReqdTSPCB.Text;
            objvoA.FivePlnthAreaBuild = txtFivePlnthAreaBuild.Text;
            objvoA.LandConvrChrgAC = txtLandConvrChrgAC.Text;                 // 3
            objvoA.LandConvrChrgAP = txtLandConvrChrgAP.Text;
            objvoA.LandCostIeIdaIpAC = txtLandCostIeIdaIpAC.Text;             // 4
            objvoA.LandCostIeIdaIpAP = txtLandCostIeIdaIpAP.Text;
            objvoA.MortgageHypothDutyAC = txtMortgageHypothDutyAC.Text;       // 2
            objvoA.MortgageHypothDutyAP = txtMortgageHypothDutyAP.Text;
            objvoA.NatureofTrans = txtNatureofTrans.Text;
            objvoA.PlnthAreaBuild = txtPlnthAreaBuild.Text;
            objvoA.RegnDate = Convert.ToDateTime(txtRegDate.Text);
            objvoA.RegdDeedNo = txtRegdDeedNo.Text;
            objvoA.StampTranfrDutyAC = txtStampTranfrDutyAC.Text;             // 1
            objvoA.StampTranfrDutyAP = txtStampTranfrDutyAP.Text;
            objvoA.SubRegOffc = txtSubRegOffc.Text;


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
        string newPath = "";
        //string sFileDir = Server.MapPath("~\\Attachments");
        //string sFileDir = Server.MapPath("") + "\\IncentivesAttachments\\" + Session["EntprIncentive"].ToString();
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
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\9\\27");

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

                        objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["EntprIncentive"].ToString()),"NA",
                            // 60,
                                                     27,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName1.Text = fuDocuments1.FileName;
                        lblAttachedFileName1.Visible = true;
                        lblupload1.Visible = false;
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

    protected void btnUpload2_Click(object sender, EventArgs e)
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
                        newPath = System.IO.Path.Combine(sFileDir, Session["EntprIncentive"].ToString() + "\\9\\28");

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
                            //  61,
                                                       28,
                                                      sFileName,
                                                      newPath,
                                                      Convert.ToInt32(Session["uid"].ToString()));

                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblAttachedFileName2.Text = fuDocuments2.FileName;
                        lblAttachedFileName2.Visible = true;
                        lblUpload2.Visible = false;
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
    protected void BtnPrevious_Click(object sender, EventArgs e)
    {

        Response.Redirect("InvestmentSubsidy.aspx?Previous=" + "P");

    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (lblAttachedFileName1.Text != "" && lblAttachedFileName2.Text != "")
        {
            if (save())
            {
            }
            DataSet ds = new DataSet();
            ds = (DataSet)Session["incentivedata"];
            string IncentiveId = ds.Tables[0].Rows[0]["EnterperIncentiveID"].ToString();
            UpdateAnnexureflag(IncentiveId, "9", "Y", "");

            // Response.Redirect("frmIncentiveForm3.aspx?next=" + "N");
            Response.Redirect("StampDutyTransferdutyAnnex1.aspx?next=" + "N");
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
        Response.Redirect("StampDutyAnnex.aspx");
    }
    protected void txtPlnthAreaBuild_TextChanged(object sender, EventArgs e)
    {
        txtFivePlnthAreaBuild.Text = "";
        decimal fivePlnthAreaBuild = 0;
        decimal PlnthAreaBuild = 0;

        PlnthAreaBuild = Convert.ToDecimal(txtPlnthAreaBuild.Text);
        fivePlnthAreaBuild = Convert.ToDecimal(5 * PlnthAreaBuild);
        txtFivePlnthAreaBuild.Text = Convert.ToString(fivePlnthAreaBuild);

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