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




    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            BindDistricts();
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);

            int year = DateTime.Now.Year - 5;

            for (int Y = year; Y <= DateTime.Now.Year; Y++)
            {

                ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
            }
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlUnitDIst.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlUnitDIst_SelectedIndexChanged(sender, e);
                ddlUnitDIst.Enabled = false;
            }

           // ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlYear.Enabled = false;
           // ddlMonth.SelectedIndex = DateTime.Now.Month - 1;
            ddlMonth.Enabled = false;
            if ((System.DateTime.Now.Month) == 1)
            {
                ddlMonth.SelectedValue = "12";
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.SelectedValue = ddlYear.Items.FindByValue((System.DateTime.Now.Year - 1).ToString()).Value;
            }
            else
            {
                ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                ddlYear.Enabled = false;

                ddlMonth.SelectedValue = ddlMonth.Items.FindByValue((System.DateTime.Now.Month - 1).ToString()).Value;
                ddlMonth.Enabled = false;

            }
            GetBanks();

        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {
            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            //hdfFlagID.Value = "";
        }

        //    DataSet dstarget = new DataSet();

        //    dstarget = Gen.GetBankVisitoutofTarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), "1004");

        //    if (dstarget.Tables[0].Rows.Count > 0)
        //    {

        //        lblmsg2.Text = dstarget.Tables[0].Rows[0]["Target"].ToString();



        //    }
        //    else
        //    {

        //        lblmsg2.Text = "0";

        //    }

        //    DataSet dscount = new DataSet();

        //    dscount = Gen.getcountoftarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), "1001");

        //    if (dscount.Tables[0].Rows.Count > 0)
        //    {

        //        lblmsg1.Text = dscount.Tables[0].Rows[0]["expr1"].ToString();


        //    }
        //    else
        //    {
        //        lblmsg1.Text = "0";
        //    }

    }
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlUnitDIst.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlUnitDIst.DataSource = dsd.Tables[0];
                ddlUnitDIst.DataValueField = "District_Id";
                ddlUnitDIst.DataTextField = "District_Name";
                ddlUnitDIst.DataBind();
                //ddlUnitDIst.Items.Insert(0, "--Select--");
                AddSelect(ddlUnitDIst);
            }
            else
            {
                AddSelect(ddlUnitDIst);
                //ddlUnitDIst.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }

    private void GetBanks()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetBridgeBankDetails();
        ddlBank.DataSource = dsnew.Tables[0];
        ddlBank.DataTextField = "BANKNAME";
        ddlBank.DataValueField = "BANKID";
        ddlBank.DataBind();
        ddlBank.Items.Insert(0, "--Select--");
    }

    //protected DataTable createtablecrtificate()
    //{
    //    dtMyTable = new DataTable("CertificateTb2");

    //    dtMyTable.Columns.Add("new", typeof(string));
    //    dtMyTable.Columns.Add("Beneficiary_Name", typeof(string));
    //    dtMyTable.Columns.Add("Beneficiary_address", typeof(string));
    //    dtMyTable.Columns.Add("Project_cost", typeof(string));
    //    dtMyTable.Columns.Add("Amount_sanctioned", typeof(string));
    //    dtMyTable.Columns.Add("Bank_Name", typeof(string));
    //    dtMyTable.Columns.Add("Branch_Name", typeof(string));
    //    dtMyTable.Columns.Add("Current_Status_of_the_Unit", typeof(string));
    //    dtMyTable.Columns.Add("Remarks", typeof(string));
    //    //dtMyTable.Columns.Add("Date_of_Sanction", typeof(string));

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
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlUnitDIst.SelectedValue == "0" || ddlUnitDIst.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select District  details\\n";
            slno = slno + 1;
        }
        if (ddlUnitMandal.SelectedValue == "0" || ddlUnitMandal.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Mandal details \\n";
            slno = slno + 1;
        }
        if (ddlVillageunit.SelectedValue == "0" || ddlVillageunit.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select village details \\n";
            slno = slno + 1;
        }

        //if (ddlYear.SelectedValue == "0" || ddlYear.SelectedItem.Text == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Year  \\n";
        //    slno = slno + 1;
        //}

        //if (ddlMonth.SelectedValue == "0" || ddlMonth.SelectedItem.Text == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
        //    slno = slno + 1;
        //}

        if (txtBeneficaryName.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Beneficiary Name \\n";
            slno = slno + 1;
        }
        if (txtbeneficiaryAddress.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Beneficiary Address \\n";
            slno = slno + 1;
        }
        
        if (ddlStatusOfUnit.SelectedValue == "0" || ddlStatusOfUnit.SelectedItem.Text == "--Select--")
        {

            ErrorMsg = ErrorMsg + slno + ". Please Select current status\\n";
            slno = slno + 1;
        }
        if (ddlStatusOfUnit.SelectedValue == "3")
        {
            if (txtStatusOthers.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current  Status others  \\n";
                slno = slno + 1;
            }
        }
        if (ddlStatusOfUnit.SelectedValue == "2")
        {
            if (txtgroundeddate.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Grounded Date  \\n";
                slno = slno + 1;
            }
        }

        if (txtProjectCost.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Project Cost \\n";
            slno = slno + 1;
        }
        if (txtAmontScanctioned.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter Sanctioned Amount \\n";
            slno = slno + 1;
        }
        
        if (txtRemarks.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks \\n";
            slno = slno + 1;
        }

        

        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (rbtcasesregistered.SelectedValue == "Y")
        {
            //server side validations
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
        //if (ddlUnitMandal.SelectedItem.Text == "--Select--")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select your mandal');", true);
        //    return;
        //}
        //if (ddlVillageunit.SelectedItem.Text == "--Select--")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select your village');", true);
        //    return;
        //}


        string loanothers = "";
        string unitstatusothers = "";
        string groundeddate = "";

        try
        {
            if (ddlTypeOfLoan.SelectedValue.ToString() == "4")
            {
                loanothers = txtLoanTypeOthers.Text.Trim();
            }
            else

            {
                loanothers = "";
            }
            if (ddlStatusOfUnit.SelectedValue.ToString() == "3")
            {
                unitstatusothers = txtStatusOthers.Text.Trim();
            }
            else
            {
                unitstatusothers = "";
            }
            if (ddlStatusOfUnit.SelectedValue.ToString() == "2")
            {
                groundeddate = txtgroundeddate.Text.Trim();
            }
            else
            {
                groundeddate = "";
            }
            if (BtnSave1.Text == "Save")
            {


                //if (Convert.ToInt32(lblmsg1.Text) >= Convert.ToInt32(lblmsg2.Text))
                //{

                //    Failure.Visible = true;
                //    success.Visible = false;

                //    lblmsg0.Text = "Not Registered More than Target";

                //    return;

                //}



                int i = Gen.insertPMEGPMUDRA(Session["uid"].ToString(), ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(),
                    txtBeneficaryName.Text, txtbeneficiaryAddress.Text,
                txtProjectCost.Text, txtAmontScanctioned.Text, ddlBank.SelectedValue, txtBankBranchName.Text,
                ddlStatusOfUnit.SelectedValue, txtRemarks.Text, Session["uid"].ToString(),
                ddlUnitDIst.SelectedValue, ddlUnitMandal.SelectedValue, ddlVillageunit.SelectedValue,
                ddlTypeOfLoan.SelectedValue, loanothers, unitstatusothers, rbtcasesregistered.SelectedValue.ToString(), groundeddate);
                if (i > 0)
                {

                    //DataSet dscount = new DataSet();

                    //dscount = Gen.getcountoftarget(ddlYear.SelectedValue.ToString(), ddlMonth.SelectedValue.ToString(), Session["uid"].ToString(), "1001");

                    //if (dscount.Tables[0].Rows.Count > 0)
                    //{

                    //    lblmsg1.Text = dscount.Tables[0].Rows[0]["expr1"].ToString();


                    //}
                    //else
                    //{
                    //    lblmsg1.Text = "0";
                    //}



                    //lblmsg.Text = "Added Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Added Successfully..!');", true);
                    return;
                }
            }
            if (BtnSave1.Text == "Update")
            {


                lblmsg.Text = "";

                int i = Gen.updatePMEGPMUDRA(Session["uid"].ToString(), ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(), txtBeneficaryName.Text
, txtbeneficiaryAddress.Text,
txtProjectCost.Text, txtAmontScanctioned.Text, ddlBank.SelectedValue, txtBankBranchName.Text,
ddlStatusOfUnit.SelectedValue, txtRemarks.Text, Session["uid"].ToString(), hdfID.Value,
ddlUnitDIst.SelectedValue, ddlUnitMandal.SelectedValue, ddlVillageunit.SelectedValue,
                ddlTypeOfLoan.SelectedValue, loanothers, unitstatusothers, rbtcasesregistered.SelectedValue.ToString(), groundeddate);
                if (i > 0)
                {

                    //lblmsg.Text = "Updated Successfully..!";
                    success.Visible = true;
                    Failure.Visible = false;
                    clear();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Updated Successfully..!');", true);
                    return;
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
    void clear()
    {
        success.Visible = false;
        txtBeneficaryName.Text = "";
        ddlBank.SelectedIndex = 0;

        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);

        int year = DateTime.Now.Year - 5;

        for (int Y = year; Y <= DateTime.Now.Year; Y++)
        {

            ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
        }

        //ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlYear.Enabled = false;
        //ddlMonth.SelectedIndex = DateTime.Now.Month;
        ddlMonth.Enabled = false;

        //ddlMonth.SelectedIndex = 0;
        //  ddlYear.SelectedIndex = 0;
        ddlStatusOfUnit.SelectedIndex = 0;
        // ddlintLineofActivity.SelectedIndex = 0;
        txtBankBranchName.Text = "";
        txtbeneficiaryAddress.Text = "";
        txtBankBranchName.Text = "";
        txtProjectCost.Text = "";
        txtRemarks.Text = "";
        txtAmontScanctioned.Text = "";
        ddlTypeOfLoan.SelectedIndex = 0;
        ddlUnitMandal.SelectedIndex = 0;
        ddlVillageunit.SelectedIndex = 0;
        trcurrentstatusothers.Visible = false;
        trtypeofloanothers.Visible = false;
        txtLoanTypeOthers.Text = "";
        txtStatusOthers.Text = "";
        ddlUnitDIst.Enabled = false;
        txtgroundeddate.Text = "";

    }



    public void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet dsemp = new DataSet();

        dsemp = Gen.GetPMEGPandMUDRA(hdfID.Value.ToString());

        if (dsemp.Tables[0].Rows.Count > 0)
        {
            if (dsemp.Tables[0].Rows[0]["District"].ToString() != "")
            {
                ddlUnitDIst.SelectedValue = dsemp.Tables[0].Rows[0]["District"].ToString();
                ddlUnitDIst.Enabled = false;
                ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (dsemp.Tables[0].Rows[0]["Mandal"].ToString() != "")
            {
                ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Mandal"].ToString();
               
                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
            }

            ddlVillageunit.SelectedValue = dsemp.Tables[0].Rows[0]["Village"].ToString();
            ddlTypeOfLoan.SelectedValue = dsemp.Tables[0].Rows[0]["Type_of_loan"].ToString();
            if (dsemp.Tables[0].Rows[0]["Type_of_loan"].ToString() == "4")
            {
                trtypeofloanothers.Visible = true;
                txtLoanTypeOthers.Text = dsemp.Tables[0].Rows[0]["Type_of_loanothers"].ToString();
            }
            else
            {
                txtLoanTypeOthers.Text = "";
                trtypeofloanothers.Visible = false;

            }

            ddlStatusOfUnit.SelectedValue = dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString();
            //if (dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString() == "3")
            //{
            //    trcurrentstatusothers.Visible = true;
            //    txtStatusOthers.Text = dsemp.Tables[0].Rows[0]["Unit_statusothers"].ToString();
            //}
            //else
            //{
            //    txtStatusOthers.Text = "";
            //    trcurrentstatusothers.Visible = false;
            //}
            if (dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString() == "3")
            {
                trcurrentstatusothers.Visible = true;
                trgroundeddate.Visible = false;
                txtStatusOthers.Text = dsemp.Tables[0].Rows[0]["Unit_statusothers"].ToString();
            }
            else if (dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString() == "2")
            {
                trcurrentstatusothers.Visible = false;
                trgroundeddate.Visible = true;
                txtgroundeddate.Text = dsemp.Tables[0].Rows[0]["groundeddate"].ToString();

            }
            else
            {
                txtStatusOthers.Text = "";
                trcurrentstatusothers.Visible = false;
                trgroundeddate.Visible = false;
                txtgroundeddate.Text = "";

            }
            ////txtStatusOthers.Text= dsemp.Tables[0].Rows[0]["Unit_statusothers"].ToString();
            txtBeneficaryName.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
            txtbeneficiaryAddress.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
            txtBankBranchName.Text = dsemp.Tables[0].Rows[0]["BranchName"].ToString();
            txtProjectCost.Text = dsemp.Tables[0].Rows[0]["ProjectCost"].ToString();
            txtRemarks.Text = dsemp.Tables[0].Rows[0]["Remarks"].ToString();
            txtAmontScanctioned.Text = dsemp.Tables[0].Rows[0]["AmountSanctioned"].ToString();

            ddlMonth.SelectedValue = ddlMonth.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Month"].ToString().Trim()).Value;
            ddlYear.SelectedValue = ddlYear.Items.FindByValue(dsemp.Tables[0].Rows[0]["VI_Year"].ToString()).Value;

            GetBanks();
            if (dsemp.Tables[0].Rows[0]["intBankid"].ToString().Trim() != "")
            {
                ddlBank.SelectedValue = ddlBank.Items.FindByValue(dsemp.Tables[0].Rows[0]["intBankid"].ToString()).Value;
            }

            if (dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString().Trim() != "")
            {
                ddlStatusOfUnit.SelectedValue = ddlStatusOfUnit.Items.FindByValue(dsemp.Tables[0].Rows[0]["CurrentStatus"].ToString()).Value;
            }
            BtnSave1.Text = "Update";
        }
    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
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

    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
        }

    }

    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            if ((hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == "") || (hdfFlagID0.Value.Trim() == "" && hdfFlagID.Value == ""))
            {

                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gvCertificate.DataBind();
            }
            else
            {
                if (hdfFlagID0.Value.Trim() != "")
                {

                    try
                    {
                        string traineetradesnames = gvCertificate.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                        DataSet dsna = new DataSet();
                        int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                        this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvCertificate.DataBind();
                        //}

                    }
                    catch (Exception eee)
                    {
                    }

                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {
        }
    }



    private void AddDataToTableCeertificate(string intQuessionaireCFOid, string Beneficiary_Name, string Beneficiary_address, string Project_cost, string Amount_sanctioned, string Bank_Name, string Branch_Name, string Current_Status_of_the_Unit, string Remarks, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataTable dtMyTable;
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");



            Row["new"] = "0";
            //Row["intCFEForestid"] = "0";
            // Row["intQuessionaireCFOid"] = intQuessionaireCFOid;
            Row["Beneficiary_Name"] = Beneficiary_Name;
            Row["Beneficiary_address"] = Beneficiary_address;

            Row["Project_cost"] = Project_cost;
            Row["Amount_sanctioned"] = Amount_sanctioned;
            Row["Bank_Name"] = Bank_Name;
            Row["Branch_Name"] = Branch_Name;
            Row["Current_Status_of_the_Unit"] = Current_Status_of_the_Unit;
            Row["Remarks"] = Remarks;
            //Row["created_dt"] = createddate;
            // Row["tnrExpEndDate"] = tnrExpEndDate1;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";

            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }


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



    //protected void GetNewRectoInsertdr()
    //{
    //    myDtNewRecdr = (DataTable)Session["CertificateTb2"];
    //    DataView dvdr = new DataView(myDtNewRecdr);
    //    //dvdr.RowFilter = "new = 0";
    //    myDtNewRecdr = dvdr.ToTable();
    //}

    //protected void GetNewRectoInsertdr1()
    //{
    //    //myDtNewRecdr1 = (DataTable)Session["CertificateTb1"];
    //    //DataView dvdr1 = new DataView(myDtNewRecdr1);
    //    ////dvdr1.RowFilter = "new = 0";
    //    //myDtNewRecdr1 = dvdr1.ToTable();

    //}

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
        Check();
    }

    void Check()
    {
        if (txtAmontScanctioned.Text == "")
        {
            txtAmontScanctioned.Text = "0";
        }

        if (txtProjectCost.Text == "")
        {
            txtProjectCost.Text = "0";
        }

        if (Convert.ToDecimal(txtAmontScanctioned.Text) > Convert.ToDecimal(txtProjectCost.Text))
        {
            txtAmontScanctioned.Text = "";
            lblmsg0.Text = "* Amount Sanctioned must be less then Project Cost";
            Failure.Visible = true;
            return;
        }
        else
        {
            Failure.Visible = false;
        }
    }

    protected void txtProjectCost_TextChanged(object sender, EventArgs e)
    {
        Check();
    }

    protected void ddlTypeOfLoan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTypeOfLoan.SelectedItem.Text == "OTHER")
        {
            trtypeofloanothers.Visible = true;
        }
        else
        {
            txtLoanTypeOthers.Text = "";
            trtypeofloanothers.Visible = false;

        }
    }

    protected void ddlStatusOfUnit_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlStatusOfUnit.SelectedItem.Text == "OTHERS")
        //{
        //    trcurrentstatusothers.Visible = true;

        //}
        //else
        //{
        //    txtStatusOthers.Text = "";
        //    trcurrentstatusothers.Visible = false;
        //}
        if (ddlStatusOfUnit.SelectedItem.Text == "OTHERS")
        {
            trcurrentstatusothers.Visible = true;
            trgroundeddate.Visible = false;
        }
        else if (ddlStatusOfUnit.SelectedItem.Text == "Grounded")
        {
            trcurrentstatusothers.Visible = false;
            trgroundeddate.Visible = true;


        }
        else
        {
            txtStatusOthers.Text = "";
            trcurrentstatusothers.Visible = false;
            trgroundeddate.Visible = false;
            txtgroundeddate.Text = "";

        }

    }

    protected void ddlUnitDIst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitDIst.SelectedIndex == 0)
        {
            ddlUnitMandal.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();

        }
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlUnitMandal.DataSource = dsm.Tables[0];
            ddlUnitMandal.DataValueField = "Mandal_Id";
            ddlUnitMandal.DataTextField = "Manda_lName";
            ddlUnitMandal.DataBind();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();
            //ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
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
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
    }

    protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUnitMandal.SelectedIndex == 0)
        {

            ddlVillageunit.Items.Clear();
            // ddlVillageunit.Items.Insert(0, "--Village--");
            AddSelect(ddlVillageunit);
        }
        else
        {
            ddlVillageunit.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillageunit.DataSource = dsv.Tables[0];
                ddlVillageunit.DataValueField = "Village_Id";
                ddlVillageunit.DataTextField = "Village_Name";
                ddlVillageunit.DataBind();
                AddSelect(ddlVillageunit);
                //  ddlVillageunit.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
        }
    }



    protected void rbtcasesregistered_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtcasesregistered.SelectedValue.ToString() == "N")
        {
            fn1.Visible = false;
            fn2.Visible = false;
            fn3.Visible = false;
            fn4.Visible = false;
            fn5.Visible = false;
            fn6.Visible = false;
            fn7.Visible = false;
            fn8.Visible = false;
        }
        else
        {
            fn1.Visible = true;
            fn2.Visible = true;
            fn3.Visible = true;
            fn4.Visible = true;
            fn5.Visible = true;
            fn6.Visible = true;
            fn7.Visible = true;
            fn8.Visible = true;
        }


    }
}
