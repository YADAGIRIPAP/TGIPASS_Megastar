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
        try
        {
            if (Session.Count <= 0)
            {
                // Response.Redirect("../../frmUserLogin.aspx");
                //  Response.Redirect("~/Index.aspx");
            }

            if (!IsPostBack)
            {

                fillgrid();

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }

    //    if (!IsPostBack)
    //    {
    //        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);

    //        int year = DateTime.Now.Year - 5;

    //        for (int Y = year; Y <= DateTime.Now.Year; Y++)
    //        {

    //            ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
    //        }

    //        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    //        ddlMonth.SelectedIndex = DateTime.Now.Month;


    //        GetBanks();

    //        DataSet dsc = new DataSet();
    //        dsc = Gen.GetCategoryDet();
    //        ddlintLineofActivity.DataSource = dsc.Tables[0];
    //        ddlintLineofActivity.DataValueField = "intLineofActivityid";
    //        ddlintLineofActivity.DataTextField = "LineofActivity_Name";
    //        ddlintLineofActivity.DataBind();
    //        ddlintLineofActivity.Items.Insert(0, "--Select--");

    //        dtMyTableCertificate = createtablecrtificate();
    //        Session["CertificateTb2"] = dtMyTableCertificate;

    //        dtMyTableCertificate1 = createtablecrtificate1();
    //        Session["CertificateTb1"] = dtMyTableCertificate1;


    //    }
    //    if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
    //    {
    //        Failure.Visible = false;
    //        success.Visible = false;
    //        FillDetails();
    //        hdfFlagID.Value = "";
    //    }


    //}

    //private void GetBanks()
    //{
    //    DataSet dsnew = new DataSet();

    //    dsnew = Gen.GetBanks();
    //    ddlBank.DataSource = dsnew.Tables[0];
    //    ddlBank.DataTextField = "BankName";
    //    ddlBank.DataValueField = "Id";
    //    ddlBank.DataBind();
    //    ddlBank.Items.Insert(0, "--Select--");
    //}


    //protected DataTable createtablecrtificate()
    //{
    //    dtMyTable = new DataTable("CertificateTb2");

    //    dtMyTable.Columns.Add("new", typeof(string));
    //    dtMyTable.Columns.Add("Bank_Name", typeof(string));
    //    dtMyTable.Columns.Add("Branch_Name", typeof(string));
    //    dtMyTable.Columns.Add("Nature_of_Loan", typeof(string));
    //    dtMyTable.Columns.Add("Promoter_Name", typeof(string));
    //    dtMyTable.Columns.Add("Line_of_Activity", typeof(string));
    //    dtMyTable.Columns.Add("Loan_Amount", typeof(string));
    //    dtMyTable.Columns.Add("Date_of_Sanction", typeof(string));

    //    dtMyTable.Columns.Add("Created_by", typeof(string));
    //    dtMyTable.Columns.Add("intLineofActivityMid", typeof(string));


    //    return dtMyTable;
    //}

    //protected DataTable createtablecrtificate1()
    //{
    //    dtMyTable1 = new DataTable("CertificateTb1");

    //    dtMyTable1.Columns.Add("new", typeof(string));
    //    dtMyTable1.Columns.Add("intQuessionaireCFOid", typeof(string));
    //    dtMyTable1.Columns.Add("intCFOEnterpid", typeof(string));
    //    dtMyTable1.Columns.Add("Raw_ItemName", typeof(string));
    //    dtMyTable1.Columns.Add("Raw_Item_Quantity", typeof(string));
    //    dtMyTable1.Columns.Add("Raw_Item_Quantity_In", typeof(string));
    //    dtMyTable1.Columns.Add("Raw_Item_Quantity_Per", typeof(string));
    //    dtMyTable1.Columns.Add("Created_by", typeof(string));
    //    dtMyTable1.Columns.Add("intLineofActivityRid", typeof(string));


    //    return dtMyTable1;
    //}


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    //protected void BtnUpdate_Click(object sender, EventArgs e)
    //{


    //    try
    //    {
    //        int i = Gen.updateBankVisitDet(Session["uid"].ToString(), ddlBank.SelectedValue, txtBankBranchName.Text, ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(),
    //        ddlNatureOfLoan.SelectedValue, txtPromoterName.Text, ddlintLineofActivity.SelectedValue, txtLoanAmont.Text, txtDDDate.Text, Session["uid"].ToString(), hdfID.Value);
    //        if (i > 0)
    //        {

    //            lblmsg.Text = "Updated Successfully..!";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            clear();
    //            BtnSave1.Visible = true;
    //            BtnUpdate.Visible = false;
    //            ddlMonth.Enabled = true;
    //            ddlYear.Enabled = true;
    //            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    //            ddlMonth.SelectedIndex = DateTime.Now.Month;
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

    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    //DataSet dsUser = new DataSet();
    //    //dsUser = Gen.CheckBankVisit(ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString());
    //    //if (dsUser.Tables[0].Rows.Count > 0)
    //    //{
    //    //    ddlMonth.SelectedIndex = 0;
    //    //    ddlYear.SelectedIndex = 0;
    //    //    lblmsg0.Text = "<font color=red> You have Already Entered Bank Visit Details For Selected Month and Year</font>";
    //    //    success.Visible = false;
    //    //    Failure.Visible = true;

    //    //    return;
    //    //    // txtRetypePassword.Text = "";
    //    //}

    //    try
    //    {
    //        int i = Gen.insertBankVisitDet(Session["uid"].ToString(), ddlBank.SelectedValue, txtBankBranchName.Text, ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(),
    //        ddlNatureOfLoan.SelectedValue, txtPromoterName.Text, ddlintLineofActivity.SelectedValue, txtLoanAmont.Text, txtDDDate.Text, Session["uid"].ToString());
    //        if (i > 0)
    //        {

    //            lblmsg.Text = "Added Successfully..!";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            clear();
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

    //    //txtBankName.Text = "";
    //    txtPromoterName.Text = "";
    //    ddlBank.SelectedIndex = 0;
    //    ddlMonth.SelectedIndex = 0;
    //    ddlYear.SelectedIndex = 0;
    //    ddlNatureOfLoan.SelectedIndex = 0;
    //    ddlintLineofActivity.SelectedIndex = 0;
    //    txtDDDate.Text = "";
    //    txtBankBranchName.Text = "";
    //    txtLoanAmont.Text = "";
    //}

    //void FillDetails()
    //{

    //    DataSet dscheck = new DataSet();
    //    try
    //    {

    //        dscheck = Gen.GetShowBankVisitDet(hdfID.Value);

    //        if (dscheck.Tables[0].Rows.Count > 0)
    //        {
    //            ddlBank.SelectedValue = dscheck.Tables[0].Rows[0]["intBankid"].ToString();
    //            ddlMonth.SelectedValue = dscheck.Tables[0].Rows[0]["BankVisit_Month"].ToString();
    //            ddlYear.SelectedValue = dscheck.Tables[0].Rows[0]["BankVisit_Year"].ToString();
    //            ddlintLineofActivity.SelectedValue = dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString();
    //            ddlNatureOfLoan.SelectedValue = dscheck.Tables[0].Rows[0]["intNatureofLoan"].ToString();
    //            txtDDDate.Text = Convert.ToDateTime(dscheck.Tables[0].Rows[0]["DateofSanction"].ToString()).ToString("dd-MM-yyyy");
    //            txtLoanAmont.Text = dscheck.Tables[0].Rows[0]["LoanAmount"].ToString();
    //            txtPromoterName.Text = dscheck.Tables[0].Rows[0]["PromoterName"].ToString();
    //            txtBankBranchName.Text = dscheck.Tables[0].Rows[0]["BranchName"].ToString();
    //            ddlMonth.Enabled = false;
    //            ddlYear.Enabled = false;
    //        }
    //        if (dscheck.Tables[0].Rows[0]["Status"].ToString() == "1")
    //        {
    //            BtnSave1.Visible = false;
    //            BtnUpdate.Visible = true;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.ToString();
    //    }
    //    finally
    //    {

    //    }

    //  }
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

    //        if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
    //        {
    //            AddDataToTableCeertificate(Session["ApplidA"].ToString(),txtBankName.Text,txtBankBranchName.Text,ddlNatureOfLoan.SelectedItem.ToString(), txtPromoterName.Text,ddlintLineofActivity.SelectedItem.ToString(),txtLoanAmont.Text,txtDDDate.Text, (DataTable)Session["CertificateTb2"]);//Session["uid"].ToString()


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

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //try
        //{
        //    if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
        //    {

        //        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

        //        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
        //        this.gvCertificate.DataBind();
        //    }
        //    else
        //    {
        //        if (hdfFlagID0.Value.Trim() != "")
        //        {

        //            try
        //            {
        //                string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
        //                DataSet dsna = new DataSet();
        //                int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

        //                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
        //                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
        //                this.gvCertificate.DataBind();
        //                //}

        //            }
        //            catch (Exception eee)
        //            {
        //            }

        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblmsg.Text = "Please enter correct data";// ex.ToString();

        //}
        //finally
        //{
        //}
    }



    //private void AddDataToTableCeertificate(string intQuessionaireCFOid, string Bank_Name, string Branch_Name, string Nature_of_Loan, string Promoter_Name, string Line_of_Activity, string Loan_Amount, string Date_of_Sanction, DataTable myTable)
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
    //        Row["Bank_Name"] = Bank_Name;
    //        Row["Branch_Name"] = Branch_Name;

    //        Row["Nature_of_Loan"] = Nature_of_Loan;
    //        Row["Promoter_Name"] = Promoter_Name;
    //        Row["Line_of_Activity"] = Line_of_Activity;
    //        Row["Loan_Amount"] = Loan_Amount;
    //        Row["Date_of_Sanction"] = Date_of_Sanction;
    //        //Row["Est_FireWood"] = Est_FireWood;
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
    //}


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


    //private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    //{




    //}

    //protected void BtnClear0_Click1(object sender, EventArgs e)
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



    //protected void GetNewRectoInsertdr()
    //{
    //    myDtNewRecdr = (DataTable)Session["CertificateTb2"];
    //    DataView dvdr = new DataView(myDtNewRecdr);
    //    //dvdr.RowFilter = "new = 0";
    //    myDtNewRecdr = dvdr.ToTable();
    //}

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
        try
        {
            //txtRawItem.Text = "";
            //txtRawQuantity.Text = "";
            //ddlRawQuantityIn.SelectedIndex = 0;
            //ddlRawQuantityPer.SelectedIndex = 0;
            //  ddlmonth0.SelectedIndex = 0;
            //ddlyear0.SelectedIndex = 0;
            success.Visible = false;
            Failure.Visible = false;
            gvCertificate0.DataSource = null;
            gvCertificate0.DataBind();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave4_Click(object sender, EventArgs e)
    {
        fillgrid();
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
    void fillgrid()
    {
        try
        {

            DataSet ds = new DataSet();

            //  ds = Gen.Searchbankvisitdetails1(Session["uid"].ToString(), ddlmonth0.SelectedValue.ToString(), ddlyear0.SelectedValue.ToString());

            ds = Gen.Searchbankvisitdetails1(Request.QueryString[0].ToString(), Request.QueryString[1].ToString(), Request.QueryString[2].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                gvCertificate0.DataSource = ds.Tables[0];
                gvCertificate0.DataBind();
                lblmsg.Text = "";
                // success.Visible = true;
                // Failure.Visible = false;


            }
            else
            {
                success.Visible = false;
                Failure.Visible = true;
                lblmsg0.Text = "No Records found.";
                // gvCertificate0.DataSource = null;
                // gvCertificate0.DataBind();
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
}
