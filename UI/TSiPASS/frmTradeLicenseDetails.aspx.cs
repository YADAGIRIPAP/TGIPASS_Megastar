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

public partial class UI_TSiPASS_frmTradeLicenseDetails : System.Web.UI.Page
{
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    GHMCTEST.WebService objghmc = new GHMCTEST.WebService();
    string P_LICENCE_FEE, P_GARBAGE_CHARGES, P_FINES, P_ST;
    CDMAMASTERLIVE.CDMA_TRADEMASTER_SERVICES CDMAMASTER = new CDMAMASTERLIVE.CDMA_TRADEMASTER_SERVICES();
    PRDLIVE.TradelicenseNew PRDSERVICE = new PRDLIVE.TradelicenseNew();
    PRDLIVE.getDistrictList prddistrict = new PRDLIVE.getDistrictList();
    PRDLIVE.tradeNewBean prdoutput = new PRDLIVE.tradeNewBean();
    PRDLIVE.tradeLicenseFor tradefor = new PRDLIVE.tradeLicenseFor();
    PRDLIVE.tradeforcode subtrade = new PRDLIVE.tradeforcode();
    PRDLIVE.getFinyear finyearlist = new PRDLIVE.getFinyear();
    PRDLIVE.getAnnualFee annualfee = new PRDLIVE.getAnnualFee();
    PRDLIVE.getPriodFromToFinyear fromto = new PRDLIVE.getPriodFromToFinyear();

    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       // prdoutput.dist_list = PRDSERVICE.getDistrictList("", "");

