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
using System.Globalization;
using System.Net;
using System.Text;

public partial class UI_TSiPASS_frmMSME_edit : System.Web.UI.Page
{
    Cls_MSME obj_msme = new Cls_MSME();
    General Gen = new General();
    CommonBL objcommon = new CommonBL();
    DB.DB con = new DB.DB();
    string MSMENO;
    protected string latitude { get; set; }
    protected string logititude { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0)
        {
            btnsubmit.Enabled = true;

        }
        if (!IsPostBack)
        {
            //hyp_addloc.NavigateUrl ="javascript:Newwindow('frmlocationfrommap.aspx?')";
            //txt_laltuide.Text = Convert.ToString(Session["tsipasslatitude"]);
            //txt_longitude.Text = Convert.ToString(Session["tsipasslongitude"]);
            if (Request.QueryString.Count == 2)
            {
                if (Request.QueryString["Latitude"].ToString() != null)
                {
                    txt_laltuide.Text = Convert.ToString(Request.QueryString["Latitude"]);
                    txt_longitude.Text = Convert.ToString(Request.QueryString["Longitude"]);
                    MSMENO = Convert.ToString(Session["MSMENO"]);
                    ViewState["MSMENO"] = MSMENO;
                    FillDetails(MSMENO);
                }
            }
            else
            {

                // hyp_addloc.NavigateUrl = "javascript:Newwindow('frmlocationfrommap.aspx?')";


            }


            BindConstitutionunit();
            BindDistricts();
            getSectorList();
            loadmandals();
            load_village();
            BindIndustrialParks();
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    MSMENO = Request.QueryString[0].ToString().Trim();
                    ViewState["MSMENO"] = MSMENO;
                    Session["MSMENO"] = MSMENO;
                    FillDetails(MSMENO);
                    //getemployeementtype(MSMENO);
                }
                else
                {
                    Response.Redirect("frmMSMEReportDRILLDOWN.aspx");
                }
            }
            else
            {
                Response.Redirect("frmMSMEReportDRILLDOWN.aspx");
            }
        }
    }

    protected void getemployeementtype(string MsmeNo)
    {
        DataSet dsnew = new DataSet();
        dsnew = obj_msme.getemployeementdatabymsmeno(MsmeNo);
        //grd_employeedetails.DataSource = dsnew.Tables[0];
        //grd_employeedetails.DataBind();
        grd_employeedetails_contract.DataSource = dsnew.Tables[1];
        grd_employeedetails_contract.DataBind();
        grd_employeedetails_outsourcing.DataSource = dsnew.Tables[2];
        grd_employeedetails_outsourcing.DataBind();
    }


    #region getdatadisplay
    public void AddSelect(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    #endregion


    #region Databind
    public void FillDetails(string MSMENO)
    {
        //Request.QueryString[0].ToString().Trim()
        DataSet dsemp = obj_msme.GetMSMEDetailsbyMSMEID(MSMENO);

        if (dsemp.Tables[0].Rows.Count > 0)
        {
            try
            {
                txtUnitName.Text = dsemp.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                txtUAMID.Text = dsemp.Tables[0].Rows[0]["UAM_ID"].ToString();
                ddlCategory.SelectedValue = dsemp.Tables[0].Rows[0]["CATEGOERY_ID"].ToString();
                if (ddlCategory.SelectedValue == "1" || ddlCategory.SelectedValue == "2" || ddlCategory.SelectedValue == "3")
                {
                    Employment1.Visible = true;
                    Employment2.Visible = true;
                    Employment3.Visible = true;
                    Employment4.Visible = true;
                    Employment5.Visible = true;
                }
                else
                {
                    Employment1.Visible = false;
                    Employment2.Visible = false;
                    Employment3.Visible = false;
                    Employment4.Visible = false;
                    Employment5.Visible = false;
                }
                ddldistrict.SelectedValue = dsemp.Tables[0].Rows[0]["DISTRICT_ID"].ToString();
                loadmandals();
                BindIndustrialParks();
                div_industrialparks.Visible = false;
                if (dsemp.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString() == "1")
                {
                    rdunitIEORNOT.SelectedValue = dsemp.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString();
                    if (dsemp.Tables[0].Rows[0]["IndustrialParkID"].ToString() == "" || dsemp.Tables[0].Rows[0]["IndustrialParkID"].ToString() == "--Select" || dsemp.Tables[0].Rows[0]["IndustrialParkID"].ToString() == "0" || dsemp.Tables[0].Rows[0]["IndustrialParkID"].ToString() == "NULL")
                    {
                        ddl_induspark.SelectedValue = "0";
                    }
                    else
                    {
                        div_industrialparks.Visible = true;
                        ddl_induspark.SelectedValue = dsemp.Tables[0].Rows[0]["IndustrialParkID"].ToString();
                    }
                }
                else
                {
                    rdunitIEORNOT.SelectedValue = dsemp.Tables[0].Rows[0]["UNITS_IE_OR_NOT"].ToString();
                }
                if (dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString() == "" || dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString() == "--Select" || dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString() == "0" || dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString() == "NULL")
                {
                    ddlMandal.SelectedValue = "0";
                }
                else
                {
                    ddlMandal.SelectedValue = dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString();
                }
                load_village();
                if (dsemp.Tables[0].Rows[0]["VillageID"].ToString() == "" || dsemp.Tables[0].Rows[0]["VillageID"].ToString() == "--Select" || dsemp.Tables[0].Rows[0]["VillageID"].ToString() == "0" || dsemp.Tables[0].Rows[0]["VillageID"].ToString() == "NULL")
                {
                    ddl_village.SelectedValue = "0";
                }
                else
                {
                    ddl_village.SelectedValue = dsemp.Tables[0].Rows[0]["VillageID"].ToString();
                }


                if (!string.IsNullOrWhiteSpace(Convert.ToString(dsemp.Tables[0].Rows[0]["latitude"])) && Convert.ToString(dsemp.Tables[0].Rows[0]["latitude"]) != " ")
                {
                    this.latitude = Convert.ToString(dsemp.Tables[0].Rows[0]["latitude"]);
                }
                if (!string.IsNullOrWhiteSpace(Convert.ToString(dsemp.Tables[0].Rows[0]["longitude"])) && Convert.ToString(dsemp.Tables[0].Rows[0]["longitude"]) != " ")
                {
                    this.logititude = Convert.ToString(dsemp.Tables[0].Rows[0]["longitude"]);
                }






                txt_houseno.Text = dsemp.Tables[0].Rows[0]["HouseNo"].ToString();
                txt_Locality.Text = dsemp.Tables[0].Rows[0]["Locality"].ToString();
                txt_street.Text = dsemp.Tables[0].Rows[0]["Street"].ToString();
                txt_landmark.Text = dsemp.Tables[0].Rows[0]["LandMark"].ToString();
                txtunitaddress.Text = dsemp.Tables[0].Rows[0]["CompleteAddress"].ToString();
                txtinvestment.Text = dsemp.Tables[0].Rows[0]["Investment"].ToString();
                txtEmployment.Text = dsemp.Tables[0].Rows[0]["EMPLOYMENT"].ToString();
                if (!string.IsNullOrEmpty(dsemp.Tables[0].Rows[0]["PresentStatus"].ToString()))
                {
                    if (dsemp.Tables[0].Rows[0]["PresentStatus"].ToString() == "Working")
                        ddlstatus.SelectedValue = "1";
                    else if (dsemp.Tables[0].Rows[0]["PresentStatus"].ToString() == "Closed")
                        ddlstatus.SelectedValue = "2";
                    else if (dsemp.Tables[0].Rows[0]["PresentStatus"].ToString() == "Other")
                        ddlstatus.SelectedValue = "3";
                    else
                        ddlstatus.SelectedValue = "0";
                }
                else
                {
                    ddlstatus.SelectedValue = "0";
                }
                otherstatus.Visible = false;
                if (ddlstatus.SelectedItem.Text == "Other")
                {
                    txtOtherStatus.Text = dsemp.Tables[0].Rows[0]["OtherPresentStatus"].ToString();
                }
                ddlConst_of_unit.SelectedValue = dsemp.Tables[0].Rows[0]["TYPEOFINDUSTRY"].ToString();
                txtDateOfCommencement.Text = dsemp.Tables[0].Rows[0]["DATEOFCOMMENCEMENT"].ToString();
                RdtypeofConn.SelectedValue = dsemp.Tables[0].Rows[0]["TYPEOFCONNECTION"].ToString();
                rdnUnitExport.SelectedValue = dsemp.Tables[0].Rows[0]["EXPORT"].ToString();
                divcountry.Visible = false;
                if (rdnUnitExport.SelectedValue == "Y")
                {
                    divcountry.Visible = true;
                    txtEXPORTCOUNTRY.Text = dsemp.Tables[0].Rows[0]["EXPORTCOUNTRY"].ToString();
                }
                txtDate.Text = dsemp.Tables[0].Rows[0]["DateofCapture"].ToString();


                txtNameofEntrepreneur.Text = dsemp.Tables[0].Rows[0]["NAME_OF_ENTREPRENEUR"].ToString();
                txtMObileNo.Text = dsemp.Tables[0].Rows[0]["MOBILE_NO"].ToString();
                txtEmail.Text = dsemp.Tables[0].Rows[0]["EMAIL_ID"].ToString();
                ddlCaste.SelectedValue = dsemp.Tables[0].Rows[0]["STATU_S"].ToString();
                ddlDifferentlyabled.SelectedValue = dsemp.Tables[0].Rows[0]["PROMOTERDISABLED"].ToString();
                ddlWomenEnterprenuer.SelectedValue = dsemp.Tables[0].Rows[0]["PROMOTERWOMEN"].ToString();



                ddlSector.SelectedValue = dsemp.Tables[0].Rows[0]["SECTOR"].ToString();
                BindLineofactivity(ddlSector.SelectedValue);
                ddlintLineofActivity.SelectedValue = dsemp.Tables[0].Rows[0]["LINE_OF_ACTIVITY"].ToString();
                ddlCategorybyZone.SelectedValue = dsemp.Tables[0].Rows[0]["PCBCATEGORY"].ToString();
                txtProductSpec.Text = dsemp.Tables[0].Rows[0]["PRODUCT_SPEC"].ToString();


                ddlrawmaterialprocured.SelectedValue = dsemp.Tables[0].Rows[0]["RAWMATERIALPROCURED"].ToString();
                div_rawDistrict.Visible = false;
                div_rawstate.Visible = false;
                div_rawcountry.Visible = false;

                if (ddlrawmaterialprocured.SelectedValue == "31")
                {
                    getdistricts();
                    div_rawDistrict.Visible = true;
                    ddl_rawdistrict.Visible = true;
                    ddl_rawdistrict.SelectedValue = dsemp.Tables[0].Rows[0]["RAWMATERIALDISTRICT"].ToString();
                }
                else if (ddlrawmaterialprocured.SelectedValue == "1")
                {
                    getStatesotherthanTG();
                    ddlState.Visible = true;
                    div_rawstate.Visible = true;
                    ddlState.SelectedValue = dsemp.Tables[0].Rows[0]["RAWMATERIALSTATE"].ToString();
                }
                else if (ddlrawmaterialprocured.SelectedValue == "2")
                {
                    div_rawcountry.Visible = true;
                    txtfromcountry.Text = dsemp.Tables[0].Rows[0]["RAWMATERIALCOUNTRY"].ToString();
                }
                else
                {
                    ddlrawmaterialprocured.SelectedValue = "0";
                }

                txtremarks.Text = dsemp.Tables[0].Rows[0]["REMARKS"].ToString();

                txtskilledcontract.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["skilledcontract"].ToString());
                txtskilledoutsourcing.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["skilledoutsourcing"].ToString());
                txtskilledtotal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["skilledtotal"].ToString());


                txtsemiskilledcontract.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["semiskilledcontract"].ToString());
                txtsemiskilledoutsourcing.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["semiskilledoutsourcing"].ToString());
                txtsemiskilledtotal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["semiskilledtotal"].ToString());

                txtunskilledcontract.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["unskilledcontract"].ToString());
                txtunskilledoutsourcing.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["unskilledoutsourcing"].ToString());
                txtunskilledtotal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["unskilledtotal"].ToString());

                txtmanagerialcontract.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["managerialcontract"].ToString());
                txtmanagerialoutsourcing.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["managerialoutsourcing"].ToString());
                txtmanagerialtotal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["managerialtotal"].ToString());

                txt_totemppfesi.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofempgivenesipf"].ToString());
                txt_totnoofindirectemp.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofempdirect"].ToString());
                txt_noofdirectemp.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofempindirect"].ToString());
                txtmenemp.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofMenemp"].ToString());

                txtlocal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofemplocal"].ToString());
                txtnonlocal.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofempnonlocal"].ToString());
                 txtmigrant.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["Migrantworkman"].ToString());

                txt_totempnopfesi.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofempnotgivenesipf"].ToString());
                txt_totlocalemp.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofemplocal"].ToString());

                txtwomen.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["noofWomenemp"].ToString());
                txttotalemployement.Text = Convert.ToString(dsemp.Tables[0].Rows[0]["totalEmployement"].ToString());
                ddl_village_SelectedIndexChanged(this, EventArgs.Empty);
                if (dsemp.Tables[0].Rows[0]["intcfeid"].ToString() != null && dsemp.Tables[0].Rows[0]["intcfeid"].ToString() != "")
                {
                    ddltsipass.SelectedValue = dsemp.Tables[0].Rows[0]["intcfeid"].ToString();
                }

                //OBJMSMEUNITDETAILS.totalEmployement = Convert.ToString(txttotalemployement.Text = Convert.ToString(dsemp.Tables[0].Rows[0][""].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            GetmsmeAttachments();
            GetProductManfacturedetails();
            getRAWRecords();
        }

    }
    public void GetmsmeAttachments()
    {
        try
        {
            DataSet ds = obj_msme.ViewAttachmetsDatabyMSMEID(Request.QueryString[0].ToString().Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2, senPlanB;
                int i = 0;
                DataTable dt1 = new DataTable();
                dt1.Columns.Add("link");
                dt1.Columns.Add("FileName");
                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    if (sen.Contains("MSMEDocments"))
                    {
                        senPlanB = "";
                        senPlanB = ds.Tables[0].Rows[i][1].ToString();

                        DataRow _row = dt1.NewRow();
                        _row["link"] = sen;
                        _row["FileName"] = senPlanB;
                        dt1.Rows.Add(_row);
                        this.grd_uploadgrid.DataSource = dt1;
                        this.grd_uploadgrid.DataBind();
                    }
                    i++;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        finally
        {

        }
    }
    public void GetProductManfacturedetails()
    {
        try
        {
            DataTable Dt = obj_msme.getProductMANFDETAILSbyMSMEID(Request.QueryString[0].ToString().Trim());
            grd_manufacturedproducts.DataSource = Dt;
            grd_manufacturedproducts.DataBind();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    public void getRAWRecords()
    {
        try
        {
            DataTable dt = obj_msme.getRAWDETAILSbyMSMEID(Request.QueryString[0].ToString().Trim());
            grd_rawmaterial.DataSource = dt;
            grd_rawmaterial.DataBind();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    #endregion


    #region unit details
    public void BindConstitutionunit()
    {
        try
        {
            ddlConst_of_unit.Items.Clear();
            DataSet dsConstofunit = new DataSet();
            dsConstofunit = objcommon.GetConstitutionunit();
            if (dsConstofunit != null && dsConstofunit.Tables.Count > 0 && dsConstofunit.Tables[0].Rows.Count > 0)
            {
                ddlConst_of_unit.DataSource = dsConstofunit.Tables[0];
                ddlConst_of_unit.DataTextField = "ConstitutionUnit";
                ddlConst_of_unit.DataValueField = "CunitId";
                ddlConst_of_unit.DataBind();
                AddSelect(ddlConst_of_unit);
            }
            else
            {
                ddlConst_of_unit.Items.Clear();
                AddSelect(ddlConst_of_unit);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }
    protected void rdunitIEORNOT_SelectedIndexChanged(object sender, EventArgs e)
    {
        div_industrialparks.Visible = false;
        if (rdunitIEORNOT.SelectedValue == "1")
        {
            div_industrialparks.Visible = true;
            BindIndustrialParks();
        }
    }
    public void BindDistricts()
    {
        try
        {
            //DataSet dsd = new DataSet();
            //ddldistrict.Items.Clear();
            //dsd = Gen.GetDistrictsWithoutHYD();
            Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "MSME");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "District_Id";
                ddldistrict.DataTextField = "District_Name";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldistrict.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedIndex > 0)
        {
            div_industrialparks.Visible = false;
            if (rdunitIEORNOT.SelectedValue == "1")
            {
                div_industrialparks.Visible = true;
                BindIndustrialParks();
            }
            loadmandals();
            load_village();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select District');", true);
        }

    }
    public void loadmandals()
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddlMandal.Items.Clear();
                AddSelectForMandal(ddlMandal);
            }
            else
            {
                ddlMandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddldistrict.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlMandal.DataSource = dsm.Tables[0];
                    ddlMandal.DataValueField = "Mandal_Id";
                    ddlMandal.DataTextField = "Manda_lName";
                    ddlMandal.DataBind();
                    AddSelectForMandal(ddlMandal);
                }
                else
                {
                    ddlMandal.Items.Clear();
                    AddSelect(ddlMandal);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }
    public void AddSelectForMandal(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_village();
    }
    public void load_village()
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddl_village.Items.Clear();
                AddSelectForMandal(ddl_village);
            }
            else
            {
                ddl_village.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetVillages(ddlMandal.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddl_village.DataSource = dsm.Tables[0];
                    ddl_village.DataValueField = "Village_Id";
                    ddl_village.DataTextField = "Village_Name";
                    ddl_village.DataBind();
                    AddSelectForMandal(ddl_village);
                }
                else
                {
                    ddl_village.Items.Clear();
                    AddSelect(ddl_village);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }
    private void BindIndustrialParks()
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddl_induspark.Items.Clear();
                AddSelectForMandal(ddl_induspark);
            }
            else
            {
                DataSet dsParks = new DataSet();
                int DistrictCd = Convert.ToInt32(ddldistrict.SelectedValue);
                ddl_induspark.Items.Clear();
                dsParks = objcommon.GetIALAParks(0, DistrictCd);
                if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
                {
                    ddl_induspark.DataSource = dsParks.Tables[0];
                    ddl_induspark.DataValueField = "IALA_Cd";
                    ddl_induspark.DataTextField = "NameofIALA";
                    ddl_induspark.DataBind();
                    AddSelect(ddl_induspark);
                }
                else
                {
                    ddl_induspark.Items.Clear();
                    AddSelect(ddl_induspark);
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void ddl_induspark_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_village.Enabled = true;
        try
        {
            DataSet dsParks = new DataSet();
            int IALACode = Convert.ToInt32(ddl_induspark.SelectedValue);
            dsParks = objcommon.GetIALAParks(IALACode, 0);
            if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
            {
                ddl_village.Enabled = false;
                string districtCd = "0", MandalCd = "0", VillageCd = "0";
                districtCd = dsParks.Tables[0].Rows[0]["Districtcd"].ToString();
                MandalCd = dsParks.Tables[0].Rows[0]["Mandalcd"].ToString();
                VillageCd = dsParks.Tables[0].Rows[0]["Villagecd"].ToString();
                if (MandalCd != "")
                {
                    ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(MandalCd).Value;
                    ddlMandal_SelectedIndexChanged(sender, e);
                }
                else
                {
                    ddlMandal.SelectedIndex = 0;
                    ddl_village.SelectedIndex = 0;
                }
                if (VillageCd != "")
                {
                    ddl_village.SelectedValue = ddl_village.Items.FindByValue(VillageCd).Value;
                }
                else
                {
                    ddl_village.SelectedIndex = 0;
                }
            }
            else
            {
                ddl_village.SelectedIndex = 0;
                ddl_village.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    protected void txtinvestment_TextChanged(object sender, EventArgs e)
    {
        string message = "";
        if (!string.IsNullOrEmpty(txtinvestment.Text))
        {
            int Day;
            if (!int.TryParse(Convert.ToString(txtinvestment.Text), out Day))
            {
                message = "alert('" + "Investment  Should be Numeric" + "')";
            }
            else
            {
                Int64 investmentvalues = (Convert.ToInt16(txtinvestment.Text) * 100000);
                string R = RupeesinNumber(Convert.ToInt64(investmentvalues));
                if (Convert.ToInt16(txtinvestment.Text) > 99)
                {

                    message = "alert('" + "Investment is " + R + ",is it confirm?" + "')";
                }
                else
                {
                    message = "alert('" + "Investment is " + R + "is it correct?" + "')";
                }

                //if(Convert.ToInt16(txtinvestment.Text)>=99)
                //{
                //    message = "alert('" + "Investment is"+ Convert.ToInt16(txtinvestment.Text)+ "Lakhs,Please confirm" + "')";
                //}
                //else
                //{
                //    message = "alert('" + "Investment is"+ Convert.ToInt16(txtinvestment.Text)+"lakhs is correct" + "')";
                //}
            }
        }
        else
        {
            message = "alert('" + "Enter Investment" + "')";
        }
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
    }
    protected void txtEmployment_TextChanged(object sender, EventArgs e)
    {
        string message = "";
        if (!string.IsNullOrEmpty(txtEmployment.Text))
        {
            int Day;
            if (!int.TryParse(Convert.ToString(txtEmployment.Text), out Day))
            {
                message = "alert('" + "Employment Should be Numeric" + "')";
            }
            else
            {
                if (Convert.ToInt16(txtEmployment.Text) >= 99)
                {
                    message = "alert('" + "Employment is above 99 ,it is confirm" + "')";
                }
                else
                {
                    message = "alert('" + "Employment is" + Convert.ToInt16(txtEmployment.Text) + "is correct" + "')";
                }
            }
        }
        else
        {
            message = "alert('" + "Enter Employment" + "')";
        }
        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        otherstatus.Visible = false;
        if (ddlstatus.SelectedItem.Text == "Other")
        {
            otherstatus.Visible = true;
        }
    }
    protected void txtDateofCommencement_TextChanged(object sender, EventArgs e)
    {
        try
        {
            comFunctions ddd = new comFunctions();
            //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
            DateTime dat = ddd.convertDateIndia(txtDateOfCommencement.Text);
            if (dat > DateTime.Now)
            {
                lblmsg0.Text = "Future Date cannot be selected.";
                txtDateOfCommencement.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
            }
        }
        catch (Exception ex)
        {
            Errors.ErrorLog(ex);
            txtDateOfCommencement.Focus();
            lblmsg0.Text = "Please Select Valid Date(dd-mm-yy).";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-mm-yy)');", true);
        }
    }
    protected void rdnUnitExport_SelectedIndexChanged(object sender, EventArgs e)
    {
        divcountry.Visible = false;
        if (rdnUnitExport.SelectedValue == "Y")
        {
            divcountry.Visible = true;
            txtEXPORTCOUNTRY.Text = "";
        }
    }

    #endregion

    #region productdetails

    protected void getSectorList()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.getSectorNames();
        ddlSector.DataSource = dsnew.Tables[0];
        ddlSector.DataTextField = "SectorName";
        ddlSector.DataValueField = "SectorName";
        ddlSector.DataBind();
        ddlSector.Items.Insert(0, "--Select--");
    }
    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSector.SelectedValue.ToString() != "--Select--")
        {
            BindLineofactivity(ddlSector.SelectedValue);
        }
        else
        {
            ddlSector.Items.Clear();
            ddlSector.Items.Insert(0, "--Select--");
        }
    }
    public void BindLineofactivity(string sectorName)
    {
        DataSet dsc = new DataSet();
        dsc = Gen.GetSectorbylineofactivity(sectorName);
        ddlintLineofActivity.DataSource = dsc.Tables[0];
        ddlintLineofActivity.DataValueField = "intLineofActivityid";
        ddlintLineofActivity.DataTextField = "LineofActivity_Name";
        ddlintLineofActivity.DataBind();
        ddlintLineofActivity.Items.Insert(0, "--Select--");
    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlintLineofActivity.SelectedIndex == 0)
            {

            }
            else
            {
                categoryzone(ddlintLineofActivity.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    void categoryzone(string lineactivity)
    {
        try
        {
            ddlCategorybyZone.Enabled = true;
            DataSet dsct = new DataSet();
            dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
            if (dsct.Tables[0].Rows.Count > 0)
            {
                if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                {
                    ddlCategorybyZone.SelectedValue = "3";
                    ddlCategorybyZone.Enabled = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                {
                    ddlCategorybyZone.SelectedValue = "4";
                    ddlCategorybyZone.Enabled = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                {
                    ddlCategorybyZone.SelectedValue = "2";
                    ddlCategorybyZone.Enabled = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                {
                    ddlCategorybyZone.SelectedValue = "1";
                    ddlCategorybyZone.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }


    #endregion

    #region item manfacture

    protected void ddlManfquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        trothers.Visible = false;
        if (ddlManfquantityin.SelectedValue == "Others")
        {
            trothers.Visible = true;
        }
    }
    protected void grd_manufacturedproducts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink1");
        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SketchCopy_Path"));
        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;
        }
    }
    protected void btnFirstGrid_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls_manufacturing();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            try
            {
                bool filecheck = true;
                if (fpdSketch.HasFile)
                {
                    string[] fileType = fpdSketch.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                    {
                        FIleUploading(fpdSketch, "ItemsManufactre", hplSketch, "1", "10008", "USER");
                    }
                    else
                    {
                        string message = "alert('" + "Please Upload PDF, JPEG Files Only" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        filecheck = false;
                    }
                }
                if (filecheck == true)
                {
                    MSMELineOfManfGrid2DETAILS obj_msmeproductmanfacture = new MSMELineOfManfGrid2DETAILS();
                    obj_msmeproductmanfacture.MSMEID = Convert.ToString(Request.QueryString[0].ToString().Trim());
                    obj_msmeproductmanfacture.Item = Convert.ToString(txtManfitem.Text);
                    obj_msmeproductmanfacture.QuantityPerAnnum = Convert.ToString(txtManfquantityperannum.Text);
                    obj_msmeproductmanfacture.ProductionInUnits = Convert.ToString(ddlManfquantityin.SelectedItem.Text);
                    obj_msmeproductmanfacture.ManufOtherUnits = Convert.ToString(txtMfgothers.Text);
                    obj_msmeproductmanfacture.Attachment = Convert.ToString(hplSketch.NavigateUrl);
                    obj_msmeproductmanfacture.OthersSpecify = Convert.ToString(txtotherproduct.Text);
                    obj_msmeproductmanfacture.CreatedBy = Convert.ToString(Session["uid"]);
                    obj_msmeproductmanfacture.prodmanf_ID = Convert.ToString(hf_productmanfactureID.Value);

                    int checkprodman = obj_msme.UpdateMsme_productmanfaturedetails(obj_msmeproductmanfacture);
                    if (checkprodman > 0)
                    {
                        ClearManufactureGridData();
                        string message = "alert('Product Manfacture Updated Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                    else
                    {
                        //updation Failed
                        string message = "alert('Product Manfacture Updation Failed')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('" + "Please Upload PDF, JPEG Files Only" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    filecheck = false;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        GetProductManfacturedetails();
    }
    protected void ButtonMfgcancel_Click(object sender, EventArgs e)
    {
        ClearManufactureGridData();
    }
    public void ClearManufactureGridData()
    {
        txtManfitem.Text = string.Empty;
        txtManfquantityperannum.Text = string.Empty;
        txtMfgothers.Text = string.Empty;
        ddlManfquantityin.ClearSelection();
    }
    protected void grd_manufacturedproducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deactive_manfacture")
        {
            string rawmaterialdelete = Convert.ToString(e.CommandArgument);
            string[] arg = new string[3];
            arg = rawmaterialdelete.Split(';');

            string ProdManID = Convert.ToString(arg[0]);
            int rownumber = Convert.ToInt32(arg[1]);
            int testprod = obj_msme.deactiveMsme_productmanfaturedetails(Convert.ToString(Request.QueryString[0].ToString().Trim()), ProdManID, Convert.ToString(Session["uid"]));
            if (testprod >= 0)
            {
                string message = "alert('Product Manfacture Deleted successfully)";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('Product Manfacture Updation Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            GetProductManfacturedetails();
        }
        if (e.CommandName == "edit_prodmanf")
        {
            string rawmaterialedit = Convert.ToString(e.CommandArgument);
            string[] arg = new string[3];
            arg = rawmaterialedit.Split(';');

            string ProdManID = Convert.ToString(arg[0]);
            string MSME_NO = Convert.ToString(arg[1]);
            int rownumber = Convert.ToInt32(arg[2]);

            DataSet dt_editrawmaterial = obj_msme.Getproductmanfaturebyprodmanfid(MSME_NO, ProdManID);
            if (dt_editrawmaterial.Tables.Count > 0)
            {
                if (dt_editrawmaterial.Tables[0].Rows.Count > 0)
                {
                    trrawothers.Visible = false;
                    hf_productmanfactureID.Value = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["ProdManID"]);
                    txtManfitem.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["Manfitem"]);
                    txtManfquantityperannum.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["Manfquantityperannum"]);
                    ddlManfquantityin.SelectedItem.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["Manfquantityin"]);
                    hplSketch.NavigateUrl = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["SketchCopy_Path"]);
                    hplSketch.Visible = true;
                    //fpdSketch.FileName = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["SketchCopy_Path"]); 
                    txtotherproduct.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["OthersSpecify"]);
                    trothers.Visible = false;
                    if (Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["Manfquantityin"]).ToLower() == "others")
                    {
                        txtMfgothers.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["Mfgothers"]);
                        trothers.Visible = true;
                    }
                }
            }

        }
    }
    public string ValidateControls_manufacturing()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtManfitem.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter ManufactureItem \\n";
            slno = slno + 1;
        }
        if (txtManfquantityperannum.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Quantity per Annum \\n";
            slno = slno + 1;
        }
        if (ddlManfquantityin.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Production In Units \\n";
            slno = slno + 1;
        }
        if (ddlManfquantityin.SelectedValue == "Others")
        {
            if (txtMfgothers.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter other Quantity\\n";
                slno = slno + 1;
            }
        }
        //if (txtotherproduct.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Other Product Related Details (If Any)\\n";
        //    slno = slno + 1;
        //}
        return ErrorMsg;
    }

    #endregion

    #region raw material state district details
    protected void ddlrawmaterialprocured_SelectedIndexChanged(object sender, EventArgs e)
    {
        div_rawDistrict.Visible = false;
        div_rawstate.Visible = false;
        div_rawcountry.Visible = false;
        if (ddlrawmaterialprocured.SelectedValue.ToString() != "--Select--")
        {
            if (ddlrawmaterialprocured.SelectedValue.ToString() == "31")
            {
                getdistricts();
                ddl_rawdistrict.Visible = true;
                div_rawDistrict.Visible = true;
            }
            else if (ddlrawmaterialprocured.SelectedValue.ToString() == "1")
            {
                getStatesotherthanTG();
                ddlState.Visible = true;
                div_rawstate.Visible = true;
            }
            else if (ddlrawmaterialprocured.SelectedValue.ToString() == "2")
            {
                txtfromcountry.Text = "";
                txtfromcountry.Visible = true;
                div_rawcountry.Visible = true;
            }
        }
        else
        {
            ddl_rawdistrict.Items.Clear();
            ddl_rawdistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetDistrictsbystate(ddlrawmaterialprocured.SelectedValue.ToString());
        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsnew = new DataSet();
        dsnew = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "MSME");
        ddl_rawdistrict.DataSource = dsnew.Tables[0];
        ddl_rawdistrict.DataTextField = "District_Name";
        ddl_rawdistrict.DataValueField = "District_Id";
        ddl_rawdistrict.DataBind();
        ddl_rawdistrict.Items.Insert(0, "--Select--");
    }
    void getStatesotherthanTG()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStatesotherthanTG();
        ddlState.DataSource = ds.Tables[0];
        ddlState.DataTextField = "State_Name";
        ddlState.DataValueField = "State_id";
        ddlState.DataBind();
        ddlState.Items.Insert(0, "--Select--");
    }

    #endregion

    #region Raw material
    protected void ddlRawUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        trrawothers.Visible = false;
        if (ddlRawUnits.SelectedValue == "Others")
        {
            trrawothers.Visible = true;
        }
    }
    protected void grd_rawmaterial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deactive_rawmaterial")
        {
            string rawmaterialdelete = Convert.ToString(e.CommandArgument);
            string[] arg = new string[3];
            arg = rawmaterialdelete.Split(';');

            string RawmatID = Convert.ToString(arg[0]);
            int rownumber = Convert.ToInt32(arg[1]);
            int testraw = obj_msme.deactiveMsme_rawmaterialdetails(Convert.ToString(Request.QueryString[0].ToString().Trim()), RawmatID, Convert.ToString(Session["uid"]));
            if (testraw >= 0)
            {
                string message = "alert('Raw material Deleted successfully)";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('Raw material Updation Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            getRAWRecords();
        }
        if (e.CommandName == "edit_rawmaterial")
        {
            string rawmaterialedit = Convert.ToString(e.CommandArgument);
            string[] arg = new string[3];
            arg = rawmaterialedit.Split(';');

            string RawmatID = Convert.ToString(arg[0]);
            string MSME_NO = Convert.ToString(arg[1]);
            int rownumber = Convert.ToInt32(arg[2]);

            DataSet dt_editrawmaterial = obj_msme.GetRawmaterialbyrowid(MSME_NO, RawmatID);
            if (dt_editrawmaterial.Tables.Count > 0)
            {
                if (dt_editrawmaterial.Tables[0].Rows.Count > 0)
                {
                    trrawothers.Visible = false;
                    txtRawItem.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["RawItem"]);
                    hf_rawmaterialid.Value = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["RawmatID"]);
                    txtRawQntyperAnnum.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["RawQntyperAnnum"]);
                    ddlRawUnits.SelectedItem.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["RawUnits"]);
                    if (Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["RawUnits"]).ToLower() == "others")
                    {
                        trrawothers.Visible = true;
                        txtRawothers.Text = Convert.ToString(dt_editrawmaterial.Tables[0].Rows[0]["OtherUnits"]);
                    }
                }
            }


        }
    }
    protected void btn_addrawmaterial_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateLandControls_rawmaterial();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        else
        {
            try
            {
                MSMELineOfManfGrid1DETAILS objMSMELineOfManfGrid1DETAILSBO = new MSMELineOfManfGrid1DETAILS();
                objMSMELineOfManfGrid1DETAILSBO.MSMEID = Convert.ToString(Request.QueryString[0].ToString().Trim());
                objMSMELineOfManfGrid1DETAILSBO.Item = Convert.ToString(txtRawItem.Text);
                objMSMELineOfManfGrid1DETAILSBO.QuantityPerAnnum = Convert.ToString(txtRawQntyperAnnum.Text);
                objMSMELineOfManfGrid1DETAILSBO.ProductionInUnits = Convert.ToString(ddlRawUnits.SelectedItem);
                objMSMELineOfManfGrid1DETAILSBO.OtherRawUnits = Convert.ToString(txtRawothers.Text);
                objMSMELineOfManfGrid1DETAILSBO.CreatedBy = Convert.ToString(Session["uid"]);
                objMSMELineOfManfGrid1DETAILSBO.RMDID = Convert.ToString(hf_rawmaterialid.Value);
                int checkrawmaterial = obj_msme.UpdateMsme_rawmaterialdetails(objMSMELineOfManfGrid1DETAILSBO);
                if (checkrawmaterial > 0)
                {
                    ClearRawMaterislGridData();
                    string message = "alert('Raw Material Updated Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    //updation Failed
                    string message = "alert('Raw Material Updation Failed')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        getRAWRecords();
    }
    protected void btnSecondGridClear_Click(object sender, EventArgs e)
    {
        //raw material cancel
        ClearRawMaterislGridData();
    }
    public void ClearRawMaterislGridData()
    {
        txtRawItem.Text = string.Empty;
        txtRawQntyperAnnum.Text = string.Empty;
        txtRawothers.Text = string.Empty;
        ddlRawUnits.ClearSelection();
        hf_rawmaterialid.Value = "";
    }
    public string ValidateLandControls_rawmaterial()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (txtRawItem.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter RawMaterialItem \\n";
            slno = slno + 1;
        }
        if (txtRawQntyperAnnum.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Quantity per Annum \\n";
            slno = slno + 1;
        }
        if (ddlRawUnits.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Production In Units \\n";
            slno = slno + 1;
        }
        if (ddlRawUnits.SelectedValue == "Others")
        {
            if (txtRawothers.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Other Quantity  in Units \\n";
                slno = slno + 1;
            }
        }
        return ErrorMsg;
    }

    #endregion

    #region upload file
    protected void btn_saveupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (file_uploadmachinery.HasFile)
            {
                string[] fileType = file_uploadmachinery.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                {
                    FIleUploading(file_uploadmachinery, "MSMEDocments", hypmsme, "1", "10008", "USER");
                    int intUID = Convert.ToInt32(Session["uid"]);
                    string FileType = fileType[i - 1].ToUpper().Trim();
                    string FilePath = hypmsme.NavigateUrl;
                    string FileName = file_uploadmachinery.FileName;
                    string FileDescription = "MSMEDocments";
                    int Created_by = Convert.ToInt32(Session["uid"]);
                    string applid = Convert.ToString(Request.QueryString[0].ToString().Trim());

                    if (obj_msme.Uploadlistdetailsofmanchinetools(intUID, FileType, FilePath, FileName, FileDescription, Created_by, applid))
                    {
                        string message = "alert('" + "Upload File Successfully" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                    else
                    {
                        string message = "alert('" + "Upload file failed" + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    }
                }
                else
                {
                    string message = "alert('" + "Please Upload PDF, JPEG Files Only" + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

            }
            GetmsmeAttachments();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void FIleUploading(FileUpload fpd, string Description, HyperLink hlp, string ApprovalID, string DocID, string DocUploadedUserType)
    {
        try
        {
            Session["uid"] = "1000";
            string newPath = "";
            string sFileDir = Server.MapPath("~\\MSMEAttachments");
            General t1 = new General();
            if ((fpd.PostedFile != null) && (fpd.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);

                string fileExtension = Path.GetExtension(sFileName);
                string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                string Attachmentidnew = Session["uid"].ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                sFileName = Description + Attachmentidnew + fileExtension;

                try
                {
                    string[] fileType = fpd.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "JPEG")
                    {

                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\" + Description + "\\" + Attachmentidnew);
                        if (!Directory.Exists(newPath))
                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fpd.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        if (result == 0)
                        {
                            hlp.Text = "View";
                            hlp.NavigateUrl = "~/MSMEAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                            ViewState[fpd.ID] = "~/MSMEAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //outmsg = "1";
                        }
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Upload PDF,JPG  files only..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                    }
                }
                catch (Exception ex)//in case of an error
                {
                    throw ex;
                }
            }
        }
        catch (Exception ex)//in case of an error
        {
            throw ex;
        }
        //return outmsg;
    }

    protected void grd_uploadgrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "deactive_uploadlistdetails")
        {
            string rawmaterialdelete = Convert.ToString(e.CommandArgument);
            string[] arg = new string[3];
            arg = rawmaterialdelete.Split(';');

            string intMSMEID = Convert.ToString(arg[0]);
            int rownumber = Convert.ToInt32(arg[1]);

            if (obj_msme.deactiveMsme_uploadlistofdetails(Convert.ToString(Request.QueryString[0].ToString().Trim()), intMSMEID, Convert.ToString(Session["uid"])))
            {
                string message = "alert('File Deleted successfully)";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            else
            {
                string message = "alert('File Updation Failed')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            GetmsmeAttachments();
        }
    }

    #endregion

    #region Submit
    public void DeleteFile(string strFileName)
    {//Delete file from the server
        if (strFileName.Trim().Length > 0)
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Exists)//if file exists delete it
            {
                fi.Delete();
            }
        }
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        //Cancel
        try
        {
            Response.Redirect("frmMSMEReport.aspx");
        }
        catch (Exception ex)
        {
            // Response.Write(ex);
            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }

    public string ValidateLandControlsSumbit()
    {
        int slno = 1;
        string ErrorMsg = "";

        string test1 = Convert.ToString(Request.Form["latitude"]);
        string test2 = Convert.ToString(Request.Form["logititude"]);

        if (Request.Form["latitude"].ToString().TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter langitude \\n";
            slno = slno + 1;
        }
        if (Request.Form["logititude"].ToString().TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter longitude \\n";
            slno = slno + 1;
        }

        if (txtUnitName.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name Details \\n";
            slno = slno + 1;
        }
        //if (txtUAMID.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter UAM ID Details \\n";
        //    slno = slno + 1;
        //}
        if (ddlCategory.SelectedItem.Text == "--Select--" || ddlCategory.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Category \\n";
            slno = slno + 1;
        }
        if (ddldistrict.SelectedItem.Text == "--Select--" || ddldistrict.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District Details \\n";
            slno = slno + 1;
        }
        if (ddlMandal.SelectedItem.Text == "--Select--" || ddlMandal.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Details \\n";
            slno = slno + 1;
        }
        if (ddl_village.SelectedItem.Text == "--Select--" || ddl_village.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Village Details \\n";
            slno = slno + 1;
        }
        if (txt_houseno.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter House No \\n";
            slno = slno + 1;
        }
        if (txt_Locality.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Locality \\n";
            slno = slno + 1;
        }
        if (txt_street.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Street \\n";
            slno = slno + 1;
        }
        if (txt_landmark.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Land Mark \\n";
            slno = slno + 1;
        }
        if (txtunitaddress.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Complete Unit Address \\n";
            slno = slno + 1;
        }
        if (txtinvestment.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Investment \\n";
            slno = slno + 1;
        }
        if (txtEmployment.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Employment \\n";
            slno = slno + 1;
        }
        if (ddlstatus.SelectedItem.Text == "--Select--" || ddlstatus.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Present Status \\n";
            slno = slno + 1;
        }
        if (ddlConst_of_unit.SelectedItem.Text == "--Select--" || ddlConst_of_unit.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type Of Industry\\n";
            slno = slno + 1;
        }
        if (txtDateOfCommencement.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date Of Commencement of Production\\n";
            slno = slno + 1;
        }
        if (txtNameofEntrepreneur.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Entrepreneur Details \\n";
            slno = slno + 1;
        }
        if (txtMObileNo.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter MobileNo Details \\n";
            slno = slno + 1;
        }
        //if (txtEmail.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Details \\n";
        //    slno = slno + 1;
        //}
        if (ddlCaste.SelectedItem.Text == "--Select--" || ddlCaste.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Social Status \\n";
            slno = slno + 1;
        }
        if (ddlDifferentlyabled.SelectedItem.Text == "--Select--" || ddlDifferentlyabled.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Is Promoter Differently Abled \\n";
            slno = slno + 1;
        }
        if (ddlWomenEnterprenuer.SelectedItem.Text == "--Select--" || ddlWomenEnterprenuer.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Is Promoter Women\\n";
            slno = slno + 1;
        }
        if (ddlSector.SelectedItem.Text == "--Select--" || ddlSector.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Sector \\n";
            slno = slno + 1;
        }
        if (ddlintLineofActivity.SelectedItem.Text == "--Select--" || ddlintLineofActivity.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select LineofActivity Details \\n";
            slno = slno + 1;
        }
        if (ddlCategorybyZone.SelectedItem.Text == "--Select--" || ddlCategorybyZone.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Category by PCB \\n";
            slno = slno + 1;
        }
        if (ddlrawmaterialprocured.SelectedItem.Text == "--Select--" || ddlrawmaterialprocured.SelectedIndex <= 0)
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Raw Materials is Procurred From \\n";
            slno = slno + 1;
        }
        if (txtremarks.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks \\n";
            slno = slno + 1;
        }
        if (ddlrawmaterialprocured.SelectedValue.ToString() == "31")
        {
            if (ddl_rawdistrict.SelectedItem.Text == "--Select--" || ddl_rawdistrict.SelectedIndex <= 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Raw Materials is Procurred From District \\n";
                slno = slno + 1;
            }
        }
        if (ddlrawmaterialprocured.SelectedValue.ToString() == "1")
        {
            if (ddlState.SelectedItem.Text == "--Select--" || ddlState.SelectedIndex <= 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Raw Materials is Procurred From State \\n";
                slno = slno + 1;
            }
        }
        if (ddlrawmaterialprocured.SelectedValue.ToString() == "2")
        {
            if (txtfromcountry.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Country of Raw Material \\n";
                slno = slno + 1;
            }
        }
        if (rdnUnitExport.SelectedValue.ToString() == "Y")
        {
            if (txtEXPORTCOUNTRY.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Major Export to Which countries \\n";
                slno = slno + 1;
            }
        }
        if (ddlstatus.SelectedItem.Text == "Other")
        {
            if (txtOtherStatus.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Other Present Status \\n";
                slno = slno + 1;
            }
        }
        if (rdunitIEORNOT.SelectedValue == "1")
        {
            if (ddl_induspark.SelectedItem.Text == "--Select--" || ddl_induspark.SelectedIndex <= 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Raw Materials is Procurred From State \\n";
                slno = slno + 1;
            }
        }

        if (ddlCategory.SelectedValue == "1" || ddlCategory.SelectedValue == "2" || ddlCategory.SelectedValue == "3")
        {
            if (txtskilledcontract.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Skilled Contract Employment \\n";
                slno = slno + 1;
            }

            if (txtskilledoutsourcing.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Skilled Outsourcing Employment \\n";
                slno = slno + 1;
            }


            if (txtsemiskilledcontract.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  SemiSkilled Contract Employment \\n";
                slno = slno + 1;
            }

            if (txtsemiskilledoutsourcing.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter SemiSkilled OutSourcing Employment \\n";
                slno = slno + 1;
            }

            if (txtunskilledcontract.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter UnSkilled Contract Employment \\n";
                slno = slno + 1;
            }

            if (txtunskilledoutsourcing.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter UnSkilled OutSourcing Employment \\n";
                slno = slno + 1;
            }

            if (txtmanagerialcontract.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Managerial Contract Employment \\n";
                slno = slno + 1;
            }

            if (txtmanagerialoutsourcing.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Managerial OutSourcing Employment \\n";
                slno = slno + 1;
            }

            if (txtmenemp.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Men Employees \\n";
                slno = slno + 1;
            }
            if (txtwomen.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of women Employees \\n";
                slno = slno + 1;
            }
            if (txt_noofdirectemp.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of direct Employees \\n";
                slno = slno + 1;
            }
            if (txt_totnoofindirectemp.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of indirect Employees \\n";
                slno = slno + 1;
            }
            if (txt_totemppfesi.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Employees getting PF/ESI \\n";
                slno = slno + 1;
            }

            if (txt_totempnopfesi.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Employees having ESI \\n";
                slno = slno + 1;
            }
            if (txtlocal.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Local Employees \\n";
                slno = slno + 1;
            }
            if (txtmigrant.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Migrant Employees \\n";
                slno = slno + 1;
            }
            if (txt_noofdirectemp.Text.Trim() != "")
            {
                if (Convert.ToDecimal(txt_noofdirectemp.Text) != Convert.ToDecimal((Convert.ToDecimal(txtlocal.Text)) + (Convert.ToDecimal(txtnonlocal.Text)) + (Convert.ToDecimal(txtmigrant.Text))))
                {
                    ErrorMsg = ErrorMsg + slno + ". Total Local,Non Local and Migrant Employees should be equal to total direct employment. \\n";
                    slno = slno + 1;
                    txtlocal.Text = "";
                    txtnonlocal.Text = "";
                    txtmigrant.Text = "";
                }
            }
            //if (txt_totemppfesi.Text.Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter employees getting PF/ESI \\n";
            //    slno = slno + 1;
            //}
        }

        //if (txt_laltuide.Text.Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please select the location of the unit \\n";
        //    slno = slno + 1;
        //}
        //if (txt_longitude.Text.Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please select the location of the unit \\n";
        //    slno = slno + 1;
        //}

        return ErrorMsg;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string errormsg = ValidateLandControlsSumbit();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;

            }
            else
            {

                //if (confirm('Are you sure you want to save this thing into the database?'))
                //{
                //    // Save it!
                //    console.log('Thing was saved to the database.');
                //}
                //else
                //{
                //    // Do nothing!
                //    console.log('Thing was not saved to the database.');
                //}

                MSMEUNITDETAILS OBJMSMEUNITDETAILS = new MSMEUNITDETAILS();
                OBJMSMEUNITDETAILS.UNIT_NAME = txtUnitName.Text.ToString();
                OBJMSMEUNITDETAILS.UAM_ID = txtUAMID.Text.Trim();
                OBJMSMEUNITDETAILS.CATEGOERY_ID = ddlCategory.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.UNITS_IE_OR_NOT = rdunitIEORNOT.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.DISTRICT_ID = ddldistrict.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.MANDAL_ID = ddlMandal.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.VillageID = Convert.ToInt32(ddl_village.SelectedValue);
                if (rdunitIEORNOT.SelectedValue == "1")
                {
                    OBJMSMEUNITDETAILS.IndustrialParkID = Convert.ToString(ddl_induspark.SelectedValue);
                }
                OBJMSMEUNITDETAILS.HouseNo = Convert.ToString(txt_houseno.Text);
                OBJMSMEUNITDETAILS.Locality = Convert.ToString(txt_Locality.Text);
                OBJMSMEUNITDETAILS.Street = Convert.ToString(txt_street.Text);
                OBJMSMEUNITDETAILS.LandMark = Convert.ToString(txt_landmark.Text);
                OBJMSMEUNITDETAILS.Completeaddress = txtunitaddress.Text.Trim();
                OBJMSMEUNITDETAILS.investment = txtinvestment.Text.Trim();
                OBJMSMEUNITDETAILS.EMPLOYMENT = txtEmployment.Text.Trim();
                OBJMSMEUNITDETAILS.presentstatus = ddlstatus.SelectedItem.Text;
                OBJMSMEUNITDETAILS.otherpresentstatus = txtOtherStatus.Text;
                OBJMSMEUNITDETAILS.TYPEOFINDUSTRY = ddlConst_of_unit.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.TYPEOFCONNECTION = RdtypeofConn.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.EXPORT = rdnUnitExport.SelectedValue.ToString();
                if (OBJMSMEUNITDETAILS.EXPORT == "Y")
                {
                    OBJMSMEUNITDETAILS.EXPORTCOUNTRY = txtEXPORTCOUNTRY.Text;
                }
                else
                {
                    OBJMSMEUNITDETAILS.EXPORTCOUNTRY = null;
                }
                if (txtDate.Text == "" || txtDate.Text == null)
                {
                    OBJMSMEUNITDETAILS.Date = null;
                }
                else
                {
                    string[] ConvertedDt11 = txtDate.Text.Split('-');
                    OBJMSMEUNITDETAILS.Date = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
                }
                if (txtDateOfCommencement.Text == "" || txtDateOfCommencement.Text == null)
                {
                    OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = null;
                }
                else
                {
                    //comFunctions ddd = new comFunctions();
                    ////string[] ConvertedDt12 = txtDateOfCommencement.Text.Split('-');
                    //// OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = ConvertedDt12[2].ToString() + "/" + ConvertedDt12[1].ToString() + "/" + ConvertedDt12[0].ToString();
                    //DateTime dat_commentofdate = ddd.convertDateIndia(txtDateOfCommencement.Text);
                    //OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = Convert.ToString(dat_commentofdate);
                    string[] ConvertedDt12 = txtDateOfCommencement.Text.Split('-');
                    OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = ConvertedDt12[2].ToString() + "/" + ConvertedDt12[1].ToString() + "/" + ConvertedDt12[0].ToString();

                }

                //--enterpreneur details--//
                OBJMSMEUNITDETAILS.NAME_OF_ENTREPRENEUR = txtNameofEntrepreneur.Text.Trim();
                OBJMSMEUNITDETAILS.MOBILE_NO = txtMObileNo.Text.Trim();
                OBJMSMEUNITDETAILS.EMAIL_ID = txtEmail.Text.Trim();
                OBJMSMEUNITDETAILS.SOCAILSTATUS = ddlCaste.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.PROMOTERDISABLED = ddlDifferentlyabled.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.PROMOTERWOMEN = ddlWomenEnterprenuer.SelectedValue.ToString();
                //***enterpreneur details**//

                //***product details**//
                OBJMSMEUNITDETAILS.SECTOR = ddlSector.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.LINE_OF_ACTIVITY = ddlintLineofActivity.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.PCBCATEGORY = ddlCategorybyZone.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.PRODUCT_SPEC = txtProductSpec.Text.Trim();
                //**product details**//

                //--Raw materials desc--//
                OBJMSMEUNITDETAILS.RAWMATERIALPROCURED = ddlrawmaterialprocured.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.RAWMATERIALDISTRICT = ddl_rawdistrict.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.RAWMATERIALSTATE = ddlState.SelectedValue.ToString();
                OBJMSMEUNITDETAILS.RAWMATERIALCOUNTRY = txtfromcountry.Text;
                //***Raw materials desc***//
                OBJMSMEUNITDETAILS.REMARKS = txtremarks.Text.Trim();
                OBJMSMEUNITDETAILS.CreatedBy = Convert.ToString(Session["uid"]);
                OBJMSMEUNITDETAILS.uploaddetailslistofmachinery = "";

                if (Request.QueryString[0].ToString().Trim() != null)
                {
                    OBJMSMEUNITDETAILS.MSMENO = Request.QueryString[0].ToString().Trim().ToString();
                }
                else
                {
                    OBJMSMEUNITDETAILS.MSMENO = null;
                }
                if (ddltsipass.SelectedItem.Text != "--Select--" || ddltsipass.SelectedIndex != 0)
                {
                    OBJMSMEUNITDETAILS.tsipassuidno = ddltsipass.SelectedItem.Text;
                    OBJMSMEUNITDETAILS.intcfeid = ddltsipass.SelectedValue.ToString();
                }

                OBJMSMEUNITDETAILS.noofempnotgivenesipf = Convert.ToString(txt_totempnotpfesi.Text);
                OBJMSMEUNITDETAILS.noofemplocal = Convert.ToString(txt_totlocalemp.Text);
                OBJMSMEUNITDETAILS.noofempnonlocal = Convert.ToString(txt_totalnonlocal.Text);
                

                OBJMSMEUNITDETAILS.noofempoutsourcig = Convert.ToString(txt_noofempoutsourcing.Text);
                OBJMSMEUNITDETAILS.noofempContract = Convert.ToString(txt_noofempcontract.Text);


                OBJMSMEUNITDETAILS.skilledcontract = Convert.ToString(txtskilledcontract.Text);
                OBJMSMEUNITDETAILS.skilledoutsourcing = Convert.ToString(txtskilledoutsourcing.Text);
                OBJMSMEUNITDETAILS.skilledtotal = Convert.ToString(txtskilledtotal.Text);


                OBJMSMEUNITDETAILS.semiskilledcontract = Convert.ToString(txtsemiskilledcontract.Text);
                OBJMSMEUNITDETAILS.semiskilledoutsourcing = Convert.ToString(txtsemiskilledoutsourcing.Text);
                OBJMSMEUNITDETAILS.semiskilledtotal = Convert.ToString(txtsemiskilledtotal.Text);

                OBJMSMEUNITDETAILS.unskilledcontract = Convert.ToString(txtunskilledcontract.Text);
                OBJMSMEUNITDETAILS.unskilledoutsourcing = Convert.ToString(txtunskilledoutsourcing.Text);
                OBJMSMEUNITDETAILS.unskilledtotal = Convert.ToString(txtunskilledtotal.Text);

                OBJMSMEUNITDETAILS.managerialcontract = Convert.ToString(txtmanagerialcontract.Text);
                OBJMSMEUNITDETAILS.managerialoutsourcing = Convert.ToString(txtmanagerialoutsourcing.Text);
                OBJMSMEUNITDETAILS.managerialtotal = Convert.ToString(txtmanagerialtotal.Text);

                OBJMSMEUNITDETAILS.noofempgivenesipf = Convert.ToString(txt_totemppfesi.Text);
                OBJMSMEUNITDETAILS.noofempdirect = Convert.ToString(txt_noofdirectemp.Text);
                OBJMSMEUNITDETAILS.noofempindirect = Convert.ToString(txt_totnoofindirectemp.Text);
                OBJMSMEUNITDETAILS.noofMenemp = Convert.ToString(txtmenemp.Text);
                OBJMSMEUNITDETAILS.noofWomenemp = Convert.ToString(txtwomen.Text);
                OBJMSMEUNITDETAILS.totalEmployement = Convert.ToString(txttotalemployement.Text);

                //OBJMSMEUNITDETAILS.latitude = Convert.ToString(txt_laltuide.Text);
                //OBJMSMEUNITDETAILS.longitude = Convert.ToString(txt_longitude.Text);

                OBJMSMEUNITDETAILS.latitude = Convert.ToString(Request.Form["latitude"]);
                OBJMSMEUNITDETAILS.longitude = Convert.ToString(Request.Form["logititude"]);

                OBJMSMEUNITDETAILS.noofempnotgivenesipf = Convert.ToString(txt_totempnopfesi.Text);
                OBJMSMEUNITDETAILS.noofemplocal = Convert.ToString(txtlocal.Text);
                OBJMSMEUNITDETAILS.noofempnonlocal = Convert.ToString(txtnonlocal.Text);
                OBJMSMEUNITDETAILS.Migrantworkman = Convert.ToString(txtmigrant.Text);

                int result = obj_msme.UpdateMsmeUnitDetails(OBJMSMEUNITDETAILS);
                int updatedate = updatetsipassuidcfe();
                string IPadd = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                bool result_inactiveemployeedata = obj_msme.inactiveemployeedata(OBJMSMEUNITDETAILS.CreatedBy, IPadd, OBJMSMEUNITDETAILS.MSMENO);
                //grdemployementdetailsinsert(OBJMSMEUNITDETAILS.MSMENO);

                grdoutsourcingemployementdetailsinsert(OBJMSMEUNITDETAILS.MSMENO);
                grdcotractemployementdetailsinsert(OBJMSMEUNITDETAILS.MSMENO);


                if (result > 0)
                {
                    string message = "alert('Application Submitted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    success.Visible = true;
                    lblmsg.Text = "Application Updated Successfully";
                    btnsubmit.Enabled = false;
                    Response.Redirect("frmMSMEReport.aspx");
                }
                else
                {
                    string message = "alert('Application Not Processed please try Again!!')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    btnsubmit.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }

    }

    void grdoutsourcingemployementdetailsinsert(string MSMENO)
    {
        try
        {
            for (int i = 0; i < grd_employeedetails_outsourcing.Rows.Count; i++)
            {
                MSMEemployeedatagridDETAILS objMSMEemployeedatagridDETAILSBO = new MSMEemployeedatagridDETAILS();
                HiddenField hf_osemptypeid = (HiddenField)grd_employeedetails_outsourcing.Rows[i].FindControl("hf_osemptypeid");
                Label lbl_osemptype = (Label)grd_employeedetails_outsourcing.Rows[i].FindControl("lbl_osemptype");
                TextBox txtempos_women = grd_employeedetails_outsourcing.Rows[i].FindControl("txtempos_women") as TextBox;
                TextBox txtempos_men = grd_employeedetails_outsourcing.Rows[i].FindControl("txtempos_men") as TextBox;
                objMSMEemployeedatagridDETAILSBO.emptypeid = hf_osemptypeid.Value;
                objMSMEemployeedatagridDETAILSBO.emptypename = lbl_osemptype.Text;
                objMSMEemployeedatagridDETAILSBO.Women = txtempos_women.Text;
                objMSMEemployeedatagridDETAILSBO.men = txtempos_men.Text;
                objMSMEemployeedatagridDETAILSBO.Iscontract = false;
                objMSMEemployeedatagridDETAILSBO.Isoutsour = true;
                objMSMEemployeedatagridDETAILSBO.CreatedBy = Convert.ToString(Session["uid"]);
                objMSMEemployeedatagridDETAILSBO.CreatedIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                objMSMEemployeedatagridDETAILSBO.MSMENO = MSMENO;
                bool result_emp = obj_msme.insertemployeedata(objMSMEemployeedatagridDETAILSBO);
            }

        }
        catch (Exception ex)
        {

        }
    }

    void grdcotractemployementdetailsinsert(string MSMENO)
    {
        try
        {
            for (int i = 0; i < grd_employeedetails_contract.Rows.Count; i++)
            {
                MSMEemployeedatagridDETAILS objMSMEemployeedatagridDETAILSBO = new MSMEemployeedatagridDETAILS();
                HiddenField hf_emptypeidcon = (HiddenField)grd_employeedetails_contract.Rows[i].FindControl("hf_emptypeidcon");
                Label lbl_emptypecon = (Label)grd_employeedetails_contract.Rows[i].FindControl("lbl_emptypecon");
                TextBox txtemp_conwomen = grd_employeedetails_contract.Rows[i].FindControl("txtemp_conwomen") as TextBox;
                TextBox txtemp_conmen = grd_employeedetails_contract.Rows[i].FindControl("txtemp_conmen") as TextBox;


                objMSMEemployeedatagridDETAILSBO.emptypeid = hf_emptypeidcon.Value;
                objMSMEemployeedatagridDETAILSBO.emptypename = lbl_emptypecon.Text;
                objMSMEemployeedatagridDETAILSBO.Women = txtemp_conwomen.Text;
                objMSMEemployeedatagridDETAILSBO.men = txtemp_conmen.Text;
                objMSMEemployeedatagridDETAILSBO.Iscontract = true;
                objMSMEemployeedatagridDETAILSBO.Isoutsour = false;
                objMSMEemployeedatagridDETAILSBO.CreatedBy = Convert.ToString(Session["uid"]);
                objMSMEemployeedatagridDETAILSBO.CreatedIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                objMSMEemployeedatagridDETAILSBO.MSMENO = MSMENO;
                bool result_emp = obj_msme.insertemployeedata(objMSMEemployeedatagridDETAILSBO);
            }

        }
        catch (Exception ex)
        {

        }
    }

    //void grdemployementdetailsinsert(string MSMENO)
    //{
    //    try
    //    {
    //        for (int i = 0; i < grd_employeedetails.Rows.Count; i++)
    //        {
    //            MSMEemployeedatagridDETAILS objMSMEemployeedatagridDETAILSBO = new MSMEemployeedatagridDETAILS();
    //            HiddenField hf_emptypeid = (HiddenField)grd_employeedetails.Rows[i].FindControl("hf_emptypeid");
    //            TextBox txt_emptype = (TextBox)grd_employeedetails.Rows[i].FindControl("txt_emptype");

    //            TextBox txtemp_payamount = grd_employeedetails.Rows[i].FindControl("txtemp_payamount") as TextBox;
    //            TextBox txtemp_pfamount = grd_employeedetails.Rows[i].FindControl("txtemp_pfamount") as TextBox;
    //            TextBox txtemp_esiamount = grd_employeedetails.Rows[i].FindControl("txtemp_esiamount") as TextBox;
    //            TextBox txtemp_noofposts = (TextBox)grd_employeedetails.Rows[i].FindControl("txtemp_noofposts");
    //            TextBox txtemp_women = grd_employeedetails.Rows[i].FindControl("txtemp_women") as TextBox;
    //            TextBox txtemp_men = (TextBox)grd_employeedetails.Rows[i].FindControl("txtemp_men");
    //            TextBox txtemp_local = grd_employeedetails.Rows[i].FindControl("txtemp_local") as TextBox;
    //            TextBox txtemp_nonlocal = (TextBox)grd_employeedetails.Rows[i].FindControl("txtemp_nonlocal");
    //            TextBox txtemp_qualifications = grd_employeedetails.Rows[i].FindControl("txtemp_qualifications") as TextBox;

    //            objMSMEemployeedatagridDETAILSBO.emptypeid = hf_emptypeid.Value;
    //            objMSMEemployeedatagridDETAILSBO.emptypename = txt_emptype.Text;
    //            objMSMEemployeedatagridDETAILSBO.payamount = txtemp_payamount.Text;
    //            objMSMEemployeedatagridDETAILSBO.Pfamount = txtemp_pfamount.Text;
    //            objMSMEemployeedatagridDETAILSBO.esiamount = txtemp_esiamount.Text;
    //            objMSMEemployeedatagridDETAILSBO.qualiskillsreq = txtemp_qualifications.Text;
    //            objMSMEemployeedatagridDETAILSBO.noofpost = txtemp_noofposts.Text;
    //            objMSMEemployeedatagridDETAILSBO.Women = txtemp_women.Text;
    //            objMSMEemployeedatagridDETAILSBO.men = txtemp_men.Text;
    //            objMSMEemployeedatagridDETAILSBO.Local = txtemp_local.Text;
    //            objMSMEemployeedatagridDETAILSBO.Nonlocal = txtemp_nonlocal.Text;
    //            objMSMEemployeedatagridDETAILSBO.CreatedBy = Convert.ToString(Session["uid"]);
    //            objMSMEemployeedatagridDETAILSBO.CreatedIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    //            objMSMEemployeedatagridDETAILSBO.MSMENO = MSMENO;
    //            bool result_emp = obj_msme.insertemployeedata(objMSMEemployeedatagridDETAILSBO);




    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}


    void test()
    {
        //try
        //{
        //    if (Regex.IsMatch(mobilenumber, @"^\d{10}$"))
        //    {
        //        format = true;
        //    }
        //    else
        //    {
        //        format = false;
        //        lbl.Text = "Invalid MobileNo";
        //        lbl.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    format = false;
        //    lbl.Text = "Invalid MobileNo";
        //    lbl.ForeColor = System.Drawing.Color.Red;
        //}

        //try
        //{
        //    if (Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
        //    {
        //        format = true;
        //    }
        //    else
        //    {
        //        format = false;
        //        lbl.Text = "Invalid EmailID";
        //        lbl.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    format = false;
        //    lbl.Text = "Invalid EmailID";
        //    lbl.ForeColor = System.Drawing.Color.Red;
        //}
        //if (!int.TryParse(Convert.ToString(empty.Rows[j]["Session Minutes(MM)"]), out Day))
        //{
        //    empty.Rows[j][8] = "Session Minutes(MM) Should be Numeric";
        //    empty.AcceptChanges();
        //}

    }
    #endregion

    #region ruppes
    public string Rupees(Int64 rup)
    {
        string result = "";
        Int64 res;
        if ((rup / 10000000) > 0)
        {
            res = rup / 10000000;
            rup = rup % 10000000;
            result = result + ' ' + RupeesToWords(res) + " Crore";
        }
        if ((rup / 100000) > 0)
        {
            res = rup / 100000;
            rup = rup % 100000;
            result = result + ' ' + RupeesToWords(res) + " Lack";
        }
        if ((rup / 1000) > 0)
        {
            res = rup / 1000;
            rup = rup % 1000;
            result = result + ' ' + RupeesToWords(res) + " Thousand";
        }
        if ((rup / 100) > 0)
        {
            res = rup / 100;
            rup = rup % 100;
            result = result + ' ' + RupeesToWords(res) + " Hundred";
        }
        if ((rup % 10) >= 0)
        {
            res = rup % 100;
            result = result + " " + RupeesToWords(res);
        }
        //result = result + ' ' + " Rupees only";
        return result;
    }
    public string RupeesToWords(Int64 rup)
    {
        string result = "";
        if ((rup >= 1) && (rup <= 10))
        {
            if ((rup % 10) == 1) result = "One";
            if ((rup % 10) == 2) result = "Two";
            if ((rup % 10) == 3) result = "Three";
            if ((rup % 10) == 4) result = "Four";
            if ((rup % 10) == 5) result = "Five";
            if ((rup % 10) == 6) result = "Six";
            if ((rup % 10) == 7) result = "Seven";
            if ((rup % 10) == 8) result = "Eight";
            if ((rup % 10) == 9) result = "Nine";
            if ((rup % 10) == 0) result = "Ten";
        }
        if (rup > 9 && rup < 20)
        {
            if (rup == 11) result = "Eleven";
            if (rup == 12) result = "Twelve";
            if (rup == 13) result = "Thirteen";
            if (rup == 14) result = "Forteen";
            if (rup == 15) result = "Fifteen";
            if (rup == 16) result = "Sixteen";
            if (rup == 17) result = "Seventeen";
            if (rup == 18) result = "Eighteen";
            if (rup == 19) result = "Nineteen";
        }
        if (rup > 20 && (rup / 10) == 2 && (rup % 10) == 0) result = "Twenty";
        if (rup > 20 && (rup / 10) == 3 && (rup % 10) == 0) result = "Thirty";
        if (rup > 20 && (rup / 10) == 4 && (rup % 10) == 0) result = "Forty";
        if (rup > 20 && (rup / 10) == 5 && (rup % 10) == 0) result = "Fifty";
        if (rup > 20 && (rup / 10) == 6 && (rup % 10) == 0) result = "Sixty";
        if (rup > 20 && (rup / 10) == 7 && (rup % 10) == 0) result = "Seventy";
        if (rup > 20 && (rup / 10) == 8 && (rup % 10) == 0) result = "Eighty";
        if (rup > 20 && (rup / 10) == 9 && (rup % 10) == 0) result = "Ninty";

        if (rup > 20 && (rup / 10) == 2 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Twenty One";
            if ((rup % 10) == 2) result = "Twenty Two";
            if ((rup % 10) == 3) result = "Twenty Three";
            if ((rup % 10) == 4) result = "Twenty Four";
            if ((rup % 10) == 5) result = "Twenty Five";
            if ((rup % 10) == 6) result = "Twenty Six";
            if ((rup % 10) == 7) result = "Twenty Seven";
            if ((rup % 10) == 8) result = "Twenty Eight";
            if ((rup % 10) == 9) result = "Twenty Nine";
        }
        if (rup > 20 && (rup / 10) == 3 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Thirty One";
            if ((rup % 10) == 2) result = "Thirty Two";
            if ((rup % 10) == 3) result = "Thirty Three";
            if ((rup % 10) == 4) result = "Thirty Four";
            if ((rup % 10) == 5) result = "Thirty Five";
            if ((rup % 10) == 6) result = "Thirty Six";
            if ((rup % 10) == 7) result = "Thirty Seven";
            if ((rup % 10) == 8) result = "Thirty Eight";
            if ((rup % 10) == 9) result = "Thirty Nine";
        }
        if (rup > 20 && (rup / 10) == 4 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Forty One";
            if ((rup % 10) == 2) result = "Forty Two";
            if ((rup % 10) == 3) result = "Forty Three";
            if ((rup % 10) == 4) result = "Forty Four";
            if ((rup % 10) == 5) result = "Forty Five";
            if ((rup % 10) == 6) result = "Forty Six";
            if ((rup % 10) == 7) result = "Forty Seven";
            if ((rup % 10) == 8) result = "Forty Eight";
            if ((rup % 10) == 9) result = "Forty Nine";
        }
        if (rup > 20 && (rup / 10) == 5 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Fifty One";
            if ((rup % 10) == 2) result = "Fifty Two";
            if ((rup % 10) == 3) result = "Fifty Three";
            if ((rup % 10) == 4) result = "Fifty Four";
            if ((rup % 10) == 5) result = "Fifty Five";
            if ((rup % 10) == 6) result = "Fifty Six";
            if ((rup % 10) == 7) result = "Fifty Seven";
            if ((rup % 10) == 8) result = "Fifty Eight";
            if ((rup % 10) == 9) result = "Fifty Nine";
        }
        if (rup > 20 && (rup / 10) == 6 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Sixty One";
            if ((rup % 10) == 2) result = "Sixty Two";
            if ((rup % 10) == 3) result = "Sixty Three";
            if ((rup % 10) == 4) result = "Sixty Four";
            if ((rup % 10) == 5) result = "Sixty Five";
            if ((rup % 10) == 6) result = "Sixty Six";
            if ((rup % 10) == 7) result = "Sixty Seven";
            if ((rup % 10) == 8) result = "Sixty Eight";
            if ((rup % 10) == 9) result = "Sixty Nine";
        }
        if (rup > 20 && (rup / 10) == 7 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Seventy One";
            if ((rup % 10) == 2) result = "Seventy Two";
            if ((rup % 10) == 3) result = "Seventy Three";
            if ((rup % 10) == 4) result = "Seventy Four";
            if ((rup % 10) == 5) result = "Seventy Five";
            if ((rup % 10) == 6) result = "Seventy Six";
            if ((rup % 10) == 7) result = "Seventy Seven";
            if ((rup % 10) == 8) result = "Seventy Eight";
            if ((rup % 10) == 9) result = "Seventy Nine";
        }
        if (rup > 20 && (rup / 10) == 8 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Eighty One";
            if ((rup % 10) == 2) result = "Eighty Two";
            if ((rup % 10) == 3) result = "Eighty Three";
            if ((rup % 10) == 4) result = "Eighty Four";
            if ((rup % 10) == 5) result = "Eighty Five";
            if ((rup % 10) == 6) result = "Eighty Six";
            if ((rup % 10) == 7) result = "Eighty Seven";
            if ((rup % 10) == 8) result = "Eighty Eight";
            if ((rup % 10) == 9) result = "Eighty Nine";
        }
        if (rup > 20 && (rup / 10) == 9 && (rup % 10) != 0)
        {
            if ((rup % 10) == 1) result = "Ninty One";
            if ((rup % 10) == 2) result = "Ninty Two";
            if ((rup % 10) == 3) result = "Ninty Three";
            if ((rup % 10) == 4) result = "Ninty Four";
            if ((rup % 10) == 5) result = "Ninty Five";
            if ((rup % 10) == 6) result = "Ninty Six";
            if ((rup % 10) == 7) result = "Ninty Seven";
            if ((rup % 10) == 8) result = "Ninty Eight";
            if ((rup % 10) == 9) result = "Ninty Nine";
        }
        return result;
    }

    public string RupeesinNumber(Int64 rup)
    {
        string result = "";
        Int64 res;
        if ((rup / 10000000) > 0 && (rup != 0))
        {
            res = rup / 10000000;
            rup = rup % 10000000;
            result = result + ' ' + res + " Crore";
        }
        if ((rup / 100000) > 0 && (rup != 0))
        {
            res = rup / 100000;
            rup = rup % 100000;
            result = result + ' ' + res + " Lakhs";
        }
        if ((rup / 1000) > 0 && (rup != 0))
        {
            res = rup / 1000;
            rup = rup % 1000;
            result = result + ' ' + res + " Thousand";
        }
        if ((rup / 100) > 0 && (rup != 0))
        {
            res = rup / 100;
            rup = rup % 100;
            result = result + ' ' + res + " Hundred";
        }
        if ((rup % 10) >= 0 && (rup != 0))
        {
            res = rup % 100;
            result = result + " " + res;
        }
        //result = result + ' ' + " Rupees only";
        return result;
    }
    #endregion


    public DataSet GetUidnumber(string districtid, string mandalid, string villageid)
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("USP_GET_TSIPASSUIDNO", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (districtid.Trim() == "" || districtid.Trim() == null)
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = districtid.ToString();


            if (mandalid.Trim() == "" || mandalid.Trim() == null)
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = mandalid.ToString();

            if (villageid.Trim() == "" || villageid.Trim() == null)
                da.SelectCommand.Parameters.Add("@VILLAGEID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@VILLAGEID", SqlDbType.VarChar).Value = villageid.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }


    }


    protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_village.SelectedIndex == 0)
            {
                ddltsipass.Items.Clear();
                AddSelectForTSipass(ddltsipass);
            }
            else
            {
                ddltsipass.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = GetUidnumber(ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddl_village.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddltsipass.DataSource = dsm.Tables[0];
                    ddltsipass.DataValueField = "intCFEEnterpid";
                    ddltsipass.DataTextField = "NAMEOFUNIT";
                    ddltsipass.DataBind();
                    AddSelectForTSipass(ddltsipass);
                }
                else
                {
                    ddltsipass.Items.Clear();
                    AddSelect(ddltsipass);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, "1000");
        }
    }

    public void AddSelectForTSipass(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            MSMEUNITDETAILS OBJMSMEUNITDETAILS = new MSMEUNITDETAILS();
            if (ddltsipass.SelectedItem.Text != "--Select--" || ddltsipass.SelectedIndex != 0)
            {
                OBJMSMEUNITDETAILS.VillageID = Convert.ToInt32(ddl_village.SelectedValue);
            }
            else
            {
                string message = "alert('Please select Village')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnsubmit.Enabled = false;
            }
            if (Request.QueryString[0].ToString().Trim() != null)
            {
                OBJMSMEUNITDETAILS.MSMENO = Request.QueryString[0].ToString().Trim().ToString();
            }
            else
            {
                OBJMSMEUNITDETAILS.MSMENO = null;
            }
            if (ddltsipass.SelectedItem.Text != "--Select--" || ddltsipass.SelectedIndex != 0)
            {
                OBJMSMEUNITDETAILS.tsipassuidno = ddltsipass.SelectedItem.Text;
                OBJMSMEUNITDETAILS.intcfeid = ddltsipass.SelectedValue.ToString();
            }
            int result = UpdateMsmeUnitDetailstsipass(OBJMSMEUNITDETAILS);
            if (result > 0)
            {
                string message = "alert('Application Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                success.Visible = true;
                lblmsg.Text = "Application Updated Successfully";
                btnsubmit.Enabled = false;
                Response.Redirect("frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + "01-03-2020" + "&todate=" + System.DateTime.Now.ToString("21-06-2021") + "&district=" + ddldistrict.SelectedValue);
            }
            else
            {
                string message = "alert('Application Not Processed please try Again!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnsubmit.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    public int UpdateMsmeUnitDetailstsipass(MSMEUNITDETAILS bc)
    {
        string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        int valid;
        SqlConnection connection = new SqlConnection(str);
        SqlTransaction transaction = null;
        connection.Open();
        transaction = connection.BeginTransaction();
        try
        {
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "MSME_Update_UNIT_DETAILS_UIDNO";
            com.Transaction = transaction;
            com.Connection = connection;

            com.Parameters.AddWithValue("@CREATED_BY", bc.CreatedBy);

            com.Parameters.AddWithValue("@MSME_NO", bc.MSMENO);

            com.Parameters.AddWithValue("@VillageID", bc.VillageID);

            if (bc.tsipassuidno == "" || bc.tsipassuidno == null)
                com.Parameters.AddWithValue("@tsipassuidno", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@tsipassuidno", SqlDbType.VarChar).Value = bc.tsipassuidno.Trim();

            if (bc.intcfeid == "" || bc.intcfeid == null)
                com.Parameters.AddWithValue("@intcfeid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                com.Parameters.AddWithValue("@intcfeid", SqlDbType.VarChar).Value = bc.intcfeid.Trim();

            com.Parameters.Add("@Valid", SqlDbType.Int, 500);
            com.Parameters["@Valid"].Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            valid = (Int32)com.Parameters["@Valid"].Value;
            transaction.Commit();
            connection.Close();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw ex;
        }
        finally
        {
            connection.Close();
            connection.Dispose();
        }
        return valid;


    }


    public int updatetsipassuidcfe()
    {
        int result = 0;
        try
        {

            MSMEUNITDETAILS OBJMSMEUNITDETAILS = new MSMEUNITDETAILS();
            if (ddltsipass.SelectedItem.Text != "--Select--" || ddltsipass.SelectedIndex != 0)
            {
                OBJMSMEUNITDETAILS.VillageID = Convert.ToInt32(ddl_village.SelectedValue);
                if (Request.QueryString[0].ToString().Trim() != null)
                {
                    OBJMSMEUNITDETAILS.MSMENO = Request.QueryString[0].ToString().Trim().ToString();
                }
                else
                {
                    OBJMSMEUNITDETAILS.MSMENO = null;
                }
                if (ddltsipass.SelectedItem.Text != "--Select--" || ddltsipass.SelectedIndex != 0)
                {
                    OBJMSMEUNITDETAILS.tsipassuidno = ddltsipass.SelectedItem.Text;
                    OBJMSMEUNITDETAILS.intcfeid = ddltsipass.SelectedValue.ToString();
                }
                result = UpdateMsmeUnitDetailstsipass(OBJMSMEUNITDETAILS);
                if (result > 0)
                {
                    //string message = "alert('Application Submitted Successfully')";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    //success.Visible = true;
                    //lblmsg.Text = "Application Updated Successfully";
                    //btnsubmit.Enabled = false;
                    //Response.Redirect("frmMSMEReportDRILLDOWN.aspx?ROLE=IPO&fromdate=" + "01-03-2020" + "&todate=" + System.DateTime.Now.ToString("21-06-2021") + "&district=" + ddldistrict.SelectedValue);
                }
                else
                {
                    //string message = "alert('Application Not Processed please try Again!!')";
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    //btnsubmit.Enabled = false;
                }

            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
        return result;

    }

    protected void txtskilledcontract_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtskilledoutsourcing_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtskilledtotal_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtsemiskilledcontract_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtsemiskilledtotal_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtsemiskilledoutsourcing_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtunskilledcontract_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtunskilledoutsourcing_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtunskilledtotal_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtmanagerialtotal_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtmanagerialoutsourcing_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }
    protected void txtmanagerialcontract_TextChanged(object sender, EventArgs e)
    {
        CalculatationEmployment();
    }

    public void CalculatationEmployment()
    {
        //if (ddlSector_Ent.SelectedIndex != 0)
        //{
        if (txtskilledcontract.Text.Trim() == "")
        {
            txtskilledcontract.Text = "0";
        }

        if (txtskilledoutsourcing.Text.Trim() == "")
        {
            txtskilledoutsourcing.Text = "0";
        }


        if (txtsemiskilledcontract.Text.Trim() == "")
        {
            txtsemiskilledcontract.Text = "0";
        }

        if (txtsemiskilledoutsourcing.Text.Trim() == "")
        {
            txtsemiskilledoutsourcing.Text = "0";
        }

        if (txtunskilledcontract.Text.Trim() == "")
        {
            txtunskilledcontract.Text = "0";
        }

        if (txtunskilledoutsourcing.Text.Trim() == "")
        {
            txtunskilledoutsourcing.Text = "0";
        }

        if (txtmanagerialcontract.Text.Trim() == "")
        {
            txtmanagerialcontract.Text = "0";
        }

        if (txtmanagerialoutsourcing.Text.Trim() == "")
        {
            txtmanagerialoutsourcing.Text = "0";
        }

        txtskilledtotal.Text = Convert.ToString((Convert.ToDecimal(txtskilledcontract.Text) + Convert.ToDecimal(txtskilledoutsourcing.Text)));
        txtsemiskilledtotal.Text = Convert.ToString((Convert.ToDecimal(txtsemiskilledcontract.Text) + Convert.ToDecimal(txtsemiskilledoutsourcing.Text)));
        txtunskilledtotal.Text = Convert.ToString((Convert.ToDecimal(txtunskilledcontract.Text) + Convert.ToDecimal(txtunskilledoutsourcing.Text)));
        txtmanagerialtotal.Text = Convert.ToString((Convert.ToDecimal(txtmanagerialcontract.Text) + Convert.ToDecimal(txtmanagerialoutsourcing.Text)));
        txt_noofdirectemp.Text = Convert.ToString((Convert.ToDecimal(txtskilledtotal.Text) + Convert.ToDecimal(txtsemiskilledtotal.Text) + (Convert.ToDecimal(txtunskilledtotal.Text) + Convert.ToDecimal(txtmanagerialtotal.Text))));
        txttotalcontract.Text = Convert.ToString((Convert.ToDecimal(txtskilledcontract.Text) + Convert.ToDecimal(txtsemiskilledcontract.Text) + (Convert.ToDecimal(txtunskilledcontract.Text) + Convert.ToDecimal(txtmanagerialcontract.Text))));
        txttotaloutsourcing.Text = Convert.ToString((Convert.ToDecimal(txtskilledoutsourcing.Text) + Convert.ToDecimal(txtsemiskilledoutsourcing.Text) + (Convert.ToDecimal(txtunskilledoutsourcing.Text) + Convert.ToDecimal(txtmanagerialoutsourcing.Text))));
        txtEmployment.Text = Convert.ToString((Convert.ToDecimal(txtskilledtotal.Text) + Convert.ToDecimal(txtsemiskilledtotal.Text) + (Convert.ToDecimal(txtunskilledtotal.Text) + Convert.ToDecimal(txtmanagerialtotal.Text))));
        //}
        //else
        //{
        //    TxtTot_PrjCost.Text = "0";
        //    lblmsg.Text = "Please Select Sector of Enterprise";
        //}
    }
    protected void txt_noofdirectemp_TextChanged(object sender, EventArgs e)
    {
        if (txt_noofdirectemp.Text.Trim() == "")
        {
            txt_noofdirectemp.Text = "0";
        }

        if (txt_totnoofindirectemp.Text.Trim() == "")
        {
            txt_totnoofindirectemp.Text = "0";
        }

        txttotalemployement.Text = Convert.ToString((Convert.ToDecimal(txt_noofdirectemp.Text) + Convert.ToDecimal(txt_totnoofindirectemp.Text)));
    }
    protected void txt_totnoofindirectemp_TextChanged(object sender, EventArgs e)
    {
        if (txt_noofdirectemp.Text.Trim() == "")
        {
            txt_noofdirectemp.Text = "0";
        }

        if (txt_totnoofindirectemp.Text.Trim() == "")
        {
            txt_totnoofindirectemp.Text = "0";
        }

        txttotalemployement.Text = Convert.ToString((Convert.ToDecimal(txt_noofdirectemp.Text) + Convert.ToDecimal(txt_totnoofindirectemp.Text)));

    }

    //protected void lnk_locationadd_Click(object sender, EventArgs e)
    //{
    //    lnk_locationadd.OnClientClick = "javascript:return onlocationclick()";
    //    //mp_FileNoting.Show();
    //    lnk_locationadd.OnClientClick = "javascript:return onlocationclick()";
    //}

    protected void txtlocal_TextChanged(object sender, EventArgs e)
    {
        if (txtlocal.Text != "")
        {
            //txtnonlocal.Text = Convert.ToString((Convert.ToDecimal(txtEmployment.Text) - Convert.ToDecimal(txtlocal.Text)));
        }
    }

    protected void txtmenemp_TextChanged(object sender, EventArgs e)
    {
        if (txtmenemp.Text != "")
        {
            txtwomen.Text = Convert.ToString((Convert.ToDecimal(txtEmployment.Text) - Convert.ToDecimal(txtmenemp.Text)));
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}