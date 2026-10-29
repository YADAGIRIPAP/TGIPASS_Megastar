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
//coding done by Jyotshna as on 09-05-2016 
//tables: td_GrievanceDet,tbl_Users
//procedures: InsGrevience
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string Grivance_File_Path, Grivance_File_Type, Grievnace_FileName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}

        if (!IsPostBack)
        {
            getdistricts();
            GetDepartment();

            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            ddlintLineofActivity.Items.Insert(0, "--Select--");
            success.Visible = false;
            Failure.Visible = false;
            Label574.Visible = false;
            TxtSanctionedDate.Visible = false   ;
            reqfvmob3.Visible = false;
        }
        
    }
    void clear()
    {

        txtindname.Text = "";
        // ddldept.SelectedIndex=0;
        ddlMandal.SelectedIndex = 0;
        txtAmount.Text = "";
        txtBankName.Text = "";
        txtRegDate.Text = "";
        ddlStatus.SelectedIndex = 0;
        ddldist.SelectedIndex = 0;


        txtEmail.Text = "";
        txtMob.Text = "";
        ddldist.SelectedIndex = 0;

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();

       // txtSub.Text = "";
        //txtDesc.Text = "";
    }

    
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //////////////
        //Grivance_File_Path = "";
        //Grivance_File_Type = "";
        //Grievnace_FileName = "";
        ////////////////
        ////int j = Gen.InsGrevience(txtindname.Text.Trim(),ddldept.SelectedValue.ToString(),txtEmail.Text.Trim(),txtMob.Text.Trim(),ddldist.SelectedValue,txtSub.Text.Trim(),txtDesc.Text.Trim(),"", "","", Session["uid"].ToString());
        //// Create the subfolder
        //string newPath = "";
        //string sFileDir = Server.MapPath("~\\Grievance");

        //General t1 = new General();
        //if (FileUpload.HasFile)
        //{
        //    if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
        //    {
        //        //determine file name
        //        string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
        //        try
        //        {

        //            string[] fileType = FileUpload.PostedFile.FileName.Split('.');
        //            int i = fileType.Length;
        //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
        //            {
        //                //Create a new subfolder under the current active folder
        //                //newPath = System.IO.Path.Combine(sFileDir, "1000");
        //                if (Session.Count > 0)
        //                {
        //                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
        //                }
        //                else
        //                {
        //                    newPath = System.IO.Path.Combine(sFileDir,"1000");
        //                }
        //                //////////////
        //                Grivance_File_Path = newPath+System.DateTime.Now.ToString("ddMMyyyyhhmmss");
        //                Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
        //                Grievnace_FileName = sFileName;
        //                //////////////

        //                if (!Directory.Exists(Grivance_File_Path))

        //                    System.IO.Directory.CreateDirectory(Grivance_File_Path);
        //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
        //                int count = dir.GetFiles().Length;
        //                if (count == 0)
        //                    FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
        //                else
        //                {
        //                    if (count == 1)
        //                    {
        //                        string[] Files = Directory.GetFiles(Grivance_File_Path);

        //                        foreach (string file in Files)
        //                        {
        //                            File.Delete(file);
        //                        }
        //                        FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
        //                //success.Visible = false;
        //                //Failure.Visible = true;
        //            }

        //        }
        //        catch (Exception)//in case of an error
        //        {
        //            DeleteFile(newPath + "\\" + sFileName);
        //        }
        //    }
        //}
        
        //int j = Gen.InsGrevience(txtindname.Text.Trim(), ddldept.SelectedValue.ToString(), txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldist.SelectedValue, txtSub.Text.Trim(), txtDesc.Text.Trim(),Grivance_File_Path,Grivance_File_Type,Grievnace_FileName, "1000");

        if (BtnSave.Text == "Submit")
        {

            int z = Gen.insertLoanDetails(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddlMandal.SelectedValue.ToString(), txtBankName.Text, txtRegDate.Text, txtAmount.Text, ddlStatus.SelectedValue.ToString(), ddlintLineofActivity.SelectedValue,txtBankBranchName.Text,TxtSanctionedDate.Text);

            if (z != 999)
            {

                string applno=System.DateTime.Now.Year.ToString()+"-LOAN-"+z.ToString();

                int w = Gen.UpdateApplNoofloanDetails(z.ToString(), applno.ToString());

                string maildesc = "<H2>TSiPASS TSiPASS MIS Loan Registration</H2><br><br> Dear " + txtindname.Text.Trim() + "<br><br> Loan Details is Submitted Your Application No:<b> " + applno.ToString() + "</b> <br/><br/> Thank You";

                //cmf.SendMailGriev("fss.jyotshna@gmail.com",maildesc);
                //cmf.SendMailGriev(txtEmail.Text, maildesc);
                cmf.SendMailLoan(txtEmail.Text, maildesc);
                //string maildept = "";
                //if (Session.Count > 0)
                //{
                //    maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: " + Session["username"].ToString() + "<br><br>With the Subject: " + txtSub.Text;
                //    maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>" + Session["username"].ToString() + "</b>";
                //}
                //else
                //{
                //    maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: Guest<br><br>With the Subject: " + txtSub.Text;
                //    maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>Guest</b>";
                //}


                //DataSet dsdept = Gen.GetDepartmentbyid(ddldept.SelectedValue.ToString());
                ////cmf.SendMailGriev(dsdept.Tables[0].Rows[0]["Email"].ToString(), maildept);
                //cmf.SendMailGriev("fss.jyotshna@gmail.com", maildept);

                clear();

                Response.Redirect("ResultLoanDetails.aspx?id=" + z.ToString());


                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Submited Successfully..!";

            }


        }



        //if (Session.Count > 0)
        //{
        //    int j = Gen.InsGrevience(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(), txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, Session["uid"].ToString());
        //}
        //else
        //{
        //    int j = Gen.InsGrevience(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(), txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, "");
        //}


        //string maildesc = txtindname.Text.Trim() + " Grievance is Submitted for the Department: " + ddldept.SelectedItem.Text.Trim() + "<br><br>With the Description: " + txtDesc.Text;
        
        ////cmf.SendMailGriev("fss.jyotshna@gmail.com",maildesc);
        //cmf.SendMailGriev(txtEmail.Text, maildesc);
        //string maildept="";
        //if (Session.Count > 0)
        //{
        //    maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: " + Session["username"].ToString() + "<br><br>With the Subject: " + txtSub.Text;
        //    maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>" + Session["username"].ToString() + "</b>";
        //}
        //else
        //{
        //    maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: Guest<br><br>With the Subject: " + txtSub.Text;
        //    maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>Guest</b>";
        //}
        
        
        //DataSet dsdept = Gen.GetDepartmentbyid(ddldept.SelectedValue.ToString());
        ////cmf.SendMailGriev(dsdept.Tables[0].Rows[0]["Email"].ToString(), maildept);
        //cmf.SendMailGriev("fss.jyotshna@gmail.com", maildept);
        
        //lblmsg.Text = "Submited Successfully..!";
        
        //clear();
    }
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        ddldist.DataSource = dsnew.Tables[0];
        ddldist.DataTextField = "District_Name";
        ddldist.DataValueField = "District_Id";
        ddldist.DataBind();
        ddldist.Items.Insert(0, "--Select--");
    }
    protected void GetDepartment()
    {
        //DataSet dsd = new DataSet();
        //dsd = Gen.GetDepartment();
        //ddldept.DataSource = dsd.Tables[0];
        //ddldept.DataValueField = "Dept_Id";
        //ddldept.DataTextField = "Dept_Full_name";
        //ddldept.DataBind();
        //ddldept.Items.Insert(0, "--Select--");
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


    protected void BtnUpload_Click(object sender, EventArgs e)
    {

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldist.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");


    }

    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddldist.SelectedValue != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex == 4 || ddlStatus.SelectedIndex == 3)
        {
            Label574.Visible = true;
            TxtSanctionedDate.Visible = true;
            reqfvmob3.Visible = true;
        }
        else
        {
            Label574.Visible = false;
            TxtSanctionedDate.Visible = false;
            reqfvmob3.Visible = false;
        }
    }
}
