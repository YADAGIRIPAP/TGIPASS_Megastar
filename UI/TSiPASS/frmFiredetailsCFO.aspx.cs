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

//created by suresh as on 13-1-2016 
//tables is td_BDCDet,tbl_Users
//procedures CheckUserid,insrtBDC,deleteBDC,getBDCbyID

public partial class UI_TSiPASS_frmFiredetailsCFO : System.Web.UI.Page
{
    int delete = 0;
    comFunctions cmf = new comFunctions();
    General Gen = new General();
    DataRow dtrdr;
    DataTable myDtNewRecdr = new DataTable();
    static DataTable dtMyTable;
    static DataTable dtMyTableCertificate;
    List<Stairecases> lststire = new List<Stairecases>();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
            Response.Redirect("~/Index.aspx");
        }

        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                dtMyTableCertificate = createtablecrtificate();
                Session["CertificateTb2"] = dtMyTableCertificate;
            }
            DataSet dscheck = new DataSet();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dscheck1 = new DataSet();
            dscheck1 = Gen.GetShowQuestionariesCFO(Session["uid"].ToString().Trim());
            if (dscheck1.Tables[0].Rows.Count > 0)
            {
                Session["ApplidA"] = dscheck1.Tables[0].Rows[0]["intQuessionaireCFOid"].ToString().Trim();
            }
            else
            {
                Session["ApplidA"] = "0";
            }

            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    ResetFormControl(this);
                }

            }


            // }
        }
        if (!IsPostBack)
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.getdataofidentityCFONew(Session["ApplidA"].ToString(), "14");

            if (dsnew.Tables[0].Rows.Count > 0)
            {




            }
            else
            {


                if (Request.QueryString[1].ToString() == "N")
                {

                    Response.Redirect("frmOccupencyCertificateTSIIC.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");

                }

                else
                {

                    Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");

                }
            }


        }

        //if (!IsPostBack)
        //{

        //    if (Session["Applida"].ToString().Trim() == "" || Session["Applid"].ToString().Trim() == "0")
        //    {
        //        Response.Redirect("frmQuesstionniareRegc.aspx");
        //    }


        //    if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
        //    {
        //        DataSet dsnew = new DataSet();

        //        dsnew = Gen.GetEnterPreneurdatabyQuewaterReq(Session["Applid"].ToString());

        //        if (dsnew.Tables[0].Rows.Count > 0)
        //        {
        //            txtHight_Building.Text = dsnew.Tables[0].Rows[0]["Hight_Build"].ToString().Trim();
        //            txtHight_Building.Enabled = false;
        //        }
        //        else
        //        {
        //            txtHight_Building.Enabled = true;
        //        }
        //    }
        //}



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

        if (!IsPostBack)
        {
            DataSet dsver = new DataSet();

            dsver = Gen.Getverifyofque5CFO(Session["ApplidA"].ToString());

            if (dsver.Tables[0].Rows.Count > 0)
            {
                string res = Gen.RetriveStatusCFO(Session["ApplidA"].ToString());
                ////string res = Gen.RetriveStatus("1002");


                if (res == "3" || Convert.ToInt32(res) >= 3)
                {
                    foreach (GridViewRow row in gvCertificate.Rows)
                    {
                        DataControlFieldCell editable = (DataControlFieldCell)row.Controls[0];
                        editable.Enabled = false;
                    }
                    if (gvCertificate.Rows.Count > 0)
                    {
                        BtnSave2.Enabled = false;
                    }
                }
            }
        }
        if (txtHight_Building.Text == "")
        {
            txtHight_Building.ReadOnly = false;
        }
        if (txtHight_EachFloor.Text == "")
        {
            txtHight_EachFloor.ReadOnly = false;
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
                    //case "System.Web.UI.WebControls.FileUpload":
                    //    ((FileUpload)c).Enabled = false;
                    //    break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)c).Enabled = false;
                        break;
                }
            }
        }
        if (ddlstaire.SelectedItem.Text == "--Select--")
        {
            ddlstaire.Enabled = true;
            txtWidth_Stairs1.ReadOnly = false;
            txtNofStairecases.ReadOnly = false;
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (BtnSave1.Text == "Save")
        {
            if (gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Means of Escape Details and Click add new Button </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            lststire.Clear();
            foreach (GridViewRow gvrow in gvCertificate.Rows)
            {
                Stairecases fromvo = new Stairecases();
                int rowIndex = gvrow.RowIndex;
                fromvo.Staireid = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                fromvo.StaireName = gvCertificate.Rows[rowIndex].Cells[1].Text;
                fromvo.Width = gvCertificate.Rows[rowIndex].Cells[2].Text;
                fromvo.NoofStairecases = gvCertificate.Rows[rowIndex].Cells[3].Text;
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.Created_By = Session["uid"].ToString();
                lststire.Add(fromvo);
            }
            string HoseReel = rblHoseReel.SelectedValue;
            string WetRiser = rblWetRiser.SelectedValue;
            string DownCorner = rblDownCorner.SelectedValue;
            string YardHydrant = rdbYardHydrant.SelectedValue;
            string ManuallyOperatedelectricalfirealaramsystem = rdbManuallyOperated.SelectedValue;
            string AutomaticDetectionSystem = rdbDetectionSystem.SelectedValue;
            string Undergroundwatersump = rdbgroundwatersump.SelectedValue;
            string TerraceTank = rdbTerraceTank.SelectedValue;
            string TerracePumps = rdbTerracePumps.SelectedValue;
            string Electricalpumps = rdbElectricalpumps.SelectedValue;
            string DieselPumps = rdbDieselPumps.SelectedValue;
            string JockeyPumps = rdbJockeyPumps.SelectedValue;
            string NoofFireLifts = ddlFireLiftsProvided.SelectedValue;
            DataSet ds = new DataSet();

            ds = Gen.GetdataofFireenterprenuerCFO(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                int result = 0;
                //result = Gen.InsertFireDetails(ds.Tables[0].Rows[0]["intCFEFireid"].ToString().Trim(), Session["Applid"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtHight_Building.Text
                //, txtHight_EachFloor.Text, txtInter_Stairs.Text, txtExernal_Stairs.Text, txtWidth_Stairs.Text, txtWidth_Stairs1.Text,

                //txtNoofExits.Text, txtWidth_eachExit.Text, txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
                //txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,

                //rblSprinkler.SelectedValue, rblFoam.SelectedValue, rblCO2.SelectedValue, rblDCP.SelectedValue, rblFire_Service_Inlet.SelectedValue,

                //txtUnder_ground.Text, txtCourt_yard_hydrants.Text, txtFire_pumps_Electrical_15.Text, txtFire_pumps_Diesel.Text, txtFire_pumps_Electrical_30.Text, rblTrolley_45.SelectedValue,
                //rblFencing.SelectedValue, rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString());

                result = Gen.InsertFireDetailsCFO(ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim(), Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), "1", "1",
                    txtHight_Building.Text, txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
               txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,
               rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "", "", "", "", "", "", rblTrolley_45.SelectedValue,
               "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, "1000", DateTime.Now.ToString(),
               "1000", DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text, HoseReel, WetRiser, DownCorner, YardHydrant,
               ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps, NoofFireLifts);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                    DataSet dsdatenew = new DataSet();
                    dsdatenew = Gen.RetriveFiredata(hdfFlagID0.Value.ToString());


                    if (dsdatenew.Tables[0].Rows.Count > 0)
                    {
                        if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                        {
                            gvCertificate.DataSource = dsdatenew.Tables[1];
                            gvCertificate.DataBind();
                        }
                    }
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {

                    lblmsg.Text = "<font color='green'>Fire Details updated Successfully..!</font>";
                    this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                }

                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }

            }
            else
            {

                int result = 0;
                result = Gen.InsertFireDetailsCFO("0", Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtHight_Building.Text
                , txtHight_EachFloor.Text, "", "", "", "",

                "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
                txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,

                rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "",

                "", "", "", "", "", rblTrolley_45.SelectedValue,
                "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text,
                HoseReel, WetRiser, DownCorner, YardHydrant, ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps, NoofFireLifts);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    // this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                    DataSet dsdatenew = new DataSet();
                    dsdatenew = Gen.RetriveFiredataCFO(hdfFlagID0.Value.ToString());


                    if (dsdatenew.Tables[0].Rows.Count > 0)
                    {
                        if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                        {
                            gvCertificate.DataSource = ds.Tables[1];
                            gvCertificate.DataBind();
                        }
                    }
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }

            }
        }

        else
        {


        }
    }
    public void Clear()
    {

        ddlFire_Alaram.SelectedIndex = 0;
        ddlFire_Detection.SelectedIndex = 0;
        ddlLevel_ground.SelectedIndex = 0;

        foreach (ListItem lst in rblCO2.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        foreach (ListItem lst in rblCont_Room.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        //foreach (ListItem lst in rblDCP.Items)
        //{
        //    if (lst.Selected)
        //        lst.Selected = false;
        //}

        //foreach (ListItem lst in rblFencing.Items)
        //{
        //    if (lst.Selected)
        //        lst.Selected = false;
        //}

        //foreach (ListItem lst in rblFire_Service_Inlet.Items)
        //{
        //    if (lst.Selected)
        //        lst.Selected = false;
        //}

        //foreach (ListItem lst in rblFoam.Items)
        //{
        //    if (lst.Selected)
        //        lst.Selected = false;
        //}

        foreach (ListItem lst in rblHydraulic_Platform.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        foreach (ListItem lst in rblLightning_Prot.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        foreach (ListItem lst in rblSoakPit.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        foreach (ListItem lst in rblSprinkler.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        foreach (ListItem lst in rblTrolley_45.Items)
        {
            if (lst.Selected)
                lst.Selected = false;
        }

        // txtCourt_yard_hydrants.Text = "";
        // txtExernal_Stairs.Text = "";
        txtFire_East.Text = "";
        txtFire_North.Text = "";
        // txtFire_pumps_Diesel.Text = "";
        // txtFire_pumps_Electrical_15.Text = "";
        // txtFire_pumps_Electrical_30.Text = "";
        txtFire_South.Text = "";
        txtFire_West.Text = "";
        txtHight_Building.Text = "";
        txtHight_EachFloor.Text = "";
        //  txtInter_Stairs.Text = "";
        //  txtNoofExits.Text = "";
        //  txtUnder_ground.Text = "";
        //  txtWidth_eachExit.Text = "";
        //  txtWidth_Stairs.Text = "";
        txtWidth_Stairs1.Text = "";
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
            //ds = Gen.getTraineeDetails(hdfID.Value.ToString());
            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmetsDataCFO(hdfFlagID0.Value.ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2, sennew;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");
                    sennew = dsattachment.Tables[0].Rows[i]["LINKNEW"].ToString();// LINKNEW
                    string encpassword = Gen.Encrypt(sennew, "SYSTIME");
                    if (sen.Contains("FireBuildingPlanApproval"))
                    {
                        lblPlanapproval.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        lblPlanapproval.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        LabelPlanapproval.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }

                    if (sen.Contains("CellarFloorPlanApproval"))
                    {
                        HpCellarFloor.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpCellarFloor.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblCellarFloor.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("GroundFloorPlanApproval"))
                    {
                        HpGroundFloor.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpGroundFloor.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblGroundFloor.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("FloorWisePlanApproval"))
                    {
                        HpFloorWise.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpFloorWise.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblFloorWise.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("TerracePlanApproval"))
                    {
                        HpTerracePlan.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpTerracePlan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblTerracePlan.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("FireSectionApproval"))
                    {
                        HpSection.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpSection.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblSection.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("FireElevationApproval"))
                    {
                        HpElevation.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HpElevation.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblElevation.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("fireOtherPlansApproval"))
                    {
                        hpOtherPlans.NavigateUrl = sen;
                        hpOtherPlans.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblOtherPlans.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("FileCertForm"))  //added newly. 17.1.19(itc error)
                    {
                        HyperLink1.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        HyperLink1.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        Label456.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;
                }
            }
            ds = Gen.RetriveFiredataCFO(hdfFlagID0.Value.ToString());


            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    gvCertificate.DataSource = ds.Tables[1];
                    gvCertificate.DataBind();
                    // Session["CertificateTb2"] = ds.Tables[1];
                }
                hdfpencode.Value = ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString();
                txtHight_Building.Text = ds.Tables[0].Rows[0]["Hight_Building"].ToString();
                txtHight_EachFloor.Text = ds.Tables[0].Rows[0]["Hight_EachFloor"].ToString();
                //txtInter_Stairs.Text = ds.Tables[0].Rows[0]["Inter_Stairs"].ToString();
                //txtExernal_Stairs.Text = ds.Tables[0].Rows[0]["Exernal_Stairs"].ToString();
                //txtWidth_Stairs.Text = ds.Tables[0].Rows[0]["Width_Stairs"].ToString();
                //txtWidth_Stairs1.Text = ds.Tables[0].Rows[0]["Width_Stairs1"].ToString();
                //txtNoofExits.Text = ds.Tables[0].Rows[0]["NoofExits"].ToString();
                //txtWidth_eachExit.Text = ds.Tables[0].Rows[0]["Width_eachExit"].ToString();
                txtFire_East.Text = ds.Tables[0].Rows[0]["Fire_East"].ToString();
                txtFire_West.Text = ds.Tables[0].Rows[0]["Fire_West"].ToString();
                txtFire_South.Text = ds.Tables[0].Rows[0]["Fire_South"].ToString();
                txtFire_North.Text = ds.Tables[0].Rows[0]["Fire_North"].ToString();
                ddlLevel_ground.SelectedValue = ddlLevel_ground.Items.FindByValue(ds.Tables[0].Rows[0]["Level_ground"].ToString().Trim()).Value;
                ddlFire_Detection.SelectedValue = ddlFire_Detection.Items.FindByValue(ds.Tables[0].Rows[0]["Fire_Detection"].ToString().Trim()).Value;
                ddlFire_Alaram.SelectedValue = ddlFire_Alaram.Items.FindByValue(ds.Tables[0].Rows[0]["Fire_Alaram"].ToString().Trim()).Value;
                if (ds.Tables[0].Rows[0]["Frontsidedir"].ToString().Trim() != "")
                    ddlfrontsidedir.SelectedValue = ddlfrontsidedir.Items.FindByValue(ds.Tables[0].Rows[0]["Frontsidedir"].ToString().Trim()).Value;
                else
                    ddlfrontsidedir.Enabled = true;

                if (ds.Tables[0].Rows[0]["NoofFireLifts"].ToString().Trim() != "")
                    ddlFireLiftsProvided.SelectedValue = ddlFireLiftsProvided.Items.FindByValue(ds.Tables[0].Rows[0]["NoofFireLifts"].ToString().Trim()).Value;
                else
                    ddlFireLiftsProvided.Enabled = true;


                rblSprinkler.SelectedValue = rblSprinkler.Items.FindByValue(ds.Tables[0].Rows[0]["Sprinkler"].ToString().Trim()).Value;
                //rblFoam.SelectedValue = rblFoam.Items.FindByValue(ds.Tables[0].Rows[0]["Foam"].ToString().Trim()).Value;
                rblCO2.SelectedValue = rblCO2.Items.FindByValue(ds.Tables[0].Rows[0]["CO2"].ToString().Trim()).Value;
                //rblDCP.SelectedValue = rblDCP.Items.FindByValue(ds.Tables[0].Rows[0]["DCP"].ToString().Trim()).Value;
                //rblFire_Service_Inlet.SelectedValue = rblFire_Service_Inlet.Items.FindByValue(ds.Tables[0].Rows[0]["Fire_Service_Inlet"].ToString().Trim()).Value;
                //txtUnder_ground.Text = ds.Tables[0].Rows[0]["Under_ground"].ToString();
                //txtCourt_yard_hydrants.Text = ds.Tables[0].Rows[0]["Court_yard_hydrants"].ToString();
                //txtFire_pumps_Electrical_15.Text = ds.Tables[0].Rows[0]["Fire_pumps_Electrical_15"].ToString();
                //txtFire_pumps_Diesel.Text = ds.Tables[0].Rows[0]["Fire_pumps_Diesel"].ToString();
                //txtFire_pumps_Electrical_30.Text = ds.Tables[0].Rows[0]["Fire_pumps_Electrical_30"].ToString();
                rblTrolley_45.SelectedValue = rblTrolley_45.Items.FindByValue(ds.Tables[0].Rows[0]["Trolley_45"].ToString().Trim()).Value;
                //rblFencing.SelectedValue = rblFencing.Items.FindByValue(ds.Tables[0].Rows[0]["Fencing"].ToString().Trim()).Value;
                rblSoakPit.SelectedValue = rblSoakPit.Items.FindByValue(ds.Tables[0].Rows[0]["SoakPit"].ToString().Trim()).Value;
                rblLightning_Prot.SelectedValue = rblLightning_Prot.Items.FindByValue(ds.Tables[0].Rows[0]["Lightning_Prot"].ToString().Trim()).Value;
                rblCont_Room.SelectedValue = rblCont_Room.Items.FindByValue(ds.Tables[0].Rows[0]["Cont_Room"].ToString().Trim()).Value;
                rblHydraulic_Platform.SelectedValue = rblHydraulic_Platform.Items.FindByValue(ds.Tables[0].Rows[0]["Hydraulic_Platform"].ToString().Trim()).Value;

                if (ds.Tables[0].Rows[0]["HoseReel"].ToString().Trim() != "")
                    rblHoseReel.SelectedValue = rblHoseReel.Items.FindByValue(ds.Tables[0].Rows[0]["HoseReel"].ToString().Trim()).Value;
                else
                    rblHoseReel.Enabled = true;

                if (ds.Tables[0].Rows[0]["WetRiser"].ToString().Trim() != "")
                    rblWetRiser.SelectedValue = rblWetRiser.Items.FindByValue(ds.Tables[0].Rows[0]["WetRiser"].ToString().Trim()).Value;
                else
                    rblWetRiser.Enabled = true;

                if (ds.Tables[0].Rows[0]["DownCorner"].ToString().Trim() != "")
                    rblDownCorner.SelectedValue = rblDownCorner.Items.FindByValue(ds.Tables[0].Rows[0]["DownCorner"].ToString().Trim()).Value;
                else
                    rblDownCorner.Enabled = true;
                if (ds.Tables[0].Rows[0]["YardHydrant"].ToString().Trim() != "")
                    rdbYardHydrant.SelectedValue = rdbYardHydrant.Items.FindByValue(ds.Tables[0].Rows[0]["YardHydrant"].ToString().Trim()).Value;
                else
                    rdbYardHydrant.Enabled = true;
                if (ds.Tables[0].Rows[0]["ManuallyOperatedelectricalfirealaramsystem"].ToString().Trim() != "")
                    rdbManuallyOperated.SelectedValue = rdbManuallyOperated.Items.FindByValue(ds.Tables[0].Rows[0]["ManuallyOperatedelectricalfirealaramsystem"].ToString().Trim()).Value;
                else
                    rdbManuallyOperated.Enabled = true;
                if (ds.Tables[0].Rows[0]["AutomaticDetectionSystem"].ToString().Trim() != "")
                    rdbDetectionSystem.SelectedValue = rdbDetectionSystem.Items.FindByValue(ds.Tables[0].Rows[0]["AutomaticDetectionSystem"].ToString().Trim()).Value;
                else
                    rdbDetectionSystem.Enabled = true;
                if (ds.Tables[0].Rows[0]["Undergroundwatersump"].ToString().Trim() != "")
                    rdbgroundwatersump.SelectedValue = rdbgroundwatersump.Items.FindByValue(ds.Tables[0].Rows[0]["Undergroundwatersump"].ToString().Trim()).Value;
                else
                    rdbgroundwatersump.Enabled = true;
                if (ds.Tables[0].Rows[0]["TerraceTank"].ToString().Trim() != "")
                    rdbTerraceTank.SelectedValue = rdbTerraceTank.Items.FindByValue(ds.Tables[0].Rows[0]["TerraceTank"].ToString().Trim()).Value;
                else
                    rdbTerraceTank.Enabled = true;
                if (ds.Tables[0].Rows[0]["TerracePumps"].ToString().Trim() != "")
                    rdbTerracePumps.SelectedValue = rdbTerracePumps.Items.FindByValue(ds.Tables[0].Rows[0]["TerracePumps"].ToString().Trim()).Value;
                else
                    rdbTerracePumps.Enabled = true;
                if (ds.Tables[0].Rows[0]["Electricalpumps"].ToString().Trim() != "")
                    rdbElectricalpumps.SelectedValue = rdbElectricalpumps.Items.FindByValue(ds.Tables[0].Rows[0]["Electricalpumps"].ToString().Trim()).Value;
                else
                    rdbElectricalpumps.Enabled = true;
                if (ds.Tables[0].Rows[0]["DieselPumps"].ToString().Trim() != "")
                    rdbDieselPumps.SelectedValue = rdbDieselPumps.Items.FindByValue(ds.Tables[0].Rows[0]["DieselPumps"].ToString().Trim()).Value;
                else
                    rdbDieselPumps.Enabled = true;
                if (ds.Tables[0].Rows[0]["JockeyPumps"].ToString().Trim() != "")
                    rdbJockeyPumps.SelectedValue = rdbJockeyPumps.Items.FindByValue(ds.Tables[0].Rows[0]["JockeyPumps"].ToString().Trim()).Value;
                else
                    rdbJockeyPumps.Enabled = true;

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
    protected void txtcontact27_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtcontact13_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtNoofExits_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList14_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList17_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList18_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void RadioButtonList19_SelectedIndexChanged(object sender, EventArgs e)
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

            if (Label456.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Fire Occupancy Certificate Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }

            if (LabelPlanapproval.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Site Plan Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblCellarFloor.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Cellar Floor Plan Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblGroundFloor.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Stilt/Ground Floor Plan Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblFloorWise.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Floor Wise Plan Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblTerracePlan.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Terrace Plan Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblSection.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Section Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblElevation.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Elevation Approval Attachment..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (gvCertificate.Rows.Count == 0)
            {
                lblmsg0.Text = "<font color=red> Please Enter Means of Escape Details and Click add Button </font>";

                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            lststire.Clear();
            foreach (GridViewRow gvrow in gvCertificate.Rows)
            {
                Stairecases fromvo = new Stairecases();
                int rowIndex = gvrow.RowIndex;
                fromvo.Staireid = ((Label)gvrow.FindControl("lblstaireid")).Text.ToString();
                fromvo.StaireName = gvCertificate.Rows[rowIndex].Cells[1].Text;
                fromvo.Width = gvCertificate.Rows[rowIndex].Cells[2].Text;
                fromvo.NoofStairecases = gvCertificate.Rows[rowIndex].Cells[3].Text;
                fromvo.id = ((Label)gvrow.FindControl("lblid")).Text.ToString();
                fromvo.Created_By = Session["uid"].ToString();
                lststire.Add(fromvo);
            }

            ds = Gen.GetdataofFireenterprenuerCFO(hdfFlagID0.Value.ToString());
            string HoseReel = rblHoseReel.SelectedValue;
            string WetRiser = rblWetRiser.SelectedValue;
            string DownCorner = rblDownCorner.SelectedValue;
            string YardHydrant = rdbYardHydrant.SelectedValue;
            string ManuallyOperatedelectricalfirealaramsystem = rdbManuallyOperated.SelectedValue;
            string AutomaticDetectionSystem = rdbDetectionSystem.SelectedValue;
            string Undergroundwatersump = rdbgroundwatersump.SelectedValue;
            string TerraceTank = rdbTerraceTank.SelectedValue;
            string TerracePumps = rdbTerracePumps.SelectedValue;
            string Electricalpumps = rdbElectricalpumps.SelectedValue;
            string DieselPumps = rdbDieselPumps.SelectedValue;
            string JockeyPumps = rdbJockeyPumps.SelectedValue;
            string NoofFireLifts = ddlFireLiftsProvided.SelectedValue;
            if (ds.Tables[0].Rows.Count > 0)
            {
                int result = 0;
                result = Gen.InsertFireDetailsCFO(ds.Tables[0].Rows[0]["intCFOEnterpid"].ToString().Trim(), Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtHight_Building.Text
                , txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
                txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,

                rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "",

                "", "", "", "", "", rblTrolley_45.SelectedValue,
                "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text,
                HoseReel, WetRiser, DownCorner, YardHydrant, ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps, NoofFireLifts);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("frmOccupencyCertificateTSIIC.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Fire Details Added Successfully..!</font>";
                    //this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    Response.Redirect("frmOccupencyCertificateTSIIC.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
            }
            else
            {


                int result = 0;
                result = Gen.InsertFireDetailsCFO("0", Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), "1", "1", txtHight_Building.Text
                , txtHight_EachFloor.Text, "", "", "", "",

                "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
                txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,

                rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "",

                "", "", "", "", "", rblTrolley_45.SelectedValue,
                "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, "1000", DateTime.Now.ToString(), "1000", DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text,
                HoseReel, WetRiser, DownCorner, YardHydrant, ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps, NoofFireLifts);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("frmOccupencyCertificateTSIIC.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Fire Details Added Successfully..!</font>";
                    //this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                }
            }
        }
    }
    protected void btnNext0_Click(object sender, EventArgs e)
    {

        //Response.Redirect("frmPowerDetails.aspx?intApplicationId=" + hdfFlagID0.Value);
        Response.Redirect("frmSteamPipelineInspectUpload.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
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
    protected void BtnSave2_Click1(object sender, EventArgs e)
    {
        gvCertificate.Visible = true;
        try
        {
            AddDataToTableCeertificate(ddlstaire.SelectedItem.Text, txtWidth_Stairs1.Text, ddlstaire.SelectedValue, txtNofStairecases.Text.Trim(), (DataTable)Session["CertificateTb2"]);
            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
            lblmsg.Text = "";
        }
        catch (Exception ee)
        {
            ////lbldtvalid.Text = "Please enter correct Date.";
            ////lbldtvalid.ForeColor = System.Drawing.Color.DarkRed;
        }

        gvCertificate.Visible = true;
    }
    private void AddDataToTableCeertificate(string Stairecase, string Width, string staireid, string Noof, DataTable myTable)
    {//totStartDate, string totEndDate, string totSummary,
        try
        {
            DataRow Row;
            Row = myTable.NewRow();

            dtMyTable = new DataTable("CertificateTb2");
            Row["Stairecase"] = Stairecase;
            Row["Width"] = Width;
            Row["staireid"] = staireid;
            Row["NoofStairecases"] = Noof;
            Row["id"] = "";
            myTable.Rows.Add(Row);
        }
        catch (Exception ee)
        {
            //  ((DataTable)Session["myDatatable"]).Rows.Clear();
            //  Response.Redirect("~/EmpFacility.aspx");
        }
    }
    protected DataTable createtablecrtificate()
    {
        dtMyTable = new DataTable("CertificateTb2");

        // dtMyTable.Columns.Add("new", typeof(string));
        dtMyTable.Columns.Add("Stairecase", typeof(string));
        dtMyTable.Columns.Add("Width", typeof(string));
        dtMyTable.Columns.Add("staireid", typeof(string));
        dtMyTable.Columns.Add("NoofStairecases", typeof(string));
        dtMyTable.Columns.Add("id", typeof(string));

        return dtMyTable;
    }
    protected void BtnClear0_Click2(object sender, EventArgs e)
    {

    }
    protected void gvCertificate_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
            this.gvCertificate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Please enter correct data";// ex.ToString();

        }
        finally
        {

        }
    }
    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void BtnPlanapproval_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FilePlanapproval.PostedFile != null) && (FilePlanapproval.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FilePlanapproval.PostedFile.FileName);
            try
            {
                string[] fileType = FilePlanapproval.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\FireBuildingPlanApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FilePlanapproval.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FilePlanapproval.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "FireBuildingPlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        lblPlanapproval.Text = FilePlanapproval.FileName;
                        LabelPlanapproval.Text = FilePlanapproval.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadCellarFloor.PostedFile != null) && (FileUploadCellarFloor.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadCellarFloor.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadCellarFloor.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\CellarFloorPlanApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadCellarFloor.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadCellarFloor.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "CellarFloorPlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpCellarFloor.Text = FileUploadCellarFloor.FileName;
                        lblCellarFloor.Text = FileUploadCellarFloor.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadGroundFloor.PostedFile != null) && (FileUploadGroundFloor.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadGroundFloor.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadGroundFloor.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\GroundFloorPlanApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadGroundFloor.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadGroundFloor.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "GroundFloorPlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpGroundFloor.Text = FileUploadGroundFloor.FileName;
                        lblGroundFloor.Text = FileUploadGroundFloor.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadFloorWise.PostedFile != null) && (FileUploadFloorWise.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadFloorWise.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadFloorWise.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\FloorWisePlanApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadFloorWise.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadFloorWise.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "FloorWisePlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpFloorWise.Text = FileUploadFloorWise.FileName;
                        lblFloorWise.Text = FileUploadFloorWise.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadTerracePlan.PostedFile != null) && (FileUploadTerracePlan.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadTerracePlan.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadTerracePlan.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\TerracePlanApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadTerracePlan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadTerracePlan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "TerracePlanApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpTerracePlan.Text = FileUploadTerracePlan.FileName;
                        lblTerracePlan.Text = FileUploadTerracePlan.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadSection.PostedFile != null) && (FileUploadSection.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadSection.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadSection.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\FireSectionApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadSection.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadSection.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "FireSectionApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpSection.Text = FileUploadSection.FileName;
                        lblSection.Text = FileUploadSection.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadElevation.PostedFile != null) && (FileUploadElevation.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadElevation.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadElevation.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\FireElevationApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadElevation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadElevation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "FireElevationApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        HpElevation.Text = FileUploadElevation.FileName;
                        lblElevation.Text = FileUploadElevation.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

        General t1 = new General();
        if ((FileUploadfireOtherPlans.PostedFile != null) && (FileUploadfireOtherPlans.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(FileUploadfireOtherPlans.PostedFile.FileName);
            try
            {
                string[] fileType = FileUploadfireOtherPlans.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\fireOtherPlansApproval");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        FileUploadfireOtherPlans.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            FileUploadfireOtherPlans.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;
                    result = t1.InsertImagedataCFO(Session["ApplidA"].ToString(), Request.QueryString[0].ToString(), fileType[i - 1].ToUpper(), newPath, sFileName, "fireOtherPlansApproval", "", Session["uid"].ToString(), DateTime.Now.ToString(), "1000", DateTime.Now.ToString());
                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hpOtherPlans.Text = FileUploadfireOtherPlans.FileName;
                        lblOtherPlans.Text = FileUploadfireOtherPlans.FileName;
                        success.Visible = true;
                        Failure.Visible = false;
                        // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                        //fillNews(userid);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                }
            }
            catch (Exception)//in case of an error
            {
                //lblError.Visible = true;
                //lblError.Text = "An Error Occured. Please Try Again!";
                DeleteFile(newPath + "\\" + sFileName);
                // DeleteFile(sFileDir + sFileName);
            }
        }
    }

    protected void BtnFileCert_Click(object sender, EventArgs e)
    {
        try
        {
            string newPath = "";
            string sFileDir = ConfigurationManager.AppSettings["CFOfilePath"];

            General t1 = new General();
            if (FileUpload4.HasFile)
            {
                if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
                {
                    //determine file name
                    string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                    try
                    {

                        string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["uid"].ToString() + "\\FileCertForm");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            int result = 0;

                            result = t1.InsertCFOAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "FileCertFORM");


                            if (result > 0)
                            {
                                //ResetFormControl(this);
                                lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                                Label3.Text = FileUpload4.FileName;
                                Label456.Text = FileUpload4.FileName;
                                success.Visible = true;
                                Failure.Visible = false;
                                // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                                //fillNews(userid);
                            }
                            else
                            {
                                lblmsg0.Text = "<font color='red'>Attachment Added Failed..!</font>";
                                success.Visible = false;
                                Failure.Visible = true;
                                // Response.Write("<script>alert('Attachment Added Failed ')</script> ");
                            }

                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                            //  Response.Write("<script>alert('Upload PDF,Doc,JPG files only  ')</script> "); //+ fileType[1].Trim(); 
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        //lblError.Visible = true;
                        //lblError.Text = "An Error Occured. Please Try Again!";
                        DeleteFile(newPath + "\\" + sFileName);
                        // DeleteFile(sFileDir + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
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