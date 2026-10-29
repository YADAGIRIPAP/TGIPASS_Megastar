using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class UI_TSiPASS_Tourismevent_ApproveDetails : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
   //General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    byte[] SelfCert;
    string SelfCertFileName = "";
    static DataTable dtMyTableCertificate;
    string AttachmentFilepath = "", AttachmentFileName = "";
    static DataTable dtMyTable;
    string intEnterpreniourApprovalid = "", intQuessionaireid = "", intCFEEnterpid = "", intDeptid = "", intApprovalid = "", QueryRaiseDate = "", QueryDescription = "", QueryStatus = "", Created_by = "", Created_dt = "";

    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;

    string responseFromServer = "";
    Cls_TourismDashboard obj_dashboard = new Cls_TourismDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
                Response.Redirect("~/Index.aspx");
            }
            FillDetails();
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    FillDetails();
                }
            }
            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }
            if (!IsPostBack)
            {
                if (Session["Reject"] != null && Session["Reject"] == "Y")
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
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
                        i = obj_dashboard.tourismevent_insertApprovalData(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text, getclientIP());

                        try
                        {
                            int k = obj_dashboard.tourismevent_InsertDeptDateTracing(hdfFlagID2.Value.Trim(), hdfFlagID3.Value.Trim(), Label447.Text.Trim(), null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", hdfFlagID1.Value);
                        }
                        catch (Exception ex)
                        {

                        }
                        DataSet dscer = new DataSet();
                        dscer = obj_dashboard.tourismevent_GetStatusforCertificate(hdfFlagID3.Value);

                        if (dscer.Tables[0].Rows.Count > 0)
                        {
                            int result = 0;
                            result = obj_dashboard.tourismevent_UpdCommissionerApprovalNew(Request.QueryString[0].ToString(), hdfFlagID2.Value, hdfFlagID1.Value, "15", dscer.Tables[0].Rows[0]["LastDateofPreScrutiy"].ToString(), Session["uid"].ToString().Trim(), hdfFlagID3.Value);
                        }
                        else
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
                        i = obj_dashboard.tourismevent_insertApprovalData(Request.QueryString[0].ToString(), txtGeo_Cordinate_Latitude.Text, ddlStatus.SelectedValue.ToString(), Session["uid"].ToString(), hdfFlagID1.Value, hdfFlagID2.Value, txtremarks.Text, getclientIP());
                        int k =obj_dashboard.tourismevent_InsertDeptDateTracing(hdfFlagID2.Value, hdfFlagID3.Value, Label447.Text, null, null, null, null, System.DateTime.Now.ToString("MM/dd/yyyy"), "CFE", hdfFlagID1.Value);
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
                    //hdfFlagID2
                    //hdfFlagID3.Value
                    DataSet dsMail1 = new DataSet();
                    //dsMail1 = obj_dashboard.tourismevent_GetShowEmailidandMobileNumber(hdfFlagID3.Value.ToString(), hdfFlagID2.Value.ToString());
                    dsMail1 = obj_dashboard.tourismevent_GetShowEmailidandMobileNumber(hdfFlagID3.Value.ToString());
                    if (ddlStatus.SelectedItem.Text.Trim() == "Approved")
                    {

                        if (dsMail1.Tables[0].Rows.Count > 0)
                        {
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has issued an approval to your application.Please login to TS-iPASS to download your approval. Please click on this link " + '\n' + dsMail1.Tables[0].Rows[0]["LINK"].ToString().Trim() + '\n' + " to give feedback. Thank You.");
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
                            cmf.SendMailTSiPASS(dsMail1.Tables[0].Rows[0]["Email"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") :<br/><br/> <b>" + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.</b>");
                        }
                        if (dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim() != "")
                        {
                            cmf.SendSingleSMS(dsMail1.Tables[0].Rows[0]["MobileNo"].ToString().Trim(), "Dear " + Label448.Text + " - (" + Label447.Text + ") ," + dsMail1.Tables[0].Rows[0]["Dept_Name"].ToString().Trim() + " has " + ddlStatus.SelectedItem.Text.ToString() + " your application.Please login to TS-iPASS Appeal for Rejection. Thank You.");
                        }
                        txtGeo_Cordinate_Latitude.Text = "";
                        ddlStatus.SelectedIndex = 0;
                        txtremarks.Text = "";

                        lblmsg.Text = "Status Updated Successfully";
                        if (intDeptid != "11")
                        {
                            Response.Redirect("frmDepartementDashboardNew.aspx");
                        }
                        else
                        {
                            Response.Redirect("frmDepartementDashboardNewHmda.aspx");
                        }
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

    void FillDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            ds = obj_dashboard.tourismevent_GetdataofApprovaldataAprovalbyID(Request.QueryString[0].ToString(), Session["User_Code"].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label447.Text = ds.Tables[0].Rows[0]["UID_No"].ToString().Trim();
                Label448.Text = ds.Tables[0].Rows[0]["NameAddEventManagement"].ToString().Trim();
                Label449.Text = ds.Tables[0].Rows[0]["ClassificationofEvent"].ToString().Trim();
                Label450.Text = ds.Tables[0].Rows[0]["TypeofEvent"].ToString().Trim();
                if (Request.QueryString.Count < 2)
                {
                    hdfFlagID1.Value = ds.Tables[0].Rows[0]["intApprovalid"].ToString().Trim();
                    hdfFlagID2.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                    hdfFlagID3.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();
                }
                else
                {
                    if (Request.QueryString[1].ToString().Trim() == "1")
                    {
                        hdfFlagID1.Value = "6";
                    }
                    else
                    {
                        hdfFlagID1.Value = "35";
                    }
                    hdfFlagID2.Value = ds.Tables[0].Rows[0]["intDeptid"].ToString().Trim();
                    hdfFlagID3.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();

                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    // && ds.Tables[1].Rows.Count > 0
                    //hmdaattachements.Visible = true;
                    //gvlastattachments.DataSource = ds.Tables[1];
                    //gvlastattachments.DataBind();
                }
                else
                {
                    hmdaattachements.Visible = false;
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
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/Index.aspx");
            }
            string newPath = "";
            string sFileDir = Server.MapPath("~\\Attachments");

            Cls_TourismDashboard t1 = new Cls_TourismDashboard();
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    //determine file name
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
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\TourismEventRejectedDocumentS\\" + hdfFlagID2.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));
                            }
                            else
                            {
                                newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\ApprovalDocument\\" + hdfFlagID2.Value + System.DateTime.Now.ToString("ddMMyyyyHHmmtt"));
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
                                result = t1.Tourismevent_InsertImagedataApproval(hdfFlagID3.Value, Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TourismEventRejectedDocumentS", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID2.Value, hdfFlagID1.Value);
                            }
                            else
                            {
                                result = t1.Tourismevent_InsertImagedataApproval(hdfFlagID3.Value, Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "ApprovalDocument", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), hdfFlagID2.Value, hdfFlagID1.Value);
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
            }
        }
        catch (Exception ex)
        {
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
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStatus.SelectedValue.ToString().Trim() == "16")
            {
                Remarks.Visible = true;
                Label455.Text = "Upload Document";
            }
            else
            {
                Remarks.Visible = false;
                Label455.Text = "Upload Certificate";
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
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
                GetTESTVALUES(message, Label447.Text.Trim(), mobileNo, hdfFlagID3.Value.ToString(), hdfFlagID2.Value.ToString(), hdfFlagID1.Value);
            }
            catch (Exception ex)
            {

            }
        }
        return responseFromServer.Trim();
        // return "402,1,0";

    }







}