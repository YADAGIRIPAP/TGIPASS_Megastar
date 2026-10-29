using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//designing and developed by suresh as on 12-1-2016
//Purpose : To Add Implementaion Patner Details
//Tables used : td_IPDetails
//Stored procedures Used :getIPbyID,deleteIP,insrtIP


public partial class TSTIPregistration : System.Web.UI.Page
{
    General Gen = new General();

    protected void Page_Load(object sender, EventArgs e)
    {
 



        
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            //  Gen.getStates(ddlState);

            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "3")
            {
                BtnDelete.Visible = false;
            }
            else
            {
                BtnDelete.Visible = false;
            }
            BtnSave1.Text = "Update";
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "3")
            {
                BtnDelete.Visible = false;
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
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.getIPbyID(Session["User_Code"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {


            txtip.Text = ds.Tables[0].Rows[0]["IPName"].ToString();
            ddltypeip.SelectedValue = ddltypeip.Items.FindByValue(ds.Tables[0].Rows[0]["TypeofIP"].ToString()).Value;
            txtauthorised.Text = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
            txtmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();         
            txtcontact1.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            txtauthorised0.Text = ds.Tables[0].Rows[0]["SecondaryContactNo"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            txtweb.Text = ds.Tables[0].Rows[0]["Website"].ToString();
            txtauthorised0.Text = ds.Tables[0].Rows[0]["SecondaryAuthorisedPerson"].ToString();

            txtScontact.Text = ds.Tables[0].Rows[0]["SPerson"].ToString();
            txtSEmail.Text = ds.Tables[0].Rows[0]["SEmail"].ToString();
            //txtuser.Text = ds.Tables[1].Rows[0]["User_id"].ToString();
            //txtuser.Enabled = false;
            //txtpass.Enabled = false;
            //txtpass.TextMode = TextBoxMode.SingleLine;
            //txtpass.Text = "*****"; //ds.Tables[2].Rows[0]["Password"].ToString();
            
           // txtuser.Enabled = false;
            //txtpass.Enabled = false;

            BtnDelete.Visible = false;


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

       


        Gen.IPName = txtip.Text;
        Gen.TypeofIP = ddltypeip.SelectedValue;
        Gen.AuthorisedPerson = txtauthorised.Text;
        Gen.ContactNo = txtcontact1.Text;
        Gen.SecondaryContactNo = txtauthorised0.Text;
        Gen.Email = txtmail.Text;
        Gen.Address = txtaddress.Text;
        Gen.Website = txtweb.Text;

        


        System.Threading.Thread.Sleep(5000);

        //int i = Gen.insrtIP("0", Session["uid"].ToString(), txtuser.Text, txtpass.Text, Session["User_Code"].ToString());
        int i = Gen.insrtIP(Session["User_Code"].ToString(), Session["uid"].ToString(), "", "", Session["User_Code"].ToString(), txtScontact.Text, txtSEmail.Text);

            if (i != 999)
            {
                lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                //clear();
                FillDetails();
            }
            else
            {
                lblmsg0.Text = "Already Exist. ";
                success.Visible = false;
                Failure.Visible = true;
                //lblmsg.Text = "Added Successfully..!";
            }
        
    }
    void clear()
    {
        BtnSave1.Text = "Save";
        BtnDelete.Visible = false;


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
        //txtcontact2.Text = "";
        txtcontact1.Text = "";
        txtaddress.Text = "";
        txtweb.Text = "";
        
       
        
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("IPDetails.aspx");
    }
}
