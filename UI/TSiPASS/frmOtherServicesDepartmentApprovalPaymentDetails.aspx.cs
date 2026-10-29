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

public partial class UI_TSiPASS_frmOtherServicesDepartmentApprovalPaymentDetails : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    decimal TotalFee;
    decimal TotalFeeNExt;
    decimal TotalAmountExt;
    DataRow dtrdr;
    int hmdaCount;
    int hmdaCount1;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string sonlinetrnsNo;
    static DataTable dtMyTable;
    string AttachmentFilepath = "", AttachmentFileName = "";
    string ApprovalId;
    string IntCFEId;

    string ApprovalIdQery;
    string IntCFEIdQuery;
    #region "Global Variables"
    //RequestURL objRequestURL = new RequestURL();
    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["ApprovalId"] != null && Request.QueryString["ApprovalId"] != "")
        {
            ApprovalId = Request.QueryString["ApprovalId"];
            ApprovalIdQery = Request.QueryString["ApprovalId"];
        }

        if (Request.QueryString["CFEEnterpid"] != null && Request.QueryString["CFEEnterpid"] != "")
        {
            IntCFEIdQuery = Request.QueryString["CFEEnterpid"];
        }


        if (!IsPostBack)
        {
            
           
                
            

            //Session["Applid"] = "1013";
            //Session["UIDNO"] = "";
            //Session["intCFEEnterpid"] = "1013";
            Session["uid"] = Session["validCreated"].ToString();

            DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //    Session["UIDNO"] = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();
            //    Session["intCFEEnterpid"] = dscheck.Tables[3].Rows[0]["intCFEEnterpid"].ToString().Trim();
            //}

            dscheck = Gen.GetOtheServiceShowQuestionaries(Session["uid"].ToString().Trim(), ApprovalId);
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["IncentReformId"].ToString().Trim();
                Session["UIDNO"] = dscheck.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Session["intCFEEnterpid"] = dscheck.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
            }

            else
            {
                Session["Applid"] = "0";
            }

            if (Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmDistrictReformsForm.aspx");
            }



            DataSet dspay = new DataSet();
            dspay = Gen.GetOtherServicesPayDetailsPaidDet(Session["Applid"].ToString().Trim());
            if (dspay != null && dspay.Tables.Count > 0 && dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails0.DataSource = dspay.Tables[0];
                grdDetails0.DataBind();
            }
            if (Request.QueryString["AdditionalPayment"] != null)
            {
                DataSet ds = new DataSet();
                ds = Gen.GetEnterPreniourPayDetailsAddtionalPayment(Session["Applid"].ToString().Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    #region commented code
                    ///ADDED BY MADHURI FOR UPDATING PENALTY AMOUNT OF HMDA DEPT//
                    ///Commenting by Sridhar 
                    //string uidnumber = "";
                    //string hmdauidno = "";
                    //Double totalamount = 0.00;
                    //Double hmdatotalamount = 0.00;
                    //foreach (DataRow item in ds.Tables[0].Rows)
                    //{
                    //    if (item["ApprovalId"].ToString() == "35")
                    //    {
                    //        //string totalfees
                    //        DataSet dsnew = new DataSet();
                    //        totalamount = Convert.ToDouble(item["Fees"].ToString());
                    //        dsnew = Gen.GetUidnumber(Session["Applid"].ToString());
                    //        if (dsnew.Tables[0].Rows.Count > 0)
                    //        {
                    //            uidnumber = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();

                    //        }
                    //        DataSet dshmda = new DataSet();
                    //        dshmda = Gen.getuidforhmda(uidnumber, "35");
                    //        hmdauidno = dshmda.Tables[0].Rows[0]["UIDNUMBER"].ToString();

                    //        HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
                    //        HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
                    //        hmdapplication = hmdaservice.GetPenaltyAmount(hmdauidno, "$$08@213");

                    //        if (hmdapplication.ResponseStatus != 0)
                    //        {
                    //            hmdatotalamount = (hmdapplication.TotalAmount + hmdapplication.PenaltyAmount);
                    //            if (hmdatotalamount != totalamount)
                    //            {
                    //                int j = Gen.UpdateAdditionalpaymentsInterest(Session["Applid"].ToString().Trim(), hmdatotalamount.ToString(), "", "11", "35", "", Convert.ToString(hmdapplication.PenaltyAmount));
                    //                DataSet dsNEW = new DataSet();
                    //                dsNEW = Gen.GetEnterPreniourPayDetailsAddtionalPayment(Session["Applid"].ToString().Trim());
                    //                grdDetails.DataSource = dsNEW.Tables[0];
                    //                grdDetails.DataBind();
                    //            }
                    //        }
                    //        if (item["ApprovalId"].ToString() == "35")
                    //        {
                    //            if (ds.Tables[0].Rows[0]["DCLetterConditionsdocid"].ToString() != "" && ds.Tables[0].Rows[0]["DCLetterConditionsdocid"].ToString() != string.Empty)
                    //            {
                    //                string attachmentid = ds.Tables[0].Rows[0]["DCLetterConditionsdocid"].ToString().Trim();
                    //                string[] split = ds.Tables[0].Rows[0]["DCLetterConditionsdocid"].ToString().Split(',');
                    //                for (int i = 0; i < split.Length; i++)
                    //                {
                    //                    if (split[i].ToString().TrimStart().Trim() == "11")//NALA conversion
                    //                    {
                    //                        trrNALA.Visible = true;
                    //                    }

                    //                    if (split[i].ToString().TrimStart().Trim() == "13")//Gift deed
                    //                    {
                    //                        trGift.Visible = true;
                    //                    }
                    //                    if (split[i].ToString().TrimStart().Trim() == "14")// Formation of BT road
                    //                    {
                    //                        trBTRoad.Visible = true;
                    //                    }
                    //                    if (split[i].ToString().TrimStart().Trim() == "15")//Photographs of demolished
                    //                    {
                    //                        trphotodemolished.Visible = true;
                    //                    }
                    //                    if (split[i].ToString().TrimStart().Trim() == "16")//NOC from Fire service
                    //                    {
                    //                        trNOCFire.Visible = true;
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }

                    //}

                    ///END OF ADDED CODE///
                    #endregion
                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {
                            if (row1.Cells[5].Text != "" && row1.Cells[5].Text != "0")
                            {
                                if (hmdaCount != 0 || hmdaCount1 != 0)
                                {
                                    grdDetails.Rows[hmdaCount].Cells[5].Text = grdDetails.Rows[hmdaCount].Cells[3].Text;
                                    grdDetails.Rows[hmdaCount1].Cells[5].Text = grdDetails.Rows[hmdaCount1].Cells[3].Text;

                                }
                                sum = sum + Convert.ToDecimal(row1.Cells[5].Text);

                            }


                            //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
                        }
                    }

                    HdfA.Value = sum.ToString();
                    txtAmount.Text = HdfA.Value;
                    TxtAmountOnline.Text = HdfA.Value;
                }
            }
            else
            {
                //Session["Applid"] = "1013";
                DataSet ds = new DataSet();
                ds = Gen.GetEnterPreniourPayDetailsOtherServices(Session["Applid"].ToString().Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {

                            sum = sum + Convert.ToDecimal(row1.Cells[5].Text);


                            //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
                        }
                    }

                    HdfA.Value = sum.ToString();
                    txtAmount.Text = HdfA.Value;
                    TxtAmountOnline.Text = HdfA.Value;
                }
            }

            //Session["uid"] = "1000";
            //Session["Applid"] = "1000";
            rblPaymentMode.SelectedIndex = 0;
            rblPaymentMode.SelectedIndex = 1;
            rblPaymentMode.Visible = false;
            RadioButtonList1_SelectedIndexChanged(sender, e);

            if (rblPaymentMode.SelectedIndex == 0)
            {
                paynot.Visible = false;
                paynotOnline.Visible = true;
                BtnDelete.Text = "Generate Challan";
                rdbOnlineBankType.Visible = false;
            }
            else
            {
                paynot.Visible = false;
                paynotOnline.Visible = true;
                BtnDelete.Text = "Pay";
                rdbOnlineBankType.Visible = true;
            }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        if (TxtAmountOnline.Text == "0")
        {
            BtnDelete.Text = "Submit Applications";
        }
        else
        {
            BtnDelete.Text = "Pay";
        }

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
        if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        {
            Response.Redirect("frmDistrictReformsForm.aspx");
        }
        else
        {
            #region commenting
            //commenting
            //int selectioncount = 0;
            //foreach (GridViewRow row in grdDetails.Rows)
            //{
            //    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
            //    {
            //        string HdfApprovalidnew = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    
            //        if (HdfApprovalidnew.Trim() != "33")
            //        {
            //            selectioncount = selectioncount + 1;
            //        }
                   
            //    }
            //}

            //if (selectioncount == 0)
            //{
            //    lblmsg0.Text = "<font color='red'>Please Select Atleaset one Department for Approval ..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (mortgagetable.Visible == true)
            //{
            //    if (gvUpload4.Rows.Count < 1)
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload at least one document..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //if (trrNALA.Visible == true)
            //{
            //    if (Label5.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Nala conversion..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //if (trGift.Visible == true)
            //{
            //    if (Label6.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Gift deed..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //if (trBTRoad.Visible == true)
            //{
            //    if (Label7.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Formation of BT road..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //if (trphotodemolished.Visible == true)
            //{
            //    if (Label8.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload Photographs of demolished..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //if (trNOCFire.Visible == true)
            //{
            //    if (Label10.Text == "")
            //    {
            //        lblmsg0.Text = "<font color='red'>Please Upload NOC from Fire service..!</font>";
            //        success.Visible = false;
            //        Failure.Visible = true;
            //        return;
            //    }
            //}
            //DataSet dsnew = new DataSet();

            //dsnew = Gen.GetUidnumber(Session["Applid"].ToString());
            //if (dsnew.Tables[0].Rows.Count > 0)
            //{
            //    hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            //    Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            //}

            //commenting upto Here bY sridhar
            #endregion


            if (rblPaymentMode.SelectedIndex == 0)
            {
                try
                {

                    Session["SBHCHLNREF"] = "E" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                    //inset into SBI payment disbursement table

                    Session["Amount"] = TxtAmountOnline.Text;

                    Session["UID_no"] = hdfUIDNumber.Value;



                    DataSet dscha = new DataSet();

                    dscha = Gen.GetEnterPreneurdatabyQue(Session["Applid"].ToString().Trim());

                    if (dscha.Tables[0].Rows.Count > 0)
                    {

                        Hdfeid.Value = dscha.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

                    }

                    foreach (GridViewRow row in grdDetails.Rows)
                    {

                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {

                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();

                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();

                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();

                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();



                            if (ViewState["DDUploadName"] == null)

                                ViewState["DDUploadName"] = "";

                            if (ViewState["pathDDUpload"] == null)

                                ViewState["pathDDUpload"] = "";

                            // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);





                            DataSet dsch = new DataSet();

                            dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);

                            if (dsch.Tables[0].Rows.Count > 0)
                            {

                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

                                int s = Gen.InsertUIDGeneration(HdfQueid, dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);
                            }

                            DataSet dschab = new DataSet();

                            dschab = Gen.GetEnterPreneurdatabyQue(HdfQueid);

                            if (dschab.Tables[0].Rows.Count > 0)
                            {

                                hdfUIDNumber.Value = dschab.Tables[0].Rows[0]["UID_No"].ToString();

                                Session["UID_no"] = hdfUIDNumber.Value;

                            }
                        }
                        else
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();

                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();

                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();

                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                            int j = Gen.UpdateAdditionalpaymentsUID(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());
                        }
                    }
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();

                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();

                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();

                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                            DataSet dsch = new DataSet();

                            dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);

                            if (dsch.Tables[0].Rows.Count > 0)
                            {

                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

                                int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), Session["SBHCHLNREF"].ToString().Trim(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);

                            }
                        }
                    }
                    Response.Redirect("SBHChallan.aspx");
                }

                catch (Exception ex)
                {

                    throw ex;

                }
                //DataSet dscha = new DataSet();
                //dscha = Gen.GetEnterPreneurdatabyQue(Session["Applid"].ToString().Trim());
                //if (dscha.Tables[0].Rows.Count > 0)
                //{
                //    Hdfeid.Value = dscha.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                //}




                //foreach (GridViewRow row in grdDetails.Rows)
                //{
                //    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                //    {
                //        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                //        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                //        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                //        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                //        if (ViewState["DDUploadName"] == null)
                //            ViewState["DDUploadName"] = "";
                //        if (ViewState["pathDDUpload"] == null)
                //            ViewState["pathDDUpload"] = "";
                //        // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);


                //        DataSet dsch = new DataSet();
                //        dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);
                //        if (dsch.Tables[0].Rows.Count > 0)
                //        {
                //            Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                //            int s = Gen.InsertPaymentTransaction(HdfQueid, dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);



                //        }


                //    }
                //    else
                //    {
                //        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                //        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                //        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                //        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                //        int j = Gen.UpdateAdditionalpayments(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid);

                //    }
                //}
                //Response.Redirect("CFEPrint.aspx?intApplicationid=" + Hdfeid.Value);
            }
            else
            {
                Session["AdditionalPayment"] = "";
                Session["Amount"] = TxtAmountOnline.Text;
               
                Session["UID_no"] = hdfUIDNumber.Value;

                DataSet dscha = new DataSet();
                dscha = Gen.GetEnterPreneurForOtherServices(Session["Applid"].ToString().Trim());
                if (dscha.Tables[0].Rows.Count > 0)
                {
                    Hdfeid.Value = dscha.Tables[0].Rows[0]["IncentReformId"].ToString();
                }
                if (Request.QueryString["AdditionalPayment"] != null)
                {
                    Session["AdditionalPayment"] = "Y";
                }
                else
                {
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                            if (ViewState["DDUploadName"] == null)
                                ViewState["DDUploadName"] = "";
                            if (ViewState["pathDDUpload"] == null)
                                ViewState["pathDDUpload"] = "";
                            // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);


                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurForOtherServices(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["IncentReformId"].ToString();
                                int s = Gen.InsertUIDGenerationForServices(HdfQueid, dsch.Tables[0].Rows[0]["IncentReformId"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);
                            }

                          
                                DataSet dslat = new DataSet();
                                dslat = Gen.GetEnterPreneurForOtherServices(HdfQueid);

                                if (dslat.Tables[0].Rows.Count > 0)
                                {
                                    int quedata = Gen.updatenonPaymentinOtherServices(dslat.Tables[0].Rows[0]["IncentReformId"].ToString(), Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                                }
                            

                            DataSet dschab = new DataSet();
                            dschab = Gen.GetEnterPreneurForOtherServices(HdfQueid);
                            if (dschab.Tables[0].Rows.Count > 0)
                            {
                                hdfUIDNumber.Value = dschab.Tables[0].Rows[0]["UID_No"].ToString();
                                Session["UID_no"] = hdfUIDNumber.Value;
                            }
                        }
                        else
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            int j = Gen.UpdateAdditionalpaymentsUID_ForOtherServices(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());
                            // (string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string IPAddress)
                        }
                    }
                }
                if (chkBuilldesc.Checked && rdbOnlineBankType.SelectedValue == "Billdesk")
                {
                    sonlinetrnsNo = "Bill" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                    Session["onlinetransId"] = sonlinetrnsNo;
                    //inset into SBI payment disbursement table
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDesk(Session["UID_no"].ToString(), dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "CFE", Session["AdditionalPayment"].ToString());
                            }
                        }
                    }
                    if (mortgagetable.Visible == true)
                    {
                        int msg = 0;
                        string[] rd1 = null;
                        string ConvertedDt1 = "";
                        string date = "";
                        if (txtRegDate.Text.Trim() != "")
                        {
                            rd1 = txtRegDate.Text.Split('/');
                            ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

                            date = ConvertedDt1;
                        }
                        msg = Gen.insertMortgagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), txtmortgagenumber.Text.Trim(), txtfloor.Text.Trim(), txtareasqmtr.Text.Trim(),
                            txtsro.Text.Trim(), date, txtplotno.Text.Trim(), Session["uid"].ToString());
                    }
                    Response.Redirect("BilldeskPaymentPage.aspx");
                }
                else if (rdbOnlineBankType.SelectedValue.ToString().Trim() == "Kotak")
                {
                    sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                    Session["onlinetransId"] = sonlinetrnsNo;
                    //inset into SBI payment disbursement table
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();

                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurForOtherServices(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["IncentReformId"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDesk(Session["UID_no"].ToString(), dsch.Tables[0].Rows[0]["IncentReformId"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "OtherServices", Session["AdditionalPayment"].ToString());
                            }
                        }
                    }

                    #region commenting by sridhar
                    //if (mortgagetable.Visible == true)
                    //{
                    //    int msg = 0;
                    //    string[] rd1 = null;
                    //    string ConvertedDt1 = "";
                    //    string date = "";
                    //    if (txtRegDate.Text.Trim() != "")
                    //    {
                    //        rd1 = txtRegDate.Text.Split('/');
                    //        ConvertedDt1 = rd1[0].ToString() + "/" + rd1[1].ToString() + "/" + rd1[2].ToString();

                    //        date = ConvertedDt1;
                    //    }
                    //    msg = Gen.insertMortgagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), txtmortgagenumber.Text.Trim(), txtfloor.Text.Trim(), txtareasqmtr.Text.Trim(),
                    //        txtsro.Text.Trim(), date, txtplotno.Text.Trim(), Session["uid"].ToString());
                    //}

                    #endregion

                    if(TxtAmountOnline.Text == "0")
                    {
                        string Appro = ApprovalIdQery;
                        string IntCFEId = IntCFEIdQuery;
                        Response.Redirect("AcknoledgementForOtherServices.aspx?ApprovalId=" + ApprovalIdQery + "&IntCFEId=" + IntCFEIdQuery);

                    }
                    else
                    {
                        Response.Redirect("KotakPageForOtherServices.aspx");
                    }
                  
                       
                   
                      
                    

                  
                }
                else
                {
                    if (rdbOnlineBankType.SelectedIndex == 0)// SBI
                    {
                        #region

                        //Begin Added on 20-04-2016 by Geetha Garu
                        sonlinetrnsNo = "SBI" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        Session["onlinetransId"] = sonlinetrnsNo;
                        //inset into SBI payment disbursement table
                        foreach (GridViewRow row in grdDetails.Rows)
                        {
                            if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                            {
                                string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                                string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                                string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                                string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();



                                DataSet dsch = new DataSet();
                                dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);
                                if (dsch.Tables[0].Rows.Count > 0)
                                {
                                    Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                    int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);
                                }
                            }
                        }
                        Response.Redirect("OnlinePaymentRequest.aspx");
                        #endregion
                    }
                    else // ICICI
                    {
                        #region ICICI
                        DataSet ds = new DataSet();
                        SqlConnection sqlcon = new SqlConnection(con);
                        SqlCommand cmd = new SqlCommand("GetICICITRNSID", sqlcon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TSipass_UID", Session["UID_no"].ToString());
                        cmd.Parameters.AddWithValue("@Paid_Amt", Convert.ToDouble(Session["Amount"].ToString()));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            Session["IcicitransId"] = ds.Tables[0].Rows[0][0].ToString();//"9892381157";
                            // Session["Amount"]=Convert.ToDecimal(Session["Amount"].ToString()).ToString("f2");
                            //inset into ICICI payment disbursement table
                            foreach (GridViewRow row in grdDetails.Rows)
                            {
                                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                                {
                                    string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                                    string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                                    string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                                    string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();


                                    DataSet dsch = new DataSet();
                                    dsch = Gen.GetEnterPreneurdatabyQue(HdfQueid);
                                    if (dsch.Tables[0].Rows.Count > 0)
                                    {
                                        Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                        int s = Gen.InsertPaymentDisbusment(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), Session["IcicitransId"].ToString(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid, "CFE");

                                    }
                                }
                            }
                            //Session["onlinetransId"] = //sonlinetrnsNo;

                            Response.Redirect("IciciPaymentRequest.aspx");
                        }
                        #endregion
                    }
                }

            }

            //  Response.Redirect("Dashboard.aspx");

            // }
        }

    }

    #region
    //no use the following code
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsData(Session["intCFEEnterpid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, senPlanB;
                int i = 0;
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("link");
                dt2.Columns.Add("FileName");

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");



                    if (sen.Contains("DD Upload"))
                    {
                        lblFileName.NavigateUrl = sen;
                        lblFileName.Text = ds.Tables[0].Rows[i][1].ToString();
                        Label434.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink9.NavigateUrl = sen;
                        //HyperLink9.Text = 
                        //gvCertificate.Visible = true;
                        //DataSet ds1 = new DataSet();
                        //ds1 = Gen.GetAdditonalAttachmets(hdfFlagID0.Value.ToString());
                        //this.gvCertificate.DataSource = ds1.Tables[0];
                        //this.gvCertificate.DataBind();
                    }
                    if (sen.Contains("MortgageHMDA"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt2.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt2.Rows.Add(_row);

                        Session["CertificateTb2"] = null;
                        Session["CertificateTb2"] = dt2;
                        this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvUpload4.DataBind();
                    }
                    i++;
                }
                //gvCertificate.Visible = true;
                //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                //this.gvCertificate.DataBind();

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
    //uptohere
    #endregion
    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        // hmdaCount = Convert.ToInt32(Session["hmdaCount"].ToString());
        // hmdaCount1 = Convert.ToInt32(Session["hmdaCount1"].ToString());
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        if (ChkApproval.Checked == true)
        {
            row.Cells[5].Text = row.Cells[3].Text;
            //if (row.RowIndex == hmdaCount)  //changed --added on 28.03.18
            //{
            //    CheckBox hmdaCLU = (CheckBox)grdDetails.Rows[hmdaCount].FindControl("ChkApproval");
            //    CheckBox hmdaCLU1 = (CheckBox)grdDetails.Rows[hmdaCount1].FindControl("ChkApproval");
            //    hmdaCLU.Checked = true;
            //    hmdaCLU1.Checked = true;

            //    hmdaCLU1.Enabled = false;
            //    //  row.Cells[6].Text = row.Cells[4].Text;


            //    //decimal TotalFee12 = Convert.ToDecimal(DataBinder.Eval(e.r.DataItem, "Fees"));
            //    //TotalFee = TotalFee + TotalFee12;
            //    //TotalFee = TotalFee + TotalFee12;
            //    // CheckBox hmdaCLU = (CheckBox)row.FindControl("ChkApproval");
            //    //hmdaCLU.Checked = true;
            //}
            //else if (row.RowIndex == hmdaCount1)
            //{
            //    CheckBox hmdaCLU = (CheckBox)grdDetails.Rows[hmdaCount].FindControl("ChkApproval");
            //    CheckBox hmdaCLU1 = (CheckBox)grdDetails.Rows[hmdaCount1].FindControl("ChkApproval");
            //    hmdaCLU.Checked = true;
            //    hmdaCLU1.Checked = true;
            //    hmdaCLU.Enabled = false;
            //    //  row.Cells[6].Text = row.Cells[4].Text;


            //}
        }
        else
        {
            row.Cells[5].Text = "0";


        }
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[5].Text != "" && row1.Cells[5].Text != "0")
                {
                    sum = sum + Convert.ToDecimal(row1.Cells[5].Text);
                    //if (hmdaCount != 0 || hmdaCount1 != 0)
                    //{
                    //    grdDetails.Rows[hmdaCount].Cells[5].Text = grdDetails.Rows[hmdaCount].Cells[3].Text;
                    //    grdDetails.Rows[hmdaCount1].Cells[5].Text = grdDetails.Rows[hmdaCount1].Cells[3].Text;

                    //}
                }
            }
        }
        //int total, totalmarks;
        //for (int i = 0; i < grdDetails.Rows.Count; i++)
        //{
        //    total = Convert.ToInt32(grdDetails.Rows[i].Cells[3].Text.ToString());
        //    totalmarks = Convert.ToInt32(total);

        //    sum = sum + total;
        //}

        HdfA.Value = sum.ToString();
        txtAmount.Text = HdfA.Value;
        TxtAmountOnline.Text = HdfA.Value;
        if (TxtAmountOnline.Text == "0")
        {
            BtnDelete.Text = "Submit Applications";
        }
        else
        {
            BtnDelete.Text = "Pay";
        }
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            //decimal TotalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            TotalFee = TotalFee + TotalFee1;
            string s = "0";
            if (e.Row.Cells[5].Text != "")
            {
                s = e.Row.Cells[5].Text;
            }



            decimal TotalFee1a = Convert.ToDecimal(s);
            TotalFeeNExt = TotalFeeNExt + TotalFee1a;

            //decimal TotalAmount1 = Convert.ToDecimal(s);
            //TotalAmountExt = TotalAmountExt + TotalAmount1;

            HiddenField HdfAmount = (HiddenField)e.Row.FindControl("HdfAmount");
            HiddenField HdfDeptid = (HiddenField)e.Row.FindControl("HdfDeptid");
            HiddenField HdfQueid = (HiddenField)e.Row.FindControl("HdfQueid");
            HiddenField HdfApprovalid = (HiddenField)e.Row.FindControl("HdfApprovalid");
            CheckBox ChkApproval = (CheckBox)e.Row.FindControl("ChkApproval");

            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();

            string dcletter = DataBinder.Eval(e.Row.DataItem, "letter").ToString().Trim();

            DataSet dsappr = new DataSet();
            dsappr = Gen.GetQuestionaryAprovalsApplyData(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());

            if (dsappr.Tables[0].Rows.Count > 0)
            {
                //if (dsappr.Tables[0].Rows[0]["IsPayment"].ToString().Trim() == "Y")
                //{
                //ChkApproval.Checked = true;
                //ChkApproval.Enabled = false;
                //}
            }
            string approvalName = DataBinder.Eval(e.Row.DataItem, "ApprovalName").ToString().Trim();

            if (approvalName == "HMDA-Change of Land Use")
            {
                hmdaCount = e.Row.RowIndex;
                Session["hmdaCount"] = hmdaCount;


            }
            else if (approvalName == "HMDA-CLU Publication Charges")
            {
                //hmdaCount1 = Int32.Parse(grdDetails.DataKeys[e.Row.RowIndex].Values["ApprovalName"].ToString());
                hmdaCount1 = e.Row.RowIndex;
                Session["hmdaCount1"] = hmdaCount1;

                //lblmsg0.Text = Session["hmdaCount1"].ToString();

            }

            if (HdfApprovalid.Value == "33")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }

            //if (HdfQueid.Value != "18067")
            //{
            //    if (HdfApprovalid.Value == "72")
            //    {

            //        ChkApproval.Checked = true;
            //        ChkApproval.Enabled = false;
            //        e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            //    }
            //}
            if (HdfApprovalid.Value == "35" || HdfApprovalid.Value == "31")
            {
                if (dcletter != null && dcletter != "")
                {
                    grdDetails.Columns[6].Visible = true;
                    //if (HdfApprovalid.Value == "35")
                    //{
                    mortgagetable.Visible = true;
                    //}
                    //else
                    //{
                    //    mortgagetable.Visible = false;
                    //}
                    DataSet dsM = new DataSet();
                    dsM = Gen.getMortgagedetailsonuid(Session["UIDNO"].ToString(), HdfApprovalid.Value.ToString());
                    if (dsM != null && dsM.Tables.Count > 0 && dsM.Tables[0].Rows.Count > 0)
                    {
                        txtmortgagenumber.Text = dsM.Tables[0].Rows[0]["MortgageNumber"].ToString();
                        txtplotno.Text = dsM.Tables[0].Rows[0]["PlotNumber"].ToString();
                        txtRegDate.Text = dsM.Tables[0].Rows[0]["Date"].ToString();
                        txtareasqmtr.Text = dsM.Tables[0].Rows[0]["Area"].ToString();
                        txtsro.Text = dsM.Tables[0].Rows[0]["SRO"].ToString();
                        txtfloor.Text = dsM.Tables[0].Rows[0]["FLoorDetails"].ToString();
                    }
                    DataSet ds = new DataSet();

                    try
                    {
                        //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

                        ds = Gen.ViewAttachmetsData(Session["intCFEEnterpid"].ToString());

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int c = ds.Tables[0].Rows.Count;
                            string sen, sen1, sen2, senPlanB;
                            int i = 0;
                            DataTable dt2 = new DataTable();
                            dt2.Columns.Add("link");
                            dt2.Columns.Add("FileName");

                            while (i < c)
                            {
                                sen2 = ds.Tables[0].Rows[i][0].ToString();
                                sen1 = sen2.Replace(@"\", @"/");
                                sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");



                                if (sen.Contains("DD Upload"))
                                {
                                    lblFileName.NavigateUrl = sen;
                                    lblFileName.Text = ds.Tables[0].Rows[i][1].ToString();
                                    Label434.Text = ds.Tables[0].Rows[i][1].ToString();
                                    //HyperLink9.NavigateUrl = sen;
                                    //HyperLink9.Text = 
                                    //gvCertificate.Visible = true;
                                    //DataSet ds1 = new DataSet();
                                    //ds1 = Gen.GetAdditonalAttachmets(hdfFlagID0.Value.ToString());
                                    //this.gvCertificate.DataSource = ds1.Tables[0];
                                    //this.gvCertificate.DataBind();
                                }
                                if (sen.Contains("MortgageHMDA"))
                                {
                                    senPlanB = "";
                                    senPlanB = ds.Tables[0].Rows[i][1].ToString();

                                    DataRow _row = dt2.NewRow();
                                    _row["link"] = sen;
                                    _row["FileName"] = senPlanB;
                                    dt2.Rows.Add(_row);

                                    Session["CertificateTb2"] = null;
                                    Session["CertificateTb2"] = dt2;
                                    this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                                    this.gvUpload4.DataBind();
                                }
                                i++;
                            }
                            //gvCertificate.Visible = true;
                            //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                            //this.gvCertificate.DataBind();

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
                else
                {
                    grdDetails.Columns[6].Visible = true;
                    mortgagetable.Visible = false;
                }
            }
            else
            {
                grdDetails.Columns[6].Visible = false;
                mortgagetable.Visible = false;
            }

            //if (Convert.ToDouble(HdfAmount.Value) == 0)
            //{
            //    ChkApproval.Checked = true;
            //    ChkApproval.Enabled = false;
            //    e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            //}
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString();
            //   e.Row.Cells[5].Text = TotalFeeNExt.ToString();

        }
    }
    protected void HdfAmount_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)  //RadioButtonList1_SelectedIndexChanged
    {

        if (rblPaymentMode.SelectedIndex == 0)
        {
            paynot.Visible = false;
            paynotOnline.Visible = true;
            BtnDelete.Text = "Generate Challan";
            rdbOnlineBankType.Visible = false;
            rdbOnlineBankType_SelectedIndexChanged(sender, e);
        }
        else
        {
            paynot.Visible = false;
            paynotOnline.Visible = true;
            BtnDelete.Text = "Pay";
            rdbOnlineBankType.Visible = true;
            rdbOnlineBankType.SelectedValue = "Kotak";
            rdbOnlineBankType_SelectedIndexChanged(sender, e);
        }
    }


    //protected DataTable createtablecrtificate()
    //{
    //    dtMyTable = new DataTable("CertificateTb");

    //    dtMyTable.Columns.Add("new", typeof(string));
    //    dtMyTable.Columns.Add("Manf_ItemName", typeof(string));
    //    //dtMyTable.Columns.Add("Manf_Item_Quantity", typeof(string));
    //    dtMyTable.Columns.Add("Manf_Item_Quantity_In", typeof(string));
    //    // dtMyTable.Columns.Add("Manf_Item_Quantity_Per", typeof(string));
    //    // dtMyTable.Columns.Add("Girth", typeof(string));
    //    //dtMyTable.Columns.Add("Est_FireWood", typeof(string));
    //    //dtMyTable.Columns.Add("Forest_Pole", typeof(string));
    //    //dtMyTable.Columns.Add("ExpYears", typeof(string));


    //    //  dtMyTable.Columns.Add("Created_by", typeof(string));

    //    //   dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


    //    return dtMyTable;
    //}


    //private void AddDataToTableCeertificate(string Manf_ItemName, string Manf_Item_Quantity_In, DataTable myTable)
    //{//totStartDate, string totEndDate, string totSummary,
    //    try
    //    {
    //        DataRow Row;
    //        Row = myTable.NewRow();

    //        dtMyTable = new DataTable("CertificateTb");

    //        //  Row["new"] = "0";
    //        //Row["intCFEForestid"] = "0";
    //        Row["Manf_ItemName"] = Manf_ItemName;
    //        //Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
    //        Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
    //        //    Row["Created_by"] = Session["uid"].ToString().Trim();
    //        //   Row["intLineofActivityMid"] = "0";

    //        myTable.Rows.Add(Row);
    //    }
    //    catch (Exception ee)
    //    {
    //        //  ((DataTable)Session["myDatatable"]).Rows.Clear();
    //        //  Response.Redirect("~/EmpFacility.aspx");
    //    }
    //}



    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {

            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = Server.MapPath("~\\Attachments");


            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                //Response.Write(FileUpload1.HasFile.ToString());
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {

                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //Response.Write(sFileName);
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

                            newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\DD Upload");
                            ViewState["pathDDUpload"] = newPath;
                            ViewState["DDUploadName"] = sFileName;
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            //System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
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
                            //gvCertificate.Visible = true;
                            //AddDataToTableCeertificate("DD Payment", sFileName, (DataTable)Session["CertificateTb"]);

                            //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                            //this.gvCertificate.DataBind();
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            int result = 0;
                            result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DD Upload", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = sFileName;
                                lblFileName.NavigateUrl = newPath + "\\" + sFileName;
                                Label434.Text = sFileName;
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
        catch (Exception ex)
        {
            // Response.Write(ex.ToString());
        }
        finally
        {
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
    protected void rdbOnlineBankType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbOnlineBankType.SelectedValue == "Billdesk" && rblPaymentMode.SelectedItem.Text == "Online")
        {
            trbuilddesc.Visible = true;
        }
        else
        {
            trbuilddesc.Visible = false;
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Attachments");
        General t1 = new General();
        if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
            try
            {
                string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\MortgageHMDA");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                    int count = dir.GetFiles().Length;
                    int result = 0;
                    if (count == 0)
                    {
                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "MortgageHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    }
                    else
                    {
                        if (count > 0)
                        {
                            string FileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(FileUpload5.FileName);
                            string FileNameWithExtension = System.IO.Path.GetExtension(FileUpload5.FileName);

                            FileNameWithoutExtension = FileNameWithoutExtension + "_" + count;
                            string FinalFileName = FileNameWithoutExtension + FileNameWithExtension;

                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + FinalFileName);

                            result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "MortgageHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        }
                    }
                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        //Label4.Text = FileUpload5.FileName;
                        Label447.Text = FileUpload5.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        FillDetails();
                        //lnkupload4.Visible = true;
                        //Button4.Visible = false;

                        //DataSet ds = new DataSet();
                        //ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

                        //if (ds.Tables[4].Rows.Count > 0)
                        //{
                        //    int c = ds.Tables[4].Rows.Count;
                        //    string sen1, sen2, sen3, sen4;
                        //    int j = 0;

                        //    while (j < c)
                        //    {
                        //        sen1 = ds.Tables[4].Rows[j][0].ToString();

                        //        if (sen1.Contains("Combinedbuildingplan"))
                        //        {
                        //            sen3 = sen1.Replace(@"\", @"/");
                        //            sen4 = sen3.Replace(@"D:/TS-iPASSFinal/", "~/");
                        //            sen2 = ds.Tables[4].Rows[j][1].ToString();

                        //            DataTable dt = new DataTable();
                        //            dt.Clear();
                        //            dt.Columns.Add("link");
                        //            dt.Columns.Add("FileName");
                        //            DataRow _row = dt.NewRow();
                        //            _row["link"] = sen4;
                        //            _row["FileName"] = sen2;
                        //            dt.Rows.Add(_row);

                        //            Session["CertificateTb1"] = null;
                        //            Session["CertificateTb1"] = dt;
                        //            this.gvUpload4.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        //            this.gvUpload4.DataBind();
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    SetFocus(Failure);
                }
            }
            catch (Exception)//in case of an error
            {
                DeleteFile(newPath + "\\" + sFileName);
            }
        }

    }

    protected void btnNALA_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUploadNALA.PostedFile != null) && (FileUploadNALA.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadNALA.PostedFile.FileName);
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

                string[] fileType = FileUploadNALA.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    // newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\NALAHMDA");
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\NALAHMDA");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadNALA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadNALA.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NALAHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label5.Text = FileUploadNALA.FileName;
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
    protected void btnGift_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUploadGift.PostedFile != null) && (FileUploadGift.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadGift.PostedFile.FileName);
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

                string[] fileType = FileUploadGift.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    //newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\GiftDeedHMDA");

                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadGift.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadGift.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "GiftDeedHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), FileUploadGift.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label6.Text = FileUploadGift.FileName;
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
    protected void btnBTRoad_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUploadBTRoad.PostedFile != null) && (FileUploadBTRoad.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadBTRoad.PostedFile.FileName);
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

                string[] fileType = FileUploadBTRoad.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    //newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\BTRoadHMDA");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadBTRoad.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadBTRoad.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "BTRoadHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label7.Text = FileUploadBTRoad.FileName;
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
    protected void btnphotodemolished_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((Filephotodemolished.PostedFile != null) && (Filephotodemolished.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(Filephotodemolished.PostedFile.FileName);
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

                string[] fileType = Filephotodemolished.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    //newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\PhotoDemolishedHMDA");
                    //
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        Filephotodemolished.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            Filephotodemolished.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "PhotoDemolishedHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label8.Text = Filephotodemolished.FileName;
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
    protected void btnNOCFire_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUploadNOCFire.PostedFile != null) && (FileUploadNOCFire.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadNOCFire.PostedFile.FileName);
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

                string[] fileType = FileUploadNOCFire.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    // newPath = System.IO.Path.Combine(sFileDir, hdfFlagID3.Value + "\\ResponseAttachment\\" + hdfFlagID1.Value + "\\CommonAffidavit");
                    newPath = System.IO.Path.Combine(sFileDir, Session["intCFEEnterpid"].ToString() + "\\NOCFireHMDA");
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadNOCFire.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadNOCFire.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    AttachmentFilepath = newPath + "\\" + sFileName;
                    int result = 0;
                    //       result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Session["intCFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NOCFireHMDA ", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    //result = t1.InsertImagedataApproval(Session["Applid"].ToString(), hdfFlagID3.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CommonAffidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID1.Value.ToString(), hdfFlagID2.Value.ToString());

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        Label10.Text = FileUploadNOCFire.FileName;
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
}