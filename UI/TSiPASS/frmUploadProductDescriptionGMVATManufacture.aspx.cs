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
    string AttachmentFilepath="", AttachmentFileName="";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
    string FMB_File_Path;
    string FMB_File_Type;
    string FMB_File_Name;

    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBox1.Text = Request.QueryString[1].ToString();
        //TextBox2.Text = Request.QueryString[2].ToString();
        //TextBox3.Text = Request.QueryString[3].ToString();
        //TextBox4.Text = Request.QueryString[4].ToString();
        //TextBox5.Text = Request.QueryString[5].ToString();
        //TextBox6.Text = Request.QueryString[6].ToString();
        //TextBox7.Text = Request.QueryString[7].ToString();

        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        FillDetails();
        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();

            }

        }



     

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        lblmsg.Text = "";
        if (BtnSave1.Text == "Submit")
        {

           
                if (FileUpload1.HasFile)
                {
                }
                else
                {
                    //lblresult.Text = "<font color='red'>Upload FMB</font>";
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Please Upload Product Document";
                    return;
                }
           // }
            int i = 0;
            //Jytotshna On 03-06-2016
            FMB_File_Path = "";
            FMB_File_Type = "";
            FMB_File_Name = "";
            string newPath = "";
            string sFileDir = Server.MapPath("~\\TSVATExporters");
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int ij = fileType.Length;
                        if (fileType[ij - 1].ToUpper().Trim() == "PDF" || fileType[ij - 1].ToUpper().Trim() == "DOC" || fileType[ij - 1].ToUpper().Trim() == "JPG" || fileType[ij - 1].ToUpper().Trim() == "XLS" || fileType[ij - 1].ToUpper().Trim() == "XLSX" || fileType[ij - 1].ToUpper().Trim() == "DOCX" || fileType[ij - 1].ToUpper().Trim() == "ZIP" || fileType[ij - 1].ToUpper().Trim() == "RAR" || fileType[ij - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            //newPath = System.IO.Path.Combine(sFileDir, "1000");
                            if (Session.Count > 0)
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString());
                            }
                            else
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString());
                            }
                            //////////////
                            FMB_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                            FMB_File_Type = fileType[ij - 1].ToUpper().Trim();
                            FMB_File_Name = sFileName;
                            //////////////

                            if (!Directory.Exists(FMB_File_Path))
                                System.IO.Directory.CreateDirectory(FMB_File_Path);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(FMB_File_Path);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload1.PostedFile.SaveAs(FMB_File_Path + "\\" + FMB_File_Name);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(FMB_File_Path);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload1.PostedFile.SaveAs(FMB_File_Path + "\\" + FMB_File_Name);
                                }
                            }

                        }
                        else
                        {
                            //lblresult.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                            lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                            Failure.Visible = true;
                            success.Visible = false;
                            return;
                            //success.Visible = false;
                            //Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }

                i = Gen.updateProductDescriptionVATManufacture(Request.QueryString[0].ToString(), FMB_File_Type, FMB_File_Path, FMB_File_Name, Session["uid"].ToString(), txtGeo_Cordinate_Latitude.Text,ddlStatus.SelectedValue.ToString(),txtIndicatestate.Text,ddlStatus0.SelectedValue.ToString(),txtCountryName.Text);

                if (i != 999)
                {
                    lblmsg.Text = "Product Details Updated Successfully";
                    Response.Redirect("frmVATManufactureGM.aspx");
                    success.Visible = true;
                    Failure.Visible = false;
                }
                else
                {
                    lblmsg.Text = "failed..";
                    success.Visible = false;
                    Failure.Visible = true;


                }

            }









            // int i =0;
            //if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
            //{
            //    if (lblFileName.Text.Trim() != "")
            //    {
            //      i  = Gen.insertApprovalData(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text);
            //    }
            //    else
            //    {
            //        lblmsg.Text = "Please Upload Approval Document";
            //        success.Visible = true;
            //        Failure.Visible = false;
            //    }
            //}
            //else
            //{
            //     i = Gen.insertApprovalData(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text);
            //}


            
            //if (i != 999)
            //{
            //    //hdfFlagID2
            //    //hdfFlagID3.Value
            //    DataSet dsMail1 = new DataSet();
            //  //  dsMail1 = Gen.GetShowEmailidandMobileNumber(hdfFlagID3.Value.ToString());//intQuessionaireid
            //    dsMail1 = Gen.GetShowEmailidandMobileNumbernew(hdfFlagID3.Value.ToString(), hdfFlagID2.Value.ToString());
            //    if (dsMail1.Tables[0].Rows.Count > 0)
            //    {



            //        cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Thank You.</b>");
            //    }
            //    if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
            //    {
            //        //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
            //        cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Thank You.");
            //    }
            //    txtGeo_Cordinate_Latitude.Text = "";
            //    ddlStatus.SelectedIndex = 0;
            //    txtremarks.Text = "";

            //    lblmsg.Text = "Status Updated Successfully";
            //    Response.Redirect("frmDepartementDashboardNew.aspx");
            //    success.Visible = true;
            //    Failure.Visible = false;
            //}
            //else
            //{
            //    lblmsg.Text = "failed..";
            //    success.Visible = false;
            //    Failure.Visible = true;


            //}


        }







       
    }
    void clear()
    {

        
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
      

    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

           // ds = Gen.GetdataofApprovaldataAproval(Request.QueryString[0].ToString());

            ds = Gen.GetGMExportdataVATmanufacturedata(Request.QueryString[0].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["EnterpriseName"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["TINNumber"].ToString().Trim();
               // Label449.Text = ds.Tables[0].Rows[0]["StatusofExporter"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["Commodities"].ToString().Trim();

                //hdfFlagID1.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //hdfFlagID2.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
               // hdfFlagID3.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();
            //    Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                //Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
               // Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                
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
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["pathAttachment"] == null)
    //        ViewState["pathAttachment"] = "";
    //    if (ViewState["AttachmentName"] == null)
    //        ViewState["AttachmentName"] = "";


    //    DataSet ds = new DataSet();

    //    try
    //    {
    //        //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

    //        ds = Gen.GetQueryStatusByTransactionID(Request.QueryString[0].ToString());


    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Label447.Text = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
    //            Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
    //            Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
    //            Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
    //            Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
    //            Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
    //            Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
    //            Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();

                
    //            intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
    //            intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
    //            intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
    //            intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
    //            intApprovalid=ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
    //            QueryRaiseDate=ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
    //            QueryDescription=ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
    //            QueryStatus=ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
    //            Created_by=ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
    //            Created_dt=ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
    //            //string number = "";
               

    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();

    //    }
    //    finally
    //    {

    //    }

    //    try
    //    {

    //    }

    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();

    //    }
    //    finally
    //    {

    //    }
    //    try
    //    {
    //        int result = 0;
    //        result = Gen.InsertQueryDetails(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), DateTime.Now.ToString(), "", Created_by, Created_dt, "", "");
    //        // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //        //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //        if (result > 0)
    //        {
    //            //ResetFormControl(this);
    //            Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
    //            lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            //this.Clear();
    //            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //            //fillNews(userid);
    //        }
    //        else
    //        {
    //            lblmsg0.Text = "<font color='red'>Query Details Adding Failed..!</font>";
    //            success.Visible = false;
    //            Failure.Visible = true;
    //            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //        }
    //        // }
    //        //Response.Redirect("frmViewAttachmentDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
    //    }

    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();

    //    }
    //    finally
    //    {

    //    }

    //}
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

    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //    string sFileDir = Server.MapPath("~\\Attachments");

    //    General t1 = new General();
    //    if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //    {
    //        //determine file name
    //        string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //        AttachmentFileName = sFileName;
    //        try
    //        {
    //            //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
    //            //{
    //            //    //Save File on disk


    //            //if (FileUpload1.FileContent.Length > 102400 * 18)
    //            //{
    //            //     lblmsg0.Text = "size should be less than 600KB";
    //            //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
    //            //    return;
    //            //}

    //            string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //            int i = fileType.Length;
    //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
    //            {
    //                //Create a new subfolder under the current active folder
    //                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ResponseAttachment");
    //                ViewState["pathAttachment"] = newPath;
    //                ViewState["AttachmentName"] = sFileName;

    //                // Create the subfolder
    //                if (!Directory.Exists(newPath))

    //                    System.IO.Directory.CreateDirectory(newPath);
    //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                int count = dir.GetFiles().Length;
    //                if (count == 0)
    //                    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                else
    //                {
    //                    if (count == 1)
    //                    {
    //                        string[] Files = Directory.GetFiles(newPath);

    //                        foreach (string file in Files)
    //                        {
    //                            File.Delete(file);
    //                        }
    //                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    }
    //                }

    //                AttachmentFilepath = newPath + "\\" + sFileName;
    //                int result = 0;

    //                result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                if (result > 0)
    //                {
    //                    //ResetFormControl(this);
    //                    lblmsg.Text = "Attachment Successfully Added";
    //                    lblmsg.Visible = true;
    //                    lblmsg.Visible = false;
    //                    Label440.Text= FileUpload1.FileName;
    //                    success.Visible = true;
    //                    Failure.Visible = false;
    //                    Response.Write("<script>alert('Attachment Successfully Added')</script> ");



    //                    //fillNews(userid);
    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "Attachment Added Failed";
    //                    lblmsg0.Visible = true;
    //                    lblmsg.Visible = false;
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                }

    //            }
    //            else
    //            {
    //                lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
    //                lblmsg0.Visible = true;
    //                lblmsg.Visible = false;
    //                success.Visible = false;
    //                Failure.Visible = true;
    //                Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //            }
    //        }
    //        catch (Exception)//in case of an error
    //        {
    //            //lblError.Visible = true;
    //            //lblError.Text = "An Error Occured. Please Try Again!";
    //            DeleteFile(newPath + "\\" + sFileName);
    //            // DeleteFile(sFileDir + sFileName);
    //        }
    //    }​
    //}
    protected void BtnClear_Click1(object sender, EventArgs e)
    {

        
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {

        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\TSVATExports");

        General t1 = new General();
        if (FileUpload1.HasFile)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
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

                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString());//\\ApprovalDocument\\

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
            //            result = t1.InsertImagedataApproval(hdfFlagID3.Value, Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ApprovalDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID2.Value, hdfFlagID1.Value);
                        
                        //result = t1.updateProductDescription(Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString());

                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFileName.Text = FileUpload1.FileName;
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
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlStatus.SelectedValue.ToString().Trim() == "14")
        {
            rem.Visible = true;

        }
        else
        {
            rem.Visible = false;

        }

    }
    protected void ddlStatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue.ToString() == "Yes")
        {
            rem.Visible = true;

        }
        else
        {
            rem.Visible = false;

        }

    }
    protected void ddlStatus0_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus0.SelectedValue.ToString() == "Yes")
        {
            remnew.Visible = true;

        }
        else
        {
            remnew.Visible = false;

        }


    }
}




