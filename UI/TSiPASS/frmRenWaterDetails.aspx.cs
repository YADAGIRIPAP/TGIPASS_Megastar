using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_frmRenWaterDetails : System.Web.UI.Page
{
    General Gen = new General();
    string RENID, Applid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["uid"]) != "")
        {
            //Session["Applid"] = "1";
            //string Applid = Session["ApplidA"].ToString();
            //Session["RENID"] = "1";
            //RENID = "1";
            if (!IsPostBack)
            {
               
                if (Request.QueryString.Count > 0)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = Gen.getdataofidentityREN(Request.QueryString[0].ToString(), "20");//Session["Applid"].ToString()
                    if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                    {
                        BindData();
                    }
                    else
                    {
                        if (Request.QueryString[1].ToString() == "N")
                        {
                            Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        }
                        else
                        {
                            Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                        }
                    }
                }
                else
                {
                    Response.Redirect("frmRenewalService.aspx");
                }
            }
        }

    }
    public void BindData()
    {
        string intQuessionaireid = Request.QueryString[0].ToString();
        try
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("USP_GETRenWaterDetails", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@intQuessionaireid", Convert.ToInt32(intQuessionaireid));
            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Convert.ToString(Session["uid"]);
            da.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtinstalledCalpacity.Text = Convert.ToString(ds.Tables[0].Rows[0]["InstalledCapacity"]);
                    txtWaterQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["WaterQuantum_mcft"]);
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
                        sen = sen1.Replace(@"C:/TS-iPASSFinal/", "~/");

                        if (sen.Contains("changeinCapacityofwithdrawl"))
                        {

                            hplCapNoChangeCertf.NavigateUrl = sen;
                            hplCapNoChangeCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblOtherPlans.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                        }
                        if (sen.Contains("drawingmorethanAllocatedwater"))
                        {

                            hplNoMoreWaterCertf.NavigateUrl = sen;
                            hplNoMoreWaterCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblOtherPlans.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                        }
                        if (sen.Contains("CADDeptEEcertificate"))
                        {

                            hplFlowMeterSealCertf.NavigateUrl = sen;
                            hplFlowMeterSealCertf.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
                            lblOtherPlans.Text = ds.Tables[1].Rows[i]["AttachmentFilename"].ToString();
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
    protected void BtnClear_Click(object sender, EventArgs e)
    {


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
        if (string.IsNullOrEmpty(txtWaterQuantity.Text) || txtWaterQuantity.Text == "" || txtWaterQuantity.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please Enter Quantum of Water withdrawn  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplCapNoChangeCertf.Text) || hplCapNoChangeCertf.Text == "" || hplCapNoChangeCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload EE certification for No change in Capacity of withdrawl  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplNoMoreWaterCertf.Text) || hplNoMoreWaterCertf.Text == "" || hplNoMoreWaterCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload EE certfication for not drawing more than Allocated water  \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(hplFlowMeterSealCertf.Text) || hplFlowMeterSealCertf.Text == "" || hplFlowMeterSealCertf.Text == null)
        {
            Erromsg = Erromsg + slno + ". Please upload I&CAD Dept EE certificate for Flow meter seal  \\n";
            slno = slno + 1;
        }

        return Erromsg;
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {

    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        SaveData();
        Response.Redirect("frmBoilerRenewals.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }
    public void SaveData()
    {
        string Result = "";
        string intQuessionaireid = Session["Applid"].ToString();
        string CFOEnterpid = Session["uid"].ToString();
        string waterdept = "20";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

        try
        {
            string erromsg = Validations();
            if (erromsg == "")
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("USP_InsRenWaterDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intQuessionaireid", intQuessionaireid);
                cmd.Parameters.AddWithValue("@intEnterpid", CFOEnterpid);
                cmd.Parameters.AddWithValue("@WaterDept", waterdept); 
                cmd.Parameters.AddWithValue("@InstalledCapacity", txtinstalledCalpacity.Text);
                cmd.Parameters.AddWithValue("@WaterQuantum_mcft", txtWaterQuantity.Text); 
              //  cmd.Parameters.AddWithValue("@ArrearAmount", Convert.ToDecimal(txtRequirement_Water.Text));
                cmd.Parameters.AddWithValue("@Created_by", Convert.ToString(Session["uid"]));
                cmd.Parameters.Add("@Result", SqlDbType.VarChar, 100);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Result = cmd.Parameters["@Result"].Value.ToString();
                // int Result = cmd.ExecuteNonQuery();
                if (Result != "")
                {
                    lblmsg.Text = "Record Inserted Succesfully";
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
        string sFileDir = Server.MapPath("~\\RENAttachments");

        General t1 = new General();
        if ((fupCapNoChangeCertf.PostedFile != null) && (fupCapNoChangeCertf.PostedFile.ContentLength > 0))
        {
            bool filename = ValidateFileName(fupCapNoChangeCertf.PostedFile.FileName);
            bool fileextension = ValidateFileExtension(fupCapNoChangeCertf);

            if (filename == false)
            {
                lblmsg0.Text = "<font color='red'>Document name should not contain symbols like  <, >, %, $, @, &,=, /</font>";
                success.Visible = false;
                Failure.Visible = true; return;
            }
            if (fileextension == false)
            {
                lblmsg0.Text = "<font color='red'>Document should not contain double extension (double . )..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (fupCapNoChangeCertf.PostedFile.ContentType != "application/pdf")
            {
                lblmsg0.Text = "<font color='red'>Please upolad PDF documents only..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (filename == true && fileextension == true)
            {
                string sFileName = System.IO.Path.GetFileName(fupCapNoChangeCertf.PostedFile.FileName);
                try
                {
                    //newPath = System.IO.Path.Combine(sFileDir, RENID + "\\changeinCapacityofwithdrawl");
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\changeinCapacityofwithdrawl");

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

                    //result = t1.InsertRenewalAttachement(Applid, Session["uid"].ToString(), "1", "1", fupCapNoChangeCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "changeinCapacityofwithdrawl");
                    result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fupCapNoChangeCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "changeinCapacityofwithdrawl");

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplCapNoChangeCertf.Text = fupCapNoChangeCertf.FileName;
                        hplCapNoChangeCertf.NavigateUrl = newPath + "\\" + sFileName;
                        success.Visible = true;
                        Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Upload Document...!</font>";
            //lblmsg0.Text = lblmsg0.Text + "\\n <font color='red'>Please Upload PDF files only...!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }


    }

    protected void btnNoMoreWaterCertf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\RENAttachments");

        General t1 = new General();
        if ((fupNoMoreWaterCertf.PostedFile != null) && (fupNoMoreWaterCertf.PostedFile.ContentLength > 0))
        {
            bool filename = ValidateFileName(fupNoMoreWaterCertf.PostedFile.FileName);
            bool fileextension = ValidateFileExtension(fupNoMoreWaterCertf);

            if (filename == false)
            {
                lblmsg0.Text = "<font color='red'>Document name should not contain symbols like  <, >, %, $, @, &,=, /</font>";
                success.Visible = false;
                Failure.Visible = true; return;
            }
            if (fileextension == false)
            {
                lblmsg0.Text = "<font color='red'>Document should not contain double extension (double . )..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (fupNoMoreWaterCertf.PostedFile.ContentType != "application/pdf")
            {
                lblmsg0.Text = "<font color='red'>Please upolad PDF documents only..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (filename == true && fileextension == true)
            {
                string sFileName = System.IO.Path.GetFileName(fupNoMoreWaterCertf.PostedFile.FileName);
                try
                {
                    //newPath = System.IO.Path.Combine(sFileDir, RENID + "\\drawingmorethanAllocatedwater");
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\drawingmorethanAllocatedwater");

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

                    //result = t1.InsertRenewalAttachement(Applid, Session["uid"].ToString(), "1", "1", fupNoMoreWaterCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "drawingmorethanAllocatedwater");
                    result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fupNoMoreWaterCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "drawingmorethanAllocatedwater");

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplNoMoreWaterCertf.Text = fupNoMoreWaterCertf.FileName;
                        hplNoMoreWaterCertf.NavigateUrl = newPath + "\\" + sFileName;
                        success.Visible = true;
                        Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Upload Document...!</font>";
            //lblmsg0.Text = lblmsg0.Text + "\\n <font color='red'>Please Upload PDF files only...!</font>";
            success.Visible = false;
            Failure.Visible = true;
        }

    }

    protected void btnFlowMeterSealCertf_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\RENAttachments");

        General t1 = new General();
        if ((fupFlowMeterSealCertf.PostedFile != null) && (fupFlowMeterSealCertf.PostedFile.ContentLength > 0))
        {
            bool filename = ValidateFileName(fupFlowMeterSealCertf.PostedFile.FileName);
            bool fileextension = ValidateFileExtension(fupFlowMeterSealCertf);

            if (filename == false)
            {
                lblmsg0.Text = "<font color='red'>Document name should not contain symbols like  <, >, %, $, @, &,=, /</font>";
                success.Visible = false;
                Failure.Visible = true; return;
            }
            if (fileextension == false)
            {
                lblmsg0.Text = "<font color='red'>Document should not contain double extension (double . )..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (fupFlowMeterSealCertf.PostedFile.ContentType != "application/pdf")
            {
                lblmsg0.Text = "<font color='red'>Please upolad PDF documents only..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (filename == true && fileextension == true)
            {
                string sFileName = System.IO.Path.GetFileName(fupFlowMeterSealCertf.PostedFile.FileName);
                try
                {
                    //newPath = System.IO.Path.Combine(sFileDir, RENID + "\\CADDeptEEcertificate");
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\CADDeptEEcertificate");

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

                  //  result = t1.InsertRenewalAttachement(Applid, Session["uid"].ToString(), "1", "1", fupFlowMeterSealCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "CADDeptEEcertificate");
                    result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fupFlowMeterSealCertf.PostedFile.ContentType, sFileName, newPath, "A", Session["uid"].ToString(), "CADDeptEEcertificate");

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplFlowMeterSealCertf.Text = fupFlowMeterSealCertf.FileName;
                        hplFlowMeterSealCertf.NavigateUrl = newPath + "\\" + sFileName;
                        success.Visible = true;
                        Failure.Visible = false;
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
            lblmsg0.Text = "<font color='red'>Please Upload Document...!</font>";
            //lblmsg0.Text = lblmsg0.Text + "\\n <font color='red'>Please Upload PDF files only...!</font>";
            success.Visible = false;
            Failure.Visible = true;
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
}