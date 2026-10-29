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

public partial class UI_TSIPASS_frmFireDetailRen : System.Web.UI.Page
{
    SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);


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

            Response.Redirect("~/Index.aspx");
        }


        if (!IsPostBack)
        {

            if (!IsPostBack)
            {
                DataSet dscheck = new DataSet();
                dscheck = Gen.GetShowRenewalQuestionaries(Session["uid"].ToString().Trim(), Request.QueryString[0].ToString());
                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    Session["Applid"] = dscheck.Tables[0].Rows[0]["intQuessionaireid"].ToString().Trim();
                }
                else
                {
                    Session["Applid"] = "0";
                }

                if (dscheck != null && dscheck.Tables.Count > 0 && dscheck.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(dscheck.Tables[0].Rows[0]["Approval_Status"].ToString()) >= 3)
                    {

                        ResetFormControl(this);

                    }
                }
                DataSet ds = new DataSet();
                ds = Gen.ViewAttachmentREN(Session["uid"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
                {
                    FillDetails();
                }
            }
            if (!IsPostBack)
            {
                DataSet dsnew = new DataSet();
                dsnew = Gen.getdataofidentityREN(Request.QueryString[0].ToString(), "14");//Session["Applid"].ToString()
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    if (Request.QueryString[1].ToString() == "N")
                    {
                        Response.Redirect("manfofboilerRENEWAL.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    }
                    else
                    {
                        Response.Redirect("frmFactoryRenewal.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&Previous=" + "P");
                    }
                }
            }


        }

        if (!IsPostBack)
        {
            DataSet ds = new DataSet();

            ds = RetriveFiredataREN(Request.QueryString[0].ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                FillDetails();
            }
        }

        if (!IsPostBack)
        {
            dtMyTableCertificate = createtablecrtificate();
            Session["CertificateTb2"] = dtMyTableCertificate;
        }


        if ((hdfID.Value.ToString().Trim() != "" && hdfFlagID.Value.ToString().Trim() == "0"))
        {

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

            ds = GetdataofFireenterprenuerRen(hdfFlagID0.Value.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {

                int result = 0;


                result = InsertFireDetailsRen("", Request.QueryString[0].ToString().Trim(), "", "1", "1",
                    txtHight_Building.Text, txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
               txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,
               rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "", "", "", "", "", "", rblTrolley_45.SelectedValue,
               "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, Session["uid"].ToString(), DateTime.Now.ToString(),
               Session["uid"].ToString(), DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text, HoseReel, WetRiser, DownCorner, YardHydrant,
               ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps,
               NoofFireLifts, txtOCFileno.Text, txtLatfileNo.Text, txtOCfee.Text, txtOCDate.Text, txtRenOCDate.Text);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";
                    //  this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;

                    DataSet dsdatenew = new DataSet();
                    dsdatenew = RetriveFiredataREN(Request.QueryString[0].ToString());


                    if (dsdatenew.Tables[0].Rows.Count > 0)
                    {
                        if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                        {
                            gvCertificate.DataSource = dsdatenew.Tables[1];
                            gvCertificate.DataBind();
                        }
                    }

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

                }

            }
            else
            {

                int result = 0;
                result = InsertFireDetailsRen("", Request.QueryString[0].ToString().Trim(), "", "1", "1",
                    txtHight_Building.Text, txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
               txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,
               rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "", "", "", "", "", "", rblTrolley_45.SelectedValue,
               "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, Session["uid"].ToString(), DateTime.Now.ToString(),
               Session["uid"].ToString(), DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text, HoseReel, WetRiser, DownCorner, YardHydrant,
               ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps,
               NoofFireLifts, txtOCFileno.Text, txtLatfileNo.Text, txtOCfee.Text, txtOCDate.Text, txtRenOCDate.Text);
                if (result > 0)
                {

                    lblmsg.Text = "<font color='green'>Fire Details Saved Successfully..!</font>";

                    success.Visible = true;
                    Failure.Visible = false;

                    DataSet dsdatenew = new DataSet();
                    dsdatenew = RetriveFiredataREN(hdfFlagID0.Value.ToString());


                    if (dsdatenew.Tables[0].Rows.Count > 0)
                    {
                        if (dsdatenew != null && dsdatenew.Tables.Count > 1 && dsdatenew.Tables[1].Rows.Count > 0)
                        {
                            gvCertificate.DataSource = ds.Tables[1];
                            gvCertificate.DataBind();
                        }
                    }

                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Fire Details Submission Failed..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;

                }

            }
        }

        else
        {


        }
    }
    public DataSet GetdataofFireenterprenuerRen(string intQuerid)
    {

        osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("GetdataoffiredetRen", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intQuerid.Trim() == "" || intQuerid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intQuerid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intQuerid", SqlDbType.VarChar).Value = intQuerid.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }
    }

    public int InsertFireDetailsRen(string number, string intQuessionaireid, string intCFEEnterpid, string Uid_No, string Reg_Id, string Hight_Building,
    string Hight_EachFloor, string Inter_Stairs, string Exernal_Stairs, string Width_Stairs, string Width_Stairs1, string NoofExits, string Width_eachExit,
    string Fire_East, string Fire_West, string Fire_South, string Fire_North, string Level_ground, string Fire_Detection, string Fire_Alaram, string Sprinkler,
    string Foam, string CO2, string DCP, string Fire_Service_Inlet, string Under_ground, string Court_yard_hydrants, string Fire_pumps_Electrical_15,
    string Fire_pumps_Diesel, string Fire_pumps_Electrical_30, string Trolley_45, string Fencing, string SoakPit, string Lightning_Prot, string Cont_Room,
    string Hydraulic_Platform, string Created_by, string Created_dt, string Modified_by, string Modified_dt, List<Stairecases> lststire,
    string frontsidedir, string HoseReel, string WetRiser, string DownCorner, string YardHydrant, string ManuallyOperatedelectricalfirealaramsystem,
    string AutomaticDetectionSystem, string Undergroundwatersump, string TerraceTank, string TerracePumps, string Electricalpumps, string DieselPumps,
    string JockeyPumps, string NoofFireLifts, string OCFileno, string LatfileNo, string OCfee, string OCDate, string RenOCDate)
    {
        try
        {

            osqlConnection.Open();
            SqlDataAdapter myDataAdapter;

            myDataAdapter = new SqlDataAdapter("sp_FireDetails_Renewal", osqlConnection);
            myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (number.Trim() == "" || number.Trim() == null || number.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@number", SqlDbType.VarChar).Value = "0";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@number", SqlDbType.VarChar).Value = number.Trim();
            }

            if (intQuessionaireid.Trim() == "" || intQuessionaireid.Trim() == null || intQuessionaireid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intQuessionaireid", SqlDbType.Int).Value = Int32.Parse(intQuessionaireid.Trim());
            }


            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null || intCFEEnterpid.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.Int).Value = Int32.Parse(intCFEEnterpid.Trim());
            }

            if (Uid_No.Trim() == "" || Uid_No.Trim() == null || Uid_No.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Uid_No", SqlDbType.Int).Value = Int32.Parse(Uid_No.Trim());
            }

            if (Reg_Id.Trim() == "" || Reg_Id.Trim() == null || Reg_Id.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Reg_Id", SqlDbType.Int).Value = Int32.Parse(Reg_Id.Trim());
            }

            //----------------------------------

            if (Hight_Building.Trim() == "" || Hight_Building.Trim() == null || Hight_Building.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hight_Building", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hight_Building", SqlDbType.Decimal).Value = Decimal.Parse(Hight_Building.Trim());
            }

            if (Hight_EachFloor.Trim() == "" || Hight_EachFloor.Trim() == null || Hight_EachFloor.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hight_EachFloor", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hight_EachFloor", SqlDbType.Decimal).Value = Decimal.Parse(Hight_EachFloor.Trim());
            }

            if (Inter_Stairs.Trim() == "" || Inter_Stairs.Trim() == null || Inter_Stairs.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Inter_Stairs", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Inter_Stairs", SqlDbType.Decimal).Value = Decimal.Parse(Inter_Stairs.Trim());
            }

            if (Exernal_Stairs.Trim() == "" || Exernal_Stairs.Trim() == null || Exernal_Stairs.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Exernal_Stairs", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Exernal_Stairs", SqlDbType.Decimal).Value = Decimal.Parse(Exernal_Stairs.Trim());
            }

            if (Width_Stairs.Trim() == "" || Width_Stairs.Trim() == null || Width_Stairs.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_Stairs", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_Stairs", SqlDbType.Decimal).Value = Decimal.Parse(Width_Stairs.Trim());
            }

            if (Width_Stairs1.Trim() == "" || Width_Stairs1.Trim() == null || Width_Stairs1.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_Stairs1", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_Stairs1", SqlDbType.Decimal).Value = Decimal.Parse(Width_Stairs1.Trim());
            }

            if (NoofExits.Trim() == "" || NoofExits.Trim() == null || NoofExits.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@NoofExits", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@NoofExits", SqlDbType.Decimal).Value = Decimal.Parse(NoofExits.Trim());
            }

            if (Width_eachExit.Trim() == "" || Width_eachExit.Trim() == null || Width_eachExit.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_eachExit", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Width_eachExit", SqlDbType.Decimal).Value = Decimal.Parse(Width_eachExit.Trim());
            }

            if (Fire_East.Trim() == "" || Fire_East.Trim() == null || Fire_East.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_East", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_East", SqlDbType.Decimal).Value = Decimal.Parse(Fire_East.Trim());
            }

            if (Fire_West.Trim() == "" || Fire_West.Trim() == null || Fire_West.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_West", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_West", SqlDbType.Decimal).Value = Decimal.Parse(Fire_West.Trim());
            }

            if (Fire_South.Trim() == "" || Fire_South.Trim() == null || Fire_South.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_South", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_South", SqlDbType.Decimal).Value = Decimal.Parse(Fire_South.Trim());
            }

            if (Fire_North.Trim() == "" || Fire_North.Trim() == null || Fire_North.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_North", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_North", SqlDbType.Decimal).Value = Decimal.Parse(Fire_North.Trim());
            }
            //-------------------------------------

            //--------------------------------------
            if (Level_ground.Trim() == "" || Level_ground.Trim() == null || Level_ground.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Level_ground", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Level_ground", SqlDbType.Int).Value = Int32.Parse(Level_ground.Trim());
            }

            //---------------------------------------

            if (Fire_Detection.Trim() == "" || Fire_Detection.Trim() == null || Fire_Detection.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Detection", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Detection", SqlDbType.VarChar).Value = Fire_Detection.Trim();
            }

            if (Fire_Alaram.Trim() == "" || Fire_Alaram.Trim() == null || Fire_Alaram.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Alaram", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Alaram", SqlDbType.VarChar).Value = Fire_Alaram.Trim();
            }

            //-----------------------------------------
            if (Sprinkler.Trim() == "" || Sprinkler.Trim() == null || Sprinkler.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Sprinkler", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Sprinkler", SqlDbType.Char).Value = Char.Parse(Sprinkler.Trim());
            }

            if (Foam.Trim() == "" || Foam.Trim() == null || Foam.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Foam", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Foam", SqlDbType.Char).Value = Char.Parse(Foam.Trim());
            }


            if (CO2.Trim() == "" || CO2.Trim() == null || CO2.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CO2", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@CO2", SqlDbType.Char).Value = Char.Parse(CO2.Trim());
            }


            if (DCP.Trim() == "" || DCP.Trim() == null || DCP.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@DCP", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@DCP", SqlDbType.Char).Value = Char.Parse(DCP.Trim());
            }


            if (Fire_Service_Inlet.Trim() == "" || Fire_Service_Inlet.Trim() == null || Fire_Service_Inlet.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Service_Inlet", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_Service_Inlet", SqlDbType.Char).Value = Char.Parse(Fire_Service_Inlet.Trim());
            }


            //----------------------------------------

            //          @Trolley_45 char(1),
            //@Fencing char(1),
            //@SoakPit char(1),
            //@Lightning_Prot char(1),
            //@Cont_Room char(1),
            //@Hydraulic_Platform char(1),


            if (Trolley_45.Trim() == "" || Trolley_45.Trim() == null || Trolley_45.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Trolley_45", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Trolley_45", SqlDbType.Char).Value = Char.Parse(Trolley_45.Trim());
            }

            if (Fencing.Trim() == "" || Fencing.Trim() == null || Fencing.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fencing", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fencing", SqlDbType.Char).Value = Char.Parse(Fencing.Trim());
            }


            if (SoakPit.Trim() == "" || SoakPit.Trim() == null || SoakPit.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@SoakPit", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@SoakPit", SqlDbType.Char).Value = Char.Parse(SoakPit.Trim());
            }


            if (Lightning_Prot.Trim() == "" || Lightning_Prot.Trim() == null || Lightning_Prot.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Lightning_Prot", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Lightning_Prot", SqlDbType.Char).Value = Char.Parse(Lightning_Prot.Trim());
            }


            if (Cont_Room.Trim() == "" || Cont_Room.Trim() == null || Cont_Room.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Cont_Room", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Cont_Room", SqlDbType.Char).Value = Char.Parse(Cont_Room.Trim());
            }

            if (Hydraulic_Platform.Trim() == "" || Hydraulic_Platform.Trim() == null || Hydraulic_Platform.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hydraulic_Platform", SqlDbType.Char).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Hydraulic_Platform", SqlDbType.Char).Value = Char.Parse(Hydraulic_Platform.Trim());
            }



            if (Under_ground.Trim() == "" || Under_ground.Trim() == null || Under_ground.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Under_ground", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Under_ground", SqlDbType.Decimal).Value = Decimal.Parse(Under_ground.Trim());
            }

            if (Court_yard_hydrants.Trim() == "" || Court_yard_hydrants.Trim() == null || Court_yard_hydrants.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Court_yard_hydrants", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Court_yard_hydrants", SqlDbType.Decimal).Value = Decimal.Parse(Court_yard_hydrants.Trim());
            }

            if (Fire_pumps_Electrical_15.Trim() == "" || Fire_pumps_Electrical_15.Trim() == null || Fire_pumps_Electrical_15.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Electrical_15", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Electrical_15", SqlDbType.Decimal).Value = Decimal.Parse(Fire_pumps_Electrical_15.Trim());
            }

            if (Fire_pumps_Diesel.Trim() == "" || Fire_pumps_Diesel.Trim() == null || Fire_pumps_Diesel.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Diesel", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Diesel", SqlDbType.Decimal).Value = Decimal.Parse(Fire_pumps_Diesel.Trim());
            }

            if (Fire_pumps_Electrical_30.Trim() == "" || Fire_pumps_Electrical_30.Trim() == null || Fire_pumps_Electrical_30.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Electrical_30", SqlDbType.Decimal).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Fire_pumps_Electrical_30", SqlDbType.Decimal).Value = Decimal.Parse(Fire_pumps_Electrical_30.Trim());
            }

            if (frontsidedir.Trim() == "" || frontsidedir.Trim() == null || frontsidedir.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@frontsidedir", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@frontsidedir", SqlDbType.VarChar).Value = frontsidedir.Trim();
            }
            //----------------------------------------------

            if (Created_by.Trim() == "" || Created_by.Trim() == null || Created_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_by", SqlDbType.Int).Value = Int32.Parse(Created_by.Trim());
            }

            if (Created_dt.Trim() == "" || Created_dt.Trim() == null || Created_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Created_dt", SqlDbType.DateTime).Value = Created_dt.Trim();
            }


            if (Modified_by.Trim() == "" || Modified_by.Trim() == null || Modified_by.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_by", SqlDbType.Int).Value = Int32.Parse(Modified_by.Trim());
            }

            if (Modified_dt.Trim() == "" || Modified_dt.Trim() == null || Modified_dt.Trim() == "--Select--")
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@Modified_dt", SqlDbType.DateTime).Value = Modified_dt.Trim();
            }

            myDataAdapter.SelectCommand.Parameters.Add("@HoseReel", SqlDbType.VarChar).Value = HoseReel.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@WetRiser", SqlDbType.VarChar).Value = WetRiser.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@DownCorner", SqlDbType.VarChar).Value = DownCorner.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@YardHydrant", SqlDbType.VarChar).Value = YardHydrant.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@ManuallyOperatedelectricalfirealaramsystem", SqlDbType.VarChar).Value = ManuallyOperatedelectricalfirealaramsystem.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@AutomaticDetectionSystem", SqlDbType.VarChar).Value = AutomaticDetectionSystem.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@Undergroundwatersump", SqlDbType.VarChar).Value = Undergroundwatersump.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@TerraceTank", SqlDbType.VarChar).Value = TerraceTank.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@TerracePumps", SqlDbType.VarChar).Value = TerracePumps.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@Electricalpumps", SqlDbType.VarChar).Value = Electricalpumps.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@DieselPumps", SqlDbType.VarChar).Value = DieselPumps.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@JockeyPumps", SqlDbType.VarChar).Value = JockeyPumps.Trim();
            myDataAdapter.SelectCommand.Parameters.Add("@NoofFireLifts", SqlDbType.VarChar).Value = NoofFireLifts.Trim();

            if (OCFileno.Trim() == "" || OCFileno.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCFileno", SqlDbType.VarChar).Value = "NA";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCFileno", SqlDbType.VarChar).Value = OCFileno.ToString();
            }
            if (LatfileNo.Trim() == "" || LatfileNo.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@LatfileNo", SqlDbType.VarChar).Value = "NA";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@LatfileNo", SqlDbType.VarChar).Value = LatfileNo.ToString();
            }
            if (OCfee.Trim() == "" || OCfee.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCfee", SqlDbType.VarChar).Value = "NA";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCfee", SqlDbType.VarChar).Value = OCfee.ToString();
            }
            if (OCDate.Trim() == "" || OCDate.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCDate", SqlDbType.DateTime).Value = "NA";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@OCDate", SqlDbType.DateTime).Value = OCDate.ToString();
            }
            if (RenOCDate.Trim() == "" || RenOCDate.Trim() == null)
            {
                myDataAdapter.SelectCommand.Parameters.Add("@RenOCDate", SqlDbType.DateTime).Value = "NA";
            }
            else
            {
                myDataAdapter.SelectCommand.Parameters.Add("@RenOCDate", SqlDbType.DateTime).Value = RenOCDate.ToString();
            }



            int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


            if (n > 0)
            {
                int valid = 0;

                SqlCommand cmd = null;

                foreach (Stairecases fromvo in lststire)
                {
                    cmd = new SqlCommand("USP_INSERT_StaireCases_Renewal", osqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@intQuessionaireid", Convert.ToString(intQuessionaireid));
                    cmd.Parameters.AddWithValue("@intCFEEnterpid", Convert.ToString(intCFEEnterpid));

                    cmd.Parameters.AddWithValue("@Staireid", Convert.ToString(fromvo.Staireid));
                    cmd.Parameters.AddWithValue("@StaireName", Convert.ToString(fromvo.StaireName));
                    cmd.Parameters.AddWithValue("@NoofStairecases", Convert.ToString(fromvo.NoofStairecases));
                    cmd.Parameters.AddWithValue("@Width", Convert.ToString(fromvo.Width));
                    cmd.Parameters.AddWithValue("@id", Convert.ToString(fromvo.id));
                    cmd.Parameters.AddWithValue("@Created_By ", Convert.ToString(fromvo.Created_By));
                    cmd.Parameters.Add("@Valid", SqlDbType.Int, 500);
                    cmd.Parameters["@Valid"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    valid = (Int32)cmd.Parameters["@Valid"].Value;
                }
                return 1;

            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            osqlConnection.Close();
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
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


        txtFire_East.Text = "";
        txtFire_North.Text = "";

        txtFire_South.Text = "";
        txtFire_West.Text = "";
        txtHight_Building.Text = "";
        txtHight_EachFloor.Text = "";

        txtWidth_Stairs1.Text = "";
    }
    protected void BtnClear0_Click(object sender, EventArgs e)
    {



    }

    public DataSet RetriveFiredataREN(string intCFEEnterpid)
    {
        osqlConnection.Open();
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        try
        {
            da = new SqlDataAdapter("RetriveFireDataREN", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (intCFEEnterpid.Trim() == "" || intCFEEnterpid.Trim() == null)
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = "%";
            else
                da.SelectCommand.Parameters.Add("@intCFEEnterpid", SqlDbType.VarChar).Value = intCFEEnterpid.ToString();

            da.Fill(ds);
            return ds;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            osqlConnection.Close();
        }

    }

    void FillDetails()
    {
        hdfFlagID.Value = "1";
        DataSet ds = new DataSet();

        try
        {

            DataSet dsattachment = new DataSet();
            dsattachment = Gen.ViewAttachmentREN(Request.QueryString[0].ToString());

            if (dsattachment.Tables[0].Rows.Count > 0)
            {
                int c = dsattachment.Tables[0].Rows.Count;
                string sen, sen1, sen2;
                int i = 0;

                while (i < c)
                {
                    sen2 = dsattachment.Tables[0].Rows[i][0].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");


                    if (sen.Contains("OccupancyCopy"))
                    {
                        hpOtherPlans.NavigateUrl = sen;
                        hpOtherPlans.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblOtherPlans.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    if (sen.Contains("LatestRenewalCopy"))  //added newly. 17.1.19(itc error)
                    {
                        hplLatestRenewal.NavigateUrl = sen;
                        hplLatestRenewal.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        lblLatestRenewal.Text = dsattachment.Tables[0].Rows[i][1].ToString();
                        //HyperLink1.NavigateUrl = sen;
                        //HyperLink1.Text = 
                    }
                    i++;
                }
            }
            ds = RetriveFiredataREN(Request.QueryString[0].ToString());


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
                if (ds.Tables[0].Rows[0]["OCFileno"].ToString().Trim() != "")
                {
                    txtOCFileno.Text = ds.Tables[0].Rows[0]["OCFileno"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["LatfileNo"].ToString().Trim() != "")
                {
                    txtLatfileNo.Text = ds.Tables[0].Rows[0]["LatfileNo"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["OCfee"].ToString().Trim() != "")
                {
                    txtOCfee.Text = ds.Tables[0].Rows[0]["OCfee"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["OCDate"].ToString().Trim() != "")
                {
                    txtOCDate.Text = ds.Tables[0].Rows[0]["OCDate"].ToString().Trim();
                }
                if (ds.Tables[0].Rows[0]["RenOCDate"].ToString().Trim() != "")
                {
                    txtRenOCDate.Text = ds.Tables[0].Rows[0]["RenOCDate"].ToString().Trim();
                }

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


            if (lblLatestRenewal.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Latest Renewal Copy..!</font>";
                success.Visible = false;
                Failure.Visible = true;
                return;
            }
            if (lblOtherPlans.Text == "")
            {
                lblmsg0.Text = "<font color='red'>Please Upload Occupancy Copy..!</font>";
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

            ds = GetdataofFireenterprenuerRen(hdfFlagID0.Value.ToString());
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
                result = InsertFireDetailsRen("", Request.QueryString[0].ToString().Trim(), "", "1", "1",
                    txtHight_Building.Text, txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
               txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,
               rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "", "", "", "", "", "", rblTrolley_45.SelectedValue,
               "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, Session["uid"].ToString(), DateTime.Now.ToString(),
               Session["uid"].ToString(), DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text, HoseReel, WetRiser, DownCorner, YardHydrant,
               ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps,
               NoofFireLifts, txtOCFileno.Text, txtLatfileNo.Text, txtOCfee.Text, txtOCDate.Text, txtRenOCDate.Text);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("manfofboilerRENEWAL.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
                    lblmsg.Text = "<font color='green'>Fire Details Added Successfully..!</font>";
                    //this.Clear();
                    success.Visible = true;
                    Failure.Visible = false;
                    // Response.Write("<script>alert('Attachment Successfully Added')</script> ");
                    //fillNews(userid);
                }
                else if (result == 0)
                {
                    Response.Redirect("manfofboilerRENEWAL.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
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
                result = InsertFireDetailsRen("", Request.QueryString[0].ToString().Trim(), "", "1", "1",
                    txtHight_Building.Text, txtHight_EachFloor.Text, "", "", "", "", "", "", txtFire_East.Text, txtFire_West.Text, txtFire_South.Text,
               txtFire_North.Text, ddlLevel_ground.SelectedValue, ddlFire_Detection.SelectedItem.Text, ddlFire_Alaram.SelectedItem.Text,
               rblSprinkler.SelectedValue, "", rblCO2.SelectedValue, "", "", "", "", "", "", "", rblTrolley_45.SelectedValue,
               "", rblSoakPit.SelectedValue, rblLightning_Prot.SelectedValue, rblCont_Room.SelectedValue, rblHydraulic_Platform.SelectedValue, Session["uid"].ToString(), DateTime.Now.ToString(),
               Session["uid"].ToString(), DateTime.Now.ToString(), lststire, ddlfrontsidedir.SelectedItem.Text, HoseReel, WetRiser, DownCorner, YardHydrant,
               ManuallyOperatedelectricalfirealaramsystem, AutomaticDetectionSystem, Undergroundwatersump, TerraceTank, TerracePumps, Electricalpumps, DieselPumps, JockeyPumps,
               NoofFireLifts, txtOCFileno.Text, txtLatfileNo.Text, txtOCfee.Text, txtOCDate.Text, txtRenOCDate.Text);
                if (result > 0)
                {
                    //ResetFormControl(this);
                    Response.Redirect("manfofboilerRENEWAL.aspx?intApplicationId=" + Request.QueryString[0].ToString() + "&next=" + "N");
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
        Response.Redirect("frmFactoryRenewal.aspx?intApplicationId=" + hdfFlagID0.Value + "&Previous=" + "P");
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
    protected void btnLatestRenewal_Click(object sender, EventArgs e)
    {
        string newPath = "";
        //string sFileDir = "E:\\Satishkumar\\Applicaitons\\TMCWebsite\\TMC website\\TenderNotice";
        //string sFileDir = "~\\TenderNotice";
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

        General t1 = new General();
        if ((flLatRenewalCopy.PostedFile != null) && (flLatRenewalCopy.PostedFile.ContentLength > 0))
        {
            //determine file name
            string sFileName = System.IO.Path.GetFileName(flLatRenewalCopy.PostedFile.FileName);
            try
            {
                string[] fileType = flLatRenewalCopy.PostedFile.FileName.Split('.');
                int i = fileType.Length;
                if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                {
                    //Create a new subfolder under the current active folder
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\LatestRenewalCopy");

                    // Create the subfolder
                    if (!Directory.Exists(newPath))

                        System.IO.Directory.CreateDirectory(newPath);
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                    int count = dir.GetFiles().Length;
                    if (count == 0)
                        flLatRenewalCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                    else
                    {
                        if (count == 1)
                        {
                            string[] Files = Directory.GetFiles(newPath);

                            foreach (string file in Files)
                            {
                                File.Delete(file);
                            }
                            flLatRenewalCopy.PostedFile.SaveAs(newPath + "\\" + sFileName);
                        }
                    }
                    int result = 0;

                    result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "LatestRenewalCopy");

                    if (result > 0)
                    {
                        //ResetFormControl(this);
                        lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                        hplLatestRenewal.Text = flLatRenewalCopy.FileName;
                        lblLatestRenewal.Text = flLatRenewalCopy.FileName;
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
        string sFileDir = ConfigurationManager.AppSettings["RENfilePath"];

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
                    newPath = System.IO.Path.Combine(sFileDir, Request.QueryString[0].ToString() + "\\OccupancyCopy");

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

                    result = t1.InsertRenewalAttachement(Session["Applid"].ToString(), Session["uid"].ToString(), "1", "1", fileType[i - 1].ToUpper(), sFileName, newPath, "A", Session["uid"].ToString(), "OccupancyCopy");

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


}



