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

public partial class UI_TSiPASS_frmDrugRenewal : System.Web.UI.Page
{
    General Gen = new General();
    Drug.TSIPass_Eodb objdrugtest = new Drug.TSIPass_Eodb();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityREN(Request.QueryString[0].ToString(), "19");//Session["Applid"].ToString()
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {
                    //Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    //  Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {
                    Response.Redirect("frmtradeRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }
        if (!IsPostBack)
        {

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {

                ResetFormControl(this);

            }
            
            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];

                if (!IsPostBack)
                {
                    //BindScreenDetails();

                    FillDetails();

                }
            }

            //DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //    }

            //}



        }
    }
    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).ReadOnly = true;
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).Enabled = false;
                        }
                        break;
                    case "System.Web.UI.WebControls.FileUpload":
                        ((FileUpload)c).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;

                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)c).Enabled = false;
                        break;
                }
            }
        }
    }
    void FillDetails()
    {

        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.RetriveDRUGRENEWALDETAILS(Request.QueryString[0].ToString());


            if (ds.Tables[0].Rows.Count > 0)

            {
        
                hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["DRUGRENEWALID"]);

                txtlicenseNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["LICENSE_NO"]);

                txtnameofthefirm.Text = Convert.ToString(ds.Tables[0].Rows[0]["NAMEOFFIRM"]);

                txtdistrict.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_DISTRICT"]);

                txtmandal.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_MANDAL"]);

                txtvillage.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_VILLAGE"]);

                txtunitaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["UNIT_ADDRESS"]);

                txtdistric_office.Text = Convert.ToString(ds.Tables[0].Rows[0]["OFFICE_DISTRICT"]);

                txtmandal_office.Text= Convert.ToString(ds.Tables[0].Rows[0]["OFFICE_MANDAL"]);

                txtvillage_office.Text= Convert.ToString(ds.Tables[0].Rows[0]["OFFICE_VILLAGE"]);

                txtoffice_Address.Text= Convert.ToString(ds.Tables[0].Rows[0]["OFFICE_ADDRESS"]);

                txtfromdate.Text= Convert.ToString(ds.Tables[0].Rows[0]["FROMDATE"]);

                txttodate.Text= Convert.ToString(ds.Tables[0].Rows[0]["TODATE"]);               

                txttotalAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalAmount"]);

                txtLicenseType.Text = Convert.ToString(ds.Tables[0].Rows[0]["LicenseType_Name"]);
                txtLicenseSubType.Text = Convert.ToString(ds.Tables[0].Rows[0]["LicenseSubType_Name"]);


                txttotalproduct.Text = Convert.ToString(ds.Tables[0].Rows[0]["TOTALPRODUCT"]);
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
    public class listofdrug
    {
        public string SuccessFlag { get; set; }
        public string SuccessMsg { get; set; }
        public IList<RenewalDetails> Data { get; set; }
        // public string Data { get; set; }
    }

    public class RenewalDetails
    {

        public string Name_Frim { get; set; }
        public string unitDistrict { get; set; }
        public string UnitMandal { get; set; }
        public string UnitVillage { get; set; }
        public string UntiAddress { get; set; }

        public string OfficeDistrict { get; set; }
        public string OfficeMandal { get; set; }
        public string OfficeVillage { get; set; }
        public string OfficeAddress { get; set; }

        public string FRMDATE { get; set; }
        public string EXPDATE { get; set; }

        public string TOTamount { get; set; }
        public string LicenseType_Name { get; set; }
        public string LicenseSubType_Name { get; set; }
    }
    protected void txtlicenseNO_TextChanged(object sender, EventArgs e)
    {
       // DataSet ds = new DataSet();
      var  ds = objdrugtest.GetFirmLicenseDetails(txtlicenseNO.Text,"Tsipass", "Tsipass$Admin@123");
      if (ds != null)
      {
          listofdrug instance = Cls_JSONFormat.JsonDeserialize<listofdrug>(ds);

          var testdata = instance.Data;
          DataTable dt_test = Cls_JSONFormat.ToDataTable(testdata);
          txtnameofthefirm.Text = Convert.ToString(dt_test.Rows[0]["Name_Frim"]);
          txtdistric_office.Text = Convert.ToString(dt_test.Rows[0]["OfficeDistrict"]);
          txtmandal_office.Text = Convert.ToString(dt_test.Rows[0]["OfficeMandal"]);
          txtvillage_office.Text = Convert.ToString(dt_test.Rows[0]["OfficeVillage"]);
          txtunitaddress.Text = Convert.ToString(dt_test.Rows[0]["UntiAddress"]);
          txtdistrict.Text = Convert.ToString(dt_test.Rows[0]["unitDistrict"]);
          txtmandal.Text = Convert.ToString(dt_test.Rows[0]["UnitMandal"]);
          txtvillage.Text = Convert.ToString(dt_test.Rows[0]["UnitVillage"]);
          txtfromdate.Text = Convert.ToString(dt_test.Rows[0]["FRMDATE"]);
          txttodate.Text = Convert.ToString(dt_test.Rows[0]["EXPDATE"]);
          txtoffice_Address.Text = Convert.ToString(dt_test.Rows[0]["OfficeAddress"]);
          txttotalAmount.Text = Convert.ToString(dt_test.Rows[0]["TOTamount"]);
          txtLicenseType.Text = Convert.ToString(dt_test.Rows[0]["LicenseType_Name"]);
          txtLicenseSubType.Text = Convert.ToString(dt_test.Rows[0]["LicenseSubType_Name"]);
      }
      else
      {
          Failure.Visible = true;
          lblmsg0.Text = "There is no Data with Enter License No";
      }
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        //if (ddlexpyear.SelectedValue == "0" || ddlexpyear.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please select Status and previous experience of the Applicant \\n";
        //    slno = slno + 1;
        //}
        //if (txt9Bfileno.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter 9B File Number of the building granted \\n";
        //    slno = slno + 1;
        //}

        //if (txtreferancedate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Date of the Reference in which permission for construction of the building granted \\n";
        //    slno = slno + 1;
        //}
        //if (txtlongevitydate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter The Date upto which the certificate of longevity of the building issued by the executive engineer (R&B) is valid \\n";
        //    slno = slno + 1;
        //}

        //if (txtelectricalcertificatevaliddate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter The date upto which the Electrical certificate in form -D is Valid \\n";
        //    slno = slno + 1;
        //}

        //if (txtfirenocvaliddate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter The date upto which the NOC of Fire Department is Valid \\n";
        //    slno = slno + 1;
        //}


        //if (ddllicenseperiod.SelectedValue == "0" || ddllicenseperiod.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select The period for which the license has to be granted \\n";
        //    slno = slno + 1;
        //}
        //if (rbttheatretype.SelectedValue == "" || rbttheatretype.SelectedValue == "null")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Type of Cinema Theatre \\n";
        //    slno = slno + 1;
        //}
        //if (txtnoofscreens.Text == "" || txtnoofscreens.Text == "0")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please enter Number of Screens in multiplex \\n";
        //    slno = slno + 1;
        //}
        //if (ddlnoofshows.SelectedValue == "0" || ddlnoofshows.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Number of Shows proposed to be screened for single screen/Multiplex \\n";
        //    slno = slno + 1;
        //}
        //if (ddlcommissionerate.SelectedValue == "0" || ddlcommissionerate.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Commissionerate \\n";
        //    slno = slno + 1;
        //}
        //if (ddlzone.SelectedValue == "0" || ddlzone.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Zone \\n";
        //    slno = slno + 1;
        //}
        //if (ddldivision.SelectedValue == "0" || ddldivision.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Division \\n";
        //    slno = slno + 1;
        //}
        //if (ddlpolicestation.SelectedValue == "0" || ddlpolicestation.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Police Station \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficzone.SelectedValue == "0" || ddltrafficzone.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Zone \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficdivision.SelectedValue == "0" || ddltrafficdivision.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Division \\n";
        //    slno = slno + 1;
        //}
        //if (ddltrafficpolicestation.SelectedValue == "0" || ddltrafficpolicestation.SelectedValue == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Traffic Police Station \\n";
        //    slno = slno + 1;
        //}

        //if (lbl8BNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload 8B NOC. \\n";
        //    slno = slno + 1;
        //}
        //if (lbl9BNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload 9B NOC. \\n";
        //    slno = slno + 1;
        //}

        //if (lblfireoccupancycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Fire Occupancy Certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblGHMCoccupancycertificate.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload GHMC Occupancy Certificate. \\n";
        //    slno = slno + 1;
        //}

        //if (lblTSFTCANDTDCNOC.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload NOC of TSFTV & TDC. \\n";
        //    slno = slno + 1;
        //}

        //if (lblfirmchambernoc.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload NOC of Film Chamber of Commerce. \\n";
        //    slno = slno + 1;
        //}

        //if (lblfirmdivision.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Film Division. \\n";
        //    slno = slno + 1;
        //}

        //if (lblleaseagreement.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Lease Agreement or any other relavent document. \\n";
        //    slno = slno + 1;
        //}

        //if (lblblueprint.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload Blue print of Cinema Theatre/Multiplex with Screens and seating Capacity. \\n";
        //    slno = slno + 1;
        //}

        //if (lblseatingdetails.Text == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please upload 	Details with regard to Screens, seating and Ticket Rates proposed. \\n";
        //    slno = slno + 1;
        //}

        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave.Text == "Save")
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            

            int result = 0;
            result = Gen.InsertDrugRenewalDetails(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtlicenseNO.Text, txtnameofthefirm.Text,
                txtdistrict.Text, txtmandal.Text, txtvillage.Text, txtunitaddress.Text, txtdistric_office.Text,
                txtmandal_office.Text, txtvillage_office.Text, txtoffice_Address.Text,txtfromdate.Text,txttodate.Text ,txttotalproduct.Text,
                hdnidentityid.Value, Session["uid"].ToString(), txttotalAmount.Text);

            if (result > 0)
            {
                if (result == 1)
                {
                    lblmsg.Text = "<font color='green'>Drug Renewal  Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    success.Visible = true;
                    Failure.Visible = false;
                    lblmsg.Text = "<font color='green'>Drug Renewal Details Updated Successflly..!</font>";
                }
            }
            else
            {

                success.Visible = false;
                Failure.Visible = true;
                lblmsg.Text = "<font color='green'>Drug Renewal Details  Submission Failed..!</font>";

            }

        }


    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmtradeRenewal.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }

        int result = 0;
        string test = Session["ApplidA"].ToString();
        result = Gen.InsertDrugRenewalDetails(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtlicenseNO.Text, txtnameofthefirm.Text,
                txtdistrict.Text, txtmandal.Text, txtvillage.Text, txtunitaddress.Text, txtdistric_office.Text,
                txtmandal_office.Text, txtvillage_office.Text, txtoffice_Address.Text, txtfromdate.Text, txttodate.Text, txttotalproduct.Text,
                hdnidentityid.Value, Session["uid"].ToString(), txttotalAmount.Text);
        if (result > 0)
        {
            if (result == 1)
            {
                Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                lblmsg.Text = "<font color='green'>Drug Renewal Details Updated Successflly..!</font>";
                success.Visible = true;
                Failure.Visible = false;

            }
            else
            {
                Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "<font color='green'>Drug Renewal Details Updated Successflly..!</font>";
            }
        }
        else
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "<font color='green'>Drug Renewal Details  Submission Failed..!</font>";

        }

    }


    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmDrugRenewal.aspx?intApplicationId=" + Session["Applid"].ToString().Trim() + "&next=" + "N");        
    }
}