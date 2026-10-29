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


public partial class UI_TSiPASS_frmInspRepDrft : System.Web.UI.Page
{

    int delete = 0;
    comFunctions cmf = new comFunctions();
    string inctiveID = "";
    General Gen = new General();
    //DataRow dtrdr;
    //DataTable myDtNewRecdr = new DataTable();

    DataRow dtrdr;
    string incentiveID = "";
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

    DataSet dsCAF = new DataSet();
    string ApplClm = "";
    string consUnit = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../frmUserLogin.aspx");
        }

        string IncIDfrData = Request.QueryString[0].ToString();

        DataSet ds = new DataSet();
        ds = Gen.GetIncentiveDeptDetails(IncIDfrData);
        FillDetailssdc(ds);

        DataSet dsInsp = new DataSet();

        dsInsp = Gen.GetIncentiveDeptDetails_InspReprt(IncIDfrData);
        FillDetailsInsp(dsInsp);

        dtMyTableCertificate = createtablecrtificate1();
        Session["CertificateTb2"] = dtMyTableCertificate;

        if (Request.QueryString["EntrpId"] != null)
        {

        }
    }

    #region getDetailsofInspReport
    public void getDetailsofInspReport()
    {
        DataSet ds;
        string IncentiveId = Request.QueryString["IncentiveId"].ToString();
        try
        {
            ds = Gen.GetIncentiveDeptDetails(IncentiveId);
            FillDetailssdc(ds);

        }
        catch
        {

        }
    }
    #endregion

    public void FillDetailssdc(DataSet ds)
    {
        string IncentID = "";
        DataSet oDataSet = new DataSet();
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //divCommonAppli.Visible = true;
                //IncentID = ds.Tables[0].Rows[0]["IncentveID"].ToString();
                lblUID.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                string UnitDistName = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                // ddlConstOfUnit.Visible = false;
                string UNITMANDAL = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                string UNITVILLAGE = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                string UnitHNO = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                string UnitStreet = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                string str = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                ApplClm = ds.Tables[0].Rows[0]["created_dt"].ToString();
                txtRcptAppln.Text = ds.Tables[0].Rows[0]["created_dt"].ToString();
                

                txtUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtApplicantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                txtPanNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtTinNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();

                ddlCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                ddltypeofOrg.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();

                ddlindustryStatus.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();

                // rblCaste.Text = ds.Tables[0].Rows[0]["Caste"].ToString();

                ddldistrictoffc.Text = ds.Tables[0].Rows[0]["OFFCDISTNAME"].ToString();
                ddloffcmandal.Text = ds.Tables[0].Rows[0]["OFFCMANDAL"].ToString();
                ddlvilloffc.Text = ds.Tables[0].Rows[0]["OFFCVILLAGE"].ToString();
                txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                txtstreetoffice.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

            //  string IncIDfrData = "1090";

                //Label1.Text = "Line of Activity for " + str.ToString();

                //oDataSet = Gen.GETINCENTIVESCAFDATA_INSP(IncIDfrData);
                //gvLOA.Visible = true;
                //gvLOA.DataSource = oDataSet.Tables[0];
                //gvLOA.DataBind();

                //if (oDataSet.Tables[0].Rows.Count == 0)
                //{

                //    Label1.Text = "Line of Activity Not Available, Shortfall may be informed to GM";
                //    Label1.ForeColor = System.Drawing.Color.Red;
                //    gvLOA.Visible = false;
                //}
                if (ds.Tables[0].Rows[0]["TSCPflag"].ToString() == "Y") //   if (caste == "3" || caste == "4")   //SC, ST
                {
                    lblheadTPRIDE.Text = "<center>T-PRIDE (TSCP)</center>";
                }
                else if (ds.Tables[0].Rows[0]["TSPflag"].ToString() == "Y")
                {
                    lblheadTPRIDE.Text = "<center>T-PRIDE (TSP)</center>";
                }
                else if (ds.Tables[0].Rows[0]["TIDEAflag"].ToString() == "Y")
                {
                    lblheadTPRIDE.Text = "<center>T-IDEA</center>";
                }
            }
            if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
            {
                lblInspectr.Text = ds.Tables[5].Rows[0]["empname"].ToString() + ", " + ds.Tables[5].Rows[0]["Designation"].ToString();

                
            }
        }
    }

    //return IncentID;

    public void FillDetailsInsp(DataSet ds)
    {

        try
        {
            DataSet oDataSet = new DataSet();
            string IncIDfrData = Request.QueryString[0].ToString();

            oDataSet = Gen.GETINCENTIVESCAFDATA_INSP_Report(IncIDfrData);
            ds = Gen.GETINCENTIVESCAFDATA_INSP(IncIDfrData);

            gvLOA.Visible = true;
            gvLOA.DataSource = ds.Tables[1];
            gvLOA.DataBind();
            if (oDataSet.Tables[0].Rows[0]["DCPNew"].ToString() != "01/01/1900")
            {
                lblDCP.Text = oDataSet.Tables[0].Rows[0]["DCPNew"].ToString();
            }
            //if (oDataSet.Tables[0].Rows[0]["ApplClmNew"].ToString() != "01/01/1900")
            //{
            //    txtRcptAppln.Text = oDataSet.Tables[0].Rows[0]["ApplClmNew"].ToString();
            //}
            if (oDataSet.Tables[0].Rows[0]["DateShrtfallNew"].ToString() != "01/01/1900")
            {
                txtDateShrtfall.Text = oDataSet.Tables[0].Rows[0]["DateShrtfallNew"].ToString();
            }
            if (oDataSet.Tables[0].Rows[0]["DtShrtFallRcvdNew"].ToString() != "01/01/1900")
            {
                txtDtShrtFallRcvd.Text = oDataSet.Tables[0].Rows[0]["DtShrtFallRcvdNew"].ToString();
            }

            txtLndCst25Prcnt.Text = oDataSet.Tables[0].Rows[0]["LndCst25Prcny"].ToString();
            txtRegnFee25Prcnt.Text = oDataSet.Tables[0].Rows[0]["RegnFee25Prcnt"].ToString();
            txtProprtn25Prcnt.Text = oDataSet.Tables[0].Rows[0]["Proprtn25Prcnt"].ToString();
            txt25BldCvl.Text = oDataSet.Tables[0].Rows[0]["Clm25PBldgCvl"].ToString();
            txtTotal25Prcnt.Text = oDataSet.Tables[0].Rows[0]["Total25Prcnt"].ToString();
            txtAprdPjCst25Prcnt.Text = oDataSet.Tables[0].Rows[0]["AprdPjCst25Prcnt"].ToString();
            txtComputedcost.Text = oDataSet.Tables[0].Rows[0]["Computedcost25"].ToString();

            txtTotVal1.Text = oDataSet.Tables[0].Rows[0]["TotVal1"].ToString();
            txtTotVal2.Text = oDataSet.Tables[0].Rows[0]["TotVal2"].ToString();
            txtTotVal3.Text = oDataSet.Tables[0].Rows[0]["TotVal3"].ToString();
            txtTotVal4.Text = oDataSet.Tables[0].Rows[0]["TotVal4"].ToString();
            txtTotVal10.Text = oDataSet.Tables[0].Rows[0]["TotVal10"].ToString();

            txtValofItems.Text = oDataSet.Tables[0].Rows[0]["ValofItems"].ToString();
            txtPlnthArea.Text = oDataSet.Tables[0].Rows[0]["PlnthArea"].ToString();
            txtTSSFC.Text = oDataSet.Tables[0].Rows[0]["TSSFC"].ToString();
            txtAprvPJVal.Text = oDataSet.Tables[0].Rows[0]["AprvPJVal"].ToString();
            txtAppJTot.Text = oDataSet.Tables[0].Rows[0]["AppJTot"].ToString();
            txtGrndTotVal.Text = oDataSet.Tables[0].Rows[0]["GrndTotVal"].ToString();


            txtAsperApprvdCost.Text = oDataSet.Tables[0].Rows[0]["AsprAppPjCostPM"].ToString();
            txtAsperCivilEngr.Text = oDataSet.Tables[0].Rows[0]["AsperCivilEngr"].ToString();
            txtComptdGm.Text = oDataSet.Tables[0].Rows[0]["ComptdGm"].ToString();
            txtComputedCostApprPrj.Text = oDataSet.Tables[0].Rows[0]["Comptedcst"].ToString();

            txtTotCstCmptdLand.Text = oDataSet.Tables[0].Rows[0]["totCstCmptdLand"].ToString();
            txtTotCstCmptdBldg.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdBldg"].ToString();
            txtTotCstCmptdPlntMach.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdPlntMach"].ToString();
            txtTotCstCmptdTotal.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdTotal"].ToString();

            txtInvSubsidyVal.Text = oDataSet.Tables[0].Rows[0]["InvSubsidyVal"].ToString();
            txtAddnInvSubsdyWmn.Text = oDataSet.Tables[0].Rows[0]["addnInvSubsdyWmn"].ToString();
            txtInvSubsdySCST.Text = oDataSet.Tables[0].Rows[0]["invSubsdySCS"].ToString();
            txtAddnInvSbsdySc10Prcnt.Text = oDataSet.Tables[0].Rows[0]["addnInvSbsdySc10Prcnt"].ToString();
            //txtTotalInv.Text= oDataSet.Tables[0].Rows[0]["TotInv"].ToString();

           // lbltotalinvestsubsidy.Text = (Convert.ToInt32(txtInvSubsidyVal.Text.Trim()) + Convert.ToInt32(txtAddnInvSubsdyWmn.Text.Trim()) + Convert.ToInt32(txtAddnInvSbsdySc10Prcnt.Text.Trim())).ToString();
            lbltotalinvestsubsidy.Text = (Convert.ToDecimal(txtInvSubsidyVal.Text.Trim()) + Convert.ToDecimal(txtAddnInvSubsdyWmn.Text.Trim()) +
                                          Convert.ToDecimal(txtAddnInvSbsdySc10Prcnt.Text.Trim())).ToString();

            //  txtInvSubsidyVal.Text = oDataSet.Tables[0].Rows[0]["investmentSubs"].ToString();
            // txtPower.Text= oDataSet.Tables[0].Rows[0]["Powerr"].ToString();


            txtExtent.Text = oDataSet.Tables[0].Rows[0]["Extent"].ToString();
            txt5TtimesBltup.Text = oDataSet.Tables[0].Rows[0]["TtimesBltup"].ToString();
            txtBuiltupAra.Text = oDataSet.Tables[0].Rows[0]["BuiltupAra"].ToString();
            txtExtentElgble.Text = oDataSet.Tables[0].Rows[0]["ExtentElgble"].ToString();

            lblDateofIns.Text = oDataSet.Tables[0].Rows[0]["InpectedDate"].ToString();
            lblPerson.Text = oDataSet.Tables[0].Rows[0]["PersonIndustry"].ToString();
            //txtTotCstCmptdLand.Text= oDataSet.Tables[1][]
            lblIPORemarks.Text = oDataSet.Tables[0].Rows[0]["txtremarks"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected DataTable createtablecrtificate1()
    {
        dtMyTable1 = new DataTable("CertificateTb1");

        dtMyTable1.Columns.Add("new", typeof(string));
        dtMyTable1.Columns.Add("Column1", typeof(string));
        dtMyTable1.Columns.Add("Column2", typeof(string));
        dtMyTable1.Columns.Add("Column3", typeof(string));
        dtMyTable1.Columns.Add("Column4", typeof(string));
        dtMyTable1.Columns.Add("Column5", typeof(string));
        dtMyTable1.Columns.Add("Column6", typeof(string));
        dtMyTable1.Columns.Add("Column7", typeof(string));
        dtMyTable1.Columns.Add("Created_by", typeof(string));

        dtMyTable1.Columns.Add("intLineofActivityMid", typeof(string));

        return dtMyTable1;
    }

    protected void gvInstalledCap_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void gvInstalledCap_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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

    public void DisableForm(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Enabled = false;
            if (ctrl is Button)
                ((Button)ctrl).Enabled = false;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).Enabled = false;
            else if (ctrl is CheckBox)
                ((CheckBox)ctrl).Enabled = false;
            else if (ctrl is RadioButton)
                ((RadioButton)ctrl).Enabled = false;


            DisableForm(ctrl.Controls);
        }
    }

    protected void txtTotCstCmptdPlntMach_TextChanged(object sender, EventArgs e)
    {

    }
}