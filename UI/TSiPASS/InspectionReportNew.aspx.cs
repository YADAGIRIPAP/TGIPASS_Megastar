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
using BusinessLogic;

public partial class UI_TSiPASS_InspectionReportNew : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    string inctiveID = "";
    General Gen = new General();
    Fetch objFetch = new Fetch();
    string casteGenderGmUpdate = "0";
    InspectionReportVOs oInspectionReportVOs = new InspectionReportVOs();

    List<InpectionGrid422Vos> listInpectionGrid422Vos = new List<InpectionGrid422Vos>();

    List<InpectionGrid423Vos> listInpectionGrid423Vos = new List<InpectionGrid423Vos>();

    List<InpectionGridLOAVos> listInpectionGridLOAVos = new List<InpectionGridLOAVos>();

    List<InpectionGridExpVos> listInpectionGridExpVos = new List<InpectionGridExpVos>();

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
        try
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    string IncIDfrData = Request.QueryString[0].ToString();
                    ViewState["IncentveID"] = Request.QueryString[0].ToString();
                    BindConstitutionUnit();
                    DataSet ds = new DataSet();
                    ds = Gen.GetInspectionReportData(IncIDfrData);
                    if (ds.Tables.Count > 5)
                    {
                        if (ds.Tables[5].Rows.Count > 0)
                        {
                            if (ds.Tables[5].Rows[0]["OLDRECORD"].ToString() == "Y" || IncIDfrData == "18646")
                            {
                                string EntrpId = Request.QueryString[0].ToString();
                                string Inctypeid = "6";
                                Response.Redirect("frmInspRepDrft.aspx?EntrpId=" + EntrpId + "&Inctypeid=" + Inctypeid + "");
                            }
                        }
                    }

                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        trNewindusNew.Visible = true;
                        Label1.Text = "3.1 " + " New Industry / Existing";
                        DataTable dtNewIndustry = new DataTable();
                        dtNewIndustry.Columns.AddRange(new DataColumn[1] { new DataColumn("NatureofAssets", typeof(string)) });
                        dtNewIndustry.Rows.Add("Land");
                        dtNewIndustry.Rows.Add("Building");
                        dtNewIndustry.Rows.Add("Plant & Machinery");
                        gvFixedCapitalInvestment.DataSource = dtNewIndustry;
                        gvFixedCapitalInvestment.DataBind();
                        trFixedCapitalInvestment.Visible = true;

                        trExpansionDriverNew.Visible = true;
                        Label2.Text = "3.2 " + " Expansion / Diversification";
                        DataTable dtExpansionDiversification = new DataTable();
                        dtExpansionDiversification.Columns.AddRange(new DataColumn[1] { new DataColumn("StatusIndustry", typeof(string)) });
                        //dtExpansionDiversification.Rows.Add("Existing Enterprise");
                        dtExpansionDiversification.Rows.Add("Expansion/Diversification");
                        gvExpansionDriverNew.DataSource = dtExpansionDiversification;
                        gvExpansionDriverNew.DataBind();

                        FillInspectionReportDetails(ds);
                        DisableForm(Controls);

                        trsubmit.Visible = false;
                        divbtnprint.Visible = true;
                        btnprint.Enabled = true;//check
                    }
                    else
                    {
                        ds = Gen.GetIncentiveDeptDetails(IncIDfrData);
                        FillDetails(ds);

                        txtTotCstCmptdLand_TextChanged(sender, e);

                        trNewindusNew.Visible = true;
                        Label1.Text = "3.1 " + " New Industry / Existing";
                        DataTable dtNewIndustry = new DataTable();
                        dtNewIndustry.Columns.AddRange(new DataColumn[1] { new DataColumn("NatureofAssets", typeof(string)) });
                        dtNewIndustry.Rows.Add("Land");
                        dtNewIndustry.Rows.Add("Building");
                        dtNewIndustry.Rows.Add("Plant & Machinery");
                        gvFixedCapitalInvestment.DataSource = dtNewIndustry;
                        gvFixedCapitalInvestment.DataBind();
                        trFixedCapitalInvestment.Visible = true;

                        //if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "New Industry" && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != null && ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "")
                        //{
                        // if condition added on 16.02.2018 by chh
                        trExpansionDriverNew.Visible = true;
                        Label2.Text = "3.2 " + " Expansion / Diversification";
                        DataTable dtExpansionDiversification = new DataTable();
                        dtExpansionDiversification.Columns.AddRange(new DataColumn[1] { new DataColumn("StatusIndustry", typeof(string)) });
                        //dtExpansionDiversification.Rows.Add("Existing Enterprise");
                        dtExpansionDiversification.Rows.Add("Expansion/Diversification");
                        gvExpansionDriverNew.DataSource = dtExpansionDiversification;
                        gvExpansionDriverNew.DataBind();
                        //}

                        ddlStatus_SelectedIndexChanged(sender, e);
                    }
                    DataSet dsnewre = new DataSet();
                    dsnewre = Gen.GetIncetiveDetailsdeptAttachementsIpo(IncIDfrData, "6");

                    if (dsnewre != null && dsnewre.Tables.Count > 0 && dsnewre.Tables[0].Rows.Count > 0)
                    {
                        GridView3att.DataSource = dsnewre.Tables[0];
                        GridView3att.DataBind();
                    }

                    dtMyTableCertificate = createtablecrtificate1();
                    Session["CertificateTb1"] = dtMyTableCertificate;

                    dtMyTableCertificate1 = createtablecrtificate2();
                    Session["CertificateTb2"] = dtMyTableCertificate1;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    #region getDetailsofInspReport
    public void getDetailsofInspReport()
    {
        DataSet ds;
        string IncentiveId = Request.QueryString["EntrpId"].ToString();
        try
        {
            ds = Gen.GetIncentiveDeptDetails(IncentiveId);
            FillDetails(ds);
        }
        catch
        {

        }
    }
    #endregion
    protected void GridView3att_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lbl") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
                // CheckBox chkverified = (e.Row.FindControl("chkverified") as CheckBox);
                RadioButtonList rbtverified = (e.Row.FindControl("rbtverified") as RadioButtonList);
                //string sennew = HyperLinkSubsidy.Text;
                //string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                //HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                Label lblVerifiednew = (e.Row.FindControl("lblVerified") as Label);
                string filepathnew = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LINKNEW"));
                if (filepathnew != "")
                {
                    string encpassword = Gen.Encrypt(filepathnew, "SYSTIME");
                    HyperLinkSubsidy.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                }
                else
                {
                    HyperLinkSubsidy.Visible = false;
                }
                //if (lbl.Text == "")
                //{
                //    HyperLinkSubsidy.Visible = false;
                //    e.Row.Font.Bold = true;
                //    chkverified.Visible = false;
                //}
                //if (HyperLinkSubsidy.NavigateUrl == "")
                //{
                //    HyperLinkSubsidy.Visible = false;
                //    chkverified.Visible = false;
                //}
                //if (lblVerifiednew.Text == "YES" && chkverified.Visible == true)
                //{

                //    chkverified.Checked = true;
                //    chkverified.Enabled = false;
                //}
                if (lbl.Text == "")
                {
                    HyperLinkSubsidy.Visible = false;
                    e.Row.Font.Bold = true;
                    rbtverified.Visible = false;
                }
                if (HyperLinkSubsidy.NavigateUrl == "")
                {
                    HyperLinkSubsidy.Visible = false;
                    rbtverified.Visible = false;
                }
                if (lblVerifiednew.Text == "YES" && rbtverified.Visible == true)
                {

                    rbtverified.SelectedValue = "Y";
                    rbtverified.Enabled = false;
                }
                if (lblVerifiednew.Text == "WRONG" && rbtverified.Visible == true)
                {

                    rbtverified.SelectedValue = "N";
                    rbtverified.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    public void FillDetails(DataSet ds)
    {
        try
        {
            DataSet oDataSet = new DataSet();
            if (ds != null)
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["lblUdyogAdhar"] = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                    ViewState["lblnameofIND"] = ds.Tables[0].Rows[0]["UnitDtls"].ToString();  //ds.Tables[0].Rows[0]["UnitName"].ToString();
                    ViewState["OrgType2"] = ds.Tables[0].Rows[0]["OrgType2"].ToString();
                    ddlUnitCons.SelectedItem.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();

                    lblnameofIND.Text = ds.Tables[0].Rows[0]["UnitDtls"].ToString();
                    string UnitDistName = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                    // ddlConstOfUnit.Visible = false;
                    string UNITMANDAL = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                    string UNITVILLAGE = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString();
                    string UnitHNO = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                    string UnitStreet = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                    string str = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                    ViewState["IdsustryStatus"] = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();

                    // ApplClm = ds.Tables[0].Rows[0]["created_dt"].ToString();
                    // txtRcptAppln.Text = ds.Tables[0].Rows[0]["created_dt"].ToString(); // commented on 14.12.2017 by chhh
                    txtRcptAppln.Text = ds.Tables[0].Rows[0]["ApplliedDate"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        gvNewindus.DataSource = ds.Tables[1];
                        gvNewindus.DataBind();
                    }
                    //lblAddress.Text = "Sy no:" + UnitHNO + "," + "," + UNITVILLAGE + "(V)" + "," + UNITMANDAL + "(M)" + ",\n" + UnitDistName + "(Dist).";

                    lblDCP.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                    //  ddlStatus.SelectedItem.Text = str.ToString();  // commented on 23.02.2018

                    string indstatus2 = "";
                    indstatus2 = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                    if (indstatus2.ToUpper().Trim().Contains("NEW"))
                    {
                        ddlStatus.SelectedValue = "1";
                        // ddlStatus.SelectedItem.Text = "New Industry"; 
                    }
                    else if (indstatus2.ToUpper().Trim().Contains("EXPANSION"))
                    {
                        ddlStatus.SelectedValue = "2";
                    }
                    else if (indstatus2.ToUpper().Trim().Contains("DIVERSIFICATION"))
                    {
                        ddlStatus.SelectedValue = "3";
                    }

                    if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                    {
                        if (ds.Tables[5].Rows[0]["TobeinspectedDate"].ToString() != null)   //nulll value allow
                            txtInpectedDate.Text = ds.Tables[5].Rows[0]["TobeinspectedDate"].ToString();//changed nikhil

                        txtIPOName.Text = ds.Tables[5].Rows[0]["empname"].ToString();
                        lblIPODesignation.Text = ds.Tables[5].Rows[0]["Designation"].ToString();
                        //lblIPODesignation.Text = Session["uid"];
                    }
                    if (ds != null && ds.Tables.Count > 6 && ds.Tables[6].Rows.Count > 0)
                    {
                        if (ds.Tables[6].Rows[0]["queryRsdDate"].ToString() != null)  //nulll value allow
                            txtDateShrtfall.Text = ds.Tables[6].Rows[0]["queryRsdDate"].ToString();//changed nikhil

                        if (ds.Tables[6].Rows[0]["QueryRespondDate"].ToString() != null)  //nulll value allow, disable textbox.
                            txtDtShrtFallRcvd.Text = ds.Tables[6].Rows[0]["QueryRespondDate"].ToString();//changed nikhil
                    }
                    // 21.07.2017
                    if (ds != null && ds.Tables.Count > 2 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString() != null)
                        {
                            txtTotCstCmptdLand.Text = ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString();
                            ViewState["Land"] = ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString();
                        }

                        if (ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString() != null)
                        {
                            txtTotCstCmptdBldg.Text = ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString();
                            ViewState["Building"] = ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString();
                        }

                        if (ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString() != null)
                        {
                            txtTotCstCmptdPlntMach.Text = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                            ViewState["PlantMachinery"] = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                        }
                    }

                    //string IncIDfrData = Request.QueryString[0].ToString();
                    //Label1.Text = "Line of Activity for " + str.ToString();
                    //oDataSet = Gen.GETINCENTIVESCAFDATA_INSP(IncIDfrData);
                    //gvInstalledCap.Visible = true;
                    //gvInstalledCap.DataSource = oDataSet.Tables[1];
                    //gvInstalledCap.DataBind();

                    //if (oDataSet.Tables[1].Rows.Count == 0)
                    //{
                    //    Label1.Text = "Line of Activity Not Available, Shortfall may be informed to GM";
                    //    Label1.ForeColor = System.Drawing.Color.Red;
                    //    gvInstalledCap.Visible = false;
                    //}
                }
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected DataTable createtablecrtificate1()
    {
        try
        {
            dtMyTable1 = new DataTable("CertificateTb1");

            dtMyTable1.Columns.Add("new", typeof(string));
            dtMyTable1.Columns.Add("Column1", typeof(string));
            dtMyTable1.Columns.Add("Column2", typeof(string));
            dtMyTable1.Columns.Add("Column3", typeof(string));
            dtMyTable1.Columns.Add("Column4", typeof(string));
            dtMyTable1.Columns.Add("Created_by", typeof(string));

            dtMyTable1.Columns.Add("intLineofActivityMid", typeof(string));
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }

        return dtMyTable1;
    }
    protected DataTable createtablecrtificate2()
    {
        try
        {
            dtMyTable1 = new DataTable("CertificateTb2");

            dtMyTable1.Columns.Add("new", typeof(string));
            dtMyTable1.Columns.Add("Column1", typeof(string));
            dtMyTable1.Columns.Add("Column2", typeof(string));
            dtMyTable1.Columns.Add("Column3", typeof(string));
            dtMyTable1.Columns.Add("Column4", typeof(string));
            dtMyTable1.Columns.Add("Created_by", typeof(string));

            dtMyTable1.Columns.Add("intLineofActivityMid", typeof(string));
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }

        return dtMyTable1;
    }
    protected void gvExpansionDriverNew_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

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
            else if (ctrl is RadioButtonList)
                ((RadioButtonList)ctrl).Enabled = false;

            DisableForm(ctrl.Controls);
        }
    }
    protected void ddlqtyLOA_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtLndCst25Prcnt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal LndCst25Prcnt = 0;
            decimal Regnfee = 0;
            decimal RegnFee25Prcnt = 0;
            decimal Sum = 0;

            if (txtLndCst25Prcnt.Text != null && txtLndCst25Prcnt.Text != "")
            {
                LndCst25Prcnt = Convert.ToDecimal(txtLndCst25Prcnt.Text);
            }

            if (txtRegnfee.Text != null && txtRegnfee.Text != "")
            {
                Regnfee = Convert.ToDecimal(txtRegnfee.Text);
            }

            if (txtRegnFee25Prcnt.Text != null && txtRegnFee25Prcnt.Text != "")
            {
                RegnFee25Prcnt = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
            }
            txtTotal25Prcnt.Text = "";
            Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
            txtTotal25Prcnt.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtRegnfee_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal LndCst25Prcnt = 0;
            decimal Regnfee = 0;
            decimal RegnFee25Prcnt = 0;
            decimal Sum = 0;

            if (txtLndCst25Prcnt.Text != null && txtLndCst25Prcnt.Text != "")
            {
                LndCst25Prcnt = Convert.ToDecimal(txtLndCst25Prcnt.Text);
            }

            if (txtRegnFee25Prcnt.Text != null && txtRegnFee25Prcnt.Text != "")
            {
                RegnFee25Prcnt = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
            }

            if (txtRegnfee.Text != null && txtRegnfee.Text != "")
            {
                Regnfee = Convert.ToDecimal(txtRegnfee.Text);
            }

            txtTotal25Prcnt.Text = "";
            Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
            txtTotal25Prcnt.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }

    //protected void txtApprovedProjectcost_TextChanged(object sender, EventArgs e)
    //{
    //    decimal LndCst25Prcnt = 0;
    //    decimal Regnfee = 0;
    //    decimal RegnFee25Prcnt = 0;
    //    decimal Sum = 0;

    //    if (txtLndCst25Prcnt.Text != null && txtLndCst25Prcnt.Text != "")
    //    {
    //        LndCst25Prcnt = Convert.ToDecimal(txtLndCst25Prcnt.Text);
    //    }

    //    if (txtRegnFee25Prcnt.Text != null && txtRegnFee25Prcnt.Text != "")
    //    {
    //        Regnfee = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
    //    }

    //    if (txtRegnfee.Text != null && txtRegnfee.Text != "")
    //    {
    //        RegnFee25Prcnt = Convert.ToDecimal(txtRegnfee.Text);
    //    }

    //    Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
    //    //txtTotal25Prcnt.Text = Sum.ToString();
    //}

    protected void txtAprdPjCst25Prcnt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AprdPjCst25Prcnt = 0;
            decimal Computedcost = 0;

            if (txtAprdPjCst25Prcnt.Text != "")
            {
                AprdPjCst25Prcnt = Convert.ToDecimal(txtAprdPjCst25Prcnt.Text);
            }
            if (txtComputedcost.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtComputedcost.Text);
            }
            if (Computedcost > AprdPjCst25Prcnt)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtAprdPjCst25Prcnt.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtComputedcost_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AprdPjCst25Prcnt = 0;
            decimal Computedcost = 0;

            if (txtAprdPjCst25Prcnt.Text != "")
            {
                AprdPjCst25Prcnt = Convert.ToDecimal(txtAprdPjCst25Prcnt.Text);
            }
            if (txtComputedcost.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtComputedcost.Text);
            }
            if (Computedcost > AprdPjCst25Prcnt)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtComputedcost.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtBuiltupAra_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txt5TtimesBltup.Text = "";
            if (txtBuiltupAra.Text.Trim() != string.Empty || txtBuiltupAra.Text.Trim() != "")
            {
                txt5TtimesBltup.Text = (5 * Convert.ToDecimal(txtBuiltupAra.Text.Trim())).ToString();
                txtExtentElgble.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Built up area in Sq.Mtrs (Point Number 4.1.1)');", true);
                txtPersonIndustry.Focus();
                return;
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlStatus.SelectedValue == "New Industry")
            if (ddlStatus.SelectedItem.Text.Trim() == "New Industry")
            {
                enabledisable(true);
                foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
                {
                    TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                    TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                    TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                    TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                    LOA.Text = "NA";
                    InstalledCapacity.Text = "NA";
                    Units.Text = "NA";
                    ExpansionDiversification.Text = "0";

                    LOA.Enabled = false;
                    InstalledCapacity.Enabled = false;
                    Units.Enabled = false;
                    ExpansionDiversification.Enabled = false;
                }
                foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
                {
                    TextBox ExistingEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    if (gvrow.RowIndex == 0)
                    {
                        ExistingEnterprise.Text = ViewState["Land"].ToString();
                    }
                    if (gvrow.RowIndex == 1)
                    {
                        ExistingEnterprise.Text = ViewState["Building"].ToString();
                    }
                    if (gvrow.RowIndex == 2)
                    {
                        ExistingEnterprise.Text = ViewState["PlantMachinery"].ToString();
                    }
                    ExpansionDiversification.Text = "0";
                    ExpansionDiversificationincreasepercentage.Text = "0";

                    //ExistingEnterprise.Enabled = false;
                    ExpansionDiversification.Enabled = false;
                    ExpansionDiversificationincreasepercentage.Enabled = false;
                }
                txtExistingEnterprise_TextChanged(sender, e);
                //int sum = Convert.ToInt32(ViewState["Land"].ToString()) + Convert.ToInt32(ViewState["Building"].ToString()) + Convert.ToInt32(ViewState["PlantMachinery"].ToString());
                //txttotalNew.Text = sum.ToString();
            }
            // else if (ddlStatus.SelectedValue == "Expansion")
            else if (ddlStatus.SelectedItem.Text.Trim() == "Expansion")
            {
                enabledisable(true);
                foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
                {
                    TextBox ExistingEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    if (gvrow.RowIndex == 0)
                    {
                        ExistingEnterprise.Text = ViewState["Land"].ToString();
                    }
                    if (gvrow.RowIndex == 1)
                    {
                        ExistingEnterprise.Text = ViewState["Building"].ToString();
                    }
                    if (gvrow.RowIndex == 2)
                    {
                        ExistingEnterprise.Text = ViewState["PlantMachinery"].ToString();
                    }

                    //    ExistingEnterprise.Enabled = false; //  commented on 28.12.2017 by chh

                    txtExistingEnterprise_TextChanged(sender, e);
                    //int sum = Convert.ToInt32(ViewState["Land"].ToString()) + Convert.ToInt32(ViewState["Building"].ToString()) + Convert.ToInt32(ViewState["PlantMachinery"].ToString());
                    //txttotalNew.Text = sum.ToString();
                }
            }
            //else if (ddlStatus.SelectedValue == "Diversification")
            else if (ddlStatus.SelectedItem.Text.Trim() == "Diversification")
            {

                foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
                {
                    TextBox ExistingEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    if (gvrow.RowIndex == 0)
                    {
                        ExistingEnterprise.Text = ViewState["Land"].ToString();
                    }
                    if (gvrow.RowIndex == 1)
                    {
                        ExistingEnterprise.Text = ViewState["Building"].ToString();
                    }
                    if (gvrow.RowIndex == 2)
                    {
                        ExistingEnterprise.Text = ViewState["PlantMachinery"].ToString();
                    }

                    ExistingEnterprise.Enabled = false;

                    txtExistingEnterprise_TextChanged(sender, e);
                    //int sum = Convert.ToInt32(ViewState["Land"].ToString()) + Convert.ToInt32(ViewState["Building"].ToString()) + Convert.ToInt32(ViewState["PlantMachinery"].ToString());
                    //txttotalNew.Text = sum.ToString();
                }
                enabledisable(true);
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void btnAdd422New_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Failure.Visible = false;
        try
        {
            if (txt822guideline422.Text == "" || txt822guideline422.Text == null)
            {
                lblMsg420_2.Text = "Value of the items 8.2.2 to 8.2.10 of guideline Cannot be blank" + "<br/>";
                Failure0.Visible = true;
                txt822guideline422.Focus();
                valid = 1;
            }
            if (txtPlintharea422.Text == "" || txtPlintharea422.Text == null)
            {
                lblMsg420_2.Text = "Plinth Area Cannot be blank" + "<br/>";
                Failure0.Visible = true;
                txtPlintharea422.Focus();
                valid = 1;
            }
            if (txtTSSFCnorms422.Text == "" || txtTSSFCnorms422.Text == null)
            {
                lblMsg420_2.Text = "Rate as per the TSSFC norms Cannot be blank" + "<br/>";
                Failure0.Visible = true;
                txtTSSFCnorms422.Focus();
                valid = 1;
            }
            if (txtvalue422.Text == "" || txtvalue422.Text == null)
            {
                lblMsg420_2.Text = "Value Cannot be blank" + "<br/>";
                Failure0.Visible = true;
                txtvalue422.Focus();
                valid = 1;
            }
            if (valid == 0)
            {
                if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    AddDataToTableCeertificate(txt822guideline422.Text, txtPlintharea422.Text, txtTSSFCnorms422.Text, txtvalue422.Text, (DataTable)Session["CertificateTb1"]);

                    this.gv422.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                    this.gv422.DataBind();
                }
                else
                    if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificate(txt822guideline422.Text, txtPlintharea422.Text, txtTSSFCnorms422.Text, txtvalue422.Text, (DataTable)Session["CertificateTb1"]);
                        this.gv422.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gv422.DataBind();
                    }
                gv422.Visible = true;
                lblMsg420_2.Text = "";
                Failure0.Visible = false;

                txt822guideline422.Text = "";
                txtPlintharea422.Text = "";
                txtTSSFCnorms422.Text = "";
                txtvalue422.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void btnclear422New_Click(object sender, EventArgs e)
    {
        Failure.Visible = false;
        Failure0.Visible = false;

        txt822guideline422.Text = "";
        txtPlintharea422.Text = "";
        txtTSSFCnorms422.Text = "";
        txtvalue422.Text = "";
    }
    protected void btnclear423New_Click(object sender, EventArgs e)
    {
        Failure.Visible = false;
        Failure0.Visible = false;

        txt423guideline.Text = "";
        txtPlintharea423.Text = "";
        txtTSSFCnorms423.Text = "";
        txtvalue423.Text = "";
    }
    private void AddDataToTableCeertificate(string guidline822, string Plintharea, string TSSFCnorms, string Value, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb1");

            Row["new"] = "0";
            Row["Column1"] = guidline822;
            Row["Column2"] = Plintharea;
            Row["Column3"] = TSSFCnorms;
            Row["Column4"] = Value;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void btnAdd423New_Click(object sender, EventArgs e)
    {
        int valid = 0;
        Failure0.Visible = false;
        try
        {
            if (txt423guideline.Text == "" || txt822guideline422.Text == null)
            {
                lblMsg423_2.Text = "Value of the items 8.2.11 to 8.2.17 of guideline Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txt423guideline.Focus();
                valid = 1;
            }
            if (txtPlintharea423.Text == "" || txtPlintharea423.Text == null)
            {
                lblMsg423_2.Text = "Plinth Area Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtPlintharea423.Focus();
                valid = 1;
            }
            if (txtTSSFCnorms423.Text == "" || txtTSSFCnorms423.Text == null)
            {
                lblMsg423_2.Text = "Rate as per the TSSFC norms Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtTSSFCnorms423.Focus();
                valid = 1;
            }
            if (txtvalue423.Text == "" || txtvalue423.Text == null)
            {
                lblMsg423_2.Text = "Value Cannot be blank" + "<br/>";
                Failure.Visible = true;
                txtvalue423.Focus();
                valid = 1;
            }
            if (valid == 0)
            {
                if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    AddDataToTableCeertificate1(txt423guideline.Text, txtPlintharea423.Text, txtTSSFCnorms423.Text, txtvalue423.Text, (DataTable)Session["CertificateTb2"]);

                    this.gv423.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gv423.DataBind();
                }
                else
                    if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificate1(txt423guideline.Text, txtPlintharea423.Text, txtTSSFCnorms423.Text, txtvalue423.Text, (DataTable)Session["CertificateTb2"]);
                        this.gv423.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gv423.DataBind();
                    }
                gv423.Visible = true;
                lblMsg423_2.Text = "";
                Failure.Visible = false;

                txt423guideline.Text = "";
                txtPlintharea423.Text = "";
                txtTSSFCnorms423.Text = "";
                txtvalue423.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    private void AddDataToTableCeertificate1(string guidline823, string Plintharea, string TSSFCnorms, string Value, DataTable myTable)
    {
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");

            Row["new"] = "0";
            Row["Column1"] = guidline823;
            Row["Column2"] = Plintharea;
            Row["Column3"] = TSSFCnorms;
            Row["Column4"] = Value;
            Row["Created_by"] = Session["uid"].ToString().Trim();

            Row["intLineofActivityMid"] = "0";
            myTable.Rows.Add(Row);
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    public void BindConstitutionUnit()
    {
        DataSet dsdorg = new DataSet();
        try
        {
            dsdorg = objFetch.FetchConstitutionUnit();
            if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
            {
                ddlUnitCons.DataSource = dsdorg.Tables[0];
                ddlUnitCons.DataValueField = "CunitId";
                ddlUnitCons.DataTextField = "ConstitutionUnit";
                ddlUnitCons.DataBind();
                ddlUnitCons.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlUnitCons.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void gv422_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);

                this.gv422.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                this.gv422.DataBind();
            }
            else
            {
                if (hdfFlagID.Value.Trim() != "")
                {
                    try
                    {
                        string traineetradesnames = gv422.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                        DataSet dsna = new DataSet();
                        int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                        ((DataTable)Session["CertificateTb1"]).Rows.RemoveAt(e.RowIndex);
                        this.gv422.DataSource = ((DataTable)Session["CertificateTb1"]).DefaultView;
                        this.gv422.DataBind();
                    }
                    catch (Exception eee)
                    {
                        throw eee;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg420_2.Text = ex.Message;
        }
    }
    protected void gv423_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
            {
                ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                this.gv423.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                this.gv423.DataBind();
            }
            else
            {
                if (hdfFlagID.Value.Trim() != "")
                {
                    try
                    {
                        string traineetradesnames = gv423.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                        DataSet dsna = new DataSet();
                        int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                        ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                        this.gv423.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gv423.DataBind();
                    }
                    catch (Exception eee)
                    {
                        throw eee;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg423_2.Text = ex.Message;
        }
    }
    protected void gvNewindus_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gv422_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gv423_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    //public string insertDetailsofInspection()
    //{
    //    string Status;
    //    string created_by = Session["uid"].ToString();
    //    string usCode = Session["User_Code"].ToString();
    //    string lblCons = ViewState["OrgType2"].ToString();
    //    string indStat = ddlStatus.SelectedItem.Text.ToString();

    //    lblIPODesignation.Text = "";
    //    //ddlNameofInd.SelectedItem.Text.ToString() = "";
    //    string inctiveID = ViewState["IncentveID"].ToString(); // remove this for testing
    //    string MstIncentiveId = Request.QueryString[1].ToString();

    //    string[] InpectedDate = txtInpectedDate.Text.Split('/');
    //    string[] lblDCPdate = lblDCP.Text.Split('/');
    //    string[] DateShrtfall = txtDateShrtfall.Text.Split('/');
    //    string[] DtShrtFallRcvd = txtDtShrtFallRcvd.Text.Split('/');

    //    string DateShrtfallnew = "";
    //    string DtShrtFallRcvdnew = "";
    //    if (DateShrtfall[0] == "")
    //    {
    //        DateShrtfallnew = null;
    //    }
    //    else
    //    {
    //        DateShrtfallnew = DateShrtfall[2] + "/" + DateShrtfall[1] + "/" + DateShrtfall[0];
    //    }

    //    if (DtShrtFallRcvd[0] == "")
    //    {
    //        DtShrtFallRcvdnew = null;
    //    }
    //    else
    //    {
    //        DtShrtFallRcvdnew = DtShrtFallRcvd[2] + "/" + DtShrtFallRcvd[1] + "/" + DtShrtFallRcvd[0];
    //    }
    //    Status = Gen.insertInspRprtData(inctiveID, Session["User_Code"].ToString(), ViewState["lblnameofIND"].ToString(), ViewState["lblUdyogAdhar"].ToString(), txtIPOName.Text, lblIPODesignation.Text.ToString(),
    //        InpectedDate[2] + "/" + InpectedDate[1] + "/" + InpectedDate[0], lblCons, txtPersonIndustry.Text, indStat, rdbVerifyCert.SelectedItem.Text, "", lblDCPdate[2] + "/" + lblDCPdate[1] + "/" + lblDCPdate[0],
    //       DateShrtfallnew, DtShrtFallRcvdnew, txtExtent.Text, txtBuiltupAra.Text, txt5TtimesBltup.Text, txtExtentElgble.Text,
    //        rdblYesNoClaimSubmn.SelectedItem.Text, rdblClmApplRmbrLandCst.SelectedItem.Text, txt25BldgCvl.Text, txtLndCst25Prcnt.Text, txtRegnFee25Prcnt.Text, txtTotal25Prcnt.Text,
    //        txtAprdPjCst25Prcnt.Text, txtProprtn25Prcnt.Text, txtComputedcost.Text, txtValofItems.Text, txtPlnthArea.Text, txtTSSFC.Text, txtAprvPJVal.Text,
    //        txtAppJTot.Text, txtTotVal1.Text, txtTotVal2.Text, txtTotVal3.Text, txtTotVal4.Text, txtTotVal10.Text, txtGrndTotVal.Text, txtAsperApprPjCostPM.Text,
    //        txtAsperCivilEngr.Text, txtComptdGm.Text, txtComputedcost.Text, txtAsperApprPjCostPM.Text, txtAsperListPM.Text, txtTechKnowPM.Text,
    //        txt2ndMachPM.Text, txtPrcnt2ndMach.Text, txtTotal2ndHandMach.Text, txtTot2ndMach.Text, txtTotCstCmptdLand.Text, txtTotCstCmptdBldg.Text,
    //        txtTotCstCmptdPlntMach.Text, txtTotCstCmptdTotal.Text, txtInvSubsidyVal.Text, txtAddnInvSubsdyWmn.Text, "",
    //        txtAddnInvSbsdySc10Prcnt.Text, txtTotalInv.Text, "", "", "", "", "", "", "", "", "", "", "", MstIncentiveId, txtremarks.Text.Trim());

    //    return Status;
    //}

    public void AssignValuesToVOs()
    {
        string lblCons = ViewState["OrgType2"].ToString();
        string created_by = Session["uid"].ToString();
        string MstIncentiveId = Request.QueryString[1].ToString();
        string indStat = ddlStatus.SelectedItem.Text.ToString();

        string[] InpectedDate = txtInpectedDate.Text.Split('/');
        string[] lblDCPdate = lblDCP.Text.Split('/');
        string[] DateShrtfall = txtDateShrtfall.Text.Split('/');
        string[] DtShrtFallRcvd = txtDtShrtFallRcvd.Text.Split('/');
        string[] RcptAppln = txtRcptAppln.Text.Split('/');

        string DateShrtfallnew = "";
        string DtShrtFallRcvdnew = "";
        if (DateShrtfall[0] == "")
        {
            DateShrtfallnew = "01/01/1900";
        }
        else
        {
            DateShrtfallnew = DateShrtfall[2] + "/" + DateShrtfall[1] + "/" + DateShrtfall[0];
        }

        if (DtShrtFallRcvd[0] == "")
        {
            DtShrtFallRcvdnew = "01/01/1900";
        }
        else
        {
            DtShrtFallRcvdnew = DtShrtFallRcvd[2] + "/" + DtShrtFallRcvd[1] + "/" + DtShrtFallRcvd[0];
        }
        try
        {
            //string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
            //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

            oInspectionReportVOs.inctiveID = Request.QueryString[0].ToString().ToUpper();
            oInspectionReportVOs.User_Code = Session["User_Code"].ToString().ToUpper();
            oInspectionReportVOs.nameofIND = ViewState["lblnameofIND"].ToString().ToUpper();
            oInspectionReportVOs.udyogAdhar = ViewState["lblUdyogAdhar"].ToString().ToUpper();
            oInspectionReportVOs.IPOName = txtIPOName.Text.ToUpper();
            oInspectionReportVOs.IPODesignation = lblIPODesignation.Text.ToString().ToUpper();

            //added by chinna

            oInspectionReportVOs.IsDlcOrSlc = rblDLCSLC.SelectedValue.ToString();


            oInspectionReportVOs.InpectedDate = InpectedDate[2] + "/" + InpectedDate[1] + "/" + InpectedDate[0];
            //oInspectionReportVOs.InpectedDate = "01/01/1900";

            oInspectionReportVOs.UnitCons = lblCons.ToUpper();
            oInspectionReportVOs.PersonIndustry = txtPersonIndustry.Text.ToUpper();
            oInspectionReportVOs.indStat = indStat.ToUpper();
            oInspectionReportVOs.VerifyCert = rdbVerifyCert.SelectedItem.Text.ToUpper();
            oInspectionReportVOs.ApplClm = "0";

            oInspectionReportVOs.DCP = lblDCPdate[2] + "/" + lblDCPdate[1] + "/" + lblDCPdate[0];
            //oInspectionReportVOs.DCP = "01/01/1900";
            oInspectionReportVOs.RcptAppln = RcptAppln[2] + "/" + RcptAppln[1] + "/" + RcptAppln[0];

            // 3.0
            foreach (GridViewRow gvrow in gvNewindus.Rows)
            {
                InpectionGridLOAVos oInpectionGridLOAVos = new InpectionGridLOAVos();

                oInpectionGridLOAVos.IncentiveID = Request.QueryString["EntrpId"].ToString();
                oInpectionGridLOAVos.UserCode = Session["User_Code"].ToString();

                TextBox LineofActivity = (TextBox)gvrow.FindControl("txtLOA");
                TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                TextBox Value = (TextBox)gvrow.FindControl("txtValue");
                TextBox Unit = (TextBox)gvrow.FindControl("txtUnit");

                oInpectionGridLOAVos.LineofActivity = LineofActivity.Text;
                oInpectionGridLOAVos.InstalledCapacity = InstalledCapacity.Text;
                oInpectionGridLOAVos.Value = Value.Text;
                oInpectionGridLOAVos.Unit = Unit.Text;
                oInpectionGridLOAVos.LOAType = "New Industry"; //ViewState["IdsustryStatus"].ToString();
                oInpectionGridLOAVos.CreatedBy = Session["uid"].ToString();

                listInpectionGridLOAVos.Add(oInpectionGridLOAVos);
            }
            if (ddlStatus.SelectedItem.Text != "New Industry")
            {
                foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
                {
                    InpectionGridExpVos oInpectionGridExpVos = new InpectionGridExpVos();

                    oInpectionGridExpVos.IncentiveID = Request.QueryString["EntrpId"].ToString();
                    oInpectionGridExpVos.UserCode = Session["User_Code"].ToString();

                    TextBox LineofActivity = (TextBox)gvrow.FindControl("txtLOA");
                    TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                    TextBox Value = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox Unit = (TextBox)gvrow.FindControl("txtUnits");

                    oInpectionGridExpVos.LineofActivity = LineofActivity.Text;
                    oInpectionGridExpVos.InstalledCapacity = InstalledCapacity.Text;
                    oInpectionGridExpVos.Value = Value.Text;
                    oInpectionGridExpVos.Unit = Unit.Text;
                    oInpectionGridExpVos.LOAType = ddlStatus.SelectedItem.Text;
                    oInpectionGridExpVos.CreatedBy = Session["uid"].ToString();

                    listInpectionGridExpVos.Add(oInpectionGridExpVos);
                }
            }
            oInspectionReportVOs.DateShrtfall = DateShrtfallnew;
            oInspectionReportVOs.DtShrtFallRcvd = DtShrtFallRcvdnew;

            // 4.0.0
            oInspectionReportVOs.Extent = txtExtent.Text;
            oInspectionReportVOs.BuiltupAra = txtBuiltupAra.Text;
            oInspectionReportVOs.TtimesBltup = txt5TtimesBltup.Text;
            oInspectionReportVOs.ExtentElgble = txtExtentElgble.Text;
            oInspectionReportVOs.YesNoClaimSubmn = rdblYesNoClaimSubmn.SelectedItem.Text;
            oInspectionReportVOs.ClmApplRmbrLandCst = rdblClmApplRmbrLandCst.SelectedItem.Text;

            if (chkMobileUnit.Checked == true)  //added on 03.09.2019
                oInspectionReportVOs.isMobileUnit = "1";
            else if (chkMobileUnit.Checked == false)
                oInspectionReportVOs.isMobileUnit = "0";

            // 4.2.0
            oInspectionReportVOs.Clm25PBldgCvl = txt25BldgCvl.Text.ToUpper();
            oInspectionReportVOs.BuildingApprovedPrjtCost = txt25BldgCvl.Text.ToUpper();

            if (gv422.Visible == true)
            {
                foreach (GridViewRow gvrow in gv422.Rows)
                {
                    InpectionGrid422Vos oInpectionGrid422Vos = new InpectionGrid422Vos();

                    oInpectionGrid422Vos.IncentiveID = Request.QueryString["EntrpId"].ToString();
                    oInpectionGrid422Vos.UserCode = Session["User_Code"].ToString();
                    oInpectionGrid422Vos.guideline422 = gvrow.Cells[1].Text;
                    oInpectionGrid422Vos.Plintharea422 = gvrow.Cells[2].Text;
                    oInpectionGrid422Vos.TSSFCnorms422 = gvrow.Cells[3].Text;
                    oInpectionGrid422Vos.value422 = gvrow.Cells[4].Text;
                    oInpectionGrid422Vos.CreatedBy = Session["uid"].ToString();

                    listInpectionGrid422Vos.Add(oInpectionGrid422Vos);
                }
            }
            // 4.2.3
            if (gv423.Visible == true)
            {
                foreach (GridViewRow gvrow in gv423.Rows)
                {
                    InpectionGrid423Vos oInpectionGrid423Vos = new InpectionGrid423Vos();

                    oInpectionGrid423Vos.IncentiveID = Request.QueryString["EntrpId"].ToString();
                    oInpectionGrid423Vos.UserCode = Session["User_Code"].ToString();
                    oInpectionGrid423Vos.guideline423 = gvrow.Cells[1].Text;
                    oInpectionGrid423Vos.Plintharea423 = gvrow.Cells[2].Text;
                    oInpectionGrid423Vos.TSSFCnorms423 = gvrow.Cells[3].Text;
                    oInpectionGrid423Vos.value423 = gvrow.Cells[4].Text;
                    oInpectionGrid423Vos.CreatedBy = Session["uid"].ToString();

                    listInpectionGrid423Vos.Add(oInpectionGrid423Vos);
                }
            }
            foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
            {
                if (gvrow.RowIndex == 0)
                {
                    TextBox LandExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox LandExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox LandExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    oInspectionReportVOs.LandExistEnterprise = LandExistEnterprise.Text;
                    oInspectionReportVOs.LandExpanDiversification = LandExpanDiversification.Text;
                    oInspectionReportVOs.LandExpanDiversificationPercentage = LandExpanDiversificationPercentage.Text;
                }
                if (gvrow.RowIndex == 1)
                {
                    TextBox BuildingExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox BuildingExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox BuildingExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    oInspectionReportVOs.BuildingExistEnterprise = BuildingExistEnterprise.Text;
                    oInspectionReportVOs.BuildingExpanDiversification = BuildingExpanDiversification.Text;
                    oInspectionReportVOs.BuildingExpanDiversificationPercentage = BuildingExpanDiversificationPercentage.Text;
                }
                if (gvrow.RowIndex == 2)
                {
                    TextBox PlantMachExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    TextBox PlantMachExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                    TextBox PlantMachExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                    oInspectionReportVOs.PlantMachExistEnterprise = PlantMachExistEnterprise.Text;
                    oInspectionReportVOs.PlantMachExpanDiversification = PlantMachExpanDiversification.Text;
                    oInspectionReportVOs.PlantMachExpanDiversificationPercentage = PlantMachExpanDiversificationPercentage.Text;
                }
            }

            oInspectionReportVOs.TotVal100 = txtTotVal100.Text;
            oInspectionReportVOs.LndCst25Prcny = txtLndCst25Prcnt.Text;
            oInspectionReportVOs.RegnFee25Prcnt = txtRegnfee.Text;
            oInspectionReportVOs.Total25Prcnt = txtTotal25Prcnt.Text;
            oInspectionReportVOs.AprdPjCst25Prcnt = txtAprdPjCst25Prcnt.Text;
            oInspectionReportVOs.Proprtn25Prcnt = txtProprtn25Prcnt.Text;
            oInspectionReportVOs.Computedcost = txtComputedcost.Text;
            oInspectionReportVOs.ValofItems = txtValofItems.Text;
            oInspectionReportVOs.PlnthArea = txtPlnthArea.Text;
            oInspectionReportVOs.TSSFC = txtTSSFC.Text;
            oInspectionReportVOs.AprvPJVal = txtAprvPJVal.Text;
            oInspectionReportVOs.AppJTot = txtAppJTot.Text;
            oInspectionReportVOs.TotVal1 = txtTotVal1.Text;
            oInspectionReportVOs.TotVal2 = txtTotVal2.Text;
            oInspectionReportVOs.TotVal3 = txtTotVal3.Text;
            oInspectionReportVOs.TotVal4 = txtTotVal4.Text;
            oInspectionReportVOs.TotVal100 = txtTotVal100.Text;
            oInspectionReportVOs.GrndTotVal = txtGrndTotVal.Text;
            oInspectionReportVOs.AsperApprPjCostPM = txtAsperApprvdCost.Text;
            oInspectionReportVOs.AsperCivilEngr = txtAsperCivilEngr.Text;
            oInspectionReportVOs.ComptdGm = txtComptdGm.Text;
            oInspectionReportVOs.Comptedcst = txtComputedCostApprPrj.Text;
            oInspectionReportVOs.AsprAppPjCostPM = txtAsperApprPjCostPM.Text;
            oInspectionReportVOs.AsperListPM = txtAsperListPM.Text;
            oInspectionReportVOs.TechKnowPM = txtTechKnowPM.Text;
            oInspectionReportVOs.MachPM = txt2ndMachPM.Text;
            oInspectionReportVOs.Prcnt2ndMach = txtPrcnt2ndMach.Text;
            oInspectionReportVOs.Total2ndHandMach = txtTotal2ndHandMach.Text;
            oInspectionReportVOs.Tot2ndMach = txtTot2ndMach.Text;
            oInspectionReportVOs.totCstCmptdLand = txtTotCstCmptdLand.Text;
            oInspectionReportVOs.TotCstCmptdBldg = txtTotCstCmptdBldg.Text;
            oInspectionReportVOs.TotCstCmptdPlntMach = txtTotCstCmptdPlntMach.Text;
            oInspectionReportVOs.TotCstCmptdTotal = txtTotCstCmptdTotal.Text;
            oInspectionReportVOs.InvSubsidyVal = txtInvSubsidyVal.Text;
            oInspectionReportVOs.AddnInvSubsdyWmn = txtAddnInvSubsdyWmn.Text;
            oInspectionReportVOs.InvSubsdySCS = txtInvSubsdySCST.Text;
            oInspectionReportVOs.AddnInvSbsdySc10Prcnt = txtAddnInvSbsdySc10Prcnt.Text;
            oInspectionReportVOs.TotalInv = txtTotalInv.Text;
            oInspectionReportVOs.empval1 = "0";
            oInspectionReportVOs.empval2 = "0";
            oInspectionReportVOs.empval3 = "0";
            oInspectionReportVOs.empval4 = "0";
            oInspectionReportVOs.empval5 = "0";
            oInspectionReportVOs.empval6 = "0";
            oInspectionReportVOs.empval7 = "0";
            oInspectionReportVOs.empval8 = "0";
            oInspectionReportVOs.empval9999 = "0";
            oInspectionReportVOs.empval999 = "0";
            oInspectionReportVOs.empval99 = "0";
            oInspectionReportVOs.mstincentiveid = MstIncentiveId;
            oInspectionReportVOs.txtremarks = txtremarks.Text.Trim().ToUpper();


            oInspectionReportVOs.caste_IR = rdbCaste.SelectedValue.ToString();

            oInspectionReportVOs.gender_IR = rdbGender.SelectedValue.ToString();

            oInspectionReportVOs.category_IR = rdbCategory.SelectedValue.ToString();

            oInspectionReportVOs.enterprisetype_IR = rdbEnterprise.SelectedValue.ToString();

            oInspectionReportVOs.sector_IR = rdbSector.SelectedValue.ToString();

            oInspectionReportVOs.servicetype_IR = rdbServiceType.SelectedValue.ToString();

            oInspectionReportVOs.transNonTrans_IR = rdbTransportNonTrans.SelectedValue.ToString();

            oInspectionReportVOs.txtLOActivityExpan = txtLOActivityExpan.Text.ToString();

            oInspectionReportVOs.txtinstalledccapExpan = txtinstalledccapExpan.Text.ToString();

            oInspectionReportVOs.ddlquantityinExpan = ddlquantityinExpan.SelectedValue.ToString();

            oInspectionReportVOs.txtunitExpan = txtunitExpan.Text.ToString();

            oInspectionReportVOs.txtvalueExpan = txtvalueExpan.Text.ToString();

            oInspectionReportVOs.TXTLANDVALUE_EXISTING = TXTLANDVALUE_EXISTING.Text.ToString();

            oInspectionReportVOs.TXTBUILDINGVALE_EXISTING = TXTBUILDINGVALE_EXISTING.Text.ToString();

            oInspectionReportVOs.TXTPLANTANDMACHINAERVALUE_EXISTING = TXTPLANTANDMACHINAERVALUE_EXISTING.Text.ToString();

            oInspectionReportVOs.TXTLANDVALUE_EXPANSION = TXTLANDVALUE_EXPANSION.Text.ToString();

            oInspectionReportVOs.TXTBUILDINGVALUE_EXPANSION = TXTBUILDINGVALUE_EXPANSION.Text.ToString();

            oInspectionReportVOs.TXTPLANTANDMACHINERYVALUE_EXPANSION = TXTPLANTANDMACHINERYVALUE_EXPANSION.Text.ToString();

            oInspectionReportVOs.TXTINCPERCENTAGE_LAND = TXTINCPERCENTAGE_LAND.Text.ToString();

            oInspectionReportVOs.TXTINCRPERCEN_BUILDINGVALUE = TXTINCRPERCEN_BUILDINGVALUE.Text.ToString();

            oInspectionReportVOs.TXTINCPERCEN_PLANTANDMACHINERY = TXTINCPERCEN_PLANTANDMACHINERY.Text.ToString();

        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int valid = 0;
        int rowCount = GridView3att.Rows.Count;
        int rowCountinc = 0;

        try
        {
            #region ServerValidations
            if (txtPersonIndustry.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check And Enter (Point Number 1.6)');", true);
                txtPersonIndustry.Focus();
                return;
            }

            if (rblDLCSLC.SelectedItem == null)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check (Point Number 1.8) and Select AnyOne Option');", true);
                rblDLCSLC.Focus();
                return;
            }


            if (rdbVerifyCert.SelectedItem == null)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check (Point Number 2.0) and Select AnyOne Option');", true);
                rdbVerifyCert.Focus();
                return;
            }


            foreach (GridViewRow gvrow in gvNewindus.Rows)
            {
                TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                TextBox Units = (TextBox)gvrow.FindControl("txtUnit");
                TextBox Value = (TextBox)gvrow.FindControl("txtValue");

                if (LOA.Text == "" || LOA.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.1)');", true);
                    LOA.Focus();
                    return;
                }
                if (InstalledCapacity.Text == "" || InstalledCapacity.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.1)');", true);
                    InstalledCapacity.Focus();
                    return;
                }
                if (Units.Text == "" || Units.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.1)');", true);
                    Units.Focus();
                    return;
                }
                if (Value.Text == "" || Value.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.1)');", true);
                    Value.Focus();
                    return;
                }
            }
            foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
            {
                TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                if (LOA.Text == "" || LOA.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.2)');", true);
                    LOA.Focus();
                    return;
                }
                if (InstalledCapacity.Text == "" || InstalledCapacity.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.2)');", true);
                    InstalledCapacity.Focus();
                    return;
                }
                if (Units.Text == "" || Units.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.2)');", true);
                    Units.Focus();
                    return;
                }
                if (ExpansionDiversification.Text == "" || ExpansionDiversification.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Project Details (Point Number 3.2)');", true);
                    ExpansionDiversification.Focus();
                    return;
                }
            }
            foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
            {
                TextBox ExistingEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                if (ExistingEnterprise.Text == "" || ExistingEnterprise.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Fixed Capital Investment (Point Number 3.3)');", true);
                    ExistingEnterprise.Focus();
                    return;
                }
                if (ExpansionDiversification.Text == "" || ExpansionDiversification.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Fixed Capital Investment (Point Number 3.3)');", true);
                    ExpansionDiversification.Focus();
                    return;
                }
                if (ExpansionDiversificationincreasepercentage.Text == "" || ExpansionDiversificationincreasepercentage.Text == string.Empty)
                {
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check Fixed Capital Investment (Point Number 3.3)');", true);
                    ExpansionDiversificationincreasepercentage.Focus();
                    return;
                }
            }

            if (txttotalNew.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total (Point Number 3.3)');", true);
                txttotalNew.Focus();
                return;
            }
            if (lblDCP.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Date of commencement of Production (Point Number 3.4)');", true);
                lblDCP.Focus();
                return;
            }
            if (txtExtent.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Extent in Sq.Mtrs (Point Number 4.1.1)');", true);
                txtExtent.Focus();
                return;
            }
            if (txtBuiltupAra.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Built up area in Sq.Mtrs (Point Number 4.1.1)');", true);
                txtBuiltupAra.Focus();
                return;
            }
            if (txt5TtimesBltup.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter 5 times built up area in Sq.Mtrs (Point Number 4.1.1)');", true);
                txt5TtimesBltup.Focus();
                return;
            }
            if (txtExtentElgble.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Extent eligible in Sq.Mtrs (Point Number 4.1.1)');", true);
                txtExtentElgble.Focus();
                return;
            }
            if (rdblYesNoClaimSubmn.SelectedItem == null)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check (Point Number 4.1.2) and Select AnyOne Option');", true);
                rdblYesNoClaimSubmn.Focus();
                return;
            }
            if (rdblClmApplRmbrLandCst.SelectedItem == null)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check (Point Number 4.1.3) and Select AnyOne Option');", true);
                rdblClmApplRmbrLandCst.Focus();
                return;
            }
            if (txtLndCst25Prcnt.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Land cost (Point Number 4.1.4)');", true);
                txtLndCst25Prcnt.Focus();
                return;
            }
            if (txtRegnfee.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Regn. fee (Point Number 4.1.4)');", true);
                txtRegnfee.Focus();
                return;
            }
            if (txtTotal25Prcnt.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total (Point Number 4.1.4)');", true);
                txtTotal25Prcnt.Focus();
                return;
            }
            if (txtAprdPjCst25Prcnt.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Approved Project cost (Point Number 4.1.4)');", true);
                txtAprdPjCst25Prcnt.Focus();
                return;
            }
            if (txtProprtn25Prcnt.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Proportionate eligible value (Point Number 4.1.4)');", true);
                txtProprtn25Prcnt.Focus();
                return;
            }
            if (txtComputedcost.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Computed Cost (Point Number 4.1.5)');", true);
                txtComputedcost.Focus();
                return;
            }
            if (txt25BldgCvl.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Approved Project Cost (Point Number 4.2.1)');", true);
                txt25BldgCvl.Focus();
                return;
            }
            if (gv422.Visible == false)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check And Enter (Point Number 4.2.2) Details and Click On Add Button');", true);
                btnAdd422New.Focus();
                return;
            }
            if (txtTotVal100.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total value of 100 % Items (Point Number 4.2.2)');", true);
                txtTotVal100.Focus();
                return;
            }
            if (gv423.Visible == false)
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Check And Enter (Point Number 4.2.3) Details and Click On Add Button');", true);
                btnAdd423New.Focus();
                return;
            }
            if (txtAppJTot.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total Value 10% Items (in Rs) (Point Number 4.2.4)');", true);
                txtAppJTot.Focus();
                return;
            }
            if (txtGrndTotVal.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Grand Total Value 100% + 10% Items (in Rs) (Point Number 4.2.5)');", true);
                txtGrndTotVal.Focus();
                return;
            }
            if (txtAsperApprvdCost.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter As per approved project cost (Point Number 4.2.6)');", true);
                txtAsperApprvdCost.Focus();
                return;
            }
            if (txtAsperCivilEngr.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter As per Civil Engineer Certificate (Point Number 4.2.6)');", true);
                txtAsperCivilEngr.Focus();
                return;
            }
            if (txtComptdGm.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Computed value by the GM (Point Number 4.2.6)');", true);
                txtComptdGm.Focus();
                return;
            }
            if (txtComputedCostApprPrj.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Computed cost (Point Number 4.2.6)');", true);
                txtComputedCostApprPrj.Focus();
                return;
            }
            if (txtAsperApprPjCostPM.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter As per approved project cost (Point Number 4.3.1)');", true);
                txtAsperApprPjCostPM.Focus();
                return;
            }
            if (txtAsperListPM.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter As per list of Plant & Machinery (Point Number 4.3.1)');", true);
                txtAsperListPM.Focus();
                return;
            }
            if (txtPrcnt2ndMach.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter % of 2nd hand Machinery (Point Number 4.3.1)');", true);
                txtPrcnt2ndMach.Focus();
                return;
            }
            if (txtTechKnowPM.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Tech. Know how and study and turnkey charges not to exceed 10% of PM & E (Point Number 4.3.1)');", true);
                txtTechKnowPM.Focus();
                return;
            }
            if (txt2ndMachPM.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter 2nd hand machinery Value (Point Number 4.3.1)');", true);
                txt2ndMachPM.Focus();
                return;
            }
            if (txtTotal2ndHandMach.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total (Point Number 4.3.1)');", true);
                txtTotal2ndHandMach.Focus();
                return;
            }
            if (txtTot2ndMach.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Computed Cost (Point Number 4.3.2)');", true);
                txtTot2ndMach.Focus();
                return;
            }
            if (txtTotCstCmptdLand.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Land (Point Number 4.4.0)');", true);
                txtTotCstCmptdLand.Focus();
                return;
            }
            if (txtTotCstCmptdPlntMach.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Plant & Machinery (Point Number 4.4.0)');", true);
                txtTotCstCmptdPlntMach.Focus();
                return;
            }
            if (txtTotCstCmptdBldg.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Buildings (Point Number 4.4.0)');", true);
                txtTotCstCmptdBldg.Focus();
                return;
            }
            if (txtTotCstCmptdTotal.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total (Point Number 4.4.0)');", true);
                txtTotCstCmptdTotal.Focus();
                return;
            }
            if (txtInvSubsidyVal.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Investment Subsidy (in Rs) (Point Number 5.1)');", true);
                txtInvSubsidyVal.Focus();
                return;
            }
            if (txtAddnInvSubsdyWmn.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter An Additional Investment Subsidy for Women entrepreneurs (Point Number 5.2)');", true);
                txtAddnInvSubsdyWmn.Focus();
                return;
            }
            if (txtInvSubsdySCST.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter An additional investment subsidy for SC/ST entrepreneurs (Point Number 5.3)');", true);
                txtInvSubsdySCST.Focus();
                return;
            }
            if (txtAddnInvSbsdySc10Prcnt.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter An additional investment subsidy for Women entrepreneurs set up in Scheduled areas (Point Number 5.4)');", true);
                txtAddnInvSbsdySc10Prcnt.Focus();
                return;
            }
            if (txtTotalInv.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Total (Point Number 5.5)');", true);
                txtTotalInv.Focus();
                return;
            }
            if (txtremarks.Text == "")
            {
                valid = 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Enter Remarks (Point Number 5.6)');", true);
                txtremarks.Focus();
                return;
            }
            //if (lblFileName.Text == "")
            //{
            //    valid = 1;
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select the file to upload');", true);
            //    FileUpload1.Focus();
            //    return;
            //}

            #endregion
            if (rdbEnterprise.SelectedIndex == 1)
            {
                string errormsg = ValidateControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;

                }

            }

            while (rowCountinc < rowCount)  //added newly on 25.02.2020.
            {

                Label lbltext = (Label)GridView3att.Rows[rowCountinc].FindControl("lbl");
                string text = lbltext.Text.ToString();
                //CheckBox chkverified = (CheckBox)GridView3att.Rows[rowCountinc].FindControl("chkverified");
                RadioButtonList rbtverified = (RadioButtonList)GridView3att.Rows[rowCountinc].FindControl("rbtverified");

                //if (chkverified.Checked != true && chkverified.Visible == true)
                if ((rbtverified.SelectedValue == "" || rbtverified.SelectedValue == null || rbtverified.SelectedValue == "") && rbtverified.Visible == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please verify all the attachments');", true);
                    return;
                }
                rowCountinc = rowCountinc + 1;
            }

            if (valid == 0)
            {
                AssignValuesToVOs();

                int outflag = Gen.InsertInspectionReport(oInspectionReportVOs, listInpectionGridLOAVos, listInpectionGridExpVos, listInpectionGrid422Vos, listInpectionGrid423Vos);

                if (outflag != 0)
                {
                    foreach (GridViewRow gvrow in GridView3att.Rows)
                    {
                        string attid = ((Label)gvrow.FindControl("lblatchid")).Text.ToString();
                        //CheckBox chkverified = ((CheckBox)gvrow.FindControl("chkverified"));
                        RadioButtonList rbtverified = ((RadioButtonList)gvrow.FindControl("rbtverified"));


                        // if (chkverified.Visible == true && chkverified.Checked == true && attid != "0" && attid != "")
                        if (rbtverified.Visible == true && (rbtverified.SelectedValue == "Y" || rbtverified.SelectedValue == "N") && attid != "0" && attid != "")
                        {
                            int valid1 = Gen.UpdateverifyInctveattachment(ViewState["IncentveID"].ToString(), attid, Session["uid"].ToString(), rbtverified.SelectedValue);
                        }

                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Inspection Report Submitted Successfully');", true);
                    trsubmit.Visible = false;
                    divbtnprint.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Inspection Report Already Submitted');", true);
                }
            }

            //string succMesg = "";
            //succMesg = insertDetailsofInspection();
            //try
            //{
            //    foreach (GridViewRow gvrow in GridView3att.Rows)
            //    {
            //        string attid = ((Label)gvrow.FindControl("lblatchid")).Text.ToString();
            //        CheckBox chkverified = ((CheckBox)gvrow.FindControl("chkverified"));
            //        if (chkverified.Visible == true && chkverified.Checked == true && attid != "0" && attid != "")
            //        {
            //            int valid = Gen.UpdateverifyInctveattachment(ViewState["IncentveID"].ToString(), attid, Session["uid"].ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
            //if (succMesg == "1")
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccMesg", "alert('Inspection Report Submitted Successfully');", true);
            //else
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccMesg", "alert('Inspection report uploaded earlier!!');", true);
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
            trsubmit.Visible = true;
            divbtnprint.Visible = false;
        }
    }
    public void FillInspectionReportDetails(DataSet oDataSet)
    {
        DataSet ds = new DataSet();

        try
        {
            string IncentiveId = ViewState["IncentveID"].ToString();
            string createdby = Session["uid"].ToString();
            ds = Gen.GETINCENTIVESCHECKLIST(createdby, IncentiveId);
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2, sennew;

                FileUpload1.Visible = true;
                BtnSave3.Visible = true;

                foreach (DataRow dr in table.Rows)
                {
                    string attachmentid = dr["AttachmentId"].ToString();
                    sen2 = dr["link"].ToString();
                    sennew = dr["LINKNEW"].ToString();// dsattachment.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    sen1 = sen2.Replace(@"\", @"/");
                    //sen = sen1.Replace(@"D:/TSIPASS/", "~/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal", "https://ipass.telangana.gov.in/");

                    if (attachmentid == "5500")
                    {
                        lblFileName.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblFileName.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label444.Text = dr["FileNm"].ToString(); // label   
                        lblFileName.Visible = true;
                        Label444.Visible = false;
                        FileUpload1.Visible = false;
                        BtnSave3.Visible = false;
                    }
                }
            }

            if (oDataSet.Tables[0] != null)
            {
                if (oDataSet.Tables.Count > 0 && oDataSet.Tables[0].Rows.Count > 0)
                {
                    lblnameofIND.Text = oDataSet.Tables[0].Rows[0]["nameofIND"].ToString();
                    txtIPOName.Text = oDataSet.Tables[0].Rows[0]["IPOName"].ToString();
                    lblIPODesignation.Text = oDataSet.Tables[0].Rows[0]["IPODesignation"].ToString();
                    txtInpectedDate.Text = oDataSet.Tables[0].Rows[0]["InpectedDateConverted"].ToString();

                    if (oDataSet.Tables[0].Rows[0]["ismobileunit"].ToString() != null) //added on 03.09.19
                    {
                        if (oDataSet.Tables[0].Rows[0]["ismobileunit"].ToString() == "1")
                        {
                            chkMobileUnit.Checked = true;
                            chkMobileUnit.Enabled = false;
                        }
                        else if (oDataSet.Tables[0].Rows[0]["ismobileunit"].ToString() == "0")
                        {
                            chkMobileUnit.Checked = false;
                            chkMobileUnit.Enabled = false;
                        }
                    }

                    if (oDataSet.Tables[0].Rows[0]["IsDlcOrSlc"].ToString() != null)
                    {
                        rblDLCSLC.SelectedValue = oDataSet.Tables[0].Rows[0]["IsDlcOrSlc"].ToString();
                    }
                    else
                    {
                        lblIsDlcSlc.Visible = false;
                        lblhIsdlcslc.Visible = false;
                        rblDLCSLC.Visible = false;
                    }

                    ddlUnitCons.SelectedItem.Text = oDataSet.Tables[0].Rows[0]["UnitCons"].ToString();
                    txtPersonIndustry.Text = oDataSet.Tables[0].Rows[0]["PersonIndustry"].ToString();

                    // ddlStatus.SelectedItem.Text = oDataSet.Tables[0].Rows[0]["indStat"].ToString();

                    string indstatus = "";
                    indstatus = oDataSet.Tables[0].Rows[0]["indStat"].ToString();
                    if (indstatus.ToUpper().Trim().Contains("NEW"))
                    {
                        ddlStatus.SelectedValue = "1";
                    }
                    else if (indstatus.ToUpper().Trim().Contains("EXPANSION"))
                    {
                        ddlStatus.SelectedValue = "2";
                    }
                    else if (indstatus.ToUpper().Trim().Contains("DIVERSIFICATION"))
                    {
                        ddlStatus.SelectedValue = "3";
                    }


                    rdbVerifyCert.SelectedValue = oDataSet.Tables[0].Rows[0]["VerifyCertNew"].ToString();

                    //txttotalNew.Text = Convert.ToString(Convert.ToInt32(oDataSet.Tables[0].Rows[0]["LandExistEnterprise"].ToString()) + Convert.ToInt32(oDataSet.Tables[0].Rows[0]["BuildingExistEnterprise"].ToString())
                    //                   + Convert.ToInt32(oDataSet.Tables[0].Rows[0]["PlantMachExistEnterprise"].ToString()));


                    txttotalNew.Text = Convert.ToString(Convert.ToDouble(Convert.ToDouble(oDataSet.Tables[0].Rows[0]["LandExistEnterprise"].ToString())) + Convert.ToDouble(Convert.ToDouble(oDataSet.Tables[0].Rows[0]["BuildingExistEnterprise"].ToString()))
                                       + Convert.ToDouble(Convert.ToDouble(oDataSet.Tables[0].Rows[0]["PlantMachExistEnterprise"].ToString()))
                                       + Convert.ToDouble(oDataSet.Tables[0].Rows[0]["LandExpanDiversification"].ToString())
                                       + Convert.ToDouble(oDataSet.Tables[0].Rows[0]["BuildingExpanDiversification"].ToString()) +
                                       +Convert.ToDouble(oDataSet.Tables[0].Rows[0]["PlantMachExpanDiversification"].ToString()));

                    if (oDataSet.Tables[0].Rows[0]["DCPConverted"].ToString() != "01/01/1900")
                        lblDCP.Text = oDataSet.Tables[0].Rows[0]["DCPConverted"].ToString();
                    else
                        lblDCP.Text = "";

                    if (oDataSet.Tables[0].Rows[0]["DateApplicationClaimConverted"].ToString() != "01/01/1900")
                        txtRcptAppln.Text = oDataSet.Tables[0].Rows[0]["DateApplicationClaimConverted"].ToString();
                    else
                        txtRcptAppln.Text = "";

                    if (oDataSet.Tables[0].Rows[0]["DateShrtfallConverted"].ToString() != "01/01/1900")
                        txtDateShrtfall.Text = oDataSet.Tables[0].Rows[0]["DateShrtfallConverted"].ToString();
                    else
                        txtDateShrtfall.Text = "";

                    if (oDataSet.Tables[0].Rows[0]["DtShrtFallRcvdConverted"].ToString() != "01/01/1900")
                        txtDtShrtFallRcvd.Text = oDataSet.Tables[0].Rows[0]["DtShrtFallRcvdConverted"].ToString();
                    else
                        txtDtShrtFallRcvd.Text = "";

                    // 4.0.0
                    txtExtent.Text = oDataSet.Tables[0].Rows[0]["Extent"].ToString();
                    txtBuiltupAra.Text = oDataSet.Tables[0].Rows[0]["BuiltupAra"].ToString();
                    txt5TtimesBltup.Text = oDataSet.Tables[0].Rows[0]["TtimesBltup"].ToString();
                    txtExtentElgble.Text = oDataSet.Tables[0].Rows[0]["ExtentElgble"].ToString();
                    rdblYesNoClaimSubmn.SelectedValue = oDataSet.Tables[0].Rows[0]["YesNoClaimSubmnNew"].ToString();
                    rdblClmApplRmbrLandCst.SelectedValue = oDataSet.Tables[0].Rows[0]["ClmApplRmbrLandCstNew"].ToString();

                    // 4.2.1
                    txt25BldgCvl.Text = oDataSet.Tables[0].Rows[0]["BuildingApprovedPrjtCost"].ToString();

                    // 4.1.4
                    txtLndCst25Prcnt.Text = oDataSet.Tables[0].Rows[0]["LndCst25Prcny"].ToString();
                    txtRegnfee.Text = oDataSet.Tables[0].Rows[0]["RegnFee25Prcnt"].ToString();  // DOUBT
                    txtTotal25Prcnt.Text = oDataSet.Tables[0].Rows[0]["Total25Prcnt"].ToString();
                    txtAprdPjCst25Prcnt.Text = oDataSet.Tables[0].Rows[0]["AprdPjCst25Prcnt"].ToString();
                    txtProprtn25Prcnt.Text = oDataSet.Tables[0].Rows[0]["Proprtn25Prcnt"].ToString();
                    txtComputedcost.Text = oDataSet.Tables[0].Rows[0]["Computedcost25"].ToString();

                    //txt25BldgCvl

                    foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
                    {
                        if (gvrow.RowIndex == 0)
                        {
                            TextBox LandExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                            TextBox LandExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                            TextBox LandExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                            LandExistEnterprise.Text = oDataSet.Tables[0].Rows[0]["LandExistEnterprise"].ToString();
                            LandExpanDiversification.Text = oDataSet.Tables[0].Rows[0]["LandExpanDiversification"].ToString();
                            LandExpanDiversificationPercentage.Text = oDataSet.Tables[0].Rows[0]["LandExpanDiversificationPercentage"].ToString();
                        }
                        if (gvrow.RowIndex == 1)
                        {
                            TextBox BuildingExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                            TextBox BuildingExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                            TextBox BuildingExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                            BuildingExistEnterprise.Text = oDataSet.Tables[0].Rows[0]["BuildingExistEnterprise"].ToString();
                            BuildingExpanDiversification.Text = oDataSet.Tables[0].Rows[0]["BuildingExpanDiversification"].ToString();
                            BuildingExpanDiversificationPercentage.Text = oDataSet.Tables[0].Rows[0]["BuildingExpanDiversificationPercentage"].ToString();
                        }
                        if (gvrow.RowIndex == 2)
                        {
                            TextBox PlantMachExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                            TextBox PlantMachExpanDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");
                            TextBox PlantMachExpanDiversificationPercentage = (TextBox)gvrow.FindControl("txtExpansionDiversificationincreasepercentage");

                            PlantMachExistEnterprise.Text = oDataSet.Tables[0].Rows[0]["PlantMachExistEnterprise"].ToString();
                            PlantMachExpanDiversification.Text = oDataSet.Tables[0].Rows[0]["PlantMachExpanDiversification"].ToString();
                            PlantMachExpanDiversificationPercentage.Text = oDataSet.Tables[0].Rows[0]["PlantMachExpanDiversificationPercentage"].ToString();
                        }
                    }
                }
            }
            if (oDataSet.Tables[1] != null)
            {
                if (oDataSet.Tables[1].Rows.Count > 0)
                {
                    gvNewindus.DataSource = oDataSet.Tables[1];
                    gvNewindus.DataBind();
                }
            }
            if (oDataSet.Tables[2] != null)
            {
                if (oDataSet.Tables[2].Rows.Count > 0)
                {
                    foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
                    {
                        TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                        TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                        TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                        TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                        LOA.Text = oDataSet.Tables[2].Rows[0]["LineOfActivity"].ToString();
                        InstalledCapacity.Text = oDataSet.Tables[2].Rows[0]["InstalledCapacity"].ToString();
                        Units.Text = oDataSet.Tables[2].Rows[0]["NameOfUnit"].ToString();
                        ExpansionDiversification.Text = oDataSet.Tables[2].Rows[0]["Value"].ToString();

                        LOA.Enabled = false;
                        InstalledCapacity.Enabled = false;
                        Units.Enabled = false;
                        ExpansionDiversification.Enabled = false;
                    }
                }
                else
                {
                    foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
                    {
                        TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                        TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                        TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                        TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                        LOA.Text = "NA";
                        InstalledCapacity.Text = "NA";
                        Units.Text = "NA";
                        ExpansionDiversification.Text = "0";

                        LOA.Enabled = false;
                        InstalledCapacity.Enabled = false;
                        Units.Enabled = false;
                        ExpansionDiversification.Enabled = false;
                    }
                }
            }
            if (oDataSet.Tables[3] != null)
            {
                if (oDataSet.Tables[3].Rows.Count > 0)
                {
                    gv422.DataSource = oDataSet.Tables[3];
                    gv422.DataBind();

                    gv422.Visible = true;
                    gv422.Columns[5].Visible = false;
                }
                Label3.Text = "4.2.2";
                tr4221.Visible = false;
                tr4222.Visible = false;
                tr4223.Visible = false;
            }
            if (oDataSet.Tables[4] != null)
            {
                if (oDataSet.Tables[4].Rows.Count > 0)
                {
                    gv423.DataSource = oDataSet.Tables[4];
                    gv423.DataBind();

                    gv423.Visible = true;
                    gv423.Columns[5].Visible = false;
                }
                tr4231.Visible = false;
                tr4232.Visible = false;
                tr4233.Visible = false;
            }
            txtTotVal100.Text = oDataSet.Tables[0].Rows[0]["TotVal10"].ToString();
            txtAppJTot.Text = oDataSet.Tables[0].Rows[0]["AppJTot"].ToString();
            txtGrndTotVal.Text = oDataSet.Tables[0].Rows[0]["GrndTotVal"].ToString();

            txtAsperApprvdCost.Text = oDataSet.Tables[0].Rows[0]["AsperApprPjCostPM"].ToString();
            txtAsperCivilEngr.Text = oDataSet.Tables[0].Rows[0]["AsperCivilEngr"].ToString();

            txtComptdGm.Text = oDataSet.Tables[0].Rows[0]["ComptdGm"].ToString();
            txtComputedCostApprPrj.Text = oDataSet.Tables[0].Rows[0]["Comptedcst"].ToString();

            //added by chinna
            rblDLCSLC.SelectedValue = oDataSet.Tables[0].Rows[0]["IsDlcOrSlc"].ToString();

            txtAsperApprPjCostPM.Text = oDataSet.Tables[0].Rows[0]["AsprAppPjCostPM"].ToString();
            txtAsperListPM.Text = oDataSet.Tables[0].Rows[0]["AsperListPM"].ToString();
            txtPrcnt2ndMach.Text = oDataSet.Tables[0].Rows[0]["Prcnt2ndMach"].ToString();
            txtTechKnowPM.Text = oDataSet.Tables[0].Rows[0]["TechKnowPM"].ToString();
            txt2ndMachPM.Text = oDataSet.Tables[0].Rows[0]["MachPM"].ToString();
            txtTotal2ndHandMach.Text = oDataSet.Tables[0].Rows[0]["Total2ndHandMach"].ToString();
            txtTot2ndMach.Text = oDataSet.Tables[0].Rows[0]["Tot2ndMach"].ToString();

            txtTotCstCmptdLand.Text = oDataSet.Tables[0].Rows[0]["totCstCmptdLand"].ToString();
            txtTotCstCmptdBldg.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdBldg"].ToString();
            txtTotCstCmptdPlntMach.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdPlntMach"].ToString();
            txtTotCstCmptdTotal.Text = oDataSet.Tables[0].Rows[0]["TotCstCmptdTotal"].ToString();

            txtInvSubsidyVal.Text = oDataSet.Tables[0].Rows[0]["InvSubsidyVal"].ToString();
            txtAddnInvSubsdyWmn.Text = oDataSet.Tables[0].Rows[0]["addnInvSubsdyWmn"].ToString();
            txtInvSubsdySCST.Text = oDataSet.Tables[0].Rows[0]["invSubsdySCS"].ToString();
            txtAddnInvSbsdySc10Prcnt.Text = oDataSet.Tables[0].Rows[0]["addnInvSbsdySc10Prcnt"].ToString();

            txtTotalInv.Text = oDataSet.Tables[0].Rows[0]["totalInv"].ToString();
            txtremarks.Text = oDataSet.Tables[0].Rows[0]["txtremarks"].ToString();


            if (oDataSet.Tables[0].Rows[0]["caste_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["caste_IR"].ToString() != null)
            {
                rdbCaste.SelectedValue = oDataSet.Tables[0].Rows[0]["caste_IR"].ToString();
                rdbCaste.Enabled = true;
            }
            if (oDataSet.Tables[0].Rows[0]["gender_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["gender_IR"].ToString() != null)
            {
                rdbGender.SelectedValue = oDataSet.Tables[0].Rows[0]["gender_IR"].ToString();
                rdbGender.Enabled = true;
            }
            if (oDataSet.Tables[0].Rows[0]["category_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["category_IR"].ToString() != null)
            {
                rdbCategory.SelectedValue = oDataSet.Tables[0].Rows[0]["category_IR"].ToString();
                rdbCategory.Enabled = true;
            }
            if (oDataSet.Tables[0].Rows[0]["enterprise_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["enterprise_IR"].ToString() != null)
            {
                rdbEnterprise.SelectedValue = oDataSet.Tables[0].Rows[0]["enterprise_IR"].ToString();
                rdbEnterprise.Enabled = true;
            }
            if (oDataSet.Tables[0].Rows[0]["enterprise_IR"].ToString().ToUpper() == "Expansion")
            {
                trlineofactivityexpansion.Visible = true;
                txtLOActivityExpan.Text = oDataSet.Tables[0].Rows[0]["txtLOActivityExpan"].ToString();
                txtLOActivityExpan.Enabled = false;
                txtinstalledccapExpan.Text = oDataSet.Tables[0].Rows[0]["txtinstalledccapExpan"].ToString();
                txtinstalledccapExpan.Enabled = false;
                ddlquantityinExpan.Text = oDataSet.Tables[0].Rows[0]["ddlquantityinExpan"].ToString();
                ddlquantityinExpan.Enabled = false;
                txtunitExpan.Text = oDataSet.Tables[0].Rows[0]["txtunitExpan"].ToString();
                txtunitExpan.Enabled = false;
                txtvalueExpan.Text = oDataSet.Tables[0].Rows[0]["txtvalueExpan"].ToString();
                txtvalueExpan.Enabled = false;

                TRFIXEDCAPITALHEADING.Visible = true;
                trFixedcap.Visible = true;
                TXTLANDVALUE_EXISTING.Text = oDataSet.Tables[0].Rows[0]["TXTLANDVALUE_EXISTING"].ToString();
                TXTLANDVALUE_EXISTING.Enabled = false;
                TXTBUILDINGVALE_EXISTING.Text = oDataSet.Tables[0].Rows[0]["TXTBUILDINGVALE_EXISTING"].ToString();
                TXTBUILDINGVALE_EXISTING.Enabled = false;
                TXTPLANTANDMACHINAERVALUE_EXISTING.Text = oDataSet.Tables[0].Rows[0]["TXTPLANTANDMACHINAERVALUE_EXISTING"].ToString();
                TXTPLANTANDMACHINAERVALUE_EXISTING.Enabled = false;
                TXTLANDVALUE_EXPANSION.Text = oDataSet.Tables[0].Rows[0]["TXTLANDVALUE_EXPANSION"].ToString();
                TXTLANDVALUE_EXPANSION.Enabled = false;
                TXTBUILDINGVALUE_EXPANSION.Text = oDataSet.Tables[0].Rows[0]["TXTBUILDINGVALUE_EXPANSION"].ToString();
                TXTBUILDINGVALUE_EXPANSION.Enabled = false;
                TXTPLANTANDMACHINERYVALUE_EXPANSION.Text = oDataSet.Tables[0].Rows[0]["TXTPLANTANDMACHINERYVALUE_EXPANSION"].ToString();
                TXTPLANTANDMACHINERYVALUE_EXPANSION.Enabled = false;
                TXTINCPERCENTAGE_LAND.Text = oDataSet.Tables[0].Rows[0]["TXTINCPERCENTAGE_LAND"].ToString();
                TXTINCPERCENTAGE_LAND.Enabled = false;
                TXTINCRPERCEN_BUILDINGVALUE.Text = oDataSet.Tables[0].Rows[0]["TXTINCRPERCEN_BUILDINGVALUE"].ToString();
                TXTINCRPERCEN_BUILDINGVALUE.Enabled = false;
                TXTINCPERCEN_PLANTANDMACHINERY.Text = oDataSet.Tables[0].Rows[0]["TXTINCPERCEN_PLANTANDMACHINERY"].ToString();
                TXTINCPERCEN_PLANTANDMACHINERY.Enabled = false;
            }
            else
            {
                trlineofactivityexpansion.Visible = false;
                TRFIXEDCAPITALHEADING.Visible = false;
                trFixedcap.Visible = false;
            }
            if (oDataSet.Tables[0].Rows[0]["sector_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["sector_IR"].ToString() != null)
            {
                rdbSector.SelectedValue = oDataSet.Tables[0].Rows[0]["sector_IR"].ToString();
                rdbSector.Enabled = true;
                ViewState["casteGenderGmUpdate"] = "Y";
                if (oDataSet.Tables[0].Rows[0]["sector_IR"].ToString() != "" || oDataSet.Tables[0].Rows[0]["sector_IR"] != null)
                {


                    rdbSector_SelectedIndexChanged(this, EventArgs.Empty);
                    rdbSector.Enabled = true;
                }
            }
            if (oDataSet.Tables[0].Rows[0]["serviceType_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["serviceType_IR"].ToString() != null)
            {
                rdbServiceType.SelectedValue = oDataSet.Tables[0].Rows[0]["serviceType_IR"].ToString();
                rdbServiceType.Enabled = true;
                if (oDataSet.Tables[0].Rows[0]["serviceType_IR"].ToString() != "" || oDataSet.Tables[0].Rows[0]["serviceType_IR"] != null)
                {
                    rdbServiceType_SelectedIndexChanged(this, EventArgs.Empty);
                    rdbServiceType.Enabled = true;
                }
            }
            if (oDataSet.Tables[0].Rows[0]["transportNonTrans_IR"].ToString() != "" && oDataSet.Tables[0].Rows[0]["transportNonTrans_IR"].ToString() != null)
            {
                rdbTransportNonTrans.SelectedValue = oDataSet.Tables[0].Rows[0]["transportNonTrans_IR"].ToString();
                rdbTransportNonTrans.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtExistingEnterprise_TextChanged(object sender, EventArgs e)
    {
        decimal LndCst = 0;
        decimal BuildCst = 0;
        decimal BuildPercent = 0;
        decimal Sum = 0;
        try
        {
            foreach (GridViewRow gvrow in gvFixedCapitalInvestment.Rows)
            {
                if (gvrow.RowIndex == 0)
                {
                    TextBox LandExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    if (LandExistEnterprise.Text != null && LandExistEnterprise.Text != "")
                    {
                        LndCst = Convert.ToDecimal(LandExistEnterprise.Text);
                    }
                }

                if (gvrow.RowIndex == 1)
                {
                    TextBox LandExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    if (LandExistEnterprise.Text != null && LandExistEnterprise.Text != "")
                    {
                        BuildCst = Convert.ToDecimal(LandExistEnterprise.Text);
                    }
                }

                if (gvrow.RowIndex == 2)
                {
                    TextBox LandExistEnterprise = (TextBox)gvrow.FindControl("txtExistingEnterprise");
                    if (LandExistEnterprise.Text != null && LandExistEnterprise.Text != "")
                    {
                        BuildPercent = Convert.ToDecimal(LandExistEnterprise.Text);
                    }
                }

                txttotalNew.Text = "";
                Sum = LndCst + BuildCst + BuildPercent;
                txttotalNew.Text = Sum.ToString();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtAsperApprvdCost_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AsperApprvdCost = 0;
            decimal Computedcost = 0;

            if (txtAsperApprvdCost.Text != "")
            {
                AsperApprvdCost = Convert.ToDecimal(txtAsperApprvdCost.Text);
            }
            if (txtComputedCostApprPrj.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtComputedCostApprPrj.Text);
            }
            if (Computedcost > AsperApprvdCost)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtComputedCostApprPrj.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtComputedCostApprPrj_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AsperApprvdCost = 0;
            decimal Computedcost = 0;

            if (txtAsperApprvdCost.Text != "")
            {
                AsperApprvdCost = Convert.ToDecimal(txtAsperApprvdCost.Text);
            }
            if (txtComputedCostApprPrj.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtComputedCostApprPrj.Text);
            }
            if (Computedcost > AsperApprvdCost)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtComputedCostApprPrj.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtAsperApprPjCostPM_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AsperApprPjCostPM = 0;
            decimal Computedcost = 0;

            if (txtAsperApprPjCostPM.Text != "")
            {
                AsperApprPjCostPM = Convert.ToDecimal(txtAsperApprPjCostPM.Text);
            }
            if (txtTot2ndMach.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtTot2ndMach.Text);
            }
            if (Computedcost > AsperApprPjCostPM)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtTot2ndMach.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtTot2ndMach_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal AsperApprPjCostPM = 0;
            decimal Computedcost = 0;

            if (txtAsperApprPjCostPM.Text != "")
            {
                AsperApprPjCostPM = Convert.ToDecimal(txtAsperApprPjCostPM.Text);
            }
            if (txtTot2ndMach.Text != "")
            {
                Computedcost = Convert.ToDecimal(txtTot2ndMach.Text);
            }
            if (Computedcost > AsperApprPjCostPM)
            {
                string message = "alert('Computed Cost Sholud not be Greater than Approved Project cost')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                txtTot2ndMach.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtTotCstCmptdLand_TextChanged(object sender, EventArgs e)
    {
        decimal TotCstCmptdLand = 0;
        decimal TotCstCmptdBldg = 0;
        decimal TotCstCmptdPlntMach = 0;
        decimal Sum = 0;

        try
        {
            if (txtTotCstCmptdLand.Text != "")
            {
                TotCstCmptdLand = Convert.ToDecimal(txtTotCstCmptdLand.Text);
            }
            if (txtTotCstCmptdBldg.Text != "")
            {
                TotCstCmptdBldg = Convert.ToDecimal(txtTotCstCmptdBldg.Text);
            }
            if (txtTotCstCmptdPlntMach.Text != "")
            {
                TotCstCmptdPlntMach = Convert.ToDecimal(txtTotCstCmptdPlntMach.Text);
            }

            txtTotCstCmptdTotal.Text = "";
            Sum = TotCstCmptdLand + TotCstCmptdBldg + TotCstCmptdPlntMach;
            txtTotCstCmptdTotal.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtTotCstCmptdBldg_TextChanged(object sender, EventArgs e)
    {
        decimal TotCstCmptdLand = 0;
        decimal TotCstCmptdBldg = 0;
        decimal TotCstCmptdPlntMach = 0;
        decimal Sum = 0;

        try
        {
            if (txtTotCstCmptdLand.Text != "")
            {
                TotCstCmptdLand = Convert.ToDecimal(txtTotCstCmptdLand.Text);
            }
            if (txtTotCstCmptdBldg.Text != "")
            {
                TotCstCmptdBldg = Convert.ToDecimal(txtTotCstCmptdBldg.Text);
            }
            if (txtTotCstCmptdPlntMach.Text != "")
            {
                TotCstCmptdPlntMach = Convert.ToDecimal(txtTotCstCmptdPlntMach.Text);
            }

            txtTotCstCmptdTotal.Text = "";
            Sum = TotCstCmptdLand + TotCstCmptdBldg + TotCstCmptdPlntMach;
            txtTotCstCmptdTotal.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtTotCstCmptdPlntMach_TextChanged(object sender, EventArgs e)
    {
        decimal TotCstCmptdLand = 0;
        decimal TotCstCmptdBldg = 0;
        decimal TotCstCmptdPlntMach = 0;
        decimal Sum = 0;

        try
        {
            if (txtTotCstCmptdLand.Text != "")
            {
                TotCstCmptdLand = Convert.ToDecimal(txtTotCstCmptdLand.Text);
            }
            if (txtTotCstCmptdBldg.Text != "")
            {
                TotCstCmptdBldg = Convert.ToDecimal(txtTotCstCmptdBldg.Text);
            }
            if (txtTotCstCmptdPlntMach.Text != "")
            {
                TotCstCmptdPlntMach = Convert.ToDecimal(txtTotCstCmptdPlntMach.Text);
            }

            txtTotCstCmptdTotal.Text = "";
            Sum = TotCstCmptdLand + TotCstCmptdBldg + TotCstCmptdPlntMach;
            txtTotCstCmptdTotal.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    public static char[] ReverseString1(string str)
    {
        char[] chars = str.ToCharArray();

        for (int i = 0, j = str.Length - 1; i < j; i++, j--)
        {
            char c = chars[i];
            chars[i] = chars[j];
            chars[j] = c;
        }
        return chars;
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {
        //int valid = 0;
        Failure.Visible = false;
        string newPath = "";
        General t1 = new General();

        if (FileUpload1.HasFile)
        {
            string incentiveid = ViewState["IncentveID"].ToString();

            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                try
                {
                    string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                    int i = fileType.Length;
                    if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                    {
                        //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\5500");
                        string serverpath = ConfigurationManager.AppSettings["INCfilePath"] + incentiveid.ToString() + "\\5500";
                        if (!Directory.Exists(serverpath))
                            Directory.CreateDirectory(serverpath);

                        FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                        string CrtdUser = Session["uid"].ToString();
                        string Path = serverpath;
                        string FileName = sFileName;

                        t1.InsertIncentiveAttachment(incentiveid, "0", "5500", sFileName, serverpath, CrtdUser);

                        lblFileName.Text = sFileName;
                        FileUpload1.Focus();

                        //FileInfo fi = new FileInfo(newPath + "\\" + sFileName);
                        //if (fi.Exists)//if file exists delete it
                        //{
                        //fi.Delete();
                        //}
                        //else
                        //{
                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Invalid Format Uploaded');", true);
                        FileUpload1.Focus();
                        return;
                    }
                }
                catch (Exception)//in case of an error
                {
                    DeleteFile(newPath + "\\" + sFileName);
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select a file To Upload..!');", true);
            FileUpload1.Focus();
            return;
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
    // added by chh on 23.02.2018
    public void enabledisable(bool str)
    {
        if (ddlStatus.SelectedValue != "New Industry")
        {
            foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
            {
                TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                LOA.Text = "NA";
                InstalledCapacity.Text = "NA";
                Units.Text = "NA";
                ExpansionDiversification.Text = "0";

                LOA.Enabled = str;
                InstalledCapacity.Enabled = str;
                Units.Enabled = str;
                ExpansionDiversification.Enabled = str;
            }


            foreach (GridViewRow gvrow2 in gvFixedCapitalInvestment.Rows)
            {
                TextBox ExistingEnterprise = (TextBox)gvrow2.FindControl("txtExistingEnterprise");
                TextBox ExpansionDiversification = (TextBox)gvrow2.FindControl("txtExpansionDiversification");
                TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow2.FindControl("txtExpansionDiversificationincreasepercentage");

                ExistingEnterprise.Enabled = str;
                ExpansionDiversification.Enabled = str;
                ExpansionDiversificationincreasepercentage.Enabled = str;
            }

        }


        else if (ddlStatus.SelectedValue == "New Industry")
        {
            foreach (GridViewRow gvrow in gvExpansionDriverNew.Rows)
            {
                TextBox LOA = (TextBox)gvrow.FindControl("txtLOA");
                TextBox InstalledCapacity = (TextBox)gvrow.FindControl("txtInstalledCapacity");
                TextBox Units = (TextBox)gvrow.FindControl("txtUnits");
                TextBox ExpansionDiversification = (TextBox)gvrow.FindControl("txtExpansionDiversification");

                LOA.Text = "NA";
                InstalledCapacity.Text = "NA";
                Units.Text = "NA";
                ExpansionDiversification.Text = "0";

                LOA.Enabled = false;
                InstalledCapacity.Enabled = false;
                Units.Enabled = false;
                ExpansionDiversification.Enabled = false;
            }


            foreach (GridViewRow gvrow2 in gvFixedCapitalInvestment.Rows)
            {
                TextBox ExistingEnterprise = (TextBox)gvrow2.FindControl("txtExistingEnterprise");
                TextBox ExpansionDiversification = (TextBox)gvrow2.FindControl("txtExpansionDiversification");
                TextBox ExpansionDiversificationincreasepercentage = (TextBox)gvrow2.FindControl("txtExpansionDiversificationincreasepercentage");

                ExistingEnterprise.Enabled = true;
                ExpansionDiversification.Enabled = false;
                ExpansionDiversificationincreasepercentage.Enabled = false;
            }
        }
    }




    protected void txtInvSubsidyVal_TextChanged(object sender, EventArgs e)
    {
        decimal InvSubsidyVal = 0;
        decimal AddnInvSubsdyWmn = 0;
        decimal InvSubsdySCST = 0;
        decimal AddnInvSbsdySc10Prcnt = 0;
        decimal Sum = 0;

        try
        {
            if (txtInvSubsidyVal.Text != "")
            {
                InvSubsidyVal = Convert.ToDecimal(txtInvSubsidyVal.Text);
            }
            if (txtAddnInvSubsdyWmn.Text != "")
            {
                AddnInvSubsdyWmn = Convert.ToDecimal(txtAddnInvSubsdyWmn.Text);
            }
            if (txtInvSubsdySCST.Text != "")
            {
                InvSubsdySCST = Convert.ToDecimal(txtInvSubsdySCST.Text);
            }
            if (txtAddnInvSbsdySc10Prcnt.Text != "")
            {
                AddnInvSbsdySc10Prcnt = Convert.ToDecimal(txtAddnInvSbsdySc10Prcnt.Text);
            }

            txtTotalInv.Text = "";
            Sum = InvSubsidyVal + AddnInvSubsdyWmn + InvSubsdySCST + AddnInvSbsdySc10Prcnt;
            txtTotalInv.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtAddnInvSubsdyWmn_TextChanged(object sender, EventArgs e)
    {
        decimal InvSubsidyVal = 0;
        decimal AddnInvSubsdyWmn = 0;
        decimal InvSubsdySCST = 0;
        decimal AddnInvSbsdySc10Prcnt = 0;
        decimal Sum = 0;

        try
        {
            if (txtInvSubsidyVal.Text != "")
            {
                InvSubsidyVal = Convert.ToDecimal(txtInvSubsidyVal.Text);
            }
            if (txtAddnInvSubsdyWmn.Text != "")
            {
                AddnInvSubsdyWmn = Convert.ToDecimal(txtAddnInvSubsdyWmn.Text);
            }
            if (txtInvSubsdySCST.Text != "")
            {
                InvSubsdySCST = Convert.ToDecimal(txtInvSubsdySCST.Text);
            }
            if (txtAddnInvSbsdySc10Prcnt.Text != "")
            {
                AddnInvSbsdySc10Prcnt = Convert.ToDecimal(txtAddnInvSbsdySc10Prcnt.Text);
            }

            txtTotalInv.Text = "";
            Sum = InvSubsidyVal + AddnInvSubsdyWmn + InvSubsdySCST + AddnInvSbsdySc10Prcnt;
            txtTotalInv.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtInvSubsdySCST_TextChanged(object sender, EventArgs e)
    {
        decimal InvSubsidyVal = 0;
        decimal AddnInvSubsdyWmn = 0;
        decimal InvSubsdySCST = 0;
        decimal AddnInvSbsdySc10Prcnt = 0;
        decimal Sum = 0;

        try
        {
            if (txtInvSubsidyVal.Text != "")
            {
                InvSubsidyVal = Convert.ToDecimal(txtInvSubsidyVal.Text);
            }
            if (txtAddnInvSubsdyWmn.Text != "")
            {
                AddnInvSubsdyWmn = Convert.ToDecimal(txtAddnInvSubsdyWmn.Text);
            }
            if (txtInvSubsdySCST.Text != "")
            {
                InvSubsdySCST = Convert.ToDecimal(txtInvSubsdySCST.Text);
            }
            if (txtAddnInvSbsdySc10Prcnt.Text != "")
            {
                AddnInvSbsdySc10Prcnt = Convert.ToDecimal(txtAddnInvSbsdySc10Prcnt.Text);
            }

            txtTotalInv.Text = "";
            Sum = InvSubsidyVal + AddnInvSubsdyWmn + InvSubsdySCST + AddnInvSbsdySc10Prcnt;
            txtTotalInv.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }
    protected void txtAddnInvSbsdySc10Prcnt_TextChanged(object sender, EventArgs e)
    {
        decimal InvSubsidyVal = 0;
        decimal AddnInvSubsdyWmn = 0;
        decimal InvSubsdySCST = 0;
        decimal AddnInvSbsdySc10Prcnt = 0;
        decimal Sum = 0;

        try
        {
            if (txtInvSubsidyVal.Text != "")
            {
                InvSubsidyVal = Convert.ToDecimal(txtInvSubsidyVal.Text);
            }
            if (txtAddnInvSubsdyWmn.Text != "")
            {
                AddnInvSubsdyWmn = Convert.ToDecimal(txtAddnInvSubsdyWmn.Text);
            }
            if (txtInvSubsdySCST.Text != "")
            {
                InvSubsdySCST = Convert.ToDecimal(txtInvSubsdySCST.Text);
            }
            if (txtAddnInvSbsdySc10Prcnt.Text != "")
            {
                AddnInvSbsdySc10Prcnt = Convert.ToDecimal(txtAddnInvSbsdySc10Prcnt.Text);
            }

            txtTotalInv.Text = "";
            Sum = InvSubsidyVal + AddnInvSubsdyWmn + InvSubsdySCST + AddnInvSbsdySc10Prcnt;
            txtTotalInv.Text = Sum.ToString();
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message;
            lblErrorMsg.Focus();
        }
    }



    protected void rdbCaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCaste.SelectedIndex == 0 || rdbCaste.SelectedIndex == 1 || rdbCaste.SelectedIndex == 2 || rdbCaste.SelectedIndex == 3)
        {
            rdbCaste.Enabled = false;
            rdbGender.Enabled = true;

        }
    }
    protected void rdbGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbGender.SelectedIndex == 0 || rdbGender.SelectedIndex == 1)
        {
            rdbGender.Enabled = false;
            rdbCategory.Enabled = true;

        }
    }
    protected void rdbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbCategory.SelectedIndex == 0 || rdbCategory.SelectedIndex == 1 || rdbCategory.SelectedIndex == 2 || rdbCategory.SelectedIndex == 3 || rdbCategory.SelectedIndex == 4)
        {
            rdbCategory.Enabled = false;
            rdbEnterprise.Enabled = true;

        }
    }
    protected void rdbEnterprise_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rdbEnterprise.SelectedIndex == 0 || rdbEnterprise.SelectedIndex == 1)
        //{
        //    rdbEnterprise.Enabled = false;
        //    rdbSector.Enabled = true;

        //}
        if (rdbEnterprise.SelectedIndex == 0 || rdbEnterprise.SelectedIndex == 1)
        {
            //rdbEnterprise.Enabled = false;
            //rdbSector.Enabled = true;
            rdbEnterprise.Enabled = false;
            rdbSector.Enabled = true;
            if (rdbEnterprise.SelectedIndex == 1)
            {
                trlineofactivityexpansion.Visible = true;
                TRFIXEDCAPITALHEADING.Visible = true;
                trFixedcap.Visible = true;
            }
            else
            {
                trlineofactivityexpansion.Visible = false;
                TRFIXEDCAPITALHEADING.Visible = false;
                trFixedcap.Visible = false;
            }
        }

    }
    public string ValidateControls()
    {
        int slno = 1;
        string ErrorMsg = "";

        if (txtLOActivityExpan.Text == null || txtLOActivityExpan.Text == "")
        {
            rdbSector.ClearSelection();
            txtLOActivityExpan.Focus();
            ErrorMsg = ErrorMsg + slno + ". Please Enter Line of activity\\n";
            slno = slno + 1;
        }
        if (txtinstalledccapExpan.Text == null || txtinstalledccapExpan.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Enter Installed Capacity\\n";
            slno = slno + 1;
        }
        if (ddlquantityinExpan.SelectedValue == null || ddlquantityinExpan.SelectedValue == "" || ddlquantityinExpan.SelectedValue == "--Select--")
        {
            ErrorMsg = ErrorMsg + slno + ". Please Select Units\\n";
            slno = slno + 1;
        }
        if (ddlquantityinExpan.SelectedValue == "Others")
        {
            if (txtunitExpan.Text == null || txtunitExpan.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Units\\n";
                slno = slno + 1;
            }
        }

        if (txtvalueExpan.Text == null || txtvalueExpan.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Value\\n";
            slno = slno + 1;
        }
        if (TXTLANDVALUE_EXISTING.Text == null || TXTLANDVALUE_EXISTING.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter existing land value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTBUILDINGVALE_EXISTING.Text == null || TXTBUILDINGVALE_EXISTING.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter existing building value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTPLANTANDMACHINAERVALUE_EXISTING.Text == null || TXTPLANTANDMACHINAERVALUE_EXISTING.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter existing plant and machinery value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTLANDVALUE_EXPANSION.Text == null || TXTLANDVALUE_EXPANSION.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Expansion land value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTBUILDINGVALUE_EXPANSION.Text == null || TXTBUILDINGVALUE_EXPANSION.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Expansion Building value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTPLANTANDMACHINERYVALUE_EXPANSION.Text == null || TXTPLANTANDMACHINERYVALUE_EXPANSION.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Expansion land value(In Rs.)\\n";
            slno = slno + 1;
        }
        if (TXTINCPERCENTAGE_LAND.Text == null || TXTINCPERCENTAGE_LAND.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter Land value % of increase under Expansion/Diversification\\n";
            slno = slno + 1;
        }
        if (TXTINCRPERCEN_BUILDINGVALUE.Text == null || TXTINCRPERCEN_BUILDINGVALUE.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter building value  % of increase under Expansion/Diversification\\n";
            slno = slno + 1;
        }
        if (TXTINCPERCEN_PLANTANDMACHINERY.Text == null || TXTINCPERCEN_PLANTANDMACHINERY.Text == "")
        {
            ErrorMsg = ErrorMsg + slno + ". Please enter plant and machinery value % of increase under Expansion/Diversification\\n";
            slno = slno + 1;
        }



        return ErrorMsg;
    }
    protected void rdbSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rdbEnterprise.SelectedIndex == 1)
        //{
        //    string errormsg = ValidateControls();
        //    if (errormsg.Trim().TrimStart() != "")
        //    {
        //        string message = "alert('" + errormsg + "')";
        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //        return;

        //    }

        //}
        if (rdbSector.SelectedIndex == 0 || rdbSector.SelectedIndex == 1)
        {
            rdbSector.Enabled = false;
            if (rdbSector.SelectedIndex != 0)
            {
                casteGenderGmUpdate = "Y";
                ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
                trsubmit.Visible = true;
            }
            else
            {
                trsubmit.Visible = false;
                trServiceType.Visible = true;
            }

            //trForwardApplicationTo.Visible = true;
            //trForwardGMGrid.Visible = true;
            //trFowardNote.Visible = true;

        }
    }
    protected void rdbTransportNonTrans_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbTransportNonTrans.Enabled = false;
        casteGenderGmUpdate = "Y";
        ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
        trsubmit.Visible = true;
    }

    protected void rdbServiceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        rdbServiceType.Enabled = false;
        rdbTransportNonTrans.Enabled = true;

        if (rdbServiceType.SelectedIndex == 0 || rdbServiceType.SelectedIndex == 1)
        {
            rdbServiceType.Enabled = false;
            if (rdbServiceType.SelectedIndex != 0)
            {
                casteGenderGmUpdate = "Y";
                ViewState["casteGenderGmUpdate"] = casteGenderGmUpdate;
                trsubmit.Visible = true;
            }
            else
            {
                trsubmit.Visible = false;
                trTransNonTrans.Visible = true;
            }

            //trForwardApplicationTo.Visible = true;
            //trForwardGMGrid.Visible = true;
            //trFowardNote.Visible = true;

        }


    }
    protected void ddlquantityinExpan_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlquantityinExpan.SelectedValue.ToString() == "Others")
        {
            txtunitExpan.Visible = true;
            ddlquantityinExpan.Visible = true;
        }
        else
        {
            txtunitExpan.Visible = false;
            ddlquantityinExpan.Visible = true;
        }

    }

}