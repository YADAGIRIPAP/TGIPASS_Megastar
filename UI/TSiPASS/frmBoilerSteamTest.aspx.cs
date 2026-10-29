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

public partial class UI_TSiPASS_frmBoilerSteamTest : System.Web.UI.Page
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
        // Request.QueryString["intApplicationId"] = "1722";
        try
        {
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
                Response.Redirect("frmBoilerSteamTest.aspx");
            }

            if (!IsPostBack)
            {
                //string res = Gen.RetriveStatusBoilersCFO(Session["ApplidA"].ToString());

                //if (res == "Y")
                //{

                //}
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "64");
                if (dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {

                        Response.Redirect("frmCAFSteamPipeline.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                    }
                    else
                    {
                        Response.Redirect("frmBoilerInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

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



            if (txtdiscription.Text == "")
            {
                txtdiscription.ReadOnly = false;
            }

            if (Label453.Text == "")
            {
                FileUpload1.Enabled = true;
            }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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

            string cfeid = Request.QueryString[0].ToString().Trim();
            //string approvalid = Request.QueryString[1].ToString().Trim();
            ds = Gen.GetBoilerUploadDetailsCFO(cfeid, "64");



            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                //Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();


            }
            DataSet dsnew = new DataSet();
            dsnew = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (dsnew.Tables[0].Rows.Count > 0)
            {
                int c = dsnew.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");



                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    //sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");

                        if (sen.Contains("SteamTestAttachment"))
                        {
                            Label453.NavigateUrl = sen;
                            Label453.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //Label440.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                    }
                    i++;
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
        string payment = "", commonupdated = "";
        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.GetBoilerUploadDetailsCFO(Request.QueryString[0].ToString(), "64");


            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                //Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                //QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                payment = ds.Tables[0].Rows[0]["IsPayment"].ToString().Trim();
                commonupdated = ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
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
            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = 1;
            //result = Gen.InsertSteamtestUploadCFO(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
            // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            if (payment != "Y")
            {
                DataSet dslat = new DataSet();
                dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["ApplidA"].ToString());

                if (dslat.Tables[0].Rows.Count > 0)
                {
                    int quedata = Gen.updatenonPaymentinCFOQueNew(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Session["uid"].ToString(), "64", "0.00");
                }
                if (result > 0)
                {
                    if (intApprovalid == "64")
                    {
                        //string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                        //string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                        //string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                        DataSet dsdept = new DataSet();
                        dsdept = Gen.getdepartmentdetailsonuidCFO(Label447.Text.Trim(), intApprovalid);
                        //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                        {
                            string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                            //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                            //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                            // BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                            FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                            FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                            BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                            BoilerService.requestForSteamTest boilererectionvo = new BoilerService.requestForSteamTest();


                            //if (intApprovalid == "27")//BOILERS
                            //{
                            boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            boilererectionvo.enterpreneur_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                            boilererectionvo.system_ip = "0.0.0.0";
                            boilererectionvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
                            boilererectionvo.quessionaire_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

                            BoilerService.steamtestrequestdocument[] lst = null;
                            if (dsdept.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtraw = new DataTable();
                                dtraw = dsdept.Tables[0];
                                lst = new BoilerService.steamtestrequestdocument[dtraw.Rows.Count];

                                for (int k = 0; k < dtraw.Rows.Count; k++)
                                {
                                    BoilerService.steamtestrequestdocument boilererrectiondocumentsvo = new BoilerService.steamtestrequestdocument();
                                    boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                    boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                    lst[k] = boilererrectiondocumentsvo;
                                    //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                    //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                }
                            }
                            boilererectionvo.steamtestrequestdocument = lst;
                            //boilererectionvo.errdocuments = lst;
                            string boilerout = boilererection.insertIntoRequestforSteamTest(boilererectionvo);
                            if (boilerout == "SUCCESS")
                            {
                                Gen.UpdateDepartwebserviceflagCFO(Label447.Text.Trim(), intApprovalid, "C", boilerout, "Y");
                                try
                                {
                                    int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447.Text.Trim(), System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", intApprovalid);
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            else
                            {
                                Gen.UpdateDepartwebserviceflagCFO(Label447.Text.Trim(), intApprovalid, "C", boilerout, "N");
                            }
                        }
                    }


                    //Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
                    lblmsg.Text = "<font color='green'>Steam Report Added Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                    //Response.Redirect("DashboardNewCFO.aspx");
                    //this.Clear();
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Steam Report adding Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
                // }
                //Response.Redirect("frmViewAttachmentDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
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

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
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
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\SteamTestAttachment\\" + hdfFlagID1.Value);
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

                        //result = t1.InsertCFOAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "EreationPermissionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "SteamTestAttachment");



                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "Attachment Successfully Added";
                            lblmsg.Visible = true;
                            lblmsg.Visible = false;
                            Label453.Text = FileUpload1.FileName;
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        try
        {
            int result = 0;
            if (Label453.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Steam Test Request Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            else
            {
                DataSet ds = new DataSet();
                string payment = "", commonupdated = "";
                try
                {
                    //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

                    ds = Gen.GetBoilerUploadDetailsCFO(Request.QueryString[0].ToString(), "64");


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                        Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                        Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                        Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                        Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                        Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                        //Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                        //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                        hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                        //intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                        intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                        intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                        hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                        intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                        intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                        //QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                        //QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                        //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                        Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                        Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                        payment = ds.Tables[0].Rows[0]["IsPayment"].ToString().Trim();
                        commonupdated = ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
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
                    int msg = 0;
                    string queryresopnedesc = txtdiscription.Text.Trim();
                    msg = 1;
                    //result = Gen.InsertSteamtestUploadCFO(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
                    // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (payment != "Y")
                    {
                        DataSet dslat = new DataSet();
                        dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["ApplidA"].ToString());

                        if (dslat.Tables[0].Rows.Count > 0)
                        {
                            int quedata = Gen.updatenonPaymentinCFOQueNew(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Session["uid"].ToString(), "64", "0.00");
                        }
                        if (msg > 0)
                        {
                            if (intApprovalid == "64")
                            {
                                //string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                                //string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                                //string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                                DataSet dsdept = new DataSet();
                                dsdept = Gen.getdepartmentdetailsonuidCFO(Label447.Text.Trim(), intApprovalid);
                                //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                                    //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                                    //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                                    // BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                                    FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                                    FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                                    BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                                    BoilerService.requestForSteamTest boilererectionvo = new BoilerService.requestForSteamTest();


                                    //if (intApprovalid == "27")//BOILERS
                                    //{
                                    boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                                    boilererectionvo.enterpreneur_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                                    boilererectionvo.system_ip = "0.0.0.0";
                                    boilererectionvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
                                    boilererectionvo.quessionaire_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

                                    BoilerService.steamtestrequestdocument[] lst = null;
                                    if (dsdept.Tables[0].Rows.Count > 0)
                                    {
                                        DataTable dtraw = new DataTable();
                                        dtraw = dsdept.Tables[0];
                                        lst = new BoilerService.steamtestrequestdocument[dtraw.Rows.Count];

                                        for (int k = 0; k < dtraw.Rows.Count; k++)
                                        {
                                            BoilerService.steamtestrequestdocument boilererrectiondocumentsvo = new BoilerService.steamtestrequestdocument();
                                            boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                            boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                            lst[k] = boilererrectiondocumentsvo;
                                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                        }
                                    }
                                    boilererectionvo.steamtestrequestdocument = lst;
                                    //boilererectionvo.errdocuments = lst;
                                    string boilerout = boilererection.insertIntoRequestforSteamTest(boilererectionvo);
                                    if (boilerout == "SUCCESS")
                                    {
                                        Gen.UpdateDepartwebserviceflagCFO(Label447.Text.Trim(), intApprovalid, "C", boilerout, "Y");
                                        try
                                        {
                                            int k = Gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, Label447.Text.Trim(), System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", intApprovalid);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        Gen.UpdateDepartwebserviceflagCFO(Label447.Text.Trim(), intApprovalid, "C", boilerout, "N");
                                    }
                                }
                            }


                            //Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
                            lblmsg.Text = "<font color='green'>Steam Report Added Successfully..!</font>";
                            success.Visible = true;
                            Failure.Visible = false;
                            //Response.Redirect("DashboardNewCFO.aspx");
                            //this.Clear();
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Steam Report adding Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }
                        // }
                        //Response.Redirect("frmViewAttachmentDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
                    }
                }

                catch (Exception ex)
                {
                    lblmsg.Text = ex.ToString();

                }
                finally
                {

                }

                Response.Redirect("frmCAFSteamPipeline.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                lblmsg.Text = "<font color='green'>Errector Details Saved Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBoilerInspectUpload.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
    }
    protected void BtnClr_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmBoilerSteamTest.aspx" + Session["uid"].ToString());
    }
}