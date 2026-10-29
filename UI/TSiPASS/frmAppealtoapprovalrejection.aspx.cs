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
            string cfeid = Request.QueryString[0].ToString().Trim();
            string approvalid = Request.QueryString[1].ToString().Trim();
            ds = Gen.GetApprovalRejectedDetails(cfeid, approvalid);


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
                if (ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString() != "" && ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString() != null)
                {
                    lbldeptremarks.Text = ds.Tables[0].Rows[0]["COIRejectRemarks"].ToString();
                    //lblmsg0.Text = "Application is already applied for appeal need to be revoked";
                    trdeptremarks.Visible = true;
                    //return;
                }
            }

            if (ds.Tables[0].Rows[0]["Appealed"].ToString() == "Y")
            {
                trbtn.Visible = false;
                trdescription.Visible = false;
                trattachment.Visible = false;
                tr1.Visible = true;
            }


        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

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
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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

                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
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
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        string[] Files = Directory.GetFiles(newPath);

                        foreach (string file in Files)
                        {
                            File.Delete(file);
                        }
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);

                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Appeal Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label440.Text = FileUpload1.FileName;
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
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        int result = 0;
        if ((txtdiscription.Text == "" && txtdiscription.Text == string.Empty) && (Label440.Text == "" && Label440.Text == string.Empty))
        {
            lblmsg0.Text = "Please Enter Appeal Description or Upload Atachment";
            Failure.Visible = true;
            lblmsg0.Focus();
            return;
        }

        result = Gen.UpdateAppealDepartmentProcess(hdfFlagID3.Value, hdfFlagID1.Value, hdfFlagID2.Value, txtdiscription.Text, Session["uid"].ToString().Trim());

        if (result > 0)
        {
            lblmsg.Text = "Appealed Successfully";
            trattachment.Visible = false;
            trdescription.Visible = false;
        }
        else
        {
            lblmsg0.Text = "Failed to Appeal";
        }
    }
}




