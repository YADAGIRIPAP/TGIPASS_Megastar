using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Net.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text;

public partial class UI_TSiPASS_frmApproveDetailsbyquery_DWGOgroundwater : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    string AttachmentFilepath = "", AttachmentFileName = "";
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";

    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;

    string responseFromServer = "";

    Cls_OSGroundWater obj_dashboard = new Cls_OSGroundWater();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/tshome.aspx");
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != null)
                {
                    hdfFlagID_applicantno.Value = Convert.ToString(Request.QueryString[0]);

                    if (!IsPostBack)
                    {
                        FillDetails();
                    }

                }
            }
            //if (!IsPostBack)
            //{
            //    if (Session["Reject"] != null && Convert.ToString(Session["Reject"]) == "Y")
            //    {
            //        ddlStatus.SelectedValue = "16";
            //        Session["Reject"] = "";
            //        ddlStatus.Enabled = false;
            //        ddlStatus_SelectedIndexChanged(sender, e);
            //    }
            //}
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    void FillDetails()
    {
        try
        {
            DataSet ds = obj_dashboard.GetdataofApprovaldataAprovalbyID_groundwater(Request.QueryString[0].ToString(), Session["User_Code"].ToString().Trim());
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_UIDNumber.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                    lbl_nameofapplicant.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString().Trim();
                    lbl_typeofapplicant.Text = ds.Tables[0].Rows[0]["ApplicationType_IndusorAgriName"].ToString().Trim();
                    hf_intApprovalid.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                    hf_intDeptid.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                    hf_intQuessionaireid.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();

                    string stageid = Convert.ToString(ds.Tables[0].Rows[0]["Stageid"]);
                    string DWGOApproved = Convert.ToString(ds.Tables[0].Rows[0]["DWGOApproved"]);
                    string DWGORejected = Convert.ToString(ds.Tables[0].Rows[0]["DWGORejected"]);
                    string DWGOQueryRaised = Convert.ToString(ds.Tables[0].Rows[0]["DWGOQueryRaised"]);
                    string ISDWGOQueryResponded = Convert.ToString(ds.Tables[0].Rows[0]["ISDWGOQueryResponded"]);
                    if (!string.IsNullOrEmpty(stageid))
                    {
                        if (stageid == "12")
                        {
                            if (DWGOQueryRaised == "Y" && ISDWGOQueryResponded == "Y")
                            {
                                ddlStatus.Items.RemoveAt(1);
                            }
                        }
                        else
                        {
                            Response.Redirect("frmDepartementDashboardNew_GW.aspx");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {

        }


    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            tr_Remarks.Visible = false;
            tr_filereferece.Visible = false;
            tr_upload.Visible = false;
            try
            {
                if (ddlStatus.SelectedValue.ToString().Trim() == "16")
                {
                    tr_Remarks.Visible = true;
                    tr_filereferece.Visible = true;
                    tr_upload.Visible = true;
                    label_head5.Text = "Upload Document";
                }
                else if (ddlStatus.SelectedValue.ToString().Trim() == "5")
                {
                    tr_Remarks.Visible = true;
                }
                else
                {
                    tr_filereferece.Visible = true;
                    tr_upload.Visible = true;
                    tr_Remarks.Visible = true;
                    label_head5.Text = "Upload Certificate";
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedIndex > 0)
            {

                string newPath = "";
                string sFileDir = Server.MapPath("~\\Attachments\\GroundWaterWaltForm");
                if (file_uploadcert.HasFile)
                {
                    if ((file_uploadcert.PostedFile != null) && (file_uploadcert.PostedFile.ContentLength > 0))
                    {
                        //determine file name
                        string sFileName = System.IO.Path.GetFileName(file_uploadcert.PostedFile.FileName);
                        LogErrorFile.LogData(sFileName);
                        try
                        {
                            string[] fileType = file_uploadcert.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            LogErrorFile.LogData(Convert.ToString(i));
                            if (fileType[i - 1].ToUpper().Trim() == "PDF")
                            {
                                //Create a new subfolder under the current active folder
                                if (ddlStatus.SelectedValue == "16")
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\DistrictRejectedDocument\\" + hf_intDeptid.Value);// + System.DateTime.Now.ToString("ddMMyyyyHHmmtt")
                                    LogErrorFile.LogData(newPath);
                                }
                                else
                                {
                                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\DistrictApprovalDocument\\" + hf_intDeptid.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));
                                }

                                // Create the subfolder
                                if (!Directory.Exists(newPath))
                                    System.IO.Directory.CreateDirectory(newPath);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                                LogErrorFile.LogData(Convert.ToString(dir));
                                int count = dir.GetFiles().Length;
                                LogErrorFile.LogData(Convert.ToString(count));
                                if (count == 0)
                                {
                                    file_uploadcert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                    LogErrorFile.LogData(Convert.ToString(newPath + "\\" + sFileName));
                                }                    
                                else
                                {
                                    if (count == 1)
                                    {
                                        string[] Files = Directory.GetFiles(newPath);

                                        foreach (string file in Files)
                                        {
                                            File.Delete(file);
                                        }
                                        file_uploadcert.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                        LogErrorFile.LogData(Convert.ToString(newPath + "\\" + sFileName));
                                    }
                                }
                                int result = 0;
                                if (ddlStatus.SelectedValue == "16")
                                {
                                    result = obj_dashboard.InsertImagedataApproval_groundwater(hf_intQuessionaireid.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "DistrictRejectedDocument", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hf_intDeptid.Value, hf_intApprovalid.Value);
                                    LogErrorFile.LogData(Convert.ToString(result));
                                }
                                else
                                {
                                    result = obj_dashboard.InsertImagedataApproval_groundwater(hf_intQuessionaireid.Value, fileType[i - 1].ToUpper(), newPath, sFileName, "DistrictApprovalDocument", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hf_intDeptid.Value, hf_intApprovalid.Value);
                                }

                                if (result > 0)
                                {
                                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                    lblFileName.Text = file_uploadcert.FileName;
                                    success.Visible = true;
                                    Failure.Visible = false;
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
                                lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                            }

                        }
                        catch (Exception ex)//in case of an error
                        {
                            // DeleteFile(newPath + "\\" + sFileName);
                            LogErrorFile.LogData(Convert.ToString(ex));
                        }
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }

            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a Status..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {

            lblmsg.Text = "";
            if (BtnSave1.Text == "Submit")
            {
                int i = 0;
                if (ddlStatus.SelectedValue == "5")
                {
                    if (txtremarks.Text != "")
                    {

                        int result = 0;
                        result = obj_dashboard.insertDepartmentProcess_grounwaterMRO(hf_intQuessionaireid.Value, hf_intDeptid.Value, hf_intApprovalid.Value, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString().Trim());
                        int j = obj_dashboard.UpdateprescrunitystageofMRO(hf_intQuessionaireid.Value, "", "Completed", Session["uid"].ToString(), ddlStatus.SelectedValue.ToString(), hf_intDeptid.Value, hf_intApprovalid.Value, getclientIP(),"");
                        int io = obj_dashboard.insertQueryResponsedata_MROGroundwater(result.ToString(), hf_intQuessionaireid.Value, txtremarks.Text, "Y", Session["uid"].ToString(), hf_intDeptid.Value, hf_intApprovalid.Value, hf_intQuessionaireid.Value);
                        int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_intDeptid.Value, hf_intQuessionaireid.Value, lbl_UIDNumber.Text, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), null, null, "GW", hf_intApprovalid.Value);
                    }
                    else
                    {
                        lblmsg0.Text = "Please Enter Query to raise..";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                else if (ddlStatus.SelectedValue == "16")
                {
                    if (txtremarks.Text != "")
                    {
                        i = obj_dashboard.insertApprovalData_DWGOgroundwater(Request.QueryString[0].ToString(), txt_FileReferenceNo.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hf_intApprovalid.Value, hf_intDeptid.Value, txtremarks.Text, getclientIP());
                        int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_intDeptid.Value, hf_intQuessionaireid.Value, lbl_UIDNumber.Text, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "GW", hf_intApprovalid.Value);

                    }
                    else
                    {
                        lblmsg0.Text = "Please Enter Reason For Rejection..";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                else if (ddlStatus.SelectedValue == "13")
                {
                    if (lblFileName.Text.Trim() != "")
                    {
                        i = obj_dashboard.insertApprovalData_DWGOgroundwater(Request.QueryString[0].ToString(), txt_FileReferenceNo.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hf_intApprovalid.Value, hf_intDeptid.Value, txtremarks.Text, getclientIP());

                        try
                        {
                            int k = obj_dashboard.InsertDeptDateTracing_mrogroundwater(hf_intDeptid.Value.Trim(), hf_intQuessionaireid.Value.Trim(), lbl_UIDNumber.Text.Trim(), null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "GW", hf_intApprovalid.Value);    
                        }
                        catch (Exception ex)
                        {

                        }                     
                    }
                    else
                    {
                        lblmsg.Text = "Please Upload Approval Document";
                        success.Visible = true;
                        Failure.Visible = false;
                        return;
                    }
                }
                if (i != 999)
                {
                    DataSet dsMail1 = new DataSet();
                    dsMail1 = obj_dashboard.GetShowEmailidandMobileNumber_MROGroundwater(hf_intQuessionaireid.Value.ToString());
                    if (ddlStatus.SelectedValue == "13")
                    {
                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") :<br/><br/> <b>" + "District Ground Water Officer" + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") ," + "District Ground Water Officer" + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                        }
                        txt_FileReferenceNo.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status Updated Successfully";
                        Response.Redirect("frmDepartementDashboardNew_GW.aspx");
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "16")
                    {
                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") :<br/><br/> <b>" + "District Ground Water Officer" + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") ," + "District Ground Water Officer" + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        }
                        txt_FileReferenceNo.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status Updated Successfully";

                        Response.Redirect("frmDepartementDashboardNew_GW.aspx");

                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else if (ddlStatus.SelectedValue == "5")
                    {
                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") :<br/><br/> <b>" + "District Ground Water Officer" + " has " + ddlStatus.SelectedItem.Text.ToString() + " has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You..</b>");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNumber.Text + ") ," + "District Ground Water Officer" + " has " + ddlStatus.SelectedItem.Text.ToString() + " has raised a query on your application. </b><br/><br/>Please respond to the query in your login in https://ipass.telangana.gov.in/. Thank You..");
                        }
                        txt_FileReferenceNo.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status  Query Raised  Successfully";

                        Response.Redirect("frmDepartementDashboardNew_GW.aspx");

                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }
                else
                {
                    lblmsg.Text = "failed..";
                    success.Visible = false;
                    Failure.Visible = true;
                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
    public void GetTESTVALUES(string Responce, string UIDNO, string MOBILENO, string INTQUESSIONAREID, string INTDEPTID, string INTAPPROVALID)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_INS_SMSSENDDATA", con.GetConnection);
            da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
            da.SelectCommand.Parameters.Add("@UIDno", SqlDbType.VarChar).Value = UIDNO.ToString();
            da.SelectCommand.Parameters.Add("@Mobileno", SqlDbType.VarChar).Value = MOBILENO.ToString();
            da.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = INTQUESSIONAREID.ToString();
            da.SelectCommand.Parameters.Add("@intDeptid", SqlDbType.VarChar).Value = INTDEPTID.ToString();
            da.SelectCommand.Parameters.Add("@intApprovalid", SqlDbType.VarChar).Value = INTAPPROVALID.ToString();

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    public string SendSingleSMS(String mobileNo, String message)
    {
        try
        {
            request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(password) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            //  request.KeepAlive = false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
        if (responseFromServer.Contains("402"))
        {
            try
            {
                GetTESTVALUES(message, lbl_UIDNumber.Text.Trim(), mobileNo, hf_intQuessionaireid.Value.ToString(), hf_intDeptid.Value.ToString(), hf_intApprovalid.Value);
            }
            catch (Exception ex)
            {

            }
        }
        return responseFromServer.Trim();
        // return "402,1,0";

    }



}