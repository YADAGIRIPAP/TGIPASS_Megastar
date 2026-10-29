using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public partial class PDCHouseholdAttendance : System.Web.UI.Page
{

    //designing and developed by siva as on 27-02-2016

    //Purpose : To update Wages Payement Details
    //Tables used :tr_BenWagesPayment, tr_BenAttendanceDet
    //Stored procedures Used : GetWorkProgressforWages,InsUpdBeneficiaryWages


    General Gen = new General();
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (!IsPostBack)
        {

            ddlyear.Items.Add(System.DateTime.Now.Year.ToString());
        }


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            

            
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            
            BtnSave1.Text = "Update";
        }

    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();


        ds = Gen.GetWorkProgressforWages(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblProject.Text = ds.Tables[0].Rows[0]["PrjName"].ToString();
            lblWorkCode.Text = ds.Tables[0].Rows[0]["workcode"].ToString();
            lblWorkActivity.Text = ds.Tables[0].Rows[0]["WorkActivity"].ToString();
            
            lblBoma.Text = ds.Tables[0].Rows[0]["BomaName"].ToString();
            lblWorkStartDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["WorkStartDate"].ToString()).ToString("dd-MM-yyyy");

            
            //lblCost.Text = ds.Tables[0].Rows[0]["EstCost"].ToString();

            //DataSet dsBen = new DataSet();
            //dsBen = Gen.GetWorkwiseBenDet(hdfID.Value.ToString());
            //if (dsBen.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = dsBen.Tables[0];
            //    grdDetails.DataBind();
            //}

            //DataSet dsnew = Gen.workProgressBendet(hdfID.Value.ToString());
            //if (dsnew.Tables[1].Rows.Count > 0)
            //{
            //    txtStartDate.Text = Convert.ToDateTime(dsnew.Tables[1].Rows[0]["WorkStartDate"].ToString()).ToString("dd-MM-yyyy");
            //    ddlStatus.SelectedValue = ddlStatus.Items.FindByValue(dsnew.Tables[1].Rows[0]["Status"].ToString()).Value;
            //    txtRemarks.Text = dsnew.Tables[1].Rows[0]["Remarks"].ToString();
            //}

        }
    }    



    protected void BtnSave_Click(object sender, EventArgs e)
    {
        



        int count = 0;
        for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
        {
            CheckBox c = (CheckBox)grdDetails.Rows[iii].Cells[0].FindControl("CheckBox1");


            if (c.Checked == true)
            {
                count++;
            }
            else
            {
            }
        }
        if (count == 0)
        {
            lblmsg0.Text = "At lease one Household should be selected";
            Failure.Visible = true;
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", lblmsg0.Text, true);
            return;

        }        
       
            for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
            {
                GridViewRow row = (GridViewRow)grdDetails.Rows[iii];
                TextBox txtAmt = (TextBox)grdDetails.Rows[iii].Cells[0].FindControl("txtAmt");
                CheckBox c = (CheckBox)grdDetails.Rows[iii].Cells[0].FindControl("CheckBox1");
                if (c.Checked == true && c.Enabled == true)
                {
                    if (txtAmt.Text!="")
                    {



                        int s = Gen.InsUpdBeneficiaryWages(grdDetails.DataKeys[iii].Value.ToString(), ddlyear.SelectedValue, ddlMonth.SelectedValue, txtStartDate.Text, txtAmt.Text, Session["uid"].ToString());

                        if (s == 999)
                        {
                            lblmsg0.Text = "Already Exist. ";
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                        //else
                        //{
                        //    lblmsg.Text = "Submited Successfully..!";
                        //    success.Visible = true;
                        //    Failure.Visible = false;
                        //}
                    }
                }                
            }


            lblmsg.Text = "Submited Successfully..!";
            success.Visible = true;
            Failure.Visible = false;
            clear();
       
    }

    void clear()
    {
        BtnSave1.Text = "Submit";
        txtStartDate.Text = "";
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        ddlMonth.SelectedIndex = 0;
        ddlyear.SelectedIndex = 0;

        lblProject.Text = "";
        lblWorkCode.Text = "";
        lblWorkActivity.Text = "";
        //lblTarget.Text = "";
        lblBoma.Text = "";
        lblWorkStartDate.Text = "";

        //lblEndDate.Text = "";
        lblCost.Text = "";

    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            string Amt="";
            CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("CheckBox1");
            TextBox txtAmt = (TextBox)e.Row.Cells[0].FindControl("txtAmt");

            DataSet dsnew = Gen.GetBenPaidAmt(Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "intBenid")).ToString(), ddlyear.SelectedValue, ddlMonth.SelectedValue);

            if (dsnew.Tables[0].Rows.Count > 0)
            {
                e.Row.Cells[11].Text = dsnew.Tables[0].Rows[0]["Amt"].ToString();
                if (e.Row.Cells[11].Text == "")
                {
                    e.Row.Cells[11].Text = "0";
                }
            }
            else
            {
                e.Row.Cells[11].Text = "0";
                //Amt = "0";
            }
            

            txtAmt.Text = Convert.ToString(Convert.ToDecimal(e.Row.Cells[10].Text) - Convert.ToDecimal(e.Row.Cells[11].Text)); // Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amt")).ToString();

            if (txtAmt.Text == "0.00")
            {
                txtAmt.Enabled = false;
            }
            else
            {
                txtAmt.Enabled = true;
            }
        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {


        if (cmf.convertDateIndia(txtStartDate.Text) < cmf.convertDateIndia(lblWorkStartDate.Text))
        {
            lblmsg0.Text = "Work Start Date should be greater than the paid date. ";
            success.Visible = false;
            Failure.Visible = true;

            return;

        }

        if (cmf.convertDateIndia(txtStartDate.Text) > cmf.convertDateIndia(System.DateTime.Now.ToString("dd-MM-yyyy")))
        {
            lblmsg0.Text = "Paid date should be less than the current date.";
            success.Visible = false;
            Failure.Visible = true;
            return;

        }
        

        DataSet ds = new DataSet();
        ds = Gen.getAttendanceCount(hdfID.Value.ToString(), ddlyear.SelectedValue, ddlMonth.SelectedValue);

        if (ds.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = ds.Tables[0];
            grdDetails.DataBind();
        }
        else
        {
            grdDetails.DataSource = null;
            grdDetails.DataBind();
        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
        Response.Redirect("PDCHouseholdWages.aspx");
    }
}
