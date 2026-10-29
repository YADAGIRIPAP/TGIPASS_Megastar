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

public partial class UI_TSiPASS_GuestGeneralQuery : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string Grivance_File_Path, Grivance_File_Type, Grievnace_FileName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}

        if (!IsPostBack)
        {
            getdistricts();
            GetDepartment();
            success.Visible = false;
            Failure.Visible = false;
            ddlRegisterAs_SelectedIndexChanged(sender, e);
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        txtindname.Text = "";
        ddldept.SelectedIndex = 0;
        txtEmail.Text = "";
        txtMob.Text = "";
        ddldist.SelectedIndex = 0;
        txtSub.Text = "";
        txtDesc.Text = "";
        BtnSave.Enabled = true;
        txtuidno.Text = "";
        txtuidno.Enabled = true;
        ddldist.Enabled = true;
        txtMob.Enabled = true;
        txtEmail.Enabled = true;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //////////////
        Grivance_File_Path = "";
        Grivance_File_Type = "";
        Grievnace_FileName = "";
        //////////////
        //int j = Gen.InsGrevience(txtindname.Text.Trim(),ddldept.SelectedValue.ToString(),txtEmail.Text.Trim(),txtMob.Text.Trim(),ddldist.SelectedValue,txtSub.Text.Trim(),txtDesc.Text.Trim(),"", "","", Session["uid"].ToString());
        // Create the subfolder
        string newPath = "";
        if (ddlRegisterAs.SelectedValue == "G")
        {
            if (txtuidno.Text == "")
            {
                lblmsg0.Text = "Please Enter UID Number";
                lblmsg0.Visible = true;
                return;
            }
        }


        string sFileDir = Server.MapPath("~\\Grievance");

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
                        if (Session.Count > 0)
                        {
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString());
                        }
                        else
                        {
                            newPath = System.IO.Path.Combine(sFileDir, "1000");
                        }
                        //////////////
                        Grivance_File_Path = newPath + System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                        Grivance_File_Type = fileType[i - 1].ToUpper().Trim();
                        Grievnace_FileName = sFileName;
                        //////////////

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
                        lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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

        //int j = Gen.InsGrevience(txtindname.Text.Trim(), ddldept.SelectedValue.ToString(), txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldist.SelectedValue, txtSub.Text.Trim(), txtDesc.Text.Trim(),Grivance_File_Path,Grivance_File_Type,Grievnace_FileName, "1000");
        int j = 0;
        if (Session.Count > 0)
        {
            j = Gen.InsGrevience(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(), txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, Session["uid"].ToString(), ddlRegisterAs.SelectedValue, txtuidno.Text.Trim(),"0",null);
        }
        else
        {
            j = Gen.InsGrevience(txtindname.Text.Trim(), ddldist.SelectedValue, txtEmail.Text.Trim(), txtMob.Text.Trim(), ddldept.SelectedValue.ToString(), txtSub.Text.Trim(), txtDesc.Text.Trim(), Grivance_File_Path, Grivance_File_Type, Grievnace_FileName, "", ddlRegisterAs.SelectedValue, txtuidno.Text.Trim(), "0", null);
        }


        string maildesc = txtindname.Text.Trim() + " Grievance is Submitted for the Department: " + ddldept.SelectedItem.Text.Trim() + "<br><br>With the Description: " + txtDesc.Text;
        string maildescnodalofficer = txtindname.Text.Trim() + " Grievance is Received for the UIDNO: " + txtuidno.Text.Trim() + "<br><br>With the Description: " + txtDesc.Text;

        // cmf.SendMailGriev(txtEmail.Text, maildesc);//commented by lavanya
        string maildept = "";
        string mailnodalofficer = "";
        if (Session.Count > 0)
        {
            maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: " + Session["username"].ToString() + "<br><br>With the Subject: " + txtSub.Text;
            maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>" + Session["username"].ToString() + "</b>";
        }
        else
        {
            maildept = txtindname.Text.Trim() + " Grievance is Submitted by Enterprenuer: Guest<br><br>With the Subject: " + txtSub.Text;
            maildept = maildept + "<br><br> Thanks and Regards ,<br><br><b>Guest</b>";
        }


        DataSet dsdept = Gen.GetDepartmentbyid(ddldept.SelectedValue.ToString());

        cmf.SendMailGriev("kcsbabu@yahoo.com", maildept);

        //lblmsg.Text = "Submited Successfully..!";
        //success.Visible = true;
        //Failure.Visible = false;
        //txtindname.Text = "";
        //ddldept.SelectedIndex = 0;
        //txtEmail.Text = "";
        //txtMob.Text = "";
        //ddldist.SelectedIndex = 0;
        //txtSub.Text = "";
        //txtDesc.Text = "";
        lblmsg.Text = "Submited Successfully..!";
        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Submitted Successfully..!');", true);
        success.Visible = true;
        Failure.Visible = false;
        int deptid = 0;
        if (ddldept.SelectedValue != "--Select--")
            deptid = Convert.ToInt32(ddldept.SelectedValue);
        DataSet dsdata = new DataSet();
        dsdata = Gen.GetGreivanceAck_Data(j, deptid);
        if (dsdata != null && dsdata.Tables.Count > 0 && dsdata.Tables[0].Rows.Count > 0)
        {
            string GreivanceNo = j.ToString();
            string msgs = "", body = "", msgsnodalofficer = "", bodynodalofficer = "";
            string Contact_Name = dsdata.Tables[0].Rows[0]["Contact_Name"].ToString();
            string DepartmentName = dsdata.Tables[0].Rows[0]["DepartmentName"].ToString();
            string MobileNo = dsdata.Tables[0].Rows[0]["MobileNo"].ToString();
            string EmailId = dsdata.Tables[0].Rows[0]["EmailId"].ToString();
            string Address1 = dsdata.Tables[0].Rows[0]["Address1"].ToString();
            string Address2 = dsdata.Tables[0].Rows[0]["Address2"].ToString();
            string Address3 = dsdata.Tables[0].Rows[0]["Address3"].ToString();
            string Address4 = dsdata.Tables[0].Rows[0]["Address4"].ToString();
            string Address5 = dsdata.Tables[0].Rows[0]["Address5"].ToString();
            if (ddlRegisterAs.SelectedValue == "G")
            {

                body = @"<div>
                            Dear " + txtindname.Text + "," + @"
                            <br/><br />
                            Grievance registered successfully with number " + GreivanceNo.ToString() + " .and will be addressed within 7 days. If not addressed within 7 days please contact Sri." + Contact_Name.ToString() + " ,TS-iPASS Nodal Officer, " + DepartmentName.ToString() + " Department, Mobile No." + MobileNo.ToString() + " , email id " + EmailId.ToString() + "<br/><br />" + Address1 + "<br>" + Address2 + "<br>" + Address3 + "<br>" + Address4 + "<br>" + Address5 + " </div>";

                // SendEmail1(txtEmail.Text.Trim(), "tsipass.telangana@gmail.com", body, lblHead1.Text);

                msgs = "Dear " + txtindname.Text + "\r\n" + "Grievance registered successfully with number " + GreivanceNo.ToString();

                bodynodalofficer = @"<div>
                            Dear " + Contact_Name + "," + @"
                            <br/><br />
                            Grievance registered successfully with number " + GreivanceNo.ToString() + " for UIDNO" + txtuidno.Text.Trim() + " .and have to address within 7 days.</div>";

                // SendEmail1(txtEmail.Text.Trim(), "tsipass.telangana@gmail.com", body, lblHead1.Text);

                msgsnodalofficer = "Dear " + Contact_Name + "\r\n" + "Grievance registered successfully with number " + GreivanceNo.ToString() + "for UIDNO " + txtuidno.Text.Trim() + " ," + txtindname.Text.Trim();

            }
            else if (ddlRegisterAs.SelectedValue == "F")
            {
                body = @"<div>
                            Dear " + txtindname.Text + "," + @"
                            <br/><br />
                            Feedback received successfully.<br><br>" + Address1 + "<br>" + Address2 + "<br>" + Address3 + "<br>" + Address4 + "<br>" + Address5 + " </div>";

                msgs = "Dear " + txtindname.Text + "\r\n" + "Feedback received successfully.";
            }
            else if (ddlRegisterAs.SelectedValue == "Q")
            {
                body = @"<div style='FontSize:12px'>
                            Dear " + txtindname.Text + "," + @"
                            <br/><br />
                            Query received successfully. Clarification will be sent to mail within in 3 days.<br><br>" + Address1 + "<br>" + Address2 + "<br>" + Address3 + "<br>" + Address4 + "<br>" + Address5 + " </div>";

                msgs = "Dear " + txtindname.Text + "\r\n" + "Query received successfully.";
            }
            // msgs = msgs + "\r\n" + "\r\n" + "Thanks and Regards ," + "\r\n" + "Commissionerate of Industries,TS-iPASS Cell";
            try
            {
                SendMailAnother(txtEmail.Text.Trim(), body);
                SendMailAnotherNodalOfficer(EmailId, bodynodalofficer);
            }
            catch (Exception ex)
            {

            }
            try
            {
                cmf.SendSingleSMS(txtMob.Text, msgs);
                cmf.SendSingleSMS(MobileNo, msgsnodalofficer);
            }
            catch (Exception ex)
            {

            }
            txtuidno.Text = "";
            txtindname.Text = "";
            txtEmail.Text = "";
            txtMob.Text = "";
            ddldist.SelectedIndex = 0;
            txtSub.Text = "";
            txtDesc.Text = "";
            ddldept.SelectedIndex = 0;
            ddlRegisterAs.SelectedIndex = 0;
            BtnSave.Enabled = false;
        }
        //clear();
    }
    public void SendMailAnother(string anothermail, string body)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("kcsbabu@gmail.com");
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

        mail.Subject = lblHead1.Text;// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = body;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
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

    public void SendMailAnotherNodalOfficer(string anothermail, string body)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("kcsbabu@gmail.com");
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

        mail.Subject = lblHead1.Text;// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = body;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        //client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");
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
    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetDistrictsbystate("%");
        ddldist.DataSource = dsnew.Tables[0];
        ddldist.DataTextField = "District_Name";
        ddldist.DataValueField = "District_Id";
        ddldist.DataBind();
        ddldist.Items.Insert(0, "--Select--");
    }
    protected void GetDepartment()
    {
        DataSet dsd = new DataSet();
        dsd = Gen.GetDepartment();
        ddldept.DataSource = dsd.Tables[0];
        ddldept.DataValueField = "Dept_Id";
        ddldept.DataTextField = "Dept_Full_name";
        ddldept.DataBind();
        ddldept.Items.Insert(0, "--Select--");
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


    protected void BtnUpload_Click(object sender, EventArgs e)
    {

    }
    protected void ddlRegisterAs_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSlno3.Text = "3";
        lblSlno4.Text = "4";
        lblSlno5.Text = "5";
        lblSlno6.Text = "6";
        lblSlno7.Text = "7";
        lblSlno8.Text = "8";

        //if (ddlRegisterAs.SelectedIndex <= 0)
        //{
        //    trData.Visible = false;
        //    trgrivenance.Visible = true;

        //}
        //else 
        if (ddlRegisterAs.SelectedValue == "G")
        {
            lblHead1.Text = "Grievance Registration";
            lblHead2.Text = "Grievance";
            Label558.Text = "Grievance Details";
            Label537.Text = "Industry Name";
            trSubject.Visible = true;
            TRdEPTnAME.Visible = true;
            trData.Visible = true;
            trgrivenance.Visible = false;
            LBLAVAIABLE.Visible = false;
            lblstar.Visible = true;
            lblindustar.Visible = true;

        }
        else if (ddlRegisterAs.SelectedValue == "F")
        {
            lblHead1.Text = "Feedback";
            lblHead2.Text = "Feedback";
            Label558.Text = "Feedback Details";
            Label537.Text = "Industry Name";
            trSubject.Visible = true;
            TRdEPTnAME.Visible = true;
            trData.Visible = true;
            trgrivenance.Visible = false;
            LBLAVAIABLE.Visible = true;
            lblstar.Visible = false;
            lblindustar.Visible = true;
        }
        else if (ddlRegisterAs.SelectedValue == "Q")
        {
            lblHead1.Text = "Query";
            lblHead2.Text = "General Query";
            Label558.Text = "General Query Details";
            Label537.Text = "Applicant Name";
            trSubject.Visible = false;
            TRdEPTnAME.Visible = false;
            trData.Visible = true;
            lblSlno3.Text = "2";
            lblSlno4.Text = "3";
            lblSlno5.Text = "4";
            //lblSlno6.Text = "2";
            lblSlno7.Text = "5";
            lblSlno8.Text = "6";
            trgrivenance.Visible = false;
            LBLAVAIABLE.Visible = true;
            lblstar.Visible = false;
            lblindustar.Visible = true;
        }
        else
        {
            Label537.Text = "Industry Name";
            trSubject.Visible = true;
            TRdEPTnAME.Visible = true;

        }
    }
    protected void txtuidno_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = Gen.GetUIDDataforGreivance(txtuidno.Text.Trim());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtuidno.Enabled = false;
                if (ds.Tables[0].Rows[0]["nameofunit"].ToString() != null)
                {
                    txtindname.Text = ds.Tables[0].Rows[0]["nameofunit"].ToString();
                    txtindname.Enabled = false;
                }
                if (ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != null)
                {
                    ddldist.SelectedValue = ds.Tables[0].Rows[0]["Prop_intDistrictid"].ToString();
                    ddldist.Enabled = false;
                }
                if (ds.Tables[0].Rows[0]["MobileNumber"].ToString() != null)
                {
                    txtMob.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                    txtMob.Enabled = false;
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != null)
                {
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtEmail.Enabled = false;
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ddldept.DataSource = ds.Tables[1];
                    ddldept.DataValueField = "Dept_Id";
                    ddldept.DataTextField = "Dept_Full_name";
                    ddldept.DataBind();
                    ddldept.Items.Insert(0, "--Select--");
                }
            }
            else
            {
                txtuidno.Enabled = true;
                ddldist.Enabled = true;
                txtMob.Enabled = true;
                txtEmail.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
        }
    }
}