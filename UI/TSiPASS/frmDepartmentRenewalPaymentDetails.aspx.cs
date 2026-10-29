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
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Mail;
//using TSIPassBE;
//using TSIPassBL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public partial class UI_TSiPASS_frmDepartmentRenewalPaymentDetails : System.Web.UI.Page
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
    #region "Global Variables"
    //RequestURL objRequestURL = new RequestURL();
    string con = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ToString();
    WebClient wc = new WebClient();
    TSNPDCLService.TsipassWsService tsnpdcl = new TSNPDCLService.TsipassWsService();
    TSSPDCLService.TSSPDCLIPassService tsspdcl = new TSSPDCLService.TSSPDCLIPassService();
    FactoryService.TSFactoryServiceImplService factory = new FactoryService.TSFactoryServiceImplService();
    FireService.Service1 fire = new FireService.Service1();
    //BoilerService.TSBoilerServiceImplService boiler = new BoilerService.TSBoilerServiceImplService();
    LabourService.TSLabourServiceImplService labourservice = new LabourService.TSLabourServiceImplService();
    NALAService.MeeSevaWebService nalaservice = new NALAService.MeeSevaWebService();
    HMWSSBService.TSiPASSNewConnectionUC hmwssb = new HMWSSBService.TSiPASSNewConnectionUC();
    BoilerService.TSBoilerServiceImplService BoilerRenewalservice = new BoilerService.TSBoilerServiceImplService();
    DB.DB conn = new DB.DB();
    #endregion
    //DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");

        }
        FillDetails();

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
            //    rblPaymentMode.Items[0].Enabled = false;
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
            }

            DataSet dscheck = new DataSet();
            //dscheck = Gen.GetUidnumberRen(Session["Applid"].ToString());
            //dscheck = Gen.GetUidnumberRen(Session["mainQnreid"].ToString());
            if (Request.QueryString["intApplicationId"] != null)
            {
                dscheck = Gen.GetUidnumberRen(Request.QueryString["intApplicationId"].ToString());
                //dscheck = Gen.GetUidnumberRen(Session["mainQnreid"].ToString());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    Session["UIDNO"] = dscheck.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                    Session["intCFEEnterpid"] = dscheck.Tables[0].Rows[0]["Created_by"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }

                if (Session["Applid"].ToString().Trim() == "0")
                {
                    Response.Redirect("frmQuesstionniareReg.aspx");
                }
            }


            DataSet dspay = new DataSet();
            dspay = Gen.GetEnterPreniourPayDetailsPaidDetRenewal(Session["Applid"].ToString().Trim());
            if (dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails0.DataSource = dspay.Tables[0];
                grdDetails0.DataBind();
            }
            if (Request.QueryString["AdditionalPayment"] != null)
            {
                DataSet ds = new DataSet();
                //ds = Gen.GetEnterPreniourPayDetailsAddtionalPaymentRenewal(Request.QueryString["intApplicationId"].ToString());//check
                ds = Gen.GetEnterPreniourPayDetailsAddtionalPaymentRenewal(Session["mainQnreid"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        ((CheckBox)row1.FindControl("ChkApproval")).Checked = true;
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {
                            if (row1.Cells[1].Text.Contains("Consent for Renewal from Pollution Control Board"))
                            {
                                sum = sum + Convert.ToDecimal(row1.Cells[3].Text);
                            }
                            else
                            {
                                sum = sum + Convert.ToDecimal(row1.Cells[3].Text);

                            }
                            //sum = sum + Convert.ToDecimal(row1.Cells[5].Text);
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
                ds = Gen.GetEnterPreniourPayDetailsRenewal(Session["Applid"].ToString().Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();

                    decimal sum = Convert.ToDecimal("0");
                    foreach (GridViewRow row1 in grdDetails.Rows)
                    {
                        if (((CheckBox)row1.FindControl("ChkApproval")).Checked)
                        {

                           // sum = sum + Convert.ToDecimal(row1.Cells[5].Text);

                            if (row1.Cells[1].Text.Contains("Consent for Renewal from Pollution Control Board"))
                            {
                                sum = sum + Convert.ToDecimal(row1.Cells[3].Text);
                            }
                            else
                            {
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

            //Session["uid"] = "1000";
            //Session["Applid"] = "1000";
            rblPaymentMode.SelectedIndex = 0;
            //rblPaymentMode.SelectedIndex = 0;
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
            Response.Redirect("frmRenewalService.aspx");
        }
        else
        {
            int selectioncount = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                if (((CheckBox)row.FindControl("ChkApproval")).Checked)
                {
                    string HdfApprovalidnew = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                    // if (HdfApprovalidnew.Trim() != "33" && HdfApprovalidnew.Trim() != "36" && HdfApprovalidnew.Trim() != "57")
                    if (HdfApprovalidnew.Trim() != "33")
                    {
                        selectioncount = selectioncount + 1;
                    }
                    //if (HdfApprovalidnew.Trim() == "20")
                    //{
                    //    DataSet dspcb = new DataSet();
                    //    dspcb = Gen.getdataofidentity(Session["Applid"].ToString(), "1");
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

            dsnew = Gen.GetUidnumberRen(Session["Applid"].ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {

                hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
                Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            }
            //generating 

            if (rblPaymentMode.SelectedIndex == 0)
            {
                try
                {

                    Session["SBHCHLNREF"] = "E" + System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                    //inset into SBI payment disbursement table

                    Session["Amount"] = TxtAmountOnline.Text;

                    Session["UID_no"] = hdfUIDNumber.Value;



                    DataSet dscha = new DataSet();

                    dscha = Gen.GetEnterPreneurdatabyQueRenewal(Session["Applid"].ToString().Trim());

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

                            dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);

                            if (dsch.Tables[0].Rows.Count > 0)
                            {

                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

                                int s = Gen.InsertUIDGenerationRenewal(HdfQueid, dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);
                            }

                            DataSet dschab = new DataSet();

                            dschab = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);

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

                            int j = Gen.UpdateAdditionalpaymentsUIDRenewal(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());
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

                            dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);

                            if (dsch.Tables[0].Rows.Count > 0)
                            {

                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

                                int s = Gen.InsertPaymentDisbusmentSBIRenewal(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), Session["SBHCHLNREF"].ToString().Trim(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);

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
                // Session["Amount"] = "2";
                Session["UID_no"] = hdfUIDNumber.Value;

                DataSet dscha = new DataSet();
                dscha = Gen.GetEnterPreneurdatabyQueRenewal(Session["Applid"].ToString().Trim());
                if (dscha.Tables[0].Rows.Count > 0)
                {
                    Hdfeid.Value = dscha.Tables[0].Rows[0]["intQuessionaireid"].ToString();
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
                            dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                int s = Gen.InsertUIDGenerationRenewal(HdfQueid, dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, txtDDDate.Text, HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfUIDNumber.Value);
                            }

                            DataSet dschab = new DataSet();
                            dschab = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
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
                            int j = Gen.UpdateAdditionalpaymentsUIDRenewal(HdfQueid, "", "Completed", Session["uid"].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());
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
                            dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDesk(Session["UID_no"].ToString(), dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "REN", Session["AdditionalPayment"].ToString());
                            }
                        }
                    }
                    Response.Redirect("BilldeskPaymentPageREN.aspx");
                }
                if (rdbOnlineBankType.SelectedValue.ToString().Trim() == "Kotak")
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
                            dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
                            if (dsch.Tables[0].Rows.Count > 0)
                            {
                                Hdfeid.Value = dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                int s = Gen.InsertPaymentBillDesk(Session["UID_no"].ToString(), dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, Session["uid"].ToString(), HdfApprovalid, "REN", Session["AdditionalPayment"].ToString());
                            }
                            if (TxtAmountOnline.Text == "0")
                            {
                                int quedata = updatenonPaymentinRENQueNew(HdfQueid, Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                                lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                                success.Visible = true;
                                Failure.Visible = false;
                            }
                        }
                    }
                    if (TxtAmountOnline.Text == "0")
                    {
                        //int quedata = updatenonPaymentinRENQueNew(HdfQueid, Session["uid"].ToString(), HdfApprovalid, HdfAmount);
                        Webserviceren(Session["UID_no"].ToString());
                    }
                    else
                    {
                        Response.Redirect("KotakPageREN.aspx");
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
                                dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
                                if (dsch.Tables[0].Rows.Count > 0)
                                {
                                    Hdfeid.Value = dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                    // int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(),HdfApprovalid);
                                    int s = Gen.InsertPaymentDisbusmentSBI(dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), sonlinetrnsNo, HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid);
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
                                    dsch = Gen.GetEnterPreneurdatabyQueRenewal(HdfQueid);
                                    if (dsch.Tables[0].Rows.Count > 0)
                                    {
                                        Hdfeid.Value = dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                        int s = Gen.InsertPaymentDisbusment(dsch.Tables[0].Rows[0]["intQuessionaireid"].ToString(), Session["IcicitransId"].ToString(), HdfDeptid, HdfAmount, "Y", Session["uid"].ToString(), HdfApprovalid, "CFE");

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
    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

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
        
        if (ChkApproval.Checked == true)
        {
            row.Cells[5].Text = row.Cells[3].Text;

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



            DataSet dsappr = new DataSet();
            dsappr = Gen.GetQuestionaryAprovalsApplyDataRenewal(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "Dept_Id").ToString().Trim(), DataBinder.Eval(e.Row.DataItem, "ApprovalId").ToString().Trim());

            if (dsappr.Tables[0].Rows.Count > 0)
            {
                //if (dsappr.Tables[0].Rows[0]["IsPayment"].ToString().Trim() == "Y")
                //{
                //ChkApproval.Checked = true;
                //ChkApproval.Enabled = false;
                //}
            }

            if (HdfApprovalid.Value == "33")
            {

                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "55")
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
              
            }
            if (HdfApprovalid.Value == "155")
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }

            if (HdfApprovalid.Value == "54")
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;

            }
            if (HdfApprovalid.Value == "154")
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }

            if (Convert.ToDouble(HdfAmount.Value) == 0)
            {
                ChkApproval.Checked = true;
                ChkApproval.Enabled = false;
                e.Row.Cells[5].Text = e.Row.Cells[3].Text;
            }
            if (HdfApprovalid.Value == "35")
            {
                grdDetails.Columns[6].Visible = true;
            }
            else
            {
                grdDetails.Columns[6].Visible = false;
            }
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
            string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];


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

    public void Webserviceren(string UIDNO)
    {
        //DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataSet dsdept = new DataSet();
        try
        {
            //if (Session["objUsrDtl"] != null)
            //{
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds = Gen.GetDepartmentonuidREN(UIDNO);
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["intApprovalid"].ToString();
                        if (deptid == "53")
                        {
                            dsdept = Gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                string cafUniqueNo = dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                                string transactionId = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                string amount = dsdept.Tables[0].Rows[0]["Approval_Fee"].ToString();
                                string bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                string transactionStatus = "S";
                                string paymentType = "NB";
                                string indApplication = dsdept.Tables[0].Rows[0]["NICApplicationno"].ToString();
                                string additionalPayment = "F";

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
                                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", jsonResponse, "Y");
                                                    //int k = gen.InsertDeptDateTracing("20", dsdept.Tables[0].Rows[0]["intQuessionaireid"].ToString(), UIDNO, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, null, "CFE", "20");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", jsonResponse, "N");
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



                        if (deptid == "55")
                        {
                            BoilerService.renewalDetails boilerrenvo = new BoilerService.renewalDetails();
                            //string deptid = dt.Rows[i]["intApprovalid"].ToString();
                            dsdept = Gen.getdepartmentdetailsonuidREN(UIDNO, deptid);
                            string boilerdata = dsdept.GetXml();
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                boilerrenvo.amount_tobe_paid = dsdept.Tables[0].Rows[0]["amount_tobe_paid"].ToString();
                                // boilerrenvo.anexuredocuments = dsdept.Tables[0].Rows[0]["anexuredocuments"].ToString();
                                boilerrenvo.application_stage = Convert.ToInt32(dsdept.Tables[0].Rows[0]["application_stage"].ToString());
                                boilerrenvo.applicationId = dsdept.Tables[0].Rows[0]["applicationId"].ToString();
                                boilerrenvo.bankAmount = dsdept.Tables[0].Rows[0]["bankAmount"].ToString();
                                boilerrenvo.bankDate = dsdept.Tables[0].Rows[0]["bankDate"].ToString();
                                boilerrenvo.bankName = dsdept.Tables[0].Rows[0]["bankName"].ToString();
                                boilerrenvo.bankstatus = dsdept.Tables[0].Rows[0]["bankstatus"].ToString();
                                boilerrenvo.banktransid = dsdept.Tables[0].Rows[0]["banktransid"].ToString();
                                boilerrenvo.boiler_376 = dsdept.Tables[0].Rows[0]["boiler_376"].ToString();
                                boilerrenvo.boiler_maker_name = dsdept.Tables[0].Rows[0]["boiler_maker_name"].ToString();
                                boilerrenvo.boiler_maker_no = dsdept.Tables[0].Rows[0]["boiler_maker_no"].ToString();
                                boilerrenvo.boiler_rating = dsdept.Tables[0].Rows[0]["boiler_rating"].ToString();
                                boilerrenvo.boiler_used_for = dsdept.Tables[0].Rows[0]["boiler_used_for"].ToString();
                                // boilerrenvo.cbbdocuments = dsdept.Tables[0].Rows[0]["cbbdocuments"].ToString();
                                boilerrenvo.challanNo = dsdept.Tables[0].Rows[0]["challanNo"].ToString();
                                boilerrenvo.class_of_repairer = dsdept.Tables[0].Rows[0]["class_of_repairer"].ToString();
                                boilerrenvo.competent_person = dsdept.Tables[0].Rows[0]["competent_person"].ToString();
                                //boilerrenvo.component_person_details = dsdept.Tables[0].Rows[0]["component_person_details"].ToString();
                                boilerrenvo.created_by = Convert.ToInt32(dsdept.Tables[0].Rows[0]["created_by"].ToString());
                                boilerrenvo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                                // boilerrenvo.designdocuments = dsdept.Tables[0].Rows[0]["designdocuments"].ToString();
                                boilerrenvo.details_of_repairs = dsdept.Tables[0].Rows[0]["details_of_repairs"].ToString();
                                boilerrenvo.details_of_repairs_path = dsdept.Tables[0].Rows[0]["details_of_repairs_path"].ToString();
                                boilerrenvo.district = dsdept.Tables[0].Rows[0]["district"].ToString();
                                boilerrenvo.door_no = dsdept.Tables[0].Rows[0]["door_no"].ToString();
                                boilerrenvo.enterpreneur_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["enterpreneur_id"].ToString());
                                boilerrenvo.exemption_boilers = dsdept.Tables[0].Rows[0]["exemption_boilers"].ToString();
                                boilerrenvo.exemption_document = dsdept.Tables[0].Rows[0]["exemption_document"].ToString();
                                boilerrenvo.expire_pre_cer_date = dsdept.Tables[0].Rows[0]["expire_pre_cer_date"].ToString();
                                boilerrenvo.fee = dsdept.Tables[0].Rows[0]["fee"].ToString();
                                // boilerrenvo.formdocuments = dsdept.Tables[0].Rows[0]["formdocuments"].ToString();
                                boilerrenvo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                boilerrenvo.inspection_letter = dsdept.Tables[0].Rows[0]["inspection_letter"].ToString();
                                boilerrenvo.inspection_required = dsdept.Tables[0].Rows[0]["inspection_required"].ToString();
                                boilerrenvo.inspector_authority_flag = Convert.ToInt32(dsdept.Tables[0].Rows[0]["inspector_authority_flag"].ToString());
                                boilerrenvo.length_pipeline = dsdept.Tables[0].Rows[0]["length_pipeline"].ToString();
                                boilerrenvo.locality = dsdept.Tables[0].Rows[0]["locality"].ToString();
                                boilerrenvo.mandal = dsdept.Tables[0].Rows[0]["mandal"].ToString();
                                boilerrenvo.max_evaporation = dsdept.Tables[0].Rows[0]["max_evaporation"].ToString();
                                boilerrenvo.max_pressure = dsdept.Tables[0].Rows[0]["max_pressure"].ToString();
                                boilerrenvo.modeofpayment = dsdept.Tables[0].Rows[0]["modeofpayment"].ToString();
                                boilerrenvo.name_of_repairer = dsdept.Tables[0].Rows[0]["name_of_repairer"].ToString();

                                boilerrenvo.owner_contact_no = dsdept.Tables[0].Rows[0]["owner_contact_no"].ToString();
                                boilerrenvo.owner_email = dsdept.Tables[0].Rows[0]["owner_email"].ToString();
                                boilerrenvo.owner_name = dsdept.Tables[0].Rows[0]["owner_name"].ToString();
                                boilerrenvo.payment_status = dsdept.Tables[0].Rows[0]["payment_status"].ToString();
                                boilerrenvo.pincode = dsdept.Tables[0].Rows[0]["pincode"].ToString();
                                boilerrenvo.quessionaire_id = Convert.ToInt32(dsdept.Tables[0].Rows[0]["quessionaire_id"].ToString());
                                boilerrenvo.registration_of_steampipe_line = dsdept.Tables[0].Rows[0]["registration_of_steampipe_line"].ToString();
                                boilerrenvo.remarks = dsdept.Tables[0].Rows[0]["remarks"].ToString();
                                boilerrenvo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                boilerrenvo.repairs = dsdept.Tables[0].Rows[0]["repairs"].ToString();
                                boilerrenvo.required_documents = dsdept.Tables[0].Rows[0]["required_documents"].ToString();
                                boilerrenvo.supporting_documents = dsdept.Tables[0].Rows[0]["supporting_documents"].ToString();
                                boilerrenvo.system_ip = dsdept.Tables[0].Rows[0]["system_ip"].ToString();
                                boilerrenvo.trydate = dsdept.Tables[0].Rows[0]["trydate"].ToString();
                                boilerrenvo.type_of_boiler = dsdept.Tables[0].Rows[0]["type_of_boiler"].ToString();
                                boilerrenvo.upload_form5 = dsdept.Tables[0].Rows[0]["upload_form5"].ToString();
                                boilerrenvo.user_serial_no = Convert.ToInt32(dsdept.Tables[0].Rows[0]["user_serial_no"].ToString());
                                boilerrenvo.village = dsdept.Tables[0].Rows[0]["village"].ToString();
                                boilerrenvo.thirdparty_authority = dsdept.Tables[0].Rows[0]["Thirdparttype"].ToString();

                                boilerrenvo.details_of_repairs_path = "";
                                //BoilerServiceTest.otherdocuments[] othdoc = null;
                                //BoilerService.otherdocuments othdocvo = new BoilerService.otherdocuments();
                                //othdocvo.documentName = dsdept.Tables[0].Rows[0]["AttachmentFilename"].ToString();
                                //othdocvo.documentPath = dsdept.Tables[0].Rows[0]["otherdocuments"].ToString();
                                BoilerService.anexuredocuments[] anexuredocuments = null;
                                BoilerService.cbbdocuments[] cbbdocument = null;
                                BoilerService.formdocuments[] form = null;
                                BoilerService.otherdocuments[] Otherdoc = null;
                                BoilerService.designdocuments[] boedocuments = null;


                                DataSet dsBoiler = new DataSet();
                                dsBoiler = Gen.getattachmentdetailsonuidREN(UIDNO, deptid, "");
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
                                        boilerrenvo.otherdocuments = Otherdoc;

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
                                        boilerrenvo.cbbdocuments = cbbdocument;
                                    }

                                    if (dsBoiler.Tables[2].Rows.Count > 0)
                                    {
                                        DataTable dtformdocuments = new DataTable();
                                        dtformdocuments = dsBoiler.Tables[2];
                                        form = new BoilerService.formdocuments[dtformdocuments.Rows.Count];

                                        for (int n = 0; n < dtformdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.formdocuments formvo = new BoilerService.formdocuments();
                                            formvo.documentName = dtformdocuments.Rows[n]["FileName"].ToString();
                                            formvo.documentPath = dtformdocuments.Rows[n]["Filepath"].ToString();
                                            form[n] = formvo;
                                        }
                                        boilerrenvo.formdocuments = form;
                                    }

                                    if (dsBoiler.Tables[3].Rows.Count > 0)
                                    {
                                        DataTable dtanexuredocuments = new DataTable();
                                        dtanexuredocuments = dsBoiler.Tables[3];
                                        anexuredocuments = new BoilerService.anexuredocuments[dtanexuredocuments.Rows.Count];

                                        for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                        {
                                            BoilerService.anexuredocuments annexurevo = new BoilerService.anexuredocuments();
                                            annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                            annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                            anexuredocuments[n] = annexurevo;
                                        }
                                        boilerrenvo.anexuredocuments = anexuredocuments;
                                    }
                                    if (dsBoiler.Tables[4].Rows.Count > 0)
                                    {
                                        DataTable dtrepairerdocuments = new DataTable();
                                        dtrepairerdocuments = dsBoiler.Tables[4];
                                        //anexuredocuments = new BoilerServiceTest.repai [dtanexuredocuments.Rows.Count];

                                        //for (int n = 0; n < dtanexuredocuments.Rows.Count; n++)
                                        //{
                                        //    BoilerServiceTest.anexuredocuments annexurevo = new BoilerServiceTest.anexuredocuments();
                                        //    annexurevo.documentName = dtanexuredocuments.Rows[n]["FileName"].ToString();
                                        //    annexurevo.documentPath = dtanexuredocuments.Rows[n]["Filepath"].ToString();
                                        //    anexuredocuments[n] = annexurevo;
                                        //}
                                        boilerrenvo.details_of_repairs_path = dtrepairerdocuments.Rows[0]["Filepath"].ToString();
                                    }
                                    if (dsBoiler.Tables[5].Rows.Count > 0)
                                    {
                                        DataTable dtboecertificationdocuments = new DataTable();
                                        dtboecertificationdocuments = dsBoiler.Tables[5];
                                        boedocuments = new BoilerService.designdocuments[dtboecertificationdocuments.Rows.Count];

                                        for (int n = 0; n < dtboecertificationdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.designdocuments boecertificationvo = new BoilerService.designdocuments();
                                            boecertificationvo.documentName = dtboecertificationdocuments.Rows[n]["FileName"].ToString();
                                            boecertificationvo.documentPath = dtboecertificationdocuments.Rows[n]["Filepath"].ToString();
                                            boedocuments[n] = boecertificationvo;
                                        }
                                        boilerrenvo.boedocuments = boedocuments;
                                    }
                                    if (dsBoiler.Tables[6].Rows.Count > 0)
                                    {
                                        DataTable dtboecertificationdocuments = new DataTable();
                                        dtboecertificationdocuments = dsBoiler.Tables[6];
                                        boedocuments = new BoilerService.designdocuments[dtboecertificationdocuments.Rows.Count];

                                        for (int n = 0; n < dtboecertificationdocuments.Rows.Count; n++)
                                        {
                                            BoilerService.designdocuments boecertificationvo = new BoilerService.designdocuments();
                                            boecertificationvo.documentName = dtboecertificationdocuments.Rows[n]["FileName"].ToString();
                                            boecertificationvo.documentPath = dtboecertificationdocuments.Rows[n]["Filepath"].ToString();
                                            boedocuments[n] = boecertificationvo;
                                        }
                                        boilerrenvo.boequalificationdocs = boedocuments;
                                    }
                                }
                                string output = BoilerRenewalservice.renewalofBoilers(boilerrenvo);
                                if (output == "SUCCESS")
                                {
                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, deptid, "C", output, "Y");
                                }
                            }

                        }
                    }
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable dtadd = new DataTable();
                    dtadd = ds.Tables[1];
                    for (int j = 0; j < dtadd.Rows.Count; j++)
                    {
                        string deptid1 = dtadd.Rows[j]["intApprovalid"].ToString();
                        if (deptid1 == "53")
                        {
                            //DataSet dsdept = new DataSet();

                            dsdept = Gen.getAdditionalPaymentDetailsREN(UIDNO, deptid1);
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
                                                    Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid1, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, deptid1, "AP", jsonResponse, "N");
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
                                                    Gen.UpdateDepartwebserviceflagCFO(UIDNO, deptid1, "AP", jsonResponse, "Y");
                                                }
                                                else
                                                {
                                                    //string labourouterrormsg = labourout.status + ',' + labourout.uID + ',' + labourout.officerDetails;
                                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, deptid1, "AP", jsonResponse, "Y");
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
                        if (deptid1 == "55")
                        {
                            dsdept = Gen.getAdditionalPaymentDetailsREN(UIDNO, deptid1);
                            if (dsdept != null && dsdept.Tables.Count > 0 && dsdept.Tables[0].Rows.Count > 0)
                            {
                                BoilerService.renewalAdditionalPayment renewaladditionalvo = new BoilerService.renewalAdditionalPayment();
                                renewaladditionalvo.applicationID = dsdept.Tables[0].Rows[0]["UIDNO"].ToString();
                                renewaladditionalvo.bankAmount = dsdept.Tables[0].Rows[0]["Online_Amount"].ToString();
                                renewaladditionalvo.bankDate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                renewaladditionalvo.bankName = dsdept.Tables[0].Rows[0]["BankName"].ToString();
                                renewaladditionalvo.bankstatus = dsdept.Tables[0].Rows[0]["IsActive"].ToString();
                                renewaladditionalvo.banktransid = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                //renewaladditionalvo.boilerrating = "50";// dsdept.Tables[0].Rows[0]["boilerrating"].ToString();
                                renewaladditionalvo.challanNumber = dsdept.Tables[0].Rows[0]["TransactionNO"].ToString();
                                renewaladditionalvo.ddocode = dsdept.Tables[0].Rows[0]["ddocode"].ToString();
                                renewaladditionalvo.department_transaction_id = dsdept.Tables[0].Rows[0]["OnlineOrderNo"].ToString();
                                renewaladditionalvo.entrepreneurRemarks = dsdept.Tables[0].Rows[0]["entrepreneurRemarks"].ToString();
                                renewaladditionalvo.hoa = dsdept.Tables[0].Rows[0]["hoa"].ToString();
                                renewaladditionalvo.remittersname = dsdept.Tables[0].Rows[0]["remittersname"].ToString();
                                //renewaladditionalvo.steampipelinelength = "0";// dsdept.Tables[0].Rows[0]["steampipelinelength"].ToString();
                                renewaladditionalvo.systemIP = "0000";// dsdept.Tables[0].Rows[0][""].ToString();
                                renewaladditionalvo.trydate = dsdept.Tables[0].Rows[0]["TransactionDate"].ToString();
                                renewaladditionalvo.userID = dsdept.Tables[0].Rows[0]["Created_by"].ToString();

                                string paymentoutput = BoilerRenewalservice.insertIntoRenewalAdditionalPayment(renewaladditionalvo);
                                if (paymentoutput == "SUCCESS")
                                {
                                    Gen.UpdateDepartwebserviceflagREN(UIDNO, "55", "AP", paymentoutput, "Y");
                                }
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
            }
            // }
        }
        catch (Exception ex)
        {
            //  lblmsg.Text = ex.Message;
            //lblmsg.Visible = true;
        }
    }

    public int updatenonPaymentinRENQueNew(string intQuessionaireCFOid, string Created_by, string HdfApprovalid, string HdfAmount)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[getUpdatedataswithoutpayments_REN]";

        if (intQuessionaireCFOid == "" || intQuessionaireCFOid == null)
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.Trim();


        if (Created_by == "" || Created_by == null || Created_by == "--Select--")
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        com.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = HdfApprovalid.Trim();
        com.Parameters.Add("@Amount", SqlDbType.VarChar).Value = HdfAmount.Trim();
        conn.OpenConnection();
        com.Connection = conn.GetConnection;

        try
        {
            //return com.ExecuteNonQuery();
            return Convert.ToInt32(com.ExecuteScalar());
        }
        catch (Exception ex)
        {

            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            conn.CloseConnection();
        }

    }
}