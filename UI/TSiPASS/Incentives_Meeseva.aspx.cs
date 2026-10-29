using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using System.Security.Cryptography;
using System.Text;
using System.IO;
//using MeeSeva;

public partial class Incentives_Meeseva : System.Web.UI.Page
{
    byte[] key = { 0xA2, 0x15, 0x37, 0x07, 0xCB, 0x62, 0xC1, 0xD3, 0xF8, 0xF1, 0x97, 0xDF, 0xD0, 0x13, 0x4F, 0x79, 0x01, 0x67, 0x7A, 0x85, 0x94, 0x16, 0x31, 0x92 };
    byte[] iv = { 50, 51, 52, 53, 54, 55, 56, 57 };

    private byte[] m_key;
    private byte[] m_iv;
    TripleDESCryptoServiceProvider m_des = new TripleDESCryptoServiceProvider();
    UTF8Encoding m_utf8 = new UTF8Encoding();

    comFunctions objCmf = new comFunctions();
    Fetch objFetch = new Fetch();    
    DML objDml = new DML();    
    DataTable myDtNewRecdr = new DataTable();
    //MeeSevaWebService objMeeSeva = new MeeSevaWebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    Session.RemoveAll();
                    string enc;
                    Session["enc"] = enc = Convert.ToString(Request.QueryString["enc"]);
                    //Session["enc"] = enc = "54QuOTDZ31WJ0GOwrlQ472TzIq/QRA58xj8PyGWlBcEh91%20QVcHN6FYXUTZ9QfcDrEjdHuqP%20K0tHWkixsM4lYR83TyG5WvIZ1ok9zhjtLkB1rnigKqfXPttIrTWxteYHRS06n3Gy5wSKZaOXws145gy9Jylqv8bRYFoEDSrEd535EbazyXNyO1oZq5NpwYBf4DTwt%20zIlO9MkExTNkXHvDzEFjs8pz7X/Bxd5NCfzJK6LWTAhp5gw==";
                    string queryString = enc.Replace(" ", "+");
                    queryString = Decrypt(queryString);

                    IList<string> queryStringArray = queryString.Split('&');


                    if (queryStringArray.Count != 10) { Response.Redirect("https://ipass.telangana.gov.in", false); return; }

                    Session["StrUniqueNo"] = Convert.ToString(queryStringArray[0].Split('=')[1]);
                    Session["StrSCAId"] = Convert.ToString(queryStringArray[1].Split('=')[1]);
                    Session["StrMeesevaUserId"] = Convert.ToString(queryStringArray[2].Split('=')[1]);
                    Session["StrChannelId"] = Convert.ToString(queryStringArray[3].Split('=')[1]);
                    Session["StrChecksum"] = Convert.ToString(queryStringArray[4].Split('=')[1]);
                    Session["StrMeesevaRequestId"] = Convert.ToString(queryStringArray[5].Split('=')[1]);
                    Session["StrServiceid"] = Convert.ToString(queryStringArray[6].Split('=')[1]);
                    Session["StrScaPassword"] = Convert.ToString(queryStringArray[7].Split('=')[1]);
                    Session["StrMeesevaFlag"] = Convert.ToString(queryStringArray[8].Split('=')[1]);
                    Session["StrRandomNumber"] = Convert.ToString(queryStringArray[9].Split('=')[1]);



                    if (!GenerateCheckSum1(Session["StrSCAId"].ToString(), Session["StrScaPassword"].ToString(), Session["StrSCAId"].ToString(), Session["StrMeesevaUserId"].ToString(), Session["StrUniqueNo"].ToString(), Session["StrChecksum"].ToString()))
                    {
                        Response.Redirect("~/ErrorMeeSevaPage.htm", false);
                        return;
                    }

