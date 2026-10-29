using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmFilmShootingApplication : System.Web.UI.Page
{
    decimal Servicefee;
    decimal Policefee;
    decimal policeConstablefee;
    decimal policeApplicationfee;
    decimal servicstax;
    string Ishoursbased;
    decimal ExtraHoursFee;
    string Departmentid;

    comFunctions cmf = new comFunctions();
    General Gen = new General();
    Cls_Filmshooting objFilmShooting = new Cls_Filmshooting();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            BindAgencyDistricts();
            BindTempDistricts();
            BindProducerDistricts();
            BindLocationNames();
            FillDetails();

        }



        //if (!IsPostBack)
        //{


        //    DataSet dsnew = new DataSet();
        //    dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "426");
        //    if (dsnew.Tables[0].Rows.Count > 0)
        //    {

        //    }

        //    else
        //    {
        //        if (Request.QueryString[1].ToString() == "N")
        //        {

        //            Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

        //        }
        //        else
        //        {
        //            Response.Redirect("frmPoliceAttachments.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

        //        }

        //    }
        //}

    }
    public void BindAgencyDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "FILM");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldist_agency.DataSource = dsTypes.Tables[0];
            ddldist_agency.DataTextField = "District_Name";
            ddldist_agency.DataValueField = "District_Id";
            ddldist_agency.DataBind();

            ddldist_agency.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public void BindTempDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "FILM");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldistrict_temp.DataSource = dsTypes.Tables[0];
            ddldistrict_temp.DataTextField = "District_Name";
            ddldistrict_temp.DataValueField = "District_Id";
            ddldistrict_temp.DataBind();

            ddldistrict_temp.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public void BindProducerDistricts()
    {
        //DataSet dsTypes = new DataSet();
        //dsTypes = Gen.GetDistricts();
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsTypes = new DataSet();
        dsTypes = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "FILM");
        if (dsTypes.Tables[0].Rows.Count > 0)
        {
            ddldistrict_producer.DataSource = dsTypes.Tables[0];
            ddldistrict_producer.DataTextField = "District_Name";
            ddldistrict_producer.DataValueField = "District_Id";
            ddldistrict_producer.DataBind();

            ddldistrict_producer.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public void BindLocationNames()
    {
        DataSet dslocnames = new DataSet();
        dslocnames = GetLocationnames();
        if (dslocnames.Tables[0].Rows.Count > 0)
        {
            ddllocationname.DataSource = dslocnames.Tables[0];
            ddllocationname.DataTextField = "location_name";
            ddllocationname.DataValueField = "location_id";
            ddllocationname.DataBind();

            ddllocationname.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    public DataSet GetLocationnames()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GetLocations");
        return Dsnew;
    }
    void FillDetails()
    {
        int CreatedBy = Convert.ToInt32(Session["uid"]);
        DataSet ds = new DataSet();


        //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

        //if (Request.QueryString[1].ToString() != "")
        if (Request.QueryString.Count>0)
        {
            ds = objFilmShooting.RetriveFilmShootingDetails(CreatedBy, Request.QueryString[1].ToString());
        }
        else
        {
            ds = objFilmShooting.RetriveFilmShootingDetails(CreatedBy, "");
        }
        if (ds.Tables.Count > 0)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["App_Status"]);
                if (App_Status == "2")
                {
                    btnPayment.Visible = true;

                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["intfilmshootingid"]);
                    hdnTransactionNumber.Value = Convert.ToString(ds.Tables[0].Rows[0]["intfilmshootingid"]);

                    //hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["intfilmshootingid"]);

                    txtcompanyGstin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CompanyGSTIN"]);

                    txtproducername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Produccername"]);

                    rbttradebody.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Tradebody"]);
                    if (rbttradebody.SelectedValue == "Y")
                    {
                        trtradebodydetails.Visible = true;
                        txttradebodydetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["Tradebodydetails"]);
                    }
                    txtfilmtitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["Filmtitle"]);

                    ddllanguage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Filmlanguage"]);
                    if (ddllanguage.SelectedValue == "4")
                    {
                        trotherlanguage.Visible = true;
                        txtotherlanguage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Otherlanguage"]);
                    }

                    ddlfilmType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Filmtype"]);
                    if (ddlfilmType.SelectedValue == "5")
                    {
                        trotherfilmtype.Visible = true;
                        txtotherfilmtype.Text = Convert.ToString(ds.Tables[0].Rows[0]["Othertype"]);
                    }

                    ddlshootingtime.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Shootingtime"]);

                    txtdirector.Text = Convert.ToString(ds.Tables[0].Rows[0]["Director"]);

                    txtcameraman.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cameraman"]);

                    txtmainartists.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mainartists"]);

                    txttotalcrewno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalcrewno"]);

                    txtproposedshootingscheduule.Text = Convert.ToString(ds.Tables[0].Rows[0]["Proposedshootingschedule"]);


                    ddllocationname.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["LocationnameId"]);

                    txtfromdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["startdate"]);

                    txttodate.Text = Convert.ToString(ds.Tables[0].Rows[0]["enddate"]);

                    txtblockingdays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Blockingdays"]);

                    txtshootingdays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shootingdays"]);

                    txtnoofpolicepersionsrequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["Noofpolicepersions"]);

                    txtpriceperlocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Priceperlocation"]);

                    txtshootingfee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Shootingfee"]);

                    txtcautiondeposit.Text = Convert.ToString(ds.Tables[0].Rows[0]["Cautionfee"]);

                    txtservicefee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Servicefee"]);

                    txtpolicefee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Policefee"]);

                    txtgst.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gst"]);

                    txtextrahorsamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Extrahoursamount"]);

                    txttotalamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalamount"]);

                    string chekdepartmentname = Convert.ToString(ds.Tables[0].Rows[0]["Departmentname_termsconditionsFLAG"]);
                    if (chekdepartmentname == "Y")
                    {
                        chkdepartmentname.Checked = true;
                        lbldepartmentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["department_name"]);
                    }

                    string chektermandconditions = Convert.ToString(ds.Tables[0].Rows[0]["FilmDevelopmentCorporationFLAG"]);

                    if (chektermandconditions == "Y")
                    {
                        chktermsandconditions.Checked = true;
                    }
                    string chekparticularsfurnished = Convert.ToString(ds.Tables[0].Rows[0]["ParticularsFurnishedFLAG"]);
                    if (chekparticularsfurnished == "Y")
                    {
                        chkparticularsfurnished.Checked = true;
                    }
                    string chekundertaking = Convert.ToString(ds.Tables[0].Rows[0]["ReimbursetheDamageFLAG"]);
                    if (chekundertaking == "Y")
                    {
                        chkundertake.Checked = true;
                    }
                    txtnameofproductionagency.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProductionAgencyName"]);
                    ddldist_agency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Permanent_District"]);
                    ddldist_agency_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlmandal_agency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Permanent_Mandal"]);
                    ddlmandal_agency_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlvillage_agency.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Permanent_Village"]);
                    txtplotnumber_agency.Text = Convert.ToString(ds.Tables[0].Rows[0]["Permanent_PlotNo"]);
                    txtpincode_agency.Text = Convert.ToString(ds.Tables[0].Rows[0]["Permanent_PINCODE"]);
                    if (ds.Tables[0].Rows[0]["CkeckSameasaddress"].ToString() == "Y")
                    {
                        checkaddress.Checked = true;
                    }
                    else
                    {
                        checkaddress.Checked = false;
                    }
                    ddldistrict_temp.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_District"]);
                    ddldistrict_temp_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlmandal_temp.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_Mandal"]);
                    ddlmandal_temp_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlvillage_temp.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_Village"]);
                    txtplotno_temp.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PlotNo"]);
                    txtpincode_temp.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PINCODE"]);

                    txtphno1_agency.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgencyPhno1"]);
                    txtphno2_agency.Text = Convert.ToString(ds.Tables[0].Rows[0]["AgencyPhno2"]);

                    ddldistrict_producer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_District"]);
                    ddldistrict_producer_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlmandal_prodcer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_Mandal"]);
                    ddlmandal_prodcer_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlvillage_prodcer.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_Village"]);
                    txtplotno_producer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PlotNo"]);
                    txtpincode_producer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PINCODE"]);

                    txtphno1_producer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PINCODE"]);
                    txtphno2_producer.Text = Convert.ToString(ds.Tables[0].Rows[0]["Temperory_PINCODE"]);
                    txtemailid_producer.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProducerEmailId"]);

                    txtapplicantname.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                    txtapplicantmobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantMobileNo"]);
                    lbldepartmentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["department_name"]);
                    ViewState["departmentid"] = Convert.ToString(ds.Tables[0].Rows[0]["dept_id"]);
                }
            }
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
    protected void ddllanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddllanguage.SelectedValue == "4")
        {
            trotherlanguage.Visible = true;
        }
        else
        {
            trotherlanguage.Visible = false;
        }
    }

    protected void ddlfilmType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfilmType.SelectedValue == "5")
        {
            trotherfilmtype.Visible = true;
        }
        else
        {
            trotherfilmtype.Visible = false;
        }
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtcompanyGstin.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter company GSTIN number \\n";
            slno = slno + 1;
        }

        if (txtproducername.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter producer name \\n";
            slno = slno + 1;
        }
        if (rbttradebody.SelectedValue == "0" || rbttradebody.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Whether a member of any Trade-body or not \\n";
            slno = slno + 1;
        }
        if (rbttradebody.SelectedValue == "Y")
        {
            if (txttradebodydetails.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter trade body details \\n";
                slno = slno + 1;
            }
        }
        if (txtfilmtitle.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter film title \\n";
            slno = slno + 1;
        }
        if (ddllanguage.SelectedValue == "0" || ddllanguage.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select film language \\n";
            slno = slno + 1;
        }
        if (ddllanguage.SelectedValue == "")
        {
            if (txtotherlanguage.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter other language \\n";
                slno = slno + 1;
            }
        }
        if (ddlfilmType.SelectedValue == "" || ddlfilmType.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select type of film \\n";
            slno = slno + 1;
        }
        if (ddlfilmType.SelectedValue == "5")
        {
            if (txtotherfilmtype.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter other type of film \\n";
                slno = slno + 1;
            }
        }
        if (ddlshootingtime.SelectedValue == "0" || ddlshootingtime.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select shooting time \\n";
            slno = slno + 1;
        }

        if (txtdirector.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter director name \\n";
            slno = slno + 1;
        }

        if (txtcameraman.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter cameraman name \\n";
            slno = slno + 1;
        }

        if (txtmainartists.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter all main artists names \\n";
            slno = slno + 1;
        }

        if (txttotalcrewno.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter total no of crew in film shooting \\n";
            slno = slno + 1;
        }

        if (txtproposedshootingscheduule.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter roposed shooting Schedule in detail (indoor/outdoor/ Song/scene) with description\\n";
            slno = slno + 1;
        }
        if (ddllocationname.SelectedValue == "0" || ddllocationname.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select location name \\n";
            slno = slno + 1;
        }

        if (txtfromdate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select start date \\n";
            slno = slno + 1;
        }
        if (txttodate.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select end date \\n";
            slno = slno + 1;
        }

        if (txtshootingdays.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of shooting days \\n";
            slno = slno + 1;
        }
        if (txtnoofpolicepersionsrequired.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter no of police persions required \\n";
            slno = slno + 1;
        }

        if (chkdepartmentname.Checked == false)
        {
            ErrorMsg = ErrorMsg + slno + ". Please confirm wheather you agreee to the terms & conditions of concern department. \\n";
            slno = slno + 1;
        }
        if (chktermsandconditions.Checked == false)
        {
            ErrorMsg = ErrorMsg + slno + ". Please confirm wheather you accept Film Development Corporation Terms and conditions. \\n";
            slno = slno + 1;
        }
        if (chkparticularsfurnished.Checked == false)
        {
            ErrorMsg = ErrorMsg + slno + ". Please confirm wheather  that the particulars furnished above are true. \\n";
            slno = slno + 1;
        }
        if (chkundertake.Checked == false)
        {
            ErrorMsg = ErrorMsg + slno + ". Please confirm you undertake to reimburse the damages caused if any, during the " +
                "above film shooting from the caution deposit amount to the respective department/organization/Institution. \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {



        if (BtnSave1.Text == "Save")
        {

            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            string chkdeptnameid;
            if (chkdepartmentname.Checked == true)
            {
                chkdeptnameid = "Y";
            }
            else
            {
                chkdeptnameid = "N";
            }
            string termscondionsid;
            if (chktermsandconditions.Checked == true)
            {
                termscondionsid = "Y";
            }
            else
            {
                termscondionsid = "N";
            }
            string particlarsid;
            if (chkparticularsfurnished.Checked == true)
            {
                particlarsid = "Y";
            }
            else
            {
                particlarsid = "N";
            }
            string undertakingid;
            if (chkundertake.Checked == true)
            {
                undertakingid = "Y";
            }
            else
            {
                undertakingid = "N";
            }
            string chkaddress;
            if (checkaddress.Checked == true)
            {
                chkaddress = "Y";
            }
            else
            {
                chkaddress = "N";
            }
            try
            {
                string deptid = ViewState["departmentid"].ToString();
                Response objres = new Response();
                int filmshootingid = 0;
                objres = objFilmShooting.InsertFilmShootingDetails(txtcompanyGstin.Text, txtproducername.Text,
                    rbttradebody.SelectedValue, txttradebodydetails.Text, txtfilmtitle.Text, ddllanguage.SelectedValue, txtotherlanguage.Text,
                    ddlfilmType.SelectedValue, txtotherfilmtype.Text, ddlshootingtime.SelectedValue,
                    txtdirector.Text, txtcameraman.Text, txtmainartists.Text, txttotalcrewno.Text,
                    txtproposedshootingscheduule.Text, out filmshootingid, ddllocationname.SelectedItem.Text, ddllocationname.SelectedValue,
                    txtfromdate.Text, txttodate.Text, txtblockingdays.Text, txtshootingdays.Text, txtnoofpolicepersionsrequired.Text,
                    txtpriceperlocation.Text, txtshootingfee.Text, txtcautiondeposit.Text, txtservicefee.Text, txtpolicefee.Text, txtgst.Text, txtextrahorsamount.Text,

                    txttotalamount.Text, Session["uid"].ToString(), chkdeptnameid, termscondionsid, particlarsid, undertakingid, ViewState["departmentid"].ToString(), lbldepartmentname.Text, 
                    txtnameofproductionagency.Text, ddldist_agency.SelectedValue, ddlmandal_agency.SelectedValue,
                    ddlvillage_agency.SelectedValue, txtpincode_agency.Text, txtplotnumber_agency.Text, chkaddress, ddldistrict_temp.SelectedValue, ddlmandal_temp.SelectedValue, ddlvillage_temp.SelectedValue,
                    txtpincode_temp.Text, txtplotno_temp.Text, txtphno1_agency.Text, txtphno2_agency.Text,
                    ddldistrict_producer.SelectedValue, ddlmandal_prodcer.SelectedValue, ddlvillage_prodcer.SelectedValue,
                    txtplotno_producer.Text, txtpincode_producer.Text, txtphno1_producer.Text, txtphno2_producer.Text, txtemailid_producer.Text, txtapplicantname.Text, txtapplicantmobileno.Text);
                Session["Applid"] = filmshootingid;
                if (objres.ResponseVal == true)
                {
                    hdnTransactionNumber.Value = filmshootingid.ToString();
                    Response.Write("Submitted Successfully.....");
                    // BtnSave.Enabled = false;
                    BtnClear.Enabled = false;
                    btnPayment.Enabled = true;
                    btnPayment.Visible = true;



                }
            }
            catch (Exception ex)
            {
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }

        }
    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmAdvertisement.aspx?intApplicationId=" + hdnapplicationid.Value + "&Previous=" + "P");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {


        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        string chkdeptnameid;
        if (chkdepartmentname.Checked == true)
        {
            chkdeptnameid = "Y";
        }
        else
        {
            chkdeptnameid = "N";
        }
        string termscondionsid;
        if (chktermsandconditions.Checked == true)
        {
            termscondionsid = "Y";
        }
        else
        {
            termscondionsid = "N";
        }
        string particlarsid;
        if (chkparticularsfurnished.Checked == true)
        {
            particlarsid = "Y";
        }
        else
        {
            particlarsid = "N";
        }
        string undertakingid;
        if (chkundertake.Checked == true)
        {
            undertakingid = "Y";
        }
        else
        {
            undertakingid = "N";
        }
        string chkaddress;
        if (checkaddress.Checked == true)
        {
            chkaddress = "Y";
        }
        else
        {
            chkaddress = "N";
        }
        try
        {

            Response objres = new Response();
            int filmshootingid = 0;
            objres = objFilmShooting.InsertFilmShootingDetails(txtcompanyGstin.Text, txtproducername.Text,
                rbttradebody.SelectedValue, txttradebodydetails.Text, txtfilmtitle.Text, ddllanguage.SelectedValue, txtotherlanguage.Text, ddlfilmType.SelectedValue, txtotherfilmtype.Text, ddlshootingtime.SelectedValue, txtdirector.Text,
                txtcameraman.Text, txtmainartists.Text, txttotalcrewno.Text, txtproposedshootingscheduule.Text,
                out filmshootingid, ddllocationname.SelectedItem.Text, ddllocationname.SelectedValue, txtfromdate.Text, txttodate.Text, txtblockingdays.Text, txtshootingdays.Text, txtnoofpolicepersionsrequired.Text,
                txtpriceperlocation.Text, txtshootingfee.Text, txtcautiondeposit.Text, txtservicefee.Text, txtpolicefee.Text, txtgst.Text, txtextrahorsamount.Text,
                txttotalamount.Text, Session["uid"].ToString(), chkdeptnameid, termscondionsid, particlarsid, undertakingid, ViewState["departmentid"].ToString(), lbldepartmentname.Text, 
                txtnameofproductionagency.Text, ddldist_agency.SelectedValue, ddlmandal_agency.SelectedValue,
                ddlvillage_agency.SelectedValue, txtpincode_agency.Text, txtplotnumber_agency.Text, chkaddress, ddldistrict_temp.SelectedValue, ddlmandal_temp.SelectedValue, ddlvillage_temp.SelectedValue,
                txtpincode_temp.Text, txtplotno_temp.Text, txtphno1_agency.Text, txtphno2_agency.Text,
                ddldistrict_producer.SelectedValue, ddlmandal_prodcer.SelectedValue, ddlvillage_prodcer.SelectedValue,
                txtplotno_producer.Text, txtpincode_producer.Text, txtphno1_producer.Text, txtphno2_producer.Text, txtemailid_producer.Text, txtapplicantname.Text, txtapplicantmobileno.Text);
            Session["Applid"] = filmshootingid;
            if (objres.ResponseVal == true)
            {
                hdnTransactionNumber.Value = filmshootingid.ToString();
                Response.Write("Submitted Successfully.....");
                // BtnSave.Enabled = false;
                BtnClear.Enabled = false;
                btnPayment.Enabled = true;
                btnPayment.Visible = true;

            }
            if (hdnTransactionNumber.Value.ToString().Trim() == "" || hdnTransactionNumber.Value.Trim() == "0")
            {
                Response.Redirect("frmFilmShootingApplication.aspx");
            }
            else
            {
                Response.Redirect("frmPaymentFilmShooting.aspx?intApplicationId=" + hdnTransactionNumber.Value);
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }


    }
    public void ClearAll()
    {
        txtcompanyGstin.Text = "";
        txtproducername.Text = "";
        rbttradebody.ClearSelection();
        txttradebodydetails.Text = "";
        txtfilmtitle.Text = "";
        ddllanguage.ClearSelection();
        txtotherlanguage.Text = "";
        ddlfilmType.ClearSelection();
        txtotherfilmtype.Text = "";
        ddlshootingtime.ClearSelection();
        txtdirector.Text = "";
        txtcameraman.Text = "";
        txtmainartists.Text = "";
        txttotalcrewno.Text = "";
        txtproposedshootingscheduule.Text = "";
        ddllocationname.ClearSelection();
        txtfromdate.Text = "";
        txttodate.Text = "";
        txtblockingdays.Text = "";
        txtshootingdays.Text = "";
        txtnoofpolicepersionsrequired.Text = "";
        txtpriceperlocation.Text = "";
        txtshootingfee.Text = "";
        txtcautiondeposit.Text = "";
        txtservicefee.Text = "";
        txtpolicefee.Text = "";
        txtgst.Text = "";
        txtextrahorsamount.Text = "";
        txttotalamount.Text = "";
        chkdepartmentname.Checked = false;
        chktermsandconditions.Checked = false;
        chkparticularsfurnished.Checked = false;
        chkundertake.Checked = false;
    }
    protected void ddllocationname_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtshootingfee.Text = "";
        txtnoofpolicepersionsrequired.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = ""; txtblockingdays.Text = "";
        txtshootingdays.Text = "";
        txtservicefee.Text = "";
        txtpolicefee.Text = "";
        txtgst.Text = "";
        txttotalamount.Text = "";
        try
        {
            Bindpolicefee();
        }
        catch (Exception ex)
        {
        }
        //DataSet ds = new DataSet();
        //ds = GetLocationRelatedDetails(ddllocationname.SelectedValue);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    lbldepartmentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["department_name"]);
        //    Departmentid = Convert.ToString(ds.Tables[0].Rows[0]["department_id"]);
        //    ViewState["departmentid"] = Departmentid;
        //    txtpriceperlocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["fee_amount"]);
        //    txtcautiondeposit.Text = Convert.ToString(ds.Tables[0].Rows[0]["caution_amount"]);
        //    Servicefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["service_fee"]);
        //    ViewState["servicefee"] = Servicefee;
        //    Policefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["per_day_police_fee"]);
        //    ViewState["policefee"] = Policefee;
        //    policeConstablefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["police_constable_fee"]);
        //    ViewState["policeconstablefee"] = policeConstablefee;
        //    policeApplicationfee = Convert.ToDecimal(ds.Tables[0].Rows[0]["police_application_fee"]);
        //    ViewState["policeapplicationfee"] = policeApplicationfee;
        //    servicstax = Convert.ToDecimal(ds.Tables[0].Rows[0]["service_tax"]);
        //    Ishoursbased = Convert.ToString(ds.Tables[0].Rows[0]["is_hours_based"]);

        //    if (ds.Tables[0].Rows[0]["extra_hour_fee"].ToString() == null || ds.Tables[0].Rows[0]["extra_hour_fee"].ToString() == "")
        //    {
        //        ExtraHoursFee = 0;
        //        txtextrahorsamount.Text = Convert.ToString(ExtraHoursFee);
        //    }
        //    else
        //    {
        //        ExtraHoursFee = Convert.ToDecimal(ds.Tables[0].Rows[0]["extra_hour_fee"]);
        //        txtextrahorsamount.Text = Convert.ToString(ExtraHoursFee);
        //    }
        //}

    }
    public DataSet GetLocationRelatedDetails(string locationid)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@locationid",SqlDbType.VarChar)
       };
        pp[0].Value = locationid;
        Dsnew = Gen.GenericFillDs("GetLocationRelatedDetails", pp);
        return Dsnew;
    }

    protected void txttodate_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = GetBlockingDays(txtfromdate.Text, txttodate.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtblockingdays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Column1"]);
        }
    }
    public DataSet GetBlockingDays(string fromdate, string todate)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@fromdate",SqlDbType.VarChar),
             new SqlParameter("@todate",SqlDbType.VarChar)
       };
        pp[0].Value = fromdate;
        pp[1].Value = todate;
        Dsnew = Gen.GenericFillDs("GetBlockingHours", pp);
        return Dsnew;
    }

    protected void txtshootingdays_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(txtshootingdays.Text) > Convert.ToInt16(txtblockingdays.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Shooting Days cannot be more than Blocking Days')", true);

            txtshootingdays.Text = "";

            return;

        }
        try
        {
            Bindpolicefee();
        }
        catch (Exception ex)
        {
        }
        //txtshootingfee.Text = (Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(txtpriceperlocation.Text)).ToString();
        //txtservicefee.Text = (Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(ViewState["servicefee"])).ToString();
        //txtgst.Text = (Convert.ToDecimal(0.18) * Convert.ToDecimal(txtservicefee.Text)).ToString();
        ////txtpolicefee.Text = ((Convert.ToDecimal(txtnoofpolicepersionsrequired.Text) * Convert.ToDecimal(ViewState["policefee"])) 
        ////    + (Convert.ToDecimal(ViewState["policeapplicationfee"])) + 
        ////    (Convert.ToDecimal(txtnoofpolicepersionsrequired.Text) * Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(ViewState["policeconstablefee"]))).ToString();
        ////txttotalamount.Text = (Convert.ToDecimal(txtshootingfee.Text) + Convert.ToDecimal(txtcautiondeposit.Text) +
        ////            Convert.ToDecimal(txtservicefee.Text) + Convert.ToDecimal(txtpolicefee.Text) + Convert.ToDecimal(txtgst.Text) + Convert.ToDecimal(txtextrahorsamount.Text)).ToString();
    }

    protected void txtnoofpolicepersionsrequired_TextChanged(object sender, EventArgs e)
    {
        try
        {
            Bindpolicefee();
        }
        catch (Exception ex)
        {
        }


        // txtpolicefee.Text = (Convert.ToDecimal(txtnoofpolicepersionsrequired.Text) * Convert.ToDecimal(ViewState["policefee"])).ToString();
        //txtpolicefee.Text = ((Convert.ToDecimal(txtnoofpolicepersionsrequired.Text) * Convert.ToDecimal(ViewState["policefee"]))
        //    + (Convert.ToDecimal(ViewState["policeapplicationfee"])) +
        //    (Convert.ToDecimal(txtnoofpolicepersionsrequired.Text) * Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(ViewState["policeconstablefee"]))).ToString();
        //txttotalamount.Text = (Convert.ToDecimal(txtshootingfee.Text) + Convert.ToDecimal(txtcautiondeposit.Text) +
        //    Convert.ToDecimal(txtservicefee.Text) + Convert.ToDecimal(txtpolicefee.Text) + Convert.ToDecimal(txtgst.Text) + Convert.ToDecimal(txtextrahorsamount.Text)).ToString();
    }

    protected void rbttradebody_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbttradebody.SelectedValue == "Y")
        {
            trtradebodydetails.Visible = true;
            txttradebodydetails.Text = "";

        }
        else
        {
            trtradebodydetails.Visible = false;
            txttradebodydetails.Text = "";
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        ClearAll();
    }

    protected void ddldist_agency_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldist_agency.SelectedIndex == 0)
            {
                ddlmandal_agency.Items.Clear();
                ddlmandal_agency.Items.Insert(0, "--Mandal--");

            }
            else
            {
                ddlmandal_agency.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldist_agency.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal_agency.DataSource = dsm.Tables[0];
                    ddlmandal_agency.DataValueField = "Mandal_Id";
                    ddlmandal_agency.DataTextField = "Manda_lName";
                    ddlmandal_agency.DataBind();
                    ddlmandal_agency.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal_agency.Items.Clear();
                    ddlmandal_agency.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_agency_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal_agency.SelectedIndex == 0)
            {

                ddlvillage_agency.Items.Clear();
                ddlvillage_agency.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage_agency.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal_agency.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage_agency.DataSource = dsv.Tables[0];
                    ddlvillage_agency.DataValueField = "Village_Id";
                    ddlvillage_agency.DataTextField = "Village_Name";
                    ddlvillage_agency.DataBind();
                    ddlvillage_agency.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage_agency.Items.Clear();
                    ddlvillage_agency.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void checkaddress_CheckedChanged(object sender, EventArgs e)
    {
        if (checkaddress.Checked == true)
        {
            ddldistrict_temp.SelectedValue = ddldist_agency.SelectedValue;
            ddldistrict_temp_SelectedIndexChanged(this, EventArgs.Empty);
            ddlmandal_temp.SelectedValue = ddlmandal_agency.SelectedValue;
            ddlmandal_temp_SelectedIndexChanged(this, EventArgs.Empty);
            ddlvillage_temp.SelectedValue = ddlvillage_agency.SelectedValue;
            txtplotno_temp.Text = txtplotnumber_agency.Text;
            txtpincode_temp.Text = txtpincode_agency.Text;
        }
        else
        {
            ddldistrict_temp.SelectedValue = "0";
            ddlmandal_temp.SelectedValue = "0";
            ddlvillage_temp.SelectedValue = "0";
            txtplotno_temp.Text = "";
            txtpincode_temp.Text = "";
        }
    }

    protected void ddldistrict_temp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict_temp.SelectedIndex == 0)
            {
                ddlmandal_temp.Items.Clear();
                ddlmandal_temp.Items.Insert(0, "--Mandal--");

            }
            else
            {
                ddlmandal_temp.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict_temp.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal_temp.DataSource = dsm.Tables[0];
                    ddlmandal_temp.DataValueField = "Mandal_Id";
                    ddlmandal_temp.DataTextField = "Manda_lName";
                    ddlmandal_temp.DataBind();
                    ddlmandal_temp.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal_temp.Items.Clear();
                    ddlmandal_temp.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_temp_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal_temp.SelectedIndex == 0)
            {

                ddlvillage_temp.Items.Clear();
                ddlvillage_temp.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage_temp.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal_temp.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage_temp.DataSource = dsv.Tables[0];
                    ddlvillage_temp.DataValueField = "Village_Id";
                    ddlvillage_temp.DataTextField = "Village_Name";
                    ddlvillage_temp.DataBind();
                    ddlvillage_temp.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage_temp.Items.Clear();
                    ddlvillage_temp.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddldistrict_producer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict_producer.SelectedIndex == 0)
            {
                ddlmandal_prodcer.Items.Clear();
                ddlmandal_prodcer.Items.Insert(0, "--Mandal--");

            }
            else
            {
                ddlmandal_prodcer.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict_producer.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlmandal_prodcer.DataSource = dsm.Tables[0];
                    ddlmandal_prodcer.DataValueField = "Mandal_Id";
                    ddlmandal_prodcer.DataTextField = "Manda_lName";
                    ddlmandal_prodcer.DataBind();
                    ddlmandal_prodcer.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlmandal_prodcer.Items.Clear();
                    ddlmandal_prodcer.Items.Insert(0, "--Mandal--");
                }



            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlmandal_prodcer_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmandal_prodcer.SelectedIndex == 0)
            {

                ddlvillage_prodcer.Items.Clear();
                ddlvillage_prodcer.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage_prodcer.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlmandal_prodcer.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlvillage_prodcer.DataSource = dsv.Tables[0];
                    ddlvillage_prodcer.DataValueField = "Village_Id";
                    ddlvillage_prodcer.DataTextField = "Village_Name";
                    ddlvillage_prodcer.DataBind();
                    ddlvillage_prodcer.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlvillage_prodcer.Items.Clear();
                    ddlvillage_prodcer.Items.Insert(0, "--Village--");
                }
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    public void Bindpolicefee()
    {
        DataSet ds = new DataSet();
        ds = GetPolicefee(txtshootingdays.Text, txtnoofpolicepersionsrequired.Text, ddllocationname.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtpolicefee.Text = ds.Tables[0].Rows[0]["TotalPolicefee"].ToString();
            lbldepartmentname.Text = Convert.ToString(ds.Tables[0].Rows[0]["department_name"]);
            Departmentid = Convert.ToString(ds.Tables[0].Rows[0]["department_id"]);
            ViewState["departmentid"] = Departmentid;
            txtpriceperlocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["fee_amount"]);
            txtcautiondeposit.Text = Convert.ToString(ds.Tables[0].Rows[0]["caution_amount"]);
            Servicefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["service_fee"]);
            Policefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["per_day_police_fee"]);
            policeConstablefee = Convert.ToDecimal(ds.Tables[0].Rows[0]["police_constable_fee"]);
            policeApplicationfee = Convert.ToDecimal(ds.Tables[0].Rows[0]["police_application_fee"]);
            servicstax = Convert.ToDecimal(ds.Tables[0].Rows[0]["service_tax"]);
            Ishoursbased = Convert.ToString(ds.Tables[0].Rows[0]["is_hours_based"]);

            if (ds.Tables[0].Rows[0]["extra_hour_fee"].ToString() == null || ds.Tables[0].Rows[0]["extra_hour_fee"].ToString() == "")
            {
                ExtraHoursFee = 0;
                txtextrahorsamount.Text = Convert.ToString(ExtraHoursFee);
            }
            else
            {
                ExtraHoursFee = Convert.ToDecimal(ds.Tables[0].Rows[0]["extra_hour_fee"]);
                txtextrahorsamount.Text = Convert.ToString(ExtraHoursFee);
            }
            txtshootingfee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalshootingfee"]);
            txtservicefee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalservicefee"]);
            txtgst.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalGSTfee"]);
            txttotalamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["Totalfeeamont"]);

            //txttotalamount.Text = (Convert.ToDecimal(txtshootingfee.Text) + Convert.ToDecimal(txtcautiondeposit.Text) +
            //Convert.ToDecimal(txtservicefee.Text) + Convert.ToDecimal(txtpolicefee.Text) + Convert.ToDecimal(txtgst.Text) + Convert.ToDecimal(txtextrahorsamount.Text)).ToString();
            //txtshootingfee.Text = (Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(txtpriceperlocation.Text)).ToString();
            //txtservicefee.Text = (Convert.ToDecimal(txtshootingdays.Text) * Convert.ToDecimal(ViewState["servicefee"])).ToString();
            //txtgst.Text = (Convert.ToDecimal(0.18) * Convert.ToDecimal(txtservicefee.Text)).ToString();
        }
    }

    public DataSet GetPolicefee(string shootingdays, string noofpolicepersions, string locationid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
       {
             new SqlParameter("@shootingdays",SqlDbType.VarChar),
             new SqlParameter("@noofpolicepersions",SqlDbType.VarChar),
             new SqlParameter("@locationid",SqlDbType.VarChar)
       };
        pp[0].Value = shootingdays;
        pp[1].Value = noofpolicepersions;
        pp[2].Value = locationid;
        Dsnew = Gen.GenericFillDs("GetPoliceFee", pp);
        return Dsnew;
    }
}