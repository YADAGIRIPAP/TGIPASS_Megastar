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

public partial class UI_TSiPASS_frmResponceQueriesRenewal : System.Web.UI.Page
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
    BoilerQueryResponseService.TSBoilerServiceImplService Boiler = new BoilerQueryResponseService.TSBoilerServiceImplService();
    BoilerQueryResponseService.planQR boilervo = new BoilerQueryResponseService.planQR();
    FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
    FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();
    BoilerService.TSBoilerServiceImplService BoilerRenewalservice = new BoilerService.TSBoilerServiceImplService();

    protected void Page_Load(object sender, EventArgs e)
    {
        //TextBox1.Text = Request.QueryString[1].ToString();
        //TextBox2.Text = Request.QueryString[2].ToString();
        //TextBox3.Text = Request.QueryString[3].ToString();
        //TextBox4.Text = Request.QueryString[4].ToString();
        //TextBox5.Text = Request.QueryString[5].ToString();
        //TextBox6.Text = Request.QueryString[6].ToString();
        //TextBox7.Text = Request.QueryString[7].ToString();

        //if (Session.Count <= 0)
        //{
        //    // Response.Redirect("../../frmUserLogin.aspx");
        //    Response.Redirect("~/Index.aspx");
        //}
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

        //DataSet dscheck1 = new DataSet();
        //dscheck1 = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim());
        //if (dscheck1.Tables[0].Rows.Count > 0)
        //{
        //    Session["Applid"] = dscheck1.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
        //}
        //else
        //{
        //    Session["Applid"] = "0";
        //}



        //if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        //{
        //    Response.Redirect("frmRenewaService.aspx");
        //}




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

            ds = Gen.GetQueryStatusByTransactionIDRenewal(Request.QueryString[0].ToString());


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
                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString() != null && ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() != "")
                {
                    txtdiscription.Text = ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim();
                }

                if (ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString() != null && ds.Tables[0].Rows[0]["QueryRespondRemarks"].ToString().Trim() != "")
                {
                    lblFileNameResponse.NavigateUrl = ds.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    lblFileNameResponse.Text = "Response Attachment";
                    //lblFileNameResponse.Text = ds.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                }
                //if (hdfFlagID1.Value == "266")
                //{
                //    Session["ApplidA"] = intQuessionaireid;
                //    Response.Redirect("frmLabourCFO.aspx?intApplicationId=" + intCFEEnterpid + "&next=N&Query=" + "Y&intApprovalid=" + hdfFlagID2.Value + "&Queryid=" + Request.QueryString[0].ToString());
                //}

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

            ds = Gen.GetQueryStatusByTransactionIDRenewal(Request.QueryString[0].ToString());


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


                intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                //Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
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
            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = Gen.InsertQueryDetailsRenewal(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
            // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            if (result > 0)
            {
                if (intApprovalid == "55")
                {
                    try
                    {
                        BoilerService.renewalResponseDetails boilerrenqueryvo = new BoilerService.renewalResponseDetails();
                        DataSet dsdeptquery = new DataSet();
                        dsdeptquery = Gen.GetQueryStatusByTransactionIDRenewalResponse(intQuessionaireid, "55");
                        if (dsdeptquery != null && dsdeptquery.Tables.Count > 0 && dsdeptquery.Tables[0].Rows.Count > 0)
                        {
                            string uidno = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                            boilerrenqueryvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                            boilerrenqueryvo.entrepreneurRemarks = dsdeptquery.Tables[0].Rows[0]["QueryRespondRemarks"].ToString();
                            boilerrenqueryvo.systemIP = "0:0:0:0";
                            boilerrenqueryvo.userID = dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();
                            BoilerService.queryResponseAttachment[] lst = null;
                            BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                            if (dsdeptquery.Tables[1].Rows.Count > 0)
                            {
                                DataTable dtraw = new DataTable();
                                dtraw = dsdeptquery.Tables[1];
                                lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                                if (dsdeptquery.Tables[1].Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {

                                        boilerqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                                        boilerqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                                        lst[k] = boilerqueryvo;
                                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                    }
                                }
                                else
                                {
                                    boilerqueryvo.documentName = "NA";
                                    boilerqueryvo.documentPath = "NA";
                                }
                                boilerrenqueryvo.queryResponseAttachments = lst;
                            }

                            string queryresponse = BoilerRenewalservice.renewalQueryResponse(boilerrenqueryvo);
                            if (queryresopnedesc == "SUCCESS")
                            {
                                Gen.UpdateDepartwebserviceflagREN(uidno, "56", "Q", queryresopnedesc, "Y");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                //ResetFormControl(this);
                //DataSet dsdept = new DataSet();
                //dsdept = Gen.GetQueryStatusByTransactionIDRenewalResponse(intQuessionaireid, intApprovalid);
                //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                //if (intApprovalid == "27")//BOILERS
                //{
                //    boilervo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                //    boilervo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString(); ;
                //    boilervo.systemIP = "0.0.0.0";
                //    boilervo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();
                //    BoilerQueryResponseService.queryResponseAttachment[] lst = null;
                //    if (dsdept.Tables[0].Rows.Count > 0)
                //    {
                //        DataTable dtraw = new DataTable();
                //        dtraw = dsdept.Tables[0];
                //        lst = new BoilerQueryResponseService.queryResponseAttachment[dtraw.Rows.Count];

                //        for (int k = 0; k < dtraw.Rows.Count; k++)
                //        {
                //            BoilerQueryResponseService.queryResponseAttachment boilerattachmentvo = new BoilerQueryResponseService.queryResponseAttachment();
                //            boilerattachmentvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                //            boilerattachmentvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                //            lst[k] = boilerattachmentvo;
                //            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                //            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                //        }
                //    }
                //    boilervo.queryResponseAttachments = lst;
                //    string boilerout = Boiler.insertIntoPlanApprovalQueryResponse(boilervo);
                //    if (boilerout == "SUCCESS")
                //    {
                //        Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "Y");
                //        int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                //    }
                //    else
                //    {
                //        Gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "Q", boilerout, "N");
                //    }
                //}
                //else
                //{
                //    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFO", intApprovalid);
                //}
                //DataSet dsMail = new DataSet();
                //dsMail = Gen.GetShowEmailidandMobileNumberCFO(intQuessionaireid);

                //if (dsMail.Tables[0].Rows.Count > 0)
                //{

                //    cmf.SendMailTSiPASSCFO(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                //}
                //if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //{
                //    //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                //    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                //}



                //Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
                lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                Response.Redirect("RenewalDashboard.aspx?Qnreid=" + Session["Applid"].ToString());
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
            // }
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
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\RENAttachments");

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
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\"+Session["Applid"] + "\\ResponseAttachment\\" + hdfFlagID1.Value);
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

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



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
}