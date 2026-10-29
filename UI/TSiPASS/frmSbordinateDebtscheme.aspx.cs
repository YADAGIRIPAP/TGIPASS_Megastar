using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class UI_TSiPASS_frmSbordinateDebtscheme : System.Web.UI.Page
{
    string ID;
    General Gen = new General();
    comFunctions cmf = new comFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/frmBridgeAccLogin.aspx");
        }

        if (!IsPostBack)
        {
            BindDistricts();
            ddlUnitDIst_SelectedIndexChanged(sender, e);
            BindLineofActivityName();
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0].ToString() != "")
                {
                    txtUnitName.Enabled = false;
                    txtEntrepreneurname.Enabled = false;
                    ddlUnitDIst.Enabled = false;
                    ddlUnitMandal.Enabled = false;
                    ddlVillageunit.Enabled = false;
                    txtAddress.Enabled = false;
                    txtmobileNo.Enabled = false;
                    ddlintLineofActivity.Enabled = false;
                    txtEmail.Enabled = false;
                    trremarks.Visible = true;
                    trupdate.Visible = true;
                    trsave.Visible = false;
                    ID = Request.QueryString[0].ToString().Trim();
                    ViewState["ID"] = ID;
                    FillDetails();
                }
            }
        }
    }

    public void FillDetails()
    {

        DataSet dsemp = new DataSet();

        dsemp = RETRIVESUBORDINATEDEBTSCHEMEDetails(ID);

        if (dsemp.Tables[0].Rows.Count > 0)
        {
            try
            {

                txtUnitName.Text = dsemp.Tables[0].Rows[0]["Unitname"].ToString();
                txtEntrepreneurname.Text = dsemp.Tables[0].Rows[0]["Entrepreneurname"].ToString();

                ddlUnitDIst.SelectedValue = dsemp.Tables[0].Rows[0]["District"].ToString();
                loadmandals();
                //if (!string.IsNullOrEmpty(dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString()))
                //{
                //    ddlMandal.SelectedValue = dsemp.Tables[0].Rows[0]["MANDAL_ID"].ToString();
                //}
                if (dsemp.Tables[0].Rows[0]["Mandal"].ToString() == "" || dsemp.Tables[0].Rows[0]["Mandal"].ToString() == "--Select" || dsemp.Tables[0].Rows[0]["Mandal"].ToString() == "0" || dsemp.Tables[0].Rows[0]["Mandal"].ToString() == "NULL")
                {
                    ddlUnitMandal.SelectedValue = "0";

                }
                else
                {
                    ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Mandal"].ToString();
                }
                loadvillages();
                if (dsemp.Tables[0].Rows[0]["Village"].ToString() == "" || dsemp.Tables[0].Rows[0]["Village"].ToString() == "--Select" || dsemp.Tables[0].Rows[0]["Village"].ToString() == "0" || dsemp.Tables[0].Rows[0]["Village"].ToString() == "NULL")
                {
                    ddlVillageunit.SelectedValue = "0";

                }
                else
                {
                    ddlVillageunit.SelectedValue = dsemp.Tables[0].Rows[0]["Village"].ToString();
                }

                txtAddress.Text = dsemp.Tables[0].Rows[0]["Addres"].ToString();
                ddlintLineofActivity.SelectedItem.Text = dsemp.Tables[0].Rows[0]["LineOfActivity"].ToString();
                txtmobileNo.Text = dsemp.Tables[0].Rows[0]["MobileNo"].ToString();
                txtEmail.Text = dsemp.Tables[0].Rows[0]["EmailId"].ToString();

                rbtSMANPA.SelectedValue = dsemp.Tables[0].Rows[0]["RbtSMANPA"].ToString();
                if (rbtSMANPA.SelectedValue == "SMA")

                {
                    troutstandingAount.Visible = true;
                    txtOutStandingAmount.Text = dsemp.Tables[0].Rows[0]["SMAOtStandingAmount"].ToString();
                    //Check();
                    if (Convert.ToDecimal(txtOutStandingAmount.Text) < 1000000)
                    {
                        trassessment.Visible = true;
                        trviablenotviable.Visible = false;
                        trtevstudydonerestrctamount.Visible = false;
                        TEVSbordinatedebtScheme.Visible = false;
                        trTEVAmount.Visible = false;
                    }
                    else
                    {
                        trviablenotviable.Visible = false;
                    }
                }
                else
                {
                    troutstandingAount.Visible = true;
                }
                rdAssessment.SelectedValue = dsemp.Tables[0].Rows[0]["Assestment"].ToString();

                if (rdAssessment.SelectedValue == "Y")
                {
                    trviablenotviable.Visible = true;
                    rbtviablenotviable.SelectedValue = dsemp.Tables[0].Rows[0]["RbtViablenotViable"].ToString();
                }
                else
                {
                    trviablenotviable.Visible = false;
                }
                if (rbtviablenotviable.SelectedValue == "Viable")
                {
                    trrestructingAmontviable.Visible = true;
                    txtRestructAmount.Text = dsemp.Tables[0].Rows[0]["RestructAmount_Viable"].ToString();
                    trsubordinatedept.Visible = true;
                    rbtSubordinatedept.SelectedValue = dsemp.Tables[0].Rows[0]["RbtSubordinateDeptScheme_Viable"].ToString();
                }
                else
                {
                    trrestructingAmontviable.Visible = false;
                    trsubordinatedept.Visible = false;
                }
                if (rbtSubordinatedept.SelectedValue == "Y")
                {
                    tramount.Visible = true;
                    txtAmount.Text = dsemp.Tables[0].Rows[0]["SubordinateDeptSchemeAmont_Viable"].ToString();
                }
                else
                {
                    tramount.Visible = false;
                }
                if (Convert.ToDecimal(txtOutStandingAmount.Text) > 1000000)
                {
                    trassessment.Visible = false;
                    trtevstudydone.Visible = true;
                    rbtTEVStudyDone.SelectedValue = dsemp.Tables[0].Rows[0]["RbtTEVStdyDone"].ToString();
                    trrestructingAmontviable.Visible = false;
                    trsubordinatedept.Visible = false;
                    tramount.Visible = false;

                }
                else
                {
                    trtevstudydone.Visible = false;
                }
                if (rbtTEVStudyDone.SelectedValue == "Y")
                {
                    trviableTEV.Visible = true;
                    rdviableTEV.SelectedValue = dsemp.Tables[0].Rows[0]["Viable_TEV"].ToString();
                }
                else
                {
                    trviableTEV.Visible = false;
                }
                if (rdviableTEV.SelectedValue == "Viable")
                {
                    trtevstudydonerestrctamount.Visible = true;
                    txtRestructAmountTEV.Text = dsemp.Tables[0].Rows[0]["RestructAmount_TEV"].ToString();
                    TEVSbordinatedebtScheme.Visible = true;
                    rbtSubordinateSchemeforTEV.SelectedValue = dsemp.Tables[0].Rows[0]["RbtSubordinateDeptScheme_TEV"].ToString();
                }
                else
                {
                    trtevstudydonerestrctamount.Visible = false;
                    TEVSbordinatedebtScheme.Visible = false;
                }
                if (rbtSubordinateSchemeforTEV.SelectedValue == "Y")
                {
                    trTEVAmount.Visible = true;
                    txtAmontTEVStudyDone.Text = dsemp.Tables[0].Rows[0]["SubordinateDeptSchemeAmont_TEV"].ToString();
                }
                txtremarks.Text = dsemp.Tables[0].Rows[0]["remarks"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

    }
    public void BindLineofActivityName()
    {
        try
        {
            ddlintLineofActivity.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlintLineofActivity.DataSource = dsc.Tables[0];
                ddlintLineofActivity.DataValueField = "intLineofActivityid";
                ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                ddlintLineofActivity.DataBind();
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintLineofActivity.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlUnitDIst.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlUnitDIst.DataSource = dsd.Tables[0];
                ddlUnitDIst.DataValueField = "District_Id";
                ddlUnitDIst.DataTextField = "District_Name";
                ddlUnitDIst.DataBind();
                //ddlUnitDIst.Items.Insert(0, "--Select--");
                AddSelect(ddlUnitDIst);
            }
            else
            {
                AddSelect(ddlUnitDIst);
                //ddlUnitDIst.Items.Insert(0, "--Select--");
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
    protected void txtOutStandingAmount_TextChanged(object sender, EventArgs e)
    {
        Check();
    }
    void Check()
    {

        if (Convert.ToDecimal(txtOutStandingAmount.Text) <= 1000000)
        {
            trassessment.Visible = true;
            rbtTEVStudyDone.ClearSelection();
            rbtviablenotviable.ClearSelection();
            txtRestructAmountTEV.Text = "";
            rbtSubordinateSchemeforTEV.ClearSelection();
            txtAmontTEVStudyDone.Text = "";
            trviablenotviable.Visible = false;
            trtevstudydonerestrctamount.Visible = false;
            TEVSbordinatedebtScheme.Visible = false;
            trTEVAmount.Visible = false;
            rdviableTEV.ClearSelection();
            trviableTEV.Visible = false;
        }
        else
        {
            trviablenotviable.Visible = false;
        }
        if (Convert.ToDecimal(txtOutStandingAmount.Text) > 1000000)
        {
            trassessment.Visible = false;
            rdAssessment.ClearSelection();
            rbtviablenotviable.ClearSelection(); txtAmount.Text = "";
            txtRestructAmount.Text = "";
            rbtSubordinatedept.ClearSelection();

            trtevstudydone.Visible = true;
            trrestructingAmontviable.Visible = false;
            trsubordinatedept.Visible = false;
            tramount.Visible = false;

        }
        else
        {
            trtevstudydone.Visible = false;
        }
    }

    protected void rbtSMANPA_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtSMANPA.SelectedValue == "SMA")
        {
            troutstandingAount.Visible = true;
            txtOutStandingAmount.Text = "";
            txtRestructAmount.Text = "";
            txtAmount.Text = "";
            txtRestructAmountTEV.Text = "";
            txtAmontTEVStudyDone.Text = "";
            rdAssessment.ClearSelection();
            rbtTEVStudyDone.ClearSelection();
            rdviableTEV.ClearSelection();
            rbtSubordinatedept.ClearSelection();
            rbtSubordinateSchemeforTEV.ClearSelection();
            rbtviablenotviable.ClearSelection();
            //rdAssessment.SelectedValue = "";
            //rbtTEVStudyDone.SelectedValue = "";
        }
        else
        {
            troutstandingAount.Visible = false;
            trviablenotviable.Visible = false;
            tramount.Visible = false;
            trsubordinatedept.Visible = false;
            trrestructingAmontviable.Visible = false;
            trtevstudydone.Visible = false;
            trtevstudydonerestrctamount.Visible = false;
            TEVSbordinatedebtScheme.Visible = false;
            trviableTEV.Visible = false;
            trassessment.Visible = false;
            trTEVAmount.Visible = false;
        }
    }

    protected void rbtviablenotviable_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtviablenotviable.SelectedValue == "Viable")
        {
            trrestructingAmontviable.Visible = true;
            trsubordinatedept.Visible = true;
        }
        else
        {
            trrestructingAmontviable.Visible = false;
            trsubordinatedept.Visible = false;
            tramount.Visible = false;
            txtRestructAmount.Text = "";
            txtAmount.Text = "";
            rbtSubordinatedept.ClearSelection();
        }
    }

    protected void rbtSubordinatedept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtSubordinatedept.SelectedValue == "Y")
        {
            tramount.Visible = true;
        }
        else
        {
            tramount.Visible = false;
            txtAmount.Text = "";
        }
    }

    protected void rbtTEVStudyDone_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rbtTEVStudyDone.SelectedValue == "Y")
        {
            trviableTEV.Visible = true;
        }
        else
        {
            trviableTEV.Visible = false;
            rdviableTEV.ClearSelection();
            txtRestructAmountTEV.Text = "";
            txtAmontTEVStudyDone.Text = "";
            rbtSubordinateSchemeforTEV.ClearSelection();
            trtevstudydonerestrctamount.Visible = false;
            TEVSbordinatedebtScheme.Visible = false;
            trTEVAmount.Visible = false;
        }
    }

    protected void rbtSubordinateSchemeforTEV_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtSubordinateSchemeforTEV.SelectedValue == "Y")
        {
            trTEVAmount.Visible = true;
        }
        else
        {
            trTEVAmount.Visible = false;
            txtAmontTEVStudyDone.Text = "";
        }
    }
    protected void ddlUnitDIst_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadmandals();
    }
    public void loadmandals()
    {
        if (ddlUnitDIst.SelectedIndex == 0)
        {
            ddlUnitMandal.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();

        }
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlUnitMandal.DataSource = dsm.Tables[0];
            ddlUnitMandal.DataValueField = "Mandal_Id";
            ddlUnitMandal.DataTextField = "Manda_lName";
            ddlUnitMandal.DataBind();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();
            //ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
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

    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadvillages();
    }
    public void loadvillages()
    {
        if (ddlUnitMandal.SelectedIndex == 0)
        {

            ddlVillageunit.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlVillageunit);
        }
        else
        {
            ddlVillageunit.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillageunit.DataSource = dsv.Tables[0];
                ddlVillageunit.DataValueField = "Village_Id";
                ddlVillageunit.DataTextField = "Village_Name";
                ddlVillageunit.DataBind();
                AddSelect(ddlVillageunit);
                //  ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
        }
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

        DataSet ds = new DataSet();

        ds = InsertSubOrdinateDeptScheme(txtUnitName.Text, txtEntrepreneurname.Text, ddlUnitDIst.SelectedValue, ddlUnitMandal.SelectedValue, ddlVillageunit.SelectedValue, txtAddress.Text, txtSrveyno.Text, ddlintLineofActivity.SelectedItem.ToString(),
                   txtmobileNo.Text, txtEmail.Text, rbtSMANPA.SelectedValue.ToString(), txtOutStandingAmount.Text, rbtviablenotviable.SelectedValue.ToString(), rbtTEVStudyDone.SelectedValue.ToString(), txtRestructAmount.Text, txtRestructAmountTEV.Text,
                   rbtSubordinatedept.SelectedValue.ToString(), rbtSubordinateSchemeforTEV.SelectedValue.ToString(), txtAmount.Text, txtAmontTEVStudyDone.Text, rdAssessment.SelectedValue.ToString(), rdviableTEV.SelectedValue.ToString(), Session["uid"].ToString(), Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Columns.Contains("REMARKS"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record ALREADY EXIST ')", true);
                BtnSave.Enabled = false;
                clear();
                return;

            }
            else
            {
                //string message = " Record Added Sccessflly";
                //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                BtnSave.Enabled = false;
                clear();
                return;


            }



        }
    }
    public DataSet InsertSubOrdinateDeptScheme(string Unitname,
string Entrepreneurname,
string District,
string Mandal,
string Village,
string Addres,
string SurveyNo,
string LineOfActivity,
string MobileNo,
string EmailId,
string RbtSMANPA,
string SMAOtStandingAmount,
string RbtViablenotViable,
string RbtTEVStdyDone,
string RestructAmount_Viable,
string RestructAmount_TEV,
string RbtSubordinateDeptScheme_Viable,
string RbtSubordinateDeptScheme_TEV,
string SubordinateDeptSchemeAmont_Viable,
string SubordinateDeptSchemeAmont_TEV,
string Assestment,
string Viable_TEV,
string Created_by,
string Modified_by)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@Unitname",SqlDbType.VarChar),
                new SqlParameter("@Entrepreneurname",SqlDbType.VarChar),
               new SqlParameter("@District",SqlDbType.VarChar),
               new SqlParameter("@Mandal",SqlDbType.VarChar),
               new SqlParameter("@Village",SqlDbType.VarChar),
                new SqlParameter("@Addres",SqlDbType.VarChar),
               new SqlParameter("@SurveyNo",SqlDbType.VarChar),
               new SqlParameter("@LineOfActivity",SqlDbType.VarChar),
               new SqlParameter("@MobileNo",SqlDbType.VarChar),
                new SqlParameter("@EmailId",SqlDbType.VarChar),
               new SqlParameter("@RbtSMANPA",SqlDbType.VarChar),
               new SqlParameter("@SMAOtStandingAmount",SqlDbType.VarChar),
               new SqlParameter("@RbtViablenotViable",SqlDbType.VarChar),
                new SqlParameter("@RbtTEVStdyDone",SqlDbType.VarChar),
               new SqlParameter("@RestructAmount_Viable",SqlDbType.VarChar),
               new SqlParameter("@RestructAmount_TEV",SqlDbType.VarChar),
               new SqlParameter("@RbtSubordinateDeptScheme_Viable",SqlDbType.VarChar),
                new SqlParameter("@RbtSubordinateDeptScheme_TEV",SqlDbType.VarChar),
               new SqlParameter("@SubordinateDeptSchemeAmont_Viable",SqlDbType.VarChar),
               new SqlParameter("@SubordinateDeptSchemeAmont_TEV",SqlDbType.VarChar),
               new SqlParameter("@Assestment",SqlDbType.VarChar),
               new SqlParameter("@Viable_TEV",SqlDbType.VarChar),
                new SqlParameter("@Created_by",SqlDbType.VarChar),
               new SqlParameter("@Modified_by",SqlDbType.VarChar)

           };

        pp[0].Value = Unitname;
        pp[1].Value = Entrepreneurname;
        pp[2].Value = District;
        pp[3].Value = Mandal;
        pp[4].Value = Village;
        if (Addres != null)
        {
            pp[5].Value = Addres;
        }
        else
        {
            pp[5].Value = null;
        }

        pp[6].Value = SurveyNo;
        pp[7].Value = LineOfActivity;
        pp[8].Value = MobileNo;
        if (EmailId != null)
        {
            pp[9].Value = EmailId;
        }
        else
        {
            pp[9].Value = null;
        }

        pp[10].Value = RbtSMANPA;
        if (pp[10].Value.ToString() == "SMA")
        {


            if (SMAOtStandingAmount != null & SMAOtStandingAmount != "")
            {
                pp[11].Value = SMAOtStandingAmount;
            }
            else
            {
                pp[11].Value = null;
            }

            if (RbtViablenotViable != null & RbtViablenotViable != "")
            {
                pp[12].Value = RbtViablenotViable;
            }
            else
            {
                pp[12].Value = null;
            }
            if (RbtTEVStdyDone != null & RbtTEVStdyDone != "")
            {
                pp[13].Value = RbtTEVStdyDone;
            }
            else
            {
                pp[13].Value = null;
            }
            if (RestructAmount_Viable != null & RestructAmount_Viable != "")
            {
                pp[14].Value = RestructAmount_Viable;
            }
            else
            {
                pp[14].Value = null;
            }
            if (RestructAmount_TEV != null & RestructAmount_TEV != "")
            {
                pp[15].Value = RestructAmount_TEV;
            }
            else
            {
                pp[15].Value = null;
            }
            if (RbtSubordinateDeptScheme_Viable != null & RbtSubordinateDeptScheme_Viable != "")
            {
                pp[16].Value = RbtSubordinateDeptScheme_Viable;
            }
            else
            {
                pp[16].Value = null;
            }
            if (RbtSubordinateDeptScheme_TEV != null & RbtSubordinateDeptScheme_TEV != "")
            {
                pp[17].Value = RbtSubordinateDeptScheme_TEV;
            }
            else
            {
                pp[17].Value = null;
            }
            if (SubordinateDeptSchemeAmont_Viable != null & SubordinateDeptSchemeAmont_Viable != "")
            {
                pp[18].Value = SubordinateDeptSchemeAmont_Viable;
            }
            else
            {
                pp[18].Value = null;
            }
            if (SubordinateDeptSchemeAmont_TEV != null & SubordinateDeptSchemeAmont_TEV != "")
            {
                pp[19].Value = SubordinateDeptSchemeAmont_TEV;
            }
            else
            {
                pp[19].Value = null;
            }
            if (Assestment != null & Assestment != "")
            {
                pp[20].Value = Assestment;
            }
            else
            {
                pp[20].Value = null;
            }
            if (Viable_TEV != null & Viable_TEV != "")
            {
                pp[21].Value = Viable_TEV;
            }
            else
            {
                pp[21].Value = null;
            }
        }

        pp[22].Value = Created_by;
        pp[23].Value = Modified_by;



        //USP_GET_DISTRICTREPORT_FINANCIALYEAR
        Dsnew = Gen.GenericFillDs("INSERTSBORDINATEDEPTSCHEMEDETAILS", pp);
        return Dsnew;
    }

    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlUnitDIst.SelectedValue == "0" || ddlUnitDIst.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District  details\\n";
            slno = slno + 1;
        }
        if (ddlUnitMandal.SelectedValue == "0" || ddlUnitMandal.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal details \\n";
            slno = slno + 1;
        }
        if (ddlVillageunit.SelectedValue == "0" || ddlVillageunit.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village details \\n";
            slno = slno + 1;
        }


        if (rbtSMANPA.SelectedValue == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Type of Loan \\n";
            slno = slno + 1;
        }

        if (ddlintLineofActivity.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Line of Activity \\n";
            slno = slno + 1;
        }

        if (rbtSMANPA.SelectedValue == "SMA")
        {
            if (txtOutStandingAmount.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Out Standing Amount \\n";
                slno = slno + 1;
            }
            if (Convert.ToDecimal(txtOutStandingAmount.Text) <= 1000000)
            {
                if (rdAssessment.SelectedValue == "NUll" || rdAssessment.SelectedValue == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Assestment for Viability Done by Branch  \\n";
                    slno = slno + 1;
                }
                if (rdAssessment.SelectedValue == "Y")
                {

                    if (rbtviablenotviable.SelectedValue == "NUll" || rbtviablenotviable.SelectedValue == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Given Assesment is Viable or Not  \\n";
                        slno = slno + 1;
                    }
                }
                if (rbtviablenotviable.SelectedValue == "Viable")
                {
                    if (txtRestructAmount.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Required for Restructuring after Assessment(In Rs.)  \\n";
                        slno = slno + 1;
                    }
                    if (rbtSubordinatedept.SelectedValue == "NULL" || rbtSubordinatedept.SelectedValue == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Is Amount Sanctioned Under Sub-Debt Scheme  \\n";
                        slno = slno + 1;
                    }
                }
                if (rbtSubordinatedept.SelectedValue == "Y")
                {
                    if (txtAmount.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Sanctioned Under Sub-Debt Scheme (In Rs.)  \\n";
                        slno = slno + 1;
                    }
                }
            }
            if (Convert.ToDecimal(txtOutStandingAmount.Text) > 1000000)
            {
                if (rbtTEVStudyDone.SelectedValue == "NULL" || rbtTEVStudyDone.SelectedValue == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Is TEV Study Done or Not  \\n";
                    slno = slno + 1;
                }
                if (rbtTEVStudyDone.SelectedValue == "Y")
                {
                    if (rdviableTEV.SelectedValue == "NULL" || rdviableTEV.SelectedValue == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select 	Is Viable or not as per TEV Study  \\n";
                        slno = slno + 1;
                    }
                }
                if (rdviableTEV.SelectedValue == "Viable")
                {
                    if (txtRestructAmountTEV.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter  Restructuring(In Rs.)TEV Study done Amount \\n";
                        slno = slno + 1;
                    }
                    if (rbtSubordinateSchemeforTEV.SelectedValue == "NULL" || rbtSubordinateSchemeforTEV.SelectedValue == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Is Sanctioned Amount Under Subordinate Debt Scheme(TEV) \\n";
                        slno = slno + 1;
                    }
                }
                if (rbtSubordinateSchemeforTEV.SelectedValue == "Y")
                {
                    if (txtAmontTEVStudyDone.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Under Subordinate Debt Scheme(TEV) (In Rs.) \\n";
                        slno = slno + 1;
                    }
                }
            }
        }




        return ErrorMsg;
    }

    protected void rdAssessment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdAssessment.SelectedValue == "Y")
        {
            trviablenotviable.Visible = true;
        }
        else
        {
            trviablenotviable.Visible = false;
            rbtviablenotviable.ClearSelection();
            txtRestructAmount.Text = "";
            rbtSubordinatedept.ClearSelection();
            txtAmount.Text = "";

            trrestructingAmontviable.Visible = false;
            trsubordinatedept.Visible = false;
            tramount.Visible = false;
        }

    }

    protected void rdviableTEV_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdviableTEV.SelectedValue == "Viable")
        {
            trtevstudydonerestrctamount.Visible = true;
            TEVSbordinatedebtScheme.Visible = true;

        }
        else
        {
            trtevstudydonerestrctamount.Visible = false;
            TEVSbordinatedebtScheme.Visible = false;
            trTEVAmount.Visible = false;
            txtRestructAmountTEV.Text = "";
            txtAmontTEVStudyDone.Text = "";
            rbtSubordinateSchemeforTEV.ClearSelection();

        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet dsupdate = new DataSet();

        dsupdate = updateSubOrdinateDeptScheme(ViewState["ID"].ToString(), rbtSMANPA.SelectedValue.ToString(), txtOutStandingAmount.Text, rbtviablenotviable.SelectedValue.ToString(), rbtTEVStudyDone.SelectedValue.ToString(), txtRestructAmount.Text, txtRestructAmountTEV.Text,
                   rbtSubordinatedept.SelectedValue.ToString(), rbtSubordinateSchemeforTEV.SelectedValue.ToString(), txtAmount.Text, txtAmontTEVStudyDone.Text, rdAssessment.SelectedValue.ToString(), rdviableTEV.SelectedValue.ToString(), Session["uid"].ToString(), Session["uid"].ToString(), txtremarks.Text);

        if (dsupdate.Tables[0].Rows.Count > 0)
        {

            //string message = " Record Added Sccessflly";
            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
            btnUpdate.Enabled = false;
            return;

        }
    }
    public DataSet updateSubOrdinateDeptScheme(string ID,
string RbtSMANPA,
string SMAOtStandingAmount,
string RbtViablenotViable,
string RbtTEVStdyDone,
string RestructAmount_Viable,
string RestructAmount_TEV,
string RbtSubordinateDeptScheme_Viable,
string RbtSubordinateDeptScheme_TEV,
string SubordinateDeptSchemeAmont_Viable,
string SubordinateDeptSchemeAmont_TEV,
string Assestment,
string Viable_TEV,

string Created_by,
string Modified_by,
string Remarks)
    {
        DataSet Dsnew = new DataSet();

        SqlParameter[] pp = new SqlParameter[] {

               new SqlParameter("@RbtSMANPA",SqlDbType.VarChar),
               new SqlParameter("@SMAOtStandingAmount",SqlDbType.VarChar),
               new SqlParameter("@RbtViablenotViable",SqlDbType.VarChar),
                new SqlParameter("@RbtTEVStdyDone",SqlDbType.VarChar),
               new SqlParameter("@RestructAmount_Viable",SqlDbType.VarChar),
               new SqlParameter("@RestructAmount_TEV",SqlDbType.VarChar),
               new SqlParameter("@RbtSubordinateDeptScheme_Viable",SqlDbType.VarChar),
                new SqlParameter("@RbtSubordinateDeptScheme_TEV",SqlDbType.VarChar),
               new SqlParameter("@SubordinateDeptSchemeAmont_Viable",SqlDbType.VarChar),
               new SqlParameter("@SubordinateDeptSchemeAmont_TEV",SqlDbType.VarChar),
               new SqlParameter("@Assestment",SqlDbType.VarChar),
               new SqlParameter("@Viable_TEV",SqlDbType.VarChar),
                new SqlParameter("@Created_by",SqlDbType.VarChar),
               new SqlParameter("@Modified_by",SqlDbType.VarChar),
                new SqlParameter("@REMARKS",SqlDbType.VarChar),
                 new SqlParameter("@ID",SqlDbType.VarChar)

           };



        pp[0].Value = RbtSMANPA;

        if (SMAOtStandingAmount != null & SMAOtStandingAmount != "")
        {
            pp[1].Value = SMAOtStandingAmount;
        }
        else
        {
            pp[1].Value = null;
        }

        if (RbtViablenotViable != null & RbtViablenotViable != "")
        {
            pp[2].Value = RbtViablenotViable;
        }
        else
        {
            pp[2].Value = null;
        }
        if (RbtTEVStdyDone != null & RbtTEVStdyDone != "")
        {
            pp[3].Value = RbtTEVStdyDone;
        }
        else
        {
            pp[3].Value = null;
        }
        if (RestructAmount_Viable != null & RestructAmount_Viable != "")
        {
            pp[4].Value = RestructAmount_Viable;
        }
        else
        {
            pp[4].Value = null;
        }
        if (RestructAmount_TEV != null & RestructAmount_TEV != "")
        {
            pp[5].Value = RestructAmount_TEV;
        }
        else
        {
            pp[5].Value = null;
        }
        if (RbtSubordinateDeptScheme_Viable != null & RbtSubordinateDeptScheme_Viable != "")
        {
            pp[6].Value = RbtSubordinateDeptScheme_Viable;
        }
        else
        {
            pp[6].Value = null;
        }
        if (RbtSubordinateDeptScheme_TEV != null & RbtSubordinateDeptScheme_TEV != "")
        {
            pp[7].Value = RbtSubordinateDeptScheme_TEV;
        }
        else
        {
            pp[7].Value = null;
        }
        if (SubordinateDeptSchemeAmont_Viable != null & SubordinateDeptSchemeAmont_Viable != "")
        {
            pp[8].Value = SubordinateDeptSchemeAmont_Viable;
        }
        else
        {
            pp[8].Value = null;
        }
        if (SubordinateDeptSchemeAmont_TEV != null & SubordinateDeptSchemeAmont_TEV != "")
        {
            pp[9].Value = SubordinateDeptSchemeAmont_TEV;
        }
        else
        {
            pp[9].Value = null;
        }
        if (Assestment != null & Assestment != "")
        {
            pp[10].Value = Assestment;
        }
        else
        {
            pp[10].Value = null;
        }
        if (Viable_TEV != null & Viable_TEV != "")
        {
            pp[11].Value = Viable_TEV;
        }
        else
        {
            pp[11].Value = null;
        }


        pp[12].Value = Created_by;
        pp[13].Value = Modified_by;
        pp[14].Value = Remarks;
        pp[15].Value = ID;




        Dsnew = Gen.GenericFillDs("UPDATESBORDINATEDEPTSCHEMEDETAILS", pp);
        return Dsnew;
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmsbordinateDebtscheme.aspx");
    }
    public void clear()
    {
        txtUnitName.Text = "";
        txtEntrepreneurname.Text = "";
        ddlUnitDIst.SelectedValue = "0";
        ddlUnitMandal.SelectedValue = "0";
        ddlVillageunit.SelectedValue = "0";
        txtAddress.Text = "";
        txtmobileNo.Text = "";
        txtEmail.Text = "";
        ddlintLineofActivity.SelectedValue = "--Select--";
        rbtSMANPA.ClearSelection();
        txtOutStandingAmount.Text = "";
        rdAssessment.ClearSelection();
        rbtviablenotviable.ClearSelection();
        txtRestructAmount.Text = "";
        rbtSubordinatedept.ClearSelection();
        txtAmount.Text = "";
        rbtTEVStudyDone.ClearSelection();
        rdviableTEV.ClearSelection();
        txtRestructAmountTEV.Text = "";
        rbtSubordinateSchemeforTEV.ClearSelection();
        txtAmontTEVStudyDone.Text = "";
        BtnSave.Enabled = true;
        troutstandingAount.Visible = false;
        trassessment.Visible = false;
        trviablenotviable.Visible = false;
        trrestructingAmontviable.Visible = false;
        trsubordinatedept.Visible = false;
        tramount.Visible = false;
        trtevstudydone.Visible = false;
        trviableTEV.Visible = false;
        trtevstudydonerestrctamount.Visible = false;
        TEVSbordinatedebtScheme.Visible = false;
        trTEVAmount.Visible = false;
    }

    protected void txtRestructAmount_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtRestructAmount.Text) > Convert.ToDecimal(txtOutStandingAmount.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your entered Restruct Amount is Greater than Out Standing Amount')", true);
            return;
        }
    }

    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtAmount.Text) > Convert.ToDecimal(txtRestructAmount.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Sanctioned Amount Sholud Less than Restructed Amount')", true);
            txtAmount.Text = "";
            return;

        }
    }

    protected void txtRestructAmountTEV_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtRestructAmountTEV.Text) > Convert.ToDecimal(txtOutStandingAmount.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Amount Reqired for Restructuring(In Rs.)(TEV Study done) is greater than Out Standing Amount ')", true);

            return;
        }
    }

    protected void txtAmontTEVStudyDone_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtAmontTEVStudyDone.Text) > Convert.ToDecimal(txtRestructAmountTEV.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Sanctioned Amount Under Subordinate Debt Scheme(TEV) (In Rs.) Sholud Less than Amount Reqired for Restructuring(In Rs.)(TEV Study done)')", true);
            txtAmontTEVStudyDone.Text = "";
            return;
        }
    }

    public DataSet RETRIVESUBORDINATEDEBTSCHEMEDetails(string ID)
    {
        DB.DB con = new DB.DB();
        con.OpenConnection();
        SqlDataAdapter da;
        //con.OpenConnection();
        //SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("RETRIVE_SUBORDINATE_SCHEME_DETAILS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (ID.Trim() == "" || ID.Trim() == null)
                da.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = ID.ToString();


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


}