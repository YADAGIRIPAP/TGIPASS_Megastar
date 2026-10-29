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
    int hp;
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }

        if (!IsPostBack)
        {


            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                if (TourismFlag == "Y")
                {
                    lblProductionMonth.Text = "Expected Month and Year of Operations (DD/MM/YYYY)";
                }
                else
                {
                    lblProductionMonth.Text = "Expected Month and Year of Trial Production(DD/MM/YYYY)";
                }
            }
            else
            {
                Session["Applid"] = "0";
            }
            DataSet dspower125 = new DataSet();
            dspower125 = GetLineofActivity_125HP(Convert.ToInt32(Session["Applid"]));

            if (dspower125.Tables[0].Rows.Count > 0)
            {
                hdnlineofactivity.Value = dspower125.Tables[0].Rows[0]["intLineofActivity"].ToString();
            }
            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque4(Session["Applid"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatus(Session["Applid"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);

                    if (txtConnectedLoadHP.Text.Trim().TrimEnd() == "")
                    {
                        txtConnectedLoadHP.ReadOnly = true;
                    }
                    if (txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text.Trim().TrimEnd() == "")
                    {
                        txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.ReadOnly = false;
                    }
                    if (txtContractedMaximumDemandinKVA0.Text.Trim().TrimEnd() == "")
                    {
                        txtContractedMaximumDemandinKVA0.ReadOnly = false;
                    }

                    if (ddlRequiredVoltageLevel.SelectedValue == "--Select--")
                    {
                        ddlRequiredVoltageLevel.Enabled = true;
                    }
                    if (ddlAnyOtherServicesExistingintheSamePremises.SelectedValue == "--Select--")
                    {
                        ddlAnyOtherServicesExistingintheSamePremises.Enabled = true;
                    }
                    if (txtPerDay.Text.Trim().TrimEnd() == "")
                    {
                        txtPerDay.ReadOnly = false;
                    }
                    if (txtPerMonth.Text.Trim().TrimEnd() == "")
                    {
                        txtPerMonth.ReadOnly = false;
                    }
                    if (txtExpectedMonthandYearofTrialProduction.Text.Trim().TrimEnd() == "")
                    {
                        txtExpectedMonthandYearofTrialProduction.ReadOnly = false;
                    }
                    if (txtProbableDateofRequirementofPowerSupply.Text.Trim().TrimEnd() == "")
                    {
                        txtProbableDateofRequirementofPowerSupply.ReadOnly = false;
                    }
                }

            }


        }

        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
                FillDetails();

            }

        }


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }
    }

    public DataSet GetLineofActivity_125HP(int intquestionnaireid)
    {
        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("SP_GetLineofActivity_125HP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;



            da.SelectCommand.Parameters.Add("@intquestionnaireid", SqlDbType.VarChar).Value = intquestionnaireid;



            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }
    }
    protected void btnOrgLookup_Click(object sender, EventArgs e)
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {

        if (BtnSave1.Text == "Save")
        {
            DataSet ds = new DataSet();

            ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {



                int result = 0;
                result = Gen.InsertPowerDetails(ds.Tables[0].Rows[0]["intCFEPowerid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtContractedMaximumDemandinKVA.Text,
                    txtConnectedLoadKW.Text,
                    txtConnectedLoadHP.Text,
                    txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text, ddlRequiredVoltageLevel.SelectedValue, ddlAnyOtherServicesExistingintheSamePremises.SelectedValue, txtPerDay.Text, txtPerMonth.Text, txtExpectedMonthandYearofTrialProduction.Text, txtProbableDateofRequirementofPowerSupply.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), txtContractedMaximumDemandinKVA0.Text);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                    //  this.Clear();
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    lblmsg.Text = "<font color='green'>Power Details Updated Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Power Details Saved Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }

            }
            else
            {


                int result = 0;
                result = Gen.InsertPowerDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtContractedMaximumDemandinKVA.Text,
                    txtConnectedLoadKW.Text,
                    txtConnectedLoadHP.Text,
                    txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text, ddlRequiredVoltageLevel.SelectedValue, ddlAnyOtherServicesExistingintheSamePremises.SelectedValue, txtPerDay.Text, txtPerMonth.Text, txtExpectedMonthandYearofTrialProduction.Text, txtProbableDateofRequirementofPowerSupply.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), txtContractedMaximumDemandinKVA0.Text);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Power Details Saved Successfully..!</font>";
                    success.Visible = true;
                    Failure.Visible = false;
                    //this.Clear();
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Power Details Saved Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }

            }
        }
    }
    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {
        //        CREATE TABLE [dbo].[td_CFEPowerDet](
        //    [intCFEPowerid] [int] IDENTITY(1000,1) NOT NULL,
        //    [intQuessionaireid] [int] NULL,
        //    [intCFEEnterpid] [int] NULL,
        //    [Uid_No] [varchar](30) NULL,
        //    [Reg_Id] [int] NULL,
        //    [Cont_Demand_Max] [decimal](18, 0) NULL,
        //    [Connect_Load_A] [decimal](18, 0) NULL,
        //    [Connect_Load_B] [decimal](18, 0) NULL,
        //    [Aggrigate_Capcity] [decimal](18, 0) NULL,
        //    [Req_Voltage] [int] NULL,
        //    [Anyother_Service] [char](1) NULL,
        //    [Power_PerDay] [decimal](18, 0) NULL,
        //    [Power_PerMonth] [decimal](18, 0) NULL,
        //    [Trail_Production] [datetime] NULL,
        //    [Portable_Date] [datetime] NULL,
        //    [Created_by] [int] NULL,
        //    [Created_dt] [datetime] NULL,
        //    [Modified_by] [int] NULL,
        //    [Modified_dt] [datetime] NULL,
        // CONSTRAINT [PK_td_CFEPowerDet] PRIMARY KEY CLUSTERED 
        //(
        //    [intCFEPowerid] ASC
        //)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
        //) ON [PRIMARY]


    }
    void FillDetails()
    {

        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            ds = Gen.getdataofPowerDetails(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFEPowerid"].ToString();

                txtContractedMaximumDemandinKVA.Text = ds.Tables[0].Rows[0]["Cont_Demand_Max"].ToString();
                txtConnectedLoadKW.Text = ds.Tables[0].Rows[0]["Connect_Load_A"].ToString();

                txtConnectedLoadHP.Text = ds.Tables[0].Rows[0]["Connect_Load_B"].ToString();
               // txtConnectedLoadHP_TextChanged(this, EventArgs.Empty);
                txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text = ds.Tables[0].Rows[0]["Aggrigate_Capcity"].ToString();
                //txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text = ds.Tables[0].Rows[0]["Aggrigate_Capcity"].ToString();

                ddlRequiredVoltageLevel.SelectedValue = ddlRequiredVoltageLevel.Items.FindByValue(ds.Tables[0].Rows[0]["Req_Voltage"].ToString().Trim()).Value;
                //ddlAnyOtherServicesExistingintheSamePremises.SelectedValue = ddlRequiredVoltageLevel.Items.FindByValue(ds.Tables[0].Rows[0]["Anyother_Service"].ToString().Trim()).Value;
                ddlAnyOtherServicesExistingintheSamePremises.SelectedValue = ddlAnyOtherServicesExistingintheSamePremises.Items.FindByValue(ds.Tables[0].Rows[0]["Anyother_Service"].ToString()).Value;

                if (ddlAnyOtherServicesExistingintheSamePremises.SelectedValue.ToString() == "y")
                {
                    meter.Visible = true;
                }
                else
                {
                    meter.Visible = false;

                }


                txtContractedMaximumDemandinKVA0.Text = ds.Tables[0].Rows[0]["MeterNumber"].ToString();
                txtPerDay.Text = ds.Tables[0].Rows[0]["Power_PerDay"].ToString().Trim();

                txtPerMonth.Text = ds.Tables[0].Rows[0]["Power_PerMonth"].ToString().Trim();

                //Response.Write(Convert.ToDateTime(ds.Tables[0].Rows[0]["Trail_Production"]).ToString("MM/dd/yyyy"));
                //return;

                txtExpectedMonthandYearofTrialProduction.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Trail_Production"]).ToString("dd-MM-yyyy");

                txtProbableDateofRequirementofPowerSupply.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Portable_Date"]).ToString("dd-MM-yyyy");



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
        this.Clear();
    }

    public void Clear()
    {
        txtProbableDateofRequirementofPowerSupply.Text = "";
        txtPerMonth.Text = "";
        txtPerDay.Text = "";
        txtExpectedMonthandYearofTrialProduction.Text = "";
        txtContractedMaximumDemandinKVA.Text = "";
        txtConnectedLoadKW.Text = "";
        txtConnectedLoadHP.Text = "";
        txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text = "";
        ddlRequiredVoltageLevel.SelectedIndex = 0;
        ddlAnyOtherServicesExistingintheSamePremises.SelectedIndex = 0;
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



    protected void GetNewRectoInsertdr()
    {

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {

        string number = "";

        if (hdfFlagID0.Value != "")
        {

            number = hdfpencode.Value;
        }

        if (btnNext.Text == "Next")
        {
            DataSet ds = new DataSet();
            //Response.Write(hdfFlagID0.Value.ToString());
            //return;
            ds = Gen.GetdataofPowerenterprenuer(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {



                int result = 0;
                result = Gen.InsertPowerDetails(ds.Tables[0].Rows[0]["intCFEPowerid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtContractedMaximumDemandinKVA.Text,
                    txtConnectedLoadKW.Text,
                    txtConnectedLoadHP.Text,
                    txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text, ddlRequiredVoltageLevel.SelectedValue, ddlAnyOtherServicesExistingintheSamePremises.SelectedValue, txtPerDay.Text, txtPerMonth.Text, txtExpectedMonthandYearofTrialProduction.Text, txtProbableDateofRequirementofPowerSupply.Text, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), txtContractedMaximumDemandinKVA0.Text);
                if (result > 0)
                {
                    Session["ECAF"] = "N";

                    Response.Redirect("frmFireDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Power Details Added Successfully..!</font>";
                    //this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    Response.Redirect("frmFireDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");


                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Power Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
            }
            else
            {
                int result = 0;
                result = Gen.InsertPowerDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtContractedMaximumDemandinKVA.Text,
                    txtConnectedLoadKW.Text,
                    txtConnectedLoadHP.Text,
                    txtAggregateInstalledCapacityoftheTransformertobeInstalledbytheEntreprenuer.Text, ddlRequiredVoltageLevel.SelectedValue, ddlAnyOtherServicesExistingintheSamePremises.SelectedValue.ToString().Trim(), txtPerDay.Text, txtPerMonth.Text, txtExpectedMonthandYearofTrialProduction.Text, txtProbableDateofRequirementofPowerSupply.Text, Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), txtContractedMaximumDemandinKVA0.Text);
                if (result > 0)
                {

                    Response.Redirect("frmFireDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Power Details Added Successfully..!</font>";
                    //this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Power Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }


            }
        }
    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {
        //Response.Redirect("frmForestDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmForestDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");



    }
    protected void ddlAnyOtherServicesExistingintheSamePremises_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlAnyOtherServicesExistingintheSamePremises.SelectedValue.ToString() == "y")
        {
            meter.Visible = true;
        }
        else
        {
            meter.Visible = false;

        }
    }
    protected void txtConnectedLoadHP_TextChanged(object sender, EventArgs e)
    {
        //txtConnectedLoadHP.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
        //ddlRequiredVoltageLevel.Items.Clear();


        #region "commented : towards : HD : TSSPDCL-307"
        //if (txtConnectedLoadHP.Text.Trim() != "" || txtConnectedLoadHP.Text.Trim() != "0")
        //{

        //    txtContractedMaximumDemandinKVA.Text = ((Convert.ToDouble(txtConnectedLoadHP.Text.Trim()) * 0.75) / 0.95).ToString();

        //    if (txtContractedMaximumDemandinKVA.Text.Substring(txtContractedMaximumDemandinKVA.Text.IndexOf('.') + 1).Length > 2 && txtContractedMaximumDemandinKVA.Text.Contains('.'))
        //    {
        //        txtContractedMaximumDemandinKVA.Text = txtContractedMaximumDemandinKVA.Text.Substring(0, txtContractedMaximumDemandinKVA.Text.IndexOf('.')) + txtContractedMaximumDemandinKVA.Text.Substring(txtContractedMaximumDemandinKVA.Text.IndexOf('.'), 3);
        //    }

        //    ddlRequiredVoltageLevel.Items.Clear();
        //    if (Convert.ToDouble(txtConnectedLoadHP.Text) < 100)
        //    {
        //        ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("LT", "100"));
        //    }
        //    else if (Convert.ToDouble(txtConnectedLoadHP.Text) >= 100)
        //    {
        //        //ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("11 KV", "11"));
        //        ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("33 KV", "33"));
        //        //  ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("133 KV", "133"));
        //        ddlRequiredVoltageLevel.SelectedValue = "11";

        //    }
        //}
        #endregion

        int val;
        if (!int.TryParse(txtConnectedLoadHP.Text, out val) || val <= 0)
        {
            txtConnectedLoadHP.Text = "";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Enter a value greater than 0');", true);
        }
        else
        {

       
        if (txtConnectedLoadHP.Text != "" || txtConnectedLoadHP.Text != null)
        {
            lblChcekHP.Visible = false;
            try
            {
                DataSet dshp = new DataSet();

                dshp = GetDataPowerReqHP(Session["uid"].ToString().Trim());
                if (dshp.Tables[0].Rows.Count > 0 && dshp.Tables[0].Rows != null && (dshp.Tables[0].Rows).ToString() != "" && txtConnectedLoadHP.Text != "")
                {

                    hp = Convert.ToInt32(dshp.Tables[0].Rows[0]["Power_Req"].ToString().Trim());

                    if (hp == 1)
                    {
                        if (Convert.ToInt32(txtConnectedLoadHP.Text) > 30)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp less than or equal to 30')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }

                    if (hp == 2)
                    {
                        if (Convert.ToInt32(txtConnectedLoadHP.Text) <= 30 || Convert.ToInt32(txtConnectedLoadHP.Text) > 100)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp between 30 and 100')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }

                    if (hp == 3)
                    {
                        //if (hdnlineofactivity.Value == "1142" || hdnlineofactivity.Value == "1230")
                        //{
                        //    if (Convert.ToInt32(txtConnectedLoadHP.Text) < 101 || Convert.ToInt32(txtConnectedLoadHP.Text) > 125)
                        //    {
                        //        txtConnectedLoadHP.Text = "";
                        //        string message = "alert('please enter hp less than 125')";
                        //        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //        return;
                        //    }

                        //}
                         if (Convert.ToInt32(txtConnectedLoadHP.Text) < 101 || Convert.ToInt32(txtConnectedLoadHP.Text) > 500)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp between 101 and 500')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }

                    if (hp == 4)
                    {
                        if (Convert.ToInt32(txtConnectedLoadHP.Text) < 501 || Convert.ToInt32(txtConnectedLoadHP.Text) > 1500)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp between 501 and 1500')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }

                    if (hp == 5)
                    {
                        if (Convert.ToInt32(txtConnectedLoadHP.Text) < 1501 || Convert.ToInt32(txtConnectedLoadHP.Text) > 10000)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp between 1501 and 10000')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }
                    if (hp == 6)
                    {
                        if (Convert.ToInt32(txtConnectedLoadHP.Text) <= 10000)
                        {
                            txtConnectedLoadHP.Text = "";
                            string message = "alert('please enter hp more than 10000')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            return;
                        }

                    }

                }
                else
                {
                    string message = "alert('please enter the HP')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }


                int temp = Convert.ToInt32(txtConnectedLoadHP.Text);
                if (txtConnectedLoadHP.Text.Trim() != "" || txtConnectedLoadHP.Text.Trim() != "0")
                {
                    txtContractedMaximumDemandinKVA.Text = ((Convert.ToDouble(txtConnectedLoadHP.Text.Trim()) * 0.75) / 0.95).ToString();

                    if (txtContractedMaximumDemandinKVA.Text.Substring(txtContractedMaximumDemandinKVA.Text.IndexOf('.') + 1).Length > 2 && txtContractedMaximumDemandinKVA.Text.Contains('.'))
                    {
                        txtContractedMaximumDemandinKVA.Text = txtContractedMaximumDemandinKVA.Text.Substring(0, txtContractedMaximumDemandinKVA.Text.IndexOf('.')) + txtContractedMaximumDemandinKVA.Text.Substring(txtContractedMaximumDemandinKVA.Text.IndexOf('.'), 3);
                    }

                    ddlRequiredVoltageLevel.Items.Clear();
                    if (Convert.ToDouble(txtConnectedLoadHP.Text) < 100)
                    {
                        ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("LT", "100"));
                    }
                    else if (Convert.ToDouble(txtConnectedLoadHP.Text) >= 100)
                    {
                        if ((hdnlineofactivity.Value == "1142" || hdnlineofactivity.Value == "1230") && Convert.ToDouble(txtConnectedLoadHP.Text) >= 100 && Convert.ToDouble(txtConnectedLoadHP.Text) < 125)
                        {
                            
                            ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("LT", "100"));
                            ddlRequiredVoltageLevel.SelectedValue = "100";
                        }
                        else
                        {

                            //ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("11 KV", "11"));
                            ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("33 KV", "33"));
                            //  ddlRequiredVoltageLevel.Items.Insert(0, new ListItem("133 KV", "133"));
                            ddlRequiredVoltageLevel.SelectedValue = "11";
                        }
                    }
                }
            }
            catch (Exception h)
            {
                lblChcekHP.Visible = true;
                lblChcekHP.Text = "Please enter only numeric values";
                txtConnectedLoadHP.Text = "";
                txtConnectedLoadKW.Text = "";
                ddlRequiredVoltageLevel.Items.Clear();
                txtConnectedLoadHP.Focus();
            }



        }
        }
    }

    public DataSet GetDataPowerReqHP(string Createdby) //powerReqHP
    {

        con.OpenConnection();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetPowerReqHP", con.GetConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (Createdby.Trim() == "" || Createdby.Trim() == null)
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@createdby", SqlDbType.VarChar).Value = Createdby.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.CloseConnection();
        }

    }
}
