using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_frmDepartmentsViewAppl_groundwater : System.Web.UI.Page
{
    string rstages = "0";
    comFunctions cmf = new comFunctions();
    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (Request.QueryString.Count>0)
        {
            rstages = Request.QueryString[0].ToString().Trim();
            if (Request.QueryString.Count==2)
            {
                lbl_title.Text = Convert.ToString(Request.QueryString[1]);
            }
            if (!IsPostBack)
            {
                GetDetails();
            }
        }
    }
    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {          
            DataSet dsn = new DataSet();
            dsn = obj_dashboard.GetShowDepartmentFiles_grounwaterMRO(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();               
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
            grdDetails.Columns[9].Visible = false;
            grdDetails.Columns[10].Visible = false;
            if (rstages=="4" || rstages == "7")
            {
                //Stg=4&Pre-Scrutiny-Pending Within 2 Day
                //Stg = 7 & Pre - Scrutiny - Pending Beyond 2 Days
                grdDetails.Columns[9].Visible = true;
                grdDetails.Columns[10].Visible = true;
            }
            if (rstages == "11" || rstages == "10" || rstages == "19")
            {
                //Stg=11&lbl=Approval Under Process Within Time Limits
                //Stg=10 & lbl = Approval Under Process Beyond Time Limits
                //stg=19&lbl=Total Letters to be upload which rejetced by District Ground Water
                grdDetails.Columns[9].Visible = true;  
            }
        }
    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
          
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            #region
            //ID,ApplicationType_IndusorAgri,DistrictID,MandalId,VillageId,TypeofWell,TypeOfDrwngWater,StageId,Createdby,Created_Date,ModifiedBy,
            //            Modified_date,AccepFlag,LandPassbookPath,Registrationcertificatepath,IdentityProofPath,MROOfficeID,paymentFlag,Dept_id,Approvalid,
            ////MROOfficerApprovalid,MROOfficerApprovalFee,DeptApprovalFee,UID_No,App_Status,MRO_Dept_id,
            //       

            #endregion

            #region
            Label lnk_uid_no = (Label)e.Row.FindControl("lnk_uid_no");
            Label lbl_rejetedstatusofapplication = (Label)e.Row.FindControl("lbl_rejetedstatusofapplication");
            HyperLink hyp_Applicationform = (HyperLink)e.Row.FindControl("hyp_Applicationform");           
            HyperLink hyp_attachments = (HyperLink)e.Row.FindControl("hyp_attachments");
            HyperLink hyp_paymentdetails = (HyperLink)e.Row.FindControl("hyp_paymentdetails");

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UID_No")).Trim();
            //lnk_uid_no.OnClientClick = "javascript:return Popup('" + intUid + "')";

            hyp_Applicationform.Target = "_blank";
            hyp_Applicationform.NavigateUrl = "GroundWaterPrint.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_attachments.Target = "_blank";
            hyp_attachments.NavigateUrl = "UserGroundwaterAttachments.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

            hyp_paymentdetails.Target = "_blank";
            hyp_paymentdetails.NavigateUrl = "UserGroundwaterPaymentDetails.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();



            lbl_rejetedstatusofapplication.Visible = false;
            string ReasonForRejection = "";
            string MRORejectedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MRORejectedReason")).Trim();
            string DGWORejetedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DGWORejetedReason")).Trim();
            string TRANSCORejetedReason = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TRANSCORejetedReason")).Trim();
            if (!string.IsNullOrEmpty(MRORejectedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = "Reason for MRO Rejection:  " + MRORejectedReason + "," + "\n";
            }
            if (!string.IsNullOrEmpty(DGWORejetedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = ReasonForRejection+ "Reason for Ground Water Department Rejection:  " + DGWORejetedReason + "\n";
            }
            if (!string.IsNullOrEmpty(TRANSCORejetedReason))
            {
                lbl_rejetedstatusofapplication.Visible = true;
                ReasonForRejection = ReasonForRejection + "Reason for TRANSCO Department Rejection:  " + TRANSCORejetedReason + "\n";
            }

            lbl_rejetedstatusofapplication.Text = ReasonForRejection;

            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            Label lbl_gridstatusdesc = (Label)e.Row.FindControl("lbl_gridstatusdesc");
            TextBox txt_remarksarequery = (TextBox)e.Row.FindControl("txt_remarksarequery");
            Label LabelDiscription = (Label)e.Row.FindControl("LabelDiscription");
            HyperLink hyp_approveapplication = (HyperLink)e.Row.FindControl("hyp_approveapplication");           
            Button BtnSave = (Button)e.Row.FindControl("BtnSave");

            ddlStatus.Visible = false;
            lbl_gridstatusdesc.Visible = false;
            txt_remarksarequery.Visible = false;
            LabelDiscription.Visible = false;
            hyp_approveapplication.Visible = false;
            BtnSave.Visible = false;

            string StageId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStageid")).Trim();

            string DWGORejected = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGORejected")).Trim();
            string DWGOApproved = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOApproved")).Trim();

            if (StageId=="4")
            {
                //4   Application Submitted and Payment Made
                if (rstages == "4" || rstages == "7")
                {
                    //Stg=4&Pre-Scrutiny-Pending Within 2 Day
                    //Stg = 7 & Pre - Scrutiny - Pending Beyond 2 Days
                    ddlStatus.Visible = true;
                    BtnSave.Visible = true;
                }
            }
            if (StageId == "9")
            {
                //Query Responded action should take by department
                if (rstages == "7")
                {
                    //Stg=4&Pre-Scrutiny-Pending Within 2 Day
                    //Stg = 7 & Pre - Scrutiny - Pending Beyond 2 Days
                    ddlStatus.Visible = true;
                    BtnSave.Visible = true;
                    ddlStatus.Items.RemoveAt(1);
                }
            }

            if (StageId == "12")
            {
                //Pre-Scrunity Completed and awaiting for Approval
                if (!string.IsNullOrEmpty(DWGOApproved))
                {
                    if (DWGOApproved == "Y")
                    {
                        if (rstages == "11" || rstages == "10")
                        {
                            //Stg=11&lbl=Approval Under Process Within Time Limits
                            //Stg=10 & lbl = Approval Under Process Beyond Time Limits
                            hyp_approveapplication.Visible = true;
                            hyp_approveapplication.Text = "Approve";
                            hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_Groundwater.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                        }
                    }
                }

                //Rejected by DGWO upload letter
                if (!string.IsNullOrEmpty(DWGORejected))
                {
                    if (DWGORejected == "Y")
                    {
                        if (rstages == "19")
                        {
                            //Stg=11&lbl=Approval Under Process Within Time Limits
                            //Stg=10 & lbl = Approval Under Process Beyond Time Limits
                            hyp_approveapplication.Visible = true;
                            hyp_approveapplication.Text = "Upload Reject Letter";
                            hyp_approveapplication.ForeColor = System.Drawing.Color.Red;
                            hyp_approveapplication.NavigateUrl = "frmApproveDetailsbyquery_Groundwater.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
                        }
                    }
                }
            }

            HyperLink hyp_userqueryrespose = (HyperLink)e.Row.FindControl("hyp_userqueryrespose");
            hyp_userqueryrespose.Visible = false;
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "QueryRespondDate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRaisedby"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DWGOQueryRespondeddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRaiseddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "GWTRASCOQueryRespondeddate"))))
            {
                hyp_userqueryrespose.Visible = true;
                hyp_userqueryrespose.NavigateUrl = "frmqueryresponseview_GroudwaterDept.aspx?Appid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();
            }

            #endregion
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txt_remarksarequery = (TextBox)row.FindControl("txt_remarksarequery");
        Label lbl_gridstatusdesc = (Label)row.FindControl("lbl_gridstatusdesc");
        Label LabelDiscription = (Label)row.FindControl("LabelDiscription");

        txt_remarksarequery.Visible = false;
        lbl_gridstatusdesc.Visible = false;
        LabelDiscription.Visible = false;

        if (ddlStatus.SelectedValue.ToString() == "12")
        {
            //forward to GW
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
            //Rejected by MRO
            txt_remarksarequery.Visible = true;
            LabelDiscription.Visible = true;
            lbl_gridstatusdesc.Visible = true;
            lbl_gridstatusdesc.Text = "Reason For Rejection";
            LabelDiscription.Text = "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?";
            string CloseWindow; CloseWindow = "alert('Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please mention on which act or rule,you are Rejecting?')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Rejection in pre-scrutiny stage is allowed only if the application is not in accordance with any act / rules. Pl. indicate the provision of act /rules that necessitate rejection of this application.Please Mention on which act or rule,you are Rejecting?", true);

            string message = "Please mention on which act or rule,you are Rejecting?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("');");
            ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb.ToString());
        }
        else if (ddlStatus.SelectedValue.ToString() == "5")
        {
            //Rejected by MRO
            txt_remarksarequery.Visible = true;
            lbl_gridstatusdesc.Visible = true;
            lbl_gridstatusdesc.Text = "Query Raise";
        }

    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txt_remarksarequery = (TextBox)row.FindControl("txt_remarksarequery");
       

        HiddenField hf_gridquestionarieID = (HiddenField)row.FindControl("hf_gridquestionarieID");
        HiddenField hf_griddeptid = (HiddenField)row.FindControl("hf_griddeptid");
        HiddenField hf_gridapprovalid = (HiddenField)row.FindControl("hf_gridapprovalid");
        HiddenField hf_griduidno = (HiddenField)row.FindControl("hf_griduidno");
        HiddenField hf_gridstageid = (HiddenField)row.FindControl("hf_gridstageid");
        HiddenField hf_gridLastDateofPreScrunity = (HiddenField)row.FindControl("hf_gridLastDateofPreScrunity");
        
        string LastDateofPreScrutiy= hf_gridLastDateofPreScrunity.Value;
        string intCFEEnterpid = hf_gridquestionarieID.Value;
        string intDeptid = hf_griddeptid.Value;
        string intApprovalid = hf_gridapprovalid.Value;
        string UID_No = hf_griduidno.Value;
        string StageId = hf_gridstageid.Value;
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        else 
        {
            if (ddlStatus.SelectedIndex <= 0)
            {
                Failure.Visible = true;
                success.Visible = false;
                lblmsg.Text = "Please Select Status";
            }
            else
            {
                int result = 0;
                result = obj_dashboard.insertDepartmentProcess_grounwaterMRO(hf_gridquestionarieID.Value,hf_griddeptid.Value,hf_gridapprovalid.Value,hf_gridstageid.Value,Session["uid"].ToString().Trim());
              
                if (ddlStatus.SelectedValue.ToString() == "5")
                {
                    if (txt_remarksarequery.Text == "")
                    {
                        lblmsg.Text = "Please Enter Query Description";
                    }
                    else
                    {
                        int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_gridquestionarieID.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, getclientIP(), "");
                        int i = obj_dashboard.insertQueryResponsedata_MROGroundwater(result.ToString(), hf_gridquestionarieID.Value, txt_remarksarequery.Text, "Y", Session["uid"].ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, hf_gridquestionarieID.Value);
                        try
                        {
                            int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_griddeptid.Value, hf_gridquestionarieID.Value, hf_griduidno.Value,
                                null, null, System.DateTime.Now.ToString("MM/dd/yyyy"),
                               null, null, "GW", hf_gridapprovalid.Value);
                        }
                        catch (Exception ex)
                        {

                        }
                        DataSet dsMail = new DataSet();
                        dsMail = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_gridquestionarieID.Value);
                        if (dsMail.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                        }
                        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            //SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in TS-iPASS. Thank You.");
                            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                        }
                        GetDetails();
                    }
                }
                
                
                else if (ddlStatus.SelectedValue.ToString() == "12")
                {
                    int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_gridquestionarieID.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, getclientIP(),"");
                    try
                    {
                        int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_griddeptid.Value, hf_gridquestionarieID.Value, hf_griduidno.Value, null, System.DateTime.Now.ToString("MM/dd/yyyy"),
                               null, null, null, "GW", hf_gridapprovalid.Value);
                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    dsMail = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_gridquestionarieID.Value);
                    if (dsMail.Tables[0].Rows.Count > 0)
                    {
                        cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    }
                    if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    {
                        cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                        //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    }
                }
                else if (ddlStatus.SelectedValue.ToString() == "16")
                {
                    if (txt_remarksarequery.Text.Trim() != "")
                    {
                        int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_gridquestionarieID.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, getclientIP(), txt_remarksarequery.Text);
                        int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_griddeptid.Value, hf_gridquestionarieID.Value, hf_griduidno.Value, null, System.DateTime.Now.ToString("MM/dd/yyyy"),
                                null, null, null, "GW", hf_gridapprovalid.Value);
                        DataSet dsMail = new DataSet();
                        dsMail = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_gridquestionarieID.Value);
                        if (dsMail.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        }
                        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                            //  cmf.SendSingleSMS("9247492919", "Dear " + row.Cells[3].Text + " - (" + row.Cells[1].Text + ") : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                        }
                    }
                    else
                    {
                        success.Visible = false;
                        Failure.Visible = true;
                        lblmsg0.Text = "Please Enter Reason For Rejection";
                    }
                }
                if (result > 0)
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "Successfully Updated";
                    if (ddlStatus.SelectedValue.ToString() == "16")
                    {
                        if (txt_remarksarequery.Text.Trim() == "")
                        {
                            success.Visible = false;
                            Failure.Visible = true;
                            lblmsg0.Text = "Please Enter Reason For Rejection";
                        }
                    }
                    ddlStatus.SelectedIndex = 0;
                    txt_remarksarequery.Text = "";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }

                #region



                //if (ddlStatus.SelectedValue=="5" || ddlStatus.SelectedValue == "6")
                //{
                //    //(string intCFEEnterpid, string intDeptid, string intApprovalid, string intStageid, string Trans_Date, string Created_by)
                //    int result = 0;
                //    result = obj_dashboard.insertDepartmentProcess_grounwaterMRO(hf_gridquestionarieID.Value, hf_griddeptid.Value, hf_gridapprovalid.Value,
                //     hf_gridstageid.Value, hf_gridLastDateofPreScrunity.Value, Session["uid"].ToString().Trim());

                //     if (ddlStatus.SelectedValue.ToString() == "5")
                //    {
                //        //(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string Reason)

                //        int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_gridquestionarieID.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, getclientIP(),"");
                //        try
                //        {
                //            int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_griddeptid.Value, hf_gridquestionarieID.Value, 
                //                hf_griduidno.Value, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "GW", hf_gridapprovalid.Value);

                //            //(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, 
                //            //    string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)
                //            }
                //        catch (Exception ex)
                //        {

                //        }
                //        DataSet dsMail = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_gridquestionarieID.Value);
                //        if (dsMail.Tables[0].Rows.Count > 0)
                //        {
                //            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                //        }
                //        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //        {
                //            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");

                //        }
                //    }
                //    else if (ddlStatus.SelectedValue.ToString() == "6")
                //    {
                //        if (txt_remarksarequery.Text.Trim() != "")
                //        {

                //            int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_gridquestionarieID.Value, "", "Rejected", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_griddeptid.Value, hf_gridapprovalid.Value, getclientIP(), txt_remarksarequery.Text);

                //            //(string intCFEEnterpid, string Amount, string Status, string Created_by, string stageid, string dept, string Approval, string ipaddress, string Reason)

                //            int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater
                //                (hf_griddeptid.Value, hf_gridquestionarieID.Value, hf_griduidno.Value, null, System.DateTime.Now.ToString("MM/dd/yyyy"),
                //                null, null, null, "GW", hf_gridapprovalid.Value);
                //            //(string DepartmentId, string QuessionaireId, string Uid_No, string Apply_Date, string PreScrutinity_Date, 
                //            //    string QueryRaised_Date, string QueryRespond_Date, string Approval_Date, string Application_Type, string ApprovalId)

                //            DataSet dsMail = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_gridquestionarieID.Value);
                //            if (dsMail.Tables[0].Rows.Count > 0)
                //            {
                //                cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                //            }
                //            if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                //            {
                //                cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");

                //            }
                //        }
                //        else
                //        {
                //            success.Visible = false;
                //            Failure.Visible = true;
                //            lblmsg0.Text = "Please Enter Reason For Rejection";
                //        }
                //    }
                //    if (result > 0)
                //    {
                //        success.Visible = true;
                //        Failure.Visible = false;
                //        lblmsg.Text = "Successfully Updated";
                //        if (ddlStatus.SelectedValue.ToString() == "16")
                //        {
                //            if (txt_remarksarequery.Text.Trim() == "")
                //            {
                //                success.Visible = false;
                //                Failure.Visible = true;
                //                lblmsg0.Text = "Please Enter Reason For Rejection";
                //            }
                //        }
                //        ddlStatus.SelectedIndex = 0;
                //        txtAmount.Text = "";
                //        txt_remarksarequery.Text = "";
                //    }
                //    else
                //    {
                //        success.Visible = false;
                //        Failure.Visible = true;
                //        lblmsg.Text = "Failed..";
                //    }
                //}
                //else
                //{
                //    Failure.Visible = true;
                //    success.Visible = false;
                //    lblmsg.Text = "Please Select Status";
                //}
                #endregion

            }
        }     
        GetDetails();
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