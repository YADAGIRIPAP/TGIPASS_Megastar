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

public partial class UI_TSiPASS_frmCEIGComplainceReport : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";

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
        // FillDetails();

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


        DataSet dscheck1 = new DataSet();
        dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
        if (dscheck1.Tables[0].Rows.Count > 0)
        {
            Session["Applid"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
        }
        else
        {
            Session["Applid"] = "0";
        }



        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("frmQuesstionniareRegCFO.aspx");
        }




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



    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        // Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + hdfFlagID0.Value);


    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.GetQueryStatusByTransactionIDCFOCEIG(Session["Applid"].ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                // QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                string updatedflag = "";
                //if (ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != "" && ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != null)
                //{
                //    updatedflag = ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
                //}
                HyperLink1.Text = "Form Of Order";// ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
                trshortfalldoc.Visible = true;
                HyperLink1.NavigateUrl = ds.Tables[0].Rows[0]["CEIGDocument"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["ComplainceReport"].ToString().Trim() != null && ds.Tables[0].Rows[0]["CeigIntstageid"].ToString().Trim() == "13")
                {
                    trresponse_comp.Visible = false;
                    trresponse.Visible = false;
                    trsubmit.Visible = false;
                }
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
        if (ViewState["pathAttachment"] == null)
            ViewState["pathAttachment"] = "";
        if (ViewState["AttachmentName"] == null)
            ViewState["AttachmentName"] = "";


        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.GetQueryStatusByTransactionIDCFOCEIG(Session["Applid"].ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();


                //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";


            }
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

        }

        //try
        //{

        //}

        //catch (Exception ex)
        //{
        //    lblmsg.Text = ex.ToString();

        //}
        //finally
        //{

        //}

        try
        {
            if (txtdiscription.Text == "")
            {
                lblmsg0.Text = "Please Enter Response Text";
                Failure.Visible = true;
                lblmsg0.Focus();
                return;
            }

            if (Label440.Text == "" && Label440.Text == string.Empty)
            {
                lblmsg0.Text = "Please Upload Complaince Report Atachment";
                Failure.Visible = true;
                lblmsg0.Focus();
                return;
            }


            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = Gen.InsertQueryDetailsCFOCEIG(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
            // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            if (result > 0)
            {
                //ResetFormControl(this);
                try
                {
                    int k = Gen.InsertDeptDateTracingCFO("6", intQuessionaireid, "", null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", "16");
                }
                catch (Exception ex)
                {

                }

                DataSet dsdept = new DataSet();
                dsdept = Gen.GetQueryStatusByTransactionIDCFOCEIG(intQuessionaireid);
             
                CEIGCFOService.installationApplication ceifcfo = new CEIGCFOService.installationApplication();
                CEIGCFOService.queryReply ceigqueryvo = new CEIGCFOService.queryReply();
                CEIGCFOService.ApplicationServiceImplService ceigcfo = new CEIGCFOService.ApplicationServiceImplService();

                if (intApprovalid == "16")
                {
                    //ceigqueryvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                    ceigqueryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                    ceigqueryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                    //ceigqueryvo.registration_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["intQueryTrnsid"].ToString());
                    ceigqueryvo.reply_doc_path = dsdept.Tables[0].Rows[0]["ComplainceReport"].ToString();
                    ceigqueryvo.reply_description = dsdept.Tables[0].Rows[0]["CeigComplainceResponse"].ToString();
                    // ceigqueryvo.system_ip = "1.1.1.1";
                    ceigqueryvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                    string output = ceigcfo.updateInstallationCompliance(ceigqueryvo);
                    if (output == "SUCCESS")
                    {

                        Gen.UpdateDepartwebserviceflagCFO(ceigqueryvo.UID, intApprovalid, "CR", output, "Y");
                        try
                        {
                            //int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflagCFO(ceigqueryvo.UID, intApprovalid, "CR", output, "N");
                    }
                    //SUCCESS
                }
                DataSet dsMail = new DataSet();
                dsMail = Gen.GetShowEmailidandMobileNumberCFO(intQuessionaireid);

                if (dsMail.Tables[0].Rows.Count > 0)
                {

                    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b> Complaince Report has been submitted successfully.Further details will be communicated. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") : Complaince Report has been submitted successfully.Further details will be communicated. Thank You.");
                }



                //Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
                lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                Response.Redirect("DashboardNewCFO.aspx");
                //this.Clear();
                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                //fillNews(userid);
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Query Details Adding Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
            }
             //}
            //Response.Redirect("frmViewAttachmentDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

        }
        finally
        {

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
            //if (BtnSave1.Text == "Save")
            //{

            //}
            //else
            //{

            //}
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

    //public void DeleteFile(string strFileName)
    //{//Delete file from the server
    //    if (strFileName.Trim().Length > 0)
    //    {
    //        FileInfo fi = new FileInfo(strFileName);
    //        if (fi.Exists)//if file exists delete it
    //        {
    //            fi.Delete();
    //        }
    //    }
    //}

    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        //string sFileDir = Server.MapPath("~\\CFOAttachments");
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            AttachmentFileName = sFileName;
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
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\ComplainceReportCEIG");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

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

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label440.Text = FileUpload1.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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

    public static string getclientIP()
    {
        string result = string.Empty;
        string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (!string.IsNullOrEmpty(ip))
        {
            string[] ipRange = ip.Split(',');
            int le = ipRange.Length - 1;
            result = ipRange[0];
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        return result;
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



}