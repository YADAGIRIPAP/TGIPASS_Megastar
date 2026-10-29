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

    static DataTable dtMyTable;

    DataRow dtr;
    static DataTable dtMyTablepr;
    static DataTable dtMyTableCertificate;

    DataRow dtrdr1;
    DataTable myDtNewRecdr1 = new DataTable();

    static DataTable dtMyTable1;

    DataRow dtr1;
    static DataTable dtMyTablepr1;
    static DataTable dtMyTableCertificate1;


    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session.Count <= 0)
        //{
        //    // Response.Redirect("../../frmUserLogin.aspx");
        //    Response.Redirect("~/Index.aspx");
        //}

        //if (!IsPostBack)
        //{
        //    DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);

        //    int year = DateTime.Now.Year - 5;

        //    for (int Y = year; Y <= DateTime.Now.Year; Y++)
        //    {

        //        ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
        //    }

        //    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        //    ddlMonth.SelectedIndex = DateTime.Now.Month;

        //    GetBanks();
        //    dtMyTableCertificate = createtablecrtificate();
        //    Session["CertificateTb2"] = dtMyTableCertificate;

        //    dtMyTableCertificate1 = createtablecrtificate1();
        //    Session["CertificateTb1"] = dtMyTableCertificate1;

        // //   FillDetails();
        //}

        //if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        //{
        //    Failure.Visible = false;
        //    success.Visible = false;
        //    FillDetails();
        //    //hdfFlagID.Value = "";
        //}

        if (!IsPostBack)
        {
            fillgrid();

            success.Visible = false;
            Failure.Visible = false;
        }
    }

    private void GetBanks()
    {
        //DataSet dsnew = new DataSet();

        //dsnew = Gen.GetBanks();
        //ddlBank.DataSource = dsnew.Tables[0];
        //ddlBank.DataTextField = "BankName";
        //ddlBank.DataValueField = "Id";
        //ddlBank.DataBind();
        //ddlBank.Items.Insert(0, "--Select--");
    }

    //protected DataTable createtablecrtificate()
    //{
        //dtMyTable = new DataTable("CertificateTb2");

        //dtMyTable.Columns.Add("new", typeof(string));
        //dtMyTable.Columns.Add("Beneficiary_Name", typeof(string));
        //dtMyTable.Columns.Add("Beneficiary_address", typeof(string));
        //dtMyTable.Columns.Add("Project_cost", typeof(string));
        //dtMyTable.Columns.Add("Amount_sanctioned", typeof(string));
        //dtMyTable.Columns.Add("Bank_Name", typeof(string));
        //dtMyTable.Columns.Add("Branch_Name", typeof(string));
        //dtMyTable.Columns.Add("Current_Status_of_the_Unit", typeof(string));
        //dtMyTable.Columns.Add("Remarks", typeof(string));
        ////dtMyTable.Columns.Add("Date_of_Sanction", typeof(string));

        //dtMyTable.Columns.Add("Created_by", typeof(string));
        //dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


        //return dtMyTable;
    //}

   // protected DataTable createtablecrtificate1()
    //{
        //dtMyTable1 = new DataTable("CertificateTb1");

        //dtMyTable1.Columns.Add("new", typeof(string));
        //dtMyTable1.Columns.Add("intQuessionaireCFOid", typeof(string));
        //dtMyTable1.Columns.Add("intCFOEnterpid", typeof(string));
        //dtMyTable1.Columns.Add("Raw_ItemName", typeof(string));
        //dtMyTable1.Columns.Add("Raw_Item_Quantity", typeof(string));
        //dtMyTable1.Columns.Add("Raw_Item_Quantity_In", typeof(string));
        //dtMyTable1.Columns.Add("Raw_Item_Quantity_Per", typeof(string));
        //dtMyTable1.Columns.Add("Created_by", typeof(string));
        //dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


        //return dtMyTable1;
    //}


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (BtnSave1.Text == "Save")
    //        {
    //            int i = Gen.insertPMEGPMUDRA(Session["uid"].ToString(), ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(), txtBeneficaryName.Text, txtbeneficiaryAddress.Text,
    //            txtProjectCost.Text, txtAmontScanctioned.Text, ddlBank.SelectedValue, txtBankBranchName.Text, ddlStatusOfLoan.SelectedValue, txtRemarks.Text, Session["uid"].ToString());
    //            if (i > 0)
    //            {

    //                lblmsg.Text = "Added Successfully..!";
    //                success.Visible = true;
    //                Failure.Visible = false;
    //                clear();
    //            }
    //        }
    //        if (BtnSave1.Text == "Update")
    //        {
    //            lblmsg.Text = "";

    //            int i = Gen.updatePMEGPMUDRA(Session["uid"].ToString(), ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(), txtBeneficaryName.Text, txtbeneficiaryAddress.Text,
    //            txtProjectCost.Text, txtAmontScanctioned.Text, ddlBank.SelectedValue, txtBankBranchName.Text, ddlStatusOfLoan.SelectedValue, txtRemarks.Text, Session["uid"].ToString(), hdfID.Value);
    //            if (i > 0)
    //            {

    //                lblmsg.Text = "Updated Successfully..!";
    //                success.Visible = true;
    //                Failure.Visible = false;
    //                clear();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }
    //}
    //void clear()
    //{

    //    txtBeneficaryName.Text = "";
    //    ddlBank.SelectedIndex = 0;
    //    ddlMonth.SelectedIndex = 0;
    //    ddlYear.SelectedIndex = 0;
    //    ddlStatusOfLoan.SelectedIndex = 0;
    //    // ddlintLineofActivity.SelectedIndex = 0;
    //    txtBankBranchName.Text = "";
    //    txtbeneficiaryAddress.Text = "";
    //    txtBankBranchName.Text = "";
    //    txtProjectCost.Text = "";
    //    txtRemarks.Text = "";
    //    txtAmontScanctioned.Text = "";






    //}



    //public void FillDetails()
    //{
    //    hdfFlagID.Value = "1";
    //    DataSet dsemp = new DataSet();

    //    dsemp = Gen.GetPMEGPandMUDRA(hdfID.Value.ToString());

    //    if (dsemp.Tables[0].Rows.Count > 0)
    //    {
    //        txtBeneficaryName.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
    //        txtbeneficiaryAddress.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
    //        txtBankBranchName.Text = dsemp.Tables[0].Rows[0]["BranchName"].ToString();
    //        txtProjectCost.Text = dsemp.Tables[0].Rows[0]["ProjectCost"].ToString();
    //        txtRemarks.Text = dsemp.Tables[0].Rows[0]["Remarks"].ToString();
    //        txtAmontScanctioned.Text = dsemp.Tables[0].Rows[0]["AmountSanctioned"].ToString();

    //        ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Month"].ToString().Trim()).Value;
    //        ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

    //        GetBanks();
    //        if (dsemp.Tables[0].Rows[0]["intBankid"].ToString().Trim() != "")
    //        {
    //            ddlBank.SelectedValue = ddlBank.Items.FindByValue(dsemp.Tables[0].Rows[0]["intBankid"].ToString()).Value;
    //        }

    //        if (dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString().Trim() != "")
    //        {
    //            ddlStatusOfLoan.SelectedValue = ddlStatusOfLoan.Items.FindByValue(dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString()).Value;
    //        }
    //        BtnSave1.Text = "Update";
    //    }
    //}
    protected void BtnClear_Click(object sender, EventArgs e)
    {
       // clear();

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
    //protected void BtnSave2_Click(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        gvCertificate.Visible = true;

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(), txtBeneficaryName.Text, txtbeneficiaryAddress.Text, txtProjectCost.Text, txtAmontScanctioned.Text, txtBankName.Text, txtBankBranchName.Text, ddlStatusOfLoan.SelectedItem.ToString(), txtRemarks.Text, (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //            gvCertificate.Columns[0].Visible = false;
    //            clear();
    //            //lblmsg.Text = "";
    //            //lblmsg.Text = "";
    //            //txtBankName.Text = "";
    //            //txtPromoterName.Text = "";
    //            //ddlManQuantityIn.SelectedIndex = 0;
    //           // ddlManQuantityPer .SelectedIndex = 0;


    //            //}
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }

    //}

    //protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
    //        e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
    //    }

    //}

    //protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    try
    //    {
    //        if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {

    //            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

    //            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //            this.gvCertificate.DataBind();
    //        }
    //        else
    //        {
    //            if (hdfFlagID0.Value.Trim() != "")
    //            {

    //                try
    //                {
    //                    string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
    //                    DataSet dsna = new DataSet();
    //                    int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

    //                    ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
    //                    this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
    //                    this.gvCertificate.DataBind();
    //                    //}

    //                }
    //                catch (Exception eee)
    //                {
    //                }

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = "Please enter correct data";// ex.ToString();

    //    }
    //    finally
    //    {
    //    }
    //}



    //private void AddDataToTableCeertificate(string intQuessionaireCFOid, string Beneficiary_Name, string Beneficiary_address, string Project_cost, string Amount_sanctioned, string Bank_Name, string Branch_Name, string Current_Status_of_the_Unit, string Remarks, DataTable myTable)
    //{//totStartDate, string totEndDate, string totSummary,
    //    try
    //    {
    //        DataTable dtMyTable;
    //        DataRow Row;
    //        Row = myTable.NewRow();

    //        dtMyTable = new DataTable("CertificateTb2");



    //        Row["new"] = "0";
    //        //Row["intCFEForestid"] = "0";
    //        // Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
    //        Row["Beneficiary_Name"] = Beneficiary_Name;
    //        Row["Beneficiary_address"] = Beneficiary_address;

    //        Row["Project_cost"] = Project_cost;
    //        Row["Amount_sanctioned"] = Amount_sanctioned;
    //        Row["Bank_Name"] = Bank_Name;
    //        Row["Branch_Name"] = Branch_Name;
    //        Row["Current_Status_of_the_Unit"] = Current_Status_of_the_Unit;
    //        Row["Remarks"] = Remarks;
    //        //Row["created_dt"] = createddate;
    //        // Row["tnrExpEndDate"] = tnrExpEndDate1;
    //        Row["Created_by"] = Session["uid"].ToString().Trim();

    //        Row["intLineofActivityMid"] = "0";

    //        myTable.Rows.Add(Row);
    //    }
    //    catch (Exception ee)
    //    {
    //        //  ((DataTable)Session["myDatatable"]).Rows.Clear();
    //        //  Response.Redirect("~/EmpFacility.aspx");
    //    }
   // }


    //private void AddDataToTableCeertificate1(string intQuessionaireCFOid, string intCFOEnterpid, string Raw_ItemName, string Raw_Item_Quantity, string Raw_Item_Quantity_In, string Raw_Item_Quantity_Per, DataTable myTable1)
    //{//totStartDate, string totEndDate, string totSummary,
    //    try
    //    {
    //        DataRow Row;
    //        Row = myTable1.NewRow();

    //        dtMyTable1 = new DataTable("CertificateTb1");



    //        Row["new"] = "0";
    //        //Row["intCFEForestid"] = "0";
    //        Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
    //        Row["intCFOEnterpid"] = intCFOEnterpid;
    //        Row["Raw_ItemName"] = Raw_ItemName;

    //        Row["Raw_Item_Quantity"] = Raw_Item_Quantity;
    //        Row["Raw_Item_Quantity_In"] = Raw_Item_Quantity_In;
    //        Row["Raw_Item_Quantity_Per"] = Raw_Item_Quantity_Per;
    //        //Row["OtherItemName"] = OtherItemName;
    //        //Row["Forest_Pole"] = Forest_Pole;
    //        //Row["Est_FireWood"] = Est_FireWood;
    //        //Row["created_dt"] = createddate;
    //        // Row["tnrExpEndDate"] = tnrExpEndDate1;
    //        Row["Created_by"] = Session["uid"].ToString().Trim();

    //        Row["intLineofActivityRid"] = "0";

    //        myTable1.Rows.Add(Row);
    //    }
    //    catch (Exception ex)
    //    {
    //        //  ((DataTable)Session["myDatatable"]).Rows.Clear();
    //        //  Response.Redirect("~/EmpFacility.aspx");
    //        throw ex;
    //    }
    //}


    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {




    }

   // protected void BtnClear0_Click1(object sender, EventArgs e)
    //{

    //}
    //protected void gvpractical0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        if (BtnSave1.Text == "Save")
    //        {






    //        }
    //        else
    //        {


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //  lblresult.Text = ex.ToString();

    //    }
    //    finally
    //    {
    //    }
    //}



    protected void GetNewRectoInsertdr()
    {
        //myDtNewRecdr = (DataTable)Session["CertificateTb2"];
        //DataView dvdr = new DataView(myDtNewRecdr);
        ////dvdr.RowFilter = "new = 0";
        //myDtNewRecdr = dvdr.ToTable();
    }

    protected void GetNewRectoInsertdr1()
    {
        //myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
        //DataView dvdr1 = new DataView(myDtNewRecdr1);
        ////dvdr1.RowFilter = "new = 0";
        //myDtNewRecdr1 = dvdr1.ToTable();

    }

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
        //    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        //}
    }

    //protected void gvCertificate0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    try
    //    {
    //        if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //        }
    //        else
    //        {
    //            if (hdfFlagID0.Value.Trim() != "")
    //            {
    //                try
    //                {
    //                    string traineetradesnames = gvCertificate0.DataKeys[e.RowIndex].Values["intLineofActivityRid"].ToString();
    //                    DataSet dsna = new DataSet();

    //                    int i1 = Gen.deleteGroupSavingData2(traineetradesnames);

    //                    ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
    //                    this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //                    this.gvCertificate0.DataBind();
    //                    //}

    //                }
    //                catch (Exception eee)
    //                {
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = "Please enter correct data";// ex.ToString();
    //    }
    //    finally
    //    {
    //    }

    //}
    //protected void BtnSave3_Click(object sender, EventArgs e)
    //{
    //    gvCertificate0.Visible = true;
    //    try
    //    {
    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);//Session["uid"].ToString()


    //            this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //            this.gvCertificate0.DataBind();
    //            gvCertificate0.Columns[0].Visible = false;

    //            lblmsg.Text = "";
    //            txtRawItem.Text = "";
    //            txtRawQuantity.Text = "";
    //            ddlRawQuantityIn.SelectedIndex = 0;
    //            ddlRawQuantityPer.SelectedIndex = 0;
    //            //}
    //        }
    //        else
    //            if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
    //            {

    //                //gvCertificate.Visible = true;


    //                //AddDataToTableTOT("1001-001",cmf.convertDateIndia(txtTStartdate.Text).ToString("dd-MM-yyyy"),cmf.convertDateIndia(txtTEndDate.Text).ToString("dd-MM-yyyy"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //                //siva as on 10-08-2103
    //                // AddDataToTableTOT("1001-001", cmf.convertDateIndia(txtTStartdate.Text).ToString("yyyy-MM-dd"), cmf.convertDateIndia(txtTEndDate.Text).ToString("yyyy-MM-dd"), txtSummary.Text, (DataTable)Session["tmpTrainerTOT"]);
    //                AddDataToTableCeertificate1(Session["ApplidA"].ToString(), Session["uid"].ToString(), txtRawItem.Text, txtRawQuantity.Text, ddlRawQuantityIn.SelectedItem.Text.ToString(), ddlRawQuantityPer.SelectedItem.Text.ToString(), (DataTable)Session["CertificateTb1"]);
    //                this.gvCertificate0.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
    //                this.gvCertificate0.DataBind();
    //                gvCertificate0.Columns[0].Visible = false;
    //                //clear_child_TOT();
    //                lblmsg.Text = "";
    //                txtRawItem.Text = "";
    //                txtRawQuantity.Text = "";
    //                ddlRawQuantityIn.SelectedIndex = 0;
    //                ddlRawQuantityPer.SelectedIndex = 0;
    //                //}
    //            }
    //    }
    //    catch (Exception ee)
    //    {
    //        ////lbldtvalid.Text = "Please enter correct Date.";
    //        ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
    //    }

    //    gvCertificate0.Visible = true;
    //}
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    txtBankName.Text = "";
    //    txtPromoterName.Text = "";
    //    //ddlManQuantityIn.SelectedIndex = 0;
    //    //ddlManQuantityPer.SelectedIndex = 0;
    //}
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
        //txtRawItem.Text = "";
        //txtRawQuantity.Text = "";
        //ddlRawQuantityIn.SelectedIndex = 0;
        //ddlRawQuantityPer.SelectedIndex = 0;
        ddlmonth0.SelectedIndex = 0;
        ddlyear0.SelectedIndex = 0;
        Failure.Visible = false;
        success.Visible = false;
        gvCertificate0.Visible = false;

    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void BtnClear0_Click2(object sender, EventArgs e)
    //{
    //    clear();
    //}
    protected void txtAmontScanctioned_TextChanged(object sender, EventArgs e)
    {
      //  Check();
    }

    //void Check()
    //{
    //    if (txtAmontScanctioned.Text == "")
    //    {
    //        txtAmontScanctioned.Text = "0";
    //    }
       
    //    if (txtProjectCost.Text == "")
    //    {
    //         txtProjectCost.Text = "0";
    //    }
        
    //    if (Convert.ToDecimal(txtAmontScanctioned.Text) > Convert.ToDecimal(txtProjectCost.Text))
    //    {
    //        txtAmontScanctioned.Text = "";
    //        lblmsg0.Text = "* Amount Sanctioned must be less then Project Cost";
    //        Failure.Visible = true;
    //        return;
    //    }
    //    else
    //    {
    //        Failure.Visible = false;
    //    }
    //}

    protected void txtProjectCost_TextChanged(object sender, EventArgs e)
    {
       // Check();
    }
    protected void grdDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void grdDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        if (ddlyear0.SelectedIndex== 0 )
        {
            lblmsg.Text = "please select year";

        }
       
        if (ddlmonth0.SelectedIndex == 0)
        {
            lblmsg.Text = "please select month";

        }
        else
        {
            fillgrid();
            // txtUidno0.Text = "";
            //ddlmonth0.SelectedIndex = 0;
            //ddlyear0.SelectedIndex = 0;
        }
    }
    void fillgrid()
    {


        DataSet ds = new DataSet();

        //ds = Gen.SearchPMEGPdetails1(Session["uid"].ToString(), ddlmonth0.SelectedValue.ToString(), ddlyear0.SelectedValue.ToString());

        ds = Gen.SearchPMEGPdetails1(Request.QueryString[0].ToString(),Request.QueryString[1].ToString(),Request.QueryString[2].ToString());

        if (ds.Tables[0].Rows.Count > 0)
        {

            gvCertificate0.DataSource = ds.Tables[0];
            gvCertificate0.DataBind();
            lblmsg.Text = "";
          //  success.Visible = true;
            //Failure.Visible = false;


        }
        else
        {
           // success.Visible = false;
           // Failure.Visible = true;
           // lblmsg0.Text = "No Records found.";
            gvCertificate0.DataSource = null;
            gvCertificate0.DataBind();
        }
    }
}
