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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

public partial class UI_TSIPASS_frmHelpdescrptDrill : System.Web.UI.Page
{

    DB.DB con = new DB.DB();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    #region Declaration
    General clsGeneral = new General();
    comFunctions fssFunctions = new comFunctions();
    General cmn = new General();
    /// <summary>
    ///Begin  Created By Ravi Chandra on 14-05-2012 at 12.20PM For Help Desk Declaration 
    /// </summary>
    string mobPIA = String.Empty;
    /// <summary>
    ///End  Created By Ravi Chandra on 14-05-2012 at 12.20PM For Help Desk Declaration
    /// </summary>
    string piaid = String.Empty;
    string trCode = String.Empty;
    string mppia = String.Empty;
    DataSet ds;
    string user;
    DataView dv;
    string userid;
    /// <summary>
    /// Created By Srikanht for Restriction
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 


    string usertype = "", userid1 = "";
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Label1.Text = "Report from 1st April to " + System.DateTime.Now.ToString("dd-MMM-yyyy");

            // getdistricts();
            //if (Session["uid"] != null)
            //{
            //    if (Session["uid"] == "1238")
            //    {
            //        fillgrid();
            //    }
            //}
            if (Session["uid"] != null)
            {
                lblHeading.Text = Session["uid"].ToString();
            }
            
