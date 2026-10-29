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
       
        if (Session.Count <= 0)
        {
            //Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            success0.Visible = false;
            Failure0.Visible = false;

            Filldetails();

 
            //fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }


    void Filldetails()
    {
        DataSet ds = new DataSet();

        ds = Gen.GetdataofRenewalsbylogin(Session["User_Code"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblUnitName.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString();
            lblMobNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            lblUnitLocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();


        }


    }


    

    
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    fillGrid();   
    //}














    protected void ddlCateORg_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtEmNo35_TextChanged(object sender, EventArgs e)
    {
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        if (ChkApproval.Checked)
        {

            if (lblFileName2.Text == "" || lblFileName2.Text == "[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the Boilers Approval Attachment";
                return;
            }


            DataSet dsnew = new DataSet();
            dsnew = Gen.Fetchsearchbydeptandlogin(Session["uid"].ToString(), hdfFlagID0.Value);
            if (dsnew.Tables[0].Rows.Count > 0)
            {


                Failure0.Visible = true;

                lblmsg2.Text = "Already registerd for this Depatment";
                return;


            }


            int boilers = Gen.insertRenewaldata(Session["uid"].ToString(), lblFileName2.Text, "", ddlYear.SelectedValue,"", ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), hdfFlagID0.Value);

           // int boilers1 = Gen.insertRenewalDetailsApproval(txtEmNo51.Text, Session["uid"].ToString(), hdfFlagID0.Value);


            if (boilers != 999 )
            {

                success0.Visible = true;
                Failure0.Visible = false;
                lblmsg1.Text = "Success fully Registred";

            }







        }



  if (ChkApproval0.Checked)
        {

            if (lblFileName3.Text == "" || lblFileName3.Text == "[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the Fire Approval Attachment";
                return;
            }


            DataSet dsnew = new DataSet();
            dsnew = Gen.Fetchsearchbydeptandlogin(Session["uid"].ToString(), hdfFlagID1.Value);
            if (dsnew.Tables[0].Rows.Count > 0)
            {


                Failure0.Visible = true;

                lblmsg2.Text = "Already registerd for this Depatment";
                return;


            }


            int boilers = Gen.insertRenewaldata(Session["uid"].ToString(), lblFileName3.Text, "", ddlYear0.SelectedValue, "", ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), hdfFlagID1.Value);
           // int boilers1 = Gen.insertRenewalDetailsApproval(txtEmNo51.Text, Session["uid"].ToString(), hdfFlagID0.Value);


            if (boilers != 999)
            {

                success0.Visible = true;
                Failure0.Visible = false;
                lblmsg1.Text = "Success fully Registred";

            }







        }
        if (ChkApproval1.Checked)
        {

            if (lblFileName4.Text == "" || lblFileName4.Text == "[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the labour Approval Attachment";
                return;
            }


            DataSet dsnew = new DataSet();
            dsnew = Gen.Fetchsearchbydeptandlogin(Session["uid"].ToString(), hdfFlagID2.Value);
            if (dsnew.Tables[0].Rows.Count > 0)
            {


                Failure0.Visible = true;

                lblmsg2.Text = "Already registerd for this Depatment";
                return;


            }


            int boilers = Gen.insertRenewaldata(Session["uid"].ToString(), lblFileName4.Text, "", ddlYear1.SelectedValue, txtEmployes.Text, ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), hdfFlagID2.Value);
           // int boilers1 = Gen.insertRenewalDetailsApproval(txtEmNo51.Text, Session["uid"].ToString(), hdfFlagID0.Value);



            if (boilers != 999 )
            {

                success0.Visible = true;
                Failure0.Visible = false;
                lblmsg1.Text = "Success fully Registred";

            }







        }


        if (ChkApproval2.Checked)
        {

            if (lblFileName5.Text == "" || lblFileName5.Text=="[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the PCB Approval Attachment";
                return;
            }
            if (lblFileName7.Text == "" || lblFileName7.Text == "[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the Bank Details Attachment";
                return;
            }


            DataSet dsnew = new DataSet();
            dsnew = Gen.Fetchsearchbydeptandlogin(Session["uid"].ToString(), hdfFlagID3.Value);
            if (dsnew.Tables[0].Rows.Count > 0)
            {


                Failure0.Visible = true;

                lblmsg2.Text = "Already registerd for this Depatment";
                return;


            }


            int boilers = Gen.insertRenewaldata(Session["uid"].ToString(), lblFileName5.Text, lblFileName7.Text, ddlYear2.SelectedValue, "", ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), hdfFlagID3.Value);

            //int boilers1 = Gen.insertRenewalDetailsApproval(txtEmNo51.Text, Session["uid"].ToString(), hdfFlagID0.Value);



            if (boilers != 999 )
            {

                success0.Visible = true;
                Failure0.Visible = false;
                lblmsg1.Text = "Successfully Registred";

            }







        }
        if (ChkApproval3.Checked)
        {

            if (lblFileName6.Text == "" ||lblFileName6.Text=="[lblFileName]")
            {

                Failure0.Visible = true;

                lblmsg2.Text = "Please Upload the Factory Approval Attachment";
                return;
            }


            DataSet dsnew = new DataSet();
            dsnew = Gen.Fetchsearchbydeptandlogin(Session["uid"].ToString(), hdfFlagID4.Value);
            if (dsnew.Tables[0].Rows.Count > 0)
            {


                Failure0.Visible = true;

                lblmsg2.Text = "Already registerd for this Depatment";
                return;


            }


            int boilers = Gen.insertRenewaldata(Session["uid"].ToString(), lblFileName6.Text, "", ddlYear3.SelectedValue, "", ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString(), hdfFlagID4.Value);

          // int boilers1 = Gen.insertRenewalDetailsApproval(txtEmNo51.Text, Session["uid"].ToString(), hdfFlagID0.Value);



            if (boilers != 999 )
            {

                success0.Visible = true;
                Failure0.Visible = false;
                lblmsg1.Text = "Successfully Registred";

            }







        }







    }
   
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (CheckBoxList1.SelectedValue == "FACTORIES")
        //{
        //    renewalDate.Visible = true;
        //}
        //else
        //{
        //    renewalDate.Visible = false;
        //}
    }

    void Renewaldata()
    {
            


    }
    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
      //  BtnSave9.Visible = false;

        if (ChkApproval.Checked == true)
        {
            BoilerFields.Visible = true;
            boilersbtn.Visible = true;
           // BtnSave9.Visible = true;
            //Boilersupload.Visible = true;
            //boilersbtn.Visible = true;
            //Boilerfee.Visible = true;
            //Boilerfee1.Visible = true;
            //Boilersubmit.Visible = true;
          //  txtEmNo51.ReadOnly = true;
            DataSet ds = new DataSet();
            ds = Gen.getAmountofRenewal(ChkApproval.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

               // txtEmNo51.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                hdfFlagID0.Value = ds.Tables[0].Rows[0]["intRenewalDeptId"].ToString();
            }
          

        }
        else
        {
            BoilerFields.Visible = false;

            //Boilersupload.Visible = false;
            //boilersbtn.Visible = false;
            //Boilerfee.Visible = false;
            //Boilerfee1.Visible = false;
            //Boilersubmit.Visible = false;

          //  txtEmNo51.Text = "";
           // BtnSave9.Visible = false;

        }
        if (ChkApproval1.Checked == true || ChkApproval2.Checked == true || ChkApproval3.Checked == true || ChkApproval0.Checked == true || ChkApproval.Checked == true)
        {
            BtnSave9.Visible = true;
        }
        else { BtnSave9.Visible = false; }

    }
    protected void ChkApproval0_CheckedChanged(object sender, EventArgs e)
    {
       // BtnSave9.Visible = false;


        if (ChkApproval0.Checked == true)
        {
            FireFields.Visible = true;
           // BtnSave9.Visible = true;
            //Firebtn.Visible = true;
            //firefee.Visible = true;
            //firefee1.Visible = true;
            //FireSubmit.Visible = true;
           // BoilerFields.Visible = true;


            DataSet ds = new DataSet();
            ds = Gen.getAmountofRenewal(ChkApproval0.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

               // txtEmNo52.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intRenewalDeptId"].ToString();
            }

            //txtEmNo52.ReadOnly = true;
        }
        else
        {
            FireFields.Visible = false;
            //BtnSave9.Visible = false;
            //Fireupload.Visible = false;
            //Firebtn.Visible = false;
            //firefee.Visible = false;
            //firefee1.Visible = false;
            //FireSubmit.Visible = false;
         //   txtEmNo52.Text = "";


        }
        if (ChkApproval1.Checked == true || ChkApproval2.Checked == true || ChkApproval3.Checked == true || ChkApproval0.Checked == true || ChkApproval.Checked == true)
        {
            BtnSave9.Visible = true;
        }
        else { BtnSave9.Visible = false; }


    }
    protected void ChkApproval1_CheckedChanged(object sender, EventArgs e)
    {
       // BtnSave9.Visible = false;


        if (ChkApproval1.Checked == true)
        {
            labourFields.Visible = true;
            labourFields1.Visible = true;
          //  BtnSave9.Visible = true;
            //labourUpload.Visible = true;
            //labourbtn.Visible = true;
            //labourfee.Visible = true;
            //labourfee1.Visible = true;
            //labourSubmit.Visible = true;

            
            DataSet ds = new DataSet();
            ds = Gen.getAmountofRenewal(ChkApproval1.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

              //  txtEmNo53.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intRenewalDeptId"].ToString();
            }

           // txtEmNo53.ReadOnly = true;

        }
        else
        {
            labourFields.Visible = false;
            labourFields1.Visible = false;
           // BtnSave9.Visible = false;

            //labourUpload.Visible = false;
            //labourbtn.Visible = false;
            //labourfee.Visible = false;
            //labourfee1.Visible = false;
            //labourSubmit.Visible = false;
          //  txtEmNo53.Text = "";
        }
        if (ChkApproval1.Checked == true || ChkApproval2.Checked == true || ChkApproval3.Checked == true || ChkApproval0.Checked == true || ChkApproval.Checked == true)
        {
            BtnSave9.Visible = true;
        }
        else { BtnSave9.Visible = false; }
    }
    protected void ChkApproval2_CheckedChanged(object sender, EventArgs e)
    {
       // BtnSave9.Visible = false;

        if (ChkApproval2.Checked == true)
        {
            PCBFields.Visible = true;
            PCBFields1.Visible = true;
           // BtnSave9.Visible = true;
            //PCBUpload.Visible = true;
            //PCBBtn.Visible = true;
            //PCBfee.Visible = true;
            //PCBfee1.Visible = true;
            //PCBsubmit.Visible = true;

            DataSet ds = new DataSet();
            ds = Gen.getAmountofRenewal(ChkApproval2.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

              //  txtEmNo54.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                hdfFlagID3.Value = ds.Tables[0].Rows[0]["intRenewalDeptId"].ToString();
            }

           // txtEmNo54.ReadOnly = true;

        }
        else
        {
            PCBFields.Visible = false;
            PCBFields1.Visible = false;
           // BtnSave9.Visible = false;
            //PCBUpload.Visible = false;
            //PCBBtn.Visible = false;
            //PCBfee.Visible = false;
            //PCBfee1.Visible = false;
            //PCBsubmit.Visible = false;
        //    txtEmNo54.Text = "";

        }
        if (ChkApproval1.Checked == true || ChkApproval2.Checked == true || ChkApproval3.Checked == true || ChkApproval0.Checked == true || ChkApproval.Checked == true)
        {
            BtnSave9.Visible = true;
        }
        else { BtnSave9.Visible = false; }

    }
    protected void ChkApproval3_CheckedChanged(object sender, EventArgs e)
    {
       

        if (ChkApproval3.Checked == true)
        {
            FactoryFields.Visible = true;
           //FactoryFields1.Visible = true;
           
            //FactoryUpload.Visible = true;
            //Factorybtn.Visible = true;
            //FactoryFee.Visible = true;
            //FactoryFee1.Visible = true;
            //factoryperiod.Visible = true;
            //Factorysubmit.Visible = true;

            DataSet ds = new DataSet();
            ds = Gen.getAmountofRenewal(ChkApproval3.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {

                //txtEmNo55.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                hdfFlagID4.Value = ds.Tables[0].Rows[0]["intRenewalDeptId"].ToString();
            }



        }
        else
        {
            FactoryFields.Visible = false;
            //FactoryFields1.Visible = false;
            //BtnSave9.Visible = false;
            //FactoryUpload.Visible = false;
            //Factorybtn.Visible = false;
            //FactoryFee.Visible = false;
            //FactoryFee1.Visible = false;
            //factoryperiod.Visible = false;
            //Factorysubmit.Visible = false;


        }
        if (ChkApproval1.Checked == true || ChkApproval2.Checked == true || ChkApproval3.Checked == true || ChkApproval0.Checked == true || ChkApproval.Checked == true)
        {
            BtnSave9.Visible = true;
        }
        else { BtnSave9.Visible = false; }
    }

    protected void BtnSave4_Click(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalBoiler");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
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

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalBoiler");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName2.Text = FileUpload6.FileName;
                            Label572.Text = FileUpload6.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
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
    protected void BtnSave5_Click(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalFire");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
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

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalFire");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName3.Text = FileUpload7.FileName;
                            Label576.Text = FileUpload7.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }
    protected void BtnSave6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalLabour");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
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

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalLabour");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName4.Text = FileUpload8.FileName;
                            Label577.Text = FileUpload8.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }


    protected void BtnSave7_Click(object sender, EventArgs e)
    {

        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

        General t1 = new General();
        if (FileUpload9.HasFile)
        {
            if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalPCB");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName,newPath, "A", Session["uid"].ToString(), "RenewalPCB");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName5.Text = FileUpload9.FileName;
                            Label578.Text = FileUpload9.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }



    }
    protected void BtnSave8_Click(object sender, EventArgs e)
    {


        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalFactory");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
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

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalFactory");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName6.Text = FileUpload10.FileName;
                            Label579.Text = FileUpload10.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }


    }

    protected void BtnSave10_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Renewals");

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
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\RenewalPCB");
                        // Create the subfolder
                        ViewState["pathAttachment"] = newPath;
                        ViewState["AttachmentName"] = sFileName;
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

                        result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalPCB");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg1.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName7.Text = FileUpload11.FileName;
                            Label594.Text = FileUpload11.FileName;
                            success0.Visible = true;
                            Failure0.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg2.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success0.Visible = false;
                            Failure0.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }
                    else
                    {
                        lblmsg2.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        success0.Visible = false;
                        Failure0.Visible = true;
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
            lblmsg2.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            success0.Visible = false;
            Failure0.Visible = true;
            //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
        }



    }

   
}
