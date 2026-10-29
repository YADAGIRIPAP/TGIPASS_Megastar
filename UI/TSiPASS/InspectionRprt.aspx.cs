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

public partial class UI_TSiPASS_InspectionRprt : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session.Count <= 0)
        {
            // Response.Redirect("../../frmUserLogin.aspx");
        }


        if (!IsPostBack)
        {
          //  fillForm();
           // DisableForm(Page.Controls);
            DataSet dscheck = new DataSet();
            string niktesst = Session["uid"].ToString().Trim();
            dscheck = Gen.GetShowQuestionaries(Session["uid"].ToString().Trim());
            if (dscheck.Tables[0].Rows.Count > 0)
            {
                Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
            }
            else
            {
                Session["Applid"] = "0";
            }

            DataSet dsver = new DataSet();

            //dsver = Gen.Getverifyofque2(Session["Applid"].ToString());

            //if (dsver.Tables[0].Rows.Count > 0)
            //{
            string res = Gen.RetriveStatus(Session["Applid"].ToString());
            ////string res = Gen.RetriveStatus("1002");


            if (res == "3" || Convert.ToInt32(res) >= 3)
            {
                ResetFormControl(this);
            }


            if (Session["Applid"].ToString() != "" || Session["Applid"].ToString() != "0")
            {

                DataSet dsch = new DataSet();
                dsch = Gen.GetEnterPreneurdatabylineofactivity1(Session["Applid"].ToString());



            }


        }
        if (Request.QueryString["intApplicationId"] != null)
        {
            hdfFlagID0.Value = Request.QueryString["intApplicationId"];

            if (!IsPostBack)
            {
            //    FillDetails();

            }

        }
        

            if (Request.QueryString["EntrpId"] != null)
        {
            inctiveID = Request.QueryString["EntrpId"];

            if (!IsPostBack)
            {
                //    FillDetails();

            }

        }

        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

        }

        //if (hdfFlagID0.Value.ToString().Trim() != "")
        //{


        //}

    }

    ////public string getINCID(string userID)
    //{
        
        
    // //   incentiveID = Gen.returnINCID(userID);
    //  //  return incentiveID;
    //}

    public void fillForm()
    {
        try
        {

            string created_by = Session["uid"].ToString();
            //incentiveID = getINCID(created_by);
            //DataTable oDataTable = new DataTable();
            DataSet oDataSet1 = new DataSet();
            oDataSet1 = Gen.IncentivesRprtData(incentiveID);
            ddlNameofInd.DataSource = oDataSet1;
            if (incentiveID != null)
                trNameofInd2TxtBx.Visible = true;
            else
                trNameofInd1ddl.Visible = true;

            txtNameofInd.Text = oDataSet1.Tables[0].Rows[0]["UnitName"].ToString();

            ddlNameofInd.DataValueField = "UnitName";
            ddlNameofInd.DataBind();


            txtUdyogAdhar.Text= oDataSet1.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
          // txt
            



        }
        catch(Exception ex)
        {
            throw ex;
        }
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
        succMesg=insertDetailsofInspection();
        if(succMesg=="1")
        ScriptManager.RegisterStartupScript(this,this.GetType(),"SuccMesg","alert('Report Saved');",true);
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccMesg", "alert('Inspection report uploaded earlier!!');", true);

    }

    protected string insertDetailsofInspection()
    {
        string Status;
        string created_by = Session["uid"].ToString();

      //  incentiveID = 

        lblIPODesignation.Text = "";
        //ddlNameofInd.SelectedItem.Text.ToString() = "";

            Status =Gen.insertInspRprtData(inctiveID, Session["User_Code"].ToString(), null,null,txtIPOName.Text,null,txtInpectedDate.Text,ddlConstOfUnit.SelectedItem.Text,txtPersonIndustry.Text,ddlStatus.SelectedItem.Text,rdbVerifyCert.SelectedItem.Text,txtLOAInsp.Text,txtUnitInsp.Text,txtInstldCapInsp.Text,txtValueInsp.Text,txtLOAExistEntr.Text,txtInstCapExistEntr.Text,txtPercntIncrExistEntr.Text,txtLOAExpn.Text,txtInsCapExpn.Text,txtIncrExpn.Text,txtLandExtEntr.Text,txtBldngExtEntr.Text,txtPltMachExstEntr.Text,txtTotLand.Text,txtExpnLAnd.Text, txtBldngExpnDivers.Text, txtPltMachExpn.Text, txtTolBldg.Text, txtLandExpnDiverse.Text, txtBldgIncrExpn.Text, txtPltMachIncrExpn.Text, txtToTPlantMach.Text, txtCalenderDCP.Text, txtRcptAppln.Text, txtDateShrtfall.Text, txtDtShrtFallRcvd.Text, txtExtent.Text, txtBuiltupAra.Text, txt5TtimesBltup.Text, txtExtentElgble.Text,rdblYesNoClaimSubmn.SelectedItem.Text, rdblClmApplRmbrLandCst.SelectedItem.Text, txtLndCst25Prcnt.Text, txtRegnFee25Prcnt.Text, txtTotal25Prcnt.Text, txtAprdPjCst25Prcnt.Text, txtProprtn25Prcnt.Text, txtComputedcost.Text,txtValofItems.Text,txtPlnthArea.Text,txtTSSFC.Text,txtAprvPJVal.Text,txtAppJTot.Text,txtTotVal1.Text,txtTotVal2.Text,txtTotVal3.Text,txtTotVal4.Text,txtTotVal10.Text,txtGrndTotVal.Text,txtAsperApprPjCostPM.Text,txtAsperCivilEngr.Text,txtComptdGm.Text,txtComputedcost.Text,txtAsperApprPjCostPM.Text, txtAsperListPM.Text, txtTechKnowPM.Text, txt2ndMachPM.Text, txtPrcnt2ndMach.Text, txtTotal2ndHandMach.Text, txtTot2ndMach.Text, txtTotCstCmptdLand.Text, txtTotCstCmptdBldg.Text, txtTotCstCmptdPlntMach.Text, txtTotCstCmptdTotal.Text, txtInvSubsidyVal.Text, txtAddnInvSubsdyWmn.Text, txtInvSubsdySCST.Text, txtAddnInvSbsdySc10Prcnt.Text, txtTotalInv.Text,"", "", "", "", "", "", "", "", "", "", "", "");
        
        return Status;
    }
}