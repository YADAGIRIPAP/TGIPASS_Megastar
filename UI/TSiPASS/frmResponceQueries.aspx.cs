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
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";
    string queryid = "";


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
        // FillDetails();

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

        if (Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("frmQuesstionniareReg.aspx");
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

            ds = Gen.GetQueryStatusByTransactionID(Request.QueryString[0].ToString());
            if (Request.QueryString[0].ToString() != null)
            {
                queryid = Request.QueryString[0].ToString();
            }

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["PLoutionCategorys"].ToString().Trim();
                Label451.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                Label452.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                Label453.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                Label454.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                hdfFlagID2.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                string updatedflag = "";
                if (ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != "" && ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString() != null)
                {
                    updatedflag = ds.Tables[0].Rows[0]["CommonDetailsUpdatedFlag"].ToString().Trim();
                }

                if (hdfFlagID1.Value == "267")
                {
                    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + intCFEEnterpid + "&next=N&Query=" + "Y&intApprovalid=" + hdfFlagID2.Value + "&Queryid=" + Request.QueryString[0].ToString());
                }

                if (hdfFlagID1.Value == "11" || hdfFlagID1.Value == "3")
                {
                    if (hdfFlagID1.Value == "11" && hdfFlagID2.Value != "6")
                    {
                        trresponseattachment.Visible = false;
                        if (ds.Tables[0].Rows[0]["QueryDetails"].ToString() != "" && ds.Tables[0].Rows[0]["QueryDetails"].ToString() != string.Empty)
                        {
                            string attachmentid = ds.Tables[0].Rows[0]["QueryDetails"].ToString().Trim();
                            string[] split = ds.Tables[0].Rows[0]["QueryDetails"].ToString().Split(',');
                            for (int i = 0; i < split.Length; i++)
                            {
                                if (split[i].ToString().TrimStart().Trim() == "1")//registration deed
                                {
                                    trregistrationdeed.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "2")// process flow
                                {
                                    trProcessFlow.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "3")//PAN / AADHAAR
                                {
                                    trPANAADHAAR.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "4")//Self-Certification Form
                                {
                                    trSelfCertification.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "5")//Partnership Deed (or) Articles of Association (AOA)
                                {
                                    trPartnershipDeed.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "6")//Mutation order
                                {
                                    trMutationorder.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "7")//Common Affidavit
                                {
                                    trCommonAffidavit.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "9")//Structural Engineering Certificate  
                                {
                                    trStructuralEng.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "10")//Combined building plan including all floor plans
                                {
                                    trCombinedbuilding.Visible = true;
                                    //for (int j = 0; j < split1.Length; j++)
                                    //{
                                    //    if (split1[j].ToString().TrimStart().Trim() == "1")//registration deed
                                    //    {
                                    //        HyperLink1.Text = "Short Fall Letter";
                                    //    }
                                    //}

                                }
                                if (ds.Tables[0].Rows[0]["additionaldocs"].ToString().Contains(','))
                                {
                                    trshortfalldoc.Visible = true;
                                    string[] split1 = ds.Tables[0].Rows[0]["additionaldocs"].ToString().Split(',');
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = split1[0];
                                    trsDraawingfalldoc.Visible = true;
                                    HyperLink2.Text = "Drawing Short Fall Letter";
                                    HyperLink2.NavigateUrl = split1[1];
                                }
                                else
                                {
                                    trshortfalldoc.Visible = true;
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();
                                    trsDraawingfalldoc.Visible = false;
                                    if(hdfFlagID1.Value == "11")
                                    {
                                        trshortfalldoc.Visible = false;
                                    }
                                }


                                //ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();

                            }
                        }
                    }

                    if (hdfFlagID1.Value == "3")// updatedflag == "Y" &&  commented by on 13/07/2022
                    {
                        trresponseattachment.Visible = false;
                        if (ds.Tables[0].Rows[0]["QueryDetails"].ToString() != "" && ds.Tables[0].Rows[0]["QueryDetails"].ToString() != string.Empty)
                        {
                            string attachmentid = ds.Tables[0].Rows[0]["QueryDetails"].ToString().Trim();
                            string[] split = ds.Tables[0].Rows[0]["QueryDetails"].ToString().Split(',');
                            for (int i = 0; i < split.Length; i++)
                            {
                                if (split[i].ToString().TrimStart().Trim() == "1")//registration deed
                                {
                                    trregistrationdeed.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "2")// process flow
                                {
                                    trProcessFlow.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "3")//PAN / AADHAAR
                                {
                                    trPANAADHAAR.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "4")//Self-Certification Form
                                {
                                    trSelfCertification.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "5")//Partnership Deed (or) Articles of Association (AOA)
                                {
                                    trPartnershipDeed.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "6")//Mutation order
                                {
                                    trMutationorder.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "7")//Common Affidavit
                                {
                                    trCommonAffidavit.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "9")//Structural Engineering Certificate  
                                {
                                    trStructuralEng.Visible = true;
                                }
                                if (split[i].ToString().TrimStart().Trim() == "10")//Combined building plan including all floor plans
                                {
                                    trCombinedbuilding.Visible = true;
                                    //for (int j = 0; j < split1.Length; j++)
                                    //{
                                    //    if (split1[j].ToString().TrimStart().Trim() == "1")//registration deed
                                    //    {
                                    //        HyperLink1.Text = "Short Fall Letter";
                                    //    }
                                    //}

                                }
                                if (ds.Tables[0].Rows[0]["additionaldocs"].ToString().Contains(','))
                                {
                                    trshortfalldoc.Visible = true;
                                    string[] split1 = ds.Tables[0].Rows[0]["additionaldocs"].ToString().Split(',');
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = split1[0];
                                    trsDraawingfalldoc.Visible = true;
                                    HyperLink2.Text = "Drawing Short Fall Letter";
                                    HyperLink2.NavigateUrl = split1[1];
                                }
                                else
                                {
                                    trshortfalldoc.Visible = true;
                                    HyperLink1.Text = "Short Fall Letter";
                                    HyperLink1.NavigateUrl = ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();
                                    trsDraawingfalldoc.Visible = false;
                                }


                                //ds.Tables[0].Rows[0]["additionaldocs"].ToString().Trim();

                            }
                        }
                    }

                    if (hdfFlagID1.Value == "11" && hdfFlagID2.Value == "6")
                    {
                        trresponseattachment.Visible = true;
                    }
                }
 
                else
                {
                    trresponseattachment.Visible = true;
                }
            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int c = ds.Tables[1].Rows.Count;
                string sen, sen1, sen2, senPlanB, sennew;
                int i = 0;

                trresponseattachmentgrid.Visible = true;
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");
                dt1.Columns.Add("LINKNEW");

                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");
                dt2.Columns.Add("LINKNEW");

                while (i < c)
                {
                    sen2 = ds.Tables[1].Rows[i][0].ToString();
                    sennew = ds.Tables[1].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.Contains("ResponseAttachment"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[1].Rows[i][1].ToString();

                        DataRow _row = dt1.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        _row["LINKNEW"] = sennew;
                        dt1.Rows.Add(_row);

                        Session["CertificateTb1"] = null;
                        Session["CertificateTb1"] = dt1;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gvUpload4.DataBind();

                        //Button4.Visible = false;
                        // lnkupload4.Visible = true;

                    }
                    i++;
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

            ds = Gen.GetQueryStatusByTransactionID(Request.QueryString[0].ToString());


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
                intQuessionaireid = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                hdfFlagID3.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intDeptid = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                intApprovalid = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                QueryRaiseDate = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                QueryDescription = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                QueryStatus = ds.Tables[0].Rows[0]["QueryStatus"].ToString().Trim();
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
            if ((txtdiscription.Text == "" || txtdiscription.Text == string.Empty || string.IsNullOrWhiteSpace(txtdiscription.Text))
                && (Label440.Text == "" || Label440.Text == string.Empty))
            {
                lblmsg0.Text = "Please Enter Query Response or Upload Atachment";
                Failure.Visible = true;
                lblmsg0.Focus();
                return;
            }
            //if (trresponseattachment.Visible == true)
            //{
            //    if (Label440.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Query Response Attachments..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            if (trregistrationdeed.Visible == true)
            {
                if (Label2.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Registration Deed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trProcessFlow.Visible == true)
            {
                if (Label4.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Process Flow Chart..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trPANAADHAAR.Visible == true)
            {
                if (Label6.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload PAN/ Aadhar..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trSelfCertification.Visible == true)
            {
                if (Label8.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Self Certification Form..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trPartnershipDeed.Visible == true)
            {
                if (Label10.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Partnershipdetails (or) Articles Of Association(AOA)..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trMutationorder.Visible == true)
            {
                if (Label12.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Mutation Order..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trCommonAffidavit.Visible == true)
            {
                if (Label14.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Common Affidavit..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }
            if (trStructuralEng.Visible == true)
            {
                if (Label16.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Structural Engineer Certificate..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            if (trCombinedbuilding.Visible == true)
            {
                if (Label18.Text == "")
                {
                    lblmsg0.Text = "<font color='red'>Please Upload Pre-DCR Drawings..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
            }

            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = Gen.InsertQueryDetails(intEnterpreniourApprovalid, intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid, QueryRaiseDate, QueryDescription, QueryStatus, ViewState["AttachmentName"].ToString(), ViewState["pathAttachment"].ToString(), "", queryresopnedesc, Created_by, "", "", "", getclientIP());
            // result = Gen.InsertQueryDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
            if (result > 0)
            {
                Cls_nswswebapiafterpayment obj_afterpayment = new Cls_nswswebapiafterpayment();
                obj_afterpayment.getlicencesstatusupdated(intCFEEnterpid, intDeptid, intApprovalid, "CFE", "queryresponded");

                //ResetFormControl(this);
                DataSet dsMail = new DataSet();
                TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
                TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
                FireService.Service1 fireservice = new FireService.Service1();
                //FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
                FactoryServiceQueryResponse.TSFactoryServiceImplService factoryquery = new FactoryServiceQueryResponse.TSFactoryServiceImplService();
                FactoryServiceQueryResponse.planQR queryvo = new FactoryServiceQueryResponse.planQR();
                HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
                HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();                
                TSIICService.tsipass tsiicservice = new TSIICService.tsipass();
                TSIICService.ApplicationFormResponse tsiicapplication = new TSIICService.ApplicationFormResponse();
                string npdclqueryresponse = "", nicapplno = "", questionnaireid="";
                DataSet dsdept = new DataSet();
                dsdept = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
                string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                if (intApprovalid == "20")
                {
                    nicapplno = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                    questionnaireid = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                }
                if (intApprovalid == "4" || intApprovalid == "41")//NPDCL
                {
                    try
                    {
                        npdclqueryresponse = dsdept.GetXml();
                        string npdclqueryresponseout = tsnpdcl.insertQueryResponse(npdclqueryresponse);
                        StringReader str1 = new StringReader(npdclqueryresponseout);
                        DataSet dsout1 = new DataSet();
                        dsout1.ReadXml(str1);
                        if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                        {
                            if (dsout1.Tables[0].Columns.Contains("status"))
                            {
                                if (dsout1.Tables[0].Rows[0]["status"].ToString() == "S")
                                {
                                    string npdclsattachment = dsout1.Tables[0].Rows[0]["status"].ToString();
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachment, "Y");
                                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                                }
                                else
                                {
                                    string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["status"].ToString();
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachmenterror, "N");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else if (intApprovalid == "8") //FIRE
                {
                    try
                    {
                        string OUTPUT = fireservice.StoreQueryResponse(UIDNO, filepath, remarks);
                        if (OUTPUT == "Success")
                        {
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "Y");
                            int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                        }
                        else
                        {
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", OUTPUT, "N");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (intApprovalid == "25") //SPDCL
                {
                    try
                    {
                        npdclqueryresponse = dsdept.GetXml();
                        string Outtsspdcl = tsspdcl.setQueryResponse(npdclqueryresponse);
                        StringReader str1 = new StringReader(Outtsspdcl);
                        DataSet dsout1 = new DataSet();
                        dsout1.ReadXml(str1);
                        if (dsout1 != null && dsout1.Tables.Count > 0 && dsout1.Tables[0].Rows.Count > 0)
                        {
                            if (dsout1.Tables[0].Columns.Contains("RESULT"))
                            {
                                if (dsout1.Tables[0].Rows[0]["RESULT"].ToString() == "Success")
                                {
                                    string npdclsattachment = dsout1.Tables[0].Rows[0]["RESULT"].ToString();
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachment, "Y");
                                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                                }
                                else
                                {
                                    string npdclsattachmenterror = dsout1.Tables[0].Rows[0]["RESULT"].ToString();
                                    Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", npdclsattachmenterror, "N");
                                }
                            }
                        }                        
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (intApprovalid == "21" || intApprovalid == "5" || intApprovalid == "44")//FACTORIES
                {
                    try
                    {
                        queryvo.applicationID = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                        queryvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString().Replace("'", ""); 
                        queryvo.systemIP = "0.0.0.0";
                        queryvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();

                        FactoryServiceQueryResponse.queryResponseAttachment[] lst = null;
                        if (dsdept.Tables[0].Rows.Count > 0)
                        {
                            DataTable dtraw = new DataTable();
                            dtraw = dsdept.Tables[1];
                            lst = new FactoryServiceQueryResponse.queryResponseAttachment[dtraw.Rows.Count];

                            for (int k = 0; k < dtraw.Rows.Count; k++)
                            {
                                FactoryServiceQueryResponse.queryResponseAttachment factoryqueryvo = new FactoryServiceQueryResponse.queryResponseAttachment();
                                factoryqueryvo.documentName = dtraw.Rows[k]["FileName"].ToString();
                                factoryqueryvo.documentPath = dtraw.Rows[k]["link"].ToString();
                                lst[k] = factoryqueryvo;
                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                            }
                            queryvo.queryResponseAttachments = lst;
                        }

                        string queryout = factoryquery.insertIntoPlanApprovalQueryResponse(queryvo);
                        if (queryout == "SUCCESS")
                        {
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", queryout, "Y");
                            int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                        }
                        else
                        {
                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", queryout, "N");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (intApprovalid == "31")
                {
                    //DataSet dsdept = new DataSet();
                    //dsdept = Gen.GetQueryStatusByTransactionIDResponse("1065", "35");
                    //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                    //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                    DataSet dsdepthmda = new DataSet();
                    dsdepthmda = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
                    string tsiic = dsdepthmda.GetXml();
                    tsiicapplication = tsiicservice.reSubmission(tsiic, "$$08@213");
                    if (tsiicapplication.ResponseStatus.ToString() == "1")
                    {
                        Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", tsiicapplication.ErrorMessage, "Y");
                        int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", tsiicapplication.ErrorMessage, "N");
                    }
                }
                else if (intApprovalid == "35")
                {
                    //DataSet dsdept = new DataSet();
                    //dsdept = Gen.GetQueryStatusByTransactionIDResponse("1065", "35");
                    //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                    //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                    //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                    DataSet dsdepthmda = new DataSet();
                    dsdepthmda = Gen.GetQueryStatusByTransactionIDResponse(intQuessionaireid, intApprovalid);
                    string hmda = dsdepthmda.GetXml();
                    hmdapplication = hmdaservice.reSubmission(hmda, "$$08@213");
                    if (hmdapplication.ResponseStatus.ToString() == "1")
                    {
                        Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "Y");
                        int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                    }
                    else
                    {
                        Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", hmdapplication.ErrorMessage, "N");
                    }
                }
                else if (intApprovalid == "20")
                {

                    try
                    {

                        //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
                        string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + questionnaireid + "&indApplicationNo=" + nicapplno + "&remark=" + remarks + "&urlSingle=" + filepath;
                        try
                        {
                            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                            if (webRequest != null)
                            {
                                webRequest.Method = "GET";
                                webRequest.Timeout = 20000;
                                webRequest.ContentType = "application/x-www-form-urlencoded";

                                //using (System.IO.Stream s = webRequest.GetRequestStream())
                                //{
                                //    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                                //        sw.Write(jsonData);
                                //}

                                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                                {
                                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                                    {
                                        var jsonResponse = sr.ReadToEnd();
                                        System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", jsonResponse));
                                        if (jsonResponse.Contains("Clarification submitted successfully"))
                                        {
                                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", jsonResponse, "Y");
                                            int k = Gen.InsertDeptDateTracing("1", questionnaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", "20");
                                        }
                                        else
                                        {
                                            Gen.UpdateDepartwebserviceflag(UIDNO, intApprovalid, "Q", jsonResponse, "N");
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    int k = Gen.InsertDeptDateTracing(intDeptid, intQuessionaireid, ds.Tables[0].Rows[0]["UID_No"].ToString().Trim(), null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "CFE", intApprovalid);
                }
                //fireservice.BeginStoreQueryResponse(
                dsMail = Gen.GetShowEmailidandMobileNumber(intQuessionaireid);

                if (dsMail.Tables[0].Rows.Count > 0)
                {

                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    //cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                }


                //Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value);
                lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                Response.Redirect("HomeDashboard.aspx");
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
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

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
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    //int count = dir.GetFiles().Length;
                    //if (count == 0)
                    //    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    //else
                    //{
                    //    if (count == 1)
                    //    {
                    //        string[] Files = Directory.GetFiles(newPath);

                    //        foreach (string file in Files)
                    //        {
                    //            File.Delete(file);
                    //        }
                    //        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    //    }
                    //}

                    //AttachmentFilepath = newPath + "\\" + sFileName;
                    //int result = 0;
                    ////       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    ////result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    int count = dir.GetFiles().Length;
                    int result = 0;
                    if (count == 0)
                    {
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    }
                    else
                    {
                        if (count > 0)
                        {
                            string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                            string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                            FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                            string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                            //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Response Attachment ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                            result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                        }
                    }
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        //Label440.Text = FileUpload1.FileName;
                        FillDetails();
                        success.Visible = true;
                        Failure.Visible = false;
                        //Response.Write("<script>alert('Attachment Successfully Added')</script> ");



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
                    Response.Write("<script>alert('Upload PDF files only  ')</script> "); //+ fileType[1].Trim(); 
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

    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    string newPath = "";
    //    //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
    //    //string sFileDir = "~\\TenderNotice";
    //    string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

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
    //                newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value);
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
    //                //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
    //                //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

    //                result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

    //                if (result > 0)
    //                {
    //                    //ResetFormControl(this);
    //                    lblmsg.Text = "Attachment Successfully Added";
    //                    lblmsg.Visible = true;
    //                    lblmsg.Visible = false;
    //                    Label440.Text = FileUpload1.FileName;
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
    //    }
    //}
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

    protected void btnregistrationdeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadregistrationdeed.PostedFile != null) && (FileUploadregistrationdeed.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadregistrationdeed.PostedFile.FileName);
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

                string[] fileType = FileUploadregistrationdeed.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\registrationdeed");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadregistrationdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadregistrationdeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Registration Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label2.Text = FileUploadregistrationdeed.FileName;
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
                    Response.Write("<script>alert('Upload PDF files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void btnProcessFlow_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadProcessFlow.PostedFile != null) && (FileUploadProcessFlow.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadProcessFlow.PostedFile.FileName);
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

                string[] fileType = FileUploadProcessFlow.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\ProcessFlow");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadProcessFlow.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadProcessFlow.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Process Flow", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label4.Text = FileUploadProcessFlow.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnPANAADHAAR_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadPANAADHAAR.PostedFile != null) && (FileUploadPANAADHAAR.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadPANAADHAAR.PostedFile.FileName);
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

                string[] fileType = FileUploadPANAADHAAR.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\PANAADHAAR");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadPANAADHAAR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadPANAADHAAR.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PAN/AADHAR", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label6.Text = FileUploadPANAADHAAR.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnSelfCertification_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadSelfCertification.PostedFile != null) && (FileUploadSelfCertification.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadSelfCertification.PostedFile.FileName);
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

                string[] fileType = FileUploadSelfCertification.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\SelfCertification");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadSelfCertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadSelfCertification.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "SelfCertification", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label8.Text = FileUploadSelfCertification.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnPartnershipDeed_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadPartnershipDeed.PostedFile != null) && (FileUploadPartnershipDeed.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadPartnershipDeed.PostedFile.FileName);
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

                string[] fileType = FileUploadPartnershipDeed.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\PartnershipDeed");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadPartnershipDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadPartnershipDeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Partnership Deed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label10.Text = FileUploadPartnershipDeed.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnMutationorder_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadMutationorder.PostedFile != null) && (FileUploadMutationorder.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadMutationorder.PostedFile.FileName);
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

                string[] fileType = FileUploadMutationorder.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\Mutationorder");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadMutationorder.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Mutation Order", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label12.Text = FileUploadMutationorder.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnCommonAffidavit_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadCommonAffidavit.PostedFile != null) && (FileUploadCommonAffidavit.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadCommonAffidavit.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                //if (FileUploadCommonAffidavit.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUploadCommonAffidavit.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUploadCommonAffidavit.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadCommonAffidavit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadCommonAffidavit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label14.Text = FileUploadCommonAffidavit.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnStructuralEng_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadStructuralEng.PostedFile != null) && (FileUploadStructuralEng.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadStructuralEng.PostedFile.FileName);
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

                string[] fileType = FileUploadStructuralEng.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\StructuralEng");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadStructuralEng.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadStructuralEng.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Structural Engineer", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label16.Text = FileUploadStructuralEng.FileName;
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
                    lblmsg0.Text = "Upload PDF files only..!";
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
    protected void btnCombinedbuilding_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFEfilePath"];

        General t1 = new General();
        if ((FileUploadCombinedbuilding.PostedFile != null) && (FileUploadCombinedbuilding.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadCombinedbuilding.PostedFile.FileName);
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

                string[] fileType = FileUploadCombinedbuilding.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\Combinedbuilding");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadCombinedbuilding.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadCombinedbuilding.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath+"\\"+sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combinebuildingplan", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label18.Text = FileUploadCombinedbuilding.FileName;
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
                    lblmsg0.Text = "Upload DWG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload DWG files only  ')</script> "); //+ fileType[1].Trim(); 
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




