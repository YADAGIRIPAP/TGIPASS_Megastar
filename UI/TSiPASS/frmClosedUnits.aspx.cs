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
            hdfFlagID.Value = "1";
        }

        if (!IsPostBack)
        {
            BindDistricts();
            txtdateofentry.Text = System.DateTime.Now.Day.ToString();
            //ddlMonth.SelectedIndex = System.DateTime.Now.Month - 1;
            //ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
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
                ddlProp_intDistrictid.SelectedValue = Session["DistrictID"].ToString().Trim();
                ddlProp_intDistrictid_SelectedIndexChanged(sender, e);
                ddlProp_intDistrictid.Enabled = false;
            }
                ddlMonth.Enabled = false;
            ddlYear.Enabled = false;
            txtdateofentry.Enabled = false;

            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDet();
            ddlintLineofActivity.DataSource = dsc.Tables[0];
            ddlintLineofActivity.DataValueField = "intLineofActivityid";
            ddlintLineofActivity.DataTextField = "LineofActivity_Name";
            ddlintLineofActivity.DataBind();
            AddSelect(ddlintLineofActivity);
            //ddlintLineofActivity.Items.Insert(0, "--Select--");

            //DataSet dsm = new DataSet();
            //dsm = Gen.GetMandalsForClosedUnits();
            //if (dsm.Tables[0].Rows.Count > 0)
            //{
            //    ddlMandal.DataSource = dsm.Tables[0];
            //    ddlMandal.DataValueField = "Mandal_Id";
            //    ddlMandal.DataTextField = "Manda_lName";
            //    ddlMandal.DataBind();
            //    ddlMandal.Items.Insert(0, "--Select--");
            //}
            //else
            //{
            //    ddlMandal.Items.Clear();
            //    ddlMandal.Items.Insert(0, "--Select--");
            //}
        }
  
    }
    
    public void BindDistricts()
    {
        try
        {
            DataSet dsd = new DataSet();
            ddlProp_intDistrictid.Items.Clear();
            dsd = Gen.GetDistrictsWithoutHYD();
            if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
            {
                ddlProp_intDistrictid.DataSource = dsd.Tables[0];
                ddlProp_intDistrictid.DataValueField = "District_Id";
                ddlProp_intDistrictid.DataTextField = "District_Name";
                ddlProp_intDistrictid.DataBind();
                // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddlProp_intDistrictid);
            }
            else
            {
               // ddlProp_intDistrictid.Items.Insert(0, "--Select--");
                AddSelect(ddlProp_intDistrictid);
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
    
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (ddlProp_intDistrictid.SelectedValue == "0" || ddlProp_intDistrictid.SelectedItem.Text == "--Select--")
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
        
        if (TxtNameofUnit.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Bank Unit Name \\n";
            slno = slno + 1;
        }
        if (TxtAddressofUnit.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Address \\n";
            slno = slno + 1;
        }
        if (ddlLTHT.SelectedValue == "0" || ddlLTHT.SelectedItem.Text == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Lt or Ht \\n";
            slno = slno + 1;
        }
        if (ddlCurrentStatus.SelectedValue == "0" || ddlCurrentStatus.SelectedItem.Text == "--Select--")
        {
           
            ErrorMsg = ErrorMsg + slno + ". Please Select current status\\n";
            slno = slno + 1;
        }
        if(ddlCurrentStatus.SelectedValue=="2")
        {
            if (txtStatusOthers.Text.Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current  Status others  \\n";
                slno = slno + 1;
            }
        }
         

        if (TxtDateofCloser.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Closer of the Unit \\n";
            slno = slno + 1;
        }
        if (TxtDateofCloserFirst.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ".Please enter Date of Closure Reported for the first time \\n";
            slno = slno + 1;
        }
        if (TxtBriefReason.Text.Trim() == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Brief Reason for closer \\n";
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
        if (rbtTIHCL.SelectedValue != "Y" && rbtTIHCL.SelectedValue != "N")
        {
            ErrorMsg = ErrorMsg + slno + ". Please select Whether send to TIHCL or not \\n";
            slno = slno + 1;
        }
        if (rbtTIHCL.SelectedValue == "N")
        {
            if (Txtreason.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Reason \\n";
                slno = slno + 1;
            }
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
        string statusOthers = "";
        if(ddlCurrentStatus.SelectedValue=="2")
        {
            statusOthers = txtStatusOthers.Text.Trim();
        }
        else
        {
            statusOthers = "";
        }
        //if (ddlUnitMandal.SelectedItem.Text == "--Select--")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Your Mandal');", true);
        //    return;
        //}
        //if (ddlVillageunit.SelectedItem.Text == "--Select--")
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Your village');", true);
        //    return;
        //}
        if (BtnSave1.Text == "Save")
        {
            
            string DateofClosure_date;
           
            if (TxtDateofCloser.Text == "" || TxtDateofCloser.Text == null)
            {
                 DateofClosure_date = null;
            }
            else
            {
                string[] ConvertedDtloan = TxtDateofCloser.Text.Split('/');
                DateofClosure_date = ConvertedDtloan[2].ToString() + "/" + ConvertedDtloan[1].ToString() + "/" + ConvertedDtloan[0].ToString();
            }
            string DateofClosureFirst_date;

            if (TxtDateofCloserFirst.Text == "" || TxtDateofCloserFirst.Text == null)
            {
                DateofClosureFirst_date = null;
            }
            else
            {
                string[] ConvertedDtloan1 = TxtDateofCloserFirst.Text.Split('/');
            DateofClosureFirst_date = ConvertedDtloan1[2].ToString() + "/" + ConvertedDtloan1[1].ToString() + "/" + ConvertedDtloan1[0].ToString();
             }
            int i = 0;
            i = Gen.InsertClosedUnits("1",ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlUnitMandal.SelectedValue, 
                TxtNameofUnit.Text, TxtAddressofUnit.Text, DateofClosure_date, ddlLTHT.SelectedValue, 
                TxtBriefReason.Text, txtRemarks.Text, ddlintLineofActivity.SelectedValue, Session["uid"].ToString(),
                txtdateofentry.Text,ddlProp_intDistrictid.SelectedValue, DateofClosureFirst_date,
                ddlCurrentStatus.SelectedValue, statusOthers, ddlVillageunit.SelectedValue,
                rbtcasesregmonth.SelectedValue.ToString(), rbtTIHCL.SelectedValue.ToString(), Txtreason.Text);

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
        if (BtnSave1.Text == "Update")
        {
            string DateofClosure_date;

            if (TxtDateofCloser.Text == "" || TxtDateofCloser.Text == null)
            {
                DateofClosure_date = null;
            }
            else
            {
                string[] ConvertedDtloan = TxtDateofCloser.Text.Split('/');
                DateofClosure_date = ConvertedDtloan[2].ToString() + "/" + ConvertedDtloan[1].ToString() + "/" + ConvertedDtloan[0].ToString();
            }
            string DateofClosureFirst_date;

            if (TxtDateofCloserFirst.Text == "" || TxtDateofCloserFirst.Text == null)
            {
                DateofClosureFirst_date = null;
            }
            else
            {
                string[] ConvertedDtloan1 = TxtDateofCloserFirst.Text.Split('/');
                DateofClosureFirst_date = ConvertedDtloan1[2].ToString() + "/" + ConvertedDtloan1[1].ToString() + "/" + ConvertedDtloan1[0].ToString();
            }
            int i = 0;

            i = Gen.InsertClosedUnits(hdfID.Value,ddlMonth.SelectedValue, ddlYear.SelectedValue,
                ddlUnitMandal.SelectedValue, TxtNameofUnit.Text, TxtAddressofUnit.Text, DateofClosure_date,
                ddlLTHT.SelectedValue, TxtBriefReason.Text, txtRemarks.Text, ddlintLineofActivity.SelectedValue, 
                Session["uid"].ToString(), txtdateofentry.Text, ddlProp_intDistrictid.SelectedValue,
                DateofClosureFirst_date, ddlCurrentStatus.SelectedValue, statusOthers,ddlVillageunit.SelectedValue,
                rbtcasesregmonth.SelectedValue.ToString(), rbtTIHCL.SelectedValue.ToString(), Txtreason.Text);

            if (i > 0)
            {

                //lblmsg.Text = "Updated Successfully..!";
                success.Visible = true;
                Failure.Visible = false;
                clear();
                ddlVillageunit.SelectedIndex = 0;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Updated Successfully..!');", true);
                return;
            }
        }

    }
    void clear()
    {
        success.Visible = false;
        //ddlMonth.SelectedIndex = System.DateTime.Now.Month-1;
        //ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
        ddlMonth.Enabled = false;
        ddlYear.Enabled = false;
        ddlUnitMandal.SelectedIndex = 0;
        //ddlMonth.SelectedIndex = 0; 
        TxtNameofUnit.Text = ""; TxtAddressofUnit.Text = ""; TxtDateofCloser.Text = ""; ddlLTHT.SelectedIndex = 0; TxtBriefReason.Text = ""; txtRemarks.Text = ""; ddlintLineofActivity.SelectedIndex = 0;
        BtnSave1.Text = "Save";
        ddlCurrentStatus.SelectedIndex = 0;
        trotherstatus.Visible = false;
        TxtDateofCloserFirst.Text = "";
        //ddlProp_intDistrictid.SelectedIndex = 0;
        ddlUnitMandal.SelectedIndex = 0;
        ddlVillageunit.SelectedIndex = 0;
        txtStatusOthers.Text = "";
        rbtTIHCL.ClearSelection();
        Txtreason.Text = "";
        
    }

    void FillDetails()
    {

        DataSet ds = new DataSet();
        try
        {

            DataSet dsemp = new DataSet();


            dsemp = Gen.getUnitClosedDet(hdfID.Value);

            if (dsemp.Tables[0].Rows.Count > 0)
            {
                ddlMonth.SelectedValue = dsemp.Tables[0].Rows[0]["VI_Month"].ToString();
                ddlYear.SelectedValue = dsemp.Tables[0].Rows[0]["VI_Year"].ToString();
                TxtNameofUnit.Text = dsemp.Tables[0].Rows[0]["NameofUnit"].ToString();
                if (dsemp.Tables[0].Rows[0]["District"].ToString() != "")
                {
                    ddlProp_intDistrictid.SelectedValue = dsemp.Tables[0].Rows[0]["District"].ToString();
                    //ddlProp_intDistrictid.Enabled = false;
                    ddlProp_intDistrictid_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (dsemp.Tables[0].Rows[0]["Location"].ToString() != "")
                {
                    ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Location"].ToString();
                    //ddlUnitMandal.Enabled = false;
                    ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                }
                //ddlUnitMandal.SelectedValue = dsemp.Tables[0].Rows[0]["Location"].ToString();
                //ddlProp_intDistrictid.SelectedValue=dsemp.Tables[0].Rows[0]["district"].ToString();
                ddlVillageunit.SelectedValue = dsemp.Tables[0].Rows[0]["Village"].ToString();
                TxtAddressofUnit.Text = dsemp.Tables[0].Rows[0]["AddressofUnit"].ToString();
                ddlLTHT.SelectedValue = dsemp.Tables[0].Rows[0]["HTLT"].ToString();
                TxtDateofCloser.Text = (dsemp.Tables[0].Rows[0]["DateofCloser"]).ToString();
                //TxtDateofCloser.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["DateofCloser"].ToString()).ToString("dd-MM-yyyy");
                TxtBriefReason.Text = dsemp.Tables[0].Rows[0]["BriefReason"].ToString();
                txtRemarks.Text = dsemp.Tables[0].Rows[0]["OtherRemarks"].ToString();
                // ddlintLineofActivity.SelectedValue = dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString();
                if (dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString() == "" || dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString() == "--Select--" || dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString() == "0"|| dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString()=="NULL")
                {
                    ddlintLineofActivity.SelectedValue = "0";
                }
                else
                {
                    ddlintLineofActivity.SelectedValue = dsemp.Tables[0].Rows[0]["Line_of_Activity"].ToString();
                }
                TxtDateofCloserFirst.Text = (dsemp.Tables[0].Rows[0]["dateofclosedunitsfirst"]).ToString();
                //TxtDateofCloserFirst.Text = Convert.ToDateTime(dsemp.Tables[0].Rows[0]["dateofclosedunitsfirst"].ToString()).ToString("dd-MM-yyyy");
                if (!string.IsNullOrEmpty(dsemp.Tables[0].Rows[0]["currentstatus"].ToString()))
                {
                    ddlCurrentStatus.SelectedValue = dsemp.Tables[0].Rows[0]["currentstatus"].ToString();
                }
                else
                {
                    ddlCurrentStatus.SelectedValue = "0";
                }
                if (dsemp.Tables[0].Rows[0]["currentstatus"].ToString()=="2")
                {
                    trotherstatus.Visible = true;
                    txtStatusOthers.Text = dsemp.Tables[0].Rows[0]["csothers"].ToString();
                }
                else
                {
                    trotherstatus.Visible = false;
                    txtStatusOthers.Text = "";
                }
                if (dsemp.Tables[0].Rows[0]["TIHCL"].ToString() == "Y" || dsemp.Tables[0].Rows[0]["TIHCL"].ToString() == "N")
                {
                    rbtTIHCL.SelectedValue = dsemp.Tables[0].Rows[0]["TIHCL"].ToString();

                }
                if (rbtTIHCL.SelectedValue == "N")
                {
                    Trreason.Visible = true;
                    Txtreason.Text = dsemp.Tables[0].Rows[0]["reason"].ToString();

                }
                else
                {
                    Trreason.Visible = false;
                    Txtreason.Text = "";
                }
                hdfID.Value = dsemp.Tables[0].Rows[0]["intClosedUnitid"].ToString();

                BtnSave1.Text = "Update";
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
   
    protected void gvCertificate0_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }   
    protected void BtnClear1_Click(object sender, EventArgs e)
    {
      
    }

    protected void ddlintLineofActivity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void TxtNameofUnit_TextChanged(object sender, EventArgs e)
    {

    }



    protected void ddlCurrentStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCurrentStatus.SelectedItem.Text == "Others")
        {
            trotherstatus.Visible = true;
            txtStatusOthers.Text = "";
        }
        else
        {
            trotherstatus.Visible = false;
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


    protected void ddlProp_intDistrictid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProp_intDistrictid.SelectedIndex == 0)
        {
            ddlUnitMandal.Items.Clear();
            // ddlUnitMandal.Items.Insert(0, "--Mandal--");
            AddSelect(ddlUnitMandal);
        }
        else
        {
            ddlUnitMandal.Items.Clear();
            DataSet dsm = new DataSet();
            // added newly for testing only

            //if (ddlUnitDIst.SelectedValue == "Medchal")
            //{
            //    ddlUnitDIst.SelectedValue = "20";
            //}

            dsm = Gen.GetMandals(ddlProp_intDistrictid.SelectedValue);
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
        }
        
    }
    protected void rbtTIHCL_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txtreason.Text = "";
        if (rbtTIHCL.SelectedValue == "N")
        {
            Trreason.Visible = true;
        }
        else
        {
            Trreason.Visible = false;
        }


    }

}
