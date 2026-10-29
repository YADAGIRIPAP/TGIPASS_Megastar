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

public partial class UI_TSiPASS_manufactureRegistrations : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    int n1;
   // string id="17083";
    static DataTable dtMyTable;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
                }

            }


            // }
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "103");

            if (dsnew.Tables[0].Rows.Count > 0)
            {




            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    //Response.Redirect("frmCinematographLicense.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                   // Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");


                }
                else
                {
                    Response.Redirect("frmFiredetailsCFO.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value =Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();

            }
        }

    }
    public void ResetFormControl(Control parent)
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

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    public string ValidateFileUploadControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (gvUpload4.Rows.Count < 1)
        {
            ErrorMsg = ErrorMsg + slno + ".Please Upload Document With Detailed list of the machinery, Tools and Equipment..! \\n";
            slno = slno + 1;

        }
        if (gvUpload5.Rows.Count < 1)
        {
            ErrorMsg = ErrorMsg + slno + ".Please Upload Document with Detailed list of Testing Facilities..!\\n";
            slno = slno + 1;

        }
        if (gvupload6.Rows.Count < 1)
        {
            ErrorMsg = ErrorMsg + slno + ".Please Upload Document with Detailed list of technical personnel with designation, qualifications and experience..!\\n";
            slno = slno + 1;

        }
        if (gvupload7.Rows.Count < 1)
        {
            ErrorMsg = ErrorMsg + slno + ".Please Upload Docment with List of welders employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950..!\\n";
            slno = slno + 1;

        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateFileUploadControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
                int result = 0;
                result = Gen.insertmanfacturerDetails( Session["ApplidA"].ToString(), hdfFlagID0.Value.ToString(), "1", "1",
                    txtworkshoparea.Text, txtestablishyear.Text, ddlTypeOfEquipment.SelectedValue, txtFirmtoexecutejob.Text, txtfirmtoAcceptResponsibility.Text,
                    txtfirmtosupplymaterials.Text,  txtfirmQualitycontrolsystem.Text, Session["uid"].ToString(), Session["uid"].ToString());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>Manufacture Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>Manufacture Boiler Details Submission Failed..!</font>";
                }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];
            General t1 = new General();
            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\MachinaryToolEqipment");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            //result = t1.InsertImagedata(Session["ApplidA"].ToString(), hdfFlagID0.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, " machinery, Tools and Equipment ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MachinaryToolEqipment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }

                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload5.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload5.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                                FileUpload5.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                //result = t1.InsertImagedata(Session["ApplidA"].ToString(), hdfFlagID0.Value.ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, " machinery, Tools and Equipment ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MachinaryToolEqipment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }
                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label4.Text = FileUpload5.FileName;
                            Label447.Text = FileUpload5.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            FillDetails();
                            
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
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

                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\TestingFacilities");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)
                        //    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            //result = t1.InsertImagedata(Session["ApplidA"].ToString(), hdfFlagID0.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Testing Facilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TestingFacilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }
                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload4.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload4.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                //result = t1.InsertImagedata(Session["ApplidA"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Testing Facilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TestingFacilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }

                        //int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label3.Text = FileUpload4.FileName;
                            Label448.Text = FileUpload4.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            //SetFocus(success);
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                            FillDetails();
                            //DataSet ds = new DataSet();
                            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                            //if (ds.Tables[5].Rows.Count > 0)
                            //{
                            //    int c = ds.Tables[5].Rows.Count;
                            //    string sen1, sen2, sen3, sen4;
                            //    int j = 0;

                            //    while (j < c)
                            //    {
                            //        sen1 = ds.Tables[5].Rows[j][0].ToString();

                            //        if (sen1.Contains("Combinedsiteplan"))
                            //        {
                            //            sen3 = sen1.Replace(@"\", @"/");
                            //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                            //            sen2 = ds.Tables[5].Rows[j][1].ToString();

                            //            DataTable dt = new DataTable();
                            //            dt.Clear();
                            //            dt.Columns.Add("link");
                            //            dt.Columns.Add("FileName");
                            //            DataRow _row = dt.NewRow();
                            //            _row["link"] = sen4;
                            //            _row["FileName"] = sen2;
                            //            dt.Rows.Add(_row);

                            //            Session["CertificateTb1"] = null;
                            //            Session["CertificateTb1"] = dt;
                            //            this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                            //            this.gvUpload5.DataBind();
                            //        }
                            //    }
                            //}

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            SetFocus(Failure);
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
                        //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                    }
                }
                catch (Exception ex)//in case of an error
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\DQandExperience");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)
                        //    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            //result = t1.InsertImagedata(Session["ApplidA"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "designation, qualifications and experience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "designationqualificationsandexperience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
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

                                //result = t1.InsertImagedata(Session["ApplidA"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "designation, qualifications and experience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "designationqualificationsandexperience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }

                        //int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label3.Text = FileUpload4.FileName;
                            Label448.Text = FileUpload1.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            //SetFocus(success);
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                            FillDetails();
                            //DataSet ds = new DataSet();
                            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                            //if (ds.Tables[5].Rows.Count > 0)
                            //{
                            //    int c = ds.Tables[5].Rows.Count;
                            //    string sen1, sen2, sen3, sen4;
                            //    int j = 0;

                            //    while (j < c)
                            //    {
                            //        sen1 = ds.Tables[5].Rows[j][0].ToString();

                            //        if (sen1.Contains("Combinedsiteplan"))
                            //        {
                            //            sen3 = sen1.Replace(@"\", @"/");
                            //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                            //            sen2 = ds.Tables[5].Rows[j][1].ToString();

                            //            DataTable dt = new DataTable();
                            //            dt.Clear();
                            //            dt.Columns.Add("link");
                            //            dt.Columns.Add("FileName");
                            //            DataRow _row = dt.NewRow();
                            //            _row["link"] = sen4;
                            //            _row["FileName"] = sen2;
                            //            dt.Rows.Add(_row);

                            //            Session["CertificateTb1"] = null;
                            //            Session["CertificateTb1"] = dt;
                            //            this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                            //            this.gvUpload5.DataBind();
                            //        }
                            //    }
                            //}

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            SetFocus(Failure);
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
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
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
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

                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\IBR1950");

                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        //int count = dir.GetFiles().Length;
                        //if (count == 0)
                        //    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //else
                        //{
                        //    if (count == 1)
                        //    {
                        //        string[] Files = Directory.GetFiles(newPath);

                        //        foreach (string file in Files)
                        //        {
                        //            File.Delete(file);
                        //        }
                        //        FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //    }
                        //}

                        int count = dir.GetFiles().Length;
                        int result = 0;
                        if (count == 0)
                        {
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            //result = t1.InsertImagedata(Session["ApplidA"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Indian Boiler Regulations, 1950 .", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IndianBoilerRegulations", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }
                        else
                        {
                            if (count > 0)
                            {
                                string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload2.FileName);
                                string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload2.FileName);

                                FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                                string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                                FileUpload2.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                                //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Indian Boiler Regulations, 1950 .", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IndianBoilerRegulations", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            }
                        }

                        //int result = 0;
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), ViewState["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined site plan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label3.Text = FileUpload4.FileName;
                            Label448.Text = FileUpload4.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            //SetFocus(success);
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                            FillDetails();
                            //DataSet ds = new DataSet();
                            //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                            //if (ds.Tables[5].Rows.Count > 0)
                            //{
                            //    int c = ds.Tables[5].Rows.Count;
                            //    string sen1, sen2, sen3, sen4;
                            //    int j = 0;

                            //    while (j < c)
                            //    {
                            //        sen1 = ds.Tables[5].Rows[j][0].ToString();

                            //        if (sen1.Contains("Combinedsiteplan"))
                            //        {
                            //            sen3 = sen1.Replace(@"\", @"/");
                            //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                            //            sen2 = ds.Tables[5].Rows[j][1].ToString();

                            //            DataTable dt = new DataTable();
                            //            dt.Clear();
                            //            dt.Columns.Add("link");
                            //            dt.Columns.Add("FileName");
                            //            DataRow _row = dt.NewRow();
                            //            _row["link"] = sen4;
                            //            _row["FileName"] = sen2;
                            //            dt.Rows.Add(_row);

                            //            Session["CertificateTb1"] = null;
                            //            Session["CertificateTb1"] = dt;
                            //            this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                            //            this.gvUpload5.DataBind();
                            //        }
                            //    }
                            //}

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            SetFocus(Failure);
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(Failure);
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

    void FillDetails()
    {
        try
        {
            DataSet dscfeboiler = new DataSet();
            dscfeboiler = Gen.GetdataofCFEBoiler(hdfFlagID0.Value);

            if (dscfeboiler.Tables[0].Rows.Count > 0)
            {

                txtworkshoparea.Text = dscfeboiler.Tables[0].Rows[0]["WorkShop_Area"].ToString();
                txtestablishyear.Text = dscfeboiler.Tables[0].Rows[0]["Establishment_Year"].ToString();
                ddlTypeOfEquipment.SelectedValue = dscfeboiler.Tables[0].Rows[0]["Eqipment_Type"].ToString();
                txtFirmtoexecutejob.Text = dscfeboiler.Tables[0].Rows[0]["Firmtoexecutejob"].ToString();
                txtfirmtoAcceptResponsibility.Text = dscfeboiler.Tables[0].Rows[0]["firmtoAcceptResponsibility"].ToString();
                txtfirmtosupplymaterials.Text = dscfeboiler.Tables[0].Rows[0]["firmtosupplymaterials"].ToString();
                txtfirmQualitycontrolsystem.Text = dscfeboiler.Tables[0].Rows[0]["firmQualitycontrolsystem"].ToString();
            }





            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            //DataSet dsattachment = new DataSet();
            DataSet ds = new DataSet();
            ds = Gen.ViewAttachmetsDataCFO(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, senPlanB;
                int i = 0;


                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");

                DataTable dt3 = new DataTable();
                dt3.Columns.Add("link");
                dt3.Columns.Add("FileName");

                DataTable dt4 = new DataTable();
                dt4.Columns.Add("link");
                dt4.Columns.Add("FileName");


                while (i < c)
                {

                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");




                    if (sen.Contains("MachinaryToolEqipment"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt1.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt1.Rows.Add(_row);

                        Session["CertificateTb5"] = null;
                        Session["CertificateTb5"] = dt1;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb5"]).DefaultView;
                        this.gvUpload4.DataBind();

                        //Button4.Visible = false;
                        // lnkupload4.Visible = true;

                    }

                    if (sen.Contains("TestingFacilities"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt2.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt2.Rows.Add(_row);

                        Session["CertificateTb2"] = null;
                        Session["CertificateTb2"] = dt2;
                        this.gvUpload5.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvUpload5.DataBind();
                    }
                    if (sen.Contains("DQandExperience"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt3.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt3.Rows.Add(_row);

                        Session["CertificateTb3"] = null;
                        Session["CertificateTb3"] = dt3;
                        this.gvupload6.DataSource = ((DataTable)Session["CertificateTb3"]).DefaultView;
                        this.gvupload6.DataBind();
                    }
                    if (sen.Contains("IBR1950"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt4.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt4.Rows.Add(_row);

                        Session["CertificateTb4"] = null;
                        Session["CertificateTb4"] = dt4;
                        this.gvupload7.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                        this.gvupload7.DataBind();
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

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //this.Clear();
    }

    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmFiredetailsCFO.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateFileUploadControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        int result = 0;
        result = Gen.insertmanfacturerDetails(Session["Applid"].ToString(), hdfFlagID0.Value.ToString(), "1", "1",
            txtworkshoparea.Text, txtestablishyear.Text, ddlTypeOfEquipment.SelectedValue, txtFirmtoexecutejob.Text, txtfirmtoAcceptResponsibility.Text,
            txtfirmtosupplymaterials.Text, txtfirmQualitycontrolsystem.Text, Session["uid"].ToString(), Session["uid"].ToString());

        if (result > 0)
        {
            Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
            lblmsg.Text = "<font color='green'>Manufacture Boiler Details Saved Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;

        }
        else
        {
            lblmsg.Text = "<font color='green'>Manufacture Boiler Details Submission Failed..!</font>";
        }
    }
}