        //divCDMA.Visible = true;
        //divGHMC.Visible = true;
        //DIVPRD.Visible = true;
        string cdmadistid = "";
        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                if (dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString() != null && dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString() != "")
                {
                    cdmadistid = dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString().Trim();
                }
            }
            else
            {
                Session["ApplidA"] = "0";
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
                }

            }


            // }
        }
        if (!IsPostBack)
        {
            PRDLIVE.TradelicenseNew prdservice = new PRDLIVE.TradelicenseNew();


            CDMAMASTERLIVE.ULB_ModelReq CDMAPARAMETERS = new CDMAMASTERLIVE.ULB_ModelReq();
            CDMAMASTERLIVE.District_Model districtres = new CDMAMASTERLIVE.District_Model();
            //CDMAMASTERLIVE.TaskOfListOfDistrict_Model district = CDMAMASTER.GetDistrictList();
            CDMAMASTERLIVE.ULB_ModelRes resparameters = new CDMAMASTERLIVE.ULB_ModelRes();
            //CDMAPARAMETERS.I_DSTOBJID=
            DataSet dsghmc = new DataSet();

            dsghmc = Gen.getdataofidentityCFONewApproval(Session["ApplidA"].ToString(), "118");

            if (dsghmc.Tables[0].Rows.Count > 0)
            {
                hdnflagapprovalid.Value = dsghmc.Tables[0].Rows[0]["intDeptid"].ToString();

                if (hdnflagapprovalid.Value == "61" || hdnflagapprovalid.Value == "4" || hdnflagapprovalid.Value == "403")
                {
                    if (hdnflagapprovalid.Value == "403")
                    {
                        divGHMC.Visible = false;
                        divCDMA.Visible = true;
                        DIVPRD.Visible = false;
                        DataSet dscheck1 = new DataSet();
                        dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
                        if (dscheck1 != null && dscheck1.Tables.Count > 0 && dscheck1.Tables[0].Rows.Count > 0)
                        {
                            //Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                            if (dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString() != null && dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString() != "")
                            {
                                cdmadistid = dscheck1.Tables[0].Rows[0]["CDMADIST"].ToString().Trim();
                            }
                        }
                        CDMAPARAMETERS.I_DSTOBJID = Convert.ToInt32(cdmadistid);
                        //CDMAMASTERLIVE.TaskOfListOfULB_ModelRes ulblist = CDMAMASTER.GetULBList(CDMAPARAMETERS);
                        CDMAMASTERLIVE.ULB_ModelRes[] res = CDMAMASTER.GetULBList(CDMAPARAMETERS);
                        ddlulb.DataTextField = "VC_ULBNAME";
                        ddlulb.DataValueField = "I_ULBOBJID";
                        ddlulb.DataSource = res;
                        ddlulb.DataBind();
                        AddSelect(ddlulb);
                        ddlulb_SelectedIndexChanged(sender, e);

                        //CDMAMASTERLIVE.ULB_ModelRes[] resvo = null;
                        //DataTable dtraw = new DataTable();
                        //int k = res.Count();
                        //resvo = new CDMAMASTERLIVE.ULB_ModelRes[dtraw.Rows.Count];
                        //for (int k = 0; k < dtraw.Rows.Count; k++)
                        //{
                        //    resparameters.I_ULBOBJID =Convert.ToInt32(dtraw.Rows[k]["I_ULBOBJID"].ToString());
                        //    resparameters.VC_ULBNAME =dtraw.Rows[k]["VC_ULBNAME"].ToString();
                        //    ddlulb.SelectedValue = Convert.ToString(resparameters.I_ULBOBJID);
                        //    ddlulb.SelectedItem.Text = resparameters.VC_ULBNAME;
                        //}

                    }
                    else if (hdnflagapprovalid.Value == "4")
                    {
                        divGHMC.Visible = false;
                        divCDMA.Visible = false;
                        DIVPRD.Visible = true;
                    }
                    else if (hdnflagapprovalid.Value == "61")
                    {
                        divGHMC.Visible = true;
                        divCDMA.Visible = false;
                        DIVPRD.Visible = false;
                    }
                }

                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {

                        //  Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        //  Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }

                    else
                    {
                        //need to change
                        Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                    }
                }

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {
                    //need to change
                    Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                }
            }

        }



        if (!IsPostBack)
        {
            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());

            }

            if (Request.QueryString["intApplicationId"] != null)
            {
                hdfFlagID0.Value = Request.QueryString["intApplicationId"];
                BindRoadTYpes();
                BindGHMCCategories();
                BindCircles();
                BindTRADELICENSEFOR_PRD();
                BINDFINANCIALYEARS();
                BINDDISTRICTS();
                FillDetails();
            }
        }
    }
    public void BindTRADELICENSEFOR_PRD()
    {

        prdoutput.tradeList = PRDSERVICE.tradeLicenseFor("", "");
        ddltradelicensefor.DataTextField = "tradeforName";
        ddltradelicensefor.DataValueField = "tradeforcode";
        ddltradelicensefor.DataSource = prdoutput.tradeList;
        ddltradelicensefor.DataBind();
        AddSelect(ddltradelicensefor);

    }
    public void BINDFINANCIALYEARS()
    {

        prdoutput.finyearList = PRDSERVICE.getFinyear("", "");

        List<listitemddl> lst = new List<listitemddl>();
        int count = 0;
        foreach (PRDLIVE.stringArray abc in prdoutput.finyearList)
        {
            listitemddl ltm = new listitemddl();
            ltm.item = abc.item[0].ToString();
            lst.Add(ltm);
            count = count + 1;
        }


        ddltradelicenseyear.DataTextField = "item";
        ddltradelicenseyear.DataValueField = "item";
        ddltradelicenseyear.DataSource = lst;
        ddltradelicenseyear.DataBind();
        AddSelect(ddltradelicenseyear);

    }
    public class listitemddl
    {
        public string item
        {
            get;
            set;
        }
    }
    public void BINDDISTRICTS()
    {
        prdoutput.dist_list = PRDSERVICE.getDistrictList("", "");
        ddldistrict.DataTextField = "distName";
        ddldistrict.DataValueField = "distCode";
        ddldistrict.DataSource = prdoutput.dist_list;
        ddldistrict.DataBind();
        AddSelect(ddldistrict);

    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        prdoutput.mand_list = PRDSERVICE.getMandalList(ddldistrict.SelectedValue, "", "");
        ddlmandal.DataTextField = "mandName";
        ddlmandal.DataValueField = "mandCode";
        ddlmandal.DataSource = prdoutput.mand_list;
        ddlmandal.DataBind();
        AddSelect(ddlmandal);
    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        prdoutput.village_list = PRDSERVICE.getPanchayatList(ddldistrict.SelectedValue, ddlmandal.SelectedValue, "", "");
        ddlgrampanchayat.DataTextField = "officeName";
        ddlgrampanchayat.DataValueField = "officeid";
        ddlgrampanchayat.DataSource = prdoutput.village_list;
        ddlgrampanchayat.DataBind();
        AddSelect(ddlgrampanchayat);
    }
    public void BindGHMCCategories()
    {
        //DataSet dscat = new DataSet();

        //dscat = objghmc.TRADECATEGORYDETAILS();
        //if (dscat != null && dscat.Tables.Count > 0 && dscat.Tables[0].Rows.Count > 0)
        //{
        //    ddlghmccategoery.DataSource = dscat.Tables[0];
        //    ddlghmccategoery.DataTextField = "VC_CTGY_DESC_NEW";
        //    ddlghmccategoery.DataValueField = "I_CTGY_CODE_NEW";
        //    ddlghmccategoery.DataBind();
        //    AddSelect(ddlghmccategoery);
        //}
        //else
        //{
        //    ddlghmccategoery.Items.Clear();
        //    AddSelect(ddlghmccategoery);
        //}
    }
    public void BindCircles()
    {
        //DataSet dscircle = new DataSet();

        //dscircle = objghmc.TRADECIRCLES();
        //if (dscircle != null && dscircle.Tables.Count > 0 && dscircle.Tables[0].Rows.Count > 0)
        //{
        //    ddlcircle.DataSource = dscircle.Tables[0];
        //    ddlcircle.DataTextField = "CIRCLE_NAME";
        //    ddlcircle.DataValueField = "CIRCLE_NO";
        //    ddlcircle.DataBind();
        //    AddSelect(ddlcircle);
        //}
        //else
        //{
        //    ddlcircle.Items.Clear();
        //    AddSelect(ddlcircle);
        //}
    }
    public void BindRoadTYpes()
    {
        //DataSet dsroadtype = new DataSet();

        //dsroadtype = objghmc.TRADEUNITRATES();
        //if (dsroadtype != null && dsroadtype.Tables.Count > 0 && dsroadtype.Tables[0].Rows.Count > 0)
        //{
        //    ddlroadtype.DataSource = dsroadtype.Tables[0];
        //    ddlroadtype.DataTextField = "ROADTYPE";
        //    ddlroadtype.DataValueField = "UNITRATEID";
        //    ddlroadtype.DataBind();
        //    AddSelect(ddlroadtype);
        //}
        //else
        //{
        //    ddlroadtype.Items.Clear();
        //    AddSelect(ddlroadtype);
        //}
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

            ds = Gen.RetriveTrdeLicenseData(hdfFlagID0.Value.ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnidentityid.Value = Convert.ToString(ds.Tables[0].Rows[0]["intcdmaid"]);

                if (hdnflagapprovalid.Value == "403")//cdma
                {
                txtheight.Text = Convert.ToString(ds.Tables[0].Rows[0]["HEIGHT_CDMA"]);
                txtwidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["WIDTH_CDMA"]);
                txtplinthareacdma.Text = Convert.ToString(ds.Tables[0].Rows[0]["LINTHAREA_CDMA"]);

                rbtnature.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["tradenature_cdma"]);
                if (ds.Tables[0].Rows[0]["tradenature_cdma"].ToString() == "T")
                {
                    txtfromdate.Enabled = true;
                    txtfromdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["fromdatecdma"]);
                    txttodate.Enabled = true;
                    txttodate.Text = Convert.ToString(ds.Tables[0].Rows[0]["todatecdma"]);

                }
                txttradetitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["tradetitle_cdma"]);
                ddlulb.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TradeULB"]);
                ddlulb_SelectedIndexChanged(this, EventArgs.Empty);
                ddlcdmacategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["categoerytype_cdma"].ToString().Trim());
                ddlcdmacategoery_SelectedIndexChanged(this, EventArgs.Empty);
                ddlcdmasubcategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["subcategoery_cdma"].ToString().Trim());
                //ddlcdmacategoery_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else if (hdnflagapprovalid.Value == "61")//ghmc
                {
                    //    ddlghmccategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["categoerytype_ghmc"].ToString().Trim());
                    ddlghmccategoery_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlghmcsubcategoery.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["subcategoery_ghmc"].ToString().Trim());
                    ddlroadtype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["roadtype_ghmc"].ToString().Trim());
                    txtroadwidth.Text = Convert.ToString(ds.Tables[0].Rows[0]["roadwidth_ghmc"].ToString().Trim());
                    txtmaxceilamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["maximumclaimamount_ghmc"].ToString().Trim());
                    txtplintharea.Text = Convert.ToString(ds.Tables[0].Rows[0]["plintharea_ghmc"].ToString().Trim());
                    ddlcircle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["circle_ghmc"].ToString().Trim());
                    ddlcircle_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlwardname.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["wardname_ghmc"].ToString().Trim());

                    ddllocality.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["locality_ghmc"].ToString().Trim());
                    rbtpropertytype.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["propertytype_ghmc"].ToString().Trim());
                    if (ds.Tables[0].Rows[0]["propertytype_ghmc"].ToString() == "1" || ds.Tables[0].Rows[0]["propertytype_ghmc"].ToString() == "3")
                    {
                        trpropertytax.Visible = true;
                        txtproertytaxnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["propertytaxnumber_ghmc"]);
                        txtownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["ownername_ghmc"]);
                        txtdoornumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["doornumber_ghmc"]);
                        txtaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address_ghmc"]);
                    }
                    if (ds.Tables[0].Rows[0]["propertytype_ghmc"].ToString() == "2")
                    {
                        trplotno.Visible = true;
                        txtplotnumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["plotnumber_ghmc"]);
                        txtownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["ownername_ghmc"]);
                        txtdoornumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["doornumber_ghmc"]);
                        txtaddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["address_ghmc"]);
                    }
                }
                else
                {
                    ddldistrict.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["districtid"]);
                    ddldistrict_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlmandal.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["mandalid"]);
                    ddlmandal_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlgrampanchayat.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["grampanchayatofficeid"]);

                    ddltradelicensefor.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TradeLicensefor"]);
                    ddltradelicensefor_SelectedIndexChanged(this, EventArgs.Empty);

                    ddltrade.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Trade"]);
                    ddltrade_SelectedIndexChanged(this, EventArgs.Empty);

                    ddlsubtrade.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubTrade"]);
                    txtannuallicensefee.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnnualLicenseFee"]);
                    ddltradelicenseyear.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TradeLicenseYear"]);
                    txtlicenseperiodfrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["LicenseYearFrom"]);
                    txtlicenseperiodto.Text = Convert.ToString(ds.Tables[0].Rows[0]["LicenseYearTo"]);
                    ddlestablishbilding.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EstablishedBuilding"]);
                    if (ddlestablishbilding.SelectedValue == "1")
                    {
                        trbuildingownername.Visible = true;
                        trrentorleasedeedno.Visible = false;
                        trrentorleasedeeddate.Visible = false;
                        trrentorleaseperiodfrom.Visible = false;
                        trrentorleaseperiodto.Visible = false;
                        txtbuildingownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerName"]);
                    }
                    else
                    {
                        trbuildingownername.Visible = true;
                        trrentorleasedeedno.Visible = true;
                        trrentorleasedeeddate.Visible = true;
                        trrentorleaseperiodfrom.Visible = true;
                        trrentorleaseperiodto.Visible = true;
                        txtbuildingownername.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerName"]);
                        txtrentorleasedeedno.Text = Convert.ToString(ds.Tables[0].Rows[0]["RentorLeaseDeedNo"]);
                        txtrentorleasedeeddate.Text = Convert.ToString(ds.Tables[0].Rows[0]["RentorLeaseDeedDate"]);
                        txtrentorleaseperiodfrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["RentorLeasePeriodFrom"]);
                        txtrentorleaseperiodto.Text = Convert.ToString(ds.Tables[0].Rows[0]["RentorLeasePeriodTo"]);

                    }
                    ddlconcerndeptlicensereqired.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ConcernedDeptLicense"]);
                    ddlconcerndeptlicensereqired_SelectedIndexChanged(this, EventArgs.Empty);

                    if (ddlconcerndeptlicensereqired.SelectedValue == "Y")
                    {
                        trdeptlicensedetails.Visible = true;
                        txtdeptlicensedetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["DeptLicenseDetails"]);
                        txtTANorGSt.Text = Convert.ToString(ds.Tables[0].Rows[0]["TANorGSTno"]);
                    }
                    else
                    {
                        trdeptlicensedetails.Visible = false;
                        txtTANorGSt.Text = Convert.ToString(ds.Tables[0].Rows[0]["TANorGSTno"]);

                    }


                }
            }
            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmetsDataCFO(hdfFlagID0.Value.ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("BuildingTaxPaidReceipt"))
                    {
                        hyptaxpaidreceipt.NavigateUrl = sen;
                        hyptaxpaidreceipt.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblbuildingtaxpaidreceipt.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("OwnershiporLeaseAgreement"))
                    {
                        hyperownershiporleaseagrmntdocment.NavigateUrl = sen;
                        hyperownershiporleaseagrmntdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblownershiporleaseagrmntdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("DepartmentLicense"))
                    {
                        hyperdepartmentlicense.NavigateUrl = sen;
                        hyperdepartmentlicense.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbldepartmentlicense.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("TANorGSTdocment"))
                    {
                        hypertanorgstdocment.NavigateUrl = sen;
                        hypertanorgstdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lbltanorgstdocment.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("LeaseDeed"))
                    {
                        hyperlinkleasedeed.NavigateUrl = sen;
                        hyperlinkleasedeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblleasedeed.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;



                }
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
    protected void rbtnature_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnature.SelectedValue == "T")
        {
            txtfromdate.Enabled = true;
            txttodate.Enabled = true;
        }
        else
        {
            txtfromdate.Enabled = false;
            txtfromdate.Text = "";
            txttodate.Enabled = false;
            txttodate.Text = "";
        }
    }

    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
        if (divCDMA.Visible == true)
        {
            if (txtheight.Text == "" || txtheight.Text == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Height other than zero\\n";
                slno = slno + 1;
            }
            if (txtwidth.Text == ""||txtwidth.Text =="0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Width other than zero \\n";
                slno = slno + 1;
            }

            if (rbtnature.SelectedValue == "0" || rbtnature.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select trade nature \\n";
                slno = slno + 1;
            }
            if (txttradetitle.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter trade title \\n";
                slno = slno + 1;
            }
            if (rbtnature.SelectedValue == "T")
            {
                if (txtfromdate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please from date \\n";
                    slno = slno + 1;
                }
                if (txttodate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter to date \\n";
                    slno = slno + 1;
                }
            }
            if (ddlcdmacategoery.SelectedValue == "0" || ddlcdmacategoery.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select categoery type \\n";
                slno = slno + 1;
            }
            if (ddlcdmacategoery.SelectedValue == "" || ddlcdmacategoery.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select subcategoery type \\n";
                slno = slno + 1;
            }
        }
        if (divGHMC.Visible == true)
        {
            if (ddlghmccategoery.SelectedValue == "0" || ddlghmccategoery.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select categowey type(GHMC) \\n";
                slno = slno + 1;
            }
            if (ddlghmcsubcategoery.SelectedValue == "0" || ddlghmcsubcategoery.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select subcategowey type(GHMC) \\n";
                slno = slno + 1;
            }
            if (ddlroadtype.SelectedValue == "0" || ddlroadtype.SelectedValue == "--Select Road Type--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select road type \\n";
                slno = slno + 1;
            }
            if (txtplintharea.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter plinth area in Sft. \\n";
                slno = slno + 1;
            }
            if (ddlcircle.SelectedValue == "0" || ddlcircle.SelectedValue == "--Select Circle--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select your circle name \\n";
                slno = slno + 1;
            }
            if (ddlwardname.SelectedValue == "0" || ddlwardname.SelectedValue == "--Select Ward Name--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select your Ward name \\n";
                slno = slno + 1;
            }
            if (ddllocality.SelectedValue == "0" || ddllocality.SelectedValue == "--Select Locality--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select your localoty \\n";
                slno = slno + 1;
            }
            if (rbtpropertytype.SelectedValue == "0" || rbtpropertytype.SelectedValue == "NULL")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select your Property Type \\n";
                slno = slno + 1;
            }
            if (rbtpropertytype.SelectedValue == "1" || rbtpropertytype.SelectedValue == "3")
            {

                if (txtproertytaxnumber.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter your Property tax number \\n";
                    slno = slno + 1;
                }
            }
            if (rbtpropertytype.SelectedValue == "2")
            {

                if (txtplotnumber.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter your plot number \\n";
                    slno = slno + 1;
                }
            }
            if (txtaddress.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter your address \\n";
                slno = slno + 1;
            }
        }
        if (DIVPRD.Visible == true)
        {
            if (ddltradelicensefor.SelectedValue == "0" || ddltradelicensefor.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Trade License For which you want to apply \\n";
                slno = slno + 1;
            }
            if (ddltrade.SelectedValue == "0" || ddltrade.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Trade type \\n";
                slno = slno + 1;
            }
            if (ddlsubtrade.SelectedValue == "0" || ddlsubtrade.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Sub Trade type \\n";
                slno = slno + 1;
            }
            if (ddltradelicenseyear.SelectedValue == "0" || ddltradelicenseyear.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select tradelicense Year \\n";
                slno = slno + 1;
            }
            if (ddlestablishbilding.SelectedValue == "0" || ddlestablishbilding.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Proposed License/Establishment Building Type \\n";
                slno = slno + 1;
            }
            if (ddlestablishbilding.SelectedValue == "1")
            {
                if (txtbuildingownername.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Owner name \\n";
                    slno = slno + 1;
                }
            }
            if (ddlestablishbilding.SelectedValue == "2" || ddlestablishbilding.SelectedValue == "3")
            {
                if (txtbuildingownername.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Owner name \\n";
                    slno = slno + 1;
                }
                if (txtrentorleasedeedno.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter rent or leasedeed no \\n";
                    slno = slno + 1;
                }
                if (txtrentorleasedeeddate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter rent or lease deed date \\n";
                    slno = slno + 1;
                }
                if (txtrentorleaseperiodfrom.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter rent or leased period from\\n";
                    slno = slno + 1;
                }
                if (txtrentorleaseperiodto.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter rent or leased period to \\n";
                    slno = slno + 1;
                }
            }
            if (ddlconcerndeptlicensereqired.SelectedValue == "0" || ddlconcerndeptlicensereqired.SelectedValue == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select  wheather Concerned Department License is Required or not \\n";
                slno = slno + 1;
            }
            if (ddlconcerndeptlicensereqired.SelectedValue == "Y")
            {
                if (txtTANorGSt.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TAN or GST number \\n";
                    slno = slno + 1;
                }
                if (txtdeptlicensedetails.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Department License Details \\n";
                    slno = slno + 1;
                }
            }
            if (ddlconcerndeptlicensereqired.SelectedValue == "N")
            {
                if (txtTANorGSt.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TAN or GST number \\n";
                    slno = slno + 1;
                }
            }
        }
        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        string tradefee = "0";
        string PLICENCEFEE = "0";
        string PGARBAGECHARGES = "0";
        string PFINES = "0";
        string PST = "0";
        string ULBNAME = "";
        string CATEGORYNAME = "";
        string SUBCATEGORYNAME = "";
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (divCDMA.Visible == true)
        {
            if (ddlcdmasubcategoery.SelectedValue != "0")
            {
                CDMAMASTERLIVE.GetTradeFeesReq cdmatradefeereq = new CDMAMASTERLIVE.GetTradeFeesReq();
                CDMAMASTERLIVE.GetTradeFeesRes cdmatradefeeres = new CDMAMASTERLIVE.GetTradeFeesRes();
                cdmatradefeereq.I_TRCTGYCODE = Convert.ToInt32(ddlcdmacategoery.SelectedValue);
                cdmatradefeereq.I_TRSUBCTGYCODE = Convert.ToInt32(ddlcdmasubcategoery.SelectedValue);
                cdmatradefeereq.I_ULBOBJID = Convert.ToInt32(ddlulb.SelectedValue);
                cdmatradefeeres = CDMAMASTER.GetTradeFees(cdmatradefeereq);
                tradefee = cdmatradefeeres.LICENCE_FEE;

                ULBNAME = ddlulb.SelectedItem.Text;
                CATEGORYNAME = ddlcdmacategoery.SelectedItem.Text;
                SUBCATEGORYNAME = ddlcdmasubcategoery.SelectedItem.Text;
            }
        }
        if (divGHMC.Visible == true)
        {
            if (txtplintharea.Text != "")
            {
                if (ddlroadtype.SelectedValue != "" || ddlroadtype.SelectedItem.Text != "--Select Road Type--")
                {
                    DataSet dscat = new DataSet();

                    string amount = objghmc.TRADEFEECALCULATION(ddlroadtype.SelectedValue, txtplintharea.Text.Trim());
                    if (amount != null && amount != "")
                    {
                        string[] values = amount.ToString().Split(',');
                        P_LICENCE_FEE = values[0].Trim();
                        P_GARBAGE_CHARGES = values[1].Trim();
                        P_FINES = values[2].Trim();
                        P_ST = values[3].Trim();
                        tradefee = amount;
                        PLICENCEFEE = P_LICENCE_FEE;
                        PGARBAGECHARGES = P_GARBAGE_CHARGES;
                        PFINES = P_FINES;
                        PST = P_ST;
                        ULBNAME = ddlwardname.SelectedItem.Text;
                        CATEGORYNAME = ddlghmccategoery.SelectedItem.Text;
                        SUBCATEGORYNAME = ddlghmcsubcategoery.SelectedItem.Text;
                    }
                    else
                    {

                    }
                }
                else
                {
                    lblmsg0.Text = "Please select Road Type and then enter Plinth Area";
                }
            }
        }
        if (DIVPRD.Visible == true)
        {
            //PRDSERVICE.tra
        }

        DataSet ds = new DataSet();
        ds = InsertTradeLicenseDetails(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), rbtnature.SelectedValue, txtfromdate.Text,
            txttodate.Text, txttradetitle.Text, ddlcdmacategoery.SelectedValue, ddlcdmasubcategoery.SelectedValue, ddlroadtype.SelectedValue, txtroadwidth.Text,
            txtmaxceilamount.Text, txtplintharea.Text, ddlghmccategoery.SelectedValue, ddlghmcsubcategoery.SelectedValue, ddlcircle.SelectedValue, ddlwardname.SelectedValue, ddllocality.SelectedValue, rbtpropertytype.SelectedValue,
            txtproertytaxnumber.Text, txtplotnumber.Text, txtownername.Text, txtdoornumber.Text, txtaddress.Text, hdnidentityid.Value, ddlulb.SelectedValue,

            ddltradelicensefor.SelectedValue, ddltrade.SelectedValue, ddlsubtrade.SelectedValue, txtannuallicensefee.Text, ddltradelicenseyear.SelectedValue,
            txtlicenseperiodfrom.Text, txtlicenseperiodto.Text, ddlestablishbilding.SelectedValue, txtbuildingownername.Text, txtrentorleasedeedno.Text,
            txtrentorleasedeeddate.Text, txtrentorleaseperiodfrom.Text, txtrentorleaseperiodto.Text, ddlconcerndeptlicensereqired.SelectedValue,
            txtTANorGSt.Text, txtdeptlicensedetails.Text,
            Session["uid"].ToString(), Session["uid"].ToString(), txtheight.Text.Trim().ToString(),
            txtwidth.Text.Trim().ToString(), txtplinthareacdma.Text.Trim().ToString(), txtghmctradetile.Text, tradefee, PLICENCEFEE, PGARBAGECHARGES, PFINES, PST, ULBNAME, CATEGORYNAME, SUBCATEGORYNAME, ddldistrict.SelectedValue, ddlmandal.SelectedValue, ddlgrampanchayat.SelectedValue, txtinstallationfee.Text.Trim().ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (hdnidentityid.Value == "0" || hdnidentityid.Value == "null" || hdnidentityid.Value == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                //BtnSave.Enabled = false;
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                //BtnSave.Enabled = false;
                return;
            }
        }
    }
    public DataSet InsertTradeLicenseDetails(

string intQuessionaireCFOid,
string intCFOEnterpid,
string tradenature,
string fromdate,
string todate,
string tradetitle,

string categoery,
string subcategoery,
string roadtype,
string roadwidth,
string maximumceillingamount,
string plintharea,
string categoery_ghmc,
string subcategoery_ghmc,
string circle,
string wardname,
string locality,
string propertytype,
string propertytaxnumber,
string plotnumber,
string ownername,
string doornumber,
string address,
string identityid,
string tradeulb,

string tradelicensefor,
string trade,
string subtrade,
string annuallicensefee,
string tradelicenseyear,
string licenseyearfrom,
string licenseyearto,
string establishedbuilding,
string buildingownername,
string rentroleasedeedno,
string rentorleasedeeddate,
string rentorleaseperiodfrom,
string rentorleaseperiodto,
string concerneddeptlicense,
string tanorgstno,
string deptlicensedetails,


string createdby,
string modefiedby, string heightCDMA,
string widthCDMA,
string plinthareaCDMA, string ghmctradetitle, string tradefee, string PLICENCEFEE, string PGARBAGECHARGES, string PFINES, string PST, string ULBNAME,
string CATEGORYNAME, string SUBCATEGORYNAME, string DISTRICTID, string MANDALID, string GRAMPANCHAYATOFFICEID, string instalLationfee)
    {
        if (osqlConnection.State != ConnectionState.Open)
            osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_Insert_TradeLicenseDetails", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.ToString();
            da.SelectCommand.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intCFOEnterpid.ToString();
            if (tradenature.Trim() == "" || tradenature.Trim() == null || tradenature.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@tradenature", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@tradenature", SqlDbType.VarChar).Value = tradenature.ToString();
            if (fromdate.Trim() == "" || fromdate.Trim() == null || fromdate.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@fromdate", SqlDbType.DateTime).Value = Convert.ToDateTime(fromdate.ToString());
            if (todate.Trim() == "" || todate.Trim() == null || todate.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@todate", SqlDbType.DateTime).Value = Convert.ToDateTime(todate.ToString());
            if (tradetitle.Trim() == "" || tradetitle.Trim() == null || tradetitle.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@tradetitle", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@tradetitle", SqlDbType.VarChar).Value = tradetitle.ToString();
            if (categoery.Trim() == "" || categoery.Trim() == null || categoery.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@categoerytype", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@categoerytype", SqlDbType.VarChar).Value = categoery.ToString();
            if (subcategoery.Trim() == "" || subcategoery.Trim() == null || subcategoery.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@subcategoery", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@subcategoery", SqlDbType.VarChar).Value = subcategoery.ToString();
            if (divCDMA.Visible == true)
            {
                da.SelectCommand.Parameters.Add("@cdmaflag", SqlDbType.VarChar).Value = "Y";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@cdmaflag", SqlDbType.VarChar).Value = DBNull.Value;
            }

            if (roadtype.Trim() == "" || roadtype.Trim() == null || roadtype.Trim() == "--Select Road Type--")
            {
                da.SelectCommand.Parameters.Add("@roadtype_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@roadtype_ghmc", SqlDbType.VarChar).Value = roadtype.ToString();
            if (roadwidth.Trim() == "" || roadwidth.Trim() == null || roadwidth.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@roadwidth_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@roadwidth_ghmc", SqlDbType.VarChar).Value = roadwidth.ToString();
            if (maximumceillingamount.Trim() == "" || maximumceillingamount.Trim() == null || maximumceillingamount.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@maximumclaimamount_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@maximumclaimamount_ghmc", SqlDbType.VarChar).Value = maximumceillingamount.ToString();

            if (plintharea.Trim() == "" || plintharea.Trim() == null || plintharea.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@plintharea_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@plintharea_ghmc", SqlDbType.VarChar).Value = plintharea.ToString();



            if (categoery_ghmc.Trim() == "" || categoery_ghmc.Trim() == null || categoery_ghmc.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@categoerytype_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@categoerytype_ghmc", SqlDbType.VarChar).Value = categoery_ghmc.ToString();

            if (subcategoery_ghmc.Trim() == "" || subcategoery_ghmc.Trim() == null || subcategoery_ghmc.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@subcategoery_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@subcategoery_ghmc", SqlDbType.VarChar).Value = subcategoery_ghmc.ToString();


            if (circle.Trim() == "" || circle.Trim() == null || circle.Trim() == "--Select Circle--")
            {
                da.SelectCommand.Parameters.Add("@circle_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@circle_ghmc", SqlDbType.VarChar).Value = circle.ToString();

            if (wardname.Trim() == "" || wardname.Trim() == null || wardname.Trim() == "--Select Ward Name--")
            {
                da.SelectCommand.Parameters.Add("@wardname_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@wardname_ghmc", SqlDbType.VarChar).Value = wardname.ToString();

            if (locality.Trim() == "" || locality.Trim() == null || locality.Trim() == "--Select Locality--")
            {
                da.SelectCommand.Parameters.Add("@locality_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@locality_ghmc", SqlDbType.VarChar).Value = locality.ToString();

            if (propertytype.Trim() == "" || propertytype.Trim() == null || propertytype.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@propertytype_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@propertytype_ghmc", SqlDbType.VarChar).Value = propertytype.ToString();

            if (propertytaxnumber.Trim() == "" || propertytaxnumber.Trim() == null || propertytaxnumber.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@propertytaxnumber_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@propertytaxnumber_ghmc", SqlDbType.VarChar).Value = propertytaxnumber.ToString();

            if (plotnumber.Trim() == "" || plotnumber.Trim() == null || plotnumber.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@plotnumber_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@plotnumber_ghmc", SqlDbType.VarChar).Value = plotnumber.ToString();

            if (ownername.Trim() == "" || ownername.Trim() == null || ownername.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ownername_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ownername_ghmc", SqlDbType.VarChar).Value = ownername.ToString();

            if (doornumber.Trim() == "" || doornumber.Trim() == null || doornumber.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@doornumber_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@doornumber_ghmc", SqlDbType.VarChar).Value = doornumber.ToString();

            if (address.Trim() == "" || address.Trim() == null || address.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@address_ghmc", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@address_ghmc", SqlDbType.VarChar).Value = address.ToString();
            if (divGHMC.Visible == true)
            {
                da.SelectCommand.Parameters.Add("@ghmcflag", SqlDbType.VarChar).Value = "Y";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@ghmcflag", SqlDbType.VarChar).Value = DBNull.Value;
            }


            if (createdby.Trim() == "" || createdby.Trim() == null || createdby.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = createdby.ToString();

            if (modefiedby.Trim() == "" || modefiedby.Trim() == null || modefiedby.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@modefiedby", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@modefiedby", SqlDbType.VarChar).Value = modefiedby.ToString();

            if (identityid.Trim() == "" || identityid.Trim() == null || identityid.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@incdmaid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@incdmaid", SqlDbType.VarChar).Value = identityid.ToString();

            if (tradelicensefor.Trim() == "" || tradelicensefor.Trim() == null || tradelicensefor.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@TradeLicensefor", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@TradeLicensefor", SqlDbType.VarChar).Value = tradelicensefor.ToString();

            if (trade.Trim() == "" || trade.Trim() == null || trade.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@Trade", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@Trade", SqlDbType.VarChar).Value = trade.ToString();

            if (subtrade.Trim() == "" || subtrade.Trim() == null || subtrade.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SubTrade", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SubTrade", SqlDbType.VarChar).Value = subtrade.ToString();

            if (annuallicensefee.Trim() == "" || annuallicensefee.Trim() == null || annuallicensefee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@AnnualLicenseFee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@AnnualLicenseFee", SqlDbType.VarChar).Value = annuallicensefee.ToString();

            if (tradelicenseyear.Trim() == "" || tradelicenseyear.Trim() == null || tradelicenseyear.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@TradeLicenseYear", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@TradeLicenseYear", SqlDbType.VarChar).Value = tradelicenseyear.ToString();

            if (licenseyearfrom.Trim() == "" || licenseyearfrom.Trim() == null || licenseyearfrom.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@LicenseYearFrom", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@LicenseYearFrom", SqlDbType.DateTime).Value = cmf.convertDateIndia(licenseyearfrom.ToString());

            if (licenseyearto.Trim() == "" || licenseyearto.Trim() == null || licenseyearto.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@LicenseYearTo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@LicenseYearTo", SqlDbType.DateTime).Value = cmf.convertDateIndia(licenseyearto.ToString());

            if (establishedbuilding.Trim() == "" || establishedbuilding.Trim() == null || establishedbuilding.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@EstablishedBuilding", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@EstablishedBuilding", SqlDbType.VarChar).Value = establishedbuilding.ToString();

            if (buildingownername.Trim() == "" || buildingownername.Trim() == null || buildingownername.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = buildingownername.ToString();

            if (rentroleasedeedno.Trim() == "" || rentroleasedeedno.Trim() == null || rentroleasedeedno.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@RentorLeaseDeedNo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@RentorLeaseDeedNo", SqlDbType.VarChar).Value = rentroleasedeedno.ToString();

            if (rentorleasedeeddate.Trim() == "" || rentorleasedeeddate.Trim() == null || rentorleasedeeddate.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@RentorLeaseDeedDate", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@RentorLeaseDeedDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(rentorleasedeeddate.ToString());

            if (rentorleaseperiodfrom.Trim() == "" || rentorleaseperiodfrom.Trim() == null || rentorleaseperiodfrom.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@RentorLeasePeriodFrom", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@RentorLeasePeriodFrom", SqlDbType.DateTime).Value = cmf.convertDateIndia(rentorleaseperiodfrom.ToString());

            if (rentorleaseperiodto.Trim() == "" || rentorleaseperiodto.Trim() == null || rentorleaseperiodto.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@RentorLeasePeriodTo", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@RentorLeasePeriodTo", SqlDbType.DateTime).Value = cmf.convertDateIndia(rentorleaseperiodto.ToString());

            if (concerneddeptlicense.Trim() == "" || concerneddeptlicense.Trim() == null || concerneddeptlicense.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ConcernedDeptLicense", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ConcernedDeptLicense", SqlDbType.VarChar).Value = concerneddeptlicense.ToString();

            if (tanorgstno.Trim() == "" || tanorgstno.Trim() == null || tanorgstno.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@TANorGSTno", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@TANorGSTno", SqlDbType.VarChar).Value = tanorgstno.ToString();

            if (deptlicensedetails.Trim() == "" || deptlicensedetails.Trim() == null || deptlicensedetails.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@DeptLicenseDetails", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@DeptLicenseDetails", SqlDbType.VarChar).Value = deptlicensedetails.ToString();
            if (DIVPRD.Visible == true)
            {
                da.SelectCommand.Parameters.Add("@PRDFLAG", SqlDbType.VarChar).Value = "Y";
            }
            else
            {
                da.SelectCommand.Parameters.Add("@PRDFLAG", SqlDbType.VarChar).Value = DBNull.Value;
            }


            if (tradeulb.Trim() == "" || tradeulb.Trim() == null || tradeulb.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@TradeULB", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@TradeULB", SqlDbType.VarChar).Value = tradeulb.ToString();


            if (heightCDMA.Trim() == "" || heightCDMA.Trim() == null)
            {
                da.SelectCommand.Parameters.Add("@heightCDMA", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@heightCDMA", SqlDbType.VarChar).Value = heightCDMA.ToString();

            if (widthCDMA.Trim() == "" || widthCDMA.Trim() == null)
            {
                da.SelectCommand.Parameters.Add("@widthCDMA", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@widthCDMA", SqlDbType.VarChar).Value = widthCDMA.ToString();

            if (plinthareaCDMA.Trim() == "" || plinthareaCDMA.Trim() == null)
            {
                da.SelectCommand.Parameters.Add("@plinthareaCDMA", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@plinthareaCDMA", SqlDbType.VarChar).Value = plinthareaCDMA.ToString();

            if (ghmctradetitle.Trim() == "" || ghmctradetitle.Trim() == null || ghmctradetitle.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ghmctradetitle", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ghmctradetitle", SqlDbType.VarChar).Value = ghmctradetitle.ToString();


            if (tradefee.Trim() == "" || tradefee.Trim() == null || tradefee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@tradefee", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@tradefee", SqlDbType.VarChar).Value = tradefee.ToString();

            if (PLICENCEFEE.Trim() == "" || PLICENCEFEE.Trim() == null || PLICENCEFEE.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@P_LICENCE_FEE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@P_LICENCE_FEE", SqlDbType.VarChar).Value = PLICENCEFEE.ToString();

            if (PGARBAGECHARGES.Trim() == "" || PGARBAGECHARGES.Trim() == null || PGARBAGECHARGES.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@P_GARBAGE_CHARGES", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@P_GARBAGE_CHARGES", SqlDbType.VarChar).Value = PGARBAGECHARGES.ToString();

            if (PFINES.Trim() == "" || PFINES.Trim() == null || PFINES.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@P_FINES", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@P_FINES", SqlDbType.VarChar).Value = PFINES.ToString();

            if (PST.Trim() == "" || PST.Trim() == null || PST.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@P_ST", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@P_ST", SqlDbType.VarChar).Value = PST.ToString();

            if (ULBNAME.Trim() == "" || ULBNAME.Trim() == null || ULBNAME.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@ULBNAME", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@ULBNAME", SqlDbType.VarChar).Value = ULBNAME.ToString();
            if (CATEGORYNAME.Trim() == "" || CATEGORYNAME.Trim() == null || CATEGORYNAME.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@CATEGORYNAME", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@CATEGORYNAME", SqlDbType.VarChar).Value = CATEGORYNAME.ToString();
            if (SUBCATEGORYNAME.Trim() == "" || SUBCATEGORYNAME.Trim() == null || SUBCATEGORYNAME.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@SUBCATEGORYNAME", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@SUBCATEGORYNAME", SqlDbType.VarChar).Value = SUBCATEGORYNAME.ToString();
            if (DISTRICTID.Trim() == "" || DISTRICTID.Trim() == null || DISTRICTID.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@districtid", SqlDbType.VarChar).Value = DISTRICTID.ToString();

            if (MANDALID.Trim() == "" || MANDALID.Trim() == null || MANDALID.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@mandalid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@mandalid", SqlDbType.VarChar).Value = MANDALID.ToString();

            if (GRAMPANCHAYATOFFICEID.Trim() == "" || GRAMPANCHAYATOFFICEID.Trim() == null || GRAMPANCHAYATOFFICEID.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@grampanchayatofficeid", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@grampanchayatofficeid", SqlDbType.VarChar).Value = GRAMPANCHAYATOFFICEID.ToString();

            if (instalLationfee.Trim() == "" || instalLationfee.Trim() == null || instalLationfee.Trim() == "--Select--")
            {
                da.SelectCommand.Parameters.Add("@INSTALLATIONFEE", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
                da.SelectCommand.Parameters.Add("@INSTALLATIONFEE", SqlDbType.VarChar).Value = instalLationfee.ToString();



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

    protected void btnleasedeed_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fupleasedeed.HasFile)
            {
                if ((fupleasedeed.PostedFile != null) && (fupleasedeed.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupleasedeed.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupleasedeed.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\LeaseDeed");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupleasedeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupleasedeed.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "LeaseDeed", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperlinkleasedeed.Text = fupleasedeed.FileName;
                                lblleasedeed.Text = fupleasedeed.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
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

    protected void rbtpropertytype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtpropertytype.SelectedValue == "1" || rbtpropertytype.SelectedValue == "3")
        {
            trpropertytax.Visible = true;
            trplotno.Visible = false;
            txtproertytaxnumber.Text = "";
            txtownername.Text = "";
            txtdoornumber.Text = "";
            txtaddress.Text = "";
        }
        if (rbtpropertytype.SelectedValue == "2")
        {
            trpropertytax.Visible = false;
            trplotno.Visible = true;
            txtplotnumber.Text = "";
            txtownername.Text = "";
            txtdoornumber.Text = "";
            txtaddress.Text = "";
        }
        DataSet dsroaddetails = new DataSet();
        dsroaddetails = objghmc.TRADEPROPERTYTYPE();
    }

    protected void ddlroadtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsroaddetails = new DataSet();
        dsroaddetails = objghmc.TRADEUNITRATES();
        if (dsroaddetails != null && dsroaddetails.Tables.Count > 0 && dsroaddetails.Tables[0].Rows.Count > 0)
        {
            int roaddetailscount = dsroaddetails.Tables[0].Rows.Count;
            for (int i = 0; i < roaddetailscount; i++)
            {


                //if (dsroaddetails.Tables[0].Rows[0]["UNITRATEID"].ToString() == "1" && dsroaddetails.Tables[0].Rows[i].ToString())
                if (ddlroadtype.SelectedValue == "1")
                {
                    txtroadwidth.Text = dsroaddetails.Tables[0].Rows[0]["ROADWIDTH"].ToString();
                    txtmaxceilamount.Text = dsroaddetails.Tables[0].Rows[0]["MAXCEILINGRATE"].ToString();
                }
                else if (ddlroadtype.SelectedValue == "2")
                {
                    txtroadwidth.Text = dsroaddetails.Tables[0].Rows[1]["ROADWIDTH"].ToString();
                    txtmaxceilamount.Text = dsroaddetails.Tables[0].Rows[1]["MAXCEILINGRATE"].ToString();
                }
                else if (ddlroadtype.SelectedValue == "3")
                {
                    txtroadwidth.Text = dsroaddetails.Tables[0].Rows[2]["ROADWIDTH"].ToString();
                    txtmaxceilamount.Text = dsroaddetails.Tables[0].Rows[2]["MAXCEILINGRATE"].ToString();
                }
                else
                {
                    txtroadwidth.Text = dsroaddetails.Tables[0].Rows[3]["ROADWIDTH"].ToString();
                    txtmaxceilamount.Text = dsroaddetails.Tables[0].Rows[3]["MAXCEILINGRATE"].ToString();
                }
            }
        }
    }

    protected void ddlcircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsward = new DataSet();
        dsward = objghmc.TRADEWARDS(ddlcircle.SelectedValue);
        if (dsward != null && dsward.Tables.Count > 0 && dsward.Tables[0].Rows.Count > 0)
        {
            ddlwardname.DataSource = dsward.Tables[0];
            ddlwardname.DataTextField = "WARD_NAME";
            ddlwardname.DataValueField = "WARD_ID";
            ddlwardname.DataBind();
            AddSelect(ddlwardname);
        }
        else
        {
            ddlwardname.Items.Clear();
            AddSelect(ddlwardname);
        }
        DataSet dslocality = new DataSet();
        dslocality = objghmc.TRADELOCALITIES(ddlcircle.SelectedValue);
        if (dslocality != null && dslocality.Tables.Count > 0 && dslocality.Tables[0].Rows.Count > 0)
        {
            ddllocality.DataSource = dslocality.Tables[0];
            ddllocality.DataTextField = "NAME";
            ddllocality.DataValueField = "LOCALITY_CODE";
            ddllocality.DataBind();
            AddSelect(ddllocality);
        }
        else
        {
            ddllocality.Items.Clear();
            AddSelect(ddllocality);
        }
    }

    //protected void ddlwardname_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataSet dslocality = new DataSet();
    //    dslocality = objghmc.TRADELOCALITIES(ddlcircle.SelectedValue);
    //    if (dslocality != null && dslocality.Tables.Count > 0 && dslocality.Tables[0].Rows.Count > 0)

    //    {
    //        ddllocality.DataSource = dslocality.Tables[0];
    //        ddllocality.DataTextField = "NAME";
    //        ddllocality.DataValueField = "LOCALITY_CODE";
    //        ddllocality.DataBind();
    //        AddSelect(ddllocality);
    //    }
    //    else
    //    {
    //        ddllocality.Items.Clear();
    //        AddSelect(ddllocality);
    //    }
    //}
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmFilmShootingApplication.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");
        Response.Redirect("manufactureRegistrations.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        string errormsg = ValidateControls();
        string tradefee = "0";
        string PLICENCEFEE = "0";
        string PGARBAGECHARGES = "0";
        string PFINES = "0";
        string PST = "0";
        string ULBNAME = "";
        string CATEGORYNAME = "";
        string SUBCATEGORYNAME = "";
        if (errormsg.Trim().TrimStart() != "")
        {
            string message = "alert('" + errormsg + "')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;
        }
        if (divCDMA.Visible == true)
        {
            if (ddlcdmasubcategoery.SelectedValue != "0")
            {
                CDMAMASTERLIVE.GetTradeFeesReq cdmatradefeereq = new CDMAMASTERLIVE.GetTradeFeesReq();
                CDMAMASTERLIVE.GetTradeFeesRes cdmatradefeeres = new CDMAMASTERLIVE.GetTradeFeesRes();
                cdmatradefeereq.I_TRCTGYCODE = Convert.ToInt32(ddlcdmacategoery.SelectedValue);
                cdmatradefeereq.I_TRSUBCTGYCODE = Convert.ToInt32(ddlcdmasubcategoery.SelectedValue);
                cdmatradefeereq.I_ULBOBJID = Convert.ToInt32(ddlulb.SelectedValue);
                cdmatradefeeres = CDMAMASTER.GetTradeFees(cdmatradefeereq);
                tradefee = cdmatradefeeres.LICENCE_FEE;

                ULBNAME = ddlulb.SelectedItem.Text;
                CATEGORYNAME = ddlcdmacategoery.SelectedItem.Text;
                SUBCATEGORYNAME = ddlcdmasubcategoery.SelectedItem.Text;
            }
        }
        if (divGHMC.Visible == true)
        {
            if (txtplintharea.Text != "")
            {
                if (ddlroadtype.SelectedValue != "" || ddlroadtype.SelectedItem.Text != "--Select Road Type--")
                {
                    DataSet dscat = new DataSet();

                    string amount = objghmc.TRADEFEECALCULATION(ddlroadtype.SelectedValue, txtplintharea.Text.Trim());
                    if (amount != null && amount != "")
                    {
                        string[] values = amount.ToString().Split(',');
                        P_LICENCE_FEE = values[0].Trim();
                        P_GARBAGE_CHARGES = values[1].Trim();
                        P_FINES = values[2].Trim();
                        P_ST = values[3].Trim();
                        tradefee = amount;
                        PLICENCEFEE = P_LICENCE_FEE;
                        PGARBAGECHARGES = P_GARBAGE_CHARGES;
                        PFINES = P_FINES;
                        PST = P_ST;
                        ULBNAME = ddlwardname.SelectedItem.Text;
                        CATEGORYNAME = ddlghmccategoery.SelectedItem.Text;
                        SUBCATEGORYNAME = ddlghmcsubcategoery.SelectedItem.Text;
                    }
                    else
                    {

                    }
                }
                else
                {
                    lblmsg0.Text = "Please select Road Type and then enter Plinth Area";
                }
            }
        }
        if (DIVPRD.Visible == true)
        {
            //PRDSERVICE.tra
        }

        DataSet ds = new DataSet();
        ds = InsertTradeLicenseDetails(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), rbtnature.SelectedValue, txtfromdate.Text,
            txttodate.Text, txttradetitle.Text, ddlcdmacategoery.SelectedValue, ddlcdmasubcategoery.SelectedValue, ddlroadtype.SelectedValue, txtroadwidth.Text,
            txtmaxceilamount.Text, txtplintharea.Text, ddlghmccategoery.SelectedValue, ddlghmcsubcategoery.SelectedValue, ddlcircle.SelectedValue, ddlwardname.SelectedValue, ddllocality.SelectedValue, rbtpropertytype.SelectedValue,
            txtproertytaxnumber.Text, txtplotnumber.Text, txtownername.Text, txtdoornumber.Text, txtaddress.Text, hdnidentityid.Value, ddlulb.SelectedValue,

            ddltradelicensefor.SelectedValue, ddltrade.SelectedValue, ddlsubtrade.SelectedValue, txtannuallicensefee.Text, ddltradelicenseyear.SelectedValue,
            txtlicenseperiodfrom.Text, txtlicenseperiodto.Text, ddlestablishbilding.SelectedValue, txtbuildingownername.Text, txtrentorleasedeedno.Text,
            txtrentorleasedeeddate.Text, txtrentorleaseperiodfrom.Text, txtrentorleaseperiodto.Text, ddlconcerndeptlicensereqired.SelectedValue,
            txtTANorGSt.Text, txtdeptlicensedetails.Text,
            Session["uid"].ToString(), Session["uid"].ToString(), txtheight.Text.Trim().ToString(),
            txtwidth.Text.Trim().ToString(), txtplintharea.Text.Trim().ToString(), txtghmctradetile.Text, tradefee, PLICENCEFEE, PGARBAGECHARGES, PFINES, PST, ULBNAME, CATEGORYNAME, SUBCATEGORYNAME, ddldistrict.SelectedValue, ddlmandal.SelectedValue, ddlgrampanchayat.SelectedValue, txtinstallationfee.Text.Trim().ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            if (hdnidentityid.Value == "0" || hdnidentityid.Value == "null" || hdnidentityid.Value == "") //
            {
               // Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                //BtnSave.Enabled = false;
                //return;
            }
            else
            {
                // Response.Redirect("frmCAFAttachmentDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                Response.Redirect("frmCFOWaterDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Updated Successfully')", true);
                //BtnSave.Enabled = false;
                //return;
            }
        }



    }
    protected void txtproertytaxnumber_TextChanged(object sender, EventArgs e)
    {

        txtownername.Text = "PropertyOwner";
        txtdoornumber.Text = "1-12";
    }

    protected void txtplotnumber_TextChanged(object sender, EventArgs e)
    {
        txtownername.Text = "PlotOwner";
        txtdoornumber.Text = "1-123";
    }

    protected void ddlulb_SelectedIndexChanged(object sender, EventArgs e)
    {
        CDMAMASTERLIVE.GetCategoriesReq categoryparamater = new CDMAMASTERLIVE.GetCategoriesReq();
        categoryparamater.I_ULBOBJID = Convert.ToInt32(ddlulb.SelectedValue);
        //CDMAMASTERLIVE.TaskOfListOfGetCategoriesRes categorylist = CDMAMASTER.GetCategories(categoryparamater);
        CDMAMASTERLIVE.GetCategoriesRes[] CATRES = CDMAMASTER.GetCategories(categoryparamater);
        ddlcdmacategoery.DataTextField = "VC_TRCNAME";
        ddlcdmacategoery.DataValueField = "I_TRCTGYCODE";
        ddlcdmacategoery.DataSource = CATRES;
        ddlcdmacategoery.DataBind();
        AddSelect(ddlcdmacategoery);

    }

    protected void ddltradelicensefor_SelectedIndexChanged(object sender, EventArgs e)
    {
        prdoutput.tradeList = PRDSERVICE.tradeforcode(ddltradelicensefor.SelectedValue, "", "");
        ddltrade.DataTextField = "tradedesc";
        ddltrade.DataValueField = "trade_code";
        ddltrade.DataSource = prdoutput.tradeList;
        ddltrade.DataBind();
        AddSelect(ddltrade);
        if (ddltradelicensefor.SelectedItem.Text.Trim().ToString() == "Cell Tower")
        {
            trinstallationfee.Visible = true;
        }
        else
        {
            trinstallationfee.Visible = false;
        }
    }

    protected void ddltrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        prdoutput.tradeList = PRDSERVICE.subtradecode(ddltrade.SelectedValue, "", "");
        ddlsubtrade.DataTextField = "subTradeDesc";
        ddlsubtrade.DataValueField = "subTrade";
        ddlsubtrade.DataSource = prdoutput.tradeList;
        ddlsubtrade.DataBind();
        AddSelect(ddlsubtrade);
    }

    protected void ddlsubtrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        PRDLIVE.tradeNewBean tradenewvo = new PRDLIVE.tradeNewBean();
        string fee = "";
        string installationfee = "";
        prdoutput.installationfee = PRDSERVICE.getAnnualFee(ddltradelicensefor.SelectedValue.ToString(), ddltrade.SelectedValue.ToString(), ddlsubtrade.SelectedValue.ToString(), ddlsubtrade.SelectedItem.Text.ToString(), ddlgrampanchayat.SelectedValue.ToString(), "", "").ToString();
        PRDLIVE.tradeNewBean[] tradenew = PRDSERVICE.getAnnualFee(ddltradelicensefor.SelectedValue.ToString(), ddltrade.SelectedValue.ToString(), ddlsubtrade.SelectedValue.ToString(), ddlsubtrade.SelectedItem.Text.ToString(), ddlgrampanchayat.SelectedValue.ToString(), "", "");

        int inttrade = tradenew.Length;

        for (int b = 0; b < inttrade; b++)
        {
            tradenewvo = tradenew[b];
            fee = tradenewvo.fee;
            installationfee = tradenewvo.installationfee;

        }

        txtannuallicensefee.Text = fee.ToString();
        //txtinstallationfee.Text = installationfee.ToString();
        if (installationfee == null || installationfee == "")
        {
            txtinstallationfee.Text = null;
        }
        else
        {
            txtinstallationfee.Text = installationfee.ToString();
        }
    }

    protected void ddltradelicenseyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        prdoutput.ROrLFromDate = PRDSERVICE.getPriodFromToFinyear(ddltradelicensefor.SelectedValue, ddltradelicenseyear.SelectedValue, "", "").ROrLFromDate;
        prdoutput.ROrLToDate = PRDSERVICE.getPriodFromToFinyear(ddltradelicensefor.SelectedValue, ddltradelicenseyear.SelectedValue, "", "").ROrLToDate;
        txtlicenseperiodfrom.Text = prdoutput.ROrLFromDate;
        txtlicenseperiodto.Text = prdoutput.ROrLToDate;
    }

    protected void ddlestablishbilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlestablishbilding.SelectedValue == "1")
        {
            trbuildingownername.Visible = true;
            trrentorleasedeedno.Visible = false;
            trrentorleasedeeddate.Visible = false;
            trrentorleaseperiodfrom.Visible = false;
            trrentorleaseperiodto.Visible = false;
        }
        else
        {
            trbuildingownername.Visible = true;
            trrentorleasedeedno.Visible = true;
            trrentorleasedeeddate.Visible = true;
            trrentorleaseperiodfrom.Visible = true;
            trrentorleaseperiodto.Visible = true;
        }
    }

    protected void ddlconcerndeptlicensereqired_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlconcerndeptlicensereqired.SelectedValue == "Y")
        {
            trdeptlicensedetails.Visible = true;
        }
        else
        {
            trdeptlicensedetails.Visible = false;
        }
    }

    protected void btnbuildingtaxpaidreceipt_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fupbuildingtaxpaidreceipt.HasFile)
            {
                if ((fupbuildingtaxpaidreceipt.PostedFile != null) && (fupbuildingtaxpaidreceipt.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupbuildingtaxpaidreceipt.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupbuildingtaxpaidreceipt.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\BuildingTaxPaidReceipt");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupbuildingtaxpaidreceipt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupbuildingtaxpaidreceipt.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "BuildingTaxPaidReceipt", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyptaxpaidreceipt.Text = fupbuildingtaxpaidreceipt.FileName;
                                lblbuildingtaxpaidreceipt.Text = fupbuildingtaxpaidreceipt.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btnownershiporleaseagrmntdocment_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fupownershiporleaseagrmntdocment.HasFile)
            {
                if ((fupownershiporleaseagrmntdocment.PostedFile != null) && (fupownershiporleaseagrmntdocment.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupownershiporleaseagrmntdocment.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupownershiporleaseagrmntdocment.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\OwnershiporLeaseAgreement");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupownershiporleaseagrmntdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupownershiporleaseagrmntdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "OwnershiporLeaseAgreement", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperownershiporleaseagrmntdocment.Text = fupownershiporleaseagrmntdocment.FileName;
                                lblownershiporleaseagrmntdocment.Text = fupownershiporleaseagrmntdocment.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btndepartmentlicense_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fupdepartmentlicense.HasFile)
            {
                if ((fupdepartmentlicense.PostedFile != null) && (fupdepartmentlicense.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fupdepartmentlicense.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fupdepartmentlicense.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\DepartmentLicense");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupdepartmentlicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupdepartmentlicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "DepartmentLicense", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hyperdepartmentlicense.Text = fupdepartmentlicense.FileName;
                                lbldepartmentlicense.Text = fupdepartmentlicense.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void btntanorgstdocment_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
            //string sFileDir = "~\\TenderNotice";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (fuptanorgstdocment.HasFile)
            {
                if ((fuptanorgstdocment.PostedFile != null) && (fuptanorgstdocment.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(fuptanorgstdocment.PostedFile.FileName);
                    try
                    {


                        string[] fileType = fuptanorgstdocment.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\TANorGSTdocment");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fuptanorgstdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fuptanorgstdocment.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;
                            result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TANorGSTdocment", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                hypertanorgstdocment.Text = fuptanorgstdocment.FileName;
                                lbltanorgstdocment.Text = fuptanorgstdocment.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    protected void ddlsubcategoery_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddlghmccategoery_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dssubcat = new DataSet();
            dssubcat = objghmc.TRADESUBCATEGORYDETAILS(ddlghmccategoery.SelectedValue);
            if (dssubcat != null && dssubcat.Tables.Count > 0 && dssubcat.Tables[0].Rows.Count > 0)
            {
                ddlghmcsubcategoery.DataSource = dssubcat.Tables[0];
                ddlghmcsubcategoery.DataValueField = "I_SUB_CTGY_CODE_NEW";
                ddlghmcsubcategoery.DataTextField = "VC_SUB_CTGY_DESC_NEW";
                ddlghmcsubcategoery.DataBind();
                AddSelect(ddlghmcsubcategoery);
            }
            else
            {
                AddSelect(ddlghmcsubcategoery);
            }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void ddlcdmacategoery_SelectedIndexChanged(object sender, EventArgs e)
    {
        CDMAMASTERLIVE.GetSubCategoriesReq subcategoryparamater = new CDMAMASTERLIVE.GetSubCategoriesReq();
        subcategoryparamater.I_TRCTGYCODE = Convert.ToInt32(ddlcdmacategoery.SelectedValue);
        //CDMAMASTERLIVE.TaskOfListOfGetSubCategoriesRes subcategorylist = CDMAMASTER.GetSubCategories(subcategoryparamater);
        CDMAMASTERLIVE.GetSubCategoriesRes[] SUBRES = CDMAMASTER.GetSubCategories(subcategoryparamater);
        ddlcdmasubcategoery.DataTextField = "VC_TRSUBCTGYNAME";
        ddlcdmasubcategoery.DataValueField = "I_TRSUBCTGYCODE";
        ddlcdmasubcategoery.DataSource = SUBRES;
        ddlcdmasubcategoery.DataBind();
        AddSelect(ddlcdmasubcategoery);
    }
    protected void txtplintharea_TextChanged(object sender, EventArgs e)
    {
        if (txtplintharea.Text != "")
        {
            if (ddlroadtype.SelectedValue != "" || ddlroadtype.SelectedItem.Text != "--Select Road Type--")
            {
                DataSet dscat = new DataSet();

                string amount = objghmc.TRADEFEECALCULATION(ddlroadtype.SelectedValue, txtplintharea.Text.Trim());
                if (amount != null && amount != "")
                {
                    string[] values = amount.ToString().Split(',');
                    P_LICENCE_FEE = values[0].Trim();
                    P_GARBAGE_CHARGES = values[1].Trim();
                    P_FINES = values[2].Trim();
                    P_ST = values[3].Trim();

                }
                else
                {

                }
            }
            else
            {
                lblmsg0.Text = "Please select Road Type and then enter Plinth Area";
            }
        }
    }

    protected void txtheight_TextChanged(object sender, EventArgs e)
    {
        String WIDTH = "";
        if (txtwidth.Text == "")
        {
            WIDTH = "0";
        }
        txtplinthareacdma.Text = (Convert.ToDecimal(txtheight.Text) * Convert.ToDecimal(WIDTH)).ToString();
    }

    protected void txtwidth_TextChanged(object sender, EventArgs e)
    {
        if (txtheight.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Height');", true);
        }
        else
        {
            txtplinthareacdma.Text = (Convert.ToDecimal(txtheight.Text) * Convert.ToDecimal(txtwidth.Text)).ToString();
        }
    }
    protected void ddlcdmasubcategoery_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CDMAMASTERLIVE.GetTradeFeesReq cdmatradefeereq = new CDMAMASTERLIVE.GetTradeFeesReq();
            CDMAMASTERLIVE.GetTradeFeesRes cdmatradefeeres = new CDMAMASTERLIVE.GetTradeFeesRes();
            cdmatradefeereq.I_TRCTGYCODE = Convert.ToInt32(ddlcdmacategoery.SelectedValue);
            cdmatradefeereq.I_TRSUBCTGYCODE = Convert.ToInt32(ddlcdmasubcategoery.SelectedValue);
            cdmatradefeereq.I_ULBOBJID = Convert.ToInt32(ddlulb.SelectedValue);
            cdmatradefeeres = CDMAMASTER.GetTradeFees(cdmatradefeereq);


        }
        catch (Exception ex)
        {
        }
    }
}