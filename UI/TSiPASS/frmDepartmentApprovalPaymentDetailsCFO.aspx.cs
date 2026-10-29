using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using BusinessLogic;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    decimal TotalFee;
    decimal TotalFeeNExt;
    decimal TotalAmountExt;
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string sonlinetrnsNo;
    static DataTable dtMyTable;
    HttpWebRequest request;
    static Stream dataStream;
    string responseFromServer = "";

    WebserviceVO webvo = new WebserviceVO();

    General gen = new General();
    WebClient wc = new WebClient();

    BoilerService.TSBoilerServiceImplService Boiler = new BoilerService.TSBoilerServiceImplService();
    LabourCFOService.TSLabourServiceImplService labourserviceCfo = new LabourCFOService.TSLabourServiceImplService();
    // LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    FireServiceCFO.Service1 firecfo = new FireServiceCFO.Service1();
    FactoryServiceCFO.TSFactoryServiceImplService factorycfo = new FactoryServiceCFO.TSFactoryServiceImplService();
    CEIGService.InstallationAppServiceImplService ceifcfo = new CEIGService.InstallationAppServiceImplService();

    #region "Global Variables"
    //RequestURL objRequestURL = new RequestURL();
    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");


        }


        //if (Session["user"] != null && Session["user"] != "")
        //{ }
        //else
        //{
        //    Response.Redirect("/Account/Login.aspx?link=" + System.Web.HttpContext.Current.Request.Url.PathAndQuery);
        //}

        if (!IsPostBack)
        {
            //dtMyTableCertificate = createtablecrtificate();
            //Session["CertificateTb"] = dtMyTableCertificate;
            //if (Session["Applid"] != null || Session["Applid"] != "")
            //{
            //    //  Response.Redirect("frmDepartmentApprovalDetails.aspx");

            //}
            //else
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");

            //}

            //rblPaymentMode.Items[0].Enabled = false;
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
            }

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                if (dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim() != "")
                {
                    Session["UIDNO"] = dscheck.Tables[2].Rows[0]["UID_No"].ToString().Trim();
                }

                if (dscheck.Tables[3].Rows[0]["intCFOEnterpid"].ToString().Trim() != "")
                {
                    Session["intCFOEnterpid"] = dscheck.Tables[3].Rows[0]["intCFOEnterpid"].ToString().Trim();
                }
            }
            else
            {
                Session["Applid"] = "0";
                Session["intCFOEnterpid"] = "0";
            }

            if (Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareRegCFO.aspx");
            }
            //if (Session["intCFOEnterpid"].ToString().Trim() == "0")
            //{

            //    Response.Redirect("frmCAFEntrepreneurDetails.aspx");
            //}
            DataSet dspay = new DataSet();
            dspay = Gen.GetEnterPreniourPayDetailsPaidDetCFO(Session["Applid"].ToString().Trim());
            if (dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails0.DataSource = dspay.Tables[0];
                grdDetails0.DataBind();
            }

            if (Request.QueryString["AddtionalPayment"] != null)
            {
                DataSet ds = new DataSet();
                ds = Gen.GetEnterPreniourPayDetailsAddtionalPaymentCFO(Session["Applid"].ToString().Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {

                            sum = sum + Convert.ToDecimal(row1.Cells[6].Text);


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
                DataSet ds = new DataSet();
                ds = Gen.GetEnterPreniourPayDetailsCFO(Session["Applid"].ToString().Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {

                            sum = sum + Convert.ToDecimal(row1.Cells[6].Text);


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
            //   rblPaymentMode.SelectedIndex = 1;
            if (rblPaymentMode.SelectedValue == "Demand Draft")
            {
                paynot.Visible = true;
                paynotOnline.Visible = false;

            }
            else
            {
                paynot.Visible = false;
                paynotOnline.Visible = true;
                //rdbOnlineBankType.SelectedIndex = 0;
            }
        }
        FillDetails();
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        RadioButtonList1_SelectedIndexChanged(sender, e);

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
            Response.Redirect("frmQuesstionniareRegCFO.aspx");
        }
        else
        {
            //if (lblFileName.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Attachment..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //}

            //else
            //{

            DataSet dsland = new DataSet();

            dsland = Gen.VerifylandordetailsCFO(Session["Applid"].ToString());

            if (dsland.Tables[0].Rows.Count == 0)
            {

                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Enterprenuer Details in Common Application Form";


                return;

            }
            dsland = Gen.VerifylandordetailsCFO(Session["Applid"].ToString());
            if (dsland.Tables[1].Rows.Count == 0)
            {

                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Line of Manufacture in  Common Application Form";


                return;


            }
            dsland = Gen.VerifylandordetailsCFO(Session["Applid"].ToString());
            if (dsland.Tables[2].Rows.Count == 0)
            {

                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Please Enter Line of Raw materials in Common Application Form";


                return;


            }

            int selectioncount = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    string HdfApprovalidnew = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    if (HdfApprovalidnew.Trim() != "33")
                    {
                        selectioncount = selectioncount + 1;
                    }
                    //if (HdfApprovalidnew.Trim() == "14")
                    //{
                    //    DataSet dspcb = new DataSet();
                    //    dspcb = Gen.getdataofidentityCFONew(Session["Applid"].ToString(), "1");
                    //    if (dspcb != null && dspcb.Tables.Count > 0 && dspcb.Tables[0].Rows.Count > 0)
                    //    {

                    //    }
                    //    else
                    //    {
                    //        lblmsg0.Text = "<font color='red'>Please fill the form related to PCB Department ..!</font>";
                    //        success.Visible = false;
                    //        Failure.Visible = true;
                    //        return;
                    //    }
                    //}
                }
            }

            if (selectioncount == 0)
            {
                lblmsg0.Text = "<font color='red'>Please Select Atleaset one Department for Approval ..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }


            DataSet dsnew = new DataSet();

            dsnew = Gen.GetUidnumberCFO(Session["Applid"].ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {

                hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
                Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            }
            //generating 

            if (rblPaymentMode.SelectedIndex == 0)
            {

                //if (lblFileName.Text == "")
                //{

                //    success.Visible = false;
                //    Failure.Visible = true;
                //    lblmsg0.Text = "Please Upload DD(Demand Draft)";

                //    return;
                //}


                DataSet dscha = new DataSet();
                dscha = Gen.GetEnterPreneurdatabyQueCFO(Session["Applid"].ToString().Trim());
                if (dscha.Tables[0].Rows.Count > 0)
                {
                    Hdfeid.Value = dscha.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                }




                foreach (GridViewRow row in grdDetails.Rows)
                {
                    if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                        if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                        {
                            RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                            if (rdbAmount.SelectedIndex == 1)
                            {
                                HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            }
                            else
                            {
                                HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                            }
                        }
                        if (ViewState["DDUploadName"] == null)
                            ViewState["DDUploadName"] = "";
                        if (ViewState["pathDDUpload"] == null)
                            ViewState["pathDDUpload"] = "";
                        // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);


                        DataSet dsch = new DataSet();
                        dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                        if (dsch.Tables[0].Rows.Count > 0)
                        {
                            Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            int s = Gen.InsertPaymentTransactionCFO(HdfQueid, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);



                        }

                        if (HdfApprovalid == "33")
                        {

                            DataSet dslat = new DataSet();
                            dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["Applid"].ToString());

                            if (dslat.Tables[0].Rows.Count > 0)
                            {


                                int quedata = Gen.updatenonPaymentinCFOQue(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Session["uid"].ToString());


                            }

                        }


                    }
                    else
                    {
                        string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                        string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                        string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                        string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                        int j = Gen.UpdateAdditionalpaymentsCFO(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());

                    }
                }
                Response.Redirect("CFOPrint.aspx?intApplicationid=" + Hdfeid.Value);
            }
            else
            {
                Session["AdditionalPayment"] = "";
                Session["Amount"] = TxtAmountOnline.Text;
                Session["UID_no"] = hdfUIDNumber.Value;

                DataSet dscha = new DataSet();
                dscha = Gen.GetEnterPreneurdatabyQueCFO(Session["Applid"].ToString().Trim());
                if (dscha.Tables[0].Rows.Count > 0)
                {
                    Hdfeid.Value = dscha.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                }


                if (Request.QueryString["AddtionalPayment"] != null)
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


                            if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                            {
                                RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                                if (rdbAmount.SelectedIndex == 1)
                                {
                                    HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                                }
                                else
                                {
                                    HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                                }
                            }


                            if (ViewState["DDUploadName"] == null)
                                ViewState["DDUploadName"] = "";
                            if (ViewState["pathDDUpload"] == null)
                                ViewState["pathDDUpload"] = "";
                            // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);


                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                int s = Gen.InsertUIDGenerationCFO(HdfQueid, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);
                            }

                            if (HdfApprovalid != "33")
                            {
                                DataSet dslat = new DataSet();
                                dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["Applid"].ToString());

                                if (dslat.Tables[0].Rows.Count > 0)
                                {
                                    int quedata = Gen.updatenonPaymentinCFOQueNew(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                                }
                            }

                            DataSet dschab = new DataSet();
                            dschab = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                            if (dschab.Tables[0].Rows.Count > 0)
                            {
                                hdfUIDNumber.Value = dschab.Tables[0].Rows[0]["UID_No"].ToString();
                            }
                        }
                        else
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            int j = Gen.UpdateAdditionalpaymentsUIDCFO(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());

                        }
                    }
                }
                if (chkBuilldesc.Checked && rdbOnlineBankType.SelectedValue == "Billdesk")
                {
                    sonlinetrnsNo = "Bill" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                    Session["onlinetransId"] = sonlinetrnsNo;
                    Session["UID_no"] = hdfUIDNumber.Value;
                    //inset into SBI payment disbursement table
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                            {
                                RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                                if (rdbAmount.SelectedIndex == 1)
                                {
                                    HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                                }
                                else
                                {
                                    HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                                }
                            }
                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDeskCFO(hdfUIDNumber.Value, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "CFO", Session["AdditionalPayment"].ToString());
                            }
                        }
                    }
                    if (BtnDelete.Text == "Submit Applications")
                    {
                        Webservices(hdfUIDNumber.Value);
                    }
                    Response.Redirect("BilldeskPaymentPageCFO.aspx");
                }
                if (rdbOnlineBankType.SelectedValue.ToString().Trim() == "Kotak")
                {
                    sonlinetrnsNo = "Kotak" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
                    Session["onlinetransId"] = sonlinetrnsNo;
                    Session["UID_no"] = hdfUIDNumber.Value;
                    //inset into SBI payment disbursement table
                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                        {
                            string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                            string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                            string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                            string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                            if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                            {
                                RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                                if (rdbAmount.SelectedIndex == 1)
                                {
                                    HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                                }
                                else
                                {
                                    HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                                }
                            }
                            DataSet dsch = new DataSet();
                            dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDeskCFO(hdfUIDNumber.Value, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "CFO", Session["AdditionalPayment"].ToString());
                            }
                            if (BtnDelete.Text == "Submit Applications")
                            {
                                if (TxtAmountOnline.Text == "0")
                                {
                                    int quedata = Gen.updatenonPaymentinCFOQueNew(HdfQueid, Session["uid"].ToString(), HdfApprovalid, "0.00");
                                    if (HdfApprovalid == "74" || HdfApprovalid == "73")
                                    {
                                        int k = gen.InsertDeptDateTracingCFO(HdfDeptid, HdfQueid, Session["UID_no"].ToString(), System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", HdfApprovalid);
                                    }
                                }
                            }
                        }
                    }
                    if (BtnDelete.Text == "Submit Applications")
                    {
                        
                        Webservices(hdfUIDNumber.Value);
                    }
                    Response.Redirect("KotakPageCFO.aspx");
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

                                if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                                {
                                    RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                                    if (rdbAmount.SelectedIndex == 1)
                                    {
                                        HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                                    }
                                    else
                                    {
                                        HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                                    }
                                }

                                DataSet dsch = new DataSet();
                                dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                                if (dsch.Tables[0].Rows.Count > 0)
                                {
                                    Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                    int s = Gen.InsertPaymentDisbusmentSBICFO(dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), Session["onlinetransId"].ToString().Trim(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);
                                }
                            }
                        }

                        Response.Redirect("OnlinePaymentRequest.aspx");
                        #endregion

                    }
                    else // ICICI
                    {
                        DataSet ds = new DataSet();
                        SqlConnection sqlcon = new SqlConnection(con);
                        SqlCommand cmd = new SqlCommand("GetICICITRNSIDCFO", sqlcon);
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


                                    if (HdfDeptid.ToString().Trim() == "8" || HdfDeptid.ToString().Trim() == "7")
                                    {
                                        RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
                                        if (rdbAmount.SelectedIndex == 1)
                                        {
                                            HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                                        }
                                        else
                                        {
                                            HdfAmount = Convert.ToDecimal(Convert.ToDecimal(((HiddenField)row.FindControl("HdfAmount")).Value.ToString()) / Convert.ToDecimal("0.00")).ToString("f0");
                                        }
                                    }
                                    DataSet dsch = new DataSet();
                                    dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                                    if (dsch.Tables[0].Rows.Count > 0)
                                    {
                                        Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                        int s = Gen.InsertPaymentDisbusmentCFO(dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), Session["IcicitransId"].ToString(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);
                                    }
                                }
                            }
                            //Session["onlinetransId"] = //sonlinetrnsNo;
                            Response.Redirect("IciciPaymentRequest.aspx");
                        }
                    }
                }
            }

            //  Response.Redirect("Dashboard.aspx");

            // }
        }

    }
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsDatabyPaymentddCFO(hdfFlagID0.Value.ToString());

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

    protected void ChkApproval_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkApproval = (CheckBox)sender;
        GridViewRow row = (GridViewRow)ChkApproval.NamingContainer;
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        RadioButtonList rdbAmount = (RadioButtonList)row.FindControl("RdbAmountPre");
        HiddenField HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid"));
        if (ChkApproval.Checked == true)
        {
            if (HdfDeptid.Value == "7" || HdfDeptid.Value == "8")
            {
                if (rdbAmount.SelectedIndex == 1)
                {
                    row.Cells[6].Text = row.Cells[3].Text;
                }
                else
                {
                    row.Cells[6].Text = Convert.ToDecimal(Convert.ToDecimal(row.Cells[3].Text) / Convert.ToDecimal("0.00")).ToString("f0");
                }
            }
            else
            {
                row.Cells[6].Text = row.Cells[3].Text;
            }

        }
        else
        {
            row.Cells[6].Text = "0";


        }
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[6].Text != "" && row1.Cells[6].Text != "0")
                {

                    sum = sum + Convert.ToDecimal(row1.Cells[6].Text);
                }


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

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
            //decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            //decimal TotalAmount = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            //TotalFee = TotalFee + TotalFee1;
            string s = "0";
            if (e.Row.Cells[6].Text != "")
            {
                s = e.Row.Cells[6].Text;
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
            RadioButtonList rdbAmount = (RadioButtonList)e.Row.FindControl("RdbAmountPre");

            HdfAmount.Value = DataBinder.Eval(e.Row.DataItem, "Fees").ToString().Trim();
            HdfDeptid.Value = DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim();
            HdfQueid.Value = DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid").ToString().Trim();
            HdfApprovalid.Value = DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim();



            DataSet dsappr = new DataSet();
            dsappr = Gen.GetQuestionaryAprovalsApplyDataCFOnew(DataBinder.Eval(e.Row.DataItem, "intQuessionaireCFOid").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());

            if (dsappr.Tables[0].Rows.Count > 0)
            {
                //if (dsappr.Tables[0].Rows[0]["IsPayment"].ToString().Trim() == "Y")
                //{
                //ChkApproval.Checked = true;
                //ChkApproval.Enabled = false;
                //}
            }

            if (HdfApprovalid.Value == "33" || HdfAmount.Value == "0")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "52")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }

            if (HdfApprovalid.Value == "118")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "15" && Session["uid"].ToString().Trim()!= "229577")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "152" && Session["uid"].ToString().Trim() != "229577")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }

            if (HdfApprovalid.Value == "27")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "153")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[6].Text = e.Row.Cells[3].Text;
            }

            if (DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim() == "7" || DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim() == "8")
            {
                rdbAmount.Visible = true;
                if (e.Row.Cells[3].Text == "0")
                {
                    ChkApproval.Enabled = false;
                    rdbAmount.Visible = false;
                }
            }
            else
            {
                rdbAmount.Visible = false;
            }


        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            //e.Row.Cells[2].Text = "Total Fee";
            //e.Row.Cells[3].Text = TotalFee.ToString();
            //   e.Row.Cells[5].Text = TotalFeeNExt.ToString();

        }
    }
    protected void HdfAmount_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblPaymentMode.SelectedValue == "Demand Draft")
        {
            paynot.Visible = true;
            paynotOnline.Visible = false;

        }
        else
        {
            paynot.Visible = false;
            paynotOnline.Visible = true;
        }
        if (rdbOnlineBankType.SelectedValue == "Billdesk")
        {
           // trbuilddesc.Visible = true;
        }
        else
        {
            trbuilddesc.Visible = false;
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
            string sFileDir = Server.MapPath("~\\CFOAttachments");


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

                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\DD Upload");
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
                            result = t1.InsertImagedataCFO(Session["Applid"].ToString(), Session["uid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DD Upload", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


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
    protected void RdbAmountPre_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rdbAmount = (RadioButtonList)sender;
        GridViewRow row = (GridViewRow)rdbAmount.NamingContainer;
        HiddenField HdfAmount = (HiddenField)row.FindControl("HdfAmount");
        CheckBox ChkApproval = (CheckBox)row.FindControl("ChkApproval");

        HiddenField HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid"));
        if (ChkApproval.Checked == true)
        {
            if (HdfDeptid.Value == "7" || HdfDeptid.Value == "8")
            {
                if (rdbAmount.SelectedIndex == 1)
                {
                    row.Cells[6].Text = row.Cells[3].Text;
                }
                else
                {
                    //  row.Cells[6].Text = row.Cells[3].Text;

                    row.Cells[6].Text = Convert.ToDecimal((Convert.ToDecimal(row.Cells[3].Text) / Convert.ToDecimal("100")) * Convert.ToDecimal("10")).ToString("f0");
                }
            }
            else
            {
                row.Cells[6].Text = row.Cells[3].Text;
            }

        }
        else
        {
            row.Cells[6].Text = "0";


        }
        decimal sum = Convert.ToDecimal("0");
        foreach (GridViewRow row1 in grdDetails.Rows)
        {
            if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
            {
                if (row1.Cells[6].Text != "" && row1.Cells[6].Text != "0")
                {

                    sum = sum + Convert.ToDecimal(row1.Cells[6].Text);
                }


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Session["uid"].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

        HdfA.Value = sum.ToString();
        txtAmount.Text = HdfA.Value;
        TxtAmountOnline.Text = HdfA.Value;

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

    public void Webservices(string UIDNO)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            //if (!IsPostBack)
            //{
                // string UIDNO = Request.QueryString["UIDNO"].ToString();
                // string UIDNO = "SML018004917311CFO"; //"SML018004917311CFO";// "LRG005000817440CFO";//"SML00500064419";//"SML00500064419";
                ds = gen.GetDepartmentonuidCFO(UIDNO);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "14")
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                            string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                            string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            string transactionStatus = "S";
                            string paymentType = "NB";
                            string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                            string additionalPayment = "F";

                            //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";


                            string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                            //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                            //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
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
                                            if (jsonResponse.Contains("Fee submitted successfully"))
                                            {
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "Y");
                                            }
                                            else
                                            {
                                                //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", jsonResponse, "N");
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
                        if (deptid == "16")
                        {
                            CEIGService.installationApplication ceifvo = new CEIGService.installationApplication();
                            DataSet dsdept = new DataSet();
                            string valueshmwssb = "";
                            string outputhmwssb = "";
                            string outpayhmwssb = "";
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valueshmwssb = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {

                                ceifvo.aadhar_number = dsdept.Tables[0].Rows[0]["AadharNo"].ToString();
                                ceifvo.applicationID = dsdept.Tables[0].Rows[0]["intCFOPowerid"].ToString();
                                ceifvo.UID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                                ceifvo.atc = dsdept.Tables[0].Rows[0]["ATC"].ToString();
                                //ceifvo.checkListUploads = "";
                                ceifvo.cli_already_installed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
                                ceifvo.cli_proposed = dsdept.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
                                ceifvo.cmd_already_installed = dsdept.Tables[0].Rows[0]["Connect_Load_A"].ToString();
                                ceifvo.cmd_proposed = dsdept.Tables[0].Rows[0]["Connect_Load_B"].ToString();
                                ceifvo.customer_remarks = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                                ceifvo.email_id = dsdept.Tables[0].Rows[0]["Email"].ToString();
                                ceifvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                ceifvo.file_number = "";// dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.first_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.hno = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                                ceifvo.industry_district_id = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                                ceifvo.industry_hno = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                                ceifvo.industry_mandal_id = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                                ceifvo.industry_pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                                ceifvo.industry_plot_no = dsdept.Tables[0].Rows[0]["PLOTNO"].ToString();
                                ceifvo.industry_street_name = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                                ceifvo.industry_sy_no = dsdept.Tables[0].Rows[0]["Survey_No"].ToString();
                                ceifvo.industry_village_id = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                                ceifvo.last_name = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.loction_district_id = dsdept.Tables[0].Rows[0]["intDistrictid"].ToString();
                                ceifvo.mandal_id = dsdept.Tables[0].Rows[0]["intMandalid"].ToString();
                                ceifvo.mobile_no = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                                ceifvo.name_of_industry = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                                ceifvo.name_of_promoter = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.pan_number = dsdept.Tables[0].Rows[0]["PANcardno"].ToString();
                                ceifvo.pincode = dsdept.Tables[0].Rows[0]["Pincode"].ToString();
                                ceifvo.plant_slno = dsdept.Tables[0].Rows[0]["Plant_slno"].ToString();
                                ceifvo.plot_no = dsdept.Tables[0].Rows[0]["DOOR_nO"].ToString();
                                ceifvo.proposal_for = dsdept.Tables[0].Rows[0]["ProposalForQue"].ToString();
                                ceifvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                ceifvo.regulation_slno = dsdept.Tables[0].Rows[0]["Regulation_type"].ToString();
                                ceifvo.so_do_wo = dsdept.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                                ceifvo.street_name = dsdept.Tables[0].Rows[0]["Street_Name"].ToString();
                                ceifvo.sy_no = "123";// dsdept.Tables[0].Rows[0][""].ToString();
                                ceifvo.system_ip = "1.1.1.1"; ;// dsdept.Tables[0].Rows[0][""].ToString();                                
                                ceifvo.type_of_industry = "35";//dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                                ceifvo.type_of_industry_others = "";// dsdept.Tables[0].Rows[0][""].ToString();                              
                                ceifvo.user_name = dsdept.Tables[0].Rows[0]["User_name"].ToString();
                                ceifvo.password = dsdept.Tables[0].Rows[0]["password"].ToString();
                                ceifvo.village_id = dsdept.Tables[0].Rows[0]["Village_Name"].ToString();
                                ceifvo.voltage_slno = dsdept.Tables[0].Rows[0]["Voltage_Slno"].ToString();
                                DataSet dsBoiler = new DataSet();
                                CEIGService.checkListUploads[] Uploaddocuments = null;
                                dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, "16", "");
                                string attcvalueshmwssb = dsBoiler.GetXml();
                                if (dsBoiler != null && dsBoiler.Tables.Count > 0)
                                {

                                    ///Registration Deed////

                                    //if (dsBoiler.Tables[0].Rows.Count > 0)
                                    //{
                                    DataTable dtceigdocuments = new DataTable();
                                    dtceigdocuments = dsBoiler.Tables[0];
                                    Uploaddocuments = new CEIGService.checkListUploads[dtceigdocuments.Rows.Count];

                                    for (int n = 0; n < dtceigdocuments.Rows.Count; n++)
                                    {
                                        CEIGService.checkListUploads uploadvo = new CEIGService.checkListUploads();
                                        uploadvo.documentName = dtceigdocuments.Rows[n]["FileName"].ToString();
                                        uploadvo.documentPath = dtceigdocuments.Rows[n]["Filepath"].ToString();
                                        uploadvo.documentId = Convert.ToInt32(dtceigdocuments.Rows[n]["Documentid"].ToString());
                                        Uploaddocuments[n] = uploadvo;
                                    }
                                    ceifvo.checkListUploads = Uploaddocuments;
                                    //}
                                }
                                string ceigout = ceifcfo.insertIntoInstallationApproval(ceifvo);
                                if (ceigout == "SUCCESS")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", ceigout, "N");
                                    //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", ceigout, "N");
                                }
                            }
                        }

                        if (deptid == "27") // Boilers
                        {
                            try
                            {
                                BoilerService.plan boilervo = new BoilerService.plan();

                                DataSet dsdept = new DataSet();
                                string valueshmwssb = "";
                                string outputhmwssb = "";
                                string outpayhmwssb = "";
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                                valueshmwssb = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {

                                    boilervo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                                    boilervo.application_stage = Convert.ToInt16(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
                                    //boilervo.application_type = dsdept.Tables[0].Rows[0]["application_type"].ToString();
                                    boilervo.applicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                                    //boilervo.assigned_to_officer_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["assigned_to_officer_id"].ToString());
                                    boilervo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                                    boilervo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                                    boilervo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                                    boilervo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                                    boilervo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                                    boilervo.boiler_maker_name = dsdept.Tables[0].Rows[0]["boiler_maker_name"].ToString();
                                    boilervo.boiler_maker_no = dsdept.Tables[0].Rows[0]["boiler_maker_no"].ToString();
                                    boilervo.boiler_rating = dsdept.Tables[0].Rows[0]["boiler_rating"].ToString();
                                    boilervo.boiler_used_for = dsdept.Tables[0].Rows[0]["boiler_used_for"].ToString();
                                    boilervo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                                    boilervo.component_person_details = dsdept.Tables[0].Rows[0]["component_person_details"].ToString();
                                    boilervo.courier_date = dsdept.Tables[0].Rows[0]["courier_date"].ToString();
                                    boilervo.courier_number = dsdept.Tables[0].Rows[0]["courier_number"].ToString();
                                    boilervo.created_by = Convert.ToInt16(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                                    boilervo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                                    boilervo.district = dsdept.Tables[0].Rows[0]["district"].ToString();
                                    boilervo.door_no = dsdept.Tables[0].Rows[0]["door_no"].ToString();
                                    boilervo.e_district = dsdept.Tables[0].Rows[0]["e_district"].ToString();
                                    boilervo.e_door_no = dsdept.Tables[0].Rows[0]["e_door_no"].ToString();
                                    boilervo.e_email = dsdept.Tables[0].Rows[0]["e_email"].ToString();
                                    boilervo.e_licence_copy_filepath = dsdept.Tables[0].Rows[0]["e_licence_copy_filepath"].ToString();
                                    boilervo.e_locality = dsdept.Tables[0].Rows[0]["e_locality"].ToString();
                                    boilervo.e_mandal = dsdept.Tables[0].Rows[0]["e_mandal"].ToString();
                                    boilervo.e_mobile_no = dsdept.Tables[0].Rows[0]["e_mobile_no"].ToString();
                                    boilervo.e_pincode = dsdept.Tables[0].Rows[0]["e_pincode"].ToString();
                                    boilervo.e_state = dsdept.Tables[0].Rows[0]["e_state"].ToString();
                                    boilervo.e_village = dsdept.Tables[0].Rows[0]["e_village"].ToString();
                                    boilervo.enterpreneur_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                    boilervo.erector_class = dsdept.Tables[0].Rows[0]["erector_class"].ToString();
                                    boilervo.erector_name = dsdept.Tables[0].Rows[0]["erector_name"].ToString();
                                    boilervo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                    //boilervo.inspection_officer = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspection_officer"].ToString());
                                    boilervo.inspector_authority_flag = Convert.ToInt16(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
                                    //boilervo.inspector_designation = dsdept.Tables[0].Rows[0]["inspector_designation"].ToString();
                                    boilervo.locality = dsdept.Tables[0].Rows[0]["locality"].ToString();
                                    boilervo.mandal = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                                    boilervo.max_evaporation = dsdept.Tables[0].Rows[0]["max_evaporation"].ToString();
                                    boilervo.max_pressure = dsdept.Tables[0].Rows[0]["max_pressure"].ToString();
                                    boilervo.owner_contact_no = dsdept.Tables[0].Rows[0]["owner_contact_no"].ToString();
                                    boilervo.owner_email = dsdept.Tables[0].Rows[0]["owner_email"].ToString();
                                    boilervo.owner_name = dsdept.Tables[0].Rows[0]["owner_name"].ToString();
                                    boilervo.payment_status = "NA";
                                    boilervo.pincode = dsdept.Tables[0].Rows[0]["pincode"].ToString();
                                    boilervo.place = dsdept.Tables[0].Rows[0]["place"].ToString();
                                    boilervo.present_status_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["present_status_id"].ToString());
                                    boilervo.quessionaire_id = Convert.ToInt16(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                    boilervo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                    boilervo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                    boilervo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                    boilervo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                    boilervo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                    boilervo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                    boilervo.user_serial_no = Convert.ToInt16(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                    boilervo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                    boilervo.year = dsdept.Tables[0].Rows[0]["year"].ToString();

                                    BoilerService.anexuredocuments[] anexuredocuments = null;
                                    BoilerService.cbbdocuments[] cbbdocument = null;
                                    BoilerService.designdocuments[] designdocument = null;
                                    BoilerService.formdocuments[] form = null;
                                    BoilerService.otherdocuments[] Otherdoc = null;

                                    DataSet dsBoiler = new DataSet();
                                    dsBoiler = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");
                                    string attcvalueshmwssb = dsBoiler.GetXml();
                                    if (dsBoiler != null && dsBoiler.Tables.Count > 0 && dsBoiler.Tables[0].Rows.Count > 0)
                                    {
                                        ///Registration Deed////

                                        if (dsBoiler.Tables[0].Rows.Count > 0)
                                        {
                                            DataTable dtotherdocuments = new DataTable();
                                            dtotherdocuments = dsBoiler.Tables[0];
                                            Otherdoc = new BoilerService.otherdocuments[dtotherdocuments.Rows.Count];

                                            for (int n = 0; n < dtotherdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.otherdocuments otherdocvo = new BoilerService.otherdocuments();
                                                otherdocvo.documentName = dtotherdocuments.Rows[n]["FileName"].ToString();
                                                otherdocvo.documentPath = dtotherdocuments.Rows[n]["Filepath"].ToString();
                                                Otherdoc[n] = otherdocvo;
                                            }
                                            boilervo.otherdocuments = Otherdoc;

                                        }
                                        if (dsBoiler.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtcbbdocuments = new DataTable();
                                            dtcbbdocuments = dsBoiler.Tables[1];
                                            cbbdocument = new BoilerService.cbbdocuments[dtcbbdocuments.Rows.Count];

                                            for (int n = 0; n < dtcbbdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.cbbdocuments cbbvo = new BoilerService.cbbdocuments();
                                                cbbvo.documentName = dtcbbdocuments.Rows[n]["FileName"].ToString();
                                                cbbvo.documentPath = dtcbbdocuments.Rows[n]["Filepath"].ToString();
                                                cbbdocument[n] = cbbvo;
                                            }
                                            boilervo.cbbdocuments = cbbdocument;
                                        }
                                        if (dsBoiler.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtdesigndocuments = new DataTable();
                                            dtdesigndocuments = dsBoiler.Tables[2];
                                            designdocument = new BoilerService.designdocuments[dtdesigndocuments.Rows.Count];

                                            for (int n = 0; n < dtdesigndocuments.Rows.Count; n++)
                                            {
                                                BoilerService.designdocuments designvo = new BoilerService.designdocuments();
                                                designvo.documentName = dtdesigndocuments.Rows[n]["FileName"].ToString();
                                                designvo.documentPath = dtdesigndocuments.Rows[n]["Filepath"].ToString();
                                                designdocument[n] = designvo;
                                            }
                                            boilervo.designdocuments = designdocument;
                                        }
                                        if (dsBoiler.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtformdocuments = new DataTable();
                                            dtformdocuments = dsBoiler.Tables[3];
                                            form = new BoilerService.formdocuments[dtformdocuments.Rows.Count];

                                            for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                            {
                                                BoilerService.formdocuments formvo = new BoilerService.formdocuments();
                                                formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                                formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                                form[n] = formvo;
                                            }
                                            boilervo.formdocuments = form;
                                        }

                                        if (dsBoiler.Tables[4].Rows.Count > 0)
                                        {
                                            DataTable dtanexuredocuments = new DataTable();
                                            dtanexuredocuments = dsBoiler.Tables[4];
                                            anexuredocuments = new BoilerService.anexuredocuments[dtanexuredocuments.Rows.Count];

                                            for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                            {
                                                BoilerService.anexuredocuments annexurevo = new BoilerService.anexuredocuments();
                                                annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                                annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                                anexuredocuments[n] = annexurevo;
                                            }
                                            boilervo.anexuredocuments = anexuredocuments;
                                        }
                                    }

                                    string boilerout = Boiler.registrationofBoilers(boilervo);//SUCCESS
                                    if (boilerout == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "Y");
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", boilerout, "N");
                                        //int k = gen.InsertDeptDateTracing(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["intDeptid"].ToString(), dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", boilerout, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "64") // BOILER STEAM TEST
                        {
                            string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                            string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                            string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
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
                                boilererectionvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["questionniareId"].ToString());

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
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                    try
                                    {
                                        int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                                }
                            }
                        }

                        if (deptid == "63")// BOILER FORM V
                        {
                            string intApprovalid = dt.Rows[i]["intApprovalid"].ToString();
                            string intQuessionaireid = dt.Rows[i]["intQuessionaireid"].ToString();
                            string intDeptid = dt.Rows[i]["intDeptid"].ToString();

                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            //string UIDNO = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                                //string remarks = dsdept.Tables[0].Rows[0]["queryRespText"].ToString();
                                //BoilerQueryResponseServiceTest.TSBoilerServiceImplService Boiler = new BoilerQueryResponseServiceTest.TSBoilerServiceImplService();
                                //BoilerQueryResponseServiceTest.planQR boilervo = new BoilerQueryResponseServiceTest.planQR();
                                FireServiceCFO.Service1 fireservicecfo = new FireServiceCFO.Service1();
                                FactoryQueryResponseServiceCFO.TSFactoryServiceImplService factoryquery = new FactoryQueryResponseServiceCFO.TSFactoryServiceImplService();

                                BoilerService.TSBoilerServiceImplService boilererection = new BoilerService.TSBoilerServiceImplService();
                                BoilerService.errectionCompletion boilererectionvo = new BoilerService.errectionCompletion();


                                //if (intApprovalid == "27")//BOILERS
                                //{
                                boilererectionvo.applicationId = dsdept.Tables[0].Rows[0]["tsipassUid"].ToString();
                                boilererectionvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["entrepreneurId"].ToString());
                                boilererectionvo.system_ip = "0.0.0.0";
                                boilererectionvo.userID = dsdept.Tables[0].Rows[0]["userID"].ToString();

                                BoilerService.errectiondocuments[] lst = null;
                                if (dsdept.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtraw = new DataTable();
                                    dtraw = dsdept.Tables[0];
                                    lst = new BoilerService.errectiondocuments[dtraw.Rows.Count];

                                    for (int k = 0; k < dtraw.Rows.Count; k++)
                                    {
                                        BoilerService.errectiondocuments boilererrectiondocumentsvo = new BoilerService.errectiondocuments();
                                        boilererrectiondocumentsvo.documentName = dtraw.Rows[k]["queryRespDocName"].ToString();
                                        boilererrectiondocumentsvo.documentPath = dtraw.Rows[k]["queryRespDocPath"].ToString();
                                        lst[k] = boilererrectiondocumentsvo;
                                        //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                        //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                    }
                                }
                                boilererectionvo.errdocuments = lst;
                                string boilerout = boilererection.insertIntoErrectionCompletionReport(boilererectionvo);
                                if (boilerout == "SUCCESS")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "Y");
                                    try
                                    {
                                        int k = gen.InsertDeptDateTracingCFO(intDeptid, intQuessionaireid, UIDNO, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "CFO", intApprovalid);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, intApprovalid, "C", boilerout, "N");
                                }
                            }
                        }
                        if (deptid == "18")// FIRE
                        {
                            try
                            {
                                string valuefire = "";
                                string outputfire = "";
                                string fireattachments = "";
                                string outapplicant = "";
                                string outapplicant1 = "";
                                string outescapre = "";
                                DataSet dsdept = new DataSet();
                                DataSet dsfire = new DataSet();
                                DataSet dsfireescape = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                                valuefire = dsdept.GetXml();
                                string output = firecfo.InsertApplicantFireDetails_CFO(valuefire);
                                string[] split = output.Split('-');
                                string applid = split[1];
                                dsfire = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                                if (dsfire != null && dsfire.Tables.Count > 0 && dsfire.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire = new DataTable();
                                    DataTable dtfirenew = new DataTable();
                                    dtfire = dsfire.Tables[1];
                                    dtfirenew = dsfire.Tables[2];
                                    dsfire.Tables.Remove(dtfire);
                                    dsfire.Tables.Remove(dtfirenew);
                                    string fireescape = "";
                                    fireescape = dsfire.GetXml();
                                    outescapre = firecfo.StoreMeansOfEscape_CFO(fireescape);
                                }
                                DataSet dsfire1 = new DataSet();
                                dsfire1 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                                if (dsfire1 != null && dsfire1.Tables.Count > 0 && dsfire1.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire1 = new DataTable();
                                    DataTable dtfire1new = new DataTable();
                                    dtfire1 = dsfire1.Tables[0];
                                    dtfire1new = dsfire1.Tables[2];
                                    dsfire1.Tables.Remove(dtfire1);
                                    dsfire1.Tables.Remove(dtfire1new);

                                    string fireapplicant = "";
                                    fireapplicant = dsfire1.GetXml();
                                    outapplicant = firecfo.StoreFloorwiseApplicantDtls_CFO(fireapplicant);
                                }
                                DataSet dsfire2 = new DataSet();
                                dsfire2 = gen.getfiremeanofescapedetailsonuidCFO(UIDNO, applid);
                                if (dsfire2 != null && dsfire2.Tables.Count > 0 && dsfire2.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfire2 = new DataTable();
                                    DataTable dtfire2new = new DataTable();
                                    dtfire2 = dsfire2.Tables[1];
                                    dtfire2new = dsfire2.Tables[0];
                                    dsfire2.Tables.Remove(dtfire2);
                                    dsfire2.Tables.Remove(dtfire2new);

                                    string firefight = "";
                                    firefight = dsfire2.GetXml();
                                    outapplicant1 = firecfo.StoreFireFightingInstallations_CFO(firefight);
                                }

                                DataSet dsdeptattachmentsfire = new DataSet();
                                dsdeptattachmentsfire = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, applid);
                                fireattachments = dsdeptattachmentsfire.GetXml();
                                outputfire = firecfo.StoreUploadDocuments_CFO(fireattachments);
                                //StringReader str1 = new StringReader(outputfire);
                                //DataSet dsout1 = new DataSet();
                                //dsout1.ReadXml(str1);
                                if (split[0] == "Success" && outescapre == "Success" && outapplicant == "Success" && outapplicant1 == "Success" && outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", outapplicant, "Y");
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outapplicant, "Y");
                                    int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["QuestionnaireId"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                }
                                else
                                {
                                    string outputerror = split[0].ToString() + ',' + outescapre + ',' + outapplicant + ',' + outapplicant1 + ',' + outputfire;
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", outputerror, "N");
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "52")// if (deptid == "48")  // shops and establishment
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();

                                LabourCFOService.shopsEstRegistrations shopactobjnew = new LabourCFOService.shopsEstRegistrations();


                                //LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                //LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                //LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                //LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');
                                    if (actids.Contains("1"))//The Buildings & Other Construction Workers Act
                                    {
                                        // labouract.buildingRegistrationActSelected = true;
                                        labouract.shopRegistrationActSelected = true;
                                        shopactobjnew.actID = "SEF";//dsdept.Tables[0].Rows[0]["actID"].ToString();
                                        shopactobjnew.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        shopactobjnew.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        shopactobjnew.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        shopactobjnew.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        shopactobjnew.compound_fee = 0;// dsdept.Tables[0].Columns[""].ToString();
                                        shopactobjnew.date_commencement = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        shopactobjnew.date_completion = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        shopactobjnew.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                        //  shopactobjnew.establishment_full_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        shopactobjnew.establishment_name = dsdept.Tables[0].Rows[0]["NAME"].ToString();
                                        //   shopactobjnew.establishment_permanent_district = dsdept.Tables[0].Rows[0]["Form1_2_Per_District"].ToString();
                                        //   shopactobjnew.establishment_permanent_door = dsdept.Tables[0].Rows[0]["Form1_2_Per_DoorNo"].ToString();
                                        //  shopactobjnew.establishment_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_2_Per_Mandal"].ToString();
                                        //   shopactobjnew.establishment_permanent_pincode = dsdept.Tables[0].Rows[0]["Form1_2_Per_PinCode"].ToString();
                                        //   shopactobjnew.establishment_permanent_village = dsdept.Tables[0].Rows[0]["Form1_2_Per_Village"].ToString();
                                        shopactobjnew.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        shopactobjnew.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        shopactobjnew.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        shopactobjnew.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        shopactobjnew.establishment_postal_pincode = dsdept.Tables[0].Rows[0]["Form1_Estd_PinCode"].ToString();
                                        shopactobjnew.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        shopactobjnew.manager_agent_designation = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Designation"].ToString();
                                        shopactobjnew.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        shopactobjnew.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        shopactobjnew.manager_agent_email = dsdept.Tables[0].Rows[0]["Form1_Manager_EMail"].ToString();
                                        shopactobjnew.manager_agent_fathername = dsdept.Tables[0].Rows[0]["Form1_1_Manager_FatherName"].ToString();
                                        shopactobjnew.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        shopactobjnew.manager_agent_mobile = dsdept.Tables[0].Rows[0]["Form1_Manager_MobileNo"].ToString();
                                        shopactobjnew.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        shopactobjnew.manager_agent_street = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Locality"].ToString();
                                        shopactobjnew.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        shopactobjnew.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        shopactobjnew.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        // shopactobjnew.other_attachments_1 = "";//dsdept.Tables[0].Columns["other_attachments_1"].ToString();
                                        // shopactobjnew.other_attachments_2 = "";// dsdept.Tables[0].Columns["other_attachments_2"].ToString();
                                        shopactobjnew.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        shopactobjnew.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        shopactobjnew.penality_percentage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        shopactobjnew.penality_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        shopactobjnew.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        shopactobjnew.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                        shopactobjnew.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        shopactobjnew.registration_years = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_years"].ToString());
                                        shopactobjnew.stageID = dsdept.Tables[0].Rows[0]["stageID"].ToString();
                                        shopactobjnew.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        shopactobjnew.total_penality_amount = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_penality_amount"].ToString());
                                        shopactobjnew.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_registration_fee"].ToString());
                                        shopactobjnew.totalAmount = dsdept.Tables[0].Rows[0]["totalAmount"].ToString();
                                        shopactobjnew.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        shopactobjnew.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        shopactobjnew.transaction_status = "Y";
                                        shopactobjnew.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        //labour.tsipassApplicationID = dsdept.Tables[0].Rows[0]["tsipassApplicationID"].ToString();
                                        shopactobjnew.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        shopactobjnew.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        shopactobjnew.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        shopactobjnew.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        shopactobjnew.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();
                                        shopactobjnew.establishment_category = "1";
                                        shopactobjnew.establishment_classification = "1";
                                        shopactobjnew.male_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Male"].ToString();
                                        shopactobjnew.male_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Male"].ToString();
                                        shopactobjnew.female_adults = dsdept.Tables[0].Rows[0]["Form1_1_Employees_Above18_Female"].ToString();
                                        shopactobjnew.female_young = dsdept.Tables[0].Rows[0]["Form1_1_Employees_14_18_Female"].ToString();
                                        shopactobjnew.employees_proof = "";
                                        shopactobjnew.address_proof = "";
                                        shopactobjnew.authorise_letter_proof = "";
                                        shopactobjnew.certificate_incorporation_proof = "";
                                        shopactobjnew.employer_age = dsdept.Tables[0].Rows[0]["Form1_Employer_Age"].ToString();
                                        shopactobjnew.employer_designation = dsdept.Tables[0].Rows[0]["Form1_Employer_Designation"].ToString();
                                        shopactobjnew.employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        shopactobjnew.employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        shopactobjnew.employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        shopactobjnew.employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        shopactobjnew.employer_permanent_locality = dsdept.Tables[0].Rows[0]["Form1_Employer_Locality"].ToString();
                                        shopactobjnew.employer_permanent_pincode = "";// dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();

                                        shopactobjnew.employer_permanent_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        shopactobjnew.employer_permanent_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        shopactobjnew.employer_permanent_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        shopactobjnew.employer_permanent_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        string managerexists = "";
                                        if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"] != null && dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() != "")
                                        {
                                            if (dsdept.Tables[0].Rows[0]["Form1_1_Manager_Agent_Flag"].ToString() == "N")
                                            {
                                                managerexists = "NO";
                                            }
                                            else
                                            {
                                                managerexists = "YES";
                                            }
                                        }
                                        shopactobjnew.manager_exists = managerexists;
                                        shopactobjnew.total_adults = dsdept.Tables[0].Rows[0]["total_adults"].ToString();
                                        shopactobjnew.total_young = dsdept.Tables[0].Rows[0]["total_young"].ToString();
                                        //  labouract.buildingRegistrationActData = labour;

                                        LabourCFOService.shopActsWorkPlaceMultiData[] shopactobj = null;

                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            shopactobj = new LabourCFOService.shopActsWorkPlaceMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsWorkPlaceMultiData workplacevo = new LabourCFOService.shopActsWorkPlaceMultiData();
                                                workplacevo.workPlacedoorNo = dtraw.Rows[k]["Door_No"].ToString();
                                                workplacevo.workPlacelocality = dtraw.Rows[k]["Locality"].ToString();
                                                workplacevo.workPlaceType = dtraw.Rows[k]["Work_Place"].ToString();
                                                shopactobj[k] = workplacevo;
                                            }
                                            shopactobjnew.workPlaceDetails = shopactobj;
                                        }

                                        LabourCFOService.shopActsEmployeesMultiData[] shopactobj1 = null;
                                        if (dsdept.Tables[2].Rows.Count > 0)
                                        {
                                            DataTable dtraw2 = new DataTable();
                                            dtraw2 = dsdept.Tables[2];
                                            shopactobj1 = new LabourCFOService.shopActsEmployeesMultiData[dtraw2.Rows.Count];

                                            for (int k = 0; k < dtraw2.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsEmployeesMultiData workplacevo1 = new LabourCFOService.shopActsEmployeesMultiData();
                                                workplacevo1.employeeGender = dtraw2.Rows[k]["Gender"].ToString();
                                                workplacevo1.employeeName = dtraw2.Rows[k]["Name"].ToString();
                                                workplacevo1.employeeOccupation = dtraw2.Rows[k]["Occupation"].ToString();
                                                shopactobj1[k] = workplacevo1;
                                            }
                                            shopactobjnew.employeesDetails = shopactobj1;
                                        }


                                        LabourCFOService.shopActsFamilyMultiData[] shopactobj3 = null;

                                        if (dsdept.Tables[3].Rows.Count > 0)
                                        {
                                            DataTable dtraw3 = new DataTable();
                                            dtraw3 = dsdept.Tables[3];
                                            shopactobj3 = new LabourCFOService.shopActsFamilyMultiData[dtraw3.Rows.Count];

                                            for (int k = 0; k < dtraw3.Rows.Count; k++)
                                            {
                                                LabourCFOService.shopActsFamilyMultiData workplacevo3 = new LabourCFOService.shopActsFamilyMultiData();
                                                workplacevo3.familyMemberAdultYoung = dtraw3.Rows[k]["Adult_Flag"].ToString();
                                                workplacevo3.familyMemberGender = dtraw3.Rows[k]["Gender"].ToString();
                                                workplacevo3.familyMemberRelationship = dtraw3.Rows[k]["RelationShip"].ToString();
                                                workplacevo3.familyMemeberName = dtraw3.Rows[k]["Name"].ToString();
                                                shopactobj3[k] = workplacevo3;
                                            }
                                            shopactobjnew.familyDetails = shopactobj3;
                                        }
                                        labouract.shopRegistrationActData = shopactobjnew;
                                        labourout = labourserviceCfo.actSelected(labouract);

                                        // labourout = labourserviceCfo.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }

                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "50") // contract labour
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();



                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');
                                    if (actids.Contains("3"))//The Contract Labour Act (Principal Employer)
                                    {

                                        labouract.contractLabourPrincipalEmplyerActSelected = true;
                                        contractvo.actID = "CPF";
                                        contractvo.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        contractvo.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        contractvo.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        contractvo.compound_fee = 0;
                                        contractvo.employees_attachement = "";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                        contractvo.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        contractvo.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        contractvo.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        contractvo.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        contractvo.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        contractvo.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        contractvo.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        contractvo.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        contractvo.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        contractvo.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        contractvo.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        contractvo.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        contractvo.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        contractvo.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        contractvo.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        contractvo.other_attachments_1 = "";
                                        contractvo.other_attachments_2 = "";
                                        contractvo.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        contractvo.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        contractvo.penality_percentage = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_percentage"].ToString());
                                        contractvo.penality_years = 0;//Convert.ToInt32(dsdept.Tables[0].Rows[0]["penality_years"].ToString());
                                        //contractvo.previous_registered_act = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_certificate = dsdept.Tables[0].Rows[0][""].ToString();
                                        //contractvo.previous_registration_no = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        contractvo.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        contractvo.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        contractvo.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        contractvo.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        contractvo.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        contractvo.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        contractvo.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        contractvo.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        contractvo.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                        contractvo.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.registration_years = 0;
                                        contractvo.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        contractvo.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        contractvo.total_penality_amount = 0;
                                        contractvo.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        contractvo.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        contractvo.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        contractvo.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        contractvo.transaction_status = "Y";//dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        contractvo.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        //contractvo.tsipassApplicationID = dsdept.Tables[0].Rows[0][""].ToString();
                                        contractvo.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        contractvo.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        contractvo.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        contractvo.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        contractvo.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourCFOService.contractLabourPrincipalEmployerMultiData[] contractmulti = null;

                                        //contractvo.contractorParticulars[] lstitem = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            contractmulti = new LabourCFOService.contractLabourPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourCFOService.contractLabourPrincipalEmployerMultiData coc = new LabourCFOService.contractLabourPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                contractmulti[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            contractvo.contractorParticulars = contractmulti;
                                            //rawvo.materialDescr
                                        }

                                        labouract.contractLabourPrincipalEmplyerActData = contractvo;
                                        labourout = labourserviceCfo.actSelected(labouract);

                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        if (deptid == "51")
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                DataSet dsdeptattachments = new DataSet();
                                dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);

                                LabourCFOService.act labouract = new LabourCFOService.act();
                                LabourCFOService.buildingotherconstructions labour = new LabourCFOService.buildingotherconstructions();
                                LabourCFOService.actsResponse labourout = new LabourCFOService.actsResponse();
                                LabourCFOService.contractLabourPrincipalEmployer contractvo = new LabourCFOService.contractLabourPrincipalEmployer();
                                LabourCFOService.ismwPrincipalEmployer migrateemployer = new LabourCFOService.ismwPrincipalEmployer();

                                string actids = "";
                                string actid = "";
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    actids = dsdept.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                                    string[] split = actids.Split(',');

                                    if (actids.Contains("4"))//Principal Employer Registration Under InterState Migrant Workman Act
                                    {
                                        labouract.interstateMigrantPrincipalEmplyerActSelected = true;
                                        migrateemployer.actID = "ISMWPEF";
                                        migrateemployer.bank_code = dsdept.Tables[0].Rows[0]["bank_code"].ToString();
                                        migrateemployer.bank_ref_number = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                        migrateemployer.cin = dsdept.Tables[0].Rows[0]["cin"].ToString();
                                        migrateemployer.compound_fee = 0;
                                        migrateemployer.director_district = dsdept.Tables[0].Rows[0]["Form1_4_Dir_District"].ToString();
                                        migrateemployer.director_door = dsdept.Tables[0].Rows[0]["Form1_4_Dir_DoorNo"].ToString();
                                        migrateemployer.director_mandal = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Mandal"].ToString();
                                        migrateemployer.director_name = dsdept.Tables[0].Rows[0]["Form1_4_Dir_FullName"].ToString();
                                        migrateemployer.director_village = dsdept.Tables[0].Rows[0]["Form1_4_Dir_Village"].ToString();
                                        migrateemployer.employees_attachement = "";
                                        migrateemployer.entrepreneur_id = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                                        migrateemployer.establishment_category = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Category"].ToString();
                                        migrateemployer.establishment_category_others = dsdept.Tables[0].Rows[0]["Form1_1_Estb_Classification"].ToString();
                                        migrateemployer.establishment_name = dsdept.Tables[0].Rows[0]["Form1_Estb_Name"].ToString();
                                        migrateemployer.establishment_postal_district = dsdept.Tables[0].Rows[0]["Form1_Estd_District"].ToString();
                                        migrateemployer.establishment_postal_door = dsdept.Tables[0].Rows[0]["Form1_Estd_DoorNo"].ToString();
                                        migrateemployer.establishment_postal_locality = dsdept.Tables[0].Rows[0]["Form1_Estd_Locality"].ToString();
                                        migrateemployer.establishment_postal_mandal = dsdept.Tables[0].Rows[0]["Form1_Estd_Mandal"].ToString();
                                        migrateemployer.establishment_postal_village = dsdept.Tables[0].Rows[0]["Form1_Estd_Village"].ToString();
                                        migrateemployer.ipass_status_id = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.manager_agent_district = dsdept.Tables[0].Rows[0]["Form1_1_Manager_District"].ToString();
                                        migrateemployer.manager_agent_door = dsdept.Tables[0].Rows[0]["Form1_1_Manager_DoorNo"].ToString();
                                        migrateemployer.manager_agent_mandal = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Mandal"].ToString();
                                        migrateemployer.manager_agent_name = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Name"].ToString();
                                        migrateemployer.manager_agent_village = dsdept.Tables[0].Rows[0]["Form1_1_Manager_Village"].ToString();
                                        migrateemployer.max_employees_aday = dsdept.Tables[0].Rows[0]["Form1_2_MaxWorkers"].ToString();
                                        migrateemployer.nature_work = dsdept.Tables[0].Rows[0]["Form1_Nature_of_Business"].ToString();
                                        migrateemployer.other_attachments_1 = "";
                                        migrateemployer.other_attachments_2 = "";
                                        migrateemployer.payment_mode = dsdept.Tables[0].Rows[0]["payment_mode"].ToString();
                                        migrateemployer.paymentFlag = dsdept.Tables[0].Rows[0]["paymentFlag"].ToString();
                                        migrateemployer.penality_percentage = 0;
                                        migrateemployer.penality_years = 0;
                                        migrateemployer.previous_registered_act = "";
                                        migrateemployer.previous_registration_certificate = "";
                                        migrateemployer.previous_registration_no = "";
                                        migrateemployer.principal_employer_district = dsdept.Tables[0].Rows[0]["Form1_Employer_District"].ToString();
                                        migrateemployer.principal_employer_door = dsdept.Tables[0].Rows[0]["Form1_Employer_DoorNo"].ToString();
                                        migrateemployer.principal_employer_email = dsdept.Tables[0].Rows[0]["Form1_Employer_EmailID"].ToString();
                                        migrateemployer.principal_employer_fathername = dsdept.Tables[0].Rows[0]["Form1_Empolyer_FatherName"].ToString();
                                        migrateemployer.principal_employer_mandal = dsdept.Tables[0].Rows[0]["Form1_Employer_Mandal"].ToString();
                                        migrateemployer.principal_employer_mobile = dsdept.Tables[0].Rows[0]["Form1_Employer_MobileNo"].ToString();
                                        migrateemployer.principal_employer_name = dsdept.Tables[0].Rows[0]["Form1_Employer_Name"].ToString();
                                        migrateemployer.principal_employer_village = dsdept.Tables[0].Rows[0]["Form1_Employer_Village"].ToString();
                                        migrateemployer.projectSubmitDate = dsdept.Tables[0].Rows[0]["projectSubmitDate"].ToString();
                                        migrateemployer.questionnaire_id = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                        migrateemployer.registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.registration_years = 0;
                                        migrateemployer.stageID = dsdept.Tables[0].Rows[0]["intStageid"].ToString();
                                        migrateemployer.total_amount_payable = Convert.ToInt32(dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString());
                                        migrateemployer.total_penality_amount = 0;
                                        migrateemployer.total_registration_fee = Convert.ToInt32(dsdept.Tables[0].Rows[0]["registration_fee"].ToString());
                                        migrateemployer.totalAmount = dsdept.Tables[0].Rows[0]["total_amount_payable"].ToString();
                                        migrateemployer.transaction_for = dsdept.Tables[0].Rows[0]["transaction_for"].ToString();
                                        migrateemployer.transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.transaction_status = "Y";
                                        migrateemployer.transactionDate = dsdept.Tables[0].Rows[0]["transactionDate"].ToString();
                                        migrateemployer.transactionNumber = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                        migrateemployer.type_of_application = dsdept.Tables[0].Rows[0]["type_of_application"].ToString();
                                        migrateemployer.uID = dsdept.Tables[0].Rows[0]["UID_NO"].ToString();
                                        migrateemployer.unpaid_balance_welfare = Convert.ToInt32(dsdept.Tables[0].Rows[0]["unpaid_balance_welfare"].ToString());
                                        migrateemployer.valid_from_date = dsdept.Tables[0].Rows[0]["Form1_1_DateofCommencement"].ToString();
                                        migrateemployer.valid_to_date = dsdept.Tables[0].Rows[0]["Form1_2_Est_Compltd_Dt"].ToString();

                                        LabourCFOService.ismwPrincipalEmployerMultiData[] migrantvo = null;
                                        ContractorDetails co = new ContractorDetails();
                                        //FactoryService.rawMaterial[] lst = null;
                                        if (dsdept.Tables[1].Rows.Count > 0)
                                        {
                                            DataTable dtraw = new DataTable();
                                            dtraw = dsdept.Tables[1];
                                            migrantvo = new LabourCFOService.ismwPrincipalEmployerMultiData[dtraw.Rows.Count];

                                            for (int k = 0; k < dtraw.Rows.Count; k++)
                                            {
                                                //FactoryService.rawMaterial BBB = new FactoryService.rawMaterial();
                                                LabourCFOService.ismwPrincipalEmployerMultiData coc = new LabourCFOService.ismwPrincipalEmployerMultiData();
                                                coc.contractorAddress = dtraw.Rows[k]["Contractor_Address"].ToString();
                                                coc.commencementDate = dtraw.Rows[k]["Contractor_Est_Commence_Dt"].ToString();
                                                coc.terminationDate = dtraw.Rows[k]["Contractor_Est_Compltd_Dt"].ToString();
                                                //coc.m = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                coc.contractorName = dtraw.Rows[k]["Contractor_Name"].ToString();
                                                coc.maxcontractLabour = dtraw.Rows[k]["Contractor_MaxWorkers"].ToString();
                                                coc.natureOfWork = dtraw.Rows[k]["Contractor_Work_Nature"].ToString();
                                                coc.manufacturingDeptDetails = dtraw.Rows[k]["Contractor_ManufacturingDepts"].ToString();
                                                coc.mobileNo = dtraw.Rows[k]["Contractor_MobileNo"].ToString();
                                                migrantvo[k] = coc;
                                                //factoryvo.rawMaterials[k].materialDescr = dtraw.Rows[k]["Raw_ItemName"].ToString();
                                                //rawvo.materialDescr = dtraw.Rows[i]["Raw_ItemName"].ToString();
                                            }
                                            migrateemployer.contractorParticulars = migrantvo;
                                            //rawvo.materialDescr
                                        }
                                        labouract.interstateMigrantPrincipalEmplyerActData = migrateemployer;
                                        labourout = labourserviceCfo.actSelected(labouract);
                                        if (labourout.status == "SUCCESS")
                                        {
                                            string labouroutmsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", labouroutmsg, "Y");
                                            int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                                        }
                                        else
                                        {
                                            string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                            gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "N", labourouterrormsg, "N");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "15")//FACTORIES
                        {

                            FactoryServiceCFO.grantLicense factoryvo = new FactoryServiceCFO.grantLicense();

                            string outputfactory = "";
                            string valuefactory = "";
                            DataSet dsdept = new DataSet();
                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            valuefactory = dsdept.GetXml();
                            //outputfactory = factory.insertIntoPlanApproval(factoryvo);


                            factoryvo.amountToBePaid = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.applicationID = dsdept.Tables[0].Rows[0]["UID_No"].ToString();
                            factoryvo.applicationStageID = dsdept.Tables[0].Rows[0]["intstageid"].ToString();
                            factoryvo.applicationStatus = "Pre-Scuitiny Pending"; //dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.applicationSubmittedDate = dsdept.Tables[0].Rows[0]["UID_NOGenerateDate"].ToString();

                            //factoryvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                            //factoryvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                            //factoryvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                            //factoryvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                            factoryvo.communicationAddress = dsdept.Tables[0].Rows[0]["communicationAddress"].ToString();
                            factoryvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                            factoryvo.factoryDistrictID = dsdept.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                            factoryvo.factoryDoorNumber = dsdept.Tables[0].Rows[0]["Door_No"].ToString();
                            factoryvo.factoryLocality = dsdept.Tables[0].Rows[0]["StreetName"].ToString();
                            factoryvo.factoryMandalID = dsdept.Tables[0].Rows[0]["Prop_intMandalid"].ToString();
                            factoryvo.factoryName = dsdept.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                            factoryvo.factoryOccupationDateByOccupier = dsdept.Tables[0].Rows[0]["Date_Occupation"].ToString();// 
                            factoryvo.factoryPinCode = dsdept.Tables[0].Rows[0]["Land_Pincode"].ToString();
                            factoryvo.factoryType = dsdept.Tables[0].Rows[0]["TypeofFactory"].ToString();
                            factoryvo.factoryVillageID = dsdept.Tables[0].Rows[0]["Prop_intVillageid"].ToString();
                            factoryvo.horsePowerToBeInstalledRegular = dsdept.Tables[0].Rows[0]["RegularHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledRegularUnits = "HP";
                            factoryvo.horsePowerToBeInstalledStandby = dsdept.Tables[0].Rows[0]["StandbyHp"].ToString(); //dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.horsePowerToBeInstalledStandbyUnits = "HP";
                            factoryvo.managerDistrict = dsdept.Tables[0].Rows[0]["Mangr_District"].ToString();
                            factoryvo.managerDoorNo = dsdept.Tables[0].Rows[0]["Mangr_DoorNo"].ToString();
                            factoryvo.managerFullName = dsdept.Tables[0].Rows[0]["Mangr_Full_Name"].ToString();
                            factoryvo.managerLocality = dsdept.Tables[0].Rows[0]["Mangr_Locality"].ToString();
                            factoryvo.managerMailId = dsdept.Tables[0].Rows[0]["Mangr_EmailId"].ToString();
                            factoryvo.managerMandal = dsdept.Tables[0].Rows[0]["Mangr_Mandal"].ToString();
                            factoryvo.managerMobileNumber = dsdept.Tables[0].Rows[0]["Mangr_MobileNo"].ToString();
                            factoryvo.managerPinCode = dsdept.Tables[0].Rows[0]["Mangr_PinCode"].ToString();
                            factoryvo.managerVillage = dsdept.Tables[0].Rows[0]["Mangr_Village"].ToString();
                            factoryvo.natureOfManufacturingProcessMain = dsdept.Tables[0].Rows[0]["MAIN"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.natureOfManufacturingProcessSecondary = dsdept.Tables[0].Rows[0]["SECONDARYITEM"].ToString();// dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.noOfyearsSelectedToPayLicenceFee = dsdept.Tables[0].Rows[0]["LicenseYear"].ToString();
                            factoryvo.occupierDistrict = dsdept.Tables[0].Rows[0]["Occupier_District"].ToString();
                            factoryvo.occupierDoorNo = dsdept.Tables[0].Rows[0]["Occupier_DoorNo"].ToString();
                            factoryvo.occupierFullName = dsdept.Tables[0].Rows[0]["Occupier_Full_Name"].ToString();
                            factoryvo.occupierLocality = dsdept.Tables[0].Rows[0]["Occupier_Locality"].ToString();
                            factoryvo.occupierMailId = dsdept.Tables[0].Rows[0]["Occupier_EmailId"].ToString();
                            factoryvo.occupierMandal = dsdept.Tables[0].Rows[0]["Occupier_Mandal"].ToString();
                            factoryvo.occupierMobileNumber = dsdept.Tables[0].Rows[0]["Occupier_MobileNo"].ToString();
                            factoryvo.occupierOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierPinCode = dsdept.Tables[0].Rows[0]["Occupier_PinCode"].ToString();
                            factoryvo.occupierPositionInFactory = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.occupierVillage = dsdept.Tables[0].Rows[0]["Occupier_Village"].ToString();
                            factoryvo.ownerDistrict = dsdept.Tables[0].Rows[0]["Owner_District"].ToString();
                            factoryvo.ownerDoorNo = dsdept.Tables[0].Rows[0]["Owner_DoorNo"].ToString();
                            factoryvo.ownerFullName = dsdept.Tables[0].Rows[0]["Owner_Full_Name"].ToString();
                            factoryvo.ownerLocality = dsdept.Tables[0].Rows[0]["Owner_Locality"].ToString();
                            factoryvo.ownerMailId = dsdept.Tables[0].Rows[0]["Owner_EmailId"].ToString();
                            factoryvo.ownerMandal = dsdept.Tables[0].Rows[0]["Owner_Mandal"].ToString();
                            factoryvo.ownerMobileNumber = dsdept.Tables[0].Rows[0]["Owner_MobileNo"].ToString();
                            factoryvo.ownerOtherStatePostalAddress = "NA";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerPinCode = dsdept.Tables[0].Rows[0]["Owner_PinCode"].ToString();
                            factoryvo.ownerState = "36";//dsdept.Tables[0].Rows[0][""].ToString();
                            factoryvo.ownerVillage = dsdept.Tables[0].Rows[0]["Owner_Village"].ToString();
                            factoryvo.paidAmount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                            factoryvo.paymentStatus = dsdept.Tables[0].Rows[0]["IsPayment"].ToString();
                            factoryvo.plansReferenceApprovedByChiefInspectorIfApplicable = dsdept.Tables[0].Rows[0]["Plans_Chief_Inspector_RefNo"].ToString();//Plans_Chief_Inspector_RefNo
                            factoryvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                            factoryvo.systemIP = "0.0.0.0";// dsdept.Tables[0].Columns[""].ToString();
                            factoryvo.userID = dsdept.Tables[0].Rows[0]["CREATEDBY"].ToString();
                            factoryvo.userMailID = dsdept.Tables[0].Rows[0]["Email"].ToString();
                            factoryvo.userMobileNumber = dsdept.Tables[0].Rows[0]["MobileNumber"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsFemale = dsdept.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                            factoryvo.workersToBeEmployedAdolescentsMale = dsdept.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                            factoryvo.workersToBeEmployedAdultsFemale = dsdept.Tables[0].Rows[0]["AdultFemale"].ToString();
                            factoryvo.workersToBeEmployedAdultsMale = dsdept.Tables[0].Rows[0]["AdultMale"].ToString();
                            factoryvo.workersToBeEmployedChildrenFemale = dsdept.Tables[0].Rows[0]["Children_Female"].ToString();
                            factoryvo.workersToBeEmployedChildrenMale = dsdept.Tables[0].Rows[0]["Children_Male"].ToString();

                        factoryvo.workersToBeEmployedAdolescentsTrans = dsdept.Tables[0].Rows[0]["AdolescentsTRANS"].ToString();
                        factoryvo.workersToBeEmployedAdultsTrans = dsdept.Tables[0].Rows[0]["AdultTRANS"].ToString();
                        factoryvo.workersToBeEmployedChildrenTrans = dsdept.Tables[0].Rows[0]["Children_TRANS"].ToString();

                        FactoryServiceCFO.aadharCardOrPanCard[] factoryaadhar = null;
                            FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[] factoryrefapproved = null;
                            FactoryServiceCFO.latestListOfPartnersOrDirectors[] factorypartner = null;
                            FactoryServiceCFO.partnershipDeed[] factorypartnershipdeed = null;
                            FactoryServiceCFO.passPortSizePhotographWithSignature[] factoryphotosign = null;
                            FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[] factoryregisteredsaledeed = null;

                            FactoryServiceCFO.factoryOccupierAndManagerPhotoIDProof[] factoryoccupierIdPrrof = null;
                            FactoryServiceCFO.inCaseChangeOfDirectorsFormNo32[] factorydirector = null;
                            FactoryServiceCFO.proposedInventoriesOfChemicalsUsed[] factoryinventories = null;

                        FactoryServiceCFO.machinery[] factmachineries = null;
                        FactoryServiceCFO.workersList[] factworkersList = null;
                        FactoryServiceCFO.selfComplianceChecklist[] factselfComplianceChecklist = null;

                        DataSet dsfactroy = new DataSet();
                            dsfactroy = gen.getattachmentdetailsonuidCFO(UIDNO, deptid, "");

                            if (dsfactroy != null && dsfactroy.Tables.Count > 0 && dsfactroy.Tables[0].Rows.Count > 0)
                            {
                                ///Registration Deed////

                                if (dsfactroy.Tables[0].Rows.Count > 0)
                                {
                                    DataTable dtfactoryaadhar = new DataTable();
                                    dtfactoryaadhar = dsfactroy.Tables[0];
                                    factoryaadhar = new FactoryServiceCFO.aadharCardOrPanCard[dtfactoryaadhar.Rows.Count];

                                    for (int n = 0; n < dtfactoryaadhar.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.aadharCardOrPanCard factoryaadharvo = new FactoryServiceCFO.aadharCardOrPanCard();
                                        factoryaadharvo.documentName = dtfactoryaadhar.Rows[n]["FileName"].ToString();
                                        factoryaadharvo.documentPath = dtfactoryaadhar.Rows[n]["Filepath"].ToString();
                                        factoryaadhar[n] = factoryaadharvo;
                                    }
                                }
                                if (dsfactroy.Tables[1].Rows.Count > 0)
                                {
                                    DataTable dtfactoryrefapproved = new DataTable();
                                    dtfactoryrefapproved = dsfactroy.Tables[1];
                                    factoryrefapproved = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories[dtfactoryrefapproved.Rows.Count];

                                    for (int o = 0; o < dtfactoryrefapproved.Rows.Count; o++)
                                    {
                                        FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories factoryrefapprovedvo = new FactoryServiceCFO.plansReferenceApprovedByDirectorOfFactories();
                                        factoryrefapprovedvo.documentName = dtfactoryrefapproved.Rows[o]["FileName"].ToString();
                                        factoryrefapprovedvo.documentPath = dtfactoryrefapproved.Rows[o]["Filepath"].ToString();
                                        factoryrefapproved[o] = factoryrefapprovedvo;
                                    }
                                }
                                if (dsfactroy.Tables[2].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartner = new DataTable();
                                    dtfactorypartner = dsfactroy.Tables[2];
                                    factorypartner = new FactoryServiceCFO.latestListOfPartnersOrDirectors[dtfactorypartner.Rows.Count];

                                    for (int p = 0; p < dtfactorypartner.Rows.Count; p++)
                                    {
                                        FactoryServiceCFO.latestListOfPartnersOrDirectors factorypartnervo = new FactoryServiceCFO.latestListOfPartnersOrDirectors();
                                        factorypartnervo.documentName = dtfactorypartner.Rows[p]["FileName"].ToString();
                                        factorypartnervo.documentPath = dtfactorypartner.Rows[p]["Filepath"].ToString();
                                        factorypartner[p] = factorypartnervo;
                                    }
                                }
                                if (dsfactroy.Tables[3].Rows.Count > 0)
                                {
                                    DataTable dtfactorypartnershipdeed = new DataTable();
                                    dtfactorypartnershipdeed = dsfactroy.Tables[3];
                                    factorypartnershipdeed = new FactoryServiceCFO.partnershipDeed[dtfactorypartnershipdeed.Rows.Count];

                                    for (int n = 0; n < dtfactorypartnershipdeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.partnershipDeed factorypartnershipdeedvo = new FactoryServiceCFO.partnershipDeed();
                                        factorypartnershipdeedvo.documentName = dtfactorypartnershipdeed.Rows[n]["FileName"].ToString();
                                        factorypartnershipdeedvo.documentPath = dtfactorypartnershipdeed.Rows[n]["Filepath"].ToString();
                                        factorypartnershipdeed[n] = factorypartnershipdeedvo;
                                    }
                                }
                                if (dsfactroy.Tables[4].Rows.Count > 0)
                                {
                                    DataTable dtfactoryphotosign = new DataTable();
                                    dtfactoryphotosign = dsfactroy.Tables[4];
                                    factoryphotosign = new FactoryServiceCFO.passPortSizePhotographWithSignature[dtfactoryphotosign.Rows.Count];

                                    for (int n = 0; n < dtfactoryphotosign.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.passPortSizePhotographWithSignature factoryphotosignvo = new FactoryServiceCFO.passPortSizePhotographWithSignature();
                                        factoryphotosignvo.documentName = dtfactoryphotosign.Rows[n]["FileName"].ToString();
                                        factoryphotosignvo.documentPath = dtfactoryphotosign.Rows[n]["Filepath"].ToString();
                                        factoryphotosign[n] = factoryphotosignvo;
                                    }
                                }
                                if (dsfactroy.Tables[5].Rows.Count > 0)
                                {
                                    DataTable dtfactoryregisteredsaledeed = new DataTable();
                                    dtfactoryregisteredsaledeed = dsfactroy.Tables[5];
                                    factoryregisteredsaledeed = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed[dtfactoryregisteredsaledeed.Rows.Count];

                                    for (int n = 0; n < dtfactoryregisteredsaledeed.Rows.Count; n++)
                                    {
                                        FactoryServiceCFO.registeredSaleDeedOrLeaseDeed factoryregisteredsaledeedvo = new FactoryServiceCFO.registeredSaleDeedOrLeaseDeed();
                                        factoryregisteredsaledeedvo.documentName = dtfactoryregisteredsaledeed.Rows[n]["FileName"].ToString();
                                        factoryregisteredsaledeedvo.documentPath = dtfactoryregisteredsaledeed.Rows[n]["Filepath"].ToString();
                                        factoryregisteredsaledeed[n] = factoryregisteredsaledeedvo;
                                    }
                                }
                            if (dsfactroy.Tables[8].Rows.Count > 0)
                            {
                                DataTable dtmachinery = new DataTable();
                                dtmachinery = dsfactroy.Tables[8];
                                factmachineries = new FactoryServiceCFO.machinery[dtmachinery.Rows.Count];

                                for (int n = 0; n < dtmachinery.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.machinery factoryrmachineryvo = new FactoryServiceCFO.machinery();
                                    factoryrmachineryvo.documentName = dtmachinery.Rows[n]["FileName"].ToString();
                                    factoryrmachineryvo.documentPath = dtmachinery.Rows[n]["Filepath"].ToString();
                                    factmachineries[n] = factoryrmachineryvo;
                                }
                            }

                            if (dsfactroy.Tables[9].Rows.Count > 0)
                            {
                                DataTable dtselfcompchklist = new DataTable();
                                dtselfcompchklist = dsfactroy.Tables[9];
                                factselfComplianceChecklist = new FactoryServiceCFO.selfComplianceChecklist[dtselfcompchklist.Rows.Count];

                                for (int n = 0; n < dtselfcompchklist.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.selfComplianceChecklist factselfComplianceChecklistvo = new FactoryServiceCFO.selfComplianceChecklist();
                                    factselfComplianceChecklistvo.documentName = dtselfcompchklist.Rows[n]["FileName"].ToString();
                                    factselfComplianceChecklistvo.documentPath = dtselfcompchklist.Rows[n]["Filepath"].ToString();
                                    factselfComplianceChecklist[n] = factselfComplianceChecklistvo;
                                }
                            }

                            if (dsfactroy.Tables[10].Rows.Count > 0)
                            {
                                DataTable dtworkerslist = new DataTable();
                                dtworkerslist = dsfactroy.Tables[10];
                                factworkersList = new FactoryServiceCFO.workersList[dtworkerslist.Rows.Count];

                                for (int n = 0; n < dtworkerslist.Rows.Count; n++)
                                {
                                    FactoryServiceCFO.workersList factworkersListvo = new FactoryServiceCFO.workersList();
                                    factworkersListvo.documentName = dtworkerslist.Rows[n]["FileName"].ToString();
                                    factworkersListvo.documentPath = dtworkerslist.Rows[n]["Filepath"].ToString();
                                    factworkersList[n] = factworkersListvo;
                                }
                            }
                        }


                            factoryvo.aadharCardOrPanCardAttachments = factoryaadhar;
                            factoryvo.plansReferenceApprovedByDirectorOfFactoriesAttachments = factoryrefapproved;
                            factoryvo.latestListOfPartnersOrDirectorsAttachments = factorypartner;
                            factoryvo.partnershipDeedAttachments = factorypartnershipdeed;
                            factoryvo.passPortSizePhotographWithSignatureAttachments = factoryphotosign;
                            factoryvo.registeredSaleDeedOrLeaseDeedAttachments = factoryregisteredsaledeed;
                            factoryvo.factoryOccupierAndManagerPhotoIDProofAttachments = factoryoccupierIdPrrof;
                            factoryvo.inCaseChangeOfDirectorsFormNo32Attachments = factorydirector;
                            factoryvo.proposedInventoriesOfChemicalsUsedAttachments = factoryinventories;

                        factoryvo.machineryAttachments = factmachineries;
                        factoryvo.selfComplianceChecklistAttachments = factselfComplianceChecklist;
                        factoryvo.workersListAttachments = factworkersList;

                        string OUTPUT = factorycfo.insertIntoGrantLicense(factoryvo);

                            if (OUTPUT == "SUCCESS")
                            {

                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "Y");
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "A", OUTPUT, "Y");
                                int k = gen.InsertDeptDateTracingCFO(dsdept.Tables[0].Rows[0]["DEPTID"].ToString(), dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFO", deptid);
                            }
                            else
                            {
                                gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "C", OUTPUT, "N");
                            }
                        }
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int i = 0; i < dtadd.Rows.Count; i++)
                    {
                        string deptid = dtadd.Rows[i]["intApprovalid"].ToString();
                    string intQuessionairecfoid = dtadd.Rows[i]["intQuessionaireid"].ToString();
                    string intcfoenterpid = dtadd.Rows[i]["intCFOEnterpid"].ToString();
                    string INTDEPDID = dtadd.Rows[i]["intDeptid"].ToString();
                    if (deptid == "14")
                        {
                            DataSet dsdept = new DataSet();

                            dsdept = gen.getdepartmentdetailsonuidCFO(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "T";

                                //string WEBSERVICE_URL = "http://164.100.163.19/TLWSC/updateFee?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&additionalPayment=" + additionalPayment + "";

                                string WEBSERVICE_URL1 = "http://tsocmms.nic.in/TLWS/updateCl?cafUniqueNo=" + cafUniqueNo + "&indApplicationNo=" + indApplication + "&remark=" + "AdditionalAmountSubmitted" + "&urlSingle=" + "";

                                try
                                {
                                    var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL1);
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
                                                if (jsonResponse.Contains("submitted successfully"))
                                                {
                                                    //gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    //gen.UpdateDepartwebserviceflag(UIDNO, deptid, "AP", jsonResponse, "N");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }


                                string WEBSERVICE_URL = "http://tsocmms.nic.in/TLWS/updateFee?cafUniqueNo=" + cafUniqueNo + "&transactionId=" + transactionId + "&amount=" + amount + "&bankName=" + bankName + "&transactionStatus=" + transactionStatus + "&paymentType=" + paymentType + "&indApplicationNo=" + indApplication + "&additionalPayment=" + additionalPayment + "";


                                //string jsonData = "{\"cafUniqueNo\" : \""+cafUniqueNo+"\", \"transactionId\":\""+transactionId+"\" , \"amount\":\""+amount+"\" , \"bankName\":\""+bankName+"\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
                                //string jsonData = "cafUniqueNo" : \"" + cafUniqueNo + "\", \"transactionId\":\"" + transactionId + "\" , \"amount\":\"" + amount + "\" , \"bankName\":\"" + bankName + "\" , \"transactionStatus\":\"S\" , \"paymentType\":\"NB\"}";
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
                                                if (jsonResponse.Contains("Fee submitted successfully"))
                                                {
                                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", jsonResponse, "N");
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
                        }
                        if (deptid == "16")
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    CEIGService.payment ceigpaymentvo = new CEIGService.payment();
                                    ceigpaymentvo.amount = Convert.ToDouble(dsdept.Tables[0].Rows[0]["Online_Amount"].ToString());
                                    //ceigpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                    ceigpaymentvo.bank_id = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    ceigpaymentvo.branch_name = "";
                                    ceigpaymentvo.challan_copy = "";
                                    ceigpaymentvo.challan_date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    ceigpaymentvo.challan_no = dsdept.Tables[0].Rows[0]["challano"].ToString();
                                    ceigpaymentvo.entrepreneurID = dsdept.Tables[0].Rows[0]["intCFEEnterpid"].ToString();
                                    ceigpaymentvo.payment_type = dsdept.Tables[0].Rows[0]["paymentmode"].ToString();
                                    ceigpaymentvo.questionaireID = dsdept.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString();
                                    ceigpaymentvo.reply_document = "";
                                    ceigpaymentvo.reply_remarks = "";
                                    ceigpaymentvo.system_ip = "1.1.1.1"; ;
                                    ceigpaymentvo.tx_id = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    ceigpaymentvo.UID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    string outceigpayment = ceifcfo.updatePayment(ceigpaymentvo);

                                    if (outceigpayment == "SUCCESS")
                                    {

                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "Y");

                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outceigpayment, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "15") //FACTORY
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    FactoryServiceCFO.grantLicenseAdditionalPayment factorycfovo = new FactoryServiceCFO.grantLicenseAdditionalPayment();
                                    factorycfovo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factorycfovo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    factorycfovo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    factorycfovo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    factorycfovo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    factorycfovo.paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    factorycfovo.systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    factorycfovo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[1].Rows.Count > 0)
                                {
                                    factorycfovo.harithanidhibankamount = dsdept.Tables[1].Rows[0]["Online_Amount"].ToString();
                                    factorycfovo.harithanidhibankdate = dsdept.Tables[1].Rows[0]["TransactionDate"].ToString();
                                    factorycfovo.harithanidhibankname = dsdept.Tables[1].Rows[0]["BankName"].ToString();
                                    factorycfovo.harithanidhibankstatus = dsdept.Tables[1].Rows[0]["PaymentFlag"].ToString();
                                    factorycfovo.harithanidhichallanno = dsdept.Tables[1].Rows[0]["TransactionNO"].ToString();
                                }

                                // string outfactory = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);

                                //if (outfactory == "SUCCESS")
                                //{

                                //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "Y");

                                //}
                                //else
                                //{
                                //    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outfactory, "N");
                                //}
                                var response = factorycfo.insertIntoGrantLicenseAdditionalPayment(factorycfovo);
                                string allottedOfficer = response.allottedOfficer;
                                string applicationId = response.applicationId;
                                string certificatePath = response.certificatePath;
                                string entrepreneurId = response.entrepreneurId;
                                string questionaireId = response.questionaireId;
                                string registrationNo = response.registrationNo;
                                string remarks = response.remarks;
                                string result = response.result;   // SUCCESS / FAIL
                                string status = response.status;
                                string remarkswithallotedofficerandapplicationid = "";
                                remarkswithallotedofficerandapplicationid = "alloted officer: " + allottedOfficer + " , " + "factories application id: " + applicationId + " , " + "Remarks: " + remarks + " , " + "Status: " + status;
                                if (result == "SUCCESS")
                                {

                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "Y");
                                    if (status == "Approval Issued" && remarks == "Auto Generation")
                                    {
                                        DepartmentApprovalSystem obj = new DepartmentApprovalSystem();
                                        obj.DepartmentApprovalProcessAndCertificateUploadCFO(intQuessionairecfoid, intcfoenterpid, deptid, INTDEPDID, "13", UIDNO + ".pdf", certificatePath, remarkswithallotedofficerandapplicationid, registrationNo, "");
                                    }
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", result, "N");
                                }
                            }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "18")/// FIRE
                        {
                            try
                            {
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                string UIDNo = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                string date = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string paymentStatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                string systemIP = "0.0.0.0";//dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                //string userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string outputfire = firecfo.PaymentDetails_CFO(UIDNo, challanNumber, date, bankName, amount);

                                if (outputfire == "Success")
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "Y");
                                }
                                else
                                {
                                    gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", outputfire, "N");
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (deptid == "27") //BOILER
                        {
                            try
                            {
                                string outputfactory = "";
                                string valuefactory = "";
                                DataSet dsdept = new DataSet();
                                dsdept = gen.getAdditionalPaymentDetailsCFO(UIDNO, deptid);
                                valuefactory = dsdept.GetXml();
                                if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                                {
                                    BoilerService.planAdditionalPayment Boilerpaymentvo = new BoilerService.planAdditionalPayment();
                                    Boilerpaymentvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                    Boilerpaymentvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                    Boilerpaymentvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                    Boilerpaymentvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                    Boilerpaymentvo.bankstatus = dsdept.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    Boilerpaymentvo.banktransid = "NA";
                                    Boilerpaymentvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                    Boilerpaymentvo.ddocode = "NA";
                                    Boilerpaymentvo.department_transaction_id = "NA";
                                    Boilerpaymentvo.hoa = "NA";
                                    Boilerpaymentvo.remittersname = "NA";
                                    Boilerpaymentvo.systemIP = "0:0:0:0";
                                    Boilerpaymentvo.trydate = "NA";
                                    Boilerpaymentvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                    string OutBoiler = Boiler.insertIntoPlanApprovalAdditionalPayment(Boilerpaymentvo);
                                    if (OutBoiler == "SUCCESS")
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "Y");
                                    }
                                    else
                                    {
                                        gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid, "AP", OutBoiler, "N");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                StringBuilder sbScript = new StringBuilder();
                string sScript;
                sbScript.Append("<script>");
                sbScript.Append(" window.close();");
                sbScript.Append("</script>");
                sScript = sbScript.ToString();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", sScript, false);
            //}
            // }
        }
        catch (Exception ex)
        {
            // lblmsg.Text = ex.Message;
            //  lblmsg.Visible = true;
        }

    }
}
