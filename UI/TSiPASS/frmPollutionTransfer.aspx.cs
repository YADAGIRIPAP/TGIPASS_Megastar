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
            //Response.Redirect("~/Index.aspx");
        }
        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {


            }

        }





        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);


    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.UpdatepollutionTransfer(txtUID.Text, ddlApproval.SelectedValue);

            lblmsg.Text = "<font color='green'>Successfully Transferred..!</font>";
            success.Visible = true;
            Failure.Visible = false;
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




    protected void GetNewRectoInsertdr()
    {

    }

    //public void DeleteFile(string strFileName)
    //{//Delete file from the server
    //    if (strFileName.Trim().Length > 0)
    //    {
    //        FileInfo fi = new FileInfo(strFileName);
    //        if (fi.Exists)//if file exists delete it
    //        {
    //            fi.Delete();
    //        }
    //    }
    //}


    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{

    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //    string sFileDir = Server.MapPath("~\\Attachments");

    //    General t1 = new General();
    //    if (FileUpload1.HasFile)
    //    {
    //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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

    //                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "DWG")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID0.Value + "\\ApprovalDocument\\" + hdfFlagID2.Value);

    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int result = 0;
    //                    result = t1.InsertImagedataApproval(hdfFlagID3.Value, hdfFlagID0.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "ApprovalDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), hdfFlagID2.Value, hdfFlagID1.Value);


    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        lblFileName.Text = FileUpload1.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                        txtUID.Text = "";
    //                        Label447.Text = "";
    //                        Label448.Text = "";
    //                        Label449.Text = "";
    //                        Label450.Text = "";


    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }
    //                    lblFileName.Text = "";
    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    //    else
    //    {
    //        lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
    //        success.Visible = false;
    //        Failure.Visible = true;
    //        //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
    //    }

    //}

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (txtUID.Text != "")
        {
            getApprovalbyUID();
            //trDetails.Visible = false;
        }

    }

    public void getApprovalbyUID()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.getApprovalbyUIDfrotransfer(txtUID.Text);
        ddlApproval.DataSource = dsnew.Tables[0];
        ddlApproval.DataTextField = "ApprovalName";
        ddlApproval.DataValueField = "ApprovalId";
        ddlApproval.DataBind();
        ddlApproval.Items.Insert(0, "--Select--");
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (txtUID.Text != "")
        {
            if (ddlApproval.SelectedItem.Text != "--Select--")
            {
                FillDetails();
                ddlApproval.Items.Clear();
                
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Select Approval to transfer";
            }

        }
        else
        {
            success.Visible = false;
            Failure.Visible = true;
            lblmsg0.Text = "Please Enter UID";
        }
        
    }
}




