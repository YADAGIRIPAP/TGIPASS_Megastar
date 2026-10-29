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
       
        if (Session.Count <= 0)
        {
           // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }
        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
        {

            FillDetails();
            Failure.Visible = false;
            success.Visible = false;
            BtnSave1.Text = "Update";
            //lblresult.Text = "";
            //Btnsave.Enabled = true;
            hdfFlagID.Value = "";
        }
        if (!IsPostBack)
        {
            BindDistricts();
            lblIPOname.Text = Session["user_id"].ToString();
           // ddlMonth.SelectedIndex = System.DateTime.Now.Month - 1;
           // ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
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
            if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
            {
                ddlUnitDIst.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlUnitDIst_SelectedIndexChanged(sender, e);
                ddlUnitDIst.Enabled = false;
            }
            ddlMonth.Enabled = false;
            ddlYear.Enabled = false;
            

            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            //  ddlintLineofActivity.Items.Insert(0, "--Select--");
            AddSelect(ddlintLineofActivity);

            // getIPOS();



            //DataSet dscheck1 = new DataSet();
            //dscheck1 = Gen.GetIPoSubsidydetails(Session["uid"].ToString().Trim(),ddlMonth.SelectedValue,ddlYear.SelectedValue);
            //if (dscheck1.Tables[0].Rows.Count > 0)
            //{
            //    FillDetails();
            //    //Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            //}

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
                //ddlUnitDIst.Items.Insert(0, "--Select--");
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
    protected void getIPOS()
    {
        DataSet dsnew = new DataSet();
        dsnew = Gen.GetIPOS(Session["uid"].ToString());

        ddlIPOname.DataSource = dsnew.Tables[0];
        ddlIPOname.DataTextField = "Dept_Name";
        ddlIPOname.DataValueField = "intUserid";
        ddlIPOname.DataBind();
        ddlIPOname.Items.Insert(0, "--Select--");
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

        if (ddlYear.SelectedValue == "0" || ddlYear.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Year  \\n";
            slno = slno + 1;
        }

        if (ddlMonth.SelectedValue == "0" || ddlMonth.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
            slno = slno + 1;
        }
        if (txtPromoterName.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Promoter Name \\n";
            slno = slno + 1;
        }

        if (txtBeneficaryName.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter  Unit Name \\n";
            slno = slno + 1;
        }
        if (txtbeneficiaryAddress.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Address \\n";
            slno = slno + 1;
        }
        if (ddlCaste.SelectedValue == "0" || ddlCaste.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Social Status \\n";
            slno = slno + 1;
        }
       
        if (txtFirstDate.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of release of Advanced Subsidy(1st Instalment) \\n";
            slno = slno + 1;
        }
        if (txtFirstAmount.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter 1st installment Amount \\n";
            slno = slno + 1;
        }
        if (txtSecondDate.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of release of Advanced Subsidy(2nd Instalment) \\n";
            slno = slno + 1;
        }
        if (txtSecondAmount.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter 2nd installment Amount \\n";
            slno = slno + 1;
        }
        if (ddlStatus.SelectedValue == "0" || ddlStatus.SelectedItem.Text == "--Select--")
        {

            ErrorMsg = ErrorMsg + slno + ". Please Select current status\\n";
            slno = slno + 1;
        }
        if (txtRemarks.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks \\n";
            slno = slno + 1;
        }

        if (ddlintLineofActivity.SelectedValue == "0" || ddlintLineofActivity.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Line of Activity \\n";
            slno = slno + 1;
        }

        return ErrorMsg;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (rbtcasesregmonth.SelectedValue == "Y")
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
        if (BtnSave1.Text == "Save")
        {
            int i = Gen.InsertAdvancedSubsidy(lblIPOname.Text, ddlMonth.SelectedValue, ddlYear.SelectedValue, 
                txtPromoterName.Text, txtBeneficaryName.Text, txtbeneficiaryAddress.Text, txtFirstDate.Text, 
                txtFirstAmount.Text, txtSecondDate.Text, txtSecondAmount.Text, ddlCaste.SelectedValue, 
                ddlStatus.SelectedValue, txtRemarks.Text, ddlintLineofActivity.SelectedValue, 
                Session["uid"].ToString(), "1",ddlUnitDIst.SelectedValue,ddlUnitMandal.SelectedValue,
                ddlVillageunit.SelectedValue,rbtcasesregmonth.SelectedValue.ToString());
            if (i > 0)
            {

                //lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Added Successfully..!');", true);
                return;
            }
            else
            {

                //lblmsg.Text = "Added Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('RECORD ALREADY EXIST..!');", true);
                return;
            }
        }
        else if (BtnSave1.Text == "Update")
        {
            int i = Gen.InsertAdvancedSubsidy(lblIPOname.Text, ddlMonth.SelectedValue, ddlYear.SelectedValue,
                txtPromoterName.Text, txtBeneficaryName.Text, txtbeneficiaryAddress.Text, txtFirstDate.Text, 
                txtFirstAmount.Text, txtSecondDate.Text, txtSecondAmount.Text, ddlCaste.SelectedValue,
                ddlStatus.SelectedValue, txtRemarks.Text, ddlintLineofActivity.SelectedValue, 
                Session["uid"].ToString(), hdfID.Value.ToString().Trim(), ddlUnitDIst.SelectedValue, 
                ddlUnitMandal.SelectedValue, ddlVillageunit.SelectedValue, rbtcasesregmonth.SelectedValue.ToString());
            
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
    void clear()
    {
        success.Visible = false;

        txtPromoterName.Text = ""; txtBeneficaryName.Text = ""; txtbeneficiaryAddress.Text = ""; 
        txtFirstDate.Text = ""; txtFirstAmount.Text = ""; txtSecondDate.Text = ""; txtSecondAmount.Text = ""; 
        ddlCaste.SelectedIndex = 0; ddlStatus.SelectedIndex = 0; txtRemarks.Text = "";
        ddlintLineofActivity.SelectedIndex = 0; ddlIPOname.SelectedIndex = 0;

        BtnSave1.Text = "Save";
        ddlUnitMandal.SelectedIndex = 0;
        ddlVillageunit.SelectedIndex = 0;

      
       
       
    }


   
    void FillDetails()
    {

        DataSet dscheck1 = new DataSet();
        dscheck1 = Gen.GetIPoSubsidydetails(hdfID.Value);
        if (dscheck1.Tables[0].Rows.Count > 0)
        {
            if (dscheck1.Tables[0].Rows[0]["District"].ToString() != "")
            {
                ddlUnitDIst.SelectedValue = dscheck1.Tables[0].Rows[0]["District"].ToString();
                ddlUnitDIst.Enabled = false;
                ddlUnitDIst_SelectedIndexChanged(this, EventArgs.Empty);
            }
            if (dscheck1.Tables[0].Rows[0]["Mandal"].ToString() != "")
            {
                ddlUnitMandal.SelectedValue = dscheck1.Tables[0].Rows[0]["Mandal"].ToString();
                //ddlUnitMandal.Enabled = false;
                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
            }

            ddlVillageunit.SelectedValue = dscheck1.Tables[0].Rows[0]["Village"].ToString();
            lblIPOname.Text = dscheck1.Tables[0].Rows[0]["intIPOid"].ToString();
            txtPromoterName.Text = dscheck1.Tables[0].Rows[0]["Promoter_Name"].ToString();
            txtBeneficaryName.Text = dscheck1.Tables[0].Rows[0]["NameofUnit"].ToString();
            txtbeneficiaryAddress.Text = dscheck1.Tables[0].Rows[0]["AddressofUnit"].ToString();

            if (!string.IsNullOrEmpty(dscheck1.Tables[0].Rows[0]["DateofReleaseFirstInstalment"].ToString()))
            {
                txtFirstDate.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["DateofReleaseFirstInstalment"].ToString()).ToString("dd-MM-yyyy");

            }
            else
            {
                txtFirstDate.Text = "";
            }

            txtFirstAmount.Text = dscheck1.Tables[0].Rows[0]["FirstInstalment"].ToString();
            if (!string.IsNullOrEmpty(dscheck1.Tables[0].Rows[0]["DateofReleaseSecondInstalment"].ToString()))
            {
                txtSecondDate.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["DateofReleaseSecondInstalment"].ToString()).ToString("dd-MM-yyyy");
            }
            else
            {
                txtSecondDate.Text = "";
            }
                txtSecondAmount.Text = dscheck1.Tables[0].Rows[0]["SecondInstalment"].ToString();
            if (!string.IsNullOrEmpty(dscheck1.Tables[0].Rows[0]["Caste"].ToString()))
            {
                ddlCaste.SelectedValue = dscheck1.Tables[0].Rows[0]["Caste"].ToString();
            }
            else
            {
                ddlCaste.SelectedValue = "0";
            }
            ddlStatus.SelectedValue = dscheck1.Tables[0].Rows[0]["CurrentStatus"].ToString();
            txtRemarks.Text = dscheck1.Tables[0].Rows[0]["Remarks"].ToString();
            // ddlintLineofActivity.SelectedValue = dscheck1.Tables[0].Rows[0]["intLineofActivity"].ToString();
            if (!string.IsNullOrEmpty(dscheck1.Tables[0].Rows[0]["intLineofActivity"].ToString()))
            {
                ddlintLineofActivity.SelectedValue = dscheck1.Tables[0].Rows[0]["intLineofActivity"].ToString();
            }
            else
            {
                ddlintLineofActivity.SelectedValue = "0";
            }
                // Label442.Text = dscheck1.Tables[0].Rows[0]["intAdvanceSubsidyid"].ToString();
                hdfID.Value = dscheck1.Tables[0].Rows[0]["intAdvanceSubsidyid"].ToString();
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
    


    private void fillTrademappingGriddr(DataTable tmpTabledr, string MemType, string authorised, string designation, string gender, string mobile, string email2, string Created_by)
    {

      


    }
  
    protected void BtnClear0_Click1(object sender, EventArgs e)
    {
      
    }
   





   
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
    protected void ddlCaste_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    protected void rbtcasesregmonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtcasesregmonth.SelectedValue.ToString() == "N")
        {

            fn1.Visible = false;
            fn2.Visible = false;
            fn3.Visible = false;
            fn4.Visible = false;
            fn5.Visible = false;
            fn6.Visible = false;
            fn7.Visible = false;
            fn8.Visible = false;
            fn9.Visible = false;
            fn10.Visible = false;
            fn11.Visible = false;
            fn12.Visible = false;
            fn13.Visible = false;
            fn14.Visible = false;
            fn15.Visible = false;
            fn16.Visible = false;

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
            fn9.Visible = true;
            fn10.Visible = true;
            fn11.Visible = true;
            fn12.Visible = true;
            fn13.Visible = true;
            fn14.Visible = true;
            fn15.Visible = true;
            fn16.Visible = true;
        }

    }
}
