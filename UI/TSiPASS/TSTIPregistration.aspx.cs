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
//Purpose : To Add Implementaion Patner Details
//Tables used : td_IPDetails
//Stored procedures Used :getIPbyID,deleteIP,insrtIP


public partial class TSTIPregistration : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
 



        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            //  Gen.getStates(ddlState);
            if (Request.QueryString.Count > 0)
            {
                Failure.Visible = false;
                success.Visible = false;
                FillDetails();
                if (Session["userlevel"].ToString() == "3")
                {
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                BtnSave1.Text = "Update";
            }
            
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0" ))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "3")
            {
                BtnDelete.Visible = true;
            }
            else
            {
                BtnDelete.Visible = false;
            }
            BtnSave1.Text = "Update";
        }

    }

    void FillDetails()
    {
        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.getIPbyID(ids.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {


            txtip.Text = ds.Tables[0].Rows[0]["IPName"].ToString();
            ddltypeip.SelectedValue = ddltypeip.Items.FindByValue(ds.Tables[0].Rows[0]["TypeofIP"].ToString()).Value;
            txtauthorised.Text = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
            txtmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();         
            txtcontact1.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtauthorised0.Text = ds.Tables[0].Rows[0]["SecondaryContactNo"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtauthorised0.Text = ds.Tables[0].Rows[0]["SecondaryAuthorisedPerson"].ToString();

            txtScontact.Text = ds.Tables[0].Rows[0]["SPerson"].ToString();
            txtSEmail.Text = ds.Tables[0].Rows[0]["SEmail"].ToString();

            txtweb.Text = ds.Tables[0].Rows[0]["Website"].ToString();
            txtuser.Text = ds.Tables[1].Rows[0]["User_id"].ToString();
            txtuser.Enabled = false;
            txtpass.Enabled = false;
            txtpass.TextMode = TextBoxMode.SingleLine;
            txtpass.Text = "*****"; //ds.Tables[2].Rows[0]["Password"].ToString();
            
           // txtuser.Enabled = false;
            //txtpass.Enabled = false;
            



        }
    }    
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        int i = Gen.deleteIP(hdfID.Value);

        if (i == 1)
        {
            lblmsg.Text = "Deleted Successfully.";
            success.Visible = true;
            Failure.Visible = false;
            clear();
        }
        else if (i == 3)
        {
            lblmsg0.Text = "Not Possible.";
            success.Visible = false;
            Failure.Visible = true;
            clear();
        }
        else
        {
            lblmsg0.Text = "Please contact to Administrator.";
            success.Visible = false;
            Failure.Visible = true;
            clear();
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        string ids = "";
        if (Request.QueryString.Count > 0)
        {
            ids = Request.QueryString[0].ToString();
        }
        else
        {
            ids = hdfID.Value;
        }


        Gen.IPName = txtip.Text;
        Gen.TypeofIP = ddltypeip.SelectedValue;
        Gen.AuthorisedPerson = txtauthorised.Text;
        Gen.ContactNo = txtcontact1.Text;
        Gen.SecondaryContactNo = txtauthorised0.Text;
        Gen.Email = txtmail.Text;
        Gen.Address = txtaddress.Text;
        Gen.Website = txtweb.Text;
        Gen.SecondaryAuthorisedPerson = txtauthorised0.Text;

        


        System.Threading.Thread.Sleep(5000);

        if (BtnSave1.Text == "Save")
        {

            DataSet dsUser = new DataSet();
            dsUser = Gen.CheckUserid(txtuser.Text.Trim());
            //
            if (dsUser.Tables[0].Rows.Count > 0)
            {
                Failure.Visible = true;
                lblmsg0.Text = " User ID already Exists, Please specify another User ID.";
                txtuser.Text = "";
                txtpass.Text = "";
                return;
                // txtRetypePassword.Text = "";
            }



            int i = Gen.insrtIP("0", Session["uid"].ToString(), txtuser.Text, txtpass.Text, Session["User_Code"].ToString(), txtScontact.Text, txtSEmail.Text);
            if (i != 999)
            {
                SendMailAnother(txtmail.Text);


                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        else
        {
            int i = Gen.insrtIP(ids.ToString(), Session["uid"].ToString(), txtuser.Text, txtpass.Text, Session["User_Code"].ToString(), txtScontact.Text, txtSEmail.Text);

            if (i != 999)
            {
                lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
                //lblmsg.Text = "Added Successfully..!";
            }
        }
    }

    public void SendMailAnother(string anothermail)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = anothermail; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("fss.srikanth@gmail.com");
        mail.CC.Add("support@fruxsoft.com");

        mail.From = new MailAddress(from, ":: TSiPASS TSiPASS MIS ::", System.Text.Encoding.UTF8);

        mail.Subject = "TSiPASS TSiPASS MIS - IP Login Credentials -" + Session["user_id"].ToString();

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = "Dear " + txtip.Text + "<br><br>  <H2>TSiPASS TSiPASS MIS - IP Login Credentials</H2><br> <b> NAME: " + txtip.Text + "</b> <br><br> USER ID: " + txtuser.Text + "<br> <br> Password : " + txtpass.Text + "<br> <br> URL:  <a href=http://203.124.107.65/publicworks target='_blank' > TSiPASS TSiPASS </a> <br> <br> Please Login by clicking the above link.<br><br>Thanks & Regards<br>Commissionerate of Industries,TS-iPASS Cell. ";
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

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

    void clear()
    {
        BtnSave1.Text = "Save";
        BtnDelete.Visible = false;
        txtauthorised0.Text = "";
        txtScontact.Text = ""; txtSEmail.Text = "";
        //ddlState.SelectedIndex = 0;

        // ddlCounties.Items.Clear();
        // ddlCounties.Items.Insert(0, "--Select--");
        // ddlCounties.SelectedIndex = 0;
        // ddlPayams.Items.Clear();
        // ddlPayams.Items.Insert(0, "--Select--");
        // ddlPayams.SelectedIndex = 0;
        txtip.Text = "";
        ddltypeip.SelectedIndex = 0;
       // ddltypeip.Items.Insert(0, "--Select--");
        txtauthorised.Text = "";
        txtmail.Text = "";
        txtauthorised0.Text = "";
        txtcontact1.Text = "";
        txtaddress.Text = "";
        txtweb.Text = "";
        txtuser.Text = "";
        txtpass.Text = "";
        txtuser.Enabled = true;
        txtpass.Enabled = true;
       
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("TSTIPregistration.aspx");
    }
}
