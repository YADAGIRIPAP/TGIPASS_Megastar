using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
//onkeypress="Names()"
public partial class UI_TSiPASS_frmMobileTowesTSROW : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DB.DB con = new DB.DB();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            BindDistricts_TSROW();
            BindDistricts_TSROWSITE();
            BindEXTENT();
            BINDDEPARTMENTS();
            FillDetails();
        }
    }
    public void FillDetails()
    {
        int CreatedBy = Convert.ToInt32(Session["uid"]);
        DataSet ds = new DataSet();

        ds = RetriveCinematographicDetails(CreatedBy);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                string App_Status = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationStatus"]);
                if (App_Status == "2")
                {
                    
                    Session["Applid"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileTowerID"]);
                    HDNMOBILETOWERID.Value = Convert.ToString(ds.Tables[0].Rows[0]["MobileTowerID"]);
                    txtorganisationname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Organizationname"]);
                    txtplotorflatno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Plotorflatno"]);
                    txtroadorstreet.Text = Convert.ToString(ds.Tables[0].Rows[0]["RoadorStreet"]);
                    txtcityortown.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityorTown"]);
                    ddldistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlMandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Mandal"]);
                    ddlMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlVillage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["village"]);
                    txtpincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pincode"]);
                    txtname_authorisedperson.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name_authorisedPerson"]);
                    txtdesignation_authorisedperson.Text = Convert.ToString(ds.Tables[0].Rows[0]["Designation_authorisedPerson"]);
                    txtphoneno_authorisedperson.Text = Convert.ToString(ds.Tables[0].Rows[0]["Phoneno_authorisedPerson"]);
                    txtemail_authorisedperson.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email_authorisedPerson"]);
                    ddlextent_proposedsite.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Extent_site"]);
                    ddlextent_proposedsite_SelectedIndexChanged(this, EventArgs.Empty);
                    ddltowertype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Towertype"]);
                    if (ddlextent_proposedsite.SelectedValue == "1")
                    {
                        trinstallationofland.Visible = true;
                        lblinstallationofland.Text = "INSTALLATION ON LAND (PRIVATE)";
                        trinstallationofbuildings.Visible = false;
                        trlanddetails.Visible = true;
                        trbuildingdetails.Visible = false;
                    }
                    if (ddlextent_proposedsite.SelectedValue == "4")
                    {
                        trinstallationofland.Visible = true;
                        lblinstallationofland.Text = "INSTALLATION ON LAND (GOVERNMENT)";
                        trinstallationofbuildings.Visible = false;
                        trlanddetails.Visible = true;
                        trbuildingdetails.Visible = false;
                    }
                    if(ddlextent_proposedsite.SelectedValue == "4"|| ddlextent_proposedsite.SelectedValue == "1")
                    {
                        txtlandrequired.Text = Convert.ToString(ds.Tables[0].Rows[0]["LandRequired_PrivateorGovt"]);
                        txtplotno_private.Text = Convert.ToString(ds.Tables[0].Rows[0]["PlotNo_PrivateorGovt"]);
                        txtroadorstreet_private.Text = Convert.ToString(ds.Tables[0].Rows[0]["roadorStreet_PrivateorGovt"]);
                        txtwardorblockno_private.Text = Convert.ToString(ds.Tables[0].Rows[0]["WardorBlock_PrivateorGovt"]);
                        txtcityortown_private.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityorTown_PrivateorGovt"]);
                    }
                    
                    if (ddlextent_proposedsite.SelectedValue == "2")
                    {
                        trinstallationofland.Visible = false;
                        lblinstallationofland.Text = "INSTALLATION ON BUILDINGS (PRIVATE)";
                        trinstallationofbuildings.Visible = true;
                        trlanddetails.Visible = false;
                        trbuildingdetails.Visible = true;
                    }
                    if (ddlextent_proposedsite.SelectedValue == "3")
                    {
                        trinstallationofland.Visible = false;
                        lblinstallationofland.Text = "INSTALLATION ON BUILDINGS (GOVERNMENT)";
                        trinstallationofbuildings.Visible = true;
                        trlanddetails.Visible = false;
                        trbuildingdetails.Visible = true;
                    }
                    if (ddlextent_proposedsite.SelectedValue == "2" || ddlextent_proposedsite.SelectedValue == "3")
                    {
                        txtnameofthebuildingorstructure.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameofbuilding_PrivateorGovt"]);
                        txtbuildingheight.Text = Convert.ToString(ds.Tables[0].Rows[0]["Heightofbuilding_PrivateorGovt"]);
                        ddlstoresofbuilding.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Storesofbuilding_PrivateorGovt"]);
                        txtareaofbuildingorstructure.Text = Convert.ToString(ds.Tables[0].Rows[0]["Areaofbuilding_PrivateorGovt"]);
                        txthouseno_building.Text = Convert.ToString(ds.Tables[0].Rows[0]["HNOofbuilding_PrivateorGovt"]);
                        txtstreet_building.Text = Convert.ToString(ds.Tables[0].Rows[0]["Streetofbuilding_PrivateorGovt"]);
                        txtlocality_building.Text = Convert.ToString(ds.Tables[0].Rows[0]["Localityofbuilding_PrivateorGovt"]);
                        txtlandmark_building.Text = Convert.ToString(ds.Tables[0].Rows[0]["LandMarkofbuilding_PrivateorGovt"]);
                        txtpincode_building.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pincodeofbuilding_PrivateorGovt"]);
                    }
                   
                    txttowerheight.Text = Convert.ToString(ds.Tables[0].Rows[0]["TowerHeight"]);
                    txtplotsize.Text = Convert.ToString(ds.Tables[0].Rows[0]["PlotSize"]);
                    ddldepartment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Department"]);
                    ddlsitedistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["District_Site"]);
                    if (ddldepartment.SelectedValue == "1")
                    {
                        trward.Visible = false;
                        trmuncipality.Visible = false;
                        trpanchayatrajED.Visible = false;
                        trpanchayatrajRD.Visible = false;
                        trmandal_site.Visible = false;
                    }
                    if (ddldepartment.SelectedValue == "2")
                    {
                        trward.Visible = true;
                        ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlward.SelectedValue= Convert.ToString(ds.Tables[0].Rows[0]["Ward_Site"]);
                        trmuncipality.Visible = false;
                        trpanchayatrajED.Visible = false;
                        trpanchayatrajRD.Visible = false;
                        trmandal_site.Visible = false;
                    }
                    if (ddldepartment.SelectedValue == "4")
                    {
                        trward.Visible = false;
                        trmuncipality.Visible = true;
                        ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlmuncipality.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Muncipality_Site"]);
                        trpanchayatrajED.Visible = false;
                        trpanchayatrajRD.Visible = false;
                        trmandal_site.Visible = false;
                    }
                    if (ddldepartment.SelectedValue == "5")
                    {
                        trward.Visible = false;
                        trmuncipality.Visible = false;
                        trpanchayatrajED.Visible = true;
                        ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlpanchayatED.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PanchayatED_Site"]);
                        trpanchayatrajRD.Visible = false;
                        trmandal_site.Visible = false;
                    }
                    if (ddldepartment.SelectedValue == "9")
                    {
                        trward.Visible = false;
                        trmuncipality.Visible = false;
                        trpanchayatrajED.Visible = false;
                        trpanchayatrajRD.Visible = true;
                        trmandal_site.Visible = true;
                        ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlsitemandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Mandal_Site"]);
                        ddlsitemandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlpanchayatRD.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PanchayatRD_Site"]);
                    }

                    txtlatitude.Text = Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]);
                    txtlongitude.Text = Convert.ToString(ds.Tables[0].Rows[0]["Longitude"]);
                    txtowername.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerName"]);
                    txtowneraddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerAddress"]);
                    txtmodeandtimeduration.Text = Convert.ToString(ds.Tables[0].Rows[0]["ModeandTime_Work"]);
                    txtinconvenience.Text = Convert.ToString(ds.Tables[0].Rows[0]["Inconvenience"]);

                    txtmeasuresproposed.Text = Convert.ToString(ds.Tables[0].Rows[0]["MeasuresProposed"]);

                    txtname_employee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name_Employee"]);

                    txtaddress_employee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address_Employee"]);
                    txtmobileno_employee.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo_Employee"]);

                    txtemail_employee.Text = Convert.ToString(ds.Tables[0].Rows[0]["Email_Employee"]);
                    txtanyothermatter.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnyotherMatter"]);

                    txtadministrativecharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["AdministrativeCharges"]);
                    txtGST.Text = Convert.ToString(ds.Tables[0].Rows[0]["GST"]);



                }


            }
        }




    }
    public DataSet RetriveCinematographicDetails(int CREATEDBY)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetmobileTowerDetails_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = CREATEDBY;
           
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
    public void BindEXTENT()
    {
        try
        {

            DataSet dsd = new DataSet();

            dsd = GetEXTENT_TSROW();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlextent_proposedsite.DataSource = dsd.Tables[0];
                ddlextent_proposedsite.DataValueField = "extent_id";
                ddlextent_proposedsite.DataTextField = "extent_name";
                ddlextent_proposedsite.DataBind();
                ddlextent_proposedsite.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlextent_proposedsite.Items.Insert(0, "--Select--");
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
    public DataSet GetEXTENT_TSROW()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETEXTENT_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public void BindDistricts_TSROW()
    {
        try
        {
            
            DataSet dsd = new DataSet();
            
            dsd = GetDistricts_TSROW();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = dsd.Tables[0];
                ddldistrict.DataValueField = "district_id";
                ddldistrict.DataTextField = "district_name";
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public DataSet GetDistricts_TSROW()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETDISTRICTS_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public void BindDistricts_TSROWSITE()
    {
        try
        {

            DataSet dsd = new DataSet();

            dsd = GetDistricts_TSROWSITE();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlsitedistrict.DataSource = dsd.Tables[0];
                ddlsitedistrict.DataValueField = "district_id";
                ddlsitedistrict.DataTextField = "district_name";
                ddlsitedistrict.DataBind();
                ddlsitedistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlsitedistrict.Items.Insert(0, "--Select--");
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
    public DataSet GetDistricts_TSROWSITE()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETDISTRICTS_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public void BINDDEPARTMENTS()
    {
        try
        {

            DataSet dsd = new DataSet();

            dsd = GETDEPARTMENTS_TSROW();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddldepartment.DataSource = dsd.Tables[0];
                ddldepartment.DataValueField = "dept_id";
                ddldepartment.DataTextField = "dept_name";
                ddldepartment.DataBind();
                ddldepartment.Items.Insert(0, "--Select--");
            }
            else
            {
                ddldepartment.Items.Insert(0, "--Select--");
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
    public DataSet GETDEPARTMENTS_TSROW()
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETDEPARTMENT_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    public DataSet GetMANDALS_TSROW(string DISTRICTID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETMANDALS_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null|| DISTRICTID.Trim()=="--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DISTRICTID.ToString();
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
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (txtorganisationname.Text == "" || txtorganisationname.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Name of Organisation \\n";
            slno = slno + 1;
        }
        if (txtplotorflatno.Text == "" || txtplotorflatno.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Plot/Flat No \\n";
            slno = slno + 1;
        }
        if (txtroadorstreet.Text == "" || txtroadorstreet.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Road/Street Name \\n";
            slno = slno + 1;
        }
        if (txtcityortown.Text == "" || txtcityortown.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter City/Town Name \\n";
            slno = slno + 1;
        }

        if (ddldistrict.SelectedValue == "0" || ddldistrict.SelectedValue == "--Select--" || ddldistrict.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select District \\n";
            slno = slno + 1;
        }
        if (ddlMandal.SelectedValue == "0" || ddlMandal.SelectedValue == "--Select--" || ddlMandal.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Mandal \\n";
            slno = slno + 1;
        }
        if (ddlVillage.SelectedValue == "0" || ddlVillage.SelectedValue == "--Select--" || ddlVillage.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Village \\n";
            slno = slno + 1;
        }
        if (txtpincode.Text == "" || txtpincode.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Pincode \\n";
            slno = slno + 1;
        }
        if (txtname_authorisedperson.Text == "" || txtname_authorisedperson.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Authorised Person Name  \\n";
            slno = slno + 1;
        }
        if (txtdesignation_authorisedperson.Text == "" || txtdesignation_authorisedperson.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Authorised Person Designamtion  \\n";
            slno = slno + 1;
        }
        if (txtphoneno_authorisedperson.Text == "" || txtphoneno_authorisedperson.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Authorised Person Phone/Mobile No  \\n";
            slno = slno + 1;
        }
        if (txtemail_authorisedperson.Text == "" || txtemail_authorisedperson.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Authorised Person Email  \\n";
            slno = slno + 1;
        }
        if (ddlextent_proposedsite.SelectedValue == "0" || ddlextent_proposedsite.SelectedValue == "--Select--" || ddlextent_proposedsite.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Extent \\n";
            slno = slno + 1;
        }
        if (ddltowertype.SelectedValue == "0" || ddltowertype.SelectedValue == "--Select--" || ddltowertype.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Tower Type \\n";
            slno = slno + 1;
        }
        if (txttowerheight.Text == "" || txttowerheight.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Tower Height(sq.ft)  \\n";
            slno = slno + 1;
        }
        if (txtplotsize.Text == "" || txtplotsize.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Plot Size(sq.ft)  \\n";
            slno = slno + 1;
        }
        if (ddldepartment.SelectedValue == "0" || ddldepartment.SelectedValue == "--Select--" || ddldepartment.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Department \\n";
            slno = slno + 1;
        }
        if (ddlsitedistrict.SelectedValue == "0" || ddlsitedistrict.SelectedValue == "--Select--" || ddlsitedistrict.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Site District \\n";
            slno = slno + 1;
        }

        if (ddldepartment.SelectedValue == "2")
        {
            if (ddlward.SelectedValue == "0" || ddlward.SelectedValue == "--Select--" || ddlward.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Site Ward \\n";
                slno = slno + 1;
            }
        }
        if (ddldepartment.SelectedValue == "4")
        {
            if (ddlmuncipality.SelectedValue == "0" || ddlmuncipality.SelectedValue == "--Select--" || ddlmuncipality.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Site muncipality \\n";
                slno = slno + 1;
            }
        }
        if (ddldepartment.SelectedValue == "5")
        {
            if (ddlpanchayatED.SelectedValue == "0" || ddlpanchayatED.SelectedValue == "--Select--" || ddlpanchayatED.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Site Panchayat-ED \\n";
                slno = slno + 1;
            }
        }
        if (ddldepartment.SelectedValue == "9")
        {
            if (ddlsitemandal.SelectedValue == "0" || ddlsitemandal.SelectedValue == "--Select--" || ddlsitemandal.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Site Mandal \\n";
                slno = slno + 1;
            }
            if (ddlpanchayatRD.SelectedValue == "0" || ddlpanchayatRD.SelectedValue == "--Select--" || ddlpanchayatRD.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Site Panchayat-RD \\n";
                slno = slno + 1;
            }
        }
        if (ddlextent_proposedsite.SelectedValue == "1" || ddlextent_proposedsite.SelectedValue == "4")
        {
            if (txtlandrequired.Text == "" || txtlandrequired.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Land Required (Size & Area in meter) \\n";
                slno = slno + 1;
            }
            if (txtplotno_private.Text == "" || txtplotno_private.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Plot No. \\n";
                slno = slno + 1;
            }
            if (txtroadorstreet_private.Text == "" || txtroadorstreet_private.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Road/ Street \\n";
                slno = slno + 1;
            }
            if (txtwardorblockno_private.Text == "" || txtwardorblockno_private.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Ward No./ Block No. & Locality \\n";
                slno = slno + 1;
            }
            if (txtcityortown_private.Text == "" || txtcityortown_private.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter City/ Town \\n";
                slno = slno + 1;
            }
        }

        if (ddlextent_proposedsite.SelectedValue == "2" || ddlextent_proposedsite.SelectedValue == "3")
        {
            if (txtnameofthebuildingorstructure.Text == "" || txtnameofthebuildingorstructure.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Name of the Building/ Structure \\n";
                slno = slno + 1;
            }
            if (txtbuildingheight.Text == "" || txtbuildingheight.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Height of building (Meters) \\n";
                slno = slno + 1;
            }
            if (ddlstoresofbuilding.SelectedValue == "0" || ddlstoresofbuilding.SelectedValue == "--Select--" || ddlstoresofbuilding.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Stores of building \\n";
                slno = slno + 1;
            }
            if (txtareaofbuildingorstructure.Text == "" || txtareaofbuildingorstructure.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Area of the building/structure \\n";
                slno = slno + 1;
            }
            if (txthouseno_building.Text == "" || txthouseno_building.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter H.No \\n";
                slno = slno + 1;
            }
            if (txtstreet_building.Text == "" || txtstreet_building.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Street \\n";
                slno = slno + 1;
            }
            if (txtlocality_building.Text == "" || txtlocality_building.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Locality \\n";
                slno = slno + 1;
            }
            if (txtlandmark_building.Text == "" || txtlandmark_building.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Landmark \\n";
                slno = slno + 1;
            }
            if (txtpincode_building.Text == "" || txtpincode_building.Text == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Pin code \\n";
                slno = slno + 1;
            }
        }
        if (txtlatitude.Text == "" || txtlatitude.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Exact Latitude of the Proposed Site \\n";
            slno = slno + 1;
        }
        if (txtlongitude.Text == "" || txtlongitude.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Exact Longitude of the Proposed Site \\n";
            slno = slno + 1;
        }

        if (txtowername.Text == "" || txtowername.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Name of Owner \\n";
            slno = slno + 1;
        }
        if (txtowneraddress.Text == "" || txtowneraddress.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Address of Owner \\n";
            slno = slno + 1;
        }
        if (txtmodeandtimeduration.Text == "" || txtmodeandtimeduration.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The mode of and the time duration for execution of the work \\n";
            slno = slno + 1;
        }
        if (txtinconvenience.Text == "" || txtinconvenience.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The inconvenience that is likely to be caused to the public and the specific measures to be taken to mitigate such inconvenience \\n";
            slno = slno + 1;
        }
        if (txtmeasuresproposed.Text == "" || txtmeasuresproposed.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter The measures proposed to be taken to ensure public safety during the execution of the work \\n";
            slno = slno + 1;
        }
        if (txtname_employee.Text == "" || txtname_employee.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Employee Name \\n";
            slno = slno + 1;
        }
        if (txtaddress_employee.Text == "" || txtaddress_employee.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Employee Address \\n";
            slno = slno + 1;
        }
        if (txtmobileno_employee.Text == "" || txtmobileno_employee.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Employee Mobile No \\n";
            slno = slno + 1;
        }
        if (txtemail_employee.Text == "" || txtemail_employee.Text == null)
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Employee Email \\n";
            slno = slno + 1;
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        try
        {
            DataSet ds1 = new DataSet();
            ds1 = InsertMobileTower_TSROW(txtorganisationname.Text, txtplotorflatno.Text,txtroadorstreet.Text,txtcityortown.Text,
               ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue,txtpincode.Text,
                txtname_authorisedperson.Text, txtdesignation_authorisedperson.Text, txtphoneno_authorisedperson.Text,
                txtemail_authorisedperson.Text, 
                ddlextent_proposedsite.SelectedValue, ddltowertype.SelectedValue,txttowerheight.Text,
                txtplotsize.Text, ddldepartment.SelectedValue, ddlsitedistrict.SelectedValue,
                ddlward.SelectedValue,ddlmuncipality.SelectedValue,ddlpanchayatED.SelectedValue, ddlsitemandal.SelectedValue,
                ddlpanchayatRD.SelectedValue,txtlandrequired.Text, txtplotno_private.Text,
                txtroadorstreet_private.Text,txtwardorblockno_private.Text,txtcityortown_private.Text,              
                txtnameofthebuildingorstructure.Text,txtbuildingheight.Text, ddlstoresofbuilding.SelectedValue,
                txtareaofbuildingorstructure.Text, txthouseno_building.Text, txtstreet_building.Text,
                txtlocality_building.Text, txtlandmark_building.Text, txtpincode_building.Text,
                txtlatitude.Text,txtlongitude.Text, txtowername.Text, txtowneraddress.Text,
                txtmodeandtimeduration.Text, txtinconvenience.Text, txtmeasuresproposed.Text,
                txtname_employee.Text,txtaddress_employee.Text, txtmobileno_employee.Text,
                txtemail_employee.Text, txtanyothermatter.Text, txtadministrativecharges.Text,
                txtGST.Text,Session["uid"].ToString(), HDNMOBILETOWERID.Value);

            if (ds1.Tables[0].Rows.Count > 0)
            {

                string a;
                a = ds1.Tables[0].Rows[0]["value"].ToString();
                ViewState["MOBILETOWERID"]= ds1.Tables[0].Rows[0]["uniqueid"].ToString();
                if (a == "1")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    //BtnSave.Enabled = false;
                    return;
                }
                if (a == "2")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                    //BtnSave.Enabled = false;
                    return;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Filed To Insert')", true);
                //BtnSave.Enabled = false;
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet InsertMobileTower_TSROW(string Organizationname, string Plotorflatno,
    string RoadorStreet, string CityorTown, string District, string Mandal,
    string village, string Pincode, string Name_authorisedPerson,
    string Designation_authorisedPerson, string Phoneno_authorisedPerson,
    string Email_authorisedPerson, string Extent_site, string Towertype,
    string TowerHeight, string PlotSize, string Department, string District_Site,
    string Ward_Site, string Muncipality_Site, string PanchayatED_Site,
    string Mandal_Site,string PanchayatRD_Site, string LandRequired_PrivateorGovt,
    string PlotNo_PrivateorGovt, string roadorStreet_PrivateorGovt,
    string WardorBlock_PrivateorGovt,string CityorTown_PrivateorGovt,
    string Nameofbuilding_PrivateorGovt, string Heightofbuilding_PrivateorGovt, 
    string Storesofbuilding_PrivateorGovt,string Areaofbuilding_PrivateorGovt, 
    string HNOofbuilding_PrivateorGovt, string Streetofbuilding_PrivateorGovt,
    string Localityofbuilding_PrivateorGovt,string LandMarkofbuilding_PrivateorGovt, 
    string Pincodeofbuilding_PrivateorGovt,string Latitude, string Longitude,
    string OwnerName, string OwnerAddress,string ModeandTime_Work, 
    string Inconvenience, string MeasuresProposed,string Name_Employee,
    string Address_Employee, string MobileNo_Employee,string Email_Employee, 
    string AnyotherMatter, string AdministrativeCharges,string GST,
    string createdby, string MobileTowerID)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_INSERT_MOBILETOWER_TSROW", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            
            if (Organizationname.Trim() == "" || Organizationname.Trim() == null || Organizationname.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Organizationname", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Organizationname", SqlDbType.VarChar).Value = Organizationname.ToString();
            if (Plotorflatno.Trim() == "" || Plotorflatno.Trim() == null || Plotorflatno.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Plotorflatno", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Plotorflatno", SqlDbType.VarChar).Value = Plotorflatno.ToString();
            if (RoadorStreet.Trim() == "" || RoadorStreet.Trim() == null || RoadorStreet.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@RoadorStreet", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@RoadorStreet", SqlDbType.VarChar).Value = RoadorStreet.ToString();
            if (CityorTown.Trim() == "" || CityorTown.Trim() == null || CityorTown.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@CityorTown", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@CityorTown", SqlDbType.VarChar).Value = CityorTown.ToString();


            if (District.Trim() == "" || District.Trim() == null || District.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = District.ToString();

            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = Mandal.ToString();

            if (village.Trim() == "" || village.Trim() == null || village.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@village", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@village", SqlDbType.VarChar).Value = village.ToString();

            if (Pincode.Trim() == "" || Pincode.Trim() == null || Pincode.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = Pincode.ToString();
           
            if (Name_authorisedPerson.Trim() == "" || Name_authorisedPerson.Trim() == null || Name_authorisedPerson.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Name_authorisedPerson", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Name_authorisedPerson", SqlDbType.VarChar).Value = Name_authorisedPerson.ToString();

            if (Designation_authorisedPerson.Trim() == "" || Designation_authorisedPerson.Trim() == null || Designation_authorisedPerson.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Designation_authorisedPerson", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Designation_authorisedPerson", SqlDbType.VarChar).Value = Designation_authorisedPerson.ToString();



            if (Phoneno_authorisedPerson.Trim() == "" || Phoneno_authorisedPerson.Trim() == null || Phoneno_authorisedPerson.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Phoneno_authorisedPerson", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Phoneno_authorisedPerson", SqlDbType.VarChar).Value = Phoneno_authorisedPerson.ToString();

            if (Email_authorisedPerson.Trim() == "" || Email_authorisedPerson.Trim() == null || Email_authorisedPerson.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Email_authorisedPerson", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Email_authorisedPerson", SqlDbType.VarChar).Value = Email_authorisedPerson.ToString();


            if (Extent_site.Trim() == "" || Extent_site.Trim() == null || Extent_site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Extent_site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Extent_site", SqlDbType.VarChar).Value = Extent_site.ToString();

            if (Towertype.Trim() == "" || Towertype.Trim() == null || Towertype.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Towertype", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Towertype", SqlDbType.VarChar).Value = Towertype.ToString();

            if (TowerHeight.Trim() == "" || TowerHeight.Trim() == null || TowerHeight.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@TowerHeight", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@TowerHeight", SqlDbType.VarChar).Value = TowerHeight.ToString();

            if (PlotSize.Trim() == "" || PlotSize.Trim() == null || PlotSize.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@PlotSize", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@PlotSize", SqlDbType.VarChar).Value = PlotSize.ToString();

            ///

            if (Department.Trim() == "" || Department.Trim() == null || Department.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Department", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Department", SqlDbType.VarChar).Value = Department.ToString();
            if (District_Site.Trim() == "" || District_Site.Trim() == null || District_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@District_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@District_Site", SqlDbType.VarChar).Value = District_Site.ToString();
            if (Ward_Site.Trim() == "" || Ward_Site.Trim() == null || Ward_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Ward_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Ward_Site", SqlDbType.VarChar).Value = Ward_Site.ToString();
            if (Muncipality_Site.Trim() == "" || Muncipality_Site.Trim() == null || Muncipality_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Muncipality_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Muncipality_Site", SqlDbType.VarChar).Value = Muncipality_Site.ToString();


            if (PanchayatED_Site.Trim() == "" || PanchayatED_Site.Trim() == null || PanchayatED_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@PanchayatED_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@PanchayatED_Site", SqlDbType.VarChar).Value = PanchayatED_Site.ToString();

            if (Mandal_Site.Trim() == "" || Mandal_Site.Trim() == null || Mandal_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Mandal_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Mandal_Site", SqlDbType.VarChar).Value = Mandal_Site.ToString();

            if (PanchayatRD_Site.Trim() == "" || PanchayatRD_Site.Trim() == null || PanchayatRD_Site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@PanchayatRD_Site", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@PanchayatRD_Site", SqlDbType.VarChar).Value = PanchayatRD_Site.ToString();

            if (LandRequired_PrivateorGovt.Trim() == "" || LandRequired_PrivateorGovt.Trim() == null || LandRequired_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@LandRequired_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@LandRequired_PrivateorGovt", SqlDbType.VarChar).Value = LandRequired_PrivateorGovt.ToString();

            if (PlotNo_PrivateorGovt.Trim() == "" || PlotNo_PrivateorGovt.Trim() == null || PlotNo_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@PlotNo_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@PlotNo_PrivateorGovt", SqlDbType.VarChar).Value = PlotNo_PrivateorGovt.ToString();

            if (roadorStreet_PrivateorGovt.Trim() == "" || roadorStreet_PrivateorGovt.Trim() == null || roadorStreet_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@roadorStreet_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@roadorStreet_PrivateorGovt", SqlDbType.VarChar).Value = roadorStreet_PrivateorGovt.ToString();



            if (WardorBlock_PrivateorGovt.Trim() == "" || WardorBlock_PrivateorGovt.Trim() == null || WardorBlock_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@WardorBlock_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@WardorBlock_PrivateorGovt", SqlDbType.VarChar).Value = WardorBlock_PrivateorGovt.ToString();

            if (CityorTown_PrivateorGovt.Trim() == "" || CityorTown_PrivateorGovt.Trim() == null || CityorTown_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@CityorTown_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@CityorTown_PrivateorGovt", SqlDbType.VarChar).Value = CityorTown_PrivateorGovt.ToString();

            //
            if (Nameofbuilding_PrivateorGovt.Trim() == "" || Nameofbuilding_PrivateorGovt.Trim() == null || Extent_site.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Nameofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Nameofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Nameofbuilding_PrivateorGovt.ToString();

            if (Storesofbuilding_PrivateorGovt.Trim() == "" || Storesofbuilding_PrivateorGovt.Trim() == null || Storesofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Storesofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Storesofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Storesofbuilding_PrivateorGovt.ToString();

            if (Areaofbuilding_PrivateorGovt.Trim() == "" || Areaofbuilding_PrivateorGovt.Trim() == null || Areaofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Areaofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Areaofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Areaofbuilding_PrivateorGovt.ToString();

            if (HNOofbuilding_PrivateorGovt.Trim() == "" || HNOofbuilding_PrivateorGovt.Trim() == null || HNOofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@HNOofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@HNOofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = HNOofbuilding_PrivateorGovt.ToString();


            if (Streetofbuilding_PrivateorGovt.Trim() == "" || Streetofbuilding_PrivateorGovt.Trim() == null || Streetofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Streetofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Streetofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Streetofbuilding_PrivateorGovt.ToString();

            //
            if (Localityofbuilding_PrivateorGovt.Trim() == "" || Localityofbuilding_PrivateorGovt.Trim() == null || Localityofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Localityofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Localityofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Localityofbuilding_PrivateorGovt.ToString();

            if (LandMarkofbuilding_PrivateorGovt.Trim() == "" || LandMarkofbuilding_PrivateorGovt.Trim() == null || LandMarkofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@LandMarkofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@LandMarkofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = LandMarkofbuilding_PrivateorGovt.ToString();

            if (Pincodeofbuilding_PrivateorGovt.Trim() == "" || Pincodeofbuilding_PrivateorGovt.Trim() == null || Pincodeofbuilding_PrivateorGovt.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Pincodeofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Pincodeofbuilding_PrivateorGovt", SqlDbType.VarChar).Value = Pincodeofbuilding_PrivateorGovt.ToString();

            if (Latitude.Trim() == "" || Latitude.Trim() == null || Latitude.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = Latitude.ToString();

            if (Longitude.Trim() == "" || Longitude.Trim() == null || Longitude.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = Longitude.ToString();

            if (OwnerName.Trim() == "" || OwnerName.Trim() == null || OwnerName.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = OwnerName.ToString();

            if (OwnerAddress.Trim() == "" || OwnerAddress.Trim() == null || OwnerAddress.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@OwnerAddress", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@OwnerAddress", SqlDbType.VarChar).Value = OwnerAddress.ToString();

            if (ModeandTime_Work.Trim() == "" || ModeandTime_Work.Trim() == null || ModeandTime_Work.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ModeandTime_Work", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ModeandTime_Work", SqlDbType.VarChar).Value = ModeandTime_Work.ToString();

            if (Inconvenience.Trim() == "" || Inconvenience.Trim() == null || Inconvenience.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Inconvenience", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Inconvenience", SqlDbType.VarChar).Value = Inconvenience.ToString();
            
            if (MeasuresProposed.Trim() == "" || MeasuresProposed.Trim() == null || MeasuresProposed.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@MeasuresProposed", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@MeasuresProposed", SqlDbType.VarChar).Value = MeasuresProposed.ToString();

            if (Name_Employee.Trim() == "" || Name_Employee.Trim() == null || Name_Employee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Name_Employee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Name_Employee", SqlDbType.VarChar).Value = Name_Employee.ToString();
            if (Address_Employee.Trim() == "" || Address_Employee.Trim() == null || Address_Employee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Address_Employee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Address_Employee", SqlDbType.VarChar).Value = Address_Employee.ToString();

            if (MobileNo_Employee.Trim() == "" || MobileNo_Employee.Trim() == null || MobileNo_Employee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@MobileNo_Employee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@MobileNo_Employee", SqlDbType.VarChar).Value = MobileNo_Employee.ToString();

            if (Email_Employee.Trim() == "" || Email_Employee.Trim() == null || Email_Employee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Email_Employee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Email_Employee", SqlDbType.VarChar).Value = Email_Employee.ToString();

            if (AnyotherMatter.Trim() == "" || AnyotherMatter.Trim() == null || AnyotherMatter.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@AnyotherMatter", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@AnyotherMatter", SqlDbType.VarChar).Value = AnyotherMatter.ToString();

            if (AdministrativeCharges.Trim() == "" || AdministrativeCharges.Trim() == null || AdministrativeCharges.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@AdministrativeCharges", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@AdministrativeCharges", SqlDbType.VarChar).Value = AdministrativeCharges.ToString();

            if (GST.Trim() == "" || GST.Trim() == null || GST.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@GST", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@GST", SqlDbType.VarChar).Value = GST.ToString();

            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();


            if (MobileTowerID.Trim() == "" || MobileTowerID.Trim() == null || MobileTowerID.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@MobileTowerID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@MobileTowerID", SqlDbType.VarChar).Value = MobileTowerID.ToString();


            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            if (osqlConnection.State != ConnectionState.Closed)
                osqlConnection.Close();
        }
    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet dsd = new DataSet();
            
            dsd = GetMANDALS_TSROW(ddldistrict.SelectedValue);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlMandal.DataSource = dsd.Tables[0];
                ddlMandal.DataValueField = "mandal_id";
                ddlMandal.DataTextField = "mandal_name";
                ddlMandal.DataBind();
                ddlMandal.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlMandal.Items.Insert(0, "--Select--");
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
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataSet dsd = new DataSet();
           
            dsd = GetVillages_TSROW(ddldistrict.SelectedValue,ddlMandal.SelectedValue);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlVillage.DataSource = dsd.Tables[0];
                ddlVillage.DataValueField = "village_id";
                ddlVillage.DataTextField = "village_name";
                ddlVillage.DataBind();
                ddlVillage.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlVillage.Items.Insert(0, "--Select--");
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
    public DataSet GetVillages_TSROW(string DISTRICTID, string MANDALID)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETVILLAGES_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null || DISTRICTID.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID", SqlDbType.VarChar).Value = DISTRICTID.ToString();
            if (MANDALID.Trim() == "" || MANDALID.Trim() == null || MANDALID.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@MANDALID", SqlDbType.VarChar).Value = MANDALID.ToString();
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
    protected void ddlextent_proposedsite_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlextent_proposedsite.SelectedValue=="1")
        {
            trinstallationofland.Visible = true;
            lblinstallationofland.Text = "INSTALLATION ON LAND (PRIVATE)";
            trinstallationofbuildings.Visible = false;
            trlanddetails.Visible = true;
            trbuildingdetails.Visible = false;
        }
        if (ddlextent_proposedsite.SelectedValue == "4")
        {
            trinstallationofland.Visible = true;
            lblinstallationofland.Text = "INSTALLATION ON LAND (GOVERNMENT)";
            trinstallationofbuildings.Visible = false;
            trlanddetails.Visible = true;
            trbuildingdetails.Visible = false;
        }
        if (ddlextent_proposedsite.SelectedValue == "2")
        {
            trinstallationofland.Visible = false;
            lblinstallationofland.Text = "INSTALLATION ON BUILDINGS (PRIVATE)";
            trinstallationofbuildings.Visible = true;
            trlanddetails.Visible = false;
            trbuildingdetails.Visible = true;
        }
        if (ddlextent_proposedsite.SelectedValue == "3")
        {
            trinstallationofland.Visible = false;
            lblinstallationofland.Text = "INSTALLATION ON BUILDINGS (GOVERNMENT)";
            trinstallationofbuildings.Visible = true;
            trlanddetails.Visible = false;
            trbuildingdetails.Visible = true;
        }
        try
        {

            DataSet dsd = new DataSet();
            //if(ddlextent_proposedsite.SelectedValue=="1"|| ddlextent_proposedsite.SelectedValue == "3")
            //{
            //    ddlextent_proposedsite.SelectedItem.Text = "LAND";
            //}
            //if (ddlextent_proposedsite.SelectedValue == "2" || ddlextent_proposedsite.SelectedValue == "4")
            //{
            //    ddlextent_proposedsite.SelectedItem.Text = "BUILDINGS";
            //}
            dsd = GETTOWERTYPE(ddlextent_proposedsite.SelectedValue);
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddltowertype.DataSource = dsd.Tables[0];
                ddltowertype.DataValueField = "tower_type_id";
                ddltowertype.DataTextField = "tower_type_name";
                ddltowertype.DataBind();
                ddltowertype.Items.Insert(0, "--Select--");
            }
            else
            {
                ddltowertype.Items.Insert(0, "--Select--");
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
    public DataSet GETTOWERTYPE(string ddlextent)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETTOWERTYPE_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ddlextent.Trim() == "" || ddlextent.Trim() == null || ddlextent.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@ddlextent", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@ddlextent", SqlDbType.VarChar).Value = ddlextent.ToString();
           
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
    protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlsitedistrict.ClearSelection();
        if(ddldepartment.SelectedValue == "1")
        {
            trward.Visible = false;
            trmuncipality.Visible = false;
            trpanchayatrajED.Visible = false;
            trpanchayatrajRD.Visible = false;
            trmandal_site.Visible = false;
        }
        if (ddldepartment.SelectedValue=="2")
        {
            trward.Visible = true;
            trmuncipality.Visible = false;
            trpanchayatrajED.Visible = false;
            trpanchayatrajRD.Visible = false;
            trmandal_site.Visible = false;
        }
        if (ddldepartment.SelectedValue == "4")
        {
            trward.Visible = false;
            trmuncipality.Visible = true;
            trpanchayatrajED.Visible = false;
            trpanchayatrajRD.Visible = false;
            trmandal_site.Visible = false;
        }
        if (ddldepartment.SelectedValue == "5")
        {
            trward.Visible = false;
            trmuncipality.Visible = false;
            trpanchayatrajED.Visible = true;
            trpanchayatrajRD.Visible = false;
            trmandal_site.Visible = false;
        }
        if (ddldepartment.SelectedValue == "9")
        {
            trward.Visible = false;
            trmuncipality.Visible = false;
            trpanchayatrajED.Visible = false;
            trpanchayatrajRD.Visible = true;
            trmandal_site.Visible = true;
        }

    }
    protected void ddlsitedistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddldepartment.SelectedValue=="2")
        {
            try
            {

                DataSet dsd = new DataSet();

                dsd = GetWards(ddlsitedistrict.SelectedValue);
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlward.DataSource = dsd.Tables[0];
                    ddlward.DataValueField = "ward_no";
                    ddlward.DataTextField = "ward_name";
                    ddlward.DataBind();
                    ddlward.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlward.Items.Insert(0, "--Select--");
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
       
        if (ddldepartment.SelectedValue == "4")
        {
            try
            {

                DataSet dsd = new DataSet();

                dsd = GetMuncipolities(ddlsitedistrict.SelectedValue);
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlmuncipality.DataSource = dsd.Tables[0];
                    ddlmuncipality.DataValueField = "municipality_id";
                    ddlmuncipality.DataTextField = "municipality_name";
                    ddlmuncipality.DataBind();
                    ddlmuncipality.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlmuncipality.Items.Insert(0, "--Select--");
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
        if (ddldepartment.SelectedValue == "5")
        {
            try
            {

                DataSet dsd = new DataSet();

                dsd = GetPANCHAYAT_ED(ddlsitedistrict.SelectedValue);
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlpanchayatED.DataSource = dsd.Tables[0];
                    ddlpanchayatED.DataValueField = "panchayath_id";
                    ddlpanchayatED.DataTextField = "panchayath_name";
                    ddlpanchayatED.DataBind();
                    ddlpanchayatED.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlpanchayatED.Items.Insert(0, "--Select--");
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
        if (ddldepartment.SelectedValue == "9")
        {
            try
            {

                DataSet dsd = new DataSet();

                dsd = GetSITEMANDALS(ddlsitedistrict.SelectedValue);
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlsitemandal.DataSource = dsd.Tables[0];
                    ddlsitemandal.DataValueField = "mandal_id";
                    ddlsitemandal.DataTextField = "mandal_name";
                    ddlsitemandal.DataBind();
                    ddlsitemandal.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlmuncipality.Items.Insert(0, "--Select--");
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
    }
    public DataSet GetWards(string DISTRICTID_SITE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETWARDS_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID_SITE.Trim() == "" || DISTRICTID_SITE.Trim() == null || DISTRICTID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = DISTRICTID_SITE.ToString();
            
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
    public DataSet GetMuncipolities(string DISTRICTID_SITE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETMUNCIPOLITIES_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID_SITE.Trim() == "" || DISTRICTID_SITE.Trim() == null || DISTRICTID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = DISTRICTID_SITE.ToString();

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
    public DataSet GetPANCHAYAT_ED(string DISTRICTID_SITE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETPANCHAYAT_ED_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID_SITE.Trim() == "" || DISTRICTID_SITE.Trim() == null || DISTRICTID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = DISTRICTID_SITE.ToString();

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
    public DataSet GetSITEMANDALS(string DISTRICTID_SITE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETSITEMANDALS_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID_SITE.Trim() == "" || DISTRICTID_SITE.Trim() == null || DISTRICTID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = DISTRICTID_SITE.ToString();

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
    protected void ddlsitemandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldepartment.SelectedValue == "9"&&( ddlsitedistrict.SelectedValue!=""&& ddlsitedistrict.SelectedValue != null&&ddlsitedistrict.SelectedValue != "--Select--")
            &&(ddlsitemandal.SelectedValue != "" && ddlsitemandal.SelectedValue != null && ddlsitemandal.SelectedValue != "--Select--"))
        {
            try
            {

                DataSet dsd = new DataSet();

                dsd = GetPANCHAYAT_RD(ddlsitedistrict.SelectedValue,ddlsitemandal.SelectedValue);
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlpanchayatRD.DataSource = dsd.Tables[0];
                    ddlpanchayatRD.DataValueField = "panchayath_id";
                    ddlpanchayatRD.DataTextField = "panchayath_name";
                    ddlpanchayatRD.DataBind();
                    ddlpanchayatRD.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlpanchayatRD.Items.Insert(0, "--Select--");
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
    }
    public DataSet GetPANCHAYAT_RD(string DISTRICTID_SITE,string MANDALID_SITE)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETPANCHAYAT_RD_TSROW", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (DISTRICTID_SITE.Trim() == "" || DISTRICTID_SITE.Trim() == null || DISTRICTID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@DISTRICTID_SITE", SqlDbType.VarChar).Value = DISTRICTID_SITE.ToString();
            if (MANDALID_SITE.Trim() == "" || MANDALID_SITE.Trim() == null || MANDALID_SITE.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@MANDALID_SITE", SqlDbType.VarChar).Value = " %";
            else
                da.SelectCommand.Parameters.Add("@MANDALID_SITE", SqlDbType.VarChar).Value = MANDALID_SITE.ToString();



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

    protected void btnnext_Click(object sender, EventArgs e)
    {
        string mobiletowerid = HDNMOBILETOWERID.Value;
        Response.Redirect("FRMMOBILETOWERTSROWATTACHMENTS.aspx?mobiletowerid=" + mobiletowerid);

    }
}