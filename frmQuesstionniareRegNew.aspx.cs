using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID
public partial class TSTBDCReg1 : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    decimal TotalFee = Convert.ToDecimal("0");
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //if (Session.Count <= 0)
        //{
        //    Response.Redirect("~/Index.aspx");
        //}

        if (!IsPostBack)
        {


            //DataSet dscheck = new DataSet();
            //dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            //if (dscheck.Tables[0].Rows.Count > 0)
            //{
            //    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            //}
            //else
            //{
            //    Session["Applid"] = "0";
            //}

            //DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque9(Session["Applid"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            //    string res = Gen.RetriveStatus(Session["Applid"].ToString());
            //    ////string res = Gen.RetriveStatus("1002");


            //    if (res == "3" || Convert.ToInt32(res) >= 3)
            //    {
            //        ResetFormControl(this);
            //        BtnClear.Visible = false;
            //      //  BtnSave.Visible = false;
            //        BtnSave1.Visible = false;
            //    }

            //}



        }




        if (!IsPostBack)
        {
            DataSet dsd = new DataSet();
            dsd = Gen.GetDistrictsWithoutHYD();
            ddlProp_intDistrictid.DataSource = dsd.Tables[0];
            ddlProp_intDistrictid.DataValueField = "District_Id";
            ddlProp_intDistrictid.DataTextField = "District_Name";
            ddlProp_intDistrictid.DataBind();
            ddlProp_intDistrictid.Items.Insert(0, "--District--");

            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            ddlintLineofActivity.Items.Insert(0, "--Select--");
            //Session["Applid"] = "0";
            ddlLoc_of_unit.Items.Clear();
            ddlLoc_of_unit.Items.Insert(0, "--Select--");
            //BtnSave.Visible = false;
            
            //fillDetails();
            hdnfocus.Value = ddlConst_of_unit.ClientID;
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            
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
    //public void fillDetails()
    //{

    //     DataSet dscheck = new DataSet();
    //        dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
    //        if (dscheck.Tables[0].Rows.Count > 0)
    //        {
    //            ddlConst_of_unit.SelectedValue = ddlConst_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim()).Value;
    //            ddlSector_Ent.SelectedValue = ddlSector_Ent.Items.FindByValue(dscheck.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim()).Value;
    //            TxtTot_Extent.Text = dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();



    //            ddlProp_intDistrictid.SelectedValue = dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim();
    //            if (ddlProp_intDistrictid.SelectedIndex == 0)
    //            {
    //                ddlProp_intMandalid.Items.Clear();
    //                ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
    //                ChkWater_reg_from.Items.Clear();
    //                ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
    //                ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
    //                ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
    //            }
    //            else
    //            {
    //                ddlProp_intMandalid.Items.Clear();
    //                DataSet dsm = new DataSet();
    //                dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
    //                if (dsm.Tables[0].Rows.Count > 0)
    //                {
    //                    ddlProp_intMandalid.DataSource = dsm.Tables[0];
    //                    ddlProp_intMandalid.DataValueField = "Mandal_Id";
    //                    ddlProp_intMandalid.DataTextField = "Manda_lName";
    //                    ddlProp_intMandalid.DataBind();
    //                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
    //                }
    //                else
    //                {
    //                    ddlProp_intMandalid.Items.Clear();
    //                    ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
    //                }



    //            }
    //            ddlProp_intMandalid.SelectedValue =ddlProp_intMandalid.Items.FindByValue( dscheck.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
    //            if (ddlProp_intMandalid.SelectedIndex == 0)
    //            {

    //                ddlProp_intVillageid.Items.Clear();
    //                ddlProp_intVillageid.Items.Insert(0, "--Village--");
    //            }
    //            else
    //            {
    //                ddlProp_intVillageid.Items.Clear();
    //                DataSet dsv = new DataSet();
    //                dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
    //                if (dsv.Tables[0].Rows.Count > 0)
    //                {
    //                    ddlProp_intVillageid.DataSource = dsv.Tables[0];
    //                    ddlProp_intVillageid.DataValueField = "Village_Id";
    //                    ddlProp_intVillageid.DataTextField = "Village_Name";
    //                    ddlProp_intVillageid.DataBind();
    //                    ddlProp_intVillageid.Items.Insert(0, "--Village--");
    //                }
    //                else
    //                {
    //                    ddlProp_intVillageid.Items.Clear();
    //                    ddlProp_intVillageid.Items.Insert(0, "--Village--");
    //                }

    //                DataSet dsss = new DataSet();
    //                dsss = Gen.GetShowLOcationofUnit(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);
    //                if (dsss.Tables[0].Rows.Count > 0)
    //                {
    //                    if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
    //                    {
    //                        ddlLoc_of_unit.Items.Clear();
    //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
    //                        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));

    //                        ChkWater_reg_from.Items[1].Selected = true;
    //                        ChkWater_reg_from.Items[1].Enabled = true;





    //                    }
    //                    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
    //                    {
    //                        ddlLoc_of_unit.Items.Clear();
    //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
    //                        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
    //                        ChkWater_reg_from.Items[1].Selected = false;
    //                        ChkWater_reg_from.Items[1].Enabled = false;



    //                    }
    //                    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
    //                    {
    //                        ddlLoc_of_unit.Items.Clear();
    //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
    //                        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
    //                        ChkWater_reg_from.Items[1].Selected = false;
    //                        ChkWater_reg_from.Items[1].Enabled = false;



    //                    }
    //                    else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
    //                    {
    //                        ddlLoc_of_unit.Items.Clear();
    //                        ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                        ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
    //                        ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
    //                        ChkWater_reg_from.Items[1].Selected = false;
    //                        ChkWater_reg_from.Items[1].Enabled = false;



    //                    }
    //                }
    //                else
    //                {
    //                    ddlLoc_of_unit.Items.Clear();
    //                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
    //                }
    //            }
    //            ddlProp_intVillageid.SelectedValue =ddlProp_intVillageid.Items.FindByValue( dscheck.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
    //            TxtProp_Emp.Text = dscheck.Tables[0].Rows[0]["Prop_Emp"].ToString().Trim();
    //            TxtVal_Land.Text = dscheck.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
    //            TxtVal_Build.Text = dscheck.Tables[0].Rows[0]["Val_Build"].ToString().Trim();
    //            TxtVal_Plant.Text = dscheck.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();

    //            TxtTot_PrjCost.Text = dscheck.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();

    //            HdfLblEnt_is.Value = dscheck.Tables[0].Rows[0]["Ent_is"].ToString().Trim();
    //            CalculatationEnterprisePrjCost();
    //            CalculatationEnterprise();
    //            ddlintLineofActivity.SelectedValue =ddlintLineofActivity.Items.FindByValue( dscheck.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;



    //            if (ddlintLineofActivity.SelectedIndex == 0)
    //            {
    //                HdfLblPol_Category.Value = "";
    //                LblPol_Category.Text = "";
    //                trFallinPolution.Visible = false;
    //            }
    //            else
    //            {
    //                DataSet dsct = new DataSet();
    //                dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
    //                if (dsct.Tables[0].Rows.Count > 0)
    //                {

    //                    if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
    //                    {
    //                        HdfLblPol_Category.Value = "Orange";
    //                        LblPol_Category.Text = "<font color=Orange>Orange</font>";
    //                        trFallinPolution.Visible = false;

    //                    }
    //                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
    //                    {
    //                        HdfLblPol_Category.Value = "Red";
    //                        LblPol_Category.Text = "<font color=Red>Red</font>";
    //                        trFallinPolution.Visible = false;
    //                    }
    //                    else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
    //                    {
    //                        HdfLblPol_Category.Value = "Green";
    //                        trFallinPolution.Visible = true;
    //                        LblPol_Category.Text = "<font color=Green>Green</font>";
    //                    }
    //                }
    //                else
    //                {
    //                    HdfLblPol_Category.Value = "";
    //                    LblPol_Category.Text = "";
    //                    trFallinPolution.Visible = false;
    //                }
    //            }

    //            RdPol_Indus.SelectedValue = RdPol_Indus.Items.FindByValue(dscheck.Tables[0].Rows[0]["Pol_Indus"].ToString().Trim()).Value;
                
    //          //  HdfLblPol_Category.Value=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();
    //            ddlPower_Req.SelectedValue = ddlPower_Req.Items.FindByValue(dscheck.Tables[0].Rows[0]["Power_Req"].ToString().Trim()).Value;
    //            ddlLoc_of_unit.SelectedValue = ddlLoc_of_unit.Items.FindByValue(dscheck.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim()).Value;
    //            TxtWater_req_Perday.Text = dscheck.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
    //            if (dscheck.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "")
    //            {
    //                ChkWater_reg_from.Items[0].Selected = true;
    //            }
    //            if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "")
    //            {
    //                ChkWater_reg_from.Items[1].Selected = true;
    //            }
    //            if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "")
    //            {
    //                ChkWater_reg_from.Items[2].Selected = true;
    //            }
    //      //  chkwatera=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
    //          //  chkwaterb=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim(); 
    //          //  chkwaterc=dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();

    //            RdDo_Store_Kerosine.SelectedValue = RdDo_Store_Kerosine.Items.FindByValue(dscheck.Tables[0].Rows[0]["Do_Store_Kerosine"].ToString().Trim()).Value;

    //            RdGen_Reqired.SelectedValue = RdGen_Reqired.Items.FindByValue(dscheck.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim()).Value;
    //            TxtHight_Build.Text = dscheck.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();
    //            TxtBuilt_up_Area.Text = dscheck.Tables[0].Rows[0]["Built_up_Area"].ToString().Trim();
    //            RdFall_in_Municipal.SelectedValue =  RdFall_in_Municipal.Items.FindByValue( dscheck.Tables[0].Rows[0]["Fall_in_Municipal"].ToString().Trim()).Value;
    //            RdProp_Site.SelectedValue =RdProp_Site.Items.FindByValue( dscheck.Tables[0].Rows[0]["Prop_Site"].ToString().Trim()).Value;
    //            if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
    //            {
    //                trtrees.Visible = true;
    //                tr4.Visible = true;
    //                Txt_NoofTrees.Text = "";
    //                if (dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim() != "")
    //                {
    //                    RdbExecpted.SelectedValue = RdbExecpted.Items.FindByValue(dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim()).Value;
    //                }
    //            }
    //            else
    //            {
    //                Txt_NoofTrees.Text = "";
    //                trtrees.Visible = false;
    //                tr4.Visible = false;
    //                if (dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim() != "")
    //                {
    //                    RdbExecpted.SelectedValue = RdbExecpted.Items.FindByValue(dscheck.Tables[0].Rows[0]["NonExmTrees"].ToString().Trim()).Value;
    //                }
    //            }

    //            Txt_NoofTrees.Text = dscheck.Tables[0].Rows[0]["NoofTrees"].ToString().Trim();
    //            TxtnameofUnit.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
    //            if(dscheck.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim() !="")
    //                ddlAppl_Type.SelectedValue = ddlAppl_Type.Items.FindByValue( dscheck.Tables[0].Rows[0]["Appl_Type"].ToString().Trim()).Value;
  
    //            //if (dscheck.Tables[1].Rows.Count > 0)
    //            //{
    //            //    grdDetails.DataSource = dscheck.Tables[1];
    //            //    grdDetails.DataBind();
    //            //}
    //            Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
    //            BtnClear.Visible = false;
    //            if (ddlLoc_of_unit.SelectedIndex != 0)
    //            {
    //                if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
    //                {
    //                    trApplType.Visible = true;
    //                }
    //                else
    //                {
    //                    trApplType.Visible = false;
    //                }
    //            }
    //            else
    //            {
    //                trApplType.Visible = false;
    //            }
    //            CalcFees();
    //        }
    //        else
    //        {
    //        }

    //     }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

       // BtnSave.Visible = true;
        CalcFees();
       
    }

    public void CalcFees()
    {

        try
        {
           
            DataSet dss = new DataSet();
            string Enterpriseid = "0";
            dss = Gen.GetEnterprisebyID(HdfLblEnt_is.Value);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Enterpriseid = dss.Tables[0].Rows[0]["intEnterpriseType"].ToString();
            }

            string SearchVerfi = "";
            DataSet dsa = new DataSet();
            DataSet dsv = new DataSet();
            dsv = null;

            dsv = Gen.GetShowApprovalandFees("0", Enterpriseid);
            DataSet dsMunicial = new DataSet();
            if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "R")
            {

                dsMunicial = Gen.GetShowApprovalandFees("2", Enterpriseid);
                dsv.Tables[0].Merge(dsMunicial.Tables[0]);

            }
            DataSet dsv1 = new DataSet();
            //if (ddlPower_Req.SelectedIndex == 1)
            //{

            //    dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv1.Tables[0]);
            //}
            //else 

            if (ddlPower_Req.SelectedIndex == 2)
            {

                dsv1 = Gen.GetShowApprovalandFees("5", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);
            }
            else if (ddlPower_Req.SelectedIndex == 3)
            {

                dsv1 = Gen.GetShowApprovalandFees("21", Enterpriseid);
                dsv.Tables[0].Merge(dsv1.Tables[0]);

            }
            DataSet dsv2 = new DataSet();
            if (ddlProp_intDistrictid.SelectedValue == "1" || ddlProp_intDistrictid.SelectedValue == "2" || ddlProp_intDistrictid.SelectedValue == "3" || ddlProp_intDistrictid.SelectedValue == "9" || ddlProp_intDistrictid.SelectedValue == "10")
            {

                dsv2 = Gen.GetShowApprovalandFees("4", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);
            }
            else if (ddlProp_intDistrictid.SelectedValue == "4" || ddlProp_intDistrictid.SelectedValue == "5" || ddlProp_intDistrictid.SelectedValue == "6" || ddlProp_intDistrictid.SelectedValue == "7" || ddlProp_intDistrictid.SelectedValue == "8")
            {
                dsv2 = Gen.GetShowApprovalandFees("25", Enterpriseid);
                dsv.Tables[0].Merge(dsv2.Tables[0]);
            }






            DataSet dsv3 = new DataSet();

            if (HdfLblPol_Category.Value == "Red")
            {
                dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            else if (HdfLblPol_Category.Value == "Green")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text, ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);


                    }
                }
                else
                {


                    dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);


                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                ////if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                ////{

                ////}
                ////else
                ////{
                ////    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                ////    {

                ////        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                ////        dsv.Tables[0].Merge(dsv3.Tables[0]);

                ////    }
                ////    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                ////    {
                ////        if (HdfLblEnt_is.Value == "Green")
                ////        {
                ////            dsv3 = Gen.GetShowApprovalandFeesPCB("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                ////            dsv.Tables[0].Merge(dsv3.Tables[0]);
                ////        }

                ////    }
                ////    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                ////    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                ////}
            }
            else if (HdfLblPol_Category.Value == "Orange")
            {
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (RdPol_Indus.SelectedValue.ToString().Trim() == "Y")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);

                    }
                    else if (RdPol_Indus.SelectedValue.ToString().Trim() == "N")
                    {

                        dsv3 = Gen.GetShowApprovalandFeesPCBDIC("3", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text,ddlProp_intDistrictid.SelectedValue);
                        dsv.Tables[0].Merge(dsv3.Tables[0]);


                    }
                }
                else
                {


                    dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);


                    //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtVal_Plant.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                //dsv3 = Gen.GetShowApprovalandFeesPCB("20", Enterpriseid, HdfLblPol_Category.Value, RdGen_Reqired.SelectedValue, TxtTot_PrjCost.Text);
                //dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            if (ChkWater_reg_from.Items[0].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesGroundWater("9", Enterpriseid, TxtWater_req_Perday.Text, TxtTot_Extent.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[1].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFeesHWS("10", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (ChkWater_reg_from.Items[2].Selected == true)
            {
                dsv3 = Gen.GetShowApprovalandFees("11", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (RdDo_Store_Kerosine.SelectedValue == "Y")
            {
                dsv3 = Gen.GetShowApprovalandFeesDistincts("32", Enterpriseid, ddlProp_intDistrictid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }
            if (TxtHight_Build.Text.Trim() == "")
            {
                TxtHight_Build.Text = "0";
            }
            if (Convert.ToDecimal(TxtHight_Build.Text.Trim()) >= Convert.ToDecimal("15"))
            {
                dsv3 = Gen.GetShowApprovalandFeesFire("8", Enterpriseid, TxtBuilt_up_Area.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            if (RdProp_Site.SelectedValue.ToString() == "Y")
            {
                //dsv3 = Gen.GetShowApprovalandFees("28", Enterpriseid);

                dsv3 = Gen.GetShowApprovalandFeesEnterPriseAmount("28", Enterpriseid, TxtVal_Plant.Text, TxtTot_PrjCost.Text, Txt_NoofTrees.Text);
                dsv.Tables[0].Merge(dsv3.Tables[0]);
            }

            //if (ddlLoc_of_unit.SelectedValue == "1")
            //{
            //    dsv3 = Gen.GetShowApprovalandFees("6", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //    dsv3 = Gen.GetShowApprovalandFees("29", Enterpriseid);
            //    dsv.Tables[0].Merge(dsv3.Tables[0]);
            //}

            if (ddlLoc_of_unit.SelectedValue == "2")
            {
                dsv3 = Gen.GetShowApprovalandFeesDTCP("7", Enterpriseid, RdFall_in_Municipal.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "3")
            {
                dsv3 = Gen.GetShowApprovalandFees("31", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "4")
            {
                dsv3 = Gen.GetShowApprovalandFees("30", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            if (ddlLoc_of_unit.SelectedValue == "5")
            {
                dsv3 = Gen.GetShowApprovalandFees("38", Enterpriseid);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            DataSet dsv4 = new DataSet();
            dsv4 = Gen.GetShowApprovalandFeesEnterPriseAmount("33", Enterpriseid, TxtVal_Plant.Text, TxtTot_PrjCost.Text, "0");
            dsv.Tables[0].Merge(dsv4.Tables[0]);
            if (ddlLoc_of_unit.SelectedValue == "1")
            {
                if (ddlAppl_Type.SelectedValue == "1")
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                }
                else if (ddlAppl_Type.SelectedValue == "2")
                {

                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuilding("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);

                }
                else
                {
                    dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("6", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    dsv.Tables[0].Merge(dsv3.Tables[0]);
                    //dsv3 = Gen.GetShowApprovalandFeesHMDACLUandBuildingBoth("35", Enterpriseid, ddlAppl_Type.SelectedValue, TxtTot_Extent.Text, TxtHight_Build.Text);
                    //dsv.Tables[0].Merge(dsv3.Tables[0]);
                }

            }

            if (ddlLoc_of_unit.SelectedValue != "4")
            {
                dsv3 = Gen.GetShowApprovalandFeesNALA("34", Enterpriseid, ddlProp_intDistrictid.SelectedValue, null, null, ddlProp_intMandalid.SelectedValue);
                dsv.Tables[0].Merge(dsv3.Tables[0]);

            }
            //dsv3 = Gen.GetShowApprovalandFees("37", Enterpriseid);
            //dsv.Tables[0].Merge(dsv3.Tables[0]);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dsv.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }

            //if (dsv.Tables[0].Rows.Count > 0)
            //{
            //    grdDetails.DataSource = dsv.Tables[0];
            //    grdDetails.DataBind();
            //}
            //else
            //{
            //    grdDetails.DataSource = null;
            //    grdDetails.DataBind();
            //}
            //int s = Gen.insertQuetieneroes("0", ddlConst_of_unit.SelectedValue, ddlSector_Ent.SelectedValue, TxtTot_Extent.Text, ddlProp_intDistrictid.SelectedValue,
            //           ddlProp_intMandalid.SelectedValue, ddlProp_intVillageid.SelectedValue, TxtProp_Emp.Text, TxtVal_Land.Text, TxtVal_Build.Text, TxtVal_Plant.Text, TxtTot_PrjCost.Text, HdfLblEnt_is.Value, ddlintLineofActivity.SelectedValue, RdPol_Indus.SelectedValue, HdfLblPol_Category.Value, ddlPower_Req.SelectedValue, ddlLoc_of_unit.SelectedValue, TxtWater_req_Perday.Text,
            //           ChkWater_reg_from.SelectedItem.Text, ChkWater_reg_from.SelectedItem.Text, ChkWater_reg_from.SelectedItem.Text, RdDo_Store_Kerosine.SelectedValue, RdGen_Reqired.SelectedValue, TxtHight_Build.Text, TxtBuilt_up_Area.Text, RdFall_in_Municipal.SelectedValue, RdProp_Site.SelectedValue, "1", "1000", "1000");

            //if (s >= 0)
            //{
            //    success.Visible = true;
            //    Failure.Visible = false;
            //    lblmsg.Text = "Questionnaire - Consent for Establishment is Succesfully Saved";
            //    cmf.ResetFormControl(this);
            //    Session["Applid"] = s.ToString();
            //}
            //else
            //{
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    lblmsg0.Text = "Questionnaire - Consent for Establishment is Registration Failed";
            //}
        }
        catch (Exception ex)
        {


        }
        finally
        {
        }
    
    }
    void clear()
    {

        
       
       
    }


   
      
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        cmf.ResetFormControl(this);
        grdDetails.DataSource = null;
        grdDetails.DataBind();
        HdfLblEnt_is.Value = "";
        HdfLblPol_Category.Value = "";
        LblEnt_is.Text = "";
        LblPol_Category.Text = "";
        //BtnSave.Visible = false;
        Txt_NoofTrees.Text = "";
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
   
    protected void ddlState_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlCounties_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {
            
        try
        {

           

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {

        }
    
    }

    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
    protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
           
        }
        catch (Exception ex)
        {
          

        }
        finally
        {
        }
    }



    protected void GetNewRectoInsertdr()
    {
        
    }
    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intDistrictid.SelectedIndex == 0)
        {
            ddlProp_intMandalid.Items.Clear();
            ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
            ChkWater_reg_from.Items.Clear();
            ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
            ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
            ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
        }
        else
        {
            ddlProp_intMandalid.Items.Clear();
          DataSet dsm=new DataSet();
          dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
          if (dsm.Tables[0].Rows.Count > 0)
          {
              ddlProp_intMandalid.DataSource = dsm.Tables[0];
              ddlProp_intMandalid.DataValueField = "Mandal_Id";
              ddlProp_intMandalid.DataTextField = "Manda_lName";
              ddlProp_intMandalid.DataBind();
              ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
          }
          else 
          {
              ddlProp_intMandalid.Items.Clear();
              ddlProp_intMandalid.Items.Insert(0, "--Mandal--");
          }


        
        }
        hdnfocus.Value = ddlProp_intDistrictid.ClientID;
     //   ddlProp_intDistrictid.Focus();
    }
    protected void ddlProp_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intMandalid.SelectedIndex == 0)
        {

            ddlProp_intVillageid.Items.Clear();
            ddlProp_intVillageid.Items.Insert(0, "--Village--");
        }
        else
        {
            ddlProp_intVillageid.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlProp_intMandalid.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlProp_intVillageid.DataSource = dsv.Tables[0];
                ddlProp_intVillageid.DataValueField = "Village_Id";
                ddlProp_intVillageid.DataTextField = "Village_Name";
                ddlProp_intVillageid.DataBind();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlProp_intVillageid.Items.Clear();
                ddlProp_intVillageid.Items.Insert(0, "--Village--");
            }

            DataSet dsss = new DataSet();
            dsss = Gen.GetShowLOcationofUnit(ddlProp_intDistrictid.SelectedValue, ddlProp_intMandalid.SelectedValue);
            if (dsss.Tables[0].Rows.Count > 0)
            {
                if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "1")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of HMDA (HMDA list of villages link)", "1"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    
                        ChkWater_reg_from.Items[1].Selected = true;
                        ChkWater_reg_from.Items[1].Enabled = true;
                    
                      


                    
                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "2")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of DT&CP", "2"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    ChkWater_reg_from.Items[1].Selected = false;
                    ChkWater_reg_from.Items[1].Enabled = false;
                  

                  
                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "3")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of KUDA", "3"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    ChkWater_reg_from.Items[1].Selected = false;
                    ChkWater_reg_from.Items[1].Enabled = false;
                  

                    
                }
                else if (dsss.Tables[0].Rows[0][0].ToString().Trim() == "5")
                {
                    ddlLoc_of_unit.Items.Clear();
                    ddlLoc_of_unit.Items.Insert(0, "--Select--");
                    ddlLoc_of_unit.Items.Insert(1, new ListItem("Within the purview of GM DIC,HYD", "5"));
                    ddlLoc_of_unit.Items.Insert(2, new ListItem("IALA (TSIIC)", "4"));
                    ChkWater_reg_from.Items[1].Selected = false;
                    ChkWater_reg_from.Items[1].Enabled = false;



                }
            }
            else
            {
                ddlLoc_of_unit.Items.Clear();
                ddlLoc_of_unit.Items.Insert(0, "--Select--");
            }
        }
       // ddlProp_intMandalid.Focus();

        hdnfocus.Value = ddlProp_intMandalid.ClientID;
    }
    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintLineofActivity.SelectedIndex == 0)
        {
            HdfLblPol_Category.Value = "";
            LblPol_Category.Text = "";
            //   trFallinPolution.Visible = false;
            RdPol_Indus.Enabled = false;
        }
        else
        {
            DataSet dsct = new DataSet();
            dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
            if (dsct.Tables[0].Rows.Count > 0)
            {

                if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                {
                    HdfLblPol_Category.Value = "Orange";
                    LblPol_Category.Text = "<font color=Orange>Orange</font>";
                    if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                    {
                        //   trFallinPolution.Visible = true;
                    }
                    else
                    {
                        //     trFallinPolution.Visible = false;
                    }

                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                {
                    HdfLblPol_Category.Value = "Red";
                    LblPol_Category.Text = "<font color=Red>Red</font>";
                    //  trFallinPolution.Visible = false;
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                {
                    HdfLblPol_Category.Value = "Green";
                    // trFallinPolution.Visible = true;
                    LblPol_Category.Text = "<font color=Green>Green</font>";
                }
                else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                {
                    HdfLblPol_Category.Value = "White";
                    //   trFallinPolution.Visible = true;
                    LblPol_Category.Text = "White";
                }
                if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                {
                    if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
                    {
                        RdPol_Indus.SelectedValue = "Y";

                    }
                    else
                    {
                        RdPol_Indus.SelectedValue = "N";

                    }
                }
                else
                { RdPol_Indus.SelectedValue = "Y"; }
                RdPol_Indus.Enabled = false;
            }

            else
            {
                HdfLblPol_Category.Value = "";
                LblPol_Category.Text = "";
                RdPol_Indus.Enabled = false;
                trFallinPolution.Visible = false;
            }

        }
        hdnfocus.Value =ddlintLineofActivity.ClientID;
    }
    protected void TxtVal_Plant_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        hdnfocus.Value = TxtVal_Plant.ClientID;
    }

     public void CalculatationEnterprisePrjCost()
    {
        if (ddlSector_Ent.SelectedIndex != 0)
        {
            if (TxtVal_Build.Text.Trim() == "")
            {
                TxtVal_Build.Text = "0";
            }

            if (TxtVal_Land.Text.Trim() == "")
            {
                TxtVal_Land.Text = "0";
            }

            if (TxtVal_Plant.Text.Trim() == "")
            {
                TxtVal_Plant.Text = "0";
            }
            TxtTot_PrjCost.Text = Convert.ToString((Convert.ToDecimal(TxtVal_Build.Text) + Convert.ToDecimal(TxtVal_Land.Text) + Convert.ToDecimal(TxtVal_Plant.Text)));
            lblmsg.Text = "";
        }
        else
        {
            TxtTot_PrjCost.Text = "0";
            lblmsg.Text = "Please Select Sector of Enterprise";
        }
    }

    public void CalculatationEnterprise()
    {
        if (ddlSector_Ent.SelectedIndex != 0)
        {

            if (TxtProp_Emp.Text.Trim() == "")
            {
                TxtProp_Emp.Text = "0";
            }

            lblmsg.Text = "";
            DataSet dsEnter = new DataSet();
            if (ddlSector_Ent.SelectedValue == "2")
            {
                if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
                    if (dsEnter.Tables[0].Rows.Count > 0)
                    {
                        HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                    }
                    else
                    {
                        HdfLblEnt_is.Value = "";
                        LblEnt_is.Text = "";
                    }
                }
            }
            else if (ddlSector_Ent.SelectedValue == "1")
            {
                if (Convert.ToDecimal(TxtTot_PrjCost.Text) >= Convert.ToDecimal("20000"))
                {
                    HdfLblEnt_is.Value = "Mega";

                    LblEnt_is.Text = "Mega";
                }
                else
                {
                    dsEnter = Gen.GetEnterPriseIs(TxtVal_Plant.Text, ddlSector_Ent.SelectedValue);
                    if (dsEnter.Tables[0].Rows.Count > 0)
                    {
                        HdfLblEnt_is.Value = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                        LblEnt_is.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                    }
                    else
                    {
                        HdfLblEnt_is.Value = "";
                        LblEnt_is.Text = "";
                    }
                }
            }
            else
            {
                HdfLblEnt_is.Value = "";
                LblEnt_is.Text = "";
            }

            if (Convert.ToDecimal(TxtProp_Emp.Text) >= Convert.ToDecimal("1000"))
            { HdfLblEnt_is.Value = "Mega";
            LblEnt_is.Text = "Mega";
            }
            success.Visible = false;
        }
        else
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
            success.Visible = true;
            lblmsg.Text = "Please Select Sector of Enterprise";
        }


        if (ddlintLineofActivity.SelectedIndex == 0)
                {
                    HdfLblPol_Category.Value = "";
                    LblPol_Category.Text = "";
                 //   trFallinPolution.Visible = false;
                    RdPol_Indus.Enabled = false;
                }
                else
                {
                    DataSet dsct = new DataSet();
                    dsct = Gen.GetCategoryType(ddlintLineofActivity.SelectedValue);
                    if (dsct.Tables[0].Rows.Count > 0)
                    {

                        if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "O")
                        {
                            HdfLblPol_Category.Value = "Orange";
                            LblPol_Category.Text = "<font color=Orange>Orange</font>";
                            if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                            {
                                //   trFallinPolution.Visible = true;
                            }
                            else
                            {
                                //     trFallinPolution.Visible = false;
                            }

                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "R")
                        {
                            HdfLblPol_Category.Value = "Red";
                            LblPol_Category.Text = "<font color=Red>Red</font>";
                            //  trFallinPolution.Visible = false;
                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "G")
                        {
                            HdfLblPol_Category.Value = "Green";
                            // trFallinPolution.Visible = true;
                            LblPol_Category.Text = "<font color=Green>Green</font>";
                        }
                        else if (dsct.Tables[0].Rows[0]["LineofActivity_Type"].ToString().Trim() == "W")
                        {
                            HdfLblPol_Category.Value = "White";
                            //   trFallinPolution.Visible = true;
                            LblPol_Category.Text = "White";
                        }
                        if (HdfLblEnt_is.Value == "Small" || HdfLblEnt_is.Value == "Micro")
                        {
                            if (dsct.Tables[0].Rows[0]["Flag"].ToString().Trim() == "Y")
                            {
                                RdPol_Indus.SelectedValue = "Y";

                            }
                            else
                            {
                                RdPol_Indus.SelectedValue = "N";

                            }
                        }
                        else
                        { RdPol_Indus.SelectedValue = "Y"; }
                        RdPol_Indus.Enabled = false;
                    }

                    else
                    {
                        HdfLblPol_Category.Value = "";
                        LblPol_Category.Text = "";
                        RdPol_Indus.Enabled = false;
                        trFallinPolution.Visible = false;
                    }

                }
       

        if (TxtVal_Plant.Text == "" || TxtVal_Plant.Text == "0")
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }
    }
    protected void TxtVal_Land_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }

        hdnfocus.Value =TxtVal_Build.ClientID;
    }
    protected void TxtVal_Build_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }
        hdnfocus.Value =TxtVal_Plant.ClientID;
    }
    protected void ddlSector_Ent_SelectedIndexChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
        CalculatationEnterprise();
        if (ddlSector_Ent.SelectedIndex == 0)
        {
            HdfLblEnt_is.Value = "";
            LblEnt_is.Text = "";
        }

        hdnfocus.Value = ddlSector_Ent.ClientID;
    }
    protected void BtnApprovalFees_Click(object sender, EventArgs e)
    {
        //string SearchVerfi = "";
      
        //if (RdFall_in_Municipal.SelectedValue.ToString().Trim() == "N")
        //{
        //    SearchVerfi = "2";
        //}
        //DataSet dsv = new DataSet();
        //dsv = Gen.GetShowApprovalandFees(SearchVerfi);
        //if (dsv.Tables[0].Rows.Count > 0)
        //{
        //    grdDetails.DataSource = dsv.Tables[0];
        //    grdDetails.DataBind();
        //}
        //else
        //{
        //    grdDetails.DataSource = null;
        //    grdDetails.DataBind();
        //}
    }
    protected void TxtProp_Emp_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprise();
        hdnfocus.Value =TxtVal_Land.ClientID;
    }
    protected void RdProp_Site_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdProp_Site.SelectedValue.ToString().Trim() == "Y")
        {
            trtrees.Visible = true;
            Txt_NoofTrees.Text = "";
            tr4.Visible = true;
        }
        else
        {
            Txt_NoofTrees.Text = "";
            trtrees.Visible = false;
            tr4.Visible = false;
        }
        hdnfocus.Value = RdProp_Site.ClientID;
    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            decimal TotalFee1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees"));
            TotalFee = TotalFee + TotalFee1;

           

          HiddenField HdfApprovalid = (HiddenField)e.Row.Cells[0].FindControl("HdfApprovalid");
          HdfApprovalid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ApprovalId")).Trim();

          HiddenField HdfQueid = (HiddenField)e.Row.Cells[0].FindControl("HdfQueid");
          HdfQueid.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Dept_Id")).Trim();

            e.Row.Cells[3].Text=Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Fees")).ToString("#,##0");
        }
        if ((e.Row.RowType == DataControlRowType.Footer))
        {
            e.Row.Cells[2].Text = "Total Fee";
            e.Row.Cells[3].Text = TotalFee.ToString("f0");
        }
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        try
        {


            string chkwatera = "", chkwaterb = "", chkwaterc = "";
            if (ChkWater_reg_from.Items[0].Selected == true)
            {
                chkwatera = ChkWater_reg_from.Items[0].Text;
            }
            if (ChkWater_reg_from.Items[1].Selected == true)
            {
                chkwaterb = ChkWater_reg_from.Items[1].Text;
            }

            if (ChkWater_reg_from.Items[2].Selected == true)
            {
                chkwaterc = ChkWater_reg_from.Items[2].Text;
            }


            CalcFees();
            //shankar
            QuesionerVO quesionervoobj = new QuesionerVO();

            quesionervoobj.intQuessionaireid = Session["Applid"].ToString().Trim();
            quesionervoobj.Const_of_unit = ddlConst_of_unit.SelectedValue;
            quesionervoobj.Sector_Ent = ddlSector_Ent.SelectedValue;
            quesionervoobj.Tot_Extent = TxtTot_Extent.Text;
            quesionervoobj.Prop_intDistrictid = ddlProp_intDistrictid.SelectedValue;
            quesionervoobj.Prop_intMandalid = ddlProp_intMandalid.SelectedValue;
            quesionervoobj.Prop_intVillageid = ddlProp_intVillageid.SelectedValue;
            quesionervoobj.Prop_Emp = TxtProp_Emp.Text;
            quesionervoobj.Val_Land = TxtVal_Land.Text;
            quesionervoobj.Val_Build = TxtVal_Build.Text;
            quesionervoobj.Val_Plant = TxtVal_Plant.Text;
            quesionervoobj.Tot_PrjCost = TxtTot_PrjCost.Text;
            quesionervoobj.Ent_is = HdfLblEnt_is.Value;
            quesionervoobj.intLineofActivity = ddlintLineofActivity.SelectedValue;
            quesionervoobj.Pol_Indus = RdPol_Indus.SelectedValue;
            quesionervoobj.Pol_Category = HdfLblPol_Category.Value;
            quesionervoobj.Power_Req = ddlPower_Req.SelectedValue;
            quesionervoobj.Loc_of_unit = ddlLoc_of_unit.SelectedValue;
            quesionervoobj.Water_req_Perday = TxtWater_req_Perday.Text;
            quesionervoobj.Water_reg_from1 = chkwatera;
            quesionervoobj.Water_reg_from2 = chkwaterb;
            quesionervoobj.Water_reg_from3 = chkwaterc;
            quesionervoobj.Do_Store_Kerosine = RdDo_Store_Kerosine.SelectedValue;
            quesionervoobj.Gen_Reqired = RdGen_Reqired.SelectedValue;
            quesionervoobj.Hight_Build = TxtHight_Build.Text;
            quesionervoobj.Built_up_Area = TxtBuilt_up_Area.Text;
            quesionervoobj.Fall_in_Municipal = RdFall_in_Municipal.SelectedValue;
            quesionervoobj.Prop_Site = RdProp_Site.SelectedValue;
            quesionervoobj.Appl_Status = "2";
            quesionervoobj.Appl_no = "1000";
            quesionervoobj.Created_by = Session["uid"].ToString().Trim();
            quesionervoobj.NoofTrees = Txt_NoofTrees.Text;
            quesionervoobj.Non_Exempted = RdbExecpted.SelectedValue;
            quesionervoobj.Appl_Type = ddlAppl_Type.SelectedValue;
            quesionervoobj.nameofunit = TxtnameofUnit.Text.Trim();


            //end shankar

            int s = Gen.insertQuetieneroes(quesionervoobj);
            Session["Applid"] = s.ToString();

            if (s >= 0)
            {
                for (int iii = 0; iii < grdDetails.Rows.Count; iii++)
                {

                    HiddenField HdfApprovalid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfApprovalid");
                    HiddenField HdfQueid = (HiddenField)grdDetails.Rows[iii].Cells[0].FindControl("HdfQueid");
                    int a = Gen.insertQuetieneroesDept(s.ToString(), HdfQueid.Value, HdfApprovalid.Value, "1000", grdDetails.Rows[iii].Cells[3].Text);
                }

                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Questionnaire - Consent for Establishment is Succesfully Submitted";


                cmf.ResetFormControl(this);
                grdDetails.DataSource = null;
                grdDetails.DataBind();
                HdfLblEnt_is.Value = "";
                HdfLblPol_Category.Value = "";
                LblEnt_is.Text = "";
                LblPol_Category.Text = "";
                BtnSave.Visible = false;
                Response.Redirect("TS-iPASS.aspx?id=" + Session["Applid"].ToString().Trim());
            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "Questionnaire - Consent for Establishment is Registration Failed";
            }
        }
        catch (Exception ex)
        {


        }
        finally
        {
        }
    }
    protected void ddlLoc_of_unit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLoc_of_unit.SelectedIndex != 0)
        {
            if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "1")
            {
                trApplType.Visible = true;

                ddlAppl_Type.Items.Clear();
                ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
                ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
                ChkWater_reg_from.Items[1].Selected = true;
                ChkWater_reg_from.Items[1].Enabled = false;
            }
            else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "5")
            {
                trApplType.Visible = true;
                ddlAppl_Type.Items.Clear();
                ddlAppl_Type.Items.Insert(0,new ListItem("Industrial Building Approval", "2"));
                ChkWater_reg_from.Items[1].Selected = true;
                ChkWater_reg_from.Items[1].Enabled = true;
            }
            else if (ddlLoc_of_unit.SelectedValue.ToString().Trim() == "3")
            {
                trApplType.Visible = true;
                ddlAppl_Type.Items.Clear();
                ddlAppl_Type.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlAppl_Type.Items.Insert(1, new ListItem("Change of Land Use", "1"));
                ddlAppl_Type.Items.Insert(2, new ListItem("Industrial Building Approval", "2"));
                ChkWater_reg_from.Items[1].Selected = false;
                ChkWater_reg_from.Items[1].Enabled = false;
            }
            
            else
            {
                trApplType.Visible = false;
                ChkWater_reg_from.Items[1].Selected = false;
                ChkWater_reg_from.Items[1].Enabled = false;
            }
        }
        else
        {
            trApplType.Visible = false;
        }
        hdnfocus.Value = ddlLoc_of_unit.ClientID;
       // ddlLoc_of_unit.Focus();
    }
    protected void TxtTot_Extent_TextChanged(object sender, EventArgs e)
    {

    }
   
}
