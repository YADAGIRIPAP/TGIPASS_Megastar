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
            Response.Redirect("~/Index.aspx");
        }
        try
        {
            if (!IsPostBack)
            {
                gvmodelsnames.DataSource = BindModelsData(Convert.ToInt32(3));
                gvmodelsnames.DataBind();
                DataTable dt = new DataTable();
                dt = BindBasicMethod();
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    Label txtMakerGvV = (Label)gvrTEMPVehMstr.FindControl("lblModelname");
                    txtMakerGvV.Text = dt.Rows[gvrTEMPVehMstr.RowIndex]["Name"].ToString();
                }

                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
                if (dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                    string TourismFlag = dscheck.Tables[0].Rows[0]["TourismFlag"].ToString().Trim();
                    if (TourismFlag == "Y")
                    {
                        lblWaterforProcessing.Text = "Water for Processing(Unit use) ( in KL/Day )"; //lavanya
                    }
                    else
                    {
                        lblWaterforProcessing.Text = "Water for Processing(Industrial use) ( in KL/Day )"; //lavanya
                    }
                }
                else
                {
                    Session["Applid"] = "0";
                }
                if (dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString() != "" && dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString() == "HMWS & SB")
                {
                    trarea.Visible = true;
                    ViewState["hmwssb"] = dscheck.Tables[0].Rows[0]["Water_reg_from2"].ToString();
                    try
                    {
                        ddlarea.Items.Clear();
                        DataSet dsc = new DataSet();
                        dsc = Gen.GetWaterArea(dscheck.Tables[0].Rows[0]["Prop_intDistrictid"].ToString().Trim());
                        if (dsc != null && dsc.Tables.Count > 0 && dsc.Tables[0].Rows.Count > 0)
                        {
                            ddlarea.DataSource = dsc.Tables[0];
                            ddlarea.DataValueField = "AreaCode";
                            ddlarea.DataTextField = "Area_Description";
                            ddlarea.DataBind();
                            ddlarea.Items.Insert(0, "--Select--");
                        }
                        else
                        {
                            ddlarea.Items.Insert(0, "--Select--");
                        }
                    }
                    catch (Exception ex)
                    {
                        lblmsg0.Text = ex.Message;
                        Failure.Visible = true;
                        success.Visible = false;
                    }

                }
                else
                {
                    trarea.Visible = false;
                }
                if (dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString() != "" && dscheck.Tables[0].Rows[0]["Water_reg_from3"].ToString() == "Rivers/Canals")
                {
                    trIrrigation.Visible = true;
                }


            }


            if (!IsPostBack)
            {

                DataSet dsnew = new DataSet();

                DataTable dt = new DataTable();
                dsnew = Gen.getdataofidentity(Session["Applid"].ToString(), "20");

                if (dsnew != null && dsnew.Tables[0].Rows.Count > 0)
                    dt = dsnew.Tables[0];

                DataSet dsnew15 = new DataSet();
                dsnew15 = Gen.getdataofidentity(Session["Applid"].ToString(), "15");

                if (dsnew15 != null && dsnew15.Tables[0].Rows.Count > 0)
                    dt = dsnew15.Tables[0];
                DataSet dsnew16 = new DataSet();
                dsnew16 = Gen.getdataofidentity(Session["Applid"].ToString(), "16");

                //DataSet dsnew17 = new DataSet();
                //dsnew17 = Gen.getdataofidentity(Session["Applid"].ToString(), "71");


                if ((dsnew16 != null && dsnew16.Tables[0].Rows.Count > 0) || dt != null)
                {
                    //dt.Merge(dsnew16.Tables[0]);
                }
                //else
                //{
                //    dt = dsnew1.Tables[0];
                //}


                //if (dt!=null && dt.Rows.Count > 0)
                //{ 

                //}
                if (dsnew.Tables[0].Rows.Count > 0 || dsnew15.Tables[0].Rows.Count > 0 || dsnew16.Tables[0].Rows.Count > 0)
                {

                }

                else
                {


                    if (Request.QueryString[1].ToString() == "N")
                    {


                        Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                    }

                    else
                    {

                        Response.Redirect("frmFireDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                    }



                }

            }

            if (!IsPostBack)
            {

                if (Session["Applid"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
                {
                    Response.Redirect("frmQuesstionniareReg.aspx");
                }


                if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
                {

                    DataSet dsch = new DataSet();
                    dsch = Gen.GetEnterPreneurdatabyQuewaterReq(Session["Applid"].ToString());

                    if (dsch.Tables[0].Rows.Count > 0)
                    {
                        if (dsch.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim() != "")
                        {

                            txtRequirement_Water.Text = dsch.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();


                            //ddlintLineofActivity.SelectedValue = ddlintLineofActivity.Items.FindByValue(dsch.Tables[0].Rows[0]["intLineofActivity"].ToString().Trim()).Value;

                            //                        ddlintLineofActivity.Enabled = false;
                        }
                        foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                        {
                            TextBox txtwaterrequirednew = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            txtwaterrequirednew.ReadOnly = false;
                            if (dsch.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 0)
                            {
                                CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                                txtMakerGvV.Checked = true;
                                txtwaterrequired.Text = dsch.Tables[0].Rows[0]["Water_req_Perday_Borewell"].ToString().Trim();
                                if (txtwaterrequired.Text.Trim().TrimStart() == "")
                                {
                                    txtwaterrequired.Text = dsch.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
                                }
                                txtwaterrequired.ReadOnly = false;
                            }
                            if (dsch.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 1)
                            {
                                CheckBox txtMakerGvV1 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                                txtMakerGvV1.Checked = true;
                                txtwaterrequired.Text = dsch.Tables[0].Rows[0]["Water_req_Perday_HMWS"].ToString().Trim();
                                txtwaterrequired.ReadOnly = false;
                            }
                            if (dsch.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 2)
                            {
                                CheckBox txtMakerGvV2 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                                TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                                txtMakerGvV2.Checked = true;
                                txtwaterrequired.Text = dsch.Tables[0].Rows[0]["Water_req_Perday_RiversCanals"].ToString().Trim();
                                txtwaterrequired.ReadOnly = false;
                            }
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
            if (ddlarea.SelectedValue == "0" || ddlarea.SelectedItem.Text == "--Select--")
            {
                ddlarea.Enabled = true;
            }

            if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
            {

            }

            if (!IsPostBack)
            {
                DataSet dsver = new DataSet();

                dsver = Gen.Getverifyofque6(Session["Applid"].ToString());

                if (dsver.Tables[0].Rows.Count > 0)
                {
                    string res = Gen.RetriveStatus(Session["Applid"].ToString());
                    ////string res = Gen.RetriveStatus("1002");


                    if (res == "3" || Convert.ToInt32(res) >= 3)
                    {
                        ResetFormControl(this);
                        int a = 0, b = 0;
                        foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                        {
                            TextBox txtwaterrequirednew = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            if (txtMakerGvV.Checked)
                            {
                                a = a + 1;
                            }
                            if (txtwaterrequirednew.Text.Trim() != "")
                            {
                                b = b + 1;
                            }
                        }
                        foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                        {
                            TextBox txtwaterrequirednew = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                            CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                            if (a != 0)
                            {
                                txtMakerGvV.Enabled = false;
                            }
                            else
                            {
                                txtMakerGvV.Enabled = true;
                                // txtwaterrequirednew.ReadOnly = false;
                            }
                            if (b != 0)
                            {
                                txtwaterrequirednew.Enabled = false;
                            }
                            else
                            {
                                txtwaterrequirednew.Enabled = true;
                                txtwaterrequirednew.ReadOnly = false;
                            }
                        }
                        if (ddlarea.SelectedValue == "0" || ddlarea.SelectedItem.Text == "--Select--")
                        {
                            ddlarea.Enabled = true;
                        }

                    }

                }
            }
            if (txtDrink_Water.Text == "")
            {
                txtDrink_Water.Enabled = true;
            }
            if (txtWater_Processing.Text == "")
            {
                txtWater_Processing.Enabled = true;
            }
            if (txtRequirement_Water.Text == "")
            {
                txtRequirement_Water.Enabled = true;
            }
            if (txtQuant_Water_Consumptive.Text == "")
            {
                txtQuant_Water_Consumptive.Enabled = true;
            }
            if (txtQuant_Water_NonConsumptive.Text == "")
            {
                txtQuant_Water_NonConsumptive.Enabled = true;
            }


        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }

    }

    public DataTable BindModelsData(int iRowIndexx)
    {
        DataTable dtReff = new DataTable();
        DataRow drReff;
        try
        {
            gvmodelsnames.DataSource = null;
            gvmodelsnames.DataBind();


            DataColumn dc = new DataColumn();
            dtReff.Columns.Add("Water required from");
            dtReff.Columns.Add("Water Required per day( in KLD)");
            drReff = dtReff.NewRow();
            if (drReff.ItemArray[0] == null)
            {
                drReff.ItemArray[0] = "";
            }
            dtReff.Rows.Add(drReff);

            for (int i = 0; i < iRowIndexx - 1; i++)
            {
                drReff = dtReff.NewRow();
                dtReff.Rows.Add(drReff);
            }

        }
        catch (Exception ex)
        {
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
            success.Visible = false;
        }
        return dtReff;
    }
    public DataTable BindBasicMethod()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));

        DataRow dr = dt.NewRow();
        dr["Name"] = "New Bore well";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "HMWS & SB";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Name"] = "Rivers/Canals";
        dt.Rows.Add(dr);
        return dt;
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
                        if (((TextBox)c).Text == "" || ((TextBox)c).Text == null || string.IsNullOrEmpty(((TextBox)c).Text))
                        {
                            ((TextBox)c).ReadOnly = false;
                        }
                        else
                        {
                            ((TextBox)c).ReadOnly = true;
                        }

                        //((TextBox)c).ReadOnly = true;
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
    protected void btnOrgLookup_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //if (ViewState["hmwssb"].ToString() != "" && ViewState["hmwssb"].ToString() != "" && ViewState["hmwssb"].ToString() == "HMWS & SB")
        //{
        //    if (ddlarea.SelectedValue == "" || ddlarea.SelectedValue == null || ddlarea.SelectedValue == "--Select--")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Area Name.');", true);
        //    }

        //}
        //else
        //{
        try
        {
            if (BtnSave1.Text == "Save")
            {
                string errormsg = "";
                errormsg = Validations();
                if (errormsg == "")
                {
                    int chk = 0;
                    chk = CheckBoxList1.Items.Count;
                    string lan = "";
                    string value = "";
                    for (int prjcnt = 0; prjcnt < chk; prjcnt++)
                    {

                        if (CheckBoxList1.Items[prjcnt].Selected)
                        {
                            lan += CheckBoxList1.Items[prjcnt].Value + ",";
                        }



                    }
                    if (lan != null && lan != "")
                        lan = lan.Remove(lan.Length - 1);

                    DataSet ds = new DataSet();

                    ds = Gen.GetdataofWaterenterprenuer(hdfFlagID0.Value.ToString());
                    string chkwatera = "", chkwaterb = "", chkwaterc = "";
                    decimal chkwaterreqa = 0, chkwaterreqb = 0, chkwaterreqc = 0;

                    foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                    {
                        CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        Label lblModelname = (Label)gvrTEMPVehMstr.FindControl("lblModelname");

                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                        {
                            chkwatera = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqa = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                        {
                            chkwaterb = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqb = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                        {
                            chkwaterc = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqc = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                    }

                    QuesionerVO quesionervoobj = new QuesionerVO();
                    quesionervoobj.Water_req_Perday = (chkwaterreqa + chkwaterreqb + chkwaterreqc).ToString();
                    quesionervoobj.Water_req_Perday1 = chkwaterreqa.ToString();
                    quesionervoobj.Water_req_Perday2 = chkwaterreqb.ToString();
                    quesionervoobj.Water_req_Perday3 = chkwaterreqc.ToString();
                    quesionervoobj.Water_reg_from1 = chkwatera;
                    quesionervoobj.Water_reg_from2 = chkwaterb;
                    quesionervoobj.Water_reg_from3 = chkwaterc;

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int result = 0;
                        result = Gen.InsertWaterDetails(ds.Tables[0].Rows[0]["intCFEWaterid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", "0", txtDrink_Water.Text, txtWater_Processing.Text, lan.ToString(), quesionervoobj.Water_req_Perday, txtQuant_Water_Consumptive.Text, txtQuant_Water_NonConsumptive.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ddlarea.SelectedValue, quesionervoobj, txtIntakeCordinates.Text, txtStorageCordinates.Text, txtMinWaterReq.Text, txtMaxWaterReq.Text);
                        if (result > 0)
                        {
                            //ResetFormControl(this);

                            lblmsg.Text = "<font color='green'>Water Details Saved Successfully..!</font>";
                            // this.Clear();
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else if (result == 0)
                        {
                            lblmsg.Text = "<font color='green'>Water Details Updated Successfully..!</font>";
                            // this.Clear();
                            success.Visible = true;
                            Failure.Visible = false;

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Water Details Saved Fail..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }
                    }
                    else
                    {
                        int result = 0;
                        result = Gen.InsertWaterDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", "0", txtDrink_Water.Text, txtWater_Processing.Text, lan.ToString(), quesionervoobj.Water_req_Perday, txtQuant_Water_Consumptive.Text, txtQuant_Water_NonConsumptive.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ddlarea.SelectedValue, quesionervoobj, txtIntakeCordinates.Text, txtStorageCordinates.Text, txtMinWaterReq.Text, txtMaxWaterReq.Text);
                        if (result > 0)
                        {
                            //ResetFormControl(this);

                            lblmsg.Text = "<font color='green'>Water Details Saved Successfully..!</font>";
                            // this.Clear();
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Water Details Saved Fail..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }

                    }

                }
                else
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    // }

    public string Validations()
    {
        string errormsg = ""; int slno = 1;
        if (string.IsNullOrEmpty(txtDrink_Water.Text) || txtDrink_Water.Text == "" || txtDrink_Water.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Drinking Water required ( in KL/Day ) \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtWater_Processing.Text) || txtWater_Processing.Text == "" || txtWater_Processing.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Water for Processing(Industrial use) ( in KL/Day ) \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtQuant_Water_Consumptive.Text) || txtQuant_Water_Consumptive.Text == "" || txtQuant_Water_Consumptive.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Quantity of Water Required for Consumptive Use (in KL/Day) \\n";
            slno = slno + 1;
        }
        if (string.IsNullOrEmpty(txtQuant_Water_NonConsumptive.Text) || txtQuant_Water_NonConsumptive.Text == "" || txtQuant_Water_NonConsumptive.Text == null)
        {
            errormsg = errormsg + slno + ". Please Enter Quantity of Water Required for Non-Consumptive Use (in KL/Day) \\n";
            slno = slno + 1;
        }
        if (trarea.Visible == true)
        {
            if (ddlarea.SelectedValue == "0" || ddlarea.SelectedValue == "--Select--")
            {
                errormsg = errormsg + slno + ". Please Select Area Name \\n";
                slno = slno + 1;
            }
        }
        if (trIrrigation.Visible == true)
        {
            if (string.IsNullOrEmpty(txtIntakeCordinates.Text) || txtIntakeCordinates.Text == "" || txtIntakeCordinates.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter Geo Coordinates of Proposed Intake Point \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrEmpty(txtStorageCordinates.Text) || txtStorageCordinates.Text == "" || txtStorageCordinates.Text == null)
            {
                errormsg = errormsg + slno + ". Please EnterGeo Coordinates of Proposed Storage Point/ Utilisation point \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrEmpty(txtMinWaterReq.Text) || txtMinWaterReq.Text == "" || txtMinWaterReq.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter minimum Water requirements ( mcft) per annum \\n";
                slno = slno + 1;
            }
            if (string.IsNullOrEmpty(txtMaxWaterReq.Text) || txtMaxWaterReq.Text == "" || txtMaxWaterReq.Text == null)
            {
                errormsg = errormsg + slno + ". Please Enter Maximum Water requirement ( mcft) per annum \\n";
                slno = slno + 1;
            }
        }
        return errormsg;
    }


    void clear()
    {




    }


    protected void BtnClear0_Click(object sender, EventArgs e)
    {



    }
    void FillDetails()
    {


        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {
            ds = Gen.getdataofwaterDetails(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (ds.Tables[0].Rows[0]["Water_Suply_From"].ToString().Trim() != "")
                //{
                //    ddlWater_Suply_From.SelectedValue = ddlWater_Suply_From.Items.FindByValue(ds.Tables[0].Rows[0]["Water_Suply_From"].ToString().Trim()).Value;
                //}
                foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                {
                    if (ds.Tables[0].Rows[0]["Water_reg_from1"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 0)
                    {
                        CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        txtMakerGvV.Checked = true;
                        txtwaterrequired.Text = ds.Tables[0].Rows[0]["Water_req_Perday_Borewell"].ToString().Trim();
                        if (txtwaterrequired.Text.Trim().TrimStart() == "")
                        {
                            txtwaterrequired.Text = ds.Tables[0].Rows[0]["Water_req_Perday"].ToString().Trim();
                            txtwaterrequired.ReadOnly = false;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["Water_reg_from2"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 1)
                    {
                        CheckBox txtMakerGvV1 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        txtMakerGvV1.Checked = true;
                        txtwaterrequired.Text = ds.Tables[0].Rows[0]["Water_req_Perday_HMWS"].ToString().Trim();
                        txtwaterrequired.ReadOnly = false;
                    }
                    if (ds.Tables[0].Rows[0]["Water_reg_from3"].ToString().Trim() != "" && gvrTEMPVehMstr.RowIndex == 2)
                    {
                        CheckBox txtMakerGvV2 = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        txtMakerGvV2.Checked = true;
                        txtwaterrequired.Text = ds.Tables[0].Rows[0]["Water_req_Perday_RiversCanals"].ToString().Trim();
                        txtwaterrequired.ReadOnly = false;
                        trIrrigation.Visible = true;
                    }
                }
                txtDrink_Water.Text = ds.Tables[0].Rows[0]["Drink_Water"].ToString();
                txtWater_Processing.Text = ds.Tables[0].Rows[0]["Water_Processing"].ToString();
                //if (ds.Tables[0].Rows[0]["Source_Water"].ToString().Trim() != "")
                //{
                //    ddlSource_Water.SelectedValue = ddlSource_Water.Items.FindByValue(ds.Tables[0].Rows[0]["Source_Water"].ToString().Trim()).Value;
                //}
                txtRequirement_Water.Text = ds.Tables[0].Rows[0]["Requirement_Water"].ToString();

                txtQuant_Water_Consumptive.Text = ds.Tables[0].Rows[0]["Quant_Water_Consumptive"].ToString();

                txtQuant_Water_NonConsumptive.Text = ds.Tables[0].Rows[0]["Quant_Water_NonConsumptive"].ToString();

                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFEWaterid"].ToString();


                string water = ds.Tables[0].Rows[0]["Source_Water"].ToString();
                string[] k = water.Split(',');


                foreach (ListItem item in CheckBoxList1.Items)
                    item.Selected = k.Contains(item.Value);

                if (ds.Tables[0].Rows[0]["Hmwssb_Areaid"].ToString().Trim() != "")
                {
                    ddlarea.SelectedValue = ddlarea.Items.FindByValue(ds.Tables[0].Rows[0]["Hmwssb_Areaid"].ToString().Trim()).Value;
                }
                else
                {
                    ddlarea.Enabled = true;
                }
                txtIntakeCordinates.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_IntakePointCordnats"]);
                txtStorageCordinates.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_StoragePointCordnats"]);
                txtMinWaterReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_MinWaterReqPerAnnum"]);
                txtMaxWaterReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["Irrg_MaxWaterReqPerAnnum"]);
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
    public void Clear()
    {
        txtDrink_Water.Text = "";
        txtQuant_Water_Consumptive.Text = "";
        txtQuant_Water_NonConsumptive.Text = "";
        txtRequirement_Water.Text = "";
        txtWater_Processing.Text = "";
        txtIntakeCordinates.Text = "";
        txtStorageCordinates.Text = "";
        txtMinWaterReq.Text = "";
        txtMaxWaterReq.Text = "";
        //ddlSource_Water.SelectedIndex = 0;
        //CheckBoxList1.Items.Clear();
        // ddlWater_Suply_From.SelectedIndex = 0;
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {

        //if (ViewState["hmwssb"].ToString() != "" && ViewState["hmwssb"].ToString() != "" && ViewState["hmwssb"].ToString() == "HMWS & SB")
        //{
        //    if (ddlarea.SelectedValue == "" || ddlarea.SelectedValue == null || ddlarea.SelectedValue == "--Select--")
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Area Name.');", true);
        //    }

        //}
        //else
        //{
        try
        {
            string number = "";

            if (hdfFlagID0.Value != "")
            {

                number = hdfpencode.Value;
            }


            if (btnNext.Text == "Next")
            {
                string errormsg = "";
                errormsg = Validations();
                if (errormsg == "")
                {
                    int chk = 0;
                    chk = CheckBoxList1.Items.Count;
                    string lan = "";
                    string value = "";
                    for (int prjcnt = 0; prjcnt < chk; prjcnt++)
                    {

                        if (CheckBoxList1.Items[prjcnt].Selected)
                        {
                            lan += CheckBoxList1.Items[prjcnt].Value + ",";
                        }



                    }
                    if (lan != null && lan != "")
                        lan = lan.Remove(lan.Length - 1);


                    DataSet ds = new DataSet();

                    ds = Gen.GetdataofWaterenterprenuer(hdfFlagID0.Value.ToString());

                    string chkwatera = "", chkwaterb = "", chkwaterc = "";
                    decimal chkwaterreqa = 0, chkwaterreqb = 0, chkwaterreqc = 0;

                    foreach (GridViewRow gvrTEMPVehMstr in gvmodelsnames.Rows)
                    {
                        CheckBox txtMakerGvV = (CheckBox)gvrTEMPVehMstr.FindControl("chkmodelname");
                        TextBox txtwaterrequired = (TextBox)gvrTEMPVehMstr.FindControl("txtwaterrequired");
                        Label lblModelname = (Label)gvrTEMPVehMstr.FindControl("lblModelname");

                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 0)
                        {
                            chkwatera = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqa = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 1)
                        {
                            chkwaterb = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqb = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                        if (txtMakerGvV.Checked == true && gvrTEMPVehMstr.RowIndex == 2)
                        {
                            chkwaterc = lblModelname.Text;
                            if (txtwaterrequired.Text.Trim() != "")
                                chkwaterreqc = Convert.ToDecimal(txtwaterrequired.Text);
                        }
                    }
                    QuesionerVO quesionervoobj = new QuesionerVO();
                    quesionervoobj.Water_req_Perday = (chkwaterreqa + chkwaterreqb + chkwaterreqc).ToString();
                    quesionervoobj.Water_req_Perday1 = chkwaterreqa.ToString();
                    quesionervoobj.Water_req_Perday2 = chkwaterreqb.ToString();
                    quesionervoobj.Water_req_Perday3 = chkwaterreqc.ToString();
                    quesionervoobj.Water_reg_from1 = chkwatera;
                    quesionervoobj.Water_reg_from2 = chkwaterb;
                    quesionervoobj.Water_reg_from3 = chkwaterc;

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        int result = 0;
                        result = Gen.InsertWaterDetails(ds.Tables[0].Rows[0]["intCFEWaterid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", "0", txtDrink_Water.Text, txtWater_Processing.Text, lan.ToString(), quesionervoobj.Water_req_Perday, txtQuant_Water_Consumptive.Text, txtQuant_Water_NonConsumptive.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ddlarea.SelectedValue, quesionervoobj, txtIntakeCordinates.Text, txtStorageCordinates.Text, txtMinWaterReq.Text, txtMaxWaterReq.Text);
                        if (result > 0)
                        {
                            //ResetFormControl(this);
                            Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                            lblmsg.Text = "<font color='green'>Water Details Added Successfully..!</font>";
                            this.Clear();
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else if (result == 0)
                        {
                            Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Water Details Submission Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }
                    }
                    else
                    {

                        int result = 0;
                        result = Gen.InsertWaterDetails("0", Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", "0", txtDrink_Water.Text, txtWater_Processing.Text, lan.ToString(), quesionervoobj.Water_req_Perday, txtQuant_Water_Consumptive.Text, txtQuant_Water_NonConsumptive.Text, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), ddlarea.SelectedValue, quesionervoobj, txtIntakeCordinates.Text, txtStorageCordinates.Text, txtMinWaterReq.Text, txtMaxWaterReq.Text);
                        if (result > 0)
                        {
                            //ResetFormControl(this);

                            Response.Redirect("frmPCBDetails.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                            lblmsg.Text = "<font color='green'>Water Details Added Successfully..!</font>";
                            this.Clear();
                            success.Visible = true;
                            Failure.Visible = false;
                            // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                            //fillNews(userid);
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Water Details Submission Failed..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                        }
                    }
                }
                else
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            //lblmsg0.Text = "Internal error has occured. Please try after some time";
            lblmsg0.Text = ex.Message;
            Failure.Visible = true;
        }
    }
    //}
    protected void btnNext0_Click(object sender, EventArgs e)
    {

        // Response.Redirect("frmFireDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmFireDetails.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
    }
}
