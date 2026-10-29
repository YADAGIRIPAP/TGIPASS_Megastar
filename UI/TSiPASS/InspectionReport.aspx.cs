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
public partial class UI_TSiPASS_InspectionReport : System.Web.UI.Page
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


        if (!IsPostBack)
        {

            string IncIDfrData = Request.QueryString[0].ToString();
            ViewState["IncentveID"] = Request.QueryString[0].ToString();
            DataSet ds = new DataSet();
            ds = Gen.GetIncentiveDeptDetails(IncIDfrData);
            FillDetails(ds);
            DataSet dsnewre = new DataSet();
            dsnewre = Gen.GetIncetiveDetailsdeptAttachementsIpo(IncIDfrData, "6");
            if (dsnewre != null && dsnewre.Tables.Count > 0 && dsnewre.Tables[0].Rows.Count > 0)
            {
                GridView3att.DataSource = dsnewre.Tables[0];
                GridView3att.DataBind();
            }
            dtMyTableCertificate = createtablecrtificate1();
            Session["CertificateTb2"] = dtMyTableCertificate;
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
            FillDetails(ds);

        }
        catch
        {

        }
    }
    #endregion

    protected void GridView3att_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (e.Row.FindControl("lbl") as Label);
            HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);
            CheckBox chkverified = (e.Row.FindControl("chkverified") as CheckBox);
            Label lblVerifiednew = (e.Row.FindControl("lblVerified") as Label);


            if (lbl.Text == "")
            {
                //e.Row.Cells[1].ColumnSpan = 2;
                //e.Row.Cells.RemoveAt(2);
                HyperLinkSubsidy.Visible = false;
                e.Row.Font.Bold = true;
                chkverified.Visible = false;
            }
            if (HyperLinkSubsidy.NavigateUrl == "")
            {
                HyperLinkSubsidy.Visible = false;
                chkverified.Visible = false;
            }
            if (lblVerifiednew.Text == "YES" && chkverified.Visible == true)
            {

                chkverified.Checked = true;
                chkverified.Enabled = false;
            }
        }
    }

    public void FillDetails(DataSet ds)
    {
        string IncentID = "";
        DataSet oDataSet = new DataSet();
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //divCommonAppli.Visible = true;
                //IncentID = ds.Tables[0].Rows[0]["IncentveID"].ToString();

                ViewState["lblUdyogAdhar"] = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                ViewState["lblnameofIND"] = ds.Tables[0].Rows[0]["UnitName"].ToString();
                ViewState["OrgType2"] = ds.Tables[0].Rows[0]["OrgType2"].ToString();
                string UnitDistName = ds.Tables[0].Rows[0]["UnitDistName"].ToString();
                // ddlConstOfUnit.Visible = false;
                string UNITMANDAL = ds.Tables[0].Rows[0]["UNITMANDAL"].ToString();
                string UNITVILLAGE = ds.Tables[0].Rows[0]["UNITVILLAGE"].ToString(); ;
                string UnitHNO = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                string UnitStreet = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                string str = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                // ApplClm = ds.Tables[0].Rows[0]["created_dt"].ToString();
                txtRcptAppln.Text = ds.Tables[0].Rows[0]["created_dt"].ToString();

                //lblAddress.Text = "Sy no:" + UnitHNO + "," + "," + UNITVILLAGE + "(V)" + "," + UNITMANDAL + "(M)" + ",\n" + UnitDistName + "(Dist).";

                lblDCP.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                ddlStatus.SelectedItem.Text = str.ToString();
                
           

                if (ds != null && ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    if (ds.Tables[5].Rows[0]["TobeinspectedDate"].ToString() != null)   //nulll value allow
                        txtInpectedDate.Text = ds.Tables[5].Rows[0]["TobeinspectedDate"].ToString();//changed nikhil

                    txtIPOName.Text = ds.Tables[5].Rows[0]["empname"].ToString();
                    lblIPODesignation.Text = ds.Tables[5].Rows[0]["Designation"].ToString();
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
                        txtTotCstCmptdLand.Text = ds.Tables[3].Rows[0]["LandApprovedProjectCost"].ToString();
                  
                    if (ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString() != null)
                        txtTotCstCmptdBldg.Text = ds.Tables[3].Rows[0]["BuildingApprovedProjectCost"].ToString();

                    if (ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString() != null)
                        txtTotCstCmptdPlntMach.Text = ds.Tables[3].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();


                }
                //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //{
                //    if (ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString() != null)
                //        txtAprdPjCst25Prcnt.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                //    if (ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString() != null)
                //        txtLndCst25Prcnt.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                //    if (ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString() != null)
                //        txt25BldgCvl.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();                                 


                //}
                //land capital cost tab is not getting captured  ---nikhil..

                //land 25% Land cost capital cost tab is not getting captured  ---nikhil..

                //Building and other civil works  --nikhil

                //10% of the total value of the civil works   --nikhil

                //Valuation of Project tab --nikhil

                //  Plant and Machinary and Equipment(PM & E)  --nikhil

                // Total Cost computed  ---nikhil 

                //recomended  sanction of investment Subsidy --nikhil

                //Attachments --nikhil.




                // lblCons_Unit.Text = ds.Tables[0].Rows[0]["OrgType2"].ToString();
                //  consUnit = lblCons_Unit.Text.ToString();
                string IncIDfrData = Request.QueryString[0].ToString();

                Label1.Text = "Line of Activity for " + str.ToString();

                oDataSet = Gen.GETINCENTIVESCAFDATA_INSP(IncIDfrData);
                gvInstalledCap.Visible = true;
                gvInstalledCap.DataSource = oDataSet.Tables[1];
                gvInstalledCap.DataBind();

                if (oDataSet.Tables[1].Rows.Count == 0)
                {

                    Label1.Text = "Line of Activity Not Available, Shortfall may be informed to GM";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    gvInstalledCap.Visible = false;
                }
            }
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
            else if (ctrl is RadioButton)
                ((RadioButton)ctrl).Enabled = false;


            DisableForm(ctrl.Controls);
        }
    }


    protected void ddlqtyLOA_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string succMesg = "";

        succMesg = insertDetailsofInspection();
        try
        {
            foreach (GridViewRow gvrow in GridView3att.Rows)
            {
                string attid = ((Label)gvrow.FindControl("lblatchid")).Text.ToString();
                CheckBox chkverified = ((CheckBox)gvrow.FindControl("chkverified"));
                if (chkverified.Visible == true && chkverified.Checked == true && attid != "0" && attid != "")
                {
                    int valid = Gen.UpdateverifyInctveattachment(ViewState["IncentveID"].ToString(), attid, Session["uid"].ToString(),"");
                }
            }
        }
        catch (Exception ex)
        {

        }
        if (succMesg == "1")
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccMesg", "alert('Inspection Report Submitted Successfully');", true);
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccMesg", "alert('Inspection report uploaded earlier!!');", true);

    }

    public string insertDetailsofInspection()
    {
        string Status;
        string created_by = Session["uid"].ToString();
        string usCode = Session["User_Code"].ToString();
        string lblCons = ViewState["OrgType2"].ToString();
        string indStat = ddlStatus.SelectedItem.Text.ToString();



        //  incentiveID = 

        lblIPODesignation.Text = "";
        //ddlNameofInd.SelectedItem.Text.ToString() = "";
        string inctiveID = ViewState["IncentveID"].ToString(); // remove this for testing
        string MstIncentiveId = Request.QueryString[1].ToString();

        string[] InpectedDate = txtInpectedDate.Text.Split('/');
        string[] lblDCPdate = lblDCP.Text.Split('/');
        string[] DateShrtfall = txtDateShrtfall.Text.Split('/');
        string[] DtShrtFallRcvd = txtDtShrtFallRcvd.Text.Split('/');

        string DateShrtfallnew = "";
        string DtShrtFallRcvdnew = "";
        if (DateShrtfall[0] == "")
        {
            DateShrtfallnew = null;
        }
        else
        {
            DateShrtfallnew = DateShrtfall[2] + "/" + DateShrtfall[1] + "/" + DateShrtfall[0];
        }

        if (DtShrtFallRcvd[0] == "")
        {
            DtShrtFallRcvdnew = null;
        }
        else
        {
            DtShrtFallRcvdnew = DtShrtFallRcvd[2] + "/" + DtShrtFallRcvd[1] + "/" + DtShrtFallRcvd[0];
        }
        Status = Gen.insertInspRprtData(inctiveID, Session["User_Code"].ToString(), ViewState["lblnameofIND"].ToString(), ViewState["lblUdyogAdhar"].ToString(), txtIPOName.Text, lblIPODesignation.Text.ToString(),
            InpectedDate[2] + "/" + InpectedDate[1] + "/" + InpectedDate[0], lblCons, txtPersonIndustry.Text, indStat, rdbVerifyCert.SelectedItem.Text, "", lblDCPdate[2] + "/" + lblDCPdate[1] + "/" + lblDCPdate[0],
           DateShrtfallnew, DtShrtFallRcvdnew, txtExtent.Text, txtBuiltupAra.Text, txt5TtimesBltup.Text, txtExtentElgble.Text,
            rdblYesNoClaimSubmn.SelectedItem.Text, rdblClmApplRmbrLandCst.SelectedItem.Text, txt25BldgCvl.Text, txtLndCst25Prcnt.Text, txtRegnFee25Prcnt.Text, txtTotal25Prcnt.Text,
            txtAprdPjCst25Prcnt.Text, txtProprtn25Prcnt.Text, txtComputedcost.Text, txtValofItems.Text, txtPlnthArea.Text, txtTSSFC.Text, txtAprvPJVal.Text,
            txtAppJTot.Text, txtTotVal1.Text, txtTotVal2.Text, txtTotVal3.Text, txtTotVal4.Text, txtTotVal10.Text, txtGrndTotVal.Text, txtAsperApprPjCostPM.Text,
            txtAsperCivilEngr.Text, txtComptdGm.Text, txtComputedcost.Text, txtAsperApprPjCostPM.Text, txtAsperListPM.Text, txtTechKnowPM.Text,
            txt2ndMachPM.Text, txtPrcnt2ndMach.Text, txtTotal2ndHandMach.Text, txtTot2ndMach.Text, txtTotCstCmptdLand.Text, txtTotCstCmptdBldg.Text,
            txtTotCstCmptdPlntMach.Text, txtTotCstCmptdTotal.Text, txtInvSubsidyVal.Text, txtAddnInvSubsdyWmn.Text, "",
            txtAddnInvSbsdySc10Prcnt.Text, txtTotalInv.Text, "", "", "", "", "", "", "", "", "", "", "", MstIncentiveId, txtremarks.Text.Trim());



        //txtLOAInsp.Text,txtUnitInsp.Text,txtInstldCapInsp.Text,txtValueInsp.Text,//remove coments if not necc
        //txtLOAExistEntr.Text,txtInstCapExistEntr.Text,txtPercntIncrExistEntr.Text,txtLOAExpn.Text,txtInsCapExpn.Text,txtIncrExpn.Text,
        //txtLandExtEntr.Text,txtBldngExtEntr.Text,txtPltMachExstEntr.Text,txtTotLand.Text,txtExpnLAnd.Text, txtBldngExpnDivers.Text, txtPltMachExpn.Text, 
        // txtTolBldg.Text, txtLandExpnDiverse.Text, txtBldgIncrExpn.Text, txtPltMachIncrExpn.Text, txtToTPlantMach.Text, ddlConstOfUnit.SelectedItem.Text

        return Status;
    }

    protected void txtTotCstCmptdPlntMach_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtLndCst25Prcnt_TextChanged(object sender, EventArgs e)
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
            Regnfee = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
        }

        if (txtRegnfee.Text != null && txtRegnfee.Text != "")
        {
            RegnFee25Prcnt = Convert.ToDecimal(txtRegnfee.Text);
        }

        Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
        txtTotal25Prcnt.Text = Sum.ToString();

    }
    protected void txtRegnFee25Prcnt_TextChanged(object sender, EventArgs e)
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
            Regnfee = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
        }

        if (txtRegnfee.Text != null && txtRegnfee.Text != "")
        {
            RegnFee25Prcnt = Convert.ToDecimal(txtRegnfee.Text);
        }

        Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
        txtTotal25Prcnt.Text = Sum.ToString();
    }
    protected void txtRegnfee_TextChanged(object sender, EventArgs e)
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
            Regnfee = Convert.ToDecimal(txtRegnFee25Prcnt.Text);
        }

        if (txtRegnfee.Text != null && txtRegnfee.Text != "")
        {
            RegnFee25Prcnt = Convert.ToDecimal(txtRegnfee.Text);
        }

        Sum = LndCst25Prcnt + Regnfee + RegnFee25Prcnt;
        txtTotal25Prcnt.Text = Sum.ToString();
    }
    protected void txtAprdPjCst25Prcnt_TextChanged(object sender, EventArgs e)
    {
        decimal AprdPjCst25Prcnt = 0;
        decimal Computedcost = 0;

        if ( txtAprdPjCst25Prcnt.Text != "")
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
    protected void txtComputedcost_TextChanged(object sender, EventArgs e)
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

    protected void txtBuiltupAra_TextChanged(object sender, EventArgs e)
    {
        if (txtBuiltupAra.Text.Trim() != "")
        {
            txt5TtimesBltup.Text = (5 * Convert.ToDecimal(txtBuiltupAra.Text.Trim())).ToString();
        }
    }
}
