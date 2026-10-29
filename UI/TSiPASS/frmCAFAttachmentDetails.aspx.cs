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
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                DataSet ss = new DataSet();
                ss = Gen.GetQuesionaryID(Session["uid"].ToString());
                //hdfFlagID0.Value = .Tables[0].Rows[0][0].ToString();
                if (ss.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = ss.Tables[0].Rows[0][0].ToString().Trim();
                    string TourismFlag = ss.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                    if (TourismFlag == "Y")
                    {
                        trBoilerRegistration.Visible = false;
                        trDrugsLicense.Visible = false;
                        trProcessFlowChart.Visible = false;
                        lblNumber2.Visible = false;
                    }
                    else
                    {
                        trBoilerRegistration.Visible = true;
                        trDrugsLicense.Visible = true;
                        trProcessFlowChart.Visible = true;
                    }
                }
                else
                {
                    Session["Applid"] = "0";
                }
                //DataSet dsver = new DataSet();

                //dsver = Gen.Getverifyofque7(Session["Applid"].ToString());

                //if (dsver.Tables[0].Rows.Count > 0)
                //{
                //    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                //    ////string res = Gen.RetriveStatus("1002");


                //    if (res == "3" || Convert.ToInt32(res) >= 3)
                //    {
                //        ResetFormControl(this);
                //    }

                //}

                DataSet ds = new DataSet();
                ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FillDetails();
                }
            }


            //DataSet ds = new DataSet();
            //ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (!IsPostBack)
            //    {
            //        FillDetails();
            //    }

            //}


            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lblmsg0.Text = ex.Message;
            // Failure.Visible = true;
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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "<font color='Green'>Attachments Saved Success..!</font>";
        success.Visible = true;
        Failure.Visible = false;


    }

    void clear()
    {




    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {



    }

    void FillDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sennew = ds.Tables[0].Rows[i]["linkview"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                        //if (sen.Contains("B1Form"))
                        //{
                        //    lblFileName.NavigateUrl = sen;
                        //    lblFileName.Text = ds.Tables[0].Rows[i][1].ToString();
                        //    Label444.Text = ds.Tables[0].Rows[i][1].ToString();
                        //    //HyperLink1.NavigateUrl = sen;
                        //    //HyperLink1.Text = 
                        //}

                        //if (sen.Contains("B2Form"))
                        //{
                        //    Label1.NavigateUrl = sen;
                        //    Label1.Text = ds.Tables[0].Rows[i][1].ToString();
                        //    Label453.Text = ds.Tables[0].Rows[i][1].ToString();
                        //}

                        //if (sen.Contains("HazForm"))
                        //{
                        //    Label2.NavigateUrl = sen;
                        //    Label2.Text = ds.Tables[0].Rows[i][1].ToString();
                        //    Label454.Text = ds.Tables[0].Rows[i][1].ToString();
                        //}

                        //if (sen.Contains("CompForm"))
                        //{
                        //    Label4.NavigateUrl = sen;
                        //    Label4.Text = ds.Tables[0].Rows[i][1].ToString();
                        //    Label455.Text = ds.Tables[0].Rows[i][1].ToString();
                        //}

                        if (sen.Contains("FileCertForm"))
                        {
                            Label3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label3.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label456.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("BoilerRegForm"))
                        {
                            lblFileName0.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            lblFileName0.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label457.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("DrugForm"))
                        {
                            Label438.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label438.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label458.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("ElecDrawForm"))
                        {
                            Label440.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label440.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label459.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("PartDeedForm"))
                        {
                            Label449.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label449.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label460.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("ListofDirForm"))
                        {
                            Label450.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label450.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label461.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("PanForm"))
                        {
                            Label451.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label451.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label462.Text = ds.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("DEET"))
                        {
                            hypdeetregack.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            hypdeetregack.Text = ds.Tables[0].Rows[i][1].ToString();
                            lbldeetregack.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("LandDeedForm"))
                        {
                            Label452.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label452.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label463.Text = ds.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("ProcessFlowChart"))
                        {
                            Label466.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label466.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label467.Text = ds.Tables[0].Rows[i][1].ToString();
                        }


                        if (sen.Contains("PlantLayout"))
                        {
                            Label469.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                            Label469.Text = ds.Tables[0].Rows[i][1].ToString();
                            Label470.Text = ds.Tables[0].Rows[i][1].ToString();
                        }
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

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

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
            if (BtnSave1.Text == "Save")
            {



            }
            else
            {


            }
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
    protected void Button1_Click(object sender, EventArgs e)
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

    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

    //    General t1 = new General();
    //    if (FileUpload1.HasFile)
    //    {
    //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //            try
    //            {

    //                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\B1Form");
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

    //                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B1 FORM");


    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        lblFileName.Text = FileUpload1.FileName;
    //                        Label444.Text = FileUpload1.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

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
    //protected void BtnB2Form_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

    //    General t1 = new General();
    //    if (FileUpload2.HasFile)
    //    {
    //        if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
    //            try
    //            {

    //                string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\B2Form");
    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int result = 0;

    //                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B2 FORM");


    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        Label1.Text = FileUpload2.FileName;
    //                        Label453.Text = FileUpload2.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

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
    //protected void BtnHazForm_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

    //    General t1 = new General();
    //    if (FileUpload3.HasFile)
    //    {
    //        if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
    //            try
    //            {

    //                string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HazForm");
    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int result = 0;

    //                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HazFORM");


    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        Label2.Text = FileUpload3.FileName;
    //                        Label454.Text = FileUpload3.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

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
    //protected void BtnCompRep_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

    //    General t1 = new General();
    //    if (FileUpload5.HasFile)
    //    {
    //        if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
    //            try
    //            {

    //                string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CompForm");
    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int result = 0;

    //                    result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CompFORM");


    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        Label4.Text = FileUpload5.FileName;
    //                        Label455.Text = FileUpload5.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

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

    protected void BtnFileCert_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload4.HasFile)
            {
                if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\FileCertForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "FileCertFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label3.Text = FileUpload4.FileName;
                                Label456.Text = FileUpload4.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnBoilerReg_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload6.HasFile)
            {
                if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\BoilerRegForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "BoilerRegFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName0.Text = FileUpload6.FileName;
                                Label457.Text = FileUpload6.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnDrug_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload7.HasFile)
            {
                if ((FileUpload7.PostedFile != null) && (FileUpload7.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload7.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload7.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\DrugForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload7.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "DrugFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label438.Text = FileUpload7.FileName;
                                Label458.Text = FileUpload7.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnElecDraw_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload8.HasFile)
            {
                if ((FileUpload8.PostedFile != null) && (FileUpload8.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload8.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload8.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ElecDrawForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload8.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ElecDrawFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label440.Text = FileUpload8.FileName;
                                Label459.Text = FileUpload8.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnPartDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload10.HasFile)
            {
                if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PartDeedForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload10.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PartDeedFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label449.Text = FileUpload10.FileName;
                                Label460.Text = FileUpload10.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnListofDir_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload11.HasFile)
            {
                if ((FileUpload11.PostedFile != null) && (FileUpload11.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload11.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload11.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ListofDirForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload11.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ListofDirFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label450.Text = FileUpload11.FileName;
                                Label461.Text = FileUpload11.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnPan_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload12.HasFile)
            {
                if ((FileUpload12.PostedFile != null) && (FileUpload12.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload12.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload12.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PanForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload12.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PanFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label451.Text = FileUpload12.FileName;
                                Label462.Text = FileUpload12.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnLandDeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload13.HasFile)
            {
                if ((FileUpload13.PostedFile != null) && (FileUpload13.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload13.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload13.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\LandDeedForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload13.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LandDeedFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label452.Text = FileUpload13.FileName;
                                Label463.Text = FileUpload13.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        //if (Label444.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload B1 Form Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label453.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload B2 Form Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label454.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Hazardous Form Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label455.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Compliance Report Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label456.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Fire Occupancy Certificate Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}


        //if (Label461.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload List Of Directors Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label467.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload PAN/AADHAR Card Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}

        //if (Label470.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload PAN/AADHAR Card Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}


        //if (Label457.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Boiler Registration Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label458.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Drugs License Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label459.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Electrical Drawing Approvals Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label460.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Partnership deed Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        //if (Label461.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload List Of Directors Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}
        if (Label467.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Process Flow Chart..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label462.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload PAN/AADHAR Card Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lbldeetregack.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload DEET Registration Acknowledgement..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        //if (Label463.Text == "")
        //{
        //    lblmsg0.Text = "<font color='red'>Please Upload Land OwnerShip Deed Attachment..!</font>";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;
        //}

        Response.Redirect("frmDepartmentApprovalPaymentDetailsCFO.aspx?intApplicationId=" + Session["uid"].ToString());
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCFOPCBDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
        //Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
        Response.Redirect("ForestTransitPermit.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }


    protected void BtnListofDir0_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload14.HasFile)
            {
                if ((FileUpload14.PostedFile != null) && (FileUpload14.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload14.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload14.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ProcessFlowChart");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload14.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ProcessFlowChart");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label466.Text = FileUpload14.FileName;
                                Label467.Text = FileUpload14.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }


    }
    protected void BtnListofDir1_Click(object sender, EventArgs e)
    {

        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload15.HasFile)
            {
                if ((FileUpload15.PostedFile != null) && (FileUpload15.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload15.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload15.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PlantLayout");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload15.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "PlantLayout");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label469.Text = FileUpload15.FileName;
                                Label470.Text = FileUpload15.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }


    }
    protected void btndeetregack_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fupdeetregack.HasFile)
            {
                if ((fupdeetregack.PostedFile != null) && (fupdeetregack.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupdeetregack.PostedFile.FileName);
                    try
                    {

                        string[] fileType = fupdeetregack.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\DEETREGACK");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupdeetregack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupdeetregack.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "DEET Registration Acknowledgement");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hypdeetregack.Text = fupdeetregack.FileName;
                                lbldeetregack.Text = fupdeetregack.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

}
