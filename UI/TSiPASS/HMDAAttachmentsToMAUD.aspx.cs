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

public partial class UI_TSiPASS_HMDAAttachmentsToMAUD : System.Web.UI.Page
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
        //BtnClear0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            DataSet dscheck = new DataSet();
            if (Request.QueryString[0].ToString() != null)
            {
                dscheck = Gen.GetShowQuestionaries(Request.QueryString[0].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque8(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (Convert.ToInt32(res) >= 3)
                {
                    //ResetFormControl(this);

                    //FileUpload1.Enabled = false;
                    //FileUpload2.Enabled = false;
                    ////FileUpload3.Enabled = false;
                    //FileUpload5.Enabled = false;
                    //FileUpload4.Enabled = false;
                    //FileUpload6.Enabled = false;
                    //FileUpload7.Enabled = false;
                    //FileUpload8.Enabled = false;
                    //ddlAttachmentType.Enabled = false;
                    //txtOthers.Enabled = false;
                    //FileUpload9.Enabled = false;
                }

            }
        }

        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();

            }
        }



        if (!IsPostBack)
        {
            //Session["Applid"] = "1005";
            //Session["Approvalid"] = "33";
            //Session["Deptid"] = "2";

            DataSet ds = new DataSet();
            ds = Gen.RetriveIsOfflineByAPPID(Session["Applid"].ToString());
            int count = ds.Tables[0].Rows.Count;

            for (int l = 0; l < count; l++)
            {
                
            }

        }

        if (!IsPostBack)
        {
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb"] = dtMyTableCertificate;
            //  Session["uid"] = "1000";
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
                }
            }
        }
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (LabelDetailed.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Detailed Report Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (LabelMaster.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Master Plan Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (LabelGoogle.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Google Map Attachment..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
          

        //int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

        //LinkButton myTextBox = grdDetails.Rows[indexing].FindControl("LinkButton1") as LinkButton;

        string result = Gen.sendMAUD_HMDACLU(Request.QueryString[1].ToString());
        if (result == "success")
        {
            lblmsg.Text = "<font color='green'>SuccessFully Send to MA&UD...!!</font>";
            //lblmsg0.Text = ;
            success.Visible = true;
            Failure.Visible = false;
            return;
        }
            //fillGrid();

    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        Response.Redirect("HMDAAttachmentsToMAUD.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        // Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
        // Response.Redirect("frmLegalAct_New.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
    void FillDetails()
    {
        // hdfFlagID.Value = "1000";
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("DetailedReportMAUD"))
                    {
                        lblDetailed.NavigateUrl = sen;
                        lblDetailed.Text = ds.Tables[0].Rows[i][1].ToString();
                        LabelDetailed.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("MasterPlanMAUD"))
                    {
                        LblMaster.NavigateUrl = sen;
                        LblMaster.Text = ds.Tables[0].Rows[i][1].ToString();
                        LabelMaster.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink2.NavigateUrl = sen;
                        //HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
                    }

                    if (sen.Contains("GoogleMapMAUD"))
                    {
                        LblGoogle.NavigateUrl = sen;
                        LblGoogle.Text = ds.Tables[0].Rows[i][1].ToString();
                        LabelGoogle.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink3.NavigateUrl = sen;
                        //HyperLink3.Text = ds.Tables[0].Rows[i][1].ToString();
                    }                  

                    i++;
                }
                gvCertificate.Visible = true;
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                this.gvCertificate.DataBind();

            }


        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {

      
            if (LabelDetailed.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload PCB Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
      

        
            if (LabelMaster.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload CommercialTaxes Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        
          if (LabelGoogle.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload TSIIC Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        

       
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

    

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
        //dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
        dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
        // dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
        // dtMyTable.Columns.Add("Girth", typeof(string));
        //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
        //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        //  dtMyTable.Columns.Add("Created_by", typeof(string));

        //   dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


        return dtMyTable;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUpload9.PostedFile != null) && (FileUpload9.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload9.PostedFile.FileName);
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

                string[] fileType = FileUpload9.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\OtherDocument");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    //int count = dir.GetFiles().Length;
                    //if (count == 0)
                    //    FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    //else
                    //{
                    //    if (count == 1)
                    //    {
                    //        string[] Files = Directory.GetFiles(newPath);
                    //        foreach (string file in Files)
                    //        {
                    //            File.Delete(file);
                    //        }
                    //        FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    //    }
                    //}
                    FileUpload9.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    int result = 0;
                    gvCertificate.Visible = true;
                    string other;
                    if (txtOthers.Text == "" || txtOthers.Text == null)
                        other = ddlAttachmentType.SelectedItem.Text;
                    else
                        other = txtOthers.Text;
                    AddDataToTableCeertificate(other, "", sFileName, (DataTable)Session["CertificateTb"]);

                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                    this.gvCertificate.DataBind();
                    //   result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, other, "b", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label5.Text = FileUpload9.FileName;
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
    protected void FileUpload1_Load(object sender, EventArgs e)
    {

    }

    protected void txtcontact6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAttachmentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAttachmentType.SelectedIndex == 11)
        {
            txtOthers.Visible = true;
        }
        else
        {
            txtOthers.Visible = false;
        }
    }

    private void AddDataToTableCeertificate(string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb");

            //  Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["Manf_ItemName"] = Manf_ItemName;
            //Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            //    Row["Created_by"] = Session["uid"].ToString().Trim();
            //   Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }



    protected void BtnSave2_Click1(object sender, EventArgs e)
    {

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvCertificate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }

    protected void BtnDetailed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileDetailed.PostedFile != null) && (FileDetailed.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileDetailed.PostedFile.FileName);
            try
            {
                string[] fileType = FileDetailed.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\DetailedReportMAUD");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileDetailed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileDetailed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DetailedReportMAUD", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblDetailed.Text = FileDetailed.FileName;
                        LabelDetailed.Text = FileDetailed.FileName;
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
    protected void ButtonMaster_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadMaster.PostedFile != null) && (FileUploadMaster.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadMaster.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadMaster.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\MasterPlanMAUD");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadMaster.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadMaster.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MasterPlanMAUD", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        LabelMaster.Text = FileUploadMaster.FileName;
                        LblMaster.Text = FileUploadMaster.FileName;
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
    protected void ButtonGoogle_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadGoogle.PostedFile != null) && (FileUploadGoogle.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadGoogle.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadGoogle.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\GoogleMapMAUD");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadGoogle.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadGoogle.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "GoogleMapMAUD", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        LblGoogle.Text = FileUploadGoogle.FileName;
                        LabelGoogle.Text = FileUploadGoogle.FileName;
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
    protected void btnback_Click(object sender, EventArgs e)
    {
        try
        {
             //Response.Redirect("HMDAAttachmentsToMAUD.aspx?cfeid=" + cfeid + "&uidno=" + uidno);
            string query = "2";
            string query1 = "Approval Under Process Beyond Time Limits";
            Response.Redirect("frmCFEDepartmentsApprovalProcessHmda.aspx?query=" + query + "&query1=" + query1);
        }
        catch (Exception ex)
        {
        }
    }
}