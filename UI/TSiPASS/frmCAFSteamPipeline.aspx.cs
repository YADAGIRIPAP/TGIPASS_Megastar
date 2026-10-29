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

public partial class UI_TSiPASS_frmCAFSteamPipeline : System.Web.UI.Page
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
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }



            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }



        }

        if (!IsPostBack)
        {

            DataSet dsver = new DataSet();

            dsver = Gen.GetverifyofqueBoiler9SteamCFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);

                }
                else
                {
                    ViewState["Enable"] = "Y";
                }
            }

        }


        if (!IsPostBack)
        {
            //string res = Gen.RetriveStatusBoilersCFO(Session["ApplidA"].ToString());

            //if (res == "Y")
            //{

            //}
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityCFONewBoiler(Session["ApplidA"].ToString(), "67");
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                }
                else
                {
                    Response.Redirect("frmBoilerSteamTest.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

                }

            }



        }

        if (!IsPostBack)
        {

            getstates();
            DataSet ds = new DataSet();
            ds = Gen.GetdataofCFOBoilerSteam(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                FillDetails();

            }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        if (txtAllowedMaximumPresure.Text.Trim() == "")
        {
            txtAllowedMaximumPresure.Enabled = true;
            txtAllowedMaximumPresure.ReadOnly = false;
        }
        if (LabelErector.Text == "")
        {
            FileUploadErector.Enabled = true;
        }
    }


    protected void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlState.DataSource = ds.Tables[0];
        ddlState.DataTextField = "State_Name";
        ddlState.DataValueField = "State_id";
        ddlState.DataBind();
        ddlState.Items.Insert(0, "--Select--");

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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave1.Text == "Save")
        {
            if (trerector.Visible && trerector.Visible)// if new registration
            {
                if (LabelErector.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Erector Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trreqdoc.Visible)
            {
                if (LabelRequiredDoc.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Required Document Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trsteampipeline.Visible)
            {
                if (LabelSteam.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload SteamPipeline Drawings Document Attachment..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            
            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOBoilerSteam(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insertCFOBoilerSteampipeline(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtMakersNumber.Text, ddlBoilersUsedfor.SelectedValue, txtBoilerRatingSurface.Text.Trim(), txtAllowedMaximumPresure.Text, ddlerectorclass.SelectedItem.Text.Trim(), txtNameOfErector.Text, ddlState.SelectedValue, txtTotalLengthOfStreamPipeLine.Text, txtnoofvessels.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtlenupto.Text.Trim(), txtlenabove.Text.Trim());
                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insertCFOBoilerSteampipeline(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtMakersNumber.Text, ddlBoilersUsedfor.SelectedValue, txtBoilerRatingSurface.Text.Trim(), txtAllowedMaximumPresure.Text, ddlerectorclass.SelectedItem.Text.Trim(), txtNameOfErector.Text, ddlState.SelectedValue, txtTotalLengthOfStreamPipeLine.Text, txtnoofvessels.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtlenupto.Text.Trim(), txtlenabove.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Submission Failed..!</font>";
                }
            }
        }



    }
    void clear()
    {

        //txtRegistrationNumber.Text = ""; txtNameOfOwner.Text = ""; txtWhereStudied.Text = ""; txtDateOfInspection.Text = ""; txtDescriptionofboilersAge.Text = ""; txtMakersName.Text = "";
        //ddlTypeofBoiler.SelectedIndex = 0; ddlBoilersUsedfor.SelectedIndex = 0; txtMakersNumber.Text = ""; txtPlace.Text = ""; txtYear.Text = "";
        //txtAllowedMaximumPresure.Text = ""; txtEconomiserMarker.Text = ""; txtBoilerRatingSurface.Text = ""; txtMaximumContinousEvapration.Text = "";
        //txtClassofErector.Text = ""; txtNameOfErector.Text = ""; ddlState.SelectedIndex = 0; txtMaximumPresureofEconomiser.Text = "";
        //txtTotalLengthOfStreamPipeLine.Text = "";
        Response.Redirect("");


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (BtnDelete.Text == "Next")
        {
            if ((ViewState["Enable"] != null && ViewState["Enable"] != "" && ViewState["Enable"].ToString() == "Y") || Convert.ToString(Session["uid"])== "370298")
            {
                if (trerector.Visible && trerector.Visible)// if new registration
                {
                    if (LabelErector.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Erector Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        FileUploadErector.Enabled = true;
                        return;
                    }
                }
                if (trreqdoc.Visible)
                {
                    if (LabelRequiredDoc.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Required Document Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (trsteampipeline.Visible)
                {
                    if (LabelSteam.Text == "")
                    {
                        lblmsg0.Text = "<font color='red'>Please Upload Steam Pipeline Drawings Attachment..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }                
            }
            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOBoilerSteam(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insertCFOBoilerSteampipeline(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtMakersNumber.Text, ddlBoilersUsedfor.SelectedValue, txtBoilerRatingSurface.Text.Trim(), txtAllowedMaximumPresure.Text, ddlerectorclass.SelectedItem.Text.Trim(), txtNameOfErector.Text, ddlState.SelectedValue, txtTotalLengthOfStreamPipeLine.Text, txtnoofvessels.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtlenupto.Text.Trim(), txtlenabove.Text.Trim());
                if (result > 0)
                {

                    Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Boiler Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insertCFOBoilerSteampipeline(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtMakersNumber.Text, ddlBoilersUsedfor.SelectedValue, txtBoilerRatingSurface.Text.Trim(), txtAllowedMaximumPresure.Text, ddlerectorclass.SelectedItem.Text.Trim(), txtNameOfErector.Text, ddlState.SelectedValue, txtTotalLengthOfStreamPipeLine.Text, txtnoofvessels.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtlenupto.Text.Trim(), txtlenabove.Text.Trim());

                if (result > 0)
                {
                    Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Boiler Details Submission Failed..!</font>";
                }
            }


        }


    }
    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.GetdataofCFOBoilerSteam(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

           
            ddlBoilersUsedfor.SelectedValue = ds.Tables[0].Rows[0]["Boiler_User_for"].ToString();
            txtMakersNumber.Text = ds.Tables[0].Rows[0]["Reg_No_Boiler"].ToString();
           
            txtAllowedMaximumPresure.Text = ds.Tables[0].Rows[0]["Allowed_Max_Presure"].ToString();

            txtBoilerRatingSurface.Text = ds.Tables[0].Rows[0]["Boiler_ration"].ToString();
            txtNameOfErector.Text = ds.Tables[0].Rows[0]["Name_of_Erector"].ToString();
            getstates();
            ddlState.SelectedValue = ds.Tables[0].Rows[0]["State_Erector"].ToString();
            txtnoofvessels.Text = ds.Tables[0].Rows[0]["NumberofVesselsconnected"].ToString();
            txtTotalLengthOfStreamPipeLine.Text = ds.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine"].ToString();
            txtlenabove.Text = ds.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Above"].ToString();
            txtlenupto.Text = ds.Tables[0].Rows[0]["Tot_Lenght_Steam_PipeLine_Upto"].ToString();

            if (ds.Tables[0].Rows[0]["ErectorClass"].ToString().Trim() != "")
            {
                ddlerectorclass.SelectedItem.Text = ds.Tables[0].Rows[0]["ErectorClass"].ToString().Trim();
            }
            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");



                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                        if (sen.Contains("SteamErectorLicense"))
                        {
                            HyperLinkErector.NavigateUrl = sen;
                            HyperLinkErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelErector.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }

                        if (sen.Contains("SteamRequiredDoc"))
                        {
                            HyperLinkRequiredDoc.NavigateUrl = sen;
                            HyperLinkRequiredDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelRequiredDoc.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("SteamDrawings"))
                        {
                            HyperLinksteamdrawing.NavigateUrl = sen;
                            HyperLinksteamdrawing.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                            LabelSteam.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        }

                        
                    }
                    i++;
                }

            }

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
    protected void ddlstatus32_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus31_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddlstatus28_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBoilerSteamTest.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
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

    protected void BtnErector_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadErector.HasFile)
        {
            if ((FileUploadErector.PostedFile != null) && (FileUploadErector.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadErector.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadErector.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SteamErectorLicense");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadErector.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadErector.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SteamErectorLicense");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkErector.Text = FileUploadErector.FileName;
                            LabelErector.Text = FileUploadErector.FileName;
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
   
    protected void btnreqdoc_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadRequiredDoc.HasFile)
        {
            if ((FileUploadRequiredDoc.PostedFile != null) && (FileUploadRequiredDoc.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadRequiredDoc.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadRequiredDoc.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SteamRequiredDoc");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadRequiredDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadRequiredDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SteamRequiredDocuments");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinkRequiredDoc.Text = FileUploadRequiredDoc.FileName;
                            LabelRequiredDoc.Text = FileUploadRequiredDoc.FileName;
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
   
    protected void BtnSteam_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadSteam.HasFile)
        {
            if ((FileUploadSteam.PostedFile != null) && (FileUploadSteam.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadSteam.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadSteam.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SteamDrawings");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadSteam.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadSteam.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["ApplidA"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SteamDrawings");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLinksteamdrawing.Text = FileUploadSteam.FileName;
                            LabelSteam.Text = FileUploadSteam.FileName;
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
    protected void txtlenupto_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtlenupto.Text.Trim() != "")
            {
                if (txtlenabove.Text.Trim() != "")
                {
                    txtTotalLengthOfStreamPipeLine.Text = Convert.ToString(decimal.Add(Convert.ToDecimal(txtlenupto.Text), Convert.ToDecimal(txtlenabove.Text)));
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void txtlenabove_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtlenupto.Text.Trim() != "")
            {
                if (txtlenabove.Text.Trim() != "")
                {
                    txtTotalLengthOfStreamPipeLine.Text = Convert.ToString(decimal.Add(Convert.ToDecimal(txtlenupto.Text), Convert.ToDecimal(txtlenabove.Text)));
                    
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}