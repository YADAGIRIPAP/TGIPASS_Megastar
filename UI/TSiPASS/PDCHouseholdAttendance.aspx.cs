using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class PDCHouseholdAttendance : System.Web.UI.Page
{

    //designing and developed by siva as on 27-02-2016

    //Purpose : To update Attendance Details
    //Tables used : tr_BenAttendanceDet,tbl_BeneficiaryDet
    //Stored procedures Used : BenefeciaryAttendance,GetWorkwiseBenDet


    comFunctions cmf = new comFunctions();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
        if (!IsPostBack)
        {
            
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

            DataSet dsBen = new DataSet();
            dsBen = Gen.GetWorkwiseBenDet(hdfID.Value.ToString());
            if (dsBen.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsBen.Tables[0];
                grdDetails.DataBind();
            }

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

        if (cmf.convertDateIndia(txtStartDate.Text) < cmf.convertDateIndia(lblWorkStartDate.Text))
        {
            lblmsg0.Text = "Attendance Date should be greater than the Work Start date. ";
            success.Visible = false;
            Failure.Visible = true;

            return;

        }

        if (cmf.convertDateIndia(txtStartDate.Text) > cmf.convertDateIndia(System.DateTime.Now.ToString("dd-MM-yyyy")))
        {
            lblmsg0.Text = "Attendance date should be less than the current date.";
            success.Visible = false;
            Failure.Visible = true;
            return;

        }



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
                DropDownList ddlStatus = (DropDownList)grdDetails.Rows[iii].Cells[0].FindControl("ddlStatus");
                CheckBox c = (CheckBox)grdDetails.Rows[iii].Cells[0].FindControl("CheckBox1");
                if (c.Checked == true && c.Enabled == true)
                {
                    if (ddlStatus.SelectedValue != "--Select--")
                    {

                        

                        int s = Gen.BenefeciaryAttendance(hdfID.Value.ToString(), grdDetails.DataKeys[iii].Value.ToString(), ddlStatus.SelectedValue,txtStartDate.Text, Session["uid"].ToString());

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
    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            CheckBox chk = (CheckBox)e.Row.Cells[0].FindControl("CheckBox1");
            //DataSet dsnew = Gen.workProgressBendet(hdfID.Value.ToString());
            //int n = dsnew.Tables[0].Rows.Count;
            //for (int r = 0; r < n; r++)
            //{
            //    if (grdDetails.DataKeys[e.Row.RowIndex].Values[0].ToString() == dsnew.Tables[0].Rows[r]["intBenid"].ToString().Trim())
            //    {

            //        chk.Checked = true;
            //        chk.Enabled = false;
            //        //BtnBatchsave.Visible = true;
            //    }
            //    else
            //    {
            //        //BtnBatchsave.Visible= false;
            //    }
            //}
        }
    }
}
