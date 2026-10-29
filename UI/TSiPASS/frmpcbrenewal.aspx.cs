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

public partial class UI_TSiPASS_frmpcbrenewal : System.Web.UI.Page
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
    //[getQuesssionerDetailsRen]


    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (Session.Count <= 0)
    //    {
    //        Response.Redirect("~/Index.aspx");
    //    }

    //    if (!IsPostBack)
    //    {
    //        DataSet dscheck = new DataSet();
    //        dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
    //        if (dscheck.Tables[0].Rows.Count > 0)
    //        {
    //            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
    //        }
    //        else
    //        {
    //            Session["Applid"] = "0";
    //        }

    //        DataSet dspcb = new DataSet();
    //        dspcb = Gen.GetdataRedirectionurltopcbREN(Session["Applid"].ToString(), "");
    //        if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
    //        {
    //            // string URI = "164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails";
    //            //string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
    //            //    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
    //            //     + "&serviceId=1" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString() + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString() + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString() + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString() + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString() + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString() + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString() + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString() + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString();
    //            //Response.Redirect("http://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
    //            //Response.Redirect("http://164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);

    //            string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
    //                "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
    //                 + "&serviceId=11" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString()
    //                 + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString()
    //                 + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString()
    //                 + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString()
    //                 + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString()
    //                 + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString()
    //                 + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString()
    //                 + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString()
    //                 + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString()
    //                 + "&buildArea=" + dspcb.Tables[0].Rows[0]["buildArea"].ToString() + "&industryTypeId=" + dspcb.Tables[0].Rows[0]["industryTypeId"].ToString() +
    //                 "&categoryId=" + dspcb.Tables[0].Rows[0]["categoryId"].ToString()
    //                 + "&uniqueUserId=" + dspcb.Tables[0].Rows[0]["uniqueUserId"].ToString() + "&intCFEEnterpid=" + dspcb.Tables[0].Rows[0]["intQuessionaireid"].ToString();

    //            Response.Redirect("http://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
    //        }

    //        if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
    //        {

    //            ResetFormControl(this);

    //        }

    //        //DataSet ds = new DataSet();
    //        //ds = Gen.ViewAttachmentREN(Session["Applid"].ToString());

    //        //if (ds.Tables[0].Rows.Count > 0)
    //        //{
    //        //    FillDetails();
    //        //}
    //        DataSet dsnew = new DataSet();
    //        dsnew = Gen.getdataofidentityREN(Request.QueryString[0].ToString(), "1");
    //        if (dsnew.Tables[0].Rows.Count > 0)
    //        {

    //        }
    //        else
    //        {
    //            if (Request.QueryString[1].ToString() == "N")
    //            {
    //                Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    //            }
    //            else
    //            {
    //                Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
    //            }
    //        }
    //    }
    //    if (!IsPostBack)
    //    {
    //        DataSet dsnew = new DataSet();
    //        dsnew = Gen.getdataofidentityREN(Session["Applid"].ToString(), "1");
    //        if (dsnew.Tables[0].Rows.Count > 0)
    //        {

    //        }
    //        else
    //        {
    //            if (Request.QueryString[1].ToString() == "N")
    //            {
    //                Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    //            }
    //            else
    //            {
    //                Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
    //            }
    //        }
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dspcb = new DataSet();
            dspcb = Gen.GetdataRedirectionurltopcbREN(Session["Applid"].ToString(), "");
            if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
            {
                // string URI = "164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails";
                //string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
                //    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
                //     + "&serviceId=1" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString() + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString() + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString() + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString() + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString() + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString() + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString() + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString() + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString();
                //Response.Redirect("http://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
                //Response.Redirect("http://164.100.163.19/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);

                string myParameters = "indName=" + dspcb.Tables[0].Rows[0]["insustryName"].ToString() + "&indDistrict=" + dspcb.Tables[0].Rows[0]["industryDistrict"].ToString().Trim() + "&indAddress=" + dspcb.Tables[0].Rows[0]["industryAddress"].ToString() + "&cafUniqueNo=" + dspcb.Tables[0].Rows[0]["cafUniqueNo"].ToString() +
                    "&indPhoneNo=" + dspcb.Tables[0].Rows[0]["industryMobile"].ToString() + "&indEmail=" + dspcb.Tables[0].Rows[0]["industryEmail"].ToString()
                     + "&serviceId=11" + "&indPin=" + dspcb.Tables[0].Rows[0]["indPin"].ToString() + "&village1=" + dspcb.Tables[0].Rows[0]["village1"].ToString()
                     + "&indSfNo=" + dspcb.Tables[0].Rows[0]["indSfNo"].ToString() + "&indRegNum=" + dspcb.Tables[0].Rows[0]["indRegNum"].ToString()
                     + "&indCapInvt=" + dspcb.Tables[0].Rows[0]["indCapInvt"].ToString() + "&indNewCapInvt=" + dspcb.Tables[0].Rows[0]["indNewCapInvt"].ToString()
                     + "&indStatus=" + dspcb.Tables[0].Rows[0]["indStatus"].ToString() + "&regdOfficeAddress=" + dspcb.Tables[0].Rows[0]["regdOfficeAddress"].ToString()
                     + "&occPin=" + dspcb.Tables[0].Rows[0]["occPin"].ToString() + "&nationality=" + dspcb.Tables[0].Rows[0]["nationality"].ToString()
                     + "&occPhoneCode=" + dspcb.Tables[0].Rows[0]["occPhoneCode"].ToString() + "&occPhoneNo=" + dspcb.Tables[0].Rows[0]["occPhoneNo"].ToString()
                     + "&occMobile=" + dspcb.Tables[0].Rows[0]["occMobile"].ToString() + "&occEmail=" + dspcb.Tables[0].Rows[0]["occEmail"].ToString()
                     + "&industryUnit=" + dspcb.Tables[0].Rows[0]["industryUnit"].ToString() + "&occName=" + dspcb.Tables[0].Rows[0]["occName"].ToString()
                     + "&tehsil=" + dspcb.Tables[0].Rows[0]["tehsil"].ToString() + "&jurisdictionOffice=" + dspcb.Tables[0].Rows[0]["jurisdictionOffice"].ToString()
                     + "&buildArea=" + dspcb.Tables[0].Rows[0]["buildArea"].ToString() + "&industryTypeId=" + dspcb.Tables[0].Rows[0]["industryTypeId"].ToString() +
                     "&categoryId=" + dspcb.Tables[0].Rows[0]["categoryId"].ToString()
                     + "&uniqueUserId=" + dspcb.Tables[0].Rows[0]["uniqueUserId"].ToString() + "&intQuessionaireid=" + dspcb.Tables[0].Rows[0]["intQuessionaireid"].ToString();

                Response.Redirect("https://tsocmms.nic.in/TLNPCB/industryRegMaster/doLoginWithDetails?" + myParameters);
            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                ResetFormControl(this);

            }

            DataSet ds = new DataSet();
            ds = Gen.ViewAttachmentREN(Session["Applid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityREN(Session["Applid"].ToString(), "1");
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
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

    protected void btnB1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\RENAttachments");

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

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B1 FORM");


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
    protected void btnB2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\RENAttachments");

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

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "B2 FORM");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink1.Text = FileUpload2.FileName;
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
    protected void btnForm1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\RENAttachments");

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
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\HWAFORM1");
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

                        result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "HWAFORM1");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink2.Text = FileUpload3.FileName;
                            Label4.Text = FileUpload3.FileName;
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
    protected void btnsave_Click(object sender, EventArgs e)
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
        if (Label4.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Form-1 under HW(M,H &TM) Rules for HWA Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
    }
    protected void btnnext_Click(object sender, EventArgs e)
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
        if (Label4.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Form-1 under HW(M,H &TM) Rules for HWA Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        Response.Redirect("frmLabourShopRenewal.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "N");// + hdfID.Value
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmRenewalDetail.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "P");// + hdfID.Value
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmpcbrenewal.aspx");
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

        DataSet ds = new DataSet();
        ds = Gen.ViewAttachmentREN(Session["Applid"].ToString());

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
                sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/RENAttachments")), "~/");
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
                    HyperLink1.NavigateUrl = sen;
                    HyperLink1.Text = ds.Tables[0].Rows[i][1].ToString();
                    Label445.Text = ds.Tables[0].Rows[i][1].ToString();
                }

                if (sen.Contains("HWAFORM1"))
                {
                    HyperLink2.NavigateUrl = sen;
                    HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    Label4.Text = ds.Tables[0].Rows[i][1].ToString();
                }


                i++;
            }

        }

    }
}