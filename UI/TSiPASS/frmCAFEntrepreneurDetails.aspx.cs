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
    DB.DB con = new DB.DB();
    string res = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
                Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
               
                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "117");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    trheading.Visible = true;
                    trpolicedetails.Visible = true;
                }
                else
                {
                    trheading.Visible = false;
                    trpolicedetails.Visible = false;
                }
                dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "90");
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    if (trpolicedetails.Visible == false)
                    {
                        trheading.Visible = true;
                        trpolicedetails.Visible = true;
                    }
                    else
                    {
                        trpolicedetails.Visible = true;
                        trheading.Visible = false;
                    }
                }
                else
                {
                    if (trpolicedetails.Visible == false)
                        trpolicedetails.Visible = false;
                }


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
                    string TourismFlag = dscheck1.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                    if (TourismFlag == "Y")
                    {
                        lblNameandAddressofPromoter.Text = "Name Address of the Promoter/ Unit undertaking in full(BLOCK LETTERS)";
                        lblNameofIndus.Text = "Name of Unit Undertaking";
                        Session["HOTEL"] = "Y";
                    }
                    else
                    {
                        lblNameandAddressofPromoter.Text = "Name Address of the Promoter/Industrial undertaking in full(BLOCK LETTERS)";
                        lblNameofIndus.Text = "Name of Industrial Undertaking";
                    }
                }
                else
                {
                    Session["ApplidA"] = "0";
                }



                if (Session["ApplidA"].ToString().Trim() == "" || Session["ApplidA"].ToString().Trim() == "0")
                {
                    if (Session["HOTEL"] != null && Session["HOTEL"].ToString() == "Y")
                        Response.Redirect("frmQuesstionniareRegCFOHotel.aspx");
                    else
                        Response.Redirect("frmQuesstionniareRegCFO.aspx");
                }

                DataSet dsver = new DataSet();

                dsver = Gen.GetverifyofqueCFO(Session["ApplidA"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                     res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);

                    }

                }

                BINDQUALIFICATION_MANAGEMENTANDSTAFF();
                BINDQUALIFICATION_SUPERVISOR();
                BINDQUALIFICATION_SKILLEDWORKERS();
                BINDQUALIFICATION_SEMISKILLEDWORKERS();
                BINDQUALIFICATION_UNSKILLEDWORKERS();
                getstates();
                fillNatureofOrg();
                fillCategoryofReg();
            }

            DataSet ds = new DataSet();
            ds = Gen.GetdataofEnterprenuerCFO(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = Gen.GetdataofEnterprenuerCFO(Session["uid"].ToString());
                    if (dsnew != null && dsnew.Tables.Count > 0)
                    {
                        FillDetails(dsnew);
                    }
                    DataSet dschecknew = new DataSet();
                    dschecknew = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                    if (dschecknew != null && dschecknew.Tables.Count > 0)
                    {
                        if (dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                        {
                            getdistrictsland();
                            if (dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                            {
                                ddlLand_intDistrictid.SelectedValue = ddlLand_intDistrictid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
                                ddlLand_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                                ddlLand_intDistrictid.Enabled = false;
                            }

                            if (dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "0")
                            {
                                ddlLand_intMandalid.SelectedValue = ddlLand_intMandalid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
                                ddlLand_intMandalid_SelectedIndexChanged(this, EventArgs.Empty);
                                ddlLand_intMandalid.Enabled = false;
                            }
                            if (dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "0")
                            {
                                try
                                {
                                    ddlLand_intVillageid.SelectedValue = ddlLand_intVillageid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                                    ddlLand_intVillageid.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    ddlLand_intVillageid.Enabled = true;
                                }
                            }
                        }
                    }

                }

            }
            else
            {
                if (!IsPostBack)
                {
                    DataSet dschecknewcfo = new DataSet();
                    dschecknewcfo = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                    if (dschecknewcfo != null && dschecknewcfo.Tables[0].Rows.Count > 0)
                    {
                        if (dschecknewcfo.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknewcfo.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                        {
                            getdistrictsland();
                            if (dschecknewcfo.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknewcfo.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                            {
                                ddlLand_intDistrictid.SelectedValue = ddlLand_intDistrictid.Items.FindByValue(dschecknewcfo.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
                                ddlLand_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                                ddlLand_intDistrictid.Enabled = false;
                            }

                            if (dschecknewcfo.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "" && dschecknewcfo.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "0")
                            {
                                ddlLand_intMandalid.SelectedValue = ddlLand_intMandalid.Items.FindByValue(dschecknewcfo.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
                                ddlLand_intMandalid_SelectedIndexChanged(this, EventArgs.Empty);
                                ddlLand_intMandalid.Enabled = false;
                            }
                            if (dschecknewcfo.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "" && dschecknewcfo.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "0")
                            {
                                ddlLand_intVillageid.SelectedValue = ddlLand_intVillageid.Items.FindByValue(dschecknewcfo.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                                ddlLand_intVillageid.Enabled = false;
                            }
                        }
                    }

                    DataSet dsch = new DataSet();
                    DataSet dsarea = new DataSet();
                    dsch = Gen.GetEnterPreneurdatabyQue(Session["Applid"].ToString());
                    if (dsch.Tables[0].Rows.Count > 0)
                    {
                        DataSet dschecknew = new DataSet();
                        dschecknew = Gen.GetShowQuestionariesCFOnew(Session["uid"].ToString().Trim());
                        if (dschecknew != null && dschecknew.Tables.Count > 0)
                        {
                            txtNameOfIndustrialUndertaking.Text = dschecknew.Tables[0].Rows[0]["nameofunit"].ToString().Trim();

                            dsarea = Gen.GetEnterPreneurdatabyQuewaterReq(Session["Applid"].ToString());
                            if (dsarea != null && dsarea.Tables.Count > 0 && dsarea.Tables[0].Rows.Count > 0)
                            {
                                TxtBuilt_up_Area.Text = dsarea.Tables[0].Rows[0]["Built_up_Area"].ToString().Trim();
                                if (dsarea.Tables[0].Rows[0]["Hight_Build"].ToString().Trim() != "")
                                {
                                    TxtHight_Build.Text = dsarea.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();
                                }
                                if (dsarea.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim() != "")
                                {
                                    //ddlNatureofOrg.SelectedValue = ddlNatureofOrg.Items.FindByValue(dsarea.Tables[0].Rows[0]["Const_of_unit"].ToString()).Value;
                                    // ddlNatureofOrg.Enabled = false;
                                }
                            }
                            //if (dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                            //{
                            //    getdistrictsland();
                            //    if (dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString() != "0")
                            //    {
                            //        ddlLand_intDistrictid.SelectedValue = ddlLand_intDistrictid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim()).Value;
                            //        ddlLand_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                            //        ddlLand_intDistrictid.Enabled = false;
                            //    }

                            //    if (dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString() != "0")
                            //    {
                            //        ddlLand_intMandalid.SelectedValue = ddlLand_intMandalid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intMandalid"].ToString().Trim()).Value;
                            //        ddlLand_intMandalid_SelectedIndexChanged(this, EventArgs.Empty);
                            //        ddlLand_intMandalid.Enabled = false;
                            //    }
                            //    if (dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "" && dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString() != "0")
                            //    {
                            //        ddlLand_intVillageid.SelectedValue = ddlLand_intVillageid.Items.FindByValue(dschecknew.Tables[0].Rows[0]["Prop_intVillageid"].ToString().Trim()).Value;
                            //        ddlLand_intVillageid.Enabled = false;
                            //    }

                            //}    
                            DataSet Cfe = new DataSet();
                            Cfe = Gen.GetEnterPreneurdata(dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
                            FillDetailsCFE(Cfe);
                        }

                    }

                    //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
                    //{

                    //}
                }
            }
            if (txtSurveyNo.Text.Trim() == "")
            {
                txtSurveyNo.ReadOnly = false;
            }
            if (txtName_Gramapachayat.Text.Trim() == "")
            {
                txtName_Gramapachayat.ReadOnly = false;
            }
            if (txtLand_Pincode.Text.Trim() == "")
            {
                txtLand_Pincode.ReadOnly = false;
            }
            if (ddlVillage.SelectedValue == "--Select--")
            {
                ddlVillage.Enabled = true;
            }
            if (txtEmail.Text.Trim() == "")
            {
                txtEmail.ReadOnly = false;
            }
            if (ddlProject.SelectedValue == "--Select--")
            {
                ddlProject.Enabled = true;
            }


            if (txtstaffMale.Text.Trim() == "")
            {
                txtstaffMale.ReadOnly = false;
            }
            if (txtfemale.Text.Trim() == "")
            {
                txtfemale.ReadOnly = false;
            }
            if (ddlManagementandStaffQualification.SelectedValue == "--Select--" || ddlManagementandStaffQualification.SelectedValue=="0")
            {
                ddlManagementandStaffQualification.Enabled = true;
            }

            if (txtsupermalecount.Text.Trim() == "")
            {
                txtsupermalecount.ReadOnly = false;
            }
            if (txtsuperfemalecount.Text.Trim() == "")
            {
                txtsuperfemalecount.ReadOnly = false;
            }
            if (ddlSupervisor.SelectedValue == "--Select--" || ddlSupervisor.SelectedValue == "0")
            {
                ddlSupervisor.Enabled = true;
            }

            if (txtSkilledWorkersMale.Text.Trim() == "")
            {
                txtSkilledWorkersMale.ReadOnly = false;
            }
            if (txtSkilledWorkersFemale.Text.Trim() == "")
            {
                txtSkilledWorkersFemale.ReadOnly = false;
            }
            if (ddlskilledworkers.SelectedValue == "--Select--" || ddlskilledworkers.SelectedValue == "0")
            {
                ddlskilledworkers.Enabled = true;
            }
            if (txtSemiSkilledWorkersMale.Text.Trim() == "")
            {
                txtSemiSkilledWorkersMale.ReadOnly = false;
            }
            if (txtSemiSkilledWorkersFemale.Text.Trim() == "")
            {
                txtSemiSkilledWorkersFemale.ReadOnly = false;
            }
            if (ddlsemiskilledworkers.SelectedValue == "--Select--" || ddlsemiskilledworkers.SelectedValue == "0")
            {
                ddlsemiskilledworkers.Enabled = true;
            }
            if (TXTUNSKILLEDWORKERMALE.Text.Trim() == "")
            {
                TXTUNSKILLEDWORKERMALE.ReadOnly = false;
            }
            if (TXTUNSKILLEDWORKERFEMALE.Text.Trim() == "")
            {
                TXTUNSKILLEDWORKERFEMALE.ReadOnly = false;
            }
            if (ddlunskilledworkers.SelectedValue == "--Select--" || ddlunskilledworkers.SelectedValue == "0")
            {
                ddlunskilledworkers.Enabled = true;
            }
        }

        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }


    public void BINDQUALIFICATION_MANAGEMENTANDSTAFF()
    {
        DataSet dsqualification = new DataSet();
        dsqualification = GETEXPERIENCE();
        if (dsqualification != null && dsqualification.Tables.Count > 0 && dsqualification.Tables[0].Rows.Count > 0)
        {
            ddlManagementandStaffQualification.DataSource = dsqualification.Tables[0];
            ddlManagementandStaffQualification.DataValueField = "QUALIFICATIONID";
            ddlManagementandStaffQualification.DataTextField = "QUALIFICATION";
            ddlManagementandStaffQualification.DataBind();
        }
    }
    public void BINDQUALIFICATION_SUPERVISOR()
    {
        DataSet dsqualification = new DataSet();
        dsqualification = GETEXPERIENCE();
        if (dsqualification != null && dsqualification.Tables.Count > 0 && dsqualification.Tables[0].Rows.Count > 0)
        {
            ddlSupervisor.DataSource = dsqualification.Tables[0];
            ddlSupervisor.DataValueField = "QUALIFICATIONID";
            ddlSupervisor.DataTextField = "QUALIFICATION";
            ddlSupervisor.DataBind();
        }
    }
    public void BINDQUALIFICATION_SKILLEDWORKERS()
    {
        DataSet dsqualification = new DataSet();
        dsqualification = GETEXPERIENCE();
        if (dsqualification != null && dsqualification.Tables.Count > 0 && dsqualification.Tables[0].Rows.Count > 0)
        {
            ddlskilledworkers.DataSource = dsqualification.Tables[0];
            ddlskilledworkers.DataValueField = "QUALIFICATIONID";
            ddlskilledworkers.DataTextField = "QUALIFICATION";
            ddlskilledworkers.DataBind();
        }
    }
    public void BINDQUALIFICATION_SEMISKILLEDWORKERS()
    {
        DataSet dsqualification = new DataSet();
        dsqualification = GETEXPERIENCE();
        if (dsqualification != null && dsqualification.Tables.Count > 0 && dsqualification.Tables[0].Rows.Count > 0)
        {
            ddlsemiskilledworkers.DataSource = dsqualification.Tables[0];
            ddlsemiskilledworkers.DataValueField = "QUALIFICATIONID";
            ddlsemiskilledworkers.DataTextField = "QUALIFICATION";
            ddlsemiskilledworkers.DataBind();
        }
    }
    public void BINDQUALIFICATION_UNSKILLEDWORKERS()
    {
        DataSet dsqualification = new DataSet();
        dsqualification = GETEXPERIENCE();
        if (dsqualification != null && dsqualification.Tables.Count > 0 && dsqualification.Tables[0].Rows.Count > 0)
        {
            ddlunskilledworkers.DataSource = dsqualification.Tables[0];
            ddlunskilledworkers.DataValueField = "QUALIFICATIONID";
            ddlunskilledworkers.DataTextField = "QUALIFICATION";
            ddlunskilledworkers.DataBind();
        }
    }
    public DataSet GETEXPERIENCE()
    {

        DataSet Dsnew = new DataSet();


        Dsnew = Gen.GenericFillDs("SP_GETQUALIFICATIONS");
        return Dsnew;
    }


    void fillNatureofOrg()
    {
        DataSet ds = new DataSet();
        ds = Gen.getNatureofOrg();

        ddlNatureofOrg.DataSource = ds.Tables[0];
        ddlNatureofOrg.DataTextField = "Org_Type";
        ddlNatureofOrg.DataValueField = "Org_ID";
        ddlNatureofOrg.DataBind();
        ddlNatureofOrg.Items.Insert(0, "--Select--");
    }

    protected void fillCategoryofReg()
    {
        DataSet ds = new DataSet();
        ds = Gen.getCategoryRegistration();

        ddlCateORg.DataSource = ds.Tables[0];
        ddlCateORg.DataTextField = "Category_Of_Registration";
        ddlCateORg.DataValueField = "Cate_Reg_ID";
        ddlCateORg.DataBind();
        ddlCateORg.Items.Insert(0, "--Select--");
    }
    List<string> exemptTextBoxIds = new List<string> { "txtAdultMale", "txtAdultFemale","TXTTRANSADULTS", "txtAdoleMale", "txtAdoleFemale", "TXTTRANSADOLESCENTS", "txtChildMale", "txtChildFemale", "TXTTRANSCHILDREN" };

    public void ResetFormControl(Control parent)
    {
        //foreach (Control c in parent.Controls)
        //{
        //    if (c.Controls.Count > 0)
        //    {
        //        ResetFormControl(c);
        //    }
        //    else
        //    {
        //        switch (c.GetType().ToString())
        //        {
        //            case "System.Web.UI.WebControls.TextBox":
        //                ((TextBox)c).ReadOnly = true;

        //                break;

        //            case "System.Web.UI.WebControls.DropDownList":

        //                if (((DropDownList)c).Items.Count > 0)
        //                {
        //                    ((DropDownList)c).Enabled = false;
        //                }
        //                break;
        //            case "System.Web.UI.WebControls.FileUpload":
        //                ((FileUpload)c).Enabled = false;
        //                break;
        //            case "System.Web.UI.WebControls.RadioButtonList":
        //                ((RadioButtonList)c).Enabled = false;
        //                break;

        //            case "System.Web.UI.WebControls.CheckBoxList":
        //                ((CheckBoxList)c).Enabled = false;
        //                break;

        //        }
        //    }
        //}
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
                        TextBox txt = (TextBox)c;

                        // Skip if this textbox is in the exempt list
                        if (!exemptTextBoxIds.Contains(txt.ID))
                        {
                            txt.ReadOnly = true;
                        }
                        break;

                    case "System.Web.UI.WebControls.DropDownList":
                        DropDownList ddl = (DropDownList)c;
                        if (ddl.Items.Count > 0)
                        {
                            ddl.Enabled = false;
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

    #region states, district, mandals

    protected void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlState.DataSource = ds.Tables[0];
        ddlState.DataTextField = "State_Name";
        ddlState.DataValueField = "State_id";
        ddlState.DataBind();
        ddlState.Items.Insert(0, "--Select--");

    }

    protected void getdistricts()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistrictsbystate(ddlState.SelectedValue.ToString());

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
        ddlDistrict.DataSource = ds.Tables[0];
        ddlDistrict.DataTextField = "District_Name";
        ddlDistrict.DataValueField = "District_Id";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "--Select--");

    }

    protected void getMandals()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlDistrict.SelectedValue.ToString());
        ddlMandal.DataSource = ds.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");
    }

    protected void getVillages()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
        ddlVillage.DataSource = ds.Tables[0];
        ddlVillage.DataTextField = "Village_Name";
        ddlVillage.DataValueField = "Village_Id";
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, "--Select--");
    }
    protected void getdistrictsland()
    {
        //DataSet ds = new DataSet();
        //ds = Gen.GetDistrictsbystate("31");

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet ds = new DataSet();
        ds = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFO");
        ddlLand_intDistrictid.DataSource = ds.Tables[0];
        ddlLand_intDistrictid.DataTextField = "District_Name";
        ddlLand_intDistrictid.DataValueField = "District_Id";
        ddlLand_intDistrictid.DataBind();
        ddlLand_intDistrictid.Items.Insert(0, "--Select--");

    }

    protected void getMandalsland()
    {
        DataSet ds = new DataSet();
        ds = Gen.Getmandalsbydistrict(ddlLand_intDistrictid.SelectedValue.ToString());
        ddlLand_intMandalid.DataSource = ds.Tables[0];
        ddlLand_intMandalid.DataTextField = "Manda_lName";
        ddlLand_intMandalid.DataValueField = "Mandal_Id";
        ddlLand_intMandalid.DataBind();
        ddlLand_intMandalid.Items.Insert(0, "--Select--");
    }

    protected void getVillagesland()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetVillagebymandal(ddlLand_intMandalid.SelectedValue.ToString());
        ddlLand_intVillageid.DataSource = ds.Tables[0];
        ddlLand_intVillageid.DataTextField = "Village_Name";
        ddlLand_intVillageid.DataValueField = "Village_Id";
        ddlLand_intVillageid.DataBind();
        ddlLand_intVillageid.Items.Insert(0, "--Select--");
    }
    #endregion


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (BtnSave1.Text == "Save")
            {

                string policeNoc = "";
                if (trpolicedetails.Visible == true)
                {
                    policeNoc = "Y";
                }
                else if (trpolicedetails.Visible == false)
                {
                    policeNoc = "N";
                }
                DataSet ds = new DataSet();

                ds = Gen.GetdataofEnterprenuerCFO(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    result = insetEnterprenuerdataCFO(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["Applid"].ToString(), 
                        txtNameOfIndustrialUndertaking.Text, txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, 
                        ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreetName.Text, 
                        txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text, ddlNatureofOrg.SelectedValue,
                        txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text,
                        txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, 
                        ddlProject.SelectedValue, txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString(), txtDistrict.Text,
                        txtMandal.Text, txtVillage.Text, ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(), 
                        ddlMinority.SelectedValue.ToString(), TxtHight_Build.Text, TxtBuilt_up_Area.Text, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, 
                        ddlLand_intMandalid.SelectedValue, ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, 
                        ddlcommissionerate.SelectedValue.ToString(), ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), 
                        ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(), ddltrafficdivision.SelectedValue.ToString(),
                        ddltrafficpolicestation.SelectedValue.ToString(), policeNoc, txtstaffMale.Text, txtfemale.Text, ddlManagementandStaffQualification.SelectedValue.ToString(),
                        txtmngmntstaffqualificationother.Text, txtsupermalecount.Text, txtsuperfemalecount.Text, ddlSupervisor.SelectedValue.ToString(),
                        txtsupervisorqualificationother.Text, txtSkilledWorkersMale.Text, txtSkilledWorkersFemale.Text,
                        ddlskilledworkers.SelectedValue.ToString(), txtskilledworkerqualother.Text, txtSemiSkilledWorkersMale.Text, txtSemiSkilledWorkersFemale.Text,
                        ddlsemiskilledworkers.SelectedValue.ToString(), txtsemiskilledworkerqualother.Text, TXTUNSKILLEDWORKERMALE.Text, TXTUNSKILLEDWORKERFEMALE.Text,
                        ddlunskilledworkers.SelectedValue.ToString(), txtunskilledworkersqualother.Text,
                        TXTTRANSADULTS.Text, TXTTRANSADOLESCENTS.Text, TXTTRANSCHILDREN.Text);

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else if (result == 0)
                    {
                        lblmsg.Text = "<font color='green'>Enterprenuer Details Updated Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }
                else
                {
                    int result = 0;
                    result = insetEnterprenuerdataCFO(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["Applid"].ToString(), 
                        txtNameOfIndustrialUndertaking.Text, txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, 
                        ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreetName.Text,
                        txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text, ddlNatureofOrg.SelectedValue,
                        txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text, 
                        txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, ddlProject.SelectedValue, 
                        txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString(), txtDistrict.Text, txtMandal.Text, txtVillage.Text,
                        ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(), ddlMinority.SelectedValue.ToString(), 
                        TxtHight_Build.Text, TxtBuilt_up_Area.Text, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue,
                        ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text,
                        ddlcommissionerate.SelectedValue.ToString(), ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), 
                        ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(), ddltrafficdivision.SelectedValue.ToString(),
                        ddltrafficpolicestation.SelectedValue.ToString(), policeNoc, txtstaffMale.Text, txtfemale.Text, ddlManagementandStaffQualification.SelectedValue.ToString(),
                        txtmngmntstaffqualificationother.Text, txtsupermalecount.Text, txtsuperfemalecount.Text, ddlSupervisor.SelectedValue.ToString(),
                        txtsupervisorqualificationother.Text, txtSkilledWorkersMale.Text, txtSkilledWorkersFemale.Text,
                        ddlskilledworkers.SelectedValue.ToString(), txtskilledworkerqualother.Text, txtSemiSkilledWorkersMale.Text, txtSemiSkilledWorkersFemale.Text,
                        ddlsemiskilledworkers.SelectedValue.ToString(), txtsemiskilledworkerqualother.Text, TXTUNSKILLEDWORKERMALE.Text, TXTUNSKILLEDWORKERFEMALE.Text,
                        ddlunskilledworkers.SelectedValue.ToString(), txtunskilledworkersqualother.Text,
                        TXTTRANSADULTS.Text, TXTTRANSADOLESCENTS.Text, TXTTRANSCHILDREN.Text);

                    if (result > 0)
                    {
                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {
                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Submission Failed..!</font>";
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    public int insetEnterprenuerdataCFO(string @intCFOEnterpid,
        string intQuessionaireCFOid,
        string intQuessionaireid,
        string NameofIndustrialUnder,
        string NameofthePromoter,
        string SoWo,
        string Age,
        string Occupation,
        string intStateid,
        string intDistrictid,
        string intMandalid,
        string intVillageid,
        string StreetName,
        string Door_No,
        string Land_Mark,
        string Pincode,
        string MobileNumber,
        string Email,
        string Fax,
        string intTypeofOrganization,
        string TelephoneNumber,
        string AdultMale,
        string AdultFemale,
        string Adolescents_Male,
        string Adolescents_Female,
        string Children_Male,
        string Children_Female,
        string intCategoryofReg,
        string Reg_No,
        string Reg_Date,
        string Reg_ExpDate,
        string TypeofFactory,
        string Reg_id,
        string UID_No,
        string Created_by,
     string @Modified_by, string DistrictName, string Mandalname, string VillageName, string diffabled, string WomenEnterprenuer, string Minority, string Hight_Build, string Built_up_Area
       , string SurveyNo,
string Land_intDistrictid,
string Land_intMandalid,
string Land_intVillageid,
string Name_Gramapachayat,
string Land_Pincode, string Commissionerate, string Pol_Zone, string Pol_Division, string Pol_Station, string Tra_Station, string Tra_Division, string Tra_Police, string PoliceNo,
string staffmale, string stafffemale, string staffqulification, string staffqulification_other, string supervisormale,
string supervisorfemale, string supervisorqualification, string supervisorqualification_other, string skilledworkersmale,
string skilledworkersfemale, string skilledworkersqualification, string skilledworkersqualification_other, string semiskilledworkersmale,
string semiskilledworkersfemale, string semiskilledworkersqualification, string semiskilledworkersqualification_other,
string unskilledworkersmale, string unskilledworkersfemale, string unskilledworkersqualification, string unskilledworkersqualification_other,
 string transgenderaudult, string transgenderadolescents, string transgenderchildren       )
    {


        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.CommandText = "insertEnterPrenuerdetailsCFO";

        if (intCFOEnterpid.ToString().Trim() == "" || intCFOEnterpid.ToString().Trim() == null || intCFOEnterpid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = "0";
        else
            com.Parameters.Add("@intCFOEnterpid", SqlDbType.VarChar).Value = intCFOEnterpid.Trim();

        if (intQuessionaireCFOid.ToString().Trim() == "" || intQuessionaireCFOid.ToString().Trim() == null || intCFOEnterpid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireCFOid", SqlDbType.VarChar).Value = intQuessionaireCFOid.Trim();

        if (intQuessionaireid.ToString().Trim() == "" || intQuessionaireid.ToString().Trim() == null || intQuessionaireid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intQuessionaireid", SqlDbType.VarChar).Value = intQuessionaireid.Trim();


        if (DistrictName.ToString().Trim() == "" || DistrictName.ToString().Trim() == null || DistrictName.ToString().Trim() == "--Select--")
            com.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@DistrictName", SqlDbType.VarChar).Value = DistrictName.Trim();
        if (diffabled.ToString().Trim() == "" || diffabled.ToString().Trim() == null || diffabled.ToString().Trim() == "--Select--")
            com.Parameters.Add("@diffabled", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@diffabled", SqlDbType.VarChar).Value = diffabled.Trim();

        if (WomenEnterprenuer.ToString().Trim() == "" || WomenEnterprenuer.ToString().Trim() == null || WomenEnterprenuer.ToString().Trim() == "--Select--")
            com.Parameters.Add("@WomenEnterprenuer", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@WomenEnterprenuer", SqlDbType.VarChar).Value = WomenEnterprenuer.Trim();


        if (Minority.ToString().Trim() == "" || Minority.ToString().Trim() == null || Minority.ToString().Trim() == "--Select--")

            com.Parameters.Add("@Minority", SqlDbType.VarChar).Value = DBNull.Value;

        else
            com.Parameters.Add("@Minority", SqlDbType.VarChar).Value = Minority.Trim();

        if (Hight_Build == "" || Hight_Build == null || Hight_Build == "--Select--")
            com.Parameters.Add("@Hight_Build", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Hight_Build", SqlDbType.VarChar).Value = Hight_Build.Trim();


        if (Built_up_Area == "" || Built_up_Area == null || Built_up_Area == "--Select--")
            com.Parameters.Add("@Built_up_Area", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Built_up_Area", SqlDbType.VarChar).Value = Built_up_Area.Trim();




        if (Mandalname.ToString().Trim() == "" || Mandalname.ToString().Trim() == null || Mandalname.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Mandalname", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Mandalname", SqlDbType.VarChar).Value = Mandalname.Trim();



        if (VillageName.ToString().Trim() == "" || VillageName.ToString().Trim() == null || VillageName.ToString().Trim() == "--Select--")
            com.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = VillageName.Trim();

        if (NameofIndustrialUnder.ToString().Trim() == "" || NameofIndustrialUnder.ToString().Trim() == null || NameofIndustrialUnder.ToString().Trim() == "--Select--")
            com.Parameters.Add("@NameofIndustrialUnder", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NameofIndustrialUnder", SqlDbType.VarChar).Value = NameofIndustrialUnder.Trim();

        if (NameofthePromoter.ToString().Trim() == "" || NameofthePromoter.ToString().Trim() == null || NameofthePromoter.ToString().Trim() == "--Select--")
            com.Parameters.Add("@NameofthePromoter", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@NameofthePromoter", SqlDbType.VarChar).Value = NameofthePromoter.Trim();

        if (SoWo.ToString().Trim() == "" || SoWo.ToString().Trim() == null || SoWo.ToString().Trim() == "--Select--")
            com.Parameters.Add("@SoWo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SoWo", SqlDbType.VarChar).Value = SoWo.Trim();

        if (Age.ToString().Trim() == "" || Age.ToString().Trim() == null || Age.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Age", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Age", SqlDbType.VarChar).Value = Age.Trim();

        //if (Age.ToString().Trim() == "" || Age.ToString().Trim() == null)
        //    com.Parameters.Add("@Age", SqlDbType.VarChar).Value = DBNull.Value;
        //else
        //    com.Parameters.Add("@Age", SqlDbType.VarChar).Value = Age.Trim();

        if (Occupation.ToString().Trim() == "" || Occupation.ToString().Trim() == null || Occupation.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Occupation", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Occupation", SqlDbType.VarChar).Value = Occupation.Trim();

        if (intStateid.ToString().Trim() == "" || intStateid.ToString().Trim() == null || intStateid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intStateid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intStateid", SqlDbType.VarChar).Value = intStateid.Trim();

        if (intDistrictid.ToString().Trim() == "" || intDistrictid.ToString().Trim() == null || intDistrictid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intDistrictid", SqlDbType.VarChar).Value = intDistrictid.Trim();

        if (intMandalid.ToString().Trim() == "" || intMandalid.ToString().Trim() == null || intMandalid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intMandalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intMandalid", SqlDbType.VarChar).Value = intMandalid.Trim();

        if (intVillageid.ToString().Trim() == "" || intVillageid.ToString().Trim() == null || intVillageid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intVillageid", SqlDbType.VarChar).Value = intVillageid.Trim();

        if (StreetName.ToString().Trim() == "" || StreetName.ToString().Trim() == null)
            com.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@StreetName", SqlDbType.VarChar).Value = StreetName.Trim();

        if (Door_No.ToString().Trim() == "" || Door_No.ToString().Trim() == null)
            com.Parameters.Add("@Door_No", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Door_No", SqlDbType.VarChar).Value = Door_No.Trim();

        if (Land_Mark.ToString().Trim() == "" || Land_Mark.ToString().Trim() == null)
            com.Parameters.Add("@Land_Mark", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Land_Mark", SqlDbType.VarChar).Value = Land_Mark.Trim();

        if (Pincode.ToString().Trim() == "" || Pincode.ToString().Trim() == null)
            com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = Pincode.Trim();

        if (MobileNumber.ToString().Trim() == "" || MobileNumber.ToString().Trim() == null)
            com.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = MobileNumber.Trim();

        if (Email.ToString().Trim() == "" || Email.ToString().Trim() == null)
            com.Parameters.Add("@Email", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email.Trim();

        if (Fax.ToString().Trim() == "" || Fax.ToString().Trim() == null)
            com.Parameters.Add("@Fax", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Fax.Trim();

        if (intTypeofOrganization.ToString().Trim() == "" || intTypeofOrganization.ToString().Trim() == null || intTypeofOrganization.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intTypeofOrganization", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intTypeofOrganization", SqlDbType.VarChar).Value = intTypeofOrganization.Trim();

        if (TelephoneNumber.ToString().Trim() == "" || TelephoneNumber.ToString().Trim() == null)
            com.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TelephoneNumber", SqlDbType.VarChar).Value = TelephoneNumber.Trim();

        if (AdultMale.ToString().Trim() == "" || AdultMale.ToString().Trim() == null)
            com.Parameters.Add("@AdultMale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdultMale", SqlDbType.VarChar).Value = AdultMale.Trim();

        if (AdultFemale.ToString().Trim() == "" || AdultFemale.ToString().Trim() == null)
            com.Parameters.Add("@AdultFemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@AdultFemale", SqlDbType.VarChar).Value = AdultFemale.Trim();

        if (Adolescents_Male.ToString().Trim() == "" || Adolescents_Male.ToString().Trim() == null)
            com.Parameters.Add("@Adolescents_Male", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Adolescents_Male", SqlDbType.VarChar).Value = Adolescents_Male.Trim();

        if (Adolescents_Female.ToString().Trim() == "" || Adolescents_Female.ToString().Trim() == null)
            com.Parameters.Add("@Adolescents_Female", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Adolescents_Female", SqlDbType.VarChar).Value = Adolescents_Female.Trim();

        if (Children_Male.ToString().Trim() == "" || Children_Male.ToString().Trim() == null)
            com.Parameters.Add("@Children_Male", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Children_Male", SqlDbType.VarChar).Value = Children_Male.Trim();

        if (Children_Female.ToString().Trim() == "" || Children_Female.ToString().Trim() == null)
            com.Parameters.Add("@Children_Female", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Children_Female", SqlDbType.VarChar).Value = Children_Female.Trim();

        if (intCategoryofReg.ToString().Trim() == "" || intCategoryofReg.ToString().Trim() == null || intCategoryofReg.ToString().Trim() == "--Select--")
            com.Parameters.Add("@intCategoryofReg", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@intCategoryofReg", SqlDbType.VarChar).Value = intCategoryofReg.Trim();

        if (Reg_No.ToString().Trim() == "" || Reg_No.ToString().Trim() == null)
            com.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = Reg_No.Trim();

        if (Reg_Date.ToString().Trim() == "" || Reg_Date.ToString().Trim() == null || Reg_Date.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Reg_Date", SqlDbType.DateTime).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reg_Date", SqlDbType.DateTime).Value = cmf.convertDateIndia(Reg_Date.Trim());

        if (Reg_ExpDate.ToString().Trim() == "" || Reg_ExpDate.ToString().Trim() == null || Reg_ExpDate.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Reg_ExpDate", SqlDbType.DateTime).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reg_ExpDate", SqlDbType.DateTime).Value = cmf.convertDateIndia(Reg_ExpDate.Trim());

        if (TypeofFactory.ToString().Trim() == "" || TypeofFactory.ToString().Trim() == null || TypeofFactory.ToString().Trim() == "--Select Proposal--" || TypeofFactory.ToString().Trim() == "--Select--")
            com.Parameters.Add("@TypeofFactory", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@TypeofFactory", SqlDbType.VarChar).Value = TypeofFactory.Trim();

        if (Reg_id.ToString().Trim() == "" || Reg_id.ToString().Trim() == null || Reg_id.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Reg_id", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Reg_id", SqlDbType.VarChar).Value = Reg_id.Trim();

        if (UID_No.ToString().Trim() == "" || UID_No.ToString().Trim() == null || UID_No.ToString().Trim() == "--Select--")
            com.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@UID_No", SqlDbType.VarChar).Value = UID_No.Trim();

        if (Created_by.ToString().Trim() == "" || Created_by.ToString().Trim() == null || Created_by.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Created_by", SqlDbType.VarChar).Value = Created_by.Trim();

        if (Modified_by.ToString().Trim() == "" || Modified_by.ToString().Trim() == null || Modified_by.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Modified_by ", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Modified_by ", SqlDbType.VarChar).Value = Modified_by.Trim();
        /////// Added by madhuri on 12/09/2017///////////////

        if (SurveyNo.ToString().Trim() == "" || SurveyNo.ToString().Trim() == null || SurveyNo.ToString().Trim() == "--Select--")
            com.Parameters.Add("@SurveyNo", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@SurveyNo", SqlDbType.VarChar).Value = SurveyNo.Trim();

        if (Land_intDistrictid.ToString().Trim() == "" || Land_intDistrictid.ToString().Trim() == null || Land_intDistrictid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Land_intDistrictid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Land_intDistrictid", SqlDbType.VarChar).Value = Land_intDistrictid.Trim();

        if (Land_intMandalid.ToString().Trim() == "" || Land_intMandalid.ToString().Trim() == null || Land_intMandalid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Land_intMandalid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Land_intMandalid", SqlDbType.VarChar).Value = Land_intMandalid.Trim();

        if (Land_intVillageid.ToString().Trim() == "" || Land_intVillageid.ToString().Trim() == null || Land_intVillageid.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Land_intVillageid", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Land_intVillageid", SqlDbType.VarChar).Value = Land_intVillageid.Trim();

        if (Name_Gramapachayat.ToString().Trim() == "" || Name_Gramapachayat.ToString().Trim() == null || Name_Gramapachayat.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Name_Gramapachayat", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Name_Gramapachayat", SqlDbType.VarChar).Value = Name_Gramapachayat.Trim();

        if (Land_Pincode.ToString().Trim() == "" || Land_Pincode.ToString().Trim() == null || Land_Pincode.ToString().Trim() == "--Select--")
            com.Parameters.Add("@Land_Pincode", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@Land_Pincode", SqlDbType.VarChar).Value = Land_Pincode.Trim();
        if (Commissionerate.Trim() == "" || Commissionerate.Trim() == null)
        {
            com.Parameters.Add("@Commissionerate", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Commissionerate", SqlDbType.VarChar).Value = Commissionerate.Trim();
        }
        if (Pol_Zone.Trim() == "" || Pol_Zone.Trim() == null)
        {
            com.Parameters.Add("@Pol_Zone", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Pol_Zone", SqlDbType.VarChar).Value = Pol_Zone.Trim();
        }
        if (Pol_Division.Trim() == "" || Pol_Division.Trim() == null)
        {
            com.Parameters.Add("@Pol_Division", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Pol_Division", SqlDbType.VarChar).Value = Pol_Division.Trim();
        }
        if (Pol_Station.Trim() == "" || Pol_Station.Trim() == null)
        {
            com.Parameters.Add("@Pol_Station", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Pol_Station", SqlDbType.VarChar).Value = Pol_Station.Trim();
        }
        if (Tra_Station.Trim() == "" || Tra_Station.Trim() == null)
        {
            com.Parameters.Add("@Tra_Station", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Tra_Station", SqlDbType.VarChar).Value = Tra_Station.Trim();
        }
        if (Tra_Division.Trim() == "" || Tra_Division.Trim() == null)
        {
            com.Parameters.Add("@Tra_Division", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Tra_Division", SqlDbType.VarChar).Value = Tra_Division.Trim();
        }
        if (Tra_Police.Trim() == "" || Tra_Police.Trim() == null)
        {
            com.Parameters.Add("@Tra_Police", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@Tra_Police", SqlDbType.VarChar).Value = Tra_Police.Trim();
        }
        if (PoliceNo.Trim() == "" || PoliceNo.Trim() == null)
        {
            com.Parameters.Add("@PoliceNoc", SqlDbType.VarChar).Value = DBNull.Value;
        }
        else
        {
            com.Parameters.Add("@PoliceNoc", SqlDbType.VarChar).Value = PoliceNo.Trim();
        }
        //---------------------------------------------------------------------------------------------------------------
        if (staffmale.ToString().Trim() == "" || staffmale.ToString().Trim() == null || staffmale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@staffmale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@staffmale", SqlDbType.VarChar).Value = staffmale.Trim();

        if (stafffemale.ToString().Trim() == "" || stafffemale.ToString().Trim() == null || stafffemale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@stafffemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@stafffemale", SqlDbType.VarChar).Value = stafffemale.Trim();

        if (staffqulification.ToString().Trim() == "" || staffqulification.ToString().Trim() == null || staffqulification.ToString().Trim() == "--Select--")
            com.Parameters.Add("@staffqulification", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@staffqulification", SqlDbType.VarChar).Value = staffqulification.Trim();

        if (staffqulification_other.ToString().Trim() == "" || staffqulification_other.ToString().Trim() == null || staffqulification_other.ToString().Trim() == "--Select--")
            com.Parameters.Add("@staffqulification_other", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@staffqulification_other", SqlDbType.VarChar).Value = staffqulification_other.Trim();

        if (supervisormale.ToString().Trim() == "" || supervisormale.ToString().Trim() == null || supervisormale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@supervisormale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@supervisormale", SqlDbType.VarChar).Value = supervisormale.Trim();

        if (supervisorfemale.ToString().Trim() == "" || supervisorfemale.ToString().Trim() == null || supervisorfemale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@supervisorfemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@supervisorfemale", SqlDbType.VarChar).Value = supervisorfemale.Trim();

        if (supervisorqualification.ToString().Trim() == "" || supervisorqualification.ToString().Trim() == null || supervisorqualification.ToString().Trim() == "--Select--")
            com.Parameters.Add("@supervisorqualification", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@supervisorqualification", SqlDbType.VarChar).Value = supervisorqualification.Trim();

        if (supervisorqualification_other.ToString().Trim() == "" || supervisorqualification_other.ToString().Trim() == null || supervisorqualification_other.ToString().Trim() == "--Select--")
            com.Parameters.Add("@supervisorqualification_other", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@supervisorqualification_other", SqlDbType.VarChar).Value = supervisorqualification_other.Trim();

        if (skilledworkersmale.ToString().Trim() == "" || skilledworkersmale.ToString().Trim() == null || skilledworkersmale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@skilledworkersmale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@skilledworkersmale", SqlDbType.VarChar).Value = skilledworkersmale.Trim();

        if (skilledworkersfemale.ToString().Trim() == "" || skilledworkersfemale.ToString().Trim() == null || skilledworkersfemale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@skilledworkersfemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@skilledworkersfemale", SqlDbType.VarChar).Value = skilledworkersfemale.Trim();

        if (skilledworkersqualification.ToString().Trim() == "" || skilledworkersqualification.ToString().Trim() == null || skilledworkersqualification.ToString().Trim() == "--Select--")
            com.Parameters.Add("@skilledworkersqualification", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@skilledworkersqualification", SqlDbType.VarChar).Value = skilledworkersqualification.Trim();

        if (skilledworkersqualification_other.ToString().Trim() == "" || skilledworkersqualification_other.ToString().Trim() == null || skilledworkersqualification_other.ToString().Trim() == "--Select--")
            com.Parameters.Add("@skilledworkersqualification_other", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@skilledworkersqualification_other", SqlDbType.VarChar).Value = skilledworkersqualification_other.Trim();

        if (semiskilledworkersmale.ToString().Trim() == "" || semiskilledworkersmale.ToString().Trim() == null || semiskilledworkersmale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@semiskilledworkersmale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@semiskilledworkersmale", SqlDbType.VarChar).Value = semiskilledworkersmale.Trim();

        if (semiskilledworkersfemale.ToString().Trim() == "" || semiskilledworkersfemale.ToString().Trim() == null || semiskilledworkersfemale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@semiskilledworkersfemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@semiskilledworkersfemale", SqlDbType.VarChar).Value = semiskilledworkersfemale.Trim();

        if (semiskilledworkersqualification.ToString().Trim() == "" || semiskilledworkersqualification.ToString().Trim() == null || semiskilledworkersqualification.ToString().Trim() == "--Select--")
            com.Parameters.Add("@semiskilledworkersqualification", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@semiskilledworkersqualification", SqlDbType.VarChar).Value = semiskilledworkersqualification.Trim();

        if (semiskilledworkersqualification_other.ToString().Trim() == "" || semiskilledworkersqualification_other.ToString().Trim() == null || semiskilledworkersqualification_other.ToString().Trim() == "--Select--")
            com.Parameters.Add("@semiskilledworkersqualification_other", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@semiskilledworkersqualification_other", SqlDbType.VarChar).Value = semiskilledworkersqualification_other.Trim();

        if (unskilledworkersmale.ToString().Trim() == "" || unskilledworkersmale.ToString().Trim() == null || unskilledworkersmale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@unskilledworkersmale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@unskilledworkersmale", SqlDbType.VarChar).Value = unskilledworkersmale.Trim();

        if (unskilledworkersfemale.ToString().Trim() == "" || unskilledworkersfemale.ToString().Trim() == null || unskilledworkersfemale.ToString().Trim() == "--Select--")
            com.Parameters.Add("@unskilledworkersfemale", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@unskilledworkersfemale", SqlDbType.VarChar).Value = unskilledworkersfemale.Trim();

        if (unskilledworkersqualification.ToString().Trim() == "" || unskilledworkersqualification.ToString().Trim() == null || unskilledworkersqualification.ToString().Trim() == "--Select--")
            com.Parameters.Add("@unskilledworkersqualification", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@unskilledworkersqualification", SqlDbType.VarChar).Value = unskilledworkersqualification.Trim();

        if (unskilledworkersqualification_other.ToString().Trim() == "" || unskilledworkersqualification_other.ToString().Trim() == null || unskilledworkersqualification_other.ToString().Trim() == "--Select--")
            com.Parameters.Add("@unskilledworkersqualification_other", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@unskilledworkersqualification_other", SqlDbType.VarChar).Value = unskilledworkersqualification_other.Trim();


        if (transgenderaudult.ToString().Trim() == "" || transgenderaudult.ToString().Trim() == null || transgenderaudult.ToString().Trim() == "--Select--")
            com.Parameters.Add("@transgenderaudult", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transgenderaudult", SqlDbType.VarChar).Value = transgenderaudult.Trim();
        if (transgenderadolescents.ToString().Trim() == "" || transgenderadolescents.ToString().Trim() == null || transgenderadolescents.ToString().Trim() == "--Select--")
            com.Parameters.Add("@transgenderadolescents", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transgenderadolescents", SqlDbType.VarChar).Value = transgenderadolescents.Trim();
        if (transgenderchildren.ToString().Trim() == "" || transgenderchildren.ToString().Trim() == null || transgenderchildren.ToString().Trim() == "--Select--")
            com.Parameters.Add("@transgenderchildren", SqlDbType.VarChar).Value = DBNull.Value;
        else
            com.Parameters.Add("@transgenderchildren", SqlDbType.VarChar).Value = transgenderchildren.Trim();


        //====================================================
        con.OpenConnection();
        com.Connection = con.GetConnection;

        try
        {
            //return Convert.ToInt32(com.ExecuteScalar());
            //if (returnvalue == DBNull.Value || returnvalue == null)
            //    return 0;
            //else
            //    return Convert.ToInt32(returnvalue);

            object returnvalue = com.ExecuteScalar();
            if (returnvalue == DBNull.Value || returnvalue == null)
                return 0;
            else
                return Convert.ToInt32(returnvalue);

        }
        catch (Exception ex)
        {
            throw ex;
            //return 0;
            return 0;
        }
        finally
        {
            com.Dispose();
            con.CloseConnection();
        }
    }
    void clear()
    {

        txtNameOfIndustrialUndertaking.Text = ""; txtNameOfPromoter.Text = ""; txtSonOfDOWO.Text = ""; txtage.Text = ""; txtOccupation.Text = ""; ddlState.SelectedIndex = 0; ddlDistrict.SelectedIndex = 0; ddlMandal.SelectedIndex = 0;
        ddlVillage.SelectedIndex = 0; txtStreetName.Text = ""; txtDoorNo.Text = ""; txtLandmark.Text = ""; txtMobileNo.Text = ""; txtEmail.Text = ""; txtFax.Text = "";
        ddlNatureofOrg.SelectedIndex = 0; txtTelephone.Text = ""; txtAdultMale.Text = ""; txtAdultFemale.Text = ""; txtAdoleMale.Text = ""; txtAdoleFemale.Text = "";
        txtChildMale.Text = ""; txtChildFemale.Text = ""; ddlCateORg.SelectedIndex = 0; txtRegNo.Text = ""; txtRegDate.Text = ""; txtRegExpDate.Text = "";
        ddlProject.SelectedIndex = 0; txtRegNo.Text = ""; TxtHight_Build.Text = ""; TxtBuilt_up_Area.Text = "";

    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx");



        try
        {

            if (BtnDelete.Text == "Next")
            {
                string policeNoc = "";
                if (trpolicedetails.Visible == true)
                {
                    policeNoc = "Y";
                }
                else if (trpolicedetails.Visible == false)
                {
                    policeNoc = "N";
                }
                DataSet ds = new DataSet();

                //ds = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());

                ds = Gen.GetdataofEnterprenuerCFO(Session["uid"].ToString());


                if (ds.Tables[0].Rows.Count > 0)
                {
                    int result = 0;
                    result = insetEnterprenuerdataCFO(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["Applid"].ToString(),
                        txtNameOfIndustrialUndertaking.Text, txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, 
                        ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreetName.Text,
                        txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text, ddlNatureofOrg.SelectedValue, 
                        txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text, 
                        txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, ddlProject.SelectedValue, 
                        txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString(), txtDistrict.Text, txtMandal.Text, txtVillage.Text, 
                        ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(), ddlMinority.SelectedValue.ToString(), 
                        TxtHight_Build.Text, TxtBuilt_up_Area.Text, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, 
                        ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, ddlcommissionerate.SelectedValue.ToString(), 
                        ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(),
                        ddltrafficdivision.SelectedValue.ToString(), ddltrafficpolicestation.SelectedValue.ToString(), policeNoc, txtstaffMale.Text, txtfemale.Text, ddlManagementandStaffQualification.SelectedValue.ToString(),
                        txtmngmntstaffqualificationother.Text, txtsupermalecount.Text, txtsuperfemalecount.Text, ddlSupervisor.SelectedValue.ToString(),
                        txtsupervisorqualificationother.Text, txtSkilledWorkersMale.Text, txtSkilledWorkersFemale.Text,
                        ddlskilledworkers.SelectedValue.ToString(), txtskilledworkerqualother.Text, txtSemiSkilledWorkersMale.Text, txtSemiSkilledWorkersFemale.Text,
                        ddlsemiskilledworkers.SelectedValue.ToString(), txtsemiskilledworkerqualother.Text, TXTUNSKILLEDWORKERMALE.Text, TXTUNSKILLEDWORKERFEMALE.Text,
                        ddlunskilledworkers.SelectedValue.ToString(), txtunskilledworkersqualother.Text,
                        TXTTRANSADULTS.Text, TXTTRANSADOLESCENTS.Text, TXTTRANSCHILDREN.Text);

                    if (result > 0)
                    {

                        Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + Session["uid"].ToString());
                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else if (result == 0)
                    {

                        Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + Session["uid"].ToString());
                        lblmsg.Text = "<font color='green'>Enterprenuer Details Updated Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;
                    }
                }

                else
                {


                    if (trpolicedetails.Visible == true)
                    {
                        policeNoc = "Y";
                    }
                    else if (trpolicedetails.Visible == false)
                    {
                        policeNoc = "N";
                    }
                    int result = 0;
                    result = insetEnterprenuerdataCFO(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["Applid"].ToString(), txtNameOfIndustrialUndertaking.Text,
                        txtNameOfPromoter.Text, txtSonOfDOWO.Text, txtage.Text, txtOccupation.Text, ddlState.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue,
                        ddlVillage.SelectedValue, txtStreetName.Text, txtDoorNo.Text, txtLandmark.Text, "0", txtMobileNo.Text, txtEmail.Text, txtFax.Text,
                        ddlNatureofOrg.SelectedValue, txtTelephone.Text, txtAdultMale.Text, txtAdultFemale.Text, txtAdoleMale.Text, txtAdoleFemale.Text, txtChildMale.Text, 
                        txtChildFemale.Text, ddlCateORg.SelectedValue, txtRegNo.Text, txtRegDate.Text, txtRegExpDate.Text, ddlProject.SelectedValue, 
                        txtRegNo.Text, "0", Session["uid"].ToString(), Session["uid"].ToString(), txtDistrict.Text, txtMandal.Text, txtVillage.Text, 
                        ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(), ddlMinority.SelectedValue.ToString(),
                        TxtHight_Build.Text, TxtBuilt_up_Area.Text, txtSurveyNo.Text, ddlLand_intDistrictid.SelectedValue, ddlLand_intMandalid.SelectedValue, 
                        ddlLand_intVillageid.SelectedValue, txtName_Gramapachayat.Text, txtLand_Pincode.Text, ddlcommissionerate.SelectedValue.ToString(), 
                        ddlzone.SelectedValue.ToString(), ddldivision.SelectedValue.ToString(), ddlpolicestation.SelectedValue.ToString(), ddltrafficzone.SelectedValue.ToString(),
                        ddltrafficdivision.SelectedValue.ToString(), ddltrafficpolicestation.SelectedValue.ToString(), policeNoc, txtstaffMale.Text, txtfemale.Text, ddlManagementandStaffQualification.SelectedValue.ToString(),
                        txtmngmntstaffqualificationother.Text, txtsupermalecount.Text, txtsuperfemalecount.Text, ddlSupervisor.SelectedValue.ToString(),
                        txtsupervisorqualificationother.Text, txtSkilledWorkersMale.Text, txtSkilledWorkersFemale.Text,
                        ddlskilledworkers.SelectedValue.ToString(), txtskilledworkerqualother.Text, txtSemiSkilledWorkersMale.Text, txtSemiSkilledWorkersFemale.Text,
                        ddlsemiskilledworkers.SelectedValue.ToString(), txtsemiskilledworkerqualother.Text, TXTUNSKILLEDWORKERMALE.Text, TXTUNSKILLEDWORKERFEMALE.Text,
                        ddlunskilledworkers.SelectedValue.ToString(), txtunskilledworkersqualother.Text,
                        TXTTRANSADULTS.Text, TXTTRANSADOLESCENTS.Text, TXTTRANSCHILDREN.Text);

                    if (result > 0)
                    {

                        Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + Session["uid"].ToString());
                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Saved Successfully..!</font>";
                        success.Visible = true;
                        Failure.Visible = false;

                    }
                    else
                    {

                        lblmsg.Text = "<font color='green'>CFO Enterprenuer Details Submission Failed..!</font>";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }




    }
    void FillDetailsCFE(DataSet ds)
    {
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                txtSonOfDOWO.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

                getstates();



                //ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["intStateid"].ToString().Trim() != "")
                {
                    ddlState.SelectedValue = ddlState.Items.FindByValue(ds.Tables[0].Rows[0]["intStateid"].ToString().Trim()).Value;
                }
                if (ddlState.SelectedValue.ToString() != "--Select--")
                {
                    // getdistricts();
                    //getdistricts();
                    if (ddlState.SelectedValue.ToString() == "31")
                    {
                        dist.Visible = false;
                        mandal.Visible = false;
                        Vill.Visible = false;


                        dist1.Visible = true;
                        mandal1.Visible = true;
                        vill1.Visible = true;

                        getdistricts();
                        if (ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim() != "")
                        {
                            ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim()).Value;
                        }
                        getMandals();
                        if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                        {
                            try
                            {
                                ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim()).Value;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        getVillages();
                        if (ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim() != "")
                        {
                            // ddlVillage.SelectedValue = ddlVillage.Items.FindByValue(ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim()).Value;
                            try
                            {
                                ddlVillage.SelectedValue = ddlVillage.Items.FindByValue(ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim()).Value;
                            }
                            catch (Exception ex)
                            {

                            }
                        }


                    }
                    else
                    {
                        dist.Visible = true;
                        mandal.Visible = true;
                        Vill.Visible = true;

                        dist1.Visible = false;
                        mandal1.Visible = false;
                        vill1.Visible = false;

                    }


                }
                else
                {
                    ddlDistrict.Items.Clear();
                    ddlDistrict.Items.Insert(0, "--Select--");


                }


                txtDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                txtMandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                txtVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();



                txtStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();

                txtDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();

                //  txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

                txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                // txtAltmobileno.Text = ds.Tables[0].Rows[0]["AlternarteMobileNo"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                //if (ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim() != "")
                //{
                //    ddlType.SelectedValue = ddlType.Items.FindByValue(ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim()).Value;
                //}
                txtTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                if (ds.Tables[0].Rows[0]["ProposalFor"].ToString().Trim() != "")
                {
                    ddlProject.SelectedValue = ddlProject.Items.FindByValue(ds.Tables[0].Rows[0]["ProposalFor"].ToString().Trim()).Value;
                }

                //if (ds.Tables[0].Rows[0]["Caste"].ToString().Trim() != "")
                //{
                //    ddlCaste.SelectedValue = ddlCaste.Items.FindByValue(ds.Tables[0].Rows[0]["Caste"].ToString().Trim()).Value;
                //}

                txtAdultMale.Text = ds.Tables[0].Rows[0]["DirectMale"].ToString();

                txtAdultFemale.Text = ds.Tables[0].Rows[0]["DirectFemale"].ToString();

                // txtIndirectMale.Text = ds.Tables[0].Rows[0]["InDirectMale"].ToString();
                // txtindirectFemale.Text = ds.Tables[0].Rows[0]["InDirectFemale"].ToString();

                //  ddlCaste.SelectedValue = ddlCaste.Items.FindByValue(ds.Tables[0].Rows[0]["Caste"].ToString().Trim()).Value;


                //if (ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim() != "")
                //{
                //    ddlcategory.SelectedValue = ddlcategory.Items.FindByValue(ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim()).Value;
                //}
                txtRegNo.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();

                if (ds.Tables[0].Rows[0]["Reg_Date"].ToString().Trim() != "")
                {

                    txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MM-yyyy");
                }
                //if (ds.Tables[0].Rows[0]["TypeofFactory"].ToString().Trim() != "")
                //{
                //    ddlfactoryType.SelectedValue = ddlfactoryType.Items.FindByValue(ds.Tables[0].Rows[0]["TypeofFactory"].ToString().Trim()).Value;
                //}

                //ddlfactoryType.SelectedValue = ddlfactoryType.Items.FindByValue(ds.Tables[0].Rows[0]["TypeofFactory"].ToString().Trim()).Value;


                if (ds.Tables[0].Rows[0]["diffabled"].ToString().Trim() != "")
                {

                    ddlDifferentlyabled.SelectedValue = ddlDifferentlyabled.Items.FindByValue(ds.Tables[0].Rows[0]["diffabled"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["WomenEnterprenuer"].ToString().Trim() != "")
                {

                    ddlWomenEnterprenuer.SelectedValue = ddlWomenEnterprenuer.Items.FindByValue(ds.Tables[0].Rows[0]["WomenEnterprenuer"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["Minority"].ToString().Trim() != "")
                {

                    ddlMinority.SelectedValue = ddlWomenEnterprenuer.Items.FindByValue(ds.Tables[0].Rows[0]["Minority"].ToString().Trim()).Value;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    void FillDetails(DataSet ds)
    {
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtNameOfIndustrialUndertaking.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                txtNameOfPromoter.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                txtSonOfDOWO.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();
                txtage.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                txtOccupation.Text = ds.Tables[0].Rows[0]["Occupation"].ToString();
                ddlState.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString();
                if (Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]) == "0" || Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]) != "0")
                {
                    BindCommissionerates();
                    //ddlcommissionerate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    ddlcommissionerate.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Commissionerate"]);
                    ddlcommissionerate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                ddlzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Pol_Zone"]);
                ddlzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddldivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Pol_Division"]);
                ddldivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddlpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Pol_Station"]);
                ddltrafficzone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Tra_Station"]);
                ddltrafficzone_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficdivision.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Tra_Division"]);
                ddltrafficdivision_SelectedIndexChanged(this, EventArgs.Empty);
                ddltrafficpolicestation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Tra_Police"]);

                txtstaffMale.Text = ds.Tables[0].Rows[0]["staffmale"].ToString();
                txtfemale.Text = ds.Tables[0].Rows[0]["stafffemale"].ToString();
                ddlManagementandStaffQualification.SelectedValue = ds.Tables[0].Rows[0]["staffqulification"].ToString();
                if (ddlManagementandStaffQualification.SelectedValue == "6")
                {
                    if (ds.Tables[0].Rows[0]["staffqulification_other"].ToString() != "" || ds.Tables[0].Rows[0]["staffqulification_other"].ToString() != null)
                    {
                        txtmngmntstaffqualificationother.Text = ds.Tables[0].Rows[0]["staffqulification_other"].ToString();

                    }
                    else
                    {
                        txtmngmntstaffqualificationother.Text = "0";

                    }
                }

                txtsupermalecount.Text = ds.Tables[0].Rows[0]["supervisormale"].ToString();
                txtsuperfemalecount.Text = ds.Tables[0].Rows[0]["supervisorfemale"].ToString();
                ddlSupervisor.SelectedValue = ds.Tables[0].Rows[0]["supervisorqualification"].ToString();
                if (ddlSupervisor.SelectedValue == "6")
                {
                    if (ds.Tables[0].Rows[0]["supervisorqualification_other"].ToString() != "" || ds.Tables[0].Rows[0]["supervisorqualification_other"].ToString() != null)
                    {
                        txtsupervisorqualificationother.Text = ds.Tables[0].Rows[0]["supervisorqualification_other"].ToString();

                    }
                    else
                    {
                        txtsupervisorqualificationother.Text = "0";

                    }
                }
                txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["skilledworkersmale"].ToString();
                txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["skilledworkersfemale"].ToString();
                ddlskilledworkers.SelectedValue = ds.Tables[0].Rows[0]["skilledworkersqualification"].ToString();
                if (ddlskilledworkers.SelectedValue == "6")
                {
                    if (ds.Tables[0].Rows[0]["skilledworkersqualification_other"].ToString() != "" || ds.Tables[0].Rows[0]["skilledworkersqualification_other"].ToString() != null)
                    {
                        txtskilledworkerqualother.Text = ds.Tables[0].Rows[0]["skilledworkersqualification_other"].ToString();

                    }
                    else
                    {
                        txtskilledworkerqualother.Text = "0";

                    }
                }
                txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["semiskilledworkersmale"].ToString();
                txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["semiskilledworkersfemale"].ToString();
                ddlsemiskilledworkers.SelectedValue = ds.Tables[0].Rows[0]["semiskilledworkersqualification"].ToString();
                if (ddlsemiskilledworkers.SelectedValue == "6")
                {
                    if (ds.Tables[0].Rows[0]["semiskilledworkersqualification_other"].ToString() != "" || ds.Tables[0].Rows[0]["semiskilledworkersqualification_other"].ToString() != null)
                    {
                        txtsemiskilledworkerqualother.Text = ds.Tables[0].Rows[0]["semiskilledworkersqualification_other"].ToString();

                    }
                    else
                    {
                        txtsemiskilledworkerqualother.Text = "0";

                    }
                }
                TXTUNSKILLEDWORKERMALE.Text = ds.Tables[0].Rows[0]["unskilledworkersmale"].ToString();
                TXTUNSKILLEDWORKERFEMALE.Text = ds.Tables[0].Rows[0]["unskilledworkersfemale"].ToString();
                ddlunskilledworkers.SelectedValue = ds.Tables[0].Rows[0]["unskilledworkersqualification"].ToString();
                if (ddlunskilledworkers.SelectedValue == "6")
                {
                    if (ds.Tables[0].Rows[0]["unskilledworkersqualification_other"].ToString() != "" || ds.Tables[0].Rows[0]["unskilledworkersqualification_other"].ToString() != null)
                    {
                        txtunskilledworkersqualother.Text = ds.Tables[0].Rows[0]["unskilledworkersqualification_other"].ToString();

                    }
                    else
                    {
                        txtunskilledworkersqualother.Text = "0";

                    }
                }
                if (ddlState.SelectedValue.ToString() != "--Select--")
                {
                    // getdistricts();
                    //getdistricts();
                    if (ddlState.SelectedValue.ToString() == "31")
                    {


                        dist.Visible = false;
                        mandal.Visible = false;
                        Vill.Visible = false;


                        dist1.Visible = true;
                        mandal1.Visible = true;
                        vill1.Visible = true;

                        getdistricts();
                        //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();

                        //getdistricts();
                        if (ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim() != "")
                        {
                            // ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim()).Value;

                            ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
                        }
                        getMandals();
                        if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                        {
                            //ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim()).Value;
                            ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["intMandalid"].ToString();

                        }
                        getVillages();
                        if (ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim() != "")
                        {
                            //ddlvillage.SelectedValue = ddlvillage.Items.FindByValue(ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim()).Value;
                            ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["intVillageid"].ToString();
                        }


                    }
                    else
                    {
                        dist.Visible = true;
                        mandal.Visible = true;
                        Vill.Visible = true;

                        dist1.Visible = false;
                        mandal1.Visible = false;
                        vill1.Visible = false;

                    }


                }
                else
                {
                    ddlDistrict.Items.Clear();
                    ddlDistrict.Items.Insert(0, "--Select--");


                }



                txtDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                txtMandal.Text = ds.Tables[0].Rows[0]["MandalName"].ToString();
                txtVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();

                //ddlDistrict.SelectedValue = ddlDistrict.Items.FindByValue(ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim()).Value; 

                //getdistricts();
                //ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
                //getMandals();
                //ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["intMandalid"].ToString();
                //getVillages();
                //ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["intVillageid"].ToString();
                txtStreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
                txtDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                txtLandmark.Text = ds.Tables[0].Rows[0]["Land_Mark"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtFax.Text = ds.Tables[0].Rows[0]["Fax"].ToString();
                if (ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim() != "")
                {
                    ddlNatureofOrg.SelectedValue = ddlNatureofOrg.Items.FindByValue(ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim()).Value;
                }
                txtTelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["AdultMale"].ToString() == "" || ds.Tables[0].Rows[0]["AdultMale"].ToString() == null)
                    {
                        txtAdultMale.Enabled = true;
                    }
                    else
                    {
                        txtAdultMale.Enabled = false;
                        txtAdultMale.Text = ds.Tables[0].Rows[0]["AdultMale"].ToString();
                    }
                }
                else
                {
                    txtAdultMale.Enabled = true;
                    txtAdultMale.Text = ds.Tables[0].Rows[0]["AdultMale"].ToString();

                }
                
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["AdultFemale"].ToString() == "" || ds.Tables[0].Rows[0]["AdultFemale"].ToString() == null)
                    {
                        txtAdultFemale.Enabled = true;
                    }
                    else
                    {
                        txtAdultFemale.Enabled = false;
                        txtAdultFemale.Text = ds.Tables[0].Rows[0]["AdultFemale"].ToString();
                    }
                }
                else
                {
                    txtAdultFemale.Enabled = true;
                    txtAdultFemale.Text = ds.Tables[0].Rows[0]["AdultFemale"].ToString();
                }
               
                if (res == "3" )
                {
                    if (ds.Tables[0].Rows[0]["TRANSGENDER_ADULT"].ToString() == ""|| ds.Tables[0].Rows[0]["TRANSGENDER_ADULT"].ToString() ==null)
                    {
                        TXTTRANSADULTS.Enabled = true;
                    }
                    else
                    {
                        TXTTRANSADULTS.Enabled = false;
                        TXTTRANSADULTS.Text = ds.Tables[0].Rows[0]["TRANSGENDER_ADULT"].ToString();
                    }
                }
                else
                {
                    TXTTRANSADULTS.Enabled = true;
                    TXTTRANSADULTS.Text = ds.Tables[0].Rows[0]["TRANSGENDER_ADULT"].ToString();
                }
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["Adolescents_Male"].ToString() == "" || ds.Tables[0].Rows[0]["Adolescents_Male"].ToString() == null)
                    {
                        txtAdoleMale.Enabled = true;
                    }
                    else
                    {
                        txtAdoleMale.Enabled = false;
                        txtAdoleMale.Text = ds.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                    }
                }
                else
                {
                    txtAdoleMale.Enabled = true;
                    txtAdoleMale.Text = ds.Tables[0].Rows[0]["Adolescents_Male"].ToString();
                }
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["Adolescents_Female"].ToString() == "" || ds.Tables[0].Rows[0]["Adolescents_Female"].ToString() == null)
                    {
                        txtAdoleFemale.Enabled = true;
                    }
                    else
                    {
                        txtAdoleFemale.Enabled = false;
                        txtAdoleFemale.Text = ds.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                    }
                }
                else
                {
                    txtAdoleFemale.Enabled = true;
                    txtAdoleFemale.Text = ds.Tables[0].Rows[0]["Adolescents_Female"].ToString();
                }
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["TRANSGENDER_ADOLESCENTS"].ToString() == "" || ds.Tables[0].Rows[0]["TRANSGENDER_ADOLESCENTS"].ToString() == null)
                    {
                        TXTTRANSADOLESCENTS.Enabled = true;
                    }
                    else
                    {
                        TXTTRANSADOLESCENTS.Enabled = false;
                        TXTTRANSADOLESCENTS.Text = ds.Tables[0].Rows[0]["TRANSGENDER_ADOLESCENTS"].ToString();
                    }
                }
                else
                {
                    TXTTRANSADOLESCENTS.Enabled = true;
                    TXTTRANSADOLESCENTS.Text = ds.Tables[0].Rows[0]["TRANSGENDER_ADOLESCENTS"].ToString();
                }

               
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["Children_Male"].ToString() == "" || ds.Tables[0].Rows[0]["Children_Male"].ToString() == null)
                    {
                        txtChildMale.Enabled = true;
                    }
                    else
                    {
                        txtChildMale.Enabled = false;
                        txtChildMale.Text = ds.Tables[0].Rows[0]["Children_Male"].ToString();
                    }
                }
                else
                {
                    txtChildMale.Enabled = true;
                    txtChildMale.Text = ds.Tables[0].Rows[0]["Children_Male"].ToString();
                }
                
                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["Children_Female"].ToString() == "" || ds.Tables[0].Rows[0]["Children_Female"].ToString() == null)
                    {
                        txtChildFemale.Enabled = true;
                    }
                    else
                    {
                        txtChildFemale.Enabled = false;
                        txtChildFemale.Text = ds.Tables[0].Rows[0]["Children_Female"].ToString();
                    }
                }
                else
                {
                    txtChildFemale.Enabled = true;
                    txtChildFemale.Text = ds.Tables[0].Rows[0]["Children_Female"].ToString();
                }

                if (res == "3")
                {
                    if (ds.Tables[0].Rows[0]["TRANSGENDER_CHILDRES"].ToString() == "" || ds.Tables[0].Rows[0]["TRANSGENDER_CHILDRES"].ToString() == null)
                    {
                        TXTTRANSCHILDREN.Enabled = true;
                    }
                    else
                    {
                        TXTTRANSCHILDREN.Enabled = false;
                        TXTTRANSCHILDREN.Text = ds.Tables[0].Rows[0]["TRANSGENDER_CHILDRES"].ToString();
                    }
                }
                else
                {
                    TXTTRANSCHILDREN.Enabled = true;
                    TXTTRANSCHILDREN.Text = ds.Tables[0].Rows[0]["TRANSGENDER_CHILDRES"].ToString();
                }


                if (ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim() != "")
                {
                    ddlCateORg.SelectedValue = ddlCateORg.Items.FindByValue(ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim()).Value;
                }
                txtRegNo.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();
                if (ds.Tables[0].Rows[0]["Reg_Date"].ToString().Trim() != "")
                {
                    txtRegDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_Date"]).ToString("dd-MMM-yyyy");
                }
                if (ds.Tables[0].Rows[0]["Reg_ExpDate"].ToString().Trim() != "")
                {
                    txtRegExpDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Reg_ExpDate"]).ToString("dd-MMM-yyyy");
                }
                if (ds.Tables[0].Rows[0]["TypeofFactory"].ToString().Trim() != "")
                {
                    ddlProject.SelectedValue = ddlProject.Items.FindByValue(ds.Tables[0].Rows[0]["TypeofFactory"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["diffabled"].ToString().Trim() != "")
                {

                    ddlDifferentlyabled.SelectedValue = ddlDifferentlyabled.Items.FindByValue(ds.Tables[0].Rows[0]["diffabled"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["WomenEnterprenuer"].ToString().Trim() != "")
                {

                    ddlWomenEnterprenuer.SelectedValue = ddlWomenEnterprenuer.Items.FindByValue(ds.Tables[0].Rows[0]["WomenEnterprenuer"].ToString().Trim()).Value;
                }

                if (ds.Tables[0].Rows[0]["Minority"].ToString().Trim() != "")
                {

                    ddlMinority.SelectedValue = ddlWomenEnterprenuer.Items.FindByValue(ds.Tables[0].Rows[0]["Minority"].ToString().Trim()).Value;
                }

                TxtBuilt_up_Area.Text = ds.Tables[0].Rows[0]["Built_up_Area"].ToString();
                TxtHight_Build.Text = ds.Tables[0].Rows[0]["Hight_Build"].ToString();
                if (ds.Tables[0].Rows[0]["SurveyNo"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["SurveyNo"].ToString() != null)
                {
                    txtSurveyNo.Text = ds.Tables[0].Rows[0]["SurveyNo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Land_Pincode"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["Land_Pincode"].ToString() != null)
                {
                    txtLand_Pincode.Text = ds.Tables[0].Rows[0]["Land_Pincode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name_Gramapachayat"].ToString().Trim() != "" && ds.Tables[0].Rows[0]["Name_Gramapachayat"].ToString() != null)
                {
                    txtName_Gramapachayat.Text = ds.Tables[0].Rows[0]["Name_Gramapachayat"].ToString();
                }
                //txtRegNo.Text = ds.Tables[0].Rows[0]["Reg_id"].ToString();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        clear();
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
    protected void ddlstatus32_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact7_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact35_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        //getdistricts();


        if (ddlState.SelectedValue.ToString() != "--Select--")
        {
            // getdistricts();

            if (ddlState.SelectedValue.ToString() == "31")
            {
                getdistricts();

                dist.Visible = false;
                mandal.Visible = false;
                Vill.Visible = false;

                dist1.Visible = true;
                mandal1.Visible = true;
                vill1.Visible = true;


            }
            else
            {
                dist.Visible = true;
                mandal.Visible = true;
                Vill.Visible = true;

                dist1.Visible = false;
                mandal1.Visible = false;
                vill1.Visible = false;

            }


        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, "--Select--");


        }



    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        getMandals();
    }

    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        getVillages();
    }

    protected void ddlLand_intMandalid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLand_intMandalid.SelectedValue.ToString() != "--Select--")
        {
            getVillagesland();

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
            getMandalsland();
        }
        else
        {

        }
    }

    public DataSet GetZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATEID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETZONES", pp);
        return Dsnew;
    }

    public void BindCommissionerates()
    {
        DataSet dscommission = new DataSet();
        dscommission = GetCommissionerates();
        if (dscommission.Tables[0].Rows.Count > 0)
        {
            ddlcommissionerate.DataSource = dscommission.Tables[0];
            ddlcommissionerate.DataTextField = "Commissionerate_Name";
            ddlcommissionerate.DataValueField = "Commissionerate_Id";
            ddlcommissionerate.DataBind();

            ddlcommissionerate.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetCommissionerates()
    {
        DataSet Dsnew = new DataSet();

        Dsnew = Gen.GenericFillDs("GETCOMMISSIONERATES");
        return Dsnew;
    }
    protected void ddlcommissionerate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dszone = new DataSet();
        dszone = GetZones(ddlcommissionerate.SelectedValue);
        if (dszone.Tables[0].Rows.Count > 0)
        {
            ddlzone.DataSource = dszone.Tables[0];
            ddlzone.DataTextField = "zone_name";
            ddlzone.DataValueField = "zone_id";
            ddlzone.DataBind();

            ddlzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        DataSet dstrafficzone = new DataSet();
        dstrafficzone = GetTrafficZones(ddlcommissionerate.SelectedValue);
        if (dstrafficzone.Tables[0].Rows.Count > 0)
        {
            ddltrafficzone.DataSource = dstrafficzone.Tables[0];
            ddltrafficzone.DataTextField = "Traffic_zone_name";
            ddltrafficzone.DataValueField = "Traffic_zone_id";
            ddltrafficzone.DataBind();

            ddltrafficzone.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficZones(string commissionerateid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICZONES", pp);
        return Dsnew;
    }
    protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dsdivision = new DataSet();
        dsdivision = GetDivisions(ddlzone.SelectedValue);
        if (dsdivision.Tables[0].Rows.Count > 0)
        {
            ddldivision.DataSource = dsdivision.Tables[0];
            ddldivision.DataTextField = "division_name";
            ddldivision.DataValueField = "division_id";
            ddldivision.DataBind();

            ddldivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetPoliceStatioons(ddlcommissionerate.SelectedValue, ddldivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddlpolicestation.DataSource = dspolice.Tables[0];
            ddlpolicestation.DataTextField = "policestation_name";
            ddlpolicestation.DataValueField = "policestation_id";
            ddlpolicestation.DataBind();

            ddlpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetPoliceStatioons(string commissionerateid, string divisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@DIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = divisionid;
        Dsnew = Gen.GenericFillDs("GETPOLICESTATIONS", pp);
        return Dsnew;
    }
    public DataSet GetDivisions(string zoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@ZONEID",SqlDbType.VarChar)
        };
        pp[0].Value = zoneid;
        Dsnew = Gen.GenericFillDs("GETDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficzone_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dstrafficdivision = new DataSet();
        dstrafficdivision = GetTrafficDivisions(ddltrafficzone.SelectedValue);
        if (dstrafficdivision.Tables[0].Rows.Count > 0)
        {
            ddltrafficdivision.DataSource = dstrafficdivision.Tables[0];
            ddltrafficdivision.DataTextField = "Traffic_division_name";
            ddltrafficdivision.DataValueField = "Traffic_division_id";
            ddltrafficdivision.DataBind();

            ddltrafficdivision.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficDivisions(string trafficzoneid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@TRAFFICZONE_ID",SqlDbType.VarChar)
        };
        pp[0].Value = trafficzoneid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICDIVISIONS", pp);
        return Dsnew;
    }

    protected void ddltrafficdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dspolice = new DataSet();
        dspolice = GetTrafficPoliceStatioons(ddlcommissionerate.SelectedValue, ddltrafficdivision.SelectedValue);
        if (dspolice.Tables[0].Rows.Count > 0)
        {
            ddltrafficpolicestation.DataSource = dspolice.Tables[0];
            ddltrafficpolicestation.DataTextField = "Traffic_policestation_name";
            ddltrafficpolicestation.DataValueField = "Traffic_policestation_id";
            ddltrafficpolicestation.DataBind();

            ddltrafficpolicestation.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public DataSet GetTrafficPoliceStatioons(string commissionerateid, string trafficdivisionid)
    {
        DataSet Dsnew = new DataSet();
        SqlParameter[] pp = new SqlParameter[]
        {
             new SqlParameter("@COMMISSIONERATE_ID",SqlDbType.VarChar),
             new SqlParameter("@TRAFFICDIVISION_ID",SqlDbType.VarChar)
        };
        pp[0].Value = commissionerateid;
        pp[1].Value = trafficdivisionid;
        Dsnew = Gen.GenericFillDs("GETTRAFFICPOLICESTATIONS", pp);
        return Dsnew;
    }
    protected void ddlManagementandStaffQualification_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtmngmntstaffqualificationother.Text = "";
        if (ddlManagementandStaffQualification.SelectedItem.Text == "OTHER")
        {
            txtmngmntstaffqualificationother.Enabled = true;
            txtmngmntstaffqualificationother.ReadOnly = false;
        }
        else
        {
            txtmngmntstaffqualificationother.Enabled = false;
        }
    }

    protected void ddlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtsupervisorqualificationother.Text = "";
        if (ddlSupervisor.SelectedItem.Text == "OTHER")
        {
            txtsupervisorqualificationother.Enabled = true;
                txtsupervisorqualificationother.ReadOnly=false;
        }
        else
        {
            txtsupervisorqualificationother.Enabled = false;
        }
    }

    protected void ddlskilledworkers_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtskilledworkerqualother.Text = "";
        if (ddlskilledworkers.SelectedItem.Text == "OTHER")
        {
            txtskilledworkerqualother.Enabled = true;
            txtskilledworkerqualother.ReadOnly = false;
        }
        else
        {
            txtskilledworkerqualother.Enabled = false;
        }
    }

    protected void ddlsemiskilledworkers_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtsemiskilledworkerqualother.Text = "";
        if (ddlsemiskilledworkers.SelectedItem.Text == "OTHER")
        {
            txtsemiskilledworkerqualother.Enabled = true;
            txtsemiskilledworkerqualother.ReadOnly = false;
        }
        else
        {
            txtsemiskilledworkerqualother.Enabled = false;
        }
    }

    protected void ddlunskilledworkers_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtunskilledworkersqualother.Text = "";
        if (ddlunskilledworkers.SelectedItem.Text == "OTHER")
        {
            txtunskilledworkersqualother.Enabled = true;
            txtunskilledworkersqualother.ReadOnly = false;
        }
        else
        {
            txtunskilledworkersqualother.Enabled = false;
        }

    }

}
