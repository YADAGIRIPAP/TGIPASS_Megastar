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

        
        
        
       

        btnOrgLookup0.Attributes.Add("onclick", "javascript:return OpenPopup()");
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

                //DateTime.Now.Month;

            getIPOS();



            DataSet ds1 = Gen.getIPOTargetDetailslat(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), Session["uid"].ToString());

            if (ds1.Tables[0].Rows.Count > 0)
            {
                hdfID.Value = ds1.Tables[0].Rows[0]["intGMtoIPOid"].ToString();
                FillDetails();
                BtnSave1.Text = "Update";
                hdfID.Value = "";
            }
            else
            {
                hdfID.Value = "";
            }

        }

        //FillDetails();
       // hdfFlagID.Value = "";

        //DataSet ds1 = Gen.getIPOTargetDetailslat(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), Session["uid"].ToString());

        //if (ds1.Tables[0].Rows.Count > 0)
        //{
        //    hdfID.Value = ds1.Tables[0].Rows[0]["intGMtoIPOid"].ToString();
        //    FillDetails();
        //    BtnSave1.Text = "Update";
        //}
        //else
        //{
        //    hdfID.Value = "";
        //}



        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            hdfFlagID.Value = "";
        }
        else
        {
            hdfID.Value = "";
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

        if (dsnew.Tables[0].Rows.Count > 0)
        {
            gvCertificate0.DataSource = dsnew.Tables[0];
            gvCertificate0.DataBind();
           
        }

       // ddlIPOname.DataSource = dsnew.Tables[0];
      //  ddlIPOname.DataTextField = "Dept_Name";
       // ddlIPOname.DataValueField = "intUserid";
       // ddlIPOname.DataBind();
       // ddlIPOname.Items.Insert(0, "--Select--");


    
    }
    

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }


    public void FillDetails()
    {


        

        DataSet dsemp1 = new DataSet();

        dsemp1 = Gen.getGMtoIPOTarget1(hdfID.Value);

        if (dsemp1.Tables[0].Rows.Count > 0)
        {
            ddlmonth.SelectedIndex = Convert.ToInt32(dsemp1.Tables[0].Rows[0]["VI_Month"].ToString());
            ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsemp1.Tables[0].Rows[0]["VI_Year"].ToString()).Value;
            ddlmonth.Enabled = false;
            ddlYear.Enabled = false;

            DataSet dsemp = new DataSet();

            dsemp = Gen.GetIPOS(dsemp1.Tables[0].Rows[0]["intGMid"].ToString());

            if (dsemp.Tables[0].Rows.Count > 0)
            {

                gvCertificate0.DataSource = dsemp.Tables[0];
                gvCertificate0.DataBind();


                //    txttarget.Text = dsemp.Tables[0].Rows[0]["Target"].ToString();
                //    ddlmonth.SelectedValue = ddlmonth.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Month"].ToString().Trim()).Value;
                //    ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Year"].ToString()).Value;
                //    getIPOS();
                //    ddlIPOname.SelectedValue = ddlIPOname.Items.FindByValue(dsemp.Tables[0].Rows[0]["intIPOid"].ToString()).Value;

                //    ddltarget2.SelectedValue = ddltarget2.Items.FindByValue(dsemp.Tables[0].Rows[0]["intFormid"].ToString()).Value;
                //    BtnSave1.Text = "Update";
            }
        }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (BtnSave1.Text == "Save")
            {


                for (int m = 0; m < gvCertificate0.Rows.Count; m++)
                {

                    GridViewRow row = (GridViewRow)gvCertificate0.Rows[m];

                    //TextBox txttargetBanvisit1 = (TextBox)e.Row.Cells[2].FindControl("txttargetBanvisit1");

                    //TextBox txttargetBankvisit2 = (TextBox)e.Row.Cells[3].FindControl("txttargetBankvisit2");

                    //TextBox txttargetVehicleInsp = (TextBox)e.Row.Cells[4].FindControl("txttargetVehicleInsp");

                    //TextBox txttargetPMEGP = (TextBox)e.Row.Cells[5].FindControl("txttargetVehicleInsp");

                    //TextBox txttargetClosedUnits = (TextBox)e.Row.Cells[6].FindControl("txttargetClosedUnits");

                    //TextBox txttargetIndustryCatelog = (TextBox)e.Row.Cells[7].FindControl("txttargetIndustryCatelog");

                    //TextBox txttargetUnitInsp = (TextBox)e.Row.Cells[8].FindControl("txttargetUnitInsp");



                    TextBox txttargetBanvisit1 = (TextBox)row.FindControl("txttargetBanvisit1");
                    TextBox txttargetBankvisit2 = (TextBox)row.FindControl("txttargetBankvisit2");

                    TextBox txttargetVehicleInsp = (TextBox)row.FindControl("txttargetVehicleInsp");

                    TextBox txttargetPMEGP = (TextBox)row.FindControl("txttargetPMEGP");

                    TextBox txttargetClosedUnits = (TextBox)row.FindControl("txttargetClosedUnits");

                    TextBox txttargetIndustryCatelog = (TextBox)row.FindControl("txttargetIndustryCatelog");

                    TextBox txttargetUnitInsp = (TextBox)row.FindControl("txttargetUnitInsp");
                    
                   // DropDownList txtyearpassing = (DropDownList)row.FindControl("ddlPassingYear");
                   // TextBox txtMarks = (TextBox)row.FindControl("txtMarks");


                    HiddenField hdfVul = (HiddenField)row.FindControl("hdfVul");

                    if (txttargetBanvisit1.Text == "" || txttargetBanvisit1.Text == null)
                    {

                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    
                    else if (txttargetBankvisit2.Text == "" || txttargetBankvisit2.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetVehicleInsp.Text == "" || txttargetVehicleInsp.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;

                    }
                    else if (txttargetPMEGP.Text == "" || txttargetPMEGP.Text == null)
                    {

                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetClosedUnits.Text == "" || txttargetClosedUnits.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetIndustryCatelog.Text == "" || txttargetIndustryCatelog.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;

                    }
                    else if (txttargetUnitInsp.Text == "" || txttargetUnitInsp.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else
                    {

                        DataSet ds = new DataSet();
                        ds = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1000");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }


                        DataSet ds1 = new DataSet();
                        ds1 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1001");

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }



                        DataSet ds2 = new DataSet();
                        ds2 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1002");

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }



                        DataSet ds3 = new DataSet();
                        ds3 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1004");

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }


                        DataSet ds4 = new DataSet();
                        ds4 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1006");

                        if (ds4.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }


                        DataSet ds5 = new DataSet();
                        ds5 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1007");

                        if (ds5.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }


                        DataSet ds6 = new DataSet();
                        ds6 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1008");

                        if (ds5.Tables[0].Rows.Count > 0)
                        {
                            Failure.Visible = true;
                            success.Visible = false;
                            lblmsg0.Text = "Already  target Registered for this month of Year";
                            return;
                        }




                        int i = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1000", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetBanvisit1.Text, Session["uid"].ToString());

                        int a = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1001", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetBankvisit2.Text, Session["uid"].ToString());


                        int b = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1002", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetVehicleInsp.Text, Session["uid"].ToString());

                        int c = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1004", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetPMEGP.Text, Session["uid"].ToString());

                        int d = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1006", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetClosedUnits.Text, Session["uid"].ToString());

                        int f = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1007", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetIndustryCatelog.Text, Session["uid"].ToString());


                        int g = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1008", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                  txttargetUnitInsp.Text, Session["uid"].ToString());


                        

                    }


                   


                    //if (txtUniversity.Text.Trim() != "")
                    //{
                    //    //mem = txtNo.Text;
                    //    //mem = mem + 1;

                    //    //objUpperFloors.FloorNo = FloorNo;
                    //    cmn.savetraineeEducational(Convert.ToString(i), gvCertificate0.DataKeys[m].Value.ToString(), txtUniversity.Text, txtsub.Text, txtyearpassing.SelectedValue.ToString().Trim(), txtMarks.Text, Session["uid"].ToString(), hdfVul.Value);

                    //}



                }



                Response.Redirect("HomeIPOResult.aspx");
                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
         
                //clear();



                //int i = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), ddlIPOname.SelectedValue, ddltarget2.SelectedValue, ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
               // txttarget.Text, Session["uid"].ToString());
               
            }

            if (BtnSave1.Text == "Update")
            {
                lblmsg.Text = "";


                int del = Gen.DeleteGMtargetbyId(Session["uid"].ToString(), ddlYear.SelectedValue, ddlmonth.SelectedIndex.ToString());

                for (int m = 0; m < gvCertificate0.Rows.Count; m++)
                {

                    GridViewRow row = (GridViewRow)gvCertificate0.Rows[m];

                    //TextBox txttargetBanvisit1 = (TextBox)e.Row.Cells[2].FindControl("txttargetBanvisit1");

                    //TextBox txttargetBankvisit2 = (TextBox)e.Row.Cells[3].FindControl("txttargetBankvisit2");

                    //TextBox txttargetVehicleInsp = (TextBox)e.Row.Cells[4].FindControl("txttargetVehicleInsp");

                    //TextBox txttargetPMEGP = (TextBox)e.Row.Cells[5].FindControl("txttargetVehicleInsp");

                    //TextBox txttargetClosedUnits = (TextBox)e.Row.Cells[6].FindControl("txttargetClosedUnits");

                    //TextBox txttargetIndustryCatelog = (TextBox)e.Row.Cells[7].FindControl("txttargetIndustryCatelog");

                    //TextBox txttargetUnitInsp = (TextBox)e.Row.Cells[8].FindControl("txttargetUnitInsp");



                    TextBox txttargetBanvisit1 = (TextBox)row.FindControl("txttargetBanvisit1");
                    TextBox txttargetBankvisit2 = (TextBox)row.FindControl("txttargetBankvisit2");

                    TextBox txttargetVehicleInsp = (TextBox)row.FindControl("txttargetVehicleInsp");

                    TextBox txttargetPMEGP = (TextBox)row.FindControl("txttargetPMEGP");

                    TextBox txttargetClosedUnits = (TextBox)row.FindControl("txttargetClosedUnits");

                    TextBox txttargetIndustryCatelog = (TextBox)row.FindControl("txttargetIndustryCatelog");

                    TextBox txttargetUnitInsp = (TextBox)row.FindControl("txttargetUnitInsp");

                    // DropDownList txtyearpassing = (DropDownList)row.FindControl("ddlPassingYear");
                    // TextBox txtMarks = (TextBox)row.FindControl("txtMarks");


                    HiddenField hdfVul = (HiddenField)row.FindControl("hdfVul");

                    if (txttargetBanvisit1.Text == "" || txttargetBanvisit1.Text == null)
                    {

                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }

                    else if (txttargetBankvisit2.Text == "" || txttargetBankvisit2.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetVehicleInsp.Text == "" || txttargetVehicleInsp.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;

                    }
                    else if (txttargetPMEGP.Text == "" || txttargetPMEGP.Text == null)
                    {

                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetClosedUnits.Text == "" || txttargetClosedUnits.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else if (txttargetIndustryCatelog.Text == "" || txttargetIndustryCatelog.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;

                    }
                    else if (txttargetUnitInsp.Text == "" || txttargetUnitInsp.Text == null)
                    {
                        Failure.Visible = true;
                        success.Visible = false;
                        lblmsg0.Text = "Please enter Target";
                        return;
                    }
                    else
                    {

                        //DataSet dsemp1 = new DataSet();

           // dsemp1 = Gen.getGMtoIPOTarget(hdfID.Value);


          //  if (dsemp1.Tables[0].Rows.Count > 0)
          //  {

               // int del = Gen.DeleteGMtargetbyId(Session["uid"].ToString(),ddlYear.SelectedValue,ddlmonth.SelectedIndex.ToString());





                DataSet ds = new DataSet();
                ds = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1000");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }


                DataSet ds1 = new DataSet();
                ds1 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1001");

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }



                DataSet ds2 = new DataSet();
                ds2 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1002");

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }



                DataSet ds3 = new DataSet();
                ds3 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1004");

                if (ds3.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }


                DataSet ds4 = new DataSet();
                ds4 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1006");

                if (ds4.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }


                DataSet ds5 = new DataSet();
                ds5 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1007");

                if (ds5.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }


                DataSet ds6 = new DataSet();
                ds6 = Gen.FatechtargetofIPO(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedValue.ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1008");

                if (ds5.Tables[0].Rows.Count > 0)
                {
                    Failure.Visible = true;
                    success.Visible = false;
                    lblmsg0.Text = "Already  target Registered for this month of Year";
                    return;
                }




                int i = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1000", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetBanvisit1.Text, Session["uid"].ToString());

                int a = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1001", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetBankvisit2.Text, Session["uid"].ToString());


                int b = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1002", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetVehicleInsp.Text, Session["uid"].ToString());

                int c = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1004", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetPMEGP.Text, Session["uid"].ToString());

                int d = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1006", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetClosedUnits.Text, Session["uid"].ToString());

                int f = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1007", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetIndustryCatelog.Text, Session["uid"].ToString());


                int g = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1008", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
          txttargetUnitInsp.Text, Session["uid"].ToString());





                //DataSet dsemp = new DataSet();

                //dsemp = Gen.GetIPOS(dsemp1.Tables[0].Rows[0]["intGMid"].ToString());


//                int a = Gen.updateGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1000", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
  //              txttargetBanvisit1.Text, Session["uid"].ToString(), hdfID.Value);



    //            int g = Gen.insertGMtoIPOTarget(Session["uid"].ToString(), gvCertificate0.DataKeys[m].Value.ToString(), "1008", ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
      //    txttargetUnitInsp.Text, Session["uid"].ToString());


            //}





                    }



                  
                }


                Response.Redirect("HomeIPOResult.aspx");
                lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;


            }

            //    int i = Gen.updateGMtoIPOTarget(Session["uid"].ToString(), ddlIPOname.SelectedValue, ddltarget2.SelectedValue, ddlmonth.SelectedValue, ddlYear.SelectedItem.ToString(),
            //    txttarget.Text, Session["uid"].ToString(), hdfID.Value);
            //    if (i > 0)
            //    {

            //        lblmsg.Text = "Updated Successfully..!";
            //        success.Visible = true;
            //        Failure.Visible = false;
            //        clear();
            //    }
            //}


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

        GridViewRow row = (GridViewRow)NamingContainer;
        TextBox txttargetBanvisit1 = (TextBox)row.FindControl("txttargetBanvisit1");
        TextBox txttargetBankvisit2 = (TextBox)row.FindControl("txttargetBankvisit2");

        TextBox txttargetVehicleInsp = (TextBox)row.FindControl("txttargetVehicleInsp");

        TextBox txttargetPMEGP = (TextBox)row.FindControl("txttargetPMEGP");

        TextBox txttargetClosedUnits = (TextBox)row.FindControl("txttargetClosedUnits");

        TextBox txttargetIndustryCatelog = (TextBox)row.FindControl("txttargetIndustryCatelog");

        TextBox txttargetUnitInsp = (TextBox)row.FindControl("txttargetUnitInsp");


        txttargetBanvisit1.Text = "";
        txttargetBankvisit2.Text = "";
        txttargetVehicleInsp.Text = "";
        txttargetPMEGP.Text = "";
        txttargetClosedUnits.Text = "";
        txttargetIndustryCatelog.Text = "";
        txttargetUnitInsp.Text = "";




        //ddlIPOname.SelectedIndex = 0;
        //ddltarget2.SelectedIndex = 0;
        //ddlmonth.SelectedIndex = 0;
        //ddlYear.SelectedIndex = 0;
        //txttarget.Text = "";
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
        //    clear();
        //}
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txttargetBanvisit1 = (TextBox)e.Row.Cells[2].FindControl("txttargetBanvisit1");

            TextBox txttargetBankvisit2 = (TextBox)e.Row.Cells[3].FindControl("txttargetBankvisit2");

            TextBox txttargetVehicleInsp = (TextBox)e.Row.Cells[4].FindControl("txttargetVehicleInsp");

            TextBox txttargetPMEGP = (TextBox)e.Row.Cells[5].FindControl("txttargetPMEGP");

            TextBox txttargetClosedUnits = (TextBox)e.Row.Cells[6].FindControl("txttargetClosedUnits");

            TextBox txttargetIndustryCatelog = (TextBox)e.Row.Cells[7].FindControl("txttargetIndustryCatelog");

            TextBox txttargetUnitInsp = (TextBox)e.Row.Cells[8].FindControl("txttargetUnitInsp");


            HiddenField hdfFlagID0=(HiddenField)e.Row.Cells[0].FindControl("hdfFlagID0");
           // hdfFlagID0.Value=

                hdfFlagID0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intUserid")).Trim();
            HiddenField hdfVul = (HiddenField)e.Row.FindControl("hdfVul");


            
            DataSet dsemp1 = new DataSet();

            dsemp1 = Gen.getGMtoIPOTarget1(hdfID.Value);

            if (dsemp1.Tables[0].Rows.Count > 0)
            {

                DataSet dsemp = new DataSet();

                dsemp = Gen.GetIPOS(dsemp1.Tables[0].Rows[0]["intGMid"].ToString());

                if (dsemp.Tables[0].Rows.Count > 0)
                {
                    int n = dsemp.Tables[0].Rows.Count;
                    for (int r = 0; r < n; r++)
                    {

                        DataSet dsfill = new DataSet();
                        dsfill = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1000");

                        if (dsfill.Tables[0].Rows.Count > 0)
                        {

                            txttargetBanvisit1.Text = dsfill.Tables[0].Rows[0]["Target"].ToString();
                        }
                        DataSet dsfill1 = new DataSet();
                        dsfill1 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1001");

                        if (dsfill1.Tables[0].Rows.Count > 0)
                        {
                            txttargetBankvisit2.Text = dsfill1.Tables[0].Rows[0]["Target"].ToString();
                        }

                        DataSet dsfill2 = new DataSet();
                        dsfill2 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1002");

                        if (dsfill2.Tables[0].Rows.Count > 0)
                        {
                            txttargetVehicleInsp.Text = dsfill2.Tables[0].Rows[0]["Target"].ToString();
                        }

                        DataSet dsfill3 = new DataSet();
                        dsfill3 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1004");

                        if (dsfill3.Tables[0].Rows.Count > 0)
                        {
                            txttargetPMEGP.Text = dsfill3.Tables[0].Rows[0]["Target"].ToString();
                        }

                        DataSet dsfill4 = new DataSet();
                        dsfill4 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1006");

                        if (dsfill4.Tables[0].Rows.Count > 0)
                        {

                            txttargetClosedUnits.Text = dsfill4.Tables[0].Rows[0]["Target"].ToString();
                        }

                        DataSet dsfill5 = new DataSet();
                        dsfill5 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1007");

                        if (dsfill5.Tables[0].Rows.Count > 0)
                        {

                            txttargetIndustryCatelog.Text = dsfill5.Tables[0].Rows[0]["Target"].ToString();
                        }


                        DataSet dsfill6 = new DataSet();
                        dsfill6 = Gen.GetIPOTargetDetails(hdfFlagID0.Value, ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), "1008");

                        if (dsfill6.Tables[0].Rows.Count > 0)
                        {

                            txttargetUnitInsp.Text = dsfill6.Tables[0].Rows[0]["Target"].ToString();
                        }




                    }
                }


                //DataSet dsemp1 = new DataSet();
                //dsemp1 = Gen.getGMtoIPOTarget(hdfID.Value);


                // DataSet dsvol = Gen.GetIPOTargetDetails(dsemp1.Tables[0].Rows[0]["intIPOid"].ToString(), dsemp1.Tables[0].Rows[0]["VI_Year"].ToString(), dsemp1.Tables[0].Rows[0]["VI_Month"].ToString());




            }
  
        }

    }
    protected void btnOrgLookup0_Click(object sender, EventArgs e)
    {

    }
    protected void txttargetBanvisit1_TextChanged(object sender, EventArgs e)
    {
        TextBox txttargetBanvisit1 = (TextBox)sender;
        GridViewRow row = (GridViewRow)txttargetBanvisit1.NamingContainer;

        TextBox txttargetBankvisit2 = (TextBox)row.FindControl("txttargetBankvisit2");

        if (txttargetBanvisit1.Text != "")
        {

            txttargetBankvisit2.Text = txttargetBanvisit1.Text;
        }
        else
        {
            txttargetBankvisit2.Text = "0";
        }

    }
    protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = Gen.getIPOTargetDetailslat(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), Session["uid"].ToString());

        if (ds1.Tables[0].Rows.Count > 0)
        {
            hdfID.Value = ds1.Tables[0].Rows[0]["intGMtoIPOid"].ToString();
            FillDetails();
            BtnSave1.Text = "Update";
        }
        else
        {

            getIPOS();
            hdfID.Value = "";
        }

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = Gen.getIPOTargetDetailslat(ddlYear.SelectedValue.ToString(), ddlmonth.SelectedIndex.ToString(), Session["uid"].ToString());

        if (ds1.Tables[0].Rows.Count > 0)
        {
            hdfID.Value = ds1.Tables[0].Rows[0]["intGMtoIPOid"].ToString();
            FillDetails();
            BtnSave1.Text = "Update";
        }
        else
        {
            getIPOS();
            hdfID.Value = "";
        }

    }
}
