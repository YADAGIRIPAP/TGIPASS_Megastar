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

public partial class UI_TSiPASS_frmBoilerInspectionUpload : System.Web.UI.Page
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



        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("frmRenewaService.aspx");
        }




        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();
                getBoilerStages();
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

            ds = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");
            //Gen.GetQueryStatusByTransactionIDRenewal(Request.QueryString[0].ToString());
            //ds = Gen.getEnterprenuerRenewaldashboarddrilldown(Session["uid"].ToString().Trim(), status, Request.QueryString[0].ToString().Trim(), "");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
                // intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                Session["Applid"] = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["InspectingAuthorityType"].ToString().Trim() == "2" && (ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim() == "1" || ds.Tables[0].Rows[0]["Thirdparttype"].ToString().Trim() == "2"))
                {
                    if (ds.Tables[0].Rows[0]["intStageid"].ToString().Trim() == "12")
                    {
                        trirRelavent.Visible = true;
                        trInspection.Visible = true;
                        trformv.Visible = true;
                    }
                }
                if (ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "7")
                {
                    trboilerstagesdropdown.Visible = true;
                    ddlBoilerStages.SelectedValue = "9";
                    ddlBoilerStages.Enabled = false;
                    rescduleINSdate.Visible = true;
                    rescdulehrddate.Visible = true;
                    reschdule.Visible = true;
                }
                //if (ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "14")
                //{
                //    trboilerstagesdropdown.Visible = true;
                //    ddlBoilerStages.SelectedValue = "15";
                //    ddlBoilerStages.Enabled = false;
                //    truploadrepairer.Visible = true;
                //}
                if (ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "24")
                {
                    trboilerstagesdropdown.Visible = true;
                    ddlBoilerStages.SelectedValue = "15";
                    ddlBoilerStages.Enabled = false;
                    truploadrepairer.Visible = true;
                }
                if (ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "12" || ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "17" || ds.Tables[0].Rows[0]["BoilerStageid"].ToString().Trim() == "23")
                {
                    truploadCompletion.Visible = true;
                    trboilerstagesdropdown.Visible = true;
                    ddlBoilerStages.SelectedValue = "22";
                    ddlBoilerStages.Enabled = false;
                }
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                grdDetails.DataSource = ds.Tables[1];
                grdDetails.DataBind();
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

            ds = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");
            //Gen.GetQueryStatusByTransactionIDRenewal(Request.QueryString[0].ToString());


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //Label447.Text = ds.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                //Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();


                // intEnterpreniourApprovalid = ds.Tables[0].Rows[0]["intEnterpreniourApprovalid"].ToString().Trim();
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                //QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                //QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                //QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
                Created_by = ds.Tables[0].Rows[0]["Createdby"].ToString().Trim();
                //Created_dt = ds.Tables[0].Rows[0]["Created_dt"].ToString().Trim();
                //string number = "";
                string inspdate = ""; string hydate = "";

                //string[] date = txtInspection.Text.Trim().Split(' ');
                if (txtInspection.Text != "")
                {
                    string[] newdate = txtInspection.Text.Trim().Split('/');
                    inspdate = newdate[1].ToString() + "/" + newdate[0].ToString() + "/" + newdate[2].ToString();// +" " + date[1].ToString();
                }
                if (txthydraulic.Text != "")
                {
                    string[] newdate1 = txthydraulic.Text.Trim().Split('/');
                    hydate = newdate1[1].ToString() + "/" + newdate1[0].ToString() + "/" + newdate1[2].ToString();// +" " + date[1].ToString();
                }

                if (ddlBoilerStages.SelectedValue == "9")
                {
                    if (txtInspection.Text == "")
                    {
                        lblmsg0.Text = "Please select Thorough examination date";
                        lblmsg0.Visible = true;
                        return;
                    }
                    if (txthydraulic.Text == "")
                    {
                        lblmsg0.Text = "Please select Hydraulic Test date";
                        lblmsg0.Visible = true;
                        return;
                    }
                }
                int i = Gen.InsertBoilerStageDetailsRenewal(intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, ddlBoilerStages.SelectedValue,
                    inspdate, hydate, "", "", "", "");


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
            if (ddlBoilerStages.SelectedValue == "9")
            {
                BoilerService.renewalRequestforReschduleinspection BoilerReschdulevo = new BoilerService.renewalRequestforReschduleinspection();
                // BoilerServiceTest.renewalReschduleSteamTest BoilerReschdulevo = new BoilerServiceTest.renewalReschduleSteamTest();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");
                BoilerReschdulevo.application_id = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                BoilerReschdulevo.reschdule_hydraulicdate = dsdeptquery.Tables[0].Rows[0]["ReschduleHydraulicTestdate"].ToString();
                BoilerReschdulevo.reschdule_inspectiondate = dsdeptquery.Tables[0].Rows[0]["Reschduleinspectiondate"].ToString();
                //BoilerReschdulevo.uploadreschduledocuments="";
                BoilerReschdulevo.systemIP = "000";
                BoilerReschdulevo.userID = dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();

                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[2].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[2];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[2].Rows.Count > 0)
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
                    BoilerReschdulevo.uploadreschduledocuments = lst;
                }

                string boilerreschdule = BoilerRenewalservice.renewalReschduleInspectionNotice(BoilerReschdulevo);
                if (boilerreschdule == "SUCCESS")
                {
                    Gen.UpdateDepartwebserviceflagREN(BoilerReschdulevo.application_id, "55", "RE", boilerreschdule, "Y");
                }
                else
                {
                    Gen.UpdateDepartwebserviceflagREN(BoilerReschdulevo.application_id, "55", "RE", boilerreschdule, "N");
                }
            }
            if (ddlBoilerStages.SelectedValue == "15")
            {
                BoilerService.renewalRepairsDetails renewalrepairervo = new BoilerService.renewalRepairsDetails();
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");

               
                renewalrepairervo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();//dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                renewalrepairervo.entrepreneurRemarks = "NA";
                renewalrepairervo.systemIP = "00000";
                renewalrepairervo.userID = intQuessionaireid; //dsdeptquery.Tables[0].Rows[0]["Created_by"].ToString();

                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[3].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[3];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[3].Rows.Count > 0)
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
                    renewalrepairervo.queryResponseAttachments = lst;
                    string renewalrepaireroutpu = BoilerRenewalservice.renewalRepairerDetails(renewalrepairervo);
                    if (renewalrepaireroutpu == "SUCCESS")
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UR", renewalrepaireroutpu, "Y");
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UR", renewalrepaireroutpu, "N");
                    }
                }
            }
            if (ddlBoilerStages.SelectedValue == "22")
            {
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");

                // BoilerServiceTest.renewalInspectionRelatedDocs
                BoilerService.renewalRepairsCompletionDetails boilerrCompletionvo = new BoilerService.renewalRepairsCompletionDetails();
                boilerrCompletionvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                boilerrCompletionvo.entrepreneurRemarks = "NA";
                boilerrCompletionvo.systemIP = "0000";
                boilerrCompletionvo.userID = intQuessionaireid;// "";
                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[4].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[4];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[4].Rows.Count > 0)
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
                    boilerrCompletionvo.queryResponseAttachments = lst;
                    string completionoutput = BoilerRenewalservice.renewalRepairsCompletion(boilerrCompletionvo);
                    if (completionoutput == "SUCCESS")
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UC", completionoutput, "Y");
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "UC", completionoutput, "N");
                    }
                }
            }
            if (trirRelavent.Visible == true)
            {
                DataSet dsdeptquery = new DataSet();
                dsdeptquery = Gen.getEnterprenuerRenewalBoilerdashboarddrilldown(Session["Applid"].ToString(), "", Request.QueryString[0].ToString(), "");

                // BoilerServiceTest.renewalInspectionRelatedDocs
                BoilerService.renewalInspectionRelatedDocs boilerrelateddocvo = new BoilerService.renewalInspectionRelatedDocs();
                boilerrelateddocvo.applicationID = dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString();
                //boilerrelateddocvo.inspectionRelatedDocs = "NA";
                // boilerrelateddocvo.inspectionRelaventDocs = "NA";
                // boilerrelateddocvo.uploadformvDocs = "NA";
                boilerrelateddocvo.systemIP = "0000";
                boilerrelateddocvo.userID = intQuessionaireid;// "";
                //boilerrepairervo.queryResponseAttachments
                BoilerService.queryResponseAttachment[] lst = null;
                BoilerService.queryResponseAttachment[] lst1 = null;
                BoilerService.queryResponseAttachment[] lst2 = null;
                BoilerService.queryResponseAttachment boilerqueryvo = new BoilerService.queryResponseAttachment();
                BoilerService.queryResponseAttachment boilerqueryvo1 = new BoilerService.queryResponseAttachment();
                BoilerService.queryResponseAttachment boilerqueryvo2 = new BoilerService.queryResponseAttachment();
                if (dsdeptquery.Tables[5].Rows.Count > 0)
                {
                    DataTable dtraw = new DataTable();
                    dtraw = dsdeptquery.Tables[5];
                    lst = new BoilerService.queryResponseAttachment[dtraw.Rows.Count];
                    if (dsdeptquery.Tables[5].Rows.Count > 0)
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
                    boilerrelateddocvo.inspectionRelatedDocs = lst;

                    if (dsdeptquery.Tables[6].Rows.Count > 0)
                    {
                        DataTable dtraw1 = new DataTable();
                        dtraw1 = dsdeptquery.Tables[6];
                        lst1 = new BoilerService.queryResponseAttachment[dtraw1.Rows.Count];

                        for (int l = 0; l < dtraw1.Rows.Count; l++)
                        {

                            boilerqueryvo1.documentName = dtraw1.Rows[l]["FileName"].ToString();
                            boilerqueryvo1.documentPath = dtraw1.Rows[l]["link"].ToString();
                            lst1[l] = boilerqueryvo1;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo1.documentName = "NA";
                        boilerqueryvo1.documentPath = "NA";
                    }
                    boilerrelateddocvo.inspectionRelaventDocs = lst1;

                    if (dsdeptquery.Tables[7].Rows.Count > 0)
                    {
                        DataTable dtraw2 = new DataTable();
                        dtraw2 = dsdeptquery.Tables[7];
                        lst2 = new BoilerService.queryResponseAttachment[dtraw2.Rows.Count];

                        for (int m = 0; m < dtraw2.Rows.Count; m++)
                        {

                            boilerqueryvo2.documentName = dtraw2.Rows[m]["FileName"].ToString();
                            boilerqueryvo2.documentPath = dtraw2.Rows[m]["link"].ToString();
                            lst2[m] = boilerqueryvo2;
                            //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                            //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                        }
                    }
                    else
                    {
                        boilerqueryvo2.documentName = "NA";
                        boilerqueryvo2.documentPath = "NA";
                    }
                    boilerrelateddocvo.uploadformvDocs = lst2;

                    string completionoutput = BoilerRenewalservice.insertRenewalInspectionRelatedDocs(boilerrelateddocvo);
                    if (completionoutput == "SUCCESS")
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "TR", completionoutput, "Y");
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflagREN(dsdeptquery.Tables[0].Rows[0]["UID_No"].ToString(), "55", "TR", completionoutput, "N");
                    }
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
        //string sFileDir = Server.MapPath("~\\RENAttachments");
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];
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
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\ReschduleinspectionAttachment\\" + hdfFlagID1.Value);
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

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ReschduleinspectionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



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
    protected void btnrepairerdetails_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((fileuploadrepairerdetails.PostedFile != null) && (fileuploadrepairerdetails.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fileuploadrepairerdetails.PostedFile.FileName);
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

                string[] fileType = fileuploadrepairerdetails.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\RepairerdetailsAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fileuploadrepairerdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fileuploadrepairerdetails.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RepairerdetailsAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        lblFileNameResponse.Text = fileuploadrepairerdetails.FileName;
                        lblrepairerdetails.Text = fileuploadrepairerdetails.FileName;
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
    protected void btnploadCompletion_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((fileuploadploadCompletion.PostedFile != null) && (fileuploadploadCompletion.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fileuploadploadCompletion.PostedFile.FileName);
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

                string[] fileType = fileuploadploadCompletion.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Session["Applid"].ToString() + "\\UploadCompletionAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fileuploadploadCompletion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fileuploadploadCompletion.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "UploadCompletionAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label3.Text = fileuploadploadCompletion.FileName;
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

    void getBoilerStages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetBoilerStages("");
        ddlBoilerStages.DataSource = dsnew.Tables[0];
        ddlBoilerStages.DataTextField = "StageName";
        ddlBoilerStages.DataValueField = "intStageid";
        ddlBoilerStages.DataBind();
        ddlBoilerStages.Items.Insert(0, "--Select--");


    }
    protected void btnInspection_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((fileuploadInspection.PostedFile != null) && (fileuploadInspection.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fileuploadInspection.PostedFile.FileName);
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

                string[] fileType = fileuploadInspection.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() +"\\"+ Session["Applid"].ToString() + "\\UploadInspectionRelatedAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fileuploadInspection.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fileuploadInspection.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "UploadInspectionRelatedAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        hyperlinkInspection.Text = fileuploadInspection.FileName;
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
    protected void btnirRelavent_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((fileuploadirRelavent.PostedFile != null) && (fileuploadirRelavent.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fileuploadirRelavent.PostedFile.FileName);
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

                string[] fileType = fileuploadirRelavent.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() +"\\"+ Session["Applid"].ToString() + "\\UploadInspectionRelevantAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fileuploadirRelavent.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fileuploadirRelavent.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "UploadInspectionRelevantAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        hyperlinkirRelavent.Text = fileuploadirRelavent.FileName;
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
    protected void btnformv_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((fileuploadformv.PostedFile != null) && (fileuploadformv.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fileuploadformv.PostedFile.FileName);
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

                string[] fileType = fileuploadformv.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\"+ Session["Applid"].ToString() + "\\UploadFORMVAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fileuploadformv.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fileuploadformv.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ResponseAttachment");

                    result = t1.InsertRENAttachementApproval(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "UploadFORMVAttachment", hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());



                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        hyperlinkformv.Text = fileuploadformv.FileName;
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
}