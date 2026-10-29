using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UI_TSiPASS_frmClusterInformation : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    comFunctions cmf = new comFunctions();
    General Gen = new General();


    List<ClusterUnitVo> lstclusterUnitvo = new List<ClusterUnitVo>();
    List<ClusterExportVo> lstclusterexportvo = new List<ClusterExportVo>();
    List<ClusterIndustryVo> lstclusterindvo = new List<ClusterIndustryVo>();
    List<ClusterCommonFacilitiesVO> lstCommonFacilityCenters = new List<ClusterCommonFacilitiesVO>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count <= 0)
        {
            Response.Redirect("../../Index.aspx");
        }
        if (!IsPostBack)
        {
            //Session["clusterId"] = "15";

            DataTable dt = BindUnitGridAdd();
            gvUnitDetails.DataSource = dt;
            gvUnitDetails.DataBind();

            BindMandals();
            gvExports.DataSource = BindgvExportsGrid();
            gvExports.DataBind();

            gvIndustriesList.DataSource = BindgvIndustriesGrid();
            gvIndustriesList.DataBind();

            gvCommonFacility.DataSource = BindgvCommonFacilityCenterGrid();
            gvCommonFacility.DataBind();

            gvExports.Columns[4].HeaderStyle.Width = 230;
            //gvExports.Columns[5].HeaderStyle.Width = 50;
            //gvExports.Columns[3].HeaderStyle.Width = 50;
            string ClusterId = "";
            if (Request.QueryString["ClusterID"] != null && Request.QueryString["ClusterID"].ToString() != "")
            {
                ClusterId = Request.QueryString["ClusterID"].ToString();
                trRemarks.Visible = true;
                DataSet dsCluster = new DataSet();
                dsCluster = Gen.GetClusterInformation(Convert.ToInt32(ClusterId));
                if (dsCluster != null && dsCluster.Tables.Count > 0 && dsCluster.Tables[0].Rows.Count > 0)
                {
                    BtnSave1.Text = "UPDATE";
                    ddlMandal.SelectedValue = dsCluster.Tables[0].Rows[0]["mandal_cd"].ToString();
                    ddlMandal_SelectedIndexChanged(sender, e);
                    ddlVillage.Text = dsCluster.Tables[0].Rows[0]["Village_Cd"].ToString();

                    txtLineofActivity.Text = dsCluster.Tables[0].Rows[0]["LineofActivity"].ToString();
                    txtSubstationName.Text = dsCluster.Tables[0].Rows[0]["Infra_SubStation"].ToString();

                    ddlCapacitySubstation.SelectedValue = dsCluster.Tables[0].Rows[0]["Infra_Sub_CapacityForddl"].ToString();

                    txtTrainingFacilities.Text = dsCluster.Tables[0].Rows[0]["Infra_Training_Facility"].ToString();
                    txtRawMaterial.Text = dsCluster.Tables[0].Rows[0]["Raw_Material_Source"].ToString();
                    txtMajorMarkets.Text = dsCluster.Tables[0].Rows[0]["Major_Markets"].ToString();

                    if (dsCluster.Tables.Count > 1 && dsCluster.Tables[1].Rows.Count > 0)
                    {
                        ViewState["dtUnits"] = dsCluster.Tables[1];
                        gvUnitDetails.DataSource = dsCluster.Tables[1];
                        gvUnitDetails.DataBind();
                    }
                    if (dsCluster.Tables.Count > 2 && dsCluster.Tables[2].Rows.Count > 0)
                    {
                        ViewState["dtCommonFacilities"] = dsCluster.Tables[2];
                        gvCommonFacility.DataSource = dsCluster.Tables[2];
                        gvCommonFacility.DataBind();
                    }
                    if (dsCluster.Tables.Count > 3 && dsCluster.Tables[3].Rows.Count > 0)
                    {
                        ViewState["dtExportDtls"] = dsCluster.Tables[3]; ;
                        gvExports.DataSource = dsCluster.Tables[3];
                        gvExports.DataBind();
                    }
                    if (dsCluster.Tables.Count > 4 && dsCluster.Tables[4].Rows.Count > 0)
                    {
                        ViewState["dtIndustryDtls"] = dsCluster.Tables[4];
                        gvIndustriesList.DataSource = dsCluster.Tables[4];
                        gvIndustriesList.DataBind();
                    }
                }

            }

        }
    }
    protected void BtnSave3_Click(object sender, EventArgs e)
    {

    }
    protected void BTNcLEAR_Click(object sender, EventArgs e)
    {

    }
    public void BindMandals()
    {
        string Distcd = (Session["DistrictID"].ToString().Trim());
        ddlMandal.Items.Clear();
        DataSet dsm = new DataSet();
        dsm = Gen.GetMandals(Distcd);
        if (dsm.Tables[0].Rows.Count > 0)
        {
            ddlMandal.DataSource = dsm.Tables[0];
            ddlMandal.DataValueField = "Mandal_Id";
            ddlMandal.DataTextField = "Manda_lName";
            ddlMandal.DataBind();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }
        else
        {
            ddlMandal.Items.Clear();
            ddlMandal.Items.Insert(0, "--Mandal--");
        }

    }
    protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindVillages(ddlMandal, ddlVillage);
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    public void BindVillages(DropDownList ddlMandal, DropDownList ddlVillages)
    {
        if (ddlMandal.SelectedIndex == 0)
        {
            ddlVillages.Items.Clear();
            ddlVillages.Items.Insert(0, "--Village--");
        }
        else
        {
            ddlVillages.Items.Clear();
            DataSet dsv = new DataSet();
            dsv = Gen.GetVillages(ddlMandal.SelectedValue);
            if (dsv.Tables[0].Rows.Count > 0)
            {
                ddlVillages.DataSource = dsv.Tables[0];
                ddlVillages.DataValueField = "Village_Id";
                ddlVillages.DataTextField = "Village_Name";
                ddlVillages.DataBind();
                ddlVillages.Items.Insert(0, "--Village--");
            }
            else
            {
                ddlVillages.Items.Clear();
                ddlVillages.Items.Insert(0, "--Village--");
            }
        }

    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            //labouractvo.
            int clusterId = 0;
            foreach (GridViewRow gvrow in gvUnitDetails.Rows)
            {
                int index = Convert.ToInt32(gvrow.RowIndex);
                TextBox txtNoofUnits1 = (TextBox)gvUnitDetails.Rows[index].FindControl("txtNoofUnits");
                TextBox txtIvestment1 = (TextBox)gvUnitDetails.Rows[index].FindControl("txtIvestment");
                TextBox txtEmployment1 = (TextBox)gvUnitDetails.Rows[index].FindControl("txtEmployment");
                TextBox txtTurnover1 = (TextBox)gvUnitDetails.Rows[index].FindControl("txtTurnover");
                txtIvestment1.Text = "";
                txtEmployment1.Text = "";
                txtTurnover1.Text = "";
                txtNoofUnits1.Text = "";
            }
            foreach (GridViewRow gvrow in gvIndustriesList.Rows)
            {
                // 1  Micro
                // 2 Small
                // 3 Medium
                // 4 Large 
                int index = Convert.ToInt32(gvrow.RowIndex);

                //GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                //int RowIndex = gvr.RowIndex;
                DropDownList ddlunittype = (DropDownList)gvIndustriesList.Rows[index].FindControl("ddlUnitType");
                //TextBox txtnoofunitsInds = (TextBox)gvIndustriesList.Rows[index].FindControl("txtNoofUnits");
                TextBox txtInvestmentInds = (TextBox)gvIndustriesList.Rows[index].FindControl("txtInvestment");
                TextBox txtEmploymentInds = (TextBox)gvIndustriesList.Rows[index].FindControl("txtEmployment");
                TextBox txtTurnoverInds = (TextBox)gvIndustriesList.Rows[index].FindControl("txtTurnover");

                int a = Convert.ToInt32(ddlunittype.SelectedValue);
                if (a != 0)
                {
                    TextBox txtnoofunits1 = (TextBox)gvUnitDetails.Rows[a - 1].FindControl("txtNoofUnits");
                    TextBox txtIvestment1 = (TextBox)gvUnitDetails.Rows[a - 1].FindControl("txtIvestment");
                    TextBox txtEmployment1 = (TextBox)gvUnitDetails.Rows[a - 1].FindControl("txtEmployment");
                    TextBox txtTurnover1 = (TextBox)gvUnitDetails.Rows[a - 1].FindControl("txtTurnover");

                    if (txtnoofunits1.Text == "")
                    {
                        txtnoofunits1.Text = "0";
                    }


                    if (txtIvestment1.Text == "")
                    {
                        txtIvestment1.Text = "0";
                    }
                    if (txtEmployment1.Text == "")
                    {
                        txtEmployment1.Text = "0";
                    }
                    if (txtTurnover1.Text == "")
                    {
                        txtTurnover1.Text = "0";
                    }

                    //if (txtnoofunitsInds.Text == "")
                    //{
                    //    txtnoofunitsInds.Text = "0";
                    //}
                    if (txtInvestmentInds.Text == "")
                    {
                        txtInvestmentInds.Text = "0";
                    }
                    if (txtEmploymentInds.Text == "")
                    {
                        txtEmploymentInds.Text = "0";
                    }
                    if (txtTurnoverInds.Text == "")
                    {
                        txtTurnoverInds.Text = "0";
                    }

                    txtnoofunits1.Text = (Convert.ToInt32(txtnoofunits1.Text) + 1).ToString();
                    txtIvestment1.Text = (Convert.ToInt32(txtIvestment1.Text) + Convert.ToInt32(txtInvestmentInds.Text)).ToString();
                    txtEmployment1.Text = (Convert.ToInt32(txtEmployment1.Text) + Convert.ToInt32(txtEmploymentInds.Text)).ToString();
                    txtTurnover1.Text = (Convert.ToInt32(txtTurnover1.Text) + Convert.ToInt32(txtTurnoverInds.Text)).ToString();

                    // txtNoofUnits_TextChanged(sender, e);
                }
            }
            txtNoofUnits_TextChanged(sender, e);
            txtIvestment_TextChanged(sender, e);
            txtEmployment_TextChanged(sender, e);
            txtTurnover_TextChanged(sender, e);

            clusterId = SaveClusterDetails();
            //lblresult.Text = "<font color='green'>Cluster Information Added Successfully..!</font>";
            //lblresult.Visible = true;
            if (clusterId != 0)
            {
                BtnSave1.Enabled = false;
                Session["clusterId"] = clusterId.ToString();
                tdPrint.Visible = true;
                lblmsg.Text = "<font color='green'>Labour Details Added Successfully..!</font>";
                success.Visible = true;
                Failure.Visible = false;
            }
            //sessio
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    private int SaveClusterDetails()
    {
        int valid = 0;
        lblerrMsg.Text = "";
        ClusterVo cluster = new ClusterVo();

        if (BtnSave1.Text.Trim().ToUpper() == "UPDATE")
        {
            cluster.InsertMode = "U";
            if (Request.QueryString["ClusterID"] != null && Request.QueryString["ClusterID"].ToString() != "")
            {
                cluster.Cluster_Id = Convert.ToInt32(Request.QueryString["ClusterID"].ToString());
            }
            if (txtRemarks.Text.Trim() == "")
            {

                lblmsg0.Text = "<font color='red'>Please Enter Remarks..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return 0;
            }
        }
        else
        {
            cluster.InsertMode = "I";
        }
        cluster.District_Cd = (Session["DistrictID"].ToString().Trim());
        cluster.Mandal_Cd = ddlMandal.SelectedValue.ToString();
        cluster.Village_Cd = ddlVillage.SelectedValue.ToString();
        cluster.LineofActivity = txtLineofActivity.Text.Trim().ToUpper();
        cluster.Infra_Power = ddlPowerConnectivity.SelectedValue;
        cluster.Infra_SubStation = txtSubstationName.Text.Trim().ToUpper();
        cluster.Infra_Sub_Capacity = ddlCapacitySubstation.SelectedValue;
        //cluster.Infra_Common_Facility = txtCommonFacilityCent.Text;
        cluster.Infra_Training_Facility = txtTrainingFacilities.Text.Trim().ToUpper();
        cluster.Raw_Material_Source = txtRawMaterial.Text.Trim().ToUpper();
        cluster.Major_Markets = txtMajorMarkets.Text.Trim().ToUpper();
        cluster.Created_By = Session["uid"].ToString().Trim();

        foreach (GridViewRow gvrow in gvExports.Rows)
        {
            ClusterExportVo expvo = new ClusterExportVo();

            TextBox txtUnitName = (TextBox)gvrow.FindControl("txtUnitName");
            TextBox txtProductExported = (TextBox)gvrow.FindControl("txtProductExported");
            TextBox txtCountryProductExported = (TextBox)gvrow.FindControl("txtCountryProductExported");
            TextBox txtQuantumExports = (TextBox)gvrow.FindControl("txtQuantumExports");
            TextBox txtValueExports = (TextBox)gvrow.FindControl("txtValueExports");
            DropDownList ddlquantityin = (DropDownList)gvrow.FindControl("ddlquantityin");
            TextBox txtitem2 = (TextBox)gvrow.FindControl("txtitem2");
            expvo.Nameof_Unit = txtUnitName.Text.Trim().ToUpper();
            expvo.Product_Exported = txtProductExported.Text.Trim().ToUpper();
            expvo.Country_Exported = txtCountryProductExported.Text.Trim().ToUpper();
            expvo.QuantumofExports = txtQuantumExports.Text;
            expvo.ValueofExports = txtValueExports.Text;
            expvo.QuantityIn = ddlquantityin.SelectedValue;
            if (expvo.QuantityIn == "Others")
                expvo.QuantityIn = txtitem2.Text;

            lstclusterexportvo.Add(expvo);
        }

        foreach (GridViewRow gvrow in gvIndustriesList.Rows)
        {
            ClusterIndustryVo indusVo = new ClusterIndustryVo();

            TextBox txtIndusName = (TextBox)gvrow.FindControl("txtIndusName");
            TextBox txtLineofActivity1 = (TextBox)gvrow.FindControl("txtLineofActivity");
            TextBox txtInvestment = (TextBox)gvrow.FindControl("txtInvestment");
            TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");

            DropDownList ddlUnitType = (DropDownList)gvrow.FindControl("ddlUnitType");
        //    TextBox txtnoofunits1 = (TextBox)gvrow.FindControl("txtNoofUnits");
            TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

            indusVo.NameofIndustry = txtIndusName.Text.Trim().ToUpper();
            indusVo.LineofActivity = txtLineofActivity1.Text.Trim().ToUpper();
            indusVo.Investment = txtInvestment.Text;
            indusVo.Employment = txtEmployment.Text;
           // indusVo.NoofUnits = txtnoofunits1.Text.Trim().TrimStart();
            indusVo.Turnover = txtTurnover.Text.Trim().TrimStart();
            indusVo.Unit_Typevalue = ddlUnitType.SelectedValue;
            indusVo.UnitType = ddlUnitType.SelectedItem.Text;
            lstclusterindvo.Add(indusVo);
        }

        foreach (GridViewRow gvrow in gvUnitDetails.Rows)
        {
            ClusterUnitVo unitVo = new ClusterUnitVo();

            Label lblUnitType = (Label)gvrow.FindControl("lblType");
            TextBox txtNoofUnits = (TextBox)gvrow.FindControl("txtNoofUnits");
            TextBox txtIvestment = (TextBox)gvrow.FindControl("txtIvestment");
            TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");
            TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

            unitVo.Employment = txtEmployment.Text;
            unitVo.Investment = txtIvestment.Text;
            unitVo.No_Units = txtNoofUnits.Text;
            unitVo.TurnOver = txtTurnover.Text;
            unitVo.Unit_Type = lblUnitType.Text;

            lstclusterUnitvo.Add(unitVo);
        }
        foreach (GridViewRow gvrow in gvCommonFacility.Rows)
        {
            ClusterCommonFacilitiesVO commonfacvo = new ClusterCommonFacilitiesVO();

            DropDownList ddlCommonFacType = (DropDownList)gvrow.FindControl("ddlCommonFacType");
            TextBox txtCommonFacDetails = (TextBox)gvrow.FindControl("txtCommonFacDetails");

            commonfacvo.TypeCd = ddlCommonFacType.SelectedValue;
            commonfacvo.Details = txtCommonFacDetails.Text.Trim().ToUpper();

            lstCommonFacilityCenters.Add(commonfacvo);
        }


        valid = Gen.InsertClusterDetails(cluster, lstclusterUnitvo, lstclusterexportvo, lstclusterindvo, lstCommonFacilityCenters);
        return valid;
    }

    protected DataTable BindUnitGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Unit_Type");
        dt.Columns.Add("No_Units");
        dt.Columns.Add("Investment");
        dt.Columns.Add("Employment");
        dt.Columns.Add("TurnOver");

        DataRow dr = dt.NewRow();
        dr[0] = "Micro";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";

        dt.Rows.Add(dr);
        DataRow dr1 = dt.NewRow();
        dr1[0] = "Small";
        dr1[1] = "";
        dr1[2] = "";
        dr1[3] = "";
        dr1[4] = "";

        dt.Rows.Add(dr1);

        DataRow dr2 = dt.NewRow();
        dr2[0] = "Medium";
        dr2[1] = "";
        dr2[2] = "";
        dr2[3] = "";
        dr2[4] = "";

        dt.Rows.Add(dr2);

        DataRow dr3 = dt.NewRow();
        dr3[0] = "Large";
        dr3[1] = "";
        dr3[2] = "";
        dr3[3] = "";
        dr3[4] = "";

        dt.Rows.Add(dr3);

        DataRow dr4 = dt.NewRow();
        dr4[0] = "Total";
        dr4[1] = "";
        dr4[2] = "";
        dr4[3] = "";
        dr4[4] = "";

        dt.Rows.Add(dr4);

        return dt;
    }
    protected void gvUnitDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow gvrow = e.Row;
            Label lblType = (Label)gvrow.FindControl("lblType");
            DataTable dt = (DataTable)ViewState["dtUnits"];

            if (dt != null)
            {
                if (e.Row.RowIndex < dt.Rows.Count)
                {
                    TextBox txtNoofUnits = (TextBox)gvrow.FindControl("txtNoofUnits");
                    TextBox txtIvestment = (TextBox)gvrow.FindControl("txtIvestment");
                    TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");
                    TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

                    txtEmployment.Text = dt.Rows[e.Row.RowIndex]["Employment"].ToString();
                    txtIvestment.Text = dt.Rows[e.Row.RowIndex]["Investment"].ToString();
                    txtNoofUnits.Text = dt.Rows[e.Row.RowIndex]["No_Units"].ToString();
                    txtTurnover.Text = dt.Rows[e.Row.RowIndex]["TurnOver"].ToString();
                    //lblUnitType.Text = dt.Rows[e.Row.RowIndex][""].ToString();

                }
            }
            if (lblType.Text.ToUpper() == "TOTAL")
            {
                //TextBox txtUnit = (TextBox)gvrow.FindControl("lblType");
                e.Row.Enabled = false;
            }
        }
    }
    protected DataTable BindgvExportsGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("txtUnitName");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvExportsGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Nameof_Unit");
        dt.Columns.Add("Product_Exported");
        dt.Columns.Add("Country_Exported");
        dt.Columns.Add("QuantumofExports");

        dt.Columns.Add("ValueofExports");
        dt.Columns.Add("QuantityIn");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvIndustriesGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("txtIndusName");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvCommonFacilityCenterGrid()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("TypeCd");

        DataRow dr = dt.NewRow();
        dr[0] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvIndustriesGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("NameofIndustry");
        dt.Columns.Add("UnitType");
        //dt.Columns.Add("Noofunits");
        dt.Columns.Add("LineofActivity");
        dt.Columns.Add("Investment");
        dt.Columns.Add("Employment");
        dt.Columns.Add("Turnover");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";
        dr[2] = "";
        dr[3] = "";
        dr[4] = "";
        dr[5] = "";


        dt.Rows.Add(dr);

        return dt;
    }
    protected DataTable BindgvCommonFacilityGridAdd()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("TypeCd");
        dt.Columns.Add("Details");
        DataRow dr = dt.NewRow();
        dr[0] = "";
        dr[1] = "";

        dt.Rows.Add(dr);

        return dt;
    }
    protected void gvExports_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvExportsGridAdd();
                String[] arraydata = new String[6];

                int gvrcnt = gvExports.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvrow = gvExports.Rows[i];

                    TextBox txtUnitName = (TextBox)gvrow.FindControl("txtUnitName");
                    TextBox txtProductExported = (TextBox)gvrow.FindControl("txtProductExported");
                    TextBox txtCountryProductExported = (TextBox)gvrow.FindControl("txtCountryProductExported");
                    TextBox txtQuantumExports = (TextBox)gvrow.FindControl("txtQuantumExports");
                    TextBox txtValueExports = (TextBox)gvrow.FindControl("txtValueExports");

                    DropDownList ddlquantityin = (DropDownList)gvrow.FindControl("ddlquantityin");
                    TextBox txtitem2 = (TextBox)gvrow.FindControl("txtitem2");

                    arraydata[0] = txtUnitName.Text;
                    arraydata[1] = txtProductExported.Text;
                    arraydata[2] = txtCountryProductExported.Text;
                    arraydata[3] = txtQuantumExports.Text;
                    arraydata[4] = txtValueExports.Text;

                    if (ddlquantityin.SelectedValue == "Others")
                        arraydata[5] = txtitem2.Text;
                    else
                        arraydata[5] = ddlquantityin.SelectedValue;

                    if (txtUnitName.Text == "" || txtProductExported.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblerrMsg.Text = "Please enter Export details";
                        lblerrMsg.CssClass = "errormsg";
                        lblerrMsg.Visible = true;
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }


                if (valid == 0)
                {
                    ViewState["dtExportDtls"] = dt;
                    gvExports.DataSource = dt;
                    gvExports.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvExports.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvExportsGridAdd();

                    String[] arraydata = new String[6];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvrow = gvExports.Rows[i];

                            TextBox txtUnitName = (TextBox)gvrow.FindControl("txtUnitName");
                            TextBox txtProductExported = (TextBox)gvrow.FindControl("txtProductExported");
                            TextBox txtCountryProductExported = (TextBox)gvrow.FindControl("txtCountryProductExported");
                            TextBox txtQuantumExports = (TextBox)gvrow.FindControl("txtQuantumExports");
                            TextBox txtValueExports = (TextBox)gvrow.FindControl("txtValueExports");
                            DropDownList ddlquantityin = (DropDownList)gvrow.FindControl("ddlquantityin");
                            TextBox txtitem2 = (TextBox)gvrow.FindControl("txtitem2");

                            arraydata[0] = txtUnitName.Text;
                            arraydata[1] = txtProductExported.Text;
                            arraydata[2] = txtCountryProductExported.Text;
                            arraydata[3] = txtQuantumExports.Text;
                            arraydata[4] = txtValueExports.Text;
                            if (ddlquantityin.SelectedValue == "Others")
                                arraydata[5] = txtitem2.Text;
                            else
                                arraydata[5] = ddlquantityin.SelectedValue;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtExportDtls"] = dt;
                    gvExports.DataSource = dt;
                    gvExports.DataBind();
                }
                else
                {
                    lblerrMsg.Text = "Cannot remove the details, Please modify";
                    lblerrMsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvExports_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtExportDtls"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvrow = e.Row;
                        TextBox txtUnitName = (TextBox)gvrow.FindControl("txtUnitName");
                        TextBox txtProductExported = (TextBox)gvrow.FindControl("txtProductExported");
                        TextBox txtCountryProductExported = (TextBox)gvrow.FindControl("txtCountryProductExported");
                        TextBox txtQuantumExports = (TextBox)gvrow.FindControl("txtQuantumExports");
                        TextBox txtValueExports = (TextBox)gvrow.FindControl("txtValueExports");
                        DropDownList ddlquantityin = (DropDownList)gvrow.FindControl("ddlquantityin");
                        TextBox txtitem2 = (TextBox)gvrow.FindControl("txtitem2");

                        txtUnitName.Text = dt.Rows[e.Row.RowIndex]["Nameof_Unit"].ToString();
                        txtProductExported.Text = dt.Rows[e.Row.RowIndex]["Product_Exported"].ToString();
                        txtCountryProductExported.Text = dt.Rows[e.Row.RowIndex]["Country_Exported"].ToString();
                        txtQuantumExports.Text = dt.Rows[e.Row.RowIndex]["QuantumofExports"].ToString();
                        txtValueExports.Text = dt.Rows[e.Row.RowIndex]["ValueofExports"].ToString();
                        if (dt.Rows[e.Row.RowIndex]["QuantityIn"].ToString() != "")
                        {
                            ListItem item = ddlquantityin.Items.FindByText(dt.Rows[e.Row.RowIndex]["QuantityIn"].ToString());
                            if (item != null)
                            {
                                ddlquantityin.SelectedValue = ddlquantityin.Items.FindByValue(dt.Rows[e.Row.RowIndex]["QuantityIn"].ToString()).Value;
                                txtitem2.Visible = false;
                            }
                            else
                            {
                                ddlquantityin.SelectedValue = "Others";
                                txtitem2.Visible = true;
                                txtitem2.Text = dt.Rows[e.Row.RowIndex]["QuantityIn"].ToString();
                            }
                        }
                        else
                        {
                            ddlquantityin.SelectedValue = "0";
                            txtitem2.Visible = false;
                        }
                        //if (ddlquantityin.SelectedValue == "Others")
                        //    txtitem2.Text = dt.Rows[e.Row.RowIndex]["QuantityIn"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvIndustriesList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtIndustryDtls"];

                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {
                        GridViewRow gvrow = e.Row;
                        TextBox txtIndusName = (TextBox)gvrow.FindControl("txtIndusName");
                        DropDownList ddlUnitType = (DropDownList)gvrow.FindControl("ddlUnitType");
                        //TextBox txtnoofunits1 = (TextBox)gvrow.FindControl("txtNoofUnits");
                        TextBox txtLineofActivity1 = (TextBox)gvrow.FindControl("txtLineofActivity");
                        TextBox txtInvestment = (TextBox)gvrow.FindControl("txtInvestment");
                        TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");
                        TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

                        txtIndusName.Text = dt.Rows[e.Row.RowIndex]["NameofIndustry"].ToString();
                        ddlUnitType.SelectedValue = dt.Rows[e.Row.RowIndex]["UnitType"].ToString();
                        //  txtnoofunits1.Text = dt.Rows[e.Row.RowIndex]["Noofunits"].ToString();
                        txtLineofActivity1.Text = dt.Rows[e.Row.RowIndex]["LineofActivity"].ToString();
                        txtInvestment.Text = dt.Rows[e.Row.RowIndex]["Investment"].ToString();
                        txtEmployment.Text = dt.Rows[e.Row.RowIndex]["Employment"].ToString();
                        txtTurnover.Text = dt.Rows[e.Row.RowIndex]["Turnover"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvIndustriesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvIndustriesGridAdd();
                // String[] arraydata = new String[4];
                String[] arraydata = new String[6];

                int gvrcnt = gvIndustriesList.Rows.Count;
                decimal extent = 0;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvrow = gvIndustriesList.Rows[i];
                    TextBox txtIndusName = (TextBox)gvrow.FindControl("txtIndusName");
                    DropDownList ddlUnitType = (DropDownList)gvrow.FindControl("ddlUnitType");
                    // TextBox txtnoofunitsNew = (TextBox)gvrow.FindControl("txtNoofUnits");
                    TextBox txtLineofActivity1 = (TextBox)gvrow.FindControl("txtLineofActivity");
                    TextBox txtInvestment = (TextBox)gvrow.FindControl("txtInvestment");
                    TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");
                    TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

                    arraydata[0] = txtIndusName.Text;
                    arraydata[1] = ddlUnitType.SelectedValue;
                    //  arraydata[2] = txtnoofunitsNew.Text;
                    arraydata[2] = txtLineofActivity1.Text;
                    arraydata[3] = txtInvestment.Text;
                    arraydata[4] = txtEmployment.Text;
                    arraydata[5] = txtTurnover.Text;

                    if (txtIndusName.Text == "" || txtLineofActivity1.Text == "")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblerrMsg.Text = "Please enter Industry details";
                        lblerrMsg.CssClass = "errormsg";
                    }
                    dt.Rows[i].ItemArray = arraydata;
                    DataRow dRow;
                    dRow = null;
                    dRow = dt.NewRow();
                    dt.Rows.Add(dRow);
                }


                if (valid == 0)
                {
                    ViewState["dtIndustryDtls"] = dt;
                    gvIndustriesList.DataSource = dt;
                    gvIndustriesList.DataBind();
                }


                //if (ddlunittype.SelectedValue == "1")
                //{ 
                // TextBox txtnoofunits= (TextBox)gvUnitDetails.Rows[0].FindControl("txtNoofUnits");
                // TextBox txtIvestment = (TextBox)gvUnitDetails.Rows[0].FindControl("txtIvestment");
                // TextBox txtEmployment = (TextBox)gvUnitDetails.Rows[0].FindControl("txtIvestment");
                // TextBox txtTurnover = (TextBox)gvUnitDetails.Rows[0].FindControl("txtTurnover");
                //}
                //else if (ddlunittype.SelectedValue == "2")
                //{
                //    TextBox txtnoofunits = (TextBox)gvUnitDetails.Rows[1].FindControl("txtNoofUnits");
                //    TextBox txtIvestment = (TextBox)gvUnitDetails.Rows[1].FindControl("txtIvestment");
                //    TextBox txtEmployment = (TextBox)gvUnitDetails.Rows[1].FindControl("txtIvestment");
                //    TextBox txtTurnover = (TextBox)gvUnitDetails.Rows[1].FindControl("txtTurnover");
                //}
                //else if (ddlunittype.SelectedValue == "3")
                //{
                //    TextBox txtnoofunits = (TextBox)gvUnitDetails.Rows[2].FindControl("txtNoofUnits");
                //    TextBox txtIvestment = (TextBox)gvUnitDetails.Rows[2].FindControl("txtIvestment");
                //    TextBox txtEmployment = (TextBox)gvUnitDetails.Rows[2].FindControl("txtIvestment");
                //    TextBox txtTurnover = (TextBox)gvUnitDetails.Rows[2].FindControl("txtTurnover");
                //}
                //else if (ddlunittype.SelectedValue == "4")
                //{
                //    TextBox txtnoofunits = (TextBox)gvUnitDetails.Rows[3].FindControl("txtNoofUnits");
                //    TextBox txtIvestment = (TextBox)gvUnitDetails.Rows[3].FindControl("txtIvestment");
                //    TextBox txtEmployment = (TextBox)gvUnitDetails.Rows[3].FindControl("txtIvestment");
                //    TextBox txtTurnover = (TextBox)gvUnitDetails.Rows[3].FindControl("txtTurnover");
                //}
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvIndustriesList.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvIndustriesGridAdd();

                    String[] arraydata = new String[6];

                    int j = Convert.ToInt32(e.CommandArgument);
                    decimal extent = 0;
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {
                        if (i != j)
                        {
                            GridViewRow gvrow = gvIndustriesList.Rows[i];
                            TextBox txtIndusName = (TextBox)gvrow.FindControl("txtIndusName");
                            DropDownList ddlUnitType = (DropDownList)gvrow.FindControl("ddlUnitType");
                            //TextBox txtnoofunitsNew = (TextBox)gvrow.FindControl("txtNoofUnits");
                            TextBox txtLineofActivity1 = (TextBox)gvrow.FindControl("txtLineofActivity");
                            TextBox txtInvestment = (TextBox)gvrow.FindControl("txtInvestment");
                            TextBox txtEmployment = (TextBox)gvrow.FindControl("txtEmployment");
                            TextBox txtTurnover = (TextBox)gvrow.FindControl("txtTurnover");

                            arraydata[0] = txtIndusName.Text;
                            arraydata[1] = ddlUnitType.SelectedValue;
                            //  arraydata[2] = txtnoofunitsNew.Text;
                            arraydata[2] = txtLineofActivity1.Text;
                            arraydata[3] = txtInvestment.Text;
                            arraydata[4] = txtEmployment.Text;
                            arraydata[5] = txtTurnover.Text;


                            //arraydata[0] = txtIndusName.Text;
                            //arraydata[1] = txtLineofActivity1.Text;
                            //arraydata[2] = txtInvestment.Text;
                            //arraydata[3] = txtEmployment.Text;
                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }

                    dt.Rows.RemoveAt(j);
                    ViewState["dtIndustryDtls"] = dt;
                    gvIndustriesList.DataSource = dt;
                    gvIndustriesList.DataBind();
                }
                else
                {
                    lblerrMsg.Text = "Cannot remove the details, Please modify";
                    lblerrMsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }

    protected void txtNoofUnits_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;
            //int Unitcount = 0;
            //TextBox txtinvestment = (TextBox)gvrow.FindControl("txtIvestment");
            //txtinvestment.Focus();

            int gvrcnt = gvUnitDetails.Rows.Count;

            int UnitCountforsum = 0;

            for (int i = 0; i < gvrcnt; i++)
            {
                GridViewRow gvr = gvUnitDetails.Rows[i];
                Label lblUnitType = (Label)gvr.FindControl("lblType");
                TextBox UnitCount = (TextBox)gvr.FindControl("txtNoofUnits");
                int intUnitcount = 0;
                if (lblUnitType.Text != "Total")
                {
                    if (UnitCount.Text.Trim() != "")
                        intUnitcount = Convert.ToInt32(UnitCount.Text.Trim());
                    UnitCountforsum = UnitCountforsum + intUnitcount;
                }
                if (lblUnitType.Text == "Total")
                {
                    if (UnitCount.Text == "")
                    {
                        UnitCount.Text = "0";
                    }
                    UnitCount.Text = (UnitCountforsum).ToString();
                }
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void txtIvestment_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;

            //TextBox txtemployment = (TextBox)gvrow.FindControl("txtEmployment");
            //txtemployment.Focus();

            int gvrcnt = gvUnitDetails.Rows.Count;
            int UnitCountforsum = 0;
            for (int i = 0; i < gvrcnt; i++)
            {
                GridViewRow gvr = gvUnitDetails.Rows[i];
                Label lblUnitType = (Label)gvr.FindControl("lblType");
                TextBox UnitCount = (TextBox)gvr.FindControl("txtIvestment");
                //if (lblUnitType.Text == "Total")
                //{
                //    TextBox UnitCount = (TextBox)gvr.FindControl("txtIvestment");
                //    if (UnitCount.Text == "")
                //    {
                //        UnitCount.Text = "0";
                //    }
                //    UnitCount.Text = (Convert.ToDecimal(UnitCount.Text) + Convert.ToDecimal(((TextBox)sender).Text)).ToString();
                //}
                int intUnitcount = 0;
                if (lblUnitType.Text != "Total")
                {
                    if (UnitCount.Text.Trim() != "")
                        intUnitcount = Convert.ToInt32(UnitCount.Text.Trim());
                    UnitCountforsum = UnitCountforsum + intUnitcount;
                }
                if (lblUnitType.Text == "Total")
                {
                    if (UnitCount.Text == "")
                    {
                        UnitCount.Text = "0";
                    }
                    UnitCount.Text = (UnitCountforsum).ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void txtEmployment_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;

            //TextBox txtturnover = (TextBox)gvrow.FindControl("txtTurnover");
            //txtturnover.Focus();
            int UnitCountforsum = 0;
            int gvrcnt = gvUnitDetails.Rows.Count;
            for (int i = 0; i < gvrcnt; i++)
            {
                GridViewRow gvr = gvUnitDetails.Rows[i];
                Label lblUnitType = (Label)gvr.FindControl("lblType");
                TextBox UnitCount = (TextBox)gvr.FindControl("txtEmployment");
                //if (lblUnitType.Text == "Total")
                //{
                //    TextBox UnitCount = (TextBox)gvr.FindControl("txtEmployment");
                //    if (UnitCount.Text == "")
                //    {
                //        UnitCount.Text = "0";
                //    }
                //    UnitCount.Text = (Convert.ToInt32(UnitCount.Text) + Convert.ToInt32(((TextBox)sender).Text)).ToString();
                //}
                int intUnitcount = 0;
                if (lblUnitType.Text != "Total")
                {
                    if (UnitCount.Text.Trim() != "")
                        intUnitcount = Convert.ToInt32(UnitCount.Text.Trim());
                    UnitCountforsum = UnitCountforsum + intUnitcount;
                }
                if (lblUnitType.Text == "Total")
                {
                    if (UnitCount.Text == "")
                    {
                        UnitCount.Text = "0";
                    }
                    UnitCount.Text = (UnitCountforsum).ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void txtTurnover_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow gvrow = (GridViewRow)((TextBox)sender).Parent.Parent;

            //int j = gvrow.RowIndex;
            int UnitCountforsum = 0;
            //TextBox txtunitcount = (TextBox)gvUnitDetails.Rows[j + 1].Cells[2].FindControl("txtNoofUnits");
            //txtunitcount.Focus();

            int gvrcnt = gvUnitDetails.Rows.Count;
            for (int i = 0; i < gvrcnt; i++)
            {
                GridViewRow gvr = gvUnitDetails.Rows[i];
                Label lblUnitType = (Label)gvr.FindControl("lblType");
                TextBox UnitCount = (TextBox)gvr.FindControl("txtTurnover");
                //if (lblUnitType.Text == "Total")
                //{
                //    TextBox UnitCount = (TextBox)gvr.FindControl("txtTurnover");
                //    if (UnitCount.Text == "")
                //    {
                //        UnitCount.Text = "0";
                //    }
                //    UnitCount.Text = (Convert.ToDecimal(UnitCount.Text) + Convert.ToDecimal(((TextBox)sender).Text)).ToString();
                //}
                int intUnitcount = 0;
                if (lblUnitType.Text != "Total")
                {
                    if (UnitCount.Text.Trim() != "")
                        intUnitcount = Convert.ToInt32(UnitCount.Text.Trim());
                    UnitCountforsum = UnitCountforsum + intUnitcount;
                }
                if (lblUnitType.Text == "Total")
                {
                    if (UnitCount.Text == "")
                    {
                        UnitCount.Text = "0";
                    }
                    UnitCount.Text = (UnitCountforsum).ToString();
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridViewRow gvrow = (GridViewRow)((DropDownList)sender).Parent.Parent;

        DropDownList ddlquantityin = (DropDownList)gvrow.FindControl("ddlquantityin");
        TextBox txtitem2 = (TextBox)gvrow.FindControl("txtitem2");


        if (ddlquantityin.SelectedValue.ToString() == "Others")
        {
            txtitem2.Visible = true;

        }
        else
        {
            txtitem2.Visible = false;

        }

    }
    protected void gvCommonFacility_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            DataSet dsm = new DataSet();
            dsm = Gen.GetClusterCommonFacilityTypes();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtCommonFacilities"];
                GridViewRow gvrow = e.Row;
                DropDownList ddlCommonFacType = (DropDownList)gvrow.FindControl("ddlCommonFacType");
                ddlCommonFacType.Items.Clear();
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlCommonFacType.DataSource = dsm.Tables[0];
                    ddlCommonFacType.DataValueField = "TypeCd";
                    ddlCommonFacType.DataTextField = "TypeDesc";
                    ddlCommonFacType.DataBind();
                    ddlCommonFacType.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlCommonFacType.Items.Clear();
                    ddlCommonFacType.Items.Insert(0, "--Select--");
                }
                if (dt != null)
                {
                    if (e.Row.RowIndex < dt.Rows.Count)
                    {

                        TextBox txtCommonFacDetails = (TextBox)gvrow.FindControl("txtCommonFacDetails");
                        ddlCommonFacType.SelectedValue = dt.Rows[e.Row.RowIndex]["TypeCd"].ToString();
                        txtCommonFacDetails.Text = dt.Rows[e.Row.RowIndex]["Details"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }
    protected void gvCommonFacility_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            lblerrMsg.Text = "";
            int valid = 0;
            if (e.CommandName == "Add")
            {
                dt = BindgvCommonFacilityGridAdd();
                String[] arraydata = new String[2];

                int gvrcnt = gvCommonFacility.Rows.Count;
                for (int i = 0; i < gvrcnt; i++)
                {
                    GridViewRow gvrow = gvCommonFacility.Rows[i];
                    DropDownList ddlCommonFacType = (DropDownList)gvrow.FindControl("ddlCommonFacType");
                    TextBox txtCommonFacDetails = (TextBox)gvrow.FindControl("txtCommonFacDetails");

                    arraydata[0] = ddlCommonFacType.SelectedValue;
                    arraydata[1] = txtCommonFacDetails.Text;
                    if (ddlCommonFacType.SelectedValue == "--Select--" || ddlCommonFacType.SelectedValue == "0")// || txtEnjExtent.Value == "")
                    {
                        valid = 1;
                        lblerrMsg.Text = "Please Select Common Facility Center Type";
                        lblerrMsg.CssClass = "errormsg";
                    }
                    if (valid == 0)
                    {
                        dt.Rows[i].ItemArray = arraydata;
                        DataRow dRow;
                        dRow = null;
                        dRow = dt.NewRow();
                        dt.Rows.Add(dRow);
                    }
                }


                if (valid == 0)
                {
                    ViewState["dtCommonFacilities"] = dt;
                    gvCommonFacility.DataSource = dt;
                    gvCommonFacility.DataBind();
                }
                //SetFocus(gvEnjoyer);
            }
            else if (e.CommandName == "Remove")
            {
                int gvrcnt = gvCommonFacility.Rows.Count;
                if (gvrcnt > 1)
                {
                    dt = BindgvCommonFacilityGridAdd();

                    String[] arraydata = new String[2];

                    int j = Convert.ToInt32(e.CommandArgument);
                    int i;
                    for (i = 0; i < gvrcnt; i++)
                    {

                        if (i != j)
                        {
                            GridViewRow gvrow = gvCommonFacility.Rows[i];
                            DropDownList ddlCommonFacType = (DropDownList)gvrow.FindControl("ddlCommonFacType");
                            TextBox txtCommonFacDetails = (TextBox)gvrow.FindControl("txtCommonFacDetails");

                            arraydata[0] = ddlCommonFacType.SelectedValue;
                            arraydata[1] = txtCommonFacDetails.Text;

                            DataRow dRow;
                            dRow = null;
                            dRow = dt.NewRow();
                            dt.Rows.Add(dRow);

                            dt.Rows[i].ItemArray = arraydata;
                        }
                    }
                    dt.Rows.RemoveAt(j);
                    ViewState["dtCommonFacilities"] = dt;
                    gvCommonFacility.DataSource = dt;
                    gvCommonFacility.DataBind();
                }
                else
                {
                    lblerrMsg.Text = "Cannot remove the details, Please modify";
                    lblerrMsg.CssClass = "errormsg";
                }
            }
        }
        catch (Exception ex)
        {
            lblerrMsg.Text = ex.Message;
            lblerrMsg.CssClass = "errormsg";
        }
    }


    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    if (ViewState["clusterId"] != null && ViewState["clusterId"].ToString() != "")
    //    {
    //        Response.Redirect("ClusterPrint.aspx?ClusterId=" + Request.QueryString[0].ToString());
    //    }
    //}
}
