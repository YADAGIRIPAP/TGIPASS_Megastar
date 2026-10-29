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
    int n1;

    static DataTable dtMyTable;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
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
            }
            else
            {
                Session["Applid"] = "0";
            }


            string res = Gen.RetriveStatusCFO(Session["Applid"].ToString());
            ////string res = Gen.RetriveStatus("1002");


            if (Convert.ToInt32(res) >= 3)
            {

                ResetFormControl(this);

            }

            DataSet ds = new DataSet();
            ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
        }

        if (!IsPostBack)
        {

            //string res = Gen.RetriveStatusPCBCFO(Session["Applid"].ToString());

            //if (res == "Y")
            //{

            //}
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityCFONew(Session["Applid"].ToString(), "1");
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {


            }

            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    //Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

                }

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

    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.ViewAttachmentCFO(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int c = ds.Tables[0].Rows.Count;
            string sen, sen1, sen2;
            int i = 0;

            while (i < c)
            {
                sen2 = ds.Tables[0].Rows[i][0].ToString();
                sen1 = sen2.Replace(@"\", @"/");
                //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                if (sen1.Contains("CFOAttachments"))
                {
                    sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");
                    if (sen.Contains("B1Form"))
                    {
                        lblFileName.NavigateUrl = sen;
                        lblFileName.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label444.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("B2Form"))
                    {
                        Label1.NavigateUrl = sen;
                        Label1.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label445.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("HazForm"))
                    {
                        Label2.NavigateUrl = sen;
                        Label2.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label446.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("CompForm"))
                    {
                        Label4.NavigateUrl = sen;
                        Label4.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label447.Text = ds.Tables[0].Rows[i][1].ToString();
                    }
                }
                i++;
            }

        }

    }

    protected void BtnSave3_Click(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PCB_B1Form");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B1 FORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName.Text = FileUpload1.FileName;
                            Label444.Text = FileUpload1.FileName;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if (FileUpload2.HasFile)
        {
            if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PCB_B2Form");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B2 FORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label1.Text = FileUpload2.FileName;
                            Label445.Text = FileUpload2.FileName;
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PCB_HazForm");
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

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HazFORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label2.Text = FileUpload3.FileName;
                            Label446.Text = FileUpload3.FileName;
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\CFOAttachments");

        General t1 = new General();
        if (FileUpload5.HasFile)
        {
            if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\PCB_CompForm");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "CompFORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label4.Text = FileUpload5.FileName;
                            Label447.Text = FileUpload5.FileName;
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
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        if (Label444.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload B1 Form Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label445.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload B2 Form Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label446.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Hazardous Form Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (Label447.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Compliance Report Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        //Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
        Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCAFBoilersDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
}




