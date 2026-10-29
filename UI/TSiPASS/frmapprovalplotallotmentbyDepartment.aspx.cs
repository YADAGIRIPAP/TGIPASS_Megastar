using System.Xml;
using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;


public partial class UI_TSiPASS_frmapprovalplotallotmentbyDepartment : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    cls_plotallotmentadmin Gen = new cls_plotallotmentadmin();   
    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;

    string responseFromServer = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (Request.QueryString["intApplicationId"] != null)
            {
                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
            if (!IsPostBack)
            {
                if (Session["Reject"] != null && Convert.ToString(Session["Reject"]) == "Y")
                {
                    ddlStatus.SelectedValue = "16";
                    Session["Reject"] = "";
                    ddlStatus.Enabled = false;
                    ddlStatus_SelectedIndexChanged(sender, e);
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }


    void FillDetails()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Gen.GetdataofApprovaldataAprovalbyID_plotallotment(Request.QueryString[0].ToString(), Session["User_Code"].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_UIDNO.Text = ds.Tables[0].Rows[0]["UIDNo"].ToString().Trim();
                lbl_nameofapplicant.Text = ds.Tables[0].Rows[0]["NameOftheFirm_Applicant"].ToString().Trim();
                lbl_district.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString().Trim();
                lbl_industrialpark.Text = ds.Tables[0].Rows[0]["IndustrialParkId"].ToString().Trim();
                hf_approvalid.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                hf_deptid.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                hf_intQuessionaireid.Value = ds.Tables[0].Rows[0]["ApplicationId"].ToString();
            }
        }
        catch (Exception ex)
        {
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
            if (ddlStatus.SelectedValue.ToString().Trim() == "16")
            {
                Remarks.Visible = true;
                lbl_titleheaduploadcertificate.Text = "Upload Document";
            }
            else
            {
                Remarks.Visible = false;
                lbl_titleheaduploadcertificate.Text = "Upload Certificate";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btn_uploafdile_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            string newPath = "";
            string sFileDir = Server.MapPath("~\\PlotAllotmentAttachments");

            cls_plotallotmentadmin t1 = new cls_plotallotmentadmin();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            if (ddlStatus.SelectedValue == "16")
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PlotallotmentRejectedDocuments\\" + hf_deptid.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));
                            }
                            else
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ApprovalDocument\\" + hf_deptid.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));
                            }

                            // Create the subfolder
                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            int result = 0;
                            if (ddlStatus.SelectedValue == "16")
                            {
                                result = t1.InsertImagedataApproval_plotallotment(hf_intQuessionaireid.Value,fileType[i - 1].ToUpper(), newPath, sFileName, "PlotallotmentRejectedDocuments",Session["uid"].ToString(),hf_deptid.Value,hf_approvalid.Value);
                            }
                            else
                            {
                                result = t1.InsertImagedataApproval_plotallotment(hf_intQuessionaireid.Value,fileType[i - 1].ToUpper(), newPath, sFileName, "ApprovalDocument",Session["uid"].ToString(),hf_deptid.Value, hf_approvalid.Value);
                            }

                            if (result > 0)
                            {
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                lblFileName.Text = FileUpload1.FileName;
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
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
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
        catch (Exception ex)
        {
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

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            lblmsg.Text = "";
            if (BtnSave1.Text == "Submit")
            {
                int i = 0;
                if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
                {
                    if (lblFileName.Text.Trim() != "")
                    {
                        i = Gen.insertApprovalData_plotallotment(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hf_approvalid.Value, hf_deptid.Value, txtremarks.Text, getclientIP());
                        try
                        {
                            int k = Gen.InsertDeptDateTracing_plotallotment(hf_deptid.Value.Trim(), hf_intQuessionaireid.Value.Trim(), lbl_UIDNO.Text.Trim(), null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "PlotAllotment", hf_approvalid.Value);
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
                else
                {
                    if (txtremarks.Text != "")
                    {
                        i = Gen.insertApprovalData_plotallotment(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hf_approvalid.Value, hf_deptid.Value, txtremarks.Text, getclientIP());
                        int k = Gen.InsertDeptDateTracing_plotallotment(hf_deptid.Value, hf_intQuessionaireid.Value, lbl_UIDNO.Text, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "PlotAllotment", hf_approvalid.Value);
                       
                    }
                    else
                    {
                        lblmsg0.Text = "Please Enter Reason For Rejection..";
                        success.Visible = false;
                        Failure.Visible = true;
                        return;
                    }
                }
                if (i != 999)
                {
                    DataSet dsMail1 = new DataSet();
                    dsMail1 = Gen.GetShowEmailidandMobileNumber_plotallotment(hf_intQuessionaireid.Value.ToString());
                    if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
                    {
                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNO.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNO.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                        }
                        txtGeo_Cordinate_Latitude.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";
                        lblmsg.Text = "Status Updated Successfully";
                        Response.Redirect("frmDepartementDashboardNew.aspx");
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                    else
                    {
                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNO.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {                         
                            cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + lbl_nameofapplicant.Text + " - (" + lbl_UIDNO.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        }
                        txtGeo_Cordinate_Latitude.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";
                        lblmsg.Text = "Status Updated Successfully";
                        Response.Redirect("frmDepartementPlotAllotmentDashboard.aspx");
                        
                       
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
                GetTESTVALUES(message, lbl_UIDNO.Text.Trim(), mobileNo, hf_intQuessionaireid.Value.ToString(), hf_deptid.Value.ToString(), hf_approvalid.Value);
            }
            catch (Exception ex)
            {

            }
        }
        return responseFromServer.Trim();
    }



   
}