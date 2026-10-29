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

public partial class UI_TSiPASS_frmcapturemsmenewCommon : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    static DataTable dtMyTable;
    DataTable myDtNewRecdr = new DataTable();
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter();
    DataSet oDataSet = new DataSet();
    CommonBL objcommon = new CommonBL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count > 0)
        {
            btnsubmit.Enabled = true;
        }

        if (!IsPostBack)
        {
            BindDistricts();
            BindConstitutionunit();
            getSectorList();

            if (Request.QueryString["UID"] != null)
            {
                insertintocatalogue();
            }
            //DataSet dsc = new DataSet();
            //dsc = Gen.GetCategoryDet();
            //ddlintLineofActivity.DataSource = dsc.Tables[0];
            //ddlintLineofActivity.DataValueField = "intLineofActivityid";
            //ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            //ddlintLineofActivity.DataBind();
            //ddlintLineofActivity.Items.Insert(0, "--Select--");
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

        }
    }

    void Page_PreInit(Object sender, EventArgs e)
    {
        //if (Session.Count <= 0)
        //{
        //    this.MasterPageFile = "~/UI/TSiPASS/EmptyMaster.master";
        //}

    }

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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }


    public void insertintocatalogue()
    {
        string uid = Request.QueryString["UID"].ToString();
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@uid",SqlDbType.VarChar) 


           };
        pp[0].Value = uid;


        Dsnew = Gen.GenericFillDs("USP_GET_DETAILS_INSERTINTOCATALOGUE", pp);
        txtUnitName.Text = Dsnew.Tables[0].Rows[0]["nameofunit"].ToString();
        txtUAMID.Text = Dsnew.Tables[0].Rows[0]["Reg_No"].ToString();
        ddlCategory.SelectedValue = Dsnew.Tables[0].Rows[0]["Category"].ToString();
        ddldistrict.SelectedValue = Dsnew.Tables[0].Rows[0]["District_Id"].ToString();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddldistrict.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.SelectedValue = Dsnew.Tables[0].Rows[0]["Mandal_Id"].ToString();
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            ddlMandal.Items.Insert(0, "--Select--");
        }

        txtunitaddress.Text = Dsnew.Tables[0].Rows[0]["CompleteUnitAddress"].ToString();
        txtinvestment.Text = Dsnew.Tables[0].Rows[0]["Investment"].ToString();
        txtEmployment.Text = Dsnew.Tables[0].Rows[0]["NoofEmployee"].ToString();
        rdunitIEORNOT.SelectedValue = Dsnew.Tables[0].Rows[0]["IALA_Flag"].ToString();
        ddlConst_of_unit.SelectedValue = Dsnew.Tables[0].Rows[0]["Cons_of_Unit"].ToString();
        txtDateOfCommencement.Text = Dsnew.Tables[0].Rows[0]["dcp"].ToString();
        txtNameofEntrepreneur.Text = Dsnew.Tables[0].Rows[0]["NameofthePromoter"].ToString();
        txtMObileNo.Text = Dsnew.Tables[0].Rows[0]["MobileNumber"].ToString();
        txtEmail.Text = Dsnew.Tables[0].Rows[0]["Email"].ToString();
        ddlCaste.SelectedValue = Dsnew.Tables[0].Rows[0]["Caste_Name"].ToString();
        ddlDifferentlyabled.SelectedValue = Dsnew.Tables[0].Rows[0]["diffabled"].ToString();
        ddlWomenEnterprenuer.SelectedValue = Dsnew.Tables[0].Rows[0]["WomenEnterprenuer"].ToString();
        ddlSector.SelectedItem.Text = Dsnew.Tables[0].Rows[0]["Sector"].ToString();
        BindLineofactivity(ddlSector.SelectedValue);
        ddlintLineofActivity.SelectedValue = Dsnew.Tables[0].Rows[0]["intLineofActivity"].ToString();
        ddlCategorybyZone.SelectedItem.Text = Dsnew.Tables[0].Rows[0]["Pol_Category"].ToString();

    }

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

    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddldistrict.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
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
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict.SelectedIndex == 0)
            {
                ddlMandal.Items.Clear();
                ddlMandal.Items.Insert(0, "--Select--");
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
                    ddlMandal.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlMandal.Items.Clear();
                    ddlMandal.Items.Insert(0, "--Select--");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void ddlManfquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlManfquantityin.SelectedValue == "Others")
        {
            trothers.Visible = true;
        }
        else
        {
            trothers.Visible = false;
        }
    }
    protected void ddlRawUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRawUnits.SelectedValue == "Others")
        {
            trrawothers.Visible = true;
        }
        else
        {
            trrawothers.Visible = false;
        }
    }

    public string ValidateLandControlsSumbit()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlCategory.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Category \\n";
            slno = slno + 1;
        }


        //if (txtUAMID.Text.TrimStart().TrimEnd().Trim() == "")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter UAM ID Details \\n";
        //    slno = slno + 1;
        //}
        if (txtUnitName.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name Details \\n";
            slno = slno + 1;
        }

        if (ddldistrict.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District Details \\n";
            slno = slno + 1;
        }

        if (ddlMandal.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Details \\n";
            slno = slno + 1;
        }

        if (txtEmployment.Text.TrimStart().TrimEnd().Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Employeement Details \\n";
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
        if (ddlintLineofActivity.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select LineofActivity Details \\n";
            slno = slno + 1;
        }


        if (ddlConst_of_unit.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Type Of Industry \\n";
            slno = slno + 1;
        }



        return ErrorMsg;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
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

            MSMEUNITDETAILS OBJMSMEUNITDETAILS = new MSMEUNITDETAILS();
            OBJMSMEUNITDETAILS.UNITS_IE_OR_NOT = rdunitIEORNOT.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.CATEGOERY_ID = ddlCategory.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.UAM_ID = txtUAMID.Text.Trim();
            OBJMSMEUNITDETAILS.DISTRICT_ID = ddldistrict.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.MANDAL_ID = ddlMandal.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.UNIT_NAME = txtUnitName.Text.ToString();
            OBJMSMEUNITDETAILS.EMPLOYMENT = txtEmployment.Text.Trim();
            OBJMSMEUNITDETAILS.NAME_OF_ENTREPRENEUR = txtNameofEntrepreneur.Text.Trim();
            OBJMSMEUNITDETAILS.MOBILE_NO = txtMObileNo.Text.Trim();
            OBJMSMEUNITDETAILS.EMAIL_ID = txtEmail.Text.Trim();
            OBJMSMEUNITDETAILS.LINE_OF_ACTIVITY = ddlintLineofActivity.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.PRODUCT_SPEC = txtProductSpec.Text.Trim();
            OBJMSMEUNITDETAILS.CreatedBy = Session["uid"].ToString();
            OBJMSMEUNITDETAILS.PRODUCT_SPEC = txtProductSpec.Text.Trim();
            OBJMSMEUNITDETAILS.investment = txtinvestment.Text.Trim();
            OBJMSMEUNITDETAILS.Completeaddress = txtunitaddress.Text.Trim();

            if (txtDate.Text == "" || txtDate.Text == null)
            {
                OBJMSMEUNITDETAILS.Date = null;
            }
            else
            {
                string[] ConvertedDt11 = txtDate.Text.Split('-');
                OBJMSMEUNITDETAILS.Date = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
            }
            OBJMSMEUNITDETAILS.presentstatus = ddlstatus.SelectedItem.Text;
            OBJMSMEUNITDETAILS.otherpresentstatus = ddlstatus.SelectedItem.Text;

            OBJMSMEUNITDETAILS.TYPEOFINDUSTRY = ddlConst_of_unit.SelectedValue.ToString();
            if (txtDateOfCommencement.Text == "" || txtDateOfCommencement.Text == null)
            {
                OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = null;
            }
            else
            {
                string[] ConvertedDt12 = txtDateOfCommencement.Text.Split('-');
                OBJMSMEUNITDETAILS.DATEOFCOMMENCEMENT = ConvertedDt12[2].ToString() + "/" + ConvertedDt12[1].ToString() + "/" + ConvertedDt12[0].ToString();
            }

            OBJMSMEUNITDETAILS.PCBCATEGORY = ddlCategorybyZone.SelectedValue.ToString();
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
            OBJMSMEUNITDETAILS.SOCAILSTATUS = ddlCaste.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.PROMOTERWOMEN = ddlWomenEnterprenuer.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.PROMOTERDISABLED = ddlDifferentlyabled.SelectedValue.ToString();

            OBJMSMEUNITDETAILS.SECTOR = ddlSector.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.RAWMATERIALPROCURED = ddlrawmaterialprocured.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.RAWMATERIALDISTRICT = ddldistrict1.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.RAWMATERIALSTATE = ddlState.SelectedValue.ToString();
            OBJMSMEUNITDETAILS.RAWMATERIALCOUNTRY = txtfromcountry.Text;

            if (Request.QueryString["UID"] != null)
            {
                OBJMSMEUNITDETAILS.tsipassuidno = Request.QueryString["UID"].ToString();
            }
            else
            {
                OBJMSMEUNITDETAILS.tsipassuidno = "N";
            }
            


            int result = Gen.InsertMsmeUnitDetails(OBJMSMEUNITDETAILS);
            ViewState["MSMEID"] = result;
            DataSet ds = new DataSet();
            List<MSMELineOfManfGrid1DETAILS> listMSMELineOfManfGrid1DETAILSBO = new List<MSMELineOfManfGrid1DETAILS>();
            if (grdPowerutilized.Rows.Count != 0)
            {
                listMSMELineOfManfGrid1DETAILSBO.Clear();
                ds.Tables.Add((DataTable)ViewState["PowerutilizedCurrentTable"]);

                foreach (GridViewRow row in grdPowerutilized.Rows)
                {
                    MSMELineOfManfGrid1DETAILS objMSMELineOfManfGrid1DETAILSBO = new MSMELineOfManfGrid1DETAILS();

                    int rowIndex = row.RowIndex;

                    objMSMELineOfManfGrid1DETAILSBO.MSMEID = ViewState["MSMEID"].ToString();

                    objMSMELineOfManfGrid1DETAILSBO.Item = ds.Tables[0].Rows[rowIndex]["RawItem"].ToString();
                    objMSMELineOfManfGrid1DETAILSBO.QuantityPerAnnum = ds.Tables[0].Rows[rowIndex]["RawQntyperAnnum"].ToString();
                    objMSMELineOfManfGrid1DETAILSBO.ProductionInUnits = ds.Tables[0].Rows[rowIndex]["RawUnits"].ToString();
                    objMSMELineOfManfGrid1DETAILSBO.OtherRawUnits = ds.Tables[0].Rows[rowIndex]["OtherUnits"].ToString();


                    objMSMELineOfManfGrid1DETAILSBO.CreatedBy = Session["uid"].ToString();

                    listMSMELineOfManfGrid1DETAILSBO.Add(objMSMELineOfManfGrid1DETAILSBO);
                }
            }

            DataSet ds1 = new DataSet();
            List<MSMELineOfManfGrid2DETAILS> listMSMELineOfManfGrid2DETAILSBO = new List<MSMELineOfManfGrid2DETAILS>();
            if (grdEnergyConsumed.Rows.Count != 0)
            {
                listMSMELineOfManfGrid2DETAILSBO.Clear();
                ds1.Tables.Add((DataTable)ViewState["EnergyconsumedCurrentTable"]);

                foreach (GridViewRow row in grdEnergyConsumed.Rows)
                {
                    MSMELineOfManfGrid2DETAILS objMSMELineOfManfGrid2DETAILSBO = new MSMELineOfManfGrid2DETAILS();
                    int rowIndex = row.RowIndex;

                    objMSMELineOfManfGrid2DETAILSBO.MSMEID = ViewState["MSMEID"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.Item = ds1.Tables[0].Rows[rowIndex]["Manfitem"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.QuantityPerAnnum = ds1.Tables[0].Rows[rowIndex]["Manfquantityperannum"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.ProductionInUnits = ds1.Tables[0].Rows[rowIndex]["Manfquantityin"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.ManufOtherUnits = ds1.Tables[0].Rows[rowIndex]["Mfgothers"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.Attachment = ds1.Tables[0].Rows[rowIndex]["SketchCopy_Path"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.OthersSpecify = ds1.Tables[0].Rows[rowIndex]["OthersSpecify"].ToString();
                    objMSMELineOfManfGrid2DETAILSBO.CreatedBy = Session["uid"].ToString();
                    listMSMELineOfManfGrid2DETAILSBO.Add(objMSMELineOfManfGrid2DETAILSBO);



                }
            }

            int Insertion = Gen.insertMSMEDetailsDB(ViewState["MSMEID"].ToString(), listMSMELineOfManfGrid1DETAILSBO, listMSMELineOfManfGrid2DETAILSBO);
            if (Insertion >= 1)
            {
                string message = "alert('Application Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                success.Visible = true;
                lblmsg.Text = "Application Submitted Successfully";

                btnsubmit.Enabled = false;

            }
            else
            {
                string message = "alert('Application Not Processed please try Again!!')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnsubmit.Enabled = false;
            }


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
    protected void btnclear_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("frmcapturemsmenewCommon.aspx");
        }
        catch (Exception ex)
        {
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }



    protected void GetNewRectoInsertdr()
    {
        myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        DataView dvdr = new DataView(myDtNewRecdr);
        myDtNewRecdr = dvdr.ToTable();
    }



    public string ValidateLandControls()
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

        //if (fpdSketch.HasFile == false)
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Upload photo  \\n";
        //    slno = slno + 1;
        //}


        return ErrorMsg;
    }

    public string ValidateLandControls1()
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


        return ErrorMsg;
    }
    protected void btnSecondGridAdd_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateLandControls1();
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

                DataTable dt = new DataTable();

                dt.Columns.Add("RawItem", typeof(string));
                dt.Columns.Add("RawQntyperAnnum", typeof(string));
                dt.Columns.Add("RawUnits", typeof(string));
                dt.Columns.Add("OtherUnits", typeof(string));

                if (ViewState["PowerutilizedCurrentTable"] != null)
                {
                    if (ViewState["PowerutilizedCurrentTable"].ToString() != "0")
                    {
                        dt = (DataTable)ViewState["PowerutilizedCurrentTable"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["RawItem"] = txtRawItem.Text;
                    dr["RawQntyperAnnum"] = txtRawQntyperAnnum.Text;
                    dr["RawUnits"] = ddlRawUnits.SelectedItem.ToString();
                    dr["OtherUnits"] = txtRawothers.Text;

                    dt.Rows.Add(dr);
                    grdPowerutilized.DataSource = dt;
                    grdPowerutilized.DataBind();
                    ViewState["PowerutilizedCurrentTable"] = dt;
                    ClearRawMaterislGridData();
                }
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["RawItem"] = txtRawItem.Text;
                    dr["RawQntyperAnnum"] = txtRawQntyperAnnum.Text;
                    dr["RawUnits"] = ddlRawUnits.SelectedItem.ToString();
                    dr["OtherUnits"] = txtRawothers.Text;

                    dt.Rows.Add(dr);
                    grdPowerutilized.DataSource = dt;
                    grdPowerutilized.DataBind();
                    ViewState["PowerutilizedCurrentTable"] = dt;
                    ClearRawMaterislGridData();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

    public void ClearRawMaterislGridData()
    {
        txtRawItem.Text = string.Empty;
        txtRawQntyperAnnum.Text = string.Empty;
        txtRawothers.Text = string.Empty;
        ddlRawUnits.ClearSelection();



    }

    public void FIleUploading(FileUpload fpd, string Description, HyperLink hlp, string ApprovalID, string DocID, string DocUploadedUserType)
    {

        //string outmsg = "0";
        try
        {
            Session["uid"] = Session["uid"].ToString();
            string newPath = "";
            string sFileDir = Server.MapPath("~\\MSMEAttachments");
            General t1 = new General();
            if ((fpd.PostedFile != null) && (fpd.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
                // string sFileName = System.IO.Path.GetFileName(fpd.PostedFile.FileName);
                //string sFileName = "";

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
                        //  result = t1.InsertCFEUploads(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, Session["uid"].ToString(), ApprovalID, DocID, DocUploadedUserType);
                        // result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        // result = t1.InsertImagedata(Session["Questionaireid"].ToString(), Session["CFEEnterpid"].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Description, "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result == 0)
                        {
                            //lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hlp.Text = "View";
                            hlp.NavigateUrl = "~/MSMEAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                            ViewState[fpd.ID] = "~/MSMEAttachments/" + Session["uid"] + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                            //outmsg = "0";
                            //   ViewState[fpd.ID] = "~/Attachments/" + "1" + "/" + Description + "/" + Attachmentidnew + "/" + sFileName;
                            //success.Visible = true;
                            //Failure.Visible = false;

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

    protected void btnSecondGridClear_Click(object sender, EventArgs e)
    {
        txtRawItem.Text = string.Empty;
        txtRawQntyperAnnum.Text = string.Empty;
        txtRawothers.Text = string.Empty;
        ddlRawUnits.ClearSelection();
    }

    protected void btnFirstGrid_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateLandControls();
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
                        return;
                    }

                }

                if (fpdSketch.HasFile == false)
                {
                    ViewState["fpdSketch"] = "";
                }


                DataTable dt = new DataTable();

                dt.Columns.Add("Manfitem", typeof(string));
                dt.Columns.Add("Manfquantityperannum", typeof(string));
                dt.Columns.Add("Manfquantityin", typeof(string));
                dt.Columns.Add("Mfgothers", typeof(string));
                dt.Columns.Add("SketchCopy_Path", typeof(string));
                dt.Columns.Add("OthersSpecify", typeof(string));

                if (ViewState["EnergyconsumedCurrentTable"] != null)
                {
                    if (ViewState["EnergyconsumedCurrentTable"].ToString() != "0")
                    {
                        dt = (DataTable)ViewState["EnergyconsumedCurrentTable"];
                    }
                    DataRow dr = dt.NewRow();

                    dr["Manfitem"] = txtManfitem.Text;
                    dr["Manfquantityperannum"] = txtManfquantityperannum.Text;
                    dr["Manfquantityin"] = ddlManfquantityin.SelectedItem.Text.ToString();
                    dr["Mfgothers"] = txtMfgothers.Text;
                    dr["SketchCopy_Path"] = ViewState["fpdSketch"].ToString();
                    dr["OthersSpecify"] = txtotherproduct.Text;

                    dt.Rows.Add(dr);
                    grdEnergyConsumed.DataSource = dt;
                    grdEnergyConsumed.DataBind();
                    ViewState["EnergyconsumedCurrentTable"] = dt;
                    ClearManufactureGridData();
                }
                else
                {
                    DataRow dr = dt.NewRow();

                    dr["Manfitem"] = txtManfitem.Text;
                    dr["Manfquantityperannum"] = txtManfquantityperannum.Text;
                    dr["Manfquantityin"] = ddlManfquantityin.SelectedItem.Text.ToString();
                    dr["Mfgothers"] = txtMfgothers.Text;
                    dr["SketchCopy_Path"] = ViewState["fpdSketch"].ToString();
                    dr["OthersSpecify"] = txtotherproduct.Text;

                    dt.Rows.Add(dr);
                    grdEnergyConsumed.DataSource = dt;
                    grdEnergyConsumed.DataBind();
                    ViewState["EnergyconsumedCurrentTable"] = dt;
                    ClearManufactureGridData();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public void ClearManufactureGridData()
    {
        txtManfitem.Text = string.Empty;
        txtManfquantityperannum.Text = string.Empty;
        txtMfgothers.Text = string.Empty;
        ddlManfquantityin.ClearSelection();


    }

    protected void grdEnergyConsumed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("EnergyDelete"))
        {
            DataTable dt = (DataTable)ViewState["EnergyconsumedCurrentTable"];
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowINdex = gvr.RowIndex;
            if (dt.Rows.Count >= 1)
            {
                dt.Rows[RowINdex].Delete();
                dt.AcceptChanges();
                ViewState["EnergyconsumedCurrentTable"] = dt;
                grdEnergyConsumed.DataSource = ViewState["EnergyconsumedCurrentTable"];
                grdEnergyConsumed.DataBind();
            }
        }
    }

    protected void grdEnergyConsumed_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdPowerutilized_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            DataTable dt = (DataTable)ViewState["PowerutilizedCurrentTable"];
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowINdex = gvr.RowIndex;
            if (dt.Rows.Count >= 1)
            {
                dt.Rows[RowINdex].Delete();
                dt.AcceptChanges();
                ViewState["PowerutilizedCurrentTable"] = dt;
                grdPowerutilized.DataSource = ViewState["PowerutilizedCurrentTable"];
                grdPowerutilized.DataBind();
            }
        }
    }

    protected void grdPowerutilized_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void ButtonMfgcancel_Click(object sender, EventArgs e)
    {
        ClearManufactureGridData();
    }
    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedItem.Text == "Other")
        {
            otherstatus.Visible = true;
        }
        else
        {
            otherstatus.Visible = false;
        }
    }

    protected void rdnUnitExport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdnUnitExport.SelectedValue == "Y")
        {
            divcountry.Visible = true;
        }
        else
        {
            divcountry.Visible = false;
        }
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

    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistrictsbystate(ddlrawmaterialprocured.SelectedValue.ToString());
        ddldistrict1.DataSource = dsnew.Tables[0];
        ddldistrict1.DataTextField = "District_Name";
        ddldistrict1.DataValueField = "District_Id";
        ddldistrict1.DataBind();
        ddldistrict1.Items.Insert(0, "--Select--");

    }

    protected void getSectorList()
    {
        DataSet dsnew = new DataSet();

        //dsnew = Gen.GetSectorbylineofactivity(ddlintLineofActivity.SelectedValue.ToString());
        //ddlSector.DataSource = dsnew.Tables[0];
        //ddlSector.DataTextField = "SectorName";
        //ddlSector.DataValueField = "IntSectorMapId";
        //ddlSector.DataBind();
        //ddlSector.Items.Insert(0, "--Select--");

        dsnew = Gen.getSectorNames();
        ddlSector.DataSource = dsnew.Tables[0];
        ddlSector.DataTextField = "SectorName";
        ddlSector.DataValueField = "SectorName";
        ddlSector.DataBind();
        ddlSector.Items.Insert(0, "--Select--");

    }

    protected void ddlrawmaterialprocured_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrawmaterialprocured.SelectedValue.ToString() != "--Select--")
        {


            if (ddlrawmaterialprocured.SelectedValue.ToString() == "31")
            {
                getdistricts();
                ddldistrict1.Visible = true;
                ddlState.Visible = false;
                txtfromcountry.Visible = false;
                labelDistrict.Visible = true;
                labelState.Visible = false;
                labelCountry.Visible = false;





            }
            else if (ddlrawmaterialprocured.SelectedValue.ToString() == "1")
            {
                getStatesotherthanTG();
                ddldistrict1.Visible = false;
                ddlState.Visible = true;
                txtfromcountry.Visible = false;
                labelDistrict.Visible = false;
                labelState.Visible = true;
                labelCountry.Visible = false;
            }

            else if (ddlrawmaterialprocured.SelectedValue.ToString() == "2")
            {
                ddldistrict1.Visible = false;
                ddlState.Visible = false;
                txtfromcountry.Visible = true;
                labelDistrict.Visible = false;
                labelState.Visible = false;
                labelCountry.Visible = true;
            }


        }
        else
        {
            ddldistrict1.Items.Clear();
            ddldistrict1.Items.Insert(0, "--Select--");


        }
    }

    //protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlintLineofActivity.SelectedValue.ToString() != "--Select--")
    //    {
    //        getSectorList();

    //    }
    //    else
    //    {
    //        ddlintLineofActivity.Items.Clear();
    //        ddlintLineofActivity.Items.Insert(0, "--Select--");


    //    }
    //}

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

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlintLineofActivity.SelectedIndex == 0)
            {

            }
            else
            {
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

                else
                {
                    //HdfLblPol_Category.Value = "";
                    //LblPol_Category.Text = "";
                    //RdPol_Indus.Enabled = false;
                    //trFallinPolution.Visible = false;
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

    protected void grdEnergyConsumed_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        HyperLink h3 = (HyperLink)e.Row.FindControl("HyperLink1");

        string hyperLnk1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SketchCopy_Path"));

        if (hyperLnk1 != "")
        {
            h3.Text = "View";
            h3.Visible = true;


        }
    }
}