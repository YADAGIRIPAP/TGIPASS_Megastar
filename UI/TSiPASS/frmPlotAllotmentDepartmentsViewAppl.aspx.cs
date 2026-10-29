using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_TSiPASS_frmPlotAllotmentDepartmentsViewAppl : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    cls_plotallotmentadmin Gen = new cls_plotallotmentadmin();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string rstages = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                ddldistrict.Enabled = true;
                DataSet dsd = Gen.GetDistrictsofplot();
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--Select--");
                if (Session["DistrictID"].ToString().Trim() != "")
                {
                    ddldistrict.SelectedValue = Convert.ToString(Session["DistrictID"]);
                    ddldistrict.Enabled = false;
                }
                GetDetails();
            }
        }
    }

//     --2	Q - Submitted
//--3	Application Submitted and Payment Pending
//--5	Query Raised and Payment Pending
//--8	Query Responded and Payment Pending
//--13	Approved by Department
//--16	Rejected
//--19	Deffered

    public void GetDetails()
    {
        if (Request.QueryString.Count > 0)
        {
            rstages = Request.QueryString[0].ToString().Trim();
            DataSet dsn = new DataSet();
            dsn = Gen.GetShowDepartmentFiles_plotallotment(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), Session["DistrictID"].ToString().Trim());
            if (dsn.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[14].Visible = false;
                grdDetails.Columns[15].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
       
    }
 
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        GetDetails();

    }
  
    public void GetDetailsSearch()
    {
        if (txt_nameofUnit.Text == String.Empty && txt_uidno.Text == String.Empty && ddldistrict.SelectedItem.Text == "--Select--")
        {
            GetDetails();
        }
        else
        {
            if (Request.QueryString.Count > 0)
            {
                rstages = Request.QueryString[0].ToString().Trim();
                DataSet dsn = new DataSet();
                dsn = Gen.GetShowDepartmentFilesSearch_plotallotment(Session["User_Code"].ToString().Trim(), rstages.ToString().Trim(), ddldistrict.SelectedValue.ToString(), txt_nameofUnit.Text, txt_uidno.Text);
                if (dsn.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsn.Tables[0];
                    grdDetails.DataBind();
                    grdDetails.Columns[14].Visible = false;
                    grdDetails.Columns[15].Visible = false;
                }
                else
                {
                    grdDetails.DataSource = null;
                    grdDetails.DataBind();
                }
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
            if (e.Row.Cells[13].Text.Trim() == "Y")
            {
                e.Row.Cells[13].Text = "Please process this application in Concerned Department portal";
                e.Row.Cells[13].Font.Bold = true;
            }
            else
            {
                 e.Row.Cells[13].Text = "Please process this application in TS-iPASS portal";
            }

            string intUid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNO")).Trim();
            LinkButton btn = (LinkButton)e.Row.FindControl("lnk_griduidno");
            btn.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNO")).Trim();
            btn.OnClientClick = "javascript:return Popup('" + intUid + "')";


            HyperLink hyp_userform = (HyperLink)e.Row.Cells[8].Controls[0];
            hyp_userform.NavigateUrl = "UserFormView_plotallotment.aspx?intApplid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationId")).Trim();
            hyp_userform.Target = "_blank";

            HyperLink hyp_paymentform = (HyperLink)e.Row.Cells[9].Controls[0];
            hyp_paymentform.Target = "_blank";
            hyp_paymentform.NavigateUrl = "RptPaymentDetails_DeptPlotallotment.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UIDNO")).Trim();


            Label lbl_grdcurrentstatus = (Label)e.Row.FindControl("lbl_grdcurrentstatus");
            HyperLink hyp_grdqueryresponse = (HyperLink)e.Row.Cells[10].Controls[0];
            // HyperLink hyp_grdqueryresponse = (HyperLink)e.Row.FindControl("hyp_grdqueryresponse");

            hyp_grdqueryresponse.NavigateUrl = "frmQurieResponseStatus_PlotAllotment.aspx?intApplicationId=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApplicationId")).Trim();
            hyp_grdqueryresponse.Target = "_blank";
         

            string currentstatusmsg = "";

               if(!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate")).Trim()))
            {
                currentstatusmsg="<b>Query Raised Date:</b>"+ Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate")).Trim()+"</br>";
              //  hyp_grdqueryresponse.Visible = true;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_ResponedDate")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Query Responed Date:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_ResponedDate")).Trim() + "</br>";
              //  hyp_grdqueryresponse.Visible = true;
            }  
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Deffered_date")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Deffered Date:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Deffered_date")).Trim() + "</br>";
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefferedReason")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Deffered Reason:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DefferedReason")).Trim() + "</br>";
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_date")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Approved Date:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Approval_date")).Trim() + "</br>";
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalRemarks")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+"<b>Approval Remarks:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalRemarks")).Trim() + "</br>";
            }          
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Rejected_date")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Rejected Date:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Rejected_date")).Trim() + "</br>";
            }
            if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedReason")).Trim()))
            {
                currentstatusmsg = currentstatusmsg+ "<b>Rejected Reason:</b>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "RejectedReason")).Trim() + "</br>";
            }
            lbl_grdcurrentstatus.Text = currentstatusmsg;

            //2(Q - Submitted),3(Application Submitted and Payment Pending),5(Query Raised and Payment Pending),8 (Query Responded and Payment Pending),
            //13 (Approved by Department),16(Rejected),19(Deffered)

            DropDownList ddlStatus = (DropDownList)e.Row.FindControl("ddlStatus");
            Label lbl_grdbiewstatus = (Label)e.Row.FindControl("lbl_grdbiewstatus");
            Label lbl_statusselectedtext = (Label)e.Row.FindControl("lbl_statusselectedtext");
            Label LabelDiscription = (Label)e.Row.FindControl("LabelDiscription");
            TextBox txt_gdreason = (TextBox)e.Row.FindControl("txt_gdreason");
            Button BtnSave = (Button)e.Row.FindControl("BtnSave");

            //Label lbl_grdcurrentstatus = (Label)e.Row.FindControl("lbl_grdcurrentstatus");

            ddlStatus.Visible = false;
            BtnSave.Visible = false;
            lbl_grdbiewstatus.Visible = false;

            int Stageidofrow =Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "intstageid"));
            if(Stageidofrow>=3)
            {             
                if(Stageidofrow==13 || Stageidofrow == 16)
                {
                    //13 (Approved by Department),16(Rejected)
                }
                else
                {
                    ddlStatus.Visible = true;
                    BtnSave.Visible = true;
                    lbl_grdbiewstatus.Visible = true;
                    if(Stageidofrow==19)
                    {
                        //19(Deffered)
                        ddlStatus.Items.RemoveAt(2);
                        if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Query_RaiseDate")).Trim()))
                        {
                            ddlStatus.Items.RemoveAt(1);
                        }
                    }
                    if (Stageidofrow == 5 || Stageidofrow == 8)
                    {
                        //5(Query Raised and Payment Pending),8 (Query Responded and Payment Pending) 
                        ddlStatus.Items.RemoveAt(1);
                        if (!string.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Deffered_date")).Trim()))
                        {
                            ddlStatus.Items.RemoveAt(2);
                        }
                    }
                    //ddlStatus.Items.RemoveAt(3);
                    //if (ddlStatus.Items.FindByValue("11") != null)
                    // ddlStatus.Items.RemoveAt(ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue("11")));
                }
            }

        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        //2(Q - Submitted),3(Application Submitted and Payment Pending),5(Query Raised and Payment Pending),8 (Query Responded and Payment Pending),
        //13 (Approved by Department),16(Rejected),19(Deffered)

        DropDownList ddlStatus = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
        TextBox txt_gdreason = (TextBox)row.FindControl("txt_gdreason");
        Label lbl_statusselectedtext = (Label)row.FindControl("lbl_statusselectedtext");
        Label LabelDiscription = (Label)row.FindControl("LabelDiscription");

        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        HiddenField hf_intDeptid = (HiddenField)row.FindControl("hf_intDeptid");
        HiddenField hf_intApprovalid = (HiddenField)row.FindControl("hf_intApprovalid");
        HiddenField hf_intstageid = (HiddenField)row.FindControl("hf_intstageid");

        txt_gdreason.Visible = false;
        lbl_statusselectedtext.Visible = false;
        LabelDiscription.Visible = false;

        if (ddlStatus.SelectedValue.ToString() == "5")
        {
            //5(Query Raised and Payment Pending)
            txt_gdreason.Visible = true;
            lbl_statusselectedtext.Visible = true;
            lbl_statusselectedtext.Text = "Query Description";
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "19")
        {
            //19(Deffered)
            txt_gdreason.Visible = true;
            lbl_statusselectedtext.Visible = true;
            lbl_statusselectedtext.Text = "Deffered Reason";
            LabelDiscription.Visible = false;
        }
        else if (ddlStatus.SelectedValue.ToString() == "16")
        {
           // 16(Rejected)
            txt_gdreason.Visible = true;
            lbl_statusselectedtext.Visible = true;
            LabelDiscription.Visible = true;

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
            lbl_statusselectedtext.Text = "Reason For Rejection";           
        }
        else if (ddlStatus.SelectedValue.ToString() == "13")
        {
            //13 (Approved by Department)
           // Response.Redirect("frmapprovalplotallotmentbyDepartment.aspx?");
            //frmPlotAllotmentDepartmentsViewAppl.aspx? Stg = 5 & Pre - Scrutiny - Pending Within 3 Days
            Response.Redirect("frmapprovalplotallotmentbyDepartment.aspx?Stg=5&Pre-Scrutiny-Pending Within 3 Days"+ "&intApplicationId=" + hdfApplID.Value.Trim() + "&DepartmentID="+ hf_intDeptid.Value.Trim() + "&ApprovalID=" + hf_intApprovalid.Value + "&StageID="+ ddlStatus.SelectedValue);
        }
      
    }
    protected void BtnSave_Click1(object sender, EventArgs e)
    {
        //2(Q - Submitted),3(Application Submitted and Payment Pending),5(Query Raised and Payment Pending),8 (Query Responded and Payment Pending),
        //13 (Approved by Department),16(Rejected),19(Deffered)
        Button BtnSave = (Button)sender;
        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");
        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txt_gdreason = (TextBox)row.FindControl("txt_gdreason");

        HiddenField hf_intDeptid = (HiddenField)row.FindControl("hf_intDeptid");
        HiddenField hf_intApprovalid = (HiddenField)row.FindControl("hf_intApprovalid");
        HiddenField hf_intstageid = (HiddenField)row.FindControl("hf_intstageid");
        HiddenField hf_LastDateofPreScrutiy = (HiddenField)row.FindControl("hf_LastDateofPreScrutiy");
        HiddenField hf_grduidno = (HiddenField)row.FindControl("hf_grduidno");
        
        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;
            success.Visible = false;
            lblmsg.Text = "Please Select Status";
        }
        else
        {
            if (!string.IsNullOrEmpty(txt_gdreason.Text) || txt_gdreason.Text == "")
            {
                lblmsg.Text = "Please Enter Query Description";
            }
            else
            {
                int result = 0;
                //insert into new table for tracking status
                result = Gen.insertDepartmentProcess_plotallotment(hdfApplID.Value, hf_intDeptid.Value, hf_intApprovalid.Value, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString().Trim());
               //update in current tracker table department approvals
                int j = Gen.UpdateStatusofapplicant_plotallotment(hdfApplID.Value, Convert.ToString(txt_gdreason.Text), "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_intDeptid.Value, hf_intApprovalid.Value, getclientIP());
               

                if (ddlStatus.SelectedValue.ToString() == "5")
                {
                    //update flag of departmenttracker table
                    try
                    {
                        int k = Gen.InsertDeptDateTracing_plotallotment(hf_intDeptid.Value, hdfApplID.Value, hf_grduidno.Value, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "Plot Allotment", hf_intApprovalid.Value);
                    }
                    catch (Exception ex)
                    {

                    }

                    DataSet dsMail = Gen.GetShowEmailidandMobileNumber_plotallotment(hdfApplID.Value);
                    if (dsMail.Tables[0].Rows.Count > 0)
                    {
                        cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + "  :<br/><br/> <b> " + Session["user_id"].ToString() + "  has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You.");
                    }
                    if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    {

                        cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has raised a query on your application. Please respond to the query in your login in https://ipass.telangana.gov.in. Thank You.");
                    }
                }
                else if (ddlStatus.SelectedValue.ToString() == "19")
                {
                    try
                    {
                        int k = Gen.InsertDeptDateTracing_plotallotment(hf_intDeptid.Value, hdfApplID.Value, hf_grduidno.Value,null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, null, "Plot Allotment", hf_intApprovalid.Value);
                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    dsMail = Gen.GetShowEmailidandMobileNumber_plotallotment(hdfApplID.Value);
                    if (dsMail.Tables[0].Rows.Count > 0)
                    {
                        cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    }
                    if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    {
                        cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");

                    }
                }
                else if (ddlStatus.SelectedValue.ToString() == "13")
                {
                    try
                    {
                        int k = Gen.InsertDeptDateTracing_plotallotment(hf_intDeptid.Value, hdfApplID.Value, hf_grduidno.Value, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "Plot Allotment", hf_intApprovalid.Value);

                    }
                    catch (Exception ex)
                    {

                    }
                    DataSet dsMail = new DataSet();
                    dsMail = Gen.GetShowEmailidandMobileNumber_plotallotment(hdfApplID.Value);
                    if (dsMail.Tables[0].Rows.Count > 0)
                    {
                        cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");
                    }
                    if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                    {
                        cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has completed pre-scrutiny of your application. Thank You.");

                    }
                }
                else if (ddlStatus.SelectedValue.ToString() == "16")
                {
                    if (txt_gdreason.Text.Trim() != "")
                    {
                        int k = Gen.InsertDeptDateTracing_plotallotment(hf_intDeptid.Value, hdfApplID.Value,hf_grduidno.Value, null,null, null, null, null, "Plot Allotment", hf_intApprovalid.Value);
                        DataSet dsMail = new DataSet();
                        dsMail = Gen.GetShowEmailidandMobileNumber_plotallotment(hdfApplID.Value);
                        if (dsMail.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " :<br/><br/> <b> " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        }
                        if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + dsMail.Tables[0].Rows[0]["Names"].ToString().Trim() + " : " + Session["user_id"].ToString() + "  has Rejected your application. Please login to TS-iPASS Appeal for Rejection. Thank You.");

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
                        if (txt_gdreason.Text.Trim() == "")
                        {
                            success.Visible = false;
                            Failure.Visible = true;
                            lblmsg0.Text = "Please Enter Reason For Rejection";
                        }
                    }
                    ddlStatus.SelectedIndex = 0;
                    txt_gdreason.Text = "";
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg.Text = "Failed..";
                }
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
    protected void btn_searchdata_Click(object sender, EventArgs e)
    {
        GetDetailsSearch();
    }
}