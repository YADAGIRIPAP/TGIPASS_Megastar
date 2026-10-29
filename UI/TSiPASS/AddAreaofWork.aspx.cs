using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//designing and developed by siva as on 4-12-2015
//Purpose : To Add Type of Work Details
//Tables used : 
public partial class AddQualiication : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
            if (Session.Count <= 0)
            {
                Response.Redirect("../../frmUserLogin.aspx");
            }

            if (!IsPostBack)
            {

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
            hdfFlagID.Value = "1";
            DataSet ds = new DataSet();


            ds = Gen.getAreaofWorkbyID(hdfID.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {


                txtarea.Text = ds.Tables[0].Rows[0]["AreaofWork"].ToString();



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
            Gen.AreaofWork = txtarea.Text;





            System.Threading.Thread.Sleep(5000);

            if (BtnSave1.Text == "Save")
            {
                int i = Gen.insrtAreaofWork("0", Session["uid"].ToString());
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
                int i = Gen.insrtAreaofWork(hdfID.Value, Session["uid"].ToString());

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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
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
        txtarea.Text = "";


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddAreaofWork.aspx");
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        try
        {
            int i = Gen.deleteAreaofWork(hdfID.Value);

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
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}
