using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class UI_TSiPASS_ApplyAdvertisement : System.Web.UI.Page
{

    comFunctions cmf = new comFunctions();
    Cls_OSAdvertisement obj_adv = new Cls_OSAdvertisement();
    int advertisementid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");
        }
        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                BindDistricts();
                bindMandal();
                BindVillage();
                FillDetails();
            }
        }

    }

    public void BindDistricts()
    {
        try
        {
            ddl_district.Items.Clear();
            ddl_mandal.Items.Clear();
            ddl_village.Items.Clear();
            //DataSet dsd = new DataSet();

            //dsd = obj_adv.GetDistricts_adv();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "ADVERTISEMENT");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddl_district.DataSource = dsd.Tables[0];
                ddl_district.DataValueField = "District_Id";
                ddl_district.DataTextField = "District_Name";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, "0");
            }
            else
            {
                //ddl_district.Items.Insert(0, "--District--");
                ddl_district.Items.Insert(0, "0");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void bindMandal()
    {

        ddl_mandal.Items.Clear();
        ddl_village.Items.Clear();
        ddl_village.Items.Insert(0, "--Village--");
        DataSet dsm = new DataSet();
        dsm = obj_adv.GetMandalsbydistid_adv(ddl_district.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddl_mandal.DataSource = dsm.Tables[0];
            ddl_mandal.DataValueField = "Mandal_Id";
            ddl_mandal.DataTextField = "Manda_lName";
            ddl_mandal.DataBind();
            ddl_mandal.Items.Insert(0, "0");
        }
        else
        {
            ddl_mandal.Items.Clear();
            ddl_mandal.Items.Insert(0, "0");
        }
    }
    public void BindVillage()
    {
        ddl_village.Items.Clear();
        DataSet dsv = new DataSet();
        dsv = obj_adv.GetVillagesbymandalid_adv(ddl_mandal.SelectedValue);
        if (dsv.Tables[0].Rows.Count > 0)
        {
            ddl_village.DataSource = dsv.Tables[0];
            ddl_village.DataValueField = "Village_Id";
            ddl_village.DataTextField = "Village_Name";
            ddl_village.DataBind();
            ddl_village.Items.Insert(0, "0");
        }
        else
        {
            ddl_village.Items.Clear();
            ddl_village.Items.Insert(0, "0");
        }
    }
    protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindMandal();
        BindVillage();
    }
    protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillage();
    }

    protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindvisibletrue();
    }

    public void bindvisibletrue()
    {
        Table1.Visible = true;
        tbl_appdetails.Visible = false;
        tbl_cdmaappdetails.Visible = false;
        tbl_ghmclicenumber.Visible = false;
        tbl_ghmctrade.Visible = false;
        tbl_ghmcarea.Visible = false;
        tbl_ghmcbuildingvalues.Visible = false;
        tbl_ghmcadvcat.Visible = false;
        tbl_ghmcadvmts.Visible = false;
        tbl_ghmcadvfee.Visible = false;
        tbl_cdmaappcontdetails.Visible = false;
        tbl_cdmaadvlocdetails.Visible = false;
        tbl_cdmaadvsubcat.Visible = false;
        tbl_cdmanonhoarding.Visible = false;
        tbl_cdmaadvdates.Visible = false;
        string GHMCFLAG = "Y";
        string CDMAFLAG = "N";
        if (GHMCFLAG == "Y")
        {
            tbl_appdetails.Visible = true;

            tbl_ghmclicenumber.Visible = true;
            tbl_ghmctrade.Visible = true;
            tbl_ghmcarea.Visible = true;
            tbl_ghmcbuildingvalues.Visible = true;
            tbl_ghmcadvcat.Visible = true;
            tbl_ghmcadvmts.Visible = true;
            tbl_ghmcadvfee.Visible = true;

        }
        else if (CDMAFLAG == "Y")
        {
            tbl_appdetails.Visible = true;

            tbl_cdmaappdetails.Visible = true;
            tbl_cdmaappcontdetails.Visible = true;
            tbl_cdmaadvlocdetails.Visible = true;
            tbl_cdmaadvsubcat.Visible = true;
            tbl_cdmanonhoarding.Visible = true;
            tbl_cdmaadvdates.Visible = true;
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

    protected void rbthoarding_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbthoarding.SelectedValue == "H")
        {
            trfacing.Visible = true;
        }
        else
        {
            trfacing.Visible = false;
        }
    }

    protected void ddladvertisementcategoery_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddladvertisementcategoery.SelectedValue == "1")
        {
            ddladvertisementsubcategoery.SelectedValue = "1";
        }
        if (ddladvertisementcategoery.SelectedValue == "2")
        {
            ddladvertisementsubcategoery.SelectedValue = "2";
        }
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (rbthoarding.SelectedValue == "" || rbthoarding.SelectedValue == "null")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select wheather it is Hoarding or Non-Hoarding Advertisement \\n";
            slno = slno + 1;
        }
        if (ddlulb.SelectedValue == "0" || ddlulb.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select ULB type \\n";
            slno = slno + 1;
        }
        if (txtlandmark.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter LandMark of Building/Premises \\n";
            slno = slno + 1;
        }

        if (txtownername.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Owner Name(Building/Premises) \\n";
            slno = slno + 1;
        }
        if (txtdoornmber.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Door Number \\n";
            slno = slno + 1;
        }

        if (txtaddress.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Address \\n";
            slno = slno + 1;
        }

        if (txtbuildingassesmentnumber.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". please enter Building Assessment Number \\n";
            slno = slno + 1;
        }
        if (txtcity.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". please enter city name \\n";
            slno = slno + 1;
        }
        if (ddladvertisementcategoery.SelectedValue == "0" || ddladvertisementcategoery.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Advertisement Categoery \\n";
            slno = slno + 1;
        }
        if (ddladvertisementsubcategoery.SelectedValue == "0" || ddladvertisementsubcategoery.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Advertisement Sub Categoery \\n";
            slno = slno + 1;
        }
        if (txtunitname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Unit Name. \\n";
            slno = slno + 1;
        }
        if (ddllandownership.SelectedValue == "0" || ddllandownership.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Land Ownership Type \\n";
            slno = slno + 1;
        }

        if (txtlengthinmtsornos.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Length(In mtrs). \\n";
            slno = slno + 1;
        }

        if (txtwidthinmts.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Width(In mtrs). \\n";
            slno = slno + 1;
        }

        if (txttotalarea.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Total Area. \\n";
            slno = slno + 1;
        }
        if (txtdetails.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Other Details. \\n";
            slno = slno + 1;
        }
        if (txtstartdate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select start Date. \\n";
            slno = slno + 1;
        }

        if (txtenddate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select End Date. \\n";
            slno = slno + 1;
        }

        if (txtanyotherparticulars.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Details of any other perticulars. \\n";
            slno = slno + 1;
        }
        if (rbthoarding.SelectedValue == "H")
        {

            if (ddlfacing.SelectedValue == "0" || ddlfacing.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Advertisement Hoarding  Facing Direction. \\n";
                slno = slno + 1;
            }
        }


        if (txt_appaddress.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Address. \\n";
            slno = slno + 1;
        }

        if (txt_appmobileno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile No. \\n";
            slno = slno + 1;
        }

        if (txt_appemail.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Email. \\n";
            slno = slno + 1;
        }

        if (txt_appdoorno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Door No. \\n";
            slno = slno + 1;
        }

        if (txt_Appstreet.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Street. \\n";
            slno = slno + 1;
        }
        if (txt_AppCity.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter City. \\n";
            slno = slno + 1;
        }

        if (txt_applicantsurname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Surname. \\n";
            slno = slno + 1;
        }

        if (txt_applicantName.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name. \\n";
            slno = slno + 1;
        }

        if (txt_pannumber.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Pan Number. \\n";
            slno = slno + 1;
        }

        if (txt_AdharNumber.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Adhar Number. \\n";
            slno = slno + 1;
        }

        if (ddl_district.SelectedValue == "" || ddl_district.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select District. \\n";
            slno = slno + 1;
        }

        if (ddl_mandal.SelectedValue == "" || ddl_mandal.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Mandal. \\n";
            slno = slno + 1;
        }

        if (ddl_village.SelectedValue == "" || ddl_village.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Mandal. \\n";
            slno = slno + 1;
        }

        if (ddl_district.SelectedItem.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District Name. \\n";
            slno = slno + 1;
        }
        if (ddl_mandal.SelectedItem.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Name. \\n";
            slno = slno + 1;
        }
        if (ddl_village.SelectedItem.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select village Name. \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave.Text == "Save")
        {
            //string errormsg = ValidateControls();
            //if (errormsg.Trim().TrimStart() != "")
            //{
            //    string message = "alert('" + errormsg + "')";
            //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //    return;
            //}
            //else
            //{
                Response objResp = new Response();
                objResp = InsertupdateAdevertisment();
                if (objResp.ResponseVal == true)
                {
                    hdfFlagID0.Value = advertisementid.ToString();
                    Response.Write("Submitted Successfully.....");

                    // BtnSave.Enabled = false;
                    BtnClear.Enabled = false;
                    btnNext.Enabled = true;
                    btnNext.Visible = true;


                }
                //if (!string.IsNullOrEmpty(result))
                //{
                //    if (Convert.ToInt32(result) > 0)
                //    {
                //        Response.Redirect("frmPaymentAdvertisement.aspx?intApplicationId=" + result);
                //        lblmsg.Text = "<font color='green'> Advertisement Details Saved Successfully..!</font>";
                //        success.Visible = true;
                //        Failure.Visible = false;

                //    }
                //    else
                //    {
                //        // Response.Redirect("frmPaymentAdvertisement.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                //        success.Visible = false;
                //        Failure.Visible = true;
                //        lblmsg.Text = "<font color='green'> Advertisement Details Submission Failed..!</font>";
                //    }
                //}
                //else
                //{
                //    success.Visible = false;
                //    Failure.Visible = true;
                //    lblmsg.Text = "<font color='green'> Advertisement Details  Submission Failed..!</font>";
                //}
            //}
        }
    }

    public Response InsertupdateAdevertisment()
    {
        AdvertismentDetailsobj obj = new AdvertismentDetailsobj();
        obj.Wheatherhoardinggornonhoarding = Convert.ToString(rbthoarding.SelectedValue);
        obj.Ulbname_cdma = Convert.ToString(ddlulb.SelectedValue);
        obj.Landmark_cdma = Convert.ToString(txtlandmark.Text);
        obj.Ownername_cdma = Convert.ToString(txtownername.Text);
        obj.Doornumber_cdma = Convert.ToString(txtdoornmber.Text);
        obj.Address_cdma = Convert.ToString(txtaddress.Text);
        obj.Assesmentnumber_cdma = Convert.ToString(txtbuildingassesmentnumber.Text);
        obj.city_cdma = Convert.ToString(txtcity.Text);
        obj.Advertisementcategoery_cdma = Convert.ToString(ddladvertisementcategoery.SelectedValue);
        obj.Advertisementsubcategoery_cdma = Convert.ToString(ddladvertisementsubcategoery.SelectedValue);
        obj.Unitname_cdma = Convert.ToString(txtunitname.Text);
        obj.Landownership_cdma = Convert.ToString(ddllandownership.SelectedValue);
        obj.Lengthinmtrs_cdma = Convert.ToString(txtlengthinmtsornos.Text);
        obj.Widthinmtrs_cdma = Convert.ToString(txtwidthinmts.Text);
        obj.Totalarea_cdma = Convert.ToString(txttotalarea.Text);
        obj.Details_cdma = Convert.ToString(txtdetails.Text);
        obj.Startdate_cdma = txtstartdate.Text;
        obj.Enddate_cdma = txtenddate.Text;
        obj.locality = ddllocality.SelectedValue;
        obj.zone = ddlzone.SelectedValue;
        obj.ward = ddlward.SelectedValue;
        obj.blockno = ddlblocknumber.SelectedValue;
        obj.Anyotherperticulars = Convert.ToString(txtanyotherparticulars.Text);
        obj.Facing_cdma = Convert.ToString(ddlfacing.SelectedValue);
        obj.Advertisement_CDMAFLAG = "N";
        obj.advertisementid = Convert.ToString(hdnidentityid.Value);
        obj.Created_by = Convert.ToString(Session["uid"]);
        obj.Email = Convert.ToString(txt_appemail.Text);
        obj.tradelicenseno = Convert.ToString(txttradelicenseno.Text);
        obj.MobileNumber = Convert.ToString(txt_appmobileno.Text);
        obj.AddressWithContact = Convert.ToString(txt_appaddress.Text);
        obj.Created_IP = Convert.ToString(Request.ServerVariables["Remote_Addr"]);
        obj.ApplicantDoorNo = Convert.ToString(txt_appdoorno.Text);
        obj.ApplicantStreetName = Convert.ToString(txt_Appstreet.Text);
        obj.ApplicantCity = Convert.ToString(txt_AppCity.Text);
        obj.ApplicantSurName = Convert.ToString(txt_applicantsurname.Text);
        obj.ApplicantName = Convert.ToString(txt_applicantName.Text);
        obj.ApplicantPanNumber = Convert.ToString(txt_pannumber.Text);
        obj.ApplicantAdharno = Convert.ToString(txt_AdharNumber.Text);
        obj.ApplicantDistID = Convert.ToString(ddl_district.SelectedValue);
        obj.ApplicantMandalID = Convert.ToString(ddl_mandal.SelectedValue);
        obj.ApplicantVillageID = Convert.ToString(ddl_village.SelectedValue);
        obj.ApplicantDistName = Convert.ToString(ddl_district.SelectedItem.Text);
        obj.ApplicantMandaltName = Convert.ToString(ddl_mandal.SelectedItem.Text);
        obj.ApplicantVillageName = Convert.ToString(ddl_village.SelectedItem.Text);

        obj.istradelicencse = Convert.ToString(rbd_tradelicensenumber.Checked);
        obj.isprovisionallicencse = Convert.ToString(rdb_provisionallicense.Checked);
        obj.iswithoutlicencse = Convert.ToString(rdb_withoutlicense.Checked);
        obj.ghmctradename = Convert.ToString(txt_ghmctradename.Text);
        obj.ghmctradelicensenumber = Convert.ToString(txt_ghmctradelicensenumber.Text);
        obj.ghmcaddress = Convert.ToString(txt_ghmcaddress.Text);
        obj.ghmcarea = Convert.ToString(ddl_ghmcarea.SelectedValue);
        obj.ghmclocality = Convert.ToString(txt_ghmclocality.Text);
        obj.ghmcheightofbuilding = Convert.ToString(txt_ghmcheightofbuilding.Text);
        obj.ghmcwidthofbuilding = Convert.ToString(txt_ghmcwidthofbuilding.Text);
        obj.ghmctradepermisearea = Convert.ToString(txt_ghmctradepermisearea.Text);
        obj.ghmcadvertismenttype = Convert.ToString(ddl_ghmcadvertismenttype.SelectedValue);
        obj.ghmcadvertismentcontent = Convert.ToString(txt_ghmcadvertismentcontent.Text);
        obj.ghmccategory = Convert.ToString(txt_ghmccategory.Text);

        obj.ghmcemd = Convert.ToString(txt_ghmcemd.Text);
        obj.ghmcadvehight = Convert.ToString(txt_ghmcadvehight.Text);
        obj.ghmcadvwidth = Convert.ToString(txt_ghmcadvwidth.Text);
        obj.IS_ghmcfirsttime = Convert.ToString(rdb_ghmcfirsttime.SelectedValue);
        obj.ghmcadvertismentrate = Convert.ToString(txt_ghmcadvertismentrate.Text);
        obj.ghmcadvfee = Convert.ToString(txt_ghmcadvfee.Text);
        obj.ghmcadvphoto = Convert.ToString(HyperLinkProofofAddress.NavigateUrl);




        Response result = obj_adv.InsertAdvertisementSOA(obj, out advertisementid);



        return result;

    }


    void FillDetails()
    {
        BindDistricts();
        bindMandal();
        BindVillage();

        DataSet ds = new DataSet();
        try
        {
            ds = obj_adv.RetriveAdvertisement(Convert.ToString(Session["uid"]));
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["AdvertisementID_SO"]);
                rbthoarding.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Wheatherhoardinggornonhoarding"]);
                ddlulb.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Ulbname_cdma"]);
                txtlandmark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Landmark_cdma"]);
                txtownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ownername_cdma"]);
                txtdoornmber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Doornumber_cdma"]);
                txtaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address_cdma"]);
                txtbuildingassesmentnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Assesmentnumber_cdma"]);
                txtcity.Text = Convert.ToString(ds.Tables[0].Rows[0]["city_cdma"]);
                ddladvertisementcategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Advertisementcategoery_cdma"]);
                ddladvertisementsubcategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Advertisementsubcategoery_cdma"]);
                txtunitname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Unitname_cdma"]);
                ddllandownership.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Landownership_cdma"]);
                txtlengthinmtsornos.Text = Convert.ToString(ds.Tables[0].Rows[0]["Lengthinmtrs_cdma"]);
                txtwidthinmts.Text = Convert.ToString(ds.Tables[0].Rows[0]["Widthinmtrs_cdma"]);
                txttotalarea.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalarea_cdma"]);
                txtdetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["Details_cdma"]);
                txtstartdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Startdate"]);
                txtenddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Enddate"]);
                txtanyotherparticulars.Text = Convert.ToString(ds.Tables[0].Rows[0]["Anyotherperticulars"]);
                if (rbthoarding.SelectedValue == "H")
                {
                    trfacing.Visible = true;
                    ddlfacing.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Facing_cdma"]);
                }
                txt_appemail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                txt_appmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNumber"]);
                txt_appaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["AddressWithContact"]);
                txt_appdoorno.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantDoorNo"]);
                txt_Appstreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantStreetName"]);
                txt_AppCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantCity"]);
                txt_applicantsurname.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantSurName"]);
                txt_applicantName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                txt_pannumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantPanNumber"]);
                txt_AdharNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantAdharno"]);
                ddl_district.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantDistID"]);
                ddl_district_SelectedIndexChanged(this, EventArgs.Empty);
                ddl_mandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMandalID"]);
                ddl_mandal_SelectedIndexChanged(this, EventArgs.Empty);
                ddl_village.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantVillageID"]);
                //ddllocality.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["ApplicantVillageID"]);

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



    protected void btnNext0_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyAdvertisement.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        //string errormsg = ValidateControls();
        //if (errormsg.Trim().TrimStart() != "")
        //{
        //    string message = "alert('" + errormsg + "')";
        //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //    return;
        //}
        //else
        //{
            Response objResp = new Response();
            objResp = InsertupdateAdevertisment();
            if (objResp.ResponseVal == true)
            {
                hdfFlagID0.Value = advertisementid.ToString();
                Response.Write("Submitted Successfully.....");

                // BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnNext.Enabled = true;
                btnNext.Visible = true;


            }

            if (hdfFlagID0.Value.ToString().Trim() == "" || hdfFlagID0.Value.Trim() == "0")
            {
                Response.Redirect("frmDraftQuestionnaireTourisamEvent.aspx");
            }
            else
            {
                Response.Redirect("frmPaymentAdvertisement.aspx");
            }
       // }
    }

    protected void btn_ghmcuploadphoto_Click(object sender, EventArgs e)
    {
        string newPath = "";
        // string sFileDir = @"D:\TS-iPASSFinal\Attachments";
        string SubFolder = @"\ADVERISMENT\" + Session["uid"].ToString();
        General.FileResult objfileResult = new General.FileResult();
        General Gen = new General();
        string[] extensions = { ".pdf", ".jpg", ".jpeg" };
        objfileResult = Gen.SaveFile(fpd_ghmcadvphoto, SubFolder, "GHMCPHOTO");

        if (objfileResult.Result == true)
        {
            HyperLinkProofofAddress.Visible = true;
            HyperLinkProofofAddress.NavigateUrl = objfileResult.FilePath;
            hdnProofofAddressType.Value = objfileResult.FileType;
            hdnFileNameProofofAddress.Value = objfileResult.FileName;
            fpd_ghmcadvphoto.Visible = true;
            btn_ghmcuploadphoto.Visible = true;
            lbl_ghmcadvphotoname.Text = objfileResult.FileName;
        }
        else
        {

            HyperLinkProofofAddress.NavigateUrl = objfileResult.FilePath;
            lbl_ghmcadvphotoname.Text = objfileResult.Message;
        }
    }

}