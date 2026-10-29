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
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
            }


            if (!IsPostBack)
            {
                // TxtBuilt_up_Area.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                DataSet dsch = new DataSet();
                dsch = Gen.GetEnterPreneurdatabyQue1(Session["Applid"].ToString());

                if (dsch.Tables[0].Rows.Count > 0)
                {

                    if (dsch.Tables[0].Rows[0]["PolCatogory"].ToString() == "2")
                    {
                        trc5form.Visible = true;
                        trEmpUpload.Visible = true;
                        trc5Upload.Visible = true;
                    }
                    else
                    {
                        trc5form.Visible = false;
                    }
                }

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

                if (dsver != null && dsver.Tables.Count > 0 && dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                    }

                }
                //else
                //{
                //    Response.Redirect("frmLabourDetails_New.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                //}


            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();

                dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "1");

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
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
                    FillDetails();
                    FillDetailsAttachments();
                }

            }


            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }

            if (gvCertificate.Rows.Count == 0)
            {
                txtwaste.ReadOnly = false;
                txtcatagory.ReadOnly = false;               
                txtQntGenerated.ReadOnly = false;                
                txtstorage.ReadOnly = false;
                txtdisposal.ReadOnly = false;
            }
        }
        catch (Exception ex)
        {
            //response.write(ex);
            //throw (ex);
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

            if (trEmpUpload.Visible == true)
            {
                if (lblc5Form.Text == "" || lblEmpDoc.Text == "")
                {
                    lblmsg0.Text = "<font color=red> Please upload C5 and EMP</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    return;
                    BtnSave1.Enabled = false;
                }

            }



            DataSet ds = new DataSet();

            ds = Gen.GetdataofPCBenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                int i = Gen.insertPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());

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
                int i = Gen.insertPCBDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());

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
                int i = Gen.insertPCBDetails(ds.Tables[0].Rows[0]["intCFEPCBid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());

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

                int i = Gen.insertPCBDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), txtProcess.Text, txtwashing.Text, txtboiler.Text, txtcooling.Text, txtdomestic.Text, txttotal.Text, TxtCapacity.Text, Txtfuel.Text, TxtFuelstorage.Text, Txtheight.Text, TxtDiameter.Text, txtAirpollution.Text, Txtemission.Text, TxtQuantity.Text, TxtcontrolEquipement.Text, ddlproject.SelectedValue.ToString(), Session["uid"].ToString());

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

                lblmsg0.Text = "<font color=red> Please upload C5 and EMP</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;

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

    protected void btnEmpDoc_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");
        string text = fupEmpDoc.FileName.ToString();


        General t1 = new General();
        //  string text = fupEmpDoc.PostedFile.FileName.ToString();

        if ((fupEmpDoc.PostedFile != null) && (fupEmpDoc.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupEmpDoc.PostedFile.FileName);
            try
            {

                string[] fileType = fupEmpDoc.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\Document");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    sFileName = "EMP" + "." + fileType[i - 1].ToUpper().Trim();


                    fupEmpDoc.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    int result = 0;
                    gvCertificate.Visible = true;


                    AddDataToTableCeertificate("", "", sFileName, (DataTable)Session["CertificateTb"]);

                    //  this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                    //   this.gvCertificate.DataBind();
                    //   result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "EMP", "b", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblEmpDoc.Text = fupEmpDoc.FileName;
                        BtnSave1.Enabled = true;

                        lblEmpDoc.Visible = true;
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
            catch (Exception ex)//in case of an error
            {
                throw ex;
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
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


    private void AddDataToTableCeertificate(string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb");

            //  Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            Row["Manf_ItemName"] = Manf_ItemName;
            //Row["Manf_Item_Quantity"] = Manf_Item_Quantity;
            Row["Manf_Item_Quantity_In"] = Manf_Item_Quantity_In;
            //    Row["Created_by"] = Session["uid"].ToString().Trim();
            //   Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }

    protected void btnC5Form_Click(object sender, EventArgs e)
    {
        string newPath = "";

        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = Server.MapPath("~\\Attachments");
        string text = fupc5Form.FileName.ToString();


        General t1 = new General();
        //  string text = fupEmpDoc.PostedFile.FileName.ToString();

        if ((fupc5Form.PostedFile != null) && (fupc5Form.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(fupc5Form.PostedFile.FileName);
            try
            {

                string[] fileType = fupc5Form.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\Document");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    sFileName = "C5" + "." + fileType[i - 1].ToUpper().Trim();


                    fupc5Form.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    int result = 0;
                    gvCertificate.Visible = true;


                    AddDataToTableCeertificate("", "", sFileName, (DataTable)Session["CertificateTb"]);

                    //  this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb"]).DefaultView;
                    //   this.gvCertificate.DataBind();
                    //   result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    result = t1.InsertImagedata(Session["Applid"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "C5", "b", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblc5Form.Text = fupc5Form.FileName;
                        lblc5Form.Visible = true;
                        success.Visible = true;
                        Failure.Visible = false;
                        BtnSave1.Enabled = true;
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
            catch (Exception ex)//in case of an error
            {
                throw ex;
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }

    // attachments binding
    void FillDetailsAttachments()
    {
        // hdfFlagID.Value = "1000";
        DataSet ds = new DataSet();

        try
        {
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString()); // hdfFlagID0.Value.ToString()

            ds = Gen.ViewAttachmetsData(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                int c = ds.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = ds.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (sen.Contains("C5"))
                    {
                        hlc5Form.NavigateUrl = sen;
                        hlc5Form.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblc5Form.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("EMP"))
                    {
                        hlEmpDoc.NavigateUrl = sen;
                        hlEmpDoc.Text = ds.Tables[0].Rows[i][1].ToString();
                        lblEmpDoc.Text = ds.Tables[0].Rows[i][1].ToString();
                        //HyperLink2.NavigateUrl = sen;
                        //HyperLink2.Text = ds.Tables[0].Rows[i][1].ToString();
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


}
