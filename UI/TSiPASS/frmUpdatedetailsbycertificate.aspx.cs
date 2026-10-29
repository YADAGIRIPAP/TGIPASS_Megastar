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
    byte[] Cast = new byte[36871];
    string CasteFileName = "";


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
        }
        else
        {

            if (fupWork1.PostedFile != null && fupWork1.PostedFile.ContentLength > 0)
                CastUpload();
        }
        
        
        //FillDetails();
        //if (Request.QueryString["intApplicationId"] != null)
        //{
        //    hdfFlagID0.Value = Request.QueryString["intApplicationId"];

        //    if (!IsPostBack)
        //    {
        //        FillDetails();

        //    }

        //}


        if (!IsPostBack)
        {
            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}

            //if (Session["Applid"].ToString().Trim() == "0")
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}

            getdistricts();
            Session["Cast"] = Cast;
            Session["CasteFileName"] = "";

        }

        if (fupWork1.HasFile)
        {
            Session["fupWork1"] = fupWork1;
            hdfUploadFile1.Value = fupWork1.FileName;
        }
        else if (Session["fupWork1"] != null)
        {
            fupWork1 = (FileUpload)Session["fupWork1"];
            hdfUploadFile1.Value = fupWork1.FileName;
        }


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
        }
    }



    void CastUpload()
    {

        Session["CasteFileName"] = System.IO.Path.GetFileName(fupWork1.PostedFile.FileName);

        try
        {
            string[] fileType = fupWork1.PostedFile.FileName.Split('.');
            int letterI = fileType.Length;

            if (fupWork1.FileContent.Length > 307200)
            {
                lblmsg.Text = " File size should be less than 300KB";
                success.Visible = true;
                Failure.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lblmsg.Text + "');", true);
                return;
            }
            Session["Cast"] = new byte[fupWork1.PostedFile.ContentLength];
            if (fileType[letterI - 1].ToUpper().Trim() == "PDF" || fileType[letterI - 1].ToUpper().Trim() == "DOC" || fileType[letterI - 1].ToUpper().Trim() == "JPG" || fileType[letterI - 1].ToUpper().Trim() == "GIF" || fileType[letterI - 1].ToUpper().Trim() == "JPEG" || fileType[letterI - 1].ToUpper().Trim() == "XLS")
            {
                HttpPostedFile Image = fupWork1.PostedFile;
                Image.InputStream.Read((byte[])Session["Cast"], 0, (int)fupWork1.PostedFile.ContentLength);
                lbl1.Text = Session["CasteFileName"].ToString().Trim();
            }

        }
        catch (Exception ex)
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg0.Text = "An Error Occured. Please Try Again!" + ex.Message;

        }

        finally
        {

        }
    }

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlLand_intDistrictid.DataSource = dsnew.Tables[0];
        ddlLand_intDistrictid.DataTextField = "District_Name";
        ddlLand_intDistrictid.DataValueField = "District_Id";
        ddlLand_intDistrictid.DataBind();
        ddlLand_intDistrictid.Items.Insert(0, "--Select--");

    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {


        if (BtnSave1.Text == "Submit")
        {


            lblmsg.Text = "";
            lblmsg0.Text = "";
            Failure.Visible = false;
            success.Visible = false;
            if (Session["CasteFileName"].ToString().Trim() == "")
            {
                lblmsg0.Text = "Please upload Certificate";
                Failure.Visible = true;
                success.Visible = false;
                string mesg1 = "Please upload Certificate";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mesg1 + "');", true);
                return;
            }


                 //int i = Gen.insertApprovalData(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text);


            int i = Gen.insertUploadCertificate(txtnameofUnit.Text, txtUID.Text, ddlLand_intDistrictid.SelectedValue.ToString(), txtaddress.Text, "0", Session["uid"].ToString(), "1000", ddlLand_intDistrictid0.SelectedValue.ToString(),(byte[])(Session["Cast"]), Session["CasteFileName"].ToString().Trim());
            //  Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text


            
            if (i != 999)
            {
                //txtGeo_Cordinate_Latitude.Text = "";
                //ddlStatus.SelectedIndex = 0;
                //txtremarks.Text = "";
                txtnameofUnit.Text = "";
                txtUID.Text = "";
                //txtunitlocation.Text = "";
                txtaddress.Text = "";
                //lblFileName.Text = "";
               
                lbl1.Text = "";
                ddlLand_intDistrictid.SelectedIndex = 0;
                ddlLand_intDistrictid0.SelectedIndex = 0;
                Session["CasteFileName"] = "";

                Response.Write("<script>alert('Updated Successfully..!')</script>");

            //    lblmsg.Text = "Updated Successfully";
            ////    Response.Redirect("frmDepartementDashboardNew.aspx");
            //    success.Visible = true;
            //    Failure.Visible = false;
            }
            else
            {
                lblmsg0.Text = "failed..";
                success.Visible = false;
                Failure.Visible = true;


            }


        }







       
    }
    void clear()
    {

        
       
       
    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
      

    }
    //void FillDetails()
    //{
    //    DataSet ds = new DataSet();

    //    try
    //    {
    //        //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

    //        ds = Gen.GetdataofApprovaldataAproval(Request.QueryString[0].ToString());


    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
    //            Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
    //            Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
    //            Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();

    //            hdfFlagID1.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
    //            hdfFlagID2.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
    //            hdfFlagID3.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();
    //        //    Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
    //            //Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
    //           // Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
    //            //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                
    //        }
    //    }

    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();

    //    }
    //    finally
    //    {

    //    }

          
    //}    
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
        Response.Redirect("frmUpdatedetailsbycertificate.aspx");
        
    }
    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{

    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //    string sFileDir = Server.MapPath("~\\Attachments");

    //    General t1 = new General();
    //    if (FileUpload1.HasFile)
    //    {
    //        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
    //            try
    //            {
    //                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
    //                //{
    //                //    //Save File on disk


    //                //if (FileUpload1.FileContent.Length > 102400 * 18)
    //                //{
    //                //     lblmsg0.Text = "size should be less than 600KB";
    //                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
    //                //    return;
    //                //}

    //                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
    //                {
    //                    //Create a new subfolder under the current active folder
    //                    newPath = System.IO.Path.Combine(sFileDir, "\\certificateDocument");//Request.QueryString[0].ToString() + 

    //                    // Create the subfolder
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int result = 0;
    //                    result = t1.InsertImagedata2("0", "1000", fileType[i - 1].ToUpper(), newPath, sFileName, "certificateDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                    //Session["Applid"].ToString()

    //                    if (result > 0)
    //                    {
    //                        //ResetFormControl(this);
    //                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                        lblFileName.Text = FileUpload1.FileName;
    //                        success.Visible = true;
    //                        Failure.Visible = false;
    //                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                        //fillNews(userid);
    //                    }
    //                    else
    //                    {
    //                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                        success.Visible = false;
    //                        Failure.Visible = true;
    //                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    }

    //                }
    //                else
    //                {
    //                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
    //                    success.Visible = false;
    //                    Failure.Visible = true;
    //                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //                }

    //            }
    //            catch (Exception)//in case of an error
    //            {
    //                //lblError.Visible = true;
    //                //lblError.Text = "An Error Occured. Please Try Again!";
    //                DeleteFile(newPath + "\\" + sFileName);
    //                // DeleteFile(sFileDir + sFileName);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
    //        success.Visible = false;
    //        Failure.Visible = true;
    //        //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
    //    }

    //}
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddlStatus.SelectedValue.ToString().Trim() == "14")
        //{
        //    rem.Visible = true;

        //}
        //else
        //{
        //    rem.Visible = false;

        //}

    }
}