                    txtBussinessActivity.Visible = false;
                    btnNext.PostBackUrl = "";
                    txtAccNumber.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");
                    txtBuildingValue.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");
                    txtLandValue.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");
                    txtMobile.Attributes.Add("onkeypress", "return restrictChars(event,this,0);");
                    txtPlantandMachinery.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");
                    txtTotal.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");
                    txttotalEmp.Attributes.Add("onkeypress", "return restrictChars(event,this,2);");

                    objCmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                    objCmf.BindCtlto(true, ddlDistrict, objFetch.FetchDistrictMst(), 1, 0, false);
                    objCmf.BindCtlto(true, ddlintLineofActivity, objFetch.FetchLineofActivity(), 1, 0, false);
                    objCmf.BindCtlto(true, ddlCategory, objFetch.FetchCategory(), 1, 0, false);
                    ddlDistrict_SelectedIndexChanged(sender, e);
                    rblSector_SelectedIndexChanged(sender, e);
                    txtEmUdgAadhar_TextChanged(sender, e);
                    

                    btnNext.Visible = false;
                    if (Session["EntprIncentive"] != null) btnNext.Visible = true;
                }

                else { Response.Redirect("https://ipass.telangana.gov.in", false); }
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); Response.Redirect("https://ipass.telangana.gov.in", false); }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e) 
    {
        try {
            DataTable dt = new DataTable();
            if (ddlDistrict.SelectedIndex > 0)
                dt = objFetch.FetchMandals(Convert.ToInt32(ddlDistrict.SelectedValue));
            else 
                dt = null;


                objCmf.BindCtlto(true, ddlMandal, dt, 1, 0, false);
                ddlMandal_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            if (ddlMandal.SelectedIndex > 0)
                dt = objFetch.FetchVillages(Convert.ToInt32(ddlMandal.SelectedValue));
            else
                dt = null;


            objCmf.BindCtlto(true, ddlVillage, dt, 1, 0, false);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { rblSector_SelectedIndexChanged(sender, e); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void cbDiffAbled_CheckedChanged(object sender, EventArgs e)
    {
        try { rblSector_SelectedIndexChanged(sender, e); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void rblSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            ddlintLineofActivity.Visible = true;
            txtBussinessActivity.Visible = false;
            trSectorVeh.Visible = false;
            rblVeh.Items[0].Enabled = false;
            //rblVeh.SelectedValue = "1";
            txtPlantandMachinery.Enabled = txtEquipment.Enabled = false;
            switch (rblSector.SelectedValue)
            {                 
                case "1":
                    txtBussinessActivity.Visible = true;
                    ddlintLineofActivity.Visible = false;
                    lblNatureofActitvity.Text = "Nature of Service Activity";
                    rfvLineOfAct.ControlToValidate = "txtBussinessActivity";
                    rfvLineOfAct.ErrorMessage = "Please Enter Nature of Service Activity";
                    rfvLineOfAct.InitialValue = "";
                    txtEquipment.Enabled= trSectorVeh.Visible = true;
                    txtEquipment.Text = "0";
                    if (ddlCaste.SelectedValue == "3" || ddlCaste.SelectedValue == "4" || cbDiffAbled.Checked)
                    {
                        rblVeh.Visible = true;
                        rblVeh.Items[0].Enabled = true; 
                    }
                    break;
                default:
                    lblNatureofActitvity.Text = "Nature of Activity";
                    rfvLineOfAct.ControlToValidate = "ddlintLineofActivity";
                    rfvLineOfAct.InitialValue = "-- SELECT --";
                    rblVeh.Visible= txtPlantandMachinery.Enabled = true;
                    txtPlantandMachinery.Text = "0";
                    break;
            }
            rblVeh_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void rblVeh_SelectedIndexChanged(object sender, EventArgs e)
    {
        try 
        {
            lblVehivleRegNo.Visible = txtvehicleRegistratioNumber.Visible = false;
            ddlLandStatus.Enabled = ddlBuidingStatus.Enabled = ddltypeofOrg.Enabled = txttotalEmp.Enabled = true;
            txtLandValue.Enabled = txtBuildingValue.Enabled = true;
            if (rblVeh.SelectedValue == "1")
            {
                lbldateofCommencement.Text = "Date of commencement for Production";                
            }
            else
            {
                lbldateofCommencement.Text = "Vehicle Registration Date";
                lblVehivleRegNo.Visible = txtvehicleRegistratioNumber.Visible = true;
                ddlLandStatus.Enabled = ddlBuidingStatus.Enabled = ddltypeofOrg.Enabled=txttotalEmp.Enabled= false;
                txtLandValue.Enabled = txtBuildingValue.Enabled =false;
                ddlLandStatus.SelectedIndex = ddlBuidingStatus.SelectedIndex = ddltypeofOrg.SelectedIndex = 0;
                txttotalEmp.Text = "0";
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        try { cbWomen.Checked = (ddlGender.SelectedValue.ToLower() == "f" ? true : false);}
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void btnSave_Click(object sender, EventArgs e)    
    { if (save()) System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data submitted successfully');", true); }

    private bool save()
    {
        try
        {
            if (Page.IsValid)
            {
                Failure0.Visible = false;
                txtTotal.Text = Convert.ToString(
                                Convert.ToDecimal(txtLandValue.Text.Trim() == "" ? "0" : txtLandValue.Text) +
                                Convert.ToDecimal(txtBuildingValue.Text.Trim() == "" ? "0" : txtBuildingValue.Text) +
                                Convert.ToDecimal(txtPlantandMachinery.Text.Trim() == "" ? "0" : txtPlantandMachinery.Text) +
                                Convert.ToDecimal(txtEquipment.Text.Trim() == "" ? "0" : txtEquipment.Text));

                int sector;
                if (rblSector.SelectedIndex > -1)
                { sector = Convert.ToInt32(rblSector.SelectedValue); }
                else
                {
                    lblmsg2.Text = "Please Select Sector";
                    Failure0.Visible = true;
                    return false;
                }

                bool IsGHMC;
                if (rblGHMC.SelectedIndex > -1)
                { IsGHMC = (rblGHMC.SelectedValue == "0" ? true : false); }
                else
                {
                    lblmsg2.Text = "Please Select Municipal corporation";
                    rblGHMC.Focus();
                    Failure0.Visible = true;
                    return false;
                }

                int intlineofActivity = -1;
                bool IsVehicleIncentive = (rblVeh.SelectedValue=="0"?true:false);

                if (IsVehicleIncentive && txtvehicleRegistratioNumber.Text.Trim().Length<3)
                {
                    Failure0.Visible = true;
                    lblmsg1.Text = "Please Enter Valid Vehicle Number";
                    return false;
                }

                string BussinessActivity = "";
                DateTime DateOfCommencement=Convert.ToDateTime("01/01/1900");
                if (sector == 1)
                {
                    BussinessActivity = txtBussinessActivity.Text;

                    try
                    {
                        DateOfCommencement = Convert.ToDateTime(txtDateofCommencement.Text);
                        if (DateOfCommencement > DateTime.Now)
                        {
                            Failure0.Visible = true;
                            txtDateofCommencement.Focus();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
                            lblmsg2.Text = "Future Date cannot be selected.";
                        }
                    }
                    catch (Exception)
                    {
                        Failure0.Visible = true;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
                        lblmsg2.Text = "Please Select Valid Date(dd-MMM-yyyy).";
                        return false;
                    }
                }
                else
                { intlineofActivity = Convert.ToInt32(ddlintLineofActivity.SelectedValue); }

                DateOfCommencement = Convert.ToDateTime(txtDateofCommencement.Text);
                if (DateOfCommencement.AddYears(15) < DateTime.Now)
                {
                    Failure0.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('You are not eligible for applying incentive as your Date of commencement is morethan 15 years old.');", true);
                    lblmsg2.Text = "You are not eligible for applying incentive as your Date of commencement is morethan 15 years.";
                    return false;
                }
                Session["EntprIncentive"] = objDml.InsUpdDeltbl_Incentive(txtEmUdgAadhar.Text,
                                                    txtUnitname.Text,
                                                    txtApplicantName.Text,
                                                    ddlGender.SelectedValue,
                                                    Convert.ToInt32(ddlCaste.SelectedValue),
                                                    txtEmail.Text,
                                                    txtMobile.Text,
                                                    intlineofActivity,
                                                    Convert.ToInt32(ddlCategory.SelectedValue),
                                                    Convert.ToDecimal(txtLandValue.Text.Trim() == "" ? "0" : txtLandValue.Text),
                                                    Convert.ToDecimal(txtBuildingValue.Text.Trim() == "" ? "0" : txtBuildingValue.Text),
                                                    Convert.ToDecimal(txtPlantandMachinery.Text.Trim() == "" ? "0" : txtPlantandMachinery.Text),
                                                    Convert.ToDecimal(txtEquipment.Text.Trim() == "" ? "0" : txtEquipment.Text),
                                                    Convert.ToDecimal(txtTotal.Text.Trim() == "" ? "0" : txtTotal.Text),
                                                    (ddlLandStatus.SelectedIndex>0? ddlLandStatus.SelectedValue:"0"),
                                                    (ddlBuidingStatus.SelectedIndex > 0 ? ddlBuidingStatus.SelectedValue : "0"),
                                                    Convert.ToInt32(ddlDistrict.SelectedValue),
                                                    Convert.ToInt32((ddltypeofOrg.SelectedIndex > 0 ? ddltypeofOrg.SelectedValue : "0")),
                                                    Convert.ToInt32(txttotalEmp.Text.Trim() == "" ? "0" : txttotalEmp.Text),
                                                    (ddlBank.SelectedIndex > 0 ? ddlBank.SelectedValue : "0"),
                                                    txtAccNumber.Text,
                                                    txtBranchName.Text,
                                                    txtIfscCode.Text,
                                                    0,
                                                    cbDiffAbled.Checked,
                                                    cbWomen.Checked,
                                                    cbMinority.Checked,
                                                    txtAddressoftheUnit.Text,
                                                    Convert.ToInt32(ddlMandal.SelectedValue),
                                                    Convert.ToInt32(ddlVillage.SelectedValue),
                                                    sector,
                                                    BussinessActivity,
                                                    IsGHMC,
                                                    IsVehicleIncentive,
                                                    DateOfCommencement,
                                                    txtvehicleRegistratioNumber.Text,
                                                    true,
                                                    (Session["StrMeesevaUserId"] ==null ? "" : Session["StrMeesevaUserId"].ToString()),
                                                    false
                                                    );
                try
                {
                    if (Convert.ToInt32(Session["EntprIncentive"]) > 0)
                    {
                        Session["Incentive_DateOfCommencement"] = null;
                        if (DateOfCommencement.ToString("dd-MMM-yyyy").ToLower() != "01-jan-1900")
                            Session["Incentive_DateOfCommencement"] = DateOfCommencement;
                        Session["Incentive_DateOfCommencement"] = Convert.ToDateTime(txtDateofCommencement.Text);
                        Session["Incentive_isVehicle"] = IsVehicleIncentive;
                        Session["Incentive_GHMC"] = IsGHMC;
                        Session["Incentive_Caste"] = Convert.ToInt32(ddlCaste.SelectedValue);
                        Session["Incentive_Sector"] = sector;
                        Session["Incentive_PHC"] = cbDiffAbled.Checked;
                        Session["Incentive_Category"] = Convert.ToInt32(ddlCategory.SelectedValue);
                        success0.Visible = true;

                        if (Session["EntprIncentive"] != null)
                        {
                            lblmsg1.Text = "Data submitted successfully, please click on Next to continue.";
                            btnNext.Visible = true;
                        }
                        btnNext.PostBackUrl = "~/UI/TSiPASS/TypeOfIncentives_MeeSeva.aspx";
                        return true;
                    }
                    else
                    {
                        Failure0.Visible = true;
                        lblmsg2.Text = "Please fill all the Mandatory fields.";
                        return false;
                    }
                }
                catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); return false; }
            }
            return false;
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); return false; }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        try { objCmf.ClearControls(this.Page); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        try { if (save()) Response.Redirect(btnNext.PostBackUrl,false); }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void txtTotalValueCalculation(object sender, EventArgs e)
    {
        try
        {
            decimal landValue = Math.Round(Convert.ToDecimal(txtLandValue.Text.Trim() == "" ? "0" : txtLandValue.Text), 2);
            decimal buildingValue = Math.Round(Convert.ToDecimal(txtBuildingValue.Text.Trim() == "" ? "0" : txtBuildingValue.Text), 2);
            decimal plantAndmachinery = Math.Round(Convert.ToDecimal(txtPlantandMachinery.Text.Trim() == "" ? "0" : txtPlantandMachinery.Text), 2);

            decimal eqptValue = Convert.ToDecimal(txtEquipment.Text.Trim() == "" ? "0" : txtEquipment.Text);

            if (eqptValue > 0)
            {
                txtTotal.Text = txtEquipment.Text;
                txtPlantandMachinery.Text = txtLandValue.Text = txtBuildingValue.Text = "0";
            }
            else
            {
                txtTotal.Text = Math.Round(landValue + buildingValue + plantAndmachinery, 2).ToString();
            }

            switch (rblSector.SelectedValue)
            {
                case "1":
                    if (eqptValue <= 10)
                        ddlCategory.SelectedValue = "1";
                    else if (eqptValue > 10 && eqptValue <= 200)
                        ddlCategory.SelectedValue = "2";
                    else if (eqptValue > 200 && eqptValue <= 500)
                        ddlCategory.SelectedValue = "3";
                    else
                        ddlCategory.SelectedValue = "4";
                    break;
                default:
                    if (plantAndmachinery <= 25)
                        ddlCategory.SelectedValue = "1";
                    else if (plantAndmachinery > 25 && plantAndmachinery <= 500)
                        ddlCategory.SelectedValue = "2";
                    else if (plantAndmachinery > 500 && plantAndmachinery <= 1000)
                        ddlCategory.SelectedValue = "3";
                    else if (plantAndmachinery > 1000 && plantAndmachinery <= 20000)
                        ddlCategory.SelectedValue = "4";
                    else if (plantAndmachinery > 20000)
                        ddlCategory.SelectedValue = "5";
                    break;
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void txtDateofCommencement_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Failure0.Visible = false;
            DateTime dat = Convert.ToDateTime(txtDateofCommencement.Text);
            if (dat > DateTime.Now)
            {
                Failure0.Visible = true;
                txtDateofCommencement.Focus();
                lblmsg2.Text = "Future Date cannot be selected.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog_MeeSeva(ex);
            Failure0.Visible = true;
            txtDateofCommencement.Focus();
            lblmsg2.Text = "Please Select Valid Date(dd-MMM-yyyy).";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
        }
    }

    #region MeeSeva

    public string Decrypt(string textToDecrypt)
    {
        try
        {
            // string decrypt = "54QuOTDZ31WJ0GOwrlQ472TzIq/QRA58xj8PyGWlBcEh91+QVcHN6FYXUTZ9QfcDRKONwQb8G7+jZLPoH0qWF3KU+1hWFKFxWfc+mDKIRpjt5oL7DklFdEVmdyabqN9YBP8IZM4VA7B80qkIFguT3PRidr8la2yyeS8NSDhatSSfD5hGH18jAgNyay2dp/KrEFncpHSG/ypQiITH0G+dAH0Gr8HbId/L";
            byte[] input = Convert.FromBase64String(textToDecrypt);
            byte[] output = Transform(input,
                            m_des.CreateDecryptor(key, iv));
            return m_utf8.GetString(output);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); return null; }
    }


    private byte[] Transform(byte[] input,
              ICryptoTransform CryptoTransform)
    {
        try
        {
            // create the necessary streams
            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(memStream,
                         CryptoTransform, CryptoStreamMode.Write);
            // transform the bytes as requested
            cryptStream.Write(input, 0, input.Length);
            cryptStream.FlushFinalBlock();
            // Read the memory stream and
            // convert it back into byte array
            memStream.Position = 0;
            byte[] result = memStream.ToArray();
            // close and release the streams
            memStream.Close();
            cryptStream.Close();
            // hand back the encrypted buffer
            return result;
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); return null; }
    }

    private bool GenerateCheckSum1(string scaUserId, string scaPassword, string centerId, string operatorId, string uniqueNo, string Checksum)
    {
        try
        {
            string compareChecksum = Checksum.Substring(1, Checksum.Length - 2);
            string str1 = centerId + uniqueNo;
            string str2 = operatorId;
            string l3 = (str1 + scaUserId) + (str2 + scaPassword);
            int n1 = str1.Length;
            int n2 = str2.Length;
            string l1 = str1.Substring(0, n1 - 3);
            string l2 = str2.Substring(0, n2 - 2);
            if (compareChecksum.Equals(l3 + l2 + uniqueNo + l1))
                return true;
            else
                return false;

        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); return false; }
    } 

    #endregion

    protected void txtEmUdgAadhar_TextChanged(object sender, EventArgs e)
    {
        try 
        {
            //DataTable dt = objFetch.FetchIncentiveDtls_MeeSeva(Session["StrMeesevaUserId"].ToString());
            //DataTable dt = objFetch.FetchIncentiveDtls_MeeSeva(txtEmUdgAadhar.Text);
            string EmUdyog = "";
            if (Session["EmUdyog"] != null && txtEmUdgAadhar.Text == "") EmUdyog = Session["EmUdyog"].ToString(); else EmUdyog = txtEmUdgAadhar.Text;
            DataTable dt = new DataTable();
            dt = objFetch.FetchIncentiveDtls_MeeSeva(EmUdyog);
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["EntprIncentive"] = dt.Rows[0]["IncentiveId"].ToString();
                Session["EmUdyog"] = txtEmUdgAadhar.Text = dt.Rows[0]["EMiUdyogAadhar"].ToString();

                txtAccNumber.Text = dt.Rows[0]["AccNo"].ToString();
                txtAddressoftheUnit.Text = dt.Rows[0]["Addressofunit"].ToString();
                txtApplicantName.Text = dt.Rows[0]["ApplciantName"].ToString();
                txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();
                if (dt.Rows[0]["BuildingStatus"].ToString() == "0") ddlBuidingStatus.SelectedIndex = 0; else ddlBuidingStatus.SelectedValue = dt.Rows[0]["BuildingStatus"].ToString();
                txtBuildingValue.Text = dt.Rows[0]["BuildingValue"].ToString();
                txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                
                txtEquipment.Text = dt.Rows[0]["EquipmentValue"].ToString();
                txtIfscCode.Text = dt.Rows[0]["IFSCCode"].ToString();

                if (dt.Rows[0]["landstatus"].ToString() == "0") ddlLandStatus.SelectedIndex = 0; else ddlLandStatus.SelectedValue = dt.Rows[0]["landstatus"].ToString();
                txtLandValue.Text = dt.Rows[0]["Landvalue"].ToString();
                txtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                txtPlantandMachinery.Text = dt.Rows[0]["PlantMachineryValue"].ToString();
                txtTotal.Text = dt.Rows[0]["Total"].ToString();
                txttotalEmp.Text = dt.Rows[0]["TotalEmployment"].ToString();
                txtUnitname.Text = dt.Rows[0]["UnitName"].ToString();
                ddlBank.SelectedValue = dt.Rows[0]["BankName"].ToString();
                Session["Incentive_Caste"] = ddlCaste.SelectedValue = dt.Rows[0]["Caste"].ToString();

                if (dt.Rows[0]["sector"].ToString() == "-1")
                {
                    rblSector.SelectedIndex = -1;
                    Session["incentive_Sector"] = null;
                }
                else
                    Session["incentive_Sector"] = rblSector.SelectedValue = dt.Rows[0]["sector"].ToString();
                rblSector_SelectedIndexChanged(sender, e);

                ddlDistrict.SelectedValue = dt.Rows[0]["District"].ToString();
                ddlDistrict_SelectedIndexChanged(sender, e);

                ddlGender.SelectedValue = dt.Rows[0]["Gender"].ToString();

                if (dt.Rows[0]["natureOfAct"].ToString() == "-1")
                    ddlintLineofActivity.SelectedIndex = -1;
                else
                    ddlintLineofActivity.SelectedValue = dt.Rows[0]["natureOfAct"].ToString();

                txtBussinessActivity.Text = dt.Rows[0]["NatureofBussiness"].ToString();
                ddltypeofOrg.SelectedValue = dt.Rows[0]["TypeofOrg"].ToString();
                ddlCategory.SelectedValue = dt.Rows[0]["Category"].ToString();

                Session["Incentive_Category"] = Convert.ToInt32(ddlCategory.SelectedValue);

                cbDiffAbled.Checked = (dt.Rows[0]["IsDifferentlyAbled"].ToString().Trim() == "" ? false : Convert.ToBoolean(dt.Rows[0]["IsDifferentlyAbled"].ToString()));
                cbMinority.Checked = (dt.Rows[0]["IsWomen"].ToString().Trim() == "" ? false : Convert.ToBoolean(dt.Rows[0]["IsWomen"].ToString()));
                cbWomen.Checked = (dt.Rows[0]["IsMinority"].ToString().Trim() == "" ? false : Convert.ToBoolean(dt.Rows[0]["IsMinority"].ToString()));
                if (dt.Rows[0]["manadalid"].ToString() == "0") ddlMandal.SelectedIndex = 0; else ddlMandal.SelectedValue = dt.Rows[0]["manadalid"].ToString();
                Session["Incentive_PHC"] = cbDiffAbled.Checked;

                ddlMandal_SelectedIndexChanged(sender, e);
                if (dt.Rows[0]["villageid"].ToString() == "0") ddlVillage.SelectedIndex = 0; else ddlVillage.SelectedValue = dt.Rows[0]["villageid"].ToString();
                Session["Incentive_NewOrExisting"] = Convert.ToInt32(dt.Rows[0]["IsOneTimeIncentive"].ToString());

                bool IsVehIncen = false;
                Session["Incentive_isVehicle"] = IsVehIncen = Convert.ToBoolean(dt.Rows[0]["isVehicleIncentive"].ToString());
                rblVeh.SelectedValue = (IsVehIncen ? "0" : "1");

                txtvehicleRegistratioNumber.Text = dt.Rows[0]["VehicleNumber"].ToString().Trim();

                txtDateofCommencement.Text = dt.Rows[0]["DCP"].ToString().Trim();

                bool IsGHMC = Convert.ToBoolean(dt.Rows[0]["IsGHMCandOtherMuncpOrp"].ToString());
                rblGHMC.SelectedValue = (IsGHMC ? "0" : "1");

                cbDiffAbled_CheckedChanged(sender, e);
            }
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void ddlLandStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            if (ddlLandStatus.SelectedValue == "1" || ddlLandStatus.SelectedValue == "2")
            {
                txtLandValue.Text = "0";
            }
            txtTotalValueCalculation(sender, e);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }

    protected void ddlBuidingStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlBuidingStatus.SelectedValue == "1" || ddlBuidingStatus.SelectedValue == "2")
            {
                txtBuildingValue.Text = "0";
            }
            txtTotalValueCalculation(sender, e);
        }
        catch (Exception ex) { Errors.ErrorLog_MeeSeva(ex); }
    }
}