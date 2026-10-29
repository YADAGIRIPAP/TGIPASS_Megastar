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
        try
        {
            if (Session.Count <= 0)
            {
                //// Response.Redirect("../../frmUserLogin.aspx");
                // Response.Redirect("~/Index.aspx");
            }
            if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "0")
            {

                //FillDetails();
                //Failure.Visible = false;
                //success.Visible = false;
                //BtnSave1.Text = "Update";
                ////lblresult.Text = "";
                ////Btnsave.Enabled = true;
                //hdfFlagID.Value = "";
            }
            if (!IsPostBack)
            {
                fillgrid();
                success.Visible = false;
                Failure.Visible = false;
                //ddlMonth.SelectedIndex = System.DateTime.Now.Month;
                //ddlYear.SelectedValue = ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Value;
                //ddlMonth.Enabled = false;
                //ddlYear.Enabled = false;


                //DataSet dsc = new DataSet();
                //dsc = Gen.GetCategoryDet();
                //ddlintLineofActivity.DataSource = dsc.Tables[0];
                //ddlintLineofActivity.DataValueField = "intLineofActivityid";
                //ddlintLineofActivity.DataTextField = "LineofActivity_Name";
                //ddlintLineofActivity.DataBind();
                //ddlintLineofActivity.Items.Insert(0, "--Select--");


                //    getIPOS();



                //DataSet dscheck1 = new DataSet();
                //dscheck1 = Gen.GetIPoSubsidydetails(Session["uid"].ToString().Trim(),ddlMonth.SelectedValue,ddlYear.SelectedValue);
                //if (dscheck1.Tables[0].Rows.Count > 0)
                //{
                //    FillDetails();
                //    //Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
                //}

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }
    //protected void getIPOS()
    //{
    //    DataSet dsnew = new DataSet();
    //    dsnew = Gen.GetIPOS(Session["uid"].ToString());

    //    ddlIPOname.DataSource = dsnew.Tables[0];
    //    ddlIPOname.DataTextField = "Dept_Name";
    //    ddlIPOname.DataValueField = "intUserid";
    //    ddlIPOname.DataBind();
    //    ddlIPOname.Items.Insert(0, "--Select--");
    //}






    //protected void BtnSave_Click(object sender, EventArgs e)
    //{
    //    if (BtnSave1.Text == "Save")
    //    {
    //        int i = Gen.InsertAdvancedSubsidy(ddlIPOname.SelectedValue, ddlMonth.SelectedValue, ddlYear.SelectedValue, txtPromoterName.Text, txtBeneficaryName.Text, txtbeneficiaryAddress.Text, txtFirstDate.Text, txtFirstAmount.Text, txtSecondDate.Text, txtSecondAmount.Text, ddlCaste.SelectedValue, ddlStatus.SelectedValue, txtRemarks.Text, ddlintLineofActivity.SelectedValue, Session["uid"].ToString(), "1");
    //        if (i > 0)
    //        {

    //            lblmsg.Text = "Added Successfully..!";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            clear();
    //        }
    //    }
    //    else if (BtnSave1.Text == "Update")
    //    {
    //        int i = Gen.InsertAdvancedSubsidy(ddlIPOname.SelectedValue,ddlMonth.SelectedValue, ddlYear.SelectedValue, txtPromoterName.Text, txtBeneficaryName.Text, txtbeneficiaryAddress.Text, txtFirstDate.Text, txtFirstAmount.Text, txtSecondDate.Text, txtSecondAmount.Text, ddlCaste.SelectedValue, ddlStatus.SelectedValue, txtRemarks.Text, ddlintLineofActivity.SelectedValue, Session["uid"].ToString(), hdfID.Value.ToString().Trim());

    //        if (i > 0)
    //        {

    //            lblmsg.Text = "Updated Successfully..!";
    //            success.Visible = true;
    //            Failure.Visible = false;
    //            clear();
    //        }

    //    }
    //}
    //void clear()
    //{

    //    txtPromoterName.Text = ""; txtBeneficaryName.Text = ""; txtbeneficiaryAddress.Text = ""; txtFirstDate.Text = ""; txtFirstAmount.Text = ""; txtSecondDate.Text = ""; txtSecondAmount.Text = ""; ddlCaste.SelectedIndex = 0; ddlStatus.SelectedIndex = 0; txtRemarks.Text = ""; ddlintLineofActivity.SelectedIndex = 0; ddlIPOname.SelectedIndex = 0;

    //    BtnSave1.Text = "Save";




    //}



    //void FillDetails()
    //{

    //    DataSet dscheck1 = new DataSet();
    //    dscheck1 = Gen.GetIPoSubsidydetails(hdfID.Value);
    //    if (dscheck1.Tables[0].Rows.Count > 0)
    //    {
    //        ddlIPOname.SelectedValue = dscheck1.Tables[0].Rows[0]["intIPOid"].ToString();
    //        txtPromoterName.Text = dscheck1.Tables[0].Rows[0]["Promoter_Name"].ToString();
    //        txtBeneficaryName.Text = dscheck1.Tables[0].Rows[0]["NameofUnit"].ToString();
    //        txtbeneficiaryAddress.Text = dscheck1.Tables[0].Rows[0]["AddressofUnit"].ToString();
    //        txtFirstDate.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["DateofReleaseFirstInstalment"].ToString()).ToString("dd-MM-yyyy");
    //        txtFirstAmount.Text = dscheck1.Tables[0].Rows[0]["FirstInstalment"].ToString();
    //        txtSecondDate.Text = Convert.ToDateTime(dscheck1.Tables[0].Rows[0]["DateofReleaseSecondInstalment"].ToString()).ToString("dd-MM-yyyy");
    //        txtSecondAmount.Text = dscheck1.Tables[0].Rows[0]["SecondInstalment"].ToString();
    //        ddlCaste.SelectedValue = dscheck1.Tables[0].Rows[0]["Caste"].ToString();
    //        ddlStatus.SelectedValue = dscheck1.Tables[0].Rows[0]["CurrentStatus"].ToString();
    //        txtRemarks.Text = dscheck1.Tables[0].Rows[0]["Remarks"].ToString();
    //        ddlintLineofActivity.SelectedValue = dscheck1.Tables[0].Rows[0]["intLineofActivity"].ToString();
    //       // Label442.Text = dscheck1.Tables[0].Rows[0]["intAdvanceSubsidyid"].ToString();
    //        hdfID.Value = dscheck1.Tables[0].Rows[0]["intAdvanceSubsidyid"].ToString();
    //        BtnSave1.Text = "Update";
    //    }


    //}    
    //protected void BtnClear_Click(object sender, EventArgs e)
    //{
    //    clear();

    //}
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
        ddlmonth0.SelectedIndex = 0;
        ddlyear0.SelectedIndex = 0;
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
    protected void txtUidno_TextChanged(object sender, EventArgs e)
    {

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
        try
        {
            fillgrid();
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
        // txtUidno0.Text = "";
        // ddlmonth0.SelectedIndex = 0;
        // ddlyear0.SelectedIndex = 0;
    }
    void fillgrid()
    {

        try
        {
            DataSet ds = new DataSet();

            //ds = Gen.Searchadvsubsidydetails1(Session["uid"].ToString(), ddlmonth0.SelectedValue.ToString(), ddlyear0.SelectedValue.ToString());

            ds = Gen.Searchadvsubsidydetails1Pending(Request.QueryString[0].ToString(), Request.QueryString[1].ToString(), Request.QueryString[2].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                gvCertificate0.DataSource = ds.Tables[0];
                gvCertificate0.DataBind();
                lblmsg.Text = "";
                //          success.Visible = true;
                //        Failure.Visible = false;


            }
            else
            {
                //      success.Visible = false;
                //    Failure.Visible = true;
                lblmsg0.Text = "No Records found.";
                gvCertificate0.DataSource = null;
                gvCertificate0.DataBind();
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
