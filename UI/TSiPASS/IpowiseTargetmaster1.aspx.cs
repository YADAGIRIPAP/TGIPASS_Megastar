using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddPayams : System.Web.UI.Page
{
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {

        
        
        
       

        //btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }

        if (!IsPostBack)
        {
            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            }

            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlmonth.SelectedIndex = DateTime.Now.Month;
            getIPOS();
        }

        //FillDetails();
       // hdfFlagID.Value = "";
        
            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {
                Failure.Visible = false;
                success.Visible = false;
                FillDetails();
                hdfFlagID.Value = "";
            }
        }
        //    if (Session["userlevel"].ToString() == "1")
        //    {
        //        BtnCancel.Visible = true;
        //    }
        //    else
        //    {
        //        BtnCancel.Visible = false;
        //    }
        //    BtnSave1.Text = "Update";
        //}
    

    protected void getIPOS()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIPOS(Session["uid"].ToString());

        ddlIPOname.DataSource = dsnew.Tables[0];
        ddlIPOname.DataTextField = "Dept_Name";
        ddlIPOname.DataValueField = "intUserid";
        ddlIPOname.DataBind();
        ddlIPOname.Items.Insert(0, "--Select--");
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }


    public void FillDetails()
    {
        DataSet dsemp = new DataSet();

        dsemp = Gen.getGMtoIPOTarget(hdfID.Value);

        if (dsemp.Tables[0].Rows.Count > 0)
        {
            txttarget.Text = dsemp.Tables[0].Rows[0]["Target"].ToString();
            ddlmonth.SelectedValue = ddlmonth.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Month"].ToString().Trim()).Value;
            ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Year"].ToString()).Value;
            getIPOS();
            ddlIPOname.SelectedValue = ddlIPOname.Items.FindByValue(dsemp.Tables[0].Rows[0]["intIPOid"].ToString()).Value;

            ddltarget2.SelectedValue = ddltarget2.Items.FindByValue(dsemp.Tables[0].Rows[0]["intFormid"].ToString()).Value;
            BtnSave1.Text = "Update";
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {
                lblmsg.Text = "";

                DataSet ds = new DataSet();
                ds = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), ddlIPOname.SelectedValue.ToString(), ddltarget2.SelectedValue.ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }



                int i = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), ddlIPOname.SelectedValue, ddltarget2.SelectedValue, ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                txttarget.Text, Session["uid"].ToString());
                if (i > 0)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }
            }

            if (BtnSave1.Text == "Update")
            {
                lblmsg.Text = "";

                int i = Gen.updateGMtoIPOTarget(Session["uid"].ToString(), ddlIPOname.SelectedValue, ddltarget2.SelectedValue, ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                txttarget.Text, Session["uid"].ToString(), hdfID.Value);
                if (i > 0)
                {

                    lblmsg.Text = "Updated Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }
            }


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    }
    

    void clear()
    {
        ddlIPOname.SelectedIndex = 0;
        ddltarget2.SelectedIndex = 0;
        ddlmonth.SelectedIndex = 0;
        ddlYear.SelectedIndex = 0;
        txttarget.Text = "";
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
       // Response.Redirect("AddPayams.aspx");
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  getcounties();
    }
    void getcounties()
    {
        //ddlmonth.Items.Clear();
       
        //if (ddlIPOname.SelectedIndex != 0)
        //{
        //    Gen.getCounties(ddlmonth, ddlIPOname.SelectedValue);
        //}
        //else
        //{
        //    ddlmonth.Items.Insert(0, "--Select--");
            

        //}
    }
    protected void txtMSName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        //int i = Gen.deletePayams(hdfID.Value);

        //if (i == 1)
        //{
        //    lblmsg.Text = "Deleted Successfully.";
        //    success.Visible = true;
        //    Failure.Visible = false;
        //    clear();
        //}
        //else if (i == 3)
        //{
        //    lblmsg0.Text = "Not Possible.";
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    clear();
        //}
        //else
        //{
        //    lblmsg0.Text = "Please contact to Administrator.";
        //    success.Visible = false;
        //    Failure.Visible = true;
            clear();
        //}
    }
}
