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
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {


            getdistricts();
            //fillGrid();
        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }


    protected void getdistricts()
    {
        DataSet dsnew = new DataSet();

        dsnew = Gen.GetDistricts();
        ddlLand_intDistrictid.DataSource = dsnew.Tables[0];
        ddlLand_intDistrictid.DataTextField = "District_Name";
        ddlLand_intDistrictid.DataValueField = "District_Id";
        ddlLand_intDistrictid.DataBind();
        ddlLand_intDistrictid.Items.Insert(0, "--Select--");

    }
    void fillGrid()
    {

        DataSet dsn = new DataSet();
        // dsn = Gen.GetShowDepartmentFiles("%");
        // Session["User_Code"] = "1";
        // dsn = Gen.GetShowDepartmentFiles(Session["User_Code"].ToString().Trim());
        //dsn = Gen.GetShowDepartmentFiles("15", "3", "5");

        //dsn = Gen.GetCompletedbyApproval("12", txtFromDate.Text, txtToDate.Text);

        dsn = Gen.GetdataofCertificate(txtnameofUnit.Text, txtUID.Text, ddlLand_intDistrictid.SelectedValue.ToString(), ddlLand_intDistrictid0.SelectedValue.ToString(), ddlquantityper.SelectedValue);
        if (ddlquantityper.SelectedValue == "CFE" || ddlquantityper.SelectedValue == "HOTELCFE" || ddlquantityper.SelectedValue == "EVENTS" || ddlquantityper.SelectedValue == "AGENCY"
            || ddlquantityper.SelectedValue == "FDC" || ddlquantityper.SelectedValue == "MULTIPLEX" || ddlquantityper.SelectedValue == "MOBILE" || ddlquantityper.SelectedValue == "ADV" || ddlquantityper.SelectedValue == "LIQUOR" || ddlquantityper.SelectedValue == "BMW" || ddlquantityper.SelectedValue == "LEGAL")
        {
            if (dsn.Tables[0].Rows.Count > 0)
            {
                trinc.Visible = false;
                trcfecfo.Visible = true;
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[5].Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        else if (ddlquantityper.SelectedValue == "CFO" || ddlquantityper.SelectedValue == "HOTELCFO" || ddlquantityper.SelectedValue == "EXBR" || ddlquantityper.SelectedValue == "EXLAB" || ddlquantityper.SelectedValue == "EXIMP" || ddlquantityper.SelectedValue == "EXEXP")
        {
            if (dsn.Tables[0].Rows.Count > 0)
            {
                trinc.Visible = false;
                trcfecfo.Visible = true;
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[5].Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        else if (ddlquantityper.SelectedValue == "REN")
        {
            if (dsn.Tables[0].Rows.Count > 0)
            {
                trinc.Visible = false;
                trcfecfo.Visible = true;
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[5].Visible = true;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        else if (ddlquantityper.SelectedValue == "Plot")
        {
            if (dsn.Tables[0].Rows.Count > 0)
            {
                trinc.Visible = false;
                trcfecfo.Visible = true;
                grdDetails.DataSource = dsn.Tables[0];
                grdDetails.DataBind();
                grdDetails.Columns[6].Visible = true;
                //grdDetails.Columns[5].Visible = false;
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        else if (ddlquantityper.SelectedValue == "INC")
        {
            if (dsn.Tables[0].Rows.Count > 0)
            {
                trinc.Visible = true;
                trcfecfo.Visible = false;
                GridView1.DataSource = dsn.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        //DataSet ds = new DataSet();
        //ds = gen.getReleaseProceedingsUser(userid);
        //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //{
        //    // tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
        //    grdDetails.DataSource = ds.Tables[0];
        //    grdDetails.DataBind();
        //}


    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label enterid = (e.Row.FindControl("lblEnterperIncentiveID") as Label);
            Label MstIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);

            Label lblOfflineFlag = (e.Row.FindControl("lblOfflineFlag") as Label);
            Label lbloffiline = (e.Row.FindControl("lbloffiline") as Label);

            if (MstIncentiveId.Text == "6")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantInvestmentSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "1")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPavalaVaddiSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "3")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantPowerCostSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "5")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSalesTaxSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "9")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantStampDutySubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "4")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantCleanerProductionSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "7")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantIIDFSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "8")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantskillupgradationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "10")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantSeedCapitalSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "11")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantQualityCertificationSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }
            if (MstIncentiveId.Text == "12")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl = "ProformaApplicantAdvanceSubsidyforSCSTSubsidy.aspx?incentiveid=" + enterid.Text.Trim();
            }


            if (lblOfflineFlag.Text.Trim() == "Y")
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = false;
                lbloffiline.Visible = true;
                lbloffiline.Text = "Offiline data";
            }
            else
            {
                (e.Row.FindControl("anchortagGMCertificate") as HyperLink).Visible = true;
                lbloffiline.Visible = false;
                lbloffiline.Text = "";
            }

        }
    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        fillGrid();
    }

    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {



    }
    void FillDetails()
    {


    }
    protected void BtnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("frmCFEcertificateProcess.aspx");
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

    }



    protected void GetNewRectoInsertdr()
    {

    }

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //HyperLink h1 = (HyperLink)e.Row.Cells[5].Controls[0];
            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IType")) == "I")
            {
                grdDetails.Columns[6].Visible = false;
                HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter");
                h2.NavigateUrl = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FileName"));
                h2.Text = "View";
            }
            else if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IType")) == "P")
            {
                grdDetails.Columns[5].Visible = false;
            }
            else
            {
                HyperLink h2 = (HyperLink)e.Row.FindControl("hypLetter");
                h2.NavigateUrl = "HDDocsDL1.aspx?type=2&id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCertificationid"));
                h2.Text = "View";
            }




            //string fromdate, Todate;
            //if (txtFromDate.Text == "" || txtToDate.Text == "")
            //{

            //    fromdate = "%";
            //    Todate = "%";
            //    h1.Text = "Approve";



            // h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();



            //}

            //else
            //{
            //    h1.Text = "Approve";
            //    fromdate = txtFromDate.Text;
            //    Todate = txtToDate.Text;
            //    h1.NavigateUrl = "frmApproveDetailsbyquery.aspx?No=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim() + "&FromDate=" + fromdate + "&ToDate=" + Todate;
            //}
        }
        //    HyperLink h1 = (HyperLink)e.Row.Cells[7].Controls[0];

        //    HyperLink h2 = (HyperLink)e.Row.Cells[8].Controls[0];
        //    HyperLink h3 = (HyperLink)e.Row.Cells[9].Controls[0];
        //    DropDownList ddlStatus = (DropDownList)e.Row.Cells[10].FindControl("ddlStatus");

        //    TextBox txtPromotor = (TextBox)e.Row.Cells[10].FindControl("txtPromotor");

        //    Label Label378 = (Label)e.Row.Cells[10].FindControl("Label378");

        //    HiddenField hdfApplID = (HiddenField)e.Row.Cells[10].FindControl("hdfApplID");
        //    hdfApplID.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intQuessionaireid")).Trim();

        //    HiddenField hdfGroundedNo = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo");

        //    hdfGroundedNo.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intCFEEnterpid")).Trim();

        //    HiddenField hdfGroundedNo0 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo0");

        //    hdfGroundedNo0.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intDeptid")).Trim();


        //    HiddenField hdfGroundedNo1 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo1");

        //    hdfGroundedNo1.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intApprovalid")).Trim();


        //    HiddenField hdfGroundedNo2 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo2");

        //    hdfGroundedNo2.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LastDateofPreScrutiy")).Trim();


        //    HiddenField hdfGroundedNo3 = (HiddenField)e.Row.Cells[11].FindControl("hdfGroundedNo3");

        //    hdfGroundedNo3.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "intStatusid")).Trim();


        //    if (ddlStatus.SelectedValue.ToString() == "8")
        //    {
        //        txtPromotor.Visible = true;
        //        Label378.Visible = true;

        //    }
        //    else
        //    {
        //        txtPromotor.Visible = false;
        //        Label378.Visible = false;


        //    }







        //}




    }
    //protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    DropDownList ddlStatus = (DropDownList)sender;
    //    GridViewRow row = (GridViewRow)ddlStatus.NamingContainer;
    //    TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

    //    Label Label378 = (Label)row.FindControl("Label378");

    //    //DropDownList ddlCorporation1 = (DropDownList)row.FindControl("ddlCorporation");
    //    //DropDownList ddlWard = (DropDownList)row.FindControl("ddlWard");
    //    //GetWards(ddlWard, ddlCorporation1.SelectedValue);

    //    ////DropDownList ddlStatus = (DropDownList).FindControl("ddlStatus");
    //    //Button BtnSave = (Button)sender;
    //    //GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
    //    //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");


    //    if (ddlStatus.SelectedValue.ToString() == "8")
    //    {
    //        txtPromotor.Visible = true;
    //        Label378.Visible = true;

    //    }

    //    else
    //    {
    //        txtPromotor.Visible = false;
    //        Label378.Visible = false;


    //    }

    //    // if(ddlStatus.)

    //    //if()


    //}
    protected void BtnSave_Click1(object sender, EventArgs e)
    {

        Button BtnSave = (Button)sender;

        GridViewRow row = (GridViewRow)BtnSave.NamingContainer;
        HiddenField hdfApplID = (HiddenField)row.FindControl("hdfApplID");

        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
        TextBox txtPromotor = (TextBox)row.FindControl("txtPromotor");

        HyperLink h1 = (HyperLink)row.FindControl("h1");

        HyperLink h2 = (HyperLink)row.FindControl("h2");

        HyperLink h3 = (HyperLink)row.FindControl("h3");

        HiddenField hdfGroundedNo = (HiddenField)row.FindControl("hdfGroundedNo");
        HiddenField hdfGroundedNo0 = (HiddenField)row.FindControl("hdfGroundedNo0");
        HiddenField hdfGroundedNo1 = (HiddenField)row.FindControl("hdfGroundedNo1");

        HiddenField hdfGroundedNo2 = (HiddenField)row.FindControl("hdfGroundedNo2");

        HiddenField hdfGroundedNo3 = (HiddenField)row.FindControl("hdfGroundedNo3");


        if (ddlStatus.SelectedValue.ToString() == "--Select--")
        {
            Failure.Visible = true;

            success.Visible = false;

            lblmsg.Text = "Please Select Status";


        }

        int result = 0;
        result = Gen.insertDepartmentProcess(hdfGroundedNo.Value, hdfGroundedNo0.Value, hdfGroundedNo1.Value, ddlStatus.SelectedValue.ToString(), hdfGroundedNo2.Value, Session["uid"].ToString().Trim());


        if (ddlStatus.SelectedValue.ToString() == "8")
        {

            //  int i= Gen.insertQueryResponsedata(result.ToString(), hdfGroundedNo.Value, txtPromotor.Text,ddlStatus.SelectedValue.ToString(), Session["uid"].ToString());
            int i = 1;

            if (i > 0)
            {

                success.Visible = true;
                Failure.Visible = false;
                lblmsg.Text = "Successfully Registered";
                return;

            }


        }

        if (result > 0)
        {


            success.Visible = true;
            Failure.Visible = false;
            lblmsg.Text = "Successfully Registered";


        }
        else
        {

            success.Visible = false;
            Failure.Visible = true;
            lblmsg.Text = "Failed..";


        }



        //else if (ddlStatus.SelectedValue.ToString() == "--Select--")
        //{
        //    Failure.Visible = true;

        //    success.Visible = false;

        //    lblmsg.Text = "Please Select Status";


        //}








    }
    protected void ddlquantityper_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlquantityper.SelectedValue == "INC")
        //{
        //    Label423.Text = "UID Number";
        //}
        //else
        //{
        //    Label423.Text = "UID Number";
        //}
    }
}
