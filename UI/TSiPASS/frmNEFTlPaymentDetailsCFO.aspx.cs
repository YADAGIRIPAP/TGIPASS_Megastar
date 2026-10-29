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
    #endregion
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

            //rblPaymentMode.Items[0].Enabled = false;
            if (Request.QueryString[0].ToString().Trim() != null)
            {
                hdfFlagID0.Value = Request.QueryString[0].ToString().Trim();
            }

             DataSet dscheck = new DataSet();
             dscheck = Gen.GetShowQuestionariesCFOnew(Request.QueryString[1].ToString().Trim());
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
                Session["intCFOEnterpid"]="0";
            }

            if ( Session["Applid"].ToString().Trim() =="0")
            {
                Response.Redirect("frmQuesstionniareRegCFO.aspx");
            }
            //if (Session["intCFOEnterpid"].ToString().Trim() == "0")
            //{

            //    Response.Redirect("frmCAFEntrepreneurDetails.aspx");
            //}
            DataSet dspay=new DataSet();
            dspay = Gen.GetEnterPreniourPayDetailsPaidDetCFO(Session["Applid"].ToString().Trim());
            if (dspay.Tables[0].Rows.Count > 0)
            {
                grdDetails0.DataSource = dspay.Tables[0];
                grdDetails0.DataBind();
            }

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


                            //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Request.QueryString[1].ToString().Trim(), RdWhetherAlreadyApproved);  
                        }
                    }

                    HdfA.Value = sum.ToString();
                    txtAmount.Text = HdfA.Value;
                    TxtAmountOnline.Text = HdfA.Value;
                }
                //Session["uid"] = "1000";
                //Session["Applid"] = "1000";
             //   rblPaymentMode.SelectedIndex = 1;
                if (rblPaymentMode.SelectedValue == "D")
                {
                    paynot.Visible = true;
                    paynotOnline.Visible = false;

                }
                else
                {
                    paynot.Visible = false;
                    paynotOnline.Visible = true;
                    rdbOnlineBankType.SelectedIndex = 0;
                }
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
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

            DataSet dsnew = new DataSet();

            dsnew = Gen.GetUidnumberCFO(Session["Applid"].ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {

                hdfUIDNumber.Value = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
                Session["UID_no"] = dsnew.Tables[0].Rows[0]["UIDNumber"].ToString();
            }
            //generating 
            
             if (rblPaymentMode.SelectedIndex== 0)
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
                         // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Request.QueryString[1].ToString().Trim(), RdWhetherAlreadyApproved);


                         DataSet dsch = new DataSet();
                         dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                         if (dsch.Tables[0].Rows.Count > 0)
                         {
                             Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                             int s = Gen.InsertNEFTPaymentTransactionCFO(HdfQueid, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedValue, txtDDNumber.Text, DateTime.Now.ToString(), HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), hdfUIDNumber.Value, txtRemarks.Text, getclientIP());



                         }

                         if (HdfApprovalid == "33")
                         {

                             DataSet dslat = new DataSet();
                             dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["Applid"].ToString());

                             if (dslat.Tables[0].Rows.Count > 0)
                             {


                                 int quedata = Gen.updatenonPaymentinCFOQue(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Request.QueryString[1].ToString());


                             }

                         }


                     }
                     else
                     {
                         string HdfQueid = ((HiddenField)row.FindControl("HdfQueid")).Value.ToString();
                         string HdfDeptid = ((HiddenField)row.FindControl("HdfDeptid")).Value.ToString();
                         string HdfApprovalid = ((HiddenField)row.FindControl("HdfApprovalid")).Value.ToString();
                         string HdfAmount = ((HiddenField)row.FindControl("HdfAmount")).Value.ToString();
                         int j = Gen.UpdateAdditionalpaymentsCFO(HdfQueid, "", "Completed", Request.QueryString[1].ToString(), "2", HdfDeptid, HdfApprovalid,getclientIP());

                     }
                 }
                 lblmsg.Text = "<font color='green'>Payment Successfully Completed..!</font>";

                 success.Visible = true;
                 Failure.Visible = false;
                 Page.Response.Redirect(Page.Request.Url.ToString(), true);
             }
             else
             {

                 Session["Amount"] =  TxtAmountOnline.Text;
                 Session["UID_no"] = hdfUIDNumber.Value;

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
                         // int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Request.QueryString[1].ToString().Trim(), RdWhetherAlreadyApproved);


                         DataSet dsch = new DataSet();
                         dsch = Gen.GetEnterPreneurdatabyQueCFO(HdfQueid);
                         if (dsch.Tables[0].Rows.Count > 0)
                         {
                             Hdfeid.Value = dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                             int s = Gen.InsertUIDGenerationCFO(HdfQueid, dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), HdfDeptid, HdfApprovalid, rblPaymentMode.SelectedItem.Text, txtDDNumber.Text, DateTime.Now.ToString(), HdfAmount, txtBankName.Text, txtBankBranchName.Text, ViewState["DDUploadName"].ToString(), ViewState["pathDDUpload"].ToString(), Request.QueryString[1].ToString(), DateTime.Now.ToString(), Request.QueryString[1].ToString(), DateTime.Now.ToString(), hdfUIDNumber.Value);



                         }




                         if (HdfApprovalid == "33")
                         {

                             DataSet dslat = new DataSet();
                             dslat = Gen.GetDeptApprovaldatabyQueCFO(Session["Applid"].ToString());

                             if (dslat.Tables[0].Rows.Count > 0)
                             {


                                 int quedata = Gen.updatenonPaymentinCFOQue(dslat.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString(), Request.QueryString[1].ToString());


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
                         int j = Gen.UpdateAdditionalpaymentsUIDCFO(HdfQueid, "", "Completed", Request.QueryString[1].ToString(), "2", HdfDeptid, HdfApprovalid, getclientIP());

                     }
                 }
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
                                 int s = Gen.InsertPaymentDisbusmentSBICFO(dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), Session["onlinetransId"].ToString().Trim(), HdfDeptid, HdfAmount, "Y", Request.QueryString[1].ToString(), HdfApprovalid);



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
                                     int s = Gen.InsertPaymentDisbusmentCFO(dsch.Tables[0].Rows[0]["intCFOEnterpid"].ToString(), Session["IcicitransId"].ToString(), HdfDeptid, HdfAmount, "Y", Request.QueryString[1].ToString(), HdfApprovalid);



                                 }


                             }

                         }
                         //Session["onlinetransId"] = //sonlinetrnsNo;


                        
                         Response.Redirect("IciciPaymentRequest.aspx");
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
               

                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Request.QueryString[1].ToString().Trim(), RdWhetherAlreadyApproved);  
            }
        }

        HdfA.Value = sum.ToString();
        txtAmount.Text = HdfA.Value;
      TxtAmountOnline.Text = HdfA.Value;

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

            if (HdfApprovalid.Value == "33")
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
        if (rblPaymentMode.SelectedValue == "D")
        {
            paynot.Visible = true;
            paynotOnline.Visible = false;

        }
        else
        {
            paynot.Visible = false;
            paynotOnline.Visible = true;
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
    //        //    Row["Created_by"] = Request.QueryString[1].ToString().Trim();
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

                            newPath = System.IO.Path.Combine(sFileDir, Session["intCFOEnterpid"].ToString() + "\\DD Upload");
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
                            result = t1.InsertImagedataCFO(Session["Applid"].ToString(), Session["intCFOEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DD Upload", "A", Request.QueryString[1].ToString(), DateTime.Now.ToString(), Request.QueryString[1].ToString(), DateTime.Now.ToString());


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


                //  int s = Gen.insertDepartmentAprrovalNew(HdfQueid, HdfDeptid, HdfApprovalid, HdfAmount, "N", Request.QueryString[1].ToString().Trim(), RdWhetherAlreadyApproved);  
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
}
