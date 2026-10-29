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
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection.Emit;
public partial class UI_TSiPASS_frmlanddetails_buildnow : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    string GeoFileName = "", GeoFilepath = "";
    string KMPFileName = "", KMPFilepath = "";
    string KMPFileName1 = "", KMPFilepath1 = "";
    HMDAService.tsipass hmdaservice = new HMDAService.tsipass();
    HMDAService.ApplicationFormResponse hmdapplication = new HMDAService.ApplicationFormResponse();
    DB.DB con = new DB.DB();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {
            BindLineofActivityName();
            txtLand_ProposedArea.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());

            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                if (TourismFlag == "Y")
                {
                    ViewState["TOURISMFLAG"] = "Y";
                    tblGeoDetailsforHotel.Visible = true;
                    if (dscheck.Tables[0].Rows[0]["Excavation_Flag"].ToString().Trim() == "Y")
                    {
                        trExcavation.Visible = true;
                    }
                    else
                    {
                        trExcavation.Visible = false;
                    }
                    lblIndusProdActivity.Text = "Please Enter Unit/Product/Activity";
                    lblCategoryofIndus.Text = "Category of Unit";
                    ddltypeofbuilding.SelectedValue = "2";//commercial automatically
                }
                else
                {
                    tblGeoDetailsforHotel.Visible = false;
                    lblIndusProdActivity.Text = "Please Enter Industry/Product/Activity";
                    lblCategoryofIndus.Text = "Category of Industry";

                }
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque1(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");
                HDNAPPLSTATUS.Value = res;


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);


                }
                if (Label12.Text == "" || Label12.Text == null)
                {
                    FileUpload3.Enabled = true;
                }
                else
                {
                    FileUpload3.Enabled = false;
                }

            }
            //DataSet dsdtls1 = new DataSet();
            //DataTable dt1 = new DataTable();
            //dsdtls1 = Gen.GetApprovalsDetails(Session["Applid"].ToString().Trim());
            //if (dsdtls1 != null && dsdtls1.Tables.Count > 0 && dsdtls1.Tables[0].Rows.Count > 0)
            //{
            //    if (dsdtls1.Tables[0].Rows.Count > 0)
            //    {
            //        dt1 = dsdtls1.Tables[0];
            //        for (int i = 0; i < dt1.Rows.Count; i++)
            //        {
            //            string deptid = dt1.Rows[i]["ApprovalId"].ToString();
            //            string IsOffline = dt1.Rows[i]["IsOffline"].ToString();
            //            if ((deptid == "6" || deptid == "36" || deptid == "45") && IsOffline != "Y")
            //            {
            //                CLUTable.Visible = true;
            //                return;

            //            }

            //            return;
            //            //else
            //            //{
            //            //    trarchitec.Visible = false;
            //            //    trarchitecdwg.Visible = false;
            //            //}

            //        }
            //    }

            //}

            DataSet dsdtls = new DataSet();
            DataTable dt = new DataTable();
            dsdtls = Gen.GetApprovalsDetails(Session["Applid"].ToString().Trim());
            if (dsdtls != null && dsdtls.Tables.Count > 0 && dsdtls.Tables[0].Rows.Count > 0)
            {
                if (dsdtls.Tables[0].Rows.Count > 0)
                {
                    dt = dsdtls.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string deptid = dt.Rows[i]["ApprovalId"].ToString();
                        HDNAPPROVALID.Value = deptid;
                        string IsOffline = dt.Rows[i]["IsOffline"].ToString();
                        HDNDTCP_MUNCIPALFLAG.Value = dt.Rows[i]["DTCP_MUNCIPALFLAG"].ToString();
                        //string AppStatus = dt.Rows[i]["Appl_Status"].ToString();
                        //if (AppStatus == "3")
                        //{
                        if ((deptid == "31" || deptid == "7" || deptid == "35" || deptid == "38") && IsOffline != "Y")
                        {
                            trarchitec.Visible = true;
                            trarchitecdwg.Visible = true;
                            TRARCHLICNO.Visible = true;
                            TRARCHLICMOBILENO.Visible = true;
                            TRARCHLICNAME.Visible = true;
                            HDNAPPRVALID2.Value = HDNAPPROVALID.Value;

                            if (HDNAPPRVALID2.Value == "7")
                            {
                                if (Session["Uid"].ToString() == "335162" || Session["Uid"].ToString() == "320265" || Session["Uid"].ToString() == "335486")
                                {
                                    drawingno.Visible = false;
                                    //drawing2.Visible = false;
                                    TRHEADING.Visible = false;
                                    TRPLANPDF.Visible = false;
                                    TRSECURITYREPORT.Visible = false;

                                }
                                else
                                {
                                    if (HDNDTCP_MUNCIPALFLAG.Value == "Y")
                                    {
                                        trarchitec.Visible = true;
                                        trarchitecdwg.Visible = true;
                                        TRHEADING.Visible = true;

                                        drawingno.Visible = true;
                                        drawing2.Visible = true;
                                        TRARCHLICNO.Visible = false;
                                        TRARCHLICMOBILENO.Visible = false;
                                        TRARCHLICNAME.Visible = false;
                                        TRPREDCR.Visible = false;
                                    }
                                    else
                                    {
                                        drawingno.Visible = false;
                                        //drawing2.Visible = false;
                                        TRHEADING.Visible = false;
                                        TRPLANPDF.Visible = false;
                                        TRSECURITYREPORT.Visible = false;

                                    }

                                }
                            }

                            else if (HDNAPPRVALID2.Value == "35")
                            {
                                trarchitec.Visible = true;
                                trarchitecdwg.Visible = true;
                                TRHEADING.Visible = true;

                                drawingno.Visible = true;
                                drawing2.Visible = true;
                                TRARCHLICNO.Visible = false;
                                TRARCHLICMOBILENO.Visible = false;
                                TRARCHLICNAME.Visible = false;
                                TRPREDCR.Visible = false;
                            }
                            else
                            {
                                TRHEADING.Visible = false;

                                trarchitec.Visible = true;
                                trarchitecdwg.Visible = true;
                                drawingno.Visible = false;
                                //drawing2.Visible = false;
                            }

                        }

                        if ((deptid == "31" || deptid == "7" || deptid == "35" || deptid == "38") && IsOffline == "Y")
                        {
                            trarchitec.Visible = false;
                            trarchitecdwg.Visible = false;
                            drawingno.Visible = false;
                            //drawing2.Visible = false;
                            //drawingno.Visible = false;
                            ////drawing2.Visible = false;
                        }
                        if ((deptid == "6" || deptid == "36" || deptid == "45") && IsOffline != "Y")
                        {
                            CLUTable.Visible = true;


                        }
                        //}
                        //else if ((deptid == "31" || deptid == "7" || deptid == "35") && IsOffline != "Y")
                        //{

                        //}


                        //else
                        //{
                        //    trarchitec.Visible = false;
                        //    trarchitecdwg.Visible = false;
                        //}

                    }
                }

            }
            getdistricts();
            getCorportaions();


            //if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            //{
            //    Response.Redirect("frmQuesstionniareReg.aspx");
            //}
            if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            {
                string TourismFlag = ""; //lavanya 20.10.2020
                if (ViewState["TOURISMFLAG"] != null)
                    TourismFlag = ViewState["TOURISMFLAG"].ToString();
                if (TourismFlag == "Y")
                { Response.Redirect("frmQuesstionniareRegHotel.aspx"); }
                else
                {
                    Response.Redirect("frmQuesstionniareReg.aspx");
                }
            }
            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {
                DataSet dsnew = new DataSet();

                dsnew = Gen.GetEnterPreneurdatabyQuewaterReq(Session["Applid"].ToString());

                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    txtLand_TotExtent.Text = dsnew.Tables[0].Rows[0]["Tot_Extent"].ToString().Trim();

                    txtLand_BuiltupArea.Text = dsnew.Tables[0].Rows[0]["Built_up_Area"].ToString().Trim();
                    //commented on 07-11-2020
                    //if (dsnew.Tables[0].Rows[0]["TsiicPlotno"].ToString().Trim() != "")
                    //{
                    //    txtSurveyNo.Text = dsnew.Tables[0].Rows[0]["TsiicPlotno"].ToString().Trim();
                    //}



                    //   txtHight_Building.Text = dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();

                    //if (dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim() != "")
                    //{
                    //    ddlintIndustryProduct.SelectedValue = ddlintIndustryProduct.Items.FindByValue(dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim()).Value;
                    //    ddlintIndustryProduct.Enabled = false;
                    //}
                    if (dsnew.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim() != "")
                    {
                        try
                        {
                            ddlintIndustryProduct.SelectedValue = ddlintIndustryProduct.Items.FindByValue(dsnew.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;
                            ddlintIndustryProduct.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (dsnew.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim() != "" && dsnew.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim() != "0")
                    {
                        ddlintLocationFalls.SelectedValue = ddlintLocationFalls.Items.FindByValue(dsnew.Tables[0].Rows[0]["Loc_of_unit"].ToString().Trim()).Value;
                        ddlintLocationFalls.Enabled = false;
                    }
                    if (dsnew.Tables[0].Rows[0]["NameofIALA"].ToString().Trim() != "")
                    {
                        txtLocationNameIEIDA.Text = dsnew.Tables[0].Rows[0]["NameofIALA"].ToString().Trim();
                        txtLocationNameIEIDA.Enabled = false;
                        trsez.Visible = true;
                        ddlintApplicationTypeid.SelectedValue = "2";
                        // ddlintApplicationTypeid_SelectedIndexChanged(sender, e);
                        //ddlintApplicationTypeid.Enabled = false;
                    }
                    else
                    {
                        trsez.Visible = false;
                    }

                    if (dsnew.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "" && dsnew.Tables[0].Rows[0]["Appl_Type"].ToString().Trim() != "0")
                    {
                        ddlintApplicationTypeid.SelectedValue = ddlintApplicationTypeid.Items.FindByValue(dsnew.Tables[0].Rows[0]["Appl_Type"].ToString().Trim()).Value;
                        // ddlintApplicationTypeid_SelectedIndexChanged(sender, e);
                        //ddlintApplicationTypeid.Enabled = false;
                    }
                    else if (dsnew.Tables[0].Rows[0]["NameofIALA"].ToString().Trim() == "")
                    {
                        ddlintApplicationTypeid.SelectedValue = "4";
                        //  ddlintApplicationTypeid_SelectedIndexChanged(sender, e);
                        //  ddlintApplicationTypeid.Enabled = false;
                    }
                    if (dsnew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dsnew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                    {

                        if (dsnew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dsnew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                        {
                            ddlLand_intDistrictid.SelectedValue = ddlLand_intDistrictid.Items.FindByValue(dsnew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
                            ddlLand_intDistrictid_SelectedIndexChanged(sender, e);
                            ddlLand_intDistrictid.Enabled = false;
                        }

                        if (dsnew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "" && dsnew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "0")
                        {
                            ddlLand_intMandalid.SelectedValue = ddlLand_intMandalid.Items.FindByValue(dsnew.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
                            ddlLand_intMandalid_SelectedIndexChanged(sender, e);
                            ddlLand_intMandalid.Enabled = false;
                        }
                        if (dsnew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "" && dsnew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "0")
                        {
                            ddlLand_intVillageid.SelectedValue = ddlLand_intVillageid.Items.FindByValue(dsnew.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                            ddlLand_intVillageid.Enabled = false;
                        }
                    }
                    if (dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim() != "")
                    {
                        txtHight_Building.Text = dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();
                        txtHight_Building.Enabled = false;
                    }
                    else
                    {
                        txtHight_Building.Enabled = true;
                    }

                    if (dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim() != "")
                    {
                        txtHight_Building.Text = dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();

                        if (Convert.ToDecimal(txtHight_Building.Text.Trim()) >= Convert.ToDecimal("18"))
                        {
                            trNOC.Visible = true;


                        }

                        else
                        {

                            trNOC.Visible = false;

                        }

                    }
                    else
                    {
                        txtHight_Building.Enabled = true;
                    }





                }

                txtLand_TotExtent.Enabled = false;
                txtLand_BuiltupArea.Enabled = false;
                // txtHight_Building.Enabled = false;

                DataSet dsch = new DataSet();
                dsch = Gen.GetEnterPreneurdatabyQue1(Session["Applid"].ToString());

                if (dsch.Tables[0].Rows.Count > 0)
                {

                    if (dsch.Tables[0].Rows[0]["PolCatogory"].ToString() == "2")
                    {
                        ddlintCategoryid.SelectedValue = ddlintCategoryid.Items.FindByValue(dsch.Tables[0].Rows[0]["PolCatogory"].ToString()).Value;


                    }
                    else if (dsch.Tables[0].Rows[0]["PolCatogory"].ToString() == "3")
                    {

                        ddlintCategoryid.SelectedValue = ddlintCategoryid.Items.FindByValue(dsch.Tables[0].Rows[0]["PolCatogory"].ToString()).Value;
                    }

                    else if (dsch.Tables[0].Rows[0]["PolCatogory"].ToString() == "1")
                    {
                        ddlintCategoryid.SelectedValue = ddlintCategoryid.Items.FindByValue(dsch.Tables[0].Rows[0]["PolCatogory"].ToString()).Value;

                    }
                    else if (dsch.Tables[0].Rows[0]["PolCatogory"].ToString() == "4")
                    {
                        ddlintCategoryid.SelectedValue = ddlintCategoryid.Items.FindByValue(dsch.Tables[0].Rows[0]["PolCatogory"].ToString()).Value;

                    }
                    else
                    {

                    }
                    ddlintCategoryid.Enabled = false;
                }

                //DataSet dspvt = new DataSet();
                //dspvt=Gen

            }

            if (txtName_Gramapachayat.Text.Trim().TrimEnd() == "")
            {
                txtName_Gramapachayat.ReadOnly = false;
            }
            if (txtLand_Pincode.Text.Trim().TrimEnd() == "")
            {
                txtLand_Pincode.ReadOnly = false;
            }
            if (txtLand_ProposedArea.Text.Trim().TrimEnd() == "")
            {
                txtLand_ProposedArea.ReadOnly = false;
            }
            if (txtLand_BuiltupArea.Text.Trim().TrimEnd() == "")
            {
                txtLand_BuiltupArea.ReadOnly = false;
            }
            if (txtHight_Building.Text.Trim().TrimEnd() == "")
            {
                txtHight_Building.ReadOnly = false;
            }
            if (txtLand_Existingwidth.Text.Trim().TrimEnd() == "")
            {
                txtLand_Existingwidth.ReadOnly = false;
            }
            if (txtLand_TelephoneNumber.Text.Trim().TrimEnd() == "")
            {
                txtLand_TelephoneNumber.ReadOnly = false;
            }
            if (ddlintTypeofApprochid.SelectedValue == "--Select--")
            {
                ddlintTypeofApprochid.Enabled = true;
            }
            if (ddlintLocationFalls.SelectedValue == "--Select--")
            {
                ddlintLocationFalls.Enabled = true;
            }
            if (ddlintBuildingApproval.SelectedValue == "--Select--")
            {
                ddlintBuildingApproval.Enabled = true;
            }
            if (ddlintIndustryProduct.SelectedValue == "--Select--")
            {
                ddlintIndustryProduct.Enabled = true;
            }
            if (ddlintCategoryid.SelectedValue == "--Select--")
            {
                ddlintIndustryProduct.Enabled = true;
            }
            //if (Request.QueryString["intApplicationId"] != null)
            //{
            //    hdfID.Value = Request.QueryString["intApplicationId"];
            //    hdfFlagID.Value = "0";
            //}
        }


        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfID.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();
                FillDetails_SCRUTINYATTACHMENTS();
                DataSet dsver = new DataSet();

                dsver = Gen.Getverifyofque1(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");
                    HDNAPPLSTATUS.Value = res;


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);


                    }
                    if (Label12.Text == "" || Label12.Text == null)
                    {
                        FileUpload3.Enabled = true;
                    }
                    else
                    {
                        FileUpload3.Enabled = false;
                    }

                }

            }

        }

        if (txtArchitectName.Text.Trim() == "")
        {
            txtArchitectName.ReadOnly = false;
        }
        if (txtArchitectMobileno.Text.Trim() == "")
        {
            txtArchitectMobileno.ReadOnly = false;
        }
        if (txtalic2.Text.Trim() == "" || txtalic2.Text.Length.ToString() != "4")
        {
            txtalic2.ReadOnly = false;
        }
        if (txtalic3.Text.Trim() == "" || txtalic3.Text.Length.ToString() != "5" || txtalic3.Text.Length.ToString() != "6")
        {
            txtalic3.ReadOnly = false;
        }
        if (txtstructuralengname.Text.Trim() == "")
        {
            txtstructuralengname.ReadOnly = false;
        }
        if (txtstructuralenglicno.Text.Trim() == "")
        {
            txtstructuralenglicno.ReadOnly = false;
        }
        if (txtstructuralmobileno.Text.Trim() == "")
        {
            txtstructuralmobileno.ReadOnly = false;
        }
        if (ddltypeofbuilding.SelectedItem.Text == "--Select--")
        {
            ddltypeofbuilding.Enabled = true;
        }
        if (ddllandaspermasterplan.SelectedItem.Text == "--Select--")
        {
            ddllandaspermasterplan.Enabled = true;
        }
        if (ddlislandpartof.SelectedItem.Text == "--Select--")
        {
            ddlislandpartof.Enabled = true;
        }
        if (rblAffected_roadwinding.SelectedValue == null)
        {
            rblAffected_roadwinding.Enabled = true;
        }
        if (txtroadwidening.Text.Trim() == "")
        {
            txtroadwidening.ReadOnly = false;
        }
        if (txtexistingbuildup.Text == "")
        {
            txtexistingbuildup.ReadOnly = false;
        }
        if (txttypeofbuildingother.Text == "")
        {
            txttypeofbuildingother.ReadOnly = false;
        }
        if (txtlandmasterplan.Text == "")
        {
            txtlandmasterplan.ReadOnly = false;
        }
        if (Label6.Text == "")
        {
            FileUpload5.Enabled = true;
        }

        if (Label8.Text == "")
        {
            FileUpload1.Enabled = true;
        }

        if (Label10.Text == "")
        {
            FileUpload2.Enabled = true;
        }
        //if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        //{
        //   // FillDetails();
        //   // lblmsg.Text = "";


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
                        if (((TextBox)c).Text == "" || ((TextBox)c).Text == null || string.IsNullOrEmpty(((TextBox)c).Text))
                        {
                            ((TextBox)c).ReadOnly = false;
                        }
                        else
                        {
                            ((TextBox)c).ReadOnly = true;
                        }

                        //((TextBox)c).ReadOnly = true;
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
                }
            }
        }
    }

    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetDistricts();

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsnew = new DataSet();
        //ddlProp_intDistrictid.Items.Clear();
        dsnew = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");
        ddlLand_intDistrictid.DataSource = dsnew.Tables[0];
        ddlLand_intDistrictid.DataTextField = "District_Name";
        ddlLand_intDistrictid.DataValueField = "District_Id";
        ddlLand_intDistrictid.DataBind();
        ddlLand_intDistrictid.Items.Insert(0, "--Select--");

    }

    //void getMandals()
    //{

    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.Getmandalsbydistrict(ddlLand_intDistrictid.SelectedValue.ToString());
    //    ddlLand_intMandalid.DataSource = dsnew.Tables[0];
    //    ddlLand_intMandalid.DataTextField = "Manda_lName";
    //    ddlLand_intMandalid.DataValueField = "Mandal_Id";
    //    ddlLand_intMandalid.DataBind();
    //    ddlLand_intMandalid.Items.Insert(0, "--Select--");


    //}
    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetMandals(ddlLand_intDistrictid.SelectedValue.ToString());
        ddlLand_intMandalid.DataSource = dsnew.Tables[0];
        ddlLand_intMandalid.DataTextField = "Manda_lName";
        ddlLand_intMandalid.DataValueField = "Mandal_Id";
        ddlLand_intMandalid.DataBind();
        ddlLand_intMandalid.Items.Insert(0, "--Select--");


    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.GetVillagebymandal(ddlLand_intMandalid.SelectedValue.ToString());
        ddlLand_intVillageid.DataSource = dsnew.Tables[0];
        ddlLand_intVillageid.DataTextField = "Village_Name";
        ddlLand_intVillageid.DataValueField = "Village_Id";
        ddlLand_intVillageid.DataBind();
        ddlLand_intVillageid.Items.Insert(0, "--Select--");


    }


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (ViewState["GeoName"] == null)
            ViewState["GeoName"] = "";
        if (ViewState["pathGeo"] == null)
            ViewState["pathGeo"] = "";
        if (ViewState["pathKML"] == null)
            ViewState["pathKML"] = "";
        if (ViewState["KMLName"] == null)
            ViewState["KMLName"] = "";
        if (ViewState["pathKML1"] == null)
            ViewState["pathKML1"] = "";
        if (ViewState["KMLName1"] == null)
            ViewState["KMLName1"] = "";

        string number = "";

        if (hdfID.Value != "")
        {

            number = hdfpencode.Value;
        }
        if (drawing2.Visible == true)
        {
            if (txtSecretKey.Text.Trim().ToString() == "" || txtdrrefno1.Text.Trim().ToString() == "")
            {
                lblmsg0.Text = "<font color='red'>Please enter Secret Key!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtSecretKey.Enabled = true;
                txtdrrefno1.Enabled = true;
                return;
            }
        }

        if (trarchitec.Visible == true && TRARCHLICMOBILENO.Visible == true)
        {
            if (txtArchitectMobileno.Text.Length.ToString() != "10")
            {
                lblmsg0.Text = "<font color='red'>Architect Mobile number length must be exactly 10 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtArchitectMobileno.Enabled = true;
                return;
            }
            if (txtalic2.Text.Length.ToString() != "4")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Correct Year of Architect License Number!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtalic2.Enabled = true;
                return;
            }
            if (txtalic2.Text.Trim() != "")
            {
                if (txtalic2.Text.Length == 4)
                {
                    int articyear = 0;
                    articyear = Convert.ToInt16(txtalic2.Text.Trim());
                    if (articyear > 1900 && articyear <= DateTime.Now.Year)
                    {

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(txtalic2);
                        return;
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    SetFocus(txtalic2);
                    return;
                }
            }
            if (txtalic3.Text.Length.ToString() != "5" && txtalic3.Text.Length.ToString() != "6")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Correct Architect License Number!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtalic3.Enabled = true;
                return;
            }
            if (Label6.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Architectural dwg. in Pre-DCR..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }


            if (Label8.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Common Affidavit Copy..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (Label10.Text == "" && Convert.ToDecimal(txtHight_Building.Text.ToString()) > 18)
            {
                lblmsg0.Text = "<font color='red'>Please Upload NOC from FIRE Dept..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (trstructuralengmobileno.Visible == true)
        {
            if (txtstructuralmobileno.Text.Length.ToString() != "10")
            {
                lblmsg0.Text = "<font color='red'>Structural Engineer Mobile number length must be exactly 10 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (txtLand_ProposedArea.Text == "0" || txtLand_ProposedArea.Text == "0.00")
        {
            lblmsg0.Text = "<font color='red'>Proposed Area for Development(in Sq. mts) should not be Zero!</font>";
            //  this.Clear();
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (HDNAPPRVALID2.Value == "7" || HDNAPPRVALID2.Value == "35")
        {
            if (txtSecretKey.Text.Trim() != "")
            {


                if (txtdrrefno1.Text == "" || txtdrrefno1.Text == null || string.IsNullOrWhiteSpace(txtdrrefno1.Text) || txtdrrefno2.Text == "" || txtdrrefno2.Text == null || string.IsNullOrWhiteSpace(txtdrrefno2.Text) ||
                    txtdrrefno3.Text == "" || txtdrrefno3.Text == null || string.IsNullOrWhiteSpace(txtdrrefno3.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter drawing reference number')", true);
                    txtSecretKey.Text = "";
                    txtdrrefno2.Focus();
                    return;
                }
                string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                DrawingVo drawing = new DrawingVo();
                drawing.RefNo = txtdrrefno1.Text.Trim() + "/" + txtdrrefno2.Text.Trim() + "/" + txtdrrefno3.Text.Trim();// "TS/000026/2024";
                drawing.SecretKey = txtSecretKey.Text.Trim();// "Hanspp2uHSBv7TG";
                DCRPORTALLIVE.TGiPASSdrawingio1 objdcr = new DCRPORTALLIVE.TGiPASSdrawingio1();
                string responseJson1 = objdcr.XMLREQUEST1(drawing.RefNo, drawing.SecretKey);
                BuildingPermitResponse responseObject = JsonConvert.DeserializeObject<BuildingPermitResponse>(responseJson1);
                ViewState["responseObject"] = responseObject;

                BuildingPermitResponse responseObject1 = (BuildingPermitResponse)ViewState["responseObject"];
                int DrawingResult = 0;
                string DrawingNo = txtdrrefno1.Text.Trim() + "/" + txtdrrefno2.Text.Trim() + "/" + txtdrrefno3.Text.Trim();
                string Secretkey = txtSecretKey.Text.Trim();
                DrawingResult = Gen.InsertDrawingDetails(DrawingNo, Secretkey, responseObject1.Applicationtype, responseObject1.ArchitectLicenseNo, responseObject1.ArchitectMobileNo,
                    responseObject1.ArchitectName, responseObject1.Authority, responseObject1.BuiltUpArea, responseObject1.Casetype, responseObject1.District,
                    responseObject1.ExistingRoadWidth, responseObject1.GramPanchayat, responseObject1.LocalBody, responseObject1.Mandal, responseObject1.MaxBuildingHeight,
                    responseObject1.Municipality, responseObject1.Organisation, responseObject1.PlanPDFBase64, responseObject1.PlanPDFName, responseObject1.PredcrDwgBase64,
                    responseObject1.PredcrDwgName, responseObject1.ScrutinyReportBase64, responseObject1.ScrutinyReportName, responseObject1.TotalLandExtent,
                    responseObject1.Village, Request.QueryString[0].ToString(), Session["uid"].ToString().Trim(), responseObject1.sMessage, responseObject1.sStatus);
            }
        }
        //if (DrawingResult > 0)
        //{
        DataSet ds = new DataSet();

        ds = Gen.GetdataofLandenterprenuer(hdfID.Value.ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            int result = 0;

            //result = Gen.InsertLandDetails("1000", Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1234", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

            result = Gen.InsertLandDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, null, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(),
               txtArchitectName.Text.Trim(), txtalic1.Text.Trim() + "/" + txtalic2.Text.Trim() + "/" + txtalic3.Text.Trim(), txtArchitectMobileno.Text.Trim(), txtexistingbuildup.Text.Trim(), ddllandaspermasterplan.SelectedValue, txtlandmasterplan.Text.Trim(), ddltypeofbuilding.SelectedValue, txttypeofbuildingother.Text.Trim(), rblAffected_roadwinding.SelectedValue, txtroadwidening.Text, ddlislandpartof.SelectedValue, txtstructuralenglicno.Text.Trim(), txtstructuralengname.Text.Trim(), txtstructuralmobileno.Text.Trim(), ddlcorporationname.SelectedValue, ddlwardno.SelectedValue, "", "", "", "", "", txtExcavationDepth.Text.Trim());
            if (result > 0)
            {
                //ResetFormControl(this);
                lblmsg.Text = "<font color='green'>Land Details Saved Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                this.Clear();
                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                //fillNews(userid);
            }
            else if (result == 0)
            {
                lblmsg.Text = "<font color='green'>Land Details Updated Successfully..!</font>";
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Land Details Saved Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
            }

        }
        else
        {
            int result = 0;

            //result = Gen.InsertLandDetails("1000", Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), "1234", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

            result = Gen.InsertLandDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, null, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(),
                txtArchitectName.Text.Trim(), txtalic1.Text.Trim() + "/" + txtalic2.Text.Trim() + "/" + txtalic3.Text.Trim(), txtArchitectMobileno.Text.Trim(), txtexistingbuildup.Text.Trim(), ddllandaspermasterplan.SelectedValue, txtlandmasterplan.Text.Trim(), ddltypeofbuilding.SelectedValue, txttypeofbuildingother.Text.Trim(), rblAffected_roadwinding.SelectedValue, txtroadwidening.Text, ddlislandpartof.SelectedValue, txtstructuralenglicno.Text.Trim(), txtstructuralengname.Text.Trim(), txtstructuralmobileno.Text.Trim(), ddlcorporationname.SelectedValue, ddlwardno.SelectedValue, "", "", "", "", "", txtExcavationDepth.Text.Trim());
            if (result > 0)
            {
                //ResetFormControl(this);
                lblmsg.Text = "<font color='green'>Land Details Saved Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
                this.Clear();
                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                //fillNews(userid);
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Land Details Saved Failed..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
            }

        }
        //}
    }
    public void Clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        if (ddlintApplicationTypeid.SelectedIndex == 1)
        {
            //if (Label455.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Google Map..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (Label456.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload KML File..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
        }
        if (ddlintApplicationTypeid.SelectedIndex == 2)
        {
            //if (Label457.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload KML File..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
        }
        if (ddlintApplicationTypeid.SelectedIndex == 3)
        {
            //if (Label455.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload Google Map..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (Label456.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload KML File..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
            //if (Label457.Text == "")
            //{
            //    lblmsg0.Text = "<font color='red'>Please Upload KML File..!</font>";
            //    success.Visible = false;
            //    Failure.Visible = true;
            //    return;
            //}
        }

        if (trarchitec.Visible == true && TRARCHLICMOBILENO.Visible == true)
        {
            if (txtArchitectMobileno.Text.Length.ToString() != "10")
            {
                lblmsg0.Text = "<font color='red'>Architect Mobile number length must be exactly 10 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtArchitectMobileno.Enabled = true;
                return;
            }

            if (txtalic2.Text.Length.ToString() != "4")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Correct Year of Architect License Number!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtalic2.Enabled = true;
                return;
            }
            if (txtalic2.Text.Trim() != "")
            {
                if (txtalic2.Text.Length == 4)
                {
                    int articyear = 0;
                    articyear = Convert.ToInt16(txtalic2.Text.Trim());
                    if (articyear > 1900 && articyear <= DateTime.Now.Year)
                    {

                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        SetFocus(txtalic2);
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    SetFocus(txtalic2);
                }
            }
            if (txtalic3.Text.Length.ToString() != "6" && txtalic3.Text.Length.ToString() != "5")
            {
                lblmsg0.Text = "<font color='red'>Please Enter Correct Architect License Number!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtalic3.Enabled = true;
                return;
            }
            if (Label6.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Architectural dwg. in Pre-DCR..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (Label12.Text == "" && CLUTable.Visible == true)
            {
                lblmsg0.Text = "<font color='red'>Please Upload SELF CERTIFICATION FOR CHANGE OF LAND USE..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }



            if (Label8.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Common Affidavit Copy..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (Label10.Text == "" && Convert.ToDecimal(txtHight_Building.Text.ToString()) >= 18)
            {
                lblmsg0.Text = "<font color='red'>Please Upload NOC from FIRE Dept..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }
        if (trstructuralengmobileno.Visible == true)
        {
            if (txtstructuralmobileno.Text.Length.ToString() != "10")
            {
                lblmsg0.Text = "<font color='red'>Structural Engineer Mobile number length must be exactly 10 characters!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
        }

        if (ViewState["GeoName"] == null)
            ViewState["GeoName"] = "";
        if (ViewState["pathGeo"] == null)
            ViewState["pathGeo"] = "";
        if (ViewState["pathKML"] == null)
            ViewState["pathKML"] = "";
        if (ViewState["KMLName"] == null)
            ViewState["KMLName"] = "";
        if (ViewState["pathKML1"] == null)
            ViewState["pathKML1"] = "";
        if (ViewState["KMLName1"] == null)
            ViewState["KMLName1"] = "";

        string number = "";

        if (hdfID.Value != "")
        {

            number = hdfpencode.Value;
        }

        if (drawing2.Visible == true)
        {
            if (txtSecretKey.Text.Trim().ToString() == "" || txtdrrefno1.Text.Trim().ToString() == "")
            {
                lblmsg0.Text = "<font color='red'>Please enter Secret Key!</font>";
                //  this.Clear();
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(lblmsg0);
                txtSecretKey.Enabled = true;
                txtdrrefno1.Enabled = true;
                return;
            }
        }
        if (BtnDelete.Text == "Next")
        {
            if (HDNAPPRVALID2.Value == "7" || HDNAPPRVALID2.Value == "35")
            {
                if (txtSecretKey.Text.Trim() != "")
                {


                    if (txtdrrefno1.Text == "" || txtdrrefno1.Text == null || string.IsNullOrWhiteSpace(txtdrrefno1.Text) || txtdrrefno2.Text == "" || txtdrrefno2.Text == null || string.IsNullOrWhiteSpace(txtdrrefno2.Text) ||
                        txtdrrefno3.Text == "" || txtdrrefno3.Text == null || string.IsNullOrWhiteSpace(txtdrrefno3.Text))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter drawing reference number')", true);
                        txtSecretKey.Text = "";
                        txtdrrefno2.Focus();
                        return;
                    }
                    string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                    DrawingVo drawing = new DrawingVo();
                    drawing.RefNo = txtdrrefno1.Text.Trim() + "/" + txtdrrefno2.Text.Trim() + "/" + txtdrrefno3.Text.Trim();// "TS/000026/2024";
                    drawing.SecretKey = txtSecretKey.Text.Trim();// "Hanspp2uHSBv7TG";
                    DCRPORTALLIVE.TGiPASSdrawingio1 objdcr = new DCRPORTALLIVE.TGiPASSdrawingio1();
                    string responseJson1 = objdcr.XMLREQUEST1(drawing.RefNo, drawing.SecretKey);
                    BuildingPermitResponse responseObject = JsonConvert.DeserializeObject<BuildingPermitResponse>(responseJson1);
                    ViewState["responseObject"] = responseObject;

                    BuildingPermitResponse responseObject1 = (BuildingPermitResponse)ViewState["responseObject"];
                    int DrawingResult = 0;
                    string DrawingNo = txtdrrefno1.Text.Trim() + "/" + txtdrrefno2.Text.Trim() + "/" + txtdrrefno3.Text.Trim();
                    string Secretkey = txtSecretKey.Text.Trim();
                    DrawingResult = Gen.InsertDrawingDetails(DrawingNo, Secretkey, responseObject1.Applicationtype, responseObject1.ArchitectLicenseNo, responseObject1.ArchitectMobileNo,
                        responseObject1.ArchitectName, responseObject1.Authority, responseObject1.BuiltUpArea, responseObject1.Casetype, responseObject1.District,
                        responseObject1.ExistingRoadWidth, responseObject1.GramPanchayat, responseObject1.LocalBody, responseObject1.Mandal, responseObject1.MaxBuildingHeight,
                        responseObject1.Municipality, responseObject1.Organisation, responseObject1.PlanPDFBase64, responseObject1.PlanPDFName, responseObject1.PredcrDwgBase64,
                        responseObject1.PredcrDwgName, responseObject1.ScrutinyReportBase64, responseObject1.ScrutinyReportName, responseObject1.TotalLandExtent,
                        responseObject1.Village, Request.QueryString[0].ToString(), Session["uid"].ToString().Trim(), responseObject1.sMessage, responseObject1.sStatus);
                }
            }
            DataSet ds = new DataSet();

            ds = Gen.GetdataofLandenterprenuer(hdfID.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {


                int result = 0;

                result = Gen.InsertLandDetails(ds.Tables[0].Rows[0]["intCFELandid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, null, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(),
                    txtArchitectName.Text.Trim(), txtalic1.Text.Trim() + "/" + txtalic2.Text.Trim() + "/" + txtalic3.Text.Trim(), txtArchitectMobileno.Text.Trim(), txtexistingbuildup.Text.Trim(), ddllandaspermasterplan.SelectedValue, txtlandmasterplan.Text.Trim(), ddltypeofbuilding.SelectedValue, txttypeofbuildingother.Text.Trim(), rblAffected_roadwinding.SelectedValue, txtroadwidening.Text, ddlislandpartof.SelectedValue, txtstructuralenglicno.Text.Trim(), txtstructuralengname.Text.Trim(), txtstructuralmobileno.Text.Trim(), ddlcorporationname.SelectedValue, ddlwardno.SelectedValue, "", "", "", "", "", txtExcavationDepth.Text.Trim());
                //result = Gen.InsertLandDetails(number, Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, rblIsSitePlanning.SelectedValue, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, GeoFileName, GeoFilepath, txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, KMPFileName, KMPFilepath, rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, KMPFileName1, KMPFilepath1, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Land Details Added Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                    this.Clear();
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value + "&next=" + "N");
                }

                else
                {
                    lblmsg0.Text = "<font color='red'>Land Details Adding Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
            }
            else
            {
                int result = 0;
                result = Gen.InsertLandDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", ddlintProposedCateogryid.SelectedValue, ddlintApplicationTypeid.SelectedValue, txtLocationNameIEIDA.Text, null, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, txtLand_Email.Text, txtLand_TelephoneNumber.Text, txtLand_TotExtent.Text, txtLand_ProposedArea.Text, txtLand_BuiltupArea.Text, txtLand_Existingwidth.Text, ddlintTypeofApprochid.SelectedValue, ddlintLocationFalls.SelectedValue, ddlintBuildingApproval.SelectedValue, ddlintIndustryProduct.SelectedValue, ddlintCategoryid.SelectedValue, ddlFromZone.SelectedValue, ddlToZone.SelectedValue, ViewState["GeoName"].ToString(), ViewState["pathGeo"].ToString(), txtGeo_Cordinate_Latitude.Text, txtGeo_Cordinate_Langitude.Text, ViewState["KMLName"].ToString(), ViewState["pathKML"].ToString(), rblCovered_revenueSketch.SelectedValue, rblCovered_Adjoining.SelectedValue, txtPlot_Number.Text, txtSanction_LayoutNo.Text, txtLand_User_MasterPlan.Text, txtHight_Building.Text, rblAffected_roadwinding.SelectedValue, txtGeo_Cordinate_Latitude1.Text, txtGeo_Cordinate_Langitude1.Text, ViewState["KMLName1"].ToString(), ViewState["pathKML1"].ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(), Session["uid"].ToString().Trim(), DateTime.Now.ToString(),
                    txtArchitectName.Text.Trim(), txtalic1.Text.Trim() + "/" + txtalic2.Text.Trim() + "/" + txtalic3.Text.Trim(), txtArchitectMobileno.Text.Trim(), txtexistingbuildup.Text.Trim(), ddllandaspermasterplan.SelectedValue, txtlandmasterplan.Text.Trim(), ddltypeofbuilding.SelectedValue, txttypeofbuildingother.Text.Trim(), rblAffected_roadwinding.SelectedValue, txtroadwidening.Text, ddlislandpartof.SelectedValue, txtstructuralenglicno.Text.Trim(), txtstructuralengname.Text.Trim(), txtstructuralmobileno.Text.Trim(), ddlcorporationname.SelectedValue, ddlwardno.SelectedValue, "", "", "", "", "", txtExcavationDepth.Text.Trim());
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + hdfID.Value + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Land Details Added Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                    this.Clear();
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Land Details Adding Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }



            }

        }
    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());

            ds = Gen.RetriveLanddata(hdfID.Value.ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["APPLIEDDATE"].ToString() == "0")
                //{

                //    if (HDNAPPLSTATUS.Value == "3")
                //    {
                //        drawingno.Visible = false;
                //        //drawing2.Visible = false;
                //        TRHEADING.Visible = false;

                //        if (ds.Tables[0].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectName"] != null)
                //        {
                //            trarchitec.Visible = true;
                //            trarchitecdwg.Visible = true;
                //            txtArchitectMobileno.Text = ds.Tables[0].Rows[0]["ArchitectMobileno"].ToString();
                //            txtArchitectName.Text = ds.Tables[0].Rows[0]["ArchitectName"].ToString();
                //            if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                //            {
                //                if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                //                {
                //                    string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                //                    txtalic2.Text = values[1].Trim();
                //                    txtalic3.Text = values[2].Trim();
                //                }

                //            }

                //        }

                //    }
                //    //else
                //    //{

                //    //    TRARCHLICNO.Visible = false;
                //    //    TRARCHLICMOBILENO.Visible = false;
                //    //    TRARCHLICNAME.Visible = false;


                //    //}
                //}
                //else
                //{

                //    if (HDNAPPRVALID2.Value == "7" || HDNAPPRVALID2.Value == "35")
                //    {
                //        TRPREDCR.Visible = false;
                //        TRARCHLICNO.Visible = false;
                //        TRARCHLICMOBILENO.Visible = false;
                //        TRARCHLICNAME.Visible = false;
                //    }
                //    else
                //    {
                //        TRPREDCR.Visible = true;
                //        TRARCHLICNO.Visible = true;
                //        TRARCHLICMOBILENO.Visible = true;
                //        TRARCHLICNAME.Visible = true;
                //    }





                //}
                if (HDNAPPRVALID2.Value == "35" || HDNAPPRVALID2.Value == "7" || HDNAPPRVALID2.Value == "31" || HDNAPPRVALID2.Value == "38")
                {
                    DataSet DSHMDADTCP = new DataSet();

                    DSHMDADTCP = GETAPPLIEDDATA_DTCPHMDA(Session["Applid"].ToString());
                    if (DSHMDADTCP.Tables[0].Rows.Count > 0)
                    {
                        HDNISPAYMENT.Value = DSHMDADTCP.Tables[0].Rows[0]["IsPayment"].ToString();
                        HDNISOFLINE.Value = DSHMDADTCP.Tables[0].Rows[0]["IsOffline"].ToString();
                        hdnstageid.Value = DSHMDADTCP.Tables[0].Rows[0]["intStageid"].ToString();
                    }
                    if (HDNAPPRVALID2.Value == "7")
                    {
                        if (HDNISOFLINE.Value == "N")
                        {
                            if (Session["Uid"].ToString() == "335162" || Session["Uid"].ToString() == "320265" || Session["Uid"].ToString() == "335486" || HDNDTCP_MUNCIPALFLAG.Value == "N")
                            {
                                drawingno.Visible = false;
                                //drawing2.Visible = false;
                                TRHEADING.Visible = false;
                                TRPLANPDF.Visible = false;
                                TRSECURITYREPORT.Visible = false;
                                if (ds.Tables[0].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectName"] != null)
                                {
                                    trarchitec.Visible = true;
                                    trarchitecdwg.Visible = true;
                                    txtArchitectMobileno.Text = ds.Tables[0].Rows[0]["ArchitectMobileno"].ToString();
                                    txtArchitectName.Text = ds.Tables[0].Rows[0]["ArchitectName"].ToString();
                                    if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                                    {
                                        if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                                        {
                                            string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                                            txtalic2.Text = values[1].Trim();
                                            txtalic3.Text = values[2].Trim();
                                        }

                                    }

                                }
                            }
                            else
                            {
                                if (HDNISPAYMENT.Value == "Y" && Convert.ToInt32(hdnstageid.Value) >= 4)
                                {
                                    if (ds.Tables[1].Rows.Count == 0)

                                    {
                                        drawingno.Visible = false;
                                        //drawing2.Visible = false;
                                        TRHEADING.Visible = false;

                                        if (ds.Tables[0].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectName"] != null)
                                        {
                                            TRARCHLICNO.Visible = true;
                                            TRARCHLICMOBILENO.Visible = true;
                                            TRARCHLICNAME.Visible = true;
                                            trarchitec.Visible = true;
                                            trarchitecdwg.Visible = true;
                                            txtArchitectMobileno.Text = ds.Tables[0].Rows[0]["ArchitectMobileno"].ToString();
                                            txtArchitectName.Text = ds.Tables[0].Rows[0]["ArchitectName"].ToString();
                                            if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                                            {
                                                if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                                                {
                                                    string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                                                    txtalic2.Text = values[1].Trim();
                                                    txtalic3.Text = values[2].Trim();
                                                }

                                            }

                                        }
                                    }
                                    else
                                    {
                                        if (ds.Tables[1].Rows.Count > 0 && (HDNAPPRVALID2.Value == "7"))
                                        {

                                            if (ds.Tables[1].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[1].Rows[0]["ArchitectName"] != null)
                                            {
                                                TRHEADING.Visible = true;
                                                drawingno.Visible = true;
                                                drawing2.Visible = true;
                                                txtSecretKey.Text = ds.Tables[1].Rows[0]["SecretKey"].ToString();
                                                txtSecretKey.Enabled = false;
                                                txtdrrefno1.Enabled = false;
                                                txtdrrefno2.Enabled = false;
                                                txtdrrefno3.Enabled = false;

                                                if (ds.Tables[1].Rows[0]["DrawingNo"].ToString().Contains("/"))
                                                {
                                                    string[] values = ds.Tables[1].Rows[0]["DrawingNo"].ToString().Split('/');
                                                    txtdrrefno1.Text = values[0].Trim();
                                                    txtdrrefno2.Text = values[1].Trim();
                                                    txtdrrefno3.Text = values[2].Trim();
                                                }

                                                trarchitec.Visible = true;
                                                trarchitecdwg.Visible = true;
                                                TRARCHLICMOBILENO.Visible = false;
                                                TRARCHLICNAME.Visible = false;
                                                TRARCHLICNO.Visible = false;

                                                TRPLANPDF.Visible = true;
                                                TRSECURITYREPORT.Visible = true;

                                            }

                                        }

                                    }

                                }
                                else
                                {
                                    TRPREDCR.Visible = false;
                                    TRARCHLICNO.Visible = false;
                                    TRARCHLICMOBILENO.Visible = false;
                                    TRARCHLICNAME.Visible = false;
                                    drawingno.Visible = true;
                                    drawing2.Visible = true;
                                    TRHEADING.Visible = true;
                                    if (ds.Tables[1].Rows.Count > 0)
                                    {
                                        if (ds.Tables[1].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[1].Rows[0]["ArchitectName"] != null)
                                        {
                                            TRHEADING.Visible = true;
                                            drawingno.Visible = true;
                                            drawing2.Visible = true;
                                            txtSecretKey.Text = ds.Tables[1].Rows[0]["SecretKey"].ToString();
                                            txtSecretKey.Enabled = false;
                                            txtdrrefno1.Enabled = false;
                                            txtdrrefno2.Enabled = false;
                                            txtdrrefno3.Enabled = false;

                                            if (ds.Tables[1].Rows[0]["DrawingNo"].ToString().Contains("/"))
                                            {
                                                string[] values = ds.Tables[1].Rows[0]["DrawingNo"].ToString().Split('/');
                                                txtdrrefno1.Text = values[0].Trim();
                                                txtdrrefno2.Text = values[1].Trim();
                                                txtdrrefno3.Text = values[2].Trim();
                                            }

                                            trarchitec.Visible = true;
                                            trarchitecdwg.Visible = true;
                                            TRARCHLICMOBILENO.Visible = false;
                                            TRARCHLICNAME.Visible = false;
                                            TRARCHLICNO.Visible = false;

                                            TRPLANPDF.Visible = true;
                                            TRSECURITYREPORT.Visible = true;

                                        }

                                    }

                                }
                            }
                        }
                        else
                        {
                            TRPREDCR.Visible = false;
                            TRARCHLICNO.Visible = false;
                            TRARCHLICMOBILENO.Visible = false;
                            TRARCHLICNAME.Visible = false;
                            drawingno.Visible = false;
                            //drawing2.Visible = false;
                            TRHEADING.Visible = false;
                        }
                    }
                    else if (HDNAPPRVALID2.Value == "35")
                    {
                        if (HDNISOFLINE.Value == "N")
                        {

                            if (HDNISPAYMENT.Value == "Y" && Convert.ToInt32(hdnstageid.Value) >= 4)
                            {
                                if (ds.Tables[1].Rows.Count == 0)

                                {
                                    drawingno.Visible = false;
                                    //drawing2.Visible = false;
                                    TRHEADING.Visible = false;

                                    if (ds.Tables[0].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectName"] != null)
                                    {
                                        TRARCHLICNO.Visible = true;
                                        TRARCHLICMOBILENO.Visible = true;
                                        TRARCHLICNAME.Visible = true;
                                        trarchitec.Visible = true;
                                        trarchitecdwg.Visible = true;
                                        txtArchitectMobileno.Text = ds.Tables[0].Rows[0]["ArchitectMobileno"].ToString();
                                        txtArchitectName.Text = ds.Tables[0].Rows[0]["ArchitectName"].ToString();
                                        if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                                        {
                                            if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                                            {
                                                string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                                                txtalic2.Text = values[1].Trim();
                                                txtalic3.Text = values[2].Trim();
                                            }

                                        }

                                    }
                                }
                                else
                                {
                                    if (ds.Tables[1].Rows.Count > 0 && (HDNAPPRVALID2.Value == "35"))
                                    {

                                        if (ds.Tables[1].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[1].Rows[0]["ArchitectName"] != null)
                                        {
                                            TRHEADING.Visible = true;
                                            drawingno.Visible = true;
                                            drawing2.Visible = true;
                                            txtSecretKey.Text = ds.Tables[1].Rows[0]["SecretKey"].ToString();
                                            txtSecretKey.Enabled = false;
                                            txtdrrefno1.Enabled = false;
                                            txtdrrefno2.Enabled = false;
                                            txtdrrefno3.Enabled = false;

                                            if (ds.Tables[1].Rows[0]["DrawingNo"].ToString().Contains("/"))
                                            {
                                                string[] values = ds.Tables[1].Rows[0]["DrawingNo"].ToString().Split('/');
                                                txtdrrefno1.Text = values[0].Trim();
                                                txtdrrefno2.Text = values[1].Trim();
                                                txtdrrefno3.Text = values[2].Trim();
                                            }

                                            trarchitec.Visible = true;
                                            trarchitecdwg.Visible = true;
                                            TRARCHLICMOBILENO.Visible = false;
                                            TRARCHLICNAME.Visible = false;
                                            TRARCHLICNO.Visible = false;

                                            TRPLANPDF.Visible = true;
                                            TRSECURITYREPORT.Visible = true;

                                        }

                                    }

                                }

                            }
                            else
                            {
                                TRPREDCR.Visible = false;
                                TRARCHLICNO.Visible = false;
                                TRARCHLICMOBILENO.Visible = false;
                                TRARCHLICNAME.Visible = false;
                                drawingno.Visible = true;
                                drawing2.Visible = true;
                                TRHEADING.Visible = true;
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    if (ds.Tables[1].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[1].Rows[0]["ArchitectName"] != null)
                                    {
                                        TRHEADING.Visible = true;
                                        drawingno.Visible = true;
                                        drawing2.Visible = true;
                                        txtSecretKey.Text = ds.Tables[1].Rows[0]["SecretKey"].ToString();
                                        txtSecretKey.Enabled = false;
                                        txtdrrefno1.Enabled = false;
                                        txtdrrefno2.Enabled = false;
                                        txtdrrefno3.Enabled = false;

                                        if (ds.Tables[1].Rows[0]["DrawingNo"].ToString().Contains("/"))
                                        {
                                            string[] values = ds.Tables[1].Rows[0]["DrawingNo"].ToString().Split('/');
                                            txtdrrefno1.Text = values[0].Trim();
                                            txtdrrefno2.Text = values[1].Trim();
                                            txtdrrefno3.Text = values[2].Trim();
                                        }

                                        trarchitec.Visible = true;
                                        trarchitecdwg.Visible = true;
                                        TRARCHLICMOBILENO.Visible = false;
                                        TRARCHLICNAME.Visible = false;
                                        TRARCHLICNO.Visible = false;

                                        TRPLANPDF.Visible = true;
                                        TRSECURITYREPORT.Visible = true;

                                    }

                                }

                            }

                        }
                        else
                        {
                            TRPREDCR.Visible = false;
                            TRARCHLICNO.Visible = false;
                            TRARCHLICMOBILENO.Visible = false;
                            TRARCHLICNAME.Visible = false;
                            drawingno.Visible = false;
                            //drawing2.Visible = false;
                            TRHEADING.Visible = false;
                        }
                    }
                    else
                    {
                        if (HDNISOFLINE.Value == "N")
                        {
                            drawingno.Visible = false;
                            //drawing2.Visible = false;
                            TRHEADING.Visible = false;
                            TRPLANPDF.Visible = false;
                            TRSECURITYREPORT.Visible = false;
                            if (ds.Tables[0].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectName"] != null)
                            {
                                trarchitec.Visible = true;
                                trarchitecdwg.Visible = true;
                                txtArchitectMobileno.Text = ds.Tables[0].Rows[0]["ArchitectMobileno"].ToString();
                                txtArchitectName.Text = ds.Tables[0].Rows[0]["ArchitectName"].ToString();
                                if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                                {
                                    if (ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                                    {
                                        string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                                        txtalic2.Text = values[1].Trim();
                                        txtalic3.Text = values[2].Trim();
                                    }

                                }

                            }

                        }

                    }

                }
                else
                {
                    TRPREDCR.Visible = false;
                    TRARCHLICNO.Visible = false;
                    TRARCHLICMOBILENO.Visible = false;
                    TRARCHLICNAME.Visible = false;
                    drawingno.Visible = false;
                    //drawing2.Visible = false;
                    TRHEADING.Visible = false;

                }

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFELandid"].ToString();
                if (ds.Tables[0].Rows[0]["intProposedCateogryid"].ToString().Trim() != "")
                {
                    ddlintProposedCateogryid.SelectedValue = ddlintProposedCateogryid.Items.FindByValue(ds.Tables[0].Rows[0]["intProposedCateogryid"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["intApplicationTypeid"].ToString().Trim() != "")
                {

                    ddlintApplicationTypeid.SelectedValue = ddlintApplicationTypeid.Items.FindByValue(ds.Tables[0].Rows[0]["intApplicationTypeid"].ToString().Trim()).Value;
                }

                if (ddlintApplicationTypeid.SelectedIndex == 0)
                {
                    // ChangeofLandUse.Visible = false;
                    Acceptance.Visible = false;
                    IndustrialBuildingApproval.Visible = false;
                }
                if (ddlintApplicationTypeid.SelectedIndex == 1)
                {
                    // ChangeofLandUse.Visible = true;
                    // Acceptance.Visible = true;
                    IndustrialBuildingApproval.Visible = false;
                }
                if (ddlintApplicationTypeid.SelectedIndex == 2)
                {
                    //  ChangeofLandUse.Visible = false;
                    //  Acceptance.Visible = true;
                    // IndustrialBuildingApproval.Visible = true;
                }
                if (ddlintApplicationTypeid.SelectedIndex == 3)
                {
                    //  ChangeofLandUse.Visible = true;
                    //  Acceptance.Visible = true;
                    //  IndustrialBuildingApproval.Visible = true;
                }
                if (ddlintApplicationTypeid.SelectedIndex == 4)
                {
                    //  ChangeofLandUse.Visible = false;
                    //  Acceptance.Visible = false;
                    IndustrialBuildingApproval.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["FromZone"].ToString().Trim() != "")
                {

                    ddlFromZone.SelectedValue = ddlFromZone.Items.FindByValue(ds.Tables[0].Rows[0]["FromZone"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["ToZone"].ToString().Trim() != "")
                {
                    ddlToZone.SelectedValue = ddlToZone.Items.FindByValue(ds.Tables[0].Rows[0]["ToZone"].ToString().Trim()).Value;
                }


                // txtLocationNameIEIDA.Text = ds.Tables[0].Rows[0]["LocationNameIEIDA"].ToString();
                if (ds.Tables[0].Rows[0]["IsSitePlaning"].ToString().Trim() != "")
                {
                    // rblIsSitePlanning.SelectedValue = rblIsSitePlanning.Items.FindByValue(ds.Tables[0].Rows[0]["IsSitePlaning"].ToString().Trim()).Value;
                }
                txtSurveyNo.Text = ds.Tables[0].Rows[0]["SurveyNo"].ToString();
                txtName_Gramapachayat.Text = ds.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                txtLand_Pincode.Text = ds.Tables[0].Rows[0]["Land_Pincode"].ToString();
                txtLand_Email.Text = ds.Tables[0].Rows[0]["Land_Email"].ToString();
                txtLand_TelephoneNumber.Text = ds.Tables[0].Rows[0]["Land_TelephoneNumber"].ToString();
                //txtLand_TotExtent.Text= ds.Tables[0].Rows[0]["Land_TotExtent"].ToString();
                txtLand_ProposedArea.Text = ds.Tables[0].Rows[0]["Land_ProposedArea"].ToString();
                //       txtLand_BuiltupArea.Text= ds.Tables[0].Rows[0]["Land_BuiltupArea"].ToString();
                txtLand_Existingwidth.Text = ds.Tables[0].Rows[0]["Land_Existingwidth"].ToString();
                if (ds.Tables[0].Rows[0]["intTypeofApprochid"].ToString().Trim() != "")
                {
                    ddlintTypeofApprochid.SelectedValue = ddlintTypeofApprochid.Items.FindByValue(ds.Tables[0].Rows[0]["intTypeofApprochid"].ToString().Trim()).Value;
                }
                //if (ds.Tables[0].Rows[0]["intLocationFalls"].ToString().Trim() != "")
                //{
                //    ddlintLocationFalls.SelectedValue = ddlintLocationFalls.Items.FindByValue(ds.Tables[0].Rows[0]["intLocationFalls"].ToString().Trim()).Value;
                //}
                if (ds.Tables[0].Rows[0]["intBuildingApproval"].ToString().Trim() != "")
                {
                    ddlintBuildingApproval.SelectedValue = ddlintBuildingApproval.Items.FindByValue(ds.Tables[0].Rows[0]["intBuildingApproval"].ToString().Trim()).Value;
                }

                //if (ds.Tables[0].Rows[0]["intIndustryProduct"].ToString().Trim() != "")
                //{
                //    ddlintIndustryProduct.SelectedValue = ddlintIndustryProduct.Items.FindByValue(ds.Tables[0].Rows[0]["intIndustryProduct"].ToString()).Value;
                //}

                //if (ds.Tables[0].Rows[0]["intCategoryid"].ToString().Trim()!= "")
                //{
                //    ddlintCategoryid.SelectedValue = ddlintCategoryid.Items.FindByValue(ds.Tables[0].Rows[0]["intCategoryid"].ToString()).Value;
                //}

                //ds.Tables[0].Rows[0]["GoogleMaptoUploadFile"].ToString();
                //ds.Tables[0].Rows[0]["GoogleMapFilePath"].ToString();
                txtGeo_Cordinate_Latitude.Text = ds.Tables[0].Rows[0]["Geo_Cordinate_Latitude"].ToString();
                txtGeo_Cordinate_Langitude.Text = ds.Tables[0].Rows[0]["Geo_Cordinate_Langitude"].ToString();
                // ds.Tables[0].Rows[0]["KMLFileName"].ToString();
                // ds.Tables[0].Rows[0]["KMLFilePath"].ToString();
                if (ds.Tables[0].Rows[0]["Covered_revenueSketch"].ToString().Trim() != "")
                {
                    rblCovered_revenueSketch.SelectedValue = rblCovered_revenueSketch.Items.FindByValue(ds.Tables[0].Rows[0]["Covered_revenueSketch"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["Covered_Adjoining"].ToString().Trim() != "")
                {
                    rblCovered_Adjoining.SelectedValue = rblCovered_Adjoining.Items.FindByValue(ds.Tables[0].Rows[0]["Covered_Adjoining"].ToString().Trim()).Value;
                }
                txtPlot_Number.Text = ds.Tables[0].Rows[0]["Plot_Number"].ToString();
                txtSanction_LayoutNo.Text = ds.Tables[0].Rows[0]["Sanction_LayoutNo"].ToString();
                txtLand_User_MasterPlan.Text = ds.Tables[0].Rows[0]["Land_User_MasterPlan"].ToString();
                if (ds.Tables[0].Rows[0]["Hight_Building"].ToString() != null && ds.Tables[0].Rows[0]["Hight_Building"].ToString().Trim() != "")
                {
                    txtHight_Building.Text = ds.Tables[0].Rows[0]["Hight_Building"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Affected_roadwinding"].ToString().Trim() != "")
                {
                    rblAffected_roadwinding.SelectedValue = rblAffected_roadwinding.Items.FindByValue(ds.Tables[0].Rows[0]["Affected_roadwinding"].ToString().Trim()).Value;
                }
                txtGeo_Cordinate_Latitude1.Text = ds.Tables[0].Rows[0]["Geo_Cordinate_Latitude1"].ToString();
                txtGeo_Cordinate_Langitude1.Text = ds.Tables[0].Rows[0]["Geo_Cordinate_Langitude1"].ToString();
                if (ds.Tables[0].Rows[0]["typeofbuilding"].ToString().Trim() != "")
                {
                    ddltypeofbuilding.SelectedValue = ddltypeofbuilding.Items.FindByValue(ds.Tables[0].Rows[0]["typeofbuilding"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["landaspermasterplan"].ToString().Trim() != "")
                {
                    ddllandaspermasterplan.SelectedValue = ddllandaspermasterplan.Items.FindByValue(ds.Tables[0].Rows[0]["landaspermasterplan"].ToString().Trim()).Value;
                }
                if (ds.Tables[0].Rows[0]["islandpartof"].ToString().Trim() != "")
                {
                    ddlislandpartof.SelectedValue = ddlislandpartof.Items.FindByValue(ds.Tables[0].Rows[0]["islandpartof"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["StructuralLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["StructuralLicenseno"] != null)
                {
                    txtstructuralenglicno.Text = ds.Tables[0].Rows[0]["StructuralLicenseno"].ToString();
                }
                txtstructuralmobileno.Text = ds.Tables[0].Rows[0]["StructuralMobileno"].ToString();
                txtstructuralengname.Text = ds.Tables[0].Rows[0]["StructuralName"].ToString();


                EventArgs e = new EventArgs();
                object sender = new object();
                txtHight_Building_TextChanged(sender, e);
                if (ds.Tables[1].Rows.Count > 0 && (HDNAPPRVALID2.Value == "7" || HDNAPPRVALID2.Value == "35"))
                {
                    string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];

                    if (ds.Tables[1].Rows[0]["ArchitectName"].ToString() != "" && ds.Tables[1].Rows[0]["ArchitectName"] != null)
                    {
                        TRHEADING.Visible = true;
                        drawingno.Visible = true;
                        drawing2.Visible = true;
                        txtSecretKey.Text = ds.Tables[1].Rows[0]["SecretKey"].ToString();
                        txtSecretKey.Enabled = false;
                        txtdrrefno1.Enabled = false;
                        txtdrrefno2.Enabled = false;
                        txtdrrefno3.Enabled = false;

                        if (ds.Tables[1].Rows[0]["DrawingNo"].ToString().Contains("/"))
                        {
                            string[] values = ds.Tables[1].Rows[0]["DrawingNo"].ToString().Split('/');
                            txtdrrefno1.Text = values[0].Trim();
                            txtdrrefno2.Text = values[1].Trim();
                            txtdrrefno3.Text = values[2].Trim();
                        }

                        trarchitec.Visible = true;
                        trarchitecdwg.Visible = true;
                        TRARCHLICMOBILENO.Visible = false;
                        TRARCHLICNAME.Visible = false;
                        TRARCHLICNO.Visible = false;
                        //txtArchitectMobileno.Text = ds.Tables[1].Rows[0]["ArchitectMobileno"].ToString();
                        //txtArchitectMobileno.Enabled = false;
                        //txtArchitectName.Text = ds.Tables[1].Rows[0]["ArchitectName"].ToString();
                        //txtArchitectName.Enabled = false;

                        // txtalic3.Text = ds.Tables[1].Rows[0]["ArchitectLicenseno"].ToString();
                        // txtalic3.Enabled = false;
                        TRPLANPDF.Visible = true;
                        TRSECURITYREPORT.Visible = true;
                        //if (ds.Tables[1].Rows[0]["ArchitectLicenseno"].ToString() != "" && ds.Tables[0].Rows[0]["ArchitectLicenseno"] != null)
                        //{
                        //    if (ds.Tables[1].Rows[0]["ArchitectLicenseno"].ToString().Contains("/"))
                        //    {
                        //        string[] values = ds.Tables[0].Rows[0]["ArchitectLicenseno"].ToString().Split('/');
                        //        txtalic2.Text = values[1].Trim();
                        //        txtalic3.Text = values[2].Trim();
                        //    }

                        //}

                    }
                    //txtSecretKey_TextChanged(null, EventArgs.Empty);
                    //if (ds.Tables[1].Rows[0]["PlanPDFBase64"].ToString() != "" && ds.Tables[1].Rows[0]["PlanPDFBase64"] != null)
                    //{
                    //    string newPathPlanPDFBase64 = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PlanPDFBase64");

                    //    string planPdfFilePath = Path.Combine(newPathPlanPDFBase64, "Plan.pdf");                        // Convert Base64 to PDF and save to the specified paths
                    //    Base64ToPdfConverter.ConvertBase64ToPdf(ds.Tables[1].Rows[0]["PlanPDFBase64"].ToString(), planPdfFilePath);
                    //    planPdfFilePath = planPdfFilePath.Replace(@"\", @"/");
                    //    planPdfFilePath = planPdfFilePath.Replace(@"G:/TS-iPASSFinal/", "~/TS-iPASSAttachments/");
                    //    HypPlan.NavigateUrl = planPdfFilePath;
                    //}

                    //if (ds.Tables[1].Rows[0]["ScrutinyReportBase64"].ToString() != "" && ds.Tables[1].Rows[0]["ScrutinyReportBase64"] != null)
                    //{
                    //    string scrutinyReportFilePath = Path.Combine(sFileDir, "ScrutinyReport.html");// "path/to/save/ScrutinyReport.pdf";  // Specify a valid path for the Scrutiny Report PDF

                    //    // Convert Base64 to PDF and save to the specified paths

                    //    Base64ToPdfConverter.ConvertBase64ToPdf(ds.Tables[1].Rows[0]["ScrutinyReportBase64"].ToString(), scrutinyReportFilePath);
                    //    scrutinyReportFilePath = scrutinyReportFilePath.Replace(@"\", @"/");
                    //    scrutinyReportFilePath = scrutinyReportFilePath.Replace(@"G:/TS-iPASSFinal/", "~/TS-iPASSAttachments/");
                    //    HypScrutiny.NavigateUrl = scrutinyReportFilePath;
                    //}
                    if (ds.Tables[1].Rows[0]["PlanPDFBase64"].ToString() != "" && ds.Tables[1].Rows[0]["PlanPDFBase64"] != null)
                    {
                        //string newPathPlanPDFBase64 = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\PlanPDFBase64");

                        //string planPdfFilePath = Path.Combine(newPathPlanPDFBase64, "Plan.pdf");                        // Convert Base64 to PDF and save to the specified paths
                        //Base64ToPdfConverter.ConvertBase64ToPdf(ds.Tables[1].Rows[0]["PlanPDFBase64"].ToString(), planPdfFilePath);
                        string planPdfFilePath = Convert.ToString(ds.Tables[1].Rows[0]["PlanPath"]).Replace(@"\", @"/");
                        planPdfFilePath = planPdfFilePath.Replace(@"G:/TS-iPASSFinal/", "~/TS-iPASSAttachments/");
                        HypPlan.NavigateUrl = planPdfFilePath;
                    }

                    if (ds.Tables[1].Rows[0]["ScrutinyReportBase64"].ToString() != "" && ds.Tables[1].Rows[0]["ScrutinyReportBase64"] != null)
                    {
                        //string scrutinyReportFilePath = Path.Combine(sFileDir, "ScrutinyReport.html");// "path/to/save/ScrutinyReport.pdf";  // Specify a valid path for the Scrutiny Report PDF

                        // Convert Base64 to PDF and save to the specified paths

                        //Base64ToPdfConverter.ConvertBase64ToPdf(ds.Tables[1].Rows[0]["ScrutinyReportBase64"].ToString(), scrutinyReportFilePath);
                        string scrutinyReportFilePath = Convert.ToString(ds.Tables[1].Rows[0]["ScrutinyPath"]).Replace(@"\", @"/");
                        scrutinyReportFilePath = scrutinyReportFilePath.Replace(@"G:/TS-iPASSFinal/", "~/TS-iPASSAttachments/");
                        HypScrutiny.NavigateUrl = scrutinyReportFilePath;
                    }

                }
            }
            DataSet dsnew = new DataSet();
            dsnew = Gen.ViewAttachmetsData(hdfID.Value.ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                int c = dsnew.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    //sen = sen1.Replace(@"D:/RAJESHP/TS-iPASSnew09042016/TS-iPASS/", "~/");


                    //string other;
                    //if (txtOthers.Text == "" || txtOthers.Text == null)
                    //    other = ddlAttachmentType.SelectedItem.Text;
                    //else
                    //    other = txtOthers.Text;
                    // AddDataToTableCeertificate(other, txtDescription.Text, sFileName, (DataTable)Session["CertificateTb"]);



                    if (sen.Contains("GoogleMaptoUpload"))
                    {
                        lblFileName.NavigateUrl = sen;
                        lblFileName.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label455.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("KML File"))
                    {
                        lblFileName2.NavigateUrl = sen;
                        lblFileName2.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label456.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("KML FILE1"))
                    {
                        lblFileName1.NavigateUrl = sen;
                        lblFileName1.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label457.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("CombinedbuildingplanDWG"))
                    {
                        HyperLink1.NavigateUrl = sen;
                        HyperLink1.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label6.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("CommonAffidavit"))
                    {
                        HyperLink2.NavigateUrl = sen;
                        HyperLink2.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label8.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }


                    if (sen.Contains("NOCFireDept"))
                    {
                        HyperLink3.NavigateUrl = sen;
                        HyperLink3.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label10.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("CLUProforma"))
                    {
                        HyperLink4.NavigateUrl = sen;
                        HyperLink4.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        Label12.Text = dsnew.Tables[0].Rows[i][1].ToString();
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

    public DataSet GETAPPLIEDDATA_DTCPHMDA(string intquesid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETAPPLIEDDATA_DTCPHMDA", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intquesid.Trim() == "" || intquesid.Trim() == null)
                da.SelectCommand.Parameters.Add("@INTQUESTID", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@INTQUESTID", SqlDbType.VarChar).Value = intquesid.ToString();

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

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmLandDetails.aspx");
        Clear();
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getcounties()
    {

    }
    protected void ddlCounties_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    void getPayams()
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
            if (BtnSave1.Text == "Save")
            {






            }
            else
            {


            }
        }
        catch (Exception ex)
        {
            //  lblresult.Text = ex.ToString();

        }
        finally
        {
        }
    }



    protected void GetNewRectoInsertdr()
    {

    }
    protected void txtcontact20_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact12_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus27_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtLand_TelephoneNumber_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus17_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus23_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus24_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus25_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstatus26_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact36_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList9_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if (FileUpload4.HasFile)
        {
            if (FileUpload4.PostedFile.FileName.Contains("'") == true || FileUpload4.PostedFile.FileName.Contains("/") == true
               || FileUpload4.PostedFile.FileName.Contains("*") == true || FileUpload4.PostedFile.FileName.Contains("$") == true
               || FileUpload4.PostedFile.FileName.Contains("^") == true || FileUpload4.PostedFile.FileName.Contains("#") == true
               || FileUpload4.PostedFile.FileName.Contains("&") == true)
            {
                lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                try
                {
                    //if (fupGoogleMaptoUploadFile.PostedFile.ContentLength <= lMaxFileSize)
                    //{
                    //    //Save File on disk


                    //if (fupGoogleMaptoUploadFile.FileContent.Length > 102400 * 18)
                    //{
                    //     lblmsg0.Text = "size should be less than 600KB";
                    //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                    //    return;
                    //}

                    string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToString().Trim() == "PNG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\GoogleMaptoUpload");
                        ViewState["pathGeo"] = newPath;
                        ViewState["GeoName"] = sFileName;
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }
                        int result = 0;
                        result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Google Map to Upload", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            HyperLink5.Text = FileUpload4.FileName;
                            Label144.Text = FileUpload4.FileName;
                            //lblFileName.Text = fupGoogleMaptoUploadFile.FileName;
                            //Label455.Text = fupGoogleMaptoUploadFile.FileName;
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
                        lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
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
    protected void BtnSave6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((fupKMLFileName.PostedFile != null) && (fupKMLFileName.PostedFile.ContentLength > 0))
        {
            if (fupKMLFileName.PostedFile.FileName.Contains("'") == true || fupKMLFileName.PostedFile.FileName.Contains("/") == true
               || fupKMLFileName.PostedFile.FileName.Contains("*") == true || fupKMLFileName.PostedFile.FileName.Contains("$") == true
               || fupKMLFileName.PostedFile.FileName.Contains("^") == true || fupKMLFileName.PostedFile.FileName.Contains("#") == true
               || fupKMLFileName.PostedFile.FileName.Contains("&") == true)
            {
                lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupKMLFileName.PostedFile.FileName);
            KMPFileName = sFileName;
            try
            {
                //if (fupGoogleMaptoUploadFile.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (fupGoogleMaptoUploadFile.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = fupKMLFileName.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                //Response.Write(fileType[i - 1].ToUpper().Trim());
                //return;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToString().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "KML" || fileType[i - 1].ToString().Trim().ToUpper() == "KMZ")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\KML File");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupKMLFileName.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupKMLFileName.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    KMPFilepath = newPath + "\\" + sFileName;
                    int result = 0;

                    //     result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "KML File", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "KML File", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblmsg.Visible = false;
                        lblFileName2.Text = fupKMLFileName.FileName;
                        Label456.Text = fupKMLFileName.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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


    protected void BtnSave5_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((fupKMLFileName1.PostedFile != null) && (fupKMLFileName1.PostedFile.ContentLength > 0))
        {
            if (fupKMLFileName1.PostedFile.FileName.Contains("'") == true || fupKMLFileName1.PostedFile.FileName.Contains("/") == true
               || fupKMLFileName1.PostedFile.FileName.Contains("*") == true || fupKMLFileName1.PostedFile.FileName.Contains("$") == true
               || fupKMLFileName1.PostedFile.FileName.Contains("^") == true || fupKMLFileName1.PostedFile.FileName.Contains("#") == true
               || fupKMLFileName.PostedFile.FileName.Contains("&") == true)
            {
                lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupKMLFileName1.PostedFile.FileName);
            KMPFileName1 = sFileName;
            try
            {
                //if (fupGoogleMaptoUploadFile.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (fupGoogleMaptoUploadFile.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = fupKMLFileName1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToString().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "KML" || fileType[i - 1].ToString().Trim() == "KMZ")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\KML FILE1");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        fupKMLFileName1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            fupKMLFileName1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    KMPFilepath1 = newPath + "\\" + sFileName;
                    int result = 0;

                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "KML FILE1", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "Attachment Successfully Added";
                        lblmsg.Visible = true;
                        lblFileName1.Text = fupKMLFileName1.FileName;
                        Label457.Text = fupKMLFileName1.FileName;
                        lblmsg.Visible = false;
                        success.Visible = true;
                        Failure.Visible = false;
                        Response.Write("<script>alert('Attachment Successfully Added')</script> ");



                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "Attachment Added Failed";
                        lblmsg0.Visible = true;
                        lblmsg.Visible = false;
                        success.Visible = false;
                        Failure.Visible = true;
                        Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "Upload PDF,Doc,JPG files only..!";
                    lblmsg0.Visible = true;
                    lblmsg.Visible = false;
                    success.Visible = false;
                    Failure.Visible = true;
                    Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
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
    protected void ddlLand_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLand_intMandalid.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlLand_intVillageid.Items.Clear();
            ddlLand_intVillageid.Items.Insert(0, "--Select--");

        }
    }
    protected void ddlLand_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLand_intDistrictid.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }
    protected void ddlintApplicationTypeid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlintApplicationTypeid.SelectedIndex == 0)
        {
            ChangeofLandUse.Visible = false;
            Acceptance.Visible = false;
            IndustrialBuildingApproval.Visible = false;
        }
        if (ddlintApplicationTypeid.SelectedIndex == 1)
        {
            // ChangeofLandUse.Visible = true;
            // Acceptance.Visible = true;
            IndustrialBuildingApproval.Visible = false;
        }
        if (ddlintApplicationTypeid.SelectedIndex == 2)
        {
            ChangeofLandUse.Visible = false;
            // Acceptance.Visible = true;
            // IndustrialBuildingApproval.Visible = true;
        }
        if (ddlintApplicationTypeid.SelectedIndex == 3)
        {
            //  ChangeofLandUse.Visible = true;
            //  Acceptance.Visible = true;
            // IndustrialBuildingApproval.Visible = true;
        }
        if (ddlintApplicationTypeid.SelectedIndex == 4)
        {
            ChangeofLandUse.Visible = false;
            //  Acceptance.Visible = false;
            IndustrialBuildingApproval.Visible = false;
        }



    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmEntrepreneurDetails.aspx?intApplicationId=" + Session["Applid"].ToString());// + hdfID.Value
    }

    public void BindLineofActivityName()
    {
        try
        {
            ddlintIndustryProduct.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDetNew(Session["uid"].ToString().Trim());
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlintIndustryProduct.DataSource = dsc.Tables[0];
                ddlintIndustryProduct.DataValueField = "intLineofActivityid";
                ddlintIndustryProduct.DataTextField = "LineofActivity_Name";
                ddlintIndustryProduct.DataBind();
                ddlintIndustryProduct.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlintIndustryProduct.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    protected void ddllandaspermasterplan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddllandaspermasterplan.SelectedValue == "8")
        {
            trlandmasterplanother.Visible = true;
        }
        else
        {
            trlandmasterplanother.Visible = false;
        }
    }
    protected void rblAffected_roadwinding_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblAffected_roadwinding.SelectedValue == "Y")
        {
            trraodwidening.Visible = true;
        }
        else
        {
            trraodwidening.Visible = false;
        }

    }
    protected void ddltypeofbuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltypeofbuilding.SelectedValue == "4")
        {
            trtypeofbuildingother.Visible = true;
        }
        else
        {
            trtypeofbuildingother.Visible = false;
        }
    }
    protected void txtHight_Building_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtHight_Building.Text.Trim()) > Convert.ToDecimal("10"))
        {
            trstructuralengname.Visible = true;
            trstructuralengmobileno.Visible = true;
            trstructuralenglicno.Visible = true;
        }
        else
        {
            trstructuralengname.Visible = false;
            trstructuralengmobileno.Visible = false;
            trstructuralenglicno.Visible = false;
        }

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        //string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];
        General t1 = new General();
        if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
        {
            if (FileUpload5.PostedFile.FileName.Contains("'") == true || FileUpload5.PostedFile.FileName.Contains("/") == true
                    || FileUpload5.PostedFile.FileName.Contains("*") == true || FileUpload5.PostedFile.FileName.Contains("$") == true
                    || FileUpload5.PostedFile.FileName.Contains("^") == true || FileUpload5.PostedFile.FileName.Contains("#") == true
                    || FileUpload5.PostedFile.FileName.Contains("&") == true)
            {
                lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "DWG")
                if (fileType[i - 1].ToUpper().Trim() == "DWG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\CombinedbuildingplanDWG");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Combined building plan including all floor plans DWG", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label6.Text = FileUpload5.FileName;
                        Label447.Text = FileUpload5.FileName;
                        HyperLink1.Text = FileUpload5.FileName;
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
                    lblmsg0.Text = "<font color='red'>Upload DWG files only..!</font>";
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

    protected void txtalic2_TextChanged(object sender, EventArgs e)
    {
        if (txtalic2.Text.Trim() != "")
        {
            if (txtalic2.Text.Length == 4)
            {
                int articyear = 0;
                articyear = Convert.ToInt16(txtalic2.Text.Trim());
                if (articyear > 1900 && articyear <= DateTime.Now.Year)
                {

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    SetFocus(txtalic2);
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please enter Correct Year..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                SetFocus(txtalic2);
            }
        }
    }

    protected void txtalic3_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtalic2.Text.Trim() != null && txtalic2.Text.Trim() != "")
            {
                if (txtalic3.Text.Trim() != null && txtalic3.Text.Trim() != "")
                {
                    string licenseno = txtalic1.Text.Trim() + "/" + txtalic2.Text.Trim() + "/" + txtalic3.Text.Trim();
                    hmdapplication = hmdaservice.getArchitectDetails(licenseno, "$$08@213");
                    if (hmdapplication.Error == "")
                    {
                        if (hmdapplication.Name != "" && hmdapplication.Name != null)
                        {
                            txtArchitectName.Text = hmdapplication.Name;
                            txtArchitectName.Enabled = false;
                        }
                        else
                        {
                            txtArchitectName.Enabled = true;
                        }
                        if (hmdapplication.MobileNo != "" && hmdapplication.MobileNo != null)
                        {
                            txtArchitectMobileno.Text = hmdapplication.MobileNo;
                            txtArchitectMobileno.Enabled = false;
                        }
                        else
                        {
                            txtArchitectMobileno.Enabled = true;
                        }


                    }

                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    void getCorportaions()
    {

        DataSet dsnew = new DataSet();
        try
        {
            dsnew = Gen.GetCorporationbydistrict(ddlLand_intDistrictid.SelectedValue.ToString());
            ddlcorporationname.DataSource = dsnew.Tables[0];
            ddlcorporationname.DataTextField = "CorporationName";
            ddlcorporationname.DataValueField = "CorporationID";
            ddlcorporationname.DataBind();
            ddlcorporationname.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {

        }

    }

    void getWards()
    {

        DataSet dsnew = new DataSet();
        try
        {
            dsnew = Gen.Getwardbycorporation(ddlcorporationname.SelectedValue.ToString());
            ddlwardno.DataSource = dsnew.Tables[0];
            ddlwardno.DataTextField = "LocationName";
            ddlwardno.DataValueField = "LocationID";
            ddlwardno.DataBind();
            ddlwardno.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {

        }

    }
    protected void ddlcorporationname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlcorporationname.SelectedValue.ToString() != "--Select--")
            {
                getWards();
            }
            else
            {
                ddlwardno.Items.Clear();
                ddlwardno.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void btnNOC_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        // string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];

        General t1 = new General();
        if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "DWG")
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\NOCFireDept");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "NOC From FIRE Dept", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label10.Text = FileUpload2.FileName;
                        Label447.Text = FileUpload2.FileName;
                        HyperLink3.Text = FileUpload2.FileName;
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
                    lblmsg0.Text = "<font color='red'>Upload pdf files only..!</font>";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        // string sFileDir = Server.MapPath("~\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];

        General t1 = new General();
        if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
        {
            if (FileUpload3.PostedFile.FileName.Contains("'") == true || FileUpload3.PostedFile.FileName.Contains("/") == true
                    || FileUpload3.PostedFile.FileName.Contains("*") == true || FileUpload3.PostedFile.FileName.Contains("$") == true
                    || FileUpload3.PostedFile.FileName.Contains("^") == true || FileUpload3.PostedFile.FileName.Contains("#") == true
                    || FileUpload3.PostedFile.FileName.Contains("&") == true)
            {
                lblmsg0.Text = "<font color='red'>Document Name should not contain (',/,*,$,^,#, &)..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "DWG")
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\CLUProforma");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CLUProforma", "", Session["uid"].ToString(), DateTime.Now.ToString(),
                        "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label12.Text = FileUpload3.FileName;

                        HyperLink4.Text = FileUpload3.FileName;
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
                    lblmsg0.Text = "<font color='red'>Upload pdf files only..!</font>";
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
    protected void btnCommonAffidavit_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        //string sFileDir = Server.MapPath("G:\\TS-iPASSFinal\\Attachments");
        string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];  //Server.MapPath("~\\Attachments");

        General t1 = new General();
        if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
            try
            {
                //if (FileUpload1.PostedFile.ContentLength <= lMaxFileSize)
                //{
                //    //Save File on disk


                //if (FileUpload1.FileContent.Length > 102400 * 18)
                //{
                //     lblmsg0.Text = "size should be less than 600KB";
                //     Response.Write("<script>alert('size should be less than 600KB')</script> ");
                //    return;
                //}

                string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG" || fileType[i - 1].ToUpper().Trim() == "DWG")
                if (fileType[i - 1].ToUpper().Trim() == "PDF")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\CommonAffidavit");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }

                    int result = 0;
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "Common Affidavit", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        Label8.Text = FileUpload1.FileName;
                        Label447.Text = FileUpload1.FileName;
                        HyperLink2.Text = FileUpload1.FileName;
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
                    lblmsg0.Text = "<font color='red'>Upload pdf files only..!</font>";
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
    protected async void txtSecretKey_TextChanged(object sender, EventArgs e)
    {

        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
        string secretKey = txtSecretKey.Text;
        string url = "https://uat-apis.buildnow.floww.ai/integrations/ipass/scrutiny_report/v1/";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("X-API-Key", "VUOApTUxK045LVELPgvRWMKEaeAVKxW1wrr8a844");

            var json = "{ \"scrutiny_key\": \"" + secretKey + "\" }";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                int DrawingResult = 0;
                string responseObject1 = JsonConvert.DeserializeObject(responseJson).ToString();
                BuildnowResponse responseObject = JsonConvert.DeserializeObject<BuildnowResponse>(responseJson);

                DrawingResult = InsertBuildnowDrawingDetails(responseObject1, Session["uid"].ToString().Trim());
                if (DrawingResult > 0)
                {
                    bool success = await DownloadAndSaveAttachments(responseObject, Session["uid"].ToString().Trim());
                    if (success)
                    {
                        FillDetails_SCRUTINYATTACHMENTS();
                    }
                }
            }
            else
            {
            }
        }
    }
    void FillDetails_SCRUTINYATTACHMENTS()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();
        try
        {
            DataSet dsnew = new DataSet();
            dsnew = ViewAttachmetsData_SCRUTINYREPORT(hdfID.Value.ToString());
            if (dsnew.Tables[0].Rows.Count > 0)
            {
                trarchitecdwg.Visible = true;
                TRPLANPDF.Visible = true;
                TRSECURITYREPORT.Visible = true;
                TRDWG.Visible = true;
                TRPREDCR.Visible = false;

                int c = dsnew.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;
                while (i < c)
                {
                    //sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    //sen1 = sen2.Replace(@"\", @"/");
                    //sennew = dsnew.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    //string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    sen2 = dsnew.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    //if (sen1.Contains("Attachments"))
                    //{
                       // sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/Attachments")), "~/");
                        //if (sen.Contains("drawingpdf"))
                        //{
                        //    HypPlan.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        //    HypPlan.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //}

                        //if (sen.Contains("scrutinyreport"))
                        //{
                        //    HypScrutiny.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        //    HypScrutiny.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //}
                        //if (sen.Contains("drawingfile"))
                        //{
                        //    HypDWG.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        //    HypDWG.Text = dsnew.Tables[0].Rows[i][1].ToString();

                        //}
                        if (sen.Contains("drawingpdf"))
                        {
                            HypPlan.NavigateUrl = sen;
                            HypPlan.Text = dsnew.Tables[0].Rows[i][1].ToString();
                           // Label8.Text = dsnew.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }
                    if (sen.Contains("scrutinyreport"))
                    {
                        HypScrutiny.NavigateUrl = sen;
                        HypScrutiny.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        // Label8.Text = dsnew.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    //}
                    i++;
                }
            }
            if (dsnew.Tables[1].Rows.Count > 0)
            {
                drawing2.Visible = true;
                txtSecretKey.Text = dsnew.Tables[0].Rows[0]["scrutiny_key"].ToString();
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
    public DataSet ViewAttachmetsData_SCRUTINYREPORT(string intEnterprenuerid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GETSCRUTINYREPORTATTACHMENTS", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (intEnterprenuerid.Trim() == "" || intEnterprenuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEid", SqlDbType.VarChar).Value = intEnterprenuerid.ToString();



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

    private async Task<bool> DownloadAndSaveAttachments(BuildnowResponse data, string userId)
    {
        using (var httpClient = new HttpClient())
        {
            if (!string.IsNullOrEmpty(data.scrutiny_report_url))
                await SaveFileToServer(httpClient, data.scrutiny_report_url, "scrutiny_report_" + userId + ".pdf");

            if (!string.IsNullOrEmpty(data.drawing_pdf_url))
                await SaveFileToServer(httpClient, data.drawing_pdf_url, "drawing_pdf_" + userId + ".pdf");

            if (!string.IsNullOrEmpty(data.drawing_file_url))
                await SaveFileToServer(httpClient, data.drawing_file_url, "drawing_file_" + userId + ".dwg");
        }
        return true;
    }

    private async Task SaveFileToServer(HttpClient client, string fileUrl, string fileName)
    {
        try
        {
            string FILEDESCRIPTION = "";
            if (fileName.Contains("scrutiny_report"))
            {
                FILEDESCRIPTION = "scrutinyreport_BUILDNOW";
            }
            else if (fileName.Contains("drawing_pdf"))
            {
                FILEDESCRIPTION = "drawingpdf_BUILDNOW";
            }
            else if (fileName.Contains("drawing_file"))
            {
                FILEDESCRIPTION = "drawingfile_BUILDNOW";
            }

            // Base folder from config
            string sFileDir = ConfigurationManager.AppSettings["cfefilePath"];
            // Example: G:\TS-iPASSFinal\Attachments

            // Build folder path -> base + UID + FILEDESCRIPTION
            string folderPath = Path.Combine(sFileDir, Request.QueryString[0].ToString(), FILEDESCRIPTION);

            // Ensure folder exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Final file path
            string savePath = Path.Combine(folderPath, fileName);

            // Download file bytes
            using (var httpClient = new HttpClient())
            {
                byte[] fileBytes = await httpClient.GetByteArrayAsync(fileUrl);
                File.WriteAllBytes(savePath, fileBytes); // Save file
            }

            // Insert into DB
            General t1 = new General();
            t1.InsertImagedata(
                Session["Applid"].ToString(),
                Request.QueryString[0].ToString(),
    System.IO.Path.GetExtension(fileName).Replace(".", string.Empty), // ✅ works for all types
                folderPath,
                fileName,
                FILEDESCRIPTION,
                "",
                Session["uid"].ToString(),
                DateTime.Now.ToString(),
                "1000",
                DateTime.Now.ToString()
            );
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Download error: " + ex.ToString());
        }

    }
    public int InsertBuildnowDrawingDetails(string JSONDATA, string createdby)
    {
        int valid;
        con.OpenConnection();
        SqlCommand cmd = new SqlCommand("USP_INSERTBUILDNOWDRAWINGDETAILS", con.GetConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@jsonData", JSONDATA);
            cmd.Parameters.AddWithValue("@createdby", createdby);

            cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
            cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            valid = (Int32)cmd.Parameters["@Valid"].Value;
            con.CloseConnection();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cmd.Dispose();
            con.CloseConnection();
        }
        return valid;
    }
    public class Base64ToPdfConverter
    {
        public static void ConvertBase64ToPdf(string base64String, string outputPath)
        {
            byte[] pdfBytes = Convert.FromBase64String(base64String);

            File.WriteAllBytes(outputPath, pdfBytes);
        }
    }
}
public class DrawingVo
{
    public string RefNo { get; set; }
    public string SecretKey { get; set; }
}
[Serializable]
public class BuildingPermitResponse
{
    public string Applicationtype { get; set; }
    public string ArchitectLicenseNo { get; set; }
    public string ArchitectMobileNo { get; set; }
    public string ArchitectName { get; set; }
    public string Authority { get; set; }
    public string BuiltUpArea { get; set; }
    public string Casetype { get; set; }
    public string District { get; set; }
    public string ExistingRoadWidth { get; set; }
    public string LocalBody { get; set; }
    public string Mandal { get; set; }
    public string MaxBuildingHeight { get; set; }
    public string PlanPDFBase64 { get; set; }
    public string ScrutinyReportName { get; set; }
    public double TotalLandExtent { get; set; }
    public string Village { get; set; }
    public string sMessage { get; set; }
    public string sStatus { get; set; }
    public string GramPanchayat { get; set; }
    public string Municipality { get; set; }
    public string Organisation { get; set; }
    public string PlanPDFName { get; set; }
    public string PredcrDwgBase64 { get; set; }
    public string PredcrDwgName { get; set; }
    public string ProjectNature { get; set; }
    public string ScrutinyReportBase64 { get; set; }

}
public class BuildnowResponse
{
    public string scrutiny_report_url { get; set; }
    public string drawing_pdf_url { get; set; }
    public string drawing_file_url { get; set; }
}