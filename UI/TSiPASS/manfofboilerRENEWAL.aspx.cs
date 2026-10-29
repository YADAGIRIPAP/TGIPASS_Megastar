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
public partial class UI_TSiPASS_manfofboilerRENEWAL : System.Web.UI.Page
{
    General Gen = new General();
    string ID;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {
            //Session["Applid"] = "0";
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityRENAPPROVALID(Request.QueryString[0].ToString(), "104");//Session["Applid"].ToString()
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        Response.Redirect("frmISMWCLRenewalForm.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim() + "&next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }

            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }

                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
                    {

                        ResetFormControl(this);

                    }
                }

                //DataSet ds = new DataSet();
                //ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

                //if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                //    FillDetails();
                //}
            }
            

            //BindDistricts();
        }

        if (!IsPostBack)
        {

            //DataSet dsver = new DataSet();

            //dsver = Gen.GetverifyofqueBoiler9CFO(Session["ApplidA"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //        ViewState["Enable"] = "Y";
            //    }

            //}

        }


        if (!IsPostBack)
        {
            //string res = Gen.RetriveStatusBoilersCFO(Session["ApplidA"].ToString());

            //if (res == "Y")
            //{

            //}
            //DataSet dsnew = new DataSet();
            //dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "56");
            //if (dsnew.Tables[0].Rows.Count > 0)
            //{

            //}
            //else
            //{
            //    if (Request.QueryString[1].ToString() == "N")
            //    {

            //        Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

            //    }
            //    else
            //    {
            //        Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

            //    }

            //}



        }

        if (!IsPostBack)
        {
                       
            DataSet ds = new DataSet();
            ds = Gen.GetdataofRENBoiler(Request.QueryString[0].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                FillDetails();

            }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

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

    protected void BtnUpload1_Click(object sender, EventArgs e)
    {
        //string newPath = "";
        //string sFileDir = Server.MapPath("~\\Renewalcertificate");

        //General t1 = new General();
        //if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
        //{
        //    //determine file name
        //    string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
        //    try
        //    {
        //        string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
        //        int i = fileType.Length;
        //        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
        //        {
        //            //Create a new subfolder under the current active folder
        //            //newPath = System.IO.Path.Combine(sFileDir, sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss"));
        //            newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

        //            // Create the subfolder
        //            if (!Directory.Exists(newPath))
        //                System.IO.Directory.CreateDirectory(newPath);
        //            try
        //            {
        //                FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);

        //                lblfileUpload1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
        //                lblFileLink1.Text = FileUpload3.FileName;
        //                success.Visible = true;
        //                Failure.Visible = false;

        //                string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
        //                HdLink1.Value = newPath + "\\" + sFileName;
        //            }
        //            catch
        //            {
        //                lblfileUpload1.Text = "<font color='red'>Attachment Added Failed..!</font>";
        //                success.Visible = false;
        //                Failure.Visible = true;
        //            }

        //        }
        //        else
        //        {
        //            lblfileUpload1.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
        //            success.Visible = false;
        //            Failure.Visible = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        DeleteFile(newPath + "\\" + sFileName);
        //    }
        //}
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if (FileUpload3.HasFile)
        {
            if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PREREGRENCERTIFICATE");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PreviousRegorRenCertificate");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileLink1.Text = FileUpload3.FileName;
                            lblfileUpload1.Text = FileUpload3.FileName;
                            success.Visible = true;
                            Failure.Visible = false;

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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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
        else
        {
            lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (lblfileUpload1.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Previous Registration/Renewal Certificate..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (gvUpload4.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of the machinery, Tools and Equipment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label448.Text == "")
        if (gvUpload5.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of Testing Facilities..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (gvupload6.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of technical personnel with designation, qualifications and experience..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label448.Text == "")
        if (gvupload7.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload List of welders employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        int result = 0;
        result = Gen.InsertmanfRenewalDetails(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1",
            txtworkshoparea.Text, HdLink1.Value, ddlTypeOfEquipment.SelectedValue, txtFirmtoexecutejob.Text, txtfirmtoAcceptResponsibility.Text,
            txtfirmtosupplymaterials.Text, txtfirmQualitycontrolsystem.Text, Session["uid"].ToString(), Session["uid"].ToString());

        if (result > 0)
        {
            lblmsg.Text = "<font color='green'>Boiler Renewal Manufacturer Details Saved Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
            Response.Redirect("frmISMWCLRenewalForm.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim() + "&next=" + "N");
        }
        else
        {
            lblmsg.Text = "<font color='green'>Boiler Renewal Manufacturer Details Submission Failed..!</font>";
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];
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
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MachinaryToolEqipment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "MachinaryToolEqipment");
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
                                //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MachinaryToolEqipment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "MachinaryToolEqipment");
                            }
                        }
                        if (result > 0)
                        {
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            //Label4.Text = FileUpload5.FileName;
                            Label447.Text = FileUpload5.FileName;
                            success.Visible = true;
                            Failure.Visible = false;
                            FillDetailsAttachments();

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
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

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
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TestingFacilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "TestingFacilities");
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
                                //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TestingFacilities", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "TestingFacilities");
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
                            FillDetailsAttachments();
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
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

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
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "designationqualificationsandexperience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "designationqualificationsandexperience");
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
                                //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "designationqualificationsandexperience", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "designationqualificationsandexperience");
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
                            FillDetailsAttachments();
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
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

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
                            //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IndianBoilerRegulations", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "IndianBoilerRegulations");
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
                                //result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "IndianBoilerRegulations", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                                result = t1.InsertRenewalAttachement(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "IndianBoilerRegulations");
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
                            FillDetailsAttachments();
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
        DataSet dsboilerren = new DataSet();
        dsboilerren = Gen.GetdataofRENBoiler(Request.QueryString[0].ToString());

        if (dsboilerren.Tables[0].Rows.Count > 0)
        {
            txtworkshoparea.Text = dsboilerren.Tables[0].Rows[0]["WorkShop_Area"].ToString();

            ddlTypeOfEquipment.SelectedValue = dsboilerren.Tables[0].Rows[0]["Eqipment_Type"].ToString();
            txtFirmtoexecutejob.Text = dsboilerren.Tables[0].Rows[0]["Firmtoexecutejob"].ToString();
            txtfirmQualitycontrolsystem.Text = dsboilerren.Tables[0].Rows[0]["firmQualitycontrolsystem"].ToString();
            txtfirmtosupplymaterials.Text = dsboilerren.Tables[0].Rows[0]["firmtosupplymaterials"].ToString();
            txtfirmtoAcceptResponsibility.Text = dsboilerren.Tables[0].Rows[0]["firmtoAcceptResponsibility"].ToString();
            int cn = dsboilerren.Tables[0].Rows.Count;
            string senn, senn1, senn2;
            int i1 = 0;

            while (i1 < cn)
            {
                senn2 = dsboilerren.Tables[0].Rows[i1][0].ToString();
                senn1 = senn2.Replace(@"\", @"/");
                senn = senn1.Replace(@"D:/TS-iPASSFinal/", "~/");


                //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");


                if (senn.Contains("PREREGRENCERTIFICATE"))
                {
                    lblFileLink1.NavigateUrl = senn;
                    lblFileLink1.Text = dsboilerren.Tables[0].Rows[i1][1].ToString();
                    lblfileUpload1.Text = dsboilerren.Tables[0].Rows[i1][1].ToString();
                    //HyperLink1.NavigateUrl = sen;
                    //HyperLink1.Text = 
                }
                i1++;




                DataSet ds = new DataSet();
                


                try
                {

                    //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

                    ds = Gen.ViewAttachmentREN(Request.QueryString[0].ToString());

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
        }
    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (lblfileUpload1.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Previous Registration/Renewal Certificate..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (gvUpload4.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of the machinery, Tools and Equipment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label448.Text == "")
        if (gvUpload5.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of Testing Facilities..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (gvupload6.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed list of technical personnel with designation, qualifications and experience..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label448.Text == "")
        if (gvupload7.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload List of welders employed with copies of current certificate issued by a Competent Authority under the Indian Boiler Regulations, 1950..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        int result = 0;
        result = Gen.InsertmanfRenewalDetails(Request.QueryString[0].ToString(), Session["uid"].ToString(), "1", "1",
            txtworkshoparea.Text, HdLink1.Value, ddlTypeOfEquipment.SelectedValue, txtFirmtoexecutejob.Text, txtfirmtoAcceptResponsibility.Text,
            txtfirmtosupplymaterials.Text, txtfirmQualitycontrolsystem.Text, Session["uid"].ToString(), Session["uid"].ToString());

        if (result > 0)
        {
            lblmsg.Text = "<font color='green'>Boiler Renewal Manufacturer Details Saved Successfully..!</font>";
            success.Visible = true;
            Failure.Visible = false;
            Response.Redirect("frmISMWCLRenewalForm.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

        }
        else
        {
            lblmsg.Text = "<font color='green'>Boiler Renewal Manufacturer Details Submission Failed..!</font>";
        }
    }

    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString().Trim());
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }

    void FillDetailsAttachments()
    {

        DataSet ds = new DataSet();
        try
        {

            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmentREN(Request.QueryString[0].ToString());

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
}
