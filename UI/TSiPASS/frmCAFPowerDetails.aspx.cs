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
    public DataSet GDs { get; set; }
    CEIGCFOService.ApplicationServiceImplService ceigtest = new CEIGCFOService.ApplicationServiceImplService();
    //CEIGCFOService.ApplicationServiceImplService ceigtest = new CEIGCFOService.ApplicationServiceImplService();
    #region comment
    //DataTable dtMyTable = new DataTable();
    //DataTable dtMyTableI;
    //DataTable dtMyTableH;
    //DataTable dtMyTableG;
    //DataTable dtMyTableF;
    //DataTable dtMyTableE;
    //DataTable dtMyTableC;
    //DataTable dtMyTableB;
    //DataTable dtMyTableA;

    //
    #endregion

    DataSet dsMyPower = new DataSet();
    DataTable dtMyPower;
    List<LoadParticulars> lstLoadParticulars = new List<LoadParticulars>();
    List<CircuitBreakerLoad> lstCircuitBreakerLoad = new List<CircuitBreakerLoad>();
    List<TransformerTest> lstTransformerTest = new List<TransformerTest>();
    List<ABSwitchIsolator> lstABSwitchIsolator = new List<ABSwitchIsolator>();
    List<LightningArrestor> lstLightningArrestor = new List<LightningArrestor>();
    List<GeneratorsTestFuel> lstGeneratorsTestFuel = new List<GeneratorsTestFuel>();
    List<PreCommissioning> lstPreCommissioning = new List<PreCommissioning>();
    List<Transmissionlines> lstTransmissionlines = new List<Transmissionlines>();

    private void getsection()
    {
        ViewState["Power_I"] = "0";
        ViewState["Power_IS"] = "";
        ViewState["Power_G"] = "0";
        ViewState["Power_GS"] = "";
        ViewState["Power_H"] = "0";
        ViewState["Power_HS"] = "";
        ViewState["Power_F"] = "0";
        ViewState["Power_FS"] = "";
        ViewState["Power_E"] = "0";
        ViewState["Power_ES"] = "";
        ViewState["Power_C"] = "0";
        ViewState["Power_CS"] = "";
        ViewState["Power_B"] = "0";
        ViewState["Power_BS"] = "";
        ViewState["Power_A"] = "0";
        ViewState["Power_AS"] = "";
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            txtcapinkv.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtcaphp.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtcircuitcapacity.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtTransformercapacity.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtVoltage.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtswitchVoltage.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtswitchcapacity.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtlightvoltage.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtlightcapacity.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            txtgenercapacity.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
            txtheatrate.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            getsection();
            BindRegulations(ddlregulation);
            BindPlant(ddlplant);
            BindVoltage(ddlvoltage);
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                if (dscheck.Tables[0].Rows[0]["HTNO"].ToString().Trim() != "" && dscheck.Tables[0].Rows[0]["HTNO"].ToString().Trim() != null)
                {
                    txtdrawingno.Text = dscheck.Tables[0].Rows[0]["HTNO"].ToString().Trim();
                   // txtdrawingno_TextChanged(sender, e);
                }
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
            }
            else
            {
                Session["ApplidA"] = "0";
            }



        }

        if (!IsPostBack)
        {

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofquepower9CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    //ResetFormControl(this);
                }

            }

        }

        if (!IsPostBack)
        {
            //string res = Gen.RetriveStatusHTCFO(Session["ApplidA"].ToString());

            //if (res == "Y")
            //{

            //}

            DataSet dsnew = new DataSet();
            dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "6");
            if (dsnew.Tables[0].Rows.Count > 0)
            {

            }
            else
            {
                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");

                }
                else
                {
                    Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

                }

            }



        }



        if (!IsPostBack)
        {


            getdistricts();

            DataSet ds = new DataSet();
            ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

            getcommondetails(Convert.ToInt32(Session["uid"]));

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
        }


        //DataSet ds = new DataSet();
        //ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    if (!IsPostBack)
        //    {
        //        FillDetails();
        //    }

        //}


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
        if (ddlregulation.Text.Trim() == "--Select--")
        {
            ddlregulation.Enabled = true;
        }

        if (txtaggregatecapacity.Text.Trim() == "")
        {
            txtaggregatecapacity.ReadOnly = false;
        }

        if (ddlregulation.SelectedItem.Text.Trim() == "43(3)" || ddlregulation.SelectedItem.Text.Trim() == "43(4)" || ddlregulation.SelectedItem.Text.Trim() == "36")
        {
            trvoltage.Visible = true;
            trPlant.Visible = false;
            if (ddlvoltage.Text.Trim() == "--Select--")
            {
                ddlvoltage.Enabled = true;
            }
        }
        else if (ddlregulation.SelectedItem.Text.Trim() == "32" || ddlregulation.SelectedItem.Text.Trim() == "43(4) & 32")
        {
            trvoltage.Visible = false;
            trPlant.Visible = true;
            if (ddlplant.Text.Trim() == "--Select--")
            {
                ddlplant.Enabled = true;
            }
        }
        if (LabelAgreement.Text == "")
        {
            FileAgreement.Enabled = true;
        }
        if (lblLicense.Text == "")
        {
            FileUploadLicense.Enabled = true;
        }
        if (lblpermitr.Text == "")
        {
            FileUploadpermit.Enabled = true;
        }
        if (lblFeasibility.Text == "")
        {
            FileUploadFeasibility.Enabled = true;
        }
        if (lblElectricalDiagram.Text == "")
        {
            FileUploadElectricalDiagram.Enabled = true;
        }
        if (lbllayout.Text == "")
        {
            FileUploadlayout.Enabled = true;
        }
        if (lblequipmentdrawing.Text == "")
        {
            FileUploadequipmentdrawing.Enabled = true;
        }
        if (lblearthinglayout.Text == "")
        {
            FileUploadearthinglayout.Enabled = true;
        }
    }

    #region states, district, mandals

    //protected void getstates()
    //{
    //    DataSet ds = new DataSet();
    //    ds = Gen.getStates();

    //    ddlstatus21.DataSource = ds.Tables[0];
    //    ddlstatus21.DataTextField = "State_Name";
    //    ddlstatus21.DataValueField = "State_id";
    //    ddlstatus21.DataBind();
    //    ddlstatus21.Items.Insert(0, "--Select--");

    //}

    protected void getdistricts()
    {
        DataSet ds = new DataSet();
        ds = Gen.GetDistricts();
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
    #endregion

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

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (txtdrawingno.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Enter Drawing Approval Number..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (LabelAgreement.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Completion Report from Supplier..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblLicense.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Commencement Report (WR-I)..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblpermitr.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Completion Report (WR-II)..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (gvLoad.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Load Particulars Document..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        lstLoadParticulars.Clear();
        //dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
        //dsMyPower.Tables[0].TableName = "Power_A";

        DataSet Ds1 = new DataSet();
        Ds1.Tables.Add((DataTable)ViewState["Power_AS"]);
        Ds1.Tables[0].TableName = "Power_A";
        foreach (GridViewRow gvrow in gvLoad.Rows)
        {
            LoadParticulars LoadParticularsvo = new LoadParticulars();
            int rowIndex = gvrow.RowIndex;

            LoadParticularsvo.EquipmentName = Ds1.Tables["Power_A"].Rows[rowIndex][0].ToString();
            LoadParticularsvo.Make = Ds1.Tables["Power_A"].Rows[rowIndex][1].ToString();
            LoadParticularsvo.SerialNo = Ds1.Tables["Power_A"].Rows[rowIndex][2].ToString();
            LoadParticularsvo.CapacityinKV = Ds1.Tables["Power_A"].Rows[rowIndex][3].ToString();
            LoadParticularsvo.CapacityinHP = Ds1.Tables["Power_A"].Rows[rowIndex][4].ToString();
            LoadParticularsvo.LoadUpload = Ds1.Tables["Power_A"].Rows[rowIndex][5].ToString();
            LoadParticularsvo.capacityloadpath = Ds1.Tables["Power_A"].Rows[rowIndex][6].ToString();
            //LoadParticularsvo.LoadUpload = gvLoad.Rows[rowIndex].Cells[3].Text;
            //LoadParticularsvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
            LoadParticularsvo.Created_By = Session["uid"].ToString();
            lstLoadParticulars.Add(LoadParticularsvo);
        }

        lstCircuitBreakerLoad.Clear();
        //dsMyPower.Tables.Add((DataTable)ViewState["Power_BS"]);
        //dsMyPower.Tables[1].TableName = "Power_B";

        Ds1.Tables.Clear();
        if (ViewState["Power_BS"] != null && ViewState["Power_BS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_BS"]);
            Ds1.Tables[0].TableName = "Power_B";

            foreach (GridViewRow gvrow in gvcircuit.Rows)
            {
                CircuitBreakerLoad CircuitBreakerLoadvo = new CircuitBreakerLoad();
                int rowIndex = gvrow.RowIndex;
                CircuitBreakerLoadvo.Location = Ds1.Tables["Power_B"].Rows[rowIndex][0].ToString();
                CircuitBreakerLoadvo.CapacityA = Ds1.Tables["Power_B"].Rows[rowIndex][1].ToString();
                CircuitBreakerLoadvo.Make = Ds1.Tables["Power_B"].Rows[rowIndex][2].ToString();
                CircuitBreakerLoadvo.CBSerialNo = Ds1.Tables["Power_B"].Rows[rowIndex][3].ToString();
                CircuitBreakerLoadvo.ISCKA = Ds1.Tables["Power_B"].Rows[rowIndex][4].ToString();
                CircuitBreakerLoadvo.TestCertificateUpload = Ds1.Tables["Power_B"].Rows[rowIndex][5].ToString();
                CircuitBreakerLoadvo.testcertificatefilepath = Ds1.Tables["Power_B"].Rows[rowIndex][6].ToString();

                #region comment


                //CircuitBreakerLoadvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //CircuitBreakerLoadvo.CBSerialNo = gvcircuit.Rows[rowIndex].Cells[1].Text;
                //CircuitBreakerLoadvo.ISCKA = gvcircuit.Rows[rowIndex].Cells[2].Text;
                //CircuitBreakerLoadvo.Location = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.Make = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.TestCertificateUpload = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion


                CircuitBreakerLoadvo.Created_By = Session["uid"].ToString();
                lstCircuitBreakerLoad.Add(CircuitBreakerLoadvo);
            }
        }
        lstTransformerTest.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_CS"]);
        //dsMyPower.Tables[2].TableName = "Power_C";

        Ds1.Tables.Clear();
        if (ViewState["Power_CS"] != null && ViewState["Power_CS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_CS"]);
            Ds1.Tables[0].TableName = "Power_C";

            foreach (GridViewRow gvrow in gvTransformer.Rows)
            {
                TransformerTest TransformerTestvo = new TransformerTest();
                int rowIndex = gvrow.RowIndex;
                // ******** there is missing in the field of Equipment Name in the list please be add *************
                TransformerTestvo.Transformer = Ds1.Tables["Power_C"].Rows[rowIndex][0].ToString();
                TransformerTestvo.EquipmentName = Ds1.Tables["Power_C"].Rows[rowIndex][1].ToString();
                TransformerTestvo.TypeofTransformer = Ds1.Tables["Power_C"].Rows[rowIndex][2].ToString();
                TransformerTestvo.Capacity = Ds1.Tables["Power_C"].Rows[rowIndex][3].ToString();
                TransformerTestvo.Make = Ds1.Tables["Power_C"].Rows[rowIndex][4].ToString();
                TransformerTestvo.SerialNo = Ds1.Tables["Power_C"].Rows[rowIndex][5].ToString();
                TransformerTestvo.VoltageHVLV = Ds1.Tables["Power_C"].Rows[rowIndex][6].ToString();
                TransformerTestvo.TransformerTestUpload = Ds1.Tables["Power_C"].Rows[rowIndex][7].ToString();
                TransformerTestvo.transformeruploadfilepath = Ds1.Tables["Power_C"].Rows[rowIndex][8].ToString();

                #region comment


                //TransformerTestvo.Capacity = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //TransformerTestvo.Make = gvtran.Rows[rowIndex].Cells[1].Text;
                //TransformerTestvo.OilTestUpload = gvtran.Rows[rowIndex].Cells[2].Text;
                //TransformerTestvo.SerialNo = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.Transformer = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.TransformerTestUpload = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.TypeofTransformer = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.VoltageHVLV = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                TransformerTestvo.Created_By = Session["uid"].ToString();
                lstTransformerTest.Add(TransformerTestvo);
            }
        }
        lstABSwitchIsolator.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_ES"]);
        //dsMyPower.Tables[3].TableName = "Power_E";

        Ds1.Tables.Clear();
        if (ViewState["Power_ES"] != null && ViewState["Power_ES"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_ES"]);
            Ds1.Tables[0].TableName = "Power_E";

            foreach (GridViewRow gvrow in gvswitch.Rows)
            {
                ABSwitchIsolator ABSwitchIsolatorvo = new ABSwitchIsolator();
                int rowIndex = gvrow.RowIndex;

                ABSwitchIsolatorvo.Location = Ds1.Tables["Power_E"].Rows[rowIndex][0].ToString();
                ABSwitchIsolatorvo.WithorWithoutEarthSwitch = Ds1.Tables["Power_E"].Rows[rowIndex][1].ToString();
                ABSwitchIsolatorvo.VoltageV = Ds1.Tables["Power_E"].Rows[rowIndex][2].ToString();
                ABSwitchIsolatorvo.CapacityA = Ds1.Tables["Power_E"].Rows[rowIndex][3].ToString();
                ABSwitchIsolatorvo.Make = Ds1.Tables["Power_E"].Rows[rowIndex][4].ToString();
                ABSwitchIsolatorvo.SerialNo = Ds1.Tables["Power_E"].Rows[rowIndex][5].ToString();
                ABSwitchIsolatorvo.TestUpload = Ds1.Tables["Power_E"].Rows[rowIndex][6].ToString();
                ABSwitchIsolatorvo.testuploadpath = Ds1.Tables["Power_E"].Rows[rowIndex][7].ToString();


                #region comment


                //ABSwitchIsolatorvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //ABSwitchIsolatorvo.Location = gvswitch.Rows[rowIndex].Cells[1].Text;
                //ABSwitchIsolatorvo.Make = gvswitch.Rows[rowIndex].Cells[2].Text;
                //ABSwitchIsolatorvo.SerialNo = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.TestUpload = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.VoltageHVLV = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.VoltageV = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.WithorWithoutEarthSwitch = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                ABSwitchIsolatorvo.Created_By = Session["uid"].ToString();
                lstABSwitchIsolator.Add(ABSwitchIsolatorvo);
            }
        }
        lstLightningArrestor.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_FS"]);
        //dsMyPower.Tables[4].TableName = "Power_F";

        Ds1.Tables.Clear();
        if (ViewState["Power_FS"] != null && ViewState["Power_FS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_FS"]);
            Ds1.Tables[0].TableName = "Power_F";

            foreach (GridViewRow gvrow in gvlight.Rows)
            {
                LightningArrestor LightningArrestorsvo = new LightningArrestor();
                int rowIndex = gvrow.RowIndex;

                LightningArrestorsvo.Location = Ds1.Tables["Power_F"].Rows[rowIndex][0].ToString();
                LightningArrestorsvo.VoltageV = Ds1.Tables["Power_F"].Rows[rowIndex][1].ToString();
                LightningArrestorsvo.CapacityA = Ds1.Tables["Power_F"].Rows[rowIndex][2].ToString();
                LightningArrestorsvo.Make = Ds1.Tables["Power_F"].Rows[rowIndex][3].ToString();
                LightningArrestorsvo.SerialNo = Ds1.Tables["Power_F"].Rows[rowIndex][4].ToString();
                LightningArrestorsvo.TestUpload = Ds1.Tables["Power_F"].Rows[rowIndex][5].ToString();
                LightningArrestorsvo.Testuploadfilepath = Ds1.Tables["Power_F"].Rows[rowIndex][6].ToString();

                #region comment


                //LightningArrestorsvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //LightningArrestorsvo.Location = gvlight.Rows[rowIndex].Cells[1].Text;
                //LightningArrestorsvo.Make = gvlight.Rows[rowIndex].Cells[2].Text;
                //LightningArrestorsvo.SerialNo = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.TestUpload = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.VoltageHVLV = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.VoltageV = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                LightningArrestorsvo.Created_By = Session["uid"].ToString();
                lstLightningArrestor.Add(LightningArrestorsvo);
            }
        }
        lstGeneratorsTestFuel.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_GS"]);
        //dsMyPower.Tables[5].TableName = "Power_G";

        Ds1.Tables.Clear();
        if (ViewState["Power_GS"] != null && ViewState["Power_GS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_GS"]);
            Ds1.Tables[0].TableName = "Power_G";

            foreach (GridViewRow gvrow in gvgene.Rows)
            {
                GeneratorsTestFuel GeneratorsTestFuelvo = new GeneratorsTestFuel();
                int rowIndex = gvrow.RowIndex;

                GeneratorsTestFuelvo.Location = Ds1.Tables["Power_G"].Rows[rowIndex][0].ToString();
                GeneratorsTestFuelvo.CapacityA = Ds1.Tables["Power_G"].Rows[rowIndex][1].ToString();
                GeneratorsTestFuelvo.Make = Ds1.Tables["Power_G"].Rows[rowIndex][2].ToString();
                GeneratorsTestFuelvo.SerialNo = Ds1.Tables["Power_G"].Rows[rowIndex][3].ToString();
                GeneratorsTestFuelvo.FuelType = Ds1.Tables["Power_G"].Rows[rowIndex][4].ToString();
                GeneratorsTestFuelvo.FuelSource = Ds1.Tables["Power_G"].Rows[rowIndex][5].ToString();
                GeneratorsTestFuelvo.SoxNoxEmission = Ds1.Tables["Power_G"].Rows[rowIndex][6].ToString();
                GeneratorsTestFuelvo.Mercury = Ds1.Tables["Power_G"].Rows[rowIndex][7].ToString();
                GeneratorsTestFuelvo.HeatRateDetails = Ds1.Tables["Power_G"].Rows[rowIndex][8].ToString();
                GeneratorsTestFuelvo.FuelTestUpload = Ds1.Tables["Power_G"].Rows[rowIndex][9].ToString();
                GeneratorsTestFuelvo.FuelTestUploadfilepath = Ds1.Tables["Power_G"].Rows[rowIndex][10].ToString();

                #region comment


                //GeneratorsTestFuelvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //GeneratorsTestFuelvo.FuelSource = gvgene.Rows[rowIndex].Cells[1].Text;
                //GeneratorsTestFuelvo.FuelTestUpload = gvgene.Rows[rowIndex].Cells[2].Text;
                //GeneratorsTestFuelvo.FuelType = gvgene.Rows[rowIndex].Cells[2].Text;
                //GeneratorsTestFuelvo.HeatRateDetails = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Location = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Make = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Mercury = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.SerialNo = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.SoxNoxEmission = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                GeneratorsTestFuelvo.Created_By = Session["uid"].ToString();
                lstGeneratorsTestFuel.Add(GeneratorsTestFuelvo);
            }
        }
        lstPreCommissioning.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_HS"]);
        //dsMyPower.Tables[6].TableName = "Power_H";

        Ds1.Tables.Clear();
        if (ViewState["Power_HS"] != null && ViewState["Power_HS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_HS"]);
            Ds1.Tables[0].TableName = "Power_H";

            foreach (GridViewRow gvrow in gvcomm.Rows)
            {
                PreCommissioning PreCommissioningvo = new PreCommissioning();
                int rowIndex = gvrow.RowIndex;

                PreCommissioningvo.Description = Ds1.Tables["Power_H"].Rows[rowIndex][1].ToString();
                PreCommissioningvo.Equipment = Ds1.Tables["Power_H"].Rows[rowIndex][0].ToString();
                PreCommissioningvo.CommissioningUpload = Ds1.Tables["Power_H"].Rows[rowIndex][2].ToString();
                PreCommissioningvo.CommissioningUploadfilepath = Ds1.Tables["Power_H"].Rows[rowIndex][3].ToString();
                #region comment


                //PreCommissioningvo.CommissioningUpload = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //PreCommissioningvo.Description = gvcomm.Rows[rowIndex].Cells[1].Text;
                //PreCommissioningvo.Equipment = gvcomm.Rows[rowIndex].Cells[2].Text;
                //PreCommissioningvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                PreCommissioningvo.Created_By = Session["uid"].ToString();
                lstPreCommissioning.Add(PreCommissioningvo);
            }
        }


        //dsMyPower.Tables.Add((DataTable)ViewState["Power_IS"]);
        //dsMyPower.Tables[7].TableName = "Power_I";

        lstTransmissionlines.Clear();
        Ds1.Tables.Clear();
        if (ViewState["Power_IS"] != null && ViewState["Power_IS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_IS"]);
            Ds1.Tables[0].TableName = "Power_I";

            foreach (GridViewRow gvrow in gvtran.Rows)
            {
                // ******** there is missing in the field of serial no in the list please be add *************
                Transmissionlines Transmissionlinesvo = new Transmissionlines();
                int rowIndex = gvrow.RowIndex;


                Transmissionlinesvo.Description = Ds1.Tables["Power_I"].Rows[rowIndex][0].ToString();
                Transmissionlinesvo.TransmissionUpload = Ds1.Tables["Power_I"].Rows[rowIndex][1].ToString();
                Transmissionlinesvo.TransmissionUploadfilepath = Ds1.Tables["Power_I"].Rows[rowIndex][2].ToString();
                #region comment


                //Transmissionlinesvo.Description = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //Transmissionlinesvo.TransmissionUpload = gvtran.Rows[rowIndex].Cells[1].Text;
                //Transmissionlinesvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                Transmissionlinesvo.Created_By = Session["uid"].ToString();
                lstTransmissionlines.Add(Transmissionlinesvo);
            }
        }
        if (BtnSave1.Text == "Save")
        {

            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insetCFOPowerDet(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim(), lstLoadParticulars, lstCircuitBreakerLoad,
                    lstTransformerTest, lstABSwitchIsolator, lstLightningArrestor, lstGeneratorsTestFuel, lstPreCommissioning, lstTransmissionlines, txtdrawingno.Text.Trim());
                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Power Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insetCFOPowerDet(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim(), lstLoadParticulars, lstCircuitBreakerLoad,
                    lstTransformerTest, lstABSwitchIsolator, lstLightningArrestor, lstGeneratorsTestFuel, lstPreCommissioning, lstTransmissionlines, txtdrawingno.Text.Trim());

                if (result > 0)
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Submission Failed..!</font>";
                }
            }
        }


    }
    void clear()
    {

        txtKVAAlreadyInstalled.Text = ""; txtKVAProposed.Text = ""; txtKVATotal.Text = ""; txtConnectedAlreadyInstalled.Text = ""; txtConnectProposed.Text = ""; txtConnectTotal.Text = "";
        ddlProject.SelectedIndex = 0; ddlDistrict.SelectedIndex = 0; ddlMandal.SelectedIndex = 0; ddlVillage.SelectedValue = ""; txtStreet.Text = ""; txtPinCode.Text = "";
        txtTelephone.Text = ""; txtNearTelephone.Text = ""; txtDateofCommencement.Text = ""; txtExtent.Text = ""; ddlConnectLoad.SelectedIndex = 0;


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmCAFFactoryDetails.aspx");

        if (txtdrawingno.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Enter Drawing Approval Number..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (LabelAgreement.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Completion Report from Supplier..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblLicense.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Commencement Report (WR-I)..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }
        if (lblpermitr.Text == "")
        {
            lblmsg0.Text = "<font color='red'>Please Upload Work Completion Report (WR-II)..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        if (gvLoad.Rows.Count < 1)
        {
            lblmsg0.Text = "<font color='red'>Please Upload Load Particulars Document..!</font>";
            success.Visible = false;
            Failure.Visible = true;
            return;
        }

        lstLoadParticulars.Clear();
        //dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
        //dsMyPower.Tables[0].TableName = "Power_A";

        DataSet Ds1 = new DataSet();
        Ds1.Tables.Add((DataTable)ViewState["Power_AS"]);
        Ds1.Tables[0].TableName = "Power_A";
        foreach (GridViewRow gvrow in gvLoad.Rows)
        {
            LoadParticulars LoadParticularsvo = new LoadParticulars();
            int rowIndex = gvrow.RowIndex;

            LoadParticularsvo.EquipmentName = Ds1.Tables["Power_A"].Rows[rowIndex][0].ToString();
            LoadParticularsvo.Make = Ds1.Tables["Power_A"].Rows[rowIndex][1].ToString();
            LoadParticularsvo.SerialNo = Ds1.Tables["Power_A"].Rows[rowIndex][2].ToString();
            LoadParticularsvo.CapacityinKV = Ds1.Tables["Power_A"].Rows[rowIndex][3].ToString();
            LoadParticularsvo.CapacityinHP = Ds1.Tables["Power_A"].Rows[rowIndex][4].ToString();
            LoadParticularsvo.LoadUpload = Ds1.Tables["Power_A"].Rows[rowIndex][5].ToString();
            LoadParticularsvo.capacityloadpath = Ds1.Tables["Power_A"].Rows[rowIndex][6].ToString();
            //LoadParticularsvo.LoadUpload = gvLoad.Rows[rowIndex].Cells[3].Text;
            //LoadParticularsvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
            LoadParticularsvo.Created_By = Session["uid"].ToString();
            lstLoadParticulars.Add(LoadParticularsvo);
        }

        lstCircuitBreakerLoad.Clear();
        //dsMyPower.Tables.Add((DataTable)ViewState["Power_BS"]);
        //dsMyPower.Tables[1].TableName = "Power_B";

        Ds1.Tables.Clear();
        if (ViewState["Power_BS"] != null && ViewState["Power_BS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_BS"]);
            Ds1.Tables[0].TableName = "Power_B";

            foreach (GridViewRow gvrow in gvcircuit.Rows)
            {
                CircuitBreakerLoad CircuitBreakerLoadvo = new CircuitBreakerLoad();
                int rowIndex = gvrow.RowIndex;
                CircuitBreakerLoadvo.Location = Ds1.Tables["Power_B"].Rows[rowIndex][0].ToString();
                CircuitBreakerLoadvo.CapacityA = Ds1.Tables["Power_B"].Rows[rowIndex][1].ToString();
                CircuitBreakerLoadvo.Make = Ds1.Tables["Power_B"].Rows[rowIndex][2].ToString();
                CircuitBreakerLoadvo.CBSerialNo = Ds1.Tables["Power_B"].Rows[rowIndex][3].ToString();
                CircuitBreakerLoadvo.ISCKA = Ds1.Tables["Power_B"].Rows[rowIndex][4].ToString();
                CircuitBreakerLoadvo.TestCertificateUpload = Ds1.Tables["Power_B"].Rows[rowIndex][5].ToString();
                CircuitBreakerLoadvo.testcertificatefilepath = Ds1.Tables["Power_B"].Rows[rowIndex][6].ToString();

                #region comment


                //CircuitBreakerLoadvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //CircuitBreakerLoadvo.CBSerialNo = gvcircuit.Rows[rowIndex].Cells[1].Text;
                //CircuitBreakerLoadvo.ISCKA = gvcircuit.Rows[rowIndex].Cells[2].Text;
                //CircuitBreakerLoadvo.Location = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.Make = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.TestCertificateUpload = gvcircuit.Rows[rowIndex].Cells[3].Text;
                //CircuitBreakerLoadvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion


                CircuitBreakerLoadvo.Created_By = Session["uid"].ToString();
                lstCircuitBreakerLoad.Add(CircuitBreakerLoadvo);
            }
        }
        lstTransformerTest.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_CS"]);
        //dsMyPower.Tables[2].TableName = "Power_C";

        Ds1.Tables.Clear();
        if (ViewState["Power_CS"] != null && ViewState["Power_CS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_CS"]);
            Ds1.Tables[0].TableName = "Power_C";

            foreach (GridViewRow gvrow in gvTransformer.Rows)
            {
                TransformerTest TransformerTestvo = new TransformerTest();
                int rowIndex = gvrow.RowIndex;
                // ******** there is missing in the field of Equipment Name in the list please be add *************
                TransformerTestvo.Transformer = Ds1.Tables["Power_C"].Rows[rowIndex][0].ToString();
                TransformerTestvo.EquipmentName = Ds1.Tables["Power_C"].Rows[rowIndex][1].ToString();
                TransformerTestvo.TypeofTransformer = Ds1.Tables["Power_C"].Rows[rowIndex][2].ToString();
                TransformerTestvo.Capacity = Ds1.Tables["Power_C"].Rows[rowIndex][3].ToString();
                TransformerTestvo.Make = Ds1.Tables["Power_C"].Rows[rowIndex][4].ToString();
                TransformerTestvo.SerialNo = Ds1.Tables["Power_C"].Rows[rowIndex][5].ToString();
                TransformerTestvo.VoltageHVLV = Ds1.Tables["Power_C"].Rows[rowIndex][6].ToString();
                TransformerTestvo.TransformerTestUpload = Ds1.Tables["Power_C"].Rows[rowIndex][7].ToString();
                TransformerTestvo.transformeruploadfilepath = Ds1.Tables["Power_C"].Rows[rowIndex][8].ToString();

                #region comment


                //TransformerTestvo.Capacity = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //TransformerTestvo.Make = gvtran.Rows[rowIndex].Cells[1].Text;
                //TransformerTestvo.OilTestUpload = gvtran.Rows[rowIndex].Cells[2].Text;
                //TransformerTestvo.SerialNo = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.Transformer = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.TransformerTestUpload = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.TypeofTransformer = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.VoltageHVLV = gvtran.Rows[rowIndex].Cells[3].Text;
                //TransformerTestvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                TransformerTestvo.Created_By = Session["uid"].ToString();
                lstTransformerTest.Add(TransformerTestvo);
            }
        }
        lstABSwitchIsolator.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_ES"]);
        //dsMyPower.Tables[3].TableName = "Power_E";

        Ds1.Tables.Clear();
        if (ViewState["Power_ES"] != null && ViewState["Power_ES"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_ES"]);
            Ds1.Tables[0].TableName = "Power_E";

            foreach (GridViewRow gvrow in gvswitch.Rows)
            {
                ABSwitchIsolator ABSwitchIsolatorvo = new ABSwitchIsolator();
                int rowIndex = gvrow.RowIndex;

                ABSwitchIsolatorvo.Location = Ds1.Tables["Power_E"].Rows[rowIndex][0].ToString();
                ABSwitchIsolatorvo.WithorWithoutEarthSwitch = Ds1.Tables["Power_E"].Rows[rowIndex][1].ToString();
                ABSwitchIsolatorvo.VoltageV = Ds1.Tables["Power_E"].Rows[rowIndex][2].ToString();
                ABSwitchIsolatorvo.CapacityA = Ds1.Tables["Power_E"].Rows[rowIndex][3].ToString();
                ABSwitchIsolatorvo.Make = Ds1.Tables["Power_E"].Rows[rowIndex][4].ToString();
                ABSwitchIsolatorvo.SerialNo = Ds1.Tables["Power_E"].Rows[rowIndex][5].ToString();
                ABSwitchIsolatorvo.TestUpload = Ds1.Tables["Power_E"].Rows[rowIndex][6].ToString();
                ABSwitchIsolatorvo.testuploadpath = Ds1.Tables["Power_E"].Rows[rowIndex][7].ToString();


                #region comment


                //ABSwitchIsolatorvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //ABSwitchIsolatorvo.Location = gvswitch.Rows[rowIndex].Cells[1].Text;
                //ABSwitchIsolatorvo.Make = gvswitch.Rows[rowIndex].Cells[2].Text;
                //ABSwitchIsolatorvo.SerialNo = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.TestUpload = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.VoltageHVLV = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.VoltageV = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.WithorWithoutEarthSwitch = gvswitch.Rows[rowIndex].Cells[3].Text;
                //ABSwitchIsolatorvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                ABSwitchIsolatorvo.Created_By = Session["uid"].ToString();
                lstABSwitchIsolator.Add(ABSwitchIsolatorvo);
            }
        }
        lstLightningArrestor.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_FS"]);
        //dsMyPower.Tables[4].TableName = "Power_F";

        Ds1.Tables.Clear();
        if (ViewState["Power_FS"] != null && ViewState["Power_FS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_FS"]);
            Ds1.Tables[0].TableName = "Power_F";

            foreach (GridViewRow gvrow in gvlight.Rows)
            {
                LightningArrestor LightningArrestorsvo = new LightningArrestor();
                int rowIndex = gvrow.RowIndex;

                LightningArrestorsvo.Location = Ds1.Tables["Power_F"].Rows[rowIndex][0].ToString();
                LightningArrestorsvo.VoltageV = Ds1.Tables["Power_F"].Rows[rowIndex][1].ToString();
                LightningArrestorsvo.CapacityA = Ds1.Tables["Power_F"].Rows[rowIndex][2].ToString();
                LightningArrestorsvo.Make = Ds1.Tables["Power_F"].Rows[rowIndex][3].ToString();
                LightningArrestorsvo.SerialNo = Ds1.Tables["Power_F"].Rows[rowIndex][4].ToString();
                LightningArrestorsvo.TestUpload = Ds1.Tables["Power_F"].Rows[rowIndex][5].ToString();
                LightningArrestorsvo.Testuploadfilepath = Ds1.Tables["Power_F"].Rows[rowIndex][6].ToString();

                #region comment


                //LightningArrestorsvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //LightningArrestorsvo.Location = gvlight.Rows[rowIndex].Cells[1].Text;
                //LightningArrestorsvo.Make = gvlight.Rows[rowIndex].Cells[2].Text;
                //LightningArrestorsvo.SerialNo = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.TestUpload = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.VoltageHVLV = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.VoltageV = gvlight.Rows[rowIndex].Cells[3].Text;
                //LightningArrestorsvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                LightningArrestorsvo.Created_By = Session["uid"].ToString();
                lstLightningArrestor.Add(LightningArrestorsvo);
            }
        }
        lstGeneratorsTestFuel.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_GS"]);
        //dsMyPower.Tables[5].TableName = "Power_G";

        Ds1.Tables.Clear();
        if (ViewState["Power_GS"] != null && ViewState["Power_GS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_GS"]);
            Ds1.Tables[0].TableName = "Power_G";

            foreach (GridViewRow gvrow in gvgene.Rows)
            {
                GeneratorsTestFuel GeneratorsTestFuelvo = new GeneratorsTestFuel();
                int rowIndex = gvrow.RowIndex;

                GeneratorsTestFuelvo.Location = Ds1.Tables["Power_G"].Rows[rowIndex][0].ToString();
                GeneratorsTestFuelvo.CapacityA = Ds1.Tables["Power_G"].Rows[rowIndex][1].ToString();
                GeneratorsTestFuelvo.Make = Ds1.Tables["Power_G"].Rows[rowIndex][2].ToString();
                GeneratorsTestFuelvo.SerialNo = Ds1.Tables["Power_G"].Rows[rowIndex][3].ToString();
                GeneratorsTestFuelvo.FuelType = Ds1.Tables["Power_G"].Rows[rowIndex][4].ToString();
                GeneratorsTestFuelvo.FuelSource = Ds1.Tables["Power_G"].Rows[rowIndex][5].ToString();
                GeneratorsTestFuelvo.SoxNoxEmission = Ds1.Tables["Power_G"].Rows[rowIndex][6].ToString();
                GeneratorsTestFuelvo.Mercury = Ds1.Tables["Power_G"].Rows[rowIndex][7].ToString();
                GeneratorsTestFuelvo.HeatRateDetails = Ds1.Tables["Power_G"].Rows[rowIndex][8].ToString();
                GeneratorsTestFuelvo.FuelTestUpload = Ds1.Tables["Power_G"].Rows[rowIndex][9].ToString();
                GeneratorsTestFuelvo.FuelTestUploadfilepath = Ds1.Tables["Power_G"].Rows[rowIndex][10].ToString();

                #region comment


                //GeneratorsTestFuelvo.CapacityA = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //GeneratorsTestFuelvo.FuelSource = gvgene.Rows[rowIndex].Cells[1].Text;
                //GeneratorsTestFuelvo.FuelTestUpload = gvgene.Rows[rowIndex].Cells[2].Text;
                //GeneratorsTestFuelvo.FuelType = gvgene.Rows[rowIndex].Cells[2].Text;
                //GeneratorsTestFuelvo.HeatRateDetails = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Location = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Make = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.Mercury = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.SerialNo = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.SoxNoxEmission = gvgene.Rows[rowIndex].Cells[3].Text;
                //GeneratorsTestFuelvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                GeneratorsTestFuelvo.Created_By = Session["uid"].ToString();
                lstGeneratorsTestFuel.Add(GeneratorsTestFuelvo);
            }
        }
        lstPreCommissioning.Clear();

        //dsMyPower.Tables.Add((DataTable)ViewState["Power_HS"]);
        //dsMyPower.Tables[6].TableName = "Power_H";

        Ds1.Tables.Clear();
        if (ViewState["Power_HS"] != null && ViewState["Power_HS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_HS"]);
            Ds1.Tables[0].TableName = "Power_H";

            foreach (GridViewRow gvrow in gvcomm.Rows)
            {
                PreCommissioning PreCommissioningvo = new PreCommissioning();
                int rowIndex = gvrow.RowIndex;

                PreCommissioningvo.Description = Ds1.Tables["Power_H"].Rows[rowIndex][1].ToString();
                PreCommissioningvo.Equipment = Ds1.Tables["Power_H"].Rows[rowIndex][0].ToString();
                PreCommissioningvo.CommissioningUpload = Ds1.Tables["Power_H"].Rows[rowIndex][2].ToString();
                PreCommissioningvo.CommissioningUploadfilepath = Ds1.Tables["Power_H"].Rows[rowIndex][3].ToString();
                #region comment


                //PreCommissioningvo.CommissioningUpload = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //PreCommissioningvo.Description = gvcomm.Rows[rowIndex].Cells[1].Text;
                //PreCommissioningvo.Equipment = gvcomm.Rows[rowIndex].Cells[2].Text;
                //PreCommissioningvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                PreCommissioningvo.Created_By = Session["uid"].ToString();
                lstPreCommissioning.Add(PreCommissioningvo);
            }
        }


        //dsMyPower.Tables.Add((DataTable)ViewState["Power_IS"]);
        //dsMyPower.Tables[7].TableName = "Power_I";

        lstTransmissionlines.Clear();
        Ds1.Tables.Clear();
        if (ViewState["Power_IS"] != null && ViewState["Power_IS"].ToString() != "")
        {
            Ds1.Tables.Add((DataTable)ViewState["Power_IS"]);
            Ds1.Tables[0].TableName = "Power_I";

            foreach (GridViewRow gvrow in gvtran.Rows)
            {
                // ******** there is missing in the field of serial no in the list please be add *************
                Transmissionlines Transmissionlinesvo = new Transmissionlines();
                int rowIndex = gvrow.RowIndex;


                Transmissionlinesvo.Description = Ds1.Tables["Power_I"].Rows[rowIndex][0].ToString();
                Transmissionlinesvo.TransmissionUpload = Ds1.Tables["Power_I"].Rows[rowIndex][1].ToString();
                Transmissionlinesvo.TransmissionUploadfilepath = Ds1.Tables["Power_I"].Rows[rowIndex][2].ToString();
                #region comment


                //Transmissionlinesvo.Description = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                //Transmissionlinesvo.TransmissionUpload = gvtran.Rows[rowIndex].Cells[1].Text;
                //Transmissionlinesvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                #endregion
                Transmissionlinesvo.Created_By = Session["uid"].ToString();
                lstTransmissionlines.Add(Transmissionlinesvo);
            }
        }
        if (BtnDelete.Text == "Next")
        {

            DataSet ds = new DataSet();

            ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;

                result = Gen.insetCFOPowerDet(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim(), lstLoadParticulars, lstCircuitBreakerLoad,
                    lstTransformerTest, lstABSwitchIsolator, lstLightningArrestor, lstGeneratorsTestFuel, lstPreCommissioning, lstTransmissionlines, txtdrawingno.Text.Trim());
                if (result > 0)
                {


                    Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else if (result == 0)
                {
                    Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Power Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
            }
            else
            {
                int result = 0;
                result = Gen.insetCFOPowerDet(Session["uid"].ToString(), Session["ApplidA"].ToString(), Session["uid"].ToString(), "", "", txtKVAAlreadyInstalled.Text, txtKVAProposed.Text, txtKVATotal.Text, txtConnectedAlreadyInstalled.Text, txtConnectProposed.Text, txtConnectTotal.Text, ddlProject.SelectedValue, ddlDistrict.SelectedValue, ddlMandal.SelectedValue, ddlVillage.SelectedValue, txtStreet.Text, txtPinCode.Text, txtTelephone.Text, txtNearTelephone.Text, txtDateofCommencement.Text, Session["uid"].ToString(), Session["uid"].ToString(), txtExtent.Text, ddlConnectLoad.SelectedValue, txtSurvey.Text, ddlregulation.SelectedValue, ddlplant.SelectedValue, ddlvoltage.SelectedValue, txtaggregatecapacity.Text.Trim(), lstLoadParticulars, lstCircuitBreakerLoad,
                    lstTransformerTest, lstABSwitchIsolator, lstLightningArrestor, lstGeneratorsTestFuel, lstPreCommissioning, lstTransmissionlines, txtdrawingno.Text.Trim());


                if (result > 0)
                {
                    Response.Redirect("frmCAFFactoryDetails.aspx?intApplicationId=" + Session["uid"].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>CFO Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;

                }
                else
                {
                    lblmsg.Text = "<font color='green'>CFO Power Details Submission Failed..!</font>";
                }


            }
        }



    }
    void FillDetails()
    {

        DataSet ds = new DataSet();
        ds = Gen.GetdataofCFOPowerDet(Session["uid"].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtdrawingno.Text = ds.Tables[0].Rows[0]["DrwaingFileNo"].ToString().Trim();

            txtKVAAlreadyInstalled.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Already"].ToString();
            txtKVAProposed.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Proposed"].ToString();
            txtKVATotal.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max_Total"].ToString();
            txtConnectedAlreadyInstalled.Text = ds.Tables[0].Rows[0]["Connect_Load_A"].ToString();
            txtConnectProposed.Text = ds.Tables[0].Rows[0]["Connect_Load_B"].ToString();
            txtConnectTotal.Text = ds.Tables[0].Rows[0]["Connect_Load_C"].ToString();
            ddlProject.SelectedValue = ds.Tables[0].Rows[0]["Prop_Location"].ToString();
            ddlDistrict.SelectedValue = ds.Tables[0].Rows[0]["intDistrictid"].ToString();
            getMandals();
            ddlMandal.SelectedValue = ds.Tables[0].Rows[0]["intMandalid"].ToString();
            getVillages();
            ddlVillage.SelectedValue = ds.Tables[0].Rows[0]["Village_Name"].ToString();
            txtSurvey.Text = ds.Tables[0].Rows[0]["Survey_No"].ToString();
            txtStreet.Text = ds.Tables[0].Rows[0]["Street_Name"].ToString();
            txtPinCode.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
            txtTelephone.Text = ds.Tables[0].Rows[0]["Telephonce_No"].ToString();
            txtNearTelephone.Text = ds.Tables[0].Rows[0]["Nearest_Tel_No"].ToString();

            if (ds.Tables[0].Rows[0]["Date_Comm_Production"].ToString().Trim() != "")
            {
                txtDateofCommencement.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Comm_Production"]).ToString("dd-MMM-yyyy");
            }
            txtExtent.Text = ds.Tables[0].Rows[0]["Extent"].ToString();
            ddlConnectLoad.SelectedValue = ds.Tables[0].Rows[0]["Type_of_connect_Load"].ToString();

            ddlregulation.SelectedValue = ds.Tables[0].Rows[0]["Regulation_type"].ToString();
            ddlvoltage.SelectedValue = ds.Tables[0].Rows[0]["Voltage_Slno"].ToString();
            ddlplant.SelectedValue = ds.Tables[0].Rows[0]["Plant_slno"].ToString();
            txtaggregatecapacity.Text = ds.Tables[0].Rows[0]["AggregateCapacity"].ToString();

            DataSet dsattachments = new DataSet();
            dsattachments = Gen.ViewAttachmentCFO(Session["uid"].ToString());

            if (dsattachments.Tables[0].Rows.Count > 0)
            {
                int c = dsattachments.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;
               
                while (i < c)
                {
                    sen2 = dsattachments.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sennew = dsattachments.Tables[0].Rows[i]["linkview"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");

                    //  sen = sen1.Replace(@"C:/TSiPASS/Attachments/1192/", "~/");//"C:/TSiPASS/Attachments/1192/B1Form\CateogryofRegistration.jpg"
                    if (sen1.Contains("CFOAttachments"))
                    {
                        sen = sen1.Replace(sen1.Substring(0, sen1.IndexOf(@"/CFOAttachments")), "~/");
                        if (sen.Contains("Supplier"))
                        {
                            lblAgreement.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            lblAgreement.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            LabelAgreement.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            //HyperLink1.NavigateUrl = sen;
                            //HyperLink1.Text = 
                        }

                        if (sen.Contains("WRI"))
                        {
                            HpLicense.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            HpLicense.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblLicense.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("WRII"))
                        {
                            Hppermit.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            Hppermit.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblpermitr.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }

                        if (sen.Contains("Feasibilityreport"))
                        {
                            HpFeasibility.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            HpFeasibility.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblFeasibility.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("ElectricalDiagram"))
                        {
                            HpElectricalDiagram.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            HpElectricalDiagram.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblElectricalDiagram.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("StructralLayout"))
                        {
                            Hplayout.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            Hplayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lbllayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("equipmentdrawing"))
                        {
                            Hpequipmentdrawing.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            Hpequipmentdrawing.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblequipmentdrawing.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                        if (sen.Contains("earthinglayout"))
                        {
                            hpearthinglayout.NavigateUrl = "CS.aspx?filepathnew=" + encpassword; //sen;
                            hpearthinglayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                            lblearthinglayout.Text = dsattachments.Tables[0].Rows[i][1].ToString();
                        }
                    }
                    i++;
                }

            }

        }



    }


    public DataSet getcommondetails(int uid)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@uid",SqlDbType.Int)

                };
            p[0].Value = Session["uid"].ToString().Trim();


            // XmlDocument doc = new XmlDocument(); USP_GET_RM_ABSTRACTDETAILS

            GDs = Gen.GenericFillDs("usp_abrast_details", p);



            if (GDs.Tables[0].Rows.Count > 0)
            {

                gvLoad.DataSource = GDs.Tables[0];
                gvLoad.DataBind();
                GDs.Tables[0].TableName = "Power_A";
                ViewState["Power_AS"] = GDs.Tables[0];
                ViewState["Power_A"] = "1";
                //string[] param = new string[] {
                //    GDs.Tables[0].Rows[0]["EquipmentName"].ToString(),
                //    GDs.Tables[0].Rows[0]["Make"].ToString(),
                //    GDs.Tables[0].Rows[0]["SerialNo"].ToString(),
                //        GDs.Tables[0].Rows[0]["CapacityinKV"].ToString(),
                //            GDs.Tables[0].Rows[0]["CapacityinHP"].ToString(),
                //                GDs.Tables[0].Rows[0]["LoadUpload"].ToString(),
                //                     GDs.Tables[0].Rows[0]["capacityloadpath"].ToString() };
                //if (ViewState["Power_A"].ToString() == "0")
                //{
                //    CreatePowerTable(Type);
                //}
                //else
                //{
                //    dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
                //}
                //AddDataToPowerTable("Upload Load Particulars", param, dsMyPower.Tables["Power_A"]);

                ////if (ViewState["Power_A"].ToString() == "0")
                ////{
                ////    CreatePowerTable("");
                ////}
                ////else
                ////{
                //dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
                ////}

                ////AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_A"]);
                //gvLoad.DataSource = dsMyPower.Tables["Power_A"];
                //gvLoad.DataBind();
                ////ClearFuncs(Type);
                //ViewState["Power_A"] = "1";
                //ViewState["Power_AS"] = dsMyPower.Tables["Power_A"];
            }
            if (GDs.Tables[1].Rows.Count > 0)
            {
                GDs.Tables[1].TableName = "Power_B";
                gvcircuit.DataSource = GDs.Tables[1];
                gvcircuit.DataBind();
                ViewState["Power_BS"] = GDs.Tables[1];
                ViewState["Power_B"] = "1";
            }

            if (GDs.Tables[2].Rows.Count > 0)
            {
                GDs.Tables[2].TableName = "Power_F";
                gvlight.DataSource = GDs.Tables[2];
                gvlight.DataBind();
                ViewState["Power_FS"] = GDs.Tables[2];
                ViewState["Power_F"] = "1";
            }

            if (GDs.Tables[3].Rows.Count > 0)
            {
                GDs.Tables[3].TableName = "Power_C";
                gvTransformer.DataSource = GDs.Tables[3];

                gvTransformer.DataBind();
                ViewState["Power_CS"] = GDs.Tables[3];
                ViewState["Power_C"] = "1";

            }

            if (GDs.Tables[4].Rows.Count > 0)
            {
                GDs.Tables[4].TableName = "Power_E";
                gvswitch.DataSource = GDs.Tables[4];
                gvswitch.DataBind();
                ViewState["Power_ES"] = GDs.Tables[4];
                ViewState["Power_E"] = "1";

            }
            if (GDs.Tables[5].Rows.Count > 0)
            {
                GDs.Tables[5].TableName = "Power_G";
                gvgene.DataSource = GDs.Tables[5];
                gvgene.DataBind();
                ViewState["Power_GS"] = GDs.Tables[5];
                ViewState["Power_G"] = "1";

            }
            if (GDs.Tables[6].Rows.Count > 0)
            {
                GDs.Tables[6].TableName = "Power_H";
                gvcomm.DataSource = GDs.Tables[6];
                gvcomm.DataBind();
                ViewState["Power_HS"] = GDs.Tables[6];
                ViewState["Power_H"] = "1";
            }
            if (GDs.Tables[7].Rows.Count > 0)
            {
                GDs.Tables[7].TableName = "Power_I";
                gvtran.DataSource = GDs.Tables[7];
                gvtran.DataBind();
                ViewState["Power_IS"] = GDs.Tables[7];
                ViewState["Power_I"] = "1";
            }
            return GDs;
        }
        catch (Exception ex)
        {
            throw ex;

            //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {

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
    protected void txtcontact32_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact29_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        getMandals();
    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        getVillages();
    }
    protected void txtKVAAlreadyInstalled_TextChanged(object sender, EventArgs e)
    {
        if (txtKVAAlreadyInstalled.Text == "")
        {
            txtKVAAlreadyInstalled.Text = "0";
        }
        if (txtKVAProposed.Text == "")
        {
            txtKVAProposed.Text = "0";
        }

        txtKVATotal.Text = (Convert.ToDecimal(txtKVAAlreadyInstalled.Text) + Convert.ToDecimal(txtKVAProposed.Text)).ToString();
    }
    protected void txtKVAProposed_TextChanged(object sender, EventArgs e)
    {
        if (txtKVAAlreadyInstalled.Text == "")
        {
            txtKVAAlreadyInstalled.Text = "0";
        }
        if (txtKVAProposed.Text == "")
        {
            txtKVAProposed.Text = "0";
        }

        txtKVATotal.Text = (Convert.ToDecimal(txtKVAAlreadyInstalled.Text) + Convert.ToDecimal(txtKVAProposed.Text)).ToString();
    }
    protected void txtConnectedAlreadyInstalled_TextChanged(object sender, EventArgs e)
    {
        if (txtConnectedAlreadyInstalled.Text == "")
        {
            txtConnectedAlreadyInstalled.Text = "0";

        }
        if (txtConnectProposed.Text == "")
        {
            txtConnectProposed.Text = "0";
        }

        txtConnectTotal.Text = Convert.ToString(Convert.ToDecimal(txtConnectedAlreadyInstalled.Text) + Convert.ToDecimal(txtConnectProposed.Text));
    }
    protected void txtConnectProposed_TextChanged(object sender, EventArgs e)
    {
        if (txtConnectedAlreadyInstalled.Text == "")
        {
            txtConnectedAlreadyInstalled.Text = "0";

        }
        if (txtConnectProposed.Text == "")
        {
            txtConnectProposed.Text = "0";
        }
        txtConnectTotal.Text = (Convert.ToDecimal(txtConnectedAlreadyInstalled.Text) + Convert.ToDecimal(txtConnectProposed.Text)).ToString();
    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmCAFLINEOFMANUFACTURE.aspx?intApplicationId=" + Session["uid"].ToString() + "&Previous=" + "P");

    }
    public void BindRegulations(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlregulation.Items.Clear();
            dsd = Gen.GetRegulations();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlregulation.DataSource = dsd.Tables[0];
                ddlregulation.DataValueField = "Regulation_Id";
                ddlregulation.DataTextField = "Regulation_Name";
                ddlregulation.DataBind();
                ddlregulation.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlregulation.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }
    protected void ddlregulation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlregulation.SelectedItem.Text.Trim() == "43(3)" || ddlregulation.SelectedItem.Text.Trim() == "43(4)" || ddlregulation.SelectedItem.Text.Trim() == "36")
        {
            trvoltage.Visible = true;
            trPlant.Visible = false;
        }
        else if (ddlregulation.SelectedItem.Text.Trim() == "32" || ddlregulation.SelectedItem.Text.Trim() == "43(4) & 32")
        {
            trvoltage.Visible = false;
            trPlant.Visible = true;
        }

    }

    public void BindVoltage(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlvoltage.Items.Clear();
            dsd = Gen.GetVolations("");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlvoltage.DataSource = dsd.Tables[0];
                ddlvoltage.DataValueField = "Voltage_Id";
                ddlvoltage.DataTextField = "Voltage_Name";
                ddlvoltage.DataBind();
                ddlvoltage.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlvoltage.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
        }
    }

    public void BindPlant(DropDownList ddl)
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlplant.Items.Clear();
            dsd = Gen.GetPlants("");
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlplant.DataSource = dsd.Tables[0];
                ddlplant.DataValueField = "Plant_Id";
                ddlplant.DataTextField = "Plant_Name";
                ddlplant.DataBind();
                ddlplant.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlplant.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblerror.Text = ex.Message;
            //lblerror.CssClass = "errormsg";
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

    protected void BtnAgreement_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileAgreement.HasFile)
        {
            if ((FileAgreement.PostedFile != null) && (FileAgreement.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileAgreement.PostedFile.FileName);
                try
                {

                    string[] fileType = FileAgreement.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\Supplier");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileAgreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileAgreement.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Supplier");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblAgreement.Text = FileAgreement.FileName;
                            LabelAgreement.Text = FileAgreement.FileName;
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

    protected void btnLicense_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadLicense.HasFile)
        {
            if ((FileUploadLicense.PostedFile != null) && (FileUploadLicense.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadLicense.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadLicense.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\WRI");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadLicense.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "WRI");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblLicense.Text = FileUploadLicense.FileName;
                            HpLicense.Text = FileUploadLicense.FileName;
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

    protected void btnpermit_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadpermit.HasFile)
        {
            if ((FileUploadpermit.PostedFile != null) && (FileUploadpermit.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadpermit.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadpermit.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\WRII");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadpermit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadpermit.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "WRII");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblpermitr.Text = FileUploadpermit.FileName;
                            Hppermit.Text = FileUploadpermit.FileName;
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

    protected void btnFeasibility_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadFeasibility.HasFile)
        {
            if ((FileUploadFeasibility.PostedFile != null) && (FileUploadFeasibility.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadFeasibility.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadFeasibility.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\Feasibilityreport ");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadFeasibility.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadFeasibility.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "Feasibilityreport");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblFeasibility.Text = FileUploadFeasibility.FileName;
                            HpFeasibility.Text = FileUploadFeasibility.FileName;
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

    protected void btnElectricalDiagram_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadElectricalDiagram.HasFile)
        {
            if ((FileUploadElectricalDiagram.PostedFile != null) && (FileUploadElectricalDiagram.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadElectricalDiagram.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadElectricalDiagram.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ElectricalDiagram");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadElectricalDiagram.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadElectricalDiagram.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "ElectricalDiagram");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblElectricalDiagram.Text = FileUploadElectricalDiagram.FileName;
                            HpElectricalDiagram.Text = FileUploadElectricalDiagram.FileName;
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

    protected void btnlayout_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadlayout.HasFile)
        {
            if ((FileUploadlayout.PostedFile != null) && (FileUploadlayout.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadlayout.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadlayout.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\StructralLayout");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadlayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadlayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "StructralLayout");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lbllayout.Text = FileUploadlayout.FileName;
                            Hplayout.Text = FileUploadlayout.FileName;
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

    protected void btnequipmentdrawing_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadequipmentdrawing.HasFile)
        {
            if ((FileUploadequipmentdrawing.PostedFile != null) && (FileUploadequipmentdrawing.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadequipmentdrawing.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadequipmentdrawing.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\equipmentdrawing");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadequipmentdrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadequipmentdrawing.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "equipmentdrawing");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblequipmentdrawing.Text = FileUploadequipmentdrawing.FileName;
                            Hpequipmentdrawing.Text = FileUploadequipmentdrawing.FileName;
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

    protected void btnearthinglayout_Click(object sender, EventArgs e)
    {
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (FileUploadearthinglayout.HasFile)
        {
            if ((FileUploadearthinglayout.PostedFile != null) && (FileUploadearthinglayout.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(FileUploadearthinglayout.PostedFile.FileName);
                try
                {

                    string[] fileType = FileUploadearthinglayout.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\earthinglayout");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            FileUploadearthinglayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                FileUploadearthinglayout.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                        int result = 0;

                        result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "earthinglayout");


                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblearthinglayout.Text = FileUploadearthinglayout.FileName;
                            hpearthinglayout.Text = FileUploadearthinglayout.FileName;
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

    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    protected void gvLoad_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvLoad_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvLoad.DataSource = DeleteDataFromPowerTable("Upload Load Particulars", e.RowIndex);
            gvLoad.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnloadsave_Click(object sender, EventArgs e)
    {
        string Type = "Upload Load Particulars";
        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (fileloadupload.HasFile)
        {
            if ((fileloadupload.PostedFile != null) && (fileloadupload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(fileloadupload.PostedFile.FileName);
                try
                {

                    string[] fileType = fileloadupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\Load");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            fileloadupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                fileloadupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        string[] param = new string[] { txtequipment.Text.Trim(), txtmake.Text.Trim(), txtserialno.Text.Trim(), txtcapinkv.Text.Trim(), txtcaphp.Text.Trim(), fileloadupload.FileName.Trim(), newPath };
        if (ViewState["Power_A"].ToString() == "0")
        {
            CreatePowerTable(Type);
        }
        else
        {
            dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
        }
        AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_A"]);
        gvLoad.DataSource = dsMyPower.Tables["Power_A"];
        gvLoad.DataBind();
        ClearFuncs(Type);
        ViewState["Power_A"] = "1";
        ViewState["Power_AS"] = dsMyPower.Tables["Power_A"];
    }
    protected void btnloadclear_Click(object sender, EventArgs e)
    {

    }
    protected void btncircuitadd_Click(object sender, EventArgs e)
    {
        string Type = "Upload Circuit Breaker/Load Break Switch Test Reports";

        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (TestCertificateupload.HasFile)
        {
            if ((TestCertificateupload.PostedFile != null) && (TestCertificateupload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(TestCertificateupload.PostedFile.FileName);
                try
                {

                    string[] fileType = TestCertificateupload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\CircuitBreaker");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            TestCertificateupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                TestCertificateupload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        string[] param = new string[] { txtcircuitlocation.Text.Trim(), txtcircuitcapacity.Text.Trim(), txtcircuitmake.Text.Trim(), TextBox5.Text.Trim(), txtISCKA.Text.Trim(), TestCertificateupload.FileName.Trim(), newPath };
        if (ViewState["Power_B"].ToString() == "0")
        {
            CreatePowerTable(Type);
        }
        else
        {
            dsMyPower.Tables.Add((DataTable)ViewState["Power_BS"]);
        }
        AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_B"]);
        gvcircuit.DataSource = dsMyPower.Tables["Power_B"];
        gvcircuit.DataBind();
        ClearFuncs(Type);
        ViewState["Power_B"] = "1";
        ViewState["Power_BS"] = dsMyPower.Tables["Power_B"];
    }
    protected void btncircuitclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvcircuit_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvcircuit_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvcircuit.DataSource = DeleteDataFromPowerTable("Upload Circuit Breaker/Load Break Switch Test Reports", e.RowIndex);
            gvcircuit.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnTransformersame_Click(object sender, EventArgs e)
    {
        string Type = "Upload Transformer Test Certificates";

        string newPath = "";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if (uploadTransformerTestUpload.HasFile)
        {
            if ((uploadTransformerTestUpload.PostedFile != null) && (uploadTransformerTestUpload.PostedFile.ContentLength > 0))
            {
                //determine file name
                string sFileName = System.IO.Path.GetFileName(uploadTransformerTestUpload.PostedFile.FileName);
                try
                {

                    string[] fileType = uploadTransformerTestUpload.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                    {
                        //Create a new subfolder under the current active folder
                        newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\TransformerTest");
                        // Create the subfolder
                        if (!Directory.Exists(newPath))

                            System.IO.Directory.CreateDirectory(newPath);
                        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                        int count = dir.GetFiles().Length;
                        if (count == 0)
                            uploadTransformerTestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        else
                        {
                            if (count == 1)
                            {
                                string[] Files = Directory.GetFiles(newPath);

                                foreach (string file in Files)
                                {
                                    File.Delete(file);
                                }
                                uploadTransformerTestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        string[] param = new string[] { txtTransformer.Text.Trim(), txttransfEquipment.Text.Trim(), ddltransformer.SelectedItem.Text.Trim(), txtTransformercapacity.Text.Trim(), txttransmake.Text.Trim(), txttransserialno.Text.Trim(), txtVoltage.Text.Trim(), uploadTransformerTestUpload.FileName.Trim(), newPath };

        if (ViewState["Power_C"].ToString() == "0")
        {
            CreatePowerTable(Type);
        }
        else
        {
            dsMyPower.Tables.Add((DataTable)ViewState["Power_CS"]);
        }
        AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_C"]);
        gvTransformer.DataSource = dsMyPower.Tables["Power_C"];
        gvTransformer.DataBind();
        ClearFuncs(Type);
        ViewState["Power_C"] = "1";
        ViewState["Power_CS"] = dsMyPower.Tables["Power_C"];
    }
    protected void btnTransformerclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvTransformer_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvTransformer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvTransformer.DataSource = DeleteDataFromPowerTable("Upload Transformer Test Certificates", e.RowIndex);
            gvTransformer.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnswitchsave_Click(object sender, EventArgs e)
    {

        try
        {
            string Type = "Upload AB Switch / Isolator Test Report";



            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (TestUpload.HasFile)
            {
                if ((TestUpload.PostedFile != null) && (TestUpload.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(TestUpload.PostedFile.FileName);
                    try
                    {

                        string[] fileType = TestUpload.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ ABSwitch");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                TestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    TestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            string[] param = new string[] { txtSwitchlocation.Text.Trim(), ddlearth.SelectedItem.Text.Trim(), txtswitchVoltage.Text.Trim(), txtswitchcapacity.Text.Trim(), txtswitchmake.Text.Trim(), txtswitchserialno.Text.Trim(), TestUpload.FileName.Trim(), newPath };
            if (ViewState["Power_E"].ToString() == "0")
            {
                CreatePowerTable(Type);
            }
            else
            {
                dsMyPower.Tables.Add((DataTable)ViewState["Power_ES"]);
            }
            AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_E"]);
            gvswitch.DataSource = dsMyPower.Tables["Power_E"];
            gvswitch.DataBind();
            ClearFuncs(Type);
            ViewState["Power_E"] = "1";
            ViewState["Power_ES"] = dsMyPower.Tables["Power_E"];
        }

        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btnswitchclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvswitch_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvswitch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvswitch.DataSource = DeleteDataFromPowerTable("Upload AB Switch / Isolator Test Report", e.RowIndex);
            gvswitch.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btnlightsave_Click(object sender, EventArgs e)
    {
        try
        {
            string Type = "Upload Lightning Arrestor Test Reports";
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (testUploadlightening.HasFile)
            {
                if ((testUploadlightening.PostedFile != null) && (testUploadlightening.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(testUploadlightening.PostedFile.FileName);
                    try
                    {

                        string[] fileType = testUploadlightening.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ Lightning");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                testUploadlightening.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    testUploadlightening.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            string[] param = new string[] { txtlightinglocation.Text.Trim(), txtlightvoltage.Text.Trim(), txtlightcapacity.Text.Trim(), txtlightmake.Text.Trim(), TextBox24.Text.Trim(), testUploadlightening.FileName.Trim(), newPath };
            if (ViewState["Power_F"].ToString() == "0")
            {
                CreatePowerTable(Type);
            }
            else
            {
                dsMyPower.Tables.Add((DataTable)ViewState["Power_FS"]);
            }
            AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_F"]);
            gvlight.DataSource = dsMyPower.Tables["Power_F"];
            gvlight.DataBind();
            ClearFuncs(Type);
            ViewState["Power_F"] = "1";
            ViewState["Power_FS"] = dsMyPower.Tables["Power_F"];
        }
        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btnlightclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvlight_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvlight_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvlight.DataSource = DeleteDataFromPowerTable("Upload Lightning Arrestor Test Reports", e.RowIndex);
            gvlight.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btngenesave_Click(object sender, EventArgs e)
    {
        try
        {
            string Type = "Upload Generators Test Reports with Fuel";
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FuelTestUpload.HasFile)
            {
                if ((FuelTestUpload.PostedFile != null) && (FuelTestUpload.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FuelTestUpload.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FuelTestUpload.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ Generators");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FuelTestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FuelTestUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            string[] param = new string[] { txtgeneratorlocation.Text.Trim(), txtgenercapacity.Text.Trim(), txtgenemake.Text.Trim(), txtgeneserialno.Text.Trim(), txtfueltype.Text.Trim(), txtfuelsource.Text.Trim(), txtsoxnox.Text.Trim(), txtmercury.Text.Trim(), txtheatrate.Text.Trim(), FuelTestUpload.FileName.Trim(), newPath };
            if (ViewState["Power_G"].ToString() == "0")
            {
                CreatePowerTable(Type);
            }
            else
            {
                dsMyPower.Tables.Add((DataTable)ViewState["Power_GS"]);
            }
            AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_G"]);
            gvgene.DataSource = dsMyPower.Tables["Power_G"];
            gvgene.DataBind();
            ClearFuncs(Type);
            ViewState["Power_G"] = "1";
            ViewState["Power_GS"] = dsMyPower.Tables["Power_G"];
        }
        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btngeneclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvgene_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvgene_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvgene.DataSource = DeleteDataFromPowerTable("Upload Generators Test Reports with Fuel", e.RowIndex);
            gvgene.DataBind();
        }
        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btncommsave_Click(object sender, EventArgs e)
    {
        try
        {
            string Type = "Upload Pre Commissioning Test Report";

            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (CommissioningUpload.HasFile)
            {
                if ((CommissioningUpload.PostedFile != null) && (CommissioningUpload.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(CommissioningUpload.PostedFile.FileName);
                    try
                    {

                        string[] fileType = CommissioningUpload.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ PreCommissioning");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                CommissioningUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    CommissioningUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            string[] param = new string[] { txtcommequipment.Text.Trim(), txtcommdesc.Text.Trim(), CommissioningUpload.FileName.Trim(), newPath };
            if (ViewState["Power_H"].ToString() == "0")
            {
                CreatePowerTable(Type);
            }
            else
            {
                dsMyPower.Tables.Add((DataTable)ViewState["Power_HS"]);
            }
            //CreatePowerTable(Type);
            AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_H"]);
            gvcomm.DataSource = dsMyPower.Tables["Power_H"];
            gvcomm.DataBind();
            ClearFuncs(Type);
            ViewState["Power_H"] = "1";
            ViewState["Power_HS"] = dsMyPower.Tables["Power_H"];
        }
        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btncommclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvcomm_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvcomm_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvcomm.DataSource = DeleteDataFromPowerTable("Upload Pre Commissioning Test Report", e.RowIndex);
            gvcomm.DataBind();

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void btntransave_Click(object sender, EventArgs e)
    {
        try
        {

            string Type = "Upload Transmission lines";

            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (TransmissionUpload.HasFile)
            {
                if ((TransmissionUpload.PostedFile != null) && (TransmissionUpload.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(TransmissionUpload.PostedFile.FileName);
                    try
                    {

                        string[] fileType = TransmissionUpload.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "DWG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\ Transmissionlines");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                TransmissionUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    TransmissionUpload.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            string[] param = new string[] { txttransDescription.Text.Trim(), TransmissionUpload.FileName.Trim(), newPath };
            if (ViewState["Power_I"].ToString() == "0")
            {
                CreatePowerTable(Type);
            }
            else
            {
                dsMyPower.Tables.Add((DataTable)ViewState["Power_IS"]);

            }
            AddDataToPowerTable(Type, param, dsMyPower.Tables["Power_I"]);
            gvtran.DataSource = dsMyPower.Tables["Power_I"];
            gvtran.DataBind();
            gvtran.Visible = true;
            ClearFuncs(Type);
            ViewState["Power_I"] = "1";
            ViewState["Power_IS"] = dsMyPower.Tables["Power_I"];
        }
        catch (Exception ee)
        {

            throw;
        }
    }
    protected void btntransclear_Click(object sender, EventArgs e)
    {

    }
    protected void gvtran_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gvtran_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            gvtran.DataSource = DeleteDataFromPowerTable("Upload Transmission lines", e.RowIndex);
            gvtran.DataBind();
        }
        catch (Exception ee)
        {

            throw;
        }


    }
    private void ClearFuncs(string Type)
    {
        switch (Type)
        {
            case "Upload Transmission lines":


                txttransDescription.Focus();
                TransmissionUpload.Focus();
                break;
            case "Upload Pre Commissioning Test Report":
                txtcommequipment.Text = "";
                txtcommdesc.Text = "";
                txtcommequipment.Focus();
                CommissioningUpload.Focus();
                break;
            case "Upload Generators Test Reports with Fuel":
                txtgeneratorlocation.Text = "";
                txtgenercapacity.Text = "";
                txtgenemake.Text = "";
                txtgeneserialno.Text = "";
                txtfueltype.Text = "";
                txtfuelsource.Text = "";
                txtsoxnox.Text = "";
                txtmercury.Text = "";
                txtheatrate.Text = "";
                txtgeneratorlocation.Focus();
                FuelTestUpload.Focus();
                break;
            case "Upload Lightning Arrestor Test Reports":
                txtlightinglocation.Text = "";
                txtlightvoltage.Text = "";
                txtlightcapacity.Text = "";
                txtlightmake.Text = "";
                TextBox24.Text = "";
                txtlightinglocation.Focus();
                testUploadlightening.Focus();
                break;
            case "Upload AB Switch / Isolator Test Report":
                txtSwitchlocation.Text = "";
                ddlearth.ClearSelection();
                txtswitchVoltage.Text = "";
                txtswitchcapacity.Text = "";
                txtswitchmake.Text = "";
                txtswitchserialno.Text = "";
                txtSwitchlocation.Focus();
                TestUpload.Focus();
                break;
            case "Upload Transformer Test Certificates":
                txtTransformer.Text = "";
                txttransfEquipment.Text = "";
                ddltransformer.ClearSelection();
                txtTransformercapacity.Text = "";
                txttransmake.Text = "";
                txttransserialno.Text = "";
                txtVoltage.Text = "";
                txtTransformer.Focus();
                uploadTransformerTestUpload.Focus();
                break;
            case "Upload Circuit Breaker/Load Break Switch Test Reports":
                txtcircuitlocation.Text = "";
                txtcircuitcapacity.Text = "";
                txtcircuitmake.Text = "";
                TextBox5.Text = "";
                txtISCKA.Text = "";
                txtcircuitlocation.Focus();
                TestCertificateupload.Focus();
                break;
            case "Upload Load Particulars":
                txtequipment.Text = "";
                txtmake.Text = "";
                txtserialno.Text = "";
                txtcapinkv.Text = "";
                txtcaphp.Text = "";
                txtequipment.Focus();
                fileloadupload.Focus();


                break;
        }
    }
    protected DataTable CreatePowerTable(string Type)
    {

        try
        {
            switch (Type)
            {
                case "Upload Transmission lines":
                    dtMyPower = new DataTable("Power_I");
                    dtMyPower.Columns.Add("Description", typeof(string));

                    dtMyPower.Columns.Add("TransmissionUpload", typeof(string));
                    dtMyPower.Columns.Add("TransmissionUploadfilepath", typeof(string));
                    break;
                case "Upload Pre Commissioning Test Report":
                    dtMyPower = new DataTable("Power_H");
                    dtMyPower.Columns.Add("Equipment", typeof(string));
                    dtMyPower.Columns.Add("Description", typeof(string));
                    dtMyPower.Columns.Add("CommissioningUpload", typeof(string));
                    dtMyPower.Columns.Add("CommissioningUploadfilepath", typeof(string));
                    break;
                case "Upload Generators Test Reports with Fuel":
                    dtMyPower = new DataTable("Power_G");
                    dtMyPower.Columns.Add("Location", typeof(string));
                    dtMyPower.Columns.Add("CapacityA", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("SerialNo", typeof(string));
                    dtMyPower.Columns.Add("FuelType", typeof(string));
                    dtMyPower.Columns.Add("FuelSource", typeof(string));
                    dtMyPower.Columns.Add("SoxNoxEmission", typeof(string));
                    dtMyPower.Columns.Add("Mercury", typeof(string));
                    dtMyPower.Columns.Add("HeatRateDetails", typeof(string));
                    dtMyPower.Columns.Add("FuelTestUpload", typeof(string));
                    dtMyPower.Columns.Add("FuelTestUploadfilepath", typeof(string));
                    break;
                case "Upload Lightning Arrestor Test Reports":
                    dtMyPower = new DataTable("Power_F");
                    dtMyPower.Columns.Add("Location", typeof(string));
                    dtMyPower.Columns.Add("VoltageV", typeof(string));
                    dtMyPower.Columns.Add("CapacityA", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("SerialNo", typeof(string));
                    dtMyPower.Columns.Add("TestUpload", typeof(string));
                    dtMyPower.Columns.Add("Testuploadfilepath", typeof(string));
                    break;

                case "Upload AB Switch / Isolator Test Report":
                    dtMyPower = new DataTable("Power_E");
                    dtMyPower.Columns.Add("Location", typeof(string));
                    dtMyPower.Columns.Add("WithorWithoutEarthSwitch", typeof(string));
                    dtMyPower.Columns.Add("VoltageV", typeof(string));
                    dtMyPower.Columns.Add("CapacityA", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("SerialNo", typeof(string));
                    dtMyPower.Columns.Add("TestUpload", typeof(string));
                    dtMyPower.Columns.Add("testuploadpath", typeof(string));
                    break;

                case "Upload Transformer Test Certificates":
                    dtMyPower = new DataTable("Power_C");// need to verify
                    dtMyPower.Columns.Add("Transformer", typeof(string));
                    dtMyPower.Columns.Add("EquipmentName", typeof(string));
                    dtMyPower.Columns.Add("TypeofTransformer", typeof(string));
                    dtMyPower.Columns.Add("Capacity", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("SerialNo", typeof(string));
                    dtMyPower.Columns.Add("VoltageHVLV", typeof(string));
                    dtMyPower.Columns.Add("TransformerTestUpload", typeof(string));
                    dtMyPower.Columns.Add("transformeruploadfilepath", typeof(string));
                    break;
                case "Upload Circuit Breaker/Load Break Switch Test Reports":
                    dtMyPower = new DataTable("Power_B");
                    dtMyPower.Columns.Add("Location", typeof(string));
                    dtMyPower.Columns.Add("CapacityA", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("CBSerialNo", typeof(string));
                    dtMyPower.Columns.Add("ISCKA", typeof(string));
                    dtMyPower.Columns.Add("TestCertificateUpload", typeof(string));
                    dtMyPower.Columns.Add("testcertificatefilepath", typeof(string));
                    break;
                case "Upload Load Particulars":
                    dtMyPower = new DataTable("Power_A");
                    dtMyPower.Columns.Add("EquipmentName", typeof(string));
                    dtMyPower.Columns.Add("Make", typeof(string));
                    dtMyPower.Columns.Add("SerialNo", typeof(string));
                    dtMyPower.Columns.Add("CapacityinKV", typeof(string));
                    dtMyPower.Columns.Add("CapacityinHP", typeof(string));
                    dtMyPower.Columns.Add("Loadupload", typeof(string));
                    dtMyPower.Columns.Add("capacityloadpath", typeof(string));
                    break;
            }
            dsMyPower.Tables.Add(dtMyPower);
        }
        catch (Exception ee)
        {
            throw ee;
        }

        return dtMyPower;
    }
    private void AddDataToPowerTable(string Type, string[] parameter, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();
            switch (Type)
            {
                case "Upload Transmission lines":

                    Row["Description"] = parameter[0].ToString();
                    Row["TransmissionUpload"] = parameter[1].ToString();
                    Row["TransmissionUploadfilepath"] = parameter[2].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload Pre Commissioning Test Report":
                    Row["Equipment"] = parameter[0].ToString();
                    Row["Description"] = parameter[1].ToString();
                    Row["CommissioningUpload"] = parameter[2].ToString();
                    Row["CommissioningUploadfilepath"] = parameter[3].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload Generators Test Reports with Fuel":
                    Row["Location"] = parameter[0].ToString();
                    Row["CapacityA"] = parameter[1].ToString();
                    Row["Make"] = parameter[2].ToString();
                    Row["SerialNo"] = parameter[3].ToString();
                    Row["FuelType"] = parameter[4].ToString();
                    Row["FuelSource"] = parameter[5].ToString();
                    Row["SoxNoxEmission"] = parameter[6].ToString();
                    Row["Mercury"] = parameter[7].ToString();
                    Row["HeatRateDetails"] = parameter[8].ToString();
                    Row["FuelTestUpload"] = parameter[9].ToString();
                    Row["FuelTestUploadfilepath"] = parameter[10].ToString();
                    myTable.Rows.Add(Row);
                    break;

                case "Upload Lightning Arrestor Test Reports":
                    Row["Location"] = parameter[0].ToString();
                    Row["VoltageV"] = parameter[1].ToString();
                    Row["CapacityA"] = parameter[2].ToString();
                    Row["Make"] = parameter[3].ToString();
                    Row["SerialNo"] = parameter[4].ToString();
                    Row["TestUpload"] = parameter[5].ToString();
                    Row["Testuploadfilepath"] = parameter[6].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload AB Switch / Isolator Test Report":
                    Row["Location"] = parameter[0].ToString();
                    Row["WithorWithoutEarthSwitch"] = parameter[1].ToString();
                    Row["VoltageV"] = parameter[2].ToString();
                    Row["CapacityA"] = parameter[3].ToString();
                    Row["Make"] = parameter[4].ToString();
                    Row["SerialNo"] = parameter[5].ToString();
                    Row["TestUpload"] = parameter[6].ToString();
                    Row["testuploadpath"] = parameter[7].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload Transformer Test Certificates":
                    Row["Transformer"] = parameter[0].ToString();
                    Row["EquipmentName"] = parameter[1].ToString();
                    Row["TypeofTransformer"] = parameter[2].ToString();
                    Row["Capacity"] = parameter[3].ToString();
                    Row["Make"] = parameter[4].ToString();
                    Row["SerialNo"] = parameter[5].ToString();
                    Row["VoltageHVLV"] = parameter[6].ToString();
                    Row["TransformerTestUpload"] = parameter[7].ToString();
                    Row["transformeruploadfilepath"] = parameter[8].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload Circuit Breaker/Load Break Switch Test Reports":
                    Row["Location"] = parameter[0].ToString();
                    Row["CapacityA"] = parameter[1].ToString();
                    Row["Make"] = parameter[2].ToString();
                    Row["CBSerialNo"] = parameter[3].ToString();
                    Row["ISCKA"] = parameter[4].ToString();
                    Row["TestCertificateUpload"] = parameter[5].ToString();
                    Row["testcertificatefilepath"] = parameter[6].ToString();
                    myTable.Rows.Add(Row);
                    break;
                case "Upload Load Particulars":
                    Row["EquipmentName"] = parameter[0].ToString();
                    Row["Make"] = parameter[1].ToString();
                    Row["SerialNo"] = parameter[2].ToString();
                    Row["CapacityinKV"] = parameter[3].ToString();
                    Row["CapacityinHP"] = parameter[4].ToString();
                    Row["LoadUpload"] = parameter[5].ToString();
                    Row["capacityloadpath"] = parameter[6].ToString();
                    myTable.Rows.Add(Row);
                    break;
            }
        }
        catch (Exception ee)
        {
        }
    }
    private DataSet DeleteDataFromPowerTable(string Type, int parameter)
    {
        try
        {
            switch (Type)
            {
                case "Upload Transmission lines":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_IS"]);
                    dsMyPower.Tables["Power_I"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_I"].AcceptChanges();
                    break;
                case "Upload Pre Commissioning Test Report":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_HS"]);
                    dsMyPower.Tables["Power_H"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_H"].AcceptChanges();
                    break;
                case "Upload Generators Test Reports with Fuel":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_GS"]);
                    dsMyPower.Tables["Power_G"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_G"].AcceptChanges();
                    break;
                case "Upload Lightning Arrestor Test Reports":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_FS"]);
                    dsMyPower.Tables["Power_F"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_F"].AcceptChanges();
                    break;

                case "Upload AB Switch / Isolator Test Report":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_ES"]);
                    dsMyPower.Tables["Power_E"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_E"].AcceptChanges();
                    break;

                case "Upload Transformer Test Certificates":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_CS"]);
                    dsMyPower.Tables["Power_C"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_C"].AcceptChanges();
                    break;
                case "Upload Circuit Breaker/Load Break Switch Test Reports":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_BS"]);
                    dsMyPower.Tables["Power_B"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_B"].AcceptChanges();
                    break;
                case "Upload Load Particulars":
                    dsMyPower.Tables.Add((DataTable)ViewState["Power_AS"]);
                    dsMyPower.Tables["Power_A"].Rows[parameter].Delete();
                    dsMyPower.Tables["Power_A"].AcceptChanges();
                    break;
            }
            return dsMyPower;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void txtdrawingno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CEIGCFOService.validInstallationData installationvo = new CEIGCFOService.validInstallationData();
            CEIGCFOService.checkInstallation checkvo = new CEIGCFOService.checkInstallation();
            checkvo.fileNumber = txtdrawingno.Text.Trim();
            installationvo = ceigtest.installationCheck(checkvo);
            if (installationvo.result == "SUCCESS")
            {
                txtaggregatecapacity.Text = installationvo.atc;
                txtConnectedAlreadyInstalled.Text = installationvo.cliAlreadyInstalled;
                txtConnectProposed.Text = installationvo.cliProposed;
                txtConnectTotal.Text = installationvo.cliTotal;
                txtKVAAlreadyInstalled.Text = installationvo.cmdAlreadyInstalled;
                txtKVAProposed.Text = installationvo.cmdProposed;
                txtKVATotal.Text = installationvo.cmdTotal;
                //  installationvo.fileNumber = "";
                ddlregulation.SelectedValue = installationvo.regulationSlno;
                if (installationvo.isVoltagePlant == "V")
                {
                    ddlvoltage.SelectedValue = installationvo.voltageSlno;
                }
                if (installationvo.isVoltagePlant == "P")
                {
                    ddlplant.SelectedValue = installationvo.plantSlno;
                }

                txtVoltage.Text = installationvo.voltageSlno;
                txtConnectProposed_TextChanged(sender, e);
                txtKVAProposed_TextChanged(sender, e);
            }
            else
            {
                txtdrawingno.Text = "";
                string message = "alert('please enter correct Drawing Approval Number')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }


        }
        catch (Exception ex)
        {
        }
    }
}

