using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
//designing and developed by suresh as on 12-1-2016
//Purpose : To Add TST Details
//Tables used : td_TstTeamDet
//Stored procedures Used : sp_getStates,sp_getCounties,sp_getPayams,getTSTbyID,deleteTST,insrtTST,sp_Designations


public partial class CheckPOITD : System.Web.UI.Page
{
    General Gen = new General();
    byte[] Photo = new byte[1];
    string PhotoFileName = "";
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("../../frmUserLogin.aspx");
        //}
        try
        {
            if (!IsPostBack)
            {
                divbtn.Visible = true;
                GetDepartment();
                getdistricts();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void GetDepartment()
    {
        try
        {
            DataSet dsd = new DataSet();

            dsd = Gen.GetDepartmentFullName();
            ddlDepartment.DataSource = dsd.Tables[0];
            ddlDepartment.DataValueField = "Dept_Id";
            ddlDepartment.DataTextField = "Dept_Full_name";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void getdistricts()
    {
        try
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDistricts();
            ddlDistrict.DataSource = dsnew.Tables[0];
            ddlDistrict.DataTextField = "District_Name";
            ddlDistrict.DataValueField = "District_Id";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlDistrict.SelectedIndex == 0)
            {
                ddlMandal.Items.Clear();
                ddlMandal.Items.Insert(0, "--Select--");

            }
            else
            {
                ddlMandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlDistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlMandal.DataSource = dsm.Tables[0];
                    ddlMandal.DataValueField = "Mandal_Id";
                    ddlMandal.DataTextField = "Manda_lName";
                    ddlMandal.DataBind();
                    ddlMandal.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlMandal.Items.Clear();
                    ddlMandal.Items.Insert(0, "--Select--");
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
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        try
        {
            lblmsg.Text = "";


            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckUserid2(txtname2.Text.Trim());
            //
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtname2.Text = "";
                lblmsg.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";
                success.Visible = true;
                Failure.Visible = false;

                return;
                // txtRetypePassword.Text = "";
            }




            int i = Gen.AddnewInspectionUserRegistration(ddlDepartment.SelectedValue, txtDesignation.Text, ddlDistrict.SelectedValue, ddlMandal.SelectedValue,
                txtfirstname.Text, txtLastname.Text, txtaddress.Text, txtemail.Text, txtAadhaar.Text, txtcontact.Text, txtname2.Text, txtpasswordnew.Text);



            if (i != 999)
            {

                string msgs = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br> you are successfully registered.<br><br> User Id : " + txtname2.Text + "<br><br> Password : " + txtpasswordnew.Text + "<br>";
                msgs = msgs + "<br><br><br>Thanks and Regards ,<br> Commissionerate of Industries,TS-iPASS Cell";

                string body = msgs;
                SendMailAnother(txtemail.Text);
                cmf.SendSingleSMS(txtcontact.Text, "Dear " + txtfirstname.Text + " " + txtLastname.Text + " TSiPASS MIS  - Login Credentials Welcome to TS-iPASS.  USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + " URL:  https://ipass.telangana.gov.in , Please Login by clicking the above link,Regards TSiPASS.");
                clear();


                Response.Redirect("FrmHDResultNew.aspx?Msg=User Registration Successfully Done");
                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;


            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    void clear()
    {

        try
        {
            txtfirstname.Text = "";
            txtLastname.Text = "";
            txtemail.Text = "";
            ddlDepartment.SelectedIndex = 0;
            txtaddress.Text = "";

            txtcontact.Text = "";
            txtname2.Text = "";
            txtpasswordnew.Text = "";
            txtcomparepwd.Text = "";
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewInspectionUser.aspx");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {


    }
    public void SendMailAnother(string anothermail)
    {

        try
        {
            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            //mail.CC.Add("fss.srikanth@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");

            mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);

            mail.Subject = "Inspection User -Login Credentials -";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Dear " + txtfirstname.Text + " " + txtLastname.Text + "<br><br>  <H2>TSiPASS MIS  - Login Credentials</H2><br> Welcome to TS-iPASS. <br/> Dear <b> NAME: " + txtfirstname.Text + " " + txtLastname.Text + "</b>,<br/> Please use the following credentials to Login. <br><br> USER ID: " + txtname2.Text + "<br> <br> Password : " + txtpasswordnew.Text + "<br> <br> URL:  <a href='https://ipass.telangana.gov.in' target='_blank' > TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Regards<br>TSiPASS MIS";
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            //client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");
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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckUserid2(txtname2.Text.Trim());
            //
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                txtname2.Text = "";
                lblmsg.Text = "<font color=red> User ID already Exists, Please specify another User ID </font>";

                success.Visible = true;
                Failure.Visible = false;
                //return;
                // txtRetypePassword.Text = "";
            }
            else
            {
                lblmsg.Text = "<font color=green> User ID Available </font>";

                success.Visible = true;
                Failure.Visible = false;

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    protected void btnRegister_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            tblRegister.Visible = true;
            divbtn.Visible = false;
            tblRegister1.Visible = true;
            tblRegister2.Visible = true;
            lblHeading.Text = "Inspecting Official-Registration";
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}
