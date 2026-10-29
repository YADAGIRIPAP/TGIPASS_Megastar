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
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

public partial class UI_TSiPASS_frmFeedBackChangestatus : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    string intGrievanceid;
    string Grivance_File_Path, Grivance_File_Type, Grievnace_FileName;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (Request.QueryString["intGrievanceid"] != "")
        {
            intGrievanceid = Request.QueryString["intGrievanceid"].ToString();

            if (!IsPostBack)
            {

                //DataSet ds = Gen.fetchgrievancedet("%", "%", "%", Session["User_Code"].ToString(), intGrievanceid, "%", "%");
                DataSet ds = Gen.fetch_FeedbackQuerydet("%", "%", "%", "%", intGrievanceid, "%", "%", "F");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LblInd.Text = ds.Tables[0].Rows[0]["IndustryName"].ToString();
                    LblDist.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                    lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    LblMob.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    //lblSub.Text = ds.Tables[0].Rows[0]["Grivance_Subject"].ToString();
                    LblDesc.Text = ds.Tables[0].Rows[0]["Grievance_Description"].ToString();
                    lblgreivancedate.Text = ds.Tables[0].Rows[0]["Created_dt"].ToString();
                    if (Request.QueryString.Count > 1)
                    {
                        Lblstatus1.Visible = false;
                        Labelcolun1.Visible = false;
                        ddlstatus.Visible = false;
                        LblRemarks.Visible = false;
                        Labelcolun2.Visible = false;
                        TxtRemarks.Visible = false;
                        Lblforward.Visible = true;
                        Labelcolun3.Visible = true;
                        ddlforward.Visible = true;
                        ReqfvStatus.Visible = false;
                        reqfvRemarks.Visible = false;
                    }
                    else
                    {
                        Lblstatus1.Visible = true;
                        Labelcolun1.Visible = true;
                        ddlstatus.Visible = true;
                        LblRemarks.Visible = true;
                        Labelcolun2.Visible = true;
                        TxtRemarks.Visible = true;
                        Lblforward.Visible = false;
                        Labelcolun3.Visible = false;
                        ddlforward.Visible = false;
                        ReqfvStatus.Visible = true;
                        reqfvRemarks.Visible = true;
                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "Closed with Reply" || ds.Tables[0].Rows[0]["Status"].ToString() == "Closed without Reply")
                        {
                            // ddlstatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                            ddlstatus.Enabled = false;
                            BtnSave.Enabled = false;
                            BtnClear.Enabled = false;
                            TxtRemarks.Enabled = false;
                        }
                        else
                        {
                            if (Session["userlevel"].ToString() == "10")
                            {
                                if (ds.Tables[0].Rows[0]["ForwardTo"].ToString() != "1213")
                                {
                                    // ddlstatus.SelectedIndex = 0;
                                    Tr1.Visible = true;
                                    ddlstatus.Enabled = true;
                                    BtnSave.Enabled = true;
                                    BtnClear.Enabled = true;
                                    TxtRemarks.Enabled = true;
                                }
                            }
                            else if (Session["userlevel"].ToString() == "1")
                            {
                                //ddlstatus.SelectedIndex = 0;
                                ddlstatus.Enabled = true;
                                BtnSave.Enabled = true;
                                BtnClear.Enabled = true;
                                TxtRemarks.Enabled = true;
                                Tr1.Visible = true;
                            }
                        }
                    }

                    FetchGrievStatus();
                    if (!Directory.Exists(ds.Tables[0].Rows[0]["Grivance_File_Path"].ToString()))
                    {
                        HyperLinkGriev.Text = "No Attachment";
                    }
                    else
                    {
                        string sen, sen1, sen2;
                        sen2 = ds.Tables[0].Rows[0]["Grivance_File_Path"].ToString();
                        sen1 = sen2.Replace(@"\", @"/");
                        sen1 = sen1 + "/" + ds.Tables[0].Rows[0]["Grievnace_FileName"].ToString();
                        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                        HyperLinkGriev.NavigateUrl = sen;
                        HyperLinkGriev.Text = ds.Tables[0].Rows[0]["Grievnace_FileName"].ToString();
                    }
                }
            }
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //ddlstatus.SelectedIndex = 0;
        TxtRemarks.Text = "";
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void FetchGrievStatus()
    {
        DataSet ds = Gen.FetchGrievStatus(intGrievanceid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblprevstatus.Visible = true;
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            lblprevstatus.Visible = false;
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString.Count < 1)
        {
            if (ddlstatus.SelectedValue.ToString() == "--Select--")
            {
                lblMsg.Text = "Please Select Status";
                return;
            }
        }

        //////////////
        string FileNameofrMail = "";
        Grivance_File_Path = "";
        Grivance_File_Type = "";
        Grievnace_FileName = "";
        //////////////
        //int j = Gen.InsGrevience(txtindname.Text.Trim(),ddldept.SelectedValue.ToString(),txtEmail.Text.Trim(),txtMob.Text.Trim(),ddldist.SelectedValue,txtSub.Text.Trim(),txtDesc.Text.Trim(),"", "","", Session["uid"].ToString());
        // Create the subfolder
        string newPath = "";
        string sFileDir = Server.MapPath("~\\GeneralFeedBack");

        General t1 = new General();
        if (FileUpload.HasFile)
        {
            if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, "1000");
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                        //////////////
                        Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                        Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                        Grievnace_FileName = sFileName;
                        //////////////
                        FileNameofrMail = Grivance_File_Path + "\\" + Grievnace_FileName;
                        if (!Directory.Exists(Grivance_File_Path))

                            System.IO.Directory.CreateDirectory(Grivance_File_Path);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(Grivance_File_Path);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                            }
                        }

                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        int j;
        if (Request.QueryString.Count > 1)
        {
            j = Gen.InsGrievStaus(intGrievanceid, ddlstatus.SelectedValue.ToString(), TxtRemarks.Text, Session["uid"].ToString(), ddlforward.SelectedValue, Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, "");
        }
        else
        {
            j = Gen.InsGrievStaus(intGrievanceid, ddlstatus.SelectedValue.ToString(), TxtRemarks.Text, Session["uid"].ToString(), "", Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, "");
        }
        lblMsg.Text = "Submitted Successfully..!";
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Submitted Successfully..!');", true);
        if (ddlstatus.SelectedItem.Text == "Closed with Reply" || ddlstatus.SelectedItem.Text == "Closed without Reply")
        {
            string body = @"<div>
                            Dear " + LblInd.Text + "," + @"
                            <br/><br />
                            FeedBack " + ddlstatus.SelectedItem.Text + " . <br/>Remarks " + TxtRemarks.Text + "<br/><br/>" + "TS-iPASS Cell,<br/>" + "Commissinerate of Industries," + " <br/> " + "Chirag-ali-lane, Abids, Hyderabad." + "<br/>" + "Phone:040-23441636" + "<br/>" + "Email id : asstdir.sw.inds@telangana.gov.in" + "<br/></div>";

            // SendEmail1(txtEmail.Text.Trim(), "tsipass.telangana@gmail.com", body, lblHead1.Text);

            string msgs = "Dear " + LblInd.Text + "\r\n" + "FeedBack " + ddlstatus.SelectedItem.Text + ". Remarks " + TxtRemarks.Text;
            try
            {
                SendMailAnother(lblEmail.Text.Trim(), body, FileNameofrMail);
            }
            catch (Exception ex)
            {

            }
            try
            {
                cmf.SendSingleSMS(LblMob.Text, msgs);
            }
            catch (Exception ex)
            {

            }
        }

        // ddlstatus.SelectedIndex = 0;
        TxtRemarks.Text = "";
        FetchGrievStatus();

        Response.Redirect("DeptFeedBackStatusDetails.aspx");
    }
    public void SendMailAnother(string anothermail, string body, string FilePath)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("kcsbabu@gmail.com");
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

        mail.Subject = "TSiPASS";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = body;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Attachments.Add(new Attachment(FilePath));
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

       // client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
        //client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
        client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

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
    protected void btnforward_Click(object sender, EventArgs e)
    {
        string FileNameofrMail = "";
        Grivance_File_Path = "";
        Grivance_File_Type = "";
        Grievnace_FileName = "";
        //////////////
        //int j = Gen.InsGrevience(txtindname.Text.Trim(),ddldept.SelectedValue.ToString(),txtEmail.Text.Trim(),txtMob.Text.Trim(),ddldist.SelectedValue,txtSub.Text.Trim(),txtDesc.Text.Trim(),"", "","", Session["uid"].ToString());
        // Create the subfolder
        string newPath = "";
        string sFileDir = Server.MapPath("~\\GeneralFeedBack");

        General t1 = new General();
        if (FileUpload.HasFile)
        {
            if ((FileUpload.PostedFile != null) && (FileUpload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUpload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        //newPath = System.IO.Path.Combine(sFileDir, "1000");
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                        //////////////
                        Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                        Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                        Grievnace_FileName = sFileName;
                        //////////////
                        FileNameofrMail = Grivance_File_Path + "\\" + Grievnace_FileName;
                        if (!Directory.Exists(Grivance_File_Path))

                            System.IO.Directory.CreateDirectory(Grivance_File_Path);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Grivance_File_Path);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(Grivance_File_Path);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload.PostedFile.SaveAs(Grivance_File_Path + "\\" + Grievnace_FileName);
                            }
                        }

                    }
                    else
                    {
                        lblMsg.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                        //success.Visible = false;
                        //Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        int j;
        j = Gen.InsGrievStaus(intGrievanceid, ddlstatus.SelectedValue.ToString(), TxtRemarks.Text, Session["uid"].ToString(), ddlforward.SelectedValue, Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, "");
        TxtRemarks.Text = "";
        FetchGrievStatus();

        Response.Redirect("DeptFeedBackStatusDetails.aspx");
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedValue == "Forward")
        {
            Lblstatus1.Visible = false;
            Labelcolun1.Visible = false;
            ddlstatus.Visible = false;
            LblRemarks.Visible = false;
            Labelcolun2.Visible = false;
            TxtRemarks.Visible = false;
            Lblforward.Visible = true;
            Labelcolun3.Visible = true;
            ddlforward.Visible = true;
            ReqfvStatus.Visible = false;
            reqfvRemarks.Visible = false;
            btnforward.Visible = true;
            BtnSave.Visible = false;
            trreplyfile.Visible = false;
            trreplyremarks.Visible = false;
        }
        if (ddlstatus.SelectedValue == "Closed with Reply")
        {
            Lblstatus1.Visible = true;
            Labelcolun1.Visible = true;
            ddlstatus.Visible = true;
            LblRemarks.Visible = true;
            Labelcolun2.Visible = true;
            TxtRemarks.Visible = true;
            Lblforward.Visible = false;
            Labelcolun3.Visible = false;
            ddlforward.Visible = false;
            ReqfvStatus.Visible = true;
            reqfvRemarks.Visible = true;
            btnforward.Visible = false;
            BtnSave.Visible = true;
            trreplyfile.Visible = true;
            trreplyremarks.Visible = true;
        }
        if (ddlstatus.SelectedValue == "Closed without Reply")
        {
            Lblstatus1.Visible = true;
            Labelcolun1.Visible = true;
            ddlstatus.Visible = true;
            LblRemarks.Visible = true;
            Labelcolun2.Visible = true;
            TxtRemarks.Visible = true;
            Lblforward.Visible = false;
            Labelcolun3.Visible = false;
            ddlforward.Visible = false;
            ReqfvStatus.Visible = true;
            reqfvRemarks.Visible = true;
            btnforward.Visible = false;
            BtnSave.Visible = true;
            trreplyfile.Visible = false;
            trreplyremarks.Visible = false;
        }
    }
}