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
            //ddlYear.SelectedValue = DateTime.Now.Year.ToString();
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
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
             //ddlintLineofActivity.Items.Insert(0, "--Select--");
            AddSelect(ddlintLineofActivity);
            AddOthers(ddlintLineofActivity);
            GetBanks();

        }
        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

            

            Failure.Visible = false;
            success.Visible = false;
            FillDetails();
            hdfFlagID.Value = "";
        }

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
                // ddlUnitDIst.Items.Insert(0, "--Select--");
                AddSelect(ddlUnitDIst);
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


    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
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


        if (ddlNatureOfLoan.SelectedItem.Text == "--Select--" || ddlNatureOfLoan.SelectedValue.ToString() == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select Nature of Loan');", true);
            return;
        }
        string loanothers = "";
        string LOAothers = "";
        if (ddlNatureOfLoan.SelectedValue.ToString() == "5")
        {
            loanothers = txtLoanOthers.Text.Trim();
        }
        else
        {
            loanothers = "";
        }

        if (ddlintLineofActivity.SelectedValue.ToString() == "001")
        {
            LOAothers = txtLOAothers.Text.Trim();
        }
        else
        {
            LOAothers = "";
        }
        try
        {
            int i = Gen.updateBankVisitDet(Session["uid"].ToString(), ddlBank.SelectedValue, 
                txtBankBranchName.Text, ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(),
            ddlNatureOfLoan.SelectedValue, txtPromoterName.Text, ddlintLineofActivity.SelectedValue.ToString(), 
            txtLoanAmont.Text, txtDDDate.Text, Session["uid"].ToString(), hdfID.Value, 
            txtUnitName.Text, txtAddress.Text, loanothers, txtContact.Text,
            ddlUnitDIst.SelectedValue,ddlUnitMandal.SelectedValue,
            ddlVillageunit.SelectedValue, rbtcasesregistered.SelectedValue.ToString(), LOAothers, Txtinvesment.Text);
            if (i > 0)
            {

                //lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
                BtnSave1.Visible = true;
                BtnUpdate.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Updated Successfully..!');", true);
                return;
                //  ddlMonth.Enabled = true;
                //  ddlYear.Enabled = true;
                //  ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                //  ddlMonth.SelectedIndex = DateTime.Now.Month;
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
    //server side validations on 31-03-2020
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
        //if(ddlBank.SelectedValue=="0"||ddlBank.SelectedItem.Text== "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Bank Name \\n";
        //    slno = slno + 1;
        //}
        //if (txtBankBranchName.Text.Trim() == "" )
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Bank Branch Name \\n";
        //    slno = slno + 1;
        //}
        //if (ddlNatureOfLoan.SelectedValue == "0" || ddlNatureOfLoan.SelectedItem.Text == "--Select--")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Select Nature of loan \\n";
        //    slno = slno + 1;
        //}
        //if(txtLoanOthers.Text.Trim()=="")
        //{
        //    ErrorMsg = ErrorMsg + slno + ". Please Enter Your Nature of Loan \\n";
        //    slno = slno + 1;
        //}
        if (txtUnitName.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name \\n";
            slno = slno + 1;
        }
        if (txtAddress.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Address \\n";
            slno = slno + 1;
        }
        if (txtPromoterName.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Promoter Name \\n";
            slno = slno + 1;
        }
        if (txtLoanAmont.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Amount \\n";
            slno = slno + 1;
        }
        if (txtDDDate.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Sanctioned Date \\n";
            slno = slno + 1;
        }
        if (ddlintLineofActivity.SelectedValue == "0" || ddlintLineofActivity.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Line of Activity \\n";
            slno = slno + 1;
        }
        if(ddlintLineofActivity.SelectedValue=="001")
        {
            if (txtLOAothers.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Other line of Activity \\n";
                slno = slno + 1;
            }
        }

        if (Txtinvesment.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Total Investment\\n";
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

        
        if (ddlNatureOfLoan.SelectedItem.Text == "--Select--"||ddlNatureOfLoan.SelectedValue.ToString()=="0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select Nature of Loan');", true);
            return;
        }

        string loanothers = "";
        string LOAothers = "";
        try
        {
            if (ddlNatureOfLoan.SelectedValue.ToString() == "5")
            {
                 loanothers = txtLoanOthers.Text.Trim();
            }
            else
            {
                loanothers="";
            }
            if(ddlintLineofActivity.SelectedValue.ToString()=="001")
            {
                LOAothers = txtLOAothers.Text.Trim();
            }
            else
            {
                LOAothers = "";
            }

            int i = Gen.insertBankVisitDet(Session["uid"].ToString(), ddlBank.SelectedValue, txtBankBranchName.Text, ddlMonth.SelectedValue, ddlYear.SelectedItem.ToString(),
            ddlNatureOfLoan.SelectedValue, txtPromoterName.Text, ddlintLineofActivity.SelectedValue.ToString(), txtLoanAmont.Text,
            txtDDDate.Text, Session["uid"].ToString(), txtUnitName.Text, txtAddress.Text, loanothers,
            txtContact.Text, ddlUnitDIst.SelectedValue, ddlUnitMandal.SelectedValue,
            ddlVillageunit.SelectedValue, rbtcasesregistered.SelectedValue.ToString(), LOAothers, Txtinvesment.Text);
            if (i > 0)
            {
                //lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Added Successfully..!');", true);
                return;
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
        trlineofactivity.Visible = false;
        loanothers.Visible = false;
        txtContact.Text = "";
        //txtBankName.Text = "";
        txtPromoterName.Text = "";
        ddlBank.SelectedIndex = 0;
        //      ddlMonth.SelectedIndex = 0;
        txtAddress.Text = "";
        txtUnitName.Text = "";
        txtLoanOthers.Text = "";
        success.Visible = false;
        ddlUnitMandal.SelectedIndex = 0;
        ddlVillageunit.SelectedIndex = 0;
        txtLOAothers.Text = "";
        int year = DateTime.Now.Year - 5;

        for (int Y = year; Y <= DateTime.Now.Year; Y++)
        {

            ddlYear.Items.Add(new ListItem(Y.ToString(), Y.ToString()));
        }

       // ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        ddlYear.Enabled = false;
       // ddlMonth.SelectedIndex = DateTime.Now.Month-1;
        ddlMonth.Enabled = false;
        //        ddlYear.SelectedIndex = 0;
        ddlNatureOfLoan.SelectedIndex = 0;
        ddlintLineofActivity.SelectedIndex = 0;
        txtDDDate.Text = "";
        txtBankBranchName.Text = "";
        txtLoanAmont.Text = "";
        Txtinvesment.Text = "";
    }

    void FillDetails()
    {

        DataSet dscheck = new DataSet();
        try
        {

            dscheck = Gen.GetShowBankVisitDet(hdfID.Value);

            if (dscheck.Tables[0].Rows.Count > 0)
            {
                rbtcasesregistered.SelectedValue= dscheck.Tables[0].Rows[0]["RBT_BVR"].ToString();
                ddlBank.SelectedValue = dscheck.Tables[0].Rows[0]["intBankid"].ToString();
                ddlMonth.SelectedValue = dscheck.Tables[0].Rows[0]["BankVisit_Month"].ToString();

                if (dscheck.Tables[0].Rows[0]["District"].ToString() != "")
                {
                    ddlUnitDIst.SelectedValue = dscheck.Tables[0].Rows[0]["District"].ToString();
                    ddlUnitDIst.Enabled = false;
                    ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (dscheck.Tables[0].Rows[0]["Mandal"].ToString() != "")
                {
                    ddlUnitMandal.SelectedValue = dscheck.Tables[0].Rows[0]["Mandal"].ToString();
                    
                    ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                }


               
                ddlVillageunit.SelectedValue = dscheck.Tables[0].Rows[0]["Village"].ToString();
                ddlYear.SelectedValue = dscheck.Tables[0].Rows[0]["BankVisit_Year"].ToString();
                  //ddlintLineofActivity.SelectedValue = dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString();
               if(dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString()==""|| dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString()=="--Select--"|| dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString() == "0")
                {
                    ddlintLineofActivity.SelectedValue = "0";
                }
               else if(dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString() =="001")
                {
                    ddlintLineofActivity.SelectedValue = "001";
                    trlineofactivity.Visible = true;
                    txtLOAothers.Text = dscheck.Tables[0].Rows[0]["TXT_LOA_OTHERS"].ToString();
                }
                else 
                {
                    ddlintLineofActivity.SelectedValue = dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString();
                }
               // ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dscheck.Tables[0].Rows[0]["intLineofActivityid"].ToString()).Value;
                

                ddlNatureOfLoan.SelectedValue = dscheck.Tables[0].Rows[0]["intNatureofLoan"].ToString();
                //txtDDDate.Text = Convert.ToDateTime(dscheck.Tables[0].Rows[0]["DateofSanction"].ToString()).ToString("dd-MM-yyyy");
                if (!string.IsNullOrEmpty(dscheck.Tables[0].Rows[0]["DateofSanction"].ToString()))
                {
                    txtDDDate.Text = Convert.ToDateTime(dscheck.Tables[0].Rows[0]["DateofSanction"].ToString()).ToString("dd-MM-yyyy");

                }
                else
                {
                    txtDDDate.Text = "";
                }
                txtLoanAmont.Text = dscheck.Tables[0].Rows[0]["LoanAmount"].ToString();
                txtPromoterName.Text = dscheck.Tables[0].Rows[0]["PromoterName"].ToString();
                txtBankBranchName.Text = dscheck.Tables[0].Rows[0]["BranchName"].ToString();
                txtContact.Text = dscheck.Tables[0].Rows[0]["CONTACT_NO"].ToString();
                if (dscheck.Tables[0].Rows[0]["intNatureofLoan"].ToString()== "5")
                {
                    loanothers.Visible = true;
                    txtLoanOthers.Text = dscheck.Tables[0].Rows[0]["NATURE_OF_LOANOTHERS"].ToString();
                }
                else
                {
                    loanothers.Visible = false;
                    txtLoanOthers.Text = "";
                }
                txtUnitName.Text = dscheck.Tables[0].Rows[0]["nameofunit"].ToString();
                txtAddress.Text = dscheck.Tables[0].Rows[0]["unitaddress"].ToString();
                Txtinvesment.Text = dscheck.Tables[0].Rows[0]["Totalinvestment"].ToString();
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
            }
            if (dscheck.Tables[0].Rows[0]["Status"].ToString() == "1")
            {
                BtnSave1.Visible = false;
                BtnUpdate.Visible = true;
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

    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }


    protected void BtnClear1_Click(object sender, EventArgs e)
    {

    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlintLineofActivity.SelectedValue=="001"||ddlintLineofActivity.SelectedItem.Text=="Others")
        {
            trlineofactivity.Visible = true;
            txtLOAothers.Text = "";
        }
        else
        {
            trlineofactivity.Visible = false;
            txtLOAothers.Text = "";
        }
    }
    protected void BtnSave2_Click(object sender, EventArgs e)
    {

    }

    protected void ddlNatureOfLoan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNatureOfLoan.SelectedItem.Text == "Others")
        {
            loanothers.Visible = true;
            txtLoanOthers.Text = "";
        }
        else
        {
            loanothers.Visible = false;
            txtLoanOthers.Text = "";
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
    public void AddOthers(DropDownList ddl)
    {
        try
        {
            ListItem li = new ListItem();
            li.Text = "Others";
            li.Value = "001";
            ddl.Items.Insert(001, li);
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
            //lbl1.Visible = false;
            //lbl2.Visible = false;
            //lbl3.Visible = false;
            //lbl4.Visible = false;
            //lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            lbl11.Visible = false;
            lbl12.Visible = false;
            lbl13.Visible = false;

        }
        else
        {
            lbl6.Visible = true;
            lbl7.Visible = true;
            lbl8.Visible = true;
            lbl9.Visible = true;
            lbl10.Visible = true;
            lbl11.Visible = true;
            lbl12.Visible = true;
            lbl13.Visible = true;
        }
    }
}
