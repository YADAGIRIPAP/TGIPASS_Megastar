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

public partial class UI_TSiPASS_frmResponceQueries_UserDrillingRigs : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    Cls_DrillingRigs obj_data = new Cls_DrillingRigs();
    string intQuessionaireid = "",intCFEEnterpid = "",intDeptid = "",intApprovalid = "",Created_by = "";
    string queryid = ""; string AttachmentFileName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }
        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString[0].ToString() != null)
            {
                hf_intapplicationid.Value = Request.QueryString[0].ToString();
                Session["Applid"] = Convert.ToString(Request.QueryString[0].ToString());
                if (!IsPostBack)
                {
                    FillDetails();
                }

            }
        }
        else
        {

        }
    }

    void FillDetails()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = obj_data.GetQueryStatusByTransactionID_Rigs(Request.QueryString[0].ToString(),Convert.ToString(Session["uid"]));
            if (Request.QueryString[0].ToString() != null)
            {
                queryid = Request.QueryString[0].ToString();
            }

            //RegRigID  Applicationtypeid   AddDistrictId AddDistrictName AddMandalid AddMandalname   AddVillageid AddVillagename  
            //    Street Houseno regvehicleno rtoplaceofregvehicle    RTODistrictID RTODistrictName Descofdrillrigs maxdiameterdepth    
            //    Areaofoperation Isactive    CreatedOn CreatedBy   CreatedIP ModifiedOn  ModifiedBy ModifiedIP 
            //    AppStatus Stageid PaymentDate UIDNO   DWGODeptid DWGOApprovalid  FeeAmount PaymentDone ApplicantMobileno ApplicantEmailID  
            //    intDeptid intApprovalid   intStatusid intCFEEnterpid  UID_No Nameoftheapplicant  RTODistrictName
            //    Applicationtype LastDateofPreScrutiy QueryDescription    QueryRaiseDate    intQueryTrnsid 
            //    intEnterpreniourApprovalid QueryStatus CommonDetailsUpdatedFlag additionaldocs  QueryDetails

                     if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lbl_uidno.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                lbl_nameoftheapplicant.Text = ds.Tables[0].Rows[0]["Nameoftheapplicant"].ToString().Trim();
                lbl_placeofrtoregistration.Text = ds.Tables[0].Rows[0]["RTODistrictName"].ToString().Trim();
                lbl_applicationtype.Text = ds.Tables[0].Rows[0]["Applicationtype"].ToString().Trim();
                lbl_departmentname.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString().Trim();
                lbl_approvalname.Text = ds.Tables[0].Rows[0]["ApprovalName"].ToString().Trim();
                lbl_queryraiseddate.Text = ds.Tables[0].Rows[0]["QueryRaiseDate"].ToString().Trim();
                lbl_querydescription.Text = ds.Tables[0].Rows[0]["QueryDescription"].ToString().Trim();
                hf_intdeptid.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                hf_intapprovalid.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                hf_intcfeentrpid.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                intCFEEnterpid = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                trresponseattachment.Visible = true;
                
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

                intQuessionaireid = hf_intcfeentrpid.Value;
                intCFEEnterpid = hf_intcfeentrpid.Value;
                intDeptid = hf_intdeptid.Value;
                intApprovalid = hf_intapprovalid.Value;
        Created_by = Convert.ToString(Session["uid"]);
        try
        {
            if ((txtdiscription.Text == "" && txtdiscription.Text == string.Empty) && (Label440.Text == "" && Label440.Text == string.Empty))
            {
                lblmsg0.Text = "Please Enter Query Response or Upload Atachment";
                Failure.Visible = true;
                lblmsg0.Focus();
                return;
            }
            int result = 0;
            string queryresopnedesc = txtdiscription.Text.Trim();
            result = obj_data.InsertQueryDetails_Rigs(intQuessionaireid, intCFEEnterpid, intDeptid, intApprovalid,ViewState["AttachmentName"].ToString(),
                ViewState["pathAttachment"].ToString(), queryresopnedesc,Created_by,getclientIP());
            string UIDNO = Convert.ToString(lbl_uidno.Text).Trim();
            string filepath = Convert.ToString(hyp_resattach.NavigateUrl).Trim();
            string remarks = Convert.ToString(txtdiscription.Text).Trim();
            int k = obj_data.InsertDeptDateTracing_DrillingsRigs(intDeptid, intQuessionaireid, UIDNO, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, "Rigs", intApprovalid);

            //if (result!=null)
            //{

                //ResetFormControl(this);
                DataSet dsMail = new DataSet();
              
                //string UIDNO = Convert.ToString(lbl_uidno.Text).Trim();
                //string filepath = dsdept.Tables[0].Rows[0]["queryRespDocPath"].ToString();
                //string remarks = Convert.ToString(txtdiscription.Text).Trim();

              

      
                dsMail =obj_data.GetShowEmailidandMobileNumber_DrillingRigs(intQuessionaireid);
                if (dsMail.Tables[0].Rows.Count > 0)
                {
                    cmf.SendMailTSiPASS(dsMail.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameoftheapplicant.Text + " - (" + lbl_uidno.Text + ") :<br/><br/> <b> Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                }
                if (dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                {
                    cmf.SendSingleSMS(dsMail.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameoftheapplicant.Text + " - (" + lbl_uidno.Text + ") : Response to query has been submitted successfully.Further details will be communicated. Thank You.");
                }
                lblmsg.Text = "<font color='green'>Query Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                Response.Redirect("UserDrillingRigsborewelllist.aspx");
            //}
            //else
            //{
            //    lblmsg0.Text = "<font color='red'>Query Details Adding Failed..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //}

        }

        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();

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

    protected void Button6_Click(object sender, EventArgs e)
    {
        hyp_resattach.Visible = false;
        string newPath = "";
        string sFileDir = Server.MapPath("~\\Attachments");
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            AttachmentFileName = sFileName;
            try
            {
                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, hf_intcfeentrpid.Value + "\\ResponseAttachment\\" + hf_intdeptid.Value);
                    ViewState["pathAttachment"] = newPath;
                    ViewState["AttachmentName"] = sFileName;

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    int result = 0;
                    if (count == 0)
                    {
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        result = obj_data.InsertImagedataApproval_DrillingRigs(hf_intcfeentrpid.Value.ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Response Attachment", Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), hf_intdeptid.Value.ToString(), hf_intapprovalid.Value.ToString());
                        hyp_resattach.Visible = true;
                        hyp_resattach.NavigateUrl = newPath + "/" + sFileName;
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
                            result = obj_data.InsertImagedataApproval_DrillingRigs(hf_intcfeentrpid.Value.ToString(), fileType[i - 1].ToUpper(), newPath, FinalFileName, "Response Attachment",Session["uid"].ToString(), DateTime.Now.ToString(), Session["uid"].ToString(), DateTime.Now.ToString(), hf_intdeptid.Value.ToString(), hf_intapprovalid.Value.ToString());
                            hyp_resattach.Visible = true;
                            hyp_resattach.NavigateUrl = newPath + "/" + FinalFileName;
                        }
                    }
                    if (result > 0)
                    {
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        FillDetails();
                        success.Visible = true;
                        Failure.Visible = false;
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
                DeleteFile(newPath + "\\" + sFileName);
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