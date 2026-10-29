using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UI_TSiPASS_CFEDetailsVerification : System.Web.UI.Page
{
    string ErrorMsg = "";
    DB.DB con = new DB.DB();
    General clsGeneral = new General();
    DataSet ds = new DataSet();
    General Gen = new General();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (Convert.ToString(Session["uid"]) != "")
            {
                if (Request.QueryString.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        if (Request.QueryString["Enterpid"].ToString() != "")
                        {
                            BindLineofActivityName();
                            FillGrid();
                            txtNewPlantMachnryCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtExpPlantMachnryCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtNewBuildingCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtExpBuildingCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtNewLandCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtExpLandCost.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtNewTurnover.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                            txtExpTurnover.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");



                        }
                    }
                }
            }
            else
            { Response.Redirect("~/Ipasslogin.aspx"); }
        }
        catch (Exception ex)
        {
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void BindLineofActivityName()
    {
        try
        {
            ddlLOA.Items.Clear();
            DataSet dsc = new DataSet();
            dsc = Gen.GetCategoryDetNew(Session["uid"].ToString());
            if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
            {
                ddlLOA.DataSource = dsc.Tables[0];
                ddlLOA.DataValueField = "intLineofActivityid";
                ddlLOA.DataTextField = "LineofActivity_Name";
                ddlLOA.DataBind();
                ddlLOA.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlLOA.Items.Insert(0, "--Select--");
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = ex.Message;
            //Failure.Visible = true;
            //success.Visible = false;
            Response.Write(ex);
            LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
        }
    }
    public void FillGrid()
    {
        try
        {
            string Enterpid = Request.QueryString["Enterpid"].ToString();
            ds = clsGeneral.GetCFEEnterprenuerDetailsNew(Enterpid);

            if (ds.Tables[0].Rows.Count != 0)
            {

                lblUidNo.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                lblCFEEnterpid.Text = Request.QueryString["Enterpid"].ToString();
                lblNameOfUndertaker.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                lblpan.Text = ds.Tables[0].Rows[0]["PANcardno"].ToString();
                ddlLOA.SelectedValue= ds.Tables[0].Rows[0]["intLineofActivity"].ToString(); 
                lblExpansion.Text = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                rblExpansion.SelectedValue = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                rblSector.Text = ds.Tables[0].Rows[0]["Sec_EnterpriseName"].ToString();
                lblSector.Text = ds.Tables[0].Rows[0]["Sec_EnterpriseName"].ToString();
                lblLOA.Text= ds.Tables[0].Rows[0]["LineofActivity_Name"].ToString();
                lblMale.Text = ds.Tables[0].Rows[0]["DirectMale"].ToString();
                lblFemale.Text = ds.Tables[0].Rows[0]["DirectFemale"].ToString();
                lblTotal.Text = ds.Tables[0].Rows[0]["Prop_Emp"].ToString();
                rblExpansion_SelectedIndexChanged(null, EventArgs.Empty);

                lblLandCostN.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                lblBuildN.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                lblPlantN.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();
                lblAnnualN.Text = ds.Tables[0].Rows[0]["annualTurnover_act"].ToString();

                lblLandCostE.Text = ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString();
                lblBuildE.Text = ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString();
                lblPlantE.Text = ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString();
                lblAnnualE.Text = ds.Tables[0].Rows[0]["annualTurnover_Exp_act"].ToString();

                if (ds.Tables[0].Rows[0]["ProposalFor"].ToString() != "New")
                {
                    
                    lblProjtype.Text = "For New Project";
                    //HideColumn(true); Val_LandExpansion
                }
                else
                {
                    
                    lblNew.Text = "For Existing Project";
                    
                    lblProjtype.Text = "For Existing Project";
                    HideColumn(false);

                }

            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            // lbl.Text = ex.Message;
            //Failure.Visible = true;
        }
    }
    public void HideColumn(bool hide)
    {
        if (hide == true) ////to make visible false
        {
            tdExp.Visible = false;
            tdPlant.Visible = false;
            tdBuilding.Visible = false;
            tdLand.Visible = false;
            tdTurnover.Visible = false;
            tdMaleEmp.Visible = false;
            tdFemaleEmp.Visible = false;
            tdTotalEmp.Visible = false;
            lblExpn.Visible = false;
            lblLandCostE.Visible = false;
            lblBuildE.Visible = false;
            lblPlantE.Visible = false;
            lblAnnualE.Visible = false;
        }
        else
        {
            tdExp.Visible = true;
            tdPlant.Visible = true;
            tdBuilding.Visible = true;
            tdLand.Visible = true;
            tdTurnover.Visible = true;
            tdMaleEmp.Visible = true;
            tdFemaleEmp.Visible = true;
            tdTotalEmp.Visible = true;
        }
    }

    protected void rblTsipass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblTsipass.SelectedValue == "Y")
            {
                Login.Visible = true;
            }
            else { Login.Visible = false; }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rblExpansion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rblExpansion.SelectedValue == "New")
            {
                lblProjtype.Text = "For New Project";
                HideColumn(true);
            }
            else
            {
                lblNew.Text = "For Existing Project";

                lblProjtype.Text = "For Existing Project";
                HideColumn(false);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ErrorMsg = Validations();
            if (ErrorMsg == "")
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;

                com.CommandText = "USP_INSERTCFEUserVerifedData";

                com.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Convert.ToInt32(lblCFEEnterpid.Text.Trim());
                com.Parameters.Add("@UIDNo", SqlDbType.VarChar).Value = lblUidNo.Text.Trim();
                com.Parameters.Add("@PANno", SqlDbType.VarChar).Value = txtPan.Text.Trim();
                com.Parameters.Add("@GSTno", SqlDbType.VarChar).Value = txtgst.Text.Trim();
                com.Parameters.Add("@SectorType", SqlDbType.VarChar).Value = rblSector.SelectedItem.Text.Trim();
                com.Parameters.Add("@NEWorExpansion", SqlDbType.VarChar).Value = rblExpansion.SelectedItem.Text.Trim();

                com.Parameters.Add("@New_PMCost", SqlDbType.VarChar).Value = txtNewPlantMachnryCost.Text.Trim();
                com.Parameters.Add("@New_BuildingCost", SqlDbType.VarChar).Value = txtNewBuildingCost.Text.Trim();
                com.Parameters.Add("@New_LandCost", SqlDbType.VarChar).Value = txtNewLandCost.Text.Trim();
                com.Parameters.Add("@New_AnnualTurnOver", SqlDbType.VarChar).Value = txtNewTurnover.Text.Trim();
                com.Parameters.Add("@New_MaleEmp", SqlDbType.VarChar).Value = txtNewMale.Text.Trim();
                com.Parameters.Add("@New_FemaleEmp", SqlDbType.VarChar).Value = txtNewFemale.Text.Trim();
                com.Parameters.Add("@New_TotalEmp", SqlDbType.VarChar).Value = txtNewTotal.Text.Trim();

                if (txtExpPlantMachnryCost.Text.Trim() == "" || txtExpPlantMachnryCost.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_PMCost", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_PMCost", SqlDbType.VarChar).Value = txtExpPlantMachnryCost.Text.Trim();

                if (txtExpBuildingCost.Text.Trim() == "" || txtExpBuildingCost.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_BuildingCost", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_BuildingCost", SqlDbType.VarChar).Value = txtExpBuildingCost.Text.Trim();

                if (txtExpLandCost.Text.Trim() == "" || txtExpLandCost.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_LandCost", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_LandCost", SqlDbType.VarChar).Value = txtExpLandCost.Text.Trim();

                if (txtExpTurnover.Text.Trim() == "" || txtExpTurnover.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_AnnualTurnOver", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_AnnualTurnOver", SqlDbType.VarChar).Value = txtExpTurnover.Text.Trim();

                if (txtExpMale.Text.Trim() == "" || txtExpMale.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_MaleEmp", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_MaleEmp", SqlDbType.VarChar).Value = txtExpMale.Text.Trim();

                if (txtExpFemale.Text.Trim() == "" || txtExpFemale.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_FemaleEmp", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_FemaleEmp", SqlDbType.VarChar).Value = txtExpFemale.Text.Trim();

                if (txtExpTotal.Text.Trim() == "" || txtExpTotal.Text.Trim() == null)
                    com.Parameters.Add("@Expnsn_TotalEmp", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@Expnsn_TotalEmp", SqlDbType.VarChar).Value = txtExpTotal.Text.Trim();

                com.Parameters.Add("@HadOtherLogins", SqlDbType.VarChar).Value = rblTsipass.SelectedItem.Text.Trim();
                com.Parameters.Add("@LOAID", SqlDbType.VarChar).Value = ddlLOA.SelectedValue.Trim();
                if (txtTSiPasslogins.Text.Trim() == "" || txtTSiPasslogins.Text.Trim() == null)
                    com.Parameters.Add("@LoginUsernames", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    com.Parameters.Add("@LoginUsernames", SqlDbType.VarChar).Value = txtTSiPasslogins.Text.Trim();
                com.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value =Convert.ToString( Session["uid"]).Trim();

                com.Parameters.Add("@Result", SqlDbType.Int, 500);
                com.Parameters["@Result"].Direction = ParameterDirection.Output;
                con.OpenConnection();
                com.Connection = con.GetConnection;
                com.ExecuteNonQuery();
                int valid = (Int32)com.Parameters["@Result"].Value;

                com.Connection = con.GetConnection;

                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    con.CloseConnection();
                    throw ex;
                }
                finally
                {
                    com.Dispose();
                    con.CloseConnection();
                }


            }
            else
            {
                string message = "alert('" + ErrorMsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string Validations()
    {
        try
        {
            int slno = 1;
            string errormsg = "";
            if (string.IsNullOrEmpty(txtPan.Text) || txtPan.Text == "" || txtPan.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter PAN NO..! \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrEmpty(txtgst.Text) || txtgst.Text == "" || txtgst.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter GST NO...! \\n";
                slno = slno + 1;
            }
            if (rblSector.SelectedIndex == -1)
            {
                errormsg = errormsg + slno + ". Please Enter Type of Sector \\n";
                slno = slno + 1;
            }
            if (rblExpansion.SelectedIndex == -1)
            {
                errormsg = errormsg + slno + ". Please Enter New & Expansion \\n";
                slno = slno + 1;
            }
            else if (rblExpansion.SelectedValue == "Expansion")
            {
                if (string.IsNullOrEmpty(txtNewPlantMachnryCost.Text) || txtNewPlantMachnryCost.Text == "" || txtNewPlantMachnryCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Plant & Machinery Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewBuildingCost.Text) || txtNewBuildingCost.Text == "" || txtNewBuildingCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Building Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewLandCost.Text) || txtNewLandCost.Text == "" || txtNewLandCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Existing Enter Land Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewTurnover.Text) || txtNewTurnover.Text == "" || txtNewTurnover.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Annual TurnOver...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewMale.Text) || txtNewMale.Text == "" || txtNewMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Existing Enter Male Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewFemale.Text) || txtNewFemale.Text == "" || txtNewFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Existing Enter Female Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewTotal.Text) || txtNewTotal.Text == "" || txtNewTotal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Total Employee...! \\n";
                    slno = slno + 1;
                }


                if (string.IsNullOrEmpty(txtExpPlantMachnryCost.Text) || txtExpPlantMachnryCost.Text == "" || txtExpPlantMachnryCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Expnasion Plant & Machinery Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpBuildingCost.Text) || txtExpBuildingCost.Text == "" || txtExpBuildingCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Building Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpLandCost.Text) || txtExpLandCost.Text == "" || txtExpLandCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Land Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpTurnover.Text) || txtExpTurnover.Text == "" || txtExpTurnover.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing TurnOver...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpMale.Text) || txtExpMale.Text == "" || txtExpMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Male Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpFemale.Text) || txtExpFemale.Text == "" || txtExpFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Female Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtExpTotal.Text) || txtExpTotal.Text == "" || txtExpTotal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Existing Total Employee...! \\n";
                    slno = slno + 1;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtNewPlantMachnryCost.Text) || txtNewPlantMachnryCost.Text == "" || txtNewPlantMachnryCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Plant & Machinery Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewBuildingCost.Text) || txtNewBuildingCost.Text == "" || txtNewBuildingCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Building Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewLandCost.Text) || txtNewLandCost.Text == "" || txtNewLandCost.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Land Cost...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewTurnover.Text) || txtNewTurnover.Text == "" || txtNewTurnover.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TurnOver...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewMale.Text) || txtNewMale.Text == "" || txtNewMale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Male Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewFemale.Text) || txtNewFemale.Text == "" || txtNewFemale.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Female Employee...! \\n";
                    slno = slno + 1;
                }
                if (string.IsNullOrEmpty(txtNewTotal.Text) || txtNewTotal.Text == "" || txtNewTotal.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter Total Employee...! \\n";
                    slno = slno + 1;
                }
            }

            if (rblTsipass.SelectedIndex == -1)
            {
                errormsg = errormsg + slno + ". Please Enter Already TSiPASS Login...! \\n";
                slno = slno + 1;
            }
            else if (rblTsipass.SelectedValue == "Y")
            {
                if (string.IsNullOrEmpty(txtTSiPasslogins.Text) || txtTSiPasslogins.Text == "" || txtTSiPasslogins.Text == null)
                {
                    errormsg = errormsg + slno + ". Please Enter TSiPASS Login Usernames...! \\n";
                    slno = slno + 1;
                }
            }
            return errormsg;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}