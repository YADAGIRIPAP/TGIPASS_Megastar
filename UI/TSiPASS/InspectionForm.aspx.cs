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
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            //Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
           
             // ddlDepartment.DataValueField = newds.Tables[0].Rows[0]["Department"].ToString().Trim();
           
            success.Visible = false;
            Failure.Visible = false;
            GetDepartment();
            getdistricts();
            if (Session["userlevel"].ToString().Trim() == "10")
            {
                ddlDepartment.SelectedValue = ddlDepartment.Items.FindByValue(Session["User_Code"].ToString().Trim()).Value;
                ddlDepartment.Enabled = false;
            }
            else
            {
                DataSet newds = new DataSet();
                newds = Gen.GetDepartmentForInspection(Session["User_Code"].ToString().Trim());
                ddlDepartment.SelectedValue = ddlDepartment.Items.FindByValue(newds.Tables[0].Rows[0]["intDeptid"].ToString().Trim()).Value;
                ddlDepartment.Enabled = false;
                txtDesignation.Text= newds.Tables[0].Rows[0]["Inspect_Designation"].ToString().Trim();
                txtDesignation.Enabled = false;
            }

        }

        
    }
    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();

        dsd = Gen.GetDepartmentFullName();
        ddlDepartment.DataSource = dsd.Tables[0];
        ddlDepartment.DataValueField = "Dept_Id";
        ddlDepartment.DataTextField = "Dept_Full_Name";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, "--Select--");
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedIndex == 0)
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Select--");
           
        }
        else
        {
            ddlMandal.Items.Clear();
            DataSet dsm = new DataSet();
            dsm = Gen.GetMandals(ddldistrict.SelectedValue);
            if (dsm.Tables[0].Rows.Count > 0)
            {
                ddlMandal.DataSource = dsm.Tables[0];
                ddlMandal.DataValueField = "Mandal_Id";
                ddlMandal.DataTextField = "Manda_lName";
                ddlMandal.DataBind();
                ddlMandal.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlMandal.Items.Clear();
                ddlMandal.Items.Insert(0, "--Select--");
            }
        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMandal.SelectedIndex == 0)
        {

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, "--Select--");
        }
        else
        {
            ddlVillage.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillage.DataSource = dsv.Tables[0];
                ddlVillage.DataValueField = "Village_Id";
                ddlVillage.DataTextField = "Village_Name";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlVillage.Items.Clear();
                ddlVillage.Items.Insert(0, "--Select--");
            }

           
        }
    }

    protected void ddltypofinspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltypofinspection.SelectedIndex == 4)
        {
            trOthers.Visible = true;
        }
        else
        {
            trOthers.Visible = false;
        }
    }
     
    
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //ddlDepartment.SelectedIndex = 0;
        ddldistrict.SelectedIndex = 0;
        ddlMandal.SelectedIndex = -1;
        ddlVillage.SelectedIndex = -1;
        txtAadhaar.Text = "";
        txtdateofinspection.Text = "";
        txtDesignation.Text = "";
        txtNameofUnit.Text = "";
        txtother.Text = "";
        txtPrmoterEmail.Text = "";
        txtPromotermobile.Text = "";
        txtTypofunit.Text = "";
        txtUID.Text = "";
        //Response.Redirect("~/InspectionForm.aspx", false);

    }
    
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            if (lblFileLink1.Text == "" && lblFileLink2.Text == "" && lblFileLink3.Text == "" && lblFileLink4.Text == "")
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Upload at least one Document";
            }
            else
            {
                int s = Gen.insertInspectionDet(txtNameofUnit.Text,
                    ddldistrict.SelectedItem.Text,
                    ddlMandal.SelectedItem.Text,
                    ddlVillage.SelectedItem.Text,
                    txtDesignation.Text,
                    txtdateofinspection.Text,
                    txtdateofinspection.Text,
                    txtUID.Text,
                    HdLink1.Value,
                    ddlDepartment.SelectedItem.Text,
                    ddltypofinspection.SelectedItem.Text,
                    txtdateofinspection.Text,
                    Session["uid"].ToString().Trim(),
                    txtdateofinspection.Text,
                    Session["uid"].ToString().Trim(),
                    txtdateofinspection.Text,
                    ddltypofinspection.SelectedValue,
                    ddlVillage.SelectedItem.Text,
                    HdLink2.Value,
                    HdLink3.Value,
                    HdLink4.Value,
                    txtTypofunit.Text,
                    txtPromotermobile.Text, txtPrmoterEmail.Text,
                    txtAadhaar.Text, txtother.Text);
                Session["Applid"] = s.ToString();

                if (s >= 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Inspection Details -  Succesfully Submitted";
                    txtUID.Text = "";
                    txtPromotermobile.Text = "";
                    txtPrmoterEmail.Text = "";
                    txtNameofUnit.Text = "";
                    txtDesignation.Text = "";
                    txtdateofinspection.Text = "";
                    ddlDepartment.SelectedIndex = 0;
                    ddldistrict.SelectedIndex = 0;
                    ddlMandal.SelectedIndex = 0;
                    ddltypofinspection.SelectedIndex = 0;
                    txtTypofunit.Text = "";
                    ddlVillage.SelectedIndex = 0;
                    lblFileLink1.Text = "";
                    lblFileLink2.Text = "";
                    lblFileLink3.Text = "";
                    lblFileLink4.Text = "";
                    txtAadhaar.Text = "";
                    txtother.Text="";
                    txtother.Visible = false;
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Text = "Inspection Details - Submition Failed";
                }
            }
            
        }
            
        catch (Exception ex)
        {


        }
        finally
        {
        }
    }

    protected void BtnUpload1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {                    
                    //Create a new subfolder under the current active folder
                    //newPath = System.IO.Path.Combine(sFileDir, sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss"));
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath)) 
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                   
                        lblfileUpload1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink1.Text = FileUpload5.FileName;
                        success.Visible = true;
                        Failure.Visible = false;                        
                        
                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink1.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload1.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload1.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload2.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink2.Text = FileUpload1.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink2.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload3.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink3.Text = FileUpload2.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink3.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload3.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload3.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }
    protected void BtnUpload4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Inspection");

        General t1 = new General();
        if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = sFileDir + "\\" + Session["uid"].ToString().Trim() + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))
                        System.IO.Directory.CreateDirectory(newPath);
                    try
                    {
                        FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);

                        lblfileUpload4.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblFileLink4.Text = FileUpload3.FileName;
                        success.Visible = true;
                        Failure.Visible = false;

                        string str = newPath.Replace(Server.MapPath(""), "https://ipass.telangana.gov.in");
                        HdLink4.Value = newPath + "\\" + sFileName;
                    }
                    catch
                    {
                        lblfileUpload4.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                else
                {
                    lblfileUpload4.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            catch (Exception)
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }
    }

    private void DeleteFile(string strFileName)
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
