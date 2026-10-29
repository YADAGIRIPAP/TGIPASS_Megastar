using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.IO;

public partial class UI_TSiPASS_AssignSVCDate : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();

    comFunctions obcmf = new comFunctions();
    Fetch objFetch = new Fetch();
    string paths = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
            }
            if (!IsPostBack)
            {
                string Cast = Request.QueryString[0].ToString();
                string Investmentid = Request.QueryString[1].ToString();
                h1heading.InnerHtml = Cast + " Category";
                txtsvcdate.Text = Request.QueryString[3].ToString();
                string proposedSvcDate = Request.QueryString[2].ToString();
                string status = "1";
                string distid = Session["DistrictID"].ToString().Trim();
                string Stagenew = Request.QueryString["Stage"].ToString().Trim();
                DataSet ds = new DataSet();

                ds = Gen.getReleaseProceedingsAssignSVCAgenda(Cast, Investmentid, proposedSvcDate, Stagenew);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();
                    btnSubmit.Visible = true;

                    tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                }
                else
                {
                    btnSubmit.Visible = false;
                }

                if (Request.QueryString.Count > 0)
                {
                    //ddlstatus.SelectedValue = status;
                    //ddlstatus.Enabled = false;
                    //ddlDistrict.SelectedValue = distid;
                    //ddlDistrict.Enabled = false;
                    //grdDetails.Columns[7].Visible = false;
                    //grdDetails.Columns[8].Visible = false;
                }
                else
                {
                    //ddlstatus.SelectedIndex = 0;
                    //ddlstatus.Enabled = true;
                    //ddlDistrict.SelectedValue = distid;
                    //ddlDistrict.Enabled = false;
                }
                //if (!IsPostBack)
                //{
                //    fetchIncentivedet();
                //}
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    protected void GetDepartment()
    {

    }


    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            fetchIncentivedet();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    //protected void fetchIncentivedet()
    //{
    //    DataSet ds= new DataSet();

    //    ds = Gen.fetchIncentivedetIPO(Session["User_Code"].ToString(), Request.QueryString[0].ToString().Trim(), ddlIncentiveName.SelectedValue, TxtIndname.Text);
    //         grdDetails.DataSource = ds.Tables[0]; 
    //        grdDetails.DataBind();

    //}
    //fetchIncentivedetIPONewIncType

    protected void fetchIncentivedet()
    {
        try
        {
            DataSet ds = new DataSet();

            ds = Gen.fetchIncentivedetIPONewIncTypeAddlDirector(Session["uid"].ToString(), "3", "", "");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                btnSubmit.Visible = true;
            }
            else
            {
                btnSubmit.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    //protected void gvdetailsnew_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
    //        string status = Request.QueryString[0].ToString().Trim();
    //        //Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
    //        (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "ApplicantIncentiveDtls.aspx?EntrpId=" + enterid.Text.Trim() + "&Sts=" + status + "&SVCStatus=" + Request.QueryString[1].ToString();
    //    }
    //}


    //protected void BtnSaveg_Click(object sender, EventArgs e)
    //{
    //    Button BtnSaveg = (Button)sender;
    //    GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

    //    HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
    //    FileUpload FileUpload6 = (FileUpload)row.FindControl("FileUpload6");
    //    Label Label572 = (Label)row.FindControl("Label572");
    //    //  Label lblFileName2 = (Label)row.FindControl("lblFileName2");
    //    TextBox txtInspectionDate = (TextBox)row.FindControl("txtInspectionDate");

    //    string newPath = "";
    //    string sFileDir = Server.MapPath("~\\IpoIncentive");

    //    General t1 = new General();
    //    if (FileUpload6.HasFile)
    //    {
    //        if ((FileUpload6.PostedFile != null) && (FileUpload6.PostedFile.ContentLength > 0))
    //        {
    //            //determine file name
    //            string sFileName = System.IO.Path.GetFileName(FileUpload6.PostedFile.FileName);
    //            try
    //            {

    //                string[] fileType = FileUpload6.PostedFile.FileName.Split('.');
    //                int i = fileType.Length;
    //                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG" || fileType[i - 1].ToUpper().Trim() == "PNG")
    //                {
    //                    newPath = System.IO.Path.Combine(sFileDir, HdfintApplicationid.Value + System.DateTime.Now.ToString("ddMMyyyyhhmm") + "\\IpoIncentive");
    //                    // Create the subfolder
    //                    ViewState["pathAttachment"] = newPath;
    //                    ViewState["AttachmentName"] = sFileName;
    //                    if (!Directory.Exists(newPath))

    //                        System.IO.Directory.CreateDirectory(newPath);
    //                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
    //                    int count = dir.GetFiles().Length;
    //                    if (count == 0)
    //                        FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                    else
    //                    {
    //                        if (count == 1)
    //                        {
    //                            string[] Files = Directory.GetFiles(newPath);

    //                            foreach (string file in Files)
    //                            {
    //                                File.Delete(file);
    //                            }
    //                            FileUpload6.PostedFile.SaveAs(newPath + "\\" + sFileName);
    //                        }
    //                    }

    //                    int returnValue = Gen.InsertUpload(HdfintApplicationid.Value, "", txtInspectionDate.Text, Session["uid"].ToString(), ViewState["pathAttachment"].ToString(), ViewState["AttachmentName"].ToString());

    //                    if (returnValue != 999)
    //                    {
    //                        DataTable dt = objFetch.FetchIncentiveDtlsbyIncentiveID(HdfintApplicationid.Value);
    //                        string names = dt.Rows[0]["UnitName"].ToString();
    //                        string emailid = dt.Rows[0]["EmailID"].ToString();
    //                        paths = ViewState["pathAttachment"].ToString();


    //                        string msg = "Dear " + names + " , Your Unit's inspection report is prepared and sent to GM.Please see the given link for your inspection report URL: " + paths.Replace(@"D:\TS-iPASSFinal\", "https://ipass.telangana.gov.in/") + "  for your reference.Thank You";
    //                        cmf.SendMailTSiPASSIncentive(emailid, msg);
    //                        // cmf.SendMailTSiPASSIncentive("fss.srikanth@gmail.com", msg);
    //                        fetchIncentivedet();
    //                        lblresult.Text = "Attachment Successfully Uploaded";
    //                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);



    //                    }
    //                    else
    //                    {
    //                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

    //                        lblresult.Text = "Status Not Updated";

    //                    }



    //                    //int result = 0;

    //                    //result = t1.InsertRenewalAttachement("", Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "RenewalBoiler");


    //                    //if (result > 0)
    //                    //{
    //                    //ResetFormControl(this);
    //                    lblresult.Text = "<font color='green'>Attachment Successfully Added..!</font>";
    //                    //   lblFileName2.Text = FileUpload6.FileName;
    //                    Label572.Text = FileUpload6.FileName;
    //                    //success0.Visible = true;
    //                    //Failure0.Visible = false;
    //                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
    //                    //fillNews(userid);
    //                    //}
    //                    //else
    //                    //{
    //                    //    lblresult.Text = "<font color='red'>Attachment Added Failed..!</font>";
    //                    //    ////success0.Visible = false;
    //                    //    ////Failure0.Visible = true;
    //                    //    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
    //                    //}

    //                }
    //                else
    //                {
    //                    lblresult.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
    //                    ////success0.Visible = false;
    //                    ////Failure0.Visible = true;
    //                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
    //                }

    //            }
    //            catch (Exception)//in case of an error
    //            {
    //                //lblError.Visible = true;
    //                //lblError.Text = "An Error Occured. Please Try Again!";
    //                //// DeleteFile(newPath + "\\" + sFileName);
    //                // DeleteFile(sFileDir + sFileName);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Please upload certificate..');", true);

    //        lblresult.Text = "Please upload certificate";
    //        //int returnValue = Gen.InsertUpload(HdfintApplicationid.Value, "",txtInspectionDate.Text , Session["uid"].ToString(), null, null);

    //        //if (returnValue != 999)
    //        //{
    //        //    fetchIncentivedet();
    //        //    lblresult.Text = "Attachment Successfully Uploaded";
    //        //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);



    //        //}
    //        //else
    //        //{
    //        //    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

    //        //    lblresult.Text = "Status Not Updated";
    //        //}
    //        ////lblresult.Text = "<font color='red'>Please Select a file To Upload..!</font>";
    //        //success0.Visible = false;
    //        //Failure0.Visible = true;
    //        //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
    //    }

    //    //Button BtnSaveg = (Button)sender;
    //    //GridViewRow row = (GridViewRow)BtnSaveg.NamingContainer;

    //    //HiddenField HdfintApplicationid = (HiddenField)row.FindControl("HdfintApplicationid");
    //    //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");

    //    //if (ddlStatus.SelectedIndex == 0)
    //    //{
    //    //    lblresult.Text = "Please Select Status";
    //    //}
    //    //else
    //    //{
    //    //    //  lblresult.Text = "Status Updated";


    //    //    int returnValue = Gen.ChangeStateWiseStatus(HdfintApplicationid.Value, ddlStatus.SelectedValue.ToString().Trim(), Session["uid"].ToString());

    //    //    if (returnValue != 999)
    //    //    {

    //    //        lblresult.Text = "Status Updated";
    //    //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Status Updated Successfully');", true);

    //    //        fillgrid();

    //    //    }
    //    //    else
    //    //    {
    //    //        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Failed..');", true);

    //    //        lblresult.Text = "Status Not Updated";

    //    //    }


    //    //        }
    //    //  int returnValue = cnn.ChangestatusAppl(HdfintApplicationid.Value, ddlStatusg.SelectedValue.ToString().Trim(), Session["uid"].ToString());




    //}


    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        //ExportToExcel();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtsvcdate.Text.Trim() == "")
            {
                string message = "alert('Please Enter Convened SVC Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            // //List<officerRemarks> lstremarks = new List<officerRemarks>();
            // foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            // {
            //     int rowIndex = gvrow.RowIndex;
            //     string EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
            //     string IncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

            //     // string IncentiveName = gvrow.Cells[1].Text;

            //     string ApproveStatus = ((RadioButtonList)gvrow.FindControl("rbtnLstApprove")).SelectedValue;

            //     string Userid = Session["uid"].ToString();
            //     string valid = "", SVCDate = "";

            //     if (txtsvcdate.Text != "" && txtsvcdate.Text.Contains('/'))
            //     {
            //         string[] datett = txtsvcdate.Text.Trim().Split('/');
            //         SVCDate = datett[2] + "/" + datett[1] + "/" + datett[0];
            //     }
            //     //  SVCDate = txtsvcdate.Text;
            //   valid = Gen.UpdateSVCDate(EnterperIncentiveID, Userid, SVCDate, ApproveStatus);

            // }
            // trold.Visible = true;
            // btnSubmit.Visible = false;
            // lblresult.Text = "<font color='green'>SVC Date Assigned Successfully..!</font>";

            // //success.Visible = true;
            // //Failure.Visible = false;



            //// --------------------------------------------------------------------------------------------------------------
            int valid = 0;
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
                if (chkcheck.Checked == true)
                {
                    officerRemarks fromvo = new officerRemarks();
                    int rowIndex = gvrow.RowIndex;

                    fromvo.EnterperIncentiveID = ((Label)gvrow.FindControl("lblEnterperIncentiveID")).Text.ToString();
                    fromvo.MstIncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    string ApproveStatus = ((RadioButtonList)gvrow.FindControl("rbtnLstApprove")).SelectedValue;
                    string rejectedRemarks = ((TextBox)gvrow.FindControl("txtIncQueryFnl2")).Text.Trim();
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    if (ApproveStatus == "Y")
                    {
                        fromvo.status = "File in full shape";
                        fromvo.Remarks = gvdetailsnew.Rows[rowIndex].Cells[6].Text;
                    }
                    if (ApproveStatus == "N")
                    {
                        fromvo.status = "Reject";
                        fromvo.Remarks = rejectedRemarks;
                    }
                    if (txtsvcdate.Text != "" && txtsvcdate.Text.Contains('/'))
                    {
                        string[] datett = txtsvcdate.Text.Trim().Split('/');
                        fromvo.Slcdate = datett[2] + "/" + datett[1] + "/" + datett[0];
                        //string[] date4 = txtsvcdate.Text.Trim().Split('/');
                        //fromvo.Slcdate = txtsvcdate.Text.Trim();
                    }
                    fromvo.CreatedByid = Session["uid"].ToString();
                    fromvo.Designation = Role_Code.Trim();
                    //return;
                    valid = Gen.InsertincentiveOfficerCommentsAdditionalPOSTSLCASSignDAteBulk(fromvo, "POSTSVC");
                }
            }
            if (valid == 1)
            {
                string message = "alert('SVC Proceedings Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    protected void rbtnLstApprove_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButtonList ddlDeptnameFnl2 = (RadioButtonList)sender;

            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
            if (ddlDeptnameFnl2.SelectedValue == "Y")
            {
                txtIncQuery.Visible = false;
            }
            else
            {
                txtIncQuery.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblMsg.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
}