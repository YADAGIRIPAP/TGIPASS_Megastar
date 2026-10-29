using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
using ListItem = System.Web.UI.WebControls.ListItem;
using AjaxControlToolkit.HTMLEditor.ToolbarButton;
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Net.Mail;
using System.Web;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public partial class UI_TSiPASS_Personal_Interaction_Page_New_Entrepreneurs : System.Web.UI.Page
{
    General gen = new General();
    DB.DB con = new DB.DB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        PrintBtn.Visible = false;
        if (Session["uid"].ToString() == "34668")
        {
            Session["Role_Code"] = "GM";
            Session["DistrictID"] = "1";
        }
        if (!IsPostBack)
        {
            //Main_Interaction_Types();
            Main_Scheme_Types();
            Sector_Name_Details();
            Mandal_List(); //VenueofInteraction_Details();
        }
    }


    protected void WomenCell_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (WomenCell.SelectedValue == "0")
        { Interaction_Id.Visible = true; }
        else
        {
            Interaction_Id.Visible = false; Interaction_Block.Visible = false;
            Interaction_Level_Existing.ClearSelection();
        }

    }
    //private void Main_Interaction_Types()
    //{
    //    DataTable dataTable = new DataTable();
    //    con.OpenConnection();
    //    {
    //        using (SqlCommand command = new SqlCommand("GetInteractiontypes", con.GetConnection))
    //        {
    //            command.CommandType = CommandType.StoredProcedure;

    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                adapter.Fill(dataTable);
    //                Main_Interaction.DataSource = dataTable;
    //                Main_Interaction.DataTextField = "InteractionType";
    //                Main_Interaction.DataValueField = "ID";
    //                Main_Interaction.DataBind();
    //            }
    //            con.CloseConnection();
    //        }
    //    }
    //}

    private void Main_Scheme_Types()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetSchemestypes", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    Scheme_Names.DataSource = dataTable;
                    Scheme_Names.DataTextField = "Scheme_Name";
                    Scheme_Names.DataValueField = "Scheme_ID";
                    Scheme_Names.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void PMEGP_ELIGIBILTY_Details(string Scheme_Name)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetEligibilityCriteria", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Scheme_Name", Scheme_Name);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    PMEGP_ELIGIBILTY.DataSource = dataTable;
                    PMEGP_ELIGIBILTY.DataTextField = "EC_Name";
                    PMEGP_ELIGIBILTY.DataValueField = "EC_ID";
                    PMEGP_ELIGIBILTY.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void PMEGP_FINANCIAL_Details(string Scheme_Name)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetFinancialDetails", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Scheme", Scheme_Name);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    PMEGP_FINANCIAL.DataSource = dataTable;
                    PMEGP_FINANCIAL.DataTextField = "FD_Name";
                    PMEGP_FINANCIAL.DataValueField = "FD_ID";
                    PMEGP_FINANCIAL.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void PMFME_ELIGIBILTY_Details(string Scheme_Name)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetEligibilityCriteria", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Scheme_Name", Scheme_Name);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    PMFME_ELIGIBILTY.DataSource = dataTable;
                    PMFME_ELIGIBILTY.DataTextField = "EC_Name";
                    PMFME_ELIGIBILTY.DataValueField = "EC_ID";
                    PMFME_ELIGIBILTY.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void Sector_Name_Details()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("getSectorNames", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                    // dataTable.Rows[0]["SectorName"] = "--Select--";
                    // sector_dropdown.DataSource = dataTable;
                    // sector_dropdown.DataTextField = "SectorName";
                    dataTable.Rows[0]["SectorName"] = "--Select--";
                    sector_dropdown.DataSource = dataTable;
                    sector_dropdown.DataTextField = "SectorName";
                    sector_dropdown.DataValueField = "SectorName";
                    sector_dropdown.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void VenueofInteraction_Details()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("Getvenueofinteractiondetails", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                    dataTable.Rows[0]["ID"] = 0;
                    dataTable.Rows[0]["Venue of Interaction"] = "--Select--";
                    Interaction_Venue.DataSource = dataTable;
                    Interaction_Venue.DataTextField = "Venue of Interaction";
                    Interaction_Venue.DataValueField = "ID";
                    Interaction_Venue.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void Mandal_List()
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GETMandal_EXISTING_ENTREPRENEURS", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (Session["DistrictID"] != null && !string.IsNullOrEmpty(Session["DistrictID"].ToString()))
                {
                    int district = Convert.ToInt32(Session["DistrictID"].ToString().TrimEnd());
                    command.Parameters.Add(new SqlParameter("@District_ID", SqlDbType.Int)).Value = district;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                        dataTable.Rows.InsertAt(dataTable.NewRow(), 0);
                        dataTable.Rows[0]["Manda_lName"] = "--Select--";
                        ddl_Mandal.DataSource = dataTable;
                        ddl_Mandal.DataTextField = "Manda_lName";
                        ddl_Mandal.DataValueField = "Mandal_Id";
                        ddl_Mandal.DataBind();
                        if(ddl_Mandal.Items.Count >0)
                        {
                            VenueofInteraction_Details();
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/tsHome.aspx");
                }
                con.CloseConnection();
            }
        }
    }


    private void PMFME_FINANCIAL_Details(string Scheme_Name)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetFinancialDetails", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Scheme", Scheme_Name);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    PMFME_FINANCIAL.DataSource = dataTable;
                    PMFME_FINANCIAL.DataTextField = "FD_Name";
                    PMFME_FINANCIAL.DataValueField = "FD_ID";
                    PMFME_FINANCIAL.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    private void MUDRA_ELIGIBILITY_Details(string Scheme_Name)
    {
        DataTable dataTable = new DataTable();
        con.OpenConnection();
        {
            using (SqlCommand command = new SqlCommand("GetEligibilityCriteria", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Scheme_Name", Scheme_Name);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    MUDRA_ELIGIBILITY.DataSource = dataTable;
                    MUDRA_ELIGIBILITY.DataTextField = "EC_Name";
                    MUDRA_ELIGIBILITY.DataValueField = "EC_ID";
                    MUDRA_ELIGIBILITY.DataBind();
                }
                con.CloseConnection();
            }
        }
    }
    protected void Land_Grievance_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Land_Grievance.SelectedValue == "0")
        //{ TSIIC_LAND_Select.Visible = true; }
        //else { TSIIC_LAND_Select.Visible = false; }
        //if (Land_Grievance.SelectedValue == "1")
        //{ Land_Text_Box.Visible = true; }
        //else { Land_Text_Box.Visible = false; }
    }
    protected void Scheme_Names_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Scheme_Names.Items[0].Selected)
        {
            PMEGP_CONTENT.Visible = true;
            PMEGP_ELIGIBILTY_Details("PMEGP"); PMEGP_FINANCIAL_Details("PMEGP");
        }
        else { PMEGP_CONTENT.Visible = false; }
        if (Scheme_Names.Items[1].Selected)
        {
            PMFME_CONTENT.Visible = true;
            PMFME_ELIGIBILTY_Details("PMFME"); PMFME_FINANCIAL_Details("PMFME");
        }
        else { PMFME_CONTENT.Visible = false; }
        if (Scheme_Names.Items[2].Selected)
        {
            T_IDEA.Visible = true;
        }
        else { T_IDEA.Visible = false; }
        if (Scheme_Names.Items[3].Selected)
        {
            T_PRIDE.Visible = true;
        }
        else { T_PRIDE.Visible = false; }
        if (Scheme_Names.Items[4].Selected)
        {
            Mudra_block.Visible = true;
            //MUDRA_ELIGIBILITY_Details();
        }
        else { Mudra_block.Visible = false; }
        if (Scheme_Names.Items[5].Selected)
        {
            CGTMSE_block.Visible = true;
        }
        else { CGTMSE_block.Visible = false; }
        if (Scheme_Names.Items[6].Selected)
        {
            DALITHA_BANDHU.Visible = true;
        }
        else { DALITHA_BANDHU.Visible = false; }
    }


    //protected void ExperienceInSector_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if(ExperienceInSector.SelectedValue == "0")
    //    { TextYears.Visible = true; }
    //    else { TextYears.Visible = false; }
    //}

    protected void sector_dropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(sector_dropdown.SelectedItem.Text != "--Select--")
        //{ ExperienceSectorBlock_1.Visible = true; /*ExperienceSectorBlock_2.Visible = true;*/ }
        //else { ExperienceSectorBlock_1.Visible = false; /*ExperienceSectorBlock_2.Visible = false;*/ }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "0")
        { sector_category_1.Visible = true; sector_category_2.Visible = true; ExperienceSectorBlock_1.Visible = true; TextYears.Visible = true; }
        else { sector_category_1.Visible = false; sector_category_2.Visible = false; ExperienceSectorBlock_1.Visible = false; TextYears.Visible = false; }
    }
    protected void PMEGP_VALIDATION_CheckedChanged(object sender, EventArgs e)
    {
        if (PMEGP_VALIDATION.Checked == true)
        { PMEGP_LINK.Visible = true; }
        else { PMEGP_LINK.Visible = false; }
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox4.Checked == true)
        { Div4.Visible = true; }
        else { Div4.Visible = false; }
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox3.Checked == true)
        { Div3.Visible = true; }
        else { Div3.Visible = false; }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox2.Checked == true)
        { Div2.Visible = true; }
        else { Div2.Visible = false; }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        { Div1.Visible = true; }
        else { Div1.Visible = false; }
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox5.Checked == true)
        { Div5.Visible = true; }
        else { Div5.Visible = false; };
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox6.Checked == true)
        { Div6.Visible = true; }
        else { Div6.Visible = false; };
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox7.Checked == true)
        { Div7.Visible = true; }
        else { Div7.Visible = false; }
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox8.Checked == true)
        { Div8.Visible = true; }
        else { Div8.Visible = false; };
    }
    //protected void Interaction_Venue_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Interaction_Venue.SelectedItem.Text == "Others")
    //    { Other_Venue_1.Visible = true; Other_Venue_2.Visible = true; }
    //    else { Other_Venue_1.Visible = false; Other_Venue_2.Visible = false; }
    //}
    protected void Candidate_Age_New_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Candidate_Age_New.Text) <= 18)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter age more than 18 years');", true);
        }
    }
    protected void Interaction_Level_Existing_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Interaction_Level_Existing.SelectedValue == "0")
        {
            Interaction_block_District.Visible = true;
            Interaction_Block.Visible = false;
            tdmandal.Visible = false;
            tdmandalddl.Visible = false; Interaction_Venue.ClearSelection(); ddl_Mandal.ClearSelection(); Interaction_Date.Text = "";
            //  Interaction_Venue_SelectedIndexChanged(sender, e);
        }
        else if (Interaction_Level_Existing.SelectedValue == "1")
        {
            Interaction_block_District.Visible = false;
            Interaction_Venue_District.Text = "";
            Interaction_Block.Visible = true;
            tdmandal.Visible = true;
            tdmandalddl.Visible = true; Interaction_Venue.ClearSelection(); Interaction_Date.Text = "";
            if (ddl_Mandal.Items.Count <= 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Mandal Level not yet Constituted');", true);
                tdmandal.Visible = false;
                tdmandalddl.Visible = false; Interaction_Venue.Text = ""; Interaction_Date.Text = "";
                Interaction_Level_Existing.ClearSelection();
                //Interaction_Level_Existing.SelectedIndex = -1;
                Interaction_Level_Existing_SelectedIndexChanged(sender, e);

            }
            // Interaction_Venue_SelectedIndexChanged(sender, e);
        }
        else
        {
            Interaction_block_District.Visible = false;
            Interaction_Block.Visible = false;
        }

    }
    protected void chkSchemes_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSchemes.Checked)
        {
            lblschms.Visible = false;
            lblTS.Visible = true; CheckTSIPASS.Visible = true;
            lbl1a.Visible = true; chkPMEGP.Visible = true;
            lbl1b.Visible = true; ChkPMFME.Visible = true;
            lbl1c.Visible = true; chkTidea.Visible = true;
            lbl1d.Visible = true; chkTpride.Visible = true;
            lbl1e.Visible = true; chkMudra.Visible = true;
            lbl1f.Visible = true; chkCGTMSE.Visible = true;
            lbl1g.Visible = true; chkDalitabandu.Visible = true;
            lbl1j.Visible = true; chckudyam.Visible = true;
        }
        else
        {
            lblschms.Visible = false;
            lbl1a.Visible = false; CheckTSIPASS.Visible = false; CheckTSIPASS.Checked = false; CheckTSIPASS_CheckedChanged(sender, e);
            lbl1a.Visible = false; chkPMEGP.Visible = false; chkPMEGP.Checked = false; chkPMEGP_CheckedChanged(sender, e);
            lbl1b.Visible = false; ChkPMFME.Visible = false; ChkPMFME.Checked = false; ChkPMFME_CheckedChanged(sender, e);
            lbl1c.Visible = false; chkTidea.Visible = false; chkTidea.Checked = false; chkTidea_CheckedChanged(sender, e);
            lbl1d.Visible = false; chkTpride.Visible = false; chkTpride.Checked = false; chkTpride_CheckedChanged(sender, e);
            lbl1e.Visible = false; chkMudra.Visible = false; chkMudra.Checked = false; chkMudra_CheckedChanged(sender, e);
            lbl1f.Visible = false; chkCGTMSE.Visible = false; chkCGTMSE.Checked = false; chkCGTMSE_CheckedChanged(sender, e);
            lbl1g.Visible = false; chkDalitabandu.Visible = false; chkDalitabandu.Checked = false; chkDalitabandu_CheckedChanged(sender, e);
            // lbl1i.Visible = false; chckNIMSME.Visible = false; chckNIMSME.Checked = false; chckNIMSME_CheckedChanged(sender, e);
            lbl1j.Visible = false; chckudyam.Visible = false; chckudyam.Checked = false; chckudyam_CheckedChanged(sender, e);
        }
    }
    protected void CheckTSIPASS_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckTSIPASS.Checked)
        {
            CheckTSIPASS.ForeColor = Color.DarkSlateBlue;
            Tsipass.Visible = true;
        }
        else
        {
            CheckTSIPASS.ForeColor = Color.Black; Tsipass.Visible = false;
        }
    }
    protected void chkPMEGP_CheckedChanged(object sender, EventArgs e)
    {
        if (chkPMEGP.Checked)
        {
            chkPMEGP.ForeColor = Color.DarkSlateBlue;
            PMEGP_CONTENT.Visible = true;
            PMEGP_ELIGIBILTY_Details("PMEGP"); PMEGP_FINANCIAL_Details("PMEGP");
        }
        else
        {
            chkPMEGP.ForeColor = Color.Black;
            chkPMEGP.Style["text-decoration"] = "none";
            PMEGP_CONTENT.Visible = false; PMEGP_VALIDATION.Checked = false;
        }
    }
    protected void ChkPMFME_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkPMFME.Checked)
        {
            ChkPMFME.ForeColor = Color.DarkSlateBlue;
            PMFME_CONTENT.Visible = true; PMFME_ELIGIBILTY_Details("PMFME"); PMFME_FINANCIAL_Details("PMFME");
        }
        else { ChkPMFME.ForeColor = Color.Black; PMFME_CONTENT.Visible = false; CheckBox1.Checked = false; }
    }
    protected void chkTidea_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTidea.Checked)
        {
            chkTidea.ForeColor = Color.DarkSlateBlue;
            T_IDEA.Visible = true;
        }
        else { chkTidea.ForeColor = Color.Black; T_IDEA.Visible = false; CheckBox5.Checked = false; }

    }
    protected void chkTpride_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTpride.Checked)
        {
            chkTpride.ForeColor = Color.DarkSlateBlue;
            T_PRIDE.Visible = true;
        }
        else { chkTpride.ForeColor = Color.Black; T_PRIDE.Visible = false; CheckBox6.Checked = false; }

    }
    protected void chkMudra_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMudra.Checked)
        {
            chkMudra.ForeColor = Color.DarkSlateBlue;
            Mudra_block.Visible = true; MUDRA_ELIGIBILITY_Details("Mudra");
        }
        else { chkMudra.ForeColor = Color.Black; Mudra_block.Visible = false; CheckBox2.Checked = false; }
    }
    protected void chkCGTMSE_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCGTMSE.Checked)
        {
            chkCGTMSE.ForeColor = Color.DarkSlateBlue;
            CGTMSE_block.Visible = true;
        }
        else { chkCGTMSE.ForeColor = Color.Black; CGTMSE_block.Visible = false; CheckBox7.Checked = false; }
    }
    protected void chkDalitabandu_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDalitabandu.Checked)
        {
            chkDalitabandu.ForeColor = Color.DarkSlateBlue;
            DALITHA_BANDHU.Visible = true;
        }
        else { chkDalitabandu.ForeColor = Color.Black; DALITHA_BANDHU.Visible = false; CheckBox8.Checked = false; }

    }
    protected void chkTrainings_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTrainings.Checked)
        {
            lbltrainings.Visible = true;
            lbl2a.Visible = true; chktasks.Visible = true;
            lbl2b.Visible = true; chkDET.Visible = true; chkDET.Checked = false;
            lbl1i.Visible = true; chckNIMSME.Visible = true;
        }
        else
        {
            lbltrainings.Visible = false;
            lbl2a.Visible = false; chktasks.Visible = false; chktasks.Checked = false; chktasks_CheckedChanged(sender, e);
            lbl2b.Visible = false; chkDET.Visible = false; chkDET.Checked = false; chkDET_CheckedChanged(sender, e);
        }


    }
    protected void chktasks_CheckedChanged(object sender, EventArgs e)
    {
        if (chktasks.Checked)
        {
            chktasks.ForeColor = Color.DarkSlateBlue;
            Trainingtasks_Block.Visible = true;
        }
        else
        {
            chktasks.ForeColor = Color.Black; Trainingtasks_Block.Visible = false; CheckBox3.Checked = false;
            lbl1i.Visible = false; chckNIMSME.Visible = false; chckNIMSME.Checked = false; chckNIMSME_CheckedChanged(sender, e);
        }

    }
    protected void chkDET_CheckedChanged(object sender, EventArgs e)
    {
        if (chkDET.Checked) { chkDET.ForeColor = Color.Gray; TrainingDET_Block.Visible = true; }
        else { chkDET.ForeColor = Color.Black; TrainingDET_Block.Visible = false; CheckBox4.Checked = false; }


    }
    protected void chkLand_CheckedChanged(object sender, EventArgs e)
    {
        if (chkLand.Checked)
        {

            if (Gender_New.Text == "" && Social_Category_New.SelectedValue == "0")
            {
                chkLand.Checked = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Gender and Social Status');", true);
                return;
            }
            else
            {
                TSIIC_LAND_Select.Visible = true;
                chkLand.ForeColor = Color.Gray;
                getVacanplots();
            }

        }
        else { chkLand.ForeColor = Color.Black; TSIIC_LAND_Select.Visible = false; RadioButtonList10.ClearSelection(); }
    }
    public void getVacanplots()
    {
        if (chkLand.Checked)
        {
            if (Gender_New.Text != "" && Social_Category_New.SelectedValue != "0")
            {
                DataSet ds = new DataSet();
                con.OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter("Sp_GetVacanplots", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Districtid", SqlDbType.Int).Value = Convert.ToInt32(Convert.ToString(Session["DistrictID"]));
                if (Gender_New.Text == "Female")
                {
                    da.SelectCommand.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = "FEMALE";
                }
                else
                { da.SelectCommand.Parameters.Add("@CATEGORY", SqlDbType.VarChar).Value = Social_Category_New.SelectedItem.Text.Trim(); }



                da.Fill(ds);
                con.CloseConnection();
                grdvacantplots.DataSource = ds;
                grdvacantplots.DataBind();
                grdvacantplots.Visible = true;
            }
            else
            {
                chkLand.Checked = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Gender and Social Status');", true);
                return;
            }
        }
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        //if (ModeOfInteraction.SelectedIndex != -1 && txtintractionDt.Text != "" && WomenCell.SelectedIndex != -1
        //    && Candidate_Name_New.Text != "" && Contact_Number_New.Text != "" && Mail_ID_New.Text != "" &&
        //    Candidate_Age_New.Text != "" && Gender_New.SelectedIndex != -1 && rblPHC.SelectedIndex != -1 &&
        //    Social_Category_New.SelectedItem.Text != "--Select--" && Qualification_List_New.SelectedItem.Text != "--Select--"
        //    && txtudyamregno.Text != "" && Visit_Purpose.Text != "" && RadioButtonList1.SelectedIndex != -1)



        string errormsg = "";
        if (ModeOfInteraction.SelectedIndex == -1)
        {
            errormsg += "Please select Mode of Interaction.\n";

        }
        if (txtintractionDt.Text == "")
        {
            errormsg += "Please enter Date of Interaction.\n";

        }
        if (WomenCell.SelectedIndex == -1)
        {
            errormsg += "Please select an option in Whether the interaction happened at Women Cell.\n";

        }
        if (Candidate_Name_New.Text == "")
        {
            errormsg += "Please enter Candidate's Name.\n";

        }
        if (Contact_Number_New.Text == "")
        {
            errormsg += "Please enter Contact Number.\n";

        }
        if (Mail_ID_New.Text == "")
        {
            errormsg += "Please enter Email ID.\n";

        }
        if (Candidate_Age_New.Text == "")
        {
            errormsg += "Please enter Age.\n";

        }
        if (Gender_New.SelectedIndex == -1)
        {
            errormsg += "Please select an option in Gender.\n";

        }
        if (rblPHC.SelectedIndex == -1)
        {
            errormsg += "Please select an option inPHC Category.\n";

        }
        if (Social_Category_New.SelectedItem.Text == "--Select--")
        {
            errormsg += "Please select an option Social Category.\n";

        }
        if (Qualification_List_New.SelectedItem.Text == "--Select--")
        {
            errormsg += "Please select an option Qualification.\n";

        }
        //if (txtudyamregno.Text != "")
        //{
        //    errormsg += "Please enter Udyam Registration.\n";
        //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Udyam Registration');", true);
        //    //return;
        //}
        if (Visit_Purpose.Text == "")
        {
            errormsg += "Please enter Purpose of Visit / Interaction.\n";

        }
        if (RadioButtonList1.SelectedIndex == -1)
        {
            errormsg += "Please select an option in Whether the applicant has any Sector specific Experience.\n";

            ClearErrorClasses();
            Interaction_Date.Text = txtintractionDt.Text;

            if (WomenCell.SelectedValue == "0")
            {
                if (Interaction_Level_Existing.SelectedIndex != -1)
                {
                    if (Interaction_Level_Existing.SelectedValue == "0")
                    {
                        if (Interaction_Venue_District.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all Details about District level interaction');", true);
                            return;
                        }
                        return;
                    }
                    else if (Interaction_Level_Existing.SelectedValue == "1")
                    {
                        if (ddl_Mandal.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Mandal');", true);
                            return;
                        }
                        else if (Interaction_Venue.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Mandal');", true);
                            return;
                        }
                        else if(Interaction_Venue.SelectedItem.Text != "--Select--")
                        {
                            if (Interaction_Venue.SelectedItem.Text == "Others")
                            {
                                if (OtherVenue.Text == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter Other Venue Details');", true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Enter all Details about mandal level interaction');", true);
                            return;
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Select Interaction tooks place at District level or not');", true);
                    return;
                }
            }
            if (RadioButtonList1.SelectedValue == "0")
            {
                if (sector_dropdown.SelectedItem.Text == "--Select--" || YearsofExperience.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all details about sector experience');", true);
                    return;
                }
            }
            else
            {

                ClearErrorClasses();
                ValidateAndHighlightRadioBtn(ModeOfInteraction); ValidateAndHighlightRadioBtn(WomenCell); ValidateAndHighlight(Candidate_Name_New); ValidateAndHighlight(Contact_Number_New);
                ValidateAndHighlight(Mail_ID_New); ValidateAndHighlight(Candidate_Age_New); ValidateAndHighlightRadioBtn(Gender_New); ValidateAndHighlightdropdown(Social_Category_New);
                ValidateAndHighlightdropdown(Qualification_List_New); ValidateAndHighlight(txtPAN); ValidateAndHighlightRadioBtn(RadioButtonList1); ValidateAndHighlightdropdown(sector_dropdown);
                ValidateAndHighlight(YearsofExperience); ValidateAndHighlight(Visit_Purpose); ValidateAndHighlightRadioBtn(rblPHC);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Highlighted Sections Below to Proceed Further.');", true);
                //missingDetailsAlert", "alert(' "  + errormsg + " ')", true);





            }
        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please Fill all the Highlighted Sections Below to Proceed Further.');", true);
        //return;
        //if (ModeOfInteraction.SelectedItem != null && !string.IsNullOrEmpty(ModeOfInteraction.SelectedItem.Text) && WomenCell.SelectedItem != null &&
        //    !string.IsNullOrEmpty(WomenCell.SelectedItem.Text) && !string.IsNullOrEmpty(Candidate_Name_New.Text) && !string.IsNullOrEmpty(Candidate_Age_New.Text) &&
        //    !string.IsNullOrEmpty(Contact_Number_New.Text) && !string.IsNullOrEmpty(Mail_ID_New.Text) &&
        //    Gender_New.SelectedItem != null && !string.IsNullOrEmpty(Gender_New.SelectedItem.Text) && Qualification_List_New.SelectedItem != null && !string.IsNullOrEmpty(Qualification_List_New.SelectedItem.Text) &&
        //    Social_Category_New.SelectedItem != null && rblPHC.SelectedItem != null && !string.IsNullOrEmpty(Social_Category_New.SelectedItem.Text) && !string.IsNullOrEmpty(Visit_Purpose.Text) && RadioButtonList1.SelectedItem != null)
        //{

        if (errormsg == "")
        {
            DataTable NEW_ENTREPRENEUR_DATA = new DataTable();
            ClearErrorClasses();
            int InteractionID;
            con.OpenConnection();

            using (SqlCommand command = new SqlCommand("DataBind_tbl_NEW_ENTREPRENEURS", con.GetConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ModeofInteraction", GetSelectedValue(ModeOfInteraction));
                command.Parameters.AddWithValue("@InteractionDatetime", ToDBValue(txtintractionDt.Text));
                string onlydt = (txtintractionDt.Text).Substring(0, 10);
                //command.Parameters.AddWithValue("@onlyDateIntraction", onlydt);
                command.Parameters.Add("@onlyDateIntraction", SqlDbType.Date).Value = DateTime.ParseExact(onlydt, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                command.Parameters.AddWithValue("@WomenCell", GetSelectedValue(WomenCell));
                command.Parameters.AddWithValue("@WomenCellinteraction", GetSelectedValue(Interaction_Level_Existing));
                if (Interaction_Level_Existing.SelectedValue == "0")
                {
                    command.Parameters.AddWithValue("@VenueofInteraction", Interaction_Venue_District.Text);
                }
                else
                {
                    command.Parameters.AddWithValue("@Mandal", GetSelectedValueddl(ddl_Mandal));
                    command.Parameters.AddWithValue("@DateWomenCell", ToDBValue(Interaction_Date.Text));
                    if (Interaction_Date.Text == "")
                        command.Parameters.Add("@OnlyDateWomenCell", SqlDbType.Date).Value = ToDBValue(Interaction_Date.Text);
                    else

                        command.Parameters.Add("@OnlyDateWomenCell", SqlDbType.Date).Value = DateTime.ParseExact((Interaction_Date.Text).Substring(0, 10), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                    //command.Parameters.AddWithValue("@OnlyDateWomenCell", (Interaction_Date.Text).Substring(0, 10));
                    //  command.Parameters.AddWithValue("@VenueofInteraction", GetSelectedValueddl(Interaction_Venue));

                    command.Parameters.AddWithValue("@VenueofInteraction", Interaction_Venue.Text);
                    command.Parameters.AddWithValue("@OtherVenue", ToDBValue(OtherVenue.Text));
                }
                command.Parameters.AddWithValue("@ApplicantName", Candidate_Name_New.Text);
                command.Parameters.AddWithValue("@Contactnumber", Contact_Number_New.Text);
                command.Parameters.AddWithValue("@Emailid", Mail_ID_New.Text);
                command.Parameters.AddWithValue("@Age", Candidate_Age_New.Text);
                command.Parameters.AddWithValue("@GENDER", GetSelectedValue(Gender_New));
                command.Parameters.AddWithValue("@SOCIALCATEGORY", GetSelectedValueddl(Social_Category_New));
                command.Parameters.AddWithValue("@isPHC", GetSelectedValue(rblPHC));
                command.Parameters.AddWithValue("@EDUCATIONALQUALIFICATION", GetSelectedValueddl(Qualification_List_New));
                command.Parameters.AddWithValue("@PANno", ToDBValue(txtPAN.Text));
                command.Parameters.AddWithValue("@PurposeofVisit", Visit_Purpose.Text);
                command.Parameters.AddWithValue("@AnySectorExperience", GetSelectedValue(RadioButtonList1));
                command.Parameters.AddWithValue("@SECTORName", GetSelectedValueddl(sector_dropdown));
                command.Parameters.AddWithValue("@ExperienceinYears", ToDBValue(YearsofExperience.Text));

                command.Parameters.AddWithValue("@ExplainedSchemes", chkSchemes.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeTSIPASS", CheckTSIPASS.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemePMEGP", chkPMEGP.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemePMFME", ChkPMFME.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeTIDEA", chkTidea.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeTPRIDE", chkTpride.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeMudra", chkMudra.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeCGTMSE", chkCGTMSE.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedSchemeDalithaBandhu", chkDalitabandu.Checked ? "YES" : "NO");


                command.Parameters.AddWithValue("@InterestedinTSIPASS", chkTSIPASSintrsted.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinPMEGP", PMEGP_VALIDATION.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinPMFME", CheckBox1.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinTIDEA", CheckBox5.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinTPRIDE", CheckBox6.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinMudra", CheckBox2.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinCGTMSE", CheckBox7.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinDalithaBandhu", CheckBox8.Checked ? "YES" : "NO");

                command.Parameters.AddWithValue("@ExplainedTrainings", chkTrainings.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedTASKS", chktasks.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedDET", chkDET.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinTASKS", CheckBox3.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinDET", CheckBox4.Checked ? "YES" : "NO");

                command.Parameters.AddWithValue("@ExplainedLand", chkLand.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@abtvacantplots", GetSelectedValue(RadioButtonList10));

                command.Parameters.AddWithValue("@Others", ToDBValue(OTHER_ISSUES.Text));
                command.Parameters.AddWithValue("@createdby", Session["uid"].ToString());
                command.Parameters.AddWithValue("@DistrictID", Convert.ToInt32(Session["DistrictID"].ToString()));

                // command.Parameters.AddWithValue("@UdyamRegno", ToDBValue(txtudyamregno.Text.Trim()));

                command.Parameters.AddWithValue("@ExplainedUdyam", chckudyam.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinUdyam", chckdivudyam1.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@ExplainedNIMSME", chckNIMSME.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@InterestedinNIMSME", chckNIMSMEd.Checked ? "YES" : "NO");
                command.Parameters.AddWithValue("@WomenCellIntrlevel", GetSelectedValue(Interaction_Level_Existing));
                command.Parameters.Add("@InteractionID", SqlDbType.Int);
                command.Parameters["@InteractionID"].Direction = ParameterDirection.Output;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(NEW_ENTREPRENEUR_DATA);
                    InteractionID = (int)command.Parameters["@InteractionID"].Value;
                }
                con.CloseConnection();
                ViewState["InteractionID"] = InteractionID;
                ClearErrorClasses();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('All Details are Submitted Successfully');", true);
                SubmitBtn.Visible = false;
                SubmitBtn.BackColor = Color.DarkGray;
                PrintBtn.Visible = true;
            }
        }
        else
        {
            //ClearErrorClasses();
            //ValidateAndHighlight(Candidate_Name_New); ValidateAndHighlight(Candidate_Age_New); ValidateAndHighlight(Contact_Number_New); ValidateAndHighlight(Mail_ID_New); ValidateAndHighlightRadioBtn(ModeOfInteraction);
            //ValidateAndHighlightRadioBtn(RadioButtonList1);
            ////ValidateAndHighlightCHKBOX(Main_Interaction);
            //ValidateAndHighlightRadioBtn(WomenCell); ValidateAndHighlightRadioBtn(Gender_New);
            ////(Qualification_List_New); 
            //ValidateAndHighlight(Visit_Purpose);
            ////ValidateAndHighlightRadioBtn(Social_Category_New);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert(' " + errormsg + " ')", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('"+ errormsg + " ');", true);
        }
    }
    protected void ClearErrorClasses()
    {
        ModeOfInteraction.CssClass = ""; WomenCell.CssClass = ""; Candidate_Name_New.CssClass = ""; Candidate_Age_New.CssClass = ""; Contact_Number_New.CssClass = "";
        Mail_ID_New.CssClass = ""; Gender_New.CssClass = ""; Qualification_List_New.CssClass = ""; Social_Category_New.CssClass = "";
        Visit_Purpose.CssClass = ""; ddl_Mandal.CssClass = ""; Interaction_Date.CssClass = ""; Interaction_Venue.CssClass = ""; OtherVenue.CssClass = ""; YearsofExperience.CssClass = "";
        RadioButtonList1.CssClass = ""; sector_dropdown.CssClass = ""; OTHER_ISSUES.CssClass = ""; ; rblPHC.CssClass = "";
    }

    protected void ValidateAndHighlight(System.Web.UI.WebControls.TextBox textBox)
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            textBox.CssClass = "error-border";
        }
        else
        {
            textBox.CssClass = "";
        }
    }

    protected void ValidateAndHighlightRadioBtn(RadioButtonList radioButton)
    {
        if (radioButton.SelectedIndex >= 0)
        { radioButton.CssClass = ""; }
        else { radioButton.CssClass = "error-border"; }
    }

    protected void ValidateAndHighlightCHKBOX(CheckBoxList checkBoxList)
    {
        if (checkBoxList != null)
        {
            bool isSelected = false;
            foreach (ListItem item in checkBoxList.Items)
            {
                if (item.Selected)
                {
                    isSelected = true;
                    break;
                }
            }
            checkBoxList.CssClass = isSelected ? "" : "error-border";
        }
    }

    protected void ValidateAndHighlightdropdown(DropDownList dropDownlist)
    {
        if (dropDownlist.SelectedItem.Text == "--Select--")
        { dropDownlist.CssClass = "error-border"; }
        else { dropDownlist.CssClass = ""; }
    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UI/TSIPASS/Personal_Interaction_Page_New_Entrepreneurs.aspx");
    }
    private object GetSelectedValue(ListControl control)
    {
        return control.SelectedItem != null ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    object ToDBValue(string str)
    {
        return string.IsNullOrEmpty(str) ? DBNull.Value : (object)str;
    }
    private object GetSelectedValueddl(ListControl control)
    {
        return control.SelectedItem.Text != "--Select--" ? (object)control.SelectedItem.Text : DBNull.Value;
    }
    protected void PrintBtn_Click(object sender, EventArgs e)
    {
        int InteractionID = (int)ViewState["InteractionID"];
        string dataToPass = InteractionID.ToString();

        string redirectUrl = "Personal_Interaction_Page_New_Entrepreneurs_PrintPage.aspx?InteractionID=" + dataToPass;

        string script = "window.open('" + redirectUrl + "', '_blank', 'width=1500,height=1500');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", script, true);
    }

    protected void chkTSIPASSintrsted_CheckedChanged(object sender, EventArgs e)
    {
        if (chkTSIPASSintrsted.Checked)
        { LinkTSIPASS.Visible = true; }

    }

    protected void LinkTSIPASS_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://ipass.telangana.gov.in/";
            sendLinkbymail("TSIPASS Website ", link);
            LinkTSIPASS.ForeColor = Color.DarkGray;
            LinkTSIPASS.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkPMEGP_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://kviconline.gov.in/pmegpeportal/pmegphome/index.jsp";
            sendLinkbymail("PMEGP Website ", link);
            LinkPMEGP.ForeColor = Color.DarkGray;
            LinkPMEGP.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkPMFME_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://pmfme.mofpi.gov.in/pmfme/#/Home-Page";
            sendLinkbymail("PMFME Website ", link);
            LinkPMFME.ForeColor = Color.DarkGray;
            LinkPMFME.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkTIDEA_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://industries.telangana.gov.in/Library/2015INDS_MS77.pdf";
            sendLinkbymail("T-IDEA Website ", link);
            LinkTIDEA.ForeColor = Color.DarkGray;
            LinkTIDEA.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void LinkTPRIDE_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://industries.telangana.gov.in/Library/2015INDS_MS78.pdf";
            sendLinkbymail("PMEGP Website", link);
            LinkTPRIDE.ForeColor = Color.DarkGray;
            LinkTPRIDE.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkMUDRA_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.mudra.org.in/";
            sendLinkbymail("MUDRA Website ", link);
            LinkMUDRA.ForeColor = Color.DarkGray;
            LinkMUDRA.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    //protected void LinkUDYAMIMITRA_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string link = "https://udyamimitra.in/page/mudra-loans";
    //        sendLinkbymail("UDYAMIMITRA Website ", link);
    //    }
    //    catch (Exception ex)
    //    { throw ex; }

    //}

    protected void LinkCGTMSE_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.cgtmse.in/Home";
            sendLinkbymail("CGTMSE Website ", link);
            LinkCGTMSE.ForeColor = Color.DarkGray;
            LinkCGTMSE.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkDalithaBandhu_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.db2021.telangana.gov.in/";
            sendLinkbymail("DalithaBandhu Website", link);
            LinkDalithaBandhu.ForeColor = Color.DarkGray;
            LinkDalithaBandhu.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkTASK_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://task.telangana.gov.in/";
            sendLinkbymail("TASK (Telangana) Website", link);
            LinkTASK.ForeColor = Color.DarkGray;
            LinkTASK.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void LinkDET_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://employment.telangana.gov.in";
            sendLinkbymail("Employment(Telangana) Website", link);
            LinkDET.ForeColor = Color.DarkGray;
            LinkDET.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void sendLinkbymail(string Type, string link)
    {
        try
        {
            if (Mail_ID_New.Text != "")
            {
                string from = "tsipass.telangana@gmail.com";
                string to = Mail_ID_New.Text;
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, ":: TSiPASS ::", System.Text.Encoding.UTF8);
                mail.Subject = Type + "Link";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "Dear Sir/madam, <br><br> This is the link of " + Type + ": -" + "<a href = '" + link + "' target = '_blank' >" + Type + "</a>" + " <br> Please click on the above link to know about " + Type + "<br> <br>Regards,<br>Commissionerate of Industries,<br>MSME WING.";
                mail.BodyEncoding = System.Text.Encoding.UTF8;

                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();

                //client.Credentials = new System.Net.NetworkCredential(from, "lrefskmlxnoowqtc");//
                client.Credentials = new System.Net.NetworkCredential(from, "fqeq nive azke giwb");//

                client.Port = 587; // Gmail works on this port lrefskmlxnoowqtc
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Gmail works on Server Secured Layer tsipass@2016
                try
                {
                    client.Send(mail);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('An EMail has been sent');", true);
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    HttpContext.Current.Response.Write(errorMessage);
                } // end try
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "missingDetailsAlert", "alert('Please enter Mail ID');", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdtsiic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdtsiic.SelectedValue == "0")
        {
            divtsiic.Visible = true;
        }
        else
        {
            divtsiic.Visible = false;
        }
    }

    protected void lkbtsiic_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://tsiic.telangana.gov.in/PMVacantPlots";
            sendLinkbymail("TSIIC Website ", link);
            lkbtsiic.ForeColor = Color.DarkGray;
            lkbtsiic.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chckNIMSME_CheckedChanged(object sender, EventArgs e)
    {
        if (chckNIMSME.Checked == true)
        {
            divNIMSME.Visible = true;
        }
        else
        {
            divNIMSME.Visible = false;
            DivNIMSME1.Visible = false;
            chckNIMSMEd.Checked = false;
        }
    }

    protected void chckNIMSMEd_CheckedChanged(object sender, EventArgs e)
    {
        if (chckNIMSMEd.Checked == true)
        {
            DivNIMSME1.Visible = true;
        }
        else
        {
            DivNIMSME1.Visible = false;
        }
    }

    protected void lnkNIMSME_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://www.nimsme.org/";
            sendLinkbymail("NIMSME Website ", link);
            lnkNIMSME.ForeColor = Color.DarkGray;
            lnkNIMSME.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void chckudyam_CheckedChanged(object sender, EventArgs e)
    {
        if (chckudyam.Checked == true)
        { divudyam.Visible = true; }
        else
        {
            divudyam.Visible = false;
            Divudaym1.Visible = false;
            chckdivudyam1.Checked = false;
        }

    }

    protected void chckdivudyam1_CheckedChanged(object sender, EventArgs e)
    {
        if (chckdivudyam1.Checked == true)
        {
            Divudaym1.Visible = true;
        }
        else
        {
            Divudaym1.Visible = false;
        }
    }

    protected void lnkudyam_Click(object sender, EventArgs e)
    {
        try
        {
            string link = "https://udyamregistration.gov.in/Government-India/Ministry-MSME-registration.htm";
            sendLinkbymail("Udyam Registration Website ", link);
            lnkudyam.ForeColor = Color.DarkGray;
            lnkudyam.Enabled = false;
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void Gender_New_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //getVacanplots();
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void Social_Category_New_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            getVacanplots();
            if (Social_Category_New.SelectedItem.Text == "OBC" || Social_Category_New.SelectedItem.Text == "ST" || Social_Category_New.SelectedItem.Text == "SC" || Social_Category_New.SelectedItem.Text == "Minority")
            {
                landdesc.Text = "3a. Whether information on vacant plots mandated to Weaker Section is informed :";
                grdvacantplots.Visible = true;
            }
            else
            {
                landdesc.Text = "3a. Whether information on vacant plots informed :";
                grdvacantplots.Visible = false;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void Interaction_Venue_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Interaction_Venue.SelectedItem.Text == "Others")
            {
                Other_Venue_1.Visible = true;
                Other_Venue_2.Visible = true;
                Interaction_Venue.Visible = true;
            }
            else
            {
                Other_Venue_1.Visible = false;
                Other_Venue_2.Visible = false;
                //Interaction_Venue.Visible = false;
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
}