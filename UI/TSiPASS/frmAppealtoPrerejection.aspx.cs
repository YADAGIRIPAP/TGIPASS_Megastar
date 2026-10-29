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
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBox1.Text = Request.QueryString[1].ToString();
        //TextBox2.Text = Request.QueryString[2].ToString();
        //TextBox3.Text = Request.QueryString[3].ToString();
        //TextBox4.Text = Request.QueryString[4].ToString();
        //TextBox5.Text = Request.QueryString[5].ToString();
        //TextBox6.Text = Request.QueryString[6].ToString();
        //TextBox7.Text = Request.QueryString[7].ToString();
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("../../index.aspx");
            }
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareReg.aspx");
            }

            if (!IsPostBack)
            {
                FillDetails();

            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        // Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);


    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());
            string updatedflag = "";
            string cfeid = Request.QueryString[0].ToString().Trim();
            string approvalid = Request.QueryString[1].ToString().Trim();
            ds = Gen.GetpreRejectedDetails(cfeid, approvalid);


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["Rejecteddate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["rejected_reason"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();

                if (ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != "" && ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != null)
                {
                    updatedflag = ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString() != "" && ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString() != null)
                {
                    lbldeptremarks.Text = ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString();
                    //lblmsg0.Text = "Application is already applied for appeal need to be revoked";
                    trdeptremarks.Visible = true;
                    //return;
                }

            }
            // commented on 01/11/2017 for allowing appeal multiple times/// removed comments - 30.11.17
            if (ds.Tables[0].Rows[0]["Appealed"].ToString() == "Y")
            {
                trbtn.Visible = false;
                trdescription.Visible = false;
                trattachment.Visible = false;
                tr1.Visible = true;
                lblmsg0.Text = "Application is already applied for appeal need to be revoked";
                lblmsg0.Visible = true;
                return;
            }
            else
            {
                trattachment.Visible = true;
            }
            if (hdfFlagID1.Value == "11" || hdfFlagID1.Value == "3")
            {
                if ( hdfFlagID1.Value == "3")
                {
                    trattachment.Visible = false;
                    if (ds.Tables[0].Rows[0]["RejectionAttachment"].ToString() != "" && ds.Tables[0].Rows[0]["RejectionAttachment"].ToString() != string.Empty)
                    {
                        string attachmentid = ds.Tables[0].Rows[0]["RejectionAttachment"].ToString().Trim();
                        string[] split = ds.Tables[0].Rows[0]["RejectionAttachment"].ToString().Split(',');

                        for (int i = 0; i < split.Length; i++)
                        {
                            if (split[i].ToString().TrimStart().Trim() == "1")//registration deed
                            {
                                trregistrationdeed.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "2")// process flow
                            {
                                trProcessFlow.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "3")//PAN / AADHAAR
                            {
                                trPANAADHAAR.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "4")//Self-Certification Form
                            {
                                trSelfCertification.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "5")//Partnership Deed (or) Articles of Association (AOA)
                            {
                                trPartnershipDeed.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "6")//Mutation order
                            {
                                trMutationorder.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "7")//Common Affidavit
                            {
                                trCommonAffidavit.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "9")//Structural Engineering Certificate  
                            {
                                trStructuralEng.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "10")//Combined building plan including all floor plans
                            {
                                trCombinedbuilding.Visible = true;
                                //for (int j = 0; j < split1.Length; j++)
                                //{
                                //    if (split1[j].ToString().TrimStart().Trim() == "1")//registration deed
                                //    {
                                //        HyperLink1.Text = "Short Fall Letter";
                                //    }
                                //}

                            }
                            if (ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Contains(','))
                            {
                                trrejectiondoc.Visible = true;
                                string[] split1 = ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Split(',');
                                HyperLink1.Text = "Rejection Letter";
                                HyperLink1.NavigateUrl = split1[0];
                                //trsDraawingfalldoc.Visible = true;
                                //HyperLink2.Text = "Drawing Short Fall Letter";
                                //HyperLink2.NavigateUrl = split1[1];
                            }
                            else
                            {
                                trrejectiondoc.Visible = true;
                                HyperLink1.Text = "Short Fall Letter";
                                HyperLink1.NavigateUrl = ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Trim();
                                //trsDraawingfalldoc.Visible = false;
                            }


                            //ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();

                        }

                    }
                    else
                    {
                        trattachment.Visible = true;
                    }
                }
                if (hdfFlagID1.Value == "11" && hdfFlagID2.Value != "6")
                {
                    trattachment.Visible = false;
                    if (ds.Tables[0].Rows[0]["RejectionAttachment"].ToString() != "" && ds.Tables[0].Rows[0]["RejectionAttachment"].ToString() != string.Empty)
                    {
                        string attachmentid = ds.Tables[0].Rows[0]["RejectionAttachment"].ToString().Trim();
                        string[] split = ds.Tables[0].Rows[0]["RejectionAttachment"].ToString().Split(',');

                        for (int i = 0; i < split.Length; i++)
                        {
                            if (split[i].ToString().TrimStart().Trim() == "1")//registration deed
                            {
                                trregistrationdeed.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "2")// process flow
                            {
                                trProcessFlow.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "3")//PAN / AADHAAR
                            {
                                trPANAADHAAR.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "4")//Self-Certification Form
                            {
                                trSelfCertification.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "5")//Partnership Deed (or) Articles of Association (AOA)
                            {
                                trPartnershipDeed.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "6")//Mutation order
                            {
                                trMutationorder.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "7")//Common Affidavit
                            {
                                trCommonAffidavit.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "9")//Structural Engineering Certificate  
                            {
                                trStructuralEng.Visible = true;
                            }
                            if (split[i].ToString().TrimStart().Trim() == "10")//Combined building plan including all floor plans
                            {
                                trCombinedbuilding.Visible = true;
                                //for (int j = 0; j < split1.Length; j++)
                                //{
                                //    if (split1[j].ToString().TrimStart().Trim() == "1")//registration deed
                                //    {
                                //        HyperLink1.Text = "Short Fall Letter";
                                //    }
                                //}

                            }
                            if (ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Contains(','))
                            {
                                trrejectiondoc.Visible = true;
                                string[] split1 = ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Split(',');
                                HyperLink1.Text = "Rejection Letter";
                                HyperLink1.NavigateUrl = split1[0];
                                //trsDraawingfalldoc.Visible = true;
                                //HyperLink2.Text = "Drawing Short Fall Letter";
                                //HyperLink2.NavigateUrl = split1[1];
                            }
                            else
                            {
                                trrejectiondoc.Visible = true;
                                HyperLink1.Text = "Short Fall Letter";
                                HyperLink1.NavigateUrl = ds.Tables[0].Rows[0]["RejectedLetter"].ToString().Trim();
                                //trsDraawingfalldoc.Visible = false;
                            }


                            //ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();

                        }

                    }
                    else
                    {
                        trattachment.Visible = true;
                    }
                }
                if (hdfFlagID1.Value == "11" && hdfFlagID2.Value == "6")
                {
                    trattachment.Visible = true;
                }
            }
            else
            {
                trresponseattachmentgrid.Visible = true;
                //trattachment.Visible = true;
            }
            string COIRejectRemarks = ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString().Trim();
            if (COIRejectRemarks != "")
            {
                try
                {
                    TrCOIRemarks.Visible = true;
                    lblcoiremarks.Text = COIRejectRemarks;
                }
                catch (Exception ee)
                {

                    throw;
                }
            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2, senPlanB;
                int i = 0;

                trresponseattachmentgrid.Visible = true;
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.Contains("AppealAttachment"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[1].Rows[i][1].ToString();

                        DataRow _row = dt1.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt1.Rows.Add(_row);

                        Session["CertificateTb1"] = null;
                        Session["CertificateTb1"] = dt1;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvUpload4.DataBind();

                        //Button4.Visible = false;
                        // lnkupload4.Visible = true;

                    }
                    i++;
                }

            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {

        }


    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
    {

    }
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

        try
        {



        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }

    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

    protected void BtnClear0_Click1(object sender, EventArgs e)
    {

    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //if (BtnSave1.Text == "Save")
            //{

            //}
            //else
            //{

            //}
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {

        }
    }



    protected void GetNewRectoInsertdr()
    {

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

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection newSql = new SqlConnection();

            string newPath = "";
            int result = 0;
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

            General t1 = new General();
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value);
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                        {
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Appeal Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        }

                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                string[] Files = Directory.GetFiles(newPath);


                                //foreach (string file in Files)
                                //{
                                //    File.Delete(file);
                                //}
                                result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Appeal Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;


                        //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Appeal Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            //Label440.Text = FileUpload1.FileName;
                            FillDetails();
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");




                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF,Doc,JPG file or RAR only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG file only or RAR  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //int result = 0;
            //if ((txtdiscription.Text == "" && txtdiscription.Text == string.Empty) && (Label440.Text == "" && Label440.Text == string.Empty))
            //{
            //    lblmsg0.Text = "Please Enter Appeal Description or Upload Atachment";
            //    Failure.Visible = true;
            //    lblmsg0.Focus();
            //    return;
            //}
            int result = 0;
            if (txtdiscription.Text == "" || txtdiscription.Text == string.Empty || txtdiscription.Text.Trim().TrimStart().TrimEnd() == "\r\n" || string.IsNullOrWhiteSpace(txtdiscription.Text))
            {
                lblmsg0.Text = "Please Enter Appeal Description or Upload Atachment";
                Failure.Visible = true;
                lblmsg0.Focus();
                return;
            }
            //if (trresponseattachment.Visible == true)
            //{
            //    if (Label440.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Query Response Attachments..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            if (trregistrationdeed.Visible == true)
            {
                if (Label4.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Registration Deed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trProcessFlow.Visible == true)
            {
                if (Label5.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Process Flow Chart..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trPANAADHAAR.Visible == true)
            {
                if (Label6.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload PAN/ Aadhar..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trSelfCertification.Visible == true)
            {
                if (Label8.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Self Certification Form..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trPartnershipDeed.Visible == true)
            {
                if (Label10.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Partnershipdetails (or) Articles Of Association(AOA)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trMutationorder.Visible == true)
            {
                if (Label12.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Mutation Order..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trCommonAffidavit.Visible == true)
            {
                if (Label14.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Common Affidavit..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trStructuralEng.Visible == true)
            {
                if (Label16.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Structural Engineer Certificate..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trCombinedbuilding.Visible == true)
            {
                if (Label18.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Pre-DCR Drawings..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trattachment.Visible == true &&     (hdfFlagID1.Value != "11" && hdfFlagID1.Value != "3"))
            {
                if (gvUpload4.Rows.Count == 0)
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Appeal attachments..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            result = Gen.UpdateAppealDepartmentProcess(hdfFlagID3.Value, hdfFlagID1.Value, hdfFlagID2.Value, txtdiscription.Text, Session["uid"].ToString().Trim());

            if (result > 0)
            {
                lblmsg.Text = "Appealed Successfully";
                trattachment.Visible = false;
                BtnSubmit.Visible = false;
            }
            else
            {
                lblmsg0.Text = "Failed to Appeal";
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnregistrationdeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
        General t1 = new General();
        if ((FileUploadregistrationdeed.PostedFile != null) && (FileUploadregistrationdeed.PostedFile.ContentLength > 0))
        {
            //determine file name

            string sFileName = System.IO.Path.GetFileName(FileUploadregistrationdeed.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadregistrationdeed.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder

                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\registrationdeed");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;
                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                    {
                        //lblmsg.Text =Convert.ToString(count);
                        //lblmsg.Visible = true;
                        //success.Visible = true;
                        FileUploadregistrationdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    }

                    else
                    {
                        if (count == 1)
                        {
                            //lblmsg.Text = Convert.ToString(count);
                            //lblmsg.Visible = true;
                            //success.Visible = true;
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                //File.Delete(file);
                            }
                            FileUploadregistrationdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;

                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Registration Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg0.Visible = false;
                        Label4.Text = FileUploadregistrationdeed.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void btnProcessFlow_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadProcessFlow.PostedFile != null) && (FileUploadProcessFlow.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadProcessFlow.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadProcessFlow.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\ProcessFlow");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadProcessFlow.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadProcessFlow.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Process Flow", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label5.Text = FileUploadProcessFlow.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void btnPANAADHAAR_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadPANAADHAAR.PostedFile != null) && (FileUploadPANAADHAAR.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadPANAADHAAR.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadPANAADHAAR.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\PANAADHAAR");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadPANAADHAAR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadPANAADHAAR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PAN/AADHAR", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label6.Text = FileUploadPANAADHAAR.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void btnSelfCertification_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadSelfCertification.PostedFile != null) && (FileUploadSelfCertification.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadSelfCertification.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadSelfCertification.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\SelfCertification");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadSelfCertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadSelfCertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "SelfCertification", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label8.Text = FileUploadSelfCertification.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void btnPartnershipDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadPartnershipDeed.PostedFile != null) && (FileUploadPartnershipDeed.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadPartnershipDeed.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadPartnershipDeed.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\PartnershipDeed");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadPartnershipDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadPartnershipDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Partnership Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label10.Text = FileUploadPartnershipDeed.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    //protected void btnMutationorder_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string newPath = "";
    //        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //        //string sFileDir = "~\\TenderNotice";
    //        //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
    //        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

    //        General t1 = new General();
    //        if ((FileUploadMutationorder.PostedFile != null) && (FileUploadMutationorder.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUploadMutationorder.PostedFile.FileName);
    //            AttachmentFileName = sFileName;
    //            try
    //            {
    //                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
    //                //{
    //                //    //Save File on disk


    //                //if (FileUpload1.FileContent.Length > 102400 * 18)
    //                //{
    //                //     lblmsg0.Text = "size should be less than 600KB";
    //                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
    //                //    return;
    //                //}

    //                string[] fileType = FileUploadMutationorder.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\Mutationorder");
    //                    ViewState["pathAttachment"] = newPath;
    //                    ViewState["AttachmentName"] = sFileName;

    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    AttachmentFilepath = newPath + "\\" + sFileName;
    //                    int result = 0;
    //                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

    //                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation Order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "Attachment Successfully Added";
    //                        lblmsg.Visible = true;
    //                        lblmsg.Visible = false;
    //                        Label12.Text = FileUploadMutationorder.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "Attachment Added Failed";
    //                        lblmsg0.Visible = true;
    //                        lblmsg.Visible = false;
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "Upload PDF files only..!";
    //                    lblmsg0.Visible = true;
    //                    lblmsg.Visible = false;
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //                }
    //            }
    //            catch (Exception)//in case of an error
    //            {
    //                //lblError.Visible = true;
    //                //lblError.Text = "An Error Occured. Please Try Again!";
    //                DeleteFile(newPath + "\\" + sFileName);
    //                // DeleteFile(sFileDir + sFileName);
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblmsg0.Text = "Internal error has occured. Please try after some time";
    //        lblmsg0.Text = ex.Message;
    //        Failure.Visible = true;
    //    }
    //}

    protected void btnMutationorder_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadMutationorder.PostedFile != null) && (FileUploadMutationorder.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadMutationorder.PostedFile.FileName);
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadMutationorder.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Mutation order");
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\Mutationorder");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation Order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        if (result > 0)
                        {
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label12.Text = FileUploadMutationorder.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

        //try
        //{
        //    string newPath = "";
        //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //    //string sFileDir = "~\\TenderNotice";
        //    //  string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
        //    string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
        //    General t1 = new General();
        //    if ((FileUploadMutationorder.PostedFile != null) && (FileUploadMutationorder.PostedFile.ContentLength > 0))
        //    {
        //        //determine file name
        //        string sFileName = System.IO.Path.GetFileName(FileUploadMutationorder.PostedFile.FileName);
        //        try
        //        {
        //            //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
        //            //{
        //            //    //Save File on disk


        //            //if (FileUpload1.FileContent.Length > 102400 * 18)
        //            //{
        //            //     lblmsg0.Text = "size should be less than 600KB";
        //            //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
        //            //    return;
        //            //}

        //            string[] fileType = FileUploadMutationorder.PostedFile.FileName.Split('.');
        //            int i = fileType.Length;
        //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
        //            {
        //                //Create a new subfolder under the current active folder
        //                //newPath = System.IO.Path.Combine(sFileDir, ViewState["intCFEEnterpid"].ToString() + "\\Mutation order");
        //                newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\Mutationorder");
        //                // Create the subfolder
        //                if (!Directory.Exists(newPath))

        //                    System.IO.Directory.CreateDirectory(newPath);
        //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
        //                int count = dir.GetFiles().Length;
        //                if (count == 0)
        //                    FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
        //                else
        //                {
        //                    if (count == 1)
        //                    {
        //                        string[] Files = Directory.GetFiles(newPath);

        //                        foreach (string file in Files)
        //                        {
        //                            File.Delete(file);
        //                        }
        //                        FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
        //                    }
        //                }

        //                int result = 0;
        //                //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
        //                result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation Order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
        //                if (result > 0)
        //                {
        //                    //ResetFormControl(this);
        //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
        //                    Label2.Text = FileUploadMutationorder.FileName;
        //                    Label446.Text = FileUploadMutationorder.FileName;
        //                    success.Visible = true;
        //                    Failure.Visible = false;
        //                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
        //                    //fillNews(userid);
        //                }
        //                else
        //                {
        //                    lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
        //                    success.Visible = false;
        //                    Failure.Visible = true;
        //                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
        //                }

        //            }
        //            else
        //            {
        //                lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
        //                success.Visible = false;
        //                Failure.Visible = true;
        //                //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
        //            }
        //        }
        //        catch (Exception)//in case of an error
        //        {
        //            //lblError.Visible = true;
        //            //lblError.Text = "An Error Occured. Please Try Again!";
        //            DeleteFile(newPath + "\\" + sFileName);
        //            // DeleteFile(sFileDir + sFileName);
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    //lblmsg0.Text = "Internal error has occured. Please try after some time";
        //    lblmsg0.Text = ex.Message;
        //    Failure.Visible = true;
        //}
    }

    protected void btnCommonAffidavit_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            // string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

            General t1 = new General();
            if ((FileUploadCommonAffidavit.PostedFile != null) && (FileUploadCommonAffidavit.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadCommonAffidavit.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUploadCommonAffidavit.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUploadCommonAffidavit.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadCommonAffidavit.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadCommonAffidavit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadCommonAffidavit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label14.Text = FileUploadCommonAffidavit.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void btnStructuralEng_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            General t1 = new General();
            if ((FileUploadStructuralEng.PostedFile != null) && (FileUploadStructuralEng.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadStructuralEng.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {
                    //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (FileUpload1.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUploadStructuralEng.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\StructuralEng");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadStructuralEng.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    //File.Delete(file);
                                }
                                FileUploadStructuralEng.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Structural Engineer", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label16.Text = FileUploadStructuralEng.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload PDF files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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
    protected void btnCombinedbuilding_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            //string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];
            string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

            General t1 = new General();
            if ((FileUploadCombinedbuilding.PostedFile != null) && (FileUploadCombinedbuilding.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadCombinedbuilding.PostedFile.FileName);
                AttachmentFileName = sFileName;
                try
                {


                    string[] fileType = FileUploadCombinedbuilding.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\AppealAttachment\\" + hdfFlagID1.Value + "\\Combined building plan including all floor plans DWG");
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadCombinedbuilding.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {

                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                //File.Delete(file);
                            }
                            FileUploadCombinedbuilding.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        }

                        AttachmentFilepath = newPath + "\\" + sFileName;
                        int result = 0;
                        //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined building plan including all floor plans DWG", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label18.Text = FileUploadCombinedbuilding.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "Attachment Added Failed";
                            lblmsg0.Visible = true;
                            lblmsg.Visible = false;
                            success.Visible = false;
                            Failure.Visible = true;
                            Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "Upload DWG files only..!";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Upload DWG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception)//in case of an error
                {
                    //lblError.Visible = true;
                    //lblError.Text = "An Error Occured. Please Try Again!";
                    DeleteFile(newPath + "\\" + sFileName);
                    // DeleteFile(sFileDir + sFileName);
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




