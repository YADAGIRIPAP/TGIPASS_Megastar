using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmCFOWaterDetails : System.Web.UI.Page
{
    General Gen = new General();
    String CFEID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["uid"]) != "" && Convert.ToString(Session["ApplidA"]) != "")
        {
            string Applid = Session["ApplidA"].ToString();

            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "171");

                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    Binddata();
                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        //Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        Response.Redirect("ForestTransitPermit.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }
                    else
                    {

                        Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/HomeDashboard.aspx");
        }

    }
    public void Binddata()
    {
        string intQuessionaireid = Session["ApplidA"].ToString();
        try
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("USP_GETCFOWATERDet", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = Convert.ToInt32(intQuessionaireid);
            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);

            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtinstalledCalpacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_InstalledCapacity"]);
                    txtflownumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_FlowMeterNumber"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Appl_Status"]) == "3")
                        ResetFormControl(this);
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    int c = ds.Tables[1].Rows.Count;
                    string sen, sen1, sen2;
                    int i = 0;


                    while (i < c)
                    {
                        sen2 = ds.Tables[1].Rows[i]["AttachmentFilePath"].ToString();
                        sen1 = sen2.Replace(@"\", @"/");
                        sen = sen1.Replace(@"E:/TS-iPASSFinal/", "~/");


                        if (sen.Contains("LandClearance"))
                        {

                            hplCapNoChangeCertf.NavigateUrl = sen;
                            hplCapNoChangeCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblOtherPlans.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                        }
                        if (sen.Contains("PCBClearance"))
                        {

                            hplNoMoreWaterCertf.NavigateUrl = sen;
                            hplNoMoreWaterCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblCellarFloor.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();

                        }
                        if (sen.Contains("Forestclearance"))
                        {


                            hplFlowMeterSealCertf.NavigateUrl = sen;
                            hplFlowMeterSealCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblGroundFloor.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();

                        }
                        if (sen.Contains("CADDeptEEcertificate"))
                        {

                            hplflowmwter.NavigateUrl = sen;
                            hplflowmwter.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblTerracePlan.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();

                        }
                        i++;
                    }


                }

            }
            connection.Close();
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SaveData();
        }
        catch (Exception ex) { throw ex; }

    }
    public string Validations()
    {
        string Erromsg = "";
        int slno = 1;
        if (string.IsNullOrEmpty(txtinstalledCalpacity.Text) || txtinstalledCalpacity.Text == "" || txtinstalledCalpacity.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please Enter Installed Capacity  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtflownumber.Text) || txtflownumber.Text == "" || txtflownumber.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please Enter Flow Meter Number  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplCapNoChangeCertf.Text) || hplCapNoChangeCertf.Text == "" || hplCapNoChangeCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload Land Clearance \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplNoMoreWaterCertf.Text) || hplNoMoreWaterCertf.Text == "" || hplNoMoreWaterCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload PCB Clearance  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplFlowMeterSealCertf.Text) || hplFlowMeterSealCertf.Text == "" || hplFlowMeterSealCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload Forest clearance ( if any ( optional))  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplflowmwter.Text) || hplflowmwter.Text == "" || hplflowmwter.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload I&CAD Dept EE certificate for Flow meter calibration and check  \\n";
            slno = slno + 1;
        }

        return Erromsg;
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmTradeLicenseDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
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
    protected void btnNext_Click(object sender, EventArgs e)
    {
        SaveData();
        Response.Redirect("ForestTransitPermit.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
    public void SaveData()
    {
        string Result = "";
        string intQuessionaireid = Session["ApplidA"].ToString();
        string CFOEnterpid = Session["uid"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        try
        {
            string erromsg = Validations();
            if (erromsg == "")
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("USP_INSCFOWATERDet", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intQuessionaireid", intQuessionaireid);
                cmd.Parameters.AddWithValue("@intCFOEnterpid", CFOEnterpid);
                cmd.Parameters.AddWithValue("@Irrg_InstalledCapacity", txtinstalledCalpacity.Text);
                cmd.Parameters.AddWithValue("@Irrg_FlowMeterNumber", txtflownumber.Text);
                cmd.Parameters.AddWithValue("@Created_by", Convert.ToString(Session["uid"]));
                cmd.Parameters.Add("@RESULT", SqlDbType.VarChar, 100);
                cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Result = cmd.Parameters["@RESULT"].Value.ToString();
                // int Result = cmd.ExecuteNonQuery();
                if (Result != "")
                {
                    lblmsg.Text = "Details Saved Succesfully ";
                    lblmsg.ForeColor = System.Drawing.Color.CornflowerBlue;
                }

            }
            else
            {
                string message = "alert('" + erromsg + "')";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", message, true);
                return;
            }

        }
        catch (Exception ex) { throw ex; }
        finally { connection.Close(); }
    }
    protected void btnCapNoChangeCertf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");
        CFEID = Convert.ToString(Session["uid"].ToString());
        General t1 = new General();
        if ((fupCapNoChangeCertf.PostedFile != null) && (fupCapNoChangeCertf.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupCapNoChangeCertf.PostedFile.FileName);
            try
            {
                string[] fileType = fupCapNoChangeCertf.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, CFEID + "\\LandClearance");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupCapNoChangeCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupCapNoChangeCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), CFEID, fileType[i - 1].ToUpper(), newPath, sFileName, "LandClearance", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplCapNoChangeCertf.Text = fupCapNoChangeCertf.FileName;
                        lblOtherPlans.Text = fupCapNoChangeCertf.FileName;
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

    protected void btnNoMoreWaterCertf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");
        CFEID = Convert.ToString(Session["uid"].ToString());
        General t1 = new General();
        if ((fupNoMoreWaterCertf.PostedFile != null) && (fupNoMoreWaterCertf.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupNoMoreWaterCertf.PostedFile.FileName);
            try
            {
                string[] fileType = fupNoMoreWaterCertf.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, CFEID + "\\PCBClearance");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupNoMoreWaterCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupNoMoreWaterCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), CFEID, fileType[i - 1].ToUpper(), newPath, sFileName, "PCBClearance", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplNoMoreWaterCertf.Text = fupNoMoreWaterCertf.FileName;
                        lblOtherPlans.Text = fupNoMoreWaterCertf.FileName;
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

    protected void btnFlowMeterSealCertf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");
        CFEID = Convert.ToString(Session["uid"].ToString());
        General t1 = new General();
        if ((fupFlowMeterSealCertf.PostedFile != null) && (fupFlowMeterSealCertf.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupFlowMeterSealCertf.PostedFile.FileName);
            try
            {
                string[] fileType = fupFlowMeterSealCertf.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, CFEID + "\\Forestclearance");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupFlowMeterSealCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupFlowMeterSealCertf.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), CFEID, fileType[i - 1].ToUpper(), newPath, sFileName, "Forestclearance", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplFlowMeterSealCertf.Text = fupFlowMeterSealCertf.FileName;
                        lblOtherPlans.Text = fupFlowMeterSealCertf.FileName;
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
    public static bool ValidateFileName(string fileName)
    {
        try
        {
            string pattern = @"[<>%$@&=!:*?|]";

            if (Regex.IsMatch(fileName, pattern))
            {
                return false;
            }
            return true;
        }
        catch (Exception ex)
        { throw ex; }
    }
    public static bool ValidateFileExtension(FileUpload Attachment)
    {
        try
        {
            string Attachmentname = Attachment.PostedFile.FileName;
            string[] fileType = Attachmentname.Split('.');
            int i = fileType.Length;

            if (i == 2)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        { throw ex; }
    }
    public void DeleteFile(string strFileName)
    {
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnflowmeter_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\CFOAttachments");
        CFEID = Convert.ToString(Session["uid"].ToString());
        General t1 = new General();
        if ((fupflowmetre.PostedFile != null) && (fupflowmetre.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupflowmetre.PostedFile.FileName);
            try
            {
                string[] fileType = fupflowmetre.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, CFEID + "\\CADDeptEEcertificate");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupflowmetre.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupflowmetre.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), CFEID, fileType[i - 1].ToUpper(), newPath, sFileName, "CADDeptEEcertificate", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplflowmwter.Text = fupflowmetre.FileName;
                        lblOtherPlans.Text = fupflowmetre.FileName;
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

    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
}