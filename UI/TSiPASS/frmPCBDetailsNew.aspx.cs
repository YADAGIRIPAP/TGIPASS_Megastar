using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmPCBDetailsNew : System.Web.UI.Page
{
    PCBClass objPCB = new PCBClass();

    DataTable dt = new DataTable();
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    //DataRow dtrdr;
    //DataTable myDtNewRecdr = new DataTable();

    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            Response.Redirect("~/Index.aspx");

        }


        if (!IsPostBack)
        {
            // TxtBuilt_up_Area.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                if (dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != null && dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString() != "")
                {
                    ViewState["LabourActId"] = dscheck.Tables[0].Rows[0]["LabourAct_Id"].ToString();
                }
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();

                if (dscheck.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim() != "")
                {
                    string valuselected = "";
                    if (dscheck.Tables[0].Rows[0]["Gen_Reqired"].ToString().Trim() == "Y")
                    {
                        valuselected = "1";
                    }
                    else
                    {
                        valuselected = "2";
                    }

                    ddlproject.SelectedValue = ddlproject.Items.FindByValue(valuselected).Value;
                    // ddlproject.Enabled = false;
                    // ddlproject_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque7(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
                }

            }


        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "1");

            if (dsnew.Tables[0].Rows.Count > 0)
            {




            }
            else
            {


                //if (Request.QueryString[1].ToString() == "N")
                //{


                //    Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                //}

                //else
                //{

                //    Response.Redirect("frmWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                //}
                if (Request.QueryString[1].ToString() == "N")
                {
                    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    Response.Redirect("frmWaterDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                }
            }
        }

        if (!IsPostBack)
        {

            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb4"] = dtMyTableCertificate;

        }


        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                BindPresentLandPCB(); //lavanya pcb
                BindLocationPCB();//lavanya pcb
                //GetFeaturesPCB();
                BindDisposalPointsPCB();//lavanya pcb
                gvFeatures20Km5Km.DataSource = BindFeaturesGridAdd();
                gvFeatures20Km5Km.DataBind();

                gvByProductDetails.DataSource = BindByproductGridAdd();
                gvByProductDetails.DataBind();
                BindDischargePurposePCB(ddlPurposeDischargeWater);
                BindFinalDischargePCB(ddlModeofFinalDischarge);
                FillDetails();

            }

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
                }
            }
        }
    }

    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave1.Text == "Save")
        {

            DataSet ds = new DataSet();

            ds = Gen.GetdataofPCBenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                //
                int i = SaveNewPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim());
                int k = Gen.DeletebyPCBdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb4"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetailsPCB(myDtNewRecdr);

                    //Session.Remove("CertificateTb4");

                    //gvCertificate.DataSource = null;
                    //gvCertificate.DataBind();

                }


                if (i != 999)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    // clear();
                }
                else
                {
                    lblmsg0.Text = "Already Exist. ";
                    success.Visible = false;
                    Failure.Visible = true;
                }
            }
            else
            {
                // int i = Gen.insertPCBDetailsNew("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());
                int i = SaveNewPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim());

                int k = Gen.DeletebyPCBdataid(hdfFlagID0.Value.ToString());
                if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb4"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetailsPCB(myDtNewRecdr);
                    //Session.Remove("CertificateTb4");

                    //gvCertificate.DataSource = null;
                    //gvCertificate.DataBind();

                }


                if (i != 999)
                {

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    //clear();
                }
                else
                {
                    lblmsg0.Text = "Already Exist. ";
                    success.Visible = false;
                    Failure.Visible = true;
                }

            }

        }


    }


    public void CalculatationEnterprisePrjCost()
    {
        //if (ddlSector_Ent.SelectedIndex != 0)
        //{
        if (txtProcess.Text.Trim() == "")
        {
            txtProcess.Text = "0";
        }

        if (txtwashing.Text.Trim() == "")
        {
            txtwashing.Text = "0";
        }

        if (txtboiler.Text.Trim() == "")
        {
            txtboiler.Text = "0";
        }

        if (txtcooling.Text.Trim() == "")
        {
            txtcooling.Text = "0";
        }

        if (txtdomestic.Text.Trim() == "")
        {
            txtdomestic.Text = "0";
        }

        txttotal.Text = Convert.ToString((Convert.ToDecimal(txtProcess.Text) + Convert.ToDecimal(txtboiler.Text) + Convert.ToDecimal(txtwashing.Text) + Convert.ToDecimal(txtcooling.Text) + Convert.ToDecimal(txtdomestic.Text)));
        lblmsg.Text = "";
        //}
        //else
        //{
        //    TxtTot_PrjCost.Text = "0";
        //    lblmsg.Text = "Please Select Sector of Enterprise";
        //}
    }

    void clear()
    {

        txtProcess.Text = ""; txtwashing.Text = ""; txtboiler.Text = ""; txtcooling.Text = ""; txtdomestic.Text = ""; txttotal.Text = ""; TxtCapacity.Text = ""; Txtfuel.Text = ""; TxtFuelstorage.Text = "";
        Txtheight.Text = ""; TxtDiameter.Text = ""; txtAirpollution.Text = ""; Txtemission.Text = ""; TxtQuantity.Text = ""; TxtcontrolEquipement.Text = ""; ddlproject.SelectedIndex = 0;


    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {

        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }


        if (BtnDelete.Text == "Next")
        {
            if (gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Solid and hazardous waste and Click add new Button</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            DataSet ds = new DataSet();

            ds = Gen.GetdataofPCBenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                //int i = Gen.insertPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());
                int i = SaveNewPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim());
                int k = Gen.DeletebyPCBdataid(hdfFlagID0.Value.ToString());
                if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb4"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetailsPCB(myDtNewRecdr);

                }

                ds = Gen.getPCBDetails(hdfFlagID0.Value.ToString());
                string WaterSourcedtls = "", WaterConsumptionDtls = "";
                if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    WaterSourcedtls = "Y";
                }
                if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    WaterConsumptionDtls = "Y";
                }
                if (WaterConsumptionDtls != "Y" || WaterSourcedtls != "Y")
                {
                    if (WaterConsumptionDtls != "Y")
                    {
                        lblmsg0.Text = "Please Enter Water Consumption Details" + "<br/>";
                    }
                    if (WaterSourcedtls != "Y")
                    {
                        lblmsg0.Text += "Please Enter Water Source Details";
                    }
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                }
                if (i != 999)
                {
                    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }
                else
                {
                    lblmsg0.Text = "Already Exist. ";
                    success.Visible = false;
                    Failure.Visible = true;
                }

            }

            else
            {

                // int i = Gen.insertPCBDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());
                int i = SaveNewPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim());
                int k = Gen.DeletebyPCBdataid(hdfFlagID0.Value.ToString());

                if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
                {

                    for (int m = 0; m < ((DataTable)Session["CertificateTb4"]).Rows.Count; m++)
                    {
                        if (((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBBulkid"].ToString().Trim() == "0")
                        {
                            //((DataTable)Session["tmpdrDataTable"]).Rows[m]["intCPBid"] = Convert.ToString(i);
                            ((DataTable)Session["CertificateTb4"]).Rows[m]["intCFEPCBid"] = Convert.ToString(i);
                        }
                    }

                    GetNewRectoInsertdr();
                    int statuspr = Gen.bulkInsertEduDetailsPCB(myDtNewRecdr);

                }


                if (i != 999)
                {
                    Response.Redirect("frmAttachmentDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                }
                else
                {
                    lblmsg0.Text = "Already Exist. ";
                    success.Visible = false;
                    Failure.Visible = true;
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
            ds = Gen.getPCBDetails(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFEPCBid"].ToString();
                txtProcess.Text = ds.Tables[0].Rows[0]["PCB_Water"].ToString();
                txtwashing.Text = ds.Tables[0].Rows[0]["PCB_Washing"].ToString();
                txtboiler.Text = ds.Tables[0].Rows[0]["PCB_BoilerBlowDown"].ToString();
                txtcooling.Text = ds.Tables[0].Rows[0]["PCB_CollingTower"].ToString();
                txtdomestic.Text = ds.Tables[0].Rows[0]["PCB_Domastic"].ToString();
                txttotal.Text = ds.Tables[0].Rows[0]["PCB_Total"].ToString();
                TxtCapacity.Text = ds.Tables[0].Rows[0]["PCB_AP_Capcity"].ToString();
                Txtfuel.Text = ds.Tables[0].Rows[0]["PCB_FuelConsumption"].ToString();
                TxtFuelstorage.Text = ds.Tables[0].Rows[0]["PCB_FuelStorge"].ToString();
                Txtheight.Text = ds.Tables[0].Rows[0]["PCB_StackHight"].ToString();
                TxtDiameter.Text = ds.Tables[0].Rows[0]["PCB_StackDaimeter"].ToString();
                txtAirpollution.Text = ds.Tables[0].Rows[0]["PCB_AirPolution_Equipment"].ToString();
                Txtemission.Text = ds.Tables[0].Rows[0]["PCB_EmiCharcter"].ToString();
                TxtQuantity.Text = ds.Tables[0].Rows[0]["PCB_Qunt_Emission"].ToString();
                TxtcontrolEquipement.Text = ds.Tables[0].Rows[0]["PCB_ControlEqu"].ToString();
                ddlproject.SelectedValue = ddlproject.Items.FindByValue(ds.Tables[0].Rows[0]["PCB_IsPrjRequired"].ToString().Trim()).Value;

                DataSet dsTrade = Gen.getPCBbulkdetails(hdfFlagID0.Value.ToString());
                if (dsTrade.Tables[0].Rows.Count > 0)
                {
                    DataTableReader rdt = new DataTableReader(dsTrade.Tables[0]);
                    IDataReader readert = rdt;

                    //ddlTrade.SelectedIndex = 0;


                    //Session["tmpDataTable"] = dsTrade.Tables[0];

                    ((DataTable)Session["CertificateTb4"]).Clear();
                    ((DataTable)Session["CertificateTb4"]).Load(readert);
                    gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]);
                    gvCertificate.DataBind();
                    //  gvCertificate.Columns[0].Visible = true;
                    //gvCertificate.Columns[1].Visible = false;


                }
                else
                {
                    gvCertificate.DataSource = null;
                    gvCertificate.DataBind();
                }


                //if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                //{
                txtFaxNo.Text = ds.Tables[0].Rows[0]["FaxNo"].ToString(); //lavanya pcb
                if (ds.Tables[0].Rows[0]["ForeignCollab"].ToString() != "")
                    ddlForeignCollab0.SelectedValue = ds.Tables[0].Rows[0]["ForeignCollab"].ToString();  //lavanya pcb

                ddlPresentUseofLand.SelectedValue = ds.Tables[0].Rows[0]["UseofLand"].ToString();
                ddlLocation.SelectedValue = ds.Tables[0].Rows[0]["Location"].ToString();
                txtGreenBelt.Text = ds.Tables[0].Rows[0]["GreenBeltArea"].ToString();
                rbtnTownship.SelectedValue = ds.Tables[0].Rows[0]["TownShipProposal"].ToString();
                txtAreaAllocation.Text = ds.Tables[0].Rows[0]["TownArea_Alloc"].ToString();
                txtDistanceFromSite.Text = ds.Tables[0].Rows[0]["DistanceFromSite"].ToString();
                txtPopulationTown.Text = ds.Tables[0].Rows[0]["Emp_Population"].ToString();
                txtWaterConsumptionTown.Text = ds.Tables[0].Rows[0]["WaterSupply"].ToString();
                ddlDisposalPoint.SelectedValue = ds.Tables[0].Rows[0]["DisposalPoint"].ToString();
                rbtnLstSewerSys.SelectedValue = ds.Tables[0].Rows[0]["SewerSys"].ToString();
                rbtnLstSewage.SelectedValue = ds.Tables[0].Rows[0]["Sewage_TreatMent"].ToString();
                txtTotalEmpsPremises.Text = ds.Tables[0].Rows[0]["TotalEmp_Premises"].ToString();
                rbtnLstProhibited.SelectedValue = ds.Tables[0].Rows[0]["Prohibitted_Area"].ToString();
                rbtnLstSourceofEnergy.SelectedValue = ds.Tables[0].Rows[0]["Source_Energy"].ToString();
                txtInplanGenType.Text = ds.Tables[0].Rows[0]["Inplant_Generationtype"].ToString();
                rbtnTownship_SelectedIndexChanged(this, EventArgs.Empty);
                rbtnLstSourceofEnergy_SelectedIndexChanged(this, EventArgs.Empty);
                //   ,,
                ddlModeofFinalDischarge.SelectedValue = ds.Tables[0].Rows[0]["ModeofFinalDischarge"].ToString();
                ddlPurposeDischargeWater.SelectedValue = ds.Tables[0].Rows[0]["DischargeWasteWater"].ToString();
                rbntLstPretreatment.SelectedValue = ds.Tables[0].Rows[0]["PretreatmentNecessary"].ToString();

                rbtnLstNoise.SelectedValue = ds.Tables[0].Rows[0]["NoisePollution"].ToString();
                rbtnLstOdourProblem.SelectedValue = ds.Tables[0].Rows[0]["OdourPRoblem"].ToString();
                rbtnLstThermal.SelectedValue = ds.Tables[0].Rows[0]["ThermalPollution"].ToString();

                totPolutionMonitoringCost.Text = ds.Tables[0].Rows[0]["PolMonitoring_Cost"].ToString();
                totPolutionControlCost.Text = ds.Tables[0].Rows[0]["PolControl_Cost"].ToString();
                txtRecurringCost.Text = ds.Tables[0].Rows[0]["Recurring_Cost"].ToString();
                // }
            }
            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                ViewState["dtFeatureDtls"] = ds.Tables[2];
                gvFeatures20Km5Km.DataSource = ds.Tables[2];
                gvFeatures20Km5Km.DataBind();
            }
            if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                ViewState["dtByProductDetails"]= ds.Tables[3];
                gvByProductDetails.DataSource = ds.Tables[3];
                gvByProductDetails.DataBind();
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

    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb4");

        dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("intQuessionaireid", typeof(string));
        dtMyTable.Columns.Add("intCFEEnterpid", typeof(string));
        dtMyTable.Columns.Add("intCFEPCBid", typeof(string));

        dtMyTable.Columns.Add("NameofWaste", typeof(string));
        dtMyTable.Columns.Add("Category", typeof(string));
        dtMyTable.Columns.Add("Qunt_Generated", typeof(string));
        dtMyTable.Columns.Add("Storage_Treatment", typeof(string));
        dtMyTable.Columns.Add("Disposal", typeof(string));
        //dtMyTable.Columns.Add("ToDate", typeof(string));
        //dtMyTable.Columns.Add("ExpYears", typeof(string));


        dtMyTable.Columns.Add("created_by", typeof(string));

        dtMyTable.Columns.Add("intCFEPCBBulkid", typeof(string));


        return dtMyTable;
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmPCBDetails.aspx");
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

        myDtNewRecdr = (DataTable)Session["CertificateTb4"];
        DataView dvdr = new DataView(myDtNewRecdr);
        // dvdr.RowFilter = "new = 0";
        myDtNewRecdr = dvdr.ToTable();

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        txtwaste.Text = "";
        txtcatagory.Text = "";
        txtQntGenerated.Text = "";
        txtstorage.Text = "";
        txtdisposal.Text = "";


    }

    private void AddDataToTableCeertificate(string intQuessionaireid, string intCFEEnterpid, string NameofWaste, string Category, string Qunt_Generated, string Storage_Treatment, string Disposal, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb4");



            Row["new"] = "0";
            Row["intCFEPCBid"] = "0";
            Row["intQuessionaireid"] = intQuessionaireid;
            Row["intCFEEnterpid"] = intCFEEnterpid;

            Row["NameofWaste"] = NameofWaste;

            Row["Category"] = Category;
            Row["Qunt_Generated"] = Qunt_Generated;
            Row["Storage_Treatment"] = Storage_Treatment;
            Row["Disposal"] = Disposal;
            //Row["Forest_Pole"] = Forest_Pole;
            //Row["Est_FireWood"] = Est_FireWood;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intCFEPCBBulkid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtwaste.Text, txtcatagory.Text, txtQntGenerated.Text, txtstorage.Text, txtdisposal.Text, (DataTable)Session["CertificateTb4"]);


                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;

                lblmsg.Text = "";
                txtwaste.Text = "";
                txtcatagory.Text = "";
                txtQntGenerated.Text = "";
                txtstorage.Text = "";
                txtdisposal.Text = "";
                //}
            }
            else
            //  if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
            {

                //gvCertificate.Visible = true;


                //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                //siva as on 10-08-2103
                // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
                AddDataToTableCeertificate(Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtwaste.Text, txtcatagory.Text, txtQntGenerated.Text, txtstorage.Text, txtdisposal.Text, (DataTable)Session["CertificateTb4"]);
                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                this.gvCertificate.DataBind();
                gvCertificate.Columns[0].Visible = false;
                //clear_child_TOT();
                lblmsg.Text = "";
                lblmsg.Text = "";
                txtwaste.Text = "";
                txtcatagory.Text = "";
                txtQntGenerated.Text = "";
                txtstorage.Text = "";
                txtdisposal.Text = "";
                //}
            }
        }

        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;

    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    //if (BtnSave1.Text == "Save")
        //    //{
        //    ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);
        //    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]);
        //    this.gvCertificate.DataBind();
        //    //}
        //    //int i = Gen.deletePCBbilkdata();






        //}
        //catch (Exception ex)
        //{
        //    //  lblresult.Text = ex.ToString();

        //}
        //finally
        //{


        //}






        try
        {
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                //((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);
                //this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]);
                //this.gvCertificate.DataBind();


                ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                this.gvCertificate.DataBind();
                //ddlSector.SelectedIndex = 0;
                //ddlTrade.SelectedIndex = 0;
                //btnAddTrdmpNew.Visible = true;
                //BtnTradeUpdate.Visible = false;
            }
            else
            {
                if (hdfFlagID0.Value.Trim() != "")
                {



                    //DataSet dsbat = new DataSet();
                    //dsbat = gen.batchexistswithtrngtrade(trainertradesname, hdfID.Value.ToString());
                    //if (dsbat.Tables[0].Rows[0][0].ToString() == "0")
                    //{
                    //    gen.deleteTCTradeTrainer(trainertradesname, tradestrainneid, hdfID.Value.ToString());
                    //}
                    //else
                    //{
                    //   lblresult.Text = "Trade already assigned to a batch";
                    //    return;
                    //}

                    try
                    {
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intCFEPCBBulkid"].ToString();
                        //string traineeids = gvTradeMapping.DataKeys[e.RowIndex].Values["intTraineeID"].ToString();
                        DataSet dsna = new DataSet();
                        //dsna = Gen.deleteGroupSavingData1(traineetradesnames);
                        //if (dsna.Tables[0].Rows.Count > 0)
                        //{

                        //    lblmsg.Text = "This Trainee is Already alloted to Batch,So you can't delete this trainee trade";
                        //}
                        //else
                        //{


                        int i1 = Gen.deleteGroupSavingData4(traineetradesnames);

                        ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    { }






                }
            }
            // Added by Srikanth on 20-08-2013 for Page Breakup
            //hdnfocus.Value = txtOrganisation.ClientID;
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {
        }
    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddlproject_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnDelete0_Click(object sender, EventArgs e)
    {

        Response.Redirect("frmWaterDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");

    }
    protected void txtProcess_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtwashing_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtboiler_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtcooling_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    protected void txtdomestic_TextChanged(object sender, EventArgs e)
    {
        CalculatationEnterprisePrjCost();
    }
    private void BindDisposalPointsPCB()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlDisposalPoint.Items.Clear();
            dsd = Gen.GetDisposalPointsPCB();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlDisposalPoint.DataSource = dsd.Tables[0];
                ddlDisposalPoint.DataValueField = "DisposalPointId";
                ddlDisposalPoint.DataTextField = "DisposalPoint_Desc";
                ddlDisposalPoint.DataBind();
            }
            ddlDisposalPoint.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    private void BindLocationPCB()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlLocation.Items.Clear();
            dsd = Gen.GetLocationPCB();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlLocation.DataSource = dsd.Tables[0];
                ddlLocation.DataValueField = "LocationId";
                ddlLocation.DataTextField = "Location_Desc";
                ddlLocation.DataBind();
            }
            ddlLocation.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }

    private void BindPresentLandPCB()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlPresentUseofLand.Items.Clear();
            dsd = Gen.GetPresentLandPCB();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlPresentUseofLand.DataSource = dsd.Tables[0];
                ddlPresentUseofLand.DataValueField = "PresentLandId";
                ddlPresentUseofLand.DataTextField = "PresentLand_Desc";
                ddlPresentUseofLand.DataBind();
            }
            ddlPresentUseofLand.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg";
        }
    }
    protected void gvFeatures20Km5Km_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindFeaturesGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvFeatures20Km5Km.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvrow = gvFeatures20Km5Km.Rows[i];

                    DropDownList ddlFeature = (DropDownList)gvrow.FindControl("ddlFeature");
                    TextBox txtFeatureName = (TextBox)gvrow.FindControl("txtFeatureName");
                    TextBox txtDistance = (TextBox)gvrow.FindControl("txtDistance");

                    arraydata[0] = ddlFeature.SelectedValue;
                    arraydata[1] = txtFeatureName.Text;
                    arraydata[2] = txtDistance.Text;

                    if (txtFeatureName.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter Feature Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtFeatureDtls"] = dt;
                    gvFeatures20Km5Km.DataSource = dt;
                    gvFeatures20Km5Km.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvFeatures20Km5Km.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindFeaturesGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvrow = gvFeatures20Km5Km.Rows[i];
                            DropDownList ddlFeature = (DropDownList)gvrow.FindControl("ddlFeature");
                            TextBox txtFeatureName = (TextBox)gvrow.FindControl("txtFeatureName");
                            TextBox txtDistance = (TextBox)gvrow.FindControl("txtDistance");

                            arraydata[0] = ddlFeature.SelectedValue;
                            arraydata[1] = txtFeatureName.Text;
                            arraydata[2] = txtDistance.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtFeatureDtls"] = dt;
                    gvFeatures20Km5Km.DataSource = dt;
                    gvFeatures20Km5Km.DataBind();
                }
                else
                {
                    dt = BindFeaturesGridAdd();
                    ViewState["dtFeatureDtls"] = dt;
                    gvFeatures20Km5Km.DataSource = dt;
                    gvFeatures20Km5Km.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void gvFeatures20Km5Km_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvrow = e.Row;

                DataTable dt = (DataTable)ViewState["dtFeatureDtls"];
                DropDownList ddlFeature = (DropDownList)gvrow.FindControl("ddlFeature");
                TextBox txtFeatureName = (TextBox)gvrow.FindControl("txtFeatureName");
                TextBox txtDistance = (TextBox)gvrow.FindControl("txtDistance");
                BindFeatures(ddlFeature);

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlFeature.SelectedValue = dt.Rows[e.Row.RowIndex]["FeatureCd"].ToString();
                        txtFeatureName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        txtDistance.Text = dt.Rows[e.Row.RowIndex]["Distance"].ToString();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    private void BindFeatures(DropDownList ddlFeature)
    {
        try
        {
            ddlFeature.Items.Clear();
            DataSet dsFeatures = new DataSet();
            dsFeatures = objPCB.GetFeaturesPCB();
            if (dsFeatures != null && dsFeatures.Tables.Count > 0 && dsFeatures.Tables[0].Rows.Count > 0)
            {
                ddlFeature.DataSource = dsFeatures.Tables[0];
                ddlFeature.DataTextField = "Feature_Desc";
                ddlFeature.DataValueField = "FeatureId";
                ddlFeature.DataBind();
            }
            ddlFeature.Items.Insert(0, "--Select--");
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    protected void rbtnTownship_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtnTownship.SelectedValue == "Y")
                trTownship.Visible = true;
            else
                trTownship.Visible = false;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    protected void rbtnLstSourceofEnergy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbtnLstSourceofEnergy.SelectedValue == "I")
                trInplantGen.Visible = true;
            else
                trInplantGen.Visible = false;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    protected void gvByProductDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvrow = e.Row;

                DataTable dt = (DataTable)ViewState["dtByProductDetails"];
                DropDownList ddlByProductUnits = (DropDownList)gvrow.FindControl("ddlByProductUnits");
                TextBox txtByProductName = (TextBox)gvrow.FindControl("txtByProductName");
                TextBox txtByProductCapacity = (TextBox)gvrow.FindControl("txtByProductCapacity");
                BindByProductUnits(ddlByProductUnits);
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        ddlByProductUnits.SelectedValue = dt.Rows[e.Row.RowIndex]["Units"].ToString();
                        txtByProductName.Text = dt.Rows[e.Row.RowIndex]["Name"].ToString();
                        txtByProductCapacity.Text = dt.Rows[e.Row.RowIndex]["Capacity"].ToString();

                    }
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }

    private void BindByProductUnits(DropDownList ddlByProductUnits)
    {
        DataSet dsUnits = new DataSet();
        dsUnits = objPCB.GETUnitsPCB();
        ddlByProductUnits.Items.Clear();
        if (dsUnits != null && dsUnits.Tables.Count > 0 && dsUnits.Tables[0].Rows.Count > 0)
        {
            ddlByProductUnits.DataSource = dsUnits.Tables[0];
            ddlByProductUnits.DataTextField = "Unit_Desc";
            ddlByProductUnits.DataValueField = "UnitID";
            ddlByProductUnits.DataBind();
        }
        ddlByProductUnits.Items.Insert(0, "--Select--");
    }
    protected void gvByProductDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindByproductGridAdd();
                String[] arraydata = new String[3];

                int gvrcnt = gvByProductDetails.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvrow = gvByProductDetails.Rows[i];
                    DropDownList ddlByProductUnits = (DropDownList)gvrow.FindControl("ddlByProductUnits");
                    TextBox txtByProductName = (TextBox)gvrow.FindControl("txtByProductName");
                    TextBox txtByProductCapacity = (TextBox)gvrow.FindControl("txtByProductCapacity");
                    arraydata[2] = ddlByProductUnits.SelectedValue;
                    arraydata[0] = txtByProductName.Text;
                    arraydata[1] = txtByProductCapacity.Text;
                    if (ddlByProductUnits.SelectedValue == "0" || txtByProductName.Text.Trim() == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblmsg.Text = "Please enter By Product Details";
                        lblmsg.CssClass = "errormsg"; Failure.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }

                if (valid == 0)
                {
                    ViewState["dtByProductDetails"] = dt;
                    gvByProductDetails.DataSource = dt;
                    gvByProductDetails.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvByProductDetails.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindByproductGridAdd();
                    String[] arraydata = new String[3];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvrow = gvByProductDetails.Rows[i];
                            DropDownList ddlByProductUnits = (DropDownList)gvrow.FindControl("ddlByProductUnits");
                            TextBox txtByProductName = (TextBox)gvrow.FindControl("txtByProductName");
                            TextBox txtByProductCapacity = (TextBox)gvrow.FindControl("txtByProductCapacity");
                            arraydata[2] = ddlByProductUnits.SelectedValue;
                            arraydata[0] = txtByProductName.Text;
                            arraydata[1] = txtByProductCapacity.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtByProductDetails"] = dt;
                    gvByProductDetails.DataSource = dt;
                    gvByProductDetails.DataBind();
                }
                else
                {
                    dt = BindByproductGridAdd();
                    ViewState["dtByProductDetails"] = dt;
                    gvByProductDetails.DataSource = dt;
                    gvByProductDetails.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.CssClass = "errormsg"; Failure.Visible = true;
        }
    }
    private DataTable BindFeaturesGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("FeatureCd");
        dt.Columns.Add("Name");
        dt.Columns.Add("Distance");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable BindByproductGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Name");
        dt.Columns.Add("Capacity");
        dt.Columns.Add("Units");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";

        dt.Rows.Add(dr);
        return dt;
    }
    private int SaveNewPCBDetails(string intCFEPCBid)
    {
        PCBDetailsVo pcbVo = new PCBDetailsVo();
        pcbVo.FaxNo = txtFaxNo.Text;
        pcbVo.ForeignCollab = ddlForeignCollab0.SelectedValue;
        pcbVo.UseofLand = ddlPresentUseofLand.SelectedValue;//.SelectedValue;
        pcbVo.Location = ddlLocation.SelectedValue;
        pcbVo.GreenBeltArea = txtGreenBelt.Text;
        pcbVo.TownShipProposal = rbtnTownship.SelectedValue;


        pcbVo.TownArea_Alloc = txtAreaAllocation.Text;
        pcbVo.DistanceFromSite = txtDistanceFromSite.Text;
        pcbVo.Emp_Population = txtPopulationTown.Text;
        pcbVo.WaterSupply = txtWaterConsumptionTown.Text;
        pcbVo.DisposalPoint = ddlDisposalPoint.SelectedValue;
        pcbVo.SewerSys = rbtnLstSewerSys.SelectedValue;
        pcbVo.Sewage_TreatMent = rbtnLstSewage.SelectedValue;
        pcbVo.TotalEmp_Premises = txtTotalEmpsPremises.Text;
        pcbVo.Prohibitted_Area = rbtnLstProhibited.SelectedValue;
        pcbVo.Source_Energy = rbtnLstSourceofEnergy.SelectedValue;

        pcbVo.Inplant_Generationtype = txtInplanGenType.Text;
        pcbVo.DischargeWasteWater = ddlPurposeDischargeWater.SelectedValue;
        pcbVo.ModeofFinalDischarge = ddlModeofFinalDischarge.SelectedValue;
        pcbVo.PretreatmentNecessary = rbntLstPretreatment.SelectedValue;
        pcbVo.NoisePollution = rbtnLstNoise.SelectedValue;
        pcbVo.OdourPRoblem = rbtnLstOdourProblem.SelectedValue;
        pcbVo.ThermalPollution = rbtnLstThermal.SelectedValue;

        pcbVo.PolMonitoring_Cost = totPolutionMonitoringCost.Text;
        pcbVo.PolControl_Cost = totPolutionControlCost.Text;
        pcbVo.Recurring_Cost = txtRecurringCost.Text;

        List<LandFeatures> lstFeatures = new List<LandFeatures>();
        foreach (GridViewRow gvrow in gvFeatures20Km5Km.Rows)
        {
            LandFeatures featuresvo = new LandFeatures();
            DropDownList ddlFeature = (DropDownList)gvrow.FindControl("ddlFeature");
            TextBox txtFeatureName = (TextBox)gvrow.FindControl("txtFeatureName");
            TextBox txtDistance = (TextBox)gvrow.FindControl("txtDistance");

            featuresvo.Feature = ddlFeature.SelectedValue;
            featuresvo.Name = txtFeatureName.Text;
            featuresvo.Distance = txtDistance.Text;
            if (txtDistance.Text.Trim() != "")
                lstFeatures.Add(featuresvo);
        }
        List<ByProduct> lstByproduct = new List<ByProduct>();
        foreach (GridViewRow gvrow in gvByProductDetails.Rows)
        {
            ByProduct productvo = new ByProduct();
            DropDownList ddlByProductUnits = (DropDownList)gvrow.FindControl("ddlByProductUnits");
            TextBox txtByProductName = (TextBox)gvrow.FindControl("txtByProductName");
            TextBox txtByProductCapacity = (TextBox)gvrow.FindControl("txtByProductCapacity");

            productvo.Capacity = txtByProductCapacity.Text;
            productvo.Name = txtByProductName.Text;
            productvo.Units = ddlByProductUnits.SelectedValue;
            if (txtByProductCapacity.Text.Trim() != "")
                lstByproduct.Add(productvo);
        }
        int i = Gen.insertPCBDetailsNew(intCFEPCBid, Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString(), pcbVo, lstFeatures, lstByproduct);
        return i;

    }
    private void BindDischargePurposePCB(DropDownList ddlDischargePurpose)
    {
        DataSet dsWasteWaterSource = new DataSet();
        dsWasteWaterSource = objPCB.GetDischargePurposePCB();
        if (dsWasteWaterSource != null && dsWasteWaterSource.Tables.Count > 0 && dsWasteWaterSource.Tables[0].Rows.Count > 0)
        {
            ddlDischargePurpose.DataSource = dsWasteWaterSource.Tables[0];
            ddlDischargePurpose.DataTextField = "DischargePurpose_Desc";
            ddlDischargePurpose.DataValueField = "DischargePurposeId";
            ddlDischargePurpose.DataBind();
        }

    }

    private void BindFinalDischargePCB(DropDownList ddlFinalDischargePCB)
    {
        DataSet dsWasteWaterSource = new DataSet();
        dsWasteWaterSource = objPCB.GETFinalDischargePCB();
        if (dsWasteWaterSource != null && dsWasteWaterSource.Tables.Count > 0 && dsWasteWaterSource.Tables[0].Rows.Count > 0)
        {
            ddlFinalDischargePCB.DataSource = dsWasteWaterSource.Tables[0];
            ddlFinalDischargePCB.DataTextField = "FinalDischarge_Desc";
            ddlFinalDischargePCB.DataValueField = "FinalDischargeId";
            ddlFinalDischargePCB.DataBind();
        }

    }
    protected void lbtnWCEffluent_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmWCEffulent.aspx?intApplicationId=" + hdfFlagID0.Value + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
    }
    protected void lbtnSolidWaste_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmSolidWastes.aspx?intApplicationId=" + hdfFlagID0.Value + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
    }
    protected void lbtnAirEmission_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", "window.open('frmAirEmission.aspx?intApplicationId=" + hdfFlagID0.Value + "','null','height=500,width=800,scrollbars=1,status=yes,toolbar=no,menubar=no,location=no');", true);
    }
}