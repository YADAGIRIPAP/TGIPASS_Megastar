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
using System.IO;

public partial class UI_TSiPASS_frm_Renewalcelltower : System.Web.UI.Page
{
    PRDLIVE.TradelicenseNew PRDSERVICE = new PRDLIVE.TradelicenseNew();
    PRDLIVE.tradeNewBean prdoutput = new PRDLIVE.tradeNewBean();
    // PRDLIVE.TradelicenseNew prdservice = new PRDLIVE.TradelicenseNew();
    //PRDLIVE.tradeLicenseFor tradefor = new PRDLIVE.tradeLicenseFor();
    //PRDLIVE.tradeforcode subtrade = new PRDLIVE.tradeforcode();
    //PRDLIVE.getFinyear finyearlist = new PRDLIVE.getFinyear();
    //PRDLIVE.getAnnualFee annualfee = new PRDLIVE.getAnnualFee();
    //PRDLIVE.getPriodFromToFinyear fromto = new PRDLIVE.getPriodFromToFinyear();
    //PRDLIVE.getDistrictList prddistrict = new PRDLIVE.getDistrictList();
    //PRDLIVE.getRenewalTradeDetails obj_renewaldetails = new PRDLIVE.getRenewalTradeDetails();

    General Gen = new General();
    cls_renewalmobiletower obj_tower = new cls_renewalmobiletower();
    protected void Page_Load(object sender, EventArgs e)
    {
        //createdby = Session["uid"].ToString();
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
           
           
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(),"");
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
               
            }
            else
            {
                Session["Applid"] = "0";
            }

            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityRENAPPROVALID(Session["Applid"].ToString(), "139");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    BINDPRDDistricts();
                    BINDPRDFINANCIALYEARS();

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                        ////  Response.Redirect("frmFireDetailRen.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                        //Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }

                    else
                    {
                        Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }

            BINDPRDRenwaldetailsbyuseridrenewalid();
            if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
            {
                btn_getrenewaldetails.Visible = false;
                btn_clear.Visible = false;
                ResetFormControl(this);
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

    public void BINDPRDRenwaldetailsbyuseridrenewalid()
    {
        div_prdview.Visible = true;
        btn_getrenewaldetails.Visible = true;
        btn_clear.Visible = true;
        div_prddetails.Visible = false;
        div_prdsubmit.Visible = false;
       
        txt_prdcelltowerlice.Text = ""; txt_prdcelltowerfor.Text = ""; txt_prdtrade.Text = ""; txt_prdsubtrade.Text = "";
        txt_prdnameoffirm.Text = ""; txt_prdannuallicensefee.Text = ""; txt_prddoorlocality.Text = ""; txt_prdDistrictname.Text = "";
        txt_prdmandalname.Text = ""; txt_prdvillagename.Text = ""; txt_prdrenewalperiodfrom.Text = ""; txt_prdrenewalperiodto.Text = "";
        hf_PrdTradeID.Value = "";
        hf_PrdSubTradeID.Value = "";
        hf_PrdCellTowerID.Value = "";
       
        DataSet ds_binddata = obj_tower.Getcelltowerrenwaliduserid(Convert.ToString(Session["Applid"]),Convert.ToString(Session["uid"]));

        if (ds_binddata!=null)
        {
            if (ds_binddata.Tables.Count>0)
            {
                if(ds_binddata.Tables[0].Rows.Count>0)
                {
                    div_prdview.Visible = true;
                    div_prddetails.Visible = true;
                    div_prdsubmit.Visible = true;
                    txt_prdcelltowerlice.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdTradeLicenseNumber"]);
                    txt_prdcelltowerfor.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdCellTowerFor"]);
                    txt_prdtrade.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdTradeName"]);
                    txt_prdsubtrade.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdSubTradeName"]);
                    txt_prdnameoffirm.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdNameoffirm_shops"]); 
                    txt_prdannuallicensefee.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdAnuualLicenseFee"]); 
                    txt_prddoorlocality.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["prdDoorNo_locality"]);
                    txt_prdDistrictname.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdDistrictName"]);
                    txt_prdmandalname.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdMandalName"]); 
                    txt_prdvillagename.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdVillageName"]);
                    txt_prdrenewalperiodfrom.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdRenewalperiodFrom"]);
                    txt_prdrenewalperiodto.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdRenewalPeriodTo"]);
                    hf_PrdTradeID.Value = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdTradeID"]);
                    hf_PrdSubTradeID.Value = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdSubTradeID"]);
                    hf_PrdCellTowerID.Value = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdCellTowerID"]);

                    txt_prdtradelicenseno.Text = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdCellTowerID"]);
                    ddl_prddistricts.SelectedValue= Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdDistrictID"]);
                    ddl_tradelicenseyear.SelectedValue = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdTradeLicenseYear"]);         
                    BINDPRDMandals();
                    ddl_prdmandal.SelectedValue = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdMandalID"]);
                    BINDPRDVillages();
                    ddl_prdgrampanchayat.SelectedValue = Convert.ToString(ds_binddata.Tables[0].Rows[0]["PrdVillageID"]);
                    //RenwalCelltowerid,[RenewalID],[CreatedOn],[CreatedIP],[CreatedBy]
                }   
            }     
        }

        #region
        //prdoutput.id = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_number;
        //if (prdoutput.id != "")
        //{
        //    txt_prdcelltowerlice.Text = prdoutput.id;
        //}
        //prdoutput.tradeforName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").tradeForDesc;
        //if (prdoutput.tradeforName != "")
        //{
        //    txt_prdcelltowerfor.Text = prdoutput.tradeforName;
        //}
        //prdoutput.trade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").trade;
        //if (prdoutput.trade != "")
        //{
        //    txt_prdtrade.Text = prdoutput.trade;
        //}
        //prdoutput.subTradeDesc = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").subTradeDesc;
        //if (prdoutput.subTradeDesc != "")
        //{
        //    txt_prdsubtrade.Text = prdoutput.subTradeDesc;
        //}
        //prdoutput.name = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").FOrBOrEName;
        //if (prdoutput.name != "")
        //{
        //    txt_prdnameoffirm.Text = prdoutput.name;
        //}
        //prdoutput.annualLicenseFee = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").annualLicenseFee;
        //if (prdoutput.annualLicenseFee != "")
        //{
        //    txt_prdannuallicensefee.Text = prdoutput.annualLicenseFee;
        //}
        //prdoutput.doorno = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").doorno;
        //prdoutput.locality = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").locality;
        //if (prdoutput.doorno != "" || prdoutput.locality != "")
        //{
        //    txt_prddoorlocality.Text = prdoutput.doorno + "/" + prdoutput.locality;
        //}
        //prdoutput.distName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").distName;
        //if (prdoutput.distName != "")
        //{
        //    txt_prdDistrictname.Text = prdoutput.distName;
        //}
        //prdoutput.mandName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").mandName;
        //if (prdoutput.mandName != "")
        //{
        //    txt_prdmandalname.Text = prdoutput.mandName;
        //}
        //prdoutput.officeName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").officeName;
        //if (prdoutput.officeName != "")
        //{
        //    txt_prdvillagename.Text = prdoutput.officeName;
        //}
        //prdoutput.license_from = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_from;
        //if (prdoutput.license_from != "")
        //{
        //    txt_prdrenewalperiodfrom.Text = prdoutput.license_from;
        //}
        //prdoutput.license_to = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_to;
        //if (prdoutput.license_to != "")
        //{
        //    txt_prdrenewalperiodto.Text = prdoutput.license_to;
        //}
        //prdoutput.distCode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").distCode;
        //prdoutput.mandCode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").mandCode;
        //prdoutput.officeid = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").officeid;
        //prdoutput.tradeforcode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").tradeforcode;
        //prdoutput.subTrade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").subTrade;
        //prdoutput.license_year = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_year;
        //prdoutput.trade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").trade;
        //hf_PrdTradeID.Value = prdoutput.tradeforcode;
        //hf_PrdSubTradeID.Value = prdoutput.subTrade;
        //hf_PrdCellTowerID.Value = prdoutput.trade;

        #endregion

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
    public void BINDPRDDistricts()
    {

        prdoutput.dist_list = PRDSERVICE.getDistrictList("","");
        ddl_prddistricts.DataTextField = "distName";
        ddl_prddistricts.DataValueField = "distCode";
        ddl_prddistricts.DataSource = prdoutput.dist_list;
        ddl_prddistricts.DataBind();
        AddSelect(ddl_prddistricts);
    }

    //public void BINDPRDFINANCIALYEARS()
    //{
    //    prdoutput.finyearList = PRDSERVICE.getFinyear("", "");
    //    //object[] objectArray = new[] { "first", "second", "third", "42" };
    //    string[] stringArray = (string[])prdoutput.finyearList;
    //    //List<string> listfinalyear = stringArray.ToList();

    //    //string[] array = prdoutput.finyearList;
    //    // List<string> list = array.ToList();

    //    //ArrayList resultObjects = ...;
    //    //List<string> results = resultObjects.Cast<string>()
    //    //                                    .ToList();

    //   // int[] arr = { 10, 20, 30, 40, 50 };

    //    // function calling
    //    List<string> lst = get_list(prdoutput.finyearList);

    //    ddl_tradelicenseyear.DataTextField = "item";
    //    ddl_tradelicenseyear.DataValueField = "item";
    //    ddl_tradelicenseyear.DataSource = prdoutput.finyearList;
    //    ddl_tradelicenseyear.DataBind();
    //    AddSelect(ddl_tradelicenseyear);
    //}

    public void BINDPRDFINANCIALYEARS()
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
        ddl_tradelicenseyear.DataTextField = "item";
        ddl_tradelicenseyear.DataValueField = "item";
        ddl_tradelicenseyear.DataSource = lst;
        ddl_tradelicenseyear.DataBind();
        AddSelect(ddl_tradelicenseyear);
    }
    public class listitemddl
    {
        public string item
        {
            get;
            set;
        }
    }

    //static List<int> get_list(int[] arr)
    //{
    //    // List<T>(IEnumerable<T>) 
    //    // Constructor
    //    // is a used to convert a 
    //    // given an integer array 
    //    // to the list

    //    List<int> L = new List<int>(arr);

    //    return L;
    //}

    //static void Main(string[] args)
    //{
    //    // given integer array
    //    int[] arr = { 10, 20, 30, 40, 50 };

    //    // function calling
    //    List<int> lst = get_list(arr);

    //    // printing output
    //    foreach (int i in lst)
    //    {
    //        Console.Write(i + " ");
    //    }

    //}
    public void BINDPRDMandals()
    {
        prdoutput.mand_list = PRDSERVICE.getMandalList(ddl_prddistricts.SelectedValue,"","");
        ddl_prdmandal.DataTextField = "mandName";
        ddl_prdmandal.DataValueField = "mandCode";
        ddl_prdmandal.DataSource = prdoutput.mand_list;
        ddl_prdmandal.DataBind();
        AddSelect(ddl_prdmandal);
    }
    public void BINDPRDVillages()
    {
        prdoutput.village_list = PRDSERVICE.getPanchayatList(ddl_prddistricts.SelectedValue,ddl_prdmandal.SelectedValue,"","");
        ddl_prdgrampanchayat.DataTextField = "officeName";
        ddl_prdgrampanchayat.DataValueField = "officeid";
        ddl_prdgrampanchayat.DataSource = prdoutput.village_list;
        ddl_prdgrampanchayat.DataBind();
        AddSelect(ddl_prdgrampanchayat);
    }
    public void BINDPRDRenwaldetails()
    {
        div_prddetails.Visible = true;
        div_prdsubmit.Visible = true;
        div_prdview.Visible = true;
        txt_prdcelltowerlice.Text = ""; txt_prdcelltowerfor.Text = ""; txt_prdtrade.Text = ""; txt_prdsubtrade.Text = "";
        txt_prdnameoffirm.Text = ""; txt_prdannuallicensefee.Text = ""; txt_prddoorlocality.Text = ""; txt_prdDistrictname.Text = "";
        txt_prdmandalname.Text = ""; txt_prdvillagename.Text = ""; txt_prdrenewalperiodfrom.Text = ""; txt_prdrenewalperiodto.Text = "";
        prdoutput.id = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_number;
        if (prdoutput.id!="")
        {
            txt_prdcelltowerlice.Text = prdoutput.id;
        }
        prdoutput.tradeforName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").tradeForDesc;
        if (prdoutput.tradeforName != "")
        {
            txt_prdcelltowerfor.Text = prdoutput.tradeforName;
        }
        prdoutput.trade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").trade;
        if (prdoutput.trade != "")
        {
            txt_prdtrade.Text = prdoutput.trade;
        }
        prdoutput.subTradeDesc = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").subTradeDesc;
        if (prdoutput.subTradeDesc!="")
        {
            txt_prdsubtrade.Text = prdoutput.subTradeDesc;  
        }
        prdoutput.name = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").FOrBOrEName;
        if (prdoutput.name!="")
        {
            txt_prdnameoffirm.Text = prdoutput.name; 
        }
        prdoutput.annualLicenseFee = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").annualLicenseFee;
        if (prdoutput.annualLicenseFee!="")
        {
            txt_prdannuallicensefee.Text = prdoutput.annualLicenseFee; 
        }
        prdoutput.doorno = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").doorno;
        prdoutput.locality = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").locality;
        if (prdoutput.doorno!="" || prdoutput.locality!="")
        {
            txt_prddoorlocality.Text = prdoutput.doorno+"/"+ prdoutput.locality; 
        }
        prdoutput.distName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").distName;
        if (prdoutput.distName!="")
        {
            txt_prdDistrictname.Text = prdoutput.distName;      
        }
        prdoutput.mandName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").mandName;
        if (prdoutput.mandName!="")
        {
            txt_prdmandalname.Text = prdoutput.mandName;
        }
        prdoutput.officeName = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").officeName;
        if (prdoutput.officeName!="")
        {
            txt_prdvillagename.Text = prdoutput.officeName;
        }
        prdoutput.license_from = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_from;
        if (prdoutput.license_from!="")
        {
            txt_prdrenewalperiodfrom.Text = prdoutput.license_from;
        }
        prdoutput.license_to = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_to;
        if (prdoutput.license_to!="")
        {
            txt_prdrenewalperiodto.Text = prdoutput.license_to;
        }


       
        prdoutput.distCode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue,"","").distCode;    
        prdoutput.mandCode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").mandCode;
        prdoutput.officeid = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").officeid;   
        prdoutput.tradeforcode = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").tradeforcode;  
        prdoutput.subTrade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").subTrade;  
        prdoutput.license_year = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").license_year;
        prdoutput.trade = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").trade;
        hf_PrdTradeID.Value = prdoutput.tradeforcode;
        hf_PrdSubTradeID.Value = prdoutput.subTrade;
        hf_PrdCellTowerID.Value = prdoutput.trade;


        // prdoutput.tradefor = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").tr;

        //prdoutput. = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").gpCode;
        //prdoutput. = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").gpName;
        //prdoutput. = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").renewal_status;
        //prdoutput. = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").resp_msg;
        //prdoutput. = PRDSERVICE.getRenewalTradeDetails(ddl_prdgrampanchayat.SelectedValue, txt_prdtradelicenseno.Text, ddl_tradelicenseyear.SelectedValue, "", "").status_code;
    }
    protected void ddl_prddistricts_SelectedIndexChanged(object sender, EventArgs e)
    {
        BINDPRDMandals();
        BINDPRDVillages();
    }
    protected void ddl_prdmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        BINDPRDVillages();
    }
    protected void btn_getrenewaldetails_Click(object sender, EventArgs e)
    {
        if (ddl_prddistricts.SelectedIndex <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select District.')", true);
        }
        else
        {
            if (ddl_prdmandal.SelectedIndex <= 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Mandal.')", true);
            }
            else
            {
                if (ddl_prdgrampanchayat.SelectedIndex <= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Gram Panchayat.')", true);
                }
                else
                {
                    if (ddl_tradelicenseyear.SelectedIndex <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Finanical Year.')", true);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_prdtradelicenseno.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserted Successfully.')", true);
                        }
                        else
                        {
                            BINDPRDRenwaldetails();
                        }
                    }
                }
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
        else
        {
            prdmobiletowerrenewalobj obj_celltower = new prdmobiletowerrenewalobj();
            obj_celltower.tradelicenseno = txt_prdcelltowerlice.Text;
            obj_celltower.PrdDistrictName = txt_prdDistrictname.Text;       
            obj_celltower.PrdMandalName = txt_prdmandalname.Text;
            obj_celltower.PrdVillageName = txt_prdvillagename.Text;
            obj_celltower.PrdTradeName = txt_prdtrade.Text;
            obj_celltower.PrdSubTradeName = txt_prdsubtrade.Text;
            obj_celltower.PrdCellTowerFor = txt_prdcelltowerfor.Text;
            obj_celltower.PrdAnuualLicenseFee = Convert.ToDecimal(txt_prdannuallicensefee.Text);
            obj_celltower.PrdNameoffirm_shops = txt_prdnameoffirm.Text;
            obj_celltower.prdDoorNo_locality = txt_prddoorlocality.Text;
            obj_celltower.PrdRenewalperiodFrom = txt_prdrenewalperiodfrom.Text;
            obj_celltower.PrdRenewalPeriodTo = txt_prdrenewalperiodto.Text;

            obj_celltower.PrdDistrictID = Convert.ToString(ddl_prddistricts.SelectedValue);
            obj_celltower.PrdMandalID = Convert.ToString(ddl_prdmandal.SelectedValue);
            obj_celltower.PrdVillageID = Convert.ToString(ddl_prdgrampanchayat.SelectedValue);
            obj_celltower.PrdTradeLicenseYear = Convert.ToString(ddl_tradelicenseyear.SelectedValue);
            obj_celltower.PrdTradeLicenseNumber = Convert.ToString(txt_prdtradelicenseno.Text);
            obj_celltower.PrdTradeID = Convert.ToString(hf_PrdTradeID.Value);
            obj_celltower.PrdSubTradeID = Convert.ToString(hf_PrdSubTradeID.Value);
            obj_celltower.PrdCellTowerID = Convert.ToString(hf_PrdCellTowerID.Value);
            obj_celltower.RenewalID = Convert.ToString(Session["Applid"]);
            obj_celltower.CreatedIP = Request.ServerVariables["Remote_Addr"];
            obj_celltower.CreatedBy = Convert.ToString(Session["uid"]);
            // obj_celltower.RenwalCelltowerid = "";
            string RenwalCelltowerid = obj_tower.Insertupdatemobiletowerrenewal(obj_celltower);
            if(!string.IsNullOrEmpty(RenwalCelltowerid))
            {
                if (Convert.ToInt16(RenwalCelltowerid)>0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inserted Successfully.')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insertion Failed.')", true);
                }    
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Insertion Failed.')", true);
            }
        }
    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";
 
        if (txt_prdcelltowerlice.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter block number \\n";
            slno = slno + 1;
        }
        if (txt_prdcelltowerfor.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter site area  in Sqm As Per Document \\n";
            slno = slno + 1;
        }
        if (txt_prdtrade.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter site area  in Sqm As Per Submitted Plan \\n";
            slno = slno + 1;
        }
        if (txt_prdsubtrade.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter road widening area \\n";
            slno = slno + 1;
        }
        if (txt_prdnameoffirm.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter net area \\n";
            slno = slno + 1;
        }
        if (txt_prdannuallicensefee.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter bilding permission no. \\n";
            slno = slno + 1;
        }
        if (txt_prddoorlocality.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate no. \\n";
            slno = slno + 1;
        }
        if (txt_prdDistrictname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter bilding permission date. \\n";
            slno = slno + 1;
        }
        if (txt_prdmandalname.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate date. \\n";
            slno = slno + 1;
        }
        if (txt_prdvillagename.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate date. \\n";
            slno = slno + 1;
        }
        if (txt_prdrenewalperiodfrom.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate date. \\n";
            slno = slno + 1;
        }
        if (txt_prdrenewalperiodto.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter occupancy certificate date. \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {

    }
    protected void Btnprevious_Click(object sender, EventArgs e)
    {
        Response.Redirect("Advertisement_renewal.aspx?intApplicationId=" + Session["Applid"].ToString() + "&next=" + "P");// + hdfID.Value
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
       // Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Session["Applid"].ToString().Trim());
        Response.Redirect("frmDepartmentRenewalPaymentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
    }

  

}