            if (Session["userlevel"] != null)
            {
                if (Session["userlevel"].ToString() == "2")
                {
                    fillgrid();
                }
                else if (Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "359104" || Session["uid"].ToString() == "359030")
                {                    
                    fillgrid();
                }
                else
                {
                    Response.Redirect("~/tsHome.aspx");
                }
            }

        }
    }

    #region BtnSave
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Button btn1 = (Button)sender;
        GridViewRow row = (GridViewRow)btn1.NamingContainer;

        DropDownList ddlchStatus = (DropDownList)row.FindControl("ddlchStatus");
        TextBox txtremarks = (TextBox)row.FindControl("txtremarks");
        string int_fbid = row.Cells[1].Text;
        string Modified_by = Session["uid"].ToString();
        string Created_by = Session["uid"].ToString();
        FileUpload fupReply = (FileUpload)row.FindControl("fupReply");
        Label lblCreatedby = (Label)row.FindControl("lblCreatedby");
        string Filepath = "", Filename = "";
        DropDownList ddltypeprob = (DropDownList)row.FindControl("ddltypeprob");
        if (txtremarks.Text == "")
        {
            Failure.Visible = true;
            lblmsg0.Text = "Please enter the Remarks";
            return;
        }
        if (fupReply.HasFile)
        {
            string sFileDir = ConfigurationManager.AppSettings["HelpdeskfilePath"];
            if ((fupReply.PostedFile != null) && (fupReply.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fupReply.PostedFile.FileName);
                string targetPath = "";
                try
                {
                    string[] fileType = fupReply.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                  //  if (fileType[i - 1].ToUpper().Trim() == "PDF")
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")

                        {

                            string num = int_fbid;

                        targetPath = System.IO.Path.Combine(sFileDir, lblCreatedby.Text
                               + "/" + num + "");

                        if (!Directory.Exists(targetPath))

                            System.IO.Directory.CreateDirectory(targetPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(targetPath);

                        fupReply.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                        Filename = fupReply.PostedFile.FileName;
                        Filepath = targetPath + "\\" + sFileName;
                        int count = dir.GetFiles().Length;

                        Session["newPath"] = targetPath;
                        if (count == 1)
                            fupReply.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                        else
                        {
                            if (count == 2)
                            {
                                string[] Files = Directory.GetFiles(targetPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fupReply.PostedFile.SaveAs(targetPath + "\\" + sFileName);
                            }
                        }
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }

                }
                catch (Exception)//in case of an error
                {

                    Exception ex;
                    DeleteFile(targetPath + "\\" + sFileName);
                }
            }
        }
        // string Remarks;

        //      int returnValue = cmn.ForwardComplaint( ddlchStatus.SelectedValue.Trim(), remarks);
        //int returnValue = cmn.ChangestatusapproveNew(int_fbid, ddlchStatus.SelectedValue.ToString().Trim(), txtremarks.Text, Modified_by, getclientIP(), Session["user_id"].ToString().Trim(), ddltypeprob.SelectedValue.ToString().Trim(), Session["user_id"].ToString().Trim());
       int returnValue = ChangestatusapproveNew(int_fbid, ddlchStatus.SelectedValue.ToString().Trim(), txtremarks.Text, Modified_by, getclientIP(), Session["user_id"].ToString().Trim(), ddltypeprob.SelectedValue.ToString().Trim(), Session["user_id"].ToString().Trim(), Filepath, Filename);

        cmn.AddToTrans(int_fbid, ddlchStatus.SelectedValue.ToString(), txtremarks.Text, Created_by);
        fillgrid();
        DataSet dsdet = new DataSet();
        dsdet = cmn.GetHelpDespDetbyid(int_fbid.Trim());
        if (dsdet.Tables[0].Rows.Count > 0)
        {

            string newhdCode = dsdet.Tables[0].Rows[0]["hd_Code"].ToString();
            string txtemail = dsdet.Tables[0].Rows[0]["anothermailid"].ToString();
            //string Label57 = dsdet.Tables[0].Rows[0]["piaName"].ToString();
            string Label57 = "";
            string Label58 = dsdet.Tables[0].Rows[0]["hd_Username"].ToString();
            string ddlfeedback = dsdet.Tables[0].Rows[0]["Fb_Type"].ToString();
            string txtsubjet = dsdet.Tables[0].Rows[0]["hd_desc"].ToString();
            if (!string.IsNullOrEmpty(dsdet.Tables[0].Rows[0]["Up_Remarks"].ToString()))
            {
                string Remarksdet = dsdet.Tables[0].Rows[0]["Up_Remarks"].ToString();
            }
            else
            {
                string Remarksdet = dsdet.Tables[0].Rows[0]["Remarks"].ToString();
            }
            string statusdet = ddlchStatus.SelectedItem.Text;
            //  SendMail(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, Remarksdet, statusdet);
            // SendMailKishore(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, Remarksdet, statusdet);
            //SendMailSekhar(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, Remarksdet, statusdet);

            //  SendMailSri(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, Remarksdet, statusdet);
            if (txtemail != "")
                SendMailAnother(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, txtremarks.Text, txtemail.Trim(), statusdet);
            // SendMailAnother(newhdCode, Label57, Label58, ddlfeedback, txtsubjet, Remarksdet, txtemail.Trim(), statusdet);

        }
    }
    public int ChangestatusapproveNew(string int_fbid, string Status, string Remarks, string Modified_by, string IPAddress, string Updby, string TypeofProblem, string up_by, string Filepath, string Filename)
    {
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "[sp_Updatehelpdesk_New]";

        if (int_fbid.Trim() == "" || int_fbid.Trim() == null)
            com.Parameters.Add("@int_fbid", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@int_fbid", SqlDbType.Int).Value = int_fbid.Trim();

        if (Status.Trim() == "" || Status.Trim() == null)
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status.Trim();

        if (Remarks.Trim() == "" || Remarks.Trim() == null)
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Remarks.Trim();

        if (Modified_by.Trim() == "" || Modified_by.Trim() == null)
            com.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Modified_by.Trim();

        if (IPAddress.Trim() == "" || IPAddress.Trim() == null)
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = IPAddress.Trim();

        if (Updby.Trim() == "" || Updby.Trim() == null)
            com.Parameters.Add("@Updby", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Updby", SqlDbType.VarChar).Value = Updby.Trim();

        if (TypeofProblem.Trim() == "" || TypeofProblem.Trim() == null)
            com.Parameters.Add("@TypeofProblem", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TypeofProblem", SqlDbType.VarChar).Value = TypeofProblem.Trim();

        if (up_by.Trim() == "" || up_by.Trim() == null)
            com.Parameters.Add("@up_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@up_by", SqlDbType.VarChar).Value = up_by.Trim();
        if (Filename.Trim() == "" || Filename.Trim() == null)
            com.Parameters.Add("@Filename", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Filename", SqlDbType.VarChar).Value = Filename.Trim();
        if (Filepath.Trim() == "" || Filepath.Trim() == null)
            com.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Filepath", SqlDbType.VarChar).Value = Filepath.Trim();

        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            return com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            con.CloseConnection();
            throw ex;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
    #endregion

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
    void clear()
    {




    }

    public void SendMailAnother(string numbers, string Label57, string Label58, string ddlfeedback, string txtsubjet, string Remarksdet, string txtemail, string statusdet)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = txtemail.Trim(); //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("kcsbabu@yahoo.com");
        //mail.bCC.Add("nikhil.hyd21@gmail.com");

        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS - MIS ::", System.Text.Encoding.UTF8);
        mail.Subject = "Re: TSiPASS TSiPASS  - MIS Help Desk Registration Status From Commissionerate of Industries,TS-iPASS Cell.," + Label57;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "<H2>Re: TSiPASS TSiPASS - MIS Help Desk Registration Status</H2><br><br>From : Commissionerate of Industries,TS-iPASS Cell.,  <br> <br>  <br><br> USER NAME: " + Label58 + "<br> Feed Back Type: " + ddlfeedback + " <br><br> Status: " + statusdet + " <br> <br> Our  Comments : " + txtsubjet + " <br> <br> Remarks : " + Remarksdet + " <br><br> Help Desk Our Reference Number is <b>" + numbers + "</b> <br> <br>";
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        //object a = (byte[])Session["File"];
        //mail.Attachments.Add(new Attachment(new MemoryStream((byte[])Session["letterUpload"]), Session["letterUploadFileName"].ToString()));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        //client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");
      //  client.Credentials = new System.Net.NetworkCredential(from, "zwcq vlxk gyor lpeg");
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (Session["uid"].ToString() == "350398"|| Session["uid"].ToString() == "350396")
        {
            e.Row.Cells[13].Visible = false;
        }
            if (e.Row.RowType == DataControlRowType.Header)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Header");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            AssignGridRowStyle(e.Row, "GridviewScrollC1Item");
            e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[0].CssClass = "text-center";

            HyperLink HyperLink2 = (HyperLink)e.Row.FindControl("HyperLink2");
            if (HyperLink2.NavigateUrl == "")
            {
                HyperLink2.Visible = false;
            }
            else
            {
                HyperLink2.Visible = true;
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Button BtnSave = (Button)e.Row.FindControl("BtnSave");
            ////Begin Created By Srikanth on 18-5-2012 
            //BtnSave.Attributes.Add("onclick", DisableTheButton(this.Page, BtnSave, "group"));
            ////Begin Created By Srikanth on 18-5-2012 
            HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter");
            //h2.NavigateUrl = "HDDocsDL.aspx?type=2&id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "int_fbid"));
            string hyperLnk = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "hd_uplddocname"));
            string Rhwt = e.Row.Height.ToString();
            //if (h2.HasAttributes)
            HyperLink h3 = (HyperLink)e.Row.FindControl("hprlink");
            //h2.NavigateUrl = "HDDocsDL.aspx?type=2&id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "int_fbid"));
            // string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FilePath"));
            HiddenField Hdfpswd = (HiddenField)e.Row.FindControl("Hdfpswd");
            HiddenField HdfEncryflag = (HiddenField)e.Row.FindControl("HdfEncryflag");
            Label lblpswd = (Label)e.Row.FindControl("lblpswd");
            if (HdfEncryflag.Value == "Y")
                lblpswd.Text = Gen.Decrypt(Hdfpswd.Value, "SYSTIME");
            else
                lblpswd.Text = Hdfpswd.Value;

            string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
            if (filepathnew != "")
            {
                string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                h3.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
            }
            else
            {
                h3.Visible = false;
            }


            if (hyperLnk != "")
            {
                h2.Text = "View";
                h2.Visible = true;
                hyperLnk = "";
            }
            else if (filepathnew != "")
            {
                h3.Text = "View";
                h3.Visible = true;
                h2.Visible = false;
                filepathnew = "";
            }
            else
            {
                h2.Visible = false;
                h3.Visible = false;
            }
            //            h2.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "hd_uplddocname"));
        }
    }

    private void AssignGridRowStyle(GridViewRow gr, string cssName)
    {
        try
        {
            if (gr.RowType == DataControlRowType.Header)
            {
                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++) gr.Cells[cellIndex].CssClass = "GridviewScrollC1Header";
            }
            else
            {
                gr.CssClass = cssName;

                for (int cellIndex = 0; cellIndex < gr.Cells.Count; cellIndex++)
                {
                    gr.Cells[cellIndex].CssClass = cssName;

                    try
                    {
                        double d;
                        if (Double.TryParse(gr.Cells[cellIndex].Text, out d)) gr.Cells[cellIndex].CssClass = "algnRight";
                    }
                    catch (Exception) { }
                }
            }
        }
        catch (Exception) { }
    }

    public void fillgrid()
    {
        DataSet ds = new DataSet();
        string DistrictID = Request.QueryString[0].ToString().Trim();
        string status = Request.QueryString[1].ToString().Trim();
        txtFromDate.Text = Request.QueryString[2].ToString().Trim();
        txtTodate.Text = Request.QueryString[3].ToString().Trim();
        string FromdateforDB = "", TodateforDB = "";
        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
        {
            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
        }


        ds = Gen.RetriveStatushelpdeskhistory(status, DistrictID, FromdateforDB, TodateforDB);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
            grdExport.DataSource = ds.Tables[0];
            ViewState["grdExport"] = ds.Tables[0];
            grdExport.DataBind();
            grdDetails.Visible = true;
            grdExport.Visible = false;

            Label1.Text = "Report from " + txtFromDate.Text.Trim() + " To " + txtTodate.Text.Trim();
            int rowscount = ds.Tables[0].Rows.Count;
            if (status == "1" && DistrictID == "1012")
            {
                lblHeading.Text = "Total Applications Pending - Change Request (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "1007")
            {
                lblHeading.Text = "Total Applications Pending - Data Correction (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "1008")
            {
                lblHeading.Text = "Total Applications Pending - Data Deletion (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "1011")
            {
                lblHeading.Text = "Total Applications Pending - New Requirement (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "1010")
            {
                lblHeading.Text = "Total Applications Pending - Others (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "1009")
            {
                lblHeading.Text = "Total Applications Pending - Technical Issue (" + rowscount.ToString() + ")";
            }
            else if (status == "1" && DistrictID == "%")
            {
                lblHeading.Text = "Total Applications Pending - All (" + rowscount.ToString() + ")";
            } // end
            if (status == "3" && DistrictID == "1012")
            {
                lblHeading.Text = "Total Applications Posted - Change Request (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "1007")
            {
                lblHeading.Text = "Total Applications Posted - Data Correction (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "1008")
            {
                lblHeading.Text = "Total Applications Posted - Data Deletion (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "1011")
            {
                lblHeading.Text = "Total Applications Posted - New Requirement (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "1010")
            {
                lblHeading.Text = "Total Applications Posted - Others (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "1009")
            {
                lblHeading.Text = "Total Applications Solved - Technical Issue (" + rowscount.ToString() + ")";
            }
            else if (status == "3" && DistrictID == "%")
            {
                lblHeading.Text = "Total Applications Solved - All (" + rowscount.ToString() + ")";
            }  // end
            if (status == "4" && DistrictID == "1012")
            {
                lblHeading.Text = "Total Applications Solved - Change Request (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "1007")
            {
                lblHeading.Text = "Total Applications Solved - Data Correction (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "1008")
            {
                lblHeading.Text = "Total Applications Solved - Data Deletion (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "1011")
            {
                lblHeading.Text = "Total Applications Solved - New Requirement (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "1010")
            {
                lblHeading.Text = "Total Applications Solved - Others (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "1009")
            {
                lblHeading.Text = "Total Applications Solved - Technical Issue (" + rowscount.ToString() + ")";
            }
            else if (status == "4" && DistrictID == "%")
            {
                lblHeading.Text = "Total Applications Solved - All (" + rowscount.ToString() + ")";
            } // end
            if (status == "5" && DistrictID == "1012")
            {
                lblHeading.Text = "Total Applications Pending - Change Request (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "1007")
            {
                lblHeading.Text = "Total Applications Pending - Data Correction (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "1008")
            {
                lblHeading.Text = "Total Applications Pending - Data Deletion (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "1011")
            {
                lblHeading.Text = "Total Applications Pending - New Requirement (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "1010")
            {
                lblHeading.Text = "Total Applications Pending - Others (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "1009")
            {
                lblHeading.Text = "Total Applications Pending - Technical Issue (" + rowscount.ToString() + ")";
            }
            else if (status == "5" && DistrictID == "%")
            {
                lblHeading.Text = "Total Applications Pending - All (" + rowscount.ToString() + ")";
            }
            if (status == "6" && DistrictID == "1012")
            {
                lblHeading.Text = "Total Applications Under Proccess - Change Request (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "1007")
            {
                lblHeading.Text = "Total Applications Under Procces - Data Correction (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "1008")
            {
                lblHeading.Text = "Total Applications Under Procces - Data Deletion (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "1011")
            {
                lblHeading.Text = "Total Applications Under Procces - New Requirement (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "1010")
            {
                lblHeading.Text = "Total Applications Under Procces - Others (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "1009")
            {
                lblHeading.Text = "Total Applications Pending - Technical Issue (" + rowscount.ToString() + ")";
            }
            else if (status == "6" && DistrictID == "%")
            {
                lblHeading.Text = "Total Applications Under Procces - All (" + rowscount.ToString() + ")";
            } // end

            if (DistrictID != "%")
            {
                grdDetails.Columns[5].Visible = false;
                grdDetails.Columns[8].Visible = false;
                grdDetails.Columns[9].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[12].Visible = false;
            }
            if ((status == "3" || status == "4" || status == "2"))
            {
                grdDetails.Columns[9].Visible = true;
                grdDetails.Columns[11].Visible = true;
                grdDetails.Columns[12].Visible = false;
                grdDetails.Columns[13].Visible = false;
            }
            if (status == "6")
            {
                grdDetails.Columns[9].Visible = true;
                grdDetails.Columns[10].Visible = true;
                grdDetails.Columns[12].Visible = false;
                grdDetails.Columns[11].Visible = false;
                grdDetails.Columns[13].Visible = true;
            }
        }
        else
        {
            Label1.Text = "No Records Found ";
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
        HyperLink1.NavigateUrl = "frmHelpdescrpt.aspx";
    }

    //protected void ExportToExcel()
    //{
    //    try
    //    {

    //        string FromdateforDB = "", TodateforDB = "";
    //        if (txtFromDate.Text != "" && txtFromDate.Text.Contains('-'))
    //        {
    //            FromdateforDB = Convert.ToString(DateTime.ParseExact(txtFromDate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //            TodateforDB = Convert.ToString(DateTime.ParseExact(txtTodate.Text, "dd-MM-yyyy", null).ToString("MM-dd-yyyy"));
    //        }
    //        Response.Clear();
    //        Response.Buffer = true;

    //        string FileName = lblHeading.Text;
    //        FileName = FileName.Replace(" ", "");
    //        Response.AddHeader("content-disposition", "attachment;filename=" + FileName + DateTime.Now.ToString("M/d/yyyy") + ".xls");

    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.ms-excel";
    //        using (StringWriter sw = new StringWriter())
    //        {
    //            DataSet ds = new DataSet();
    //            string status = Request.QueryString[1].ToString().Trim();
    //            string type = Request.QueryString[4].ToString().Trim();
    //            string fromdate = Request.QueryString[2].ToString().Trim();
    //            string todate = Request.QueryString[3].ToString().Trim();

    //            if (Session["DistrictID"].ToString().Trim() != "")
    //            {
    //                ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), Session["DistrictID"].ToString().Trim(), FromdateforDB, TodateforDB);
    //            }
    //            else
    //            {
    //                ds = Gen.RetriveStatusByTypeDistrictNew(status, type, "%", Request.QueryString[0].ToString().Trim(), "%", FromdateforDB, TodateforDB);
    //            }

    //            ds.Tables[0].Columns.Remove("DOA");
    //            HtmlTextWriter hw = new HtmlTextWriter(sw);
    //            grdExport.DataSource = ds.Tables[0];
    //            grdExport.DataBind();
    //            grdExport.RenderControl(hw);
    //            string label1text = Label1.Text;
    //            string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='10'><h4>" + lblHeading.Text + "</h4></td></td></tr><tr><td align='center' colspan='10'><h4>" + label1text + "</h4></td></td></tr></table>";
    //            HttpContext.Current.Response.Write(headerTable);

    //            Response.Output.Write(sw.ToString());
    //            Response.Flush();
    //            Response.End();
    //        }
    //    }
    //    catch (Exception e)
    //    {

    //    }
    //}



    public void ExportToExcel(string controlName)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition ", "attachment;filename= " + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView gv = (GridView)(pnl_Data.FindControl(controlName));
                gv.RenderControl(hw);
                //Response.Output.Write(lblHeader.Text);
                // Response.Output.WriteLine(LblRs.Text);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (grdExport.Rows.Count > 0)
        {
            grdExport.Visible = true;
            ExportToExcel("grdExport");
        }
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    protected void PrintPdf()
    {
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    //trLogo.Visible = true;
                    grdDetails.AllowPaging = false;
                    this.fillgrid();
                    grdDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.FooterRow.ForeColor = System.Drawing.Color.Black;
                    grdDetails.Columns[1].Visible = false;
                    grdDetails.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename= Grievance.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        catch (Exception e)
        {

        }
    }
    //protected void BtnSave2_Click1(object sender, EventArgs e)
    //{
    //    ExportToExcel();
    //}

    protected void BtnPDF_Click(object sender, EventArgs e)
    {
        PrintPdf();
    }
}