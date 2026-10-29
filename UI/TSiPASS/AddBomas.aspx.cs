using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//designing and developed by siva as on 28-11-2015

//Purpose : To Add Qualification Details
//Tables used : tm_Qualification
//Stored procedures Used : sp_getStates,sp_getCounties,sp_getPayams,getBomasbyID,deleteBomas,insrtUpdBomas
public partial class AddBomas : System.Web.UI.Page
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
            Gen.getStates(ddlState);
        }
       
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            if (Session["userlevel"].ToString() == "1")
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
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.getBomasbyID(hdfID.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlState.SelectedValue = ddlState.Items.FindByValue(ds.Tables[0].Rows[0]["intStateid"].ToString()).Value;
                getcounties();
                ddlCounties.SelectedValue = ddlCounties.Items.FindByValue(ds.Tables[0].Rows[0]["intCountieid"].ToString()).Value;
                getPayams();
                ddlPayams.SelectedValue = ddlPayams.Items.FindByValue(ds.Tables[0].Rows[0]["intPayamid"].ToString()).Value;
                txtBoma.Text = ds.Tables[0].Rows[0]["BomaName"].ToString();
                txtBomaCode.Text = ds.Tables[0].Rows[0]["BomaCode"].ToString();
                txtLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                txtLongitude.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();
                txtpopulation.Text = ds.Tables[0].Rows[0]["Population"].ToString();
            }
        }    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Gen.BomaCode = txtBomaCode.Text;
        Gen.intPayamid = ddlPayams.SelectedValue;
        Gen.BomaName = txtBoma.Text;
        Gen.Latitude = txtLatitude.Text;
        Gen.Longitude = txtLongitude.Text;
        Gen.BPopulation = txtpopulation.Text;
        

        System.Threading.Thread.Sleep(5000);

        if (BtnSave1.Text == "Save")
        {
            int i = Gen.insertBomas("0", Session["uid"].ToString());
            if (i != 999)
            {
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
            int i = Gen.insertBomas(hdfID.Value, Session["uid"].ToString());
            
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
    void clear()
    {
        BtnSave1.Text = "Save";
        BtnDelete.Visible = false;
        txtpopulation.Text = "";
        
        ddlState.SelectedIndex = 0;

        ddlCounties.Items.Clear();
        ddlCounties.Items.Insert(0, "--Select--");
        ddlCounties.SelectedIndex = 0;
        ddlPayams.Items.Clear();
        ddlPayams.Items.Insert(0, "--Select--");
        ddlPayams.SelectedIndex = 0;
        txtBomaCode.Text="";
        
         txtBoma.Text = "";
         txtLatitude.Text = "";
         txtLongitude.Text = "";
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBomas.aspx");        
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        int i = Gen.deleteBomas(hdfID.Value);

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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcounties();
    }
    void getcounties()
    {
        ddlCounties.Items.Clear();
        ddlPayams.Items.Clear();
        if (ddlState.SelectedIndex != 0)
        {
            Gen.getCounties(ddlCounties, ddlState.SelectedValue);
        }
        else
        {
            ddlCounties.Items.Insert(0, "--Select--");
            ddlPayams.Items.Insert(0, "--Select--");

        }
    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPayams();
    }
    void getPayams()
    {
        ddlPayams.Items.Clear();
        if (ddlCounties.SelectedIndex != 0)
        {
            Gen.getPayams(ddlPayams, ddlCounties.SelectedValue);
        }
        else
        {
            ddlPayams.Items.Insert(0, "--Select--");
        }
    }
}
