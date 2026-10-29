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

    int male;
    int female;
    int transgender;
    protected void Page_Load(object sender, EventArgs e)
    {

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

            if (dscheck.Tables[6].Rows.Count > 0)
            {
                HDNDATEOFPAYMENT.Value = dscheck.Tables[6].Rows[0]["PAYMENTDATE"].ToString().Trim();

            }
            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");
                HDNAPPLSTATUS.Value = res;

                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
             
                }

            }


            getstates();
            if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
            {
                Response.Redirect("frmQuesstionniareReg.aspx");
            }


            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {
                DataSet dsnew = new DataSet();

                dsnew = Gen.GetEnterPreneurdatabyQuewaterReq(Session["Applid"].ToString());
                if (dsnew.Tables[0].Rows.Count > 0)
                {
                    txtlandValue.Text = dsnew.Tables[0].Rows[0]["Val_Land"].ToString().Trim();
                    txtlandValue.Enabled = false;
                    txtbuilding.Text = dsnew.Tables[0].Rows[0]["Val_Build"].ToString().Trim();

                    txtbuilding.Enabled = false;
                    txtPlant.Text = dsnew.Tables[0].Rows[0]["Val_Plant"].ToString().Trim();
                    txtPlant.Enabled = false;
                    txttotal.Text = dsnew.Tables[0].Rows[0]["Tot_PrjCost"].ToString().Trim();
                    txttotal.Enabled = false;

                    if (dsnew.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim() != "")
                    {
                        if (dsnew.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim() == "New")
                        {
                            tdprojectcostname.InnerHtml = "<u>A). New Investment</u>";
                            tblexpansion.Visible = false;
                            tblexpansionheading.Visible = false;
                            trtotalinv.Visible = false;
                            trtotalinvinv.Visible = false;
                        }
                        else if (dsnew.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim() == "Expansion")
                        {
                            tdprojectcostname.InnerHtml = "<u>A). Existing Investment</u>";
                            tblexpansion.Visible = true;
                            tblexpansionheading.Visible = true;
                            trtotalinv.Visible = true;
                            trtotalinvinv.Visible = true;


                            txtlandValueexp.Text = dsnew.Tables[0].Rows[0]["Val_LandExpansion"].ToString().Trim();
                            txtlandValueexp.Enabled = false;


                            txtbuildingexp.Text = dsnew.Tables[0].Rows[0]["Val_BuildExpansion"].ToString().Trim();
                            txtbuildingexp.Enabled = false;

                            txtPlantexp.Text = dsnew.Tables[0].Rows[0]["Val_PlantExpansion"].ToString().Trim();
                            txtPlantexp.Enabled = false;

                            txttotalexp.Text = dsnew.Tables[0].Rows[0]["Tot_PrjCostExpansion"].ToString().Trim();
                            txttotalexp.Enabled = false;
                            if (txtlandValueexp.Text.Trim().TrimStart() == "")
                            {
                                txtlandValueexp.Text = "0";
                            }
                            if (txtbuildingexp.Text.Trim().TrimStart() == "")
                            {
                                txtbuildingexp.Text = "0";
                            }
                            if (txtPlantexp.Text.Trim().TrimStart() == "")
                            {
                                txtPlantexp.Text = "0";
                            }
                            if (txttotalexp.Text.Trim().TrimStart() == "")
                            {
                                txttotalexp.Text = "0";
                            }
                            txtlandValueexptotal.Text = (Convert.ToDouble(txtlandValueexp.Text.Trim().TrimStart()) + Convert.ToDouble(txtlandValue.Text.Trim().TrimStart())).ToString();
                            txtbuildingexptotal.Text = (Convert.ToDouble(txtbuildingexp.Text.Trim().TrimStart()) + Convert.ToDouble(txtbuilding.Text.Trim().TrimStart())).ToString();
                            txtPlantexptotal.Text = (Convert.ToDouble(txtPlantexp.Text.Trim().TrimStart()) + Convert.ToDouble(txtPlant.Text.Trim().TrimStart())).ToString();
                            txttotalexptotal.Text = (Convert.ToDouble(txtlandValueexptotal.Text.Trim().TrimStart()) + Convert.ToDouble(txtbuildingexptotal.Text.Trim().TrimStart()) + Convert.ToDouble(txtPlantexptotal.Text.Trim().TrimStart())).ToString();

                            txtlandValueexptotal.Enabled = false;
                            txtbuildingexptotal.Enabled = false;
                            txtPlantexptotal.Enabled = false;
                            txttotalexptotal.Enabled = false;
                        }
                        else
                        {
                            tdprojectcostname.InnerHtml = "<u>New Investment</u>";
                            tblexpansion.Visible = false;
                            tblexpansionheading.Visible = false;
                        }
                    }
                    else
                    {
                        tdprojectcostname.InnerHtml = "<u>New Investment</u>";
                        tblexpansion.Visible = false;
                        tblexpansionheading.Visible = false;
                    }
                    if (dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString().Trim() != "")
                    {
                        //ddlType.SelectedValue = ddlType.Items.FindByValue(dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString()).Value;
                        //ddlType.Enabled = false;
                        if (ddlType.Items.FindByValue(dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString()) != null)
                        {
                            ddlType.SelectedValue = ddlType.Items.FindByValue(dsnew.Tables[0].Rows[0]["Const_of_unit"].ToString()).Value;
                            ddlType.Enabled = false;
                        }
                        else
                        {
                            ddlType.Enabled = true; ;
                        }
                    }

                    txtindustrialName.Text = dsnew.Tables[0].Rows[0]["nameofunit"].ToString().Trim();
                    txtindustrialName.Enabled = false;

                    //if (dsnew.Tables[0].Rows[0]["Sector_Ent"].ToString().Trim() != "")
                    //{
                    //    ddlcategory.SelectedValue = ddlcategory.Items.FindByValue(dsnew.Tables[0].Rows[0]["Sector_Ent"].ToString()).Value;
                    //    ddlcategory.Enabled = false;
                    //}

                    if (dsnew.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim() == "N")
                    {
                        ddlfactoryType.SelectedIndex = 2;
                        ddlfactoryType.Enabled = false;
                    }
                    else if (dsnew.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim() == "Y")
                    {
                        ddlfactoryType.SelectedIndex = 1;
                        ddlfactoryType.Enabled = false;
                    }
                    else
                    {
                        //  ddlfactoryType.Enabled = true;
                    }

                    if (dsnew.Tables[0].Rows[0]["ProposalForQue"].ToString() != "")
                    {
                        ddlproposal.SelectedValue = ddlproposal.Items.FindByText(dsnew.Tables[0].Rows[0]["ProposalForQue"].ToString().Trim()).Value;
                        ddlproposal.Enabled = false;
                    }
                    lbltotalEmployment.Text = dsnew.Tables[0].Rows[0]["Prop_Emp"].ToString().Trim();
                }
            }

        }

        //    if (Request.QueryString["intApplicationId"] != null)
        //    {
        //        hdfFlagID0.Value = Request.QueryString["intApplicationId"];
        //        hdfFlagID.Value = "0";
        //    }
        //}

        if (Request.QueryString.Count > 0)
        {
            if (Request.QueryString["intApplicationId"] != null)
            {
                DataSet dsch = new DataSet();
                dsch = Gen.GetEnterPreneurdatabyQue(Request.QueryString["intApplicationId"].ToString().Trim());
                if (dsch.Tables[0].Rows.Count > 0)
                {

                    hdfFlagID0.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                    if (dsch.Tables[0].Rows[0]["intStatusid"].ToString().Trim() == "3")
                    {
                        Response.Redirect("CFEPrint.aspx?id=" + dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
                    }
                    if (!IsPostBack)
                    {
                        FillDetails();

                    }
                }


            }
        }

        else
        {
            DataSet dsch = new DataSet();
            dsch = Gen.GetEnterPreneurdatabyQue(Session["Applid"].ToString().Trim());
            if (dsch.Tables[0].Rows.Count > 0)
            {
                hdfFlagID0.Value = dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim();
                if (dsch.Tables[0].Rows[0]["intStatusid"].ToString().Trim() == "3")
                {
                    Response.Redirect("CFEPrint.aspx?id=" + dsch.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
                }
                if (!IsPostBack)
                {
                    FillDetails();

                }
            }
        }

        //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        //{

        //}
        //if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        //{
        //    FillDetails();
        //    lblmsg.Text = "";


        //}
        if (!IsPostBack)
        {
            if (txtAltmobileno.Text.Trim().TrimStart() == "")
            {
                txtAltmobileno.ReadOnly = false;
            }
            else
            {
                if (txtAltmobileno.Text.Trim() != txtmobileNo.Text.Trim())
                {
                    txtAltmobileno.ReadOnly = true;
                    txtAltmobileno.Enabled = true;
                }
                else
                {
                    txtAltmobileno.ReadOnly = false;
                }
                //txtAltmobileno.ReadOnly = true;
            }
            if (ddlfactoryType.SelectedItem.Text == "--Select--")
            {
                ddlfactoryType.Enabled = true;
            }
            else
            {
                ddlfactoryType.Enabled = false;
            }
            if (ddlvillage.SelectedItem.Text == "--Select--")
            {
                ddlvillage.Enabled = true;
            }
            //else
            //{
            //    ddlvillage.Enabled = false;
            //}
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
                        if (txtdirectTransgender.Text == "" || txtdirectTransgender.Text == null)
                        {
                            txtdirectTransgender.Enabled = true;
                            txtdirectTransgender.ReadOnly = false;
                        }
                        
                        if (TXTINDIRECTTRANSGENDER.Text == "" || TXTINDIRECTTRANSGENDER.Text == null)
                        {
                            TXTINDIRECTTRANSGENDER.Enabled = true;
                            TXTINDIRECTTRANSGENDER.ReadOnly = false;
                        }
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

    void getstates()
    {
        DataSet ds = new DataSet();
        ds = Gen.getStates();

        ddlstate.DataSource = ds.Tables[0];
        ddlstate.DataTextField = "State_Name";
        ddlstate.DataValueField = "State_id";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, "--Select--");


    }


    protected void getdistricts()
    {
        //DataSet dsnew = new DataSet();
        //dsnew = Gen.GetDistrictsbystate(ddlstate.SelectedValue.ToString());

        Cls_MasterofTsipass obj_newdistrictwargnal = new Cls_MasterofTsipass();
        DataSet dsnew = new DataSet();
        //ddlProp_intDistrictid.Items.Clear();
        dsnew = obj_newdistrictwargnal.GetallDistrictswithoutWarangal(Convert.ToString(Session["uid"]), "CFE");
        ddldistrict.DataSource = dsnew.Tables[0];
        ddldistrict.DataTextField = "District_Name";
        ddldistrict.DataValueField = "District_Id";
        ddldistrict.DataBind();
        ddldistrict.Items.Insert(0, "--Select--");

    }

    void getMandals()
    {

        DataSet dsnew = new DataSet();

        dsnew = Gen.Getmandalsbydistrict(ddldistrict.SelectedValue.ToString());
        ddlMandal.DataSource = dsnew.Tables[0];
        ddlMandal.DataTextField = "Manda_lName";
        ddlMandal.DataValueField = "Mandal_Id";
        ddlMandal.DataBind();
        ddlMandal.Items.Insert(0, "--Select--");


    }

    void getVillages()
    {

        DataSet dsnew = new DataSet();
        if (HDNAPPLSTATUS.Value == "3" && DateTime.ParseExact(HDNDATEOFPAYMENT.Value, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact("06-12-2025", "dd-MM-yyyy", CultureInfo.InvariantCulture))
        {

            dsnew = Gen.GetVillagebymandal(ddlMandal.SelectedValue.ToString());
            ddlvillage.DataSource = dsnew.Tables[0];
            ddlvillage.DataTextField = "Village_Name";
            ddlvillage.DataValueField = "Village_Id";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, "--Select--");
        }

        else
        {
            ddlvillage.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = GetVillagesWITHOUT111GMVILLAGES(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlvillage.DataSource = dsv.Tables[0];
                ddlvillage.DataValueField = "Village_Id";
                ddlvillage.DataTextField = "Village_Name";
                ddlvillage.DataBind();
                ddlvillage.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, "--Village--");
            }
        }

    }
    public DataSet GetVillagesWITHOUT111GMVILLAGES(string Mandal)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetVillages_WITHOUT111GMVILLAGES", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            if (Mandal.Trim() == "" || Mandal.Trim() == null || Mandal.Trim() == "--Select--")
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = DBNull.Value;
            else
                da.SelectCommand.Parameters.Add("@inMandalid", SqlDbType.VarChar).Value = Mandal.ToString();

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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //string number = "";

        //if (hdfID.Value != "")
        //{

        //    number = hdfpencode.Value;
        //}

        //DataSet ds = new DataSet();

        //ds = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{

        //    lblmsg0.Text = "<font color='green'>This Questionary was Registered ..!</font>";
        //    //  this.Clear();
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;

        //}


        string errormsg = "";

        if (BtnSave1.Text == "Save")
        {

            DataSet ds = new DataSet();

            ds = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtPincode.Text.Length.ToString() != "6")
                {
                    lblmsg0.Text = "<font color='red'>Pin number length must be exactly 6 characters!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (txtmobileNo.Text.Length.ToString() != "10")
                {
                    lblmsg0.Text = "<font color='red'>Mobile number length must be exactly 10 characters!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (txtmobileNo.Text.Trim() == txtAltmobileno.Text.Trim())
                {
                    lblmsg0.Text = "<font color='red'>Mobile number and Alternate Mobile number should not be same!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                int result = 0;

                errormsg = CheckEmp();
                if (errormsg.Trim().TrimStart() == "")
                {



                    result = Gen.insertEnterprenuerdata(ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim(), Session["Applid"].ToString(), txtindustrialName.Text,
                        txtPromotor.Text, txtSoromoter.Text, ddlstate.SelectedValue, ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddlvillage.SelectedValue,
                        txtstreetName.Text, txtDoorNo.Text, txtPincode.Text,
                        txtmobileNo.Text, txtEmail.Text, ddlType.SelectedValue, txttelephone.Text, ddlproposal.SelectedValue, ddlCaste.SelectedValue, txtDirectmale.Text,
                        txtdirectfemale.Text, txtIndirectMale.Text, txtindirectFemale.Text, ddlcategory.SelectedValue, txtregNo.Text, txtRegDate.Text,
                        ddlfactoryType.SelectedValue, Session["uid"].ToString(), txtlandValue.Text, txtPlant.Text, txtbuilding.Text, txttotal.Text,
                        txtUIDnumber.Text, txtDistrict.Text, txtMandal.Text, txtVillage.Text, ddlDifferentlyabled.SelectedValue.ToString(),
                        ddlWomenEnterprenuer.SelectedValue.ToString(), ddlMinority.SelectedValue.ToString(), txtAltmobileno.Text.Trim(),
                         txtdirectTransgender.Text, TXTINDIRECTTRANSGENDER.Text);
                    if (result > 0)
                {
                    //ResetFormControl(this);


                    //  Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + result.ToString());
                    // clear();
                    lblmsg.Text = "<font color='green'>Enterprenuer Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Enterprenuer Details Updated Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                }


                else
                {
                    // clear();
                    lblmsg0.Text = "<font color='red'>Enterprenuer Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
                }
                else
                {
                     txtdirectTransgender.Text = "";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            else
            {

                int result = 0;

                errormsg = CheckEmp();
                if (errormsg.Trim().TrimStart() == "")
                {
                    result = Gen.insertEnterprenuerdata("0", Session["Applid"].ToString(), txtindustrialName.Text, txtPromotor.Text, txtSoromoter.Text,
                        ddlstate.SelectedValue, ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddlvillage.SelectedValue, txtstreetName.Text,
                        txtDoorNo.Text, txtPincode.Text, txtmobileNo.Text, txtEmail.Text, ddlType.SelectedValue, txttelephone.Text, ddlproposal.SelectedValue,
                        ddlCaste.SelectedValue, txtDirectmale.Text, txtdirectfemale.Text, txtIndirectMale.Text, txtindirectFemale.Text,
                        ddlcategory.SelectedValue, txtregNo.Text, txtRegDate.Text, ddlfactoryType.SelectedValue, Session["uid"].ToString(),
                        txtlandValue.Text, txtPlant.Text, txtbuilding.Text, txttotal.Text, txtUIDnumber.Text, txtDistrict.Text, txtMandal.Text,
                        txtVillage.Text, ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(),
                        ddlMinority.SelectedValue.ToString(), txtAltmobileno.Text.Trim(),
                         txtdirectTransgender.Text, TXTINDIRECTTRANSGENDER.Text);
                    if (result > 0)
                {
                    //ResetFormControl(this);


                    //  Response.Redirect("frmLINEOFMANUFACTURE.aspx?intApplicationId=" + result.ToString());
                    // clear();
                    lblmsg.Text = "<font color='green'>Enterprenuer Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    // clear();
                    lblmsg0.Text = "<font color='red'>Enterprenuer Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
                }
                else
                {
                    txtdirectTransgender.Text = "";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }

        }

    }
    void clear()
    {

        txtindustrialName.Text = "";
        txtPromotor.Text = ""; txtSoromoter.Text = ""; ddlstate.SelectedIndex = 0; ddldistrict.SelectedIndex = 0; ddlMandal.SelectedIndex = 0; ddlvillage.SelectedIndex = 0; txtstreetName.Text = "";
        txtDoorNo.Text = ""; txtPincode.Text = ""; txtmobileNo.Text = ""; txtEmail.Text = ""; ddlType.SelectedIndex = 0; txttelephone.Text = ""; ddlproposal.SelectedIndex = 0; ddlcategory.SelectedIndex = 0;
        txtDirectmale.Text = ""; txtdirectfemale.Text = ""; txtIndirectMale.Text = ""; txtindirectFemale.Text = ""; ddlcategory.SelectedIndex = 0; txtregNo.Text = "";
        txtRegDate.Text = ""; ddlfactoryType.SelectedIndex = 0;
        ddlCaste.SelectedIndex = 0;


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        string number = "";


        if (hdfFlagID0.Value != "")
        {

            //number = hdfpencode.Value;
            number = hdfFlagID1.Value;
        }


        //DataSet ds = new DataSet();

        //ds = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{

        //    lblmsg.Text = "<font color='green'>This Questionary was Registered ..!</font>";
        //    //  this.Clear();
        //    success.Visible = false;
        //    Failure.Visible = true;
        //    return;

        //}

        string errormsg = "";
        if (BtnDelete.Text == "Next")
        {
            DataSet ds = new DataSet();

            ds = Gen.GetdataofEnterprenuer(Session["Applid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtPincode.Text.Length.ToString() != "6")
                {
                    lblmsg0.Text = "<font color='red'>Pin number length must be exactly 6 characters!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (txtmobileNo.Text.Length.ToString() != "10")
                {
                    lblmsg0.Text = "<font color='red'>Mobile number length must be exactly 10 characters!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (txtmobileNo.Text.Trim() == txtAltmobileno.Text.Trim())
                {
                    lblmsg0.Text = "<font color='red'>Mobile number and Alternate Mobile number should not be same!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                
                int result = 0;

                errormsg = CheckEmp();
                if (errormsg.Trim().TrimStart() == "")
                {

                    result = Gen.insertEnterprenuerdata(ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim(), Session["Applid"].ToString(), txtindustrialName.Text,
                        txtPromotor.Text, txtSoromoter.Text, ddlstate.SelectedValue, ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddlvillage.SelectedValue,
                        txtstreetName.Text, txtDoorNo.Text, txtPincode.Text, txtmobileNo.Text, txtEmail.Text, ddlType.SelectedValue, txttelephone.Text,
                        ddlproposal.SelectedValue, ddlCaste.SelectedValue, txtDirectmale.Text, txtdirectfemale.Text, txtIndirectMale.Text, txtindirectFemale.Text,
                        ddlcategory.SelectedValue, txtregNo.Text, txtRegDate.Text, ddlfactoryType.SelectedValue, Session["uid"].ToString(), txtlandValue.Text,
                        txtPlant.Text, txtbuilding.Text, txttotal.Text, txtUIDnumber.Text, txtDistrict.Text, txtMandal.Text, txtVillage.Text, ddlDifferentlyabled.SelectedValue.ToString(),
                        ddlWomenEnterprenuer.SelectedValue.ToString(), ddlMinority.SelectedValue.ToString(), txtAltmobileno.Text.Trim(),
                        txtdirectTransgender.Text, TXTINDIRECTTRANSGENDER.Text);
                    if (result > 0)
                {
                    //ResetFormControl(this);


                    Response.Redirect("frmLandDetails.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;



                }
                else if (result == 0)
                {
                    Response.Redirect("frmLandDetails.aspx?intApplicationId=" + ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString().Trim());
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                }

                else
                {

                    lblmsg.Text = "<font color='green'>Failed..!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                }
                }
                else
                {
                     txtdirectTransgender.Text = "";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }

            else
            {

                int result = 0;

                errormsg = CheckEmp();
                if (errormsg.Trim().TrimStart() == "")
                {

                    result = Gen.insertEnterprenuerdata("0", Session["Applid"].ToString(), txtindustrialName.Text, txtPromotor.Text, txtSoromoter.Text, ddlstate.SelectedValue,
                        ddldistrict.SelectedValue, ddlMandal.SelectedValue, ddlvillage.SelectedValue, txtstreetName.Text, txtDoorNo.Text, txtPincode.Text,
                        txtmobileNo.Text, txtEmail.Text, ddlType.SelectedValue,
                        txttelephone.Text, ddlproposal.SelectedValue, ddlCaste.SelectedValue, txtDirectmale.Text, txtdirectfemale.Text, txtIndirectMale.Text,
                        txtindirectFemale.Text, ddlcategory.SelectedValue, txtregNo.Text, txtRegDate.Text, ddlfactoryType.SelectedValue.ToString(),
                        Session["uid"].ToString(), txtlandValue.Text, txtPlant.Text, txtbuilding.Text, txttotal.Text, txtUIDnumber.Text, txtDistrict.Text,
                        txtMandal.Text, txtVillage.Text, ddlDifferentlyabled.SelectedValue.ToString(), ddlWomenEnterprenuer.SelectedValue.ToString(),
                        ddlMinority.SelectedValue.ToString(), txtAltmobileno.Text.Trim(),
                        txtdirectTransgender.Text, TXTINDIRECTTRANSGENDER.Text);
                    if (result != 0)
                {
                    //ResetFormControl(this);


                    Response.Redirect("frmLandDetails.aspx?intApplicationId=" + result.ToString());
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;



                }

                else if (result == 0)
                {

                    Response.Redirect("frmLandDetails.aspx?intApplicationId=" + hdfpencode.Value.ToString());
                }

                else
                {

                    lblmsg.Text = "<font color='green'>Failed..!</font>";
                    //  this.Clear();
                    success.Visible = false;
                    Failure.Visible = true;
                }
                }
                else
                {
                     txtdirectTransgender.Text = "";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
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

            ds = Gen.GetEnterPreneurdata(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim() != "")
                {
                    ddlcategory.SelectedValue = ddlcategory.Items.FindByValue(ds.Tables[0].Rows[0]["intCategoryofReg"].ToString()).Value;
                    //ddlcategory.Enabled = false;
                }


                txtUIDnumber.Text = ds.Tables[0].Rows[0]["CGGUid"].ToString();
                //       txtindustrialName.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                txtPromotor.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();

                txtSoromoter.Text = ds.Tables[0].Rows[0]["SoWo"].ToString();

                getstates();



                //ddlstate.SelectedValue = ds.Tables[0].Rows[0]["intStateid"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["intStateid"].ToString().Trim() != "")
                {


                    ddlstate.SelectedValue = ddlstate.Items.FindByValue(ds.Tables[0].Rows[0]["intStateid"].ToString().Trim()).Value;
                }

                if (ddlstate.SelectedValue.ToString() != "--Select--")
                {
                    // getdistricts();
                    //getdistricts();
                    if (ddlstate.SelectedValue.ToString() == "31")
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
                            ddldistrict.SelectedValue = ddldistrict.Items.FindByValue(ds.Tables[0].Rows[0]["intDistrictid"].ToString().Trim()).Value;
                        }
                        getMandals();
                        if (ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim() != "")
                        {
                            ddlMandal.SelectedValue = ddlMandal.Items.FindByValue(ds.Tables[0].Rows[0]["intMandalid"].ToString().Trim()).Value;
                        }
                        getVillages();
                        if (ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim() != "")
                        {
                            ddlvillage.SelectedValue = ddlvillage.Items.FindByValue(ds.Tables[0].Rows[0]["intVillageid"].ToString().Trim()).Value;
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
                    ddldistrict.Items.Clear();
                    ddldistrict.Items.Insert(0, "--Select--");


                }


                txtDistrict.Text = ds.Tables[0].Rows[0]["DistrictName"].ToString();
                txtMandal.Text = ds.Tables[0].Rows[0]["Mandalname"].ToString();
                txtVillage.Text = ds.Tables[0].Rows[0]["VillageName"].ToString();



                txtstreetName.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();

                txtDoorNo.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();

                txtPincode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();

                txtmobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                txtAltmobileno.Text = ds.Tables[0].Rows[0]["AlternarteMobileNo"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                //if (ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim() != "")
                //{
                //    ddlType.SelectedValue = ddlType.Items.FindByValue(ds.Tables[0].Rows[0]["intTypeofOrganization"].ToString().Trim()).Value;
                //}
                txttelephone.Text = ds.Tables[0].Rows[0]["TelephoneNumber"].ToString();
                //if (ds.Tables[0].Rows[0]["ProposalFor"].ToString().Trim() != "")
                //{
                //    ddlproposal.SelectedValue = ddlproposal.Items.FindByValue(ds.Tables[0].Rows[0]["ProposalFor"].ToString().Trim()).Value;
                //}

                if (ds.Tables[0].Rows[0]["Caste"].ToString().Trim() != "")
                {
                    ddlCaste.SelectedValue = ddlCaste.Items.FindByValue(ds.Tables[0].Rows[0]["Caste"].ToString().Trim()).Value;
                }

                txtDirectmale.Text = ds.Tables[0].Rows[0]["DirectMale"].ToString();

                txtdirectfemale.Text = ds.Tables[0].Rows[0]["DirectFemale"].ToString();
                txtdirectTransgender.Text = ds.Tables[0].Rows[0]["TRANS_DIRECT"].ToString();

                txtIndirectMale.Text = ds.Tables[0].Rows[0]["InDirectMale"].ToString();
                txtindirectFemale.Text = ds.Tables[0].Rows[0]["InDirectFemale"].ToString();
                TXTINDIRECTTRANSGENDER.Text = ds.Tables[0].Rows[0]["TRANS_INDIRECT"].ToString();

                //  ddlCaste.SelectedValue = ddlCaste.Items.FindByValue(ds.Tables[0].Rows[0]["Caste"].ToString().Trim()).Value;


                //if (ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim() != "")
                //{
                //    ddlcategory.SelectedValue = ddlcategory.Items.FindByValue(ds.Tables[0].Rows[0]["intCategoryofReg"].ToString().Trim()).Value;
                //}
                txtregNo.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();

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



                //txtlandValue.Text = ds.Tables[0].Rows[0]["land_value"].ToString();
                //txtbuilding.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                //txtPlant.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();
                //txttotal.Text = ds.Tables[0].Rows[0]["Total_value"].ToString();
                hdfFlagID1.Value = ds.Tables[0].Rows[0]["intQuessionaireid"].ToString();

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFEEnterpid"].ToString();

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
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmEntrepreneurDetails.aspx");
        clear();
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

    public void CalculatationEnterprisePrjCost()
    {
        //if (ddlSector_Ent.SelectedIndex != 0)
        //{
        if (txtlandValue.Text.Trim() == "")
        {
            txtlandValue.Text = "0";
        }

        if (txtbuilding.Text.Trim() == "")
        {
            txtbuilding.Text = "0";
        }

        if (txtPlant.Text.Trim() == "")
        {
            txtPlant.Text = "0";
        }
        txttotal.Text = Convert.ToString((Convert.ToDecimal(txtlandValue.Text) + Convert.ToDecimal(txtbuilding.Text) + Convert.ToDecimal(txtPlant.Text)));
        lblmsg.Text = "";
        //}
        //else
        //{
        //    TxtTot_PrjCost.Text = "0";
        //    lblmsg.Text = "Please Select Sector of Enterprise";
        //}
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
    protected void txtcontact9_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (ddlstate.SelectedValue.ToString() != "--Select--")
        {
            // getdistricts();

            if (ddlstate.SelectedValue.ToString() == "31")
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
            ddldistrict.Items.Clear();
            ddldistrict.Items.Insert(0, "--Select--");


        }

    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue.ToString() != "--Select--")
        {
            getMandals();
        }
        else
        {

        }
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlMandal.SelectedValue.ToString() != "--Select--")
        {
            getVillages();

        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, "--Select--");

        }
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

    }
    protected void txtlandValue_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtbuilding_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtPlant_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtregNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtdirectfemale_TextChanged(object sender, EventArgs e)
    {
        if (txtdirectfemale.Text == "" || txtdirectfemale.Text == null)
        {
            female = 0;

        }
        else
        {
            female = Convert.ToInt32(txtdirectfemale.Text);
        }
        if (female > Convert.ToInt32(lbltotalEmployment.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered Female Employment count should not exceed the total employment count.')", true);
            txtdirectfemale.Text = "";
        }
    }
    protected void txtDirectmale_TextChanged(object sender, EventArgs e)
    {
        if (txtDirectmale.Text == "" || txtDirectmale.Text == null)
        {
            male = 0;

        }
        else
        {
            male = Convert.ToInt32(txtDirectmale.Text);
        }
        if (male > Convert.ToInt32(lbltotalEmployment.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered Male Employment count should not exceed the total employment count.')", true);
            txtDirectmale.Text = "";
        }
    }
    public string CheckEmp()
    {

        string ErrorMsg = "";
        int totalEmployment = int.Parse(lbltotalEmployment.Text);

        // TryParse to safely convert values
        int input1 = int.TryParse(txtDirectmale.Text, out input1) ? input1 : 0;
        int input2 = int.TryParse(txtdirectfemale.Text, out input2) ? input2 : 0;
        int input3 = int.TryParse(txtdirectTransgender.Text, out input3) ? input3 : 0;
        int total = input1 + input2 + input3;
        // Check each individual input does not exceed total employment
        if (input1 > totalEmployment || input2 > totalEmployment || input3 > totalEmployment)
        {
            //string script = "alert('Each input must be less than or equal to Total Employment (" + totalEmployment + ").');";
            //ClientScript.RegisterStartupScript(this.GetType(), "alertLimitPerBox", script, true);
            ErrorMsg = "Entered male,female and transgender employment must be less than or equal to Total Employment";
        }



        else if (total > totalEmployment || total < totalEmployment)
        {
            //string script = "alert('Total of all inputs exceeds Total Employment (" + totalEmployment + ").');";
            //ClientScript.RegisterStartupScript(this.GetType(), "alertTotalExceeded", script, true);
            ErrorMsg = "Total of male,female and transgender should be equal to total employment count";
        }
        else
        {
            ErrorMsg = "";
        }
        return ErrorMsg;

    }
    protected void txtdirectTransgender_TextChanged(object sender, EventArgs e)
    {
        if (txtdirectTransgender.Text == "" || txtdirectTransgender.Text == null)
        {
            transgender = 0;

        }
        else
        {
            transgender = Convert.ToInt32(txtdirectTransgender.Text);
        }
        if (transgender > Convert.ToInt32(lbltotalEmployment.Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Entered Transgender Employment count should not exceed the total employment count.')", true);
            txtdirectTransgender.Text = "";
        }

    }

}
